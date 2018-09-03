namespace GoldenLady.Dress.View
{
    partial class FrmVenue
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
            System.Windows.Forms.Label label2;
            this.txtDepartmentNo = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.btnManageTheme = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.grpObjectList.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(782, 559);
            // 
            // grpObjectList
            // 
            this.grpObjectList.Margin = new System.Windows.Forms.Padding(2);
            this.grpObjectList.Padding = new System.Windows.Forms.Padding(2);
            this.grpObjectList.Size = new System.Drawing.Size(281, 454);
            this.grpObjectList.Text = "场馆列表";
            // 
            // lstObject
            // 
            this.lstObject.Location = new System.Drawing.Point(4, 23);
            this.lstObject.Margin = new System.Windows.Forms.Padding(2);
            this.lstObject.Size = new System.Drawing.Size(273, 424);
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.btnManageTheme);
            this.grpInfo.Controls.Add(this.txtDepartmentNo);
            this.grpInfo.Controls.Add(label2);
            this.grpInfo.Size = new System.Drawing.Size(482, 500);
            this.grpInfo.Text = "场馆信息";
            this.grpInfo.Controls.SetChildIndex(this.lblObjectName, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectName, 0);
            this.grpInfo.Controls.SetChildIndex(this.lblObjectDescription, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectDescription, 0);
            this.grpInfo.Controls.SetChildIndex(this.chkObjectDisabled, 0);
            this.grpInfo.Controls.SetChildIndex(label2, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtDepartmentNo, 0);
            this.grpInfo.Controls.SetChildIndex(this.btnManageTheme, 0);
            // 
            // chkObjectDisabled
            // 
            this.chkObjectDisabled.Location = new System.Drawing.Point(274, 69);
            this.chkObjectDisabled.Margin = new System.Windows.Forms.Padding(2);
            this.chkObjectDisabled.Text = "停用该场馆";
            // 
            // txtObjectDescription
            // 
            this.txtObjectDescription.Location = new System.Drawing.Point(5, 99);
            this.txtObjectDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtObjectDescription.Size = new System.Drawing.Size(468, 396);
            // 
            // lblObjectDescription
            // 
            this.lblObjectDescription.Location = new System.Drawing.Point(14, 71);
            this.lblObjectDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObjectDescription.Text = "场馆描述";
            // 
            // txtObjectName
            // 
            this.txtObjectName.Location = new System.Drawing.Point(336, 25);
            this.txtObjectName.Margin = new System.Windows.Forms.Padding(2);
            this.txtObjectName.Size = new System.Drawing.Size(137, 26);
            // 
            // lblObjectName
            // 
            this.lblObjectName.Location = new System.Drawing.Point(253, 28);
            this.lblObjectName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblObjectName.Text = "场馆名称";
            // 
            // btnDeleteObject
            // 
            this.btnDeleteObject.Text = "删除选中场馆";
            this.btnDeleteObject.Click += new System.EventHandler(this.btnDeleteObject_Click);
            // 
            // btnNewObject
            // 
            this.btnNewObject.Location = new System.Drawing.Point(3, 461);
            this.btnNewObject.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewObject.Size = new System.Drawing.Size(281, 43);
            this.btnNewObject.Text = "添加新场馆";
            this.btnNewObject.Click += new System.EventHandler(this.btnNewObject_Click);
            // 
            // btnSaveObject
            // 
            this.btnSaveObject.Size = new System.Drawing.Size(482, 41);
            this.btnSaveObject.Click += new System.EventHandler(this.btnSaveObject_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(14, 28);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(93, 20);
            label2.TabIndex = 7;
            label2.Text = "关联部门编号";
            // 
            // txtDepartmentNo
            // 
            this.txtDepartmentNo.Location = new System.Drawing.Point(121, 25);
            this.txtDepartmentNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtDepartmentNo.Name = "txtDepartmentNo";
            this.txtDepartmentNo.ReadOnly = true;
            this.txtDepartmentNo.Size = new System.Drawing.Size(112, 26);
            this.txtDepartmentNo.TabIndex = 8;
            // 
            // btnManageTheme
            // 
            this.btnManageTheme.Location = new System.Drawing.Point(389, 64);
            this.btnManageTheme.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageTheme.Name = "btnManageTheme";
            this.btnManageTheme.Size = new System.Drawing.Size(84, 34);
            this.btnManageTheme.TabIndex = 9;
            this.btnManageTheme.Text = "管理风格";
            this.btnManageTheme.UseVisualStyleBackColor = true;
            this.btnManageTheme.Click += new System.EventHandler(this.btnManageTheme_Click);
            // 
            // FrmVenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FrmVenue";
            this.Size = new System.Drawing.Size(782, 559);
            this.pnlMain.ResumeLayout(false);
            this.grpObjectList.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utility.UserControls.CustomizedTextBox txtDepartmentNo;
        private System.Windows.Forms.Button btnManageTheme;
    }
}