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
    /// 用于配置管理的数据库操作方法集
    /// </summary>
    public class ConfigManagement : ErpService
    {
        private static ConfigManagement _theInstance;
        private ConfigManagement() {}

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static ConfigManagement Instance
        {
            get { return _theInstance ?? (_theInstance = new ConfigManagement()); }
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>配置信息</returns>
        [WebMethod]
        public DataSet GetConfig(string filter = null)
        {
            return ExecuteQuery(string.Format(@"SELECT ConfigType, ConfigValue, ConfigNO FROM Config {0}", filter));
        }
        /// <summary>
        /// 获取订单来源
        /// </summary>
        /// <returns>订单来源</returns>
        [WebMethod]
        public IEnumerable<OrderSource> GetOrderSources()
        {
            using(DataSet dsOrderSource = GetConfig(@"WHERE ConfigType='订单来源'"))
            {
                try
                {
                    return from DataRow row in dsOrderSource.Tables[0].Rows select OrderSource.FromDataRow(row);
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询订单来源时遇到了问题导致失败！{0}方法名称：'ConfigManagement.GetOrderSources'", Environment.NewLine));
                }
                return new OrderSource[] {};
            }
        }
        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <returns>区域信息</returns>
        [WebMethod]
        public DataSet GetArea()
        {
            return ExecuteQuery(@"SELECT MenuId,MenuParent,MenuName,IsCheked FROM Area");
        }
        /// <summary>
        /// 获取设置信息
        /// </summary>
        /// <returns>设置信息</returns>
        [WebMethod]
        public DataSet GetSettings()
        {
            return ExecuteQuery(@"SELECT * FROM Setting");
        }
        /// <summary>
        /// 获取是否启用了解的服务
        /// </summary>
        /// <returns>是否启用</returns>
        [WebMethod]
        public bool GetKnownServiceEnabled()
        {
            return ExecuteScalar(@"SELECT [Enabled] FROM Setting WHERE Options = 'KnowService'").SafeDbBoolean();
        }
    }
}