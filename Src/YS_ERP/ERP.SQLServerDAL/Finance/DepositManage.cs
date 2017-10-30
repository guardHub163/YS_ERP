using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using System.Data;
using System.Data.SqlClient;

namespace CZZD.ERP.SQLServerDAL
{
    public class DepositManage : IDeposit
    {
        #region 获得当前的最大流水号
        /// <summary>
        /// 获得当前的最大流水号
        /// </summary>
        public string GetMaxID()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select max(SLIP_NUMBER) FROM BLL_DEPOSIT ");
            object obj = DbHelperSQL.GetSingle(sb.ToString());
            return CConvert.ToString(obj);
        }
        #endregion

        #region  增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllDepositTable depositTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLL_DEPOSIT(");
            strSql.Append("SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,CUSTOMER_CLAIM_CODE,AMOUNT,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE)");
            strSql.Append(" values (");
            strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@SLIP_TYPE,@CUSTOMER_CLAIM_CODE,@AMOUNT,@MEMO,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@COMPANY_CODE)");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@SLIP_TYPE", SqlDbType.Int,4),
					new SqlParameter("@CUSTOMER_CLAIM_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = depositTable.SLIP_NUMBER;
            parameters[1].Value = depositTable.SLIP_DATE;
            parameters[2].Value = depositTable.SLIP_TYPE;
            parameters[3].Value = depositTable.CUSTOMER_CLAIM_CODE;
            parameters[4].Value = depositTable.AMOUNT;
            parameters[5].Value = depositTable.MEMO;
            parameters[6].Value = depositTable.STATUS_FLAG;
            parameters[7].Value = depositTable.CREATE_USER;
            parameters[8].Value = depositTable.LAST_UPDATE_USER;
            parameters[9].Value = depositTable.COMPANY_CODE;

            int i = 0;
            while (true)
            {
                try
                {
                    return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                }
                catch (Exception ex)
                {
                    i++;

                    if (i > 10)
                    {
                        throw ex;
                    }
                    parameters[0].Value = CConvert.ToInt32(GetMaxID()) + 1;

                }
            }
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string slipNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update BLL_DEPOSIT ");
            strSql.AppendFormat(" SET STATUS_FLAG ={0} ", CConstant.DELETE);
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = slipNumber;

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

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_deposit_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region 获得分页数据总的记录条数
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_deposit_view");
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
                strSql.Append("order by T.SLIP_NUMBER DESC");
            }
            strSql.Append(")AS Row, T.* from bll_deposit_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 获得前受金总支付，总分配，余额信息
        /// <summary>
        /// 获得前受金总支付，总分配，余额信息
        /// </summary>
        public DataSet GetTotalDeposit(string customerClaimCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM bll_deposit_amount_view");
            strSql.AppendFormat(" where CUSTOMER_CLAIM_CODE = '{0}'", customerClaimCode);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

    }//end class
}
