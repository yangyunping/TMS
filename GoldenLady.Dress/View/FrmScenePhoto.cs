using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmScenePhoto : FrmBackWork
    {
        private Scene _scene;
        private IList<string> _serverPaths;

        private Scene Scene
        {
            get { return _scene; }
            set
            {
                _scene = value;
                OnSceneChanged();
            }
        }
        private IList<string> ServerPaths
        {
            get { return _serverPaths; }
            set
            {
                _serverPaths = value;
                OnServerPathsChanged();
            }
        }
        private string ServerPath { get; set; }

        private void OnServerPathsChanged()
        {
            cmbServerPath.DataSource = ServerPaths;
            cmbServerPath.SelectedItem = null;
        }
        private void OnSceneChanged()
        {
            txtSceneName.Text = Scene.Name;
        }

        public FrmScenePhoto(Scene scene)
        {
            InitializeComponent();
            if(null == scene)
            {
                throw new ArgumentNullException(@"scene", @"场景对象不能为空");
            }
            Scene = scene;
            Init();
            BindEvents();
        }
        private void Init()
        {
            photoManager.ThumbSize = DressManager.ConfigManager.Config.ThumbShowSize;
            photoManager.LargePhotoMappingRule = DressManager.GetLarge;
        }
        private void BindEvents()
        {
            //
            // cmbServerPath
            //
            cmbServerPath.LostFocus += (sender, args) => ServerPath = ((ComboBox)sender).Text;
            //
            // this
            //
            Load += (sender, args) =>
            {
                InitData();
                StartBackWork(ProcLoad);
            };
            FormClosing += (sender, args) =>
            {
                OpenWaitFrm();
                UpdateWaitMessage(@"清除临时文件夹");
                DressManager.DeleteTempDirectory();
                CloseWaitFrm();
            };
        }
        private void InitData()
        {
            ServerPaths = DressManager.GetScenePhotoUploadPaths().ToList();
        }
        private void ProcLoad()
        {
            try
            {
                UpdateWaitMessage(@"创建本地照片处理临时文件夹");
                DressManager.CreateTempDirectory();

                UpdateWaitMessage(@"拉取服务器照片文件到本地");
                IEnumerable<string> thumbs = DressManager.DownloadToTemp(Scene);

                UpdateWaitMessage(@"加载图片");
                Invoke((Action<IEnumerable<string>>)(files =>
                {
                    photoManager.Photos.AddRange(files);
                    photoManager.UpdatePhotos();
                }), thumbs);

                Invoke(new MethodInvoker(CloseWaitFrm));
            }
            catch(Exception ex)
            {
                Invoke(new MethodInvoker(() =>
                {
                    CloseWaitFrm();
                    MessageBoxEx.Info(string.Format(@"加载照片失败！{0}{1}", Environment.NewLine, ex.Message));
                }));
            }
        }
        private void ProcAddPhoto(object objFiles)
        {
            IEnumerable<string> originalFiles = (IEnumerable<string>)objFiles;
            IEnumerable<string> files = null;
            IEnumerable<string> thumbFiles = null;
            IEnumerable<string> largeFiles = null;
            IEnumerable<string> SHA1Files = null;
            IEnumerable<string> serverFiles = null;
            IEnumerable<string> serverThumbFiles = null;
            IEnumerable<string> serverLargeFiles = null;
            IEnumerable<string> serverSHA1Files = null;
            try
            {
                UpdateWaitMessage(@"将原图迁移至临时处理文件夹");
                files = DressManager.CopyPhotoToTemp(originalFiles);

                UpdateWaitMessage(@"生成缩略图");
                thumbFiles = DressManager.GenerateThumb(files);

                UpdateWaitMessage(@"生成大图");
                largeFiles = DressManager.GenerateLarge(files);

                UpdateWaitMessage(@"生成SHA1校验码文件");
                SHA1Files = DressManager.GenerateSHA1(files);

                UpdateWaitMessage(@"上传照片到服务器");
                serverFiles = DressManager.UploadToServer(files, Scene, ServerPath);
                serverThumbFiles = DressManager.UploadToServer(thumbFiles, Scene, ServerPath);
                serverLargeFiles = DressManager.UploadToServer(largeFiles, Scene, ServerPath);
                serverSHA1Files = DressManager.UploadToServer(SHA1Files, Scene, ServerPath);

                UpdateWaitMessage(@"写入数据库");
                ErpService.DressManagement.NewScenePhoto(serverFiles, Scene);

                UpdateWaitMessage(@"加载照片");
                Invoke((Action<IEnumerable<string>>)(fs => photoManager.AddPhotos(fs)), thumbFiles);

                Invoke(new MethodInvoker(() =>
                {
                    CloseWaitFrm();
                    MessageBoxEx.Info(@"添加照片成功");
                }));
            }
            catch(Exception ex)
            {
                // 删除所有产生的文件
                FileTool.DeleteFiles(files);
                FileTool.DeleteFiles(thumbFiles);
                FileTool.DeleteFiles(largeFiles);
                FileTool.DeleteFiles(SHA1Files);
                FileTool.DeleteFiles(serverFiles);
                FileTool.DeleteFiles(serverThumbFiles);
                FileTool.DeleteFiles(serverLargeFiles);
                FileTool.DeleteFiles(serverSHA1Files);

                Invoke(new MethodInvoker(() =>
                {
                    CloseWaitFrm();
                    MessageBoxEx.Info(string.Format(@"添加照片失败！{0}{1}", Environment.NewLine, ex.Message));
                }));
            }
        }
        private void ProcDeletePhoto()
        {
            try
            {
                IEnumerable<string> thumbFiles = photoManager.SelectedPhotoFilePaths;
                var files = thumbFiles as string[] ?? thumbFiles.ToArray();
                IEnumerable<string> largeFiles = DressManager.GetLarge(files);

                if (files.Any())
                {
                    DressManager.DeleteServerFile(files, Scene);
                    UpdateWaitMessage(@"删除数据库记录及服务器文件");
                    UpdateWaitMessage(@"删除临时文件夹中的文件");
                    FileTool.DeleteFiles(files);
                }
                else
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        CloseWaitFrm();
                        MessageBox.Show(@"没有选中照片！");
                    }));
                    return;
                }
                FileTool.DeleteFiles(largeFiles);

                UpdateWaitMessage(@"加载照片");
                Invoke(new MethodInvoker(() => photoManager.RemoveSelected()));

                Invoke(new MethodInvoker(() =>
                {
                    CloseWaitFrm();
                    MessageBoxEx.Info(@"删除照片成功");
                }));
            }
            catch(Exception ex)
            {
                Invoke(new MethodInvoker(() =>
                {
                    CloseWaitFrm();
                    MessageBoxEx.Info(string.Format(@"删除照片失败！{0}{1}", Environment.NewLine, ex.Message));
                    Close(); // 关闭窗口防止发生其他意外
                }));
            }
        }

        private void photoManager_AddPhotoButtonClick(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(ServerPath))
            {
                MessageBoxEx.Error(@"请先选择一个上传路径！");
                cmbServerPath.Focus();
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog
            {
                Multiselect = true,
                Filter = DressManager.OriginalPhotoFileFilter
            };
            if(DialogResult.OK == dlg.ShowDialog())
            {
                // 检测重名的文件
                List<string> duplicatedFilesName = new List<string>();
                List<string> files = new List<string>();
                foreach(string fileName in dlg.FileNames)
                {
                    string name = fileName;
                    if(photoManager.Photos.Paths.Exists(fn => Path.GetFileNameWithoutExtension(fn) == Path.GetFileNameWithoutExtension(name)))
                    {
                        duplicatedFilesName.Add(Path.GetFileName(name));
                    }
                    else
                    {
                        files.Add(name);
                    }
                }

                // 提示存在重名文件
                if(duplicatedFilesName.Count > 0
                   &&
                   DialogResult.OK != MessageBoxEx.Confirm(string.Format(@"以下照片的文件名与现有照片的文件名重复：
{0}
这些文件将不会被添加，是否继续？", string.Join(Environment.NewLine, duplicatedFilesName.ToArray()))))
                {
                    return;
                }

                // 开始添加
                StartBackWork(ProcAddPhoto, files);
            }
        }
        private void photoManager_DeletePhotoButtonClick(object sender, EventArgs e)
        {
            // 删除确认
            if(DialogResult.OK != MessageBoxEx.Confirm(@"确定要删除选中的照片吗？"))
            {
                return;
            }
            // 开始删除
            StartBackWork(ProcDeletePhoto);
        }

        private void photoManager_CopyPhotoButtonClick(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog newpath = new FolderBrowserDialog();
                if (newpath.SelectedPath == null || newpath.ShowDialog() == DialogResult.Cancel)
                {
                    MessageBox.Show(@"复制所到的文件夹路径无效。");
                    return;
                }
                IEnumerable<string> thumbFiles = photoManager.SelectedPhotoFilePaths;
                var enumerable = thumbFiles as string[] ?? thumbFiles.ToArray();
                if (!enumerable.Any())
                {
                    MessageBox.Show(@"没有选中照片！");
                    return;
                }
                int i = 0;
                foreach (var thumbFile in enumerable)
                {
                    File.Copy(thumbFile.Replace("thumb", "large"), Path.Combine(newpath.SelectedPath,Convert.ToString(i)+@".jpg"));
                    i++;
                }
                MessageBox.Show(@"复制成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"出错。" + ex);
                return;
            }
        }
    }
}