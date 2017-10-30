using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface ICompositionProducts
    {
        bool Exists(string code);

        bool Add(CZZD.ERP.Model.BaseCompositionProductsTable model);

        bool Update(CZZD.ERP.Model.BaseCompositionProductsTable model);

        bool Delete(string code);

        CZZD.ERP.Model.BaseCompositionProductsTable GetModel(string code);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
