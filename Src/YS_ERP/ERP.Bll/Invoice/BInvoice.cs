using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BInvoice
    {
        IInvoice dal = DALFactory.DataAccess.CreatInvoiceManage();
        
        public DataSet GetSlipNumber(string where) 
        {
            return dal.GetSlipNumber(where);
        }

        public DataSet GetStatementOneInfo(string slipNumber) 
        {
            return dal.GetStatementOneInfo(slipNumber);
        }

        public DataSet GetStatementTwoInfo(string slipNumber) 
        {
            return dal.GetStatementTwoInfo(slipNumber);
        }

        public DataSet GetOrderHeaderInfo(string orderSlipNumber) 
        {
            return dal.GetOrderHeaderInfo(orderSlipNumber);
        }

        public DataSet GetInvoiceNumber(string orderSlipNumber) 
        {
            return dal.GetInvoiceNumber(orderSlipNumber);
        }

        public DataSet GetAmountWithoutTaxa(string orderSlipNumber) 
        {
            return dal.GetAmountWithoutTaxa(orderSlipNumber);
        }

        public DataSet GetSalesProductInfo(string where) 
        {
            return dal.GetSalesProductInfo(where);
        }

        #region 应收账款管理表
        /// <summary>
        /// 获得机械本体应收账款
        /// </summary>
        public DataSet GetMachineAccountReceivable(string where)
        {
            return dal.GetMachineAccountReceivable(where);
        }

        /// <summary>
        /// 获得机械部件应收账款
        /// </summary>
        public DataSet GetPartsAccountReceivable(string where)
        {
            return dal.GetPartsAccountReceivable(where);
        }

         /// <summary>
        /// 获得己开票的收款金额
        /// </summary>
        public DataSet GetReceiptMatch(string where)
        {
            return dal.GetReceiptMatch(where);
        }
        #endregion
    }//end class
}
