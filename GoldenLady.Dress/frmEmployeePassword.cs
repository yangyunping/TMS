using System;
using System.Windows.Forms;
using GoldenLady.Global;
using GoldenLady.Global.Exception;
using GoldenLady.Standard;
using GoldenLadyWS;

namespace GoldenLady.Dress
{
    /// <summary>
    /// Redesign By: LiuHaiyang
    /// Date: 2016.12.6
    /// LastUpdate By:
    /// LastUpdateDate:
    /// </summary>
    public partial class frmEmployeePassword : Form
    {
        #region Constructors

        public frmEmployeePassword() { InitializeComponent(); }

        #endregion

        #region Methods

        private void Process()
        {
            string strPwd1 = txtPassword1.Text.Trim();
            string strPwd2 = txtPassword2.Text.Trim();
            if(!strPwd1.IsValidPassword())
                throw AccountException.PasswordInvalid;
            if(0 != StringComparer.CurrentCulture.Compare(strPwd1, strPwd2))
                throw AccountException.PasswordRepeatNotMatch;
            if(!ErpService.CompanyManagement.UpdateEmployeePassword(Information.CurrentUser.EmployeeNO, strPwd1))
                throw AccountException.ChangePasswordFailed;
            MessageBox.Show(@"修改密码成功！");
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region Event Handlers

        private void btnCancel_Click(object sender, EventArgs e) { DialogResult = DialogResult.Cancel; }
        private void btnOK_Click(object sender, EventArgs e) 
        {
            try
            {
                Process();
            }
            catch(AccountException ex)
            {
                MessageBox.Show(ex.Message);
                switch(ex.ExeptionType)
                {
                    case AccountExeptionType.PasswordInvalid:
                    case AccountExeptionType.PasswordRepeatNotMatch:
                    case AccountExeptionType.ChangePasswordFailed:
                    {
                        txtPassword1.Focus();
                        txtPassword1.SelectAll();
                        break;
                    }
                    case AccountExeptionType.UserNameNotExists:
                    case AccountExeptionType.PasswordNotMatch:
                    case AccountExeptionType.AccountInvalid:
                    case AccountExeptionType.NeedChangePassword:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        private void txtPassword1_Enter(object sender, EventArgs e) { txtPassword1.SelectAll(); }
        private void txtPassword2_Enter(object sender, EventArgs e) { txtPassword2.SelectAll(); }

        #endregion
    }
}