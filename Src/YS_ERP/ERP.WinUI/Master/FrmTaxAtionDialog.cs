using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;


namespace CZZD.ERP.WinUI
{
    public partial class FrmTaxAtionDialog : Form
    {

        private BaseUserTable _userInfo;
        private BaseTaxAtionTable _currentTaxAtionTable = null;
        private int _mode;
        private DialogResult result = DialogResult.Cancel;
     
        private BTaxAtion bTaxAtion = new BTaxAtion();

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseTaxAtionTable CurrentTaxAtionTable
        {
            get { return _currentTaxAtionTable; }
            set { _currentTaxAtionTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmTaxAtionDialog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentTaxAtionTable == null)
                {
                    _currentTaxAtionTable = new BaseTaxAtionTable();
                }

                _currentTaxAtionTable.CODE = txtCode.Text.Trim();
                _currentTaxAtionTable.NAME = txtName.Text.Trim();
                _currentTaxAtionTable.TAX_RATE = Convert.ToDecimal(txtTaxRate.Text.Trim());
                _currentTaxAtionTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bTaxAtion.Exists(txtCode.Text.Trim()))
                    {
                        bTaxAtion.Update(_currentTaxAtionTable);
                    }
                    else
                    {
                        _currentTaxAtionTable.CREATE_USER = _userInfo.CODE;
                        bTaxAtion.Add(_currentTaxAtionTable);
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

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (CTools.GetTextBoxLength(txtName.Text) > txtName.MaxLength)
            {
                txtName.Text = CTools.textSpilt(txtName.Text, txtName.MaxLength);
            }

            if (txtTaxRate.Text == null || "".Equals(txtTaxRate.Text))
            {
                txtTaxRate.Text = "0";
            }

            return true;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FrmTaxAtionDialog_Load(object sender, EventArgs e)
        {
            if (_currentTaxAtionTable != null)
            {

                txtCode.Text = _currentTaxAtionTable.CODE;
                txtName.Text = _currentTaxAtionTable.NAME;
                txtTaxRate.Text = _currentTaxAtionTable.TAX_RATE.ToString();
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

        private void FrmTaxAtionDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void FrmTaxAtionDialog_Shown(object sender, EventArgs e)
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
                if (txtTaxRate.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }

            }

            if (txtTaxRate.Focused)
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
                        if (str[1].Length >= 2 && ((TextBox)sender).SelectionStart > ((TextBox)sender).Text.IndexOf('.'))
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                BaseTaxAtionTable TaxAtionCode = new BaseTaxAtionTable();
                TaxAtionCode = bTaxAtion.GetModel(txtCode.Text);
                if (TaxAtionCode != null)
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
                if (txtTaxRate.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }
    }
}
