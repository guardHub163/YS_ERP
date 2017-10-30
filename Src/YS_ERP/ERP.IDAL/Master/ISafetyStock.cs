using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface ISafetyStock
    {
        bool Exists(string WAREHOUSE_CODE, string PRODUCT_CODE);

        bool Add(CZZD.ERP.Model.BaseSafetyStockTable model);

        bool Update(CZZD.ERP.Model.BaseSafetyStockTable model);

        bool Delete(string WAREHOUSE_CODE, string PRODUCT_CODE);

        CZZD.ERP.Model.BaseSafetyStockTable GetModel(string WAREHOUSE_CODE, string PRODUCT_CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
