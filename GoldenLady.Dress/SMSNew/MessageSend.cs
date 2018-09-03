using System;
using System.Collections.Generic;
using System.Text;
using GoldenLadyWS;
namespace GoldenLady.SMSNew
{
    public class MessageSend
    {
        Service ErpWs = new Service();
        /// <summary>
        /// 发送员工工资短信
        /// </summary>
        /// <param name="msgText">短信内容</param>
        /// <param name="phone">电话</param>
        /// <returns>结果</returns>
        public bool Message_SendEmployee(string msgText,string phone)
        {
            try
            {
                bool result = false;
                try
                {
                    ClientSide.Sms.GetApp(System.Windows.Forms.Application.StartupPath);
                }
                catch (Exception)
                {
                    ErpWs.InsetSendMessages1(phone, "该短信发送失败", "0", "员工工资短信", "");
                }

                if (ClientSide.Sms.app.fSendSMS(msgText, phone, "5", "", "") == "发送成功")//给先生发送信息
                {
                    //插入记录
                    ErpWs.InsetSendMessages1(phone, msgText.Trim(), "1", "员工工资短信", "");
                    result = true;

                }
                else
                {
                    //插入记录
                    ErpWs.InsetSendMessages1(phone, msgText.Trim(), "0", "员工工资短信", "先生");
                    result = false;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 短信发送公共方法  qiuqianquan 2013-01-07
        /// </summary>
        /// <param name="MessagesTextString">短信的内容</param>
        /// <param name="TelePhone">电话号码</param>
        /// <param name="EmployeeNo">员工编号</param>
        /// <param name="EmployeeName">员工姓名</param>
        /// <param name="CustomerNo">客户编号</param> 
        /// <param name="CustomerNameBoy">客户姓名</param> 
        /// <returns></returns>
        public bool Message_Send(string MessagesTextString, string[] TelePhone, string[] CustomerName, string choosetime, string ChooseAddress)
        {
            bool result = false;
            try
            {
                string M_S_Nan = "";
                string M_S_Nv = "";
                for (int i = 0; i < MessagesTextString.Length; i++)
                {
                    M_S_Nan = MessagesTextString.Replace("[姓名]", CustomerName[0] + " 先生");
                    M_S_Nv = MessagesTextString.Replace("[姓名]", CustomerName[1] + " 女士");

                    M_S_Nan = M_S_Nan.Replace("[时间]", choosetime);
                    M_S_Nv = M_S_Nv.Replace("[时间]", choosetime);

                    //M_S_Nan = M_S_Nan.Replace("[公司名称]", "金夫人集团");
                    //M_S_Nv = M_S_Nv.Replace("[公司名称]", "金夫人集团");

                    M_S_Nan = M_S_Nan.Replace("[详细地址]", ChooseAddress);
                    M_S_Nv = M_S_Nv.Replace("[详细地址]", ChooseAddress);
                }

                try
                {
                    ClientSide.Sms.GetApp(System.Windows.Forms.Application.StartupPath);
                }
                catch (Exception)
                {
                    ErpWs.InsetSendMessages(TelePhone[0], "该短信发送失败", "0", CustomerName[0].ToString(), "先生");
                }

                if (ClientSide.Sms.app.fSendSMS(M_S_Nan.Trim(), TelePhone[0], "5", "", "") == "发送成功")//给先生发送信息
                {
                    //插入记录
                    ErpWs.InsetSendMessages(TelePhone[0], M_S_Nan.Trim(), "1", CustomerName[0].ToString(), "先生");
                    result = true;

                }
                else
                {
                    //插入记录
                    ErpWs.InsetSendMessages(TelePhone[0], M_S_Nan.Trim(), "0", CustomerName[0].ToString(), "先生");
                    result = false;
                }

                if (ClientSide.Sms.app.fSendSMS(M_S_Nv.Trim(), TelePhone[1], "5", "", "") == "发送成功")//给小姐发送信息
                {
                    //插入记录
                     ErpWs.InsetSendMessages(TelePhone[1], M_S_Nv.Trim(), "1", CustomerName[1].ToString(), "女士");
                    result = true;
                }
                else
                {
                    //插入记录
                     ErpWs.InsetSendMessages(TelePhone[1], M_S_Nv.Trim(), "0", CustomerName[1].ToString(), "女士");
                    result = false;
                }


                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="msgText">短信内容</param>
        /// <param name="phone">电话</param>
        /// <param name="smsType">什么短信</param>
        /// <returns>结果</returns>
        public  bool SendSms(string msgText, string phone,string smsType)
        {
            try
            {
                bool result = false;
                try
                {
                    ClientSide.Sms.GetApp(System.Windows.Forms.Application.StartupPath);
                }
                catch (Exception)
                {
                    ErpWs.InsetSendMessages1(phone, "短信发送失败", "0", smsType, "");
                }
                if (ClientSide.Sms.app.fSendSMS(msgText, phone, "5", "", "") == "发送成功")
                {
                    //插入记录
                    ErpWs.InsetSendMessages1(phone, msgText.Trim(), "1", smsType, "");
                    result = true;
                }
                else
                {
                    //插入记录
                    ErpWs.InsetSendMessages1(phone, msgText.Trim(), "0", smsType, "");
                    result = false;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
