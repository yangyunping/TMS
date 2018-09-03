using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using GoldenLady.Global;
using GoldenLadyWS;
namespace GoldenLady.SMSNew
{
    public partial class frmSendSms : Form
    {
        int sendType = 0;//0为默认状态，1为其它入口状态
        Service ErpWs = new Service();
      
        public frmSendSms()
        {
            InitializeComponent();
            IsDtpUse(false);
            ClientSide.Sms.GetApp(Application.StartupPath);
        }

        public frmSendSms(List<string> lstOrderNo,int sendtype)
        {
            InitializeComponent();
            IsDtpUse(false);
            ClientSide.Sms.GetApp(Application.StartupPath);
            SearchCustomers(lstOrderNo);//绑定要发送的顾客手机号
            sendType = sendtype;
            txtPhone.ReadOnly = true;
        }
        /// <summary>
        /// 礼服出租短信发送
        /// </summary>
        /// <param name="customerInfo"></param>
        public frmSendSms(List<string> customerInfo)
        {
            InitializeComponent();
            IsDtpUse(false);
            cmbAi.Enabled = false;
            ClientSide.Sms.GetApp(Application.StartupPath);
            sendType = 1;
            customerno.Add(customerInfo[0]);
            customername.Add(customerInfo[1]);
            txtPhone.Text = customerInfo[2];
            txtSendContent.Text = customerInfo[3];
            txtPhone.ReadOnly = false;
        }
        public frmSendSms(List<string[]> cutomerInfo, int sendtype)//create by wujianbo 20110802，由积分界面进入短信发送
        {
            InitializeComponent();
            IsDtpUse(false);
            ClientSide.Sms.GetApp(Application.StartupPath);
            int i=0;
            foreach (string[] info in cutomerInfo)
            {
                i++;
                txtPhone.Text += info[1];
                customername.Add(info[0]);//客户名称
                customerno.Add(info[2]);//客户号
                if (i != cutomerInfo.Count)//update by wujianbo 20110823 解决电话号码末尾始终有个逗号的问题
                {
                    txtPhone.Text += ",";
                }
            }
            sendType = sendtype;
            txtPhone.ReadOnly = true;
        }

        /// <summary>
        /// 摄控界面进入
        /// </summary>
        /// <param name="customerInfo"></param>
        public frmSendSms(List<string[]> customerInfo)
        {
            InitializeComponent();
            IsDtpUse(false);
            ClientSide.Sms.GetApp(Application.StartupPath);
            
            frmSexChoose fsc=new frmSexChoose();
            fsc.ShowDialog();

            foreach (string[] info in customerInfo)
            {
                if (fsc.sex == 0)
                {
                    if (info[2].Trim().Length != 0)
                    {
                        customerno.Add(info[0]);
                        txtPhone.Text += info[2]+",";
                    }
                }
                else if (fsc.sex == 1)
                {
                    if (info[1].Trim().Length != 0)
                    {
                        customerno.Add(info[0]);
                        txtPhone.Text += info[1] + ",";
                    }
                }
                else
                {
                    if (info[2].Trim().Length != 0)
                    {
                        customerno.Add(info[0]);
                        txtPhone.Text += info[2] + ",";
                    }
                    if (info[1].Trim().Length != 0)
                    {
                        customerno.Add(info[0]);
                        txtPhone.Text += info[1] + ",";
                    }
                }
            }
            if (txtPhone.Text.Split(',').Length > 0)
            {
                txtPhone.Text = txtPhone.Text.Substring(0,txtPhone.Text.Length-1);
            }
        }


        List<string> customername = new List<string>();//客户名称
        List<string> customerno = new List<string>();//客户号

