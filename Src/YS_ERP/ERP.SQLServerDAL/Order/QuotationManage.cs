using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Common;
using System.Data.SqlClient;
using System.Data;
using CZZD.ERP.IDAL;

namespace CZZD.ERP.SQLServerDAL
{
    public class QuotationManage : IQuotation
    {
        //获得最大ID号
        public string GetMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(MAX(T.SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from (");
            strSql.Append(" SELECT CASE len(SLIP_NUMBER) WHEN 0 THEN '0' WHEN 1 THEN '0' WHEN 2 THEN '0' WHEN 3 THEN '0' ELSE RIGHT(SLIP_NUMBER, 4) END AS SLIP_NUMBER ");
            strSql.Append("FROM BLL_QUOTATION ");
            strSql.Append(" WHERE (LEFT(SLIP_NUMBER, 8) = CAST(YEAR(GETDATE()) AS NVARCHAR) + CAST(RIGHT(100 + MONTH(GETDATE()), 2) AS NVARCHAR) + CAST(RIGHT(100 + DAY(GETDATE()), 2) AS NVARCHAR))) T");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BLL_QUOTATION");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BllQuotationTable model)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into BLL_QUOTATION(");
                    strSql.Append("SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,CUSTOMER_CODE,QUANTITY,CURRENCY_CODE,COMPANY_CODE,AMOUNT_INCLUDED_TAX,AMOUNT_WITHOUT_TAX,TAX_RATE,TAX_AMOUNT,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,ORDER_FLAG,DISCOUNT_RATE,ENQUIRY_METHOD,ENQUIRY_DATE,DELIVERY_PERIOD,DELIVERY_TERMS,PAYMENT_TERMS,DISCOUNT_AMOUNT,VER,UPDATE_COUNT,TO_CUSTOMER_MEMO)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@SLIP_TYPE,@CUSTOMER_CODE,@QUANTITY,@CURRENCY_CODE,@COMPANY_CODE,@AMOUNT_INCLUDED_TAX,@AMOUNT_WITHOUT_TAX,@TAX_RATE,@TAX_AMOUNT,@MEMO,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@ORDER_FLAG,@DISCOUNT_RATE,@ENQUIRY_METHOD,@ENQUIRY_DATE,@DELIVERY_PERIOD,@DELIVERY_TERMS,@PAYMENT_TERMS,@DISCOUNT_AMOUNT,@VER,@UPDATE_COUNT,@TO_CUSTOMER_MEMO)");
                    SqlParameter[] parameters = {
					    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					    new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),					   
					    new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					    new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),					    
					    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					    new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					    new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					    new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					    new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                        new SqlParameter("@ORDER_FLAG", SqlDbType.Int,4),
                        new SqlParameter("@DISCOUNT_RATE", SqlDbType.Decimal,5),
                        new SqlParameter("@ENQUIRY_METHOD", SqlDbType.VarChar,20),
                        new SqlParameter("@ENQUIRY_DATE", SqlDbType.DateTime),
                        new SqlParameter("@DELIVERY_PERIOD", SqlDbType.VarChar,255),
                        new SqlParameter("@DELIVERY_TERMS", SqlDbType.VarChar,255),
                        new SqlParameter("@PAYMENT_TERMS", SqlDbType.VarChar,255),
                        new SqlParameter("@DISCOUNT_AMOUNT", SqlDbType.Decimal,10),
                        new SqlParameter("@VER", SqlDbType.VarChar,50),    
                        new SqlParameter("@UPDATE_COUNT", SqlDbType.Int), 
                        new SqlParameter("@TO_CUSTOMER_MEMO", SqlDbType.Text)
                                                };
                    parameters[0].Value = model.SLIP_NUMBER;
                    parameters[1].Value = model.SLIP_DATE;
                    parameters[2].Value = model.SLIP_TYPE;
                    parameters[3].Value = model.CUSTOMER_CODE;
                    parameters[4].Value = model.QUANTITY;
                    parameters[5].Value = model.CURRENCY_CODE;
                    parameters[6].Value = model.COMPANY_CODE;
                    parameters[7].Value = model.AMOUNT_INCLUDED_TAX;
                    parameters[8].Value = model.AMOUNT_WITHOUT_TAX;
                    parameters[9].Value = model.TAX_RATE;
                    parameters[10].Value = model.TAX_AMOUNT;
                    parameters[11].Value = model.MEMO;
                    parameters[12].Value = CConstant.INIT;
                    parameters[13].Value = model.CREATE_USER;
                    parameters[14].Value = model.LAST_UPDATE_USER;
                    parameters[15].Value = model.ORDER_FLAG;
                    parameters[16].Value = model.DISCOUNT_RATE;
                    parameters[17].Value = model.ENQUIRY_METHOD;
                    parameters[18].Value = model.ENQUIRY_DATE;
                    parameters[19].Value = model.DELIVERY_PERIOD;
                    parameters[20].Value = model.DELIVERY_TERMS;
                    parameters[21].Value = model.PAYMENT_TERMS;
                    parameters[22].Value = model.DISCOUNT_AMOUNT;
                    parameters[23].Value = model.VER;
                    parameters[24].Value = model.UPDATE_COUNT;
                    parameters[25].Value = model.TO_CUSTOMER_MEMO;
                    listSql.Add(new CommandInfo(strSql.ToString(), parameters));

