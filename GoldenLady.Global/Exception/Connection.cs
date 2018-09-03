namespace GoldenLady.Global.Exception
{
    /// <summary>
    /// 连接类异常类型
    /// </summary>
    public enum ConnectionExeptionType : byte
    {
        /// <summary>
        /// 线路未选择
        /// </summary>
        LineNotSelected
    }

    /// <summary>
    /// 连接类异常
    /// </summary>
    public sealed class ConnectionExeption : System.Exception
    {
        private static ConnectionExeption _lineNotSelected;

        /// <summary>
        /// 异常类型
        /// </summary>
        public ConnectionExeptionType ExeptionType
        {
            get;
            private set;
        }
        /// <summary>
        /// 提示消息
        /// </summary>
        public new string Message
        {
            get;
            private set;
        }

        static ConnectionExeption()
        {
            _lineNotSelected = null;
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="type">异常类型</param>
        /// <param name="message">提示消息</param>
        public ConnectionExeption(ConnectionExeptionType type, string message)
        {
            ExeptionType = type;
            Message = message;
        }

        /// <summary>
        /// 线路未选择
        /// </summary>
        public static ConnectionExeption LineNotSelected
        {
            get
            {
                return _lineNotSelected ?? (_lineNotSelected = new ConnectionExeption(ConnectionExeptionType.LineNotSelected, @"请选择连接线路！"));
            }
        }
    }
}