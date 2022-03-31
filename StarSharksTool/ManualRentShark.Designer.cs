namespace StarSharksTool
{
    partial class ManualRentShark
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
            this.components = new System.ComponentModel.Container();
            this.gasPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.priceTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.approveContract = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rentHistory = new System.Windows.Forms.DataGridView();
            this.rentedCountLabel = new System.Windows.Forms.Label();
            this.offset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.range = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.autoRent = new System.Windows.Forms.CheckBox();
            this.autoRentOffsetMs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.levelGroupBox = new System.Windows.Forms.GroupBox();
            this.level2 = new System.Windows.Forms.RadioButton();
            this.level3 = new System.Windows.Forms.RadioButton();
            this.level1 = new System.Windows.Forms.RadioButton();
            this.dynamicGas = new System.Windows.Forms.CheckBox();
            this.dynamicGasLbl = new System.Windows.Forms.Label();
            this.seaCountLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maxRentCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentHistory)).BeginInit();
            this.levelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gasPrice
            // 
            this.gasPrice.Location = new System.Drawing.Point(614, 9);
            this.gasPrice.Margin = new System.Windows.Forms.Padding(2);
            this.gasPrice.Name = "gasPrice";
            this.gasPrice.Size = new System.Drawing.Size(35, 23);
            this.gasPrice.TabIndex = 17;
            this.gasPrice.Text = "9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(525, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "GASPrice(Wei)";
            // 
            // priceTextbox
            // 
            this.priceTextbox.Location = new System.Drawing.Point(700, 9);
            this.priceTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.priceTextbox.Name = "priceTextbox";
            this.priceTextbox.Size = new System.Drawing.Size(51, 23);
            this.priceTextbox.TabIndex = 15;
            this.priceTextbox.Text = "14";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(651, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "价格<=";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(157, 9);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 21);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "自动刷新(5s)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // approveContract
            // 
            this.approveContract.Location = new System.Drawing.Point(11, 7);
            this.approveContract.Margin = new System.Windows.Forms.Padding(2);
            this.approveContract.Name = "approveContract";
            this.approveContract.Size = new System.Drawing.Size(71, 24);
            this.approveContract.TabIndex = 20;
            this.approveContract.Text = "授权合约";
            this.approveContract.UseVisualStyleBackColor = true;
            this.approveContract.Click += new System.EventHandler(this.approveContract_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(86, 7);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(67, 24);
            this.refreshBtn.TabIndex = 19;
            this.refreshBtn.Text = "刷新";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 35);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(510, 443);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // rentHistory
            // 
            this.rentHistory.AllowUserToAddRows = false;
            this.rentHistory.AllowUserToDeleteRows = false;
            this.rentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentHistory.Location = new System.Drawing.Point(643, 72);
            this.rentHistory.Margin = new System.Windows.Forms.Padding(2);
            this.rentHistory.Name = "rentHistory";
            this.rentHistory.ReadOnly = true;
            this.rentHistory.RowHeadersWidth = 62;
            this.rentHistory.RowTemplate.Height = 32;
            this.rentHistory.Size = new System.Drawing.Size(630, 406);
            this.rentHistory.TabIndex = 22;
            this.rentHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rentHistory_CellContentClick);
            // 
            // rentedCountLabel
            // 
            this.rentedCountLabel.AutoSize = true;
            this.rentedCountLabel.Location = new System.Drawing.Point(1222, 11);
            this.rentedCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rentedCountLabel.Name = "rentedCountLabel";
            this.rentedCountLabel.Size = new System.Drawing.Size(51, 17);
            this.rentedCountLabel.TabIndex = 23;
            this.rentedCountLabel.Text = "已租0条";
            // 
            // offset
            // 
            this.offset.Location = new System.Drawing.Point(802, 6);
            this.offset.Margin = new System.Windows.Forms.Padding(2);
            this.offset.Name = "offset";
            this.offset.Size = new System.Drawing.Size(51, 23);
            this.offset.TabIndex = 24;
            this.offset.Text = "400";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(857, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Range";
            // 
            // range
            // 
            this.range.Location = new System.Drawing.Point(904, 6);
            this.range.Margin = new System.Windows.Forms.Padding(2);
            this.range.Name = "range";
            this.range.Size = new System.Drawing.Size(51, 23);
            this.range.TabIndex = 26;
            this.range.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(643, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(379, 34);
            this.label5.TabIndex = 28;
            this.label5.Text = "Offset：与区块的偏差值，如果刷新后鱼距离现在有较长时间可以调小\r\nRange：范围，3秒1个区块，默认获取将来150S的租鱼记录\r\n";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // autoRent
            // 
            this.autoRent.AutoSize = true;
            this.autoRent.Location = new System.Drawing.Point(959, 9);
            this.autoRent.Margin = new System.Windows.Forms.Padding(2);
            this.autoRent.Name = "autoRent";
            this.autoRent.Size = new System.Drawing.Size(75, 21);
            this.autoRent.TabIndex = 29;
            this.autoRent.Text = "自动租赁";
            this.autoRent.UseVisualStyleBackColor = true;
            this.autoRent.CheckedChanged += new System.EventHandler(this.autoRent_CheckedChanged);
            // 
            // autoRentOffsetMs
            // 
            this.autoRentOffsetMs.Location = new System.Drawing.Point(1159, 33);
            this.autoRentOffsetMs.Margin = new System.Windows.Forms.Padding(2);
            this.autoRentOffsetMs.Name = "autoRentOffsetMs";
            this.autoRentOffsetMs.Size = new System.Drawing.Size(35, 23);
            this.autoRentOffsetMs.TabIndex = 31;
            this.autoRentOffsetMs.Text = "3500";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1038, 36);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "租赁延迟毫秒数(ms)";
            // 
            // levelGroupBox
            // 
            this.levelGroupBox.Controls.Add(this.level2);
            this.levelGroupBox.Controls.Add(this.level3);
            this.levelGroupBox.Controls.Add(this.level1);
            this.levelGroupBox.Location = new System.Drawing.Point(526, 37);
            this.levelGroupBox.Name = "levelGroupBox";
            this.levelGroupBox.Size = new System.Drawing.Size(112, 150);
            this.levelGroupBox.TabIndex = 32;
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
            // dynamicGas
            // 
            this.dynamicGas.AutoSize = true;
            this.dynamicGas.Location = new System.Drawing.Point(380, 10);
            this.dynamicGas.Margin = new System.Windows.Forms.Padding(2);
            this.dynamicGas.Name = "dynamicGas";
            this.dynamicGas.Size = new System.Drawing.Size(75, 21);
            this.dynamicGas.TabIndex = 33;
            this.dynamicGas.Text = "动态GAS";
            this.dynamicGas.UseVisualStyleBackColor = true;
            this.dynamicGas.CheckedChanged += new System.EventHandler(this.dynamicGas_CheckedChanged);
            // 
            // dynamicGasLbl
            // 
            this.dynamicGasLbl.AutoSize = true;
            this.dynamicGasLbl.Location = new System.Drawing.Point(459, 11);
            this.dynamicGasLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dynamicGasLbl.Name = "dynamicGasLbl";
            this.dynamicGasLbl.Size = new System.Drawing.Size(25, 17);
            this.dynamicGasLbl.TabIndex = 34;
            this.dynamicGasLbl.Text = "0.0";
            // 
            // seaCountLbl
            // 
            this.seaCountLbl.AutoSize = true;
            this.seaCountLbl.Location = new System.Drawing.Point(284, 10);
            this.seaCountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.seaCountLbl.Name = "seaCountLbl";
            this.seaCountLbl.Size = new System.Drawing.Size(33, 17);
            this.seaCountLbl.TabIndex = 35;
            this.seaCountLbl.Text = "SEA:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1038, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "期望条数(不要留多SEA)";
            // 
            // maxRentCount
            // 
            this.maxRentCount.Location = new System.Drawing.Point(1176, 6);
            this.maxRentCount.Margin = new System.Windows.Forms.Padding(2);
            this.maxRentCount.Name = "maxRentCount";
            this.maxRentCount.Size = new System.Drawing.Size(42, 23);
            this.maxRentCount.TabIndex = 36;
            this.maxRentCount.Text = "2";
            // 
            // ManualRentShark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 493);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maxRentCount);
            this.Controls.Add(this.seaCountLbl);
            this.Controls.Add(this.dynamicGasLbl);
            this.Controls.Add(this.dynamicGas);
            this.Controls.Add(this.levelGroupBox);
            this.Controls.Add(this.autoRentOffsetMs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.autoRent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.range);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.offset);
            this.Controls.Add(this.rentedCountLabel);
            this.Controls.Add(this.rentHistory);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.approveContract);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gasPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.priceTextbox);
            this.Controls.Add(this.label1);
            this.Name = "ManualRentShark";
            this.Text = "ManualRentShark";
            this.Load += new System.EventHandler(this.ManualRentShark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentHistory)).EndInit();
            this.levelGroupBox.ResumeLayout(false);
            this.levelGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox gasPrice;
        private Label label3;
        private TextBox priceTextbox;
        private Label label1;
        private CheckBox checkBox1;
        private Button approveContract;
        private Button refreshBtn;
        private DataGridView dataGridView1;
        private DataGridView rentHistory;
        private Label rentedCountLabel;
        private TextBox offset;
        private Label label2;
        private Label label4;
        private TextBox range;
        private Label label5;
        private System.Windows.Forms.Timer timer1;
        private CheckBox autoRent;
        private TextBox autoRentOffsetMs;
        private Label label6;
        private GroupBox levelGroupBox;
        private RadioButton level2;
        private RadioButton level3;
        private RadioButton level1;
        private CheckBox dynamicGas;
        private Label dynamicGasLbl;
        private Label seaCountLbl;
        private Label label7;
        private TextBox maxRentCount;
    }
}