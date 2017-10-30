using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.DBUtility;

namespace CZZD.ERP.SQLServerDAL
{
    public class SysCommonManage : ISysCommon
    {
        #region 日志
        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="time"></param>
        /// <param name="loginfo"></param>
        public void AddLog(string time, string loginfo, string Particular)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_Log(");
            strSql.Append("datetime,loginfo,Particular)");
            strSql.Append(" values (");
            strSql.Append("'" + time + "',");
            strSql.Append("'" + loginfo + "',");
            strSql.Append("'" + Particular + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void DeleteLog(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Log ");
            strSql.Append(" where ID= " + ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public void DelOverdueLog(int days)
        {
            string str = " DATEDIFF(day,[datetime],getdate())>" + days;
            DeleteLog(str);
        }
        public void DeleteLog(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public DataSet GetLogs(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID DESC");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataRow GetLog(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Log ");
            strSql.Append(" where ID= " + ID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0];
        }
        #endregion
    }
}
