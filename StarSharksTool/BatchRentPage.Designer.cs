namespace StarSharksTool
{
    partial class BatchRentPage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.autoRent = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.priceTextbox = new System.Windows.Forms.TextBox();
            this.rentHistory = new System.Windows.Forms.DataGridView();
            this.rentedCountLabel = new System.Windows.Forms.Label();
            this.seaCountLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gasPrice = new System.Windows.Forms.TextBox();
            this.levelGroupBox = new System.Windows.Forms.GroupBox();
            this.level2 = new System.Windows.Forms.RadioButton();
            this.level3 = new System.Windows.Forms.RadioButton();
            this.level1 = new System.Windows.Forms.RadioButton();
            this.rentProxy = new System.Windows.Forms.TextBox();
            this.proxyLbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dynamicGasLbl = new System.Windows.Forms.Label();
            this.dynamicGas = new System.Windows.Forms.CheckBox();
            this.maxDynamicGasPrice = new System.Windows.Forms.CheckBox();
            this.maxDynamicGasPriceTbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentHistory)).BeginInit();
            this.levelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 59);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(363, 406);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(131, 3);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(71, 24);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "刷新";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 6);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(121, 21);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "自动刷新(200ms)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // autoRent
            // 
            this.autoRent.AutoSize = true;
            this.autoRent.Location = new System.Drawing.Point(563, 11);
            this.autoRent.Margin = new System.Windows.Forms.Padding(2);
            this.autoRent.Name = "autoRent";
            this.autoRent.Size = new System.Drawing.Size(75, 21);
            this.autoRent.TabIndex = 4;
            this.autoRent.Text = "自动租赁";
            this.autoRent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "价格<=";
            // 
            // priceTextbox
            // 
            this.priceTextbox.Location = new System.Drawing.Point(509, 8);
            this.priceTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.priceTextbox.Name = "priceTextbox";
            this.priceTextbox.Size = new System.Drawing.Size(51, 23);
            this.priceTextbox.TabIndex = 6;
            this.priceTextbox.Text = "13";
            // 
            // rentHistory
            // 
            this.rentHistory.AllowUserToAddRows = false;
            this.rentHistory.AllowUserToDeleteRows = false;
            this.rentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentHistory.Location = new System.Drawing.Point(493, 74);
            this.rentHistory.Margin = new System.Windows.Forms.Padding(2);
            this.rentHistory.Name = "rentHistory";
            this.rentHistory.ReadOnly = true;
            this.rentHistory.RowHeadersWidth = 62;
            this.rentHistory.RowTemplate.Height = 32;
            this.rentHistory.Size = new System.Drawing.Size(388, 392);
            this.rentHistory.TabIndex = 7;
            // 
            // rentedCountLabel
            // 
            this.rentedCountLabel.AutoSize = true;
            this.rentedCountLabel.Location = new System.Drawing.Point(833, 11);
            this.rentedCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rentedCountLabel.Name = "rentedCountLabel";
            this.rentedCountLabel.Size = new System.Drawing.Size(51, 17);
            this.rentedCountLabel.TabIndex = 10;
            this.rentedCountLabel.Text = "已租0条";
            // 
            // seaCountLbl
            // 
            this.seaCountLbl.AutoSize = true;
            this.seaCountLbl.Location = new System.Drawing.Point(206, 9);
            this.seaCountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.seaCountLbl.Name = "seaCountLbl";
            this.seaCountLbl.Size = new System.Drawing.Size(33, 17);
            this.seaCountLbl.TabIndex = 11;
            this.seaCountLbl.Text = "SEA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "GAS";
            // 
            // gasPrice
            // 
            this.gasPrice.Location = new System.Drawing.Point(423, 8);
            this.gasPrice.Margin = new System.Windows.Forms.Padding(2);
            this.gasPrice.Name = "gasPrice";
            this.gasPrice.Size = new System.Drawing.Size(35, 23);
            this.gasPrice.TabIndex = 13;
            this.gasPrice.Text = "6";
            // 
            // levelGroupBox
            // 
            this.levelGroupBox.Controls.Add(this.level2);
            this.levelGroupBox.Controls.Add(this.level3);
            this.levelGroupBox.Controls.Add(this.level1);
            this.levelGroupBox.Location = new System.Drawing.Point(376, 59);
            this.levelGroupBox.Name = "levelGroupBox";
            this.levelGroupBox.Size = new System.Drawing.Size(112, 150);
            this.levelGroupBox.TabIndex = 14;
            this.levelGroupBox.TabStop = false;
            this.levelGroupBox.Text = "等级";
            // 
            // level2
            // 
            this.level2.AutoSize = true;
            this.level2.Location = new System.Drawing.Point(10, 73);
            this.level2.Name = "level2";
            this.level2.Size = new System.Drawing.Size(59, 21);
            this.level2.TabIndex = 3;
            this.level2.Text = "Star:2";
            this.level2.UseVisualStyleBackColor = true;
            // 
            // level3
            // 
            this.level3.AutoSize = true;
            this.level3.Location = new System.Drawing.Point(10, 123);
            this.level3.Name = "level3";
            this.level3.Size = new System.Drawing.Size(59, 21);
            this.level3.TabIndex = 2;
            this.level3.Text = "Star:3";
            this.level3.UseVisualStyleBackColor = true;
            // 
            // level1
            // 
            this.level1.AutoSize = true;
            this.level1.Checked = true;
            this.level1.Location = new System.Drawing.Point(10, 22);
            this.level1.Name = "level1";
            this.level1.Size = new System.Drawing.Size(59, 21);
            this.level1.TabIndex = 0;
            this.level1.TabStop = true;
            this.level1.Text = "Star:1";
            this.level1.UseVisualStyleBackColor = true;
            // 
            // rentProxy
            // 
            this.rentProxy.Location = new System.Drawing.Point(100, 32);
            this.rentProxy.Margin = new System.Windows.Forms.Padding(2);
            this.rentProxy.Name = "rentProxy";
            this.rentProxy.Size = new System.Drawing.Size(178, 23);
            this.rentProxy.TabIndex = 16;
            // 
            // proxyLbl
            // 
            this.proxyLbl.AutoSize = true;
            this.proxyLbl.Location = new System.Drawing.Point(11, 35);
            this.proxyLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.proxyLbl.Name = "proxyLbl";
            this.proxyLbl.Size = new System.Drawing.Size(88, 17);
            this.proxyLbl.TabIndex = 15;
            this.proxyLbl.Text = "市场刷新Proxy";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 470);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(868, 353);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // dynamicGasLbl
            // 
            this.dynamicGasLbl.AutoSize = true;
            this.dynamicGasLbl.Location = new System.Drawing.Point(362, 8);
            this.dynamicGasLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dynamicGasLbl.Name = "dynamicGasLbl";
            this.dynamicGasLbl.Size = new System.Drawing.Size(25, 17);
            this.dynamicGasLbl.TabIndex = 36;
            this.dynamicGasLbl.Text = "0.0";
            // 
            // dynamicGas
            // 
            this.dynamicGas.AutoSize = true;
            this.dynamicGas.Location = new System.Drawing.Point(283, 7);
            this.dynamicGas.Margin = new System.Windows.Forms.Padding(2);
            this.dynamicGas.Name = "dynamicGas";
            this.dynamicGas.Size = new System.Drawing.Size(75, 21);
            this.dynamicGas.TabIndex = 35;
            this.dynamicGas.Text = "动态GAS";
            this.dynamicGas.UseVisualStyleBackColor = true;
            this.dynamicGas.CheckedChanged += new System.EventHandler(this.dynamicGas_CheckedChanged);
            // 
            // maxDynamicGasPrice
            // 
            this.maxDynamicGasPrice.AutoSize = true;
            this.maxDynamicGasPrice.Checked = true;
            this.maxDynamicGasPrice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.maxDynamicGasPrice.Location = new System.Drawing.Point(283, 32);
            this.maxDynamicGasPrice.Name = "maxDynamicGasPrice";
            this.maxDynamicGasPrice.Size = new System.Drawing.Size(99, 21);
            this.maxDynamicGasPrice.TabIndex = 37;
            this.maxDynamicGasPrice.Text = "最大动态GAS";
            this.maxDynamicGasPrice.UseVisualStyleBackColor = true;
            // 
            // maxDynamicGasPriceTbx
            // 
            this.maxDynamicGasPriceTbx.Location = new System.Drawing.Point(383, 30);
            this.maxDynamicGasPriceTbx.Margin = new System.Windows.Forms.Padding(2);
            this.maxDynamicGasPriceTbx.Name = "maxDynamicGasPriceTbx";
            this.maxDynamicGasPriceTbx.Size = new System.Drawing.Size(75, 23);
            this.maxDynamicGasPriceTbx.TabIndex = 38;
            this.maxDynamicGasPriceTbx.Text = "8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(493, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 34);
            this.label4.TabIndex = 39;
            this.label4.Text = "注意！！！钱包里不要多留SEA,只要有SEA就会无限租\r\n如果没有收全国请先使用主界面的批量授权";
            // 
            // BatchRentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 835);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxDynamicGasPriceTbx);
            this.Controls.Add(this.maxDynamicGasPrice);
            this.Controls.Add(this.dynamicGasLbl);
            this.Controls.Add(this.dynamicGas);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.rentProxy);
            this.Controls.Add(this.proxyLbl);
            this.Controls.Add(this.levelGroupBox);
            this.Controls.Add(this.gasPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seaCountLbl);
            this.Controls.Add(this.rentedCountLabel);
            this.Controls.Add(this.rentHistory);
            this.Controls.Add(this.priceTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoRent);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BatchRentPage";
            this.Text = "BatchRentPage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RentPage_FormClosed);
            this.Load += new System.EventHandler(this.RentPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentHistory)).EndInit();
            this.levelGroupBox.ResumeLayout(false);
            this.levelGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Button refreshBtn;
        private CheckBox checkBox1;
        private CheckBox autoRent;
        private Label label1;
        private TextBox priceTextbox;
        private DataGridView rentHistory;
        private Label rentedCountLabel;
        private Label seaCountLbl;
        private Label label3;
        private TextBox gasPrice;
        private GroupBox levelGroupBox;
        private RadioButton level2;
        private RadioButton level3;
        private RadioButton level1;
        private TextBox rentProxy;
        private Label proxyLbl;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label dynamicGasLbl;
        private CheckBox dynamicGas;
        private CheckBox maxDynamicGasPrice;
        private TextBox maxDynamicGasPriceTbx;
        private Label label4;
    }
}