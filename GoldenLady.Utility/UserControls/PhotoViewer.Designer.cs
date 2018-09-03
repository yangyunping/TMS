namespace GoldenLady.Utility.UserControls
{
    partial class PhotoViewer
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
            this.pnlPage = new System.Windows.Forms.Panel();
            this.lblPage = new System.Windows.Forms.Label();
            this.pnlName = new System.Windows.Forms.Panel();
            this.linkOptional = new System.Windows.Forms.LinkLabel();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.btnNext = new TransparentBlock();
            this.btnPrev = new TransparentBlock();
            this.pnlPage.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPage
            // 
            this.pnlPage.BackColor = System.Drawing.SystemColors.Info;
            this.pnlPage.Controls.Add(this.lblPage);
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPage.Location = new System.Drawing.Point(0, 503);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(853, 30);
            this.pnlPage.TabIndex = 0;
            // 
            // lblPage
            // 
            this.lblPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPage.Location = new System.Drawing.Point(0, 0);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(853, 30);
            this.lblPage.TabIndex = 0;
            this.lblPage.Text = "1 / 20";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlName
            // 
            this.pnlName.BackColor = System.Drawing.SystemColors.Info;
            this.pnlName.Controls.Add(this.linkOptional);
            this.pnlName.Controls.Add(this.lblName);
            this.pnlName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlName.Location = new System.Drawing.Point(0, 533);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(853, 30);
            this.pnlName.TabIndex = 1;
            // 
            // linkOptional
            // 
            this.linkOptional.Dock = System.Windows.Forms.DockStyle.Right;
            this.linkOptional.Location = new System.Drawing.Point(775, 0);
            this.linkOptional.Name = "linkOptional";
            this.linkOptional.Size = new System.Drawing.Size(78, 30);
            this.linkOptional.TabIndex = 1;
            this.linkOptional.TabStop = true;
            this.linkOptional.Text = "功能按钮";
            this.linkOptional.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(853, 30);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "场景图片1.jpg";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pic);
            this.pnlMain.Controls.Add(this.btnNext);
            this.pnlMain.Controls.Add(this.btnPrev);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(853, 503);
            this.pnlMain.TabIndex = 2;
            // 
            // pic
            // 
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.Location = new System.Drawing.Point(80, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(693, 503);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Alpha = 50;
            this.btnNext.BaseColor = System.Drawing.Color.Gray;
            this.btnNext.ChangeAlphaWhenMouseOver = true;
            this.btnNext.CurrentAlpha = 50;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNext.Location = new System.Drawing.Point(773, 0);
            this.btnNext.MouseOverAlpha = 100;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 503);
            this.btnNext.TabIndex = 2;
            this.btnNext.UserDraw = null;
            // 
            // btnPrev
            // 
            this.btnPrev.Alpha = 50;
            this.btnPrev.BaseColor = System.Drawing.Color.Gray;
            this.btnPrev.ChangeAlphaWhenMouseOver = true;
            this.btnPrev.CurrentAlpha = 50;
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrev.Location = new System.Drawing.Point(0, 0);
            this.btnPrev.MouseOverAlpha = 100;
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(80, 503);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.UserDraw = null;
            // 
            // PhotoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlPage);
            this.Controls.Add(this.pnlName);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PhotoViewer";
            this.Size = new System.Drawing.Size(853, 563);
            this.pnlPage.ResumeLayout(false);
            this.pnlName.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.LinkLabel linkOptional;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox pic;
        private TransparentBlock btnPrev;
        private TransparentBlock btnNext;
    }
}
