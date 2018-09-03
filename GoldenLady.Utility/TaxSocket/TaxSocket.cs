using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace GoldenLady.Utility.TaxSocket
{
    #region 税务登记内容
    public class TaxRegistrationContent
    {
        private string _id;
        /// <summary>
        /// 业务ID
        /// </summary>
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }

        private string _nsrbm;
        /// <summary>
        /// 纳税人编码
        /// </summary>
        public string nsrbm
        {
            set { _nsrbm = value; }
            get { return _nsrbm; }
        }

        #region 业务ID1002
        private string _swjgmc;
        /// <summary>
        /// 税务机关名称
        /// </summary>
        public string swjgmc
        {
            set { _swjgmc = value; }
            get { return _swjgmc; }
        }

        private string _swjgdm;
        /// <summary>
        /// 税务机关代码
        /// </summary>
        public string swjgdm
        {
            set { _swjgdm = value; }
            get { return _swjgdm; }
        }

        private string _nsrmc;
        /// <summary>
        /// 纳税人名称
        /// </summary>
        public string nsrmc
        {
            set { _nsrmc = value; }
            get { return _nsrmc; }
        }

        private string _nsrsbh;
        /// <summary>
        /// 纳税人识别号
        /// </summary>
        public string nsrsbh
        {
            set { _nsrsbh = value; }
            get { return _nsrsbh; }
        }
        #endregion

        #region 业务ID1002
        private string _fpdm;
        /// <summary>
        /// 发票代码
        /// </summary>
        public string fpdm
        {
            set { _fpdm = value; }
            get { return _fpdm; }
        }
        #endregion

        #region 业务ID1003
        private string _hymc;
        /// <summary>
        /// 行业名称
        /// </summary>
        public string hymc
        {
            set { _hymc = value; }
            get { return _hymc; }
        }

        private string _hybm;
        /// <summary>
        /// 行业编码
        /// </summary>
        public string hybm
        {
            set { _hybm = value; }
            get { return _hybm; }
        }

        private string _fpzlbm;
        /// <summary>
        /// 发票种类编码
        /// </summary>
        public string fpzlbm
        {
            set { _fpzlbm = value; }
            get { return _fpzlbm; }
        }

        private string[] _pmmc;
        /// <summary>
        /// 品目名称
        /// </summary>
        public string[] pmmc
        {
            set { _pmmc = value; }
            get { return _pmmc; }
        }

        private string[] _pmbm;
        /// <summary>
        /// 品目编码
        /// </summary>
        public string[] pmbm
        {
            set { _pmbm = value; }
            get { return _pmbm; }
        }

        private string[] _zmdm;
        /// <summary>
        /// 子目代码
        /// </summary>
        public string[] zmdm
        {
            set { _zmdm = value; }
            get { return _zmdm; }
        }
        #endregion
    }
    #endregion

    public class Tax
    {
        private string _msg;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg
        {
            set { _msg = value; }
            get { return _msg; }
        }

        /// <summary>
        /// 地税服务器信息
        /// </summary>
        private TaxServerInfo _TaxServerInfo = new TaxServerInfo();
        /// <summary>
        /// 纳税人信息
        /// </summary>
        public TaxRegistrationContent _TaxRegistrationContent = new TaxRegistrationContent();
        /// <summary>
        /// 收银信息
        /// </summary>
        public TaxCashContent _TaxCashContent = new TaxCashContent();
        /// <summary>
        /// 实例化地税Socket
        /// </summary>
        /// <param name="taxServerInfo">税务服务器IP和端口</param>
        public Tax(TaxServerInfo taxServerInfo)
        {
            this._TaxServerInfo = taxServerInfo;
        }

        #region 初始地税信息

        #region 获取纳税人信息001
        /// <summary>
        /// 获取纳税人所有信息[获取纳税人信息+获取发票信息+获取品目信息]
        /// </summary>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public TaxRegistrationContent GetTaxData(string nsrbm,ref string strMsg)
        {
            _TaxRegistrationContent.nsrbm = nsrbm;

            string strMsg1001 = "";
            bool breturn1001 = GetTaxID1001(ref strMsg1001);

            string strMsg1002 = "";
            bool breturn1002 = GetTaxID1002(ref strMsg1002);

            string strMsg1003 = "";
            bool breturn1003 = GetTaxID1003(ref strMsg1003);

            strMsg = strMsg1001 + "\n" + strMsg1002 + "\n" + strMsg1003;
            if (breturn1001 && breturn1002 && breturn1003)
            {
                return _TaxRegistrationContent;
            }
            else
            {
                return new TaxRegistrationContent();
            }
        }

        /// <summary>
        /// 获取纳税人信息
        /// </summary>
        private bool GetTaxID1001(ref string strMsg)
        {
            return SendTax_ID_1001(ref strMsg);
        }
        #endregion

        #region 获取发票信息002
        /// <summary>
        /// 获取发票信息
        /// </summary>
        private bool GetTaxID1002(ref string strMsg)
        {
            return SendTax_ID_1002(ref strMsg);
        }
        #endregion

        #region 获取品目信息003
        /// <summary>
        /// 获取品目信息
        /// </summary>
        private bool GetTaxID1003(ref string strMsg)
        {
            return SendTax_ID_1003(ref strMsg);
        }
        #endregion



        #endregion

        #region 发送/接收信息

        /// <summary>
        /// 发送/接收信息
        /// </summary>
        /// <param name="strSend">发送内容</param>
        /// <param name="strRecv">接收内容</param>
        /// <param name="strMsg">错误信息</param>
        /// <returns></returns>
        private bool SendTax(string strSend,ref string strRecv,ref string strMsg)
        {
            string ip = _TaxServerInfo.ServerIP;
            int port = Int32.Parse(_TaxServerInfo.ServerPort);
            IPEndPoint ipe;
            try
            {
                ipe = new IPEndPoint(IPAddress.Parse(ip), port);
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
            }
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(ipe);
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
            }
            try
            {
                //发送信息
                byte[] sendByte = Encoding.GetEncoding("GB2312").GetBytes(strSend);
                socket.Send(sendByte);
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
            }
            try
            {
                //while (true)
                //{
                //    //接收信息
                //    byte[] recvByte = new byte[1024];
                //    //int ibyte = socket.Receive(recvByte);
                //    //strRecv += Encoding.GetEncoding("GB2312").GetString(recvByte, 0, ibyte);
                //    int ibyte = socket.Receive(recvByte, recvByte.Length, 0);
                //    if (ibyte > 0)
                //    {
                //        strRecv += Encoding.GetEncoding("GB2312").GetString(recvByte, 0, ibyte);
                //    }
                //    else
                //    {
                //        break;
                //    }
                    
                //    System.Threading.Thread.Sleep(20);
                //}
                bool complete = false;
                bool TimeOver = false;
                TimeSpan tsEnd = new TimeSpan(DateTime.Now.Ticks) + new TimeSpan(0, 0, 20);
                do
                {
                    //接收信息
                    byte[] recvByte = new byte[1024 * 8];
                    int ibyte = socket.Receive(recvByte, recvByte.Length, SocketFlags.None);
                    if (ibyte > 0)
                    {
                        strRecv += Encoding.GetEncoding("GB2312").GetString(recvByte, 0, ibyte);
                    }
                    try
                    {
                        XmlDocument xdTemp = new XmlDocument();
                        xdTemp.LoadXml(strRecv);
                        complete = true;
                    }
                    catch
                    {
                        complete = false;
                    }
                    System.Threading.Thread.Sleep(1);
                    TimeSpan ts = new TimeSpan(DateTime.Now.Ticks);
                    if (ts > tsEnd)
                    {
                        TimeOver = true;
                    }
                } while (!complete && !TimeOver);
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
            }
            finally
            {
                socket.Close();
            }
            return true;
        }

        #endregion

        #region 业务操作

        #region XML中特殊字符进行处理

        /// <summary>
        /// 特殊字符处理
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string CheckSendText(string str)
        {
            for (int i = 0; i < GetReplaceString().Count; i++)
            {
                str = str.Replace(GetReplaceString()[i][0], GetReplaceString()[i][1]);
            }
            return str;
        }

        private List<string[]> GetReplaceString()
        {
            List<string[]> ReplaceString = new List<string[]>();
            //34【"】换成【”】，38【&】换成【＆】，39【'】换成【’】，60【<】换成【《】，62【>】换成【》】，92【\】换成【＼】
            ReplaceString.Add(new string[] { "\"", "”" });
            ReplaceString.Add(new string[] { "&", "＆" });
            ReplaceString.Add(new string[] { "'", "’" });
            ReplaceString.Add(new string[] { "<", "《" });
            ReplaceString.Add(new string[] { ">", "》" });
            ReplaceString.Add(new string[] { "\\", "＼" });
            return ReplaceString;
        }

        #endregion

        #region 纳税人信息
        private bool SendTax_ID_1001(ref string strMsg)
        {
            string sSendText = "<?xml version=\"1.0\" encoding=\"GB2312\" ?>";
            sSendText += "<root>";
            sSendText += "<item id=\"1001\" nsrbm=\"" + _TaxRegistrationContent.nsrbm + "\">";
            sSendText += "</item>";
            sSendText += "</root>";
            string strRecv = "";
            if (SendTax(sSendText, ref strRecv, ref strMsg))
            {
                return GetRecvData_ID_1001(strRecv, ref strMsg);
            }
            else
            {
                return true;
            }
        }

        private bool GetRecvData_ID_1001(string str, ref string strMsg)
        {
            bool state = false;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            XmlElement xe = xmlDoc.DocumentElement;
            XmlNodeList nodelst = xe.ChildNodes;
            //读取顶层所有属性值
            foreach (XmlNode node in nodelst)
            {
                XmlAttributeCollection xmlattrs = node.Attributes;
                if (Int32.Parse(node.Attributes["state"].Value.ToString()) > 0)
                {
                    _TaxRegistrationContent.swjgmc = node.Attributes["swjgmc"].Value.ToString();
                    _TaxRegistrationContent.swjgdm = node.Attributes["swjgdm"].Value.ToString();
                    _TaxRegistrationContent.nsrsbh = node.Attributes["nsrsbh"].Value.ToString();
                    _TaxRegistrationContent.nsrmc = node.Attributes["nsrmc"].Value.ToString();
                    //读取第二层所有属性值
                    //XmlNodeList nodelst2 = node.ChildNodes;
                    //int i = 0;
                    //foreach (XmlNode node2 in nodelst2)
                    //{
                    //    XmlAttributeCollection attrs2 = node2.Attributes;
                    //    foreach (XmlAttribute attr2 in attrs2)
                    //    {
                    //        listBox1.Items.Add(node2.Name + i.ToString() + " " + attr2.Name + " " + attr2.Value);
                    //    }
                    //    i++;
                    //}
                    state = true;
                }
                else
                {
                    _TaxRegistrationContent.nsrbm = "";
                    state = false;
                    strMsg = "未读取到纳税人信息";
                }
            }
            return state;
        }
        #endregion

        #region 发票信息
        private bool SendTax_ID_1002(ref string strMsg)
        {
            string sSendText = "<?xml version=\"1.0\" encoding=\"GB2312\" ?>";
            sSendText += "<root>";
            sSendText += "<item id=\"1002\" nsrbm=\"" + _TaxRegistrationContent.nsrbm + "\">";
            sSendText += "</item>";
            sSendText += "</root>";
            string strRecv = "";
            if (SendTax(sSendText, ref strRecv, ref strMsg))
            {
                return GetRecvData_ID_1002(strRecv, ref strMsg);
            }
            else
            {
                return true;
            }
        }

        private bool GetRecvData_ID_1002(string str, ref string strMsg)
        {
            bool state = false;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            XmlElement xe = xmlDoc.DocumentElement;
            XmlNodeList nodelst = xe.ChildNodes;
            //读取顶层所有属性值
            foreach (XmlNode node in nodelst)
            {
                //XmlAttributeCollection xmlattrs = node.Attributes;
                if (Int32.Parse(node.Attributes["state"].Value.ToString()) > 0)
                {
                    //读取第二层所有属性值
                    XmlNodeList nodelst2 = node.ChildNodes;
                    foreach (XmlNode node2 in nodelst2)
                    {
                        //XmlAttributeCollection attrs2 = node2.Attributes;
                        _TaxRegistrationContent.fpdm = node2.Attributes["fpdm"].Value.ToString();
                        _TaxRegistrationContent.fpzlbm = node2.Attributes["fpzlbm"].Value.ToString();
                        state = true;
                        break;
                    }
                }
                else
                {
                    state = false;
                    strMsg = "未读取到发票信息【发票种类】";
                }
            }
            return state;
        }
        #endregion

        #region 品目信息
        private bool SendTax_ID_1003(ref string strMsg)
        {
            string sSendText = "<?xml version=\"1.0\" encoding=\"GB2312\" ?>";
            sSendText += "<root>";
            sSendText += "<item id=\"1003\" nsrbm=\"" + _TaxRegistrationContent.nsrbm + "\">";
            sSendText += "</item>";
            sSendText += "</root>";
            string strRecv = "";
            if (SendTax(sSendText, ref strRecv, ref strMsg))
            {
                return GetRecvData_ID_1003(strRecv, ref strMsg);
            }
            else
            {
                return true;
            }
        }

        private bool GetRecvData_ID_1003(string str, ref string strMsg)
        {
            bool state = false;

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(str);
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
                return false;
            }
            XmlElement xe = xmlDoc.DocumentElement;
            XmlNodeList nodelst = xe.ChildNodes;
            //读取顶层所有属性值
            foreach (XmlNode node in nodelst)
            {
                //XmlAttributeCollection xmlattrs = node.Attributes;
                if (Int32.Parse(node.Attributes["state"].Value.ToString()) > 0)
                {
                    List<string[]> pmInfo = new List<string[]>();
                    //读取第二层所有属性值
                    XmlNodeList nodelst2 = node.ChildNodes;
                    foreach (XmlNode node2 in nodelst2)
                    {
                        //XmlAttributeCollection attrs2 = node2.Attributes;
                        if (!node2.Attributes["hymc"].Value.ToString().Contains("服务业")) continue;
                        _TaxRegistrationContent.hymc = node2.Attributes["hymc"].Value.ToString();
                        _TaxRegistrationContent.hybm = node2.Attributes["hybm"].Value.ToString();
                        pmInfo.Add(new string[] { node2.Attributes["pmmc"].Value.ToString(), node2.Attributes["pmbm"].Value.ToString(), node2.Attributes["zmbm"].Value.ToString() });
                    }
                    //将暂存至List<>中的数据存至品目信息中
                    _TaxRegistrationContent.pmmc = new string[pmInfo.Count];
                    _TaxRegistrationContent.pmbm = new string[pmInfo.Count];
                    _TaxRegistrationContent.zmdm = new string[pmInfo.Count];
                    for (int i = 0; i < pmInfo.Count; i++)
                    {
                        _TaxRegistrationContent.pmmc[i] = pmInfo[i][0].ToString();
                        _TaxRegistrationContent.pmbm[i] = pmInfo[i][1].ToString();
                        _TaxRegistrationContent.zmdm[i] = pmInfo[i][2].ToString();
                        
                        state = true;
                    }
                }
                else
                {
                    state = false;
                    strMsg = "未读取到品目信息";
                }
            }
            return state;
        }
        #endregion

        /// <summary>
        /// 税务开票
        /// </summary>
        /// <param name="strMsg">错误信息</param>
        /// <returns></returns>
        public bool SendTax_ID_2001(TaxCashContent taxCashContent, ref string strMsg)
        {
            this._TaxCashContent = taxCashContent;
            string strbz = _TaxCashContent.bz.Length <= 50 ? _TaxCashContent.bz : _TaxCashContent.bz.Substring(0, 50);
            string sSendText = "<?xml version=\"1.0\" encoding=\"GB2312\" ?>";
            sSendText += "<root>";
            sSendText += "<item id=\"2001\" fpdm=\"" + _TaxRegistrationContent.fpdm + "\" fphm=\"" + _TaxCashContent.fphm + "\" fpzlbm=\"" + _TaxRegistrationContent.fpzlbm + "\" fkfmc=\"" + _TaxCashContent.fkfmc + "\" bz=\"" + CheckSendText(strbz) + "\" kpr=\"" + _TaxCashContent.kpr + "\" nsrbm=\"" + _TaxRegistrationContent.nsrbm + "\" kprq=\"" + _TaxCashContent.kprq + "\" hymc=\"" + _TaxRegistrationContent.hymc + "\" hybm=\"" + _TaxRegistrationContent.hybm + "\" fkfzjlx=\"无\" fkfzjhm=\"无\">";
            for (int i = 0; i < _TaxCashContent.auto.Length; i++)
            {
                sSendText += "<list  auto=\"" + _TaxCashContent.auto[i] + "\" fpdm=\"" + _TaxRegistrationContent.fpdm + "\" fphm=\"" + _TaxCashContent.fphm + "\" pmmc=\"" + _TaxCashContent.pmmc[i] + "\" pmbm=\"" + _TaxCashContent.pmbm[i] + "\" sl=\"" + _TaxCashContent.sl[i] + "\" dj=\"" + _TaxCashContent.dj[i] + "\" je=\"" + _TaxCashContent.je[i] + "\" zmdm=\"" + _TaxCashContent.zmdm[i] + "\">";
            }
            sSendText += "</list>";
            sSendText += "</item>";
            sSendText += "</root>";
            string strRecv = "";
            if (SendTax(sSendText, ref strRecv, ref strMsg))
            {
                return GetRecvData_State(strRecv, ref strMsg);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取XML中state属性值
        /// </summary>
        /// <param name="str">需要解析的字符串</param>
        /// <param name="strMsg">错误信息</param>
        /// <returns></returns>
        private bool GetRecvData_State(string str,ref string strMsg)
        {
            //str = "<?xml version=\"1.0\" encoding=\"GB2312\" ?>\r\n<root>\r\n<item  id=\"2001\" state=\"1\" msg=\"OK\">\r\n</item>\r\n</root>\r\n";//暂时设置返回值
            bool state = false;
            string msg = "";

            XmlDocument myDoc = new XmlDocument();
            myDoc.LoadXml(str);
            XmlNodeList xnl = myDoc.SelectNodes("//item");
            foreach (XmlNode xn in xnl)
            {
                //通过Attributes获得属性名为state、msg的属性
                state = Int32.Parse(xn.Attributes["state"].Value) > 0 ? true : false;
                msg = xn.Attributes["msg"].Value;
            }
            strMsg = msg;
            return state;
        }

        #endregion

        #region 发票作废
        /// <summary>
        /// 发票作废
        /// </summary>
        /// <param name="_fpdm">发票代码</param>
        /// <param name="_fphm">发票号码</param>
        /// <param name="_fpzt">发票状态：2、正常发票作废</param>
        /// <param name="_kpr">开票员名称</param>
        /// <param name="_zfrq">作废日期(yyyymmddhhmmss)</param>
        /// <param name="_nsrbm">纳税人编码</param>
        /// <param name="_fpzlbm">发票种类编码</param>
        /// <returns></returns>
        public bool SendTax_ID_3001(string _fpdm, string _fphm, string _fpzt, string _kpr, string _zfrq, string _nsrbm, string _fpzlbm, ref string strMsg)
        {
            string strSendXml = "<?xml version=\"1.0\" encoding=\"GB2312\" ?>\r\n";
            strSendXml += "<root>\r\n";
            strSendXml += "<item id=\"3001\" fpdm=\"" + _fpdm + "\" fphm=\"" + _fphm + "\" fpzt=\"" + _fpzt + "\" kpr=\"" + _kpr + "\" zfrq=\"" + _zfrq + "\" nsrbm=\"" + _nsrbm + "\" fpzlbm=\"" + _fpzlbm + "\">\r\n";
            strSendXml += "</item>\r\n";
            strSendXml += "</root>\r\n";
            string strRec = String.Empty;
            //string strMsg = String.Empty;
            if (SendTax(strSendXml, ref strRec, ref strMsg))
            {
                return GetRecvData_State(strRec, ref strMsg);
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 发票冲红
        /// <summary>
        /// 发票冲红
        /// </summary>
        /// <param name="yfpdm">原发票代码</param>
        /// <param name="yfphm">原发票号码</param>
        /// <param name="chfpdm">冲红发票代码</param>
        /// <param name="chfphm">冲红发票号码</param>
        /// <param name="fpzlbm">发票种类编码</param>
        /// <param name="nsrbm">纳税人编码</param>
        /// <param name="kpr">开票员名称</param>
        /// <param name="chrq">冲红日期(yyyymmddhhmmss)</param>
        /// <param name="strMsg">信息</param>
        /// <returns>是否成功（true or false）</returns>
        public bool SendTax_ID_5001(string yfpdm, string yfphm, string chfpdm, string chfphm, string fpzlbm, string nsrbm, string kpr, string chrq, ref string strMsg)
        {
            string strSendXml = "<?xml version=\"1.0\" encoding=\"GB2312\" ?>\r\n";
            strSendXml += "<root>\r\n";
            strSendXml += "<item id=\"5001\" yfpdm=\"" + yfpdm + "\" yfphm=\"" + yfphm + "\"  chfpdm=\"" + chfpdm + "\" chfphm=\"" + chfphm + "\" fpzlbm=\"" + fpzlbm + "\" kpr=\"" + kpr + "\"   nsrbm=\"" + nsrbm + "\" chrq=\"" + chrq + "\">\r\n";
            strSendXml += "</item>\r\n";
            strSendXml += "</root>\r\n";
            string strRec = String.Empty;
            if (SendTax(strSendXml,ref strRec,ref strMsg))
            {
                return GetRecvData_State(strRec, ref strMsg);
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
