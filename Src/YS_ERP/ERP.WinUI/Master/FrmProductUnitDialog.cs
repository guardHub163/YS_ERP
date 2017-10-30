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
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI.Master
{
    public partial class FrmProductUnitDialog : Form
    {

        private BaseUserTable _userInfo;
        private BaseProductUnitTable _currentProductUnitTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;

        private BProductUnit bProductUnit = new BProductUnit();

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
        public BaseProductUnitTable CurrentProductUnitTable
        {
            get { return _currentProductUnitTable; }
            set { _currentProductUnitTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }


        public FrmProductUnitDialog()
        {
            InitializeComponent();
        }

        private void FrmProductUnitDialog_Load(object sender, EventArgs e)
        {
            if (_currentProductUnitTable != null)
            {
                txtProductCode.Text = _currentProductUnitTable.PRODUCT_CODE;
                txtProductName.Text = _currentProductUnitTable.PRODUCT_NAME;
                txtUnitCode.Text = _currentProductUnitTable.UNIT_CODE;
                txtUnitName.Text = _currentProductUnitTable.UNIT_NAME;
                //cb.Text = _currentProductUnitTable.BASIC_FLAG.ToString();

                if (_currentProductUnitTable.BASIC_FLAG == 1)
                    rBasic1.Checked = true;
                else
                    rBasic2.Checked = true;
            }
            if (_mode == CConstant.MODE_NEW)
                this.Text = "新建";
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtProductCode.BackColor = Color.WhiteSmoke;
                txtUnitCode.BackColor = Color.WhiteSmoke;
                txtProductCode.Enabled = false;
                txtUnitCode.Enabled = false;
                btnProduct.Enabled = false;
                btnUnit.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtProductCode.Text = "";
                txtUnitCode.Text = "";
                txtProductName.Text = "";
                txtUnitName.Text = "";
            }
        }

        private void FrmProductUnitDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentProductUnitTable == null)
                {
                    _currentProductUnitTable = new BaseProductUnitTable();
                }

                _currentProductUnitTable.PRODUCT_CODE = txtProductCode.Text;
                _currentProductUnitTable.UNIT_CODE = txtUnitCode.Text;
                //_currentProductUnitTable.BASIC_FLAG = Convert.ToInt32(cb.SelectedItem.ToString());
                _currentProductUnitTable.LAST_UPDATE_USER = _userInfo.CODE;

                if (rBasic1.Checked)
                    _currentProductUnitTable.BASIC_FLAG = 1;
                else
                    _currentProductUnitTable.BASIC_FLAG = 2;

                try
                {
                    if (bProductUnit.Exists(txtProductCode.Text.Trim(),txtUnitCode.Text.Trim()))
                    {
                        bProductUnit.Update(_currentProductUnitTable);
                    }
                    else
                    {
                        _currentProductUnitTable.CREATE_USER = _userInfo.CODE;
                        bProductUnit.Add(_currentProductUnitTable);
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
            //判断商品编号不能为空
            if (string.IsNullOrEmpty(this.txtProductCode.Text.Trim()))
                strErrorlog += "商品编号不能为空!\r\n";

            //判断单位编号不能为空
            if (string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()))
                strErrorlog += "单位编号不能为空!\r\n";

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

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
                }
            }
            frm.Dispose();
        }

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
                    rBasic1.Focus();
                }
            }
            frm.Dispose();
        }

        private void FrmProductUnitDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
                txtProductCode.Focus();
            else
                gBasic.Focus();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if(gBasic.Focused || rBasic1.Focused || rBasic2.Focused)
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

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtProductCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()))
            {
                BaseProductUnitTable ProductUnitCode = new BaseProductUnitTable();
                ProductUnitCode = bProductUnit.GetModel(txtProductCode.Text, txtUnitCode.Text);
                if (ProductUnitCode != null)
                {
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";
                    txtProductCode.Focus();
                    MessageBox.Show("商品编号与单位编号组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    txtProductName.Text = product.NAME;
            }
        }

        private void txtUnitCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtProductCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtUnitCode.Text.Trim()))
            {
                BaseProductUnitTable ProductUnitCode = new BaseProductUnitTable();
                ProductUnitCode = bProductUnit.GetModel(txtProductCode.Text, txtUnitCode.Text);
                if (ProductUnitCode != null)
                {
                    txtProductCode.Text = "";
                    txtProductName.Text = "";
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";
                    txtProductCode.Focus();
                    MessageBox.Show("商品编号与单位编号组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

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

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtProductCode.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (btnUnit.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }

    }
}
