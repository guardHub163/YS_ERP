using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class UserManage : IUser
    {
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE, string COMPANY_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_USER");
            strSql.Append(" where CODE=@CODE and COMPANY_CODE=@COMPANY_CODE ");
            //strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE_STATUS);
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;
            parameters[1].Value = COMPANY_CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BaseUserTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.CODE, model.COMPANY_CODE))
            {
                strSql = new StringBuilder();
                strSql.Append("update BASE_USER set ");
                strSql.Append("PASSWORD=@PASSWORD,");
                strSql.Append("NAME=@NAME,");
                strSql.Append("PHONE=@PHONE,");
                strSql.Append("EMAIL=@EMAIL,");
                strSql.Append("DEPARTMENT_CODE=@DEPARTMENT_CODE,");
                strSql.Append("ROLES_CODE=@ROLES_CODE,");
                strSql.Append("PHOTO=@PHOTO,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(), ");
                strSql.Append("INT_COMMUNITY_DATE=@INT_COMMUNITY_DATE, ");
                strSql.Append("OUT_COMMUNITY_DATE=@OUT_COMMUNITY_DATE,");
                strSql.Append("LEVEL=@LEVEL");
                strSql.Append(" where CODE=@CODE and COMPANY_CODE=@COMPANY_CODE  ");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PASSWORD", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@PHONE", SqlDbType.VarChar,20),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,100),
					new SqlParameter("@DEPARTMENT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ROLES_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PHOTO", SqlDbType.Image,16),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@INT_COMMUNITY_DATE", SqlDbType.DateTime),
                    new SqlParameter("@OUT_COMMUNITY_DATE", SqlDbType.DateTime),
                    new SqlParameter("@LEVEL", SqlDbType.Int,8)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.PASSWORD;
                parameters[2].Value = model.NAME;
                parameters[3].Value = model.PHONE;
                parameters[4].Value = model.EMAIL;
                parameters[5].Value = model.DEPARTMENT_CODE;
                parameters[6].Value = model.COMPANY_CODE;
                parameters[7].Value = model.ROLES_CODE;
                parameters[8].Value = model.PHOTO;
                parameters[9].Value = CConstant.NORMAL;
                parameters[10].Value = model.LAST_UPDATE_USER;
                parameters[11].Value = model.INT_COMMUNITY_DATE;
                parameters[12].Value = model.OUT_COMMUNITY_DATE;
                parameters[13].Value = model.LEVEL;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            else
            {
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_USER(");
                strSql.Append("CODE,PASSWORD,NAME,PHONE,EMAIL,DEPARTMENT_CODE,COMPANY_CODE,ROLES_CODE,PHOTO,STATUS_FLAG,CREATE_USER,CREATE_DATE,LAST_UPDATE_USER,LAST_UPDATE_TIME,INT_COMMUNITY_DATE,OUT_COMMUNITY_DATE,LEVEL)");
                strSql.Append(" values (");
                strSql.Append("@CODE,@PASSWORD,@NAME,@PHONE,@EMAIL,@DEPARTMENT_CODE,@COMPANY_CODE,@ROLES_CODE,@PHOTO,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE(),@INT_COMMUNITY_DATE,@OUT_COMMUNITY_DATE,@LEVEL)");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PASSWORD", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@PHONE", SqlDbType.VarChar,20),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,100),
					new SqlParameter("@DEPARTMENT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ROLES_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PHOTO", SqlDbType.Image,16),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@INT_COMMUNITY_DATE", SqlDbType.DateTime),
                    new SqlParameter("@OUT_COMMUNITY_DATE", SqlDbType.DateTime),
                    new SqlParameter("@LEVEL", SqlDbType.Int,8)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.PASSWORD;
                parameters[2].Value = model.NAME;
                parameters[3].Value = model.PHONE;
                parameters[4].Value = model.EMAIL;
                parameters[5].Value = model.DEPARTMENT_CODE;
                parameters[6].Value = model.COMPANY_CODE;
                parameters[7].Value = model.ROLES_CODE;
                parameters[8].Value = model.PHOTO;
                parameters[9].Value = model.STATUS_FLAG;
                parameters[10].Value = model.CREATE_USER;
                parameters[11].Value = model.LAST_UPDATE_USER;
                parameters[12].Value = model.INT_COMMUNITY_DATE;
                parameters[13].Value = model.OUT_COMMUNITY_DATE;
                parameters[14].Value = model.LEVEL;
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
        public bool Update(BaseUserTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_USER set ");
            strSql.Append("PASSWORD=@PASSWORD,");
            strSql.Append("NAME=@NAME,");
            strSql.Append("PHONE=@PHONE,");
            strSql.Append("EMAIL=@EMAIL,");
            strSql.Append("DEPARTMENT_CODE=@DEPARTMENT_CODE,");
            //strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
            strSql.Append("ROLES_CODE=@ROLES_CODE,");
            strSql.Append("PHOTO=@PHOTO,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(), ");
            strSql.Append("INT_COMMUNITY_DATE=@INT_COMMUNITY_DATE, ");
            strSql.Append("OUT_COMMUNITY_DATE=@OUT_COMMUNITY_DATE,");
            strSql.Append("LEVEL=@LEVEL");
            strSql.Append(" where CODE=@CODE and COMPANY_CODE=@COMPANY_CODE  ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PASSWORD", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@PHONE", SqlDbType.VarChar,20),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,100),
					new SqlParameter("@DEPARTMENT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ROLES_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PHOTO", SqlDbType.Image,16),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@INT_COMMUNITY_DATE", SqlDbType.DateTime),
                    new SqlParameter("@OUT_COMMUNITY_DATE", SqlDbType.DateTime),
                    new SqlParameter("@LEVEL", SqlDbType.Int,4)};
            parameters[0].Value = model.CODE;
            parameters[1].Value = model.PASSWORD;
            parameters[2].Value = model.NAME;
            parameters[3].Value = model.PHONE;
            parameters[4].Value = model.EMAIL;
            parameters[5].Value = model.DEPARTMENT_CODE;
            parameters[6].Value = model.COMPANY_CODE;
            parameters[7].Value = model.ROLES_CODE;
            parameters[8].Value = model.PHOTO;
            parameters[9].Value = CConstant.NORMAL;
            parameters[10].Value = model.LAST_UPDATE_USER;
            parameters[11].Value = model.INT_COMMUNITY_DATE;
            parameters[12].Value = model.OUT_COMMUNITY_DATE;
            parameters[13].Value = model.LEVEL;
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
        public bool Delete(string CODE, string COMPANY_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_USER  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where CODE=@CODE and COMPANY_CODE=@COMPANY_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;
            parameters[1].Value = COMPANY_CODE;

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
        public BaseUserTable GetModel(string CODE, string COMPANY_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CODE,PASSWORD,NAME,PHONE,EMAIL,DEPARTMENT_CODE,COMPANY_CODE,ROLES_CODE,PHOTO,STATUS_FLAG,CREATE_USER,CREATE_DATE,LAST_UPDATE_USER,LAST_UPDATE_TIME,DEPARTMENT_NAME,COMPANY_NAME,ROLES_NAME,INT_COMMUNITY_DATE,OUT_COMMUNITY_DATE,LEVEL,DEFAULTINFO from base_user_view ");
            strSql.Append(" where CODE=@CODE and COMPANY_CODE=@COMPANY_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;
            parameters[1].Value = COMPANY_CODE;

            BaseUserTable model = new BaseUserTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CODE = ds.Tables[0].Rows[0]["CODE"].ToString();
                model.PASSWORD = ds.Tables[0].Rows[0]["PASSWORD"].ToString();
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.PHONE = ds.Tables[0].Rows[0]["PHONE"].ToString();
                model.EMAIL = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                model.DEPARTMENT_CODE = ds.Tables[0].Rows[0]["DEPARTMENT_CODE"].ToString();
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                model.ROLES_CODE = ds.Tables[0].Rows[0]["ROLES_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["INT_COMMUNITY_DATE"].ToString() != "")
                {
                    model.INT_COMMUNITY_DATE = CConvert.ToDateTime(ds.Tables[0].Rows[0]["INT_COMMUNITY_DATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OUT_COMMUNITY_DATE"].ToString() != "")
                {
                    model.OUT_COMMUNITY_DATE = CConvert.ToDateTime(ds.Tables[0].Rows[0]["OUT_COMMUNITY_DATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PHOTO"].ToString() != "")
                {
                    model.PHOTO = (byte[])ds.Tables[0].Rows[0]["PHOTO"];
                }
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUS_FLAG = CConvert.ToInt32(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE"].ToString() != "")
                {
                    model.CREATE_DATE = CConvert.ToDateTime(ds.Tables[0].Rows[0]["CREATE_DATE"].ToString());
                }
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = CConvert.ToDateTime(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                model.DEPARTMENT_NAME = ds.Tables[0].Rows[0]["DEPARTMENT_NAME"].ToString();
                model.COMPANY_NAME = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
                model.ROLES_NAME = ds.Tables[0].Rows[0]["ROLES_NAME"].ToString();
                model.LEVEL = CConvert.ToInt32(ds.Tables[0].Rows[0]["LEVEL"].ToString());
                if (ds.Tables[0].Rows[0]["DEFAULTINFO"].ToString() != "")
                {
                    model.INFO = ds.Tables[0].Rows[0]["DEFAULTINFO"].ToString();
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
            strSql.Append("select * ");
            strSql.Append(" FROM base_user_view ");
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
            strSql.Append("select count(1) from base_user_view");
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
            strSql.Append(")AS Row, T.* from base_user_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得公司编号
        /// </summary>
        public string GetCompany(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select code from BASE_COMPANY ");
            strSql.Append(" where NAME = @NAME ");
            SqlParameter[] parameters = {
					new SqlParameter("@NAME", SqlDbType.VarChar,50)};
            parameters[0].Value = name;
            string code = null;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                code = ds.Tables[0].Rows[0]["CODE"].ToString();
            }
            return code;
        }

        public bool UpdateDefault(BaseUserTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_USER set ");
            strSql.Append("DEFAULTINFO=@DEFAULTINFO");
            strSql.Append(" where CODE=@CODE");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@DEFAULTINFO", SqlDbType.VarChar,250),
				};
            parameters[0].Value = model.CODE;
            parameters[1].Value = model.INFO;

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

        #endregion  Method

    }//end class
}
