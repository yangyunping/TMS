namespace GoldenLadyWS.Model
{
    /// <summary>
    /// 软件版本信息
    /// </summary>
    public sealed class EditionInformation
    {
        /// <summary>
        /// 版本编号
        /// </summary>
        public string EditionNO { get; set; }
        /// <summary>
        /// 版本名称
        /// </summary>
        public string EditionName { get; set; }
        /// <summary>
        /// 客户称谓1
        /// </summary>
        public string CustomerName1 { get; set; }
        /// <summary>
        /// 客户称谓2
        /// </summary>
        public string CustomerName2 { get; set; }
        /// <summary>
        /// 需要记录的日期
        /// </summary>
        public string MemorizeDay { get; set; }
    }
}