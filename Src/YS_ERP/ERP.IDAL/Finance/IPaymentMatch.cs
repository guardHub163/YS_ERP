using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface IPaymentMatch
    {
        System.Data.DataSet GetPaymentEntryDataList(string strWhere);

        int AddpaymentMatch(CZZD.ERP.Model.BllPaymentMatchTable payment);

        System.Data.DataSet GetPaymentMatchSearchList(string strWhere, string orderby, int startIndex, int endIndex);

        int GetPaymentMatchSearchRecordCount(string strWhere);

        bool DeletePayment(string SLIP_NUMBER);
    }
}
