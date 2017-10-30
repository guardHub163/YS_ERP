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
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.CacheData;


namespace CZZD.ERP.WinUI
{
    public partial class FrmSlipTypeDialog : Form
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BaseUserTable _userInfo;
        private BaseSlipTypeTable _currentSlipTypeTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BSlipType bSlipType = new BSlipType();

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
        public BaseSlipTypeTable CurrentSlipTypeTable
        {
            get { return _currentSlipTypeTable; }
            set { _currentSlipTypeTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmSlipTypeDialog()
        {
            InitializeComponent();
        }

        private void FrmSlipTypeDialog_Load(object sender, EventArgs e)
        {
            if (_currentSlipTypeTable != null)
            {
                txtCode.Text = _currentSlipTypeTable.CODE;
                txtName.Text = _currentSlipTypeTable.NAME;
                txtenglishname.Text = _currentSlipTypeTable.ENGLISHNAME;
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
                if (_currentSlipTypeTable == null)
                {
                    _currentSlipTypeTable = new BaseSlipTypeTable();
                }
                _currentSlipTypeTable.CODE = txtCode.Text.Trim();
                _currentSlipTypeTable.NAME = txtName.Text.Trim();
                _currentSlipTypeTable.COMPANY_CODE = "01";
                _currentSlipTypeTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentSlipTypeTable.ENGLISHNAME = txtenglishname.Text.Trim();
                _currentSlipTypeTable.ATTRIBUTE1 = "";
                _currentSlipTypeTable.ATTRIBUTE2 = "";
                _currentSlipTypeTable.ATTRIBUTE3 = "";
                try
                {
                    if (bSlipType.Exists( txtCode.Text.Trim()))
                    {
                        bSlipType.Update(_currentSlipTypeTable);
                    }
                    else
                    {
                        _currentSlipTypeTable.CREATE_USER = _userInfo.CODE;
                        bSlipType.Add(_currentSlipTypeTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败,请重新输入!");
                    Logger.Error("订单类型保存失败!", ex);
                    return;
                }
                result = DialogResult.OK;
                this.Close();
                CCacheData.SlipType = null;
            }

        }

        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断材料编号不能为空
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                strErrorlog += "编号不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }
        
        private void FrmProductPartsDialog_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!(txtCode.Focused))
            {
                BaseSlipTypeTable SlipType = new BaseSlipTypeTable();
                SlipType = bSlipType.GetModel(txtCode.Text);
                if (SlipType != null)
                {
                    txtCode.Text = "";
                    MessageBox.Show("类型编号和订单编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void FrmSlipTypeDialog_Shown(object sender, EventArgs e)
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

        private void FrmSlipTypeDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }        
    }
}
