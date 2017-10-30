using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmDeliveryDialog : Form
    {
        private BDelivery bDelivery = new BDelivery();
        private BaseUserTable _userInfo;
        private BaseDeliveryTable _currentDeliveryTable = null;
        private int _mode = 1;
        private BCommon bCommon = new BCommon();
        private DialogResult result = DialogResult.Cancel;

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
        public BaseDeliveryTable CurrentDeliveryTable
        {
            get { return _currentDeliveryTable; }
            set { _currentDeliveryTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmDeliveryDialog()
        {
            InitializeComponent();
        }

        private void FrmDeliveryDialog_Load(object sender, EventArgs e)
        {
            if (_currentDeliveryTable != null)
            {
                txtCustomerCode.Text = _currentDeliveryTable.CUSTOMER_CODE;
                txtCustomerName.Text = bCommon.GetBaseMaster("CUSTOMER", _currentDeliveryTable.CUSTOMER_CODE).Name;
                txtDeliveryCode.Text = _currentDeliveryTable.DELIVERY_CODE;
                txtAddressFirst.Text = _currentDeliveryTable.ADDRESS_FIRST;
                txtAddressMiddle.Text = _currentDeliveryTable.ADDRESS_MIDDLE;
                txtAddressLast.Text = _currentDeliveryTable.ADDRESS_LAST;
                txtZipCode.Text = _currentDeliveryTable.ZIP_CODE;
                txtPhone.Text = _currentDeliveryTable.PHONE_NUMBER;
                txtFax.Text = _currentDeliveryTable.FAX_NUMBER;
                txtMobilNumber.Text = _currentDeliveryTable.MOBIL_NUMBER;
                txtContactName.Text = _currentDeliveryTable.CONTACT_NAME;
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCustomerCode.BackColor = Color.WhiteSmoke;
                txtCustomerCode.Enabled = false;
                txtDeliveryCode.BackColor = Color.WhiteSmoke;
                txtDeliveryCode.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCustomerCode.Text = "";
                txtDeliveryCode.Text = "";
            }
        }

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentDeliveryTable == null)
                {
                    _currentDeliveryTable = new BaseDeliveryTable();
                }

                _currentDeliveryTable.CUSTOMER_CODE = txtCustomerCode.Text.Trim();
                //_currentDeliveryTable.CUSTOMER_NAME = txtCustomerName.Text.Trim();
                _currentDeliveryTable.DELIVERY_CODE = txtDeliveryCode.Text.Trim();
                _currentDeliveryTable.ADDRESS_FIRST = txtAddressFirst.Text.Trim();
                _currentDeliveryTable.ADDRESS_MIDDLE = txtAddressMiddle.Text.Trim();
                _currentDeliveryTable.ADDRESS_LAST = txtAddressLast.Text.Trim();
                _currentDeliveryTable.ZIP_CODE = txtZipCode.Text.Trim();
                _currentDeliveryTable.PHONE_NUMBER = txtPhone.Text.Trim();
                _currentDeliveryTable.FAX_NUMBER = txtFax.Text.Trim();
                _currentDeliveryTable.MOBIL_NUMBER = txtMobilNumber.Text.Trim();
                _currentDeliveryTable.CONTACT_NAME = txtContactName.Text.Trim();
                _currentDeliveryTable.LAST_UPDATE_USER = _userInfo.CODE;
            
                try
                {
                    if (bDelivery.Exists(txtCustomerCode.Text.Trim(), txtDeliveryCode.Text.Trim()))
                        bDelivery.Update(_currentDeliveryTable);
                    else
                    {
                        _currentDeliveryTable.CREATE_USER = _userInfo.CODE;
                        bDelivery.Add(_currentDeliveryTable);
                    }
                }
                catch (Exception ex)
                {
                    //log.error
                    MessageBox.Show("");
                    return;
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
            if (string.IsNullOrEmpty(this.txtCustomerCode.Text.Trim()))
            {
                strErrorlog += "客户编号不能为空!\r\n";
            }

            //判断地址编号不能为空
            if (string.IsNullOrEmpty(this.txtDeliveryCode.Text.Trim()))
            {
                strErrorlog += "地址编号不能为空!\r\n";
            }

            //判断地址名称不能为空
            if (string.IsNullOrEmpty(this.txtAddressFirst.Text.Trim()))
            {
                strErrorlog += "地址1不能为空!\r\n";
            }

            if (strErrorlog != null || "".Equals(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
      
            if (CTools.GetTextBoxLength(txtContactName.Text) > txtContactName.MaxLength)
                txtContactName.Text = CTools.textSpilt(txtContactName.Text, txtContactName.MaxLength);
            return true;
        }
        #endregion

        #region 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        private void FrmCustomerDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        #region 客户
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Customer", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtCustomerName.Text = frm.BaseMasterTable.Name;
                    txtDeliveryCode.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCustomerCode.Text.Trim()))
            {
                BaseCustomerTable Customer = new BaseCustomerTable();
                BCustomer bCustomer = new BCustomer();
                Customer = bCustomer.GetModel(txtCustomerCode.Text);
                if (Customer == null)
                {
                    txtCustomerCode.Focus();
                    txtCustomerCode.Text = "";
                    txtCustomerName.Text = "";
                    MessageBox.Show("客户编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtCustomerName.Text = Customer.NAME;
                }
            }
        }
        #endregion

        private void FrmCustomerDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtCustomerCode.Focus();
            }
            else
            {
                txtAddressFirst.Focus();
            }
        }

        #region 按键
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 )
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            } 

            if (txtPhone.Focused || txtFax.Focused || txtMobilNumber.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)45)
                {
                    e.Handled = true;
                }
            }

            if (txtZipCode.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }

        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion
                
        private void txtDeliveryCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerCode.Text) && !string.IsNullOrEmpty(txtDeliveryCode.Text))
            {
            
                BaseDeliveryTable DeliveryCode = new BaseDeliveryTable();
                DeliveryCode = bDelivery.GetModel(txtCustomerCode.Text.Trim(), txtDeliveryCode.Text.Trim());
                if (DeliveryCode != null)
                {
                     txtCustomerCode.Text = "";
                     txtCustomerName.Text = "";
                     txtDeliveryCode.Text = "";
                     txtAddressFirst.Text = "";
                     txtCustomerCode.Focus();
                     MessageBox.Show("客户编号和地址编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
            }
        }
    }
}
