using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface IProductUnit
    {
        bool Exists(string PRODUCT_CODE, string UNIT_CODE);

        bool Add(BaseProductUnitTable model);

        bool Update(BaseProductUnitTable model);

        bool Delete(string PRODUCT_CODE, string UNIT_CODE);

        BaseProductUnitTable GetModel(string PRODUCT_CODE, string UNIT_CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    
    }
}
