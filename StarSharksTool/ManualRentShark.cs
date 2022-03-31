using Nethereum.Web3;
using StarSharksTool.Contracts.ERC20;
using StarSharksTool.Models;
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
    public partial class ManualRentShark : Form
    {
        public Dictionary<(int, int), string> RentHistory = new Dictionary<(int, int), string>();
        public Dictionary<int, SharkModel> SharkData = new Dictionary<int, SharkModel>();
        private AccountModel _accountModel;
        public int RentedSharkCount { get; set; }
        private bool AutoRenting = false;
        public ManualRentShark(AccountModel accountModel)
        {
            InitializeComponent();
            _accountModel = accountModel;

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
                    if (approveContract.Enabled)
                    {
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
            AutoRenting = false;
            await this.RefreshData();
        }
        private async Task RerenderSharkData()
        {
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
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id"));
            dt.Columns.Add(new DataColumn("Price"));
            dt.Columns.Add(new DataColumn("Countdown"));
            List<Task> autoRentTask = new List<Task>();
            if (SharkData != null && SharkData.Count > 0)
            {
                foreach (var item in SharkData)
                {
                    if (item.Value.Attr.Star == level && item.Value.Sheet != null)
                    {
                        var dr = dt.NewRow();
                        dr["Id"] = item.Key.ToString();
                        dr["Price"] = priceTextbox.Text;
                        if (item.Value.Sheet?.RentExpireAt != null)
                        {
                            dr["Countdown"] = (DateTimeOffset.FromUnixTimeSeconds(item.Value.Sheet.RentExpireAt) - DateTime.Now).TotalSeconds.ToString("0.0");
                        }
                        dt.Rows.Add(dr);
                    }
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
        }
        private async Task RefreshData()
        {
            try
            {
                int estimatePrice = Convert.ToInt32(priceTextbox.Text);
                int rangeValue = Convert.ToInt32(range.Text);
                int offsetValue = Convert.ToInt32(offset.Text);
                var sharks = await Services.Service.GetChainRentHistory(offsetValue, rangeValue, estimatePrice);
                SharkData = await Services.Service.GetSharkDetails(sharks.Select(c => c.Item1));
                SharkData = SharkData
                    .Where(c => c.Value.Sheet != null)
                    .Where(c =>
                    {
                        return (DateTimeOffset.FromUnixTimeSeconds(c.Value.Sheet.RentExpireAt) - DateTime.Now).TotalSeconds > -10;
                    }).OrderBy(c => c.Value.Sheet.RentExpireAt).Take(5).ToDictionary(c => c.Key, c => c.Value);
                if (SharkData != null && SharkData.Count > 0)
                {
                    var shark = SharkData.FirstOrDefault().Value;
                    if (shark != null)
                    {
                        var countdown = (DateTimeOffset.FromUnixTimeSeconds(shark.Sheet.RentExpireAt) - DateTime.Now).TotalSeconds;
                        if (-6 > countdown)
                        {
                            this.offset.Text = (Convert.ToInt32(this.offset.Text) + 10).ToString();
                        }
                        else
                        {
                            var overflowOffset = (int)(countdown / 3);
                            if (overflowOffset > 0)
                            {
                                this.offset.Text = (Convert.ToInt32(this.offset.Text) - overflowOffset).ToString();
                            }
                        }
                    }
                    else
                    {
                        this.offset.Text = (Convert.ToInt32(this.offset.Text) + 100).ToString();
                    }
                }
                await RerenderSharkData();
            }
            catch
            {

            }
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "rentBtnColumn" && e.RowIndex >= 0)
            {
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

            //if (rentHistory.Columns.GetLastColumn(DataGridViewElementStates.None, DataGridViewElementStates.None).Name != "getGasColumn")
            //{
            //    DataGridViewButtonColumn rentBtnColumn = new DataGridViewButtonColumn();
            //    rentBtnColumn.Text = "查询Gas";
            //    rentBtnColumn.HeaderText = "查询Gas";
            //    rentBtnColumn.Name = "getGasColumn";
            //    rentBtnColumn.DefaultCellStyle.NullValue = "查询Gas";
            //    rentHistory.Columns.Add(rentBtnColumn);
            //}
        }
        private async Task RentShark(int sharkId, int maxPrice, decimal gasPrice = 6)
        {
            try
            {
                AutoRenting = true;
                if (RentHistory.ContainsKey((sharkId, maxPrice)) && RentHistory[(sharkId, maxPrice)] == "租到了")
                {
                    return;
                };
                if (RentHistory.ContainsKey((sharkId, maxPrice)))
                {
                    RentHistory[(sharkId, maxPrice)] = "租赁中";
                }
                else
                {
                    RentHistory.Add((sharkId, maxPrice), "租赁中");
                }
                if (dynamicGas.Checked == false)
                {
                    decimal parsedGasPrice = 0;
                    decimal.TryParse(this.gasPrice.Text.Trim(), out parsedGasPrice);
                    if (parsedGasPrice > 0)
                        gasPrice = parsedGasPrice;
                }
                else
                {
                    gasPrice = Global.GetGasPrice(Convert.ToInt32(this.priceTextbox.Text));
                }

                RerenderRentHistory();
                try
                {
                    var resp = await Services.Service.RentShark(_accountModel.Account.Address, sharkId, maxPrice, new Models.RentModels.RentLock(), gasPrice, true, dynamicGas.Checked);
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
                        await Task.Delay(1000 * 10);
                        if (this.checkBox1.Checked == true)
                        {
                            await this.RefreshData();
                        }
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
            finally
            {
                AutoRenting = false;
            }
        }

        private void ManualRentShark_Load(object sender, EventArgs e)
        {
            offset.Text = (400 + (((int)(DateTime.Now - new DateTime(2022, 03, 18)).TotalDays) * 100)).ToString();

        }

        private void autoRent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await RerenderSharkData();
            int offset = Convert.ToInt32(autoRentOffsetMs.Text);
            var estimatePrice = Convert.ToInt32(priceTextbox.Text);
            if (autoRent.Checked == true && AutoRenting == false)
            {
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
                foreach (var item in SharkData)
                {
                    if (item.Value.Sheet?.RentExpireAt != null && item.Value.Attr.Star == level)
                    {
                        //是正在出租状态可以参与比对,如果比当
                        if (item.Value.Sheet.RentExpireAt != 946684800)
                        {
                            var ts = (DateTimeOffset.FromUnixTimeSeconds(item.Value.Sheet.RentExpireAt) - DateTime.Now).TotalMilliseconds;
                            //已经过期，且在毫秒内
                            if (ts < 0 && (ts * -1) > offset && ((ts * -1) - offset) <= 100)
                            {
                                await this.RentShark(item.Key, estimatePrice);
                            }
                        }
                    }
                }
            }
        }

        private async void rentHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "getGasColumn" && e.RowIndex >= 0)
            //{
            //    var sharkId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["RentId"].Value);
            //    var (renter, gasPrice) = Services.Service.GetGasPriceBySharkId(sharkId);
            //}
        }

        private void dynamicGas_CheckedChanged(object sender, EventArgs e)
        {
            this.gasPrice.ReadOnly = dynamicGas.Checked == true;
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
                try
                {
                    await AutoRefresh();
                }
                catch { }
            }
        }

        private async Task AutoRefresh()
        {
            while (this.checkBox1.Checked == true)
            {
                await RefreshData();
                await Task.Delay(5000);
            }
        }
    }
}
