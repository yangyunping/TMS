namespace GoldenLady.SMSNew
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnOption = new System.Windows.Forms.Button();
            this.btnSendSms = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOption
            // 
            this.btnOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOption.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOption.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOption.Image = ((System.Drawing.Image)(resources.GetObject("btnOption.Image")));
            this.btnOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOption.Location = new System.Drawing.Point(58, 31);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(104, 49);
            this.btnOption.TabIndex = 0;
            this.btnOption.Text = "短信设置";
            this.btnOption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOption.UseVisualStyleBackColor = true;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btnSendSms
            // 
            this.btnSendSms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendSms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendSms.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendSms.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSendSms.Image = ((System.Drawing.Image)(resources.GetObject("btnSendSms.Image")));
            this.btnSendSms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendSms.Location = new System.Drawing.Point(58, 86);
            this.btnSendSms.Name = "btnSendSms";
            this.btnSendSms.Size = new System.Drawing.Size(104, 49);
            this.btnSendSms.TabIndex = 1;
            this.btnSendSms.Text = "发送短信";
            this.btnSendSms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendSms.UseVisualStyleBackColor = true;
            this.btnSendSms.Click += new System.EventHandler(this.btnSendSms_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(58, 141);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 49);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "短信查询";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(226, 224);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSendSms);
            this.Controls.Add(this.btnOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "短信平台";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.Button btnSendSms;
        private System.Windows.Forms.Button btnSearch;
    }
}