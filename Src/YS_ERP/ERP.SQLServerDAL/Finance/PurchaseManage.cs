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
    public class PurchaseManage : IPurchase
    {
        #region 查询未开票数据
        public DataSet GetPurchaseEntryDataList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM bll_purchase_entry_view ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append("where" + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 增加开票数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllPurchaseTable model)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = null;
            int maxSlipNumber = CConvert.ToInt32(GetPurchaseMaxSlipNumber(model.COMPANY_CODE));
            model.SLIP_NUMBER = model.COMPANY_CODE + "-" + model.SUPPLIER_CODE + "-" + CConvert.ToString(++maxSlipNumber).PadLeft(4, '0');
            strSql = new StringBuilder();

            strSql.Append("insert into BLL_PURCHASE(");
            strSql.Append("SLIP_NUMBER,SUPPLIER_CODE,INVOICE_NUMBER,INVOICE_NUMBER_LOCAL,SLIP_DATE,PAYMENT_DATE,INVOICE_AMOUNT,INVOICE_AMOUNT_LOCAL,PACKING_AMOUNT,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE)");
            strSql.Append(" values (");
            strSql.Append("@SLIP_NUMBER,@SUPPLIER_CODE,@INVOICE_NUMBER,@INVOICE_NUMBER_LOCAL,@SLIP_DATE,@PAYMENT_DATE,@INVOICE_AMOUNT,@INVOICE_AMOUNT_LOCAL,@PACKING_AMOUNT,@STATUS_FLAG,@CREATE_USER,@CREATE_DATE_TIME,@LAST_UPDATE_TIME,@LAST_UPDATE_USER,@COMPANY_CODE)");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@INVOICE_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@INVOICE_NUMBER_LOCAL", SqlDbType.VarChar,50),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@PAYMENT_DATE", SqlDbType.DateTime),
					new SqlParameter("@INVOICE_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@INVOICE_AMOUNT_LOCAL", SqlDbType.Decimal,9),
					new SqlParameter("@PACKING_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@CREATE_DATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@LAST_UPDATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = model.SLIP_NUMBER;
            parameters[1].Value = model.SUPPLIER_CODE;
            parameters[2].Value = model.INVOICE_NUMBER;
            parameters[3].Value = model.INVOICE_NUMBER_LOCAL;
            parameters[4].Value = model.SLIP_DATE;
            parameters[5].Value = model.PAYMENT_DATE;
            parameters[6].Value = model.INVOICE_AMOUNT;
            parameters[7].Value = model.INVOICE_AMOUNT_LOCAL;
            parameters[8].Value = model.PACKING_AMOUNT;
            parameters[9].Value = model.STATUS_FLAG;
            parameters[10].Value = model.CREATE_USER;
            parameters[11].Value = model.CREATE_DATE_TIME;
            parameters[12].Value = model.LAST_UPDATE_TIME;
            parameters[13].Value = model.LAST_UPDATE_USER;
            parameters[14].Value = model.COMPANY_CODE;

            listSql.Add(new CommandInfo(strSql.ToString(), parameters));

            //明细更新
            foreach (BllPurchaseLineTable purchaseLineTable in model.Items)
            {
                strSql = new StringBuilder();
                strSql.Append("insert into BLL_PURCHASE_LINE(");
                strSql.Append("SLIP_NUMBER,LINE_NUMBER,PURCHASE_ORDER_NUMBER,RECEIPT_SLIP_NUMBER,RECEIPT_LINE_NUMBER,INVOICE_AMOUNT,TAX_AMOUNT,PACKING_AMOUNT,CURRENCY_CODE,STATUS_FLAG)");
                strSql.Append(" values (");
                strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PURCHASE_ORDER_NUMBER,@RECEIPT_SLIP_NUMBER,@RECEIPT_LINE_NUMBER,@INVOICE_AMOUNT,@TAX_AMOUNT,@PACKING_AMOUNT,@CURRENCY_CODE,@STATUS_FLAG)");
                SqlParameter[] lineParameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@PURCHASE_ORDER_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@RECEIPT_SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@RECEIPT_LINE_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@INVOICE_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@PACKING_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                lineParameters[0].Value = model.SLIP_NUMBER;
                lineParameters[1].Value = purchaseLineTable.LINE_NUMBER;
                lineParameters[2].Value = purchaseLineTable.PURCHASE_ORDER_NUMBER;
                lineParameters[3].Value = purchaseLineTable.RECEIPT_SLIP_NUMBER;
                lineParameters[4].Value = purchaseLineTable.RECEIPT_LINE_NUMBER;
                lineParameters[5].Value = purchaseLineTable.INVOICE_AMOUNT;
                lineParameters[6].Value = purchaseLineTable.TAX_AMOUNT;
                lineParameters[7].Value = purchaseLineTable.PACKING_AMOUNT;
                lineParameters[8].Value = purchaseLineTable.CURRENCY_CODE;
                lineParameters[9].Value = purchaseLineTable.STATUS_FLAG;
                listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));

                //入库状态更新
                strSql = new StringBuilder();
                strSql.Append(" update BLL_RECEIPT set ");
                strSql.Append(" STATUS_FLAG=@STATUS_FLAG");
                strSql.Append(" where SLIP_NUMBER=@RECEIPT_SLIP_NUMBER");

                SqlParameter[] receiptParam = {					        
                            new SqlParameter("@RECEIPT_SLIP_NUMBER",  SqlDbType.VarChar,20),
                            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                receiptParam[0].Value = purchaseLineTable.RECEIPT_SLIP_NUMBER;
                receiptParam[1].Value = CConstant.NORMAL;
                listSql.Add(new CommandInfo(strSql.ToString(), receiptParam));
            }

            return DbHelperSQL.ExecuteSqlTran(listSql);
        }
        #endregion

        #region 最大销售编号取得
        /// <summary>
        /// 最大销售编号取得
        /// </summary>
        /// <returns></returns>
        private string GetPurchaseMaxSlipNumber(string companyCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select isnull(max(SLIP_NUMBER),0) from ( ");
            strSql.Append(" SELECT CASE len(SLIP_NUMBER) WHEN 0 THEN '0' WHEN 1 THEN '0' WHEN 2 THEN '0' WHEN 3 THEN '0' ELSE RIGHT(SLIP_NUMBER, 4) END AS SLIP_NUMBER");
            strSql.Append(" FROM dbo.BLL_PURCHASE ");
            strSql.Append(" where COMPANY_CODE=@COMPANY_CODE ) T");
            SqlParameter[] parameters = {
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = companyCode;
            return DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
        }
        #endregion

        #region 采购发票查询
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetPurchaseRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_purchase_search_view");
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
        public DataSet GetPurchaseList(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.* from bll_purchase_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #region 对象
        public BllPurchaseTable GetPurchaseModel(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,SUPPLIER_CODE,INVOICE_NUMBER,INVOICE_NUMBER_LOCAL,SLIP_DATE,PAYMENT_DATE,INVOICE_AMOUNT,INVOICE_AMOUNT_LOCAL,PACKING_AMOUNT,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE from BLL_PURCHASE ");
            strSql.Append(" where SLIP_NUMBER = @SLIP_NUMBER");
            SqlParameter[] parameters = {
                        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = SLIP_NUMBER;

            BllPurchaseTable model = new BllPurchaseTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                model.SUPPLIER_CODE = ds.Tables[0].Rows[0]["SUPPLIER_CODE"].ToString();
                model.INVOICE_NUMBER = ds.Tables[0].Rows[0]["INVOICE_NUMBER"].ToString();
                model.INVOICE_NUMBER_LOCAL = ds.Tables[0].Rows[0]["INVOICE_NUMBER_LOCAL"].ToString();
                if (ds.Tables[0].Rows[0]["SLIP_DATE"].ToString() != "")
                {
                    model.SLIP_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["SLIP_DATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PAYMENT_DATE"].ToString() != "")
                {
                    model.PAYMENT_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["PAYMENT_DATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["INVOICE_AMOUNT"].ToString() != "")
                {
                    model.INVOICE_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["INVOICE_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["INVOICE_AMOUNT_LOCAL"].ToString() != "")
                {
                    model.INVOICE_AMOUNT_LOCAL = decimal.Parse(ds.Tables[0].Rows[0]["INVOICE_AMOUNT_LOCAL"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PACKING_AMOUNT"].ToString() != "")
                {
                    model.PACKING_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["PACKING_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                strSql = new StringBuilder();
                strSql.Append("select * from BLL_PURCHASE_LINE ");
                strSql.Append(" where SLIP_NUMBER = @SLIP_NUMBER ");
                strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
                SqlParameter[] lineParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                lineParam[0].Value = SLIP_NUMBER;
                ds = DbHelperSQL.Query(strSql.ToString(), lineParam);
                BllPurchaseLineTable line = null;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    line = new BllPurchaseLineTable();
                    line.SLIP_NUMBER = CConvert.ToString(row["SLIP_NUMBER"]);
                    line.LINE_NUMBER = CConvert.ToInt32(row["LINE_NUMBER"]);
                    line.PURCHASE_ORDER_NUMBER = CConvert.ToString(row["PURCHASE_ORDER_NUMBER"]);
                    line.RECEIPT_SLIP_NUMBER = CConvert.ToString(row["RECEIPT_SLIP_NUMBER"]);
                    line.RECEIPT_LINE_NUMBER = CConvert.ToInt32(row["RECEIPT_LINE_NUMBER"]);
                    line.INVOICE_AMOUNT = CConvert.ToDecimal(row["INVOICE_AMOUNT"]);
                    line.TAX_AMOUNT = CConvert.ToDecimal(row["TAX_AMOUNT"]);
                    line.PACKING_AMOUNT = CConvert.ToDecimal(row["PACKING_AMOUNT"]);
                    line.CURRENCY_CODE = CConvert.ToString(row["CURRENCY_CODE"]);
                    line.STATUS_FLAG = CConvert.ToInt32(row["STATUS_FLAG"]);

                    if (!string.IsNullOrEmpty(line.SLIP_NUMBER))
                    {
                        model.AddItems(line);
                    }
                }

                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 取消
        public bool DeletePurchase(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_PURCHASE  set STATUS_FLAG = {0}", CConstant.DELETE);
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

        #region 未付款查询
        public int GetUnPaymentRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_un_payment_match_search_view");
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
        public DataSet GetUnPaymentList(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.* from bll_un_payment_match_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获得已开票金额
        public decimal GetGetInvoiceAmount(string RECEIPT_SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT INVOICE_AMOUNT from bll_purchase_invoice_amount_view ");
            strSql.Append(" WHERE  RECEIPT_SLIP_NUMBER = @RECEIPT_SLIP_NUMBER ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RECEIPT_SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = RECEIPT_SLIP_NUMBER;
            return CConvert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }
        #endregion

        public DataSet GetPurchaseList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM bll_purchase_search_view ");           
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" order bySLIP_NUMBER asc ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        public decimal GetTotalDeposit(string supplierCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT SUM(DEPOSIT_AMOUNT) FROM BLL_DEPOSIT_AMOUNT_VIEW");
            if (!string.IsNullOrEmpty(supplierCode))
            {
                strSql.AppendFormat(" where SUPPLIER_CODE = '{0}'", supplierCode);
            }
            return CConvert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        #endregion
    }
}
