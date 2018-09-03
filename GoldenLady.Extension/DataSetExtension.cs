using System.Data;

namespace GoldenLady.Extension
{
    /// <summary>
    /// 数据集扩展
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public static class DataSetExtension
    {
        /// <summary>
        /// 判断DataSet是否为空
        /// </summary>
        /// <param name="ds">目标</param>
        /// <returns>为空返回true，否则false</returns>
        public static bool IsEmpty(this DataSet ds) { return (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0); }
    }
}
