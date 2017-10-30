using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Common;
using CZZD.ERP.DBUtility;
using CZZD.ERP.IDAL.Product;
using CZZD.ERP.Model;
using System.Data;
using System.Data.SqlClient;
using CZZD.ERP.Model;

namespace CZZD.ERP.SQLServerDAL
{
    public class ProductionPlanManage : IProductionPlan
    {
        /// <summary>
        /// 取得当前公司的最大订单流水号
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public string GetMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(max(SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from get_productionplan_header_max_slip_number");
            return CConvert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public string Add(BaseProductionPlanTable headerModel, BllOrderHeaderTable bOrderHeader)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into BLL_PRODUCTION_SCHEDULE(");
                    strSql.Append("SLIP_NUMBER,ORDER_SLIP_NUNBER,SLIP_DATE,SLIP_TYPE_CODE,DESCRIPTION,PLAN_NUMBER,PLAN_START_DATE,PLAN_END_DATE,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,ACTUAL_START_TIME,ACTUAL_END_TIME,MEMO1,MEMO2,MEMO3)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@ORDER_SLIP_NUNBER,GETDATE(),@SLIP_TYPE_CODE,@DESCRIPTION,@PLAN_NUMBER,@PLAN_START_DATE,@PLAN_END_DATE,@MEMO,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@ACTUAL_START_TIME,@ACTUAL_END_TIME,@MEMO1,@MEMO2,@MEMO3)");
                    SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@ORDER_SLIP_NUNBER", SqlDbType.VarChar,50),			
					new SqlParameter("@SLIP_TYPE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@DESCRIPTION", SqlDbType.VarChar,50),
					new SqlParameter("@PLAN_NUMBER", SqlDbType.Int,9),
					new SqlParameter("@PLAN_START_DATE", SqlDbType.DateTime),
					new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime),
					new SqlParameter("@MEMO", SqlDbType.VarChar,50),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,50),			
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,50),                    
               		new SqlParameter("@ACTUAL_START_TIME", SqlDbType.DateTime),
        		    new SqlParameter("@ACTUAL_END_TIME", SqlDbType.DateTime),
                	new SqlParameter("@MEMO1", SqlDbType.VarChar,50),
                    new SqlParameter("@MEMO2", SqlDbType.VarChar,50),
                    new SqlParameter("@MEMO3", SqlDbType.VarChar,50)};
                    parameters[0].Value = headerModel.SLIP_NUMBER;
                    parameters[1].Value = headerModel.ORDER_SLIP_NUNBER;
                    parameters[2].Value = headerModel.SLIP_TYPE_CODE;
                    parameters[3].Value = headerModel.SPEC;
                    parameters[4].Value = headerModel.PLAN_QUANTITY;
                    parameters[5].Value = headerModel.PLAN_START_DATE;
                    parameters[6].Value = headerModel.PLAN_END_DATE;
                    parameters[7].Value = headerModel.MEMO;
                    parameters[8].Value = CConstant.INIT;
                    parameters[9].Value = headerModel.CREATE_USER;
                    parameters[10].Value = headerModel.LAST_UPDATE_USER;
                    parameters[11].Value = headerModel.ACTUAL_START_TIME;
                    parameters[12].Value = headerModel.ACTUAL_END_TIME;
                    parameters[13].Value = headerModel.MEMO1;
                    parameters[14].Value = headerModel.MEMO2;
                    parameters[15].Value = headerModel.MEMO3;
                    listSql.Add(new CommandInfo(strSql.ToString(), parameters));

