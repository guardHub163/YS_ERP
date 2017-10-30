using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL.Product;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll.Product
{
    public class BProductionPlan
    {
        IProductionPlan dal = DALFactory.DataAccess.CreateProductionPlanManage();
        public BProductionPlan()
        {
        }

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
        /// 增加一条数据
        /// </summary>
        public string Add(BaseProductionPlanTable model, BllOrderHeaderTable bOrderHeader)
        {
            return dal.Add(model,bOrderHeader);
        }

        public DataSet GetProductionPlanHeader(string strWhere)
        {
            return dal.GetProductionPlanHeader(strWhere);
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

        public BaseProductionPlanTable GetModel(string SLIP_NUMBER)
        {
            return dal.GetModel(SLIP_NUMBER);
        }

        public string Update(BaseProductionPlanTable model)
        {
            return dal.Update(model);
        }

        public int Pause(string SLIP_NUMBER, string status)
        {
            return dal.Pause(SLIP_NUMBER,status);
        }
    }
}
