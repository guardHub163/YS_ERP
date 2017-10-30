using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BLocation
    {
        ILocation dal = DALFactory.DataAccess.CreateLocationManage();
        public BLocation()
		{}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE) 
        {
            return dal.Exists(CODE);
        }
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CODE,string PRODUCT_CODE, string WAREHOUSE_CODE)
		{
			return dal.Exists(CODE,PRODUCT_CODE,WAREHOUSE_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(BaseLocationTable model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(BaseLocationTable model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CODE,string PRODUCT_CODE, string WAREHOUSE_CODE)
		{
			
			return dal.Delete(CODE,PRODUCT_CODE,WAREHOUSE_CODE);
		}
		

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public BaseLocationTable GetModel(string CODE,string PRODUCT_CODE, string WAREHOUSE_CODE)
		{
			
			return dal.GetModel(CODE,PRODUCT_CODE,WAREHOUSE_CODE);
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
		
    }
}