                    //明细插入
                    foreach (BaseProductionPlanLineTable lineModel in headerModel.Items)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_PRODUCTION_SCHEDULE_LINE(");
                        strSql.Append(" SLIP_NUMBER,LINE_NUMBER,PARTS_CODE,PLAN_START_DATE,PLAN_END_DATE,PLAN_NUMBER,SCHEDULE_FLAG,STATUS_FLAG,ACTUAL_START_TIME,ACTUAL_END_TIME)");
                        strSql.Append(" values (");
                        strSql.Append(" @SLIP_NUMBER,@LINE_NUMBER,@PARTS_CODE,@PLAN_START_DATE,@PLAN_END_DATE,@PLAN_NUMBER,@SCHEDULE_FLAG,@STATUS_FLAG,@ACTUAL_START_TIME,@ACTUAL_END_TIME)");
                        SqlParameter[] lineParameters = {
                            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9),
                            new SqlParameter("@PARTS_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@PLAN_START_DATE", SqlDbType.DateTime),
                            new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime),
                            new SqlParameter("@PLAN_NUMBER", SqlDbType.Int,9),
                            new SqlParameter("@SCHEDULE_FLAG", SqlDbType.Int,9),
                            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,20),
                            new SqlParameter("@ACTUAL_START_TIME", SqlDbType.DateTime),
                            new SqlParameter("@ACTUAL_END_TIME", SqlDbType.DateTime)};
                        lineParameters[0].Value = headerModel.SLIP_NUMBER;
                        lineParameters[1].Value = lineModel.LINE_NUMBER;
                        lineParameters[2].Value = lineModel.PARTS_CODE;
                        lineParameters[3].Value = lineModel.PLAN_START_DATE;
                        lineParameters[4].Value = lineModel.PLAN_END_DATE;
                        lineParameters[5].Value = lineModel.PLAN_NUMBER;
                        lineParameters[6].Value = lineModel.SCHEDULE_FLAG;
                        lineParameters[7].Value = CConstant.INIT;
                        lineParameters[8].Value = lineModel.ACTUAL_START_TIME;
                        lineParameters[9].Value = lineModel.ACTUAL_END_TIME;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
                    }

                    foreach (BaseProductionPlanDrawingLineTable lineModel in headerModel.ItemsDrawing)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_PRODUCTION_SCHEDULE_DRAWING_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,DRAWING_CODE,PLAN_END_DATE,STATUS_FLAG,ACTUAL_START_TIME,ACTUAL_END_TIME)");
                        strSql.Append(" values (");
                        strSql.Append(" @SLIP_NUMBER,@LINE_NUMBER,@DRAWING_CODE,@PLAN_END_DATE,@STATUS_FLAG,@ACTUAL_START_TIME,@ACTUAL_END_TIME)");
                        SqlParameter[] lineDrawingParameters = {
                            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9),
                            new SqlParameter("@DRAWING_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime),                          
                            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,20),
                            new SqlParameter("@ACTUAL_START_TIME", SqlDbType.DateTime),
                            new SqlParameter("@ACTUAL_END_TIME", SqlDbType.DateTime)};
                        lineDrawingParameters[0].Value = headerModel.SLIP_NUMBER;
                        lineDrawingParameters[1].Value = lineModel.LINE_NUMBER;
                        lineDrawingParameters[2].Value = lineModel.DRAWING_CODE;
                        lineDrawingParameters[3].Value = lineModel.PLAN_END_DATE;
                        lineDrawingParameters[4].Value = CConstant.INIT;
                        lineDrawingParameters[5].Value = lineModel.ACTUAL_START_TIME;
                        lineDrawingParameters[6].Value = lineModel.ACTUAL_END_TIME;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineDrawingParameters));
                    }
                    foreach (BaseProductionPlanLineTable lineTable in headerModel.Items)
                    // foreach (BaseProductionScheduleProductionProcessTable lineModel in headerModel.ItemsProductionProcess)
                    {
                        foreach (BaseProductionScheduleProductionProcessTable lineModel in lineTable.ProductionProcess)
                        {
                            strSql = new StringBuilder();
                            strSql.Append("insert into BLL_PRODUCTION_SCHEDULE_PRODUCTION_PROCESS(");
                            strSql.Append("SLIP_NUMBER,SCHEDULE_LINE_NUNBER,LINE_NUMBER,PRODUCTION_PROCESS_CODE,PLAN_START_DATE,PLAN_END_DATE,STATUS_FLAG,ACTUAL_START_TIME,ACTUAL_END_TIME)");
                            strSql.Append(" values (");
                            strSql.Append("@SLIP_NUMBER,@SCHEDULE_LINE_NUNBER,@LINE_NUMBER,@PRODUCTION_PROCESS_CODE,@PLAN_START_DATE,@PLAN_END_DATE,@STATUS_FLAG,@ACTUAL_START_TIME,@ACTUAL_END_TIME)");
                            SqlParameter[] lineProductionProcessParameters = {
                            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                            new SqlParameter("@SCHEDULE_LINE_NUNBER", SqlDbType.Int,9),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9),
                            new SqlParameter("@PRODUCTION_PROCESS_CODE", SqlDbType.VarChar,50),                                         
                            new SqlParameter("@PLAN_START_DATE", SqlDbType.DateTime),
                            new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime),
                            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
                            new SqlParameter("@ACTUAL_START_TIME", SqlDbType.DateTime),
                            new SqlParameter("@ACTUAL_END_TIME", SqlDbType.DateTime)};
                            lineProductionProcessParameters[0].Value = headerModel.SLIP_NUMBER;
                            lineProductionProcessParameters[1].Value = lineModel.SCHEDULE_LINE_NUNBER;
                            lineProductionProcessParameters[2].Value = lineModel.LINE_NUMBER;
                            lineProductionProcessParameters[3].Value = lineModel.PRODUCTION_PROCESS_CODE;
                            lineProductionProcessParameters[4].Value = lineModel.PLAN_START_DATE;
                            lineProductionProcessParameters[5].Value = lineModel.PLAN_END_DATE;
                            lineProductionProcessParameters[6].Value = CConstant.INIT;
                            lineProductionProcessParameters[7].Value = lineModel.ACTUAL_START_TIME;
                            lineProductionProcessParameters[8].Value = lineModel.ACTUAL_END_TIME;
                            listSql.Add(new CommandInfo(strSql.ToString(), lineProductionProcessParameters));
                        }
                    }

                    foreach (BaseProductionPlanLineTable lineTable in headerModel.Items)
                    {
                        foreach (BaseProductionScheduleProductionProcessTable lineModel in lineTable.ProductionProcess)
                        {
                            foreach (BaseProductionTechnologyTable lineTechnologyModel in lineModel.ProductionTechnology)
                            {
                                strSql = new StringBuilder();
                                strSql.Append("insert into BLL_PRODUCTION_SCHEDULE_TECHNOLOGY(");
                                strSql.Append("SLIP_NUMBER,SCHEDULE_LINE_NUMBER,SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER,TECHNOLOGY_LINE_NUMBER,TECHNOLOGY_CODE,STATUS_FLAG,PLAN_START_DATE,PLAN_END_DATE,ACTUAL_START_TIME,ACTUAL_END_TIME)");
                                strSql.Append(" values (");
                                strSql.Append("@SLIP_NUMBER,@SCHEDULE_LINE_NUMBER,@SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER,@TECHNOLOGY_LINE_NUMBER,@TECHNOLOGY_CODE,@STATUS_FLAG,@PLAN_START_DATE,@PLAN_END_DATE,@ACTUAL_START_TIME,@ACTUAL_END_TIME)");
                                SqlParameter[] lineTechnologyParameters = {
                                new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                                new SqlParameter("@SCHEDULE_LINE_NUMBER", SqlDbType.Int,9),
                                new SqlParameter("@SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER", SqlDbType.Int,9),
                                new SqlParameter("@TECHNOLOGY_LINE_NUMBER", SqlDbType.Int,9),
                                new SqlParameter("@TECHNOLOGY_CODE", SqlDbType.VarChar,50), 
                                new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),        
                                new SqlParameter("@PLAN_START_DATE", SqlDbType.DateTime),
                                new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime),                               
                                new SqlParameter("@ACTUAL_START_TIME", SqlDbType.DateTime),
                                new SqlParameter("@ACTUAL_END_TIME", SqlDbType.DateTime)};
                                lineTechnologyParameters[0].Value = headerModel.SLIP_NUMBER;
                                lineTechnologyParameters[1].Value = lineTechnologyModel.SCHEDULE_LINE_NUMBER;
                                lineTechnologyParameters[2].Value = lineTechnologyModel.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER;
                                lineTechnologyParameters[3].Value = lineTechnologyModel.LINE_NUMBER;
                                lineTechnologyParameters[4].Value = lineTechnologyModel.TECHNOLOGY_CODE;
                                lineTechnologyParameters[5].Value = CConstant.INIT;
                                lineTechnologyParameters[6].Value = lineTechnologyModel.PLAN_START_DATE;
                                lineTechnologyParameters[7].Value = lineTechnologyModel.PLAN_END_DATE;
                                lineTechnologyParameters[8].Value = lineTechnologyModel.ACTUAL_START_TIME;
                                lineTechnologyParameters[9].Value = lineTechnologyModel.ACTUAL_END_TIME;
                                listSql.Add(new CommandInfo(strSql.ToString(), lineTechnologyParameters));
                            }
                        }
                    }

                    foreach (BllOrderLineTable orderline in bOrderHeader.Items)
                    {

                        strSql = new StringBuilder();
                        strSql.Append("update BLL_ORDER_LINE set ");
                        strSql.Append("ALLOATION_QUANTITY=@ALLOATION_QUANTITY");
                        strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                        strSql.Append("  AND  LINE_NUMBER=@LINE_NUMBER ");
                        SqlParameter[] orderLineParam = {
                        new SqlParameter("@ALLOATION_QUANTITY", SqlDbType.Decimal),
                        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
                        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9)};
                        orderLineParam[0].Value = orderline.ALLOATION_QUANTITY;
                        orderLineParam[1].Value = orderline.SLIP_NUMBER;
                        orderLineParam[2].Value = orderline.LINE_NUMBER;
                        listSql.Add(new CommandInfo(strSql.ToString(), orderLineParam));
                    }
                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                    break;
                }
                catch (SqlException ex)
                {
                    headerModel.SLIP_NUMBER = DateTime.Now.ToString("yyyyMMdd") + (CConvert.ToInt32(GetMaxSlipNumber()) + 1).ToString().PadLeft(4, '0');
                    i++;
                    if (i == 10)
                    {
                        throw ex;
                    }
                    continue;
                }
                break;
            }
            if (result <= 0)
            {
                return null;
            }
            return headerModel.SLIP_NUMBER;
        }

        public DataSet GetProductionPlanHeader(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM bll_production_schedule_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
                strSql.Append("order by T.SLIP_NUMBER DESC");
            }
            strSql.Append(")AS Row, T.* from bll_production_schedule_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_production_schedule_view");
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
        /// 得到一个对象实体
        /// </summary>
        public BaseProductionPlanTable GetModel(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from bll_production_schedule_model_view ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            strSql.Append(" order by LINE_NUMBER ,PSPP_LINE_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;
            BaseProductionPlanTable model = null;
            BaseProductionPlanLineTable modelLine = new BaseProductionPlanLineTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            bool isFirst = true;
            int currentLineNumber = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (isFirst)
                {
                    isFirst = false;
                    model = new BaseProductionPlanTable();
                    model.SLIP_NUMBER = dr["SLIP_NUMBER"].ToString();
                    model.ORDER_SLIP_NUNBER = dr["ORDER_SLIP_NUNBER"].ToString();
                    if (dr["SLIP_DATE"].ToString() != "")
                    {
                        model.SLIP_DATE = DateTime.Parse(dr["SLIP_DATE"].ToString());
                    }
                    model.SLIP_TYPE_CODE = dr["SLIP_TYPE_CODE"].ToString();
                    model.SPEC = dr["DESCRIPTION"].ToString();
                    if (dr["PLAN_NUMBER"].ToString() != "")
                    {
                        model.PLAN_QUANTITY = decimal.Parse(dr["PLAN_NUMBER"].ToString());
                    }
                    if (dr["PLAN_START_DATE"].ToString() != "")
                    {
                        model.PLAN_START_DATE = DateTime.Parse(dr["PLAN_START_DATE"].ToString());
                    }
                    if (dr["PLAN_END_DATE"].ToString() != "")
                    {
                        model.PLAN_END_DATE = DateTime.Parse(dr["PLAN_END_DATE"].ToString());
                    }
                    if (dr["ACTUAL_START_TIME"].ToString() != "")
                    {
                        model.ACTUAL_START_TIME = DateTime.Parse(dr["ACTUAL_START_TIME"].ToString());
                    }
                    if (dr["ACTUAL_END_TIME"].ToString() != "")
                    {
                        model.ACTUAL_END_TIME = DateTime.Parse(dr["ACTUAL_END_TIME"].ToString());
                    }
                    model.MEMO = dr["MEMO"].ToString();
                    model.MEMO1 = dr["MEMO1"].ToString();
                    model.MEMO2 = dr["MEMO2"].ToString();
                    model.MEMO3 = dr["MEMO3"].ToString();
                    if (dr["STATUS_FLAG"].ToString() != "")
                    {
                        model.STATUS_FLAG = int.Parse(dr["STATUS_FLAG"].ToString());
                    }
                    model.CREATE_USER = dr["CREATE_USER"].ToString();
                    if (dr["CREATE_DATE_TIME"].ToString() != "")
                    {
                        model.CREATE_DATE_TIME = DateTime.Parse(dr["CREATE_DATE_TIME"].ToString());
                    }
                    if (dr["LAST_UPDATE_TIME"].ToString() != "")
                    {
                        model.LAST_UPDATE_TIME = DateTime.Parse(dr["LAST_UPDATE_TIME"].ToString());
                    }
                    model.LAST_UPDATE_USER = dr["LAST_UPDATE_USER"].ToString();
                    model.SLIP_TYPE_NAME = dr["SLIP_TYPE_NAME"].ToString();
                }
                int lineNumber = CConvert.ToInt32(dr["LINE_NUMBER"]);
                if (currentLineNumber != lineNumber)
                {
                    if (currentLineNumber != 0)
                    {
                        model.AddItem(modelLine);
                    }
                    currentLineNumber = lineNumber;
                    modelLine = new BaseProductionPlanLineTable();
                    modelLine.LINE_NUMBER = lineNumber;
                    modelLine.PARTS_CODE = dr["PARTS_CODE"].ToString();
                    if (dr["PSL_PLAN_START_DATE"].ToString() != "")
                    {
                        modelLine.PLAN_START_DATE = DateTime.Parse(dr["PSL_PLAN_START_DATE"].ToString());
                    }
                    if (dr["PSL_PLAN_END_DATE"].ToString() != "")
                    {
                        modelLine.PLAN_END_DATE = DateTime.Parse(dr["PSL_PLAN_END_DATE"].ToString());
                    }
                    if (dr["PSL_PLAN_NUMBER"].ToString() != "")
                    {
                        modelLine.PLAN_NUMBER = decimal.Parse(dr["PSL_PLAN_NUMBER"].ToString());
                    }
                    if (dr["SCHEDULE_FLAG"].ToString() != "")
                    {
                        modelLine.SCHEDULE_FLAG = int.Parse(dr["SCHEDULE_FLAG"].ToString());
                    }
                    if (dr["PSL_ACTUAL_START_TIME"].ToString() != "")
                    {
                        modelLine.ACTUAL_START_TIME = DateTime.Parse(dr["PSL_ACTUAL_START_TIME"].ToString());
                    }
                    if (dr["PSL_ACTUAL_END_TIME"].ToString() != "")
                    {
                        modelLine.ACTUAL_END_TIME = DateTime.Parse(dr["PSL_ACTUAL_END_TIME"].ToString());
                    }
                    if (dr["PSL_STATUS_FLAG"].ToString() != "")
                    {
                        modelLine.STATUS_FLAG = int.Parse(dr["PSL_STATUS_FLAG"].ToString());
                    }
                    modelLine.PARTS_NAME = dr["PARTS_NAME"].ToString();
                }

                BaseProductionScheduleProductionProcessTable productionprocessTable = new BaseProductionScheduleProductionProcessTable();
                if (dr["PSPP_LINE_NUMBER"].ToString() != "")
                {
                    productionprocessTable.LINE_NUMBER = int.Parse(dr["PSPP_LINE_NUMBER"].ToString());
                }
                if (dr["SCHEDULE_LINE_NUNBER"].ToString() != "")
                {
                    productionprocessTable.SCHEDULE_LINE_NUNBER = int.Parse(dr["SCHEDULE_LINE_NUNBER"].ToString());
                }
                productionprocessTable.PRODUCTION_PROCESS_CODE = dr["PRODUCTION_PROCESS_CODE"].ToString();
                if (dr["PSPP_PLAN_START_DATE"].ToString() != "")
                {
                    productionprocessTable.PLAN_START_DATE = DateTime.Parse(dr["PSPP_PLAN_START_DATE"].ToString());
                }
                if (dr["PSPP_PLAN_END_DATE"].ToString() != "")
                {
                    productionprocessTable.PLAN_END_DATE = DateTime.Parse(dr["PSPP_PLAN_END_DATE"].ToString());
                }
                if (dr["PSPP_STATUS_FLAG"].ToString() != "")
                {
                    productionprocessTable.STATUS_FLAG = int.Parse(dr["PSPP_STATUS_FLAG"].ToString());
                }
                if (dr["PSPP_ACTUAL_START_TIME"].ToString() != "")
                {
                    productionprocessTable.ACTUAL_START_TIME = DateTime.Parse(dr["PSPP_ACTUAL_START_TIME"].ToString());
                }
                if (dr["PSPP_ACTUAL_END_TIME"].ToString() != "")
                {
                    productionprocessTable.ACTUAL_END_TIME = DateTime.Parse(dr["PSPP_ACTUAL_END_TIME"].ToString());
                }
                productionprocessTable.PRODUCTION_PROCESS_NAME = dr["PRODUCTION_PROCESS_NAME"].ToString();
                productionprocessTable.DEPARTMENT_CODE = dr["DEPARTMENT_CODE"].ToString();
                productionprocessTable.DEPARTMENT_NAME = dr["DEPARTMENT_NAME"].ToString();
                productionprocessTable.PRODUCTION_CYCLE = CConvert.ToDecimal(dr["PRODUCTION_CYCLE"].ToString());
                modelLine.AddProductionProcess(productionprocessTable);
            }

            if (model != null)
            {
                model.AddItem(modelLine);
            }

            return model;

        }

        public string Update(BaseProductionPlanTable headerModel)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(" UPDATE BLL_PRODUCTION_SCHEDULE SET");
                    strSql.Append(" PLAN_END_DATE=@PLAN_END_DATE");
                    strSql.Append(" WHERE SLIP_NUMBER=@SLIP_NUMBER");
                    SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime)};
                    parameters[0].Value = headerModel.SLIP_NUMBER;
                    parameters[1].Value = headerModel.PLAN_END_DATE;
                    listSql.Add(new CommandInfo(strSql.ToString(), parameters));

                    //明细插入
                    foreach (BaseProductionPlanLineTable lineModel in headerModel.Items)
                    {
                        strSql = new StringBuilder();
                        strSql.Append(" UPDATE BLL_PRODUCTION_SCHEDULE_LINE SET");
                        strSql.Append(" PLAN_START_DATE=@PLAN_START_DATE,PLAN_END_DATE=@PLAN_END_DATE");
                        strSql.Append(" WHERE SLIP_NUMBER=@SLIP_NUMBER");
                        strSql.Append(" AND LINE_NUMBER=@LINE_NUMBER");
                        SqlParameter[] lineParameters = {
                        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9),
                        new SqlParameter("@PLAN_START_DATE", SqlDbType.DateTime),
                        new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime)};
                        lineParameters[0].Value = headerModel.SLIP_NUMBER;
                        lineParameters[1].Value = lineModel.LINE_NUMBER;
                        lineParameters[2].Value = lineModel.PLAN_START_DATE;
                        lineParameters[3].Value = lineModel.PLAN_END_DATE;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
                    }

                    foreach (BaseProductionPlanDrawingLineTable lineModel in headerModel.ItemsDrawing)
                    {
                        strSql = new StringBuilder();
                        strSql.Append(" UPDATE BLL_PRODUCTION_SCHEDULE_DRAWING_LINE SET");
                        strSql.Append(" PLAN_END_DATE=@PLAN_END_DATE");
                        strSql.Append(" WHERE SLIP_NUMBER=@SLIP_NUMBER");
                        strSql.Append(" AND LINE_NUMBER=@LINE_NUMBER");
                        SqlParameter[] lineDrawingParameters = {
                            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9),                        
                            new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime)};
                        lineDrawingParameters[0].Value = headerModel.SLIP_NUMBER;
                        lineDrawingParameters[1].Value = lineModel.LINE_NUMBER;
                        lineDrawingParameters[2].Value = lineModel.PLAN_END_DATE;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineDrawingParameters));
                    }
                    foreach (BaseProductionPlanLineTable lineTable in headerModel.Items)
                    {
                        foreach (BaseProductionScheduleProductionProcessTable lineModel in lineTable.ProductionProcess)
                        {
                            strSql = new StringBuilder();
                            strSql.Append(" UPDATE BLL_PRODUCTION_SCHEDULE_PRODUCTION_PROCESS SET");
                            strSql.Append(" PLAN_START_DATE=@PLAN_START_DATE,PLAN_END_DATE=@PLAN_END_DATE");
                            strSql.Append(" WHERE SLIP_NUMBER=@SLIP_NUMBER");
                            strSql.Append(" AND SCHEDULE_LINE_NUNBER=@SCHEDULE_LINE_NUNBER");
                            strSql.Append(" AND LINE_NUMBER=@LINE_NUMBER");
                            SqlParameter[] lineProductionProcessParameters = {
                            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                            new SqlParameter("@SCHEDULE_LINE_NUNBER", SqlDbType.Int,9),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,9),                                                            
                            new SqlParameter("@PLAN_START_DATE", SqlDbType.DateTime),
                            new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime)};
                            lineProductionProcessParameters[0].Value = headerModel.SLIP_NUMBER;
                            lineProductionProcessParameters[1].Value = lineModel.SCHEDULE_LINE_NUNBER;
                            lineProductionProcessParameters[2].Value = lineModel.LINE_NUMBER;
                            lineProductionProcessParameters[3].Value = lineModel.PLAN_START_DATE;
                            lineProductionProcessParameters[4].Value = lineModel.PLAN_END_DATE;
                            listSql.Add(new CommandInfo(strSql.ToString(), lineProductionProcessParameters));
                        }
                    }

                    foreach (BaseProductionPlanLineTable lineTable in headerModel.Items)
                    {
                        foreach (BaseProductionScheduleProductionProcessTable lineModel in lineTable.ProductionProcess)
                        {
                            foreach (BaseProductionTechnologyTable lineTechnologyModel in lineModel.ProductionTechnology)
                            {
                                strSql = new StringBuilder();
                                strSql.Append(" UPDATE BLL_PRODUCTION_SCHEDULE_TECHNOLOGY SET");
                                strSql.Append(" PLAN_END_DATE=@PLAN_END_DATE");
                                strSql.Append(" WHERE SLIP_NUMBER=@SLIP_NUMBER");
                                strSql.Append(" AND SCHEDULE_LINE_NUMBER=@SCHEDULE_LINE_NUMBER");
                                strSql.Append(" AND SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER=@SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER");
                                strSql.Append(" AND TECHNOLOGY_LINE_NUMBER=@TECHNOLOGY_LINE_NUMBER");
                                SqlParameter[] lineTechnologyParameters = {
                                new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                                new SqlParameter("@SCHEDULE_LINE_NUMBER", SqlDbType.Int,9),
                                new SqlParameter("@SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER", SqlDbType.Int,9),
                                new SqlParameter("@TECHNOLOGY_LINE_NUMBER", SqlDbType.Int,9),
                                new SqlParameter("@PLAN_END_DATE", SqlDbType.DateTime)};
                                lineTechnologyParameters[0].Value = headerModel.SLIP_NUMBER;
                                lineTechnologyParameters[1].Value = lineTechnologyModel.SCHEDULE_LINE_NUMBER;
                                lineTechnologyParameters[2].Value = lineTechnologyModel.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER;
                                lineTechnologyParameters[3].Value = lineTechnologyModel.LINE_NUMBER;
                                lineTechnologyParameters[4].Value = lineTechnologyModel.PLAN_END_DATE;
                                listSql.Add(new CommandInfo(strSql.ToString(), lineTechnologyParameters));
                            }
                        }
                    }
                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                    break;
                }
                catch (SqlException ex)
                {
                    headerModel.SLIP_NUMBER = DateTime.Now.ToString("yyyyMMdd") + (CConvert.ToInt32(GetMaxSlipNumber()) + 1).ToString().PadLeft(4, '0');
                    i++;
                    if (i == 10)
                    {
                        throw ex;
                    }
                    continue;
                }
                break;
            }
            if (result <= 0)
            {
                return null;
            }
            return headerModel.SLIP_NUMBER;
        }

        public int Pause(string SLIP_NUMBER, string status)
        {
            int resultschedule = 0;
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLL_PRODUCTION_SCHEDULE set ");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            SqlParameter[] planparameters = {			
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,9),
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            if (status.Equals(CConvert.ToString(CConstant.PAUSE)))
            {
                planparameters[0].Value = CConstant.NORMAL;
            }
            else
            {
                planparameters[0].Value = CConstant.PAUSE;
            }

            planparameters[1].Value = SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), planparameters));
            resultschedule = DbHelperSQL.ExecuteSqlTran(listSql);
            return resultschedule;
        }
    }//end class
}
