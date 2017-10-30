using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Common;
using CZZD.ERP.DBUtility;
using CZZD.ERP.Model;
using System.Data.SqlClient;

namespace CZZD.ERP.SQLServerDAL
{
    public class ShipmentManage : IShipment
    {
        #region IShipment 成员

        /// <summary>
        /// 未出库数据的获得
        /// </summary>
        public DataSet GetShipmentPlanList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM bll_shipment_view ");
            if (strWhere != "")
            {
                strSql.AppendFormat(" where {0}", strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(List<BllShipmentTable> datas)
        {
            List<CommandInfo> listSql = null;
            StringBuilder strSql = null;
            int maxSlipNumber = CConvert.ToInt32(GetShipmentMaxSlipNumber());
            int result = 0;
            foreach (BllShipmentTable shipmentTable in datas)
            {
                listSql = new List<CommandInfo>();
                strSql = new StringBuilder();
                shipmentTable.SLIP_NUMBER = DateTime.Now.ToString("yyyyMMdd") + CConvert.ToString(++maxSlipNumber);
                //shipmentTable.SLIP_NUMBER = CommonManage.GetSeq(CConstant.SEQ_SHIPMENT);

                strSql.Append("insert into BLL_SHIPMENT(");
                strSql.Append("SLIP_NUMBER,ORDER_SLIP_NUMBER,SERIAL_NUMBER,SLIP_DATE,ARRIVAL_DATE,AMOUNT,CURRENCY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,AMOUNT_INCLUDED_TAX,AMOUNT_WITHOUT_TAX,TAX_RATE,TAX_AMOUNT,COMPANY_CODE)");
                strSql.Append(" values (");
                strSql.Append("@SLIP_NUMBER,@ORDER_SLIP_NUMBER,@SERIAL_NUMBER,@SLIP_DATE,@ARRIVAL_DATE,@AMOUNT,@CURRENCY_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER,@AMOUNT_INCLUDED_TAX,@AMOUNT_WITHOUT_TAX,@TAX_RATE,@TAX_AMOUNT,@COMPANY_CODE)");
                SqlParameter[] shipmentParam = {
					    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@SERIAL_NUMBER", SqlDbType.VarChar,50),
					    new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					    new SqlParameter("@ARRIVAL_DATE", SqlDbType.DateTime),
					    new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),
					    new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					    new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					    new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					    new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9),
                        new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20)};
                shipmentParam[0].Value = shipmentTable.SLIP_NUMBER;
                shipmentParam[1].Value = shipmentTable.ORDER_SLIP_NUMBER;
                shipmentParam[2].Value = shipmentTable.SERIAL_NUMBER;
                shipmentParam[3].Value = shipmentTable.SLIP_DATE;
                shipmentParam[4].Value = shipmentTable.ARRIVAL_DATE;
                shipmentParam[5].Value = shipmentTable.AMOUNT;
                shipmentParam[6].Value = shipmentTable.CURRENCY_CODE;
                shipmentParam[7].Value = shipmentTable.STATUS_FLAG;
                shipmentParam[8].Value = shipmentTable.CREATE_USER;
                shipmentParam[9].Value = shipmentTable.LAST_UPDATE_USER;
                shipmentParam[10].Value = shipmentTable.AMOUNT_INCLUDED_TAX;
                shipmentParam[11].Value = shipmentTable.AMOUNT_WITHOUT_TAX;
                shipmentParam[12].Value = shipmentTable.TAX_RATE;
                shipmentParam[13].Value = shipmentTable.TAX_AMOUNT;
                shipmentParam[14].Value = shipmentTable.COMPANY_CODE;
                listSql.Add(new CommandInfo(strSql.ToString(), shipmentParam));

                //strSql = new StringBuilder();
                //strSql.Append("update Sys_Seq set ");
                //strSql.Append("SEQ= SEQ + 1 ");
                //strSql.Append("WHERE BLL_TYPE = @BLL_TYPE");
                //SqlParameter[] SeqParam = { 
                //                new SqlParameter("@BLL_TYPE", SqlDbType.VarChar,10) };
                //SeqParam[0].Value = CConstant.SEQ_SHIPMENT;
                //listSql.Add(new CommandInfo(strSql.ToString(), SeqParam));

                foreach (BllShipmentLineTable shipmentLineTable in shipmentTable.Items)
                {
                    //明细的保存
                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_SHIPMENT_LINE(");
                    strSql.Append("SLIP_NUMBER,LINE_NUMBER,DEPARTUAL_WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,UNIT_CODE,PRICE,AMOUNT,MEMO,STATUS_FLAG,ORDER_LINE_NUMBER)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@DEPARTUAL_WAREHOUSE_CODE,@PRODUCT_CODE,@QUANTITY,@UNIT_CODE,@PRICE,@AMOUNT,@MEMO,@STATUS_FLAG,@ORDER_LINE_NUMBER)");
                    SqlParameter[] shipmentLineParam = {
                    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
                    new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
                    new SqlParameter("@DEPARTUAL_WAREHOUSE_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                    new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
                    new SqlParameter("@PRICE", SqlDbType.Decimal,9),
                    new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),
                    new SqlParameter("@MEMO", SqlDbType.NVarChar,255),
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@ORDER_LINE_NUMBER", SqlDbType.Int,4)};
                    shipmentLineParam[0].Value = shipmentTable.SLIP_NUMBER;
                    shipmentLineParam[1].Value = shipmentLineTable.LINE_NUMBER;
                    shipmentLineParam[2].Value = shipmentLineTable.DEPARTUAL_WAREHOUSE_CODE;
                    shipmentLineParam[3].Value = shipmentLineTable.PRODUCT_CODE;
                    shipmentLineParam[4].Value = shipmentLineTable.QUANTITY;
                    shipmentLineParam[5].Value = shipmentLineTable.UNIT_CODE;
                    shipmentLineParam[6].Value = shipmentLineTable.PRICE;
                    shipmentLineParam[7].Value = shipmentLineTable.AMOUNT;
                    shipmentLineParam[8].Value = shipmentLineTable.MEMO;
                    shipmentLineParam[9].Value = shipmentLineTable.STATUS_FLAG;
                    shipmentLineParam[10].Value = shipmentLineTable.ORDER_LINE_NUMBER;
                    listSql.Add(new CommandInfo(strSql.ToString(), shipmentLineParam));

                    //库存更新
                    strSql = new StringBuilder();
                    strSql.Append("update BASE_STOCK set ");
                    strSql.Append("QUANTITY=isnull(QUANTITY,0)-@QUANTITY,");
                    strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                    strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                    strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");

                    SqlParameter[] stockParam = {
                            new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@LAST_UPDATE_USER",  SqlDbType.VarChar,20)};
                    stockParam[0].Value = shipmentLineTable.DEPARTUAL_WAREHOUSE_CODE;
                    stockParam[1].Value = shipmentLineTable.PRODUCT_CODE;
                    stockParam[2].Value = shipmentLineTable.QUANTITY;
                    stockParam[3].Value = shipmentTable.LAST_UPDATE_USER;
                    listSql.Add(new CommandInfo(strSql.ToString(), stockParam));

                    //引当状态的结束
                    strSql = new StringBuilder();
                    strSql.Append("update BLL_ALLOATION set ");
                    strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
                    strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                    strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                    strSql.Append(" where ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER and ORDER_LINE_NUMBER=@ORDER_LINE_NUMBER ");
                    strSql.AppendFormat("and STATUS_FLAG <>{0} AND STATUS_FLAG <> {1}", CConstant.DELETE, CConstant.ALLOATION_SHIPMENT);

                    SqlParameter[] alloationParam = {					        
                            new SqlParameter("@ORDER_SLIP_NUMBER",  SqlDbType.VarChar,20),
                            new SqlParameter("@ORDER_LINE_NUMBER", SqlDbType.Int,4),
                            new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                            new SqlParameter("@LAST_UPDATE_USER",  SqlDbType.VarChar,20)};
                    alloationParam[0].Value = shipmentTable.ORDER_SLIP_NUMBER;
                    alloationParam[1].Value = shipmentLineTable.ORDER_LINE_NUMBER;
                    alloationParam[2].Value = CConstant.ALLOATION_SHIPMENT;
                    alloationParam[3].Value = shipmentTable.LAST_UPDATE_USER;
                    listSql.Add(new CommandInfo(strSql.ToString(), alloationParam));

                    //出库数量的回写
                    strSql = new StringBuilder();
                    strSql.Append("update BLL_ORDER_LINE set ");
                    strSql.Append("SHIPMENT_QUANTITY= isnull(SHIPMENT_QUANTITY,0) + @SHIPMENT_QUANTITY");
                    strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER and LINE_NUMBER=@LINE_NUMBER ");
                    strSql.AppendFormat("and STATUS_FLAG <>{0}", CConstant.DELETE);

                    SqlParameter[] orderLineParam = {					        
                            new SqlParameter("@SLIP_NUMBER",  SqlDbType.VarChar,20),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
                            new SqlParameter("@SHIPMENT_QUANTITY", SqlDbType.Decimal,9)};
                    orderLineParam[0].Value = shipmentTable.ORDER_SLIP_NUMBER;
                    orderLineParam[1].Value = shipmentLineTable.ORDER_LINE_NUMBER;
                    orderLineParam[2].Value = shipmentLineTable.QUANTITY;
                    listSql.Add(new CommandInfo(strSql.ToString(), orderLineParam));

                    //将修改的数据回写到BLL_ORDER_HEADER
                    strSql = new StringBuilder();
                    strSql.Append("update BLL_ORDER_HEADER set ");
                    strSql.Append("SERIAL_NUMBER=@SERIAL_NUMBER,CHECK_NUMBER=@CHECK_NUMBER,CUSTOMER_PO_NUMBER=@CUSTOMER_PO_NUMBER ");
                    strSql.Append("where SLIP_NUMBER=@SLIP_NUMBER");

                    SqlParameter[] orderHeader ={
                            new SqlParameter("@SLIP_NUMBER",SqlDbType.VarChar,20),
                            new SqlParameter("@SERIAL_NUMBER",SqlDbType.VarChar,50),
                            new SqlParameter("@CHECK_NUMBER",SqlDbType.VarChar,20),
                            new SqlParameter("@CUSTOMER_PO_NUMBER",SqlDbType.VarChar,50)
                                               };
                    orderHeader[0].Value = shipmentTable.ORDER_SLIP_NUMBER;
                    orderHeader[1].Value = shipmentTable.SERIAL_NUMBER;
                    orderHeader[2].Value = shipmentTable.CHECK_NUMBER;
                    orderHeader[3].Value = shipmentTable.CUSTOMER_PO_NUMBER;
                    listSql.Add(new CommandInfo(strSql.ToString(), orderHeader));
                }
                result = DbHelperSQL.ExecuteSqlTran(listSql);
            }
            return result;
        }

        /// <summary>
        /// 最大出库编号取得
        /// </summary>
        /// <returns></returns>
        private string GetShipmentMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(MAX(T.SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from (");
            strSql.Append(" SELECT CASE len(SLIP_NUMBER) WHEN 0 THEN '0' WHEN 1 THEN '0' WHEN 2 THEN '0' WHEN 3 THEN '0' ELSE RIGHT(SLIP_NUMBER, 4) END AS SLIP_NUMBER ");
            strSql.Append("FROM BLL_SHIPMENT ");
            strSql.Append(" WHERE (LEFT(SLIP_NUMBER, 8) = CAST(YEAR(GETDATE()) AS NVARCHAR) + CAST(RIGHT(100 + MONTH(GETDATE()), 2) AS NVARCHAR) + CAST(RIGHT(100 + DAY(GETDATE()), 2) AS NVARCHAR))) T");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BllShipmentTable shipmentTable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLL_SHIPMENT set ");
            strSql.Append("ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER,");
            strSql.Append("SERIAL_NUMBER=@SERIAL_NUMBER,");
            strSql.Append("SLIP_DATE=@SLIP_DATE,");
            strSql.Append("ARRIVAL_DATE=@ARRIVAL_DATE,");
            strSql.Append("AMOUNT=@AMOUNT,");
            strSql.Append("CURRENCY_CODE=@CURRENCY_CODE,");
            strSql.Append("STATUS_FLAG=@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER,");
            strSql.Append("AMOUNT_INCLUDED_TAX=@AMOUNT_INCLUDED_TAX,");
            strSql.Append("AMOUNT_WITHOUT_TAX=@AMOUNT_WITHOUT_TAX,");
            strSql.Append("TAX_RATE=@TAX_RATE,");
            strSql.Append("TAX_AMOUNT=@TAX_AMOUNT");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20),
					new SqlParameter("@SERIAL_NUMBER", SqlDbType.VarChar,50),
					new SqlParameter("@SLIP_DATE", SqlDbType.DateTime),
					new SqlParameter("@ARRIVAL_DATE", SqlDbType.DateTime),
					new SqlParameter("@AMOUNT", SqlDbType.Decimal,9),
					new SqlParameter("@CURRENCY_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20),
                    new SqlParameter("@AMOUNT_INCLUDED_TAX", SqlDbType.Decimal,9),
					new SqlParameter("@AMOUNT_WITHOUT_TAX", SqlDbType.Decimal,9),
					new SqlParameter("@TAX_RATE", SqlDbType.Decimal,5),
					new SqlParameter("@TAX_AMOUNT", SqlDbType.Decimal,9)};
            parameters[0].Value = shipmentTable.SLIP_NUMBER;
            parameters[1].Value = shipmentTable.ORDER_SLIP_NUMBER;
            parameters[2].Value = shipmentTable.SERIAL_NUMBER;
            parameters[3].Value = shipmentTable.SLIP_DATE;
            parameters[4].Value = shipmentTable.ARRIVAL_DATE;
            parameters[5].Value = shipmentTable.AMOUNT;
            parameters[6].Value = shipmentTable.CURRENCY_CODE;
            parameters[7].Value = shipmentTable.STATUS_FLAG;
            parameters[8].Value = shipmentTable.LAST_UPDATE_USER;
            parameters[9].Value = shipmentTable.AMOUNT_INCLUDED_TAX;
            parameters[10].Value = shipmentTable.AMOUNT_WITHOUT_TAX;
            parameters[11].Value = shipmentTable.TAX_RATE;
            parameters[12].Value = shipmentTable.TAX_AMOUNT;

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
        public BllShipmentTable GetModel(string slipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,ORDER_SLIP_NUMBER,SERIAL_NUMBER,SLIP_DATE,ARRIVAL_DATE,AMOUNT,CURRENCY_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER,AMOUNT_INCLUDED_TAX,AMOUNT_WITHOUT_TAX,TAX_RATE,TAX_AMOUNT,COMPANY_CODE ");
            strSql.Append(" from BLL_SHIPMENT ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = slipNumber;

            BllShipmentTable shipModel = new BllShipmentTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                shipModel.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                shipModel.ORDER_SLIP_NUMBER = ds.Tables[0].Rows[0]["ORDER_SLIP_NUMBER"].ToString();
                shipModel.SERIAL_NUMBER = ds.Tables[0].Rows[0]["SERIAL_NUMBER"].ToString();
                if (ds.Tables[0].Rows[0]["SLIP_DATE"].ToString() != "")
                {
                    shipModel.SLIP_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["SLIP_DATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ARRIVAL_DATE"].ToString() != "")
                {
                    shipModel.ARRIVAL_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["ARRIVAL_DATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AMOUNT"].ToString() != "")
                {
                    shipModel.AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT"].ToString());
                }
                shipModel.CURRENCY_CODE = ds.Tables[0].Rows[0]["CURRENCY_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    shipModel.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                shipModel.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    shipModel.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    shipModel.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                shipModel.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["AMOUNT_INCLUDED_TAX"].ToString() != "")
                {
                    shipModel.AMOUNT_INCLUDED_TAX = decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT_INCLUDED_TAX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AMOUNT_WITHOUT_TAX"].ToString() != "")
                {
                    shipModel.AMOUNT_WITHOUT_TAX = decimal.Parse(ds.Tables[0].Rows[0]["AMOUNT_WITHOUT_TAX"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TAX_RATE"].ToString() != "")
                {
                    shipModel.TAX_RATE = decimal.Parse(ds.Tables[0].Rows[0]["TAX_RATE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TAX_AMOUNT"].ToString() != "")
                {
                    shipModel.TAX_AMOUNT = decimal.Parse(ds.Tables[0].Rows[0]["TAX_AMOUNT"].ToString());
                }
                shipModel.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();

                strSql = new StringBuilder();
                strSql.Append("select  * from BLL_SHIPMENT_LINE ");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] lineParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                lineParam[0].Value = slipNumber;
                ds = DbHelperSQL.Query(strSql.ToString(), lineParam);
                BllShipmentLineTable lineModel = null;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    lineModel = new BllShipmentLineTable();
                    lineModel.SLIP_NUMBER = CConvert.ToString(row["SLIP_NUMBER"]);
                    lineModel.LINE_NUMBER = CConvert.ToInt32(row["LINE_NUMBER"]);
                    lineModel.DEPARTUAL_WAREHOUSE_CODE = CConvert.ToString(row["DEPARTUAL_WAREHOUSE_CODE"]);
                    lineModel.PRODUCT_CODE = CConvert.ToString(row["PRODUCT_CODE"]);
                    lineModel.QUANTITY = CConvert.ToDecimal(row["QUANTITY"]);
                    lineModel.UNIT_CODE = CConvert.ToString(row["UNIT_CODE"]);
                    lineModel.PRICE = CConvert.ToDecimal(row["PRICE"]);
                    lineModel.AMOUNT = CConvert.ToDecimal(row["AMOUNT"]);
                    lineModel.MEMO = CConvert.ToString(row["MEMO"]);
                    lineModel.STATUS_FLAG = CConvert.ToInt32(row["STATUS_FLAG"]);
                    if (!string.IsNullOrEmpty(lineModel.SLIP_NUMBER))
                    {
                        shipModel.AddItems(lineModel);
                    }
                }
                return shipModel;
            }
            else
            {
                return null;
            }
        }

        public string GetReceiptInvoiceNumber(string orderSlipNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT TOP 1 ");
            //strSql.Append(" BPO.ORDER_SLIP_NUMBER, ");
            //strSql.Append(" BPO.SLIP_NUMBER AS PO_SLIP_NUMBER, ");
            //strSql.Append(" BR.SLIP_NUMBER AS RECEIPT_SLIP_NUMBER, ");
            //strSql.Append(" BRL.PRODUCT_CODE, ");
            strSql.Append(" BRL.INVOICE_NUMBER ");
            strSql.Append(" FROM BLL_PURCHASE_ORDER AS BPO ");
            strSql.Append(" LEFT JOIN BLL_RECEIPT AS BR ON BPO.SLIP_NUMBER = BR.PO_SLIP_NUMBER ");
            strSql.Append(" LEFT JOIN BLL_RECEIPT_LINE AS BRL ON BR.SLIP_NUMBER = BRL.SLIP_NUMBER ");
            strSql.Append(" WHERE BPO.ORDER_SLIP_NUMBER=@ORDER_SLIP_NUMBER ");
            strSql.Append(" ORDER BY  BPO.SLIP_NUMBER, BR.SLIP_NUMBER ,BRL.LINE_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@ORDER_SLIP_NUMBER", SqlDbType.VarChar,20)};
            parameters[0].Value = orderSlipNumber;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);

            return CConvert.ToString(obj);

        }

        /// <summary>
        /// 获得分页数据总的记录条数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_shipment_search_view");
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
            strSql.Append(")AS Row, T.* from bll_shipment_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        public DataSet GetPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SLIP_NUMBER, ORDER_SLIP_NUMBER, SERIAL_NUMBER, COMPANY_NAME,CONVERT(varchar(12) , SLIP_DATE, 111 ) AS SLIP_DATE,CONVERT(varchar(12) , ARRIVAL_DATE, 111 ) AS ARRIVAL_DATE, AMOUNT, CURRENCY_NAME, STATUS_FLAG,");
            strSql.Append("AMOUNT_INCLUDED_TAX, AMOUNT_WITHOUT_TAX, TAX_RATE, TAX_AMOUNT, LINE_NUMBER, ORDER_LINE_NUMBER,DEPARTUAL_WAREHOUSE_NAME,");
            strSql.Append("PRODUCT_NAME, QUANTITY, UNIT_NAME, PRICE, LINE_AMOUNT, MEMO,CREATE_USER_NAME, CONVERT(varchar(12) , CREATE_DATE_TIME, 111 ) AS CREATE_DATE_TIME, LAST_UPDATE_USER_NAME, CONVERT(varchar(12) , LAST_UPDATE_TIME, 111 ) AS LAST_UPDATE_TIME");
            strSql.Append(" from bll_shipment_search_view ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by SLIP_NUMBER");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得所有数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" from bll_shipment_search_view ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append("order by SLIP_NUMBER");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 出库取消
        /// </summary>
        public int DeleteShipment(string slipNumber, string userCode)
        {

            DataSet shipmentLines = GetList(" SLIP_NUMBER = '" + slipNumber + "'");

            List<CommandInfo> listSql = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BLL_SHIPMENT set ");
            strSql.Append("STATUS_FLAG =@STATUS_FLAG,");
            strSql.Append("LAST_UPDATE_USER =@LAST_UPDATE_USER, ");
            strSql.Append("LAST_UPDATE_TIME =GETDATE() ");
            strSql.Append("where SLIP_NUMBER=@SLIP_NUMBER");
            SqlParameter[] shipmentParameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50),
                    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
                    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
            shipmentParameters[0].Value = slipNumber;
            shipmentParameters[1].Value = CConstant.DELETE;
            shipmentParameters[2].Value = userCode;
            listSql.Add(new CommandInfo(strSql.ToString(), shipmentParameters));

            foreach (DataRow dr in shipmentLines.Tables[0].Rows)
            {
                //库存更新
                strSql = new StringBuilder();
                strSql.Append("update BASE_STOCK set ");
                strSql.Append("QUANTITY=QUANTITY+@QUANTITY,");
                strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");

                SqlParameter[] stockParam = {
                            new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
                            new SqlParameter("@PRODUCT_CODE",  SqlDbType.VarChar,20),
                            new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@LAST_UPDATE_USER",  SqlDbType.VarChar,20)};
                stockParam[0].Value = dr["DEPARTUAL_WAREHOUSE_CODE"];
                stockParam[1].Value = dr["PRODUCT_CODE"];
                stockParam[2].Value = dr["QUANTITY"];
                stockParam[3].Value = userCode;
                listSql.Add(new CommandInfo(strSql.ToString(), stockParam));

                //出库数量的更新
                strSql = new StringBuilder();
                strSql.Append("update BLL_ORDER_LINE set ");
                strSql.Append("SHIPMENT_QUANTITY=SHIPMENT_QUANTITY-@SHIPMENT_QUANTITY");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER and LINE_NUMBER=@LINE_NUMBER ");
                strSql.AppendFormat("and STATUS_FLAG <>{0}", CConstant.DELETE);

                SqlParameter[] orderLineParam = {					        
                            new SqlParameter("@SLIP_NUMBER",  SqlDbType.VarChar,20),
                            new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
                            new SqlParameter("@SHIPMENT_QUANTITY", SqlDbType.Decimal,9)};
                orderLineParam[0].Value = dr["ORDER_SLIP_NUMBER"];
                orderLineParam[1].Value = dr["ORDER_LINE_NUMBER"];
                orderLineParam[2].Value = dr["QUANTITY"];
                listSql.Add(new CommandInfo(strSql.ToString(), orderLineParam));
            }

            return DbHelperSQL.ExecuteSqlTran(listSql);

        }

        /// <summary>
        /// 根据出库编号获得是否开过发票的状态
        /// </summary>
        public DataSet GetShipmentFlag(string slip_number)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT STATUS_FLAG FROM BLL_SHIPMENT WHERE SLIP_NUMBER='{0}'", slip_number);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得简易的出库订单，只包含HEADER部分信息
        /// </summary>
        public DataSet GetShipMentPrintSelectList(string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM ( ");
            strSql.Append(" SELECT  '' AS NO, SH.*, ");
            strSql.Append(" OH.SLIP_DATE AS ORDER_SLIP_DATE,  ");
            strSql.Append(" OH.CUSTOMER_PO_NUMBER,  ");
            strSql.Append(" OH.OWNER_PO_NUMBER,  ");
            strSql.Append(" OH.CUSTOMER_CODE,  ");
            strSql.Append(" OH.ENDER_CUSTOMER_CODE, ");
            strSql.Append(" OH.DELIVERY_POINT_CODE,   ");
            strSql.Append(" BEC.NAME AS ENDER_CUSTOMER_NAME ");
            strSql.Append(" FROM BLL_SHIPMENT AS SH ");
            strSql.Append(" LEFT JOIN dbo.BLL_ORDER_HEADER AS OH ON OH.SLIP_NUMBER = SH.ORDER_SLIP_NUMBER  ");
            strSql.Append(" LEFT JOIN dbo.BASE_CUSTOMER AS BEC ON OH.ENDER_CUSTOMER_CODE = BEC.CODE  ");
            strSql.Append(" ) AS V ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by SLIP_NUMBER");
            return DbHelperSQL.Query(strSql.ToString());
        }

        //获得在库数
        public decimal GetStock(string  warehouse, string product)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT QUANTITY FROM BASE_STOCK");
            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
            strSql.AppendFormat("and STATUS_FLAG <>{0}", CConstant.DELETE);
            SqlParameter[] stockParam = {					        
                            new SqlParameter("@WAREHOUSE_CODE",  SqlDbType.VarChar,20),
                            new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20)};
            stockParam[0].Value = warehouse;
            stockParam[1].Value = product;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), stockParam);
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
    }
}
