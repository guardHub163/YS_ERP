using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface ILocation
    {
        bool Exists(string CODE);
        bool Exists(string CODE, string PRODUCT_CODE, string WAREHOUSE_CODE);

        bool Add(CZZD.ERP.Model.BaseLocationTable model);

        bool Update(CZZD.ERP.Model.BaseLocationTable model);

        bool Delete(string CODE, string PRODUCT_CODE, string WAREHOUSE_CODE);

        CZZD.ERP.Model.BaseLocationTable GetModel(string CODE ,string PRODUCT_CODE, string WAREHOUSE_CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
