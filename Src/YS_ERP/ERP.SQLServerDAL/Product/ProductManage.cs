using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using System.Data;

namespace CZZD.ERP.SQLServerDAL
{
    public class ProductManage : IProduct
    {
        public ProductManage()
        { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PRODUCT");
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ExistSupplierPrice(string SUPPLIER_CODE, string PRODUCT_CODE, string UNIT_CODE, string CURRENCY_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_SUPPLIER_PRICE");
            strSql.Append(" where SUPPLIER_CODE=@SUPPLIER_CODE and PRODUCT_CODE=@PRODUCT_CODE and UNIT_CODE=@UNIT_CODE and CURRENCY_CODE=@CURRENCY_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.NChar,10)};
            parameters[0].Value = SUPPLIER_CODE;
            parameters[1].Value = PRODUCT_CODE;
            parameters[2].Value = UNIT_CODE;
            parameters[3].Value = CURRENCY_CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BaseProductTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            //List<CommandInfo> listSql = new List<CommandInfo>();
            if (Exists(model.CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_PRODUCT set ");
                strSql.Append("NAME=@NAME,");
                strSql.Append("SPEC=@SPEC,");
                strSql.Append("MODEL_NUMBER=@MODEL_NUMBER,");
                strSql.Append("GROUP_CODE=@GROUP_CODE,");
                strSql.Append("BASIC_UNIT_CODE=@BASIC_UNIT_CODE,");
                strSql.Append("ACCOUTING_TARGET=@ACCOUTING_TARGET,");
                strSql.Append("HS_CODE=@HS_CODE,");
                strSql.Append("SALES_PRICE=@SALES_PRICE,");
                strSql.Append("LOCATION_CODE=@LOCATION_CODE,");
                strSql.Append("STOCK_FLAG=@STOCK_FLAG,");
                strSql.Append("PROPERTY_FLAG=@PROPERTY_FLAG,");
                strSql.Append("FROMSET_FLAG=@FROMSET_FLAG,");
                strSql.Append("MECHANICAL_DISTINCTION_FLAG=@MECHANICAL_DISTINCTION_FLAG,");
                strSql.Append("SAFETY_STOCK=@SAFETY_STOCK,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(), ");
                strSql.Append("SELL_LOCATION=@SELL_LOCATION, ");
                strSql.Append("PACKAGE_MODE=@PACKAGE_MODE, ");
                strSql.Append("NAME_JP=@NAME_JP, ");
                strSql.Append("PURCHASE_PRICE=@PURCHASE_PRICE, ");
                strSql.Append("SUPPLIER_CODE=@SUPPLIER_CODE ");
                strSql.Append(" where CODE=@CODE ");
                strSql.Append(" and PRODUCT_FLAG=@PRODUCT_FLAG");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@SPEC", SqlDbType.NVarChar,100),
					new SqlParameter("@MODEL_NUMBER", SqlDbType.NVarChar,100),
					new SqlParameter("@GROUP_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@BASIC_UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ACCOUTING_TARGET", SqlDbType.Int,4),
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@SALES_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@LOCATION_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STOCK_FLAG", SqlDbType.Int,4),
					new SqlParameter("@PROPERTY_FLAG", SqlDbType.Int,4),                    
					new SqlParameter("@FROMSET_FLAG", SqlDbType.Int,4),
					new SqlParameter("@MECHANICAL_DISTINCTION_FLAG", SqlDbType.Int,4),
					new SqlParameter("@SAFETY_STOCK", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@SELL_LOCATION", SqlDbType.Int,4),
                    new SqlParameter("@PACKAGE_MODE", SqlDbType.Int,4),
                    new SqlParameter("@NAME_JP", SqlDbType.NVarChar,100),
                    new SqlParameter("@PURCHASE_PRICE",SqlDbType.Decimal,9),
                    new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20), 
                    new SqlParameter("@PRODUCT_FLAG", SqlDbType.Int,4)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = model.SPEC;
                parameters[3].Value = model.MODEL_NUMBER;
                parameters[4].Value = model.GROUP_CODE;
                parameters[5].Value = model.BASIC_UNIT_CODE;
                parameters[6].Value = model.ACCOUTING_TARGET;
                parameters[7].Value = model.HS_CODE;
                parameters[8].Value = model.SALES_PRICE;
                parameters[9].Value = model.LOCATION_CODE;
                parameters[10].Value = model.STOCK_FLAG;
                parameters[11].Value = model.PROPERTY_FLAG;
                parameters[12].Value = model.FROMSET_FLAG;
                parameters[13].Value = model.MECHANICAL_DISTINCTION_FLAG;
                parameters[14].Value = model.SAFETY_STOCK;
                parameters[15].Value = model.STATUS_FLAG;
                parameters[16].Value = model.CREATE_USER;
                parameters[17].Value = model.LAST_UPDATE_USER;
                parameters[18].Value = model.SELL_LOCATION;
                parameters[19].Value = model.PACKAGE_MODE;
                parameters[20].Value = model.NAME_JP;
                parameters[21].Value = model.PURCHASE_PRICE;
                parameters[22].Value = model.SUPPLIER_CODE;
                parameters[23].Value = model.PRODUCT_FLAG;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_PRODUCT(");
                strSql.Append("CODE,NAME,SPEC,MODEL_NUMBER,GROUP_CODE,BASIC_UNIT_CODE,ACCOUTING_TARGET,HS_CODE,SALES_PRICE,LOCATION_CODE,STOCK_FLAG,PROPERTY_FLAG,FROMSET_FLAG,MECHANICAL_DISTINCTION_FLAG,SAFETY_STOCK,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,SELL_LOCATION,PACKAGE_MODE,NAME_JP,PURCHASE_PRICE,SUPPLIER_CODE,PRODUCT_FLAG)");
                strSql.Append(" values (");
                strSql.Append("@CODE,@NAME,@SPEC,@MODEL_NUMBER,@GROUP_CODE,@BASIC_UNIT_CODE,@ACCOUTING_TARGET,@HS_CODE,@SALES_PRICE,@LOCATION_CODE,@STOCK_FLAG,@PROPERTY_FLAG,@FROMSET_FLAG,@MECHANICAL_DISTINCTION_FLAG,@SAFETY_STOCK,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@SELL_LOCATION,@PACKAGE_MODE,@NAME_JP,@PURCHASE_PRICE,@SUPPLIER_CODE,@PRODUCT_FLAG)");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@SPEC", SqlDbType.NVarChar,100),
					new SqlParameter("@MODEL_NUMBER", SqlDbType.NVarChar,100),
					new SqlParameter("@GROUP_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@BASIC_UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ACCOUTING_TARGET", SqlDbType.Int,4),
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@SALES_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@LOCATION_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STOCK_FLAG", SqlDbType.Int,4),
					new SqlParameter("@PROPERTY_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@FROMSET_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@MECHANICAL_DISTINCTION_FLAG", SqlDbType.Int,4),
					new SqlParameter("@SAFETY_STOCK", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@SELL_LOCATION", SqlDbType.Int,4),
                    new SqlParameter("@PACKAGE_MODE", SqlDbType.Int,4),
                    new SqlParameter("@NAME_JP", SqlDbType.NVarChar,100),
                    new SqlParameter("@PURCHASE_PRICE",SqlDbType.Decimal,9),
                    new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_FLAG", SqlDbType.Int,4)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = model.SPEC;
                parameters[3].Value = model.MODEL_NUMBER;
                parameters[4].Value = model.GROUP_CODE;
                parameters[5].Value = model.BASIC_UNIT_CODE;
                parameters[6].Value = model.ACCOUTING_TARGET;
                parameters[7].Value = model.HS_CODE;
                parameters[8].Value = model.SALES_PRICE;
                parameters[9].Value = model.LOCATION_CODE;
                parameters[10].Value = model.STOCK_FLAG;
                parameters[11].Value = model.PROPERTY_FLAG;
                parameters[12].Value = model.FROMSET_FLAG;
                parameters[13].Value = model.MECHANICAL_DISTINCTION_FLAG;
                parameters[14].Value = model.SAFETY_STOCK;
                parameters[15].Value = CConstant.INIT;
                parameters[16].Value = model.CREATE_USER;
                parameters[17].Value = model.LAST_UPDATE_USER;
                parameters[18].Value = model.SELL_LOCATION;
                parameters[19].Value = model.PACKAGE_MODE;
                parameters[20].Value = model.NAME_JP;
                parameters[21].Value = model.PURCHASE_PRICE;
                parameters[22].Value = model.SUPPLIER_CODE;
                parameters[23].Value = model.PRODUCT_FLAG;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseProductTable model)
        {
            int rows = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_PRODUCT set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("SPEC=@SPEC,");
            strSql.Append("MODEL_NUMBER=@MODEL_NUMBER,");
            strSql.Append("GROUP_CODE=@GROUP_CODE,");
            strSql.Append("BASIC_UNIT_CODE=@BASIC_UNIT_CODE,");
            strSql.Append("ACCOUTING_TARGET=@ACCOUTING_TARGET,");
            strSql.Append("HS_CODE=@HS_CODE,");
            strSql.Append("SALES_PRICE=@SALES_PRICE,");
            strSql.Append("LOCATION_CODE=@LOCATION_CODE,");
            strSql.Append("STOCK_FLAG=@STOCK_FLAG,");
            strSql.Append("PROPERTY_FLAG=@PROPERTY_FLAG,");
            strSql.Append("FROMSET_FLAG=@FROMSET_FLAG,");
            strSql.Append("MECHANICAL_DISTINCTION_FLAG=@MECHANICAL_DISTINCTION_FLAG,");
            strSql.Append("SAFETY_STOCK=@SAFETY_STOCK,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("SELL_LOCATION=@SELL_LOCATION, ");
            strSql.Append("PACKAGE_MODE=@PACKAGE_MODE, ");
            strSql.Append("NAME_JP=@NAME_JP, ");
            strSql.Append("PURCHASE_PRICE=@PURCHASE_PRICE, ");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("SUPPLIER_CODE=@SUPPLIER_CODE");
            strSql.Append(" where CODE=@CODE ");
            strSql.Append(" and PRODUCT_FLAG=@PRODUCT_FLAG");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@SPEC", SqlDbType.NVarChar,100),
					new SqlParameter("@MODEL_NUMBER", SqlDbType.NVarChar,100),
					new SqlParameter("@GROUP_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@BASIC_UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ACCOUTING_TARGET", SqlDbType.Int,4),
					new SqlParameter("@HS_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@SALES_PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@LOCATION_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STOCK_FLAG", SqlDbType.Int,4),
					new SqlParameter("@PROPERTY_FLAG", SqlDbType.Int,4),                    
					new SqlParameter("@FROMSET_FLAG", SqlDbType.Int,4),
					new SqlParameter("@MECHANICAL_DISTINCTION_FLAG", SqlDbType.Int,4),
					new SqlParameter("@SAFETY_STOCK", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@SELL_LOCATION", SqlDbType.Int,4),
                    new SqlParameter("@PACKAGE_MODE", SqlDbType.Int,4),
                    new SqlParameter("@NAME_JP", SqlDbType.NVarChar,100),
                    new SqlParameter("@PURCHASE_PRICE",SqlDbType.Decimal,9),
                    new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_FLAG", SqlDbType.Int,4)};
            parameters[0].Value = model.CODE;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.SPEC;
            parameters[3].Value = model.MODEL_NUMBER;
            parameters[4].Value = model.GROUP_CODE;
            parameters[5].Value = model.BASIC_UNIT_CODE;
            parameters[6].Value = model.ACCOUTING_TARGET;
            parameters[7].Value = model.HS_CODE;
            parameters[8].Value = model.SALES_PRICE;
            parameters[9].Value = model.LOCATION_CODE;
            parameters[10].Value = model.STOCK_FLAG;
            parameters[11].Value = model.PROPERTY_FLAG;
            parameters[12].Value = model.FROMSET_FLAG;
            parameters[13].Value = model.MECHANICAL_DISTINCTION_FLAG;
            parameters[14].Value = model.SAFETY_STOCK;
            parameters[15].Value = model.STATUS_FLAG;
            parameters[16].Value = model.LAST_UPDATE_USER;
            parameters[17].Value = model.SELL_LOCATION;
            parameters[18].Value = model.PACKAGE_MODE;
            parameters[19].Value = model.NAME_JP;
            parameters[20].Value = model.PURCHASE_PRICE;
            parameters[21].Value = model.SUPPLIER_CODE;
            parameters[22].Value = model.PRODUCT_FLAG;

            rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string code)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_PRODUCT  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where CODE=@CODE ");

            SqlParameter[] pParam = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            pParam[0].Value = code;
            listSql.Add(new CommandInfo(strSql.ToString(), pParam));

            strSql = new StringBuilder();
            strSql.Append("delete from BASE_COMPOSITION_PRODUCTS_SPECIFICATION ");
            strSql.Append(" where SPECIFICATION_CODE=@SPECIFICATION_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@SPECIFICATION_CODE", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;
            listSql.Add(new CommandInfo(strSql.ToString(), parameters));

            int rows = DbHelperSQL.ExecuteSqlTran(listSql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseProductTable GetModel(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from base_product_view ");
            strSql.Append(" where CODE=@CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = code;

            BaseProductTable model = new BaseProductTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CODE = ds.Tables[0].Rows[0]["CODE"].ToString();
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.SPEC = ds.Tables[0].Rows[0]["SPEC"].ToString();
                model.MODEL_NUMBER = ds.Tables[0].Rows[0]["MODEL_NUMBER"].ToString();
                model.GROUP_CODE = ds.Tables[0].Rows[0]["GROUP_CODE"].ToString();
                model.GROUP_NAME = ds.Tables[0].Rows[0]["GROUP_NAME"].ToString();
                model.BASIC_UNIT_CODE = ds.Tables[0].Rows[0]["BASIC_UNIT_CODE"].ToString();
                model.BASIC_UNIT_NAME = ds.Tables[0].Rows[0]["UNIT_NAME"].ToString();
                model.NAME_JP = ds.Tables[0].Rows[0]["NAME_JP"].ToString();
                if (ds.Tables[0].Rows[0]["ACCOUTING_TARGET"].ToString() != "")
                {
                    model.ACCOUTING_TARGET = int.Parse(ds.Tables[0].Rows[0]["ACCOUTING_TARGET"].ToString());
                }

                model.HS_CODE = ds.Tables[0].Rows[0]["HS_CODE"].ToString();
                model.HSCODE_NAME = ds.Tables[0].Rows[0]["HSCODE_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["SALES_PRICE"].ToString() != "")
                {
                    model.SALES_PRICE = decimal.Parse(ds.Tables[0].Rows[0]["SALES_PRICE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PURCHASE_PRICE"].ToString() != "")
                {
                    model.PURCHASE_PRICE = decimal.Parse(ds.Tables[0].Rows[0]["PURCHASE_PRICE"].ToString());
                }
                model.LOCATION_CODE = ds.Tables[0].Rows[0]["LOCATION_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["STOCK_FLAG"].ToString() != "")
                {
                    model.STOCK_FLAG = int.Parse(ds.Tables[0].Rows[0]["STOCK_FLAG"].ToString());
                }

                if (ds.Tables[0].Rows[0]["PROPERTY_FLAG"].ToString() != "")
                {
                    model.PROPERTY_FLAG = int.Parse(ds.Tables[0].Rows[0]["PROPERTY_FLAG"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SELL_LOCATION"].ToString() != "")
                {
                    model.SELL_LOCATION = int.Parse(ds.Tables[0].Rows[0]["SELL_LOCATION"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PACKAGE_MODE"].ToString() != "")
                {
                    model.PACKAGE_MODE = int.Parse(ds.Tables[0].Rows[0]["PACKAGE_MODE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FROMSET_FLAG"].ToString() != "")
                {
                    model.FROMSET_FLAG = int.Parse(ds.Tables[0].Rows[0]["FROMSET_FLAG"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MECHANICAL_DISTINCTION_FLAG"].ToString() != "")
                {
                    model.MECHANICAL_DISTINCTION_FLAG = int.Parse(ds.Tables[0].Rows[0]["MECHANICAL_DISTINCTION_FLAG"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                model.LOCATION_NAME = ds.Tables[0].Rows[0]["LOCATION_NAME"].ToString();
                model.GROUP_NAME = ds.Tables[0].Rows[0]["GROUP_NAME"].ToString();
                model.HSCODE_NAME = ds.Tables[0].Rows[0]["HSCODE_NAME"].ToString();
                model.SUPPLIER_CODE = ds.Tables[0].Rows[0]["SUPPLIER_CODE"].ToString();
                model.SUPPLIER_NAME = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                if (ds.Tables[0].Rows[0]["SAFETY_STOCK"].ToString() != "")
                {
                    model.SAFETY_STOCK = CConvert.ToDecimal(ds.Tables[0].Rows[0]["SAFETY_STOCK"]);
                }
                if (ds.Tables[0].Rows[0]["PRODUCT_FLAG"].ToString() != "")
                {
                    model.PRODUCT_FLAG = CConvert.ToInt32(ds.Tables[0].Rows[0]["PRODUCT_FLAG"]);
                }
                model.CREATE_USER_NAME = ds.Tables[0].Rows[0]["CREATE_USER_NAME"].ToString();
                model.LAST_UPDATE_USER_NAME = ds.Tables[0].Rows[0]["LAST_UPDATE_USER_NAME"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM base_product_view ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from base_product_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_product_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }//end class
}
