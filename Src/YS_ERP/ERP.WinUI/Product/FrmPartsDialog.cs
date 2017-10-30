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
    public partial class FrmPartsDialog : Form
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private int _mode;
        private BaseUserTable _userInfo;
        private DialogResult result = DialogResult.Cancel;
        private BaseProductTable _currentProductTable = null;

        private BProductGroup bProductGroup = new BProductGroup();
        private BProduct bProduct = new BProduct();
        private BUnit bUnit = new BUnit();

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

        public FrmPartsDialog()
        {
            InitializeComponent();
        }

        public FrmPartsDialog(BaseUserTable user)
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
                txtGroupCode.Text = _currentProductTable.GROUP_CODE;
                txtGroupName.Text = _currentProductTable.GROUP_NAME;
                txtUnitCode.Text = _currentProductTable.BASIC_UNIT_CODE;
                txtUnitName.Text = _currentProductTable.BASIC_UNIT_NAME;
                txtPrice.Text = _currentProductTable.SALES_PRICE.ToString();
                txtPurchase_Price.Text = _currentProductTable.PURCHASE_PRICE.ToString();
                txtSafetyStock.Text = _currentProductTable.SAFETY_STOCK.ToString();
            }

            txtCode.Focus();
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
                btnSaveAndNew.Visible = true;
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
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                _currentProductTable.GROUP_CODE = txtGroupCode.Text.Trim();
                _currentProductTable.BASIC_UNIT_CODE = txtUnitCode.Text.Trim();
                _currentProductTable.SALES_PRICE = Convert.ToDecimal(txtPrice.Text.Trim());
                _currentProductTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentProductTable.PURCHASE_PRICE = CConvert.ToDecimal(txtPurchase_Price.Text.Trim());
                _currentProductTable.SELL_LOCATION = CConstant.PRODUCT_SELL_CHINA;
                _currentProductTable.PACKAGE_MODE = CConstant.PRODUCT_PACKAGE_ALONT;
                _currentProductTable.SAFETY_STOCK = CConvert.ToDecimal(txtSafetyStock.Text.Trim());
                _currentProductTable.PRODUCT_FLAG = CConstant.PRODUCT_FLAG_PARTS;

                try
                {
                    bool ret = false;
                    if (bProduct.Exists(txtCode.Text.Trim()))
                    {
                        ret = bProduct.Update(_currentProductTable);
                    }
                    else
                    {
                        _currentProductTable.CREATE_USER = _userInfo.CODE;
                        ret = bProduct.Add(_currentProductTable);
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
                    Logger.Error("原料保存失败。", ex);
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
            //判断编号不能为空
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                strErrorlog += "原料编号不能为空!\r\n";
            }
            //判断编号是否已存在
            else if (_mode != CConstant.MODE_MODIFY && bProduct.Exists(txtCode.Text.Trim()))
            {
                strErrorlog += "原料编号已存在。\r\n";
            }

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                strErrorlog += "原料名称不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()))
            {
                strErrorlog += "基本单位不能为空!\r\n";
            }

            //判断类别不能为空
            if (string.IsNullOrEmpty(this.txtGroupCode.Text.Trim()))
            {
                strErrorlog += "种类编号不能为空!\r\n";
            }

            //判断安全在库数不能为空
            if (string.IsNullOrEmpty(this.txtSafetyStock.Text.Trim()))
            {
                strErrorlog += "安全在库数不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtPrice.Text == null || "".Equals(txtPrice.Text))
            {
                txtPrice.Text = "0";
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
            if (MessageBox.Show("确定取消吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
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
        #endregion

        #region 商品分类
        private void btnGroupCode_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT_GROUP", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtGroupCode.Text = frm.BaseMasterTable.Code;
                    txtGroupName.Text = frm.BaseMasterTable.Name;
                    txtUnitCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtGroupCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtGroupCode.Text.Trim()))
            {

                BaseProductGroupTable productGroup = bProductGroup.GetModel(this.txtGroupCode.Text);
                if (productGroup != null)
                {
                    txtGroupName.Text = productGroup.NAME;

                }
                else
                {
                    txtGroupCode.Text = "";
                    txtGroupName.Text = "";
                    MessageBox.Show("种类不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGroupCode.Focus();
                }
            }
            else
            {
                txtGroupCode.Text = "";
                txtGroupName.Text = "";
            }
        }
        #endregion

        #region 单位
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

        #region 按键
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtPurchase_Price.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }

            if (txtPrice.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            }
            else if (txtPurchase_Price.Focused)
            {
                if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    e.Handled = true;
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
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                BaseProductTable ProductCode = new BaseProductTable();
                ProductCode = bProduct.GetModel(txtCode.Text);
                if (ProductCode != null)
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
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion


        /// <summary>
        /// 清空数据
        /// </summary>
        private void ClearAll()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtSpec.Text = "";
            txtGroupCode.Text = "";
            txtGroupName.Text = "";
            txtUnitCode.Text = "";
            txtUnitName.Text = "";
            txtPrice.Text = "";
            txtPurchase_Price.Text = "";
            txtSafetyStock.Text = "";
        }


    }//end class
}
