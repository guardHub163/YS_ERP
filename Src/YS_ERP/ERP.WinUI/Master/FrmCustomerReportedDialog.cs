using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmCustomerReportedDialog : Form
    {

        private BaseUserTable _userInfo;
        private BaseCustomerReportedTable _currentCustomerReportedTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BCommon bCommon = new BCommon();
       
        private BCustomerReported bCustomerReported = new BCustomerReported();

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
        public BaseCustomerReportedTable CurrentCustomerReportedtTable
        {
            get { return _currentCustomerReportedTable; }
            set { _currentCustomerReportedTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmCustomerReportedDialog()
        {
            InitializeComponent();
        }

        private void FrmCustomerReportedDialog_Load(object sender, EventArgs e)
        {
            if (_currentCustomerReportedTable != null)
            {
                txtCustomer.Text = _currentCustomerReportedTable.CUSTOMER_CODE;
                txtCustomerName.Text = bCommon.GetBaseMaster("CUSTOMER", _currentCustomerReportedTable.CUSTOMER_CODE).Name;
                txtReported.Text = _currentCustomerReportedTable.CUSTOMER_REPORTED_CODE;
                txtReportedName.Text = bCommon.GetBaseMaster("CUSTOMER", _currentCustomerReportedTable.CUSTOMER_REPORTED_CODE).Name;
                ReportedDate.Value = _currentCustomerReportedTable.REPORTED_DATE;
                EffectiveDate.Value = _currentCustomerReportedTable.EFFECTIVE_DATE;
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCustomer.BackColor = Color.WhiteSmoke;
                txtReported.BackColor = Color.WhiteSmoke;
                txtCustomer.Enabled = false;
                txtReported.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCustomer.Text = "";
                txtCustomerName.Text = "";
                txtReported.Text = "";
                txtReportedName.Text = "";
            }
        }

        private void FrmCustomerReportedDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentCustomerReportedTable == null)
                {
                    _currentCustomerReportedTable = new BaseCustomerReportedTable();
                }

                _currentCustomerReportedTable.CUSTOMER_CODE = txtCustomer.Text.Trim();
                _currentCustomerReportedTable.CUSTOMER_REPORTED_CODE = txtReported.Text.Trim();
                _currentCustomerReportedTable.REPORTED_DATE = ReportedDate.Value;
                _currentCustomerReportedTable.EFFECTIVE_DATE = EffectiveDate.Value;
                _currentCustomerReportedTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bCustomerReported.Exists(txtCustomer.Text.Trim(), txtReported.Text.Trim()))
                    {
                        bCustomerReported.Update(_currentCustomerReportedTable);
                    }
                    else
                    {
                        _currentCustomerReportedTable.CREATE_USER = _userInfo.CODE;
                        bCustomerReported.Add(_currentCustomerReportedTable);
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
            if (string.IsNullOrEmpty(this.txtCustomer.Text.Trim()))
            {
                strErrorlog += "代理店不能为空!\r\n";
            }
          
            if (string.IsNullOrEmpty(this.txtReported.Text.Trim()))
            {
                strErrorlog += "报备客户名称不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if(CTools.GetTextBoxLength(txtReported.Text) > txtReported.MaxLength)
            {
                txtReported.Text = CTools.textSpilt(txtReported.Text,txtReported.MaxLength);
            }
            return true;
        }
        #endregion

        #region 取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                result = DialogResult.Cancel;
                this.Close();
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
        }
       
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtCustomer.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (ReportedDate.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }
        #endregion

        #region 客户
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Customer", "TYPE = 1");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustomer.Text = frm.BaseMasterTable.Code;
                    txtCustomerName.Text = frm.BaseMasterTable.Name;
                    txtCustomer.Focus();
                    txtReported.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtCustomer_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCustomer.Text.Trim()) && !string.IsNullOrEmpty(this.txtReported.Text.Trim()))
            {
                BaseCustomerReportedTable CustomerReportedCode = new BaseCustomerReportedTable();
                CustomerReportedCode = bCustomerReported.GetModel(txtCustomer.Text, txtReported.Text);
                if (CustomerReportedCode != null)
                {
                    txtCustomer.Text = "";
                    txtReported.Text = "";
                    txtCustomer.Focus();
                    MessageBox.Show("代理店与报备名称已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            //if (!string.IsNullOrEmpty(txtCustomer.Text.Trim()))
            //{
            //    BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", txtCustomer.Text.Trim());
            //    if (baseMaster != null)
            //    {
            //        txtCustomer.Text = baseMaster.Code;
            //        txtCustomerName.Text = baseMaster.Name;
            //    }
            //    else
            //    {
            //        MessageBox.Show("代理店不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtCustomer.Text = "";
            //        txtCustomerName.Text = "";
            //        txtCustomer.Focus();
            //    }
            //}
            //else
            //{
            //    txtCustomerName.Text = "";
            //}

            string customerCode = txtCustomer.Text.Trim();
            if (customerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", customerCode, "TYPE = 1");
                if (baseMaster != null)
                {
                    txtCustomer.Text = baseMaster.Code;
                    txtCustomerName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("代理店不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomer.Text = "";
                    txtCustomerName.Text = "";
                    txtCustomer.Focus();
                }
            }
            else
            {
                txtCustomerName.Text = "";
            }
        }
        #endregion

        #region 报备客户
        private void btnReported_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("Customer", "TYPE = 2");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtReported.Text = frm.BaseMasterTable.Code;
                    txtReportedName.Text = frm.BaseMasterTable.Name;
                    txtReported.Focus();
                    ReportedDate.Focus();
                }
            }
            frm.Dispose();
        }
        private void txtReported_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCustomer.Text.Trim()) && !string.IsNullOrEmpty(this.txtReported.Text.Trim()))
            {
                BaseCustomerReportedTable CustomerReportedCode = new BaseCustomerReportedTable();
                CustomerReportedCode = bCustomerReported.GetModel(txtCustomer.Text, txtReported.Text);
                if (CustomerReportedCode != null)
                {
                    txtCustomer.Text = "";
                    txtReported.Text = "";
                    txtCustomer.Focus();
                    MessageBox.Show("代理店与报备名称已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            //if (!string.IsNullOrEmpty(txtReported.Text.Trim()))
            //{
            //    BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", txtReported.Text.Trim());
            //    if (baseMaster != null)
            //    {
            //        txtReported.Text = baseMaster.Code;
            //        txtReportedName.Text = baseMaster.Name;
            //    }
            //    else
            //    {
            //        MessageBox.Show("报备客户不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtReported.Text = "";
            //        txtReportedName.Text = "";
            //        txtReported.Focus();
            //    }
            //}
            //else
            //{
            //    txtReportedName.Text = "";
            //}
            string endCustomerCode = txtReported.Text.Trim();
            if (endCustomerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", endCustomerCode, "TYPE = 2");
                if (baseMaster != null)
                {

                    txtReported.Text = baseMaster.Code;
                    txtReportedName.Text = baseMaster.Name;


                }
                else
                {
                    MessageBox.Show("报备客户不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReported.Text = "";
                    txtReportedName.Text = "";
                    txtReported.Focus();
                }
            }
            else
            {
                txtReportedName.Text = "";
            }
        }
        #endregion

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }

        private void ReportedDate_Leave(object sender, EventArgs e)
        {
            EffectiveDate.Value = ReportedDate.Value.AddMonths(3);
        }
    }
}
