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
using CZZD.ERP.WinUI.Properties;
using System.Collections;

namespace CZZD.ERP.WinUI
{
    public partial class FrmPurchase : FrmBase
    {
        protected BPurchase bPurchase = new BPurchase();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private Hashtable hashTable = null;
        private decimal total_un_invoice_amount;
        private string slipnumber;

        public string SLIP
        {
            set { slipnumber = value; }
            get { return slipnumber; }
        }

        public FrmPurchase()
        {
            InitializeComponent();
        }

        private void FrmPurchase_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            if (string.IsNullOrEmpty(slipnumber))
            {
                #region dgvData
                this.dgvData.AutoGenerateColumns = false;
                this.dgvData.AllowUserToAddRows = false;
                this.dgvData.AllowUserToDeleteRows = false;

                PageSize = 16;
                dgvData.Rows.Add(PageSize);
                dgvData.Rows[0].Selected = true;

                #endregion
            }
            else
            {
                OperateInit();
                setStatus(false);
            }
        }

        #region 明细确认
        private void OperateInit()
        {
            BllPurchaseTable purchase = bPurchase.GetPurchaseModel(slipnumber);
            if (purchase != null)
            {
                txtSupplierCode.Text = purchase.SUPPLIER_CODE;
                if (!string.IsNullOrEmpty(purchase.SUPPLIER_CODE) && bCommon.GetBaseMaster("SUPPLIER", purchase.SUPPLIER_CODE) != null)
                {
                    txtSupplierName.Text = bCommon.GetBaseMaster("SUPPLIER", purchase.SUPPLIER_CODE).Name;
                }
                txtInvoiceNo.Text = purchase.INVOICE_NUMBER;
                txtInvoiceAmount.Text = CConvert.ToString(purchase.INVOICE_AMOUNT);
                txtInvoiceNoLocal.Text = purchase.INVOICE_NUMBER_LOCAL;
                txtInvoiceAmountLocal.Text = CConvert.ToString(purchase.INVOICE_AMOUNT_LOCAL);
                txtPurchaseDate.Value = purchase.SLIP_DATE;
                txtPaymentDate.Value = purchase.PAYMENT_DATE;
                //txtPackAmount.Text = CConvert.ToString(purchase.PACKING_AMOUNT);

                #region dgvData明细确认初始化
                int i = 1;
                dgvData.Rows.Clear();
                string currentSupplier = "";
                dgvData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                dgvData.ReadOnly = true;
                foreach (BllPurchaseLineTable line in purchase.Items)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow row = dgvData.Rows[currentRowIndex];
                    row.Cells["No"].Value = i++;
                    string SupplierCode = CConvert.ToString(row.Cells["SUPPLIER_CODE"].Value);
                    if (currentSupplier == "" || currentSupplier != SupplierCode)
                    {
                        currentSupplier = SupplierCode;
                        if (!string.IsNullOrEmpty(purchase.SUPPLIER_CODE))
                        {
                            row.Cells["SUPPLIER_NAME"].Value = bCommon.GetBaseMaster("SUPPLIER", purchase.SUPPLIER_CODE).Name;
                        }
                    }
                    row.Cells["PO_SLIP_NUMBER"].Value = line.PURCHASE_ORDER_NUMBER;
                    row.Cells["SLIP_NUMBER"].Value = line.RECEIPT_SLIP_NUMBER;
                    row.Cells["AMOUNT"].Value = line.INVOICE_AMOUNT;
                    if (!string.IsNullOrEmpty(line.CURRENCY_CODE))
                    {
                        row.Cells["CURRENCY_NAME"].Value = bCommon.GetBaseMaster("CURRENCY", line.CURRENCY_CODE).Name;
                    }
                    row.Cells["TAX_AMOUNT"].Value = line.TAX_AMOUNT;
                    row.Cells["PACKAGE_AMOUNT"].Value = line.PACKING_AMOUNT;
                    BllReceiptLineTable receiptLine = new BReceipt().GetLineModel(line.RECEIPT_SLIP_NUMBER, line.RECEIPT_LINE_NUMBER);
                    if (receiptLine != null)
                    {
                        if (!string.IsNullOrEmpty(receiptLine.PRODUCT_CODE))
                        {
                            row.Cells["PRODUCT_NAME"].Value = bCommon.GetBaseMaster("PRODUCT", receiptLine.PRODUCT_CODE).Name;
                        }
                        row.Cells["AMOUNT_INCLUDED_TAX"].Value = receiptLine.AMOUNT_INCLUDED_TAX;
                        decimal InAmount = bPurchase.GetGetInvoiceAmount(line.RECEIPT_SLIP_NUMBER);
                        if (receiptLine.AMOUNT_INCLUDED_TAX > 0 && InAmount > 0 && receiptLine.AMOUNT_INCLUDED_TAX >= InAmount)
                        {
                            row.Cells["UN_INVOICE_AMOUNT"].Value = receiptLine.AMOUNT_INCLUDED_TAX - InAmount;
                        }
                        else
                        {
                            row.Cells["UN_INVOICE_AMOUNT"].Value = 0;
                        }
                    }
                }
                #endregion
            }
        }

        private void setStatus(bool flag)
        {
            this.Text = "采购发票明细";
            txtSupplierCode.Enabled = flag;
            btnSupplier.Enabled = flag;
            txtInvoiceNo.Enabled = flag;
            txtInvoiceNoLocal.Enabled = flag;
            txtInvoiceAmount.Enabled = flag;
            txtInvoiceAmountLocal.Enabled = flag;
            txtPaymentDate.Enabled = flag;
            txtPurchaseDate.Enabled = flag;
            //txtPackAmount.Enabled = flag;
            dgvData.Columns["AMOUNT"].ReadOnly = !flag;
            dgvData.Columns["TAX_AMOUNT"].ReadOnly = !flag;
            dgvData.Columns["PACKAGE_AMOUNT"].ReadOnly = !flag;
            dgvData.Columns["UN_INVOICE_AMOUNT"].Visible = flag;
            //dgvData.Columns["Column1"].ReadOnly = !flag;
            btnSearch.Visible = flag;
            //btnDivPackAmount.Visible = flag;
            btnSave.Visible = flag;
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
                    BaseSupplierTable supplier = new BSupplier().GetModel(frm.BaseMasterTable.Code);
                    if (supplier.TYPE == CConstant.ERP_FOREIGN_NUMBER)
                    {
                        txtInvoiceNoLocal.Enabled = false;
                        txtInvoiceAmountLocal.Enabled = false;
                        txtInvoiceNoLocal.BackColor = SystemColors.Info;
                        txtInvoiceAmountLocal.BackColor = SystemColors.Info;
                        txtInvoiceNoLocal.Text = "";
                        txtInvoiceAmountLocal.Text = "";
                        txtInvoiceNo.Enabled = true;
                        txtInvoiceAmount.Enabled = true;
                        txtInvoiceNo.BackColor = Color.FromArgb(255, 192, 192);
                        txtInvoiceAmount.BackColor = Color.FromArgb(255, 192, 192);
                        //txtPackAmount.Text = "";
                        //txtPackAmount.Enabled = true;
                        //btnDivPackAmount.Enabled = true;
                        txtInvoiceNo.Focus();
                    }
                    else if (supplier.TYPE == CConstant.ERP_DOMESTIC_NUMBER)
                    {
                        txtInvoiceNo.Enabled = false;
                        txtInvoiceAmount.Enabled = false;
                        txtInvoiceNo.BackColor = SystemColors.Info;
                        txtInvoiceAmount.BackColor = SystemColors.Info;
                        txtInvoiceNo.Text = "";
                        txtInvoiceAmount.Text = "";
                        txtInvoiceNoLocal.Enabled = true;
                        txtInvoiceAmountLocal.Enabled = true;
                        txtInvoiceNoLocal.BackColor = Color.FromArgb(255, 192, 192);
                        txtInvoiceAmountLocal.BackColor = Color.FromArgb(255, 192, 192);
                        //txtPackAmount.Text = "0";
                        //txtPackAmount.Enabled = false;
                        //btnDivPackAmount.Enabled = false;
                        txtInvoiceNoLocal.Focus();
                    }
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (SupplierCode != "")
            {
                BaseSupplierTable supplier = new BSupplier().GetModel(SupplierCode);
                if (supplier != null)
                {
                    txtSupplierCode.Text = supplier.CODE;
                    txtSupplierName.Text = supplier.NAME;
                    if (supplier.TYPE == CConstant.ERP_FOREIGN_NUMBER)
                    {
                        txtInvoiceNoLocal.Enabled = false;
                        txtInvoiceAmountLocal.Enabled = false;
                        txtInvoiceNoLocal.BackColor = SystemColors.Info;
                        txtInvoiceAmountLocal.BackColor = SystemColors.Info;
                        txtInvoiceNoLocal.Text = "";
                        txtInvoiceAmountLocal.Text = "";
                        txtInvoiceNo.Enabled = true;
                        txtInvoiceAmount.Enabled = true;
                        txtInvoiceNo.BackColor = Color.FromArgb(255, 192, 192);
                        txtInvoiceAmount.BackColor = Color.FromArgb(255, 192, 192);
                        if (string.IsNullOrEmpty(slipnumber))
                        {
                            //txtPackAmount.Text = "";
                            //txtPackAmount.Enabled = true;
                            //btnDivPackAmount.Enabled = true;
                        }
                    }
                    else if (supplier.TYPE == CConstant.ERP_DOMESTIC_NUMBER)
                    {
                        txtInvoiceNo.Enabled = false;
                        txtInvoiceAmount.Enabled = false;
                        txtInvoiceNo.BackColor = SystemColors.Info;
                        txtInvoiceAmount.BackColor = SystemColors.Info;
                        txtInvoiceNo.Text = "";
                        txtInvoiceAmount.Text = "";
                        txtInvoiceNoLocal.Enabled = true;
                        txtInvoiceAmountLocal.Enabled = true;
                        txtInvoiceNoLocal.BackColor = Color.FromArgb(255, 192, 192);
                        txtInvoiceAmountLocal.BackColor = Color.FromArgb(255, 192, 192);
                        if (string.IsNullOrEmpty(slipnumber))
                        {
                            //txtPackAmount.Text = "0";
                            //txtPackAmount.Enabled = false;
                            //btnDivPackAmount.Enabled = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("供应商不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
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

        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (SearchCheck())
            {
                string where = GetCondition();
                string orderby = "ORDER BY SUPPLIER_CODE,PO_SLIP_NUMBER,SLIP_NUMBER ";
                DataTable dt = bPurchase.GetPurchaseEntryDataList(where + orderby).Tables[0];
                hashTable = new Hashtable();
                total_un_invoice_amount = 0;

                //初期化
                this.dgvData.Rows.Clear();

                if (dt.Rows.Count > 0)
                {                    

                    //dgvData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                    //
                    int i = 1;
                    string currentSupplierCode = "";

                    foreach (DataRow dr in dt.Rows)
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow row = dgvData.Rows[currentRowIndex];
                        row.Cells["NO"].Value = i++;
                        string supplierCode = CConvert.ToString(dr["SUPPLIER_CODE"]);
                        if (currentSupplierCode == "" || currentSupplierCode != supplierCode)
                        {
                            //供应商
                            currentSupplierCode = supplierCode;
                            row.Cells["SUPPLIER_NAME"].Value = dr["SUPPLIER_NAME"];
                        }
                        row.Cells["SUPPLIER_CODE"].Value = dr["SUPPLIER_CODE"];

                        //采购订单编号
                        row.Cells["PO_SLIP_NUMBER"].Value = dr["PO_SLIP_NUMBER"];

                        row.Cells["PRODUCT_CODE"].Value = dr["PRODUCT_CODE"];
                        //商品名称
                        row.Cells["PRODUCT_NAME"].Value = dr["PRODUCT_NAME"];

                        //入库编号
                        row.Cells["SLIP_NUMBER"].Value = dr["SLIP_NUMBER"];

                        //入库明细编号
                        row.Cells["RECEIPT_LINE_NUMBER"].Value = dr["RECEIPT_LINE_NUMBER"];

                        //入库金额
                        row.Cells["AMOUNT_INCLUDED_TAX"].Value = dr["AMOUNT_INCLUDED_TAX"];

                        //货币
                        row.Cells["CURRENCY_CODE"].Value = dr["CURRENCY_CODE"];
                        row.Cells["CURRENCY_NAME"].Value = dr["CURRENCY_NAME"];

                        //未开票金额
                        row.Cells["UN_INVOICE_AMOUNT"].Value = dr["UN_INVOICE_AMOUNT"];
                        hashTable.Add(row.Cells["NO"].Value, dr["UN_INVOICE_AMOUNT"]);
                        total_un_invoice_amount += CConvert.ToDecimal(dr["UN_INVOICE_AMOUNT"]);

                        row.Cells["ALL"].Value = "ALL";

                        if (txtInvoiceNo.Enabled && txtInvoiceAmount.Enabled)
                        {
                            row.Cells["AMOUNT"].Style.BackColor = System.Drawing.SystemColors.Info;
                            row.Cells["AMOUNT"].Style.SelectionForeColor = System.Drawing.SystemColors.ControlText;
                            row.Cells["AMOUNT"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;

                            row.Cells["TAX_AMOUNT"].Style.BackColor = System.Drawing.SystemColors.Info;
                            row.Cells["TAX_AMOUNT"].Style.SelectionForeColor = System.Drawing.SystemColors.ControlText;
                            row.Cells["TAX_AMOUNT"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;

                            row.Cells["PACKAGE_AMOUNT"].Style.BackColor = System.Drawing.SystemColors.Info;
                            row.Cells["PACKAGE_AMOUNT"].Style.SelectionForeColor = System.Drawing.SystemColors.ControlText;
                            row.Cells["PACKAGE_AMOUNT"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;

                            row.Cells["ALL"].Style.BackColor = System.Drawing.SystemColors.Info;
                            row.Cells["ALL"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;

                            row.Cells["TAX_AMOUNT"].Value = 0.00;
                            row.Cells["PACKAGE_AMOUNT"].Value = 0.00;

                            row.Cells["AMOUNT"].ReadOnly = false;
                            row.Cells["TAX_AMOUNT"].ReadOnly = false;
                            row.Cells["PACKAGE_AMOUNT"].ReadOnly = false;
                        }
                        else if (txtInvoiceNoLocal.Enabled && txtInvoiceAmountLocal.Enabled)
                        {
                            row.Cells["AMOUNT"].Style.BackColor = System.Drawing.SystemColors.Info;
                            row.Cells["AMOUNT"].Style.SelectionForeColor = System.Drawing.SystemColors.ControlText;
                            row.Cells["AMOUNT"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;

                            row.Cells["ALL"].Style.BackColor = System.Drawing.SystemColors.Info;
                            row.Cells["ALL"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;

                            row.Cells["TAX_AMOUNT"].Value = 0.00;
                            row.Cells["PACKAGE_AMOUNT"].Value = 0.00;

                            row.Cells["TAX_AMOUNT"].ReadOnly = true;
                            row.Cells["PACKAGE_AMOUNT"].ReadOnly = true;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //补空行
                for (int i = dt.Rows.Count; i < 16; i++)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow row = dgvData.Rows[currentRowIndex];
                    row.Cells["AMOUNT"].ReadOnly = true;
                    row.Cells["TAX_AMOUNT"].ReadOnly = true;
                    row.Cells["PACKAGE_AMOUNT"].ReadOnly = true;
                }

            }
        }

        private bool SearchCheck()
        {
            string strErrlog = null;
            if (string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                strErrlog += "供应商不能为空!\r\n";
            }
            if (txtInvoiceNo.Enabled && string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                strErrlog += "INVOICE No.不能为空!\r\n";
            }
            if (txtInvoiceAmount.Enabled && string.IsNullOrEmpty(txtInvoiceAmount.Text.Trim()))
            {
                strErrlog += "INV.合计金额不能为空!\r\n";
            }
            if (txtInvoiceNoLocal.Enabled && string.IsNullOrEmpty(txtInvoiceNoLocal.Text.Trim()))
            {
                strErrlog += "发票No不能为空!\r\n";
            }
            if (txtInvoiceAmountLocal.Enabled && string.IsNullOrEmpty(txtInvoiceAmountLocal.Text.Trim()))
            {
                strErrlog += "发票合计金额不能为空!\r\n";
            }
            if (!string.IsNullOrEmpty(strErrlog))
            {
                MessageBox.Show(strErrlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        //绘制单元格时发生事件
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //DataGridView dgv = (DataGridView)(sender);
            //if (e.RowIndex >= 0 && dgvData.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
            //{
            //    DataGridViewRow row = dgv.Rows[e.RowIndex];
            //    if (txtInvoiceNo.Enabled && txtInvoiceAmount.Enabled)
            //    {
            //        if (!"".Equals(row.Cells["No"].Value))
            //        {
            //            row.Cells["AMOUNT"].Style.BackColor = Color.FromArgb(255, 255, 192);
            //            row.Cells["PACKAGE_AMOUNT"].Style.BackColor = Color.FromArgb(255, 255, 192);
            //            row.Cells["AMOUNT"].ReadOnly = false;
            //            row.Cells["PACKAGE_AMOUNT"].ReadOnly = false;
            //        }
            //        else
            //        {
            //            row.Cells["AMOUNT"].ReadOnly = true;
            //            row.Cells["PACKAGE_AMOUNT"].ReadOnly = true;
            //        }

            //        dgv.Columns["TAX_AMOUNT"].ReadOnly = true;

            //    }
            //    else if (txtInvoiceNoLocal.Enabled && txtInvoiceAmountLocal.Enabled)
            //    {
            //        row.Cells["AMOUNT"].Style.BackColor = Color.FromArgb(255, 255, 192);
            //        //row.Cells["TAX_AMOUNT"].Style.BackColor = Color.White;
            //        row.Cells["PACKAGE_AMOUNT"].Style.BackColor = Color.White;
            //        row.Cells["TAX_AMOUNT"].Value = 0;
            //        row.Cells["PACKAGE_AMOUNT"].Value = 0;
            //        //dgv.Columns["AMOUNT"].ReadOnly = false;
            //        dgv.Columns["TAX_AMOUNT"].ReadOnly = true;
            //        dgv.Columns["PACKAGE_AMOUNT"].ReadOnly = true;
            //    }
            //}
        }
        #endregion

        #region 查询条件
        private string GetCondition()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0} ", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                sb.AppendFormat(" and SUPPLIER_CODE = '{0}'", txtSupplierCode.Text);
            }
            //if (txtInvoiceNo.Enabled && !string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            //{
            //    sb.AppendFormat(" and INVOICE_NUMBER like '{0}%'", txtInvoiceNo.Text.Trim());
            //}
            if (txtReceiptDateFrom.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE >= '{0}'", txtReceiptDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (txtReceiptDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE < '{0}'", txtReceiptDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            return sb.ToString();
        }
        #endregion

        #region dgvData输入数字
        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["No"].Value == null || "".Equals(row.Cells["No"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "AMOUNT")
            {
                e.Control.KeyPress += new KeyPressEventHandler(InputAmount);
            }
            if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "TAX_AMOUNT")
            {
                e.Control.KeyPress += new KeyPressEventHandler(InputAmount);
            }
            if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "PACKAGE_AMOUNT")
            {
                e.Control.KeyPress += new KeyPressEventHandler(InputAmount);
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtInvoiceAmountLocal.Focused || txtInvoiceAmount.Focused)
                {
                    txtPurchaseDate.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }
            if ( txtInvoiceAmount.Focused || txtInvoiceAmountLocal.Focused)
            {
                InputAmount(sender, e);
            }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                List<BllPurchaseTable> datas = new List<BllPurchaseTable>();

                BllPurchaseTable purchaseTable = new BllPurchaseTable();
                DateTime currentDate = DateTime.Now;
                decimal packing_amount = 0;

                //表头信息的保存
                //付款公司编号
                purchaseTable.SUPPLIER_CODE = this.txtSupplierCode.Text.Trim();
                //国外发票编
                purchaseTable.INVOICE_NUMBER = this.txtInvoiceNo.Text.Trim();
                //国内发票编号
                purchaseTable.INVOICE_NUMBER_LOCAL = this.txtInvoiceNoLocal.Text.Trim();
                //开票日期
                purchaseTable.SLIP_DATE = this.txtPurchaseDate.Value;
                //付款预定日
                purchaseTable.PAYMENT_DATE = this.txtPaymentDate.Value;
                //国外发票金额
                purchaseTable.INVOICE_AMOUNT = CConvert.ToDecimal(this.txtInvoiceAmount.Text.Trim());
                //国内发票金额
                purchaseTable.INVOICE_AMOUNT_LOCAL = CConvert.ToDecimal(this.txtInvoiceAmountLocal.Text.Trim());
                //包装费金额
                //purchaseTable.PACKING_AMOUNT = CConvert.ToDecimal(this.txtPackAmount.Text.Trim());
                //状态
                purchaseTable.STATUS_FLAG = CConstant.INIT;
                //创建人           
                purchaseTable.CREATE_USER = UserTable.CODE;
                //创建时间
                purchaseTable.CREATE_DATE_TIME = currentDate;
                //最后更新人
                purchaseTable.LAST_UPDATE_USER = UserTable.CODE;
                //最后更新时间
                purchaseTable.LAST_UPDATE_TIME = currentDate;
                // 公司 
                purchaseTable.COMPANY_CODE = UserTable.COMPANY_CODE;

                //明细信息保存
                int lineNo = 1;
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    decimal amount = CConvert.ToDecimal(CConvert.ToString(row.Cells["AMOUNT"].Value));
                    if (amount == 0)
                    {
                        continue;
                    }

                    BllPurchaseLineTable purchaseLineTable = new BllPurchaseLineTable();
                    //明细编号
                    purchaseLineTable.LINE_NUMBER = lineNo;
                    lineNo++;

                    //采购订单
                    purchaseLineTable.PURCHASE_ORDER_NUMBER = CConvert.ToString(row.Cells["PO_SLIP_NUMBER"].Value);
                    //入库编号
                    purchaseLineTable.RECEIPT_SLIP_NUMBER = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                    //入库明细单号
                    purchaseLineTable.RECEIPT_LINE_NUMBER = CConvert.ToInt32(row.Cells["RECEIPT_LINE_NUMBER"].Value);
                    //开票金额
                    purchaseLineTable.INVOICE_AMOUNT = amount;
                    //关税
                    purchaseLineTable.TAX_AMOUNT = CConvert.ToDecimal(row.Cells["TAX_AMOUNT"].Value);
                    //包装费用
                    purchaseLineTable.PACKING_AMOUNT = CConvert.ToDecimal(row.Cells["PACKAGE_AMOUNT"].Value);
                    packing_amount += purchaseLineTable.PACKING_AMOUNT;
                    //货币编号 
                    purchaseLineTable.CURRENCY_CODE = CConvert.ToString(row.Cells["CURRENCY_CODE"].Value);
                    //状态
                    purchaseLineTable.STATUS_FLAG = CConstant.INIT;

                    //存入表头
                    purchaseTable.Items.Add(purchaseLineTable);
                }
                //包装费金额
                purchaseTable.PACKING_AMOUNT = packing_amount;
                if (purchaseTable.Items.Count == 0)
                {
                    MessageBox.Show("请输入入库明细的发票金额。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                int result = 0;
                try
                {
                    result = bPurchase.Add(purchaseTable);
                    if (result <= 0)
                    {
                        MessageBox.Show("采购发票保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("采购发票保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("采购发票保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("采购发票保存失败!!!!!", ex);
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region 保存前验证
        public bool saveCheck()
        {
            string strErrlog = null;
            decimal total = 0;
            decimal InvoiceAmount = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                total += CConvert.ToDecimal(row.Cells["PACKAGE_AMOUNT"].Value);
                InvoiceAmount += CConvert.ToDecimal(row.Cells["AMOUNT"].Value);
            }
            if (txtInvoiceNo.Enabled && txtInvoiceAmount.Enabled)
            {
                if (InvoiceAmount != CConvert.ToDecimal(txtInvoiceAmount.Text))
                {
                    strErrlog += "明细开票金额必须与INV.合计金额相等!\r\n";
                }
            }
            else if (txtInvoiceNoLocal.Enabled && txtInvoiceAmountLocal.Enabled)
            {
                if (InvoiceAmount != CConvert.ToDecimal(txtInvoiceAmountLocal.Text))
                {
                    strErrlog += "明细开票金额必须与发票合计金额相等!\r\n";
                }
            }
            //if (CConvert.ToDecimal(txtPackAmount.Text) != total)
            //{
            //    strErrlog += "明细的包装费用必须与总费用相等!\r\n";
            //}
            if (!string.IsNullOrEmpty(strErrlog))
            {
                MessageBox.Show(strErrlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
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
            //供应商
            this.txtSupplierCode.Text = "";
            this.txtSupplierName.Text = "";
            //INVOICE
            this.txtInvoiceNo.Text = "";
            this.txtInvoiceAmount.Text = "";
            this.txtInvoiceNo.Enabled = false;
            txtInvoiceNo.BackColor = SystemColors.Info;
            this.txtInvoiceAmount.Enabled = false;
            this.txtInvoiceAmount.BackColor = SystemColors.Info;
            //发票
            this.txtInvoiceNoLocal.Text = "";
            this.txtInvoiceAmountLocal.Text = "";
            this.txtInvoiceNoLocal.Enabled = false;
            this.txtInvoiceNoLocal.BackColor = SystemColors.Info;
            this.txtInvoiceAmountLocal.Enabled = false;
            this.txtInvoiceAmountLocal.BackColor = SystemColors.Info;
            //入库日
            this.txtReceiptDateFrom.Value = DateTime.Now;
            this.txtReceiptDateFrom.Checked = false;
            this.txtReceiptDateTo.Value = DateTime.Now;
            this.txtReceiptDateTo.Checked = false;
            //销售日期
            this.txtPurchaseDate.Value = DateTime.Now;
            //付款预定日
            this.txtPaymentDate.Value = DateTime.Now;
            //包装金额
            //this.txtPackAmount.Text = "";

            this.dgvData.Rows.Clear();
        }

        #endregion

        //#region   包装费用
        //private void btnDivPackAmount_Click(object sender, EventArgs e)
        //{
        //    if (txtPackAmount.Text != "")
        //    {
        //        if (CConvert.ToDecimal(txtPackAmount.Text) > 0 && hashTable.Count > 0 && total_un_invoice_amount > 0)
        //        {
        //            decimal total = CConvert.ToDecimal(txtPackAmount.Text);
        //            decimal other = 0;
        //            int i = 1;
        //            foreach (DataGridViewRow row in dgvData.Rows)
        //            {
        //                if (i < dgvData.Rows.Count)
        //                {
        //                    if (row.Cells["PO_SLIP_NUMBER"].Value != null && row.Cells["PO_SLIP_NUMBER"].Value.ToString() != "")
        //                    {
        //                        row.Cells["PACKAGE_AMOUNT"].Value = Math.Round((CConvert.ToDecimal(row.Cells["UN_INVOICE_AMOUNT"].Value) / total_un_invoice_amount) * total, 2);
        //                        other += CConvert.ToDecimal(row.Cells["PACKAGE_AMOUNT"].Value);
        //                        i++;
        //                    }
        //                }
        //                else if (i == dgvData.Rows.Count)
        //                {
        //                    if (row.Cells["PO_SLIP_NUMBER"].Value != null && row.Cells["PO_SLIP_NUMBER"].Value.ToString() != "")
        //                    {
        //                        row.Cells["PACKAGE_AMOUNT"].Value = total - other;
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("包装费用不能小于0!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("包装费用不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //}
        //#endregion

        #region dgvData单元格验证
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
            string suppliercode = CConvert.ToString(dr.Cells["SUPPLIER_CODE"].Value);
            if (!string.IsNullOrEmpty(suppliercode))
            {
                if (e.ColumnIndex == dgvData.Columns["AMOUNT"].Index)
                {
                    if (CConvert.ToDecimal(dr.Cells["AMOUNT"].Value) > CConvert.ToDecimal(dr.Cells["AMOUNT_INCLUDED_TAX"].Value))
                    {
                        MessageBox.Show("开票金额不能大于金额!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dr.Cells["AMOUNT"].Value = "";
                        dr.Cells["AMOUNT"].Selected = true;
                    }

                    if (new BSupplier().GetModel(suppliercode).TYPE == 1)
                    {
                        string productcode = CConvert.ToString(dr.Cells["PRODUCT_CODE"].Value);
                        if (!string.IsNullOrEmpty(productcode))
                        {
                            string hscode = new BProduct().GetModel(productcode).HS_CODE;
                            decimal exch = 0;
                            DateTime date = CConvert.ToDateTime(txtPurchaseDate.Value.Year + "/" + txtPurchaseDate.Value.Month + "/" + 1);
                            try
                            {
                                exch = new BExchange().GetModel(date, dr.Cells["CURRENCY_CODE"].Value.ToString()).EXCHANGE_RATE;
                            }
                            catch { exch = 1; }
                            if (!string.IsNullOrEmpty(hscode))
                            {
                                decimal tax = new BHsCode().GetModel(hscode).TAX_RATE;
                                dr.Cells["TAX_AMOUNT"].Value = CConvert.ToDecimal(dr.Cells["AMOUNT"].Value) * (tax / 100) * (exch / 100);
                            }
                            else
                            {
                                dr.Cells["TAX_AMOUNT"].Value = 0;
                            }
                        }
                        else
                        {
                            dr.Cells["TAX_AMOUNT"].Value = 0;
                        }
                    }
                }
            }
        }
        #endregion

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["ALL"].Index)
                {
                    row.Cells["AMOUNT"].Value = row.Cells["UN_INVOICE_AMOUNT"].Value;
                }
            }
        }
    }
}
