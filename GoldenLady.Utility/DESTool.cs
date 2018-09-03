using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GoldenLady.Utility
{
    /// <summary>
    /// DES加解密工具
    /// </summary>
    public static class DESTool
    {
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="stringToDecrypt">待解密字符串</param>
        /// <param name="sEncryptionKey">密钥</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            try
            {
                byte[] rgbIV = { 10, 20, 30, 40, 50, 60, 70, 80 };
                byte[] rgbKey = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] buffer = Convert.FromBase64String(stringToDecrypt);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="stringToEncrypt">待加密字符串</param>
        /// <param name="sEncryptionKey">密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string stringToEncrypt, string sEncryptionKey)
        {
            try
            {
                byte[] rgbIV = { 10, 20, 30, 40, 50, 60, 70, 80 };
                byte[] rgbKey = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.FlushFinalBlock();
                return Convert.ToBase64String(stream.ToArray());
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }
    }
}