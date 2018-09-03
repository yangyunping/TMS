using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Extension;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.Utils
{
    /// <summary>
    /// 礼服管理器
    /// LiuHaiyang
    /// 2017.5.8
    /// </summary>
    internal static class DressManager
    {
        public static readonly string OriginalPhotoFileFilter = @"图片文件(*.jpg;)|*.jpg;";
        private const string DressThumbFileExtention = @".lf";
        private const string LargeFileExtention = @".large";
        private const string OriginalFileExtention = @".jpg";
        private const string Sha1FileExtention = @".sha1";
        private const string Sha1Wildcard = @"*.sha1";
        private const string TempPhotoDirectoryName = @"TempPhoto";
        private const string ThumbDirName = @"Thumb";
        private const string ThumbFileExtention = @".thumb";
        private const string ThumbWildcard = @"*.thumb";
        private static ConfigManager _configManager;
        private static string _tempDirectory;

        /// <summary>
        /// 配置管理
        /// </summary>
        public static ConfigManager ConfigManager
        {
            get { return _configManager ?? (_configManager = new ConfigManager()); }
        }
        /// <summary>
        /// 获取本地照片处理临时文件夹
        /// </summary>
        public static string TempDirectory
        {
            get { return _tempDirectory ?? (_tempDirectory = Path.Combine(Application.LocalUserAppDataPath, TempPhotoDirectoryName)); }
        }

        /// <summary>
        /// 获取指定场景的本地照片缓存路径
        /// </summary>
        /// <param name="scene">指定场景</param>
        /// <returns>指定场景的本地照片缓存路径</returns>
        private static string GetCacheDirectory(Scene scene)
        {
            return Path.Combine(ConfigManager.Config.CachePhotoDirectory, @"Scene", scene.ID.ToString());
        }
        /// <summary>
        /// 删除照片缓存（包含sha1文件、缩略图、大图）
        /// </summary>
        /// <param name="photoPath">照片文件路径</param>
        public static void DeleteCache(string photoPath)
        {
            File.Delete(GetLarge(photoPath));
            File.Delete(GetThumb(photoPath));
            File.Delete(GetSHA1(photoPath));
        }
        /// <summary>
        /// 创建本地照片处理临时文件夹
        /// </summary>
        public static void CreateTempDirectory()
        {
            DeleteTempDirectory();
            Directory.CreateDirectory(TempDirectory);
        }
        /// <summary>
        /// 删除本地照片处理临时文件夹
        /// </summary>
        public static void DeleteTempDirectory()
        {
            if(Directory.Exists(TempDirectory))
            {
                Directory.Delete(TempDirectory, true);
            }
        }
        /// <summary>
        /// 从照片路径获取缩略图路径
        /// </summary>
        /// <param name="photoPath">照片路径</param>
        /// <returns>缩略图路径</returns>
        public static string GetThumb(string photoPath)
        {
            return Path.GetExtension(photoPath) == ThumbFileExtention ? photoPath : Path.ChangeExtension(photoPath, ThumbFileExtention);
        }
        /// <summary>
        /// 从照片路径获取原图路径
        /// </summary>
        /// <param name="photoPath">照片路径</param>
        /// <returns>缩略图路径</returns>
        public static string GetOriginal(string photoPath)
        {
            return Path.GetExtension(photoPath) == OriginalFileExtention ? photoPath : Path.ChangeExtension(photoPath, OriginalFileExtention);
        }
        /// <summary>
        /// 从照片路径获取大图路径
        /// </summary>
        /// <param name="photoPath">照片路径</param>
        /// <returns>大图路径</returns>
        public static string GetLarge(string photoPath)
        {
            return Path.GetExtension(photoPath) == LargeFileExtention ? photoPath : Path.ChangeExtension(photoPath, LargeFileExtention);
        }
        /// <summary>
        /// 从照片路径获取SHA1路径
        /// </summary>
        /// <param name="photoPath">照片路径</param>
        /// <returns>SHA1路径</returns>
        public static string GetSHA1(string photoPath)
        {
            return Path.GetExtension(photoPath) == Sha1FileExtention ? photoPath : Path.ChangeExtension(photoPath, Sha1FileExtention);
        }
        /// <summary>
        /// 从照片路径获取礼服缩略图路径
        /// </summary>
        /// <param name="photoPath">照片路径</param>
        /// <returns>礼服缩略图路径</returns>
        public static string GetDressThumb(string photoPath)
        {
            return Path.GetExtension(photoPath) == DressThumbFileExtention ? photoPath : Path.ChangeExtension(photoPath, DressThumbFileExtention);
        }
        /// <summary>
        /// 拉取服务器场景照片文件到本地照片处理临时文件夹
        /// </summary>
        /// <param name="scene">要拉取照片的场景对象</param>
        /// <returns>缩略图路径</returns>
        public static IEnumerable<string> DownloadToTemp(Scene scene)
        {
            IEnumerable<string> files = ErpService.DressManagement.GetScenePhotoFiles(scene);
            List<string> thumbs = new List<string>();
            foreach(string file in files)
            {
                string srcThumb = GetThumb(file);
                //string srcLarge = GetLarge(file);
                //string tempDir = TempDirectory;
               // string dstThumb = Path.Combine(tempDir, Path.GetFileName(srcThumb));
               //string dstLarge = Path.Combine(tempDir, Path.GetFileName(srcLarge));
               // File.Copy(srcThumb, dstThumb, true);
               // File.Copy(srcLarge, dstLarge, true);
                thumbs.Add(srcThumb);
            }
            return thumbs;
        }
        /// <summary>
        /// 拷贝照片到临时处理文件夹
        /// </summary>
        /// <param name="files">照片文件</param>
        /// <returns>拷贝到临时处理文件夹中的文件</returns>
        public static IEnumerable<string> CopyPhotoToTemp(IEnumerable<string> files)
        {
            List<string> tempFiles = new List<string>();
            string tempDir = TempDirectory;
            foreach(string file in files)
            {
                string dstFilePath = Path.Combine(tempDir, Path.GetFileName(file));
                File.Copy(file, dstFilePath);
                tempFiles.Add(dstFilePath);
            }
            return tempFiles;
        }
        /// <summary>
        /// 生成缩略图（同目录下）
        /// </summary>
        /// <param name="files">原图文件</param>
        /// <returns>生成的缩略图文件</returns>
        public static IEnumerable<string> GenerateThumb(IEnumerable<string> files)
        {
            List<string> thumbFiles = new List<string>();
            foreach(string file in files)
            {
                string thumbFilePath = GetThumb(file);
                using(Image imgSrc = FileTool.ReadImageFile(file), img = imgSrc.ZoomImage(ConfigManager.Config.ThumbSize, true, Color.LightGray))
                {
                    img.Save(thumbFilePath, ImageFormat.Jpeg);
                }
                thumbFiles.Add(thumbFilePath);
            }
            return thumbFiles;
        }
        /// <summary>
        /// 生成大图（同目录下）
        /// </summary>
        /// <param name="files">原图文件</param>
        /// <returns>生成的大图文件</returns>
        public static IEnumerable<string> GenerateLarge(IEnumerable<string> files)
        {
            List<string> largeFiles = new List<string>();
            foreach(string file in files)
            {
                string largeFilePath = GetLarge(file);
                using(Image imgSrc = FileTool.ReadImageFile(file), img = imgSrc.ZoomImage(ConfigManager.Config.LargeSize))
                {
                    img.Save(largeFilePath, ImageFormat.Jpeg);
                }
                largeFiles.Add(largeFilePath);
            }
            return largeFiles;
        }
        /// <summary>
        /// 生成SHA1校验码文件（同目录下）
        /// </summary>
        /// <param name="files">原图文件</param>
        /// <returns>生成的HA1校验码文件</returns>
        public static IEnumerable<string> GenerateSHA1(IEnumerable<string> files)
        {
            List<string> SHA1Files = new List<string>();
            foreach(string file in files)
            {
                string SHA1FilePath = GetSHA1(file);
                FileTool.CreateAndWriteText(SHA1FilePath, SHA1Tool.EncryptFile(file));
                SHA1Files.Add(SHA1FilePath);
            }
            return SHA1Files;
        }
        /// <summary>
        /// 将本地场景文件上传到服务器
        /// </summary>
        /// <param name="files">本地场景文件</param>
        /// <param name="scene">要操作的场景对象</param>
        /// <param name="serverPath">服务器路径</param>
        /// <returns>上传到服务器上的文件</returns>
        public static IEnumerable<string> UploadToServer(IEnumerable<string> files, Scene scene, string serverPath)
        {
            string serverDir = Path.Combine(serverPath, @"Scene", scene.ID.ToString());
            if(!Directory.Exists(serverDir))
            {
                Directory.CreateDirectory(serverDir);
            }
            List<string> serverFiles = new List<string>();
            foreach(string file in files)
            {
                string serverFilePath = Path.Combine(serverDir, Path.GetFileName(file));
                File.Copy(file, serverFilePath);
                serverFiles.Add(serverFilePath);
            }
            return serverFiles;
        }
        /// <summary>
        /// 获取同一目录下对应的缩略图文件
        /// </summary>
        /// <param name="files">文件</param>
        /// <returns>对应的缩略图文件</returns>
        public static IEnumerable<string> GetThumb(IEnumerable<string> files)
        {
            return from file in files select GetThumb(file);
        }
        /// <summary>
        /// 获取同一目录下对应的原图文件
        /// </summary>
        /// <param name="files">文件</param>
        /// <returns>对应的原图文件</returns>
        public static IEnumerable<string> GetOriginal(IEnumerable<string> files)
        {
            return from file in files select GetOriginal(file);
        }
        /// <summary>
        /// 获取同一目录下对应的大图文件
        /// </summary>
        /// <param name="files">文件</param>
        /// <returns>对应的大图文件</returns>
        public static IEnumerable<string> GetLarge(IEnumerable<string> files)
        {
            return from file in files select GetLarge(file);
        }
        /// <summary>
        /// 获取同一目录下对应的SHA1文件
        /// </summary>
        /// <param name="files">文件</param>
        /// <returns>对应的SHA1文件</returns>
        public static IEnumerable<string> GetSHA1(IEnumerable<string> files)
        {
            return from file in files select GetSHA1(file);
        }
        /// <summary>
        /// 获取同一目录下对应的FileSHA1对象
        /// </summary>
        /// <param name="files">文件</param>
        /// <returns>对应的FileSHA1对象</returns>
        public static IEnumerable<FileSHA1> GetFileSHA1(IEnumerable<string> files)
        {
            return from file in files
                   select GetSHA1(file)
                   into path
                   let sha1 = FileTool.OpenAndReadAllText(path)
                   select new FileSHA1 {FilePath = path, SHA1 = sha1};
        }
        /// <summary>
        /// 获取指定场景文件对应的服务器上的文件
        /// </summary>
        /// <param name="files">指定场景文件</param>
        /// <param name="scene">文件所属的场景对象</param>
        /// <returns>对应的服务器上的文件</returns>
        public static IEnumerable<string> GetServerFile(IEnumerable<string> files, Scene scene)
        {
            return ErpService.DressManagement.GetScenePhotoFiles(scene).Where(filePath => files.Any(f => Path.GetFileName(f) == Path.GetFileName(filePath)));
        }
        /// <summary>
        /// 在服务器上删除与指定文件对应的场景文件以及数据库记录
        /// </summary>
        /// <param name="files">指定场景文件</param>
        /// <param name="scene">要删除文件的场景对象</param>
        public static void DeleteServerFile(IEnumerable<string> files, Scene scene)
        {
            IEnumerable<string> originalFiles = GetServerFile(GetOriginal(files), scene);
            IEnumerable<string> largeFiles = GetLarge(originalFiles);
            IEnumerable<string> thumbFiles = GetThumb(originalFiles);
            IEnumerable<string> SHA1Files = GetSHA1(originalFiles);

            ErpService.DressManagement.DeleteScenePhoto(originalFiles, scene);
            FileTool.DeleteFiles(originalFiles);
            FileTool.DeleteFiles(largeFiles);
            FileTool.DeleteFiles(thumbFiles);
            FileTool.DeleteFiles(SHA1Files);
        }
        /// <summary>
        /// 删除场景对象（数据库记录和服务器文件夹）
        /// </summary>
        /// <param name="scene">要删除的场景对象</param>
        public static void DeleteScene(Scene scene)
        {
            IEnumerable<string> serverFiles = ErpService.DressManagement.GetScenePhotoFiles(scene);
            IEnumerable<string> sceneDirs = DirectoryTool.GetDistinctDirectories(serverFiles);
            ErpService.DressManagement.DeleteScene(scene);
            DirectoryTool.DeleteDirectories(sceneDirs);
        }
        /// <summary>
        /// 删除风格对象
        /// </summary>
        /// <param name="theme"></param>
        public static void DeleteThemeObject(Theme theme)
        {
            ErpService.DressManagement.DeleteTheme(theme);
        }

        /// <summary>
        /// 获取场景的缩略图封面（默认取第一张）
        /// </summary>
        /// <param name="scene">要获取的场景对象</param>
        /// <returns>缩略图路径。如果本地缓存和服务器上都没有照片，返回null</returns>
        public static string GetCoverThumb(Scene scene)
        {
            // 获取缓存目录
            string cacheDir = GetCacheDirectory(scene);
            if(!Directory.Exists(cacheDir))
            {
                Directory.CreateDirectory(cacheDir);
            }

            // 有缓存，直接返回第一张
            IEnumerable<string> thumbFiles = Directory.GetFiles(cacheDir, ThumbWildcard, SearchOption.TopDirectoryOnly);
            if(thumbFiles.Any())
            {
                return thumbFiles.First();
            }

            // 无缓存，下载一张后返回
            IEnumerable<string> serverFiles = ErpService.DressManagement.GetScenePhotoFiles(scene);
            return serverFiles.Any() ? DownloadToCache(serverFiles.First(), cacheDir) : null;
        }
        /// <summary>
        /// 从服务器上下载指定照片到缓存（不含原图）
        /// </summary>
        /// <param name="serverFile">服务器上的文件路径</param>
        /// <param name="cacheDir">缓存目录（已确保存在）</param>
        /// <returns>下载后的缩略图缓存路径</returns>
        private static string DownloadToCache(string serverFile, string cacheDir)
        {
            string srcThumb = GetThumb(serverFile);
            string srcLarge = GetLarge(serverFile);
            string srcSHA1 = GetSHA1(serverFile);
            string dstThumb = Path.Combine(cacheDir, Path.GetFileName(srcThumb));
            string dstLarge = Path.Combine(cacheDir, Path.GetFileName(srcLarge));
            string dstSHA1 = Path.Combine(cacheDir, Path.GetFileName(srcSHA1));

            File.Copy(srcThumb, dstThumb);
            File.Copy(srcLarge, dstLarge);
            File.Copy(srcSHA1, dstSHA1);

            return dstThumb;
        }
        /// <summary>
        /// 从服务器上下载对象所有场景照片到缓存（不含原图）
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <param name="cacheDir">缓存目录（已确保存在）</param>
        /// <returns>下载后的缩略图缓存路径</returns>
        private static IEnumerable<string> DownloadToCache(Scene scene, string cacheDir)
        {
            List<string> cacheThumbs = new List<string>();
            IEnumerable<string> serverFiles = ErpService.DressManagement.GetScenePhotoFiles(scene);
            foreach(string serverFile in serverFiles)
            {
                string srcThumb = GetThumb(serverFile);
                string srcLarge = GetLarge(serverFile);
                string srcSHA1 = GetSHA1(serverFile);
                string dstThumb = Path.Combine(cacheDir, Path.GetFileName(srcThumb));
                string dstLarge = Path.Combine(cacheDir, Path.GetFileName(srcLarge));
                string dstSHA1 = Path.Combine(cacheDir, Path.GetFileName(srcSHA1));

                File.Copy(srcThumb, dstThumb);
                File.Copy(srcLarge, dstLarge);
                File.Copy(srcSHA1, dstSHA1);

                cacheThumbs.Add(dstThumb);
            }
            return cacheThumbs;
        }
        /// <summary>
        /// 获取场景对象的缩略图缓存
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <returns>缩略图缓存文件列表</returns>
        public static IEnumerable<string> GetCacheThumb(Scene scene)
        {
            // 获取缓存目录
            string cacheDir = GetCacheDirectory(scene);
            if(!Directory.Exists(cacheDir))
            {
                Directory.CreateDirectory(cacheDir);
            }

            // 检查是否有缓存照片
            IEnumerable<string> thumbFiles = Directory.GetFiles(cacheDir, ThumbWildcard, SearchOption.TopDirectoryOnly);
            if(thumbFiles.Any()) // 有缓存
            {
                // 检测是否需要更新缓存
                if(NeedUpdateCache(scene, cacheDir) && DialogResult.OK == MessageBoxEx.Confirm(@"检测到照片有更新，是否立即执行更新？")) // 需要
                {
                    UpdateCache(scene, cacheDir);
                    return Directory.GetFiles(cacheDir, ThumbWildcard, SearchOption.TopDirectoryOnly);
                }
                return thumbFiles;
            }
            // 下载全部
            return DownloadToCache(scene, cacheDir);
        }
        /// <summary>
        /// 获取场景对象的大图缓存
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <returns>大图缓存文件列表</returns>
        public static IEnumerable<string> GetCacheLarge(Scene scene)
        {
            return GetLarge(GetCacheThumb(scene));
        }
        /// <summary>
        /// 场景对象是否需要更新缓存
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <param name="cacheDir">场景对象缓存目录（已确保存在）</param>
        /// <returns>需要则返回true，否则false</returns>
        public static bool NeedUpdateCache(Scene scene, string cacheDir)
        {
            IEnumerable<string> serverFiles = ErpService.DressManagement.GetScenePhotoFiles(scene);
            IEnumerable<string> serverSHA1s = GetSHA1(serverFiles);
            IEnumerable<string> cacheSHA1s = Directory.GetFiles(cacheDir, Sha1Wildcard, SearchOption.TopDirectoryOnly);

            // 数量不等，需要更新
            if(serverSHA1s.Count() != cacheSHA1s.Count())
            {
                return true;
            }

            // 数量相等，对应检测
            IEnumerable<string> cacheSHA1Codes = GetSHA1Codes(cacheSHA1s);
            foreach(string serverSHA1 in serverSHA1s)
            {
                string code = FileTool.OpenAndReadAllText(serverSHA1);
                if(!cacheSHA1Codes.Contains(code))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// 从SHA1文件读取SHA1校验码
        /// </summary>
        /// <param name="sha1s">SHA1文件</param>
        /// <returns>SHA1校验码</returns>
        private static IEnumerable<string> GetSHA1Codes(IEnumerable<string> sha1s)
        {
            return from sha1 in sha1s select FileTool.OpenAndReadAllText(sha1);
        }
        /// <summary>
        /// 更新场景对象缓存
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <param name="cacheDir">场景对象缓存目录（已确保存在）</param>
        public static void UpdateCache(Scene scene, string cacheDir)
        {
            IEnumerable<string> serverFiles = ErpService.DressManagement.GetScenePhotoFiles(scene);
            IEnumerable<FileSHA1> serverFileSHA1s = GetFileSHA1(serverFiles);
            IEnumerable<string> cacheSHA1s = Directory.GetFiles(cacheDir, Sha1Wildcard, SearchOption.TopDirectoryOnly);
            List<FileSHA1> cacheFileSHA1s = GetFileSHA1(cacheSHA1s).ToList();

            // 删除多余的缓存
            for(int idx = cacheFileSHA1s.Count - 1; idx >= 0; idx--)
            {
                FileSHA1 file = cacheFileSHA1s[idx];
                if(null == serverFileSHA1s.FirstOrDefault(f => f.SHA1 == file.SHA1))
                {
                    DeleteCache(file.FilePath);
                    cacheFileSHA1s.RemoveAt(idx);
                }
            }

            // 校对更新缓存
            foreach(FileSHA1 serverFileSha1 in serverFileSHA1s)
            {
                FileSHA1 theOne = cacheFileSHA1s.FirstOrDefault(f => f.SHA1 == serverFileSha1.SHA1);
                if(null == theOne) // 未缓存
                {
                    DownloadToCache(serverFileSha1.FilePath, cacheDir);
                }
                else // 已缓存
                {
                    string serverPhotoName = Path.GetFileNameWithoutExtension(serverFileSha1.FilePath);
                    if(serverPhotoName != Path.GetFileNameWithoutExtension(theOne.FilePath)) // 名称不同
                    {
                        RenameCache(theOne.FilePath, serverPhotoName); // 重命名
                    }
                }
                cacheFileSHA1s.Remove(theOne);
            }
        }
        /// <summary>
        /// 缓存照片重命名
        /// </summary>
        /// <param name="filePath">缓存照片文件</param>
        /// <param name="newName">新名称</param>
        private static void RenameCache(string filePath, string newName)
        {
            string oldThumb = GetThumb(filePath);
            string oldLarge = GetLarge(filePath);
            string oldSHA1 = GetSHA1(filePath);
            string dir = Path.GetDirectoryName(filePath);
            string newThumb = Path.Combine(dir, string.Concat(newName, ThumbFileExtention));
            string newLarge = Path.Combine(dir, string.Concat(newName, LargeFileExtention));
            string newSHA1 = Path.Combine(dir, string.Concat(newName, Sha1FileExtention));

            File.Delete(newThumb);
            File.Delete(newLarge);
            File.Delete(newSHA1);

            File.Move(oldThumb, newThumb);
            File.Move(oldLarge, newLarge);
            File.Move(oldSHA1, newSHA1);
        }
        /// <summary>
        /// 获取规则集
        /// </summary>
        /// <returns>规则集</returns>
        public static IEnumerable<RuleObject> GetRules()
        {
            return ErpService.DressManagement.GetRules();
        }
        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns>供应商</returns>
        public static IEnumerable<Supplier> GetSuppliers()
        {
            return ErpService.DressManagement.GetSuppliers();
        }
        /// <summary>
        /// 获取档次规格
        /// </summary>
        /// <returns>档次规格</returns>
        public static IEnumerable<Level> GetLevels()
        {
            return ErpService.DressManagement.GetLevels();
        }
        /// <summary>
        /// 获取照片服务器路径
        /// </summary>
        /// <returns>照片服务器路径</returns>
        public static IEnumerable<string> GetServerPaths()
        {
            return ErpService.DressManagement.GetServerPaths();
        }
        /// <summary>
        /// 从规则集中过滤出指定集
        /// </summary>
        /// <param name="rules">规则集</param>
        /// <param name="parentRuleNo">指定父集编号</param>
        /// <returns></returns>
        public static IEnumerable<RuleObject> FilterRules(IEnumerable<RuleObject> rules, int parentRuleNo)
        {
            return rules.Where(r => r.ParentRuleNo == parentRuleNo);
        }
        /// <summary>
        /// 上传礼服照片到服务器
        /// </summary>
        /// <param name="filePath">礼服照片路径</param>
        /// <param name="serverDir">服务器文件夹路径</param>
        /// <returns>上传后的文件绝对路径</returns>
        public static string UploadDressPhoto(string filePath, string serverDir)
        {
            string serverFilePath = Path.Combine(serverDir, Path.GetFileName(filePath));
            if (serverFilePath != filePath)
            {
                string serverThumbPath = GetDressThumb(serverFilePath);
                File.Copy(filePath, serverFilePath, true);
                using (
                    Image imgSrc = FileTool.ReadImageFile(filePath),
                        img = imgSrc.ZoomImage(ConfigManager.Config.ThumbSize))
                {
                    img.Save(serverThumbPath, ImageFormat.Jpeg);
                }
            }
            return serverFilePath;
        }
        /// <summary>
        /// 删除服务器上的礼服照片
        /// </summary>
        /// <param name="serverFilePath">服务器上的礼服照片绝对路径</param>
        public static void DeleteDressPhoto(string serverFilePath)
        {
            string serverThumbPath = GetDressThumb(serverFilePath);
            File.Delete(serverFilePath);
            File.Delete(serverThumbPath);
        }
        /// <summary>
        /// 从区域对象获取所在场馆部门名称
        /// </summary>
        /// <param name="area">区域对象</param>
        /// <param name="rules">规则集</param>
        /// <returns>区域对象所在场馆部门名称</returns>
        public static string GetDepartmentName(RuleObject area, IEnumerable<RuleObject> rules)
        {
            RuleObject target = area;
            while(null != target && string.IsNullOrWhiteSpace(target.BindingNo))
            {
                target = rules.FirstOrDefault(r => r.RuleNo == target.ParentRuleNo);
            }
            return target == null ? null : ErpService.CompanyManagement.GetDepartmentNameByNo(target.BindingNo);
        }
        /// <summary>
        /// 新建礼服
        /// </summary>
        /// <param name="dress">要新建的礼服对象</param>
        /// <param name="serverPhotoPath">礼服对应的服务器照片文件路径</param>
        public static void NewDress(Standard.Dress.Dress dress, string serverPhotoPath)
        {
            ErpService.DressManagement.NewDress(dress, serverPhotoPath);
        }
        /// <summary>
        /// 修改礼服
        /// </summary>
        /// <param name="dress">要新建的礼服对象</param>
        /// <param name="serverPhotoPath">礼服对应的服务器照片文件路径</param>
        public static void OldDressModify(Standard.Dress.Dress dress, string serverPhotoPath)
        {
            ErpService.DressManagement.OldDressModify(dress, serverPhotoPath);
        }
        /// <summary>
        /// 检测场馆是否已存在
        /// </summary>
        /// <param name="newVenue">准备新建的场馆对象</param>
        /// <returns>存在返回true，不存在返回false</returns>
        public static bool IsVenueExists(Venue newVenue)
        {
            return ErpService.DressManagement.IsVenueExists(newVenue);
        }
        /// <summary>
        /// 添加场馆
        /// </summary>
        /// <param name="venue">场馆</param>
        public static void NewVenue(Venue venue)
        {
            ErpService.DressManagement.NewVenue(venue);
        }
        /// <summary>
        /// 检测风格是否已存在
        /// </summary>
        /// <param name="theme">准备新建的风格对象</param>
        /// <returns>存在返回true，不存在返回false</returns>
        public static bool IsThemeExists(Theme theme)
        {
            return ErpService.DressManagement.IsThemeExists(theme);
        }
        /// <summary>
        /// 添加风格
        /// </summary>
        /// <param name="theme">风格</param>
        public static void NewTheme(Theme theme)
        {
            ErpService.DressManagement.NewTheme(theme);
        }
        /// <summary>
        /// 检测场景是否已存在
        /// </summary>
        /// <param name="scene">准备新建的场景对象</param>
        /// <returns>存在返回true，不存在返回false</returns>
        public static bool IsSceneExists(Scene scene)
        {
            return ErpService.DressManagement.IsSceneExists(scene);
        }
        /// <summary>
        /// 添加场景
        /// </summary>
        /// <param name="scene">场景</param>
        public static void NewScene(Scene scene)
        {
            ErpService.DressManagement.NewScene(scene);
        }
        /// <summary>
        /// 更新场馆信息
        /// </summary>
        /// <param name="venue">要更新的场馆对象</param>
        public static void UpdateVenue(Venue venue)
        {
            ErpService.DressManagement.UpdateVenue(venue);
        }
        /// <summary>
        /// 获取场馆
        /// </summary>
        /// <returns>场馆列表</returns>
        public static IEnumerable<Venue> GetVenues()
        {
            return ErpService.DressManagement.GetVenues();
        }
        /// <summary>
        /// 获取所属于指定场馆的风格
        /// </summary>
        /// <param name="venue">指定的场馆</param>
        /// <returns>风格列表</returns>
        public static IEnumerable<Theme> GetThemes(Venue venue)
        {
            return ErpService.DressManagement.GetThemes(venue);
        }
        /// <summary>
        /// 更新风格信息
        /// </summary>
        /// <param name="theme">要更新的风格对象</param>
        public static void UpdateTheme(Theme theme)
        {
            ErpService.DressManagement.UpdateTheme(theme);
        }
        /// <summary>
        /// 获取所属于指定风格的场景
        /// </summary>
        /// <param name="theme">指定的风格</param>
        /// <returns>场景列表</returns>
        public static IEnumerable<Scene> GetScenes(Theme theme)
        {
            return ErpService.DressManagement.GetScenes(theme);
        }
        /// <summary>
        /// 更新场景信息
        /// </summary>
        /// <param name="scene">要更新的场景对象</param>
        public static void UpdateScene(Scene scene)
        {
            ErpService.DressManagement.UpdateScene(scene);
        }
        /// <summary>
        /// 获取指定场景绑定的礼服条码
        /// </summary>
        /// <param name="scene">指定场景对象</param>
        /// <returns>绑定的礼服条码</returns>
        public static IEnumerable<string> GetDressBarCodes(Scene scene)
        {
            return ErpService.DressManagement.GetDressBarCodes(scene);
        }
        /// <summary>
        /// 获取指定风格绑定的对象礼服条码
        /// </summary>
        /// <param name="theme">指定风格对象</param>
        /// <param name="typeId">对象类型规则编号</param>
        /// <returns>绑定的对象礼服条码</returns>
        public static IEnumerable<string> GetDressBarCodes(Theme theme, int typeId)
        {
            return ErpService.DressManagement.GetDressBarCodes(theme, typeId);
        }
        /// <summary>
        /// 新建场景礼服匹配
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <param name="dressBarCode">礼服条码</param>
        public static void NewSceneDress(Scene scene, string dressBarCode)
        {
            ErpService.DressManagement.NewSceneDress(scene, dressBarCode);
        }                                                                                                                                                                                                                                                                                                                                                                  
        /// <summary>
        /// 移除场景礼服匹配
        /// </summary>
        /// <param name="scene">场景对象</param>
        /// <param name="dressBarCode">礼服条码</param>
        public static void DeleteSceneDress(Scene scene, string dressBarCode)
        {
            ErpService.DressManagement.DeleteSceneDress(scene, dressBarCode);
        }
        /// <summary>
        /// 获取场景照片上传路径
        /// </summary>
        /// <returns>场景照片上传路径</returns>
        public static IEnumerable<string> GetScenePhotoUploadPaths()
        {
            return ErpService.DressManagement.GetScenePhotoUploadPaths();
        }
        /// <summary>
        /// 获取主题匹配所需要的类型（男士礼服，妆面）
        /// </summary>
        /// <returns>主题匹配所需要的类型</returns>
        public static IEnumerable<RuleObject> GetThemeMatchTypes()
        {
            return ErpService.DressManagement.GetThemeMatchTypes();
        }
        /// <summary>
        /// 新建风格匹配
        /// </summary>
        /// <param name="theme">风格对象</param>
        /// <param name="dressBarCode">礼服条码</param>
        /// <param name="typeId">性质规则编号</param>
        public static void NewThemeDress(Theme theme, string dressBarCode, int typeId)
        {
            ErpService.DressManagement.NewThemeDress(theme, dressBarCode, typeId);
        }
        /// <summary>
        /// 删除风格匹配
        /// </summary>
        /// <param name="theme">风格对象</param>
        /// <param name="dressBarCode">礼服编号</param>
        /// <param name="typeId">性质规则编号</param>
        public static void DeleteThemeDress(Theme theme, string dressBarCode, int typeId)
        {
            ErpService.DressManagement.DeleteThemeDress(theme, dressBarCode, typeId);
        }
        /// <summary>
        /// 获取跨馆预选
        /// </summary>
        /// <param name="venueId">场馆ID</param>
        /// <returns>跨馆预选设置记录</returns>
        public static IEnumerable<CrossReservation> GetCrossReservations(int venueId)
        {
            return ErpService.DressManagement.GetCrossReservations(venueId);
        }
        /// <summary>
        /// 新建跨馆选衣
        /// </summary>
        /// <param name="crossReservation">跨馆选衣设置</param>
        public static void NewCrossReservation(CrossReservation crossReservation)
        {
            ErpService.DressManagement.NewCrossReservation(crossReservation);
        }
        /// <summary>
        /// 删除跨馆选衣
        /// </summary>
        /// <param name="crossReservation">跨馆选衣设置</param>
        public static void DeleteCrossReservation(CrossReservation crossReservation)
        {
            ErpService.DressManagement.DeleteCrossReservation(crossReservation);
        }

        /// <summary>
        /// 礼服淘汰
        /// </summary>
        /// <param name="barcode">礼服条码</param>
        /// <param name="state"></param>
        public static void EliminateDress(string barcode ,string state)
        {
            ErpService.DressManagement.EliminateDress(barcode, state, @"礼服" + barcode + state);
        }

        /// <summary>
        /// 次数修改
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="dressCnt"></param>
        /// <param name="empId"></param>
        /// <param name="oldCnt"></param>
        /// EliminateDressUse
        public static bool EliminateDressUseCout(string barcode, decimal dressCnt,string empId, string oldCnt)
        {
            return ErpService.DressManagement.EliminateDressUseCout(barcode, dressCnt, empId, oldCnt);
        }

        /// <summary>
        /// 用途修改
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="dressUse"></param>
        /// <param name="empId"></param>
        /// <param name="useage"></param>
        /// EliminateDressUse
        public static bool EliminateDressUse(string barcode, string dressUse, string empId, string useage)
        {
            return ErpService.DressManagement.EliminateDressUse(barcode, dressUse, empId, useage);
        }

        /// <summary>
        /// 更换礼服所在场馆
        /// </summary>
        /// <param name="barcode">礼服条码</param>
        /// <param name="area">场馆对象</param>
        /// <param name="oldeVeunue"></param>
        /// <param name="empId"></param>
        /// <param name="department"></param>
        public static void ChangeArea(string barcode, RuleObject area,string oldeVeunue, string empId, string department)
        {
            ErpService.DressManagement.ChangeArea(barcode, area, GetDepartmentName(area, GetRules()), oldeVeunue, empId, department);
        }
    }
}