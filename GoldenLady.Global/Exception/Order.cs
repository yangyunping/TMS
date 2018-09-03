using System.Text;

namespace GoldenLady.Global.Exception
{
    /// <summary>
    /// 订单类异常类型
    /// </summary>
    public enum OrderExceptionType : byte
    {
        /// <summary>
        /// 普通异常类型，用于不需要特殊捕获并处理此种异常的时候使用，通常只是传达一个错误Message时使用
        /// </summary>
        Normal,
        /// <summary>
        /// 获取订单状态信息失败
        /// </summary>
        GetOrderStateInfoFailed,
        /// <summary>
        /// 未缴纳定金
        /// </summary>
        NoCashPaid,
        /// <summary>
        /// 已经排过摄控
        /// </summary>
        ShootScheduled
    }

    /// <summary>
    /// 订单类异常
    /// </summary>
    public sealed class OrderException : System.Exception
    {
        private static OrderException _getOrderStateInfoFailed;
        private static OrderException _noCashPaid;
        private static OrderException _shootScheduled;

        /// <summary>
        /// 异常类型
        /// </summary>
        public OrderExceptionType ExceptionType
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
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="type">异常类型</param>
        /// <param name="message">提示消息</param>
        public OrderException(OrderExceptionType type, string message)
        {
            ExceptionType = type;
            Message = message;
        }

        /// <summary>
        /// 获取订单状态信息失败
        /// </summary>
        public static OrderException GetOrderStateInfoFailed
        {
            get
            {
                if(null != _getOrderStateInfoFailed)
                    return _getOrderStateInfoFailed;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"获取订单状态信息失败！");
                sb.AppendLine(HintString.PleaseConnectAdmin);
                _getOrderStateInfoFailed = new OrderException(OrderExceptionType.GetOrderStateInfoFailed, sb.ToString());
                return _getOrderStateInfoFailed;
            }
        }
        /// <summary>
        /// 未缴纳定金
        /// </summary>
        public static OrderException NoCashPaid
        {
            get
            {
                return _noCashPaid ?? (_noCashPaid = new OrderException(OrderExceptionType.NoCashPaid, @"该订单尚未缴纳定金！"));
            }
        }
        /// <summary>
        /// 已经安排摄控
        /// </summary>
        public static OrderException ShootScheduled
        {
            get
            {
                return _shootScheduled ?? (_shootScheduled = new OrderException(OrderExceptionType.ShootScheduled, @"该订单已经安排过摄控！"));
            }
        }
    }
}
