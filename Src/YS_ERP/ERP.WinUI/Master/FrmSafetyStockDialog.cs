using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI.Master
{
    public partial class FrmSafetyStockDialog : Form
    {

        private BaseUserTable _userInfo;
        private BSafetyStock bSafetyStock = new BSafetyStock();
        private int _mode;
        private BaseSafetyStockTable _currentSafetyStockTable = null;
        private DialogResult result = DialogResult.Cancel;


        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        public BaseSafetyStockTable CurrentSafetyStockTable
        {
            get { return _currentSafetyStockTable; }
            set { _currentSafetyStockTable = value; }
        }

        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmSafetyStockDialog()
        {
            InitializeComponent();
        }

        private void FrmSafetyStockDialog_Load(object sender, EventArgs e)
        {
            if (_currentSafetyStockTable != null)
            {
                txtWarehouseCode.Text = _currentSafetyStockTable.WAREHOUSE_CODE;
                txtWarehouseName.Text = _currentSafetyStockTable.WAREHOUSE_NAME;
                txtProductCode.Text = _currentSafetyStockTable.PRODUCT_CODE;
                txtProductName.Text = _currentSafetyStockTable.PRODUCT_NAME;
                txtUnitCode.Text = _currentSafetyStockTable.UNIT_CODE;
                txtUnitName.Text = _currentSafetyStockTable.UNIT_NAME;
                txtSafetyStock.Text = _currentSafetyStockTable.SAFETY_STOCK.ToString();
                txtMaxQuantity.Text = _currentSafetyStockTable.MAX_QUANTITY.ToString();
                txtMinPurcahseQuantity.Text = _currentSafetyStockTable.MIN_PURCHASE_QUANTITY.ToString();
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtWarehouseCode.BackColor = Color.WhiteSmoke;
                txtWarehouseCode.Enabled = false;
                txtProductCode.BackColor = Color.WhiteSmoke;
                txtProductCode.Enabled = false;
                btnWarehouse.Enabled = false;
                btnProduct.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtWarehouseCode.Text = "";
                txtProductCode.Text = "";
                txtWarehouseName.Text = "";
                txtProductName.Text = "";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentSafetyStockTable == null)
                {
                    _currentSafetyStockTable = new BaseSafetyStockTable();
                }

                _currentSafetyStockTable.WAREHOUSE_CODE = txtWarehouseCode.Text;
                _currentSafetyStockTable.PRODUCT_CODE = txtProductCode.Text;
                _currentSafetyStockTable.UNIT_CODE = txtUnitCode.Text;
                _currentSafetyStockTable.SAFETY_STOCK = Convert.ToDecimal(txtSafetyStock.Text);
                _currentSafetyStockTable.MAX_QUANTITY = Convert.ToDecimal(txtMaxQuantity.Text);
                _currentSafetyStockTable.MIN_PURCHASE_QUANTITY = Convert.ToDecimal(txtMinPurcahseQuantity.Text);
                _currentSafetyStockTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bSafetyStock.Exists(txtWarehouseCode.Text.Trim(), txtProductCode.Text.Trim()))
                    {
                        bSafetyStock.Update(_currentSafetyStockTable);
                    }
                    else
                    {
                        _currentSafetyStockTable.CREATE_USER = _userInfo.CODE;
                        bSafetyStock.Add(_currentSafetyStockTable);
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
            //判断仓库编号不能为空
            if (string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()))
                strErrorlog += "仓库编号不能为空!\r\n";

            //判断商品编号不能为空
            if (string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
                strErrorlog += "商品编号不能为空!\r\n";

            if (string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()))
                strErrorlog += "单位编号不能为空!\r\n";

            if (string.IsNullOrEmpty(this.txtSafetyStock.Text.Trim()))
                strErrorlog += "安全库存数不能为空!\r\n";

            if (string.IsNullOrEmpty(this.txtMaxQuantity.Text.Trim()))
                strErrorlog += "最大库存数不能为空!\r\n";

            if (string.IsNullOrEmpty(this.txtMinPurcahseQuantity.Text.Trim()))
                strErrorlog += "最小采购数不能为空!\r\n";

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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

        #region 仓库
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouseCode.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                    txtWarehouseCode.Focus();
                    txtProductCode.Focus();
                    txtWarehouseCode_Leave(txtWarehouseCode, EventArgs.Empty);
                }
            }
            frm.Dispose();
        }

        private void txtWarehouseCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
            {
                BaseSafetyStockTable SafetyCode = new BaseSafetyStockTable();
                SafetyCode = bSafetyStock.GetModel(txtWarehouseCode.Text, txtProductCode.Text);
                if (SafetyCode != null)
                {
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtWarehouseCode.Focus();
                    MessageBox.Show("仓库编号与商品编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (!string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()))
            {
                BaseWarehouseTable Warehouse = new BaseWarehouseTable();
                BWarehouse bWarehouse = new BWarehouse();
                Warehouse = bWarehouse.GetModel(this.txtWarehouseCode.Text);
                if (Warehouse == null || "".Equals(Warehouse))
                {
                    txtWarehouseCode.Focus();
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    MessageBox.Show("仓库编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    txtWarehouseName.Text = Warehouse.NAME;
            }
        }
        #endregion

        #region 商品
        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductCode.Text = frm.BaseMasterTable.Code;
                    txtProductName.Text = frm.BaseMasterTable.Name;
                    txtProductCode.Focus();
                    txtUnitCode.Focus();
                    txtProductCode_Leave(txtProductCode, EventArgs.Empty);
                }
            }
            frm.Dispose();
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
            {
                BaseSafetyStockTable SafetyCode = new BaseSafetyStockTable();
                SafetyCode = bSafetyStock.GetModel(txtWarehouseCode.Text, txtProductCode.Text);
                if (SafetyCode != null)
                {
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtWarehouseCode.Focus();
                    MessageBox.Show("仓库编号与商品编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (!string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
            {
                BaseProductTable product = new BaseProductTable();
                BProduct bProduct = new BProduct();
                product = bProduct.GetModel(this.txtProductCode.Text);
                if (product == null || "".Equals(product))
                {
                    txtProductCode.Focus();
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    MessageBox.Show("商品编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtProductName.Text = product.NAME;
                    txtUnitCode.Text = product.BASIC_UNIT_CODE;
                    txtUnitName.Text = product.BASIC_UNIT_NAME;
                }
            }
        }
        #endregion

        #region 单位
        private void btnUnit_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("UNIT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtUnitCode.Text = frm.BaseMasterTable.Code;
                    txtUnitName.Text = frm.BaseMasterTable.Name;
                    txtUnitCode.Focus();
                    txtSafetyStock.Focus();
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
                    MessageBox.Show("单位编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    txtUnitName.Text = Unit.NAME;
            }
        }
        #endregion

        private void FrmSafetyStockDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void FrmSafetyStockDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtWarehouseCode.Focus();
            }
            else
            {
                txtUnitCode.Focus();
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtMinPurcahseQuantity.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }

            if (txtSafetyStock.Focused || txtMaxQuantity.Focused || txtMinPurcahseQuantity.Focused)
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
                if (txtWarehouseCode.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtSafetyStock.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }
    }
}
