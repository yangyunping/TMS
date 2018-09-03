namespace GoldenLady.Dress.View
{
    partial class FrmNewDress
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
            GoldenLady.Utility.UserControls.CustomizeGroupBox grpPhoto;
            GoldenLady.Utility.UserControls.CustomizeGroupBox grpInfo;
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            this.photoPicker = new GoldenLady.Utility.UserControls.SinglePhotoPicker();
            this.txtSale = new GoldenLady.Utility.UserControls.CashTextBox();
            this.txtRent = new GoldenLady.Utility.UserControls.CashTextBox();
            this.txtCost = new GoldenLady.Utility.UserControls.CashTextBox();
            this.numNOTime = new System.Windows.Forms.NumericUpDown();
            this.numUsedToday = new System.Windows.Forms.NumericUpDown();
            this.txtSource = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.btnPickArea = new System.Windows.Forms.Button();
            this.txtArea = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.txtBuyer = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.txtDescription = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.txtNote = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.cmbUse = new System.Windows.Forms.ComboBox();
            this.cmbLowerMaterial = new System.Windows.Forms.ComboBox();
            this.cmbUpperMaterial = new System.Windows.Forms.ComboBox();
            this.cmbLowerStyle = new System.Windows.Forms.ComboBox();
            this.cmbUpperStyle = new System.Windows.Forms.ComboBox();
            this.cmbOrnamental = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtBarCode = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.txtCustomCode = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.txtDressNo = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            this.cmbServerPath = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.grpServer = new GoldenLady.Utility.UserControls.CustomizeGroupBox();
            this.btnModify = new System.Windows.Forms.Button();
            grpPhoto = new GoldenLady.Utility.UserControls.CustomizeGroupBox();
            grpInfo = new GoldenLady.Utility.UserControls.CustomizeGroupBox();
            label26 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            grpPhoto.SuspendLayout();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNOTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsedToday)).BeginInit();
            this.grpServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnModify);
            this.pnlMain.Controls.Add(this.grpServer);
            this.pnlMain.Controls.Add(this.btnNew);
            this.pnlMain.Controls.Add(grpPhoto);
            this.pnlMain.Controls.Add(grpInfo);
            this.pnlMain.Size = new System.Drawing.Size(837, 681);
            // 
            // pnlWait
            // 
            this.pnlWait.Size = new System.Drawing.Size(837, 681);
            // 
            // grpPhoto
            // 
            grpPhoto.BorderColor = System.Drawing.Color.Black;
            grpPhoto.Controls.Add(this.photoPicker);
            grpPhoto.Location = new System.Drawing.Point(481, 3);
            grpPhoto.Name = "grpPhoto";
            grpPhoto.Size = new System.Drawing.Size(344, 596);
            grpPhoto.TabIndex = 1;
            grpPhoto.TabStop = false;
            grpPhoto.Text = "照片信息";
            grpPhoto.TitleFontColor = System.Drawing.Color.Black;
            // 
            // photoPicker
            // 
            this.photoPicker.CurrentPhoto = null;
            this.photoPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoPicker.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.photoPicker.Location = new System.Drawing.Point(3, 22);
            this.photoPicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.photoPicker.MinimumSize = new System.Drawing.Size(240, 360);
            this.photoPicker.Name = "photoPicker";
            this.photoPicker.PhotoFileFilter = "照片文件(*.jpg;)|*.jpg;";
            this.photoPicker.PhotoFilePath = null;
            this.photoPicker.Size = new System.Drawing.Size(338, 571);
            this.photoPicker.TabIndex = 0;
            // 
            // grpInfo
            // 
            grpInfo.BorderColor = System.Drawing.Color.Black;
            grpInfo.Controls.Add(label26);
            grpInfo.Controls.Add(this.txtSale);
            grpInfo.Controls.Add(label25);
            grpInfo.Controls.Add(this.txtRent);
            grpInfo.Controls.Add(label24);
            grpInfo.Controls.Add(this.txtCost);
            grpInfo.Controls.Add(this.numNOTime);
            grpInfo.Controls.Add(label23);
            grpInfo.Controls.Add(this.numUsedToday);
            grpInfo.Controls.Add(label22);
            grpInfo.Controls.Add(this.txtSource);
            grpInfo.Controls.Add(label21);
            grpInfo.Controls.Add(this.btnPickArea);
            grpInfo.Controls.Add(this.txtArea);
            grpInfo.Controls.Add(label18);
            grpInfo.Controls.Add(this.txtBuyer);
            grpInfo.Controls.Add(label20);
            grpInfo.Controls.Add(this.cmbLevel);
            grpInfo.Controls.Add(label19);
            grpInfo.Controls.Add(this.txtDescription);
            grpInfo.Controls.Add(label17);
            grpInfo.Controls.Add(this.txtNote);
            grpInfo.Controls.Add(label16);
            grpInfo.Controls.Add(this.cmbSupplier);
            grpInfo.Controls.Add(label15);
            grpInfo.Controls.Add(this.cmbUse);
            grpInfo.Controls.Add(label14);
            grpInfo.Controls.Add(this.cmbLowerMaterial);
            grpInfo.Controls.Add(label12);
            grpInfo.Controls.Add(this.cmbUpperMaterial);
            grpInfo.Controls.Add(label13);
            grpInfo.Controls.Add(this.cmbLowerStyle);
            grpInfo.Controls.Add(label11);
            grpInfo.Controls.Add(this.cmbUpperStyle);
            grpInfo.Controls.Add(label10);
            grpInfo.Controls.Add(this.cmbOrnamental);
            grpInfo.Controls.Add(label9);
            grpInfo.Controls.Add(this.cmbBrand);
            grpInfo.Controls.Add(label8);
            grpInfo.Controls.Add(this.cmbColor);
            grpInfo.Controls.Add(label7);
            grpInfo.Controls.Add(this.cmbCategory);
            grpInfo.Controls.Add(label6);
            grpInfo.Controls.Add(this.cmbType);
            grpInfo.Controls.Add(label5);
            grpInfo.Controls.Add(this.txtBarCode);
            grpInfo.Controls.Add(label4);
            grpInfo.Controls.Add(this.txtCustomCode);
            grpInfo.Controls.Add(label3);
            grpInfo.Controls.Add(this.txtDressNo);
            grpInfo.Controls.Add(label2);
            grpInfo.Location = new System.Drawing.Point(13, 3);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new System.Drawing.Size(454, 596);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "基本信息";
            grpInfo.TitleFontColor = System.Drawing.Color.Black;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(307, 437);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(65, 20);
            label26.TabIndex = 53;
            label26.Text = "出售价格";
            // 
            // txtSale
            // 
            this.txtSale.Location = new System.Drawing.Point(378, 434);
            this.txtSale.Name = "txtSale";
            this.txtSale.Size = new System.Drawing.Size(63, 26);
            this.txtSale.TabIndex = 52;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(158, 437);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(65, 20);
            label25.TabIndex = 51;
            label25.Text = "出租价格";
            // 
            // txtRent
            // 
            this.txtRent.Location = new System.Drawing.Point(229, 434);
            this.txtRent.Name = "txtRent";
            this.txtRent.Size = new System.Drawing.Size(63, 26);
            this.txtRent.TabIndex = 50;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(6, 437);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(65, 20);
            label24.TabIndex = 49;
            label24.Text = "成本价格";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(77, 434);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(63, 26);
            this.txtCost.TabIndex = 48;
            // 
            // numNOTime
            // 
            this.numNOTime.Location = new System.Drawing.Point(305, 393);
            this.numNOTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numNOTime.Name = "numNOTime";
            this.numNOTime.Size = new System.Drawing.Size(136, 26);
            this.numNOTime.TabIndex = 47;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(234, 396);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(65, 20);
            label23.TabIndex = 46;
            label23.Text = "预用次数";
            // 
            // numUsedToday
            // 
            this.numUsedToday.Location = new System.Drawing.Point(91, 393);
            this.numUsedToday.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numUsedToday.Name = "numUsedToday";
            this.numUsedToday.Size = new System.Drawing.Size(122, 26);
            this.numUsedToday.TabIndex = 45;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(6, 396);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(79, 20);
            label22.TabIndex = 44;
            label22.Text = "日使用次数";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(77, 475);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(364, 26);
            this.txtSource.TabIndex = 43;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(6, 478);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(65, 20);
            label21.TabIndex = 42;
            label21.Text = "购买渠道";
            // 
            // btnPickArea
            // 
            this.btnPickArea.Location = new System.Drawing.Point(238, 350);
            this.btnPickArea.Name = "btnPickArea";
            this.btnPickArea.Size = new System.Drawing.Size(75, 31);
            this.btnPickArea.TabIndex = 41;
            this.btnPickArea.Text = "区域选择";
            this.btnPickArea.UseVisualStyleBackColor = true;
            this.btnPickArea.Click += new System.EventHandler(this.btnPickArea_Click);
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(77, 352);
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(136, 26);
            this.txtArea.TabIndex = 40;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(6, 355);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(65, 20);
            label18.TabIndex = 39;
            label18.Text = "礼服区域";
            // 
            // txtBuyer
            // 
            this.txtBuyer.Location = new System.Drawing.Point(305, 311);
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.Size = new System.Drawing.Size(136, 26);
            this.txtBuyer.TabIndex = 38;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(234, 314);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(65, 20);
            label20.TabIndex = 37;
            label20.Text = "购买人员";
            // 
            // cmbLevel
            // 
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Location = new System.Drawing.Point(77, 310);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(136, 28);
            this.cmbLevel.TabIndex = 36;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(6, 314);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(65, 20);
            label19.TabIndex = 35;
            label19.Text = "档次规格";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(77, 516);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(364, 26);
            this.txtDescription.TabIndex = 31;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(6, 519);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(65, 20);
            label17.TabIndex = 30;
            label17.Text = "礼服描述";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(77, 557);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(364, 26);
            this.txtNote.TabIndex = 29;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(6, 560);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(65, 20);
            label16.TabIndex = 28;
            label16.Text = "礼服备注";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(305, 269);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(136, 28);
            this.cmbSupplier.TabIndex = 27;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(234, 273);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(65, 20);
            label15.TabIndex = 26;
            label15.Text = "供应商家";
            // 
            // cmbUse
            // 
            this.cmbUse.FormattingEnabled = true;
            this.cmbUse.Location = new System.Drawing.Point(77, 269);
            this.cmbUse.Name = "cmbUse";
            this.cmbUse.Size = new System.Drawing.Size(136, 28);
            this.cmbUse.TabIndex = 25;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(6, 273);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(65, 20);
            label14.TabIndex = 24;
            label14.Text = "礼服用途";
            // 
            // cmbLowerMaterial
            // 
            this.cmbLowerMaterial.FormattingEnabled = true;
            this.cmbLowerMaterial.Location = new System.Drawing.Point(305, 228);
            this.cmbLowerMaterial.Name = "cmbLowerMaterial";
            this.cmbLowerMaterial.Size = new System.Drawing.Size(136, 28);
            this.cmbLowerMaterial.TabIndex = 23;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(234, 232);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(65, 20);
            label12.TabIndex = 22;
            label12.Text = "下身材质";
            // 
            // cmbUpperMaterial
            // 
            this.cmbUpperMaterial.FormattingEnabled = true;
            this.cmbUpperMaterial.Location = new System.Drawing.Point(305, 187);
            this.cmbUpperMaterial.Name = "cmbUpperMaterial";
            this.cmbUpperMaterial.Size = new System.Drawing.Size(136, 28);
            this.cmbUpperMaterial.TabIndex = 21;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(234, 191);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(65, 20);
            label13.TabIndex = 20;
            label13.Text = "上身材质";
            // 
            // cmbLowerStyle
            // 
            this.cmbLowerStyle.FormattingEnabled = true;
            this.cmbLowerStyle.Location = new System.Drawing.Point(77, 228);
            this.cmbLowerStyle.Name = "cmbLowerStyle";
            this.cmbLowerStyle.Size = new System.Drawing.Size(136, 28);
            this.cmbLowerStyle.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(6, 232);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(65, 20);
            label11.TabIndex = 18;
            label11.Text = "下身款式";
            // 
            // cmbUpperStyle
            // 
            this.cmbUpperStyle.FormattingEnabled = true;
            this.cmbUpperStyle.Location = new System.Drawing.Point(77, 187);
            this.cmbUpperStyle.Name = "cmbUpperStyle";
            this.cmbUpperStyle.Size = new System.Drawing.Size(136, 28);
            this.cmbUpperStyle.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(6, 191);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(65, 20);
            label10.TabIndex = 16;
            label10.Text = "上身款式";
            // 
            // cmbOrnamental
            // 
            this.cmbOrnamental.FormattingEnabled = true;
            this.cmbOrnamental.Location = new System.Drawing.Point(305, 146);
            this.cmbOrnamental.Name = "cmbOrnamental";
            this.cmbOrnamental.Size = new System.Drawing.Size(136, 28);
            this.cmbOrnamental.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(234, 150);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(65, 20);
            label9.TabIndex = 14;
            label9.Text = "礼服装饰";
            // 
            // cmbBrand
            // 
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(77, 146);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(136, 28);
            this.cmbBrand.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 150);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(65, 20);
            label8.TabIndex = 12;
            label8.Text = "礼服品牌";
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(77, 105);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(136, 28);
            this.cmbColor.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 109);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(65, 20);
            label7.TabIndex = 10;
            label7.Text = "礼服颜色";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(305, 105);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(136, 28);
            this.cmbCategory.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(234, 109);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(65, 20);
            label6.TabIndex = 8;
            label6.Text = "礼服类别";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(305, 64);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(136, 28);
            this.cmbType.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(234, 68);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(65, 20);
            label5.TabIndex = 6;
            label5.Text = "礼服性质";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(77, 65);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(136, 26);
            this.txtBarCode.TabIndex = 5;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 68);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(65, 20);
            label4.TabIndex = 4;
            label4.Text = "礼服条码";
            // 
            // txtCustomCode
            // 
            this.txtCustomCode.Location = new System.Drawing.Point(305, 24);
            this.txtCustomCode.Name = "txtCustomCode";
            this.txtCustomCode.Size = new System.Drawing.Size(136, 26);
            this.txtCustomCode.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(234, 27);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(65, 20);
            label3.TabIndex = 2;
            label3.Text = "自定编号";
            // 
            // txtDressNo
            // 
            this.txtDressNo.Location = new System.Drawing.Point(77, 24);
            this.txtDressNo.Name = "txtDressNo";
            this.txtDressNo.ReadOnly = true;
            this.txtDressNo.Size = new System.Drawing.Size(136, 26);
            this.txtDressNo.TabIndex = 1;
            this.txtDressNo.Text = "自动生成";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 20);
            label2.TabIndex = 0;
            label2.Text = "礼服编号";
            // 
            // cmbServerPath
            // 
            this.cmbServerPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServerPath.FormattingEnabled = true;
            this.cmbServerPath.Location = new System.Drawing.Point(8, 25);
            this.cmbServerPath.Name = "cmbServerPath";
            this.cmbServerPath.Size = new System.Drawing.Size(521, 28);
            this.cmbServerPath.TabIndex = 55;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Location = new System.Drawing.Point(556, 614);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(124, 54);
            this.btnNew.TabIndex = 54;
            this.btnNew.Text = "创建礼服";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // grpServer
            // 
            this.grpServer.BorderColor = System.Drawing.Color.Black;
            this.grpServer.Controls.Add(this.cmbServerPath);
            this.grpServer.Location = new System.Drawing.Point(13, 605);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(537, 64);
            this.grpServer.TabIndex = 56;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "上传到服务器";
            this.grpServer.TitleFontColor = System.Drawing.Color.Black;
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModify.Location = new System.Drawing.Point(701, 614);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(124, 54);
            this.btnModify.TabIndex = 57;
            this.btnModify.Text = "修改礼服";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // FrmNewDress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 681);
            this.Name = "FrmNewDress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "礼服建档";
            this.Load += new System.EventHandler(this.FrmNewDress_Load);
            this.pnlMain.ResumeLayout(false);
            grpPhoto.ResumeLayout(false);
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNOTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsedToday)).EndInit();
            this.grpServer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Utility.UserControls.CustomizedTextBox txtDressNo;
        private Utility.UserControls.CustomizedTextBox txtCustomCode;
        private Utility.UserControls.CustomizedTextBox txtBarCode;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbOrnamental;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbLowerStyle;
        private System.Windows.Forms.ComboBox cmbUpperStyle;
        private System.Windows.Forms.ComboBox cmbLowerMaterial;
        private System.Windows.Forms.ComboBox cmbUpperMaterial;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.ComboBox cmbUse;
        private Utility.UserControls.CustomizedTextBox txtDescription;
        private Utility.UserControls.CustomizedTextBox txtNote;
        private System.Windows.Forms.NumericUpDown numNOTime;
        private System.Windows.Forms.NumericUpDown numUsedToday;
        private Utility.UserControls.CustomizedTextBox txtSource;
        private System.Windows.Forms.Button btnPickArea;
        private Utility.UserControls.CustomizedTextBox txtArea;
        private Utility.UserControls.CustomizedTextBox txtBuyer;
        private System.Windows.Forms.ComboBox cmbLevel;
        private Utility.UserControls.CashTextBox txtSale;
        private Utility.UserControls.CashTextBox txtRent;
        private Utility.UserControls.CashTextBox txtCost;
        private System.Windows.Forms.Button btnNew;
        private Utility.UserControls.SinglePhotoPicker photoPicker;
        private System.Windows.Forms.ComboBox cmbServerPath;
        private Utility.UserControls.CustomizeGroupBox grpServer;
        private System.Windows.Forms.Button btnModify;

    }
}