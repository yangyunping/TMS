using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldenLadyWS
{
    public class ChooseDal : ErpService
    {
        static ChooseDal _instance;
        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static ChooseDal Instance
        {
            get
            {
                return _instance ?? (_instance = new ChooseDal());
            }
        }

        /// <summary>
        /// 指定摄影师在同一开看样的订单数量
        /// </summary>
        /// <param name="shootEmployeeName">摄影师名字</param>
        /// <param name="chooseDate">看样时间</param>
        /// <returns></returns>
        public int SameShootEmployeeInChoose(string shootEmployeeName, DateTime chooseDate)
        {
            string sqlString = @"with chs as(
select o.OrderNO,e.EmployeeName ShootEmployeeName,ROW_NUMBER()over(partition by o.OrderNO order by s.PreShootDate desc) rowNO
from Orders o 
join OrderShoot s on s.OrderNO=o.OrderNO and ShootType='内景'
left join Employee e on e.EmployeeNO=s.ShootEmployeeNO
where datediff(dd,o.PreChooseDate,'" + chooseDate + @"')=0
)
select count(1) from chs where chs.rowNO=1 and ShootEmployeeName='" + shootEmployeeName + "'";
            return (int)ExecuteScalar(sqlString);
        }
    }
}
