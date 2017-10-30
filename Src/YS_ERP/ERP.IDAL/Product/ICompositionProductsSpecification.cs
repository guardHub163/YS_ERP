using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CZZD.ERP.IDAL
{
    public interface ICompositionProductsProductionProcess
    {

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string compositionProductsCode, string productionProcessCode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(CZZD.ERP.Model.BaseCompositionProductsProductionProcessTable model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(CZZD.ERP.Model.BaseCompositionProductsProductionProcessTable model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string compositionProductsCode, string productionProcessCode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CZZD.ERP.Model.BaseCompositionProductsProductionProcessTable GetModel(string compositionProductsCode, string productionProcessCode);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        int GetRecordCount(string strWhere);

        System.Data.DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex);


        CZZD.ERP.Model.BaseCompositionProductsProductionProcessTable GetOrder(string order);

    }
}
