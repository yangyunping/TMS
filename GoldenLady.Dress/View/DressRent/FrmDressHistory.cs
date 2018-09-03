using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmDressHistory : Form
    {
        public FrmDressHistory(string dressBarCode)
        {
            InitializeComponent();
            DgvDressColumns();
            txtDressBarCode.Text = dressBarCode;
            btnSearch_Click(null, null);
        }
        private void DgvDressColumns()
        {
            dgvShow.Columns.AddRange(

                new DataGridViewTextBoxColumn
                {
                    Name = @"dressBarCode",
                    HeaderText = @"礼服条码",
                    DataPropertyName = @"dressBarCode",
                    Width = 110
                },

                new DataGridViewTextBoxColumn
                {
                    Name = @"DressStatus",
                    HeaderText = @"礼服状态",
                    DataPropertyName = @"DressStatus",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"CustomerName1",
                    HeaderText = @"先生",
                    DataPropertyName = @"CustomerName1",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"MobilePhone1",
                    HeaderText = @"电话1",
                    DataPropertyName = @"MobilePhone1",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"CustomerName2",
                    HeaderText = @"小姐",
                    DataPropertyName = @"CustomerName2",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"MobilePhone2",
                    HeaderText = @"电话2",
                    DataPropertyName = @"MobilePhone2",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"takeDressTime",
                    HeaderText = @"取衣时间",
                    DataPropertyName = @"takeDressTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"marryDtaTime",
                    HeaderText = @"结婚时间",
                    DataPropertyName = @"marryDtaTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"returnDressTime",
                    HeaderText = @"还衣时间",
                    DataPropertyName = @"returnDressTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"DressCustomCode",
                    HeaderText = @"自编号",
                    DataPropertyName = @"DressCustomCode",
                    Width = 80
                },
                 new DataGridViewTextBoxColumn
                 {
                     Name = @"RuleName",
                     HeaderText = @"小类",
                     DataPropertyName = @"RuleName",
                     Width = 80
                 },
                 new DataGridViewTextBoxColumn
                 {
                     Name = @"batchNum",
                     HeaderText = @"批号",
                     DataPropertyName = @"batchNum",
                     Width = 100
                 },
                new DataGridViewTextBoxColumn
                {
                    Name = @"DressStylist",
                    HeaderText = @"礼服师",
                    DataPropertyName = @"DressStylist",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"DressCompany",
                    HeaderText = @"伴娘服",
                    DataPropertyName = @"DressCompany",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"OutOperate",
                    HeaderText = @"出件人",
                    DataPropertyName = @"OutOperate",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"OutOperatoerTime",
                    HeaderText = @"出件时间",
                    DataPropertyName = @"OutOperatoerTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"inOperate",
                    HeaderText = @"回件人",
                    DataPropertyName = @"inOperate",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"BackOperatorTime",
                    HeaderText = @"回件时间",
                    DataPropertyName = @"BackOperatorTime",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"remarks",
                    HeaderText = @"单件备注",
                    DataPropertyName = @"remarks",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"Notes",
                    HeaderText = @"总备注",
                    DataPropertyName = @"Notes",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"SallType",
                    HeaderText = @"销售类别",
                    DataPropertyName = @"SallType",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"RentOfPrice",
                    HeaderText = @"出租价钱",
                    DataPropertyName = @"RentOfPrice",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"SaleOfPrice",
                    HeaderText = @"出售价钱",
                    DataPropertyName = @"SaleOfPrice",
                    Width = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = @"OperateTime",
                    HeaderText = @"创建时间",
                    DataPropertyName = @"OperateTime",
                    Width = 100
                }
                );
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDressBarCode.Text))
            {
                string sSql = string.Format(@" and  a.DressBarCode = '{0}'  ", txtDressBarCode.Text);
                DataTable dtDresses = ErpService.DressManagement.GetRenDresses(sSql).Tables[0];
                dgvShow.AutoGenerateColumns = false;
                dgvShow.DataSource = dtDresses;
                lblSum.Text = @"显示总数：" + dtDresses.Rows.Count;
                dtDresses.Dispose();
            }
            else
            {
                MessageBox.Show(@"请输入礼服条码！");
            }
        }

        private void 显示礼服照片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShow.CurrentRow != null)
            {
                try
                {
                    if (AllKindsData.ImgPathLst != null)
                    {
                        AllKindsData.ImgPathLst.Clear();
                    }
                    string dressBarcode = dgvShow.CurrentRow.Cells["DressBarCode"].Value.ToString();
                    DataTable dtTable = ErpService.DressManagement.DressesManage(dressBarcode).Tables[0];
                    string imgPath = dtTable.Rows[0]["DressImagePath"].ToString();
                    dtTable.Dispose();
                    if (imgPath == String.Empty)
                    {
                        MessageBox.Show(@"没有照片");
                        return;
                    }
                    new FrmExampleShow(imgPath, 0).ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"照片路径无法访问！" + ex);
                    return;
                }
            }
        }
    }
}
