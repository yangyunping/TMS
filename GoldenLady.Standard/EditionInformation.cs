using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 软件版本信息
    /// </summary>
    public sealed class EditionInformation
    {
        /// <summary>
        /// 版本编号
        /// </summary>
        public string EditionNO { get; set; }
        /// <summary>
        /// 版本名称
        /// </summary>
        public string EditionName { get; set; }
        /// <summary>
        /// 客户称谓1
        /// </summary>
        public string CustomerName1 { get; set; }
        /// <summary>
        /// 客户称谓2
        /// </summary>
        public string CustomerName2 { get; set; }
        /// <summary>
        /// 需要记录的日期
        /// </summary>
        public string MemorizeDay { get; set; }

        /// <summary>
        /// 从数据集构造
        /// </summary>
        /// <param name="dr">数据集</param>
        /// <returns>构造的对象</returns>
        public static implicit operator EditionInformation(DataRow dr)
        {
            return null == dr ? new EditionInformation() : new EditionInformation
                                                           {
                                                                   EditionNO = dr["EditionNO"].SafeDbValue<string>(),
                                                                   EditionName = dr["EditionName"].SafeDbValue<string>(),
                                                                   CustomerName1 = dr["CustomerName1"].SafeDbValue<string>(),
                                                                   CustomerName2 = dr["CustomerName2"].SafeDbValue<string>(),
                                                                   MemorizeDay = dr["MemorizeDay"].SafeDbString()
                                                           };
        }
    }
}