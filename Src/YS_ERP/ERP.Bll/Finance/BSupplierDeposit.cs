using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BSupplierDeposit
    {
        ISupplierDeposit dal = DALFactory.DataAccess.CreateSupplierDepositManage();

        #region　获得当前的最大流水号
        /// <summary>
        /// 获得当前的最大流水号
        /// </summary>
        /// <returns></returns>
        public string GetMaxID()
        {
            return dal.GetMaxID();
        }
        #endregion

        #region　增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BllSupplierDepositTable depositTable)
        {
            return dal.Add(depositTable);
        }
        #endregion

        #region　删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string slipNumber)
        {
            return dal.Delete(slipNumber);
        }
        #endregion

        #region　获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        #endregion

        #region 分页查询
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
        #endregion

        #region 获得预付款总支付，总分配，余额信息
        /// <summary>
        /// 获得预付款总支付，总分配，余额信息
        /// </summary>
        public DataSet GetTotalDeposit(string supplierCode)
        {
            return dal.GetTotalDeposit(supplierCode);
        }
        #endregion
    }//end class
}
