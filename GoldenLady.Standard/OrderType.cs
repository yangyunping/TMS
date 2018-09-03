namespace GoldenLady.Standard
{
    /// <summary>
    /// 订单类别
    /// </summary>
    public sealed class OrderType : KVPair<bool>
    {
        /// <summary>
        /// 禁止显式构造对象
        /// </summary>
        private OrderType() {}

        private static OrderType _online;
        private static OrderType _offline;

        /// <summary>
        /// 线上订单
        /// </summary>
        public static OrderType Online
        {
            get
            {
                return _online ?? (_online = new OrderType
                {
                    Name = @"线上订单",
                    Value = true
                });
            }
        }

        /// <summary>
        /// 线下订单
        /// </summary>
        public static OrderType Offline
        {
            get
            {
                return _offline ?? (_offline = new OrderType
                {
                    Name = @"线下订单",
                    Value = false
                });
            }
        }

        /// <summary>
        /// 未知
        /// </summary>
        public static OrderType Unknown
        {
            get { return null; }
        }

        /// <summary>
        /// 转换为OrderType对象
        /// </summary>
        /// <param name="isOnline">是否线上订单</param>
        /// <returns>构造好的OrderType对象</returns>
        public static OrderType Parse(bool isOnline)
        {
            return isOnline ? Online : Offline;
        }
    }
}