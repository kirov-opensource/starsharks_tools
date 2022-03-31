using Nethereum.Web3.Accounts;
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
    public partial class AccountControl : Form
    {
        public AccountControl()
        {
            //Account account
            InitializeComponent();
        }

        private async void AccountControl_Load(object sender, EventArgs e)
        {
            await this.Login();
        }

        public async Task Login()
        {

        }
    }
}
