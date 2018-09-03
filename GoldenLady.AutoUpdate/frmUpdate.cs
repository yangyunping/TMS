using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace GoldenLady.AutoUpdate
{

    public partial class frmUpdate : Form
    {
        const string TEMP_FILE_NAME = "Old.exe";
        public frmUpdate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 干掉正在运行的程序
        /// </summary>
        /// <param name="appName"></param>
        private void PreDownLoad(string appName)
        {
            Process[] allProcess = Process.GetProcesses();
            foreach (var p in allProcess)
            {
                if (p.ProcessName.ToLower() + ".exe" == appName.ToLower())
                {
                    for (int i = 0; i < p.Threads.Count; i++)/*干掉程序中的线程*/
                    {
                        p.Threads[i].Dispose();
                    }
                    p.Kill();
                }
            }
            Thread.Sleep(10);//等一下，尽量确保appName被Kill掉
            if (File.Exists(TEMP_FILE_NAME))
            {
                try
                {
                    File.Delete(TEMP_FILE_NAME);
                }
                catch { }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            Updater updater = new Updater();
            PreDownLoad(updater.EntryPoint);
            IEnumerable<UpdateFileInfo> updateFiles = updater.CheckUpdateFile();
            int count = updateFiles.Count();
            int index = 1;
            Thread downTask = new Thread(() =>
            {
                foreach (var item in updateFiles)
                {
                    string tempFileName = Path.Combine(updater.TempDirectory, item.FileName);//升级下载的临时文件名（fullName）
                    string serverFileUrl = updater.ServerUrl.TrimEnd('/') + "/" + item.FileName.Replace('\\','/');
                    this.BeginInvoke(new Action(() =>
                    {
                        lblFile.Text = Path.GetFileName(tempFileName);
                        lblFileCount.Text = index + "/" + count;
                    }));
                    Thread.Sleep(128);/*让下载慢点点，也就慢点点^_^*/
                    try
                    {
                        if (File.Exists(tempFileName))
                        {
                            File.Delete(tempFileName);
                        }
                    }
                    catch{}
                    try
                    {
                        WebFile.DownLoadFile(tempFileName, serverFileUrl, PreDown, DownAction);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(serverFileUrl+"\r\n详细信息："+ex.Message);
                    }
                    index++;
                }
                this.Invoke(new Action(()=>CopyUpdateFile(updater,updateFiles)));//完成下载,拷贝文件
            });
            downTask.IsBackground = true;
            downTask.Start();
            base.OnShown(e);
        }
        /// <summary>
        /// 准备下载
        /// </summary>
        /// <param name="totalLength"></param>
        private void PreDown(long totalLength)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(data =>
                {
                    pgbDownProcess.Value = 0;
                    pgbDownProcess.Maximum = data;

                }), (int)totalLength);
            }
            else
            {
                pgbDownProcess.Value = 0;
                pgbDownProcess.Maximum = (int)totalLength;
            }
        }
        /// <summary>
        /// 监视下载进度
        /// </summary>
        /// <param name="dlData"></param>
        private void DownAction(DownLoadData dlData)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<DownLoadData>(data =>
                {
                    if ((int)data.DownLength <= pgbDownProcess.Maximum)
                    {
                        pgbDownProcess.Value = (int)data.DownLength;
                    }
                }), dlData);
            }
            else
            {
                if ((int)dlData.DownLength <= pgbDownProcess.Maximum)
                {
                    pgbDownProcess.Value = (int)dlData.DownLength;
                }
            }
        }
        /// <summary>
        /// 完成下载
        /// </summary>
        private void CopyUpdateFile(Updater updater, IEnumerable<UpdateFileInfo> updateFiles)
        {
            string currentDir = Application.StartupPath;
            string currentExecuteFile = this.GetType().Assembly.Location;
            foreach (var item in updateFiles)
            {
                string tempFileName = Path.Combine(updater.TempDirectory, item.FileName);
                string destinationFileName = Path.Combine(currentDir, item.FileName);
                string destinationDirectory = Path.GetDirectoryName(destinationFileName);
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }
                //判断是否是在更新自己
                if (Path.GetFileName(tempFileName).ToLower() == Path.GetFileName(currentExecuteFile).ToLower())
                {
                    //重命名自己（这是可以的）
                    File.Move(currentExecuteFile, Path.Combine(Path.GetDirectoryName(currentExecuteFile), TEMP_FILE_NAME));
                }
                if (File.Exists(tempFileName))
                {
                    File.Copy(tempFileName, destinationFileName, true);
                }
            }
            /*AutoUpdaterList.xml*/
            File.Copy(updater.TempXmlFileName, Path.Combine(currentDir, DataModel.XmlFileName), true);
            try
            {
                System.Diagnostics.Process.Start(updater.EntryPoint);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message+"\r\n"+updater.EntryPoint);
            }
            finally
            {
                Environment.Exit(0);
            }
        }
    }
}
