using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GoldenLadyWS.Model
{
    public enum ReShoot:byte
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal=0,
        /// <summary>
        /// 补拍
        /// </summary>
        [Description("需要补拍")]
        Additional,
        /// <summary>
        /// 重拍
        /// </summary>
        [Description("需要重拍")]
        Repeat
    }
}
