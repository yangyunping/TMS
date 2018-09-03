using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Services;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLady.Utility;

namespace GoldenLadyWS
{
    /// <summary>
    /// 用于公司管理的数据库操作方法集
    /// </summary>
    public sealed class CompanyManagement : ErpService
    {
        private static CompanyManagement _theInstance;
        private CompanyManagement() { }
        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static CompanyManagement Instance
        {
            get { return _theInstance ?? (_theInstance = new CompanyManagement()); }
        }

        /// <summary>
        /// 查询员工信息
        /// </summary>
        /// <param name="employeeNO">员工编号</param>
        /// <returns>员工信息</returns>
        [WebMethod]
        public DataSet SearchEmployeeInfo(string employeeNO)
        {
            string strSql = string.Format(@"DECLARE @employeeNO2 VARCHAR(50) = '{0}'
                                            DECLARE @userPower VARCHAR(1000) = (SELECT CONVERT(VARCHAR, PowerID) + ',' FROM EmployeePowers WHERE EmployeeNO = (SELECT TOP 1 EmployeeNO FROM Employee WHERE EmployeeNO2 = @employeeNO2 AND IsDelete = 0) FOR XML PATH(''))
                                            SELECT e.EmployeeNO, e.EmployeeNO2, e.EmployeePassword, e.EmployeeName, e.CardNO, e.EmployeeBirthday, e.EmployeePhone, e.EmployeeDuty, e.EmployeeLevel, e.IsChange, e.IsDelete,
                                            d.DepartmentNO, d.DepartmentName, d.CompanyBM,
                                            CASE
												WHEN d.DepartmentName = '管理员组' THEN '管理员'
												ELSE c1.ConfigValue
											END AS EmployeeDutyChs,
                                            c2.ConfigValue AS EmployeeSex,
                                            SUBSTRING(@userPower, 0, LEN(@userPower)) AS [UserPower]
                                            FROM Employee e 
                                            INNER JOIN Department d ON e.DepartmentNO = d.DepartmentNO
                                            LEFT JOIN Config c1 ON e.EmployeeDuty = c1.ConfigNO
                                            LEFT JOIN Config c2 ON e.EmployeeSex = c2.ConfigNO
                                            WHERE EmployeeNO2 = @employeeNO2", employeeNO);
            return ExecuteQuery(strSql);
        }

        /// <summary>
        /// 查询公司信息
        /// </summary>
        /// <returns>公司信息</returns>
        [WebMethod]
        public DataSet SearchCompanyInfo()
        {
            return ExecuteQuery(@"SELECT TOP 1 CompanyBM, CompanyChinese FROM CompanyRegisterInformation WHERE IsDeleteStates = 0");
        }

        /// <summary>
        /// 查询软件版本信息
        /// </summary>
        /// <returns>版本信息</returns>
        [WebMethod]
        public DataSet SearchEditionInfo()
        {
            return ExecuteQuery(@"SELECT EditionNO, EditionName, CustomerName1, CustomerName2, MemorizeDay FROM EditionManager WHERE [Default] = 1");
        }

        /// <summary>
        /// 更新员工密码
        /// </summary>
        /// <param name="employeeNO">员工编号</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>是否成功</returns>
        [WebMethod]
        public bool UpdateEmployeePassword(string employeeNO, string newPwd)
        {
            return 0 != ExecuteNonQuery(string.Format(@"UPDATE Employee SET EmployeePassword = '{0}', IsChange = 1 WHERE EmployeeNO = '{1}'", newPwd, employeeNO));
        }

        /// <summary>
        /// 查询作为介绍人的员工信息
        /// </summary>
        /// <param name="employeeNO">员工编号-旧</param>
        /// <returns>员工信息</returns>
        [WebMethod]
        public DataSet SearchIntroducerEmployee(string employeeNO)
        {
            return ExecuteQuery(string.Format(@"SELECT EmployeeName, CardNO FROM [dbo].[V_Employee] WHERE EmployeeNO = '{0}'", employeeNO));
        }

        /// <summary>
        /// 获取当前登陆员工的所有权限名称
        /// </summary>
        /// <returns>当前登陆员工的所有权限名称</returns>
        [WebMethod]
        public string[] SearchCurrentEmployeePowersName()
        {
            StringBuilder sb = new StringBuilder(ExecuteScalar(string.Format(@"SELECT p.Name + ';' FROM EmployeePowers ep LEFT JOIN Powers p ON ep.PowerID = p.ID WHERE ep.EmployeeNO = '{0}' FOR XML PATH('')", Information.CurrentUser.EmployeeNO)).SafeDbString());
            if(sb.Length <= 0)
            {
                return new string[]{};
            }
            sb.Length -= 1;
            return sb.ToString().Split(';');
        }

        /// <summary>
        /// 获取部门下的所有员工
        /// </summary>
        /// <param name="departmentNo">部门编号</param>
        /// <returns>部门下的所有员工</returns>
        [WebMethod]
        public DataSet GetDepartmentEmployee(string departmentNo)
        {
            return ExecuteQuery(string.Format(@"SELECT * FROM dbo.v_SearchEmployee WHERE IsDelete = 0 AND DepartmentNO='{0}'", departmentNo));
        }
        /// <summary>
        /// 获取部门下的所有员工列表
        /// </summary>
        /// <param name="departmentNo">部门编号</param>
        /// <returns>部门下的所有员工列表</returns>
        [WebMethod]
        public IEnumerable<Employee> GetDepartmentEmployeeList(string departmentNo)
        {
            using(DataSet dsEmployee = GetDepartmentEmployee(departmentNo))
            {
                try
                {
                    return from DataRow row in dsEmployee.Tables[0].Rows select Employee.FromDataRow(row);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询部门员工列表时遇到了问题导致失败！{0}方法名称：'CompanyManagement.GetDepartmentEmployeeList'", Environment.NewLine));
                }
                return new Employee[]{};
            }
        }

        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <returns>所有部门列表</returns>
        [WebMethod]
        public IEnumerable<Department> GetDepartments()
        {
            using(DataSet dsEmployee = ExecuteQuery(@"SELECT * FROM Department WHERE IsDelete = 0"))
            {
                try
                {
                    return from DataRow row in dsEmployee.Tables[0].Rows select Department.FromDataRow(row);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询部门列表时遇到了问题导致失败！{0}方法名称：'CompanyManagement.GetDepartments'", Environment.NewLine));
                }
                return new Department[] { };
            }
        }

        /// <summary>
        /// 根据部门编号获取部门名称
        /// </summary>
        /// <param name="departmentNo">部门编号</param>
        /// <returns>部门名称</returns>
        public string GetDepartmentNameByNo(string departmentNo)
        {
            return ExecuteScalar(string.Format(@"SELECT TOP 1 DepartmentName FROM Department WHERE DepartmentNO = '{0}' AND IsDelete = 0", departmentNo)).SafeDbString();
        }
    }
}