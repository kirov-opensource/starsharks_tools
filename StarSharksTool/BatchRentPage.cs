using Microsoft.Extensions.Logging;
using Nethereum.Web3;
using StarSharksTool.Contracts.ERC20;
using StarSharksTool.Models;
using StarSharksTool.Models.RentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarSharksTool
{
    public partial class BatchRentPage : Form
    {
        public HashSet<int> BlackIds = new HashSet<int>() { 47251 };
        public Dictionary<string, AccountModel> allAccounts = Global.Accounts.ToDictionary(c => c.Account.Address.ToLower());
        public Dictionary<(int, int), string> RentHistory = new Dictionary<(int, int), string>();
        public Dictionary<string, AccountModel> NeedRentAccounts = new Dictionary<string, AccountModel>();
        public HashSet<string> RentLock = new HashSet<string>();
        public RentLock obj = null;
        public bool Renting = false;
        public int RentedSharkCount = 0;
        public object ParallelLocker = new object();

        public BatchRentPage()
        {
            obj = new RentLock() { Nonce = 0 };
            InitializeComponent();

            priceTextbox.Text = Global.AppSettings.RENT.SEA_PRICE.ToString();
            gasPrice.Text = Global.AppSettings.RENT.GAS_PRICE.ToString();
            rentProxy.Text = Global.AppSettings.RENT.MARPLACE_PROXY;
            foreach (var item in allAccounts)
            {
                CheckBox cbx = new CheckBox();
                cbx.Text = item.Value.Alias;
                bool defaultChecked = item.Value.Alias.Contains("main") == false;
                cbx.Click += (object? sender, EventArgs e) =>
                {
                    if ((sender as CheckBox).Checked == true)
                    {
                        NeedRentAccounts.Add(item.Key, item.Value);
                    }
                    else
                    {
                        NeedRentAccounts.Remove(item.Key);
                    }
                };
                cbx.Checked = defaultChecked;
                if (defaultChecked)
                {
                    NeedRentAccounts.Add(item.Key, item.Value);
                }
                flowLayoutPanel1.Controls.Add(cbx);
                Task.Run(() =>
                {
                    var web3 = new Web3(item.Value.Account, Global.BSC_URL);
                    var seaContractHandler = web3.Eth.GetContractHandler(Global.SEA_ADDRESS);
                    var balanceOfFunction = new BalanceOfFunction
                    {
                        Owner = item.Value.Account.Address
                    };
                    while (true)
                    {
                        Thread.Sleep(5000);
                        try
                        {
                            if (!NeedRentAccounts.ContainsKey(item.Value.Account.Address.ToLower()))
                            {
                                return;
                            }
                            var seaBalanceOfFunctionReturn = seaContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction).ConfigureAwait(false).GetAwaiter().GetResult();
                            var walletSeaCount = seaBalanceOfFunctionReturn / 1000000000000000000;
                            MethodInvoker mi = new MethodInvoker(() =>
                            {
                                var textboxPrice = Convert.ToInt32(priceTextbox.Text);
                                if (cbx.Checked == true && textboxPrice > walletSeaCount)
                                {
                                    cbx.Checked = false;
                                    NeedRentAccounts.Remove(item.Value.Account.Address.ToLower());
                                }
                                cbx.Text = $"{item.Value.Alias}({walletSeaCount})";
                            });
                            BeginInvoke(mi);
                        }
                        catch (InvalidOperationException)
                        {
                            break;
                        }
                        catch (Exception e)
                        {

                        }
                    }
                });

            }


            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        await Task.Delay(500);
                        var gasPrice = Global.GetGasPrice(Convert.ToInt32(this.priceTextbox.Text));
                        MethodInvoker mi = new MethodInvoker(() =>
                        {
                            var textboxPrice = Convert.ToInt32(priceTextbox.Text);
                            dynamicGasLbl.Text = $"{gasPrice}";
                        });
                        BeginInvoke(mi);
                    }
                    catch (InvalidOperationException)
                    {
                        break;
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
            });

            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        await Task.Delay(3);
                        MethodInvoker mi = new MethodInvoker(() =>
                        {
                            if (NeedRentAccounts.Count == 0)
                            {
                                this.autoRent.Checked = false;
                                this.checkBox1.Checked = false;
                            }
                        });
                        BeginInvoke(mi);
                    }
                    catch (InvalidOperationException)
                    {
                        break;
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
            });
        }


        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            await RefreshData();
        }
        private async Task RefreshData()
        {
            try
            {

                var textboxPrice = Convert.ToInt32(priceTextbox.Text);
                var level = 1;
                if (level1.Checked)
                {
                    level = 1;
                }
                else if (level2.Checked)
                {
                    level = 2;
                }
                else if (level3.Checked)
                {
                    level = 3;
                }
                var c = await Services.Service.GetMarketplace(textboxPrice, level, rentProxy.Text);
                var model = c.Data.Sharks;
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Id"));
                dt.Columns.Add(new DataColumn("Price"));
                List<Task> autoRentTask = new List<Task>();
                Random r = new Random();
                if (model != null)
                {
                    foreach (var item in model)
                    {
                        if (BlackIds.Contains(item.Attr.SharkId))
                            continue;
                        var price = (int)Convert.ToDouble(item.Sheet.RentExceptGain);
                        for (int i = 0; i < NeedRentAccounts.Count; i++)
                        {
                            if (this.autoRent.Checked == true && price <= textboxPrice && NeedRentAccounts.Count > 0)
                            {
                                var shark = model[r.Next(0, model.Count - 1)];
                                if (!Services.Service.RentedSharkIds.Contains(shark.Attr.SharkId))
                                {
                                    autoRentTask.Add(this.RentShark(shark.Attr.SharkId, price));
                                }
                            }
                        }
                        var dr = dt.NewRow();
                        dr["Id"] = item.Attr.SharkId.ToString();
                        dr["Price"] = item.Sheet.RentExceptGain;
                        dt.Rows.Add(dr);
                    }
                }

                this.dataGridView1.DataSource = dt;

                if (dataGridView1.Columns.GetLastColumn(DataGridViewElementStates.None, DataGridViewElementStates.None).Name != "rentBtnColumn")
                {
                    DataGridViewButtonColumn rentBtnColumn = new DataGridViewButtonColumn();
                    rentBtnColumn.Text = "租他";
                    rentBtnColumn.HeaderText = "操作";
                    rentBtnColumn.Name = "rentBtnColumn";
                    rentBtnColumn.DefaultCellStyle.NullValue = "租它";
                    dataGridView1.Columns.Add(rentBtnColumn);
                }
                if (autoRentTask.Any())
                {
                    Task.Run(async () => { await Task.WhenAll(autoRentTask); });
                }
            }
            catch (Exception e)
            {
                Global.GetLogger("BatchRentPage").LogError(e, e.Message);
            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "rentBtnColumn" && e.RowIndex >= 0)
            {
                Renting = false;
                var sharkId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                var maxPrice = (int)Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Price"].Value);
                await this.RentShark(sharkId, maxPrice);
            }
        }
        public void RerenderRentHistory()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RentId");
            dt.Columns.Add("RentPrice");
            dt.Columns.Add("Status");
            var tmp = RentHistory.Reverse();
            foreach (var item in tmp)
            {
                dt.Rows.Add(item.Key.Item1, item.Key.Item2, item.Value);
            }
            rentHistory.DataSource = dt;
        }
        private async Task RentShark(int sharkId, int maxPrice, decimal gasPrice = 6)
        {
            Random r = new Random();
            var accountAddresses = NeedRentAccounts.Keys.ToList();
            string luckyAccountAddress = string.Empty;
            int retry = 0;
            do
            {
                retry++;
                if (retry > 5)
                {
                    return;
                }
                if (NeedRentAccounts.Count == RentLock.Count)
                {
                    return;
                }
                luckyAccountAddress = accountAddresses[r.Next(0, accountAddresses.Count)];
                accountAddresses = NeedRentAccounts.Keys.ToList();
            } while (!NeedRentAccounts.ContainsKey(luckyAccountAddress) || RentLock.Contains(luckyAccountAddress));

            var _accountModel = NeedRentAccounts[luckyAccountAddress];

            if (RentHistory.ContainsKey((sharkId, maxPrice)))
            {
                return;
            };
            if (BlackIds.Contains(sharkId))
            {
                return;
            };
            RentHistory.Add((sharkId, maxPrice), "租赁中");
            if (dynamicGas.Checked == false)
            {
                decimal parsedGasPrice = 0;
                decimal.TryParse(this.gasPrice.Text.Trim(), out parsedGasPrice);
                if (parsedGasPrice > 0)
                    gasPrice = parsedGasPrice;
            }
            else
            {
                var currentDynamicGasPrice = Global.GetGasPrice(Convert.ToInt32(this.priceTextbox.Text));
                if (maxDynamicGasPrice.Checked == true)
                {
                    var maxDynamicGasPrice = Convert.ToDecimal(maxDynamicGasPriceTbx.Text);
                    if (currentDynamicGasPrice > maxDynamicGasPrice)
                    {
                        return;
                    }
                }

                gasPrice = currentDynamicGasPrice;
            }

            RerenderRentHistory();
            BlackIds.Add(sharkId);

            try
            {
                RentLock.Add(luckyAccountAddress);
                var resp = await Services.Service.RentShark(_accountModel.Account.Address, sharkId, maxPrice, obj, gasPrice);
                if (resp.Item1 == 1)
                {
                    RentHistory[(sharkId, maxPrice)] = "租到了";
                    RentedSharkCount++;
                    rentedCountLabel.Text = $"已租{RentedSharkCount}条";
                }
                else
                {
                    RentHistory[(sharkId, maxPrice)] = $"没租到|{(resp.Item2.Equals(string.Empty) ? "扣手续费" : resp.Item2)}";
                }
            }
            catch (Exception e)
            {
                RentHistory[(sharkId, maxPrice)] = $"租用异常|{e.Message}";
            }
            finally
            {
                RentLock.Remove(luckyAccountAddress);
            }
            RerenderRentHistory();
        }

        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                try
                {
                    await AutoRefresh();
                }
                catch (Exception ex)
                {
                    Global.GetLogger("BatchRentPage").LogError(ex, ex.Message);
                }
            }
        }
        private async Task AutoRefresh()
        {
            while (this.checkBox1.Checked == true)
            {
                await RefreshData();
                await Task.Delay(200);
            }
        }

        private void RentPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.autoRent.Checked = false;
            this.checkBox1.Checked = false;
        }

        private void RentPage_Load(object sender, EventArgs e)
        {

        }

        private void dynamicGas_CheckedChanged(object sender, EventArgs e)
        {
            this.gasPrice.ReadOnly = dynamicGas.Checked == true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
