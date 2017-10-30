using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Common;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using System.Data;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;

namespace CZZD.ERP.SQLServerDAL
{
    public class SlipTypeManage : ISlipType
    {
        public SlipTypeManage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_SLIP_TYPE");
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = { new SqlParameter("@CODE", SqlDbType.VarChar, 50) };
            parameters[0].Value = CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BaseSlipTypeTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_SLIP_TYPE set ");
                strSql.Append("NAME=@NAME,");
                strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE()");
                strSql.Append(" where CODE=@CODE ");
                SqlParameter[] parameters = {	
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = model.COMPANY_CODE;
                parameters[3].Value = CConstant.INIT;
                parameters[4].Value = model.CREATE_USER;
                parameters[5].Value = model.LAST_UPDATE_USER;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_SLIP_TYPE(");
                strSql.Append("CODE,NAME,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,ENGLISH_NAME,ATTRIBUTE1,ATTRIBUTE2,ATTRIBUTE3)");
                strSql.Append(" values (");
                strSql.Append("@CODE,@NAME,@COMPANY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE(),@ENGLISH_NAME,@ATTRIBUTE1,@ATTRIBUTE2,@ATTRIBUTE3)");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@ENGLISH_NAME", SqlDbType.VarChar,20),
                    new SqlParameter("@ATTRIBUTE1", SqlDbType.VarChar,20),
                    new SqlParameter("@ATTRIBUTE2", SqlDbType.VarChar,20),
                    new SqlParameter("@ATTRIBUTE3", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = model.COMPANY_CODE;
                parameters[3].Value = CConstant.INIT;
                parameters[4].Value = model.CREATE_USER;
                parameters[5].Value = model.LAST_UPDATE_USER;
                parameters[6].Value = model.ENGLISHNAME;
                parameters[7].Value = model.ATTRIBUTE1;
                parameters[8].Value = model.ATTRIBUTE2;
                parameters[9].Value = model.ATTRIBUTE3;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            if (rows > 0)
            {
                return true;
                CCacheData.SlipType = null;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseSlipTypeTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_SLIP_TYPE set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("ENGLISH_NAME=@ENGLISH_NAME");
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@ENGLISH_NAME", SqlDbType.VarChar,20)};
            parameters[0].Value = model.CODE;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.COMPANY_CODE;
            parameters[3].Value = model.STATUE_FLAG;
            parameters[4].Value = model.LAST_UPDATE_USER;
            parameters[5].Value = model.ENGLISHNAME;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                CCacheData.SlipType = null;
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
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_SLIP_TYPE  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] stParam = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            stParam[0].Value = CODE;
            listSql.Add(new CommandInfo(strSql.ToString(), stParam));

            strSql = new StringBuilder();
            strSql.Append("delete from BASE_SLIP_TYPE_COMPOSITION_PRODUCTS ");
            strSql.Append(" where SLIP_TYPE_CODE=@SLIP_TYPE_CODE ");
            SqlParameter[] scpParam = {
					new SqlParameter("@SLIP_TYPE_CODE", SqlDbType.VarChar,50)};
            scpParam[0].Value = CODE;
            listSql.Add(new CommandInfo(strSql.ToString(), scpParam));

            int rows = DbHelperSQL.ExecuteSqlTran(listSql);
            if (rows > 0)
            {
                CCacheData.SlipType = null;
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
        public BaseSlipTypeTable GetModel(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  *  from base_slip_type_view ");
            strSql.Append(" where CODE=@CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            BaseSlipTypeTable model = new BaseSlipTypeTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CODE = ds.Tables[0].Rows[0]["CODE"].ToString();
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUE_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                model.COMPANY_NAME = ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                model.CREATE_USER_NAME = ds.Tables[0].Rows[0]["CREATE_USER_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                model.LAST_UPDATE_USER_NAME = ds.Tables[0].Rows[0]["LAST_UPDATE_USER_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                model.ENGLISHNAME = ds.Tables[0].Rows[0]["ENGLISH_NAME"].ToString();
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
            strSql.Append("select * from base_slip_type_view ");
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
            strSql.Append("select count(1) from base_slip_type_view");
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
            strSql.Append(")AS Row, T.* from base_slip_type_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetProductTreeList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM base_product_tree_view ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
