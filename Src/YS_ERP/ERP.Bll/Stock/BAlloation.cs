using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BAlloation
    {
        IAlloation dal = DALFactory.DataAccess.CreateAlloationManage();

        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllAlloationTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        public int Add(List<BllAlloationTable> dataList, int alloationStatus)
        {
            return dal.Add(dataList, alloationStatus);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string slipNumber)
        {

            return dal.Delete(slipNumber);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string orderSlipNumber, int orderLineNumber)
        {

            return dal.Delete(orderSlipNumber, orderLineNumber);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool DeleteByOrderSlipNumber(int orderLineNumber)
        {

            return dal.DeleteByOrderSlipNumber(orderLineNumber);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BllAlloationTable GetModel(string slipNumber)
        {
            return dal.GetModel(slipNumber);
        }

        /// <summary>
        /// 引当数量的取得
        /// </summary>
        public decimal GetAlloationQuantity(string warehouseCode, string productCode)
        {
            return dal.GetAlloationQuantity(warehouseCode, productCode);
        }

        /// <summary>
        /// 引当数量的取得
        /// </summary>
        public decimal GetAlloationQuantity(string orderSlipNumber, string warehouseCode, string productCode)
        {
            return dal.GetAlloationQuantity(orderSlipNumber, warehouseCode, productCode);
        }

        /// <summary>
        /// 当前己引当的仓库的取得
        /// </summary>
        /// <returns></returns>
        public BaseWarehouseTable GetAlloationWarehouse(string orderSlipNumber, int orderLineNumber)
        {
            return dal.GetAlloationWarehouse(orderSlipNumber, orderLineNumber);
        }

        #endregion  Method

    }
}
