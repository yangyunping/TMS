using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Global;
using GoldenLady.Standard;

namespace GoldenLady.SMSNew
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            CheckUserPower();
        }

        private void btnSendSms_Click(object sender, EventArgs e)
        {
            frmSendSms fss = new frmSendSms();
            fss.Show();
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            if (Information.CurrentUser.EmployeeDuty == "Duty_18" || Information.CurrentUser.EmployeeDepartmentNO == "Administrators")
            {
                frmOption fo = new frmOption();
                fo.ShowDialog();
            }
            else
            {
                MessageBox.Show("该功能你无权限！", "权限", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch fs = new frmSearch();
            fs.ShowDialog();
        }

        private void CheckUserPower()
        {
            btnOption.Enabled = Information.CurrentUser.UserPower.Contains(Powers.短信.短信模板设置);
            btnSendSms.Enabled = Information.CurrentUser.UserPower.Contains(Powers.短信.短信发送);
        }
    }
}
