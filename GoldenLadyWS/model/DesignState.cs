using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GoldenLadyWS.Model
{
    /*0-分件 1-样前设计 2-样前设计完成 3-看样完成 4-样后设计 5-样后设计完成 6-质检完成 7-打包完成*/
    public enum DesignState : byte
    {
        /// <summary>
        /// 分件
        /// </summary>
        [Description(@"分件")]
        Dispatch = 0,
        /// <summary>
        /// 样前设计
        /// </summary>
        [Description(@"样前设计")]
        PreDesign = 1,
        /// <summary>
        /// 样前设计完成
        /// </summary>
        [Description(@"样前设计完成")]
        PreDesignComplete = 2,
        /// <summary>
        /// 看样完成
        /// </summary>
        [Description(@"看样完成")]
        ChooseComplete = 3,
        /// <summary>
        /// 样后设计
        /// </summary>
        [Description(@"样后设计")]
        Design = 4,
        /// <summary>
        /// 样后设计完成
        /// </summary>
        [Description(@"样后设计完成")]
        DesignComplete = 5,
        /// <summary>
        /// 质检完成
        /// </summary>
        [Description(@"质检完成")]
        CheckPass = 6,
        /// <summary>
        /// 打包完成
        /// </summary>
        [Description(@"打包完成")]
        PackageComplete = 7
    }
}
