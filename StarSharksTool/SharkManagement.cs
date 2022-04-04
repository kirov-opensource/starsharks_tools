using Microsoft.Extensions.Logging;
using StarSharksTool.Enums;
using StarSharksTool.Models;
using StarSharksTool.Services;

namespace StarSharksTool
{
    public partial class SharkManagement : Form
    {
        public List<GroupBox> AccountGroups { get; set; } = new List<GroupBox>();
        public Dictionary<ListBox, List<int>> ListBoxDataDictionary = new Dictionary<ListBox, List<int>>();
        public Dictionary<int, SharkModel> SharkDictionary = new Dictionary<int, SharkModel>();
        internal Service service = new Service();

        public SharkManagement()
        {
            InitializeComponent();
        }

        private void SharkManagement_Load(object sender, EventArgs e)
        {
            service.TransferEvent += ProcessIncrease;
        }

        private void ProcessIncrease(object? sender, TransferEventArgs e)
        {
            var total = Convert.ToInt32(TotalCountLbl.Text);
            var current = Convert.ToInt32(CurrentCountLbl.Text);
            current += 1;
            CurrentCountLbl.BeginInvoke(() => CurrentCountLbl.Text = current.ToString());
            progressBar1.BeginInvoke(() => progressBar1.Value = (int)(((double)current / (double)total) * 100));
        }

        private void groupBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        public Size PANEL_SIZE = new Size(320, 210);
        public Size LISTBOX_SIZE = new Size(320 - DEFAULT_PADDING - DEFAULT_PADDING, 210 - DEFAULT_PADDING - DEFAULT_PADDING);
        public const int DEFAULT_PADDING = 25;
        private GroupBox GenerateGroupBox(AccountModel account, List<int> ids)
        {
            GroupBox currentGroupBox = new GroupBox();
            currentGroupBox.Size = PANEL_SIZE;
            currentGroupBox.Text = $"({account!.Alias}){account!.Account!.Address[0..6]} **** {account!.Account!.Address[^4..]}";
            currentGroupBox.Name = account!.Account!.Address + "GroupBox";
            // 高度到时候用整除去算
            currentGroupBox.Location = new Point(AccountGroups.Count * (PANEL_SIZE.Width + DEFAULT_PADDING) + DEFAULT_PADDING, DEFAULT_PADDING);
            AccountGroups.Add(currentGroupBox);
            currentGroupBox.Controls.Add(GenerateListBox(account!.Account!.Address, ids));
            return currentGroupBox;
        }
        private ListBox GenerateListBox(string name, List<int> ids)
        {
            ListBox gListBox = new ListBox();
            gListBox.Name = name + "ListBox";
            gListBox.AllowDrop = true;
            gListBox.MouseDown += ListBoxMouseDown!;
            gListBox.DragEnter += ListBoxDragEnter!;
            gListBox.DragDrop += ListBoxDragDrop!;
            gListBox.MeasureItem += ListBoxMeasureItem;
            gListBox.DrawItem += ListBoxDrawItem;
            gListBox.DrawMode = DrawMode.OwnerDrawVariable;
            gListBox.DataSource = ids;
            gListBox.Size = LISTBOX_SIZE;
            gListBox.Location = new Point(DEFAULT_PADDING, DEFAULT_PADDING);
            //gListBox.Size = new Size(200, 200);
            //gListBox.Location = new Point(15, 15);
            ListBoxDataDictionary.Add(gListBox, ids);

            return gListBox;
        }