        private void SearchCustomers(List<string> sOrderNO)//根据传入的订单号查询顾客手机号
        {
            string sSql = "and (1<>1 ";
            for (int i = 0; i < sOrderNO.Count; i++)
            {
                sSql += "or OrderNO = '" + sOrderNO[i] + "' ";
            }
            sSql += ") ";
            DataSet myds = new DataSet();
            myds = ErpWs.SearchOrders(ErpWs._Columns_All, sSql);
            DataRow[] dr = myds.Tables[0].Select("1=1");
            int count = dr.Length;
            frmSexChoose fsc = new frmSexChoose();
            fsc.ShowDialog();
            if (fsc.sex == 2)
            {
                for (int i = 0; i < count; i++)
                {
                    if (dr[i]["MobilePhone1"].ToString().Trim().Length != 0)
                    {
                        txtPhone.Text += dr[i]["MobilePhone1"].ToString().Trim();
                        customername.Add(dr[i]["customername1"].ToString());
                        customerno.Add(dr[i]["customerno"].ToString());
                        if (i != (count - 1) || dr[i]["MobilePhone2"].ToString().Trim().Length != 0)
                        {
                            txtPhone.Text += ",";
                        }
                    }
                    if (dr[i]["MobilePhone2"].ToString().Trim().Length != 0)
                    {
                        txtPhone.Text += dr[i]["MobilePhone2"].ToString().Trim();
                        customername.Add(dr[i]["customername2"].ToString());
                        customerno.Add(dr[i]["customerno"].ToString());
                        if (i != (count - 1))
                        {
                            txtPhone.Text += ",";
                        }
                    }
                }
            }
            else if (fsc.sex == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (dr[i]["MobilePhone2"].ToString().Trim().Length != 0)
                    {
                        txtPhone.Text += dr[i]["MobilePhone2"].ToString().Trim();
                        customername.Add(dr[i]["customername2"].ToString());
                        customerno.Add(dr[i]["customerno"].ToString());
                        if (i != (count - 1))
                        {
                            txtPhone.Text += ",";
                        }
                    }
                }
            }
            else if (fsc.sex == 1)
            {
                for (int i = 0; i < count; i++)
                {
                    if (dr[i]["MobilePhone1"].ToString().Trim().Length != 0)
                    {
                        txtPhone.Text += dr[i]["MobilePhone1"].ToString().Trim();
                        customername.Add(dr[i]["customername1"].ToString());
                        customerno.Add(dr[i]["customerno"].ToString());
                        if (i != (count - 1))
                        {
                            txtPhone.Text += ",";
                        }
                    }
                }
            }
        }

        void IsDtpUse(bool flag)//是否启用时间控件
        {
            dtpYMD.Enabled = flag;
            dtpHMS.Enabled = flag;
        }

        List<int> listAiID = new List<int>();

        private void frmSendSms_Load(object sender, EventArgs e)
        {
            GoldenLadyWS.Service service = new GoldenLadyWS.Service();
            string sql = "select sa.id as id,name,content1 as content from SMSUsefulExpressions su,SMSAi sa where su.id=sa.id";
            DataSet ds = service.GetDataSet(sql);
            if (ds != null)
            {
                cmbAi.ValueMember = "content";
                cmbAi.DisplayMember = "name";
                cmbAi.DataSource = ds.Tables[0];
                cmbAi.SelectedIndex = -1;
                foreach (DataRow i in ds.Tables[0].Rows)
                {
                    listAiID.Add(Convert.ToInt32(i["id"].ToString()));
                }
            }
        }

