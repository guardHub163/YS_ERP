using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using System.Data;
using CZZD.ERP.IDAL;

namespace CZZD.ERP.Bll
{
    public class BOrderHeader
    {
        IOrderHeader dal = DALFactory.DataAccess.CreateOrderHeaderManage();

        public BOrderHeader()
        {

        }
        #region  Method
        /// <summary>
        /// 取得当前公司的最大订单流水号
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public string GetMaxSlipNumber()
        {
            return dal.GetMaxSlipNumber();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string slipNumber)
        {
            return dal.Exists(slipNumber);
        }

        public DataSet GetDelivery(string customer_code)
        {
            return dal.GetDelivery(customer_code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BllOrderHeaderTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BllOrderHeaderTable model)
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
        public BllOrderHeaderTable GetModel(string slipNumber)
        {
            return dal.GetModel(slipNumber);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetPrintList(string strwhere)
        {
            return dal.GetPrintList(strwhere);
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


        /// <summary>
        /// 订单承认、不承认
        /// </summary>
        public bool UpdateVerify(string slipNumber, int verifyFlag)
        {
            return dal.UpdateVerify(slipNumber, verifyFlag);
        }

        #endregion  Method

        #region History OrderHeader

        /// <summary>
        /// 得到历史记录对象实体
        /// </summary>
        public BllHistoryOrderHeaderTable GetHistoryModel(string historySlipNumber)
        {
            return dal.GetHistoryModel(historySlipNumber);
        }

        public DataSet GetHistoryOrderList(string orderSlipNumber) 
        {
            return dal.GetHistoryOrderList(orderSlipNumber);
        }
        #endregion

        /// <summary>
        /// 判断销售订单中是否包含机械本体
        /// </summary>
        public bool IsMechanicalBaseOrder(string slipNubmer)
        {
            return dal.IsMechanicalBaseOrder(slipNubmer);
        }

        #region  订单修理输入用

        /// <summary>
        /// 修理输入记录的添加
        /// </summary>
        public int AddOrderService(BllOrderServiceTable model) 
        {
            return dal.AddOrderService(model);
        }

        /// <summary>
        ///  修理输入记录的修正
        /// </summary>
        public int UpdateOrderService(BllOrderServiceTable model) 
        {
            return dal.UpdateOrderService(model);
        }

        /// <summary>
        ///  修理输入记录的删除
        /// </summary>
        public int DeleteOrderService(BllOrderServiceTable model)
        {
            return dal.DeleteOrderService(model);
        }

        /// <summary>
        /// 修理输入记录的取得
        /// </summary>
        public BllOrderServiceTable GetOrderServiceMode(string slipNumber) 
        {
            return dal.GetOrderServiceMode(slipNumber);
        }
        #endregion

        public int UpdateProduce(List<BllOrderHeaderTable> orderList)
        {
            return dal.UpdateProduce(orderList);
        }

        public DataSet GetOrderHeader(string strWhere)
        {
            return dal.GetOrderHeader(strWhere);
        }

        public DataSet GetModelInfo(string slipNumber)
        {
            return dal.GetModelInfo(slipNumber);
        }

        public DataSet GetModelInfo(string slipNumber, string productcode)
        {
            return dal.GetModelInfo1(slipNumber, productcode);
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount1(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList1(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetList(strWhere, orderby, startIndex, endIndex);
        }
    }//end class
}
