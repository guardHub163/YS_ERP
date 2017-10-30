using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface IDelivery
    {
        bool Exists(string CUSTOMER_CODE, string DELIVERY_CODE);

        bool Add(CZZD.ERP.Model.BaseDeliveryTable model);

        bool Update(CZZD.ERP.Model.BaseDeliveryTable model);

        bool Delete(string CUSTOMER_CODE, string DELIVERY_CODE);

        CZZD.ERP.Model.BaseDeliveryTable GetModel(string CUSTOMER_CODE, string DELIVERY_CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    
    }
}
