using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using System.Collections;

namespace CZZD.ERP.WinUI
{
    public partial class FrmShipment : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private Hashtable ht = null;

        public FrmShipment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmShipment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            initDgvData();
        }

        private void initDgvData()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            dgvData.Rows.Clear();
            PageSize = 16;
            dgvData.Rows.Add(PageSize);
            this.dgvData.Columns["SHIPMENT_CHK"].Visible = false;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Columns["SERIAL_NUMBER"].ReadOnly = true;
            dgvData.Columns["DEPARTUAL_DATE"].ReadOnly = true;
            dgvData.Columns["ARRIVAL_DATE"].ReadOnly = true;
        }

        /// <summary>
        ///  DataGridView的初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex >= 0 && (e.ColumnIndex == 4) && dgvData.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];
                row.Cells["QUANTITY"].Style.BackColor = System.Drawing.SystemColors.Info;

                if (row.Cells["SLIP_NUMBER"].Value == null || "".Equals(row.Cells["SLIP_NUMBER"].Value))
                {
                    row.Cells["DEPARTUAL_DATE"].ReadOnly = true;
                    row.Cells["ARRIVAL_DATE"].ReadOnly = true;
                }
                else
                {
                    Color color = COLOR_INFO;
                    row.Cells["DEPARTUAL_DATE"].Style.BackColor = color;
                    row.Cells["ARRIVAL_DATE"].Style.BackColor = color;

                    row.Cells["DEPARTUAL_DATE"].ReadOnly = false;
                    row.Cells["ARRIVAL_DATE"].ReadOnly = false;
                }
            }
        }

        /// <summary>
        /// DataGridView输入数据验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 入库数据的查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(true);
        }

        /// <summary>
        /// BindData
        /// </summary>
        /// <param name="isShowMessage"></param>
        public void BindData(bool isShowMessage)
        {
            DataTable dt = bShipment.GetShipmentPlanList(GetConduction()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dgvData.Rows.Clear();
                this.dgvData.Columns["SHIPMENT_CHK"].Visible = true;
                this.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                dgvData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;

                int i = 1;
                string currentSlipNumber = "";

                foreach (DataRow dr in dt.Rows)
                {
                    int currentRowIndex = dgvData.Rows.Add(1);
                    DataGridViewRow dgvr = dgvData.Rows[currentRowIndex];
                    dgvr.Cells["NO"].Value = i++;
                    string slipNumber = CConvert.ToString(dr["SLIP_NUMBER"]);
                    if (currentSlipNumber == "" || currentSlipNumber != slipNumber)
                    {
                        currentSlipNumber = slipNumber;
                        dgvr.Cells["SLIP_NUMBER"].Value = slipNumber;
                        dgvr.Cells["END_CUSTOMER_NAME"].Value = dr["ENDER_CUSTOMER_NAME"];
                        dgvr.Cells["SERIAL_NUMBER"].Value = dr["SERIAL_NUMBER"];
                        dgvr.Cells["DEPARTUAL_DATE"].Value = CConvert.DateTimeToString(dr["DEPARTUAL_DATE"], "yyyy-MM-dd");
                        dgvr.Cells["ARRIVAL_DATE"].Value = CConvert.DateTimeToString(dr["DUE_DATE"], "yyyy-MM-dd");
                        dgvr.Cells["CHECK_NUMBER"].Value = dr["CHECK_NUMBER"];
                        dgvr.Cells["CUSTOMER_PO_NUMBER"].Value = dr["CUSTOMER_PO_NUMBER"];
                        dgvr.Cells["WAREHOUSE_NAME"].Value = dr["DEPARTUAL_WAREHOUSE_NAME"];
                    }
                    dgvr.Cells["PRODUCT_CODE"].Value = dr["PRODUCT_CODE"];
                    dgvr.Cells["PRODUCT_NAME"].Value = dr["PRODUCT_NAME"];
                    dgvr.Cells["ORDER_QUANTITY"].Value = dr["QUANTITY"];
                    dgvr.Cells["ALLOATION_QUANTITY"].Value = dr["ALLOATION_QUANTITY"];
                    dgvr.Cells["QUANTITY"].Value = CConvert.ToDecimal(dr["QUANTITY"]) - CConvert.ToDecimal(dr["SHIPMENT_QUANTITY"]);
                    dgvr.Cells["SHIPMENT_QUANTITY"].Value = CConvert.ToDecimal(dr["SHIPMENT_QUANTITY"]);


                    dgvr.Cells["UNIT_CODE"].Value = dr["UNIT_CODE"];
                    dgvr.Cells["UNIT_NAME"].Value = dr["UNIT_NAME"];
                    dgvr.Cells["WAREHOUSE_CODE"].Value = dr["DEPARTUAL_WAREHOUSE_CODE"];

                    dgvr.Cells["TRUE_SLIP_NUMBER"].Value = slipNumber;
                    dgvr.Cells["LINE_NUMBER"].Value = dr["LINE_NUMBER"];
                    dgvr.Cells["CURRENCY_CODE"].Value = dr["CURRENCY_CODE"];
                    dgvr.Cells["LINE_MEMO"].Value = dr["LINE_MEMO"];
                    dgvr.Cells["TAX_RATE"].Value = dr["TAX_RATE"];
                    dgvr.Cells["PRICE"].Value = dr["PRICE"];
                    dgvr.Cells["SHIPMENT_DEPOSIT"].Value = dr["SHIPMENT_DEPOSIT"];
                    dgvr.Cells["AMOUNT_INCLUDED_TAX"].Value = dr["AMOUNT_INCLUDED_TAX"];
                }
            }
            else
            {
                if (isShowMessage)
                {
                    MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.dgvData.AlternatingRowsDefaultCellStyle.BackColor = COLOR_DIFF_ROW;
                initDgvData();
            }

            ReSetDataGridView("");
        }

        /// <summary>
        /// 查询条件的准备
        /// </summary>
        /// <returns></returns>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" VERIFY_FLAG = {0} AND STATUS_FLAG <> {1}", CConstant.VERIFY, CConstant.DELETE);
            sb.AppendFormat(" AND ISNULL(QUANTITY,0)-ISNULL(SHIPMENT_QUANTITY,0)>0 ");

            //订单编号
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
                return sb.ToString();
            }
            //合同编号
            if (!string.IsNullOrEmpty(txtCustomerPoNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_PO_NUMBER LIKE  '{0}%'", txtCustomerPoNumber.Text.Trim());
            }
            //客户
            if (!string.IsNullOrEmpty(txtEndCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND ENDER_CUSTOMER_CODE = '{0}'", txtEndCustomerCode.Text.Trim());
            }
            //订单日期From
            if (this.txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //订单日期To
            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //出库预定日期From
            if (this.txtDepartualDateFrom.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE >= '{0}'", txtDepartualDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //出库预定日期To
            if (this.txtDepartualDateTo.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE < '{0}'", txtDepartualDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
            }
        }

        /// <summary>
        /// 出库确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isExsit = false;
            ht = new Hashtable();
            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dgvr.Cells["SHIPMENT_CHK"].Value))
                {
                    if (!Convert.ToBoolean(dgvr.Cells["SHIPMENT_FLAG"].Value))
                    {
                        MessageBox.Show("出库条件未满足，请检查订单信息（合同编号，预付款）。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value) > 0)
                    {
                        string slipNumber = CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value);

                        //预付金额
                        decimal DepositAmount = (new BDepositArr()).GetArrAmount(slipNumber);
                        try
                        {
                            if (CConvert.ToDecimal(dgvr.Cells["SHIPMENT_DEPOSIT"].Value) / 100 > DepositAmount / CConvert.ToDecimal(dgvr.Cells["AMOUNT_INCLUDED_TAX"].Value))
                            {
                                MessageBox.Show("出库时预付款金额未支付或支付不足。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        catch (Exception ex) { }
                    }

                    if (CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value) + CConvert.ToDecimal(dgvr.Cells["SHIPMENT_QUANTITY"].Value) > CConvert.ToDecimal(dgvr.Cells["ORDER_QUANTITY"].Value))
                    {
                        MessageBox.Show("本次出库数量与已出库数量之和不能大于销售数量。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string key = CConvert.ToString(dgvr.Cells["WAREHOUSE_CODE"].Value) + "_" + CConvert.ToString(dgvr.Cells["PRODUCT_CODE"].Value);                   
                    foreach (DictionaryEntry de in ht)
                    {
                        if (key.Equals(de.Key))
                        {
                            ht[key] = CConvert.ToDecimal(de.Value) + CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);
                            isExsit = true;
                            break;
                        }                        
                    }
                    if (!isExsit)
                    {
                        ht.Add(key, CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value));
                    }
                }
            }

            foreach (DictionaryEntry de in ht)
            { 
                string []arry = CConvert.ToString(de.Key).Split('_');
                string warehouse = arry[0];
                string product = arry[1];
                decimal quantity = CConvert.ToDecimal(de.Value);
                if (bShipment.GetStock(warehouse, product) < quantity)
                {
                    MessageBox.Show("在库数不足。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (MessageBox.Show("确定要出库吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<BllShipmentTable> datas = new List<BllShipmentTable>();
                BllShipmentTable shipmentTable = null;
                DateTime currentDate = DateTime.Now;
                string currentSlipNumber = "";
                int i = 1;
                decimal totalAmount = 0;
                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    if (Convert.ToBoolean(dgvr.Cells["SHIPMENT_CHK"].Value) && CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value) > 0)
                    {
                        string slipNumber = CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value);

                        if (currentSlipNumber != slipNumber)
                        {
                            if (currentSlipNumber != "")
                            {
                                shipmentTable.AMOUNT = totalAmount;
                                shipmentTable.AMOUNT_INCLUDED_TAX = totalAmount;

                                shipmentTable.AMOUNT_WITHOUT_TAX = WithoutAmount(totalAmount, shipmentTable.TAX_RATE);
                                shipmentTable.TAX_AMOUNT = totalAmount - shipmentTable.AMOUNT_WITHOUT_TAX;
                                datas.Add(shipmentTable);
                                totalAmount = 0;
                            }
                            currentSlipNumber = slipNumber;
                            shipmentTable = new BllShipmentTable();
                            i = 1;
                            shipmentTable.ORDER_SLIP_NUMBER = slipNumber;

                            shipmentTable.SERIAL_NUMBER = CConvert.ToString(dgvr.Cells["SERIAL_NUMBER"].Value);
                            shipmentTable.SLIP_DATE = currentDate;
                            shipmentTable.ARRIVAL_DATE = CConvert.ToDateTime(dgvr.Cells["DEPARTUAL_DATE"].Value);
                            shipmentTable.TAX_RATE = CConvert.ToDecimal(dgvr.Cells["TAX_RATE"].Value);

                            shipmentTable.CURRENCY_CODE = CConvert.ToString(dgvr.Cells["CURRENCY_CODE"].Value);
                            shipmentTable.STATUS_FLAG = CConstant.INIT;
                            shipmentTable.CREATE_USER = UserTable.CODE;
                            shipmentTable.LAST_UPDATE_USER = UserTable.CODE;
                            shipmentTable.COMPANY_CODE = UserTable.COMPANY_CODE;
                            shipmentTable.CHECK_NUMBER = CConvert.ToString(dgvr.Cells["CHECK_NUMBER"].Value);
                            shipmentTable.CUSTOMER_PO_NUMBER = CConvert.ToString(dgvr.Cells["CUSTOMER_PO_NUMBER"].Value);
                        }
                        BllShipmentLineTable shipmentLineTable = new BllShipmentLineTable();
                        shipmentLineTable.LINE_NUMBER = i++;
                        shipmentLineTable.ORDER_LINE_NUMBER = CConvert.ToInt32(dgvr.Cells["LINE_NUMBER"].Value);
                        shipmentLineTable.DEPARTUAL_WAREHOUSE_CODE = CConvert.ToString(dgvr.Cells["WAREHOUSE_CODE"].Value);
                        shipmentLineTable.PRODUCT_CODE = CConvert.ToString(dgvr.Cells["PRODUCT_CODE"].Value);
                        shipmentLineTable.QUANTITY = CConvert.ToDecimal(dgvr.Cells["QUANTITY"].Value);
                        shipmentLineTable.UNIT_CODE = CConvert.ToString(dgvr.Cells["UNIT_CODE"].Value);
                        shipmentLineTable.PRICE = CConvert.ToDecimal(dgvr.Cells["PRICE"].Value);
                        shipmentLineTable.AMOUNT = shipmentLineTable.QUANTITY * shipmentLineTable.PRICE;
                        shipmentLineTable.MEMO = CConvert.ToString(dgvr.Cells["LINE_MEMO"].Value);
                        shipmentLineTable.STATUS_FLAG = CConstant.INIT;
                        totalAmount += CConvert.ToDecimal(shipmentLineTable.PRICE * shipmentLineTable.QUANTITY);
                        shipmentTable.AddItems(shipmentLineTable);
                    }
                }

                if (shipmentTable != null)
                {
                    shipmentTable.AMOUNT = totalAmount;
                    shipmentTable.AMOUNT_INCLUDED_TAX = totalAmount;
                    shipmentTable.AMOUNT_WITHOUT_TAX = WithoutAmount(totalAmount, shipmentTable.TAX_RATE);
                    shipmentTable.TAX_AMOUNT = totalAmount - shipmentTable.AMOUNT_WITHOUT_TAX;
                    datas.Add(shipmentTable);
                }

                //数据表的更新
                if (datas.Count > 0)
                {
                    try
                    {
                        int ret = bShipment.Add(datas);
                        if (ret > 0)
                        {
                            MessageBox.Show("出库确认成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindData(false);
                        }
                        else
                        {
                            MessageBox.Show("出库确认失败，请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("出库确认失败，请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("出库确认失败。", ex);
                    }

                }
                else
                {
                    MessageBox.Show("请先择需要出库的数据,或出库数量小于等于零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region 客户
        /// <summary>
        /// 客户选择按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndCustomer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtEndCustomerCode.Text = frm.BaseMasterTable.Code;
                    txtEndCustomerName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        /// <summary>
        /// 客户输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEndCustomerCode_Leave(object sender, EventArgs e)
        {
            string endCustomerCode = txtEndCustomerCode.Text.Trim();
            if (endCustomerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", endCustomerCode);
                if (baseMaster != null)
                {
                    txtEndCustomerCode.Text = baseMaster.Code;
                    txtEndCustomerName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("客户不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEndCustomerCode.Text = "";
                    txtEndCustomerName.Text = "";
                    txtEndCustomerCode.Focus();
                }
            }
            else
            {
                txtEndCustomerName.Text = "";
            }
        }
        #endregion

        /// <summary>
        /// 控制空行不能被选中
        /// </summary>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if ("".Equals(CConvert.ToString(row.Cells["TRUE_SLIP_NUMBER"].Value)))
                {
                    row.Selected = false;
                }
            }
        }

        /// <summary>
        /// DataGridView 数据输入验证
        /// </summary>
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dgvr = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["SERIAL_NUMBER"].Index)
                {
                    string serialNumber = CConvert.ToString(dgvr.Cells["SERIAL_NUMBER"].Value);
                    if (serialNumber.Length > 50)
                    {
                        MessageBox.Show("机械番号长度超出。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["SERIAL_NUMBER"].Value = serialNumber.Substring(0, 50);
                    }
                    ReSetDataGridView(CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value));
                }
                else if (e.ColumnIndex == dgvData.Columns["CHECK_NUMBER"].Index)
                {
                    string serialNumber = CConvert.ToString(dgvr.Cells["CHECK_NUMBER"].Value);
                    if (serialNumber.Length > 50)
                    {
                        MessageBox.Show("审查编号长度超出。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["CHECK_NUMBER"].Value = serialNumber.Substring(0, 50);
                    }
                    ReSetDataGridView(CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value));
                }
                else if (e.ColumnIndex == dgvData.Columns["CUSTOMER_PO_NUMBER"].Index)
                {
                    string serialNumber = CConvert.ToString(dgvr.Cells["CUSTOMER_PO_NUMBER"].Value);
                    if (serialNumber.Length > 50)
                    {
                        MessageBox.Show("合同编号长度超出。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["CUSTOMER_PO_NUMBER"].Value = serialNumber.Substring(0, 50);
                    }
                    ReSetDataGridView(CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value));
                }
                else if (e.ColumnIndex == dgvData.Columns["DEPARTUAL_DATE"].Index)
                {
                    string departualDate = CConvert.ToString(dgvr.Cells["DEPARTUAL_DATE"].Value);
                    if (departualDate != "")
                    {
                        DateTime dTime = DateTime.Now;
                        try
                        {
                            dTime = DateTime.Parse(departualDate);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的出库日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        dgvr.Cells["DEPARTUAL_DATE"].Value = dTime.ToString("yyyy-MM-dd");
                    }

                }
                else if (e.ColumnIndex == dgvData.Columns["ARRIVAL_DATE"].Index)
                {
                    string arrivalDate = CConvert.ToString(dgvr.Cells["ARRIVAL_DATE"].Value);
                    if (arrivalDate != "")
                    {
                        DateTime dTime = DateTime.Now;
                        try
                        {
                            dTime = DateTime.Parse(arrivalDate);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的到达预定日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        dgvr.Cells["ARRIVAL_DATE"].Value = dTime.ToString("yyyy-MM-dd");
                    }

                }
                else if (e.ColumnIndex == dgvData.Columns["QUANTITY"].Index)
                {
                    string quantity = CConvert.ToString(dgvr.Cells["QUANTITY"].Value);
                    decimal alloationQuantity = CConvert.ToDecimal(dgvr.Cells["ALLOATION_QUANTITY"].Value);

                    if (CConvert.ToDecimal(quantity) < 0)
                    {
                        MessageBox.Show("出库数量不能为负数。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvr.Cells["QUANTITY"].Value = 1;
                    }
                    else if (CConvert.ToDecimal(quantity) == 0)
                    {
                        try
                        {
                            decimal.Parse(quantity);
                            MessageBox.Show("出库数量不能为零。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的出库数量。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        finally
                        {
                            dgvr.Cells["QUANTITY"].Value = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("CellValidated error!", ex);
            }
        }

        /// <summary>
        /// DataGridView输入控制
        /// </summary>
        bool HasAttachEvent = false;
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!this.HasAttachEvent) // 注册事件
            {
                e.Control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "QUANTITY")
                    {
                        InputDouble(o, c);
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
        /// 显示数据的重新整理
        /// </summary>
        private void ReSetDataGridView(string slipNumber)
        {
            string currentSlipNumber = "";
            bool shipmentFlag = true;

            foreach (DataGridViewRow dgvr in dgvData.Rows)
            {
                if (dgvr.Cells[0].Value == null || "".Equals(dgvr.Cells[0].Value))
                {
                    break;
                }

                if (!"".Equals(slipNumber) && !slipNumber.Equals(CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value)))
                {
                    continue;
                }

                if (!currentSlipNumber.Equals(dgvr.Cells["TRUE_SLIP_NUMBER"].Value))
                {
                    currentSlipNumber = CConvert.ToString(dgvr.Cells["TRUE_SLIP_NUMBER"].Value);
                    //check
                    shipmentFlag = true;

                    //预付金额
                    decimal DepositAmount = (new BDepositArr()).GetArrAmount(currentSlipNumber);
                    try
                    {
                        if (CConvert.ToDecimal(dgvr.Cells["SHIPMENT_DEPOSIT"].Value) / 100 > DepositAmount / CConvert.ToDecimal(dgvr.Cells["AMOUNT_INCLUDED_TAX"].Value))
                        {
                            shipmentFlag = false;
                        }
                    }
                    catch (Exception ex) { }
                }

                if (shipmentFlag)
                {
                    dgvr.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgvr.DefaultCellStyle.BackColor = COLOR_NG;
                }
                dgvr.Cells["SHIPMENT_FLAG"].Value = shipmentFlag;

            }
        }
    }//end class
}
