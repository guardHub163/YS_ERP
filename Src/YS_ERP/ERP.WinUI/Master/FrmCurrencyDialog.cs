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
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmCurrencyDialog : Form
    {
        private BCurrency bCurrency = new BCurrency();
        private BaseUserTable _userInfo;
        private BaseCurrencyTable _currentCurrencyTable = null;
        private int _mode;
        private DialogResult result = DialogResult.Cancel;
    

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseCurrencyTable CurrentCurrencyTable
        {
            get { return _currentCurrencyTable; }
            set { _currentCurrencyTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmCurrencyDialog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentCurrencyTable == null)
                {
                    _currentCurrencyTable = new BaseCurrencyTable();
                }
                _currentCurrencyTable.CODE = txtCode.Text;
                _currentCurrencyTable.NAME = txtName.Text;
                _currentCurrencyTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bCurrency.Exists(txtCode.Text.Trim()))
                    {
                        bCurrency.Update(_currentCurrencyTable);
                    }
                    else
                    {
                        _currentCurrencyTable.CREATE_USER = _userInfo.CODE;
                        bCurrency.Add(_currentCurrencyTable);
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
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                strErrorlog += "编号不能为空!\r\n";               
            }

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {     
                strErrorlog += "名称不能为空!\r\n";               
            }

            if (strErrorlog != null || "".Equals(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (CTools.GetTextBoxLength(txtName.Text) > txtName.MaxLength)
            {
                txtName.Text = CTools.textSpilt(txtName.Text, txtName.MaxLength);
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }

        private void FrmCurrencyDialog_Load(object sender, EventArgs e)
        {
            if (_currentCurrencyTable != null)
            {

                txtCode.Text = _currentCurrencyTable.CODE;
                txtName.Text = _currentCurrencyTable.NAME;
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

        private void FrmCurrencyDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void FrmCurrencyDialog_Shown(object sender, EventArgs e)
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

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if(txtName.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    //System.Windows.Forms.SendKeys.Send("{Tab}");
                    ProcessTabKey(true);
                }
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                BaseCurrencyTable CurrencyCode = new BaseCurrencyTable();
                CurrencyCode = bCurrency.GetModel(txtCode.Text);
                if (CurrencyCode != null)
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
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtName.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }
    }
}
