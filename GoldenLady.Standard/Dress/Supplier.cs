using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard.Dress
{
    /// <summary>
    /// 礼服供应商
    /// LiuHaiyang
    /// 2017.4.26
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact{ get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>构造好的对象</returns>
        public static Supplier FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new Supplier
            {
                Name = dr["SuppliersName"].SafeDbString(),
                No = dr["SuppliersNumbers"].SafeDbString(),
                Contact = dr["SuppliersContactInformation"].SafeDbString(),
                Address = dr["SuppliersAddress"].SafeDbString(),
                Note = dr["Notes"].SafeDbString()
            };
        }
    }
}