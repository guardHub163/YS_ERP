using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data.SqlClient;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using System.Data;

namespace CZZD.ERP.SQLServerDAL
{
    public class OrderHeaderManage : IOrderHeader
    {
        #region  Method

        /// <summary>
        /// 取得当前公司的最大订单流水号
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public string GetMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(max(SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from get_order_header_max_slip_number");
            return CConvert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        //根据需要家得出纳入先
        public DataSet GetDelivery(string customer_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select top 1 *  from BASE_DELIVERY  where CUSTOMER_CODE like '{0}'", customer_code);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string slipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BLL_ORDER_HEADER");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = slipNumber;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BllOrderHeaderTable headerModel)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into BLL_ORDER_HEADER(");
                    strSql.Append("SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,SERIAL_NUMBER,OWNER_PO_NUMBER,CUSTOMER_PO_NUMBER,DELIVERY_POINT_CODE,CUSTOMER_CODE,ENDER_CUSTOMER_CODE,DEPARTUAL_WAREHOUSE_CODE,DEPARTUAL_DATE,DUE_DATE,SALES_EMPLOYEE_CODE,ATTACHED_FLAG,UPDATED_COUNT,VERIFY_FLAG,CURRENCY_CODE,ORDER_DEPOSIT,SHIPMENT_DEPOSIT,COMPANY_CODE,MEMO,AMOUNT_INCLUDED_TAX,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,TAX_RATE,ALLOATION_FLAG,CHECK_NUMBER,ORDER_DEPOSIT_DATE,ORDER_SHIPMENT_DEPOSIT_DATE,QUOTES_NUMBER,PRODUCE_FLAG,QUANTITY,DISCOUNT_AMOUNT,DELIVERY_TERMS,PAYMENT_TERMS,VER,DISCOUNT_RATE,TO_CUSTOMER_MEMO)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@SLIP_TYPE,@SERIAL_NUMBER,@OWNER_PO_NUMBER,@CUSTOMER_PO_NUMBER,@DELIVERY_POINT_CODE,@CUSTOMER_CODE,@ENDER_CUSTOMER_CODE,@DEPARTUAL_WAREHOUSE_CODE,@DEPARTUAL_DATE,@DUE_DATE,@SALES_EMPLOYEE_CODE,@ATTACHED_FLAG,@UPDATED_COUNT,@VERIFY_FLAG,@CURRENCY_CODE,@ORDER_DEPOSIT,@SHIPMENT_DEPOSIT,@COMPANY_CODE,@MEMO,@AMOUNT_INCLUDED_TAX,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@TAX_RATE,@ALLOATION_FLAG,@CHECK_NUMBER,@ORDER_DEPOSIT_DATE,@ORDER_SHIPMENT_DEPOSIT_DATE,@QUOTES_NUMBER,@PRODUCE_FLAG,@QUANTITY,@DISCOUNT_AMOUNT,@DELIVERY_TERMS,@PAYMENT_TERMS,@VER,@DISCOUNT_RATE,@TO_CUSTOMER_MEMO)");
                    SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					new SqlParameter("@SERIAL_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@OWNER_PO_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@CUSTOMER_PO_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@DELIVERY_POINT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ENDER_CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@DEPARTUAL_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@DEPARTUAL_DATE", SqlDbType.DateTime),
					new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
					new SqlParameter("@SALES_EMPLOYEE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ATTACHED_FLAG", SqlDbType.Int,4),
					new SqlParameter("@UPDATED_COUNT", SqlDbType.Int,4),
					new SqlParameter("@VERIFY_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ORDER_DEPOSIT", SqlDbType.Decimal,5),
					new SqlParameter("@SHIPMENT_DEPOSIT", SqlDbType.Decimal,5),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@TAX_RATE", SqlDbType.Decimal,8),
                    new SqlParameter("@ALLOATION_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CHECK_NUMBER", SqlDbType.VarChar,20),
                    //new SqlParameter("@CHECK_DATE", SqlDbType.DateTime),
                    new SqlParameter("@ORDER_DEPOSIT_DATE", SqlDbType.DateTime),
                    new SqlParameter("@ORDER_SHIPMENT_DEPOSIT_DATE", SqlDbType.DateTime),
                    new SqlParameter("@QUOTES_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCE_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                    new SqlParameter("@DISCOUNT_AMOUNT", SqlDbType.Decimal,9),
                    new SqlParameter("@DELIVERY_TERMS", SqlDbType.VarChar,250),
                    new SqlParameter("@PAYMENT_TERMS", SqlDbType.VarChar,250),
                    new SqlParameter("@VER", SqlDbType.VarChar,250),
                    new SqlParameter("@DISCOUNT_RATE", SqlDbType.Decimal,9),
                    new SqlParameter("@TO_CUSTOMER_MEMO", SqlDbType.Text)};
                    parameters[0].Value = headerModel.SLIP_NUMBER;
                    parameters[1].Value = headerModel.SLIP_DATE;
                    parameters[2].Value = headerModel.SLIP_TYPE;
                    parameters[3].Value = headerModel.SERIAL_NUMBER;
                    parameters[4].Value = headerModel.OWNER_PO_NUMBER;
                    parameters[5].Value = headerModel.CUSTOMER_PO_NUMBER;
                    parameters[6].Value = headerModel.DELIVERY_POINT_CODE;
                    parameters[7].Value = headerModel.CUSTOMER_CODE;
                    parameters[8].Value = headerModel.ENDER_CUSTOMER_CODE;
                    parameters[9].Value = headerModel.DEPARTUAL_WAREHOUSE_CODE;
                    parameters[10].Value = headerModel.DEPARTUAL_DATE;
                    parameters[11].Value = headerModel.DUE_DATE;
                    parameters[12].Value = headerModel.SALES_EMPLOYEE_CODE;
                    parameters[13].Value = headerModel.ATTACHED_FLAG;
                    parameters[14].Value = headerModel.UPDATED_COUNT;
                    parameters[15].Value = headerModel.VERIFY_FLAG;
                    parameters[16].Value = headerModel.CURRENCY_CODE;
                    parameters[17].Value = headerModel.ORDER_DEPOSIT;
                    parameters[18].Value = headerModel.SHIPMENT_DEPOSIT;
                    parameters[19].Value = headerModel.COMPANY_CODE;
                    parameters[20].Value = headerModel.MEMO;
                    parameters[21].Value = headerModel.AMOUNT_INCLUDED_TAX;
                    parameters[22].Value = headerModel.AMOUNT_WITHOUT_TAX;
                    parameters[23].Value = headerModel.TAX_AMOUNT;
                    parameters[24].Value = headerModel.STATUS_FLAG;
                    parameters[25].Value = headerModel.CREATE_USER;
                    parameters[26].Value = headerModel.LAST_UPDATE_USER;
                    parameters[27].Value = headerModel.TAX_RATE;
                    parameters[28].Value = headerModel.ALLOATION_FLAG;
                    parameters[29].Value = headerModel.CHECK_NUMBER;
                   // parameters[30].Value = headerModel.CHECK_DATE;
                    parameters[30].Value = headerModel.ORDER_DEPOSIT_DATE;
                    parameters[31].Value = headerModel.ORDER_SHIPMENT_DEPOSIT_DATE;
                    parameters[32].Value = headerModel.QUOTES_NUMBER;
                    parameters[33].Value = headerModel.PRODUCE_FLAG;
                    parameters[34].Value = headerModel.QUANTITY;
                    parameters[35].Value = headerModel.DISCOUNT_AMOUNT;
                    parameters[36].Value = headerModel.DELIVERY_TERMS;
                    parameters[37].Value = headerModel.PAYMENT_TERMS;
                    parameters[38].Value = headerModel.VER;
                    parameters[39].Value = headerModel.DISCOUNT_RATE;
                    parameters[40].Value = headerModel.TO_CUSTOMER_MEMO;
                    listSql.Add(new CommandInfo(strSql.ToString(), parameters));

                    if (!string.IsNullOrEmpty(headerModel.QUOTES_NUMBER))
                    {
                        strSql = new StringBuilder();
                        strSql.AppendFormat("update BLL_QUOTATION set ORDER_FLAG={0} ", 1);
                        strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                        SqlParameter[] qoParam = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                        qoParam[0].Value = headerModel.QUOTES_NUMBER;
                        listSql.Add(new CommandInfo(strSql.ToString(), qoParam));
                    }

                    //明细插入
                    foreach (BllOrderLineTable lineModel in headerModel.Items)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_ORDER_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT,CURRENCY_CODE,MEMO,STATUS_FLAG,SHIPMENT_FLAG,ALLOATION_QUANTITY,SHIPMENT_QUANTITY,METERIAL,PARTS_CODE,SPEC,DESCRIPTION,DISCOUNT,DESCRIPTION1)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT,@CURRENCY_CODE,@MEMO,@STATUS_FLAG,@SHIPMENT_FLAG,@ALLOATION_QUANTITY,@SHIPMENT_QUANTITY,@METERIAL,@PARTS_CODE,@SPEC,@DESCRIPTION,@DISCOUNT,@DESCRIPTION1)");
                        SqlParameter[] lineParameters = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					        new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),
					        new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@SHIPMENT_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@ALLOATION_QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@SHIPMENT_QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@METERIAL", SqlDbType.VarChar,50),    
                            new SqlParameter("@PARTS_CODE", SqlDbType.VarChar,50),   
                            new SqlParameter("@SPEC", SqlDbType.VarChar,50),   
                            new SqlParameter("@DESCRIPTION", SqlDbType.VarChar,50),   
                            new SqlParameter("@DISCOUNT", SqlDbType.Decimal,9),
                            new SqlParameter("@DESCRIPTION1", SqlDbType.VarChar,50)};
                        lineParameters[0].Value = headerModel.SLIP_NUMBER;
                        lineParameters[1].Value = lineModel.LINE_NUMBER;
                        lineParameters[2].Value = lineModel.PRODUCT_CODE;
                        lineParameters[3].Value = lineModel.QUANTITY;
                        lineParameters[4].Value = lineModel.UNIT_CODE;
                        lineParameters[5].Value = lineModel.PRICE;
                        lineParameters[6].Value = lineModel.AMOUNT;
                        lineParameters[7].Value = lineModel.CURRENCY_CODE;
                        lineParameters[8].Value = lineModel.MEMO;
                        lineParameters[9].Value = lineModel.STATUS_FLAG;
                        lineParameters[10].Value = lineModel.SHIPMENT_FLAG;
                        lineParameters[11].Value = lineModel.ALLOATION_QUANTITY;
                        lineParameters[12].Value = lineModel.SHIPMENT_QUANTITY;
                        lineParameters[13].Value = lineModel.METERIAL;
                        lineParameters[14].Value = lineModel.PARTS_CODE;
                        lineParameters[15].Value = lineModel.SPEC;
                        lineParameters[16].Value = lineModel.DESCRIPTION;
                        lineParameters[17].Value = lineModel.PRICE_DISCOUNT;
                        lineParameters[18].Value = lineModel.DESCRIPTION1;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BllOrderHeaderTable headerModel)
        {
            int result = 0;
            List<CommandInfo> listSql = null;
            StringBuilder strSql = null;
            //原有订单数据的取得
            BllOrderHeaderTable oldHeaderModel = GetModel(headerModel.SLIP_NUMBER);

            int i = 0;
            while (i < 10)
            {
                listSql = new List<CommandInfo>();

                //History表数据的插入
                #region
                //现有最大ID的取得
                int historyMaxID = DbHelperSQL.GetMaxID("HISTORY_NUMBER", "BLL_HISTORY_ORDER_HEADER");
                strSql = new StringBuilder();
                strSql.Append("insert into BLL_HISTORY_ORDER_HEADER(");
                strSql.Append("HISTORY_NUMBER,SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,SERIAL_NUMBER,OWNER_PO_NUMBER,CUSTOMER_PO_NUMBER,DELIVERY_POINT_CODE,CUSTOMER_CODE,ENDER_CUSTOMER_CODE,DEPARTUAL_WAREHOUSE_CODE,DEPARTUAL_DATE,DUE_DATE,SALES_EMPLOYEE_CODE,ATTACHED_FLAG,UPDATED_COUNT,VERIFY_FLAG,CURRENCY_CODE,ORDER_DEPOSIT,SHIPMENT_DEPOSIT,COMPANY_CODE,MEMO,AMOUNT_INCLUDED_TAX,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,TAX_RATE,ALLOATION_FLAG,CHECK_NUMBER,ORDER_DEPOSIT_DATE,ORDER_SHIPMENT_DEPOSIT_DATE,QUOTES_NUMBER,DISCOUNT_AMOUNT,DELIVERY_TERMS,PAYMENT_TERMS,VER,DISCOUNT_RATE,TO_CUSTOMER_MEMO)");
                strSql.Append(" values (");
                strSql.Append("@HISTORY_NUMBER,@SLIP_NUMBER,@SLIP_DATE,@SLIP_TYPE,@SERIAL_NUMBER,@OWNER_PO_NUMBER,@CUSTOMER_PO_NUMBER,@DELIVERY_POINT_CODE,@CUSTOMER_CODE,@ENDER_CUSTOMER_CODE,@DEPARTUAL_WAREHOUSE_CODE,@DEPARTUAL_DATE,@DUE_DATE,@SALES_EMPLOYEE_CODE,@ATTACHED_FLAG,@UPDATED_COUNT,@VERIFY_FLAG,@CURRENCY_CODE,@ORDER_DEPOSIT,@SHIPMENT_DEPOSIT,@COMPANY_CODE,@MEMO,@AMOUNT_INCLUDED_TAX,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@TAX_RATE,@ALLOATION_FLAG,@CHECK_NUMBER,@ORDER_DEPOSIT_DATE,@ORDER_SHIPMENT_DEPOSIT_DATE,@QUOTES_NUMBER,@DISCOUNT_AMOUNT,@DELIVERY_TERMS,@PAYMENT_TERMS,@VER,@DISCOUNT_RATE,@TO_CUSTOMER_MEMO)");
                SqlParameter[] historyHeaderParameters = {
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
                    new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
                    new SqlParameter("@SERIAL_NUMBER", SqlDbType.VarChar,50),
                    new SqlParameter("@OWNER_PO_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@CUSTOMER_PO_NUMBER", SqlDbType.VarChar,50),
                    new SqlParameter("@DELIVERY_POINT_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@ENDER_CUSTOMER_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@DEPARTUAL_WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@DEPARTUAL_DATE", SqlDbType.DateTime),
                    new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                    new SqlParameter("@SALES_EMPLOYEE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@ATTACHED_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@UPDATED_COUNT", SqlDbType.Int,4),
                    new SqlParameter("@VERIFY_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@ORDER_DEPOSIT", SqlDbType.Decimal,5),
                    new SqlParameter("@SHIPMENT_DEPOSIT", SqlDbType.Decimal,5),
                    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
                    new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
                    new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
                    new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@TAX_RATE", SqlDbType.Decimal,8),
                    new SqlParameter("@ALLOATION_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@CHECK_NUMBER", SqlDbType.VarChar,20),
                   // new SqlParameter("@CHECK_DATE", SqlDbType.DateTime),
                    new SqlParameter("@HISTORY_NUMBER", SqlDbType.Int,4),
                    new SqlParameter("@ORDER_DEPOSIT_DATE", SqlDbType.DateTime),
                    new SqlParameter("@ORDER_SHIPMENT_DEPOSIT_DATE", SqlDbType.DateTime),
                    new SqlParameter("@QUOTES_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@DISCOUNT_AMOUNT", SqlDbType.Decimal,9),
                    new SqlParameter("@DELIVERY_TERMS", SqlDbType.VarChar,250),
                    new SqlParameter("@PAYMENT_TERMS", SqlDbType.VarChar,250),
                    new SqlParameter("@VER", SqlDbType.VarChar,250),
                    new SqlParameter("@DISCOUNT_RATE", SqlDbType.Decimal,9),
                    new SqlParameter("@TO_CUSTOMER_MEMO", SqlDbType.Text)};
                historyHeaderParameters[0].Value = oldHeaderModel.SLIP_NUMBER;
                historyHeaderParameters[1].Value = oldHeaderModel.SLIP_DATE;
                historyHeaderParameters[2].Value = oldHeaderModel.SLIP_TYPE;
                historyHeaderParameters[3].Value = oldHeaderModel.SERIAL_NUMBER;
                historyHeaderParameters[4].Value = oldHeaderModel.OWNER_PO_NUMBER;
                historyHeaderParameters[5].Value = oldHeaderModel.CUSTOMER_PO_NUMBER;
                historyHeaderParameters[6].Value = oldHeaderModel.DELIVERY_POINT_CODE;
                historyHeaderParameters[7].Value = oldHeaderModel.CUSTOMER_CODE;
                historyHeaderParameters[8].Value = oldHeaderModel.ENDER_CUSTOMER_CODE;
                historyHeaderParameters[9].Value = oldHeaderModel.DEPARTUAL_WAREHOUSE_CODE;
                historyHeaderParameters[10].Value = oldHeaderModel.DEPARTUAL_DATE;
                historyHeaderParameters[11].Value = oldHeaderModel.DUE_DATE;
                historyHeaderParameters[12].Value = oldHeaderModel.SALES_EMPLOYEE_CODE;
                historyHeaderParameters[13].Value = oldHeaderModel.ATTACHED_FLAG;
                historyHeaderParameters[14].Value = oldHeaderModel.UPDATED_COUNT;
                historyHeaderParameters[15].Value = oldHeaderModel.VERIFY_FLAG;
                historyHeaderParameters[16].Value = oldHeaderModel.CURRENCY_CODE;
                historyHeaderParameters[17].Value = oldHeaderModel.ORDER_DEPOSIT;
                historyHeaderParameters[18].Value = oldHeaderModel.SHIPMENT_DEPOSIT;
                historyHeaderParameters[19].Value = oldHeaderModel.COMPANY_CODE;
                historyHeaderParameters[20].Value = oldHeaderModel.MEMO;
                historyHeaderParameters[21].Value = oldHeaderModel.AMOUNT_INCLUDED_TAX;
                historyHeaderParameters[22].Value = oldHeaderModel.AMOUNT_WITHOUT_TAX;
                historyHeaderParameters[23].Value = oldHeaderModel.TAX_AMOUNT;
                historyHeaderParameters[24].Value = oldHeaderModel.STATUS_FLAG;
                historyHeaderParameters[25].Value = oldHeaderModel.CREATE_USER;
                historyHeaderParameters[26].Value = oldHeaderModel.LAST_UPDATE_USER;
                historyHeaderParameters[27].Value = oldHeaderModel.TAX_RATE;
                historyHeaderParameters[28].Value = oldHeaderModel.ALLOATION_FLAG;
                historyHeaderParameters[29].Value = oldHeaderModel.CHECK_NUMBER;
                //historyHeaderParameters[30].Value = oldHeaderModel.CHECK_DATE;
                historyHeaderParameters[30].Value = historyMaxID;
                historyHeaderParameters[31].Value = oldHeaderModel.ORDER_DEPOSIT_DATE;
                historyHeaderParameters[32].Value = oldHeaderModel.ORDER_SHIPMENT_DEPOSIT_DATE;
                historyHeaderParameters[33].Value = oldHeaderModel.QUOTES_NUMBER;
                historyHeaderParameters[34].Value = oldHeaderModel.DISCOUNT_AMOUNT;
                historyHeaderParameters[35].Value = oldHeaderModel.DELIVERY_TERMS;
                historyHeaderParameters[36].Value = oldHeaderModel.PAYMENT_TERMS;
                historyHeaderParameters[37].Value = oldHeaderModel.VER;
                historyHeaderParameters[38].Value = oldHeaderModel.DISCOUNT_RATE;
                historyHeaderParameters[39].Value = oldHeaderModel.TO_CUSTOMER_MEMO;
                listSql.Add(new CommandInfo(strSql.ToString(), historyHeaderParameters));

                //明细插入
                foreach (BllOrderLineTable oldLineModel in oldHeaderModel.Items)
                {
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_HISTORY_ORDER_LINE(");
                    strSql.Append("HISTORY_NUMBER,SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT,CURRENCY_CODE,MEMO,STATUS_FLAG,SHIPMENT_FLAG,ALLOATION_QUANTITY,SHIPMENT_QUANTITY,METERIAL,PARTS_CODE,SPEC,DESCRIPTION,DISCOUNT,DESCRIPTION1)");
                    strSql.Append(" values (");
                    strSql.Append("@HISTORY_NUMBER,@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT,@CURRENCY_CODE,@MEMO,@STATUS_FLAG,@SHIPMENT_FLAG,@ALLOATION_QUANTITY,@SHIPMENT_QUANTITY,   @METERIAL,@PARTS_CODE,@SPEC,@DESCRIPTION,@DISCOUNT,@DESCRIPTION1)");
                    SqlParameter[] historyLineParameters = {
                            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
                            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
                            new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),
                            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
                            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@SHIPMENT_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@ALLOATION_QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@SHIPMENT_QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@HISTORY_NUMBER", SqlDbType.Int,4),                         
                            new SqlParameter("@METERIAL", SqlDbType.VarChar,50),    
                            new SqlParameter("@PARTS_CODE", SqlDbType.VarChar,50),   
                            new SqlParameter("@SPEC", SqlDbType.VarChar,50),   
                            new SqlParameter("@DESCRIPTION", SqlDbType.VarChar,50),   
                            new SqlParameter("@DISCOUNT", SqlDbType.Decimal,9),
                             new SqlParameter("@DESCRIPTION1", SqlDbType.VarChar,50)};
                    historyLineParameters[0].Value = oldHeaderModel.SLIP_NUMBER;
                    historyLineParameters[1].Value = oldLineModel.LINE_NUMBER;
                    historyLineParameters[2].Value = oldLineModel.PRODUCT_CODE;
                    historyLineParameters[3].Value = oldLineModel.QUANTITY;
                    historyLineParameters[4].Value = oldLineModel.UNIT_CODE;
                    historyLineParameters[5].Value = oldLineModel.PRICE;
                    historyLineParameters[6].Value = oldLineModel.AMOUNT;
                    historyLineParameters[7].Value = oldLineModel.CURRENCY_CODE;
                    historyLineParameters[8].Value = oldLineModel.MEMO;
                    historyLineParameters[9].Value = oldLineModel.STATUS_FLAG;
                    historyLineParameters[10].Value = oldLineModel.SHIPMENT_FLAG;
                    historyLineParameters[11].Value = oldLineModel.ALLOATION_QUANTITY;
                    historyLineParameters[12].Value = oldLineModel.SHIPMENT_QUANTITY;
                    historyLineParameters[13].Value = historyMaxID;
                    historyLineParameters[14].Value = oldLineModel.METERIAL;
                    historyLineParameters[15].Value = oldLineModel.PARTS_CODE;
                    historyLineParameters[16].Value = oldLineModel.SPEC;
                    historyLineParameters[17].Value = oldLineModel.DESCRIPTION;
                    historyLineParameters[18].Value = oldLineModel.PRICE_DISCOUNT;
                    historyLineParameters[19].Value = oldLineModel.DESCRIPTION1;
                    listSql.Add(new CommandInfo(strSql.ToString(), historyLineParameters));
                }
                #endregion

                //引当解除
                #region 引当出库数据的删除
                strSql = new StringBuilder();
                strSql.Append(" delete from BLL_ALLOATION ");
                strSql.Append(" where ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER");
                strSql.AppendFormat(" and STATUS_FLAG <> {0} and STATUS_FLAG <> {1} ", CConstant.DELETE, CConstant.ALLOATION_SHIPMENT);
                SqlParameter[] alloationParameters = {
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20)
                    };
                alloationParameters[0].Value = headerModel.SLIP_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), alloationParameters));
                #endregion

                //主表的更新
                #region 主表的更新
                strSql = new StringBuilder();
                strSql.Append("update BLL_ORDER_HEADER set ");
                strSql.Append("SLIP_DATE=@SLIP_DATE,");
                strSql.Append("SLIP_TYPE=@SLIP_TYPE,");
                strSql.Append("SERIAL_NUMBER=@SERIAL_NUMBER,");
                strSql.Append("OWNER_PO_NUMBER=@OWNER_PO_NUMBER,");
                strSql.Append("CUSTOMER_PO_NUMBER=@CUSTOMER_PO_NUMBER,");
                strSql.Append("DELIVERY_POINT_CODE=@DELIVERY_POINT_CODE,");
                strSql.Append("CUSTOMER_CODE=@CUSTOMER_CODE,");
                strSql.Append("ENDER_CUSTOMER_CODE=@ENDER_CUSTOMER_CODE,");
                strSql.Append("DEPARTUAL_WAREHOUSE_CODE=@DEPARTUAL_WAREHOUSE_CODE,");
                strSql.Append("DEPARTUAL_DATE=@DEPARTUAL_DATE,");
                strSql.Append("DUE_DATE=@DUE_DATE,");
                strSql.Append("SALES_EMPLOYEE_CODE=@SALES_EMPLOYEE_CODE,");
                strSql.Append("ATTACHED_FLAG=@ATTACHED_FLAG,");
                strSql.Append("UPDATED_COUNT=@UPDATED_COUNT,");
                strSql.Append("VERIFY_FLAG=@VERIFY_FLAG,");
                strSql.Append("CURRENCY_CODE=@CURRENCY_CODE,");
                strSql.Append("ORDER_DEPOSIT=@ORDER_DEPOSIT,");
                strSql.Append("SHIPMENT_DEPOSIT=@SHIPMENT_DEPOSIT,");
                strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
                strSql.Append("MEMO=@MEMO,");
                strSql.Append("AMOUNT_INCLUDED_TAX=@AMOUNT_INCLUDED_TAX,");
                strSql.Append("AMOUNT_WITHOUT_TAX=@AMOUNT_WITHOUT_TAX,");
                strSql.Append("TAX_RATE=@TAX_RATE,");
                strSql.Append("TAX_AMOUNT=@TAX_AMOUNT,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("CHECK_NUMBER=@CHECK_NUMBER,");
                //strSql.Append("CHECK_DATE=@CHECK_DATE,");
                strSql.Append("ALLOATION_FLAG=@ALLOATION_FLAG,");
                strSql.Append("ORDER_DEPOSIT_DATE=@ORDER_DEPOSIT_DATE,");
                strSql.Append("ORDER_SHIPMENT_DEPOSIT_DATE=@ORDER_SHIPMENT_DEPOSIT_DATE,");
                strSql.Append("QUOTES_NUMBER=@QUOTES_NUMBER,");
                strSql.Append("PRODUCE_FLAG=@PRODUCE_FLAG,");
                strSql.Append("QUANTITY=@QUANTITY,");
                strSql.Append("DISCOUNT_AMOUNT=@DISCOUNT_AMOUNT,");
                strSql.Append("DELIVERY_TERMS=@DELIVERY_TERMS,");
                strSql.Append("PAYMENT_TERMS=@PAYMENT_TERMS,");
                strSql.Append("VER=@VER,");
                strSql.Append("DISCOUNT_RATE=@DISCOUNT_RATE,");
                strSql.Append("TO_CUSTOMER_MEMO=@TO_CUSTOMER_MEMO");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] headerParameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					new SqlParameter("@SERIAL_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@OWNER_PO_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@CUSTOMER_PO_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@DELIVERY_POINT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ENDER_CUSTOMER_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@DEPARTUAL_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@DEPARTUAL_DATE", SqlDbType.DateTime),
					new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
					new SqlParameter("@SALES_EMPLOYEE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ATTACHED_FLAG", SqlDbType.Int,4),
					new SqlParameter("@UPDATED_COUNT", SqlDbType.Int,4),
					new SqlParameter("@VERIFY_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ORDER_DEPOSIT", SqlDbType.Decimal,5),
					new SqlParameter("@SHIPMENT_DEPOSIT", SqlDbType.Decimal,5),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
                    new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@CHECK_NUMBER", SqlDbType.VarChar,20),
                    //new SqlParameter("@CHECK_DATE", SqlDbType.DateTime),
                    new SqlParameter("@ALLOATION_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@ORDER_DEPOSIT_DATE", SqlDbType.DateTime),
                    new SqlParameter("@ORDER_SHIPMENT_DEPOSIT_DATE", SqlDbType.DateTime),
                    new SqlParameter("@QUOTES_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                    new SqlParameter("@DISCOUNT_AMOUNT", SqlDbType.Decimal,9),
                    new SqlParameter("@DELIVERY_TERMS", SqlDbType.VarChar,250),
                    new SqlParameter("@PAYMENT_TERMS", SqlDbType.VarChar,250),
                    new SqlParameter("@VER", SqlDbType.VarChar,250),
                    new SqlParameter("@DISCOUNT_RATE", SqlDbType.Decimal,9),
                    new SqlParameter("@TO_CUSTOMER_MEMO", SqlDbType.Text)};
                headerParameters[0].Value = headerModel.SLIP_NUMBER;
                headerParameters[1].Value = headerModel.SLIP_DATE;
                headerParameters[2].Value = headerModel.SLIP_TYPE;
                headerParameters[3].Value = headerModel.SERIAL_NUMBER;
                headerParameters[4].Value = headerModel.OWNER_PO_NUMBER;
                headerParameters[5].Value = headerModel.CUSTOMER_PO_NUMBER;
                headerParameters[6].Value = headerModel.DELIVERY_POINT_CODE;
                headerParameters[7].Value = headerModel.CUSTOMER_CODE;
                headerParameters[8].Value = headerModel.ENDER_CUSTOMER_CODE;
                headerParameters[9].Value = headerModel.DEPARTUAL_WAREHOUSE_CODE;
                headerParameters[10].Value = headerModel.DEPARTUAL_DATE;
                headerParameters[11].Value = headerModel.DUE_DATE;
                headerParameters[12].Value = headerModel.SALES_EMPLOYEE_CODE;
                headerParameters[13].Value = headerModel.ATTACHED_FLAG;
                headerParameters[14].Value = headerModel.UPDATED_COUNT;
                headerParameters[15].Value = headerModel.VERIFY_FLAG;
                headerParameters[16].Value = headerModel.CURRENCY_CODE;
                headerParameters[17].Value = headerModel.ORDER_DEPOSIT;
                headerParameters[18].Value = headerModel.SHIPMENT_DEPOSIT;
                headerParameters[19].Value = headerModel.COMPANY_CODE;
                headerParameters[20].Value = headerModel.MEMO;
                headerParameters[21].Value = headerModel.AMOUNT_INCLUDED_TAX;
                headerParameters[22].Value = headerModel.AMOUNT_WITHOUT_TAX;
                headerParameters[23].Value = headerModel.TAX_RATE;
                headerParameters[24].Value = headerModel.TAX_AMOUNT;
                headerParameters[25].Value = headerModel.STATUS_FLAG;
                headerParameters[26].Value = headerModel.LAST_UPDATE_USER;
                headerParameters[27].Value = headerModel.CHECK_NUMBER;
                //headerParameters[28].Value = headerModel.CHECK_DATE;
                headerParameters[28].Value = CConstant.ALLOATION_UN;
                headerParameters[29].Value = headerModel.ORDER_DEPOSIT_DATE;
                headerParameters[30].Value = headerModel.ORDER_SHIPMENT_DEPOSIT_DATE;
                headerParameters[31].Value = headerModel.QUOTES_NUMBER;
                headerParameters[32].Value = headerModel.PRODUCE_FLAG;
                headerParameters[33].Value = headerModel.QUANTITY;
                headerParameters[34].Value = headerModel.DISCOUNT_AMOUNT;
                headerParameters[35].Value = headerModel.DELIVERY_TERMS;
                headerParameters[36].Value = headerModel.PAYMENT_TERMS;
                headerParameters[37].Value = headerModel.VER;
                headerParameters[38].Value = headerModel.DISCOUNT_RATE;
                headerParameters[39].Value = headerModel.TO_CUSTOMER_MEMO;
                listSql.Add(new CommandInfo(strSql.ToString(), headerParameters));

                #endregion

                //明细数据的先删除
                #region
                strSql = new StringBuilder();
                strSql.AppendFormat("delete from  BLL_ORDER_LINE ");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] deleteLineParameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                deleteLineParameters[0].Value = headerModel.SLIP_NUMBER;
                listSql.Add(new CommandInfo(strSql.ToString(), deleteLineParameters));
                #endregion

                //明细数据的重新插入
                #region
                foreach (BllOrderLineTable lineModel in headerModel.Items)
                {
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_ORDER_LINE(");
                    strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT,CURRENCY_CODE,MEMO,STATUS_FLAG,SHIPMENT_FLAG,ALLOATION_QUANTITY,SHIPMENT_QUANTITY,METERIAL,PARTS_CODE,SPEC,DESCRIPTION,DISCOUNT,DESCRIPTION1)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT,@CURRENCY_CODE,@MEMO,@STATUS_FLAG,@SHIPMENT_FLAG,@ALLOATION_QUANTITY,@SHIPMENT_QUANTITY,@METERIAL,@PARTS_CODE,@SPEC,@DESCRIPTION,@DISCOUNT,@DESCRIPTION1)");
                    SqlParameter[] lineParameters = {
                            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
                            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
                            new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),
                            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
                            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@SHIPMENT_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@ALLOATION_QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@SHIPMENT_QUANTITY", SqlDbType.Decimal,9),
                             new SqlParameter("@METERIAL", SqlDbType.VarChar,50),    
                            new SqlParameter("@PARTS_CODE", SqlDbType.VarChar,50),   
                            new SqlParameter("@SPEC", SqlDbType.VarChar,50),   
                            new SqlParameter("@DESCRIPTION", SqlDbType.VarChar,50),   
                            new SqlParameter("@DISCOUNT", SqlDbType.Decimal,9),   
                            new SqlParameter("@DESCRIPTION1", SqlDbType.VarChar,50)};
                    lineParameters[0].Value = headerModel.SLIP_NUMBER;
                    lineParameters[1].Value = lineModel.LINE_NUMBER;
                    lineParameters[2].Value = lineModel.PRODUCT_CODE;
                    lineParameters[3].Value = lineModel.QUANTITY;
                    lineParameters[4].Value = lineModel.UNIT_CODE;
                    lineParameters[5].Value = lineModel.PRICE;
                    lineParameters[6].Value = lineModel.AMOUNT;
                    lineParameters[7].Value = lineModel.CURRENCY_CODE;
                    lineParameters[8].Value = lineModel.MEMO;
                    lineParameters[9].Value = lineModel.STATUS_FLAG;
                    lineParameters[10].Value = lineModel.SHIPMENT_FLAG;
                    lineParameters[11].Value = lineModel.ALLOATION_QUANTITY;
                    lineParameters[12].Value = lineModel.SHIPMENT_QUANTITY;
                    lineParameters[13].Value = lineModel.METERIAL;
                    lineParameters[14].Value = lineModel.PARTS_CODE;
                    lineParameters[15].Value = lineModel.SPEC;
                    lineParameters[16].Value = lineModel.DESCRIPTION;
                    lineParameters[17].Value = lineModel.PRICE_DISCOUNT;
                    lineParameters[18].Value = lineModel.DESCRIPTION1;
                    listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
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

        public int UpdateProduce(List<BllOrderHeaderTable> orderList)
        {
            int result = 0;
            foreach (BllOrderHeaderTable orderTable in orderList)
            {
                StringBuilder strSql = new StringBuilder();
                strSql = new StringBuilder();
                strSql.Append("update BLL_ORDER_HEADER set ");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
                strSql.Append("PRODUCE_FLAG=@PRODUCE_FLAG");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] headerParameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),					
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),                   
                    new SqlParameter("@PRODUCE_FLAG", SqlDbType.Int,4)};
                headerParameters[0].Value = orderTable.SLIP_NUMBER;
                headerParameters[1].Value = orderTable.LAST_UPDATE_USER;
                headerParameters[2].Value = orderTable.PRODUCE_FLAG;

                result = DbHelperSQL.ExecuteSql(strSql.ToString(), headerParameters);
            }
            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string slipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_ORDER_HEADER set STATUS_FLAG={0} ", CConstant.DELETE);
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
        public BllOrderHeaderTable GetModel(string slipNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from bll_order_header_model_view ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            strSql.Append(" order by LINE_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = slipNumber;

            BllOrderHeaderTable headerTable = new BllOrderHeaderTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                bool isFirst = true;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        headerTable.SLIP_NUMBER = dr["SLIP_NUMBER"].ToString();
                        if (dr["SLIP_DATE"].ToString() != "")
                        {
                            headerTable.SLIP_DATE = DateTime.Parse(dr["SLIP_DATE"].ToString());
                        }
                        headerTable.SLIP_TYPE = dr["SLIP_TYPE"].ToString();
                        headerTable.SERIAL_NUMBER = dr["SERIAL_NUMBER"].ToString();
                        headerTable.OWNER_PO_NUMBER = dr["OWNER_PO_NUMBER"].ToString();
                        headerTable.CUSTOMER_PO_NUMBER = dr["CUSTOMER_PO_NUMBER"].ToString();
                        headerTable.DELIVERY_POINT_CODE = dr["DELIVERY_POINT_CODE"].ToString();
                        headerTable.CUSTOMER_CODE = dr["CUSTOMER_CODE"].ToString();
                        headerTable.ENDER_CUSTOMER_CODE = dr["ENDER_CUSTOMER_CODE"].ToString();
                        headerTable.DEPARTUAL_WAREHOUSE_CODE = dr["DEPARTUAL_WAREHOUSE_CODE"].ToString();
                        if (dr["DEPARTUAL_DATE"].ToString() != "")
                        {
                            headerTable.DEPARTUAL_DATE = DateTime.Parse(dr["DEPARTUAL_DATE"].ToString());
                        }
                        if (dr["DUE_DATE"].ToString() != "")
                        {
                            headerTable.DUE_DATE = DateTime.Parse(dr["DUE_DATE"].ToString());
                        }
                        if (dr["SALES_EMPLOYEE_CODE"].ToString() != "")
                        {
                            headerTable.SALES_EMPLOYEE_CODE = dr["SALES_EMPLOYEE_CODE"].ToString();
                        }
                        if (dr["ATTACHED_FLAG"].ToString() != "")
                        {
                            headerTable.ATTACHED_FLAG = int.Parse(dr["ATTACHED_FLAG"].ToString());
                        }
                        if (dr["UPDATED_COUNT"].ToString() != "")
                        {
                            headerTable.UPDATED_COUNT = int.Parse(dr["UPDATED_COUNT"].ToString());
                        }
                        if (dr["VERIFY_FLAG"].ToString() != "")
                        {
                            headerTable.VERIFY_FLAG = int.Parse(dr["VERIFY_FLAG"].ToString());
                        }
                        // headerTable.CURRENCY_CODE = dr["CURRENCY_CODE"].ToString();
                        if (dr["ORDER_DEPOSIT"].ToString() != "")
                        {
                            headerTable.ORDER_DEPOSIT = decimal.Parse(dr["ORDER_DEPOSIT"].ToString());
                        }
                        if (dr["SHIPMENT_DEPOSIT"].ToString() != "")
                        {
                            headerTable.SHIPMENT_DEPOSIT = decimal.Parse(dr["SHIPMENT_DEPOSIT"].ToString());
                        }
                        headerTable.COMPANY_CODE = CConvert.ToString(dr["COMPANY_CODE"]);
                        headerTable.MEMO = CConvert.ToString(dr["MEMO"]);
                        if (dr["AMOUNT_INCLUDED_TAX"].ToString() != "")
                        {
                            headerTable.AMOUNT_INCLUDED_TAX = decimal.Parse(dr["AMOUNT_INCLUDED_TAX"].ToString());
                        }
                        if (dr["AMOUNT_WITHOUT_TAX"].ToString() != "")
                        {
                            headerTable.AMOUNT_WITHOUT_TAX = decimal.Parse(dr["AMOUNT_WITHOUT_TAX"].ToString());
                        }
                        if (dr["TAX_RATE"].ToString() != "")
                        {
                            headerTable.TAX_RATE = decimal.Parse(dr["TAX_RATE"].ToString());
                        }
                        if (dr["TAX_AMOUNT"].ToString() != "")
                        {
                            headerTable.TAX_AMOUNT = decimal.Parse(dr["TAX_AMOUNT"].ToString());
                        }
                        if (dr["ALLOATION_FLAG"].ToString() != "")
                        {
                            headerTable.ALLOATION_FLAG = int.Parse(dr["ALLOATION_FLAG"].ToString());
                        }
                        headerTable.CHECK_NUMBER = dr["CHECK_NUMBER"].ToString();
                        if (dr["CHECK_DATE"].ToString() != "")
                        {
                            headerTable.CHECK_DATE = DateTime.Parse(dr["CHECK_DATE"].ToString());
                        }
                        if (dr["ORDER_DEPOSIT_DATE"].ToString() != "")
                        {
                            headerTable.ORDER_DEPOSIT_DATE = DateTime.Parse(dr["ORDER_DEPOSIT_DATE"].ToString());
                        }
                        if (dr["ORDER_SHIPMENT_DEPOSIT_DATE"].ToString() != "")
                        {
                            headerTable.ORDER_SHIPMENT_DEPOSIT_DATE = DateTime.Parse(dr["ORDER_SHIPMENT_DEPOSIT_DATE"].ToString());
                        }
                        if (dr["STATUS_FLAG"].ToString() != "")
                        {
                            headerTable.STATUS_FLAG = int.Parse(dr["STATUS_FLAG"].ToString());
                        }
                        headerTable.CREATE_USER = dr["CREATE_USER"].ToString();
                        if (dr["CREATE_DATE_TIME"].ToString() != "")
                        {
                            headerTable.CREATE_DATE_TIME = DateTime.Parse(dr["CREATE_DATE_TIME"].ToString());
                        }
                        if (dr["LAST_UPDATE_TIME"].ToString() != "")
                        {
                            headerTable.LAST_UPDATE_TIME = DateTime.Parse(dr["LAST_UPDATE_TIME"].ToString());
                        }
                        headerTable.LAST_UPDATE_USER = CConvert.ToString(dr["LAST_UPDATE_USER"]);
                        headerTable.CUSTOMER_NAME = CConvert.ToString(dr["CUSTOMER_NAME"]);
                        headerTable.ENDER_CUSTOMER_NAME = CConvert.ToString(dr["ENDER_CUSTOMER_NAME"]);
                        headerTable.DELIVERY_POINT_NAME = CConvert.ToString(dr["DELIVERY_POINT_NAME"]);
                        headerTable.DEPARTUAL_WAREHOUSE_NAME = CConvert.ToString(dr["DEPARTUAL_WAREHOUSE_NAME"]);
                        headerTable.QUOTES_NUMBER = CConvert.ToString(dr["QUOTES_NUMBER"]);
                        headerTable.CURRENCY_NAME = CConvert.ToString(dr["CURRENCY_NAME"]);
                        if (ds.Tables[0].Rows[0]["PRODUCE_FLAG"].ToString() != "")
                        {
                            headerTable.PRODUCE_FLAG = int.Parse(ds.Tables[0].Rows[0]["PRODUCE_FLAG"].ToString());
                        }
                        //if (ds.Tables[0].Rows[0]["HEADER_QUANTITY"].ToString() != "")
                        //{
                        //    headerTable.QUANTITY = decimal.Parse(ds.Tables[0].Rows[0]["HEADER_QUANTITY"].ToString());
                        //}
                        if (dr["DISCOUNT_RATE"].ToString() != "")
                        {
                            headerTable.DISCOUNT_RATE = decimal.Parse(dr["DISCOUNT_RATE"].ToString());
                        }
                        if (dr["DELIVERY_TERMS"].ToString() != "")
                        {
                            headerTable.DELIVERY_TERMS = CConvert.ToString(dr["DELIVERY_TERMS"]);
                        }
                        if (dr["PAYMENT_TERMS"].ToString() != "")
                        {
                            headerTable.PAYMENT_TERMS = CConvert.ToString(dr["PAYMENT_TERMS"]);
                        }
                        if (dr["VER"].ToString() != "")
                        {
                            headerTable.VER = CConvert.ToString(dr["VER"]);
                        }
                        if (dr["CURRENCY_CODE"].ToString() != "")
                        {
                            headerTable.CURRENCY_CODE = CConvert.ToString(dr["CURRENCY_CODE"]);
                        }
                        if (dr["TO_CUSTOMER_MEMO"].ToString() != "")
                        {
                            headerTable.TO_CUSTOMER_MEMO = dr["TO_CUSTOMER_MEMO"].ToString();
                        }
                        if (dr["DISCOUNT_AMOUNT"].ToString() != "")
                        {
                            headerTable.DISCOUNT_AMOUNT = CConvert.ToDecimal(dr["DISCOUNT_AMOUNT"].ToString());
                        }
                    }


                    BllOrderLineTable lineTable = new BllOrderLineTable();
                    if (dr["LINE_NUMBER"].ToString() != "")
                    {
                        lineTable.LINE_NUMBER = int.Parse(dr["LINE_NUMBER"].ToString());
                    }
                    lineTable.PRODUCT_CODE = dr["PRODUCT_CODE"].ToString();
                    if (dr["QUANTITY"].ToString() != "")
                    {
                        lineTable.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    }
                    lineTable.UNIT_CODE = dr["UNIT_CODE"].ToString();
                    if (dr["PRICE"].ToString() != "")
                    {
                        lineTable.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    }
                    if (dr["AMOUNT"].ToString() != "")
                    {
                        lineTable.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    }
                    if (dr["LINE_CURRENCY_CODE"].ToString() != "")
                    {
                        lineTable.CURRENCY_CODE = dr["LINE_CURRENCY_CODE"].ToString();
                    }

                    if (dr["LINE_MEMO"].ToString() != "")
                    {
                        lineTable.MEMO = dr["LINE_MEMO"].ToString();
                    }

                    if (dr["LINE_STATUS_FLAG"].ToString() != "")
                    {
                        lineTable.STATUS_FLAG = int.Parse(dr["LINE_STATUS_FLAG"].ToString());
                    }
                    if (dr["SHIPMENT_FLAG"].ToString() != "")
                    {
                        lineTable.SHIPMENT_FLAG = int.Parse(dr["SHIPMENT_FLAG"].ToString());
                    }
                    if (dr["ALLOATION_QUANTITY"].ToString() != "")
                    {
                        lineTable.ALLOATION_QUANTITY = decimal.Parse(dr["ALLOATION_QUANTITY"].ToString());
                    }
                    if (dr["SHIPMENT_QUANTITY"].ToString() != "")
                    {
                        lineTable.SHIPMENT_QUANTITY = decimal.Parse(dr["SHIPMENT_QUANTITY"].ToString());
                    }
                    //if (dr["PRODUCT_NAME"].ToString() != "")
                    //{
                    //    lineTable.PRODUCT_NAME = dr["PRODUCT_NAME"].ToString();
                    //}
                    if (dr["PRODUCT_SPEC"].ToString() != "")
                    {
                        lineTable.PRODUCT_SPEC = dr["PRODUCT_SPEC"].ToString();
                    }
                    if (dr["UNIT_NAME"].ToString() != "")
                    {
                        lineTable.UNIT_NAME = dr["UNIT_NAME"].ToString();
                    }

                    if (dr["DESCRIPTION"].ToString() != "")
                    {
                        lineTable.DESCRIPTION = dr["DESCRIPTION"].ToString();
                    }
                    if (dr["METERIAL"].ToString() != "")
                    {
                        lineTable.METERIAL = dr["METERIAL"].ToString();
                    }
                    if (dr["PARTS_CODE"].ToString() != "")
                    {
                        lineTable.PARTS_CODE = dr["PARTS_CODE"].ToString();
                    }
                    if (dr["DISCOUNT"].ToString() != "")
                    {
                        lineTable.PRICE_DISCOUNT = decimal.Parse(dr["DISCOUNT"].ToString());
                    }
                    if (dr["SLIP_TYPE_NAME"].ToString() != "")
                    {
                        lineTable.PRODUCT_NAME = dr["SLIP_TYPE_NAME"].ToString();
                    }
                    if (dr["COMPOSITION_PRODUCTS_NAME"].ToString() != "")
                    {
                        lineTable.COMPOSITION_PRODUCTS_NAME = dr["COMPOSITION_PRODUCTS_NAME"].ToString();
                    }
                    if (dr["SPEC"].ToString() != "")
                    {
                        lineTable.SPEC = dr["SPEC"].ToString();
                    }
                    if (dr["DESCRIPTION1"].ToString() != "")
                    {
                        lineTable.DESCRIPTION1 = dr["DESCRIPTION1"].ToString();
                    }

                    headerTable.AddItem(lineTable);
                }
                return headerTable;
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
            strSql.Append("select * FROM bll_order_header_seach_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SLIP_NUMBER,CONVERT(varchar(12) , SLIP_DATE, 111) AS SLIP_DATE,SLIP_TYPE,SERIAL_NUMBER,OWNER_PO_NUMBER,CUSTOMER_PO_NUMBER,");
            strSql.Append(" DELIVERY_POINT_CODE,CUSTOMER_CODE,CUSTOMER_NAME,ENDER_CUSTOMER_CODE,ENDER_CUSTOMER_NAME,DEPARTUAL_WAREHOUSE_CODE,WAREHOUSE_NAME,CONVERT(varchar(12) , DEPARTUAL_DATE, 111) AS DEPARTUAL_DATE,");
            strSql.Append(" CONVERT(varchar(12) , DUE_DATE, 111) AS DUE_DATE,SALES_EMPLOYEE_CODE,ATTACHED_FLAG,ATTACHED_NAME,UPDATED_COUNT,VERIFY_FLAG,VERIFY_NAME,CURRENCY_NAME,ORDER_DEPOSIT,");
            strSql.Append(" SHIPMENT_DEPOSIT,COMPANY_NAME,MEMO,AMOUNT_INCLUDED_TAX,AMOUNT_WITHOUT_TAX,TAX_RATE,TAX_AMOUNT,");
            strSql.Append(" ALLOATION_FLAG,ALLOATION_NAME,SHIPMENT_NAME,SHIPMENT_QUANTITY,QUANTITY,CHECK_NUMBER,CHECK_DATE,STATUS_FLAG,CREATE_USER,CONVERT(varchar(12) , CREATE_DATE_TIME, 111) AS CREATE_DATE_TIME,CONVERT(varchar(12) , LAST_UPDATE_TIME, 111) AS LAST_UPDATE_TIME,LAST_UPDATE_USER,");
            strSql.Append("LINE_NUMBER,PRODUCT_NAME,LINE_QUANTITY,UNIT_NAME,PRICE,AMOUNT,CURRENCY_NAME,MEMO,ALLOATION_QUANTITY,LINE_SHIPMENT_QUANTITY ");
            strSql.Append(" FROM bll_order_print_view");
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
            strSql.Append("select count(1) from bll_order_header_seach_view");
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
            strSql.Append(")AS Row, T.* from bll_order_header_seach_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 订单承认、不承认
        /// </summary>
        public bool UpdateVerify(string slipNumber, int verifyFlag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_ORDER_HEADER set  ");
            strSql.Append("VERIFY_FLAG=@VERIFY_FLAG,");
            strSql.Append("CHECK_DATE=GETDATE()");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
                    new SqlParameter("@VERIFY_FLAG", SqlDbType.Int,9)};
            parameters[0].Value = slipNumber;
            parameters[1].Value = verifyFlag;
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

        #region history order_header
        /// <summary>
        /// 得到一个history对象实体
        /// </summary>
        public BllHistoryOrderHeaderTable GetHistoryModel(string historySlipNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from bll_history_order_header_model_view ");
            strSql.Append(" where HISTORY_NUMBER=@HISTORY_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@HISTORY_NUMBER", SqlDbType.Int,4)};
            parameters[0].Value = historySlipNumber;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            BllHistoryOrderHeaderTable historyHeaderTable = new BllHistoryOrderHeaderTable();
            if (ds.Tables[0].Rows.Count > 0)
            {
                bool isFirst = true;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        historyHeaderTable.HISTORY_NUMBER = CConvert.ToInt32(dr["HISTORY_NUMBER"]);
                        historyHeaderTable.SLIP_NUMBER = dr["SLIP_NUMBER"].ToString();
                        if (dr["SLIP_DATE"].ToString() != "")
                        {
                            historyHeaderTable.SLIP_DATE = DateTime.Parse(dr["SLIP_DATE"].ToString());
                        }
                        historyHeaderTable.SLIP_TYPE = dr["SLIP_TYPE"].ToString();
                        historyHeaderTable.SERIAL_NUMBER = dr["SERIAL_NUMBER"].ToString();
                        historyHeaderTable.OWNER_PO_NUMBER = dr["OWNER_PO_NUMBER"].ToString();
                        historyHeaderTable.CUSTOMER_PO_NUMBER = dr["CUSTOMER_PO_NUMBER"].ToString();
                        historyHeaderTable.DELIVERY_POINT_CODE = dr["DELIVERY_POINT_CODE"].ToString();
                        historyHeaderTable.CUSTOMER_CODE = dr["CUSTOMER_CODE"].ToString();
                        historyHeaderTable.ENDER_CUSTOMER_CODE = dr["ENDER_CUSTOMER_CODE"].ToString();
                        historyHeaderTable.DEPARTUAL_WAREHOUSE_CODE = dr["DEPARTUAL_WAREHOUSE_CODE"].ToString();
                        if (dr["DEPARTUAL_DATE"].ToString() != "")
                        {
                            historyHeaderTable.DEPARTUAL_DATE = DateTime.Parse(dr["DEPARTUAL_DATE"].ToString());
                        }
                        if (dr["DUE_DATE"].ToString() != "")
                        {
                            historyHeaderTable.DUE_DATE = DateTime.Parse(dr["DUE_DATE"].ToString());
                        }
                        historyHeaderTable.SALES_EMPLOYEE_CODE = dr["SALES_EMPLOYEE_CODE"].ToString();
                        if (dr["ATTACHED_FLAG"].ToString() != "")
                        {
                            historyHeaderTable.ATTACHED_FLAG = int.Parse(dr["ATTACHED_FLAG"].ToString());
                        }
                        if (dr["UPDATED_COUNT"].ToString() != "")
                        {
                            historyHeaderTable.UPDATED_COUNT = int.Parse(dr["UPDATED_COUNT"].ToString());
                        }
                        if (dr["VERIFY_FLAG"].ToString() != "")
                        {
                            historyHeaderTable.VERIFY_FLAG = int.Parse(dr["VERIFY_FLAG"].ToString());
                        }
                        if (dr["CURRENCY_CODE"].ToString() != "")
                        {
                            historyHeaderTable.CURRENCY_CODE = dr["CURRENCY_CODE"].ToString();
                        }
                        if (dr["ORDER_DEPOSIT"].ToString() != "")
                        {
                            historyHeaderTable.ORDER_DEPOSIT = decimal.Parse(dr["ORDER_DEPOSIT"].ToString());
                        }
                        if (dr["SHIPMENT_DEPOSIT"].ToString() != "")
                        {
                            historyHeaderTable.SHIPMENT_DEPOSIT = decimal.Parse(dr["SHIPMENT_DEPOSIT"].ToString());
                        }
                        historyHeaderTable.COMPANY_CODE = CConvert.ToString(dr["COMPANY_CODE"]);
                        historyHeaderTable.MEMO = CConvert.ToString(dr["MEMO"]);
                        if (dr["AMOUNT_INCLUDED_TAX"].ToString() != "")
                        {
                            historyHeaderTable.AMOUNT_INCLUDED_TAX = decimal.Parse(dr["AMOUNT_INCLUDED_TAX"].ToString());
                        }
                        if (dr["AMOUNT_WITHOUT_TAX"].ToString() != "")
                        {
                            historyHeaderTable.AMOUNT_WITHOUT_TAX = decimal.Parse(dr["AMOUNT_WITHOUT_TAX"].ToString());
                        }
                        if (dr["TAX_RATE"].ToString() != "")
                        {
                            historyHeaderTable.TAX_RATE = decimal.Parse(dr["TAX_RATE"].ToString());
                        }
                        if (dr["TAX_AMOUNT"].ToString() != "")
                        {
                            historyHeaderTable.TAX_AMOUNT = decimal.Parse(dr["TAX_AMOUNT"].ToString());
                        }
                        if (dr["ALLOATION_FLAG"].ToString() != "")
                        {
                            historyHeaderTable.ALLOATION_FLAG = int.Parse(dr["ALLOATION_FLAG"].ToString());
                        }
                        historyHeaderTable.CHECK_NUMBER = dr["CHECK_NUMBER"].ToString();
                        if (dr["CHECK_DATE"].ToString() != "")
                        {
                            historyHeaderTable.CHECK_DATE = DateTime.Parse(dr["CHECK_DATE"].ToString());
                        }
                        if (dr["ORDER_DEPOSIT_DATE"].ToString() != "")
                        {
                            historyHeaderTable.ORDER_DEPOSIT_DATE = DateTime.Parse(dr["ORDER_DEPOSIT_DATE"].ToString());
                        }
                        if (dr["ORDER_SHIPMENT_DEPOSIT_DATE"].ToString() != "")
                        {
                            historyHeaderTable.ORDER_SHIPMENT_DEPOSIT_DATE = DateTime.Parse(dr["ORDER_SHIPMENT_DEPOSIT_DATE"].ToString());
                        }
                        if (dr["STATUS_FLAG"].ToString() != "")
                        {
                            historyHeaderTable.STATUS_FLAG = int.Parse(dr["STATUS_FLAG"].ToString());
                        }
                        historyHeaderTable.CREATE_USER = dr["CREATE_USER"].ToString();
                        if (dr["CREATE_DATE_TIME"].ToString() != "")
                        {
                            historyHeaderTable.CREATE_DATE_TIME = DateTime.Parse(dr["CREATE_DATE_TIME"].ToString());
                        }
                        if (dr["LAST_UPDATE_TIME"].ToString() != "")
                        {
                            historyHeaderTable.LAST_UPDATE_TIME = DateTime.Parse(dr["LAST_UPDATE_TIME"].ToString());
                        }
                        historyHeaderTable.LAST_UPDATE_USER = CConvert.ToString(dr["LAST_UPDATE_USER"]);
                        historyHeaderTable.CUSTOMER_NAME = CConvert.ToString(dr["CUSTOMER_NAME"]);
                        historyHeaderTable.ENDER_CUSTOMER_NAME = CConvert.ToString(dr["ENDER_CUSTOMER_NAME"]);
                        historyHeaderTable.DELIVERY_POINT_NAME = CConvert.ToString(dr["DELIVERY_POINT_NAME"]);
                        historyHeaderTable.DEPARTUAL_WAREHOUSE_NAME = CConvert.ToString(dr["DEPARTUAL_WAREHOUSE_NAME"]);
                        historyHeaderTable.QUOTES_NUMBER = CConvert.ToString(dr["QUOTES_NUMBER"]);
                        if (dr["DISCOUNT_RATE"].ToString() != "")
                        {
                            historyHeaderTable.DISCOUNT_RATE = decimal.Parse(dr["DISCOUNT_RATE"].ToString());
                        }
                        if (dr["DELIVERY_TERMS"].ToString() != "")
                        {
                            historyHeaderTable.DELIVERY_TERMS = CConvert.ToString(dr["DELIVERY_TERMS"]);
                        }
                        if (dr["PAYMENT_TERMS"].ToString() != "")
                        {
                            historyHeaderTable.PAYMENT_TERMS = CConvert.ToString(dr["PAYMENT_TERMS"]);
                        }
                        if (dr["VER"].ToString() != "")
                        {
                            historyHeaderTable.VER = CConvert.ToString(dr["VER"]);
                        }
                        if (dr["DISCOUNT_AMOUNT"].ToString() != "")
                        {
                            historyHeaderTable.DISCOUNT_AMOUNT = decimal.Parse(CConvert.ToString(dr["DISCOUNT_AMOUNT"]));
                        }
                        if (dr["TO_CUSTOMER_MEMO"].ToString() != "")
                        {
                            historyHeaderTable.TO_CUSTOMER_MEMO = dr["TO_CUSTOMER_MEMO"].ToString();
                        }

                    }


                    BllHistoryOrderLineTable historyLineTable = new BllHistoryOrderLineTable();
                    if (dr["LINE_NUMBER"].ToString() != "")
                    {
                        historyLineTable.LINE_NUMBER = int.Parse(dr["LINE_NUMBER"].ToString());
                    }
                    historyLineTable.PRODUCT_CODE = dr["PRODUCT_CODE"].ToString();
                    if (dr["QUANTITY"].ToString() != "")
                    {
                        historyLineTable.QUANTITY = decimal.Parse(dr["QUANTITY"].ToString());
                    }
                    historyLineTable.UNIT_CODE = dr["UNIT_CODE"].ToString();
                    if (dr["PRICE"].ToString() != "")
                    {
                        historyLineTable.PRICE = decimal.Parse(dr["PRICE"].ToString());
                    }
                    if (dr["AMOUNT"].ToString() != "")
                    {
                        historyLineTable.AMOUNT = decimal.Parse(dr["AMOUNT"].ToString());
                    }
                    if (dr["LINE_CURRENCY_CODE"].ToString() != "")
                    {
                        historyLineTable.CURRENCY_CODE = dr["LINE_CURRENCY_CODE"].ToString();
                    }
                    if (dr["LINE_MEMO"].ToString() != "")
                    {
                        historyLineTable.MEMO = dr["LINE_MEMO"].ToString();
                    }
                    if (dr["LINE_STATUS_FLAG"].ToString() != "")
                    {
                        historyLineTable.STATUS_FLAG = int.Parse(dr["LINE_STATUS_FLAG"].ToString());
                    }
                    if (dr["SHIPMENT_FLAG"].ToString() != "")
                    {
                        historyLineTable.SHIPMENT_FLAG = int.Parse(dr["SHIPMENT_FLAG"].ToString());
                    }
                    if (dr["ALLOATION_QUANTITY"].ToString() != "")
                    {
                        historyLineTable.ALLOATION_QUANTITY = decimal.Parse(dr["ALLOATION_QUANTITY"].ToString());
                    }
                    if (dr["SHIPMENT_QUANTITY"].ToString() != "")
                    {
                        historyLineTable.SHIPMENT_QUANTITY = decimal.Parse(dr["SHIPMENT_QUANTITY"].ToString());
                    }
                    if (dr["PRODUCT_NAME"].ToString() != "")
                    {
                        historyLineTable.PRODUCT_NAME = dr["PRODUCT_NAME"].ToString();
                    }
                    if (dr["PRODUCT_SPEC"].ToString() != "")
                    {
                        historyLineTable.PRODUCT_SPEC = dr["PRODUCT_SPEC"].ToString();
                    }

                    if (dr["UNIT_NAME"].ToString() != "")
                    {
                        historyLineTable.UNIT_NAME = dr["UNIT_NAME"].ToString();
                    }

                    if (dr["DESCRIPTION"].ToString() != "")
                    {
                        historyLineTable.DESCRIPTION = dr["DESCRIPTION"].ToString();
                    }
                    if (dr["METERIAL"].ToString() != "")
                    {
                        historyLineTable.METERIAL = dr["METERIAL"].ToString();
                    }
                    if (dr["PARTS_CODE"].ToString() != "")
                    {
                        historyLineTable.PARTS_CODE = dr["PARTS_CODE"].ToString();
                    }
                    if (dr["DISCOUNT"].ToString() != "")
                    {
                        historyLineTable.PRICE_DISCOUNT = decimal.Parse(dr["DISCOUNT"].ToString());
                    }
                    if (dr["SLIP_TYPE_NAME"].ToString() != "")
                    {
                        historyLineTable.PRODUCT_NAME = dr["SLIP_TYPE_NAME"].ToString();
                    }
                    if (dr["COMPOSITION_PRODUCTS_NAME"].ToString() != "")
                    {
                        historyLineTable.COMPOSITION_PRODUCTS_NAME = dr["COMPOSITION_PRODUCTS_NAME"].ToString();
                    }
                    if (dr["SPEC"].ToString() != "")
                    {
                        historyLineTable.SPEC = dr["SPEC"].ToString();
                    }
                    if (dr["DESCRIPTION1"].ToString() != "")
                    {
                        historyLineTable.DESCRIPTION1 = dr["DESCRIPTION1"].ToString();
                    }

                    historyHeaderTable.AddItem(historyLineTable);
                }
                return historyHeaderTable;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataSet GetHistoryOrderList(string orderSlipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ''AS NO,HOH.*,BU.NAME AS LAST_UPDATE_USER_NAME from BLL_HISTORY_ORDER_HEADER AS HOH ");
            strSql.Append(" left join BASE_USER  AS BU ON BU.CODE = HOH.LAST_UPDATE_USER ");
            strSql.AppendFormat(" where  slip_number='{0}'", orderSlipNumber);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region IOrderHeader 成员


        public bool IsMechanicalBaseOrder(string slipNubmer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT count(1) ");
            strSql.Append(" FROM dbo.BLL_ORDER_HEADER AS OH  ");
            strSql.Append(" LEFT JOIN  dbo.BLL_ORDER_LINE  AS OL ON OH.SLIP_NUMBER = OL.SLIP_NUMBER ");
            strSql.Append(" LEFT JOIN BASE_PRODUCT AS P ON OL.PRODUCT_CODE = P.CODE ");
            strSql.AppendFormat(" WHERE P.MECHANICAL_DISTINCTION_FLAG = {0} ", CConstant.MECHANICAL_BASE);
            strSql.Append(" AND OH.SLIP_NUMBER =@SLIP_NUMBER ");
            strSql.AppendFormat(" AND OH.STATUS_FLAG <>{0}  ", CConstant.DELETE);

            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = slipNubmer;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters).ToString();
            if (CConvert.ToInt32(obj) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region  订单修理输入用

        /// <summary>
        /// 修理输入记录的添加
        /// </summary>
        public int AddOrderService(BllOrderServiceTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLL_ORDER_SERVICE(");
            strSql.Append("SLIP_NUMBER,TITLE,START_DATE_TIME,END_DATE_TIME,SERVICE_USER,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
            strSql.Append(" values (");
            strSql.Append("@SLIP_NUMBER,@TITLE,@START_DATE_TIME,@END_DATE_TIME,@SERVICE_USER,@MEMO,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@START_DATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@END_DATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@SERVICE_USER", SqlDbType.VarChar,50),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,1000),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@TITLE", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.SLIP_NUMBER;
            parameters[1].Value = model.START_DATE_TIME;
            parameters[2].Value = model.END_DATE_TIME;
            parameters[3].Value = model.SERVICE_USER;
            parameters[4].Value = model.MEMO;
            parameters[5].Value = model.STATUS_FLAG;
            parameters[6].Value = model.CREATE_USER;
            parameters[7].Value = model.LAST_UPDATE_USER;
            parameters[8].Value = model.TITLE;


            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        ///  修理输入记录的修正
        /// </summary>
        public int UpdateOrderService(BllOrderServiceTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLL_ORDER_SERVICE set ");
            strSql.Append("SLIP_NUMBER=@SLIP_NUMBER,");
            strSql.Append("START_DATE_TIME=@START_DATE_TIME,");
            strSql.Append("END_DATE_TIME=@END_DATE_TIME,");
            strSql.Append("SERVICE_USER=@SERVICE_USER,");
            strSql.Append("MEMO=@MEMO,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("TITLE=@TITLE");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@START_DATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@END_DATE_TIME", SqlDbType.DateTime),
					new SqlParameter("@SERVICE_USER", SqlDbType.VarChar,50),
					new SqlParameter("@MEMO", SqlDbType.NVarChar,1000),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@TITLE", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SLIP_NUMBER;
            parameters[2].Value = model.START_DATE_TIME;
            parameters[3].Value = model.END_DATE_TIME;
            parameters[4].Value = model.SERVICE_USER;
            parameters[5].Value = model.MEMO;
            parameters[6].Value = model.STATUS_FLAG;
            parameters[7].Value = model.LAST_UPDATE_USER;
            parameters[8].Value = model.TITLE;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }

        /// <summary>
        ///  修理输入记录的删除
        /// </summary>
        public int DeleteOrderService(BllOrderServiceTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLL_ORDER_SERVICE  ");
            strSql.AppendFormat(" set STATUS_FLAG ={0}", CConstant.DELETE);
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修理输入记录的取得
        /// </summary>
        public BllOrderServiceTable GetOrderServiceMode(string slipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SLIP_NUMBER,TITLE,START_DATE_TIME,END_DATE_TIME,SERVICE_USER,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME from BLL_ORDER_SERVICE ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            strSql.AppendFormat(" and STATUS_FLAG <> {0}", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = slipNumber;

            BllOrderServiceTable model = new BllOrderServiceTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                model.TITLE = ds.Tables[0].Rows[0]["TITLE"].ToString();
                if (ds.Tables[0].Rows[0]["START_DATE_TIME"].ToString() != "")
                {
                    model.START_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["START_DATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["END_DATE_TIME"].ToString() != "")
                {
                    model.END_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["END_DATE_TIME"].ToString());
                }
                model.SERVICE_USER = ds.Tables[0].Rows[0]["SERVICE_USER"].ToString();
                model.MEMO = ds.Tables[0].Rows[0]["MEMO"].ToString();
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
                return model;
            }
            else
            {
                return null;
            }
        }

        public DataSet GetOrderHeader(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM BLL_ORDER_HEADER");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataSet GetList1(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.* from BLL_ORDER_HEADER T");
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
        public int GetRecordCount1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BLL_ORDER_HEADER");
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

        public DataSet GetModelInfo(string slipNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_order_header_model_view ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            strSql.Append(" order by LINE_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = slipNumber;

            return DbHelperSQL.Query(strSql.ToString(), parameters);

        }
        public DataSet GetModelInfo1(string slipNumber, string productcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_order_header_model_view ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER and PRODUCT_CODE=@PRODUCT_CODE");
            strSql.Append(" order by LINE_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = slipNumber;
            parameters[1].Value = productcode;
            return DbHelperSQL.Query(strSql.ToString(), parameters);

        }
        #endregion
    }//end class
}
