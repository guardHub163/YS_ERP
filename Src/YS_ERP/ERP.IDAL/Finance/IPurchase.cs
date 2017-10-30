using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface IPurchase
    {

        #region 查询未开票数据
        DataSet GetPurchaseEntryDataList(string strWhere);
        #endregion

        #region 增加开票数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(BllPurchaseTable model);
        #endregion

        int GetPurchaseRecordCount(string strWhere);

        DataSet GetPurchaseList(string strWhere, string orderby, int startIndex, int endIndex);

        BllPurchaseTable GetPurchaseModel(string SLIP_NUMBER);

        bool DeletePurchase(string SLIP_NUMBER);

        int GetUnPaymentRecordCount(string strWhere);

        DataSet GetUnPaymentList(string strWhere, string orderby, int startIndex, int endIndex);

        decimal GetGetInvoiceAmount(string RECEIPT_SLIP_NUMBER);

        DataSet GetPurchaseList(string strWhere);

        decimal GetTotalDeposit(string supplierCode);
    }
}
