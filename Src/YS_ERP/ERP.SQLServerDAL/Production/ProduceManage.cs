using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class ProduceManage : IProduce
    {
        #region IProduce 成员

        /// <summary>
        /// 生产物料清单
        /// </summary>
        public DataSet GetBomList(string slipNumbers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select ");
            sb.Append(" x.product_parts_code as code, ");
            sb.Append(" bp.name, ");
            sb.Append(" bp.spec, ");
            sb.Append(" sum(x.totalQantity) as quantity ");
            sb.Append(" from ( ");
            sb.Append(" select  ");
            sb.Append(" oh.slip_number, ");
            sb.Append(" ol.product_code, ");
            sb.Append(" ol.quantity as line_quantity, ");
            sb.Append(" isnull(pp.product_parts_code,ol.product_code) as product_parts_code, ");
            sb.Append(" pp.quantity as part_quantity, ");
            sb.Append(" isnull(ol.quantity,1) * isnull(pp.quantity,1) as totalQantity ");
            sb.Append(" from bll_order_header as oh ");
            sb.Append(" left join dbo.bll_order_line as ol on oh.slip_number = ol.slip_number ");
            sb.Append(" left join dbo.base_product_parts as pp on  ol.product_code = pp.product_code ");
            sb.AppendFormat(" and  pp.status_flag <> {0}", CConstant.DELETE);
            sb.AppendFormat(" where oh.slip_number in ( {0}) ", slipNumbers);
            sb.Append(" ) as x left join base_product as bp on x.product_parts_code = bp.CODE ");
            sb.Append(" group by x.product_parts_code,bp.name,bp.SPEC ");

            return DbHelperSQL.Query(sb.ToString());
        }

        

        #endregion
    }
}
