using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using System.Collections;
using CZZD.ERP.Bll;

namespace CZZD.ERP.WinUI
{
    public partial class FrmInvoice : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        private BInvoice bInvoice = new BInvoice();
        DataTable exportDt = new DataTable();

        #region 页面初始化
        public FrmInvoice()
        {
            InitializeComponent();
        }

        public FrmInvoice(string CTag)
        {
            this.CTag = CTag;
            InitializeComponent();
        }

        /// <summary>
        /// FrmInvoice_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            dateFrom.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day);

            if (CTag.Equals(CConstant.INVOICE_OEM_SALES))
            {
                this.Text = "OEM销售成绩表";
            }
            else if (CTag.Equals(CConstant.INVOICE_OEM_PRODUCT))
            {
                this.Text = "OEM制品管理表";
            }
            else if (CTag.Equals(CConstant.INVOICE_ACCOUNT_RECEIVABLE))
            {
                this.Text = "应收账款管理表";
            }
            else if (CTag.Equals(CConstant.INVOICE_SUMMARY))
            {
                this.Text = "进销存汇总表";
            }
        }
        #endregion

        #region 报表导出
        private void btnExport_Click(object sender, EventArgs e)
        {

            //OEM销售成绩表
            if (CTag.Equals(CConstant.INVOICE_OEM_SALES))
            {
                ExportOEMSales();
            }
            //OEM制品管理表
            else if (CTag.Equals(CConstant.INVOICE_OEM_PRODUCT))
            {
                ExportOEMProduct();
            }
            //应收账款管理表
            else if (CTag.Equals(CConstant.INVOICE_ACCOUNT_RECEIVABLE))
            {
                ExportFinanceInfo();
            }
        }
        #endregion

        #region 查询条件
        /// <summary>
        /// 查询条件  OEM销售成绩表
        /// </summary>
        /// <returns></returns>
        private string GetOEMSalesConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1 ");
            if (dateFrom.Checked)
            {
                sb.AppendFormat(" AND BOH.SLIP_DATE>='{0}'", dateFrom.Value);
            }

            if (dateTo.Checked)
            {
                sb.AppendFormat(" AND BOH.SLIP_DATE<='{0}'", dateTo.Value);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 查询条件  OEM制品管理表
        /// </summary>
        /// <returns></returns>
        private string GetOEMProductConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1 ");
            if (dateFrom.Checked)
            {
                sb.AppendFormat(" AND BS.SLIP_DATE>='{0}'", dateFrom.Value);
            }

            if (dateTo.Checked)
            {
                sb.AppendFormat(" AND BS.SLIP_DATE<='{0}'", dateTo.Value);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 查询条件  
        /// </summary>
        /// <returns></returns>
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1 ");
            if (dateFrom.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE>='{0}'", dateFrom.Value);
            }

            if (dateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE<='{0}'", dateTo.Value);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 查询条件  OEM制品管理表
        /// </summary>
        /// <returns></returns>
        private string GetReceiptMatchConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1 ");
            if (dateFrom.Checked)
            {
                sb.AppendFormat(" AND BRM.SLIP_DATE>='{0}'", dateFrom.Value);
            }

            if (dateTo.Checked)
            {
                sb.AppendFormat(" AND BRM.SLIP_DATE<='{0}'", dateTo.Value);
            }
            return sb.ToString();
        }
        #endregion

        #region OEM销售成绩表
        /// <summary>
        /// OEM销售成绩表
        /// </summary>
        private void ExportOEMSales()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No");
            dt.Columns.Add("ORDER_SLIP_DATE");
            dt.Columns.Add("RECEIPT_SLIP_DATE");
            dt.Columns.Add("MACHINE_CODE");
            dt.Columns.Add("MACHINE_NAME");
            dt.Columns.Add("CHECK_NUMBER");
            dt.Columns.Add("CHECK_DATE");
            dt.Columns.Add("CUSTOMER_NAME");
            dt.Columns.Add("ENDER_CUSTOMER_NAME");
            dt.Columns.Add("ADDRESS");
            dt.Columns.Add("ADDRESS2");
            string where = GetOEMSalesConduction();

            DataTable salesTable = bInvoice.GetSalesProductInfo(where).Tables[0];
            DataRow dr = null;
            int i = 0;
            foreach (DataRow row in salesTable.Rows)
            {
                dr = dt.NewRow();
                dr["No"] = i.ToString();
                dr["ORDER_SLIP_DATE"] = row["SLIP_DATE"];
                dr["RECEIPT_SLIP_DATE"] = row["CREATE_DATE_TIME"];
                dr["MACHINE_CODE"] = row["SERIAL_NUMBER"];
                dr["MACHINE_NAME"] = row["MACHINE_NAME"];
                dr["CHECK_NUMBER"] = row["CHECK_NUMBER"];
                dr["CHECK_DATE"] = row["CHECK_DATE"];
                dr["CUSTOMER_NAME"] = row["CUSTOMER_NAME"];
                dr["ENDER_CUSTOMER_NAME"] = row["END_CUSTOMER_NAME"];
                dr["ADDRESS"] = row["ADDRESS"];
                dr["ADDRESS2"] = row["ADDRESS"];
                i++;
                dt.Rows.Add(dr);
            }

            Hashtable ht = new Hashtable();
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "LZ_OEM_SALES_PERFORMANCE_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            sf.Filter = "(文件)|*.xls;*.xlsx";
            if (sf.ShowDialog(this) == DialogResult.OK)
            {
                if (dt.Rows.Count > 0)
                {
                    int ret = CExport.ExportOEMSales(@"rpt\OEM_SALES_PERFORMANCE.frx", sf.FileName, dt, ht);
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


        }
        #endregion

        #region OEM制品管理表
        /// <summary>
        ///  OEM制品管理表
        /// </summary>
        public void ExportOEMProduct()
        {
            //OEM制品管理表所需要的导出字段
            #region
            exportDt.Columns.Clear();
            exportDt.Columns.Add("MACHINE_CODE", Type.GetType("System.String")); //机械编号
            exportDt.Columns.Add("MACHINE_NAME", Type.GetType("System.String")); //机械名称
            exportDt.Columns.Add("BODY_PURCHASE_ORDER_SLIP_NUMBER", Type.GetType("System.String")); //机械本体采购订单编号D:\龙泽ERP\ERP.WinUI\Finance\FrmSalesSearch.cs
            exportDt.Columns.Add("BODY_INVOICE_NUMBER_LOCAL", Type.GetType("System.String"));　　　 //机械本体采购发票编号
            exportDt.Columns.Add("BODY_PURCHASE_SLIP_DATE", Type.GetType("System.String"));　　　　 //机械本体采购发票日期
            exportDt.Columns.Add("BODY_INVOICE_AMOUNT", Type.GetType("System.String"));           　//机械本体采购发票金额(含税）
            exportDt.Columns.Add("PART_PURCHASE_ORDER_SLIP_NUMBER", Type.GetType("System.String")); //机械部件采购订单编号(国内)
            exportDt.Columns.Add("PART_INVOICE_NUMBER_LOCAL", Type.GetType("System.String"));       //机械部件采购发票编号(国内)
            exportDt.Columns.Add("PART_PURCHASE_SLIP_DATE", Type.GetType("System.String"));         //机械部件采购发票日期(国内)
            exportDt.Columns.Add("PART_INVOICE_AMOUNT", Type.GetType("System.Decimal"));             //机械部件采购发票金额(含税）(国内)
            exportDt.Columns.Add("FOREIGN_PURCHASE_ORDER_SLIP_NUMBER", Type.GetType("System.String"));　//机械部件采购订单编号(国外)
            exportDt.Columns.Add("FOREIGN_PURCHASE_INVOICE_NUMBER", Type.GetType("System.String"));　　 //机械部件采购发票编号(国外)
            exportDt.Columns.Add("FOREIGN_PURCHASE_SLIP_DATE", Type.GetType("System.String"));          //机械部件采购发票日期(国外)
            exportDt.Columns.Add("FOREIGN_INVOICE_AMOUNT", Type.GetType("System.Decimal"));　            //机械部件采购发票金额(含税）(国外)
            exportDt.Columns.Add("EXCHANGE_RATE", Type.GetType("System.Decimal"));                       //外币汇率
            exportDt.Columns.Add("RMB_INVOICE_AMOUNT", Type.GetType("System.Decimal"));　　　　　　　　　//外币拆合人民币
            exportDt.Columns.Add("TAX_AMOUNT", Type.GetType("System.Decimal"));　　　　　　　　　　　　　//税金
            exportDt.Columns.Add("TOTAL", Type.GetType("System.Decimal"));                               //小计
            exportDt.Columns.Add("TOTAL_AMOUNT", Type.GetType("System.Decimal"));　　　　　　　　　　　　//总金额(采购金额）
            exportDt.Columns.Add("ORDER_SLIP_NUMBER", Type.GetType("System.String"));                   //销售订单编号
            exportDt.Columns.Add("CUSTOMER_PO_NUMBER", Type.GetType("System.String"));                  //销售合同编号
            exportDt.Columns.Add("SHIPMENT_SLIP_DATE", Type.GetType("System.String"));                  //出库日期
            exportDt.Columns.Add("SALES_INVOICE_NUMBER", Type.GetType("System.String"));                //销售发票NO
            exportDt.Columns.Add("ORDER_SLIP_DATE", Type.GetType("System.String"));                     //销售日期
            exportDt.Columns.Add("AMOUNT_WITHOUT_TAX", Type.GetType("System.Decimal"));          //不含税金额
            exportDt.Columns.Add("TOTAL_BODY_AMOUNT", Type.GetType("System.Decimal"));                   //机械本体不含税金额
            exportDt.Columns.Add("PART_AMOUNT", Type.GetType("System.Decimal"));                         //机械部件不含税金额
            exportDt.Columns.Add("GROSS_PROFIT", Type.GetType("System.Decimal"));                        //利润
            exportDt.Columns.Add("CHECK_NUMBER", Type.GetType("System.String"));                        //检查编号
            exportDt.Columns.Add("CHECK_DATE", Type.GetType("System.String"));                          //检查日期
            exportDt.Columns.Add("CUSTOMER_NAME", Type.GetType("System.String"));                       //代理店名称
            exportDt.Columns.Add("ENDER_CUSTOMER_NAME", Type.GetType("System.String"));                 //需要家
            exportDt.Columns.Add("ADDRESS", Type.GetType("System.String"));                             //纳入先地址
            exportDt.Columns.Add("ADDRESS2", Type.GetType("System.String"));                            //纳入先地址2
            exportDt.Columns.Add("FANUC_SERIAL_NUMBER", Type.GetType("System.String"));
            exportDt.Columns.Add("FANUC_SLIP_NUMBER", Type.GetType("System.String"));
            #endregion

            //销售订单编号的取得
            #region
            DataTable slipTable = bInvoice.GetSlipNumber(GetOEMProductConduction()).Tables[0];

            string slip_number = "";
            foreach (DataRow row in slipTable.Rows)
            {
                slip_number += "'" + row["ORDER_SLIP_NUMBER"].ToString() + "',";
            }
            slip_number = slip_number.Substring(0, slip_number.Length - 1);
            #endregion

            //根据取出的slipnumber取得第一部分的数据　机械本体的采购信息
            #region
            DataTable oneDt = bInvoice.GetStatementOneInfo(slip_number).Tables[0];
            DataRow dr = null;
            string machineCode = CConvert.ToString(oneDt.Rows[0]["MACHINE_CODE"]);
            foreach (DataRow row in oneDt.Rows)
            {
                if (machineCode == row["MACHINE_CODE"].ToString())
                {
                    dr = exportDt.NewRow();
                    dr["ORDER_SLIP_NUMBER"] = row["ORDER_SLIP_NUMBER"];
                    dr["MACHINE_CODE"] = row["MACHINE_CODE"];
                    dr["MACHINE_NAME"] = row["MACHINE_NAME"];
                    dr["BODY_PURCHASE_ORDER_SLIP_NUMBER"] = row["PURCHASE_ORDER_NUMBER"];
                    dr["BODY_INVOICE_NUMBER_LOCAL"] = row["INVOICE_NUMBER"];
                    dr["BODY_PURCHASE_SLIP_DATE"] = row["SLIP_DATE"];
                    dr["FANUC_SERIAL_NUMBER"] = row["FANUC_SERIAL_NUMBER"];
                    dr["FANUC_SLIP_NUMBER"] = row["FANUC_SLIP_NUMBER"];
                    dr["BODY_INVOICE_AMOUNT"] = addDecimal(dr["BODY_INVOICE_AMOUNT"], row["INVOICE_AMOUNT"]);
                }
                else
                {
                    exportDt.Rows.Add(dr);
                    dr = exportDt.NewRow();
                    dr["ORDER_SLIP_NUMBER"] = row["ORDER_SLIP_NUMBER"];
                    dr["MACHINE_CODE"] = row["MACHINE_CODE"];
                    dr["MACHINE_NAME"] = row["MACHINE_NAME"];
                    dr["BODY_PURCHASE_ORDER_SLIP_NUMBER"] = row["PURCHASE_ORDER_NUMBER"];
                    dr["BODY_INVOICE_NUMBER_LOCAL"] = row["INVOICE_NUMBER"];
                    dr["BODY_PURCHASE_SLIP_DATE"] = row["SLIP_DATE"];
                    dr["FANUC_SERIAL_NUMBER"] = row["FANUC_SERIAL_NUMBER"];
                    dr["FANUC_SLIP_NUMBER"] = row["FANUC_SLIP_NUMBER"];
                    dr["BODY_INVOICE_AMOUNT"] = row["INVOICE_AMOUNT"];
                    machineCode = row["MACHINE_CODE"].ToString();
                }
            }
            if (dr != null)
            {
                exportDt.Rows.Add(dr);
            }
            #endregion

            //根据取出的ORDER_SLIP_NUMBER取得第二部分的数据　　机械部件的采购信息
            #region
            dr = null;
            BExchange bex = new BExchange();
            DataTable tmpDt = exportDt.Clone();
            DataTable twoDt = bInvoice.GetStatementTwoInfo(slip_number).Tables[0];
            string orderSlipNumber = CConvert.ToString(oneDt.Rows[0]["ORDER_SLIP_NUMBER"]);
            foreach (DataRow row in twoDt.Rows)
            {
                if (orderSlipNumber == row["ORDER_SLIP_NUMBER"].ToString())
                {
                    dr = tmpDt.NewRow();
                    dr["ORDER_SLIP_NUMBER"] = row["ORDER_SLIP_NUMBER"];
                    if (CConvert.ToInt32(row["TYPE"]) == CConstant.ERP_FOREIGN_NUMBER)//国外
                    {
                        dr["FOREIGN_PURCHASE_ORDER_SLIP_NUMBER"] = addString(dr["FOREIGN_PURCHASE_ORDER_SLIP_NUMBER"], row["PURCHASE_ORDER_SLIP_NUMBER"]);
                        dr["FOREIGN_PURCHASE_INVOICE_NUMBER"] = addString(dr["FOREIGN_PURCHASE_INVOICE_NUMBER"], row["INVOICE_NUMBER"]);
                        dr["FOREIGN_PURCHASE_SLIP_DATE"] = addString(dr["FOREIGN_PURCHASE_SLIP_DATE"], row["SLIP_DATE"]);
                        dr["FOREIGN_INVOICE_AMOUNT"] = addDecimal(dr["FOREIGN_INVOICE_AMOUNT"], row["INVOICE_AMOUNT"]);
                        DateTime datatime = CConvert.ToDateTime(CConvert.ToDateTime(dr["FOREIGN_INVOICE_AMOUNT"].ToString()).Year + "/" + CConvert.ToDateTime(dr["FOREIGN_INVOICE_AMOUNT"].ToString()).Month + "/1");
                        DataTable ExchangeTable = bex.GetExchangeFromTime(datatime, "", "").Tables[0];
                        dr["EXCHANGE_RATE"] = ExchangeTable.Rows[0]["EXCHANGE_RATE"].ToString();
                        dr["RMB_INVOICE_AMOUNT"] = addDecimal(dr["RMB_INVOICE_AMOUNT"], CConvert.ToDecimal(row["INVOICE_AMOUNT"]) * CConvert.ToDecimal(dr["EXCHANGE_RATE"]));
                    }
                    else if (CConvert.ToInt32(row["TYPE"]) == CConstant.ERP_DOMESTIC_NUMBER)//国内
                    {
                        dr["PART_PURCHASE_ORDER_SLIP_NUMBER"] = addString(dr["PART_PURCHASE_ORDER_SLIP_NUMBER"], row["PURCHASE_ORDER_SLIP_NUMBER"]);
                        dr["PART_INVOICE_NUMBER_LOCAL"] = addString(dr["PART_INVOICE_NUMBER_LOCAL"], row["INVOICE_NUMBER"]);
                        dr["PART_PURCHASE_SLIP_DATE"] = addString(dr["PART_PURCHASE_SLIP_DATE"], row["SLIP_DATE"]);
                        dr["PART_INVOICE_AMOUNT"] = addDecimal(dr["PART_INVOICE_AMOUNT"], row["INVOICE_AMOUNT"]);
                    }
                    dr["TAX_AMOUNT"] = addDecimal(dr["TAX_AMOUNT"], row["TAX_AMOUNT"]);
                }
                else
                {
                    tmpDt.Rows.Add(dr);
                    orderSlipNumber = row["ORDER_SLIP_NUMBER"].ToString();
                    dr = tmpDt.NewRow();
                    dr["ORDER_SLIP_NUMBER"] = row["ORDER_SLIP_NUMBER"];
                    if (CConvert.ToInt32(row["SUPPLIER_CODE"]) == CConstant.ERP_FOREIGN_NUMBER)//国外
                    {
                        dr["FOREIGN_PURCHASE_ORDER_SLIP_NUMBER"] = addString(dr["FOREIGN_PURCHASE_ORDER_SLIP_NUMBER"], row["PURCHASE_ORDER_SLIP_NUMBER"]);
                        dr["FOREIGN_PURCHASE_INVOICE_NUMBER"] = addString(dr["FOREIGN_PURCHASE_INVOICE_NUMBER"], row["INVOICE_NUMBER"]);
                        dr["FOREIGN_PURCHASE_SLIP_DATE"] = addString(dr["FOREIGN_PURCHASE_SLIP_DATE"], row["SLIP_DATE"]);
                        dr["FOREIGN_INVOICE_AMOUNT"] = addDecimal(dr["FOREIGN_INVOICE_AMOUNT"], row["INVOICE_AMOUNT"]);
                        dr["EXCHANGE_RATE"] = 0.07;
                        dr["RMB_INVOICE_AMOUNT"] = addDecimal(dr["RMB_INVOICE_AMOUNT"], CConvert.ToDecimal(row["INVOICE_AMOUNT"]) * CConvert.ToDecimal(dr["EXCHANGE_RATE"]));
                    }
                    else if (CConvert.ToInt32(row["SUPPLIER_CODE"]) == CConstant.ERP_DOMESTIC_NUMBER)//国内
                    {
                        dr["PART_PURCHASE_ORDER_SLIP_NUMBER"] = addString(dr["PART_PURCHASE_ORDER_SLIP_NUMBER"], row["PURCHASE_ORDER_SLIP_NUMBER"]);
                        dr["PART_INVOICE_NUMBER_LOCAL"] = addString(dr["PART_INVOICE_NUMBER_LOCAL"], row["INVOICE_NUMBER"]);
                        dr["PART_PURCHASE_SLIP_DATE"] = addString(dr["PART_PURCHASE_SLIP_DATE"], row["SLIP_DATE"]);
                        dr["PART_INVOICE_AMOUNT"] = addDecimal(dr["PART_INVOICE_AMOUNT"], row["INVOICE_AMOUNT"]);
                    }
                    dr["TAX_AMOUNT"] = addDecimal(dr["TAX_AMOUNT"], row["TAX_AMOUNT"]);
                }
            }
            if (dr != null)
            {
                tmpDt.Rows.Add(dr);
            }
            #endregion

            //采购信息段的合并
            #region
            foreach (DataRow row in exportDt.Rows)
            {
                foreach (DataRow tRow in tmpDt.Rows)
                {
                    if (row["ORDER_SLIP_NUMBER"].Equals(tRow["ORDER_SLIP_NUMBER"]))
                    {
                        row["FOREIGN_PURCHASE_ORDER_SLIP_NUMBER"] = tRow["FOREIGN_PURCHASE_ORDER_SLIP_NUMBER"];
                        row["FOREIGN_PURCHASE_INVOICE_NUMBER"] = tRow["FOREIGN_PURCHASE_INVOICE_NUMBER"];
                        row["FOREIGN_PURCHASE_SLIP_DATE"] = tRow["FOREIGN_PURCHASE_SLIP_DATE"];
                        row["FOREIGN_INVOICE_AMOUNT"] = tRow["FOREIGN_INVOICE_AMOUNT"];
                        row["EXCHANGE_RATE"] = tRow["EXCHANGE_RATE"];
                        row["RMB_INVOICE_AMOUNT"] = tRow["RMB_INVOICE_AMOUNT"];
                        row["PART_PURCHASE_ORDER_SLIP_NUMBER"] = tRow["PART_PURCHASE_ORDER_SLIP_NUMBER"];
                        row["PART_INVOICE_NUMBER_LOCAL"] = tRow["PART_INVOICE_NUMBER_LOCAL"];
                        row["PART_PURCHASE_SLIP_DATE"] = tRow["PART_PURCHASE_SLIP_DATE"];
                        row["PART_INVOICE_AMOUNT"] = tRow["PART_INVOICE_AMOUNT"];
                        row["TAX_AMOUNT"] = tRow["TAX_AMOUNT"];
                    }
                }
            }
            #endregion

            //销售信息的取得
            #region
            DataTable OrderTable = bInvoice.GetOrderHeaderInfo(slip_number).Tables[0];
            foreach (DataRow erow in exportDt.Rows)
            {
                foreach (DataRow Orow in OrderTable.Rows)
                {
                    if (erow["ORDER_SLIP_NUMBER"].Equals(Orow["SLIP_NUMBER"]))
                    {
                        erow["CUSTOMER_PO_NUMBER"] = Orow["CUSTOMER_PO_NUMBER"];
                        erow["SALES_INVOICE_NUMBER"] = Orow["SERIAL_NUMBER"];
                        erow["ORDER_SLIP_DATE"] = Orow["SLIP_DATE"];
                        erow["AMOUNT_WITHOUT_TAX"] = Orow["AMOUNT_WITHOUT_TAX"];
                        erow["CHECK_NUMBER"] = Orow["CHECK_NUMBER"];
                        erow["CHECK_DATE"] = Orow["CHECK_DATE"];
                        erow["CUSTOMER_NAME"] = Orow["CUSTOMER_NAME"];
                        erow["ENDER_CUSTOMER_NAME"] = Orow["ENDER_CUSTOMER_NAME"];
                        erow["ADDRESS"] = Orow["DELIVERY_POINT_NAME"];
                        erow["ADDRESS2"] = Orow["DELIVERY_POINT_NAME"];
                    }
                }

            }
            #endregion

            //销售发票信息的取得
            #region
            DataTable InvoiceTable = bInvoice.GetInvoiceNumber(slip_number).Tables[0];
            foreach (DataRow irow in exportDt.Rows)
            {
                foreach (DataRow Irow in InvoiceTable.Rows)
                {
                    if (irow["ORDER_SLIP_NUMBER"].Equals(Irow["ORDER_SLIP_NUMBER"]))
                    {
                        irow["SALES_INVOICE_NUMBER"] = Irow["SALES_INVOICE_NUMBER"];
                        irow["SHIPMENT_SLIP_DATE"] = Irow["SLIP_DATE"];
                    }
                }
            }
            #endregion

            //机器本体的销售信息的取得
            #region
            DataTable TotalBodyAmount = bInvoice.GetAmountWithoutTaxa(slip_number).Tables[0];
            foreach (DataRow totalrow in exportDt.Rows)
            {
                foreach (DataRow Totalrow in TotalBodyAmount.Rows)
                {
                    if (totalrow["ORDER_SLIP_NUMBER"].Equals(Totalrow["SLIP_NUMBER"]))
                    {
                        totalrow["TOTAL_BODY_AMOUNT"] = Totalrow["AMOUNT_WITHOUT_TAX"];
                    }
                }
            }
            #endregion

            //各种合计金额的计算
            #region
            foreach (DataRow row in exportDt.Rows)
            {
                row["TOTAL"] = addDecimal(row["RMB_INVOICE_AMOUNT"], row["TAX_AMOUNT"]);
                row["TOTAL_AMOUNT"] = addDecimal(row["BODY_INVOICE_AMOUNT"], row["PART_INVOICE_AMOUNT"], row["TOTAL"]);
            }
            #endregion

            //数据的导出
            #region
            Hashtable ht = new Hashtable();
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "LZ_PRODUCT_MANAGEMENT_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            sf.Filter = "(文件)|*.xls;*.xlsx";
            if (sf.ShowDialog(this) == DialogResult.OK)
            {
                if (exportDt.Rows.Count > 0)
                {
                    int ret = CExport.ExportOEMProduct(@"rpt\OEM_PRODUCT_MANAGEMENT.frx", sf.FileName, exportDt, ht);
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            #endregion
        }
        #endregion

        #region 应收账款管理表
        /// <summary>
        /// 应收账款管理表
        /// </summary>
        private void ExportFinanceInfo()
        {
            exportDt = new DataTable();
            exportDt.Columns.Add("SLIP_NUMBER", Type.GetType("System.String")); //开票内部订单编号
            exportDt.Columns.Add("SLIP_DATE", Type.GetType("System.String")); //开票日期
            exportDt.Columns.Add("SERIAL_NUMBER", Type.GetType("System.String")); //发票内容
            exportDt.Columns.Add("MODEL_NUMBER", Type.GetType("System.String")); //机械型号
            exportDt.Columns.Add("CUSTOMER_PO_NUMBER", Type.GetType("System.String")); //合同编号
            exportDt.Columns.Add("CUSTOMER_NAME", Type.GetType("System.String")); //代理店
            exportDt.Columns.Add("ENDUSER_CUSTOMER_NAME", Type.GetType("System.String")); //最终客户
            exportDt.Columns.Add("SHIPMENT_SLIP_DATE", Type.GetType("System.String")); //出库日期
            exportDt.Columns.Add("QUANTITY", Type.GetType("System.Decimal")); //数量
            exportDt.Columns.Add("INVOICE_NUMBER", Type.GetType("System.String")); //发票No
            exportDt.Columns.Add("INVOICE_AMOUNT_WITHOUT_TAX", Type.GetType("System.Decimal")); //未含税金额
            exportDt.Columns.Add("INVOICE_AMOUNT", Type.GetType("System.Decimal")); //含税金额
            exportDt.Columns.Add("CUSTOMER_CLAIM_DATE", Type.GetType("System.String")); //收款预定日期
            exportDt.Columns.Add("RECEIVABLES_DATE_1", Type.GetType("System.String")); //收款日期1
            exportDt.Columns.Add("RECEIVABLES_1", Type.GetType("System.Decimal")); //收款金额1
            exportDt.Columns.Add("RECEIVABLES_DATE_2", Type.GetType("System.String")); //收款日期2
            exportDt.Columns.Add("RECEIVABLES_2", Type.GetType("System.Decimal")); //收款金额2
            exportDt.Columns.Add("RECEIVABLES_DATE_3", Type.GetType("System.String")); //收款日期3
            exportDt.Columns.Add("RECEIVABLES_3", Type.GetType("System.Decimal")); //收款金额3
            exportDt.Columns.Add("UN_RECEIVABLES", Type.GetType("System.Decimal")); //未收款金额
            exportDt.Columns.Add("TOTAL_RECEIVABLES", Type.GetType("System.Decimal")); //总收款金额

            DataTable exportMachineDt = exportDt.Clone();
            DataTable exportPartsDt = exportDt.Clone();
            string invoiceNumber = "";
            DataRow eDr = null;

            //获得机械本体应收账款
            #region
            DataTable machineDT = bInvoice.GetMachineAccountReceivable(GetConduction()).Tables[0];
            foreach (DataRow dr in machineDT.Rows)
            {
                if (!invoiceNumber.Equals(dr["INVOICE_NUMBER"]))
                {
                    if (invoiceNumber != "")
                    {
                        exportMachineDt.Rows.Add(eDr);
                    }
                    eDr = exportMachineDt.NewRow();
                    eDr["SLIP_NUMBER"] = dr["SLIP_NUMBER"]; //开票内部订单编号
                    eDr["SLIP_DATE"] = dr["SLIP_DATE"]; //开票日期
                    eDr["SERIAL_NUMBER"] = dr["SERIAL_NUMBER"]; //发票内容
                    eDr["MODEL_NUMBER"] = dr["MODEL_NUMBER"];  //机械型号
                    eDr["CUSTOMER_PO_NUMBER"] = dr["CUSTOMER_PO_NUMBER"]; //合同编号
                    eDr["CUSTOMER_NAME"] = dr["CUSTOMER_NAME"]; //代理店
                    eDr["ENDUSER_CUSTOMER_NAME"] = dr["ENDUSER_CUSTOMER_NAME"]; //最终客户
                    eDr["SHIPMENT_SLIP_DATE"] = dr["SHIPMENT_SLIP_DATE"]; //出库日期
                    eDr["QUANTITY"] = 1;//dr["QUANTITY"]; //数量
                    eDr["INVOICE_NUMBER"] = dr["INVOICE_NUMBER"]; //发票No
                    eDr["INVOICE_AMOUNT_WITHOUT_TAX"] = GetAmountWithoutTax(dr["INVOICE_AMOUNT"], dr["TAX_RATE"]); //未含税金额
                    eDr["INVOICE_AMOUNT"] = dr["INVOICE_AMOUNT"]; //含税金额
                    eDr["CUSTOMER_CLAIM_DATE"] = dr["CUSTOMER_CLAIM_DATE"]; //收款预定日期
                    invoiceNumber = CConvert.ToString(dr["INVOICE_NUMBER"]);
                }
            }
            if (eDr != null)
            {
                exportMachineDt.Rows.Add(eDr);
            }
            #endregion

            //获得机械部件应收账款
            #region
            DataTable partsDT = bInvoice.GetPartsAccountReceivable(GetConduction()).Tables[0];
            invoiceNumber = "";
            eDr = null;
            foreach (DataRow dr in partsDT.Rows)
            {
                if (!invoiceNumber.Equals(dr["INVOICE_NUMBER"]))
                {
                    if (invoiceNumber != "")
                    {
                        exportPartsDt.Rows.Add(eDr);
                    }
                    eDr = exportPartsDt.NewRow();
                    eDr["SLIP_NUMBER"] = dr["SLIP_NUMBER"]; //开票内部订单编号
                    eDr["SLIP_DATE"] = dr["SLIP_DATE"]; //开票日期
                    eDr["SERIAL_NUMBER"] = dr["SERIAL_NUMBER"]; //发票内容
                    eDr["MODEL_NUMBER"] = "";//dr["MODEL_NUMBER"];  //机械型号
                    eDr["CUSTOMER_PO_NUMBER"] = dr["CUSTOMER_PO_NUMBER"]; //合同编号
                    eDr["CUSTOMER_NAME"] = dr["CUSTOMER_NAME"]; //代理店
                    eDr["ENDUSER_CUSTOMER_NAME"] = dr["ENDUSER_CUSTOMER_NAME"]; //最终客户
                    eDr["SHIPMENT_SLIP_DATE"] = dr["SHIPMENT_SLIP_DATE"]; //出库日期
                    eDr["QUANTITY"] = 1;//dr["QUANTITY"]; //数量
                    eDr["INVOICE_NUMBER"] = dr["INVOICE_NUMBER"]; //发票No
                    eDr["INVOICE_AMOUNT_WITHOUT_TAX"] = GetAmountWithoutTax(dr["INVOICE_AMOUNT"], dr["TAX_RATE"]); //未含税金额
                    eDr["INVOICE_AMOUNT"] = dr["INVOICE_AMOUNT"]; //含税金额
                    eDr["CUSTOMER_CLAIM_DATE"] = dr["CUSTOMER_CLAIM_DATE"]; //收款预定日期
                    invoiceNumber = CConvert.ToString(dr["INVOICE_NUMBER"]);
                }
            }
            if (eDr != null)
            {
                exportPartsDt.Rows.Add(eDr);
            }
            #endregion

            decimal totalAmount = 0;
            decimal machineTotalAmount = 0;
            decimal machineTotalAmountWithoutTax = 0;
            decimal partTotalAmountWithoutTax = 0;
            //付款信息的实装
            #region
            //获得开票付款信息
            DataTable receiptDT = bInvoice.GetReceiptMatch(GetReceiptMatchConduction()).Tables[0];

            //机械本体的开票信息的实装
            foreach (DataRow dr in exportMachineDt.Rows)
            {
                int i = 1;
                foreach (DataRow rDr in receiptDT.Rows)
                {
                    if (CConvert.ToString(dr["SLIP_NUMBER"]).Equals(rDr["SLIP_NUMBER"]))
                    {
                        dr["RECEIVABLES_DATE_" + i] = rDr["SLIP_DATE"];
                        dr["RECEIVABLES_" + i] = rDr["RECEIPT_AMOUNT"];
                        i++;
                        if (i > 3)
                        {
                            break;
                        }
                    }
                }
                dr["TOTAL_RECEIVABLES"] = addDecimal(dr["RECEIVABLES_1"], dr["RECEIVABLES_2"], dr["RECEIVABLES_3"]);
                dr["UN_RECEIVABLES"] = CConvert.ToDecimal(dr["INVOICE_AMOUNT"]) - CConvert.ToDecimal(dr["TOTAL_RECEIVABLES"]);

                machineTotalAmountWithoutTax += CConvert.ToDecimal(dr["INVOICE_AMOUNT_WITHOUT_TAX"]);
                machineTotalAmount += CConvert.ToDecimal(dr["INVOICE_AMOUNT"]);
                totalAmount += machineTotalAmount;
            }

            //机械部件的开票信息的实装
            foreach (DataRow dr in exportPartsDt.Rows)
            {
                int i = 1;
                foreach (DataRow rDr in receiptDT.Rows)
                {
                    if (CConvert.ToString(dr["SLIP_NUMBER"]).Equals(rDr["SLIP_NUMBER"]))
                    {
                        dr["RECEIVABLES_DATE_" + i] = rDr["SLIP_DATE"];
                        dr["RECEIVABLES_" + i] = rDr["RECEIPT_AMOUNT"];
                        i++;
                        if (i > 3)
                        {
                            break;
                        }
                    }
                }
                dr["TOTAL_RECEIVABLES"] = addDecimal(dr["RECEIVABLES_1"], dr["RECEIVABLES_2"], dr["RECEIVABLES_3"]);
                dr["UN_RECEIVABLES"] = CConvert.ToDecimal(dr["INVOICE_AMOUNT"]) - CConvert.ToDecimal(dr["TOTAL_RECEIVABLES"]);

                partTotalAmountWithoutTax += CConvert.ToDecimal(dr["INVOICE_AMOUNT_WITHOUT_TAX"]);
                totalAmount += CConvert.ToDecimal(dr["INVOICE_AMOUNT"]); ;
            }
            #endregion


            //数据的导出
            string[] headerTitles = { "发票内部编号", "発行年月", "発票内容", "機械型番", "契約書No.", "商社名", "顧客名", "出荷日", "台数", "発票No.", "金額(税抜）(元)", "金額(税込)(元)", "入金予定日", "入金日1", "入金額(元)1", "入金日2", "入金額(元)2", "入金日3", "入金額(元)3", "未入金額(元)", "入金総額(元)" };
            #region
            Hashtable ht = new Hashtable();
            ht.Add("&DATE", dateFrom.Text + (dateTo.Checked == true ? " 至 " + dateTo.Text : ""));
            ht.Add("&TOTAL_AMOUNT", totalAmount);
            ht.Add("&MACHINE_TOTAL_AMOUNT", machineTotalAmount);
            ht.Add("&B_MACHINE_TOTAL_AMOUNT_WITHOUT_TAX", machineTotalAmountWithoutTax);
            ht.Add("&PART_TOTAL_AMOUNT_WITHOUT_TAX", partTotalAmountWithoutTax);
            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "LZ_RECEIVABLES_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            sf.Filter = "(文件)|*.xls;*.xlsx";
            if (sf.ShowDialog(this) == DialogResult.OK)
            {
                if (exportMachineDt.Rows.Count > 0 || exportPartsDt.Rows.Count > 0)
                {
                    int ret = CExport.ExportReceivables(@"rpt\Receivables.frx", sf.FileName, exportMachineDt, exportPartsDt, ht, headerTitles);
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("明细信息不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            #endregion
        }
        #endregion

        #region 工具方法
        /// <summary>
        /// 文字列的内容相加，己经存在的内容不相加
        /// </summary>
        private string addString(object first, object two)
        {
            string f = CConvert.ToString(first);
            string t = CConvert.ToString(two);
            if (!f.Contains(t))
            {
                if (f != "")
                {
                    f += t + "\r";
                }
                else
                {
                    f = t;
                }

            }
            return f;
        }

        /// <summary>
        /// 数字列求合
        /// </summary>
        private decimal addDecimal(object first, object two)
        {
            decimal f = CConvert.ToDecimal(first);
            decimal t = CConvert.ToDecimal(two);
            return f + t;
        }

        /// <summary>
        /// 数字列求合
        /// </summary>
        private decimal addDecimal(object first, object two, object three)
        {
            decimal f = CConvert.ToDecimal(first);
            decimal t = CConvert.ToDecimal(two);
            decimal h = CConvert.ToDecimal(three);
            return f + t + h;
        }

        /// <summary>
        /// 获得未含税金额
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="taxRate"></param>
        /// <returns></returns>
        private decimal GetAmountWithoutTax(object totalAmount, object taxRate)
        {
            decimal a = CConvert.ToDecimal(totalAmount);
            decimal r = CConvert.ToDecimal(taxRate);
            return Math.Round(a / (1 + r), 2);
        }
        #endregion

        #region 取消
        /// <summary>
        /// 取消
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要关闭吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion
    }//end class
}
