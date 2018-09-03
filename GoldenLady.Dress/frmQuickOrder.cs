using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLadyWS;

namespace GoldenLady.Dress
{
    public partial class FrmQuickOrder : frmBasForm
    {
        private readonly string _sCustomerNo;
        private readonly int _panduan = 0;
        public string OrderNo;
        Service ErpWs = new Service();
        public FrmQuickOrder(string sCustomerNOs, int panduans)//0新客人  1其它
        {
            InitializeComponent();
            _sCustomerNo = sCustomerNOs;
            _panduan = panduans;
            this._sCustomerNo = sCustomerNOs;
            InitControl();
            cmbSuite.Text = @"外来出租套";
            SelectInfoByCustomerNo(_sCustomerNo);
        }
        private void SelectInfoByCustomerNo(string sCustomerNo)
        {
            string str = "select CustomerName1 as 先生,MobilePhone1 as 电话1,CustomerName2 as 小姐,MobilePhone2 as 电话2 from Customers where CustomerNO='" + sCustomerNo + "'";
            DataSet dk = ErpWs.GetDataSet(str);
            if (dk.Tables[0].Rows.Count > 0)
            {
                txtCustomerName1.Text = dk.Tables[0].Rows[0]["先生"].ToString();
                txtMobilePhone1.Text = dk.Tables[0].Rows[0]["电话1"].ToString();
                txtCustomerName2.Text = dk.Tables[0].Rows[0]["小姐"].ToString();
                txtMobilePhone2.Text = dk.Tables[0].Rows[0]["电话2"].ToString();
            }
            else
            {
                txtCustomerName1.Text = "";
                txtMobilePhone1.Text = "";
                txtCustomerName2.Text = "";
                txtMobilePhone2.Text = "";
            }
            dk.Dispose();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            //如果在新订单的情况直接退出，表示建单不成功，所以先回滚到初始状态-删除客户资料
            ErpWs.DeleteCustomers(new string[] { _sCustomerNo });
            base.Close();
        }

        private void InitControl()
        {
            lbCustomerName1.Text = Information.Edition.CustomerName1;
            lbCustomerName2.Text = Information.Edition.CustomerName2;

            cmbOrderNO.SelectedIndex = 0;
            //活动名称
            InitActivity();
            //套系类别
            InitSuiteType();
            //套系
            InitSuite();
            //加载产品库第一个产品作为默认产品
            SearchTopOneProducts();
        }

        private void InitActivity()
        {
            DataSet dsConfig;
            dsConfig =  ErpWs.SearchConfig("");
            cmbActivityName.DataSource = dsConfig.Tables[0].Select("ConfigType='订单活动' ").CopyToDataTable(); ;
            cmbActivityName.DisplayMember = "ConfigValue";
            cmbActivityName.ValueMember = "ConfigNO";
            cmbActivityName.SelectedIndex = 0;
            dsConfig.Dispose();
        }

        private void InitSuiteType()
        {
            DataSet myds =  ErpWs.SearchSuiteType();
            cmbSuiteType.DataSource = myds.Tables[0];
            cmbSuiteType.DisplayMember = "SuiteTypeName";
            cmbSuiteType.ValueMember = "SuiteTypeNO";
            myds.Dispose();
            cmbSuiteType.SelectedIndex = 0;
            cmbSuite.Text = @"外来出租套";
        }

