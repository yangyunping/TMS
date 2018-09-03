using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldenLadyWS
{
    public class LookBanDal : ErpService
    {
        static LookBanDal _instance;
        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static LookBanDal Instance
        {
            get
            {
                return _instance ?? (_instance = new LookBanDal());
            }
        }

        public int SameShootEmployeeInLookBan(string shootEmployee, DateTime lookbanDate)
        {
            string sqlString = @"with look as
(
select ROW_NUMBER()over(partition by os.OrderNO order by os.PreShootDate desc) rowNO,e.EmployeeName
from OrderProducts op 
join OrderShoot os on op.OrderNO=os.OrderNO and os.ShootType='内景'
left join Employee e on e.EmployeeNO=os.ShootEmployeeNO
where datediff(dd,PreLookDate,'" + lookbanDate + @"')=0 
)
select count(1) from look where rowNO=1 and EmployeeName='" + shootEmployee + "'";
            return (int)ExecuteScalar(sqlString);
        }
    }
}
