using System.Text;

namespace GoldenLady.Global.Exception
{
    /// <summary>
    /// 账户类异常类型
    /// </summary>
    public enum AccountExeptionType : byte
    {
        /// <summary>
        /// 用户名不存在
        /// </summary>
        UserNameNotExists,
        /// <summary>
        /// 密码与用户名不匹配
        /// </summary>
        PasswordNotMatch,
        /// <summary>
        /// 账户已失效
        /// </summary>
        AccountInvalid,
        /// <summary>
        /// 需要更改初始密码
        /// </summary>
        NeedChangePassword,
        /// <summary>
        /// 用户密码不符合规范
        /// </summary>
        PasswordInvalid,
        /// <summary>
        /// 用户密码两次输入不相符合
        /// </summary>
        PasswordRepeatNotMatch,
        /// <summary>
        /// 修改密码失败
        /// </summary>
        ChangePasswordFailed
    }

    /// <summary>
    /// 账户类异常
    /// </summary>
    public sealed class AccountException : System.Exception
    {
        private static AccountException _userNameNotExists;
        private static AccountException _passwordNotMatch;
        private static AccountException _accountInvalid;
        private static AccountException _needChangePassword;
        private static AccountException _passwordInvalid;
        private static AccountException _passwordRepeatNotMatch;
        private static AccountException _changePasswordFailed;

        /// <summary>
        /// 异常类型
        /// </summary>
        public AccountExeptionType ExeptionType { get; private set; }
        /// <summary>
        /// 提示消息
        /// </summary>
        public new string Message { get; private set; }

        static AccountException()
        {
            _userNameNotExists = null;
            _passwordNotMatch = null;
            _accountInvalid = null;
            _needChangePassword = null;
            _passwordInvalid = null;
            _passwordRepeatNotMatch = null;
            _changePasswordFailed = null;
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="type">异常类型</param>
        /// <param name="message">提示消息</param>
        public AccountException(AccountExeptionType type, string message)
        {
            ExeptionType = type;
            Message = message;
        }

        /// <summary>
        /// 用户名不存在
        /// </summary>
        public static AccountException UserNameNotExists
        {
            get { return _userNameNotExists ?? (_userNameNotExists = new AccountException(AccountExeptionType.UserNameNotExists, @"用户名不存在，请检查是否输入有误！")); }
        }
        /// <summary>
        /// 密码与用户名不匹配
        /// </summary>
        public static AccountException PasswordNotMatch
        {
            get { return _passwordNotMatch ?? (_passwordNotMatch = new AccountException(AccountExeptionType.PasswordNotMatch, @"密码与账户不匹配，请检查是否输入有误！")); }
        }
        /// <summary>
        /// 账户已失效
        /// </summary>
        public static AccountException AccountInvalid
        {
            get
            {
                if(null != _accountInvalid) return _accountInvalid;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"当前账户已失效！");
                sb.AppendLine(HintString.PleaseConnectAdmin);
                _accountInvalid = new AccountException(AccountExeptionType.AccountInvalid, sb.ToString());
                return _accountInvalid;
            }
        }
        /// <summary>
        /// 需要更改初始密码
        /// </summary>
        public static AccountException NeedChangePassword
        {
            get { return _needChangePassword ?? (_needChangePassword = new AccountException(AccountExeptionType.NeedChangePassword, @"初始密码未进行修改，请修改密码后再登录！")); }
        }
        /// <summary>
        /// 用户密码不符合规范
        /// </summary>
        public static AccountException PasswordInvalid
        {
            get
            {
                if(null != _passwordInvalid)
                    return _passwordInvalid;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"用户密码不符合规范，应满足以下条件：");
                sb.AppendLine(@"    1.长度大于等于6位数");
                sb.AppendLine(@"    2.由字母和数字组成");
                _passwordInvalid = new AccountException(AccountExeptionType.PasswordInvalid, sb.ToString());
                return _passwordInvalid;
            }
        }
        /// <summary>
        /// 用户密码两次输入不相符合
        /// </summary>
        public static AccountException PasswordRepeatNotMatch
        {
            get { return _passwordRepeatNotMatch ?? (_passwordRepeatNotMatch = new AccountException(AccountExeptionType.PasswordRepeatNotMatch, @"两次输入的密码不一致，请检查！")); }
        }
        /// <summary>
        /// 修改密码失败
        /// </summary>
        public static AccountException ChangePasswordFailed
        {
            get { return _changePasswordFailed ?? (_changePasswordFailed = new AccountException(AccountExeptionType.ChangePasswordFailed, @"修改密码失败！")); }
        }
    }
}