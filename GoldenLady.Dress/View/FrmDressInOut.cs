using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressInOut : UserControl
    {
        private string _imgPath = string.Empty;
        Service ErpWs = new Service();
        public FrmDressInOut()
        {
            InitializeComponent();
            chkDate.Enabled = Information.CurrentUser.UserPower.Contains(Powers.礼服.礼服管理);
        }

        private readonly List<string> _dressList = new List<string>(); //当前已录入的礼服
        private string _orderNo = String.Empty, _shootDate = String.Empty, _customerNo = String.Empty, _customerName = String.Empty, _moblePhone = String.Empty, _orderVenueNo = string.Empty; //当前顾客订单信息
        private void txtDressbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string dressBarCode = txtDressbarcode.Text.Trim();
                    DataTable dtDressAllInfo = ErpService.DressManagement.DressesManage(dressBarCode).Tables[0];
                    _imgPath = dtDressAllInfo.Rows[0]["DressImagePath"].ToString(); //照片路径
                    string themeName = dtDressAllInfo.Rows[0]["Themename"].ToString(); //所属风格
                    string dressStatues = dtDressAllInfo.Rows[0]["dressStatus"].ToString();//当前状态
                    int dressEachdayCnt = dtDressAllInfo.Rows[0]["DressNumberOfUsedToday"].SafeDbValue<int>();//日使用次数
                    dtDressAllInfo.Dispose();
                    if (string.IsNullOrEmpty(_imgPath))
                    {
                        MessageBox.Show(@"该礼服没有礼服照片！");
                        return;
                    }
                    if (string.IsNullOrEmpty(themeName))
                    {
                        MessageBox.Show(@"该礼服没有绑定风格，不能加入购物车");
                        return;
                    }

                    if (!chkSmall.Checked)
                    {
                        if (string.IsNullOrEmpty(grbInformation.Text))
                        {
                            MessageBox.Show(@"请选择操作类型！");
                            return;
                        }
                        if (string.IsNullOrEmpty(dressBarCode) || string.IsNullOrEmpty(_shootDate) ||
                            string.IsNullOrEmpty(lblName.Text)
                            || string.IsNullOrEmpty(_orderNo) || string.IsNullOrEmpty(_customerNo) ||
                            string.IsNullOrEmpty(_customerName)
                            || string.IsNullOrEmpty(_moblePhone) || string.IsNullOrEmpty(_orderVenueNo) ||
                            string.IsNullOrEmpty(txtEmpNO.Text))
                        {
                            MessageBox.Show(@"操作失败，请完善员工和顾客的信息!");
                            return;
                        }
                        if (_dressList.Contains(dressBarCode))
                        {
                            MessageBox.Show(@"已操作的条码，请勿重复操作");
                            return;
                        }

                        if (lblStyle.Text == btnout.Text) //礼服出件
                        {
                            DataTable dtDressInfo = ErpService.DressManagement.DressEnableUse(dressBarCode, _shootDate).Tables[0];
                            if (dtDressInfo.Rows.Count == 0)
                            {
                                MessageBox.Show(@"礼服条码或自编码错误或礼服已送洗，检查后重试！");
                                return;
                            }
                            if (Convert.ToInt32(dtDressInfo.Rows[0]["DressRemainCnt"]) == 0)
                            {
                                MessageBox.Show(@"该礼服今天没有使用次数！");
                                return;
                            }
                            if (dressStatues.Equals(DressState.外景出库.ToString()))
                            {
                                MessageBox.Show(@"该礼服已外景出库！");
                                return;
                            }
                            dtDressInfo.Dispose();

                            //礼服取出次数判断是否可用
                            DataTable dtCount = ErpService.DressManagement.GetDressInOut(
                                    string.Format(@" and  dd.DressBarCode = '{0}' and  
                                dd.DressState = '{1}' and  DATEDIFF(dd,dd.OperateTime,GETDATE())= 0", dressBarCode, DressState.取出)).Tables[0];
                            if (dtCount.Rows.Count >= dressEachdayCnt)
                            {
                                MessageBox.Show(@"该礼服取出次数已满！");
                                return;
                            }
                            dtCount.Dispose();

                            if (!ErpService.DressManagement.ChoosedInsert(dressBarCode, _orderNo, txtEmpNO.Text, lblName.Text,
                                    _orderVenueNo, _customerNo, _shootDate, BaseData.DressId))
                            {
                                MessageBox.Show(@"数据库操作失败！");
                                return;
                            }

                            //状态更改
                            Dictionary<string, string> dressInfo = new Dictionary<string, string>
                            {
                                {dressBarCode, dressStatues} //礼服编号+改前状态
                            };
                            if (dressEachdayCnt == 1) //使用次数状态更改
                            {
                                ErpService.DressManagement.UpdateDressState(dressInfo, DressState.外景出库.ToString(),
                                    Information.CurrentUser.EmployeeDepartmentName, txtEmpNO.Text.Trim());
                            }
                            else
                            {
                                ErpService.DressManagement.UpdateDressState(dressInfo, DressState.拍照中.ToString(),
                                    Information.CurrentUser.EmployeeDepartmentName, txtEmpNO.Text.Trim());
                            }

                            if (ErpService.DressManagement.DressOutOperate(dressBarCode, txtEmpNO.Text.Trim(),
                                lblName.Text, btnout.Text.Trim(), _orderVenueNo, lblStyle.Text))
                            {
                                dgvShow.Rows.Add(dressBarCode, @"InOutDressBarCode");
                                _dressList.Add(dressBarCode);
                                txtDressbarcode.Clear();
                            }
                        }
                        else if (lblStyle.Text == btnIn.Text) //礼服入库
                        {
                            if (ErpService.DressManagement.DressInOperate(dressBarCode, txtEmpNO.Text, lblStyle.Text,
                                _orderVenueNo, lblStyle.Text))
                            {
                                dgvShow.Rows.Add(dressBarCode, @"InOutDressBarCode");
                                _dressList.Add(dressBarCode);
                                txtDressbarcode.Clear();
                            }
                            if (!ErpService.DressManagement.DeleteChoosedDress(dressBarCode,
                                @"  and  DressEmployeeNO='" + txtEmpNO.Text + "'", _orderNo,
                                Information.CurrentUser.EmployeeName))
                            {
                                MessageBox.Show(@"已经送进的礼服，到购物车核对是否已删除！");
                                txtDressbarcode.Clear();
                            }
                            //状态更改
                            Dictionary<string, string> dressInfo = new Dictionary<string, string>
                            {
                                {dressBarCode, dressStatues} //礼服编号+改前状态
                            };
                            if (!dressStatues.Equals(DressState.礼服送洗.ToString()))//礼服送洗不改变状态
                            {
                                ErpService.DressManagement.UpdateDressState(dressInfo, DressState.入库.ToString(), lblName.Text, txtEmpNO.Text.Trim());
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"请选择操作类型，如点击取出按钮！");
                            return;
                        }
                    }
                    else if (chkSmall.Checked) //小件出入库
                    {
                        if (string.IsNullOrEmpty(txtEmpNO.Text) || string.IsNullOrEmpty(lblName.Text))
                        {
                            MessageBox.Show(@"请录入员工信息！");
                            return;
                        }
                        if (dtDressAllInfo.Rows.Count == 0)
                        {
                            MessageBox.Show(@"不存在该小件！");
                            return;
                        }

                        if (lblStyle.Text == btnout.Text)
                        {
                            if (ErpService.DressManagement.DressOutOperate(txtDressbarcode.Text, txtEmpNO.Text,
                                lblName.Text,
                                btnout.Text.Trim(), _orderVenueNo, lblStyle.Text))
                            {
                                MessageBox.Show(@"操作成功！");
                                txtDressbarcode.Clear();
                            }
                        }
                        else if (lblStyle.Text == btnIn.Text)
                        {
                            if (ErpService.DressManagement.DressInOperate(txtDressbarcode.Text, txtEmpNO.Text,
                                lblStyle.Text,
                                _orderVenueNo, lblStyle.Text))
                            {
                                MessageBox.Show(@"操作成功！");
                                txtDressbarcode.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"请选择操作类型，如点击取出按钮！");
                            return;
                        }
                        dtDressAllInfo.Dispose();
                    }

                    string[] pathInfo = _imgPath.Split(Convert.ToChar(@"\"));
                    Ping strPing = new Ping();
                    PingReply pingReply = strPing.Send(pathInfo[2]);
                    if (pingReply != null && pingReply.Status != IPStatus.Success)
                    {
                        MessageBox.Show(@"无法访问照片路径！");
                        return;
                    }
                    picImage.Image =
                        FileTool.ReadImageFile(_imgPath.Replace("JPG", "lf").Replace("jpg", "lf"))
                            .ZoomImage(picImage.Size, true, Color.LightGray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            grbInformation.Text = lblStyle.Text = btnout.Text;
            _dressList.Clear();
            picImage.Image = null;
            dgvShow.Columns.Clear();
            dgvShow.DataSource = null;
            dgvShow.Columns.Add(@"InOutDressBarCode", @"取出礼服条码统计");
            dgvShow.Columns[0].Width = 150;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            grbInformation.Text = lblStyle.Text = btnIn.Text;
            _dressList.Clear();
            picImage.Image = null;
            dgvShow.Columns.Clear();
            dgvShow.DataSource = null;
            dgvShow.Columns.Add(@"InOutDressBarCode", @"送进礼服条码统计");
            dgvShow.Columns[0].Width = 150;
        }

        private void DgvColumn()
        {
            dgvShow.Columns.Clear();
            dgvShow.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"DressBarCode", HeaderText = @"礼服条码", DataPropertyName = @"DressBarCode", Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = @"DressState", HeaderText = @"礼服状态", DataPropertyName = @"DressState", Width = 100, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = @"DressEmpNO", HeaderText = @"员工工号", DataPropertyName = @"DressEmpNO", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"DressEmpName", HeaderText = @"员工姓名", DataPropertyName = @"DressEmpName", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"CustomerName1", HeaderText = @"先生", DataPropertyName = @"CustomerName1", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"CustomerName2", HeaderText = @"小姐", DataPropertyName = @"CustomerName2", Width = 100, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"DressUseDate", HeaderText = @"拍照时间", DataPropertyName = @"DressUseDate", Width = 150, ReadOnly = true },
                 new DataGridViewTextBoxColumn { Name = @"OperateTime", HeaderText = @"操作时间", DataPropertyName = @"OperateTime", Width = 150, ReadOnly = true }
                );
        }

        private void btnManageSearch_Click(object sender, EventArgs e)
        {
            _dressList.Clear();
            picImage.Image = null;
            grbInformation.Text = string.Empty;
            lblStyle.Text = btnManageSearch.Text;
            DgvColumn();
            dgvShow.AutoGenerateColumns = false;
            string sSql = string.Empty;
            if (chkDate.Checked)
            {
                sSql += string.Format(@" and DATEDIFF(dd,OperateTime,'{0}')<=0 and DATEDIFF(dd,OperateTime,'{1}')>=0  and DressStatus in('送进','取出')",
                   dtpBegin.Value, dtpEnd.Value);
                DataTable dtTable = ErpService.DressManagement.GetDressInOutLog(sSql, null).Tables[0];
                dgvShow.DataSource = dtTable;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtEmpNO.Text))
                {
                    sSql += string.Format(@" and dd.DressEmpNO = '{0}' ", txtEmpNO.Text);
                }
                if (!string.IsNullOrEmpty(txtDressbarcode.Text))
                {
                    sSql += string.Format(@" and dd.DressBarCode = '{0}' ", txtDressbarcode.Text);
                }
                if (!string.IsNullOrEmpty(cmbMoblePhone.Text))
                {
                    sSql += string.Format(@" and (cs.MobilePhone1 = '{0}' or cs.MobilePhone2 = '{0}') ",
                        cmbMoblePhone.Text);
                }
                DataTable dtTable = ErpService.DressManagement.GetDressInOut(sSql).Tables[0];
                dgvShow.DataSource = dtTable;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    _dressList.Add(dtTable.Rows[i]["DressBarCode"].SafeDbValue<string>());
                }
                dtTable.Dispose();
            }
        }

        private void txtEmpNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _dressList.Clear();
                cmbMoblePhone.Items.Clear();

                DataTable dtTable = ErpWs.SearchEmployee(@" and EmployeeNO2 = '" + txtEmpNO.Text + "'").Tables[0];
                if (dtTable.Rows.Count == 0)
                {
                    MessageBox.Show(@"不存在该员工，可能输入工号有误！");
                    return;
                }
                lblName.Text = dtTable.Rows[0]["EmployeeName"].SafeDbValue<string>();
                dtTable.Dispose();

                DataTable dsDataTable = ErpWs.SearchPreShoot(string.Format(@" and ( (DATEDIFF(dd,PreShootDateN,GETDATE()) <=0 and (DATEDIFF(dd,PreShootDateN,GETDATE()) >=-1) or (DATEDIFF(dd,PreShootDateW,GETDATE()) <=0 and DATEDIFF(dd,PreShootDateW,GETDATE()) >=-1))) and (DressEmployeeN = '{0}' or DressAssistantEmployeeN = '{0}')", lblName.Text.Trim())).Tables[0];
                if (dsDataTable.Rows.Count == 0)
                {
                    MessageBox.Show(@"该化妆师没有对应的客人，请核对后重试！");
                    _customerName = lblCusName.Text = _moblePhone = string.Empty;
                    return;
                }
                else if (dsDataTable.Rows.Count == 1)
                {
                    _orderNo = dsDataTable.Rows[0]["OrderNO"].SafeDbValue<string>();
                    _shootDate = dsDataTable.Rows[0]["PreShootDateN"].SafeDbValue<string>();
                    _customerNo = dsDataTable.Rows[0]["CustomerNo"].SafeDbValue<string>();
                    _customerName = dsDataTable.Rows[0]["CustomerName1"].SafeDbValue<string>() + "  " + dsDataTable.Rows[0]["CustomerName2"].SafeDbValue<string>();
                    _moblePhone = string.IsNullOrEmpty(dsDataTable.Rows[0]["MobilePhone2"].SafeDbValue<string>())
                        ? dsDataTable.Rows[0]["MobilePhone1"].SafeDbValue<string>()
                        : dsDataTable.Rows[0]["MobilePhone2"].SafeDbValue<string>();
                    _orderVenueNo = dsDataTable.Rows[0]["ShootAddressNNO"].SafeDbValue<string>();
                    dsDataTable.Dispose();
                    lblCusName.Text = _customerName;
                    cmbMoblePhone.Text = _moblePhone;
                }
                else
                {
                    for (int i = 0; i < dsDataTable.Rows.Count; i++)
                    {
                        _moblePhone = string.IsNullOrEmpty(dsDataTable.Rows[i]["MobilePhone2"].SafeDbValue<string>())
                        ? dsDataTable.Rows[i]["MobilePhone1"].SafeDbValue<string>()
                        : dsDataTable.Rows[i]["MobilePhone2"].SafeDbValue<string>();
                        cmbMoblePhone.Items.Add(_moblePhone);
                    }
                    cmbMoblePhone.SelectedIndex = 0;
                }
            }
        }

        private void FrmDressInOut_Load(object sender, EventArgs e)
        {
            txtDressbarcode.Focus();
        }

        private void btnDressChooseFinish_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpNO.Text) && string.IsNullOrEmpty(cmbMoblePhone.Text))
            {
                MessageBox.Show(@"请输入工号进行查询！");
                return;
            }
            if (MessageBox.Show(@"确认该员工和对应的顾客选衣完成？", @"提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return;
            }
            txtDressbarcode.Clear();
            picImage.Image = null;
            if (_dressList.Count == 0)
            {
                MessageBox.Show(@"请查询出对应员工的礼服后再操作！");
                return;
            }
            if (ErpService.DressManagement.DressInOperate(string.Join(",", _dressList.ToArray()), txtEmpNO.Text, DressState.送进.ToString(), _orderVenueNo, lblStyle.Text))
            {
                MessageBox.Show(@"选衣操作成功！");
                dgvShow.Columns.Clear();
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpBegin.Enabled = dtpEnd.Enabled = chkDate.Checked;
            btnDressChooseFinish.Enabled = !chkDate.Checked;
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(grbInformation.Text))
            {
                picImage.Image = null;
                if (dgvShow.CurrentRow != null)
                {
                    string dressBarcode = dgvShow.CurrentRow.Cells["DressBarCode"].Value.ToString();
                    DataSet dsSet = ErpService.DressManagement.GetDressSearchInformation(dressBarcode);
                    string imgPath = dsSet.Tables[0].Rows[0]["DressImagePath"].SafeDbValue<string>();
                    dsSet.Dispose();
                    if (string.IsNullOrEmpty(imgPath))
                    {
                        MessageBox.Show(@"该礼服没有照片路径！");
                        return;
                    }
                    string[] pathInfo = imgPath.Split(Convert.ToChar(@"\"));
                    Ping strPing = new Ping();
                    PingReply pingReply = strPing.Send(pathInfo[2]);
                    if (pingReply != null && pingReply.Status != IPStatus.Success)
                    {
                        MessageBox.Show(@"无法访问照片路径！");
                        return;
                    }
                    picImage.Image =
                        FileTool.ReadImageFile(imgPath.Replace("JPG", "lf").Replace("jpg", "lf"))
                            .ZoomImage(picImage.Size, true, Color.LightGray);
                }
            }
        }

        private void cmbMoblePhone_SelectedValueChanged(object sender, EventArgs e)
        {
            GetCustomer();
        }

        private void cmbMoblePhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetCustomer();
            }
        }

        private void GetCustomer()
        {
            lblCusName.Text = string.Empty;
            _orderNo = _shootDate = _customerNo = _customerName = _moblePhone = _orderVenueNo = string.Empty;
            if (string.IsNullOrEmpty(cmbMoblePhone.Text))
            {
                MessageBox.Show(@"请输入有效的电话号码。");
                return;
            }
            DataTable dsDataTable = ErpWs.SearchPreShoot(string.Format(@" and (MobilePhone1 ='{1}' or  MobilePhone2 ='{1}') and (DressEmployeeN = '{0}' or DressAssistantEmployeeN = '{0}')", lblName.Text.Trim(), cmbMoblePhone.Text.Trim())).Tables[0];
            if (dsDataTable.Rows.Count == 0)
            {
                MessageBox.Show(@"该电话号码没有对应的客人，请核对后重试！");
                lblCusName.Text = string.Empty;
                return;
            }

            _orderNo = dsDataTable.Rows[0]["OrderNO"].SafeDbValue<string>();
            _shootDate = dsDataTable.Rows[0]["PreShootDateN"].SafeDbValue<string>();
            _customerNo = dsDataTable.Rows[0]["CustomerNo"].SafeDbValue<string>();
            _customerName = dsDataTable.Rows[0]["CustomerName1"].SafeDbValue<string>() + "  " +
                                        dsDataTable.Rows[0]["CustomerName2"].SafeDbValue<string>();
            _moblePhone = string.IsNullOrEmpty(dsDataTable.Rows[0]["MobilePhone2"].SafeDbValue<string>())
                ? dsDataTable.Rows[0]["MobilePhone1"].SafeDbValue<string>()
                : dsDataTable.Rows[0]["MobilePhone2"].SafeDbValue<string>();
            _orderVenueNo = dsDataTable.Rows[0]["ShootAddressNNO"].SafeDbValue<string>();
            dsDataTable.Dispose();

            lblCusName.Text = _customerName;
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            FrmExampleShow frmExampleShow = new FrmExampleShow(_imgPath, 0);
            frmExampleShow.ShowDialog();
        }
    }
}
