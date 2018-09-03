using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GoldenLady.Utility;

namespace GoldenLady.Dress
{
    /// <summary>
    /// 程序初始化过程类
    /// </summary>
    internal static class Initialize
    {
        const string TEMP_FILE_NAME = "Old.exe";
        const string UPDATE_EXECUTE_FILE = "AutoUpdate.exe";
        internal static void InitializeProgram()
        {
            /**/
            try
            {
                if (File.Exists(TEMP_FILE_NAME))
                {
                    File.Delete(TEMP_FILE_NAME);
                }
            }
            catch { }
            /**/
            Splash.Show();

            Splash.UpdateText("检查更新......");
            try
            {
                AutoUpdate.Updater updater = new AutoUpdate.Updater();
                if(updater.CheckUpdate() > 0)
                {
                    System.Diagnostics.Process.Start(UPDATE_EXECUTE_FILE);
                }
            }
            catch(Exception ex)
            {
                Splash.ShowMsgBox(string.Format(@"更新检查失败！{0}{1}", Environment.NewLine, ex.Message));
            }
            Thread.Sleep(100);

            Splash.UpdateText("初始化打印机......");
            PrinterManager.Init(Application.StartupPath);

            Thread.Sleep(100);
            Splash.Close();
        }
    }
}
