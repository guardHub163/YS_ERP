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
    public partial class FrmCustomerPriceDialog : Form
    {

        private BaseUserTable _userInfo;
        private BaseCustomerPriceTable _currentCustomerPriceTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BCommon bCommon = new BCommon();
        private BCustomerPrice bCustomerPrice = new BCustomerPrice();


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
        public BaseCustomerPriceTable CurrentCustomerPriceTable
        {
            get { return _currentCustomerPriceTable; }
            set { _currentCustomerPriceTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmCustomerPriceDialog()
        {
            InitializeComponent();
        }

        private void FrmCustomerPriceDialog_Load(object sender, EventArgs e)
        {
            if (_currentCustomerPriceTable != null)
            {
                txtCustomerCode.Text = _currentCustomerPriceTable.CUSTOMER_CODE;
                txtCustomerName.Text = _currentCustomerPriceTable.CUSTOMER_NAME;
                txtProductCode.Text = _currentCustomerPriceTable.PRODUCT_CODE;
                txtProductName.Text = _currentCustomerPriceTable.PRODUCT_NAME;
                txtUnitCode.Text = _currentCustomerPriceTable.UNIT_CODE;
                txtUnitName.Text = _currentCustomerPriceTable.UNIT_NAME;
                txtPrice.Text = _currentCustomerPriceTable.PRICE.ToString();
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCustomerCode.BackColor = Color.WhiteSmoke;
                txtProductCode.BackColor = Color.WhiteSmoke;
                txtUnitCode.BackColor = Color.WhiteSmoke;
                
                txtCustomerCode.Enabled = false;
                txtProductCode.Enabled = false;
                txtUnitCode.Enabled = false;
                btnCustomer.Enabled = false;
                btnProduct.Enabled = false;
                btnUnit.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCustomerCode.Text = "";
                txtProductCode.Text = "";
                txtUnitCode.Text = "";
                txtCustomerName.Text = "";
                txtProductName.Text = "";
                txtUnitName.Text = "";
            }
        }       

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckCode())
            {
                return;
            }
            if (CheckInput())
            {
                if (_currentCustomerPriceTable == null)
                {
                    _currentCustomerPriceTable = new BaseCustomerPriceTable();
                }

                _currentCustomerPriceTable.CUSTOMER_CODE = txtCustomerCode.Text.Trim();
                _currentCustomerPriceTable.PRODUCT_CODE = txtProductCode.Text.Trim();
                _currentCustomerPriceTable.UNIT_CODE = txtUnitCode.Text.Trim();
                _currentCustomerPriceTable.PRICE = Convert.ToDecimal(txtPrice.Text.Trim());
                _currentCustomerPriceTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bCustomerPrice.Exists(txtCustomerCode.Text.Trim(), txtProductCode.Text.Trim(), txtUnitCode.Text.Trim()))
                    {
                        bCustomerPrice.Update(_currentCustomerPriceTable);
                    }
                    else
                    {
                        _currentCustomerPriceTable.CREATE_USER = _userInfo.CODE;
                        bCustomerPrice.Add(_currentCustomerPriceTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("");
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
            //判断客户编号不能为空
            if (string.IsNullOrEmpty(this.txtCustomerCode.Text.Trim()))
            {
                strErrorlog += "客户编号不能为空!\r\n";
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

            if (strErrorlog != null || "".Equals(strErrorlog))
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

        private bool CheckCode()
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtCustomerCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
            {
                BaseCustomerPriceTable CustomerPriceCode = new BaseCustomerPriceTable();
                CustomerPriceCode = bCustomerPrice.GetModel(txtCustomerCode.Text, txtProductCode.Text, txtUnitCode.Text);
                if (CustomerPriceCode != null)
                {
                    txtCustomerCode.Text = "";
                    txtProductCode.Text = "";
                    txtUnitCode.Text = "";
                    txtCustomerName.Text = "";
                    txtProductName.Text = "";
                    txtUnitName.Text = "";
                    txtCustomerCode.Focus();
                    MessageBox.Show("客户编号商品编号单位编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FrmCustomerPriceDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }
        #endregion

        #region 客户
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Customer", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtCustomerName.Text = frm.BaseMasterTable.Name;
                    txtProductCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            string customer = txtCustomerCode.Text.Trim();
            if (!string.IsNullOrEmpty(customer))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", customer);
                if (baseMaster != null)
                {
                    txtCustomerCode.Text = baseMaster.Code;
                    txtCustomerName.Text = baseMaster.Name;
                    txtProductCode.Focus();
                }
                else
                {
                    MessageBox.Show("客户编号不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerCode.Text = "";
                    txtCustomerName.Text = "";
                    txtCustomerCode.Focus();
                }
            }
            else
            {
                txtCustomerName.Text = "";
            }           
        }
        #endregion

        #region  商品
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
                    MessageBox.Show("商品编号不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("单位编号不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region 按键
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //System.Windows.Forms.SendKeys.Send("{Tab}");
                ProcessTabKey(true);
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
                if (txtCustomerCode.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtPrice.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion
    }
}
