﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CZZD.ERP.IDAL
{
    /// <summary>
    /// 接口层ICOMPANY 公司信息
    /// </summary>
    public interface ICompany
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string CODE);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(CZZD.ERP.Model.BaseCompanyTable model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(CZZD.ERP.Model.BaseCompanyTable model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string CODE);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CZZD.ERP.Model.BaseCompanyTable GetModel(string CODE);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);

     
        #endregion  成员方法
    }
}
