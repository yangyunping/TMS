using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Standard;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    /// <summary>
    /// 添加场馆窗口
    /// LiuHaiyang
    /// 2017.4.29
    /// </summary>
    public partial class FrmNewVenue : FrmNew
    {
        private IEnumerable<Department> _departments;

        private IEnumerable<Department> Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                OnDepartmentsChanged();
            }
        }

        private void OnDepartmentsChanged()
        {
            Cursor.Current = Cursors.WaitCursor;
            tvwDepartment.BeginUpdate();
            tvwDepartment.Nodes.Clear();
            if(null != Departments)
            {
                GetChildNodes(tvwDepartment.Nodes.Add("G01", "金夫人集团"));
            }
            tvwDepartment.EndUpdate();
            Cursor.Current = Cursors.Default;
        }
        protected override void OnObjectToNewChanged()
        {
            base.OnObjectToNewChanged();
            Venue venue = (Venue)ObjectToNew;
            txtDepartmentNo.Text = null == venue ? null : venue.DepartmentNo;
        }

        public FrmNewVenue()
        {
            InitializeComponent();
            BindEvents();
        }
        private new void BindEvents()
        {
            //
            // tvwDepartment
            //
            tvwDepartment.AfterSelect += (sender, args) =>
            {
                Venue venue = (Venue)ObjectToNew;
                venue.DepartmentNo = args.Node == null ? null : args.Node.Name;
                venue.Name = args.Node == null ? null : args.Node.Text;
                OnObjectToNewChanged();
            };
            //
            // this
            //
            Shown += (sender, args) =>
            {
                tvwDepartment.Focus();
            };
        }
        protected override void InitData()
        {
            OpenWaitFrm();
            base.InitData();
            ObjectToNew = new Venue();
            Departments = ErpService.CompanyManagement.GetDepartments();
            CloseWaitFrm();
        }
        private void GetChildNodes(TreeNode parent)
        {
            foreach(Department department in Departments.Where(d => d.ParentDepartmentNo == parent.Name))
            {
                GetChildNodes(parent.Nodes.Add(department.No, department.Name));
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Venue venue = (Venue)ObjectToNew;

            // 场馆信息是否完整
            if(string.IsNullOrWhiteSpace(venue.DepartmentNo))
            {
                MessageBoxEx.Error(@"请选择一个专业部门的编号，作为场馆关联的部门编号！");
                tvwDepartment.Focus();
                return;
            }
            if(string.IsNullOrWhiteSpace(venue.Name))
            {
                MessageBoxEx.Error(@"请填写场馆名称！");
                txtObjectName.Highlight();
                return;
            }
            // 检测场馆是否已存在
            if(DressManager.IsVenueExists(venue))
            {
                MessageBoxEx.Error(string.Format(@"关联部门编号为'{0}'或名称为'{1}'的场馆已经存在！", venue.DepartmentNo, venue.Name));
                tvwDepartment.Focus();
                return;
            }

            try
            {
                DressManager.NewVenue(venue);
                OnSaveComplete();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
                OnSaveFailed();
            }
        }
    }
}