using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldenLady.AutoUpdate
{
    internal class DataModel
    {
        internal static string XmlFileName = "AutoUpdaterList.xml";
        internal static string TempEnvironmentVariable = "Temp";
    }
    /// <summary>
    /// 升级文件数据
    /// </summary>
    internal class UpdateFileInfo
    {
        /// <summary>
        /// 文件名
        /// </summary>
        internal string FileName { get; set; }
        /// <summary>
        /// 当前版本
        /// </summary>
        internal string CurrentVersion { get; set; }
        /// <summary>
        /// 可以升级的版本
        /// </summary>
        internal string UpdateVersion { get; set; }
    }
}