        private bool b_SuiteFilter = false;
        private void InitSuite()
        {
            try
            {
                string isDelete = "";
                isDelete = "and Suite.IsDelete=0";
                DataSet myds =  ErpWs.SearchSuite(isDelete);
                cmbSuite.DataSource = myds.Tables[0];
                cmbSuite.DisplayMember = "SuiteName";
                cmbSuite.ValueMember = "SuiteNO";
                myds.Dispose();
                cmbSuite.SelectedIndex = 0;
            }
            catch { MessageBox.Show("套系初始化失败,请检查!"); }
        }
        private string sIntroducerType;
        private void SearchIntroducer(string sIntroducerType, string sIntroducerNO)
        {
            string sCardNO = "";
            string sCustomerName = "";
            DataSet myds = new DataSet();
            if (sIntroducerType == "员工")
            {
                myds =  ErpWs.SearchEmployeeByEmployeeNO_old(sIntroducerNO);
                sCardNO = myds.Tables[0].Rows[0]["CardNO"].ToString();
                sCustomerName = myds.Tables[0].Rows[0]["EmployeeName"].ToString();
            }
            else if (sIntroducerType == "客人")
            {
                myds =  ErpWs.SearchCustomer("and CustomerNO='" + sIntroducerNO + "' ");
                sCardNO = myds.Tables[0].Rows[0]["CardNO"].ToString();
                sCustomerName = myds.Tables[0].Rows[0]["CustomerName1"].ToString() + " " + myds.Tables[0].Rows[0]["CustomerName2"].ToString();
            }
            lbIntroducer.Text = sCardNO + " - " + sCustomerName;
        }

