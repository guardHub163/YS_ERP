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
using CZZD.ERP.Bll;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmPurchaseOrderEntry : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private int _operateMode = CConstant.PURCHASE_NEW;
        private int count;
        private BllPurchaseOrderTable _currentPurchaseOrderTable = null;
        //private string _oldSlipNumber = "";
        private DialogResult _dialogResult = DialogResult.Cancel;

        public BllPurchaseOrderTable CurrentPurchaseOrderTable
        {
            set { _currentPurchaseOrderTable = value; }
            get { return _currentPurchaseOrderTable; }
        }

        public FrmPurchaseOrderEntry()
        {
            InitializeComponent();
        }

        private void FrmOrderImport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region 订单类型的初始化
            DataTable pstDT = CCacheData.PurchaseOrder.Copy();
            //pstDT.Columns.Add("CODE", Type.GetType("System.String"));
            //pstDT.Columns.Add("NAME", Type.GetType("System.String"));
            //DataRow dr = pstDT.NewRow();
            //dr["CODE"] = "PO";
            //dr["NAME"] = "采购";
            //pstDT.Rows.Add(dr);
            cboPurchaseSlipType.ValueMember = "CODE";
            cboPurchaseSlipType.DisplayMember = "NAME";
            cboPurchaseSlipType.DataSource = pstDT;
            #endregion

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

            dueDate.Value = entryDate.Value.AddDays(7);

            if (CConstant.PURCHASE_ORDER_NEW.Equals(CTag))
            {
                initSlipNumber();
                btnOrderDelete.Visible = false;
            }
            else if (CConstant.PURCHASE_ORDER_MODIFY.Equals(CTag))
            {
                this.Text = "采购订单修正";
                init();
                cboPurchaseSlipType.Enabled = false;

            }
            else if (CConstant.PURCHASE_ORDER_SEARCH.Equals(CTag))
            {
                this.Text = "采购订单详细";
                setStatus(false);
                init();
                btnOrderDelete.Visible = false;
                cboPurchaseSlipType.Enabled = false;
            }
        }

        #region 页面的初始化
        public void init()
        {
            if (_currentPurchaseOrderTable != null)
            {
                this.cboPurchaseSlipType.SelectedValue = _currentPurchaseOrderTable.SLIP_TYPE;
                this.txtPurchaseSlipNumber.Text = _currentPurchaseOrderTable.SLIP_NUMBER;
                this.txtSupplierCode.Text = _currentPurchaseOrderTable.SUPPLIER_CODE;
                if (bCommon.GetBaseMaster("SUPPLIER", _currentPurchaseOrderTable.SUPPLIER_CODE) != null)
                {
                    this.txtSupplierName.Text = bCommon.GetBaseMaster("SUPPLIER", _currentPurchaseOrderTable.SUPPLIER_CODE).Name;
                }
                this.txtWarehouseCode.Text = _currentPurchaseOrderTable.RECEIPT_WAREHOUSE_CODE;
                if (bCommon.GetBaseMaster("WAREHOUSE", _currentPurchaseOrderTable.RECEIPT_WAREHOUSE_CODE) !=null)
                {
                    this.txtWarehouseName.Text = bCommon.GetBaseMaster("WAREHOUSE", _currentPurchaseOrderTable.RECEIPT_WAREHOUSE_CODE).Name;
                }
                //this.txtPackingMethod.Text = _currentPurchaseOrderTable.PACKING_METHOD;
                this.txtMemo.Text = _currentPurchaseOrderTable.MEMO;
                this.txtPayment.Text = _currentPurchaseOrderTable.PAYMENT_CONDITION;
                this.txtOrderNumber.Text = _currentPurchaseOrderTable.ORDER_SLIP_NUMBER;
                this.txtSupplierOrderCode.Text = _currentPurchaseOrderTable.SUPPLIER_ORDER_NUMBER;
                this.entryDate.Text = Convert.ToString(_currentPurchaseOrderTable.SLIP_DATE);
                this.dueDate.Text = Convert.ToString(_currentPurchaseOrderTable.DUE_DATE);
                foreach (DataRow dr in CCacheData.Taxation.Rows)
                {
                    if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(_currentPurchaseOrderTable.TAX_RATE) * 100)
                    {
                        this.cboTax.SelectedValue = dr["CODE"];
                        break;
                    }
                }

                //this.cboCurrency.SelectedValue = _currentPurchaseOrderTable.CURRENCY_CODE;
                BllPurchaseOrderLineTable OLTable = new BllPurchaseOrderLineTable();
                DataSet ds = bPurchaseOrder.GetPurchaseOrderList(_currentPurchaseOrderTable.SLIP_NUMBER);
                decimal AmountIncludedTax = 0;

                try
                {
                    foreach (DataRow rows in ds.Tables[0].Rows)
                    {
                        
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow row = dgvData.Rows[currentRowIndex];
                        row.Cells[1].Selected = false;
                        row.Cells["NO"].Value = rows["LINE_NUMBER"];
                        row.Cells["PRODUCT_CODE"].Value = rows["PRODUCT_CODE"];
                        row.Cells["OLD_CODE"].Value = rows["PRODUCT_CODE"];
                        row.Cells["NAME"].Value = rows["NAME"];
                        row.Cells["SPEC"].Value = rows["SPEC"];
                        row.Cells["QUANTITY"].Value = rows["QUANTITY"];
                        row.Cells["UNIT_NAME"].Value = rows["UNIT_NAME"];
                        row.Cells["UNIT_CODE"].Value = rows["UNIT_CODE"];
                        row.Cells["PRICE"].Value = rows["PRICE"];
                        row.Cells["AMOUNT"].Value = rows["AMOUNT"];
                        row.Cells["AMOUNT_INCLUDED_TAX"].Value = rows["AMOUNT_INCLUDED_TAX"];
                        AmountIncludedTax = AmountIncludedTax + CConvert.ToDecimal(rows["AMOUNT_INCLUDED_TAX"]);
                    }
                    txtAmountIncludedTax.Text = CConvert.ToString(AmountIncludedTax);
                    btnOrderDelete.Visible = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void setStatus(bool flag)
        {
            this.cboPurchaseSlipType.Enabled = flag;
            this.txtPurchaseSlipNumber.Enabled = flag;
            this.txtSupplierCode.Enabled = flag;
            this.txtOrderNumber.Enabled = flag;
            this.btnOrders.Enabled = flag;
            this.entryDate.Enabled = flag;
            this.txtSupplierOrderCode.Enabled = flag;
            this.txtWarehouseCode.Enabled = flag;
            this.cboTax.Enabled = flag;
            this.dueDate.Enabled = flag;
            this.txtPayment.Enabled = flag;
            this.txtMemo.Enabled = flag;
            this.btnSupplier.Enabled = flag;
            this.btnWarehouse.Enabled = flag;
            this.btnSave.Enabled = flag;
            this.btnOrderDelete.Enabled = flag;
            this.btnAddRow.Enabled = flag;
            this.btnDeleteRow.Enabled = flag;
            this.btnSave.Visible = flag;
            this.btnOrderDelete.Visible = flag;
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

        #region 订单编号的初始化
        /// <summary>
        /// 订单编号的初始化
        /// </summary>
        public void initSlipNumber()
        {
            //订单编号的初始化
            string maxSlipNumber = bPurchaseOrder.GetMaxSlipNumber();
            //if (string.IsNullOrEmpty(maxSlipNumber))
            //{
            //    maxSlipNumber = "0";
            //}
            int number = Convert.ToInt32(maxSlipNumber) + 1;
            string slipNumber = DateTime.Now.ToString("yyyyMMdd") + number.ToString().PadLeft(4, '0');
            txtPurchaseSlipNumber.Text = slipNumber;
            //txtPurchaseSlipNumber.Text = bCommon.GetSeqNumber(CConstant.SEQ_PURCHASE_ORDER);
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

        #region DataGridView 行删除
        /// <summary>
        /// DataGridView 行删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    dgvData.Rows.Remove(dgvData.CurrentRow);
                    reSetNo();
                    CalculateAmount();
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

        #region 总金额计算
        /// <summary>
        /// 总金额计算
        /// </summary>
        private void CalculateAmount()
        {
            decimal IncludedTaxAmount = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                IncludedTaxAmount += Convert.ToDecimal(dr.Cells["AMOUNT"].Value);
            }
            string taxation = cboTax.Text.Replace("%", "");
            IncludedTaxAmount = IncludedTaxAmount * ((100 + Convert.ToDecimal(taxation)) / 100);
            txtAmountIncludedTax.Text = Math.Round(IncludedTaxAmount, 2).ToString("N");
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
                    //txtPackingMethod.Focus();
                }
            }
            frm.Dispose();
        }


        /// <summary>
        /// 仓库输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWarehouseCode_Leave(object sender, EventArgs e)
        {
            string warehouseCode = txtWarehouseCode.Text.Trim();
            if (warehouseCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("WAREHOUSE", warehouseCode);
                if (baseMaster != null)
                {
                    txtWarehouseCode.Text = baseMaster.Code;
                    txtWarehouseName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("入库仓库不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    txtWarehouseCode.Focus();
                }
            }
            else
            {
                txtWarehouseName.Text = "";
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
                    BaseSupplierTable CurrenceCodeTable = GetSupplierCurrence(txtSupplierCode.Text.Trim());
                    if (CurrenceCodeTable != null)
                    {
                        //cboCurrency.SelectedValue = CurrenceCodeTable.CURRENCE_CODE;
                        if (CurrenceCodeTable.TYPE == CConstant.ERP_DOMESTIC_NUMBER)
                        {
                            cboTax.SelectedValue = "01";
                        }
                        else
                        {
                            cboTax.SelectedValue = "99";
                        }
                    }
                    txtWarehouseCode.Focus();
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
                BaseSupplierTable CurrenceCodeTable = GetSupplierCurrence(SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                    if (CurrenceCodeTable != null)
                    {
                        //cboCurrency.SelectedValue = CurrenceCodeTable.CURRENCE_CODE;
                        if (CurrenceCodeTable.TYPE == CConstant.ERP_DOMESTIC_NUMBER)
                        {
                            cboTax.SelectedValue = "01";
                        }
                        else
                        {
                            cboTax.SelectedValue = "99";
                        }
                    }
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

        #region 销售编号
        private void btnOrders_Click(object sender, EventArgs e)
        {
            FrmOrdersSearch frm = new FrmOrdersSearch();
            frm.CTag = CConstant.ORDER_MASTER_SEARCH;

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.orderTable != null)
                {
                    string slipNumber = frm.orderTable.SLIP_NUMBER;
                    txtOrderNumber.Text = slipNumber;
                }
            }
            frm.Dispose();
        }

        private void txtOrderNumber_Leave(object sender, EventArgs e)
        {
            string order = txtOrderNumber.Text.Trim();
            if (!string.IsNullOrEmpty(order))
            {
                BOrderHeader bOrderHeader = new BOrderHeader();
                if (!bOrderHeader.Exists(order))
                {
                    MessageBox.Show("销售订单编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOrderNumber.Text = "";
                    txtOrderNumber.Focus();
                }
            }
        }
        #endregion

        #region 行添加
        /// <summary>
        ///  DataGridView 行添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region DataGridView 单击事件
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvData.Columns["BtnProduct"].Index)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(" (PRODUCT_FLAG = 2 OR PRODUCT_FLAG = 4)");
                    sb.AppendFormat(" AND SUPPLIER_CODE LIKE '%{0}%'", txtSupplierCode.Text.Trim());
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
                                    dr.Cells["AMOUNT_INCLUDED_TAX"].Value = productTable.PURCHASE_PRICE * (1 + CConvert.ToDecimal(cboTax.Text.Replace("%", "")) / 100);
                                    CalculateAmount();
                                }
                            }
                            else
                            {
                                MessageBox.Show("外购件不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                CalculateAmount();
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

        #region 税率的选择变更
        /// <summary>
        /// 税率的选择变更
        /// </summary>
        private void cboTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAmount();
            string taxation = cboTax.Text.Replace("%", "");
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                dr.Cells["AMOUNT_INCLUDED_TAX"].Value = Convert.ToDecimal(dr.Cells["AMOUNT"].Value) * ((100 + Convert.ToDecimal(taxation)) / 100);
            }
        }
        #endregion

        #region DataGridView 验证
        /// <summary>
        /// 列编辑完成后的验证事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                            if (!code.Equals(dr.Cells["OLD_CODE"].Value))
                            {
                                if (productTable.PRODUCT_FLAG == 2 || productTable.PRODUCT_FLAG == 4)
                                {
                                    dr.Cells["PRODUCT_CODE"].Value = productTable.CODE;
                                    dr.Cells["OLD_CODE"].Value = productTable.CODE;
                                    dr.Cells["NAME"].Value = productTable.NAME;
                                    dr.Cells["SPEC"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                    dr.Cells["QUANTITY"].Value = 1;
                                    dr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                    dr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                    dr.Cells["PRICE"].Value = productTable.PURCHASE_PRICE;
                                    dr.Cells["AMOUNT"].Value = productTable.PURCHASE_PRICE;
                                    dr.Cells["AMOUNT_INCLUDED_TAX"].Value = Convert.ToDecimal(dr.Cells["AMOUNT"].Value) * ((100 + Convert.ToDecimal(taxation)) / 100);
                                    CalculateAmount();
                                }
                                else
                                {
                                    MessageBox.Show("外购件不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dr.Cells["PRODUCT_CODE"].Value = "";
                                    dr.Cells["NAME"].Value = "";
                                    dr.Cells["SPEC"].Value = "";
                                    dr.Cells["QUANTITY"].Value = "0";
                                    dr.Cells["UNIT_CODE"].Value = "";
                                    dr.Cells["UNIT_NAME"].Value = "";
                                    dr.Cells["PRICE"].Value = "0";
                                    dr.Cells["AMOUNT"].Value = "0";
                                    dr.Cells["AMOUNT_INCLUDED_TAX"].Value = "0";
                                    //dr.Cells["CODE"].Selected = true; ;
                                    CalculateAmount();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("外购件不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr.Cells["PRODUCT_CODE"].Value = "";
                            dr.Cells["NAME"].Value = "";
                            dr.Cells["SPEC"].Value = "";
                            dr.Cells["QUANTITY"].Value = "0";
                            dr.Cells["UNIT_CODE"].Value = "";
                            dr.Cells["UNIT_NAME"].Value = "";
                            dr.Cells["PRICE"].Value = "0";
                            dr.Cells["AMOUNT"].Value = "0";
                            dr.Cells["AMOUNT_INCLUDED_TAX"].Value = "0";
                            //dr.Cells["CODE"].Selected = true; ;
                            CalculateAmount();
                        }
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["QUANTITY"].Index)
                {
                    string quantity = CConvert.ToString(dr.Cells["QUANTITY"].Value);                    
                    if (quantity == "")
                    {
                        dr.Cells["QUANTITY"].Value = 0;
                    }
                    else
                    {
                        dr.Cells["QUANTITY"].Value = CConvert.ToDecimal(quantity);
                    }
                    dr.Cells["AMOUNT"].Value = Convert.ToDecimal(quantity) * Convert.ToDecimal(dr.Cells["PRICE"].Value.ToString().Trim());
                    dr.Cells["AMOUNT_INCLUDED_TAX"].Value = Convert.ToDecimal(dr.Cells["AMOUNT"].Value) * ((100 + Convert.ToDecimal(taxation)) / 100);
                    CalculateAmount();
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
                    CalculateAmount();
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
            if (DialogResult.Yes == MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
            }
        }

        private void FrmPurchaseOrderEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _dialogResult;
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckHeaderInput())
            {
                return;
            }

            if (!CheckLineInput())
            {
                return;
            }

            BllPurchaseOrderTable POTable = new BllPurchaseOrderTable();
            BllPurchaseOrderLineTable OLTable = null;

            //订单类型
            POTable.SLIP_TYPE = cboPurchaseSlipType.SelectedValue.ToString();
            //订单编号
            POTable.SLIP_NUMBER = txtPurchaseSlipNumber.Text.Trim();
            //类型编号
            POTable.ORDER_SLIP_NUMBER = txtOrderNumber.Text.Trim();
            //供应商编号
            POTable.SUPPLIER_CODE = txtSupplierCode.Text.Trim();
            //报价单号
            POTable.SUPPLIER_ORDER_NUMBER = txtSupplierOrderCode.Text.Trim();
            //入库仓库
            POTable.RECEIPT_WAREHOUSE_CODE = txtWarehouseCode.Text.Trim();
            //采购订单日期
            POTable.SLIP_DATE = CConvert.ToDateTime(entryDate.Value.ToString("yyyy-MM-dd"));
            //交货期限
            POTable.DUE_DATE = CConvert.ToDateTime(dueDate.Value.ToString("yyyy-MM-dd"));
            //税率
            POTable.TAX_RATE = CConvert.ToDecimal(cboTax.Text.Replace("%", "")) / 100;
            //通货
            POTable.CURRENCY_CODE = "01";
            //包装方式
            //POTable.PACKING_METHOD = txtPackingMethod.Text.Trim();
            //付款方式
            POTable.PAYMENT_CONDITION = txtPayment.Text.Trim();
            //备注
            POTable.MEMO = txtMemo.Text.Trim();
            //状态
            POTable.STATUS_FLAG = CConstant.PURCHASE_NEW;
            //创建人           
            POTable.CREATE_USER = UserTable.CODE;
            //最后更新人
            POTable.LAST_UPDATE_USER = UserTable.CODE;
            //公司
            POTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            //总金额
            POTable.TOTAL_AMOUNT = CConvert.ToDecimal(txtAmountIncludedTax.Text.Trim());
            //明细的整理
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                OLTable = new BllPurchaseOrderLineTable();
                OLTable.SLIP_NUMBER = POTable.SLIP_NUMBER;
                OLTable.LINE_NUMBER = row.Index + 1;
                OLTable.PRODUCT_CODE = row.Cells["PRODUCT_CODE"].Value.ToString();
                OLTable.QUANTITY = CConvert.ToDecimal(row.Cells["QUANTITY"].Value.ToString());
                OLTable.UNIT_CODE = row.Cells["UNIT_CODE"].Value.ToString();
                OLTable.PRICE = CConvert.ToDecimal(row.Cells["PRICE"].Value.ToString());
                OLTable.AMOUNT_WITHOUT_TAX = CConvert.ToDecimal(row.Cells["AMOUNT"].Value.ToString());
                OLTable.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(row.Cells["AMOUNT_INCLUDED_TAX"].Value.ToString());
                OLTable.TAX_AMOUNT = OLTable.AMOUNT_INCLUDED_TAX - OLTable.AMOUNT_WITHOUT_TAX;
                OLTable.STATUS_FLAG = CConstant.PURCHASE_NEW;
                POTable.AddItem(OLTable);
            }

            int result = 0;
            try
            {
                if (_currentPurchaseOrderTable != null)
                {
                    result = bPurchaseOrder.Update(POTable);
                }
                else
                {
                    result = bPurchaseOrder.Add(POTable);
                }

                if (result <= 0)
                {
                    MessageBox.Show("订单保存失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("订单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (CConstant.PURCHASE_ORDER_NEW.Equals(CTag))
                    {
                        initPage();
                    }
                    else
                    {
                        _dialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("订单保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Error("订单保存失败！", ex);
            }
        }

        #endregion

        #region 数据保存前的验证
        /// <summary>
        /// 数据保存前的验证
        /// </summary>
        /// <returns></returns>
        private bool CheckHeaderInput()
        {
            string strErrorlog = null;
            //判断订单编号不能为空
            if (string.IsNullOrEmpty(this.txtPurchaseSlipNumber.Text.Trim()))
            {
                strErrorlog += "订单编号不能为空!\r\n";
            }
            //判断供应商编号不能为空
            if (string.IsNullOrEmpty(this.txtSupplierCode.Text.Trim()))
            {
                strErrorlog += "供应商编号不能为空!\r\n";
            }
            //仓库编号不能为空
            if (string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()))
            {
                strErrorlog += "仓库编号不能为空!\r\n";
            }            

            if (strErrorlog != null || "".Equals(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 数据保存前明细数据验证
        /// </summary>
        private bool CheckLineInput()
        {
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("明细数不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (CConvert.ToString(row.Cells["PRODUCT_CODE"].Value) == "")
                {
                    MessageBox.Show("商品编号不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (CConvert.ToString(row.Cells["QUANTITY"].Value) == "")
                {
                    MessageBox.Show("采购数量不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (CConvert.ToDecimal(row.Cells["QUANTITY"].Value) == 0)
                {
                    MessageBox.Show("采购数量不能为零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (CConvert.ToString(row.Cells["PRICE"].Value) == "")
                {
                    MessageBox.Show("采购单价不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 数据保存成功后页面初始化
        /// <summary>
        /// 数据保存成功后页面初始化
        /// </summary>
        private void initPage()
        {
            this.cboPurchaseSlipType.SelectedIndex = 0;
            //this.txtPurchaseSlipNumber.Text = "";
            this.txtSupplierCode.Text = "";
            this.txtSupplierName.Text = "";
            this.txtWarehouseCode.Text = "";
            this.txtWarehouseName.Text = "";
            //this.txtPackingMethod.Text = "";
            this.txtMemo.Text = "";
            this.entryDate.Value = DateTime.Now;
            this.dueDate.Value = DateTime.Now;
            this.txtOrderNumber.Text = "";
            this.txtSupplierOrderCode.Text = "";
            this.cboTax.SelectedIndex = 0;
            //this.cboCurrency.SelectedIndex = 0;
            this.txtPayment.Text = "";
            initSlipNumber();
            this.txtAmountIncludedTax.Text = CConvert.ToString(0.0);

            this.dgvData.Rows.Clear();
        }

        #endregion

        #region 订单删除
        private void btnOrderDelete_Click(object sender, EventArgs e)
        {
            if (txtPurchaseSlipNumber.Text.Trim() != "")
            {
                if (DialogResult.Yes == MessageBox.Show("确定要删除吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    try
                    {
                        if (!bPurchaseOrder.Delete(txtPurchaseSlipNumber.Text.Trim()))
                        {
                            MessageBox.Show("订单删除失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("订单删除成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _dialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("订单删除失败！请与管理员联系！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("订单删除失败！", ex);
                    }
                }
            }
        }
        #endregion

        #region 按键顺序
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion

        #region 控制只能输入数字
        bool HasAttachEvent = false;
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "QUANTITY")
            //{
            //    e.Control.KeyPress += new KeyPressEventHandler(InputDouble);
            //}
            //else if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "PRICE")
            //{
            //    e.Control.KeyPress += new KeyPressEventHandler(InputAmount);
            //}

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

        #region 订单类型发生变化时
        private void cboPurchaseSlipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CConstant.PURCHASE_ORDER_NEW.Equals(CTag))
            //{
            //    initSlipNumber();
            //}
        }
        #endregion
        
    }
}
        