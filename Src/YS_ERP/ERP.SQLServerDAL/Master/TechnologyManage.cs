using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model.Master;
using System.Data;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.CacheData;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class TechnologyManage : ITechnology
    {
        public TechnologyManage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_TECHNOLOGY");
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BaseTechnologyTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_TECHNOLOGY set ");
                strSql.Append("NAME=@NAME,");
                strSql.Append("DEPARTMENT_CODE=@DEPARTMENT_CODE,");
                strSql.Append("TECHNOLOGY_DRAWING1=@TECHNOLOGY_DRAWING1,");
                strSql.Append("TECHNOLOGY_DRAWING2=@TECHNOLOGY_DRAWING2,");
                strSql.Append("TECHNOLOGY_DRAWING3=@TECHNOLOGY_DRAWING3,");
                strSql.Append("PERIOD=@PERIOD,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE()");
                strSql.Append(" where CODE=@CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@NAME", SqlDbType.VarChar,20),
					new SqlParameter("@DEPARTMENT_CODE", SqlDbType.VarChar,100),
					new SqlParameter("@TECHNOLOGY_DRAWING1", SqlDbType.VarChar,50),
					new SqlParameter("@TECHNOLOGY_DRAWING2", SqlDbType.VarChar,50),
					new SqlParameter("@TECHNOLOGY_DRAWING3", SqlDbType.VarChar,8),
					new SqlParameter("@PERIOD", SqlDbType.Int,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.NAME;
                parameters[1].Value = model.DEPARTMENT_CODE;
                parameters[2].Value = model.TECHNOLOGY_DRAWING1;
                parameters[3].Value = model.TECHNOLOGY_DRAWING2;
                parameters[4].Value = model.TECHNOLOGY_DRAWING3;
                parameters[5].Value = model.PERIOD;
                parameters[6].Value = CConstant.NORMAL;
                parameters[7].Value = model.CREATE_USER;
                parameters[8].Value = model.LAST_UPDATE_USER;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_TECHNOLOGY(");
                strSql.Append("CODE,NAME,DEPARTMENT_CODE,TECHNOLOGY_DRAWING1,TECHNOLOGY_DRAWING2,TECHNOLOGY_DRAWING3,PERIOD,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@CODE,@NAME,@DEPARTMENT_CODE,@TECHNOLOGY_DRAWING1,@TECHNOLOGY_DRAWING2,@TECHNOLOGY_DRAWING3,@PERIOD,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@DEPARTMENT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@TECHNOLOGY_DRAWING1", SqlDbType.VarChar,50),
					new SqlParameter("@TECHNOLOGY_DRAWING2", SqlDbType.VarChar,8),
					new SqlParameter("@TECHNOLOGY_DRAWING3", SqlDbType.VarChar,100),
					new SqlParameter("@PERIOD", SqlDbType.Int,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,200),				
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,200)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = model.DEPARTMENT_CODE;
                parameters[3].Value = model.TECHNOLOGY_DRAWING1;
                parameters[4].Value = model.TECHNOLOGY_DRAWING2;
                parameters[5].Value = model.TECHNOLOGY_DRAWING3;
                parameters[6].Value = model.PERIOD;
                parameters[7].Value = CConstant.INIT;
                parameters[8].Value = model.CREATE_USER;
                parameters[9].Value = model.LAST_UPDATE_USER;
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
        public bool Update(BaseTechnologyTable model)
        {
            StringBuilder strSql = new StringBuilder();
            #region 更新
            strSql = new StringBuilder();
            strSql.Append("update BASE_TECHNOLOGY set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("DEPARTMENT_CODE=@DEPARTMENT_CODE,");
            strSql.Append("TECHNOLOGY_DRAWING1=@TECHNOLOGY_DRAWING1,");
            strSql.Append("TECHNOLOGY_DRAWING2=@TECHNOLOGY_DRAWING2,");
            strSql.Append("TECHNOLOGY_DRAWING3=@TECHNOLOGY_DRAWING3,");
            strSql.Append("PERIOD=@PERIOD,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("CREATE_USER=@CREATE_USER,");
            strSql.Append("CREATE_DATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
                    new SqlParameter("@CODE", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.VarChar,50),
					new SqlParameter("@DEPARTMENT_CODE", SqlDbType.VarChar,100),
					new SqlParameter("@TECHNOLOGY_DRAWING1", SqlDbType.VarChar,50),
					new SqlParameter("@TECHNOLOGY_DRAWING2", SqlDbType.VarChar,50),
					new SqlParameter("@TECHNOLOGY_DRAWING3", SqlDbType.VarChar,8),
					new SqlParameter("@PERIOD", SqlDbType.Int,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};

            parameters[0].Value = model.CODE;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.DEPARTMENT_CODE;
            parameters[3].Value = model.TECHNOLOGY_DRAWING1;
            parameters[4].Value = model.TECHNOLOGY_DRAWING2;
            parameters[5].Value = model.TECHNOLOGY_DRAWING3;
            parameters[6].Value = model.PERIOD;
            parameters[7].Value = CConstant.NORMAL;
            parameters[8].Value = model.CREATE_USER;
            parameters[9].Value = model.LAST_UPDATE_USER;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_TECHNOLOGY  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                CCacheData.Company = null;
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
        public BaseTechnologyTable GetModel(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from base_technology_view ");
            strSql.Append(" where CODE=@CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            BaseTechnologyTable model = new BaseTechnologyTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CODE = ds.Tables[0].Rows[0]["CODE"].ToString();
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.TECHNOLOGY_DRAWING1 = ds.Tables[0].Rows[0]["TECHNOLOGY_DRAWING1"].ToString();
                model.TECHNOLOGY_DRAWING2 = ds.Tables[0].Rows[0]["TECHNOLOGY_DRAWING2"].ToString();
                model.TECHNOLOGY_DRAWING3 = ds.Tables[0].Rows[0]["TECHNOLOGY_DRAWING3"].ToString();
                model.PERIOD = CConvert.ToInt32(ds.Tables[0].Rows[0]["PERIOD"].ToString());
                model.STATUS_FLAG = CConvert.ToInt32(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                model.LAST_UPDATE_TIME = CConvert.ToDateTime(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                model.DEPARTMENT_CODE = ds.Tables[0].Rows[0]["DEPARTMENT_CODE"].ToString();
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                model.CREATE_DATE_TIME = CConvert.ToDateTime(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                model.DEPARTMENT_NAME = ds.Tables[0].Rows[0]["DEPARTMENT_NAME"].ToString();
                model.TECHNOLOGY_DRAWINGNAME1 = ds.Tables[0].Rows[0]["DRAWING_NAME1"].ToString();
                model.TECHNOLOGY_DRAWINGNAME2 = ds.Tables[0].Rows[0]["DRAWING_NAME2"].ToString();
                model.TECHNOLOGY_DRAWINGNAME3 = ds.Tables[0].Rows[0]["DRAWING_NAME3"].ToString();
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
            strSql.Append("select *  ");
            strSql.Append(" FROM base_technology_view ");
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
            strSql.Append("select count(1) from base_technology_view");
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
            strSql.Append(")AS Row, T.* from base_technology_view T");
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
