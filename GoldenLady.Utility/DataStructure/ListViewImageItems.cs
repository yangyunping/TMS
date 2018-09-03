using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GoldenLady.Utility.DataStructure
{
    /// <summary>
    /// ����ListViewչʾͼƬ�Ľṹ��չ
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public class ListViewImageItems
    {
        /// <summary>
        /// ͼƬ��Ӧ���ļ�·��
        /// </summary>
        public readonly List<string> Paths = new List<string>();
        /// <summary>
        /// ��ListView�ؼ��ԽӵĶ��󣬰���ͼƬ���ƺͶ�ӦͼƬ������
        /// </summary>
        public readonly List<ListViewItem> Items = new List<ListViewItem>();
        /// <summary>
        /// ͼƬ�ڴ����
        /// </summary>
        public readonly ImageList Images = new ImageList
        {
            ColorDepth = ColorDepth.Depth32Bit
        };

        /// <summary>
        /// ���ͼƬ
        /// </summary>
        /// <param name="filePath">ͼƬ�ļ�·��</param>
        public virtual void Add(string filePath)
        {
            Paths.Add(filePath);
            Images.Images.Add(FileTool.ReadImageFile(filePath));
            Items.Add(new ListViewItem(Path.GetFileNameWithoutExtension(filePath), Items.Count));
        }
        /// <summary>
        /// ���������Ƭ
        /// </summary>
        /// <param name="filePaths">��Ƭ�ļ�·��</param>
        public virtual void AddRange(IEnumerable<string> filePaths)
        {
            foreach(string filePath in filePaths)
            {
                Add(filePath);
            }
        }
        /// <summary>
        /// �Ƴ�ͼƬ
        /// </summary>
        /// <param name="idx">ͼƬ����</param>
        public virtual void RemoveAt(int idx)
        {
            Paths.RemoveAt(idx);
            Images.Images.RemoveAt(idx);
            Items.RemoveAt(idx);

            // �Ƴ��󣬶�Item�Ķ�ӦͼƬ�������е���
            for(int i = idx; i < Items.Count; i++)
            {
                Items[i].ImageIndex = idx;
            }
        }
        /// <summary>
        /// �����Ƴ�ͼƬ
        /// </summary>
        /// <param name="indices">ͼƬ����</param>
        public virtual void RemoveRange(int[] indices)
        {
            // ���������Ŀ�ʼ�Ƴ�����ֹ����
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
        /// �������ͼƬ
        /// </summary>
        public virtual void Clear()
        {
            Images.Images.Clear();
            Items.Clear();
            Paths.Clear();
        }
    }
}