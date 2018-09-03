using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 员工
    /// </summary>
    public sealed class Employee
    {
        private static Employee _none;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public Department Department { get; set; }
        /// <summary>
        /// 从数据列构造
        /// </summary>
        /// <param name="dr">数据列</param>
        /// <returns>构造后的对象</returns>
        public static Employee FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据列参数为空！");
            }
            return new Employee
            {
                Name = dr["EmployeeName"].SafeDbString(),
                No = dr["EmployeeNo"].SafeDbString(),
                Department = new Department
                {
                    Name = dr["DepartmentName"].SafeDbString(), No = dr["DepartmentNo"].SafeDbString()
                }
            };
        }

        /// <summary>
        /// 未知或未选择
        /// </summary>
        public static Employee None
        {
            get
            {
                return _none ?? (_none = new Employee
                {
                    Name = @"无"
                });
            }
        }
    }
}