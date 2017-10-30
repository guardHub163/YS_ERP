using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BExchange
    {
        IExchange dal = DALFactory.DataAccess.CreatExchangeManage();
        public BExchange()
		{}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(DateTime EXCHANGE_DATE, string FROM_CURRENCY_CODE)
		{
			return dal.Exists(EXCHANGE_DATE, FROM_CURRENCY_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(BaseExchangeTable model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public int Update(BaseExchangeTable model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(DateTime EXCHANGE_DATE, string FROM_CURRENCY_CODE)
		{
			
			return dal.Delete(EXCHANGE_DATE,FROM_CURRENCY_CODE);
		}
		

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public BaseExchangeTable GetModel(DateTime EXCHANGE_DATE, string FROM_CURRENCY_CODE)
		{			
			return dal.GetModel(EXCHANGE_DATE, FROM_CURRENCY_CODE);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
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

        public DataSet GetExchangeFromTime(DateTime fromTime, string FromCurrencyCode, string ToCurrencyCode) 
        {
            return dal.GetExchangeFromTime(fromTime, FromCurrencyCode, ToCurrencyCode);
        }
		
    }
}
