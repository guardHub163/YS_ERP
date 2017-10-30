using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;

namespace CZZD.ERP.Bll
{
    public class BUser
    {
        IUser dal = DALFactory.DataAccess.CreateUserManage();

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE, string COMPANY_CODE)
        {
            return dal.Exists(CODE, COMPANY_CODE);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BaseUserTable model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseUserTable model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CODE, string COMPANY_CODE)
        {

            return dal.Delete(CODE, COMPANY_CODE);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseUserTable GetModel(string CODE, string COMPANY_CODE)
        {

            return dal.GetModel(CODE, COMPANY_CODE);
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

        public string GetCompany(string name)
        {
            return dal.GetCompany(name);
        }
        public bool UpdateDefault(BaseUserTable model)
        {
            return dal.UpdateDefault(model);
        }
        #endregion

    }//end class
}
