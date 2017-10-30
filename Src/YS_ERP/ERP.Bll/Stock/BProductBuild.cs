using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BProductBuild
    {
        IProductBuild dal = DALFactory.DataAccess.CreateProductBuildManage();

        public string GetBuildMaxSlipNumber()
        {
            return dal.GetBuildMaxSlipNumber();
        }

        public bool Existstock(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            return dal.Existstock(WAREHOUSE_CODE, PRODUCT_CODE);
        }

        public int AddBuild(BllProductBuildTable PBModel)
        {
            return dal.AddBuild(PBModel);
        }

        public int GetBuildSearchRecordCount(string strWhere)
        {
            return dal.GetBuildSearchRecordCount(strWhere);
        }

        public DataSet GetBuildSearchList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetBuildSearchList(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetBuildSearchPrintList(string strWhere)
        {
            return dal.GetBuildSearchPrintList(strWhere);
        }

        public int GetBuildRecordCount(string strWhere)
        {
            return dal.GetBuildRecordCount(strWhere);
        }

        public DataSet GetBilldList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetBilldList(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetBuildPrintList(string strWhere)
        {
            return dal.GetBuildPrintList(strWhere);
        }

        public BllProductBuildTable GetModel(string SLIP_NUMBER)
        {
            return dal.GetModel(SLIP_NUMBER);
        }

        public DataSet getParts(string PRODUCT_CODE)
        {
            return dal.getParts(PRODUCT_CODE);
        }

        public int AddRelieve(BllProductBuildTable PBModel)
        {
            return dal.AddRelieve(PBModel);
        }
    }
}
