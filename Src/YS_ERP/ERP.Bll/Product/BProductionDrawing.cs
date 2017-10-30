using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL.Product;
using System.Data;
using CZZD.ERP.Model;
using CZZD.ERP.Model.Product;

namespace CZZD.ERP.Bll.Product
{
    public class BProductionDrawing
    {

        IProductionDrawing dal = DALFactory.DataAccess.CreateProductionDrawingManage();
        public BProductionDrawing()
        {

        }
        public DataSet GetProductionDrawing(string strWhere)
        {
            return dal.GetProductionDrawing(strWhere);
        }
        public int EndDrawing(BaseProductionPlanLineTable PlanLineTable)
        {
            return dal.EndDrawing(PlanLineTable);
        }

        public int Add(BaseProductionDrawingTable model)
        {
            return dal.Add(model);
        }

        public DataSet GetProductionDrawingUpload(string strWhere)
        {
            return dal.GetProductionDrawingUpload(strWhere);
        }
        public int Delete(string SLIPNUMBER, string DRAWINGCODE, string SERVERFILENAME)
        {
            return dal.Delete(SLIPNUMBER, DRAWINGCODE, SERVERFILENAME);
        }
    }
}

