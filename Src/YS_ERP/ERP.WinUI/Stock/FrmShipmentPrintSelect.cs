using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;

namespace CZZD.ERP.WinUI
{
    public partial class FrmShipmentPrintSelect : FrmBase
    {
        private DialogResult _dialogResult = DialogResult.Cancel;
        private string _currentConduction = "";
        private DataTable _currentDt = new DataTable();

        public string resultValue = "";


        public FrmShipmentPrintSelect()
        {
            InitializeComponent();
        }

        public FrmShipmentPrintSelect(string conduction)
        {
            this._currentConduction = conduction;
            InitializeComponent();
        }

        private void FrmShipmentPrintSelect_Load(object sender, EventArgs e)
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            DataSet ds = bShipment.GetShipMentPrintSelectList(_currentConduction);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
        }

        private void reSetCurrentDt()
        {
            int i = 1;
            if (_currentDt != null)
            {
                _currentDt.Columns.Add("CHK", Type.GetType("System.Boolean"));
                foreach (DataRow dr in _currentDt.Rows)
                {
                    dr["CHK"] = false;
                    dr["No"] = i++;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShipmentPrintSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _dialogResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvData.Rows) 
            {
                if (Convert.ToBoolean(dgvr.Cells["CHK"].Value))
                {
                    resultValue += "'" + Convert.ToString(dgvr.Cells["SLIP_NUMBER"].Value) + "',";
                }
            }

            if (resultValue.Length > 0)
            {
                resultValue = resultValue.Substring(0, resultValue.Length - 1);
                _dialogResult = DialogResult.OK;
                this.Close();
            }
            else 
            {
                MessageBox.Show("请先选择记录", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }//end class
}
