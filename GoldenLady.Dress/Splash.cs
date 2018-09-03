using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoldenLady.Dress
{
    internal static class Splash
    {
        /// <summary>
        /// splash是否显示
        /// </summary>
        static bool _formShown = false;
        /// <summary>
        /// splash线程
        /// </summary>
        static Thread ssThread;
        /// <summary>
        /// splashScreen 窗口
        /// </summary>
        static frmSplashScreen _splashScreenForm;

        /// <summary>
        /// splashScreen 窗口
        /// </summary>
        internal static frmSplashScreen SplashScreenForm
        {
            get
            {
                return Splash._splashScreenForm ?? (Splash._splashScreenForm = new frmSplashScreen());
            }
        }
        /// <summary>
        /// 显示splashscreen窗口
        /// </summary>
        internal static void Show()
        {
            _formShown = false;
            SplashScreenForm.Shown += (sender, e) => _formShown = true; 
            ShowInThread();
        }
        /// <summary>
        /// 更新splashscreen显示文字
        /// </summary>
        /// <param name="text"></param>
        internal static void UpdateText(string text)
        {
            SplashScreenForm.UpdateTest(text);
        }
        /// <summary>
        /// 关闭splashscreen
        /// </summary>
        internal static void Close()
        {
            if(SplashScreenForm.InvokeRequired)
            {
                SplashScreenForm.Invoke(new Action(() =>
                {
                    SplashScreenForm.Close();
                    SplashScreenForm.Dispose();
                }));
            }
            else
            {
                SplashScreenForm.Close();
                SplashScreenForm.Dispose();
            }
            ssThread.Join();
            ssThread = null;
        }
        /// <summary>
        /// 启动线程用于显示splashscreen
        /// </summary>
        static void ShowInThread()
        {
            ssThread = new Thread(() => System.Windows.Forms.Application.Run(SplashScreenForm));
            ssThread.IsBackground = true;
            ssThread.Start();//_formShown
            while (!SplashScreenForm.InvokeRequired)
            {
                Thread.Sleep(100);
            }
        }

        internal static void ShowMsgBox(string msg)
        {
            if (SplashScreenForm.InvokeRequired)
            {
                SplashScreenForm.Invoke(new Action(() =>
                {
                    System.Windows.Forms.MessageBox.Show(SplashScreenForm, msg);
                }));
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(SplashScreenForm, msg);
            }
        }
    }
}
