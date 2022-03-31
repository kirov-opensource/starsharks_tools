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
    public partial class RentCenter : Form
    {
        public Dictionary<string, bool> IsApproveContract = new Dictionary<string, bool>();
        public RentCenter()
        {
            InitializeComponent();
        }

        private void RentCenter_Load(object sender, EventArgs e)
        {
            Global.Accounts.ForEach(c =>
            {
                CheckBox cbx = new CheckBox();
                cbx.Text = c.Alias;
                bool defaultChecked = (c.Alias.Equals("main", StringComparison.CurrentCultureIgnoreCase) ? false : true);
                cbx.Checked = defaultChecked;
                cbx.Click += (object? sender, EventArgs e) =>
                {
                    if ((sender as CheckBox).Checked == true)
                    {

                    }
                };
                this.flowLayoutPanel1.Controls.Add(cbx);
            });
        }

        private void approveContract_Click(object sender, EventArgs e)
        {

        }
    }
}
