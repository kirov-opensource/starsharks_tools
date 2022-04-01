using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.JsonRpc.Client;
using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.Crypt;
using NPOI.POIFS.FileSystem;
using NPOI.XSSF.UserModel;
using Serilog;
using SharpAdbClient;
using StarSharksTool.Contracts.ERC20;
using StarSharksTool.Extensions;
using StarSharksTool.Models;
using System.Collections.Concurrent;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace StarSharksTool
{
    public partial class AccountManagement : Form
    {
        private readonly IDistributedCache cache;
        public AccountManagement()
        {
            InitializeComponent();
            this.cache = Global.Cache;
            //AccountControl ac1 = new AccountControl();
            //ac1.TopLevel = false;
            //flowLayoutPanel1.Controls.Add(ac1);

        }

        private void AccountManagement_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"adb\adb.exe"))
            {
                AdbServer server = new AdbServer();
                var result = server.StartServer(@"adb\adb.exe", restartServerIfNewer: true);
            }
            else
            {
                MessageBox.Show("当前目录未侦测到adb文件夹，无法使用adb登录");
            }

            string key = string.Empty;

            key = ShowPromptDialog("请输入密钥", "请输入密钥");
            if (string.IsNullOrWhiteSpace(key))
                Application.Exit();
            Global.KeyHash = MD5Helper.Compute(key);
            _ = ReloadAccount();
        }
        public static string ShowPromptDialog(string text, string caption, bool isPassword = true)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 300,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Height = 50, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 90, Width = 400, UseSystemPasswordChar = isPassword };
            //textBox.UseSystemPasswordChar = true;
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Height = 50, Top = 150, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private async Task ReloadAccount()
        {
            flowLayoutPanel1.BeginInvoke(() => flowLayoutPanel1.Controls.Clear());
            await LoadAccount();
        }

        private void DisableButton()
        {
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.button1.Enabled = false;
            this.batchRent.Enabled = false;
        }
        private void EnableButton()
        {
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            this.button1.Enabled = true;
            this.batchRent.Enabled = true;
        }

        private async Task LoadAccount()
        {

            var appSettings = new AppSettings() { Proxy = String.Empty, Accounts = new List<AccountInfo>(), BSC_URL = "https://bsc-dataseed.binance.org/", OpenId = String.Empty, RENT = new RentSettings() { GAS_PRICE = 5, MARPLACE_PROXY = "", SEA_PRICE = 14 } };
            if (File.Exists(Global.SETTING_PATH))
            {
                try
                {
                    appSettings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(Global.SETTING_PATH));
                }
                catch
                {
                    File.Delete(Global.SETTING_PATH);
                }
            }
            if (appSettings == null || !(appSettings.Accounts?.Any() ?? false))
            {
                File.WriteAllText(Global.SETTING_PATH, JsonConvert.SerializeObject(appSettings, Formatting.Indented));
                MessageBox.Show($"未找到私钥, 请在{Global.SETTING_PATH}填写私钥");
                return;
            }
            //Global.HTTPCLIENT = null;
            Global.AppSettings = appSettings;
            Global.PROXY = appSettings.Proxy;
            Global.BSC_URL = appSettings.BSC_URL ?? "https://bsc-dataseed1.binance.org/";
            Global.Web3 = new Web3(new RpcClient(new Uri(Global.BSC_URL), httpClient: Global.HTTPCLIENT));

            var web3 = Global.Web3;
            var accounts = new List<AccountModel>();

            BigInteger bnbQuantity = 0;
            BigInteger seaQuantity = 0;
            decimal useaQuantity = 0;
            long sharksCount = 0;
            long accountCount = 0;
            Global.Accounts.Clear();

            if (appSettings.Accounts.Count > 0)
            {
                try
                {
                    var c = appSettings.Accounts[0].DecryptedPrivateKey;
                }
                catch (CryptographicException e)
                {
                    MessageBox.Show("密钥不正确,程序自动退出");
                    Application.Exit();
                }
            }

            var loginResponses = appSettings.Accounts.Select(c => Services.Service.Login(new Account(c.DecryptedPrivateKey, 56), c.Alias, Global.Cache)).ToList();
            await Task.WhenAll(loginResponses);
            var accountInfos = loginResponses.ToDictionary(c => c.Result.Address.ToLower(), c => c.Result);

            ConcurrentBag<string> accountAddresses = new ConcurrentBag<string>(accountInfos.Keys);
            Dictionary<string, (AccountInfoModel, IList<SharkModel>, BigInteger, BigInteger, Nethereum.Hex.HexTypes.HexBigInteger)> accountDetailInfo = new Dictionary<string, (AccountInfoModel, IList<SharkModel>, BigInteger, BigInteger, Nethereum.Hex.HexTypes.HexBigInteger)>();
            var loadFinished = false;
            do
            {
                accountDetailInfo = accountDetailInfo.Where(c => c.Key != null).ToDictionary(c => c.Key, c => c.Value);
                var waitingLoadAddresses = accountAddresses.Except(accountDetailInfo.Keys);
                if (waitingLoadAddresses.Count() == 0)
                {
                    loadFinished = true;
                    break;
                }
                await Parallel.ForEachAsync(waitingLoadAddresses, new ParallelOptions { MaxDegreeOfParallelism = 4 }, async (address, cancelToken) =>
                {
                GET_RETRY:
                    try
                    {
                        var accountInfo = accountInfos[address.ToLower()];
                        var bscAccount = accountInfo.Account;
                        var websiteToken = accountInfo.WebsiteToken;
                        var gameToken = accountInfo.GameToken;
                        var alias = accountInfo.Alias;
                        var sharkAccountInfo = GetAccountInfo(websiteToken);
                        var sharks = GetSharks(websiteToken, bscAccount.Address);
                        var bnbBalance = web3.Eth.GetBalance.SendRequestAsync(bscAccount.Address);
                        var balanceOfFunction = new BalanceOfFunction
                        {
                            Owner = bscAccount.Address
                        };
                        var seaContractHandler = web3.Eth.GetContractHandler(Global.SEA_ADDRESS);
                        var seaBalanceOfFunctionReturn = seaContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction);
                        var sssContractHandler = web3.Eth.GetContractHandler(Global.SSS_ADDRESS);
                        var sssBalanceOfFunctionReturn = sssContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction);
                        await Task.WhenAll(sharkAccountInfo, sharks, seaBalanceOfFunctionReturn, sssBalanceOfFunctionReturn, bnbBalance);
                        if (address == null)
                        {
                            throw new Exception();
                        }
                        accountDetailInfo.Add(address, (sharkAccountInfo.Result, sharks.Result, seaBalanceOfFunctionReturn.Result, sssBalanceOfFunctionReturn.Result, bnbBalance.Result));
                    }
                    catch(Exception e)
                    {
                        Global.GetLogger("AccountManagement").LogError(e, e.Message);
                        goto GET_RETRY;
                    }
                });

            } while (loadFinished == false);


            foreach (var accountInfo in accountInfos)
            {
            RETRY:
                try
                {
                    var sharkAccountInfo = accountInfos[accountInfo.Key.ToLower()];
                    var bscAccount = sharkAccountInfo.Account;
                    var websiteToken = sharkAccountInfo.WebsiteToken;
                    var gameToken = sharkAccountInfo.GameToken;
                    var alias = sharkAccountInfo.Alias;
                    {
                        var (sharkAccountInfo1, sharks, seaBalance, sssBalance, bnbBalance) = accountDetailInfo[accountInfo.Key];
                        var account = new AccountModel
                        {
                            Account = sharkAccountInfo.Account,
                            WebsiteToken = websiteToken,
                            Alias = accountInfo.Value.Alias,
                            GameToken = gameToken,
                            AccountInfo = sharkAccountInfo1,
                            Sharks = sharks.OrderByDescending(x => x.Attr.Star).ThenByDescending(x => x.Attr.Power).ToDictionary(x => x!.Attr.SharkId)
                        };
                        accounts.Add(account);
                        var label = GenerateLabel($"BNB：{Web3.Convert.FromWei(bnbBalance.Value)}");
                        var label2 = GenerateLabel($"SSS：{Web3.Convert.FromWei(sssBalance)}");
                        var label3 = GenerateLabel($"SEA：{Web3.Convert.FromWei(seaBalance)}");
                        var label5 = GenerateLabel($"u-SEA：{account.AccountInfo.Amount}");
                        if ((int)account.AccountInfo.Amount != account.AccountInfo.Amount)
                        {
                            label5.BackColor = Color.Orange;
                        }
                        List<int> sharkRent = account.Sharks.Values.OrderByDescending(c => c.Attr.Star).ThenByDescending(c => c.Attr.Power).Take(5).Select(c => c.Attr.Power).ToList();
                        var label4 = GenerateLabel($"鲨鱼数量：{account.Sharks.Count} || TOP5体力:{(string.Join("|", sharkRent))}");
                        if (sharkRent.Count >= 2 && sharkRent[1] > 0)
                        {
                            label4.BackColor = Color.Orange;
                        }
                        bnbQuantity += bnbBalance.Value;
                        seaQuantity += seaBalance;
                        useaQuantity += account.AccountInfo.Amount;
                        sharksCount += account.Sharks.Count;
                        accountCount++;
                        label_sharks_count.Text = $"鲨鱼数量：{sharksCount}";
                        label_account_count.Text = $"账号数量：{accountCount}";
                        label_bnb_quantity.Text = $"BNB：{Web3.Convert.FromWei(bnbQuantity).ToString("0.0000")}";
                        label_sea_quantity.Text = $"SEA：{Web3.Convert.FromWei(seaQuantity).ToString("0.0")}";
                        label_u_sea_quantity.Text = $"u-SEA：{useaQuantity}";


                        var panelBNB = new Panel();
                        panelBNB.Location = new Point(6, 12);
                        panelBNB.Size = new Size(450, 25);
                        panelBNB.Controls.Add(label);

                        var panelSSS = new Panel();
                        panelSSS.Location = new Point(6, 43);
                        panelSSS.Size = new Size(450, 25);
                        panelSSS.Controls.Add(label2);

                        var panelSEA = new Panel();
                        panelSEA.Location = new Point(6, 74);
                        panelSEA.Size = new Size(450, 25);
                        panelSEA.Controls.Add(label3);

                        var panelUSEA = new Panel();
                        panelUSEA.Location = new Point(6, 105);
                        panelUSEA.Size = new Size(450, 25);
                        panelUSEA.Controls.Add(label5);

                        var panelSharksCount = new Panel();
                        panelSharksCount.Location = new Point(6, 136);
                        panelSharksCount.Size = new Size(450, 25);
                        panelSharksCount.Controls.Add(label4);

                        var panel5 = new Panel();
                        panel5.Size = new Size(450, 140);
                        panel5.Dock = DockStyle.Left;
                        panel5.Controls.Add(panelBNB);
                        panel5.Controls.Add(panelSSS);
                        panel5.Controls.Add(panelSEA);
                        panel5.Controls.Add(panelUSEA);
                        panel5.Controls.Add(panelSharksCount);

                        var qrbytes = QRCode.GenerateQRCodePNG($"{account.GameToken}");
                        var pictureBox = new PictureBox();
                        pictureBox.Size = new Size(200, 140);
                        pictureBox.Dock = DockStyle.Right;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBox.Image = Image.FromStream(StreamExtension.FromBytes(qrbytes));

                        var rentButton = new Button();
                        rentButton.Text = "快捷租赁";
                        rentButton.Location = new Point(150, 0);
                        rentButton.Click += async (object? sender, EventArgs e) =>
                        {
                            RentPage rp = new RentPage(account);
                            rp.Text = $"{alias}：租赁";
                            rp.Show();
                        };

                        var quickConnectButton = new Button();
                        quickConnectButton.Text = "ADB登录";
                        quickConnectButton.Location = new Point(290, 0);
                        quickConnectButton.Click += (object? sender, EventArgs e) =>
                        {
                            ADBLogin login = new ADBLogin(gameToken);
                            login.ShowDialog();
                        };

                        var withdrawButton = new Button();
                        withdrawButton.Text = "领取SEA";
                        withdrawButton.Location = new Point(360, 0);
                        withdrawButton.Click += async (object? sender, EventArgs e) =>
                        {
                            //await Services.Service.BuyShark(bscAccount.Address, 275762, 2);
                            if (MessageBox.Show("确认提出SEA吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                            {
                                try
                                {
                                    var resp = await Services.Service.Withdraw(bscAccount.Address);
                                    if (resp.Item1 == true)
                                    {
                                        MessageBox.Show(resp.Item2);
                                    }
                                    else
                                    {
                                        throw new Exception(resp.Item2);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"提取失败，原因:{ex.Message}");
                                }
                            }
                        };

                        var copyAddressButton = new Button();
                        copyAddressButton.Text = "复制";
                        copyAddressButton.Location = new Point(430, 0);
                        copyAddressButton.Click += (object? sender, EventArgs e) =>
                        {
                            Clipboard.SetDataObject(bscAccount.Address);
                        };



                        var groupBox = new GroupBox();
                        groupBox.Text = $"({alias}){bscAccount.Address[0..6]} **** {bscAccount.Address[^4..]}";
                        groupBox.Name = $"groupbox-{bscAccount.Address}";
                        groupBox.Dock = DockStyle.Top;
                        groupBox.Size = new Size(650, 190);
                        groupBox.Controls.Add(panel5);
                        groupBox.Controls.Add(pictureBox);
                        groupBox.Controls.Add(rentButton);
                        groupBox.Controls.Add(quickConnectButton);
                        groupBox.Controls.Add(withdrawButton);
                        groupBox.Controls.Add(copyAddressButton);

                        flowLayoutPanel1.Controls.Add(groupBox);
                        Global.Accounts.Add(account);
                    }
                }
                catch(Exception e)
                {
                    Global.GetLogger("AccountManagement").LogError(e, e.Message);
                    goto RETRY;
                }
            }
            //});

            //await Task.WhenAll(tasks);
        }
        private Label GenerateLabel(string text)
        {
            var label = new Label();
            label.Text = text.Length > 50 ? $"{text[0..50]}..." : text;
            label.AutoSize = true;
            label.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(3, 3);
            return label;
        }

        private async Task<AccountInfoModel> GetAccountInfo(string token)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://www.starsharks.com/go/auth-api/account/base");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var client = Global.HTTPCLIENT;
            {
                var httpResponse = await client.SendAsync(httpRequestMessage);
                var content = await httpResponse.Content.ReadAsStringAsync();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    Global.GetLogger("AccountManagement").LogError($"https://www.starsharks.com/go/auth-api/account/base 失败: {content}");
                    throw new HttpRequestException();
                }
                var responseModel = JsonConvert.DeserializeObject<ResponseModel<AccountInfoModel>>(content);
                return responseModel!.Data!;
            }
        }

        private async Task<IList<SharkModel>> GetSharks(string token, string address)
        {
            var query = new QuerySharksModel();
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://www.starsharks.com/go/auth-api/account/sharks");
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");
        RETRY:
            try
            {
                var client = Global.HTTPCLIENT;
                {
                    var httpResponse = await client.SendAsync(httpRequestMessage);
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    if (!httpResponse.IsSuccessStatusCode)
                    {
                        Global.GetLogger("AccountManagement").LogError($"https://www.starsharks.com/go/auth-api/account/sharks 失败: {content}");
                        throw new HttpRequestException();
                    }
                    var responseModel = JsonConvert.DeserializeObject<ResponseModel<PagenationModel<SharkModel>>>(content);
                    foreach (var sharkInfo in responseModel!.Data!.Sharks!)
                    {
                        sharkInfo.AccountAddress = address;
                    }

                    return responseModel!.Data!.Sharks!.Where(c => !(c.SharkStatus == Enums.SharkStatus.RentIn && c.Attr.Power == 0)).ToList();
                }
            }
            catch
            {
                goto RETRY;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = new SharkManagement();
            //this.Hide();
            s.Show();
            //this.Show();
            //_ = ReloadAccount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ = ReloadAccount();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            _ = ReloadAccount();
        }

        private void AddAccount_Click(object sender, EventArgs e)
        {
            string key = string.Empty;

            key = ShowPromptDialog("请输入密钥", "请输入密钥");
            if (string.IsNullOrWhiteSpace(key))
                return;
            var hashedKey = MD5Helper.Compute(key);
            if (hashedKey.Equals(Global.KeyHash, StringComparison.CurrentCultureIgnoreCase))
            {
                AddAccount account = new AddAccount();
                account.ShowDialog();
            }
            else
            {
                MessageBox.Show("密钥错误");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in Global.Accounts)
            {
                await Services.Service.Rename(item.Account.Address, item.Alias);
            }
        }

        private void AccountManagement_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BlackListListenerForm form = new BlackListListenerForm();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string key = string.Empty;

            key = ShowPromptDialog("请输入密钥", "请输入密钥");
            if (string.IsNullOrWhiteSpace(key))
                return;
            var hashedKey = MD5Helper.Compute(key);
            if (hashedKey.Equals(Global.KeyHash, StringComparison.CurrentCultureIgnoreCase))
            {
            REGENERATE_ACCOUNT:
                var account = ShowPromptDialog("请输入(识别前缀/鱼条数/账号数)，如(1/6/3)：1表示前缀，6表示有6条鱼，3表示1条鱼需要3个号", "批量生成账号", false);
                if (account.Split("/").Length == 3)
                {

                    var wb = new XSSFWorkbook();
                    var sheet = wb.CreateSheet();

                    var c = account.Split("/");
                    var prefix = c[0].Trim();
                    var sharkCount = Convert.ToInt32(c[1].Trim());
                    var perSharkAccount = Convert.ToInt32(c[2].Trim());
                    var appSettings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(Global.SETTING_PATH));
                    for (int i = 0; i < sharkCount; i++)
                    {
                        for (int j = 0; j < perSharkAccount; j++)
                        {
                            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
                            var privateKey = "0x" + ecKey.GetPrivateKeyAsBytes().ToHex();
                            string alias = $"{prefix}-{char.ConvertFromUtf32(0x0041 + i)}{j + 1}";
                            var address = new Account(privateKey, 56);
                            var row = sheet.CreateRow(i * perSharkAccount + j + 1);
                            row.CreateCell(1).SetCellValue(new Account(privateKey, 56).Address);
                            row.CreateCell(2).SetCellValue(privateKey);
                            row.CreateCell(3).SetCellValue(alias);
                            appSettings.Accounts.Add(new AccountInfo { Alias = alias, PrivateKey = AESHelper.Encrypt(privateKey.Trim()) });
                        }
                    }
                    var fileName = $"./{DateTime.Now.ToString("yyyyMMddHHmmss")}_accounts.xlsx";
                    using (var file = File.OpenWrite(fileName))
                    {
                        wb.Write(file);
                    }
                    File.WriteAllText(Global.SETTING_PATH, JsonConvert.SerializeObject(appSettings, Formatting.Indented));
                    MessageBox.Show($"当前目录已经生成备份文件:{fileName},请注意备份或自行加密！");
                }
                else
                {
                    MessageBox.Show("格式错误");
                    goto REGENERATE_ACCOUNT;
                }
            }
            else
            {
                MessageBox.Show("密钥错误");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RentCenter rc = new RentCenter();
            rc.Show();
        }

        private void tokenSenderBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://raca.wangshenjie.com/tokensender");
        }

        private void tokenCollectorBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://raca.wangshenjie.com/tokencollector");
        }

        private void openCurrentFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", System.Environment.CurrentDirectory);
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            await Parallel.ForEachAsync(Global.Accounts, async (item, cancelToken) =>
            {
                var isApproveContract = await Services.Service.IsApproveRentContract(item.Account.Address);
                if (isApproveContract == false)
                {
                    try
                    {
                        await Services.Service.ApproveContract(item.Account.Address);
                    }
                    catch (Exception e)
                    {
                        Global.GetLogger("AccountManagement").LogError(e, e.Message);
                        MessageBox.Show(item.Alias + "授权失败，原因：" + e.Message);
                    }
                }
            });
            MessageBox.Show("授权完毕");
        }

        private void batchRent_Click(object sender, EventArgs e)
        {
            BatchRentPage brp = new BatchRentPage();
            brp.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void AccountManagement_Resize(object sender, EventArgs e)
        {
            // Width - 29;
            // Height - 154;
            flowLayoutPanel1.Width = this.Width - 29;
            flowLayoutPanel1.Height = this.Height - 154;
        }
    }
}
