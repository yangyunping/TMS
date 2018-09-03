using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GoldenLady.Utility.DataStructure
{
    /// <summary>
    /// 用于PropertyGrid的可打开目录选择对话框的项目
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public class PropertyGridDirectoryItem : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if(provider != null) 
            {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof (IWindowsFormsEditorService));
                if(edSvc != null)
                {
                    FolderBrowserDialog dlg = new FolderBrowserDialog
                    {
                        RootFolder = Environment.SpecialFolder.Desktop
                    };
                    if(DialogResult.OK == dlg.ShowDialog())
                    {
                        return dlg.SelectedPath;
                    }
                }
            }
            return value;
        }
    }
}