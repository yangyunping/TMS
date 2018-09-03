using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoldenLady.Dress.View;
using GoldenLady.ErrorHandle;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Global.Exception;
using GoldenLady.GoldenControl;
using GoldenLady.Standard;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress
{
    /// <summary>
    /// Redesign By: LiuHaiyang
    /// Date: 2016.12.1
    /// LastUpdate By: LiuHaiyang
    /// LastUpdateDate: 2017.1.14
    /// </summary>
    public partial class frmLogin : frmBaseForm
    {
        Service ErpWs = new Service();
        #region Constructors

        public frmLogin()
        {
            InitializeComponent();
            Init();
            BindMouseMoveEvent();
        }

        #endregion

        #region Classes

        private sealed class ServerLine
        {
            public string Name { get; set; }
            public string ConnectionString { get; set; }
        }

        #endregion

        #region Members

        /// <summary>
        /// 最多允许记录的用户名个数
        /// </summary>
        private const int MaxLoginNameSaveCount = 10;
        /// <summary>
        /// 记录的用户名用到的注册表信息键值
        /// </summary>
        private const string RegisterValueName = @"LoginName";
        /// <summary>
        /// 记录的用户名用到的注册表信息路径
        /// </summary>
        private static readonly Registry ResistryKey = new Registry(@"HKEY_CURRENT_USER\software\GoldenLady\");
        /// <summary>
        /// 用于鼠标拖拽移动窗口
        /// </summary>
        private Point _mousePoint;

        #endregion

        #region Methods

        private void BindMouseMoveEvent()
        {
            lblLogin.MouseDown += (sender, e) => _mousePoint = e.Location;
            lblLogin.MouseMove += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Location = new Point(Location.X + e.X - _mousePoint.X, Location.Y + e.Y - _mousePoint.Y);
                }
            };
            pbEmployeePhoto.MouseDown += (sender, e) => _mousePoint = e.Location;
            pbEmployeePhoto.MouseMove += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Location = new Point(Location.X + e.X - _mousePoint.X, Location.Y + e.Y - _mousePoint.Y);
                }
            };
            this.MouseDown += (sender, e) => _mousePoint = e.Location;
            this.MouseMove += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Location = new Point(Location.X + e.X - _mousePoint.X, Location.Y + e.Y - _mousePoint.Y);
                }
            };
            CloseForm.MouseDown += (sender, e) => Close();
            CloseForm.MouseEnter += (sender, args) => CloseForm.BackColor = Color.Red;
            CloseForm.MouseLeave += (sender, args) => CloseForm.BackColor = Color.Transparent;
        }
        private void Init()
        {
            // 初始化线路
            InitLine();

            // 初始化登录名
            LoadLoginEmployee();
        }
        private void InitLine()
        {
            cmbLine.Items.Clear();

            List<ServerLine> lstServerLines = new List<ServerLine>();
            string[] dsnName = ConfigurationManager.AppSettings["DSNName"].Split('|');
            for (int idx = 1; idx <= dsnName.Length; idx++)
            {
                string strConnection = ConfigurationManager.AppSettings["DSN" + idx];
                if (!(string.IsNullOrEmpty(dsnName[idx - 1]) || string.IsNullOrEmpty(strConnection)))
                    lstServerLines.Add(new ServerLine
                                       {
                                           Name = dsnName[idx - 1],
                                           ConnectionString = strConnection
                                       });
            }

            cmbLine.DataSource = lstServerLines;
            cmbLine.DisplayMember = @"Name";
            cmbLine.ValueMember = @"ConnectionString";
        }
        private void LoadEmployeePhoto()
        {
            try
            {
                using (DataSet myds = ErpWs.SearchEmployeeByEmployeeNO(cmbUserName.Text))
                {
                    SetImage(Image.FromStream(new MemoryStream((byte[])myds.Tables[0].Rows[0]["EmployeePhoto"]), true));
                }
            }
            catch
            {
                SetImage(null);
            }
        }
        private void LoadLoginEmployee()
        {
            string[] registry = ResistryKey.GetRegistry(RegisterValueName);
            if (null == registry)
            {
                cmbUserName.Focus();
                return;
            }
            cmbUserName.Items.AddRange(registry);
            cmbUserName.SelectedIndex = 0;
            txtPassword.Focus();
        }
        private void Login()
        {
            // 验证线路
            if (cmbLine.SelectedIndex < 0)
                throw ConnectionExeption.LineNotSelected;

            // 登录，记录各种用户信息
            try
            {
                using (DataSet dsUser = ErpService.CompanyManagement.SearchEmployeeInfo(cmbUserName.Text))
                {
                    if (dsUser.IsEmpty())
                    {
                        throw AccountException.UserNameNotExists;
                    }
                    Information.CurrentUser = dsUser.Tables[0].Rows[0];
                }
            }
            catch
            {
                MessageBox.Show(@"网络连接失败！");
            }
            if (Information.CurrentUser.EmployeePassword != txtPassword.Text)
            {
                throw AccountException.PasswordNotMatch;
            }

            if (Information.CurrentUser.IsDeleted)
            {
                throw AccountException.AccountInvalid;
            }
            // 记住用户名
            if (chbUserName.Checked)
            {
                string strLoginName = cmbUserName.Text;
                List<string> lstLoginName = new List<string>
                                            {
                                                    strLoginName
                                            };
                string[] registry = ResistryKey.GetRegistry(RegisterValueName);
                if (null != registry)
                {
                    foreach (string name in registry.TakeWhile(name => lstLoginName.Count < MaxLoginNameSaveCount).Where(name => 0 != StringComparer.CurrentCulture.Compare(strLoginName.ToUpper(), name.ToUpper())))
                        lstLoginName.Add(name);
                }
                ResistryKey.SetRegistry(RegisterValueName, lstLoginName.ToArray());
            }

            // 判断密码是否符合规范
            if (!txtPassword.Text.Trim().IsValidPassword())
            {
                MessageBox.Show(@"当前用户密码不符合规范，请按指示修改密码！");
                if (DialogResult.OK != new frmEmployeePassword().ShowDialog())
                    throw AccountException.PasswordInvalid;
            }

            // 隐藏登陆窗体
            Hide();

            // 初始公司、版本信息
            using (DataSet dsCompany = ErpService.CompanyManagement.SearchCompanyInfo())
            {
                if (!dsCompany.IsEmpty())
                {
                    Information.Company = dsCompany.Tables[0].Rows[0];
                }
            }
            using (DataSet dsEdition = ErpService.CompanyManagement.SearchEditionInfo())
            {
                if (!dsEdition.IsEmpty())
                {
                    Information.Edition = dsEdition.Tables[0].Rows[0];
                }
            }

            // 插入操作日志
            ErpService.LogManagement.SaveOperateLog(@"登录");

            // 提示登陆成功
            notify.Visible = true;
            notify.BalloonTipText = string.Format(@"用户[{0}] 登陆成功！{1}欢迎使用金牌流程管理系统！", Information.CurrentUser.EmployeeName, Environment.NewLine);
            notify.ShowBalloonTip(2000);
            notify.Visible = false;

            // 如果选择注销，重新显示登录窗口
            //if (DialogResult.OK == new frmGoldenLady().ShowDialog())
            //    Show();
            if (DialogResult.OK == new FrmMain().ShowDialog())
                Show();
            // 清理窗口
            cmbUserName.Text = null;
            txtPassword.Text = null;
            cmbUserName.Focus();
        }
     
        private bool HandleLoginError(Exception e)
        {
            bool bHandled = false;
            if (e is ConnectionExeption)
            {
                bHandled = true;
                ConnectionExeption ex = (ConnectionExeption)e;
                MessageBox.Show(ex.Message);
                switch (ex.ExeptionType)
                {
                    case ConnectionExeptionType.LineNotSelected:
                        {
                            cmbLine.Focus();
                            break;
                        }
                }
            }
            else if (e is AccountException)
            {
                bHandled = true;
                AccountException ex = (AccountException)e;
                MessageBox.Show(ex.Message);
                switch (ex.ExeptionType)
                {
                    case AccountExeptionType.UserNameNotExists:
                        {
                            cmbUserName.Focus();
                            cmbUserName.SelectAll();
                            txtPassword.Text = string.Empty;
                            break;
                        }
                    case AccountExeptionType.PasswordNotMatch:
                    case AccountExeptionType.AccountInvalid:
                    case AccountExeptionType.PasswordInvalid:
                        {
                            txtPassword.Focus();
                            txtPassword.SelectAll();
                            break;
                        }
                    case AccountExeptionType.NeedChangePassword:
                        {
                            frmEmployeePassword frmEmployeePassword = new frmEmployeePassword();
                            frmEmployeePassword.ShowDialog();
                            txtPassword.Focus();
                            txtPassword.SelectAll();
                            break;
                        }
                    case AccountExeptionType.PasswordRepeatNotMatch:
                        break;
                }
            }
            else if (e is WebException)
            {
                bHandled = true;
                WebException ex = (WebException)e;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"连接不上服务器！");
                sb.Append(HintString.PleaseConnectAdmin);
                MessageBox.Show(sb.ToString());
            }
            else if (e is SqlException)
            {
                SqlException ex = (SqlException)e;
                StringBuilder sb = new StringBuilder();
                switch (ex.Number)
                {
                    case SqlExceptionType.ConnectFailed:
                        {
                            bHandled = true;
                            sb.AppendLine(@"连接不上服务器！");
                            sb.AppendLine(@"请先检查本机网络连接是否正常，若问题依然存在");
                            sb.Append(HintString.PleaseConnectAdmin);
                            MessageBox.Show(sb.ToString());
                            break;
                        }
                }
            }
            else
            {
                Show();
            }
            return bHandled;
        }
        private void SetImage(Image img)
        {
            //pbEmployeePhoto.Invoke((Action<Image>)(image => pbEmployeePhoto.Image = image), img);
        }

        #endregion

        #region Event Handlers

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ErrorRecorder.SafeExecute(Login, HandleLoginError);
        }

        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (-1 == cmbLine.SelectedIndex)
                return;
            ConfigHelper.SetConfigValue("DSN", cmbLine.SelectedValue.ToString());
            WinAPI.WritePrivateProfileString("DBLine", "Line", cmbLine.SelectedIndex.ToString(), Application.StartupPath + @"\Config.ini");
            ErpWs.FetchConnString();
            ErpService.FetchConnString();
        }

        private void cmbUserName_Leave(object sender, EventArgs e)
        {
            Task.Factory.StartNew(LoadEmployeePhoto);
        }
        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Task.Factory.StartNew(LoadEmployeePhoto);
        }
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
        /// <summary>
        /// 快捷查看访问的服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F1)
                InputBox("", "", ErpWs.HelloWorld());
            if (e.KeyCode == Keys.Enter)
            {
                ErrorRecorder.SafeExecute(Login, HandleLoginError);
            }
        }
        /// <summary>
        /// 输入框
        /// </summary>
        /// <param name="sTitle">标题</param>
        /// <param name="sCaption">提示</param>
        /// <param name="sDefault">默认值</param>
        /// <returns></returns>
        private  string InputBox(string sTitle, string sCaption, string sDefault)
        {
            Dress.frmInputBox frmInputBox = new GoldenLady.Dress.frmInputBox(sTitle, sCaption, sDefault);
            if (frmInputBox.ShowDialog() == DialogResult.Yes)
            {
                return frmInputBox.sDefault;
            }
            return "";
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            // cmbLine的load发生在这之前，因为之前执行过了InitLine使得cmbLine有了数据
            // 所以这期间会自动将SelectedIndex置为0（没有数据的话置为-1）
            // 为了防止这个改动触发SelectedIndexChanged事件，就把这个事件的挂载放在了下面的代码中
            // 并且在此之前将SelectedIndex置为-1，这样保证程序在读取了配置文件中的SelectedIndex信息后
            // 才会引发该事件
            cmbLine.SelectedIndex = -1;
            cmbLine.SelectedIndexChanged += cmbLine_SelectedIndexChanged;

            // 读取线路
            const int nBufferSize = 255;
            StringBuilder lineNumber = new StringBuilder(nBufferSize);
            WinAPI.GetPrivateProfileString("DBLine", "Line", "-1", lineNumber, nBufferSize, Application.StartupPath + @"\Config.ini");
            cmbLine.SelectedIndex = Convert.ToInt32(lineNumber.ToString());
            this.Focus();
        }
        private void frmLogin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            LinearGradientBrush myBrush = new LinearGradientBrush(ClientRectangle, Color.LightSkyBlue, Color.White, LinearGradientMode.Vertical);
            g.FillRectangle(myBrush, ClientRectangle);
        }
       
        private void lbpwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbUserName.Text))
            {
                MessageBoxEx.Error(@"登录名不能为空，请重新输入！");
                cmbUserName.Focus();
                cmbUserName.SelectAll();
            }
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        #endregion
    }
}