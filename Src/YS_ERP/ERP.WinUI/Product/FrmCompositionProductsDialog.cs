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

namespace CZZD.ERP.WinUI.Master
{
    public partial class FrmCompositionProductsDialog : Form
    {
        private BCompositionProducts bCompositionProducts = new BCompositionProducts();
        private BaseUserTable _userInfo;
        private BaseCompositionProductsTable _currentCompositionProductsTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseCompositionProductsTable CurrentCompositionProductsTable
        {
            get { return _currentCompositionProductsTable; }
            set { _currentCompositionProductsTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmCompositionProductsDialog()
        {
            InitializeComponent();
        }

        private void FrmCompositionProductsDialog_Load(object sender, EventArgs e)
        {
            if (_currentCompositionProductsTable != null)
            {
                txtCode.Text = _currentCompositionProductsTable.CODE;
                txtName.Text = _currentCompositionProductsTable.NAME;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentCompositionProductsTable == null)
                {
                    _currentCompositionProductsTable = new BaseCompositionProductsTable();
                }
                _currentCompositionProductsTable.CODE = txtCode.Text.Trim();
                _currentCompositionProductsTable.NAME = txtName.Text.Trim();
                _currentCompositionProductsTable.COMPANY_CODE = _userInfo.COMPANY_CODE;
                _currentCompositionProductsTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bCompositionProducts.Exists(txtCode.Text.Trim()))
                    {
                        bCompositionProducts.Update(_currentCompositionProductsTable);
                    }
                    else
                    {
                        _currentCompositionProductsTable.CREATE_USER = _userInfo.CODE;
                        bCompositionProducts.Add(_currentCompositionProductsTable);
                    }
                }
                catch (Exception ex)
                {
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
                strErrorlog += "编号不能为空!\r\n";

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
                strErrorlog += "名称不能为空!\r\n";

            if (strErrorlog != null)
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
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FrmCompositionProductsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtName.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
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
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                if (btnCancel.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            BaseCompositionProductsTable CompositionProductsCode = new BaseCompositionProductsTable();
            CompositionProductsCode = bCompositionProducts.GetModel(txtCode.Text);
            if (CompositionProductsCode != null)
            {
                txtCode.Focus();
                txtCode.Text = "";
                MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
