using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using System.Data.SqlClient;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class ReceiptManage : IReceipt
    {

        #region 入库更新订单状态
        /// <summary>
        /// 入库更新订单状态
        /// </summary>
        /// <param name="SLIP_NUMBER"></param>
        /// <param name="LAST_UPDATE_USER"></param>
        /// <returns></returns>
        public int UpdateReceiptPlan(int SLIP_NUMBER, string LAST_UPDATE_USER)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_RECEIPT_PLAN set STATUS_FLAG={0}, ", CConstant.NORMAL);
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            SqlParameter[] parameters = {
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            parameters[0].Value = SLIP_NUMBER;
            parameters[1].Value = LAST_UPDATE_USER;
            result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return result;
        }

        #endregion

        #region 分期入库
        /// <summary>
        /// 分期入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddReceiptPlan(BllReceiptPlanTable model)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BLL_RECEIPT_PLAN(");
            strSql.Append("PURCHASE_ORDER_SLIP_NUMBER,PURCHASE_ORDER_LINE_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,COMPANY_CODE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,PRODUCT_CODE,QUANTITY,RECEIPT_PLAN_QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
            strSql.Append(" values (");
            strSql.Append("@PURCHASE_ORDER_SLIP_NUMBER,@PURCHASE_ORDER_LINE_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@COMPANY_CODE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@PRODUCT_CODE,@QUANTITY,@RECEIPT_PLAN_QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
            SqlParameter[] parameters = {
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
            parameters[0].Value = model.PURCHASE_ORDER_SLIP_NUMBER;
            parameters[1].Value = model.PURCHASE_ORDER_LINE_NUMBER;
            parameters[2].Value = model.SLIP_DATE;
            parameters[3].Value = model.SLIP_TYPE;
            parameters[4].Value = model.ORDER_SLIP_NUMBER;
            parameters[5].Value = model.SUPPLIER_ORDER_NUMBER;
            parameters[6].Value = model.SUPPLIER_CODE;
            parameters[7].Value = model.RECEIPT_WAREHOUSE_CODE;
            parameters[8].Value = model.DUE_DATE;
            parameters[9].Value = model.COMPANY_CODE;
            parameters[10].Value = model.TOTAL_AMOUNT;
            parameters[11].Value = model.TAX_RATE;
            parameters[12].Value = model.CURRENCY_CODE;
            parameters[13].Value = model.PACKING_METHOD;
            parameters[14].Value = model.PAYMENT_CONDITION;
            parameters[15].Value = model.MEMO;
            parameters[16].Value = model.PRODUCT_CODE;
            parameters[17].Value = model.QUANTITY;
            parameters[18].Value = model.RECEIPT_PLAN_QUANTITY;
            parameters[19].Value = model.UNIT_CODE;
            parameters[20].Value = model.PRICE;
            parameters[21].Value = model.AMOUNT_WITHOUT_TAX;
            parameters[22].Value = model.TAX_AMOUNT;
            parameters[23].Value = model.AMOUNT_INCLUDED_TAX;
            parameters[24].Value = model.STATUS_FLAG;
            parameters[25].Value = model.CREATE_USER;
            parameters[26].Value = model.LAST_UPDATE_USER;

            result = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return result;
        }

        #endregion

        #region 插入receipt表中
        public int AddReceipt(BllReceiptTable model)
        {
            int i = 0;
            int result = 0;
            try
            {
                List<CommandInfo> listSql = new List<CommandInfo>();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into BLL_RECEIPT(");
                strSql.Append("SLIP_NUMBER,PO_SLIP_NUMBER,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                strSql.Append(" values (");
                strSql.Append("@SLIP_NUMBER,@PO_SLIP_NUMBER,@COMPANY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@PO_SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                parameters[0].Value = model.SLIP_NUMBER;
                parameters[1].Value = model.PO_SLIP_NUMBER;
                parameters[2].Value = model.COMPANY_CODE;
                parameters[3].Value = CConstant.INIT;
                parameters[4].Value = model.CREATE_USER;
                parameters[5].Value = model.LAST_UPDATE_USER;

                listSql.Add(new CommandInfo(strSql.ToString(), parameters));

                foreach (BllReceiptLineTable lineModel in model.Items)
                {
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_RECEIPT_LINE(");
                    strSql.Append("SLIP_NUMBER,LINE_NUMBER,SLIP_DATE,INVOICE_NUMBER,RECEIPT_WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@SLIP_DATE,@INVOICE_NUMBER,@RECEIPT_WAREHOUSE_CODE,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG)");
                    SqlParameter[] lineParameters = {
					    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					    new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					    new SqlParameter("@INVOICE_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					    new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					    new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					    new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					    new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                    lineParameters[0].Value = lineModel.SLIP_NUMBER;
                    lineParameters[1].Value = lineModel.LINE_NUMBER;
                    lineParameters[2].Value = lineModel.SLIP_DATE;
                    lineParameters[3].Value = lineModel.INVOICE_NUMBER;
                    lineParameters[4].Value = lineModel.RECEIPT_WAREHOUSE_CODE;
                    lineParameters[5].Value = lineModel.PRODUCT_CODE;
                    lineParameters[6].Value = lineModel.QUANTITY;
                    lineParameters[7].Value = lineModel.UNIT_CODE;
                    lineParameters[8].Value = lineModel.PRICE;
                    lineParameters[9].Value = lineModel.AMOUNT_WITHOUT_TAX;
                    lineParameters[10].Value = lineModel.TAX_AMOUNT;
                    lineParameters[11].Value = lineModel.AMOUNT_INCLUDED_TAX;
                    lineParameters[12].Value = CConstant.INIT;

                    listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));
                }
                result = DbHelperSQL.ExecuteSqlTran(listSql);
            }
            catch (SqlException ex)
            { }
            return result;
        }
        #endregion

        #region 订单取消
        public int UpdataCancel(BllReceiptLineTable line)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = null;

            strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_RECEIPT_LINE set STATUS_FLAG = {0} ", CConstant.DELETE);
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER AND LINE_NUMBER = @LINE_NUMBER");
            SqlParameter[] UpdateReceiptParam = {
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4) };
            UpdateReceiptParam[0].Value = line.SLIP_NUMBER;
            UpdateReceiptParam[1].Value = line.LINE_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), UpdateReceiptParam));

            //receipt_plan
            strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_RECEIPT_PLAN set STATUS_FLAG={0}, ", CConstant.INIT);
            strSql.Append(" RECEIPT_PLAN_QUANTITY= @QUANTITY ");
            strSql.Append(" where SLIP_NUMBER=@RECEIPT_PLAN_NUMBER");
            SqlParameter[] UpdateReceiptPlanparam = {
                    new SqlParameter("@RECEIPT_PLAN_NUMBER", SqlDbType.Int,4),
                    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9)};
            UpdateReceiptPlanparam[0].Value = line.RECEIPT_PLAN_NUMBER;
            UpdateReceiptPlanparam[1].Value = line.QUANTITY;
            listSql.Add(new CommandInfo(strSql.ToString(), UpdateReceiptPlanparam));

            //库存更新
            strSql = new StringBuilder();
            strSql.Append("update BASE_STOCK set ");
            strSql.Append("QUANTITY=QUANTITY - @QUANTITY");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] stockParam = {
                        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9)};
            stockParam[0].Value = line.RECEIPT_WAREHOUSE_CODE;
            stockParam[1].Value = line.PRODUCT_CODE;
            stockParam[2].Value = line.QUANTITY;
            listSql.Add(new CommandInfo(strSql.ToString(), stockParam));
            return DbHelperSQL.ExecuteSqlTran(listSql);
        }
        #endregion

        #region 获得RECEIPT对象
        public BllReceiptTable GetReceiptModel(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 SLIP_NUMBER,PO_SLIP_NUMBER,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,RECEIPT_FLAG from BLL_RECEIPT ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            CZZD.ERP.Model.BllReceiptTable model = new CZZD.ERP.Model.BllReceiptTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                model.PO_SLIP_NUMBER = ds.Tables[0].Rows[0]["PO_SLIP_NUMBER"].ToString();
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
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
                if (ds.Tables[0].Rows[0]["RECEIPT_FLAG"].ToString() != "")
                {
                    model.RECEIPT_FLAG = int.Parse(ds.Tables[0].Rows[0]["RECEIPT_FLAG"].ToString());
                }

                strSql = new StringBuilder();
                strSql.Append("select  * from BLL_RECEIPT_LINE ");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] lParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20)};
                lParam[0].Value = SLIP_NUMBER;
                DataSet ds2 = DbHelperSQL.Query(strSql.ToString(), lParam);
                BllReceiptLineTable RLModel = null;
                foreach (DataRow row in ds2.Tables[0].Rows)
                {
                    RLModel = new BllReceiptLineTable();
                    RLModel.SLIP_NUMBER = CConvert.ToString(row["SLIP_NUMBER"]);
                    RLModel.LINE_NUMBER = CConvert.ToInt32(row["LINE_NUMBER"]);
                    RLModel.RECEIPT_PLAN_NUMBER = CConvert.ToInt32(row["RECEIPT_PLAN_NUMBER"]);
                    RLModel.SLIP_DATE = CConvert.ToDateTime(row["SLIP_DATE"]);
                    RLModel.INVOICE_NUMBER = CConvert.ToString(row["INVOICE_NUMBER"]);
                    RLModel.RECEIPT_WAREHOUSE_CODE = CConvert.ToString(row["RECEIPT_WAREHOUSE_CODE"]);
                    RLModel.PRODUCT_CODE = CConvert.ToString(row["PRODUCT_CODE"]);
                    RLModel.QUANTITY = CConvert.ToDecimal(row["QUANTITY"]);
                    RLModel.UNIT_CODE = CConvert.ToString(row["UNIT_CODE"]);
                    RLModel.PRODUCT_CODE = CConvert.ToString(row["PRODUCT_CODE"]);
                    RLModel.AMOUNT_WITHOUT_TAX = CConvert.ToDecimal(row["AMOUNT_WITHOUT_TAX"]);
                    RLModel.TAX_AMOUNT = CConvert.ToDecimal(row["TAX_AMOUNT"]);
                    RLModel.AMOUNT_INCLUDED_TAX = CConvert.ToDecimal(row["AMOUNT_INCLUDED_TAX"]);
                    RLModel.STATUS_FLAG = CConvert.ToInt32(row["STATUS_FLAG"]);
                    if (!string.IsNullOrEmpty(RLModel.SLIP_NUMBER))
                    {
                        model.AddItem(RLModel);
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 从PO_SLIP_NUMBER获得RECEIPT对象
        /// </summary>
        public BllReceiptTable GetRModel(string PO_SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,PO_SLIP_NUMBER,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER from BLL_RECEIPT ");
            strSql.Append(" where PO_SLIP_NUMBER=@PO_SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@PO_SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = PO_SLIP_NUMBER;

            BllReceiptTable model = new BllReceiptTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                model.PO_SLIP_NUMBER = ds.Tables[0].Rows[0]["PO_SLIP_NUMBER"].ToString();
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
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

        /// <summary>
        /// 获得RECEIPT_LINE对象
        /// </summary>
        /// <returns></returns>
        public BllReceiptLineTable GetLineModel(string SLIP_NUMBER, int LINE_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,LINE_NUMBER,RECEIPT_PLAN_NUMBER,SLIP_DATE,INVOICE_NUMBER,RECEIPT_WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG from BLL_RECEIPT_LINE ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER and LINE_NUMBER=@LINE_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4)};
            parameters[0].Value = SLIP_NUMBER;
            parameters[1].Value = LINE_NUMBER;

            CZZD.ERP.Model.BllReceiptLineTable model = new CZZD.ERP.Model.BllReceiptLineTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                if (ds.Tables[0].Rows[0]["LINE_NUMBER"].ToString() != "")
                {
                    model.LINE_NUMBER = int.Parse(ds.Tables[0].Rows[0]["LINE_NUMBER"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RECEIPT_PLAN_NUMBER"].ToString() != "")
                {
                    model.RECEIPT_PLAN_NUMBER = int.Parse(ds.Tables[0].Rows[0]["RECEIPT_PLAN_NUMBER"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SLIP_DATE"].ToString() != "")
                {
                    model.SLIP_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["SLIP_DATE"].ToString());
                }
                model.INVOICE_NUMBER = ds.Tables[0].Rows[0]["INVOICE_NUMBER"].ToString();
                model.RECEIPT_WAREHOUSE_CODE = ds.Tables[0].Rows[0]["RECEIPT_WAREHOUSE_CODE"].ToString();
                model.PRODUCT_CODE = ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["QUANTITY"].ToString() != "")
                {
                    model.QUANTITY = decimal.Parse(ds.Tables[0].Rows[0]["QUANTITY"].ToString());
                }
                model.UNIT_CODE = ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["PRICE"].ToString() != "")
                {
                    model.PRICE = decimal.Parse(ds.Tables[0].Rows[0]["PRICE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AMOUNT_WITHOUT_TAX"].ToString() != "")
                {
                    model.AMOUNT_WITHOUT_TAX = decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT_WITHOUT_TAX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TAX_AMOUNT"].ToString() != "")
                {
                    model.TAX_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["TAX_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AMOUNT_INCLUDED_TAX"].ToString() != "")
                {
                    model.AMOUNT_INCLUDED_TAX = decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT_INCLUDED_TAX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    model.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 获得最
        public string GetMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(MAX(T.SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from (");
            strSql.Append(" SELECT CASE len(SLIP_NUMBER) WHEN 0 THEN '0' WHEN 1 THEN '0' WHEN 2 THEN '0' WHEN 3 THEN '0' ELSE RIGHT(SLIP_NUMBER, 4) END AS SLIP_NUMBER ");
            strSql.Append("FROM BLL_RECEIPT ");
            strSql.Append(" WHERE (LEFT(SLIP_NUMBER, 8) = CAST(YEAR(GETDATE()) AS NVARCHAR) + CAST(RIGHT(100 + MONTH(GETDATE()), 2) AS NVARCHAR) + CAST(RIGHT(100 + DAY(GETDATE()), 2) AS NVARCHAR))) T");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }

        ///<summary>
        /// 获得返品最大ID号
        ///</summary>
        public string GetReMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(MAX(T.SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from (");
            strSql.Append(" SELECT CASE len(SLIP_NUMBER) WHEN 0 THEN '0' WHEN 1 THEN '0' WHEN 2 THEN '0' WHEN 3 THEN '0' ELSE RIGHT(SLIP_NUMBER, 4) END AS SLIP_NUMBER ");
            strSql.Append("FROM BLL_RERECEIPT ");
            strSql.Append(" WHERE (LEFT(SLIP_NUMBER, 8) = CAST(YEAR(GETDATE()) AS NVARCHAR) + CAST(RIGHT(100 + MONTH(GETDATE()), 2) AS NVARCHAR) + CAST(RIGHT(100 + DAY(GETDATE()), 2) AS NVARCHAR))) T");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }
        #endregion

        #region 入库输入
        /// <summary>
        /// 入库输入
        /// </summary>
        public int Receipt(List<BllReceiptTable> receiptList, bool IsInstallments, DateTime planDate)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                int maxSlipNumber = CConvert.ToInt32(GetMaxSlipNumber());
                try
                {
                    //List<CommandInfo> listSql = new List<CommandInfo>();
                    //StringBuilder strSql = new StringBuilder();

                    foreach (BllReceiptTable receiptTable in receiptList)
                    {
                        List<CommandInfo> listSql = new List<CommandInfo>();
                        StringBuilder strSql = new StringBuilder();
                        maxSlipNumber++;
                        receiptTable.SLIP_NUMBER = DateTime.Now.ToString("yyyyMMdd") + CConvert.ToString(maxSlipNumber).PadLeft(4, '0');
                        //receiptTable.SLIP_NUMBER = CommonManage.GetSeq(CConstant.SEQ_RECEIPT);
                        #region 入库主表处理
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_RECEIPT(");
                        strSql.Append("SLIP_NUMBER,PO_SLIP_NUMBER,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,RECEIPT_FLAG)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@PO_SLIP_NUMBER,@COMPANY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@RECEIPT_FLAG)");
                        SqlParameter[] receiptParam = {
				            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
				            new SqlParameter("@PO_SLIP_NUMBER", SqlDbType.VarChar,20),
                            new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
				            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
				            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
				            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                            new SqlParameter("@RECEIPT_FLAG", SqlDbType.Int,4)};
                        receiptParam[0].Value = receiptTable.SLIP_NUMBER;
                        receiptParam[1].Value = receiptTable.PO_SLIP_NUMBER;
                        receiptParam[2].Value = receiptTable.COMPANY_CODE;
                        receiptParam[3].Value = CConstant.INIT;
                        receiptParam[4].Value = receiptTable.CREATE_USER;
                        receiptParam[5].Value = receiptTable.LAST_UPDATE_USER;
                        receiptParam[6].Value = receiptTable.RECEIPT_FLAG;
                        listSql.Add(new CommandInfo(strSql.ToString(), receiptParam));
                        #endregion

                        //SEQ 
                        //listSql.Add(CommonManage.GetSeqUpDateSql(CConstant.SEQ_RECEIPT));

                        #region 入库明细处理
                        int lineNumber = 1;
                        foreach (BllReceiptLineTable lineModel in receiptTable.Items)
                        {
                            strSql = new StringBuilder();
                            strSql.Append("insert into BLL_RECEIPT_LINE(");
                            strSql.Append("SLIP_NUMBER,LINE_NUMBER,RECEIPT_PLAN_NUMBER,SLIP_DATE,INVOICE_NUMBER,RECEIPT_WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,SUPPLIER_CODE,CURRENCY_CODE,TAX_RATE)");
                            strSql.Append(" values (");
                            strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@RECEIPT_PLAN_NUMBER,@SLIP_DATE,@INVOICE_NUMBER,@RECEIPT_WAREHOUSE_CODE,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@SUPPLIER_CODE,@CURRENCY_CODE,@TAX_RATE)");
                            SqlParameter[] lineParameters = {
				            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
				            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
                            new SqlParameter("@RECEIPT_PLAN_NUMBER", SqlDbType.Int,4),
                            new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
				            new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
				            new SqlParameter("@INVOICE_NUMBER", SqlDbType.VarChar,20),
				            new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
				            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
				            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
				            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
				            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
				            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
				            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
				            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
				            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
				            new SqlParameter("@TAX_RATE", SqlDbType.Decimal,9)};
                            lineParameters[0].Value = receiptTable.SLIP_NUMBER;
                            lineParameters[1].Value = lineNumber++;
                            lineParameters[2].Value = lineModel.RECEIPT_PLAN_NUMBER;
                            if (receiptTable.RECEIPT_FLAG == 1)
                            {
                                lineParameters[3].Value = DateTime.Now;
                            }
                            else
                            {
                                lineParameters[3].Value = lineModel.SLIP_DATE;
                            }
                            lineParameters[4].Value = lineModel.SUPPLIER_CODE;
                            lineParameters[5].Value = lineModel.INVOICE_NUMBER;
                            lineParameters[6].Value = lineModel.RECEIPT_WAREHOUSE_CODE;
                            lineParameters[7].Value = lineModel.PRODUCT_CODE;
                            lineParameters[8].Value = lineModel.QUANTITY;
                            lineParameters[9].Value = lineModel.UNIT_CODE;
                            lineParameters[10].Value = lineModel.PRICE;
                            lineParameters[11].Value = lineModel.AMOUNT_WITHOUT_TAX;
                            lineParameters[12].Value = lineModel.TAX_AMOUNT;
                            lineParameters[13].Value = lineModel.AMOUNT_INCLUDED_TAX;
                            lineParameters[14].Value = CConstant.INIT;
                            lineParameters[15].Value = lineModel.CURRENCY_CODE;
                            lineParameters[16].Value = lineModel.TAX_RATE;
                            listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));

                            #region 库存更新
                            if (Existstock(lineModel.RECEIPT_WAREHOUSE_CODE, lineModel.PRODUCT_CODE))
                            {
                                //库存更新
                                strSql = new StringBuilder();
                                strSql.Append("update BASE_STOCK set ");
                                strSql.Append("QUANTITY=isnull(QUANTITY,0)+@QUANTITY,");
                                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                                strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");

                                SqlParameter[] uStockParam = {
                                new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                                new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                                new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                                new SqlParameter("@LAST_UPDATE_USER",  SqlDbType.VarChar,20)};
                                uStockParam[0].Value = lineModel.RECEIPT_WAREHOUSE_CODE;
                                uStockParam[1].Value = lineModel.PRODUCT_CODE;
                                uStockParam[2].Value = lineModel.QUANTITY;
                                uStockParam[3].Value = receiptTable.LAST_UPDATE_USER;
                                listSql.Add(new CommandInfo(strSql.ToString(), uStockParam));
                            }
                            else
                            {
                                strSql = new StringBuilder();
                                strSql.Append("insert into BASE_STOCK(");
                                strSql.Append("WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                                strSql.Append(" values (");
                                strSql.Append("@WAREHOUSE_CODE,@PRODUCT_CODE,@UNIT_CODE,@QUANTITY,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                                SqlParameter[] iStockParam = {
					            new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                                iStockParam[0].Value = lineModel.RECEIPT_WAREHOUSE_CODE;
                                iStockParam[1].Value = lineModel.PRODUCT_CODE;
                                iStockParam[2].Value = lineModel.UNIT_CODE;
                                iStockParam[3].Value = lineModel.QUANTITY;
                                iStockParam[4].Value = CConstant.INIT;
                                iStockParam[5].Value = receiptTable.CREATE_USER;
                                iStockParam[6].Value = receiptTable.LAST_UPDATE_USER;
                                listSql.Add(new CommandInfo(strSql.ToString(), iStockParam));
                            }
                            #endregion

                            #region 分期入库
                            BllReceiptPlanTable receiptPlanTable = GetReceiptPlanModel(lineModel.RECEIPT_PLAN_NUMBER);
                            if (IsInstallments && receiptPlanTable.RECEIPT_PLAN_QUANTITY > lineModel.QUANTITY)
                            {
                                strSql = new StringBuilder();
                                strSql.Append("insert into BLL_RECEIPT_PLAN(");
                                strSql.Append("PURCHASE_ORDER_SLIP_NUMBER,PURCHASE_ORDER_LINE_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,COMPANY_CODE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,PRODUCT_CODE,QUANTITY,RECEIPT_PLAN_QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                                strSql.Append(" values (");
                                strSql.Append("@PURCHASE_ORDER_SLIP_NUMBER,@PURCHASE_ORDER_LINE_NUMBER,@SLIP_DATE,@SLIP_TYPE,@ORDER_SLIP_NUMBER,@SUPPLIER_ORDER_NUMBER,@SUPPLIER_CODE,@RECEIPT_WAREHOUSE_CODE,@DUE_DATE,@COMPANY_CODE,@TOTAL_AMOUNT,@TAX_RATE,@CURRENCY_CODE,@PACKING_METHOD,@PAYMENT_CONDITION,@MEMO,@PRODUCT_CODE,@QUANTITY,@RECEIPT_PLAN_QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                                SqlParameter[] insertRPParam = {
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
                                insertRPParam[0].Value = receiptPlanTable.PURCHASE_ORDER_SLIP_NUMBER;
                                insertRPParam[1].Value = receiptPlanTable.PURCHASE_ORDER_LINE_NUMBER;
                                insertRPParam[2].Value = receiptPlanTable.SLIP_DATE;
                                insertRPParam[3].Value = receiptPlanTable.SLIP_TYPE;
                                insertRPParam[4].Value = receiptPlanTable.ORDER_SLIP_NUMBER;
                                insertRPParam[5].Value = receiptPlanTable.SUPPLIER_ORDER_NUMBER;
                                insertRPParam[6].Value = receiptPlanTable.SUPPLIER_CODE;
                                insertRPParam[7].Value = receiptPlanTable.RECEIPT_WAREHOUSE_CODE;
                                insertRPParam[8].Value = planDate;
                                insertRPParam[9].Value = receiptPlanTable.COMPANY_CODE;
                                insertRPParam[10].Value = receiptPlanTable.TOTAL_AMOUNT;
                                insertRPParam[11].Value = receiptPlanTable.TAX_RATE;
                                insertRPParam[12].Value = receiptPlanTable.CURRENCY_CODE;
                                insertRPParam[13].Value = receiptPlanTable.PACKING_METHOD;
                                insertRPParam[14].Value = receiptPlanTable.PAYMENT_CONDITION;
                                insertRPParam[15].Value = receiptPlanTable.MEMO;
                                insertRPParam[16].Value = receiptPlanTable.PRODUCT_CODE;
                                insertRPParam[17].Value = receiptPlanTable.QUANTITY;
                                insertRPParam[18].Value = receiptPlanTable.RECEIPT_PLAN_QUANTITY - lineModel.QUANTITY;  //序定数量－入库数量＝下次入库数量
                                insertRPParam[19].Value = receiptPlanTable.UNIT_CODE;
                                insertRPParam[20].Value = receiptPlanTable.PRICE;
                                insertRPParam[21].Value = receiptPlanTable.AMOUNT_WITHOUT_TAX;
                                insertRPParam[22].Value = receiptPlanTable.TAX_AMOUNT;
                                insertRPParam[23].Value = receiptPlanTable.AMOUNT_INCLUDED_TAX;
                                insertRPParam[24].Value = CConstant.INIT;
                                insertRPParam[25].Value = receiptPlanTable.CREATE_USER;
                                insertRPParam[26].Value = receiptPlanTable.LAST_UPDATE_USER;
                                listSql.Add(new CommandInfo(strSql.ToString(), insertRPParam));

                            }
                            #endregion

                            #region 原有入库预定数据状态的更改
                            strSql = new StringBuilder();
                            strSql.AppendFormat("update BLL_RECEIPT_PLAN set STATUS_FLAG={0}, ", CConstant.NORMAL);
                            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
                            SqlParameter[] updateRPParam = {
                                new SqlParameter("@SLIP_NUMBER", SqlDbType.Int,4),
					            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                            updateRPParam[0].Value = lineModel.RECEIPT_PLAN_NUMBER;
                            updateRPParam[1].Value = receiptTable.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), updateRPParam));
                            #endregion
                        }
                        #endregion
                        result = DbHelperSQL.ExecuteSqlTran(listSql);
                    }
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

        #region  临时入库
        public int AddOtherReceipt(BllReceiptTable OtherReceipt)
        { 
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                int maxSlipNumber = CConvert.ToInt32(GetMaxSlipNumber());
                try
                {                    
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    maxSlipNumber++;
                    OtherReceipt.SLIP_NUMBER = DateTime.Now.ToString("yyyyMMdd") + CConvert.ToString(maxSlipNumber).PadLeft(4, '0');
                    //receiptTable.SLIP_NUMBER = CommonManage.GetSeq(CConstant.SEQ_RECEIPT);

                    #region 入库主表处理
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_RECEIPT(");
                    strSql.Append("SLIP_NUMBER,PO_SLIP_NUMBER,COMPANY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,RECEIPT_FLAG)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@PO_SLIP_NUMBER,@COMPANY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@RECEIPT_FLAG)");
                    SqlParameter[] receiptParam = {
			            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
			            new SqlParameter("@PO_SLIP_NUMBER", SqlDbType.VarChar,20),
                        new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
			            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
			            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                        new SqlParameter("@RECEIPT_FLAG", SqlDbType.Int,4)};
                    receiptParam[0].Value = OtherReceipt.SLIP_NUMBER;
                    receiptParam[1].Value = OtherReceipt.PO_SLIP_NUMBER;
                    receiptParam[2].Value = OtherReceipt.COMPANY_CODE;
                    receiptParam[3].Value = CConstant.INIT;
                    receiptParam[4].Value = OtherReceipt.CREATE_USER;
                    receiptParam[5].Value = OtherReceipt.LAST_UPDATE_USER;
                    receiptParam[6].Value = OtherReceipt.RECEIPT_FLAG;
                    listSql.Add(new CommandInfo(strSql.ToString(), receiptParam));
                    #endregion

                    //SEQ 
                    //listSql.Add(CommonManage.GetSeqUpDateSql(CConstant.SEQ_RECEIPT));

                    #region 入库明细处理
                    int lineNumber = 1;
                    foreach (BllReceiptLineTable lineModel in OtherReceipt.Items)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_RECEIPT_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,RECEIPT_PLAN_NUMBER,SLIP_DATE,INVOICE_NUMBER,RECEIPT_WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,SUPPLIER_CODE,CURRENCY_CODE,TAX_RATE)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@RECEIPT_PLAN_NUMBER,@SLIP_DATE,@INVOICE_NUMBER,@RECEIPT_WAREHOUSE_CODE,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT_WITHOUT_TAX,@TAX_AMOUNT,@AMOUNT_INCLUDED_TAX,@STATUS_FLAG,@SUPPLIER_CODE,@CURRENCY_CODE,@TAX_RATE)");
                        SqlParameter[] lineParameters = {
			            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
			            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
                        new SqlParameter("@RECEIPT_PLAN_NUMBER", SqlDbType.Int,4),
                        new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
			            new SqlParameter("@SUPPLIER_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@INVOICE_NUMBER", SqlDbType.VarChar,20),
			            new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
			            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
			            new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
			            new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
			            new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
			            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                        new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@TAX_RATE", SqlDbType.Decimal,9)};
                        lineParameters[0].Value = OtherReceipt.SLIP_NUMBER;
                        lineParameters[1].Value = lineNumber++;
                        lineParameters[2].Value = lineModel.RECEIPT_PLAN_NUMBER;
                        if (OtherReceipt.RECEIPT_FLAG == 1)
                        {
                            lineParameters[3].Value = DateTime.Now;
                        }
                        else
                        {
                            lineParameters[3].Value = lineModel.SLIP_DATE;
                        }
                        lineParameters[4].Value = lineModel.SUPPLIER_CODE;
                        lineParameters[5].Value = lineModel.INVOICE_NUMBER;
                        lineParameters[6].Value = lineModel.RECEIPT_WAREHOUSE_CODE;
                        lineParameters[7].Value = lineModel.PRODUCT_CODE;
                        lineParameters[8].Value = lineModel.QUANTITY;
                        lineParameters[9].Value = lineModel.UNIT_CODE;
                        lineParameters[10].Value = lineModel.PRICE;
                        lineParameters[11].Value = lineModel.AMOUNT_WITHOUT_TAX;
                        lineParameters[12].Value = lineModel.TAX_AMOUNT;
                        lineParameters[13].Value = lineModel.AMOUNT_INCLUDED_TAX;
                        lineParameters[14].Value = CConstant.INIT;
                        lineParameters[15].Value = lineModel.CURRENCY_CODE;
                        lineParameters[16].Value = lineModel.TAX_RATE;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));

                        #region 库存更新
                        if (Existstock(lineModel.RECEIPT_WAREHOUSE_CODE, lineModel.PRODUCT_CODE))
                        {
                            //库存更新
                            strSql = new StringBuilder();
                            strSql.Append("update BASE_STOCK set ");
                            strSql.Append("QUANTITY=isnull(QUANTITY,0)+@QUANTITY,");
                            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");

                            SqlParameter[] uStockParam = {
                            new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@LAST_UPDATE_USER",  SqlDbType.VarChar,20)};
                            uStockParam[0].Value = lineModel.RECEIPT_WAREHOUSE_CODE;
                            uStockParam[1].Value = lineModel.PRODUCT_CODE;
                            uStockParam[2].Value = lineModel.QUANTITY;
                            uStockParam[3].Value = OtherReceipt.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), uStockParam));
                        }
                        else
                        {
                            strSql = new StringBuilder();
                            strSql.Append("insert into BASE_STOCK(");
                            strSql.Append("WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                            strSql.Append(" values (");
                            strSql.Append("@WAREHOUSE_CODE,@PRODUCT_CODE,@UNIT_CODE,@QUANTITY,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                            SqlParameter[] iStockParam = {
				            new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
				            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
				            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
				            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
				            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
				            new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
				            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                            iStockParam[0].Value = lineModel.RECEIPT_WAREHOUSE_CODE;
                            iStockParam[1].Value = lineModel.PRODUCT_CODE;
                            iStockParam[2].Value = lineModel.UNIT_CODE;
                            iStockParam[3].Value = lineModel.QUANTITY;
                            iStockParam[4].Value = CConstant.INIT;
                            iStockParam[5].Value = OtherReceipt.CREATE_USER;
                            iStockParam[6].Value = OtherReceipt.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), iStockParam));
                        }
                        #endregion
                    }
                    #endregion 

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

        public bool UpdateOther(CZZD.ERP.Model.BllReceiptTable model)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLL_RECEIPT set ");
            strSql.Append("PO_SLIP_NUMBER=@PO_SLIP_NUMBER,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("COMPANY_CODE=@COMPANY_CODE,");
            strSql.Append("RECEIPT_FLAG=@RECEIPT_FLAG");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@PO_SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
					new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@RECEIPT_FLAG", SqlDbType.Int,4)};
            parameters[0].Value = model.SLIP_NUMBER;
            parameters[1].Value = model.PO_SLIP_NUMBER;
            parameters[2].Value = CConstant.INIT;
            parameters[3].Value = model.LAST_UPDATE_USER;
            parameters[4].Value = model.COMPANY_CODE;
            parameters[5].Value = model.RECEIPT_FLAG;
            listSql.Add(new CommandInfo(strSql.ToString(), parameters));

            foreach (BllReceiptLineTable line in model.Items)
            {
                strSql = new StringBuilder();
                strSql.Append("update BLL_RECEIPT_LINE set ");
                strSql.Append("SLIP_DATE=@SLIP_DATE,");
                strSql.Append("INVOICE_NUMBER=@INVOICE_NUMBER,");
                strSql.Append("RECEIPT_WAREHOUSE_CODE=@RECEIPT_WAREHOUSE_CODE,");
                strSql.Append("PRODUCT_CODE=@PRODUCT_CODE,");
                strSql.Append("QUANTITY=@QUANTITY,");
                strSql.Append("UNIT_CODE=@UNIT_CODE,");
                strSql.Append("PRICE=@PRICE,");
                strSql.Append("AMOUNT_WITHOUT_TAX=@AMOUNT_WITHOUT_TAX,");
                strSql.Append("TAX_AMOUNT=@TAX_AMOUNT,");
                strSql.Append("AMOUNT_INCLUDED_TAX=@AMOUNT_INCLUDED_TAX,");
                strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                strSql.Append("RECEIPT_PLAN_NUMBER=@RECEIPT_PLAN_NUMBER,");
                strSql.Append("SUPPLIER_CODE=@SUPPLIER_CODE,");
                strSql.Append("CURRENCY_CODE=@CURRENCY_CODE,");
                strSql.Append("TAX_RATE=@TAX_RATE");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER and LINE_NUMBER=@LINE_NUMBER ");
                SqlParameter[] lineParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@INVOICE_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@PRICE", SqlDbType.Decimal,9),
					new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@RECEIPT_PLAN_NUMBER", SqlDbType.Int,4),
					new SqlParameter("@SUPPLIER_CODE", SqlDbType.NVarChar,20),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.NVarChar,20),
					new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5)};
                lineParam[0].Value = model.SLIP_NUMBER;
                lineParam[1].Value = line.LINE_NUMBER;
                lineParam[2].Value = line.SLIP_DATE;
                lineParam[3].Value = line.INVOICE_NUMBER;
                lineParam[4].Value = line.RECEIPT_WAREHOUSE_CODE;
                lineParam[5].Value = line.PRODUCT_CODE;
                lineParam[6].Value = line.QUANTITY;
                lineParam[7].Value = line.UNIT_CODE;
                lineParam[8].Value = line.PRICE;
                lineParam[9].Value = line.AMOUNT_WITHOUT_TAX;
                lineParam[10].Value = line.TAX_AMOUNT;
                lineParam[11].Value = line.AMOUNT_INCLUDED_TAX;
                lineParam[12].Value = CConstant.INIT;
                lineParam[13].Value = line.RECEIPT_PLAN_NUMBER;
                lineParam[14].Value = line.SUPPLIER_CODE;
                lineParam[15].Value = line.CURRENCY_CODE;
                lineParam[16].Value = line.TAX_RATE;
                listSql.Add(new CommandInfo(strSql.ToString(), lineParam));
            }

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

        public BllReceiptTable GetOtherModel(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,PO_SLIP_NUMBER,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,COMPANY_CODE,RECEIPT_FLAG from BLL_RECEIPT ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            CZZD.ERP.Model.BllReceiptTable model = new CZZD.ERP.Model.BllReceiptTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                model.PO_SLIP_NUMBER = ds.Tables[0].Rows[0]["PO_SLIP_NUMBER"].ToString();
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
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["RECEIPT_FLAG"].ToString() != "")
                {
                    model.RECEIPT_FLAG = int.Parse(ds.Tables[0].Rows[0]["RECEIPT_FLAG"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public DataSet GetOtherList(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_other_receipt_entry_view");
            strSql.Append(" where SLIP_NUMBER = @SLIP_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public int DeleteOtherReceipt(string slipNumber)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = null;

            BllReceiptTable receiptTable = GetReceiptModel(slipNumber);

            strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_RECEIPT set STATUS_FLAG = {0} ", CConstant.DELETE);
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            SqlParameter[] uRParam = {
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4) };
            uRParam[0].Value = receiptTable.SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), uRParam));

            foreach (BllReceiptLineTable receiptLineTable in receiptTable.Items)
            {
                //库存更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_STOCK set ");
                strSql.Append("QUANTITY=QUANTITY - @QUANTITY");
                strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
                SqlParameter[] stockParam = {
                        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9)};
                stockParam[0].Value = receiptLineTable.RECEIPT_WAREHOUSE_CODE;
                stockParam[1].Value = receiptLineTable.PRODUCT_CODE;
                stockParam[2].Value = receiptLineTable.QUANTITY;
                listSql.Add(new CommandInfo(strSql.ToString(), stockParam));
            }

            return DbHelperSQL.ExecuteSqlTran(listSql);
        }

        #endregion 

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Existstock(string WAREHOUSE_CODE, string PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BASE_STOCK");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            SqlParameter[] parameters = {
					new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,50),
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = WAREHOUSE_CODE;
            parameters[1].Value = PRODUCT_CODE;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exsitreceipt(string PO_SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BLL_RECEIPT");
            strSql.Append(" where PO_SLIP_NUMBER = @PO_SLIP_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@PO_SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = PO_SLIP_NUMBER;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        #region 获得入库序定对象
        /// <summary>
        /// 获得BllReceiptPlanTable对象
        /// </summary>
        public BllReceiptPlanTable GetReceiptPlanModel(int slipNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,PURCHASE_ORDER_SLIP_NUMBER,PURCHASE_ORDER_LINE_NUMBER,SLIP_DATE,SLIP_TYPE,ORDER_SLIP_NUMBER,SUPPLIER_ORDER_NUMBER,SUPPLIER_CODE,RECEIPT_WAREHOUSE_CODE,DUE_DATE,COMPANY_CODE,TOTAL_AMOUNT,TAX_RATE,CURRENCY_CODE,PACKING_METHOD,PAYMENT_CONDITION,MEMO,PRODUCT_CODE,QUANTITY,RECEIPT_PLAN_QUANTITY,UNIT_CODE,PRICE,AMOUNT_WITHOUT_TAX,TAX_AMOUNT,AMOUNT_INCLUDED_TAX,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER from BLL_RECEIPT_PLAN ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.Int,4)};
            parameters[0].Value = slipNumber;

            CZZD.ERP.Model.BllReceiptPlanTable model = new CZZD.ERP.Model.BllReceiptPlanTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString() != "")
                {
                    model.SLIP_NUMBER = int.Parse(ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString());
                }
                model.PURCHASE_ORDER_SLIP_NUMBER = ds.Tables[0].Rows[0]["PURCHASE_ORDER_SLIP_NUMBER"].ToString();
                if (ds.Tables[0].Rows[0]["PURCHASE_ORDER_LINE_NUMBER"].ToString() != "")
                {
                    model.PURCHASE_ORDER_LINE_NUMBER = int.Parse(ds.Tables[0].Rows[0]["PURCHASE_ORDER_LINE_NUMBER"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SLIP_DATE"].ToString() != "")
                {
                    model.SLIP_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["SLIP_DATE"].ToString());
                }
                model.SLIP_TYPE = ds.Tables[0].Rows[0]["SLIP_TYPE"].ToString();
                model.ORDER_SLIP_NUMBER = ds.Tables[0].Rows[0]["ORDER_SLIP_NUMBER"].ToString();
                model.SUPPLIER_ORDER_NUMBER = ds.Tables[0].Rows[0]["SUPPLIER_ORDER_NUMBER"].ToString();
                model.SUPPLIER_CODE = ds.Tables[0].Rows[0]["SUPPLIER_CODE"].ToString();
                model.RECEIPT_WAREHOUSE_CODE = ds.Tables[0].Rows[0]["RECEIPT_WAREHOUSE_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["DUE_DATE"].ToString() != "")
                {
                    model.DUE_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["DUE_DATE"].ToString());
                }
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString() != "")
                {
                    model.TOTAL_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TAX_RATE"].ToString() != "")
                {
                    model.TAX_RATE = decimal.Parse(ds.Tables[0].Rows[0]["TAX_RATE"].ToString());
                }
                model.CURRENCY_CODE = ds.Tables[0].Rows[0]["CURRENCY_CODE"].ToString();
                model.PACKING_METHOD = ds.Tables[0].Rows[0]["PACKING_METHOD"].ToString();
                model.PAYMENT_CONDITION = ds.Tables[0].Rows[0]["PAYMENT_CONDITION"].ToString();
                model.MEMO = ds.Tables[0].Rows[0]["MEMO"].ToString();
                model.PRODUCT_CODE = ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["QUANTITY"].ToString() != "")
                {
                    model.QUANTITY = decimal.Parse(ds.Tables[0].Rows[0]["QUANTITY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RECEIPT_PLAN_QUANTITY"].ToString() != "")
                {
                    model.RECEIPT_PLAN_QUANTITY = decimal.Parse(ds.Tables[0].Rows[0]["RECEIPT_PLAN_QUANTITY"].ToString());
                }
                model.UNIT_CODE = ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["PRICE"].ToString() != "")
                {
                    model.PRICE = decimal.Parse(ds.Tables[0].Rows[0]["PRICE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AMOUNT_WITHOUT_TAX"].ToString() != "")
                {
                    model.AMOUNT_WITHOUT_TAX = decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT_WITHOUT_TAX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TAX_AMOUNT"].ToString() != "")
                {
                    model.TAX_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["TAX_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AMOUNT_INCLUDED_TAX"].ToString() != "")
                {
                    model.AMOUNT_INCLUDED_TAX = decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT_INCLUDED_TAX"].ToString());
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

        #region 入库输入
        /// <summary>
        /// 获得入库输入分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_receiving_plan_view");
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

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_receiving_plan_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion 

        #region 入库查询
        /// <summary>
        /// 获得入库输入分页数据列表
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
            strSql.Append(")AS Row, T.* from bll_receiving_plan_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得入库查询分页数据总的记录条数
        /// </summary>
        public int GetSearchRecordCount(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_receipt_search_view");
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
        /// 获得入库查询分页数据列表
        /// </summary>
        public DataSet GetSearchList(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.* from bll_receipt_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SLIP_NUMBER,PO_SLIP_NUMBER,COMPANY_NAME,STATUS_FLAG,LINE_NUMBER,CONVERT(varchar(12) , RECEIPT_SLIP_DATE, 111 ) AS SLIP_DATE,INVOICE_NUMBER,RECEIPT_WAREHOUSE_CODE,WAREHOUSE_NAME, ");
            strSql.Append("SUPPLIER_CODE,SUPPLIER_NAME,PRODUCT_NAME,PURCHASE_QUANTITY,QUANTITY,UNIT_NAME,PRICE,TAX_RATE,CURRENCY_NAME,AMOUNT_INCLUDED_TAX,AMOUNT_WITHOUT_TAX,");
            strSql.Append("TAX_AMOUNT,CREATE_NAME,CONVERT(varchar(12) , CREATE_DATE_TIME, 111 ) AS CREATE_DATE_TIME, LAST_UPDATE_NAME, CONVERT(varchar(12), LAST_UPDATE_TIME, 111 ) AS LAST_UPDATE_TIME FROM bll_receipt_search_view ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region IReceipt 成员

        /// <summary>
        /// 入库取消
        /// </summary>
        public int UnReceipt(string slipNumber)
        {
            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = null;

            BllReceiptTable receiptTable = GetReceiptModel(slipNumber);

            strSql = new StringBuilder();
            strSql.AppendFormat("update BLL_RECEIPT set STATUS_FLAG = {0} ", CConstant.DELETE);
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER");
            SqlParameter[] uRParam = {
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4) };
            uRParam[0].Value = receiptTable.SLIP_NUMBER;
            listSql.Add(new CommandInfo(strSql.ToString(), uRParam));

            foreach (BllReceiptLineTable receiptLineTable in receiptTable.Items)
            {
                //入库预定表的更新
                strSql = new StringBuilder();
                strSql.AppendFormat("update BLL_RECEIPT_PLAN set STATUS_FLAG={0}, ", CConstant.INIT);
                strSql.Append(" RECEIPT_PLAN_QUANTITY= @QUANTITY ");
                strSql.Append(" where SLIP_NUMBER=@RECEIPT_PLAN_NUMBER");
                SqlParameter[] UpdateReceiptPlanparam = {
                    new SqlParameter("@RECEIPT_PLAN_NUMBER", SqlDbType.Int,4),
                    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9)};
                UpdateReceiptPlanparam[0].Value = receiptLineTable.RECEIPT_PLAN_NUMBER;
                UpdateReceiptPlanparam[1].Value = receiptLineTable.QUANTITY;
                listSql.Add(new CommandInfo(strSql.ToString(), UpdateReceiptPlanparam));

                //库存更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_STOCK set ");
                strSql.Append("QUANTITY=QUANTITY - @QUANTITY");
                strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
                SqlParameter[] stockParam = {
                        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9)};
                stockParam[0].Value = receiptLineTable.RECEIPT_WAREHOUSE_CODE;
                stockParam[1].Value = receiptLineTable.PRODUCT_CODE;
                stockParam[2].Value = receiptLineTable.QUANTITY;
                listSql.Add(new CommandInfo(strSql.ToString(), stockParam));
            }

            return DbHelperSQL.ExecuteSqlTran(listSql);
        }

        #endregion

        #region IReceipt 成员


        public int GetMaxLineNumber()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 返品入库
        public bool ExsitProdcuct(string PurchaseOrder, string product)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BLL_PURCHASE_ORDER_LINE");
            strSql.Append(" where SLIP_NUMBER = @SLIP_NUMBER AND PRODUCT_CODE = @PRODUCT_CODE");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE",SqlDbType.VarChar,20)};
            parameters[0].Value = PurchaseOrder;
            parameters[1].Value = product;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public int AddReReceipt(BllReReceiptTable rereceipt)
        {
            int i = 0;
            int result = 0;            
            while (i < 10)
            {
                int maxSlipNumber = CConvert.ToInt32(GetReMaxSlipNumber());
                try
                {                    
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = new StringBuilder();
                    maxSlipNumber++;
                    rereceipt.SLIP_NUMBER = DateTime.Now.ToString("yyyyMMdd") + CConvert.ToString(maxSlipNumber).PadLeft(4, '0');

                    #region 入库主表处理
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_RERECEIPT(");
                    strSql.Append("SLIP_NUMBER,PO_SLIP_NUMBER,SLIP_DATE,RECEIPT_WAREHOUSE_CODE,CURRENCY_CODE,SUPPLIER_CODE,TAX_RATE,TAX_AMOUNT,AMOUNT_WITHOUT_TAX,AMOUNT_INCLUDED_TAX,COMPANY_CODE,RERECEIPT_FLAG,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@PO_SLIP_NUMBER,@SLIP_DATE,@RECEIPT_WAREHOUSE_CODE,@CURRENCY_CODE,@SUPPLIER_CODE,@TAX_RATE,@TAX_AMOUNT,@AMOUNT_WITHOUT_TAX,@AMOUNT_INCLUDED_TAX,@COMPANY_CODE,@RERECEIPT_FLAG,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                    SqlParameter[] receiptParam = {
			            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
				        new SqlParameter("@PO_SLIP_NUMBER", SqlDbType.VarChar,20),
				        new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
				        new SqlParameter("@RECEIPT_WAREHOUSE_CODE", SqlDbType.VarChar,20),
				        new SqlParameter("@CURRENCY_CODE", SqlDbType.NVarChar,20),
				        new SqlParameter("@SUPPLIER_CODE", SqlDbType.NVarChar,20),
				        new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
				        new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
				        new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
				        new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
				        new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@RERECEIPT_FLAG", SqlDbType.Int,4),
				        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
				        new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
				        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                    receiptParam[0].Value = rereceipt.SLIP_NUMBER;
                    receiptParam[1].Value = rereceipt.PO_SLIP_NUMBER;
                    receiptParam[2].Value = rereceipt.SLIP_DATE;
                    receiptParam[3].Value = rereceipt.RECEIPT_WAREHOUSE_CODE;
                    receiptParam[4].Value = rereceipt.CURRENCY_CODE;
                    receiptParam[5].Value = rereceipt.SUPPLIER_CODE;
                    receiptParam[6].Value = rereceipt.TAX_RATE;
                    receiptParam[7].Value = rereceipt.TAX_AMOUNT;
                    receiptParam[8].Value = rereceipt.AMOUNT_WITHOUT_TAX;
                    receiptParam[9].Value = rereceipt.AMOUNT_INCLUDED_TAX;
                    receiptParam[10].Value = rereceipt.COMPANY_CODE;
                    receiptParam[11].Value = rereceipt.RERECEIPT_FLAG;
                    receiptParam[12].Value = rereceipt.STATUS_FLAG;
                    receiptParam[13].Value = rereceipt.CREATE_USER;
                    receiptParam[14].Value = rereceipt.LAST_UPDATE_USER;
                    listSql.Add(new CommandInfo(strSql.ToString(), receiptParam));
                    #endregion

                    //SEQ 
                    listSql.Add(CommonManage.GetSeqUpDateSql(CConstant.SEQ_RECEIPT_RETURN));

                    #region 入库明细处理
                    int lineNumber = 1;
                    foreach (BllReReceiptLineTable lineModel in rereceipt.Items)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_RERECEIPT_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,MEMO,STATUS_FLAG)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@MEMO,@STATUS_FLAG)");
                        SqlParameter[] lineParameters = {
			            new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
			            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
			            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
			            new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
			            new SqlParameter("@PRICE", SqlDbType.Decimal,9),
		                new SqlParameter("@MEMO", SqlDbType.VarChar,250),
			            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                        lineParameters[0].Value = rereceipt.SLIP_NUMBER;
                        lineParameters[1].Value = lineNumber++;
                        lineParameters[2].Value = lineModel.PRODUCT_CODE;
                        lineParameters[3].Value = lineModel.QUANTITY;
                        lineParameters[4].Value = lineModel.UNIT_CODE;
                        lineParameters[5].Value = lineModel.PRICE;
                        lineParameters[6].Value = lineModel.MEMO;
                        lineParameters[7].Value = CConstant.INIT;
                        listSql.Add(new CommandInfo(strSql.ToString(), lineParameters));

                        #region 库存更新                            
                        //库存更新
                        strSql = new StringBuilder();
                        strSql.Append("update BASE_STOCK set ");
                        strSql.Append("QUANTITY=isnull(QUANTITY,0)-@QUANTITY,");
                        strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                        strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                        strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");

                        SqlParameter[] uStockParam = {
                        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                        new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                        new SqlParameter("@LAST_UPDATE_USER",  SqlDbType.VarChar,20)};
                        uStockParam[0].Value = rereceipt.RECEIPT_WAREHOUSE_CODE;
                        uStockParam[1].Value = lineModel.PRODUCT_CODE;
                        uStockParam[2].Value = lineModel.QUANTITY;
                        uStockParam[3].Value = rereceipt.LAST_UPDATE_USER;
                        listSql.Add(new CommandInfo(strSql.ToString(), uStockParam));                            
                        #endregion
                    }
                    #endregion


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

        /// <summary>
        /// 根据采购订单编号与商品编号获得采购数量
        /// </summary>
        public decimal GetPurchaseQuantity(string slipnumber, string product)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 1 QUANTITY FROM BLL_PURCHASE_ORDER_LINE ");
            strSql.Append("where SLIP_NUMBER=@SLIP_NUMBER and  PRODUCT_CODE=@PRODUCT_CODE ");
            strSql.AppendFormat(" and STATUS_FLAG <> {0} ", CConstant.DELETE);
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
                    new SqlParameter("@PRODUCT_CODE",SqlDbType.VarChar,20)};
            parameters[0].Value = slipnumber;
            parameters[1].Value = product;
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

        #region 返品查询
        public DataSet GetReList(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.* from bll_storage_division_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetReSearchCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_storage_division_search_view");
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

        public BllReReceiptTable GetReModel(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,PO_SLIP_NUMBER,SLIP_DATE,RECEIPT_WAREHOUSE_CODE,CURRENCY_CODE,SUPPLIER_CODE,TAX_RATE,TAX_AMOUNT,AMOUNT_WITHOUT_TAX,AMOUNT_INCLUDED_TAX,COMPANY_CODE,RERECEIPT_FLAG,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER from BLL_RERECEIPT ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            CZZD.ERP.Model.BllReReceiptTable model = new CZZD.ERP.Model.BllReReceiptTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                model.PO_SLIP_NUMBER = ds.Tables[0].Rows[0]["PO_SLIP_NUMBER"].ToString();
                if (ds.Tables[0].Rows[0]["SLIP_DATE"].ToString() != "")
                {
                    model.SLIP_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["SLIP_DATE"].ToString());
                }
                model.RECEIPT_WAREHOUSE_CODE = ds.Tables[0].Rows[0]["RECEIPT_WAREHOUSE_CODE"].ToString();
                model.CURRENCY_CODE = ds.Tables[0].Rows[0]["CURRENCY_CODE"].ToString();
                model.SUPPLIER_CODE = ds.Tables[0].Rows[0]["SUPPLIER_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["TAX_RATE"].ToString() != "")
                {
                    model.TAX_RATE = decimal.Parse(ds.Tables[0].Rows[0]["TAX_RATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TAX_AMOUNT"].ToString() != "")
                {
                    model.TAX_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["TAX_AMOUNT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AMOUNT_WITHOUT_TAX"].ToString() != "")
                {
                    model.AMOUNT_WITHOUT_TAX = decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT_WITHOUT_TAX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AMOUNT_INCLUDED_TAX"].ToString() != "")
                {
                    model.AMOUNT_INCLUDED_TAX = decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT_INCLUDED_TAX"].ToString());
                }
                model.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["RERECEIPT_FLAG"].ToString() != "")
                {
                    model.RERECEIPT_FLAG = int.Parse(ds.Tables[0].Rows[0]["RERECEIPT_FLAG"].ToString());
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

                strSql = new StringBuilder();
                strSql.Append("SELECT * FROM BLL_RERECEIPT_LINE");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] lineParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                lineParam[0].Value = SLIP_NUMBER;
                ds = DbHelperSQL.Query(strSql.ToString(), lineParam);
                BllReReceiptLineTable RRLModel = null;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    RRLModel = new BllReReceiptLineTable();
                    RRLModel.SLIP_NUMBER = CConvert.ToString(row["SLIP_NUMBER"]);
                    RRLModel.LINE_NUMBER = CConvert.ToInt32(row["LINE_NUMBER"]);
                    RRLModel.PRODUCT_CODE = CConvert.ToString(row["PRODUCT_CODE"]);
                    RRLModel.QUANTITY = CConvert.ToDecimal(row["QUANTITY"]);
                    RRLModel.UNIT_CODE = CConvert.ToString(row["UNIT_CODE"]);
                    RRLModel.PRICE = CConvert.ToDecimal(row["PRICE"]);
                    RRLModel.MEMO = CConvert.ToString(row["MEMO"]);
                    RRLModel.STATUS_FLAG = CConvert.ToInt32(row["STATUS_FLAG"]);

                    if (RRLModel.SLIP_NUMBER != null)
                    {
                        model.AddItem(RRLModel);
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
