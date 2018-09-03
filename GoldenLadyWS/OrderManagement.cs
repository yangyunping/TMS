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
    /// 用于订单管理的数据库操作方法集
    /// </summary>
    public sealed class OrderManagement : ErpService
    {
        private static OrderManagement _theInstance;
        private OrderManagement() {}

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static OrderManagement Instance
        {
            get { return _theInstance ?? (_theInstance = new OrderManagement()); }
        }

        /// <summary>
        /// 获取客户的所有订单
        /// </summary>
        /// <param name="customerNO">客户号</param>
        /// <returns>订单</returns>
        [WebMethod]
        public DataSet SearchCustomerOrders(string customerNO)
        {
            return ExecuteQuery(string.Format(@"SELECT DISTINCT CardNO, CustomerNO, OrderNO, FPH, IntroducerCardNO, CustomerName1, CustomerName2,MobilePhone1,MobilePhone2, MarryDate, SuiteName, SuitePrice,Discount,ReducesPresently,OrderSuitePrice, OrderMemory, ImageCount, OrderDepartment, OrderEmployee, OrderDate, PreClothesDate, PreDressDate, PreShootDateN, PreShootDateW, PreChooseDate, PreLookDate, PreGetGoodsDate, ClothesAddress, ClothesEmployee, ClothesDate, ClothesMemory, DressAddress, DressEmployee, ModelEmployee, DressDate, DressMemory, ShootAddressN, ShootEmployeeN, DressEmployeeN, ShootDateN, ShootMemoryN, ShootAddressW, ShootEmployeeW, DressEmployeeW, ShootDateW, ShootMemoryW, ChooseAddress, ChooseEmployee, ChooseDate, ChooseMeMory, LookAddress, LookEmployee, LookDate, LookMemory, GetGoodsAddress, GetGoodsEmployee, GetGoodsDate, GetGoodsMemory, ImagePath, ImageXSPath, ImageSJPath, BackupPath, OrdersIsDelete, Process
                                                FROM dbo.VIEW_Orders 
                                                WHERE IsDelete=0 AND CustomerNO = '{0}'", customerNO));
        }

        /// <summary>
        /// 获取订单的更多信息
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public IEnumerable<MoreInfoItem> GetMoreInfoItems(int pid)
        {
            string strSql = string.Format(@"SELECT * FROM MoreInfo WHERE PID {0}", pid == 0 ? @"IS NULL" : string.Format(@"= {0}", pid));
            using(DataSet ds = ExecuteQuery(strSql))
            {
                try
                {
                    return from DataRow row in ds.Tables[0].Rows select MoreInfoItem.FromDataRow(row);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询更多信息列表时遇到了问题导致失败！{0}方法名称：'OrderManagement.GetMoreInfoItems'", Environment.NewLine));
                }
                return new MoreInfoItem[] { };
            }
        }

        /// <summary>
        /// 新建订单
        /// </summary>
        /// <param name="orderInfo">订单信息</param>
        /// <param name="products">订单产品</param>
        /// <param name="boxes">包装数据集</param>
        /// <param name="frames">框条数据集</param>
        /// <param name="infoItems">了解的服务</param>
        /// <param name="moreInfoOther">了解的其他服务</param>
        /// <returns>是否执行成功</returns>
        [WebMethod]
        public bool NewOrder(OrderInfo orderInfo, IEnumerable<OrderProduct> products, IEnumerable<Box> boxes, IEnumerable<Frame> frames, IList<MoreInfoItem> infoItems, string moreInfoOther)
        {
            try
            {
                // 订单信息
                string strOrder = string.Format(@"
            DECLARE @CompanyBM VARCHAR(50) = '{0}',
		            @CustomerNO VARCHAR(50) = '{1}',
		            @SuiteTypeNO VARCHAR(50) = '{2}',
		            @SuiteNO VARCHAR(50) = '{3}',
		            @SuitePrice DECIMAL(18,2) = {4},
		            @Discount DECIMAL(18,2) = {5},
		            @ReducesPresently DECIMAL(18,2) = {6},
		            @ReducesPresently2 DECIMAL(18,2) = {7},
		            @ReducesPresently3 DECIMAL(18,2) = {8},
		            @OrderSuitePrice DECIMAL(18,2) = {9},
		            @AddPresently DECIMAL(18,2) = {10},
		            @OrderDepartmentNO VARCHAR(50) = '{11}',
		            @OrderEmployeeNO VARCHAR(50) = '{12}',
		            @OrderEmployeeNO2 VARCHAR(50) = '{13}',
		            @OnLine BIT = '{14}',
		            @IsDelete BIT = '{15}',
		            @Pregnant BIT = '{16}',
		            @OrderMemory NVARCHAR(500) = N'{17}',
		            @ShootSites VARCHAR(10) = '{18}',
		            @OrderSource VARCHAR(50) = '{19}'
            DECLARE @Prefix VARCHAR(50) = @CompanyBM + CONVERT(varchar, GETDATE(), 12) + 'I', @NewOrderNO VARCHAR(50)
            SELECT @NewOrderNO = @Prefix + RIGHT('000' + CAST(ISNULL(MAX(RIGHT(OrderNO, 4)), '0000') + 1 AS VARCHAR),4) FROM Orders WHERE OrderNO LIKE @Prefix + '%' 
            INSERT INTO Orders (CustomerNO,  OrderNO,	  FPH, SuiteTypeNO,   SuiteNO,  SuitePrice,  Discount,  ReducesPresently,  ReducesPresently2,  ReducesPresently3,  AddPresently,  OrderSuitePrice,  ImageCount, ShootAddressN, PreShootDateN, ShootAddressW, PreShootDateW, OrderDepartmentNO,  OrderEmployeeNO,  OrderEmployeeNO2,  [onLine], OrderDate, OrderMemory,  ImagePath, OrderState, LossType, LossMemory, IsDelete,  ShootMemoryN,ShootMemoryW,CompanyBM,  EstimateShootTimeYearMonth,EstimateShootTimeDay, ShootSites,  OrderSource,  IsNewOrder,Pregnant) 
            VALUES (			@CustomerNO, @NewOrderNO, '',  @SuiteTypeNO , @SuiteNO, @SuitePrice, @Discount, @ReducesPresently, @ReducesPresently2, @ReducesPresently3, @AddPresently, @OrderSuitePrice, 0,			'',			   '',	          '',			 '',		    @OrderDepartmentNO, @OrderEmployeeNO, @OrderEmployeeNO2, @OnLine,  GETDATE(), @OrderMemory, '',		   1,		   '',		 '',		 @IsDelete, '',		     '',		  @CompanyBM, '',						 '',				   @ShootSites, @OrderSource, 0,		 @Pregnant)",
                                                Information.Company.CompanyBM,
                                                orderInfo.CustomerInfo.CustomerNo,
                                                orderInfo.Suite.Type.Value,
                                                orderInfo.Suite.No,
                                                orderInfo.Suite.Price,
                                                orderInfo.Price.Disconut,
                                                orderInfo.Price.Reduce1,
                                                orderInfo.Price.Reduce2,
                                                orderInfo.Price.Reduce3,
                                                orderInfo.Price.FinalPrice,
                                                orderInfo.Price.Add,
                                                orderInfo.OrderEmployee.Department.No,
                                                orderInfo.OrderEmployee.No,
                                                orderInfo.OrderEmployee2 == null ? null : orderInfo.OrderEmployee2.No,
                                                orderInfo.OrderType.Value,
                                                false,
                                                orderInfo.Pregnant.Value,
                                                orderInfo.OrderMemory,
                                                orderInfo.ShootType,
                                                orderInfo.OrderSource.Value);

                // 订单Sub信息
                string strOrderSub = string.Format(@"
            DECLARE @SuiteTypeName VARCHAR(50) = '{0}',
		            @SuiteName VARCHAR(50) = '{1}',
		            @OrderDepartmentName VARCHAR(50) = '{2}',
		            @OrderEmployeeName VARCHAR(50) = '{3}',
		            @OrderEmployeeName2 VARCHAR(50) = '{4}',
		            @OrderSourceName VARCHAR(50) = '{5}'
            INSERT INTO OrdersSub (OrderNO,		SuiteTypeName,  SuiteName,  OrderDepartmentName,  OrderEmployeeName,  OrderEmployeeName2,  OrderSourceName) 
            VALUES (			   @NewOrderNO, @SuiteTypeName, @SuiteName, @OrderDepartmentName, @OrderEmployeeName, @OrderEmployeeName2, @OrderSourceName)",
                                                   orderInfo.Suite.Type.Name,
                                                   orderInfo.Suite.Name,
                                                   orderInfo.OrderEmployee.Department.Name,
                                                   orderInfo.OrderEmployee.Name,
                                                   orderInfo.OrderEmployee2 == null ? null : orderInfo.OrderEmployee2.Name,
                                                   orderInfo.OrderSource.Name);

                // 订单支付状态信息
                const string strOrdersPayState = @"
            INSERT INTO OrdersPayState (OrderNO, PayableSuite) 
            VALUES (@NewOrderNO, @OrderSuitePrice)";

                // 礼服信息
                const string strDress = @"
            INSERT INTO Dress_Reventions (OrderNO,     Dress_WhetherGiveUp, Dress_WhetherRevention) 
            VALUES (					  @NewOrderNO, 0,					'否') ";

                // 流程信息及操作日志
                const string strOrderState = @"
            IF NOT EXISTS(SELECT * FROM OrderState WHERE OrderNO = @NewOrderNO AND IsDeleted = 0)
	            INSERT INTO OrderState(OrderNO) VALUES(@NewOrderNO)
            INSERT INTO OrderLogo (OrderNO, DepartmentNO, EmployeeNO, [Create], CreateDate, LogoType, LogoContext) 
            VALUES (@NewOrderNO, @OrderDepartmentNO, @OrderEmployeeNO, @OrderEmployeeNO, GETDATE(), '订单状态变更', '生成新订单')
            INSERT INTO Logo (OrderNO, DepartmentNO, EmployeeNO, [Create], CreateDate, LogoType, LogoContext) 
            VALUES (@NewOrderNO, @OrderDepartmentNO, @OrderEmployeeNO, @OrderEmployeeNO, GETDATE(), '订单状态变更', '生成新订单'),
                   (@NewOrderNO, @OrderDepartmentNO, @OrderEmployeeNO, @OrderEmployeeNO, GETDATE(), '操作日志', '新建订单')";

                // 初始化拍摄信息
                const string strShootInit = @"
            IF @ShootSites <> '外景'
            BEGIN
	            INSERT INTO OrderShoot(OrderNO, ShootType, ShootState, RecordState)
                VALUES (@NewOrderNO, '内景', '初始化', 3)
            END
            IF @ShootSites <> '内景'
            BEGIN
	            INSERT INTO OrderShoot(OrderNO, ShootType, ShootState, RecordState)
                VALUES (@NewOrderNO, '外景', '初始化', 3)
            END";

                // 了解的服务
                StringBuilder sbMoreInfoItem = new StringBuilder();
                if(infoItems != null && infoItems.Count > 0)
                {
                    sbMoreInfoItem.Append(@"
            INSERT INTO OrderMore(OrderNO, ItemID, CreateDate, CreateEmployee)
            VALUES");
                    foreach(MoreInfoItem item in infoItems)
                    {
                        sbMoreInfoItem.Append(string.Format(@"
            (@NewOrderNO, {0}, GETDATE(), @OrderEmployeeNO),", item.ID));
                    }
                    sbMoreInfoItem.Length -= 1;
                }
                if(!string.IsNullOrWhiteSpace(moreInfoOther))
                {
                    sbMoreInfoItem.Append(string.Format(@"
            INSERT INTO OrderMore(OrderNO, ItemID, Other, CreateDate, CreateEmployee)
            VALUES(@NewOrderNO, 1, '{0}', GETDATE(), @OrderEmployeeNO)", moreInfoOther));
                }
                string strKnownService = sbMoreInfoItem.Length > 0 ? sbMoreInfoItem.ToString() : null;

                // 产品信息
                int nCurrOrderIndex = 1;
                List<OrderProduct> lstNew = new List<OrderProduct>();
                foreach(OrderProduct product in products)
                {
                    string strParentIndex = nCurrOrderIndex.ToString("D3");
                    product.ParentProductNO = strParentIndex;
                    product.OrderIndex = nCurrOrderIndex++;
                    lstNew.Add(product);

                    foreach(OrderProduct childProduct in OrderProducts.GetChildProducts(product.ProductNo, boxes, frames))
                    {
                        childProduct.OrderIndex = nCurrOrderIndex++;
                        childProduct.ParentProductNO = strParentIndex;
                        lstNew.Add(childProduct);
                    }
                }
                string strNew = null;
                if(lstNew.Count > 0)
                {
                    StringBuilder sbPre = new StringBuilder(@"
            INSERT INTO PreProducts (OrderNO, OrderIndex, ProductNO, SeparateNO, Fram, Box, Unit, Paper, film, InsidePage, Biao, Ban, Diao, PageQuantity, NegativeQuantity, ProductQuantity, ProductMemory, ProductSellingPrice, ProduceState, [Create], CreateDate, ParentProductNO) 
            VALUES");
                    StringBuilder sbOrder = new StringBuilder(@"
            INSERT INTO OrderProducts (OrderNO, OrderIndex, ProductNO, SeparateNO, Fram, Box, Unit, Paper, film, InsidePage, Biao, Ban, Diao, PageQuantity, NegativeQuantity, ProductQuantity,ProductMemory, ProductSellingPrice, ProduceState, [Create], CreateDate, ParentProductNO, ProductElement) 
            VALUES");
                    foreach(OrderProduct pro in lstNew)
                    {
                        sbPre.Append(string.Format(@"
            (@NewOrderNO, '{0}', '{1}', '001', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {11}, {12}, {13}, '{14}', {15}, '正常', '{16}', GETDATE(),'{17}'),",
                                                   pro.OrderIndex.ToString("D3"), pro.ProductNo, pro.Fram == null ? null : pro.Fram.Value,
                                                   pro.Box == null ? null : pro.Box.Value, pro.Unit, pro.Paper, pro.Film, pro.InsidePage,
                                                   pro.Biao, pro.Ban, pro.Diao, pro.PageQuantity, pro.NegativeQuantity,
                                                   pro.ProductQuantity, pro.ProductMemory, pro.ProductSellingPrice, orderInfo.OrderEmployee.No,
                                                   pro.ParentProductNO));

                        StringBuilder strProductElement = new StringBuilder();
                        if(null != pro.Box)
                        {
                            strProductElement.Append(string.Format(@"√包装({0})", pro.Box.Name));
                        }
                        if(null != pro.Fram)
                        {
                            strProductElement.Append(string.Format(@"√框条({0})", pro.Fram.Name));
                        }
                        sbOrder.Append(string.Format(@"
            (@NewOrderNO, '{0}', '{1}', '001', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {11}, {12}, {13}, '{14}', {15}, '正常', '{16}', GETDATE(),'{17}', '{18}'),",
                                                     pro.OrderIndex.ToString("D3"), pro.ProductNo, pro.Fram == null ? null : pro.Fram.Value,
                                                     pro.Box == null ? null : pro.Box.Value, pro.Unit, pro.Paper, pro.Film, pro.InsidePage,
                                                     pro.Biao, pro.Ban, pro.Diao, pro.PageQuantity, pro.NegativeQuantity,
                                                     pro.ProductQuantity, pro.ProductMemory, pro.ProductSellingPrice, orderInfo.OrderEmployee.No,
                                                     pro.ParentProductNO, strProductElement));
                    }
                    sbPre.Length -= 1;
                    sbOrder.Length -= 1;

                    const string strLog = @"
            INSERT INTO OrderLogo (OrderNO, LogoIndex, Process, DepartmentNO, [Create], CreateDate) 
            VALUES(@NewOrderNO, 1, 'P_05', @OrderDepartmentNO, @OrderEmployeeNO, GETDATE())";
                    strNew = sbPre.Append(sbOrder).Append(strLog).ToString();
                }

                string strSql = string.Format(@"
            BEGIN TRAN TranSaveProducts
            DECLARE @errCount INT = 0
            BEGIN TRY {0}{1}{2}{3}{4}{5}{6}{7}
            END TRY
            BEGIN CATCH
                SET @errCount = @errCount + 1
            END CATCH
            IF(@errCount > 0) BEGIN
	            ROLLBACK TRAN TranSaveProducts

                DECLARE @ErrorMessage NVARCHAR(4000)= ERROR_MESSAGE()
                DECLARE @ErrorState INT = ERROR_STATE()
                RAISERROR (@ErrorMessage, 18, @ErrorState)
            END
            ELSE BEGIN
	            COMMIT TRAN TranSaveProducts
            END", strOrder, strOrderSub, strOrdersPayState, strDress, strOrderState, strShootInit, strKnownService, strNew);
                ExecuteNonQuery(strSql);
                return true;
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(string.Format(@"新建订单遇到问题：{0}{1}", Environment.NewLine, ex.Message));
                return false;
            }
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="orderInfo">订单信息</param>
        /// <param name="products">订单产品</param>
        /// <returns>操作是否成功</returns>
        [WebMethod]
        public bool EditOrder(OrderInfo orderInfo, IEnumerable<OrderProduct> products)
        {
            // 获取下一个订单产品顺序号


            return true;
        }

        /// <summary>
        /// 获取下一个订单产品顺序号
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <returns>下一个订单产品顺序号</returns>
        [WebMethod]
        private int GetNextProductIndex(string orderNo)
        {
            return ExecuteScalar(string.Format(@"
            DECLARE @PreProductsIndex INT, @OrderProductsIndex INT, @CurrentIndex INT
			SELECT @PreProductsIndex = ISNULL(CAST(MAX(OrderIndex) AS INT), 0) FROM PreProducts WHERE OrderNo='{0}'
			SELECT @OrderProductsIndex = ISNULL(CAST(MAX(OrderIndex) AS INT), 0) FROM OrderProducts WHERE OrderNo='{0}'
			IF(@PreProductsIndex > @OrderProductsIndex)
				SET @CurrentIndex = @PreProductsIndex
			ELSE
				SET @CurrentIndex = @OrderProductsIndex
            SELECT @CurrentIndex + 1", orderNo)).SafeDbInt32();
        }
    }
}