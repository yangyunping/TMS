using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLady.Utility.ToolForm;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmOrdersShootSearch : UserControl
    {
        Service ErpWs = new Service();
        public FrmOrdersShootSearch()
        {
            InitializeComponent();
            this.Text = this.Text + @"    " + Information.CurrentUser.EmployeeDutyChs + @"  " + Information.CurrentUser.EmployeeName;
            Initialize();
        }

        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void Initialize()
        {
            cmbVenues.DataSource = DressManager.GetVenues().ToList();
            cmbVenues.DisplayMember = @"Name";
            cmbVenues.ValueMember = @"DepartmentNo";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = string.Empty;
            if (chkShootDate.Checked)
            {
                sSql = " and DATEDIFF(DD,PreShootDate,'" + dtpShootDate.Value.ToShortDateString() + "')=0 ";
            }
            if (!string.IsNullOrEmpty(cmbVenues.Text))
            {
                sSql += " and ShootDepartmentNO='" + cmbVenues.SelectedValue.ToString() + "' ";
            }
            if (!string.IsNullOrEmpty(cmbShootEmployee.Text) && !cmbShootEmployee.Text.Equals(@"全部"))
            {
                sSql += " and ShootEmployee = '" + cmbShootEmployee.Text + "' ";
            }
            if (txtKey.Text != "")
            {
                sSql += string.Format("  and (vs.OrderNO = '{0}' or CustomerName1 = '{0}' or  CustomerName2 = '{0}' or  MobilePhone1 = '{0}' or  MobilePhone2 = '{0}') ", txtKey.Text);
            }
            if (string.IsNullOrEmpty(sSql))
            {
                MessageBox.Show(@"无条件查询容易造成软件卡死！");
                return;
            }
            sSql += " order by vs.OrderNO";

            DataSet dataSet = ErpWs.Search_PreShoot(sSql);
            dgvOrderData.DataSource = null;
            DataTable dt = dataSet.Tables[0];
            dt.Columns.Add("PreShootDateW");
            dt.Columns.Add("ShootAddressW");
            dt.Columns.Add("ShootMemoryW");

            #region 全套判断
            List<DataRow> lstRemove = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int iNext = i + 1;
                int iN = 0, iW = 0;

                //全套当天内外景
                if (iNext < dt.Rows.Count
                    &&
                    dt.Rows[i]["OrderNO"].ToString() == dt.Rows[iNext]["OrderNO"].ToString() && dt.Rows[i]["ShootState"].ToString() == dt.Rows[iNext]["ShootState"].ToString()
                    &&
                    dt.Rows[i]["PreShootDate"].ToString() != ""  &&  dt.Rows[iNext]["PreShootDate"].ToString() != ""
                    &&
                    DateTime.Parse(dt.Rows[i]["PreShootDate"].ToString()).Date == DateTime.Parse(dt.Rows[iNext]["PreShootDate"].ToString()).Date)
                {
                    switch (dt.Rows[i]["ShootType"].ToString())
                    {
                        case "外景":
                            iN = iNext;
                            iW = i;
                            break;
                        case "内景":
                            iN = i;
                            iW = iNext;
                            break;
                    }
                    dt.Rows[iN]["ShootType"] = "全套";
                    dt.Rows[iN]["ShootAddressW"] = dt.Rows[iW]["ShootAddress"].SafeDbValue<string>();
                    dt.Rows[iN]["PreShootDateW"] = dt.Rows[iW]["PreShootDate"].SafeDbValue<string>();
                    dt.Rows[iN]["ShootMemoryW"] = dt.Rows[iW]["ShootMemory"].SafeDbValue<string>();
                    lstRemove.Add(dt.Rows[iW]); 
                }
                else if (dt.Rows[i]["ShootType"].ToString() == "外景")
                {
                    dt.Rows[i]["ShootAddressW"] = dt.Rows[i]["ShootAddress"].SafeDbValue<string>();
                    dt.Rows[i]["PreShootDateW"] = dt.Rows[i]["PreShootDate"].SafeDbValue<string>();
                    dt.Rows[i]["ShootMemoryW"] = dt.Rows[i]["ShootMemory"].SafeDbValue<string>();
                    dt.Rows[i]["ShootAddress"] = DBNull.Value;
                    dt.Rows[i]["PreShootDate"] = DBNull.Value;
                    dt.Rows[i]["ShootMemory"] = DBNull.Value;
                }
            }
            foreach (DataRow row in lstRemove)
            {
                dt.Rows.Remove(row);
            }
            dt.AcceptChanges();
            #endregion

            dgvOrderData.AutoGenerateColumns = false;
            dgvOrderData.DataSource = dataSet.Tables[0];
            lblSum.Text = @"显示总数：" + dataSet.Tables[0].Rows.Count;
            dataSet.Dispose();
        }
        private void chkShootDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpShootDate.Enabled = chkShootDate.Checked;
        }

        private void tscDressChoose_Click(object sender, EventArgs e)
        {
            if (dgvOrderData.DataSource == null)
            {
                return;
            }
            if (dgvOrderData.CurrentRow != null)
            {
                string orderNo = dgvOrderData.CurrentRow.Cells["OrderNO"].Value.ToString();
                DataTable drTable = dgvOrderData.DataSource as DataTable;
                if (drTable != null)
                {
                    DataRow[] dr = drTable.Select("OrderNo ='" + orderNo + "' ");
                    AllKindsData.OrderNo = orderNo;
                    AllKindsData.CustomerNo = dr[0]["CustomerNO"].SafeDbValue<string>();
                    AllKindsData.CustomerName = dr[0]["CustomerName1"].SafeDbValue<string>() + "  " +
                                                dr[0]["CustomerName2"].SafeDbValue<string>();
                    AllKindsData.MoblePhone = dr[0]["MobilePhone1"].SafeDbValue<string>() + "  " +
                                              dr[0]["MobilePhone2"].SafeDbValue<string>();
                    AllKindsData.VenueDepartmentNo = AllKindsData.OrderVenueNo = dr[0]["ShootDepartmentNO"].SafeDbValue<string>();
                    AllKindsData.VenueId = dr[0]["VenueID"].SafeDbValue<int>();
                    AllKindsData.VenueName = dr[0]["shootDepartment"].SafeDbValue<string>();
                    AllKindsData.SuitPrice = dr[0]["SuitePrice"].SafeDbValue<decimal>();
                    AllKindsData.SuitName = dr[0]["SuiteName"].SafeDbValue<string>();
                    AllKindsData.ShootDate =
                        string.IsNullOrEmpty(dgvOrderData.CurrentRow.Cells["PreShootDate"].Value.ToString())
                            ? dgvOrderData.CurrentRow.Cells["PreShootDateW"].Value.ToString()
                            : dgvOrderData.CurrentRow.Cells["PreShootDate"].Value.ToString();
                    AllKindsData.ChoosedDressInfo = new Dictionary<string, string>();
                    AllKindsData.SceneInfo = new Dictionary<string, string>();
                    drTable.Dispose();
                }
                //顾客是否已选礼服和场景，并保存临时数据
                //礼服
                string sqlString = string.Format(" and OrderNO = '{0}' ", AllKindsData.OrderNo);
                DataTable dtDress = ErpService.DressManagement.SearchDressChoosed(sqlString).Tables[0];
                if (dtDress.Rows.Count > 0)
                {
                    List<string> lstDressBarcode = new List<string>();
                    lstDressBarcode.AddRange(from DataRow row in dtDress.Rows select row["DressBarCode"].ToString());
                    DataTable dtDressImage = ErpService.DressManagement.DressesManage(
                        string.Join("','", lstDressBarcode)).Tables[0];
                    foreach (DataRow row in dtDressImage.Rows)
                    {
                        string dressKey = row["Themename"].ToString() + "-" + row["DressBarCode"].ToString();
                        if (!AllKindsData.ChoosedDressInfo.ContainsKey(dressKey))
                        {
                            AllKindsData.ChoosedDressInfo.Add(dressKey, row["DressImagePath"].ToString());
                        }
                    }
                }
                dtDress.Dispose();
                //场景
                DataTable dtScene = ErpService.DressManagement.GetSceneChoosed(AllKindsData.OrderNo, null).Tables[0];
                if (dtScene.Rows.Count > 0)
                {
                    foreach (DataRow row in dtScene.Rows)
                    {
                        string sceneKey = row["SceneID"].SafeDbValue<string>() + "_" + row["SceneName"].SafeDbValue<string>();
                        if (
                            !AllKindsData.SceneInfo.ContainsKey(sceneKey))
                        {
                            AllKindsData.SceneInfo.Add(sceneKey, row["PhotoPath"].ToString());
                        }
                    }
                }
                dtScene.Dispose();
                FrmDressPreSelect frmGeneral = new FrmDressPreSelect();
                frmGeneral.Show();
            }
        }
        private void bntPrintSetting_Click(object sender, EventArgs e)
        {
            Dress.frmPrinter frmPrinter = new GoldenLady.Dress.frmPrinter();
            frmPrinter.ShowDialog();
        }

        private void cmbVenues_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbVenues.SelectedItem == null)
            {
                return;
            }
            string sqlString = @"  and IsDelete=0 and EmployeeDuty='摄影师'";
            if (!string.IsNullOrEmpty(((Venue)cmbVenues.SelectedItem).DepartmentNo))
            {
                sqlString += @" and DepartmentNO = '" + ((Venue)cmbVenues.SelectedItem).DepartmentNo + "'";
            }
            DataTable dtTable = ErpWs.SearchEmployee(sqlString).Tables[0];
            DataRow drRow = dtTable.NewRow();
            drRow["EmployeeName"] = "全部";
            drRow["EmployeeNO"] = "-1";
            dtTable.Rows.InsertAt(drRow, 0);
            cmbShootEmployee.DataSource = dtTable;
            cmbShootEmployee.DisplayMember = "EmployeeName";
            cmbShootEmployee.ValueMember = "EmployeeNO";
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
