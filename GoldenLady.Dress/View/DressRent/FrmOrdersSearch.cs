using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using GoldenLady.Extension;
using GoldenLady.SMSNew;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmOrdersSearch : UserControl
    {
        public FrmOrdersSearch()
        {
            InitializeComponent();
            DgvColumn();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = string.Empty ;
            dgvOrders.DataSource = null;
             
            if (chkOrder.Checked)
            {
                sSql += string.Format(@" and  (DATEDIFF(dd,OrderDate,'{0}') <= 0 and DATEDIFF(dd,OrderDate,'{1}') >= 0)", dtpOrderDateG.Value.ToShortDateString(), dtpOrderDateE.Value.ToShortDateString());
            }
            if (chkMarry.Checked)
            {
                sSql += string.Format(@" and  (DATEDIFF(dd,MarryDate,'{0}') <= 0 and DATEDIFF(dd,MarryDate,'{1}') >= 0)", dtpMarryDateG.Value.ToShortDateString(), dtpMarryDateE.Value.ToShortDateString());
            }
            if (txtKey.Text != string.Empty)
            {
                sSql += string.Format(@" and (o.OrderNO = '{0}' or cs.CustomerName1 = '{0}' or  cs.CustomerName2 = '{0}' or  cs.MobilePhone1 = '{0}' or cs.MobilePhone2 = '{0}')",txtKey.Text);
            }
            if (string.IsNullOrEmpty(sSql))
            {
                MessageBox.Show(@"无条件查询容易造成软件卡死，请重新操作！");
                return;
            }
            sSql += @" and (st.SuiteTypeNO = 'HS' or st.SuiteTypeNO = 'dress') "; //婚纱类

            DataTable dtTable = ErpService.DressManagement.GetDressRentInfo(sSql).Tables[0];
            dtTable.Columns.Add(@"MarryDateF");
            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                if (dtTable.Rows[i]["MarryDate2"] == null || string.IsNullOrEmpty(dtTable.Rows[i]["MarryDate2"].SafeDbValue<string>()) || dtTable.Rows[i]["MarryDate2"].SafeDbValue<string>() == @"1900-01-01")
                {
                    if (dtTable.Rows[i]["MarryDate"] == null)
                    {
                        dtTable.Rows[i]["MarryDateF"] = @"-";
                    }
                    else
                    {
                        dtTable.Rows[i]["MarryDateF"] = dtTable.Rows[i]["MarryDate"].SafeDbValue<string>();
                    }  
                }
                else
                {
                    dtTable.Rows[i]["MarryDateF"] = dtTable.Rows[i]["MarryDate"].SafeDbValue<string>() + "—" + DateTime.Parse(dtTable.Rows[i]["MarryDate2"].SafeDbValue<string>()).Day;
                }          
            }
            if (dtTable.Rows.Count == 0)
            {
                MessageBox.Show(@"没有数据！");
            }
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = dtTable;
            lblSum.Text = @"显示总数：" + dgvOrders.Rows.Count;
        }
        /// <summary>
        /// 列名加载
        /// </summary>
        private void DgvColumn()
        {
            dgvOrders.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"OrderNO", DataPropertyName = @"OrderNO", HeaderText = @"订单号", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"CustomerName1", DataPropertyName = @"CustomerName1", HeaderText = @"先生", Width = 70 },
                new DataGridViewTextBoxColumn { Name = @"MobilePhone1", DataPropertyName = @"MobilePhone1", HeaderText = @"手机1", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"CustomerName2", DataPropertyName = @"CustomerName2", HeaderText = @"女士", Width = 70 },
                new DataGridViewTextBoxColumn { Name = @"MobilePhone2", DataPropertyName = @"MobilePhone2", HeaderText = @"手机2", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"MarryDateF", DataPropertyName = @"MarryDateF", HeaderText = @"婚期", Width = 120 },
                new DataGridViewTextBoxColumn { Name = @"SuitePrice", DataPropertyName = @"SuitePrice", HeaderText = @"套系价格", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"EmpOrderName", DataPropertyName = @"EmpOrderName", HeaderText = @"门市人员", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"DepartmentName", DataPropertyName = @"DepartmentName", HeaderText = @"门市地点", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"EmpOperteName", DataPropertyName = @"EmpOperteName", HeaderText = @"操作人", Width = 80 },
                new DataGridViewTextBoxColumn { Name = @"Dress_OperatorTime", DataPropertyName = @"Dress_OperatorTime", HeaderText = @"操作时间", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"Dress_ChooseDate", DataPropertyName = @"Dress_ChooseDate", HeaderText = @"选衣时间", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"Dress_ChooseRemak", DataPropertyName = @"Dress_ChooseRemak", HeaderText = @"选衣备注", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"SuiteTypeName", DataPropertyName = @"SuiteTypeName", HeaderText = @"套系名称", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"OrderDate", DataPropertyName = @"OrderDate", HeaderText = @"订单日期", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"PreChooseDate", HeaderText = @"选片时间", DataPropertyName = @"PreChooseDate", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"CustomerNO", DataPropertyName = @"CustomerNO", HeaderText = @"客户编号", Width = 100 }
                    );
            dgvCash.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"CashPretextTypeName", DataPropertyName = @"CashPretextTypeName", HeaderText = @"收银类别", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"CashPretextName", DataPropertyName = @"CashPretextName", HeaderText = @"收银事由", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"Size", DataPropertyName = @"Size", HeaderText = @"套系价格", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"CashWay", DataPropertyName = @"CashWay", HeaderText = @"收款方式", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"CashNumber", DataPropertyName = @"CashNumber", HeaderText = @"收款金额", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"EmployeeName1", DataPropertyName = @"EmployeeName1", HeaderText = @"业绩人员", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"EmployeeName2", DataPropertyName = @"EmployeeName2", HeaderText = @"收银人员", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"CashDate", DataPropertyName = @"CashDate", HeaderText = @"收银时间", Width = 120 }
                );
             dgvMemary.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"OrderNO", DataPropertyName = @"OrderNO", HeaderText = @"订单号", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"EmployeeName", DataPropertyName = @"EmployeeName", HeaderText = @"操作人员", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"Dress_OperatorTime", DataPropertyName = @"Dress_OperatorTime", HeaderText = @"操作时间", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"Dress_TraceRemark", DataPropertyName = @"Dress_TraceRemark", HeaderText = @"操作记录", Width = 150 }
                );
        }

        private void chkOrder_CheckedChanged(object sender, EventArgs e)
        {
            dtpOrderDateG.Enabled = dtpOrderDateE.Enabled = chkOrder.Checked;
        }

        private void chkMarry_CheckedChanged(object sender, EventArgs e)
        {
            dtpMarryDateG.Enabled = dtpMarryDateE.Enabled = chkMarry.Checked;
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string orderNo = string.Empty;
            if (dgvOrders.CurrentRow != null)
            {
                orderNo = dgvOrders.CurrentRow.Cells["orderNO"].Value.ToString();
            }
            if (!string.IsNullOrEmpty(orderNo))
            {
                dgvMemary.DataSource = dgvCash.DataSource = null;
                dgvCash.AutoGenerateColumns = dgvMemary.AutoGenerateColumns = false;

                DataSet dsMemary = ErpService.DressManagement.GetDressRentMemary(" and  OrderNO = '" + orderNo + "'");
                dgvMemary.DataSource = dsMemary.Tables[0];

                DataSet dsCashMemary = ErpService.DressManagement.GetDressCashMemary(" and  OrderNO = '" + orderNo + "'");
                dgvCash.DataSource = dsCashMemary.Tables[0];
            }
        }

        private void 电子排单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                return;
            }
            if (dgvOrders.CurrentRow != null && !string.IsNullOrEmpty(dgvOrders.CurrentRow.Cells["Dress_ChooseDate"].Value.ToString()) &&  !dgvOrders.CurrentRow.Cells["Dress_ChooseDate"].Value.ToString().Contains("1900"))
            {
                MessageBox.Show(@"该订单已排单,已加载到对应的排单显示！");
                frmBasForm frmBasForm = new frmBasForm() { WindowState = FormWindowState.Maximized, Text = @"电子排单" };
                FrmRentList frmRentList = new FrmRentList(DateTime.Parse(dgvOrders.CurrentRow.Cells["Dress_ChooseDate"].Value.ToString()), dgvOrders.CurrentRow.Cells["OrderNO"].Value.ToString()) { Dock = DockStyle.Fill };
                frmBasForm.Controls.Add(frmRentList);
                frmBasForm.ShowDialog();
            }
            else
            {
                frmBasForm frmBasForm = new frmBasForm() { WindowState = FormWindowState.Maximized, Text = @"电子排单" };
                FrmRentList frmRentList = new FrmRentList(dgvOrders.CurrentRow.Cells["OrderNO"].Value.ToString()) { Dock = DockStyle.Fill };
                frmBasForm.Controls.Add(frmRentList);
                frmBasForm.ShowDialog();
            }
            dgvOrders_CellClick(null, null);
        }

        private void 婚期确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                FrmMarryDate frmMarryDate = new FrmMarryDate(dgvOrders.CurrentRow.Cells["CustomerNO"].Value.ToString());
                frmMarryDate.ShowDialog();
                dgvOrders_CellClick(null, null);
            }
        }

        private void 婚期更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                FrmMarryDate frmMarryDate = new FrmMarryDate(dgvOrders.CurrentRow.Cells["CustomerNO"].Value.ToString());
                frmMarryDate.ShowDialog();
                dgvOrders_CellClick(null, null);
            }
        }

        private void 电话追踪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                FrmCallBack frmCallBack = new FrmCallBack(dgvOrders.CurrentRow.Cells["OrderNO"].Value.ToString());
                frmCallBack.ShowDialog();
                dgvOrders_CellClick(null,null);
            }
        }

        private void 短信发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                string moblePhone, customerName, customerNo;
                customerNo = dgvOrders.CurrentRow.Cells["CustomerNO"].Value.ToString();
                if (string.IsNullOrEmpty(dgvOrders.CurrentRow.Cells["CustomerName2"].Value.ToString()))
                {
                    customerName = dgvOrders.CurrentRow.Cells["CustomerName1"].Value.ToString();
                }
                else
                {
                    customerName = dgvOrders.CurrentRow.Cells["CustomerName2"].Value.ToString();
                }
                if (string.IsNullOrEmpty(dgvOrders.CurrentRow.Cells["MobilePhone2"].Value.ToString()))
                {
                    moblePhone = dgvOrders.CurrentRow.Cells["MobilePhone1"].Value.ToString();
                }
                else
                {
                    moblePhone = dgvOrders.CurrentRow.Cells["MobilePhone2"].Value.ToString();
                }
                if (string.IsNullOrEmpty(moblePhone))
                {
                    MessageBox.Show(@"手机号码无效,检查后重试！");
                    return;
                }
                List<string> customerInfo = new List<string>();
                customerInfo.Add(customerNo);
                customerInfo.Add(customerName);
                customerInfo.Add(moblePhone);
                frmSendSms frmSendSms = new frmSendSms(customerInfo);
                frmSendSms.ShowDialog();
            }
        }

        private void 查看排单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null && !string.IsNullOrEmpty(dgvOrders.CurrentRow.Cells["Dress_ChooseDate"].Value.ToString()) && !dgvOrders.CurrentRow.Cells["Dress_ChooseDate"].Value.ToString().Contains("1900"))
            {
                frmBasForm frmBasForm = new frmBasForm() { WindowState = FormWindowState.Maximized, Text = @"电子排单" };
                FrmRentList frmRentList = new FrmRentList(DateTime.Parse(dgvOrders.CurrentRow.Cells["Dress_ChooseDate"].Value.ToString()), dgvOrders.CurrentRow.Cells["OrderNO"].Value.ToString()) { Dock = DockStyle.Fill };
                frmBasForm.Controls.Add(frmRentList);
                frmBasForm.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"没有排单！");
            }
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = @"execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = @"保存为Excel文件";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName.IndexOf(":", StringComparison.Ordinal) < 0) return; //被点了"取消"
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string columnTitle = "";
            try
            {
                //写入列标题
                for (int i = 0; i < dgvOrders.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        columnTitle += "\t";
                    }
                    columnTitle += dgvOrders.Columns[i].HeaderText;
                }
                sw.WriteLine(columnTitle);

                //写入列内容
                for (int j = 0; j < dgvOrders.Rows.Count; j++)
                {
                    string columnValue = "";
                    for (int k = 0; k < dgvOrders.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            columnValue += "\t";
                        }
                        object obj = dgvOrders.Rows[j].Cells[k].Value;
                        if (obj == null)
                            columnValue += "";
                        else
                            columnValue += obj.ToString().Trim().Replace("\t", " ").Replace("\r", " ").Replace("\n", " ");
                    }
                    sw.WriteLine(columnValue);
                }
                sw.Close();
                myStream.Close();
                MessageBox.Show(@"成功将数据导出到EXCEL文件中");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
    }
}
