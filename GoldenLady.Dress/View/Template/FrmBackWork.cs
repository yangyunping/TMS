using System;
using System.Threading.Tasks;
using GoldenLady.Utility.ToolForm;

namespace GoldenLady.Dress.View.Template
{
    /// <summary>
    /// 带有后台工作的窗体模版
    /// Designed by : LiuHaiyang
    /// 2017.4.6
    /// </summary>
    public partial class FrmBackWork : FrmDressBase
    {
        private delegate void UpdateWaitMessageInvoker(string message);

        private UpdateWaitMessageInvoker _invoker;
        protected frmWait _frmWait;

        protected virtual void OnUpdateWaitMessage(string message)
        {
            _frmWait.WaitMessage = message;
        }

        public FrmBackWork()
        {
            InitializeComponent();
        }

        protected virtual void CloseWaitFrm()
        {
            SafeCloseWaitFrm();
            pnlMain.Visible = true;
            pnlWait.Visible = false;
        }
        protected virtual void SafeCloseWaitFrm()
        {
            if(_frmWait != null && !_frmWait.Disposing && !_frmWait.IsDisposed)
            {
                _frmWait.Close();
            }
            _frmWait = null;
        }
        protected virtual void OpenWaitFrm()
        {
            pnlMain.Visible = false;
            pnlWait.Visible = true;
            SafeCloseWaitFrm();
            _frmWait = new frmWait
            {
                TimeOut = 9999
            };
            _frmWait.Show();
        }
        protected virtual void UpdateWaitMessage(string message)
        {
            Invoke(_invoker ?? (_invoker = OnUpdateWaitMessage), message);
        }
        protected virtual void StartBackWork(Action action)
        {
            OpenWaitFrm();
            Task.Factory.StartNew(action);
        }
        protected virtual void StartBackWork(Action<object> action, object arg)
        {
            OpenWaitFrm();
            Task.Factory.StartNew(action, arg);
        }
    }
}