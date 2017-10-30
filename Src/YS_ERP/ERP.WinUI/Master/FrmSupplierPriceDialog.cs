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
    public partial class FrmSupplierPriceDialog : Form
    {

        private BaseUserTable _userInfo;
        private BaseSupplierPriceTable _currentSupplierPriceTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        //private bool check = true;
        private BSupplierPrice bSupplierPrice = new BSupplierPrice();
        private BCommon bCommon = new BCommon();

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
        public BaseSupplierPriceTable CurrentSupplierPriceTable
        {
            get { return _currentSupplierPriceTable; }
            set { _currentSupplierPriceTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }


        public FrmSupplierPriceDialog()
        {
            InitializeComponent();
        }

        private void FrmSupplierPriceDialog_Load(object sender, EventArgs e)
        {

            if (_currentSupplierPriceTable != null)
            {
                txtSupplierCode.Text = _currentSupplierPriceTable.SUPPLIER_CODE;
                txtSupplierName.Text = _currentSupplierPriceTable.SUPPLIER_NAME;
                txtProductCode.Text = _currentSupplierPriceTable.PRODUCT_CODE;
                txtProductName.Text = _currentSupplierPriceTable.PRODUCT_NAME;
                txtUnitCode.Text = _currentSupplierPriceTable.UNIT_CODE;
                txtUnitName.Text = _currentSupplierPriceTable.UNIT_NAME;
                txtPrice.Text = _currentSupplierPriceTable.PRICE.ToString();

            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtSupplierCode.BackColor = Color.WhiteSmoke;
                txtProductCode.BackColor = Color.WhiteSmoke;
                txtUnitCode.BackColor = Color.WhiteSmoke;
                txtSupplierCode.Enabled = false;
                txtProductCode.Enabled = false;
                txtUnitCode.Enabled = false;
                btnSupplier.Enabled = false;
                btnProduct.Enabled =false;
                btnUnit.Enabled =false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtSupplierCode.Text = "";
                txtProductCode.Text = "";
                txtUnitCode.Text = "";
                txtSupplierName.Text = "";
                txtProductName.Text = "";
                txtUnitName.Text = "";
            }
        }

        #region 关闭
        private void FrmSupplierPriceDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断供应商编号不能为空
            if (string.IsNullOrEmpty(this.txtSupplierCode.Text.Trim()))
            {
                strErrorlog += "供应商编号不能为空!\r\n";
            }

            //判断商品编号不能为空
            if (string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
            {
                strErrorlog += "商品编号不能为空!\r\n";
            }

            //判断单位编号不能为空
            if (string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()))
            {
                strErrorlog += "单位编号不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtPrice.Text == null || "".Equals(txtPrice.Text))
            {
                txtPrice.Text = "0";
            }
            return true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!CheckCode())
            {
                return;
            }
            if (CheckInput())
            {
                if (_currentSupplierPriceTable == null)
                {
                    _currentSupplierPriceTable = new BaseSupplierPriceTable();
                }

                _currentSupplierPriceTable.SUPPLIER_CODE = txtSupplierCode.Text.Trim();
                _currentSupplierPriceTable.PRODUCT_CODE = txtProductCode.Text.Trim();
                _currentSupplierPriceTable.UNIT_CODE = txtUnitCode.Text;
                _currentSupplierPriceTable.CURRENCY_CODE = CConstant.EXCHANGE_CHIAN;
                _currentSupplierPriceTable.PRICE = Convert.ToDecimal(txtPrice.Text.Trim());
                _currentSupplierPriceTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bSupplierPrice.Exists(txtSupplierCode.Text.Trim(), txtProductCode.Text.Trim(), txtUnitCode.Text.Trim(), CConstant.EXCHANGE_CHIAN))
                    {
                        bSupplierPrice.Update(_currentSupplierPriceTable);
                    }
                    else
                    {
                        _currentSupplierPriceTable.CREATE_USER = _userInfo.CODE;
                        bSupplierPrice.Add(_currentSupplierPriceTable);
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

        private bool CheckCode()
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtSupplierCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtProductCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()))
            {
                BaseSupplierPriceTable SupplierPriceCode = new BaseSupplierPriceTable();
                SupplierPriceCode = bSupplierPrice.GetModel(txtSupplierCode.Text, txtProductCode.Text, txtUnitCode.Text, CConstant.EXCHANGE_CHIAN);
                if (SupplierPriceCode != null)
                {
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";
                    txtSupplierCode.Focus();
                    MessageBox.Show("供应商编号商品编号单位编号货币编号的组合\r\n已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 供应商
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Supplier", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    txtSupplierCode.Focus();
                    txtProductCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string supplier = txtSupplierCode.Text.Trim();
            if (!string.IsNullOrEmpty(supplier))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER",supplier);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                    txtProductCode.Focus();
                }
                else
                {
                    MessageBox.Show("供应商编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    txtSupplierCode.Focus();
                }
            }
            else
            {
                txtSupplierName.Text = "";
            }
        }
        #endregion

        #region 商品
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Product", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductCode.Text = frm.BaseMasterTable.Code;
                    txtProductName.Text = frm.BaseMasterTable.Name;
                    txtProductCode.Focus();
                    txtUnitCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            string product = txtProductCode.Text.Trim();
            if (!string.IsNullOrEmpty(product))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT", product);
                if (baseMaster != null)
                {
                    txtProductCode.Text = baseMaster.Code;
                    txtProductName.Text = baseMaster.Name;
                    txtUnitCode.Focus();
                }
                else
                {
                    MessageBox.Show("商品编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    txtUnitCode.Focus();
                    txtPrice.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtUnitCode_Leave(object sender, EventArgs e)
        {
            string unit = txtUnitCode.Text.Trim();
            if (!string.IsNullOrEmpty(unit))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("UNIT", unit);
                if (baseMaster != null)
                {
                    txtUnitCode.Text = baseMaster.Code;
                    txtUnitName.Text = baseMaster.Name;
                    txtPrice.Focus();
                }
                else
                {
                    MessageBox.Show("单位编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";
                    txtUnitCode.Focus();
                }
            }
            else
            {
                txtUnitName.Text = "";
            }            
        }
        #endregion

        private void FrmSupplierPriceDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtSupplierCode.Focus();
            }
            else
            {
                txtPrice.Focus();
            }
        }

        #region 按键
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }

            if (txtPrice.Focused)
            {
                if (e.KeyChar == 46)
                {
                    if (((TextBox)sender).SelectionStart == 0)
                    {
                        e.Handled = true;
                    }
                    else if (((TextBox)sender).Text.IndexOf('.') >= 0)
                    {
                        e.Handled = true;
                    }
                }
                else if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 46) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26)
                {
                    e.Handled = true;
                }
                else　 //以下为输入正确内容过虑
                {
                    string[] str = ((TextBox)sender).Text.Split('.');
                    if (str.Length > 1)
                    {
                        if (str[1].Length >= 2 && ((TextBox)sender).SelectionStart > ((TextBox)sender).Text.IndexOf('.'))
                        {
                            e.Handled = true;
                        }
                    }
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
               if (txtSupplierCode.Focused)
               { }
               else
               {
                   System.Windows.Forms.SendKeys.Send("+{Tab}");
               }
           }
           if (e.KeyCode == Keys.Down)
           {
               if (txtPrice.Focused)
               { }
               else
               {
                   System.Windows.Forms.SendKeys.Send("{Tab}");
               }
           }
       }
       #endregion     
    }
}
