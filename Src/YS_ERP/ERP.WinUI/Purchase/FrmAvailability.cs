using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Main;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmAvailability : FrmBase
    {
        private string _conduction = "";
        private DataTable _currentDt = new DataTable();
        public FrmAvailability()
        {
            InitializeComponent();
        }

        #region 页面初始化
        private void FrmAvailability_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.CTag = CTag;
            //dgvData初始化
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }
        #endregion

        #region 商品类别
        /// <summary>
        /// 商品类别
        /// </summary>
        private void btnGroup_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT_GROUP", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtGroupCode.Text = frm.BaseMasterTable.Code;
                    txtGroupName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 商品类别
        /// </summary>
        private void txtGroupCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGroupCode.Text.Trim()))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT_GROUP", txtGroupCode.Text.Trim(), "");
                if (baseMaster != null)
                {
                    txtGroupCode.Text = baseMaster.Code;
                    txtGroupName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("商品类别不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGroupCode.Text = "";
                    txtGroupName.Text = "";
                }
            }
            else
            {
                txtGroupName.Text = "";
            }
        }
        #endregion

        #region 供应商From
        /// <summary>
        /// 供应商From
        /// </summary>
        private void btnSupplierFrom_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Supplier", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCodeFrom.Text = frm.BaseMasterTable.Code;
                    txtSupplierNameFrom.Text = frm.BaseMasterTable.Name;
                    txtSupplierCodeTo.Focus();
                }
            }
            frm.Dispose();
        }
        /// <summary>
        /// 供应商From
        /// </summary>
        private void txtSupplierCodeFrom_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSupplierCodeFrom.Text.Trim()))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", txtSupplierCodeFrom.Text.Trim(), "");

                if (baseMaster != null)
                {
                    txtSupplierCodeFrom.Text = baseMaster.Code;
                    txtSupplierNameFrom.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("供应商编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierCodeFrom.Text = "";
                    txtSupplierNameFrom.Text = "";
                    txtSupplierCodeFrom.Focus();

                }
            }
            else
            {
                txtSupplierNameFrom.Text = "";
            }
        }
        #endregion

        #region 供应商To
        /// <summary>
        /// 供应商To
        /// </summary>
        private void btnSupplierTo_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Supplier", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCodeTo.Text = frm.BaseMasterTable.Code;
                    txtSupplierNameTo.Text = frm.BaseMasterTable.Name;
                    txtPOSlipDateFrom.Focus();
                }
            }
            frm.Dispose();
        }
        /// <summary>
        /// 供应商To
        /// </summary>
        private void txtSupplierCodeTo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSupplierCodeTo.Text.Trim()))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", txtSupplierCodeTo.Text.Trim(), "");

                if (baseMaster != null)
                {
                    txtSupplierCodeTo.Text = baseMaster.Code;
                    txtSupplierNameTo.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("供应商编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierCodeTo.Text = "";
                    txtSupplierNameTo.Text = "";
                    txtSupplierCodeTo.Focus();

                }
            }
            else
            {
                txtSupplierNameTo.Text = "";
            }
        }
        #endregion

        #region  查询
        /// <summary>
        /// 数据查询
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _conduction = GetConduction();
            BindData();
        }


        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData()
        {
            int recordCount = 0;
            DataSet ds = bPurchaseOrder.GetPurchaseBalanceBySupplier(_conduction);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();

            if (_currentDt.Rows.Count <= 0)
            {
                MessageBox.Show("查询的信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(ds.Tables[0].NewRow());
            }
            this.dgvData.DataSource = _currentDt;

        }

        private void reSetCurrentDt()
        {
            _currentDt.Columns.Add("Row");
            _currentDt.Columns.Add("RECEIPT_RATE");
            _currentDt.Columns.Add("RERECEIPT_RATE");
            _currentDt.Columns.Add("ON_SCHEDULE_RECEIPT_RATE");
            
            for (int i = 0; i <= _currentDt.Rows.Count - 1; i++)
            {
                _currentDt.Rows[i]["Row"] = i + 1;
                decimal purchase = CConvert.ToDecimal(_currentDt.Rows[i]["PURCHASE_QUANTITY"]);
                decimal receipt = CConvert.ToDecimal(_currentDt.Rows[i]["RECEIPT_QUANTITY"]);
                decimal rereceipt = CConvert.ToDecimal(_currentDt.Rows[i]["RERECEIPT_QUANTITY"]);
                decimal ontimereceipt = CConvert.ToDecimal(_currentDt.Rows[i]["ON_SCHEDULE_RECEIPT_QUANTITY"]);
                _currentDt.Rows[i]["RECEIPT_RATE"] = string.Format("{0:F2}", ((decimal)((receipt / purchase) * 100))) + "%";
                if ((rereceipt + receipt) > 0)
                {
                    _currentDt.Rows[i]["RERECEIPT_RATE"] = string.Format("{0:F2}", ((decimal)((rereceipt / (receipt + rereceipt)) * 100))) + "%";
                }
                else
                {
                    _currentDt.Rows[i]["RERECEIPT_RATE"] = "0%";
                }
                _currentDt.Rows[i]["ON_SCHEDULE_RECEIPT_RATE"] = string.Format("{0:F2}",((decimal)((ontimereceipt / purchase) * 100))) + "%"; 
            }
        }
        
        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1 ");
            if (!string.IsNullOrEmpty(txtGroupCode.Text.Trim()))
            {
                sb.AppendFormat(" AND GROUP_CODE = '{0}'", txtGroupCode.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtSupplierCodeFrom.Text.Trim()))
            {
                sb.AppendFormat(" AND SUPPLIER_CODE >='{0}' ", txtSupplierCodeFrom.Text.Trim());
            }

            if (!string.IsNullOrEmpty(txtSupplierCodeTo.Text.Trim()))
            {
                sb.AppendFormat(" AND SUPPLIER_CODE <='{0}' ", txtSupplierCodeTo.Text.Trim());
            }

            if (txtPOSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE  >='{0}' ", txtPOSlipDateFrom.Text.Trim());
            }

            if (txtPOSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE  <='{0}' ", txtPOSlipDateTo.Text.Trim());
            }
            return sb.ToString();

        }
        #endregion

        #region 控制空行不能被点击
        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["Row"].Value == null || "".Equals(row.Cells["Row"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
        #endregion

        #region   关闭
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region  导出
        /// <summary>
        /// 导出
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_currentDt.Rows.Count > 0)
            {
                int result = CExport.DataTableToExcel(_currentDt, CConstant.AVAILABILITY_HEADER, CConstant.AVAILABILITY_COLUMNS, "AVAILABILITY", "AVAILABILITY");
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
        #endregion


    }//end class
}
