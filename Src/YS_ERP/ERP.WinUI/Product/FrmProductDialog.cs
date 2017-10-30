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
    public partial class FrmProductDialog : Form
    {
        private BaseUserTable _userInfo;
        private BProduct bProduct = new BProduct();
        private int _mode;
        private BaseProductTable _currentProductTable = null;
        private DialogResult result = DialogResult.Cancel;
        private BCommon bCommon = new BCommon();

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

        public FrmProductDialog()
        {
            InitializeComponent();
        }

        public FrmProductDialog(BaseUserTable user)
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
                txtModelNumber.Text = _currentProductTable.MODEL_NUMBER;
                txtGroupCode.Text = _currentProductTable.GROUP_CODE;
                txtGroupName.Text = _currentProductTable.GROUP_NAME;
                txtBasic.Text = _currentProductTable.BASIC_UNIT_CODE;
                txtBasicName.Text = _currentProductTable.BASIC_UNIT_NAME;
                //txtHsCode.Text = _currentProductTable.HS_CODE;
                //txtHsName.Text = _currentProductTable.HSCODE_NAME;
                txtPrice.Text = _currentProductTable.SALES_PRICE.ToString();
                txtPurchase_Price.Text = _currentProductTable.PURCHASE_PRICE.ToString();
                //txtSupplierCode.Text = _currentProductTable.SUPPLIER_CODE;
                //txtSupplierName.Text = _currentProductTable.SUPPLIER_NAME;
                txtSafetyStock.Text = _currentProductTable.SAFETY_STOCK.ToString();
            }
                
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
                btnNew.Visible = true;
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
        private void btnSave_Click_1(object sender, EventArgs e)
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
                _currentProductTable.MODEL_NUMBER = txtModelNumber.Text.Trim();
                _currentProductTable.GROUP_CODE = txtGroupCode.Text.Trim();
                _currentProductTable.BASIC_UNIT_CODE = txtBasic.Text.Trim();
                //_currentProductTable.HS_CODE = txtHsCode.Text.Trim();
                _currentProductTable.SALES_PRICE = Convert.ToDecimal(txtPrice.Text.Trim());
                _currentProductTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentProductTable.PURCHASE_PRICE = CConvert.ToDecimal(txtPurchase_Price.Text.Trim());
                _currentProductTable.ACCOUTING_TARGET = 1;
                _currentProductTable.STOCK_FLAG = 1;
                _currentProductTable.PROPERTY_FLAG = 1;
                _currentProductTable.FROMSET_FLAG = 1;
                _currentProductTable.MECHANICAL_DISTINCTION_FLAG = 1;           
                _currentProductTable.SELL_LOCATION = CConstant.PRODUCT_SELL_CHINA;
                _currentProductTable.PACKAGE_MODE = CConstant.PRODUCT_PACKAGE_ALONT;
                //_currentProductTable.SUPPLIER_CODE = txtSupplierCode.Text;
                _currentProductTable.SAFETY_STOCK = CConvert.ToDecimal(txtSafetyStock.Text.Trim());
              
                try
                {
                    if (bProduct.Exists(txtCode.Text.Trim()))
                        bProduct.Update(_currentProductTable);
                    else
                    {
                        _currentProductTable.CREATE_USER = _userInfo.CODE;
                        bProduct.Add(_currentProductTable);
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
            {
                strErrorlog += "商品编号不能为空!\r\n";
            }

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                strErrorlog += "商品名称不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(this.txtBasic.Text.Trim()))
            {
                strErrorlog += "基本单位不能为空!\r\n";
            }

            //判断类别不能为空
            if (string.IsNullOrEmpty(this.txtGroupCode.Text.Trim()))
            {
                strErrorlog += "类别编号不能为空!\r\n";
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
                txtName.Text = CTools.textSpilt(txtName.Text, txtName.MaxLength);

            if (CTools.GetTextBoxLength(txtModelNumber.Text) > txtModelNumber.MaxLength)
                txtModelNumber.Text = CTools.textSpilt(txtModelNumber.Text, txtModelNumber.MaxLength);

            return true;
        }
        #endregion

        #region 取消/关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
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
                    txtBasic.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtGroupCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtGroupCode.Text.Trim()))
            {
                BaseProductGroupTable productGroup = new BaseProductGroupTable();
                BProductGroup bProductGroup = new BProductGroup();
                productGroup = bProductGroup.GetModel(this.txtGroupCode.Text);
                if (productGroup == null || "".Equals(productGroup))
                {
                    txtGroupCode.Focus();
                    txtGroupCode.Text = "";
                    txtGroupName.Text = "";
                    MessageBox.Show("类别型号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    txtGroupName.Text = productGroup.NAME;
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
                    txtBasic.Text = frm.BaseMasterTable.Code;
                    txtBasicName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        private void txtBasic_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtBasic.Text.Trim()))
            {
                BaseUnitTable Unit = new BaseUnitTable();
                BUnit bUnit = new BUnit();
                Unit = bUnit.GetModel(this.txtBasic.Text);
                if (Unit == null || "".Equals(Unit))
                {
                    txtBasic.Focus();
                    txtBasic.Text = "";
                    txtBasicName.Text = "";
                    MessageBox.Show("基本单位不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    txtBasicName.Text = Unit.NAME;
            }
            else
            {
                txtBasic.Text = "";
                txtBasicName.Text = "";
            }
        }
        #endregion

        private void FrmProductDialog_Shown(object sender, EventArgs e)
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

        #region 保存新建
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentProductTable == null)
                {
                    _currentProductTable = new BaseProductTable();
                }
                _currentProductTable.CODE = txtCode.Text;
                _currentProductTable.NAME = txtName.Text;
                _currentProductTable.SPEC = txtSpec.Text;
                _currentProductTable.MODEL_NUMBER = txtModelNumber.Text;
                _currentProductTable.GROUP_CODE = txtGroupCode.Text;
                _currentProductTable.BASIC_UNIT_CODE = txtBasic.Text;
                //_currentProductTable.HS_CODE = txtHsCode.Text;
                _currentProductTable.SALES_PRICE = Convert.ToDecimal(txtPrice.Text);
                _currentProductTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentProductTable.PURCHASE_PRICE = CConvert.ToDecimal(txtPurchase_Price.Text);
                _currentProductTable.ACCOUTING_TARGET = 1;
                _currentProductTable.STOCK_FLAG = 1;
                _currentProductTable.PROPERTY_FLAG = 1;
                _currentProductTable.FROMSET_FLAG = 1;
                _currentProductTable.MECHANICAL_DISTINCTION_FLAG = 1;
                _currentProductTable.SELL_LOCATION = CConstant.PRODUCT_SELL_CHINA;
                _currentProductTable.PACKAGE_MODE = CConstant.PRODUCT_PACKAGE_ALONT;
                //_currentProductTable.SUPPLIER_CODE = txtSupplierCode.Text;
                _currentProductTable.SAFETY_STOCK = CConvert.ToDecimal(txtSafetyStock.Text);

                try
                {
                    if (bProduct.Exists(txtCode.Text.Trim()))
                        bProduct.Update(_currentProductTable);
                    else
                    {
                        _currentProductTable.CREATE_USER = _userInfo.CODE;
                        bProduct.Add(_currentProductTable);
                    }
                    setNew();
                }
                catch (Exception ex)
                {
                    //log.error
                    MessageBox.Show("");
                    return;
                }               
            }           
        }

        private void setNew()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtSpec.Text = "";
            txtModelNumber.Text = "";
            txtGroupCode.Text = "";
            txtGroupName.Text = "";
            txtBasic.Text = "";
            txtBasicName.Text = "";
            txtPrice.Text = "";
            txtPurchase_Price.Text = "";
            txtSafetyStock.Text = "";
        }
        #endregion

        #region 供应商
        //private void btnSupplier_Click(object sender, EventArgs e)
        //{
        //    FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
        //    if (frm.ShowDialog(this) == DialogResult.OK)
        //    {
        //        if (frm.BaseMasterTable != null)
        //        {
        //            txtSupplierCode.Text = frm.BaseMasterTable.Code;
        //            txtSupplierName.Text = frm.BaseMasterTable.Name;
        //            btnSave.Focus();
        //        }
        //    }
        //    frm.Dispose();
        //}

        //private void txtSupplierCode_Leave(object sender, EventArgs e)
        //{
        //    string SupplierCode = txtSupplierCode.Text.Trim();
        //    if (!string.IsNullOrEmpty(SupplierCode))
        //    {
        //        BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
        //        if (baseMaster != null)
        //        {
        //            txtSupplierCode.Text = baseMaster.Code;
        //            txtSupplierName.Text = baseMaster.Name;                    
        //        }
        //        else
        //        {
        //            MessageBox.Show("供应商编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtSupplierCode.Text = "";
        //            txtSupplierName.Text = "";
        //            txtSupplierCode.Focus();
        //        }
        //    }
        //    else
        //    {
        //        txtSupplierName.Text = "";
        //    }
        //}
        #endregion
        
    }
}
