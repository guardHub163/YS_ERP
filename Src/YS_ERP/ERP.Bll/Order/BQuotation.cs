using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BQuotation
    {
        IQuotation dal = DALFactory.DataAccess.CreateQuotationManage();
        public string GetMaxSlipNumber()
        {
            return dal.GetMaxSlipNumber();
        }

        public bool Exists(string slipNumber)
        {
            return dal.Exists(slipNumber);
        }

        public string Add(BllQuotationTable model)
        {
            return dal.Add(model);
        }

        public int Update(BllQuotationTable QuotationModel)
        {
            return dal.Update(QuotationModel);
        }

        public bool Delete(string slipNumber)
        {
            return dal.Delete(slipNumber);
        }

        public BllQuotationTable GetModel(string SLIP_NUMBER)
        {
            return dal.GetModel(SLIP_NUMBER);
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetList(strWhere, orderby, startIndex, endIndex);
        }

        public DataSet GetHistoryQuotation(string orderSlipNumber)
        {
            return dal.GetHistoryQuotation(orderSlipNumber);
        }

        /// <summary>
        /// 得到历史记录对象实体
        /// </summary>
        public BllQuotationTable GetHistoryModel(string historySlipNumber)
        {
            return dal.GetHistoryModel(historySlipNumber);
        }
    }
}
