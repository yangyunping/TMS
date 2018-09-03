using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Utility;
using GoldenLady.Utility.ToolForm;
using GoldenLadyWS;

namespace GoldenLady.Dress.Utils
{
    public static class Methods
    {
        private static int _i = 0;

        /// <summary>
        /// 照片切换方法
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="pictureBox"></param>
        /// <param name="e"></param>
        public static void PicClickEvent(List<string> strings, PictureBox pictureBox, MouseEventArgs e)
        {
            pictureBox.Image = null;
            if (strings == null)
            {
                return;
            }
            if (e.Location.X > pictureBox.Width >> 1)
            {
                if (_i < strings.Count && _i >= 0)
                {
                    pictureBox.Image = FileTool.ReadImageFile(strings[_i]).ZoomImage(pictureBox.Size);
                    _i++;
                }
                else
                {
                    _i = 0;
                    pictureBox.Image = FileTool.ReadImageFile(strings[_i]).ZoomImage(pictureBox.Size);
                }
            }
            else
            {
                if (_i < strings.Count && _i >= 0)
                {
                    pictureBox.Image = FileTool.ReadImageFile(strings[_i]).ZoomImage(pictureBox.Size);
                    _i--;
                }
                else
                {
                    _i = strings.Count - 1;
                    pictureBox.Image = FileTool.ReadImageFile(strings[_i]).ZoomImage(pictureBox.Size);
                }
            }
        }

        /// <summary>
        /// 样照展示
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="listView"></param>
        public static void AllShow(DataTable dt, DoubleBufferListView listView)
        {
            Size imgSize = listView.LargeImageList.ImageSize;
            string ImageText;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            string[] imagePath = dt.Rows[0]["DressImagePath"].SafeDbValue<string>().Split(Convert.ToChar(@"\"));
            Ping strPing = new Ping();
            PingReply pingReply = strPing.Send(imagePath[2]);
            if (pingReply != null && pingReply.Status != IPStatus.Success)
            {
                MessageBox.Show(@"无法访问照片路径！");
                return;
            }
            for (var j = 0; j < dt.Rows.Count; j++)
            {
                string imgPath = dt.Rows[j]["DressImagePath"].SafeDbValue<string>();
                string dressbarcode = dt.Rows[j]["DressBarCode"].SafeDbValue<string>();
                string dressCustomCode = dt.Rows[j]["DressCustomCode"].SafeDbValue<string>();
                string renPrice = dt.Rows[j]["DressRentPrice"].SafeDbValue<string>();
                string salePrice = dt.Rows[j]["DressSalePrice"].SafeDbValue<string>();

                if (string.IsNullOrEmpty(dressCustomCode)) //自编码
                {
                    ImageText = dressbarcode;
                }
                else
                {
                    ImageText = dressCustomCode + @"_" + dressbarcode;
                }
                AllKindsData.ImgPathLst.Add(imgPath);
                string imgLfPath = Path.Combine(Path.GetDirectoryName(imgPath),
                    Path.GetFileNameWithoutExtension(imgPath) + ".lf");
                ListViewItem lst = new ListViewItem
                {
                    ImageKey = dressbarcode,
                    Text = ImageText,
                    Tag = imgPath + @"," + renPrice + @"," + salePrice,
                    Name = dressbarcode
                };
                Image itemImg = FileTool.ReadImageFile(imgLfPath).ZoomImage(imgSize, true, Color.LightGray);
                listView.Invoke(new Action(() =>
                {
                    if (itemImg != null)
                    {
                        listView.LargeImageList.Images.Add(dressbarcode, itemImg);
                        itemImg.Dispose();
                    }
                    listView.Items.Add(lst);
                }));
            }
            dt.Dispose();
        }

        /// <summary>
        /// 照片放大
        /// </summary>
        /// <param name="listView"></param>
        public static void PhotoLarge(ListView listView)
        {
            if (listView.SelectedItems.Count == 0)
            {
                return;
            }
            int i = 0;
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Selected)
                {
                    item.Checked = false;
                    var iamgePath = item.Tag.ToString().Split(',')[0];
                    new FrmExampleShow(iamgePath, i).ShowDialog();
                }
                i++;
            }
        }

