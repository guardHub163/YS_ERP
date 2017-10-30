using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;

namespace CZZD.ERP.IDAL
{
    public interface IUser
    {
        bool Exists(string CODE, string COMPANY_CODE);

        bool Add(CZZD.ERP.Model.BaseUserTable model);

        bool Update(CZZD.ERP.Model.BaseUserTable model);

        bool Delete(string CODE, string COMPANY_CODE);

        BaseUserTable GetModel(string CODE, string COMPANY_CODE);

        System.Data.DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        string GetCompany(string name);
        bool UpdateDefault(CZZD.ERP.Model.BaseUserTable model);

    }
}
