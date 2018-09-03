namespace GoldenLady.Dress.View.Template
{
    partial class FrmExampleShow
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
            this.lblClose = new System.Windows.Forms.Label();
            this.picExample = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picExample)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblClose.Font = new System.Drawing.Font("华文中宋", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.Location = new System.Drawing.Point(590, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(45, 33);
            this.lblClose.TabIndex = 4;
            this.lblClose.Text = "×";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // picExample
            // 
            this.picExample.BackColor = System.Drawing.Color.White;
            this.picExample.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picExample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picExample.Location = new System.Drawing.Point(0, 0);
            this.picExample.Name = "picExample";
            this.picExample.Size = new System.Drawing.Size(635, 889);
            this.picExample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picExample.TabIndex = 3;
            this.picExample.TabStop = false;
            this.picExample.Click += new System.EventHandler(this.picExample_Click);
            this.picExample.Paint += new System.Windows.Forms.PaintEventHandler(this.picExample_Paint);
            this.picExample.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picExample_MouseDown);
            this.picExample.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picExample_MouseMove);
            this.picExample.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picExample_MouseUp);
            // 
            // FrmExampleShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(635, 889);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.picExample);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmExampleShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "照片展示";
            this.Shown += new System.EventHandler(this.FrmExampleShow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picExample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.PictureBox picExample;



    }
}