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
using System.IO;

namespace CZZD.ERP.WinUI
{
    public partial class FrmCompanyDialog : Form
    {
        private BCompany bCompany = new BCompany();
        private BaseUserTable _userInfo;
        private BaseCompanyTable _currentCompanyTable = null;
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
        public BaseCompanyTable CurrentCompanyTable
        {
            get { return _currentCompanyTable; }
            set { _currentCompanyTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmCompanyDialog()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog = new OpenFileDialog();
        /// <summary>
        /// Load
        /// </summary>
        private void FrmCompanyDialog_Load(object sender, EventArgs e)
        {
            if (_currentCompanyTable != null)
            {

                txtCode.Text = _currentCompanyTable.CODE;
                txtName.Text = _currentCompanyTable.NAME;
                txtNameShort.Text = _currentCompanyTable.NAME_SHORT;
                txtEnglishName.Text = _currentCompanyTable.NAME_ENGLISH;
                txtZipCode.Text = _currentCompanyTable.ZIP_CODE;
                txtAddressFirst.Text = _currentCompanyTable.ADDRESS_FIRST;
                txtAddressMiddle.Text = _currentCompanyTable.ADDRESS_MIDDLE;
                txtAddressLast.Text = _currentCompanyTable.ADDRESS_LAST;
                txtPhone.Text = _currentCompanyTable.PHONE_NUMBER;
                txtFax.Text = _currentCompanyTable.FAX_NUMBER;
                txtEmail.Text = _currentCompanyTable.EMAIL;
                txtURL.Text = _currentCompanyTable.URL;
                txtMemo.Text = _currentCompanyTable.MEMO;
                MemoryStream LOGO = new MemoryStream(_currentCompanyTable.LOGO);
                picLogo.Image = Image.FromStream(LOGO);
                
                MemoryStream COMPANY_PICTURE = new MemoryStream(_currentCompanyTable.COMPANY_PICTURE);
                picCompany.Image = Image.FromStream(COMPANY_PICTURE);

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

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentCompanyTable == null)
                {
                    _currentCompanyTable = new BaseCompanyTable();
                }
                _currentCompanyTable.CODE = txtCode.Text.Trim().PadLeft(2, '0');
                _currentCompanyTable.NAME = txtName.Text.Trim();
                _currentCompanyTable.NAME_SHORT = txtNameShort.Text.Trim();
                _currentCompanyTable.NAME_ENGLISH = txtEnglishName.Text.Trim();
                _currentCompanyTable.ZIP_CODE = txtZipCode.Text.Trim();
                _currentCompanyTable.ADDRESS_FIRST = txtAddressFirst.Text.Trim();
                _currentCompanyTable.ADDRESS_MIDDLE = txtAddressMiddle.Text.Trim();
                _currentCompanyTable.ADDRESS_LAST = txtAddressLast.Text.Trim();
                _currentCompanyTable.PHONE_NUMBER = txtPhone.Text.Trim();
                _currentCompanyTable.FAX_NUMBER = txtFax.Text.Trim();
                _currentCompanyTable.EMAIL = txtEmail.Text.Trim();
                _currentCompanyTable.URL = txtURL.Text.Trim();
                _currentCompanyTable.MEMO = txtMemo.Text.Trim();
                _currentCompanyTable.LAST_UPDATE_USER = _userInfo.CODE;
                if (txtLogo.Text.ToString() != "")
                {
                    string[] sArray = Regex.Split(txtLogo.Text.Trim(), @"\\", RegexOptions.IgnoreCase);
                    System.IO.FileStream fs = new System.IO.FileStream(txtLogo.Text.Trim(),FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    byte[] imgByte = new byte[fs.Length];
                    fs.Read(imgByte, 0, (int)fs.Length);
                    _currentCompanyTable.LOGO = imgByte;

                }
                if (txtCompanyPicture.Text.ToString() != "")
                {
                    string[] sArray = Regex.Split(txtCompanyPicture.Text.Trim(), @"\\", RegexOptions.IgnoreCase);
                    System.IO.FileStream fs = new System.IO.FileStream(txtCompanyPicture.Text.Trim(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    byte[] imgByte = new byte[fs.Length];
                    fs.Read(imgByte, 0, (int)fs.Length);
                    _currentCompanyTable.COMPANY_PICTURE = imgByte;
                }
                try
                {
                    if (bCompany.Exists(txtCode.Text.Trim()))
                    {
                        bCompany.Update(_currentCompanyTable);
                    }
                    else
                    {
                        _currentCompanyTable.CREATE_USER = _userInfo.CODE;
                        bCompany.Add(_currentCompanyTable);
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
                CCacheData.Company = null;
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

            return true;
        }
        #endregion

        #region 关闭
        /// <summary>
        /// 取消/关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
        #endregion

        private void FrmCompanyDialog_Shown(object sender, EventArgs e)
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
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }

            if (txtPhone.Focused || txtFax.Focused)
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
                if (txtCode.Text.Trim().Length < 2)
                {
                    txtCode.Text = txtCode.Text.Trim().PadLeft(2, '0');
                }
                BaseCompanyTable CompanyCode = new BaseCompanyTable();
                CompanyCode = bCompany.GetModel(txtCode.Text.Trim());
                if (CompanyCode != null)
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
            //MessageBox.Show(e.KeyValue.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private void btnLogo_Click(object sender, EventArgs e)
        {
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtLogo.Text = openFileDialog.FileName;
                picLogo.ImageLocation = txtLogo.Text;
            }
        }

        private void btnCompanyPicture_Click(object sender, EventArgs e)
        {
            //openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtCompanyPicture.Text = openFileDialog.FileName;
                picCompany.ImageLocation = txtCompanyPicture.Text;
            }
        }
    }
}
