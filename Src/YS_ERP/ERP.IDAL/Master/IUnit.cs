using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface IUnit
    {
        bool Exists(string CODE);

        bool Add(CZZD.ERP.Model.BaseUnitTable model);

        bool Update(CZZD.ERP.Model.BaseUnitTable model);

        bool Delete(string CODE);

        CZZD.ERP.Model.BaseUnitTable GetModel(string CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
