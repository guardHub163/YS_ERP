using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using CZZD.ERP.Main;

namespace CZZD.ERP.WinUI
{
    public partial class FrmStockReView : FrmBase
    {
        private string warehousecode;
        private string productcode;
        private string _type;

        public FrmStockReView()
        {
            InitializeComponent();
        }

        public string WAREHOUSE
        {
            set { warehousecode = value; }
            get { return warehousecode; }
        }

        public string PRODUCT
        {
            set { productcode = value; }
            get { return productcode; }
        }
        public string TYPE
        {
            set { _type = value; }
            get { return _type; }
        }

        private void FrmStockReView_Load(object sender, EventArgs e)
        {
            init();
            PageSize = 16;
            if (_type == CConstant.STOCK_RECEIVING_PLAN_LIST)
            {
                this.dgvData.Columns["NAME"].HeaderText = "供应商名称";
                this.dgvData.Columns["DUE_DATE"].HeaderText = "入库时间";
                this.dgvData.Columns["QUANTITY"].HeaderText = "入库预定数量";
                this.Text = "入库预定详细";
                ReceiptSearch(1);
            }

            if (_type == CConstant.STOCK_ALLOATION_LIST)
            {
                this.dgvData.Columns["NAME"].HeaderText = "客户名称";
                this.dgvData.Columns["DUE_DATE"].HeaderText = "出库时间";
                this.dgvData.Columns["QUANTITY"].HeaderText = "出库预定数量";
                this.Text = "引当详细";
                AlloationSearch(1);
            }
        }

        #region dgvData 初始化
        public void init()
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            dgvData.Rows.Add(PageSize);
            dgvData.Rows[0].Selected = true;
        }
        #endregion

        #region 入库初始化
        public void ReceiptSearch(int currentPage)
        {
            int recordCount = bStock.GetReceiptRecordCount(warehousecode, productcode);
            this.pgControl.init(GetTotalPage(recordCount), currentPage);
            ReceiptList(currentPage);
        }

        public void ReceiptList(int currentPage)
        {
            DataSet ds = bStock.GetReceiptList(warehousecode, productcode, (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            dgvData.Rows.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells[1].Selected = false;
                row.Cells["WAREHOUSE_CODE"].Value = CConvert.ToString(dr["RECEIPT_WAREHOUSE_CODE"]);
                row.Cells["WAREHOUSE_NAME"].Value = CConvert.ToString(dr["WAREHOUSE_NAME"]);
                row.Cells["PRODUCT_CODE"].Value = CConvert.ToString(dr["PRODUCT_CODE"]);
                row.Cells["PRODUCT_NAME"].Value = CConvert.ToString(dr["PRODUCT_NAME"]);
                row.Cells["NAME"].Value = CConvert.ToString(dr["SUPPLIER_NAME"]);
                row.Cells["DUE_DATE"].Value = CConvert.ToDateTime(dr["DUE_DATE"]).ToString("yyyy-MM-dd");
                row.Cells["SLIP_NUMBER"].Value = CConvert.ToString(dr["PURCHASE_ORDER_SLIP_NUMBER"]);
                row.Cells["QUANTITY"].Value = CConvert.ToDecimal(dr["RECEIPT_PLAN_QUANTITY"]);
            }
            if (ds.Tables[0].Rows.Count < PageSize)
            {
                dgvData.Rows.Add(PageSize - ds.Tables[0].Rows.Count);
            }
            
        }
        #endregion

        #region 引当初始化
        public void AlloationSearch(int currentPage)
        {
            int recordCount = bStock.GetAlloationRecordCount(warehousecode, productcode);
            this.pgControl.init(GetTotalPage(recordCount), currentPage);
            AlloationList(1);
        }

        public void AlloationList(int currentPage)
        {
            DataSet ds = bStock.GetAlloationList(warehousecode, productcode, (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            dgvData.Rows.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int currentRowIndex = dgvData.Rows.Add(1);
                DataGridViewRow row = dgvData.Rows[currentRowIndex];
                row.Cells[1].Selected = true;
                row.Cells["WAREHOUSE_CODE"].Value = CConvert.ToString(dr["WAREHOUSE_CODE"]);
                row.Cells["WAREHOUSE_NAME"].Value = CConvert.ToString(dr["WAREHOUSE_NAME"]);
                row.Cells["PRODUCT_CODE"].Value = CConvert.ToString(dr["PRODUCT_CODE"]);
                row.Cells["PRODUCT_NAME"].Value = CConvert.ToString(dr["PRODUCT_NAME"]);
                row.Cells["NAME"].Value = CConvert.ToString(dr["ENDER_CUSTOMER_NAME"]);
                row.Cells["DUE_DATE"].Value = CConvert.ToDateTime(dr["DUE_DATE"]).ToString("yyyy-MM-dd");
                row.Cells["SLIP_NUMBER"].Value = CConvert.ToString(dr["ORDER_SLIP_NUMBER"]);
                row.Cells["QUANTITY"].Value = CConvert.ToDecimal(dr["QUANTITY"]);
            }
            if (ds.Tables[0].Rows.Count < PageSize)
            {
                dgvData.Rows.Add(PageSize - ds.Tables[0].Rows.Count);
            }
            
        }
        #endregion

        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            if (_type == CConstant.STOCK_RECEIVING_PLAN_LIST)
            {
                ReceiptList(currentPage);
            }
            if (_type == CConstant.STOCK_ALLOATION_LIST)
            {
                AlloationList(currentPage);
            }
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
                if (row.Cells["WAREHOUSE_CODE"].Value == null || "".Equals(row.Cells["WAREHOUSE_CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
    }
}
