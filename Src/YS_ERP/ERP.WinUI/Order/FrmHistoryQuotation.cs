using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Common;
using CZZD.ERP.Main;

namespace CZZD.ERP.WinUI
{
    public partial class FrmHistoryQuotation : FrmBase
    {
        private string _oldSlipNumber = "";
        public string historySlipNumber = "";
        private DialogResult _dialogResult = DialogResult.Cancel;

        public FrmHistoryQuotation()
        {
            InitializeComponent();
        }

        public FrmHistoryQuotation(string oldSlipNumber)
        {
            InitializeComponent();
            this._oldSlipNumber = oldSlipNumber;
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void FrmHistoryQuotation_Load(object sender, EventArgs e)
        {

            DataTable dt = bQuotation.GetHistoryQuotation(_oldSlipNumber).Tables[0];
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                dr["NO"] = i++;
            }
            for (int j = dt.Rows.Count; j < 8; j++)
            {
                dt.Rows.Add(dt.NewRow());
            }
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dgvData.DataSource = dt;
        }

        /// <summary>
        /// 页面关闭、取消操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 详细操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow dr = dgvData.SelectedRows[0];
                historySlipNumber = CConvert.ToString(dr.Cells["HISTORY_NUMBER"].Value);
                _dialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择操作行！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 页面关闭，设定反回状态
        /// </summary>
        private void FrmHistoryQuotation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _dialogResult;
        }


        /// <summary>
        /// 控制空行不能被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["NO"].Value == null || "".Equals(row.Cells["NO"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

    }//end class
}
