namespace GoldenLady.Dress.View.DressRent
{
    partial class FrmDressAdd
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtMan = new System.Windows.Forms.TextBox();
            this.txtWoman = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDressBarCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.chkCompany = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDresserss = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(29, 43);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(61, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "先      生";
            // 
            // txtMan
            // 
            this.txtMan.Location = new System.Drawing.Point(101, 40);
            this.txtMan.Name = "txtMan";
            this.txtMan.Size = new System.Drawing.Size(121, 26);
            this.txtMan.TabIndex = 1;
            // 
            // txtWoman
            // 
            this.txtWoman.Location = new System.Drawing.Point(298, 40);
            this.txtWoman.Name = "txtWoman";
            this.txtWoman.Size = new System.Drawing.Size(112, 26);
            this.txtWoman.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "小   姐";
            // 
            // txtDressBarCode
            // 
            this.txtDressBarCode.Location = new System.Drawing.Point(101, 102);
            this.txtDressBarCode.Name = "txtDressBarCode";
            this.txtDressBarCode.Size = new System.Drawing.Size(121, 26);
            this.txtDressBarCode.TabIndex = 5;
            this.txtDressBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDressBarCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "礼服条码";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(101, 206);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(309, 62);
            this.txtRemark.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "单件备注";
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.Location = new System.Drawing.Point(427, 40);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(239, 307);
            this.picImage.TabIndex = 14;
            this.picImage.TabStop = false;
            // 
            // chkCompany
            // 
            this.chkCompany.AutoSize = true;
            this.chkCompany.Location = new System.Drawing.Point(101, 274);
            this.chkCompany.Name = "chkCompany";
            this.chkCompany.Size = new System.Drawing.Size(70, 24);
            this.chkCompany.TabIndex = 15;
            this.chkCompany.Text = "伴娘服";
            this.chkCompany.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOK.Location = new System.Drawing.Point(259, 304);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 38);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "添  加";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancle.Location = new System.Drawing.Point(101, 304);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(100, 38);
            this.btnCancle.TabIndex = 17;
            this.btnCancle.Text = "取  消";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(233, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "（按确定键查看礼服图片）";
            // 
            // cmbDresserss
            // 
            this.cmbDresserss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDresserss.FormattingEnabled = true;
            this.cmbDresserss.Location = new System.Drawing.Point(101, 153);
            this.cmbDresserss.Name = "cmbDresserss";
            this.cmbDresserss.Size = new System.Drawing.Size(121, 28);
            this.cmbDresserss.TabIndex = 68;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 156);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 20);
            this.label15.TabIndex = 67;
            this.label15.Text = "礼  服  师";
            // 
            // FrmDressAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 377);
            this.Controls.Add(this.cmbDresserss);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkCompany);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDressBarCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWoman);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMan);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDressAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增礼服";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtMan;
        private System.Windows.Forms.TextBox txtWoman;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDressBarCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.CheckBox chkCompany;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDresserss;
        private System.Windows.Forms.Label label15;
    }
}