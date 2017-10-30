using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface IMasterMachine
    {
        bool Exists(string CODE);

        bool Add(CZZD.ERP.Model.BaseMasterMachineTable model);

        bool Update(CZZD.ERP.Model.BaseMasterMachineTable model);

        bool Delete(string CODE);

        CZZD.ERP.Model.BaseMasterMachineTable GetModel(string CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
