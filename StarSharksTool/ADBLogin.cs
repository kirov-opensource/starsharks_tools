using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarSharksTool
{
    public partial class ADBLogin : Form
    {
        private readonly string token = "";
        public ADBLogin(string token)
        {
            InitializeComponent();
            this.token = token;
        }

        private void ADBLogin_Load(object sender, EventArgs e)
        {
            LoadAdbDevices();
        }

        public void LoadAdbDevices()
        {

            if (!File.Exists(@"adb\adb.exe"))
            {
                MessageBox.Show("当前目录未侦测到adb文件夹，无法使用adb登录");
                return;
            }
            try
            {
                AdbServer server = new AdbServer();
                var result = server.StartServer(@"adb\adb.exe", restartServerIfNewer: true);
                CancellationTokenSource cts = new CancellationTokenSource();
                var client = new SharpAdbClient.AdbClient();
                var devices = client.GetDevices();
                foreach (var item in devices.OrderBy(c => c.Model))
                {
                    if (item.State == SharpAdbClient.DeviceState.Online)
                    {
                        Button button = new Button();
                        button.Text = $"{item.Model}";
                        button.Click += async (object? sender, EventArgs e) =>
                        {
                            await client.ExecuteRemoteCommandAsync("am force-stop com.starsharks.game", item, null, cts.Token);
                            await client.ExecuteRemoteCommandAsync($@"am start -W -a android.intent.action.VIEW -c android.intent.category.BROWSABLE -d ""sss://warrior/login?token={token}""", item, null, cts.Token);
                        };
                        button.Width = 80;
                        this.flowLayoutPanel1.Controls.Add(button);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"异常:{e.Message}");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
