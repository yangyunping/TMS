using GoldenLady.Utility.UserControls;

namespace GoldenLady.Dress.View.Template
{
    public partial class FrmNew
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpInfo = new GoldenLady.Utility.UserControls.CustomizeGroupBox();
            this.chkObjectDisabled = new System.Windows.Forms.CheckBox();
            this.txtObjectDescription = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.txtObjectName = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpInfo);
            this.pnlMain.Controls.Add(this.btnNew);
            this.pnlMain.Size = new System.Drawing.Size(500, 399);
            // 
            // pnlWait
            // 
            this.pnlWait.Size = new System.Drawing.Size(500, 399);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "对象描述";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "对象名称";
            // 
            // grpInfo
            // 
            this.grpInfo.BorderColor = System.Drawing.Color.Black;
            this.grpInfo.Controls.Add(this.chkObjectDisabled);
            this.grpInfo.Controls.Add(this.txtObjectDescription);
            this.grpInfo.Controls.Add(this.label3);
            this.grpInfo.Controls.Add(this.txtObjectName);
            this.grpInfo.Controls.Add(this.label2);
            this.grpInfo.Location = new System.Drawing.Point(13, 3);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(475, 337);
            this.grpInfo.TabIndex = 5;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "对象信息";
            this.grpInfo.TitleFontColor = System.Drawing.Color.Black;
            // 
            // chkObjectDisabled
            // 
            this.chkObjectDisabled.AutoSize = true;
            this.chkObjectDisabled.Location = new System.Drawing.Point(368, 56);
            this.chkObjectDisabled.Name = "chkObjectDisabled";
            this.chkObjectDisabled.Size = new System.Drawing.Size(98, 24);
            this.chkObjectDisabled.TabIndex = 6;
            this.chkObjectDisabled.Text = "停用该对象";
            this.chkObjectDisabled.UseVisualStyleBackColor = true;
            // 
            // txtObjectDescription
            // 
            this.txtObjectDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObjectDescription.Location = new System.Drawing.Point(9, 86);
            this.txtObjectDescription.Multiline = true;
            this.txtObjectDescription.Name = "txtObjectDescription";
            this.txtObjectDescription.Size = new System.Drawing.Size(457, 242);
            this.txtObjectDescription.TabIndex = 5;
            // 
            // txtObjectName
            // 
            this.txtObjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObjectName.Location = new System.Drawing.Point(322, 24);
            this.txtObjectName.Name = "txtObjectName";
            this.txtObjectName.Size = new System.Drawing.Size(144, 26);
            this.txtObjectName.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Location = new System.Drawing.Point(13, 346);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(475, 41);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "添加对象";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // FrmNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 399);
            this.Name = "FrmNew";
            this.Text = "FrmNew";
            this.pnlMain.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected Utility.UserControls.CustomizeGroupBox grpInfo;
        protected System.Windows.Forms.CheckBox chkObjectDisabled;
        protected CustomizedTextBox txtObjectDescription;
        protected CustomizedTextBox txtObjectName;
        protected System.Windows.Forms.Button btnNew;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;


    }
}