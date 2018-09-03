using System;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    internal partial class FrmVenue : FrmManage
    {
        protected override void OnSelectedObjectChanged()
        {
            base.OnSelectedObjectChanged();
            Venue venue = (Venue)SelectedObject;
            txtDepartmentNo.Text = null == venue ? null : venue.DepartmentNo;
            btnManageTheme.Enabled = null != venue;
        }

        public FrmVenue()
        {
            InitializeComponent();
        }

        protected override void InitData()
        {
            //OpenWaitFrm();
            LoadVenues();
            //CloseWaitFrm();
        }
        protected override void RefreshData()
        {
            //OpenWaitFrm();
            LoadVenues();
            //CloseWaitFrm();
        }
        private void LoadVenues()
        {
            Objects = DressManager.GetVenues().Cast<ManagedObject>().ToList();
        }
        private void ProcDelete()
        {
            //try
            //{
            //    UpdateWaitMessage(@"删除数据库记录及对应文件夹");
            //    DressManager.DeleteObject(SelectedObject);

            //    UpdateWaitMessage(@"加载数据");
            //    Invoke(new MethodInvoker(OnDeleteComplete));
            //}
            //catch(Exception ex)
            //{
            //    Invoke(new MethodInvoker(() =>
            //    {
            //        CloseWaitFrm();
            //        MessageBoxEx.Info(string.Format(@"删除场馆失败！{0}{1}", Environment.NewLine, ex.Message));
            //        Close(); // 关闭窗口防止发生其他意外
            //    }));
            //}
        }

        private void btnNewObject_Click(object sender, EventArgs e)
        {
            new FrmNewVenue().ShowDialog();
            RefreshData();
        }
        private void btnSaveObject_Click(object sender, EventArgs e)
        {
            Venue SelectedVenue = (Venue)SelectedObject;

            // 场馆信息是否完整
            if(string.IsNullOrWhiteSpace(SelectedVenue.Name))
            {
                MessageBoxEx.Error(@"请填写场馆名称！");
                txtObjectName.Highlight();
                return;
            }

            try
            {
                DressManager.UpdateVenue(SelectedVenue);
                OnSaveComplete();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
                OnSaveFailed();
            }
        }
        private void btnDeleteObject_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Error(@"尚未实现！");

            //            // 删除确认
            //            if(DialogResult.OK != MessageBoxEx.Confirm(@"请注意！
            //删除场馆后，从属于该场馆的所有风格和场景极其照片也将会被删除！
            //建议使用“停用”功能。
            //确定要删除该场馆吗？"))
            //            {
            //                return;
            //            }

            //            // 开始删除
            //    StartBackWork(ProcDelete);
        }

        private void btnManageTheme_Click(object sender, EventArgs e)
        {
            FrmTheme frmTheme = new FrmTheme((Venue) SelectedObject) {Name = btnManageTheme.Text, Text = btnManageTheme.Text,Dock = DockStyle.Fill,AutoScaleMode = AutoScaleMode.None};
            FrmDressBase frmDressBase = new FrmDressBase() { Text = btnManageTheme.Text };
            frmDressBase.Controls.Add(frmTheme);
            frmDressBase.ShowDialog();
        }
    }
}