using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BPurchaseOrder
    {
        IPurchaseOrder dal = DALFactory.DataAccess.CreatePurchaseOrderManage();

        public BPurchaseOrder()
        {
        }
        #region  Method
        /// <summary>
        /// 取得当前公司的最大订单流水号
        /// </summary>
        public string GetMaxSlipNumber()
        {
            return dal.GetMaxSlipNumber();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllPurchaseOrderTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BllPurchaseOrderTable model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string slipNumber)
        {
            return dal.Delete(slipNumber);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BllPurchaseOrderTable GetModel(string slipNumber)
        {
            return dal.GetModel(slipNumber);
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetList(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetPurchaseOrderList(string SLIP_NUMBER)
        {
            return dal.GetPurchaseOrderList(SLIP_NUMBER);
        }

        public DataSet GetReceivingPlanByPurchaseOrderSlipNumber(string SLIP_NUMBER)
        {
            return dal.GetReceivingPlanByPurchaseOrderSlipNumber(SLIP_NUMBER);
        }

        public int GetPurchaseSupplementRecordCount(string strWhere)
        {
            return dal.GetPurchaseSupplementRecordCount(strWhere);
        }

        public DataSet GetPurchaseSupplementList(string strWhere)
        {
            return dal.GetPurchaseSupplementList(strWhere);
        }

        public DataSet GetPurchaseSupplementList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetPurchaseSupplementList(strWhere, orderby, startIndex, endIndex);
        }

        public decimal GetPurchaseQuantity(string warehouseCode, string productCode)
        {
            return dal.GetPurchaseQuantity(warehouseCode, productCode);
        }

        public int GetPartsRecordCount(string PRODUCT_CODE)
        {
            return dal.GetPartsRecordCount(PRODUCT_CODE);
        }

        public DataSet GetPartsList(string PRODUCT_CODE, string orderby, int startIndex, int endIndex)
        {
            return dal.GetPartsList(PRODUCT_CODE, orderby, startIndex, endIndex);
        }

        public CZZD.ERP.Model.BaseStockTable GetStockModel(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            return dal.GetStockModel(WAREHOUSE_CODE, PRODUCT_CODE);
        }

        //实到数量
        public decimal GetReceiptActualQuantity(string PO_SLIP_NUMBER, string PRODUCT_CODE)
        {
            return dal.GetReceiptActualQuantity(PO_SLIP_NUMBER, PRODUCT_CODE);
        }

        /// <summary>
        /// 供应商供货平衡表
        /// </summary>
        /// <returns></returns>
        public DataSet GetPurchaseBalanceBySupplier(string strWhere)
        {
            return dal.GetPurchaseBalanceBySupplier(strWhere);
        }

        #region 自动采购
        /// <summary>
        /// 自动采购数据获得，按供应商，商品分类
        /// </summary>
        public DataSet GetAutoPurchaseList(string slipNumbers, bool isNetPurchase)
        {
            return dal.GetAutoPurchaseList(slipNumbers, isNetPurchase);
        }

        /// <summary>
        /// 自动采购数据获得，按订单，商品分类
        /// </summary>
        public DataSet GetAutoPurchaseList(string slipNumbers)
        {
            return dal.GetAutoPurchaseList(slipNumbers);
        }

        /// <summary>
        /// 自动采购执行
        /// </summary>
        public int AutoPurchase(List<BllPurchaseOrderTable> poList, List<BllOrderLineProductPartsTable> olppList, string orderSlipNumbers)
        {
            return dal.AutoPurchase(poList, olppList, orderSlipNumbers);
        }
        #endregion

        #endregion  Method


    }
}
