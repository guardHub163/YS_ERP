using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL.Product
{
    public interface IProductionSchedule
    {
        int GetRecordCount(string strWhere);
        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
        String GetMaxActualEndTime(string strWhere);
        DataSet GetProductionScheduleLine(string strwhere);
    }
}
