using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface IStock
    {
        string GetMaxSlipNumber();

        bool Exists(string WAREHOUSE_CODE, string PRODUCT_CODE);

        int Add(CZZD.ERP.Model.BaseStockTable model);

        bool Update(CZZD.ERP.Model.BaseStockTable model);

        bool UpdateStock(BaseStockTable stockTable);

        CZZD.ERP.Model.BaseStockTable GetModel(string WAREHOUSE_CODE, string PRODUCT_CODE);

        int AddHistory(BllHistoryStockTable historyStockTable);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetPrintList(string strWhere);

        int GetStockRecordCount(string strWhere);

        System.Data.DataSet GetStockList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetStockPrintList(string strWhere);

        decimal GetPurchaseQuantity(string warehouseCode, string productCode);

        DataSet GetReceiptList(string WAREHOUSE_CODE, string PRODUCT_CODE, int startIndex, int endIndex);

        DataSet GetAlloationList(string WAREHOUSE_CODE, string PRODUCT_CODE, int startIndex, int endIndex);

        int GetDelayRecordCount(string strWhere);

        DataSet GetDelayList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetDelayPrintList(string strWhere);

        int GetReceiptRecordCount(string WAREHOUSE_CODE, string PRODUCT_CODE);

        int GetAlloationRecordCount(string WAREHOUSE_CODE, string PRODUCT_CODE);


        DataSet GetStockNotifyList(string strWhere, string orderby, int startIndex, int endIndex);

        int GetStockNotifyRecordCount(string strWhere);
    }
}
