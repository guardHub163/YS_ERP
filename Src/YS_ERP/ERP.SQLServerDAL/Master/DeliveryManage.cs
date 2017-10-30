using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.Common;
using System.Data;

namespace CZZD.ERP.SQLServerDAL
{
    public class DeliveryManage : IDelivery
    {
        public DeliveryManage()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CUSTOMER_CODE,string DELIVERY_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BASE_DELIVERY");
			strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and DELIVERY_CODE=@DELIVERY_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@DELIVERY_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = CUSTOMER_CODE;
			parameters[1].Value = DELIVERY_CODE;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CZZD.ERP.Model.BaseDeliveryTable model)
		{
            StringBuilder strSql = null;
            int rows = 0;
            if (Exists(model.CUSTOMER_CODE, model.DELIVERY_CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_DELIVERY set ");
                strSql.Append("ADDRESS_FIRST=@ADDRESS_FIRST,");
                strSql.Append("ADDRESS_MIDDLE=@ADDRESS_MIDDLE,");
                strSql.Append("ADDRESS_LAST=@ADDRESS_LAST,");
                strSql.Append("ZIP_CODE=@ZIP_CODE,");
                strSql.Append("PHONE_NUMBER=@PHONE_NUMBER,");
                strSql.Append("FAX_NUMBER=@FAX_NUMBER,");
                strSql.Append("MOBIL_NUMBER=@MOBIL_NUMBER,");
                strSql.Append("CONTACT_NAME=@CONTACT_NAME,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("CREATE_DATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE()");
                strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and DELIVERY_CODE=@DELIVERY_CODE ");
                SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@DELIVERY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ADDRESS_FIRST", SqlDbType.NVarChar,100),
					new SqlParameter("@ADDRESS_MIDDLE", SqlDbType.NVarChar,100),
					new SqlParameter("@ADDRESS_LAST", SqlDbType.NVarChar,100),
					new SqlParameter("@ZIP_CODE", SqlDbType.VarChar,8),
					new SqlParameter("@PHONE_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@FAX_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@MOBIL_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@CONTACT_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CUSTOMER_CODE;
                parameters[1].Value = model.DELIVERY_CODE;
                parameters[2].Value = model.ADDRESS_FIRST;
                parameters[3].Value = model.ADDRESS_MIDDLE;
                parameters[4].Value = model.ADDRESS_LAST;
                parameters[5].Value = model.ZIP_CODE;
                parameters[6].Value = model.PHONE_NUMBER;
                parameters[7].Value = model.FAX_NUMBER;
                parameters[8].Value = model.MOBIL_NUMBER;
                parameters[9].Value = model.CONTACT_NAME;
                parameters[10].Value = model.STATUS_FLAG;
                parameters[11].Value = model.CREATE_USER;
                parameters[12].Value = model.LAST_UPDATE_USER;

                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion 
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_DELIVERY(");
                strSql.Append("CUSTOMER_CODE,DELIVERY_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST,ZIP_CODE,PHONE_NUMBER,FAX_NUMBER,MOBIL_NUMBER,CONTACT_NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@CUSTOMER_CODE,@DELIVERY_CODE,@ADDRESS_FIRST,@ADDRESS_MIDDLE,@ADDRESS_LAST,@ZIP_CODE,@PHONE_NUMBER,@FAX_NUMBER,@MOBIL_NUMBER,@CONTACT_NAME,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@DELIVERY_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@ADDRESS_FIRST", SqlDbType.NVarChar,100),
					new SqlParameter("@ADDRESS_MIDDLE", SqlDbType.NVarChar,100),
					new SqlParameter("@ADDRESS_LAST", SqlDbType.NVarChar,100),
					new SqlParameter("@ZIP_CODE", SqlDbType.VarChar,8),
					new SqlParameter("@PHONE_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@FAX_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@MOBIL_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@CONTACT_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CUSTOMER_CODE;
                parameters[1].Value = model.DELIVERY_CODE;
                parameters[2].Value = model.ADDRESS_FIRST;
                parameters[3].Value = model.ADDRESS_MIDDLE;
                parameters[4].Value = model.ADDRESS_LAST;
                parameters[5].Value = model.ZIP_CODE;
                parameters[6].Value = model.PHONE_NUMBER;
                parameters[7].Value = model.FAX_NUMBER;
                parameters[8].Value = model.MOBIL_NUMBER;
                parameters[9].Value = model.CONTACT_NAME;
                parameters[10].Value = model.STATUS_FLAG;
                parameters[11].Value = model.CREATE_USER;
                parameters[12].Value = model.LAST_UPDATE_USER;

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
		public bool Update(CZZD.ERP.Model.BaseDeliveryTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BASE_DELIVERY set ");
            strSql.Append("ADDRESS_FIRST=@ADDRESS_FIRST,");
            strSql.Append("ADDRESS_MIDDLE=@ADDRESS_MIDDLE,");
            strSql.Append("ADDRESS_LAST=@ADDRESS_LAST,");
			strSql.Append("ZIP_CODE=@ZIP_CODE,");
			strSql.Append("PHONE_NUMBER=@PHONE_NUMBER,");
			strSql.Append("FAX_NUMBER=@FAX_NUMBER,");
			strSql.Append("MOBIL_NUMBER=@MOBIL_NUMBER,");
			strSql.Append("CONTACT_NAME=@CONTACT_NAME,");
			strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
			strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
			strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and DELIVERY_CODE=@DELIVERY_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@DELIVERY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ADDRESS_FIRST", SqlDbType.NVarChar,100),
					new SqlParameter("@ADDRESS_MIDDLE", SqlDbType.NVarChar,100),
					new SqlParameter("@ADDRESS_LAST", SqlDbType.NVarChar,100),
					new SqlParameter("@ZIP_CODE", SqlDbType.VarChar,8),
					new SqlParameter("@PHONE_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@FAX_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@MOBIL_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@CONTACT_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
			parameters[0].Value = model.CUSTOMER_CODE;
			parameters[1].Value = model.DELIVERY_CODE;
            parameters[2].Value = model.ADDRESS_FIRST;
            parameters[3].Value = model.ADDRESS_MIDDLE;
            parameters[4].Value = model.ADDRESS_LAST;
			parameters[5].Value = model.ZIP_CODE;
			parameters[6].Value = model.PHONE_NUMBER;
			parameters[7].Value = model.FAX_NUMBER;
			parameters[8].Value = model.MOBIL_NUMBER;
			parameters[9].Value = model.CONTACT_NAME;
			parameters[10].Value = model.STATUS_FLAG;
			parameters[11].Value = model.LAST_UPDATE_USER;

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
		public bool Delete(string CUSTOMER_CODE,string DELIVERY_CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("update BASE_DELIVERY  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and DELIVERY_CODE=@DELIVERY_CODE ");
			SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@DELIVERY_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = CUSTOMER_CODE;
			parameters[1].Value = DELIVERY_CODE;

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
		public CZZD.ERP.Model.BaseDeliveryTable GetModel(string CUSTOMER_CODE,string DELIVERY_CODE)
		{			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 CUSTOMER_CODE,DELIVERY_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST,ZIP_CODE,PHONE_NUMBER,FAX_NUMBER,MOBIL_NUMBER,CONTACT_NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME from BASE_DELIVERY ");
			strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and DELIVERY_CODE=@DELIVERY_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
			SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@DELIVERY_CODE", SqlDbType.VarChar,50)};
			parameters[0].Value = CUSTOMER_CODE;
			parameters[1].Value = DELIVERY_CODE;

			CZZD.ERP.Model.BaseDeliveryTable model=new CZZD.ERP.Model.BaseDeliveryTable();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.CUSTOMER_CODE=ds.Tables[0].Rows[0]["CUSTOMER_CODE"].ToString();
				model.DELIVERY_CODE=ds.Tables[0].Rows[0]["DELIVERY_CODE"].ToString();
                model.ADDRESS_FIRST = ds.Tables[0].Rows[0]["ADDRESS_FIRST"].ToString();
                model.ADDRESS_MIDDLE = ds.Tables[0].Rows[0]["ADDRESS_MIDDLE"].ToString();
                model.ADDRESS_LAST = ds.Tables[0].Rows[0]["ADDRESS_LAST"].ToString();
				model.ZIP_CODE=ds.Tables[0].Rows[0]["ZIP_CODE"].ToString();
				model.PHONE_NUMBER=ds.Tables[0].Rows[0]["PHONE_NUMBER"].ToString();
				model.FAX_NUMBER=ds.Tables[0].Rows[0]["FAX_NUMBER"].ToString();
				model.MOBIL_NUMBER=ds.Tables[0].Rows[0]["MOBIL_NUMBER"].ToString();
				model.CONTACT_NAME=ds.Tables[0].Rows[0]["CONTACT_NAME"].ToString();
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
            strSql.Append("select CUSTOMER_CODE,CUSTOMER_NAME,DELIVERY_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST,ZIP_CODE,PHONE_NUMBER,FAX_NUMBER,MOBIL_NUMBER,CONTACT_NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME ");
            strSql.Append(" FROM base_delivery_view ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from base_delivery_view");
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
                strSql.Append("order by T.CUSTOMER_CODE asc");
            }
            strSql.Append(")AS Row, T.* from base_delivery_view T");
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
