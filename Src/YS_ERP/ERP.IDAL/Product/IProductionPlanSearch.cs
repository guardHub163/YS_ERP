using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL.Product
{
    public interface IProductionPlanSearch
    {
        DataSet GetProductionPlan(string strwhere);
        int StartProcessing(BaseProductionPlanTable PlanTable);
        int Status(BaseProductionPlanTable PlanTable);
        int LineStatus(BaseProductionPlanTable PlanTable);
        DataSet GetProductionTechnology(string strwhere);
        int EndTechnology(BaseProductionScheduleProductionProcessTable psppTable);
        DataSet GetProductionTechnologyStatus(string strwhere);
        DataSet GetProductionDw(string strwhere);
        DataSet GetTechnologyDw(string strwhere);
    }
}
