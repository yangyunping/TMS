using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressPreSelect : Form
    {
        private int _iPage = 1;//打印页数
        public FrmDressPreSelect()
        {
            InitializeComponent();
            this.Text = this.Text + @"         " + Information.CurrentUser.EmployeeDutyChs + @"  " + Information.CurrentUser.EmployeeName;
            lblName.Text = Information.CurrentUser.EmployeeDutyChs + @"：  " + Information.CurrentUser.EmployeeName;
            lblCustomer.Text = @"顾客：" + AllKindsData.CustomerName;
            InitilzeData(); //初始化数据  
            tabPage4.Enabled = tabPage5.Enabled = false;
        }

        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        /// <summary>
        /// 场馆、风格
        /// </summary>
        private void InitilzeData()
        {
            List<CrossReservation> crossReservations = DressManager.GetCrossReservations(AllKindsData.VenueId).ToList();
            cmbVenues.DataSource = crossReservations;
            cmbVenues.DisplayMember = @"CrossVenue";
            cmbVenues.ValueMember = @"CrossVenueID";

            DataTable dsTable = ErpService.DressManagement.GetDressStyle("50").Tables[0]; //上半身
            clstDressStyle.DataSource = dsTable;
            clstDressStyle.DisplayMember = @"RuleName";
            clstDressStyle.ValueMember = @"RuleNumbers";

            //已存在场馆
            cmbVenues.SelectedValue = AllKindsData.VenueId;

            //已选礼服展示购物车
            ChoosedDressShow();
        }
        /// <summary>
        /// 已选场景礼服展示
        /// </summary>
        private void ChoosedDressShow()
        {
            if (AllKindsData.SceneInfo.Count > 0)
            {
                tabShow.SelectTab(1);
                System.Drawing.Size imgSize = imgChoosedDress.ImageSize;
                foreach (var scene in AllKindsData.SceneInfo)
                {
                    try
                    {
                        Ping newPing = new Ping();
                        string[] pingStrings = Path.GetDirectoryName(scene.Value).Split(Convert.ToChar(@"\"));
                        PingReply pingReply = newPing.Send(pingStrings[2]);
                        if (pingReply != null && pingReply.Status != IPStatus.Success)
                        {
                            MessageBox.Show(@"照片路径无法访问！");
                            return;
                        }

                        string imgPath = Path.Combine(Path.GetDirectoryName(scene.Value),
                            Path.GetFileNameWithoutExtension(scene.Value) + ".thumb");
                        Image img = FileTool.ReadImageFile(imgPath).ZoomImage(imgSize, true, Color.LightGray);
                        imgChoosedDress.Images.Add(scene.Key, img);
                        ListViewItem lstViewItem = new ListViewItem()
                        {
                            ImageKey = scene.Key,
                            Text = scene.Key,
                            Tag = scene.Value
                        };
                        lvwChoosedDress.BeginUpdate();
                        lvwChoosedDress.Items.Add(lstViewItem);
                        lvwChoosedDress.EndUpdate();
                        lvwChoosedDress.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"已选场景存在照片无法访问！" + ex);
                        continue;
                    }
                }
            }

            if (AllKindsData.ChoosedDressInfo.Count > 0)
            {
                tabShow.SelectTab(1);
                System.Drawing.Size imgSize = imgChoosedDress.ImageSize;
                foreach (var dress in AllKindsData.ChoosedDressInfo)
                {
                    try
                    {
                        Ping newPing = new Ping();
                        string[] pingStrings = Path.GetDirectoryName(dress.Value).Split(Convert.ToChar(@"\"));
                        PingReply pingReply = newPing.Send(pingStrings[2]);
                        if (pingReply != null && pingReply.Status != IPStatus.Success)
                        {
                            MessageBox.Show(@"照片路径无法访问！");
                            return;
                        }

                        string imgPath = Path.Combine(Path.GetDirectoryName(dress.Value),
                            Path.GetFileNameWithoutExtension(dress.Value) + ".lf");
                        Image img = FileTool.ReadImageFile(imgPath).ZoomImage(imgSize, true, Color.LightGray);
                        imgChoosedDress.Images.Add(dress.Key, img);
                        int dex = dress.Key.LastIndexOf("-", StringComparison.Ordinal) + 1;
                        string dressBarcode = dress.Key.Substring(dex, dress.Key.Length - dex);
                        ListViewItem lstViewItem = new ListViewItem()
                        {
                            ImageKey = dress.Key,
                            Text = dress.Key,
                            Name = dressBarcode,
                            Tag = dress.Value
                        };
                        lvwChoosedDress.BeginUpdate();
                        lvwChoosedDress.Items.Add(lstViewItem);
                        lvwChoosedDress.EndUpdate();
                        lvwChoosedDress.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"已选礼服存在照片无法访问！" + ex);
                        return;
                    }
                }
            }
        }
        private void cmbVenues_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(((CrossReservation)cmbVenues.SelectedItem).CrossVenueID.ToString()))
            {
                return;
            }
            List<Theme> themes = ErpService.DressManagement.GetThemes(((CrossReservation)cmbVenues.SelectedItem).CrossVenueID).ToList();
            clstThemes.DataSource = themes;
            clstThemes.DisplayMember = @"Name";
            clstThemes.ValueMember = @"ID";

            for (int i = 0; i < themes.Count; i++)
            {
                clstThemes.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        /// <summary>
        /// 场景显示封面
        /// </summary>
        private void SceneShow()
        {
            DataTable dt = ErpService.DressManagement.GetSceneInfo(string.Join("','", AllKindsData.ThemeInfo.Keys.ToArray()), null).Tables[0];
            DataRow[] sDataTable = dt.Select("rowNum = 1");
            try
            {
                foreach (DataRow row in sDataTable)
                {
                    if (row["PhotoPath"].ToString() != String.Empty)
                    {
                        string[] imagePath = row["PhotoPath"].ToString().Split(Convert.ToChar(@"\"));
                        Ping strPing = new Ping();
                        PingReply pingReply = strPing.Send(imagePath[2]);
                        if (pingReply != null && pingReply.Status != IPStatus.Success)
                        {
                            MessageBox.Show(@"无法访问照片路径！");
                            return;
                        }
                        var img =
                            FileTool.ReadImageFile(row["PhotoPath"].ToString()
                                .Replace("jpg", "thumb")
                                .Replace("JPG", "thumb"));
                        imgScene.Images.Add(row["PhotoPath"].ToString(),
                            img.ZoomImage(imgScene.ImageSize, true, Color.LightGray));
                        ListViewItem lst = new ListViewItem()
                        {
                            ImageKey = row["PhotoPath"].ToString(),
                            Text = row["ID"].ToString() + @"_" + row["Name"].ToString(),
                            Tag = row["PhotoPath"].ToString().Replace("jpg", "thumb").Replace("JPG", "thumb")
                        };
                        lvwScenes.BeginUpdate();
                        lvwScenes.Items.Add(lst);
                        lvwScenes.EndUpdate();
                        lvwScenes.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"无法访问照片路径" + ex);
                return;
            }
            finally
            {
                dt.Dispose();
                GC.Collect();
            }

        }

        private void btnScene_Click(object sender, EventArgs e)
        {
            tabShow.SelectTab(1);

            DataTable dsTable = ErpService.DressManagement.GetDressStyle("50").Tables[0];
            clstDressStyle.DataSource = dsTable;
            clstDressStyle.DisplayMember = @"RuleName";
            clstDressStyle.ValueMember = @"RuleNumbers";
        }

        private void chkThemes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked) return;
            if (clstThemes.CheckedItems.Count > 0)
            {
                for (var i = 0; i < clstThemes.Items.Count; i++)
                {
                    clstThemes.SetItemChecked(i, false);
                }
                e.NewValue = CheckState.Checked;
            }

            AllKindsData.ThemeInfo = new Dictionary<string, string>
                {
                    {clstThemes.SelectedValue.ToString(), clstThemes.Text}
                };

            if (AllKindsData.SceneInfo == null)
            {
                AllKindsData.SceneInfo = new Dictionary<string, string>();
            }
            if (lvwScenes.Items.Count > 0)
            {
                lvwScenes.Items.Clear();
            }
            if (lvwDresses.Items.Count > 0)
            {
                lvwDresses.Items.Clear();
            }
            if (imgScene.Images.Count > 0)
            {
                imgScene.Images.Clear();
            }
            if (tabShow.SelectedIndex == 0)
            {
                SceneShow(); //场景展示
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> styleList = (from DataRowView item in clstDressStyle.CheckedItems select item.Row["RuleName"].ToString()).ToList();
            DressShow(styleList);//礼服展示
        }

        /// <summary>
        /// 转到妆面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            tabShow.SelectTab(2);
            FaceShow(); //妆面预选
        }
        /// <summary>
        /// 转到男装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext1_Click(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            tabShow.SelectTab(3);
            ManDressShow();
        }

        private Task task;
        /// <summary>
        /// 礼服展示
        /// </summary>
        private void DressShow(List<string> styleDress)
        {
            try
            {
                string venueName;
                if (cmbVenues.Text.Trim().Equals("星光夏朵-摄") || cmbVenues.Text.Trim().Equals("星光印象-摄") || cmbVenues.Text.Trim().Equals("星光奥斯卡-摄"))
                {
                    venueName = BaseData.星光Name;
                }
                else
                {
                    venueName = cmbVenues.Text.Trim();
                }
                if (clstThemes.CheckedItems.Count == 0)
                {
                    MessageBox.Show(@"请先选择风格！");
                    return;
                }
                var dtDresses =
                    ErpService.DressManagement.GetDressInformation(venueName,
                        AllKindsData.ThemeInfo.Values.ToList()[0], AllKindsData.ShootDate, BaseData.DressId, styleDress)
                        .Tables[0];
                if (dtDresses.Rows.Count == 0)
                {
                    MessageBox.Show(@"没有查询到礼服信息！");
                    return;
                }
                lvwDresses.Items.Clear();
                lvwDresses.LargeImageList.Images.Clear();
                AllKindsData.ImgPathLst = new List<string>();
                btnSearch.Enabled = false;
                task = Task.Factory.StartNew(() => Methods.AllShow(dtDresses, lvwDresses)); //礼服照片展示
            }
            catch (Exception)
            {
                MessageBox.Show(@"请加载完后操作，避免软件卡死！");
                btnSearch.Enabled = true;
                throw;
            }
        }
        /// <summary>
        /// 妆面展示
        /// </summary>
        private void FaceShow()
        {
            var dt = ErpService.DressManagement.GetFaceInformation(BaseData.FaceId, AllKindsData.ThemeInfo.Keys.ToArray()).Tables[0];
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(@"没有查询到妆面信息！");
                return;
            }
            //Methods.AllShow(dt, lvwFace, imgFace);
        }
        /// <summary>
        /// 男装展示
        /// </summary>
        private void ManDressShow()
        {
            var dt = ErpService.DressManagement.GetFaceInformation(BaseData.ManDressId, AllKindsData.ThemeInfo.Keys.ToArray()).Tables[0];
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(@"没有查询到男装信息！");
                return;
            }
            //Methods.AllShow(dt, lvwManDress, imgManDress);
        }

        private void lvwDresses_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvwDresses.SelectedItems.Count == 0)
                {
                    return;
                }
                string choosedDressBarCode = lvwDresses.SelectedItems[0].Text;
                string choosedDressedKey = clstThemes.Text + @"-" + choosedDressBarCode;
                string imagePath = lvwDresses.SelectedItems[0].Tag.ToString().Split(',')[0];

                //显示同穿
                dgvSameChoosedDress.DataSource = null;
                DataTable dtTable = ErpService.DressManagement.GetSameChoosedDress(choosedDressBarCode, AllKindsData.ShootDate).Tables[0];
                foreach (DataRow row in dtTable.Rows)
                {
                    dgvSameChoosedDress.Rows.Add(row.ItemArray);
                }
                dtTable.Dispose();

                if (AllKindsData.ChoosedDressInfo == null)
                {
                    AllKindsData.ChoosedDressInfo = new Dictionary<string, string>();
                }
                if (!AllKindsData.ChoosedDressInfo.ContainsKey(choosedDressedKey))
                {
                    AllKindsData.ChoosedDressInfo.Add(choosedDressedKey, imagePath);
                }
                DataTable dtDressInfo =
                   ErpService.DressManagement.DressEnableUse(choosedDressBarCode,
                        AllKindsData.ShootDate).Tables[0];
                if (dtDressInfo.Rows[0]["DressRemainCnt"].SafeDbValue<int>() <= 0)
                {
                    MessageBox.Show(@"该礼服没有使用次数。");
                    return;
                }
                if (!ErpService.DressManagement.ChoosedInsert(choosedDressBarCode,
                        AllKindsData.OrderNo, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName,
                        AllKindsData.OrderVenueNo, AllKindsData.CustomerNo,
                        AllKindsData.ShootDate, BaseData.DressId))
                {
                    MessageBox.Show(@"数据库操作失败，检查网络！");
                    return;
                }

                //礼服信息
                Dictionary<string, string> dressInfo = new Dictionary<string, string>
                    {
                        {choosedDressBarCode, dtDressInfo.Rows[0]["DressStatus"].SafeDbValue<string>()}
                    };
                //状态更改
                if (dtDressInfo.Rows[0]["DressNumberOfUsedToday"].SafeDbValue<Int32>() == 1)
                {
                    ErpService.DressManagement.UpdateDressState(dressInfo, @"外景出库",
                        Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO2);
                }
                else
                {
                    ErpService.DressManagement.UpdateDressState(dressInfo, DressState.拍照中.ToString(),
                        Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO2);
                }
          
                string imgPath = Path.Combine(Path.GetDirectoryName(imagePath),
                    Path.GetFileNameWithoutExtension(imagePath) + ".lf");
                Image img = FileTool.ReadImageFile(imgPath).ZoomImage(imgChoosedDress.ImageSize, true, Color.LightGray);
                imgChoosedDress.Images.Add(choosedDressBarCode, img);

                ListViewItem lst = new ListViewItem
                {
                    ImageKey = choosedDressBarCode,
                    Tag = lvwDresses.SelectedItems[0].Tag.ToString(),
                    Name = choosedDressBarCode,
                    Text = choosedDressedKey
                };

                lvwChoosedDress.BeginUpdate();
                lvwChoosedDress.Items.Add(lst);
                lvwChoosedDress.EndUpdate();
                lvwChoosedDress.Refresh();
                img.Dispose();
                lvwDresses.Items.RemoveByKey(choosedDressBarCode);
                lvwDresses.Refresh();
                dtDressInfo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"数据库操作失败" + ex);
                return;
            }
        }

        private void lvwChoosedDress_DoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string dressKey = lvwChoosedDress.SelectedItems[0].Text;
                if (AllKindsData.SceneInfo.ContainsKey(dressKey))
                {
                    AllKindsData.SceneInfo.Remove(dressKey);
                    int i = lvwChoosedDress.SelectedIndices[0];
                    lvwChoosedDress.Items.RemoveAt(i);
                    lvwChoosedDress.Refresh();
                    return;
                }
                AllKindsData.ChoosedDressInfo.Remove(dressKey);
                int dex = dressKey.LastIndexOf("-", StringComparison.Ordinal) + 1;
                string dressBarcode = dressKey.Substring(dex, dressKey.Length - dex);

                if (ErpService.DressManagement.DeleteChoosedDress(dressBarcode,
                    @" and  DressEmployeeNO in('" + Information.CurrentUser.EmployeeNO + "','自选')", AllKindsData.OrderNo, Information.CurrentUser.EmployeeName))
                {
                    DataTable dtDressInfo =
                        ErpService.DressManagement.DressesManage(dressBarcode).Tables[0];
                    //礼服信息
                    Dictionary<string, string> dressInfo = new Dictionary<string, string>
                    {
                        {dressBarcode,dtDressInfo.Rows[0]["dressStatus"].ToString()}
                    };
                    //状态更改
                    if (!dtDressInfo.Rows[0]["dressStatus"].Equals(DressState.礼服送洗.ToString()))
                    {
                        ErpService.DressManagement.UpdateDressState(dressInfo, DressState.入库.ToString(),
                        Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO2);
                    }
                    dtDressInfo.Dispose();
                    lvwChoosedDress.Items.RemoveByKey(dressBarcode);
                    lvwChoosedDress.Refresh();
                }
                else
                {
                    MessageBox.Show(@"该礼服不是这个员工加入的购物车！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"数据库操作失败！" + ex);
                return;
            }
        }

        private void lvwFace_DoubleClick(object sender, EventArgs e)
        {
            if (AllKindsData.ChoosedFaceInfo == null)
            {
                AllKindsData.ChoosedFaceInfo = new Dictionary<string, string>();
            }
            string path = lvwFace.SelectedItems[0].Tag.ToString();
            if (
                !AllKindsData.ChoosedFaceInfo.ContainsKey(clstThemes.Text.ToString() + @"-" +
                                                          lvwFace.SelectedItems[0].Text.ToString()))
            {
                AllKindsData.ChoosedFaceInfo.Add(
                    clstThemes.Text.ToString() + @"-" + lvwFace.SelectedItems[0].Text.ToString(), path);
            }
            Image image = FileTool.ReadImageFile(path);
            imgFaceChoosed.Images.Add(image.ZoomImage(imgFaceChoosed.ImageSize, true, Color.LightGray));
            imgManDressChoosed.Images.Add(image.ZoomImage(imgManDressChoosed.ImageSize, true, Color.LightGray));
            if (
                 !ErpService.DressManagement.ChoosedInsert(lvwFace.SelectedItems[0].Text.ToString(),
                     AllKindsData.OrderNo, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName,
                     Information.CurrentUser.EmployeeDepartmentNO, AllKindsData.CustomerNo,
                     AllKindsData.ShootDate, BaseData.FaceId))
            {
                MessageBox.Show(@"数据操作失败！");
                return;
            }
            ListViewItem lstItem = new ListViewItem()
            {
                ImageIndex = imgFaceChoosed.Images.Count - 1,
                Tag = path,
                Text = clstThemes.Text + @"-" + lvwFace.SelectedItems[0].Text
            };
            lvwChoosedFace.BeginUpdate();
            lvwChoosedFace.Items.Add(lstItem);
            lvwChoosedFace.EndUpdate();
            lvwChoosedFace.Refresh();

            lvwChoosedManDress.BeginUpdate();
            lvwChoosedManDress.Items.Add((ListViewItem)lstItem.Clone());
            lvwChoosedManDress.EndUpdate();
            lvwChoosedManDress.Refresh();

            lvwFace.Items.RemoveAt(lvwFace.SelectedIndices[0]);
            lvwFace.Refresh();
        }

        private void lvwChoosedFace_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                AllKindsData.ChoosedFaceInfo.Remove(lvwChoosedFace.SelectedItems[0].Text.Trim());
                Image img = FileTool.ReadImageFile(lvwChoosedFace.SelectedItems[0].Tag.ToString());
                int dex = lvwChoosedFace.SelectedItems[0].Text.Trim().LastIndexOf("-", StringComparison.Ordinal) + 1;
                string barcode = lvwChoosedFace.SelectedItems[0].Text.Trim()
                    .Substring(dex, lvwChoosedFace.SelectedItems[0].Text.Length - dex);
                imgFace.Images.Add(img.ZoomImage(imgFace.ImageSize, true, Color.LightGray));

                if (ErpService.DressManagement.DeleteChoosedDress(barcode, @" and DressEmployeeNO='" + Information.CurrentUser.EmployeeNO + "'", AllKindsData.OrderNo, Information.CurrentUser.EmployeeName))
                {
                    ListViewItem lst = new ListViewItem
                    {
                        ImageIndex = imgFace.Images.Count - 1,
                        Tag = lvwChoosedFace.SelectedItems[0].Tag.ToString(),
                        Text = barcode
                    };
                    lvwFace.BeginUpdate();
                    lvwFace.Items.Add(lst);
                    lvwFace.EndUpdate();
                    lvwFace.Refresh();

                    int i = lvwChoosedFace.SelectedIndices[0];
                    lvwChoosedFace.Items.RemoveAt(i);
                    lvwChoosedFace.Refresh();
                    lvwChoosedManDress.Items.RemoveAt(i);
                    lvwChoosedManDress.Refresh();
                }
            }
            catch
            {
                return;
            }
        }

        private void lvwMandress_DoubleClick(object sender, EventArgs e)
        {
            Methods.UnChooseDoubleClick(lvwManDress, lvwChoosedManDress, imgManDressChoosed, clstThemes.Text.ToString());
        }

        private void lvwChoosedManDress_DoubleClick(object sender, EventArgs e)
        {
            Methods.ChoosedDoubleClick(lvwManDress, lvwChoosedManDress, imgManDress);
        }

        private void lvwFace_KeyDown(object sender, KeyEventArgs e)
        {
            Methods.PhotoLarge(lvwFace);
        }

        private void lvwChoosedFace_KeyDown(object sender, KeyEventArgs e)
        {
            Methods.PhotoLarge(lvwChoosedFace);
        }

        private void lvwManDress_KeyDown(object sender, KeyEventArgs e)
        {
            Methods.PhotoLarge(lvwManDress);
        }

        private void lvwChoosedManDress_KeyDown(object sender, KeyEventArgs e)
        {
            Methods.PhotoLarge(lvwChoosedManDress);
        }
        private void lvwChoosedDress_KeyDown(object sender, KeyEventArgs e)
        {
            Methods.PhotoLarge(lvwChoosedDress);
        }

        private void lvwDresses_KeyDown(object sender, KeyEventArgs e)
        {
            Methods.PhotoLarge(lvwDresses);
        }
        private void lvwScenes_KeyDown(object sender, KeyEventArgs e)
        {
            List<string> thumbList = new List<string>();
            List<string> largeList = new List<string>();
            if (lvwScenes.SelectedItems.Count == 0)
            {
                return;
            }
            int dex = lvwScenes.SelectedItems[0].Text.LastIndexOf("_", StringComparison.Ordinal);
            string sceneId = lvwScenes.SelectedItems[0].Text.Substring(0, dex);
            DataTable dtTable = ErpService.DressManagement.GetSceneInfo(string.Join("','", AllKindsData.ThemeInfo.Keys.ToArray()), sceneId).Tables[0];
            foreach (DataRow row in dtTable.Rows)
            {
                largeList.Add(row["PhotoPath"].SafeDbValue<string>().Replace("jpg", "large").Replace("JPG", "large"));
                thumbList.Add(row["PhotoPath"].SafeDbValue<string>().Replace("jpg", "thumb").Replace("JPG", "thumb"));
            }
            dtTable.Dispose();
            new FrmPhotoShow(thumbList, largeList).ShowDialog();
        }
        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabShow.SelectTab(3);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabShow.SelectTab(2);
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog prnPreviewDialog =
                        new PrintPreviewDialog { Document = prtPrintResult };
                //prtPrintResult.PrinterSettings.PrinterName = PrinterManager.NormalPrinter.Name;
                prnPreviewDialog.ShowDialog();
                //this.Close();
                //prtPrintResult.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"打印错误\n" + ex.Message, @"检查打印机设置。", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void pdPrintResult_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int x = 300; //绘制时的横坐标
                int y = 15; //绘制时的纵坐标
                int j = 0;
                if (_iPage == 1)
                {
                    e.Graphics.DrawString("礼服预选清单", new Font("宋体", 20), new SolidBrush(Color.Black), new PointF(x, y));
                    //标题

                    //订单详情
                    x -= 250;
                    y += 40;
                    e.Graphics.DrawString(@"顾客：" + AllKindsData.CustomerName, new Font("宋体", 14),
                        new SolidBrush(Color.Black),
                        new PointF(x, y));

                    x += 350;
                    e.Graphics.DrawString(@"订单号：" + AllKindsData.OrderNo, new Font("宋体", 14),
                        new SolidBrush(Color.Black),
                        new PointF(x, y));

                    x -= 350;
                    y += 40;
                    e.Graphics.DrawString(@"礼服预选详情：", new Font("宋体", 14), new SolidBrush(Color.Black), new PointF(x, y));
                    e.Graphics.DrawString(@"场 景", new Font("宋体", 14), new SolidBrush(Color.Black), new PointF(x, y + 40));

                    //显示照片
                    x += 30;
                    y += 40;

                    if (AllKindsData.SceneInfo != null)
                    {
                        x = 120;
                        y = 135;
                        int i = 0;
                        foreach (var scene in AllKindsData.SceneInfo)
                        {
                            if (i % 5 == 0 && i != 0)
                            {
                                x = 120;
                                y += 160;
                                Image imageSmall = FileTool.ReadImageFile(scene.Value)
                                    .ZoomImage(100, 130, true, Color.LightGray);
                                e.Graphics.DrawImage(imageSmall, new PointF(x, y));
                                e.Graphics.DrawString(scene.Key, new Font("宋体", 7), new SolidBrush(Color.Black),
                                    new PointF(x, y + 140));
                                x += 130;
                                i++;
                            }
                            else
                            {
                                Image imageSmall = FileTool.ReadImageFile(scene.Value)
                                    .ZoomImage(100, 130, true, Color.LightGray);
                                e.Graphics.DrawImage(imageSmall, new PointF(x, y));
                                e.Graphics.DrawString(scene.Key, new Font("宋体", 7), new SolidBrush(Color.Black),
                                    new PointF(x, y + 140));
                                x += 130;
                                i++;
                            }
                        }
                    }

                    e.Graphics.DrawString(@"礼 服", new Font("宋体", 14), new SolidBrush(Color.Black),
                        new PointF(50, y + 200));

                    if (AllKindsData.ChoosedDressInfo != null)
                    {
                        x = 120;
                        y += 200;
                        foreach (var dress in AllKindsData.ChoosedDressInfo)
                        {
                            if (y > 980)
                            {
                                _iPage++;
                                e.HasMorePages = true;
                                return;
                            }
                            else
                            {
                                if (j % 5 == 0 && j != 0)
                                {
                                    x = 120;
                                    y += 160;
                                    Image imageSmall = FileTool.ReadImageFile(dress.Value.Replace("jpg", "lf"))
                                        .ZoomImage(100, 130, true, Color.LightGray);
                                    e.Graphics.DrawImage(imageSmall, new PointF(x, y));
                                    e.Graphics.DrawString(dress.Key, new Font("宋体", 7), new SolidBrush(Color.Black),
                                        new PointF(x, y + 140));
                                    x += 130;
                                    j++;
                                }
                                else
                                {
                                    Image imageSmall = FileTool.ReadImageFile(dress.Value.Replace("jpg", "lf"))
                                        .ZoomImage(100, 130, true, Color.LightGray);
                                    e.Graphics.DrawImage(imageSmall, new PointF(x, y));
                                    e.Graphics.DrawString(dress.Key, new Font("宋体", 7), new SolidBrush(Color.Black),
                                        new PointF(x, y + 140));
                                    x += 130;
                                    j++;
                                }
                            }
                        }
                    }

                    e.Graphics.DrawString(@"备注：", new Font("宋体", 14), new SolidBrush(Color.Black),
                        new PointF(50, y + 200));
                    if (txtMemery.Text.Length <= 45)
                    {
                        e.Graphics.DrawString(txtMemery.Text, new Font("宋体", 10), new SolidBrush(Color.Black),
                            new PointF(100, y + 203));
                    }
                    else if (txtMemery.Text.Length > 45 && txtMemery.Text.Length <= 90)
                    {
                        e.Graphics.DrawString(txtMemery.Text.Substring(0, 45), new Font("宋体", 10),
                            new SolidBrush(Color.Black),
                            new PointF(100, y + 203));
                        e.Graphics.DrawString(txtMemery.Text.Substring(45, txtMemery.Text.Length - 45),
                            new Font("宋体", 10),
                            new SolidBrush(Color.Black), new PointF(100, y + 223));
                    }
                    else if (txtMemery.Text.Length > 90)
                    {
                        e.Graphics.DrawString(txtMemery.Text.Substring(0, 45), new Font("宋体", 10),
                            new SolidBrush(Color.Black),
                            new PointF(100, y + 203));
                        e.Graphics.DrawString(txtMemery.Text.Substring(45, 45),
                            new Font("宋体", 10),
                            new SolidBrush(Color.Black), new PointF(100, y + 223));
                        e.Graphics.DrawString(txtMemery.Text.Substring(90, txtMemery.Text.Length - 90),
                            new Font("宋体", 10),
                            new SolidBrush(Color.Black), new PointF(100, y + 243));
                    }
                    e.Graphics.DrawString(@"礼服师：" + Information.CurrentUser.EmployeeName, new Font("宋体", 14),
                        new SolidBrush(Color.Black),
                        new PointF(50, y + 280));
                    e.Graphics.DrawString(@"出库时间：" + AllKindsData.ShootDate, new Font("宋体", 14),
                        new SolidBrush(Color.Black),
                        new PointF(250, y + 280));
                    e.Graphics.DrawString(@"顾客确认签字:", new Font("宋体", 14), new SolidBrush(Color.Black),
                        new PointF(50, y + 320));
                }
                if (_iPage == 2) //换页
                {
                    e.Graphics.DrawString(@"礼 服", new Font("宋体", 14), new SolidBrush(Color.Black), new PointF(40, 80));
                    _iPage = 1;
                    e.HasMorePages = false;
                    x = 130;
                    y = 135;
                    int h = 0;
                    if (AllKindsData.ChoosedDressInfo == null) return;
                    foreach (var dress in AllKindsData.ChoosedDressInfo)
                    {
                        if (h < j)
                        {
                            h++;
                            continue;
                        }
                        else
                        {
                            if (h % 5 == 0 && h != 0)
                            {
                                x = 120;
                                y += 160;
                                Image imageSmall = FileTool.ReadImageFile(dress.Value.Replace("jpg", "lf"))
                                    .ZoomImage(100, 130, true, Color.LightGray);
                                e.Graphics.DrawImage(imageSmall, new PointF(x, y));
                                e.Graphics.DrawString(dress.Key, new Font("宋体", 9), new SolidBrush(Color.Black),
                                    new PointF(x, y + 140));
                                x += 120;
                                h++;
                            }
                            else
                            {
                                Image imageSmall = FileTool.ReadImageFile(dress.Value.Replace("jpg", "lf"))
                                    .ZoomImage(100, 130, true, Color.LightGray);
                                e.Graphics.DrawImage(imageSmall, new PointF(x, y));
                                e.Graphics.DrawString(dress.Key, new Font("宋体", 9), new SolidBrush(Color.Black),
                                    new PointF(x, y + 140));
                                x += 120;
                                h++;
                            }
                        }
                    }

                    e.Graphics.DrawString(@"备注：", new Font("宋体", 14), new SolidBrush(Color.Black),
                        new PointF(50, y + 200));
                    if (txtMemery.Text.Length <= 45)
                    {
                        e.Graphics.DrawString(txtMemery.Text, new Font("宋体", 10), new SolidBrush(Color.Black),
                            new PointF(100, y + 203));
                    }
                    else if (txtMemery.Text.Length > 45 && txtMemery.Text.Length <= 90)
                    {
                        e.Graphics.DrawString(txtMemery.Text.Substring(0, 45), new Font("宋体", 10),
                            new SolidBrush(Color.Black),
                            new PointF(100, y + 203));
                        e.Graphics.DrawString(txtMemery.Text.Substring(45, txtMemery.Text.Length - 45),
                            new Font("宋体", 10),
                            new SolidBrush(Color.Black), new PointF(100, y + 223));
                    }
                    else if (txtMemery.Text.Length > 90)
                    {
                        e.Graphics.DrawString(txtMemery.Text.Substring(0, 45), new Font("宋体", 10),
                            new SolidBrush(Color.Black),
                            new PointF(100, y + 203));
                        e.Graphics.DrawString(txtMemery.Text.Substring(45, 45),
                            new Font("宋体", 10),
                            new SolidBrush(Color.Black), new PointF(100, y + 223));
                        e.Graphics.DrawString(txtMemery.Text.Substring(90, txtMemery.Text.Length - 90),
                            new Font("宋体", 10),
                            new SolidBrush(Color.Black), new PointF(100, y + 243));
                    }
                    e.Graphics.DrawString(@"礼服师：" + Information.CurrentUser.EmployeeName, new Font("宋体", 14),
                        new SolidBrush(Color.Black),
                        new PointF(50, y + 280));
                    e.Graphics.DrawString(@"出库时间：" + AllKindsData.ShootDate, new Font("宋体", 14),
                        new SolidBrush(Color.Black),
                        new PointF(250, y + 280));
                    e.Graphics.DrawString(@"顾客确认签字:", new Font("宋体", 14), new SolidBrush(Color.Black),
                        new PointF(50, y + 320));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"预览礼服清单出错！" + ex);
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void clstDressStyle_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (AllKindsData.ChoosedDressStyle == null)
            {
                AllKindsData.ChoosedDressStyle = new List<string>();
            }
            if (e.NewValue == CheckState.Checked && !AllKindsData.ChoosedDressStyle.Contains(clstDressStyle.Text))
            {
                AllKindsData.ChoosedDressStyle.Add(clstDressStyle.Text);
            }
            else
            {
                if (AllKindsData.ChoosedDressStyle.Contains(clstDressStyle.Text))
                {
                    AllKindsData.ChoosedDressStyle.Remove(clstDressStyle.Text);
                }
            }
        }

        private void txtKeys_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataTable dtPath = ErpService.DressManagement.DressesManage(txtKeys.Text.Trim()).Tables[0];
                    string imgPath = dtPath.Rows[0]["DressImagePath"].ToString();
                    string themeName = dtPath.Rows[0]["Themename"].ToString();
                    if (string.IsNullOrEmpty(imgPath))
                    {
                        MessageBox.Show(@"没有礼服照片，不能加入购物车");
                        return;
                    }
                    if (string.IsNullOrEmpty(themeName))
                    {
                        MessageBox.Show(@"该礼服没有绑定风格，不能加入购物车");
                        return;
                    }

                    //加载到同穿显示
                    while (dgvSameChoosedDress.RowCount != 0)
                    {
                        dgvSameChoosedDress.Rows.RemoveAt(0);
                    }
                    DataTable dtSame =
                        ErpService.DressManagement.GetSameChoosedDress(txtKeys.Text, AllKindsData.ShootDate).Tables[0];
                    foreach (DataRow row in dtSame.Rows)
                    {
                        dgvSameChoosedDress.Rows.Add(row.ItemArray);
                    }
                    dtSame.Dispose();

                    DataTable dtEnable =
                        ErpService.DressManagement.DressEnableUse(txtKeys.Text,
                            AllKindsData.ShootDate).Tables[0];
                    if (dtEnable.Rows.Count == 0)
                    {
                        MessageBox.Show(@"礼服已送洗，无法加入购物车！");
                        return;
                    }
                    if (Convert.ToInt32(dtEnable.Rows[0]["DressRemainCnt"]) == 0)
                    {
                        MessageBox.Show(@"次数已用完！");
                        return;
                    }
                    if (dtEnable.Rows[0]["dressStatus"].Equals(DressState.外景出库))
                    {
                        MessageBox.Show(@"该礼服已外景出库！");
                        return;
                    }
                    if (
                        !ErpService.DressManagement.ChoosedInsert(txtKeys.Text,
                            AllKindsData.OrderNo, Information.CurrentUser.EmployeeNO,
                            Information.CurrentUser.EmployeeName,
                            AllKindsData.OrderVenueNo, AllKindsData.CustomerNo,
                            AllKindsData.ShootDate, BaseData.DressId))
                    {
                        MessageBox.Show(@"数据库操作失败！");
                        return;
                    }
                    //状态更改
                    Dictionary<string, string> dressInfo = new Dictionary<string, string>
                        {
                            {txtKeys.Text, dtEnable.Rows[0]["DressStatus"].SafeDbValue<string>()} //礼服编号+改前状态
                        };
                    if (dtEnable.Rows[0]["DressNumberOfUsedToday"].SafeDbValue<Int32>() == 1)
                    {
                        ErpService.DressManagement.UpdateDressState(dressInfo, @"外景出库",
                            Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO2);
                    }
                    else
                    {
                        ErpService.DressManagement.UpdateDressState(dressInfo, DressState.拍照中.ToString(),
                            Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO2);
                    }
                    //临时礼服数据保存
                    if (AllKindsData.ChoosedDressInfo == null)
                    {
                        AllKindsData.ChoosedDressInfo = new Dictionary<string, string>();
                    }
                    if (!AllKindsData.ChoosedDressInfo.ContainsKey(themeName + @"-" + txtKeys.Text.Trim()))
                    {
                        AllKindsData.ChoosedDressInfo.Add(themeName + @"-" + txtKeys.Text.Trim(), imgPath);
                    }
                    Image img = FileTool.ReadImageFile(imgPath.Replace("jpg", "lf").Replace("JPG", "lf")).ZoomImage(imgChoosedDress.ImageSize, true, Color.LightGray);
                    imgChoosedDress.Images.Add(txtKeys.Text, img);
                    ListViewItem lst = new ListViewItem
                    {
                        ImageKey = txtKeys.Text,
                        Name = txtKeys.Text,
                        Tag = imgPath,
                        Text = themeName + @"-" + txtKeys.Text
                    };
                    lvwChoosedDress.BeginUpdate();
                    lvwChoosedDress.Items.Add(lst);
                    lvwChoosedDress.EndUpdate();
                    lvwChoosedDress.Refresh();
                    MessageBox.Show(@"加入购物车成功！");
                    dtEnable.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void lvwScenes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (AllKindsData.SceneInfo == null)
            {
                AllKindsData.SceneInfo = new Dictionary<string, string>();
            }

            for (int i = 0; i < lvwScenes.Items.Count; i++)
            {
                string key = lvwScenes.Items[i].Text;
                string value = lvwScenes.Items[i].Tag.ToString();
                if (lvwScenes.Items[i].Checked)
                {
                    if (!AllKindsData.SceneInfo.ContainsKey(key))
                    {
                        AllKindsData.SceneInfo.Add(key, value);
                        var img = FileTool.ReadImageFile(value);
                        imgChoosedDress.Images.Add(value,
                            img.ZoomImage(imgChoosedDress.ImageSize, true, Color.LightGray));
                        ListViewItem lst = new ListViewItem
                        {
                            ImageKey = value,
                            Text = key
                        };
                        lvwChoosedDress.BeginUpdate();
                        lvwChoosedDress.Items.Add(lst);
                        lvwChoosedDress.EndUpdate();
                        lvwChoosedDress.Refresh();
                    }
                }
                else
                {
                    if (AllKindsData.SceneInfo.ContainsKey(key))
                    {
                        AllKindsData.SceneInfo.Remove(key);
                        foreach (ListViewItem itemView in lvwChoosedDress.Items)
                        {
                            if (itemView.Text == key)
                            {
                                lvwChoosedDress.Items.Remove(itemView);
                                lvwChoosedDress.Refresh();
                            }
                        }
                    }
                }
            }
        }

        private void tabShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabShow.SelectedIndex == 1)
            {
                DataTable dsTable = ErpService.DressManagement.GetDressStyle("50").Tables[0];
                clstDressStyle.DataSource = dsTable;
                clstDressStyle.DisplayMember = @"RuleName";
                clstDressStyle.ValueMember = @"RuleNumbers";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (AllKindsData.SceneInfo.Count == 0)
                {
                    MessageBox.Show(@"未选择一个场景，不能出库！");
                    return;
                }
                ErpService.DressManagement.AddOrderDressInfo(AllKindsData.OrderNo, AllKindsData.VenueDepartmentNo,
                    Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName, AllKindsData.ShootDate, txtMemery.Text, AllKindsData.SceneInfo);
                MessageBox.Show(@"选衣完成！");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"数据库操作失败！" + ex);
                return;
            }
        }

        private void 外景出库Tsm_Click(object sender, EventArgs e)
        {
            string dressKey = lvwChoosedDress.SelectedItems[0].Text;
            int dex = dressKey.LastIndexOf("-", StringComparison.Ordinal) + 1;
            string dressBarcode = dressKey.Substring(dex, dressKey.Length - dex);

            //礼服信息
            Dictionary<string, string> dressInfo = new Dictionary<string, string>
                    {
                        {dressBarcode, @"拍照中"}
                    };
            //状态更改
            if (ErpService.DressManagement.UpdateDressState(dressInfo, @"外景出库",
                Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO2))
            {
                MessageBox.Show(@"外景出库成功！");
            }
            else
            {
                MessageBox.Show(@"操作失败！");
            }
        }

        private void 补拍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dressKey = lvwChoosedDress.SelectedItems[0].Text;
            int dex = dressKey.LastIndexOf("-", StringComparison.Ordinal) + 1;
            string dressBarcode = dressKey.Substring(dex, dressKey.Length - dex);
            if (ErpService.DressManagement.UpdateDressDate(AllKindsData.OrderNo, dressBarcode,Information.CurrentUser.EmployeeNO2,Information.CurrentUser.EmployeeName, AllKindsData.ShootDate))
            {
                MessageBox.Show(@"同步成功！");
            }
            else
            {
                MessageBox.Show(@"同步失败，重新操作！");
            }
        }

        private void lvwDresses_MouseEnter(object sender, EventArgs e)
        {
            if (task == null)
            {
                return;
            }
            while (task != null && task.IsCompleted)
            {
                btnSearch.Enabled = true;
                task = null;
            }
        }

        private void lvwDresses_MouseLeave(object sender, EventArgs e)
        {
            if (task == null)
            {
                return;
            }
            while (task != null && task.IsCompleted)
            {
                btnSearch.Enabled = true;
                task = null;
            }
        }
    }
}
