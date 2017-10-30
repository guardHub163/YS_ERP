using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Common;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;

namespace CZZD.ERP.SQLServerDAL
{
    public class CompositionProductsSpecificationManage : ICompositionProductsSpecification
    {
        public CompositionProductsSpecificationManage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string COMPOSITION_PRODUCTS_CODE,string SPECIFICATION_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_COMPOSITION_PRODUCTS_SPECIFICATION");
			strSql.Append(" where COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE and SPECIFICATION_CODE=@SPECIFICATION_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@SPECIFICATION_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = COMPOSITION_PRODUCTS_CODE;
			parameters[1].Value = SPECIFICATION_CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CZZD.ERP.Model.BaseCompositionProductsSpecificationTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_COMPOSITION_PRODUCTS_SPECIFICATION(");
			strSql.Append("COMPOSITION_PRODUCTS_CODE,SPECIFICATION_CODE)");
			strSql.Append(" values (");
			strSql.Append("@COMPOSITION_PRODUCTS_CODE,@SPECIFICATION_CODE)");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@SPECIFICATION_CODE", SqlDbType.VarChar,20)};
			parameters[0].Value = model.COMPOSITION_PRODUCTS_CODE;
			parameters[1].Value = model.SPECIFICATION_CODE;

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
		/// 更新一条数据
		/// </summary>
        public bool Update(CZZD.ERP.Model.BaseCompositionProductsSpecificationTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_COMPOSITION_PRODUCTS_SPECIFICATION set ");
			strSql.Append("COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE,");
			strSql.Append("SPECIFICATION_CODE=@SPECIFICATION_CODE");
			strSql.Append(" where COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE and SPECIFICATION_CODE=@SPECIFICATION_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@SPECIFICATION_CODE", SqlDbType.VarChar,20)};
			parameters[0].Value = model.COMPOSITION_PRODUCTS_CODE;
			parameters[1].Value = model.SPECIFICATION_CODE;

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
		public bool Delete(string COMPOSITION_PRODUCTS_CODE,string SPECIFICATION_CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from BASE_COMPOSITION_PRODUCTS_SPECIFICATION ");
			strSql.Append(" where COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE and SPECIFICATION_CODE=@SPECIFICATION_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@SPECIFICATION_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = COMPOSITION_PRODUCTS_CODE;
			parameters[1].Value = SPECIFICATION_CODE;

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
        public CZZD.ERP.Model.BaseCompositionProductsSpecificationTable GetModel(string COMPOSITION_PRODUCTS_CODE, string SPECIFICATION_CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 COMPOSITION_PRODUCTS_CODE,COMPOSITION_PRODUCTS_NAME,SPECIFICATION_CODE,SPECIFICATION_NAME from base_composition_products_specifition ");
			strSql.Append(" where COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE and SPECIFICATION_CODE=@SPECIFICATION_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@SPECIFICATION_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = COMPOSITION_PRODUCTS_CODE;
			parameters[1].Value = SPECIFICATION_CODE;

            CZZD.ERP.Model.BaseCompositionProductsSpecificationTable model = new CZZD.ERP.Model.BaseCompositionProductsSpecificationTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.COMPOSITION_PRODUCTS_CODE=ds.Tables[0].Rows[0]["COMPOSITION_PRODUCTS_CODE"].ToString();
                model.COMPOSITION_PRODUCTS_NAME = ds.Tables[0].Rows[0]["COMPOSITION_PRODUCTS_NAME"].ToString();
				model.SPECIFICATION_CODE=ds.Tables[0].Rows[0]["SPECIFICATION_CODE"].ToString();
                model.SPECIFICATION_NAME = ds.Tables[0].Rows[0]["SPECIFICATION_NAME"].ToString();
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
            strSql.Append(" FROM base_composition_products_specifition ");
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
            strSql.Append("select count(1) from base_composition_products_specifition");
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
                strSql.Append("order by T.COMPOSITION_PRODUCTS_CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_composition_products_specifition T");
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
