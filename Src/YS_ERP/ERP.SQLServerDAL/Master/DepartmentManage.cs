using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using System.Data;
using CZZD.ERP.IDAL;

namespace CZZD.ERP.SQLServerDAL
{
    public class DepartmentManage:IDepartment
    {
        public DepartmentManage()
		{}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_DEPARTMENT");
			strSql.Append(" where CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(BaseDepartmentTable model)
		{
			StringBuilder strSql=new StringBuilder();
            int rows = 0;
            if (Exists(model.CODE))
            {
                strSql = new StringBuilder();
                strSql.Append("update BASE_DEPARTMENT set ");
                strSql.Append("NAME=@NAME,");
                strSql.Append("PARENT_CODE=@PARENT_CODE,");
                strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE()");
                strSql.Append(" where CODE=@CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@PARENT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = model.PARENT_CODE;
                parameters[3].Value = model.COMPANY_CODE;
                parameters[4].Value = CConstant.NORMAL;
                parameters[5].Value = model.CREATE_USER;
                parameters[6].Value = model.LAST_UPDATE_USER;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            else
            {
                strSql = new StringBuilder();
			    strSql.Append("insert into BASE_DEPARTMENT(");
			    strSql.Append("CODE,NAME,PARENT_CODE,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
			    strSql.Append(" values (");
                strSql.Append("@CODE,@NAME,@PARENT_CODE,@COMPANY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
			    SqlParameter[] parameters = {
					    new SqlParameter("@CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					    new SqlParameter("@PARENT_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
			    parameters[0].Value = model.CODE;
			    parameters[1].Value = model.NAME;
			    parameters[2].Value = model.PARENT_CODE;
			    parameters[3].Value = model.COMPANY_CODE;
                parameters[4].Value = CConstant.NORMAL;
			    parameters[5].Value = model.CREATE_USER;
			    parameters[6].Value = model.LAST_UPDATE_USER;
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
		public bool Update(BaseDepartmentTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_DEPARTMENT set ");
			strSql.Append("NAME=@NAME,");
			strSql.Append("PARENT_CODE=@PARENT_CODE,");
			strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
			strSql.Append("STATUS_FLAG=@STATUS_FLAG,");	
			strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
			strSql.Append(" where CODE=@CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@PARENT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
			parameters[0].Value = model.CODE;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.PARENT_CODE;
			parameters[3].Value = model.COMPANY_CODE;
            parameters[4].Value = CConstant.NORMAL;
			parameters[5].Value = model.LAST_UPDATE_USER;

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
            strSql.AppendFormat("update BASE_DEPARTMENT  set STATUS_FLAG = {0}", CConstant.DELETE);
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
		public BaseDepartmentTable GetModel(string CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 CODE,NAME,PARENT_CODE,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,PARENT_NAME,COMPANY_NAME from base_department_view ");
			strSql.Append(" where CODE=@CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
			SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = CODE;

            BaseDepartmentTable model = new BaseDepartmentTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.CODE=ds.Tables[0].Rows[0]["CODE"].ToString();
				model.NAME=ds.Tables[0].Rows[0]["NAME"].ToString();
				model.PARENT_CODE=ds.Tables[0].Rows[0]["PARENT_CODE"].ToString();
				model.COMPANY_CODE=ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
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
                model.COMPANY_NAME = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
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
			strSql.Append("select CODE,NAME,PARENT_CODE,PARENT_NAME,COMPANY_CODE,COMPANY_NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME ");
            strSql.Append(" FROM base_department_view ");
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
            strSql.Append("select count(1) from base_department_view");
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
            strSql.Append(")AS Row, T.* from base_department_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

    }
}
