using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL.Product;
using System.Data;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using System.Data.SqlClient;
using CZZD.ERP.Model.Product;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class ProductionDrawingManage : IProductionDrawing
    {
        public DataSet GetProductionDrawing(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM bll_production_drawing_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int EndDrawing(BaseProductionPlanLineTable PlanLineTable)
        {
            int result = 0;
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            foreach (BaseProductionScheduleProductionProcessTable lineModel in PlanLineTable.ProductionProcess)
            {
                strSql = new StringBuilder();
                strSql.Append("update BLL_PRODUCTION_SCHEDULE_DRAWING_LINE set ");
                strSql.Append("ACTUAL_END_TIME=@ACTUAL_END_TIME,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
                strSql.Append(" AND LINE_NUMBER=@LINE_NUMBER");
                SqlParameter[] parameters = {                 
                    new SqlParameter("@ACTUAL_END_TIME", SqlDbType.DateTime),
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),                  
                    new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9)};
                parameters[0].Value = lineModel.ACTUAL_END_TIME;
                parameters[1].Value = lineModel.STATUS_FLAG;
                parameters[2].Value = lineModel.SLIP_NUMBER;
                parameters[3].Value = lineModel.LINE_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), parameters));
            }
            result = DbHelperSQL.ExecuteSqlTran(listSql);
            return result;
        }
        public int Add(BaseProductionDrawingTable model)
        {
            int result = 0;
            try
            {
                List<CommandInfo> listSql = new List<CommandInfo>();
                StringBuilder strSql = new StringBuilder();

                foreach (BaseProductionDrawingTable lineModel in model.Items)
                {
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_PRODUCTION_DRAWING_UPLOAD(");
                    strSql.Append("SLIP_NUMBER,DRAWING_CODE,LOCATION_FILE_NAME,SERVER_FILE_NAME)");
                    strSql.Append(" values (");
                    strSql.Append(" @SLIP_NUMBER,@DRAWING_CODE,@LOCATION_FILE_NAME,@SERVER_FILE_NAME)");
                    SqlParameter[] lineDrawingParameters = {
                            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,250),
                            new SqlParameter("@DRAWING_CODE", SqlDbType.VarChar,250),
                            new SqlParameter("@LOCATION_FILE_NAME", SqlDbType.VarChar,250),    
                            new SqlParameter("@SERVER_FILE_NAME", SqlDbType.VarChar,250)};
                    lineDrawingParameters[0].Value = lineModel.SLIPNUMBER;
                    lineDrawingParameters[1].Value = lineModel.DRAWINGCODE;
                    lineDrawingParameters[2].Value = lineModel.FILENAME;
                    lineDrawingParameters[3].Value = lineModel.SERVERFILENAME;
                    listSql.Add(new CommandInfo(strSql.ToString(), lineDrawingParameters));
                }
                result = DbHelperSQL.ExecuteSqlTran(listSql);

            }
            catch (SqlException ex)
            {


            }
            return result;
        }
        public DataSet GetProductionDrawingUpload(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM bll_production_drawing_upload_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int  Delete(string SLIPNUMBER, string DRAWINGCODE, string SERVERFILENAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM  BLL_PRODUCTION_DRAWING_UPLOAD");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            strSql.Append(" AND DRAWING_CODE=@DRAWING_CODE ");
            strSql.Append(" AND SERVER_FILE_NAME=@SERVER_FILE_NAME ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,250),
                    new SqlParameter("@DRAWING_CODE", SqlDbType.VarChar,250),
                    new SqlParameter("@SERVER_FILE_NAME", SqlDbType.VarChar,250)};
            parameters[0].Value = SLIPNUMBER;
            parameters[1].Value = DRAWINGCODE;
            parameters[2].Value = SERVERFILENAME;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

    }

}

