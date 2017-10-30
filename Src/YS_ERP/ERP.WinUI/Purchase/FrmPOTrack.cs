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
using System.Collections;

namespace CZZD.ERP.WinUI.Purchase
{
    public partial class FrmPOTrack : Form
    {
        DataTable dt = new DataTable();
        private BPurchaseOrder bPurchaseOrder = new BPurchaseOrder();
        private decimal total = 0;
        private decimal payment = 0;
        private string strWhere;
        private int Receipt;
        private bool libraryNo;
        private bool libraryOk;

        public string STRWHERE
        {
            set { strWhere = value; }
            get { return strWhere; }
        }

        public bool LIBRARYNO
        {
            set { libraryNo = value; }
            get { return libraryNo; }
        }

        public bool LIBRARYOK
        {
            set { libraryOk = value; }
            get { return libraryOk; }
        }

        public FrmPOTrack()
        {
            InitializeComponent();
        }

        private void FrmPOTrack_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("NO", Type.GetType("System.String"));
            dt.Columns.Add("SLIP_NUMBER", Type.GetType("System.String"));
            dt.Columns.Add("PRODUCT_CODE", Type.GetType("System.String"));
            dt.Columns.Add("PRODUCT_NAME", Type.GetType("System.String"));
            dt.Columns.Add("SPEC", Type.GetType("System.String"));
            dt.Columns.Add("SUPPLIER_NAME", Type.GetType("System.String"));
            dt.Columns.Add("QUANTITY", Type.GetType("System.String"));
            dt.Columns.Add("PRICE", Type.GetType("System.String"));
            dt.Columns.Add("AMOUNT", Type.GetType("System.String"));
            dt.Columns.Add("PAYMENT_STATUS", Type.GetType("System.String"));
            dt.Columns.Add("SLIP_DATE", Type.GetType("System.String"));
            dt.Columns.Add("DUE_DATE", Type.GetType("System.String"));
            dt.Columns.Add("DUE_STATUS", Type.GetType("System.String"));
            dt.Columns.Add("DELIVERY_STATUS", Type.GetType("System.String"));
            dt.Columns.Add("ACTUAL_AMOUNT", Type.GetType("System.String"));

            init();
            reSetCurrentDt();
            this.dgvData.DataSource = dt;
        }

        private void init()
        {
            BaseProductTable product = null;
            DataSet ds = bPurchaseOrder.GetList(strWhere);

            int i = 1;
            DataRow row = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                row = dt.NewRow();
                row["NO"] = i++;
                row["SLIP_NUMBER"] = dr["SLIP_NUMBER"];
                string code = CConvert.ToString(dr["PRODUCT_CODE"]);
                product = new BProduct().GetModel(code);
                row["PRODUCT_CODE"] = dr["PRODUCT_CODE"];
                row["PRODUCT_NAME"] = dr["PRODUCT_NAME"];
                if (product == null)
                {
                    product = new BaseProductTable();
                }
                row["SPEC"] = product.SPEC;
                row["SUPPLIER_NAME"] = dr["SUPPLIER_NAME"];
                row["QUANTITY"] = (int)CConvert.ToDecimal(dr["QUANTITY"]);
                row["PRICE"] = dr["PRICE"];
                row["AMOUNT"] = dr["AMOUNT_INCLUDED_TAX"];
                row["SLIP_DATE"] = CConvert.ToDateTime(dr["SLIP_DATE"]).ToString("yyyy-MM-dd");
                row["DUE_DATE"] = CConvert.ToDateTime(dr["DUE_DATE"]).ToString("yyyy-MM-dd");
                DateTime now = CConvert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                DateTime due = CConvert.ToDateTime(CConvert.ToDateTime(dr["DUE_DATE"]).ToString("yyyy-MM-dd"));
                if (now > due)
                {
                    TimeSpan ts = now - due;
                    row["DUE_STATUS"] = "超过期限" + ts.TotalDays + "天";
                }
                else
                {
                    row["DUE_STATUS"] = "未到时间";
                }
                getReceipt(CConvert.ToString(dr["SLIP_NUMBER"]));
                if (Receipt == CConstant.UN_RECEIPT)
                {
                    row["DELIVERY_STATUS"] = "未入库";
                }
                else if (Receipt == CConstant.COMPLETE_RECEIPT)
                {
                    row["DELIVERY_STATUS"] = "入库完了";
                }
                else if (Receipt == CConstant.PART_RECEIPT)
                {
                    row["DELIVERY_STATUS"] = "入库一部分";
                }
                row["ACTUAL_AMOUNT"] = bPurchaseOrder.GetReceiptActualQuantity(CConvert.ToString(dr["SLIP_NUMBER"]), CConvert.ToString(dr["PRODUCT_CODE"]));
                total += CConvert.ToDecimal(dr["AMOUNT_INCLUDED_TAX"]);
                dt.Rows.Add(row);
            }
        }

        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                getReceipt(dt.Rows[i]["SLIP_NUMBER"].ToString());
                if (libraryOk)
                {
                    if (Receipt != CConstant.COMPLETE_RECEIPT)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
                else if (libraryNo)
                {
                    if (Receipt == CConstant.COMPLETE_RECEIPT)
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
            }
            int j = 1;
            foreach (DataRow row in dt.Rows)
            {
                row["NO"] = j;
                j++;
            }
        }

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnExporte_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("&DATE", DateTime.Now.ToString("yyyy/MM/dd"));
            ht.Add("&TOTAL_AMOUNT", total);
            ht.Add("&PAYMENT_AMOUNT", payment);
            ht.Add("&NO_PAYMENT_AMOUNT", total - payment);

            if (dt.Rows.Count > 0)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.FileName = "HD_PURCHASE_ORDER_TRACK_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                sf.Filter = "(文件)|*.xls;*.xlsx";

                if (sf.ShowDialog(this) == DialogResult.OK)
                {
                    int ret = CExport.DataTableToExcel_Purchase_Order_Track(@"rpt\HD_PURCHASE_ORDER_TRACK.xls", sf.FileName, dt, ht);
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
            }
            else
            {
                MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        
    }
}
