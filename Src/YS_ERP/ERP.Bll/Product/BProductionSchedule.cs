using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL.Product;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll.Product
{
    public class BProductionSchedule
    {
        IProductionSchedule dal = DALFactory.DataAccess.CreateProductionScheduleManage();
        public BProductionSchedule()
        {
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

        public String GetMaxActualEndTime(string strWhere)
        {
            return dal.GetMaxActualEndTime(strWhere);
        }
        public DataSet GetProductionScheduleLine(string strWhere)
        {
            return dal.GetProductionScheduleLine(strWhere);
        }
    }
}
