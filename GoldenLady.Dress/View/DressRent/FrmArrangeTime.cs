using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Global;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmArrangeTime : Form
    {
        private Action<DateTime> _arriveTime;
        private Action<string> _operators;
        Service ErpWs = new Service();
        public FrmArrangeTime(Action<DateTime> arriveTime, Action<string> operators)
        {
            InitializeComponent();
            _arriveTime = arriveTime;
            _operators = operators;

            DataSet dataSet = ErpWs.SearchEmployee(string.Format(@" and  DepartmentNO = '{0}'", Information.CurrentUser.EmployeeDepartmentNO));
            cmbEmp.DataSource = dataSet.Tables[0];
            cmbEmp.DisplayMember = "EmployeeName";
            cmbEmp.ValueMember = "EmployeeNO";
            cmbEmp.SelectedIndex = -1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            if (_arriveTime != null)
            {
                _arriveTime(dtpTime.Value);
            }
        }

        private void cmbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_operators != null)
            {
                _operators(cmbEmp.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
