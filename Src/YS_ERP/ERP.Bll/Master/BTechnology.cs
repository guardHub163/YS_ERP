﻿using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model.Master;
using CZZD.ERP.IDAL;
using System.Data;

namespace CZZD.ERP.Bll
{
  public   class BTechnology
    {
        ITechnology dal = DALFactory.DataAccess.CreatTechnologyManage();
        public BTechnology()
		{}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CODE)
		{
			return dal.Exists(CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(BaseTechnologyTable model)
		{
            return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(BaseTechnologyTable model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CODE)
		{
			
			return dal.Delete(CODE);
		}
		

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public BaseTechnologyTable GetModel(string CODE)
		{
			
			return dal.GetModel(CODE);
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
