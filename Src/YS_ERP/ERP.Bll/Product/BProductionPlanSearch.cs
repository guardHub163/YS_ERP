using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL.Product;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BProductionPlanSearch
    {
        IProductionPlanSearch dal = DALFactory.DataAccess.CreateProductionPlanSearchManage();
        public BProductionPlanSearch()
        {
        }

        public DataSet GetProductionPlan(string strWhere)
        {
            return dal.GetProductionPlan(strWhere);
        }

        public int StartProcessing(BaseProductionPlanTable PlanTable)
        {
            return dal.StartProcessing(PlanTable);
        }
        public int LineStatus(BaseProductionPlanTable PlanTable)
        {
            return dal.LineStatus(PlanTable);
        }
        public int Status(BaseProductionPlanTable PlanTable)
        {
            return dal.Status(PlanTable);
        }
        public DataSet GetProductionTechnology(string strWhere)
        {
            return dal.GetProductionTechnology(strWhere);
        }

        public int EndTechnology(BaseProductionScheduleProductionProcessTable psppTable)
        {
            return dal.EndTechnology(psppTable);
        }
        public DataSet GetProductionTechnologyStatus(string strWhere)
        {
            return dal.GetProductionTechnologyStatus(strWhere);
        }
        public DataSet GetProductionDw(string strWhere)
        {
            return dal.GetProductionDw(strWhere);
        }

        public DataSet GetTechnologyDw(string strWhere)
        {
            return dal.GetTechnologyDw(strWhere);
        }

    }
}
