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
    public class SupplierPriceManage:ISupplierPrice
    {
        public SupplierPriceManage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SUPPLIER_CODE,string PRODUCT_CODE,string UNIT_CODE,string CURRENCY_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_SUPPLIER_PRICE");
			strSql.Append(" where SUPPLIER_CODE=@SUPPLIER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE and CURRENCY_CODE=@CURRENCY_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.NChar,10)};
			parameters[0].Value = SUPPLIER_CODE;
			parameters[1].Value = PRODUCT_CODE;
			parameters[2].Value = UNIT_CODE;
			parameters[3].Value = CURRENCY_CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CZZD.ERP.Model.BaseSupplierPriceTable model)
		{
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.SUPPLIER_CODE, model.PRODUCT_CODE, model.UNIT_CODE, model.CURRENCY_CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_SUPPLIER_PRICE set ");
                strSql.Append("PRICE=@PRICE,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE()");
                strSql.Append(" where SUPPLIER_CODE=@SUPPLIER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE and CURRENCY_CODE=@CURRENCY_CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.NChar,10),
					new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
				    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.SUPPLIER_CODE;
                parameters[1].Value = model.PRODUCT_CODE;
                parameters[2].Value = model.UNIT_CODE;
                parameters[3].Value = model.CURRENCY_CODE;
                parameters[4].Value = model.PRICE;
                parameters[5].Value = CConstant.NORMAL;
                parameters[6].Value = model.CREATE_USER;
                parameters[7].Value = model.LAST_UPDATE_USER;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_SUPPLIER_PRICE(");
                strSql.Append("SUPPLIER_CODE,PRODUCT_CODE,UNIT_CODE,CURRENCY_CODE,PRICE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@SUPPLIER_CODE,@PRODUCT_CODE,@UNIT_CODE,@CURRENCY_CODE,@PRICE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                SqlParameter[] parameters = {
					new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.NChar,10),
					new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.SUPPLIER_CODE;
                parameters[1].Value = model.PRODUCT_CODE;
                parameters[2].Value = model.UNIT_CODE;
                parameters[3].Value = model.CURRENCY_CODE;
                parameters[4].Value = model.PRICE;
                parameters[5].Value = model.STATUS_FLAG;
                parameters[6].Value = model.CREATE_USER;
                parameters[7].Value = model.LAST_UPDATE_USER;

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
		public bool Update(CZZD.ERP.Model.BaseSupplierPriceTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_SUPPLIER_PRICE set ");
			strSql.Append("PRICE=@PRICE,");
			strSql.Append("STATUS_FLAG=@STATUS_FLAG,");			
			strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
			strSql.Append(" where SUPPLIER_CODE=@SUPPLIER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE and CURRENCY_CODE=@CURRENCY_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.NChar,10),
					new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),					
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
			parameters[0].Value = model.SUPPLIER_CODE;
			parameters[1].Value = model.PRODUCT_CODE;
			parameters[2].Value = model.UNIT_CODE;
			parameters[3].Value = model.CURRENCY_CODE;
			parameters[4].Value = model.PRICE;
            parameters[5].Value = CConstant.MODE_COPY;
			parameters[6].Value = model.LAST_UPDATE_USER;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string SUPPLIER_CODE,string PRODUCT_CODE,string UNIT_CODE,string CURRENCY_CODE)
		{			
			StringBuilder strSql=new StringBuilder();	
            strSql.AppendFormat("update BASE_SUPPLIER_PRICE  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where SUPPLIER_CODE=@SUPPLIER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE and CURRENCY_CODE=@CURRENCY_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.NChar,10)};
			parameters[0].Value = SUPPLIER_CODE;
			parameters[1].Value = PRODUCT_CODE;
			parameters[2].Value = UNIT_CODE;
			parameters[3].Value = CURRENCY_CODE;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public CZZD.ERP.Model.BaseSupplierPriceTable GetModel(string SUPPLIER_CODE,string PRODUCT_CODE,string UNIT_CODE,string CURRENCY_CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 SUPPLIER_CODE,PRODUCT_CODE,UNIT_CODE,CURRENCY_CODE,PRICE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,SUPPLIER_NAME,PRODUCT_NAME,UNIT_NAME,CURRENCY_NAME from base_supplier_price_view ");
			strSql.Append(" where SUPPLIER_CODE=@SUPPLIER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE and CURRENCY_CODE=@CURRENCY_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
			SqlParameter[] parameters = {
					new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.NChar,10)};
			parameters[0].Value = SUPPLIER_CODE;
			parameters[1].Value = PRODUCT_CODE;
			parameters[2].Value = UNIT_CODE;
			parameters[3].Value = CURRENCY_CODE;

            CZZD.ERP.Model.BaseSupplierPriceTable model = new CZZD.ERP.Model.BaseSupplierPriceTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.SUPPLIER_CODE=ds.Tables[0].Rows[0]["SUPPLIER_CODE"].ToString();
				model.PRODUCT_CODE=ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
				model.UNIT_CODE=ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
				model.CURRENCY_CODE=ds.Tables[0].Rows[0]["CURRENCY_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["PRICE"].ToString()!="")
				{
					model.PRICE=decimal.Parse(ds.Tables[0].Rows[0]["PRICE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString()!="")
				{
					model.STATUS_FLAG=int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
				}
				model.CREATE_USER=ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
				if(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString()!="")
				{
					model.CREATE_DATE_TIME=DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
				}
				model.LAST_UPDATE_USER=ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
				if(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString()!="")
				{
					model.LAST_UPDATE_TIME=DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
				}
                model.SUPPLIER_NAME = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                model.PRODUCT_NAME = ds.Tables[0].Rows[0]["PRODUCT_NAME"].ToString();
                model.UNIT_NAME = ds.Tables[0].Rows[0]["UNIT_NAME"].ToString();
                model.CURRENCY_NAME = ds.Tables[0].Rows[0]["CURRENCY_NAME"].ToString();

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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SUPPLIER_CODE,SUPPLIER_NAME,PRODUCT_CODE,PRODUCT_NAME,UNIT_CODE,UNIT_NAME,CURRENCY_CODE,CURRENCY_NAME,PRICE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME ");
            strSql.Append(" FROM base_supplier_price_view ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from base_supplier_price_view");
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
                strSql.Append("order by T.SUPPLIER_CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_supplier_price_view T");
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
