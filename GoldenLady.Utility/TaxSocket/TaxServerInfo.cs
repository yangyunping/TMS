namespace GoldenLady.Utility.TaxSocket
{
    public class TaxServerInfo
    {
        private string _ServerIP;
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerIP
        {
            set { _ServerIP = value; }
            get { return _ServerIP; }
        }
        private string _ServerPort;
        /// <summary>
        /// 服务器端口
        /// </summary>
        public string ServerPort
        {
            set { _ServerPort = value; }
            get { return _ServerPort; }
        }
    }
}
