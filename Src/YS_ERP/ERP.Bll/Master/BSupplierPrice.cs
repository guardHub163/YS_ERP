using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.IDAL;
using CZZD.ERP.DALFactory;

namespace CZZD.ERP.Bll
{
    public class BSupplierPrice
    {

        ISupplierPrice dal = DataAccess.CreateSupplierPriceManage();
        public BSupplierPrice()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SUPPLIER_CODE, string PRODUCT_CODE, string UNIT_CODE, string CURRENCY_CODE)
        {
            return dal.Exists(SUPPLIER_CODE, PRODUCT_CODE, UNIT_CODE, CURRENCY_CODE);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CZZD.ERP.Model.BaseSupplierPriceTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CZZD.ERP.Model.BaseSupplierPriceTable model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SUPPLIER_CODE, string PRODUCT_CODE, string UNIT_CODE, string CURRENCY_CODE)
        {

            return dal.Delete(SUPPLIER_CODE, PRODUCT_CODE, UNIT_CODE, CURRENCY_CODE);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CZZD.ERP.Model.BaseSupplierPriceTable GetModel(string SUPPLIER_CODE, string PRODUCT_CODE, string UNIT_CODE, string CURRENCY_CODE)
        {

            return dal.GetModel(SUPPLIER_CODE, PRODUCT_CODE, UNIT_CODE, CURRENCY_CODE);
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
