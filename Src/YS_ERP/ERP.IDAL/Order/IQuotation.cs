using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface IQuotation
    {
        string GetMaxSlipNumber();

        bool Exists(string slipNumber);

        string Add(BllQuotationTable model);

        int Update(BllQuotationTable QuotationModel);

        bool Delete(string slipNumber);

        BllQuotationTable GetModel(string SLIP_NUMBER);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        System.Data.DataSet GetHistoryQuotation(string orderSlipNumber);

        CZZD.ERP.Model.BllQuotationTable GetHistoryModel(string historySlipNumber);
    }
}
