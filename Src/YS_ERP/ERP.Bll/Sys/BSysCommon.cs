using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BSysCommon
    {
        ISysCommon dal = DALFactory.DataAccess.CreateSysCommonManage();

        #region 日志管理
        public void AddLog(string time, string loginfo, string Particular)
        {
            dal.AddLog(time, loginfo, Particular);
        }
        public void DelOverdueLog(int days)
        {
            dal.DelOverdueLog(days);
        }
        public void DeleteLog(string Idlist)
        {
            string str = "";
            if (Idlist.Trim() != "")
            {
                str = " ID in (" + Idlist + ")";
            }
            dal.DeleteLog(str);
        }
        public void DeleteLog(string timestart, string timeend)
        {
            string str = " datetime>'" + timestart + "' and datetime<'" + timeend + "'";
            dal.DeleteLog(str);
        }
        public DataSet GetLogs(string strWhere)
        {
            return dal.GetLogs(strWhere);
        }
        public DataRow GetLog(string ID)
        {
            return dal.GetLog(ID);
        }
        #endregion
    }
}
