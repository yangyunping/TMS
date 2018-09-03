using System;
using System.Windows.Forms;
using GoldenLady.Dress.View;

namespace GoldenLady.Dress
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Initialize.InitializeProgram();
            Application.Run(new frmLogin());
        }
    }
}