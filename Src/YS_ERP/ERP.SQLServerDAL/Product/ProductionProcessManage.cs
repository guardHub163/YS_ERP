using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.Common;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using System.Data;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;

namespace CZZD.ERP.SQLServerDAL
{
    public class ProductionProcessManage : IProductionProcess
    {
        public ProductionProcessManage()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PRODUCTION_PROCESS");
            strSql.Append(" where CODE=@CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = { new SqlParameter("@CODE", SqlDbType.VarChar, 50) };
            parameters[0].Value = CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool IsDelete(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PRODUCTION_PROCESS");
            strSql.AppendFormat(" where CODE=@CODE and status_flag ={0} ", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = code;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BaseProductionProcessTable model)
        {
            StringBuilder strSql = null;
            int rows = 0;
            if (IsDelete(model.CODE))
            {
                #region 更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_PRODUCTION_PROCESS set ");
                strSql.Append("NAME=@NAME,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("CREATE_USER=@CREATE_USER,");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("DEPARTMENT_CODE=@DEPARTMENT_CODE,");
                strSql.Append("DRAWING_TYPE_CODE1=@DRAWING_TYPE_CODE1,");
                strSql.Append("DRAWING_TYPE_CODE2=@DRAWING_TYPE_CODE2,");
                strSql.Append("DRAWING_TYPE_CODE3=@DRAWING_TYPE_CODE3,");
                strSql.Append("DRAWING_TYPE_CODE4=@DRAWING_TYPE_CODE4,");
                strSql.Append("DRAWING_TYPE_CODE5=@DRAWING_TYPE_CODE5,");
                strSql.Append("DRAWING_TYPE_CODE6=@DRAWING_TYPE_CODE6,");
                strSql.Append("TECHNOLOGY_CODE1=@TECHNOLOGY_CODE1,");
                strSql.Append("TECHNOLOGY_CODE2=@TECHNOLOGY_CODE2,");
                strSql.Append("TECHNOLOGY_CODE3=@TECHNOLOGY_CODE3,");
                strSql.Append("PRODUCTION_CYCLE=@PRODUCTION_CYCLE,");
                strSql.Append("PROCESS_STATUS=@PROCESS_STATUS");
                strSql.Append(" where CODE=@CODE ");
                SqlParameter[] parameters = {	
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@DEPARTMENT_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@DRAWING_TYPE_CODE1", SqlDbType.VarChar,20), 
                    new SqlParameter("@DRAWING_TYPE_CODE2", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE3", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE4", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE5", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE6", SqlDbType.VarChar,20),
                    new SqlParameter("@TECHNOLOGY_CODE1", SqlDbType.VarChar,20),
                    new SqlParameter("@TECHNOLOGY_CODE2", SqlDbType.VarChar,20),
                    new SqlParameter("@TECHNOLOGY_CODE3", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCTION_CYCLE", SqlDbType.Decimal),
                    new SqlParameter("@PROCESS_STATUS", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = CConstant.INIT;
                parameters[3].Value = model.LAST_UPDATE_USER;
                parameters[4].Value = model.LAST_UPDATE_USER;
                parameters[5].Value = model.DEPARTMENT_CODE;
                parameters[6].Value = model.DRAWING_TYPE_CODE1;
                parameters[7].Value = model.DRAWING_TYPE_CODE2;
                parameters[8].Value = model.DRAWING_TYPE_CODE3;
                parameters[9].Value = model.DRAWING_TYPE_CODE4;
                parameters[10].Value = model.DRAWING_TYPE_CODE5;
                parameters[11].Value = model.DRAWING_TYPE_CODE6;
                parameters[12].Value = model.TECHNOLOGY_CODE1;
                parameters[13].Value = model.TECHNOLOGY_CODE2;
                parameters[14].Value = model.TECHNOLOGY_CODE3;
                parameters[15].Value = model.PRODUCTION_CYCLE;
                parameters[16].Value = model.JUDGMENT;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            else
            {
                #region 增加
                strSql = new StringBuilder();
                strSql.Append("insert into BASE_PRODUCTION_PROCESS(");
                strSql.Append("CODE,NAME,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME,ENGLISH_NAME,ATTRIBUTE1,ATTRIBUTE2,ATTRIBUTE3,DEPARTMENT_CODE,DRAWING_TYPE_CODE1,PRODUCTION_CYCLE,DRAWING_TYPE_CODE2,DRAWING_TYPE_CODE3,DRAWING_TYPE_CODE4,DRAWING_TYPE_CODE5,DRAWING_TYPE_CODE6,TECHNOLOGY_CODE1,TECHNOLOGY_CODE2,TECHNOLOGY_CODE3,PROCESS_STATUS)");
                strSql.Append(" values (");
                strSql.Append("@CODE,@NAME,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE(),@ENGLISH_NAME,@ATTRIBUTE1,@ATTRIBUTE2,@ATTRIBUTE3,@DEPARTMENT_CODE,@DRAWING_TYPE_CODE1,@PRODUCTION_CYCLE,@DRAWING_TYPE_CODE2,@DRAWING_TYPE_CODE3,@DRAWING_TYPE_CODE4,@DRAWING_TYPE_CODE5,@DRAWING_TYPE_CODE6,@TECHNOLOGY_CODE1,@TECHNOLOGY_CODE2,@TECHNOLOGY_CODE3,@PROCESS_STATUS)");
                SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@ENGLISH_NAME", SqlDbType.VarChar,20),
                    new SqlParameter("@ATTRIBUTE1", SqlDbType.VarChar,20),
                    new SqlParameter("@ATTRIBUTE2", SqlDbType.VarChar,20),
                    new SqlParameter("@ATTRIBUTE3", SqlDbType.VarChar,20),
                    new SqlParameter("@DEPARTMENT_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@DRAWING_TYPE_CODE1", SqlDbType.VarChar,20),   
                    new SqlParameter("@PRODUCTION_CYCLE", SqlDbType.Decimal),                                    
                    new SqlParameter("@DRAWING_TYPE_CODE2", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE3", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE4", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE5", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE6", SqlDbType.VarChar,20) ,
                    new SqlParameter("@TECHNOLOGY_CODE1", SqlDbType.VarChar,20),
                    new SqlParameter("@TECHNOLOGY_CODE2", SqlDbType.VarChar,20), 
                    new SqlParameter("@TECHNOLOGY_CODE3", SqlDbType.VarChar,20),
                    new SqlParameter("@PROCESS_STATUS", SqlDbType.VarChar,20)};
                parameters[0].Value = model.CODE;
                parameters[1].Value = model.NAME;
                parameters[2].Value = CConstant.INIT;
                parameters[3].Value = model.CREATE_USER;
                parameters[4].Value = model.LAST_UPDATE_USER;
                parameters[5].Value = model.ENGLISHNAME;
                parameters[6].Value = model.ATTRIBUTE1;
                parameters[7].Value = model.ATTRIBUTE2;
                parameters[8].Value = model.ATTRIBUTE3;
                parameters[9].Value = model.DEPARTMENT_CODE;
                parameters[10].Value = model.DRAWING_TYPE_CODE1;
                parameters[11].Value = model.PRODUCTION_CYCLE;
                parameters[12].Value = model.DRAWING_TYPE_CODE2;
                parameters[13].Value = model.DRAWING_TYPE_CODE3;
                parameters[14].Value = model.DRAWING_TYPE_CODE4;
                parameters[15].Value = model.DRAWING_TYPE_CODE5;
                parameters[16].Value = model.DRAWING_TYPE_CODE6;
                parameters[17].Value = model.TECHNOLOGY_CODE1;
                parameters[18].Value = model.TECHNOLOGY_CODE2;
                parameters[19].Value = model.TECHNOLOGY_CODE3;
                parameters[20].Value = model.JUDGMENT;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                #endregion
            }
            if (rows > 0)
            {
                return true;
               // CCacheData.DrawingType = null;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseProductionProcessTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BASE_PRODUCTION_PROCESS set ");
            strSql.Append("NAME=@NAME,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("ENGLISH_NAME=@ENGLISH_NAME,");
            strSql.Append("DEPARTMENT_CODE=@DEPARTMENT_CODE,");
            strSql.Append("DRAWING_TYPE_CODE1=@DRAWING_TYPE_CODE1,");
            strSql.Append("PRODUCTION_CYCLE=@PRODUCTION_CYCLE,");
            strSql.Append("DRAWING_TYPE_CODE2=@DRAWING_TYPE_CODE2,");
            strSql.Append("DRAWING_TYPE_CODE3=@DRAWING_TYPE_CODE3,");
            strSql.Append("DRAWING_TYPE_CODE4=@DRAWING_TYPE_CODE4,");
            strSql.Append("DRAWING_TYPE_CODE5=@DRAWING_TYPE_CODE5,");
            strSql.Append("DRAWING_TYPE_CODE6=@DRAWING_TYPE_CODE6,");
            strSql.Append("TECHNOLOGY_CODE1=@TECHNOLOGY_CODE1,");
            strSql.Append("TECHNOLOGY_CODE2=@TECHNOLOGY_CODE2,");
            strSql.Append("TECHNOLOGY_CODE3=@TECHNOLOGY_CODE3,");
            strSql.Append("PROCESS_STATUS=@PROCESS_STATUS");

            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,20),
					new SqlParameter("@NAME", SqlDbType.VarChar,100),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@ENGLISH_NAME", SqlDbType.VarChar,20),
                    new SqlParameter("@DEPARTMENT_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@DRAWING_TYPE_CODE1", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCTION_CYCLE", SqlDbType.Decimal),
                    new SqlParameter("@DRAWING_TYPE_CODE2", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE3", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE4", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE5", SqlDbType.VarChar,20),  
                    new SqlParameter("@DRAWING_TYPE_CODE6", SqlDbType.VarChar,20),
                    new SqlParameter("@TECHNOLOGY_CODE1", SqlDbType.VarChar,20),
                    new SqlParameter("@TECHNOLOGY_CODE2", SqlDbType.VarChar,20),
                    new SqlParameter("@TECHNOLOGY_CODE3", SqlDbType.VarChar,20),
                    new SqlParameter("@PROCESS_STATUS", SqlDbType.VarChar,20)
                                        };
            parameters[0].Value = model.CODE;
            parameters[1].Value = model.NAME;
            parameters[2].Value = model.STATUE_FLAG;
            parameters[3].Value = model.LAST_UPDATE_USER;
            parameters[4].Value = model.ENGLISHNAME;
            parameters[5].Value = model.DEPARTMENT_CODE;
            parameters[6].Value = model.DRAWING_TYPE_CODE1;
            parameters[7].Value = model.PRODUCTION_CYCLE;
            parameters[8].Value = model.DRAWING_TYPE_CODE2;
            parameters[9].Value = model.DRAWING_TYPE_CODE3;
            parameters[10].Value = model.DRAWING_TYPE_CODE4;
            parameters[11].Value = model.DRAWING_TYPE_CODE5;
            parameters[12].Value = model.DRAWING_TYPE_CODE6;
            parameters[13].Value = model.TECHNOLOGY_CODE1;
            parameters[14].Value = model.TECHNOLOGY_CODE2;
            parameters[15].Value = model.TECHNOLOGY_CODE3;
            parameters[16].Value = model.JUDGMENT;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                CCacheData.DrawingType = null;
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
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BASE_PRODUCTION_PROCESS  set STATUS_FLAG = {0}", CConstant.DELETE);
            strSql.Append(" where CODE=@CODE ");
            SqlParameter[] stParam = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            stParam[0].Value = CODE;
            listSql.Add(new CommandInfo(strSql.ToString(), stParam));

            //strSql = new StringBuilder();
            //strSql.Append("delete from BASE_PRODUCTION_PROCESS ");
            //strSql.Append(" where CODE=@CODE ");
            //SqlParameter[] scpParam = {
            //        new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            //scpParam[0].Value = CODE;
            //listSql.Add(new CommandInfo(strSql.ToString(), scpParam));

            int rows = DbHelperSQL.ExecuteSqlTran(listSql);
            if (rows > 0)
            {
                CCacheData.SlipType = null;
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
        public BaseProductionProcessTable GetModel(string CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  *  from base_production_process_view ");
            strSql.Append(" where CODE=@CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = CODE;

            BaseProductionProcessTable model = null;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                model = new BaseProductionProcessTable();
                model.CODE = dr["CODE"].ToString();
                model.NAME = dr["NAME"].ToString();
                if (dr["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUE_FLAG = CConvert.ToInt32(dr["STATUS_FLAG"]);
                }

                if (dr["CREATE_USER"].ToString() != "")
                {
                    model.CREATE_USER = dr["CREATE_USER"].ToString();
                }

                if (dr["LAST_UPDATE_USER"].ToString() != "")
                {
                    model.LAST_UPDATE_USER = dr["LAST_UPDATE_USER"].ToString();
                }

                if (dr["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(dr["CREATE_DATE_TIME"].ToString());
                }

                if (dr["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(dr["LAST_UPDATE_TIME"].ToString());
                }
                if (dr["ENGLISH_NAME"].ToString() != "")
                {
                    model.ENGLISHNAME = dr["ENGLISH_NAME"].ToString();
                }
                if (dr["PRODUCTION_CYCLE"].ToString() != "")
                {
                    model.PRODUCTION_CYCLE = CConvert.ToDecimal(dr["PRODUCTION_CYCLE"]);
                }
                if (dr["DEPARTMENT_CODE"].ToString() != "")
                {
                    model.DEPARTMENT_CODE = dr["DEPARTMENT_CODE"].ToString();
                }
                if (dr["DEPARTMENT_NAME"].ToString() != "")
                {
                    model.DEPARTMENT_NAME = dr["DEPARTMENT_NAME"].ToString();
                }
                if (dr["DRAWING_TYPE_CODE1"].ToString() != "")
                {
                    model.DRAWING_TYPE_CODE1 = dr["DRAWING_TYPE_CODE1"].ToString();
                }
                if (dr["DRAWING_TYPE_CODE2"].ToString() != "")
                {
                    model.DRAWING_TYPE_CODE2 = dr["DRAWING_TYPE_CODE2"].ToString();
                }
                if (dr["DRAWING_TYPE_CODE3"].ToString() != "")
                {
                    model.DRAWING_TYPE_CODE3 = dr["DRAWING_TYPE_CODE3"].ToString();
                }
                if (dr["DRAWING_TYPE_CODE4"].ToString() != "")
                {
                    model.DRAWING_TYPE_CODE4 = dr["DRAWING_TYPE_CODE4"].ToString();
                }
                if (dr["DRAWING_TYPE_CODE5"].ToString() != "")
                {
                    model.DRAWING_TYPE_CODE5 = dr["DRAWING_TYPE_CODE5"].ToString();
                }
                if (dr["DRAWING_TYPE_CODE6"].ToString() != "")
                {
                    model.DRAWING_TYPE_CODE6 = dr["DRAWING_TYPE_CODE6"].ToString();
                }
                if (dr["DRAWING_TYPE_NAME1"].ToString() != "")
                {
                    model.DRAWING_TYPE_NAME1 = dr["DRAWING_TYPE_NAME1"].ToString();
                }
                if (dr["DRAWING_TYPE_NAME2"].ToString() != "")
                {
                    model.DRAWING_TYPE_NAME2 = dr["DRAWING_TYPE_NAME2"].ToString();
                }
                if (dr["DRAWING_TYPE_NAME3"].ToString() != "")
                {
                    model.DRAWING_TYPE_NAME3 = dr["DRAWING_TYPE_NAME3"].ToString();
                }
                if (dr["DRAWING_TYPE_NAME4"].ToString() != "")
                {
                    model.DRAWING_TYPE_NAME4 = dr["DRAWING_TYPE_NAME4"].ToString();
                }
                if (dr["DRAWING_TYPE_NAME5"].ToString() != "")
                {
                    model.DRAWING_TYPE_NAME5 = dr["DRAWING_TYPE_NAME5"].ToString();
                }
                if (dr["DRAWING_TYPE_NAME6"].ToString() != "")
                {
                    model.DRAWING_TYPE_NAME6 = dr["DRAWING_TYPE_NAME6"].ToString();
                }

                if (dr["TECHNOLOGY_CODE1"].ToString() != "")
                {
                    model.TECHNOLOGY_CODE1 = dr["TECHNOLOGY_CODE1"].ToString();
                }
                if (dr["TECHNOLOGY_CODE2"].ToString() != "")
                {
                    model.TECHNOLOGY_CODE2 = dr["TECHNOLOGY_CODE2"].ToString();
                }
                if (dr["TECHNOLOGY_CODE3"].ToString() != "")
                {
                    model.TECHNOLOGY_CODE3 = dr["TECHNOLOGY_CODE3"].ToString();
                }
                if (dr["TECHNOLOGY_NAME1"].ToString() != "")
                {
                    model.TECHNOLOGY_NAME1 = dr["TECHNOLOGY_NAME1"].ToString();
                }
                if (dr["TECHNOLOGY_NAME2"].ToString() != "")
                {
                    model.TECHNOLOGY_NAME2 = dr["TECHNOLOGY_NAME2"].ToString();
                }
                if (dr["TECHNOLOGY_NAME3"].ToString() != "")
                {
                    model.TECHNOLOGY_NAME3 = dr["TECHNOLOGY_NAME3"].ToString();
                }
                if (dr["PROCESS_STATUS"].ToString() != "")
                {
                    model.JUDGMENT = dr["PROCESS_STATUS"].ToString();
                }

                break;
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from base_production_process_view ");
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
            strSql.Append("select count(1) from base_production_process_view");
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
            strSql.Append(")AS Row, T.* from base_production_process_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GETDEPARTMENT()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM  ");
            strSql.Append("BASE_DEPARTMENT");

            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetDrawingType()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM  ");
            strSql.Append("BASE_DRAWING");

            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}
