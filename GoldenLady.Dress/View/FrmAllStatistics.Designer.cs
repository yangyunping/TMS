namespace GoldenLady.Dress.View
{
    partial class FrmAllStatistics
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAllStatistics));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnDressEmpAchieve = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCleanMemary = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRoom = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDressInOut = new System.Windows.Forms.ToolStripButton();
            this.btnFavourite = new System.Windows.Forms.ToolStripButton();
            this.gbShow = new System.Windows.Forms.Panel();
            this.sBtnCreate = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsBtnDressEmpAchieve,
            this.tsBtnCleanMemary,
            this.tsBtnRoom,
            this.tsBtnDressInOut,
            this.btnFavourite,
            this.sBtnCreate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1038, 62);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 62);
            // 
            // tsBtnDressEmpAchieve
            // 
            this.tsBtnDressEmpAchieve.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDressEmpAchieve.Image")));
            this.tsBtnDressEmpAchieve.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDressEmpAchieve.Name = "tsBtnDressEmpAchieve";
            this.tsBtnDressEmpAchieve.Size = new System.Drawing.Size(83, 59);
            this.tsBtnDressEmpAchieve.Text = "礼服师业绩";
            this.tsBtnDressEmpAchieve.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnDressEmpAchieve.Click += new System.EventHandler(this.tsBtnDressEmpAchieve_Click);
            // 
            // tsBtnCleanMemary
            // 
            this.tsBtnCleanMemary.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCleanMemary.Image")));
            this.tsBtnCleanMemary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCleanMemary.Name = "tsBtnCleanMemary";
            this.tsBtnCleanMemary.Size = new System.Drawing.Size(97, 59);
            this.tsBtnCleanMemary.Text = "礼服送洗统计";
            this.tsBtnCleanMemary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnCleanMemary.Click += new System.EventHandler(this.tsBtnCleanMemary_Click);
            // 
            // tsBtnRoom
            // 
            this.tsBtnRoom.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRoom.Image")));
            this.tsBtnRoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRoom.Name = "tsBtnRoom";
            this.tsBtnRoom.Size = new System.Drawing.Size(83, 59);
            this.tsBtnRoom.Text = "洗衣房统计";
            this.tsBtnRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnRoom.Click += new System.EventHandler(this.tsBtnRoom_Click);
            // 
            // tsBtnDressInOut
            // 
            this.tsBtnDressInOut.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDressInOut.Image")));
            this.tsBtnDressInOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDressInOut.Name = "tsBtnDressInOut";
            this.tsBtnDressInOut.Size = new System.Drawing.Size(97, 59);
            this.tsBtnDressInOut.Text = "礼服记录查询";
            this.tsBtnDressInOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnDressInOut.Click += new System.EventHandler(this.tsBtnDressInOut_Click);
            // 
            // btnFavourite
            // 
            this.btnFavourite.Image = ((System.Drawing.Image)(resources.GetObject("btnFavourite.Image")));
            this.btnFavourite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFavourite.Name = "btnFavourite";
            this.btnFavourite.Size = new System.Drawing.Size(97, 59);
            this.btnFavourite.Text = "最受欢迎礼服";
            this.btnFavourite.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnFavourite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFavourite.Click += new System.EventHandler(this.btnFavourite_Click);
            // 
            // gbShow
            // 
            this.gbShow.BackColor = System.Drawing.Color.White;
            this.gbShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbShow.Location = new System.Drawing.Point(0, 62);
            this.gbShow.Name = "gbShow";
            this.gbShow.Size = new System.Drawing.Size(1038, 626);
            this.gbShow.TabIndex = 1;
            // 
            // sBtnCreate
            // 
            this.sBtnCreate.BackColor = System.Drawing.Color.Transparent;
            this.sBtnCreate.Image = ((System.Drawing.Image)(resources.GetObject("sBtnCreate.Image")));
            this.sBtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sBtnCreate.Name = "sBtnCreate";
            this.sBtnCreate.Size = new System.Drawing.Size(97, 59);
            this.sBtnCreate.Text = "新增礼服查询";
            this.sBtnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sBtnCreate.Click += new System.EventHandler(this.sBtnCreate_Click);
            // 
            // FrmAllStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbShow);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmAllStatistics";
            this.Size = new System.Drawing.Size(1038, 688);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnDressEmpAchieve;
        private System.Windows.Forms.ToolStripButton tsBtnCleanMemary;
        private System.Windows.Forms.ToolStripButton tsBtnRoom;
        private System.Windows.Forms.ToolStripButton tsBtnDressInOut;
        private System.Windows.Forms.Panel gbShow;
        private System.Windows.Forms.ToolStripButton btnFavourite;
        private System.Windows.Forms.ToolStripButton sBtnCreate;
    }
}
