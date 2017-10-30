using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL.Product;
using System.Data;
using CZZD.ERP.DBUtility;

namespace CZZD.ERP.SQLServerDAL
{
   public class  ProductionScheduleManage:IProductionSchedule
    {

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
                strSql.Append("order by T.SLIP_NUMBER DESC");
            }
            strSql.Append(")AS Row, T.* from bll_production_schedule_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_production_schedule_search_view");
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
        public String GetMaxActualEndTime(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MAX(ACTUAL_END_TIME) from BLL_PRODUCTION_SCHEDULE_PRODUCTION_PROCESS");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            String obj = DbHelperSQL.ExecuteSqlScalar(strSql.ToString());
            if (obj == "")
            {
                return "";
            }
            else
            {
                return Convert.ToString(obj);
            }
        }

        public DataSet GetProductionScheduleLine(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM bll_production_schedule_line_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
