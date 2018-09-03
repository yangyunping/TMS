using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard.Dress
{
    /// <summary>
    /// 常见规则编号
    /// LiuHaiyang
    /// 2017.4.29
    /// </summary>
    public static class RuleNumbers
    {
        /// <summary>
        /// 位置
        /// </summary>
        public static readonly int Area = 1;
        /// <summary>
        /// 类别
        /// </summary>
        public static readonly int Type = 2;
        /// <summary>
        /// 颜色
        /// </summary>
        public static readonly int Color = 3;
        /// <summary>
        /// 款式
        /// </summary>
        public static readonly int Style = 4;
        /// <summary>
        /// 材料
        /// </summary>
        public static readonly int Material = 5;
        /// <summary>
        /// 装饰
        /// </summary>
        public static readonly int Ornamental = 6;
        /// <summary>
        /// 上身款式
        /// </summary>
        public static readonly int UpperStyle = 50;
        /// <summary>
        /// 下身款式
        /// </summary>
        public static readonly int LowerStyle = 51;
        /// <summary>
        /// 上身材质
        /// </summary>
        public static readonly int UpperMaterial = 75;
        /// <summary>
        /// 下身材质
        /// </summary>
        public static readonly int LowerMaterial = 76;
        /// <summary>
        /// 礼服用途
        /// </summary>
        public static readonly int Use = 260;
        /// <summary>
        /// 场馆
        /// </summary>
        public static readonly int Department = 104;

    }

    /// <summary>
    /// 规则集对象
    /// LiuHaiyang
    /// 2017.4.29
    /// </summary>
    public class RuleObject
    {
        /// <summary>
        /// 规则编号
        /// </summary>
        public int RuleNo { get; set; }

        /// <summary>
        /// 父规则编号
        /// </summary>
        public int ParentRuleNo { get; set; }

        /// <summary>
        /// 对象名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 对象绑定的编号（如位置对应的专业部编号）
        /// </summary>
        public string BindingNo { get; set; }
        /// <summary>
        /// 存储路径Tag
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>构造好的对象</returns>
        public static RuleObject FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new RuleObject
            {
                Name = dr["RuleName"].SafeDbString(),
                RuleNo = dr["RuleNumbers"].SafeDbInt32(),
                ParentRuleNo = dr["ParentRuleNumbers"].SafeDbInt32(),
                BindingNo = dr["BindingNO"].SafeDbString(),
                Tag  = dr["Tag"].SafeDbString()
            };
        }
    }
}