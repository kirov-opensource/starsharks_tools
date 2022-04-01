using Newtonsoft.Json;
using StarSharksTool.Extensions;
using StarSharksTool.Models;
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
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var str = this.textBox1.Text;
            var lines = str.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }
            var appSettings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(Global.SETTING_PATH));
            foreach (var item in lines)
            {
                var keyAndAlias = item.Split(new char[] { '\t',' ', ',', '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (keyAndAlias.Length == 1)
                {
                    keyAndAlias = new string[] { keyAndAlias[0], DateTime.Now.Ticks.ToString() };
                }
                if (appSettings.Accounts == null)
                {
                    appSettings.Accounts = new List<AccountInfo> { };
                }
                var privateKey = keyAndAlias[0];
                if (privateKey.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase))
                {
                    privateKey = privateKey[2..];
                }
                appSettings.Accounts.Add(new AccountInfo { Alias = keyAndAlias[1].Trim(), PrivateKey = AESHelper.Encrypt(keyAndAlias[0].Trim()) });
            }
            File.WriteAllText(Global.SETTING_PATH, JsonConvert.SerializeObject(appSettings, Formatting.Indented));
            MessageBox.Show("添加成功");
        }
    }
}
