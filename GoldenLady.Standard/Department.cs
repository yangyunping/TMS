using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 部门
    /// </summary>
    public sealed class Department
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
        /// 父部门编号
        /// </summary>
        public string ParentDepartmentNo { get; set; }
        /// <summary>
        /// 从数据列构造
        /// </summary>
        /// <param name="dr">数据列</param>
        /// <returns>构造后的对象</returns>
        public static Department FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据列参数为空！");
            }
            return new Department
            {
                Name = dr["DepartmentName"].SafeDbString(),
                No = dr["DepartmentNo"].SafeDbString(),
                ParentDepartmentNo = dr["ParDepartmentNo"].SafeDbString()
            };
        }
    }
}