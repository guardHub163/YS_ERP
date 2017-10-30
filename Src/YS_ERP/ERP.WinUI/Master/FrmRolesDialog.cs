using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;

namespace CZZD.ERP.WinUI
{
    public partial class FrmRolesDialog : Form
    {
        private BRoles bRoles = new BRoles();
        private BaseUserTable _userInfo;
        private BaseRolesTable _currentRolesTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseRolesTable CurrentRolesTable
        {
            get { return _currentRolesTable; }
            set { _currentRolesTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmRolesDialog()
        {
            InitializeComponent();
        }

        private void FrmRolesDialog_Load(object sender, EventArgs e)
        {
            if (_currentRolesTable != null)
            {
                txtCode.Text = _currentRolesTable.CODE;
                txtName.Text = _currentRolesTable.NAME;
                txtMemo.Text = _currentRolesTable.MEMO;
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
                if (_currentRolesTable == null)
                {
                    _currentRolesTable = new BaseRolesTable();
                }
                _currentRolesTable.CODE = txtCode.Text.Trim();
                _currentRolesTable.NAME = txtName.Text.Trim();
                _currentRolesTable.MEMO = txtMemo.Text.Trim();
                _currentRolesTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bRoles.Exists(txtCode.Text.Trim()))
                        bRoles.Update(_currentRolesTable);
                    else
                    {
                        _currentRolesTable.CREATE_USER = _userInfo.CODE;
                        bRoles.Add(_currentRolesTable);
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

        /// <summary>
        /// 取消/关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FrmCompanyDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void FrmDepartmentDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
                txtCode.Focus();
            else
                txtName.Focus();
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
            BaseRolesTable RolesCode = new BaseRolesTable();
            RolesCode = bRoles.GetModel(txtCode.Text);
            if (RolesCode != null)
            {
                txtCode.Focus();
                txtCode.Text = "";
                MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
