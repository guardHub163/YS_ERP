using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.Model;
using System.Data;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class PurchaseOrderManage : IPurchaseOrder
    {
        public PurchaseOrderManage()
        { }

        #region 取得当前最大采购订单流水号
        /// <summary>
        /// 取得当前最大采购订单流水号
        /// </summary>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public string GetMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(max(SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from get_purchase_order_max_slip_number");
            return CConvert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        }
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CZZD.ERP.Model.BllPurchaseOrderTable model)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    #region 主表
                    strSql.Append("insert into BLL_PURCHASE_ORDER(");
                    strSql.Append("SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE )");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@COMPANY_CODE )");
                    SqlParameter[] parameters = {
					            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					            new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					            new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                                new SqlParameter("@TOTAL_AMOUNT",SqlDbType.Decimal,15),
					            new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					            new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                                new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
                    parameters[0].Value = model.SLIP_NUMBER;
                    parameters[1].Value = model.SLIP_DATE;
                    parameters[2].Value = model.SLIP_TYPE;
                    parameters[3].Value = model.ORDER_SLIP_NUMBER;
                    parameters[4].Value = model.SUPPLIER_ORDER_NUMBER;
                    parameters[5].Value = model.SUPPLIER_CODE;
                    parameters[6].Value = model.RECEIPT_WAREHOUSE_CODE;
                    parameters[7].Value = model.DUE_DATE;
                    parameters[8].Value = model.TOTAL_AMOUNT;
                    parameters[9].Value = model.TAX_RATE;
                    parameters[10].Value = model.CURRENCY_CODE;
                    parameters[11].Value = model.PACKING_METHOD;
                    parameters[12].Value = model.PAYMENT_CONDITION;
                    parameters[13].Value = model.MEMO;
                    parameters[14].Value = model.STATUS_FLAG;
                    parameters[15].Value = model.CREATE_USER;
                    parameters[16].Value = model.LAST_UPDATE_USER;
                    parameters[17].Value = model.COMPANY_CODE;
                    listSql.Add(new CommandInfo(strSql.ToString(), parameters));
                    #endregion

                    //SEQ 
                    //listSql.Add(CommonManage.GetSeqUpDateSql(CConstant.SEQ_PURCHASE_ORDER));

                    //明细插入
                    foreach (BllPurchaseOrderLineTable lineModel in model.Items)
                    {
                        strSql = new StringBuilder();
                        #region　明细
                        strSql.Append("insert into BLL_PURCHASE_ORDER_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG)");
                        SqlParameter[] lineParameters = {
					            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                        lineParameters[0].Value = model.SLIP_NUMBER;
                        lineParameters[1].Value = lineModel.LINE_NUMBER;
                        lineParameters[2].Value = lineModel.PRODUCT_CODE;
                        lineParameters[3].Value = lineModel.QUANTITY;
                        lineParameters[4].Value = lineModel.UNIT_CODE;
                        lineParameters[5].Value = lineModel.PRICE;
                        lineParameters[6].Value = lineModel.AMOUNT_WITHOUT_TAX;
                        lineParameters[7].Value = lineModel.TAX_AMOUNT;
                        lineParameters[8].Value = lineModel.AMOUNT_INCLUDED_TAX;
                        lineParameters[9].Value = lineModel.STATUS_FLAG;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
                        #endregion

                        #region 入库预定
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_RECEIPT_PLAN(");
                        strSql.Append("PURCHASE_ORDER_SLIP_NUMBER,PURCHASE_ORDER_LINE_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,COMPANY_CODE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,PRODUCT_CODE,QUANTITY,RECEIPT_PLAN_QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                        strSql.Append(" values (");
                        strSql.Append("@PURCHASE_ORDER_SLIP_NUMBER,@PURCHASE_ORDER_LINE_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@COMPANY_CODE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@PRODUCT_CODE,@QUANTITY,@RECEIPT_PLAN_QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");

                        SqlParameter[] rpParameters = {
					            new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@PURCHASE_ORDER_LINE_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					            new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					            new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                                new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@TOTAL_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					            new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@RECEIPT_PLAN_QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                        rpParameters[0].Value = model.SLIP_NUMBER;
                        rpParameters[1].Value = lineModel.LINE_NUMBER;
                        rpParameters[2].Value = model.SLIP_DATE;
                        rpParameters[3].Value = model.SLIP_TYPE;
                        rpParameters[4].Value = model.ORDER_SLIP_NUMBER;
                        rpParameters[5].Value = model.SUPPLIER_ORDER_NUMBER;
                        rpParameters[6].Value = model.SUPPLIER_CODE;
                        rpParameters[7].Value = model.RECEIPT_WAREHOUSE_CODE;
                        rpParameters[8].Value = model.DUE_DATE;
                        rpParameters[9].Value = model.COMPANY_CODE;
                        rpParameters[10].Value = model.TOTAL_AMOUNT;
                        rpParameters[11].Value = model.TAX_RATE;
                        rpParameters[12].Value = model.CURRENCY_CODE;
                        rpParameters[13].Value = model.PACKING_METHOD;
                        rpParameters[14].Value = model.PAYMENT_CONDITION;
                        rpParameters[15].Value = model.MEMO;
                        rpParameters[16].Value = lineModel.PRODUCT_CODE;
                        rpParameters[17].Value = lineModel.QUANTITY;
                        rpParameters[18].Value = lineModel.QUANTITY;
                        rpParameters[19].Value = lineModel.UNIT_CODE;
                        rpParameters[20].Value = lineModel.PRICE;
                        rpParameters[21].Value = lineModel.AMOUNT_WITHOUT_TAX;
                        rpParameters[22].Value = lineModel.TAX_AMOUNT;
                        rpParameters[23].Value = lineModel.AMOUNT_INCLUDED_TAX;
                        rpParameters[24].Value = CConstant.INIT;
                        rpParameters[25].Value = model.CREATE_USER;
                        rpParameters[26].Value = model.LAST_UPDATE_USER;
                        listSql.Add(new CommandInfo(strSql.ToString(), rpParameters));
                        #endregion
                    }

                    result = DbHelperSQL.ExecuteSqlTran(listSql);

                }
                catch (SqlException ex)
                {

                    model.SLIP_NUMBER = CommonManage.GetSeq(CConstant.SEQ_PURCHASE_ORDER);
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
        #endregion

        #region  更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BllPurchaseOrderTable model)
        {

            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            #region 主表
            strSql.Append("update BLL_PURCHASE_ORDER set ");
            strSql.Append("SLIP_DATE=@SLIP_DATE,");
            strSql.Append("SLIP_TYPE=@SLIP_TYPE,");
            strSql.Append("ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER,");
            strSql.Append("SUPPLIER_ORDER_NUMBER=@SUPPLIER_ORDER_NUMBER,");
            strSql.Append("SUPPLIER_CODE=@SUPPLIER_CODE,");
            strSql.Append("RECEIPT_WAREHOUSE_CODE=@RECEIPT_WAREHOUSE_CODE,");
            strSql.Append("DUE_DATE=@DUE_DATE,");
            strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
            strSql.Append("TOTAL_AMOUNT=@TOTAL_AMOUNT,");
            strSql.Append("TAX_RATE=@TAX_RATE,");
            strSql.Append("CURRENCY_CODE=@CURRENCY_CODE,");
            strSql.Append("PACKING_METHOD=@PACKING_METHOD,");
            strSql.Append("PAYMENT_CONDITION=@PAYMENT_CONDITION,");
            strSql.Append("MEMO=@MEMO,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("CREATE_USER=@CREATE_USER,");
            strSql.Append("CREATE_DATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					    new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					    new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                        new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@TOTAL_AMOUNT",SqlDbType.Decimal,15),
					    new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					    new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					    new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					    new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            parameters[0].Value = model.SLIP_NUMBER;
            parameters[1].Value = model.SLIP_DATE;
            parameters[2].Value = model.SLIP_TYPE;
            parameters[3].Value = model.ORDER_SLIP_NUMBER;
            parameters[4].Value = model.SUPPLIER_ORDER_NUMBER;
            parameters[5].Value = model.SUPPLIER_CODE;
            parameters[6].Value = model.RECEIPT_WAREHOUSE_CODE;
            parameters[7].Value = model.DUE_DATE;
            parameters[8].Value = model.COMPANY_CODE;
            parameters[9].Value = model.TOTAL_AMOUNT;
            parameters[10].Value = model.TAX_RATE;
            parameters[11].Value = model.CURRENCY_CODE;
            parameters[12].Value = model.PACKING_METHOD;
            parameters[13].Value = model.PAYMENT_CONDITION;
            parameters[14].Value = model.MEMO;
            parameters[15].Value = model.STATUS_FLAG;
            parameters[16].Value = model.CREATE_USER;
            parameters[17].Value = model.LAST_UPDATE_USER;
            listSql.Add(new CommandInfo(strSql.ToString(), parameters));
            #endregion

            #region 原有入库预定的删除
            strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_RECEIPT_PLAN set STATUS_FLAG={0} ", CConstant.DELETE);
            strSql.Append(" where PURCHASE_ORDER_SLIP_NUMBER=@PURCHASE_ORDER_SLIP_NUMBER ");
            SqlParameter[] delRPParameters = {
					                new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20)};
            delRPParameters[0].Value = model.SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), delRPParameters));
            #endregion

            #region 原有采购明细的删除
            strSql = new StringBuilder();
            strSql.Append("delete from BLL_PURCHASE_ORDER_LINE ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] delLineParameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            delLineParameters[0].Value = model.SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), delLineParameters));
            #endregion


            foreach (BllPurchaseOrderLineTable lineModel in model.Items)
            {
                strSql = new StringBuilder();
                #region　明细
                strSql.Append("insert into BLL_PURCHASE_ORDER_LINE(");
                strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG)");
                strSql.Append(" values (");
                strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG)");
                SqlParameter[] lineParameters = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					        new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					        new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					        new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                lineParameters[0].Value = model.SLIP_NUMBER;
                lineParameters[1].Value = lineModel.LINE_NUMBER;
                lineParameters[2].Value = lineModel.PRODUCT_CODE;
                lineParameters[3].Value = lineModel.QUANTITY;
                lineParameters[4].Value = lineModel.UNIT_CODE;
                lineParameters[5].Value = lineModel.PRICE;
                lineParameters[6].Value = lineModel.AMOUNT_WITHOUT_TAX;
                lineParameters[7].Value = lineModel.TAX_AMOUNT;
                lineParameters[8].Value = lineModel.AMOUNT_INCLUDED_TAX;
                lineParameters[9].Value = lineModel.STATUS_FLAG;
                listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
                #endregion

                #region 入库预定
                strSql = new StringBuilder();
                strSql.Append("insert into BLL_RECEIPT_PLAN(");
                strSql.Append("PURCHASE_ORDER_SLIP_NUMBER,PURCHASE_ORDER_LINE_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,COMPANY_CODE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,PRODUCT_CODE,QUANTITY,RECEIPT_PLAN_QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                strSql.Append(" values (");
                strSql.Append("@PURCHASE_ORDER_SLIP_NUMBER,@PURCHASE_ORDER_LINE_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@COMPANY_CODE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@PRODUCT_CODE,@QUANTITY,@RECEIPT_PLAN_QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");

                SqlParameter[] rpParameters = {
					        new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@PURCHASE_ORDER_LINE_NUMBER", SqlDbType.Int,4),
					        new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					        new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					        new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                            new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@TOTAL_AMOUNT", SqlDbType.Decimal,9),
					        new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					        new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					        new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					        new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@RECEIPT_PLAN_QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					        new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					        new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					        new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					        new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                rpParameters[0].Value = model.SLIP_NUMBER;
                rpParameters[1].Value = lineModel.LINE_NUMBER;
                rpParameters[2].Value = model.SLIP_DATE;
                rpParameters[3].Value = model.SLIP_TYPE;
                rpParameters[4].Value = model.ORDER_SLIP_NUMBER;
                rpParameters[5].Value = model.SUPPLIER_ORDER_NUMBER;
                rpParameters[6].Value = model.SUPPLIER_CODE;
                rpParameters[7].Value = model.RECEIPT_WAREHOUSE_CODE;
                rpParameters[8].Value = model.DUE_DATE;
                rpParameters[9].Value = model.COMPANY_CODE;
                rpParameters[10].Value = model.TOTAL_AMOUNT;
                rpParameters[11].Value = model.TAX_RATE;
                rpParameters[12].Value = model.CURRENCY_CODE;
                rpParameters[13].Value = model.PACKING_METHOD;
                rpParameters[14].Value = model.PAYMENT_CONDITION;
                rpParameters[15].Value = model.MEMO;
                rpParameters[16].Value = lineModel.PRODUCT_CODE;
                rpParameters[17].Value = lineModel.QUANTITY;
                rpParameters[18].Value = lineModel.QUANTITY;
                rpParameters[19].Value = lineModel.UNIT_CODE;
                rpParameters[20].Value = lineModel.PRICE;
                rpParameters[21].Value = lineModel.AMOUNT_WITHOUT_TAX;
                rpParameters[22].Value = lineModel.TAX_AMOUNT;
                rpParameters[23].Value = lineModel.AMOUNT_INCLUDED_TAX;
                rpParameters[24].Value = CConstant.INIT;
                rpParameters[25].Value = model.CREATE_USER;
                rpParameters[26].Value = model.LAST_UPDATE_USER;
                listSql.Add(new CommandInfo(strSql.ToString(), rpParameters));
                #endregion

            }
            return DbHelperSQL.ExecuteSqlTran(listSql);
        }

        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SLIP_NUMBER)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_PURCHASE_ORDER set STATUS_FLAG={0} ", CConstant.DELETE);
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), parameters));

            strSql = new StringBuilder();
            strSql.Append("DELETE BLL_RECEIPT_PLAN ");
            strSql.Append(" where PURCHASE_ORDER_SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] receiptParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            receiptParam[0].Value = SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), receiptParam));

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
        #endregion

        #region 得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CZZD.ERP.Model.BllPurchaseOrderTable GetModel(string SLIP_NUMBER)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,COMPANY_CODE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER from BLL_PURCHASE_ORDER ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            BllPurchaseOrderTable POModel = new BllPurchaseOrderTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                POModel.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                if (ds.Tables[0].Rows[0]["SLIP_DATE"].ToString() != "")
                {
                    POModel.SLIP_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["SLIP_DATE"].ToString());
                }
                POModel.SLIP_TYPE = ds.Tables[0].Rows[0]["SLIP_TYPE"].ToString();
                POModel.ORDER_SLIP_NUMBER = ds.Tables[0].Rows[0]["ORDER_SLIP_NUMBER"].ToString();
                POModel.SUPPLIER_ORDER_NUMBER = ds.Tables[0].Rows[0]["SUPPLIER_ORDER_NUMBER"].ToString();
                POModel.SUPPLIER_CODE = ds.Tables[0].Rows[0]["SUPPLIER_CODE"].ToString();
                POModel.RECEIPT_WAREHOUSE_CODE = ds.Tables[0].Rows[0]["RECEIPT_WAREHOUSE_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["DUE_DATE"].ToString() != "")
                {
                    POModel.DUE_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["DUE_DATE"].ToString());
                }
                POModel.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString() != "")
                {
                    POModel.TOTAL_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TAX_RATE"].ToString() != "")
                {
                    POModel.TAX_RATE = decimal.Parse(ds.Tables[0].Rows[0]["TAX_RATE"].ToString());
                }
                POModel.CURRENCY_CODE = ds.Tables[0].Rows[0]["CURRENCY_CODE"].ToString();
                POModel.PACKING_METHOD = ds.Tables[0].Rows[0]["PACKING_METHOD"].ToString();
                POModel.PAYMENT_CONDITION = ds.Tables[0].Rows[0]["PAYMENT_CONDITION"].ToString();
                POModel.MEMO = ds.Tables[0].Rows[0]["MEMO"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    POModel.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                POModel.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    POModel.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    POModel.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                POModel.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();

                strSql = new StringBuilder();
                strSql.Append("SELECT * FROM BLL_PURCHASE_ORDER_LINE");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] lineParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                lineParam[0].Value = SLIP_NUMBER;
                ds = DbHelperSQL.Query(strSql.ToString(), lineParam);
                BllPurchaseOrderLineTable POLModel = null;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    POLModel = new BllPurchaseOrderLineTable();
                    POLModel.SLIP_NUMBER = CConvert.ToString(row["SLIP_NUMBER"]);
                    POLModel.LINE_NUMBER = CConvert.ToInt32(row["LINE_NUMBER"]);
                    POLModel.PRODUCT_CODE = CConvert.ToString(row["PRODUCT_CODE"]);
                    POLModel.QUANTITY = CConvert.ToDecimal(row["QUANTITY"]);
                    POLModel.UNIT_CODE = CConvert.ToString(row["UNIT_CODE"]);
                    POLModel.PRICE = CConvert.ToDecimal(row["PRICE"]);
                    POLModel.AMOUNT_WITHOUT_TAX = CConvert.ToDecimal(row["AMOUNT_WITHOUT_TAX"]);
                    POLModel.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(row["AMOUNT_INCLUDED_TAX"]);
                    POLModel.TAX_AMOUNT = CConvert.ToDecimal(row["TAX_AMOUNT"]);
                    POLModel.STATUS_FLAG = CConvert.ToInt32(row["STATUS_FLAG"]);

                    if (POLModel.SLIP_NUMBER != null)
                    {
                        POModel.AddItem(POLModel);
                    }
                }
                return POModel;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region  获得订单内容
        /// <summary>
        /// 获得订单内容
        /// </summary>
        public DataSet GetPurchaseOrderList(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_purchase_order_entry_view ");

            strSql.Append("where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion

        #region 采购分页查询
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_purchase_order_print_view");
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
            strSql.Append("select count(1) from bll_purchase_order_search_view");
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
                strSql.Append("order by T.SLIP_NUMBER asc");
            }
            strSql.Append(")AS Row, T.* from bll_purchase_order_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region  根据采购单编号获得所有己入库与未入库的预定数据
        /// <summary>
        /// 根据采购单编号获得所有己入库与未入库的预定数据
        /// </summary>
        public DataSet GetReceivingPlanByPurchaseOrderSlipNumber(string purchaseOrderSlipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from BLL_RECEIPT_PLAN ");

            strSql.Append("where PURCHASE_ORDER_SLIP_NUMBER=@SLIP_NUMBER ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0} ", CConstant.DELETE);

            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = purchaseOrderSlipNumber;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion

        #region 补充查询
        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetPurchaseSupplementRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_purchase_supplement_search_view  ");
            strSql.Append("where QUANTITY < SAFETY_STOCK ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
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

        public DataSet GetPurchaseSupplementList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WAREHOUSE_CODE,WAREHOUSE_NAME,PRODUCT_CODE,PRODUCT_NAME,MODEL_NUMBER,UNIT_NAME,SAFETY_STOCK,QUANTITY,MAX_QUANTITY,MIN_PURCHASE_QUANTITY,STATUS_FLAG,CREATE_NAME,CONVERT(varchar(12) ,CREATE_DATE_TIME ,111) AS CREATE_DATE_TIME,LAST_UPDATE_NAME,CONVERT(varchar(12) ,LAST_UPDATE_TIME ,111) AS LAST_UPDATE_TIME ");
            strSql.Append(" FROM bll_purchase_supplement_search_view ");
            strSql.Append(" where QUANTITY < SAFETY_STOCK ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetPurchaseSupplementList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.WAREHOUSE_CODE asc");
            }
            strSql.Append(")AS Row, T.* from bll_purchase_supplement_search_view T");
            strSql.Append(" WHERE T.QUANTITY < T.SAFETY_STOCK ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public decimal GetPurchaseQuantity(string warehouseCode, string productCode)
        {
            decimal purchaseQuantity = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ISNULL(SUM(RECEIPT_PLAN_QUANTITY),0) FROM BLL_RECEIPT_PLAN ");
            strSql.Append(" where RECEIPT_WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE = @PRODUCT_CODE");
            strSql.AppendFormat(" and STATUS_FLAG = {0} ", CConstant.INIT);
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)
                    };
            parameters[0].Value = warehouseCode;
            parameters[1].Value = productCode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                purchaseQuantity = CConvert.ToDecimal(obj);
            }
            return purchaseQuantity;
        }

        #endregion

        #region 主成品采购查询
        public DataSet GetPartsList(string PRODUCT_CODE, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.PRODUCT_CODE asc");
            }
            strSql.Append(")AS Row, T.* from BASE_PRODUCT_PARTS T");
            strSql.AppendFormat(" where PRODUCT_CODE =@PRODUCT_CODE and STATUS_FLAG <> {0}", CConstant.DELETE);

            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = PRODUCT_CODE;

            return DbHelperSQL.Query(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetPartsRecordCount(string PRODUCT_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_PRODUCT_PARTS");
            strSql.AppendFormat(" where PRODUCT_CODE =@PRODUCT_CODE and STATUS_FLAG <> {0}", CConstant.DELETE);

            SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)};
            parameters[0].Value = PRODUCT_CODE;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public CZZD.ERP.Model.BaseStockTable GetStockModel(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER from BASE_STOCK ");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

            BaseStockTable model = new BaseStockTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.WAREHOUSE_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                model.PRODUCT_CODE = ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
                model.UNIT_CODE = ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["QUANTITY"].ToString() != "")
                {
                    model.QUANTITY = decimal.Parse(ds.Tables[0].Rows[0]["QUANTITY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                model.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    model.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    model.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                model.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 实到数量
        public decimal GetReceiptActualQuantity(string PO_SLIP_NUMBER, string PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUM(QUANTITY) FROM bll_receipt_search_view ");
            strSql.Append("where PO_SLIP_NUMBER=@PO_SLIP_NUMBER and  PRODUCT_CODE=@PRODUCT_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0} ", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@PO_SLIP_NUMBER", SqlDbType.VarChar,50),
                    new SqlParameter("@PRODUCT_CODE",SqlDbType.VarChar,20)};
            parameters[0].Value = PO_SLIP_NUMBER;
            parameters[1].Value = PRODUCT_CODE;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return CConvert.ToDecimal(obj);
            }
        }
        #endregion

        #region IPurchaseOrder 成员

        /// <summary>
        /// 供应商供货平衡表
        /// </summary>
        public DataSet GetPurchaseBalanceList(string strWhere, string orderby)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_purchase_order_print_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 供应商供货平衡表
        /// </summary>
        public DataSet GetPurchaseBalanceBySupplier(string strWhere)
        {
            ////
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append(" SELECT ");
            //strSql.Append(" X.SUPPLIER_CODE, ");
            //strSql.Append(" X.PRODUCT_CODE, ");

            //strSql.Append(" SUM(ISNULL(X.AMOUNT_INCLUDED_TAX,0)) AS PURCHASE_AMOUNT, ");
            //strSql.Append(" SUM(ISNULL(X.PURCHASE_QUANTITY,0)) AS PURCHASE_QUANTITY, ");
            //strSql.Append(" AVG(ISNULL(X.PRICE,0)) AS AVERAGE_PRICE, ");
            //strSql.Append(" MAX(ISNULL(X.PRICE,0)) AS MAX_PRICE, ");
            //strSql.Append(" MIN(ISNULL(X.PRICE,0)) AS MIN_PRICE ");
            //strSql.Append(" from bll_supplier_evaluate_price AS X");
            //if (!string.IsNullOrEmpty(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" LEFT JOIN BASE_SUPPLIER AS BS ON TT.SUPPLIER_CODE = BS.CODE ");
            //strSql.Append(" LEFT JOIN BASE_PRODUCT AS BP ON TT.PRODUCT_CODE = BP.CODE ");


            ////
            //strSql = new StringBuilder();
            //strSql.Append(" SELECT ");
            //strSql.Append(" X.SUPPLIER_CODE, ");
            //strSql.Append(" X.PRODUCT_CODE, ");
            //strSql.Append(" SUM(X.PURCHASE_QUANTITY) AS PURCHASE_QUANTITY, ");
            //strSql.Append(" SUM(ISNULL(X.RECEIPT_QUANTITY,0)) AS RECEIPT_QUANTITY, ");
            //strSql.Append(" CASE ");
            //strSql.Append(" WHEN SUM(X.PURCHASE_QUANTITY)<>0 THEN ");
            //strSql.Append(" SUM(ISNULL(X.RECEIPT_QUANTITY,0))/SUM(X.PURCHASE_QUANTITY) ");
            //strSql.Append(" ELSE ");
            //strSql.Append(" 1 ");
            //strSql.Append(" END AS RECEIPT_RATE ");
            //strSql.Append(" from bll_supplier_evaluate_receipt AS X");
            //if (!string.IsNullOrEmpty(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" LEFT JOIN BASE_SUPPLIER AS BS ON TT.SUPPLIER_CODE = BS.CODE ");
            //strSql.Append(" LEFT JOIN BASE_PRODUCT AS BP ON TT.PRODUCT_CODE = BP.CODE ");

            //return DbHelperSQL.Query(strSql.ToString());
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT T.SUPPLIER_CODE,");
            strSql.Append(" T.SUPPLIER_NAME, ");
            strSql.Append(" T.PRODUCT_CODE, ");
            strSql.Append(" T.PRODUCT_NAME, ");
            strSql.Append(" SUM(ISNULL(T.PURCHASE_QUANTITY,0)) AS PURCHASE_QUANTITY, ");
            strSql.Append(" SUM(T.ON_SCHEDULE_RECEIPT_QUANTITY) AS ON_SCHEDULE_RECEIPT_QUANTITY, ");
            strSql.Append(" SUM(T.PURCHASE_AMOUNT) AS PURCHASE_AMOUNT, ");
            strSql.Append(" MAX(T.PRICE) AS MAX_PRICE, ");
            strSql.Append(" MIN(T.PRICE) AS MIN_PRICE, ");
            strSql.Append(" AVG(T.PRICE) AS AVERAGE_PRICE, ");
            strSql.Append(" SUM(T.RECEIPT_QUANTITY) AS RECEIPT_QUANTITY, ");
            strSql.Append(" SUM(T.RERECEIPT_QUANTITY) AS RERECEIPT_QUANTITY ");
            strSql.Append(" from bll_supplier_relationship_view AS T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" GROUP BY T.SUPPLIER_CODE, T.SUPPLIER_NAME, T.PRODUCT_CODE, T.PRODUCT_NAME ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion

        #region IPurchaseOrder 自动采购

        /// <summary>
        /// //自动采购数据获得，按供应商，商品分类
        /// </summary>
        public DataSet GetAutoPurchaseList(string slipNumbers, bool isNetPurchase)
        {
            StringBuilder sb = new StringBuilder();
            if (!isNetPurchase) //毛采购
            {
                sb.Append(" SELECT    ");
                sb.Append(" TT.PRODUCT_CODE,    ");
                sb.Append(" TT.QUANTITY,   ");
                sb.Append(" BP.BASIC_UNIT_CODE,    ");
                sb.Append(" BP.PURCHASE_PRICE,  ");
                sb.Append(" BPG.BASIC_SUPPLIER  ");
                sb.Append(" FROM (   ");
                sb.Append(" 	SELECT T.PRODUCT_CODE, SUM(T.QUANTITY) AS QUANTITY   ");
                sb.Append(" 	FROM (  ");
                sb.Append(" 		SELECT     ");
                sb.Append(" 		ISNULL(BPP.PRODUCT_PARTS_CODE,BOL.PRODUCT_CODE) AS PRODUCT_CODE,  ");
                sb.Append(" 		ISNULL(BOL.QUANTITY,1) * ISNULL(BPP.QUANTITY,1) AS QUANTITY    ");
                sb.Append(" 		FROM BLL_ORDER_HEADER AS BOH    ");
                sb.Append(" 		LEFT JOIN BLL_ORDER_LINE AS BOL ON BOH.SLIP_NUMBER = BOL.SLIP_NUMBER    ");
                sb.Append(" 		LEFT JOIN BASE_PRODUCT_PARTS AS BPP ON  BOL.PRODUCT_CODE = BPP.PRODUCT_CODE ");
                sb.AppendFormat(" 		WHERE BOH.SLIP_NUMBER IN ({0}) ", slipNumbers);
                sb.Append(" 	) AS T  ");
                sb.Append(" 	GROUP BY T.PRODUCT_CODE  ");
                sb.Append(" ) AS TT  ");
                sb.Append(" LEFT JOIN BASE_PRODUCT AS BP ON TT.PRODUCT_CODE = BP.CODE    ");
                sb.Append(" LEFT JOIN BASE_PRODUCT_GROUP AS BPG ON BPG.CODE = BP.GROUP_CODE  ");
                sb.AppendFormat(" WHERE BP.PRODUCT_FLAG={0}", CConstant.PRODUCT_FLAG_PURCHASE);
                sb.Append(" ORDER BY BPG.BASIC_SUPPLIER  ");
            }
            else //净采购
            {
                sb.Append(" SELECT    ");
                sb.Append(" TT.PRODUCT_CODE,    ");
                sb.Append(" ISNULL(TT.QUANTITY,0)-(ISNULL(ST.QUANTITY,0)+ISNULL(RPV.QUANTITY,0)-ISNULL(OLP.QUANTITY,0)) AS QUANTITY,   ");
                sb.Append(" BP.BASIC_UNIT_CODE,    ");
                sb.Append(" BP.PURCHASE_PRICE,  ");
                sb.Append(" BPG.BASIC_SUPPLIER  ");
                //本次订单需求数量
                sb.Append(" FROM (   ");
                sb.Append(" 	SELECT T.PRODUCT_CODE, SUM(T.QUANTITY) AS QUANTITY   ");
                sb.Append(" 	FROM (  ");
                sb.Append(" 		SELECT     ");
                sb.Append(" 		ISNULL(BPP.PRODUCT_PARTS_CODE,BOL.PRODUCT_CODE) AS PRODUCT_CODE,  ");
                sb.Append(" 		ISNULL(BOL.QUANTITY,1) * ISNULL(BPP.QUANTITY,1) AS QUANTITY    ");
                sb.Append(" 		FROM BLL_ORDER_HEADER AS BOH    ");
                sb.Append(" 		LEFT JOIN BLL_ORDER_LINE AS BOL ON BOH.SLIP_NUMBER = BOL.SLIP_NUMBER    ");
                sb.Append(" 		LEFT JOIN BASE_PRODUCT_PARTS AS BPP ON  BOL.PRODUCT_CODE = BPP.PRODUCT_CODE ");
                sb.AppendFormat(" 		WHERE BOH.SLIP_NUMBER IN ({0}) ", slipNumbers);
                sb.Append(" 	) AS T  ");
                sb.Append(" 	GROUP BY T.PRODUCT_CODE  ");
                sb.Append(" ) AS TT  ");
                //可用库存
                sb.Append(" LEFT JOIN ( ");
                sb.Append("     SELECT  ");
                sb.Append("     BP.CODE AS PRODUCT_CODE, ");
                sb.Append("     ISNULL(BS.QUANTITY,0) -ISNULL(BP.SAFETY_STOCK,0) AS QUANTITY ");
                sb.Append("     FROM BASE_PRODUCT AS BP ");
                sb.AppendFormat("     LEFT JOIN BASE_STOCK AS BS ON BS.PRODUCT_CODE = BP.CODE AND BS.WAREHOUSE_CODE = '{0}'", CConstant.DEFAULT_WAREHOUSE_CODE);//原料仓库
                sb.Append(" ) AS ST ON ST.PRODUCT_CODE = TT.PRODUCT_CODE ");
                //己采购未领出
                sb.Append(" LEFT JOIN ( ");
                sb.Append("     SELECT  ");
                sb.Append("     PRODUCT_CODE , ");
                sb.Append("     SUM(ISNULL(QUANTITY,0))-SUM(ISNULL(USED_QUANTITY,0)) AS QUANTITY ");
                sb.Append("     FROM BLL_ORDER_LINE_PRODUCT_PARTS ");
                sb.AppendFormat("     WHERE STATUS_FLAG <>{0} ", CConstant.DELETE);
                sb.Append("     GROUP BY PRODUCT_CODE ) AS OLP ON OLP.PRODUCT_CODE = TT.PRODUCT_CODE ");
                //采购未入库
                sb.Append(" LEFT JOIN ( ");
                sb.Append("     SELECT  ");
                sb.Append("     PRODUCT_CODE,  ");
                sb.Append("     SUM(ISNULL(RECEIPT_PLAN_QUANTITY,0)) AS QUANTITY  ");
                sb.Append("     FROM bll_receiving_plan_view   ");
                sb.AppendFormat("     WHERE STATUS_FLAG={0}  ", CConstant.INIT);
                sb.Append("     GROUP BY PRODUCT_CODE ) AS RPV ON RPV.PRODUCT_CODE = TT.PRODUCT_CODE ");
                //基本信息关联
                sb.Append(" LEFT JOIN BASE_PRODUCT AS BP ON TT.PRODUCT_CODE = BP.CODE    ");
                sb.Append(" LEFT JOIN BASE_PRODUCT_GROUP AS BPG ON BPG.CODE = BP.GROUP_CODE  ");
                //采购数量小于0的过滤掉
                sb.Append(" WHERE (ISNULL(TT.QUANTITY,0)-(ISNULL(ST.QUANTITY,0)+ISNULL(RPV.QUANTITY,0)-ISNULL(OLP.QUANTITY,0))) > 0");
                sb.AppendFormat(" AND BP.PRODUCT_FLAG={0}", CConstant.PRODUCT_FLAG_PURCHASE);

                sb.Append(" ORDER BY BPG.BASIC_SUPPLIER  ");
            }

            return DbHelperSQL.Query(sb.ToString());

        }

        /// <summary>
        /// 自动采购数据获得，按订单，商品分类
        /// </summary>
        public DataSet GetAutoPurchaseList(string slipNumbers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT T.SLIP_NUMBER ,T.PRODUCT_CODE, SUM(T.QUANTITY) AS QUANTITY   ");
            sb.Append(" FROM (  ");
            sb.Append(" SELECT   ");
            sb.Append(" BOH.SLIP_NUMBER ,  ");
            sb.Append(" ISNULL(BPP.PRODUCT_PARTS_CODE,BOL.PRODUCT_CODE) AS PRODUCT_CODE,    ");
            sb.Append(" ISNULL(BOL.QUANTITY,1) * ISNULL(BPP.QUANTITY,1) AS QUANTITY    ");
            sb.Append(" FROM BLL_ORDER_HEADER AS BOH    ");
            sb.Append(" LEFT JOIN BLL_ORDER_LINE AS BOL ON BOH.SLIP_NUMBER = BOL.SLIP_NUMBER    ");
            sb.Append(" LEFT JOIN BASE_PRODUCT_PARTS AS BPP ON  BOL.PRODUCT_CODE = BPP.PRODUCT_CODE AND  BPP.STATUS_FLAG <> 9   ");
            sb.AppendFormat(" WHERE BOH.SLIP_NUMBER IN ({0}) ", slipNumbers);
            sb.Append(" ) AS T  ");
            sb.Append(" GROUP BY T.SLIP_NUMBER,T.PRODUCT_CODE  ");

            return DbHelperSQL.Query(sb.ToString());
        }


        /// <summary>
        /// 自动采购执行
        /// </summary>
        public int AutoPurchase(List<BllPurchaseOrderTable> poList, List<BllOrderLineProductPartsTable> olppList, string orderSlipNumbers)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                int maxSlipNumber = CConvert.ToInt32(GetMaxSlipNumber());
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = null;
                    
                    foreach (BllPurchaseOrderTable model in poList)
                    {                        
                        maxSlipNumber++;
                        string poSlipNumber = DateTime.Now.ToString("yyyyMMdd") + maxSlipNumber.ToString().PadLeft(4, '0');
                        strSql = new StringBuilder();
                        #region 主表
                        strSql.Append("insert into BLL_PURCHASE_ORDER(");
                        strSql.Append("SLIP_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE )");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@COMPANY_CODE )");
                        SqlParameter[] parameters = {
					            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					            new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					            new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                                new SqlParameter("@TOTAL_AMOUNT",SqlDbType.Decimal,15),
					            new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					            new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                                new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
                        parameters[0].Value = poSlipNumber;
                        parameters[1].Value = model.SLIP_DATE;
                        parameters[2].Value = model.SLIP_TYPE;
                        parameters[3].Value = model.ORDER_SLIP_NUMBER;
                        parameters[4].Value = model.SUPPLIER_ORDER_NUMBER;
                        parameters[5].Value = model.SUPPLIER_CODE;
                        parameters[6].Value = model.RECEIPT_WAREHOUSE_CODE;
                        parameters[7].Value = model.DUE_DATE;
                        parameters[8].Value = model.TOTAL_AMOUNT;
                        parameters[9].Value = model.TAX_RATE;
                        parameters[10].Value = model.CURRENCY_CODE;
                        parameters[11].Value = model.PACKING_METHOD;
                        parameters[12].Value = model.PAYMENT_CONDITION;
                        parameters[13].Value = model.MEMO;
                        parameters[14].Value = model.STATUS_FLAG;
                        parameters[15].Value = model.CREATE_USER;
                        parameters[16].Value = model.LAST_UPDATE_USER;
                        parameters[17].Value = model.COMPANY_CODE;
                        listSql.Add(new CommandInfo(strSql.ToString(), parameters));
                        #endregion

                        //明细插入
                        foreach (BllPurchaseOrderLineTable lineModel in model.Items)
                        {
                            strSql = new StringBuilder();
                            #region　明细
                            strSql.Append("insert into BLL_PURCHASE_ORDER_LINE(");
                            strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG)");
                            strSql.Append(" values (");
                            strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG)");
                            SqlParameter[] lineParameters = {
					            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                            lineParameters[0].Value = poSlipNumber;
                            lineParameters[1].Value = lineModel.LINE_NUMBER;
                            lineParameters[2].Value = lineModel.PRODUCT_CODE;
                            lineParameters[3].Value = lineModel.QUANTITY;
                            lineParameters[4].Value = lineModel.UNIT_CODE;
                            lineParameters[5].Value = lineModel.PRICE;
                            lineParameters[6].Value = lineModel.AMOUNT_WITHOUT_TAX;
                            lineParameters[7].Value = lineModel.TAX_AMOUNT;
                            lineParameters[8].Value = lineModel.AMOUNT_INCLUDED_TAX;
                            lineParameters[9].Value = lineModel.STATUS_FLAG;
                            listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
                            #endregion

                            #region 入库预定
                            strSql = new StringBuilder();
                            strSql.Append("insert into BLL_RECEIPT_PLAN(");
                            strSql.Append("PURCHASE_ORDER_SLIP_NUMBER,PURCHASE_ORDER_LINE_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,COMPANY_CODE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,PRODUCT_CODE,QUANTITY,RECEIPT_PLAN_QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                            strSql.Append(" values (");
                            strSql.Append("@PURCHASE_ORDER_SLIP_NUMBER,@PURCHASE_ORDER_LINE_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@COMPANY_CODE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@PRODUCT_CODE,@QUANTITY,@RECEIPT_PLAN_QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");

                            SqlParameter[] rcpParameters = {
					            new SqlParameter("@PURCHASE_ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@PURCHASE_ORDER_LINE_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					            new SqlParameter("@SLIP_TYPE", SqlDbType.VarChar,20),
					            new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_ORDER_NUMBER", SqlDbType.VarChar,20),
					            new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@DUE_DATE", SqlDbType.DateTime),
                                new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@TOTAL_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PACKING_METHOD", SqlDbType.NVarChar,255),
					            new SqlParameter("@PAYMENT_CONDITION", SqlDbType.NVarChar,255),
					            new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
					            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@RECEIPT_PLAN_QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                            rcpParameters[0].Value = poSlipNumber;
                            rcpParameters[1].Value = lineModel.LINE_NUMBER;
                            rcpParameters[2].Value = model.SLIP_DATE;
                            rcpParameters[3].Value = model.SLIP_TYPE;
                            rcpParameters[4].Value = model.ORDER_SLIP_NUMBER;
                            rcpParameters[5].Value = model.SUPPLIER_ORDER_NUMBER;
                            rcpParameters[6].Value = model.SUPPLIER_CODE;
                            rcpParameters[7].Value = model.RECEIPT_WAREHOUSE_CODE;
                            rcpParameters[8].Value = model.DUE_DATE;
                            rcpParameters[9].Value = model.COMPANY_CODE;
                            rcpParameters[10].Value = model.TOTAL_AMOUNT;
                            rcpParameters[11].Value = model.TAX_RATE;
                            rcpParameters[12].Value = model.CURRENCY_CODE;
                            rcpParameters[13].Value = model.PACKING_METHOD;
                            rcpParameters[14].Value = model.PAYMENT_CONDITION;
                            rcpParameters[15].Value = model.MEMO;
                            rcpParameters[16].Value = lineModel.PRODUCT_CODE;
                            rcpParameters[17].Value = lineModel.QUANTITY;
                            rcpParameters[18].Value = lineModel.QUANTITY;
                            rcpParameters[19].Value = lineModel.UNIT_CODE;
                            rcpParameters[20].Value = lineModel.PRICE;
                            rcpParameters[21].Value = lineModel.AMOUNT_WITHOUT_TAX;
                            rcpParameters[22].Value = lineModel.TAX_AMOUNT;
                            rcpParameters[23].Value = lineModel.AMOUNT_INCLUDED_TAX;
                            rcpParameters[24].Value = CConstant.INIT;
                            rcpParameters[25].Value = model.CREATE_USER;
                            rcpParameters[26].Value = model.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), rcpParameters));
                            #endregion
                        }

                        //SEQ 
                        //listSql.Add(CommonManage.GetSeqUpDateSql(CConstant.SEQ_PURCHASE_ORDER));

                        //try
                        //{
                        //    poSlipNumber = poSlipNumber.Substring(0, poSlipNumber.Length - 4) + CConvert.ToString(CConvert.ToInt32(poSlipNumber.Substring(poSlipNumber.Length - 4, 4)) + 1).PadLeft(4, '0');
                        //}
                        //catch (Exception ex)
                        //{
                        //}

                    }

                    //History
                    foreach (BllOrderLineProductPartsTable model in olppList)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_ORDER_LINE_PRODUCT_PARTS(");
                        strSql.Append("ORDER_SLIP_NUMBER,PRODUCT_CODE,QUANTITY,USED_QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_USER,LAST_UPDATE_TIME)");
                        strSql.Append(" values (");
                        strSql.Append("@ORDER_SLIP_NUMBER,@PRODUCT_CODE,@QUANTITY,@USED_QUANTITY,@STATUS_FLAG,@CREATE_USER,GETDATE(),@LAST_UPDATE_USER,GETDATE())");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@USED_QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                        parameters[0].Value = model.ORDER_SLIP_NUMBER;
                        parameters[1].Value = model.PRODUCT_CODE;
                        parameters[2].Value = model.QUANTITY;
                        parameters[3].Value = model.USED_QUANTITY;
                        parameters[4].Value = model.STATUS_FLAG;
                        parameters[5].Value = model.CREATE_USER;
                        parameters[6].Value = model.LAST_UPDATE_USER;

                        listSql.Add(new CommandInfo(strSql.ToString(), parameters));

                    }

                    //销售订单采购状态的更新
                    strSql = new StringBuilder();
                    strSql.AppendFormat("UPDATE BLL_ORDER_HEADER SET PRODUCE_FLAG = {0} ", CConstant.AUTO_PURCHASE_COMPLETED);
                    strSql.AppendFormat(" WHERE SLIP_NUMBER IN ({0}) ", orderSlipNumbers);
                    listSql.Add(new CommandInfo(strSql.ToString(), null));

                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                }
                catch (SqlException ex)
                {
                    if (i != 9)
                    {
                        i++;
                        continue;
                    }
                }
                break;
            }
            return result;
        }
        #endregion
    } //end class
}
