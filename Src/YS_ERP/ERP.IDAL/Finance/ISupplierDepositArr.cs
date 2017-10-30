using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface ISupplierDepositArr
    {
        int Add(CZZD.ERP.Model.BllSupplierDepositArrTable depositArrTable);

        bool Delete(string slipNumber, string lineNumber);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        string GetMaxID();

        decimal GetArrAmount(string purchaseOrderSlipNumber);
    }
}
