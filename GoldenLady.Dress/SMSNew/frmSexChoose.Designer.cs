namespace GoldenLady.SMSNew
{
    partial class frmSexChoose
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
            this.rdbGirl = new System.Windows.Forms.RadioButton();
            this.rdbBoy = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdbGirl);
            this.groupBox1.Controls.Add(this.rdbBoy);
            this.groupBox1.Controls.Add(this.rdbAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rdbGirl
            // 
            this.rdbGirl.AutoSize = true;
            this.rdbGirl.Location = new System.Drawing.Point(124, 20);
            this.rdbGirl.Name = "rdbGirl";
            this.rdbGirl.Size = new System.Drawing.Size(59, 16);
            this.rdbGirl.TabIndex = 2;
            this.rdbGirl.TabStop = true;
            this.rdbGirl.Text = "女顾客";
            this.rdbGirl.UseVisualStyleBackColor = true;
            this.rdbGirl.CheckedChanged += new System.EventHandler(this.rdbGirl_CheckedChanged);
            // 
            // rdbBoy
            // 
            this.rdbBoy.AutoSize = true;
            this.rdbBoy.Location = new System.Drawing.Point(59, 20);
            this.rdbBoy.Name = "rdbBoy";
            this.rdbBoy.Size = new System.Drawing.Size(59, 16);
            this.rdbBoy.TabIndex = 1;
            this.rdbBoy.TabStop = true;
            this.rdbBoy.Text = "男顾客";
            this.rdbBoy.UseVisualStyleBackColor = true;
            this.rdbBoy.CheckedChanged += new System.EventHandler(this.rdbBoy_CheckedChanged);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(6, 20);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(47, 16);
            this.rdbAll.TabIndex = 0;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "全部";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(71, 64);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmSexChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 98);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSexChoose";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择要发送的对象";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbGirl;
        private System.Windows.Forms.RadioButton rdbBoy;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.Button btnOk;
    }
}