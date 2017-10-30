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

namespace CZZD.ERP.WinUI
{
    public partial class FrmHsCodeDialog : Form
    {

        private BaseUserTable _userInfo;
        private BaseHsCodeTable _currentHsCodeTable = null;
        private int _mode;
        private BHsCode bHsCode = new BHsCode();
        private DialogResult result = DialogResult.Cancel;
       

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseHsCodeTable CurrentHsCodeTable
        {
            get { return _currentHsCodeTable; }
            set { _currentHsCodeTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmHsCodeDialog()
        {
            InitializeComponent();
        }

        #region 页面初始化
        private void FrmHsCodeDialog_Load(object sender, EventArgs e)
        {
            if (_currentHsCodeTable != null)
            {
                txtHsCode.Text = _currentHsCodeTable.HS_CODE;
                txtHsName.Text = _currentHsCodeTable.HS_NAME;
                txtTaxRate.Text = _currentHsCodeTable.TAX_RATE.ToString();
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtHsCode.BackColor = Color.WhiteSmoke;
                txtHsCode.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtHsCode.Text = "";
            }
        }

        private void FrmHsCodeDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtHsCode.Focus();
            }
            else
            {
                txtHsName.Focus();
            }
        }
        #endregion

        #region 关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FrmHsCodeDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentHsCodeTable == null)
                {
                    _currentHsCodeTable = new BaseHsCodeTable();
                }

                _currentHsCodeTable.HS_CODE = txtHsCode.Text;
                _currentHsCodeTable.HS_NAME = txtHsName.Text;

                _currentHsCodeTable.TAX_RATE = Convert.ToDecimal(txtTaxRate.Text);
                _currentHsCodeTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bHsCode.Exists(txtHsCode.Text.Trim()))
                    {
                        bHsCode.Update(_currentHsCodeTable);
                    }
                    else
                    {
                        _currentHsCodeTable.CREATE_USER = _userInfo.CODE;
                        bHsCode.Add(_currentHsCodeTable);
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
            if (string.IsNullOrEmpty(this.txtHsCode.Text.Trim()))
            {
                strErrorlog += "编号不能为空!\r\n";    
            }

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtHsName.Text.Trim()))
            {
                strErrorlog += "名称不能为空!\r\n";
            }

            //判断关税税率不能为空
            if (string.IsNullOrEmpty(this.txtTaxRate.Text.Trim()))
            {
                strErrorlog += "关税税率不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (CTools.GetTextBoxLength(txtHsName.Text) > txtHsName.MaxLength)
            {
                txtHsName.Text = CTools.textSpilt(txtHsName.Text, txtHsName.MaxLength);
            }
            return true;
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

            if (txtTaxRate.Focused )
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

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtHsCode.Focused)
                { }
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

        #endregion 

        private void txtHsCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtHsCode.Text.Trim()))
            {
                BaseHsCodeTable HsCode = new BaseHsCodeTable();
                HsCode = bHsCode.GetModel(txtHsCode.Text);
                if (HsCode != null)
                {
                    txtHsCode.Focus();
                    txtHsCode.Text = "";
                    MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        
    }
}
