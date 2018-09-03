using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmDressAdd : Form
    {
        List<string> _orderList;
        Service ErpWs = new Service();
        public FrmDressAdd(List<string> orderList)
        {
            InitializeComponent();
            _orderList = orderList;
            txtMan.Text = orderList[4];
            txtWoman.Text = orderList[5];

            DataSet dataSet = ErpWs.SearchEmployee(string.Format(@" and  DepartmentNO = '{0}'", Information.CurrentUser.EmployeeDepartmentNO));
            cmbDresserss.DataSource = dataSet.Tables[0];
            cmbDresserss.DisplayMember = "EmployeeName";
            cmbDresserss.ValueMember = "EmployeeNO";
            cmbDresserss.Text = orderList[6];
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int i = 0;//是否伴娘服
            if (chkCompany.Checked)
            {
                i = 1;
            }
            string keys = @" and DressStatus != '淘汰' and DressStatus !='出售' and DressStatus !='丢失' and  info.guanmin = '金纱嫁衣馆'";
            if (!string.IsNullOrEmpty(txtDressBarCode.Text))
            {
                keys += string.Format(@" and  info.DressBarCode = '{0}'", txtDressBarCode.Text);
            }
            DataTable drTable =
               ErpService.DressManagement.GetDressesImage(Convert.ToDateTime(_orderList[1]), Convert.ToDateTime(_orderList[3]), null, null,
                   null, keys, false).Tables[0];
            if (drTable.Rows.Count == 0)
            {
                MessageBox.Show(@"该礼服已出租！");
                return;
            }
            if (ErpService.DressManagement.DressRentAdd(_orderList,txtDressBarCode.Text,txtRemark.Text,i,Information.CurrentUser.EmployeeNO2,cmbDresserss.Text))
            {
                MessageBox.Show(@"操作成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show(@"操作失败，检查后重试！");
            }
        }

        private void txtDressBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dtTable = ErpService.DressManagement.GetDressSearchInformation(txtDressBarCode.Text).Tables[0];
                string imgPath = dtTable.Rows[0]["DressImagePath"].SafeDbValue<string>();
                if (string.IsNullOrEmpty(imgPath))
                {
                    MessageBox.Show(@"该礼服没有照片路径！");
                    return;
                }
                string[] pathInfo = imgPath.Split(Convert.ToChar(@"\"));
                Ping strPing = new Ping();
                PingReply pingReply = strPing.Send(pathInfo[2]);
                if (pingReply != null && pingReply.Status != IPStatus.Success)
                {
                    MessageBox.Show(@"无法访问照片路径！");
                    return;
                }
                picImage.Image =
                           FileTool.ReadImageFile(imgPath.Replace("JPG", "lf").Replace("jpg", "lf"))
                               .ZoomImage(picImage.Size, true, Color.LightGray);
                dtTable.Dispose();
            }
        }
    }
}
