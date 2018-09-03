using GoldenLady.Utility.UserControls;

namespace GoldenLady.Dress.View
{
    partial class FrmScenePhoto
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
            this.label5 = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.cmbServerPath = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSceneName = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.pnlPhoto = new System.Windows.Forms.Panel();
            this.photoManager = new GoldenLady.Utility.UserControls.PhotoManager();
            this.pnlMain.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlPhoto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlPhoto);
            this.pnlMain.Controls.Add(this.pnlInfo);
            this.pnlMain.Location = new System.Drawing.Point(5, 5);
            this.pnlMain.Size = new System.Drawing.Size(974, 559);
            // 
            // pnlWait
            // 
            this.pnlWait.Location = new System.Drawing.Point(5, 5);
            this.pnlWait.Size = new System.Drawing.Size(974, 559);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "场景名称";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.cmbServerPath);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.txtSceneName);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(974, 73);
            this.pnlInfo.TabIndex = 10;
            // 
            // cmbServerPath
            // 
            this.cmbServerPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServerPath.FormattingEnabled = true;
            this.cmbServerPath.Location = new System.Drawing.Point(65, 39);
            this.cmbServerPath.Name = "cmbServerPath";
            this.cmbServerPath.Size = new System.Drawing.Size(909, 28);
            this.cmbServerPath.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "上传路径";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSceneName
            // 
            this.txtSceneName.Location = new System.Drawing.Point(65, 0);
            this.txtSceneName.Multiline = true;
            this.txtSceneName.Name = "txtSceneName";
            this.txtSceneName.ReadOnly = true;
            this.txtSceneName.Size = new System.Drawing.Size(909, 25);
            this.txtSceneName.TabIndex = 8;
            // 
            // pnlPhoto
            // 
            this.pnlPhoto.Controls.Add(this.photoManager);
            this.pnlPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPhoto.Location = new System.Drawing.Point(0, 73);
            this.pnlPhoto.Name = "pnlPhoto";
            this.pnlPhoto.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlPhoto.Size = new System.Drawing.Size(974, 486);
            this.pnlPhoto.TabIndex = 11;
            // 
            // photoManager
            // 
            this.photoManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoManager.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.photoManager.LargePhotoMappingRule = null;
            this.photoManager.Location = new System.Drawing.Point(0, 10);
            this.photoManager.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.photoManager.MinimumSize = new System.Drawing.Size(440, 200);
            this.photoManager.Name = "photoManager";
            this.photoManager.SelectedPhotoIndices = new int[0];
            this.photoManager.Size = new System.Drawing.Size(974, 476);
            this.photoManager.TabIndex = 0;
            this.photoManager.ThumbSize = new System.Drawing.Size(16, 16);
            this.photoManager.AddPhotoButtonClick += new System.EventHandler(this.photoManager_AddPhotoButtonClick);
            this.photoManager.DeletePhotoButtonClick += new System.EventHandler(this.photoManager_DeletePhotoButtonClick);
            this.photoManager.CopyPhotoButtonClick += new System.EventHandler(this.photoManager_CopyPhotoButtonClick);
            // 
            // FrmScenePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 569);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "FrmScenePhoto";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "场景照片管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMain.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlPhoto.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlPhoto;
        private System.Windows.Forms.Panel pnlInfo;
        private CustomizedTextBox txtSceneName;
        private System.Windows.Forms.ComboBox cmbServerPath;
        private System.Windows.Forms.Label label2;
        private PhotoManager photoManager;
    }
}