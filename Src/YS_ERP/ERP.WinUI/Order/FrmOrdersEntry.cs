using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.CacheData;
using System.Collections;
using CZZD.ERP.Common;
using System.IO;
using System.Text.RegularExpressions;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmOrdersEntry : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private string _operateMode = CConstant.ORDER_NEW;
        private string _oldSlipNumber = "";
        private DialogResult _dialogResult = DialogResult.Cancel;

        private string _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
        private string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_ORDER);
        private int attachedNumber = 0;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmOrdersEntry()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmOrdersEntry(string slipNumber)
        {
            InitializeComponent();
            _oldSlipNumber = slipNumber;
        }
        #endregion

        #region init  页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOrdersEntry_Load(object sender, EventArgs e)
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
            //cboTax.ValueMember = "CODE";
            //cboTax.DisplayMember = "DISP_TAX_RATE";
            //cboTax.DataSource = dtTaxation;
            #endregion

            txtver.Text = "1";

            #region 货币的初始化
            //货币的初始化  
            DataTable dtCurrency = CCacheData.Currency.Copy();
            cboCurrency.ValueMember = "CODE";
            cboCurrency.DisplayMember = "NAME";
            cboCurrency.DataSource = dtCurrency;
            #endregion

            #region
            txtDepartualDate.Value = txtSlipDate.Value.AddMonths(1);
            #endregion

            init();

            #region 自动提示文本输入框
            AutoCompleteStringCollection strings = new AutoCompleteStringCollection();

            strings = new AutoCompleteStringCollection();
            strings.AddRange(CCacheData.GetBaseNamesData("DeliveryTerms"));
            txtDeliveryTerms.AutoCompleteCustomSource = strings;
            txtDeliveryTerms.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDeliveryTerms.AutoCompleteMode = AutoCompleteMode.Suggest;


            strings = new AutoCompleteStringCollection();
            strings.AddRange(CCacheData.GetBaseNamesData("PaymentTerms"));
            txtPaymentTerms.AutoCompleteCustomSource = strings;
            txtPaymentTerms.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPaymentTerms.AutoCompleteMode = AutoCompleteMode.Suggest;
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        private void init()
        {
            //订单输入 
            if (CConstant.ORDER_NEW.Equals(CTag))
            {
                this.Text = "订单输入";
                initSlipNumber();
                setStatus(true);
                this.btnOrderDelete.Visible = false;
                dgvData.Rows.Add(1);
            }
            //历史记录
            if (CConstant.ORDER_HISTORY.Equals(CTag))
            {
                this.Text = "历史记录";
                initHistoryData();
                setStatus(false);
                this.btnAttached.Visible = false;
                this.btnSave.Visible = false;
                this.btnOrderDelete.Visible = false;
            }
            //订单修正    
            else if (CConstant.ORDER_MODIFY.Equals(CTag))
            {
                this.Text = "订单修正";
                initData();
                dgvData.Rows.Add(1);
                setStatus(true);
            }
            //订单审核     
            else if (CConstant.ORDER_VERIFY.Equals(CTag))
            {
                this.Text = "订单通知";
                initData();
                setStatus(false);
                this.btnAttached.Visible = false;
                this.btnOrderDelete.Visible = false;
                //this.btnOrderDelete.Text = "审核不过";
                this.btnSave.Text = "通知";
            }
            //复制订单     
            else if (CConstant.ORDER_COPY.Equals(CTag))
            {
                this.Text = "复制订单";
                initSlipNumber();
                initData();
                setStatus(true);
            }
            else if (CConstant.ORDER_SEARCH.Equals(CTag))
            {
                this.Text = "订单详细";
                initData();
                setStatus(false);
                this.btnAttached.Visible = false;
                this.btnOrderDelete.Visible = false;
                this.btnSave.Visible = false;
            }
            else if (CConstant.PRODUCT_VALIDATION.Equals(CTag))
            {
                this.Text = "订单详细";
                initData();
                setStatus(false);
                this.btnAttached.Visible = false;
                this.btnOrderDelete.Visible = false;
                this.btnSave.Visible = false;
            }
            else if (CConstant.ORDER_QOUTATION.Equals(CTag))
            {
                this.Text = "订单输入";
                initSlipNumber();
                initQuotation();
                setStatus(true);
                this.btnOrderDelete.Visible = false;
                this.btnAttached.Location = new Point(btnAttached.Location.X + 95, btnAttached.Location.Y);
                dgvData.Rows.Add(1);
            }
        }

        private void initHistoryData()
        {
            BllHistoryOrderHeaderTable headerTable = bOrderHeader.GetHistoryModel(_oldSlipNumber);
            this.txtSlipNumber.Text = headerTable.SLIP_NUMBER;
            this.txtCustomerCode.Text = headerTable.ENDER_CUSTOMER_CODE;
            this.txtCustomerName.Text = headerTable.ENDER_CUSTOMER_NAME;

            this.txtSlipDate.Text = string.Format("{0:d}", headerTable.SLIP_DATE);
            this.txtDepartualDate.Text = string.Format("{0:d}", headerTable.DEPARTUAL_DATE);
            //foreach (DataRow dr in CCacheData.Taxation.Rows)
            //{
            //    if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(headerTable.TAX_RATE) * 100)
            //    {
            //        this.cboTax.SelectedValue = dr["CODE"];
            //        break;
            //    }
            //}
            this.txtMemo.Text = headerTable.MEMO;

            this.txtTotal.Text = string.Format("{0:N2}", headerTable.AMOUNT_INCLUDED_TAX);
            //this.txtAmountWithoutTax.Text = string.Format("{0:N2}", headerTable.AMOUNT_WITHOUT_TAX);
            //this.txtTaxAmount.Text = string.Format("{0:N2}", headerTable.TAX_AMOUNT);
            attachedNumber = CConvert.ToInt32(headerTable.ATTACHED_FLAG);
            this.txtdiscountrate.Text = headerTable.DISCOUNT_RATE.ToString();
            this.txtDeliveryTerms.Text = headerTable.DELIVERY_TERMS;
            this.txtPaymentTerms.Text = headerTable.PAYMENT_TERMS;
            this.txtver.Text = headerTable.VER;
            this.cboCurrency.SelectedValue = headerTable.CURRENCY_CODE;
            this.txtcustomerponumber.Text = headerTable.CUSTOMER_PO_NUMBER;
            this.rtxtMemo.Text = headerTable.TO_CUSTOMER_MEMO;
            foreach (BllHistoryOrderLineTable lineModel in headerTable.Items)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells["No"].Value = lineModel.LINE_NUMBER;
                row.Cells["CODE"].Value = lineModel.PRODUCT_CODE;
                row.Cells["OLD_CODE"].Value = lineModel.PRODUCT_CODE;
                row.Cells["NAME"].Value = lineModel.PRODUCT_NAME;
                row.Cells["SPEC"].Value = lineModel.SPEC;
                row.Cells["QUANTITY"].Value = lineModel.QUANTITY;
                //row.Cells["UNIT_CODE"].Value = lineModel.UNIT_CODE;
                // row.Cells["UNIT_NAME"].Value = lineModel.UNIT_NAME;
                row.Cells["PRICE"].Value = lineModel.PRICE;
                row.Cells["AMOUNT"].Value = lineModel.AMOUNT;
                row.Cells["MEMO"].Value = lineModel.MEMO;
                row.Cells["METERIAL"].Value = lineModel.METERIAL;
                row.Cells["PARTS_CODE"].Value = lineModel.PARTS_CODE;
                row.Cells["DESCRIPTION"].Value = lineModel.DESCRIPTION;
                row.Cells["PRICE_DISCOUNT"].Value = lineModel.PRICE_DISCOUNT;
                //row.Cells["QUANTITY"].Value = CConvert.ToDecimal(lineModel.QUANTITY);
                //row.Cells["PARTS_CODE"].Value = lineModel.PARTS_CODE;
                row.Cells["PARTS_NAME"].Value = lineModel.COMPOSITION_PRODUCTS_NAME;
                row.Cells["DESCRIPTION1"].Value = lineModel.DESCRIPTION1;
            }
            string code = txtCustomerCode.Text.Trim();
            DataSet ds = bCommon.GetModel(code);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtCustomerAdress.Text = dr["ADDRESS_FIRST"].ToString();
            }
        }

        /// <summary>
        /// 订单数据初始化
        /// </summary>
        private void initData()
        {
            BllOrderHeaderTable headerTable = bOrderHeader.GetModel(_oldSlipNumber);
            this.txtSlipNumber.Text = headerTable.SLIP_NUMBER;
            this.txtCustomerCode.Text = headerTable.ENDER_CUSTOMER_CODE;
            this.txtCustomerName.Text = headerTable.ENDER_CUSTOMER_NAME;
            this.txtSlipDate.Text = string.Format("{0:d}", headerTable.SLIP_DATE);
            this.txtDepartualDate.Text = string.Format("{0:d}", headerTable.DEPARTUAL_DATE);
            //foreach (DataRow dr in CCacheData.Taxation.Rows)
            //{
            //    if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(headerTable.TAX_RATE) * 100)
            //    {
            //        this.cboTax.SelectedValue = dr["CODE"];
            //        break;
            //    }
            //}

            this.txtMemo.Text = headerTable.MEMO;

            this.txtTotal.Text = string.Format("{0:N2}", headerTable.AMOUNT_INCLUDED_TAX);
            // this.txtAmountWithoutTax.Text = string.Format("{0:N2}", headerTable.AMOUNT_WITHOUT_TAX);
            // this.txtTaxAmount.Text = string.Format("{0:N2}", headerTable.TAX_AMOUNT);
            attachedNumber = CConvert.ToInt32(headerTable.ATTACHED_FLAG);

            this.txtdiscountrate.Text = headerTable.DISCOUNT_RATE.ToString();
            this.txtDeliveryTerms.Text = headerTable.DELIVERY_TERMS;
            this.txtPaymentTerms.Text = headerTable.PAYMENT_TERMS;
            this.txtver.Text = headerTable.VER;
            this.cboCurrency.SelectedValue = headerTable.CURRENCY_CODE;
            this.txtcustomerponumber.Text = headerTable.CUSTOMER_PO_NUMBER;
            this.rtxtMemo.Text = headerTable.TO_CUSTOMER_MEMO;
            foreach (BllOrderLineTable lineModel in headerTable.Items)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells["No"].Value = lineModel.LINE_NUMBER;
                row.Cells["CODE"].Value = lineModel.PRODUCT_CODE;
                row.Cells["OLD_CODE"].Value = lineModel.PRODUCT_CODE;
                row.Cells["NAME"].Value = lineModel.PRODUCT_NAME;
                row.Cells["SPEC"].Value = lineModel.SPEC;
                //row.Cells["QUANTITY"].Value = CConvert.ToDecimal(lineModel.QUANTITY / headerTable.QUANTITY);
                row.Cells["PRICE"].Value = lineModel.PRICE;
                row.Cells["AMOUNT"].Value = lineModel.AMOUNT;
                row.Cells["MEMO"].Value = lineModel.MEMO;

                row.Cells["METERIAL"].Value = lineModel.METERIAL;
                row.Cells["PARTS_CODE"].Value = lineModel.PARTS_CODE;
                row.Cells["DESCRIPTION"].Value = lineModel.DESCRIPTION;
                row.Cells["PRICE_DISCOUNT"].Value = lineModel.PRICE_DISCOUNT;
                row.Cells["QUANTITY"].Value = CConvert.ToDecimal(lineModel.QUANTITY);
                row.Cells["PARTS_CODE"].Value = lineModel.PARTS_CODE;
                row.Cells["PARTS_NAME"].Value = lineModel.COMPOSITION_PRODUCTS_NAME;
                row.Cells["DESCRIPTION1"].Value = lineModel.DESCRIPTION1;
            }
            string code = txtCustomerCode.Text.Trim();
            DataSet ds = bCommon.GetModel(code);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtCustomerAdress.Text = dr["ADDRESS_FIRST"].ToString();
            }
        }

        /// <summary>
        /// 页面控件初始化
        /// </summary>
        /// <param name="flag"></param>
        private void setStatus(bool flag)
        {

            txtSlipNumber.Enabled = flag;
            this.txtCustomerCode.Enabled = flag;
            this.txtSlipDate.Enabled = flag;
            this.txtDepartualDate.Enabled = flag;
            // this.cboTax.Enabled = flag;
            this.txtMemo.Enabled = flag;
            this.btnCustomer.Enabled = flag;
            this.dgvData.ReadOnly = !flag;
            this.txtdiscountrate.Enabled = flag;
            this.txtver.Enabled = flag;
            this.txtDeliveryTerms.Enabled = flag;
            this.txtPaymentTerms.Enabled = flag;
            this.cboCurrency.Enabled = flag;
            this.btnDeliveryTerms.Enabled = flag;
            this.btnPaymentTerms.Enabled = flag;
            //this.txtCustomerAdress.Enabled = flag;
            this.txtcustomerponumber.Enabled = flag;
            if (!flag)
            {
                foreach (DataGridViewColumn dgvc in dgvData.Columns)
                {
                    dgvc.ReadOnly = true;
                }

                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            //dgvData.Columns[1].Visible = flag;
            //dgvData.Columns[3].Visible = flag;
            //dgvData.Columns[6].Visible = flag;
            //dgvData.Columns[16].Visible = flag;
            dgvData.Columns["checkboxflag"].Visible = flag;
            dgvData.Columns["BTN_CODE"].Visible = flag;
            dgvData.Columns["BTN_PARTS_CODE"].Visible = flag;
            dgvData.Columns["BTN_METERIAL"].Visible = flag;
            dgvData.Columns["BTN_DELETE"].Visible = flag;
        }

        private void initQuotation()
        {
            BllQuotationTable QTTable = bQuotation.GetModel(_oldSlipNumber);
            //this.txtSlipNumber.Text = QTTable.SLIP_NUMBER;
            this.txtCustomerCode.Text = QTTable.CUSTOMER_CODE;
            this.txtCustomerName.Text = QTTable.CUSTOMER_NAME;
            this.txtSlipDate.Text = string.Format("{0:d}", QTTable.SLIP_DATE);
            this.txtDepartualDate.Value = CConvert.ToDateTime(QTTable.SLIP_DATE).AddMonths(1);
            //foreach (DataRow dr in CCacheData.Taxation.Rows)
            //{
            //    if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(QTTable.TAX_RATE) * 100)
            //    {
            //        this.cboTax.SelectedValue = dr["CODE"];
            //        break;
            //    }
            //}
            this.txtMemo.Text = QTTable.MEMO;
            this.txtTotal.Text = string.Format("{0:N2}", QTTable.AMOUNT_INCLUDED_TAX);
            //this.txtAmountWithoutTax.Text = string.Format("{0:N2}", QTTable.AMOUNT_WITHOUT_TAX);
            //this.txtTaxAmount.Text = string.Format("{0:N2}", QTTable.TAX_AMOUNT);

            this.txtdiscountrate.Text = QTTable.DISCOUNT_RATE.ToString();
            this.txtDeliveryTerms.Text = QTTable.DELIVERY_TERMS;
            this.txtPaymentTerms.Text = QTTable.PAYMENT_TERMS;
            this.txtver.Text = QTTable.VER;
            this.cboCurrency.SelectedValue = QTTable.CURRENCY_CODE;
            this.rtxtMemo.Text = QTTable.TO_CUSTOMER_MEMO;
            // this.txtcustomerponumber.Text=QTTable.CUS
            foreach (BllQuotationLineTable lineModel in QTTable.Items)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells["No"].Value = lineModel.LINE_NUMBER;
                row.Cells["CODE"].Value = lineModel.PRODUCT_CODE;
                row.Cells["OLD_CODE"].Value = lineModel.PRODUCT_CODE;
                row.Cells["NAME"].Value = lineModel.PRODUCT_NAME;
                row.Cells["SPEC"].Value = lineModel.SPEC;
                // row.Cells["QUANTITY"].Value = CConvert.ToDecimal(lineModel.QUANTITY / QTTable.QUANTITY);
                row.Cells["PRICE"].Value = lineModel.PRICE;
                row.Cells["AMOUNT"].Value = lineModel.AMOUNT;
                row.Cells["MEMO"].Value = lineModel.MEMO;
                row.Cells["METERIAL"].Value = lineModel.METERIAL;
                row.Cells["PARTS_CODE"].Value = lineModel.PARTS_CODE;
                row.Cells["PARTS_NAME"].Value = lineModel.COMPOSITION_PRODUCTS_NAME;
                row.Cells["DESCRIPTION"].Value = lineModel.DESCRIPTION;
                row.Cells["PRICE_DISCOUNT"].Value = lineModel.PRICE_DISCOUNT;
                row.Cells["QUANTITY"].Value = CConvert.ToDecimal(lineModel.QUANTITY);
                row.Cells["DESCRIPTION1"].Value = lineModel.DESCRIPTION1;
            }
            string code = txtCustomerCode.Text.Trim();
            DataSet ds = bCommon.GetModel(code);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtCustomerAdress.Text = dr["ADDRESS_FIRST"].ToString();
            }
        }

        #region 订单编号的初始化
        /// <summary>
        /// 订单编号的初始化
        /// </summary>
        public void initSlipNumber()
        {
            //订单编号的初始化
            string maxSlipNumber = bOrderHeader.GetMaxSlipNumber();
            int number = CConvert.ToInt32(maxSlipNumber) + 1;
            string slipNumber = DateTime.Now.ToString("yyyyMMdd") + number.ToString().PadLeft(4, '0');
            txtSlipNumber.Text = slipNumber;
        }
        #endregion


        #endregion

        #region 重绘datagridview表头
        /// <summary>
        /// 重绘datagridview表头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {

                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    //
                    row.Cells["No"].Value = e.RowIndex + 1;

                    //按钮图片                    
                    row.Cells["BTN_CODE"].Value = Resources.line_find;
                    row.Cells["BTN_PARTS_CODE"].Value = Resources.line_find;
                    row.Cells["BTN_METERIAL"].Value = Resources.line_find;
                    row.Cells["BTN_DELETE"].Value = Resources.line_delete;
                }
            }

        }
        #endregion

        #region DataGridView 行点击事件
        /// <summary>
        /// 行点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dgvData.Columns["BTN_DELETE"].Index)
                {
                    if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        if (dgvData.Rows.Count != 1)
                        {
                            dgvData.Rows.Remove(dgvData.Rows[e.RowIndex]);
                        }
                        else
                        {
                            dgvData.Rows.Remove(dgvData.Rows[e.RowIndex]);
                            dgvData.Rows.Add(1);
                        }
                        CalculateAmount();
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["BTN_CODE"].Index)
                {
                    FrmMasterSearch frm = new FrmMasterSearch("SLIP_TYPE", "");
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (frm.BaseMasterTable != null)
                        {
                            dgvData.Rows[e.RowIndex].Cells["CODE"].Value = frm.BaseMasterTable.Code;
                            dgvData.Rows[e.RowIndex].Cells["NAME"].Value = frm.BaseMasterTable.Name;
                            dgvData.Rows[e.RowIndex].Cells["METERIAL"].Value = "铸钢（ZG270-500）";

                            dgvData.Rows[e.RowIndex].Cells["SPEC"].Selected = true;
                            NewRow();
                        }
                    }
                    frm.Dispose();
                }
                else if (e.ColumnIndex == dgvData.Columns["BTN_METERIAL"].Index)
                {
                    FrmMasterSearch frm = new FrmMasterSearch("MATERIAL", "");
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (frm.BaseMasterTable != null)
                        {
                            dgvData.Rows[e.RowIndex].Cells["METERIAL"].Value = frm.BaseMasterTable.Name;
                            NewRow();
                        }
                    }
                    frm.Dispose();
                }
                else if (e.ColumnIndex == dgvData.Columns["BTN_PARTS_CODE"].Index)
                {
                    bool b = CConvert.ToBoolean(this.dgvData.Rows[e.RowIndex].Cells["checkboxflag"].Value);
                    if (b)
                    {
                        string str = dgvData.Rows[e.RowIndex].Cells["CODE"].Value.ToString();

                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("SLIP_TYPE_CODE = '{0}'", str);
                        FrmMasterSearch frm = new FrmMasterSearch("SLIP_TYPE_COMPOSITION_PRODUCTS_VIEW", sb.ToString());
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {

                            if (frm.BaseMasterTable != null)
                            {
                                dgvData.Rows[e.RowIndex].Cells["PARTS_CODE"].Value = frm.BaseMasterTable.Code;
                                dgvData.Rows[e.RowIndex].Cells["PARTS_NAME"].Value = frm.BaseMasterTable.Name;

                                if (dgvData.Rows.Count > 1)
                                {
                                    if (dgvData.Rows[e.RowIndex].Cells["PARTS_NAME"].Value.ToString() != "")
                                    {
                                        dgvData.Rows[e.RowIndex].Cells["SPEC"].Value = dgvData.Rows[e.RowIndex - 1].Cells["SPEC"].Value;
                                        dgvData.Rows[e.RowIndex].Cells["DESCRIPTION"].Value = dgvData.Rows[e.RowIndex - 1].Cells["DESCRIPTION"].Value;
                                    }
                                }

                                NewRow();
                            }
                        }
                        frm.Dispose();
                    }
                }
            }
            catch { }

        }
        //添加新行
        private void NewRow()
        {
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (string.IsNullOrEmpty(CConvert.ToString(dgvr.Cells["CODE"].Value)))
                {
                    return;
                }
            }
            dgvData.Rows.Add(1);
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
                if (e.ColumnIndex == dgvData.Columns["CODE"].Index)
                {
                    string code = dr.Cells["CODE"].Value.ToString().Trim();
                    if (code != "")
                    {
                        BaseProductTable productTable = bProduct.GetModel(code);
                        if (productTable != null)
                        {
                            if (!code.Equals(dr.Cells["OLD_CODE"].Value))
                            {
                                dr.Cells["CODE"].Value = productTable.CODE;
                                dr.Cells["OLD_CODE"].Value = productTable.CODE;
                                dr.Cells["NAME"].Value = productTable.NAME;
                                dr.Cells["SPEC"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                if (CConvert.ToInt32(dr.Cells["QUANTITY"].Value) == 0)
                                {
                                    dr.Cells["QUANTITY"].Value = 1;
                                }
                                dr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                dr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                dr.Cells["PRICE"].Value = productTable.SALES_PRICE;
                                dr.Cells["AMOUNT"].Value = productTable.SALES_PRICE;
                                CalculateAmount();
                            }
                        }
                        else
                        {
                            MessageBox.Show("商品不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr.Cells["CODE"].Value = "";
                            dr.Cells["OLD_CODE"].Value = "";
                            dr.Cells["NAME"].Value = "";
                            dr.Cells["SPEC"].Value = "";
                            dr.Cells["QUANTITY"].Value = "0";
                            dr.Cells["UNIT_CODE"].Value = "";
                            dr.Cells["UNIT_NAME"].Value = "";
                            dr.Cells["PRICE"].Value = "0";
                            dr.Cells["AMOUNT"].Value = "0";
                            dr.Cells["CODE"].Selected = true; ;
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
                    dr.Cells["AMOUNT"].Value = CConvert.ToDecimal(quantity) * CConvert.ToDecimal(dr.Cells["PRICE"].Value) - CConvert.ToDecimal(dr.Cells["PRICE_DISCOUNT"].Value);

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
                    dr.Cells["AMOUNT"].Value = CConvert.ToDecimal(price) * CConvert.ToDecimal(dr.Cells["QUANTITY"].Value) - CConvert.ToDecimal(dr.Cells["PRICE_DISCOUNT"].Value);

                    CalculateAmount();
                }
                else if (e.ColumnIndex == dgvData.Columns["PRICE_DISCOUNT"].Index)
                {
                    string PRICE_DISCOUNT = CConvert.ToString(dr.Cells["PRICE_DISCOUNT"].Value);

                    if (PRICE_DISCOUNT == "")
                    {
                        dr.Cells["PRICE_DISCOUNT"].Value = 0;
                    }
                    else
                    {
                        dr.Cells["PRICE_DISCOUNT"].Value = CConvert.ToDecimal(PRICE_DISCOUNT);
                    }
                    dr.Cells["AMOUNT"].Value = CConvert.ToDecimal(dr.Cells["PRICE"].Value) * CConvert.ToDecimal(dr.Cells["QUANTITY"].Value) - CConvert.ToDecimal(dr.Cells["PRICE_DISCOUNT"].Value);

                    CalculateAmount();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("CellValidated error!", ex);
            }
        }

        /// <summary>
        /// 行编辑完成后的验证事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region 总金额计算
        /// <summary>
        /// 总金额计算
        /// </summary>
        private void CalculateAmount()
        {
            decimal IncludedTaxAmount = 0;
            //decimal WithoutTaxAmount = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                //if (decimal.Parse(txtdiscountrate.Text) > 0)
                //{
                //    IncludedTaxAmount += CConvert.ToDecimal(dr.Cells["AMOUNT"].Value) * decimal.Parse(txtdiscountrate.Text) / 100;
                //}
                //else
                //{
                //    IncludedTaxAmount += CConvert.ToDecimal(dr.Cells["AMOUNT"].Value);
                //}
                if (txtdiscountrate.Text.Trim() == "")
                {
                    IncludedTaxAmount += CConvert.ToDecimal(dr.Cells["AMOUNT"].Value);
                }
                else
                {
                    IncludedTaxAmount += CConvert.ToDecimal(dr.Cells["AMOUNT"].Value) * (100 - decimal.Parse(txtdiscountrate.Text)) / 100;
                }
            }
            //decimal taxation = CConvert.ToDecimal(cboTax.Text.Replace("%", ""));
            //WithoutTaxAmount = WithoutAmount(IncludedTaxAmount, taxation / 100);

            txtTotal.Text = string.Format("{0:N2}", Math.Round(IncludedTaxAmount, 2));

            //txtAmountWithoutTax.Text = string.Format("{0:N2}", Math.Round(WithoutTaxAmount, 2));
            //txtTaxAmount.Text = string.Format("{0:N2}", Math.Round(IncludedTaxAmount - WithoutTaxAmount, 2));
        }
        #endregion

        #region 税率的选择变更
        /// <summary>
        /// 税率的选择变更
        /// </summary>
        private void cboTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }
        #endregion



        #region 客户
        /// <summary>
        /// 客户选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtCustomerName.Text = frm.BaseMasterTable.Name;
                }
                string code = txtCustomerCode.Text.Trim();
                DataSet ds = bCommon.GetModel(code);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtCustomerAdress.Text = dr["ADDRESS_FIRST"].ToString();
                }
            }

            frm.Dispose();
        }

        /// <summary>
        /// 客户输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {

            string customerCode = txtCustomerCode.Text.Trim();
            if (customerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", customerCode);
                if (baseMaster != null)
                {
                    txtCustomerCode.Text = baseMaster.Code;
                    txtCustomerName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("客户编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerCode.Text = "";
                    txtCustomerName.Text = "";
                    txtCustomerCode.Focus();
                }
            }
            else
            {
                txtCustomerName.Text = "";
            }
        }
        #endregion



        #region 数据保存
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            BllOrderHeaderTable OHTable = new BllOrderHeaderTable();
            BllOrderLineTable OLTable = null;
            //订单类型
            OHTable.SLIP_TYPE = "";
            //订单编号
            OHTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
            //客户
            OHTable.CUSTOMER_CODE = txtCustomerCode.Text.Trim();
            OHTable.ENDER_CUSTOMER_CODE = txtCustomerCode.Text.Trim();
            OHTable.DELIVERY_POINT_CODE = txtCustomerCode.Text.Trim();
            //出库仓库
            OHTable.DEPARTUAL_WAREHOUSE_CODE = CConstant.DEFAULT_WAREHOUSE_CODE;
            //机器编号
            OHTable.SERIAL_NUMBER = "";
            //预定出库日
            OHTable.DEPARTUAL_DATE = txtDepartualDate.Value;
            //订单日期
            OHTable.SLIP_DATE = txtSlipDate.Value;
            //纳期
            OHTable.DUE_DATE = OHTable.DEPARTUAL_DATE;
            //公司订单编号
            OHTable.OWNER_PO_NUMBER = "";
            //合同编号
            OHTable.CUSTOMER_PO_NUMBER = txtcustomerponumber.Text.Trim();
            //通货
            //OHTable.CURRENCY_CODE = CConstant.DEFAULT_CURRENCY_CODE;
            OHTable.CURRENCY_CODE = cboCurrency.SelectedValue.ToString();
            //下单时的预付款
            OHTable.ORDER_DEPOSIT = CConvert.ToDecimal(0);
            //下单时的预付款时间
            OHTable.ORDER_DEPOSIT_DATE = DateTime.Now;
            //出库时的预付款
            OHTable.SHIPMENT_DEPOSIT = CConvert.ToDecimal(0);
            //出库时的预付款时间
            OHTable.ORDER_SHIPMENT_DEPOSIT_DATE = DateTime.Now;
            //备注
            OHTable.MEMO = txtMemo.Text.Trim();
            //状态 OR 出库状况
            OHTable.STATUS_FLAG = CConstant.UN_SHIPMENT;
            //含税金额
            OHTable.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(txtTotal.Text.Trim());
            //税金
            //OHTable.TAX_AMOUNT = CConvert.ToDecimal(txtTaxAmount.Text.Trim());
            //税后金额
            //OHTable.AMOUNT_WITHOUT_TAX = CConvert.ToDecimal(txtAmountWithoutTax.Text.Trim());
            //销售人员
            OHTable.SALES_EMPLOYEE_CODE = UserTable.CODE;
            //创建人           
            OHTable.CREATE_USER = UserTable.CODE;
            //最后更新人
            OHTable.LAST_UPDATE_USER = UserTable.CODE;
            //公司编号
            OHTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            //承认状态
            OHTable.VERIFY_FLAG = CConstant.UN_VERIFY;
            //税率
            // OHTable.TAX_RATE = CConvert.ToDecimal(cboTax.Text.Replace("%", "")) / 100;
            //引当区分
            OHTable.ALLOATION_FLAG = CConstant.ALLOATION_UN;
            //更新回数
            OHTable.UPDATED_COUNT = 0;
            //添付资料
            if (attachedNumber > 0)
            {
                OHTable.ATTACHED_FLAG = CConstant.EXIST_ATTACHED;
            }
            else
            {
                OHTable.ATTACHED_FLAG = CConstant.NO_ATTACHED;
            }
            //检查编号
            OHTable.CHECK_NUMBER = "";
            //检查时间
            OHTable.CHECK_DATE = DateTime.Now;
            //报价单号
            OHTable.QUOTES_NUMBER = "";

            OHTable.PRODUCE_FLAG = CConstant.PRODUCE_DEFAULT;

            OHTable.QUANTITY = CConvert.ToDecimal(0);

            OHTable.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(txtTotal.Text.Trim()); //CConvert.ToDecimal(txtTotal.Text.Trim()) / 100 * CConvert.ToDecimal(txtdiscountrate.Text.Trim());
            OHTable.DELIVERY_TERMS = txtDeliveryTerms.Text.Trim();
            OHTable.PAYMENT_TERMS = txtPaymentTerms.Text.Trim();
            OHTable.VER = txtver.Text.Trim();
            OHTable.DISCOUNT_RATE = CConvert.ToDecimal(txtdiscountrate.Text.Trim());
            OHTable.TO_CUSTOMER_MEMO = rtxtMemo.Text;

            //明细的整理
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Index + 1 == dgvData.Rows.Count)
                {
                    break;
                }
                OLTable = new BllOrderLineTable();
                OLTable.SLIP_NUMBER = OHTable.SLIP_NUMBER;
                //明细编号
                OLTable.LINE_NUMBER = row.Index + 1;
                //商品编号
                OLTable.PRODUCT_CODE = CConvert.ToString(row.Cells["CODE"].Value);
                // 数量
                OLTable.QUANTITY = CConvert.ToDecimal(CConvert.ToDecimal(row.Cells["QUANTITY"].Value.ToString()));
                //单位编号
                OLTable.UNIT_CODE = "0";
                //单价
                OLTable.PRICE = CConvert.ToDecimal(row.Cells["PRICE"].Value);
                //金额
                OLTable.AMOUNT = CConvert.ToDecimal(row.Cells["AMOUNT"].Value);
                //货币编号
                OLTable.CURRENCY_CODE = CConstant.DEFAULT_CURRENCY_CODE;
                //备注
                OLTable.MEMO = CConvert.ToString(row.Cells["MEMO"].Value);
                //明细状态
                OLTable.STATUS_FLAG = CConstant.INIT;
                OLTable.METERIAL = CConvert.ToString(row.Cells["METERIAL"].Value);
                OLTable.PARTS_CODE = CConvert.ToString(row.Cells["PARTS_CODE"].Value);
                OLTable.SPEC = CConvert.ToString(row.Cells["SPEC"].Value);
                OLTable.DESCRIPTION = CConvert.ToString(row.Cells["DESCRIPTION"].Value);
                OLTable.DESCRIPTION1 = CConvert.ToString(row.Cells["DESCRIPTION1"].Value);
                OLTable.PRICE_DISCOUNT = CConvert.ToDecimal(row.Cells["PRICE_DISCOUNT"].Value);
                OLTable.DESCRIPTION1 = CConvert.ToString(row.Cells["DESCRIPTION1"].Value);
                if (CConstant.ORDER_NEW.Equals(CTag) || CConstant.ORDER_COPY.Equals(CTag))　// 订单输入
                {
                    OLTable.SHIPMENT_QUANTITY = 0;
                    OLTable.ALLOATION_QUANTITY = 0;
                }
                //
                if (OLTable.PRODUCT_CODE != "")
                {
                    OHTable.AddItem(OLTable);
                }
            }

            int result = 0;
            if (CConstant.ORDER_NEW.Equals(CTag) || CConstant.ORDER_COPY.Equals(CTag) || CConstant.ORDER_QOUTATION.Equals(CTag))　// 订单输入
            {
                if (CConvert.ToDecimal(txtTotal.Text) == 0)
                {
                    if (MessageBox.Show("【警告】含税金额为0；", "订单保存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    {
                        return;
                    }
                }

                try
                {
                    string slipNumber = bOrderHeader.Add(OHTable);
                    if (slipNumber == null)
                    {
                        MessageBox.Show("订单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\order", "FTP_user", "czzd", 21);
                        myftp.MkDir(slipNumber);
                        Czzd.Common.Library.FTPOperate myftp1 = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\order\\" + slipNumber, "FTP_user", "czzd", 21);
                        if (Directory.Exists(_attachedDirectory + _tmpAttachedDirectoryName))
                        {
                            DirectoryInfo di = new DirectoryInfo(_attachedDirectory + _tmpAttachedDirectoryName);
                            FileInfo[] files = di.GetFiles();

                            foreach (FileInfo file in files)
                            {
                                myftp1.Put("\\YY模具\\bin\\order\\" + _tmpAttachedDirectoryName + "\\" + file);
                            }

                            if (di.Exists)
                            {
                                DirectoryInfo[] childs = di.GetDirectories();
                                foreach (DirectoryInfo child in childs)
                                {
                                    child.Delete(true);
                                }
                                di.Delete(true);
                            }
                        }

                        MessageBox.Show("订单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (CConstant.ORDER_COPY.Equals(CTag) || CConstant.ORDER_QOUTATION.Equals(CTag))
                        {
                            _dialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            initPage();
                        }
                        if (Directory.Exists(_attachedDirectory + _tmpAttachedDirectoryName))
                        {
                            DirectoryInfo di = new DirectoryInfo(_attachedDirectory + _tmpAttachedDirectoryName);
                            di.MoveTo(_attachedDirectory + slipNumber);
                        }
                        _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    }
                }

                catch (IOException iex)
                {
                    _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    Logger.Error("附件上传失败。", iex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("订单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("新建订单保存失败。", ex);
                }
            }
            else if (CConstant.ORDER_MODIFY.Equals(CTag)) //订单修正
            {
                BllOrderHeaderTable oldOHTable = bOrderHeader.GetModel(_oldSlipNumber);
                //承认状态
                OHTable.VERIFY_FLAG = oldOHTable.VERIFY_FLAG;
                //引当区分
                OHTable.ALLOATION_FLAG = oldOHTable.ALLOATION_FLAG;
                //更新回数
                OHTable.UPDATED_COUNT = oldOHTable.UPDATED_COUNT + 1;
                //下单时的预付款时间
                OHTable.ORDER_DEPOSIT_DATE = DateTime.Now;
                //出库时的预付款时间
                OHTable.ORDER_SHIPMENT_DEPOSIT_DATE = DateTime.Now;
                OLTable.SHIPMENT_QUANTITY = 0;
                OLTable.ALLOATION_QUANTITY = 0;
                try
                {
                    result = bOrderHeader.Update(OHTable);
                    if (result <= 0)
                    {
                        MessageBox.Show("订单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("订单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();
                        _dialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("订单保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("订单修改保存失败。", ex);
                }
            }
            else if (CConstant.ORDER_VERIFY.Equals(CTag))   //订单审核
            {
                try
                {
                    //预付金额
                    decimal depositAmount = (new BDepositArr()).GetArrAmount(_oldSlipNumber);

                    if (OHTable.ORDER_DEPOSIT / 100 > depositAmount / OHTable.AMOUNT_INCLUDED_TAX)
                    {
                        MessageBox.Show("销售时预付款金额未支付或支付不足。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (!bOrderHeader.UpdateVerify(_oldSlipNumber, CConstant.VERIFY))
                    {
                        MessageBox.Show("订单通知失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("订单通知成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();
                        _dialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("订单通知失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("订单审核失败。", ex);
                }
            }

        }
        #endregion

        #region 订单取消
        /// <summary>
        /// 订单取消
        /// </summary>
        private void btnOrderDelete_Click(object sender, EventArgs e)
        {
            if (_oldSlipNumber != "")
            {
                if (CConstant.ORDER_MODIFY.Equals(CTag)) //订单修正
                {
                    if (DialogResult.Yes == MessageBox.Show("确定要删除吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        try
                        {
                            if (!bOrderHeader.Delete(_oldSlipNumber))
                            {
                                MessageBox.Show("订单取消失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                initPage();
                                _dialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("订单取消失败！请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logger.Error("订单取消失败。", ex);
                        }
                    }
                }
                else if (CConstant.ORDER_VERIFY.Equals(CTag))   //订单承认
                {
                    try
                    {
                        if (!bOrderHeader.UpdateVerify(_oldSlipNumber, CConstant.NO_VERIFY))
                        {
                            MessageBox.Show("订单审核失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("订单审核保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            initPage();
                            _dialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("订单审核保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("订单审核保存失败。", ex);
                    }

                    return;

                }
            }
        }
        #endregion

        #region 数据保存前的验证
        /// <summary>
        /// 数据保存前主表数据验证
        /// </summary>
        private bool CheckHeaderInput()
        {
            string message = "";
            if (string.IsNullOrEmpty(this.txtCustomerCode.Text))
            {
                message += "客户编号不能为空。\r\n";
            }
            if (message.Length > 0)
            {
                MessageBox.Show(message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 数据保存前明细数据验证
        /// </summary>
        private bool CheckLineInput()
        {
            int count = dgvData.Rows.Count;
            int i = 1;
            if (dgvData.Rows.Count == 0)
            {
                MessageBox.Show("明细数不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (count > i)
                {
                    if (CConvert.ToString(row.Cells["CODE"].Value) == "")
                    {
                        MessageBox.Show("商品名称不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (CConvert.ToString(row.Cells["QUANTITY"].Value) == "")
                    {
                        MessageBox.Show("销售数量不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (CConvert.ToDecimal(row.Cells["QUANTITY"].Value) == 0)
                    {
                        MessageBox.Show("销售数量不能为零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (CConvert.ToString(row.Cells["PRICE"].Value) == "")
                    {
                        MessageBox.Show("销售单价不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    //else if (CConvert.ToString(row.Cells["PARTS_CODE"].Value) == "")
                    //{
                    //    MessageBox.Show("部件编号不能为空", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return false;
                    //}
                }
                i++;

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
            this.txtCustomerCode.Text = "";
            this.txtCustomerName.Text = "";
            this.txtSlipDate.Value = DateTime.Now;
            this.txtDepartualDate.Value = DateTime.Now;
            //this.cboTax.SelectedIndex = 0;
            this.txtMemo.Text = "";
            this.txtTotal.Text = CConvert.ToString(0.0);
            //this.txtAmountWithoutTax.Text = CConvert.ToString(0.0);
            //this.txtTaxAmount.Text = CConvert.ToString(0.0);
            this.cboCurrency.SelectedIndex = 0;
            this.txtver.Text = "";
            this.txtdiscountrate.Text = "";
            this.txtDeliveryTerms.Text = "";
            this.txtPaymentTerms.Text = "";
            this.txtMemo.Text = "";
            this.txtPaymentTerms.Text = "";
            this.txtCustomerAdress.Text = "";
            this.txtcustomerponumber.Text = "";
            this.rtxtMemo.Text = "";
            initSlipNumber();
            this.dgvData.Rows.Clear();
            dgvData.Rows.Add(1);
        }

        #endregion

        #region 页面关闭
        /// <summary>
        /// 页面关闭
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 页面关闭后的返回值
        /// </summary>
        private void FrmOrdersEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _dialogResult;
        }
        #endregion


        #region 附件添加
        /// <summary>
        /// 附件的添加
        /// </summary>
        private void btnAttached_Click(object sender, EventArgs e)
        {
            FrmAttached frm = new FrmAttached();
            if (CConstant.ORDER_NEW.Equals(CTag) || CConstant.ORDER_COPY.Equals(CTag))
            {
                frm = new FrmAttached(_tmpAttachedDirectoryName, _attachedDirectory);
            }
            else
            {
                frm = new FrmAttached(_oldSlipNumber, _attachedDirectory);
                frm.CTag = CConstant.ORDER_MODIFY; ;
            }

            if (frm != null)
            {
                frm.ShowDialog(this);
                attachedNumber = frm.AttachedNumber;
                frm.Dispose();
            }
        }
        #endregion

        #region 输入控制
        /// <summary>
        /// 文本框输入控制
        /// </summary>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputInteger(sender, e);
        }

        bool HasAttachEvent = false;

        /// <summary>
        /// DataGridView输入控制
        /// </summary>
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
                    else if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "PRICE_DISCOUNT")
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


        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputInteger(sender, e);
        }
        #region mouse event
        #region  dgvData Mouse event
        /// <summary>
        /// 
        /// </summary>
        private void dgvData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if ("BTN_CODE".Equals(dgvData.Columns[e.ColumnIndex].Name))
                {
                    dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Resources.line_find_over;
                }
                else if ("BTN_PARTS_CODE".Equals(dgvData.Columns[e.ColumnIndex].Name))
                {
                    dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Resources.line_find_over;
                }
                else if ("BTN_DELETE".Equals(dgvData.Columns[e.ColumnIndex].Name))
                {
                    dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Resources.line_delete_over;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void dgvData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if ("BTN_CODE".Equals(dgvData.Columns[e.ColumnIndex].Name))
                {
                    dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Resources.line_find;
                }
                else if ("BTN_PARTS_CODE".Equals(dgvData.Columns[e.ColumnIndex].Name))
                {
                    dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Resources.line_find;
                }
                else if ("BTN_DELETE".Equals(dgvData.Columns[e.ColumnIndex].Name))
                {
                    dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Resources.line_delete;
                }
            }
        }
        #endregion

        #region  btnSave Mouse event
        /// <summary>
        /// 
        /// </summary>
        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.save_over);
        }
        /// <summary>
        /// 
        /// </summary>
        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.save);
        }
        #endregion

        #region btnFind Mouse event
        /// <summary>
        /// 
        /// </summary>
        //private void btnFind_MouseEnter(object sender, EventArgs e)
        //{
        //    SetBackgroundImage(sender, Resources.find_over);
        //}
        /// <summary>
        /// 
        /// </summary>

        #endregion
        #endregion

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtdiscountrate.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }

            }

            if (txtdiscountrate.Focused)
            {
                if (e.KeyChar == 46)
                {
                    if (((TextBox)sender).SelectionStart == 0)
                    {
                        e.Handled = true;
                    }
                    else if (((TextBox)sender).Text.IndexOf('.') >= 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 46) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26)
                {
                    e.Handled = true;
                }
                else　 //以下为输入正确内容过虑
                {
                    string[] str = ((TextBox)sender).Text.Split('.');
                    if (str.Length > 1)
                    {
                        if (str[1].Length >= 2 && ((TextBox)sender).SelectionStart > ((TextBox)sender).Text.IndexOf('.'))
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtdiscountrate.Focused)
                {

                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtdiscountrate.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }
        private void btnSaveNames_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox txt = (TextBox)btn.Parent.Controls.Find("txt" + CConvert.ToString(btn.Tag), true)[0];
            if (!bCommon.ExistsBaseNames(CConvert.ToString(btn.Tag), txt.Text.Trim()))
            {
                bCommon.SaveBaseNmaes(CConvert.ToString(btn.Tag), txt.Text.Trim());
                CCacheData.BaseNames = null;
            }
        }

        private void txtdiscountrate_Leave(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void cboTax_SelectedValueChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

    }//end class
}
