using System.Data;

namespace GoldenLadyWS
{
    /// <summary>
    /// 用于收银管理的数据库操作方法集
    /// </summary>
    public sealed class CashManagement : ErpService
    {
        private static CashManagement _theInstance;
        private CashManagement()
        {
        }

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static CashManagement Instance
        {
            get
            {
                return _theInstance ?? (_theInstance = new CashManagement());
            }
        }

        /// <summary>
        /// 查询需要收银的订单
        /// </summary>
        /// <param name="filter">筛选条件</param>
        /// <returns>需要收银的订单</returns>
        public DataSet SearchCashOrders(string filter)
        {
            return ExecuteQuery(string.Format(@"
            WITH T AS
            (
            SELECT				  dbo.Customers.CustomerNO, dbo.Customers.CardNO, dbo.Customers.IntroducerType, dbo.Customers.IntroducerCardNO, dbo.Customers.CustomerName1, 
                                  dbo.Customers.CustomerName2, dbo.Customers.MobilePhone1, dbo.Customers.MobilePhone2, dbo.Orders.OrderNO, dbo.Suite.SuiteName, 
                                  dbo.Orders.OrderSuitePrice, dbo.Department.DepartmentName AS OrderDepartment, dbo.Employee.EmployeeName AS OrderEmployee, dbo.Orders.OrderDate, 
					              ISNULL((dbo.OrdersPayState.PayableSuite - dbo.OrdersPayState.ActualSuite),0) AS Suite,
					              ISNULL((dbo.OrdersPayState.PayableShoot - dbo.OrdersPayState.ActualShoot),0) AS Shoot,
					              ISNULL((dbo.OrdersPayState.PayableClothes - dbo.OrdersPayState.ActualClothes),0) AS Clothes,
					              ISNULL((dbo.OrdersPayState.PayableChoose - dbo.OrdersPayState.ActualChoose),0) AS [Choose],
					              ISNULL((dbo.OrdersPayState.PayableGetGoods - dbo.OrdersPayState.ActuaGetGoods),0) AS GetGoods,
					              ISNULL((dbo.OrdersPayState.PayableOther - dbo.OrdersPayState.ActuaOther),0) AS Other,
					              ISNULL((dbo.OrdersPayState.PayableSuite - dbo.OrdersPayState.ActualSuite 
							            + dbo.OrdersPayState.PayableShoot - dbo.OrdersPayState.ActualShoot 
							            + dbo.OrdersPayState.PayableClothes - dbo.OrdersPayState.ActualClothes
							            + dbo.OrdersPayState.PayableChoose - dbo.OrdersPayState.ActualChoose
							            + dbo.OrdersPayState.PayableGetGoods - dbo.OrdersPayState.ActuaGetGoods
							            + dbo.OrdersPayState.PayableOther - dbo.OrdersPayState.ActuaOther),0) AS Total,
                                  dbo.SuiteType.SuiteTypeName, shootN.PreShootDate AS PreShootDateN, shootW.PreShootDate AS PreShootDateW, dbo.Orders.PreChooseDate, dbo.Orders.PreGetGoodsDate
            FROM				  dbo.OrdersPayState RIGHT JOIN
                                  dbo.Orders ON dbo.OrdersPayState.OrderNO = dbo.Orders.OrderNO LEFT JOIN
                                  (
						              SELECT OrderNO,PreShootDate,ShootAddress,ShootEmployeeNO,LightEmployeeNO,DressEmployeeNO,DressAssistantEmployeeNO,ShootDate,ShootMemory 
					                  FROM OrderShoot WHERE ShootType='内景' AND IsDelete=0 AND RecordState = 0
				                  ) AS shootN ON shootN.OrderNO=dbo.Orders.OrderNO LEFT JOIN
					              (
						              SELECT OrderNO,PreShootDate,ShootAddress,ShootEmployeeNO,LightEmployeeNO,DressEmployeeNO,DressAssistantEmployeeNO,ShootDate,ShootMemory 
						              FROM OrderShoot WHERE ShootType='外景' AND IsDelete=0 AND RecordState = 0
					              ) AS shootW ON shootW.OrderNO=dbo.Orders.OrderNO INNER JOIN 
                                  dbo.Customers ON dbo.Orders.CustomerNO = dbo.Customers.CustomerNO INNER JOIN
                                  dbo.Suite ON dbo.Orders.SuiteNO = dbo.Suite.SuiteNO INNER JOIN
                                  dbo.Department ON dbo.Orders.OrderDepartmentNO = dbo.Department.DepartmentNO INNER JOIN
                                  dbo.Employee ON dbo.Orders.OrderEmployeeNO = dbo.Employee.EmployeeNO  LEFT OUTER JOIN
                                  dbo.SuiteType ON dbo.Orders.SuiteTypeNO = dbo.SuiteType.SuiteTypeNO
            WHERE				  (dbo.Orders.OrderState = 1) AND (dbo.Orders.IsDelete = 0)
            )
            SELECT CustomerNO, CardNO, IntroducerType, IntroducerCardNO, CustomerName1, CustomerName2, MobilePhone1, MobilePhone2, 
	               OrderNO, SuiteTypeName, SuiteName, OrderSuitePrice, OrderDepartment, OrderEmployee, OrderDate, Suite, Shoot, 
	               Clothes, [Choose], GetGoods, Other, Total
            FROM T WHERE 1=1 {0}", filter));
        }
    }
}