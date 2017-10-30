using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmChoseReceipt : Form
    {

        public bool IsInstallments = false;
        public DateTime time = DateTime.Now;
        private DialogResult _result = DialogResult.Cancel;

        public FrmChoseReceipt()
        {
            InitializeComponent();
        }

        private void FrmChoseReceipt_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.DueData.Value = DateTime.Now;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rInstallments.Checked)
            {
                IsInstallments = true;
                time = DueData.Value;
            }
            _result = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChoseReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _result;
        }


    }//end class
}
