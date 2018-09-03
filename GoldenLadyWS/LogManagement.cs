using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Services;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLady.Utility;

namespace GoldenLadyWS
{
    /// <summary>
    /// 用于日志管理的数据库操作方法集
    /// </summary>
    public sealed class LogManagement : ErpService
    {
        private static LogManagement _theInstance;
        private LogManagement() { }

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static LogManagement Instance
        {
            get { return _theInstance ?? (_theInstance = new LogManagement()); }
        }

        /// <summary>
        /// 保存软件错误日志信息
        /// </summary>
        /// <param name="employeeNO">操作员工编号</param>
        /// <param name="exceptionType">异常类型</param>
        /// <param name="message">提示信息</param>
        /// <param name="stackTrace">调用堆栈</param>
        /// <returns>受影响的行数</returns>
        [WebMethod]
        public int SaveErrorLog(string employeeNO, string exceptionType, string message, string stackTrace)
        {
            string strSql = string.Format(@"INSERT INTO ErrorLog([EmployeeNO], [ExceptionType], [Message], [StackTrace]) 
                                            VALUES('{0}', '{1}', '{2}', '{3}')", employeeNO, exceptionType, message, stackTrace);
            return ExecuteNonQuery(strSql);
        }

        /// <summary>
        /// 保存一条操作日志
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="logoType">日志类型</param>
        /// <param name="logoContext">日志内容</param>
        [WebMethod]
        public void SaveOperateLog(string orderNO, string logoType, string logoContext)
        {
            try
            {
                string strSql = string.Format(@"INSERT INTO Logo (OrderNO, DepartmentNO, EmployeeNO, [Create], CreateDate, LogoType, LogoContext) 
                                            VALUES ('{0}', '{1}', '{2}', '{3}', GETDATE(), '{4}', '{5}')", orderNO, Information.CurrentUser.EmployeeDepartmentNO, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName, logoType, logoContext);
                ExecuteNonQuery(strSql);
            }
            catch(Exception ex)
            {
                MessageBoxEx.Info(string.Format(@"操作日志记录失败!{0}{1}", Environment.NewLine, ex.Message));
            }
        }

        /// <summary>
        /// 保存一条操作日志
        /// </summary>
        /// <param name="process">流程编号</param>
        /// <param name="logoType">日志类型</param>
        /// <param name="logoContext">日志内容</param>
        [WebMethod]
        public void SaveOperateProcessLog(string process, string logoType, string logoContext)
        {
            try
            {
                string strSql = string.Format(@"INSERT INTO Logo (Process, DepartmentNO, EmployeeNO, [Create], CreateDate, LogoType, LogoContext) 
                                            VALUES ('{0}', '{1}', '{2}', '{3}', GETDATE(), '{4}', '{5}')", process, Information.CurrentUser.EmployeeDepartmentNO, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName, logoType, logoContext);
                ExecuteNonQuery(strSql);
            }
            catch(Exception ex)
            {
                MessageBoxEx.Info(string.Format(@"操作日志记录失败!{0}{1}", Environment.NewLine, ex.Message));
            }
        }

        /// <summary>
        /// 保存一条操作日志
        /// </summary>
        /// <param name="logoContext">日志内容</param>
        [WebMethod]
        public void SaveOperateLog(string logoContext)
        {
            SaveOperateLog(string.Empty, LogType.Default, logoContext);
        }

        /// <summary>
        /// 保存一条操作日志
        /// </summary>
        /// <param name="logoType">日志类型</param>
        /// <param name="logoContext">日志内容</param>
        [WebMethod]
        public void SaveOperateLog(string logoType, string logoContext)
        {
            SaveOperateLog(string.Empty, logoType, logoContext);
        }

        /// <summary>
        /// 保存一条订单状态日志
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="logoType">日志类型</param>
        /// <param name="logoContext">日志内容</param>
        [WebMethod]
        public void SaveOrderLog(string orderNO, string logoType, string logoContext)
        {
            string strSql = string.Format(@"INSERT INTO OrderLogo (OrderNO, DepartmentNO, EmployeeNO, [Create], CreateDate, LogoType, LogoContext) 
                                            VALUES ('{0}', '{1}', '{2}', '{3}', GETDATE(), '{4}', '{5}')", orderNO, Information.CurrentUser.EmployeeDepartmentNO, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName, logoType, logoContext);
            ExecuteNonQuery(strSql);
        }

        /// <summary>
        /// 获取用于展示的订单状态日志
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns>状态日志</returns>
        public string GetOrderStateLogsToShow(string orderNO)
        {
            string strSql = string.Format(@"SELECT (SELECT DepartmentName FROM Department WHERE DepartmentNO = ol.DepartmentNO) AS DepartmentName, [Create], CreateDate, LogoContext FROM OrderLogo ol WHERE LogoType IN('订单状态变更', '摄影相关操作') AND OrderNO = '{0}' ORDER BY CreateDate ASC", orderNO);
            using(DataSet ds = ExecuteQuery(strSql))
            {
                if(ds.IsEmpty()) return string.Empty;
                StringBuilder sb = new StringBuilder();
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    sb.AppendLine(string.Format(@"{0} 由[{1}]的[{2}]{3}", dr[@"CreateDate"].SafeDbDateTime().ToString(CultureInfo.CurrentCulture), dr[@"DepartmentName"].SafeDbString(), dr[@"Create"].SafeDbString(), dr[@"LogoContext"].SafeDbString()));
                    sb.AppendLine();
                }
                sb.Length -= 3; // 去掉末尾空行和之前的\r\n换行符
                return sb.ToString();
            }
        }
    }
}