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
    public partial class FrmCompositionProductsProductionProcessDialog : Form
    {
        private BaseUserTable _userInfo;
        private BaseCompositionProductsProductionProcessTable _currentCompositionProductsProductionProcessTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BCompositionProductsProductionProcess bCompositionProductsSpecification = new BCompositionProductsProductionProcess();
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
        public BaseCompositionProductsProductionProcessTable CurrentCompositionProductsProductionProcessTable
        {
            get { return _currentCompositionProductsProductionProcessTable; }
            set { _currentCompositionProductsProductionProcessTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmCompositionProductsProductionProcessDialog()
        {
            InitializeComponent();
        }

        private void FrmCompositionProductsProductionProcessDialog_Load(object sender, EventArgs e)
        {
            if (_currentCompositionProductsProductionProcessTable != null)
            {
                txtCompositionProductsCode.Text = _currentCompositionProductsProductionProcessTable.COMPOSITION_PRODUCTS_CODE;
                txtCompositionProductsName.Text = _currentCompositionProductsProductionProcessTable.COMPOSITION_PRODUCTS_NAME;
                txtProductionProcessCode.Text = _currentCompositionProductsProductionProcessTable.PRODUCTION_PROCESS_CODE;
                txtProductionProcessName.Text = _currentCompositionProductsProductionProcessTable.PRODUCTION_PROCESS_NAME;
                txtOrder.Text = CConvert.ToString(_currentCompositionProductsProductionProcessTable.ORDER);
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCompositionProductsCode.BackColor = Color.WhiteSmoke;
                txtProductionProcessCode.BackColor = Color.WhiteSmoke;
                //txtCompositionProductsCode.Enabled = false;
                //txtProductionProcessCode.Enabled = false;
                //btnCompositionProducts.Enabled = false;
                //btnProductionProcess.Enabled = false;

            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCompositionProductsCode.BackColor = Color.WhiteSmoke;
                txtCompositionProductsCode.Enabled = false;
                btnCompositionProducts.Enabled = false;
                txtProductionProcessCode.Text = "";
                txtProductionProcessName.Text = "";
                txtOrder.Text = "";
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
                if (_currentCompositionProductsProductionProcessTable == null)
                {
                    _currentCompositionProductsProductionProcessTable = new BaseCompositionProductsProductionProcessTable();
                }
                _currentCompositionProductsProductionProcessTable.COMPOSITION_PRODUCTS_CODE = txtCompositionProductsCode.Text.Trim();
                _currentCompositionProductsProductionProcessTable.PRODUCTION_PROCESS_CODE = txtProductionProcessCode.Text.Trim();
                _currentCompositionProductsProductionProcessTable.ORDER = txtOrder.Text.Trim();

                try
                {
                    if (bCompositionProductsSpecification.Exists(txtCompositionProductsCode.Text.Trim(), txtProductionProcessCode.Text.Trim()))
                    {
                        bCompositionProductsSpecification.Update(_currentCompositionProductsProductionProcessTable);
                    }
                    else
                    {
                        bCompositionProductsSpecification.Add(_currentCompositionProductsProductionProcessTable);
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
            //判断组成品编号不能为空
            if (string.IsNullOrEmpty(this.txtCompositionProductsCode.Text.Trim()))
            {
                strErrorlog += "主配件编号不能为空!\r\n";
            }

            //判断规格编号不能为空
            if (string.IsNullOrEmpty(this.txtProductionProcessCode.Text.Trim()))
            {
                strErrorlog += "工序编号不能为空!\r\n";
            }

            if (string.IsNullOrEmpty(this.txtOrder.Text.Trim()))
            {
                strErrorlog += "序号不能为空!\r\n";
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
            //if (!string.IsNullOrEmpty(this.txtCompositionProductsCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtProductionProcessCode.Text.Trim()))
            //{
            //    BaseCompositionProductsProductionProcessTable compositionspecificationGroup = new BaseCompositionProductsProductionProcessTable();
            //    compositionspecificationGroup = bCompositionProductsSpecification.GetModel(txtCompositionProductsCode.Text, txtProductionProcessCode.Text);
            //    if (compositionspecificationGroup != null)
            //    {
            //        txtCompositionProductsCode.Text = "";
            //        txtCompositionProductsName.Text = "";
            //        txtProductionProcessCode.Text = "";
            //        txtProductionProcessName.Text = "";
            //        txtOrder.Text = "";
            //        txtCompositionProductsCode.Focus();
            //        MessageBox.Show("主配件与工序的组合已存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return false;
            //    }
            //}
            //if (!string.IsNullOrEmpty(this.txtOrder.Text.Trim())) 
            //{

            //    BaseCompositionProductsProductionProcessTable compositionspecificationGroup = new BaseCompositionProductsProductionProcessTable();
            //    compositionspecificationGroup = bCompositionProductsSpecification.GetOrder(this.txtOrder.Text.Trim());
            //    if (compositionspecificationGroup != null)
            //    {
            //        txtCompositionProductsCode.Text = "";
            //        txtCompositionProductsName.Text = "";
            //        txtProductionProcessCode.Text = "";
            //        txtProductionProcessName.Text = "";
            //        txtOrder.Text = "";
            //        txtCompositionProductsCode.Focus();
            //        MessageBox.Show("序号已存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region 按键
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtCompositionProductsCode.Focused)
                { }
                else
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtProductionProcessName.Focused)
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

        #region 组成品
        private void btnCompositionProducts_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("COMPOSITION_PRODUCTS", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCompositionProductsCode.Text = frm.BaseMasterTable.Code;
                    txtCompositionProductsName.Text = frm.BaseMasterTable.Name;
                    txtProductionProcessCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtCompositionProductsCode_Leave(object sender, EventArgs e)
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
                    MessageBox.Show("主配件不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCompositionProductsCode.Text = "";
                    txtCompositionProductsName.Text = "";
                    txtCompositionProductsCode.Focus();
                }
            }
            else
            {
                txtCompositionProductsName.Text = "";
            }
        }
        #endregion

        #region 规格
        private void btnProductionProcess_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCTION_PROCESS", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtProductionProcessCode.Text = frm.BaseMasterTable.Code;
                    txtProductionProcessName.Text = frm.BaseMasterTable.Name;
                    btnSave.Focus();
                    if (!string.IsNullOrEmpty(this.txtCompositionProductsCode.Text.Trim()) && !string.IsNullOrEmpty(this.txtProductionProcessCode.Text.Trim()))
                    {
                        BaseCompositionProductsProductionProcessTable compositionspecificationGroup = new BaseCompositionProductsProductionProcessTable();
                        compositionspecificationGroup = bCompositionProductsSpecification.GetModel(txtCompositionProductsCode.Text, txtProductionProcessCode.Text);
                        if (compositionspecificationGroup != null)
                        {
                            txtProductionProcessCode.Text = "";
                            txtProductionProcessName.Text = "";
                            txtOrder.Text = "";
                            txtCompositionProductsCode.Focus();
                            MessageBox.Show("主配件与工序的组合已存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;// false;
                        }
                    }
                }
            }
            frm.Dispose();
        }

        private void txtProductionProcessCode_Leave(object sender, EventArgs e)
        {
            string productionProcessCode = txtProductionProcessCode.Text.Trim();
            if (productionProcessCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCTION_PROCESS", productionProcessCode, "");
                if (baseMaster != null)
                {
                    txtProductionProcessCode.Text = baseMaster.Code;
                    txtProductionProcessName.Text = baseMaster.Name;

                }
                else
                {
                    MessageBox.Show("工序不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductionProcessCode.Text = "";
                    txtProductionProcessName.Text = "";
                    btnSave.Focus();
                }
            }
            else
            {
                txtProductionProcessCode.Text = "";
            }
        }
        #endregion

        private void FrmCompositionProductsProductionProcessDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

    }
}
