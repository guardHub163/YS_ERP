using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data.SqlClient;
using System.Data;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class StockManage : IStock
    {
        #region  Method

        /// <summary>
        /// 取得当前公司的最大订单流水号
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public string GetMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(MAX(SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from BLL_HISTORY_STOCK");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WAREHOUSE_CODE, string PRODUCT_CODE)
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

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseStockTable stockTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_STOCK(");
            strSql.Append("WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
            strSql.Append(" values (");
            strSql.Append("@WAREHOUSE_CODE,@PRODUCT_CODE,@UNIT_CODE,@QUANTITY,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            parameters[0].Value = stockTable.WAREHOUSE_CODE;
            parameters[1].Value = stockTable.PRODUCT_CODE;
            parameters[2].Value = stockTable.UNIT_CODE;
            parameters[3].Value = stockTable.QUANTITY;
            parameters[4].Value = stockTable.STATUS_FLAG;
            parameters[5].Value = stockTable.CREATE_USER;
            parameters[6].Value = stockTable.LAST_UPDATE_USER;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseStockTable stockTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_STOCK set ");
            strSql.Append("UNIT_CODE=@UNIT_CODE,");
            strSql.Append("QUANTITY=QUANTITY-@QUANTITY,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            parameters[0].Value = stockTable.WAREHOUSE_CODE;
            parameters[1].Value = stockTable.PRODUCT_CODE;
            parameters[2].Value = stockTable.UNIT_CODE;
            parameters[3].Value = stockTable.QUANTITY;
            parameters[4].Value = stockTable.STATUS_FLAG;
            parameters[5].Value = stockTable.LAST_UPDATE_USER;

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

        public bool UpdateStock(BaseStockTable stockTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_STOCK set ");
            strSql.Append("UNIT_CODE=@UNIT_CODE,");
            strSql.Append("QUANTITY=@QUANTITY,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            parameters[0].Value = stockTable.WAREHOUSE_CODE;
            parameters[1].Value = stockTable.PRODUCT_CODE;
            parameters[2].Value = stockTable.UNIT_CODE;
            parameters[3].Value = stockTable.QUANTITY;
            parameters[4].Value = stockTable.STATUS_FLAG;
            parameters[5].Value = stockTable.LAST_UPDATE_USER;

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
        public BaseStockTable GetModel(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER from BASE_STOCK ");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

            BaseStockTable model = new BaseStockTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.WAREHOUSE_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                model.PRODUCT_CODE = ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
                model.UNIT_CODE = ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["QUANTITY"].ToString() != "")
                {
                    model.QUANTITY = decimal.Parse(ds.Tables[0].Rows[0]["QUANTITY"].ToString());
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
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// add history
        /// </summary>
        public int AddHistory(BllHistoryStockTable historyStockTable)
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
                    strSql.Append("insert into BLL_HISTORY_STOCK(");
                    strSql.Append("SLIP_NUMBER,SLIP_DATE,WAREHOUSE_CODE,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@WAREHOUSE_CODE,@COMPANY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                    SqlParameter[] stockParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                    stockParam[0].Value = historyStockTable.SLIP_NUMBER;
                    stockParam[1].Value = historyStockTable.SLIP_DATE;
                    stockParam[2].Value = historyStockTable.WAREHOUSE_CODE;
                    stockParam[3].Value = historyStockTable.COMPANY_CODE;
                    stockParam[4].Value = CConstant.INIT;
                    stockParam[5].Value = historyStockTable.CREATE_USER;
                    stockParam[6].Value = historyStockTable.LAST_UPDATE_USER;
                    listSql.Add(new CommandInfo(strSql.ToString(), stockParam));

                    foreach (BllHistoryStockLineTable lineModel in historyStockTable.Items)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_HISTORY_STOCK_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,REASON_CODE,STATUS_FLAG)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@REASON_CODE,@STATUS_FLAG)");
                        SqlParameter[] lineParam = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@REASON_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                        lineParam[0].Value = lineModel.SLIP_NUMBER;
                        lineParam[1].Value = lineModel.LINE_NUMBER;
                        lineParam[2].Value = lineModel.PRODUCT_CODE;
                        lineParam[3].Value = lineModel.QUANTITY;
                        lineParam[4].Value = lineModel.UNIT_CODE;
                        lineParam[5].Value = lineModel.REASON_CODE;
                        lineParam[6].Value = CConstant.INIT;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParam));

                        if (Existstock(historyStockTable.WAREHOUSE_CODE, lineModel.PRODUCT_CODE))
                        {
                            //库存更新
                            strSql = new StringBuilder();
                            strSql.Append("update BASE_STOCK set ");
                            strSql.Append("QUANTITY=QUANTITY + @QUANTITY,");
                            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");

                            SqlParameter[] sParam = {
                                new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                                new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                                new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                                new SqlParameter("@LAST_UPDATE_USER",  SqlDbType.VarChar,20)};
                            sParam[0].Value = historyStockTable.WAREHOUSE_CODE;
                            sParam[1].Value = lineModel.PRODUCT_CODE;
                            sParam[2].Value = lineModel.QUANTITY;
                            sParam[3].Value = historyStockTable.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), sParam));
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
                            stockParam2[0].Value = historyStockTable.WAREHOUSE_CODE;
                            stockParam2[1].Value = lineModel.PRODUCT_CODE;
                            stockParam2[2].Value = lineModel.UNIT_CODE;
                            stockParam2[3].Value = lineModel.QUANTITY;
                            stockParam2[4].Value = CConstant.INIT;
                            stockParam2[5].Value = historyStockTable.CREATE_USER;
                            stockParam2[6].Value = historyStockTable.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), stockParam2));
                        }
                    }
                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                }
                catch (SqlException ex)
                {
                    if (i != 9)
                    {
                        int maxLlipNumber = CConvert.ToInt32(GetMaxSlipNumber()) + 1;
                        historyStockTable.SLIP_NUMBER = maxLlipNumber.ToString().PadLeft(4, '0');
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


        /// <summary>
        /// 获得查询分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_stock_adjustment_search_view");
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
            strSql.Append(")AS Row, T.* from bll_stock_adjustment_search_view T");
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
            strSql.Append("SELECT SLIP_NUMBER, SLIP_DATE, LINE_NUMBER, PRODUCT_CODE,  PRODUCT_NAME, WAREHOUSE_CODE, WAREHOUSE_NAME, ");
            strSql.Append("UNIT_CODE, UNIT_NAME, QUANTITY, REASON_CODE, REASON, COMPANY_CODE, COMPANY_NAME, STATUS_FLAG, ");
            strSql.Append("CREATE_NAME, CREATE_DATE_TIME, LAST_UPDATE_NAME, LAST_UPDATE_TIME FROM bll_stock_adjustment_search_view ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #region 库存查询
        /// <summary>
        /// 获得查询分页数据总的记录条数
        /// </summary>
        public int GetStockRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_stock_search_view");
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
        public DataSet GetStockList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.WAREHOUSE_CODE asc");
            }
            strSql.Append(")AS Row, T.* from bll_stock_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据总的记录条数
        /// </summary>
        public int GetStockNotifyRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_stock_notify_search_view");
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
        #region 安全库存不足通知用
        /// <summary>
        /// 获得查询分页数据列表
        /// </summary>
        public DataSet GetStockNotifyList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.WAREHOUSE_CODE asc");
            }
            strSql.Append(")AS Row, T.* from bll_stock_notify_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        /// <summary>
        /// 库存导出
        /// </summary>
        public DataSet GetStockPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT WAREHOUSE_CODE, WAREHOUSE_NAME, PRODUCT_CODE, PRODUCT_NAME, SPEC, UNIT_CODE, UNIT_NAME, QUANTITY, ");
            strSql.Append("SAFETY_STOCK FROM bll_stock_search_view");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #region 入库预定数量的取得
        /// <summary>
        /// 入库预定数量的取得
        /// </summary>
        public decimal GetPurchaseQuantity(string warehouseCode, string productCode)
        {
            decimal purchaseQuantity = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ISNULL(SUM(RECEIPT_PLAN_QUANTITY),0) FROM BLL_RECEIPT_PLAN ");
            strSql.Append(" where RECEIPT_WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE = @PRODUCT_CODE");
            strSql.AppendFormat(" and STATUS_FLAG = {0} ", CConstant.INIT);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)
                    };
            parameters[0].Value = warehouseCode;
            parameters[1].Value = productCode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                purchaseQuantity = CConvert.ToDecimal(obj);
            }
            return purchaseQuantity;
        }
        #endregion

        #region 入库预定一览查询
        /// <summary>
        /// 入库预定一览
        /// </summary>
        public int GetReceiptRecordCount(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM bll_receiving_plan_view ");
            strSql.Append(" WHERE RECEIPT_WAREHOUSE_CODE= @WAREHOUSE_CODE and PRODUCT_CODE = @PRODUCT_CODE");
            strSql.AppendFormat(" and STATUS_FLAG = {0} ", CConstant.INIT);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        ///  入库预定一览查询
        /// </summary> 
        public DataSet GetReceiptList(string WAREHOUSE_CODE, string PRODUCT_CODE, int startIndex, int endIndex)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.DUE_DATE asc");
            strSql.Append(")AS Row, T.* from bll_receiving_plan_view T");
            strSql.Append(" WHERE RECEIPT_WAREHOUSE_CODE= @WAREHOUSE_CODE and PRODUCT_CODE = @PRODUCT_CODE");
            strSql.AppendFormat(" and STATUS_FLAG = {0} ", CConstant.INIT);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion


        #region 引当详细查询
        /// <summary>
        /// 引当详细查询
        /// </summary>
        public int GetAlloationRecordCount(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM bll_alloation_view ");
            strSql.Append(" WHERE WAREHOUSE_CODE = @WAREHOUSE_CODE AND PRODUCT_CODE = @PRODUCT_CODE  ");
            strSql.AppendFormat(" AND (ALLOATION_STATUS_FLAG = {0} OR ALLOATION_STATUS_FLAG={1} ) ", CConstant.ALLOATION_COMPLETE,CConstant.ALLOATION_PART);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 引当详细查询
        /// </summary>
        public DataSet GetAlloationList(string WAREHOUSE_CODE, string PRODUCT_CODE, int startIndex, int endIndex)
        { 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.DUE_DATE asc )AS Row, T.* from bll_alloation_view T ");
            strSql.Append(" WHERE WAREHOUSE_CODE = @WAREHOUSE_CODE AND PRODUCT_CODE = @PRODUCT_CODE  ");
            strSql.AppendFormat(" AND (ALLOATION_STATUS_FLAG = {0} OR ALLOATION_STATUS_FLAG={1} ) ", CConstant.ALLOATION_COMPLETE, CConstant.ALLOATION_PART);
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion
        #endregion

        #region 滞留品查询
        public int GetDelayRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ( ");
            strSql.Append("SELECT max(LAST_RECEIPT_DATE) AS LAST_RECEIPT_DATE, CODE, max(LAST_SHIPMENT_DATE) AS LAST_SHIPMENT_DATE,");
            strSql.Append(" NAME, SPEC, QUANTITY, UNIT_NAME from bll_delay_product_view T ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by CODE,NAME,SPEC,QUANTITY,UNIT_NAME,WAREHOUSE_CODE,GROUP_CODE");
            strSql.Append(" ) TT");

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

        public DataSet GetDelayList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.WAREHOUSE_CODE asc");
            }
            strSql.Append(")AS Row, max(LAST_RECEIPT_DATE) AS LAST_RECEIPT_DATE,CODE, ");
            strSql.Append("max(LAST_SHIPMENT_DATE) AS LAST_SHIPMENT_DATE, NAME, SPEC, QUANTITY, ");
            strSql.Append("UNIT_NAME from bll_delay_product_view T ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" group by CODE,NAME,SPEC,QUANTITY,UNIT_NAME,WAREHOUSE_CODE,GROUP_CODE");
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);

            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetDelayPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ( ");
            strSql.Append("SELECT CODE, NAME, SPEC, UNIT_CODE, UNIT_NAME, GROUP_CODE, GROUP_NAME, QUANTITY, WAREHOUSE_CODE, WAREHOUSE_NAME,");
            strSql.Append(" max(LAST_SHIPMENT_DATE) AS LAST_SHIPMENT_DATE, max(LAST_RECEIPT_DATE) AS LAST_RECEIPT_DATE,STATUS_FLAG, ");
            strSql.Append(" CREATE_NAME, CREATE_DATE_TIME,LAST_UPDATE_NAME, LAST_UPDATE_TIME FROM bll_delay_product_view T ");       
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by CODE, NAME, SPEC, UNIT_CODE, UNIT_NAME, GROUP_CODE, GROUP_NAME, QUANTITY, WAREHOUSE_CODE, WAREHOUSE_NAME, STATUS_FLAG, CREATE_NAME, CREATE_DATE_TIME,LAST_UPDATE_NAME, LAST_UPDATE_TIME");
            strSql.Append(" ) TT");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion 

        
        #endregion 
    }//end class
}
