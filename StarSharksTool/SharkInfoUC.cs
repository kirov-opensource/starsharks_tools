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
    public partial class SharkInfoUC : UserControl
    {
        private Nethereum.Web3.Accounts.Account account;

        public SharkInfoUC()
        {
            InitializeComponent();

        }

        public SharkInfoUC(Nethereum.Web3.Accounts.Account account) : base()
        {
            this.account = account;
        }

        private async void SharkInfoUC_Load(object sender, EventArgs e)
        {
            await this.Login();
        }
        private async Task Login()
        {

        }
    }
}
