using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface IHsCode
    {
        bool Exists(string CODE);

        bool Add(CZZD.ERP.Model.BaseHsCodeTable model);

        bool Update(CZZD.ERP.Model.BaseHsCodeTable model);

        bool Delete(string HS_CODE);

        CZZD.ERP.Model.BaseHsCodeTable GetModel(string HS_CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
