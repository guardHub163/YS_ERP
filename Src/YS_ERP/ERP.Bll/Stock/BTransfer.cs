using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BTransfer
    {
        ITransfer dal = DALFactory.DataAccess.CreateTransferManage();

        public string GetMaxSlipNumber()
        {
            return dal.GetMaxSlipNumber();
        }

        public int Add(BllTransferReceiptTable TRModel)
        {
            return dal.Add(TRModel);
        }

        public bool Existstock(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            return dal.Existstock(WAREHOUSE_CODE, PRODUCT_CODE);
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

        public DataSet GetPrintList(string strWhere)
        {
            return dal.GetPrintList(strWhere);
        }
    }
}
