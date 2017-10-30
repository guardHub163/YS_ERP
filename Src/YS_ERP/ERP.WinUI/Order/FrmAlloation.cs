using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.CacheData;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI
{
    public partial class FrmAlloation : FrmBase
    {
        //订单编号

        private DialogResult _dialogResult = DialogResult.Cancel;
        private string _slipNumber;

        public FrmAlloation()
        {
            InitializeComponent();
        }

        public FrmAlloation(string slipNumber)
        {
            InitializeComponent();
            _slipNumber = slipNumber;
        }

        private void FrmAlloation_Load(object sender, EventArgs e)
        {
            BllOrderHeaderTable headerTable = bOrderHeader.GetModel(_slipNumber);
            this.txtSlipNumber.Text = headerTable.SLIP_NUMBER;
            this.txtCustomerCode.Text = headerTable.CUSTOMER_CODE;
            this.txtCustomerName.Text = headerTable.CUSTOMER_NAME;
            this.txtEndCustomerCode.Text = headerTable.ENDER_CUSTOMER_CODE;
            this.txtEndCustomerName.Text = headerTable.ENDER_CUSTOMER_NAME;
            this.txtDeliveryPointCode.Text = headerTable.DELIVERY_POINT_CODE;
            this.txtDeliveryPointName.Text = headerTable.DELIVERY_POINT_NAME;
            this.txtOwnerPoNumber.Text = headerTable.CUSTOMER_PO_NUMBER;
            this.txtSlipDate.Text = CConvert.DateTimeToString(headerTable.SLIP_DATE, "yyyy-MM-dd");
            this.txtDepartualDate.Text = CConvert.DateTimeToString(headerTable.DEPARTUAL_DATE, "yyyy-MM-dd");

            DataGridViewComboBoxColumn co = this.dgvData.Columns["DEPARTUAL_WAREHOUSE"] as DataGridViewComboBoxColumn;
            co.DataSource = CCacheData.WAREHOUSE.Copy();
            co.DisplayMember = "NAME";
            co.ValueMember = "CODE";

            foreach (BllOrderLineTable lineModel in headerTable.Items)
            {
                decimal quantity = CConvert.ToDecimal(lineModel.QUANTITY) - CConvert.ToDecimal(lineModel.SHIPMENT_QUANTITY);
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                dgvr.Cells["NO"].Value = lineModel.LINE_NUMBER;
                dgvr.Cells["PRODUCT_CODE"].Value = lineModel.PRODUCT_CODE;
                dgvr.Cells["PRODUCT_NAME"].Value = lineModel.PRODUCT_NAME;
                dgvr.Cells["PRODUCT_SPEC"].Value = lineModel.PRODUCT_SPEC;
                dgvr.Cells["QUANTITY"].Value = quantity;
                dgvr.Cells["UNIT_CODE"].Value = lineModel.UNIT_NAME;
                dgvr.Cells["UNIT_NAME"].Value = lineModel.UNIT_NAME;
                dgvr.Cells["REF_STOCK"].Value = "参照";

                //当前己引当的仓库的取得
                BaseWarehouseTable warehouseTable = bAlloation.GetAlloationWarehouse(headerTable.SLIP_NUMBER, lineModel.LINE_NUMBER);
                string warehouseCode = warehouseTable.CODE;
                if (warehouseCode != null && warehouseCode != "")
                {
                    ((DataGridViewComboBoxCell)dgvr.Cells["DEPARTUAL_WAREHOUSE"]).Style.NullValue = warehouseTable.NAME + " ";
                }
                else
                {
                    warehouseCode = headerTable.DEPARTUAL_WAREHOUSE_CODE;
                    ((DataGridViewComboBoxCell)dgvr.Cells["DEPARTUAL_WAREHOUSE"]).Style.NullValue = headerTable.DEPARTUAL_WAREHOUSE_NAME + " ";
                }
                dgvr.Cells["DEFAULT_WAREHOUSE_CODE"].Value = warehouseCode;

                //当前仓库实际库存的取得
                BaseStockTable stockTable = bStock.GetModel(warehouseCode, lineModel.PRODUCT_CODE);
                decimal stock = 0;
                if (stockTable != null)
                {
                    stock = CConvert.ToDecimal(stockTable.QUANTITY);
                }

                //己使用的引当数量,当前订单除外,己出库数量除外
                stock -= bAlloation.GetAlloationQuantity(headerTable.SLIP_NUMBER, warehouseCode, lineModel.PRODUCT_CODE);

                dgvr.Cells["STOCK"].Value = stock;

                dgvr.Cells["ALLOATION_QUANTITY"].Value = quantity;

                if (quantity > stock)
                {
                    dgvr.Cells["IS_ALLOATION"].Value = "NG";                   
                }
                else
                {
                    dgvr.Cells["IS_ALLOATION"].Value = "OK";                   
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAlloation_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = _dialogResult;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["DEPARTUAL_WAREHOUSE"].Index)
                {
                    string warehouseCode = CConvert.ToString(dgvr.Cells["DEPARTUAL_WAREHOUSE"].Value);
                    string productCode = CConvert.ToString(dgvr.Cells["PRODUCT_CODE"].Value);
                    string orderSlipNumber = CConvert.ToString(txtSlipNumber.Text);

                    BaseStockTable stockTable = bStock.GetModel(warehouseCode, productCode);
                    decimal stock = 0;
                    if (stockTable != null)
                    {
                        stock = CConvert.ToDecimal(stockTable.QUANTITY);
                    }

                    stock -= bAlloation.GetAlloationQuantity(orderSlipNumber, warehouseCode, productCode);

                    dgvr.Cells["STOCK"].Value = stock;

                    decimal quantity = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                    decimal alloationQuantity = CConvert.ToDecimal(dgvr.Cells["ALLOATION_QUANTITY"].Value);

                    if (alloationQuantity > stock)
                    {
                        dgvr.Cells["IS_ALLOATION"].Value = "NG";
                        dgvr.DefaultCellStyle.BackColor = COLOR_NG;
                    }
                    else
                    {
                        dgvr.Cells["IS_ALLOATION"].Value = "OK";

                        if (e.RowIndex % 2 == 0)
                        {
                            dgvr.DefaultCellStyle.BackColor = Color.White;
                        }
                        else
                        {
                            dgvr.DefaultCellStyle.BackColor = COLOR_DIFF_ROW;
                        }
                    }
                }
            }
        }

        private void dgvData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvData.IsCurrentCellDirty)
            {
                dgvData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// 引当确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlloation_Click(object sender, EventArgs e)
        {
            List<BllAlloationTable> dataList = new List<BllAlloationTable>();
            BllAlloationTable alloationTable = null;


            int alloationStatus = CConstant.ALLOATION_COMPLETE;

            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                alloationTable = new BllAlloationTable();

                decimal alloationQuantity = CConvert.ToDecimal(dgvr.Cells["ALLOATION_QUANTITY"].Value);
                decimal quantity = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);
                if (alloationQuantity > 0 && "OK".Equals(dgvr.Cells["IS_ALLOATION"].Value))
                {
                    alloationTable.ORDER_SLIP_NUMBER = _slipNumber;
                    alloationTable.ORDER_LINE_NUMBER = CConvert.ToInt32(dgvr.Cells["NO"].Value);
                    alloationTable.PRODUCT_CODE = CConvert.ToString(dgvr.Cells["PRODUCT_CODE"].Value);
                    alloationTable.QUANTITY = alloationQuantity;
                    alloationTable.UNIT_CODE = CConvert.ToString(dgvr.Cells["UNIT_CODE"].Value);
                    alloationTable.WAREHOUSE_CODE = CConvert.ToString(dgvr.Cells["DEPARTUAL_WAREHOUSE"].Value);
                    if ("".Equals(alloationTable.WAREHOUSE_CODE))
                    {
                        alloationTable.WAREHOUSE_CODE = CConvert.ToString(dgvr.Cells["DEFAULT_WAREHOUSE_CODE"].Value);
                    }

                    if (alloationQuantity == quantity)
                    {
                        alloationTable.STATUS_FLAG = CConstant.ALLOATION_COMPLETE;
                    }
                    else
                    {
                        alloationTable.STATUS_FLAG = CConstant.ALLOATION_PART;
                        alloationStatus = CConstant.ALLOATION_PART;
                    }

                    alloationTable.CREATE_USER = UserTable.CODE;
                    alloationTable.LAST_UPDATE_USER = UserTable.CODE;

                    dataList.Add(alloationTable);
                }
            }

            //未引当
            if (dataList.Count == 0)
            {
                alloationStatus = CConstant.ALLOATION_UN;
            }
            else if (dataList.Count < dgvData.Rows.Count)
            {
                alloationStatus = CConstant.ALLOATION_PART;
            }

            if (dataList.Count > 0 && bAlloation.Add(dataList, alloationStatus) > 0)
            {
                MessageBox.Show("引当完成。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _dialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// DataGridView 页面初始化输入框式样
        /// </summary>
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 && (e.ColumnIndex == 1))
            {
                DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                dgvr.Cells["ALLOATION_QUANTITY"].Style.BackColor = System.Drawing.SystemColors.Info;

                if ("NG".Equals(dgvr.Cells["IS_ALLOATION"].Value))
                {
                    dgvr.DefaultCellStyle.BackColor = COLOR_NG;
                }
                else
                {
                    if (e.RowIndex % 2 == 0)
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        dgvr.DefaultCellStyle.BackColor = COLOR_DIFF_ROW;
                    }
                }
            }

        }

        /// <summary>
        /// DataGridView　引当数量的验证
        /// </summary>
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["ALLOATION_QUANTITY"].Index)
                {
                    //

                    //未引当数量
                    decimal quantity = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);

                    //引当数
                    decimal alloationQuantity = CConvert.ToDecimal(dgvr.Cells["ALLOATION_QUANTITY"].Value);

                    //利用可能引当数量
                    decimal stockQuantity = CConvert.ToDecimal(dgvr.Cells["STOCK"].Value);

                    if (alloationQuantity == 0)
                    {
                        try
                        {
                            decimal.Parse(CConvert.ToString(dgvr.Cells["ALLOATION_QUANTITY"].Value));
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的引当数量。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            alloationQuantity = quantity;
                        }
                    }
                    else if (alloationQuantity < 0)
                    {
                        MessageBox.Show("引当数量不能为负数。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        alloationQuantity = quantity;
                    }
                    else if (alloationQuantity > quantity)
                    {
                        MessageBox.Show("引当数量不能大于未引当数量。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        alloationQuantity = quantity;
                    }

                    dgvr.Cells["ALLOATION_QUANTITY"].Value = alloationQuantity;

                    if (alloationQuantity > stockQuantity)
                    {
                        dgvr.Cells["IS_ALLOATION"].Value = "NG";
                        dgvr.DefaultCellStyle.BackColor = COLOR_NG;
                    }
                    else if (alloationQuantity <= stockQuantity)
                    {
                        dgvr.Cells["IS_ALLOATION"].Value = "OK";
                        if (e.RowIndex % 2 == 0)
                        {
                            dgvr.DefaultCellStyle.BackColor = Color.White;
                        }
                        else
                        {
                            dgvr.DefaultCellStyle.BackColor = COLOR_DIFF_ROW;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 行点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["REF_STOCK"].Index)
                {
                    string productCode = CConvert.ToString(dgvr.Cells["PRODUCT_CODE"].Value);
                    FrmStockSearch frm = new FrmStockSearch("", productCode);
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
            }
        }

        bool HasAttachEvent = false;
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!this.HasAttachEvent) // 注册事件
            {
                e.Control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "ALLOATION_QUANTITY")
                    {
                        InputDouble(o, c);
                    }
                    else
                    {
                        return;
                    }

                    //if (this.dgvData.CurrentCell.ColumnIndex == 1) return; // 第二列不验证
                    //if (!char.IsNumber(c.KeyChar)) c.Handled = true;
                });

                this.HasAttachEvent = true;
            }
        }

    }//end class
}
