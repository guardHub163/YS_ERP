using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;
using System.Text.RegularExpressions;

namespace CZZD.ERP.WinUI.Master
{
    public partial class FrmMaterialDialog : Form
    {
        private BMaterial bmaterial = new BMaterial();
        private BaseUserTable _userInfo;
        private BaseCustomerTable _currentCustomerTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BCommon bCommon = new BCommon();

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        /// <summary>
        /// 当前数据
        /// </summary>
        public BaseCustomerTable CurrentCustomerTable
        {
            get { return _currentCustomerTable; }
            set { _currentCustomerTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmMaterialDialog()
        {
            InitializeComponent();
        }

        private void FrmMaterialDialog_Load(object sender, EventArgs e)
        {
            if (_currentCustomerTable != null)
            {
                txtCode.Text = _currentCustomerTable.CODE;
                txtName.Text = _currentCustomerTable.NAME;     
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCode.BackColor = Color.WhiteSmoke;
                txtCode.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCode.Text = "";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentCustomerTable == null)
                {
                    _currentCustomerTable = new BaseCustomerTable();
                }
                _currentCustomerTable.CODE = txtCode.Text.Trim();
                _currentCustomerTable.NAME = txtName.Text.Trim();              
                _currentCustomerTable.CURRENCE_CODE = CConstant.EXCHANGE_CHIAN;
                _currentCustomerTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bmaterial.Exists(txtCode.Text.Trim()))
                        bmaterial.Update(_currentCustomerTable);
                    else
                    {
                        _currentCustomerTable.CREATE_USER = _userInfo.CODE;
                        bmaterial.Add(_currentCustomerTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                result = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断编号不能为空
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                strErrorlog += "材质编号不能为空!\r\n";
            }

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                strErrorlog += "材质名称不能为空!\r\n";
            }

            if (strErrorlog != null || "".Equals(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 取消/关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }

        private void FrmMaterialDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        #region 货币
        //private void btnCurrencyCode_Click(object sender, EventArgs e)
        //{

        //    FrmMasterSearch frm = new FrmMasterSearch("CURRENCY", "");
        //    if (frm.ShowDialog(this) == DialogResult.OK)
        //    {
        //        if (frm.BaseMasterTable != null)
        //        {
        //            txtCurrencyCode.Text = frm.BaseMasterTable.Code;
        //            txtCurrencyName.Text = frm.BaseMasterTable.Name;
        //            txtCurrencyCode.Focus();
        //        }
        //    }
        //    frm.Dispose();
        //}

        //private void txtCurrencyCode_Leave(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(this.txtCurrencyCode.Text.Trim()))
        //    {
        //        BaseCurrencyTable Currency = new BaseCurrencyTable();
        //        BCurrency bCurrency = new BCurrency();
        //        Currency = bCurrency.GetModel(txtCurrencyCode.Text);
        //        if (Currency == null)
        //        {
        //            txtCurrencyCode.Focus();
        //            txtCurrencyCode.Text = "";
        //            txtCurrencyName.Text = "";
        //            MessageBox.Show("货币编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //        else
        //            txtCurrencyName.Text = Currency.NAME;
        //    }
        //    else
        //    {
        //        txtCurrencyName.Text = "";
        //    }
        //}
        #endregion

        private void FrmMaterialDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtCode.Focus();
            }
            else
            {
                txtName.Focus();
            }
        }

        #region 按键事件
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }

            //if (txtPhone.Focused || txtFax.Focused || txtMobilNumber.Focused)
            //{
            //    if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)45)
            //    {
            //        e.Handled = true;
            //    }
            //}

            //if (txtZipCode.Focused)
            //{
            //    if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            //    {
            //        e.Handled = true;
            //    }
            //}
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtCode.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            //if (e.KeyCode == Keys.Down)
            //{
            //    if (txtMemo.Focused)
            //    {
            //        btnSave.Focus();
            //    }
            //    else
            //    {
            //        System.Windows.Forms.SendKeys.Send("{Tab}");
            //    }
            //}
        }
        #endregion

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                BaseCustomerTable CustomerCode = new BaseCustomerTable();
                CustomerCode = bmaterial.GetModel(txtCode.Text);
                if (CustomerCode != null)
                {
                    txtCode.Focus();
                    txtCode.Text = "";
                    MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //private void txtEmail_Leave(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(this.txtEmail.Text.Trim()))
        //    {
        //        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //        Regex re = new Regex(strRegex);
        //        if (!re.IsMatch(txtEmail.Text))
        //        {
        //            txtEmail.Focus();
        //            txtEmail.Text = "";
        //            MessageBox.Show("邮箱格式不正确!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //}

        #region 请款客户编号
        //private void button1_Click(object sender, EventArgs e)
        //{

        //    FrmMasterSearch frm = new FrmMasterSearch("Customer", "");
        //    if (frm.ShowDialog(this) == DialogResult.OK)
        //    {
        //        if (frm.BaseMasterTable != null)
        //        {
        //            txtClaimCode.Text = frm.BaseMasterTable.Code;
        //            txtClaimName.Text = frm.BaseMasterTable.Name;
        //            txtClaimCode.Focus();
        //        }
        //    }
        //    frm.Dispose();
        //}

        //private void txtClaimCode_Leave(object sender, EventArgs e)
        //{
        //    string claim = txtClaimCode.Text.Trim();
        //    if (!string.IsNullOrEmpty(claim))
        //    {
        //        BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", claim);
        //        if (baseMaster != null)
        //        {
        //            txtClaimCode.Text = baseMaster.Code;
        //            txtClaimName.Text = baseMaster.Name;
        //            btnSave.Focus();
        //        }
        //        else
        //        {
        //            MessageBox.Show("客户编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtClaimCode.Text = "";
        //            txtClaimName.Text = "";
        //            txtClaimCode.Focus();
        //        }
        //    }
        //    else
        //    {
        //        txtClaimName.Text = "";
        //    }
        //}
        #endregion
    }
}
