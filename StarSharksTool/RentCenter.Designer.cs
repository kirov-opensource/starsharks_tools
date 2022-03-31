namespace StarSharksTool
{
    partial class RentCenter
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
            this.rentProxy = new System.Windows.Forms.TextBox();
            this.proxyLbl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.enableMarketSharkSource = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dynamicGasLbl = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.gasPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maxRentCount = new System.Windows.Forms.TextBox();
            this.priceTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.levelGroupBox = new System.Windows.Forms.GroupBox();
            this.level2 = new System.Windows.Forms.RadioButton();
            this.level3 = new System.Windows.Forms.RadioButton();
            this.level1 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.levelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // rentProxy
            // 
            this.rentProxy.Location = new System.Drawing.Point(101, 45);
            this.rentProxy.Margin = new System.Windows.Forms.Padding(2);
            this.rentProxy.Name = "rentProxy";
            this.rentProxy.Size = new System.Drawing.Size(271, 23);
            this.rentProxy.TabIndex = 20;
            // 
            // proxyLbl
            // 
            this.proxyLbl.AutoSize = true;
            this.proxyLbl.Location = new System.Drawing.Point(12, 48);
            this.proxyLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.proxyLbl.Name = "proxyLbl";
            this.proxyLbl.Size = new System.Drawing.Size(88, 17);
            this.proxyLbl.TabIndex = 19;
            this.proxyLbl.Text = "市场刷新Proxy";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 72);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(363, 288);
            this.dataGridView1.TabIndex = 17;
            // 
            // enableMarketSharkSource
            // 
            this.enableMarketSharkSource.AutoSize = true;
            this.enableMarketSharkSource.Checked = true;
            this.enableMarketSharkSource.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableMarketSharkSource.Location = new System.Drawing.Point(12, 12);
            this.enableMarketSharkSource.Name = "enableMarketSharkSource";
            this.enableMarketSharkSource.Size = new System.Drawing.Size(99, 21);
            this.enableMarketSharkSource.TabIndex = 21;
            this.enableMarketSharkSource.Text = "启用市场租鱼";
            this.enableMarketSharkSource.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "刷新间隔";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(176, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 23);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "ms";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(798, 72);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 32;
            this.dataGridView2.Size = new System.Drawing.Size(363, 288);
            this.dataGridView2.TabIndex = 25;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(890, 42);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(271, 23);
            this.textBox2.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(799, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "BSC Endpoint";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(799, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 21);
            this.checkBox1.TabIndex = 28;
            this.checkBox1.Text = "启用区块租鱼";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dynamicGasLbl
            // 
            this.dynamicGasLbl.AutoSize = true;
            this.dynamicGasLbl.Location = new System.Drawing.Point(85, 51);
            this.dynamicGasLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dynamicGasLbl.Name = "dynamicGasLbl";
            this.dynamicGasLbl.Size = new System.Drawing.Size(25, 17);
            this.dynamicGasLbl.TabIndex = 38;
            this.dynamicGasLbl.Text = "0.0";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 49);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 21);
            this.radioButton2.TabIndex = 40;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "动态GAS";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.gasPrice);
            this.groupBox2.Controls.Add(this.dynamicGasLbl);
            this.groupBox2.Location = new System.Drawing.Point(12, 564);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(137, 79);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GAS";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 21);
            this.radioButton1.TabIndex = 39;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "静态GAS";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // gasPrice
            // 
            this.gasPrice.Location = new System.Drawing.Point(85, 21);
            this.gasPrice.Margin = new System.Windows.Forms.Padding(2);
            this.gasPrice.Name = "gasPrice";
            this.gasPrice.Size = new System.Drawing.Size(35, 23);
            this.gasPrice.TabIndex = 36;
            this.gasPrice.Text = "9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 612);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = "期望条数";
            // 
            // maxRentCount
            // 
            this.maxRentCount.Location = new System.Drawing.Point(354, 609);
            this.maxRentCount.Margin = new System.Windows.Forms.Padding(2);
            this.maxRentCount.Name = "maxRentCount";
            this.maxRentCount.Size = new System.Drawing.Size(51, 23);
            this.maxRentCount.TabIndex = 44;
            this.maxRentCount.Text = "2";
            // 
            // priceTextbox
            // 
            this.priceTextbox.Location = new System.Drawing.Point(354, 582);
            this.priceTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.priceTextbox.Name = "priceTextbox";
            this.priceTextbox.Size = new System.Drawing.Size(51, 23);
            this.priceTextbox.TabIndex = 43;
            this.priceTextbox.Text = "14";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 585);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "价格<=";
            // 
            // levelGroupBox
            // 
            this.levelGroupBox.Controls.Add(this.level2);
            this.levelGroupBox.Controls.Add(this.level3);
            this.levelGroupBox.Controls.Add(this.level1);
            this.levelGroupBox.Location = new System.Drawing.Point(155, 564);
            this.levelGroupBox.Name = "levelGroupBox";
            this.levelGroupBox.Size = new System.Drawing.Size(112, 102);
            this.levelGroupBox.TabIndex = 46;
            this.levelGroupBox.TabStop = false;
            this.levelGroupBox.Text = "等级";
            // 
            // level2
            // 
            this.level2.AutoSize = true;
            this.level2.Location = new System.Drawing.Point(10, 45);
            this.level2.Name = "level2";
            this.level2.Size = new System.Drawing.Size(59, 21);
            this.level2.TabIndex = 3;
            this.level2.Text = "Star:2";
            this.level2.UseVisualStyleBackColor = true;
            // 
            // level3
            // 
            this.level3.AutoSize = true;
            this.level3.Location = new System.Drawing.Point(10, 72);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(428, 586);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 43);
            this.button2.TabIndex = 48;
            this.button2.Text = "开始租赁";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 365);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1152, 193);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // RentCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 765);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.levelGroupBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maxRentCount);
            this.Controls.Add(this.priceTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enableMarketSharkSource);
            this.Controls.Add(this.rentProxy);
            this.Controls.Add(this.proxyLbl);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RentCenter";
            this.Text = "RentCenter";
            this.Load += new System.EventHandler(this.RentCenter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.levelGroupBox.ResumeLayout(false);
            this.levelGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox rentProxy;
        private Label proxyLbl;
        private DataGridView dataGridView1;
        private CheckBox enableMarketSharkSource;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private DataGridView dataGridView2;
        private TextBox textBox2;
        private Label label3;
        private CheckBox checkBox1;
        private Label dynamicGasLbl;
        private RadioButton radioButton2;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private TextBox gasPrice;
        private Label label7;
        private TextBox maxRentCount;
        private TextBox priceTextbox;
        private Label label4;
        private GroupBox levelGroupBox;
        private RadioButton level2;
        private RadioButton level3;
        private RadioButton level1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button approveContract;
    }
}