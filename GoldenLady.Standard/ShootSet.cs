using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 摄影
    /// </summary>
    public sealed class ShootSet
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 使用字符串赋值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>实例对象</returns>
        public static implicit operator ShootSet(string str)
        {
            ShootSet shoot = new ShootSet();
            int nFlag = str.IndexOf('-');
            shoot.Type = str.Substring(0, nFlag);
            shoot.State = str.Substring(nFlag + 1);
            return shoot;
        }
    }
    /// <summary>
    /// 摄影类型
    /// </summary>
    public static class ShootSetType
    {
        /// <summary>
        /// 内景正常
        /// </summary>
        public static readonly string InsideNormal = @"内";
        /// <summary>
        /// 内景补拍
        /// </summary>
        public static readonly string InsideDelay = @"内(补)";
        /// <summary>
        /// 内景重拍
        /// </summary>
        public static readonly string InsideReShoot = @"内(重)";
        /// <summary>
        /// 外景正常
        /// </summary>
        public static readonly string OutsideNormal = @"外";
        /// <summary>
        /// 外景补拍
        /// </summary>
        public static readonly string OutsideDelay = @"外(补)";
        /// <summary>
        /// 外景重拍
        /// </summary>
        public static readonly string OutsideReShoot = @"外(重)";
    }
    /// <summary>
    /// 摄影状态
    /// </summary>
    public static class ShootSetState
    {
        /// <summary>
        /// 未排摄控
        /// </summary>
        public static readonly string NotSet = @"未排摄控";
        /// <summary>
        /// 已排摄控
        /// </summary>
        public static readonly string Arranged = @"已排摄控";
        /// <summary>
        /// 拍摄完成
        /// </summary>
        public static readonly string Finished = @"拍摄完成";
    }
}
