using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 用于展示在订单状态窗口的订单信息
    /// </summary>
    public sealed class OrderInfoToShow
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNO
        {
            get;
            set;
        }
        /// <summary>
        /// 客人编号
        /// </summary>
        public string CustomerNO
        {
            get;
            set;
        }
        /// <summary>
        /// 发票号
        /// </summary>
        public string FPH
        {
            get;
            set;
        }
        /// <summary>
        /// 是否线上订单
        /// </summary>
        public bool Online
        {
            get;
            set;
        }
        /// <summary>
        /// 先生姓名
        /// </summary>
        public string CustomerName1
        {
            get;
            set;
        }
        /// <summary>
        /// 小姐姓名
        /// </summary>
        public string CustomerName2
        {
            get;
            set;
        }
        /// <summary>
        /// 套系名称
        /// </summary>
        public string SuiteName
        {
            get;
            set;
        }
        /// <summary>
        /// 套系价格
        /// </summary>
        public decimal SuitePrice
        {
            get;
            set;
        }
        /// <summary>
        /// 内景摄影师
        /// </summary>
        public string ShootEmployeeN
        {
            get;
            set;
        }
        /// <summary>
        /// 外景摄影师
        /// </summary>
        public string ShootEmployeeW
        {
            get;
            set;
        }
        /// <summary>
        /// 内景灯光师
        /// </summary>
        public string LightEmployeeN
        {
            get;
            set;
        }
        /// <summary>
        /// 外景灯光师
        /// </summary>
        public string LightEmployeeW
        {
            get;
            set;
        }
        /// <summary>
        /// 内景化妆师
        /// </summary>
        public string DressEmployeeN
        {
            get;
            set;
        }
        /// <summary>
        /// 外景化妆师
        /// </summary>
        public string DressEmployeeW
        {
            get;
            set;
        }
        /// <summary>
        /// 内景化妆助理
        /// </summary>
        public string DressAssistantEmployeeN
        {
            get;
            set;
        }
        /// <summary>
        /// 外景化妆助理
        /// </summary>
        public string DressAssistantEmployeeW
        {
            get;
            set;
        }
        /// <summary>
        /// 内景摄影地点
        /// </summary>
        public string ShootAddressN
        {
            get;
            set;
        }
        /// <summary>
        /// 外景摄影地点
        /// </summary>
        public string ShootAddressW
        {
            get;
            set;
        }
        /// <summary>
        /// 内景排控时间
        /// </summary>
        public DateTime PreShootDateN
        {
            get;
            set;
        }
        /// <summary>
        /// 外景排控时间
        /// </summary>
        public DateTime PreShootDateW
        {
            get;
            set;
        }
        /// <summary>
        /// 内景拍摄时间
        /// </summary>
        public DateTime ShootDateN
        {
            get;
            set;
        }
        /// <summary>
        /// 外景拍摄时间
        /// </summary>
        public DateTime ShootDateW
        {
            get;
            set;
        }
        /// <summary>
        /// 介绍人类型
        /// </summary>
        public string IntroducerType
        {
            get;
            set;
        }
        /// <summary>
        /// 介绍人编号
        /// </summary>
        public string IntroducerCardNO
        {
            get;
            set;
        }
        /// <summary>
        /// 先生手机号
        /// </summary>
        public string MobilePhone1
        {
            get;
            set;
        }
        /// <summary>
        /// 小姐手机号
        /// </summary>
        public string MobilePhone2
        {
            get;
            set;
        }
        /// <summary>
        /// 先生住址
        /// </summary>
        public string Address1
        {
            get;
            set;
        }
        /// <summary>
        /// 小姐住址
        /// </summary>
        public string Address2
        {
            get;
            set;
        }
        /// <summary>
        /// 先生生日
        /// </summary>
        public string Birthday1
        {
            get;
            set;
        }
        /// <summary>
        /// 小姐生日
        /// </summary>
        public string Birthday2
        {
            get;
            set;
        }
        /// <summary>
        /// 拍摄类型
        /// </summary>
        public string ShootSites
        {
            get;
            set;
        }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime OrderDate
        {
            get;
            set;
        }

        /// <summary>
        /// 从数据行隐式赋值
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>记录</returns>
        public static implicit operator OrderInfoToShow(DataRow dr)
        {
            if(null == dr)
                return null;
            return new OrderInfoToShow
            {
                OrderNO = dr[@"OrderNO"].SafeDbString(),
                CustomerNO = dr[@"CustomerNO"].SafeDbString(),
                FPH = dr[@"FPH"].SafeDbString(),
                Online = dr[@"onLine"].SafeDbBoolean(),
                CustomerName1 = dr[@"CustomerName1"].SafeDbString(),
                CustomerName2 = dr[@"CustomerName2"].SafeDbString(),
                SuiteName = dr[@"SuiteName"].SafeDbString(),
                SuitePrice = dr[@"SuitePrice"].SafeDbDecimal(),
                ShootEmployeeN = dr[@"ShootEmployeeN"].SafeDbString(),
                ShootEmployeeW = dr[@"ShootEmployeeW"].SafeDbString(),
                LightEmployeeN = dr[@"LightEmployeeN"].SafeDbString(),
                LightEmployeeW = dr[@"LightEmployeeW"].SafeDbString(),
                DressEmployeeN = dr[@"DressEmployeeN"].SafeDbString(),
                DressEmployeeW = dr[@"DressEmployeeW"].SafeDbString(),
                DressAssistantEmployeeN = dr[@"DressAssistantEmployeeN"].SafeDbString(),
                DressAssistantEmployeeW = dr[@"DressAssistantEmployeeW"].SafeDbString(),
                ShootAddressN = dr[@"ShootAddressN"].SafeDbString(),
                ShootAddressW = dr[@"ShootAddressW"].SafeDbString(),
                PreShootDateN = dr[@"PreShootDateN"].SafeDbDateTime(),
                PreShootDateW = dr[@"PreShootDateW"].SafeDbDateTime(),
                ShootDateN = dr[@"ShootDateN"].SafeDbDateTime(),
                ShootDateW = dr[@"ShootDateW"].SafeDbDateTime(),
                IntroducerCardNO = dr[@"IntroducerCardNO"].SafeDbString(),
                IntroducerType = dr[@"IntroducerType"].SafeDbString(),
                MobilePhone1 = dr[@"MobilePhone1"].SafeDbString(),
                MobilePhone2 = dr[@"MobilePhone2"].SafeDbString(),
                Address1 = dr[@"Address1"].SafeDbString(),
                Address2 = dr[@"Address2"].SafeDbString(),
                Birthday1 = dr[@"Birthday1"].SafeDbString(),
                Birthday2 = dr[@"Birthday2"].SafeDbString(),
                ShootSites = dr[@"ShootSites"].SafeDbString(),
                OrderDate = dr[@"OrderDate"].SafeDbValue<DateTime>()
            };
        }
    }
}