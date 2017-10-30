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
using System.Text.RegularExpressions;

namespace CZZD.ERP.WinUI
{
    public partial class FrmSales : FrmBase
    {
        protected BSales bSales = new BSales();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private string _slipNumber;

        public string SLIP_NUMBER
        {
            set { _slipNumber = value; }
            get { return _slipNumber; }
        }

        public FrmSales()
        {
            InitializeComponent();
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            if (!string.IsNullOrEmpty(_slipNumber))
            {
                OperateInit();
                setStatus(false);
                btnSearch.Visible = false;
                btnSave.Visible = false;
                btnOperate.Enabled = true;
                btnOperate.Left = btnSave.Left;
                dgvData.Columns["ALL"].Visible = false;
                this.Text = "销售发票详细";
            }
            else
            {
                this.dgvData.AutoGenerateColumns = false;
                this.dgvData.AllowUserToAddRows = false;
                this.dgvData.AllowUserToDeleteRows = false;
                PageSize = 16;
                dgvData.Rows.Add(PageSize);
            }
        }

        #region 明细确认
        private void OperateInit()
        {
            try
            {
                BllSalesTable sales = bSales.GetModel(_slipNumber);
                if (sales != null)
                {
                    txtInvoiceNo.Text = sales.INVOICE_NUMBER;
                    txtInvoiceAmount.Text = CConvert.ToString(sales.INVOICE_AMOUNT);
                    txtCustomerClaimDate.Value = sales.CUSTOMER_CLAIM_DATE;
                    txtCustomerCode.Text = sales.CUSTOMER_CLAIM_CODE;
                    txtCustomerName.Text = sales.CUSTOMER_CLAIM_NAME;
                    txtSalesDate.Value = sales.SLIP_DATE;

                    int i = 1;
                    dgvData.ReadOnly = true;
                    dgvData.Rows.Clear();
                    dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    foreach (BllSalesLineTable line in sales.Items)
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                        dgvr.Cells["No"].Value = i++;
                        dgvr.Cells["CUSTOMER_NAME"].Value = sales.CUSTOMER_CLAIM_NAME;
                        dgvr.Cells["ORDER_NUMBER"].Value = line.ORDER_SLIP_NUMBER;
                        dgvr.Cells["ORDER_AMOUNT"].Value = line.ORDER_AMOUNT;
                        dgvr.Cells["SHIPMENT_NUMBER"].Value = line.SHIPMENT_SLIP_NUMBER;
                        dgvr.Cells["SERIAL_NUMBER"].Value = line.SERIAL_NUMBER;
                        dgvr.Cells["SHIPMENT_AMOUNT"].Value = line.SHIPMENT_AMOUNT;
                        dgvr.Cells["CURRENCY_NAME"].Value = line.CURRENCY_NAME;
                        dgvr.Cells["AMOUNT"].Value = line.INVOICE_AMOUNT;
                        decimal InAmount = bSales.GetInvoiceAmount(line.SHIPMENT_SLIP_NUMBER);
                        dgvr.Cells["UN_INVOICE_AMOUNT"].Value = line.SHIPMENT_AMOUNT - InAmount;

                        dgvr.Cells["AMOUNT"].Style.BackColor = System.Drawing.SystemColors.Info;
                    }                    
                }
            }
            catch (Exception ex)
            {
                Logger.Error("销售发票详细页面加载失败：", ex);
                MessageBox.Show("销售发票详细页面加载失败，请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void setStatus(bool flag)
        {
            txtInvoiceNo.Enabled = flag;
            txtInvoiceAmount.Enabled = flag;
            txtCustomerClaimDate.Enabled = flag;
            txtCustomerCode.Enabled = flag;
            btnCustomer.Enabled = flag;
            txtSalesDate.Enabled = flag;
            txtOrderNumber.Enabled = flag;
            txtContractNumber.Enabled = flag;
            txtShipmentDateFrom.Enabled = flag;
            txtShipmentDateTo.Enabled = flag;
            btnOperate.Enabled = flag;
            btnSearch.Enabled = flag;
            btnSave.Enabled = flag;
            dgvData.Columns["AMOUNT"].ReadOnly = !flag;
        }
        #endregion

        #region 客户
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", " CLAIM_FLAG=1");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtCustomerName.Text = frm.BaseMasterTable.Name;
                    txtSalesDate.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            string customerCode = txtCustomerCode.Text.Trim();
            if (customerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", customerCode, " CLAIM_FLAG = 1");
                if (baseMaster != null)
                {
                    txtCustomerCode.Text = baseMaster.Code;
                    txtCustomerName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("请款公司不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnCustomer_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnCustomer_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定关闭吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
            }
        }
        #endregion

        #region 查询按钮
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string where = GetCondition();
            string orderby = " ORDER BY CUSTOMER_CLAIM_CODE,ORDER_SLIP_NUMBER,SLIP_NUMBER ";
            DataTable dt = bSales.GetSalesEntryDataList(where + orderby).Tables[0];

            //初期化
            this.dgvData.Rows.Clear();

            if (dt.Rows.Count > 0)
            {
                int i = 1;
                string currentCustomerClaimCode = "";

                foreach (DataRow dr in dt.Rows)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                    dgvr.Cells["NO"].Value = i++;
                    string customerClaimCode = CConvert.ToString(dr["CUSTOMER_CLAIM_CODE"]);
                    dgvr.Cells["CUSTOMER_CLAIM_CODE"].Value = dr["CUSTOMER_CLAIM_CODE"];
                    if (currentCustomerClaimCode == "" || currentCustomerClaimCode != customerClaimCode)
                    {
                        //客户
                        currentCustomerClaimCode = customerClaimCode;
                        dgvr.Cells["CUSTOMER_NAME"].Value = dr["CUSTOMER_CLAIM_NAME"];
                    }

                    //订单编号
                    dgvr.Cells["ORDER_NUMBER"].Value = dr["ORDER_SLIP_NUMBER"];
                    //机械番号
                    dgvr.Cells["SERIAL_NUMBER"].Value = dr["SERIAL_NUMBER"];
                    //订单金额
                    dgvr.Cells["ORDER_AMOUNT"].Value = dr["ORDER_AMOUNT"];
                    //出库编号
                    dgvr.Cells["SHIPMENT_NUMBER"].Value = dr["SLIP_NUMBER"];
                    //出库金额
                    dgvr.Cells["SHIPMENT_AMOUNT"].Value = dr["SHIPMENT_AMOUNT"];
                    //货币
                    dgvr.Cells["CURRENCY_CODE"].Value = dr["CURRENCY_CODE"];
                    dgvr.Cells["CURRENCY_NAME"].Value = dr["CURRENCY_NAME"];
                    //未开票金额
                    dgvr.Cells["UN_INVOICE_AMOUNT"].Value = dr["UN_INVOICE_AMOUNT"];
                    //开票金额


                    dgvr.Cells["AMOUNT"].ReadOnly = false;
                    dgvr.Cells["AMOUNT"].Style.BackColor = System.Drawing.SystemColors.Info;
                    dgvr.Cells["AMOUNT"].Style.SelectionForeColor = System.Drawing.SystemColors.ControlText;
                    dgvr.Cells["AMOUNT"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;

                    dgvr.Cells["ALL"].Value = "ALL";
                    dgvr.Cells["ALL"].Style.BackColor = System.Drawing.SystemColors.Info;
                    dgvr.Cells["ALL"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;


                }
            }
            else
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            for (int i = dt.Rows.Count; i < PageSize; i++)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                dgvr.Cells["AMOUNT"].ReadOnly = true;
            }
        }
        #endregion


        #region 查询条件
        private string GetCondition()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0} ", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtOrderNumber.Text.Trim()))
            {
                sb.AppendFormat(" and ORDER_SLIP_NUMBER like '{0}%' ", txtOrderNumber.Text);
            }
            if (!string.IsNullOrEmpty(txtContractNumber.Text.Trim()))
            {
                sb.AppendFormat(" and CUSTOMER_PO_NUMBER like '{0}%' ", txtContractNumber.Text);
            }
            if (txtShipmentDateFrom.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE >= '{0}' ", txtShipmentDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (txtShipmentDateTo.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE < '{0}' ", txtShipmentDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            if (!string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" and customer_claim_code = '{0}' ", txtCustomerCode.Text);
            }
            return sb.ToString();
        }
        #endregion

