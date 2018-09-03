using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 订单更多信息
    /// </summary>
    public class MoreInfoItem
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public string Item { get; set; }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>构造的对象</returns>
        public static MoreInfoItem FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new MoreInfoItem
            {
                ID = dr["ID"].SafeDbInt32(),
                PID = dr["PID"].SafeDbInt32(),
                Item = dr["Item"].SafeDbString()
            };
        }
    }
}