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

namespace CZZD.ERP.WinUI
{
    public partial class FrmSalesSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        protected BSales bSales = new BSales();
        private bool isSearch = false;

        public FrmSalesSearch()
        {
            InitializeComponent();
        }

        private void FrmSalesSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            initDgvData();
        }

        #region 初始化
        /// <summary>
        /// dgvData 初始化
        /// </summary>
        private void initDgvData()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            PageSize = 14;
            dgvData.Rows.Add(PageSize);
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
                }
            }
            frm.Dispose();
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            string customerCode = txtCustomerCode.Text.Trim();
            if (customerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", customerCode, " CLAIM_FLAG=1");
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

        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bSales.GetSalesRecordCount(GetCondition());
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);

            //数据绑定
            BindData(currentPage);
            isSearch = true;
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = GetCondition();
            DataSet ds = bSales.GetSalesList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            //reSetCurrentDt();
            //this.dgvData.DataSource = _currentDt;
            string currentInvoiceNumber = "";
            dgvData.Rows.Clear();
            foreach (DataRow dr in _currentDt.Rows)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells["Row"].Value = dr["Row"];
                string invoiceNumber = CConvert.ToString(dr["INVOICE_NUMBER"]);
                if (currentInvoiceNumber == "" || currentInvoiceNumber != invoiceNumber)
                {
                    currentInvoiceNumber = invoiceNumber;
                    row.Cells["INVOICE_NUMBER"].Value = invoiceNumber;
                    row.Cells["CUSTOMER_CLAIM_NAME"].Value = dr["CUSTOMER_CLAIM_NAME"];
                    row.Cells["INVOICE_AMOUNT"].Value = dr["INVOICE_AMOUNT"];
                    row.Cells["SLIP_DATE"].Value = CConvert.DateTimeToString(dr["SLIP_DATE"], "yyyy-MM-dd");
                }
                row.Cells["CURRENCY_NAME"].Value = dr["CURRENCY_NAME"];
                row.Cells["UN_RECEIPT_AMOUNT"].Value = dr["UN_RECEIPT_AMOUNT"];
                row.Cells["CUSTOMER_CLAIM_DATE"].Value = CConvert.DateTimeToString(dr["CUSTOMER_CLAIM_DATE"], "yyyy-MM-dd");
                row.Cells["PAYMENT_STATUS_NAME_C"].Value = dr["PAYMENT_STATUS_NAME"];
                row.Cells["ORDER_SLIP_NUMBER"].Value = dr["ORDER_SLIP_NUMBER"];
                row.Cells["ORDER_AMOUNT"].Value = dr["ORDER_AMOUNT"];
                row.Cells["LINE_INVOICE_AMOUNT"].Value = dr["LINE_INVOICE_AMOUNT"];
                row.Cells["SHIPMENT_SLIP_NUMBER"].Value = dr["SHIPMENT_SLIP_NUMBER"];
                row.Cells["SHIPMENT_AMOUNT"].Value = dr["SHIPMENT_AMOUNT"];
                row.Cells["SLIP_NUMBER"].Value = dr["SLIP_NUMBER"];
                row.Cells["PAYMENT_STATUS_C"].Value = dr["PAYMENT_STATUS"];
            }
            if (_currentDt.Rows.Count < PageSize)
            {
                dgvData.Rows.Add(PageSize - _currentDt.Rows.Count);
            }
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }
        #endregion

        #region 当前数据集的重新整理(暂不需要)
        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        //private void reSetCurrentDt()
        //{
        //    //for (int i = 0; i < _currentDt.Rows.Count; i++)
        //    //{
        //    //    _currentDt.Rows[i]["NO"] = i + 1;
        //    //}

        //    for (int i = _currentDt.Rows.Count; i < PageSize; i++)
        //    {
        //        _currentDt.Rows.Add(_currentDt.NewRow());
        //    }
        //}
        #endregion

        #region 查询条件整理
        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetCondition()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                sb.AppendFormat(" and INVOICE_NUMBER like '{0}%'", txtInvoiceNo.Text);
            }
            if (!string.IsNullOrEmpty(txtOrderNumber.Text.Trim()))
            {
                sb.AppendFormat(" and ORDER_SLIP_NUMBER like '{0}%'", txtOrderNumber.Text);
            }
            if (!string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" and CUSTOMER_CLAIM_CODE = '{0}'", txtCustomerCode.Text);
            }
            if (SalesDateFrom.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE >= '{0}'", SalesDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (SalesDateTo.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE < '{0}'", SalesDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            if (DueSalesDateFrom.Checked)
            {
                sb.AppendFormat(" and CUSTOMER_CLAIM_DATE >= '{0}'", DueSalesDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (DueSalesDateTo.Checked)
            {
                sb.AppendFormat(" and CUSTOMER_CLAIM_DATE < '{0}'", DueSalesDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            if (FullPayment.Checked)
            {

            }
            else if (NoPaid.Checked)
            {
                sb.AppendFormat(" and PAYMENT_STATUS = {0}", 1);
            }
            else if (NoPayment.Checked)
            {
                sb.AppendFormat(" and PAYMENT_STATUS <> {0}", 1);
            }
            return sb.ToString();
        }
        #endregion

        #region 空行不能被点击
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

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int recordCount = bSales.GetSalesRecordCount(GetCondition());
            _currentDt = bSales.GetSalesList(GetCondition(), "", 1, recordCount).Tables[0];
            if (isSearch && _currentDt != null)
            {
                string SALES_HEADER = "发票系统编号,发票编号,请款公司编号,请款公司名称,开票日期,收款预定日,发票金额,未收款金额," +
                                "收款状态,订单单号,订单金额,出库单号,出库金额,明细开票金额,通货";
                string SALES_COLUMNS = "SLIP_NUMBER,INVOICE_NUMBER,CUSTOMER_CLAIM_CODE,CUSTOMER_CLAIM_NAME,SLIP_DATE,CUSTOMER_CLAIM_DATE,INVOICE_AMOUNT,UN_RECEIPT_AMOUNT," +
                                 "PAYMENT_STATUS_NAME,ORDER_SLIP_NUMBER,ORDER_AMOUNT,SHIPMENT_SLIP_NUMBER,SHIPMENT_AMOUNT,INVOICE_AMOUNT,CURRENCY_NAME";
                int result = CExport.DataTableToExcel(_currentDt, SALES_HEADER, SALES_COLUMNS, "sheet1", "SALES");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("导出成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region 销售发票取消
        /// <summary>
        /// 销售发票取消
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要取消吗?", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    if (isSearch && dgvData.SelectedRows[0].Cells["PAYMENT_STATUS_C"].Value != null)
                    {
                        string slipnumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);
                        int paymentStatus = CConvert.ToInt32(dgvData.SelectedRows[0].Cells["PAYMENT_STATUS_C"].Value);
                        if (paymentStatus == 0 && !string.IsNullOrEmpty(slipnumber))
                        {
                            if (bSales.DeleteSales(slipnumber))
                            {
                                MessageBox.Show("取消成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                BindData(this.pgControl.GetCurrentPage());
                            }
                            else
                            {
                                MessageBox.Show("取消失败!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("该订单已收款或部分收款，不能取消!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                { }
            }
        }
        #endregion

        #region 详细确认
        /// <summary>
        /// 详细确认
        /// </summary>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.SelectedRows.Count > 0)
                {
                    string slipNumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);
                    if (!string.IsNullOrEmpty(slipNumber))
                    {
                        FrmSales frm = new FrmSales();
                        frm.SLIP_NUMBER = slipNumber;
                        frm.ShowDialog();
                        frm.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("请先选择正确的行!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            { }
        }
        #endregion

    }//end class
}
