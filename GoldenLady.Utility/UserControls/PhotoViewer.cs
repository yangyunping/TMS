using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GoldenLady.Utility.DataStructure;

namespace GoldenLady.Utility.UserControls
{
    /// <summary>
    /// 照片浏览器控件
    /// Designed by: LiuHaiyang
    /// 2017.4.12
    /// </summary>
    public partial class PhotoViewer : UserControl
    {
        private int _pageButtonWidth = 80;
        private readonly CachePool<string, Image> _photoCaches = new CachePool<string, Image>();
        private readonly List<string> _photoFiles = new List<string>();
        private int _currentIndex = -1;

        /// <summary>
        /// 当前图片索引
        /// </summary>
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                _currentIndex = value;
                OnCurrentIndexChanged();
            }
        }
        /// <summary>
        /// 照片总数量
        /// </summary>
        public int PhotoCount
        {
            get { return _photoFiles.Count; }
        }
        /// <summary>
        /// 翻页按钮宽度
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义属性"), Description("翻页按钮宽度")]
        public int PageButtonWidth
        {
            get { return _pageButtonWidth; }
            set
            {
                _pageButtonWidth = value;
                OnPageButtonWidthChanged();
            }
        }

        private void OnPageButtonWidthChanged()
        {
            btnPrev.Width = btnNext.Width = PageButtonWidth;
        }
        private void OnCurrentIndexChanged()
        {
            if(-1 == CurrentIndex)
            {
                pic.Image = null;
                lblName.Text = null;
                lblPage.Text = @"0 / 0";
                btnPrev.Enabled = btnNext.Enabled = false;
            }
            else
            {
                string filePath = _photoFiles[CurrentIndex];
                Image img = _photoCaches[filePath]; // 尝试从缓存池中获取图片
                if(null == img) // 缓存池中没有
                {
                    img = FileTool.ReadImageFile(filePath);
                    _photoCaches.Add(filePath, img); // 添加该图片到缓存池
                }
                pic.Image = img;
                lblName.Text = Path.GetFileName(filePath);
                lblPage.Text = string.Format(@"{0} / {1}", CurrentIndex + 1, PhotoCount);
                btnPrev.Enabled = true;
                btnNext.Enabled = true;
                if(CurrentIndex == 0)
                {
                    btnPrev.Enabled = false;
                }
                if(CurrentIndex == PhotoCount - 1)
                {
                    btnNext.Enabled = false;
                }
            }
            pnlMain.Invalidate(true);
            if(null != _currentIndexChanged)
            {
                _currentIndexChanged(this, EventArgs.Empty);
            }
        }

        public PhotoViewer()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            btnPrev.UserDraw = (e, block) =>
            {
                SizeF size = new SizeF(block.Size);
                Pen pen = new Pen(new SolidBrush(Color.FromArgb(block.CurrentAlpha + 100, Color.Aquamarine)), 3.0f);
                e.Graphics.DrawLine(pen, size.Width * 3.0f / 4.0f, size.Height / 4.0f, size.Width / 4.0f, size.Height / 2.0f);
                e.Graphics.DrawLine(pen, size.Width * 3.0f / 4.0f, size.Height * 3.0f / 4.0f, size.Width / 4.0f, size.Height / 2.0f);
            };
            btnNext.UserDraw = (e, block) =>
            {
                SizeF size = new SizeF(block.Size);
                Pen pen = new Pen(new SolidBrush(Color.FromArgb(block.CurrentAlpha + 100, Color.Aquamarine)), 3.0f);
                e.Graphics.DrawLine(pen, size.Width / 4.0f, size.Height / 4.0f, size.Width * 3.0f / 4.0f, size.Height / 2.0f);
                e.Graphics.DrawLine(pen, size.Width / 4.0f, size.Height * 3.0f / 4.0f, size.Width * 3.0f / 4.0f, size.Height / 2.0f);
            };
        }
        /// <summary>
        /// 添加照片
        /// </summary>
        /// <param name="photoFile">照片文件路径</param>
        public void Add(string photoFile)
        {
            _photoFiles.Add(photoFile);
            Update();
        }
        /// <summary>
        /// 批量添加照片
        /// </summary>
        /// <param name="photoFiles">照片文件路径</param>
        public void AddRange(IEnumerable<string> photoFiles)
        {
            _photoFiles.AddRange(photoFiles);
            Update();
        }
        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            _photoFiles.Clear();
            CurrentIndex = -1;
        }
        /// <summary>
        /// 删除照片
        /// </summary>
        /// <param name="idx">照片索引</param>
        public void RemoveAt(int idx)
        {
            _photoFiles.RemoveAt(idx);
            if(CurrentIndex == _photoFiles.Count)
            {
                CurrentIndex = -1;
            }
            else
            {
                Update();
            }
        }
        /// <summary>
        /// 删除当前照片
        /// </summary>
        public void RemoveCurrent()
        {
            RemoveAt(CurrentIndex);
        }
        /// <summary>
        /// 向前翻页
        /// </summary>
        public void MovePrev()
        {
            CurrentIndex -= 1;
        }
        /// <summary>
        /// 向后翻页
        /// </summary>
        public void MoveNext()
        {
            CurrentIndex += 1;
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public new void Update()
        {
            OnCurrentIndexChanged();
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("当前的图片索引更改后触发")]
        public event EventHandler CurrentIndexChanged
        {
            add { _currentIndexChanged += value; }
            remove { _currentIndexChanged -= value; }
        }
        private event EventHandler _currentIndexChanged;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("点击向前翻页按钮后触发")]
        public event EventHandler PrevButtonClick
        {
            add { btnPrev.Click += value; }
            remove { btnPrev.Click -= value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("点击向后翻页按钮后触发")]
        public event EventHandler NextButtonClick
        {
            add { btnNext.Click += value; }
            remove { btnNext.Click -= value; }
        }
    }
}