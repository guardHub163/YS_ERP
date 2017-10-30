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
using CZZD.ERP.Model;
using CZZD.ERP.WinUI;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmReceipt : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private bool isSearch = false;

        public FrmReceipt()
        {
            InitializeComponent();
        }

        private void FrmReceipt_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            init();
        }

        #region dgvData初始化
        public void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 16;
            dgvData.Rows.Add(PageSize);
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Columns["RECEIPT_CHK"].Visible = false;
            #endregion
        }
        #endregion

        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            isSearch = true;
            this.dgvData.Columns["RECEIPT_QUANTITY"].ReadOnly = false;
            Search(1);
            //this.dgvData.Rows[0].Cells["RECEIPT_CHK"].Selected = true;            
        }

        private void Search(int currentPage)
        {
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
            DataSet ds = bRerceipt.GetList(strWhere);
            dgvData.Rows.Clear();

            if (ds.Tables[0].Rows.Count > 0)
            {
                int i = 1;
                foreach (DataRow rows in ds.Tables[0].Rows)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow row = dgvData.Rows[currentRowIndex];
                    row.Cells["No"].Value = i;
                    row.Cells["SLIP_NUMBER"].Value = rows["SLIP_NUMBER"];
                    row.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value = rows["PURCHASE_ORDER_SLIP_NUMBER"];
                    row.Cells["SUPPLIER_NAME"].Value = rows["SUPPLIER_NAME"];
                    row.Cells["WAREHOUSE_NAME"].Value = rows["WAREHOUSE_NAME"];
                    row.Cells["DUE_DATE"].Value = rows["DUE_DATE"];
                    row.Cells["PRODUCT_CODE"].Value = rows["PRODUCT_CODE"];
                    row.Cells["PRODUCT_NAME"].Value = rows["PRODUCT_NAME"];
                    row.Cells["RECEIPT_PLAN_QUANTITY"].Value = Convert.ToInt32(rows["RECEIPT_PLAN_QUANTITY"]);
                    row.Cells["RECEIPT_QUANTITY"].Value = Convert.ToInt32(rows["RECEIPT_PLAN_QUANTITY"]);
                    row.Cells["QUANTITY"].Value = Convert.ToInt32(rows["QUANTITY"]);
                    row.Cells["UNIT_NAME"].Value = rows["UNIT_NAME"];
                    row.Cells["PURCHASE_ORDER_LINE_NUMBER"].Value = rows["PURCHASE_ORDER_LINE_NUMBER"];
                    row.Cells["RECEIPT_QUANTITY"].Style.BackColor = System.Drawing.SystemColors.Info;
                    if (rows["FROMSET_FLAG"].ToString() == "1")
                    {
                        row.Cells["FROMSET"].Value = "否";
                    }
                    else
                    {
                        row.Cells["FROMSET"].Value = "是";
                    }
                    i++;
                }
                //dgvData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                this.dgvData.Columns["RECEIPT_CHK"].Visible = true;
                //this.dgvData.DataSource = _currentDt;
            }
            else
            {
                init();
                this.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
            }
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
                sb.AppendFormat("and PURCHASE_ORDER_SLIP_NUMBER like '{0}%'", txtSlipNumber.Text.Trim());
            }

            if (txtSupplierCode.Text.Trim() != "")
            {
                sb.AppendFormat("and SUPPLIER_CODE = '{0}'", txtSupplierCode.Text.Trim());
            }

            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat("and RECEIPT_WAREHOUSE_CODE = '{0}'", txtWarehouseCode.Text.Trim());
            }

            if (txtSlipDateFrom.Checked)
            {
                sb.AppendFormat("and SLIP_DATE >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            else if (txtSlipDateTo.Checked)
            {
                sb.AppendFormat("and SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            if (txtReceiptDataFrom.Checked)
            {
                sb.AppendFormat("and DUE_DATE >= '{0}'", txtReceiptDataFrom.Value.ToString("yyyy-MM-dd"));
            }
            else if (txtReceiptDataTo.Checked)
            {
                sb.AppendFormat("and DUE_DATE < '{0}'", txtReceiptDataTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            return sb.ToString();
        }

        //绘制单元格时发生事件
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex >= 0 && dgvData.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                row.Cells["RECEIPT_QUANTITY"].Style.BackColor = SystemColors.Info;
            }
        }

        #endregion

        #region 列编辑后验证
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvData.Columns["RECEIPT_QUANTITY"].Index)
            {
                //Int32 price;
                //if (Int32.TryParse(CConvert.ToString(dr.Cells["RECEIPT_QUANTITY"].Value),
                //    System.Globalization.NumberStyles.Integer,
                //    System.Globalization.NumberFormatInfo.CurrentInfo, out price) )
                //{
                if (CConvert.ToInt32(dr.Cells["RECEIPT_PLAN_QUANTITY"].Value) < CConvert.ToInt32(dr.Cells["RECEIPT_QUANTITY"].Value))
                {
                    MessageBox.Show("入库数量不能大于入库预定数量,请重新输入!");
                    dr.Cells["RECEIPT_QUANTITY"].Value = "0";
                }
                //}                
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

        #region 一括设定
        //private void btnAllSet_Click(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewRow dr in dgvData.Rows)
        //    {
        //        if (Convert.ToBoolean(dr.Cells["RECEIPT_CHK"].Value))
        //        {
        //            dr.Cells["InvoiceNo"].Value = txtInvoiceNo.Text.Trim();
        //        }
        //    }
        //    txtSlipDateFrom.Focus();
        //}
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<BllReceiptTable> receiptList = new List<BllReceiptTable>();
            BllReceiptTable receiptTable = null;
            string currentPoSlipNumber = "";
            bool IsInstallments = false;

            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["RECEIPT_CHK"].Value) && (dgvr.Cells["RECEIPT_QUANTITY"].Value != null))
                {
                    string poSlipNumber = CConvert.ToString(dgvr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value);

                    if (currentPoSlipNumber != poSlipNumber)
                    {
                        if (currentPoSlipNumber != "")
                        {
                            receiptList.Add(receiptTable);

                        }
                        receiptTable = new BllReceiptTable();
                        receiptTable.PO_SLIP_NUMBER = poSlipNumber;
                        receiptTable.STATUS_FLAG = CConstant.INIT;
                        receiptTable.COMPANY_CODE = UserTable.COMPANY_CODE;
                        receiptTable.CREATE_USER = UserTable.CODE;
                        receiptTable.LAST_UPDATE_USER = UserTable.CODE;
                        receiptTable.RECEIPT_FLAG = 1;
                        currentPoSlipNumber = poSlipNumber;
                    }
                    
                    //RECEIPT_PLAN_QUANTITY
                    BllReceiptLineTable receiptLineTable = new BllReceiptLineTable();

                    //入库数量
                    decimal receiptQuantity = CConvert.ToDecimal(dgvr.Cells["RECEIPT_QUANTITY"].Value);

                    //预定数量
                    decimal receiptPlanQuantity = CConvert.ToDecimal(dgvr.Cells["RECEIPT_PLAN_QUANTITY"].Value);

                    if (receiptPlanQuantity > receiptQuantity)
                    {
                        IsInstallments = true;
                    }
                    BllReceiptPlanTable RPTable = bRerceipt.GetReceiptPlanModel(Convert.ToInt32(dgvr.Cells["SLIP_NUMBER"].Value));

                    //Receipt_Line 表中数据
                    receiptLineTable.RECEIPT_PLAN_NUMBER = RPTable.SLIP_NUMBER;
                    receiptLineTable.RECEIPT_WAREHOUSE_CODE = RPTable.RECEIPT_WAREHOUSE_CODE;
                    receiptLineTable.PRODUCT_CODE = RPTable.PRODUCT_CODE;
                    receiptLineTable.QUANTITY = receiptQuantity;
                    receiptLineTable.UNIT_CODE = RPTable.UNIT_CODE;
                    receiptLineTable.PRICE = RPTable.PRICE;
                    receiptLineTable.AMOUNT_INCLUDED_TAX = receiptLineTable.QUANTITY * receiptLineTable.PRICE;
                    receiptLineTable.AMOUNT_WITHOUT_TAX = WithoutAmount(receiptLineTable.AMOUNT_INCLUDED_TAX, RPTable.TAX_RATE);
                    receiptLineTable.TAX_AMOUNT = receiptLineTable.AMOUNT_INCLUDED_TAX - receiptLineTable.AMOUNT_WITHOUT_TAX;
                    receiptLineTable.SUPPLIER_CODE = RPTable.SUPPLIER_CODE;
                    receiptLineTable.CURRENCY_CODE = RPTable.CURRENCY_CODE;
                    receiptLineTable.TAX_RATE = RPTable.TAX_RATE;
                    receiptLineTable.INVOICE_NUMBER = CConvert.ToString(dgvr.Cells["InvoiceNo"].Value);
                    receiptTable.AddItem(receiptLineTable);
                }
            }

            if (receiptTable != null)
            {
                receiptList.Add(receiptTable);
            }

            if (receiptList.Count > 0)
            {
                DateTime time = DateTime.Now;
                if (IsInstallments)
                {
                    FrmChoseReceipt frm = new FrmChoseReceipt();
                    DialogResult resule = frm.ShowDialog(this);
                    IsInstallments = frm.IsInstallments;
                    time = frm.time;
                    if (resule== DialogResult.Cancel )
                    {
                        //分纳取消，取消入库
                        return;
                    }
                }                

                if (bRerceipt.Receipt(receiptList, IsInstallments, time) > 0)
                {
                    MessageBox.Show("采购入库成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Search(1);
                }
                else
                {
                    MessageBox.Show("采购入库失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请选择需要入库的采购订单。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #endregion

        #region dgvData 控制
        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["SLIP_NUMBER"].Value == null || "".Equals(row.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

        /// <summary>
        /// 控制只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "RECEIPT_QUANTITY")
            {
                e.Control.KeyPress += new KeyPressEventHandler(InputInteger);
            }
        }
        #endregion

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
                    MessageBox.Show("供应商编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtSupplierCode.Text = SupplierCode.CODE;
                    txtSupplierName.Text = SupplierCode.NAME;
                }
            }
            else
            {
                txtSupplierName.Text = "";
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
                    //txtInvoiceNo.Focus();
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
                    MessageBox.Show("仓库编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtWarehouseCode.Text = Warehouse.CODE;
                    txtWarehouseName.Text = Warehouse.NAME;
                }
            }
            else
            {
                txtWarehouseName.Text = "";
            }
        }
        #endregion

        #region 按键顺序
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //System.Windows.Forms.SendKeys.Send("+{Tab}");
                this.SelectNextControl(this.ActiveControl, false, true, true, false);
            }
            if (e.KeyCode == Keys.Down)
            {
                //System.Windows.Forms.SendKeys.Send("{Tab}");
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
            }
        }
        #endregion

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["FROMSET"].Index)
                {
                    if (CConvert.ToString(dr.Cells["FROMSET"].Value) == "是")
                    {
                        string attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PURCHASE);
                        string slipNumber = txtSlipNumber.Text;
                        string product = CConvert.ToString(dr.Cells["PRODUCT_CODE"].Value);
                        FrmPOAttached frm = null;
                        frm = new FrmPOAttached(dr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value.ToString(), dr.Cells["PRODUCT_CODE"].Value.ToString(), attachedDirectory, CConstant.PURCHASE_NEW);
                        frm.ShowDialog(this);
                        frm.Dispose();
                    }
                }
            }
        }


    }
}
