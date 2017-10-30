using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BPaymentMatch
    {
        IPaymentMatch dal = DALFactory.DataAccess.CreatePaymentMatchManage();

        public DataSet GetPaymentEntryDataList(string strWhere)
        {
            return dal.GetPaymentEntryDataList(strWhere);
        }

        public int AddpaymentMatch(BllPaymentMatchTable payment)
        {
            return dal.AddpaymentMatch(payment);
        }

        public DataSet GetPaymentMatchSearchList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetPaymentMatchSearchList(strWhere, orderby, startIndex, endIndex);
        }

        public int GetPaymentMatchSearchRecordCount(string strWhere)
        {
            return dal.GetPaymentMatchSearchRecordCount(strWhere);
        }

        public bool DeletePayment(string SLIP_NUMBER)
        {
            return dal.DeletePayment(SLIP_NUMBER);
        }
    }
}
