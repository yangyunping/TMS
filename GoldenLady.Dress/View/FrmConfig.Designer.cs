namespace GoldenLady.Dress.View
{
    partial class FrmConfig
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
            this.prgConfig = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // prgConfig
            // 
            this.prgConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgConfig.Location = new System.Drawing.Point(0, 0);
            this.prgConfig.Name = "prgConfig";
            this.prgConfig.Size = new System.Drawing.Size(1008, 729);
            this.prgConfig.TabIndex = 0;
            //
            // pnlMain
            //
            pnlMain.Controls.Add(this.prgConfig);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "FrmConfig";
            this.Text = "配置信息管理";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PropertyGrid prgConfig;






    }
}