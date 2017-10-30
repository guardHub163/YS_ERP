using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface ISysCommon
    {
        #region 日志管理
        void AddLog(string time, string loginfo, string Particular);
        void DeleteLog(int ID);
        void DelOverdueLog(int days);
        void DeleteLog(string strWhere);
        System.Data.DataSet GetLogs(string strWhere);
        System.Data.DataRow GetLog(string ID);
        #endregion
    }
}
