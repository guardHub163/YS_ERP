using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data.SqlClient;
using System.Data;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class SafetyStockManage:ISafetyStock
    {
        public SafetyStockManage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_SAFETY_STOCK");
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
        public bool Add(CZZD.ERP.Model.BaseSafetyStockTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.WAREHOUSE_CODE, model.PRODUCT_CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_SAFETY_STOCK set ");
                strSql.Append("UNIT_CODE=@UNIT_CODE,");
                strSql.Append("SAFETY_STOCK=@SAFETY_STOCK,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("MAX_QUANTITY=@MAX_QUANTITY,");
                strSql.Append("MIN_PURCHASE_QUANTITY=@MIN_PURCHASE_QUANTITY");
                strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@SAFETY_STOCK", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@MAX_QUANTITY", SqlDbType.Decimal,9),
                    new SqlParameter("@MIN_PURCHASE_QUANTITY", SqlDbType.Decimal,9)};
                parameters[0].Value = model.WAREHOUSE_CODE;
                parameters[1].Value = model.PRODUCT_CODE;
                parameters[2].Value = model.UNIT_CODE;
                parameters[3].Value = model.SAFETY_STOCK;
                parameters[4].Value = model.STATUS_FLAG;
                parameters[5].Value = model.CREATE_USER;
                parameters[6].Value = model.LAST_UPDATE_USER;
                parameters[7].Value = model.MAX_QUANTITY;
                parameters[8].Value = model.MIN_PURCHASE_QUANTITY;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_SAFETY_STOCK(");
                strSql.Append("WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,SAFETY_STOCK,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,MAX_QUANTITY,MIN_PURCHASE_QUANTITY)");
                strSql.Append(" values (");
                strSql.Append("@WAREHOUSE_CODE,@PRODUCT_CODE,@UNIT_CODE,@SAFETY_STOCK,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE(),@MAX_QUANTITY,@MIN_PURCHASE_QUANTITY)");
                SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@SAFETY_STOCK", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@MAX_QUANTITY", SqlDbType.Decimal,9),
                    new SqlParameter("@MIN_PURCHASE_QUANTITY", SqlDbType.Decimal,9)};
                parameters[0].Value = model.WAREHOUSE_CODE;
                parameters[1].Value = model.PRODUCT_CODE;
                parameters[2].Value = model.UNIT_CODE;
                parameters[3].Value = model.SAFETY_STOCK;
                parameters[4].Value = model.STATUS_FLAG;
                parameters[5].Value = model.CREATE_USER;
                parameters[6].Value = model.LAST_UPDATE_USER;
                parameters[7].Value = model.MAX_QUANTITY;
                parameters[8].Value = model.MIN_PURCHASE_QUANTITY;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
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
        /// 更新一条数据
        /// </summary>
        public bool Update(CZZD.ERP.Model.BaseSafetyStockTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_SAFETY_STOCK set ");
            strSql.Append("UNIT_CODE=@UNIT_CODE,");
            strSql.Append("SAFETY_STOCK=@SAFETY_STOCK,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");     
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("MAX_QUANTITY=@MAX_QUANTITY,");
            strSql.Append("MIN_PURCHASE_QUANTITY=@MIN_PURCHASE_QUANTITY");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@SAFETY_STOCK", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@MAX_QUANTITY", SqlDbType.Decimal,9),
                    new SqlParameter("@MIN_PURCHASE_QUANTITY", SqlDbType.Decimal,9)};
            parameters[0].Value = model.WAREHOUSE_CODE;
            parameters[1].Value = model.PRODUCT_CODE;
            parameters[2].Value = model.UNIT_CODE;
            parameters[3].Value = model.SAFETY_STOCK;
            parameters[4].Value = model.STATUS_FLAG;
            parameters[5].Value = model.LAST_UPDATE_USER;
            parameters[6].Value = model.MAX_QUANTITY;
            parameters[7].Value = model.MIN_PURCHASE_QUANTITY;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_SAFETY_STOCK  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

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
        public CZZD.ERP.Model.BaseSafetyStockTable GetModel(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,SAFETY_STOCK,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,WAREHOUSE_NAME,PRODUCT_NAME,UNIT_NAME,MAX_QUANTITY,MIN_PURCHASE_QUANTITY from base_safety_stock_view ");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

            CZZD.ERP.Model.BaseSafetyStockTable model = new CZZD.ERP.Model.BaseSafetyStockTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.WAREHOUSE_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                model.PRODUCT_CODE = ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
                model.UNIT_CODE = ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["SAFETY_STOCK"].ToString() != "")
                {
                    model.SAFETY_STOCK = decimal.Parse(ds.Tables[0].Rows[0]["SAFETY_STOCK"].ToString());
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
                model.WAREHOUSE_NAME = ds.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString();
                model.PRODUCT_NAME = ds.Tables[0].Rows[0]["PRODUCT_NAME"].ToString();
                model.UNIT_NAME = ds.Tables[0].Rows[0]["UNIT_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["MAX_QUANTITY"].ToString() != "")
                {
                    model.MAX_QUANTITY = CConvert.ToDecimal(ds.Tables[0].Rows[0]["MAX_QUANTITY"]);
                }
                if (ds.Tables[0].Rows[0]["MIN_PURCHASE_QUANTITY"].ToString() != "")
                {
                    model.MIN_PURCHASE_QUANTITY = CConvert.ToDecimal(ds.Tables[0].Rows[0]["MIN_PURCHASE_QUANTITY"]);
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
            strSql.Append("select WAREHOUSE_CODE,WAREHOUSE_NAME,PRODUCT_CODE,PRODUCT_NAME,UNIT_CODE,UNIT_NAME,SAFETY_STOCK,MAX_QUANTITY,MIN_PURCHASE_QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME ");
            strSql.Append(" FROM base_safety_stock_view ");
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
            strSql.Append("select count(1) from base_safety_stock_view");
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
                strSql.Append("order by T.PRODUCT_CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_safety_stock_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        
     
        #endregion  Method
    }
}
