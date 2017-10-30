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
using System.Collections;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.CacheData;
using CZZD.ERP.WinUI.Purchase;

namespace CZZD.ERP.WinUI
{
    public partial class FrmPurchaseOrderSearch : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private BllPurchaseOrderTable _currentPurchaseOrderTable = new BllPurchaseOrderTable();
        private string _currentConduction = "";
        public BllPurchaseOrderTable CurrentPurchaseOrderTable
        {
            get { return _currentPurchaseOrderTable; }
            set { _currentPurchaseOrderTable = value; }
        }
        private int Receipt;
        private bool isSearch = false;

        public FrmPurchaseOrderSearch()
        {
            InitializeComponent();
        }

        #region 页面初始化
        private void FrmPurchaseSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            #region 订单类型的初始化
            DataTable pstDT = CCacheData.PurchaseOrder.Copy();
            DataRow dr = pstDT.NewRow();
            pstDT.Rows.InsertAt(dr, 0);
            dr["CODE"] = "";
            dr["NAME"] = "全部";
            cboPurchaseSlipType.ValueMember = "CODE";
            cboPurchaseSlipType.DisplayMember = "NAME";
            cboPurchaseSlipType.DataSource = pstDT;
            #endregion

            init();
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }

        private void init()
        {
            if (CConstant.PURCHASE_ORDER_SEARCH.Equals(CTag))
            {

            }
            //订单查询
            else if (CConstant.PURCHASE_ORDER_MASTER_SEARCH.Equals(CTag))
            {
                this.Text = "订单查询";
                btnOperate.Text = "确　认";
                btnPrint.Visible = false;
                //btnPurcahse.Visible = false;
                btnModify.Visible = false;
                btnPurchasedPart.Visible = false;
                btnInquirySheet.Visible = false;
            }
            
        }

        #endregion

        #region 供应商
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SUPPLIER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSupplierCode.Text = frm.BaseMasterTable.Code;
                    txtSupplierName.Text = frm.BaseMasterTable.Name;
                    txtWarehouseCode.Focus();
                }
            }
            frm.Dispose();
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            string SupplierCode = txtSupplierCode.Text.Trim();
            if (SupplierCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SUPPLIER", SupplierCode);
                if (baseMaster != null)
                {
                    txtSupplierCode.Text = baseMaster.Code;
                    txtSupplierName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("供应商不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }
        #endregion

        #region 入库仓库
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("WAREHOUSE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtWarehouseCode.Text = frm.BaseMasterTable.Code;
                    txtWarehouseName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }


        /// <summary>
        /// 仓库输入验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWarehouseCode_Leave(object sender, EventArgs e)
        {
            string warehouseCode = txtWarehouseCode.Text.Trim();
            if (warehouseCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("WAREHOUSE", warehouseCode);
                if (baseMaster != null)
                {
                    txtWarehouseCode.Text = baseMaster.Code;
                    txtWarehouseName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("入库仓库不存在.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWarehouseCode.Text = "";
                    txtWarehouseName.Text = "";
                    txtWarehouseCode.Focus();
                }
            }
            else
            {
                txtWarehouseName.Text = "";
            }

        }
        #endregion

        #region 窗口关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region 查询分页
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _currentConduction = GetConduction();
            int currentPage = 1;
            int recordCount = bPurchaseOrder.GetRecordCount(_currentConduction);
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            DataSet ds = bPurchaseOrder.GetList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                //入库状况

                getReceipt(dr.Cells["SLIP_NUMBER"].Value.ToString());

                if (Receipt == CConstant.UN_RECEIPT && !string.IsNullOrEmpty(dr.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    dr.Cells["RECEIPT_CONDITION"].Value = "未入库";
                }
                else if (Receipt == CConstant.COMPLETE_RECEIPT && !string.IsNullOrEmpty(dr.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    dr.Cells["RECEIPT_CONDITION"].Value = "入库完了";
                }
                else if (Receipt == CConstant.PART_RECEIPT && !string.IsNullOrEmpty(dr.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    dr.Cells["RECEIPT_CONDITION"].Value = "入库一部分";
                }
            }
        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0} ", CConstant.DELETE);
            //订单类型
            if (cboPurchaseSlipType.SelectedIndex > 0)
            {
                sb.AppendFormat(" AND SLIP_TYPE = '{0}'", cboPurchaseSlipType.SelectedValue);
            }
            if (txtPurchaseOrderCode.Text.Trim() != "")
            {
                sb.AppendFormat("and SLIP_NUMBER like '{0}%' ", txtPurchaseOrderCode.Text.Trim());
            }

            if (txtSupplierCode.Text.Trim() != "")
            {
                sb.AppendFormat("and SUPPLIER_CODE = '{0}' ", txtSupplierCode.Text.Trim());
            }

            if (txtWarehouseCode.Text.Trim() != "")
            {
                sb.AppendFormat("and RECEIPT_WAREHOUSE_CODE = '{0}' ", txtWarehouseCode.Text.Trim());
            }

            if (slipDateFrom.Checked)
            {
                sb.AppendFormat("and SLIP_DATE >= '{0}' ", slipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            else if (slipDateTo.Checked)
            {
                sb.AppendFormat("and SLIP_DATE < '{0}' ", slipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            if (dueDateFrom.Checked)
            {
                sb.AppendFormat("and DUE_DATE >= '{0}' ", dueDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            else if (dueDateTo.Checked)
            {
                sb.AppendFormat("and DUE_DATE < '{0}' ", dueDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>
        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }

        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            for (int i = _currentDt.Rows.Count - 1; i >= 0; i--)
            {
                getReceipt(_currentDt.Rows[i]["SLIP_NUMBER"].ToString());
                if (rdolibraryOk.Checked)
                {
                    if (Receipt != CConstant.COMPLETE_RECEIPT)
                    {
                        _currentDt.Rows.Remove(_currentDt.Rows[i]);
                    }
                }
                else if (rdolibraryNo.Checked)
                {
                    if (Receipt == CConstant.COMPLETE_RECEIPT)
                    {
                        _currentDt.Rows.Remove(_currentDt.Rows[i]);
                    }
                }
            }
            int j = 1;
            foreach (DataRow row in _currentDt.Rows)
            {
                row["Row"] = j;
                j++;
            }
            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }
            
        }

        #endregion

        #region 获得入库状况

        public void getReceipt(string SLIP_NUMBER)
        {
            int a = 0;
            int b = 0;
            BllPurchaseOrderLineTable OLTable = new BllPurchaseOrderLineTable();
            DataSet ds = bPurchaseOrder.GetReceivingPlanByPurchaseOrderSlipNumber(SLIP_NUMBER);
            foreach (DataRow rows in ds.Tables[0].Rows)
            {
                if (CConvert.ToInt32(rows["STATUS_FLAG"]) == 0)
                {
                    a++;
                }
                else if (CConvert.ToInt32(rows["STATUS_FLAG"]) == 1)
                {
                    b++;
                }
            }           

            if (a == ds.Tables[0].Rows.Count)
            {
                Receipt = CConstant.UN_RECEIPT;
            }
            else if (b == ds.Tables[0].Rows.Count)
            {
                Receipt = CConstant.COMPLETE_RECEIPT;
            }
            else
            {
                Receipt = CConstant.PART_RECEIPT;
            }
        }

        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (GetCurrentSelectedTable())
            {
                getReceipt(_currentPurchaseOrderTable.SLIP_NUMBER);
                if (Receipt == CConstant.UN_RECEIPT)
                {
                    FrmPurchaseOrderEntry frm = new FrmPurchaseOrderEntry();
                    frm.UserTable = _userInfo;
                    frm.CTag = CConstant.PURCHASE_ORDER_MODIFY;
                    frm.CurrentPurchaseOrderTable = _currentPurchaseOrderTable;
                    if (DialogResult.OK == frm.ShowDialog(this))
                    {
                        BindData(this.pgControl.GetCurrentPage());
                    }
                    frm.Dispose();
                    _currentPurchaseOrderTable = null;
                }
                else
                {
                    MessageBox.Show("明细已入库,不能修改!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region 详细确认
        /// <summary>
        /// 详细确认
        /// </summary>
        private void btnOperate_Click(object sender, EventArgs e)
        {
            if (GetCurrentSelectedTable())
            {
                if (CConstant.PURCHASE_ORDER_SEARCH.Equals(CTag))
                {
                    FrmPurchaseOrderEntry frm = new FrmPurchaseOrderEntry();
                    frm.UserTable = _userInfo;
                    frm.CTag = CConstant.PURCHASE_ORDER_SEARCH;
                    frm.CurrentPurchaseOrderTable = _currentPurchaseOrderTable;
                    frm.ShowDialog(this);
                    frm.Dispose();
                    _currentPurchaseOrderTable = null;
                }
                else if (CConstant.PURCHASE_ORDER_MASTER_SEARCH.Equals(CTag))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        #endregion

        /// <summary>
        /// 获得当前选中的数据
        /// </summary>
        private bool GetCurrentSelectedTable()
        {
            bool b = false;
            if (dgvData.SelectedRows.Count > 0)
            {
                try
                {
                    string slipNumber = dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value.ToString();

                    _currentPurchaseOrderTable = bPurchaseOrder.GetModel(slipNumber);

                    if (_currentPurchaseOrderTable != null)
                    {
                        b = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("采购订单查询选择数据错误：", ex);
                }
            }
            else
            {
                MessageBox.Show("请先选择一行。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return b;
        }

        #region 控制空行不能被点击
        /// <summary>
        ///　控制空行不能被点击
        /// </summary>
        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["SLIP_NUMBER"].Value == null || "".Equals(row.Cells["SLIP_NUMBER"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
        #endregion

        #region 按键顺序
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                System.Windows.Forms.SendKeys.Send("+{Tab}");
            }
            if (e.KeyCode == Keys.Down)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
            }
        }
        #endregion

        #region 订单跟踪
        /// <summary>
        /// 订单跟踪
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region
            //Hashtable ht = new Hashtable();
            //BaseProductTable product = null;
            //DataSet ds = bPurchaseOrder.GetList(GetConduction());

            //DataTable dt = new DataTable();
            //dt.Columns.Add("NO", Type.GetType("System.String"));
            //dt.Columns.Add("SLIP_NUMBER", Type.GetType("System.String"));
            //dt.Columns.Add("PRODUCT_NAME", Type.GetType("System.String"));
            //dt.Columns.Add("SPEC", Type.GetType("System.String"));
            //dt.Columns.Add("SUPPLIER_NAME", Type.GetType("System.String"));
            //dt.Columns.Add("QUANTITY", Type.GetType("System.String"));
            //dt.Columns.Add("PRICE", Type.GetType("System.String"));
            //dt.Columns.Add("AMOUNT", Type.GetType("System.String"));
            //dt.Columns.Add("PAYMENT_STATUS", Type.GetType("System.String"));
            //dt.Columns.Add("SLIP_DATE", Type.GetType("System.String"));
            //dt.Columns.Add("DUE_DATE", Type.GetType("System.String"));
            //dt.Columns.Add("DUE_STATUS", Type.GetType("System.String"));
            //dt.Columns.Add("DELIVERY_STATUS", Type.GetType("System.String"));
            //dt.Columns.Add("ACTUAL_AMOUNT", Type.GetType("System.String"));

            //int i = 1;
            //decimal total = 0;
            //decimal payment = 0;
            //DataRow row = null;
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    row = dt.NewRow();
            //    row["NO"] = i++;
            //    row["SLIP_NUMBER"] = dr["SLIP_NUMBER"];
            //    string code = CConvert.ToString(dr["PRODUCT_CODE"]);
            //    product = new BProduct().GetModel(code);
            //    row["PRODUCT_NAME"] = dr["PRODUCT_NAME"];
            //    if (product == null)
            //    {
            //        product = new BaseProductTable();
            //    }
            //    row["SPEC"] = product.SPEC;
            //    row["SUPPLIER_NAME"] = dr["SUPPLIER_NAME"];
            //    row["QUANTITY"] = dr["QUANTITY"];
            //    row["PRICE"] = dr["PRICE"];
            //    row["AMOUNT"] = dr["AMOUNT_INCLUDED_TAX"];                
            //    row["SLIP_DATE"] = CConvert.ToDateTime(dr["SLIP_DATE"]).ToString("yyyy-MM-dd");
            //    row["DUE_DATE"] = CConvert.ToDateTime(dr["DUE_DATE"]).ToString("yyyy-MM-dd");
            //    DateTime now = CConvert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            //    DateTime due = CConvert.ToDateTime(CConvert.ToDateTime(dr["DUE_DATE"]).ToString("yyyy-MM-dd"));
            //    if (now > due)
            //    {
            //        TimeSpan ts = now - due;
            //        row["DUE_STATUS"] = "超过期限" + ts.TotalDays + "天";
            //    }
            //    else
            //    {
            //        row["DUE_STATUS"] ="未到时间";
            //    }
            //    getReceipt(CConvert.ToString(dr["SLIP_NUMBER"]));
            //    if (Receipt == CConstant.UN_RECEIPT)
            //    {
            //        row["DELIVERY_STATUS"] = "未入库";
            //    }
            //    else if (Receipt == CConstant.COMPLETE_RECEIPT)
            //    {
            //        row["DELIVERY_STATUS"] = "入库完了";
            //    }
            //    else if (Receipt == CConstant.PART_RECEIPT)
            //    {
            //        row["DELIVERY_STATUS"] = "入库一部分";
            //    }
            //    row["ACTUAL_AMOUNT"] = bPurchaseOrder.GetReceiptActualQuantity(CConvert.ToString(dr["SLIP_NUMBER"]), CConvert.ToString(dr["PRODUCT_CODE"]));
            //    total += CConvert.ToDecimal(dr["AMOUNT_INCLUDED_TAX"]);
            //    dt.Rows.Add(row);
            //}
                        
            //ht.Add("&DATE", "'" + DateTime.Now.ToString("yyyy.MM.dd"));
            //ht.Add("&TOTAL_AMOUNT", total);
            //ht.Add("&PAYMENT_AMOUNT", payment);
            //ht.Add("&NO_PAYMENT_AMOUNT", total - payment);

            //if (isSearch)
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        SaveFileDialog sf = new SaveFileDialog();
            //        sf.FileName = "HD_PURCHASE_ORDER_TRACK_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            //        sf.Filter = "(文件)|*.xls;*.xlsx";

            //        if (sf.ShowDialog(this) == DialogResult.OK)
            //        {                        
            //            int ret = CommonExport.DataTableToExcel_Purchase_Order_Track(@"rpt\HD_PURCHASE_ORDER_TRACK.frx", sf.FileName, dt, ht);
            //            if (CConstant.EXPORT_FAILURE.Equals(ret))
            //            {
            //                MessageBox.Show("导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            }
            //            else if (CConstant.EXPORT_SUCCESS.Equals(ret))
            //            {
            //                MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else if (CConstant.EXPORT_RUNNING.Equals(ret))
            //            {
            //                MessageBox.Show("文件正在运行，重新生成文件失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            }
            //            else if (CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST.Equals(ret))
            //            {
            //                MessageBox.Show("模版文件不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            }                        
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请先查询。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            #endregion
            FrmPOTrack frm = new FrmPOTrack();
            if (rdolibraryNo.Checked)
            {
                frm.LIBRARYNO = true;
            }
            else
            {
                frm.LIBRARYNO = false;
            }
            if (rdolibraryOk.Checked)
            {
                frm.LIBRARYOK = true;
            }
            else
            {
                frm.LIBRARYOK = false;
            }
            frm.STRWHERE = GetConduction();
            frm.ShowDialog(this);
            frm.Dispose();
        }
        #endregion

        #region 外购件订单
        private void btnSupplierFax_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                Hashtable ht = new Hashtable();
                DataTable dt = new DataTable();
                DataGridViewRow row = dgvData.SelectedRows[0];

                BllPurchaseOrderTable purchase = bPurchaseOrder.GetModel(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value));
                BaseSupplierTable supplier = bSupplier.GetModel(CConvert.ToString(row.Cells["SUPPLIER_CODE"].Value));
                if (purchase == null)
                {
                    purchase = new BllPurchaseOrderTable();
                }
                if (supplier == null)
                {
                    supplier = new BaseSupplierTable();
                }
                ht.Add("&SUPPLIER", supplier.NAME);
                ht.Add("&CONTACT_NAME", supplier.CONTACT_NAME);
                ht.Add("&MOBIL_NUMBER", supplier.MOBIL_NUMBER);
                ht.Add("&PHONE_NUMBER", supplier.PHONE_NUMBER);
                ht.Add("&FAX_NUMBER", supplier.FAX_NUMBER);
                ht.Add("&SLIP_NUMBER", purchase.SLIP_NUMBER);
                ht.Add("&SLIP_DATE", purchase.SLIP_DATE);
                ht.Add("&DUE_DATE", purchase.DUE_DATE);                       

                dt.Columns.Add("No");
                dt.Columns.Add("SPEC");
                dt.Columns.Add("NAME");
                dt.Columns.Add("UNIT_NAME");
                dt.Columns.Add("QUANTITY");
                dt.Columns.Add("PRICE");
                dt.Columns.Add("TOTAL_AMOUNT");
                dt.Columns.Add("APPLICATION");
                dt.Columns.Add("MEMO");

                DataRow rows = null;
                int i = 0;
                string name = "";
                decimal TOTAL = 0;
                foreach (BllPurchaseOrderLineTable POLTable in purchase.Items)
                {
                    rows = dt.NewRow();
                    rows["No"] = POLTable.LINE_NUMBER;
                    BaseProductTable product = bProduct.GetModel(POLTable.PRODUCT_CODE);
                    if (product != null)
                    {
                        rows["SPEC"] = product.CODE;
                        rows["NAME"] = product.NAME;
                        if (i == 0)
                        {
                            name = product.NAME;
                        }
                        if (bCommon.GetBaseMaster("UNIT", POLTable.UNIT_CODE) != null)
                        {
                            rows["UNIT_NAME"] = bCommon.GetBaseMaster("UNIT", POLTable.UNIT_CODE).Name;
                        }
                    }
                    rows["QUANTITY"] = (int)POLTable.QUANTITY;
                    rows["PRICE"] = POLTable.PRICE;
                    rows["TOTAL_AMOUNT"] = POLTable.AMOUNT_INCLUDED_TAX;
                    rows["MEMO"] = purchase.MEMO;
                    dt.Rows.Add(rows);
                    TOTAL += POLTable.AMOUNT_INCLUDED_TAX;
                    i++;
                }
                ht.Add("&TOTAL", TOTAL);

                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "HD_PURCHASED_PART_" + supplier.NAME + "_" + purchase.SLIP_DATE.ToString("yyyyMMddhhmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";
                if (sf.ShowDialog(this) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        int ret = CExport.DataTableToExcel_SF(@"rpt\HD_PURCHASED_PART.xls", sf.FileName, dt, ht);
                        if (CConstant.EXPORT_FAILURE.Equals(ret))
                        {
                            MessageBox.Show("导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (CConstant.EXPORT_SUCCESS.Equals(ret))
                        {
                            MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (CConstant.EXPORT_RUNNING.Equals(ret))
                        {
                            MessageBox.Show("文件正在运行，重新生成文件失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST.Equals(ret))
                        {
                            MessageBox.Show("模版文件不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        #endregion

        #region 询价单
        private void btnInquirySheet_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                Hashtable ht = new Hashtable();
                DataTable dt = new DataTable();
                DataGridViewRow row = dgvData.SelectedRows[0];

                BllPurchaseOrderTable purchase = bPurchaseOrder.GetModel(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value));
                BaseSupplierTable supplier = bSupplier.GetModel(CConvert.ToString(row.Cells["SUPPLIER_CODE"].Value));
                if (purchase == null)
                {
                    purchase = new BllPurchaseOrderTable();
                }
                if (supplier == null)
                {
                    supplier = new BaseSupplierTable();
                }

                ht.Add("&SUPPLIER", supplier.NAME);
                ht.Add("&CONTACT_NAME", supplier.CONTACT_NAME);
                ht.Add("&MOBIL_NUMBER", supplier.MOBIL_NUMBER);
                ht.Add("&PHONE_NUMBER", supplier.PHONE_NUMBER);
                ht.Add("&FAX_NUMBER", supplier.FAX_NUMBER);

                dt.Columns.Add("No");
                dt.Columns.Add("SPEC");
                dt.Columns.Add("NAME");
                dt.Columns.Add("UNIT_NAME");
                dt.Columns.Add("QUANTITY");
                dt.Columns.Add("PRICE");
                dt.Columns.Add("TOTAL_AMOUNT");
                dt.Columns.Add("APPLICATION");
                dt.Columns.Add("MEMO");

                DataRow rows = null;
                int i = 0;
                string name = "";
                decimal TOTAL = 0;
                foreach (BllPurchaseOrderLineTable POLTable in purchase.Items)
                {
                    rows = dt.NewRow();
                    rows["No"] = POLTable.LINE_NUMBER;
                    BaseProductTable product = bProduct.GetModel(POLTable.PRODUCT_CODE);
                    if (product != null)
                    {
                        rows["SPEC"] = product.CODE;
                        rows["NAME"] = product.NAME;
                        if (i == 0)
                        {
                            name = product.NAME;
                        }
                        if (bCommon.GetBaseMaster("UNIT", POLTable.UNIT_CODE) != null)
                        {
                            rows["UNIT_NAME"] = bCommon.GetBaseMaster("UNIT", POLTable.UNIT_CODE).Name;
                        }
                    }
                    rows["QUANTITY"] = (int)POLTable.QUANTITY;
                    rows["PRICE"] = POLTable.PRICE;
                    rows["TOTAL_AMOUNT"] = POLTable.AMOUNT_INCLUDED_TAX;
                    rows["MEMO"] = purchase.MEMO;
                    dt.Rows.Add(rows);
                    TOTAL += POLTable.AMOUNT_INCLUDED_TAX;
                    i++;
                }

                ht.Add("&TOTAL", TOTAL);
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "HD_INQUIRY_" + supplier.NAME + "_" + purchase.SLIP_DATE.ToString("yyyyMMdd") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";
                if (sf.ShowDialog(this) == DialogResult.OK)
                {
                    if (dt.Rows.Count > 0)
                    {
                        int ret = CExport.DataTableToExcel_IS(@"rpt\HD_INQUIRY.xls", sf.FileName, dt, ht);
                        if (CConstant.EXPORT_FAILURE.Equals(ret))
                        {
                            MessageBox.Show("导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (CConstant.EXPORT_SUCCESS.Equals(ret))
                        {
                            MessageBox.Show("导出成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (CConstant.EXPORT_RUNNING.Equals(ret))
                        {
                            MessageBox.Show("文件正在运行，重新生成文件失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if (CConstant.EXPORT_TEMPLETE_FILE_NOT_EXIST.Equals(ret))
                        {
                            MessageBox.Show("模版文件不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        #endregion       
    }
}
