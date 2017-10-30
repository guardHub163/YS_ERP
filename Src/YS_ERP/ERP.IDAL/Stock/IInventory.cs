using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;
using System.Collections;

namespace CZZD.ERP.IDAL
{
    public interface IInventory
    {
        string GetMaxSlipNumber();

        DataSet GetStartList(string WAREHOUSE_CODE, string orderby, int startIndex, int endIndex);

        DataSet GetStartPrintList(string WAREHOUSE_CODE);

        int GetStartRecordCount(string WAREHOUSE_CODE);

        int AddInventory(BllInventoryTable BIModel);

        int GetSearchRecordCount(string strWhere);

        DataSet GetSearchList(string strWhere, string orderby, int startIndex, int endIndex);

        BllInventoryTable GetInventoryModel(string SLIP_NUMBER);

        DataSet GetLine(string SLIP_NUMBER);

        int GetEndInventoryRecordCount(string strWhere);

        DataSet GetEndInventoryList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetEndPrintList(string strWhere);

        int UpdataInventory(string SLIP_NUMBER, Hashtable ht, string LAST_UPDATE_USER, bool isEnd);
    }
}
