using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GoldenLady.Utility
{
    public static class WinAPI
    {
        #region  Others

        [DllImport("User32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("User32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("User32.dll")]
        public static extern bool SetWindowTextW(IntPtr hWnd, string text);

        /// <summary>
        /// 写配置文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        /// <summary>
        /// 读配置文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <param name="retVal"></param>
        /// <param name="size"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// Sends the specified message to a window or windows. 
        /// The SendMessage function calls the window procedure for the specified window 
        /// and does not return until the window procedure has processed the message.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        /// <summary>
        /// GetWindowThreadProcessId
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        /// <summary>
        /// SetWindowPos
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);

        /// <summary>
        /// 指定产生动画的窗口的句柄 /// 指定动画持续的时间 /// 指定动画类型,可以是一个或多个标志的组合。
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="dwTime"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        /// <summary>
        /// ExtractIcon (网络资源)
        /// </summary>
        /// <param name="h"></param>
        /// <param name="strx"></param>
        /// <param name="ii"></param>
        /// <returns></returns>
        [DllImport("Shell32.dll")]
        public static extern int ExtractIcon(IntPtr h, string strx, int ii);

        /// <summary>
        /// SHGetFileInfoS(网络资源)
        /// </summary>
        /// <param name="pszPath"></param>
        /// <param name="dwFileAttributes"></param>
        /// <param name="psfi"></param>
        /// <param name="cbFileInfo"></param>
        /// <param name="uFlags"></param>
        /// <returns></returns>
        [DllImport("Shell32.dll")]
        public static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        //结构
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            public char szDisplayName;
            public char szTypeName;
        }
        #endregion

        #region   Old  CS.ZYC.WindowsAPI and csCut.WindowsAPI

        [Serializable, StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
            
            /// <summary>
            /// BitBlt
            /// </summary>
            /// <param name="hdcDest"></param>
            /// <param name="nXDest"></param>
            /// <param name="nYDest"></param>
            /// <param name="nWidth"></param>
            /// <param name="nHeight"></param>
            /// <param name="hdcSrc"></param>
            /// <param name="nXSrc"></param>
            /// <param name="nYSrc"></param>
            /// <param name="dwRop"></param>
            /// <returns></returns>
            [DllImportAttribute("gdi32.dll")]
            public static extern bool BitBlt(
                IntPtr hdcDest,   //目标设备的句柄  
                int nXDest,   //   目标对象的左上角的X坐标  
                int nYDest,   //   目标对象的左上角的X坐标  
                int nWidth,   //   目标对象的矩形的宽度  
                int nHeight,   //   目标对象的矩形的长度  
                IntPtr hdcSrc,   //   源设备的句柄  
                int nXSrc,   //   源对象的左上角的X坐标  
                int nYSrc,   //   源对象的左上角的X坐标  
                uint dwRop   //   光栅的操作值  
                );

            
            /// <summary>
            /// CreateDC
            /// </summary>
            /// <param name="lpszDriver"></param>
            /// <param name="lpszDevice"></param>
            /// <param name="lpszOutput"></param>
            /// <param name="lpInitData"></param>
            /// <returns></returns>
            [DllImportAttribute("gdi32.dll")]
            public static extern IntPtr CreateDC(
                string lpszDriver,   //   驱动名称  
                string lpszDevice,   //   设备名称  
                string lpszOutput,   //   无用，可以设定位"NULL"  
                IntPtr lpInitData   //   任意的打印机数据  
                );

            /// <summary>
            /// GetWindowRect
            /// </summary>
            /// <param name="handle"></param>
            /// <param name="lpRect"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern bool GetWindowRect(IntPtr handle, ref RECT lpRect);
           
            /// <summary>
            /// ClipCursor
            /// </summary>
            /// <param name="lpRect"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern bool ClipCursor(ref RECT lpRect);

            /// <summary>
            /// GetDC
            /// </summary>
            /// <param name="hWnd"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern IntPtr GetDC(IntPtr hWnd);

            /// <summary>
            /// SelectObject
            /// </summary>
            /// <param name="hdc"></param>
            /// <param name="hgdiobj"></param>
            /// <returns></returns>
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);


            /// <summary>
            /// DeleteObject
            /// </summary>
            /// <param name="hObject"></param>
            /// <returns></returns>
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);

            /// <summary>
            /// ReleaseDC
            /// </summary>
            /// <param name="hWnd"></param>
            /// <param name="hDC"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

            /// <summary>
            /// GetSystemMetrics
            /// </summary>
            /// <param name="nIndex"></param>
            /// <returns></returns>
            [DllImport("user32.dll")]
            public static extern int GetSystemMetrics(int nIndex);

            /// <summary>
            /// CreateCompatibleBitmap
            /// </summary>
            /// <param name="hdc"></param>
            /// <param name="nWidth"></param>
            /// <param name="nHeight"></param>
            /// <returns></returns>
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

            /// <summary>
            /// CreateCompatibleDC
            /// </summary>
            /// <param name="hdc"></param>
            /// <returns></returns>
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

            /// <summary>
            /// DeleteDC
            /// </summary>
            /// <param name="hdc"></param>
            /// <returns></returns>
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hdc);
        #endregion

        #region  UserAPI

            [StructLayout(LayoutKind.Sequential)]
            public class NETRESOURCE
            {

                public int dwScope;

                public int dwType;

                public int dwDisplayType;

                public int dwUsage;

                public string LocalName;

                public string RemoteName;

                public string Comment;

                public string Provider;

            }

            /// <summary>
            /// WNetAddConnection2
            /// </summary>
            /// <param name="lpNetResource"></param>
            /// <param name="lpPassword"></param>
            /// <param name="lpUsername"></param>
            /// <param name="dwFlags"></param>
            /// <returns></returns>
            [DllImport("mpr.dll", EntryPoint = "WNetAddConnection2")]

            public static extern uint WNetAddConnection2(

            [In] NETRESOURCE lpNetResource,

             string lpPassword,

             string lpUsername,

             uint dwFlags);

            /// <summary>
            /// WNetCancelConnection2
            /// </summary>
            /// <param name="lpName"></param>
            /// <param name="dwFlags"></param>
            /// <param name="fForce"></param>
            /// <returns></returns>
            [DllImport("Mpr.dll")]

            public static extern uint WNetCancelConnection2(

            string lpName,

            uint dwFlags,

            bool fForce);

            #endregion

        #region SMS 

            [DllImport("EUCPComm.dll", EntryPoint = "SendSMS")]  //即时发送
            public static extern int SendSMS(string sn, string mn, string ct, string priority);

            [DllImport("EUCPComm.dll", EntryPoint = "SendSMSEx")]  //即时发送(扩展)
            public static extern int SendSMSEx(string sn, string mn, string ct, string addi, string priority);

            [DllImport("EUCPComm.dll", EntryPoint = "SendScheSMS")]  // 定时发送
            public static extern int SendScheSMS(string sn, string mn, string ct, string ti, string priority);

            [DllImport("EUCPComm.dll", EntryPoint = "SendScheSMSEx")]  // 定时发送(扩展)
            public static extern int SendScheSMSEx(string sn, string mn, string ct, string ti, string addi, string priority);

            [DllImport("EUCPComm.dll", EntryPoint = "ReceiveSMS")]  // 接收短信
            public static extern int ReceiveSMS(string sn, deleSQF mySmsContent);

            [DllImport("EUCPComm.dll", EntryPoint = "ReceiveSMSEx")]  // 接收短信
            public static extern int ReceiveSMSEx(string sn, deleSQF mySmsContent);

            //[DllImport("EUCPComm.dll", EntryPoint = "ReceiveStatusReport")]  // 接收短信报告
            //public static extern int ReceiveStatusReport(string sn, delegSMSReport mySmsReport);

            //[DllImport("EUCPComm.dll", EntryPoint = "ReceiveStatusReportEx")]  // 接收短信报告(带批量ID)
            //public static extern int ReceiveStatusReportEx(string sn, delegSMSReportEx mySmsReportEx);  

            [DllImport("EUCPComm.dll", EntryPoint = "Register")]   // 注册 
            public static extern int Register(string sn, string pwd, string EntName, string LinkMan, string Phone, string Mobile, string Email, string Fax, string sAddress, string Postcode);

            [DllImport("EUCPComm.dll", EntryPoint = "GetBalance", CallingConvention = CallingConvention.Winapi)] // 余额 
            public static extern int GetBalance(string m, System.Text.StringBuilder balance);


            [DllImport("EUCPComm.dll", EntryPoint = "ChargeUp")]  // 存值
            public static extern int ChargeUp(string sn, string acco, string pass);

            [DllImport("EUCPComm.dll", EntryPoint = "GetPrice")]  // 价格
            public static extern int GetPrice(string m, System.Text.StringBuilder balance);

            [DllImport("EUCPComm.dll", EntryPoint = "RegistryTransfer")]  //申请转接
            public static extern int RegistryTransfer(string sn, string mn);

            [DllImport("EUCPComm.dll", EntryPoint = "CancelTransfer")]  // 注销转接
            public static extern int CancelTransfer(string sn);

            [DllImport("EUCPComm.dll", EntryPoint = "UnRegister")]  // 注销
            public static extern int UnRegister(string sn);

            [DllImport("EUCPComm.dll", EntryPoint = "SetProxy")]  // 设置代理服务器 
            public static extern int SetProxy(string IP, string Port, string UserName, string PWD);

            [DllImport("EUCPComm.dll", EntryPoint = "RegistryPwdUpd")]  // 修改序列号密码
            public static extern int RegistryPwdUpd(string sn, string oldPWD, string newPWD);

            //声明委托，对回调函数进行封装。
            public delegate void deleSQF(string mobile, string senderaddi, string recvaddi, string ct, string sd, ref int flag);

        #endregion

        #region   SMSCenter

           /// <summary>
           /// 连接
           /// </summary>
           /// <param name="pszIP"></param>
           /// <param name="iPort"></param>
           /// <param name="pszAccount"></param>
           /// <param name="pszPwd"></param>
           /// <returns></returns>
            [DllImport("MWGateway.dll", CharSet = CharSet.Ansi)]
            public static extern int MongateConnect(string pszIP, int iPort, string pszAccount, string pszPwd);

            /// <summary>
            /// 关闭连接
            /// </summary>
            /// <param name="sock"></param>
            [DllImport("MWGateway.dll", CharSet = CharSet.Ansi)]
            public static extern void MongateDisconnect(int sock);


            /// <summary>
            /// 读取剩余短信数量
            /// </summary>
            /// <param name="sock"></param>
            /// <returns></returns>
            [DllImport("MWGateway.dll", CharSet = CharSet.Ansi)]
            public static extern int MongateQueryBalance(int sock);


            /// <summary>
            /// 发送短信
            /// </summary>
            /// <param name="sock"></param>
            /// <param name="pszMobis"></param>
            /// <param name="pszMsg"></param>
            /// <param name="iMobiCount"></param>
            /// <param name="pszSN"></param>
            /// <returns></returns>
            [DllImport("MWGateway.dll", CharSet = CharSet.Ansi)]
            public static extern int MongateCsSendSms(int sock, string pszMobis, string pszMsg, int iMobiCount, string pszSN);
  
        #endregion


    }
}
