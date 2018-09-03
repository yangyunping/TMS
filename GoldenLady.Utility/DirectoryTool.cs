using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoldenLady.Utility
{
    /// <summary>
    /// 文件夹操作工具
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public static class DirectoryTool
    {
        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="srcDir">源文件夹</param>
        /// <param name="dstDir">目标文件夹</param>
        public static void Copy(string srcDir, string dstDir)
        {
            // 创建目标文件夹
            if(!Directory.Exists(dstDir))
            {
                Directory.CreateDirectory(dstDir);
            }

            // 源文件夹不存在，直接返回
            if(!Directory.Exists(srcDir))
            {
                return;
            }

            // 拷贝顶层文件
            foreach(string file in Directory.GetFiles(srcDir, @"*.*", SearchOption.TopDirectoryOnly))
            {
                File.Copy(file, Path.Combine(dstDir, Path.GetFileName(file)));
            }

            // 迭代拷贝子文件夹
            foreach(string directory in Directory.GetDirectories(srcDir, @"*", SearchOption.TopDirectoryOnly))
            {
                Copy(directory, Path.Combine(dstDir, Path.GetFileName(directory)));
            }
        }
        /// <summary>
        /// 获取批量文件路径所属的所有上一级目录（不重复）
        /// </summary>
        /// <param name="files">要获取上一级目录的批量文件路径</param>
        /// <returns>所属的所有上一级目录（不重复）</returns>
        public static IEnumerable<string> GetDistinctDirectories(IEnumerable<string> files)
        {
            List<string> dirs = new List<string>();
            foreach(string dir in files.Select(Path.GetDirectoryName).Where(dir => !dirs.Contains(dir))) 
            {
                dirs.Add(dir);
            }
            return dirs;
        }
        /// <summary>
        /// 批量删除文件夹
        /// </summary>
        /// <param name="directories">要删除的文件夹</param>
        public static void DeleteDirectories(IEnumerable<string> directories)
        {
            foreach(string directory in directories.Where(Directory.Exists)) 
            {
                Directory.Delete(directory, true);
            }
        }
    }
}