using System;

namespace GoldenLadyWS.Model
{
    /// <summary>
    /// 存放登录用户信息的类
    /// </summary>
    public sealed class UserInformation
    {
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNO { get; set; }
        /// <summary>
        /// 员工登录用编号
        /// </summary>
        public string EmployeeNO2
        {
            get;
            set;
        }
        /// <summary>
        /// 员工密码
        /// </summary>
        public string EmployeePassword
        {
            get;
            set;
        }
        /// <summary>
        /// 员工性别
        /// </summary>
        public string EmployeeSex
        {
            get;
            set;
        }
        /// <summary>
        /// 员工卡号
        /// </summary>
        public string CardNO
        {
            get;
            set;
        }
        /// <summary>
        /// 员工生日
        /// </summary>
        public DateTime EmployeeBirthday
        {
            get;
            set;
        }
        /// <summary>
        /// 员工电话
        /// </summary>
        public string EmployeePhone
        {
            get;
            set;
        }
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
        public string CompanyBM
        {
            get;
            set;
        }
        /// <summary>
        /// 员工初始密码是否已更改
        /// </summary>
        public bool OriginPasswordChanged { get; set; }
        /// <summary>
        /// 员工账号是否已失效
        /// </summary>
        public bool IsDeleted
        {
            get;
            set;
        }
        /// <summary>
        /// 员工具有的权限
        /// </summary>
        public int[] UserPower { get; set; }
    }
}