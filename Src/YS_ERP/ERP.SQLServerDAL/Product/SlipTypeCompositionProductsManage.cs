using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.SQLServerDAL
{
    public class SlipTypeCompositionProductsManage : ISlipTypeCompositionProducts
    {
        public SlipTypeCompositionProductsManage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string slipTypeCode, string compositionProductsCode)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from BASE_SLIP_TYPE_COMPOSITION_PRODUCTS");
            strSql.Append(" where SLIP_TYPE_CODE=@SLIP_TYPE_CODE and COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@SLIP_TYPE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = slipTypeCode;
            parameters[1].Value = compositionProductsCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public void Add(BaseSlipTypeCompositionProductsTable model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into BASE_SLIP_TYPE_COMPOSITION_PRODUCTS(");
            strSql.Append("SLIP_TYPE_CODE,COMPOSITION_PRODUCTS_CODE,QUANTITY)");
			strSql.Append(" values (");
            strSql.Append("@SLIP_TYPE_CODE,@COMPOSITION_PRODUCTS_CODE,@QUANTITY)");
			SqlParameter[] parameters = {
					new SqlParameter("@SLIP_TYPE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@QUANTITY", SqlDbType.Int,9)};
			parameters[0].Value = model.SLIP_TYPE_CODE;
            parameters[1].Value = model.COMPOSITION_PRODUCTS_CODE;
            parameters[2].Value = model.QUANTITY;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(BaseSlipTypeCompositionProductsTable model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update BASE_SLIP_TYPE_COMPOSITION_PRODUCTS set ");
			strSql.Append("SLIP_TYPE_CODE=@SLIP_TYPE_CODE,");
            strSql.Append("COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE,");
            strSql.Append("QUANTITY=@QUANTITY");            
            strSql.Append(" where SLIP_TYPE_CODE=@SLIP_TYPE_CODE and COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@SLIP_TYPE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@QUANTITY", SqlDbType.Int,9)
                                        };
			parameters[0].Value = model.SLIP_TYPE_CODE;
            parameters[1].Value = model.COMPOSITION_PRODUCTS_CODE;
            parameters[2].Value = model.QUANTITY;
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
        public bool Delete(string slipTypeCode, string compositionProductsCode)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from BASE_SLIP_TYPE_COMPOSITION_PRODUCTS ");
            strSql.Append(" where SLIP_TYPE_CODE=@SLIP_TYPE_CODE and COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@SLIP_TYPE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = slipTypeCode;
            parameters[1].Value = compositionProductsCode;

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
        public BaseSlipTypeCompositionProductsTable GetModel(string slipTypeCode, string compositionProductsCode)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  *  from base_slip_type_composition_products_view ");
            strSql.Append(" where SLIP_TYPE_CODE=@SLIP_TYPE_CODE and COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE ");
			SqlParameter[] parameters = {					
					new SqlParameter("@SLIP_TYPE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = slipTypeCode;
			parameters[1].Value = compositionProductsCode;

            BaseSlipTypeCompositionProductsTable model = new BaseSlipTypeCompositionProductsTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.SLIP_TYPE_CODE=ds.Tables[0].Rows[0]["SLIP_TYPE_CODE"].ToString();
                model.COMPOSITION_PRODUCTS_CODE = ds.Tables[0].Rows[0]["COMPOSITION_PRODUCTS_CODE"].ToString();
                model.COMPOSITION_PRODUCTS_NAME = ds.Tables[0].Rows[0]["COMPOSITION_PRODUCTS_NAME"].ToString();
                model.SLIP_TYPE_NAME = ds.Tables[0].Rows[0]["SLIP_TYPE_NAME"].ToString();
                model.QUANTITY =int.Parse( ds.Tables[0].Rows[0]["QUANTITY"].ToString());
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
			strSql.Append("select * ");
            strSql.Append(" FROM base_slip_type_composition_products_view ");
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
            strSql.Append("select count(1) from base_slip_type_composition_products_view");
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
                strSql.Append("order by T.SLIP_TYPE_CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_slip_type_composition_products_view T");
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
