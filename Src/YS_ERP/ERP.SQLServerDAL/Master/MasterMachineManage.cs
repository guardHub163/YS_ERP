using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using System.Data;
using CZZD.ERP.Common;
using CZZD.ERP.IDAL;

namespace CZZD.ERP.SQLServerDAL
{
    public class MasterMachineManage:IMasterMachine
    {
        public MasterMachineManage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MACHINE_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_MASTER_MACHINE");
			strSql.Append(" where MACHINE_CODE=@MACHINE_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@MACHINE_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = MACHINE_CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CZZD.ERP.Model.BaseMasterMachineTable model)
		{
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.MACHINE_CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_MASTER_MACHINE set ");
                strSql.Append("CUSTOMER_CODE=@CUSTOMER_CODE,");
                strSql.Append("PRODUCT_CODE=@PRODUCT_CODE,");
                strSql.Append("MAINTENANCE_STATIONS=@MAINTENANCE_STATIONS,");
                strSql.Append("PURCHASE_ORDER_SLIP_NUMBER=@PURCHASE_ORDER_SLIP_NUMBER,");
                strSql.Append("FANUC_SERIAL_NUMBER=@FANUC_SERIAL_NUMBER,");
                strSql.Append("FANUC_SLIP_NUMBER=@FANUC_SLIP_NUMBER,");
                strSql.Append("RECEIPT_DATE=@RECEIPT_DATE,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("MACHINE_NAME=@MACHINE_NAME,");
                strSql.Append("PURCHASE_SLIP_NUMBER=@PURCHASE_SLIP_NUMBER,");
                strSql.Append("SALE_DATE_TIME=@SALE_DATE_TIME,");
                strSql.Append(" where MACHINE_CODE=@MACHINE_CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@MACHINE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@MAINTENANCE_STATIONS", SqlDbType.VarChar,50),
                    new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@FANUC_SERIAL_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@FANUC_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@RECEIPT_DATE", SqlDbType.DateTime),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@MACHINE_NAME", SqlDbType.VarChar,100),
                    new SqlParameter("@PURCHASE_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@SALE_DATE_TIME",SqlDbType.DateTime)};
                parameters[0].Value = model.MACHINE_CODE;
                parameters[1].Value = model.CUSTOMER_CODE;
                parameters[2].Value = model.PRODUCT_CODE;
                parameters[3].Value = model.MAINTENANCE_STATIONS;
                parameters[4].Value = model.PURCHASE_ORDER_SLIP_NUMBER;
                parameters[5].Value = model.FANUC_SERIAL_NUMBER;
                parameters[6].Value = model.FANUC_SLIP_NUMBER;
                parameters[7].Value = model.RECEIPT_DATE;
                parameters[8].Value = model.STATUS_FLAG;
                parameters[9].Value = model.CREATE_USER;
                parameters[10].Value = model.LAST_UPDATE_USER;
                parameters[11].Value = model.MACHINE_NAME;
                parameters[12].Value = model.PURCHASE_SLIP_NUMBER;
                parameters[13].Value = model.SALE_DATE_TIME;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_MASTER_MACHINE(");
                strSql.Append("MACHINE_CODE,CUSTOMER_CODE,PRODUCT_CODE,MAINTENANCE_STATIONS,PURCHASE_ORDER_SLIP_NUMBER, FANUC_SERIAL_NUMBER, FANUC_SLIP_NUMBER, RECEIPT_DATE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,MACHINE_NAME,PURCHASE_SLIP_NUMBER,SALE_DATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@MACHINE_CODE,@CUSTOMER_CODE,@PRODUCT_CODE,@MAINTENANCE_STATIONS,@PURCHASE_ORDER_SLIP_NUMBER, @FANUC_SERIAL_NUMBER, @FANUC_SLIP_NUMBER, @RECEIPT_DATE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE(),@MACHINE_NAME,@PURCHASE_SLIP_NUMBER,@SALE_DATE_TIME)");
                SqlParameter[] parameters = {
					new SqlParameter("@MACHINE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@MAINTENANCE_STATIONS", SqlDbType.VarChar,50),
                    new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@FANUC_SERIAL_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@FANUC_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@RECEIPT_DATE", SqlDbType.DateTime),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@MACHINE_NAME", SqlDbType.VarChar,100),
                    new SqlParameter("@PURCHASE_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@SALE_DATE_TIME",SqlDbType.DateTime)};
                parameters[0].Value = model.MACHINE_CODE;
                parameters[1].Value = model.CUSTOMER_CODE;
                parameters[2].Value = model.PRODUCT_CODE;
                parameters[3].Value = model.MAINTENANCE_STATIONS;
                parameters[4].Value = model.PURCHASE_ORDER_SLIP_NUMBER;
                parameters[5].Value = model.FANUC_SERIAL_NUMBER;
                parameters[6].Value = model.FANUC_SLIP_NUMBER;
                parameters[7].Value = model.RECEIPT_DATE;
                parameters[8].Value = model.STATUS_FLAG;
                parameters[9].Value = model.CREATE_USER;
                parameters[10].Value = model.LAST_UPDATE_USER;
                parameters[11].Value = model.MACHINE_NAME;
                parameters[12].Value = model.PURCHASE_SLIP_NUMBER;
                parameters[13].Value = model.SALE_DATE_TIME;
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
		public bool Update(CZZD.ERP.Model.BaseMasterMachineTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_MASTER_MACHINE set ");
			strSql.Append("CUSTOMER_CODE=@CUSTOMER_CODE,");
			strSql.Append("PRODUCT_CODE=@PRODUCT_CODE,");
			strSql.Append("MAINTENANCE_STATIONS=@MAINTENANCE_STATIONS,");
            strSql.Append("PURCHASE_ORDER_SLIP_NUMBER=@PURCHASE_ORDER_SLIP_NUMBER,");
            strSql.Append("FANUC_SERIAL_NUMBER=@FANUC_SERIAL_NUMBER,");
            strSql.Append("FANUC_SLIP_NUMBER=@FANUC_SLIP_NUMBER,");
            strSql.Append("RECEIPT_DATE=@RECEIPT_DATE,");
			strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
			strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("MACHINE_NAME=@MACHINE_NAME, ");
            strSql.Append("PURCHASE_SLIP_NUMBER=@PURCHASE_SLIP_NUMBER,");
            strSql.Append("SALE_DATE_TIME=@SALE_DATE_TIME ");
			strSql.Append(" where MACHINE_CODE=@MACHINE_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@MACHINE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@MAINTENANCE_STATIONS", SqlDbType.VarChar,50),
                    new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@FANUC_SERIAL_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@FANUC_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@RECEIPT_DATE", SqlDbType.DateTime),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@MACHINE_NAME", SqlDbType.VarChar,100),
                    new SqlParameter("@PURCHASE_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@SALE_DATE_TIME",SqlDbType.DateTime)};
			parameters[0].Value = model.MACHINE_CODE;
			parameters[1].Value = model.CUSTOMER_CODE;
			parameters[2].Value = model.PRODUCT_CODE;
			parameters[3].Value = model.MAINTENANCE_STATIONS;
            parameters[4].Value = model.PURCHASE_ORDER_SLIP_NUMBER;
            parameters[5].Value = model.FANUC_SERIAL_NUMBER;
            parameters[6].Value = model.FANUC_SLIP_NUMBER;
            parameters[7].Value = model.RECEIPT_DATE;
			parameters[8].Value = model.STATUS_FLAG;
			parameters[9].Value = model.LAST_UPDATE_USER;
            parameters[10].Value = model.MACHINE_NAME;
            parameters[11].Value = model.PURCHASE_SLIP_NUMBER;
            parameters[12].Value = model.SALE_DATE_TIME;
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string MACHINE_CODE)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("update BASE_MASTER_MACHINE  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where MACHINE_CODE=@MACHINE_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@MACHINE_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = MACHINE_CODE;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public CZZD.ERP.Model.BaseMasterMachineTable GetModel(string MACHINE_CODE)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 MACHINE_CODE,CUSTOMER_CODE,PRODUCT_CODE,MAINTENANCE_STATIONS,PURCHASE_ORDER_SLIP_NUMBER, FANUC_SERIAL_NUMBER, FANUC_SLIP_NUMBER, RECEIPT_DATE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,MACHINE_NAME,PURCHASE_SLIP_NUMBER ,SALE_DATE_TIME from BASE_MASTER_MACHINE ");
			strSql.Append(" where MACHINE_CODE=@MACHINE_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
			SqlParameter[] parameters = {
					new SqlParameter("@MACHINE_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = MACHINE_CODE;

			CZZD.ERP.Model.BaseMasterMachineTable model=new CZZD.ERP.Model.BaseMasterMachineTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.MACHINE_CODE=ds.Tables[0].Rows[0]["MACHINE_CODE"].ToString();
				model.CUSTOMER_CODE=ds.Tables[0].Rows[0]["CUSTOMER_CODE"].ToString();
				model.PRODUCT_CODE=ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
				model.MAINTENANCE_STATIONS=ds.Tables[0].Rows[0]["MAINTENANCE_STATIONS"].ToString();
                model.PURCHASE_ORDER_SLIP_NUMBER = ds.Tables[0].Rows[0]["PURCHASE_ORDER_SLIP_NUMBER"].ToString();
                model.FANUC_SERIAL_NUMBER = ds.Tables[0].Rows[0]["FANUC_SERIAL_NUMBER"].ToString();
                model.FANUC_SLIP_NUMBER = ds.Tables[0].Rows[0]["FANUC_SLIP_NUMBER"].ToString();
                model.PURCHASE_SLIP_NUMBER = ds.Tables[0].Rows[0]["PURCHASE_SLIP_NUMBER"].ToString();
                if (ds.Tables[0].Rows[0]["RECEIPT_DATE"].ToString() != "")
                {
                    model.RECEIPT_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["RECEIPT_DATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SALE_DATE_TIME"].ToString() != "") 
                {
                    model.SALE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["SALE_DATE_TIME"].ToString());
                }
				if(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString()!="")
				{
					model.STATUS_FLAG=int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
				}
				model.CREATE_USER=ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
				if(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString()!="")
				{
					model.CREATE_DATE_TIME=DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
				}
				model.LAST_UPDATE_USER=ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
				if(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString()!="")
				{
					model.LAST_UPDATE_TIME=DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
				}
                model.MACHINE_NAME = ds.Tables[0].Rows[0]["MACHINE_NAME"].ToString();
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select MACHINE_CODE,MACHINE_NAME,CUSTOMER_CODE,CUSTOMER_NAME,PRODUCT_CODE,PRODUCT_NAME,STATIONS,PURCHASE_ORDER_SLIP_NUMBER, FANUC_SERIAL_NUMBER, FANUC_SLIP_NUMBER, RECEIPT_DATE,STATUS_FLAG,CREATE_NAME,CREATE_DATE_TIME,LAST_UPDATE_NAME,LAST_UPDATE_TIME,PURCHASE_SLIP_NUMBER ,SALE_DATE_TIME");
            strSql.Append(" FROM base_master_machine_view ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from base_master_machine_view");
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
                strSql.Append("order by T.MACHINE_CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_master_machine_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

		#endregion  Method
    }
}
