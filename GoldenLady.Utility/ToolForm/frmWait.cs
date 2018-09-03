using System;
using System.Windows.Forms;

namespace GoldenLady.Utility.ToolForm
{
    /// <summary>
    /// 等待窗体
    /// </summary>
    public partial class frmWait : Form
    {
        private DateTime _startTime;
        private readonly Timer timer = new Timer
        {
            Enabled = false,
            Interval = 100
        };
        private int _hintTextIndex;
        private string _waitMessage = @"正在处理";
        private int _timeOut = 60;
        private bool _isTimeOut;
        private static readonly string[] HintTexts =
        {
            @"请稍候",
            @"请稍候 /",
            @"请稍候 .—",
            @"请稍候 . \",
            @"请稍候 . |",
            @"请稍候 . /",
            @"请稍候 . .—",
            @"请稍候 . . \",
            @"请稍候 . . |",
            @"请稍候 . . /",
            @"请稍候 . . .—",
            @"请稍候 . . . \",
            @"请稍候 . . . |",
            @"请稍候 . . . /",
            @"请稍候 . . . .—",
            @"请稍候 . . . . \",
            @"请稍候 . . . . |",
            @"请稍候 . . . . /",
            @"请稍候 . . . . .—",
            @"请稍候 . . . . . \",
            @"请稍候 . . . . . |",
            @"请稍候 . . . . . /",
            @"请稍候 . . . . . .—",
            @"请稍候 . . . . . . \",
            @"请稍候 . . . . . . |",
            @"请稍候 . . . . . . /",
            @"请稍候 . . . . . . .—",
            @"请稍候 . . . . . . . \",
            @"请稍候 . . . . . . . |",
            @"请稍候 . . . . . . . /",
            @"请稍候 . . . . . . . .—",
            @"请稍候 . . . . . . . . \",
            @"请稍候 . . . . . . . . |",
            @"请稍候 . . . . . . . . /",
        };

        /// <summary>
        /// 提示信息
        /// </summary>
        public string WaitMessage
        {
            get { return _waitMessage; }
            set
            {
                _waitMessage = value;
                OnWaitMessageChanged();
            }
        }
        /// <summary>
        /// 经过多少秒判定为超时，超时后允许用户点击关闭按钮，默认60秒
        /// </summary>
        public int TimeOut
        {
            get { return _timeOut; }
            set { _timeOut = value; }
        }
        /// <summary>
        /// 当等待窗口关闭时，需要执行的委托
        /// </summary>
        public Action WhenClosed { get; set; }
        private int HintTextIndex
        {
            get { return _hintTextIndex; }
            set
            {
                _hintTextIndex = value;
                OnHintTextIndexChanged();
            }
        }
        private bool IsTimeOut
        {
            get { return _isTimeOut; }
            set
            {
                _isTimeOut = value;
                OnTimeOut();
            }
        }
        private void OnTimeOut()
        {
            ControlBox = IsTimeOut;
        }

        private void OnWaitMessageChanged()
        {
            lblMessage.Text = WaitMessage;
        }
        private void OnHintTextIndexChanged()
        {
            lblWait.Text = HintTexts[HintTextIndex];
        }

        public frmWait()
        {
            InitializeComponent();
            BindingEvents();
        }
        private void BindingEvents()
        {
            //
            // timer
            //
            timer.Tick += (sender, args) =>
            {
                HintTextIndex = (HintTextIndex + 1) % HintTexts.Length;
                if(!IsTimeOut)
                {
                    TimeSpan span = DateTime.Now - _startTime;
                    if(span.TotalSeconds > TimeOut)
                    {
                        IsTimeOut = true;
                    }
                }
            };
            //
            // this
            //
            Shown += (sender, args) =>
            {
                _startTime = DateTime.Now;
                timer.Start();
            };
            Closed += (sender, args) =>
            {
                if(timer != null && timer.Enabled)
                {
                    timer.Stop();
                    timer.Dispose();
                }
                if(WhenClosed != null)
                {
                    WhenClosed.Invoke();
                }
            };
        }
    }
}