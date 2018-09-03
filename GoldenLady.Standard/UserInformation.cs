using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 存放登录用户信息的类
    /// </summary>
    public sealed class UserInformation
    {
        private Employee _employeeInfo;

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNO { get; set; }
        /// <summary>
        /// 员工登录用编号
        /// </summary>
        public string EmployeeNO2 { get; set; }
        /// <summary>
        /// 员工密码
        /// </summary>
        public string EmployeePassword { get; set; }
        /// <summary>
        /// 员工性别
        /// </summary>
        public string EmployeeSex { get; set; }
        /// <summary>
        /// 员工卡号
        /// </summary>
        public string CardNO { get; set; }
        /// <summary>
        /// 员工生日
        /// </summary>
        public DateTime EmployeeBirthday { get; set; }
        /// <summary>
        /// 员工电话
        /// </summary>
        public string EmployeePhone { get; set; }
        /// <summary>
        /// 员工名称
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 员工部门编号
        /// </summary>
        public string EmployeeDepartmentNO { get; set; }
        /// <summary>
        /// 员工部门名称
        /// </summary>
        public string EmployeeDepartmentName { get; set; }
        /// <summary>
        /// 员工等级
        /// </summary>
        public string EmployeeLevel { get; set; }
        /// <summary>
        /// 员工职务
        /// </summary>
        public string EmployeeDuty { get; set; }
        /// <summary>
        /// 员工职务名称
        /// </summary>
        public string EmployeeDutyChs { get; set; }
        /// <summary>
        /// 员工所在公司编码
        /// </summary>
        public string CompanyBM { get; set; }
        /// <summary>
        /// 员工初始密码是否已更改
        /// </summary>
        public bool OriginPasswordChanged { get; set; }
        /// <summary>
        /// 员工账号是否已失效
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 员工具有的权限
        /// </summary>
        public int[] UserPower { get; set; }

        /// <summary>
        /// 使用数据集构造
        /// </summary>
        /// <param name="dr">数据集</param>
        /// <returns>构造后的对象</returns>
        public static implicit operator UserInformation(DataRow dr)
        {
            return null == dr ? new UserInformation() : new UserInformation
            {
                CompanyBM = dr["CompanyBM"].SafeDbValue<string>(),
                CardNO = dr["CardNO"].SafeDbValue<string>(),
                EmployeeBirthday = dr["EmployeeBirthday"].SafeDbValue<DateTime>(),
                EmployeeDepartmentNO = dr["DepartmentNO"].SafeDbValue<string>(),
                EmployeeDepartmentName = dr["DepartmentName"].SafeDbValue<string>(),
                EmployeeDuty = dr["EmployeeDuty"].SafeDbValue<string>(),
                EmployeeDutyChs = dr["EmployeeDutyChs"].SafeDbValue<string>(),
                EmployeeLevel = dr["EmployeeLevel"].SafeDbValue<string>(),
                EmployeeNO = dr["EmployeeNO"].SafeDbValue<string>(),
                EmployeeNO2 = dr["EmployeeNO2"].SafeDbValue<string>(),
                EmployeeName = dr["EmployeeName"].SafeDbValue<string>(),
                EmployeePassword = dr["EmployeePassword"].SafeDbValue<string>(),
                EmployeePhone = dr["EmployeePhone"].SafeDbValue<string>(),
                EmployeeSex = dr["EmployeeSex"].SafeDbValue<string>(),
                OriginPasswordChanged = dr["IsChange"].SafeDbValue<bool>(),
                IsDeleted = dr["IsDelete"].SafeDbValue<bool>(),
                UserPower = dr["UserPower"].SafeDbValue<string>() == null ? new int[] { } : ToInt32Array(dr["UserPower"].SafeDbValue<string>().Split(','))
            };
        }

        private static int[] ToInt32Array(IList<string> arr)
        {
            return null == arr || 0 == arr.Count || 0 == arr[0].Length ? null : arr.Select(int.Parse).ToArray();
        }
    }
}