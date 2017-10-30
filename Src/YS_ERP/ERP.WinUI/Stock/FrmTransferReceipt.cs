using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmTransferReceipt : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        public FrmTransferReceipt()
        {
            InitializeComponent();
        }

        private void FrmTransferReceipt_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            initSlipNumber();
        }

        #region 订单编号初始化
        public void initSlipNumber()
        {
            string maxSlipNumber = bTransfer.GetMaxSlipNumber();
            int number = Convert.ToInt32(maxSlipNumber) + 1;
            string slipNumber = number.ToString().PadLeft(4, '0');
            txtSlipNumber.Text = slipNumber;
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion 

        #region 调出仓库
        private void btnDepartual_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDepartualCode.Text = frm.BaseMasterTable.Code;
                    txtDepartualName.Text = frm.BaseMasterTable.Name;
                    txtArrivalCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtDepartualCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtDepartualCode.Text.Trim()))
            {
                BaseWarehouseTable Warehouse = new BaseWarehouseTable();
                BWarehouse bWarehouse = new BWarehouse();
                Warehouse = bWarehouse.GetModel(this.txtDepartualCode.Text);
                if (Warehouse == null || "".Equals(Warehouse))
                {
                    txtDepartualCode.Focus();
                    txtDepartualCode.Text = "";
                    txtDepartualName.Text = "";
                    MessageBox.Show("仓库编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtDepartualCode.Text = Warehouse.CODE;
                    txtDepartualName.Text = Warehouse.NAME;
                }
            }
            else
            {
                txtDepartualName.Text = "";
            }
        }
        #endregion

        #region 调入仓库
        private void btnArrival_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtArrivalCode.Text = frm.BaseMasterTable.Code;
                    txtArrivalName.Text = frm.BaseMasterTable.Name;
                    txtSlipDate.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtArrivalCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtArrivalCode.Text.Trim()))
            {
                BaseWarehouseTable Warehouse = new BaseWarehouseTable();
                BWarehouse bWarehouse = new BWarehouse();
                Warehouse = bWarehouse.GetModel(this.txtArrivalCode.Text);
                if (Warehouse == null || "".Equals(Warehouse))
                {
                    txtArrivalCode.Focus();
                    txtArrivalCode.Text = "";
                    txtArrivalName.Text = "";
                    MessageBox.Show("仓库编号不存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtArrivalCode.Text = Warehouse.CODE;
                    txtArrivalName.Text = Warehouse.NAME;
                }
            }
            else
            {
                txtArrivalName.Text = "";
            }
        }
        #endregion

        #region 增加一行
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (dr.Cells["PRODUCT_CODE"].Value == null || "".Equals(dr.Cells["PRODUCT_CODE"].Value.ToString().Trim()))
                {
                    dr.Cells["PRODUCT_CODE"].Selected = true;
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtDepartualCode.Text.Trim()) && !string.IsNullOrEmpty(txtArrivalCode.Text.Trim()))
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                //row.Cells[1].Selected = true;
            }
            else
            {
                MessageBox.Show("调出仓库和调入仓库都不能为空!");
            }
        }

        private void dgvData_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvData.Rows[e.RowIndex].Cells["No"].Value = e.RowIndex + 1;
        }
        #endregion

        #region 重绘表头
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex == -1 && (e.ColumnIndex == 1))
            {
                CellPainting(dgv, 2, "商品编号", e);
                e.Handled = true;
            }
        }
        #endregion

        #region 行点击事件
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvData.Columns["BtnProduct"].Index)
                {
                    FrmMasterSearch frm = new FrmMasterSearch("PRODUCT", "");
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        if (frm.BaseMasterTable != null)
                        {
                            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                            string code = frm.BaseMasterTable.Code;
                            BaseProductTable productTable = bProduct.GetModel(code);
                            BaseStockTable stock = bStock.GetModel(txtDepartualCode.Text.Trim(), productTable.CODE);
                            BAlloation bAlloation = new BAlloation();
                            if (productTable != null)
                            {
                                dr.Cells["PRODUCT_CODE"].Value = productTable.CODE;
                                dr.Cells["PRODUCT_NAME"].Value = productTable.NAME;
                                decimal alloationQuantity = bAlloation.GetAlloationQuantity(txtDepartualCode.Text.Trim(), productTable.CODE);
                                dr.Cells["QUANTITY"].Value = stock.QUANTITY - alloationQuantity;
                                dr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                dr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                dr.Cells["TRANSFER_QUANTITY"].Value = "1";
                            }
                            else
                            {
                                MessageBox.Show("商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dr.Cells["QUANTITY"].Value = "0";
                                dr.Cells["CODE"].Selected = true;
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
        #endregion

        #region 行删除
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
                dr.Cells["No"].Value = dr.Index + 1;
            }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                BllTransferReceiptTable TRTable = new BllTransferReceiptTable();
                BllTransferReceiptLineTable TRLTable = null;

                TRTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
                TRTable.DEPARTUAL_WAREHOUSE_CODE = txtDepartualCode.Text.Trim();
                TRTable.ARRIVAL_WAREHOUSE_CODE = txtArrivalCode.Text.Trim();
                TRTable.SLIP_DATE = txtSlipDate.Value;
                TRTable.CREATE_USER = _userInfo.CODE;
                TRTable.LAST_UPDATE_USER = _userInfo.CODE;

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    TRLTable = new BllTransferReceiptLineTable();
                    TRLTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
                    TRLTable.LINE_NUMBER = row.Index + 1;
                    TRLTable.PRODUCT_CODE = row.Cells["PRODUCT_CODE"].Value.ToString();
                    TRLTable.QUANTITY = CConvert.ToDecimal(row.Cells["TRANSFER_QUANTITY"].Value);
                    TRLTable.UNIT_CODE = row.Cells["UNIT_CODE"].Value.ToString();

                    if (TRLTable.SLIP_NUMBER != null)
                    {
                        TRTable.AddItem(TRLTable);
                    }
                }

                int result = 0;
                try
                {
                    result = bTransfer.Add(TRTable);
                    if (result <= 0)
                    {
                        string errorLog = "保存失败,请重试或与管理员联系.";
                        MessageBox.Show(errorLog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else  if (dgvData.Rows.Count > 0)
                    {
                        dgvData.Rows.Clear();
                        initSlipNumber();
                        txtDepartualCode.Text = "";
                        txtDepartualName.Text = "";
                        txtArrivalCode.Text = "";
                        txtArrivalName.Text = "";
                        txtSlipDate.Value = DateTime.Now;
                        MessageBox.Show("保存成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败,系统错误,请与管理员联系.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("仓库调拨失败！", ex);
                }
            }
        }

        private bool CheckInput()
        {
            string strErrorlog = null;
            
            foreach (DataGridViewRow row in dgvData.Rows )
            {
                if (CConvert.ToDecimal(row.Cells["QUANTITY"].Value) == 0)
                {
                    strErrorlog += "第" + (row.Index +1) + "行" + "库存数不能为0!\r\n";
                }

                if (CConvert.ToDecimal(row.Cells["TRANSFER_QUANTITY"].Value) <= 0 || row.Cells["TRANSFER_QUANTITY"] == null)
                {
                    strErrorlog += "第" + (row.Index + 1) + "行" + "调拨数量不能为空或输入错误!\r\n";
                }

                if (CConvert.ToDecimal(row.Cells["QUANTITY"].Value) < CConvert.ToDecimal(row.Cells["TRANSFER_QUANTITY"].Value))
                {
                    strErrorlog += "第" + (row.Index + 1) + "行" + "库存数量不能小于调拨数量!\r\n";
                    row.Cells["TRANSFER_QUANTITY"].Value = 0;
                } 
            }

            if (strErrorlog != null || "".Equals(strErrorlog))
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        #endregion 

        #region 按键顺序
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //System.Windows.Forms.SendKeys.Send("+{Tab}");
                this.SelectNextControl(this.ActiveControl, false, true, true, false);
            }
            if (e.KeyCode == Keys.Down)
            {
                //System.Windows.Forms.SendKeys.Send("{Tab}");
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
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

        #region DataGridView 验证
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["PRODUCT_CODE"].Index)
                {
                    string code = dr.Cells["PRODUCT_CODE"].Value.ToString().Trim();
                    BaseProductTable productTable = bProduct.GetModel(code);

                    if (productTable != null)
                    {
                        dr.Cells["PRODUCT_CODE"].Value = productTable.CODE;
                        dr.Cells["PRODUCT_NAME"].Value = productTable.NAME;

                        BaseStockTable stock = bStock.GetModel(txtDepartualCode.Text.Trim(), productTable.CODE);
                        BAlloation bAlloation = new BAlloation();
                        decimal alloationQuantity = bAlloation.GetAlloationQuantity(txtDepartualCode.Text.Trim(), productTable.CODE);
                        dr.Cells["QUANTITY"].Value = stock.QUANTITY - alloationQuantity;
                        dr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                        dr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                        dr.Cells["TRANSFER_QUANTITY"].Value = "1";
                    }
                    else
                    {
                        MessageBox.Show("商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dr.Cells["PRODUCT_CODE"].Value = null;
                        dr.Cells["PRODUCT_NAME"].Value = null;
                        dr.Cells["QUANTITY"].Value = "0";
                        dr.Cells["UNIT_NAME"].Value = null;
                        dr.Cells["UNIT_CODE"].Value = null;
                        dr.Cells["TRANSFER_QUANTITY"].Value = "0";
                        dr.Cells["CODE"].Selected = true;
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["TRANSFER_QUANTITY"].Index)
                {
                    if (dr.Cells["TRANSFER_QUANTITY"].Value == null)
                    {
                        dr.Cells["TRANSFER_QUANTITY"].Value = 0;
                        MessageBox.Show("调拨数量不能为空!");
                    }
                    else
                    {
                        Int32 price;
                        if (!Int32.TryParse(CConvert.ToString(dr.Cells["TRANSFER_QUANTITY"].Value),
                            System.Globalization.NumberStyles.Integer,
                            System.Globalization.NumberFormatInfo.CurrentInfo, out price))
                        {
                            MessageBox.Show("调拨数量只能为整数，请重新输入!");
                            dr.Cells["TRANSFER_QUANTITY"].Value = "0";
                            dr.Cells["TRANSFER_QUANTITY"].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("PRODUCT_CODE");
                Logger.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// 控制dgvData只能输入整数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "TRANSFER_QUANTITY")
            {
                e.Control.KeyPress += new KeyPressEventHandler(InputInteger);
            }
        }
        #endregion 

        
    }
}
