namespace GoldenLady.Dress.View.DressRent
{
    partial class FrmAddCost
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
            this.cmbOrderNo = new System.Windows.Forms.TextBox();
            this.txtTelPhoto = new System.Windows.Forms.TextBox();
            this.lblWomen = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMan = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtAddCost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbOrderNo
            // 
            this.cmbOrderNo.Location = new System.Drawing.Point(106, 111);
            this.cmbOrderNo.Name = "cmbOrderNo";
            this.cmbOrderNo.Size = new System.Drawing.Size(154, 26);
            this.cmbOrderNo.TabIndex = 3;
            // 
            // txtTelPhoto
            // 
            this.txtTelPhoto.Location = new System.Drawing.Point(106, 29);
            this.txtTelPhoto.Name = "txtTelPhoto";
            this.txtTelPhoto.Size = new System.Drawing.Size(154, 26);
            this.txtTelPhoto.TabIndex = 1;
            // 
            // lblWomen
            // 
            this.lblWomen.AutoSize = true;
            this.lblWomen.Location = new System.Drawing.Point(225, 72);
            this.lblWomen.Name = "lblWomen";
            this.lblWomen.Size = new System.Drawing.Size(0, 20);
            this.lblWomen.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(160, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "小  姐：";
            // 
            // lblMan
            // 
            this.lblMan.AutoSize = true;
            this.lblMan.Location = new System.Drawing.Point(102, 72);
            this.lblMan.Name = "lblMan";
            this.lblMan.Size = new System.Drawing.Size(0, 20);
            this.lblMan.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "先  生：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "电话号码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "订 单 号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "【元】";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Snow;
            this.btnClose.Location = new System.Drawing.Point(62, 246);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "取 消";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(185, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 29);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "保  存";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtAddCost
            // 
            this.txtAddCost.BackColor = System.Drawing.Color.White;
            this.txtAddCost.Enabled = false;
            this.txtAddCost.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddCost.ForeColor = System.Drawing.Color.Black;
            this.txtAddCost.Location = new System.Drawing.Point(106, 189);
            this.txtAddCost.Multiline = true;
            this.txtAddCost.Name = "txtAddCost";
            this.txtAddCost.Size = new System.Drawing.Size(154, 31);
            this.txtAddCost.TabIndex = 5;
            this.txtAddCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "新增消费收款：";
            // 
            // FrmAddCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 288);
            this.Controls.Add(this.cmbOrderNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTelPhoto);
            this.Controls.Add(this.lblWomen);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMan);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAddCost);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmAddCost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增消费";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTelPhoto;
        private System.Windows.Forms.Label lblWomen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAddCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cmbOrderNo;
    }
}