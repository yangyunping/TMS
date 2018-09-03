using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Management;
using GoldenLady.Utility;

namespace GoldenLady.Dress
{
    public partial class frmPrinter : Form
    {
        public frmPrinter()
        {
            InitializeComponent(); 
            InitPrinter();
        }
        
        /// <summary>
        /// 打印机
        /// </summary>
        private void InitPrinter()
        {
            ManagementObjectSearcher query;
            ManagementObjectCollection queryCollection;
            string _classname = "SELECT * FROM Win32_Printer";

            query = new ManagementObjectSearcher(_classname);
            queryCollection = query.Get();

            cmbBB.Items.Clear();
            cmbTM.Items.Clear();

            foreach (ManagementObject mo in queryCollection)
            {
                cmbTM.Items.Add(mo["Name"].ToString());
                cmbBB.Items.Add(mo["Name"].ToString());
            }
            cmbBB.Text = PrinterManager.CashPrinter.Name;
            cmbTM.Text = PrinterManager.NormalPrinter.Name;
        }

        private void cmbBB_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrinterManager.CashPrinter.Save(cmbBB.Text);
        }

        private void cmbTM_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrinterManager.NormalPrinter.Save(cmbTM.Text);
        }
    }
}
