using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Common;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.Model;

namespace CZZD.ERP.SQLServerDAL
{
    public class CompositionProductsProductionProcessManage : ICompositionProductsProductionProcess
    {
        public CompositionProductsProductionProcessManage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string compositionProductsCode, string productionProcessCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_COMPOSITION_PRODUCTS_PRODUCTION_PROCESS");
			strSql.Append(" where COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE and PRODUCTION_PROCESS_CODE=@PRODUCTION_PROCESS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCTION_PROCESS_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = compositionProductsCode;
            parameters[1].Value = productionProcessCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CZZD.ERP.Model.BaseCompositionProductsProductionProcessTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BASE_COMPOSITION_PRODUCTS_PRODUCTION_PROCESS(");
            strSql.Append("COMPOSITION_PRODUCTS_CODE,PRODUCTION_PROCESS_CODE,PRODUCTION_SEQUENCE)");
			strSql.Append(" values (");
            strSql.Append("@COMPOSITION_PRODUCTS_CODE,@PRODUCTION_PROCESS_CODE,@PRODUCTION_SEQUENCE)");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCTION_PROCESS_CODE", SqlDbType.VarChar,20),
                         new SqlParameter("@PRODUCTION_SEQUENCE", SqlDbType.Int,9)
                                        };
			parameters[0].Value = model.COMPOSITION_PRODUCTS_CODE;
			parameters[1].Value = model.PRODUCTION_PROCESS_CODE;
            parameters[2].Value = model.ORDER;
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
        public bool Update(CZZD.ERP.Model.BaseCompositionProductsProductionProcessTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_COMPOSITION_PRODUCTS_PRODUCTION_PROCESS set ");
			strSql.Append("COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE,");
			strSql.Append("PRODUCTION_PROCESS_CODE=@PRODUCTION_PROCESS_CODE,");
            strSql.Append("PRODUCTION_SEQUENCE=@PRODUCTION_SEQUENCE");
            
			strSql.Append(" where COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE and PRODUCTION_PROCESS_CODE=@PRODUCTION_PROCESS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCTION_PROCESS_CODE", SqlDbType.VarChar,20),
                                        new SqlParameter("@PRODUCTION_SEQUENCE", SqlDbType.VarChar,20)};
			parameters[0].Value = model.COMPOSITION_PRODUCTS_CODE;
			parameters[1].Value = model.PRODUCTION_PROCESS_CODE;
            parameters[2].Value = model.ORDER;
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
        public bool Delete(string compositionProductsCode, string productionProcessCode)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from BASE_COMPOSITION_PRODUCTS_PRODUCTION_PROCESS ");
			strSql.Append(" where COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE and PRODUCTION_PROCESS_CODE=@PRODUCTION_PROCESS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCTION_PROCESS_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = compositionProductsCode;
            parameters[1].Value = productionProcessCode;

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
        public CZZD.ERP.Model.BaseCompositionProductsProductionProcessTable GetModel(string compositionProductsCode, string productionProcessCode)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 COMPOSITION_PRODUCTS_CODE,COMPOSITION_PRODUCTS_NAME,PRODUCTION_PROCESS_CODE,PRODUCTION_PROCESS_NAME,PRODUCTION_SEQUENCE from base_composition_products_production_process_view ");
			strSql.Append(" where COMPOSITION_PRODUCTS_CODE=@COMPOSITION_PRODUCTS_CODE and PRODUCTION_PROCESS_CODE=@PRODUCTION_PROCESS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@COMPOSITION_PRODUCTS_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCTION_PROCESS_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = compositionProductsCode;
            parameters[1].Value = productionProcessCode;

            BaseCompositionProductsProductionProcessTable model = new BaseCompositionProductsProductionProcessTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.COMPOSITION_PRODUCTS_CODE=ds.Tables[0].Rows[0]["COMPOSITION_PRODUCTS_CODE"].ToString();
                model.COMPOSITION_PRODUCTS_NAME = ds.Tables[0].Rows[0]["COMPOSITION_PRODUCTS_NAME"].ToString();
				model.PRODUCTION_PROCESS_CODE=ds.Tables[0].Rows[0]["PRODUCTION_PROCESS_CODE"].ToString();
                model.PRODUCTION_PROCESS_NAME = ds.Tables[0].Rows[0]["PRODUCTION_PROCESS_NAME"].ToString();
                model.ORDER =ds.Tables[0].Rows[0]["PRODUCTION_SEQUENCE"].ToString();
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
            strSql.Append(" FROM base_composition_products_production_process_view ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append("order by PRODUCTION_SEQUENCE asc");
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from base_composition_products_production_process_view");
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
            strSql.Append(")AS Row, T.* from base_composition_products_production_process_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        public CZZD.ERP.Model.BaseCompositionProductsProductionProcessTable GetOrder(string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 COMPOSITION_PRODUCTS_CODE,COMPOSITION_PRODUCTS_NAME,PRODUCTION_PROCESS_CODE,PRODUCTION_PROCESS_NAME from base_composition_products_production_process_view ");
            strSql.Append(" where PRODUCTION_SEQUENCE=@PRODUCTION_SEQUENCE");
            SqlParameter[] parameters = {
					new SqlParameter("@PRODUCTION_SEQUENCE", SqlDbType.Int,9)};
            parameters[0].Value = order;       

            BaseCompositionProductsProductionProcessTable model = new BaseCompositionProductsProductionProcessTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.COMPOSITION_PRODUCTS_CODE = ds.Tables[0].Rows[0]["COMPOSITION_PRODUCTS_CODE"].ToString();
                model.COMPOSITION_PRODUCTS_NAME = ds.Tables[0].Rows[0]["COMPOSITION_PRODUCTS_NAME"].ToString();
                model.PRODUCTION_PROCESS_CODE = ds.Tables[0].Rows[0]["PRODUCTION_PROCESS_CODE"].ToString();
                model.PRODUCTION_PROCESS_NAME = ds.Tables[0].Rows[0]["PRODUCTION_PROCESS_NAME"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


		#endregion  Method
    }
}
