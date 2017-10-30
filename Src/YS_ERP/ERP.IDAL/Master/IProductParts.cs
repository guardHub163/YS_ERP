using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface IProductParts
    {
        bool Exists(string PRODUCT_CODE, string PRODUCT_PART_CODE);

        bool Add(CZZD.ERP.Model.BaseProductPartsTable model);

        bool Update(CZZD.ERP.Model.BaseProductPartsTable model);

        bool Delete(string PRODUCT_CODE, string PRODUCT_PART_CODE);

        CZZD.ERP.Model.BaseProductPartsTable GetModel(string PRODUCT_CODE, string PRODUCT_PART_CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
