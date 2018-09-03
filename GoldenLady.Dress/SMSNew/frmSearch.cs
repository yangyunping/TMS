using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Global;
using GoldenLadyWS;

namespace GoldenLady.SMSNew
{
    public partial class frmSearch : Form
    {
        Service ErpWs = new Service();
        public frmSearch()
        {
            InitializeComponent();
            ClientSide.Sms.GetApp(Application.StartupPath);
            ckbNotSent.Checked = true;
        }

        static string sql = "select smsid,customername,customersex,smsphone,smscontent,smstime,name,employeeno,customerno,smsstatus from ";
        static string sqlPlatform = sql + "SMSPlatform,SMSAi where smsaistatus=id ";
        static string sqlOld = sql + "SMSOld,SMSAi where smsaistatus=id ";
        //static string sqlByTime = " and CAST(smstime as datetime) between '" + dtStart + "' and '" + dtEnd + "'";
        static string sqlByTime = " and datediff(dd,SmsTime,'"+dtStart+"')<=0 and datediff(dd,SmsTime,'"+dtEnd+"')>=0";
        static string dtStart;
        static string dtEnd;
        static string sqlDeletePlatform = "delete from SMSPlatform where smsid=";
        static string sqlDeleteOld = "delete from SMSOld where smsid=";
        static string sqlUpdateStatus = "update SMSPlatform set smsstatus=";
        static int resendSucceed = 0;
        static int resendFaild = 0;
        static int resendSaveSucceed = 0;
        static int resendSaveFaild = 0;

        void IsDtpUse(bool flag)
        {
            dtpStart.Enabled = flag;
            dtpEnd.Enabled = flag;
        }

        void Delete(int id)
        {
            GoldenLadyWS.Service service=new GoldenLadyWS.Service();

            if (ckbNotSent.Checked)
            {
                if (service.ExecuteCommandText(sqlUpdateStatus + 0 + " where smsid=" + id) > 0)//更改状态为取消发送
                {
                    if (service.ExecuteCommandText(sqlDeletePlatform + id) <= 0)//删除未发送的短信
                    {
                        MessageBox.Show("删除失败！");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("更新状态失败！");
                    return;
                }
            }
            else
            {
                if (service.ExecuteCommandText(sqlDeleteOld + id) <= 0)//删除短信历史记录
                {
                    MessageBox.Show("删除失败！");
                    return;
                }
            }
        }

        private void ckbAllTime_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAllTime.Checked)
            {
                IsDtpUse(false);
                sqlByTime = "";
            }
            else
            {
                IsDtpUse(true);
                //sqlByTime = " and CAST(smstime as datetime) between '" + dtStart + "' and '" + dtEnd + "'";
                sqlByTime = " and datediff(dd,SmsTime,'" + dtStart + "')<=0 and datediff(dd,SmsTime,'" + dtEnd + "')>=0";
            }
        }

        void BindDgv(string commandtext)//重新根据传入的SQL语句绑定数据
        {
            GoldenLadyWS.Service service = new GoldenLadyWS.Service();
            string keywords = txtKey.Text.Trim();
            commandtext += " and (customername like '%"+keywords+"%' or smsphone like '%"+keywords+"%' or smscontent like '%"+keywords+"%' or name like '%"+keywords+"%' or employeeno like '%"+keywords+"%' or customerno like '"+keywords+"')";
            //dtStart = dtpStart.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            //dtEnd = dtpEnd.Value.ToString("yyyy-MM-dd")+" 23:59:59";
            dtStart = dtpStart.Value.Date.ToString();
            dtEnd = dtpStart.Value.Date.ToString();
            if (ckbAllTime.Checked)
            {
                sqlByTime = "";
            }
            else
            {
                //sqlByTime = " and CAST(smstime as datetime) between '" + dtStart + "' and '" + dtEnd + "'";
                sqlByTime = " and datediff(dd,SmsTime,'" + dtStart + "')<=0 and datediff(dd,SmsTime,'" + dtEnd + "')>=0";
            }
            commandtext += sqlByTime;

            if (ckbAllTime.Checked)//所有时间段
            {
                DataSet ds = service.GetDataSet(commandtext);
                dgvSearchResult.DataSource = ds.Tables[0];
            }
            else
            {
                string test = commandtext + sqlByTime;
                DataSet ds = service.GetDataSet(commandtext);
                dgvSearchResult.DataSource = ds.Tables[0];
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ckbNotSent.Checked && !ckbSucceed.Checked && !ckbFailed.Checked && !ckbCancel.Checked)//未发送
            {
                BindDgv(sqlPlatform);
            }
            else if (ckbSucceed.Checked && !ckbFailed.Checked && !ckbNotSent.Checked && !ckbCancel.Checked)//成功
            {
                BindDgv(sqlOld+" and smsstatus=1");
            }
            else if (ckbFailed.Checked && !ckbSucceed.Checked && !ckbNotSent.Checked && !ckbCancel.Checked)//失败
            {
                BindDgv(sqlOld+" and smsstatus=2");
            }
            else if(ckbCancel.Checked && !ckbSucceed.Checked && !ckbFailed.Checked && !ckbNotSent.Checked)//取消
            {
                BindDgv(sqlOld+" and smsstatus=0");
            }
            else if (ckbSucceed.Checked && ckbFailed.Checked && !ckbNotSent.Checked && !ckbCancel.Checked)//成功+失败
            {
                BindDgv(sqlOld + " and (smsstatus=1 or smsstatus=2)");
            }
            else if (ckbSucceed.Checked && ckbFailed.Checked && !ckbNotSent.Checked && ckbCancel.Checked)//成功+取消
            {
                BindDgv(sqlOld+" and (smsstatus=1 or smsstatus=0)");
            }
            else if (!ckbSucceed.Checked && ckbFailed.Checked && !ckbNotSent.Checked && ckbCancel.Checked)//失败+取消
            {
                BindDgv(sqlOld+" and (smsstatus=2 or smsstatus=0)");
            }
            else if (ckbSucceed.Checked && ckbFailed.Checked && !ckbNotSent.Checked && ckbCancel.Checked)//成功+失败+取消
            {
                BindDgv(sqlOld);
            }
            grbResult.Text = "查询结果 共" + dgvSearchResult.Rows.Count.ToString() + "条，选中"+dgvSearchResult.SelectedRows.Count.ToString()+"条";
        }

