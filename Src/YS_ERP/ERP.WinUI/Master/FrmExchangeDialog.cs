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
    public partial class FrmExchangeDialog : Form
    {
        private BaseUserTable _userInfo;
        private BaseExchangeTable _currentExchangeTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BCommon bCommon = new BCommon();
        private BExchange bExchange = new BExchange();

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
        public BaseExchangeTable CurrentExchangeTable
        {
            get { return _currentExchangeTable; }
            set { _currentExchangeTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }


        public FrmExchangeDialog()
        {
            InitializeComponent();
        }

        #region 货币
        private void btnCurrency_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CURRENCY", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCurrencyCode.Text = frm.BaseMasterTable.Code;
                    txtCurrencyName.Text = frm.BaseMasterTable.Name;
                    txtCurrencyCode.Focus();
                    txtExchangeRate.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtCurrencyCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCurrencyCode.Text.Trim()))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CURRENCY", txtCurrencyCode.Text.Trim());
                if (baseMaster != null)
                {
                    txtCurrencyCode.Text = baseMaster.Code;
                    txtCurrencyName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("货币不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCurrencyCode.Text = "";
                    txtCurrencyName.Text = "";
                    txtCurrencyCode.Focus();
                }
            }
            else
            {
                txtCurrencyName.Text = "";
            }

            if (!string.IsNullOrEmpty(this.txtCurrencyCode.Text.Trim()) && ExchangeDate.Value != null)
            {
                BaseExchangeTable exchange = new BaseExchangeTable();
                exchange = bExchange.GetModel(CConvert.ToDateTime(ExchangeDate.Value.ToString("yyyy-MM")), txtCurrencyCode.Text);
                if (exchange != null)
                {
                    ExchangeDate.Value = DateTime.Now;
                    txtCurrencyCode.Text = "";
                    ExchangeDate.Focus();
                    MessageBox.Show("当月此货币汇率已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion        

        #region 按键
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //System.Windows.Forms.SendKeys.Send("{Tab}");
                ProcessTabKey(true);
            }

            if (txtExchangeRate.Focused)
            {
                if (e.KeyChar == 46)
                {
                    if (((TextBox)sender).SelectionStart == 0)
                    {
                        e.Handled = true;
                    }
                    else if (((TextBox)sender).Text.IndexOf('.') >= 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 46) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26)
                {
                    e.Handled = true;
                }
                else　 //以下为输入正确内容过虑
                {
                    string[] str = ((TextBox)sender).Text.Split('.');
                    if (str.Length > 1)
                    {
                        if (str[1].Length >= 6 && ((TextBox)sender).SelectionStart > ((TextBox)sender).Text.IndexOf('.'))
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtCurrencyCode.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (ExchangeDate.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
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

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentExchangeTable == null)
                {
                    _currentExchangeTable = new BaseExchangeTable();
                }

                _currentExchangeTable.EXCHANGE_DATE =CConvert.ToDateTime(ExchangeDate.Value.ToString("yyyy-MM"));
                _currentExchangeTable.FROM_CURRENCY_CODE = txtCurrencyCode.Text;
                _currentExchangeTable.TO_CURRENCY_CODE = CConstant.EXCHANGE_CHIAN;
                _currentExchangeTable.EXCHANGE_RATE = CConvert.ToDecimal(txtExchangeRate.Text);
                _currentExchangeTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bExchange.Exists(ExchangeDate.Value, txtCurrencyCode.Text.Trim()))
                    {
                        bExchange.Update(_currentExchangeTable);
                    }
                    else
                    {
                        _currentExchangeTable.CREATE_USER = _userInfo.CODE;
                        bExchange.Add(_currentExchangeTable);
                    }
                }
                catch (Exception ex)
                {
                    //log.error
                    MessageBox.Show(ex.Message);
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
            if (string.IsNullOrEmpty(this.txtCurrencyCode.Text.Trim()))
            {
                strErrorlog += "货币不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(this.txtExchangeRate.Text.Trim()))
            {
                strErrorlog += "汇率不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        #endregion

        private void FrmExchangeDialog_Load(object sender, EventArgs e)
        {
            if (_currentExchangeTable != null)
            {
                ExchangeDate.Value = _currentExchangeTable.EXCHANGE_DATE;
                txtCurrencyCode.Text =  _currentExchangeTable.FROM_CURRENCY_CODE;
                if (!string.IsNullOrEmpty(_currentExchangeTable.FROM_CURRENCY_CODE) && bCommon.GetBaseMaster("CURRENCY", _currentExchangeTable.FROM_CURRENCY_CODE) != null)
                {
                    txtCurrencyName.Text = bCommon.GetBaseMaster("CURRENCY", _currentExchangeTable.FROM_CURRENCY_CODE).Name;
                }
                txtExchangeRate.Text = CConvert.ToString(_currentExchangeTable.EXCHANGE_RATE);
               
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCurrencyCode.BackColor = Color.WhiteSmoke;
                ExchangeDate.BackColor = Color.WhiteSmoke;
                txtCurrencyCode.Enabled = false;
                ExchangeDate.Enabled = false;
                btnCurrency.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCurrencyCode.Text = "";
                ExchangeDate.Value = DateTime.Now;
                txtCurrencyName.Text = "";
            }
        }

        private void FrmExchangeDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }

        private void ReportedDate_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCurrencyCode.Text.Trim()) && ExchangeDate.Value != null)
            {
                BaseExchangeTable exchange = new BaseExchangeTable();
                exchange = bExchange.GetModel(CConvert.ToDateTime(ExchangeDate.Value.ToString("yyyy-MM")), txtCurrencyCode.Text);
                if (exchange != null)
                {
                    ExchangeDate.Value = DateTime.Now;
                    txtCurrencyCode.Text = "";
                    ExchangeDate.Focus();
                    MessageBox.Show("当月此货币汇率已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
