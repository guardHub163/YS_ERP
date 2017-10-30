using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.Common;
using System.Data;

namespace CZZD.ERP.SQLServerDAL
{
    public class CustomerPriceManage:ICustomerPrice
    {
        public CustomerPriceManage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CUSTOMER_CODE, string PRODUCT_CODE, string UNIT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CUSTOMER_PRICE");
            strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CUSTOMER_CODE;
            parameters[1].Value = PRODUCT_CODE;
            parameters[2].Value = UNIT_CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CZZD.ERP.Model.BaseCustomerPriceTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.CUSTOMER_CODE, model.PRODUCT_CODE, model.UNIT_CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_CUSTOMER_PRICE set ");
                strSql.Append("PRICE=@PRICE,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE()");
                strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
			        new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CUSTOMER_CODE;
                parameters[1].Value = model.PRODUCT_CODE;
                parameters[2].Value = model.UNIT_CODE;
                parameters[3].Value = model.PRICE;
                parameters[4].Value = CConstant.NORMAL;
                parameters[5].Value = model.CREATE_USER;
                parameters[6].Value = model.LAST_UPDATE_USER;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_CUSTOMER_PRICE(");
                strSql.Append("CUSTOMER_CODE,PRODUCT_CODE,UNIT_CODE,PRICE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@CUSTOMER_CODE,@PRODUCT_CODE,@UNIT_CODE,@PRICE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),					
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CUSTOMER_CODE;
                parameters[1].Value = model.PRODUCT_CODE;
                parameters[2].Value = model.UNIT_CODE;
                parameters[3].Value = model.PRICE;
                parameters[4].Value = CConstant.NORMAL;
                parameters[5].Value = model.CREATE_USER;
                parameters[6].Value = model.LAST_UPDATE_USER;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
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
        public bool Update(CZZD.ERP.Model.BaseCustomerPriceTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CUSTOMER_PRICE set ");
            strSql.Append("PRICE=@PRICE,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");            
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
            strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),			
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            parameters[0].Value = model.CUSTOMER_CODE;
            parameters[1].Value = model.PRODUCT_CODE;
            parameters[2].Value = model.UNIT_CODE;
            parameters[3].Value = model.PRICE;
            parameters[4].Value = model.STATUS_FLAG;       
            parameters[5].Value = model.LAST_UPDATE_USER;
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
        public bool Delete(string CUSTOMER_CODE, string PRODUCT_CODE, string UNIT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_CUSTOMER_PRICE  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CUSTOMER_CODE;
            parameters[1].Value = PRODUCT_CODE;
            parameters[2].Value = UNIT_CODE;

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
        public CZZD.ERP.Model.BaseCustomerPriceTable GetModel(string CUSTOMER_CODE, string PRODUCT_CODE, string UNIT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CUSTOMER_CODE,PRODUCT_CODE,UNIT_CODE,UNIT_NAME,PRICE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,CUSTOMER_NAME,PRODUCT_NAME from base_customerprice_view ");
            strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CUSTOMER_CODE;
            parameters[1].Value = PRODUCT_CODE;
            parameters[2].Value = UNIT_CODE;

            CZZD.ERP.Model.BaseCustomerPriceTable model = new CZZD.ERP.Model.BaseCustomerPriceTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CUSTOMER_CODE = ds.Tables[0].Rows[0]["CUSTOMER_CODE"].ToString();
                model.PRODUCT_CODE = ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
                model.UNIT_CODE = ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["PRICE"].ToString() != "")
                {
                    model.PRICE = decimal.Parse(ds.Tables[0].Rows[0]["PRICE"].ToString());
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
                model.CUSTOMER_NAME = ds.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString();
                model.PRODUCT_NAME = ds.Tables[0].Rows[0]["PRODUCT_NAME"].ToString();
                model.UNIT_NAME = ds.Tables[0].Rows[0]["UNIT_NAME"].ToString();
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
            strSql.Append("select CUSTOMER_CODE,CUSTOMER_NAME,PRODUCT_CODE,PRODUCT_NAME,UNIT_CODE,UNIT_NAME,PRICE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME ");
            strSql.Append(" FROM base_customerprice_view ");
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
            strSql.Append("select count(1) from base_customerprice_view");
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
                strSql.Append("order by T.CUSTOMER_CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_customerprice_view T");
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
