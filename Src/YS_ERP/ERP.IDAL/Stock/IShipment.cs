using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface IShipment
    {
        System.Data.DataSet GetShipmentPlanList(string strWhere);

        int Add(List<CZZD.ERP.Model.BllShipmentTable> datas);

        int GetRecordCount(string strWhere);

        BllShipmentTable GetModel(string SLIP_NUMBER);

        string GetReceiptInvoiceNumber(string orderSlipNumber);

        DataSet GetList(string strWhere);

        DataSet GetPrintList(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        int DeleteShipment(string slipNumber,string userCode);

        DataSet GetShipmentFlag(string slip_number);



        DataSet GetShipMentPrintSelectList(string strWhere);

        //获得在库数
        decimal GetStock(string warehouse, string product);
    }
}
