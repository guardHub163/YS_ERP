using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.IDAL
{
    public interface IAlloation
    {
        int Add(CZZD.ERP.Model.BllAlloationTable model);

        int Add(List<CZZD.ERP.Model.BllAlloationTable> dataList,int alloationStatus);

        bool Delete(string slipNumber);

        bool Delete(string orderSlipNumber, int orderLineNumber);

        bool DeleteByOrderSlipNumber(int orderSlipNumber);


        CZZD.ERP.Model.BllAlloationTable GetModel(string slipNumber);

        decimal GetAlloationQuantity(string warehouseCode, string productCode);

        decimal GetAlloationQuantity(string orderSlipNumber, string warehouseCode, string productCode);

        CZZD.ERP.Model.BaseWarehouseTable GetAlloationWarehouse(string orderSlipNumber, int orderLineNumber);

    }
}