        void ChangeNotSendCheckStatus()
        {
            if (ckbSucceed.Checked || ckbFailed.Checked || ckbCancel.Checked)
            {
                ckbNotSent.Checked = false;
            }
            else
            {
                ckbNotSent.Checked = true;
            }
        }

        private void ckbSucceed_CheckedChanged(object sender, EventArgs e)
        {
            ChangeNotSendCheckStatus();
        }

        private void ckbFailed_CheckedChanged(object sender, EventArgs e)
        {
            ChangeNotSendCheckStatus();
        }

        private void ckbNotSent_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNotSent.Checked)
            {
                ckbSucceed.Checked = false;
                ckbFailed.Checked = false;
                ckbCancel.Checked = false;
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSearchResult.SelectedRows.Count; i++)
            {
                Delete(Convert.ToInt32(dgvSearchResult.SelectedRows[i].Cells["id"].Value.ToString()));
            }
            MessageBox.Show("删除成功！");
            btnSearch_Click(null, null);
        }

        private void ckbCancel_CheckedChanged(object sender, EventArgs e)
        {
            ChangeNotSendCheckStatus();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Value < dtpStart.Value)
            {
                dtpEnd.Value = dtpStart.Value;
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                dtpStart.Value = dtpEnd.Value;
            }
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void dgvSearchResult_SelectionChanged(object sender, EventArgs e)
        {
            grbResult.Text = "查询结果 共" + dgvSearchResult.Rows.Count.ToString() + "条，选中" + dgvSearchResult.SelectedRows.Count.ToString() + "条";
        }

        private void tsmiResend_Click(object sender, EventArgs e)//add by wujianbo 20110808，短信重发
        {
            if (MessageBox.Show("确定要重新发送？", "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < dgvSearchResult.SelectedRows.Count; i++)
                    {
                        string result = ClientSide.Sms.app.fSendSMS(dgvSearchResult.SelectedRows[i].Cells[5].Value.ToString(), dgvSearchResult.SelectedRows[i].Cells[4].Value.ToString(), "5", Information.CurrentUser.EmployeeNO, "无");
                        //string result = "发送成功";
                        if (result == "发送成功")
                        {
                            string sqlTemp = "update SMSOld set smsstatus=1,employeeno='" + Information.CurrentUser.EmployeeNO + "',smstime='" + DateTime.Now.ToString() + "' where smsid=" + int.Parse(dgvSearchResult.SelectedRows[i].Cells[0].Value.ToString());
                            if (ErpWs.ExecuteCommandText(sqlTemp) > 0)
                            {
                                resendSaveSucceed++;
                            }
                            else
                            {
                                resendSaveFaild++;
                            }
                            resendSucceed++;
                        }
                        else
                        {
                            resendFaild++;
                        }
                    }
                    MessageBox.Show("重新发送执行完毕，发送成功" + resendSucceed.ToString() + "条，失败" + resendFaild.ToString() + "条；保存成功" + resendSaveSucceed.ToString() + "条，失败" + resendSaveFaild.ToString() + "条");
                    resendSucceed = 0;
                    resendFaild = 0;
                    resendSaveSucceed = 0;
                    resendSaveFaild = 0;
                    btnSearch_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "出错啦！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cms_Opened(object sender, EventArgs e)
        {
            if (ckbNotSent.Checked)
            {
                tsmiResend.Enabled = false;
            }
            else
            {
                tsmiResend.Enabled = true;
            }
        }

    }
}
