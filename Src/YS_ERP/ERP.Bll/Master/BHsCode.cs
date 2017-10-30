using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BHsCode
    {
        IHsCode dal=DALFactory.DataAccess.CreateHsCodeManage();
        public BHsCode()
		{}
	
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string HS_CODE)
		{
			return dal.Exists(HS_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CZZD.ERP.Model.BaseHsCodeTable model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(CZZD.ERP.Model.BaseHsCodeTable model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string HS_CODE)
		{
			
			return dal.Delete(HS_CODE);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public CZZD.ERP.Model.BaseHsCodeTable GetModel(string HS_CODE)
		{
			
			return dal.GetModel(HS_CODE);
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
