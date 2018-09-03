using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GoldenLady.AutoUpdate
{
    internal static class WebFile
    {
        const int bufferLength = 1024;
        internal static void DownLoadFile(string fullFileName, string urlString)
        {
            DownLoadFile(fullFileName, urlString, null, null);
        }
        internal static void DownLoadFile(string fullFileName, string urlString, Action<long> PreDown, Action<DownLoadData> downAction)
        {
            string dirName = Path.GetDirectoryName(fullFileName);
            //创建目录
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            WebSimulate ws = new WebSimulate();
            long allLength=0L;//总长
            using (Stream webStream = ws.Simulate(urlString, out allLength))
            {
                using (FileStream fs = new FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = new byte[bufferLength];
                    long leftLength = allLength;
                    long downLength = 0;
                    if (PreDown != null)
                    {
                        PreDown(allLength);
                    }
                    while (leftLength > 0)
                    {
                        int readLength = webStream.Read(buffer, 0, bufferLength);
                        downLength += readLength;
                        leftLength -= readLength;
                        fs.Write(buffer, 0, readLength);
                        /************************/
                        if (downAction != null)
                        {
                            downAction(new DownLoadData(fullFileName, downLength));
                        }
                        /************************/
                        fs.Flush();
                    }
                }
            }
        }

    }
        internal class DownLoadData
        {
            /// <summary>
            ///文件名
            /// </summary>
            internal string FileName { get; private set; }
            /// <summary>
            /// 当前下载
            /// </summary>
            internal long DownLength { get; private set; }
            internal DownLoadData (string fileName, long downLength)
            {
                this.FileName = fileName;
                this.DownLength = downLength;
            }
        }
}
