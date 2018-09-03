using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoldenLady.SMSNew
{
    public partial class frmAddAi : Form
    {
        public frmAddAi()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAi.Text.Trim().Length == 0)
            {
                MessageBox.Show("类别名称不能为空！");
                txtAi.Focus();
                return;
            }

            GoldenLadyWS.Service serivce = new GoldenLadyWS.Service();
            bool flag = true;
            string sql = "insert into SMSAi (name,forwarddays,sendtime) Values ('" + txtAi.Text.Trim() + "',0,'00:00:00')";
            if (serivce.ExecuteCommandText(sql) <= 0)
            {
                flag = false;
            }
            int newid = Convert.ToInt32(serivce.GetDataSet("select MAX(id) from SMSAi").Tables[0].Rows[0][0].ToString());
            sql = "insert into SMSUsefulExpressions (id,content1) values (" + newid + ",'" + txtUsefulExpressions1.Text.Trim() + "')";
            if (serivce.ExecuteCommandText(sql) <= 0)
            {
                flag = false;
            }
            if (flag)
            {
                MessageBox.Show("添加成功！");
                this.DialogResult = DialogResult.Yes;
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
