using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using System.Data.SqlClient;
using CZZD.ERP.Common;
using System.Data;

namespace CZZD.ERP.SQLServerDAL
{
    public class TransferManage:ITransfer
    {
        #region Method
        /// <summary>
        /// 取得当前公司的最大订单流水号
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public string GetMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(MAX(SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from BLL_TRANSFER_RECEIPT");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(BllTransferReceiptTable TRModel)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = null;

                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_TRANSFER_RECEIPT(");
                    strSql.Append("SLIP_NUMBER,DEPARTUAL_WAREHOUSE_CODE,ARRIVAL_WAREHOUSE_CODE,SLIP_DATE,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@DEPARTUAL_WAREHOUSE_CODE,@ARRIVAL_WAREHOUSE_CODE,@SLIP_DATE,@COMPANY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                    SqlParameter[] transferParam = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@DEPARTUAL_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@ARRIVAL_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					        new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					        new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                    transferParam[0].Value = TRModel.SLIP_NUMBER;
                    transferParam[1].Value = TRModel.DEPARTUAL_WAREHOUSE_CODE;
                    transferParam[2].Value = TRModel.ARRIVAL_WAREHOUSE_CODE;
                    transferParam[3].Value = TRModel.SLIP_DATE;
                    transferParam[4].Value = TRModel.COMPANY_CODE;
                    transferParam[5].Value = CConstant.INIT;
                    transferParam[6].Value = TRModel.CREATE_USER;
                    transferParam[7].Value = TRModel.LAST_UPDATE_USER;
                    listSql.Add(new CommandInfo(strSql.ToString(), transferParam));

                    foreach (BllTransferReceiptLineTable TRLModel in TRModel.Items)
                    {
                        //明细的保存
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_TRANSFER_RECEIPT_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@UNIT_CODE,@QUANTITY,@STATUS_FLAG)");
                        SqlParameter[] TRLParam = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                        TRLParam[0].Value = TRLModel.SLIP_NUMBER;
                        TRLParam[1].Value = TRLModel.LINE_NUMBER;
                        TRLParam[2].Value = TRLModel.PRODUCT_CODE;
                        TRLParam[3].Value = TRLModel.UNIT_CODE;
                        TRLParam[4].Value = TRLModel.QUANTITY;
                        TRLParam[5].Value = CConstant.INIT;
                        listSql.Add(new CommandInfo(strSql.ToString(), TRLParam));

                        //调入仓库里商品库存减少
                        strSql = new StringBuilder();
                        strSql.Append("update BASE_STOCK set ");
                        strSql.Append("QUANTITY=QUANTITY - @QUANTITY,");
                        strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                        strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                        strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
                        SqlParameter[] departualParam = {
					        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                        departualParam[0].Value = TRModel.DEPARTUAL_WAREHOUSE_CODE;
                        departualParam[1].Value = TRLModel.PRODUCT_CODE;
                        departualParam[2].Value = TRLModel.QUANTITY;
                        departualParam[3].Value = TRModel.LAST_UPDATE_USER;
                        listSql.Add(new CommandInfo(strSql.ToString(), departualParam));

                        if (Existstock(TRModel.ARRIVAL_WAREHOUSE_CODE, TRLModel.PRODUCT_CODE))
                        {
                            //库存更新
                            strSql = new StringBuilder();
                            strSql.Append("update BASE_STOCK set ");
                            strSql.Append("QUANTITY=QUANTITY + @QUANTITY,");
                            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");

                            SqlParameter[] stockParam = {
                                    new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                                    new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                                    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                                    new SqlParameter("@LAST_UPDATE_USER",  SqlDbType.VarChar,20)};
                            stockParam[0].Value = TRModel.ARRIVAL_WAREHOUSE_CODE;
                            stockParam[1].Value = TRLModel.PRODUCT_CODE;
                            stockParam[2].Value = TRLModel.QUANTITY;
                            stockParam[3].Value = TRModel.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), stockParam));
                        }
                        else
                        {
                            strSql = new StringBuilder();
                            strSql.Append("insert into BASE_STOCK(");
                            strSql.Append("WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                            strSql.Append(" values (");
                            strSql.Append("@WAREHOUSE_CODE,@PRODUCT_CODE,@UNIT_CODE,@QUANTITY,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                            SqlParameter[] stockParam2 = {
					        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					        new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                            stockParam2[0].Value = TRModel.ARRIVAL_WAREHOUSE_CODE;
                            stockParam2[1].Value = TRLModel.PRODUCT_CODE;
                            stockParam2[2].Value = TRLModel.UNIT_CODE;
                            stockParam2[3].Value = TRLModel.QUANTITY;
                            stockParam2[4].Value = CConstant.INIT;
                            stockParam2[5].Value = TRModel.CREATE_USER;
                            stockParam2[6].Value = TRModel.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), stockParam2));
                        }
                    }
                    return DbHelperSQL.ExecuteSqlTran(listSql);
                }
                catch (SqlException ex)
                {
                    if (i != 9)
                    {
                        int maxLlipNumber = CConvert.ToInt32(GetMaxSlipNumber()) + 1;
                        TRModel.SLIP_NUMBER = maxLlipNumber.ToString().PadLeft(4, '0');
                        i++;
                        continue;
                    }
                }
                break;
            }
            return result;
        }

        // <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Existstock(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_STOCK");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion

        #region 仓库调拨查询
        /// <summary>
        /// 获得查询分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_transfer_receipt_search_view");
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
        /// 获得查询分页数据列表
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
                strSql.Append("order by T.SLIP_NUMBER asc");
            }
            strSql.Append(")AS Row, T.* from bll_transfer_receipt_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SLIP_NUMBER, SLIP_DATE, LINE_NUMBER, PRODUCT_CODE, PRODUCT_NAME, DEPARTUAL_WAREHOUSE_CODE, DEPARTUAL_WAREHOUSE, ");
            strSql.Append("ARRIVAL_WAREHOUSE_CODE, ARRIVAL_WAREHOUSE, QUANTITY, UNIT_CODE, UNIT_NAME, COMPANY_CODE, COMPANY_NAME, STATUS_FLAG, "); 
            strSql.Append("CREATE_NAME, CREATE_DATE_TIME, LAST_UPDATE_NAME, LAST_UPDATE_TIME FROM bll_transfer_receipt_search_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
