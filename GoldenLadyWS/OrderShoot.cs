using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// 用于订单拍摄管理的数据库操作方法集
    /// </summary>
    public sealed class OrderShoot : ErpService
    {
        private static OrderShoot _theInstance;
        private OrderShoot() {}

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static OrderShoot Instance
        {
            get { return _theInstance ?? (_theInstance = new OrderShoot()); }
        }

        /// <summary>
        /// 预约拍摄
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shootType">类别（内景，外景）</param>
        /// <param name="shootDepartment">摄影 部门（不是摄影地点）</param>
        /// <param name="shootAddress">具体的摄影地点</param>
        /// <param name="shootAddressName">摄影地点名称</param>
        /// <param name="shootEmployeeNO">摄影师</param>
        /// <param name="shootEmployeeName">摄影师名称</param>
        /// <param name="preShootDate">预摄影时间</param>
        /// <param name="shootMemory">摄影备注</param>
        [WebMethod]
        public bool ArrangeShoot(string orderNO, string shootType, string shootDepartment, string shootAddress, string shootAddressName, string shootEmployeeNO, string shootEmployeeName, string preShootDate, string shootMemory)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(@"
            DECLARE 
            @orderNO VARCHAR(20) = '{0}',
            @shootType VARCHAR(10) = '{1}',
            @shootDepartment VARCHAR(30) = '{2}',
            @shootAddress VARCHAR(30) = '{3}',
            @shootEmployeeNO VARCHAR(30) = '{4}',
            @preShootDate VARCHAR(30) = '{5}',
            @shootMemory VARCHAR(MAX) = '{6}',
            @opEmployee VARCHAR(30) = '{7}',
            @opDepartment VARCHAR(30) = '{8}',
            @opDateTime DATETIME = GETDATE(),
            @shootAddressName VARCHAR(30) = '{9}',
            @shootEmployeeName VARCHAR(30) = '{10}'
            IF EXISTS
            (
	            SELECT 1 FROM OrderShoot
	            WHERE OrderNO=@orderNO 
	            AND ShootState='初始化' 
	            AND ShootType=@shootType 
	            AND IsDelete=0 
	            AND RecordState = 3
            )
            BEGIN
	            UPDATE OrderShoot 
	            SET 
	            ShootDepartment=@shootDepartment, 
	            ShootAddress=@shootAddress, 
	            ShootEmployeeNO=@shootEmployeeNO, 
	            PreShootDate=@preShootDate,
	            ShootMemory=@shootMemory,
	            OpEmployee=@opEmployee,
	            OpDepartment=@opDepartment,
	            OpDateTime=@opDateTime, 
	            ShootDate = NULL, 
	            ShootState = '正常', 
	            RecordState = 0 
	            WHERE OrderNO=@orderNO 
	            AND ShootState='初始化' 
	            AND ShootType=@shootType 
	            AND IsDelete=0 
	            AND RecordState = 3
            END
            ELSE BEGIN
	            INSERT INTO OrderShoot(OrderNO, ShootState, ShootType, ShootDepartment, ShootAddress, ShootEmployeeNO, PreShootDate, ShootMemory, OpEmployee, OpDepartment, OpDateTime)
	            VALUES(@orderNO, '正常', @shootType, @shootDepartment, @shootAddress, @shootEmployeeNO, @preShootDate, @shootMemory, @opEmployee, @opDepartment, @opDateTime)
            END", orderNO, shootType, shootDepartment, shootAddress, shootEmployeeNO, preShootDate, shootMemory, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeDepartmentNO, shootAddressName, shootEmployeeName));

            if(shootType == ShootType.Inside)
            {
                sb.AppendLine(@"
                IF EXISTS
                (
	                SELECT 1 FROM OrdersSub WHERE OrderNO = @orderNO
                )
                BEGIN 
	                UPDATE OrdersSub 
	                SET 
	                ShootAddressNameN = @shootAddressName,
	                ShootEmployeeNameN = @shootEmployeeName
	                WHERE OrderNO=@orderNO
                END
                ELSE BEGIN
	                INSERT INTO OrdersSub(OrderNO, ShootAddressNameN, ShootEmployeeNameN) 
	                VALUES (@orderNO, @shootAddressName, @shootEmployeeName)
                END");
            }
            else if(shootType == ShootType.Outside)
            {
                sb.AppendLine(@"
                IF EXISTS
                (
	                SELECT 1 FROM OrdersSub WHERE OrderNO = @orderNO
                )
                BEGIN 
	                UPDATE OrdersSub 
	                SET 
	                ShootAddressNameW = @shootAddressName,
	                ShootEmployeeNameW = @shootEmployeeName
	                WHERE OrderNO=@orderNO
                END
                ELSE BEGIN
	                INSERT INTO OrdersSub(OrderNO, ShootAddressNameW, ShootEmployeeNameW) 
	                VALUES (@orderNO, @shootAddressName, @shootEmployeeName)
                END");
            }
            try
            {
                ExecuteNonQuery(sb.ToString());
                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"安排[{0}]预约, 摄影地点[{1}], 摄影师[{2}], 预约时间[{3}], 摄影备注[{4}]", shootType, shootAddressName, shootEmployeeName, preShootDate, shootMemory));
                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"安排[{0}]预约, 摄影地点[{1}], 摄影师[{2}], 预约时间[{3}], 摄影备注[{4}]", shootType, shootAddressName, shootEmployeeName, preShootDate, shootMemory));
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 设置取消重拍
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CancelNeedReShoot(string orderNO)
        {
            string strSql = string.Format(@"
                                            UPDATE FlagReshoot 
                                            SET FlagState = '已取消'
                                            WHERE OrderNO = '{0}' AND FlagState = '正常'", orderNO);
            ExecuteNonQuery(strSql);
            LogManagement.SaveOperateLog(orderNO, LogType.Shoot, @"重拍标记已失效");
            LogManagement.SaveOrderLog(orderNO, LogType.Shoot, @"重拍标记已失效");
        }
        /// <summary>
        /// 改期拍摄
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shootType">类别（内景，外景）</param>
        /// <param name="shootDepartment">摄影 部门（不是摄影地点）</param>
        /// <param name="shootAddress">具体的摄影地点</param>
        /// <param name="shootAddressName">摄影地点名称</param>
        /// <param name="shootEmployeeNO">摄影师</param>
        /// <param name="shootEmployeeName">摄影师名称</param>
        /// <param name="preShootDate">预摄影时间</param>
        /// <param name="shootMemory">摄影备注</param>
        [WebMethod]
        public bool ChangeShootDate(string orderNO, string shootType, string shootDepartment, string shootAddress, string shootAddressName, string shootEmployeeNO, string shootEmployeeName, string preShootDate, string shootMemory)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(@"
            DECLARE 
            @orderNO VARCHAR(20) = '{0}',
            @shootType VARCHAR(10) = '{1}',
            @shootDepartment VARCHAR(30) = '{2}',
            @shootAddress VARCHAR(30) = '{3}',
            @shootEmployeeNO VARCHAR(30) = '{4}',
            @preShootDate VARCHAR(30) = '{5}',
            @shootMemory VARCHAR(MAX) = '{6}',
            @opEmployee VARCHAR(30) = '{7}',
            @opDepartment VARCHAR(30) = '{8}',
            @opDateTime DATETIME = GETDATE(),
            @shootAddressName VARCHAR(30) = '{9}',
            @shootEmployeeName VARCHAR(30) = '{10}'
            UPDATE OrderShoot 
            SET 
            ShootDepartment=@shootDepartment, 
            ShootAddress=@shootAddress, 
            ShootEmployeeNO=@shootEmployeeNO, 
            PreShootDate=@preShootDate,
            ShootMemory=@shootMemory,
            OpEmployee=@opEmployee,
            OpDepartment=@opDepartment,
            OpDateTime=@opDateTime
            WHERE OrderNO=@orderNO 
            AND ShootType=@shootType 
            AND IsDelete=0 
            AND RecordState = 0", orderNO, shootType, shootDepartment, shootAddress, shootEmployeeNO, preShootDate, shootMemory, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeDepartmentNO, shootAddressName, shootEmployeeName));

            if(shootType == ShootType.Inside)
            {
                sb.AppendLine(@"
                IF EXISTS
                (
	                SELECT 1 FROM OrdersSub WHERE OrderNO = @orderNO
                )
                BEGIN 
	                UPDATE OrdersSub 
	                SET 
	                ShootAddressNameN = @shootAddressName,
	                ShootEmployeeNameN = @shootEmployeeName
	                WHERE OrderNO=@orderNO
                END
                ELSE BEGIN
	                INSERT INTO OrdersSub(OrderNO, ShootAddressNameN, ShootEmployeeNameN) 
	                VALUES (@orderNO, @shootAddressName, @shootEmployeeName)
                END");
            }
            else if(shootType == ShootType.Outside)
            {
                sb.AppendLine(@"
                IF EXISTS
                (
	                SELECT 1 FROM OrdersSub WHERE OrderNO = @orderNO
                )
                BEGIN 
	                UPDATE OrdersSub 
	                SET 
	                ShootAddressNameW = @shootAddressName,
	                ShootEmployeeNameW = @shootEmployeeName
	                WHERE OrderNO=@orderNO
                END
                ELSE BEGIN
	                INSERT INTO OrdersSub(OrderNO, ShootAddressNameW, ShootEmployeeNameW) 
	                VALUES (@orderNO, @shootAddressName, @shootEmployeeName)
                END");
            }
            try
            {
                ExecuteNonQuery(sb.ToString());
                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"[{0}]改期, 摄影地点[{1}], 摄影师[{2}], 预约时间[{3}], 摄影备注[{4}]", shootType, shootAddressName, shootEmployeeName, preShootDate, shootMemory));
                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"[{0}]改期, 摄影地点[{1}], 摄影师[{2}], 预约时间[{3}], 摄影备注[{4}]", shootType, shootAddressName, shootEmployeeName, preShootDate, shootMemory));
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static bool DateTimeNotSet(DateTime dt)
        {
            return dt.Equals(DateTime.MinValue) || dt.Date.Equals(DefValue.Date1900.Date);
        }
        /// <summary>
        /// 补拍
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shootType">类别（内景，外景）</param>
        /// <param name="shootDepartment">摄影 部门（不是摄影地点）</param>
        /// <param name="shootAddress">具体的摄影地点</param>
        /// <param name="shootAddressName">摄影地点名称</param>
        /// <param name="shootEmployeeNO">摄影师</param>
        /// <param name="shootEmployeeName">摄影师名称</param>
        /// <param name="preShootDate">预摄影时间</param>
        /// <param name="shootMemory">摄影备注</param>
        [WebMethod]
        public bool DelayShoot(string orderNO, string shootType, string shootDepartment, string shootAddress, string shootAddressName, string shootEmployeeNO, string shootEmployeeName, string preShootDate, string shootMemory)
        {
            // 先将对应类型的摄影记录设置失效
            try
            {
                ExecuteNonQuery(string.Format(@"UPDATE OrderShoot SET RecordState = 2 WHERE OrderNO='{0}' AND RecordState = 0 AND ShootType='{1}' AND IsDelete=0", orderNO, shootType));
            }
            catch
            {
                return false;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(@"            
            DECLARE 
            @orderNO VARCHAR(20) = '{0}',
            @shootType VARCHAR(10) = '{1}',
            @shootDepartment VARCHAR(30) = '{2}',
            @shootAddress VARCHAR(30) = '{3}',
            @shootEmployeeNO VARCHAR(30) = '{4}',
            @preShootDate VARCHAR(30) = '{5}',
            @shootMemory VARCHAR(MAX) = '{6}',
            @opEmployee VARCHAR(30) = '{7}',
            @opDepartment VARCHAR(30) = '{8}',
            @opDateTime DATETIME = GETDATE(),
            @shootAddressName VARCHAR(30) = '{9}',
            @shootEmployeeName VARCHAR(30) = '{10}'
	        INSERT INTO OrderShoot(OrderNO, ShootState, ShootType, ShootDepartment, ShootAddress, ShootEmployeeNO, PreShootDate, ShootMemory, OpEmployee, OpDepartment, OpDateTime)
	        VALUES(@orderNO, '补拍', @shootType, @shootDepartment, @shootAddress, @shootEmployeeNO, @preShootDate, @shootMemory, @opEmployee, @opDepartment, @opDateTime)", orderNO, shootType, shootDepartment, shootAddress, shootEmployeeNO, preShootDate, shootMemory, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeDepartmentNO, shootAddressName, shootEmployeeName));
            if(shootType == ShootType.Inside)
            {
                sb.AppendLine(@"
                IF EXISTS
                (
	                SELECT 1 FROM OrdersSub WHERE OrderNO = @orderNO
                )
                BEGIN 
	                UPDATE OrdersSub 
	                SET 
	                ShootAddressNameN = @shootAddressName,
	                ShootEmployeeNameN = @shootEmployeeName
	                WHERE OrderNO=@orderNO
                END
                ELSE BEGIN
	                INSERT INTO OrdersSub(OrderNO, ShootAddressNameN, ShootEmployeeNameN) 
	                VALUES (@orderNO, @shootAddressName, @shootEmployeeName)
                END");
            }
            else if(shootType == ShootType.Outside)
            {
                sb.AppendLine(@"
                IF EXISTS
                (
	                SELECT 1 FROM OrdersSub WHERE OrderNO = @orderNO
                )
                BEGIN 
	                UPDATE OrdersSub 
	                SET 
	                ShootAddressNameW = @shootAddressName,
	                ShootEmployeeNameW = @shootEmployeeName
	                WHERE OrderNO=@orderNO
                END
                ELSE BEGIN
	                INSERT INTO OrdersSub(OrderNO, ShootAddressNameW, ShootEmployeeNameW) 
	                VALUES (@orderNO, @shootAddressName, @shootEmployeeName)
                END");
            }
            try
            {
                ExecuteNonQuery(sb.ToString());
                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"安排[{0}]补拍, 摄影地点[{1}], 摄影师[{2}], 预约时间[{3}], 摄影备注[{4}]", shootType, shootAddressName, shootEmployeeName, preShootDate, shootMemory));
                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"安排[{0}]补拍, 摄影地点[{1}], 摄影师[{2}], 预约时间[{3}], 摄影备注[{4}]", shootType, shootAddressName, shootEmployeeName, preShootDate, shootMemory));
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 删除摄控
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shootType">拍摄类型</param>
        [WebMethod]
        public bool DeleteShoot(string orderNO, string shootType)
        {
            string strSql;
            if(shootType == ShootType.All)
            {
                strSql = string.Format(@"
                UPDATE OrderShoot 
                SET RecordState = 1,IsDelete = 1
                WHERE OrderNO='{0}' 
                AND RecordState = 0", orderNO);
            }
            else
            {
                strSql = string.Format(@"
                UPDATE OrderShoot 
                SET RecordState = 1,IsDelete = 1
                WHERE OrderNO='{0}' 
                AND RecordState = 0
                AND ShootType = '{1}'", orderNO, shootType);
            }
            try
            {
                ExecuteNonQuery(strSql);
                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"删除了[{0}]摄控", shootType));
                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"删除了[{0}]摄控", shootType));
            }
            catch
            {
                return false;
            }

            // 恢复上一条置为失效的记录，更新Orders对应日期
            switch(shootType)
            {
                case "内景":
                    using(DataSet ds = ExecuteQuery(string.Format(@"SELECT * FROM OrderShoot WHERE OrderNO = '{0}' AND ShootType = '{1}' AND RecordState = 2 ORDER BY OpDateTime DESC", orderNO, shootType)))
                    {
                        if(ds.IsEmpty())
                        {
                            // 直接更新Order
                            try
                            {
                                ExecuteNonQuery(string.Format(@"UPDATE Orders SET PreShootDateN = NULL, ShootDateN = NULL, ShootAddressN = NULL WHERE OrderNO='{0}'", orderNO));
                                return true;
                            }
                            catch
                            {
                                return false;
                            }
                        }
                        // 恢复记录，再对应更新Order
                        DataRow dr = ds.Tables[0].Rows[0];
                        DateTime dtPreShoot = dr["PreShootDate"].SafeDbDateTime();
                        DateTime dtShoot = dr["ShootDate"].SafeDbDateTime();
                        string strUpdateOrder = string.Format(@"UPDATE Orders SET PreShootDateN = '{0}', ShootDateN = '{1}', ShootAddressN = '{2}' WHERE OrderNO='{3}'", dtPreShoot.Equals(DateTime.MinValue) ? "1900-01-01" : dtPreShoot.ToString(CultureInfo.CurrentCulture), dtShoot.Equals(DateTime.MinValue) ? "1900-01-01" : dtShoot.ToString(CultureInfo.CurrentCulture), dr["ShootAddress"].SafeDbString(), orderNO);
                        string strUpdateOrderShoot = string.Format(@"UPDATE OrderShoot SET RecordState = 0 WHERE ID = {0}", dr["ID"].SafeDbInt32());
                        try
                        {
                            ExecuteNonQuery(string.Format(@"{0} {1}", strUpdateOrder, strUpdateOrderShoot));
                            LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"恢复了ID为[{0}]的摄影记录", dr["ID"].SafeDbInt32()));
                            LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"恢复了ID为[{0}]的摄影记录", dr["ID"].SafeDbInt32()));
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                case "外景":
                    using(DataSet ds = ExecuteQuery(string.Format(@"SELECT * FROM OrderShoot WHERE OrderNO = '{0}' AND ShootType = '{1}' AND RecordState = 2 ORDER BY OpDateTime DESC", orderNO, shootType)))
                    {
                        if(ds.IsEmpty())
                        {
                            // 直接更新Order
                            try
                            {
                                ExecuteNonQuery(string.Format(@"UPDATE Orders SET PreShootDateW = NULL, ShootDateW = NULL, ShootAddressW = NULL WHERE OrderNO='{0}'", orderNO));
                                return true;
                            }
                            catch
                            {
                                return false;
                            }
                        }
                        // 恢复记录，再对应更新Order
                        DataRow dr = ds.Tables[0].Rows[0];
                        DateTime dtPreShoot = dr["PreShootDate"].SafeDbDateTime();
                        DateTime dtShoot = dr["ShootDate"].SafeDbDateTime();
                        string strUpdateOrder = string.Format(@"UPDATE Orders SET PreShootDateW = '{0}', ShootDateW = '{1}', ShootAddressW = '{2}' WHERE OrderNO='{3}'", dtPreShoot.Equals(DateTime.MinValue) ? "1900-01-01" : dtPreShoot.ToString(CultureInfo.CurrentCulture), dtShoot.Equals(DateTime.MinValue) ? "1900-01-01" : dtShoot.ToString(CultureInfo.CurrentCulture), dr["ShootAddress"].SafeDbString(), orderNO);
                        string strUpdateOrderShoot = string.Format(@"UPDATE OrderShoot SET RecordState = 0 WHERE ID = {0}", dr["ID"].SafeDbInt32());
                        try
                        {
                            ExecuteNonQuery(string.Format(@"{0} {1}", strUpdateOrder, strUpdateOrderShoot));
                            LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"恢复了ID为[{0}]的摄影记录", dr["ID"].SafeDbInt32()));
                            LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"恢复了ID为[{0}]的摄影记录", dr["ID"].SafeDbInt32()));
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                case "全套":
                    using(DataSet dsN = ExecuteQuery(string.Format(@"SELECT * FROM OrderShoot WHERE OrderNO = '{0}' AND ShootType = '内景' AND RecordState = 2 ORDER BY OpDateTime DESC", orderNO)),
                                  dsW = ExecuteQuery(string.Format(@"SELECT * FROM OrderShoot WHERE OrderNO = '{0}' AND ShootType = '外景' AND RecordState = 2 ORDER BY OpDateTime DESC", orderNO)))
                    {
                        if(dsN.IsEmpty())
                        {
                            // 直接更新Order
                            try
                            {
                                ExecuteNonQuery(string.Format(@"UPDATE Orders SET PreShootDateN = NULL, ShootDateN = NULL, ShootAddressN = NULL WHERE OrderNO='{0}'", orderNO));
                            }
                            catch
                            {
                                return false;
                            }
                        }
                        else
                        {
                            // 恢复记录，再对应更新Order
                            DataRow dr = dsN.Tables[0].Rows[0];
                            DateTime dtPreShoot = dr["PreShootDate"].SafeDbDateTime();
                            DateTime dtShoot = dr["ShootDate"].SafeDbDateTime();
                            string strUpdateOrder = string.Format(@"UPDATE Orders SET PreShootDateN = '{0}', ShootDateN = '{1}', ShootAddressN = '{2}' WHERE OrderNO='{3}'", dtPreShoot.Equals(DateTime.MinValue) ? "1900-01-01" : dtPreShoot.ToString(CultureInfo.CurrentCulture), dtShoot.Equals(DateTime.MinValue) ? "1900-01-01" : dtShoot.ToString(CultureInfo.CurrentCulture), dr["ShootAddress"].SafeDbString(), orderNO);
                            string strUpdateOrderShoot = string.Format(@"UPDATE OrderShoot SET RecordState = 0 WHERE ID = {0}", dr["ID"].SafeDbInt32());
                            try
                            {
                                ExecuteNonQuery(string.Format(@"{0} {1}", strUpdateOrder, strUpdateOrderShoot));
                                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"恢复了ID为[{0}]的摄影记录", dr["ID"].SafeDbInt32()));
                                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"恢复了ID为[{0}]的摄影记录", dr["ID"].SafeDbInt32()));
                            }
                            catch
                            {
                                return false;
                            }
                        }

                        if(dsW.IsEmpty())
                        {
                            // 直接更新Order
                            try
                            {
                                ExecuteNonQuery(string.Format(@"UPDATE Orders SET PreShootDateW = NULL, ShootDateW = NULL, ShootAddressW = NULL WHERE OrderNO='{0}'", orderNO));
                                return true;
                            }
                            catch
                            {
                                return false;
                            }
                        }
                        else
                        {
                            // 恢复记录，再对应更新Order
                            DataRow dr = dsW.Tables[0].Rows[0];
                            DateTime dtPreShoot = dr["PreShootDate"].SafeDbDateTime();
                            DateTime dtShoot = dr["ShootDate"].SafeDbDateTime();
                            string strUpdateOrder = string.Format(@"UPDATE Orders SET PreShootDateW = '{0}', ShootDateW = '{1}', ShootAddressW = '{2}' WHERE OrderNO='{3}'", dtPreShoot.Equals(DateTime.MinValue) ? "1900-01-01" : dtPreShoot.ToString(CultureInfo.CurrentCulture), dtShoot.Equals(DateTime.MinValue) ? "1900-01-01" : dtShoot.ToString(CultureInfo.CurrentCulture), dr["ShootAddress"].SafeDbString(), orderNO);
                            string strUpdateOrderShoot = string.Format(@"UPDATE OrderShoot SET RecordState = 0 WHERE ID = {0}", dr["ID"].SafeDbInt32());
                            try
                            {
                                ExecuteNonQuery(string.Format(@"{0} {1}", strUpdateOrder, strUpdateOrderShoot));
                                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"恢复了ID为[{0}]的摄影记录", dr["ID"].SafeDbInt32()));
                                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"恢复了ID为[{0}]的摄影记录", dr["ID"].SafeDbInt32()));
                                return true;
                            }
                            catch
                            {
                                return false;
                            }
                        }
                    }
                default:
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 拍摄完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shootType">拍摄类型</param>
        [WebMethod]
        public bool FinishShoot(string orderNO, string shootType)
        {
            try
            {
                ExecuteNonQuery(shootType == ShootType.All ? string.Format(@"UPDATE OrderShoot SET ShootDate=GETDATE() WHERE OrderNO='{0}' AND RecordState = 0", orderNO) : string.Format(@"UPDATE OrderShoot SET ShootDate=GETDATE() WHERE orderNO='{0}' AND RecordState = 0 AND ShootType='{1}'", orderNO, shootType));
                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"设置[{0}]拍摄完成", shootType));
                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"设置[{0}]拍摄完成", shootType));
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取订单的拍摄记录
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns>拍摄记录</returns>
        [WebMethod]
        public DataSet GetOrderShootRecords(string orderNO)
        {
            string strSql = string.Format(@"SELECT * FROM OrderShoot WHERE OrderNO = '{0}'", orderNO);
            return ExecuteQuery(strSql);
        }
        private static string GetShootSetState(DateTime shoot)
        {
            return DateTimeNotSet(shoot) ? ShootSetState.Arranged : ShootSetState.Finished;
        }
        private static string GetShootSetType(string state, string type)
        {
            if(type == ShootType.Inside)
            {
                if(state == ShootState.Normal)
                {
                    return ShootSetType.InsideNormal;
                }
                if(state == ShootState.DelayShoot)
                {
                    return ShootSetType.InsideDelay;
                }
                if(state == ShootState.ReShoot)
                {
                    return ShootSetType.InsideReShoot;
                }
            }
            else if(type == ShootType.Outside)
            {
                if(state == ShootState.Normal)
                {
                    return ShootSetType.OutsideNormal;
                }
                if(state == ShootState.DelayShoot)
                {
                    return ShootSetType.OutsideDelay;
                }
                if(state == ShootState.ReShoot)
                {
                    return ShootSetType.OutsideReShoot;
                }
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取当前订单拍摄状态的描述性文字
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shootType">拍摄类型</param>
        /// <returns>订单拍摄状态的描述性文字</returns>
        public string GetShootStateDiscription(string orderNO, string shootType)
        {
            string strShootState = string.Empty;
            using(DataSet ds = GetOrderShootRecords(orderNO))
            {
                if(null == ds || null == ds.Tables[0])
                {
                    return strShootState;
                }
                using(DataTable dt = ds.Tables[0])
                {
                    if(shootType == ShootType.Inside)
                    {
                        DataRow[] drs = dt.Select("ShootType = '内景' AND RecordState = 0", "OpDateTime DESC");
                        if(0 == drs.Length)
                        {
                            strShootState = string.Format(@"{0}-{1}", ShootSetType.InsideNormal, ShootSetState.NotSet);
                        }
                        else
                        {
                            DataRow row = drs[0];
                            strShootState = string.Format(@"{0}-{1}", GetShootSetType(row["ShootState"].SafeDbString(), ShootType.Inside), GetShootSetState(row["ShootDate"].SafeDbDateTime()));
                        }
                    }
                    else if(shootType == ShootType.Outside)
                    {
                        DataRow[] drs = dt.Select("ShootType = '外景' AND RecordState = 0", "OpDateTime DESC");
                        if(0 == drs.Length)
                        {
                            strShootState = string.Format(@"{0}-{1}", ShootSetType.OutsideNormal, ShootSetState.NotSet);
                        }
                        else
                        {
                            DataRow row = drs[0];
                            strShootState = string.Format(@"{0}-{1}", GetShootSetType(row["ShootState"].SafeDbString(), ShootType.Outside), GetShootSetState(row["ShootDate"].SafeDbDateTime()));
                        }
                    }
                    else if(shootType == ShootType.All)
                    {
                        string strShootStateInside;
                        DataRow[] drsInside = dt.Select("ShootType = '内景' AND RecordState = 0", "OpDateTime DESC");
                        if(0 == drsInside.Length)
                        {
                            strShootStateInside = string.Format(@"{0}-{1}", ShootSetType.InsideNormal, ShootSetState.NotSet);
                        }
                        else
                        {
                            DataRow row = drsInside[0];
                            strShootStateInside = string.Format(@"{0}-{1}", GetShootSetType(row["ShootState"].SafeDbString(), ShootType.Inside), GetShootSetState(row["ShootDate"].SafeDbDateTime()));
                        }
                        string strShootStateOutside;
                        DataRow[] drsOutside = dt.Select("ShootType = '外景' AND RecordState = 0", "OpDateTime DESC");
                        if(0 == drsOutside.Length)
                        {
                            strShootStateOutside = string.Format(@"{0}-{1}", ShootSetType.OutsideNormal, ShootSetState.NotSet);
                        }
                        else
                        {
                            DataRow row = drsOutside[0];
                            strShootStateOutside = string.Format(@"{0}-{1}", GetShootSetType(row["ShootState"].SafeDbString(), ShootType.Outside), GetShootSetState(row["ShootDate"].SafeDbDateTime()));
                        }
                        strShootState = string.Format(@"{0}，{1}", strShootStateInside, strShootStateOutside);
                    }
                }
            }
            return strShootState;
        }
        /// <summary>
        /// 处理需要重拍的订单
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void HandleNeedReShoot(string orderNO)
        {
            string strSql = string.Format(@"
                                            UPDATE FlagReshoot 
                                            SET FlagState = '已处理', HandleEmpNO = '{1}', HandleTime = GETDATE()  
                                            WHERE OrderNO = '{0}' AND FlagState = '正常'", orderNO, Information.CurrentUser.EmployeeNO);
            ExecuteNonQuery(strSql);
            LogManagement.SaveOperateLog(orderNO, LogType.Shoot, @"重拍标记已处理");
            LogManagement.SaveOrderLog(orderNO, LogType.Shoot, @"重拍标记已处理");
        }
        /// <summary>
        /// 初始化订单摄影记录
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shootType">拍摄类型</param>
        [WebMethod]
        public void InitOrderShoot(string orderNO, string shootType)
        {
            try
            {
                if(shootType != ShootType.Outside)
                {
                    ExecuteNonQuery(string.Format(@"
                    IF NOT EXISTS (SELECT 1 FROM OrderShoot WHERE OrderNO = '{0}' AND ShootType = '内景' AND RecordState = 0)
                    BEGIN
	                    INSERT INTO OrderShoot(OrderNO, ShootType, ShootState, RecordState)
                        VALUES ('{0}', '内景', '初始化', 3)
                    END", orderNO));
                }
                if(shootType != ShootType.Inside)
                {
                    ExecuteNonQuery(string.Format(@"
                    IF NOT EXISTS (SELECT 1 FROM OrderShoot WHERE OrderNO = '{0}' AND ShootType = '外景' AND RecordState = 0)
                    BEGIN
	                    INSERT INTO OrderShoot(OrderNO, ShootType, ShootState, RecordState)
                        VALUES ('{0}', '外景', '初始化', 3)
                    END", orderNO));
                }
                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"初始化[{0}]摄影记录", shootType));
                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"初始化[{0}]摄影记录", shootType));
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(string.Format(@"初始化摄影记录失败！{0}{1}", Environment.NewLine, ex.Message));
            }
        }
        /// <summary>
        /// 重拍
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="shootType">类别（内景，外景）</param>
        /// <param name="shootDepartment">摄影 部门（不是摄影地点）</param>
        /// <param name="shootAddress">具体的摄影地点</param>
        /// <param name="shootAddressName">摄影地点名称</param>
        /// <param name="shootEmployeeNO">摄影师</param>
        /// <param name="shootEmployeeName">摄影师名称</param>
        /// <param name="preShootDate">预摄影时间</param>
        /// <param name="shootMemory">摄影备注</param>
        [WebMethod]
        public bool ReShoot(string orderNO, string shootType, string shootDepartment, string shootAddress, string shootAddressName, string shootEmployeeNO, string shootEmployeeName, string preShootDate, string shootMemory)
        {
            // 先将对应类型的摄影记录设置失效
            try
            {
                ExecuteNonQuery(string.Format(@"UPDATE OrderShoot SET RecordState = 2 WHERE OrderNO='{0}' AND RecordState = 0 AND ShootType='{1}' AND IsDelete=0", orderNO, shootType));
            }
            catch
            {
                return false;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(@"            
            DECLARE 
            @orderNO VARCHAR(20) = '{0}',
            @shootType VARCHAR(10) = '{1}',
            @shootDepartment VARCHAR(30) = '{2}',
            @shootAddress VARCHAR(30) = '{3}',
            @shootEmployeeNO VARCHAR(30) = '{4}',
            @preShootDate VARCHAR(30) = '{5}',
            @shootMemory VARCHAR(MAX) = '{6}',
            @opEmployee VARCHAR(30) = '{7}',
            @opDepartment VARCHAR(30) = '{8}',
            @opDateTime DATETIME = GETDATE(),
            @shootAddressName VARCHAR(30) = '{9}',
            @shootEmployeeName VARCHAR(30) = '{10}'
	        INSERT INTO OrderShoot(OrderNO, ShootState, ShootType, ShootDepartment, ShootAddress, ShootEmployeeNO, PreShootDate, ShootMemory, OpEmployee, OpDepartment, OpDateTime)
	        VALUES(@orderNO, '重拍', @shootType, @shootDepartment, @shootAddress, @shootEmployeeNO, @preShootDate, @shootMemory, @opEmployee, @opDepartment, @opDateTime)", orderNO, shootType, shootDepartment, shootAddress, shootEmployeeNO, preShootDate, shootMemory, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeDepartmentNO, shootAddressName, shootEmployeeName));
            if(shootType == ShootType.Inside)
            {
                sb.AppendLine(@"
                IF EXISTS
                (
	                SELECT 1 FROM OrdersSub WHERE OrderNO = @orderNO
                )
                BEGIN 
	                UPDATE OrdersSub 
	                SET 
	                ShootAddressNameN = @shootAddressName,
	                ShootEmployeeNameN = @shootEmployeeName
	                WHERE OrderNO=@orderNO
                END
                ELSE BEGIN
	                INSERT INTO OrdersSub(OrderNO, ShootAddressNameN, ShootEmployeeNameN) 
	                VALUES (@orderNO, @shootAddressName, @shootEmployeeName)
                END");
            }
            else if(shootType == ShootType.Outside)
            {
                sb.AppendLine(@"
                IF EXISTS
                (
	                SELECT 1 FROM OrdersSub WHERE OrderNO = @orderNO
                )
                BEGIN 
	                UPDATE OrdersSub 
	                SET 
	                ShootAddressNameW = @shootAddressName,
	                ShootEmployeeNameW = @shootEmployeeName
	                WHERE OrderNO=@orderNO
                END
                ELSE BEGIN
	                INSERT INTO OrdersSub(OrderNO, ShootAddressNameW, ShootEmployeeNameW) 
	                VALUES (@orderNO, @shootAddressName, @shootEmployeeName)
                END");
            }
            try
            {
                ExecuteNonQuery(sb.ToString());
                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"安排[{0}]重拍, 摄影地点[{1}], 摄影师[{2}], 预约时间[{3}], 摄影备注[{4}]", shootType, shootAddressName, shootEmployeeName, preShootDate, shootMemory));
                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"安排[{0}]重拍, 摄影地点[{1}], 摄影师[{2}], 预约时间[{3}], 摄影备注[{4}]", shootType, shootAddressName, shootEmployeeName, preShootDate, shootMemory));
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 查询看样重拍的订单
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns>结果集</returns>
        [WebMethod]
        public DataSet SearchChooseReShoot(string orderNO)
        {
            string strSql = string.Format(@"SELECT v.OrderNO, v.PreChooseDate, v.CustomerName1, v.CustomerName2, v.MobilePhone1, v.MobilePhone2,
	                                               CASE WHEN f.OrderNO IS NULL THEN 0 ELSE 1 END AS NeedReShoot,
	                                               f.ShootType AS ReShootType, f.FlagTime
                                            FROM View_Orders v LEFT JOIN FlagReshoot f ON v.OrderNO = f.OrderNO AND f.FlagState = '正常'
                                            WHERE OrderNO = '{0}'", orderNO);
            return ExecuteQuery(strSql);
        }
        /// <summary>
        /// 查询看样重拍的订单
        /// </summary>
        /// <param name="dtBegin">预约看样时间起始</param>
        /// <param name="dtEnd">预约看样时间起始结束</param>
        /// <returns>结果集</returns>
        [WebMethod]
        public DataSet SearchChooseReShoot(DateTime dtBegin, DateTime dtEnd)
        {
            string strSql = string.Format(@"SELECT v.OrderNO, v.PreChooseDate, v.CustomerName1, v.CustomerName2, v.MobilePhone1, v.MobilePhone2,
	                                               CASE WHEN f.OrderNO IS NULL THEN 0 ELSE 1 END AS NeedReShoot,
	                                               f.ShootType AS ReShootType, f.FlagTime
                                            FROM View_Orders v LEFT JOIN FlagReshoot f ON v.OrderNO = f.OrderNO AND f.FlagState = '正常'
                                            WHERE DATEDIFF(dd, '{0}', v.PreChooseDate) >= 0 AND DATEDIFF(dd, v.PreChooseDate, '{1}') >= 0", dtBegin.ToShortDateString(), dtEnd.ToShortDateString());
            return ExecuteQuery(strSql);
        }
        /// <summary>
        /// 查询看样重拍的订单
        /// </summary>
        /// <returns>查询结果</returns>
        [WebMethod]
        public DataSet SearchReShootOrder()
        {
            const string sSql = @"
                                    SELECT CardNO, CustomerNO, f.OrderNO, FPH, CustomerName1, CustomerName2,MobilePhone1,MobilePhone2, 
	                                       MarryDate, SuiteName, SuitePrice,OrderSuitePrice,OrderDepartment, OrderEmployee, OrderDate, 
	                                       PreShootDateN, ShootTitle, ShootTimeN1, ShootTimeN2, ShootMemory, PreShootDateW, PreChooseDate, 
	                                       DressAddress, DressEmployee, ModelEmployee, DressDate, DressMemory, ShootAddressN, ShootEmployeeN,
	                                       LightEmployeeN, ShootDateN, ShootMemoryN, ShootAddressW, ShootEmployeeW,LightEmployeeW, ShootDateW, 
	                                       ShootMemoryW,Process,OrderMemory,ShootSites, 
	                                       (SELECT 1) AS NeedReShoot, f.ShootType AS ReShootType, f.FlagTime
                                    FROM FlagReshoot f LEFT JOIN dbo.VIEW_Orders v ON f.OrderNO = v.OrderNO
                                    WHERE f.FlagState = '正常'";
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 查询摄控放量信息
        /// </summary>
        /// <param name="dt">摄控时间</param>
        /// <returns>摄控放量信息</returns>
        [WebMethod]
        public DataSet SearchShootControlArranged(DateTime dt)
        {
            return ExecuteQuery(string.Format(@"SELECT ControlType, ControlDate1, ControlDate2, Control1Type, Control1, Control1Name, Control2Type, Control2, Control2Name, ControlValue, UpdateEmployee, UpdateDate, CreateEmployee, CreateDate
                                                FROM VIEW_SearchN_ControlTable 
                                                WHERE ControlType='摄影' AND DATEDIFF(dd,ControlDate1,'{0}')=0", dt.ToShortDateString()));
        }
        /// <summary>
        /// 查询摄控锁定信息
        /// </summary>
        /// <param name="dt">摄控时间</param>
        /// <returns>摄控锁定信息</returns>
        [WebMethod]
        public DataSet SearchShootControlLocked(DateTime dt)
        {
            return ExecuteQuery(string.Format(@"SELECT Control1,Control2,ControlValue,IsLock FROM N_ControlTable WHERE ControlType='摄影' AND DATEDIFF(dd,ControlDate1,'{0}')=0", dt.ToShortDateString()));
        }
        /// <summary>
        /// 查询摄控所有接单地点名称
        /// </summary>
        /// <param name="dt">摄控时间</param>
        /// <returns>摄控所有接单地点名称</returns>
        [WebMethod]
        public List<string> SearchShootControlOrderDepartmentName(DateTime dt)
        {
            List<string> lst = new List<string>();
            using(DataSet ds = ExecuteQuery(string.Format(@"SELECT DISTINCT Control2Name FROM VIEW_SearchN_ControlTable WHERE ControlType='摄影' AND DATEDIFF(dd,ControlDate1,'{0}')=0", dt.ToShortDateString())))
            {
                if(null == ds || 0 == ds.Tables.Count)
                {
                    return lst;
                }
                using(DataTable d = ds.Tables[0])
                {
                    lst.AddRange(from DataRow row in d.Rows select row["Control2Name"].SafeDbValue<string>());
                }
            }
            return lst;
        }
        /// <summary>
        /// 查询摄控已排信息
        /// </summary>
        /// <param name="dt">摄控时间</param>
        /// <returns>摄控已排信息</returns>
        [WebMethod]
        public DataSet SearchShootControlSetted(DateTime dt)
        {
            return ExecuteQuery(string.Format(@"SELECT o.OrderDepartmentNO, b.ShootDepartment, COUNT(1) Number 
                                                FROM 
                                                Orders o JOIN
                                                (
	                                                SELECT OrderNO,ShootDepartment, CONVERT(VARCHAR(10),PreShootDate,23) AS preShootDate
	                                                FROM OrderShoot WHERE IsDelete=0
	                                                GROUP BY OrderNO,ShootState,ShootDepartment, CONVERT(VARCHAR(10),PreShootDate,23)
                                                ) b ON o.OrderNO=b.orderNO WHERE o.IsDelete=0 AND DATEDIFF(dd,b.PreShootDate,'{0}')=0 GROUP BY o.OrderDepartmentNO,ShootDepartment", dt.ToShortDateString()));
        }
        /// <summary>
        /// 查询摄控所有拍摄场馆名称
        /// </summary>
        /// <param name="dt">摄控时间</param>
        /// <returns>摄控所有拍摄场馆名称</returns>
        [WebMethod]
        public List<string> SearchShootControlShootAddressName(DateTime dt)
        {
            List<string> lst = new List<string>();
            using(DataSet ds = ExecuteQuery(string.Format(@"SELECT DISTINCT Control1Name FROM VIEW_SearchN_ControlTable WHERE ControlType='摄影' AND DATEDIFF(dd,ControlDate1,'{0}')=0", dt.ToShortDateString())))
            {
                if(null == ds || 0 == ds.Tables.Count)
                {
                    return lst;
                }
                using(DataTable d = ds.Tables[0])
                {
                    lst.AddRange(from DataRow row in d.Rows select row["Control1Name"].SafeDbValue<string>());
                }
            }
            return lst;
        }
        /// <summary>
        /// 查询摄控订单
        /// </summary>
        /// <param name="filter">条件过滤语句</param>
        /// <returns>查询结果</returns>
        [WebMethod]
        public DataSet SearchShootOrder(string filter)
        {
            string sSql = string.Format(@"
                                            SELECT CardNO, CustomerNO, v.OrderNO, FPH, CustomerName1, CustomerName2,MobilePhone1,MobilePhone2, 
	                                               MarryDate, SuiteName, SuitePrice,OrderSuitePrice,OrderDepartment, OrderEmployee, OrderDate, 
	                                               PreShootDateN, ShootTitle, ShootTimeN1, ShootTimeN2, ShootMemory, PreShootDateW, PreChooseDate, 
	                                               DressAddress, DressEmployee, ModelEmployee, DressDate, DressMemory, ShootAddressN, ShootEmployeeN,
	                                               LightEmployeeN, ShootDateN, ShootMemoryN, ShootAddressW, ShootEmployeeW,LightEmployeeW, ShootDateW, 
	                                               ShootMemoryW,Process,OrderMemory,ShootSites, 
	                                               CASE WHEN f.OrderNO IS NULL THEN 0 ELSE 1 END AS NeedReShoot,
	                                               f.ShootType AS ReShootType, f.FlagTime
                                            FROM dbo.VIEW_Orders v LEFT JOIN FlagReshoot f ON v.OrderNO = f.OrderNO AND f.FlagState = '正常'
                                            WHERE 1=1 {0}", filter);
            return ExecuteQuery(sSql);
        }
        /// <summary>
        /// 设置需要重拍
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="type">重拍类型</param>
        [WebMethod]
        public void SetNeedReShoot(string orderNO, string type)
        {
            string strSql = string.Format(@"
                                            DECLARE @orderNO VARCHAR(30) = '{0}'
                                            DECLARE @shootType VARCHAR(10) = '{1}'
                                            DECLARE @flagEmpNO VARCHAR(50) = '{2}'
                                            IF EXISTS (SELECT 1 FROM FlagReshoot WHERE OrderNO = @orderNO AND FlagState = '正常')
                                            BEGIN
	                                            UPDATE FlagReshoot 
	                                            SET ShootType = @shootType, FlagTime = GETDATE(), FlagEmpNO = @flagEmpNO
	                                            WHERE OrderNO = @orderNO AND FlagState = '正常'
                                            END
                                            ELSE BEGIN
	                                            INSERT INTO FlagReshoot(OrderNO, ShootType, FlagTime, FlagEmpNO, FlagState) 
	                                            VALUES(@orderNO, @shootType, GETDATE(), @flagEmpNO, '正常')
                                            END", orderNO, type, Information.CurrentUser.EmployeeNO);
            ExecuteNonQuery(strSql);
            LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"看样标记[{0}]需要重拍", type));
            LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"看样标记[{0}]需要重拍", type));
        }
        /// <summary>
        /// 设置摄影备注
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="memory">摄影备注</param>
        [WebMethod]
        public bool SetShootMemory(string orderNO, string memory)
        {
            try
            {
                ExecuteNonQuery(string.Format(@"UPDATE OrderShoot SET ShootMemory = '{0}' WHERE OrderNO = '{1}'", memory, orderNO));
                LogManagement.SaveOperateLog(orderNO, LogType.Shoot, string.Format(@"修改摄影备注为[{0}]", memory));
                LogManagement.SaveOrderLog(orderNO, LogType.Shoot, string.Format(@"修改摄影备注为[{0}]", memory));
                return true;
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
                return false;
            }
        }
    }
}