 using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL.Product
{
   public interface IProductionPlan
    {
       string GetMaxSlipNumber();
       string Add(BaseProductionPlanTable model,BllOrderHeaderTable bOrderHeader);
       DataSet GetProductionPlanHeader(string strwhere);
       int GetRecordCount(string strWhere);
       System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
       BaseProductionPlanTable GetModel(string SLIP_NUMBER);
       string Update(BaseProductionPlanTable model);
       int Pause(string SLIP_NUMBER, string status);
    }
}
