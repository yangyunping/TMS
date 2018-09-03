using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Services;
using GoldenLady.Extension;
using GoldenLady.Global.Exception;
using GoldenLady.Standard;
using GoldenLady.Utility;
using GoldenLadyWS.Model;

namespace GoldenLadyWS
{
    /// <summary>
    /// 用于订单状态管理的数据库操作方法集
    /// </summary>
    public sealed class OrderState : ErpService
    {
        private static OrderState _theInstance;
        private OrderState() {}

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static OrderState Instance
        {
            get { return _theInstance ?? (_theInstance = new OrderState()); }
        }

        #region Methods

        /// <summary>
        /// 生成新订单
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void NewOrder(string orderNO)
        {
            string strSql = string.Format(@"DECLARE @orderNO VARCHAR(20) = '{0}'
                                            IF NOT EXISTS(SELECT * FROM OrderState WHERE OrderNO = @orderNO AND IsDeleted = 0)
                                            BEGIN
	                                            INSERT INTO OrderState(OrderNO) VALUES(@orderNO)
                                            END", orderNO);
            if(ExecuteNonQuery(strSql) <= 0)
                return;
            LogManagement.SaveOperateLog(orderNO, LogType.OrderStateChanged, @"生成新订单");
            LogManagement.SaveOrderLog(orderNO, LogType.OrderStateChanged, @"生成新订单");
        }
        /// <summary>
        /// 订单失效
        /// </summary>
        /// <param name="orderNO"></param>
        [WebMethod]
        public void Deleted(string orderNO)
        {
            string strSql = string.Format(@"UPDATE OrderState SET IsDeleted = 1 WHERE OrderNO = '{0}'", orderNO);
            if(ExecuteNonQuery(strSql) <= 0)
                return;
            LogManagement.SaveOperateLog(orderNO, LogType.OrderStateChanged, @"使订单失效");
            LogManagement.SaveOrderLog(orderNO, LogType.OrderStateChanged, @"使订单失效");
        }
        /// <summary>
        /// 等待拍摄
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void WaitShoot(string orderNO)
        {
            SimpleUpdate(orderNO, "WaitShoot", OrderStateName.WaitShoot);
        }
        /// <summary>
        /// 等待重拍
        /// </summary>
        /// <param name="orderNO"></param>
        [WebMethod]
        public void WaitReShoot(string orderNO)
        {
            string strPrevStateName = GetCurrentStateName(orderNO);
            string strSql = string.Format(@"UPDATE OrderState 
                                            SET CurrentStateName = '等待拍摄', WaitShoot = 1,
                                            ShootFinished = 0,WaitPreDesign = 0,PreDesigning = 0,PreDesignFinished = 0,Choosing = 0,
                                            ChooseFinished = 0,WaitDesign = 0,Designing = 0,DesignFinished = 0,Producing = 0,
                                            WaitGetGoods = 0,GetGoodsFinished = 0,OrderFinished = 0
                                            WHERE IsDeleted = 0 AND OrderNO = '{0}'", orderNO);
            if(ExecuteNonQuery(strSql) <= 0)
                return;
            SaveSimpleOperateLog(orderNO, strPrevStateName, OrderStateName.WaitShoot);
        }
        /// <summary>
        /// 等待补拍
        /// </summary>
        /// <param name="orderNO"></param>
        [WebMethod]
        public void WaitDelayShoot(string orderNO)
        {
            string strPrevStateName = GetCurrentStateName(orderNO);
            string strSql = string.Format(@"UPDATE OrderState 
                                            SET CurrentStateName = '等待拍摄', WaitShoot = 1,
                                            ShootFinished = 0,WaitPreDesign = 0,PreDesigning = 0,PreDesignFinished = 0,Choosing = 0,
                                            ChooseFinished = 0,WaitDesign = 0,Designing = 0,DesignFinished = 0,Producing = 0,
                                            WaitGetGoods = 0,GetGoodsFinished = 0,OrderFinished = 0
                                            WHERE IsDeleted = 0 AND OrderNO = '{0}'", orderNO);
            if(ExecuteNonQuery(strSql) <= 0)
                return;
            SaveSimpleOperateLog(orderNO, strPrevStateName, OrderStateName.WaitShoot);
        }
        /// <summary>
        /// 拍摄完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void ShootFinished(string orderNO)
        {
            SimpleUpdate(orderNO, "ShootFinished", OrderStateName.ShootFinished);
        }
        /// <summary>
        /// 等待样前设计
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void WaitPreDesign(string orderNO)
        {
            SimpleUpdate(orderNO, "WaitPreDesign", OrderStateName.WaitPreDesign);
        }
        /// <summary>
        /// 样前设计中
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void PreDesigning(string orderNO)
        {
            SimpleUpdate(orderNO, "PreDesigning", OrderStateName.PreDesigning);
        }
        /// <summary>
        /// 样前设计完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void PreDesignFinished(string orderNO)
        {
            SimpleUpdate(orderNO, "PreDesignFinished", OrderStateName.PreDesignFinished);
        }
        /// <summary>
        /// 看样中
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void Choosing(string orderNO)
        {
            SimpleUpdate(orderNO, "Choosing", OrderStateName.Choosing);
        }
        /// <summary>
        /// 看样完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void ChooseFinished(string orderNO)
        {
            SimpleUpdate(orderNO, "ChooseFinished", OrderStateName.ChooseFinished);
        }
        /// <summary>
        /// 等待样后设计
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void WaitDesign(string orderNO)
        {
            SimpleUpdate(orderNO, "WaitDesign", OrderStateName.WaitDesign);
        }
        /// <summary>
        /// 样后设计中
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void Designing(string orderNO)
        {
            SimpleUpdate(orderNO, "Designing", OrderStateName.Designing);
        }
        /// <summary>
        /// 样后设计完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void DesignFinished(string orderNO)
        {
            SimpleUpdate(orderNO, "DesignFinished", OrderStateName.DesignFinished);
        }
        /// <summary>
        /// 生产中
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void Producing(string orderNO)
        {
            SimpleUpdate(orderNO, "Producing", OrderStateName.Producing);
        }
        /// <summary>
        /// 等待取件
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void WaitGetGoods(string orderNO)
        {
            SimpleUpdate(orderNO, "WaitGetGoods", OrderStateName.WaitGetGoods);
        }
        /// <summary>
        /// 取件完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void GetGoodsFinished(string orderNO)
        {
            SimpleUpdate(orderNO, "GetGoodsFinished", OrderStateName.GetGoodsFinished);
        }
        /// <summary>
        /// 归档完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void OrderFinished(string orderNO)
        {
            SimpleUpdate(orderNO, "OrderFinished", OrderStateName.OrderFinished);
        }
        /// <summary>
        /// 能否进入等待拍摄
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterWaitShoot(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.NewOrder && strCurrStateName != OrderStateName.WaitShoot)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"安排摄控操作失败！{0}因为该订单的当前状态不是'新订单'或'等待拍摄'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
            string sqlString = "select 1 from OrdersPayState where OrderNO='" + orderNO + "' and (PayableSuite = 0.0 or (PayableSuite != 0.0 and ActualSuite != 0.0))";
            string result = ExecuteScalar(sqlString).SafeDbString();
            if("1" != result)
            {
                throw OrderException.NoCashPaid;
            }
        }
        /// <summary>
        /// 能否安排摄控
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="type">拍摄类型</param>
        [WebMethod]
        public void CanScheduleShoot(string orderNO, string type)
        {
            // 订单是否确定了拍摄类型
            string strShootType = ExecuteScalar(string.Format(@"SELECT ShootSites FROM Orders WHERE IsDelete = 0 AND OrderNO = '{0}'", orderNO)).SafeDbString();
            if(string.IsNullOrWhiteSpace(strShootType))
            {
                throw new OrderException(OrderExceptionType.Normal, @"该订单尚未确定拍摄的类型（内景、外景、全套），不能安排摄控，请完善订单资料！");
            }

            // 要安排的拍摄类型与订单拍摄类型不能冲突
            if(strShootType == ShootType.All)
                return;

            if(ShootType.All == type || strShootType != type)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单的拍摄类型为'{0}'，不能安排'{1}'摄控", strShootType, type));
            }
        }
        /// <summary>
        /// 能否进入等待补拍
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="type">拍摄类型</param>
        [WebMethod]
        public void CanEnterWaitDelayShoot(string orderNO, string type)
        {
            // 订单是否确定了拍摄类型
            string strShootType = ExecuteScalar(string.Format(@"SELECT ShootSites FROM Orders WHERE IsDelete = 0 AND OrderNO = '{0}'", orderNO)).SafeDbString();
            if(string.IsNullOrWhiteSpace(strShootType))
            {
                throw new OrderException(OrderExceptionType.Normal, @"该订单尚未确定拍摄的类型（内景、外景、全套），不能安排重拍，请完善订单资料！");
            }

            try
            {
                // 订单是否进入过等待拍摄的状态
                HasEnteredWaitShoot(orderNO);
            }
            catch (OrderException ex)
            {
                MessageBoxEx.Error(ex.Message);
                return;
            }
            if(ShootType.All == type) // 排全套
            {
                // 是否对应
                if(ShootType.All != strShootType)
                {
                    throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单的拍摄类型为'{0}'，不能安排'{1}'摄控", strShootType, type));
                }

                // 是否还有没拍完的
                using(DataSet ds = ExecuteQuery(string.Format(@"SELECT ShootState, ShootType, CASE WHEN DATEDIFF(dd, ShootDate, '1900-01-01') = 0 THEN NULL ELSE ShootDate END AS ShootDate FROM OrderShoot WHERE IsDelete = 0 AND OrderNO = '{0}'", orderNO)))
                {
                    if(ds.IsEmpty())
                        throw new OrderException(OrderExceptionType.Normal, @"该订单没有拍摄记录！");
                    StringBuilder sb = new StringBuilder();
                    using(DataTable dt = ds.Tables[0])
                    {
                        foreach(DataRow dr in dt.Rows.Cast<DataRow>().Where(dr => dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue)))
                        {
                            sb.AppendLine(string.Format(@"'{0}'的'{1}' 尚未拍摄完成！", dr["ShootState"].SafeDbString(), dr["ShootType"].SafeDbString()));
                        }
                    }
                    if(sb.Length > 0)
                    {
                        throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能安排'{0}'补拍，因为：{1}{2}", type, Environment.NewLine, sb));
                    }
                }
            }
            else if(ShootType.Inside == type) // 排内景
            {
                // 是否对应
                if(ShootType.Outside == strShootType)
                {
                    throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单的拍摄类型为'{0}'，不能安排'{1}'摄控", strShootType, type));
                }

                // 是否还有没拍完的
                using(DataSet ds = ExecuteQuery(string.Format(@"SELECT ShootState, CASE WHEN DATEDIFF(dd, ShootDate, '1900-01-01') = 0 THEN NULL ELSE ShootDate END AS ShootDate FROM OrderShoot WHERE IsDelete = 0 AND ShootType = '内景' AND OrderNO = '{0}'", orderNO)))
                {
                    if(ds.IsEmpty())
                        throw new OrderException(OrderExceptionType.Normal, @"该订单没有拍摄记录！");
                    StringBuilder sb = new StringBuilder();
                    using(DataTable dt = ds.Tables[0])
                    {
                        foreach(DataRow dr in dt.Rows.Cast<DataRow>().Where(dr => dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue)))
                        {
                            sb.AppendLine(string.Format(@"'{0}'的'内景' 尚未拍摄完成！", dr["ShootState"].SafeDbString()));
                        }
                    }
                    if(sb.Length > 0)
                    {
                        throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能安排'{0}'补拍，因为：{1}{2}", type, Environment.NewLine, sb));
                    }
                }
            }
            else if(ShootType.Outside == type) // 排外景
            {
                // 是否对应
                if(ShootType.Inside == strShootType)
                {
                    throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单的拍摄类型为'{0}'，不能安排'{1}'摄控", strShootType, type));
                }

                // 是否还有没拍完的
                using(DataSet ds = ExecuteQuery(string.Format(@"SELECT ShootState, CASE WHEN DATEDIFF(dd, ShootDate, '1900-01-01') = 0 THEN NULL ELSE ShootDate END AS ShootDate FROM OrderShoot WHERE IsDelete = 0 AND ShootType = '外景' AND OrderNO = '{0}'", orderNO)))
                {
                    if(ds.IsEmpty())
                        throw new OrderException(OrderExceptionType.Normal, @"该订单没有拍摄记录！");
                    StringBuilder sb = new StringBuilder();
                    using(DataTable dt = ds.Tables[0])
                    {
                        foreach(DataRow dr in dt.Rows.Cast<DataRow>().Where(dr => dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue)))
                        {
                            sb.AppendLine(string.Format(@"'{0}'的'外景' 尚未拍摄完成！", dr["ShootState"].SafeDbString()));
                        }
                    }
                    if(sb.Length > 0)
                    {
                        throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能安排'{0}'补拍，因为：{1}{2}", type, Environment.NewLine, sb));
                    }
                }
            }
        }
        /// <summary>
        /// 能否进入等待重拍
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="type">拍摄类型</param>
        /// <param name="needChangeState">是否需要改变状态到等待拍摄</param>
        [WebMethod]
        public void CanEnterWaitReShoot(string orderNO, string type)
        {
            // 订单是否确定了拍摄类型
            string strShootType = ExecuteScalar(string.Format(@"SELECT ShootSites FROM Orders WHERE IsDelete = 0 AND OrderNO = '{0}'", orderNO)).SafeDbString();
            if(string.IsNullOrWhiteSpace(strShootType))
            {
                throw new OrderException(OrderExceptionType.Normal, @"该订单尚未确定拍摄的类型（内景、外景、全套），不能安排重拍，请完善订单资料！");
            }

            // 订单是否进入过等待拍摄的状态
            HasEnteredWaitShoot(orderNO);

            if(ShootType.All == type) // 排全套
            {
                // 是否对应
                if(ShootType.All != strShootType)
                {
                    throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单的拍摄类型为'{0}'，不能安排'{1}'摄控", strShootType, type));
                }

                // 是否还有没拍完的
                using(DataSet ds = ExecuteQuery(string.Format(@"SELECT ShootState, ShootType, CASE WHEN DATEDIFF(dd, ShootDate, '1900-01-01') = 0 THEN NULL ELSE ShootDate END AS ShootDate FROM OrderShoot WHERE IsDelete = 0 AND OrderNO = '{0}'", orderNO)))
                {
                    if(ds.IsEmpty())
                        throw new OrderException(OrderExceptionType.Normal, @"该订单没有拍摄记录！");
                    StringBuilder sb = new StringBuilder();
                    using(DataTable dt = ds.Tables[0])
                    {
                        foreach(DataRow dr in dt.Rows.Cast<DataRow>().Where(dr => dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue)))
                        {
                            sb.AppendLine(string.Format(@"'{0}'的'{1}' 尚未拍摄完成！", dr["ShootState"].SafeDbString(), dr["ShootType"].SafeDbString()));
                        }
                    }
                    if(sb.Length > 0)
                    {
                        throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能安排'{0}'重拍，因为：{1}{2}", type, Environment.NewLine, sb));
                    }
                }
            }
            else if(ShootType.Inside == type) // 排内景
            {
                // 是否对应
                if(ShootType.Outside == strShootType)
                {
                    throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单的拍摄类型为'{0}'，不能安排'{1}'摄控", strShootType, type));
                }

                // 是否还有没拍完的
                using(DataSet ds = ExecuteQuery(string.Format(@"SELECT ShootState, CASE WHEN DATEDIFF(dd, ShootDate, '1900-01-01') = 0 THEN NULL ELSE ShootDate END AS ShootDate FROM OrderShoot WHERE IsDelete = 0 AND ShootType = '内景' AND OrderNO = '{0}'", orderNO)))
                {
                    if(ds.IsEmpty())
                        throw new OrderException(OrderExceptionType.Normal, @"该订单没有拍摄记录！");
                    StringBuilder sb = new StringBuilder();
                    using(DataTable dt = ds.Tables[0])
                    {
                        foreach(DataRow dr in dt.Rows.Cast<DataRow>().Where(dr => dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue)))
                        {
                            sb.AppendLine(string.Format(@"'{0}'的'内景' 尚未拍摄完成！", dr["ShootState"].SafeDbString()));
                        }
                    }
                    if(sb.Length > 0)
                    {
                        throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能安排'{0}'重拍，因为：{1}{2}", type, Environment.NewLine, sb));
                    }
                }
            }
            else if(ShootType.Outside == type) // 排外景
            {
                // 是否对应
                if(ShootType.Inside == strShootType)
                {
                    throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单的拍摄类型为'{0}'，不能安排'{1}'摄控", strShootType, type));
                }

                // 是否还有没拍完的
                using(DataSet ds = ExecuteQuery(string.Format(@"SELECT ShootState, CASE WHEN DATEDIFF(dd, ShootDate, '1900-01-01') = 0 THEN NULL ELSE ShootDate END AS ShootDate FROM OrderShoot WHERE IsDelete = 0 AND ShootType = '外景' AND OrderNO = '{0}'", orderNO)))
                {
                    if(ds.IsEmpty())
                        throw new OrderException(OrderExceptionType.Normal, @"该订单没有拍摄记录！");
                    StringBuilder sb = new StringBuilder();
                    using(DataTable dt = ds.Tables[0])
                    {
                        foreach(DataRow dr in dt.Rows.Cast<DataRow>().Where(dr => dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue)))
                        {
                            sb.AppendLine(string.Format(@"'{0}'的'外景' 尚未拍摄完成！", dr["ShootState"].SafeDbString()));
                        }
                    }
                    if(sb.Length > 0)
                    {
                        throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能安排'{0}'重拍，因为：{1}{2}", type, Environment.NewLine, sb));
                    }
                }
            }
        }
        /// <summary>
        /// 能否进入拍摄完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="type">拍摄类型</param>
        /// <param name="dtPreShoot">排控时间</param>
        [WebMethod]
        public void CanEnterShootFinished(string orderNO, string type, DateTime dtPreShoot)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.WaitShoot)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"{0}拍摄完成操作失败！{1}因为该订单的当前状态不是'等待拍摄'，当前状态为'{2}'", type, Environment.NewLine, strCurrStateName));
            }
            if(!ExecuteScalar(string.Format(@"SELECT CASE WHEN (ActualSuite - PayableSuite >= 0.0) AND (ActualShoot - PayableShoot >= 0.0) THEN 1 ELSE 0 END AS Can FROM OrdersPayState WHERE OrderNO = '{0}'", orderNO)).SafeDbBoolean())
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"{0}拍摄完成操作失败！{1}因为该订单还存在'套系欠款'或'摄影欠款'", type, Environment.NewLine));
            }
            string strShootType = ExecuteScalar(string.Format(@"SELECT ShootSites FROM Orders WHERE IsDelete = 0 AND OrderNO = '{0}'", orderNO)).SafeDbString();
            if((ShootType.All != strShootType) && (type != strShootType))
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"{0}拍摄完成操作失败！{1}因为该订单的拍摄类型为'{2}'", type, Environment.NewLine, strShootType));
            }
            if(dtPreShoot.Subtract(DateTime.Now).Days > 0)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"{0}拍摄完成操作失败！{1}因为当前时间还没有超过预约排控时间！", type, Environment.NewLine));
            }
        }
        /// <summary>
        /// 能否变更状态至拍摄完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns></returns>
        [WebMethod]
        public bool CanChangeToShootFinished(string orderNO)
        {
            string strShootType = ExecuteScalar(string.Format(@"SELECT ShootSites FROM Orders WHERE IsDelete = 0 AND OrderNO = '{0}'", orderNO)).SafeDbString();

            // 是否还有没拍完的
            using(DataSet ds = ExecuteQuery(string.Format(@"SELECT ShootType, CASE WHEN DATEDIFF(dd, ShootDate, '1900-01-01') = 0 THEN NULL ELSE ShootDate END AS ShootDate,CASE WHEN DATEDIFF(dd, PreShootDate, '1900-01-01') = 0 THEN NULL ELSE PreShootDate END AS PreShootDate FROM OrderShoot WHERE IsDelete = 0 AND RecordState = 0 AND OrderNO = '{0}'", orderNO)))
            {
                if(ds.IsEmpty())
                {
                    throw new OrderException(OrderExceptionType.Normal, @"该订单没有拍摄记录！");
                }
                using(DataTable dt = ds.Tables[0])
                {
                    bool bN = dt.Rows.Cast<DataRow>().Any(dr => dr["ShootType"].SafeDbString() == ShootType.Inside && !dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue));
                    bool bW = dt.Rows.Cast<DataRow>().Any(dr => dr["ShootType"].SafeDbString() == ShootType.Outside && !dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue));
                    if(strShootType == ShootType.Inside)
                    {
                        return bN;
                    }
                    if(strShootType == ShootType.Outside)
                    {
                        return bW;
                    }
                    if(strShootType == ShootType.All)
                    {
                        return bN && bW;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// 能否进入等待样前设计
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterWaitPreDesign(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.ShootFinished && strCurrStateName != OrderStateName.PreDesigning && strCurrStateName != OrderStateName.WaitPreDesign)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'等待样前设计'{0}因为当前订单状态不是'拍摄完成'或'等待样前设计'或'样前设计中'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否进入样前设计中
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterPreDesigning(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.WaitPreDesign && strCurrStateName != OrderStateName.PreDesigning && strCurrStateName != OrderStateName.PreDesignFinished)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'样前设计中'{0}因为当前订单状态不是'等待样前设计'或'样前设计中'或'样前设计完成'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否进入样前设计完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterPreDesignFinished(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.PreDesigning && strCurrStateName != OrderStateName.PreDesignFinished)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'样前设计完成'{0}因为当前订单状态不是'样前设计中'或'样前设计完成'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否进入看样中（选片）
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterChoosing(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.PreDesignFinished && strCurrStateName != OrderStateName.Choosing && strCurrStateName != OrderStateName.ChooseFinished)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'看样中'{0}因为当前订单状态不是'样前设计完成'或'看样中'或'看样完成'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否进入看样完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterChooseFinished(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.Choosing && strCurrStateName != OrderStateName.ChooseFinished)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'看样完成'{0}因为当前订单状态不是'看样中'或'看样完成'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否进入等待样后设计
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterWaitDesign(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.ChooseFinished)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'等待样后设计'{0}因为当前订单状态不是'看样完成'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
            if(!ExecuteScalar(string.Format(@"SELECT CASE WHEN (ActualChoose - PayableChoose >= 0.0) THEN 1 ELSE 0 END AS Can FROM OrdersPayState WHERE OrderNO = '{0}'", orderNO)).SafeDbBoolean())
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'等待样后设计'{0}因为当前订单还存在'看样欠款'", Environment.NewLine));
            }
        }
        /// <summary>
        /// 能否进入样后设计中
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterDesigning(string orderNO)
        { 
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.WaitDesign && strCurrStateName != OrderStateName.Designing && strCurrStateName != OrderStateName.DesignFinished)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'样后设计中'{0}因为当前订单状态不是'等待样后设计'或'样后设计中'或'样后设计完成'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否进入样后设计完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterDesignFinished(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.Designing && strCurrStateName != OrderStateName.DesignFinished)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'样后设计完成'{0}因为当前订单状态不是'样后设计中'或'样后设计完成'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否进入生产中
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterProducing(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.DesignFinished && strCurrStateName != OrderStateName.Producing)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'生产中'{0}因为当前订单状态不是'样后设计完成'或'生产中'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否进入等待取件
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterWaitGetGoods(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.Producing)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'等待取件'{0}因为当前订单状态不是'生产中'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否进入取件完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterGetGoodsFinished(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.WaitGetGoods)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'取件完成'{0}因为当前订单状态不是'等待取件'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
            if(!ExecuteScalar(string.Format(@"SELECT CASE WHEN (ActuaGetGoods - PayableGetGoods >= 0.0) THEN 1 ELSE 0 END AS Can FROM OrdersPayState WHERE OrderNO = '{0}'", orderNO)).SafeDbBoolean())
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能进入'取件完成'{0}因为当前订单还存在'取件欠款'", Environment.NewLine));
            }
        }
        /// <summary>
        /// 能否进入归档完成
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanEnterOrderFinished(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.GetGoodsFinished)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能归档{0}因为当前订单状态不是'取件完成'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
            string sSql = "select * from Orders where IsDelete = 0 AND OrderNO ='" + orderNO + "'and datediff(dd,GetGoodsDate,getdate())>=30";
            if (ExecuteQuery(sSql).Tables[0].Rows.Count == 0)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能归档{0}因为当前距离订单取件完成的时间还未超过30天", Environment.NewLine));
            }
        }
        /// <summary>
        /// 能否删除摄控
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void CanDeleteShoot(string orderNO)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.WaitShoot)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能删除摄控{0}因为当前订单状态不是'等待拍摄'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }
        }
        /// <summary>
        /// 能否改期摄影
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <param name="type">摄影类型</param>
        /// <param name="state">摄影状态</param>
        [WebMethod]
        public void CanChangeShootDate(string orderNO, string type, string state)
        {
            string strCurrStateName = GetCurrentStateName(orderNO);
            if(strCurrStateName != OrderStateName.WaitShoot)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单不能改期摄控{0}因为当前订单状态不是'等待拍摄'，当前状态为'{1}'", Environment.NewLine, strCurrStateName));
            }

            string strShootType = ExecuteScalar(string.Format(@"SELECT ShootSites FROM Orders WHERE IsDelete = 0 AND OrderNO = '{0}'", orderNO)).SafeDbString();
            if(strShootType != ShootType.All && strShootType != type)
            {
                throw new OrderException(OrderExceptionType.Normal, string.Format(@"该订单的拍摄类型为'{0}'，不能安排'{1}'摄控", strShootType, type));
            }

            using(DataSet ds = ExecuteQuery(string.Format(@"SELECT ShootType, ShootState, CASE WHEN DATEDIFF(dd, ShootDate, '1900-01-01') = 0 THEN NULL ELSE ShootDate END AS ShootDate,CASE WHEN DATEDIFF(dd, PreShootDate, '1900-01-01') = 0 THEN NULL ELSE PreShootDate END AS PreShootDate FROM OrderShoot WHERE IsDelete = 0 AND OrderNO = '{0}' AND ShootState = '{1}'", orderNO, state)))
            {
                if(ds.IsEmpty())
                {
                    throw new OrderException(OrderExceptionType.Normal, @"该订单没有拍摄记录！");
                }
                using(DataTable dt = ds.Tables[0])
                {
                    if(ShootType.All == type)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach(DataRow data in dt.Rows.Cast<DataRow>().Where(dr => !dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue)))
                        {
                            sb.AppendLine(string.Format(@"'{0}'已经拍摄完成！", data["ShootType"].SafeDbString()));
                        }
                        if(sb.Length > 0)
                        {
                            throw new OrderException(OrderExceptionType.Normal, string.Format(@"当前不能安排全套改期，因为存在：{0}{1}", Environment.NewLine, sb));
                        }
                    }
                    else if(!dt.Rows.Cast<DataRow>().Any(dr => !dr["PreShootDate"].SafeDbDateTime().Equals(DateTime.MinValue) && dr["ShootDate"].SafeDbDateTime().Equals(DateTime.MinValue))) // 内外景
                    {
                        throw new OrderException(OrderExceptionType.Normal, string.Format(@"当前不能安排{0}改期，因为本次摄影已经完成，或者摄控已被删除！", type));
                    }
                }
            }
        }
        /// <summary>
        /// 标识订单是否要补拍或重拍
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="shootDate"></param>
        /// <param name="reShoot"></param>
        /// <param name="orderState"></param>
        [WebMethod]
        public void SetReShoot(string orderNO, DateTime shootDate, ReShoot reShoot, string orderState)
        {
            string sqlString = "update OrderShoot set ShootState ='" + orderState + "',  ReShoot=" + (byte)reShoot + " where OrderNO='" + orderNO + "' and datediff(dd,PreShootDate,'" + shootDate.ToShortDateString() + "')=0";
            ExecuteNonQuery(sqlString);
        }
        /// <summary>
        /// 获取订单的状态信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns>状态信息，如果订单号不存在则为null</returns>
        [WebMethod]
        public OrderStateInformation GetOrderStateInformation(string orderNO)
        {
            string strSql = string.Format(@"SELECT TOP 1 * FROM OrderState WHERE IsDeleted = 0 AND OrderNO = '{0}'", orderNO);
            using(DataSet ds = ExecuteQuery(strSql))
            {
                return ds.IsEmpty() ? null : ds.Tables[0].Rows[0];
            }
        }
        /// <summary>
        /// 获取用于展示的部分订单信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns>订单信息，如果订单号不存在则为null</returns>
        [WebMethod]
        public OrderInfoToShow GetOrderInfoToShow(string orderNO)
        {
            string strSql = string.Format(@"SELECT OrderNO, CustomerNO, FPH, [onLine], CustomerName1, CustomerName2, SuiteName, SuitePrice, ShootEmployeeN, ShootEmployeeW, ShootAddressN, ShootAddressW, PreShootDateN, PreShootDateW, ShootDateN, ShootDateW, LightEmployeeN, LightEmployeeW, DressEmployeeN, DressEmployeeW, DressAssistantEmployeeN, DressAssistantEmployeeW, MobilePhone1, MobilePhone2, Address1, Address2, IntroducerType, IntroducerCardNO, Birthday1, Birthday2, ShootSites, OrderDate FROM View_Orders o WHERE IsDelete = 0 AND OrderNO = '{0}'", orderNO);
            using(DataSet ds = ExecuteQuery(strSql))
            {
                return ds.IsEmpty() ? null : ds.Tables[0].Rows[0];
            }
        }
        /// <summary>
        /// 获取用于展示的摄影记录信息
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns>摄影记录信息，如果订单号不存在则为null</returns>
        [WebMethod]
        public List<ShootRecord> GetOrderShootRecords(string orderNO)
        {
            string strSql = string.Format(@"SELECT ShootState, ShootType, PreShootDate, CASE WHEN DATEDIFF(dd, ShootDate, '1900-01-01') = 0 THEN NULL ELSE ShootDate END AS ShootDate FROM OrderShoot WHERE IsDelete = 0 AND RecordState = 0 AND OrderNO = '{0}'", orderNO);
            using(DataSet ds = ExecuteQuery(strSql))
            {
                if(ds.IsEmpty())
                    return null;
                List<ShootRecord> lstShootRecords = new List<ShootRecord>();
                using(DataTable dt = ds.Tables[0])
                {
                    lstShootRecords.AddRange(from DataRow dr in dt.Rows select (ShootRecord)dr);
                }
                return lstShootRecords;
            }
        }
        /// <summary>
        /// 获取当前订单状态名称
        /// </summary>
        /// <param name="orderNO">订单号</param>
        /// <returns>当前订单状态名称，如果不存在则返回null</returns>
        [WebMethod]
        public string GetCurrentStateName(string orderNO)
        {
            return ExecuteScalar(string.Format(@"SELECT CurrentStateName FROM OrderState WHERE IsDeleted = 0 AND OrderNO = '{0}'", orderNO)).SafeDbString();
        }
        /// <summary>
        /// 自动判断订单状态，在删除摄控记录后调用，当前的订单状态一定为等待拍摄
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void AutoDetectState(string orderNO)
        {
            using(DataSet ds = OrderShoot.GetOrderShootRecords(orderNO))
            {
                // 没有记录，新订单
                if(null == ds || null == ds.Tables[0])
                {
                    return;
                }

                using(DataTable dt = ds.Tables[0])
                {
                    string strShootType = ExecuteScalar(string.Format(@"SELECT ShootSites FROM Orders WHERE OrderNO = '{0}' AND IsDelete = 0", orderNO)).SafeDbString();
                    if(string.IsNullOrEmpty(strShootType))
                    {
                        return;
                    }

                    if(strShootType == ShootType.Inside)
                    {
                        DataRow[] drs = dt.Select("ShootType = '内景' AND RecordState = 0", "OpDateTime DESC");
                        // 没有拍摄记录，回到新订单
                        if(drs.Length <= 0)
                        {
                            ReturnToNewOrder(orderNO);
                        }
                        else
                        {
                            // 有拍摄记录，且完成了，切换到拍摄完成
                            DataRow dr = drs[0];
                            if(!DateTimeNotSet(dr["ShootDate"].SafeDbDateTime()))
                            {
                                ShootFinished(orderNO);
                            }
                        }
                    }
                    else if(strShootType == ShootType.Outside)
                    {
                        DataRow[] drs = dt.Select("ShootType = '外景' AND RecordState = 0", "OpDateTime DESC");
                        // 没有拍摄记录，回到新订单
                        if(drs.Length <= 0)
                        {
                            ReturnToNewOrder(orderNO);
                        }
                        else
                        {
                            // 有拍摄记录，且完成了，切换到拍摄完成
                            DataRow dr = drs[0];
                            if(!DateTimeNotSet(dr["ShootDate"].SafeDbDateTime()))
                            {
                                ShootFinished(orderNO);
                            }
                        }
                    }
                    else if(strShootType == ShootType.All)
                    {
                        DataRow[] drsW = dt.Select("ShootType = '外景' AND RecordState = 0", "OpDateTime DESC");
                        DataRow[] drsN = dt.Select("ShootType = '内景' AND RecordState = 0", "OpDateTime DESC");
                        // 内外都没有拍摄记录，回到新订单
                        if(drsN.Length <= 0 && drsW.Length <= 0)
                        {
                            ReturnToNewOrder(orderNO);
                        }
                        else if(drsN.Length > 0 && drsW.Length > 0)
                        {
                            // 有拍摄记录，且都完成了，切换到拍摄完成
                            DataRow drN = drsN[0];
                            DataRow drW = drsW[0];
                            if(!DateTimeNotSet(drN["ShootDate"].SafeDbDateTime()) && !DateTimeNotSet(drW["ShootDate"].SafeDbDateTime()))
                            {
                                ShootFinished(orderNO);
                            }
                        }
                    }
                }
            }
            LogManagement.SaveOperateLog(orderNO, LogType.OrderStateChanged, @"由于删除了摄控，系统重新判断订单当前状态");
            LogManagement.SaveOrderLog(orderNO, LogType.OrderStateChanged, @"由于删除了摄控，系统重新判断订单当前状态");
        }
        private void ReturnToNewOrder(string orderNO)
        {
            string strPrevStateName = GetCurrentStateName(orderNO);
            string strSql = string.Format(@"UPDATE OrderState 
                                                SET CurrentStateName = '新订单', NewOrder = 1, WaitShoot = 0,
                                                ShootFinished = 0,WaitPreDesign = 0,PreDesigning = 0,PreDesignFinished = 0,Choosing = 0,
                                                ChooseFinished = 0,WaitDesign = 0,Designing = 0,DesignFinished = 0,Producing = 0,
                                                WaitGetGoods = 0,GetGoodsFinished = 0,OrderFinished = 0
                                                WHERE IsDeleted = 0 AND OrderNO = '{0}'", orderNO);
            ExecuteNonQuery(strSql);
            SaveSimpleOperateLog(orderNO, strPrevStateName, OrderStateName.NewOrder);
        }
        private static bool DateTimeNotSet(DateTime dt)
        {
            return dt.Equals(DateTime.MinValue) || dt.Date.Equals(DateTime.Parse("1900-01-01").Date);
        }
        private static void SaveSimpleOperateLog(string orderNO, string stateFrom, string stateTo)
        {
            LogManagement.SaveOperateLog(orderNO, LogType.OrderStateChanged, string.Format(@"将订单状态由[{0}]变为[{1}]", stateFrom, stateTo));
            LogManagement.SaveOrderLog(orderNO, LogType.OrderStateChanged, string.Format(@"将订单状态由[{0}]变为[{1}]", stateFrom, stateTo));
        }
        private void SimpleUpdate(string orderNO, string fieldName, string fieldNameChs)
        {
            string strPrevStateName = GetCurrentStateName(orderNO);
            string strSql = string.Format(@"UPDATE OrderState 
                                            SET {0} = 1, CurrentStateName = '{1}' 
                                            WHERE IsDeleted = 0 AND OrderNO = '{2}'", fieldName, fieldNameChs, orderNO);
            if(ExecuteNonQuery(strSql) <= 0)
                return;
            SaveSimpleOperateLog(orderNO, strPrevStateName, fieldNameChs);
        }
        private void HasEnteredWaitShoot(string orderNO)
        {
            if(!ExecuteScalar(string.Format(@"SELECT WaitShoot FROM OrderState WHERE IsDeleted = 0 AND OrderNO = '{0}'", orderNO)).SafeDbBoolean())
            {
                throw new OrderException(OrderExceptionType.Normal, @"补拍/重拍 操作失败！因为该订单从未进入过'等待拍摄'的状态");
            }
        }

        #endregion
    }
}