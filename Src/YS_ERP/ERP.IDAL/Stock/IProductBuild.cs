using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface IProductBuild
    {
        int GetBuildRecordCount(string strWhere);

        DataSet GetBilldList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetBuildPrintList(string strWhere);

        string GetBuildMaxSlipNumber();

        bool Existstock(string WAREHOUSE_CODE, string PRODUCT_CODE);

        int AddBuild(BllProductBuildTable PBModel);

        int GetBuildSearchRecordCount(string strWhere);

        DataSet GetBuildSearchList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetBuildSearchPrintList(string strWhere);

        BllProductBuildTable GetModel(string SLIP_NUMBER);

        DataSet getParts(string PRODUCT_CODE);

        int AddRelieve(BllProductBuildTable PBModel);
    }
}
