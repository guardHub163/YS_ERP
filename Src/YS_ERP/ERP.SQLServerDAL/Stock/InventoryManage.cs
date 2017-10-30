using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Common;
using System.Data;
using System.Data.SqlClient;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Collections;

namespace CZZD.ERP.SQLServerDAL
{
    public class InventoryManage : IInventory
    {
        #region 盘点开始
        /// <summary>
        /// 取得当前的最大盘点单号
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public string GetMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(MAX(SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from BLL_INVENTORY");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }

        public DataSet GetStartList(string WAREHOUSE_CODE, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.PRODUCT_CODE asc");
            }
            strSql.Append(")AS Row, T.* from bll_inventory_start_view T");
            strSql.AppendFormat(" where WAREHOUSE_CODE =@WAREHOUSE_CODE and STATUS_FLAG <> {0}", CConstant.DELETE);

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = WAREHOUSE_CODE;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet GetStartPrintList(string WAREHOUSE_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT WAREHOUSE_CODE, WAREHOUSE_NAME, PRODUCT_CODE, PRODUCT_NAME, SPEC, ");
            strSql.Append("UNIT_CODE, UNIT_NAME, QUANTITY, QUANTITY AS TRUE_QUANTITY, STATUS_FLAG, ");
            strSql.Append("CREATE_USER, CREATE_DATE_TIME, LAST_UPDATE_USER, LAST_UPDATE_TIME FROM bll_inventory_start_view ");
            strSql.AppendFormat(" where WAREHOUSE_CODE =@WAREHOUSE_CODE and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = WAREHOUSE_CODE;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetStartRecordCount(string WAREHOUSE_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_inventory_start_view");
            strSql.AppendFormat(" where WAREHOUSE_CODE =@WAREHOUSE_CODE and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = WAREHOUSE_CODE;

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

        public int AddInventory(BllInventoryTable BIModel)
        {
            int result = 0;
            try
            {
                List<CommandInfo> listSql = new List<CommandInfo>();

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into BLL_INVENTORY(");
                strSql.Append("SLIP_NUMBER,WAREHOUSE_CODE,COMPANY_CODE,START_DATE,STATUE_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                strSql.Append(" values (");
                strSql.Append("@SLIP_NUMBER,@WAREHOUSE_CODE,@COMPANY_CODE,@START_DATE,@STATUE_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                SqlParameter[] inventoryParam = {
			            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
			            new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@START_DATE", SqlDbType.DateTime),
			            new SqlParameter("@STATUE_FLAG", SqlDbType.Int,4),
			            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
			            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                inventoryParam[0].Value = BIModel.SLIP_NUMBER;
                inventoryParam[1].Value = BIModel.WAREHOUSE_CODE;
                inventoryParam[2].Value = BIModel.COMPANY_CODE;
                inventoryParam[3].Value = BIModel.START_DATE;
                inventoryParam[4].Value = CConstant.INIT;
                inventoryParam[5].Value = BIModel.CREATE_USER;
                inventoryParam[6].Value = BIModel.LAST_UPDATE_USER;
                listSql.Add(new CommandInfo(strSql.ToString(), inventoryParam));
                
                foreach (BllInventoryLineTable BILModel in BIModel.Items)
                {
                    //明细的保存
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_INVENTORY_LINE(");
                    strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,WAREHOUSE_CODE,STOCK_QUANTITY,TRUE_QUANTITY,STATUS_FLAG,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@WAREHOUSE_CODE,@STOCK_QUANTITY,@TRUE_QUANTITY,@STATUS_FLAG,GETDATE(),@LAST_UPDATE_USER)");
                    SqlParameter[] BILParam = {
			                new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
			                new SqlParameter("@LINE_NUMBER", SqlDbType.VarChar,20),
			                new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
			                new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
			                new SqlParameter("@STOCK_QUANTITY", SqlDbType.Decimal,9),
			                new SqlParameter("@TRUE_QUANTITY", SqlDbType.Decimal,9),
			                new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
			                new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                    BILParam[0].Value = BILModel.SLIP_NUMBER;
                    BILParam[1].Value = BILModel.LINE_NUMBER;
                    BILParam[2].Value = BILModel.PRODUCT_CODE;
                    BILParam[3].Value = BILModel.WAREHOUSE_CODE;
                    BILParam[4].Value = BILModel.STOCK_QUANTITY;
                    BILParam[5].Value = BILModel.TRUE_QUANTITY;
                    BILParam[6].Value = CConstant.INIT;
                    BILParam[7].Value = BILModel.LAST_UPDATE_USER;
                    listSql.Add(new CommandInfo(strSql.ToString(), BILParam));
                }
                result = DbHelperSQL.ExecuteSqlTran(listSql);
            }
            catch (SqlException ex)
            { }
            return result;
        }

        #endregion

        #region 盘点查询
        public int GetSearchRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BLL_INVENTORY");
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

        public DataSet GetSearchList(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.* from BLL_INVENTORY T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public BllInventoryTable GetInventoryModel(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,WAREHOUSE_CODE,COMPANY_CODE,START_DATE,END_DATE,STATUE_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER from BLL_INVENTORY ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            CZZD.ERP.Model.BllInventoryTable model = new CZZD.ERP.Model.BllInventoryTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                model.WAREHOUSE_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["START_DATE"].ToString() != "")
                {
                    model.START_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["START_DATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["END_DATE"].ToString() != "")
                {
                    model.END_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["END_DATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUE_FLAG"].ToString() != "")
                {
                    model.STATUE_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUE_FLAG"].ToString());
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

        public DataSet GetLine(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from BLL_INVENTORY_LINE ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");

            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = SLIP_NUMBER;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        #endregion

        #region 盘点结束
        public int GetEndInventoryRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ");
            strSql.Append(" (select L.*, I.START_DATE from ");
            strSql.Append(" BLL_INVENTORY AS I ,BLL_INVENTORY_LINE AS L ");
            strSql.Append(" WHERE I.SLIP_NUMBER = L.SLIP_NUMBER) T");
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

        public DataSet GetEndInventoryList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.slip_number asc");
            }
            strSql.Append(")AS Row, T.* from (");
            strSql.Append(" select L.*, I.START_DATE from ");
            strSql.Append(" BLL_INVENTORY AS I ,BLL_INVENTORY_LINE AS L ");
            strSql.Append(" WHERE I.SLIP_NUMBER = L.SLIP_NUMBER) T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetEndPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM bll_inventory_search_print_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int UpdataInventory(string SLIP_NUMBER, Hashtable ht, string LAST_UPDATE_USER,bool isEnd)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql;
            if (isEnd)
            {
                strSql = new StringBuilder();
                strSql.Append("update BLL_INVENTORY set ");
                strSql.Append("END_DATE=GETDATE(),");
                strSql.Append("STATUE_FLAG=@STATUE_FLAG,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] EParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@STATUE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                EParam[0].Value = SLIP_NUMBER;
                EParam[1].Value = CConstant.ALREADY_INVENTORY;
                EParam[2].Value = LAST_UPDATE_USER;
                listSql.Add(new CommandInfo(strSql.ToString(), EParam));
            }
            else
            {
                strSql = new StringBuilder();
                strSql.Append("update BLL_INVENTORY set ");
                strSql.Append("STATUE_FLAG=@STATUE_FLAG,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] IParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@STATUE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                IParam[0].Value = SLIP_NUMBER;
                IParam[1].Value = CConstant.COMPLETE_INVENTORY;
                IParam[2].Value = LAST_UPDATE_USER;
                listSql.Add(new CommandInfo(strSql.ToString(), IParam));
            }

            foreach (DictionaryEntry de in ht)
            {
                strSql = new StringBuilder();
                strSql.Append("update BLL_INVENTORY_LINE set ");
                strSql.Append("TRUE_QUANTITY=@TRUE_QUANTITY,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER and PRODUCT_CODE=@PRODUCT_CODE ");
                SqlParameter[] ILParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@TRUE_QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                ILParam[0].Value = SLIP_NUMBER;
                ILParam[1].Value = de.Key;
                ILParam[2].Value = de.Value;
                ILParam[3].Value = LAST_UPDATE_USER;
                listSql.Add(new CommandInfo(strSql.ToString(), ILParam));
            }            
            return DbHelperSQL.ExecuteSqlTran(listSql);
        }

        #endregion
    }
}
