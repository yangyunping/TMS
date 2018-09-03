using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 套系
    /// </summary>
    public sealed class Suite
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public SuiteType Type { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <param name="suiteTypes">套系类型列表</param>
        /// <returns>构造好的对象</returns>
        public static Suite FromDataRow(DataRow dr, IEnumerable<SuiteType> suiteTypes)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new Suite
            {
                Name = dr["SuiteName"].SafeDbString(),
                No = dr["SuiteNO"].SafeDbString(),
                Type = suiteTypes.FirstOrDefault(st => st.Value == dr["SuiteTypeNO"].SafeDbString()),
                Price = dr["SuitePrice"].SafeDbDecimal(),
                IsDeleted = dr["IsDelete"].SafeDbBoolean()
            };
        }
        /// <summary>
        /// 表示未知或未选择
        /// </summary>
        public static Suite Unknown { get { return null; }}
    }
}