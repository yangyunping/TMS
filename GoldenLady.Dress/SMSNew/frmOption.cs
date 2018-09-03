using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoldenLady.SMSNew
{
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
            ControlStatus(false);
            for (int i = 0; i <= 23; i++)
            {
                cmbHH.Items.Add(i.ToString("00"));
            }
            cmbHH.SelectedIndex = 0;
            for (int i = 0; i <= 59; i++)
            {
                cmbMM.Items.Add(i.ToString("00"));
            }
            cmbMM.SelectedIndex = 0;
        }
        DataSet myds = new DataSet();
        string id = "";
        private void frmOption_Load(object sender, EventArgs e)
        {
            GoldenLadyWS.Service service = new GoldenLadyWS.Service();
            //string Sql = " select su.id as '编号', name as '通知类别',content1 as '自定义短语1',content2 as '自定义短语2',forwarddays as '提前通知天数',sendtime as '发送时间' from SMSAi sa,SMSUsefulExpressions su where sa.id=su.id";
            string Sql = " select su.id as id, name,content1,forwarddays,sendtime from SMSAi sa,SMSUsefulExpressions su where sa.id=su.id";
            myds = service.GetDataSet(Sql);
            dgv.DataSource = myds.Tables[0];
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                int id=Convert.ToInt32( dgv.Rows[i].Cells["编号"].Value.ToString());
                if (id >= 1 && id <= 6)
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }

                //2013-01-07 qiuqianquan
                string name = dgv.Rows[i].Cells["通知类别"].Value.ToString().Trim();
                if (name == "选片预约提醒" || name == "取件预约提醒" || name == "看版预约提醒" || name == "看版取消提醒" || name == "选片取消提醒" || name == "取件取消提醒" || name == "摄影取消提醒" || name == "摄影预约提醒")
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//摄影取消提醒
                }
            }
        }

        void ControlStatus(bool flag)//控件状态
        {
            btnUpdate.Enabled = flag;
            btnDelete.Enabled = flag;
        }

        int selectIndex = 0;//选中的行数

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectIndex = e.RowIndex;
            int x;
            x = dgv.CurrentCell.RowIndex;
            txtAi.Text = dgv.Rows[x].Cells["通知类别"].Value.ToString();
            txtUsefulExpressions1.Text = dgv.Rows[x].Cells["自定义短语"].Value.ToString();
            //txtUsefulExpressions2.Text = dgv.Rows[x].Cells["自定义短语2"].Value.ToString();
            cmbForwardDays.Text = dgv.Rows[x].Cells["提前通知天数"].Value.ToString();
            //dtpSendTime.Text = dgv.Rows[x].Cells["发送时间"].Value.ToString();
            cmbHH.Text = dgv.Rows[x].Cells["发送时间"].Value.ToString().Substring(0, 2);
            cmbMM.Text = dgv.Rows[x].Cells["发送时间"].Value.ToString().Substring(3,2);
            id = dgv.Rows[x].Cells["编号"].Value.ToString();
            int tempid = Convert.ToInt32(id);
            if (tempid >= 1 && tempid <= 6)
            {
                txtAi.ReadOnly = true;
                cmbForwardDays.Enabled = true;
                //dtpSendTime.Enabled = true;
                cmbHH.Enabled = true;
                cmbMM.Enabled = true;
            }
            else
            {
                txtAi.ReadOnly = false;
                cmbForwardDays.Enabled = false;
                //dtpSendTime.Enabled = false;
                cmbHH.Enabled = false;
                cmbMM.Enabled = false;
            }

            //2013-01-07 qiuqianquan
            string name = dgv.Rows[x].Cells["通知类别"].Value.ToString().Trim();
            if (name == "选片预约提醒" || name == "取件预约提醒" || name == "看版预约提醒" || name == "看版取消提醒" || name == "选片取消提醒" || name == "取件取消提醒" | name == "摄影取消提醒" || name == "摄影预约提醒")
            {
                txtAi.ReadOnly = true;
                cmbForwardDays.Visible = true;
                cmbHH.Visible = true;
                cmbMM.Visible = true;
                btnDelete.Enabled = false;
            }


            ControlStatus(true);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAi.Text.Trim().Length == 0)
            {
                MessageBox.Show("类别名称不能为空！");
                txtAi.Focus();
                return;
            }

            if (cmbHH.Text.Length == 1)
            {
                cmbHH.Text = "0" + cmbHH.Text;
            }
            if (cmbMM.Text.Length == 1)
            {
                cmbMM.Text = "0" + cmbMM.Text;
            }

            string sql = "update SMSAi set name='"+txtAi.Text.Trim()+"',forwarddays=" + Convert.ToInt32(cmbForwardDays.Text) + ",sendtime='"+cmbHH.Text+":"+cmbMM.Text+":00"+"' where id=" + Convert.ToInt32(id);
            bool flag = true;
            GoldenLadyWS.Service serivce = new GoldenLadyWS.Service();
            if (serivce.ExecuteCommandText(sql) <= 0)
            {
                flag = false;
            }
            sql = "update SMSUsefulExpressions set content1='"+txtUsefulExpressions1.Text.Trim()+"' where id=" + Convert.ToInt32(id);
            if (serivce.ExecuteCommandText(sql) <= 0)
            {
                flag = false;
            }
            if (flag)
            {
                MessageBox.Show("修改成功！");
                frmOption_Load(null, null);
                dgv.ClearSelection();
                dgv.Rows[selectIndex].Selected = true;

            }
            else
            {
                MessageBox.Show("修改失败！！");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            GoldenLadyWS.Service service = new GoldenLadyWS.Service();
            //int Id = Convert.ToInt32(id);
            for (int i = 0; i < dgv.SelectedRows.Count; i++)
            {

                string sql = "delete from SMSAi where id=" + Convert.ToInt32(dgv.SelectedRows[i].Cells[0].Value.ToString());
                if (Convert.ToInt32(dgv.SelectedRows[i].Cells["编号"].Value) < 7)
                {
                    continue;
                }
                if (service.ExecuteCommandText(sql) <= 0)
                {
                    MessageBox.Show("删除失败！");
                }
            }
            frmOption_Load(null, null);//刷新
            dgv.ClearSelection();
            dgv.Rows[dgv.Rows.Count - 1].Selected = true;
        }

        private void cmbForwardDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)008)
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbForwardDays_TextChanged(object sender, EventArgs e)
        {
            if (cmbForwardDays.Text.Trim().Length == 0)
            {
                cmbForwardDays.Text = "0";
            }
        }

        private void lkbAdd_Click(object sender, EventArgs e)
        {
            frmAddAi faa = new frmAddAi();
            if (faa.ShowDialog() == DialogResult.Yes)
            {
                frmOption_Load(null, null);
                dgv.ClearSelection();
                dgv.Rows[dgv.Rows.Count - 1].Selected = true;
            }
        }

        private void txtUsefulExpressions1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                btnUpdate_Click(null, null);
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            btnDelete_Click(null, null);
        }

        private void cmbHH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)008)
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbMM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)008)
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbHH_TextChanged(object sender, EventArgs e)
        {
            if (cmbHH.Text == "")
            {
                cmbHH.Text = "00";
            }
            if(Convert.ToInt32(cmbHH.Text)>24)
            {
                cmbHH.Text = "23";
            }
        }

        private void cmbMM_TextChanged(object sender, EventArgs e)
        {
            if (cmbMM.Text == "")
            {
                cmbMM.Text = "00";
            }
            if (Convert.ToInt32(cmbMM.Text) > 59)
            {
                cmbMM.Text = "59";
            }
        }

    }
}