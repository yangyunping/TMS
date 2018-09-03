using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace GoldenLadyWS
{
    public class PMSDataAccess
    {
        /// <summary>
        /// 获取后期数据库产品价格
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProducts_Size()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select * from Products_Size ");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.PMS_ConStr, CommandType.Text, sbSql.ToString());
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// 获取产品价格
        /// </summary>
        /// <param name="productNO">后期产品编号</param>
        /// <param name="width">宽</param>
        /// <param name="hight">高</param>
        /// <returns></returns>
        public static DataSet GetProductPrice(string productNO, string width, string hight)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select * from Products_Size where productNO=@productNO and width=@width and hight=@hight ");
            SqlParameter[] param ={
                                      new SqlParameter("@productNO",SqlDbType.VarChar,20),
                                      new SqlParameter("@width",SqlDbType.Float),
                                      new SqlParameter("@hight",SqlDbType.Float)
                                  };
            int i = 0;
            param[i++].Value = productNO;
            param[i++].Value = width;
            param[i++].Value = hight;
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.GMS_ConStr, CommandType.Text, sbSql.ToString(), param);
            if(ds.Tables.Count==0)
            {
                return null;
            }
            return ds;
        }

        public static int InsertProducts_Size(string productNO,string hight,string width,string unit,string area,string costPrice,string salePrice)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("if not exists(select top 1 * from Products_Size where productNO=@productNO and hight=@hight and width=@width ) ");
            sbSql.Append("begin ");
            sbSql.Append("insert into Products_Size (productNO,hight,width,unit,area,cost_price,sale_price) values (@productNO,@hight,@width,@unit,@area,@cost_price,@sale_price) ");
            sbSql.Append("end ");
            sbSql.Append("else ");
            sbSql.Append("begin ");
            sbSql.Append("update Products_Size set unit=@unit,area=@area,cost_price=@cost_price,sale_price=@sale_price where productNO=@productNO and hight=@hight and width=@width ");
            sbSql.Append("end ");

            SqlParameter[] param ={
                                      new SqlParameter("@productNO",SqlDbType.VarChar,20),
                                      new SqlParameter("@hight",SqlDbType.Float),
                                      new SqlParameter("@width",SqlDbType.Float),
                                      new SqlParameter("@unit",SqlDbType.VarChar,20),
                                      new SqlParameter("@area",SqlDbType.Decimal),
                                      new SqlParameter("@cost_price",SqlDbType.Decimal),
                                      new SqlParameter("@sale_price",SqlDbType.Decimal)
                                 };
            int i = 0;
            param[i++].Value = productNO;
            param[i++].Value = hight;
            param[i++].Value = width;
            param[i++].Value = unit;
            param[i++].Value = area;
            param[i++].Value = costPrice;
            param[i++].Value = salePrice;

            return SqlHelper.ExecuteNonQuery(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString(),param);
        }

        #region 前期    计算后期产品价格
        //计算价格
        /// <summary>
        /// 计算后期产品价格
        /// </summary>
        /// <param name="ProductNO">后期产品编号</param>
        /// <param name="Hight">高</param>
        /// <param name="Width">宽</param>
        /// <param name="BackProductTypeNO">后期产品类别编号</param>
        /// <param name="Page">底</param>
        /// <param name="Paper">相纸</param>
        /// <param name="Customer_Confirm1">数码设计(传默认值 System_02_02)</param>
        /// <param name="Box">盒子</param>
        /// <param name="ProductNumber">产品数量</param>
        /// <param name="Biao">裱</param>
        /// <param name="Ban">板</param>
        /// <param name="cbCoating">淋膜</param>
        /// <param name="cbInside">内页</param>
        /// <param name="txtAddPhoto">加选 传默认值 0</param>
        /// <param name="Gold_Paper">传默认值 0</param>
        /// <param name="Fram">框条</param>
        /// <param name="sProductName">后期产品名称(传"")</param>
        /// <returns></returns>
        public static string CountPrice(string ProductNO, string Hight, string Width, string BackProductTypeNO, string Page, string Paper, string Customer_Confirm1, string Box, string ProductNumber, string Biao, string Ban, string cbCoating, string cbInside, string txtAddPhoto, string Gold_Paper, string Fram, string sProductName)
        {
            double XCPrice = 0;
            double SCZXPrice = 0;
            double XKPrice = 0;
            double JYBPrice = 0;
            double Price = 0;
            double PagePrice = 0;
            double TZBPrice = 0;
            DataSet ds = null;
            ds = new DataSet();
            //string[] sSizePrices = sSize.Text.Split('*');
            //ds.ReadXml(Application.StartupPath + @"\Data\ProductsPrice.xml");
            //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices);
            if (BackProductTypeNO == "XC")
            {
                //相册
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XCPrice = XCPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //盒子
                try
                {
                    if (Box.ToString() != "")
                    {
                        ds = GetProductPrice(Box, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XCPrice = XCPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //相纸*张
                try
                {
                    //if (Paper.ToString() != "")
                    //{
                    //    ds = GetProductPrice(Paper, Width, Hight);
                    //    PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    //    if (Customer_Confirm1.ToString() != "")
                    //    {
                    //        ds = GetProductPrice(Customer_Confirm1, Width, Hight);
                    //        PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    //    }
                    //    Price = Price + (PagePrice * double.Parse(Page.ToString()));
                    //    SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                    //}


                    if (Paper.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds = GetProductPrice(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = GetProductPrice(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = GetProductPrice(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                //淋膜
                try
                {
                    if (cbCoating.ToString() != "")
                    {
                        ds = GetProductPrice(cbCoating, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()) * double.Parse(Page.ToString());
                        XCPrice = XCPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()) * double.Parse(Page.ToString());
                    }
                }
                catch
                {
                }
                //内页
                try
                {
                    if (cbInside.ToString() != "")
                    {
                        ds = GetProductPrice(cbInside, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()) * double.Parse(Page.ToString());
                        XCPrice = XCPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()) * double.Parse(Page.ToString());
                    }
                }
                catch
                {
                }
                //加选
                //if (txtAddPhoto.ToString() != "0" && txtAddPhoto.ToString() != "")
                //{
                //    try
                //    {
                //        Price = Price + double.Parse(txtAddPhoto.ToString());
                //        SCZXPrice = SCZXPrice + double.Parse(txtAddPhoto.ToString());
                //    }
                //    catch
                //    {
                //    }
                //}
                //金属纸
                if (Gold_Paper.ToString() != "0" && Gold_Paper.ToString() != "")
                {
                    try
                    {
                        if (cbInside.ToString() != "")
                        {
                            ds = GetProductPrice("System_01_03", Width, Hight);
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            SCZXPrice = SCZXPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                //乘以数量
                //Price = Price * double.Parse(ProductNumber.ToString());
                //SCZXPrice = SCZXPrice * double.Parse(ProductNumber.ToString());
                //XCPrice = XCPrice * double.Parse(ProductNumber.ToString());
            }
            else if (BackProductTypeNO == "XK")
            {
                //相框
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //if (ProductName == "蓝宝石烤漆册皮盒FM" || ProductName == "花漾FM")//note by wujianbo 20130125 帅锅说不要
                        //{
                        //    XCPrice = XKPrice - 5;
                        //    XKPrice = 5;
                        //}
                    }
                }
                catch(Exception ex)
                {
                }
                //框条
                try
                {
                    if (Fram.ToString() != "")
                    {
                        ds = GetProductPrice(Fram, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch { }
                //盒子
                try
                {
                    if (Box.ToString() != "")
                    {
                        ds= GetProductPrice(Box, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());

                    }
                }
                catch
                {
                }
                //相纸*张
                try
                {
                    //if (Page.ToString() != "")
                    //{
                    //   ds= GetProductPrice(Paper, Width, Hight);
                    //    PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    //    if (Customer_Confirm1.ToString() != "")
                    //    {
                    //       ds= GetProductPrice(Customer_Confirm1, Width, Hight);
                    //        PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    //    }
                    //    Price = Price + (PagePrice * double.Parse(Page.ToString()));
                    //    SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                    //}


                    if (Paper.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds = GetProductPrice(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = GetProductPrice(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = GetProductPrice(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }

                }
                catch
                {
                }
                //裱
                try
                {
                    if (Biao.ToString() != "")
                    {
                        ds=GetProductPrice(Biao, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //板
                try
                {
                    if (Ban.ToString() != "")
                    {
                        ds = GetProductPrice(Ban, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //加选
                //if (txtAddPhoto.ToString() != "0" && txtAddPhoto.ToString() != "")
                //{
                //    try
                //    {
                //        Price = Price + double.Parse(txtAddPhoto.ToString());
                //        SCZXPrice = SCZXPrice + double.Parse(txtAddPhoto.ToString());
                //    }
                //    catch
                //    {
                //    }
                //}
                //金属纸
                if (Gold_Paper.ToString() != "0" && Gold_Paper.ToString() != "")
                {
                    try
                    {
                        if (cbInside.ToString() != "")
                        {
                            ds = GetProductPrice("System_01_03", Width, Hight);
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            SCZXPrice = SCZXPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
                    }
                    catch
                    {
                    }
                }

                if (ProductNO.ToString() == "085" || Fram.ToString() == "085")
                {
                    JYBPrice = 7;
                }
                Price = Price + JYBPrice;
                //乘以数量
                //Price = Price * double.Parse(ProductNumber.ToString());
                //SCZXPrice = SCZXPrice * double.Parse(ProductNumber.ToString());
                //XKPrice = XKPrice * double.Parse(ProductNumber.ToString());
            }
            else if (BackProductTypeNO == "SJ")
            {
                //水晶
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //盒子
                try
                {
                    if (Box.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Box.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //相纸*张
                try
                {
                    //if (Page.ToString() != "")
                    //{
                    //   ds= GetProductPrice(Paper, Width, Hight);
                    //    PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    //    if (Customer_Confirm1.ToString() != "")
                    //    {
                    //       ds= GetProductPrice(Customer_Confirm1, Width, Hight);
                    //        PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    //    }
                    //    Price = Price + (PagePrice * double.Parse(Page.ToString()));
                    //    SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                    //}

                    if (Paper.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds = GetProductPrice(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = GetProductPrice(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = GetProductPrice(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                //加选
                //if (txtAddPhoto.ToString() != "0" && txtAddPhoto.ToString() != "")
                //{
                //    try
                //    {
                //        Price = Price + double.Parse(txtAddPhoto.ToString());
                //        SCZXPrice = SCZXPrice + double.Parse(txtAddPhoto.ToString());
                //    }
                //    catch
                //    {
                //    }
                //}
                //金属纸
                if (Gold_Paper.ToString() != "0" && Gold_Paper.ToString() != "")
                {
                    try
                    {
                        if (cbInside.ToString() != "")
                        {
                            ds = GetProductPrice("System_01_03", Width, Hight);
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            SCZXPrice = SCZXPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                //乘以数量
                //Price = Price * double.Parse(ProductNumber.ToString());
                //SCZXPrice = SCZXPrice * double.Parse(ProductNumber.ToString());
                //XKPrice = XKPrice * double.Parse(ProductNumber.ToString());
            }
            else if (BackProductTypeNO == "PH")
            {
                //冰雕

                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds =  GetProductPrice(ProductNO.ToString(), Hight, Width);
                        if (ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" || ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" || ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00")
                        {
                            XCPrice = double.Parse(ds.Tables[0].Rows[0]["XCPrice"].ToString());
                            XKPrice = double.Parse(ds.Tables[0].Rows[0]["XKPrice"].ToString());
                            TZBPrice = double.Parse(ds.Tables[0].Rows[0]["TZBPrice"].ToString());
                            Price = XCPrice + XKPrice + TZBPrice;
                        }
                        else
                        {
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
                    }
                }
                catch
                {
                }
                //盒子
                try
                {
                    if (Box.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Box.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //相纸*张
                try
                {
                    if (Page.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds =  GetProductPrice(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds =  GetProductPrice(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds =  GetProductPrice(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                //加选
                //if (txtAddPhoto.ToString() != "0" && txtAddPhoto.ToString() != "")
                //{
                //    try
                //    {
                //        Price = Price + double.Parse(txtAddPhoto.ToString());
                //        SCZXPrice = SCZXPrice + double.Parse(txtAddPhoto.ToString());
                //    }
                //    catch
                //    {
                //    }
                //}
                //金属纸
                if (Gold_Paper.ToString() != "0" && Gold_Paper.ToString() != "")
                {
                    try
                    {
                        if (cbInside.ToString() != "")
                        {
                            ds =GetProductPrice("System_01_03", Hight, Width);
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            SCZXPrice = SCZXPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                //乘以数量
                //Price = Price * double.Parse(ProductNumber.ToString());
            }
            else if (BackProductTypeNO == "BD")
            {
                //冰雕

                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //盒子
                try
                {
                    if (Box.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Box.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //相纸*张
                try
                {
                    if (Page.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds = GetProductPrice(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = GetProductPrice(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = GetProductPrice(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                //加选
                //if (txtAddPhoto.ToString() != "0" && txtAddPhoto.ToString() != "")
                //{
                //    try
                //    {
                //        Price = Price + double.Parse(txtAddPhoto.ToString());
                //        SCZXPrice = SCZXPrice + double.Parse(txtAddPhoto.ToString());
                //    }
                //    catch
                //    {
                //    }
                //}
                //金属纸
                if (Gold_Paper.ToString() != "0" && Gold_Paper.ToString() != "")
                {
                    try
                    {
                        if (cbInside.ToString() != "")
                        {
                            ds = GetProductPrice("System_01_03", Width, Hight);
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            SCZXPrice = SCZXPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                //乘以数量
                //Price = Price * double.Parse(ProductNumber.ToString());
            }
            else if (BackProductTypeNO == "KL" || BackProductTypeNO == "TZB" || BackProductTypeNO == "KM")
            //卡米拉
            {
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //盒子
                try
                {
                    if (Box.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Box.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //相纸*张
                try
                {
                    if (Page.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds = GetProductPrice(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = GetProductPrice(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = GetProductPrice(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                //加选
                //if (txtAddPhoto.ToString() != "0" && txtAddPhoto.ToString() != "")
                //{
                //    try
                //    {
                //        Price = Price + double.Parse(txtAddPhoto.ToString());
                //        SCZXPrice = SCZXPrice + double.Parse(txtAddPhoto.ToString());
                //    }
                //    catch
                //    {
                //    }
                //}
                //乘以数量
                //Price = Price * double.Parse(ProductNumber.ToString());
                //SCZXPrice = SCZXPrice * double.Parse(ProductNumber.ToString());
                //XKPrice = XKPrice * double.Parse(ProductNumber.ToString());
            }
            else if (BackProductTypeNO == "CX")
            {
                //水晶彩像
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //if (comboBox2.Text == "总店" || comboBox2.Text == "沙坪坝金夫人" || comboBox2.Text == "公主馆" || comboBox2.Text == "名流印象馆" || comboBox2.Text == "总店-丽江")//note by wujianbo 20130125 帅锅说也不要
                //{
                //    JYBPrice = 3;
                //}
                //else
                //{
                //    JYBPrice = 0;
                //}
                //乘以数量
                Price = (Price + JYBPrice);// *double.Parse(ProductNumber.ToString());
                //XKPrice = XKPrice * double.Parse(ProductNumber.ToString());
                //JYBPrice = JYBPrice * double.Parse(ProductNumber.ToString());
            }
            else if (BackProductTypeNO == "JF")
            {   //精放

                //产品
                //try
                //{
                //    if (ProductNO.ToString() != "")
                //    {
                //        ds = GetProductPrice(ProductNO, Width, Hight);
                //        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                //    }
                //}
                //catch
                //{
                //}
                //相纸*张
                try
                {
                    if (Page.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds = GetProductPrice(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = GetProductPrice(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = GetProductPrice(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                //加选
                //if (txtAddPhoto.ToString() != "0" && txtAddPhoto.ToString() != "")
                //{
                //    try
                //    {
                //        Price = Price + double.Parse(txtAddPhoto.ToString());
                //        SCZXPrice = SCZXPrice + double.Parse(txtAddPhoto.ToString());
                //    }
                //    catch
                //    {
                //    }
                //}
                //金属纸
                if (Gold_Paper.ToString() != "0" && Gold_Paper.ToString() != "")
                {
                    try
                    {
                        if (cbInside.ToString() != "")
                        {
                            ds = GetProductPrice("System_01_03", Width, Hight);
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            SCZXPrice = SCZXPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                //乘以数量
                Price = Price * double.Parse(ProductNumber.ToString());
                SCZXPrice = SCZXPrice * double.Parse(ProductNumber.ToString());
            }
            else if (BackProductTypeNO == "HB")
            {
                //海报
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //相纸*张
                //try
                //{
                    //if (sProductName.ToString().Contains("台历"))
                //    { }
                //    else
                //    {
                //        if (Page.ToString() != "")
                //        {
                //            if (Paper.ToString() == "System_01_03")
                //            {
                //                ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Paper.ToString(), Hight, Width));
                //                PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                //                if (Customer_Confirm1.ToString() != "")
                //                {
                //                    ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Customer_Confirm1.ToString(), Hight, Width));
                //                    PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                //                }
                //                Price = Price + (PagePrice * double.Parse(Page.ToString()));
                //                SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                //            }
                //            else
                //            {

                //                ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Paper.ToString(), "0", "0"));
                //                PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                //                PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                //                if (cbDesign.SelectedValue.ToString() != "")
                //                {
                //                    ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(cbDesign.SelectedValue.ToString(), Hight, Width));
                //                    PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                //                }
                //                Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                //                SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                //            }
                //        }
                //    }
                //}
                //catch
                //{
                //}
                //加选
                //if (txtAddPhoto.ToString() != "0" && txtAddPhoto.ToString() != "")
                //{
                //    try
                //    {
                //        Price = Price + double.Parse(txtAddPhoto.ToString());
                //    }
                //    catch
                //    {
                //    }
                //}
                //乘以数量
                //Price = Price;// * double.Parse(ProductNumber.ToString());
                //JYBPrice = Price * double.Parse(ProductNumber.ToString());
                JYBPrice = Price;
            }
            else if (BackProductTypeNO == "YX")
            {
                //影像

                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        JYBPrice = Price;
                    }
                }
                catch
                {
                }
            }
            else if (BackProductTypeNO == "QT")
            {
                //其它
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //相纸*张
                try
                {
                    if (sProductName.ToString().Contains("台历") || sProductName.ToString().Contains("名片"))
                    { }
                    else
                    {
                        if (Page.ToString() != "")
                        {
                            if (Paper.ToString() == "System_01_03")
                            {
                                ds = GetProductPrice(Paper.ToString(), Hight, Width);
                                PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                                if (Customer_Confirm1.ToString() != "")
                                {
                                    ds = GetProductPrice(Customer_Confirm1.ToString(), Hight, Width);
                                    PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                                }
                                Price = Price + (PagePrice * double.Parse(Page.ToString()));
                                SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                            }
                            else
                            {

                                ds = GetProductPrice(Paper.ToString(), "0", "0");
                                PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                                PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                                Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                                SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                            }
                        }
                    }
                }
                catch
                {
                }
                //数量
                Price = Price * double.Parse(ProductNumber.ToString());
                SCZXPrice = Price;
                if (ProductNO == "看版册")
                {
                    Price = Price + 5;
                    SCZXPrice = SCZXPrice + 5;
                }
                ds.Dispose();
            }
            else if (BackProductTypeNO == "JZ")
            {
                //金钻
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = GetProductPrice(ProductNO, Width, Hight);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //盒子
                try
                {
                    if (Box.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Box.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //相纸*张
                try
                {
                    if (Page.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds = GetProductPrice(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = GetProductPrice(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = GetProductPrice(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                //加选
                //if (txtAddPhoto.ToString() != "0" && txtAddPhoto.ToString() != "")
                //{
                //    try
                //    {
                //        Price = Price + double.Parse(txtAddPhoto.ToString());
                //        SCZXPrice = SCZXPrice + double.Parse(txtAddPhoto.ToString());
                //    }
                //    catch
                //    {
                //    }
                //}
                //金属纸
                if (Gold_Paper.ToString() != "0" && Gold_Paper.ToString() != "")
                {
                    try
                    {
                        if (cbInside.ToString() != "")
                        {
                            ds = GetProductPrice("System_01_03", Width, Hight);
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            SCZXPrice = SCZXPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                //乘以数量
                //Price = Price * double.Parse(ProductNumber.ToString());
                //SCZXPrice = SCZXPrice * double.Parse(ProductNumber.ToString());
                //XKPrice = XKPrice * double.Parse(ProductNumber.ToString());
            }
            string NewPrice = Convert.ToString(Price);
            return NewPrice;

        }
        #endregion

        #region 尺寸判断
        public static string JudgeSize_2(string productType, string productSizeA, string productSizeB, string productName, string path)
        {

            string mesg = "";
            string[] noList = null; ;
            if (productType == "CX" || productType == "YX" || productName.Contains("FM") || productName.Contains("台历") || productName.Contains("名片"))
            { return ""; }

            string[] sStandard = new string[] { productSizeA, productSizeB };
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            //Thread1 = new Thread(new ThreadStart(delegate() { getImageInfo(dgvOrderProduct.Rows[i].Cells["Path"].Value.ToString(), sStandard[0], sStandard[1]); }));
            //Thread1.Start();
            if (productType == "XC")
            {
                //getImageInfo(dgvOrderProduct.Rows[i].Cells["Path"].Value.ToString(), (Convert.ToDouble(sStandard[1]) * 2).ToString(), sStandard[0]);
                //实例化一个XML文件
                XmlDocument doc = new XmlDocument();
                //判断TextBox路径是否为空 如果不为空绑定给XML路径 如果为空 从新选择路径

                //将路径放入到Load中
                doc.Load(Application.StartupPath + @"\ProductsXML\ProductSize.xml");
                //判断是否存在内容
                if (doc.DocumentElement != null)
                {
                    //将XML文档放入到Node节点中
                    XmlNode xm = doc.DocumentElement;
                    //获取所有节点数量
                    int j = xm.ChildNodes.Count;
                    //将XML文档 放入到数组中
                    noList = new string[j];
                    int t = 0;
                    foreach (XmlNode xn in xm.ChildNodes)
                    {
                        noList[t] = xn.InnerText;
                        t++;
                    }
                }

                string str = productSizeA + "*" + productSizeB;
                //得到输入的长度
                int txtlength = str.Length;
                string LM = "";
                for (int h = 0; h <= noList.Length; h++)
                {
                    string s = noList[h];

                    string lookup = s.Substring(0, txtlength);

                    if (str == lookup)
                    {
                        LM = s.Substring(txtlength);
                        break;
                    }

                }
                string[] sStandardLM;
                sStandardLM = LM.ToString().Split('*');

                try
                {
                    mesg = getImageInfo(path, sStandardLM[0], sStandardLM[1], "0", productName + productSizeA + "*" + productSizeB);
                }
                catch
                {
                    return "相册无录入尺寸";
                }
            }
            else
            {
                mesg = getImageInfo(path, sStandard[0], sStandard[1], "", productName + (productSizeA + "*" + productSizeB));
            }

            if (mesg != "")
            {
                return mesg;
            }
            else
            {
                return "";
            }
        }

        public static string getImageInfo(string sPathInfo, string sWidth, string sHight, string sType, string sProductName)//获取照片信息
        {
            double bWidth = 0;
            double bHight = 0;
            double bzSize = 0;
            string[] str = new string[3];
            string Path = sPathInfo; ;//@"C:\Users\Administrator\Desktop\新建文件夹";
            //string Path = lbPath1.Text.ToString();



            try
            {
                DirectoryInfo TheFolder = new DirectoryInfo(Path);
                if (TheFolder.GetFiles("*.jpg").Length > 0)
                {
                    foreach (FileInfo NextFile in TheFolder.GetFiles("*.jpg"))
                    {
                        Image _Value = Image.FromFile(NextFile.FullName);
                        //if (_Value.HorizontalResolution != 254)
                        //{
                        //    MessageBox.Show("照片分辨率不是254");
                        //}

                        //if ((_Value.Width - (Convert.ToDouble(sWidth) * Convert.ToDouble(_Value.HorizontalResolution)) > Convert.ToDouble(sWidth) * Convert.ToDouble(_Value.HorizontalResolution) / 50) || (_Value.Width - (Convert.ToDouble(sWidth) * Convert.ToDouble(_Value.HorizontalResolution)) < -Convert.ToDouble(sWidth) * Convert.ToDouble(_Value.HorizontalResolution) / 50) || (_Value.Height - (Convert.ToDouble(sHight) * Convert.ToDouble(_Value.HorizontalResolution)) > Convert.ToDouble(sHight) * Convert.ToDouble(_Value.HorizontalResolution) / 50) || (_Value.Height - (Convert.ToDouble(sHight) * Convert.ToDouble(_Value.HorizontalResolution)) < -Convert.ToDouble(sHight) * Convert.ToDouble(_Value.HorizontalResolution) / 50))
                        //{
                        //    MessageBox.Show("照片尺寸有误");
                        //}
                        if (sType != "0")
                        {
                            if (_Value.Width >= _Value.Height)
                            {
                                if (_Value.Width > Convert.ToDouble(sWidth) * Convert.ToDouble(_Value.HorizontalResolution) * 1.0007 || _Value.Width < Convert.ToDouble(sWidth) * Convert.ToDouble(_Value.HorizontalResolution) * 0.9993 || _Value.Height > Convert.ToDouble(sHight) * Convert.ToDouble(_Value.HorizontalResolution) * 1.0007 || _Value.Height < Convert.ToDouble(sHight) * Convert.ToDouble(_Value.HorizontalResolution) * 0.9993)
                                {
                                    return "" + sProductName + "照片尺寸有误";
                                }
                            }
                            else if (_Value.Width <= _Value.Height)
                            {
                                if (_Value.Height > Convert.ToDouble(sWidth) * Convert.ToDouble(_Value.HorizontalResolution) * 1.0007 || _Value.Height < Convert.ToDouble(sWidth) * Convert.ToDouble(_Value.HorizontalResolution) * 0.9993 || _Value.Width > Convert.ToDouble(sHight) * Convert.ToDouble(_Value.HorizontalResolution) * 1.0007 || _Value.Width < Convert.ToDouble(sHight) * Convert.ToDouble(_Value.HorizontalResolution) * 0.9993)
                                {
                                    return "" + sProductName + "照片尺寸有误";
                                }
                            }
                        }
                        else
                        {
                            if (_Value.Width >= _Value.Height)
                            {
                                if (_Value.Width / _Value.HorizontalResolution * 254 > Convert.ToDouble(sWidth) * 100 * 1.0007 || _Value.Width / _Value.HorizontalResolution * 254 < Convert.ToDouble(sWidth) * 100 * 0.9993 || _Value.Height / _Value.HorizontalResolution * 254 > Convert.ToDouble(sHight) * 100 * 1.0007 || _Value.Height / _Value.HorizontalResolution * 254 < Convert.ToDouble(sHight) * 100 * 0.9993)
                                {
                                    return "" + sProductName + "照片尺寸有误";
                                }
                            }
                            else if (_Value.Width <= _Value.Height)
                            {
                                if (_Value.Height / _Value.HorizontalResolution * 254 > Convert.ToDouble(sWidth) * 100 * 1.0007 || _Value.Height / _Value.HorizontalResolution * 254 < Convert.ToDouble(sWidth) * 100 * 0.9993 || _Value.Width / _Value.HorizontalResolution * 254 > Convert.ToDouble(sHight) * 100 * 1.0007 || _Value.Width / _Value.HorizontalResolution * 254 < Convert.ToDouble(sHight) * 100 * 0.9993)
                                {
                                    return "" + sProductName + "照片尺寸有误";
                                }
                            }
                        }
                    }
                }
                else
                {
                    return sProductName + "里没有照片！";
                }
            }
            catch
            {
                return "" + sProductName + "尺寸判断有误！";
            }
            return null;
        }
        #endregion
    }

    public class GMSDataAccess
    {
        object missing = System.Reflection.Missing.Value;

        /// <summary>   
        /// 获取所有产品信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllProducts()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select * from Products where isDelete=0");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString());
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 更新产品库后期成本价格
        /// </summary>
        /// <param name="id"></param>
        /// <param name="costPrice"></param>
        /// <returns></returns>
        public static int UpdateProductsCostPrice(string id, double costPrice)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("update Products set backProductCostPrice=@costPrice where [id]=@id");
            SqlParameter[] param ={
                                      new SqlParameter("@costPrice",SqlDbType.Decimal),
                                      new SqlParameter("@id",SqlDbType.Int)
                                 };
            int i = 0;
            param[i++].Value=costPrice;
            param[i++].Value=id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString(),param);
        }

        /// <summary>
        /// 保存订单成本价格
        /// </summary>
        /// <param name="orderNO"></param>
        /// <param name="costPrice"></param>
        /// <returns></returns>
        public static int SaveOrderCostPrice(string orderNO, double costPrice)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("update Orders set OrderCostPrice=@orderCostPrice where orderNO=@orderNO");
            SqlParameter[] param ={
                                      new SqlParameter("@orderCostPrice",SqlDbType.Decimal),
                                      new SqlParameter("@orderNO",SqlDbType.VarChar,20)
                                 };
            int i = 0;
            param[i++].Value = costPrice;
            param[i++].Value = orderNO;
            return SqlHelper.ExecuteNonQuery(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString(),param);
        }

        /// <summary>
        /// 获取订单成本价格与销售价格
        /// </summary>
        /// <param name="orderNO"></param>
        /// <returns></returns>
        public static DataTable GetOrderCostPercent(string employeeNO,DateTime dateStart,DateTime dateEnd)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select OrderNO,orderEmployeeNO,dbo.Fn_GetEmployeeName(OrderEmployeeNO) as orderEmployeeName,");
            sbSql.Append("case when(cast (orderCostPrice/OrderSuitePrice*100 as numeric(18,0))) is null then 0 else cast (orderCostPrice/OrderSuitePrice*100 as numeric(18,0)) end as costPercent,");
            sbSql.Append("ord.OrderSuitePrice,case when ord.orderCostPrice is null then 0 else ord.orderCostPrice end as orderCostPrice,cst.CustomerName1+' '+cst.CustomerName2 as customerName,st.SuiteName, ");
            sbSql.Append("dbo.fn_getcostpercent(@orderEmployeeNO) as settingCostPercent,ord.OrderDate ");
            sbSql.Append("from Orders ord,Customers cst,Suite st ");
            sbSql.Append("where ord.CustomerNO=cst.CustomerNO and ord.SuiteNO=st.SuiteNO ");
            sbSql.Append("and orderEmployeeNO=@orderEmployeeNO ");
            sbSql.Append("and orderDate between @dateStart and @dateEnd ");
            sbSql.Append("order by ord.OrderDate desc ");
            SqlParameter[] param ={
                                      new SqlParameter("@orderEmployeeNO",SqlDbType.VarChar,20),
                                      new SqlParameter("@dateStart",SqlDbType.DateTime),
                                      new SqlParameter("@dateEnd",SqlDbType.DateTime)
                                 };
            int i = 0;
            param[i++].Value = employeeNO;
            param[i++].Value = dateStart.ToString("yyyy-MM-dd") ;
            param[i++].Value = dateEnd.AddDays(1).ToString("yyyy-MM-dd");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.GMS_ConStr, CommandType.Text, sbSql.ToString(), param);
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="employeeNO">员工编号</param>
        /// <returns></returns>
        public static DataTable GetEmployee(string employeeNO)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select * from Employee where IsDelete=0 ");
            sbSql.Append("and employeeNO=@employeeNO");
            SqlParameter[] param ={
                                      new SqlParameter("@employeeNO",SqlDbType.VarChar,20)
                                 };
            int i = 0;
            param[i++].Value = employeeNO;
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString(),param);
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEmployee()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select * from Employee where IsDelete=0 ");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.GMS_ConStr, CommandType.Text, sbSql.ToString());
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 保存标准产品P数
        /// add by wujianbo 20130204
        /// </summary>
        /// <param name="productTypeNO_PNumber">产品类别编号_P数</param>
        /// <returns></returns>
        public static int SaveProductTypeStandardPNumber(string productTypeNO_PNumber)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("if not exists(select * from SpecialSet where Keywords='产品标准P数设置') ");
            sbSql.Append("begin ");
            sbSql.Append("insert into SpecialSet(Keywords,Value) values ('产品标准P数设置',@productTypeNO_PNumber)" );
            sbSql.Append("end ");
            sbSql.Append("else ");
            sbSql.Append("begin ");
            sbSql.Append("update SpecialSet set Value=@productTypeNO_PNumber where Keywords='产品标准P数设置' ");
            sbSql.Append("end ");
            SqlParameter[] param ={
                                      new SqlParameter("@productTypeNO_PNumber",SqlDbType.VarChar,100)
                                 };
            int i = 0;
            param[i++].Value = productTypeNO_PNumber;
            return SqlHelper.ExecuteNonQuery(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString(),param);
        }

        /// <summary>
        /// 根据产品类别编号获取标准P数
        /// </summary>
        /// <param name="productTypeNO">产品类别编号</param>
        /// <returns></returns>
        public static int GetProductTypeStandardPNumber(string productTypeNO)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select * from SpecialSet where Keywords='产品标准P数设置' and [Value] like @productTypeNO+'_%'");
            SqlParameter[] param ={
                                      new SqlParameter("@productTypeNO",SqlDbType.VarChar,20)
                                 };
            int i = 0;
            param[i++].Value = productTypeNO;

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString(),param);
            if (ds.Tables == null)
            {
                return 1;
            }
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                return 1;
            }
            string[] temp = dt.Rows[0]["Value"].ToString().Split('_');
            return int.Parse(temp[1]);
        }

        #region 客户问题追踪模块
        /// <summary>
        /// add by wujianbo 20130407 添加客户标识颜色
        /// </summary>
        /// <param name="colorName">颜色名称</param>
        /// <param name="description">标识描述</param>
        /// <returns></returns>
        public static int AddCustomerFlagColor(string colorName,string description)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("insert into CustomerFlagColor (ColorName,[Description]) values (@colorName,@description)");
            SqlParameter[] param ={
                                      new SqlParameter("@colorName",SqlDbType.VarChar,50),
                                      new SqlParameter("@description",SqlDbType.VarChar,200)
                                 };
            int i = 0;
            param[i++].Value = colorName;
            param[i++].Value = description;
            return SqlHelper.ExecuteNonQuery(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString(),param);
        }

        /// <summary>
        /// add by wujianbo 20130407 获取所有客户标识信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCustomerFlagColor()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select * from CustomerFlagColor where IsDelete=0");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString());
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            DataTable dt = ds.Tables[0];
            return dt;
        }

        /// <summary>
        /// add by wujianbo 20130407 删除客户标识信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteCustomerFlagColor(string id)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("update CustomerFlagColor set IsDelete=1 where ID=@id");
            SqlParameter[] para ={
                                     new SqlParameter("@id",SqlDbType.Int)
                                };
            int i = 0;
            para[i++].Value = id;
            return SqlHelper.ExecuteNonQuery(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString(),para);
        }

        /// <summary>
        ///add by wujianbo 20130412 根据控类型获取当前要注意的客户列表
        /// </summary>
        /// <param name="flag">
        /// 0-摄控
        /// 1-看控
        /// 2-看版控
        /// 3-取控
        /// </param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DataTable GetControlAttention(int flag,string date)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select c.MobilePhone1+' '+c.MobilePhone2 as '客户电话',c.CustomerName1+' '+c.CustomerName2 as '客户姓名',cit.OrderNO '订单编号',cit.Process '追踪环节',cfc.Description '问题等级',cfc.ColorName,cit.Issue '问题描述',cit.Result '追踪处理',dbo.Fn_GetDepartmentName(o.OrderDepartmentNO) '下单地点',dbo.Fn_GetDepartmentName(o.ClothesAddress) '选衣地点',o.PreClothesDate '预约选衣时间',dbo.Fn_GetDepartmentName(o.DressAddress) '化妆地点',o.PreDressDate '预约化妆时间',dbo.Fn_GetDepartmentName(o.ShootAddressN) '内景地点',o.PreShootDateN '预约内景时间',dbo.Fn_GetDepartmentName(o.ShootAddressW) '外景地点',o.PreShootDateW '预约外景时间',dbo.Fn_GetDepartmentName(o.ChooseAddress) '看样地点',o.PreChooseDate '预约看样时间',dbo.Fn_GetDepartmentName(o.LookAddress) '看板地点',o.PreLookDate '预约看板时间',dbo.Fn_GetDepartmentName(o.GetGoodsAddress) '取件地点',o.PreGetGoodsDate '预约取件时间',dbo.fn_getEmployeeName(cit.CustomerServerNO)+'('+cit.CustomerServerNO+')' as '客服人员',cit.CreateDate '问题创建时间' from CustomerIssueTracking cit join Orders o on cit.OrderNO = o.OrderNO join Customers c on cit.CustomerNO = c.CustomerNO join dbo.FlagCustomer fc on cit.CustomerNO = fc.CustomerNO join dbo.CustomerFlagColor cfc on cfc.ID = fc.FlagID where 1=1");
            switch (flag)
            {
                #region
                //case 0:
                //    sbSql.Append(" and DATEDIFF(Day,o.PreDressDate,@date)=0 or DATEDIFF(Day,o.PreShootDateN,@date)=0 or DATEDIFF(Day,o.PreShootDateW,@date)=0");
                //    break;
                //case 1:
                //    sbSql.Append(" and DATEDIFF(Day,o.PreChooseDate,@date)=0");
                //    break;
                //case 2:
                //    sbSql.Append(" and DATEDIFF(Day,o.PreLookDate,@date)=0");
                //    break;
                //case 3:
                //    sbSql.Append(" and DATEDIFF(Day,o.PreGetGoodsDate,@date)=0");
                //    break;
                #endregion
                case 0:
                    sbSql.Append(" and DATEDIFF(Day,o.PreDressDate,getdate())=0 or DATEDIFF(Day,o.PreShootDateN,getdate())=0 or DATEDIFF(Day,o.PreShootDateW,getdate())=0");
                    break;
                case 1:
                    sbSql.Append(" and DATEDIFF(Day,o.PreChooseDate,getdate())=0");
                    break;
                case 2:
                    sbSql.Append(" and DATEDIFF(Day,o.PreLookDate,getdate())=0");
                    break;
                case 3:
                    sbSql.Append(" and DATEDIFF(Day,o.PreGetGoodsDate,getdate())=0");
                    break;
                default:
                    break;
            }
            SqlParameter[] param ={
                                      new SqlParameter("@date",SqlDbType.DateTime)
                                 };
            int i = 0;
            param[i++].Value = date;
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.GMS_ConStr,CommandType.Text,sbSql.ToString(),param);
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// add by wujianbo 20130421
        /// 判断当前登陆用户是否有客户问题追踪提示的权限
        /// </summary>
        /// <returns></returns>
        public static DataTable GetControlIssueAttentionDuty()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select value from dbo.SpecialSet where Keywords = '客户问题追踪模块权限'");
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.GMS_ConStr, CommandType.Text, sbSql.ToString());
            if (ds.Tables.Count == 0)
            {
                return null;
            }
            return ds.Tables[0];
        }
        #endregion

        /// <summary>
        /// 将DataGridView中的数据导出到Excel中，并加载显示出来(无加载模板)
        /// 只用于一般的导出Excel
        /// </summary>
        /// <param name="caption">要显示的页头</param>
        /// <param name="date">打印日期</param>
        /// <param name="dgv">要进行导出的DataGridView</param>
        public void ExportToExcel(string caption, string orderShop, string date, DataGridView dgv, double[] result, double hjSum, double dxSum, int[] cashfs)
        {
            //DataGridView可见列数
            int visiblecolumncount = 0;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible == true && (dgv.Columns[i] is DataGridViewTextBoxColumn))
                {
                    visiblecolumncount++;
                }
            }

            try
            {
                //当前操作列的索引
                int currentcolumnindex = 1;
                //当前操作行的索引
                Microsoft.Office.Interop.Excel.ApplicationClass Mylxls = new Microsoft.Office.Interop.Excel.ApplicationClass();
                Microsoft.Office.Interop.Excel._Workbook oWB = (Microsoft.Office.Interop.Excel._Workbook)(Mylxls.Workbooks.Add(true));
                Microsoft.Office.Interop.Excel._Worksheet oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;
                //Mylxls.Cells.Font.Size = 10.5;   //设置默认字体大小
                //设置标头
                Mylxls.Caption = caption;
                //显示表头
                oSheet.Cells[1, 1] = caption;
                oSheet.get_Range(oSheet.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Bold = true; //粗体
                oSheet.get_Range(oSheet.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Size = 15; //大
                //显示时间
                oSheet.Cells[2, 9] = date;
                //显示门市
                oSheet.Cells[2, 1] = orderShop;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible == true && (dgv.Columns[i] is DataGridViewTextBoxColumn))   //如果显示
                    {
                        oSheet.Cells[3, currentcolumnindex] = dgv.Columns[i].HeaderText;
                        oSheet.get_Range(oSheet.Cells[3, currentcolumnindex], oSheet.Cells[3, currentcolumnindex]).Cells.Borders.LineStyle = 1; //设置边框
                        oSheet.get_Range(oSheet.Cells[3, currentcolumnindex], oSheet.Cells[3, currentcolumnindex]).ColumnWidth = dgv.Columns[i].Width / 6; //设置列宽 
                        currentcolumnindex++;
                    }
                }
                oSheet.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visiblecolumncount]).MergeCells = true; //合并单元格
                oSheet.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).RowHeight = 30;   //行高
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Name = "黑体";
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Size = 14;   //字体大小
                oSheet.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visiblecolumncount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //居中显示
                oSheet.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[2, 2]).MergeCells = true; //合并
                oSheet.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[2, 2]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; //左边显示
                oSheet.get_Range(Mylxls.Cells[2, 8], Mylxls.Cells[2, 9]).MergeCells = true; //合并
                oSheet.get_Range(Mylxls.Cells[2, 8], Mylxls.Cells[2, 9]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; //左边显示
                //Mylxls.get_Range(Mylxls.Cells[1, 2], Mylxls.Cells[1, 2]).ColumnWidth = 12;  //列宽度

                object[,] dataArray = new object[dgv.Rows.Count, visiblecolumncount];

                //当前操作列的索引
                //int currentcolumnindex = 1;
                //当前操作行的索引
                for (int i = 0; i < dgv.Rows.Count; i++)   //循环填充数据
                {
                    currentcolumnindex = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible == true && (dgv.Columns[j] is DataGridViewTextBoxColumn))
                        {
                            if (dgv[j, i].Value != null)  //如果单元格内容不为空
                            {
                                if (dgv.Columns[j].HeaderText == "金牌号码")
                                {
                                    dataArray[i, currentcolumnindex - 1] = string.Format("'{0:D8}", dgv[j, i].Value);
                                }
                                else
                                {
                                    dataArray[i, currentcolumnindex - 1] = dgv[j, i].Value.ToString(); 
                                }
                            }
                            currentcolumnindex++;
                        }
                    }
                }
                oSheet.get_Range(oSheet.Cells[4, 1], oSheet.Cells[dgv.Rows.Count + 3, visiblecolumncount]).Value2 = dataArray; //设置值
                oSheet.get_Range(oSheet.Cells[4, 1], oSheet.Cells[dgv.Rows.Count + 3, visiblecolumncount]).Cells.Borders.LineStyle = 1; //设置边框


                Mylxls.Visible = false;
                Mylxls.DisplayAlerts = false;
                Mylxls.AlertBeforeOverwriting = false;
                oSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape; //设置为纵向打印
                oSheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;       //设置打印字为A4纸张
                Mylxls.ActiveWorkbook.PrintOut(missing, missing, missing, missing, missing, missing, missing, missing);

                oSheet.Cells.Clear();

                //统计当天收银情况
                int statistics = 5;

                for (int i = statistics; i < statistics + 12; i++)
                {
                    for (int j = 2; j < 10; j++)
                    {
                        if ((i == statistics || i == statistics + 2 || i == statistics + 4) && j == 5)
                        {
                            break;
                        }
                        else if (i == statistics + 1 || i == statistics + 3 || i == statistics + 5)
                        {
                            break;
                        }
                        oSheet.get_Range(oSheet.Cells[i, j], oSheet.Cells[i, j]).Cells.Borders.LineStyle = 1; //设置边框  
                    }
                }

                oSheet.Cells[statistics, 2] = "当日收银合计:";
                oSheet.Cells[statistics, 4] = hjSum + "元";  //当日收银合计
                oSheet.get_Range(oSheet.Cells[statistics, 2], oSheet.Cells[statistics, 3]).MergeCells = true; //合并
                oSheet.get_Range(oSheet.Cells[statistics, 2], oSheet.Cells[statistics, 3]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                statistics += 2;
                oSheet.Cells[statistics, 2] = "当日地税收银合计:";
                oSheet.Cells[statistics, 4] = hjSum + "元";  //当日地税收银合计
                oSheet.get_Range(oSheet.Cells[statistics, 2], oSheet.Cells[statistics, 3]).MergeCells = true; //合并
                oSheet.get_Range(oSheet.Cells[statistics, 2], oSheet.Cells[statistics, 3]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                statistics += 2;
                oSheet.Cells[statistics, 2] = "当月累计收银合计:";
                oSheet.Cells[statistics, 4] = result[10] + "元";  //当月累计收银合计
                oSheet.get_Range(oSheet.Cells[statistics, 2], oSheet.Cells[statistics, 3]).MergeCells = true; //合并
                oSheet.get_Range(oSheet.Cells[statistics, 2], oSheet.Cells[statistics, 3]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                oSheet.Cells[++statistics, 1] = "其中";
                oSheet.get_Range(oSheet.Cells[statistics-2, 1], oSheet.Cells[statistics + 8, 1]).MergeCells = true; //合并
                oSheet.get_Range(oSheet.Cells[statistics - 2, 1], oSheet.Cells[statistics + 8, 1]).ColumnWidth = 13; //设置列宽
                oSheet.get_Range(oSheet.Cells[statistics, 1], oSheet.Cells[statistics, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                oSheet.Cells[++statistics, 2] = "旅游婚纱摄影";
                oSheet.Cells[statistics, 3] = "旅游艺术照";
                oSheet.get_Range(oSheet.Cells[statistics, 4], oSheet.Cells[statistics, 4]).ColumnWidth = 12; //设置列宽
                oSheet.Cells[statistics, 4] = "旅游摄影加选";
                oSheet.get_Range(oSheet.Cells[statistics, 5], oSheet.Cells[statistics, 5]).ColumnWidth = 12; //设置列宽
                oSheet.Cells[statistics, 5] = "旅游摄影升级";
                oSheet.Cells[statistics, 6] = "单拍";
                oSheet.Cells[statistics, 7] = "出租";
                oSheet.Cells[statistics, 8] = "其他";
                oSheet.Cells[statistics, 9] = "小计";
                //oSheet.Cells[statistics, 10] = "当月累计";

                ++statistics;
                for (int i = 2; i < 12; i++)
                {
                    oSheet.get_Range(Mylxls.Cells[statistics, i], Mylxls.Cells[statistics, i]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; //左边显示 
                }
                oSheet.Cells[statistics, 2] = result[0];
                oSheet.Cells[statistics, 3] = result[1];
                oSheet.Cells[statistics, 4] = result[2];
                oSheet.Cells[statistics, 5] = result[3];
                oSheet.Cells[statistics, 6] = result[4];
                oSheet.Cells[statistics, 7] = result[5];
                oSheet.Cells[statistics, 8] = result[6];
                oSheet.Cells[statistics, 9] = result[7] + "元";
                oSheet.get_Range(oSheet.Cells[statistics, 9], oSheet.Cells[statistics, 9]).ColumnWidth = 14; //设置列宽
                oSheet.get_Range(oSheet.Cells[statistics, 10], oSheet.Cells[statistics, 10]).ColumnWidth = 11; //设置列宽
                //oSheet.Cells[statistics, 10] = result[10] + "元";


                oSheet.Cells[++statistics, 2] = "尊荣卡:";
                oSheet.Cells[statistics, 3] = "退款:";
                oSheet.Cells[statistics, 4] = "小计:";

                ++statistics;
                for (int i = 3; i < 5; i++)
                {
                    oSheet.get_Range(Mylxls.Cells[statistics, i], Mylxls.Cells[statistics, i]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; //左边显示 
                }
                oSheet.Cells[statistics, 3] = result[8];
                oSheet.Cells[statistics, 4] = result[9];

                oSheet.Cells[++statistics, 2] = "现金:";
                oSheet.Cells[statistics, 3] = "刷卡:";
                oSheet.Cells[statistics, 4] = "支票:";
                oSheet.Cells[statistics, 5] = "支付宝:";
                oSheet.Cells[statistics, 6] = "汇款:";

                ++statistics;
                for (int i = 2; i < 7; i++)
                {
                    oSheet.get_Range(Mylxls.Cells[statistics, i], Mylxls.Cells[statistics, i]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; //左边显示
                }
                oSheet.Cells[statistics, 2] = cashfs[0];
                oSheet.Cells[statistics, 3] = cashfs[1];
                oSheet.Cells[statistics, 4] = cashfs[2];
                oSheet.Cells[statistics, 5] = cashfs[3];
                oSheet.Cells[statistics, 6] = cashfs[4];


                statistics = statistics + 3;

                oSheet.Cells[statistics, 1] = "收银员签名:";
                oSheet.Cells[statistics, 3] = "日期:";
                oSheet.get_Range(oSheet.Cells[statistics, 4], oSheet.Cells[statistics, 6]).MergeCells = true; //合并
                oSheet.get_Range(oSheet.Cells[statistics, 4], oSheet.Cells[statistics, 6]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                oSheet.Cells[statistics, 7] = "主管确认:";
                oSheet.Cells[statistics, 9] = "日期:";
                oSheet.get_Range(oSheet.Cells[statistics, 10], oSheet.Cells[statistics, 11]).MergeCells = true; //合并
                oSheet.get_Range(oSheet.Cells[statistics, 10], oSheet.Cells[statistics, 11]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                //Mylxls.Workbooks.Close();
                //Mylxls.Workbooks[1].Protect(Type.Missing, true, true);
                //oSheet.Protect(missing, missing, missing, missing, true, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, false); //生成模板
                //oSheet.SaveAs("CorpsMemberInfoTable.xls", missing, missing, missing, missing, missing, missing, missing, missing, missing);
                oSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape; //设置为纵向打印
                oSheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;       //设置打印字为A4纸张


                Mylxls.Visible = false;
                Mylxls.DisplayAlerts = false;
                Mylxls.AlertBeforeOverwriting = false;
                string path = System.Windows.Forms.Application.StartupPath;
                Mylxls.ActiveWorkbook.SaveCopyAs(path + "/" + "日报表.xls");
                Mylxls.ActiveWorkbook.PrintOut(missing, missing, missing, missing, missing, missing, missing, missing);
                
                //Mylxls.Quit();

                //销毁Excel进程
                IntPtr t = new IntPtr(Mylxls.Hwnd);
                int k = 0;
                GoldenLady.Utility.WinAPI.GetWindowThreadProcessId(t, out   k);
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
                p.Kill();

            }
            catch(Exception ex)
            {
                MessageBox.Show("信息导出失败，请确认你的机子上装有Microsoft Office Excel！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }


        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="caption">要显示的页头</param>
        /// <param name="date">打印日期</param>
        /// <param name="dgv">要进行导出的DataGridView</param>
        public void ExportToExcelNullMerge(string caption, string date, DataGridView dgv)
        {
            //DataGridView可见列数
            int visiblecolumncount = 0;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible == true && (dgv.Columns[i] is DataGridViewTextBoxColumn))
                {
                    visiblecolumncount++;
                }
            }

            try
            {
                //当前操作列的索引
                int currentcolumnindex = 1;
                //当前操作行的索引
                int currentrowindex = 4;
                Microsoft.Office.Interop.Excel.ApplicationClass Mylxls = new Microsoft.Office.Interop.Excel.ApplicationClass();
                Mylxls.Application.Workbooks.Add(true);
                //Mylxls.Cells.Font.Size = 10.5;   //设置默认字体大小
                //设置标头
                Mylxls.Caption = caption;
                //显示表头
                Mylxls.Cells[1, 1] = caption;
                //显示时间
                Mylxls.Cells[2, 1] = date;
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible == true && (dgv.Columns[i] is DataGridViewTextBoxColumn))   //如果显示
                    {
                        Mylxls.Cells[3, currentcolumnindex] = dgv.Columns[i].HeaderText;
                        Mylxls.get_Range(Mylxls.Cells[3, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).Cells.Borders.LineStyle = 1; //设置边框
                        //Mylxls.get_Range(Mylxls.Cells[3, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).Font.Bold = true; //粗体
                        Mylxls.get_Range(Mylxls.Cells[3, currentcolumnindex], Mylxls.Cells[3, currentcolumnindex]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //居中显示
                        currentcolumnindex++;
                    }
                }
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visiblecolumncount]).MergeCells = true; //合并单元格

                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).RowHeight = 30;   //行高
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Name = "黑体";
                //Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Size = 14;   //字体大小
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visiblecolumncount]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter; //居中显示
                Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[2, 2]).MergeCells = true; //合并
                Mylxls.get_Range(Mylxls.Cells[2, 1], Mylxls.Cells[2, 2]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; //左边显示
                //Mylxls.get_Range(Mylxls.Cells[1, 2], Mylxls.Cells[1, 2]).ColumnWidth = 12;  //列宽度

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    currentcolumnindex = 1;
                    currentrowindex = 4 + i;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible == true && (dgv.Columns[j] is DataGridViewTextBoxColumn))
                        {
                            if (dgv[j, i].Value != null)  //如果单元格内容不为空
                            {
                                Mylxls.Cells[currentrowindex, currentcolumnindex] = dgv[j, i].Value.ToString();
                            }
                            Mylxls.get_Range(Mylxls.Cells[1, currentcolumnindex], Mylxls.Cells[1, currentcolumnindex]).ColumnWidth = dgv.Columns[j].Width / 8;
                            Mylxls.get_Range(Mylxls.Cells[currentrowindex, currentcolumnindex], Mylxls.Cells[currentrowindex, currentcolumnindex]).Cells.Borders.LineStyle = 1; //设置边框
                            if (dgv.Rows[i].Cells[j].Value.ToString() == "")
                            {
                                //合并
                                //Mylxls.get_Range(Mylxls.Cells[currentrowindex - 1, currentcolumnindex], Mylxls.Cells[currentrowindex, currentcolumnindex]).MergeCells = true;
                                //Mylxls.get_Range(Mylxls.Cells[i - 1, col + 2], Mylxls.Cells[rowIndex, col + 2]).MergeCells = true;
                                //Mylxls.get_Range(Mylxls.Cells[i - 1, col + 3], Mylxls.Cells[rowIndex, col + 3]).MergeCells = true;
                            }
                            currentcolumnindex++;
                        }
                    }
                }
                Mylxls.Visible = true;

            }
            catch
            {
                MessageBox.Show("信息导出失败，请确认你的机子上装有Microsoft Office Excel 2003！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
    }
}
