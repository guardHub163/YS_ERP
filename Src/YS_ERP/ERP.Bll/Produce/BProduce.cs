using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;

namespace CZZD.ERP.Bll
{
    public class BProduce
    {
        IProduce dal = DALFactory.DataAccess.CreateProduceManage();

        /// <summary>
        /// 生产物料清单
        /// </summary>
        public DataSet GetBomList(string slipNumbers)
        {
            return dal.GetBomList(slipNumbers);
        }
    }
}
