using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenLady.AutoUpdate
{
    public class Updater
    {
        /// <summary>
        /// 下载持续时间2分钟
        /// </summary>
        const int DownDuration = 60 * 1000;//下载持续时间1分钟
        /// <summary>
        /// 线程互斥
        /// </summary>
        readonly object LockObj = new object();

        /// <summary>
        /// 本地xml文件
        /// </summary>
        UpdateXmlFile _localXmlFile = null;
        /// <summary>
        /// 本地临时文件夹
        /// </summary>
        internal string TempDirectory
        {
            get
            {
                return Path.Combine(Environment.GetEnvironmentVariable(DataModel.TempEnvironmentVariable), string.Format("_{0}_T_M_P_", _localXmlFile.ApplicationId));
            }
        }
        /// <summary>
        /// 可用的Url-----------------------
        /// </summary>
        public string ServerUrl
        {
            get;
            private set;
        }
        /// <summary>
        /// 从服务器上下载下来的xml文件名
        /// </summary>
        public string TempXmlFileName
        {
            get;
            private set;
        }
        /// <summary>
        /// 服务器更新地址list
        /// </summary>
        internal List<string> UpdateUrlList
        {
            get { return _localXmlFile.UrlList; }
        }

        internal string EntryPoint
        {
            get { return _localXmlFile.EntryPoint; }
        }

        public Updater()
        {
            string localXmlPath = Path.Combine(Application.StartupPath, DataModel.XmlFileName);
            if (!File.Exists(localXmlPath))
            {
                throw new FileNotFoundException(localXmlPath);
            }
            _localXmlFile = new UpdateXmlFile(localXmlPath);
        }
        /// <summary>
        /// 检查更新，并返回可以更新的项目数
        /// </summary>
        /// <returns>可以更新的项目数 Int</returns>
        public  int CheckUpdate()
        {
            return CheckUpdateFile().Count();
        }
        /// <summary>
        /// 从服务器上下载更新文件xml
        /// </summary>
        /// <param name="tempXmlName">从服务器上下载下来的本地临时更新文件全名</param>
        /// <returns></returns>
        UpdateXmlFile GetUpdateXmlFile(string tempXmlName)
        {
            UpdateXmlFile serverXmlFile = null;

            if (UpdateUrlList.Count == 0)
            {
                return serverXmlFile;
            }

            DateTime beginDateTime = DateTime.Now;//开始下载时间

            int i = 0;
            foreach (var url in UpdateUrlList)
            {
                Task.Factory.StartNew(() =>
                {
                    string xmlUpdateUrl = string.Format("{0}/{1}", url.TrimEnd('/'), DataModel.XmlFileName);
                    string tempInTempXmlFileName = Path.Combine(Path.GetDirectoryName(tempXmlName), string.Format("{0}{1}{2}", Path.GetFileNameWithoutExtension(tempXmlName), i, Path.GetExtension(tempXmlName)));
                    UpdateXmlFile tempVar = GetServerXmlFile(tempInTempXmlFileName, xmlUpdateUrl);//服务器上下下来的xml
                    lock (LockObj)
                    {
                        if (string.IsNullOrWhiteSpace(ServerUrl))
                        {
                            ServerUrl = url;
                            serverXmlFile = tempVar;
                            TempXmlFileName = tempInTempXmlFileName;
                        }
                    }
                });
                ++i;
            }

            do
            {
                Thread.Sleep(64);
            } while (string.IsNullOrWhiteSpace(ServerUrl) && DateTime.Now.Subtract(beginDateTime).TotalMilliseconds < DownDuration);
            
            return serverXmlFile;
        }
        /// <summary>
        /// 检查更新，并返回可以更新的文件数据
        /// </summary>
        /// <returns>List<UpdateFile></returns>
        internal  IEnumerable<UpdateFileInfo> CheckUpdateFile()
        {
            string tempXmlName = Path.Combine(TempDirectory, DataModel.XmlFileName);
            CreateTempDirectory(TempDirectory);//创建临时目录

            UpdateXmlFile serverXmlFile = GetUpdateXmlFile(tempXmlName);

            if (serverXmlFile == null || _localXmlFile.EntryPoint != serverXmlFile.EntryPoint || _localXmlFile.ApplicationId != serverXmlFile.ApplicationId)
            {
                return new UpdateFileInfo[] { };
            }
            IEnumerable<UpdateFileInfo> newFile = serverXmlFile.FileInfos.Join(_localXmlFile.FileInfos, server => server.Name, local => local.Name, (server, local) => GetUpdateFileInfo(server, local)).Where(p => p != null);
            IEnumerable<UpdateFileInfo> addFile = serverXmlFile.FileInfos.Except(_localXmlFile.FileInfos, UpdateXmlFile.ComparerFileInfo.Comparer).Select(p => new UpdateFileInfo { CurrentVersion = "无", UpdateVersion = p.Version, FileName = p.Name });
            return newFile.Union(addFile);
        }
        /// <summary>
        /// 比效并获取可更新文件信息
        /// </summary>
        /// <param name="serverFileInfo"></param>
        /// <param name="localFileInfo"></param>
        /// <returns></returns>
        private  UpdateFileInfo GetUpdateFileInfo(UpdateXmlFile.FileInfo serverFileInfo, UpdateXmlFile.FileInfo localFileInfo)
        {
            string[] server = serverFileInfo.Version.Split('.');
            string[] local = localFileInfo.Version.Split('.');
            UpdateFileInfo up = null;
            for (int i = 0; i < server.Length; ++i )
            {
                int iServer = 0, iLocal = 0;
                if (int.TryParse(server[i], out iServer) && int.TryParse(local[i], out iLocal))
                {
                    if (iServer > iLocal)
                    {
                        up = new UpdateFileInfo { FileName = serverFileInfo.Name, CurrentVersion = localFileInfo.Version, UpdateVersion = serverFileInfo.Version };
                        break;
                    }
                }
            }
            return up;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempXmlName"></param>
        /// <param name="serverXmlUrl"></param>
        /// <returns></returns>
        private UpdateXmlFile GetServerXmlFile(string tempXmlName, string serverXmlUrl)
        {
            if (File.Exists(tempXmlName))
            {
                File.Delete(tempXmlName);
            }
            WebFile.DownLoadFile(tempXmlName, serverXmlUrl);
            UpdateXmlFile serverXmlFile = new UpdateXmlFile(tempXmlName);
            return serverXmlFile;
        }
        private void CreateTempDirectory(string tempDir)
        {
            if (!Directory.Exists(tempDir))//不存在
            {
                try
                {
                    Directory.CreateDirectory(tempDir);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