        private void cmbAi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAi.Enabled == false)
            {
                return;
            }
            try//add by wujianbo 20121206
            {
                txtSendContent.Text = cmbAi.SelectedValue.ToString() + "\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"尚未自定义任何短语！详细信息：\r\n"+ex.Message,@"提示！",MessageBoxButtons.OK,MessageBoxIcon.Error);
                frmOption fo = new frmOption();
                fo.Show();
                this.Close();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"手机号码不能为空！");
                return;
            }
            //验证手机号码不为空
            if (txtSendContent.Text.Trim().Length == 0)
            {
                MessageBox.Show(@"发送内容不能为空！");
                return;
            }
            System.Threading.Thread tdStart = new System.Threading.Thread(StartSend);
            tdStart.IsBackground = true;
            tdStart.Start();
            //UC.ucLoading ucl = new GoldenLady.UC.ucLoading("正在发送，请稍候...", false);
            //ucl.Name = "ucLoading";
            //this.Controls.Add(ucl);
            //ucl.BringToFront();
            //ucl.Dock = DockStyle.Fill;
            //ucl.Show();
        }

        void StartSend()
        {
            try
            {
                string[] phones = txtPhone.Text.Split(',');
                //验证短信内容不能为空
                GoldenLadyWS.Service service = new GoldenLadyWS.Service();
                ClientSide.Sms.GetApp(Application.StartupPath);
                string result = "";
                string sql = "";
                int sendsucceed = 0;
                int sendfailed = 0;
                int savesucceed = 0;
                int savefailed = 0;
                dlgChangeSendState myDlg = new dlgChangeSendState(ChangeSendState);
                if (!ckbTiming.Checked)
                {
                    try
                    {
                        for (int i = 0; i < phones.Length; i++)
                        {
                            if (phones[i].Trim() == "") //add by wujianbo 20110808,如果手机号为空则不发送
                            {
                                continue;
                            }
                            string tempContent = txtSendContent.Text;
                            if (sendType == 1)
                            {
                                tempContent = txtSendContent.Text.Replace("[姓名]", customername[i]);
                            }
                            result = ClientSide.Sms.app.fSendSMS(tempContent, phones[i], "5",
                                Information.CurrentUser.EmployeeNO, "无"); //update by wujianbo 20120728
                            if (result == "发送成功")
                            {
                                if (sendType == 1)
                                {
                                    sql =
                                        "insert into SMSOld (customername,customerno,employeeno,smsphone,smscontent,smstime,smspriority,smsstatus,smsaistatus) " +
                                        "values ('" + customername[i] + "','" + customerno[i] + "','" +
                                        Information.CurrentUser.EmployeeNO + "','" + phones[i] + "','" +
                                        txtSendContent.Text.Replace("[姓名]", customername[i]) + "','" +
                                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',5,1,0) ";
                                }
                                else
                                {
                                    sql =
                                        "insert into SMSOld (customername,customerno,employeeno,smsphone,smscontent,smstime,smspriority,smsstatus,smsaistatus) " +
                                        "values ('无','无','" + Information.CurrentUser.EmployeeNO + "','" + phones[i] +
                                        "','" + txtSendContent.Text + "','" +
                                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',5,1,0) ";
                                }
                                if (service.ExecuteCommandText(sql) <= 0)
                                {
                                    sendsucceed++;
                                    savefailed++;
                                }
                                else
                                {
                                    sendsucceed++;
                                    savesucceed++;
                                }
                            }
                            else
                            {

                                if (sendType == 1)
                                {
                                    sql =
                                        "insert into SMSOld (customername,customerno,employeeno,smsphone,smscontent,smstime,smspriority,smsstatus,smsaistatus) " +
                                        "values ('" + customername[i] + "','" + customerno[i] + "','" +
                                        Information.CurrentUser.EmployeeNO + "','" + phones[i] + "','" +
                                        txtSendContent.Text.Replace("[姓名]", customername[i]) + "','" +
                                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',5,2,0)";
                                }
                                else
                                {
                                    sql =
                                        "insert into SMSOld (customername,customerno,employeeno,smsphone,smscontent,smstime,smspriority,smsstatus,smsaistatus) " +
                                        "values ('无','无','" + Information.CurrentUser.EmployeeNO + "','" + phones[i] +
                                        "','" + txtSendContent.Text + "','" +
                                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',5,2,0)";
                                }
                                if (service.ExecuteCommandText(sql) > 0)
                                {
                                    sendfailed++;
                                    savesucceed++;
                                }
                                else
                                {
                                    sendfailed++;
                                    savefailed++;
                                }
                            }

                            this.Invoke(myDlg, phones.Length, i + 1);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, @"出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    for (int i = 0; i < phones.Length; i++)
                    {
                        string sqlTiming =
                            "insert into SMSPlatform (customername,customerno,employeeno,smsphone,smscontent,smstime,smspriority,smsstatus,smsaistatus) " +
                            "values ('无','无','" + Information.CurrentUser.EmployeeNO + "','" + phones[i] + "','" +
                            txtSendContent.Text + "','" + dtpYMD.Value.ToString("yyyy-MM-dd") + " " + dtpHMS.Text +
                            "',5,3," + listAiID[cmbAi.SelectedIndex] + ")";
                        if (sendType == 1)
                        {
                            sqlTiming =
                                "insert into SMSPlatform (customername,customerno,employeeno,smsphone,smscontent,smstime,smspriority,smsstatus,smsaistatus) " +
                                "values ('" + customername[i] + "','" + customerno[i] + "','" +
                                Information.CurrentUser.EmployeeNO + "','" + phones[i] + "','" +
                                txtSendContent.Text.Replace("[姓名]", customername[i]) + "','" +
                                dtpYMD.Value.ToString("yyyy-MM-dd") + " " + dtpHMS.Text + "',5,3," +
                                listAiID[cmbAi.SelectedIndex] + ")";
                        }
                        if (service.ExecuteCommandText(sqlTiming) > 0)
                        {
                            sendsucceed++;
                            savesucceed++;
                        }
                        else
                        {
                            sendfailed++;
                            savefailed++;
                        }
                        this.Invoke(myDlg, phones.Length, i + 1);
                    }
                }

                if (MessageBox.Show(
                    @"发送任务执行完毕！发送成功" + sendsucceed + @"条，失败" + sendfailed + @"条；保存记录成功" + savesucceed + @"条，失败" +
                    savefailed + @"条！", @"提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    txtPhone.Clear();
                    txtSendContent.Clear();
                    sendsucceed = 0;
                    sendfailed = 0;
                    savesucceed = 0;
                    savefailed = 0;

                    #region 操作日志   qiuqianquan 20120518

                    string DepartmentNO = Information.CurrentUser.EmployeeDepartmentNO;
                    string CreateEmployee = Information.CurrentUser.EmployeeNO;
                    string CreateDate = DateTime.Now.ToString();
                    ErpWs.InsertOrderLogoZON("", "O7_011", DepartmentNO, CreateEmployee, CreateDate, "0", "操作日志",
                        "发送短信：" + txtPhone.Text.ToString());

                    #endregion

                    this.Close();
                }
                else
                {
                    this.Close();
                }
                //foreach (Control cnt in this.Controls)
                //{
                //    cnt.Name = "ucLoading";
                //    cnt.Dispose();
                //    break;
                //}
            }
            catch
            {
                return;
            }
        }

        void ChangeSendState(int totalCount,int sendedCount)
        {
            tslSmsCount.Text = @"即将发送"+totalCount.ToString()+@"条，已发送"+sendedCount.ToString()+@"条";
            if (totalCount == sendedCount)
            {
                tslSmsCount.Text = @"即将发送"+totalCount.ToString()+@"条";
            }
        }

        delegate void dlgChangeSendState(int totalCount, int sendedCount);

        private void ckbTiming_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTiming.Checked)
            {
                IsDtpUse(true);
            }
            else
            {
                IsDtpUse(false);
            }
        }

        private void dtpYMD_ValueChanged(object sender, EventArgs e)
        {
            if (dtpYMD.Value < DateTime.Now)
            {
                dtpYMD.Value = DateTime.Now;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != ',' && e.KeyChar!=(char)008)
            {
                e.Handled = true;
            }
        }

        private void txtSendContent_TextChanged(object sender, EventArgs e)
        {
            lblLength.Text = "已输入" + txtSendContent.Text.Length.ToString() + "字";
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            string[] phones = txtPhone.Text.Trim().Split(',');
            int count = phones.Length;
            if (txtPhone.Text.Trim().Length == 0)
            {
                count = 0;
            }
            tslSmsCount.Text = @"即将发送"+count.ToString()+@"条";
        }

        private void lkbBalance_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(ClientSide.Sms.app.GetBalance());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,@"抱歉！",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void frmSendSms_FormClosing(object sender, FormClosingEventArgs e)
        {
            customername.Clear();
            customerno.Clear();
        }

        private void tsmiExcelIn_Click(object sender, EventArgs e)
        {
            ofdPhoneFile.Filter = "Excel文件|*.xls|文本文件|*.txt";
            ofdPhoneFile.DefaultExt="xls";
            ofdPhoneFile.ShowDialog();
        }

        private void ofdPhoneFile_FileOk(object sender, CancelEventArgs e)
        {
            DataSet ds;
            try
            {
                OleDbConnection cnn = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;data source=" + ofdPhoneFile.FileName + ";Extended Properties=Excel 8.0;");
                OleDbDataAdapter cmd = new OleDbDataAdapter("select * from [Sheet1$]", cnn);
                cnn.Open();
                ds = new DataSet();
                cmd.Fill(ds);
                cnn.Close();
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show(ex.Message, "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("无任何有效数据！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = ds.Tables[0];
            string phone;
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    if (dr["电话"].ToString().Trim().Length != 0)
                    {
                        phone = dr["电话"].ToString().Trim().Trim(',').Trim() + ",";
                        if (phone.Length != 0)
                        {
                            txtPhone.Text += phone;
                        }
                    }
                }
                catch (System.ArgumentException ex)
                {
                    MessageBox.Show("找不到\"电话\"字段！", "提示！" + ex, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (txtPhone.Text.Split(',').Length != 0 && txtPhone.Text.Length != 0)
            {
                txtPhone.Text = txtPhone.Text.Substring(0, txtPhone.Text.Length - 1);
            }
        }
    }
}
