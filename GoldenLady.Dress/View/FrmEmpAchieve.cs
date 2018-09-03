using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Standard.Dress;
using GoldenLadyWS;

namespace GoldenLady.Dress
{
    public partial class FrmEmpAchieve : UserControl
    {
        public FrmEmpAchieve()
        {
            InitializeComponent();
            IniteData();
        }

        private void IniteData()
        {
            cmbVenue.DataSource = DressManager.GetVenues().ToList();
            cmbVenue.DisplayMember = @"Name";
            cmbVenue.ValueMember = @"DepartmentNo";
            cmbVenue.SelectedIndex = -1;

            dgvCnt.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"DressEmployeeNO", DataPropertyName = @"DressEmployeeNO", HeaderText = @"员工编号", Width = 150 },
                 new DataGridViewTextBoxColumn { Name = @"DressEmployeeName", DataPropertyName = @"DressEmployeeName", HeaderText = @"员工姓名", Width = 150 },
                  new DataGridViewTextBoxColumn { Name = @"DressBarSum", DataPropertyName = @"DressBarSum", HeaderText = @"礼服数量", Width = 150 }
                );
        }

        private void btnDressSearch_Click(object sender, EventArgs e)
        {
            string sSql = string.Empty;
            if (chkChooseDress.Checked)
            {
                sSql += " and (DATEDIFF(dd,CreateDate,'" + dtpDressBegin.Value +
                        "') <= 0 and DATEDIFF(dd,CreateDate,'" + dtpDressEnd.Value + "') >= 0) ";
            }
            if (!String.IsNullOrEmpty(cmbVenue.Text))
            {
                sSql += @" and  OperateDepartmentNO = '" + ((Venue)cmbVenue.SelectedItem).DepartmentNo + "' ";
            }
            if (!string.IsNullOrEmpty(cmbDressEmp.Text))
            {
                sSql += @"  and  DressEmployeeNO = '" + cmbDressEmp.SelectedValue + "' ";
            }
            dgvCnt.AutoGenerateColumns = false;
            DataTable dt = ErpService.DressManagement.GetEmpDressAchieve(sSql).Tables[0];
            dgvCnt.DataSource = dt;
            dt.Dispose();
        }

        private void cmbVenue_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbVenue.SelectedValue == null)
            {
                return;
            }
            DataTable stTable = ErpService.DressManagement.GetDressEmp(((Venue)cmbVenue.SelectedItem).DepartmentNo).Tables[0];
            cmbDressEmp.DataSource = stTable;
            cmbDressEmp.DisplayMember = @"EmployeeName";
            cmbDressEmp.ValueMember = @"EmployeeNO2";
            cmbDressEmp.SelectedIndex = -1;
        }
    }
}
