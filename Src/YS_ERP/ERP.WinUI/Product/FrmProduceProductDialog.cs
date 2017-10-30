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
    public partial class FrmProduceProductDialog : Form
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BaseUserTable _userInfo;
        private BProduct bProduct = new BProduct();
        private int _mode;
        private BaseProductTable _currentProductTable = null;
        private DialogResult result = DialogResult.Cancel;

        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseProductTable CurrentProductTable
        {
            get { return _currentProductTable; }
            set { _currentProductTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmProduceProductDialog()
        {
            InitializeComponent();
        }

        public FrmProduceProductDialog(BaseUserTable user)
        {
            InitializeComponent();
            _userInfo = user;
        }

        /// <summary>
        /// Load
        /// </summary>
        private void FrmproductDialog_Load(object sender, EventArgs e)
        {
            if (_currentProductTable != null)
            {
                txtCode.Text = _currentProductTable.CODE;
                txtName.Text = _currentProductTable.NAME;
                txtSpec.Text = _currentProductTable.SPEC;
                txtUnitCode.Text = _currentProductTable.BASIC_UNIT_CODE;
                txtUnitName.Text = _currentProductTable.BASIC_UNIT_NAME;
            }

            txtCode.Focus();
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCode.Enabled = false;
                txtName.Focus();
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCode.Text = "";
            }

        }

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentProductTable == null)
                {
                    _currentProductTable = new BaseProductTable();
                }
                _currentProductTable.CODE = txtCode.Text.Trim();
                _currentProductTable.NAME = txtName.Text.Trim();
                _currentProductTable.SPEC = txtSpec.Text.Trim();
                _currentProductTable.BASIC_UNIT_CODE = txtUnitCode.Text.Trim();
                _currentProductTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentProductTable.PRODUCT_FLAG = CConstant.PRODUCT_FLAG_PRODUCE;

                try
                {
                    bool ret = false;
                    if (bProduct.Exists(txtCode.Text.Trim()))
                        ret = bProduct.Update(_currentProductTable);
                    else
                    {
                        _currentProductTable.CREATE_USER = _userInfo.CODE;
                        ret = bProduct.Add(_currentProductTable);
                    }
                    if (ret)
                    {
                        result = DialogResult.OK;
                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show("保存失败，请重试或与系统管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败，请重试或与系统管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.Error("自制件保存失败。", ex);
                }
            }
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = "";
            //判断编号不能为空
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                strErrorlog += "自制件编号不能为空。\r\n";
            }
            //判断编号是否已存在
            else if (_mode != CConstant.MODE_MODIFY && bProduct.Exists(txtCode.Text.Trim()))
            {
                strErrorlog += "自制件编号已存在。\r\n";
            }

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                strErrorlog += "自制件名称不能为空。\r\n";
            }

            if (string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()))
            {
                strErrorlog += "单位不能为空!\r\n";
            }

            if (strErrorlog.Length > 0)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion

        #region 取消/关闭
        /// <summary>
        /// 
        /// </sum取消/关闭mary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 状态返回
        /// </summary>
        private void FrmUserDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }
        #endregion


        #region 按键
        /// <summary>
        /// 
        /// </summary>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }
        }
        #endregion

        #region 单位
        /// <summary>
        /// 
        /// </summary>
        private void btnUnit_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Unit", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtUnitCode.Text = frm.BaseMasterTable.Code;
                    txtUnitName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        private void txtUnitCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()))
            {
                BaseUnitTable Unit = new BaseUnitTable();
                BUnit bUnit = new BUnit();
                Unit = bUnit.GetModel(this.txtUnitCode.Text);
                if (Unit == null || "".Equals(Unit))
                {
                    txtUnitCode.Focus();
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";
                    MessageBox.Show("单位不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtUnitName.Text = Unit.NAME;
                }
            }
            else
            {
                txtUnitCode.Text = "";
                txtUnitName.Text = "";
            }
        }
        #endregion

    }//end class
}