        private void cmbOrderNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderNO.SelectedIndex == 0)
            {
                txtOrderNO.ReadOnly = true;
                txtOrderNO.Text = "自动生成";
            }
            else
            {
                txtOrderNO.ReadOnly = false;
                txtOrderNO.Text = "";
                txtOrderNO.Focus();
            }
        }

        private void cmbSuiteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSuite.SelectedValue != null)
                {
                    DataSet myds =  ErpWs.SearchSuite("and SuiteNO='" + cmbSuite.SelectedValue.ToString() + "'");
                    txtSuitePrice.Text = myds.Tables[0].Rows[0]["SuitePrice"].ToString();
                    myds.Dispose();
                    //bCountRows = true;
                }
            }
            catch { }
        }

        private void SearchTopOneProducts()
        {
            for (int i = dgvOrderProducts.Rows.Count - 1; i >= 0; i--)
            {
                if (dgvOrderProducts.Rows[i].IsNewRow)
                {
                    continue;
                }
                else if (dgvOrderProducts.Rows[i].Cells["Option"].Value.ToString() == "NEW")
                {
                    dgvOrderProducts.Rows.RemoveAt(i);
                }
                else
                {
                    dgvOrderProducts.Rows[i].Cells["Option"].Value = "DELETE";
                }
            }
            DataSet myds = new DataSet();
            myds =  ErpWs.SearchTopOneProducts(cmbSuite.SelectedValue.ToString());
            DataRow[] dr = myds.Tables[0].Select();
            string[] r = new string[24];
            for (int i = 0; i < dr.Length; i++)
            {
                bool bIsExist = false;
                for (int x = 0; x < dgvOrderProducts.Rows.Count; x++)
                {
                    if (dgvOrderProducts.Rows[x].IsNewRow)
                    {
                        break;
                    }
                    else if (dgvOrderProducts.Rows[x].Cells["ProductNO"].Value.ToString() == dr[i]["ProductNO"].ToString() && dgvOrderProducts.Rows[x].Cells["Option"].Value.ToString() != "DELETE")
                    {
                        bIsExist = true;
                        break;
                    }
                }
                if (bIsExist)
                {
                    continue;
                }
                //以上判断产品是否存在
                int iRows = dgvOrderProducts.Rows.Count - 2;
                string sOrderIndex = "000";
                if (iRows <= -1 || dgvOrderProducts.Rows[iRows].IsNewRow)
                    sOrderIndex = "000";
                else
                    sOrderIndex = dgvOrderProducts.Rows[iRows].Cells["OrderIndex"].Value.ToString();
                if (sOrderIndex.Trim() == "")
                    sOrderIndex = "000";
                sOrderIndex = string.Format("{0:d3}", Int32.Parse(sOrderIndex) + 1);
                r[0] = sOrderIndex;
                r[1] = dr[i]["ProductNO"].ToString();
                r[2] = dr[i]["ProductTypeName"].ToString();
                r[3] = dr[i]["ProductName"].ToString();
                r[4] = dr[i]["ProductSizeA"].ToString() + "*" + dr[i]["ProductSizeB"].ToString();
                r[5] = dr[i]["PageQuantity"].ToString();
                r[6] = dr[i]["NegativeQuantity"].ToString();
                r[7] = dr[i]["ProductQuantity"].ToString();
                r[8] = "";
                r[9] = dr[i]["ProductSellingPrice"].ToString();
                r[10] = "正常";
                r[11] = "NEW";
                r[12] = "001";
                r[13] = Information.CurrentUser.EmployeeNO;
                r[14] = DateTime.Now.ToString();
                r[15] = dr[i]["Fram"].ToString();
                r[16] = dr[i]["Box"].ToString();
                r[17] = dr[i]["Unit"].ToString();
                r[18] = dr[i]["Paper"].ToString();
                r[19] = dr[i]["film"].ToString();
                r[20] = dr[i]["InsidePage"].ToString();
                r[21] = dr[i]["Biao"].ToString();
                r[22] = dr[i]["Ban"].ToString();
                r[23] = dr[i]["Diao"].ToString();
                dgvOrderProducts.Rows.Add(r);
            }
            myds.Dispose();
        }

        private void txtSuitePrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSuitePrice.Text.Trim() != "")
                {
                    if (txtSuitePrice.Text.Trim() == ".")//by wujianbo 20110503，禁止文本框只有一个小数点，以防下面格式转换时报错
                        txtSuitePrice.Text = @"0.00";

                    txtPreSuitePrice.Text = string.Format("{0}", double.Parse(txtSuitePrice.Text.ToString()) * (double.Parse(txtDiscount.Text.ToString()) / 100) - double.Parse(txtReducesPresently.Text.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"输入错误!");
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Trim() != "")
            {
                txtPreSuitePrice.Text = string.Format("{0}", double.Parse(txtSuitePrice.Text.ToString()) * (double.Parse(txtDiscount.Text.ToString()) / 100) - double.Parse(txtReducesPresently.Text.ToString()));
            }
        }

        private void txtReducesPresently_TextChanged(object sender, EventArgs e)
        {
            if (txtReducesPresently.Text.Trim() != "")
            {
                if (txtReducesPresently.Text.Trim() == ".")//by wujianbo 20110503，禁止文本框只有一个小数点，以防下面格式转换时报错
                    txtReducesPresently.Text = @"0.00";

                txtPreSuitePrice.Text = string.Format("{0}", double.Parse(txtSuitePrice.Text) * (double.Parse(txtDiscount.Text) / 100) - double.Parse(txtReducesPresently.Text.ToString()));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (txtCustomerName1.Text.Trim() == "" && txtCustomerName2.Text.Trim() == "")
            {
                MessageBox.Show(@"客户姓名至少要有一个");
                txtCustomerName1.Focus();
                return;
            }
            if (txtOrderNO.Text.Trim() == "")
            {
                MessageBox.Show(@"请输入订单号后再保存！");
                return;
            }
            if (cmbSuite.SelectedValue == null)
            {
                MessageBox.Show(@"套系选择错误,请查询!");
                return;
            }
            int r = dgvOrderProducts.Rows.Count;
            if (r == 1)
            {
                MessageBox.Show(@"订单无产品，无法保存！请为客人录入套系产品");
                return;
            }
            if (_sCustomerNo != "" && _panduan == 0)
            {
                if (SaveCustomer())
                {
                    if (SaveOrder())
                    {
                        MessageBox.Show(@"订单基本资料保存成功!");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(@"订单保存失败，请检查!" + '\n' +  ErpWs.GetErroMsg(), "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //如果在新订单的情况直接退出，表示建单不成功，所以先回滚到初始状态-删除客户资料
                         ErpWs.DeleteCustomers(new string[] { _sCustomerNo });
                    }
                }
                else
                {
                    MessageBox.Show(@"客户保存失败，请检查!" + '\n' +  ErpWs.GetErroMsg(), "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //如果在新订单的情况直接退出，表示建单不成功，所以先回滚到初始状态-删除客户资料
                     ErpWs.DeleteCustomers(new string[] { _sCustomerNo });
                }
            }
            else
            {
                if (SaveOrder())
                {
                    MessageBox.Show(@"订单基本资料保存成功!");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(@"订单保存失败，请检查!" + '\n' +  ErpWs.GetErroMsg(), "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //如果在新订单的情况直接退出，表示建单不成功，所以先回滚到初始状态-删除客户资料
                     ErpWs.DeleteCustomers(new string[] { _sCustomerNo });
                }
            }
        }

        private string sOption = "NEW";
        //保存客户资料
        private bool SaveCustomer()
        {
            bool breturn = false;
            try
            {
                #region 保存客户基本资料
                //在保存的时候建立客户号
                string sCardType = "";
                string sTheGregorianCalendar1 = "0";
                string sMobilePhoneIsLose1 = "0";
                string sTelephoneIsLose1 = "0";
                string sTheGregorianCalendar2 = "0";
                string sMobilePhoneIsLose2 = "0";
                string sTelephoneIsLose2 = "0";
                string sJob1 = "";
                string sJobName1 = "";
                string sJob2 = "";
                string sJobName2 = "";
                string sCustomerSource = "";
                string sCustomerSourceName = "";
                string sWishRecommend = "";
                string sWishRecommendName = "";
                string sImformationSource = "";
                string sImformationSourceName = "";
                string sIsLetterAddress = "0";
                string sIsEnableAddress = "0";
                string sYear1 = "";
                string sMonth1 = "";
                string sDay1 = "";
                string sYear2 = "";
                string sMonth2 = "";
                string sDay2 = "";

                sTheGregorianCalendar1 = "0";
                sMobilePhoneIsLose1 = "0";
                sTelephoneIsLose1 = "0";
                sTheGregorianCalendar2 = "0";
                sMobilePhoneIsLose2 = "0";
                sTelephoneIsLose2 = "0";
                sIsLetterAddress = "0";
                sIsEnableAddress = "0";

                //Update:Caijinsong 2012-11-13
                if ( ErpWs.SaveCustomer(_sCustomerNo, "", "", sIntroducerType, txtIntroducer.Text.Trim(), txtCustomerName1.Text.ToString(), sYear1, sDay1, sMonth1, sTheGregorianCalendar1, txtMobilePhone1.Text.ToString(), sMobilePhoneIsLose1, "", sTelephoneIsLose1, "", "", sJob1, sJobName1, "", "", txtCustomerName2.Text.ToString(), sYear2, sDay2, sMonth2, sTheGregorianCalendar2, txtMobilePhone2.Text.ToString(), sMobilePhoneIsLose2, "", sTelephoneIsLose2, "", "", sJob2, sJobName2, "", "", sIsLetterAddress, "", "", sCustomerSource, sCustomerSourceName, sImformationSource, sImformationSourceName, sWishRecommend, sWishRecommendName, "", Information.CurrentUser.EmployeeDepartmentNO, Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName, DateTime.Now.ToString(), "0", "", "", "正常", sIsEnableAddress, "", "", "", "", "", "", Information.CurrentUser.CompanyBM))
                {
                    breturn = true;
                    if ( ErpWs.InsertOrderLogoCustZO("O1_001", Information.CurrentUser.EmployeeDepartmentNO, Information.CurrentUser.EmployeeNO, DateTime.Now.ToString(), "0", "操作日志", "新增客户" + _sCustomerNo))
                    {
                    }
                    else
                        MessageBox.Show(@"新增客户基本资料操作日志记录失败!" + '\n' +  ErpWs.GetErroMsg());
                     ErpWs.UpdateInCustomerCompleted(_sCustomerNo, "1");
                }
                else
                {
                    MessageBox.Show(@"客户基本资料保存失败!" + '\n' +  ErpWs.GetErroMsg());
                    breturn = false;
                }
                #endregion

                #region 保存推荐人积分信息
                //保存推荐人积分信息
                string sIntroducer = txtIntroducer.Text.ToString().Trim();
                if (sOption != "NEW" || sIntroducer != "")//当新建订单，同时无介绍人时无须保存推荐人
                {
                    string sIntroOption = "NEW";
                     ErpWs.SaveIntroducerRepay(sIntroducer, _sCustomerNo, "100", DateTime.Now.AddYears(1).ToString(), sIntroOption);
                }
                #endregion

            }
            catch
            {
                breturn = false;
            }
            return breturn;
        }

        private bool SaveOrder()
        {
            int r = 1;
            string[] sOrderIndex = new string[r];
            string[] sProductNO = new string[r];
            string[] sSeparateNO = new string[r];
            string[] sPageQuantity = new string[r];
            string[] sNegativeQuantity = new string[r];
            string[] sProductQuantity = new string[r];
            string[] sProductMemory = new string[r];
            string[] sProductSellingPrice = new string[r];
            string[] sProduceState = new string[r];
            string[] sOptionType = new string[r];
            string[] sCreateEmployee = new string[r];
            string[] sCreateDate = new string[r];
            string[] sFram = new string[r];
            string[] sBox = new string[r];
            string[] sUnit = new string[r];
            string[] sPaper = new string[r];
            string[] sfilm = new string[r];
            string[] sInsidePage = new string[r];
            string[] sBiao = new string[r];
            string[] sBan = new string[r];
            string[] sDiao = new string[r];
            for (int i = 0; i < r; i++)
            {
                if (dgvOrderProducts.Rows[i].IsNewRow)
                {
                    continue;
                }
                sOrderIndex[i] = dgvOrderProducts.Rows[i].Cells["OrderIndex"].Value.ToString();
                sProductNO[i] = dgvOrderProducts.Rows[i].Cells["ProductNO"].Value.ToString();
                sSeparateNO[i] = dgvOrderProducts.Rows[i].Cells["SeparateNO"].Value.ToString();
                sPageQuantity[i] = dgvOrderProducts.Rows[i].Cells["PageQuantity"].Value.ToString();
                sNegativeQuantity[i] = dgvOrderProducts.Rows[i].Cells["NegativeQuantity"].Value.ToString();
                sProductQuantity[i] = dgvOrderProducts.Rows[i].Cells["ProductQuantity"].Value.ToString();
                sProductSellingPrice[i] = dgvOrderProducts.Rows[i].Cells["ProductSellingPrice"].Value.ToString();
                sProductMemory[i] = dgvOrderProducts.Rows[i].Cells["ProductMemory"].Value.ToString();
                sProduceState[i] = dgvOrderProducts.Rows[i].Cells["ProduceState"].Value.ToString();
                sOptionType[i] = dgvOrderProducts.Rows[i].Cells["Option"].Value.ToString();
                sCreateEmployee[i] = dgvOrderProducts.Rows[i].Cells["Create"].Value.ToString();
                sCreateDate[i] = dgvOrderProducts.Rows[i].Cells["CreateDate"].Value.ToString();
                sFram[i] = dgvOrderProducts.Rows[i].Cells["Fram"].Value.ToString();
                sBox[i] = dgvOrderProducts.Rows[i].Cells["Box"].Value.ToString();
                sUnit[i] = dgvOrderProducts.Rows[i].Cells["Unit"].Value.ToString();
                sPaper[i] = dgvOrderProducts.Rows[i].Cells["Paper"].Value.ToString();
                sfilm[i] = dgvOrderProducts.Rows[i].Cells["film"].Value.ToString();
                sInsidePage[i] = dgvOrderProducts.Rows[i].Cells["InsidePage"].Value.ToString();
                sBiao[i] = dgvOrderProducts.Rows[i].Cells["Biao"].Value.ToString();
                sBan[i] = dgvOrderProducts.Rows[i].Cells["Ban"].Value.ToString();
                sDiao[i] = dgvOrderProducts.Rows[i].Cells["Diao"].Value.ToString();

            }
            string sShootAddressN = "";
            string sShootAddressNName = "";
            string sShootAddressW = "";
            string sShootAddressWName = "";

            #region 流失
            string sOrderState = "1";
            string sLossType = "";
            string sLossMemory = "";
            if (cmbOrderNO.SelectedIndex == 0)
                txtOrderNO.Text = OrderNo = CreateNewOrderNO();
            #endregion

            //新订单将自动获取收银发票，看样预付优先，其次第一次收银发票
            string sFPH =  ErpWs.GetFPH(txtOrderNO.Text.ToString());
            //if ( ErpWs.SaveOrder_N(sCustomerNo, txtOrderNO.Text.Trim(), sFPH, cmbActivityName.SelectedValue.ToString(), cmbSuiteType.SelectedValue.ToString(), cmbSuite.SelectedValue.ToString(), txtSuitePrice.Text.ToString(), txtDiscount.Text.Trim(), txtReducesPresently.Text.Trim(), txtPreSuitePrice.Text.Trim(), "0", sShootAddressN, "", sShootAddressW, "", Information.CurrentUser.EmployeeDepartmentNO, Information.CurrentUser.EmployeeNO, DateTime.Now.ToString(), "", "", sOrderState, sLossType, sLossMemory, "0", sOrderIndex, sProductNO, sSeparateNO, sFram, sBox, sUnit, sPaper, sfilm, sInsidePage, sBiao, sBan, sDiao, sPageQuantity, sNegativeQuantity, sProductQuantity, sProductMemory, sProductSellingPrice, sProduceState, sCreateEmployee, sCreateDate, sOptionType,"",""))
            //Caijinsong:2012-11-24
            if ( ErpWs.SaveOrder_N(_sCustomerNo, txtOrderNO.Text.Trim(), sFPH, cmbActivityName.SelectedValue.ToString(), cmbActivityName.Text.ToString(), cmbSuiteType.SelectedValue.ToString(), cmbSuiteType.Text.ToString(), cmbSuite.SelectedValue.ToString(), cmbSuite.Text.ToString(), txtSuitePrice.Text.ToString(), txtDiscount.Text.Trim(), txtReducesPresently.Text.Trim(), "0", "0", "0", txtPreSuitePrice.Text.Trim(), "0", sShootAddressN, sShootAddressNName, "", sShootAddressW, sShootAddressWName, "", Information.CurrentUser.EmployeeDepartmentNO, Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName, "", "", "0", DateTime.Now.ToString(), "", "", sOrderState, sLossType, sLossMemory, "0", sOrderIndex, sProductNO, sSeparateNO, sFram, sBox, sUnit, sPaper, sfilm, sInsidePage, sBiao, sBan, sDiao, sPageQuantity, sNegativeQuantity, sProductQuantity, sProductMemory, sProductSellingPrice, sProduceState, sCreateEmployee, sCreateDate, sOptionType, "", "", Information.CurrentUser.CompanyBM, "", "", "", "", "", ""))
            {
                if (! ErpWs.InsertOrderLogoZON(txtOrderNO.Text.Trim(), "O1_022", Information.CurrentUser.EmployeeDepartmentNO, Information.CurrentUser.EmployeeNO, DateTime.Now.ToString(), "0", "操作日志", ""))
                {
                    MessageBox.Show(@"插入操作日志失败" + '\n' +  ErpWs.GetErroMsg());
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private string CreateNewOrderNO()
        {
            string sCompanyBm = Information.Company.CompanyBM;
            string sYear = (DateTime.Now.Year % 100).ToString("D2");
            string sMonth = DateTime.Now.Month.ToString("D2");
            string sDay = DateTime.Now.Day.ToString("D2");
            string sOrderNo = sCompanyBm + sYear + sMonth + sDay;
            sOrderNo =  ErpWs.CreateNewOrder(sOrderNo);
            return sOrderNo;
        }
    

        private void cmbSuite_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSuite.SelectedValue != null)
                {
                    DataSet myds =  ErpWs.SearchSuite("and SuiteNO='" + cmbSuite.SelectedValue.ToString() + "'");
                    txtSuitePrice.Text = myds.Tables[0].Rows[0]["SuitePrice"].ToString();
                    myds.Dispose();
                }
            }
            catch
            {
                // ignored
            }
        }

        private void frmQuickOrder_Load(object sender, EventArgs e)
        {
            cmbSuiteType.Text = @"礼服外来人员出租类";
            cmbSuite.Text = @"外来出租套";
            lbCustomerName1.Text = @"先    生";
            lbCustomerName2.Text = @"小    姐";
        }
    }
}
