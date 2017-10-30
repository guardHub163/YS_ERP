using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Common;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.IDAL;
using System.Data;

namespace CZZD.ERP.SQLServerDAL
{
    public class ProductGroupManage:IProductGroup 
    {
        public ProductGroupManage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_PRODUCT_GROUP");
			strSql.Append(" where CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CZZD.ERP.Model.BaseProductGroupTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_PRODUCT_GROUP set ");
                strSql.Append("NAME=@NAME,");
                strSql.Append("PARENT_CODE=@PARENT_CODE,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("INDICATES_ORDER=@INDICATES_ORDER,");
                strSql.Append("DISTINCTION=@DISTINCTION,");
                strSql.Append("BASIC_SUPPLIER=@BASIC_SUPPLIER,");
                strSql.Append("SECOND_SUPPLIER_CODE=@SECOND_SUPPLIER_CODE,");
                strSql.Append("THIRD_SUPPLIER_CODE=@THIRD_SUPPLIER_CODE");
                strSql.Append(" where CODE=@CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,255),
					new SqlParameter("@PARENT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
			        new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@INDICATES_ORDER", SqlDbType.Int,8),
                    new SqlParameter("@DISTINCTION", SqlDbType.Int,8),
                    new SqlParameter("@BASIC_SUPPLIER", SqlDbType.VarChar,20),
					new SqlParameter("@SECOND_SUPPLIER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@THIRD_SUPPLIER_CODE", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = model.PARENT_CODE;
                parameters[3].Value = CConstant.NORMAL;
                parameters[4].Value = model.CREATE_USER;
                parameters[5].Value = model.LAST_UPDATE_USER;
                parameters[6].Value = model.INDICATES_ORDER;
                parameters[7].Value = model.DISTINCTION;
                parameters[8].Value = model.BASIC_SUPPLIER;
                parameters[9].Value = model.SECOND_SUPPLIER_CODE;
                parameters[10].Value = model.THIRD_SUPPLIER_CODE;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_PRODUCT_GROUP(");
                strSql.Append("CODE,NAME,PARENT_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME, INDICATES_ORDER, DISTINCTION,BASIC_SUPPLIER,SECOND_SUPPLIER_CODE,THIRD_SUPPLIER_CODE)");
                strSql.Append(" values (");
                strSql.Append("@CODE,@NAME,@PARENT_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE(), @INDICATES_ORDER, @DISTINCTION,@BASIC_SUPPLIER,@SECOND_SUPPLIER_CODE,@THIRD_SUPPLIER_CODE)");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,255),
					new SqlParameter("@PARENT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@INDICATES_ORDER", SqlDbType.Int,8),
                    new SqlParameter("@DISTINCTION", SqlDbType.Int,8),
                    new SqlParameter("@BASIC_SUPPLIER", SqlDbType.VarChar,20),
					new SqlParameter("@SECOND_SUPPLIER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@THIRD_SUPPLIER_CODE", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = model.PARENT_CODE;
                parameters[3].Value = CConstant.NORMAL;
                parameters[4].Value = model.CREATE_USER;
                parameters[5].Value = model.LAST_UPDATE_USER;
                parameters[6].Value = model.INDICATES_ORDER;
                parameters[7].Value = model.DISTINCTION;
                parameters[8].Value = model.BASIC_SUPPLIER;
                parameters[9].Value = model.SECOND_SUPPLIER_CODE;
                parameters[10].Value = model.THIRD_SUPPLIER_CODE;
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
        public bool Update(CZZD.ERP.Model.BaseProductGroupTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_PRODUCT_GROUP set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("PARENT_CODE=@PARENT_CODE,");
			strSql.Append("STATUS_FLAG=@STATUS_FLAG,");			
			strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("INDICATES_ORDER=@INDICATES_ORDER,");
            strSql.Append("DISTINCTION=@DISTINCTION, ");
            strSql.Append("BASIC_SUPPLIER=@BASIC_SUPPLIER,");
            strSql.Append("SECOND_SUPPLIER_CODE=@SECOND_SUPPLIER_CODE,");
            strSql.Append("THIRD_SUPPLIER_CODE=@THIRD_SUPPLIER_CODE");
			strSql.Append(" where CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,255),
					new SqlParameter("@PARENT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),					
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@INDICATES_ORDER", SqlDbType.Int,8),
                    new SqlParameter("@DISTINCTION", SqlDbType.Int,8),
                    new SqlParameter("@BASIC_SUPPLIER", SqlDbType.VarChar,20),
					new SqlParameter("@SECOND_SUPPLIER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@THIRD_SUPPLIER_CODE", SqlDbType.VarChar,20)};
			parameters[0].Value = model.CODE;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.PARENT_CODE;
            parameters[3].Value = CConstant.NORMAL;			
			parameters[4].Value = model.LAST_UPDATE_USER;
            parameters[5].Value = model.INDICATES_ORDER;
            parameters[6].Value = model.DISTINCTION;
            parameters[7].Value = model.BASIC_SUPPLIER;
            parameters[8].Value = model.SECOND_SUPPLIER_CODE;
            parameters[9].Value = model.THIRD_SUPPLIER_CODE;

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
		public bool Delete(string CODE)		
        {			
			StringBuilder strSql=new StringBuilder();			
            strSql.AppendFormat("update BASE_PRODUCT_GROUP  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = CODE;

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
        public CZZD.ERP.Model.BaseProductGroupTable GetModel(string CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 CODE,NAME,PARENT_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,PARENT_NAME,INDICATES_ORDER,DISTINCTION,BASIC_SUPPLIER,BASIC_SUPPLIER_NAME,SECOND_SUPPLIER_CODE,SECOND_SUPPLIER_NAME,THIRD_SUPPLIER_CODE,THIRD_SUPPLIER_NAME from base_group_view ");
			strSql.Append(" where CODE=@CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = CODE;

            CZZD.ERP.Model.BaseProductGroupTable model = new CZZD.ERP.Model.BaseProductGroupTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.CODE=ds.Tables[0].Rows[0]["CODE"].ToString();
				model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				model.PARENT_CODE=ds.Tables[0].Rows[0]["PARENT_CODE"].ToString();
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
                model.PARENT_NAME = ds.Tables[0].Rows[0]["PARENT_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["INDICATES_ORDER"].ToString() != "")
                {
                    model.INDICATES_ORDER = int.Parse(ds.Tables[0].Rows[0]["INDICATES_ORDER"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DISTINCTION"].ToString() != "")
                {
                    model.DISTINCTION = int.Parse(ds.Tables[0].Rows[0]["DISTINCTION"].ToString());
                }
                model.BASIC_SUPPLIER = ds.Tables[0].Rows[0]["BASIC_SUPPLIER"].ToString();
                model.BASIC_SUPPLIER_NAME = ds.Tables[0].Rows[0]["BASIC_SUPPLIER_NAME"].ToString();
                model.SECOND_SUPPLIER_CODE = ds.Tables[0].Rows[0]["SECOND_SUPPLIER_CODE"].ToString();
                model.SECOND_SUPPLIER_NAME = ds.Tables[0].Rows[0]["SECOND_SUPPLIER_NAME"].ToString();
                model.THIRD_SUPPLIER_CODE = ds.Tables[0].Rows[0]["THIRD_SUPPLIER_CODE"].ToString();
                model.THIRD_SUPPLIER_NAME = ds.Tables[0].Rows[0]["THIRD_SUPPLIER_NAME"].ToString();
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
            strSql.Append(" FROM base_group_view ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        public DataSet GetList(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM base_group_view ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" ORDER BY " + orderby);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from base_group_view");
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
                strSql.Append("order by T.CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_group_view T");
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
