using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GoldenLadyWS.Model
{
    /// <summary>
    /// 0-普通 1-快件 2-特快
    /// </summary>
    public enum DesignPriority
    {
        /// <summary>
        /// 普通
        /// </summary>
        [Description("普通")]
        Normal=0,
        /// <summary>
        /// 快件
        /// </summary>
        [Description("快件")]
        Fast,
        /// <summary>
        /// 特快
        /// </summary>
        [Description("特快")]
        Fastest
    }
}
