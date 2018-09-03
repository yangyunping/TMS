/*
 * 直接将产品数据导到后期，提供数据库访问
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GoldenLadyWS
{
    public class BackData
    {
        static double XCPrice = 0;
        static double SCZXPrice = 0;
        static double XKPrice = 0;
        static double JYBPrice = 0;
        static double TZBPrice = 0;
        static double JZPrice = 0;
        static double PHPrice = 0;
        static double YYPrice = 0;

        public static bool AddOrdersInfo_DD(string OrderNO, string CompanyID, string Customer, string FPH, int Files, string Path1, string OrderMemory, DateTime OrderDate, DateTime GetGoodsDate, string TotalCash)
        {
            string strSql = "if not exists (select 1 from Orders where OrderNO='" + OrderNO + "') begin  ";
            strSql += " insert into Orders (OrderNO,CompanyID,Customer,Phone,Email,FPH,Files,Path1,Path2,Path3,SendWay,OrderMemory,OrderDate,OrderEmployeeID,OrderEmployeeName,GetGoodsDate,IsDelete,WorkAddress,TotalCash,Priority,OrderLevel) values ('" + OrderNO + "','" + CompanyID + "','" + Customer + "','','','" + FPH + "'," + Files + ",'" + Path1 + "','','','网络','" + OrderMemory + "','" + OrderDate.ToString() + "','LZ01','','" + GetGoodsDate.ToShortDateString() + "','00','0','" + TotalCash + "','0','')";
            strSql += "  end  else begin ";
            strSql += " update Orders set CompanyID='" + CompanyID + "',Customer='" + Customer + "',FPH='" + FPH + "',Files='" + Files + "',Path1='" + Path1 + "',OrderMemory='" + OrderMemory + "',OrderDate='" + OrderDate.ToString() + "',GetGoodsDate='" + GetGoodsDate.ToShortDateString() + "',TotalCash='" + TotalCash + "' where OrderNO='" + OrderNO + "'";
            strSql += " end ";
            try
            {
                GoldenLadyWS.SqlHelper.ExecuteNonQuery(GoldenLadyWS.SqlHelper.PMS_ConStr_N, CommandType.Text, strSql);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        internal static DataSet GetOrdersInfo_DR(string OrderNO)
        {
            string sSql = "select 1 from Orders where OrderNo='" + OrderNO + "'";
            try
            {
                return GoldenLadyWS.SqlHelper.ExecuteDataset(GoldenLadyWS.SqlHelper.PMS_ConStr_N, CommandType.Text, sSql);
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static void Insert_Products_all(string[] CompanyID, string[] OrderNo, string[] OrderIndex, string[] SeparateOrder, string[] PageQuantity, string[] NegativeQuantity, string[] ProductQuantity, string[] ProduceState, string[] PreGetGoodsDate, string[] GetGoodsAddress, string[] InsidePage, string[] ProductName, string[] ProductSizeA, string[] ProductSizeB, string[] Biao, string[] Ban, string[] ProductCostPrice, string[] Diao, string[] film, string[] Paper, string[] Box, string[] Fram, string[] BackProductTypeNO, string[] BackProductNO, string[] ProductMemory, string rootPath, string[] productFolder)
        {
            string[] sOrderNO = new string[OrderNo.Length];
            string[] sOrderIndex = new string[OrderNo.Length];
            string[] sSeparateOrder = new string[OrderNo.Length];
            string[] sProductNO = new string[OrderNo.Length];
            string[] sBox = new string[OrderNo.Length];
            string[] sHight = new string[OrderNo.Length];
            string[] sWidth = new string[OrderNo.Length];
            string[] sUnit = new string[OrderNo.Length];
            string[] sPage = new string[OrderNo.Length];
            string[] sProductNumber = new string[OrderNo.Length];
            string[] sPaper = new string[OrderNo.Length];
            string[] sAdd_Photo = new string[OrderNo.Length];
            string[] sGold_Paper = new string[OrderNo.Length];
            string[] sCustomer_Confirm1 = new string[OrderNo.Length];
            string[] sCustomer_Confirm2 = new string[OrderNo.Length];
            string[] sfilm = new string[OrderNo.Length];
            string[] sInsidePage = new string[OrderNo.Length];
            string[] sBiao = new string[OrderNo.Length];
            string[] sBan = new string[OrderNo.Length];
            string[] sDiao = new string[OrderNo.Length];
            string[] sPrice1 = new string[OrderNo.Length];
            string[] sPrice2 = new string[OrderNo.Length];
            string[] sSCFS = new string[OrderNo.Length];
            string[] sOrderMemory = new string[OrderNo.Length];
            string[] sWorkMemory = new string[OrderNo.Length];
            string[] sGetGoodsType = new string[OrderNo.Length];
            string[] sGetGoodsDate = new string[OrderNo.Length];
            string[] sProcess = new string[OrderNo.Length];
            string[] sOutput = new string[OrderNo.Length];
            string[] sOrderDate = new string[OrderNo.Length];
            string[] sOutputDate = new string[OrderNo.Length];
            string[] sProductDate = new string[OrderNo.Length];
            string[] sOrderEmployee = new string[OrderNo.Length];
            string[] sDepartment = new string[OrderNo.Length];
            string[] sProductType = new string[OrderNo.Length];
            string[] sEmployeeName = new string[OrderNo.Length];
            string[] sIsDelete = new string[OrderNo.Length];
            string[] sWorkAddress = new string[OrderNo.Length];
            string[] sWorkTime = new string[OrderNo.Length];
            string[] sWorkShopTime = new string[OrderNo.Length];
            string[] sWorkNumber = new string[OrderNo.Length];
            string[] sFram = new string[OrderNo.Length];
            string[] sAddress = new string[OrderNo.Length];
            string[] sGetAddress = new string[OrderNo.Length];
            string[] sPath = new string[OrderNo.Length];


            #region
            for (int i = 0; i < OrderNo.Length; i++)
            {
                if (OrderNo[i] == "" || Paper[i] == "System_01_07" || string.IsNullOrEmpty(BackProductNO[i]) || string.IsNullOrEmpty(BackProductTypeNO[i]))
                {
                    continue;
                }

                if (CompanyID[i] == "LZ")//comboBox2.Text == "总店")
                {
                    if (BackProductTypeNO[i] == "YX" || BackProductTypeNO[i] == "HB")//drs[i]["BackProductTypeNO"].ToString() == "YX" || drs[i]["BackProductTypeNO"].ToString() == "HB")
                    {
                        continue;
                    }
                }
                sOrderNO[i] = OrderNo[i];
                sOrderIndex[i] = OrderIndex[i];//drs[i]["OrderIndex"].ToString();
                sSeparateOrder[i] = "001";
                sProductNO[i] = BackProductNO[i];// drs[i]["BackProductNO"].ToString();
                sFram[i] = Fram[i];// drs[i]["Fram"].ToString();
                sBox[i] = Box[i];// drs[i]["Box"].ToString();

                try
                {

                    if (Convert.ToDouble(ProductSizeA[i]) > Convert.ToDouble(ProductSizeB[i]))
                    {
                        sHight[i] = ProductSizeA[i];
                        sWidth[i] = ProductSizeB[i];
                    }
                    else
                    {
                        sHight[i] = ProductSizeB[i];
                        sWidth[i] = ProductSizeA[i];
                    }
                }
                catch
                {
                    continue;
                }
                sUnit[i] = "Unit_01";
                //加选 照片P
                if (BackProductTypeNO[i] == "XC")
                {
                    sPage[i] = Convert.ToString(Convert.ToInt32(PageQuantity[i]) * 2);
                    sAdd_Photo[i] = Convert.ToString(Convert.ToInt32(NegativeQuantity[i]) - Convert.ToInt32(sPage[i]));
                    if (Convert.ToInt32(sAdd_Photo[i]) < 0)
                    {
                        sAdd_Photo[i] = "0";
                    }

                    //if (ProductName[i].Contains("FD") || ProductName[i].Contains("FM"))
                    if (sPage[i] == "0")
                    {
                        sPage[i] = "1";
                        sAdd_Photo[i] = "0";
                    }
                }
                else if (BackProductTypeNO[i] == "QT" || BackProductTypeNO[i] == "JF")
                {
                    sPage[i] = "1";
                    sAdd_Photo[i] = "0";
                }
                else
                {
                    //if (NegativeQuantity[i] != ProductQuantity[i])
                    //{
                    //    DataSet dsType =  GetPType(BackProductNO[i]); //pc.GetBinaryUserData(Program.GLSWebs.GetPType(drs[i]["BackProductNO"].ToString()));
                    //    if ((string)dsType.Tables[0].Rows[0]["PType"] == "1")
                    //    {
                    //        sPage[i] = NegativeQuantity[i];
                    //        sAdd_Photo[i] = "0";
                    //    }
                    //    else
                    //    {
                    //        if (Convert.ToInt32(NegativeQuantity[i]) > 1)
                    //        {
                    //            sPage[i] = NegativeQuantity[i];
                    //            sAdd_Photo[i] = "0";
                    //        }
                    //        else
                    //        {
                    //            sPage[i] = "1";
                    //            sAdd_Photo[i] = "0";
                    //        }
                    //    }
                    //}
                    //else if (NegativeQuantity[i] == ProductQuantity[i])
                    //{
                    //    sPage[i] = "1";
                    //    sAdd_Photo[i] = "0";
                    //}

                    sPage[i] = "1";
                    sAdd_Photo[i] = "0";
                }
                if (sPage[i]=="0")
                {
                    sPage[i] = "1";
                }
                sProductNumber[i] = ProductQuantity[i];
                sGold_Paper[i] = "0";
                sCustomer_Confirm1[i] = "System_02_01";//"System_02_04";
                if (BackProductTypeNO[i] == "XC")
                {
                   
                    sCustomer_Confirm2[i] = "CF_05";
                }
                else
                {
                    sCustomer_Confirm2[i] = "";
                }
                sfilm[i] = film[i];
                try
                {
                    sInsidePage[i] = InsidePage[i];
                }
                catch
                {
                    sInsidePage[i] = "";
                    //MessageBox.Show("产品信息录入有误，注意相册内页！");
                }
                sPaper[i] = Paper[i];

                if (ProductMemory[i].Contains("世尊白金"))
                {
                    sPaper[i] = "System_01_03";//金属纸
                    sInsidePage[i] = "System_04_05";//PVC
                    sfilm[i] = "System_03_02";//亮膜
                }
                else if (ProductMemory[i].Contains("尤里卡"))
                {
                    sPaper[i] = "System_01_03";//金属纸
                    sInsidePage[i] = "System_04_05";//PVC
                    sfilm[i] = "System_03_06";//水晶亮膜
                }
                else if (ProductMemory[i].Contains("蕾丝内页"))
                {
                    sPaper[i] = "System_01_03";//金属纸
                    sInsidePage[i] = "System_04_06";//蕾丝内页
                    sfilm[i] = "System_03_04";//不过膜
                }
                else if (ProductMemory[i].Contains("水天一线内页"))
                {
                    sPaper[i] = "System_01_08";//光面纸
                    sInsidePage[i] = "System_04_05";//PVC
                    sfilm[i] = "System_03_06";//水晶亮膜
                }

                //根据公司相纸类别选择绒面、光面相纸
                if (Paper[i] == "System_01_02")
                {
                    sPaper[i] = "System_01_09";
                }
                else if (Paper[i] == "System_01_08")
                {
                    sPaper[i] = "System_01_10";
                }
                Paper[i] = sPaper[i];

                sBiao[i] = Biao[i];
                sBan[i] = Ban[i];
                sDiao[i] = Diao[i];
                sPrice1[i] = "";
                if (CompanyID[i] == "LZ" || CompanyID[i] == "BL")
                {
                    sGetGoodsDate[i] = DateTime.Parse(PreGetGoodsDate[i]).AddDays(-5).ToString();
                }
                else
                {
                    sGetGoodsDate[i] = DateTime.Parse(PreGetGoodsDate[i]).AddDays(0).ToString();
                }
                sGetAddress[i] = GetGoodsAddress[i];
                string BackProductNO1 = "";
                BackProductNO1 = GetOrders_ProductsInfo_XX(BackProductNO[i]);
                ProductName[i] = BackProductNO1;
                sOrderMemory[i] = ProductMemory[i];
                if (sGetAddress[i] != "")
                {
                    if (sGetAddress[i].ToString().Contains("送相") || sGetAddress[i].ToString().Contains("沙坪坝门市"))
                    {
                        sWorkMemory[i] = ProductMemory[i] + " " + "送相";
                    }
                    else if (sGetAddress[i].ToString().Contains("取件部(到店取)"))
                    {
                        sWorkMemory[i] = ProductMemory[i] + " " + sGetAddress[i];
                    }
                    else
                    {
                        sWorkMemory[i] = ProductMemory[i] + " " + sGetAddress[i] + "取";
                    }
                }
                else
                {
                    sWorkMemory[i] = ProductMemory[i];
                }

                sSCFS[i] = "[" + BackProductNO1;
                if (Fram[i] != "")
                {
                    string Fram1 = GetOrders_ProductsInfo_XX(Fram[i]);
                    sSCFS[i] += " " + Fram1;
                }
                if (Box[i] != "")
                {
                    string Box1 = GetOrders_ProductsInfo_XX(Box[i]);
                    sSCFS[i] += " " + Box1 + "]";
                }
                else
                {
                    sSCFS[i] += "]";
                }
                if (film[i] != "" && film[i] != "System_03_04")
                {
                    string film1 = GetOrders_ProductsInfo_XX(film[i]);
                    sSCFS[i] += " " + film1;
                }
                if (InsidePage[i] != "" && InsidePage[i] != "System_04_04")
                {
                    string InsidePage1 = GetOrders_ProductsInfo_XX(InsidePage[i]);
                    sSCFS[i] += " " + InsidePage1;
                }
                if (BackProductTypeNO[i] == "XC" && PageQuantity[i] != "0")
                {
                    sSCFS[i] += " " + "有序";
                }
                //if (sCustomer_Confirm2[i].ToString() != "" && BackProductTypeNO[i] != "XC")
                //{
                //    if (sCustomer_Confirm2[i].ToString() == "CF_05")
                //    {
                //        sSCFS[i] += " " + "直接生产";
                //    }
                //    else if (sCustomer_Confirm2[i].ToString() == "CF_08")
                //    {
                //        sSCFS[i] += " " + "有序";
                //    }
                //}
                if (Biao[i] != "" && Biao[i] != "System_05_03")
                {
                    string Biao1 = GetOrders_ProductsInfo_XX(Biao[i]);
                    sSCFS[i] += " " + Biao1;
                }
                if (Ban[i] != "" && Ban[i] != "System_06_03")
                {
                    string Ban1 = GetOrders_ProductsInfo_XX(Ban[i]);
                    sSCFS[i] += " " + Ban1;
                }

                try
                {
                    if (sGetAddress[i] != "")
                    {
                        if (sGetAddress[i].ToString().Contains("送相") || sGetAddress[i].ToString().Contains("沙坪坝门市"))
                        {
                            sSCFS[i] = sSCFS[i] + " 送相";
                        }
                        else if (sGetAddress[i].ToString().Contains("取件部(到店取)"))
                        {
                            sSCFS[i] = sSCFS[i] + " " + sGetAddress[i];
                        }
                        else
                        {
                            sSCFS[i] = sSCFS[i] + " " + sGetAddress[i] + "取";
                        }
                    }
                }
                catch
                {
                    sSCFS[i] = sSCFS[i];
                }
                sSCFS[i] += ProductMemory[i];

                sGetGoodsType[i] = "一般";

                sProcess[i] = "Process_01_03";

                sOutput[i] = "";

                if (sPaper[i] == "金钻相纸" || sPaper[i] == "喷绘" || BackProductTypeNO[i] == "CX" || BackProductTypeNO[i] == "PH" || ProductName[i].Contains("易拉拉") || ProductName[i].Contains("金粉世家"))
                {
                    sOutput[i] = "";
                }
                else
                {
                    sOutput[i] = "ExportM_01";
                }
                sOrderDate[i] = DateTime.Now.ToString();//drs[i]["OrderDate"].Value.ToString();
                sOutputDate[i] = "";
                sProductDate[i] = "";
                sOrderEmployee[i] = "LZ01";
                sDepartment[i] = "DD_01";
                sProductType[i] = "ProType_01";
                sEmployeeName[i] = "前期导入数据";
                sIsDelete[i] = "00";
                sWorkAddress[i] = "0";
                sWorkTime[i] = "";
                sWorkShopTime[i] = "";
                if (BackProductTypeNO[i] == "XK")
                {
                    sWorkNumber[i] = "框";
                }
                else if (BackProductTypeNO[i] == "SJ")
                {
                    sWorkNumber[i] = "晶";
                }
                else if (BackProductTypeNO[i] == "BD")
                {
                    sWorkNumber[i] = "册";
                }
                else if (BackProductTypeNO[i] == "XC")
                {
                    sWorkNumber[i] = "册";
                }
                else if (BackProductTypeNO[i] == "CX")
                {
                    sWorkNumber[i] = "彩";
                }
                else if (BackProductTypeNO[i] == "KL")
                {
                    sWorkNumber[i] = "卡";
                }
                else if (BackProductTypeNO[i] == "JZ")
                {
                    sWorkNumber[i] = "金";
                }
                else if (BackProductTypeNO[i] == "JF")
                {
                    sWorkNumber[i] = "精";
                }
                else if (BackProductTypeNO[i] == "PH")
                {
                    sWorkNumber[i] = "喷";
                }
                else if (BackProductTypeNO[i] == "YX")
                {
                    sWorkNumber[i] = "影";
                }
                else if (BackProductTypeNO[i] == "HB")
                {
                    sWorkNumber[i] = "海";
                }
                else if (BackProductTypeNO[i] == "TZB")
                {
                    sWorkNumber[i] = "拓";
                }
                else
                {
                    sWorkNumber[i] = "";
                }
                string sSczxTime = DateTime.Now.AddDays(1).Date.ToString();

                try
                {
                    /*价格计算*/
                    sPrice2[i] = CountPrice(sProductNO[i], sHight[i], sWidth[i], BackProductTypeNO[i], sPage[i], Paper[i], sCustomer_Confirm1[i], Box[i], sProductNumber[i], Biao[i], sBan[i], sfilm[i], sInsidePage[i], sAdd_Photo[i], sGold_Paper[i], sFram[i], BackProductNO1);
                }
                catch (Exception ex)
                {
                }


                int sPinBan = 0;
                if (Paper[i] == "System_01_02")
                {
                    string sSize = ProductSizeA[i] + "*" + ProductSizeB[i];
                    if (sProductType[i] == "相册")
                    {
                        if (sSize == "12*8" || sSize == "14*14" || sSize == "8*8" || sSize == "15*15" || sSize == "15*12")
                        {
                            sPinBan = 1;
                        }
                    }
                    else
                    {
                        if (double.Parse(ProductSizeA[i]) <= 5 || (sProductType[i] == "精放" && sSize == "7*5") || sSize == "30*24" || sSize == "36*28" || sSize == "40*28" || sSize == "40*30" || sSize == "45*30")
                        {
                            sPinBan = 1;
                        }

                        if ((sProductType[i] == "其它" && sSize == "8*8"))
                        {
                            sPinBan = 1;
                        }
                    }
                }
                


                try
                {
                    string path = rootPath + "\\" + Array.Find(productFolder, p => p.Contains(sOrderIndex[i] + "_"));
                    AddOrders_ProductsInfo_XX(sOrderNO[i], sOrderIndex[i], sProductNO[i], Box[i], sHight[i], sWidth[i], sUnit[i], sPage[i], sProductNumber[i], sPaper[i], sAdd_Photo[i], sGold_Paper[i], sCustomer_Confirm1[i], sCustomer_Confirm2[i], sfilm[i], sInsidePage[i], sBiao[i], sBan[i], sDiao[i], sPrice1[i], sPrice2[i], sSCFS[i], sOrderMemory[i], sWorkMemory[i], sGetGoodsType[i], sGetGoodsDate[i], sProcess[i], sOutput[i], sOrderDate[i], sOrderEmployee[i], sProductType[i], sDepartment[i], sEmployeeName[i], sWorkAddress[i], sWorkNumber[i], BackProductTypeNO[i], SCZXPrice, XCPrice, XKPrice, sFram[i], JYBPrice, TZBPrice, sSczxTime, path, sPinBan,JZPrice,PHPrice,YYPrice);
                }
                catch { }
            }
            #endregion
        }

        //计算后期产品价格
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
        #region 计算价格
        //计算价格
        private static string CountPrice(string ProductNO, string Hight, string Width, string BackProductTypeNO, string Page, string Paper, string Customer_Confirm1, string Box, string ProductNumber, string Biao, string Ban, string cbCoating, string cbInside, string txtAddPhoto, string Gold_Paper, string Fram, string sProductName)
        {
            XCPrice = 0;
            SCZXPrice = 0;
            XKPrice = 0;
            JYBPrice = 0;
            TZBPrice = 0;
            JZPrice = 0;
            PHPrice = 0;
            YYPrice = 0;
            string cbDesign = "System_02_01";
            double Price = 0;
            double PagePrice = 0;
            DataSet ds = null;
            ds = new DataSet();
            if (BackProductTypeNO == "XC")
            {
                //相册
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XCPrice = XCPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
                        {
                            XCPrice = double.Parse(ds.Tables[0].Rows[0]["XCPrice"].ToString());
                            XKPrice = double.Parse(ds.Tables[0].Rows[0]["XKPrice"].ToString());
                            TZBPrice = double.Parse(ds.Tables[0].Rows[0]["TZBPrice"].ToString());
                            Price = XCPrice + XKPrice + TZBPrice;
                        }
                        else
                        {
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            XCPrice = XCPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
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
                        ds = Count_Prices(Box.ToString(), Hight, Width);
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
                    if (Paper.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {
                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
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
                        ds = Count_Prices(cbCoating.ToString(), Hight, Width);
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
                        ds = Count_Prices(cbInside.ToString(), Hight, Width);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()) * double.Parse(Page.ToString());
                        XCPrice = XCPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()) * double.Parse(Page.ToString());
                    }

                }
                catch
                {
                }
                ////加选
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
                            ds = Count_Prices("System_01_03", Hight, Width);
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
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());


                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
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

                        //if (ProductName == "蓝宝石烤漆册皮盒FM" || ProductName == "花漾FM")
                        //{
                        //    XCPrice = XKPrice - 5;
                        //    XKPrice = 5;
                        //}
                    }
                }
                catch
                {
                }
                //框条
                try
                {
                    if (Fram.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Fram.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds = Count_Prices(Fram.ToString(), Hight, Width);
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
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
                catch { }
                //盒子
                try
                {
                    if (Box.ToString() != "")
                    {
                        ds = Count_Prices(Box.ToString(), Hight, Width);
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
                    if (Page.ToString() != "")
                    {
                        if (Paper.ToString() == "System_01_03")
                        {
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
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
                        if (Biao.ToString() == "System_05_04" || Biao.ToString() == "System_05_02")
                        {
                            ds = Count_Prices(Biao.ToString(), "0", "0");

                            Price = Price + Math.Round(double.Parse(Hight) * double.Parse(Width) / 1550 * double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()), 2);

                            XKPrice = XKPrice + Math.Round((double.Parse(Hight)) * double.Parse(Width) / 1550 * double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()), 2);
                        }
                        else
                        {
                            ds = Count_Prices(Biao.ToString(), Hight, Width);

                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }



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

                        if (Ban.ToString() == "System_06_01")
                        {
                            ds = Count_Prices(Ban.ToString(), "0", "0");
                            Price = Price + Math.Round((double.Parse(Hight)) * double.Parse(Width) / 1550 * double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()), 2);

                            XKPrice = XKPrice + Math.Round((double.Parse(Hight)) * double.Parse(Width) / 1550 * double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()), 2);
                        }
                        else
                        {
                            ds = Count_Prices(Ban.ToString(), Hight, Width);
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }

                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(Ban.ToString(), "0", "0"));

                        //Price = Price + Math.Round(double.Parse(Hight) * double.Parse(Width) / 1550 * double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()), 2);

                        //XKPrice = XKPrice + Math.Round((double.Parse(Hight)) * double.Parse(Width) / 1550 * double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString()), 2);
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                ////加选
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
                            ds = Count_Prices("System_01_03", Hight, Width);
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
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
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
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {
                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                ////加选
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
                            ds = Count_Prices("System_01_03", Hight, Width);
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
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
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
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1 != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                ////加选
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
                            ds = Count_Prices("System_01_03", Hight, Width);
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
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
                        {
                            XCPrice = double.Parse(ds.Tables[0].Rows[0]["XCPrice"].ToString());
                            XKPrice = double.Parse(ds.Tables[0].Rows[0]["XKPrice"].ToString());
                            TZBPrice = double.Parse(ds.Tables[0].Rows[0]["TZBPrice"].ToString());
                            Price = XCPrice + XKPrice + TZBPrice;
                        }
                        else
                        {
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            XCPrice = XCPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
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
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1 != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                ////加选
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
                            ds = Count_Prices("System_01_03", Hight, Width);
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
            else if (BackProductTypeNO == "TZB")
            {
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
                        {
                            XCPrice = double.Parse(ds.Tables[0].Rows[0]["XCPrice"].ToString());
                            XKPrice = double.Parse(ds.Tables[0].Rows[0]["XKPrice"].ToString());
                            TZBPrice = double.Parse(ds.Tables[0].Rows[0]["TZBPrice"].ToString());
                            Price = XCPrice + XKPrice + TZBPrice;
                        }
                        else
                        {
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            TZBPrice = TZBPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
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
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                ////加选
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
            }
            else if (BackProductTypeNO == "KL" || BackProductTypeNO == "KM")
            //卡米拉
            {
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
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
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                ////加选
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
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
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
                //if (comboBox2.Text == "总店" || comboBox2.Text == "沙坪坝金夫人" || comboBox2.Text == "公主馆" || comboBox2.Text == "名流印象馆" || comboBox2.Text == "总店-丽江" || comboBox2.Text == "总店-康定" || comboBox2.Text == "总店-三亚")
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
                //        ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
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
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                ////加选
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
                            ds = Count_Prices("System_01_03", Hight, Width);
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
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                    }
                }
                catch
                {
                }
                //相纸*张
                //try
                //{
                //    if (sProductName.ToString().Contains("台历"))
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
                ////加选
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
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        JYBPrice = Price;
                    }
                }
                catch
                {
                }
            }
            else if (BackProductTypeNO == "YY")
            {
                //影印

                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        YYPrice = YYPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
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
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            YYPrice = YYPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            YYPrice = YYPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                //乘以数量
                Price = Price * double.Parse(ProductNumber.ToString());
                YYPrice = YYPrice * double.Parse(ProductNumber.ToString());

            }
            else if (BackProductTypeNO == "QT")
            {
                //其它
                //产品
                try
                {
                    if (ProductNO.ToString() != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds = Count_Prices_New("LZ", ProductNO.ToString(), Hight, Width);
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
                        {
                            XCPrice = double.Parse(ds.Tables[0].Rows[0]["XCPrice"].ToString());
                            XKPrice = double.Parse(ds.Tables[0].Rows[0]["XKPrice"].ToString());
                            TZBPrice = double.Parse(ds.Tables[0].Rows[0]["TZBPrice"].ToString());
                            Price = XCPrice + XKPrice + TZBPrice;
                        }
                        else
                        {
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
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
                                ds = Count_Prices(Paper.ToString(), Hight, Width);
                                PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                                if (Customer_Confirm1.ToString() != "")
                                {
                                    ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                    PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                                }
                                Price = Price + (PagePrice * double.Parse(Page.ToString()));
                                SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                            }
                            else
                            {

                                ds = Count_Prices(Paper.ToString(), "0", "0");
                                PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                                PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                                ds = Count_Prices(cbDesign, Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
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
                    if (ProductNO != "")
                    {
                        //ds = pc.GetBinaryUserData(Program.GLSWebs.Count_Prices(ProductNO.ToString(), Hight, Width));
                        //Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        //XKPrice = XKPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        ds = Count_Prices(ProductNO, Hight, Width);
                        if ((ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XCPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["XKPrice"].ToString() != "0") || (ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0.00" && ds.Tables[0].Rows[0]["TZBPrice"].ToString() != "0"))
                        {
                            XCPrice = double.Parse(ds.Tables[0].Rows[0]["XCPrice"].ToString());
                            XKPrice = double.Parse(ds.Tables[0].Rows[0]["XKPrice"].ToString());
                            TZBPrice = double.Parse(ds.Tables[0].Rows[0]["TZBPrice"].ToString());
                            Price = XCPrice + XKPrice + TZBPrice;
                        }
                        else
                        {
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            JZPrice = JZPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
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
                            ds = Count_Prices(Paper.ToString(), Hight, Width);
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            if (Customer_Confirm1.ToString() != "")
                            {
                                ds = Count_Prices(Customer_Confirm1.ToString(), Hight, Width);
                                PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            }
                            Price = Price + (PagePrice * double.Parse(Page.ToString()));
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                        else
                        {

                            ds = Count_Prices(Paper.ToString(), "0", "0");
                            PagePrice = double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            PagePrice = Math.Round((double.Parse(Hight) + 0.1181) * double.Parse(Width) / 1550 * PagePrice, 2);
                            ds = Count_Prices(cbDesign, Hight, Width);
                            PagePrice = PagePrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            Price = Math.Round(Price + (PagePrice * double.Parse(Page.ToString())), 2);
                            SCZXPrice = SCZXPrice + (PagePrice * double.Parse(Page.ToString()));
                        }
                    }
                }
                catch
                {
                }
                ////加选
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
                            ds = Count_Prices("System_01_03", Hight, Width);
                            Price = Price + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                            SCZXPrice = SCZXPrice + double.Parse(ds.Tables[0].Rows[0]["Sale_Price"].ToString());
                        }
                    }
                    catch
                    {
                    }
                }

                if (ProductNO.ToString() == "JZ_54")
                {
                    JYBPrice = 7;
                }
                Price = Price + JYBPrice;
                //乘以数量
                //Price = Price * double.Parse(ProductNumber.ToString());
                //SCZXPrice = SCZXPrice * double.Parse(ProductNumber.ToString());
                //XKPrice = XKPrice * double.Parse(ProductNumber.ToString());
            }
            string NewPrice = Convert.ToString(Price);
            return NewPrice;

        }
        #endregion


        //导入后期数据_产品信息
        public static void AddOrders_ProductsInfo_XX(string OrderNO, string OrderIndex, string ProductNO, string Box, string Hight, string Width, string Unit, string Page, string ProductNumber, string Paper, string Add_Photo, string Gold_Paper, string Customer_Confirm1, string Customer_Confirm2, string film, string InsidePage, string Biao, string Ban, string Diao, string Price1, string Price2, string SCFS, string OrderMemory, string WorkMemory, string GetGoodsType, string GetGoodsDate, string Process, string Output, string OrderDate, string OrderEmployee, string ProductType, string Department, string EmployeeName, string WorkAddress, string WorkNumber, string BackProductTypeNO, double SCZXPrice, double XCPrice, double XKPrice, string Fram, double JYBPrice, double TZBPrice, string SczxTime, string Path, int pinBan, double JZPrice, double PHPrice, double YYPrice)
        {
            try
            {
                string sSql = "";
                string NewProductNumber = "1";

                if (Convert.ToInt32(ProductNumber) > 1 && BackProductTypeNO != "XC" && BackProductTypeNO != "JF" && ProductNO != "QT_01_01")
                {
                    for (int i = 0; i < Convert.ToInt32(ProductNumber); i++)
                    {
                        if (OrderNO != "")
                        {
                            Add_Photo = "0";
                            int iCurrentNumber = 0;
                            int NewPage = Int32.Parse(Page);
                            if (Page == "1")
                            {
                                iCurrentNumber = Int32.Parse(Page) / Int32.Parse(NewProductNumber);
                            }
                            else
                            {
                                if (BackProductTypeNO != "XC")
                                {
                                    try
                                    {
                                        NewPage = Int32.Parse(Page) / Int32.Parse(ProductNumber);
                                        iCurrentNumber = Int32.Parse(Page) / Int32.Parse(ProductNumber);
                                        if (NewPage == 0)
                                        {
                                            NewPage = 1;
                                            iCurrentNumber = 1;
                                        }
                                    }
                                    catch
                                    {
                                        NewPage = 1;
                                        iCurrentNumber = NewPage;
                                    }
                                }
                            }
                            sSql = " if not exists (select 1 from Orders_Products where OrderNO='" + OrderNO + "' and OrderIndex='" + OrderIndex + "') begin  ";
                            sSql += "  insert into Orders_Products (OrderNO,OrderIndex,SeparateOrder,ProductID,Box,Hight,Width,Unit,Page,ProductNumber,Paper,Add_Photo,Gold_Paper,Customer_Confirm1,Customer_Confirm2,film,InsidePage,Biao,Ban,Diao,Price1,Price2,SCFS,OrderMemory,WorkMemory,GetGoodsType,GetGoodsDate,Process,[Output],OrderDate,OrderEmployee,ProductType,WorkAddress,WorkNumber,IsDelete,SCZXPrice,XCPrice,XKPrice,Fram,JYBPrice,TZBPrice,SczxTime,Path,pinBan,JZPrice,PHPrice,YYPrice) values ('" + OrderNO + "','" + OrderIndex + "','001','" + ProductNO + "','" + Box + "','" + Hight + "','" + Width + "','" + Unit + "','" + NewPage + "','" + NewProductNumber + "','" + Paper + "','" + Add_Photo + "','" + Gold_Paper + "','" + Customer_Confirm1 + "','" + Customer_Confirm2 + "','" + film + "','" + InsidePage + "','" + Biao + "','" + Ban + "','" + Diao + "','" + Price1 + "','" + Price2 + "','" + SCFS + "','" + OrderMemory + "','" + WorkMemory + "','" + GetGoodsType + "','" + GetGoodsDate + "','" + Process + "','" + Output + "','" + OrderDate + "','" + OrderEmployee + "','" + ProductType + "','" + WorkAddress + "','" + WorkNumber + "','00','" + SCZXPrice + "','" + XCPrice + "','" + XKPrice + "','" + Fram + "','" + JYBPrice + "','" + TZBPrice + "','" + SczxTime + "','" + Path + "',"+pinBan+",'"+JZPrice+"','"+PHPrice+"','"+YYPrice+"') ";
                            sSql += "  end else begin";
                            sSql += " update Orders_Products set  ProductID='" + ProductNO + "',Box='" + Box + "',Hight='" + Hight + "',Width='" + Width + "',Unit='" + Unit + "',Page='" + NewPage + "',ProductNumber='" + NewProductNumber + "',Paper='" + Paper + "',Add_Photo='" + Add_Photo + "',Gold_Paper='" + Gold_Paper + "',Customer_Confirm1='" + Customer_Confirm1 + "',Customer_Confirm2='" + Customer_Confirm2 + "',film='" + film + "',InsidePage='" + InsidePage + "',Biao='" + Biao + "',Ban='" + Ban + "',Diao='" + Diao + "',Price1='" + Price1 + "',Price2='" + Price2 + "',SCFS='" + SCFS + "',OrderMemory='" + OrderMemory + "',WorkMemory='" + WorkMemory + "',GetGoodsType='" + GetGoodsType + "',GetGoodsDate='" + GetGoodsDate + "',Process='" + Process + "',[Output]='" + Output + "',OrderDate='" + OrderDate + "',OrderEmployee='" + OrderEmployee + "',ProductType='" + ProductType + "',WorkAddress='" + WorkAddress + "',WorkNumber='" + WorkNumber + "',SCZXPrice='" + SCZXPrice + "',XCPrice='" + XCPrice + "',XKPrice='" + XKPrice + "',Fram='" + Fram + "',JYBPrice='" + JYBPrice + "',TZBPrice='" + TZBPrice + "',SczxTime='" + SczxTime + "',Path='" + Path + "',pinBan=" + pinBan + " where OrderNO='" + OrderNO + "' and OrderIndex='" + OrderIndex + "'";
                            sSql += " end";

                            sSql += " if not exists (select 1 from OrderLogo where OrderNO='" + OrderNO + "' and OrderIndex='" + OrderIndex + "') begin ";
                            sSql += " insert into OrderLogo ( OrderNO, OrderIndex, SeparateOrder, Process, CurrentNumber, Department1, Employee1, Employee2, Date2, State, OpType) values ('" + OrderNO + "','" + OrderIndex + "','001','" + Process + "','" + iCurrentNumber + "','" + Department + "','" + OrderEmployee + "','" + OrderEmployee + "', getdate(), '1', '新建') ";
                            sSql += "  end";

                            GoldenLadyWS.SqlHelper.ExecuteNonQuery(GoldenLadyWS.SqlHelper.PMS_ConStr_N, CommandType.Text, sSql);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    int iCurrentNumber = 0;
                    iCurrentNumber = Int32.Parse(Page) * Int32.Parse(ProductNumber);
                    sSql = " if not exists (select 1 from Orders_Products where OrderNO='" + OrderNO + "' and OrderIndex='" + OrderIndex + "') begin  ";
                    sSql += " insert into Orders_Products (OrderNO,OrderIndex,SeparateOrder,ProductID,Box,Hight,Width,Unit,Page,ProductNumber,Paper,Add_Photo,Gold_Paper,Customer_Confirm1,Customer_Confirm2,film,InsidePage,Biao,Ban,Diao,Price1,Price2,SCFS,OrderMemory,WorkMemory,GetGoodsType,GetGoodsDate,Process,[Output],OrderDate,OrderEmployee,ProductType,WorkAddress,WorkNumber,IsDelete,SCZXPrice,XCPrice,XKPrice,Fram,JYBPrice,TZBPrice,SczxTime,Path,pinBan,JZPrice,PHPrice,YYPrice) values ('" + OrderNO + "','" + OrderIndex + "','001','" + ProductNO + "','" + Box + "','" + Hight + "','" + Width + "','" + Unit + "','" + Page + "','" + ProductNumber + "','" + Paper + "','" + Add_Photo + "','" + Gold_Paper + "','" + Customer_Confirm1 + "','" + Customer_Confirm2 + "','" + film + "','" + InsidePage + "','" + Biao + "','" + Ban + "','" + Diao + "','" + Price1 + "','" + Price2 + "','" + SCFS + "','" + OrderMemory + "','" + WorkMemory + "','" + GetGoodsType + "','" + GetGoodsDate + "','" + Process + "','" + Output + "','" + OrderDate + "','" + OrderEmployee + "','" + ProductType + "','" + WorkAddress + "','" + WorkNumber + "','00','" + SCZXPrice + "','" + XCPrice + "','" + XKPrice + "','" + Fram + "','" + JYBPrice + "','" + TZBPrice + "','" + SczxTime + "','" + Path + "'," + pinBan + ",'" + JZPrice + "','" + PHPrice + "','" + YYPrice + "') ";
                    sSql += "  end else begin";
                    sSql += " update Orders_Products set  ProductID='" + ProductNO + "',Box='" + Box + "',Hight='" + Hight + "',Width='" + Width + "',Unit='" + Unit + "',Page='" + Page + "',ProductNumber='" + ProductNumber + "',Paper='" + Paper + "',Add_Photo='" + Add_Photo + "',Gold_Paper='" + Gold_Paper + "',Customer_Confirm1='" + Customer_Confirm1 + "',Customer_Confirm2='" + Customer_Confirm2 + "',film='" + film + "',InsidePage='" + InsidePage + "',Biao='" + Biao + "',Ban='" + Ban + "',Diao='" + Diao + "',Price1='" + Price1 + "',Price2='" + Price2 + "',SCFS='" + SCFS + "',OrderMemory='" + OrderMemory + "',WorkMemory='" + WorkMemory + "',GetGoodsType='" + GetGoodsType + "',GetGoodsDate='" + GetGoodsDate + "',Process='" + Process + "',[Output]='" + Output + "',OrderDate='" + OrderDate + "',OrderEmployee='" + OrderEmployee + "',ProductType='" + ProductType + "',WorkAddress='" + WorkAddress + "',WorkNumber='" + WorkNumber + "',SCZXPrice='" + SCZXPrice + "',XCPrice='" + XCPrice + "',XKPrice='" + XKPrice + "',Fram='" + Fram + "',JYBPrice='" + JYBPrice + "',TZBPrice='" + TZBPrice + "',SczxTime='" + SczxTime + "',Path='" + Path + "',pinBan=" + pinBan + " where OrderNO='" + OrderNO + "' and OrderIndex='" + OrderIndex + "'";
                    sSql += " end";

                    sSql += " if not exists (select 1 from OrderLogo where OrderNO='" + OrderNO + "' and OrderIndex='" + OrderIndex + "') begin ";
                    sSql += " insert into OrderLogo ( OrderNO, OrderIndex, SeparateOrder, Process, CurrentNumber, Department1, Employee1, Employee2, Date2, State, OpType) values ('" + OrderNO + "','" + OrderIndex + "','001','" + Process + "','" + iCurrentNumber + "','" + Department + "','" + OrderEmployee + "','" + OrderEmployee + "', getdate(), '1', '新建') ";
                    sSql += "  end";

                    GoldenLadyWS.SqlHelper.ExecuteNonQuery(GoldenLadyWS.SqlHelper.PMS_ConStr_N, CommandType.Text, sSql);
                }
            }
            catch { }
        }

        public static DataSet GetPType(string ProductNo)
        {
            string sSql = "select PType=ISNULL(PType,0) from Products where Productno='" + ProductNo + "'";
            return GoldenLadyWS.SqlHelper.ExecuteDataset(GoldenLadyWS.SqlHelper.PMS_ConStr_N, CommandType.Text, sSql);
        }

        public static string GetOrders_ProductsInfo_XX(string sProductNo)
        {
            string Sql = "select ProductName from Products where ProductNo='" + sProductNo + "'";
            string sReturn = GoldenLadyWS.SqlHelper.ExecuteScalar(GoldenLadyWS.SqlHelper.PMS_ConStr_N, CommandType.Text, Sql).ToString();
            return sReturn;
        }

        public static DataSet Count_Prices(string Products_No, string Hight, string Width)
        {
            string sSql = "select Sale_Price,XCPrice= case when XCPrice is null then '0' else XCPrice end,XKPrice= case when XKPrice is null then '0' else XKPrice end,TZBPrice = case when TZBPrice is null then '0' else TZBPrice end from Products_Size where ProductNO='" + Products_No + "' and hight='" + Hight + "' and width='" + Width + "' ";
            return SqlHelper.ExecuteDataset(SqlHelper.PMS_ConStr_N, CommandType.Text, sSql, null);
        }

        public static DataSet Count_Prices_New(string CompanyNO, string Products_No, string Hight, string Width)
        {
            string sSql = "select top 1 Sale_Price,XCPrice= case when XCPrice is null then '0.00' else XCPrice end,XKPrice= case when XKPrice is null then '0.00' else XKPrice end,TZBPrice= case when TZBPrice is null then '0.00' else TZBPrice end from (select Sale_Price,XCPrice,XKPrice,TZBPrice,1 as Num from dbo.Products_Price_GZ where Hight ='" + Hight + "' and Width='" + Width + "' and ProductNO='" + Products_No + "' and CompanyNo='" + CompanyNO + "' union all select Sale_Price,XCPrice,XKPrice,TZBPrice,2 as Num from dbo.Products_Size where ProductNO='" + Products_No + "' and Hight ='" + Hight + "' and Width='" + Width + "') tmp order by Num";
            return SqlHelper.ExecuteDataset(SqlHelper.PMS_ConStr_N, CommandType.Text, sSql, null);
        }


    }
}
