using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL.Product;
using CZZD.ERP.Model;
using System.Data;
using CZZD.ERP.Common;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;

namespace CZZD.ERP.SQLServerDAL
{
    public class ProductionPlanSearchManage : IProductionPlanSearch
    {
        public DataSet GetProductionPlan(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM bll_production_schedule_model_view");
            //strSql.Append("select * FROM bll_production_schedule_process_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int StartProcessing(BaseProductionPlanTable PlanTable)
        {
            int result = 0;
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("update BLL_PRODUCTION_SCHEDULE set ");
            //strSql.Append("STATUS_FLAG=@STATUS_FLAG");
            //strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            //SqlParameter[] planparameters = {			
            //        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
            //        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            //planparameters[0].Value = PlanTable.STATUS_FLAG;
            //planparameters[1].Value = PlanTable.SLIP_NUMBER;
            //listSql.Add(new CommandInfo(strSql.ToString(), planparameters));

            foreach (BaseProductionScheduleProductionProcessTable lineModel in PlanTable.ItemsProductionProcess)
            {
                strSql = new StringBuilder();
                strSql.Append("update BLL_PRODUCTION_SCHEDULE_PRODUCTION_PROCESS set ");
                strSql.Append("ACTUAL_START_TIME=@ACTUAL_START_TIME,");
                strSql.Append("ACTUAL_END_TIME=@ACTUAL_END_TIME,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("WEIGHT=@WEIGHT");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
                strSql.Append(" AND SCHEDULE_LINE_NUNBER=@SCHEDULE_LINE_NUNBER");
                strSql.Append(" AND LINE_NUMBER=@LINE_NUMBER");
                SqlParameter[] parameters = {
					new SqlParameter("@ACTUAL_START_TIME", SqlDbType.DateTime),
					new SqlParameter("@ACTUAL_END_TIME", SqlDbType.DateTime),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@SCHEDULE_LINE_NUNBER", SqlDbType.Int,9),
                    new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9),
                    new SqlParameter("@WEIGHT", SqlDbType.VarChar,50)};
                parameters[0].Value = lineModel.ACTUAL_START_TIME;
                parameters[1].Value = lineModel.ACTUAL_END_TIME;
                parameters[2].Value = lineModel.STATUS_FLAG;
                parameters[3].Value = lineModel.SLIP_NUMBER;
                parameters[4].Value = lineModel.SCHEDULE_LINE_NUNBER;
                parameters[5].Value = lineModel.LINE_NUMBER;
                parameters[6].Value = lineModel.WEIGHT;
                listSql.Add(new CommandInfo(strSql.ToString(), parameters));
            }
            //foreach (BaseProductionPlanLineTable lineModel in PlanTable.Items)
            //{
            //    strSql = new StringBuilder();
            //    strSql.Append("update BLL_PRODUCTION_SCHEDULE_LINE set ");
            //    strSql.Append("STATUS_FLAG=@STATUS_FLAG");
            //    strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            //    strSql.Append(" AND LINE_NUMBER=@LINE_NUMBER");
            //    SqlParameter[] planlineparameters = {			
            //        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
            //        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),					
            //        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9)};
            //    planlineparameters[0].Value = lineModel.STATUS_FLAG;
            //    planlineparameters[1].Value = lineModel.SLIP_NUMBER;
            //    planlineparameters[2].Value = lineModel.LINE_NUMBER;
            //    listSql.Add(new CommandInfo(strSql.ToString(), planlineparameters));
            //}
            result = DbHelperSQL.ExecuteSqlTran(listSql);
            return result;
        }
        public int LineStatus(BaseProductionPlanTable PlanTable)
        {
            int resultstatus = 0;
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("update BLL_PRODUCTION_SCHEDULE set ");
            //strSql.Append("STATUS_FLAG=@STATUS_FLAG");
            //strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            //SqlParameter[] planparameters = {			
            //        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
            //        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            //planparameters[0].Value = PlanTable.STATUS_FLAG;
            //planparameters[1].Value = PlanTable.SLIP_NUMBER;
            //listSql.Add(new CommandInfo(strSql.ToString(), planparameters));

            foreach (BaseProductionPlanLineTable lineModel in PlanTable.Items)
            {
                strSql = new StringBuilder();
                strSql.Append("update BLL_PRODUCTION_SCHEDULE_LINE set ");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
                // strSql.Append(" AND LINE_NUMBER=@LINE_NUMBER");
                SqlParameter[] planlineparameters = {			
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)//,					
                   //new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9)
                                                   };
                planlineparameters[0].Value = lineModel.STATUS_FLAG;
                planlineparameters[1].Value = lineModel.SLIP_NUMBER;
                // planlineparameters[2].Value = lineModel.LINE_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), planlineparameters));
            }
            resultstatus = DbHelperSQL.ExecuteSqlTran(listSql);
            return resultstatus;
        }
        public int Status(BaseProductionPlanTable PlanTable)
        {
            int resultschedule = 0;
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            if (PlanTable.ACTUAL_END_TIME.ToString().Equals(""))
            {
                strSql.Append("update BLL_PRODUCTION_SCHEDULE set ");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
                SqlParameter[] planparameters = {			
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                planparameters[0].Value = PlanTable.STATUS_FLAG;
                planparameters[1].Value = PlanTable.SLIP_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), planparameters));
            }
            else
            {
                strSql.Append("update BLL_PRODUCTION_SCHEDULE set ");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("ACTUAL_END_TIME=@ACTUAL_END_TIME");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
                SqlParameter[] planparameters = {			
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
                    new SqlParameter("@ACTUAL_END_TIME", SqlDbType.DateTime),
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                planparameters[0].Value = PlanTable.STATUS_FLAG;
                planparameters[1].Value = PlanTable.ACTUAL_END_TIME;
                planparameters[2].Value = PlanTable.SLIP_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), planparameters));
            }
        

            //foreach (BaseProductionPlanLineTable lineModel in PlanTable.Items)
            //{
            //    strSql = new StringBuilder();
            //    strSql.Append("update BLL_PRODUCTION_SCHEDULE_LINE set ");
            //    strSql.Append("STATUS_FLAG=@STATUS_FLAG");
            //    strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            //    strSql.Append(" AND LINE_NUMBER=@LINE_NUMBER");
            //    SqlParameter[] planlineparameters = {			
            //        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
            //        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),					
            //        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9)};
            //    planlineparameters[0].Value = lineModel.STATUS_FLAG;
            //    planlineparameters[1].Value = lineModel.SLIP_NUMBER;
            //    planlineparameters[2].Value = lineModel.LINE_NUMBER;
            //    listSql.Add(new CommandInfo(strSql.ToString(), planlineparameters));
            //}
            resultschedule = DbHelperSQL.ExecuteSqlTran(listSql);
            return resultschedule;
        }

        public DataSet GetProductionTechnology(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select * FROM bll_production_technology_view");
            strSql.Append("select * FROM bll_production_technology_drawing_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        public int EndTechnology(BaseProductionScheduleProductionProcessTable psppTable)
        {
            int result = 0;
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            foreach (BaseProductionTechnologyTable lineModel in psppTable.ProductionTechnology)
            {
                strSql = new StringBuilder();
                strSql.Append("update BLL_PRODUCTION_SCHEDULE_TECHNOLOGY set ");
                strSql.Append("ACTUAL_END_TIME=@ACTUAL_END_TIME,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
                strSql.Append(" AND SCHEDULE_LINE_NUMBER=@SCHEDULE_LINE_NUMBER");
                strSql.Append(" AND SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER=@SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER");
                strSql.Append(" AND TECHNOLOGY_LINE_NUMBER=@TECHNOLOGY_LINE_NUMBER");
                SqlParameter[] parameters = {		
					new SqlParameter("@ACTUAL_END_TIME", SqlDbType.DateTime),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@SCHEDULE_LINE_NUMBER", SqlDbType.Int,9),
                    new SqlParameter("@SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER", SqlDbType.Int,9),
                    new SqlParameter("@TECHNOLOGY_LINE_NUMBER", SqlDbType.Int,9)};
                parameters[0].Value = lineModel.ACTUAL_END_TIME;
                parameters[1].Value = lineModel.STATUS_FLAG;
                parameters[2].Value = lineModel.SLIP_NUMBER;
                parameters[3].Value = lineModel.SCHEDULE_LINE_NUMBER;
                parameters[4].Value = lineModel.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER;
                parameters[5].Value = lineModel.LINE_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), parameters));
            }
            try
            {
                result = DbHelperSQL.ExecuteSqlTran(listSql);
            }
            catch (Exception ex)
            { }
            return result;
        }

        public DataSet GetProductionTechnologyStatus(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT PSPP.SLIP_NUMBER ,PSPP.SCHEDULE_LINE_NUNBER ,PSPP.LINE_NUMBER ,COUNT(1) AS COUNT, SUM(PST.STATUS_FLAG) AS NUMBER ");
            strSql.Append(" FROM dbo.BLL_PRODUCTION_SCHEDULE_PRODUCTION_PROCESS AS PSPP ");
            strSql.Append(" LEFT JOIN dbo.BLL_PRODUCTION_SCHEDULE_TECHNOLOGY AS PST ON PST.SLIP_NUMBER = PSPP.SLIP_NUMBER ");
            strSql.Append(" AND PST.SCHEDULE_LINE_NUMBER = PSPP.SCHEDULE_LINE_NUNBER ");
            strSql.Append(" AND PST.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER = PSPP.LINE_NUMBER");
            strSql.Append(" LEFT JOIN dbo.BASE_PRODUCTION_PROCESS AS PP ON PP.CODE = PSPP.PRODUCTION_PROCESS_CODE");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" GROUP BY PSPP.SLIP_NUMBER,PSPP.SCHEDULE_LINE_NUNBER,PSPP.LINE_NUMBER");


            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetProductionDw(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT PSPP.SLIP_NUMBER,PSPP.SCHEDULE_LINE_NUNBER,PSPP.LINE_NUMBER,COUNT(1) AS COUNT,SUM(ISNULL(PSDL.NUMBER,0)) AS NUMBER");
            strSql.Append(" FROM BLL_PRODUCTION_SCHEDULE_PRODUCTION_PROCESS AS PSPP ");
            strSql.Append(" LEFT JOIN base_production_process_drawing_view AS PPDV ON PSPP.PRODUCTION_PROCESS_CODE = PPDV.CODE ");
            strSql.Append(" LEFT JOIN (	SELECT  PSPP.SLIP_NUMBER,PSPP.DRAWING_CODE,1 AS NUMBER	FROM BLL_PRODUCTION_SCHEDULE_DRAWING_LINE AS PSPP LEFT JOIN BLL_PRODUCTION_DRAWING_UPLOAD AS PDU ON PSPP.SLIP_NUMBER = PDU.SLIP_NUMBER 	AND PSPP.DRAWING_CODE = PDU.DRAWING_CODE ");
            strSql.Append(" WHERE PDU.ID IS NOT NULL ");
            strSql.Append(" GROUP BY  PSPP.SLIP_NUMBER,PSPP.DRAWING_CODE) AS PSDL ON PSPP.SLIP_NUMBER = PSDL.SLIP_NUMBER AND PPDV.DRAWING_TYPE_CODE = PSDL.DRAWING_CODE ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" GROUP BY PSPP.SLIP_NUMBER,PSPP.SCHEDULE_LINE_NUNBER,PSPP.LINE_NUMBER");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetTechnologyDw(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT PST.SLIP_NUMBER,PST.SCHEDULE_LINE_NUMBER,PST.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER,PST.TECHNOLOGY_LINE_NUMBER,PST.TECHNOLOGY_CODE,COUNT(1) AS COUNT,SUM(ISNULL(PSDL.NUMBER,0)) AS NUMBER ");
            strSql.Append(" FROM BLL_PRODUCTION_SCHEDULE_TECHNOLOGY AS PST ");
            strSql.Append(" LEFT JOIN base_technology_drawing_view AS BTDV ON  PST.TECHNOLOGY_CODE = BTDV.CODE ");
            strSql.Append("LEFT JOIN (	SELECT  PSPP.SLIP_NUMBER,PSPP.DRAWING_CODE,1 AS NUMBER	FROM BLL_PRODUCTION_SCHEDULE_DRAWING_LINE AS PSPP  ");
            strSql.Append(" 	LEFT JOIN BLL_PRODUCTION_DRAWING_UPLOAD AS PDU ON PSPP.SLIP_NUMBER = PDU.SLIP_NUMBER AND PSPP.DRAWING_CODE = PDU.DRAWING_CODE ");
            strSql.Append("	WHERE PDU.ID IS NOT NULL 	GROUP BY  PSPP.SLIP_NUMBER,PSPP.DRAWING_CODE) AS PSDL ON PST.SLIP_NUMBER = PSDL.SLIP_NUMBER AND BTDV.TECHNOLOGY_DRAWING = PSDL.DRAWING_CODE  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" GROUP BY PST.SLIP_NUMBER,PST.SCHEDULE_LINE_NUMBER,PST.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER,PST.TECHNOLOGY_LINE_NUMBER,PST.TECHNOLOGY_CODE");
            return DbHelperSQL.Query(strSql.ToString());
        }

    }//end class
}
