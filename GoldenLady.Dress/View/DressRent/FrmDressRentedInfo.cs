using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmDressRentedInfo : UserControl
    {
        private string _imagePath;
        private string _operateEmpId;
        Service ErpWs = new Service();
        public FrmDressRentedInfo()
        {
            InitializeComponent();

            DataSet dataSet =
                ErpWs.SearchEmployee(string.Format(@" and  DepartmentNO = '{0}'",
                    Information.CurrentUser.EmployeeDepartmentNO));
            DataTable newTable = dataSet.Tables[0];
            DataRow drRow = newTable.NewRow();
            drRow["EmployeeName"] = "全部";
            drRow["EmployeeNO"] = "0";
            newTable.Rows.InsertAt(drRow, 0);
            cmbDresserss.DataSource = newTable;
            cmbDresserss.DisplayMember = "EmployeeName";
            cmbDresserss.ValueMember = "EmployeeNO";
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            dgvOrders.Columns.Clear();
            string sSql = string.Empty;
            if (chktake.Checked)
            {
                sSql +=
                    string.Format(
                        @"  and (DATEDIFF(dd,takeDressTime,'{0}') <= 0 and DATEDIFF(dd,takeDressTime,'{1}') >= 0)",
                        dtpTakeBegin.Value, dtpTakeEnd.Value);
            }
            if (chkMarry.Checked)
            {
                sSql +=
                    string.Format(
                        @"  and  (DATEDIFF(dd,marryDtaTime,'{0}') <= 0 and DATEDIFF(dd,marryDtaTime,'{1}') >= 0) ",
                        dtpMarryBegin.Value, dtpMarryEnd.Value);
            }
            if (chkBack.Checked)
            {
                sSql +=
                    string.Format(
                        @"  and  (DATEDIFF(dd,returnDressTime,'{0}') <= 0 and DATEDIFF(dd,returnDressTime,'{1}') >= 0) ",
                        dtpReurnBegin.Value, dtpReurnEnd.Value);
            }
            if (rbBntCus.Checked)
            {
                DgvCustColumns();
                if (!cmbDresserss.Text.Trim().Equals(@"全部"))
                {
                    sSql += string.Format(@"  and  (b.DressStylist = '{0}' or  b.DressStylist = '{1}')",
                        cmbDresserss.SelectedValue, cmbDresserss.Text);
                }
                if (!string.IsNullOrEmpty(txbKey.Text))
                {
                    sSql +=
                        string.Format(
                            @" and (b.OrderNO = '{0}'  or a.batchNum = '{0}' or c.CustomerName1 = '{0}' or c.CustomerName2 = '{0}' or MobilePhone1 = '{0}' or MobilePhone2 = '{0}') ",
                            txbKey.Text);
                }
                if (string.IsNullOrEmpty(sSql))
                {
                    MessageBox.Show(@"无条件查询容易卡死软件");
                    return;
                }
                DataTable dtOrders = ErpService.DressManagement.GetRentCutomers(sSql).Tables[0];
                dgvOrders.AutoGenerateColumns = false;
                dgvOrders.DataSource = dtOrders;
                lblSum.Text = @"顾客数量：" + dtOrders.Rows.Count;
                dtOrders.Dispose();
            }
            else if (rbBntDress.Checked)
            {
                DgvDressColumns();
                if (!cmbDresserss.Text.Trim().Equals(@"全部"))
                {
                    sSql += string.Format(@"  and  (DressStylist = '{0}'  or  DressStylist = '{1}')",
                        cmbDresserss.SelectedValue, cmbDresserss.Text);
                }
                if (!string.IsNullOrEmpty(txbKey.Text))
                {
                    sSql +=
                        string.Format(
                            @" and (b.OrderNO = '{0}'  or a.DressBarCode = '{0}' or c.CustomerName1 = '{0}' or c.CustomerName2 = '{0}' or MobilePhone1 = '{0}' or MobilePhone2 = '{0}') ",
                            txbKey.Text);
                }
                DataTable dtDresses = ErpService.DressManagement.GetRenDresses(sSql).Tables[0];
                dgvOrders.AutoGenerateColumns = false;
                dgvOrders.DataSource = dtDresses;
                lblSum.Text = @"礼服数量：" + dtDresses.Rows.Count;
                dtDresses.Dispose();
            }
        }

        private void DgvCustColumns()
        {
            dgvOrders.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = @"OrderNO",
                    HeaderText = @"订单号",
                    DataPropertyName = @"OrderNO",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"OrderState",
                    HeaderText = @"状态",
                    DataPropertyName = @"OrderState",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"CustomerName1",
                    HeaderText = @"先生",
                    DataPropertyName = @"CustomerName1",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"CustomerName2",
                    HeaderText = @"小姐",
                    DataPropertyName = @"CustomerName2",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"MobilePhone1",
                    HeaderText = @"电话1",
                    DataPropertyName = @"MobilePhone1",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"MobilePhone2",
                    HeaderText = @"电话2",
                    DataPropertyName = @"MobilePhone2",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"takeDressTime",
                    HeaderText = @"取衣时间",
                    DataPropertyName = @"takeDressTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"marryDtaTime",
                    HeaderText = @"结婚时间",
                    DataPropertyName = @"marryDtaTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"returnDressTime",
                    HeaderText = @"还衣时间",
                    DataPropertyName = @"returnDressTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"DressStylist",
                    HeaderText = @"礼服师",
                    DataPropertyName = @"DressStylist",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"ArriveTime",
                    HeaderText = @"成交时间",
                    DataPropertyName = @"ArriveTime",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"Dress_ChooseRemak",
                    HeaderText = @"备注",
                    DataPropertyName = @"Dress_ChooseRemak",
                    Width = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"batchNum",
                    HeaderText = @"批号",
                    DataPropertyName = @"batchNum",
                    Width = 120
                }
                );
        }

        private void DgvDressColumns()
        {
            dgvOrders.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = @"dressBarCode",
                    HeaderText = @"礼服条码",
                    DataPropertyName = @"dressBarCode",
                    Width = 110
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"RuleName",
                    HeaderText = @"小类",
                    DataPropertyName = @"RuleName",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"CustomerName1",
                    HeaderText = @"先生",
                    DataPropertyName = @"CustomerName1",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"MobilePhone1",
                    HeaderText = @"电话1",
                    DataPropertyName = @"MobilePhone1",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"CustomerName2",
                    HeaderText = @"小姐",
                    DataPropertyName = @"CustomerName2",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"MobilePhone2",
                    HeaderText = @"电话2",
                    DataPropertyName = @"MobilePhone2",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"takeDressTime",
                    HeaderText = @"取衣时间",
                    DataPropertyName = @"takeDressTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"marryDtaTime",
                    HeaderText = @"结婚时间",
                    DataPropertyName = @"marryDtaTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"returnDressTime",
                    HeaderText = @"还衣时间",
                    DataPropertyName = @"returnDressTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"DressCustomCode",
                    HeaderText = @"自编号",
                    DataPropertyName = @"DressCustomCode",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"DressStylist",
                    HeaderText = @"礼服师",
                    DataPropertyName = @"DressStylist",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"remarks",
                    HeaderText = @"单件备注",
                    DataPropertyName = @"remarks",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"Notes",
                    HeaderText = @"总备注",
                    DataPropertyName = @"Notes",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"DressCompany",
                    HeaderText = @"伴娘服",
                    DataPropertyName = @"DressCompany",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"DressStatus",
                    HeaderText = @"礼服状态",
                    DataPropertyName = @"DressStatus",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"batchNum",
                    HeaderText = @"批号",
                    DataPropertyName = @"batchNum",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"OutOperate",
                    HeaderText = @"出件人",
                    DataPropertyName = @"OutOperate",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"OutOperatoerTime",
                    HeaderText = @"出件时间",
                    DataPropertyName = @"OutOperatoerTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"inOperate",
                    HeaderText = @"回件人",
                    DataPropertyName = @"inOperate",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"BackOperatorTime",
                    HeaderText = @"回件时间",
                    DataPropertyName = @"BackOperatorTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"SallType",
                    HeaderText = @"销售类别",
                    DataPropertyName = @"SallType",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"RentOfPrice",
                    HeaderText = @"出租价钱",
                    DataPropertyName = @"RentOfPrice",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"SaleOfPrice",
                    HeaderText = @"出售价钱",
                    DataPropertyName = @"SaleOfPrice",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"OperateTime",
                    HeaderText = @"创建时间",
                    DataPropertyName = @"OperateTime",
                    Width = 100
                }
                );
        }

        private void dgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvOrders.DataSource == null || dgvOrders.Rows.Count == 0 || rbBntDress.Checked || !rbBntCus.Checked)
                {
                    return;
                }
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.Cells["OrderState"].Value.Equals(@"出件"))
                    {
                        row.DefaultCellStyle.BackColor = Color.BurlyWood;
                    }
                    if (row.Cells["OrderState"].Value.Equals(@"回件"))
                    {
                        row.DefaultCellStyle.BackColor = Color.Pink;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            picImage.Image = null;
            if (dgvOrders.CurrentRow != null && rbBntDress.Checked)
            {
                删除tsm.Enabled =
                    dgvOrders.CurrentRow.Cells["DressStylist"].Value.ToString()
                        .Equals(Information.CurrentUser.EmployeeName);
                if (Information.CurrentUser.EmployeeDuty.Equals(@"Duty_22") ||
                    Information.CurrentUser.EmployeeNO2.Equals(@"admin2"))
                {
                    删除tsm.Enabled = true;
                }
                string dressBarcode = dgvOrders.CurrentRow.Cells["DressBarCode"].Value.ToString();
                DataSet dsSet = ErpService.DressManagement.GetDressSearchInformation(dressBarcode);
                _imagePath = dsSet.Tables[0].Rows[0]["DressImagePath"].SafeDbValue<string>();
                if (string.IsNullOrEmpty(_imagePath))
                {
                    MessageBox.Show(@"该礼服没有照片");
                    return;
                }
                string[] pathInfo = _imagePath.Split(Convert.ToChar(@"\"));
                Ping strPing = new Ping();
                PingReply pingReply = strPing.Send(pathInfo[2]);
                if (pingReply != null && pingReply.Status != IPStatus.Success)
                {
                    MessageBox.Show(@"无法访问照片路径！");
                    return;
                }
                picImage.Image = FileTool.ReadImageFile(_imagePath).ZoomImage(picImage.Size, true, Color.LightGray);
                dsSet.Dispose();
            }
        }

        private void rbBntCus_CheckedChanged(object sender, EventArgs e)
        {
            dgvOrders.Columns.Clear();
            if (rbBntCus.Checked)
            {
                回件Tsm.Enabled = 出件Tsm.Enabled = true;
                出租入库ToolStripMenuItem.Enabled =
                    礼服记录查询ToolStripMenuItem.Enabled = 打印Tsm.Enabled = 修改单件备注Tsm.Enabled = btnPrint.Enabled = false;
            }
        }

        private List<RentDressesInfo> _dressCustinfos;
        private List<string> _batchList;
        private int _index = 0;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _dressCustinfos = new List<RentDressesInfo>();
            _batchList = new List<string>();
            DataTable newTable = null;
            if (!rbBntDress.Checked)
            {
                MessageBox.Show(@"请选择礼服查询后打印！");
                return;
            }
            if (chkAll.Checked)
            {
                newTable = dgvOrders.DataSource as DataTable;
            }
            else
            {
                if (dgvOrders.CurrentRow != null)
                {
                    DataTable dtShow = dgvOrders.DataSource as DataTable;
                    if (dtShow != null)
                    {
                        newTable = dtShow.Select(string.Format(@"batchNum = '{0}'",
                            dgvOrders.CurrentRow.Cells["batchNum"].Value)).CopyToDataTable();
                    }
                }
            }
            if (newTable == null)
            {
                MessageBox.Show(@"没有打印信息！");
                return;
            }
            for (int i = 0; i < newTable.Rows.Count; i++)
            {
                string batch = newTable.Rows[i]["batchNum"].ToString();
                if (_batchList.Contains(batch))
                {
                    continue;
                }
                RentDressesInfo rentDressesInfo = new RentDressesInfo();
                rentDressesInfo.Batch = batch;
                _batchList.Add(batch);
                rentDressesInfo.Address = Information.CurrentUser.CompanyBM;
                rentDressesInfo.CustomerName = newTable.Rows[i]["CustomerName2"].ToString();
                rentDressesInfo.Department = Information.CurrentUser.EmployeeDepartmentName;
                rentDressesInfo.DressStylist = newTable.Rows[i]["DressStylist"].ToString();
                rentDressesInfo.MarryDate = newTable.Rows[i]["marryDtaTime"].ToString();
                rentDressesInfo.Notes = newTable.Rows[i]["Notes"].ToString();
                rentDressesInfo.Phone = newTable.Rows[i]["MobilePhone2"].ToString();
                rentDressesInfo.Dresses = new List<List<string>>();
                for (int j = 0; j < newTable.Rows.Count; j++)
                {
                    if (newTable.Rows[j]["batchNum"].ToString() == rentDressesInfo.Batch)
                    {
                        List<string> dressList = new List<string>();
                        dressList.Add(newTable.Rows[j]["dressBarCode"].ToString());
                        dressList.Add(newTable.Rows[j]["RuleName"].ToString());
                        dressList.Add(newTable.Rows[j]["DressCustomCode"].ToString());
                        dressList.Add(newTable.Rows[j]["remarks"].ToString());
                        rentDressesInfo.Dresses.Add(dressList);
                    }
                }
                if (!_dressCustinfos.Contains(rentDressesInfo))
                {
                    _dressCustinfos.Add(rentDressesInfo);
                }
            }
            for (int i = 0; i < _dressCustinfos.Count; i++)
            {
                _index = i;
                PrintPreviewDialog printView = new PrintPreviewDialog();
                printView.Document = printDocument1;
                printView.ShowDialog();
            }
            _dressCustinfos.Clear();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font f = new Font("宋体", 20, FontStyle.Bold);
            Font f2 = new Font("宋体", 9);
            Font f3 = new Font("宋体", 13);
            Brush b = Brushes.Black;
            Image img = Properties.Resources.printTable;
            e.Graphics.DrawImage(img, 0, 0, 340, 385);
            e.Graphics.DrawString("中国金夫人(" + _dressCustinfos[_index].Address + ")", f, b, 60, 12);
            e.Graphics.DrawString(_dressCustinfos[_index].Department, f2, b, 260, 30);
            e.Graphics.DrawString("新娘", f3, b, 6, 55);
            e.Graphics.DrawString(_dressCustinfos[_index].CustomerName, f2, b, 80, 60);
            e.Graphics.DrawString("电话", f3, b, 178, 55);
            e.Graphics.DrawString(_dressCustinfos[_index].Phone, f2, b, 240, 60);
            e.Graphics.DrawString("捧花", f3, b, 6, 90);
            e.Graphics.DrawString(@"0", f2, b, 80, 95);
            e.Graphics.DrawString("婚期", f3, b, 179, 90);
            e.Graphics.DrawString(_dressCustinfos[_index].MarryDate, f2, b, 240, 93);
            e.Graphics.DrawString("总备注", f3, b, 1, 309);
            e.Graphics.DrawString(_dressCustinfos[_index].Notes, f2, b, 60, 312);
            e.Graphics.DrawString("金额", f3, b, 11, 354);
            e.Graphics.DrawString("00.00", f2, b, 70, 360);
            e.Graphics.DrawString("礼服师", f3, b, 172, 354);
            e.Graphics.DrawString(_dressCustinfos[_index].DressStylist, f2, b, 250, 357);

            for (int i = 0; i < _dressCustinfos[_index].Dresses.Count; i++)
            {
                GraphicsPrint(e.Graphics, _dressCustinfos[_index].Dresses[i][1], _dressCustinfos[_index].Dresses[i][0], _dressCustinfos[_index].Dresses[i][2] + @"  " + _dressCustinfos[_index].Dresses[i][3], i + 1);
            }
        }
        public void GraphicsPrint(Graphics g, string type, string barcode, string remark, int i)
        {
            Font f2 = new Font("宋体", 9);
            Brush b = Brushes.Black;
            switch (i)
            {
                case 1:
                    g.DrawString(type, f2, b, 11, 124);
                    g.DrawString(barcode, f2, b, 70, 124);
                    g.DrawString(remark, f2, b, 170, 124);
                    return;
                case 2: //37
                    g.DrawString(type, f2, b, 11, 153);
                    g.DrawString(barcode, f2, b, 70, 153);
                    g.DrawString(remark, f2, b, 170, 153);
                    return;
                case 3://40
                    g.DrawString(type, f2, b, 11, 183);
                    g.DrawString(barcode, f2, b, 70, 183);
                    g.DrawString(remark, f2, b, 170, 183);
                    return;
                case 4://40
                    g.DrawString(type, f2, b, 11, 213);
                    g.DrawString(barcode, f2, b, 70, 213);
                    g.DrawString(remark, f2, b, 170, 213);
                    return;
                case 5://37
                    g.DrawString(type, f2, b, 11, 243);
                    g.DrawString(barcode, f2, b, 70, 243);
                    g.DrawString(remark, f2, b, 170, 243);
                    return;
                case 6://40
                    g.DrawString(type, f2, b, 11, 273);
                    g.DrawString(barcode, f2, b, 70, 273);
                    g.DrawString(remark, f2, b, 170, 273);
                    return;
            }
        }
        private void rbBntDress_CheckedChanged(object sender, EventArgs e)
        {
            dgvOrders.Columns.Clear();
            if (rbBntDress.Checked)
            {
                回件Tsm.Enabled = 出件Tsm.Enabled = false;
                出租入库ToolStripMenuItem.Enabled = 礼服记录查询ToolStripMenuItem.Enabled = 打印Tsm.Enabled = 修改单件备注Tsm.Enabled = btnPrint.Enabled = true;
            }
        }

        private void 修改备注Tsm_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null && rbBntDress.Checked) //礼服总备注
            {
                FrmAddRemark frmAddRemark = new FrmAddRemark(null, dgvOrders.CurrentRow.Cells["batchNum"].Value.ToString(), null, dgvOrders.CurrentRow.Cells["Notes"].Value.ToString());
                frmAddRemark.ShowDialog();
            }
            if (dgvOrders.CurrentRow != null && rbBntCus.Checked)//排单备注
            {
                FrmAddRemark frmAddRemark = new FrmAddRemark(dgvOrders.CurrentRow.Cells["OrderNO"].Value.ToString(), null, null, dgvOrders.CurrentRow.Cells["Dress_ChooseRemak"].Value.ToString());
                frmAddRemark.ShowDialog();
            }
        }

        private void 打印Tsm_Click(object sender, EventArgs e)
        {
            btnPrint_Click(null, null);
        }

        private void 新增礼服Tsm_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                MessageBox.Show(@"请选择需要添加的顾客！");
                return;
            }
            List<string> orderInfo = new List<string>();
            orderInfo.Add(dgvOrders.CurrentRow.Cells["batchNum"].Value.ToString());
            orderInfo.Add(dgvOrders.CurrentRow.Cells["takeDressTime"].Value.ToString());
            orderInfo.Add(dgvOrders.CurrentRow.Cells["marryDtaTime"].Value.ToString());
            orderInfo.Add(dgvOrders.CurrentRow.Cells["returnDressTime"].Value.ToString());
            orderInfo.Add(dgvOrders.CurrentRow.Cells["CustomerName1"].Value.ToString());
            orderInfo.Add(dgvOrders.CurrentRow.Cells["CustomerName2"].Value.ToString());
            orderInfo.Add(dgvOrders.CurrentRow.Cells["DressStylist"].Value.ToString());
            FrmDressAdd frmDressAdd = new FrmDressAdd(orderInfo);
            frmDressAdd.ShowDialog();
            btnSeach_Click(null, null);
        }

        private void 删除礼服tsm_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null)
            {
                return;
            }
            if (MessageBox.Show(@"请谨慎操作，再次确定后删除！", @"提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (ErpService.DressManagement.DressRentDelete(dgvOrders.CurrentRow.Cells["batchNum"].Value.ToString(), dgvOrders.CurrentRow.Cells["dressBarCode"].Value.ToString(), Information.CurrentUser.EmployeeNO2))
                {
                    MessageBox.Show(@"删除成功");
                    dgvOrders.Rows.Remove(dgvOrders.CurrentRow);
                }
            }
        }

        private void 出件Tsm_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null && rbBntCus.Checked)
            {
                string dressbarcodes = String.Empty;
                DataTable dtDresses =
                    ErpService.DressManagement.GetCustoRentDresses(dgvOrders.CurrentRow.Cells["batchNum"].Value.ToString())
                        .Tables[0];
                for (int i = 0; i < dtDresses.Rows.Count; i++)
                {
                    dressbarcodes += @"'" + dtDresses.Rows[i]["dressBarCode"] + @"',";
                }
                FrmOperateEmp frmOperateEmp = new FrmOperateEmp(new Action<string>(p => _operateEmpId = p));
                frmOperateEmp.ShowDialog();
                if (ErpService.DressManagement.UpdateRentOut(dgvOrders.CurrentRow.Cells["OrderNO"].Value.ToString(), dgvOrders.CurrentRow.Cells["batchNum"].Value.ToString(), dressbarcodes.Remove(dressbarcodes.LastIndexOf(',')), _operateEmpId, Information.CurrentUser.EmployeeNO2))
                {
                    MessageBox.Show(@"出件成功");
                    dgvOrders.CurrentRow.Cells["OrderState"].Value = @"出件";
                }
                dtDresses.Dispose();
            }
            else
            {
                MessageBox.Show(@"请选择需要操作的顾客！");
            }
        }

        private void 回件Tsm_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null && rbBntCus.Checked)
            {
                string dressbarcodes = String.Empty;
                DataTable dtDresses =
                    ErpService.DressManagement.GetCustoRentDresses(dgvOrders.CurrentRow.Cells["batchNum"].Value.ToString())
                        .Tables[0];
                for (int i = 0; i < dtDresses.Rows.Count; i++)
                {
                    dressbarcodes += @"'" + dtDresses.Rows[i]["dressBarCode"] + @"',";
                }
                FrmOperateEmp frmOperateEmp = new FrmOperateEmp(new Action<string>(p => _operateEmpId = p));
                frmOperateEmp.ShowDialog();
                if (ErpService.DressManagement.UpdateRentBack(dgvOrders.CurrentRow.Cells["OrderNO"].Value.ToString(), dgvOrders.CurrentRow.Cells["batchNum"].Value.ToString(), dressbarcodes.Remove(dressbarcodes.LastIndexOf(',')), _operateEmpId, Information.CurrentUser.EmployeeNO2))
                {
                    MessageBox.Show(@"回件成功");
                    dgvOrders.CurrentRow.Cells["OrderState"].Value = @"回件";
                }
                dtDresses.Dispose();
            }
            else
            {
                MessageBox.Show(@"请选择需要操作的顾客！");
            }
        }

        private void 出租入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                string dressBarCode = dgvOrders.CurrentRow.Cells["DressBarCode"].Value.ToString();
                string state = dgvOrders.CurrentRow.Cells["DressStatus"].Value.ToString();
                Dictionary<string, string> dressInfo = new Dictionary<string, string>()
                {
                    {dressBarCode,state}
                };
                if (state == @"出租入库")
                {
                    MessageBox.Show(@"该礼服已入库");
                    return;
                }
                if (ErpService.DressManagement.UpdateDressState(dressInfo, @"出租入库",
                    Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO2))
                {
                    foreach (DataGridViewRow row in dgvOrders.Rows.Cast<DataGridViewRow>().Where(row => row.Cells["DressBarCode"].Value.ToString() == dressBarCode))
                    {
                        row.Cells["DressStatus"].Value = @"出租入库";
                    }
                    MessageBox.Show(@"出租入库成功！");
                }
                else
                {
                    MessageBox.Show(@"入库失败，请重试！");
                }
            }
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            FrmExampleShow frmExampleShow = new FrmExampleShow(_imagePath, 0);
            frmExampleShow.ShowDialog();
        }

        private void 礼服记录查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                FrmDressHistory frmDressHistory = new FrmDressHistory(dgvOrders.CurrentRow.Cells["dressBarCode"].Value.ToString());
                frmDressHistory.ShowDialog();
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

        private void 修改单件备注Tsm_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null && rbBntDress.Checked) //礼服单件备注
            {
                FrmAddRemark frmAddRemark = new FrmAddRemark(null, dgvOrders.CurrentRow.Cells["batchNum"].Value.ToString(), dgvOrders.CurrentRow.Cells["DressBarCode"].Value.ToString(), dgvOrders.CurrentRow.Cells["remarks"].Value.ToString());
                frmAddRemark.ShowDialog();
            }
        }

        private void txbKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSeach_Click(null, null);
            }
        }
    }
}
