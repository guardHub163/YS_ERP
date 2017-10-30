using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class HsCodeManage : IHsCode
    {
        public HsCodeManage()
		{}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string HS_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_HS_CODE");
            strSql.Append(" where HS_CODE=@HS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = HS_CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CZZD.ERP.Model.BaseHsCodeTable model)
		{
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.HS_CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_HS_CODE set ");
                strSql.Append("HS_NAME=@HS_NAME,");
                strSql.Append("TAX_RATE=@TAX_RATE,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE()");
                strSql.Append(" where HS_CODE=@HS_CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@HS_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.HS_CODE;
                parameters[1].Value = model.HS_NAME;
                parameters[2].Value = model.TAX_RATE;
                parameters[3].Value = CConstant.NORMAL;
                parameters[4].Value = model.CREATE_USER;
                parameters[5].Value = model.LAST_UPDATE_USER;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion 
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_HS_CODE(");
                strSql.Append("HS_CODE,HS_NAME,TAX_RATE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@CODE,@NAME,@TAX_RATE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.HS_CODE;
                parameters[1].Value = model.HS_NAME;
                parameters[2].Value = model.TAX_RATE;
                parameters[3].Value = CConstant.NORMAL;
                parameters[4].Value = model.CREATE_USER;
                parameters[5].Value = model.LAST_UPDATE_USER;
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
		public bool Update(CZZD.ERP.Model.BaseHsCodeTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_HS_CODE set ");
			strSql.Append("HS_NAME=@HS_NAME,");
			strSql.Append("TAX_RATE=@TAX_RATE,");
			strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
			
			strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
            strSql.Append(" where HS_CODE=@HS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@HS_NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
			parameters[0].Value = model.HS_CODE;
			parameters[1].Value = model.HS_NAME;
			parameters[2].Value = model.TAX_RATE;
            parameters[3].Value = CConstant.NORMAL;
			parameters[4].Value = model.LAST_UPDATE_USER;	

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
		public bool Delete(string HS_CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("update BASE_HS_CODE  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where HS_CODE=@HS_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = HS_CODE;

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
		public CZZD.ERP.Model.BaseHsCodeTable GetModel(string HS_CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 HS_CODE,HS_NAME,TAX_RATE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME from BASE_HS_CODE ");
            strSql.Append(" where HS_CODE=@HS_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
			SqlParameter[] parameters = {
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = HS_CODE;

			CZZD.ERP.Model.BaseHsCodeTable model=new CZZD.ERP.Model.BaseHsCodeTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
                model.HS_CODE = ds.Tables[0].Rows[0]["HS_CODE"].ToString();
                model.HS_NAME = ds.Tables[0].Rows[0]["HS_NAME"].ToString();
				if(ds.Tables[0].Rows[0]["TAX_RATE"].ToString()!="")
				{
					model.TAX_RATE=decimal.Parse(ds.Tables[0].Rows[0]["TAX_RATE"].ToString());
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
            strSql.Append("select HS_CODE,HS_NAME,TAX_RATE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME ");
			strSql.Append(" FROM BASE_HS_CODE ");
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
            strSql.Append("select count(1) from BASE_HS_CODE");
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
                strSql.Append("order by T.HS_CODE asc");
            }
            strSql.Append(")AS Row, T.* from BASE_HS_CODE T");
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
