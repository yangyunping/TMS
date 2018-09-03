using System;
using System.IO;
using System.Runtime.InteropServices;

namespace GoldenLady.Utility
{
    public static class ShellFiles
    {

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]

        public struct SHFILEOPSTRUCT
        {

            public IntPtr hwnd;

            [MarshalAs(UnmanagedType.U4)]
            public int wFunc;

            public string pFrom;

            public string pTo;

            public short fFlags;

            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;

            public IntPtr hNameMappings;

            public string lpszProgressTitle;

        }



        [DllImport("shell32.dll", CharSet = CharSet.Auto)]

        static extern int SHFileOperation(ref     SHFILEOPSTRUCT FileOp);

        const int FO_DELETE = 0x3;

        const int FO_COPY = 0x2;

        const int FO_MOVE = 0x1;

        const int FOF_ALLOWUNDO = 0x40;

        const int FOF_NOCONFIRMATION = 0x10;     //Don't     prompt     the     user.;       

        const int FOF_SIMPLEPROGRESS = 0x100;

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="path">要删除的目录</param>
        public static void SendToRecyclyBin(string path)
        {

            SHFILEOPSTRUCT shf = new SHFILEOPSTRUCT();

            shf.wFunc = FO_DELETE;

            shf.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;

            shf.pFrom = path;

            SHFileOperation(ref     shf);

        }

        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="from">源位置</param>
        /// <param name="to">目标位置</param>
        public static void Copy(string from, string to)
        {

            DirectoryInfo source = new DirectoryInfo(from);

            DirectoryInfo dest = new DirectoryInfo(to);

            if(!dest.Exists)

                dest.Create();

            SHFILEOPSTRUCT shf = new SHFILEOPSTRUCT();

            shf.wFunc = FO_COPY;

            shf.fFlags = FOF_ALLOWUNDO;

            shf.pFrom = from;

            shf.pTo = to;

            SHFileOperation(ref     shf);

        }

        /// <summary>
        /// 移动目录
        /// </summary>
        /// <param name="from">源位置</param>
        /// <param name="to">目标位置</param>
        public static void Move(string from, string to)
        {

            DirectoryInfo source = new DirectoryInfo(from);

            DirectoryInfo dest = new DirectoryInfo(to);

            if(!dest.Exists)

                dest.Create();

            SHFILEOPSTRUCT shf = new SHFILEOPSTRUCT();

            shf.wFunc = FO_MOVE;

            shf.fFlags = FOF_ALLOWUNDO;

            shf.pFrom = from;

            shf.pTo = to;

            SHFileOperation(ref     shf);

        }
    }
}
