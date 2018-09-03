namespace GoldenLady.Global.Exception
{
    /// <summary>
    /// SQL异常类型
    /// </summary>
    public static class SqlExceptionType
    {
        /// <summary>
        /// 连接失败
        /// </summary>
        public const int ConnectFailed = 1231;

        /// <summary>
        /// 插入值不符合外键约束
        /// </summary>
        public const int ForeignKeyCheckFailed = 547;

        /// <summary>
        /// 插入值主键重复
        /// </summary>
        public const int PrimaryKeyDuplicated = 2627;

        /// <summary>
        /// 礼服条码不存在
        /// </summary>
        public const int DressBarCodeNotExists = 13001;
    }
}
