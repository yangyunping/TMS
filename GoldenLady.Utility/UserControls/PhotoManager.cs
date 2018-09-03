using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Utility.DataStructure;

namespace GoldenLady.Utility.UserControls
{
    /// <summary>
    /// 照片管理器控件
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public partial class PhotoManager : UserControl
    {
        public readonly ListViewImageItems Photos = new ListViewImageItems();
        private int[] _selectedPhotoIndices ={};

        /// <summary>
        /// 从小图到大图的文件路径映射规则
        /// </summary>
        public Func<string, string> LargePhotoMappingRule { get; set; }
        public int[] SelectedPhotoIndices
        {
            get { return _selectedPhotoIndices; }
            set
            {
                _selectedPhotoIndices = value;
                OnSelectedPhotoIndicesChanged();
            }
        }
        public IEnumerable<string> SelectedPhotoFilePaths
        {
            get { return null == SelectedPhotoIndices ? new List<string>() : SelectedPhotoIndices.Select(index => Photos.Paths[index]); }
        }

        public void OnSelectedPhotoIndicesChanged()
        {
            bool hasSelection = SelectedPhotoIndices.Length > 0;
            photoViewer.CurrentIndex = hasSelection ? SelectedPhotoIndices[0] : -1;
        }

        public PhotoManager()
        {
            InitializeComponent();
            Init();
            BindEvents();
        }

        private void Init()
        {
            lvwPhoto.LargeImageList = Photos.Images;
        }
        private void BindEvents()
        {
            //
            // lvwPhoto
            //
            lvwPhoto.SelectedIndexChanged += (sender, args) => SelectedPhotoIndices = ((ListView)sender).SelectedIndices.Cast<int>().ToArray();
            //
            // photoViewer
            //
            photoViewer.PrevButtonClick += (sender, args) =>
            {
                int idx = lvwPhoto.SelectedIndices[0];
                lvwPhoto.SelectedIndices.Clear();
                lvwPhoto.SelectedIndices.Add(idx - 1);
            };
            photoViewer.NextButtonClick += (sender, args) =>
            {
                int idx = lvwPhoto.SelectedIndices[0];
                lvwPhoto.SelectedIndices.Clear();
                lvwPhoto.SelectedIndices.Add(idx + 1);
            };
        }
        /// <summary>
        /// 刷新控件
        /// </summary>
        public void UpdatePhotos()
        {
            Cursor.Current = Cursors.WaitCursor;
            lvwPhoto.BeginUpdate();
            lvwPhoto.Items.Clear();
            lvwPhoto.Items.AddRange(Photos.Items.ToArray());
            lvwPhoto.EndUpdate();
            photoViewer.Clear();
            photoViewer.AddRange(LargePhotoMappingRule == null ? Photos.Paths : from path in Photos.Paths select LargePhotoMappingRule(path));
            Cursor.Current = Cursors.Default;
            SelectedPhotoIndices = lvwPhoto.SelectedIndices.Cast<int>().ToArray();
        }
        /// <summary>
        /// 移除选中的照片
        /// </summary>
        public void RemoveSelected()
        {
            Photos.RemoveRange(SelectedPhotoIndices);
            UpdatePhotos();
        }
        /// <summary>
        /// 添加新的照片
        /// </summary>
        /// <param name="photoFiles">照片文件</param>
        public void AddPhotos(IEnumerable<string> photoFiles)
        {
            Photos.AddRange(photoFiles);
            UpdatePhotos();
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义事件"), Description("点击添加照片按钮后触发")]
        public event EventHandler AddPhotoButtonClick
        {
            add { btnAddPhoto.Click += value; }
            remove { btnAddPhoto.Click -= value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义事件"), Description("点击删除当前照片按钮后触发")]
        public event EventHandler DeletePhotoButtonClick
        {
            add { btnDeletePhoto.Click += value; }
            remove { btnDeletePhoto.Click -= value; }
        }
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义事件"), Description("点击复制当前照片按钮后触发")]
        public event EventHandler CopyPhotoButtonClick
        {
            add { btnCopyPhoto.Click += value; }
            remove { btnCopyPhoto.Click -= value; }
        }
        /// <summary>
        /// 用于显示在左边区域的缩略图尺寸，像素为单位
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义属性"), Description("用于显示在左边区域的缩略图尺寸，像素为单位")]
        public Size ThumbSize
        {
            get { return Photos.Images.ImageSize; }
            set { Photos.Images.ImageSize = value; }
        }
    }
}