        #region 画面保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Incheck() && AmountCheck())
            {
                List<BllSalesTable> datas = new List<BllSalesTable>();
                BllSalesTable salesTable = new BllSalesTable();
                DateTime currentDate = DateTime.Now;

                //表头信息的保存
                //发票号码
                salesTable.INVOICE_NUMBER = this.txtInvoiceNo.Text.Trim();
                //开票日期
                salesTable.SLIP_DATE = this.txtSalesDate.Value;
                //收款预定日
                salesTable.CUSTOMER_CLAIM_DATE = this.txtCustomerClaimDate.Value;
                //发票金额
                salesTable.INVOICE_AMOUNT = CConvert.ToDecimal(this.txtInvoiceAmount.Text.Trim());
                //状态
                salesTable.STATUS_FLAG = CConstant.INIT;
                //创建人           
                salesTable.CREATE_USER = UserTable.CODE;
                //创建时间
                salesTable.CREATE_DATE_TIME = currentDate;
                //最后更新人
                salesTable.LAST_UPDATE_USER = UserTable.CODE;
                //最后更新时间
                salesTable.LAST_UPDATE_TIME = currentDate;
                // 公司 
                salesTable.COMPANY_CODE = UserTable.COMPANY_CODE;

                //明细信息保存
                int lineNumber = 1;
                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    decimal amount = CConvert.ToDecimal(CConvert.ToString(dgvr.Cells["AMOUNT"].Value));
                    if (amount == 0)
                    {
                        continue;
                    }

                    //请款公司编号
                    salesTable.CUSTOMER_CLAIM_CODE = CConvert.ToString(dgvr.Cells["CUSTOMER_CLAIM_CODE"].Value);

                    BllSalesLineTable salesLineTable = new BllSalesLineTable();
                    //发票内部编号
                    salesLineTable.SLIP_NUMBER = salesTable.SLIP_NUMBER;
                    //明细编号
                    salesLineTable.LINE_NUMBER = lineNumber++;
                    //订单编号
                    salesLineTable.ORDER_SLIP_NUMBER = CConvert.ToString(dgvr.Cells["ORDER_NUMBER"].Value);
                    //出库编号
                    salesLineTable.SHIPMENT_SLIP_NUMBER = CConvert.ToString(dgvr.Cells["SHIPMENT_NUMBER"].Value);
                    //开票金额
                    salesLineTable.INVOICE_AMOUNT = amount;
                    //货币编号 
                    salesLineTable.CURRENCY_CODE = CConvert.ToString(dgvr.Cells["CURRENCY_CODE"].Value);
                    //状态
                    salesLineTable.STATUS_FLAG = CConstant.INIT;
                    //存入表头
                    salesTable.Items.Add(salesLineTable);
                }
                if (salesTable.Items.Count == 0)
                {
                    MessageBox.Show("请输入出库明细的发票金额。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                int result = 0;
                try
                {
                    result = bSales.Add(salesTable);
                    if (result <= 0)
                    {
                        MessageBox.Show("销售发票保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("销售发票保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        initPage();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("销售发票保存失败,系统错误,请与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("销售发票保存失败!!!!!", ex);
                }
            }
        }
        #endregion

        #region 数据保存前验证
        public bool Incheck()
        {
            string strErrorlog = null;
            //发票的编号不能为空
            if (string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                strErrorlog += "发票的编号不能为空!\r\n";
            }
            //发票合计金额不能为空
            if (string.IsNullOrEmpty(txtInvoiceAmount.Text.Trim()))
            {
                strErrorlog += "发票合计金额不能为空!\r\n";
            }
            ////请款公司编号不能为空
            //if (string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            //{
            //    strErrorlog += "请款公司编号不能为空!\r\n";
            //}

            if (!string.IsNullOrEmpty(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public bool AmountCheck()
        {
            decimal sum = 0;
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                sum += CConvert.ToDecimal(dgvr.Cells["AMOUNT"].Value);
            }
            if (sum != CConvert.ToDecimal(txtInvoiceAmount.Text.Trim()))
            {
                MessageBox.Show("发票合计总额要与开票金额的总数相等!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //客户
            this.txtCustomerCode.Text = "";
            this.txtCustomerName.Text = "";
            //订单编号
            this.txtOrderNumber.Text = "";
            //合同编号
            this.txtContractNumber.Text = "";
            //出库日
            this.txtShipmentDateFrom.Value = DateTime.Now;
            this.txtShipmentDateFrom.Checked = false;
            this.txtShipmentDateTo.Value = DateTime.Now;
            this.txtShipmentDateTo.Checked = false;
            //销售日期
            this.txtSalesDate.Value = DateTime.Now;
            //收款预定日
            this.txtCustomerClaimDate.Value = DateTime.Now;
            //发票
            this.txtInvoiceNo.Text = "";
            //发票合计金额
            this.txtInvoiceAmount.Text = "";
            this.dgvData.Rows.Clear();
        }

        #endregion

        #region 输入数字
        bool HasAttachEvent = false;
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl control = (DataGridViewTextBoxEditingControl)e.Control;

            if (!this.HasAttachEvent) // 注册事件
            {
                control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "AMOUNT")
                    {
                        InputAmount(o, c);
                    }
                    else
                    {
                        return;
                    }
                });

                this.HasAttachEvent = true;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtSalesDate.Focused)
                {
                    txtOrderNumber.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }
            if (txtInvoiceAmount.Focused)
            {
                InputInteger(sender, e);
            }

            //if (txtInvoiceNo.Focused || txtCustomerCode.Focused || txtOrderNumber.Focused || txtContractNumber.Focused)
            //{
            //    if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            //    {
            //        e.Handled = true;
            //    }
            //}
        }
        #endregion

        #region 明细确认
        /// <summary>
        /// 明细确认
        /// </summary>
        private void btnOperate_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                try
                {
                    string shipmentnumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SHIPMENT_NUMBER"].Value);
                    FrmShipmentSearch frm = new FrmShipmentSearch();
                    frm.SHIPMENT_SLIP_NUMBER = shipmentnumber;
                    frm.ShowDialog();
                    frm.Dispose();
                }
                catch (Exception ex)
                {
                    Logger.Error("明细确认:", ex);
                }
            }
            else
            {
                MessageBox.Show("请先选择一行", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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
                DataGridViewRow dgvr = dgvData.Rows[e.Row.Index];
                if (dgvr.Cells["NO"].Value == null || "".Equals(dgvr.Cells["NO"].Value.ToString()))
                {
                    dgvr.Selected = false;
                }
            }
        }
        #endregion

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvData.Columns["ALL"].Index)
                {
                    DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                    dgvr.Cells["AMOUNT"].Value = dgvr.Cells["UN_INVOICE_AMOUNT"].Value;
                }
            }
            catch (Exception ex)
            {

            }
        }

    }//end class
}
