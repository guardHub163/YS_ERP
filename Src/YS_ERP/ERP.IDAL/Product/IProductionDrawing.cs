using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;
using CZZD.ERP.Model.Product;

namespace CZZD.ERP.IDAL.Product
{
    public interface IProductionDrawing
    {
        DataSet GetProductionDrawing(string strwhere);
        int EndDrawing(BaseProductionPlanLineTable PlanLineTable);
        int Add(BaseProductionDrawingTable model);
        DataSet GetProductionDrawingUpload(string strwhere);
        int Delete(string SLIPNUMBER, string DRAWINGCODE, string SERVERFILENAME);
    }
}
