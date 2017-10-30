using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Model;
using CZZD.ERP.Model.Master;

namespace CZZD.ERP.IDAL
{
     public interface  IBank
    {
         DataSet GetBank(string ConpanyCode);

         bool Exists(string CODE);

         bool Add(BaseBankTable model);

         bool Update(BaseBankTable model);

         bool Delete(string CODE);

         BaseBankTable GetModel(string CODE);

         System.Data.DataSet GetList(string strWhere);

         int GetRecordCount(string strWhere);

         System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);
    }
}
