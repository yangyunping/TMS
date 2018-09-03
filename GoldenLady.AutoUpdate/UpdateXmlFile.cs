using System.Collections.Generic;
using System.Xml;

namespace GoldenLady.AutoUpdate
{
    /// <summary>
    /// 处理更新的xml文件
    /// </summary>
    internal class UpdateXmlFile : XmlDocument
    {
        /// <summary>
        /// xml更新文件中记录的文件信息
        /// </summary>
        internal class FileInfo
        {
            /// <summary>
            /// 版本
            /// </summary>
            internal string Version { get; set; }
            /// <summary>
            /// 文件名
            /// </summary>
            internal string Name { get; set; }
        }

        internal class ComparerFileInfo : IEqualityComparer<FileInfo>
        {
            bool IEqualityComparer<FileInfo>.Equals(FileInfo x, FileInfo y)
            {
                if (x == null && y == null)
                {
                    return true;
                }
                else if (x == null || y == null)
                {
                    return false;
                }
                else
                {
                    if (x.Name == y.Name)
                    {
                        return true;
                    }
                }
                return false;
            }

            int IEqualityComparer<FileInfo>.GetHashCode(FileInfo obj)
            {
                if (obj == null)
                {
                    return 0;
                }
                return obj.Name.GetHashCode();
            }
            static ComparerFileInfo _comparer;
            internal static ComparerFileInfo Comparer
            {
                get
                {
                    return _comparer ?? (_comparer = new ComparerFileInfo());
                }
            }
        }
        internal UpdateXmlFile(string xmlPath)
        {
            this.Load(xmlPath);
        }
        /// <summary>
        /// 更新可用的Url
        /// </summary>
        internal List<string> UrlList
        {
            get
            {
                bool hasNext = true;
                int index = 1;
                List<string> lstUrl = new List<string>();
                do
                {
                    XmlNode node = this.SelectSingleNode(string.Format("/AutoUpdater/Updater/Url{0}", index));
                    if (node != null)
                    {
                        lstUrl.Add(node.InnerText);
                    }
                    else
                    {
                        hasNext = false;
                    }
                    ++index;

                } while (hasNext);
                return lstUrl;
            }
        }

        internal int FileCount
        {
            get
            {
                if (FilesNodes != null)
                {
                    return FilesNodes.Count;
                }
                return 0;
            }
        }

        internal List<FileInfo> FileInfos
        {
            get
            {
                if (FilesNodes != null)
                {
                    List<FileInfo> lst = new List<FileInfo>();
                    foreach (XmlNode node in FilesNodes)
                    {
                        lst.Add(new FileInfo { Version = node.Attributes["Ver"].Value, Name = node.Attributes["Name"].Value });
                    }
                    return lst;
                }
                return new List<FileInfo>();
            }
        }

        internal string ApplicationId
        {
            get
            {
                XmlNode node = this.SelectSingleNode("/AutoUpdater/Application");
                if (node != null)
                {
                    return node.Attributes["applicationId"].Value;
                }
                return string.Empty;
            }
        }

        internal string EntryPoint
        {
            get
            {
                XmlNode node = this.SelectSingleNode("/AutoUpdater/Application/EntryPoint");
                if (node != null)
                {
                    return node.InnerText;
                }
                return string.Empty;
            }
        }
        private XmlNodeList FilesNodes
        {
            get
            {

                XmlNode node = this.SelectSingleNode("/AutoUpdater/Files");
                if (node != null && node.HasChildNodes)
                {
                    return node.ChildNodes;
                }
                return null;
            }

        }
    }


}
