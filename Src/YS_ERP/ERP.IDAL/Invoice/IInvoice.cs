using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface IInvoice
    {
        DataSet GetSlipNumber(string where);

        DataSet GetStatementOneInfo(string slipNumber);

        DataSet GetStatementTwoInfo(string slipNumber);

        DataSet GetOrderHeaderInfo(string orderSlipNumber);

        DataSet GetInvoiceNumber(string orderSlipNumber);

        DataSet GetAmountWithoutTaxa(string orderSlipNumber);

        DataSet GetSalesProductInfo(string where);

        DataSet GetMachineAccountReceivable(string where);

        DataSet GetPartsAccountReceivable(string where);

        DataSet GetReceiptMatch(string where);
    }
}
