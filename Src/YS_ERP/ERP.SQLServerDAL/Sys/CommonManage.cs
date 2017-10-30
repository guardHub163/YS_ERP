using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data.SqlClient;
using System.Data;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Common;
using CZZD.ERP.Model;

namespace CZZD.ERP.SQLServerDAL
{
    public class CommonManage : ICommon
    {
        #region 数据连接的测试

        /// <summary>
        /// 数据连接的测试
        /// </summary>
        public bool IsDBConn(string strconn, string strsql)
        {
            int rInt = 0;
            using (SqlConnection Conn = new SqlConnection(strconn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(strsql, Conn);
                    cmd.CommandType = CommandType.Text;
                    Conn.Open();
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                    Conn.Dispose();
                    Conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 流水编号的取得

        /// <summary>
        /// 流水编号的取得
        /// </summary>
        public string GetSeqNumber(string blltype)
        {
            string result = string.Empty;
            SqlParameter[] parames = {                                      
                                       new SqlParameter("@P_Bll_Type",SqlDbType.NVarChar),
                                       new SqlParameter("@P_Out_New_Bll_No", SqlDbType.NVarChar)
                                       };
            parames[0].Value = blltype;
            parames[1].Value = "";
            parames[1].Direction = ParameterDirection.Output;
            result = DbHelperSQL.RunProcedureScalarStr("SP_GetSeq", parames);
            return result;
        }

        /// <summary>
        /// 流水编号的取得 后台直接使用　静态方法
        /// </summary>
        public static string GetSeq(string blltype)
        {
            string result = string.Empty;
            SqlParameter[] parames = {                                      
                                       new SqlParameter("@P_Bll_Type",SqlDbType.NVarChar),
                                       new SqlParameter("@P_Out_New_Bll_No", SqlDbType.NVarChar)
                                       };
            parames[0].Value = blltype;
            parames[1].Value = "";
            parames[1].Direction = ParameterDirection.Output;
            result = DbHelperSQL.RunProcedureScalarStr("SP_GetSeq", parames);
            return result;
        }

        /// <summary>
        /// 流水编号的更新
        /// </summary>
        /// <returns></returns>
        public static CommandInfo GetSeqUpDateSql(string bllType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Seq set SEQ= SEQ + 1 WHERE BLL_TYPE = @BLL_TYPE");
            SqlParameter[] SeqParam = { 
                                new SqlParameter("@BLL_TYPE", SqlDbType.VarChar,10) };
            SeqParam[0].Value = bllType;
            return new CommandInfo(strSql.ToString(), SeqParam);
        }
        #endregion

        #region 基础数据的处理
        /// <summary>
        /// 文本入力框CHANGE事件查询方法
        /// </summary>
        public BaseMaster GetBaseMaster(string tableName, string code)
        {
            StringBuilder strSql = new StringBuilder();
            if ("DELIVERY".Equals(tableName))
            {
                strSql.AppendFormat(" select DELIVERY_CODE AS CODE ,ADDRESS_FIRST + ADDRESS_MIDDLE + ADDRESS_LAST AS NAME from BASE_{0} ", tableName);
                strSql.AppendFormat(" where DELIVERY_CODE=@CODE and STATUS_FLAG <> {0} ", CConstant.DELETE);
            }
            else
            {
                strSql.AppendFormat(" select CODE ,NAME from BASE_{0} ", tableName);
                strSql.AppendFormat(" where CODE=@CODE and STATUS_FLAG <> {0} ", CConstant.DELETE);
            }
            SqlParameter[] parameters = {
					    new SqlParameter("@CODE", SqlDbType.VarChar)};
            parameters[0].Value = code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            BaseMaster model = new BaseMaster();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CODE"] != null && ds.Tables[0].Rows[0]["CODE"].ToString() != "")
                {
                    model.Code = ds.Tables[0].Rows[0]["CODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NAME"] != null && ds.Tables[0].Rows[0]["NAME"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["NAME"].ToString();
                }
            }
            else
            {
                return null;
            }
            return model;
        }

        /// <summary>
        /// 文本入力框CHANGE事件查询方法
        /// </summary>
        public BaseMaster GetBaseMaster(string tableName, string code, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            if ("DELIVERY".Equals(tableName))//tableName为delivery时,code为地址编号, 客户编号的条件在strWhere中
            {
                strSql.AppendFormat(" select top 1 DELIVERY_CODE AS CODE,ADDRESS_FIRST + ADDRESS_MIDDLE + ADDRESS_LAST AS NAME from BASE_{0} ", tableName);
                strSql.AppendFormat(" where DELIVERY_CODE=@CODE and STATUS_FLAG <> {0} ", CConstant.DELETE);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
            }
            else if ("PRODUCT".Equals(tableName))
            {
                strSql.Append(" select CODE ,NAME from base_product_view ");
                strSql.AppendFormat(" where CODE=@CODE and STATUS_FLAG <> {0} ", CConstant.DELETE);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
            }
            else if ("SLIP_TYPE_COMPOSITION_PRODUCTS_VIEW".Equals(tableName))
            {
                strSql.Append("SELECT COMPOSITION_PRODUCTS_CODE as CODE,COMPOSITION_PRODUCTS_NAME as NAME FROM ( ");
                strSql.Append(" SELECT ROW_NUMBER() OVER ( order by T.COMPOSITION_PRODUCTS_CODE )");
                strSql.Append(" AS Row, T.* from base_slip_type_composition_products_view T");
                strSql.AppendFormat(" where COMPOSITION_PRODUCTS_CODE = @CODE ", CConstant.DELETE);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" ) tt");
            }
            else
            {
                strSql.AppendFormat(" select CODE ,NAME from BASE_{0} ", tableName);
                strSql.AppendFormat(" where CODE=@CODE and STATUS_FLAG <> {0} ", CConstant.DELETE);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
            }
            SqlParameter[] parameters = {
					    new SqlParameter("@CODE", SqlDbType.VarChar)};
            parameters[0].Value = code;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            BaseMaster model = new BaseMaster();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CODE"] != null && ds.Tables[0].Rows[0]["CODE"].ToString() != "")
                {
                    model.Code = ds.Tables[0].Rows[0]["CODE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["NAME"] != null && ds.Tables[0].Rows[0]["NAME"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["NAME"].ToString();
                }
            }
            else
            {
                return null;
            }
            return model;
        }

        /// <summary>
        /// 基础数据查询共通方法，查询小页面，总计录数的统计
        /// </summary>
        public int GetMasterRecordCount(string tableName, string code, string name, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //当表为DELIVERY时，code为客户编号，name为地址编号查询出DELIVERY信息
            if ("DELIVERY".Equals(tableName))
            {
                strSql.AppendFormat("select count(1) from BASE_{0} ", tableName);
                strSql.AppendFormat(" where CUSTOMER_CODE like @CODE and DELIVERY_CODE like @NAME and  STATUS_FLAG <> {0}", CConstant.DELETE);
            }
            else if ("PRODUCT".Equals(tableName))
            {
                strSql.Append("select count(1) from base_product_view");
                strSql.AppendFormat(" where CODE like @CODE and NAME like @NAME and  STATUS_FLAG <> {0}", CConstant.DELETE);
            }
            else if ("SLIP_TYPE_COMPOSITION_PRODUCTS_VIEW".Equals(tableName))
            {
                strSql.Append("select count(1) from base_slip_type_composition_products_view");
                strSql.AppendFormat(" where COMPOSITION_PRODUCTS_CODE like @CODE and COMPOSITION_PRODUCTS_NAME like @NAME ", CConstant.DELETE);
            }
            else
            {
                strSql.AppendFormat("select count(1) from BASE_{0} ", tableName);
                strSql.AppendFormat(" where CODE like @CODE and NAME like @NAME and  STATUS_FLAG <> {0}", CConstant.DELETE);
            }
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            SqlParameter[] parames = {
                        new SqlParameter("@CODE", SqlDbType.VarChar),
					    new SqlParameter("@NAME", SqlDbType.VarChar)};
            parames[0].Value = "%" + code + "%";
            parames[1].Value = "%" + name + "%";
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parames);
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
        /// 基础数据查询共通方法，查询小页面，分面查询
        /// </summary>
        public DataSet GetMasterDataList(string tableName, string code, string name, string strWhere, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            //当表为DELIVERY时，code为客户编号，name为地址编号查询出DELIVERY信息
            if ("DELIVERY".Equals(tableName))
            {
                strSql.Append("SELECT  DELIVERY_CODE AS CODE,ADDRESS_FIRST + ADDRESS_MIDDLE + ADDRESS_LAST AS NAME, CUSTOMER_CODE FROM ( ");
                strSql.Append(" SELECT ROW_NUMBER() OVER ( order by T.CUSTOMER_CODE )");
                strSql.AppendFormat(" AS Row, T.* from BASE_{0} T", tableName);
                strSql.AppendFormat(" where CUSTOMER_CODE like @CODE and DELIVERY_CODE like @NAME and  STATUS_FLAG <> {0}", CConstant.DELETE);
            }
            else if ("PRODUCT".Equals(tableName))
            {
                strSql.Append("SELECT * FROM ( ");
                strSql.Append(" SELECT ROW_NUMBER() OVER ( order by T.CODE )");
                strSql.Append(" AS Row, T.* from base_product_view T");
                strSql.AppendFormat(" where CODE like @CODE and NAME like @NAME and  STATUS_FLAG <> {0}", CConstant.DELETE);
            }
            else if ("SLIP_TYPE_COMPOSITION_PRODUCTS_VIEW".Equals(tableName))
            {
                strSql.Append("SELECT COMPOSITION_PRODUCTS_CODE as CODE,COMPOSITION_PRODUCTS_NAME as NAME FROM ( ");
                strSql.Append(" SELECT ROW_NUMBER() OVER ( order by T.COMPOSITION_PRODUCTS_CODE )");
                strSql.Append(" AS Row, T.* from base_slip_type_composition_products_view T");
                strSql.AppendFormat(" where COMPOSITION_PRODUCTS_CODE like @CODE and COMPOSITION_PRODUCTS_NAME like @NAME ", CConstant.DELETE);
            }
            else
            {
                strSql.Append("SELECT * FROM ( ");
                strSql.Append(" SELECT ROW_NUMBER() OVER ( order by T.CODE )");
                strSql.AppendFormat(" AS Row, T.* from BASE_{0} T", tableName);
                strSql.AppendFormat(" where CODE like @CODE and NAME like @NAME and  STATUS_FLAG <> {0}", CConstant.DELETE);
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parames = {
                        new SqlParameter("@CODE", SqlDbType.VarChar),
					    new SqlParameter("@NAME", SqlDbType.VarChar)};
            parames[0].Value = "%" + code + "%";
            parames[1].Value = "%" + name + "%";
            return DbHelperSQL.Query(strSql.ToString(), parames);
        }

        /// <summary>
        /// 基础数据查询共通方法，查询小页面，所有数据的取得
        /// </summary>
        public DataSet GetMasterList(string tableName, string code, string name, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat(" select CODE ,NAME from BASE_{0} ", tableName);
            //当表为DELIVERY时，code为客户编号，name为地址编号查询出DELIVERY信息
            if ("DELIVERY".Equals(tableName))
            {
                strSql.AppendFormat("SELECT DELIVERY_CODE AS CODE,ADDRESS_FIRST + ADDRESS_MIDDLE + ADDRESS_LAST AS NAME, CUSTOMER_CODE FROM BASE_{0}", tableName);
                strSql.AppendFormat(" where CUSTOMER_CODE like @CODE and DELIVERY_CODE like @NAME and  STATUS_FLAG <> {0}", CConstant.DELETE);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by CUSTOMER_CODE");
            }
            else if (tableName == "NAMES")
            {
                strSql.AppendFormat(" select * from {0} ", tableName);
                strSql.AppendFormat(" where CODE LIKE @CODE and NAME LIKE @NAME and STATUS_FLAG <> {0}", CConstant.DELETE);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by CODE");
            }
            else if ("PRODUCT".Equals(tableName))
            {
                strSql.Append(" select * from base_product_view ");
                strSql.AppendFormat(" where CODE LIKE @CODE and NAME LIKE @NAME and STATUS_FLAG <> {0}", CConstant.DELETE);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by CODE");
            }
            else if ("SLIP_TYPE_COMPOSITION_PRODUCTS_VIEW".Equals(tableName))
            {
                strSql.Append(" select COMPOSITION_PRODUCTS_CODE as CODE,COMPOSITION_PRODUCTS_NAME as NAME from base_slip_type_composition_products_view ");
                strSql.AppendFormat(" where COMPOSITION_PRODUCTS_CODE LIKE @CODE and COMPOSITION_PRODUCTS_NAME LIKE @NAME ", CConstant.DELETE);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by CODE");
            }
            else
            {
                strSql.AppendFormat(" select * from BASE_{0} ", tableName);
                strSql.AppendFormat(" where CODE LIKE @CODE and NAME LIKE @NAME and STATUS_FLAG <> {0}", CConstant.DELETE);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" order by CODE");
            }
            SqlParameter[] parames = {
                        new SqlParameter("@CODE", SqlDbType.VarChar),
					    new SqlParameter("@NAME", SqlDbType.VarChar)};
            parames[0].Value = "%" + code + "%";
            parames[1].Value = "%" + name + "%";
            return DbHelperSQL.Query(strSql.ToString(), parames);
        }

        /// <summary>
        /// 系统设定表数据的取得
        /// </summary>
        public DataSet getNames(string codeType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" SELECT * FROM NAMES WHERE CODE_TYPE = '{0}' AND STATUS_FLAG <> {1} ORDER BY CODE ", codeType, CConstant.DELETE);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 我的桌面处理
        /// <summary>
        /// 我的桌面数据的取得
        /// </summary>
        public DataSet GetDeskDatas(string companyCode, string userCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from BASE_DESK ");
            strSql.Append(" where COMPANY_CODE = @COMPANY_CODE and USER_CODE = @USER_CODE ");
            strSql.Append(" order by CREATE_TIME");
            SqlParameter[] parames = {
                        new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar),
					    new SqlParameter("@USER_CODE", SqlDbType.VarChar)};
            parames[0].Value = companyCode;
            parames[1].Value = userCode;
            return DbHelperSQL.Query(strSql.ToString(), parames);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(BaseDeskTable deskTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_DESK");
            strSql.Append(" where COMPANY_CODE=@COMPANY_CODE and USER_CODE=@USER_CODE and FORM_NAME=@FORM_NAME and FORM_TITLE=@FORM_TITLE and FORM_ARGS=@FORM_ARGS ");
            SqlParameter[] parameters = {
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@USER_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@FORM_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@FORM_TITLE", SqlDbType.VarChar,50),
					new SqlParameter("@FORM_ARGS", SqlDbType.VarChar,50)};
            parameters[0].Value = deskTable.COMPANY_CODE;
            parameters[1].Value = deskTable.USER_CODE;
            parameters[2].Value = deskTable.FORM_NAME;
            parameters[3].Value = deskTable.FORM_TITLE;
            parameters[4].Value = deskTable.FORM_ARGS;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 添加到桌面
        /// </summary>
        public bool InsertDesk(BaseDeskTable deskTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_DESK(");
            strSql.Append("COMPANY_CODE,USER_CODE,FORM_NAME,FORM_TITLE,PIC,FORM_ARGS)");
            strSql.Append(" values (");
            strSql.Append("@COMPANY_CODE,@USER_CODE,@FORM_NAME,@FORM_TITLE,@PIC,@FORM_ARGS)");
            SqlParameter[] parameters = {
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@USER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@FORM_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@FORM_TITLE", SqlDbType.VarChar,50),
					new SqlParameter("@PIC", SqlDbType.Image),
					new SqlParameter("@FORM_ARGS", SqlDbType.VarChar,50)};
            parameters[0].Value = deskTable.COMPANY_CODE;
            parameters[1].Value = deskTable.USER_CODE;
            parameters[2].Value = deskTable.FORM_NAME;
            parameters[3].Value = deskTable.FORM_TITLE;
            parameters[4].Value = deskTable.PIC;
            parameters[5].Value = deskTable.FORM_ARGS;

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
        /// 删除桌面项
        /// </summary>
        public bool DeleteDesk(BaseDeskTable deskTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BASE_DESK ");
            strSql.Append(" where COMPANY_CODE=@COMPANY_CODE and USER_CODE=@USER_CODE and FORM_NAME=@FORM_NAME and FORM_TITLE=@FORM_TITLE");
            SqlParameter[] parameters = {
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@USER_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@FORM_NAME", SqlDbType.VarChar,50),
                    new SqlParameter("@FORM_TITLE", SqlDbType.VarChar,50),
					new SqlParameter("@FORM_ARGS", SqlDbType.VarChar,50)};
            parameters[0].Value = deskTable.COMPANY_CODE;
            parameters[1].Value = deskTable.USER_CODE;
            parameters[2].Value = deskTable.FORM_NAME;
            parameters[3].Value = deskTable.FORM_TITLE;
            parameters[4].Value = deskTable.FORM_ARGS;

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

        #endregion

        #region 引当状态的重新计算
        /// <summary>
        /// 引当状态的重新计算
        /// </summary>
        /// <param name="orderSlipNumber"></param>
        public void ReSetAlloation(string orderSlipNumber)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append(" select ");
                strSql.Append(" BOH.SLIP_NUMBER,");
                strSql.Append(" SUM(ISNULL(BOL.QUANTITY,0)) AS QUANTITY,");
                strSql.Append(" SUM(ISNULL(BOL.SHIPMENT_QUANTITY,0)) AS SHIPMENT_QUANTITY,");
                strSql.Append(" SUM(ISNULL(BA.QUANTITY,0)) AS ALLOATION_QUANTITY");
                strSql.Append(" from BLL_ORDER_HEADER AS BOH");
                strSql.Append(" LEFT JOIN BLL_ORDER_LINE AS BOL ON BOL.SLIP_NUMBER = BOH.SLIP_NUMBER");
                strSql.AppendFormat(" LEFT JOIN BLL_ALLOATION AS BA ON BA.ORDER_SLIP_NUMBER = BOH.SLIP_NUMBER AND  BA.STATUS_FLAG<>{0}", CConstant.ALLOATION_SHIPMENT);
                if (!string.IsNullOrEmpty(orderSlipNumber))
                {
                    strSql.AppendFormat(" WHERE BOH.SLIP_NUMBER ='{0}'", orderSlipNumber);
                }
                strSql.Append(" GROUP BY  BOH.SLIP_NUMBER");

                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string slipNumber = CConvert.ToString(dr["SLIP_NUMBER"]);
                    decimal quantity = CConvert.ToDecimal(dr["QUANTITY"]);                     //受注数量
                    decimal shipmentQuantity = CConvert.ToDecimal(dr["SHIPMENT_QUANTITY"]);　  //出库数量
                    decimal alloationQuantity = CConvert.ToDecimal(dr["ALLOATION_QUANTITY"]);　//未出库的引当数量

                    int alloationStatus = CConstant.ALLOATION_UN;
                    if (alloationQuantity == 0)
                    {
                        alloationStatus = CConstant.ALLOATION_UN;
                    }
                    else if (quantity - shipmentQuantity == alloationQuantity)
                    {
                        alloationStatus = CConstant.ALLOATION_COMPLETE;
                    }
                    else if (quantity - shipmentQuantity > alloationQuantity)
                    {
                        alloationStatus = CConstant.ALLOATION_PART;
                    }

                    try
                    {
                        strSql = new StringBuilder();
                        strSql.Append("update BLL_ORDER_HEADER set ");
                        strSql.Append("ALLOATION_FLAG=@ALLOATION_FLAG");
                        strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");

                        SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@ALLOATION_FLAG", SqlDbType.Int,4)};

                        parameters[0].Value = slipNumber;
                        parameters[1].Value = alloationStatus;

                        DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        #region  用户权限管理
        /// <summary>
        /// 系统功能列表的取得
        /// </summary>
        public DataSet GetFunctionList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from base_function_view order by code ,function_code");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得当前角色的所有权限
        /// </summary>
        public DataSet GetRoles(string rolesCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select brf.*,bf.* from BASE_ROLES_FUNCTION  as brf ");
            strSql.Append(" left join BASE_FUNCTION as bf on brf.FUNCTION_CODE = bf.code ");
            strSql.Append(" where ROLES_CODE = @ROLES_CODE ");
            SqlParameter[] parames = {
                        new SqlParameter("@ROLES_CODE", SqlDbType.VarChar)};
            parames[0].Value = rolesCode;
            return DbHelperSQL.Query(strSql.ToString(), parames);
        }

        /// <summary>
        /// 权限更新
        /// </summary>
        public int UpdateRoles(DataTable rolesDt, string rolesCode)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from BASE_ROLES_FUNCTION ");
            strSql.Append(" where ROLES_CODE = @ROLES_CODE ");
            SqlParameter[] parames = {
                        new SqlParameter("@ROLES_CODE", SqlDbType.VarChar)};
            parames[0].Value = rolesCode;
            listSql.Add(new CommandInfo(strSql.ToString(), parames));

            foreach (DataRow dr in rolesDt.Rows)
            {
                strSql = new StringBuilder();
                strSql.Append(" insert into BASE_ROLES_FUNCTION ");
                strSql.Append("(ROLES_CODE,FUNCTION_CODE)");
                strSql.Append(" values ");
                strSql.Append("(@ROLES_CODE,@FUNCTION_CODE)");
                SqlParameter[] parameters = {
                        new SqlParameter("@ROLES_CODE", SqlDbType.VarChar),
                        new SqlParameter("@FUNCTION_CODE", SqlDbType.VarChar)};
                parameters[0].Value = CConvert.ToString(dr["ROLES_CODE"]);
                parameters[1].Value = CConvert.ToString(dr["FUNCTION_CODE"]);
                listSql.Add(new CommandInfo(strSql.ToString(), parameters));
            }
            return DbHelperSQL.ExecuteSqlTran(listSql);
        }

        /// <summary>
        /// 用户权限变更后我的桌面重置处理
        /// </summary>
        public void ReSetMyDesk(string companyCode, string userCode, string rolesCode)
        {
            //当前角色的所有权限
            DataTable rolesDt = GetRoles(rolesCode).Tables[0];

            //当前用户的桌面
            DataTable deskDt = GetDeskDatas(companyCode, userCode).Tables[0];

            foreach (DataRow deskRow in deskDt.Rows)
            {
                bool isExist = false;
                foreach (DataRow rolesRow in rolesDt.Rows)
                {
                    if (CConvert.ToString(deskRow["FORM_NAME"]).Equals(CConvert.ToString(rolesRow["CLASS_NAME"])) && CConvert.ToString(deskRow["FORM_ARGS"]).Equals(CConvert.ToString(rolesRow["TAG"])))
                    {
                        isExist = true;
                    }
                }
                if (!isExist)
                {
                    //删除当前桌面应用
                    BaseDeskTable deskTable = new BaseDeskTable();
                    deskTable.COMPANY_CODE = CConvert.ToString(deskRow["COMPANY_CODE"]);
                    deskTable.USER_CODE = CConvert.ToString(deskRow["USER_CODE"]);
                    deskTable.FORM_NAME = CConvert.ToString(deskRow["FORM_NAME"]);
                    deskTable.FORM_TITLE = CConvert.ToString(deskRow["FORM_TITLE"]);
                    deskTable.FORM_ARGS = CConvert.ToString(deskRow["FORM_ARGS"]);
                    DeleteDesk(deskTable);
                }
            }
        }

        #endregion

        #region 单表字段更新
        /// <summary>
        /// 单表字段更新
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Table_FiledsValue"></param>
        /// <param name="Wheres"></param>
        /// <returns></returns>
        public int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres)
        {
            int rInt = 0;
            using (SqlConnection Conn = new SqlConnection(PubConstant.ConnectionString))
            {
                string strSql = string.Format("Update {0} Set {1}  Where {2}", Table, Table_FiledsValue, Wheres);
                SqlCommand cmd = new SqlCommand(strSql, Conn);
                cmd.CommandType = CommandType.Text;
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }
        #endregion

        #region 数据库表结构的取得
        /// <summary>
        /// 数据库表结构的取得
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataSet GetTableStruct(string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select sys.columns.name, sys.types.name as type ,(select value from sys.extended_properties where sys.extended_properties.major_id = sys.columns.object_id and sys.extended_properties.minor_id = sys.columns.column_id) as description ");
            strSql.Append(" from sys.columns, sys.tables, sys.types where sys.columns.object_id = sys.tables.object_id and sys.columns.system_type_id=sys.types.system_type_id and sys.tables.name=@tableName and sys.types.name <> 'sysname' order by sys.columns.column_id ");
            SqlParameter[] parames = {
                        new SqlParameter("@tableName", SqlDbType.VarChar)};
            parames[0].Value = tableName;
            return DbHelperSQL.Query(strSql.ToString(), parames);
        }

        #endregion

        #region 数据导入的日志记录
        /// <summary>
        /// 插入数据导入日志
        /// </summary>
        public int InsertReceiveLog(BllReceiveLogTable receiveLogTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bll_Import_Log(");
            strSql.Append("AUTO_MODE,SOURCE_FILE,SUCCESS_NUMBER,FAILURE_NUMBER,BACK_FILE,ERROR_FILE,STATUS_FLAG,CREATE_DATE,CREATE_USER_ID,LAST_UPDATE_DATE,LAST_UPDATE_USER_ID)");
            strSql.Append(" values (");
            strSql.Append("@AUTO_MODE,@SOURCE_FILE,@SUCCESS_NUMBER,@FAILURE_NUMBER,@BACK_FILE,@ERROR_FILE,@STATUS_FLAG,getdate(),@CREATE_USER_ID,getdate(),@LAST_UPDATE_USER_ID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AUTO_MODE", SqlDbType.Bit,1),
					new SqlParameter("@SOURCE_FILE", SqlDbType.NVarChar,255),
					new SqlParameter("@SUCCESS_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@FAILURE_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@BACK_FILE", SqlDbType.NVarChar,255),
					new SqlParameter("@ERROR_FILE", SqlDbType.NVarChar,255),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),					
					new SqlParameter("@CREATE_USER_ID", SqlDbType.Decimal,9),	
					new SqlParameter("@LAST_UPDATE_USER_ID", SqlDbType.Decimal,9)};
            parameters[0].Value = receiveLogTable.AUTO_MODE;
            parameters[1].Value = receiveLogTable.SOURCE_FILE;
            parameters[2].Value = receiveLogTable.SUCCESS_NUMBER;
            parameters[3].Value = receiveLogTable.FAILURE_NUMBER;
            parameters[4].Value = receiveLogTable.BACK_FILE;
            parameters[5].Value = receiveLogTable.ERROR_FILE;
            parameters[6].Value = receiveLogTable.STATUS_FLAG;
            parameters[7].Value = receiveLogTable.CREATE_USER_ID;
            parameters[8].Value = receiveLogTable.LAST_UPDATE_USER_ID;

            int rInt = DbHelperSQL.ExecuteSqlScalar(strSql.ToString(), parameters);
            return rInt;
        }

        /// <summary>
        /// 导入日志的记录条数
        /// </summary>
        public int GetReceiveLogCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_receive_log_view");
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
        /// 获得导入日志数据
        /// </summary>
        public DataSet GetReceiveLogList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.ID DESC");
            }
            strSql.Append(")AS Row, T.* from bll_receive_log_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion



        #region 常用输入内容的处理

        /// <summary>
        /// 常用输入内容是否存在该记录
        /// </summary>
        public bool ExistsBaseNames(string code, string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_NAMES");
            strSql.Append(" where CODE=@CODE AND NAME=@NAME");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50),
                    new SqlParameter("@NAME", SqlDbType.NVarChar,200)};
            parameters[0].Value = code;
            parameters[1].Value = name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 所有常用输入内容
        /// </summary>
        public DataSet GetBaseNames(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" SELECT * FROM BASE_NAMES WHERE STATUS_FLAG <> {0}  ", CConstant.DELETE);
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat(" AND {0} ", strWhere);
            }
            strSql.Append(" ORDER BY CODE");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 常用输入内容数据保存
        /// </summary>
        public int SaveBaseNmaes(string code, string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BASE_NAMES(CODE,NAME)");
            strSql.Append(" values (@CODE,@NAME)");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50),
					new SqlParameter("@NAME", SqlDbType.NVarChar,200)};
            parameters[0].Value = code;
            parameters[1].Value = name;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public DataSet GetModel(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" SELECT * FROM BASE_CUSTOMER" );
            strSql.Append(" where CODE=@CODE");
             SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = code;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion
    }//end class
}
