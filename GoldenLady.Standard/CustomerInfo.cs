using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 客户信息
    /// </summary>
    public sealed class CustomerInfo
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerNo { get; set; }
        /// <summary>
        /// 先生名称
        /// </summary>
        public string CustomerName1 { get; set; }
        /// <summary>
        /// 小姐名称
        /// </summary>
        public string CustomerName2 { get; set; }
        /// <summary>
        /// 手机号1
        /// </summary>
        public string MobilePhone1 { get; set; }
        /// <summary>
        /// 手机号2
        /// </summary>
        public string MobilePhone2 { get; set; }

        /// <summary>
        /// 从数据列构造
        /// </summary>
        /// <param name="dr">数据列</param>
        /// <returns>构造后的对象</returns>
        public static CustomerInfo FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据列参数为空！");
            }
            return new CustomerInfo
            {
                CustomerNo = dr["CustomerNO"].SafeDbString(),
                CustomerName1 = dr["CustomerName1"].SafeDbString(),
                CustomerName2 = dr["CustomerName2"].SafeDbString(),
                MobilePhone1 = dr["MobilePhone1"].SafeDbString(),
                MobilePhone2 = dr["MobilePhone2"].SafeDbString()
            };
        }
    }
}