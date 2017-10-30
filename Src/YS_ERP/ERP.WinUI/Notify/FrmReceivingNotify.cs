using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmReceivingNotify : FrmBase
    {
        public FrmReceivingNotify()
        {
            InitializeComponent();
        }

        private void FrmReceivingNotify_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region dgvData初始化
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            #endregion

            btnSearch_Click(null, null);
        }

        #region 供应商
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Supplier", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSupplierCode.Text.Trim()))
            {
                BaseSupplierTable SupplierCode = new BaseSupplierTable();
                BSupplier bSupplier = new BSupplier();
                SupplierCode = bSupplier.GetModel(txtSupplierCode.Text);
                if (SupplierCode == null)
                {
                    txtSupplierCode.Focus();
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    MessageBox.Show("供应商编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtSupplierName.Text = SupplierCode.NAME;
                }
            }
        }

        #endregion

        #region 入库仓库
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouseCode.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                    txtReceiptDataFrom.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtWarehouseCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()))
            {
                BaseWarehouseTable Warehouse = new BaseWarehouseTable();
                BWarehouse bWarehouse = new BWarehouse();
                Warehouse = bWarehouse.GetModel(this.txtWarehouseCode.Text);
                if (Warehouse == null || "".Equals(Warehouse))
                {
                    txtWarehouseCode.Focus();
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    MessageBox.Show("仓库编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtWarehouseName.Text = Warehouse.NAME;
                }
            }
        }
        #endregion

        #region 查询分页
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bRerceipt.GetRecordCount(GetConduction());
            if (recordCount < 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //数据绑定
            BindData(currentPage);
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetConduction();
            DataSet ds = bRerceipt.GetList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            for (int i = ds.Tables[0].Rows.Count; i < PageSize; i++)
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            }
            dgvData.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG = {0} ", CConstant.INIT);

            if (txtSlipNumber.Text.Trim() != "")
            {
                sb.AppendFormat(" and PURCHASE_ORDER_SLIP_NUMBER like '{0}%'", txtSlipNumber.Text.Trim());
            }

            if (txtSupplierCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and SUPPLIER_CODE = '{0}'", txtSupplierCode.Text.Trim());
            }

            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat(" and RECEIPT_WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
            }

            if (txtSlipDateFrom.Checked && txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE between '{0}' and '{1}'", txtSlipDateFrom.Value.ToShortDateString(), txtSlipDateTo.Value.AddDays(1).ToShortDateString());
            }
            else if (txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE>= '{0}'", txtSlipDateFrom.Value.ToShortDateString());
            }
            else if (txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE< '{0}'", txtSlipDateTo.Value.AddDays(1).ToShortDateString());
            }

            if (txtReceiptDataFrom.Checked && txtReceiptDataTo.Checked)
            {
                sb.AppendFormat(" and DUE_DATE between '{0}' and '{1}'", txtReceiptDataFrom.Value.ToShortDateString(), txtReceiptDataTo.Value.AddDays(1).ToShortDateString());
            }
            else if (txtReceiptDataFrom.Checked)
            {
                sb.AppendFormat(" and DUE_DATE>= '{0}'", txtReceiptDataFrom.Value.ToShortDateString());
            }
            else if (txtReceiptDataTo.Checked)
            {
                sb.AppendFormat(" and DUE_DATE< '{0}'", txtReceiptDataTo.Value.AddDays(1).ToShortDateString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }

        #endregion


        #region 控制空行不能被点击
        /// <summary>
        /// 控制空行不能被点击
        /// </summary>
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
        #endregion

        #region 关闭
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }//end class
}
