using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface ICustomer
    {
        bool Exists(string CODE);

        bool Add(CZZD.ERP.Model.BaseCustomerTable model);

        bool Update(CZZD.ERP.Model.BaseCustomerTable model);

        bool Delete(string CODE);

        CZZD.ERP.Model.BaseCustomerTable GetModel(string CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
