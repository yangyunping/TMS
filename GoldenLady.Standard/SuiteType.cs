using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 套系类型
    /// </summary>
    public sealed class SuiteType : KVPair<string>
    {
        /// <summary>
        /// 未知
        /// </summary>
        public static SuiteType Unknown { get { return null; } }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>构造好的对象</returns>
        public static SuiteType FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new SuiteType
            {
                Name = dr["SuiteTypeName"].SafeDbString(),
                Value = dr["SuiteTypeNO"].SafeDbString()
            };
        }
    }
}