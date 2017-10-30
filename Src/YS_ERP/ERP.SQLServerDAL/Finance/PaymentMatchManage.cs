using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using System.Data.SqlClient;

namespace CZZD.ERP.SQLServerDAL
{
    public class PaymentMatchManage : IPaymentMatch
    {
        #region 查询未付款数据
        public DataSet GetPaymentEntryDataList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM bll_payment_match_entry_view ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append("WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 最大收款编号取得
        /// <summary>
        /// 最大收款编号取得
        /// </summary>
        /// <returns></returns>
        private string GetPaymentMatchMaxSlipNumber(string companyCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select isnull(max(SLIP_NUMBER),0) from ( ");
            strSql.Append(" SELECT CASE len(SLIP_NUMBER) WHEN 0 THEN '0' WHEN 1 THEN '0' WHEN 2 THEN '0' WHEN 3 THEN '0' ELSE RIGHT(SLIP_NUMBER, 4) END AS SLIP_NUMBER");
            strSql.Append(" FROM dbo.BLL_PAYMENT_MATCH ");
            strSql.Append(" where COMPANY_CODE=@COMPANY_CODE ) T");
            SqlParameter[] parameters = {
                    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = companyCode;
            return  DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();            
        }
        #endregion

        #region 增加一条PAYMENT_MATCH数据
        public int AddpaymentMatch(BllPaymentMatchTable payment)
        {
            int maxSlipNumber = CConvert.ToInt32(GetPaymentMatchMaxSlipNumber(payment.COMPANY_CODE));
            payment.SLIP_NUMBER = payment.COMPANY_CODE + "-" + CConvert.ToString(++maxSlipNumber).PadLeft(4,'0');

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLL_PAYMENT_MATCH(");
            strSql.Append("SLIP_NUMBER,SLIP_DATE,PURCHASE_SLIP_NUMBER,TOTAL_AMOUNT,DEPOSIT_AMOUNT,OTHER_AMOUNT,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER, COMPANY_CODE)");
            strSql.Append(" values (");
            strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@PURCHASE_SLIP_NUMBER,@TOTAL_AMOUNT,@DEPOSIT_AMOUNT,@OTHER_AMOUNT,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER, @COMPANY_CODE)");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@PURCHASE_SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@TOTAL_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@DEPOSIT_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@OTHER_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = payment.SLIP_NUMBER;
            parameters[1].Value = payment.SLIP_DATE;
            parameters[2].Value = payment.PURCHASE_SLIP_NUMBER;
            parameters[3].Value = payment.TOTAL_AMOUNT;
            parameters[4].Value = payment.DEPOSIT_AMOUNT;
            parameters[5].Value = payment.OTHER_AMOUNT;
            parameters[6].Value = payment.STATUS_FLAG;
            parameters[7].Value = payment.CREATE_USER;
            parameters[8].Value = payment.LAST_UPDATE_USER;
            parameters[9].Value = payment.COMPANY_CODE;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion

        #region 付款查询
        public DataSet GetPaymentMatchSearchList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.SUPPLIER_NAME asc");
            }
            strSql.Append(")AS Row, T.* from bll_payment_match_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetPaymentMatchSearchRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_payment_match_search_view");
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

        #region  删除
        public bool DeletePayment(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_PAYMENT_MATCH  set STATUS_FLAG = {0}", CConstant.DELETE);
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
        
    }
}
