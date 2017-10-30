﻿using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Common;
using System.Data;

namespace CZZD.ERP.SQLServerDAL
{
    public class CustomerManage : ICustomer
    {
        public CustomerManage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_CUSTOMER");
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ExistDelivery(string CUSTOMER_CODE, string DELIVERY_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_DELIVERY");
            strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and DELIVERY_CODE=@DELIVERY_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@DELIVERY_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CUSTOMER_CODE;
            parameters[1].Value = DELIVERY_CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CZZD.ERP.Model.BaseCustomerTable model)
        {
            try
            {
                List<CommandInfo> listSql = new List<CommandInfo>();
                StringBuilder strSql = null;
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_CUSTOMER(");
                strSql.Append("CODE,NAME,NAME_SHORT,NAME_ENGLISH,ZIP_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST,PHONE_NUMBER,FAX_NUMBER,MOBIL_NUMBER,CONTACT_NAME,EMAIL,URL,MEMO,MEMO2,TYPE,CLAIM_FLAG,CLAIM_CODE,CURRENCE_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,NAME_JP,PARENT_CODE,COUNTRY,PARENT_NAME)");
                strSql.Append(" values (");
                strSql.Append("@CODE,@NAME,@NAME_SHORT,@NAME_ENGLISH,@ZIP_CODE,@ADDRESS_FIRST,@ADDRESS_MIDDLE,@ADDRESS_LAST,@PHONE_NUMBER,@FAX_NUMBER,@MOBIL_NUMBER,@CONTACT_NAME,@EMAIL,@URL,@MEMO,@MEMO2,@TYPE,@CLAIM_FLAG,@CLAIM_CODE,@CURRENCE_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE(),@NAME_JP,@PARENT_CODE,@COUNTRY,@PARENT_NAME)");
                SqlParameter[] cParam = {
					    new SqlParameter("@CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					    new SqlParameter("@NAME_SHORT", SqlDbType.NVarChar,50),
					    new SqlParameter("@NAME_ENGLISH", SqlDbType.VarChar,50),
					    new SqlParameter("@ZIP_CODE", SqlDbType.VarChar,8),
					    new SqlParameter("@ADDRESS_FIRST", SqlDbType.NVarChar,100),
					    new SqlParameter("@ADDRESS_MIDDLE", SqlDbType.NVarChar,100),
					    new SqlParameter("@ADDRESS_LAST", SqlDbType.NVarChar,100),
					    new SqlParameter("@PHONE_NUMBER", SqlDbType.VarChar,50),
					    new SqlParameter("@FAX_NUMBER", SqlDbType.VarChar,50),
					    new SqlParameter("@MOBIL_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@CONTACT_NAME", SqlDbType.NVarChar,50),
					    new SqlParameter("@EMAIL", SqlDbType.VarChar,50),
					    new SqlParameter("@URL", SqlDbType.VarChar,50),
					    new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
                        new SqlParameter("@MEMO2", SqlDbType.NVarChar,255),
					    new SqlParameter("@TYPE", SqlDbType.Int,4),
					    new SqlParameter("@CLAIM_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CLAIM_CODE", SqlDbType.VarChar,50),
					    new SqlParameter("@CURRENCE_CODE", SqlDbType.VarChar,50),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,50),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,50),
                        new SqlParameter("@NAME_JP",SqlDbType.NVarChar,100),
                        new SqlParameter("@PARENT_CODE",SqlDbType.NVarChar,100),
                        new SqlParameter("@COUNTRY",SqlDbType.NVarChar,100),
                        new SqlParameter("@PARENT_NAME",SqlDbType.NVarChar,100)
                                        };
                cParam[0].Value = model.CODE;
                cParam[1].Value = model.NAME;
                cParam[2].Value = model.NAME_SHORT;
                cParam[3].Value = model.NAME_ENGLISH;
                cParam[4].Value = model.ZIP_CODE;
                cParam[5].Value = model.ADDRESS_FIRST;
                cParam[6].Value = model.ADDRESS_MIDDLE;
                cParam[7].Value = model.ADDRESS_LAST;
                cParam[8].Value = model.PHONE_NUMBER;
                cParam[9].Value = model.FAX_NUMBER;
                cParam[10].Value = model.MOBIL_NUMBER;
                cParam[11].Value = model.CONTACT_NAME;
                cParam[12].Value = model.EMAIL;
                cParam[13].Value = model.URL;
                cParam[14].Value = model.MEMO;
                cParam[15].Value = model.MEMO2;
                cParam[16].Value = model.TYPE;
                cParam[17].Value = model.CLAIM_FLAG;
                cParam[18].Value = model.CLAIM_CODE;
                cParam[19].Value = model.CURRENCE_CODE;
                cParam[20].Value = CConstant.INIT;
                cParam[21].Value = model.CREATE_USER;
                cParam[22].Value = model.LAST_UPDATE_USER;
                cParam[23].Value = model.NAME_JP;
                cParam[24].Value = model.CODE1;
                cParam[25].Value = model.COUNTRY;
                cParam[26].Value = model.PARENT_NAME;
                listSql.Add(new CommandInfo(strSql.ToString(), cParam));

                string deliverycode = "";
                if (ExistDelivery(model.CODE, "01"))
                {
                    deliverycode = "02";
                }
                else
                {
                    deliverycode = "01";
                }
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_DELIVERY(");
                strSql.Append("CUSTOMER_CODE,DELIVERY_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST,ZIP_CODE,PHONE_NUMBER,FAX_NUMBER,MOBIL_NUMBER,CONTACT_NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                strSql.Append(" values (");
                strSql.Append("@CUSTOMER_CODE,@DELIVERY_CODE,@ADDRESS_FIRST,@ADDRESS_MIDDLE,@ADDRESS_LAST,@ZIP_CODE,@PHONE_NUMBER,@FAX_NUMBER,@MOBIL_NUMBER,@CONTACT_NAME,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                SqlParameter[] dParam = {
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
                dParam[0].Value = model.CODE;
                dParam[1].Value = deliverycode;
                dParam[2].Value = model.ADDRESS_FIRST;
                dParam[3].Value = model.ADDRESS_MIDDLE;
                dParam[4].Value = model.ADDRESS_LAST;
                dParam[5].Value = model.ZIP_CODE;
                dParam[6].Value = model.PHONE_NUMBER;
                dParam[7].Value = model.FAX_NUMBER;
                dParam[8].Value = model.MOBIL_NUMBER;
                dParam[9].Value = model.CONTACT_NAME;
                dParam[10].Value = CConstant.INIT;
                dParam[11].Value = model.CREATE_USER;
                dParam[12].Value = model.LAST_UPDATE_USER;
                // dParam[13].Value = model.NAME_JAPAN;
                listSql.Add(new CommandInfo(strSql.ToString(), dParam));

                int row = DbHelperSQL.ExecuteSqlTran(listSql);
                if (row > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            { }
            return true;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CZZD.ERP.Model.BaseCustomerTable model)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_CUSTOMER set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("NAME_SHORT=@NAME_SHORT,");
            strSql.Append("NAME_ENGLISH=@NAME_ENGLISH,");
            strSql.Append("ZIP_CODE=@ZIP_CODE,");
            strSql.Append("ADDRESS_FIRST=@ADDRESS_FIRST,");
            strSql.Append("ADDRESS_MIDDLE=@ADDRESS_MIDDLE,");
            strSql.Append("ADDRESS_LAST=@ADDRESS_LAST,");
            strSql.Append("PHONE_NUMBER=@PHONE_NUMBER,");
            strSql.Append("FAX_NUMBER=@FAX_NUMBER,");
            strSql.Append("MOBIL_NUMBER=@MOBIL_NUMBER,");
            strSql.Append("CONTACT_NAME=@CONTACT_NAME,");
            strSql.Append("EMAIL=@EMAIL,");
            strSql.Append("URL=@URL,");
            strSql.Append("MEMO=@MEMO,");
            strSql.Append("MEMO2=@MEMO2,");
            strSql.Append("TYPE=@TYPE,");
            strSql.Append("CLAIM_FLAG=@CLAIM_FLAG,");
            strSql.Append("CLAIM_CODE=@CLAIM_CODE,");
            strSql.Append("CURRENCE_CODE=@CURRENCE_CODE,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("NAME_JP=@NAME_JP, ");
            strSql.Append("PARENT_CODE=@PARENT_CODE ,");
            strSql.Append("COUNTRY=@COUNTRY, ");
            strSql.Append("PARENT_NAME=@PARENT_NAME ");
            
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] cParms = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.NVarChar,100),
					new SqlParameter("@NAME_SHORT", SqlDbType.NVarChar,50),
					new SqlParameter("@NAME_ENGLISH", SqlDbType.VarChar,50),
					new SqlParameter("@ZIP_CODE", SqlDbType.VarChar,8),
					new SqlParameter("@ADDRESS_FIRST", SqlDbType.NVarChar,100),
					new SqlParameter("@ADDRESS_MIDDLE", SqlDbType.NVarChar,100),
					new SqlParameter("@ADDRESS_LAST", SqlDbType.NVarChar,100),
					new SqlParameter("@PHONE_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@FAX_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@MOBIL_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@CONTACT_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@EMAIL", SqlDbType.VarChar,50),
					new SqlParameter("@URL", SqlDbType.VarChar,50),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
                    new SqlParameter("@MEMO2", SqlDbType.NVarChar,255),
					new SqlParameter("@TYPE", SqlDbType.Int,4),
					new SqlParameter("@CLAIM_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CLAIM_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CURRENCE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),			
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@NAME_JP",SqlDbType.NVarChar,100),
                    new SqlParameter("@PARENT_CODE",SqlDbType.NVarChar,100),
                    new SqlParameter("@COUNTRY",SqlDbType.NVarChar,100),
                    new SqlParameter("@PARENT_NAME",SqlDbType.NVarChar,100)                };
            cParms[0].Value = model.CODE;
            cParms[1].Value = model.NAME;
            cParms[2].Value = model.NAME_SHORT;
            cParms[3].Value = model.NAME_ENGLISH;
            cParms[4].Value = model.ZIP_CODE;
            cParms[5].Value = model.ADDRESS_FIRST;
            cParms[6].Value = model.ADDRESS_MIDDLE;
            cParms[7].Value = model.ADDRESS_LAST;
            cParms[8].Value = model.PHONE_NUMBER;
            cParms[9].Value = model.FAX_NUMBER;
            cParms[10].Value = model.MOBIL_NUMBER;
            cParms[11].Value = model.CONTACT_NAME;
            cParms[12].Value = model.EMAIL;
            cParms[13].Value = model.URL;
            cParms[14].Value = model.MEMO;
            cParms[15].Value = model.MEMO2;
            cParms[16].Value = model.TYPE;
            cParms[17].Value = model.CLAIM_FLAG;
            cParms[18].Value = model.CLAIM_CODE;
            cParms[19].Value = model.CURRENCE_CODE;
            cParms[20].Value = CConstant.INIT;
            cParms[21].Value = model.LAST_UPDATE_USER;
            cParms[22].Value = model.NAME_JP;
            cParms[23].Value = model.CODE1;
            cParms[24].Value = model.COUNTRY;
            cParms[25].Value = model.PARENT_NAME;
            listSql.Add(new CommandInfo(strSql.ToString(), cParms));

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
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE()");
            strSql.Append(" where CUSTOMER_CODE=@CUSTOMER_CODE and DELIVERY_CODE=@DELIVERY_CODE ");
            SqlParameter[] dParam = {
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
            dParam[0].Value = model.CODE;
            dParam[1].Value = "01";
            dParam[2].Value = model.ADDRESS_FIRST;
            dParam[3].Value = model.ADDRESS_MIDDLE;
            dParam[4].Value = model.ADDRESS_LAST;
            dParam[5].Value = model.ZIP_CODE;
            dParam[6].Value = model.PHONE_NUMBER;
            dParam[7].Value = model.FAX_NUMBER;
            dParam[8].Value = model.MOBIL_NUMBER;
            dParam[9].Value = model.CONTACT_NAME;
            dParam[10].Value = CConstant.INIT;
            dParam[11].Value = model.LAST_UPDATE_USER;
            listSql.Add(new CommandInfo(strSql.ToString(), dParam));

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_CUSTOMER  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

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
        /// 得到一个对象实体
        /// </summary>
        public CZZD.ERP.Model.BaseCustomerTable GetModel(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CODE,NAME,NAME_SHORT,NAME_ENGLISH,ZIP_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST,PHONE_NUMBER,FAX_NUMBER,MOBIL_NUMBER,CONTACT_NAME,EMAIL,URL,MEMO,MEMO2,TYPE,CUSTOMER_TYPE,CLAIM_FLAG,CUSTOMER_CLAIM,CLAIM_CODE,CURRENCE_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,CURRENCE_NAME,NAME_JP,PARENT_CODE,COUNTRY,PARENT_NAME from base_customer_view ");
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            CZZD.ERP.Model.BaseCustomerTable model = new CZZD.ERP.Model.BaseCustomerTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CODE = ds.Tables[0].Rows[0]["CODE"].ToString();
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.NAME_SHORT = ds.Tables[0].Rows[0]["NAME_SHORT"].ToString();
                model.NAME_ENGLISH = ds.Tables[0].Rows[0]["NAME_ENGLISH"].ToString();
                model.ZIP_CODE = ds.Tables[0].Rows[0]["ZIP_CODE"].ToString();
                model.ADDRESS_FIRST = ds.Tables[0].Rows[0]["ADDRESS_FIRST"].ToString();
                model.ADDRESS_MIDDLE = ds.Tables[0].Rows[0]["ADDRESS_MIDDLE"].ToString();
                model.ADDRESS_LAST = ds.Tables[0].Rows[0]["ADDRESS_LAST"].ToString();
                model.PHONE_NUMBER = ds.Tables[0].Rows[0]["PHONE_NUMBER"].ToString();
                model.FAX_NUMBER = ds.Tables[0].Rows[0]["FAX_NUMBER"].ToString();
                model.MOBIL_NUMBER = ds.Tables[0].Rows[0]["MOBIL_NUMBER"].ToString();
                model.CONTACT_NAME = ds.Tables[0].Rows[0]["CONTACT_NAME"].ToString();
                model.EMAIL = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                model.URL = ds.Tables[0].Rows[0]["URL"].ToString();
                model.MEMO = ds.Tables[0].Rows[0]["MEMO"].ToString();
                model.MEMO2 = ds.Tables[0].Rows[0]["MEMO2"].ToString();
                model.NAME_JP = ds.Tables[0].Rows[0]["NAME_JP"].ToString();
                if (ds.Tables[0].Rows[0]["TYPE"].ToString() != "")
                {
                    model.TYPE = int.Parse(ds.Tables[0].Rows[0]["TYPE"].ToString());
                }
                model.CUSTOMER_TYPE = ds.Tables[0].Rows[0]["CUSTOMER_TYPE"].ToString();
                if (ds.Tables[0].Rows[0]["CLAIM_FLAG"].ToString() != "")
                {
                    model.CLAIM_FLAG = int.Parse(ds.Tables[0].Rows[0]["CLAIM_FLAG"].ToString());
                }
                model.CUSTOMER_CLAIM = ds.Tables[0].Rows[0]["CUSTOMER_CLAIM"].ToString();
                model.CLAIM_CODE = ds.Tables[0].Rows[0]["CLAIM_CODE"].ToString();
                model.CURRENCE_CODE = ds.Tables[0].Rows[0]["CURRENCE_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }

                model.CURRENCE_NAME = ds.Tables[0].Rows[0]["CURRENCE_NAME"].ToString();
                model.CODE1 = ds.Tables[0].Rows[0]["PARENT_CODE"].ToString();
                model.COUNTRY = ds.Tables[0].Rows[0]["COUNTRY"].ToString();
                model.PARENT_NAME = ds.Tables[0].Rows[0]["PARENT_NAME"].ToString();
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
            strSql.Append("select CODE,NAME,NAME_SHORT,NAME_ENGLISH,ZIP_CODE,ADDRESS_FIRST,ADDRESS_MIDDLE,ADDRESS_LAST,PHONE_NUMBER,FAX_NUMBER,MOBIL_NUMBER,CONTACT_NAME,EMAIL,URL,MEMO,MEMO2,customer_type,customer_claim,CLAIM_CODE,CURRENCE_CODE,CURRENCE_NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,NAME_JP ,CLAIM_NAME,PARENT_CODE,COUNTRY,PARENT_NAME");
            strSql.Append(" FROM base_customer_view ");
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
            strSql.Append("select count(1) from base_customer_view");
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
            strSql.Append(")AS Row, T.* from base_customer_view T");
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
