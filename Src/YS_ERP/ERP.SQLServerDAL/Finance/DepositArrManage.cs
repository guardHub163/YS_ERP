using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using System.Data.SqlClient;
using System.Data;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class DepositArrManage : IDepositArr
    {
        #region  Method


        /// <summary>
        /// 获得当前的最大流水号
        /// </summary>
        public string GetMaxID()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select max(SLIP_NUMBER) FROM BLL_DEPOSIT_ARR ");
            object obj = DbHelperSQL.GetSingle(sb.ToString());
            return CConvert.ToString(obj);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllDepositArrTable depositArrTable)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into BLL_DEPOSIT_ARR(");
                    strSql.Append("SLIP_NUMBER,SLIP_DATE,CUSTOMER_CLAIM_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@CUSTOMER_CLAIM_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@COMPANY_CODE)");
                    SqlParameter[] parameters = {
					            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					            new SqlParameter("@CUSTOMER_CLAIM_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
                    parameters[0].Value = depositArrTable.SLIP_NUMBER;
                    parameters[1].Value = depositArrTable.SLIP_DATE;
                    parameters[2].Value = depositArrTable.CUSTOMER_CLAIM_CODE;
                    parameters[3].Value = depositArrTable.STATUS_FLAG;
                    parameters[4].Value = depositArrTable.CREATE_USER;
                    parameters[5].Value = depositArrTable.LAST_UPDATE_USER;
                    parameters[6].Value = depositArrTable.COMPANY_CODE;

                    listSql.Add(new CommandInfo(strSql.ToString(), parameters));

                    foreach (BllDepositArrLineTable depositArrLineTable in depositArrTable.LineTable)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_DEPOSIT_ARR_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,ORDER_SLIP_NUMBER,ARR_AMOUNT,MEMO,STATUS_FLAG)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@ORDER_SLIP_NUMBER,@ARR_AMOUNT,@MEMO,@STATUS_FLAG)");
                        SqlParameter[] lineParam = {
					            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@ARR_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                        lineParam[0].Value = depositArrTable.SLIP_NUMBER;
                        lineParam[1].Value = depositArrLineTable.LINE_NUMBER;
                        lineParam[2].Value = depositArrLineTable.ORDER_SLIP_NUMBER;
                        lineParam[3].Value = depositArrLineTable.ARR_AMOUNT;
                        lineParam[4].Value = depositArrLineTable.MEMO;
                        lineParam[5].Value = depositArrLineTable.STATUS_FLAG;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParam));
                    }

                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                    break;
                }
                catch (Exception ex)
                {
                    i++;
                    if (i > 10)
                    {
                        throw ex;
                    }
                    depositArrTable.SLIP_NUMBER = CConvert.ToString(CConvert.ToInt32(GetMaxID()) + 1);
                }
            }

            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string slipNumber, string lineNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE BLL_DEPOSIT_ARR_LINE ");
            strSql.AppendFormat(" SET STATUS_FLAG = {0} ", CConstant.DELETE);
            strSql.Append(" WHERE SLIP_NUMBER=@SLIP_NUMBER  AND LINE_NUMBER=@LINE_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
                    new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4)
                                        };
            parameters[0].Value = slipNumber;
            parameters[1].Value = lineNumber;

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
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_deposit_arr_view");
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
            strSql.Append(")AS Row, T.* from bll_deposit_arr_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据订单编号获得己分配的金额
        /// </summary>
        public decimal GetArrAmount(string orderSlipNumber) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT isnull(sum(ARR_AMOUNT),0) as ARR_AMOUNT from BLL_DEPOSIT_ARR_LINE "); 
            strSql.AppendFormat(" WHERE STATUS_FLAG <> {0} ",CConstant.DELETE);
            strSql.Append(" AND ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = orderSlipNumber;

            return CConvert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }
        #endregion

    }//end class
}
