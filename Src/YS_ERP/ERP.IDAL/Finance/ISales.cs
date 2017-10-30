using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface ISales
    {

        #region 查询未开票数据
        DataSet GetSalesEntryDataList(string strWhere);
        #endregion

        #region 插入销售发票数据
        int Add(BllSalesTable salesTable);
        #endregion

        #region 查询已开票数据总数
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        int GetSalesRecordCount(string strWhere);
        #endregion

        #region 查询已开票数据
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        DataSet GetSalesList(string strWhere, string orderby, int startIndex, int endIndex);
        #endregion

        #region 查询已开票未收款数据总数
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        int GetUnReceiptRecordCount(string strWhere);
        #endregion

        #region 查询已开票未收款数据
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        DataSet GetUnReceiptList(string strWhere, string orderby, int startIndex, int endIndex);
        #endregion

        #region 查询未收款数据
        DataSet GetReceiptEntryDataList(string strWhere);
        #endregion

        #region 增加一条收款数据
        /// <summary>
        /// 增加一条收款数据
        /// </summary>
        int AddBllReceiptMatch(BllReceiptMatchTable model);
        #endregion

        #region 收款查询
        int GetReceiptMatchSearchRecordCount(string strWhere);

        DataSet GetReceiptMatchSearchList(string strWhere, string orderby, int startIndex, int endIndex);
        #endregion

        bool DeleteSales(string SLIP_NUMBER);

        bool DeleteReceiptMatch(string SLIP_NUMBER);

        BllSalesTable GetModel(string SLIP_NUMBER);

        decimal GetInvoiceAmount(string SALES_SLI_NUMBER);

        decimal GetTotalDepositUnBilling(string customerClaimCode);
    }
}
