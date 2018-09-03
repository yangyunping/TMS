namespace GoldenLady.Standard
{
    /// <summary>
    /// 订单价格
    /// </summary>
    public sealed class OrderPrice
    {
        private decimal _disconut = 100m;
        /// <summary>
        /// 套系价格
        /// </summary>
        public decimal SuitePrice { get; set; }
        /// <summary>
        /// 加现
        /// </summary>
        public decimal Add { get; set; }
        /// <summary>
        /// 减现1
        /// </summary>
        public decimal Reduce1 { get; set; }
        /// <summary>
        /// 减现2
        /// </summary>
        public decimal Reduce2 { get; set; }        
        /// <summary>
        /// 减现3
        /// </summary>
        public decimal Reduce3 { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Disconut
        {
            get { return _disconut; }
            set { _disconut = value; }
        }
        /// <summary>
        /// 最终价格
        /// </summary>
        public decimal FinalPrice
        {
            get { return Add == decimal.MinusOne || Reduce1 == decimal.MinusOne || Reduce2 == decimal.MinusOne || Reduce3 == decimal.MinusOne || Disconut == decimal.MinusOne ? decimal.MinusOne : SuitePrice * Disconut / 100.00m + Add - Reduce1 - Reduce2 - Reduce3; }
        }
    }
}