using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Common;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using System.Data.SqlClient;

namespace CZZD.ERP.SQLServerDAL
{
    public class SalesManage : ISales
    {

        #region 查询未开票数据
        public DataSet GetSalesEntryDataList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM bll_sales_entry_view ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 插入销售发票数据
        public int Add(BllSalesTable salesTable)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = null;
            //TODO:
            int maxSlipNumber = CConvert.ToInt32(GetSalesMaxSlipNumber(salesTable.COMPANY_CODE));
            salesTable.SLIP_NUMBER = salesTable.COMPANY_CODE + "-"+ CConvert.ToString(++maxSlipNumber).PadLeft(4, '0');
            strSql = new StringBuilder();

            strSql.Append("insert into BLL_SALES(");
            strSql.Append("SLIP_NUMBER,CUSTOMER_CLAIM_CODE,INVOICE_NUMBER,SLIP_DATE,CUSTOMER_CLAIM_DATE,INVOICE_AMOUNT,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE)");
            strSql.Append(" values (");
            strSql.Append("@SLIP_NUMBER,@CUSTOMER_CLAIM_CODE,@INVOICE_NUMBER,@SLIP_DATE,@CUSTOMER_CLAIM_DATE,@INVOICE_AMOUNT,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@COMPANY_CODE)");
            SqlParameter[] salesParam = {
					    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                        new SqlParameter("@CUSTOMER_CLAIM_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@INVOICE_NUMBER", SqlDbType.VarChar,50),
					    new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					    new SqlParameter("@CUSTOMER_CLAIM_DATE", SqlDbType.DateTime),
					    new SqlParameter("@INVOICE_AMOUNT", SqlDbType.Decimal,15),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                        new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
            salesParam[0].Value = salesTable.SLIP_NUMBER;
            salesParam[1].Value = salesTable.CUSTOMER_CLAIM_CODE;
            salesParam[2].Value = salesTable.INVOICE_NUMBER;
            salesParam[3].Value = salesTable.SLIP_DATE;
            salesParam[4].Value = salesTable.CUSTOMER_CLAIM_DATE;
            salesParam[5].Value = salesTable.INVOICE_AMOUNT;
            salesParam[6].Value = salesTable.STATUS_FLAG;
            salesParam[7].Value = salesTable.CREATE_USER;
            salesParam[8].Value = salesTable.LAST_UPDATE_USER;
            salesParam[9].Value = salesTable.COMPANY_CODE;
            listSql.Add(new CommandInfo(strSql.ToString(), salesParam));

            //明细更新
            foreach (BllSalesLineTable salesLineTable in salesTable.Items)
            {
                //明细的保存
                strSql = new StringBuilder();
                strSql.Append("insert into BLL_SALES_LINE(");
                strSql.Append("SLIP_NUMBER,LINE_NUMBER,ORDER_SLIP_NUMBER,SHIPMENT_SLIP_NUMBER,INVOICE_AMOUNT,CURRENCY_CODE,STATUS_FLAG)");
                strSql.Append(" values (");
                strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@ORDER_SLIP_NUMBER,@SHIPMENT_SLIP_NUMBER,@INVOICE_AMOUNT,@CURRENCY_CODE,@STATUS_FLAG)");
                SqlParameter[] salesLineParam = {
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
                    new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@SHIPMENT_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@INVOICE_AMOUNT", SqlDbType.Decimal,15),
                    new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                salesLineParam[0].Value = salesTable.SLIP_NUMBER;
                salesLineParam[1].Value = salesLineTable.LINE_NUMBER;
                salesLineParam[2].Value = salesLineTable.ORDER_SLIP_NUMBER;
                salesLineParam[3].Value = salesLineTable.SHIPMENT_SLIP_NUMBER;
                salesLineParam[4].Value = salesLineTable.INVOICE_AMOUNT;
                salesLineParam[5].Value = salesLineTable.CURRENCY_CODE;
                salesLineParam[6].Value = salesLineTable.STATUS_FLAG;
                listSql.Add(new CommandInfo(strSql.ToString(), salesLineParam));

                //出库状态更新
                strSql = new StringBuilder();
                strSql.Append(" update BLL_SHIPMENT set ");
                strSql.Append(" STATUS_FLAG=@STATUS_FLAG");
                strSql.Append(" where SLIP_NUMBER=@SHIPMENT_SLIP_NUMBER");

                SqlParameter[] shipmentParam = {					        
                            new SqlParameter("@SHIPMENT_SLIP_NUMBER",  SqlDbType.VarChar,20),
                            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                shipmentParam[0].Value = salesLineTable.SHIPMENT_SLIP_NUMBER;
                shipmentParam[1].Value = CConstant.NORMAL;
                listSql.Add(new CommandInfo(strSql.ToString(), shipmentParam));
            }

            return DbHelperSQL.ExecuteSqlTran(listSql);
        }
        #endregion

        #region 最大销售编号取得
        /// <summary>
        /// 最大销售编号取得
        /// </summary>
        /// <returns></returns>
        private string GetSalesMaxSlipNumber(string companyCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select isnull(max(SLIP_NUMBER),0) from  ");
            strSql.Append(" (SELECT CASE len(SLIP_NUMBER) WHEN 0 THEN '0' WHEN 1 THEN '0' WHEN 2 THEN '0' WHEN 3 THEN '0' ELSE RIGHT(SLIP_NUMBER, 4) END AS SLIP_NUMBER");
            strSql.Append(" FROM dbo.BLL_SALES ");
            strSql.Append(" where COMPANY_CODE=@COMPANY_CODE ) T");
            SqlParameter[] parameters = {
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = companyCode;
            string slipnumber = DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
            return slipnumber;
        }
        #endregion

        #region 分页查询已开票数据
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetSalesRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_sales_search_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetSalesList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.CUSTOMER_CLAIM_CODE asc");
            }
            strSql.Append(")AS Row, T.* from bll_sales_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 查询已开票未收款数据总数
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetUnReceiptRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_un_receipt_match_search_view ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion

        #region 查询已开票未收款数据
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetUnReceiptList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.SLIP_NUMBER asc");
            }
            strSql.Append(")AS Row, T.* from bll_un_receipt_match_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 查询未收款数据
        public DataSet GetReceiptEntryDataList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM bll_receipt_entry_view ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append("WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 增加一条收款数据
        /// <summary>
        /// 增加一条收款数据
        /// </summary>
        public int AddBllReceiptMatch(BllReceiptMatchTable model)
        {
            int maxSlipNumber = CConvert.ToInt32(GetReceiptMatchMaxSlipNumber(model.COMPANY_CODE));
            model.SLIP_NUMBER = model.COMPANY_CODE + "-" + CConvert.ToString(++maxSlipNumber).PadLeft(4, '0');

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLL_RECEIPT_MATCH(");
            strSql.Append("SLIP_NUMBER,SLIP_DATE,SALES_SLIP_NUMBER,SALES_LINE_NUMBER,TOTAL_AMOUNT,DEPOSIT_AMOUNT,OTHER_AMOUNT,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE)");
            strSql.Append(" values (");
            strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@SALES_SLIP_NUMBER,@SALES_LINE_NUMBER,@TOTAL_AMOUNT,@DEPOSIT_AMOUNT,@OTHER_AMOUNT,@STATUS_FLAG,@CREATE_USER,@CREATE_DATE_TIME,@LAST_UPDATE_TIME,@LAST_UPDATE_USER,@COMPANY_CODE)");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@SALES_SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SALES_LINE_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@TOTAL_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@DEPOSIT_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@OTHER_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@CREATE_DATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@LAST_UPDATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = model.SLIP_NUMBER;
            parameters[1].Value = model.SLIP_DATE;
            parameters[2].Value = model.SALES_SLIP_NUMBER;
            parameters[3].Value = model.SALES_LINE_NUMBER;
            parameters[4].Value = model.TOTAL_AMOUNT;
            parameters[5].Value = model.DEPOSIT_AMOUNT;
            parameters[6].Value = model.OTHER_AMOUNT;
            parameters[7].Value = model.STATUS_FLAG;
            parameters[8].Value = model.CREATE_USER;
            parameters[9].Value = model.CREATE_DATE_TIME;
            parameters[10].Value = model.LAST_UPDATE_TIME;
            parameters[11].Value = model.LAST_UPDATE_USER;
            parameters[12].Value = model.COMPANY_CODE;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 最大收款编号取得
        /// <summary>
        /// 最大收款编号取得
        /// </summary>
        /// <returns></returns>
        private string GetReceiptMatchMaxSlipNumber(string companyCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select isnull(max(SLIP_NUMBER),0) from ( ");
            strSql.Append(" SELECT CASE len(SLIP_NUMBER) WHEN 0 THEN '0' WHEN 1 THEN '0' WHEN 2 THEN '0' WHEN 3 THEN '0' ELSE RIGHT(SLIP_NUMBER, 4) END AS SLIP_NUMBER");
            strSql.Append(" FROM dbo.BLL_RECEIPT_MATCH ");
            strSql.Append(" where COMPANY_CODE=@COMPANY_CODE ) T");
            SqlParameter[] parameters = {
                    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = companyCode;
            string slipnumber = companyCode + DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
            return slipnumber;
        }
        #endregion

        #region 分页收款查询
        public DataSet GetReceiptMatchSearchList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.INVOICE_NUMBER asc");
            }
            strSql.Append(")AS Row, T.* from bll_receipt_match_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetReceiptMatchSearchRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_receipt_match_search_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion

        #region 删除
        public bool DeleteSales(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_SALES  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteReceiptMatch(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_RECEIPT_MATCH  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 获得SALES对象
        public BllSalesTable GetModel(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *from bll_sales_search_view ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);


            bool isFirst = true;
            BllSalesTable model = null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (isFirst)
                {
                    model = new BllSalesTable();
                    model.SLIP_NUMBER = dr["SLIP_NUMBER"].ToString();
                    model.CUSTOMER_CLAIM_CODE = dr["CUSTOMER_CLAIM_CODE"].ToString();
                    model.CUSTOMER_CLAIM_NAME = CConvert.ToString(dr["CUSTOMER_CLAIM_NAME"]);
                    model.INVOICE_NUMBER = dr["INVOICE_NUMBER"].ToString();
                    if (dr["SLIP_DATE"].ToString() != "")
                    {
                        model.SLIP_DATE = DateTime.Parse(dr["SLIP_DATE"].ToString());
                    }
                    if (dr["CUSTOMER_CLAIM_DATE"].ToString() != "")
                    {
                        model.CUSTOMER_CLAIM_DATE = DateTime.Parse(dr["CUSTOMER_CLAIM_DATE"].ToString());
                    }
                    if (dr["INVOICE_AMOUNT"].ToString() != "")
                    {
                        model.INVOICE_AMOUNT = decimal.Parse(dr["INVOICE_AMOUNT"].ToString());
                    }
                    if (dr["STATUS_FLAG"].ToString() != "")
                    {
                        model.STATUS_FLAG = int.Parse(dr["STATUS_FLAG"].ToString());
                    }
                    model.CREATE_USER = dr["CREATE_USER"].ToString();
                    if (dr["CREATE_DATE_TIME"].ToString() != "")
                    {
                        model.CREATE_DATE_TIME = DateTime.Parse(dr["CREATE_DATE_TIME"].ToString());
                    }
                    if (dr["LAST_UPDATE_TIME"].ToString() != "")
                    {
                        model.LAST_UPDATE_TIME = DateTime.Parse(dr["LAST_UPDATE_TIME"].ToString());
                    }
                    model.LAST_UPDATE_USER = dr["LAST_UPDATE_USER"].ToString();
                    model.COMPANY_CODE = dr["COMPANY_CODE"].ToString();
                    isFirst = false;
                }

                BllSalesLineTable line = new BllSalesLineTable();
                line.SLIP_NUMBER = CConvert.ToString(dr["SLIP_NUMBER"]);
                line.LINE_NUMBER = CConvert.ToInt32(dr["LINE_NUMBER"]);
                line.ORDER_SLIP_NUMBER = CConvert.ToString(dr["ORDER_SLIP_NUMBER"]);
                line.SHIPMENT_SLIP_NUMBER = CConvert.ToString(dr["SHIPMENT_SLIP_NUMBER"]);
                line.INVOICE_AMOUNT = CConvert.ToDecimal(dr["INVOICE_AMOUNT"]);
                line.CURRENCY_CODE = CConvert.ToString(dr["CURRENCY_CODE"]);
                line.CURRENCY_NAME = CConvert.ToString(dr["CURRENCY_NAME"]);
                line.STATUS_FLAG = CConvert.ToInt32(dr["LINE_STATUS_FLAG"]);
                line.ORDER_AMOUNT = CConvert.ToDecimal(dr["ORDER_AMOUNT"]);
                line.SERIAL_NUMBER = CConvert.ToString(dr["SERIAL_NUMBER"]);
                line.SHIPMENT_AMOUNT = CConvert.ToDecimal(dr["SHIPMENT_AMOUNT"]);
                
                model.AddItems(line);
            }

            return model;
        }

        #endregion

        #region 获得已开票的金额
        public decimal GetInvoiceAmount(string SHIPMENT_SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT INVOICE_AMOUNT from bll_sales_invoice_amount_view ");
            strSql.Append(" WHERE  SHIPMENT_SLIP_NUMBER = @SHIPMENT_SLIP_NUMBER ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SHIPMENT_SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = SHIPMENT_SLIP_NUMBER;
            return CConvert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }
        #endregion

        #region 获得预收款未开票余额
        /// <summary>
        /// 获得预收款未开票余额
        /// </summary>
        public decimal GetTotalDepositUnBilling(string customerClaimCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  SUM(ISNULL(BD.AMOUNT, 0) - ISNULL(BRM.DEPOSIT_AMOUNT, 0)) AS BALANCE ");
            strSql.Append(" FROM BLL_DEPOSIT AS BD LEFT OUTER JOIN ");
            strSql.Append(" BLL_SALES AS BS ON BD.CUSTOMER_CLAIM_CODE = BS.CUSTOMER_CLAIM_CODE LEFT OUTER JOIN ");
            strSql.Append(" BLL_RECEIPT_MATCH AS BRM ON BS.SLIP_NUMBER = BRM.SALES_SLIP_NUMBER ");
            strSql.AppendFormat(" WHERE (BD.STATUS_FLAG <> {0}) AND (BS.STATUS_FLAG <> {1} OR ", CConstant.DELETE, CConstant.DELETE);
            strSql.AppendFormat(" BS.STATUS_FLAG IS NULL) AND (BRM.STATUS_FLAG <> {0} OR ", CConstant.DELETE);
            strSql.Append(" BRM.STATUS_FLAG IS NULL) ");
            strSql.AppendFormat(" AND BD.CUSTOMER_CLAIM_CODE ='{0}'", customerClaimCode);
            strSql.Append(" GROUP BY BD.CUSTOMER_CLAIM_CODE ");

            return CConvert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        #endregion

    }//end class
}
