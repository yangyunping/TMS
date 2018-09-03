using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressChoosedSearch : UserControl
    {
        Service ErpWs = new Service();
        public FrmDressChoosedSearch()
        {
            InitializeComponent();
            Inital();
        }

        private void Inital()
        {
            cmbVenue.DataSource = DressManager.GetVenues().ToList();
            cmbVenue.DisplayMember = @"Name";
            cmbVenue.ValueMember = @"DepartmentNo";
            cmbVenue.SelectedIndex = -1;

            tsmDelete.Visible = Information.CurrentUser.UserPower.Contains(Powers.礼服.礼服管理);
        }

        private void btnDressSearch_Click(object sender, EventArgs e)
        {
            btnCount.Enabled = btnUseCount.Enabled = true;
            dgvDress.DataSource = null;
            dgvDress.Columns.Clear();
            dgvCount.Columns.Clear();
            string sSql = string.Empty;
            if (rnbDress.Checked)
            {
                if (chkChooseDress.Checked)
                {
                    sSql += " and (DATEDIFF(dd,dc.CreateDate,'" + dtpDressBegin.Value +
                            "') <= 0 and DATEDIFF(dd,dc.CreateDate,'" + dtpDressEnd.Value + "') >= 0) ";
                }
                if (chkUse.Checked)
                {
                    sSql += @" and (DATEDIFF(dd,DressUseDate,'" + dtpUseBegin.Value +
                            "') <= 0 and DATEDIFF(dd, DressUseDate,'" +
                            dtpUseEnd.Value + "') >= 0) ";
                }
                if (!String.IsNullOrEmpty(cmbVenue.Text))
                {
                    sSql += @" and  d.DepartmentNo = '" + ((Venue)cmbVenue.SelectedItem).DepartmentNo + "' ";
                }
                if (txtKey.Text != string.Empty)
                {
                    sSql += "  and ( dc.DressBarCode like '%" + txtKey.Text + "%'or CustomerName1 like'%" + txtKey.Text +
                            "%' or MobilePhone1 like '%" +
                            txtKey.Text + "' or CustomerName2 like'%" + txtKey.Text + "%' or MobilePhone2 like '" +
                            txtKey.Text +
                            "%' or  OrderNO like '%" + txtKey.Text + "%' or dc.DressEmployeeName like '%" + txtKey.Text +
                            "%') ";
                }
                if (!string.IsNullOrEmpty(cmbDressEmp.Text) && !cmbDressEmp.Text.Equals(@"全部"))
                {
                    sSql += @"  and  (dc.DressEmployeeNO = '" + cmbDressEmp.SelectedValue + "' or  dc.DressEmployeeName = '" + cmbDressEmp .Text.Trim()+ "')";
                }
                if (sSql == string.Empty)
                {
                    MessageBox.Show(@"不能无条件查询！");
                    return;
                }
                DgvCustomColumnDress();
                DataTable dt = ErpService.DressManagement.SearchDressChoosed(sSql).Tables[0];
                dgvDress.AutoGenerateColumns = false;
                dgvDress.DataSource = dt;
                lblSum.Text = @"礼服总数：" + dt.Rows.Count;
                dt.Dispose();
            }
            else if (rnbScene.Checked)
            {
                if (chkChooseDress.Checked)
                {
                    sSql += " and (DATEDIFF(dd, CreateTime,'" + dtpDressBegin.Value +
                            "') <= 0 and DATEDIFF(dd, CreateTime,'" + dtpDressEnd.Value + "') >= 0) ";
                }
                if (chkUse.Checked)
                {
                    sSql += @" and (DATEDIFF(dd, ShootDate,'" + dtpUseBegin.Value +
                            "') <= 0 and DATEDIFF(dd, ShootDate,'" +
                            dtpUseEnd.Value + "') >= 0) ";
                }
                if (!string.IsNullOrEmpty(cmbDressEmp.Text))
                {
                    sSql += @"  and  DressEmpNO = '" + cmbDressEmp.SelectedValue.ToString() + "' ";
                }
                if (!String.IsNullOrEmpty(cmbVenue.Text))
                {
                    sSql += @" and  DepartmentNo = '" + ((Venue)cmbVenue.SelectedItem).DepartmentNo + "' ";
                }
                DgvCustomColumnScene();
                DataTable dt = ErpService.DressManagement.GetSceneChoosed(null, sSql).Tables[0];
                dgvDress.AutoGenerateColumns = false;
                dgvDress.DataSource = dt;
                lblSum.Text = @"显示总数：" + dt.Rows.Count;
                dt.Dispose();
            }
        }
        /// <summary>
        /// 礼服查询
        /// </summary>
        private void DgvCustomColumnDress()
        {
            dgvDress.Columns.AddRange
                (
                  new DataGridViewTextBoxColumn { Name = "DressBarCode", DataPropertyName = "DressBarCode", HeaderText = @"条码", ReadOnly = true, Width = 120 },
                  new DataGridViewTextBoxColumn { Name = "RuleName", DataPropertyName = "RuleName", HeaderText = @"类别", ReadOnly = true, Width = 70 },
                  new DataGridViewTextBoxColumn { Name = "OrderNO", DataPropertyName = "OrderNO", HeaderText = @"订单号", ReadOnly = true, Width = 130 },
                  new DataGridViewTextBoxColumn { Name = "DepartmentName", DataPropertyName = "DepartmentName", HeaderText = @"拍照场馆", ReadOnly = true, Width = 120 },
                  new DataGridViewTextBoxColumn { Name = "DressUseDate", DataPropertyName = "DressUseDate", HeaderText = @"拍照时间", ReadOnly = true, Width = 120 },
                  new DataGridViewTextBoxColumn { Name = "CustomerName1", DataPropertyName = "CustomerName1", HeaderText = @"先生", ReadOnly = true },
                  new DataGridViewTextBoxColumn { Name = "MobilePhone1", DataPropertyName = "MobilePhone1", HeaderText = @"手机号1", ReadOnly = true, Width = 120 },
                  new DataGridViewTextBoxColumn { Name = "CustomerName2", DataPropertyName = "CustomerName2", HeaderText = @"女士", ReadOnly = true },
                  new DataGridViewTextBoxColumn { Name = "MobilePhone2", DataPropertyName = "MobilePhone2", HeaderText = @"手机号2", ReadOnly = true, Width = 120 },
                  new DataGridViewTextBoxColumn { Name = "DressEmployeeName", DataPropertyName = "DressEmployeeName", HeaderText = @"礼服师", ReadOnly = true },
                  new DataGridViewTextBoxColumn { Name = "CreateDate", DataPropertyName = "CreateDate", HeaderText = @"选衣时间", ReadOnly = true, Width = 120 }
                );
        }
        /// <summary>
        /// 场景查询
        /// </summary>
        private void DgvCustomColumnScene()
        {
            dgvDress.Columns.AddRange
                (
                  new DataGridViewTextBoxColumn { Name = "SceneID", DataPropertyName = "SceneID", HeaderText = @"编号", ReadOnly = true, Width = 70 },
                  new DataGridViewTextBoxColumn { Name = "SceneName", DataPropertyName = "SceneName", HeaderText = @"场景名", ReadOnly = true, Width = 140 },
                  new DataGridViewTextBoxColumn { Name = "OrderNO", DataPropertyName = "OrderNO", HeaderText = @"订单号", ReadOnly = true, Width = 130 },
                  new DataGridViewTextBoxColumn { Name = "ShootDate", DataPropertyName = "ShootDate", HeaderText = @"摄影时间", ReadOnly = true, Width = 120 },
                   new DataGridViewTextBoxColumn { Name = "VenueName", DataPropertyName = "VenueName", HeaderText = @"场馆", ReadOnly = true },
                  new DataGridViewTextBoxColumn { Name = "DressEmpName", DataPropertyName = "DressEmpName", HeaderText = @"礼服师", ReadOnly = true },
                  new DataGridViewTextBoxColumn { Name = "CreateTime", DataPropertyName = "CreateTime", HeaderText = @"选衣时间", ReadOnly = true, Width = 120 }
                );
        }
        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (dgvDress.CurrentRow != null)
            {
                if (rnbDress.Checked)
                {
                    string orderNo = dgvDress.CurrentRow.Cells["OrderNO"].Value.ToString();
                    string dressBarcode = dgvDress.CurrentRow.Cells["DressBarcode"].Value.ToString();
                    string dressUsetime = dgvDress.CurrentRow.Cells["DressUseDate"].Value.ToString();
                    string dressEmployee = dgvDress.CurrentRow.Cells["DressEmployeeName"].Value.ToString();
                    if (ErpService.DressManagement.DeleteDressChoosed(orderNo, dressBarcode, dressEmployee))
                    {
                        dgvDress.Rows.Remove(dgvDress.SelectedRows[0]);
                        ErpWs.SaveLogo(orderNo, "", "", Information.CurrentUser.EmployeeName, "礼服操作",
                            "删除礼服师: " + dressEmployee + " 为顾客所选礼服：" + dressBarcode + "    拍照时间：" + dressUsetime);
                        MessageBox.Show(@"删除成功！");
                    }
                    else
                    {
                        MessageBox.Show(@"删除失败！");
                        return;
                    }
                }
                else if (rnbScene.Checked)
                {
                    //待续。。。
                }
            }
        }

        private void tsmDressPhoto_Click(object sender, EventArgs e)
        {
            if (dgvDress.CurrentRow != null)
            {
                if (rnbDress.Checked)
                {
                    try
                    {
                        if (AllKindsData.ImgPathLst != null)
                        {
                            AllKindsData.ImgPathLst.Clear();
                        }
                        string dressBarcode = dgvDress.CurrentRow.Cells["DressBarCode"].Value.ToString();
                        DataTable dtTable = ErpService.DressManagement.DressesManage(dressBarcode).Tables[0];
                        string imgPath = dtTable.Rows[0]["DressImagePath"].ToString();
                        dtTable.Dispose();
                        if (imgPath == String.Empty)
                        {
                            MessageBox.Show(@"没有照片");
                            return;
                        }
                        new FrmExampleShow(imgPath,0).ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"照片路径无法访问！" + ex);
                        return;
                    }
                }
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            dgvCount.Columns.Clear();

            if (dgvDress.Rows.Count == 0)
            {
                return;
            }
            if (rnbScene.Checked)
            {
                MessageBox.Show(@"场景没有业绩，请选择礼服。");
                return;
            }
            dgvCount.Columns.AddRange
            (
             new DataGridViewTextBoxColumn { Name = "DressEmp", DataPropertyName = "DressEmp", HeaderText = @"礼服师", ReadOnly = true, Width = 100 },
             new DataGridViewTextBoxColumn { Name = "DressCount", DataPropertyName = "DressCount", HeaderText = @"礼服数", ReadOnly = true, Width = 120 }
            );
            foreach (DataGridViewRow drViewRow in dgvDress.Rows)
            {
                if (dgvCount.Rows.Count != 0)
                {
                    var row = drViewRow;
                    foreach (DataGridViewRow drRow in dgvCount.Rows.Cast<DataGridViewRow>().Where(drRow => drRow.Cells[0].Value.ToString() == row.Cells["DressEmployeeName"].Value.ToString()))
                    {
                        drRow.Cells[1].Value = int.Parse(drRow.Cells[1].Value.ToString()) + 1;
                    }
                    if (dgvCount.Rows.Cast<DataGridViewRow>().All(p => p.Cells[0].Value.ToString() != drViewRow.Cells["DressEmployeeName"].Value.ToString()))
                    {
                        int index = dgvCount.Rows.Add();
                        dgvCount.Rows[index].Cells[0].Value = drViewRow.Cells["DressEmployeeName"].Value.ToString();
                        dgvCount.Rows[index].Cells[1].Value = 1;
                    }
                }
                else
                {
                    int index = dgvCount.Rows.Add();
                    dgvCount.Rows[index].Cells[0].Value = drViewRow.Cells["DressEmployeeName"].Value.ToString();
                    dgvCount.Rows[index].Cells[1].Value = 1;
                }
            }
        }

        private void cmbVenue_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbVenue.SelectedValue == null)
            {
                return;
            }
            DataTable stTable = ErpService.DressManagement.GetDressEmp(((Venue)cmbVenue.SelectedItem).DepartmentNo).Tables[0];
            DataRow drRow = stTable.NewRow();
            drRow["EmployeeName"] = "全部";
            drRow["EmployeeNO2"] = "-1";
            stTable.Rows.InsertAt(drRow, 0);
            cmbDressEmp.DataSource = stTable;
            cmbDressEmp.DisplayMember = @"EmployeeName";
            cmbDressEmp.ValueMember = @"EmployeeNO2";
        }

        private void btnUseCount_Click(object sender, EventArgs e)
        {
            dgvCount.Columns.Clear();
            string titleName = string.Empty;
            if (rnbScene.Checked)
            {
                titleName = @"SceneName";
                dgvCount.Columns.AddRange
                (
                  new DataGridViewTextBoxColumn { Name = "Scene", DataPropertyName = "Scene", HeaderText = @"场景名", ReadOnly = true, Width = 140 },
                  new DataGridViewTextBoxColumn { Name = "SceneCount", DataPropertyName = "SceneCount", HeaderText = @"使用次数", ReadOnly = true, Width = 120 }
                );
            }
            else if (rnbDress.Checked)
            {
                titleName = @"DressBarCode";
                dgvCount.Columns.AddRange
                (
                new DataGridViewTextBoxColumn { HeaderText = @"礼服条码", ReadOnly = true, Width = 120 },
                new DataGridViewTextBoxColumn { HeaderText = @"使用次数", ReadOnly = true, Width = 120 }
                );
            }
            foreach (DataGridViewRow drViewRow in dgvDress.Rows)
            {
                if (dgvCount.Rows.Count != 0)
                {
                    var row = drViewRow;
                    foreach (DataGridViewRow drRow in dgvCount.Rows.Cast<DataGridViewRow>().Where(drRow => drRow.Cells[0].Value.ToString() == row.Cells[titleName].Value.ToString()))
                    {
                        drRow.Cells[1].Value = int.Parse(drRow.Cells[1].Value.ToString()) + 1;
                    }
                    if (dgvCount.Rows.Cast<DataGridViewRow>().All(p => p.Cells[0].Value.ToString() != drViewRow.Cells[titleName].Value.ToString()))
                    {
                        int index = dgvCount.Rows.Add();
                        dgvCount.Rows[index].Cells[0].Value = drViewRow.Cells[titleName].Value.ToString();
                        dgvCount.Rows[index].Cells[1].Value = 1;
                    }
                }
                else
                {
                    int index = dgvCount.Rows.Add();
                    dgvCount.Rows[index].Cells[0].Value = drViewRow.Cells[titleName].Value.ToString();
                    dgvCount.Rows[index].Cells[1].Value = 1;
                }
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
                for (int i = 0; i < dgvCount.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        columnTitle += "\t";
                    }
                    columnTitle += dgvCount.Columns[i].HeaderText;
                }
                sw.WriteLine(columnTitle);

                //写入列内容
                for (int j = 0; j < dgvCount.Rows.Count; j++)
                {
                    string columnValue = "";
                    for (int k = 0; k < dgvCount.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            columnValue += "\t";
                        }
                        object obj = dgvCount.Rows[j].Cells[k].Value;
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

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDressSearch_Click(null, null);
            }
        }
    }
}
