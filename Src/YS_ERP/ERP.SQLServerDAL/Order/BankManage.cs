using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using System.Data.SqlClient;
using CZZD.ERP.Common;
using CZZD.ERP.Model.Master;

namespace CZZD.ERP.SQLServerDAL
{
    public class BankManage : IBank
    {

        public DataSet GetBank(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM BANK");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BANK");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BaseBankTable model)
        {
            StringBuilder strSql = new StringBuilder();
            int rows = 0;
            if (Exists(model.ID))
            {
                #region 更新
                strSql = new StringBuilder();

                #endregion
            }
            else
            {
                strSql = new StringBuilder();
                strSql.Append("insert into BANK(");
                strSql.Append("ID,COMPANY_CODE,BANK_NAME,FULL_NAME_EN,FULL_NAME_CN,DETAIL_EN,DETAIL_CN,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@ID,@COMPANY_CODE,@BANK_NAME,@FULL_NAME_EN,@FULL_NAME_CN,@DETAIL_EN,@DETAIL_CN,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.VarChar,250),
					    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,250),
					    new SqlParameter("@BANK_NAME", SqlDbType.VarChar,250),
					    new SqlParameter("@FULL_NAME_EN", SqlDbType.VarChar,250),
					    new SqlParameter("@FULL_NAME_CN", SqlDbType.VarChar,250),
					    new SqlParameter("@DETAIL_EN", SqlDbType.VarChar,250),
					    new SqlParameter("@DETAIL_CN", SqlDbType.VarChar,250),
                        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.ID;
                parameters[1].Value = model.COMPANY_CODE;
                parameters[2].Value = model.BANK_NAME;
                parameters[3].Value = model.FULL_NAME_EN;
                parameters[4].Value = model.FULL_NAME_CN;
                parameters[5].Value = model.DETAIL_EN;
                parameters[6].Value = model.DETAIL_CN;
                parameters[7].Value = CConstant.INIT;
                parameters[8].Value = model.CREATE_USER;
                parameters[9].Value = model.LAST_UPDATE_USER;
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
        public bool Update(BaseBankTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BANK set ");
            strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
            strSql.Append("BANK_NAME=@BANK_NAME,");
            strSql.Append("FULL_NAME_EN=@FULL_NAME_EN,");
            strSql.Append("FULL_NAME_CN=@FULL_NAME_CN,");
            strSql.Append("DETAIL_EN=@DETAIL_EN,");
            strSql.Append("DETAIL_CN=@DETAIL_CN,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,20),
                    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@BANK_NAME", SqlDbType.VarChar,100),
                    new SqlParameter("@FULL_NAME_EN", SqlDbType.VarChar,250),
                    new SqlParameter("@FULL_NAME_CN", SqlDbType.VarChar,250),
                    new SqlParameter("@DETAIL_EN", SqlDbType.VarChar,250),
                    new SqlParameter("@DETAIL_CN", SqlDbType.VarChar,250),                             
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.COMPANY_CODE;
            parameters[2].Value = model.BANK_NAME;
            parameters[3].Value = model.FULL_NAME_EN;
            parameters[4].Value = model.FULL_NAME_CN;
            parameters[5].Value = model.DETAIL_EN;
            parameters[6].Value = model.DETAIL_CN;
            parameters[7].Value = CConstant.NORMAL;
            parameters[8].Value = model.LAST_UPDATE_USER;
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
        public bool Delete(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BANK set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

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
        public BaseBankTable GetModel(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from base_bank_view ");
            strSql.Append(" where ID=@ID ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            BaseBankTable model = new BaseBankTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NAME"].ToString() != "")
                {
                    model.COMPANY_NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                }
                if (ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString() != "")
                {
                    model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BANK_NAME"].ToString() != "")
                {
                    model.BANK_NAME = ds.Tables[0].Rows[0]["BANK_NAME"].ToString();
                }
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CREATE_USER"].ToString() != "")
                {
                    model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString() != "")
                {
                    model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DETAIL_CN"].ToString() != "")
                {
                    model.DETAIL_CN = ds.Tables[0].Rows[0]["DETAIL_CN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DETAIL_EN"].ToString() != "")
                {
                    model.DETAIL_EN = ds.Tables[0].Rows[0]["DETAIL_EN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FULL_NAME_CN"].ToString() != "")
                {
                    model.FULL_NAME_CN = ds.Tables[0].Rows[0]["FULL_NAME_CN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FULL_NAME_EN"].ToString() != "")
                {
                    model.FULL_NAME_EN = ds.Tables[0].Rows[0]["FULL_NAME_EN"].ToString();
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
            strSql.Append(" FROM base_bank_view ");
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
            strSql.Append("select count(1) from base_bank_view");
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
                strSql.Append("order by T.ID asc");
            }
            strSql.Append(")AS Row, T.* from base_bank_view T");
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
