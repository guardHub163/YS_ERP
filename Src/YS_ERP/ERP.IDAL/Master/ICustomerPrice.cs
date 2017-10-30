using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface ICustomerPrice
    {
        bool Exists(string CUSTOMER_CODE, string PRODUCT_CODE, string UNIT_CODE);

        bool Add(CZZD.ERP.Model.BaseCustomerPriceTable model);

        bool Update(CZZD.ERP.Model.BaseCustomerPriceTable model);

        bool Delete(string CUSTOMER_CODE, string PRODUCT_CODE, string UNIT_CODE);

        CZZD.ERP.Model.BaseCustomerPriceTable GetModel(string CUSTOMER_CODE, string PRODUCT_CODE, string UNIT_CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    
    }
}
