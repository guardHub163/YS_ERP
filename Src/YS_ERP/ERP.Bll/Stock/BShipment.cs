using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BShipment
    {
        IShipment dal = DALFactory.DataAccess.CreateShipmentManage();

        /// <summary>
        /// 未出库数据的获得
        /// </summary>
        public DataSet GetShipmentPlanList(string strWhere)
        {
            return dal.GetShipmentPlanList(strWhere);
        }

        /// <summary>
        /// 出库确认
        /// </summary>
        public int Add(List<BllShipmentTable> datas)
        {
            return dal.Add(datas);
        }

        /// <summary>
        /// 
        /// </summary>
        public BllShipmentTable GetModel(string slipNumber)
        {
            return dal.GetModel(slipNumber);
        }

        /// <summary>
        /// 根据销售订单编号查询出入库Invoice No
        /// </summary>
        public string GetReceiptInvoiceNumber(string orderSlipNumber)
        {
            return dal.GetReceiptInvoiceNumber(orderSlipNumber);
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
        /// 获得所有出库数据
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得所有出库导出数据
        /// </summary>
        public DataSet GetPrintList(string strWhere)
        {
            return dal.GetPrintList(strWhere);
        }


        /// <summary>
        /// 出库取消
        /// </summary>
        public int DeleteShipment(string slipNumber, string userCode) 
        {
            return dal.DeleteShipment(slipNumber,userCode);
        }


        /// <summary>
        /// 根据出库编号获得是否开过发票的状态
        /// </summary>
        public DataSet GetShipmentFlag(string slip_number)
        {
            return dal.GetShipmentFlag(slip_number);
        }

        /// <summary>
        /// 获得简易的出库订单，只包含HEADER部分信息
        /// </summary>
        public DataSet GetShipMentPrintSelectList(string strWhere) 
        {
            return dal.GetShipMentPrintSelectList(strWhere);
        }

        //获得在库数
        public decimal GetStock(string warehouse, string product)
        {
            return dal.GetStock(warehouse, product);
        }
    }//end class
}
