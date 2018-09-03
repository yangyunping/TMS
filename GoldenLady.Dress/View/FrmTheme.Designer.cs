namespace GoldenLady.Dress.View
{
    partial class FrmTheme
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
            this.txtVenueName = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.btnManageScene = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.grpObjectList.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(772, 561);
            // 
            // grpObjectList
            // 
            this.grpObjectList.Margin = new System.Windows.Forms.Padding(2);
            this.grpObjectList.Padding = new System.Windows.Forms.Padding(2);
            this.grpObjectList.Size = new System.Drawing.Size(281, 455);
            this.grpObjectList.Text = "风格列表";
            // 
            // lstObject
            // 
            this.lstObject.Location = new System.Drawing.Point(4, 25);
            this.lstObject.Margin = new System.Windows.Forms.Padding(2);
            this.lstObject.Size = new System.Drawing.Size(273, 424);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.btnManageScene);
            this.grpInfo.Controls.Add(this.txtVenueName);
            this.grpInfo.Controls.Add(label2);
            this.grpInfo.Text = "风格信息";
            this.grpInfo.Controls.SetChildIndex(this.lblObjectName, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectName, 0);
            this.grpInfo.Controls.SetChildIndex(this.lblObjectDescription, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectDescription, 0);
            this.grpInfo.Controls.SetChildIndex(this.chkObjectDisabled, 0);
            this.grpInfo.Controls.SetChildIndex(label2, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtVenueName, 0);
            this.grpInfo.Controls.SetChildIndex(this.btnManageScene, 0);
            // 
            // chkObjectDisabled
            // 
            this.chkObjectDisabled.Location = new System.Drawing.Point(240, 66);
            this.chkObjectDisabled.Margin = new System.Windows.Forms.Padding(2);
            this.chkObjectDisabled.Text = "停用该风格";
            // 
            // txtObjectDescription
            // 
            this.txtObjectDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtObjectDescription.Size = new System.Drawing.Size(459, 396);
            // 
            // lblObjectDescription
            // 
            this.lblObjectDescription.Location = new System.Drawing.Point(17, 68);
            this.lblObjectDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObjectDescription.Text = "风格描述";
            // 
            // txtObjectName
            // 
            this.txtObjectName.Location = new System.Drawing.Point(320, 23);
            this.txtObjectName.Margin = new System.Windows.Forms.Padding(2);
            this.txtObjectName.Size = new System.Drawing.Size(148, 26);
            // 
            // lblObjectName
            // 
            this.lblObjectName.Location = new System.Drawing.Point(236, 26);
            this.lblObjectName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObjectName.Text = "风格名称";
            // 
            // btnDeleteObject
            // 
            this.btnDeleteObject.Location = new System.Drawing.Point(0, 509);
            this.btnDeleteObject.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteObject.Size = new System.Drawing.Size(284, 41);
            this.btnDeleteObject.Text = "删除选中风格";
            this.btnDeleteObject.Click += new System.EventHandler(this.btnDeleteObject_Click);
            // 
            // btnNewObject
            // 
            this.btnNewObject.Location = new System.Drawing.Point(3, 462);
            this.btnNewObject.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewObject.Size = new System.Drawing.Size(281, 41);
            this.btnNewObject.Text = "添加新风格";
            this.btnNewObject.Click += new System.EventHandler(this.btnNewObject_Click);
            // 
            // btnSaveObject
            // 
            this.btnSaveObject.Click += new System.EventHandler(this.btnSaveObject_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(17, 26);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 20);
            label2.TabIndex = 7;
            label2.Text = "所属场馆";
            // 
            // txtVenueName
            // 
            this.txtVenueName.Location = new System.Drawing.Point(99, 23);
            this.txtVenueName.Margin = new System.Windows.Forms.Padding(2);
            this.txtVenueName.Name = "txtVenueName";
            this.txtVenueName.ReadOnly = true;
            this.txtVenueName.Size = new System.Drawing.Size(126, 26);
            this.txtVenueName.TabIndex = 8;
            // 
            // btnManageScene
            // 
            this.btnManageScene.Location = new System.Drawing.Point(369, 61);
            this.btnManageScene.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageScene.Name = "btnManageScene";
            this.btnManageScene.Size = new System.Drawing.Size(99, 34);
            this.btnManageScene.TabIndex = 9;
            this.btnManageScene.Text = "管理场景";
            this.btnManageScene.UseVisualStyleBackColor = true;
            this.btnManageScene.Click += new System.EventHandler(this.btnManageScene_Click);
            // 
            // FrmTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FrmTheme";
            this.Size = new System.Drawing.Size(772, 561);
            this.pnlMain.ResumeLayout(false);
            this.grpObjectList.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utility.UserControls.CustomizedTextBox txtVenueName;
        private System.Windows.Forms.Button btnManageScene;
    }
}