using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Model;
using CZZD.ERP.DBUtility;
using System.Data;
using System.Data.SqlClient;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class AlloationManage : IAlloation
    {
        #region IAlloation 成员

        /// <summary>
        ///添加一条数据
        /// </summary>
        public int Add(BllAlloationTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLL_ALLOATION(");
            strSql.Append("ORDER_SLIP_NUMBER,ORDER_LINE_NUMBER,WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,UNIT_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
            strSql.Append(" values (");
            strSql.Append("@ORDER_SLIP_NUMBER,@ORDER_LINE_NUMBER,@WAREHOUSE_CODE,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@ORDER_LINE_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),					
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            parameters[0].Value = model.ORDER_SLIP_NUMBER;
            parameters[1].Value = model.ORDER_LINE_NUMBER;
            parameters[2].Value = model.WAREHOUSE_CODE;
            parameters[3].Value = model.PRODUCT_CODE;
            parameters[4].Value = model.QUANTITY;
            parameters[5].Value = model.UNIT_CODE;
            parameters[6].Value = model.STATUS_FLAG;
            parameters[7].Value = model.CREATE_USER;
            parameters[8].Value = model.LAST_UPDATE_USER;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        ///添加数据
        /// </summary>
        public int Add(List<BllAlloationTable> dataList, int alloationStatus)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();

            try
            {
                #region 原有存在数据的删除
                strSql.Append(" delete from BLL_ALLOATION ");
                strSql.Append(" where ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER");
                strSql.AppendFormat(" and STATUS_FLAG <> {0} and STATUS_FLAG <> {1} ", CConstant.DELETE, CConstant.ALLOATION_SHIPMENT);
                SqlParameter[] param = {
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20)
                    };
                param[0].Value = dataList[0].ORDER_SLIP_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), param));
                #endregion

                #region 引当状态的更改
                strSql = new StringBuilder();
                strSql.Append(" update BLL_ORDER_HEADER set ALLOATION_FLAG=@ALLOATION_FLAG ");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
                SqlParameter[] paramOrder = {
                    new SqlParameter("@ALLOATION_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20)
                    };
                paramOrder[0].Value = alloationStatus;
                paramOrder[1].Value = dataList[0].ORDER_SLIP_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), paramOrder));
                #endregion

                #region　新的数据的保存
                foreach (BllAlloationTable alloation in dataList)
                {
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_ALLOATION(");
                    strSql.Append("ORDER_SLIP_NUMBER,ORDER_LINE_NUMBER,WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,UNIT_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                    strSql.Append(" values (");
                    strSql.Append("@ORDER_SLIP_NUMBER,@ORDER_LINE_NUMBER,@WAREHOUSE_CODE,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                    SqlParameter[] parameters = {
					    new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@ORDER_LINE_NUMBER", SqlDbType.Int,4),
					    new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					    new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),					
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                    parameters[0].Value = alloation.ORDER_SLIP_NUMBER;
                    parameters[1].Value = alloation.ORDER_LINE_NUMBER;
                    parameters[2].Value = alloation.WAREHOUSE_CODE;
                    parameters[3].Value = alloation.PRODUCT_CODE;
                    parameters[4].Value = alloation.QUANTITY;
                    parameters[5].Value = alloation.UNIT_CODE;
                    parameters[6].Value = alloation.STATUS_FLAG;
                    parameters[7].Value = alloation.CREATE_USER;
                    parameters[8].Value = alloation.LAST_UPDATE_USER;

                    listSql.Add(new CommandInfo(strSql.ToString(), parameters));

                }
                #endregion
                return DbHelperSQL.ExecuteSqlTran(listSql);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string slipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BLL_ALLOATION ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.Int,4)
                    };
            parameters[0].Value = slipNumber;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string orderSlipNumber, int orderLineNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BLL_ALLOATION ");
            strSql.Append(" where ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER and ORDER_LINE_NUMBER=@ORDER_LINE_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@ORDER_LINE_NUMBER", SqlDbType.Int,4)
                    };
            parameters[0].Value = orderSlipNumber;
            parameters[1].Value = orderLineNumber;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 删除数据
        /// </summary>
        public bool DeleteByOrderSlipNumber(int orderSlipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BLL_ALLOATION ");
            strSql.Append(" where ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20)
                    };
            parameters[0].Value = orderSlipNumber;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public BllAlloationTable GetModel(string slipNumber)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 引当数量的取得
        /// </summary>
        public decimal GetAlloationQuantity(string warehouseCode, string productCode)
        {
            decimal alloationQuantity = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ISNULL(SUM(QUANTITY),0) FROM BLL_ALLOATION ");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE = @PRODUCT_CODE");
            strSql.AppendFormat(" and STATUS_FLAG <> {0} and STATUS_FLAG <> {1} ", CConstant.DELETE, CConstant.ALLOATION_SHIPMENT);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)
                    };
            parameters[0].Value = warehouseCode;
            parameters[1].Value = productCode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                alloationQuantity = CConvert.ToDecimal(obj);
            }
            return alloationQuantity;
        }

        /// <summary>
        /// 引当数量的取得
        /// </summary>
        public decimal GetAlloationQuantity(string orderSlipNumber, string warehouseCode, string productCode)
        {
            decimal alloationQuantity = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ISNULL(SUM(QUANTITY),0) FROM BLL_ALLOATION ");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE = @PRODUCT_CODE and ORDER_SLIP_NUMBER<>@ORDER_SLIP_NUMBER");
            strSql.AppendFormat(" and STATUS_FLAG <> {0} and STATUS_FLAG <> {1} ", CConstant.DELETE, CConstant.ALLOATION_SHIPMENT);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20)
                    };
            parameters[0].Value = warehouseCode;
            parameters[1].Value = productCode;
            parameters[2].Value = orderSlipNumber;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                alloationQuantity = CConvert.ToDecimal(obj);
            }
            return alloationQuantity;
        }


        /// <summary>
        /// 当前明细己引当的仓库的取得
        /// </summary>
        public BaseWarehouseTable GetAlloationWarehouse(string orderSlipNumber, int orderLineNumber)
        {
            BaseWarehouseTable warehouseTable = new BaseWarehouseTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT BA.WAREHOUSE_CODE,BW.NAME FROM BLL_ALLOATION AS BA");
            strSql.Append(" LEFT JOIN BASE_WAREHOUSE AS BW ON BW.CODE = BA.WAREHOUSE_CODE ");
            strSql.Append(" where BA.ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER and BA.ORDER_LINE_NUMBER = @ORDER_LINE_NUMBER ");
            strSql.AppendFormat(" and BA.STATUS_FLAG <> {0} and BA.STATUS_FLAG <> {1} ", CConstant.DELETE, CConstant.ALLOATION_SHIPMENT);
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@ORDER_LINE_NUMBER", SqlDbType.Int,4)
                    };
            parameters[0].Value = orderSlipNumber;
            parameters[1].Value = orderLineNumber;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    warehouseTable.CODE = dr["WAREHOUSE_CODE"].ToString();
                    warehouseTable.NAME = dr["NAME"].ToString();
                }
            }
            return warehouseTable;
        }

       
        #endregion
    }
}
