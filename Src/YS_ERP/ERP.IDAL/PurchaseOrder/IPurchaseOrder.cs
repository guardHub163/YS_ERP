using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface IPurchaseOrder
    {
        #region  成员方法
        string GetMaxSlipNumber();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(CZZD.ERP.Model.BllPurchaseOrderTable model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(CZZD.ERP.Model.BllPurchaseOrderTable model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string SLIP_NUMBER);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CZZD.ERP.Model.BllPurchaseOrderTable GetModel(string SLIP_NUMBER);

        int GetRecordCount(string strWhere);

        DataSet GetList(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetPurchaseOrderList(string SLIP_NUMBER);

        DataSet GetReceivingPlanByPurchaseOrderSlipNumber(string SLIP_NUMBER);
        

        int GetPurchaseSupplementRecordCount(string strWhere);

        DataSet GetPurchaseSupplementList(string strWhere);

        DataSet GetPurchaseSupplementList(string strWhere, string orderby, int startIndex, int endIndex);

        decimal GetPurchaseQuantity(string warehouseCode, string productCode);

        int GetPartsRecordCount(string PRODUCT_CODE);

        DataSet GetPartsList(string PRODUCT_CODE, string orderby, int startIndex, int endIndex);

        CZZD.ERP.Model.BaseStockTable GetStockModel(string WAREHOUSE_CODE, string PRODUCT_CODE);

        //实到数量
        decimal GetReceiptActualQuantity(string PO_SLIP_NUMBER, string PRODUCT_CODE);
        #endregion  成员方法

        DataSet GetPurchaseBalanceBySupplier(string strWhere);

        DataSet GetAutoPurchaseList(string slipNumbers, bool isNetPurchase);

        DataSet GetAutoPurchaseList(string slipNumbers);

        int AutoPurchase(List<BllPurchaseOrderTable> poList, List<BllOrderLineProductPartsTable> olppList, string orderSlipNumbers);
    }
}
