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
    public partial class FrmOperateEmp : Form
    {
        Service ErpWs = new Service();
        private Action<string> _empId;
        public FrmOperateEmp(Action<string> operateEmp)
        {
            InitializeComponent();
            DataSet dataSet = ErpWs.SearchEmployee(string.Format(@" and  DepartmentNO = '{0}'", Information.CurrentUser.EmployeeDepartmentNO));
            cmbEmp.DataSource = dataSet.Tables[0];
            cmbEmp.DisplayMember = "EmployeeName";
            cmbEmp.ValueMember = "EmployeeNO";
            _empId = operateEmp;
        }

        private void cmbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_empId != null)
            {
                _empId(cmbEmp.SelectedValue.ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
