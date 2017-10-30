using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface IDepartment
    {
        bool Exists(string CODE);

        bool Add(BaseDepartmentTable model);

        bool Update(BaseDepartmentTable model);

        bool Delete(string CODE);

        BaseDepartmentTable GetModel(string CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
