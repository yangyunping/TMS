namespace GoldenLady.Dress.View.Template
{
    partial class FrmPhotoShow
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
            this.components = new System.ComponentModel.Container();
            this.ilstAll = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.picBigView = new System.Windows.Forms.PictureBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lvwSmallView = new GoldenLady.Dress.DoubleBufferListView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picBigView)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilstAll
            // 
            this.ilstAll.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilstAll.ImageSize = new System.Drawing.Size(100, 100);
            this.ilstAll.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // picBigView
            // 
            this.picBigView.BackColor = System.Drawing.Color.White;
            this.picBigView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBigView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBigView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBigView.Location = new System.Drawing.Point(0, 0);
            this.picBigView.Name = "picBigView";
            this.picBigView.Size = new System.Drawing.Size(729, 657);
            this.picBigView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBigView.TabIndex = 1;
            this.picBigView.TabStop = false;
            this.picBigView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptb1_MouseDown);
            this.picBigView.MouseLeave += new System.EventHandler(this.picView_MouseLeave);
            this.picBigView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptb1_MouseMove);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.lvwSmallView);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(318, 657);
            this.panel12.TabIndex = 4;
            // 
            // lvwSmallView
            // 
            this.lvwSmallView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSmallView.LargeImageList = this.ilstAll;
            this.lvwSmallView.Location = new System.Drawing.Point(0, 0);
            this.lvwSmallView.Name = "lvwSmallView";
            this.lvwSmallView.Size = new System.Drawing.Size(318, 657);
            this.lvwSmallView.TabIndex = 0;
            this.lvwSmallView.UseCompatibleStateImageBehavior = false;
            this.lvwSmallView.Click += new System.EventHandler(this.lvwAll_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picBigView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(318, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 657);
            this.panel1.TabIndex = 5;
            // 
            // FrmPhotoShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1047, 657);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel12);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmPhotoShow";
            this.Text = "照片预览";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPhotoShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBigView)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ilstAll;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox picBigView;
        private System.Windows.Forms.Panel panel12;
        private DoubleBufferListView lvwSmallView;
        private System.Windows.Forms.Panel panel1;


    }
}