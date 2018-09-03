namespace GoldenLady.Dress.View
{
    partial class FrmNewScene
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
            this.txtThemeName = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.grpInfo.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtThemeName);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Text = "场景信息";
            this.grpInfo.Controls.SetChildIndex(this.label2, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectName, 0);
            this.grpInfo.Controls.SetChildIndex(this.label3, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectDescription, 0);
            this.grpInfo.Controls.SetChildIndex(this.chkObjectDisabled, 0);
            this.grpInfo.Controls.SetChildIndex(this.label4, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtThemeName, 0);
            // 
            // chkObjectDisabled
            // 
            this.chkObjectDisabled.Text = "停用该场景";
            // 
            // txtObjectDescription
            // 
            this.txtObjectDescription.Size = new System.Drawing.Size(457, 236);
            // 
            // btnNew
            // 
            this.btnNew.Text = "添加场景";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label3
            // 
            this.label3.Text = "场景描述";
            // 
            // label2
            // 
            this.label2.Text = "场景名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "所属风格";
            // 
            // txtThemeName
            // 
            this.txtThemeName.Location = new System.Drawing.Point(76, 23);
            this.txtThemeName.Name = "txtThemeName";
            this.txtThemeName.ReadOnly = true;
            this.txtThemeName.Size = new System.Drawing.Size(150, 26);
            this.txtThemeName.TabIndex = 8;
            // 
            // FrmNewScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 399);
            this.Name = "FrmNewScene";
            this.Text = "添加场景";
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Utility.UserControls.CustomizedTextBox txtThemeName;
        private System.Windows.Forms.Label label4;

    }
}