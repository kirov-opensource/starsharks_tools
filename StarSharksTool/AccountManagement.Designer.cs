namespace StarSharksTool
{
    partial class AccountManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.batchRent = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openCurrentFolder = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tokenCollectorBtn = new System.Windows.Forms.Button();
            this.tokenSenderBtn = new System.Windows.Forms.Button();
            this.AddAccount = new System.Windows.Forms.Button();
            this.label_account_count = new System.Windows.Forms.Label();
            this.label_sharks_count = new System.Windows.Forms.Label();
            this.label_bnb_quantity = new System.Windows.Forms.Label();
            this.label_sea_quantity = new System.Windows.Forms.Label();
            this.label_u_sea_quantity = new System.Windows.Forms.Label();
            this.processLbl = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 56);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1406, 740);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(1195, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 64);
            this.button1.TabIndex = 1;
            this.button1.Text = "鲨鱼管理";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 64);
            this.button2.TabIndex = 3;
            this.button2.Text = "重新加载账号";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.batchRent);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.openCurrentFolder);
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.tokenCollectorBtn);
            this.panel4.Controls.Add(this.tokenSenderBtn);
            this.panel4.Controls.Add(this.AddAccount);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(5, 802);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1409, 64);
            this.panel4.TabIndex = 4;
            // 
            // batchRent
            // 
            this.batchRent.Location = new System.Drawing.Point(1077, 0);
            this.batchRent.Name = "batchRent";
            this.batchRent.Size = new System.Drawing.Size(112, 64);
            this.batchRent.TabIndex = 12;
            this.batchRent.Text = "批量租鱼";
            this.batchRent.UseVisualStyleBackColor = true;
            this.batchRent.Click += new System.EventHandler(this.batchRent_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(957, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 64);
            this.button3.TabIndex = 11;
            this.button3.Text = "一键授权租鱼合约";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // openCurrentFolder
            // 
            this.openCurrentFolder.Location = new System.Drawing.Point(834, 0);
            this.openCurrentFolder.Name = "openCurrentFolder";
            this.openCurrentFolder.Size = new System.Drawing.Size(117, 64);
            this.openCurrentFolder.TabIndex = 10;
            this.openCurrentFolder.Text = "打开当前目录";
            this.openCurrentFolder.UseVisualStyleBackColor = true;
            this.openCurrentFolder.Click += new System.EventHandler(this.openCurrentFolder_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(246, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(265, 64);
            this.button5.TabIndex = 9;
            this.button5.Text = "批量生成账号";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tokenCollectorBtn
            // 
            this.tokenCollectorBtn.Location = new System.Drawing.Point(704, 0);
            this.tokenCollectorBtn.Name = "tokenCollectorBtn";
            this.tokenCollectorBtn.Size = new System.Drawing.Size(124, 64);
            this.tokenCollectorBtn.TabIndex = 6;
            this.tokenCollectorBtn.Text = "代币收集";
            this.tokenCollectorBtn.UseVisualStyleBackColor = true;
            this.tokenCollectorBtn.Click += new System.EventHandler(this.tokenCollectorBtn_Click);
            // 
            // tokenSenderBtn
            // 
            this.tokenSenderBtn.Location = new System.Drawing.Point(517, 0);
            this.tokenSenderBtn.Name = "tokenSenderBtn";
            this.tokenSenderBtn.Size = new System.Drawing.Size(181, 64);
            this.tokenSenderBtn.TabIndex = 5;
            this.tokenSenderBtn.Text = "代币分发";
            this.tokenSenderBtn.UseVisualStyleBackColor = true;
            this.tokenSenderBtn.Click += new System.EventHandler(this.tokenSenderBtn_Click);
            // 
            // AddAccount
            // 
            this.AddAccount.Location = new System.Drawing.Point(139, 0);
            this.AddAccount.Name = "AddAccount";
            this.AddAccount.Size = new System.Drawing.Size(101, 64);
            this.AddAccount.TabIndex = 4;
            this.AddAccount.Text = "添加账号";
            this.AddAccount.UseVisualStyleBackColor = true;
            this.AddAccount.Click += new System.EventHandler(this.AddAccount_Click);
            // 
            // label_account_count
            // 
            this.label_account_count.AutoSize = true;
            this.label_account_count.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_account_count.Location = new System.Drawing.Point(8, 5);
            this.label_account_count.Name = "label_account_count";
            this.label_account_count.Size = new System.Drawing.Size(113, 19);
            this.label_account_count.TabIndex = 5;
            this.label_account_count.Text = "账号数量：0";
            // 
            // label_sharks_count
            // 
            this.label_sharks_count.AutoSize = true;
            this.label_sharks_count.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_sharks_count.Location = new System.Drawing.Point(144, 5);
            this.label_sharks_count.Name = "label_sharks_count";
            this.label_sharks_count.Size = new System.Drawing.Size(113, 19);
            this.label_sharks_count.TabIndex = 6;
            this.label_sharks_count.Text = "鲨鱼数量：0";
            // 
            // label_bnb_quantity
            // 
            this.label_bnb_quantity.AutoSize = true;
            this.label_bnb_quantity.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_bnb_quantity.Location = new System.Drawing.Point(427, 5);
            this.label_bnb_quantity.Name = "label_bnb_quantity";
            this.label_bnb_quantity.Size = new System.Drawing.Size(64, 19);
            this.label_bnb_quantity.TabIndex = 7;
            this.label_bnb_quantity.Text = "BNB：0";
            // 
            // label_sea_quantity
            // 
            this.label_sea_quantity.AutoSize = true;
            this.label_sea_quantity.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_sea_quantity.Location = new System.Drawing.Point(636, 5);
            this.label_sea_quantity.Name = "label_sea_quantity";
            this.label_sea_quantity.Size = new System.Drawing.Size(64, 19);
            this.label_sea_quantity.TabIndex = 8;
            this.label_sea_quantity.Text = "SEA：0";
            // 
            // label_u_sea_quantity
            // 
            this.label_u_sea_quantity.AutoSize = true;
            this.label_u_sea_quantity.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_u_sea_quantity.Location = new System.Drawing.Point(935, 5);
            this.label_u_sea_quantity.Name = "label_u_sea_quantity";
            this.label_u_sea_quantity.Size = new System.Drawing.Size(82, 19);
            this.label_u_sea_quantity.TabIndex = 9;
            this.label_u_sea_quantity.Text = "u-SEA：0";
            // 
            // processLbl
            // 
            this.processLbl.AutoSize = true;
            this.processLbl.Location = new System.Drawing.Point(1257, 33);
            this.processLbl.Name = "processLbl";
            this.processLbl.Size = new System.Drawing.Size(87, 17);
            this.processLbl.TabIndex = 13;
            this.processLbl.Text = "加载进度 0 / 0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 27);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1243, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // AccountManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1419, 871);
            this.Controls.Add(this.processLbl);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_u_sea_quantity);
            this.Controls.Add(this.label_sea_quantity);
            this.Controls.Add(this.label_bnb_quantity);
            this.Controls.Add(this.label_sharks_count);
            this.Controls.Add(this.label_account_count);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Name = "AccountManagement";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.AccountManagement_Load);
            this.QueryAccessibilityHelp += new System.Windows.Forms.QueryAccessibilityHelpEventHandler(this.AccountManagement_QueryAccessibilityHelp);
            this.Resize += new System.EventHandler(this.AccountManagement_Resize);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Button button2;
        private Panel panel4;
        private Label label_account_count;
        private Label label_sharks_count;
        private Label label_bnb_quantity;
        private Label label_sea_quantity;
        private Label label_u_sea_quantity;
        private Button AddAccount;
        private Button tokenCollectorBtn;
        private Button tokenSenderBtn;
        private Button button5;
        private Button openCurrentFolder;
        private Button button3;
        private Button batchRent;
        private Label processLbl;
        private ProgressBar progressBar1;
    }
}