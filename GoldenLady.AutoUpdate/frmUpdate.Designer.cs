namespace GoldenLady.AutoUpdate
{
    partial class frmUpdate
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFile = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.pgbDownProcess = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(6, 32);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(47, 12);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "lblFile";
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(319, 32);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(53, 12);
            this.lblFileCount.TabIndex = 1;
            this.lblFileCount.Text = "lblCount";
            // 
            // pgbDownProcess
            // 
            this.pgbDownProcess.Location = new System.Drawing.Point(6, 6);
            this.pgbDownProcess.Name = "pgbDownProcess";
            this.pgbDownProcess.Size = new System.Drawing.Size(390, 23);
            this.pgbDownProcess.Step = 1;
            this.pgbDownProcess.TabIndex = 2;
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 50);
            this.ControlBox = false;
            this.Controls.Add(this.pgbDownProcess);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.lblFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动更新";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.ProgressBar pgbDownProcess;
    }
}

