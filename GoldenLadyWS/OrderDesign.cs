using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLady.Utility;

namespace GoldenLadyWS
{
    /*0-分件 1-样前设计 2-样前设计完成 3-看样完成 4-样后设计 5-样后设计完成 6-质检完成 7-打包完成*/
    public class OrderDesign: ErpService
    {
        static OrderDesign _instance;
        internal static OrderDesign Instance
        {
            get
            {
                return _instance??(_instance = new OrderDesign());
            }
        }       
        private OrderDesign() { }
        /// <summary>
        /// 设计员工
        /// </summary>
        /// <returns></returns>
        public DataSet GetDesignEmployee()
        {
            string sqlString = "select ElementNO,ElementName,EmployeeNO,EmployeeName from Element el join Employee emp on el.ElementNO=emp.DepartmentNO where ElementType='设计地点' and emp.IsDelete=0";
            return base.ExecuteQuery(sqlString);
        }

        public DataSet GetDispatchOrderProducts(string keyWords, DateTime dt1, DateTime dt2)
        {
            string whereDate = string.Empty;
            if (dt1> DEF_DATETIME && dt2 > DEF_DATETIME)
            {
                whereDate = " where datediff(dd,PreShootDate,'" + dt1.ToShortDateString() + @"')<=0 and datediff(dd,PreShootDate,'" + dt2.ToShortDateString() + @"')>=0 ";
            }
            string sqlString = @"with shoot as
(
	select OrderNO,CONVERT(varchar(10),PreShootDate,111) PreShootDate from OrderShoot " + whereDate + @" group by OrderNO,CONVERT(varchar(10),PreShootDate,111)
)
select o.OrderNO,c.CustomerName1+' '+c.CustomerName2 CustomerName,Suite.SuiteName,o.ImageCount,
shoot.PreShootDate PreShootDateN,sub.ShootAddressNameN,
o.PreChooseDate,sub.ChooseAddressName,od.DispatchDate,
o.PreGetGoodsDate,em.EmployeeName as DispatchEmployeeName,ep.EmployeeName as SpecifiedEmployeeName,
op.OrderIndex,pt.ProductTypeName,p.ProductNO,p.ProductName,p.ProductSizeA+'*'+p.ProductSizeB ProductSize,op.NegativeQuantity,op.PageQuantity,op.ProductQuantity,op.ProductMemory+op.ProductElement ProductMemory,
case when od.OrderNO is null then '未分件' else '已分件' end as Dispatched
from Orders o 
join shoot on shoot.OrderNO=o.OrderNO
join Customers c on o.CustomerNO=c.CustomerNO
join Suite on Suite.SuiteNO=o.SuiteNO
join OrdersSub sub on sub.OrderNO=o.OrderNO
join OrderProducts op on o.OrderNO=op.OrderNO and op.ProduceState='正常'
join Products p on p.ProductNO=op.ProductNO
join ProductType pt on pt.ProductTypeNO=p.ProductTypeNO
left join OrderDesign od on od.OrderNO=o.OrderNO and op.OrderIndex=od.OrderIndex
left join Employee em on em.EmployeeNO=od.DispatchEmployeeNO
left join Employee ep on ep.EmployeeNO=od.SpecifiedEmployeeNO   ";
            if (!string.IsNullOrWhiteSpace(keyWords))
            {
                sqlString += "where (o.OrderNO like '%" + keyWords + "%' or c.CustomerName1 like '%" + keyWords + "%' or c.CustomerName2 like '%" + keyWords + "%' or c.MobilePhone1 like '%" + keyWords + "%' or c.MobilePhone2 like '%" + keyWords + "%')";
            }
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 分件
        /// </summary>
        /// <param name="orderNOs"></param>
        /// <param name="orderIndex"></param>
        /// <param name="priority"></param>
        /// <param name="specifiedDepNO"></param>
        /// <param name="specifiedEmpNO"></param>
        /// <param name="dispatchDepNO"></param>
        /// <param name="dispatchEmpNO"></param>
        /// <returns></returns>
        public bool DispatchOrderProducts(string orderNOs,string[] orderIndex, byte priority,string specifiedDepNO, string specifiedEmpNO,string dispatchDepNO,string dispatchEmpNO)
        {
            string sqlString = string.Empty;
            for (int i = 0; i < orderIndex.Length; ++i)
            {
                sqlString += @" if not exists (select 1 from OrderDesign where OrderNO='" + orderNOs + "' and OrderIndex='" + orderIndex[i] + @"')
begin 
    insert into OrderDesign (OrderNO,OrderIndex,Pri,DispatchDepartmentNO,DispatchEmployeeNO,DispatchDate,SpecifiedDepartmentNO,SpecifiedEmployeeNO,CreateDate) 
values ('" + orderNOs + "','" + orderIndex[i] + "'," + priority + ",'" + dispatchDepNO + "','" + dispatchEmpNO + "',GETDATE(),'" + specifiedDepNO + @"','" + specifiedEmpNO + @"',GETDATE()) 
end
else
   update OrderDesign set OrderNO ='" + orderNOs + "' ,OrderIndex ='" + orderIndex[i] + "',Pri =" + priority + ",DispatchDepartmentNO='" + dispatchDepNO + "',DispatchEmployeeNO='" + dispatchEmpNO + "',DispatchDate = GETDATE(),SpecifiedDepartmentNO = '" + specifiedDepNO + @"',SpecifiedEmployeeNO='" + specifiedEmpNO + @"',CreateDate =GETDATE()  where OrderNO='" + orderNOs + "' and OrderIndex='" + orderIndex[i] + @"' ";
            }
            return ExecuteNonQuery(sqlString) > 0; 
        }

        /// <summary>
        /// 保存订单产品设计信息(看样环节)
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <param name="orderIndices">订单产品索引集</param>
        /// <returns>是否执行成功</returns>
        public bool SaveOrderDesign(string orderNo, string[] orderIndices)
        {
            if (null == orderIndices || 0 == orderIndices.Length) { return false; }
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(@"DECLARE @orderNO VARCHAR(20) = '{0}',
		                                      @empNO VARCHAR(20),
                                              @depNO VARCHAR(20),
                                              @dispatchEmpNO varchar(20)='{1}',
                                              @dispatchDepNO varchar(20)='{2}'
                                              SELECT TOP 1 @depNO=SpecifiedDepartmentNO,@empNO = SpecifiedEmployeeNO FROM OrderDesign WHERE OrderNO = @orderNO
                                              INSERT INTO OrderDesign (OrderNO,OrderIndex,[State],DispatchDepartmentNO,DispatchEmployeeNO,DispatchDate,SpecifiedDepartmentNO,SpecifiedEmployeeNO,PreDesignDepartmentNO,PreDesignEmployeeNO,PreDesignDate,CreateDate) 
                                              VALUES ", orderNo, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeDepartmentNO));
            foreach (string orderIndex in orderIndices)
            {
                sb.Append(string.Format(@"(@orderNO,'{0}',2 ,@dispatchDepNO,@dispatchEmpNO,GETDATE(),@depNO,@empNO,@depNO,@empNO,GETDATE(),GETDATE()),", orderIndex));
            }
            sb.Length -= 1; // 去除尾巴多余的逗号
            return ExecuteNonQuery(sb.ToString())>0;
        }
        /// <summary>
        /// 删除订单产品设计信息(看样环节)
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <param name="orderIndices">订单产品索引集</param>
        /// <returns>是否执行成功</returns>
        public bool DeleteOrderDesign(string orderNo, string orderIndices)
        {
            if (string.Empty == orderIndices || 0 == orderIndices.Length) { return false; }
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format(@"Delete from OrderDesign where OrderNO = '{0}' and OrderIndex = '{1}' ",orderNo,orderIndices));
            return ExecuteNonQuery(sb.ToString()) > 0;
        }
        /// <summary>
        /// 获取样前设计完成的订单(要质检)
        /// </summary>
        /// <returns></returns>
        public DataSet GetPreDesignCompleteOrders()
        {
            return GetPreDesignOrders(string.Empty, string.Empty);
        }
        /// <summary>
        /// 获取样前设计完成的订单(要质检)，指定定单号
        /// </summary>
        /// <returns></returns>
        public DataSet GetPreDesignCompleteOrders(string orderNO)
        {
            return GetPreDesignOrders(string.Empty, orderNO);
        }
        /// <summary>
        /// 获取样前设计的订单，查询员工要进行样前设计的订单
        /// </summary>
        /// <returns></returns>
        public DataSet GetPreDesignOrders(string empNO)
        {
            return GetPreDesignOrders(empNO,string.Empty);
        }
        /// <summary>
        /// 获取样前设计的订单
        /// </summary>
        /// <param name="empNO"></param>
        /// <returns></returns>
        public DataSet GetPreDesignOrders(string empNO, string orderNO)
        {
            string sqlString = @"with preDesign
as(
	select o.OrderNO,c.CustomerName1,c.CustomerName2,o.ImagePath,o.BackupPath,Suite.SuiteName,o.Process,
	o.OrderSuitePrice,o.ImageCount,d.DepartmentName ShootAddress,e.EmployeeName ShootEmployee,os.PreShootDate,
	os.ShootMemory,o.OrderMemory,od.PreDesignEmployeeNO,od.SpecifiedEmployeeNO,od.[State],od.Pri,
	ROW_NUMBER()over(partition by o.OrderNO order by os.PreShootDate desc) rowNum
	from Orders o join Customers c on o.CustomerNO=c.CustomerNO	
	join OrderDesign od on od.OrderNO=o.OrderNO
	left join Suite on Suite.SuiteNO=o.SuiteNO
	left join OrderShoot os on os.OrderNO=o.OrderNO
	left join Department d on d.DepartmentNO=os.ShootDepartment
	left join Employee e on e.EmployeeNO=os.ShootEmployeeNO
)
select [State],Pri,OrderNO,CustomerName1,CustomerName2,ImagePath,BackupPath,SuiteName,Process,
OrderSuitePrice,ImageCount,ShootAddress,ShootEmployee,PreShootDate,e.EmployeeName DesignEmployee,
ShootMemory,OrderMemory
from preDesign left join Employee e on preDesign.SpecifiedEmployeeNO=e.EmployeeNO
where rowNum=1 ";
            if (string.IsNullOrWhiteSpace(empNO) && string.IsNullOrWhiteSpace(orderNO))/*两个都为空表示查询样前设计完成的订单*/
            {
                /*这个是要进行质检用的*/
                sqlString += "and [State]=2 ";//样前完成 
            }
            else if (!string.IsNullOrWhiteSpace(orderNO) && string.IsNullOrWhiteSpace(empNO))
            {
                /*这个是要进行质检用的*/
                sqlString += "and [State]=2 and OrderNO like '%" + orderNO + "%'";//样前完成 
            }
            else if (!string.IsNullOrWhiteSpace(empNO) && string.IsNullOrWhiteSpace(orderNO))/*订单号为空表示查询要设计的订单*/
            {
                /*设计人员查询自己要做的订单,多个订单*/
                sqlString += "and ((([State]=0 or [State]=1) and preDesign.SpecifiedEmployeeNO='" + empNO + "') or ([State]=2 and preDesign.PreDesignEmployeeNO='" + empNO + "')) ";
            }
            else
            {
                /*设计人员查询自己的订单（做没做都可以）*/
                sqlString += " and OrderNO like '%" + orderNO + "%' and ((([State]=0 or [State]=1) and preDesign.SpecifiedEmployeeNO='" + empNO + "') or ([State]=2 and preDesign.PreDesignEmployeeNO='" + empNO + "')) ";
            }
            sqlString += " order by [State] desc";
            return ExecuteQuery(sqlString);
        }

        /// <summary>
        /// 改变订单的所有产品的设计状态
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <param name="orderIndices">订单产品索引集</param>
        /// <param name="state">要更改为的目标状态</param>
        /// <returns>是否执行成功</returns>
        public bool ChangeDesignState(string orderNo, Model.DesignState state)
        {
            if (string.IsNullOrWhiteSpace(orderNo))
            { return false; }
            string strSql = string.Format(@"UPDATE OrderDesign SET [State] ={0} WHERE OrderNO = '{1}'", (byte)state, orderNo);
            return ExecuteNonQuery(strSql)>0;
        }
        /// <summary>
        /// 改变订单指定产品索引的产品的设计状态
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="orderindices"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool ChangeDesignState(string orderNo,string[] orderindices, Model.DesignState state)
        {
            string sqlString = string.Format("update OrderDesign set [State]={0} where OrderNO='{1}' and OrderIndex in ('{2}')", (byte)state, orderNo, string.Join("','", orderindices));
            return ExecuteNonQuery(sqlString)>0;
        }
        /// <summary>
        /// 查询数据用于订单验证
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public DataSet OrderValidateData(string orderNO)
        {
            string sqlString = "select ImagePath,ImageCount from Orders where OrderNO='"+orderNO+"'";
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 样前设计完成
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public bool PreDesignComplete(string orderNO,string employeeNO, string departmentNO)
        {
            //设计状态/*0-分件 1-样前设计 2-样前设计完成 3-看样完成 4-样后设计 5-样后设计完成 6-打包完成*/
            string sqlString = "update OrderDesign set PreDesignDate=GETDATE(),[State]=2,PreDesignEmployeeNO='" + employeeNO + "',PreDesignDepartmentNO='" + departmentNO + "' where OrderNO='" + orderNO + "'";
            return ExecuteNonQuery(sqlString) > 0;
        } 

        /// <summary>
        /// 更新产品路径
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="orderIndexes"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool UpdateProductImagePath(string orderNO, string[] orderIndexes,string path)
        {
            string sqlString = @"update OrderDesign set ProductImagePath='" + path + "' where OrderNO='" + orderNO + "' and OrderIndex in('" + string.Join("','", orderIndexes) + "')";
            return ExecuteNonQuery(sqlString) > 0;
        }
        /// <summary>
        /// 样后设计完成
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="orderIndexes"></param>
        /// <param name="employeeNO"></param>
        /// <param name="departmentNO"></param>
        /// <returns></returns>
        public bool DesignComplete(string orderNO,string[] orderIndexes, string employeeNO, string departmentNO)
        {
            /*0-分件 1-样前设计 2-样前设计完成 3-看样完成 4-样后设计 5-样后设计完成 6-打包完成*/
            string sqlString = "update OrderDesign set DesignDate=GETDATE(),[State]=5,DesignEmployeeNO='" + employeeNO + "',DesignDepartmentNO='" + departmentNO + "' where OrderNO='" + orderNO + "' and OrderIndex in('" + string.Join("','", orderIndexes) + "')";
            return ExecuteNonQuery(sqlString) > 0;
        }
        /// <summary>
        /// 获取样前设计的订单,设计人员获取以做设计
        /// </summary>
        /// <returns></returns>
        public DataSet GetOrderDesigns(string employeeNO)
        {
            string sqlString = @"with design as
(
	select od.OrderNO,od.OrderIndex,op.ProductNO,p.ProductName,pt.ProductTypeName,p.ProductSizeA,p.ProductSizeB,
	op.PageQuantity,op.NegativeQuantity,count(opt.[FileName]) ChooseNegativeQuantity,op.ProductQuantity,
	op.ProductElement+op.ProductMemory ProductMemory,op.ProduceState,od.Pri,od.[State],ProductImagePath,
	op.PreGetGoodsDate,op.GetGoodsAddress,dbo.Fn_GetDepartmentName(op.GetGoodsAddress) GetGoodsAddressName,
	op.PreLookDate,op.LookAddress,dbo.Fn_GetDepartmentName(op.LookAddress) LookAddressName,op.LookMemory,p.BackProductTypeNO,
	od.DispatchDepartmentNO,dbo.Fn_GetDepartmentName(od.DispatchDepartmentNO) DispatchDepartmentName,od.DispatchEmployeeNO,dbo.Fn_GetEmployeeName(od.DispatchEmployeeNO) DispatchEmployeeName,od.DispatchDate,
	od.SpecifiedDepartmentNO,dbo.Fn_GetDepartmentName(od.SpecifiedDepartmentNO) SpecifiedDepartmentName,od.SpecifiedEmployeeNO,dbo.Fn_GetEmployeeName(od.SpecifiedEmployeeNO) SpecifiedEmployeeName,
	od.PreDesignDepartmentNO,dbo.Fn_GetDepartmentName(od.PreDesignDepartmentNO) PreDesignDepartmentName,od.PreDesignEmployeeNO,dbo.Fn_GetEmployeeName(od.PreDesignEmployeeNO) PreDesignEmployeeName,od.PreDesignDate,
	od.DesignDepartmentNO,dbo.Fn_GetDepartmentName(od.DesignDepartmentNO) DesignDepartmentName,od.DesignEmployeeNO,dbo.Fn_GetEmployeeName(od.DesignEmployeeNO) DesignEmployeeName,od.DesignDate,
	od.PackageDepartmentNO,dbo.Fn_GetDepartmentName(od.PackageDepartmentNO) PackageDepartmentName,od.PackageEmployeeNO,dbo.Fn_GetEmployeeName(od.PackageEmployeeNO) PackageEmployeeName,od.PackageDate,
    od.IsInLook
	from OrderDesign od 
	join OrderProducts op on op.OrderNO=od.OrderNO and op.OrderIndex=od.OrderIndex and op.ProduceState='正常' and (od.[State]=3 or od.[State]=4)
	join Products p on p.ProductNO=op.ProductNO
	join ProductType pt on pt.ProductTypeNO=p.ProductTypeNO
	left join OrderProductImage opt on od.OrderNO=opt.OrderNO and od.OrderIndex=opt.OrderIndex
	group by od.OrderNO,od.OrderIndex,op.ProductNO,p.ProductName,pt.ProductTypeName,p.ProductSizeA,p.ProductSizeB,
	op.PageQuantity,op.NegativeQuantity,op.ProductQuantity,
	op.ProductElement,op.ProductMemory,op.ProduceState,od.Pri,od.[State],ProductImagePath,
	op.PreGetGoodsDate,op.GetGoodsAddress,op.PreLookDate,op.LookAddress,op.LookMemory,p.BackProductTypeNO,
	od.DispatchDepartmentNO,od.DispatchEmployeeNO,od.DispatchDate,
	od.SpecifiedDepartmentNO,od.SpecifiedEmployeeNO,
	od.PreDesignDepartmentNO,od.PreDesignEmployeeNO, od.PreDesignDate,
	od.DesignDepartmentNO,od.DesignEmployeeNO,od.DesignDate,
	od.PackageDepartmentNO,od.PackageEmployeeNO,od.PackageDate,od.IsInlook
),ord as
(
	select ROW_NUMBER()over(partition by o.OrderNO,od.OrderIndex order by os.PreShootDate desc) as rowNum,
	od.OrderNO,od.OrderIndex,c.CustomerName1,c.MobilePhone1,c.CustomerName2,c.MobilePhone2,c.MarryDate,c.MarryDate2,
	o.OrderSuitePrice,o.ImageCount,	o.ImagePath,Suite.SuiteName,o.OrderMemory,chsDep.DepartmentName as ChooseAddressName,
	os.PreShootDate,os.ShootDepartment,shootDep.DepartmentName ShootDepartmentName,shootEmp.EmployeeName ShootEmployeeName,os.ShootMemory
	from Orders o 
	join Customers c on o.CustomerNO=c.CustomerNO
	join OrderDesign od on od.OrderNO=o.OrderNO and (od.[State]=3 or od.[State]=4)
	join OrderShoot os on os.OrderNO=o.OrderNO
	join Suite on Suite.SuiteNO=o.SuiteNO
	left join Department chsDep on chsDep.DepartmentNO=o.ChooseAddress
	left join Department shootDep on shootDep.DepartmentNO=os.ShootDepartment
	left join Employee shootEmp on shootEmp.EmployeeNO=os.ShootEmployeeNO
)
select ord.OrderNO,ord.OrderIndex,ProductNO,ProductName,ProductTypeName,ProductSizeA,ProductSizeB,PageQuantity,NegativeQuantity,ChooseNegativeQuantity,ProductQuantity,ProductMemory,
ProduceState,Pri,[State],ProductImagePath,PreGetGoodsDate,GetGoodsAddress,GetGoodsAddressName,PreLookDate,LookAddress,LookAddressName,LookMemory,BackProductTypeNO,
DispatchDepartmentNO,DispatchDepartmentName,DispatchEmployeeNO,DispatchEmployeeName,DispatchDate,SpecifiedDepartmentNO,SpecifiedDepartmentName,
SpecifiedEmployeeNO,SpecifiedEmployeeName,PreDesignDepartmentNO,PreDesignDepartmentName,PreDesignEmployeeNO,PreDesignEmployeeName,PreDesignDate,DesignDepartmentNO,
DesignDepartmentName,DesignEmployeeNO,DesignEmployeeName,DesignDate,PackageDepartmentNO,PackageDepartmentName,PackageEmployeeNO,PackageEmployeeName,PackageDate,
CustomerName1,MobilePhone1,CustomerName2,MobilePhone2,OrderSuitePrice,ImageCount,ImagePath,SuiteName,MarryDate,MarryDate2,OrderMemory,ChooseAddressName,
PreShootDate,ShootDepartment,ShootDepartmentName,ShootEmployeeName,ShootMemory,IsInLook
from design join ord on design.OrderNO=ord.OrderNO and design.OrderIndex=ord.OrderIndex 
where ord.rowNum=1 and ((design.[State]=3 and SpecifiedEmployeeNO='" + employeeNO + "') or (design.[State]=4 and PreDesignEmployeeNO='" + employeeNO + "'))";
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 所有产品完成设计
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public bool IsAllDesigned(string orderNO)
        {
            string sqlString = "select count(1) from OrderDesign od join OrderProducts op on od.OrderNO=op.OrderNO and od.orderindex=op.OrderIndex and op.ProduceState='正常' where od.OrderNO='" + orderNO + "' and (od.DesignDate is null or datediff(dd,od.DesignDate,'1989-1-1')>0)";
            DataSet ds = ExecuteQuery(sqlString);
            return ds.Tables[0].Rows[0].Field<int>(0) == 0;
        }
        /// <summary>
        /// 按条件查询订单，用于打包，或查询打包完成的订单
        /// 有时间表示按时间查询打包完成的订单
        /// </summary>
        /// <param name="packageDate1"></param>
        /// <param name="packageDate2"></param>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public DataSet GetOrderDesignPackage(DateTime packageDate1, DateTime packageDate2,string keyWords)
        {
            string sqlString = @"select od.Pri,od.OrderNO,od.OrderIndex,c.CustomerName1,c.MobilePhone1,c.CustomerName2,c.MobilePhone2,
od.[State],op.ProductNO,p.ProductName,p.ProductSizeA,p.ProductSizeB,
od.DesignEmployeeNO,dbo.Fn_GetEmployeeName(od.DesignEmployeeNO) DesignEmployeeName,
od.DesignDepartmentNO,dbo.Fn_GetDepartmentName(od.DesignDepartmentNO) DesignDepartmentName,od.DesignDate,
od.PackageEmployeeNO,dbo.Fn_GetEmployeeName(od.PackageEmployeeNO) PackageEmployeeName,
od.PackageDepartmentNO,dbo.Fn_GetDepartmentName(od.PackageDepartmentNO) PackageDepartmentName, od.PackageDate,
op.PreGetGoodsDate,o.FPH,od.ProductImagePath,o.PreGetGoodsDate OrdPreGetGoodsDate,o.OrderMemory,o.SuitePrice
from OrderDesign od 
join OrderProducts op on od.OrderNO=op.OrderNO and od.OrderIndex=op.OrderIndex and op.ProduceState='正常'
join Products p on p.ProductNO=op.ProductNO
join Orders o on o.OrderNO=od.OrderNO
join Customers c on c.CustomerNO=o.CustomerNO
where 1=1 ";
            /*0-分件 1-样前设计 2-样前设计完成 3-看样完成 4-样后设计 5-样后设计完成 6-质检完成 7-打包完成*/
            if (packageDate1 > DefValue.Date1900 && packageDate2 > DefValue.Date1900)//有打包时间 打包完成
            {
                sqlString += "and od.[State]=7 and datediff(dd,od.PackageDate,'" + packageDate1.ToShortDateString() + "')<=0 and datediff(dd,od.PackageDate,'" + packageDate2.ToShortDateString() + "')>=0 ";
            }
            else
            {
                sqlString += "and od.[State]=6 ";
            }
            if (!string.IsNullOrWhiteSpace(keyWords))//有值
            {
                sqlString += "and (od.OrderNO like '%" + keyWords + "%' or c.CustomerName1 like '%" + keyWords + "%' or c.CustomerName1 like '%" + keyWords + "%' or c.MobilePhone1 like '%" + keyWords + "%' or c.MobilePhone2 like '%" + keyWords + "%') ";
            }
            sqlString += " order by op.PreGetGoodsDate,od.OrderNO ";
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 设计返工
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="orderIndexes"></param>
        /// <returns></returns>
        public int ReturnDesign(string orderNO, string[] orderIndexes)
        {
            string sqlString = string.Format("update OrderDesign set [State]=4 where OrderNO='{0}' and OrderIndex in ('{1}')", orderNO, string.Join("','", orderIndexes));
            return ExecuteNonQuery(sqlString);
        }
        /// <summary>
        /// 完成打包
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="orderindexes"></param>
        /// <param name="packageDepartmentNO"></param>
        /// <param name="packageEmployeeNO"></param>
        /// <param name="PackageDate"></param>
        /// <returns></returns>
        public int CompletePackage(string orderNO, string[] orderindexes, string packageDepartmentNO, string packageEmployeeNO)
        {
            string sqlString = string.Format("update OrderDesign set PackageDepartmentNO='{0}',PackageEmployeeNO='{1}',PackageDate=getdate(),[State]=7 where OrderNO='{2}' and OrderIndex in ('{3}')", 
                packageDepartmentNO, packageEmployeeNO, orderNO, string.Join("','", orderindexes));
            return ExecuteNonQuery(sqlString);
        }
        /// <summary>
        /// 设置或取消看版中
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <param name="orderindexes"></param>
        /// <param name="islook"></param>
        /// <returns></returns>
        public int IsInLook(string OrderNO, string[] orderindexes, bool islook)
        {
            string sqlString = string.Format("update OrderDesign set IsInLook='{0}' where OrderNO='{1}' and OrderIndex in ('{2}')", islook, OrderNO, string.Join("','", orderindexes));
            return ExecuteNonQuery(sqlString);
        }
        /// <summary>
        /// 质检样后设计的订单
        /// </summary>
        /// <returns></returns>
        public DataSet GetCheckDesign()
        {
            string sqlString = @"select od.OrderNO,od.OrderIndex, od.Pri,c.CustomerName1,c.CustomerName2,c.MobilePhone1,c.MobilePhone2,od.[State],
od.PreDesignDepartmentNO,dbo.Fn_GetDepartmentName(od.PreDesignDepartmentNO) PreDesignDepartmentName,od.PreDesignEmployeeNO,dbo.Fn_GetEmployeeName(od.PreDesignEmployeeNO) PreDesignEmployeeName,od.PreDesignDate,
od.DesignDepartmentNO,dbo.Fn_GetDepartmentName(od.DesignDepartmentNO) DesignDepartmentName,od.DesignEmployeeNO,dbo.Fn_GetEmployeeName(od.DesignEmployeeNO) DesignEmployeeName,od.DesignDate,
op.PreGetGoodsDate,op.PreLookDate,od.ProductImagePath
from OrderDesign od 
join OrderProducts op on od.OrderNO=op.OrderNO and od.OrderIndex=op.OrderIndex and op.ProduceState='正常' and od.[State]=5
join Orders o on o.OrderNO=od.OrderNO
join Customers c on c.CustomerNO=o.CustomerNO";
            return ExecuteQuery(sqlString);
        }
        /// <summary>
        /// 质检完成
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="orderIndexes"></param>
        /// <returns></returns>
        public int CompleteCheck(string orderNO, string[] orderIndexes)
        {
            /*0-分件 1-样前设计 2-样前设计完成 3-看样完成 4-样后设计 5-样后设计完成 6-质检完成 7-打包完成*/
            string sqlString = string.Format("update OrderDesign set [State]=6 where OrderNO='{0}' and OrderIndex in ('{1}')", orderNO, string.Join("','", orderIndexes));
            return ExecuteNonQuery(sqlString);
        }

        /// <summary>
        /// 删除订单设计记录
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public void DeleteDesign(string orderNO) {
            string sqlString = "Delete from OrderDesign where OrderNO ='" + orderNO + "'";
             ExecuteNonQuery(sqlString);
        }
    }
}
