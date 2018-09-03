using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using GoldenLady.Global.Exception;

namespace GoldenLady.Utility
{
    /// <summary>
    /// 查看帮助的类型
    /// Design By: LiuHaiyang
    /// Date: 2017.1.4
    /// LastUpdate By: LiuHaiyang
    /// LastUpdateDate: 2017.1.14
    /// </summary>
    public enum HelpViewType
    {
        ShootControl,
        ChooseControl,
        GetGoodsControl
    }

    /// <summary>
    /// 帮助查看器
    /// </summary>
    public static class HelpViewer
    {
        private const string Directory = "help";
        private static readonly Dictionary<HelpViewType, string> _dicHelp;
        static HelpViewer()
        {
            _dicHelp = new Dictionary<HelpViewType, string>
                       {
                               {
                                       HelpViewType.ShootControl, @"shoot.docx"
                               },
                               {
                                       HelpViewType.ChooseControl, @"choose.docx"
                               },
                               {
                                       HelpViewType.GetGoodsControl, @"getGoods.docx"
                               }
                       };
        }

        /// <summary>
        /// 查看帮助
        /// </summary>
        /// <param name="type">帮助类型</param>
        public static void FindHelp(HelpViewType type)
        {
            string strFileName;
            _dicHelp.TryGetValue(type, out strFileName);
            if(string.IsNullOrEmpty(strFileName))
            {
                throw new HelpViewException(HelpViewExceptionType.Normal, @"未找到指定的帮助类型！");
            }
            string strFilePath = Path.Combine(Path.Combine(Environment.CurrentDirectory, Directory), strFileName);
            if(!File.Exists(strFilePath))
            {
                throw new HelpViewException(HelpViewExceptionType.Normal, @"指定的帮助文档文件不存在！");
            }
            Process.Start(strFilePath);
        }
    }
}