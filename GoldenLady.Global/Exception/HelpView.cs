using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldenLady.Global.Exception
{
    /// <summary>
    /// 查看帮助异常类型
    /// </summary>
    public enum HelpViewExceptionType : byte
    {
        Normal
    }

    /// <summary>
    /// 查看帮助异常
    /// </summary>
    public sealed class HelpViewException : System.Exception
    {
        /// <summary>
        /// 异常类型
        /// </summary>
        public HelpViewExceptionType ExceptionType
        {
            get;
            private set;
        }
        /// <summary>
        /// 提示消息
        /// </summary>
        public new string Message
        {
            get;
            private set;
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="type">异常类型</param>
        /// <param name="message">提示消息</param>
        public HelpViewException(HelpViewExceptionType type, string message)
        {
            ExceptionType = type;
            Message = message;
        }
    }
}
