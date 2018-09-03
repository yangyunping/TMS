using System;
using System.IO;
using System.Security.Cryptography;

namespace GoldenLady.Utility
{
    /// <summary>
    /// SHA1校验码生成工具
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public static class SHA1Tool
    {
        /// <summary>
        /// 输出指定文件的SHA1校验码
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>文件与SHA1校验码</returns>
        public static string EncryptFile(string filePath)
        {
            using(FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using(SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                {
                    return Convert.ToBase64String(sha1.ComputeHash(fs));
                }
            }
        }
    }

    /// <summary>
    /// 带有SHA1校验码的文件
    /// </summary>
    public sealed class FileSHA1
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// SHA1校验码
        /// </summary>
        public string SHA1 { get; set; }
    }
}