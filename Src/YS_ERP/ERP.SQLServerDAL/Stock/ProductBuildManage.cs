using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.IDAL;
using System.Data;
using CZZD.ERP.Model;
using CZZD.ERP.DBUtility;
using System.Data.SqlClient;
using CZZD.ERP.Common;

namespace CZZD.ERP.SQLServerDAL
{
    public class ProductBuildManage : IProductBuild
    {
        #region 组成品输入
        public int GetBuildRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_product_build_entry_view");
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

        public DataSet GetBilldList(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.PRODUCT_PART_CODE asc");
            }
            strSql.Append(")AS Row, T.* from bll_product_build_entry_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetBuildPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PRODUCT_CODE, PRODUCT_NAME, PRODUCT_PART_CODE, PRODUCT_PART_NAME, SPEC, UNIT_CODE, UNIT_NAME, QUANTITY from bll_product_build_entry_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得最大的组成编号
        /// </summary>
        public string GetBuildMaxSlipNumber()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ISNULL(MAX(SLIP_NUMBER), 0) AS MAX_SLIP_NUMBER from BLL_PRODUCT_BUILD");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }

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

        public int AddBuild(BllProductBuildTable PBModel)
        { 
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = null;

                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_PRODUCT_BUILD(");
                    strSql.Append("SLIP_NUMBER,WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,BUILD_DATE,COMPANY_CODE,UNIT_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@WAREHOUSE_CODE,@PRODUCT_CODE,@QUANTITY,@BUILD_DATE,@COMPANY_CODE,@UNIT_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                    SqlParameter[] buildParam = {
					    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					    new SqlParameter("@BUILD_DATE", SqlDbType.DateTime),
					    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                    buildParam[0].Value = PBModel.SLIP_NUMBER;
                    buildParam[1].Value = PBModel.WAREHOUSE_CODE;
                    buildParam[2].Value = PBModel.PRODUCT_CODE;
                    buildParam[3].Value = PBModel.QUANTITY;
                    buildParam[4].Value = PBModel.BUILD_DATE;
                    buildParam[5].Value = PBModel.COMPANY_CODE;
                    buildParam[6].Value = PBModel.UNIT_CODE;
                    buildParam[7].Value = PBModel.STATUS_FLAG;
                    buildParam[8].Value = PBModel.CREATE_USER;
                    buildParam[9].Value = PBModel.LAST_UPDATE_USER;
                    listSql.Add(new CommandInfo(strSql.ToString(), buildParam));

                    if (Existstock(PBModel.WAREHOUSE_CODE, PBModel.PRODUCT_CODE))
                    {
                        //库存中组成品数量的增加
                        strSql = new StringBuilder();
                        strSql.Append("update BASE_STOCK set ");
                        strSql.Append("QUANTITY=QUANTITY + @QUANTITY,");
                        strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                        strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                        strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
                        SqlParameter[] addParam = {
					        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                        addParam[0].Value = PBModel.WAREHOUSE_CODE;
                        addParam[1].Value = PBModel.PRODUCT_CODE;
                        addParam[2].Value = PBModel.QUANTITY;
                        addParam[3].Value = PBModel.LAST_UPDATE_USER;
                        listSql.Add(new CommandInfo(strSql.ToString(), addParam));
                    }
                    else
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BASE_STOCK(");
                        strSql.Append("WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                        strSql.Append(" values (");
                        strSql.Append("@WAREHOUSE_CODE,@PRODUCT_CODE,@UNIT_CODE,@QUANTITY,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                        SqlParameter[] stockParam = {
					        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					        new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                        stockParam[0].Value = PBModel.WAREHOUSE_CODE;
                        stockParam[1].Value = PBModel.PRODUCT_CODE;
                        stockParam[2].Value = PBModel.UNIT_CODE;
                        stockParam[3].Value = PBModel.QUANTITY;
                        stockParam[4].Value = CConstant.INIT;
                        stockParam[5].Value = PBModel.CREATE_USER;
                        stockParam[6].Value = PBModel.LAST_UPDATE_USER;
                        listSql.Add(new CommandInfo(strSql.ToString(), stockParam));
                    }

                    foreach (BllProductBuildLineTable PBLModel in PBModel.Items)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_PRODUCT_BUILD_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_PARTS_CODE,PARTS_QUANTITY,UNIT_CODE,STATUS_FLAG)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_PARTS_CODE,@PARTS_QUANTITY,@UNIT_CODE,@STATUS_FLAG)");
                        SqlParameter[] BLParam = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					        new SqlParameter("@PRODUCT_PARTS_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PARTS_QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                        BLParam[0].Value = PBLModel.SLIP_NUMBER;
                        BLParam[1].Value = PBLModel.LINE_NUMBER;
                        BLParam[2].Value = PBLModel.PRODUCT_PARTS_CODE;
                        BLParam[3].Value = PBLModel.PARTS_QUANTITY;
                        BLParam[4].Value = PBLModel.UNIT_CODE;
                        BLParam[5].Value = PBLModel.STATUS_FLAG;
                        listSql.Add(new CommandInfo(strSql.ToString(), BLParam));

                        //库存中材料商品数量的减少
                        strSql = new StringBuilder();
                        strSql.Append("update BASE_STOCK set ");
                        strSql.Append("QUANTITY=QUANTITY - @QUANTITY,");
                        strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                        strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                        strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
                        SqlParameter[] minusParam = {
					        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                        minusParam[0].Value = PBModel.WAREHOUSE_CODE;
                        minusParam[1].Value = PBLModel.PRODUCT_PARTS_CODE;
                        minusParam[2].Value = PBLModel.PARTS_QUANTITY;
                        minusParam[3].Value = PBModel.LAST_UPDATE_USER;
                        listSql.Add(new CommandInfo(strSql.ToString(), minusParam));
                    }
                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                }
                catch (SqlException ex)
                {
                    if (i != 9)
                    {
                        int maxLlipNumber = CConvert.ToInt32(GetBuildMaxSlipNumber()) + 1;
                        PBModel.SLIP_NUMBER = maxLlipNumber.ToString().PadLeft(4, '0');
                        i++;
                        continue;
                    }
                }
                break;
            }
            return result;
        }
        #endregion 

        #region 组成品查询
        public int GetBuildSearchRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from bll_product_build_search_view");
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
        /// 获得查询分页数据列表
        /// </summary>
        public DataSet GetBuildSearchList(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.* from bll_product_build_search_view T");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetBuildSearchPrintList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from bll_product_build_search_view");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion

        #region 详细
        public BllProductBuildTable GetModel(string SLIP_NUMBER)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SLIP_NUMBER,WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,BUILD_DATE,COMPANY_CODE,UNIT_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER from BLL_PRODUCT_BUILD ");
            strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
            SqlParameter[] parameters = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
            parameters[0].Value = SLIP_NUMBER;

            BllProductBuildTable PBModel = new BllProductBuildTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                PBModel.SLIP_NUMBER = ds.Tables[0].Rows[0]["SLIP_NUMBER"].ToString();
                PBModel.WAREHOUSE_CODE = ds.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString();
                PBModel.PRODUCT_CODE = ds.Tables[0].Rows[0]["PRODUCT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["QUANTITY"].ToString() != "")
                {
                    PBModel.QUANTITY = decimal.Parse(ds.Tables[0].Rows[0]["QUANTITY"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BUILD_DATE"].ToString() != "")
                {
                    PBModel.BUILD_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["BUILD_DATE"].ToString());
                }
                PBModel.COMPANY_CODE = ds.Tables[0].Rows[0]["COMPANY_CODE"].ToString();
                PBModel.UNIT_CODE = ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
                if (ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString() != "")
                {
                    PBModel.STATUS_FLAG = int.Parse(ds.Tables[0].Rows[0]["STATUS_FLAG"].ToString());
                }
                PBModel.CREATE_USER = ds.Tables[0].Rows[0]["CREATE_USER"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString() != "")
                {
                    PBModel.CREATE_DATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE_TIME"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString() != "")
                {
                    PBModel.LAST_UPDATE_TIME = DateTime.Parse(ds.Tables[0].Rows[0]["LAST_UPDATE_TIME"].ToString());
                }
                PBModel.LAST_UPDATE_USER = ds.Tables[0].Rows[0]["LAST_UPDATE_USER"].ToString();

                strSql = new StringBuilder();
                strSql.Append("select  SLIP_NUMBER,LINE_NUMBER,PRODUCT_PARTS_CODE,PARTS_QUANTITY,UNIT_CODE,STATUS_FLAG from BLL_PRODUCT_BUILD_LINE ");
                strSql.Append(" where SLIP_NUMBER=@SLIP_NUMBER ");
                SqlParameter[] lineParam = {
					new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,50)};
                lineParam[0].Value = SLIP_NUMBER;

                ds = DbHelperSQL.Query(strSql.ToString(), lineParam);
                BllProductBuildLineTable LModel = null;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    LModel = new BllProductBuildLineTable();

                    LModel.SLIP_NUMBER = row["SLIP_NUMBER"].ToString();
                    LModel.LINE_NUMBER = CConvert.ToInt32(row["LINE_NUMBER"]);
                    LModel.PRODUCT_PARTS_CODE = row["PRODUCT_PARTS_CODE"].ToString();
                    LModel.PARTS_QUANTITY = CConvert.ToDecimal(row["PARTS_QUANTITY"].ToString());
                    LModel.UNIT_CODE = row["UNIT_CODE"].ToString();
                    LModel.STATUS_FLAG = CConvert.ToInt32(row["STATUS_FLAG"].ToString());

                    if (LModel.SLIP_NUMBER != null)
                    {
                        PBModel.AddItem(LModel);
                    }
                }

                return PBModel;
            }
            else
            {
                return null;
            }

            
        }

        #endregion

        #region 解除
        public DataSet getParts(string PRODUCT_CODE)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT pp.PRODUCT_CODE, p.CODE as PRODUCT_PART_CODE, p.NAME, pp.QUANTITY, pp.QUANTITY,  pp.STATUS_FLAG ");
            strSql.Append(" FROM BASE_PRODUCT_PARTS as pp left outer join ");
            strSql.Append(" BASE_PRODUCT as p on pp.PRODUCT_PART_CODE = p.CODE ");
            strSql.Append(" where PRODUCT_CODE = @PRODUCT_CODE and pp.STATUS_FLAG <> 9");
            SqlParameter[] parameters = {
					new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,50)};
            parameters[0].Value = PRODUCT_CODE;

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public int AddRelieve(BllProductBuildTable PBModel)
        {
            int i = 0;
            int result = 0;
            while (i < 10)
            {
                try
                {
                    List<CommandInfo> listSql = new List<CommandInfo>();
                    StringBuilder strSql = null;

                    strSql = new StringBuilder();
                    strSql.Append("insert into BLL_PRODUCT_BUILD(");
                    strSql.Append("SLIP_NUMBER,WAREHOUSE_CODE,PRODUCT_CODE,QUANTITY,BUILD_DATE,COMPANY_CODE,UNIT_CODE,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                    strSql.Append(" values (");
                    strSql.Append("@SLIP_NUMBER,@WAREHOUSE_CODE,@PRODUCT_CODE,@QUANTITY,@BUILD_DATE,@COMPANY_CODE,@UNIT_CODE,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                    SqlParameter[] buildParam = {
					    new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					    new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					    new SqlParameter("@BUILD_DATE", SqlDbType.DateTime),
					    new SqlParameter("@COMPANY_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					    new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					    new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					    new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                    buildParam[0].Value = PBModel.SLIP_NUMBER;
                    buildParam[1].Value = PBModel.WAREHOUSE_CODE;
                    buildParam[2].Value = PBModel.PRODUCT_CODE;
                    buildParam[3].Value = PBModel.QUANTITY;
                    buildParam[4].Value = PBModel.BUILD_DATE;
                    buildParam[5].Value = PBModel.COMPANY_CODE;
                    buildParam[6].Value = PBModel.UNIT_CODE;
                    buildParam[7].Value = PBModel.STATUS_FLAG;
                    buildParam[8].Value = PBModel.CREATE_USER;
                    buildParam[9].Value = PBModel.LAST_UPDATE_USER;
                    listSql.Add(new CommandInfo(strSql.ToString(), buildParam));

                    //库存中组成品数量的减少
                    strSql = new StringBuilder();
                    strSql.Append("update BASE_STOCK set ");
                    strSql.Append("QUANTITY=QUANTITY - @QUANTITY,");
                    strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                    strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                    strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
                    SqlParameter[] minusParam = {
					        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                    minusParam[0].Value = PBModel.WAREHOUSE_CODE;
                    minusParam[1].Value = PBModel.PRODUCT_CODE;
                    minusParam[2].Value = PBModel.QUANTITY;
                    minusParam[3].Value = PBModel.LAST_UPDATE_USER;
                    listSql.Add(new CommandInfo(strSql.ToString(), minusParam));

                    foreach (BllProductBuildLineTable PBLModel in PBModel.Items)
                    {
                        strSql = new StringBuilder();
                        strSql.Append("insert into BLL_PRODUCT_BUILD_LINE(");
                        strSql.Append("SLIP_NUMBER,LINE_NUMBER,PRODUCT_PARTS_CODE,PARTS_QUANTITY,UNIT_CODE,STATUS_FLAG)");
                        strSql.Append(" values (");
                        strSql.Append("@SLIP_NUMBER,@LINE_NUMBER,@PRODUCT_PARTS_CODE,@PARTS_QUANTITY,@UNIT_CODE,@STATUS_FLAG)");
                        SqlParameter[] BLParam = {
					        new SqlParameter("@SLIP_NUMBER", SqlDbType.VarChar,20),
					        new SqlParameter("@LINE_NUMBER", SqlDbType.Int,4),
					        new SqlParameter("@PRODUCT_PARTS_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PARTS_QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4)};
                        BLParam[0].Value = PBLModel.SLIP_NUMBER;
                        BLParam[1].Value = PBLModel.LINE_NUMBER;
                        BLParam[2].Value = PBLModel.PRODUCT_PARTS_CODE;
                        BLParam[3].Value = PBLModel.PARTS_QUANTITY;
                        BLParam[4].Value = PBLModel.UNIT_CODE;
                        BLParam[5].Value = PBLModel.STATUS_FLAG;
                        listSql.Add(new CommandInfo(strSql.ToString(), BLParam));

                        if (Existstock(PBModel.WAREHOUSE_CODE, PBLModel.PRODUCT_PARTS_CODE))
                        {
                            //库存中材料商品数量的增加
                            strSql = new StringBuilder();
                            strSql.Append("update BASE_STOCK set ");
                            strSql.Append("QUANTITY=QUANTITY + @QUANTITY,");
                            strSql.Append("LAST_UPDATE_TIME=GETDATE(),");
                            strSql.Append("LAST_UPDATE_USER=@LAST_UPDATE_USER");
                            strSql.Append(" where WAREHOUSE_CODE=@WAREHOUSE_CODE and PRODUCT_CODE=@PRODUCT_CODE ");
                            SqlParameter[] addParam = {
					        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
                            new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                            addParam[0].Value = PBModel.WAREHOUSE_CODE;
                            addParam[1].Value = PBLModel.PRODUCT_PARTS_CODE;
                            addParam[2].Value = PBLModel.PARTS_QUANTITY;
                            addParam[3].Value = PBModel.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), addParam));
                        }
                        else
                        {
                            strSql = new StringBuilder();
                            strSql.Append("insert into BASE_STOCK(");
                            strSql.Append("WAREHOUSE_CODE,PRODUCT_CODE,UNIT_CODE,QUANTITY,STATUS_FLAG,CREATE_USER,CREATE_DATE_TIME,LAST_UPDATE_TIME,LAST_UPDATE_USER)");
                            strSql.Append(" values (");
                            strSql.Append("@WAREHOUSE_CODE,@PRODUCT_CODE,@UNIT_CODE,@QUANTITY,@STATUS_FLAG,@CREATE_USER,GETDATE(),GETDATE(),@LAST_UPDATE_USER)");
                            SqlParameter[] stockParam = {
					        new SqlParameter("@WAREHOUSE_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@PRODUCT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,20),
					        new SqlParameter("@QUANTITY", SqlDbType.Decimal,9),
					        new SqlParameter("@STATUS_FLAG", SqlDbType.Int,4),
					        new SqlParameter("@CREATE_USER", SqlDbType.VarChar,20),
					        new SqlParameter("@LAST_UPDATE_USER", SqlDbType.VarChar,20)};
                            stockParam[0].Value = PBModel.WAREHOUSE_CODE;
                            stockParam[1].Value = PBLModel.PRODUCT_PARTS_CODE;
                            stockParam[2].Value = PBLModel.UNIT_CODE;
                            stockParam[3].Value = PBLModel.PARTS_QUANTITY;
                            stockParam[4].Value = CConstant.INIT;
                            stockParam[5].Value = PBModel.CREATE_USER;
                            stockParam[6].Value = PBModel.LAST_UPDATE_USER;
                            listSql.Add(new CommandInfo(strSql.ToString(), stockParam));
                        }
                    }
                    result = DbHelperSQL.ExecuteSqlTran(listSql);
                }
                catch (SqlException ex)
                {
                    if (i != 9)
                    {
                        int maxLlipNumber = CConvert.ToInt32(GetBuildMaxSlipNumber()) + 1;
                        PBModel.SLIP_NUMBER = maxLlipNumber.ToString().PadLeft(4, '0');
                        i++;
                        continue;
                    }
                }
                break;
            }
            return result;
        }
        #endregion
    }
}
