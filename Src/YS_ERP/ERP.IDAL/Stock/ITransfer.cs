using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface ITransfer
    {
        string GetMaxSlipNumber();

        int Add(BllTransferReceiptTable TRModel);

        bool Existstock(string WAREHOUSE_CODE, string PRODUCT_CODE);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetPrintList(string strWhere);
    }
}
