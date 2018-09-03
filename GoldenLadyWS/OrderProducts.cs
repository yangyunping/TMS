using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using GoldenLady.Extension;
using GoldenLady.Standard;
using GoldenLady.Utility;

namespace GoldenLadyWS
{
    /// <summary>
    /// 用于订单产品管理的数据库操作方法集
    /// </summary>
    public sealed class OrderProducts : ErpService
    {
        private static OrderProducts _theInstance;
        private OrderProducts() { }

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static OrderProducts Instance
        {
            get { return _theInstance ?? (_theInstance = new OrderProducts()); }
        }

        /// <summary>
        /// 将订单产品中的礼服产品状态置为'回收'，在看样前执行此操作
        /// </summary>
        /// <param name="orderNO">订单号</param>
        [WebMethod]
        public void DisableDress(string orderNO)
        {
            string strSql = string.Format(@"DECLARE @orderNO VARCHAR(20) = '{0}'
                                            DECLARE cursorTemp CURSOR FORWARD_ONLY FAST_FORWARD FOR 
                                            SELECT OrderIndex, ProductNO FROM OrderProducts WHERE OrderNO = @orderNO AND ProduceState = '正常'
                                            OPEN cursorTemp
                                            DECLARE @productNO VARCHAR(20)
                                            DECLARE @orderIndex VARCHAR(20)
                                            FETCH NEXT FROM cursorTemp INTO @orderIndex, @productNO
                                            WHILE @@FETCH_STATUS = 0
                                            BEGIN
	                                            UPDATE OrderProducts
	                                            SET ProduceState = '回收' 
	                                            WHERE OrderNO = @orderNO
	                                            AND OrderIndex = @orderIndex
	                                            AND EXISTS
	                                            (
		                                            SELECT 1 FROM Products p LEFT JOIN ProductType pt ON p.ProductTypeNO = pt.ProductTypeNO  WHERE (pt.ProductTypeName = '先生礼服' OR pt.ProductTypeName = '礼服' OR p.ProductName LIKE '%券%') AND p.ProductNO = @productNO 
	                                            )
	                                            FETCH NEXT FROM cursorTemp INTO @orderIndex, @productNO
                                            END
                                            CLOSE cursorTemp
                                            DEALLOCATE cursorTemp", orderNO);
            ExecuteNonQuery(strSql);
        }

        /// <summary>
        /// 获取套系
        /// </summary>
        /// <returns>套系</returns>
        [WebMethod]
        public IEnumerable<Suite> GetSuites(IEnumerable<SuiteType> suiteTypes)
        {
            using(DataSet ds = ExecuteQuery(@"SELECT * FROM Suite"))
            {
                try
                {
                    return from DataRow row in ds.Tables[0].Rows select Suite.FromDataRow(row, suiteTypes);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询套系列表时遇到了问题导致失败！{0}方法名称：'OrderProducts.GetSuites'", Environment.NewLine));
                }
                return new Suite[]{};
            }
        }
        /// <summary>
        /// 查询套系类别
        /// </summary>
        /// <returns>套系类别</returns>
        [WebMethod]
        public IEnumerable<SuiteType> GetSuiteTypes()
        {
            using(DataSet ds = ExecuteQuery(@"SELECT * FROM SuiteType"))
            {
                try
                {
                    return from DataRow row in ds.Tables[0].Rows select SuiteType.FromDataRow(row);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询套系类别列表时遇到了问题导致失败！{0}方法名称：'OrderProducts.GetSuiteTypes'", Environment.NewLine));
                }
                return new SuiteType[]{};
            }
        }
        /// <summary>
        /// 获取套系产品
        /// </summary>
        /// <param name="suiteNo">套系编号</param>
        /// <param name="boxes">包装数据集</param>
        /// <param name="frames">框条数据集</param>
        /// <returns>套系产品</returns>
        public IEnumerable<OrderProduct> GetSuiteProducts(string suiteNo, IEnumerable<Box> boxes, IEnumerable<Frame> frames)
        {
            using(DataSet ds = ExecuteQuery(string.Format(@"SELECT *, Size = ProductSizeA + '*' + ProductSizeB FROM dbo.V_SearchSuiteProduct WHERE SuiteNO='{0}'", suiteNo)))
            {
                try
                {
                    return from DataRow row in ds.Tables[0].Rows select OrderProduct.FromSuiteProduct(row, boxes, frames);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询套系产品列表时遇到了问题导致失败！{0}方法名称：'OrderProducts.GetSuiteProducts'", Environment.NewLine));
                }
                return new OrderProduct[]{};
            }
        }
        /// <summary>
        /// 获取产品
        /// </summary>
        /// <param name="boxes">包装数据集</param>
        /// <param name="frames">框条数据集</param>
        /// <returns>套系产品</returns>
        public IEnumerable<OrderProduct> GetProducts(IEnumerable<Box> boxes, IEnumerable<Frame> frames)
        {
            using(DataSet ds = ExecuteQuery(@"SELECT Products.ProductNo, Products.ProductName, ProductType.ProductTypeName, Size=(Products.ProductSizeA + '*' + Products.ProductSizeB), Fram, Box, Unit, Paper, film, InsidePage, Biao, Ban, Diao 
                                              FROM Products INNER JOIN ProductType ON Products.ProductTypeNO=ProductType.ProductTypeNO 
                                              WHERE IsDelete=0 AND Products.ProductNo NOT LIKE '%_sub%'"))
            {
                try
                {
                    return from DataRow row in ds.Tables[0].Rows select OrderProduct.FromProduct(row, boxes, frames);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询产品列表时遇到了问题导致失败！{0}方法名称：'OrderProducts.GetProducts'", Environment.NewLine));
                }
                return new OrderProduct[] { };
            }
        }
        /// <summary>
        /// 获取产品类型列表
        /// </summary>
        /// <returns>产品类型列表</returns>
        public IEnumerable<string> GetProductTypes()
        {
            using(DataSet ds = ExecuteQuery(@"SELECT ProductTypeName FROM ProductType"))
            {
                try
                {
                    return from DataRow row in ds.Tables[0].Rows select row["ProductTypeName"].SafeDbString();
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询产品类型列表时遇到了问题导致失败！{0}方法名称：'OrderProducts.GetProductTypes'", Environment.NewLine));
                }
                return new string[] { };
            }
        }
        /// <summary>
        /// 获取包装
        /// </summary>
        /// <returns>包装</returns>
        public IEnumerable<Box> GetBoxes()
        {
            using(DataSet ds = ExecuteQuery(@"SELECT * FROM RequireSub WHERE RequireID = 6"))
            {
                try
                {
                   return from DataRow row in ds.Tables[0].Rows select Box.FromDataRow(row);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询包装列表时遇到了问题导致失败！{0}方法名称：'OrderProducts.GetBoxes'", Environment.NewLine));
                }
                return new Box[]{};
            }
        }
        /// <summary>
        /// 获取框条
        /// </summary>
        /// <returns>框条</returns>
        public IEnumerable<Frame> GetFrames()
        {
            using(DataSet ds = ExecuteQuery(@"SELECT * FROM RequireSub WHERE RequireID = 2"))
            {
                try
                {
                    return from DataRow row in ds.Tables[0].Rows select Frame.FromDataRow(row);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询框条列表时遇到了问题导致失败！{0}方法名称：'OrderProducts.GetFrames'", Environment.NewLine));
                }
                return new Frame[]{};
            }
        }

        /// <summary>
        /// 查询子产品
        /// </summary>
        /// <param name="productNo">父产品编号</param>
        /// <param name="parentIndex">父产品顺序号</param>
        /// <param name="boxes">包装列表</param>
        /// <param name="frames">框条列表</param>
        /// <returns>子产品</returns>
        [WebMethod]
        public IEnumerable<OrderProduct> GetChildProducts(string productNo, IEnumerable<Box> boxes, IEnumerable<Frame> frames)
        {
            using(DataSet ds = ExecuteQuery(string.Format(@"SELECT Products.ProductSizeA, Products.ProductSizeB, Products.BackProductCostPrice, ProductType.ProductTypeNO,ProductType.ProductTypeName, BackProductTypeNO, BackProductNO, Products.ProductNO, Products.ProductName, ProductSize=(Products.ProductSizeA + '*' + Products.ProductSizeB), Fram, Box, Unit, Page, Paper, film, InsidePage, Biao, Ban, Diao, ProductCostPrice, Products.ProductSellingPrice, Products.ProductDescribe, Products.IsCountNumber, Products.ProductNumber, Products.NoticeNumber, Products.ProductImage, Products.[Create], Products.CreateDate, Products.IsDelete 
                                            FROM Products INNER JOIN ProductType ON Products.ProductTypeNO = ProductType.ProductTypeNO 
                                            WHERE IsDelete = 0 AND ProductNO LIKE '{0}_sub%'", productNo)))
            {
                try
                {
                    return from DataRow dr in ds.Tables[0].Rows select new OrderProduct
                    {
                        Ban = dr["Ban"].SafeDbString(),
                        Biao = dr["Biao"].SafeDbString(),
                        Box = Box.Parse(dr["Box"].SafeDbString(), boxes),
                        Diao = dr["Diao"].SafeDbString(),
                        Film = dr["Film"].SafeDbString(),
                        Fram = Frame.Parse(dr["Fram"].SafeDbString(), frames),
                        InsidePage = dr["InsidePage"].SafeDbString(),
                        NegativeQuantity = 0,
                        PageQuantity = 0,
                        Paper = dr["Paper"].SafeDbString(),
                        ProduceState = "正常",
                        ProductMemory = string.Empty,
                        ProductNo = dr["ProductNo"].SafeDbString(),
                        ProductQuantity = 1,
                        Unit = dr["Unit"].SafeDbString()
                    };
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询子产品列表时遇到了问题导致失败！{0}方法名称：'OrderProducts.GetGetChildProducts'", Environment.NewLine));
                }
                return new OrderProduct[] {};
            }
        }
    }
}