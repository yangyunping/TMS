using GoldenLady.Utility.UserControls;

namespace GoldenLady.Dress.View.Template
{
    partial class FrmManage
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnSaveObject = new System.Windows.Forms.Button();
            this.btnDeleteObject = new System.Windows.Forms.Button();
            this.btnNewObject = new System.Windows.Forms.Button();
            this.lstObject = new System.Windows.Forms.ListBox();
            this.grpObjectList = new GoldenLady.Utility.UserControls.CustomizeGroupBox();
            this.grpInfo = new GoldenLady.Utility.UserControls.CustomizeGroupBox();
            this.chkObjectDisabled = new System.Windows.Forms.CheckBox();
            this.lblObjectName = new System.Windows.Forms.Label();
            this.txtObjectName = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.lblObjectDescription = new System.Windows.Forms.Label();
            this.txtObjectDescription = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.pnlMain.SuspendLayout();
            this.grpObjectList.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpObjectList);
            this.pnlMain.Controls.Add(this.grpInfo);
            this.pnlMain.Controls.Add(this.btnDeleteObject);
            this.pnlMain.Controls.Add(this.btnNewObject);
            this.pnlMain.Controls.Add(this.btnSaveObject);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(767, 554);
            this.pnlMain.TabIndex = 0;
            // 
            // btnSaveObject
            // 
            this.btnSaveObject.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveObject.Location = new System.Drawing.Point(290, 509);
            this.btnSaveObject.Name = "btnSaveObject";
            this.btnSaveObject.Size = new System.Drawing.Size(473, 41);
            this.btnSaveObject.TabIndex = 18;
            this.btnSaveObject.Text = "保存修改";
            this.btnSaveObject.UseVisualStyleBackColor = true;
            // 
            // btnDeleteObject
            // 
            this.btnDeleteObject.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteObject.Location = new System.Drawing.Point(3, 509);
            this.btnDeleteObject.Name = "btnDeleteObject";
            this.btnDeleteObject.Size = new System.Drawing.Size(281, 41);
            this.btnDeleteObject.TabIndex = 20;
            this.btnDeleteObject.Text = "删除选中对象";
            this.btnDeleteObject.UseVisualStyleBackColor = true;
            // 
            // btnNewObject
            // 
            this.btnNewObject.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewObject.Location = new System.Drawing.Point(3, 449);
            this.btnNewObject.Name = "btnNewObject";
            this.btnNewObject.Size = new System.Drawing.Size(281, 54);
            this.btnNewObject.TabIndex = 19;
            this.btnNewObject.Text = "添加新对象";
            this.btnNewObject.UseVisualStyleBackColor = true;
            // 
            // lstObject
            // 
            this.lstObject.FormattingEnabled = true;
            this.lstObject.ItemHeight = 20;
            this.lstObject.Location = new System.Drawing.Point(10, 25);
            this.lstObject.Name = "lstObject";
            this.lstObject.Size = new System.Drawing.Size(261, 404);
            this.lstObject.TabIndex = 1;
            // 
            // grpObjectList
            // 
            this.grpObjectList.BorderColor = System.Drawing.Color.Black;
            this.grpObjectList.Controls.Add(this.lstObject);
            this.grpObjectList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpObjectList.Location = new System.Drawing.Point(3, 3);
            this.grpObjectList.Name = "grpObjectList";
            this.grpObjectList.Size = new System.Drawing.Size(281, 440);
            this.grpObjectList.TabIndex = 16;
            this.grpObjectList.TabStop = false;
            this.grpObjectList.Text = "对象列表";
            this.grpObjectList.TitleFontColor = System.Drawing.Color.Black;
            // 
            // grpInfo
            // 
            this.grpInfo.BorderColor = System.Drawing.Color.Black;
            this.grpInfo.Controls.Add(this.chkObjectDisabled);
            this.grpInfo.Controls.Add(this.txtObjectDescription);
            this.grpInfo.Controls.Add(this.lblObjectDescription);
            this.grpInfo.Controls.Add(this.txtObjectName);
            this.grpInfo.Controls.Add(this.lblObjectName);
            this.grpInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpInfo.Location = new System.Drawing.Point(290, 3);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(473, 500);
            this.grpInfo.TabIndex = 17;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "对象信息";
            this.grpInfo.TitleFontColor = System.Drawing.Color.Black;
            // 
            // chkObjectDisabled
            // 
            this.chkObjectDisabled.AutoSize = true;
            this.chkObjectDisabled.Location = new System.Drawing.Point(366, 66);
            this.chkObjectDisabled.Name = "chkObjectDisabled";
            this.chkObjectDisabled.Size = new System.Drawing.Size(98, 24);
            this.chkObjectDisabled.TabIndex = 6;
            this.chkObjectDisabled.Text = "停用该对象";
            this.chkObjectDisabled.UseVisualStyleBackColor = true;
            // 
            // lblObjectName
            // 
            this.lblObjectName.AutoSize = true;
            this.lblObjectName.Location = new System.Drawing.Point(6, 27);
            this.lblObjectName.Name = "lblObjectName";
            this.lblObjectName.Size = new System.Drawing.Size(65, 20);
            this.lblObjectName.TabIndex = 2;
            this.lblObjectName.Text = "对象名称";
            // 
            // txtObjectName
            // 
            this.txtObjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObjectName.Location = new System.Drawing.Point(77, 25);
            this.txtObjectName.Name = "txtObjectName";
            this.txtObjectName.Size = new System.Drawing.Size(387, 26);
            this.txtObjectName.TabIndex = 3;
            // 
            // lblObjectDescription
            // 
            this.lblObjectDescription.AutoSize = true;
            this.lblObjectDescription.Location = new System.Drawing.Point(5, 67);
            this.lblObjectDescription.Name = "lblObjectDescription";
            this.lblObjectDescription.Size = new System.Drawing.Size(65, 20);
            this.lblObjectDescription.TabIndex = 4;
            this.lblObjectDescription.Text = "对象描述";
            // 
            // txtObjectDescription
            // 
            this.txtObjectDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObjectDescription.Location = new System.Drawing.Point(9, 99);
            this.txtObjectDescription.Multiline = true;
            this.txtObjectDescription.Name = "txtObjectDescription";
            this.txtObjectDescription.Size = new System.Drawing.Size(455, 390);
            this.txtObjectDescription.TabIndex = 5;
            // 
            // FrmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmManage";
            this.Size = new System.Drawing.Size(767, 554);
            this.pnlMain.ResumeLayout(false);
            this.grpObjectList.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlMain;
        protected CustomizeGroupBox grpObjectList;
        protected System.Windows.Forms.ListBox lstObject;
        protected CustomizeGroupBox grpInfo;
        protected System.Windows.Forms.CheckBox chkObjectDisabled;
        protected CustomizedTextBox txtObjectDescription;
        protected System.Windows.Forms.Label lblObjectDescription;
        protected CustomizedTextBox txtObjectName;
        protected System.Windows.Forms.Label lblObjectName;
        protected System.Windows.Forms.Button btnDeleteObject;
        protected System.Windows.Forms.Button btnNewObject;
        protected System.Windows.Forms.Button btnSaveObject;



    }
}