        private int ItemMargin = 5;
        private void ListBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            ListBox listBox = sender as ListBox;
            var sharkId = (int)listBox.Items[e.Index];
            var shark = SharkDictionary[sharkId];
            string txt = shark.SharkInfo;

            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) ==
                DrawItemState.Selected)
            {
                e.Graphics.DrawString(txt, this.Font,
                    SystemBrushes.HighlightText, e.Bounds.Left,
                        e.Bounds.Top + ItemMargin);
            }
            else
            {
                using (SolidBrush br = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(txt, this.Font, br,
                        e.Bounds.Left, e.Bounds.Top + ItemMargin);
                }
            }

            e.DrawFocusRectangle();
        }

        private void ListBoxMeasureItem(object sender, MeasureItemEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            var sharkId = (int)listBox.Items[e.Index];
            var shark = SharkDictionary[sharkId];
            string txt = shark.SharkInfo;

            SizeF txt_size = e.Graphics.MeasureString(txt, this.Font);

            e.ItemHeight = (int)txt_size.Height + 2 * ItemMargin;
            e.ItemWidth = (int)txt_size.Width;
        }

        private void ListBoxDragDrop(object sender, DragEventArgs e)
        {

            var dataId = Convert.ToInt32(e.Data.GetData(DataFormats.Text));
            if (ListBoxDataDictionary[(sender as ListBox)].Contains(dataId))
            {
                return;
            }
            if (SharkDictionary[dataId].SharkStatus == Enums.SharkStatus.RentIn)
            {
                MessageBox.Show($"租入的鲨鱼无法转移", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var item in ListBoxDataDictionary)
            {
                if (item.Value.Contains(dataId))
                {
                    ListBoxDataDictionary[item.Key].Remove(dataId);
                    item.Key.DataSource = item.Value.ToList();
                }
            }
            ListBoxDataDictionary[(sender as ListBox)].Add(dataId);
            (sender as ListBox).DataSource = ListBoxDataDictionary[(sender as ListBox)].ToList();
        }

        private async void ShowSharkGroup(object sender, EventArgs e)
        {
            Dictionary<int, SharkModel> sharkDetailsDictionary = null;
            var index = 0;
            var sharkIds = Global.Accounts.SelectMany(c => c.Sharks).Select(c => c.Key);
        RELOAD_SHARK:
            try
            {
                sharkDetailsDictionary = Global.Accounts.SelectMany(c => c.Sharks).ToDictionary(c => c.Key, c => c.Value);//await Service.GetSharkDetails(sharkIds);
            }
            catch(Exception ex)
            {
                Global.GetLogger("SharkManagement").LogError(ex, ex.Message);
                goto RELOAD_SHARK;
            }
            SharkDictionary = sharkDetailsDictionary;
            foreach (var account in Global.Accounts)
            {
                foreach (var shark in account.Sharks)
                {
                    if (SharkDictionary.ContainsKey(shark.Key))
                    {
                        SharkDictionary[shark.Key].AccountAddress = account.Account.Address;
                    }
                }
            }
            //foreach (var item in Global.Accounts.SelectMany(c => c.Sharks))
            //{
            //    SharkDictionary.Add(item.Key, item.Value);
            //}
            foreach (var account in Global.Accounts)
            {
                this.flowLayoutPanel1.Controls.Add(GenerateGroupBox(account, account.Sharks.Keys.ToList()));
                index++;
            }
        }

        private void ListBoxMouseDown(object sender, MouseEventArgs e)
        {
            var box = sender as ListBox;
            if (box.Items.Count == 0)
            {
                return;
            }
            box.DoDragDrop(box.Items[box.SelectedIndex].ToString(), DragDropEffects.Move);
        }

        private void ListBoxDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private async Task SaveTransferRecord()
        {
            try
            {
                var sharkTransferRecord = SharkDictionary.Keys.Select(c =>
                {
                    string oldAddress = Global.Accounts.FirstOrDefault(d => d.Sharks.ContainsKey(c)).Account.Address;
                    string newAddress = ListBoxDataDictionary.FirstOrDefault(d => d.Value.Contains(c)).Key.Name[..^7];
                    int tokenId = c;
                    SharkType tokenType = SharkType.Shark;
                    return new TransferRecord { From = oldAddress, To = newAddress, TokenId = tokenId, SharkType = tokenType };
                }).Where(c => c.From != c.To).ToList();
                if (sharkTransferRecord.Any())
                {
                    TotalCountLbl.BeginInvoke(() => TotalCountLbl.Text = sharkTransferRecord.Count.ToString());
                    CurrentCountLbl.BeginInvoke(() => CurrentCountLbl.Text = "0");
                    progressBar1.BeginInvoke(() => progressBar1.Value = 0);
                    await service.TransferSharks(sharkTransferRecord).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Global.GetLogger("SharkManagement").LogError(ex, ex.Message);
                throw ex;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await SaveTransferRecord().ConfigureAwait(false);
        }

        private async void refreshEnergyBtn_Click(object sender, EventArgs e)
        {
            var sharkDetailsDictionary = await Service.GetSharkDetails(SharkDictionary.Keys);
            SharkDictionary = sharkDetailsDictionary;
        }

        private void SharkManagement_Resize(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Height = this.Height - 98;
        }
    }
}
