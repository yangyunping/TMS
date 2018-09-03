using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Global;
using GoldenLady.Standard.Dress;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmTemplate : Form
    {
        Service ErpWs = new Service();
        public FrmTemplate()
        {
            InitializeComponent();
            IniteData();
        }

        private void IniteData()
        {
            cmbAddress.DataSource = DressManager.GetRules().Where(p => !string.IsNullOrEmpty(p.Tag) && p.ParentRuleNo == RuleStandard.金夫人总店编号).ToList();
            cmbAddress.DisplayMember = @"Name";
            cmbAddress.ValueMember = @"BindingNo";
        }

        private void cmbAddress_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAddress.Text))
            {
                return;
            }
            string sqlString = string.Empty;
            if (!string.IsNullOrEmpty(cmbAddress.SelectedValue.ToString()))
            {
                sqlString = @" and DepartmentNO = '" + cmbAddress.SelectedValue.ToString() + "'";
            }
            DataSet dataSet = ErpWs.SearchEmployee(sqlString);
            cmbEmpDress.DataSource = dataSet.Tables[0];
            cmbEmpDress.DisplayMember = "EmployeeName";
            cmbEmpDress.ValueMember = "EmployeeNO";
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            txtEmp.Text += cmbEmpDress.Text + @",";
        }

        private void btnSee_Click(object sender, EventArgs e)
        {
            dgvShow.Rows.Clear();
            dgvShow.Columns.Clear();
            lblDateArea.Text = dtpBegin.Value.ToShortDateString()+@"  —  "+dtpEnd.Value.ToShortDateString();
            if (string.IsNullOrEmpty(txtEmp.Text))
            {
                MessageBox.Show(@"请选择员工！");
                return;
            }
            string[] columnName = txtEmp.Text.Remove(txtEmp.Text.LastIndexOf(',')).Split(',');
           
            for (int i = 0; i < columnName.Length; i++)
            {
                dgvShow.Columns.Add(columnName[i], columnName[i]);
                dgvShow.Columns[i].SortMode  = DataGridViewColumnSortMode.NotSortable;
                dgvShow.Columns[i].Width = 150;
            }
            dgvShow.ColumnHeadersHeight = 50;
            dgvShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvShow.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            string[] rowName = txtRowCnt.Text.Split(',');
            dgvShow.Rows.Add(rowName.Length);
            dgvShow.RowHeadersWidth = 50;
            for (int j = 0; j < rowName.Length; j++)
            {
                dgvShow.Rows[j].HeaderCell.Value = rowName[j];
                dgvShow.Rows[j].Height = 120;
            }
            lblSum.Text = @"可排数量：" + columnName.Length*rowName.Length;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmp.Text) || string.IsNullOrEmpty(txtRowCnt.Text) || string.IsNullOrEmpty(cmbAddress.Text))
            {
                MessageBox.Show(@"请把模板信息添加完整！");
                return;
            }
            if (ErpService.DressManagement.InsertDressControlTable(cmbAddress.SelectedValue.ToString(), dtpBegin.Value, dtpEnd.Value, txtEmp.Text.Remove(txtEmp.Text.LastIndexOf(',')), txtRowCnt.Text, Information.CurrentUser.EmployeeNO2, cmbAddress.Text))
            {
                MessageBox.Show(@"保存成功！");
            }
            else
            {
                MessageBox.Show(@"保存失败，请检查后重试");
            }
        }

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.Value = dtpBegin.Value;
            DataTable dtTable = ErpService.DressManagement.GetRentColTable(cmbAddress.SelectedValue.ToString(),dtpBegin.Value.ToShortDateString()).Tables[0];
            if (dtTable.Rows.Count>0)
            {
                MessageBox.Show(@"该日期已有模板，如需更改可继续操作！无需请谨慎操作！");
                dtTable.Dispose();
                return;
            }
            dtTable.Dispose();
        }
    }
}
