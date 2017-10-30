using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.CacheData;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using System.IO;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmQuotation : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private string _oldSlipNumber = "";
        private DialogResult _dialogResult = DialogResult.Cancel;

        private string _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
        private string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_QUOTATION);
        private int attachedNumber = 0;
        public FrmQuotation()
        {
            InitializeComponent();
        }

        public FrmQuotation(string slipnumber)
        {
            InitializeComponent();
            _oldSlipNumber = slipnumber;
        }

        private void FrmQuotation_Load(object sender, EventArgs e)
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

            #endregion

            #region 货币的初始化
            //货币的初始化  
            DataTable dtCurrency = CCacheData.Currency.Copy();
            cboCurrency.ValueMember = "CODE";
            cboCurrency.DisplayMember = "NAME";
            cboCurrency.DataSource = dtCurrency;
            #endregion

            txtver.Text = "1";


            if (string.IsNullOrEmpty(_oldSlipNumber))
            {
                init();
                dgvData.Rows.Add(1);

            }
            else if (CConstant.QUOTATION_OPERATE.Equals(CTag))
            {
                initData();
                this.btnOrderDelete.Visible = false;
                setStatus(false);


            }
            else if (CConstant.QUOTATION_MODIFY.Equals(CTag))
            {
                initData();
                dgvData.Rows.Add(1);
            }


            else if (CConstant.ORDER_HISTORY.Equals(CTag))
            {
                initHistoryData();
                this.btnSave.Visible = false;
                this.btnOrderDelete.Visible = false;
                this.btnAttached.Visible = false;
                checkboxflag.Selected = true;

                setStatus(false);
            }

            #region 自动提示文本输入框
            AutoCompleteStringCollection strings = new AutoCompleteStringCollection();
            strings.AddRange(CCacheData.GetBaseNamesData("EnquiryMethod"));
            txtEnquiryMethod.AutoCompleteCustomSource = strings;
            txtEnquiryMethod.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtEnquiryMethod.AutoCompleteMode = AutoCompleteMode.Suggest;

            strings = new AutoCompleteStringCollection();
            strings.AddRange(CCacheData.GetBaseNamesData("DeliveryPeriod"));
            txtDeliveryPeriod.AutoCompleteCustomSource = strings;
            txtDeliveryPeriod.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDeliveryPeriod.AutoCompleteMode = AutoCompleteMode.Suggest;

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

        #region 初始化
        private void init()
        {
            initSlipNumber();
            setStatus(true);
            this.btnOrderDelete.Visible = false;
        }

        private void setStatus(bool flag)
        {
            this.txtSlipNumber.Enabled = flag;
            this.txtCustomerCode.Enabled = flag;
            this.txtSlipDate.Enabled = flag;
            this.txtPaymentTerms.Enabled = flag;
            this.cboCurrency.Enabled = flag;
            //this.cboTax.Enabled = flag;
            this.txtMemo.Enabled = flag;
            this.btnCustomer.Enabled = flag;
            this.dgvData.ReadOnly = !flag;
            this.btnSave.Enabled = flag;
            this.btnAttached.Enabled = flag;
            this.txtCustomerName.Enabled = flag;
            this.txtver.Enabled = flag;
            this.txtdiscountrate.Enabled = flag;
            this.txtdiscountrate.Enabled = flag;
            this.txtEnquiryMethod.Enabled = flag; ;
            this.txtEnquiryDate.Enabled = flag;
            this.txtDeliveryPeriod.Enabled = flag; ;
            this.txtDeliveryTerms.Enabled = flag; ;
            this.txtPaymentTerms.Enabled = flag;
            this.txtPaymentTerms.Enabled = flag;
            this.btnDeliveryTerms.Enabled = flag;
            this.btnDeliveryPeriod.Enabled = flag;
            this.btnEnquiryMethod.Enabled = flag;
            this.btnPaymentTerms.Enabled = flag;
            this.rtxtMemo.Enabled = flag;

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

        /// <summary>
        /// 报价单数据初始化
        /// </summary>
        private void initData()
        {
            BllQuotationTable QTTable = bQuotation.GetModel(_oldSlipNumber);

            this.txtSlipNumber.Text = QTTable.SLIP_NUMBER;
            this.txtCustomerCode.Text = QTTable.CUSTOMER_CODE;
            this.txtCustomerName.Text = QTTable.CUSTOMER_NAME;
            this.txtSlipDate.Text = string.Format("{0:d}", QTTable.SLIP_DATE);
            //foreach (DataRow dr in CCacheData.Taxation.Rows)
            //{
            //    if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(QTTable.TAX_RATE) * 100)
            //    {
            //        this.cboTax.SelectedValue = dr["CODE"];
            //        break;
            //    }
            //}
            this.txtdiscountrate.Text = QTTable.DISCOUNT_RATE.ToString();
            this.txtEnquiryMethod.Text = QTTable.ENQUIRY_METHOD;
            this.txtEnquiryDate.Text = QTTable.ENQUIRY_DATE.ToString();
            this.txtDeliveryPeriod.Text = QTTable.DELIVERY_PERIOD;
            this.txtDeliveryTerms.Text = QTTable.DELIVERY_TERMS;
            this.txtPaymentTerms.Text = QTTable.PAYMENT_TERMS;
            this.txtver.Text = QTTable.VER;
            this.cboCurrency.SelectedValue = QTTable.CURRENCY_CODE;
            this.txtPaymentTerms.Text = QTTable.PAYMENT_TERMS;
            this.txtMemo.Text = QTTable.MEMO;
            //this.txtAmountIncludedTax.Text = string.Format("{0:N2}", QTTable.AMOUNT_INCLUDED_TAX);
            this.txtTotal.Text = string.Format("{0:N2}", QTTable.AMOUNT_INCLUDED_TAX);
            //this.txtTaxAmount.Text = string.Format("{0:N2}", QTTable.TAX_AMOUNT);
            this.rtxtMemo.Text = QTTable.TO_CUSTOMER_MEMO;
            foreach (BllQuotationLineTable lineModel in QTTable.Items)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells["CODE"].Value = lineModel.PRODUCT_CODE;
                row.Cells["NAME"].Value = lineModel.PRODUCT_NAME;
                row.Cells["DESCRIPTION"].Value = lineModel.DESCRIPTION;
                row.Cells["PRICE_DISCOUNT"].Value = lineModel.PRICE_DISCOUNT;
                row.Cells["QUANTITY"].Value = lineModel.QUANTITY;
                row.Cells["SPEC"].Value = lineModel.SPEC;
                row.Cells["PRICE"].Value = lineModel.PRICE;
                row.Cells["AMOUNT"].Value = lineModel.AMOUNT;
                row.Cells["MEMO"].Value = lineModel.MEMO;
                row.Cells["METERIAL"].Value = lineModel.METERIAL;
                row.Cells["COMPOSITION_PRODUCTS_CODE"].Value = lineModel.PARTS_CODE;
                row.Cells["COMPOSITION_PRODUCTS_NAME"].Value = lineModel.COMPOSITION_PRODUCTS_NAME;
                row.Cells["DESCRIPTION1"].Value = lineModel.DESCRIPTION1;
                // bool b = CConvert.ToBoolean(row.Cells["COMPOSITION_PRODUCTS_CODE"].Value);
                if (lineModel.PARTS_CODE != "")
                {
                    row.Cells["checkboxflag"].Value = true;
                }
                else
                {
                    row.Cells["checkboxflag"].Value = false;
                }
            }
        }
        #endregion

        private void initHistoryData()
        {
            BllQuotationTable QTTable = bQuotation.GetHistoryModel(_oldSlipNumber);
            this.txtSlipNumber.Text = QTTable.SLIP_NUMBER;
            this.txtCustomerCode.Text = QTTable.CUSTOMER_CODE;
            this.txtCustomerName.Text = QTTable.CUSTOMER_NAME;
            this.txtSlipDate.Text = string.Format("{0:d}", QTTable.SLIP_DATE);
            //foreach (DataRow dr in CCacheData.Taxation.Rows)
            //{
            //    if (CConvert.ToDecimal(dr["TAX_RATE"]) == CConvert.ToDecimal(QTTable.TAX_RATE) * 100)
            //    {
            //        this.cboTax.SelectedValue = dr["CODE"];
            //        break;
            //    }
            //}
            this.txtdiscountrate.Text = QTTable.DISCOUNT_RATE.ToString();
            this.txtEnquiryMethod.Text = QTTable.ENQUIRY_METHOD;
            this.txtEnquiryDate.Text = QTTable.ENQUIRY_DATE.ToString();
            this.txtDeliveryPeriod.Text = QTTable.DELIVERY_PERIOD;
            this.txtDeliveryTerms.Text = QTTable.DELIVERY_TERMS;
            this.txtPaymentTerms.Text = QTTable.PAYMENT_TERMS;
            this.txtver.Text = QTTable.VER;
            this.txtPaymentTerms.Text = QTTable.PAYMENT_TERMS;
            this.txtMemo.Text = QTTable.MEMO;
            this.cboCurrency.SelectedValue = QTTable.CURRENCY_CODE;
            //this.txtAmountIncludedTax.Text = string.Format("{0:N2}", QTTable.AMOUNT_INCLUDED_TAX);
            this.txtTotal.Text = string.Format("{0:N2}", QTTable.AMOUNT_INCLUDED_TAX);
            //this.txtTaxAmount.Text = string.Format("{0:N2}", QTTable.TAX_AMOUNT);
            this.rtxtMemo.Text = QTTable.TO_CUSTOMER_MEMO;
            foreach (BllQuotationLineTable lineModel in QTTable.Items)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells["CODE"].Value = lineModel.PRODUCT_CODE;
                row.Cells["DESCRIPTION"].Value = lineModel.DESCRIPTION;
                row.Cells["PRICE_DISCOUNT"].Value = lineModel.PRICE_DISCOUNT;
                row.Cells["QUANTITY"].Value = lineModel.QUANTITY;
                row.Cells["SPEC"].Value = lineModel.SPEC;
                row.Cells["PRICE"].Value = lineModel.PRICE;
                row.Cells["AMOUNT"].Value = lineModel.AMOUNT;
                row.Cells["MEMO"].Value = lineModel.MEMO;
                row.Cells["METERIAL"].Value = lineModel.METERIAL;
                row.Cells["NAME"].Value = lineModel.PRODUCT_NAME;
                row.Cells["COMPOSITION_PRODUCTS_CODE"].Value = lineModel.PARTS_CODE;
                row.Cells["COMPOSITION_PRODUCTS_NAME"].Value = lineModel.COMPOSITION_PRODUCTS_NAME;
                row.Cells["DESCRIPTION1"].Value = lineModel.DESCRIPTION1;
            }

        }

        #region 报价单编号的初始化
        private void initSlipNumber()
        {
            //报价单编号的初始化
            string maxSlipNumber = bQuotation.GetMaxSlipNumber();
            int number = CConvert.ToInt32(maxSlipNumber) + 1;
            string slipNumber = DateTime.Now.ToString("yyyyMMdd") + number.ToString().PadLeft(4, '0');
            txtSlipNumber.Text = slipNumber;
        }
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
                        BaseMaster bm = bCommon.GetBaseMaster("SLIP_TYPE", code);
                        if (bm != null)
                        {
                            if (!code.Equals(dr.Cells["OLD_CODE"].Value))
                            {
                                dr.Cells["CODE"].Value = bm.Code;
                                dr.Cells["NAME"].Value = bm.Name;
                                dr.Cells["OLD_CODE"].Value = bm.Code;
                                dr.Cells["SPEC"].Selected = true;
                                CalculateAmount();
                                NewRow();
                            }
                        }
                        else
                        {
                            MessageBox.Show("种类不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr.Cells["CODE"].Value = "";
                            dr.Cells["NAME"].Value = "";
                            dr.Cells["OLD_CODE"].Value = "";
                            dr.Cells["CODE"].Selected = true;
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
            //txtAmountIncludedTax.Text = string.Format("{0:N2}", Math.Round(IncludedTaxAmount, 2));
            //txtTotal.Text = string.Format("{0:N2}", Math.Round(WithoutTaxAmount, 2));
            txtTotal.Text = string.Format("{0:N2}", Math.Round(IncludedTaxAmount, 2));
            // txtTaxAmount.Text = string.Format("{0:N2}", Math.Round(IncludedTaxAmount - WithoutTaxAmount, 2));
            //txtAmountWithoutTax.Text = Math.Round(IncludedTaxAmount - taxAmount, 2).ToString();
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

            string endCustomerCode = txtCustomerCode.Text.Trim();
            if (endCustomerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", endCustomerCode);
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
                    else if (CConvert.ToString(row.Cells["COMPOSITION_PRODUCTS_CODE"].Value) != "" && row.Cells["checkboxflag"].Value.Equals(false))
                    {
                        MessageBox.Show("部件编号不能为空", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                i++;

            }

            return true;
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

            BllQuotationTable QTTable = new BllQuotationTable();
            BllQuotationLineTable QLTable = null;
            //报价单类型
            QTTable.SLIP_TYPE = "";
            //报价单编号
            QTTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
            //客户
            QTTable.CUSTOMER_CODE = txtCustomerCode.Text.Trim();
            QTTable.DISCOUNT_RATE = CConvert.ToDecimal(txtdiscountrate.Text.Trim());
            QTTable.ENQUIRY_METHOD = txtEnquiryMethod.Text.Trim();
            QTTable.ENQUIRY_DATE = CConvert.ToDateTime(txtEnquiryDate.Text.Trim());
            QTTable.DELIVERY_PERIOD = txtDeliveryPeriod.Text.Trim();
            QTTable.DELIVERY_TERMS = txtDeliveryTerms.Text.Trim();
            QTTable.PAYMENT_TERMS = txtPaymentTerms.Text.Trim();
            if ((txtver.Text.Trim()).Equals(""))
            {
                QTTable.VER = "1";
            }
            else
            {
                QTTable.VER = txtver.Text.Trim();
            }
            QTTable.UPDATE_COUNT = 0;
            //出库仓库
            //QTTable.DEPARTUAL_WAREHOUSE_CODE = CConstant.DEFAULT_WAREHOUSE_CODE;
            //报价单日期
            QTTable.SLIP_DATE = txtSlipDate.Value;
            //货币
            QTTable.CURRENCY_CODE = cboCurrency.SelectedValue.ToString();
            //QTTable.CURRENCY_CODE = CConstant.DEFAULT_CURRENCY_CODE;
            //备注
            QTTable.MEMO = txtMemo.Text.Trim();
            //状态 OR 出库状况
            QTTable.STATUS_FLAG = CConstant.UN_SHIPMENT;
            //含税金额
            QTTable.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(txtTotal.Text.Trim());
            //税金
            //QTTable.TAX_AMOUNT = CConvert.ToDecimal(txtTaxAmount.Text.Trim());
            //税后金额
            //QTTable.DISCOUNT_AMOUNT = CConvert.ToDecimal(txtTotal.Text.Trim());
            //销售人员
            QTTable.SALES_EMPLOYEE_CODE = UserTable.CODE;
            //创建人           
            QTTable.CREATE_USER = UserTable.CODE;
            //最后更新人
            QTTable.LAST_UPDATE_USER = UserTable.CODE;
            //公司编号
            QTTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            //税率
            //QTTable.TAX_RATE = CConvert.ToDecimal(cboTax.Text.Replace("%", "")) / 100;
            QTTable.QUANTITY = 1;


           // QTTable.ORDER_FLAG = 0;
            if (attachedNumber > 0)
            {
                QTTable.ORDER_FLAG = CConstant.EXIST_ATTACHED;
            }
            else
            {
                QTTable.ORDER_FLAG = CConstant.NO_ATTACHED;
            }

            QTTable.PAYMENT_CONDITION = txtPaymentTerms.Text;
            // QTTable.DISCOUNT_AMOUNT = CConvert.ToDecimal(txtAmountIncludedTax.Text.Trim()) / 100 * (100 - CConvert.ToDecimal(txtdiscountrate.Text.Trim()));
            //客户备注
            QTTable.TO_CUSTOMER_MEMO = rtxtMemo.Text;

            //明细的整理
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Index + 1 == dgvData.Rows.Count)
                {
                    break;
                }
                QLTable = new BllQuotationLineTable();
                QLTable.SLIP_NUMBER = QTTable.SLIP_NUMBER;
                //明细编号
                QLTable.LINE_NUMBER = row.Index + 1;
                //商品编号
                QLTable.PRODUCT_CODE = CConvert.ToString(row.Cells["CODE"].Value);

                QLTable.DESCRIPTION = CConvert.ToString(row.Cells["DESCRIPTION"].Value);
                QLTable.DESCRIPTION1 = CConvert.ToString(row.Cells["DESCRIPTION1"].Value);
                QLTable.SPEC = CConvert.ToString(row.Cells["SPEC"].Value);
                QLTable.PRICE_DISCOUNT = CConvert.ToDecimal(row.Cells["PRICE_DISCOUNT"].Value); ;

                // 数量
                QLTable.QUANTITY = CConvert.ToDecimal(QTTable.QUANTITY * CConvert.ToDecimal(row.Cells["QUANTITY"].Value.ToString()));
                //单位编号
                QLTable.UNIT_CODE = "01";
                //单价
                QLTable.PRICE = CConvert.ToDecimal(row.Cells["PRICE"].Value);
                //金额
                QLTable.AMOUNT = CConvert.ToDecimal(row.Cells["AMOUNT"].Value);
                //货币编号
                //QLTable.CURRENCY_CODE = CConstant.DEFAULT_CURRENCY_CODE;
                //备注
                QLTable.MEMO = CConvert.ToString(row.Cells["MEMO"].Value);
                //明细状态
                QLTable.STATUS_FLAG = CConstant.INIT;
                QLTable.METERIAL = CConvert.ToString(row.Cells["METERIAL"].Value);
                QLTable.PARTS_CODE = CConvert.ToString(row.Cells["COMPOSITION_PRODUCTS_CODE"].Value);

                if (QLTable.PRODUCT_CODE != "")
                {
                    QTTable.AddItem(QLTable);
                }
            }

            int result = 0;

            //if (CConvert.ToDecimal(txtAmountIncludedTax.Text) == 0)
            //{
            //    if (MessageBox.Show("【警告】含税金额为0；", "报价单保存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
            //    {
            //        return;
            //    }
            //}
            if (String.IsNullOrEmpty(_oldSlipNumber))
            {

                try
                {
                    string slipNumber = bQuotation.Add(QTTable);
                    if (slipNumber == null)
                    {
                        MessageBox.Show("报价单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\quotation", "FTP_user", "czzd", 21);
                        myftp.MkDir(slipNumber);
                        Czzd.Common.Library.FTPOperate myftp1 = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\quotation\\" + slipNumber, "FTP_user", "czzd", 21);
                        if (Directory.Exists(_attachedDirectory + _tmpAttachedDirectoryName))
                        {
                            DirectoryInfo di = new DirectoryInfo(_attachedDirectory + _tmpAttachedDirectoryName);
                            FileInfo[] files = di.GetFiles();

                            foreach (FileInfo file in files)
                            {
                                myftp1.Put("\\YY模具\\bin\\quotation\\" + _tmpAttachedDirectoryName + "\\" + file);
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

                        MessageBox.Show("报价单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("报价单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("新建报价单保存失败。", ex);
                }
            }
            else if (CConstant.QUOTATION_MODIFY.Equals(CTag)) //报价单修正
            {
                BllQuotationTable oldQLTable = bQuotation.GetModel(_oldSlipNumber);

                QTTable.UPDATE_COUNT = oldQLTable.UPDATE_COUNT + 1;              
                try
                {
                    result = bQuotation.Update(QTTable);
                    if (result <= 0)
                    {
                        MessageBox.Show("报价单保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("报价单保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();
                        _dialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报价单保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("报价单修改保存失败。", ex);
                }
            }
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
            //this.cboTax.SelectedIndex = 0;
            this.cboCurrency.SelectedIndex = 0;
            this.txtver.Text = "";
            this.txtdiscountrate.Text = "";
            this.txtdiscountrate.Text = "";
            this.txtEnquiryMethod.Text = "";
            this.txtEnquiryDate.Text = "";
            this.txtDeliveryPeriod.Text = "";
            this.txtDeliveryTerms.Text = "";
            this.txtPaymentTerms.Text = "";
            this.txtMemo.Text = "";
            this.txtPaymentTerms.Text = "";
            this.rtxtMemo.Text = "";
            //this.txtAmountIncludedTax.Text = CConvert.ToString(0.0);
            this.txtTotal.Text = CConvert.ToString(0.0);
            //this.txtTaxAmount.Text = CConvert.ToString(0.0);
            initSlipNumber();
            this.dgvData.Rows.Clear();
            txtver.Text = "1";
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
        private void FrmQuotation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = _dialogResult;
        }
        #endregion

        #region 输入控制

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
                        InputnegativeInteger(o, c);
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

        #region 报价单取消
        private void btnOrderDelete_Click(object sender, EventArgs e)
        {
            if (_oldSlipNumber != "")
            {
                if (CConstant.QUOTATION_MODIFY.Equals(CTag)) //报价单修正
                {
                    if (DialogResult.Yes == MessageBox.Show("确定要删除吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        try
                        {
                            if (!bQuotation.Delete(_oldSlipNumber))
                            {
                                MessageBox.Show("报价单取消失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("报价单取消失败！请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Logger.Error("报价单取消失败。", ex);
                        }
                    }
                }
            }
        }
        #endregion

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
                            //dgvData.Rows[e.RowIndex].Cells["CODE"].Value = frm.BaseMasterTable.Code;
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
                                dgvData.Rows[e.RowIndex].Cells["COMPOSITION_PRODUCTS_CODE"].Value = frm.BaseMasterTable.Code;
                                dgvData.Rows[e.RowIndex].Cells["COMPOSITION_PRODUCTS_NAME"].Value = frm.BaseMasterTable.Name;

                                if (dgvData.Rows.Count > 1)
                                {
                                    if (dgvData.Rows[e.RowIndex].Cells["COMPOSITION_PRODUCTS_NAME"].Value.ToString() != "")
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void btnAttached_Click(object sender, EventArgs e)
        {
            FrmAttachedQuatation frm =new FrmAttachedQuatation ();           
            if (string.IsNullOrEmpty(_oldSlipNumber))
            {
                frm = new FrmAttachedQuatation(_tmpAttachedDirectoryName, _attachedDirectory);               
            }
            else
            {
                //FrmBase frm1 = new FrmAttachedQuatation();
                
                frm = new FrmAttachedQuatation(_oldSlipNumber, _attachedDirectory);
                frm.CTag = CConstant.QUOTATION_MODIFY;  
            }

            if (frm != null)
            {
                frm.ShowDialog(this);
                attachedNumber = frm.AttachedNumber;
                frm.Dispose();
            }
        }
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
        private void btnFind_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }
        /// <summary>
        /// 
        /// </summary>
        private void btnFind_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }
        #endregion

        private void txtDiscountRate_Leave(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void cboCurrency_SelectedValueChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void btnCustomer_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnCustomer_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        #region
        private void dgvData_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvData_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

    }//end class
}
