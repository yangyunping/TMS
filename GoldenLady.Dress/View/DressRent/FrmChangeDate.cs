using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmChangeDate : Form
    {
        private Action<DateTime> _backDate;
        private Action _arrange;
        private bool _ok = false;
        public FrmChangeDate(DateTime dateTime, Action<DateTime> backChangedate,  Action arrange)
        {
            InitializeComponent();
            dtpChangeDate.Value = dateTime;
            _backDate = backChangedate;
            _arrange = arrange;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_arrange != null)
            {
                _arrange();
                _ok = true;
                this.Close();
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!_ok && MessageBox.Show(@"要放弃吗？", @"提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        private void dtpMarrydate_ValueChanged(object sender, EventArgs e)
        {
            if (_backDate != null)
            {
                _backDate(dtpChangeDate.Value);
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            dtpChangeDate.Value = dtpChangeDate.Value.AddDays(-1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtpChangeDate.Value = dtpChangeDate.Value.AddDays(1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
