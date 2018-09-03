using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GoldenLady.Utility.DataStructure
{
    /// <summary>
    /// 用于ListView展示图片的结构拓展
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public class ListViewImageItems
    {
        /// <summary>
        /// 图片对应的文件路径
        /// </summary>
        public readonly List<string> Paths = new List<string>();
        /// <summary>
        /// 与ListView控件对接的对象，包含图片名称和对应图片的索引
        /// </summary>
        public readonly List<ListViewItem> Items = new List<ListViewItem>();
        /// <summary>
        /// 图片内存对象
        /// </summary>
        public readonly ImageList Images = new ImageList
        {
            ColorDepth = ColorDepth.Depth32Bit
        };

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="filePath">图片文件路径</param>
        public virtual void Add(string filePath)
        {
            Paths.Add(filePath);
            Images.Images.Add(FileTool.ReadImageFile(filePath));
            Items.Add(new ListViewItem(Path.GetFileNameWithoutExtension(filePath), Items.Count));
        }
        /// <summary>
        /// 批量添加照片
        /// </summary>
        /// <param name="filePaths">照片文件路径</param>
        public virtual void AddRange(IEnumerable<string> filePaths)
        {
            foreach(string filePath in filePaths)
            {
                Add(filePath);
            }
        }
        /// <summary>
        /// 移除图片
        /// </summary>
        /// <param name="idx">图片索引</param>
        public virtual void RemoveAt(int idx)
        {
            Paths.RemoveAt(idx);
            Images.Images.RemoveAt(idx);
            Items.RemoveAt(idx);

            // 移除后，对Item的对应图片索引进行调整
            for(int i = idx; i < Items.Count; i++)
            {
                Items[i].ImageIndex = idx;
            }
        }
        /// <summary>
        /// 批量移除图片
        /// </summary>
        /// <param name="indices">图片索引</param>
        public virtual void RemoveRange(int[] indices)
        {
            // 从索引最大的开始移除，防止错序
            Array.Sort(indices, Comparer.Default);
            Array.Reverse(indices); 
            foreach(int index in indices)
            {
                Paths.RemoveAt(index);
                Images.Images.RemoveAt(index);
                Items.RemoveAt(index);
            }
            for(int idx = indices.Last(); idx < Items.Count; idx++)
            {
                Items[idx].ImageIndex = idx;
            }
        }
        /// <summary>
        /// 清空所有图片
        /// </summary>
        public virtual void Clear()
        {
            Images.Images.Clear();
            Items.Clear();
            Paths.Clear();
        }
    }
}