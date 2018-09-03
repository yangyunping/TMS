using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmSmallGoods : Form
    {
        public FrmSmallGoods()
        {
            InitializeComponent();
            DgvColumns();
            DataTable dtDressConfig = ErpService.DressManagement.GetDressConfigType().Tables[0];
            cmbConfigType.DataSource = dtDressConfig;
            cmbConfigType.DisplayMember = @"ConfigType";
            cmbConfigType.ValueMember = @"ID";
            cmbConfigType.SelectedIndex = -1;
        }

        private void DgvColumns()
        {
            dgvConfig.Columns.AddRange(
                new DataGridViewTextBoxColumn() { Name = @"ID", DataPropertyName = @"ID", HeaderText = @"编号", Width = 100 },
                new DataGridViewTextBoxColumn() { Name = @"ConfigValue", DataPropertyName = @"ConfigValue", HeaderText = @"名称", Width = 150 }
                );
        }

        private void cmbConfigType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvConfig.DataSource = null;
            if (string.IsNullOrEmpty(cmbConfigType.Text))
            {
                return;
            }
            DataTable dtConfig = ErpService.DressManagement.GetSmallGoods(cmbConfigType.Text).Tables[0];
            dgvConfig.AutoGenerateColumns = false;
            dgvConfig.DataSource = dtConfig;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvConfig.CurrentRow != null)
            {
                if (MessageBox.Show(@"确认删除？",@"提示！",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (ErpService.DressManagement.DeleteDressConfig(dgvConfig.CurrentRow.Cells["ID"].Value.ToString(),
                        dgvConfig.CurrentRow.Cells["ConfigValue"].Value.ToString()))
                    {
                        MessageBox.Show(@"删除成功！");
                        dgvConfig.Rows.Remove(dgvConfig.CurrentRow);
                    }
                    else
                    {
                        MessageBox.Show(@"删除失败，检查后重试！");
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbConfigType.Text) || string.IsNullOrEmpty(txtNewConfig.Text))
            {
                MessageBox.Show(@"请填写完整需要添加的信息");
                return;
            }
            if (ErpService.DressManagement.AddDressConfig(cmbConfigType.Text,txtNewConfig.Text))
            {
                MessageBox.Show(@"添加成功！");
                txtNewConfig.Clear();
                cmbConfigType_SelectedIndexChanged(null,null);
            }
            else
            {
                MessageBox.Show(@"添加失败，检查后重试！");
            }
        }

        private void txtNewConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(null, null);
            }
        }
    }
}
