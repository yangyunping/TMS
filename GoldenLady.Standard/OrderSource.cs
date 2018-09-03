using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 订单来源
    /// </summary>
    public sealed class OrderSource : KVPair<string>
    {
        /// <summary>
        /// 未知
        /// </summary>
        public static OrderSource Unknown
        {
            get { return null; }
        }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>构造好的对象</returns>
        public static OrderSource FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new OrderSource
            {
                Name = dr["ConfigValue"].SafeDbString(),
                Value = dr["ConfigNO"].SafeDbString()
            };
        }
    }
}