using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressModify : Form
    {
        private IEnumerable<RuleObject> Rules { get; set; }
        private string _imgPath = string.Empty;
        public FrmDressModify()
        {
            InitializeComponent();

            DataSet ds = ErpService.DressManagement.GetDressStyle(RuleNumbers.Use.ToString());
            cmbUse.DataSource = ds.Tables[0];
            cmbUse.ValueMember = @"RuleNumbers";
            cmbUse.DisplayMember = @"RuleName";
            cmbUse.SelectedIndex = -1;
        }

        private string Barcode
        {
            get { return txtBarcode.Text; }
        }

        private string venueName;
        private string useage;
        private void btnChangeArea_Click(object sender, EventArgs e)
        {
            new FrmAreaPicker
            {
                AfterPick = node =>
                {
                    try
                    {
                        RuleObject area = (RuleObject)node.Tag;
                        DressManager.ChangeArea(Barcode, area, venueName, Information.CurrentUser.EmployeeNO2, Information.CurrentUser.EmployeeDepartmentNO);
                        MessageBoxEx.Info(@"变更成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBoxEx.Error(ex.Message);
                    }
                }
            }.Show();
        }

        private void txtBarcode_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarcode.Text == String.Empty)
                {
                    return;
                }
                DataSet ds = ErpService.DressManagement.DressesManage(txtBarcode.Text);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(@"该礼服已淘汰！");
                    return;
                }
                txtCnt.Text = ds.Tables[0].Rows[0]["DressNumberOfUsedToday"].ToString();
                _imgPath = ds.Tables[0].Rows[0]["DressImagePath"].ToString();
                venueName = ds.Tables[0].Rows[0]["guanmin"].ToString();
                useage = ds.Tables[0].Rows[0]["DressUse"].ToString();
                cmbUse.Text = useage;
                if (_imgPath != String.Empty)
                {
                    string[] pingStrings = _imgPath.Split(Convert.ToChar(@"\"));
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(pingStrings[2]);
                    if (pingReply != null && pingReply.Status != IPStatus.Success)
                    {
                        MessageBox.Show(@"照片路径无法访问！");
                        picDress.Image = null;
                        return;
                    }
                    picDress.Image = FileTool.ReadImageFile(_imgPath.Replace("jpg", "lf").Replace("JPG", "lf")).ZoomImage(picDress.Size, true, Color.LightGray);
                }
                else
                {
                    picDress.Image = null;
                }
            }
        }


        private void btnCount_Click(object sender, EventArgs e)
        {
            if (nmUpDm.Value > 0)
            {
                if (DressManager.EliminateDressUseCout(Barcode, nmUpDm.Value, Information.CurrentUser.EmployeeNO2,txtCnt.Text))
                {
                    MessageBox.Show(@"修改成功！");
                    nmUpDm.Value = 0;
                    txtCnt.Text = nmUpDm.Value.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    MessageBox.Show(@"修改失败！");
                }
            }
            else
            {
                MessageBox.Show(@"次数不能为0");
            }
        }

        private void btnChangeUse_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbUse.Text))
            {
                if (DressManager.EliminateDressUse(Barcode, cmbUse.Text, Information.CurrentUser.EmployeeNO2,
                    useage))
                {
                    MessageBox.Show(@"修改成功！");
                    cmbUse.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show( @"修改失败！");
                }
            }
        }

        private void picDress_Click(object sender, EventArgs e)
        {
            FrmExampleShow frmExampleShow = new FrmExampleShow(_imgPath, 0);
            frmExampleShow.ShowDialog();
        }
    }
}