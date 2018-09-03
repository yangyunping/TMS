namespace GoldenLady.Dress.View
{
    partial class FrmScene
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
            System.Windows.Forms.Label label2;
            this.txtThemeName = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.btnManagePhoto = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.grpObjectList.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Margin = new System.Windows.Forms.Padding(5);
            this.pnlMain.Size = new System.Drawing.Size(785, 576);
            // 
            // grpObjectList
            // 
            this.grpObjectList.Location = new System.Drawing.Point(5, 5);
            this.grpObjectList.Margin = new System.Windows.Forms.Padding(5);
            this.grpObjectList.Padding = new System.Windows.Forms.Padding(5);
            this.grpObjectList.Size = new System.Drawing.Size(281, 455);
            this.grpObjectList.Text = "场景列表";
            // 
            // lstObject
            // 
            this.lstObject.Location = new System.Drawing.Point(8, 24);
            this.lstObject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstObject.Size = new System.Drawing.Size(265, 424);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.btnManagePhoto);
            this.grpInfo.Controls.Add(this.txtThemeName);
            this.grpInfo.Controls.Add(label2);
            this.grpInfo.Location = new System.Drawing.Point(296, 5);
            this.grpInfo.Margin = new System.Windows.Forms.Padding(5);
            this.grpInfo.Padding = new System.Windows.Forms.Padding(5);
            this.grpInfo.Size = new System.Drawing.Size(480, 510);
            this.grpInfo.Text = "场景信息";
            this.grpInfo.Controls.SetChildIndex(this.lblObjectName, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectName, 0);
            this.grpInfo.Controls.SetChildIndex(this.lblObjectDescription, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectDescription, 0);
            this.grpInfo.Controls.SetChildIndex(this.chkObjectDisabled, 0);
            this.grpInfo.Controls.SetChildIndex(label2, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtThemeName, 0);
            this.grpInfo.Controls.SetChildIndex(this.btnManagePhoto, 0);
            // 
            // chkObjectDisabled
            // 
            this.chkObjectDisabled.Location = new System.Drawing.Point(216, 65);
            this.chkObjectDisabled.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkObjectDisabled.Text = "停用该场景";
            // 
            // txtObjectDescription
            // 
            this.txtObjectDescription.Location = new System.Drawing.Point(9, 96);
            this.txtObjectDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObjectDescription.Size = new System.Drawing.Size(463, 405);
            // 
            // lblObjectDescription
            // 
            this.lblObjectDescription.Location = new System.Drawing.Point(7, 112);
            this.lblObjectDescription.Text = "场景描述";
            // 
            // txtObjectName
            // 
            this.txtObjectName.Location = new System.Drawing.Point(320, 24);
            this.txtObjectName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObjectName.Size = new System.Drawing.Size(143, 26);
            // 
            // lblObjectName
            // 
            this.lblObjectName.Location = new System.Drawing.Point(249, 27);
            this.lblObjectName.Text = "场景名称";
            // 
            // btnDeleteObject
            // 
            this.btnDeleteObject.Location = new System.Drawing.Point(5, 525);
            this.btnDeleteObject.Margin = new System.Windows.Forms.Padding(5);
            this.btnDeleteObject.Size = new System.Drawing.Size(281, 45);
            this.btnDeleteObject.Text = "删除选中场景";
            this.btnDeleteObject.Click += new System.EventHandler(this.btnDeleteObject_Click);
            // 
            // btnNewObject
            // 
            this.btnNewObject.Location = new System.Drawing.Point(5, 470);
            this.btnNewObject.Margin = new System.Windows.Forms.Padding(5);
            this.btnNewObject.Size = new System.Drawing.Size(281, 45);
            this.btnNewObject.Text = "添加新场景";
            this.btnNewObject.Click += new System.EventHandler(this.btnNewObject_Click);
            // 
            // btnSaveObject
            // 
            this.btnSaveObject.Location = new System.Drawing.Point(296, 525);
            this.btnSaveObject.Margin = new System.Windows.Forms.Padding(5);
            this.btnSaveObject.Size = new System.Drawing.Size(480, 45);
            this.btnSaveObject.Click += new System.EventHandler(this.btnSaveObject_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 20);
            label2.TabIndex = 7;
            label2.Text = "所属风格";
            // 
            // txtThemeName
            // 
            this.txtThemeName.Location = new System.Drawing.Point(77, 24);
            this.txtThemeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtThemeName.Name = "txtThemeName";
            this.txtThemeName.ReadOnly = true;
            this.txtThemeName.Size = new System.Drawing.Size(167, 26);
            this.txtThemeName.TabIndex = 8;
            // 
            // btnManagePhoto
            // 
            this.btnManagePhoto.Location = new System.Drawing.Point(363, 62);
            this.btnManagePhoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnManagePhoto.Name = "btnManagePhoto";
            this.btnManagePhoto.Size = new System.Drawing.Size(101, 31);
            this.btnManagePhoto.TabIndex = 9;
            this.btnManagePhoto.Text = "管理照片";
            this.btnManagePhoto.UseVisualStyleBackColor = true;
            this.btnManagePhoto.Click += new System.EventHandler(this.btnManagePhoto_Click);
            // 
            // FrmScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmScene";
            this.Size = new System.Drawing.Size(785, 576);
            this.pnlMain.ResumeLayout(false);
            this.grpObjectList.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utility.UserControls.CustomizedTextBox txtThemeName;
        private System.Windows.Forms.Button btnManagePhoto;

    }
}