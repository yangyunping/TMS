using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmDressRentChoose : Form
    {
        private readonly string _orderInfo;
        Service ErpWs = new Service();
        public FrmDressRentChoose(string information)
        {
            InitializeComponent();
            _orderInfo = information;
            IniteData();
        }

        List<string> _areaList = new List<string>();
        private void IniteData()
        {
            DataTable dsStyle = ErpService.DressManagement.GetDressStyle(RuleStandard.类别.ToString()).Tables[0];
            DataRow drRow = dsStyle.NewRow();
            drRow["RuleName"] = "全部";
            drRow["RuleNumbers"] = "-1";
            dsStyle.Rows.InsertAt(drRow, 0);
            cmbParentStyle.DisplayMember = @"RuleName";
            cmbParentStyle.ValueMember = @"RuleNumbers";
            cmbParentStyle.DataSource = dsStyle;

            DataTable dsArea = ErpService.DressManagement.GetDressStyle(RuleStandard.嫁衣馆区域编号).Tables[0];
            DataRow drArea = dsArea.NewRow();
            drArea["RuleName"] = "全部";
            drArea["RuleNumbers"] = "-1";
            dsArea.Rows.InsertAt(drArea, 0);
            cmbArea.DataSource = dsArea;
            cmbArea.DisplayMember = @"RuleName";
            cmbArea.ValueMember = @"RuleNumbers";
            cmbArea.SelectedIndex = -1;

            DataTable dtUseaAge = ErpService.DressManagement.GetSmallGoods(@"出租用途").Tables[0];
            cmbHireUseFor.DataSource = dtUseaAge;
            cmbHireUseFor.DisplayMember = @"ConfigValue";
            cmbHireUseFor.ValueMember = @"ID";
            cmbHireUseFor.SelectedIndex = -1;

            DataSet dataSet = ErpWs.SearchEmployee(string.Format(@" and  DepartmentNO = '{0}'", Information.CurrentUser.EmployeeDepartmentNO));
            cmbDresserss.DataSource = dataSet.Tables[0];
            cmbDresserss.DisplayMember = "EmployeeName";
            cmbDresserss.ValueMember = "EmployeeNO";
            cmbDresserss.SelectedIndex = -1;

            for (int i = 0; i < dsArea.Rows.Count; i++)
            {
                _areaList.Add(dsArea.Rows[i]["RuleNumbers"].SafeDbValue<string>());
            }
            AllKindsData.ChoosedDressInfo = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(_orderInfo))
            {
                return;
            }
            txtOrderNO.Text = _orderInfo.Split(',')[0];
            lblManName.Text = _orderInfo.Split(',')[2];
            lblWname.Text = _orderInfo.Split(',')[3];
            txtMoblePhone1.Text = _orderInfo.Split(',')[4];
            txtMoblePhone2.Text = _orderInfo.Split(',')[5];
            dtpMarryDate.Value = _orderInfo.Split(',')[7].SafeDbDateTime();
            DataTable dtTable = ErpService.DressManagement.GetRentedDressImage(_orderInfo.Split(',')[0]).Tables[0];
            if (dtTable.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow row in dtTable.Rows)
            {
                string choosedDressBarCode = row["DressBarCode"].SafeDbValue<string>();
                string batchNum = row["batchNum"].SafeDbValue<string>();
                string imagePath = row["DressImagePath"].SafeDbValue<string>();
                decimal rentPrice = row["DressRentPrice"].SafeDbValue<decimal>();
                decimal saleprice = row["DressSalePrice"].SafeDbValue<decimal>();
                string dressCustomCode = row["DressCustomCode"].SafeDbValue<string>();
                if (string.IsNullOrEmpty(imagePath))
                {
                    continue;
                }
                imgChoosed.Images.Add(choosedDressBarCode,
                FileTool.ReadImageFile(imagePath).ZoomImage(imgChoosed.ImageSize, true, Color.LightGray));
                ListViewItem lst = new ListViewItem
                {
                    ImageKey = choosedDressBarCode,
                    Name = choosedDressBarCode,
                    Text = dressCustomCode + @"_" + choosedDressBarCode,
                    Tag = imagePath + @"," + rentPrice + @"," + saleprice + @"," + batchNum,
                };
                if (AllKindsData.ChoosedDressInfo == null)
                {
                    AllKindsData.ChoosedDressInfo = new Dictionary<string, string>();
                }
                if (!AllKindsData.ChoosedDressInfo.ContainsKey(choosedDressBarCode))
                {
                    AllKindsData.ChoosedDressInfo.Add(choosedDressBarCode, imagePath);
                }
                lvwChoosed.BeginUpdate();
                lvwChoosed.Items.Add(lst);
                lvwChoosed.EndUpdate();
            }
            dtTable.Dispose();
        }

        private Task task;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lvwAll.Items.Clear();
            lvwAll.LargeImageList.Images.Clear();
            imgAll.Images.Clear();
            string parentType = string.Empty, type = string.Empty;//大类 小类
            if (string.IsNullOrEmpty(txtDressBarCode.Text) && string.IsNullOrEmpty(cmbParentStyle.Text) &&
                string.IsNullOrEmpty(cmbStyle.Text) && string.IsNullOrEmpty(cmbArea.Text))
            {
                MessageBox.Show(@"无条件查询容易造成软件卡死");
                return;
            }
            string areaStr = string.Empty;
            if (!string.IsNullOrEmpty(cmbArea.Text) && !cmbArea.Text.Equals("全部")) 
            {
                areaStr = string.Format("  and info.area in('{0}')", cmbArea.SelectedValue.ToString());
            }
            string keys = @" and DressStatus != '淘汰' and DressStatus !='出售' and DressStatus !='丢失' and  info.guanmin = '金纱嫁衣馆'";
            if (!string.IsNullOrEmpty(txtDressBarCode.Text))
            {
                keys += string.Format(@" and  info.DressBarCode = '{0}'", txtDressBarCode.Text);
            }

            if (!string.IsNullOrEmpty(cmbParentStyle.Text) && !cmbParentStyle.Text.Trim().Equals(@"全部"))
            {
                parentType = string.Format(@" and  ds.DressName= '{0}' ", cmbParentStyle.SelectedValue);
            }
            if (!string.IsNullOrEmpty(cmbStyle.Text) && !cmbStyle.Text.Trim().Equals(@"全部"))
            {
                type = string.Format(@" and  ds.DressCategories= '{0}' ", cmbStyle.SelectedValue);
            }

            DataTable drTable =
                ErpService.DressManagement.GetDressesImage(dtpTakeDate.Value, dtpReturnDate.Value, parentType, type,
                    areaStr, keys, chkAll.Checked).Tables[0];
            if (drTable.Rows.Count == 0)
            {
                MessageBox.Show(@"没有查到该礼服信息，请检查状态后重试！"); 
                return;
            }

            AllKindsData.ImgPathLst = new List<string>();
            btnSearch.Enabled = false;
            task =  Task.Factory.StartNew(() => Methods.AllShow(drTable, lvwAll));
        }
     
        private void cmbParentStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbParentStyle.Text == String.Empty)
            {
                return;
            }
            DataTable dsTable =
                ErpService.DressManagement.GetDressStyle(cmbParentStyle.SelectedValue.ToString()).Tables[0];
            cmbStyle.DataSource = dsTable;
            cmbStyle.DisplayMember = @"RuleName";
            cmbStyle.ValueMember = @"RuleNumbers";
            cmbStyle.SelectedIndex = -1;
        }

        public void GetCustomer()
        {
            string keys = string.Empty;
            if (string.IsNullOrEmpty(txtOrderNO.Text) && string.IsNullOrEmpty(txtMoblePhone1.Text) &&
                string.IsNullOrEmpty(txtMoblePhone2.Text))
            {
                MessageBox.Show(@"请输入顾客必要的查询信息！");
                return;
            }
            if (!string.IsNullOrEmpty(txtOrderNO.Text))
            {
                keys += string.Format(@" and OrderNO = '{0}'", txtOrderNO.Text);
            }
            if (!string.IsNullOrEmpty(txtMoblePhone1.Text))
            {
                keys += string.Format(@" and MobilePhone1 = '{0}'", txtMoblePhone1.Text);
            }
            if (!string.IsNullOrEmpty(txtMoblePhone2.Text))
            {
                keys += string.Format(@" and MobilePhone2 = '{0}'", txtMoblePhone2.Text);
            }
            DataTable dtCustomer = ErpService.DressManagement.GetOrderCustomer(keys).Tables[0];
            if (dtCustomer.Rows.Count == 0)
            {
                MessageBox.Show(@"没有查询到客人，检查查询条件！");
                return;
            }
            txtOrderNO.Text = dtCustomer.Rows[0]["OrderNO"].SafeDbValue<string>();
            lblManName.Text = dtCustomer.Rows[0]["CustomerName1"].SafeDbValue<string>();
            txtMoblePhone1.Text = dtCustomer.Rows[0]["MobilePhone1"].SafeDbValue<string>();
            lblWname.Text = dtCustomer.Rows[0]["CustomerName2"].SafeDbValue<string>();
            txtMoblePhone2.Text = dtCustomer.Rows[0]["MobilePhone2"].SafeDbValue<string>();
        }

        private void txtOrderNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetCustomer();
            }
        }

        private void txtMoblePhone1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetCustomer();
            }
        }

        private void txtMoblePhone2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetCustomer();
            }
        }

        private void lvwAll_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string choosedDressBarCode = lvwAll.SelectedItems[0].Name;
            string[] infoStrings = lvwAll.SelectedItems[0].Tag.ToString().Split(',');
            string imagePath = infoStrings[0];
            string rentPrice = infoStrings[1];
            string salePrice = infoStrings[2];
            imgChoosed.Images.Add(choosedDressBarCode,
                FileTool.ReadImageFile(imagePath).ZoomImage(imgChoosed.ImageSize, true, Color.LightGray));
            ListViewItem lst = new ListViewItem
            {
                ImageKey = choosedDressBarCode,
                Tag = lvwAll.SelectedItems[0].Tag.ToString(),
                Name = choosedDressBarCode,
                Text = lvwAll.SelectedItems[0].Text
            };

            if (!ErpService.DressManagement.InsertPreChoosed(txtOrderNO.Text, choosedDressBarCode, dtpTakeDate.Value, dtpMarryDate.Value, dtpReturnDate.Value, txtRemark.Text, Convert.ToDecimal(rentPrice), Convert.ToDecimal(salePrice), Information.CurrentUser.EmployeeNO2))
            {
                MessageBox.Show(@"加入购物车失败！");
                return;
            }
            if (AllKindsData.ChoosedDressInfo == null)
            {
                AllKindsData.ChoosedDressInfo = new Dictionary<string, string>();
            }
            if (!AllKindsData.ChoosedDressInfo.ContainsKey(choosedDressBarCode))
            {
                AllKindsData.ChoosedDressInfo.Add(choosedDressBarCode, imagePath);
            }
            lblDressUnitPrice.Text = rentPrice;
            lblAllPrice.Text =
                (Convert.ToDecimal(lblAllPrice.Text) + Convert.ToDecimal(rentPrice)).ToString(
                    CultureInfo.InvariantCulture);
            lvwChoosed.BeginUpdate();
            lvwChoosed.Items.Add(lst);
            lvwChoosed.EndUpdate();
            lvwChoosed.Refresh();
            lvwAll.Items.RemoveByKey(choosedDressBarCode);
            lvwAll.Refresh();
        }

        private void lvwAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Methods.PhotoLarge(lvwAll);
            }
        }

        private void lvwChoosed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Methods.PhotoLarge(lvwChoosed);
            }
        }

        private void lvwChoosed_DoubleClick(object sender, EventArgs e)
        {
            if (lvwChoosed.SelectedItems.Count > 0)
            {
                string dressbarcode = lvwChoosed.SelectedItems[0].Name;
                string rentPrice = lvwChoosed.SelectedItems[0].Tag.ToString().Split(',')[1];
                lblAllPrice.Text =
                    (Convert.ToDecimal(lblAllPrice.Text) - Convert.ToDecimal(rentPrice)).ToString(
                        CultureInfo.InvariantCulture);

                if (!ErpService.DressManagement.DeleteChoosed(txtOrderNO.Text, dressbarcode, Information.CurrentUser.EmployeeNO2))
                {
                    MessageBox.Show(@"购物车删除失败！");
                    return;
                }
                AllKindsData.ChoosedDressInfo.Remove(dressbarcode);
                lvwChoosed.Items.RemoveByKey(dressbarcode);
                lvwChoosed.Refresh();
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOrderNO.Text) || string.IsNullOrEmpty(txtMoblePhone1.Text + txtMoblePhone2.Text) ||
                string.IsNullOrEmpty(lblManName.Text + lblWname.Text))
            {
                MessageBox.Show(@"请录入客人信息！");
                return;
            }
            if (string.IsNullOrEmpty(cmbDresserss.Text))
            {
                MessageBox.Show(@"请选择礼服师！");
                return;
            }
            if (ErpService.DressManagement.UpdateDressRentFinish(txtOrderNO.Text, cmbHireUseFor.Text, txtRemark.Text, Information.CurrentUser.EmployeeNO2, cmbDresserss.Text))
            {
                MessageBox.Show(@"选衣操作完成");
                this.Close();
            }
            else
            {
                MessageBox.Show(@"选衣操作失败，请重试！");
            }
        }

        private void btnAddCost_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOrderNO.Text))
            {
                string info = txtOrderNO.Text + @"," + lblManName.Text + @"," + lblWname.Text + @"," +
                              txtMoblePhone1.Text + @"," + txtMoblePhone2.Text;
                FrmAddCost frmAddCost = new FrmAddCost(info);
                frmAddCost.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"订单号无效！");
            }
        }

        private void lvwChoosed_Click(object sender, EventArgs e)
        {
            if (lvwChoosed.SelectedItems.Count > 0)
            {
                lblDressUnitPrice.Text = lvwChoosed.SelectedItems[0].Tag.ToString().Split(',')[1];
            }
        }

        private void lvwAll_Click(object sender, EventArgs e)
        {
            if (lvwAll.SelectedItems.Count > 0)
            {
                lblDressUnitPrice.Text = lvwAll.SelectedItems[0].Tag.ToString().Split(',')[1];
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreview = new PrintPreviewDialog() { Document = printDocument1 };
            printPreview.ShowDialog();
        }
        void DrawFunction(string msg, int x, int y, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fnt = new Font(new FontFamily("黑体"), 11);
            Brush brs = Brushes.Black;
            e.Graphics.DrawString(msg, fnt, brs, x, y);
        }
        //#region
        //        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //        {
        //            try
        //            {
        //                int x = 0;
        //                int y = 20;//纵坐标
        //                int p = 20;//间距
        //                int j = 0;
        //                int spaceX = 350;
        //                DrawFunction("礼服出租清单●" + Information.Company.CompanyChinese + "●" + Information.CurrentUser.EmployeeDepartmentName, 20, y, e);
        //                y += p;
        //                DrawFunction("".PadLeft(98, '-'), 20, y, e);
        //                y += p;
        //                DrawFunction(@"客户姓名：" + lblManName.Text + @" " + lblWname.Text, 20, y, e);
        //                DrawFunction("联系电话：" + txtMoblePhone1.Text + @"  " + txtMoblePhone2.Text, spaceX, y, e);
        //                y += p;
        //                DrawFunction("礼服师：" + Information.CurrentUser.EmployeeName, 20, y, e);
        //                //DrawFunction("捧花：" + cmbFlower.Text, spaceX, y, e);
        //                y += p;
        //                DrawFunction("结婚日期：" + dtpMarryDate.Value.ToShortDateString(), 20, y, e);
        //                DrawFunction("取衣日期：" + dtpTakeDate.Value.ToShortDateString(), spaceX, y, e);
        //                DrawFunction("还衣日期：" + dtpReturnDate.Value.ToShortDateString(), spaceX + 200, y, e);
        //                y += p;

        //                DrawFunction("操作人员：" + Information.CurrentUser.EmployeeName, 20, y, e);
        //                DrawFunction("操作时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), spaceX, y, e);
        //                y += p;
        //                DrawFunction("".PadLeft(98, '-'), 20, y, e);
        //                y += p;

        //                foreach (var dress in AllKindsData.ChoosedDressInfo)
        //                {
        //                    if (j % 5 == 0 && j != 0)
        //                    {
        //                        x = 120;
        //                        y += 160;
        //                        Image imageSmall = FileTool.ReadImageFile(dress.Value.Replace("jpg", "lf"))
        //                            .ZoomImage(100, 130, true, Color.LightGray);
        //                        e.Graphics.DrawImage(imageSmall, new PointF(x, y));
        //                        e.Graphics.DrawString(dress.Key, new Font("宋体", 7), new SolidBrush(Color.Black),
        //                            new PointF(x, y + 140));
        //                        x += 130;
        //                        j++;
        //                    }
        //                    else
        //                    {
        //                        Image imageSmall = FileTool.ReadImageFile(dress.Value.Replace("jpg", "lf"))
        //                            .ZoomImage(100, 130, true, Color.LightGray);
        //                        e.Graphics.DrawImage(imageSmall, new PointF(x, y));
        //                        e.Graphics.DrawString(dress.Key, new Font("宋体", 7), new SolidBrush(Color.Black),
        //                            new PointF(x, y + 140));
        //                        x += 130;
        //                        j++;
        //                    }
        //                }

        //                DrawFunction("客人签字：", spaceX + 150, y + 20, e);
        //                y += p;
        //                DrawFunction("日    期：", spaceX + 150, y + 20, e);

        //            }
        //            catch (Exception ex)
        //            {
        //                SystemFunction.ShowMsg(ex.Message, MessageBoxIcon.Error);
        //            }
        //        }
        //#endregion

        private void dtpMarryDate_ValueChanged(object sender, EventArgs e)
        {
            dtpReturnDate.Value = dtpMarryDate.Value.AddDays(+5);
            dtpTakeDate.Value = dtpMarryDate.Value.AddDays(-5);
        }

        /// <summary>
        /// 礼服单件备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 礼服备注ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwChoosed.SelectedItems.Count > 0)
            {
                FrmAddRemark frmAddRemark = new FrmAddRemark(null, _orderInfo.Split(',')[6], lvwChoosed.SelectedItems[0].Name,null);
                frmAddRemark.ShowDialog();
            }
        }

        private void txtDressBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null,null);
            }
        }
        private void lvwAll_MouseEnter(object sender, EventArgs e)
        {
            if(task == null)
            {
                return;
            }
            while (task != null && task.IsCompleted)
            {
                btnSearch.Enabled = true;
                task = null;
            }
        }

        private void lvwAll_MouseLeave(object sender, EventArgs e)
        {
            if (task == null)
            {
                return;
            }
            while (task != null && task.IsCompleted)
            {
                btnSearch.Enabled = true;
                task = null;
            }
        }
    }
}
