using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BSlipTypeCompositionProducts
    {
        ISlipTypeCompositionProducts dal = DALFactory.DataAccess.CreateSlipTypeCompositionProductsManage();

        #region 
        public bool Exists(string slipTypeCode, string compositionProductsCode)
		{
            return dal.Exists(slipTypeCode, compositionProductsCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public void Add(BaseSlipTypeCompositionProductsTable model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(BaseSlipTypeCompositionProductsTable model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(string slipTypeCode, string compositionProductsCode)
		{
            return dal.Delete(slipTypeCode, compositionProductsCode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public CZZD.ERP.Model.BaseSlipTypeCompositionProductsTable GetModel(string slipTypeCode, string compositionProductsCode)
		{
            return dal.GetModel(slipTypeCode, compositionProductsCode);
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
		#endregion  Method
    }
}
