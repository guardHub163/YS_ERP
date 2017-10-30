using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BSupplierDepositArr
    {
        ISupplierDepositArr dal = DALFactory.DataAccess.CreateSupplierDepositArrManage();
        /// <summary>
        /// 
        /// </summary>
        public string GetMaxID()
        {
            return dal.GetMaxID();
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllSupplierDepositArrTable depositArrTable)
        {
            return dal.Add(depositArrTable);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string slipNumber, string lineNumber)
        {
            return dal.Delete(slipNumber, lineNumber);
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

        /// <summary>
        /// 根据订编号获得己分配的金额
        /// </summary>
        public decimal GetArrAmount(string purchaseOrderSlipNumber)
        {
            return dal.GetArrAmount(purchaseOrderSlipNumber);
        }

    }//end class
}
