using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface IReceipt
    {        
        int UpdateReceiptPlan(int SLIP_NUMBER, string LAST_UPDATE_USER);

        int AddReceiptPlan(BllReceiptPlanTable model);

        int AddReceipt(BllReceiptTable model);

        int UpdataCancel(BllReceiptLineTable model);

        BllReceiptTable GetReceiptModel(string SLIP_NUMBER);

        BllReceiptTable GetRModel(string PO_SLIP_NUMBER);

        BllReceiptLineTable GetLineModel(string SLIP_NUMBER, int LINE_NUMBER);

        string GetMaxSlipNumber();

        int GetMaxLineNumber();

        bool Exsitreceipt(string PO_SLIP_NUMBER);

        int Receipt(List<BllReceiptTable> receiptList, bool IsInstallments, DateTime planDate);

        BllReceiptPlanTable GetReceiptPlanModel(int slipNumber);

        int GetRecordCount(string strWhere);

        DataSet GetList(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        int GetSearchRecordCount(string strWhere);

        DataSet GetSearchList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetPrintList(string strWhere);

        int UnReceipt(string slipNumber);

        bool ExsitProdcuct(string PurchaseOrder, string product);

        int AddReReceipt(BllReReceiptTable rereceiptList);

        decimal GetPurchaseQuantity(string slipnumber, string product);

        DataSet GetReList(string strWhere, string orderby, int startIndex, int endIndex);

        int GetReSearchCount(string strWhere);

        BllReReceiptTable GetReModel(string SLIP_NUMBER);

        bool UpdateOther(CZZD.ERP.Model.BllReceiptTable model);

        BllReceiptTable GetOtherModel(string SLIP_NUMBER);

        DataSet GetOtherList(string SLIP_NUMBER);

        int DeleteOtherReceipt(string slipNumber);

        int AddOtherReceipt(BllReceiptTable OtherReceipt);
    }
}
