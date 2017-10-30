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
using CZZD.ERP.Model.Master;

namespace CZZD.ERP.WinUI
{
    public partial class FrmBankDialog : Form
    {
        private BBank bBank = new BBank();
        private BaseUserTable _userInfo;
        private BaseBankTable _currentBankTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseBankTable CurrentBankTable
        {
            get { return _currentBankTable; }
            set { _currentBankTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        #region 页面初始化
        private void FrmBankDialog_Load(object sender, EventArgs e)
        {
            if (_currentBankTable != null)
            {
                txtId.Text = _currentBankTable.ID;
                txtCode.Text = _currentBankTable.COMPANY_CODE;
                txtName.Text = _currentBankTable.COMPANY_NAME;
                txtBankName.Text = _currentBankTable.BANK_NAME;
                txtFullNameEn.Text = _currentBankTable.FULL_NAME_EN;
                txtFullNameCn.Text = _currentBankTable.FULL_NAME_CN;
                rtxtDetialEn.Text = _currentBankTable.DETAIL_EN;
                rtxtDetialCn.Text = _currentBankTable.DETAIL_CN;
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCode.BackColor = Color.WhiteSmoke;
                txtId.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtId.Text = "";
            }
        }
        public FrmBankDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentBankTable == null)
                {
                    _currentBankTable = new BaseBankTable();
                }
                _currentBankTable.ID = txtId.Text.Trim();
                _currentBankTable.COMPANY_CODE = txtCode.Text.Trim();
                _currentBankTable.BANK_NAME = txtBankName.Text.Trim();
                _currentBankTable.FULL_NAME_CN = txtFullNameCn.Text.Trim();
                _currentBankTable.FULL_NAME_EN = txtFullNameEn.Text.Trim();
                _currentBankTable.DETAIL_CN = rtxtDetialCn.Text;
                _currentBankTable.DETAIL_EN = rtxtDetialEn.Text;
                _currentBankTable.LAST_UPDATE_USER = _userInfo.CODE;
                try
                {
                    if (bBank.Exists(txtId.Text.Trim()))
                        bBank.Update(_currentBankTable);
                    else
                    {
                        _currentBankTable.CREATE_USER = _userInfo.CODE;
                        bBank.Add(_currentBankTable);
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

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
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
                    txtCode.Text = frm.BaseMasterTable.Code;
                    txtName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        #endregion



        private void FrmBankDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtId.Focus();
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                BaseCompanyTable Company = new BaseCompanyTable();
                BCompany bCompany = new BCompany();
                Company = bCompany.GetModel(this.txtCode.Text);
                if (Company == null || "".Equals(Company))
                {
                    txtCode.Focus();
                    txtCode.Text = "";

                    MessageBox.Show("公司编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtCode.Text = Company.CODE;
                    txtName.Text = Company.NAME;
                }
            }
        }

        private void btnCompany_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }

        private void btnCompany_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void FrmBankDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtId.Text.Trim()))
            {
                BaseBankTable bankCode = new BaseBankTable();
                bankCode = bBank.GetModel(txtId.Text.Trim());
                if (bankCode != null)
                {
                    txtId.Focus();
                    txtId.Text = "";
                    MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }
    }
}
