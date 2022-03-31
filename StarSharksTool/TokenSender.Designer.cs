namespace StarSharksTool
{
    partial class TokenSender
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tokenTypeBNB = new System.Windows.Forms.RadioButton();
            this.tokenTypeSEA = new System.Windows.Forms.RadioButton();
            this.sourceAccount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.targetAccounts = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mainAccountBalance = new System.Windows.Forms.Label();
            this.estimate = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tokenTypeSEA);
            this.groupBox1.Controls.Add(this.tokenTypeBNB);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "币种";
            // 
            // tokenTypeBNB
            // 
            this.tokenTypeBNB.AutoSize = true;
            this.tokenTypeBNB.Location = new System.Drawing.Point(6, 22);
            this.tokenTypeBNB.Name = "tokenTypeBNB";
            this.tokenTypeBNB.Size = new System.Drawing.Size(52, 21);
            this.tokenTypeBNB.TabIndex = 0;
            this.tokenTypeBNB.TabStop = true;
            this.tokenTypeBNB.Text = "BNB";
            this.tokenTypeBNB.UseVisualStyleBackColor = true;
            this.tokenTypeBNB.CheckedChanged += new System.EventHandler(this.tokenTypeBNB_CheckedChanged);
            // 
            // tokenTypeSEA
            // 
            this.tokenTypeSEA.AutoSize = true;
            this.tokenTypeSEA.Location = new System.Drawing.Point(64, 22);
            this.tokenTypeSEA.Name = "tokenTypeSEA";
            this.tokenTypeSEA.Size = new System.Drawing.Size(48, 21);
            this.tokenTypeSEA.TabIndex = 1;
            this.tokenTypeSEA.TabStop = true;
            this.tokenTypeSEA.Text = "SEA";
            this.tokenTypeSEA.UseVisualStyleBackColor = true;
            // 
            // sourceAccount
            // 
            this.sourceAccount.FormattingEnabled = true;
            this.sourceAccount.Location = new System.Drawing.Point(312, 12);
            this.sourceAccount.Name = "sourceAccount";
            this.sourceAccount.Size = new System.Drawing.Size(121, 25);
            this.sourceAccount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "来源账户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(486, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "目标账户";
            // 
            // targetAccounts
            // 
            this.targetAccounts.FormattingEnabled = true;
            this.targetAccounts.Location = new System.Drawing.Point(574, 12);
            this.targetAccounts.Name = "targetAccounts";
            this.targetAccounts.Size = new System.Drawing.Size(239, 436);
            this.targetAccounts.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(493, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "全选";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "账户余额";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "预计扣除";
            // 
            // mainAccountBalance
            // 
            this.mainAccountBalance.AutoSize = true;
            this.mainAccountBalance.Location = new System.Drawing.Point(312, 52);
            this.mainAccountBalance.Name = "mainAccountBalance";
            this.mainAccountBalance.Size = new System.Drawing.Size(15, 17);
            this.mainAccountBalance.TabIndex = 9;
            this.mainAccountBalance.Text = "0";
            // 
            // estimate
            // 
            this.estimate.AutoSize = true;
            this.estimate.Location = new System.Drawing.Point(312, 84);
            this.estimate.Name = "estimate";
            this.estimate.Size = new System.Drawing.Size(15, 17);
            this.estimate.TabIndex = 10;
            this.estimate.Text = "0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 458);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(722, 42);
            this.progressBar1.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(758, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 42);
            this.button2.TabIndex = 12;
            this.button2.Text = "执行";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // TokenSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 512);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.estimate);
            this.Controls.Add(this.mainAccountBalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.targetAccounts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sourceAccount);
            this.Controls.Add(this.groupBox1);
            this.Name = "TokenSender";
            this.Text = "TokenSender";
            this.Load += new System.EventHandler(this.TokenSender_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton tokenTypeSEA;
        private RadioButton tokenTypeBNB;
        private ComboBox sourceAccount;
        private Label label1;
        private Label label3;
        private CheckedListBox targetAccounts;
        private Button button1;
        private Label label4;
        private Label label5;
        private Label mainAccountBalance;
        private Label estimate;
        private ProgressBar progressBar1;
        private Button button2;
    }
}