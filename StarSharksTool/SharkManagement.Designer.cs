namespace StarSharksTool
{
    partial class SharkManagement
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentCountLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalCountLbl = new System.Windows.Forms.Label();
            this.refreshEnergyBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.Location = new System.Drawing.Point(1174, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "加载鲨鱼";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ShowSharkGroup);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1262, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1348, 707);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 2);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(950, 37);
            this.progressBar1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(956, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "进度：";
            // 
            // CurrentCountLbl
            // 
            this.CurrentCountLbl.AutoSize = true;
            this.CurrentCountLbl.Location = new System.Drawing.Point(1001, 12);
            this.CurrentCountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentCountLbl.Name = "CurrentCountLbl";
            this.CurrentCountLbl.Size = new System.Drawing.Size(15, 17);
            this.CurrentCountLbl.TabIndex = 5;
            this.CurrentCountLbl.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1029, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "/";
            // 
            // TotalCountLbl
            // 
            this.TotalCountLbl.AutoSize = true;
            this.TotalCountLbl.Location = new System.Drawing.Point(1044, 12);
            this.TotalCountLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalCountLbl.Name = "TotalCountLbl";
            this.TotalCountLbl.Size = new System.Drawing.Size(15, 17);
            this.TotalCountLbl.TabIndex = 7;
            this.TotalCountLbl.Text = "0";
            // 
            // refreshEnergyBtn
            // 
            this.refreshEnergyBtn.AllowDrop = true;
            this.refreshEnergyBtn.Location = new System.Drawing.Point(1086, 3);
            this.refreshEnergyBtn.Name = "refreshEnergyBtn";
            this.refreshEnergyBtn.Size = new System.Drawing.Size(82, 37);
            this.refreshEnergyBtn.TabIndex = 8;
            this.refreshEnergyBtn.Text = "刷新体力";
            this.refreshEnergyBtn.UseVisualStyleBackColor = true;
            this.refreshEnergyBtn.Click += new System.EventHandler(this.refreshEnergyBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.TotalCountLbl);
            this.panel1.Controls.Add(this.refreshEnergyBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.CurrentCountLbl);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 718);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1348, 45);
            this.panel1.TabIndex = 9;
            // 
            // SharkManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 766);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "SharkManagement";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "星鲨工具箱-鲨鱼管理";
            this.Load += new System.EventHandler(this.SharkManagement_Load);
            this.Resize += new System.EventHandler(this.SharkManagement_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
        private ProgressBar progressBar1;
        private Label label1;
        private Label CurrentCountLbl;
        private Label label3;
        private Label TotalCountLbl;
        private Button refreshEnergyBtn;
        private Panel panel1;
    }
}