using System.Data;
using System.Web.Services;

namespace GoldenLadyWS
{
    /// <summary>
    /// 用于系统要素配置管理的数据库操作方法集
    /// </summary>
    public class ElementManagement : ErpService
    {
        private static ElementManagement _theInstance;
        private ElementManagement() { }

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static ElementManagement Instance
        {
            get { return _theInstance ?? (_theInstance = new ElementManagement()); }
        }

        /// <summary>
        /// 获取系统要素配置信息
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns>系统要素配置信息</returns>
        [WebMethod]
        public DataSet GetElement(string filter = null)
        {
            return ExecuteQuery(string.Format(@"SELECT * FROM Element WHERE 1=1 {0}", filter));
        }

        /// <summary>
        /// 获取外景地点
        /// </summary>
        /// <returns>外景地点信息</returns>
        [WebMethod]
        public DataSet GetOutsideShootAddress()
        {
            return GetElement(@"AND ElementType='外景地点'");
        }

        /// <summary>
        /// 获取内景地点
        /// </summary>
        /// <returns>内景地点信息</returns>
        [WebMethod]
        public DataSet GetInsideShootAddress()
        {
            return GetElement(@"AND ElementType='内景地点'");
        }
    }
}