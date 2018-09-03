namespace GoldenLady.Dress.View
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.tspMenues = new System.Windows.Forms.ToolStrip();
            this.btnDressChoose = new System.Windows.Forms.ToolStripButton();
            this.btncsSearch = new System.Windows.Forms.ToolStripButton();
            this.btnDressRent = new System.Windows.Forms.ToolStripButton();
            this.btnStateChange = new System.Windows.Forms.ToolStripButton();
            this.btnDressManage = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCheck = new System.Windows.Forms.ToolStripButton();
            this.btnStatistics = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDressInfo = new System.Windows.Forms.ToolStripButton();
            this.tbContent = new System.Windows.Forms.TabControl();
            this.btnConfig = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.tspMenues.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.tspMenues);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 1045);
            this.panel1.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(12, 981);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "礼服师";
            // 
            // tspMenues
            // 
            this.tspMenues.BackColor = System.Drawing.Color.Transparent;
            this.tspMenues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tspMenues.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspMenues.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.tspMenues.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDressChoose,
            this.btncsSearch,
            this.btnDressRent,
            this.btnStateChange,
            this.btnDressManage,
            this.tsBtnCheck,
            this.btnStatistics,
            this.tsBtnDressInfo,
            this.btnConfig});
            this.tspMenues.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tspMenues.Location = new System.Drawing.Point(0, 0);
            this.tspMenues.Name = "tspMenues";
            this.tspMenues.Size = new System.Drawing.Size(167, 1045);
            this.tspMenues.TabIndex = 0;
            this.tspMenues.Text = "toolStrip1";
            this.tspMenues.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tspMenues_ItemClicked);
            // 
            // btnDressChoose
            // 
            this.btnDressChoose.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnDressChoose.ForeColor = System.Drawing.Color.White;
            this.btnDressChoose.Image = ((System.Drawing.Image)(resources.GetObject("btnDressChoose.Image")));
            this.btnDressChoose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDressChoose.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.btnDressChoose.Name = "btnDressChoose";
            this.btnDressChoose.Size = new System.Drawing.Size(155, 39);
            this.btnDressChoose.Text = "礼服预选";
            this.btnDressChoose.Click += new System.EventHandler(this.btnDressChoose_ButtonClick);
            // 
            // btncsSearch
            // 
            this.btncsSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btncsSearch.ForeColor = System.Drawing.Color.White;
            this.btncsSearch.Image = ((System.Drawing.Image)(resources.GetObject("btncsSearch.Image")));
            this.btncsSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncsSearch.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.btncsSearch.Name = "btncsSearch";
            this.btncsSearch.Size = new System.Drawing.Size(155, 39);
            this.btncsSearch.Text = "预选查询";
            this.btncsSearch.Click += new System.EventHandler(this.btncsSearch_Click);
            // 
            // btnDressRent
            // 
            this.btnDressRent.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnDressRent.ForeColor = System.Drawing.Color.White;
            this.btnDressRent.Image = ((System.Drawing.Image)(resources.GetObject("btnDressRent.Image")));
            this.btnDressRent.ImageTransparentColor = System.Drawing.Color.MediumOrchid;
            this.btnDressRent.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.btnDressRent.Name = "btnDressRent";
            this.btnDressRent.Size = new System.Drawing.Size(155, 39);
            this.btnDressRent.Text = "礼服出租";
            this.btnDressRent.Click += new System.EventHandler(this.btnDressRent_Click);
            // 
            // btnStateChange
            // 
            this.btnStateChange.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnStateChange.ForeColor = System.Drawing.Color.White;
            this.btnStateChange.Image = ((System.Drawing.Image)(resources.GetObject("btnStateChange.Image")));
            this.btnStateChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStateChange.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.btnStateChange.Name = "btnStateChange";
            this.btnStateChange.Size = new System.Drawing.Size(155, 39);
            this.btnStateChange.Text = "状态管理";
            this.btnStateChange.Click += new System.EventHandler(this.btnStateChange_Click);
            // 
            // btnDressManage
            // 
            this.btnDressManage.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnDressManage.ForeColor = System.Drawing.Color.White;
            this.btnDressManage.Image = ((System.Drawing.Image)(resources.GetObject("btnDressManage.Image")));
            this.btnDressManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDressManage.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.btnDressManage.Name = "btnDressManage";
            this.btnDressManage.Size = new System.Drawing.Size(155, 39);
            this.btnDressManage.Text = "礼服管理";
            this.btnDressManage.Click += new System.EventHandler(this.btnDressManage_Click);
            // 
            // tsBtnCheck
            // 
            this.tsBtnCheck.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsBtnCheck.ForeColor = System.Drawing.Color.White;
            this.tsBtnCheck.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCheck.Image")));
            this.tsBtnCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCheck.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.tsBtnCheck.Name = "tsBtnCheck";
            this.tsBtnCheck.Size = new System.Drawing.Size(155, 39);
            this.tsBtnCheck.Text = "每日清点";
            this.tsBtnCheck.Click += new System.EventHandler(this.tsBtnCheck_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnStatistics.ForeColor = System.Drawing.Color.White;
            this.btnStatistics.Image = ((System.Drawing.Image)(resources.GetObject("btnStatistics.Image")));
            this.btnStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(155, 39);
            this.btnStatistics.Text = "统计查询";
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // tsBtnDressInfo
            // 
            this.tsBtnDressInfo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.tsBtnDressInfo.ForeColor = System.Drawing.Color.White;
            this.tsBtnDressInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDressInfo.Image")));
            this.tsBtnDressInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDressInfo.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.tsBtnDressInfo.Name = "tsBtnDressInfo";
            this.tsBtnDressInfo.Size = new System.Drawing.Size(155, 39);
            this.tsBtnDressInfo.Text = "礼服查询";
            this.tsBtnDressInfo.Click += new System.EventHandler(this.tsBtnDressInfo_Click);
            // 
            // tbContent
            // 
            this.tbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbContent.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbContent.Location = new System.Drawing.Point(167, 0);
            this.tbContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbContent.Name = "tbContent";
            this.tbContent.SelectedIndex = 0;
            this.tbContent.Size = new System.Drawing.Size(814, 1045);
            this.tbContent.TabIndex = 1;
            this.tbContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbContent_MouseDoubleClick);
            // 
            // btnConfig
            // 
            this.btnConfig.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfig.ForeColor = System.Drawing.Color.White;
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfig.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(155, 39);
            this.btnConfig.Text = "系统设置";
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(981, 1045);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "礼服系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tspMenues.ResumeLayout(false);
            this.tspMenues.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tbContent;
        private System.Windows.Forms.ToolStrip tspMenues;
        private System.Windows.Forms.ToolStripButton btncsSearch;
        private System.Windows.Forms.ToolStripButton btnDressRent;
        private System.Windows.Forms.ToolStripButton btnStateChange;
        private System.Windows.Forms.ToolStripButton btnDressManage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolStripButton tsBtnCheck;
        private System.Windows.Forms.ToolStripButton btnDressChoose;
        private System.Windows.Forms.ToolStripButton btnStatistics;
        private System.Windows.Forms.ToolStripButton tsBtnDressInfo;
        private System.Windows.Forms.ToolStripButton btnConfig;
    }
}