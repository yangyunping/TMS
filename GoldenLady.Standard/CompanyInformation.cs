using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 存放公司信息
    /// </summary>
    public sealed class CompanyInformation
    {
        /// <summary>
        /// 公司编号
        /// </summary>
        public string CompanyBM { get; set; }

        /// <summary>
        /// 公司中文名称
        /// </summary>
        public string CompanyChinese { get; set; }

        /// <summary>
        /// 从数据集构造
        /// </summary>
        /// <param name="dr">数据集</param>
        /// <returns>构造的对象</returns>
        public static implicit operator CompanyInformation(DataRow dr)
        {
            return null == dr ? new CompanyInformation() : new CompanyInformation
                                                           {
                                                                   CompanyBM = dr["CompanyBM"].SafeDbValue<string>(),
                                                                   CompanyChinese = dr["CompanyChinese"].SafeDbValue<string>()
                                                           };
        }
    }
}