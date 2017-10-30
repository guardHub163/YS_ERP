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
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmPurchaseSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        protected BPurchase bPurchase = new BPurchase();
        private bool isSearch = false;

        public FrmPurchaseSearch()
        {
            InitializeComponent();
        }

        private void FrmPurchaseSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region dgvData 初始化
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
            #endregion
        }

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
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (SupplierCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("出库仓库不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region 查询按钮
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bPurchase.GetPurchaseRecordCount(GetCondition());
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
            DataSet ds = bPurchase.GetPurchaseList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
            //string currentInvoiceNumber = "";
            //dgvData.Rows.Clear();
            //foreach (DataRow dr in _currentDt.Rows)
            //{
            //    int currentRowIndex = dgvData.Rows.Add(1);
            //    DataGridViewRow row = dgvData.Rows[currentRowIndex];
            //    row.Cells["Row"].Value = dr["Row"];
            //    string invoiceNumber = CConvert.ToString(dr["INVOICE_NUMBER"]);
            //    if (currentInvoiceNumber == "" || currentInvoiceNumber != invoiceNumber)
            //    {
            //        currentInvoiceNumber = invoiceNumber;
            //        row.Cells["INVOICE_NUMBER"].Value = invoiceNumber;
            //        row.Cells["CUSTOMER_CLAIM_NAME"].Value = dr["CUSTOMER_CLAIM_NAME"];
            //        row.Cells["INVOICE_AMOUNT"].Value = dr["INVOICE_AMOUNT"];
            //        row.Cells["SLIP_DATE"].Value = CConvert.DateTimeToString(dr["SLIP_DATE"], "yyyy-MM-dd");
            //        row.Cells["CURRENCY_NAME"].Value = dr["CURRENCY_NAME"];
            //        row.Cells["UN_RECEIPT_AMOUNT"].Value = dr["UN_RECEIPT_AMOUNT"];
            //        row.Cells["CUSTOMER_CLAIM_DATE"].Value = CConvert.DateTimeToString(dr["CUSTOMER_CLAIM_DATE"], "yyyy-MM-dd");
            //        row.Cells["payment_status_name"].Value = dr["payment_status_name"];
            //    }
            //    row.Cells["ORDER_NUMBER"].Value = dr["ORDER_NUMBER"];
            //    row.Cells["ORDER_AMOUNT"].Value = dr["ORDER_AMOUNT"];
            //    row.Cells["LINE_INVOICE_AMOUNT"].Value = dr["LINE_INVOICE_AMOUNT"];
            //    row.Cells["SHIPMENT_NUMBER"].Value = dr["SHIPMENT_NUMBER"];
            //    row.Cells["SHIPMENT_AMOUNT"].Value = dr["SHIPMENT_AMOUNT"];
            //    row.Cells["SLIP_NUMBER"].Value = dr["SLIP_NUMBER"];
            //}
            //if (_currentDt.Rows.Count < PageSize)
            //{
            //    dgvData.Rows.Add(PageSize - _currentDt.Rows.Count);
            //}
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }
        #endregion

        #region 查询条件
        private string GetCondition()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                sb.AppendFormat(" and INVOICE_NUMBER like '{0}%'", txtInvoiceNo.Text);
            }
            if (!string.IsNullOrEmpty(txtPurchaseNo.Text.Trim()))
            {
                sb.AppendFormat(" and INVOICE_NUMBER_LOCAL like '{0}%'", txtPurchaseNo.Text);
            }
            if (!string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                sb.AppendFormat(" and SUPPLIER_CODE = '{0}'", txtSupplierCode.Text);
            }
            if (SlipDateFrom.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE >= '{0}'", SlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (SlipDateTo.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE < '{0}'", SlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            if (txtPaymentDateFrom.Checked)
            {
                sb.AppendFormat(" and PAYMENT_DATE >= '{0}'", txtPaymentDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (txtPaymentDateTo.Checked)
            {
                sb.AppendFormat(" and PAYMENT_DATE < '{0}'", txtPaymentDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            if (rbAllInvoice.Checked)
            { }
            else if (rbPaid.Checked)
            {
                sb.AppendFormat(" and payment_status = '{0}'", 1);
            }
            else if (rbNoPaid.Checked)
            {
                sb.AppendFormat(" and payment_status = '{0}'", 0);
            }
            else if (rbSomePaid.Checked)
            {
                sb.AppendFormat(" and payment_status = '{0}'", 2);
            }
            return sb.ToString();
        }
        #endregion

        #region 当前数据集的重新整理(暂不需要)
        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            //    //for (int i = 0; i < _currentDt.Rows.Count; i++)
            //    //{
            //    //    _currentDt.Rows[i]["NO"] = i + 1;
            //    //}

            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }
        }
        #endregion

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int recordCount = bPurchase.GetPurchaseRecordCount(GetCondition());
            _currentDt = bPurchase.GetPurchaseList(GetCondition(), "", 1, recordCount).Tables[0];
            if (isSearch && _currentDt != null)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "LZ_PURCHASE_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                sf.Filter = "(文件)|*.xls;*.xlsx";
                string header = "画面明细编号\t采购内部编号\t供应商编号\t供应商名称\t供应商类型\t供应商类型名称\t供应商类型名称\t国外发票No\t国外发票金额\t国内发票No\t" +
                                "国内发票金额\t付款状态\t付款状态名称\t开票日期\t付款预定日\t通货编号\t通货名称\t状态\t\n";
                if (sf.ShowDialog(this) == DialogResult.OK)
                {
                    _currentDt.Columns.Remove("INVOICE_No");
                    _currentDt.Columns.Remove("INVOICE_NO_AMOUNT");
                    if (_currentDt != null)
                    {
                        int result = CExport.DataTableToCsv(_currentDt, header, sf.FileName);
                        if (result == 0)
                        {
                            MessageBox.Show("导出成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
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

        #region 详细确认
        /// <summary>
        /// 
        /// </summary>
        private void btnOperate_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                string slipnumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);
                if (!string.IsNullOrEmpty(slipnumber))
                {
                    FrmPurchase frm = new FrmPurchase();
                    frm.SLIP = slipnumber;
                    frm.ShowDialog();
                    frm.Dispose();
                }
            }
            else 
            {
                MessageBox.Show("请先选择一行数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion

        #region 发票取消
        /// <summary>
        /// 
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要取消发票吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (isSearch && dgvData.SelectedRows[0].Cells["payment_status"].Value != null)
                    {
                        int payment_status = CConvert.ToInt32(dgvData.SelectedRows[0].Cells["payment_status"].Value);
                        string slipnumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);
                        if (payment_status == 0 && !string.IsNullOrEmpty(slipnumber))
                        {



                            if (bPurchase.DeletePurchase(slipnumber))
                            {
                                MessageBox.Show("取消发票成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindData(this.pgControl.GetCurrentPage());
                            }
                            else
                            {
                                MessageBox.Show("取消发票失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("该订单已付款或部分付款，不能取消发票。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("取消发票：", ex);
                }
            }
        }
        #endregion
    }
}
