using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.DBUtility;
using CZZD.ERP.IDAL;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class InvoiceManage : IInvoice
    {
        #region OEM制品管理表数据的获得

        /// <summary>
        /// 获得所有包含机械本体的销售订单
        /// </summary>
        public DataSet GetSlipNumber(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT distinct BSL.ORDER_SLIP_NUMBER FROM dbo.BLL_SALES BS ");
            strSql.Append("LEFT JOIN dbo.BLL_SALES_LINE BSL ON BS.SLIP_NUMBER=BSL.SLIP_NUMBER ");
            strSql.Append("LEFT JOIN dbo.BLL_SHIPMENT BSH ON BSL.SHIPMENT_SLIP_NUMBER=BSH.SLIP_NUMBER ");
            strSql.Append("LEFT JOIN dbo.BLL_SHIPMENT_LINE BSHL ON BSH.SLIP_NUMBER=BSHL.SLIP_NUMBER ");
            strSql.Append("LEFT JOIN dbo.BASE_PRODUCT BP ON BSHL.PRODUCT_CODE=BP.CODE ");
            strSql.AppendFormat("WHERE {0} AND BP.MECHANICAL_DISTINCTION_FLAG={1} AND  BS.STATUS_FLAG <> {2} ", where, CConstant.MECHANICAL_BASE, CConstant.DELETE);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得本械本体的采购信息
        /// </summary>
        /// <param name="orderSlipNumber"></param>
        /// <returns></returns>
        public DataSet GetStatementOneInfo(string orderSlipNumbers)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT distinct BS.ORDER_SLIP_NUMBER,BS.SLIP_NUMBER,BMM.MACHINE_CODE,BMM.MACHINE_NAME,BP.INVOICE_NUMBER,BP.SLIP_DATE,BMM.FANUC_SERIAL_NUMBER,BMM.FANUC_SLIP_NUMBER,");
            strSql.Append("BP.INVOICE_AMOUNT,BPL.PURCHASE_ORDER_NUMBER FROM dbo.BLL_SHIPMENT AS BS ");
            strSql.Append("LEFT JOIN dbo.BASE_MASTER_MACHINE AS BMM ON BS.SERIAL_NUMBER = BMM.MACHINE_CODE ");
            strSql.Append("LEFT JOIN dbo.BLL_PURCHASE AS BP ON BMM.PURCHASE_SLIP_NUMBER=BP.SLIP_NUMBER ");
            strSql.Append("LEFT JOIN dbo.BLL_PURCHASE_LINE AS BPL ON BP.SLIP_NUMBER = BPL.SLIP_NUMBER ");
            strSql.Append("WHERE BMM.MACHINE_CODE IS NOT NULL  ");
            strSql.AppendFormat("AND BS.ORDER_SLIP_NUMBER in ( {0})", orderSlipNumbers);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得非机械本体的采购信息
        /// </summary>
        /// <param name="orderSlipNumber"></param>
        /// <returns></returns>
        public DataSet GetStatementTwoInfo(string orderSlipNumbers)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT BPO.ORDER_SLIP_NUMBER,BPO.SLIP_NUMBER AS PURCHASE_ORDER_SLIP_NUMBER,");
            strSql.Append(" BP.INVOICE_NUMBER,BP.SLIP_DATE,BPL.INVOICE_AMOUNT,");
            strSql.Append(" BPL.TAX_AMOUNT, BPO.SUPPLIER_CODE,BSU.TYPE, ");
            strSql.Append(" BPD.MECHANICAL_DISTINCTION_FLAG FROM dbo.BLL_PURCHASE_ORDER AS BPO ");
            strSql.Append(" LEFT JOIN dbo.BLL_RECEIPT AS BR ON BPO.SLIP_NUMBER = BR.PO_SLIP_NUMBER ");
            strSql.Append(" LEFT JOIN BLL_RECEIPT_LINE AS BRL ON BR.SLIP_NUMBER=BRL.SLIP_NUMBER ");
            strSql.Append(" LEFT JOIN BASE_PRODUCT AS BPD ON BPD.CODE=BRL.PRODUCT_CODE");
            strSql.Append(" LEFT JOIN dbo.BLL_PURCHASE_LINE AS BPL ON BRL.SLIP_NUMBER=BPL.RECEIPT_SLIP_NUMBER AND BRL.LINE_NUMBER=BPL.RECEIPT_LINE_NUMBER ");
            strSql.Append(" LEFT JOIN dbo.BLL_PURCHASE AS BP ON BPL.SLIP_NUMBER = BP.SLIP_NUMBER ");
            strSql.Append(" LEFT JOIN dbo.BASE_SUPPLIER AS BSU ON BPO.SUPPLIER_CODE = BSU.CODE ");
            strSql.AppendFormat(" WHERE BPD.MECHANICAL_DISTINCTION_FLAG={0} AND BPO.ORDER_SLIP_NUMBER  in  ( {1})", CConstant.MECHANICAL_PART, orderSlipNumbers);
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///<summary>
        ///　获得销售信息
        ///</summary>
        public DataSet GetOrderHeaderInfo(string orderSlipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT * FROM bll_order_header_seach_view Where SLIP_NUMBER in ({0})", orderSlipNumber);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得销售发票信息
        /// </summary>
        public DataSet GetInvoiceNumber(string orderSlipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SA.INVOICE_NUMBER AS SALES_INVOICE_NUMBER ,BS.ORDER_SLIP_NUMBER,BS.SLIP_DATE ");
            strSql.Append("from dbo.BLL_SHIPMENT AS BS ");
            strSql.Append("LEFT JOIN dbo.BLL_SALES_LINE AS SL ON SL.ORDER_SLIP_NUMBER=BS.ORDER_SLIP_NUMBER ");
            strSql.Append("LEFT JOIN BLL_SALES AS SA ON SA.SLIP_NUMBER=SL.SLIP_NUMBER ");
            strSql.AppendFormat("WHERE BS.ORDER_SLIP_NUMBER in ({0}) ORDER BY BS.ORDER_SLIP_NUMBER ", orderSlipNumber);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得销售的机械本体不含税金额
        /// </summary>
        public DataSet GetAmountWithoutTaxa(string orderSlipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BOH.AMOUNT_WITHOUT_TAX,BOH.SLIP_NUMBER from BLL_ORDER_HEADER AS BOH ");
            strSql.Append("LEFT JOIN BLL_ORDER_LINE AS BOL ON BOL.SLIP_NUMBER=BOH.SLIP_NUMBER ");
            strSql.Append("LEFT JOIN dbo.BASE_PRODUCT AS BP ON BP.CODE=BOL.PRODUCT_CODE ");
            strSql.AppendFormat("WHERE BP.MECHANICAL_DISTINCTION_FLAG={0} AND BOH.SLIP_NUMBER in ({1})", CConstant.MECHANICAL_BASE, orderSlipNumber);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region  OEM销售成绩表数据的获得
        /// <summary>
        /// OEM销售成绩表数据的获得
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetSalesProductInfo(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT BOH.SLIP_DATE,BMM.CREATE_DATE_TIME,BOH.SERIAL_NUMBER,BMM.MACHINE_NAME, ");
            strSql.Append("BOH.CHECK_NUMBER,BOH.CHECK_DATE,CC.NAME AS CUSTOMER_NAME,CC.ADDRESS_FIRST AS ADDRESS, ");
            strSql.Append("CE.NAME AS END_CUSTOMER_NAME FROM dbo.BLL_ORDER_HEADER BOH ");
            strSql.Append("LEFT JOIN dbo.BLL_ORDER_LINE BOL ON BOL.SLIP_NUMBER=BOH.SLIP_NUMBER ");
            strSql.Append("LEFT JOIN dbo.BASE_PRODUCT BP ON BOL.PRODUCT_CODE=BP.CODE ");
            strSql.Append("LEFT JOIN BASE_MASTER_MACHINE BMM ON BMM.MACHINE_CODE=BOH.SERIAL_NUMBER ");
            strSql.Append("LEFT JOIN dbo.BASE_CUSTOMER CE ON BOH.ENDER_CUSTOMER_CODE = CE.CODE ");
            strSql.Append("LEFT JOIN dbo.BASE_CUSTOMER CC ON BOH.CUSTOMER_CODE = CC.CODE  ");
            strSql.AppendFormat("WHERE {0} AND BP.MECHANICAL_DISTINCTION_FLAG={1} ", where, CConstant.MECHANICAL_BASE);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 应收账款管理表
        /// <summary>
        /// 获得机械本体应收账款
        /// </summary>
        public DataSet GetMachineAccountReceivable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM bll_report_sales_monthly_machine_view ");
            strSql.AppendFormat("WHERE {0}", where);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得机械部件应收账款
        /// </summary>
        public DataSet GetPartsAccountReceivable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM bll_report_sales_monthly_parts_view ");
            strSql.AppendFormat("WHERE {0}", where);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得己开票的收款金额
        /// </summary>
        public DataSet GetReceiptMatch(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT BS.SLIP_NUMBER,BRM.SLIP_DATE,BRM.OTHER_AMOUNT AS RECEIPT_AMOUNT ");
            strSql.Append(" FROM BLL_SALES AS BS  ");
            strSql.Append(" LEFT JOIN BLL_RECEIPT_MATCH AS BRM ON BS.SLIP_NUMBER = BRM.SALES_SLIP_NUMBER ");
            strSql.AppendFormat(" WHERE {0} AND BRM.SLIP_NUMBER IS NOT NULL AND BS.STATUS_FLAG <> {1} AND BRM.STATUS_FLAG <> {2} ", where, CConstant.DELETE, CConstant.DELETE);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion

        #region 进销存汇总表

        #region 数据的插入
        /// <summary>
        /// 采购信息的取得
        /// </summary>
        public DataSet GetPurchaseInfo(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  ");
            strSql.Append(" BRL.RECEIPT_WAREHOUSE_CODE, ");
            strSql.Append(" BRL.PRODUCT_CODE, ");
            strSql.Append(" BPL.CURRENCY_CODE, ");
            strSql.Append(" SUM(ISNULL(BRL.QUANTITY,0))  AS QUANTITY, ");
            strSql.Append(" SUM(ISNULL(BPL.INVOICE_AMOUNT,0)) AS INVOICE_AMOUNT, ");
            strSql.Append(" SUM(ISNULL(BPL.TAX_AMOUNT,0)) AS TAX_AMOUNT, ");
            strSql.Append(" SUM(ISNULL(BPL.PACKING_AMOUNT,0)) AS PACKING_AMOUNT ");
            strSql.Append(" FROM dbo.BLL_PURCHASE AS BP ");
            strSql.Append(" LEFT JOIN dbo.BLL_PURCHASE_LINE AS BPL ON BP.SLIP_NUMBER = BPL.SLIP_NUMBER ");
            strSql.Append(" LEFT JOIN dbo.BLL_RECEIPT_LINE AS BRL ON  BPL.RECEIPT_SLIP_NUMBER = BRL.SLIP_NUMBER AND BPL.RECEIPT_LINE_NUMBER = BRL.LINE_NUMBER ");
            strSql.Append(" LEFT JOIN dbo.BLL_RECEIPT AS BR ON BRL.SLIP_NUMBER  = BRL.SLIP_NUMBER ");
            strSql.Append(" WHERE BP.STATUS_FLAG <> {0} AND BR.STATUS_FLAG <> {1} ", CConstant.DELETE, CConstant.DELETE);
            strSql.AppendFormat(where);
            strSql.Append(" GROUP BY BRL.RECEIPT_WAREHOUSE_CODE,BRL.PRODUCT_CODE,BPL.CURRENCY_CODE ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 销售信息的取得
        /// </summary>
        public DataSet GetSalesInfo(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  ");
            strSql.Append(" SPL.DEPARTUAL_WAREHOUSE_CODE, ");
            strSql.Append(" SPL.PRODUCT_CODE, ");
            strSql.Append(" SUM(ISNULL(SPL.QUANTITY,0))  AS QUANTITY ");
            strSql.Append(" FROM dbo.BLL_SALES AS BS ");
            strSql.Append(" LEFT JOIN dbo.BLL_SALES_LINE AS BSL ON BS.SLIP_NUMBER = BSL.SLIP_NUMBER ");
            strSql.Append(" LEFT JOIN dbo.BLL_SHIPMENT AS SP ON SP.SLIP_NUMBER = BSL.SHIPMENT_SLIP_NUMBER ");
            strSql.Append(" LEFT JOIN dbo.BLL_SHIPMENT_LINE AS SPL ON SPL.SLIP_NUMBER = SP.SLIP_NUMBER ");
            strSql.Append(" WHERE BS.STATUS_FLAG <> {0} AND SP.STATUS_FLAG <> {1} ", CConstant.DELETE, CConstant.DELETE);
            strSql.AppendFormat(where);
            strSql.Append(" GROUP BY SPL.DEPARTUAL_WAREHOUSE_CODE,SPL.PRODUCT_CODE ");
            strSql.AppendFormat("WHERE {0}", where);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion


        #region 报表数据的查询


        #endregion
        #endregion

    }//end class
}
