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
    public partial class FrmProductPartsDialog : Form
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        private int _mode = 1;
        private BaseUserTable _userInfo;
        private BaseProductPartsTable _currentProductPartsTable = null;
        private DialogResult result = DialogResult.Cancel;

        private BProductParts bProductParts = new BProductParts();
        private BCommon bCommon = new BCommon();
        private BProduct bProduct = new BProduct();

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
        public BaseProductPartsTable CurrentProductPartsTable
        {
            get { return _currentProductPartsTable; }
            set { _currentProductPartsTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmProductPartsDialog()
        {
            InitializeComponent();
        }

        public FrmProductPartsDialog(BaseUserTable user)
        {
            InitializeComponent();
            _userInfo = user;
        }

        private void FrmProductPartsDialog_Load(object sender, EventArgs e)
        {
            if (_currentProductPartsTable != null)
            {
                txtProductCode.Text = _currentProductPartsTable.PRODUCT_CODE;
                txtProductName.Text = _currentProductPartsTable.PRODUCT_NAME;
                txtPartsCode.Text = _currentProductPartsTable.PRODUCT_PARTS_CODE;
                txtPartsName.Text = _currentProductPartsTable.PRODUCT_PARTS_NAME;
                txtQuantity.Text = CConvert.ToString(_currentProductPartsTable.QUANTITY);
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
                btnSaveAndNew.Visible = true;
            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtProductCode.BackColor = Color.WhiteSmoke;
                txtPartsCode.BackColor = Color.WhiteSmoke;
                txtProductCode.Enabled = false;
                txtPartsCode.Enabled = false;
                btnProduct.Enabled = false;
                btnParts.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtProductCode.BackColor = Color.WhiteSmoke;
                txtProductCode.Enabled = false;
                btnProduct.Enabled = false;
                txtPartsCode.Text = "";
                txtPartsName.Text = "";
            }
        }

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                //判断编号是否已存在
                if (_mode != CConstant.MODE_MODIFY && !string.IsNullOrEmpty(this.txtProductCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtPartsCode.Text.Trim()))
                {
                    if (bProductParts.Exists(txtProductCode.Text.Trim(), txtPartsCode.Text.Trim()))
                    {
                        MessageBox.Show("自制件和原料的组合已存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPartsCode.Text = "";
                        txtPartsName.Text = "";
                        txtPartsCode.Focus();
                        return;
                    }
                }

                if (_currentProductPartsTable == null)
                {
                    _currentProductPartsTable = new BaseProductPartsTable();
                }

                _currentProductPartsTable.PRODUCT_CODE = txtProductCode.Text.Trim();
                _currentProductPartsTable.PRODUCT_PARTS_CODE = txtPartsCode.Text.Trim();
                _currentProductPartsTable.QUANTITY = Convert.ToDecimal(txtQuantity.Text.Trim());
                _currentProductPartsTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    bool ret = false;
                    if (bProductParts.Exists(txtProductCode.Text.Trim(), txtPartsCode.Text.Trim()))
                    {
                        ret = bProductParts.Update(_currentProductPartsTable);
                    }
                    else
                    {
                        _currentProductPartsTable.CREATE_USER = _userInfo.CODE;
                        ret = bProductParts.Add(_currentProductPartsTable);
                    }
                    if (ret)
                    {
                        result = DialogResult.OK;
                        if ("btnSaveAndNew".Equals(((Button)sender).Name))
                        {
                            ClearAll();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("保存失败，请重试或与系统管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败，请重试或与系统管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.Error("自制件构成保存失败。", ex);
                    return;
                }
            }
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断商品编号不能为空
            if (string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
            {
                strErrorlog += "自制件编号不能为空!\r\n";
            }

            //判断材料编号不能为空
            if (string.IsNullOrEmpty(this.txtPartsCode.Text.Trim()))
            {
                strErrorlog += "原料编号不能为空!\r\n";
            }

            if (strErrorlog != null )
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtQuantity.Text.Trim()))
                txtQuantity.Text = "1";

            return true;
        }
        #endregion

        #region 关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }
        #endregion
       
        private void FrmProductPartsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }


        #region 自制件
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", " PRODUCT_FLAG = "+CConstant.PRODUCT_FLAG_PRODUCE);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductCode.Text = frm.BaseMasterTable.Code;
                    txtProductName.Text = frm.BaseMasterTable.Name;
                    txtPartsCode.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            string product = txtProductCode.Text.Trim();
            if (!string.IsNullOrEmpty(product))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", product," PRODUCT_FLAG = "+CConstant.PRODUCT_FLAG_PRODUCE);
                if (baseMaster != null)
                {
                    txtProductCode.Text = baseMaster.Code;
                    txtProductName.Text = baseMaster.Name;
                    txtPartsCode.Focus();
                }
                else
                {
                    MessageBox.Show("自制件编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtProductCode.Focus();
                }
            }
            else
            {
                txtProductName.Text = "";
            }
        }
        #endregion

        #region 原料
        
        private void btnParts_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", " PRODUCT_FLAG = " + CConstant.PRODUCT_FLAG_PARTS);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtPartsCode.Text = frm.BaseMasterTable.Code;
                    txtPartsName.Text = frm.BaseMasterTable.Name;
                    txtQuantity.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtPartsCode_Leave(object sender, EventArgs e)
        {
            string part = txtPartsCode.Text.Trim();
            if (!string.IsNullOrEmpty(part))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", part, " PRODUCT_FLAG = " + CConstant.PRODUCT_FLAG_PARTS);
                if (baseMaster != null)
                {
                    txtPartsCode.Text = baseMaster.Code;
                    txtPartsName.Text = baseMaster.Name;
                    txtQuantity.Focus();
                }
                else
                {
                    MessageBox.Show("原料编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPartsCode.Text = "";
                    txtPartsName.Text = "";
                    txtPartsCode.Focus();
                }
            }
            else
            {
                txtPartsName.Text = "";
            }
        }
        #endregion

        #region 按键
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtProductCode.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtQuantity.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtQuantity.Focused)
                    btnSave.Focus();
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }

            if (txtQuantity.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                    e.Handled = true;
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
        #endregion

        private void ClearAll()
        {
            txtProductCode.Text = "";
            txtProductName.Text = "";
            txtPartsCode.Text = "";
            txtPartsName.Text = "";
            txtQuantity.Text = "";
        }

    }//end class
}
