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
using CZZD.ERP.CacheData;


namespace CZZD.ERP.WinUI
{
    public partial class FrmReasonDialog : Form
    {

        private BReason bReason = new BReason();
        private BaseUserTable _userInfo;
        private BaseReasonTable _currentReasonTable = null;
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
        public BaseReasonTable CurrentReasonTable
        {
            get { return _currentReasonTable; }
            set { _currentReasonTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmReasonDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        private void FrmReasonDialog_Load(object sender, EventArgs e)
        {
            if (_currentReasonTable != null)
            {

                txtCode.Text = _currentReasonTable.CODE;
                txtName.Text = _currentReasonTable.NAME;
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
                if (_currentReasonTable == null)
                {
                    _currentReasonTable = new BaseReasonTable();
                }
                _currentReasonTable.CODE = txtCode.Text.Trim();
                _currentReasonTable.NAME = txtName.Text.Trim();
                _currentReasonTable.COMPANY_CODE = _userInfo.COMPANY_CODE;
                _currentReasonTable.LAST_UPDATE_USER = _userInfo.CODE;
                try
                {
                    if (bReason.Exists(txtCode.Text.Trim()))
                    {
                        bReason.Update(_currentReasonTable);
                    }
                    else
                    {
                        _currentReasonTable.CREATE_USER = _userInfo.CODE;
                        bReason.Add(_currentReasonTable);
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
                CCacheData.Reason = null;
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
                strErrorlog += "名称不能为空\r\n";
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
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FrmUserDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void FrmLocationDialog_Shown(object sender, EventArgs e)
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
                //System.Windows.Forms.SendKeys.Send("{Tab}");
                ProcessTabKey(true);
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                BaseReasonTable ReasonCode = new BaseReasonTable();
                ReasonCode = bReason.GetModel(txtCode.Text);
                if (ReasonCode != null)
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
