using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using GoldenLady.Global;
using GoldenLadyWS;

namespace GoldenLady.Dress
{
    public partial class frmEmployee : Form
    {
        private static string sEmployeePhoto = "";
        private bool _changeEmployeePhoto = false;
        private string sOldCardNO = "";
        private bool isChange = false;
        private string oldEmployeeNO2;
        Service ErpWs = new Service();

        public frmEmployee()
        {
            InitializeComponent();
            InitControl();
            InitSystemPower();
        }

        int iType;
        public frmEmployee(string sDepartmentNOorEmployeeNO, int iType)
        {
            InitializeComponent();
            InitControl();
            InitSystemPower();
            this.iType = iType;
            if (iType == 0)
            {
                SearchEmployeeByEmployeeNO(sDepartmentNOorEmployeeNO);
                SearchUserPower(sDepartmentNOorEmployeeNO);
            }
            else
            {
                this.txtDepartmentNO.Text = sDepartmentNOorEmployeeNO;
                this.cmbDepartment.SelectedValue = sDepartmentNOorEmployeeNO;
                this.cmbDepartment.Enabled = false;
            }
        }

        private void SearchEmployeeByEmployeeNO(string sEmployeeNO)
        {
            try
            {
                DataSet myds = new DataSet();
                myds = ErpWs.SearchEmployeeByEmployeeNO_old(sEmployeeNO);
                if (myds.Tables[0].Rows.Count == 0)
                    return;
                txtDepartmentNO.Text = myds.Tables[0].Rows[0]["DepartmentNO"].ToString();
                cmbDepartment.SelectedValue = myds.Tables[0].Rows[0]["DepartmentNO"].ToString();
                txtEmployeeNO.Text = myds.Tables[0].Rows[0]["EmployeeNO"].ToString();
                //txtEmployeeNO2.Text = myds.Tables[0].Rows[0]["EmployeeNO2"].ToString();
                oldEmployeeNO2 = txtEmployeeNO2.Text = myds.Tables[0].Rows[0]["EmployeeNO2"].ToString();//Edit by Caijinsong
                sOldCardNO = txtCardNO.Text = myds.Tables[0].Rows[0]["CardNO"].ToString();
                txtEmployeePassword.Text = myds.Tables[0].Rows[0]["EmployeePassword"].ToString();
                txtEmployeeName.Text = myds.Tables[0].Rows[0]["EmployeeName"].ToString();
                txtEmployeeDescribe.Text = myds.Tables[0].Rows[0]["EmployeeDescribe"].ToString();
                cmbEmployeeDuty.SelectedValue = myds.Tables[0].Rows[0]["EmployeeDuty"].ToString();
                cmbEmployeeLevel.SelectedValue = myds.Tables[0].Rows[0]["EmployeeLevel"].ToString();
                cmbEmployeeSex.SelectedValue = myds.Tables[0].Rows[0]["EmployeeSex"].ToString();
                dtpEmployeeBirthday.Value = DateTime.Parse(myds.Tables[0].Rows[0]["EmployeeBirthday"].ToString());
                chbIsDelete.Checked = bool.Parse(myds.Tables[0].Rows[0]["IsDelete"].ToString());
                isChange = bool.Parse((myds.Tables[0].Rows[0]["isChange"].ToString()));
                //员工的联系电话
                txtEmployeePhone.Text = myds.Tables[0].Rows[0]["EmployeePhone"].ToString();
                //读取照片
                try
                {
                    MemoryStream buf = new MemoryStream((byte[])myds.Tables[0].Rows[0]["EmployeePhoto"]);
                    Image image = Image.FromStream(buf, true);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            catch { }
        }

        private void SearchUserPower(string sEmployeeNO)
        {
            DataRow[] dr = ErpWs.SearchUserPower(sEmployeeNO).Tables[0].Select();

            for (int a = 0; a < dr.Length; a++)
            {
                foreach(TreeNode tn in trwPowers.Nodes)
                {
                    foreach (TreeNode tr in tn.Nodes)
                    {
                        if (tr.Name == dr[a]["PowerID"].ToString())
                        {
                            tr.Checked = true;
                        }
                    }
                }              
            }
        }

        private void InitControl()
        {
            DataSet dsConfig = ErpWs.SearchConfig("");
            cmbEmployeeSex.DataSource = dsConfig.Tables[0].Select("ConfigType='性别'").CopyToDataTable();
            cmbEmployeeSex.DisplayMember = "ConfigValue";
            cmbEmployeeSex.ValueMember = "ConfigNO";

            //cmbEmployeeLevel.DataSource = Program.RowToTable(dsConfig.Tables[0].Select("ConfigType='级别'"), dsConfig);

            #region add by CaiJinsong 20121025 增加级别未选择选项
            cmbEmployeeLevel.DataSource = null;
            DataTable dtEmployeeLevel = new DataTable();
            dtEmployeeLevel.Columns.Add("ConfigValue");
            dtEmployeeLevel.Columns.Add("ConfigNO");
            dtEmployeeLevel.Rows.Add("-未选择-", "");
            DataTable dtLevelTmp = dsConfig.Tables[0].Select("ConfigType='级别'").CopyToDataTable();
            foreach (DataRow dr in dtLevelTmp.Rows)
            {
                dtEmployeeLevel.Rows.Add(dr["ConfigValue"] as String, dr["ConfigNO"] as String);
            }
            #endregion

            cmbEmployeeLevel.DataSource = dtEmployeeLevel;
            cmbEmployeeLevel.DisplayMember = "ConfigValue";
            cmbEmployeeLevel.ValueMember = "ConfigNO";

            #region add by wujianbo 20120813 增加职务未选择选项
            cmbEmployeeDuty.DataSource = null;
            DataTable dtEmployeeDuty = new DataTable();
            dtEmployeeDuty.Columns.Add("ConfigValue");
            dtEmployeeDuty.Columns.Add("ConfigNO");
            dtEmployeeDuty.Rows.Add("-未选择-", "");
            DataTable dtDutyTemp = dsConfig.Tables[0].Select("ConfigType='职务'").CopyToDataTable();
            foreach (DataRow dr in dtDutyTemp.Rows)
            {
                dtEmployeeDuty.Rows.Add(dr["ConfigValue"].ToString(), dr["ConfigNO"].ToString());
            }
            #endregion

            //cmbEmployeeDuty.DataSource = Program.RowToTable(dsConfig.Tables[0].Select("ConfigType='职务'"), dsConfig);//note by wujianbo 20120813
            cmbEmployeeDuty.DataSource = dtEmployeeDuty;
            cmbEmployeeDuty.DisplayMember = "ConfigValue";
            cmbEmployeeDuty.ValueMember = "ConfigNO";
            dsConfig.Dispose();

            DataSet myds = ErpWs.SearchDepartment("");
            cmbDepartment.DataSource = myds.Tables[0];
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "DepartmentNO";
            myds.Dispose();

            lbCreate.Text = Information.CurrentUser.EmployeeNO;
            lbCreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }

        # region  初始化系统权限
        private void InitSystemPower()
        {
            DataTable dt = ErpWs.SearchSystemPower().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                trwPowers.Nodes.Add(dt.Rows[i]["ID"].ToString(), dt.Rows[i]["Name"].ToString());
            }
           
            //DataRow[] drCash = dt.Select("ID >0 and ID <99");
            //DataRow[] drOrder = dt.Select("ID >500 and ID <599");
            //DataRow[] drInvite = dt.Select("ID >1000 and ID <1099");
            //DataRow[] drShoot = dt.Select(" ID >1500 and ID <1599");
            //DataRow[] drDesign = dt.Select("ID >2000 and ID <2099");
            //DataRow[] drChoose = dt.Select("ID >2500 and ID <2599");
            //DataRow[] drLook = dt.Select("ID >3000 and ID <3099");
            //DataRow[] drGetGoods = dt.Select("ID >3500 and ID <3599");
            //DataRow[] drFinish = dt.Select("ID >4000 and ID <4099");
            //DataRow[] drSMS = dt.Select("ID >4500 and ID <4599");
            //DataRow[] drReport = dt.Select("ID >5000 and ID <5099");
            //DataRow[] drSystem = dt.Select("ID >5500 and ID <5599");
            //DataRow[] drEmployee= dt.Select("ID >6000 and ID <6099");
            //DataRow[] drSuit = dt.Select("ID >6500 and ID <6599");
            //DataRow[] drDress = dt.Select("ID >7000 and ID <7099");
            //DataRow[] drCustomerService = dt.Select("ID >7500 and ID <7599");

            //TreeNode trCash = trwPowers.Nodes.Add("收银");
            //for (int i = 0; i < drCash.Length; i++ ) 
            //{
            //    trCash.Nodes.Add(drCash[i]["ID"].ToString(),drCash[i]["Name"].ToString());
            //}

            //TreeNode trOrder = trwPowers.Nodes.Add("a","接单");
            //for (int i = 0; i < drOrder.Length; i++)
            //{
            //    trOrder.Nodes.Add(drOrder[i]["ID"].ToString(),drOrder[i]["Name"].ToString());
            //}
            //TreeNode trInvite = trwPowers.Nodes.Add("b","邀约");
            //for (int i = 0; i < drInvite.Length; i++)
            //{
            //    trInvite.Nodes.Add(drInvite[i]["ID"].ToString(), drInvite[i]["Name"].ToString());
            //}
            //TreeNode trShoot = trwPowers.Nodes.Add("c","摄影");
            //for (int i = 0; i < drShoot.Length; i++)
            //{
            //    trShoot.Nodes.Add(drShoot[i]["ID"].ToString(),drShoot[i]["Name"].ToString());
            //}
            //TreeNode trDesign = trwPowers.Nodes.Add("d","设计");
            //for (int i = 0; i < drDesign.Length; i++)
            //{
            //    trDesign.Nodes.Add(drDesign[i]["ID"].ToString(),drDesign[i]["Name"].ToString());
            //}
            //TreeNode trChoose = trwPowers.Nodes.Add("n", "看样");
            //for (int i = 0; i < drChoose.Length; i++)
            //{
            //    trChoose.Nodes.Add(drChoose[i]["ID"].ToString(), drChoose[i]["Name"].ToString());
            //}
            //TreeNode trLook = trwPowers.Nodes.Add("e","看版");
            //for (int i = 0; i < drLook.Length; i++)
            //{
            //    trLook.Nodes.Add(drLook[i]["ID"].ToString(),drLook[i]["Name"].ToString());
            //}
            //TreeNode trGetGoods = trwPowers.Nodes.Add("f","取件");
            //for (int i = 0; i < drGetGoods.Length; i++)
            //{
            //    trGetGoods.Nodes.Add(drGetGoods[i]["ID"].ToString(),drGetGoods[i]["Name"].ToString());
            //}
            //TreeNode trFinish = trwPowers.Nodes.Add("g","归档");
            //for (int i = 0; i < drFinish.Length; i++)
            //{
            //    trFinish.Nodes.Add(drFinish[i]["ID"].ToString(),drFinish[i]["Name"].ToString());
            //}
            //TreeNode trSMS = trwPowers.Nodes.Add("h","短信");
            //for (int i = 0; i < drSMS.Length; i++)
            //{
            //    trSMS.Nodes.Add(drSMS[i]["ID"].ToString(),drSMS[i]["Name"].ToString());
            //}
            //TreeNode trReport = trwPowers.Nodes.Add("i","报表");
            //for (int i = 0; i < drReport.Length; i++)
            //{
            //    trReport.Nodes.Add(drReport[i]["ID"].ToString(),drReport[i]["Name"].ToString());
            //}
            //TreeNode trSystem = trwPowers.Nodes.Add("j","系统");
            //for (int i = 0; i < drSystem.Length; i++)
            //{
            //    trSystem.Nodes.Add(drSystem[i]["ID"].ToString(),drSystem[i]["Name"].ToString());
            //}
            //TreeNode trEmployee = trwPowers.Nodes.Add("o", "人资");
            //for (int i = 0; i < drEmployee.Length; i++)
            //{
            //    trEmployee.Nodes.Add(drEmployee[i]["ID"].ToString(), drEmployee[i]["Name"].ToString());
            //}
            //TreeNode trSuit = trwPowers.Nodes.Add("k","套系管理");
            //for (int i = 0; i < drSuit.Length; i++)
            //{
            //    trSuit.Nodes.Add(drSuit[i]["ID"].ToString(),drSuit[i]["Name"].ToString());
            //}
            //TreeNode trDress = trwPowers.Nodes.Add("L","礼服");
            //for (int i = 0; i < drDress.Length; i++)
            //{
            //    trDress.Nodes.Add(drDress[i]["ID"].ToString(),drDress[i]["Name"].ToString());
            //}
            //TreeNode trCustomerService = trwPowers.Nodes.Add("m","客服");
            //for (int i = 0; i < drCustomerService.Length; i++)
            //{
            //    trCustomerService.Nodes.Add(drCustomerService[i]["ID"].ToString(),drCustomerService[i]["Name"].ToString());
            //}
        }

        # endregion

        private void ClearControl()
        {
            txtEmployeeNO.Text = "";
            txtEmployeeNO2.Text = "";
            txtEmployeePassword.Text = "";
            txtEmployeeName.Text = "";
            txtEmployeeDescribe.Text = "";
            cmbEmployeeSex.SelectedIndex = 0;
            cmbEmployeeDuty.SelectedIndex = cmbEmployeeDuty.Items.Count - 1;
            cmbEmployeeLevel.SelectedIndex = cmbEmployeeLevel.Items.Count - 1;
            dtpEmployeeBirthday.Value = DateTime.Now;
            chbIsDelete.Checked = false;
            sEmployeePhoto = "";
            lbCreate.Text = Information.CurrentUser.EmployeeNO;
            lbCreateDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            txtCardNO.Text = String.Empty;
            txtEmployeePhone.Text = "";
        }

        private void lbCreate_TextChanged(object sender, EventArgs e)
        {
            if (lbCreate.Text.Trim() == "")
            {
                lbCreate.Visible = false;
                lbCreateCaption.Visible = false;
            }
            else
            {
                lbCreate.Visible = true;
                lbCreateCaption.Visible = true;
            }
        }

        private void lbCreateDate_TextChanged(object sender, EventArgs e)
        {
            if (lbCreateDate.Text.Trim() == "")
            {
                lbCreateDate.Visible = false;
                lbCreateDateCaption.Visible = false;
            }
            else
            {
                lbCreateDate.Visible = true;
                lbCreateDateCaption.Visible = true;
            }
        }

        private bool SaveEmployee()
        {
            if (txtEmployeeNO.Text.ToString().Trim() == "")
            {
                MessageBox.Show(@"员工编号不能为空!");
                txtEmployeeNO.Focus();
                return false;
            }
            if (txtEmployeeNO2.Text.ToString().Trim() == "")
            {
                MessageBox.Show(@"(二代)员工编号不能为空!");
                txtEmployeeNO2.Focus();
                return false;
            }
            ////////////////////////////////////////////////////////////////////////// Add by Caijinsong 2013-3-16
            try
            {
                if ((iType == 1 && ErpWs.VerifyEmployeeNO2(txtEmployeeNO2.Text.ToString().Trim())) || (iType == 0 && oldEmployeeNO2 != txtEmployeeNO2.Text.Trim() &&  ErpWs.VerifyEmployeeNO2(txtEmployeeNO2.Text.ToString().Trim())))
                {
                    MessageBox.Show(@"二代员工编号重复", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //////////////////////////////////////////////////////////////////////////
            if (txtEmployeeName.Text.ToString().Trim() == "")
            {
                MessageBox.Show(@"员工姓名不能为空!");
                txtEmployeeName.Focus();
                return false;
            }

            //员工的联系电话 20150629 wudongxue
            if (txtEmployeePhone.Text.Trim().Length != 11 && txtEmployeePhone.Text.Trim() != "")
            {
                MessageBox.Show(@"请输入有效的电话号码");
                txtEmployeePhone.Focus();
                return false;
            }

            if ("-未选择-".Equals(cmbEmployeeLevel.Text.Trim()))
            {
                MessageBox.Show(@"请选择员工级别！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbEmployeeLevel.Focus();
                return false;
            }

            //add by wujianbo 20120813 未选择员工职务不能保存
            if (cmbEmployeeDuty.SelectedValue.ToString() == "")
            {
                MessageBox.Show(@"请选择员工职务!");
                cmbEmployeeDuty.Focus();
                return false;
            }

            string sIsDelete = "0";
            if (chbIsDelete.Checked)
                sIsDelete = "1";

            TreeNode tr = new TreeNode();
            foreach(TreeNode tn in trwPowers.Nodes)
            {
                foreach(TreeNode trn in tn.Nodes)
                {
                    if(trn.Checked)
                    {
                        tr.Nodes.Add(trn.Name,"");
                    }    
                }
            }
            int rc = tr.Nodes.Count;
            string[] sUserPower = new string[rc];
            for (int i = 0; i < rc; i++)
            {
                sUserPower[i] = tr.Nodes[i].Name.ToString();
            }
            if (ErpWs.SaveEmployee(cmbDepartment.SelectedValue.ToString(), txtEmployeeNO.Text.Trim(), txtEmployeeNO2.Text.Trim(), txtEmployeePassword.Text.ToString(), txtEmployeeName.Text.ToString(), txtCardNO.Text.ToString(), cmbEmployeeSex.SelectedValue.ToString(), dtpEmployeeBirthday.Value.Date.ToString(), cmbEmployeeLevel.SelectedValue.ToString(), cmbEmployeeDuty.SelectedValue.ToString(), txtEmployeeDescribe.Text.ToString(), lbCreate.Text.ToString(), lbCreateDate.Text.ToString(), sIsDelete, sUserPower, isChange, txtEmployeePhone.Text.Trim()))
            {
                MessageBox.Show(@"员工信息保存成功!");
                return true;
            }
            else
            {
                MessageBox.Show(@"员工信息保存失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveEmployee())
            {
                ClearControl();
                txtEmployeeNO.Focus();
            }
        }

        private void btnSaveAndQuit_Click(object sender, EventArgs e)
        {
            if (SaveEmployee())
                this.DialogResult = DialogResult.OK;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtEmployeeNO2_TextChanged(object sender, EventArgs e)
        {
            if (iType != 0)
            {
                txtEmployeeNO.Text = txtEmployeeNO2.Text.ToString();
            }
        }

        private void trwPowers_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Action == TreeViewAction.ByMouse)
            {
                if(e.Node.Checked == true)
                {
                    SetChildrenNodeState(e.Node,true);
                }
                else if(e.Node.Checked == false)
                {
                    SetChildrenNodeState(e.Node, false);
                    if(e.Node.Parent != null)
                    {
                        SetParentNodeState(e.Node, false);
                    }
                }
            }
            if(e.Node.Parent != null)
            {
                TreeNode p = e.Node.Parent;
                p.Checked = p.Nodes.OfType<TreeNode>().All(tn=>tn.Checked);
            }
        }

        private void SetParentNodeState(TreeNode curNode, bool state) 
        {
            TreeNode parentNode = curNode.Parent;
            parentNode.Checked = state;
            if (curNode.Parent.Parent != null)
            {
                SetParentNodeState(parentNode,state);
            }   
        }
        private void SetChildrenNodeState(TreeNode curNode, bool state)
        {
            TreeNodeCollection childrenNode = curNode.Nodes;
            if (childrenNode.Count>0)
            {
                foreach(TreeNode tr in childrenNode)
                {
                    tr.Checked = state;
                    SetChildrenNodeState(tr,state);
                }
            }
        }

        private void trwPowers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            trwPowers.SelectedNode.Checked = !trwPowers.SelectedNode.Checked;
            trwPowers_AfterCheck(sender,e);
        }
    }
}