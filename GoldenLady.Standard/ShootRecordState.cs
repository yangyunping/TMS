namespace GoldenLady.Standard
{
    /// <summary>
    /// 摄影记录状态
    /// </summary>
    public static class ShootRecordState
    {
        /// <summary>
        /// 已启用
        /// </summary>
        public static readonly byte Enabled = 0;
        /// <summary>
        /// 已删除
        /// </summary>
        public static readonly byte Deleted = 1;
        /// <summary>
        /// 已失效
        /// </summary>
        public static readonly byte Disabled = 2;
        /// <summary>
        /// 初始化
        /// </summary>
        public static readonly byte Init = 3;
    }
}