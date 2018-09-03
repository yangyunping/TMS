namespace GoldenLady.Utility.UserControls
{
    partial class SinglePhotoPicker
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.pnlCtrl = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlInfo.SuspendLayout();
            this.pnlCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.SystemColors.Info;
            this.pnlInfo.Controls.Add(this.lblName);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInfo.Location = new System.Drawing.Point(0, 290);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(240, 30);
            this.pnlInfo.TabIndex = 0;
            // 
            // pnlCtrl
            // 
            this.pnlCtrl.Controls.Add(this.btnClear);
            this.pnlCtrl.Controls.Add(this.btnOpenFile);
            this.pnlCtrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCtrl.Location = new System.Drawing.Point(0, 320);
            this.pnlCtrl.Name = "pnlCtrl";
            this.pnlCtrl.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlCtrl.Size = new System.Drawing.Size(240, 40);
            this.pnlCtrl.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(240, 30);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "没有图片";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picPhoto
            // 
            this.picPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPhoto.Location = new System.Drawing.Point(0, 0);
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.Size = new System.Drawing.Size(240, 290);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.TabIndex = 2;
            this.picPhoto.TabStop = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpenFile.Location = new System.Drawing.Point(0, 5);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(108, 30);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "打开图片文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClear.Location = new System.Drawing.Point(132, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 30);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清除图片";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // SinglePhotoPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picPhoto);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlCtrl);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(240, 360);
            this.Name = "SinglePhotoPicker";
            this.Size = new System.Drawing.Size(240, 360);
            this.pnlInfo.ResumeLayout(false);
            this.pnlCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlCtrl;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOpenFile;
    }
}
