using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BSales
    {
        ISales dal = DALFactory.DataAccess.CreateSalesManage();

        #region 查询未开票数据
        public DataSet GetSalesEntryDataList(string strWhere)
        {
            return dal.GetSalesEntryDataList(strWhere);
        }
        #endregion

        #region 插入销售发票数据
        public int Add(BllSalesTable salesTable)
        {
            return dal.Add(salesTable);
        }
        #endregion

        #region 查询已开票数据
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetSalesList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetSalesList(strWhere, orderby, startIndex, endIndex);
        }
        #endregion

        #region 查询已开票数据总数
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetSalesRecordCount(string strWhere)
        {
            return dal.GetSalesRecordCount(strWhere);
        }
        #endregion

        #region 查询已开票未收款数据
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetUnReceiptList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetUnReceiptList(strWhere, orderby, startIndex, endIndex);
        }
        #endregion

        #region 查询已开票未收款数据总数
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetUnReceiptRecordCount(string strWhere)
        {
            return dal.GetUnReceiptRecordCount(strWhere);
        }
        #endregion

        #region 查询未收款数据
        public DataSet GetReceiptEntryDataList(string strWhere)
        {
            return dal.GetReceiptEntryDataList(strWhere);
        }
        #endregion

        #region 增加一条收款数据
        /// <summary>
        /// 增加一条收款数据
        /// </summary>
        public int AddBllReceiptMatch(BllReceiptMatchTable model)
        {
            return dal.AddBllReceiptMatch(model);
        }
        #endregion

        #region 收款查询
        public DataSet GetReceiptMatchSearchList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetReceiptMatchSearchList(strWhere, orderby, startIndex, endIndex);
        }

        public int GetReceiptMatchSearchRecordCount(string strWhere)
        {
            return dal.GetReceiptMatchSearchRecordCount(strWhere);
        }
        #endregion

        #region 删除
        public bool DeleteSales(string SLIP_NUMBER)
        {
            return dal.DeleteSales(SLIP_NUMBER);
        }

        public bool DeleteReceiptMatch(string SLIP_NUMBER)
        {
            return dal.DeleteReceiptMatch(SLIP_NUMBER);
        }
        #endregion

        #region 获得预收款未开票余额
        /// <summary>
        /// 获得预收款未开票余额
        /// </summary>
        public decimal GetTotalDepositUnBilling(string customerClaimCode)
        {
            return dal.GetTotalDepositUnBilling(customerClaimCode);
        }
        #endregion

        #region 获得SALES对象
        public BllSalesTable GetModel(string SLIP_NUMBER)
        {
            return dal.GetModel(SLIP_NUMBER);
        }
        #endregion 

        #region 获得已开票金额
        public decimal GetInvoiceAmount(string SHIPMENT_SLIP_NUMBER)
        {
            return dal.GetInvoiceAmount(SHIPMENT_SLIP_NUMBER);
        }
        #endregion
    }
}
