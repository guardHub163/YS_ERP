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
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmStockAdjustment : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        public FrmStockAdjustment()
        {
            InitializeComponent();
        }

        private void FrmStockAdjustment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            initSlipNumber();
            DataGridViewComboBoxColumn cbo = this.dgvData.Columns["REASON"] as DataGridViewComboBoxColumn;
            cbo.DefaultCellStyle.NullValue = "--请选择--";
            //cbo.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            cbo.ValueMember = "CODE";
            cbo.DisplayMember = "NAME";
            cbo.DataSource = CCacheData.Reason.Copy();
        }

        #region 订单初始化
        public void initSlipNumber()
        {
            string maxSlipNumber = bStock.GetMaxSlipNumber();
            int number = Convert.ToInt32(maxSlipNumber) + 1;
            string slipNumber = number.ToString().PadLeft(4, '0');
            txtSlipNumber.Text = slipNumber;
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
            if (!string.IsNullOrEmpty(txtWarehouseCode.Text.Trim()))
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells[1].Selected = true;

                //DataGridViewComboBoxColumn cbo = this.dgvData.Columns["REASON"] as DataGridViewComboBoxColumn;
                //cbo.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                //cbo.ValueMember = "CODE";
                //cbo.DisplayMember = "NAME";
                //cbo.DataSource = CCacheData.Reason.Copy(); 
                //cbo.DefaultCellStyle.NullValue = "损坏";
                //cbo.DataPropertyName = cbo.Items[0].ToString();
            }
            else
            {
                MessageBox.Show("仓库编号不能为空!");
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
                            BaseStockTable stock = bStock.GetModel(txtWarehouseCode.Text.Trim(), productTable.CODE);
                            if (productTable != null)
                            {
                                dr.Cells["PRODUCT_CODE"].Value = productTable.CODE;
                                dr.Cells["PRODUCT_NAME"].Value = productTable.NAME;
                                dr.Cells["SPEC"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                                if (stock != null)
                                {
                                    dr.Cells["QUANTITY"].Value = CConvert.ToString(stock.QUANTITY);
                                }
                                else
                                {
                                    dr.Cells["QUANTITY"].Value = 0;
                                }
                                if (!string.IsNullOrEmpty(productTable.BASIC_UNIT_CODE))
                                {
                                    dr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                                    dr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                                }
                                dr.Cells["SANCTION_NUMBER"].Value = "1";

                                //DataGridViewComboBoxColumn cbo = (DataGridViewComboBoxColumn)this.dgvData.Columns["REASON"];
                                //MessageBox.Show(cbo.Items[0]);

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
                }
            }
            frm.Dispose();
        }

        private void txtWarehouseCode_Leave(object sender, EventArgs e)
        {
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
                {
                    txtWarehouseName.Text = Warehouse.NAME;
                }
            }

        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                BllHistoryStockTable HSTable = new BllHistoryStockTable();
                BllHistoryStockLineTable HSLTable = null;

                HSTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
                HSTable.SLIP_DATE = txtSlipDate.Value;
                HSTable.WAREHOUSE_CODE = txtWarehouseCode.Text.Trim();
                HSTable.CREATE_USER = _userInfo.CODE;
                HSTable.LAST_UPDATE_USER = _userInfo.CODE;

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells["PRODUCT_CODE"].Value != null)
                    {
                        HSLTable = new BllHistoryStockLineTable();
                        HSLTable.SLIP_NUMBER = txtSlipNumber.Text.Trim();
                        HSLTable.LINE_NUMBER = row.Index + 1;
                        HSLTable.PRODUCT_CODE = row.Cells["PRODUCT_CODE"].Value.ToString();
                        HSLTable.QUANTITY = CConvert.ToDecimal(row.Cells["SANCTION_NUMBER"].Value.ToString());
                        HSLTable.UNIT_CODE = row.Cells["UNIT_CODE"].Value.ToString();
                        HSLTable.REASON_CODE = row.Cells["REASON"].Value.ToString();

                        if (HSLTable.SLIP_NUMBER != null)
                        {
                            HSTable.AddItem(HSLTable);
                        }
                    }
                }

                int result = 0;
                try
                {
                    bool b = true;
                    result = bStock.AddHistory(HSTable);
                    if (result <= 0)
                    {
                        b = false;
                        string errorLog = "保存失败,请重试或与管理员联系.";
                        MessageBox.Show(errorLog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (b && dgvData.Rows.Count > 0)
                    {
                        dgvData.Rows.Clear();
                        initSlipNumber();
                        txtWarehouseCode.Text = "";
                        txtWarehouseName.Text = "";
                        MessageBox.Show("保存成功", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败,系统错误,请与管理员联系.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.Error("新建订单保存失败！", ex);
                }
            }
        }

        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断库存编号不能为空
            if (string.IsNullOrEmpty(this.txtSlipNumber.Text.Trim()))
            {
                strErrorlog += "库存编号不能为空!\r\n";
            }

            //判断名称不能为空
            if (string.IsNullOrEmpty(this.txtWarehouseCode.Text.Trim()))
            {
                strErrorlog += "仓库编号不能为空!\r\n";
            }

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["PRODUCT_CODE"].Value == null)
                {
                    strErrorlog += "第" + (row.Index + 1) + "行" + "商品不能为空!\r\n";
                }

                if (row.Cells["SANCTION_NUMBER"].Value == null)
                {
                    strErrorlog += "第" + (row.Index + 1) + "行" + "处分数不能为空!\r\n";
                }

                if (row.Cells["REASON"].Value == null)
                {
                    strErrorlog += "第" + (row.Index + 1) + "行" + "理由不能为空!\r\n";
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

        #region 关闭
        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
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
                        dr.Cells["SPEC"].Value = productTable.SPEC + " " + productTable.MODEL_NUMBER;
                        dr.Cells["UNIT_NAME"].Value = bCommon.GetBaseMaster("UNIT", productTable.BASIC_UNIT_CODE).Name;
                        dr.Cells["UNIT_CODE"].Value = productTable.BASIC_UNIT_CODE;
                        dr.Cells["SANCTION_NUMBER"].Value = "1";
                        BaseStockTable stock = bStock.GetModel(txtWarehouseCode.Text.Trim(), productTable.CODE);
                        if (stock == null)
                        {
                            dr.Cells["QUANTITY"].Value = "0";
                        }
                        else
                        {
                            dr.Cells["QUANTITY"].Value = stock.QUANTITY;
                        }

                    }
                    else
                    {
                        MessageBox.Show("商品不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dr.Cells["PRODUCT_CODE"].Value = null;
                        dr.Cells["PRODUCT_NAME"].Value = null;
                        dr.Cells["SPEC"].Value = null;
                        dr.Cells["QUANTITY"].Value = "0";
                        dr.Cells["UNIT_NAME"].Value = null;
                        dr.Cells["UNIT_CODE"].Value = null;
                        dr.Cells["SANCTION_NUMBER"].Value = "0";
                        dr.Cells["CODE"].Selected = true;
                    }
                }
                else if (e.ColumnIndex == dgvData.Columns["SANCTION_NUMBER"].Index)
                {
                    if (dr.Cells["SANCTION_NUMBER"].Value == null)
                    {
                        dr.Cells["SANCTION_NUMBER"].Value = "0";
                        MessageBox.Show("修改数量不能为空!");
                    }
                    else
                    {
                        //Int32 price;
                        //if (!Int32.TryParse(CConvert.ToString(dr.Cells["SANCTION_NUMBER"].Value),
                        //    System.Globalization.NumberStyles.Integer,
                        //    System.Globalization.NumberFormatInfo.CurrentInfo, out price))
                        //{
                        //    MessageBox.Show("处分数只能为整数，请重新输入!");
                        //    dr.Cells["SANCTION_NUMBER"].Value = "0";
                        //    dr.Cells["SANCTION_NUMBER"].Selected = true;
                        //}
                        decimal sanctionNumber = CConvert.ToDecimal(dr.Cells["SANCTION_NUMBER"].Value);
                        decimal quantity = CConvert.ToDecimal(dr.Cells["QUANTITY"].Value);
                        if ((sanctionNumber + quantity) < 0)
                        {
                            MessageBox.Show("库存数量与修改数量之和不能小于0!");
                            dr.Cells["SANCTION_NUMBER"].Value = "0";
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

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                if (!this.dgvData.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
                    SendKeys.Send("{F4}");
            }

        }
        #endregion


        bool HasAttachEvent = false;
        #region 控制dgvData只能输入数字
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!this.HasAttachEvent) // 注册事件
            {
                e.Control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "SANCTION_NUMBER")
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
        #endregion
    }
}
