using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL.Master;
using System.Data;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
   public class MaterialManage:IMaterial
    {
       public MaterialManage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_MATERIAL");
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ExistDelivery(string CUSTOMER_CODE,string DELIVERY_CODE)
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
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = null;
            strSql = new StringBuilder();
            strSql.Append("insert into BASE_MATERIAL(");
            strSql.Append("CODE,NAME,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,MEMO1,MEMO2,MEMO3)");
            strSql.Append(" values (");
            strSql.Append("@CODE,@NAME,@COMPANY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE(),@MEMO1,@MEMO2,@MEMO3)");
            SqlParameter[] cParam = {
					    new SqlParameter("@CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@NAME", SqlDbType.VarChar,100),
					    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@STATUS_FLAG", SqlDbType.Int),				
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),					 
                        new SqlParameter("@LAST_UPDATE_USER",SqlDbType.NVarChar,20),                    
					    new SqlParameter("@MEMO1", SqlDbType.VarChar,20),
					    new SqlParameter("@MEMO2", SqlDbType.VarChar,20),
                        new SqlParameter("@MEMO3",SqlDbType.VarChar,20)};
            cParam[0].Value = model.CODE;
            cParam[1].Value = model.NAME;
            cParam[2].Value = "常州市羊氏模具有限公司";
            cParam[3].Value = 1;
            cParam[4].Value = model.CREATE_USER;
            cParam[5].Value = model.LAST_UPDATE_USER;
            cParam[6].Value = "";
            cParam[7].Value = "";
            cParam[8].Value = "";

            listSql.Add(new CommandInfo(strSql.ToString(), cParam));
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
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CZZD.ERP.Model.BaseCustomerTable model)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_MATERIAL set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("CREATE_USER=@CREATE_USER,");        
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("MEMO1=@MEMO1,");
            strSql.Append("MEMO2=@MEMO2,");
            strSql.Append("MEMO3=@MEMO3 ");            
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] cParms = {
					    new SqlParameter("@CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@NAME", SqlDbType.VarChar,100),
					    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@STATUS_FLAG", SqlDbType.Int),				
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),					 
                        new SqlParameter("@LAST_UPDATE_USER",SqlDbType.NVarChar,20),                    
					    new SqlParameter("@MEMO1", SqlDbType.VarChar,20),
					    new SqlParameter("@MEMO2", SqlDbType.VarChar,20),
                        new SqlParameter("@MEMO3",SqlDbType.VarChar,20)};
            cParms[0].Value = model.CODE;
            cParms[1].Value = model.NAME;
            cParms[2].Value = "常州市羊氏模具有限公司";
            cParms[3].Value = 1;
            cParms[4].Value = model.CREATE_USER;
            cParms[5].Value = model.LAST_UPDATE_USER;
            cParms[6].Value = "";
            cParms[7].Value = "";
            cParms[8].Value = "";
            listSql.Add(new CommandInfo(strSql.ToString(), cParms));          
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
            strSql.AppendFormat("update BASE_MATERIAL  set STATUS_FLAG = {0}", CConstant.DELETE);
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
            strSql.Append("select  top 1 CODE,NAME,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,MEMO1,MEMO2,MEMO3 from base_material_view ");
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
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
               // model.LAST_UPDATE_TIME = ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString();
             
                //model.MEMO = ds.Tables[0].Rows[0]["MEMO"].ToString();
                //model.MEMO2 = ds.Tables[0].Rows[0]["MEMO2"].ToString();
               
                //if (ds.Tables[0].Rows[0]["TYPE"].ToString() != "")
                //{
                //    model.TYPE = int.Parse(ds.Tables[0].Rows[0]["TYPE"].ToString());
                //}
                //model.CUSTOMER_TYPE = ds.Tables[0].Rows[0]["CUSTOMER_TYPE"].ToString();
                //if (ds.Tables[0].Rows[0]["CLAIM_FLAG"].ToString() != "")
                //{
                //    model.CLAIM_FLAG = int.Parse(ds.Tables[0].Rows[0]["CLAIM_FLAG"].ToString());
                //}
                //model.CUSTOMER_CLAIM = ds.Tables[0].Rows[0]["CUSTOMER_CLAIM"].ToString();
                //model.CLAIM_CODE = ds.Tables[0].Rows[0]["CLAIM_CODE"].ToString();
                //model.CURRENCE_CODE = ds.Tables[0].Rows[0]["CURRENCE_CODE"].ToString();
                //if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                //{
                //    model.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                //}
                //model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                //if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                //{
                //    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                //}
                //model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                //if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                //{
                //    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                //}

                //model.CURRENCE_NAME = ds.Tables[0].Rows[0]["CURRENCE_NAME"].ToString();

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
            strSql.Append("select CODE,NAME,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,MEMO1,MEMO2,MEMO3");
            strSql.Append(" FROM base_material_view ");
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
            strSql.Append("select count(1) from base_material_view");
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
            strSql.Append(")AS Row, T.* from base_material_view T");
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
