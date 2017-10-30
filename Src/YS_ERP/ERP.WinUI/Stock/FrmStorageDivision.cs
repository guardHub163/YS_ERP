using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmStorageDivision : FrmBase
    {
        BReceipt bReceipt = new BReceipt();
        private string _slip_number = "";

        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }

        public FrmStorageDivision()
        {
            InitializeComponent();
        }

        private void FrmStorageDivision_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region 税率的初始化
            //税率的初始化  
            DataTable dtTaxation = CCacheData.Taxation.Copy();
            dtTaxation.Columns.Add("DISP_TAX_RATE", Type.GetType("System.String"));
            foreach (DataRow row in dtTaxation.Rows)
            {
                row["DISP_TAX_RATE"] = row["TAX_RATE"].ToString() + "%";
            }
            cboTax.ValueMember = "CODE";
            cboTax.DisplayMember = "DISP_TAX_RATE";
            cboTax.DataSource = dtTaxation;
            #endregion

            #region 返品类型初始化
            cboReturn.ValueMember = "CODE";
            cboReturn.DisplayMember = "NAME";
            cboReturn.DataSource = CCacheData.ReverseStorage.Copy();
            #endregion            
            
            if (!string.IsNullOrEmpty(_slip_number))
            {
                initDta();
                setStatus(false);
            }
        }

        #region initData
        private void initDta()
        {
            BllReReceiptTable RRTable = bReceipt.GetReModel(_slip_number);
            if (RRTable != null)
            {
                try
                {
                    SlipDate.Value = CConvert.ToDateTime(RRTable.SLIP_DATE);
                    txtSupplierCode.Text = RRTable.SUPPLIER_CODE;
                    if (bCommon.GetBaseMaster("SUPPLIER", RRTable.SUPPLIER_CODE) != null)
                    {
                        txtSupplierName.Text = bCommon.GetBaseMaster("SUPPLIER", RRTable.SUPPLIER_CODE).Name;
                    }
                    txtPurchaseNumber.Text = RRTable.PO_SLIP_NUMBER;
                    foreach (DataRow dr in CCacheData.Taxation.Rows)
                    {
                        if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(RRTable.TAX_RATE) * 100)
                        {
                            this.cboTax.SelectedValue = dr["CODE"];
                            break;
                        }
                    }
                    cboReturn.SelectedValue = RRTable.RERECEIPT_FLAG;
                    foreach (BllReReceiptLineTable RRLTable in RRTable.Items)
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow row = dgvData.Rows[currentRowIndex];
                        row.Cells[1].Selected = false;
                        row.Cells["NO"].Value = RRLTable.LINE_NUMBER;
                        row.Cells["PRODUCT_CODE"].Value = RRLTable.PRODUCT_CODE;
                        BaseProductTable product = bProduct.GetModel(RRLTable.PRODUCT_CODE);
                        if (product != null)
                        {
                            row.Cells["NAME"].Value = product.NAME;
                            row.Cells["SPEC"].Value = product.SPEC + " " + product.MODEL_NUMBER;
                        }
                        row.Cells["QUANTITY"].Value = RRLTable.QUANTITY;
                        if (bCommon.GetBaseMaster("UNIT", RRLTable.UNIT_CODE) != null)
                        {
                            row.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", RRLTable.UNIT_CODE).Name;
                        }
                        row.Cells["PRICE"].Value = RRLTable.PRICE;
                        row.Cells["AMOUNT"].Value = RRLTable.PRICE * RRLTable.QUANTITY;
                        row.Cells["AMOUNT_INCLUDED_TAX"].Value = RRLTable.PRICE * RRLTable.QUANTITY * (1 + RRTable.TAX_RATE);
                        row.Cells["MEMO"].Value = RRLTable.MEMO;
                    }
                }
                catch(Exception ex)
                { }
            }
        }

        private void setStatus(bool flag)
        {
            txtPurchaseNumber.Enabled = flag;
            txtSupplierCode.Enabled = flag;
            txtSupplierName.Enabled = flag;
            SlipDate.Enabled = flag;
            cboTax.Enabled = flag;
            cboReturn.Enabled = flag;
            btnSupplier.Enabled = flag;
            btnPurchase.Enabled = flag;
            btnAddRow.Enabled = flag;
            btnDeleteRow.Enabled = flag;
            btnSave.Enabled = flag;
            if (!flag)
            {
                foreach (DataGridViewColumn dgvc in dgvData.Columns)
                {
                    dgvc.ReadOnly = true;
                }
                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            dgvData.Columns[2].Visible = flag;
        }
        #endregion 

        #region 重绘表头
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex == -1 && (e.ColumnIndex == 1))
            {
                CellPainting(dgv, 2, "外购件编号", e);
                e.Handled = true;
            }
        }
        #endregion

        #region 供应商
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    //txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (!string.IsNullOrEmpty(SupplierCode))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("供应商编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    txtSupplierCode.Focus();
                }
            }
            else
            {
                txtSupplierName.Text = "";
            }
        }
        #endregion

        //#region 入库仓库
        //private void btnWarehouse_Click(object sender, EventArgs e)
        //{
        //    FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
        //    if (frm.ShowDialog(this) == DialogResult.OK)
        //    {
        //        if (frm.BaseMasterTable != null)
        //        {
        //            txtWarehouseCode.Text = frm.BaseMasterTable.Code;
        //            txtWarehouseName.Text = frm.BaseMasterTable.Name;
        //            //txtPackingMethod.Focus();
        //        }
        //    }
        //    frm.Dispose();
        //}

        //private void txtWarehouseCode_Leave(object sender, EventArgs e)
        //{
        //    string warehouseCode = txtWarehouseCode.Text.Trim();
        //    if (warehouseCode != "")
        //    {
        //        BaseMaster baseMaster = bCommon.GetBaseMaster("WAREHOUSE", warehouseCode);
        //        if (baseMaster != null)
        //        {
        //            txtWarehouseCode.Text = baseMaster.Code;
        //            txtWarehouseName.Text = baseMaster.Name;
        //        }
        //        else
        //        {
        //            MessageBox.Show("入库仓库不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtWarehouseCode.Text = "";
        //            txtWarehouseName.Text = "";
        //            txtWarehouseCode.Focus();
        //        }
        //    }
        //    else
        //    {
        //        txtWarehouseName.Text = "";
        //    }
        //}
        //#endregion

        #region 采购订单
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            FrmPurchaseOrderSearch frm = new FrmPurchaseOrderSearch();
            frm.CTag = CConstant.PURCHASE_ORDER_MASTER_SEARCH;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.CurrentPurchaseOrderTable != null)
                {
                    string slipNumber = frm.CurrentPurchaseOrderTable.SLIP_NUMBER;
                    txtPurchaseNumber.Text = slipNumber;
                }
            }
            frm.Dispose();
        }

        private void txtPurchaseNumber_Leave(object sender, EventArgs e)
        {
            string purchase = txtPurchaseNumber.Text.Trim();
            if (!string.IsNullOrEmpty(purchase))
            {
                if (bPurchaseOrder.GetModel(purchase) == null)
                {
                    MessageBox.Show("采购订单编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPurchaseNumber.Text = "";
                    txtPurchaseNumber.Focus();
                }
            }
        }
        #endregion

        #region 行添加
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if ("".Equals(CConvert.ToString(dr.Cells["PRODUCT_CODE"].Value).Trim()))
                {
                    dr.Cells["PRODUCT_CODE"].Selected = true;
                    return;
                }
            }
            int currentRowIndex = dgvData.Rows.Add(1);
            DataGridViewRow row = dgvData.Rows[currentRowIndex];
            row.Cells[1].Selected = true;
            row.Cells["QUANTITY"].Value = "0";
            row.Cells["PRICE"].Value = "0";
            row.Cells["AMOUNT"].Value = "0";
        }
        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvData.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
        }
        #endregion

        #region DataGridView 行删除
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    dgvData.Rows.Remove(dgvData.CurrentRow);
                    reSetNo();
                }
            }
        }
        /// <summary>
        /// DataGridView 行NUMBER的重新排序
        /// </summary>
        private void reSetNo()
        {
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                dr.Cells["No"].Value = dr.Index + 1;
            }
        }
        #endregion

        #region 税率的选择变更
        private void cboTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            string taxation = cboTax.Text.Replace("%", "");
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                dr.Cells["AMOUNT_INCLUDED_TAX"].Value = Convert.ToDecimal(dr.Cells["AMOUNT"].Value) * ((100 + Convert.ToDecimal(taxation)) / 100);
            }
        }
        #endregion

        #region DataGridView 单击事件
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvData.Columns["BtnProduct"].Index)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(" PRODUCT_FLAG = 2 ");
                    sb.AppendFormat(" AND SUPPLIER_CODE LIKE '{0}%'", txtSupplierCode.Text.Trim());
                    FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", sb.ToString());
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (frm.BaseMasterTable != null)
                        {
                            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                            string code = frm.BaseMasterTable.Code;
                            BaseProductTable productTable = bProduct.GetModel(code);
                            string taxation = cboTax.Text.Replace("%", "");
                            if (productTable != null)
                            {
                                if (!string.IsNullOrEmpty(txtPurchaseNumber.Text.Trim()))
                                {
                                    if (!bReceipt.ExsitProdcuct(txtPurchaseNumber.Text.Trim(), productTable.CODE))
                                    {
                                        MessageBox.Show("采购单中商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        dr.Cells["PRODUCT_CODE"].Value = "";
                                        dr.Cells["NAME"].Value = "";
                                        dr.Cells["SPEC"].Value = "";
                                        dr.Cells["QUANTITY"].Value = "0";
                                        dr.Cells["UNIT_NAME"].Value = "";
                                        dr.Cells["UNIT_CODE"].Value = "";
                                        dr.Cells["PRICE"].Value = "0";
                                        dr.Cells["AMOUNT"].Value = "0";
                                        dr.Cells["AMOUNT_INCLUDED_TAX"].Value = "0";
                                        return;
                                    }
                                }
                                if (!productTable.CODE.Equals(dr.Cells["OLD_CODE"].Value)) //商品编号未变换
                                {
                                    dr.Cells["PRODUCT_CODE"].Value = productTable.CODE;
                                    dr.Cells["OLD_CODE"].Value = productTable.CODE;
                                    dr.Cells["NAME"].Value = productTable.NAME;
                                    dr.Cells["SPEC"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                    dr.Cells["QUANTITY"].Value = 1;
                                    if (bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE) != null)
                                    {
                                        dr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                    }
                                    dr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                    dr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE;
                                    dr.Cells["AMOUNT"].Value = productTable.PURCHASE_PRICE;
                                    dr.Cells["AMOUNT_INCLUDED_TAX"].Value = productTable.SALES_PRICE * ((100 + Convert.ToDecimal(taxation)) / 100);
                                }
                            }
                            else
                            {
                                MessageBox.Show("商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dr.Cells["PRODUCT_CODE"].Value = "";
                                dr.Cells["NAME"].Value = "";
                                dr.Cells["SPEC"].Value = "";
                                dr.Cells["QUANTITY"].Value = "0";
                                dr.Cells["UNIT_NAME"].Value = "";
                                dr.Cells["UNIT_CODE"].Value = "";
                                dr.Cells["PRICE"].Value = "0";
                                dr.Cells["AMOUNT"].Value = "0";
                                dr.Cells["AMOUNT_INCLUDED_TAX"].Value = "0";
                                //dr.Cells["CODE"].Selected = true;
                            }
                        }
                    }
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region DataGridView 验证
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                string taxation = cboTax.Text.Replace("%", "");
                if (e.ColumnIndex == dgvData.Columns["PRODUCT_CODE"].Index)
                {
                    string code = CConvert.ToString(dr.Cells["PRODUCT_CODE"].Value);
                    if (code != "")
                    {
                        BaseProductTable productTable = bProduct.GetModel(code);
                        if (productTable != null)
                        {
                            if (!string.IsNullOrEmpty(txtPurchaseNumber.Text.Trim()))
                            {
                                if (!bReceipt.ExsitProdcuct(txtPurchaseNumber.Text.Trim(), productTable.CODE))
                                {
                                    MessageBox.Show("采购单中商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dr.Cells["PRODUCT_CODE"].Value = "";
                                    dr.Cells["NAME"].Value = "";
                                    dr.Cells["SPEC"].Value = "";
                                    dr.Cells["QUANTITY"].Value = "0";
                                    dr.Cells["UNIT_NAME"].Value = "";
                                    dr.Cells["UNIT_CODE"].Value = "";
                                    dr.Cells["PRICE"].Value = "0";
                                    dr.Cells["AMOUNT"].Value = "0";
                                    dr.Cells["AMOUNT_INCLUDED_TAX"].Value = "0";
                                    return;
                                }
                            }
                            if (!code.Equals(dr.Cells["OLD_CODE"].Value))
                            {
                                dr.Cells["PRODUCT_CODE"].Value = productTable.CODE;
                                dr.Cells["OLD_CODE"].Value = productTable.CODE;
                                dr.Cells["NAME"].Value = productTable.NAME;
                                dr.Cells["SPEC"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                dr.Cells["QUANTITY"].Value = 1;
                                dr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                dr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                dr.Cells["PRICE"].Value = productTable.SALES_PRICE;
                                dr.Cells["AMOUNT"].Value = productTable.SALES_PRICE;
                                dr.Cells["AMOUNT_INCLUDED_TAX"].Value = Convert.ToDecimal(dr.Cells["AMOUNT"].Value) * ((100 + Convert.ToDecimal(taxation)) / 100);
                            }
                        }
                        else
                        {
                            MessageBox.Show("商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr.Cells["PRODUCT_CODE"].Value = "";
                            dr.Cells["NAME"].Value = "";
                            dr.Cells["SPEC"].Value = "";
                            dr.Cells["QUANTITY"].Value = "0";
                            dr.Cells["UNIT_CODE"].Value = "";
                            dr.Cells["UNIT_NAME"].Value = "";
                            dr.Cells["PRICE"].Value = "0";
                            dr.Cells["AMOUNT"].Value = "0";
                            dr.Cells["AMOUNT_INCLUDED_TAX"].Value = "0";
                        }
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["QUANTITY"].Index)
                {
                    decimal quantity = CConvert.ToDecimal(dr.Cells["QUANTITY"].Value);
                    dr.Cells["QUANTITY"].Value = CConvert.ToDecimal(quantity);
                    if (!string.IsNullOrEmpty(txtPurchaseNumber.Text.Trim()))
                    {
                        decimal purchaseQuantity = bReceipt.GetPurchaseQuantity(txtPurchaseNumber.Text.Trim(), CConvert.ToString(dr.Cells["PRODUCT_CODE"].Value));
                        if (quantity > purchaseQuantity)
                        {
                            MessageBox.Show("反品数量不能大于采购数量!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr.Cells["QUANTITY"].Value = 0;
                            dr.Cells["AMOUNT"].Value = 0;
                            dr.Cells["AMOUNT_INCLUDED_TAX"].Value = 0;
                        }
                    }
                    dr.Cells["AMOUNT"].Value = Convert.ToDecimal(quantity) * Convert.ToDecimal(dr.Cells["PRICE"].Value.ToString().Trim());
                    dr.Cells["AMOUNT_INCLUDED_TAX"].Value = Convert.ToDecimal(dr.Cells["AMOUNT"].Value) * ((100 + Convert.ToDecimal(taxation)) / 100);
                }
                else if (e.ColumnIndex == dgvData.Columns["PRICE"].Index)
                {
                    string price = CConvert.ToString(dr.Cells["PRICE"].Value);
                    if (price == "")
                    {
                        dr.Cells["PRICE"].Value = 0;
                    }
                    else
                    {
                        dr.Cells["PRICE"].Value = CConvert.ToDecimal(price);
                    }
                    dr.Cells["AMOUNT"].Value = Convert.ToDecimal(price) * Convert.ToDecimal(dr.Cells["QUANTITY"].Value.ToString().Trim());
                    dr.Cells["AMOUNT_INCLUDED_TAX"].Value = Convert.ToDecimal(dr.Cells["AMOUNT"].Value) * ((100 + Convert.ToDecimal(taxation)) / 100);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (InputCheck())
            {
                #region 返品
                decimal taxAmount = 0;
                decimal AmountWithoutTax = 0;
                decimal AmountIncludedTax = 0;
                BllReReceiptTable reReceiptTable = new BllReReceiptTable();
                BllReReceiptLineTable reReceiptLineTable = null;
                //reReceiptTable.SLIP_NUMBER = bCommon.GetSeqNumber(CConstant.SEQ_RECEIPT_RETURN);
                reReceiptTable.PO_SLIP_NUMBER = txtPurchaseNumber.Text;
                reReceiptTable.SLIP_DATE = DateTime.Now;
                reReceiptTable.RECEIPT_WAREHOUSE_CODE = CConstant.DEFAULT_WAREHOUSE_CODE;
                reReceiptTable.CURRENCY_CODE = CConstant.DEFAULT_CURRENCY_CODE;
                reReceiptTable.SUPPLIER_CODE = txtSupplierCode.Text.Trim();
                reReceiptTable.TAX_RATE = CConvert.ToDecimal(cboTax.Text.Replace("%", "")) / 100;
                reReceiptTable.RERECEIPT_FLAG = CConvert.ToInt32(cboReturn.SelectedValue);
                reReceiptTable.STATUS_FLAG = CConstant.INIT;
                reReceiptTable.COMPANY_CODE = UserTable.COMPANY_CODE;
                reReceiptTable.CREATE_USER = UserTable.CODE;
                reReceiptTable.LAST_UPDATE_USER = UserTable.CODE;

                int i = 1;
                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    reReceiptLineTable = new BllReReceiptLineTable();
                    //返品数量
                    decimal receiptQuantity = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                    //ReReceipt_Line 表中数据
                    //reReceiptLineTable.SLIP_NUMBER = reReceiptTable.SLIP_NUMBER;
                    reReceiptLineTable.LINE_NUMBER = i++;
                    reReceiptLineTable.PRODUCT_CODE = CConvert.ToString(dgvr.Cells["PRODUCT_CODE"].Value);
                    reReceiptLineTable.QUANTITY = receiptQuantity;
                    reReceiptLineTable.UNIT_CODE = CConvert.ToString(dgvr.Cells["UNIT_CODE"].Value);
                    reReceiptLineTable.PRICE = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value);
                    reReceiptTable.AddItem(reReceiptLineTable);
                    AmountWithoutTax += CConvert.ToDecimal(reReceiptLineTable.QUANTITY * reReceiptLineTable.PRICE);
                    taxAmount += CConvert.ToDecimal(reReceiptLineTable.QUANTITY * reReceiptLineTable.PRICE * reReceiptTable.TAX_RATE);
                    AmountIncludedTax = AmountWithoutTax + taxAmount;
                }
                reReceiptTable.TAX_AMOUNT = taxAmount;
                reReceiptTable.AMOUNT_WITHOUT_TAX = AmountWithoutTax;
                reReceiptTable.AMOUNT_INCLUDED_TAX = AmountIncludedTax;

                if (reReceiptTable.Items.Count > 0)
                {
                    DateTime time = DateTime.Now;
                    if (bRerceipt.AddReReceipt(reReceiptTable) > 0)
                    {
                        MessageBox.Show("返品成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setInit();
                    }
                    else
                    {
                        MessageBox.Show("返品失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("请添加明细商品。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion
            }
        }

        private bool InputCheck()
        {
            string ErrorLog = "";
            if (string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                ErrorLog += "供应商编号不能为空!\r\n";
            }

            if (CConvert.ToString(CConstant.PURCHASE_RETURN).Equals(cboReturn.SelectedValue) && string.IsNullOrEmpty(txtPurchaseNumber.Text.Trim()))
            {
                ErrorLog += "采购编号不能为空!\r\n";
            }

            if (!string.IsNullOrEmpty(txtPurchaseNumber.Text.Trim()))
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (!bReceipt.ExsitProdcuct(txtPurchaseNumber.Text.Trim(), CConvert.ToString(row.Cells["PRODUCT_CODE"].Value)))
                    {
                        ErrorLog += "采购单中不存在" + CConvert.ToString(row.Cells["PRODUCT_CODE"].Value) + "!\r\n";
                    }
                    decimal purchaseQuantity = bReceipt.GetPurchaseQuantity(txtPurchaseNumber.Text.Trim(), CConvert.ToString(row.Cells["PRODUCT_CODE"].Value));
                    if (CConvert.ToDecimal(row.Cells["QUANTITY"].Value) > purchaseQuantity)
                    {
                        ErrorLog += CConvert.ToString(row.Cells["PRODUCT_CODE"].Value) + "反品数量不能大于采购数量!\r\n";
                    }
                }
            }
            if (!string.IsNullOrEmpty(ErrorLog))
            {
                MessageBox.Show(ErrorLog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

        #region 保存后操作
        private void setInit()
        {
            //txtSlipNumber.Text = bCommon.GetSeqNumber(CConstant.SEQ_RECEIPT_RETURN);
            SlipDate.Value = DateTime.Now;
            txtSupplierCode.Text = "";
            txtSupplierName.Text = "";
            txtPurchaseNumber.Text = "";
            //txtWarehouseCode.Text = "";
            //txtWarehouseName.Text = "";
            cboTax.SelectedIndex = 0;
            cboReturn.SelectedIndex = 0;
            dgvData.Rows.Clear();
        }
        #endregion

        #region dgvData 控制
        bool HasAttachEvent = false;
        /// <summary>
        /// 控制只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl control = (DataGridViewTextBoxEditingControl)e.Control;

            if (!this.HasAttachEvent) // 注册事件
            {
                control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "QUANTITY")
                    {
                        InputDouble(o, c);
                    }
                    else if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "PRICE")
                    {
                        InputAmount(o, c);
                    }
                    else
                    {
                        return;
                    }

                    //if (this.dgvData.CurrentCell.ColumnIndex == 1) return; // 第二列不验证
                    //if (!char.IsNumber(c.KeyChar)) c.Handled = true;
                });

                this.HasAttachEvent = true;
            }
        }
        #endregion

        #region 返品类型选择变更
        private void cboReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CConvert.ToString(CConstant.PURCHASE_RETURN).Equals(cboReturn.SelectedValue))
            {
                txtPurchaseNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            }
            else if (CConvert.ToString(CConstant.PRODUCE_RETURN).Equals(cboReturn.SelectedValue))
            {
                txtPurchaseNumber.BackColor = SystemColors.Info;
            }
        }
        #endregion

    }
}
