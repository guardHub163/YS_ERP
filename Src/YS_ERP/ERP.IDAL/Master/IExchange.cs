using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface IExchange 
    {
        #region  成员方法
        bool Exists(DateTime EXCHANGE_DATE, string FROM_CURRENCY_CODE);

        int Add(CZZD.ERP.Model.BaseExchangeTable model);

        int Update(CZZD.ERP.Model.BaseExchangeTable model);

        bool Delete(DateTime EXCHANGE_DATE, string FROM_CURRENCY_CODE);

        CZZD.ERP.Model.BaseExchangeTable GetModel(DateTime EXCHANGE_DATE, string FROM_CURRENCY_CODE);

        DataSet GetList(string strWhere);

        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

        DataSet GetExchangeFromTime(DateTime fromTime, string FromCurrencyCode, string ToCurrencyCode);

        #endregion  成员方法
    }
}
