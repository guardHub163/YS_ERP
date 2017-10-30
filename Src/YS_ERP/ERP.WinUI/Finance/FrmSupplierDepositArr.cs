using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmSupplierDepositArr : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BSupplierDepositArr bDepositArr = new BSupplierDepositArr();

        #region init
        public FrmSupplierDepositArr()
        {
            InitializeComponent();
        }

        private void FrmDepositArr_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            InitPage();
        }

        private void InitPage()
        {
            this.txtSlipNumber.Text = CConvert.ToString(CConvert.ToInt32(bDepositArr.GetMaxID()) + 1);
            this.txtSupplierCode.Text = "";
            this.txtSupplierName.Text = "";
            this.txtBalance.Text = "";
            dgvData.Rows.Clear();
        }
        #endregion
       

        #region 供应商
        /// <summary>
        /// 
        /// </summary>
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    txtDate.Focus();
                }
            }
            frm.Dispose();
            txtBalance.Text = CConvert.ToString(GetSupplierDepositBlanace(txtSupplierCode.Text.Trim()));
        }

        /// <summary>
        /// 
        /// </summary>
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
                    txtBalance.Text = CConvert.ToString(GetSupplierDepositBlanace(txtSupplierCode.Text.Trim()));
                }
                else
                {
                    MessageBox.Show("供应商编号不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierCode.Text = "";
                    txtSupplierName.Text = "";
                    txtBalance.Text = "";
                    txtSupplierCode.Focus();
                }
            }
            else 
            {
                txtSupplierName.Text = "";
                txtBalance.Text = "";
            }
            
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region dgvData 处理
        /// <summary>
        /// 
        /// </summary>
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex == -1 && (e.ColumnIndex == 1))
            {
                CellPainting(dgv, 2, "采购编号", e);

                e.Handled = true;
            }

            if (e.RowIndex != -1 && (e.ColumnIndex == 1))
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                Color color = System.Drawing.SystemColors.Info;
                row.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Style.BackColor = color;
                row.Cells["AMOUNT"].Style.BackColor = color;
                row.Cells["MEMO"].Style.BackColor = color;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvData.Columns["BTN_SLIP_NUMBER"].Index)
                {
                    FrmPurchaseOrderSearch frm = new FrmPurchaseOrderSearch();
                    frm.CTag = CConstant.PURCHASE_ORDER_MASTER_SEARCH;

                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (!IsExist(frm.CurrentPurchaseOrderTable.SLIP_NUMBER, null))
                        {
                            if (frm.CurrentPurchaseOrderTable != null)
                            {
                                DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                                string slipNumber = frm.CurrentPurchaseOrderTable.SLIP_NUMBER;
                                dr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value = slipNumber;
                                dr.Cells["TOTAL_AMOUNT"].Value = frm.CurrentPurchaseOrderTable.TOTAL_AMOUNT;
                                dr.Cells["PURCHASE_ORDER_SLIP_DATE"].Value = CConvert.ToDateTime(frm.CurrentPurchaseOrderTable.SLIP_DATE).ToString("yyyy-MM-dd");
                                dr.Cells["ARR_AMOUNT"].Value = bDepositArr.GetArrAmount(slipNumber);
                            }
                        }

                    }
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["PURCHASE_ORDER_SLIP_NUMBER"].Index)
                {
                    string purchaseOrderSlipNumber = CConvert.ToString(dr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value).Trim();
                    string no = CConvert.ToString(dr.Cells["NO"].Value).Trim();
                    if (purchaseOrderSlipNumber != "")
                    {

                        BllPurchaseOrderTable purchaseOrderTable = bPurchaseOrder.GetModel(purchaseOrderSlipNumber);
                        if (purchaseOrderTable != null)
                        {
                            if (!IsExist(purchaseOrderSlipNumber, no))
                            {
                                dr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value = purchaseOrderTable.SLIP_NUMBER;
                                dr.Cells["PURCHASE_ORDER_SLIP_DATE"].Value = CConvert.ToDateTime(purchaseOrderTable.SLIP_DATE).ToString("yyyy-MM-dd");
                                dr.Cells["TOTAL_AMOUNT"].Value = purchaseOrderTable.TOTAL_AMOUNT;
                                dr.Cells["ARR_AMOUNT"].Value = bDepositArr.GetArrAmount(purchaseOrderTable.SLIP_NUMBER);
                            }
                        }
                        else
                        {
                            MessageBox.Show("订单编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value = "";
                            dr.Cells["PURCHASE_ORDER_SLIP_DATE"].Value = "";
                            dr.Cells["TOTAL_AMOUNT"].Value = "";
                            dr.Cells["ARR_AMOUNT"].Value = "0";
                            dr.Cells["AMOUNT"].Value = "";
                        }
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["AMOUNT"].Index)
                {
                    string amount = CConvert.ToString(dr.Cells["AMOUNT"].Value);

                    if (amount == "")
                    {
                        dr.Cells["AMOUNT"].Value = 0;
                    }
                    else
                    {
                        dr.Cells["AMOUNT"].Value = CConvert.ToDecimal(amount);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("CellValidated error!", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void dgvData_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// DataGridView 行添加No的顺序的初始写入
        /// </summary>
        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvData.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
        }

        /// <summary>
        ///  DataGridView 行添加
        /// </summary>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if ("".Equals(CConvert.ToString(dr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value).Trim()))
                {
                    dr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Selected = true;
                    return;
                }
            }
            int currentRowIndex = dgvData.Rows.Add(1);
            DataGridViewRow row = dgvData.Rows[currentRowIndex];
        }

        /// <summary>
        /// DataGridView 行删除
        /// </summary>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    dgvData.Rows.Remove(dgvData.CurrentRow);
                    reSetNo();
                }
            }
        }

        /// <summary>
        /// DataGridView 行NUMBER的重新排序
        /// </summary>
        private void reSetNo()
        {
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                dr.Cells["NO"].Value = dr.Index + 1;
            }
        }

        private bool IsExist(string orderSlipNumber, string no)
        {
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (CConvert.ToString(dgvr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value).Equals(orderSlipNumber))
                {
                    if (no != null && CConvert.ToString(dgvr.Cells["NO"].Value).Equals(no))
                    {
                        continue;
                    }
                    MessageBox.Show("订单编号己经存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (no != null)
                    {
                        dgvr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value = "";
                        dgvr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Selected = true;
                    }
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 数据保存

        /// <summary>
        /// 数据保存
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }

            BllSupplierDepositArrTable depositArrTable = new BllSupplierDepositArrTable();
            depositArrTable.SLIP_NUMBER = this.txtSlipNumber.Text.Trim();
            depositArrTable.SLIP_DATE = this.txtDate.Value;
            depositArrTable.SUPPLIER_CODE = this.txtSupplierCode.Text;
            depositArrTable.STATUS_FLAG = CConstant.NORMAL;
            depositArrTable.CREATE_USER = UserTable.CODE;
            depositArrTable.LAST_UPDATE_USER = UserTable.CODE;
            depositArrTable.COMPANY_CODE = UserTable.COMPANY_CODE;

            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                BllSupplierDepositArrLineTable depositArrLineTable = new BllSupplierDepositArrLineTable();
                depositArrLineTable.LINE_NUMBER = CConvert.ToInt32(dgvr.Cells["NO"].Value);
                depositArrLineTable.PURCHASE_ORDER_SLIP_NUMBER = CConvert.ToString(dgvr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value);
                depositArrLineTable.ARR_AMOUNT = CConvert.ToDecimal(dgvr.Cells["AMOUNT"].Value);
                depositArrLineTable.MEMO = CConvert.ToString(dgvr.Cells["MEMO"].Value);
                depositArrLineTable.STATUS_FLAG = CConstant.NORMAL;
                depositArrTable.addLineTable(depositArrLineTable);
            }

            try
            {
                if (bDepositArr.Add(depositArrTable) > 0)
                {
                    MessageBox.Show("保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitPage();
                }
                else
                {
                    MessageBox.Show("保存失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.Error("预付款分配输入保存失败。", ex);
            }

        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtSupplierCode.Text.Trim()))
            {
                MessageBox.Show("客户编号不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierCode.Focus();
                return false;
            }
            else if (dgvData.Rows.Count <= 0)
            {
                MessageBox.Show("明细行数必须大于零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAddRow.Focus();
                return false;
            }

            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                string orderSlipNumber = CConvert.ToString(dgvr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Value).Trim();
                if (orderSlipNumber == "")
                {
                    MessageBox.Show("明细行订单编号不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvr.Cells["PURCHASE_ORDER_SLIP_NUMBER"].Selected = true;
                    return false;
                }
                decimal amount = CConvert.ToDecimal(dgvr.Cells["AMOUNT"].Value);
                if (amount <= 0)
                {
                    MessageBox.Show("明细行金额必须大于零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvr.Cells["AMOUNT"].Selected = true;
                    return false;
                }
            }
            return true;
        }
        #endregion

        bool HasAttachEvent = false;
        /// <summary>
        /// 输入控制
        /// </summary>
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            DataGridViewTextBoxEditingControl control = (DataGridViewTextBoxEditingControl)e.Control;

            if (!this.HasAttachEvent) // 注册事件
            {
                control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "AMOUNT")
                    {
                        InputAmount(o, c);
                    }
                    else
                    {
                        return;
                    }
                });

                this.HasAttachEvent = true;
            }
        }

        /// <summary>
        /// 禁止粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 禁止鼠标右键 未完
        /// </summary>
        private void dgvData_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.TextBox_KeyPress(sender, e);
        }




    }//end class
}
