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

namespace CZZD.ERP.WinUI
{
    public partial class FrmDeposit : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BDeposit bDeposit = new BDeposit();
        private BSales bSales = new BSales();

        public FrmDeposit()
        {
            InitializeComponent();
        }

        private void FrmDeposit_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            InitPage();
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void InitPage()
        {
            //订单编号的取得
            string maxID = bDeposit.GetMaxID();
            this.txtSlipNumber.Text = (CConvert.ToInt32(maxID) + 1).ToString();
            this.txtCustomerCode.Text = "";
            this.txtCustomerName.Text = "";
            this.txtAmount.Text = "";
            this.txtBalance.Text = "";
            this.txtMemo.Text = "";
        }


        #region 客户

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
            txtBalance.Text = CConvert.ToString(GetCustomerDepositBlanace(txtCustomerCode.Text.Trim()));
        }

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
                    MessageBox.Show("客户不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerCode.Text = "";
                    txtCustomerName.Text = "";
                    txtCustomerCode.Focus();
                }
            }
            else
            {
                txtCustomerName.Text = "";
            }
            txtBalance.Text = CConvert.ToString(GetCustomerDepositBlanace(txtCustomerCode.Text.Trim()));
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region  输入保存
        /// <summary>
        /// 输入保存
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!CheckInput())
            {
                return;
            }

            BllDepositTable depositTable = new BllDepositTable();
            depositTable.SLIP_NUMBER = this.txtSlipNumber.Text;
            depositTable.SLIP_DATE = this.txtSlipDate.Value;
            depositTable.CUSTOMER_CLAIM_CODE = this.txtCustomerCode.Text;
            
            depositTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            depositTable.MEMO = this.txtMemo.Text;
            depositTable.STATUS_FLAG = CConstant.NORMAL;
            depositTable.CREATE_USER = UserTable.CODE;
            depositTable.LAST_UPDATE_USER = UserTable.CODE;
            if (rdoDeposit.Checked)
            {
                depositTable.AMOUNT = CConvert.ToDecimal(this.txtAmount.Text);
                depositTable.SLIP_TYPE = CConstant.DEPOSIT;
            }
            else
            {
                depositTable.AMOUNT = -CConvert.ToDecimal(this.txtAmount.Text);
                depositTable.SLIP_TYPE = CConstant.RE_DEPOSIT;
            }
            try
            {
                if (bDeposit.Add(depositTable) > 0)
                {
                    MessageBox.Show("保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitPage();
                }
                else
                {
                    MessageBox.Show("保存失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Error("预收款输入保存失败。", ex);
            }
        }



        /// <summary>
        /// 数据验证
        /// </summary>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtCustomerCode.Text.Trim()))
            {
                MessageBox.Show("客户编号不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerCode.Focus();
                return false;
            }
            else if (CConvert.ToDecimal(txtAmount.Text.Trim()) <= 0)
            {
                MessageBox.Show("预收款金额必须大于零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAmount.Focus();
                return false;
            }
            else if (txtMemo.Text.Trim().Length > 100)
            {
                MessageBox.Show("备注信息过长。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMemo.Text = txtMemo.Text.Trim().Substring(0, 100);
                txtMemo.Focus();
                return false;
            }
            return true;
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox obj = (TextBox)sender;
                if ("txtAmount".Equals(obj.Name))   //金额输入控制
                {
                    InputAmount(sender, e);
                }
            }
            catch { }


            base.TextBox_KeyPress(sender, e);
        }

    }//end class
}