        /// <summary>
        /// 双击已选操作
        /// </summary>
        public static void ChoosedDoubleClick(ListView unChooseLstView, ListView choosedLstView, ImageList imgList)
        {
            try
            {
                AllKindsData.ChoosedManDressInfo.Remove(choosedLstView.SelectedItems[0].Text.Trim());
                Image img = FileTool.ReadImageFile(choosedLstView.SelectedItems[0].Tag.ToString());
                int dex =
                    choosedLstView.SelectedItems[0].Text.Trim().LastIndexOf("-", StringComparison.Ordinal) + 1;
                string barcode = choosedLstView.SelectedItems[0].Text.Trim()
                    .Substring(dex, choosedLstView.SelectedItems[0].Text.Length - dex);
                imgList.Images.Add(img.ZoomImage(imgList.ImageSize, true, Color.LightGray));

                if (ErpService.DressManagement.DeleteChoosedDress(barcode, @" and  DressEmployeeNO='" + Information.CurrentUser.EmployeeNO + "'", AllKindsData.OrderNo, Information.CurrentUser.EmployeeName))
                {
                    ListViewItem lst = new ListViewItem
                    {
                        ImageIndex = imgList.Images.Count - 1,
                        Tag = choosedLstView.SelectedItems[0].Tag.ToString(),
                        Text = barcode
                    };
                    unChooseLstView.BeginUpdate();
                    unChooseLstView.Items.Add(lst);
                    unChooseLstView.EndUpdate();
                    unChooseLstView.Refresh();

                    choosedLstView.Items.RemoveAt(choosedLstView.SelectedIndices[0]);
                    choosedLstView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"" + ex);
                return;
            }
        }

        /// <summary>
        /// 双击未选操作
        /// </summary>
        public static void UnChooseDoubleClick(ListView unChoosedLstView, ListView chooseLstView, ImageList imgList,
            string clstString)
        {
            if (AllKindsData.ChoosedManDressInfo == null)
            {
                AllKindsData.ChoosedManDressInfo = new Dictionary<string, string>();
            }
            string path = unChoosedLstView.SelectedItems[0].Tag.ToString();
            if (
                !AllKindsData.ChoosedManDressInfo.ContainsKey(clstString + @"-" +
                                                              unChoosedLstView.SelectedItems[0].Text))
            {
                AllKindsData.ChoosedManDressInfo.Add(clstString + @"-" + unChoosedLstView.SelectedItems[0].Text, path);
            }

            Image image = FileTool.ReadImageFile(path);
            imgList.Images.Add(image.ZoomImage(imgList.ImageSize, true, Color.LightGray));
            if (
                !ErpService.DressManagement.ChoosedInsert(unChoosedLstView.SelectedItems[0].Text.ToString(),
                    AllKindsData.OrderNo, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName,
                    Information.CurrentUser.EmployeeDepartmentNO, AllKindsData.CustomerNo,
                    AllKindsData.ShootDate, BaseData.ManDressId))
            {
                MessageBox.Show(@"数据操作出错！");
                return;
            }
            ListViewItem lstItem = new ListViewItem()
            {
                ImageIndex = imgList.Images.Count - 1,
                Tag = path,
                Text = clstString + @"-" + unChoosedLstView.SelectedItems[0].Text.ToString()
            };
            chooseLstView.BeginUpdate();
            chooseLstView.Items.Add(lstItem);
            chooseLstView.EndUpdate();
            chooseLstView.Refresh();

            unChoosedLstView.Items.RemoveAt(unChoosedLstView.SelectedIndices[0]);
            unChoosedLstView.Refresh();
        }

        /// <summary>
        /// 创建缓存文件夹并复制原照片
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="type"></param>
        public static void FilePhotoCache(DataTable dt, string type)
        {
            Dictionary<string, string> lstPathes = new Dictionary<string, string>();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                lstPathes.Add(
                    dt.Rows[j]["VenueName"].SafeDbValue<string>() + "-" + dt.Rows[j]["Name"].SafeDbValue<string>(),
                    dt.Rows[j]["PhotoPath"].SafeDbValue<string>());
            }
            string newPathes = Path.Combine(DressManager.ConfigManager.Config.CachePhotoDirectory, type);
            try
            {
                if (Directory.Exists(newPathes))
                {
                    foreach (var lstPath in lstPathes)
                    {
                        if (!string.Join(",", Directory.GetFiles(newPathes)).Contains(lstPath.Key))
                        {
                            File.Copy(lstPath.Value, newPathes + "\\" + lstPath.Key + ".jpg", true);
                            using (
                                Image imgSrc = FileTool.ReadImageFile(newPathes + "\\" + lstPath.Key + ".jpg"),
                                    img = imgSrc.ZoomImage(DressManager.ConfigManager.Config.ThumbSize, true,
                                        Color.LightGray))
                            {
                                img.Save(DressManager.GetThumb(newPathes + "\\" + lstPath.Key + ".jpg"),
                                    ImageFormat.Jpeg);
                            }
                        }
                    }
                }
                if (!Directory.Exists(newPathes))
                {
                    Directory.CreateDirectory(newPathes);

                    foreach (var lstPath in lstPathes)
                    {
                        File.Copy(lstPath.Value, newPathes + "\\" + lstPath.Key + ".jpg", true);
                    }
                    DressManager.GenerateThumb(Directory.GetFiles(newPathes));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"主题风格场景照片缓存失败!" + ex);
                return;
            }
        }
    }
}
