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
    public partial class FrmUnitDialog : Form
    {

        private BaseUserTable _userInfo;
        private BaseUnitTable _currentUnitTable = null;
        private int _mode;
        private BUnit bUnit = new BUnit();
        private DialogResult result = DialogResult.Cancel;
     

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseUnitTable CurrentUnitTable
        {
            get { return _currentUnitTable; }
            set { _currentUnitTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmUnitDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentUnitTable == null)
                {
                    _currentUnitTable = new BaseUnitTable();
                }

                _currentUnitTable.CODE = txtCode.Text.Trim();
                _currentUnitTable.NAME = txtName.Text.Trim();
                _currentUnitTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bUnit.Exists(txtCode.Text.Trim()))
                    {
                        bUnit.Update(_currentUnitTable);
                    }
                    else
                    {
                        _currentUnitTable.CREATE_USER = _userInfo.CODE;
                        bUnit.Add(_currentUnitTable);
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

            return true;
        }


        private void FrmUnitDialog_Load(object sender, EventArgs e)
        {

            if (_currentUnitTable != null)
            {

                txtCode.Text = _currentUnitTable.CODE;
                txtName.Text = _currentUnitTable.NAME;
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

        private void FrmUserDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void FrmUnitDialog_Shown(object sender, EventArgs e)
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

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                BaseUnitTable UnitCode = new BaseUnitTable();
                UnitCode = bUnit.GetModel(txtCode.Text);
                if (UnitCode != null)
                {
                    txtCode.Focus();
                    txtCode.Text = "";
                    MessageBox.Show("单位编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
