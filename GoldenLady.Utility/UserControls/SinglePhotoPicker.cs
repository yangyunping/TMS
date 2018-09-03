using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GoldenLady.Utility.UserControls
{
    /// <summary>
    /// 单张图片拾取器
    /// LiuHaiyang
    /// 2017.4.28
    /// </summary>
    public partial class SinglePhotoPicker : UserControl
    {
        private string _photoFileFilter = @"照片文件(*.jpg;)|*.jpg;";
        private Image _currentPhoto;
        private string _photoFilePath;

        /// <summary>
        /// 存放在内存里的当前照片对象
        /// </summary>
        public Image CurrentPhoto
        {
            get { return _currentPhoto; }
            set
            {
                if(null != _currentPhoto)
                {
                    _currentPhoto.Dispose();
                }
                _currentPhoto = value;
                OnCurrentPhotoChanged();
            }
        }
        /// <summary>
        /// 打开的照片文件的完整路径
        /// </summary>
        public string PhotoFilePath
        {
            get { return _photoFilePath; }
            set
            {
                _photoFilePath = value;
                OnPhotoFilePathChanged();
            }
        }

        private void OnCurrentPhotoChanged()
        {
            picPhoto.Image = CurrentPhoto;
        }
        private void OnPhotoFilePathChanged()
        {
            CurrentPhoto = null == PhotoFilePath ? null : FileTool.ReadImageFile(PhotoFilePath);
            lblName.Text = null == PhotoFilePath ? @"没有图片" : Path.GetFileName(PhotoFilePath);
            if(null != _photoFilePathChanged)
            {
                _photoFilePathChanged(this, EventArgs.Empty);
            }
        }

        public SinglePhotoPicker()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = PhotoFileFilter
            };
            if(DialogResult.OK == dlg.ShowDialog())
            {
                PhotoFilePath = dlg.FileName;
            }
        }
        private void btnClear_Click(object sender, System.EventArgs e)
        {
            PhotoFilePath = null;
        }

        /// <summary>
        /// 照片文件格式过滤规则，默认只打开jpg格式
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义属性"), Description("照片文件格式过滤规则")]
        public string PhotoFileFilter
        {
            get { return _photoFileFilter; }
            set { _photoFileFilter = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("打开的图片变更后触发")]
        public event EventHandler PhotoFilePathChanged
        {
            add { _photoFilePathChanged += value; }
            remove { _photoFilePathChanged -= value; }
        }
        private event EventHandler _photoFilePathChanged;
    }
}