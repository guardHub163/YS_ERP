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

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductGroupDialog : Form
    {
        private BProductGroup bProductGroup = new BProductGroup();
        private BaseUserTable _userInfo;
        private BaseProductGroupTable _currentProductGroupTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        BCommon bCommon = new BCommon();

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
        public BaseProductGroupTable CurrentProductGroupTable
        {
            get { return _currentProductGroupTable; }
            set { _currentProductGroupTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmProductGroupDialog()
        {
            InitializeComponent();
        }

        private void FrmProductGroupDialog_Load(object sender, EventArgs e)
        {
            if (_currentProductGroupTable != null)
            {
                txtCode.Text = _currentProductGroupTable.CODE;
                txtName.Text = _currentProductGroupTable.NAME;
                txtParentCode.Text = _currentProductGroupTable.PARENT_CODE;
                txtParentName.Text = _currentProductGroupTable.PARENT_NAME;
                txtSupplierCode.Text = _currentProductGroupTable.BASIC_SUPPLIER;
                txtSupplierName.Text = _currentProductGroupTable.BASIC_SUPPLIER_NAME;
                txtSecondSupplier.Text = _currentProductGroupTable.SECOND_SUPPLIER_CODE;
                txtSecondSupplierName.Text = _currentProductGroupTable.SECOND_SUPPLIER_NAME;
                txtthirdSupplier.Text = _currentProductGroupTable.THIRD_SUPPLIER_CODE;
                txtThirdSupplierName.Text = _currentProductGroupTable.THIRD_SUPPLIER_NAME;
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";
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

        #region 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentProductGroupTable == null)
                {
                    _currentProductGroupTable = new BaseProductGroupTable();
                }
                _currentProductGroupTable.CODE = txtCode.Text.Trim();
                _currentProductGroupTable.NAME = txtName.Text.Trim();
                _currentProductGroupTable.PARENT_CODE = txtParentCode.Text.Trim();
                _currentProductGroupTable.LAST_UPDATE_USER = _userInfo.CODE.Trim();
                _currentProductGroupTable.BASIC_SUPPLIER = txtSupplierCode.Text.Trim();
                _currentProductGroupTable.SECOND_SUPPLIER_CODE = txtSecondSupplier.Text.Trim();
                _currentProductGroupTable.THIRD_SUPPLIER_CODE = txtthirdSupplier.Text.Trim();
                _currentProductGroupTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bProductGroup.Exists(txtCode.Text.Trim()))
                    {
                        bProductGroup.Update(_currentProductGroupTable);
                    }
                    else
                    {
                        _currentProductGroupTable.CREATE_USER = _userInfo.CODE;
                        bProductGroup.Add(_currentProductGroupTable);
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
                strErrorlog += "编号不能为空!\r\n";
            }

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                strErrorlog += "名称不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (CTools.GetTextBoxLength(txtName.Text) > txtName.MaxLength)
                txtName.Text = CTools.textSpilt(txtName.Text, txtName.MaxLength);

            return true;
        }
        #endregion
        
        private void FrmProductGroupDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        #region 上级商品类别
        private void btnParentCode_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCT_GROUP", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtParentCode.Text = frm.BaseMasterTable.Code;
                    txtParentName.Text = frm.BaseMasterTable.Name;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtParentCode_Leave(object sender, EventArgs e)
        {
            string parent = txtParentCode.Text.Trim();
            if (!string.IsNullOrEmpty(parent))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("PRODUCT_GROUP", parent);
                if (baseMaster != null)
                {
                    txtParentCode.Text = baseMaster.Code;
                    txtParentName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("上级商品种类不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtParentCode.Text = "";
                    txtParentName.Text = "";
                    txtParentCode.Focus();
                }
            }
            else
            {
                txtParentName.Text = "";
            }
        }
        #endregion

        private void FrmProductGroupDialog_Shown(object sender, EventArgs e)
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

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                BaseProductGroupTable ProductGroupCode = new BaseProductGroupTable();
                ProductGroupCode = bProductGroup.GetModel(txtCode.Text);
                if (ProductGroupCode != null)
                {
                    txtCode.Focus();
                    txtCode.Text = "";
                    MessageBox.Show("编号已存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region 默认供应商
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    txtSecondSupplier.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (!string.IsNullOrEmpty(SupplierCode))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                    txtSecondSupplier.Focus();
                }
                else
                {
                    MessageBox.Show("默认供应商不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region 供应商2
        private void btnSecondSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSecondSupplier.Text = frm.BaseMasterTable.Code;
                    txtSecondSupplierName.Text = frm.BaseMasterTable.Name;
                    txtthirdSupplier.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSecondSupplier_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSecondSupplier.Text.Trim();
            if (!string.IsNullOrEmpty(SupplierCode))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtSecondSupplier.Text = baseMaster.Code;
                    txtSecondSupplierName.Text = baseMaster.Name;
                    txtthirdSupplier.Focus();
                }
                else
                {
                    MessageBox.Show("供应商编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSecondSupplier.Text = "";
                    txtSecondSupplierName.Text = "";
                    txtSecondSupplier.Focus();
                }
            }
            else
            {
                txtSecondSupplierName.Text = "";
            }
        }
        #endregion

        #region 供应商3
        private void btnThirdSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtthirdSupplier.Text = frm.BaseMasterTable.Code;
                    txtThirdSupplierName.Text = frm.BaseMasterTable.Name;
                    txtthirdSupplier.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtthirdSupplier_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtthirdSupplier.Text.Trim();
            if (!string.IsNullOrEmpty(SupplierCode))
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtthirdSupplier.Text = baseMaster.Code;
                    txtThirdSupplierName.Text = baseMaster.Name;
                    btnSave.Focus();
                }
                else
                {
                    MessageBox.Show("供应商编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtthirdSupplier.Text = "";
                    txtThirdSupplierName.Text = "";
                    txtthirdSupplier.Focus();
                }
            }
            else
            {
                txtThirdSupplierName.Text = "";
            }
        }
        #endregion        

    }//end class
}
