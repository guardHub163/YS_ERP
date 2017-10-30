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
using CZZD.ERP.WinUI;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmUserDialog : Form
    {
        private BUser bUser = new BUser();
        private BaseUserTable _userInfo;
        private BaseUserTable _currentUserTable = null;
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
        public BaseUserTable CurrentUserTable
        {
            get { return _currentUserTable; }
            set { _currentUserTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmUserDialog()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Load
        /// </summary>
        private void FrmUserDialog_Load(object sender, EventArgs e)
        {
            DataTable dtLevel = CCacheData.LEVEL.Copy();
            cboLevel.ValueMember = "CODE";
            cboLevel.DisplayMember = "NAME";
            cboLevel.DataSource = dtLevel;

            if (_currentUserTable != null)
            {
                txtCode.Text = _currentUserTable.CODE.Substring(2);
                txtName.Text = _currentUserTable.NAME;
                txtPassword.Text = DESEncrypt.Decrypt(_currentUserTable.PASSWORD);
                txtRePassword.Text = txtPassword.Text;
                txtPhone.Text = _currentUserTable.PHONE;
                txtEmail.Text = _currentUserTable.EMAIL;
                txtDepartmentCode.Text = _currentUserTable.DEPARTMENT_CODE;
                txtDepartmentName.Text = _currentUserTable.DEPARTMENT_NAME;
                txtCompanyCode.Text = _currentUserTable.COMPANY_CODE;
                txtCompanyName.Text = _currentUserTable.COMPANY_NAME;
                txtRolesCode.Text = _currentUserTable.ROLES_CODE;
                txtRolesName.Text = bCommon.GetBaseMaster("ROLES", _currentUserTable.ROLES_CODE).Name;
                this.cboLevel.SelectedValue = _currentUserTable.LEVEL;

                if (_currentUserTable.OUT_COMMUNITY_DATE != null)
                {
                    txtOutCommunityDate.Checked = true;
                    txtOutCommunityDate.Text = string.Format("{0:d}", _currentUserTable.OUT_COMMUNITY_DATE);
                }
                else
                {
                    txtOutCommunityDate.Checked = false;
                }
                if (_currentUserTable.INT_COMMUNITY_DATE != null)
                {
                    txtIntCommunityDate.Checked = true;
                    txtIntCommunityDate.Text = string.Format("{0:d}", _currentUserTable.INT_COMMUNITY_DATE);
                }
                else
                {
                    txtIntCommunityDate.Checked = false;
                }
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
                txtCompanyCode.Enabled = false;
                btnCompany.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCode.Text = "";
                txtPassword.Text = "";
                txtRePassword.Text = "";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }

            if (_currentUserTable == null)
            {
                _currentUserTable = new BaseUserTable();
            }

            _currentUserTable.CODE = (txtCompanyCode.Text.Trim() + txtCode.Text.Trim());
            _currentUserTable.NAME = txtName.Text.Trim();
            _currentUserTable.PASSWORD = DESEncrypt.Encrypt(txtPassword.Text.Trim());
            _currentUserTable.PHONE = txtPhone.Text.Trim();
            _currentUserTable.EMAIL = txtEmail.Text.Trim();
            _currentUserTable.DEPARTMENT_CODE = txtDepartmentCode.Text.Trim();
            _currentUserTable.COMPANY_CODE = txtCompanyCode.Text.Trim();
            _currentUserTable.ROLES_CODE = txtRolesCode.Text.Trim();
            //_currentUserTable.PHOTO = GetImageToByte(txtPhoto.Text);
            _currentUserTable.PHOTO = null;
            _currentUserTable.LAST_UPDATE_USER = _userInfo.CODE;
            _currentUserTable.LEVEL = CConvert.ToInt32(cboLevel.SelectedValue.ToString());
            if (txtIntCommunityDate.Checked == true)
            {
                _currentUserTable.INT_COMMUNITY_DATE = CConvert.ToDateTime(txtIntCommunityDate.Text.Trim());
            }
            else
            {
                _currentUserTable.INT_COMMUNITY_DATE = null;
            }
            if (txtOutCommunityDate.Checked == true)
            {
                _currentUserTable.OUT_COMMUNITY_DATE = CConvert.ToDateTime(txtOutCommunityDate.Text.Trim());
            }
            else
            {
                _currentUserTable.OUT_COMMUNITY_DATE = null;
            }
            try
            {
                if (bUser.Exists(_currentUserTable.CODE, _currentUserTable.COMPANY_CODE))
                {
                    bUser.Update(_currentUserTable);
                }
                else
                {
                    _currentUserTable.CREATE_USER = _userInfo.CODE;
                    bUser.Add(_currentUserTable);
                }
            }
            catch (Exception ex)
            {
                //log.error
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            result = DialogResult.OK;
            this.Close();

        }

        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = null;
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                strErrorlog += "用户编号不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                strErrorlog += "用户名称不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                strErrorlog += "用户密码不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(txtRePassword.Text.Trim()))
            {
                strErrorlog += "用户确认密码不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(txtCompanyCode.Text.Trim()))
            {
                strErrorlog += "公司编号不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(txtDepartmentCode.Text.Trim()))
            {
                strErrorlog += "部门编号不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(txtRolesCode.Text.Trim()))
            {
                strErrorlog += "角色不能为空!\r\n";
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

        /// <summary>
        /// 
        /// </summary>
        private void FrmUserDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        #region 部门
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DEPARTMENT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDepartmentCode.Text = frm.BaseMasterTable.Code;
                    txtDepartmentName.Text = frm.BaseMasterTable.Name;
                    txtCompanyCode.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtDepartmentCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtDepartmentCode.Text.Trim()))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DEPARTMENT", this.txtDepartmentCode.Text.Trim(), "");
                if (baseMaster != null)
                {
                    txtDepartmentCode.Text = baseMaster.Code;
                    txtDepartmentName.Text = baseMaster.Name;
                }
                else
                {
                    txtDepartmentCode.Focus();
                    txtDepartmentCode.Text = "";
                    txtDepartmentName.Text = "";
                    MessageBox.Show("部门编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                txtDepartmentName.Text = "";
            }
        }
        #endregion

        #region 公司
        private void btnCompany_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("COMPANY", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCompanyCode.Text = frm.BaseMasterTable.Code;
                    txtCompanyName.Text = frm.BaseMasterTable.Name;
                    txtCompanyCode.Focus();
                    txtRolesCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtCompanyCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCompanyCode.Text.Trim()))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("COMPANY", this.txtCompanyCode.Text.Trim(), "");
                if (baseMaster != null)
                {
                    txtCompanyCode.Text = baseMaster.Code;
                    txtCompanyName.Text = baseMaster.Name;
                }
                else
                {
                    txtCompanyCode.Focus();
                    txtCompanyCode.Text = "";
                    txtCompanyName.Text = "";
                    MessageBox.Show("公司编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                txtCompanyName.Text = "";
            }

            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtCompanyCode.Text.Trim()))
            {
                BaseUserTable UserCode = new BaseUserTable();
                UserCode = bUser.GetModel((txtCompanyCode.Text + txtCode.Text), txtCompanyCode.Text);
                if (UserCode != null)
                {
                    txtCode.Focus();
                    txtCode.Text = "";
                    txtCompanyCode.Text = "";
                    txtCompanyName.Text = "";
                    MessageBox.Show("用户已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region 角色
        private void btnRoles_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("ROLES", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtRolesCode.Text = frm.BaseMasterTable.Code;
                    txtRolesName.Text = frm.BaseMasterTable.Name;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtRolesCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtRolesCode.Text.Trim()))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("ROLES", this.txtRolesCode.Text.Trim(), "");
                if (baseMaster != null)
                {
                    txtRolesCode.Text = baseMaster.Code;
                    txtRolesName.Text = baseMaster.Name;
                }
                else
                {
                    txtRolesCode.Focus();
                    txtRolesCode.Text = "";
                    txtRolesName.Text = "";
                    MessageBox.Show("角色不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                txtRolesName.Text = "";
            }
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

        private void FrmUserDialog_Shown(object sender, EventArgs e)
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

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtCompanyCode.Text.Trim()))
            {
                BaseUserTable UserCode = new BaseUserTable();
                UserCode = bUser.GetModel((txtCompanyCode.Text + txtCode.Text), txtCompanyCode.Text);
                if (UserCode != null)
                {
                    txtCode.Text = "";
                    txtCompanyCode.Text = "";
                    txtCompanyName.Text = "";
                    txtCode.Focus();
                    MessageBox.Show("用户已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtRePassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtRePassword.Text)
            {
                txtPassword.Focus();
                txtPassword.Text = "";
                txtRePassword.Text = "";
                string strErrorlog = "密码与确认密码必须一致，请重新输入！!";
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region 按键
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtRolesCode.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }

            if (txtPhone.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)45)
                {
                    e.Handled = true;
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
                if (btnRoles.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }
        #endregion
    }//end class
}
