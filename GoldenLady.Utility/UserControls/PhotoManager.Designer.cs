namespace GoldenLady.Utility.UserControls
{
    partial class PhotoManager
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
            this.btnDeletePhoto = new System.Windows.Forms.Button();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.lvwPhoto = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCopyPhoto = new System.Windows.Forms.Button();
            this.pnlManage = new System.Windows.Forms.Panel();
            this.pnlView = new System.Windows.Forms.Panel();
            this.photoViewer = new GoldenLady.Utility.UserControls.PhotoViewer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlManage.SuspendLayout();
            this.pnlView.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeletePhoto
            // 
            this.btnDeletePhoto.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeletePhoto.Location = new System.Drawing.Point(331, 0);
            this.btnDeletePhoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeletePhoto.Name = "btnDeletePhoto";
            this.btnDeletePhoto.Size = new System.Drawing.Size(119, 34);
            this.btnDeletePhoto.TabIndex = 3;
            this.btnDeletePhoto.Text = "删除选中照片";
            this.btnDeletePhoto.UseVisualStyleBackColor = true;
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAddPhoto.Location = new System.Drawing.Point(0, 0);
            this.btnAddPhoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(119, 34);
            this.btnAddPhoto.TabIndex = 2;
            this.btnAddPhoto.Text = "添加照片";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            // 
            // lvwPhoto
            // 
            this.lvwPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPhoto.Location = new System.Drawing.Point(0, 0);
            this.lvwPhoto.Name = "lvwPhoto";
            this.lvwPhoto.Size = new System.Drawing.Size(450, 760);
            this.lvwPhoto.TabIndex = 3;
            this.lvwPhoto.UseCompatibleStateImageBehavior = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvwPhoto);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(450, 760);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 8);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCopyPhoto);
            this.panel1.Controls.Add(this.btnDeletePhoto);
            this.panel1.Controls.Add(this.btnAddPhoto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 34);
            this.panel1.TabIndex = 0;
            // 
            // btnCopyPhoto
            // 
            this.btnCopyPhoto.Location = new System.Drawing.Point(167, 0);
            this.btnCopyPhoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCopyPhoto.Name = "btnCopyPhoto";
            this.btnCopyPhoto.Size = new System.Drawing.Size(119, 34);
            this.btnCopyPhoto.TabIndex = 4;
            this.btnCopyPhoto.Text = "复制选中照片";
            this.btnCopyPhoto.UseVisualStyleBackColor = true;
            // 
            // pnlManage
            // 
            this.pnlManage.Controls.Add(this.panel3);
            this.pnlManage.Controls.Add(this.panel2);
            this.pnlManage.Controls.Add(this.panel1);
            this.pnlManage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlManage.Location = new System.Drawing.Point(0, 0);
            this.pnlManage.Name = "pnlManage";
            this.pnlManage.Size = new System.Drawing.Size(450, 802);
            this.pnlManage.TabIndex = 6;
            // 
            // pnlView
            // 
            this.pnlView.Controls.Add(this.photoViewer);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(450, 0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(954, 802);
            this.pnlView.TabIndex = 7;
            // 
            // photoViewer
            // 
            this.photoViewer.CurrentIndex = -1;
            this.photoViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoViewer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.photoViewer.Location = new System.Drawing.Point(0, 0);
            this.photoViewer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.photoViewer.Name = "photoViewer";
            this.photoViewer.PageButtonWidth = 80;
            this.photoViewer.Size = new System.Drawing.Size(954, 802);
            this.photoViewer.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(450, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(8, 802);
            this.panel4.TabIndex = 8;
            // 
            // PhotoManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.pnlManage);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(440, 200);
            this.Name = "PhotoManager";
            this.Size = new System.Drawing.Size(1404, 802);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlManage.ResumeLayout(false);
            this.pnlView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeletePhoto;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.ListView lvwPhoto;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlManage;
        private System.Windows.Forms.Panel pnlView;
        private PhotoViewer photoViewer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCopyPhoto;
    }
}
