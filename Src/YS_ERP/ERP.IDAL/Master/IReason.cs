using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface IReason
    {
        bool Exists(string CODE);

        bool Add(CZZD.ERP.Model.BaseReasonTable model);

        bool Update(CZZD.ERP.Model.BaseReasonTable model);

        bool Delete(string CODE);

        CZZD.ERP.Model.BaseReasonTable GetModel(string CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
