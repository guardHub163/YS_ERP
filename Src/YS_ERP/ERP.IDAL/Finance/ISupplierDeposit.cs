using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface ISupplierDeposit
    {
        string GetMaxID();

        int Add(CZZD.ERP.Model.BllSupplierDepositTable depositTable);

        bool Delete(string slipNumber);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        System.Data.DataSet GetTotalDeposit(string supplierCode);
    }
}