                    //明细插入
                    foreach (BllQuotationLineTable lineModel in model.Items)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_QUOTATION_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT,MEMO,STATUS_FLAG,DESCRIPTION,SPEC,DISCOUNT,METERIAL,PARTS_CODE,DESCRIPTION1)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT,@MEMO,@STATUS_FLAG,@DESCRIPTION,@SPEC,@DISCOUNT,@METERIAL,@PARTS_CODE,@DESCRIPTION1)");
                        SqlParameter[] lineParam = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					        new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),					  
					        new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@DESCRIPTION", SqlDbType.VarChar,255),
					        new SqlParameter("@SPEC", SqlDbType.VarChar,250),          
                            new SqlParameter("@DISCOUNT", SqlDbType.Decimal,10),
                            new SqlParameter("@METERIAL", SqlDbType.VarChar,255),
                            new SqlParameter("@PARTS_CODE", SqlDbType.VarChar,255),
                            new SqlParameter("@DESCRIPTION1", SqlDbType.VarChar,255)};
                        lineParam[0].Value = lineModel.SLIP_NUMBER;
                        lineParam[1].Value = lineModel.LINE_NUMBER;
                        lineParam[2].Value = lineModel.PRODUCT_CODE;
                        lineParam[3].Value = lineModel.QUANTITY;
                        lineParam[4].Value = lineModel.UNIT_CODE;
                        lineParam[5].Value = lineModel.PRICE;
                        lineParam[6].Value = lineModel.AMOUNT;
                        lineParam[7].Value = lineModel.MEMO;
                        lineParam[8].Value = CConstant.INIT;
                        lineParam[9].Value = lineModel.DESCRIPTION;
                        lineParam[10].Value = lineModel.SPEC;
                        lineParam[11].Value = lineModel.PRICE_DISCOUNT;
                        lineParam[12].Value = lineModel.METERIAL;
                        lineParam[13].Value = lineModel.PARTS_CODE;
                        lineParam[14].Value = lineModel.DESCRIPTION1;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParam));
                    }

                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                    break;
                }
                catch (SqlException ex)
                {
                    model.SLIP_NUMBER = DateTime.Now.ToString("yyyyMMdd") + (CConvert.ToInt32(GetMaxSlipNumber()) + 1).ToString().PadLeft(4, '0');
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
            return model.SLIP_NUMBER;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BllQuotationTable QuotationModel)
        {
            int result = 0;
            List<CommandInfo> listSql = null;
            StringBuilder strSql = null;
            //原有订单数据的取得
            BllQuotationTable oldModel = GetModel(QuotationModel.SLIP_NUMBER);

            int i = 0;
            while (i < 10)
            {
                listSql = new List<CommandInfo>();

                //History表数据的插入
                #region
                //现有最大ID的取得
                int historyMaxID = DbHelperSQL.GetMaxID("HISTORY_NUMBER", "BLL_HISTORY_QUOTATION");

                strSql = new StringBuilder();
                strSql.Append("insert into BLL_HISTORY_QUOTATION(");
                strSql.Append("HISTORY_NUMBER,SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,CUSTOMER_CODE,QUANTITY,CURRENCY_CODE,COMPANY_CODE,AMOUNT_INCLUDED_TAX,AMOUNT_WITHOUT_TAX,TAX_RATE,TAX_AMOUNT,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,ORDER_FLAG,DISCOUNT_RATE,ENQUIRY_METHOD,ENQUIRY_DATE,DELIVERY_PERIOD,DELIVERY_TERMS,PAYMENT_TERMS,DISCOUNT_AMOUNT,VER,TO_CUSTOMER_MEMO)");
                strSql.Append(" values (");
                strSql.Append("@HISTORY_NUMBER,@SLIP_NUMBER,@SLIP_DATE,@SLIP_TYPE,@CUSTOMER_CODE,@QUANTITY,@CURRENCY_CODE,@COMPANY_CODE,@AMOUNT_INCLUDED_TAX,@AMOUNT_WITHOUT_TAX,@TAX_RATE,@TAX_AMOUNT,@MEMO,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@ORDER_FLAG,@DISCOUNT_RATE,@ENQUIRY_METHOD,@ENQUIRY_DATE,@DELIVERY_PERIOD,@DELIVERY_TERMS,@PAYMENT_TERMS,@DISCOUNT_AMOUNT,@VER,@TO_CUSTOMER_MEMO)");
                SqlParameter[] hisquotationParam = {
                       
                        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                        new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
                        new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),					   
                        new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                        new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),					    
                        new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
                        new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
                        new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
                        new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
                        new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
                        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                        new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
                        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                        new SqlParameter("@ORDER_FLAG", SqlDbType.Int,4),
                        new SqlParameter("@DISCOUNT_RATE", SqlDbType.Decimal,5),
                        new SqlParameter("@ENQUIRY_METHOD", SqlDbType.VarChar,20),
                        new SqlParameter("@ENQUIRY_DATE", SqlDbType.DateTime),
                        new SqlParameter("@DELIVERY_PERIOD", SqlDbType.VarChar,255),
                        new SqlParameter("@DELIVERY_TERMS", SqlDbType.VarChar,255),
                        new SqlParameter("@PAYMENT_TERMS", SqlDbType.VarChar,255),
                        new SqlParameter("@DISCOUNT_AMOUNT", SqlDbType.Decimal,10),                 
                        new SqlParameter("@VER", SqlDbType.VarChar,50) ,  
                         new SqlParameter("@HISTORY_NUMBER", SqlDbType.Int),
                         new SqlParameter("@TO_CUSTOMER_MEMO", SqlDbType.Text)
                                                   };
                hisquotationParam[0].Value = oldModel.SLIP_NUMBER;
                hisquotationParam[1].Value = oldModel.SLIP_DATE;
                hisquotationParam[2].Value = oldModel.SLIP_TYPE;
                hisquotationParam[3].Value = oldModel.CUSTOMER_CODE;
                hisquotationParam[4].Value = oldModel.QUANTITY;
                hisquotationParam[5].Value = oldModel.CURRENCY_CODE;
                hisquotationParam[6].Value = oldModel.COMPANY_CODE;
                hisquotationParam[7].Value = oldModel.AMOUNT_INCLUDED_TAX;
                hisquotationParam[8].Value = oldModel.AMOUNT_WITHOUT_TAX;
                hisquotationParam[9].Value = oldModel.TAX_RATE;
                hisquotationParam[10].Value = oldModel.TAX_AMOUNT;
                hisquotationParam[11].Value = oldModel.MEMO;
                hisquotationParam[12].Value = CConstant.INIT;
                hisquotationParam[13].Value = oldModel.CREATE_USER;
                hisquotationParam[14].Value = oldModel.LAST_UPDATE_USER;
                hisquotationParam[15].Value = oldModel.ORDER_FLAG;
                hisquotationParam[16].Value = oldModel.DISCOUNT_RATE;
                hisquotationParam[17].Value = oldModel.ENQUIRY_METHOD;
                hisquotationParam[18].Value = oldModel.ENQUIRY_DATE;
                hisquotationParam[19].Value = oldModel.DELIVERY_PERIOD;
                hisquotationParam[20].Value = oldModel.DELIVERY_TERMS;
                hisquotationParam[21].Value = oldModel.PAYMENT_TERMS;
                hisquotationParam[22].Value = oldModel.DISCOUNT_AMOUNT;
                hisquotationParam[23].Value = oldModel.VER;
                hisquotationParam[24].Value = historyMaxID;
                hisquotationParam[25].Value = oldModel.TO_CUSTOMER_MEMO;
                listSql.Add(new CommandInfo(strSql.ToString(), hisquotationParam));

                //明细插入
                foreach (BllQuotationLineTable lineModel in oldModel.Items)
                {
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_HISTORY_QUOTATION_LINE(");
                    strSql.Append("HISTORY_NUMBER,SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT,MEMO,STATUS_FLAG,DESCRIPTION,SPEC,DISCOUNT,METERIAL,PARTS_CODE,DESCRIPTION1)");
                    strSql.Append(" values (");
                    strSql.Append("@HISTORY_NUMBER,@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT,@MEMO,@STATUS_FLAG,@DESCRIPTION,@SPEC,@DISCOUNT,@METERIAL,@PARTS_CODE,@DESCRIPTION1)");
                    SqlParameter[] hisLineParameters = {
                         new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
                            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
                            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
                            new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),					  
                            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
                            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@DESCRIPTION", SqlDbType.VarChar,255),
                            new SqlParameter("@SPEC", SqlDbType.VarChar,250),          
                            new SqlParameter("@DISCOUNT", SqlDbType.Decimal,10),
                            new SqlParameter("@METERIAL", SqlDbType.VarChar,255),
                            new SqlParameter("@HISTORY_NUMBER", SqlDbType.Int,4),
                             new SqlParameter("@PARTS_CODE", SqlDbType.VarChar,255),
                             new SqlParameter("@DESCRIPTION1", SqlDbType.VarChar,255)};
                    hisLineParameters[0].Value = lineModel.SLIP_NUMBER;
                    hisLineParameters[1].Value = lineModel.LINE_NUMBER;
                    hisLineParameters[2].Value = lineModel.PRODUCT_CODE;
                    hisLineParameters[3].Value = lineModel.QUANTITY;
                    hisLineParameters[4].Value = lineModel.UNIT_CODE;
                    hisLineParameters[5].Value = lineModel.PRICE;
                    hisLineParameters[6].Value = lineModel.AMOUNT;
                    hisLineParameters[7].Value = lineModel.MEMO;
                    hisLineParameters[8].Value = CConstant.INIT;
                    hisLineParameters[9].Value = lineModel.DESCRIPTION;
                    hisLineParameters[10].Value = lineModel.SPEC;
                    hisLineParameters[11].Value = lineModel.PRICE_DISCOUNT;
                    hisLineParameters[12].Value = lineModel.METERIAL;
                    hisLineParameters[13].Value = historyMaxID;
                    hisLineParameters[14].Value = lineModel.PARTS_CODE;
                    hisLineParameters[15].Value = lineModel.DESCRIPTION1;
                    listSql.Add(new CommandInfo(strSql.ToString(), hisLineParameters));
                }
                #endregion

                //主表的更新
                #region 主表的更新
                strSql = new StringBuilder();
                strSql.Append("update BLL_QUOTATION set ");
                strSql.Append("SLIP_DATE=@SLIP_DATE,");
                strSql.Append("SLIP_TYPE=@SLIP_TYPE,");
                strSql.Append("CUSTOMER_CODE=@CUSTOMER_CODE,");
                strSql.Append("QUANTITY=@QUANTITY,");
                strSql.Append("CURRENCY_CODE=@CURRENCY_CODE,");
                strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
                strSql.Append("AMOUNT_INCLUDED_TAX=@AMOUNT_INCLUDED_TAX,");
                strSql.Append("AMOUNT_WITHOUT_TAX=@AMOUNT_WITHOUT_TAX,");
                strSql.Append("TAX_RATE=@TAX_RATE,");
                strSql.Append("TAX_AMOUNT=@TAX_AMOUNT,");
                strSql.Append("MEMO=@MEMO,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("ORDER_FLAG=@ORDER_FLAG, ");
                strSql.Append("DISCOUNT_RATE=@DISCOUNT_RATE, ");
                strSql.Append("ENQUIRY_METHOD=@ENQUIRY_METHOD, ");
                strSql.Append("ENQUIRY_DATE=@ENQUIRY_DATE, ");
                strSql.Append("DELIVERY_PERIOD=@DELIVERY_PERIOD, ");
                strSql.Append("DELIVERY_TERMS=@DELIVERY_TERMS, ");
                strSql.Append("PAYMENT_TERMS=@PAYMENT_TERMS, ");
                strSql.Append("DISCOUNT_AMOUNT=@DISCOUNT_AMOUNT, ");
                strSql.Append("VER=@VER, ");
                strSql.Append("UPDATE_COUNT=@UPDATE_COUNT, ");
                strSql.Append("TO_CUSTOMER_MEMO=@TO_CUSTOMER_MEMO ");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] quotationParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),					
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),					
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@ORDER_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@DISCOUNT_RATE", SqlDbType.Decimal,5),
                    new SqlParameter("@ENQUIRY_METHOD", SqlDbType.VarChar,20),
                    new SqlParameter("@ENQUIRY_DATE", SqlDbType.DateTime),
                    new SqlParameter("@DELIVERY_PERIOD", SqlDbType.VarChar,255),
                    new SqlParameter("@DELIVERY_TERMS", SqlDbType.VarChar,255),
                    new SqlParameter("@PAYMENT_TERMS", SqlDbType.VarChar,255),
                    new SqlParameter("@DISCOUNT_AMOUNT", SqlDbType.Decimal,9),                  
                    new SqlParameter("@VER", SqlDbType.VarChar,50),
                    new SqlParameter("@UPDATE_COUNT", SqlDbType.Int),
                    new SqlParameter("@TO_CUSTOMER_MEMO", SqlDbType.Text)};

                quotationParam[0].Value = QuotationModel.SLIP_NUMBER;
                quotationParam[1].Value = QuotationModel.SLIP_DATE;
                quotationParam[2].Value = QuotationModel.SLIP_TYPE;
                quotationParam[3].Value = QuotationModel.CUSTOMER_CODE;
                quotationParam[4].Value = QuotationModel.QUANTITY;
                quotationParam[5].Value = QuotationModel.CURRENCY_CODE;
                quotationParam[6].Value = QuotationModel.COMPANY_CODE;
                quotationParam[7].Value = QuotationModel.AMOUNT_INCLUDED_TAX;
                quotationParam[8].Value = QuotationModel.AMOUNT_WITHOUT_TAX;
                quotationParam[9].Value = QuotationModel.TAX_RATE;
                quotationParam[10].Value = QuotationModel.TAX_AMOUNT;
                quotationParam[11].Value = QuotationModel.MEMO;
                quotationParam[12].Value = CConstant.NORMAL;
                quotationParam[13].Value = QuotationModel.LAST_UPDATE_USER;
                quotationParam[14].Value = QuotationModel.ORDER_FLAG;
                quotationParam[15].Value = QuotationModel.DISCOUNT_RATE;
                quotationParam[16].Value = QuotationModel.ENQUIRY_METHOD;
                quotationParam[17].Value = QuotationModel.ENQUIRY_DATE;
                quotationParam[18].Value = QuotationModel.DELIVERY_PERIOD;
                quotationParam[19].Value = QuotationModel.DELIVERY_TERMS;
                quotationParam[20].Value = QuotationModel.PAYMENT_TERMS;
                quotationParam[21].Value = QuotationModel.DISCOUNT_AMOUNT;
                quotationParam[22].Value = QuotationModel.VER;
                quotationParam[23].Value = QuotationModel.UPDATE_COUNT;
                quotationParam[24].Value = QuotationModel.TO_CUSTOMER_MEMO;
                listSql.Add(new CommandInfo(strSql.ToString(), quotationParam));

                #endregion

                //明细数据的先删除
                #region
                strSql = new StringBuilder();
                strSql.AppendFormat("delete  from  BLL_QUOTATION_LINE ");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] deleteLineParameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                deleteLineParameters[0].Value = QuotationModel.SLIP_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), deleteLineParameters));
                #endregion

                //明细数据的重新插入
                #region
                foreach (BllQuotationLineTable lineModel in QuotationModel.Items)
                {
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_QUOTATION_LINE(");
                    strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT,MEMO,STATUS_FLAG,DESCRIPTION,SPEC,DISCOUNT,METERIAL,PARTS_CODE,DESCRIPTION1)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT,@MEMO,@STATUS_FLAG,@DESCRIPTION,@SPEC,@DISCOUNT,@METERIAL,@PARTS_CODE,@DESCRIPTION1)");
                    SqlParameter[] lineParam = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					        new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),
					        new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@DESCRIPTION", SqlDbType.VarChar,255),
					        new SqlParameter("@SPEC", SqlDbType.VarChar,250),          
                            new SqlParameter("@DISCOUNT", SqlDbType.Decimal,10),
                            new SqlParameter("@METERIAL", SqlDbType.VarChar,255),
                            new SqlParameter("@PARTS_CODE", SqlDbType.VarChar,255),
                            new SqlParameter("@DESCRIPTION1", SqlDbType.VarChar,255)};
                    lineParam[0].Value = lineModel.SLIP_NUMBER;
                    lineParam[1].Value = lineModel.LINE_NUMBER;
                    lineParam[2].Value = lineModel.PRODUCT_CODE;
                    lineParam[3].Value = lineModel.QUANTITY;
                    lineParam[4].Value = lineModel.UNIT_CODE;
                    lineParam[5].Value = lineModel.PRICE;
                    lineParam[6].Value = lineModel.AMOUNT;
                    lineParam[7].Value = lineModel.MEMO;
                    lineParam[8].Value = CConstant.NORMAL;
                    lineParam[9].Value = lineModel.DESCRIPTION;
                    lineParam[10].Value = lineModel.SPEC;
                    lineParam[11].Value = lineModel.PRICE_DISCOUNT;
                    lineParam[12].Value = lineModel.METERIAL;
                    lineParam[13].Value = lineModel.PARTS_CODE;
                    lineParam[14].Value = lineModel.DESCRIPTION1;
                    listSql.Add(new CommandInfo(strSql.ToString(), lineParam));
                }
                #endregion

                //执行事务
                try
                {
                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                }
                catch (Exception ex)
                {
                    i++;
                    if (i == 10)
                    {
                        throw ex;
                    }
                    continue;
                }
                break;
            }
            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string slipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_QUOTATION set STATUS_FLAG={0} ", CConstant.DELETE);
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
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
        /// 得到一个对象实体
        /// </summary>
        public BllQuotationTable GetModel(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from bll_quotation_model_view ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            CZZD.ERP.Model.BllQuotationTable model = new CZZD.ERP.Model.BllQuotationTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                bool isFirst = true;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        model.SLIP_NUMBER = dr["SLIP_NUMBER"].ToString();
                        if (dr["SLIP_DATE"].ToString() != "")
                        {
                            model.SLIP_DATE = DateTime.Parse(dr["SLIP_DATE"].ToString());
                        }
                        if (dr["SLIP_TYPE"].ToString() != "")
                        {
                            model.SLIP_TYPE = dr["SLIP_TYPE"].ToString();
                        }
                        if (dr["CUSTOMER_CODE"].ToString() != "")
                        {
                            model.CUSTOMER_CODE = dr["CUSTOMER_CODE"].ToString();
                        }
                        if (dr["DISCOUNT_RATE"].ToString() != "")
                        {
                            model.DISCOUNT_RATE = CConvert.ToDecimal(dr["DISCOUNT_RATE"].ToString());
                        }
                        if (dr["ENQUIRY_METHOD"].ToString() != "")
                        {
                            model.ENQUIRY_METHOD = dr["ENQUIRY_METHOD"].ToString();
                        }
                        if (dr["ENQUIRY_DATE"].ToString() != "")
                        {
                            model.ENQUIRY_DATE = DateTime.Parse(dr["ENQUIRY_DATE"].ToString());
                        }
                        if (dr["DELIVERY_PERIOD"].ToString() != "")
                        {
                            model.DELIVERY_PERIOD = dr["DELIVERY_PERIOD"].ToString();
                        }
                        if (dr["DELIVERY_TERMS"].ToString() != "")
                        {
                            model.DELIVERY_TERMS = dr["DELIVERY_TERMS"].ToString();
                        }
                        if (dr["PAYMENT_TERMS"].ToString() != "")
                        {
                            model.PAYMENT_TERMS = dr["PAYMENT_TERMS"].ToString();
                        }
                        if (dr["DISCOUNT_AMOUNT"].ToString() != "")
                        {
                            model.DISCOUNT_AMOUNT = CConvert.ToDecimal(dr["DISCOUNT_AMOUNT"].ToString());
                        }
                        if (dr["VER"].ToString() != "")
                        {
                            model.VER = dr["VER"].ToString();
                        }
                        if (dr["UPDATE_COUNT"].ToString() != "")
                        {
                            model.UPDATE_COUNT = CConvert.ToInt32(dr["UPDATE_COUNT"].ToString());
                        }
                        if (dr["QUANTITY"].ToString() != "")
                        {
                            model.QUANTITY = CConvert.ToDecimal(dr["QUANTITY"].ToString());
                        }
                        if (dr["CURRENCY_CODE"].ToString() != "")
                        {
                            model.CURRENCY_CODE = dr["CURRENCY_CODE"].ToString();
                        }
                        if (dr["COMPANY_CODE"].ToString() != "")
                        {
                            model.COMPANY_CODE = dr["COMPANY_CODE"].ToString();
                        }
                        if (dr["AMOUNT_INCLUDED_TAX"].ToString() != "")
                        {
                            model.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(dr["AMOUNT_INCLUDED_TAX"].ToString());
                        }
                        if (dr["AMOUNT_WITHOUT_TAX"].ToString() != "")
                        {
                            model.AMOUNT_WITHOUT_TAX = CConvert.ToDecimal(dr["AMOUNT_WITHOUT_TAX"].ToString());
                        }
                        if (dr["TAX_RATE"].ToString() != "")
                        {
                            model.TAX_RATE = CConvert.ToDecimal(dr["TAX_RATE"].ToString());
                        }
                        if (dr["TAX_AMOUNT"].ToString() != "")
                        {
                            model.TAX_AMOUNT = CConvert.ToDecimal(dr["TAX_AMOUNT"].ToString());
                        }
                        if (dr["MEMO"].ToString() != "")
                        {
                            model.MEMO = dr["MEMO"].ToString();
                        }
                        if (dr["ORDER_FLAG"].ToString() != "")
                        {
                            model.ORDER_FLAG = CConvert.ToInt32(dr["ORDER_FLAG"].ToString());
                        }
                        if (dr["STATUS_FLAG"].ToString() != "")
                        {
                            model.STATUS_FLAG = CConvert.ToInt32(dr["STATUS_FLAG"].ToString());
                        }
                        if (dr["CREATE_USER"].ToString() != "")
                        {
                            model.CREATE_USER = dr["CREATE_USER"].ToString();
                        }
                        if (dr["CREATE_DATE_TIME"].ToString() != "")
                        {
                            model.CREATE_DATE_TIME = CConvert.ToDateTime(dr["CREATE_DATE_TIME"].ToString());
                        }
                        if (dr["LAST_UPDATE_TIME"].ToString() != "")
                        {
                            model.LAST_UPDATE_TIME = CConvert.ToDateTime(dr["LAST_UPDATE_TIME"].ToString());
                        }
                        if (dr["LAST_UPDATE_USER"].ToString() != "")
                        {
                            model.LAST_UPDATE_USER = dr["LAST_UPDATE_USER"].ToString();
                        }
                        if (dr["CUSTOMER_NAME"].ToString() != "")
                        {
                            model.CUSTOMER_NAME = dr["CUSTOMER_NAME"].ToString();
                        }
                        if (dr["CURRENCY_NAME"].ToString() != "")
                        {
                            model.CURRENCY_NAME = dr["CURRENCY_NAME"].ToString();
                        }
                        if (dr["TO_CUSTOMER_MEMO"].ToString() != "")
                        {
                            model.TO_CUSTOMER_MEMO = dr["TO_CUSTOMER_MEMO"].ToString();
                        }
                    }

                    BllQuotationLineTable LineTable = new BllQuotationLineTable();
                    if (dr["LINE_NUMBER"].ToString() != "")
                    {
                        LineTable.LINE_NUMBER = CConvert.ToInt32(dr["LINE_NUMBER"].ToString());
                    }
                    if (dr["PRODUCT_CODE"].ToString() != "")
                    {
                        LineTable.PRODUCT_CODE = dr["PRODUCT_CODE"].ToString();
                    }
                    if (dr["LINE_QUANTITY"].ToString() != "")
                    {
                        LineTable.QUANTITY = CConvert.ToDecimal(dr["LINE_QUANTITY"].ToString());
                    }
                    if (dr["UNIT_CODE"].ToString() != "")
                    {
                        LineTable.UNIT_CODE = dr["UNIT_CODE"].ToString();
                    }
                    if (dr["PRICE"].ToString() != "")
                    {
                        LineTable.PRICE = CConvert.ToDecimal(dr["PRICE"].ToString());
                    }
                    if (dr["AMOUNT"].ToString() != "")
                    {
                        LineTable.AMOUNT = CConvert.ToDecimal(dr["AMOUNT"].ToString());
                    }
                    if (dr["LINE_MEMO"].ToString() != "")
                    {
                        LineTable.MEMO = dr["LINE_MEMO"].ToString();
                    }
                    if (dr["SPEC_LINE"].ToString() != "")
                    {
                        LineTable.SPEC = dr["SPEC_LINE"].ToString();
                    }
                    if (dr["DESCRIPTION"].ToString() != "")
                    {
                        LineTable.DESCRIPTION = dr["DESCRIPTION"].ToString();
                    }
                    if (dr["DISCOUNT"].ToString() != "")
                    {
                        LineTable.PRICE_DISCOUNT = CConvert.ToDecimal(dr["DISCOUNT"].ToString());
                    }
                    if (dr["SLIP_NUMBER_LINE"].ToString() != "")
                    {
                        LineTable.SLIP_NUMBER = dr["SLIP_NUMBER_LINE"].ToString();
                    }
                    if (dr["PRODUCT_CODE"].ToString() != "")
                    {
                        LineTable.PRODUCT_CODE = dr["PRODUCT_CODE"].ToString();
                    }
                    if (dr["METERIAL"].ToString() != "")
                    {
                        LineTable.METERIAL = dr["METERIAL"].ToString();
                    }
                    if (dr["PARTS_CODE"].ToString() != "")
                    {
                        LineTable.PARTS_CODE = dr["PARTS_CODE"].ToString();
                    }
                    if (dr["SLIP_TYPE_NAME"].ToString() != "")
                    {
                        LineTable.PRODUCT_NAME = dr["SLIP_TYPE_NAME"].ToString();
                    }
                    if (dr["COMPOSITION_PRODUCTS_NAME"].ToString() != "")
                    {
                        LineTable.COMPOSITION_PRODUCTS_NAME = dr["COMPOSITION_PRODUCTS_NAME"].ToString();
                    }

                    if (dr["DESCRIPTION1"].ToString() != "")
                    {
                        LineTable.DESCRIPTION1 = dr["DESCRIPTION1"].ToString();
                    }
                    model.AddItem(LineTable);
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_quotation_search_view");
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
                strSql.Append("order by T.SLIP_NUMBER DESC");
            }
            strSql.Append(")AS Row, T.* from bll_quotation_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetHistoryQuotation(string orderSlipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ''AS NO,HOH.*,BU.NAME AS LAST_UPDATE_USER_NAME from BLL_HISTORY_QUOTATION AS HOH ");
            strSql.Append(" left join BASE_USER  AS BU ON BU.CODE = HOH.LAST_UPDATE_USER ");
            strSql.AppendFormat(" where  slip_number='{0}'", orderSlipNumber);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个history对象实体
        /// </summary>
        public BllQuotationTable GetHistoryModel(string historySlipNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from bll_history_quotation_view ");
            strSql.Append(" where HISTORY_NUMBER=@HISTORY_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@HISTORY_NUMBER", SqlDbType.Int,4)};
            parameters[0].Value = historySlipNumber;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            BllQuotationTable model = new BllQuotationTable();
            if (ds.Tables[0].Rows.Count > 0)
            {
                bool isFirst = true;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        model.SLIP_NUMBER = dr["SLIP_NUMBER"].ToString();
                        if (dr["SLIP_DATE"].ToString() != "")
                        {
                            model.SLIP_DATE = CConvert.ToDateTime(dr["SLIP_DATE"].ToString());
                        }
                        if (dr["SLIP_TYPE"].ToString() != "")
                        {
                            model.SLIP_TYPE = dr["SLIP_TYPE"].ToString();
                        }
                        if (dr["CUSTOMER_CODE"].ToString() != "")
                        {
                            model.CUSTOMER_CODE = dr["CUSTOMER_CODE"].ToString();
                        }

                        if (dr["DISCOUNT_RATE"].ToString() != "")
                        {
                            model.DISCOUNT_RATE = CConvert.ToDecimal(dr["DISCOUNT_RATE"].ToString());
                        }
                        if (dr["ENQUIRY_METHOD"].ToString() != "")
                        {
                            model.ENQUIRY_METHOD = dr["ENQUIRY_METHOD"].ToString();
                        }
                        if (dr["ENQUIRY_DATE"].ToString() != "")
                        {
                            model.ENQUIRY_DATE = CConvert.ToDateTime(dr["ENQUIRY_DATE"].ToString());
                        }
                        if (dr["DELIVERY_PERIOD"].ToString() != "")
                        {
                            model.DELIVERY_PERIOD = dr["DELIVERY_PERIOD"].ToString();
                        }
                        if (dr["DELIVERY_TERMS"].ToString() != "")
                        {
                            model.DELIVERY_TERMS = dr["DELIVERY_TERMS"].ToString();
                        }
                        if (dr["PAYMENT_TERMS"].ToString() != "")
                        {
                            model.PAYMENT_TERMS = dr["PAYMENT_TERMS"].ToString();
                        }
                        if (dr["DISCOUNT_AMOUNT"].ToString() != "")
                        {
                            model.DISCOUNT_AMOUNT = CConvert.ToDecimal(dr["DISCOUNT_AMOUNT"].ToString());
                        }
                        if (dr["VER"].ToString() != "")
                        {
                            model.VER = dr["VER"].ToString();
                        }
                        if (dr["QUANTITY"].ToString() != "")
                        {
                            model.QUANTITY = CConvert.ToDecimal(dr["QUANTITY"].ToString());
                        }
                        if (dr["CURRENCY_CODE"].ToString() != "")
                        {
                            model.CURRENCY_CODE = dr["CURRENCY_CODE"].ToString();
                        }
                        if (dr["COMPANY_CODE"].ToString() != "")
                        {
                            model.COMPANY_CODE = dr["COMPANY_CODE"].ToString();
                        }
                        if (dr["AMOUNT_INCLUDED_TAX"].ToString() != "")
                        {
                            model.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(dr["AMOUNT_INCLUDED_TAX"].ToString());
                        }
                        if (dr["AMOUNT_WITHOUT_TAX"].ToString() != "")
                        {
                            model.AMOUNT_WITHOUT_TAX = CConvert.ToDecimal(dr["AMOUNT_WITHOUT_TAX"].ToString());
                        }
                        if (dr["TAX_RATE"].ToString() != "")
                        {
                            model.TAX_RATE = CConvert.ToDecimal(dr["TAX_RATE"].ToString());
                        }
                        if (dr["TAX_AMOUNT"].ToString() != "")
                        {
                            model.TAX_AMOUNT = CConvert.ToDecimal(dr["TAX_AMOUNT"].ToString());
                        }
                        if (dr["MEMO"].ToString() != "")
                        {
                            model.MEMO = dr["MEMO"].ToString();
                        }
                        if (dr["ORDER_FLAG"].ToString() != "")
                        {
                            model.ORDER_FLAG = CConvert.ToInt32(dr["ORDER_FLAG"].ToString());
                        }
                        if (dr["STATUS_FLAG"].ToString() != "")
                        {
                            model.STATUS_FLAG = CConvert.ToInt32(dr["STATUS_FLAG"].ToString());
                        }
                        if (dr["CREATE_USER"].ToString() != "")
                        {
                            model.CREATE_USER = dr["CREATE_USER"].ToString();
                        }
                        if (dr["CREATE_DATE_TIME"].ToString() != "")
                        {
                            model.CREATE_DATE_TIME = CConvert.ToDateTime(dr["CREATE_DATE_TIME"].ToString());
                        }
                        if (dr["LAST_UPDATE_TIME"].ToString() != "")
                        {
                            model.LAST_UPDATE_TIME = CConvert.ToDateTime(dr["LAST_UPDATE_TIME"].ToString());
                        }
                        if (dr["LAST_UPDATE_USER"].ToString() != "")
                        {
                            model.LAST_UPDATE_USER = dr["LAST_UPDATE_USER"].ToString();
                        }
                        if (dr["CUSTOMER_NAME"].ToString() != "")
                        {
                            model.CUSTOMER_NAME = dr["CUSTOMER_NAME"].ToString();
                        }
                        if (dr["TO_CUSTOMER_MEMO"].ToString() != "")
                        {
                            model.TO_CUSTOMER_MEMO = dr["TO_CUSTOMER_MEMO"].ToString();
                        }
                    }

                    BllQuotationLineTable LineTable = new BllQuotationLineTable();
                    if (dr["LINE_NUMBER"].ToString() != "")
                    {
                        LineTable.LINE_NUMBER = CConvert.ToInt32(dr["LINE_NUMBER"].ToString());
                    }
                    LineTable.PRODUCT_CODE = dr["PRODUCT_CODE"].ToString();
                    if (dr["LINE_QUANTITY"].ToString() != "")
                    {
                        LineTable.QUANTITY = CConvert.ToDecimal(dr["LINE_QUANTITY"].ToString());
                    }
                    if (dr["UNIT_CODE"].ToString() != "")
                    {
                        LineTable.UNIT_CODE = dr["UNIT_CODE"].ToString();
                    }
                    if (dr["PRICE"].ToString() != "")
                    {
                        LineTable.PRICE = CConvert.ToDecimal(dr["PRICE"].ToString());
                    }
                    if (dr["AMOUNT"].ToString() != "")
                    {
                        LineTable.AMOUNT = CConvert.ToDecimal(dr["AMOUNT"].ToString());
                    }
                    if (dr["LINE_MEMO"].ToString() != "")
                    {
                        LineTable.MEMO = dr["LINE_MEMO"].ToString();
                    }
                    if (dr["SPEC_LINE"].ToString() != "")
                    {
                        LineTable.SPEC = dr["SPEC_LINE"].ToString();
                    }
                    if (dr["DESCRIPTION"].ToString() != "")
                    {
                        LineTable.DESCRIPTION = dr["DESCRIPTION"].ToString();
                    }
                    if (dr["DISCOUNT"].ToString() != "")
                    {
                        LineTable.PRICE_DISCOUNT = CConvert.ToDecimal(dr["DISCOUNT"].ToString());
                    }
                    if (dr["SLIP_NUMBER_LINE"].ToString() != "")
                    {
                        LineTable.SLIP_NUMBER = dr["SLIP_NUMBER_LINE"].ToString();
                    }
                    if (dr["PRODUCT_CODE"].ToString() != "")
                    {
                        LineTable.PRODUCT_CODE = dr["PRODUCT_CODE"].ToString();
                    }
                    if (dr["METERIAL"].ToString() != "")
                    {
                        LineTable.METERIAL = dr["METERIAL"].ToString();
                    }
                    if (dr["PARTS_CODE"].ToString() != "")
                    {
                        LineTable.PARTS_CODE = dr["PARTS_CODE"].ToString();
                    }
                    if (dr["SLIP_TYPE_NAME"].ToString() != "")
                    {
                        LineTable.PRODUCT_NAME = dr["SLIP_TYPE_NAME"].ToString();
                    }
                    if (dr["COMPOSITION_PRODUCTS_NAME"].ToString() != "")
                    {
                        LineTable.COMPOSITION_PRODUCTS_NAME = dr["COMPOSITION_PRODUCTS_NAME"].ToString();
                    }
                    if (dr["DESCRIPTION1"].ToString() != "")
                    {
                        LineTable.DESCRIPTION1 = dr["DESCRIPTION1"].ToString();
                    }
                    model.AddItem(LineTable);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}
