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
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmDepartmentDialog : Form
    {
        private BDepartment bDepartment = new BDepartment(); 
        private BaseUserTable _userInfo;
        private BaseDepartmentTable _currentDepartmentTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
      

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseDepartmentTable CurrentDepartmentTable
        {
            get { return _currentDepartmentTable; }
            set { _currentDepartmentTable  = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        #region 页面初始化
        private void FrmDepartmentDialog_Load(object sender, EventArgs e)
        {
            if (_currentDepartmentTable != null)
            {

                txtCode.Text = _currentDepartmentTable.CODE;
                txtName.Text = _currentDepartmentTable.NAME;
                txtParentCode.Text = _currentDepartmentTable.PARENT_CODE;
                txtParentName.Text = _currentDepartmentTable.PARENT_NAME;
                txtCompanyCode.Text = _currentDepartmentTable.COMPANY_CODE;
                txtCompanyName.Text = _currentDepartmentTable.COMPANY_NAME;
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

        private void FrmDepartmentDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
                txtCode.Focus();
            else
                txtName.Focus();
        }

        public FrmDepartmentDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region 保存
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentDepartmentTable == null)
                {
                    _currentDepartmentTable = new BaseDepartmentTable();
                }
                _currentDepartmentTable.CODE = txtCode.Text.Trim();
                _currentDepartmentTable.NAME = txtName.Text.Trim();
                _currentDepartmentTable.PARENT_CODE = txtParentCode.Text.Trim();
                _currentDepartmentTable.COMPANY_CODE = txtCompanyCode.Text.Trim();
                _currentDepartmentTable.LAST_UPDATE_USER = _userInfo.CODE;
                try
                {
                    if (bDepartment.Exists(txtCode.Text.Trim()))
                        bDepartment.Update(_currentDepartmentTable);
                    else
                    {
                        _currentDepartmentTable.CREATE_USER = _userInfo.CODE;
                        bDepartment.Add(_currentDepartmentTable);
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
                strErrorlog += "编号不能为空!\r\n";

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
                strErrorlog += "名称不能为空!\r\n";

            if(strErrorlog != null )
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
        #endregion

        #region 取消/关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FrmCompanyDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }
        #endregion

        #region 公司
        private void btnCompany_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Company", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCompanyCode.Text = frm.BaseMasterTable.Code;
                    txtCompanyName.Text = frm.BaseMasterTable.Name;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtCompanyCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCompanyCode.Text.Trim()))
            {
                BaseCompanyTable Company = new BaseCompanyTable();
                BCompany bCompany = new BCompany();
                Company = bCompany.GetModel(this.txtCompanyCode.Text);
                if (Company == null || "".Equals(Company))
                {
                    txtCompanyCode.Focus();
                    txtCompanyCode.Text = "";
                    txtCompanyName.Text = "";
                    MessageBox.Show("公司编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtCompanyCode.Text = Company.CODE;
                    txtCompanyName.Text = Company.NAME;
                }
            }
            else
            {
                txtCompanyName.Text = "";
            }
        }
        #endregion

        #region 上级部门
        private void btnParent_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Department", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtParentCode.Text = frm.BaseMasterTable.Code;
                    txtParentName.Text = frm.BaseMasterTable.Name;
                    txtCompanyCode.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtParentCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtParentCode.Text.Trim()))
            {
                BaseDepartmentTable Parent = new BaseDepartmentTable();
                Parent = bDepartment.GetModel(this.txtParentCode.Text);
                if (Parent == null || "".Equals(Parent))
                {
                    txtParentCode.Focus();
                    txtParentCode.Text = "";
                    txtParentName.Text = "";
                    MessageBox.Show("上级编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtParentCode.Text = Parent.CODE;
                    txtParentName.Text = Parent.NAME;
                }
            }
            else
            {
                txtParentName.Text = "";
            }
        }
        #endregion

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            BaseDepartmentTable DepartmentCode = new BaseDepartmentTable();
            DepartmentCode = bDepartment.GetModel(txtCode.Text);
            if (DepartmentCode != null)
            {
                txtCode.Focus();
                txtCode.Text = "";
                MessageBox.Show("部门编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }        

        #region 按键
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if(txtCompanyCode.Focused)
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
                if (txtCode.Focused)
                {}
                else
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                if (btnCompany.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion
    }
}
