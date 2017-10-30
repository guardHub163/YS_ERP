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
    public partial class FrmSlipTypeCompositionProductsDialog : Form
    {
        private BaseUserTable _userInfo;
        private BaseSlipTypeCompositionProductsTable _currentSlipTypeProductGroupTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BSlipTypeCompositionProducts bSlipTypeProductGroup = new BSlipTypeCompositionProducts();
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
        public BaseSlipTypeCompositionProductsTable CurrentSlipTypeProductGroupTable
        {
            get { return _currentSlipTypeProductGroupTable; }
            set { _currentSlipTypeProductGroupTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public FrmSlipTypeCompositionProductsDialog()
        {
            InitializeComponent();
        }

        private void FrmMachineDialog_Load(object sender, EventArgs e)
        {
            if (_currentSlipTypeProductGroupTable != null)
            {
                txtSlipTypeCode.Text = _currentSlipTypeProductGroupTable.SLIP_TYPE_CODE;
                txtSlipTypeName.Text = _currentSlipTypeProductGroupTable.SLIP_TYPE_NAME;
                txtCompositionProductsCode.Text = _currentSlipTypeProductGroupTable.COMPOSITION_PRODUCTS_CODE;
                txtCompositionProductsName.Text = _currentSlipTypeProductGroupTable.COMPOSITION_PRODUCTS_NAME;
                txtquantity.Text = _currentSlipTypeProductGroupTable.QUANTITY.ToString();
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtSlipTypeCode.BackColor = Color.WhiteSmoke;
                txtCompositionProductsCode.BackColor = Color.WhiteSmoke;
                txtSlipTypeCode.Enabled = false;
                txtCompositionProductsCode.Enabled = false;
                //btnSlipType.Enabled = false;
                //btnCompositionProducts.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtSlipTypeCode.BackColor = Color.WhiteSmoke;
                txtSlipTypeCode.Enabled = false;
                btnSlipType.Enabled = false;
                txtCompositionProductsCode.Text = "";
                txtCompositionProductsName.Text = "";
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
                if (_currentSlipTypeProductGroupTable == null)
                {
                    _currentSlipTypeProductGroupTable = new BaseSlipTypeCompositionProductsTable();
                }
                _currentSlipTypeProductGroupTable.SLIP_TYPE_CODE = txtSlipTypeCode.Text.Trim();
                _currentSlipTypeProductGroupTable.COMPOSITION_PRODUCTS_CODE = txtCompositionProductsCode.Text.Trim();
                _currentSlipTypeProductGroupTable.QUANTITY = int.Parse(txtquantity.Text.Trim()) ;
                try
                {
                    if (bSlipTypeProductGroup.Exists(txtSlipTypeCode.Text.Trim(), txtCompositionProductsCode.Text.Trim()))
                    {
                        bSlipTypeProductGroup.Update(_currentSlipTypeProductGroupTable);
                    }
                    else
                    {
                        bSlipTypeProductGroup.Add(_currentSlipTypeProductGroupTable);
                    }
                }
                catch (Exception ex)
                {
                    //log.error
                    MessageBox.Show(ex.Message);
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
            if (string.IsNullOrEmpty(this.txtSlipTypeCode.Text.Trim()))
            {
                strErrorlog += "商品编号不能为空!\r\n";
            }

            //判断材料编号不能为空
            if (string.IsNullOrEmpty(this.txtCompositionProductsCode.Text.Trim()))
            {
                strErrorlog += "材料编号不能为空!\r\n";
            }            

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private bool CheckCode()
        {
            ////判断编号是否已存在
            //if (!string.IsNullOrEmpty(this.txtSlipTypeCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtCompositionProductsCode.Text.Trim()))
            //{
            //    BaseSlipTypeCompositionProductsTable SlipTypeProductGroup = new BaseSlipTypeCompositionProductsTable();
            //    SlipTypeProductGroup = bSlipTypeProductGroup.GetModel(txtSlipTypeCode.Text, txtCompositionProductsCode.Text);
            //    if (SlipTypeProductGroup != null)
            //    {
            //        txtSlipTypeCode.Text = "";
            //        txtSlipTypeName.Text = "";
            //        txtCompositionProductsCode.Text = "";
            //        txtCompositionProductsName.Text = "";
            //        txtSlipTypeCode.Focus();
            //        MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return false;
            //    }
            //}
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

        private void FrmProductPartsDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtSlipTypeCode.Focus();
            }
        }
        #region 按键
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtSlipTypeCode.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtCompositionProductsCode.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
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

        #region 产线
        private void btnSlipType_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SLIP_TYPE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSlipTypeCode.Text = frm.BaseMasterTable.Code;
                    txtSlipTypeName.Text = frm.BaseMasterTable.Name;
                    txtCompositionProductsCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSlipTypeCode_Leave(object sender, EventArgs e)
        {
            string slipTypeCode = txtSlipTypeCode.Text.Trim();
            if (slipTypeCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SLIP_TYPE", slipTypeCode, "");
                if (baseMaster != null)
                {
                    txtSlipTypeCode.Text = baseMaster.Code;
                    txtSlipTypeName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("产线不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSlipTypeCode.Text = "";
                    txtSlipTypeName.Text = "";
                    txtCompositionProductsCode.Focus();
                }
            }
            else
            {
                txtSlipTypeName.Text = "";
            }
        }
        #endregion

        #region 组成品
        private void btnProductGroup_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("COMPOSITION_PRODUCTS", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCompositionProductsCode.Text = frm.BaseMasterTable.Code;
                    txtCompositionProductsName.Text = frm.BaseMasterTable.Name;
                    txtCompositionProductsCode.Focus();
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtProductGroupCode_Leave(object sender, EventArgs e)
        {       

            string compositionCode = txtCompositionProductsCode.Text.Trim();
            if (compositionCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("COMPOSITION_PRODUCTS", compositionCode, "");
                if (baseMaster != null)
                {
                    txtCompositionProductsCode.Text = baseMaster.Code;
                    txtCompositionProductsName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("组成品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCompositionProductsCode.Text = "";
                    txtCompositionProductsName.Text = "";
                    btnSave.Focus();
                }
            }
            else
            {
                txtCompositionProductsName.Text = "";
            }


            if (!string.IsNullOrEmpty(this.txtSlipTypeCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtCompositionProductsCode.Text.Trim()))
            {
                BaseSlipTypeCompositionProductsTable SlipTypeProductGroup = new BaseSlipTypeCompositionProductsTable();
                SlipTypeProductGroup = bSlipTypeProductGroup.GetModel(txtSlipTypeCode.Text, txtCompositionProductsCode.Text);
                if (SlipTypeProductGroup != null)
                {
                    txtSlipTypeCode.Text = "";
                    txtSlipTypeName.Text = "";
                    txtCompositionProductsCode.Text = "";
                    txtCompositionProductsName.Text = "";
                    txtSlipTypeCode.Focus();
                    MessageBox.Show("编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return ;
                }
            }


        }
        #endregion

        private void FrmSlipTypeCompositionProductsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }
    }
}
