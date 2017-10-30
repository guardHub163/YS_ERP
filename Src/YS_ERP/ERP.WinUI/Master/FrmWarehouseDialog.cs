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
using System.Text.RegularExpressions;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmWarehouseDialog : Form
    {
       
        private BWarehouse bWarehouse = new BWarehouse();
        private BaseUserTable _userInfo;
        private BaseWarehouseTable _currentWarehouseTable = null;
        private int _mode = 1;
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
        public BaseWarehouseTable CurrentWarehouseTable
        {
            get { return _currentWarehouseTable; }
            set { _currentWarehouseTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }


        public FrmWarehouseDialog()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load
        /// </summary>
        private void FrmWarehouseDialog_Load(object sender, EventArgs e)
        {
            if (_currentWarehouseTable != null)
            {
                txtCode.Text = _currentWarehouseTable.CODE;
                txtName.Text = _currentWarehouseTable.NAME;
                txtNameShort.Text = _currentWarehouseTable.NAME_SHORT;
                txtZipCode.Text = _currentWarehouseTable.ZIP_CODE;
                txtAddressFirst.Text = _currentWarehouseTable.ADDRESS_FIRST;
                txtAddressMiddle.Text = _currentWarehouseTable.ADDRESS_MIDDLE;
                txtAddressLast.Text = _currentWarehouseTable.ADDRESS_LAST;
                txtPhone.Text = _currentWarehouseTable.PHONE_NUMBER;
                txtFax.Text = _currentWarehouseTable.FAX_NUMBER;
                txtMobil.Text = _currentWarehouseTable.MOBIL_NUMBER;
                txtContactName.Text = _currentWarehouseTable.CONTACT_NAME;
                txtEmail.Text = _currentWarehouseTable.EMAIL;
                txtMemo.Text = _currentWarehouseTable.MEMO;
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
                if (_currentWarehouseTable == null)
                {
                    _currentWarehouseTable = new BaseWarehouseTable();
                }

                _currentWarehouseTable.CODE = txtCode.Text.Trim();
                _currentWarehouseTable.NAME = txtName.Text.Trim();
                _currentWarehouseTable.NAME_SHORT = txtNameShort.Text.Trim();
                _currentWarehouseTable.ZIP_CODE = txtZipCode.Text.Trim();
                _currentWarehouseTable.ADDRESS_FIRST = txtAddressFirst.Text.Trim();
                _currentWarehouseTable.ADDRESS_MIDDLE = txtAddressMiddle.Text.Trim();
                _currentWarehouseTable.ADDRESS_LAST = txtAddressLast.Text.Trim();
                _currentWarehouseTable.PHONE_NUMBER = txtPhone.Text.Trim();
                _currentWarehouseTable.FAX_NUMBER = txtFax.Text.Trim();
                _currentWarehouseTable.MOBIL_NUMBER = txtMobil.Text.Trim();
                _currentWarehouseTable.CONTACT_NAME = txtContactName.Text.Trim();
                _currentWarehouseTable.EMAIL = txtEmail.Text.Trim();
                _currentWarehouseTable.MEMO = txtMemo.Text.Trim();
                _currentWarehouseTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bWarehouse.Exists(txtCode.Text.Trim()))
                    {
                        bWarehouse.Update(_currentWarehouseTable);
                    }
                    else
                    {
                        _currentWarehouseTable.CREATE_USER = _userInfo.CODE;
                        bWarehouse.Add(_currentWarehouseTable);
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
                CCacheData.WAREHOUSE = null;
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
                strErrorlog += "编号不能为空!\r\n";
            }
            

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                strErrorlog += "名称不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            if (CTools.GetTextBoxLength(txtName.Text) > txtName.MaxLength)
            {
                txtName.Text = CTools.textSpilt(txtName.Text, txtName.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtNameShort.Text) > txtNameShort.MaxLength)
            {
                txtNameShort.Text = CTools.textSpilt(txtNameShort.Text, txtNameShort.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtAddressFirst.Text) > txtAddressFirst.MaxLength)
            {
                txtAddressFirst.Text = CTools.textSpilt(txtAddressFirst.Text, txtAddressFirst.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtAddressMiddle.Text) > txtAddressMiddle.MaxLength)
            {
                txtAddressMiddle.Text = CTools.textSpilt(txtAddressMiddle.Text, txtAddressMiddle.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtAddressLast.Text) > txtAddressLast.MaxLength)
            {
                txtAddressLast.Text = CTools.textSpilt(txtAddressLast.Text, txtAddressLast.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtMemo.Text) > txtMemo.MaxLength)
            {
                txtMemo.Text = CTools.textSpilt(txtMemo.Text, txtMemo.MaxLength);
            }

            if (CTools.GetTextBoxLength(txtContactName.Text) > txtContactName.MaxLength)
            {
                txtContactName.Text = CTools.textSpilt(txtContactName.Text, txtContactName.MaxLength);
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
            if (MessageBox.Show("确定取消吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FrmUserDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void FrmWarehouseDialog_Shown(object sender, EventArgs e)
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

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtMemo.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }

            }

            if (txtPhone.Focused || txtFax.Focused || txtMobil.Focused)
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

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                BaseWarehouseTable WarehouseCode = new BaseWarehouseTable();
                WarehouseCode = bWarehouse.GetModel(txtCode.Text);
                if (WarehouseCode != null)
                {
                    txtCode.Focus();
                    txtCode.Text = "";
                    MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtCode.Focused)
                {

                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtMemo.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtEmail.Text.Trim()))
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (!re.IsMatch(txtEmail.Text))
                {
                    txtEmail.Focus();
                    txtEmail.Text = "";
                    MessageBox.Show("邮箱格式不正确!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
