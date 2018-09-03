namespace GoldenLady.Dress.View
{
    partial class FrmNewVenue
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
            this.tvwDepartment = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDepartmentNo = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.grpInfo.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtDepartmentNo);
            this.grpInfo.Controls.Add(this.label4);
            this.grpInfo.Location = new System.Drawing.Point(297, 2);
            this.grpInfo.Size = new System.Drawing.Size(475, 500);
            this.grpInfo.Text = "场馆信息";
            this.grpInfo.Controls.SetChildIndex(this.label2, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectName, 0);
            this.grpInfo.Controls.SetChildIndex(this.label3, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtObjectDescription, 0);
            this.grpInfo.Controls.SetChildIndex(this.chkObjectDisabled, 0);
            this.grpInfo.Controls.SetChildIndex(this.label4, 0);
            this.grpInfo.Controls.SetChildIndex(this.txtDepartmentNo, 0);
            // 
            // chkObjectDisabled
            // 
            this.chkObjectDisabled.Text = "停用该场馆";
            // 
            // txtObjectDescription
            // 
            this.txtObjectDescription.Size = new System.Drawing.Size(457, 404);
            // 
            // txtObjectName
            // 
            this.txtObjectName.Location = new System.Drawing.Point(322, 25);
            this.txtObjectName.Size = new System.Drawing.Size(144, 26);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(297, 508);
            this.btnNew.Text = "添加场馆";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label3
            // 
            this.label3.Text = "场馆描述";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(251, 27);
            this.label2.Text = "场馆名称";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tvwDepartment);
            this.pnlMain.Size = new System.Drawing.Size(784, 561);
            this.pnlMain.Controls.SetChildIndex(this.btnNew, 0);
            this.pnlMain.Controls.SetChildIndex(this.grpInfo, 0);
            this.pnlMain.Controls.SetChildIndex(this.tvwDepartment, 0);
            // 
            // pnlWait
            // 
            this.pnlWait.Size = new System.Drawing.Size(784, 561);
            // 
            // tvwDepartment
            // 
            this.tvwDepartment.Location = new System.Drawing.Point(13, 12);
            this.tvwDepartment.Name = "tvwDepartment";
            this.tvwDepartment.Size = new System.Drawing.Size(278, 537);
            this.tvwDepartment.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "关联部门编号";
            // 
            // txtDepartmentNo
            // 
            this.txtDepartmentNo.Location = new System.Drawing.Point(105, 24);
            this.txtDepartmentNo.Name = "txtDepartmentNo";
            this.txtDepartmentNo.ReadOnly = true;
            this.txtDepartmentNo.Size = new System.Drawing.Size(140, 26);
            this.txtDepartmentNo.TabIndex = 8;
            // 
            // FrmNewVenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Name = "FrmNewVenue";
            this.Text = "添加场馆";
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvwDepartment;
        private Utility.UserControls.CustomizedTextBox txtDepartmentNo;
        private System.Windows.Forms.Label label4;

    }
}