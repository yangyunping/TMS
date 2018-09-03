using System.Text;

namespace GoldenLady.Utility
{
    /// <summary>
    /// 手机号码字符串显示管理
    /// </summary>
    public class MobileString
    {
        /// <summary>
        /// 将字符串分三份，中间哪份字符替换成*
        /// </summary>
        /// <param name="mobilePhone"></param>
        /// <returns></returns>
        public static string Encrypt(string mobilePhone)
        {
            if(string.IsNullOrEmpty(mobilePhone))
            {
                return string.Empty;
            }
            //余数为1的分给最后一份
            //余数为2的分给倒数第二份
            //以此类推
            int preLength = mobilePhone.Length / 3; //分三份，侮份大小
            //第一份不可能分得余数
            int startIndex = preLength; //要变成*的字符的起始index
            int mod = mobilePhone.Length % 3; //取余数（0，1，2）
            int count = preLength;
            if(mod > 1) //余数大于1
            {
                count += 1; //大于1，三份的中间一份可分得余数
            }
            StringBuilder sb = new StringBuilder(mobilePhone);
            for(int i = startIndex; i < preLength + count; ++i)
            {
                sb[i] = '*';
            }
            return sb.ToString();
        }
    }
}