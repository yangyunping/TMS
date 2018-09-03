namespace GoldenLady.Dress.View
{
    partial class FrmNewTheme
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
            if(disposing && (components != null))
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtVenueName = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.grpInfo.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtVenueName);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Text = "风格信息";
            this.grpInfo.Controls.SetChildIndex(this.label2, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectName, 0);
            this.grpInfo.Controls.SetChildIndex(this.label3, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectDescription, 0);
            this.grpInfo.Controls.SetChildIndex(this.chkObjectDisabled, 0);
            this.grpInfo.Controls.SetChildIndex(this.label4, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtVenueName, 0);
            // 
            // chkObjectDisabled
            // 
            this.chkObjectDisabled.Text = "停用该风格";
            // 
            // btnNew
            // 
            this.btnNew.Text = "添加风格";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label3
            // 
            this.label3.Text = "风格描述";
            // 
            // label2
            // 
            this.label2.Text = "风格名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "所属场馆";
            // 
            // txtVenueName
            // 
            this.txtVenueName.Location = new System.Drawing.Point(76, 24);
            this.txtVenueName.Name = "txtVenueName";
            this.txtVenueName.ReadOnly = true;
            this.txtVenueName.Size = new System.Drawing.Size(150, 26);
            this.txtVenueName.TabIndex = 8;
            // 
            // FrmNewTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 399);
            this.Name = "FrmNewTheme";
            this.Text = "添加风格";
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private Utility.UserControls.CustomizedTextBox txtVenueName;
    }
}