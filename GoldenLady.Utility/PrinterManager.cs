using System.IO;
using System.Text;

namespace GoldenLady.Utility
{
    /// <summary>
    /// 打印机管理
    /// Designed By LiuHaiyang
    /// 2016.12.8
    /// </summary>
    public static class PrinterManager
    {
        /// <summary>
        /// 常规打印机
        /// </summary>
        public static Printer NormalPrinter
        {
            get { return Printer.NormalPrinter; }
        }
        /// <summary>
        /// 收银打印机
        /// </summary>
        public static Printer CashPrinter
        {
            get { return Printer.CashPrinter; }
        }

        /// <summary>
        /// 初始化打印机
        /// </summary>
        /// <param name="startupPath">软件启动目录</param>
        public static void Init(string startupPath) { Printer.StartupPath = startupPath; }
    }

    /// <summary>
    /// 打印机类
    /// </summary>
    public sealed class Printer
    {
        #region Members

        /// <summary>
        /// 保存配置文件时对应的section
        /// </summary>
        private const string ConfigFileSection = @"Printer";
        /// <summary>
        /// 默认的打印机名称
        /// </summary>
        private const string DefaultPrinterName = @"None";
        /// <summary>
        /// 用于保存打印机配置的文件名
        /// </summary>
        private const string SaveFileName = @"Config.ini";
        private static Printer _normalPrinter;
        private static Printer _cashPrinter;

        #endregion

        #region Constructors

        static Printer()
        {
            StartupPath = string.Empty;
            _normalPrinter = null;
            _cashPrinter = null;
        }
        /// <summary>
        /// 构造器
        /// </summary>
        public Printer(string typeName)
        {
            TypeName = typeName;
            Load();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 收银打印机
        /// </summary>
        public static Printer CashPrinter
        {
            get { return _cashPrinter ?? (_cashPrinter = new Printer("CashPrinter")); }
        }
        /// <summary>
        /// 打印机名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 常规打印机
        /// </summary>
        public static Printer NormalPrinter
        {
            get { return _normalPrinter ?? (_normalPrinter = new Printer("NormalPrinter")); }
        }
        /// <summary>
        /// 用于保存打印机配置的文件路径
        /// </summary>
        private static string SaveFilePath
        {
            get { return Path.Combine(StartupPath, SaveFileName); }
        }
        /// <summary>
        /// 软件启动目录
        /// </summary>
        public static string StartupPath { get; set; }
        /// <summary>
        /// 打印机类型名
        /// </summary>
        public string TypeName { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// 读取配置文件
        /// </summary>
        public void Load()
        {
            const int bufferSize = 255;
            StringBuilder sb = new StringBuilder(bufferSize);
            WinAPI.GetPrivateProfileString(ConfigFileSection, TypeName, DefaultPrinterName, sb, bufferSize, SaveFilePath);
            Name = 0 == sb.Length ? DefaultPrinterName : sb.ToString();
        }
        /// <summary>
        /// 保存到配置文件
        /// </summary>
        public void Save() { WinAPI.WritePrivateProfileString(ConfigFileSection, TypeName, Name, SaveFilePath); }
        /// <summary>
        /// 保存到配置文件
        /// </summary>
        /// <param name="newName">新的打印机名</param>
        public void Save(string newName)
        {
            Name = newName;
            Save();
        }

        #endregion
    }
}