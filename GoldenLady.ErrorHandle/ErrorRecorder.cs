using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Global;
using GoldenLadyWS;

namespace GoldenLady.ErrorHandle
{
    /// <summary>
    /// 软件报错记录器，用于记录用户操作过程中出现的未知错误
    /// Design By LiuHaiyang
    /// 2016.12.10
    /// LastUpdate By: LiuHaiyang
    /// LastUpdateDate: 2017.1.14
    /// </summary>
    public static class ErrorRecorder
    {
        /// <summary>
        /// 默认的本地日志文件路径
        /// </summary>
        private const string DefaultLocalFilePath = @"Logs\ErrorLog.txt";
        /// <summary>
        /// 本地日志最大存储量
        /// </summary>
        private const long MaxSaveBytes = 1024L * 1024L; // 最大存储 1MB

        private static void HintAndSaveError(Exception ex)
        {
            Save(ex, Directory.GetCurrentDirectory(), Information.CurrentUser.EmployeeNO);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"未知错误：" + ex.Message);
            sb.Append(HintString.PleaseConnectAdmin);
            MessageBox.Show(sb.ToString());
            OpenLocalFile(Directory.GetCurrentDirectory());
        }
        /// <summary>
        /// 打开本地错误日志文件
        /// </summary>
        private static void OpenLocalFile(string startUpDir)
        {
            string strFile = Path.Combine(startUpDir, DefaultLocalFilePath);
            if(!File.Exists(strFile)) return;
            Process.Start(strFile);
        }
        /// <summary>
        /// 将报错信息同时记录到本地日志文件和服务器
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="startUpDir">程序启动目录</param>
        /// <param name="employeeNO">操作员工编号</param>
        private static void Save(Exception ex, string startUpDir, string employeeNO)
        {
            SaveToLocal(ex, startUpDir);
            SaveToServer(ex, employeeNO);
        }
        /// <summary>
        /// 将报错信息记录到本地日志
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="startUpDir">程序启动目录</param>
        private static void SaveToLocal(Exception ex, string startUpDir)
        {
            // 检验文件路径是否存在
            string strLocalFilePath = Path.Combine(startUpDir, DefaultLocalFilePath);
            string strDir = Path.GetDirectoryName(strLocalFilePath);
            if(!Directory.Exists(strDir)) Directory.CreateDirectory(strDir);

            // 取出旧日志内容（放在新日志后面，保证最新的日志信息在文件开头）
            string strOld = null;
            if(File.Exists(strLocalFilePath) && (File.ReadAllBytes(strLocalFilePath).LongLength < MaxSaveBytes)) // 当文件大小超出最大存储量时，丢弃旧日志
            {
                strOld = File.ReadAllText(strLocalFilePath, Encoding.Default);
            }

            // 写入文件
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(@"[{0}]", DateTime.Now.ToString(CultureInfo.CurrentCulture)));
            sb.AppendLine(@"[异常类型]");
            sb.AppendLine(ex.GetType().FullName);
            sb.AppendLine(@"[提示信息]");
            sb.AppendLine(ex.Message);
            sb.AppendLine(@"[调用堆栈]");
            sb.AppendLine(ex.StackTrace);
            sb.AppendLine();
            if(null != strOld)
                sb.AppendLine(strOld);
            File.WriteAllText(strLocalFilePath, sb.ToString(), Encoding.Default);
        }
        /// <summary>
        /// 将报错信息记录到服务器
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="employeeNO">操作员工编号</param>
        private static void SaveToServer(Exception ex, string employeeNO)
        {
            try
            {
                ErpService.LogManagement.SaveErrorLog(employeeNO, ex.GetType().FullName, ex.Message, ex.StackTrace);
            }
            catch
            {
                // 防止二次报错
            }
        }
        /// <summary>
        /// 安全的执行一段可能抛出异常的代码，自动捕获记录异常
        /// </summary>
        /// <param name="act">目标代码</param>
        /// <returns>是否正确的执行了</returns>
        public static bool SafeExecute(Action act)
        {
            return SafeExecute(act, null);
        }
        /// <summary>
        /// 安全的执行一段可能抛出异常的代码，自动捕获记录异常
        /// </summary>
        /// <param name="act">目标代码</param>
        /// <param name="t">目标代码所需参数</param>
        /// <returns>是否正确的执行了</returns>
        public static bool SafeExecute<T>(Action<T> act, T t)
        {
            return SafeExecute(act, t, null);
        }
        /// <summary>
        /// 安全的执行一段可能抛出异常的代码，自动捕获记录异常
        /// </summary>
        /// <param name="act">目标代码</param>
        /// <param name="t1">目标代码所需参数</param>
        /// <param name="t2">目标代码所需参数</param>
        /// <returns>是否正确的执行了</returns>
        public static bool SafeExecute<T1, T2>(Action<T1, T2> act, T1 t1, T2 t2)
        {
            return SafeExecute(act, t1, t2, null);
        }
        /// <summary>
        /// 安全的执行一段可能抛出异常的代码，自动捕获记录异常，支持开发者自己处理异常
        /// </summary>
        /// <param name="act">目标代码</param>
        /// <param name="ownHandle">开发者自己能够处理的异常</param>
        /// <returns>是否正确的执行了</returns>
        public static bool SafeExecute(Action act, Predicate<Exception> ownHandle)
        {
            try
            {
                act();
                return true;
            }
            catch(Exception ex)
            {
                if((null == ownHandle) || (!ownHandle(ex)))
                {
                    HintAndSaveError(ex);
                }
                return false;
            }
        }
        /// <summary>
        /// 安全的执行一段可能抛出异常的代码，自动捕获记录异常，支持开发者自己处理异常
        /// </summary>
        /// <param name="act">目标代码</param>
        /// <param name="t">目标代码所需参数</param>
        /// <param name="ownHandle">开发者自己能够处理的异常</param>
        /// <returns>是否正确的执行了</returns>
        public static bool SafeExecute<T>(Action<T> act, T t, Predicate<Exception> ownHandle)
        {
            try
            {
                act(t);
                return true;
            }
            catch(Exception ex)
            {
                if ((null == ownHandle) || (!ownHandle(ex)))
                {
                    HintAndSaveError(ex);
                }
                return false;
            }
        }
        /// <summary>
        /// 安全的执行一段可能抛出异常的代码，自动捕获记录异常，支持开发者自己处理异常
        /// </summary>
        /// <param name="act">目标代码</param>
        /// <param name="t1">目标代码所需参数</param>
        /// <param name="t2">目标代码所需参数</param>
        /// <param name="ownHandle">开发者自己能够处理的异常</param>
        /// <returns>是否正确的执行了</returns>
        public static bool SafeExecute<T1, T2>(Action<T1, T2> act, T1 t1, T2 t2, Predicate<Exception> ownHandle)
        {
            try
            {
                act(t1, t2);
                return true;
            }
            catch(Exception ex)
            {
                if ((null == ownHandle) || (!ownHandle(ex)))
                {
                    HintAndSaveError(ex);
                }
                return false;
            }
        }
    }
}