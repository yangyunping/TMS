namespace GoldenLady.Standard.Dress
{
    /// <summary>
    /// 礼服信息
    /// LiuHaiyang
    /// 2017.4.25
    /// </summary>
    public class Dress
    {
        /// <summary>
        /// 礼服编号
        /// </summary>
        public string DressNo { get; set; }

        /// <summary>
        /// 性质编号（礼服类，配饰类）
        /// </summary>
        public string TypeNo { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 类别编号
        /// </summary>
        public string CategoryNo { get; set; }

        /// <summary>
        /// 颜色名称
        /// </summary>
        public string ColorName { get; set; }

        /// <summary>
        /// 上身款式名称
        /// </summary>
        public string UpperStyleName { get; set; }

        /// <summary>
        /// 下身款式名称
        /// </summary>
        public string LowerStyleName { get; set; }

        /// <summary>
        /// 上身材质名称
        /// </summary>
        public string UpperMaterialName { get; set; }

        /// <summary>
        /// 下身材质名称
        /// </summary>
        public string LowerMaterialName { get; set; }

        /// <summary>
        /// 装饰名称
        /// </summary>
        public string OrnamentalName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        public string AreaNo { get; set; }

        /// <summary>
        /// 用途名称
        /// </summary>
        public string UseName { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// 当前所在位置名称
        /// </summary>
        public string CurrentPositionName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 自编号
        /// </summary>
        public string CustomCode { get; set; }

        /// <summary>
        /// 购买人名称
        /// </summary>
        public string BuyerName { get; set; }

        /// <summary>
        /// 购买渠道
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 档次规格编号
        /// </summary>
        public string LevelNo { get; set; }

        /// <summary>
        /// 一直是false，貌似已弃用
        /// </summary>
        public bool DressOfShow { get; set; }

        /// <summary>
        /// 总使用次数统计
        /// </summary>
        public int NumOfUse { get; set; }

        /// <summary>
        /// 日使用次数上限
        /// </summary>
        public int NumOfUsedToday { get; set; }

        /// <summary>
        /// 预用次数
        /// </summary>
        public int NOTime { get; set; }

        /// <summary>
        /// 成本价格
        /// </summary>
        public decimal CostPrice { get; set; }

        /// <summary>
        /// 出租价格
        /// </summary>
        public decimal RentPrice { get; set; }

        /// <summary>
        /// 出售价格
        /// </summary>
        public decimal SalePrice { get; set; }
    }
}