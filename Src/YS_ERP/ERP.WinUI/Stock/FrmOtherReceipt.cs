using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;

namespace CZZD.ERP.WinUI
{
    public partial class FrmOtherReceipt : FrmBase
    {
        private DialogResult _dialogResult = DialogResult.Cancel; 
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private string _slip_number;
        private BaseUserTable _user;

        public BaseUserTable USER
        {
            get { return _user; }
            set { _user = value; }
        }

        public string SLIP_NUMBER
        {
            get { return _slip_number; }
            set { _slip_number = value; }
        }
        
        public FrmOtherReceipt()
        {
            InitializeComponent();
        }

        private void FrmOtherReceipt_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            //txtSlipNumber.Text = bCommon.GetSeqNumber(CConstant.SEQ_RECEIPT);

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
            if (!string.IsNullOrEmpty(_slip_number))
            {
                initData();
            }
        }

        private void initData()
        {
            DataTable dt = bRerceipt.GetOtherList(_slip_number).Tables[0];
            try
            {
                txtSupplierCode.Text = dt.Rows[0]["SUPPLIER_CODE"].ToString();
                txtSupplierName.Text = dt.Rows[0]["SUPPLIER_NAME"].ToString();
                txtWarehouseCode.Text = dt.Rows[0]["RECEIPT_WAREHOUSE_CODE"].ToString();
                txtWarehouseName.Text = dt.Rows[0]["WAREHOUSE_NAME"].ToString();
                slipDate.Value = CConvert.ToDateTime(dt.Rows[0]["SLIP_DATE"]);                
                foreach (DataRow dr in CCacheData.Taxation.Rows)
                {
                    if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(dt.Rows[0]["TAX_RATE"]) * 100)
                    {
                        this.cboTax.SelectedValue = dr["CODE"];
                        break;
                    }
                }
                foreach (DataRow rows in dt.Rows)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow row = dgvData.Rows[currentRowIndex];
                    row.Cells[1].Selected = false;
                    row.Cells["NO"].Value = rows["LINE_NUMBER"];
                    row.Cells["PRODUCT_CODE"].Value = rows["PRODUCT_CODE"];
                    row.Cells["NAME"].Value = rows["PRODUCT_NAME"];
                    row.Cells["SPEC"].Value = rows["SPEC"];
                    row.Cells["QUANTITY"].Value = rows["QUANTITY"];
                    row.Cells["UNIT_NAME"].Value = rows["UNIT_NAME"];
                    row.Cells["UNIT_CODE"].Value = rows["UNIT_CODE"];
                    row.Cells["PRICE"].Value = rows["PRICE"];
                    row.Cells["AMOUNT"].Value = rows["AMOUNT_WITHOUT_TAX"];
                    row.Cells["AMOUNT_INCLUDED_TAX"].Value = rows["AMOUNT_INCLUDED_TAX"];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
                    //CalculateAmount();
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

        #region 税率的选择变更
        /// <summary>
        /// 税率的选择变更
        /// </summary>
        private void cboTax_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                            //dr.Cells["CODE"].Selected = true; ;
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

        #region 数据保存前的验证
        /// <summary>
        /// 数据保存前的验证
        /// </summary>
        /// <returns></returns>
        private bool CheckHeaderInput()
        {
            string strErrorlog = null;
            //判断订单编号不能为空
            //if (string.IsNullOrEmpty(this.txtSlipNumber.Text.Trim()))
            //{
            //    strErrorlog += "订单编号不能为空!\r\n";
            //}
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
            ///this.txtSlipNumber.Text = bCommon.GetSeqNumber(CConstant.SEQ_RECEIPT);
            this.txtSupplierCode.Text = "";
            this.txtSupplierName.Text = "";
            this.txtWarehouseCode.Text = "";
            this.txtWarehouseName.Text = "";
            this.slipDate.Value = DateTime.Now;
            this.cboTax.SelectedIndex = 0;

            this.dgvData.Rows.Clear();
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
        //    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "QUANTITY")
        //    {
        //        e.Control.KeyPress += new KeyPressEventHandler(InputDouble);
        //    }
        //    else if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "PRICE")
        //    {
        //        e.Control.KeyPress += new KeyPressEventHandler(InputAmount);
        //    }

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
            BllReceiptTable receiptTable = new BllReceiptTable();
            receiptTable.SLIP_NUMBER = bCommon.GetSeqNumber(CConstant.SEQ_RECEIPT);
            receiptTable.STATUS_FLAG = CConstant.INIT;
            if (!string.IsNullOrEmpty(_slip_number))
            {
                receiptTable.COMPANY_CODE = _user.COMPANY_CODE;
                receiptTable.CREATE_USER = _user.CODE;
                receiptTable.LAST_UPDATE_USER = _user.CODE;
            }
            else
            {
                receiptTable.COMPANY_CODE = UserTable.COMPANY_CODE;
                receiptTable.CREATE_USER = UserTable.CODE;
                receiptTable.LAST_UPDATE_USER = UserTable.CODE;
            }
            receiptTable.RECEIPT_FLAG = 2;

            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                //入库数量
                decimal receiptQuantity = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);
                BllReceiptLineTable receiptLineTable = new BllReceiptLineTable();
                //Receipt_Line 表中数据
                //receiptLineTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
                receiptLineTable.LINE_NUMBER = CConvert.ToInt32(dgvr.Cells["No"].Value);
                receiptLineTable.RECEIPT_WAREHOUSE_CODE = txtWarehouseCode.Text.Trim();
                receiptLineTable.PRODUCT_CODE = CConvert.ToString(dgvr.Cells["PRODUCT_CODE"].Value);
                receiptLineTable.SLIP_DATE = slipDate.Value;
                receiptLineTable.QUANTITY = receiptQuantity;
                receiptLineTable.UNIT_CODE = CConvert.ToString(dgvr.Cells["UNIT_CODE"].Value);
                receiptLineTable.PRICE = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value);
                receiptLineTable.AMOUNT_WITHOUT_TAX = receiptLineTable.QUANTITY * receiptLineTable.PRICE;
                receiptLineTable.AMOUNT_INCLUDED_TAX = receiptLineTable.AMOUNT_WITHOUT_TAX * (1 + CConvert.ToDecimal(cboTax.Text.Replace("%", "")) / 100);
                receiptLineTable.TAX_AMOUNT = receiptLineTable.AMOUNT_INCLUDED_TAX - receiptLineTable.AMOUNT_WITHOUT_TAX;
                receiptLineTable.SUPPLIER_CODE = txtSupplierCode.Text.Trim();
                receiptLineTable.CURRENCY_CODE = CConstant.DEFAULT_CURRENCY_CODE;
                receiptLineTable.TAX_RATE = CConvert.ToDecimal(cboTax.Text.Replace("%", "")) / 100;
                receiptTable.AddItem(receiptLineTable);
                
            }
            if (receiptTable != null)
            {
                if (string.IsNullOrEmpty(_slip_number))
                {
                    if (bRerceipt.AddOtherReceipt(receiptTable) > 0)
                    {
                        MessageBox.Show("临时入库成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();
                    }
                    else
                    {
                        MessageBox.Show("临时入库失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    receiptTable.SLIP_NUMBER = _slip_number;
                    if (bRerceipt.UpdateOther(receiptTable))
                    {
                        MessageBox.Show("更新成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("更新失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需要入库的产品。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}
