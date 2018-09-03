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
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmPowerEmp : UserControl
    {
        Service ErpWs = new Service();
        public FrmPowerEmp()
        {
            InitializeComponent();
            DgvColumn();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //dgvEmp.Columns.Clear();
            if (txtKeys.Text == string.Empty)
            {
                MessageBox.Show(@"不能无条件查询！");
                return;
            }
            string sSql = string.Format("  and (EmployeeNO like '%{0}%' or EmployeeNO2 like '%{0}%' or  EmployeeName like '%{0}%') ", txtKeys.Text);
            DataTable dtTable = ErpWs.SearchEmployee(sSql).Tables[0];
            dgvEmp.AutoGenerateColumns = false;
            dgvEmp.DataSource = dtTable;
        }

        private void DgvColumn()
        {
            dgvEmp.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"DepartmentNO", DataPropertyName = @"DepartmentNO", HeaderText = @"部门编号", Width = 120 },
                new DataGridViewTextBoxColumn { Name = @"DepartmentName", DataPropertyName = @"DepartmentName", HeaderText = @"部门名称", Width = 120 },
                new DataGridViewTextBoxColumn { Name = @"EmployeeNO", DataPropertyName = @"EmployeeNO", HeaderText = @"员工编号", Width = 120 },
                new DataGridViewTextBoxColumn { Name = @"EmployeeNO2", DataPropertyName = @"EmployeeNO2", HeaderText = @"员工编号2", Width = 120 },
                new DataGridViewTextBoxColumn { Name = @"EmployeeName", DataPropertyName = @"EmployeeName", HeaderText = @"员工姓名", Width = 120 },
                new DataGridViewTextBoxColumn { Name = @"EmployeeDuty", DataPropertyName = @"EmployeeDuty", HeaderText = @"职位", Width = 120 }
                );
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dgvEmp.CurrentRow == null)
            {
                return;
            }
            frmEmployee frmEmployee = new frmEmployee(dgvEmp.CurrentRow.Cells["EmployeeNO"].Value.ToString(), 0);
            frmEmployee.ShowDialog();
        }

        private void txtKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void 修改权限ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnChange_Click(null,null);
        }
    }
}
