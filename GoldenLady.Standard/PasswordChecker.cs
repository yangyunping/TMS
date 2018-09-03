using System.Text.RegularExpressions;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 用户密码规范检测器
    /// </summary>
    public static class PasswordChecker
    {
        /// <summary>
        /// 最小密码长度
        /// </summary>
        private const int MinPasswordLength = 6;
        /// <summary>
        /// 用于验证字符串规范的正则表达式
        /// </summary>
        private const string StandardRegex = @"\d[A-Za-z]|[A-Za-z]\d";

        /// <summary>
        /// 扩展：检测字符串是否为符合要求的密码
        /// </summary>
        /// <param name="pwd">待检测的密码字符串</param>
        /// <returns>是否符合要求</returns>
        public static bool IsValidPassword(this string pwd)
        {
            return (pwd.Length >= MinPasswordLength) && Regex.IsMatch(pwd, StandardRegex);
        }
    }
}