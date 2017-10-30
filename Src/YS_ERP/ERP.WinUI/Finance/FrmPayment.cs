using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmPayment : FrmBase
    {
        BPaymentMatch bPayemntMatch = new BPaymentMatch();
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        public FrmPayment()
        {
            InitializeComponent();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            dgvData.Rows.Add(PageSize);

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
            if (DialogResult.Yes == MessageBox.Show("确定关闭吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
            }
        }
        #endregion

        #region 数据查询前条件
        private string GetCondition()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0} and UN_PAYMENT_AMOUNT > 0 ", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                sb.AppendFormat(" and SUPPLIER_CODE = '{0}'", txtSupplierCode.Text);
            }
            if (!string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
            {
                sb.AppendFormat(" and INVOICE_No like '{0}%'", txtInvoiceNo.Text);
            }
            if (txtPaymentDateFrom.Checked)
            {
                sb.AppendFormat(" and  PAYMENT_DaTE >= '{0}'", txtPaymentDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (txtPaymentDateTo.Checked)
            {
                sb.AppendFormat(" and PAYMENT_DaTE < '{0}'", txtPaymentDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            return sb.ToString();
        }
        #endregion

        #region 查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strWhere = GetCondition();
            string orderby = "ORDER BY SUPPLIER_CODE";
            DataTable dt = bPayemntMatch.GetPaymentEntryDataList(strWhere + orderby).Tables[0];

            //初期化
            this.dgvData.Rows.Clear();

            if (dt.Rows.Count > 0)
            {
                int i = 1;
                string currentSupplierName = "";
                foreach (DataRow dr in dt.Rows)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow row = dgvData.Rows[currentRowIndex];
                    row.Cells["No"].Value = i++;
                    string suppliername = CConvert.ToString(dr["SUPPLIER_NAME"]);
                    if (currentSupplierName == "" || currentSupplierName != suppliername)
                    {
                        //供应商
                        currentSupplierName = suppliername;
                        row.Cells["SUPPLIER_NAME"].Value = dr["SUPPLIER_NAME"];
                    }
                    //开票日期
                    row.Cells["PURCHASE_SLIP_DATE"].Value = dr["SLIP_DATE"];
                    //发票No
                    row.Cells["INVOICE_No"].Value = dr["INVOICE_No"];
                    //发票金额
                    row.Cells["INVOICE_NO_AMOUNT"].Value = dr["INVOICE_NO_AMOUNT"];
                    //通货
                    row.Cells["CURRENCY_NAME"].Value = dr["CURRENCY_NAME"];
                    //未付金额
                    row.Cells["UN_PAYMENT_AMOUNT"].Value = dr["UN_PAYMENT_AMOUNT"];
                    //预付款金额
                    row.Cells["DEPOSIT_AMOUNT"].Value = "0";
                    //金额
                    row.Cells["OTHER_AMOUNT"].Value = "0";
                    row.Cells["SLIP_NUMBER"].Value = dr["SLIP_NUMBER"];

                    row.Cells["DEPOSIT_AMOUNT"].Style.BackColor = System.Drawing.SystemColors.Info;
                    row.Cells["DEPOSIT_AMOUNT"].Style.SelectionForeColor = System.Drawing.SystemColors.ControlText;
                    row.Cells["DEPOSIT_AMOUNT"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;

                    row.Cells["OTHER_AMOUNT"].Style.BackColor = System.Drawing.SystemColors.Info;
                    row.Cells["OTHER_AMOUNT"].Style.SelectionForeColor = System.Drawing.SystemColors.ControlText;
                    row.Cells["OTHER_AMOUNT"].Style.SelectionBackColor = System.Drawing.SystemColors.Info;

                    row.Cells["DEPOSIT_AMOUNT"].ReadOnly = false;
                    row.Cells["OTHER_AMOUNT"].ReadOnly = false;
                }
                txtTotalNoPayment.Text = "0";
            }
            else
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            for (int i = dt.Rows.Count; i < PageSize; i++)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells["DEPOSIT_AMOUNT"].ReadOnly = true;
                row.Cells["OTHER_AMOUNT"].ReadOnly = true;
            }
        }
        #endregion

        #region 控制空行不能被点击
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
        #endregion

        #region 金额的输入验证
        /// <summary>
        /// 金额的输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region dgvData单元格验证
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                decimal UN_PAYMENT_AMOUNT = CConvert.ToDecimal(dgvr.Cells["UN_PAYMENT_AMOUNT"].Value);
                if (e.ColumnIndex == dgvData.Columns["DEPOSIT_AMOUNT"].Index)
                {
                    if (CConvert.ToDecimal(dgvr.Cells["DEPOSIT_AMOUNT"].Value) <= UN_PAYMENT_AMOUNT &&
                        (CConvert.ToDecimal(dgvr.Cells["DEPOSIT_AMOUNT"].Value) + CConvert.ToDecimal(dgvr.Cells["OTHER_AMOUNT"].Value)) <= UN_PAYMENT_AMOUNT)
                    {
                        Calculate();
                    }
                    else
                    {
                        MessageBox.Show("预付款金额不能大于未付金额,\r\n或预付款金额与付款金额之和不能大于未付金额", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvr.Cells["DEPOSIT_AMOUNT"].Value = "0";
                        dgvr.Cells["DEPOSIT_AMOUNT"].Selected = true;
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["OTHER_AMOUNT"].Index)
                {
                    if (CConvert.ToDecimal(dgvr.Cells["OTHER_AMOUNT"].Value) <= UN_PAYMENT_AMOUNT &&
                        (CConvert.ToDecimal(dgvr.Cells["DEPOSIT_AMOUNT"].Value) + CConvert.ToDecimal(dgvr.Cells["OTHER_AMOUNT"].Value)) <= UN_PAYMENT_AMOUNT)
                    {
                        Calculate();
                    }
                    else
                    {
                        MessageBox.Show("付款金额不能大于未付金额,\r\n或预付款金额与付款金额之和不能大于未付金额", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvr.Cells["OTHER_AMOUNT"].Value = "0";
                        dgvr.Cells["OTHER_AMOUNT"].Selected = true;
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["SLIP_DATE"].Index)
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
                            MessageBox.Show("请输入正确的付款日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        dgvr.Cells["SLIP_DATE"].Value = dTime.ToString("yyyy-MM-dd");
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                int result = 0;

                //  保存成功件数
                int successCount = 0;
                // 保存失败件数
                int erroeCount = 0;

                BllPaymentMatchTable payment = null;
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    // 预付款金额
                    decimal depositAmount = CConvert.ToDecimal(CConvert.ToString(row.Cells["DEPOSIT_AMOUNT"].Value));

                    //其他金额
                    decimal otherAmount = CConvert.ToDecimal(CConvert.ToString(row.Cells["OTHER_AMOUNT"].Value));

                    //收款总金额
                    decimal totalAmount = depositAmount + otherAmount;

                    payment = new BllPaymentMatchTable();
                    payment.SLIP_DATE = CConvert.ToDateTime(row.Cells["SLIP_DATE"].Value);
                    payment.PURCHASE_SLIP_NUMBER = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                    payment.TOTAL_AMOUNT = totalAmount;
                    payment.DEPOSIT_AMOUNT = depositAmount;
                    payment.OTHER_AMOUNT = otherAmount;
                    payment.COMPANY_CODE = _userInfo.COMPANY_CODE;
                    payment.STATUS_FLAG = CConstant.INIT;
                    payment.CREATE_USER = _userInfo.CODE;
                    payment.CREATE_DATE_TIME = DateTime.Now;
                    payment.LAST_UPDATE_USER = _userInfo.CODE;
                    payment.LAST_UPDATE_TIME = DateTime.Now;

                    try
                    {
                        result = bPayemntMatch.AddpaymentMatch(payment);
                        if (result > 0)
                        {
                            successCount = successCount + 1;
                        }
                        else
                        {
                            erroeCount = erroeCount + 1;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Logger.Error("收款金额输入保存失败!!!!!", ex);
                    }
                }

                if (successCount > 0 && erroeCount == 0)
                {
                    MessageBox.Show("付款输入保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initPage();
                }

                else if (successCount > 0 && erroeCount > 0)
                {
                    MessageBox.Show("付款保存部分失败！请与系统管理员联系！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initPage();
                }

                else if (successCount == 0 && erroeCount > 0)
                {
                    MessageBox.Show("付款保存失败！请与系统管理员联系！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initPage();
                }
            }
        }
        #endregion

        #region 保存前验证
        private bool saveCheck()
        {
            string strErrlog = null;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["No"].Value == null || "".Equals(row.Cells["No"].Value.ToString()))
                {
                    break;
                }

                // 预付款金额
                decimal depositAmount = CConvert.ToDecimal(CConvert.ToString(row.Cells["DEPOSIT_AMOUNT"].Value));

                //其他金额
                decimal otherAmount = CConvert.ToDecimal(CConvert.ToString(row.Cells["OTHER_AMOUNT"].Value));

                //收款总金额
                decimal totalAmount = depositAmount + otherAmount;
                if (totalAmount == 0)
                {
                    strErrlog = "第" + row.Cells["No"].Value.ToString() + "行请输入付款金额!\r\n";
                }
            }
            if (!string.IsNullOrEmpty(strErrlog))
            {
                MessageBox.Show(strErrlog);
                return false;
            }
            return true;
        }
        #endregion

        #region 保存成功后页面初始化
        private void initPage()
        {
            this.dgvData.Rows.Clear();
            txtSupplierCode.Text = "";
            txtSupplierName.Text = "";
            txtInvoiceNo.Text = "";
            txtPaymentDateFrom.Value = DateTime.Now;
            txtPaymentDateTo.Value = DateTime.Now;
            txtPaymentDateFrom.Checked = false;
            txtPaymentDateTo.Checked = false;
            txtTotalNoPayment.Text = "0";
        }
        #endregion

        #region 计算本次付款总额
        private void Calculate()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                decimal depositAmount = CConvert.ToDecimal(CConvert.ToString(row.Cells["DEPOSIT_AMOUNT"].Value));
                decimal otherAmount = CConvert.ToDecimal(CConvert.ToString(row.Cells["OTHER_AMOUNT"].Value));
                totalAmount = totalAmount + depositAmount + otherAmount;
            }
            txtTotalNoPayment.Text = totalAmount.ToString();
        }
        #endregion
    }
}
