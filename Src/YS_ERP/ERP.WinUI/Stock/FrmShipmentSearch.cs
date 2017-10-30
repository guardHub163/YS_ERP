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
    public partial class FrmShipmentSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private string slipnumber;
        private bool isSearch = false;
        private string currentConduction = "";

        public string SHIPMENT_SLIP_NUMBER
        {
            set { slipnumber = value; }
            get { return slipnumber; }
        }

        public FrmShipmentSearch()
        {
            InitializeComponent();
        }

        private void FrmShipmentSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            initDgvData();
            if (!string.IsNullOrEmpty(slipnumber))
            {
                initOperate(1);
                setStatus(false);
            }
        }

        /// <summary>
        /// dgvData 初始化
        /// </summary>
        private void initDgvData()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            PageSize = 14;
            dgvData.Rows.Add(PageSize);
        }

        #region 明细确认
        private void initOperate(int currentPage)
        {
            BllShipmentTable shipment = bShipment.GetModel(slipnumber);
            BllOrderHeaderTable orderheader = bOrderHeader.GetModel(shipment.ORDER_SLIP_NUMBER);
            txtSlipNumber.Text = slipnumber;
            txtOrderSlipNumber.Text = shipment.ORDER_SLIP_NUMBER;
            //txtCustomerCode.Text = orderheader.CUSTOMER_CODE;
            //txtCustomerName.Text = orderheader.CUSTOMER_NAME;
            txtEndCustomerCode.Text = orderheader.ENDER_CUSTOMER_CODE;
            txtEndCustomerName.Text = orderheader.ENDER_CUSTOMER_NAME;
            //txtDeliveryPointCode.Text = orderheader.ENDER_CUSTOMER_CODE;
            //txtDeliveryPointName.Text = orderheader.ENDER_CUSTOMER_NAME;
            //txtSerialNumber.Text = shipment.SERIAL_NUMBER;
            txtCustomerPoNumber.Text = orderheader.CUSTOMER_PO_NUMBER;
            txtOrderSlipDateFrom.Value = CConvert.ToDateTime(orderheader.SLIP_DATE.ToString());
            txtOrderSlipDateTo.Value = CConvert.ToDateTime(orderheader.SLIP_DATE.ToString());
            txtSlipDateFrom.Value = CConvert.ToDateTime(shipment.SLIP_DATE.ToString("yyyy-MM-dd"));
            txtSlipDateTo.Value = CConvert.ToDateTime(shipment.SLIP_DATE.ToString("yyyy-MM-dd"));
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", slipnumber);
            DataSet ds = bShipment.GetList(sb.ToString(), "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            int recordCount = bShipment.GetRecordCount(sb.ToString());
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
            this.pgControl.init(GetTotalPage(recordCount), currentPage);
        }

        private void setStatus(bool flag)
        {
            txtSlipNumber.Enabled = false;
            txtOrderSlipNumber.Enabled = false;
            txtEndCustomerCode.Enabled = false;
            txtCustomerPoNumber.Enabled = false;
            txtOrderSlipDateFrom.Enabled = false;
            txtOrderSlipDateTo.Enabled = false;
            txtSlipDateFrom.Enabled = false;
            txtSlipDateTo.Enabled = false;
            btnEndCustomer.Enabled = false;
            btnSearch.Enabled = false;
            btnPrint.Enabled = false;
            btnDelete.Enabled = false;
        }
        #endregion

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            if (string.IsNullOrEmpty(slipnumber))
            {
                BindData(currentPage);
            }
            else
            {
                initOperate(currentPage);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            currentConduction = GetConduction();
            int currentPage = 1;
            int recordCount = bShipment.GetRecordCount(currentConduction);
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);
            //数据绑定
            BindData(currentPage);
            isSearch = true;

        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            DataSet ds = bShipment.GetList(currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);

            //订单编号
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
                return sb.ToString();
            }
            //销售单号
            if (!string.IsNullOrEmpty(txtOrderSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND ORDER_SLIP_NUMBER = '{0}'", txtOrderSlipNumber.Text.Trim());
                return sb.ToString();
            }
            //合同编号
            if (!string.IsNullOrEmpty(txtCustomerPoNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_PO_NUMBER LIKE  '{0}%'", txtCustomerPoNumber.Text.Trim());
            }
            //需要家
            if (!string.IsNullOrEmpty(txtEndCustomerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND ENDER_CUSTOMER_CODE = '{0}'", txtEndCustomerCode.Text.Trim());
            }
            //出库日期From
            if (this.txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //出库日期To
            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //销售日期From
            if (this.txtOrderSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND ORDER_SLIP_DATE >= '{0}'", txtOrderSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //销售日期To
            if (this.txtOrderSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND ORDER_SLIP_DATE < '{0}'", txtOrderSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            return sb.ToString();
        }

        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["NO"].Value == null || "".Equals(row.Cells["NO"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }

        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            //for (int i = 0; i < _currentDt.Rows.Count; i++)
            //{
            //    _currentDt.Rows[i]["NO"] = i + 1;
            //}

            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }
        }

        /// <summary>
        /// 页面关闭
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                this.Close();
            }
        }

        #region 出库取消
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (isSearch && dgvData.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvr = dgvData.SelectedRows[0];
                string slipNumber = CConvert.ToString(dgvr.Cells["SLIP_NUMBER"].Value);

                if (MessageBox.Show("确定要出库取消吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //
                    if (CConvert.ToInt32(dgvr.Cells["STATUS_FLAG"].Value) == CConstant.NORMAL)
                    {
                        MessageBox.Show("销售发票已开，不能进行出库取消。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    try
                    {
                        string orderSlipNumber = CConvert.ToString(dgvr.Cells["ORDER_SLIP_NUMBER"].Value);
                        int ret = bShipment.DeleteShipment(slipNumber, UserTable.CODE);
                        if (ret > 0)
                        {
                            MessageBox.Show("出库取消成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindData(pgControl.GetCurrentPage());
                            bCommon.ReSetAlloation(orderSlipNumber);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出库取消失败，请重试或与系统管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logger.Error("出库取消失败", ex);
                    }
                }
            }
        }
        #endregion

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

        #region 导出
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable printDataTable = bShipment.GetPrintList(currentConduction).Tables[0];
            if (isSearch && printDataTable.Rows.Count > 0)
            {
                int result = CExport.DataTableToExcel(printDataTable, CConstant.SHIPMENT_HEADER, CConstant.SHIPMENT_COLUMNS, "SHIPMENT", "SHIPMENT");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("导出成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == CConstant.EXPORT_FAILURE)
                {
                    MessageBox.Show("数据导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region 纳品书
        /// <summary>
        ///  纳品书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShipper_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (isSearch)
            //    {
            //        //纳品书订单的选择
            //        FrmShipmentPrintSelect frm = new FrmShipmentPrintSelect(currentConduction);
            //        if (frm.ShowDialog(this) == DialogResult.Cancel)
            //        {
            //            return;
            //        }
            //        string slipNumber = frm.resultValue;

            //        if (!string.IsNullOrEmpty(slipNumber))
            //        {
            //            Hashtable ht = null; //单个替换用
            //            DataTable dt = null; //数据集
            //            bool isMechanicalBase = false;

            //            DataSet ds = bShipment.GetList(" SLIP_NUMBER in (" + slipNumber + ")");
            //            foreach (DataRow dr in ds.Tables[0].Rows)
            //            {
            //                if (CConstant.MECHANICAL_BASE.Equals(dr["MECHANICAL_DISTINCTION_FLAG"]))
            //                {
            //                    isMechanicalBase = true;
            //                    break;
            //                }
            //            }

            //            if (isMechanicalBase)
            //            {
            //                #region 含机械本体

            //                dt = new DataTable();
            //                dt.Columns.Add("NO", Type.GetType("System.String"));
            //                dt.Columns.Add("NAME", Type.GetType("System.String"));
            //                dt.Columns.Add("SPEC", Type.GetType("System.String"));
            //                dt.Columns.Add("QTY", Type.GetType("System.Decimal"));
            //                dt.Columns.Add("UNIT_NAME", Type.GetType("System.String"));
            //                dt.Columns.Add("SERIAL_NUMBER", Type.GetType("System.String"));

            //                DataRow row = null;
            //                bool isFirst = true;
            //                int i = 1;
            //                foreach (DataRow dr in ds.Tables[0].Rows)
            //                {
            //                    if (isFirst)
            //                    {
            //                        ht = new Hashtable();
            //                        ht.Add("&SLIP_NUMBER", CConvert.ToString(dr["SLIP_NUMBER"]));
            //                        ht.Add("&DATE", CConvert.ToDateTime(dr["SLIP_DATE"]).ToShortDateString());
            //                        ht.Add("&CUSTOMER_NAME", CConvert.ToString(dr["CUSTOMER_NAME"]));
            //                        ht.Add("&CONTACT_NAME", CConvert.ToString(dr["CONTACT_NAME"]));
            //                        ht.Add("&MOBIL_NUMBER", CConvert.ToString(dr["MOBIL_NUMBER"]));
            //                        ht.Add("&MONTH", CConvert.ToDateTime(dr["ARRIVAL_DATE"]).Month);
            //                        ht.Add("&DAY", CConvert.ToDateTime(dr["ARRIVAL_DATE"]).Day);
            //                        ht.Add("&HOUR", CConvert.ToDateTime(dr["ARRIVAL_DATE"]).Hour);
            //                        ht.Add("&MINUTE", CConvert.ToDateTime(dr["ARRIVAL_DATE"]).Minute);
            //                        ht.Add("&ADDRESS", CConvert.ToString(dr["DELIVERY_POINT_NAME"]));
            //                    }

            //                    if (CConstant.PRODUCT_PACKAGE_ALONT.Equals(dr["PACKAGE_MODE"]))
            //                    {
            //                        row = dt.NewRow();
            //                        row["NO"] = i++;
            //                        row["NAME"] = CConvert.ToString(dr["PRODUCT_NAME"]);
            //                        row["SPEC"] = CConvert.ToString(dr["SPEC"]);
            //                        row["QTY"] = CConvert.ToDecimal(dr["QUANTITY"]);
            //                        row["UNIT_NAME"] = CConvert.ToString(dr["UNIT_NAME"]);
            //                        if (CConstant.MECHANICAL_BASE.Equals(dr["MECHANICAL_DISTINCTION_FLAG"]))
            //                        {
            //                            row["SERIAL_NUMBER"] = CConvert.ToString(dr["SERIAL_NUMBER"]);
            //                        }
            //                        else
            //                        {
            //                            row["SERIAL_NUMBER"] = "";
            //                        }
            //                        dt.Rows.Add(row);
            //                    }
            //                }

            //                SaveFileDialog sf = new SaveFileDialog();
            //                sf.FileName = "LZ_SHIPMENT_BODY_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            //                sf.Filter = "(文件)|*.xls;*.xlsx";

            //                if (sf.ShowDialog(this) == DialogResult.OK)
            //                {
            //                    if (dt.Rows.Count > 0)
            //                    {
            //                        int ret = CommonExport.ExportShipmentBody(@"rpt\shipper_body.frx", sf.FileName, dt, ht);
            //                        if (CConstant.EXPORT_FAILURE.Equals(ret))
            //                        {
            //                            MessageBox.Show("导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                        }
            //                        else if (CConstant.EXPORT_SUCCESS.Equals(ret))
            //                        {
            //                            MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        }
            //                        else if (CConstant.EXPORT_RUNNING.Equals(ret))
            //                        {
            //                            MessageBox.Show("文件正在运行，重新生成文件失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                        }
            //                        else if (CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST.Equals(ret))
            //                        {
            //                            MessageBox.Show("模版文件不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                    }
            //                }
            //                #endregion
            //            }
            //            else
            //            {
            //                #region  部件出货
            //                dt = new DataTable();
            //                dt.Columns.Add("NO", Type.GetType("System.Int32"));
            //                dt.Columns.Add("PRODUCT_NAME", Type.GetType("System.String"));
            //                dt.Columns.Add("X_1", Type.GetType("System.String"));
            //                dt.Columns.Add("X_2", Type.GetType("System.String"));
            //                dt.Columns.Add("MODEL_NUMBER", Type.GetType("System.String"));
            //                dt.Columns.Add("X_3", Type.GetType("System.String"));
            //                dt.Columns.Add("QUANTITY", Type.GetType("System.Decimal"));
            //                dt.Columns.Add("MEMO", Type.GetType("System.String"));

            //                DataRow row = null;
            //                bool isFirst = true;
            //                int i = 1;
            //                foreach (DataRow dr in ds.Tables[0].Rows)
            //                {
            //                    if (isFirst)
            //                    {
            //                        ht = new Hashtable();
            //                        ht.Add("&SLIP_NUMBER", CConvert.ToString(dr["SLIP_NUMBER"]));
            //                        ht.Add("&DATE", CConvert.ToDateTime(dr["SLIP_DATE"]).ToShortDateString());
            //                        ht.Add("&END_CUSTOMER_NAME", CConvert.ToString(dr["ENDER_CUSTOMER_NAME"]));
            //                        ht.Add("&CONTACT", CConvert.ToString(dr["ENDER_CONTACT_NAME"]));
            //                        ht.Add("&MOBIL_NUMBER", CConvert.ToString(dr["ENDER_MOBIL_NUMBER"]));
            //                        ht.Add("&ADDRESS", CConvert.ToString(dr["DELIVERY_POINT_NAME"]));
            //                        DataTable userDt = new BUser().GetList(" CODE='" + CConvert.ToString(dr["CREATE_USER"]) + "'").Tables[0];
            //                        string companyName = "";
            //                        if (userDt != null && userDt.Rows.Count > 0)
            //                        {
            //                            companyName = CConvert.ToString(userDt.Rows[0]["COMPANY_NAME"]);
            //                        }
            //                        ht.Add("&COMPANY_NAME", companyName);
            //                        ht.Add("&INVOICE_NUMBER", bShipment.GetReceiptInvoiceNumber(CConvert.ToString(dr["ORDER_SLIP_NUMBER"])));
            //                    }

            //                    row = dt.NewRow();
            //                    row["NO"] = i++;
            //                    row["PRODUCT_NAME"] = CConvert.ToString(dr["PRODUCT_NAME"]);
            //                    row["MODEL_NUMBER"] = CConvert.ToString(dr["SPEC"]) + CConvert.ToString(dr["MODEL_NUMBER"]);
            //                    row["QUANTITY"] = CConvert.ToDecimal(dr["QUANTITY"]);
            //                    row["MEMO"] = CConvert.ToString(dr["MEMO"]);
            //                    dt.Rows.Add(row);
            //                }
            //                SaveFileDialog sf = new SaveFileDialog();
            //                sf.FileName = "LZ_SHIPMENT_ACCESSORIES_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            //                sf.Filter = "(文件)|*.xls;*.xlsx";

            //                if (sf.ShowDialog(this) == DialogResult.OK)
            //                {
            //                    if (dt.Rows.Count > 0)
            //                    {
            //                        int ret = CommonExport.ExportShipmentAccessories(@"rpt\shipper_accessories.frx", sf.FileName, dt, ht);
            //                        if (CConstant.EXPORT_FAILURE.Equals(ret))
            //                        {
            //                            MessageBox.Show("导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                        }
            //                        else if (CConstant.EXPORT_SUCCESS.Equals(ret))
            //                        {
            //                            MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        }
            //                        else if (CConstant.EXPORT_RUNNING.Equals(ret))
            //                        {
            //                            MessageBox.Show("文件正在运行，重新生成文件失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                        }
            //                        else if (CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST.Equals(ret))
            //                        {
            //                            MessageBox.Show("模版文件不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                    }
            //                }
            //                #endregion
            //            }
            //        }　// end if (!string.IsNullOrEmpty(slipNumber))
            //    } // end if (isSearch)
            //}
            //catch (Exception ex)
            //{ }
        }
        #endregion
    }//end class
}
