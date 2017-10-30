using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BStock
    {
        IStock dal = DALFactory.DataAccess.CreateStockManage();

        #region  Method

        public string GetMaxSlipNumber()
        {
            return dal.GetMaxSlipNumber();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            return dal.Exists(WAREHOUSE_CODE, PRODUCT_CODE);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseStockTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseStockTable model)
        {
            return dal.Update(model);
        }

        public bool UpdateStock(BaseStockTable stockTable)
        {
            return dal.UpdateStock(stockTable);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseStockTable GetModel(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            return dal.GetModel(WAREHOUSE_CODE, PRODUCT_CODE);
        }

        public int AddHistory(BllHistoryStockTable historyStockTable)
        {
            return dal.AddHistory(historyStockTable);
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetList(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetPrintList(string strWhere)
        {
            return dal.GetPrintList(strWhere);
        }

        /// <summary>
        /// 获得库存分页数据总的记录条数
        /// </summary>
        public int GetStockRecordCount(string strWhere)
        {
            return dal.GetStockRecordCount(strWhere);
        }

        /// <summary>
        /// 获得库存分页数据列表
        /// </summary>
        public DataSet GetStockList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetStockList(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 获得库存分页数据总的记录条数
        /// </summary>
        public int GetStockNotifyRecordCount(string strWhere)
        {
            return dal.GetStockNotifyRecordCount(strWhere);
        }

        /// <summary>
        /// 获得库存分页数据列表
        /// </summary>
        public DataSet GetStockNotifyList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetStockNotifyList(strWhere, orderby, startIndex, endIndex);
        }


        public DataSet GetStockPrintList(string strWhere)
        {
            return dal.GetStockPrintList(strWhere);
        }

        public decimal GetPurchaseQuantity(string warehouseCode, string productCode)
        {
            return dal.GetPurchaseQuantity(warehouseCode, productCode);
        }

        public DataSet GetReceiptList(string WAREHOUSE_CODE, string PRODUCT_CODE, int startIndex, int endIndex)
        {
            return dal.GetReceiptList(WAREHOUSE_CODE, PRODUCT_CODE, startIndex, endIndex);
        }

        public DataSet GetAlloationList(string WAREHOUSE_CODE, string PRODUCT_CODE, int startIndex, int endIndex)
        {
            return dal.GetAlloationList(WAREHOUSE_CODE, PRODUCT_CODE, startIndex, endIndex);
        }

        public int GetDelayRecordCount(string strWhere)
        {
            return dal.GetDelayRecordCount(strWhere);
        }

        public DataSet GetDelayList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetDelayList(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetDelayPrintList(string strWhere)
        {
            return dal.GetDelayPrintList(strWhere);
        }

        public int GetAlloationRecordCount(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            return dal.GetAlloationRecordCount(WAREHOUSE_CODE, PRODUCT_CODE);
        }

        public int GetReceiptRecordCount(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            return dal.GetReceiptRecordCount(WAREHOUSE_CODE, PRODUCT_CODE);
        }
        #endregion  Method
    }
}
