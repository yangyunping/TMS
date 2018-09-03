using System.Drawing;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 订单信息
    /// </summary>
    public sealed class OrderInfo
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 发票号
        /// </summary>
        public string FPH { get; set; }
        /// <summary>
        /// 接单人员
        /// </summary>
        public Employee OrderEmployee { get; set; }
        /// <summary>
        /// 接单人员2
        /// </summary>
        public Employee OrderEmployee2 { get; set; }
        /// <summary>
        /// 订单类别
        /// </summary>
        public OrderType OrderType { get; set; }
        /// <summary>
        /// 摄影类型
        /// </summary>
        public string ShootType { get; set; }
        /// <summary>
        /// 怀孕情况
        /// </summary>
        public Pregnant Pregnant { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public OrderSource OrderSource { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string OrderMemory { get; set; }
        /// <summary>
        /// 套系
        /// </summary>
        public Suite Suite { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public OrderPrice Price { get; set; }
        /// <summary>
        /// 客人信息
        /// </summary>
        public CustomerInfo CustomerInfo { get; set; }
        /// <summary>
        /// 客人素颜照
        /// </summary>
        public Image CustomerImage { get; set; }
    }
}