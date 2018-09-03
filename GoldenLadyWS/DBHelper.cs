using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace GoldenLadyWS
{
    /// <summary>
    /// 格式化dgv中Cell的值，依据为dataPropertyName
    /// </summary>
    /// <param name="dataPropertyName"></param>
    /// <param name="cellValue"></param>
    /// <returns></returns>
    public delegate object FormatCellValue(string dataPropertyName, object cellValue);
    public class DBHelper
    {
        //public static bool ExportDataGridview(DataGridView gridView, bool isShowExcele)
        //{
        //    if (gridView.Rows.Count == 0)
        //    {
        //        return false;
        //    }
        //    //建立Excel对象

        //    Excel.Application excel = new Excel.Application();
        //    excel.Application.Workbooks.Add(true);
        //    excel.Visible = isShowExcele;
        //    //生成字段名称
        //    for (int i = 0; i < gridView.ColumnCount; i++)
        //    {
        //        excel.Cells[1, i + 1] = gridView.Columns[i].HeaderText;
        //    }
        //    //填充数据
        //    for (int i = 0; i < gridView.RowCount - 1; i++)
        //    {
        //        for (int j = 0; j < gridView.ColumnCount; j++)
        //        {
        //            if (gridView[j, i].Value == typeof(string))
        //            {
        //                excel.Cells[i + 2, j + 1] = "" + gridView[i, j].Value.ToString();
        //            }
        //            else
        //            {
        //                excel.Cells[i + 2, j + 1] = gridView[j, i].Value.ToString();
        //            }
        //        }
        //    }
        //    return true;
        //}

        public static bool ExportDataGridView(DataGridView dgv)
        {
            //////建立Excel对象
            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //excel.Application.Workbooks.Add(true);
            //excel.Cells.NumberFormatLocal = "@";
            ////生成字段名称
            //for (int i = 0; i < dgv.ColumnCount; i++)
            //{
            //    excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            //}
            ////填充数据
            //for (int i = 0; i < dgv.RowCount; i++)
            //{
            //    for (int j = 0; j < dgv.ColumnCount; j++)
            //    {
            //        object obj = dgv.Rows[i].Cells[j].Value;
            //        if (obj.GetType() == typeof(string))
            //        {
            //            //excel.Cells.Style = 
            //            excel.Cells[i + 2, j + 1] = "" + obj.ToString();
            //        }
            //        else
            //        {
            //            excel.Cells[i + 2, j + 1] = obj;
            //            //excel.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j]
            //        }
            //    }
            //}
            //excel.Visible = true;
            //return true;
            return ExportDataGridView(dgv, null);
        }
        public static bool ExportDataGridView(DataGridView dgv, FormatCellValue cellValue)
        {
            ////建立Excel对象
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Cells.NumberFormatLocal = "@";
            string[] dataPropertyNames = new string[dgv.ColumnCount];
            //生成字段名称
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                dataPropertyNames[i] = dgv.Columns[i].DataPropertyName;
            }
            //填充数据
            for (int i = 0; i < dgv.RowCount; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    object obj = dgv.Rows[i].Cells[j].Value;
                    if (cellValue != null)
                    {
                        obj = cellValue.Invoke(dataPropertyNames[j], obj);
                    }
                    if (obj.GetType() == typeof(string))
                    {
                        //excel.Cells.Style = 
                        excel.Cells[i + 2, j + 1] = "" + obj.ToString();
                    }
                    else
                    {
                        excel.Cells[i + 2, j + 1] = obj;
                        //excel.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j]
                    }
                }
            }
            excel.Visible = true;
            return true;
        }
        /// <summary>
        /// 导出多个DataGridView控件的数据到Excel
        /// Caijinsong 2014-10-31
        /// </summary>
        /// <param name="Dgvs">DataGridView控件数组</param>
        /// <param name="SheetNames">对应的名称</param>
        /// <returns></returns>
        public static bool ExportDataGridView(DataGridView[] Dgvs, string[] SheetNames)
        {
            //判断给予的DataGridVeiw数组不能为null，长度也不能为0
            if (Dgvs != null && Dgvs.Length > 0)
            {
                Excel.Application app = null;//Excel对象
                Excel.Workbook wb = null;
                int index = 0;//DataGridVeiw数组在索引为Index时有数据，也就是从有数据的DataGridView控件开始导。
                for (index = 0; index < Dgvs.Length; ++index)
                {
                    if (Dgvs[index].Rows.Count > 0)
                    {
                        //有数据就结束并初始化Excel对象
                        try
                        {
                        	app = new Excel.ApplicationClass();
                            app.Visible = false;//使Excel不可视
                            app.ScreenUpdating = false;//设置此开关能大大提高效率。写完后如要可见，再设置此属性为真刷新屏幕。
                            wb = app.Workbooks.Add(true);
                        }
                        catch
                        {
                            throw new Exception("Excel对象初始化失败。");
                        }
                        break;
                    }
                }
                int worksheetIndex = 1;//worksheet的从1开始的索引
                //从索引为Index的DataGridView控件开始导
                for (int i = index; i < Dgvs.Length; ++i )
                {
                    Excel.Worksheet ws = null;
                    if (wb.Worksheets.Count >= worksheetIndex)
                    {
                        ws = wb.Worksheets[worksheetIndex] as Excel.Worksheet;
                    }
                    else
                    {
                        ws = (Excel.Worksheet)wb.Worksheets.Add(Missing.Value, Missing.Value, 1, Missing.Value);
                    }
                    if(SheetNames != null && SheetNames.Length>i)
                    {
                        ws.Name = SheetNames[i];
                    }
                    for (int j = 0; j < Dgvs[i].Columns.Count; ++j )
                    {
                        ws.Cells[1, j + 1] = Dgvs[i].Columns[j].HeaderText;
                    }
                    for (int n = 0; n < Dgvs[i].Rows.Count;++n )
                    {
                        for (int m = 0; m < Dgvs[i].Columns.Count; ++m)
                        {
                            ws.Cells[n + 2, m + 1] = Dgvs[i][m, n].Value;
                        }
                    }
                    worksheetIndex++;
                }
                app.ScreenUpdating = true;
                app.Visible = true;
                return true;
            }
            return false;
        }

    }
}
