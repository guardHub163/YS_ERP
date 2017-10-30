using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionProcessWeight : FrmBase
    {
        public FrmProductionProcessWeight()
        {
            InitializeComponent();
        }
        private BProductionPlanSearch bProductionPlanSearch = new BProductionPlanSearch();
        private void FrmProductionProcessWeight_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 15;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string strWhere = GetConduction();
            DataTable dt = bProductionPlanSearch.GetProductionPlan(strWhere).Tables[0];
            if (dt.Rows.Count < 1)
            {
                txtSlipNumber.Clear();
                txtOrder.Clear();
                dgvData.DataSource = dt;
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                dgvData.DataSource = dt;
            }
            decimal weight = 0;

            foreach (DataRow row in dt.Rows)
            {
                weight += CConvert.ToDecimal(row["WEIGHT"].ToString());
            }
            txtTotal.Text = weight.ToString();
        }

        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" PROCESS_STATUS='{0}'", "1");

            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtOrder.Text.Trim()))
            {
                sb.AppendFormat(" AND ORDER_SLIP_NUNBER = '{0}'", txtOrder.Text.Trim());
            }

            return sb.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    row.Cells["No"].Value = e.RowIndex + 1;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable processDt = dgvData.DataSource as DataTable;

            if (processDt != null)
            {

                int result = CExport.DataTableToExcel(processDt, CConstant.WEIGHT_HEADER, CConstant.WEIGHT_COLUMNS, "WEIGHT", "WEIGHT");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == CConstant.EXPORT_FAILURE)
                {
                    MessageBox.Show("数据导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("没有可以导出的数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
