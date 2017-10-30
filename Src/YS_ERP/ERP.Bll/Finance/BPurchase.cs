using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BPurchase
    {
        IPurchase dal = DALFactory.DataAccess.CreatePurchaseManage();

        #region 查询未开票数据
        public DataSet GetPurchaseEntryDataList(string strWhere)
        {
            return dal.GetPurchaseEntryDataList(strWhere);
        }
        #endregion

        #region 增加开票数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllPurchaseTable model)
        {
            return dal.Add(model);
        }
        #endregion

        #region 
        public int GetPurchaseRecordCount(string strWhere)
        {
            return dal.GetPurchaseRecordCount(strWhere);
        }
        public DataSet GetPurchaseList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetPurchaseList(strWhere, orderby, startIndex, endIndex);
        }
        public DataSet GetPurchaseList(string strWhere)
        {
            return dal.GetPurchaseList(strWhere);
        }
        #endregion 

        #region 获得对象
        public BllPurchaseTable GetPurchaseModel(string SLIP_NUMBER)
        {
            return dal.GetPurchaseModel(SLIP_NUMBER);
        }
        #endregion

        #region 取消
        public bool DeletePurchase(string SLIP_NUMBER)
        {
            return dal.DeletePurchase(SLIP_NUMBER);
        }
        #endregion

        public int GetUnPaymentRecordCount(string strWhere) 
        {
            return dal.GetUnPaymentRecordCount(strWhere);
        }

        public DataSet GetUnPaymentList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetUnPaymentList(strWhere, orderby, startIndex, endIndex);
        }

        public decimal GetGetInvoiceAmount(string RECEIPT_SLIP_NUMBER)
        {
            return dal.GetGetInvoiceAmount(RECEIPT_SLIP_NUMBER);
        }

        public decimal GetTotalDeposit(string supplierCode)
        {
            return dal.GetTotalDeposit(supplierCode);
        }
    }
}
