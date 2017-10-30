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
    public partial class FrmReceiptMatch : FrmBase
    {
        protected BSales bSales = new BSales();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        public FrmReceiptMatch()
        {
            InitializeComponent();
        }

        private void FrmReceiptMatch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            initDgvData();
            GetDepositUnBillingAmount();
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
            dgvData.Rows.Clear();

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
                    GetDepositUnBillingAmount();
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
                    GetDepositUnBillingAmount();
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
                GetDepositUnBillingAmount();
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

        #region 预收款未开票金额
        /// <summary>
        /// 预收款未开票金额
        /// </summary>
        private void GetDepositUnBillingAmount()
        {
            decimal balance = bSales.GetTotalDepositUnBilling(txtCustomerCode.Text.Trim());
            txtDepositAmount.Text = CConvert.ToString(balance);
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
            string where = GetCondition();
            string orderby = "";

            DataTable dt = bSales.GetReceiptEntryDataList(where + orderby).Tables[0];

            //初期化
            this.dgvData.Rows.Clear();
            this.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
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
                    if (currentCustomerClaimCode == "" || currentCustomerClaimCode != customerClaimCode)
                    {
                        //客户
                        currentCustomerClaimCode = customerClaimCode;
                        dgvr.Cells["CUSTOMER_CLAIM_NAME"].Value = dr["CUSTOMER_CLAIM_NAME"];
                    }
                    //开票日期
                    dgvr.Cells["SALES_SLIP_DATE"].Value = dr["SLIP_DATE"];

                    //发票No.
                    dgvr.Cells["INVOICE_NUMBER"].Value = dr["INVOICE_NUMBER"];

                    //发票金额
                    dgvr.Cells["INVOICE_AMOUNT"].Value = dr["INVOICE_AMOUNT"];

                    //未收余额
                    dgvr.Cells["UN_RECEIPT_AMOUNT"].Value = dr["UN_RECEIPT_AMOUNT"];

                    //收款预定日
                    dgvr.Cells["CUSTOMER_CLAIM_DATE"].Value = dr["CUSTOMER_CLAIM_DATE"];

                    //预付款金额 TODO:
                    dgvr.Cells["DEPOSIT_AMOUNT"].Value = "0";

                    //金额
                    dgvr.Cells["OTHER_AMOUNT"].Value = "0";

                    //销售内部编号
                    dgvr.Cells["SALES_SLIP_NUMBER"].Value = dr["SLIP_NUMBER"];

                    //收款日期
                    dgvr.Cells["SLIP_DATE"].Value = DateTime.Now;
                }
                this.dgvData.Columns["DEPOSIT_AMOUNT"].ReadOnly = false;
                this.dgvData.Columns["OTHER_AMOUNT"].ReadOnly = false;
                this.dgvData.Columns["SLIP_DATE"].ReadOnly = false;
            }
            else
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.dgvData.AlternatingRowsDefaultCellStyle.BackColor = COLOR_DIFF_ROW;
                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvData.Rows.Add(PageSize);
            }
        }

        //绘制单元格时发生事件
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex >= 0 && dgvData.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
            {
                DataGridViewRow dgvr = dgv.Rows[e.RowIndex];
                dgvr.Cells["DEPOSIT_AMOUNT"].Style.BackColor = COLOR_INFO;
                dgvr.Cells["OTHER_AMOUNT"].Style.BackColor = COLOR_INFO;
                dgvr.Cells["SLIP_DATE"].Style.BackColor = COLOR_INFO;
            }
        }
        #endregion

        #region 数据查询前条件
        private string GetCondition()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" and CUSTOMER_CLAIM_CODE = '{0}'", txtCustomerCode.Text);
            }
            if (!string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                sb.AppendFormat(" and INVOICE_NUMBER like '{0}%'", txtInvoiceNo.Text);
            }
            if (DueSalesDateFrom.Checked)
            {
                sb.AppendFormat(" and  CUSTOMER_CLAIM_DATE >= '{0}'", DueSalesDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (DueSalesDateTo.Checked)
            {
                sb.AppendFormat(" and CUSTOMER_CLAIM_DATE < '{0}'", DueSalesDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            return sb.ToString();
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;

            //  保存成功件数
            int successCount = 0;
            // 保存失败件数
            int erroeCount = 0;

            //信息保存
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                // 预付款金额
                decimal depositAmount = CConvert.ToDecimal(CConvert.ToString(dgvr.Cells["DEPOSIT_AMOUNT"].Value));

                //其他金额
                decimal otherAmount = CConvert.ToDecimal(CConvert.ToString(dgvr.Cells["OTHER_AMOUNT"].Value));

                //收款总金额
                decimal totalAmount = depositAmount + otherAmount;

                if (totalAmount == 0)
                {
                    continue;
                }

                BllReceiptMatchTable bllReceiptMatchTable = new BllReceiptMatchTable();
                //收款单据内部编号
                //后台更新
                //bllReceiptMatchTable.SLIP_NUMBER = 0;

                //收款时间
                bllReceiptMatchTable.SLIP_DATE = CConvert.ToDateTime(dgvr.Cells["SLIP_DATE"].Value);

                //销售内部编号
                bllReceiptMatchTable.SALES_SLIP_NUMBER = CConvert.ToString(dgvr.Cells["SALES_SLIP_NUMBER"].Value);

                //销售内部明细编号（暂不使用，默认更新为：1）
                bllReceiptMatchTable.SALES_LINE_NUMBER = 1;

                //合计收款金额
                bllReceiptMatchTable.TOTAL_AMOUNT = totalAmount;

                //预付款金额
                bllReceiptMatchTable.DEPOSIT_AMOUNT = depositAmount;

                //其他金额
                bllReceiptMatchTable.OTHER_AMOUNT = otherAmount;

                //状态
                bllReceiptMatchTable.STATUS_FLAG = CConstant.INIT;

                // 公司 
                bllReceiptMatchTable.COMPANY_CODE = UserTable.COMPANY_CODE;
                try
                {
                    result = bSales.AddBllReceiptMatch(bllReceiptMatchTable);
                    if (result <= 0)
                    {
                        erroeCount = erroeCount + 1;
                    }
                    else
                    {
                        successCount = successCount + 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Logger.Error("收款金额输入保存失败!!!!!", ex);
                }
            }

            //
            if (successCount == 0 && erroeCount == 0)
            {
                MessageBox.Show("请输入收款金额。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (successCount > 0 && erroeCount == 0)
            {
                MessageBox.Show("收款保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                initPage();
            }

            else if (successCount > 0 && erroeCount > 0)
            {
                MessageBox.Show("收款保存部分失败！请与系统管理员联系！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                initPage();
            }

            else if (successCount == 0 && erroeCount > 0)
            {
                MessageBox.Show("收款保存失败！请与系统管理员联系！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                initPage();
            }

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
            //预付款余额
            this.txtDepositAmount.Text = "";
            //发票编号
            this.txtInvoiceNo.Text = "";
            this.DueSalesDateFrom.Checked = false;
            this.DueSalesDateTo.Checked = false;
            this.dgvData.Rows.Clear();
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
                DataGridViewRow dgvr = dgvData.Rows[e.Row.Index];
                if (dgvr.Cells["No"].Value == null || "".Equals(dgvr.Cells["No"].Value.ToString()))
                {
                    dgvr.Selected = false;
                }
            }
        }

        bool HasAttachEvent = false;
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl control = (DataGridViewTextBoxEditingControl)e.Control;

            if (!this.HasAttachEvent) // 注册事件
            {
                control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "DEPOSIT_AMOUNT")
                    {
                        InputAmount(o, c);
                    }
                    else if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "OTHER_AMOUNT")
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
        #endregion

        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["SLIP_DATE"].Index)
                {
                    string slipDate = CConvert.ToString(dgvr.Cells["SLIP_DATE"].Value);
                    if (slipDate != "")
                    {
                        DateTime dTime = DateTime.Now;
                        try
                        {
                            dTime = DateTime.Parse(slipDate);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的收款日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        dgvr.Cells["SLIP_DATE"].Value = dTime.ToString("yyyy-MM-dd");
                    }
                }
            }
            catch { }
        }

    }//end class
}
