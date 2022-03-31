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
    public partial class RentPage : Form
    {
        public HashSet<int> BlackIds = new HashSet<int>() { 47251 };
        private AccountModel _accountModel;
        public Dictionary<(int, int), string> RentHistory = new Dictionary<(int, int), string>();
        public RentLock obj = null;
        public bool Renting = false;
        public int RentedSharkCount = 0;

        public RentPage(AccountModel accountModel)
        {
            obj = new RentLock() { Nonce = 0 };
            InitializeComponent();
            _accountModel = accountModel;

            priceTextbox.Text = Global.AppSettings.RENT.SEA_PRICE.ToString();
            gasPrice.Text = Global.AppSettings.RENT.GAS_PRICE.ToString();
            rentProxy.Text = Global.AppSettings.RENT.MARPLACE_PROXY;

            Task.Run(async () =>
            {
                var web3 = new Web3(_accountModel.Account, Global.BSC_URL);
                var seaContractHandler = web3.Eth.GetContractHandler(Global.SEA_ADDRESS);
                var balanceOfFunction = new BalanceOfFunction
                {
                    Owner = _accountModel.Account.Address
                };
                while (true)
                {
                    try
                    {
                        await Task.Delay(5000);
                        var seaBalanceOfFunctionReturn = await seaContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction);
                        var walletSeaCount = seaBalanceOfFunctionReturn / 1000000000000000000;
                        MethodInvoker mi = new MethodInvoker(() =>
                        {
                            var textboxPrice = Convert.ToInt32(priceTextbox.Text);
                            if (autoRent.Checked == true && textboxPrice > walletSeaCount)
                            {
                                this.autoRent.Checked = false;
                                this.checkBox1.Checked = false;
                            }
                            seaCountLbl.Text = $"SEA: {walletSeaCount}";
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

            Task.Run(async () =>
            {
                while (true)
                {
                    if (approveContract.Enabled) {
                        break;
                    }
                    try
                    {
                        await Task.Delay(5000);
                        bool isApproveContract = await Services.Service.IsApproveRentContract(this._accountModel.Account.Address);

                        MethodInvoker mi = new MethodInvoker(() =>
                        {
                            var textboxPrice = Convert.ToInt32(priceTextbox.Text);
                            if (isApproveContract == true)
                            {
                                approveContract.Enabled = false;
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
                    if (this.autoRent.Checked == true && price <= textboxPrice && autoRentTask.Count == 0)
                    {
                        var shark = model[r.Next(0, model.Count - 1)];
                        if (!Services.Service.RentedSharkIds.Contains(shark.Attr.SharkId))
                        {
                            autoRentTask.Add(this.RentShark(shark.Attr.SharkId, price));
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
                await Task.WhenAll(autoRentTask);
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
            foreach (var item in RentHistory)
            {
                dt.Rows.Add(item.Key.Item1, item.Key.Item2, item.Value);
            }
            rentHistory.DataSource = dt;
        }
        private async Task RentShark(int sharkId, int maxPrice, decimal gasPrice = 6)
        {
            if (RentHistory.ContainsKey((sharkId, maxPrice)))
            {
                return;
            };
            if (BlackIds.Contains(sharkId))
            {
                return;
            };
            RentHistory.Add((sharkId, maxPrice), "租赁中");
            decimal parsedGasPrice = 0;
            decimal.TryParse(this.gasPrice.Text.Trim(), out parsedGasPrice);
            if (parsedGasPrice > 0)
                gasPrice = parsedGasPrice;

            RerenderRentHistory();
            BlackIds.Add(sharkId);
            try
            {
                var resp = await Services.Service.RentShark(_accountModel.Account.Address, sharkId, maxPrice, obj, gasPrice);
                if (resp.Item1 == 1)
                {
                    RentHistory[(sharkId, maxPrice)] = "租到了";
                    RentedSharkCount++;
                    rentedCountLabel.Text = $"已租{RentedSharkCount}条";
                    var maxRentCountValue = int.Parse(maxRentCount.Text);
                    if (this.autoRent.Checked == true && RentedSharkCount >= maxRentCountValue)
                    {
                        this.autoRent.Checked = false;
                        this.checkBox1.Checked = false;
                    }
                    //MessageBox.Show("租到了");
                }
                else
                {
                    RentHistory[(sharkId, maxPrice)] = $"没租到|{resp.Item2}";
                }
            }
            catch (Exception e)
            {
                RentHistory[(sharkId, maxPrice)] = $"租用异常|{e.Message}";
            }
            RerenderRentHistory();
        }

        private async void approveContract_Click(object sender, EventArgs e)
        {
            var resp = await Services.Service.ApproveContract(this._accountModel.Account.Address);
            if (resp)
            {
                MessageBox.Show("授权成功");
            }
            else
            {
                MessageBox.Show("授权失败");
            }
        }

        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //Task.Run(() =>
                //{
                try
                {
                    await AutoRefresh();
                }
                catch { }
                //}).ConfigureAwait(false);
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
    }
}
