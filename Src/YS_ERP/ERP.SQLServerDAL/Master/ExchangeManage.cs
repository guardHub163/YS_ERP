using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Common;
using System.Data;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;

namespace CZZD.ERP.SQLServerDAL
{
    public class ExchangeManage : IExchange
    {
        public ExchangeManage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(DateTime EXCHANGE_DATE, string FROM_CURRENCY_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_EXCHANGE");
            strSql.Append(" where EXCHANGE_DATE=@EXCHANGE_DATE and FROM_CURRENCY_CODE=@FROM_CURRENCY_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@EXCHANGE_DATE", SqlDbType.DateTime),
					new SqlParameter("@FROM_CURRENCY_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = EXCHANGE_DATE;
            parameters[1].Value = FROM_CURRENCY_CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CZZD.ERP.Model.BaseExchangeTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.EXCHANGE_DATE, model.FROM_CURRENCY_CODE))
            {
                strSql = new StringBuilder();
                strSql.Append("update BASE_EXCHANGE set ");
                strSql.Append("TO_CURRENCY_CODE=@TO_CURRENCY_CODE,");
                strSql.Append("EXCHANGE_RATE=@EXCHANGE_RATE,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE()");
                strSql.Append(" where EXCHANGE_DATE=@EXCHANGE_DATE and FROM_CURRENCY_CODE=@FROM_CURRENCY_CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@EXCHANGE_DATE", SqlDbType.DateTime),
					new SqlParameter("@FROM_CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@TO_CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@EXCHANGE_RATE", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.EXCHANGE_DATE;
                parameters[1].Value = model.FROM_CURRENCY_CODE;
                parameters[2].Value = model.TO_CURRENCY_CODE;
                parameters[3].Value = model.EXCHANGE_RATE;
                parameters[4].Value = CConstant.NORMAL;
                parameters[5].Value = model.CREATE_USER;
                parameters[6].Value = model.LAST_UPDATE_USER;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            else
            {
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_EXCHANGE(");
                strSql.Append("EXCHANGE_DATE,FROM_CURRENCY_CODE,TO_CURRENCY_CODE,EXCHANGE_RATE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@EXCHANGE_DATE,@FROM_CURRENCY_CODE,@TO_CURRENCY_CODE,@EXCHANGE_RATE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                SqlParameter[] parameters = {
					new SqlParameter("@EXCHANGE_DATE", SqlDbType.DateTime),
					new SqlParameter("@FROM_CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@TO_CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@EXCHANGE_RATE", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.EXCHANGE_DATE;
                parameters[1].Value = model.FROM_CURRENCY_CODE;
                parameters[2].Value = model.TO_CURRENCY_CODE;
                parameters[3].Value = model.EXCHANGE_RATE;
                parameters[4].Value = CConstant.NORMAL;
                parameters[5].Value = model.CREATE_USER;
                parameters[6].Value = model.LAST_UPDATE_USER;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            return rows;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(CZZD.ERP.Model.BaseExchangeTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_EXCHANGE set ");
            strSql.Append("TO_CURRENCY_CODE=@TO_CURRENCY_CODE,");
            strSql.Append("EXCHANGE_RATE=@EXCHANGE_RATE,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
            strSql.Append(" where EXCHANGE_DATE=@EXCHANGE_DATE and FROM_CURRENCY_CODE=@FROM_CURRENCY_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@EXCHANGE_DATE", SqlDbType.DateTime),
					new SqlParameter("@FROM_CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@TO_CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@EXCHANGE_RATE", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            parameters[0].Value = model.EXCHANGE_DATE;
            parameters[1].Value = model.FROM_CURRENCY_CODE;
            parameters[2].Value = model.TO_CURRENCY_CODE;
            parameters[3].Value = model.EXCHANGE_RATE;
            parameters[4].Value = CConstant.INIT;
            parameters[5].Value = model.LAST_UPDATE_USER;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(DateTime EXCHANGE_DATE, string FROM_CURRENCY_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_EXCHANGE  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where EXCHANGE_DATE=@EXCHANGE_DATE and FROM_CURRENCY_CODE=@FROM_CURRENCY_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@EXCHANGE_DATE", SqlDbType.DateTime),
					new SqlParameter("@FROM_CURRENCY_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = EXCHANGE_DATE;
            parameters[1].Value = FROM_CURRENCY_CODE;

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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CZZD.ERP.Model.BaseExchangeTable GetModel(DateTime EXCHANGE_DATE, string FROM_CURRENCY_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 EXCHANGE_DATE,FROM_CURRENCY_CODE,TO_CURRENCY_CODE,EXCHANGE_RATE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME from BASE_EXCHANGE ");
            strSql.Append(" where EXCHANGE_DATE=@EXCHANGE_DATE and FROM_CURRENCY_CODE=@FROM_CURRENCY_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@EXCHANGE_DATE", SqlDbType.DateTime),
					new SqlParameter("@FROM_CURRENCY_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = EXCHANGE_DATE;
            parameters[1].Value = FROM_CURRENCY_CODE;

            CZZD.ERP.Model.BaseExchangeTable model = new CZZD.ERP.Model.BaseExchangeTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["EXCHANGE_DATE"].ToString() != "")
                {
                    model.EXCHANGE_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["EXCHANGE_DATE"].ToString());
                }
                model.FROM_CURRENCY_CODE = ds.Tables[0].Rows[0]["FROM_CURRENCY_CODE"].ToString();
                model.TO_CURRENCY_CODE = ds.Tables[0].Rows[0]["TO_CURRENCY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["EXCHANGE_RATE"].ToString() != "")
                {
                    model.EXCHANGE_RATE = decimal.Parse(ds.Tables[0].Rows[0]["EXCHANGE_RATE"].ToString());
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
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EXCHANGE_DATE, FROM_CURRENCY_CODE, '' AS FROM_CURRENCY_NAME, EXCHANGE_RATE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME ");
            strSql.Append(" FROM BASE_EXCHANGE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_EXCHANGE");
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
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.EXCHANGE_DATE asc");
            }
            strSql.Append(")AS Row, T.* from BASE_EXCHANGE T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///<summary>
        ///根据时间获得汇率
        ///</summary>
        public DataSet GetExchangeFromTime(DateTime fromTime, string FromCurrencyCode, string ToCurrencyCode)
        {
            StringBuilder str = new StringBuilder();
            if (FromCurrencyCode != "" && ToCurrencyCode != "")
            {
                str.AppendFormat("SELECT TOP 1 * FROM BASE_EXCHANGE WHERE EXCHANGE_DATE='{0}'AND FROM_CURRENCY_CODE='{1}' AND TO_CURRENCY_CODE='{0}'", fromTime, FromCurrencyCode, ToCurrencyCode);
            }
            else
            {
                str.AppendFormat("SELECT TOP 1 * FROM BASE_EXCHANGE WHERE EXCHANGE_DATE='{0}'", fromTime);
            }
            return DbHelperSQL.Query(str.ToString());
        }
        #endregion  Method
    }
}
