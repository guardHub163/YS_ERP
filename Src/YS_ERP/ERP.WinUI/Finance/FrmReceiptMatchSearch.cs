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
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmReceiptMatchSearch : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        protected BSales bSales = new BSales();
        private bool isSearch = false;

        public FrmReceiptMatchSearch()
        {
            InitializeComponent();
        }

        private void FrmReceiptMatchSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.CTag = CTag;

            init();
        }

        #region dgvData初始化
        public void init()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
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

        private void txtCustomerCode_Leave(object sender, EventArgs e)
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
                    MessageBox.Show("请款公司不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int currentPage = 1;
            int recordCount = bSales.GetReceiptMatchSearchRecordCount(GetCondition());
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
            DataSet ds = bSales.GetReceiptMatchSearchList(strWhere, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
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
            if (!string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" and CUSTOMER_CLAIM_CODE = '{0}'", txtCustomerCode.Text);
            }
            if (txtPaymentDateFrom.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE >= '{0}'", txtPaymentDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (txtPaymentDateTo.Checked)
            {
                sb.AppendFormat(" and SLIP_DATE < '{0}'", txtPaymentDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
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

        #region 当前数据集的重新整理(暂不需要)
        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            //for (int i = 0; i < _currentDt.Rows.Count; i++)
            //{
            //    _currentDt.Rows[i]["NO"] = i + 1;
            //}

            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }
        }
        #endregion

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int recordCount = bSales.GetReceiptMatchSearchRecordCount(GetCondition());
            _currentDt = bSales.GetReceiptMatchSearchList(GetCondition(), "", 1, recordCount).Tables[0];
            if (isSearch && _currentDt.Rows.Count > 0)
            {
                string RECEIPT_MATCH_HEADER = "收款编号,请款公司编号,请款公司名称,收款日期,发票编号,发票金额,预收款金额,收款金额,通货";
                string RECEIPT_MATCH_COLUMNS = "SLIP_NUMBER,CUSTOMER_CLAIM_CODE, CUSTOMER_CLAIM_NAME,SLIP_DATE, INVOICE_NUMBER, INVOICE_AMOUNT,DEPOSIT_AMOUNT,TOTAL_AMOUNT,CURRENCY_NAME";

                int result = CExport.DataTableToExcel(_currentDt, RECEIPT_MATCH_HEADER, RECEIPT_MATCH_COLUMNS, "sheet1", "RECEIPT_MATCH");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("导出成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string slipnumber = CConvert.ToString(dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value);
                if (!string.IsNullOrEmpty(slipnumber))
                {
                    if (bSales.DeleteReceiptMatch(slipnumber))
                    {
                        MessageBox.Show("取消成功!");
                        BindData(this.pgControl.GetCurrentPage());
                    }
                    else
                    {
                        MessageBox.Show("取消失败!");
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}
