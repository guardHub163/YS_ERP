using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;

namespace CZZD.ERP.WinUI
{
    public partial class FrmSupplierDeposit : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        BSupplierDeposit bDeposit = new BSupplierDeposit();
        public FrmSupplierDeposit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        private void FrmSupplierDeposit_Load(object sender, EventArgs e)
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
            this.txtSupplierCode.Text = "";
            this.txtSupplierName.Text = "";
            this.txtAmount.Text = "";
            this.txtBalance.Text = "";
            this.txtMemo.Text = "";
        }


        #region 供应商
        /// <summary>
        /// 供应商选择
        /// </summary>
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    txtAmount.Focus();
                }
            }
            frm.Dispose();
            txtBalance.Text = CConvert.ToString(GetSupplierDepositBlanace(txtSupplierCode.Text.Trim()));
        }

        /// <summary>
        /// 供应商CHECK
        /// </summary>
        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (!string.IsNullOrEmpty(SupplierCode))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                    txtBalance.Text = CConvert.ToString(GetSupplierDepositBlanace(txtSupplierCode.Text.Trim()));
                }
                else
                {
                    MessageBox.Show("供应商编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    txtBalance.Text = "";
                    txtSupplierCode.Focus();
                }
            }
            else
            {
                txtSupplierName.Text = "";
                txtBalance.Text = "";
                txtAmount.Text = "";
            }

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

            BllSupplierDepositTable depositTable = new BllSupplierDepositTable();
            depositTable.SLIP_NUMBER = this.txtSlipNumber.Text;
            depositTable.SLIP_DATE = this.txtSlipDate.Value;
            depositTable.SUPPLIER_CODE = this.txtSupplierCode.Text;           
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
                Logger.Error("预付款输入保存失败。", ex);
            }
        }



        /// <summary>
        /// 数据验证
        /// </summary>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                MessageBox.Show("供应商不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSupplierCode.Focus();
                return false;
            }
            else if (CConvert.ToDecimal(txtAmount.Text.Trim()) <= 0)
            {
                MessageBox.Show("预付款金额必须大于零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region
        /// <summary>
        /// 关闭页面
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



    }//end class
}
