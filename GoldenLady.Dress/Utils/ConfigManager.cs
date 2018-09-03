using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GoldenLady.Extension;
using GoldenLady.Utility;
using GoldenLady.Utility.DataStructure;

namespace GoldenLady.Dress.Utils
{
    /// <summary>
    /// 配置管理工具
    /// LiuHaiyang
    /// 2017.5.8
    /// </summary>
    internal sealed class ConfigManager
    {
        private const string RootNodeName = @"Root"; // 配置文件根节点名称
        private const string ConfigFileName = @"DressConfig.xml"; // 配置文件名称
        private static readonly string ConfigFilePath = Path.Combine(Application.LocalUserAppDataPath, ConfigFileName); // 配置文件绝对路径
        private readonly DressConfig _config = new DressConfig(); // 配置信息对象

        /// <summary>
        /// 配置信息
        /// </summary>
        public DressConfig Config
        {
            get { return _config; }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public ConfigManager()
        {
            Init();
        }

        /// <summary>
        /// 初始化配置管理
        /// </summary>
        private void Init()
        {
            EnsureFileExists();
            ReadConfigFromFile();
        }
        /// <summary>
        /// 读取配置信息文件
        /// </summary>
        private void ReadConfigFromFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigFilePath);

            // 读取到配置信息对象
            Config.CachePhotoDirectory = xmlDoc.GetElementValue(@"PhotoCacheDir", DefaultConfig.PhotoCacheDir);
            Config.ServerPhotoDirectory = xmlDoc.GetElementValue(@"ServerPhotoDir", DefaultConfig.ServerPhotoDir);
            Config.ThumbSize = CommonConverter.StringToSize(xmlDoc.GetElementValue(@"ThumbSize", DefaultConfig.ThumbSize));
            Config.LargeSize = CommonConverter.StringToSize(xmlDoc.GetElementValue(@"LargeSize", DefaultConfig.LargeSize));
            Config.ThumbShowSize = CommonConverter.StringToSize(xmlDoc.GetElementValue(@"ThumbShowSize", DefaultConfig.ThumbShowSize));
        }
        /// <summary>
        /// 检测配置文件是否存在，不存在则创建
        /// </summary>
        private static void EnsureFileExists()
        {
            if(!File.Exists(ConfigFilePath))
            {
                CreateDefaultConfigFile();
            }
        }
        /// <summary>
        /// 创建默认的配置文件
        /// </summary>
        private static void CreateDefaultConfigFile()
        {
            // 创建文件，写入默认值
            XmlDocument xmlDoc = new ConfigXmlDocument();

            // 根节点添加默认参数集
            XmlElement elemParams = xmlDoc.CreateElement(RootNodeName);
            elemParams.AppendChild(xmlDoc.CreateSingleElement(@"PhotoCacheDir", DefaultConfig.PhotoCacheDir)); // 本地照片缓存路径
            elemParams.AppendChild(xmlDoc.CreateSingleElement(@"ServerPhotoDir", DefaultConfig.ServerPhotoDir)); // 服务器照片存储路径
            elemParams.AppendChild(xmlDoc.CreateSingleElement(@"ThumbSize", DefaultConfig.ThumbSize)); // 照片缩略图尺寸
            elemParams.AppendChild(xmlDoc.CreateSingleElement(@"LargeSize", DefaultConfig.LargeSize)); // 照片大图尺寸
            elemParams.AppendChild(xmlDoc.CreateSingleElement(@"ThumbShowSize", DefaultConfig.ThumbShowSize)); // 照片缩略图展示尺寸

            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration(@"1.0", @"gb2312", null));
            xmlDoc.AppendChild(elemParams);
            xmlDoc.Save(ConfigFilePath);
        }
        /// <summary>
        /// 保存配置项目
        /// </summary>
        /// <param name="elementName">项目名称</param>
        /// <param name="value">项目值</param>
        private static void SaveConfig(string elementName, string value)
        {
            // 打开配置文件
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigFilePath);

            // 寻找指定项目
            XmlNodeList elems = xmlDoc.GetElementsByTagName(elementName);
            if(elems.Count > 0) // 存在项目，替换文本
            {
                elems[0].InnerText = value;
            }
            else // 不存在项目，向根节点添加该项目
            {
                XmlNode root = xmlDoc.SelectSingleNode(RootNodeName);
                if(root != null)
                {
                    root.AppendChild(xmlDoc.CreateSingleElement(elementName, value));
                }
            }

            // 保存配置文件
            xmlDoc.Save(ConfigFilePath);
        }

        /// <summary>
        /// 配置信息类
        /// LiuHaiyang
        /// 2017.5.8
        /// </summary>
        internal sealed class DressConfig
        {
            private string _serverPhotoDirectory;
            private string _cachePhotoDirectory;
            private Size _thumbSize;
            private Size _thumbShowSize;
            private Size _largeSize;

            /// <summary>
            /// 在转移缓存前要做的事情，在工作线程外（开始前）被调用
            /// </summary>
            [Browsable(false)]
            public Action BeforeMoveCache { get; set; }
            /// <summary>
            /// 在转移缓存后要做的事情，在工作线程中被调用
            /// </summary>
            [Browsable(false)]
            public Action AfterMoveCache { get; set; }

            /// <summary>
            /// 照片缩略图尺寸
            /// </summary>
            [Browsable(false)]
            public Size ThumbSize
            {
                get { return _thumbSize; }
                set
                {
                    _thumbSize = value;
                    SaveConfig(@"ThumbSize", CommonConverter.SizeToString(value));
                }
            }
            /// <summary>
            /// 照片缩略图展示尺寸
            /// </summary>
            [Browsable(false)]
            public Size ThumbShowSize
            {
                get { return _thumbShowSize; }
                set
                {
                    _thumbShowSize = value;
                    SaveConfig(@"ThumbShowSize", CommonConverter.SizeToString(value));
                }
            }
            /// <summary>
            /// 照片大图尺寸
            /// </summary>
            [Browsable(false)]
            public Size LargeSize
            {
                get { return _largeSize; }
                set
                {
                    _largeSize = value;
                    SaveConfig(@"LargeSize", CommonConverter.SizeToString(value));
                }
            }
            /// <summary>
            /// 服务器照片存储路径
            /// </summary>
            [Browsable(false)]
            public string ServerPhotoDirectory
            {
                get { return _serverPhotoDirectory; }
                set
                {
                    _serverPhotoDirectory = value;
                    SaveConfig(@"ServerPhotoDir", value);
                }
            }
            /// <summary>
            /// 本地照片缓存路径
            /// </summary>
            [Browsable(false)]
            public string CachePhotoDirectory
            {
                get { return _cachePhotoDirectory; }
                set
                {
                    if(null == _cachePhotoDirectory)
                    {
                        _cachePhotoDirectory = value;
                        SaveConfig(@"PhotoCacheDir", value);
                    }
                    else if(_cachePhotoDirectory != value) // 目录变更，迁移缓存
                    {
                        if(null != BeforeMoveCache)
                        {
                            BeforeMoveCache();
                        }
                        Task.Factory.StartNew(() =>
                        {
                            DirectoryTool.Copy(_cachePhotoDirectory, value);
                            if(Directory.Exists(_cachePhotoDirectory))
                            {
                                Directory.Delete(_cachePhotoDirectory, true);
                            }
                            _cachePhotoDirectory = value;
                            SaveConfig(@"PhotoCacheDir", value);
                            if(null != AfterMoveCache)
                            {
                                AfterMoveCache();
                            }
                        });
                    }
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Category("路径"), Description("照片缓存在本地计算机上的绝对路径")]
            [Editor(typeof (PropertyGridDirectoryItem), typeof (UITypeEditor))]
            public string 本地照片缓存路径
            {
                get { return CachePhotoDirectory; }
                set
                {
                    if(!Directory.Exists(value))
                    {
                        MessageBoxEx.Error(@"指定的目录不存在！");
                        return;
                    }
                    CachePhotoDirectory = value;
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Category("路径"), Description("所有的照片文件将会上传到这个服务器的这个路径下")]
            [Editor(typeof (PropertyGridDirectoryItem), typeof (UITypeEditor))]
            public string 服务器照片存储路径
            {
                get { return ServerPhotoDirectory; }
                set
                {
                    if(!Directory.Exists(value))
                    {
                        MessageBoxEx.Error(@"指定的目录不存在！");
                        return;
                    }
                    ServerPhotoDirectory = value;
                }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Category("参数"), Description("缓存照片生成的缩略图的尺寸")]
            public Size 照片缩略图尺寸
            {
                get { return ThumbSize; }
                set { ThumbSize = value; }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Category("参数"), Description("展示照片缩略图的尺寸")]
            public Size 照片缩略图展示尺寸
            {
                get { return ThumbShowSize; }
                set { ThumbShowSize = value; }
            }

            [EditorBrowsable(EditorBrowsableState.Never)]
            [Category("参数"), Description("缓存照片生成的大图的尺寸")]
            public Size 照片大图尺寸
            {
                get { return LargeSize; }
                set { LargeSize = value; }
            }
        }
        /// <summary>
        /// 默认配置信息
        /// LiuHaiyang
        /// 2017.5.8
        /// </summary>
        private static class DefaultConfig
        {
            public static readonly string PhotoCacheDir = Path.Combine(Application.LocalUserAppDataPath, @"PhotoCache");
            public static readonly string ServerPhotoDir = string.Format(@"\\127.0.0.1\Users\{0}\Desktop", Environment.UserName);
            public const string ThumbShowSize = @"100,100";
            public const string ThumbSize = @"256,256";
            public const string LargeSize = @"2048,2048";
        }
    }
}