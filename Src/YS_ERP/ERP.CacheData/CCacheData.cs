using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using System.Collections;

namespace CZZD.ERP.CacheData
{
    public class CCacheData
    {
        private static BCommon bCommon = new BCommon();

        private static DataTable _slipType = null;
        private static DataTable _taxation = null;
        private static DataTable _currency = null;
        private static DataTable _myDesk = null;
        private static DataTable _warehouse = null;
        private static DataTable _reason = null;
        private static DataTable _attacheDirectory = null;
        private static DataTable _functions = null;
        private static DataTable _rolesFunction = null;
        private static DataTable _delay = null;
        private static DataTable _company = null;
        private static DataTable _stations = null;
        private static DataTable _fileType = null;
        private static DataTable _baseTable = null;
        private static DataTable _distinction = null;
        private static DataTable _purchaseOrder = null;
        private static DataTable _reverseStorage = null;
        private static DataTable _receipt = null;
        private static Hashtable _ht = null;
        private static DataTable _baseNames = null;
        private static DataTable _enquiryMethod = null;
        private static DataTable _deliveryPeriod = null;
        private static DataTable _deliveryTerms = null;
        private static DataTable _paymentTerms = null;
        private static DataTable _drawingtype = null;
        private static DataTable _language = null;
        private static DataTable _status = null;
        private static DataTable _drawingstatus = null;
        private static DataTable _order = null;
        private static DataTable _technologystatus = null;
        private static DataTable _level = null;

        private static DataTable _judgment = null;
        public static DataTable JUDGMENT
        {
            get
            {
                if (_judgment == null)
                {
                    _judgment = new DataTable();
                    _judgment.Columns.Add("CODE", Type.GetType("System.String"));
                    _judgment.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _judgment.NewRow();
                    dr["CODE"] = "0";
                    dr["NAME"] = "否";
                    _judgment.Rows.Add(dr);

                    dr = _judgment.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "是";
                    _judgment.Rows.Add(dr);
                }
                return _judgment;
            }
            set { _judgment = value; }
        }

        public static DataTable LEVEL
        {
            get
            {
                if (_level == null)
                {
                    _level = new DataTable();
                    _level.Columns.Add("CODE", Type.GetType("System.String"));
                    _level.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _level.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "1";
                    _level.Rows.Add(dr);

                    dr = _level.NewRow();
                    dr["CODE"] = "2";
                    dr["NAME"] = "2";
                    _level.Rows.Add(dr);

                    dr = _level.NewRow();
                    dr["CODE"] = "3";
                    dr["NAME"] = "3";
                    _level.Rows.Add(dr);

                    dr = _level.NewRow();
                    dr["CODE"] = "4";
                    dr["NAME"] = "4";
                    _level.Rows.Add(dr);

                    dr = _level.NewRow();
                    dr["CODE"] = "5";
                    dr["NAME"] = "5";
                    _level.Rows.Add(dr);

                    dr = _level.NewRow();
                    dr["CODE"] = "6";
                    dr["NAME"] = "6";
                    _level.Rows.Add(dr);

                    dr = _level.NewRow();
                    dr["CODE"] = "7";
                    dr["NAME"] = "7";
                    _level.Rows.Add(dr);

                    dr = _level.NewRow();
                    dr["CODE"] = "8";
                    dr["NAME"] = "8";
                    _level.Rows.Add(dr);

                    dr = _level.NewRow();
                    dr["CODE"] = "9";
                    dr["NAME"] = "9";
                    _level.Rows.Add(dr);

                    dr = _level.NewRow();
                    dr["CODE"] = "10";
                    dr["NAME"] = "10";
                    _level.Rows.Add(dr);
                }
                return _level;
            }
            set { _level = value; }
        }



        public static DataTable TECHNOLOGYSTATUS
        {
            get
            {
                if (_technologystatus == null)
                {
                    _technologystatus = new DataTable();
                    _technologystatus.Columns.Add("CODE", Type.GetType("System.String"));
                    _technologystatus.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _technologystatus.NewRow();
                    dr["CODE"] = "4";
                    dr["NAME"] = "全部";
                    _technologystatus.Rows.Add(dr);

                    dr = _technologystatus.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "已结束";
                    _technologystatus.Rows.Add(dr);

                    dr = _technologystatus.NewRow();
                    dr["CODE"] = "0";
                    dr["NAME"] = "未结束";
                    _technologystatus.Rows.Add(dr);
                }
                return _technologystatus;
            }
            set { _technologystatus = value; }
        }

        public static DataTable Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new DataTable();
                    _order.Columns.Add("CODE", Type.GetType("System.String"));
                    _order.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _order.NewRow();
                    dr["CODE"] = "CN";
                    dr["NAME"] = "形式发票报表";
                    _order.Rows.Add(dr);

                    dr = _order.NewRow();
                    dr["CODE"] = "EN";
                    dr["NAME"] = "订单报表";
                    _order.Rows.Add(dr);
                }
                return _order;
            }
            set { _order = value; }
        }

        public static DataTable DrawingSTATUS
        {
            get
            {
                if (_drawingstatus == null)
                {
                    _drawingstatus = new DataTable();
                    _drawingstatus.Columns.Add("CODE", Type.GetType("System.String"));
                    _drawingstatus.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _drawingstatus.NewRow();
                    dr["CODE"] = "4";
                    dr["NAME"] = "全部";
                    _drawingstatus.Rows.Add(dr);

                    dr = _drawingstatus.NewRow();
                    dr["CODE"] = "0";
                    dr["NAME"] = "未结束";
                    _drawingstatus.Rows.Add(dr);

                    dr = _drawingstatus.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "结束";
                    _drawingstatus.Rows.Add(dr);

                }
                return _drawingstatus;
            }
            set { _drawingstatus = value; }
        }

        public static DataTable STATUS
        {
            get
            {
                if (_status == null)
                {
                    _status = new DataTable();
                    _status.Columns.Add("CODE", Type.GetType("System.String"));
                    _status.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _status.NewRow();
                    dr["CODE"] = "4";
                    dr["NAME"] = "全部";
                    _status.Rows.Add(dr);

                    dr = _status.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "已开始";
                    _status.Rows.Add(dr);

                    dr = _status.NewRow();
                    dr["CODE"] = "2";
                    dr["NAME"] = "已结束";
                    _status.Rows.Add(dr);

                    dr = _status.NewRow();
                    dr["CODE"] = "0";
                    dr["NAME"] = "未开始";
                    _status.Rows.Add(dr);
                }
                return _status;
            }
            set { _status = value; }
        }

        public static DataTable Language
        {
            get
            {
                if (_language == null)
                {
                    _language = new DataTable();
                    _language.Columns.Add("CODE", Type.GetType("System.String"));
                    _language.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _language.NewRow();
                    dr["CODE"] = "CN";
                    dr["NAME"] = "中文";
                    _language.Rows.Add(dr);

                    dr = _language.NewRow();
                    dr["CODE"] = "EN";
                    dr["NAME"] = "英文";
                    _language.Rows.Add(dr);
                }
                return _language;
            }
            set { _language = value; }
        }

        public static DataTable PurchaseOrder
        {
            get
            {
                if (_purchaseOrder == null)
                {
                    _purchaseOrder = new DataTable();
                    _purchaseOrder.Columns.Add("CODE", Type.GetType("System.String"));
                    _purchaseOrder.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _purchaseOrder.NewRow();
                    dr["CODE"] = CConstant.PURCHASE_NEED;
                    dr["NAME"] = "需求采购";
                    _purchaseOrder.Rows.Add(dr);

                    dr = _purchaseOrder.NewRow();
                    dr["CODE"] = CConstant.PURCHASE_REPAIRS;
                    dr["NAME"] = "售后维修采购";
                    _purchaseOrder.Rows.Add(dr);

                    dr = _purchaseOrder.NewRow();
                    dr["CODE"] = CConstant.PURCHASE_OTHERS;
                    dr["NAME"] = "其他采购";
                    _purchaseOrder.Rows.Add(dr);
                }
                return _purchaseOrder;
            }
            set { _purchaseOrder = value; }
        }

        public static DataTable ReverseStorage
        {
            get
            {
                if (_reverseStorage == null)
                {
                    _reverseStorage = new DataTable();
                    _reverseStorage.Columns.Add("CODE", Type.GetType("System.String"));
                    _reverseStorage.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _reverseStorage.NewRow();
                    dr["CODE"] = CConstant.PURCHASE_RETURN;
                    dr["NAME"] = "采购入库返品";
                    _reverseStorage.Rows.Add(dr);

                    dr = _reverseStorage.NewRow();
                    dr["CODE"] = CConstant.PRODUCE_RETURN;
                    dr["NAME"] = "生产返品";
                    _reverseStorage.Rows.Add(dr);
                }
                return _reverseStorage;
            }
            set { _reverseStorage = value; }
        }

        public static DataTable Delay
        {
            get
            {
                if (_delay == null)
                {
                    _delay = new DataTable();
                    _delay.Columns.Add("CODE", Type.GetType("System.String"));
                    _delay.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _delay.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "90日";
                    _delay.Rows.Add(dr);

                    dr = _delay.NewRow();
                    dr["CODE"] = "2";
                    dr["NAME"] = "180日";
                    _delay.Rows.Add(dr);

                    dr = _delay.NewRow();
                    dr["CODE"] = "3";
                    dr["NAME"] = "一年";
                    _delay.Rows.Add(dr);
                }
                return _delay;
            }
            set { _delay = value; }
        }


        /// <summary>
        /// 生产线
        /// </summary>
        public static DataTable SlipType
        {
            get
            {
                if (_slipType == null)
                {
                    _slipType = bCommon.GetMasterList("SLIP_TYPE", "", "", "").Tables[0];
                }
                return CCacheData._slipType;
            }
            set { CCacheData._slipType = value; }
        }

        public static DataTable Stations
        {
            get
            {
                if (_stations == null)
                {
                    _stations = bCommon.GetMasterList("NAMES", "", "", " CODE_TYPE='MaintenanceStations'").Tables[0];
                }
                return CCacheData._stations;
            }
            set { CCacheData._stations = value; }
        }

        /// <summary>
        /// 税率
        /// </summary>
        public static DataTable Taxation
        {
            get
            {
                if (_taxation == null)
                {
                    _taxation = bCommon.GetMasterList("TAXATION", "", "", "").Tables[0];
                }
                return CCacheData._taxation;
            }
            set { CCacheData._taxation = value; }
        }

        /// <summary>
        /// 货币
        /// </summary>
        public static DataTable Currency
        {
            get
            {
                if (_currency == null)
                {
                    _currency = bCommon.GetMasterList("CURRENCY", "", "", "").Tables[0];
                }
                return CCacheData._currency;
            }
            set { CCacheData._currency = value; }
        }

        /// <summary>
        /// 理由
        /// </summary>
        public static DataTable Reason
        {
            get
            {
                if (_reason == null)
                {
                    _reason = bCommon.GetMasterList("REASON", "", "", "").Tables[0];
                }
                return CCacheData._reason;
            }
            set { CCacheData._reason = value; }
        }

        /// <summary>
        /// 公司
        /// </summary>
        public static DataTable Company
        {
            get
            {
                if (_company == null)
                {
                    _company = bCommon.GetMasterList("COMPANY", "", "", "").Tables[0];
                }
                return CCacheData._company;
            }
            set { CCacheData._company = value; }
        }


        /// <summary>
        /// 我的桌面信息
        /// </summary>
        public static DataTable GetDesk(string companyCode, string userCode)
        {
            if (_myDesk == null || _myDesk.Rows.Count == 0)
            {
                ResetDesk(companyCode, userCode);
            }
            return _myDesk;
        }

        /// <summary>
        /// 重设我的桌面信息
        /// </summary>
        public static void ResetDesk(string companyCode, string userCode)
        {
            _myDesk = bCommon.GetDeskDatas(companyCode, userCode).Tables[0];
        }

        /// <summary>
        /// 仓库
        /// </summary>
        public static DataTable WAREHOUSE
        {
            get
            {
                if (_warehouse == null)
                {
                    _warehouse = bCommon.GetMasterList("WAREHOUSE", "", "", "").Tables[0];
                }
                return CCacheData._warehouse;

            }
            set { CCacheData._warehouse = value; }
        }

        /// <summary>
        ///  附件目录
        /// </summary>
        public static DataTable AttacheDirectory
        {
            get
            {
                if (_attacheDirectory == null)
                {
                    _attacheDirectory = bCommon.GetNames("ATTACHED_PATH").Tables[0];
                }
                return CCacheData._attacheDirectory;
            }
            set { CCacheData._attacheDirectory = value; }
        }

        /// <summary>
        /// 获得指定类型的目录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetAttacheDirectory(string type)
        {
            string ret = "";
            foreach (DataRow dr in CCacheData.AttacheDirectory.Rows)
            {
                if (type.Equals(dr["CODE"]))
                {
                    ret = CConvert.ToString(dr["PROPERT1"]);
                }
            }
            return ret;
        }

        /// <summary>
        /// 系统功能列表
        /// </summary>
        public static DataTable Function
        {
            get
            {
                if (_functions == null)
                {
                    _functions = bCommon.GetFunctionList().Tables[0];
                }
                return CCacheData._functions;
            }
            set { CCacheData._functions = value; }
        }

        /// <summary>
        /// 获得当前角色的所有权限
        /// </summary>
        public static void SetRolesFunction(string roles_code)
        {
            _rolesFunction = bCommon.GetRoles(roles_code).Tables[0];
        }

        /// <summary>
        /// 获得当前角色的所有权限
        /// </summary>
        public static DataTable GetRolesFunction(string roles_code)
        {
            if (_rolesFunction == null)
            {
                SetRolesFunction(roles_code);
            }
            return _rolesFunction;
        }

        /// <summary>
        /// 导入文件类型
        /// </summary>
        public static DataTable FileType
        {
            get
            {
                if (_fileType == null)
                {
                    _fileType = new DataTable();
                    _fileType.Columns.Add("CODE", Type.GetType("System.String"));
                    _fileType.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _fileType.NewRow();
                    dr["CODE"] = "EXCEL";
                    dr["NAME"] = "Excel文件(*.xls,*.xlsx)";
                    _fileType.Rows.Add(dr);

                    dr = _fileType.NewRow();
                    dr["CODE"] = "TXT";
                    dr["NAME"] = "文本文件(*.txt)";
                    _fileType.Rows.Add(dr);

                    dr = _fileType.NewRow();
                    dr["CODE"] = "CSV";
                    dr["NAME"] = "文本文件(*.csv)";
                    _fileType.Rows.Add(dr);
                }
                return CCacheData._fileType;
            }
            set { CCacheData._fileType = value; }
        }

        /// <summary>
        /// 导入数据库表名
        /// </summary>
        public static DataTable BaseTable
        {
            get
            {
                if (_baseTable == null)
                {
                    _baseTable = new DataTable();
                    _baseTable.Columns.Add("CODE", Type.GetType("System.String"));
                    _baseTable.Columns.Add("NAME", Type.GetType("System.String"));
                    DataRow dr = null;

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "";
                    dr["NAME"] = "未设定";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_UNIT";
                    dr["NAME"] = "单位设定";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_SUPPLIER";
                    dr["NAME"] = "供应商";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_SLIP_TYPE";
                    dr["NAME"] = "产线";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_COMPOSITION_PRODUCTS";
                    dr["NAME"] = "组成品";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_SLIP_TYPE_COMPOSITION_PRODUCTS";
                    dr["NAME"] = "产线构成";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_SPECIFICATION";
                    dr["NAME"] = "规格型号";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_COMPOSITION_PRODUCTS_SPECIFICATION";
                    dr["NAME"] = "组成品规格构成";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_PRODUCT_GROUP";
                    dr["NAME"] = "外购件种类种类";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_PRODUCT";
                    dr["NAME"] = "外购件信息";
                    _baseTable.Rows.Add(dr);

                    dr = _baseTable.NewRow();
                    dr["CODE"] = "BASE_PRODUCT_PARTS";
                    dr["NAME"] = "规格型号构成";
                    _baseTable.Rows.Add(dr);

                    //dr = _baseTable.NewRow();
                    //dr["CODE"] = "BASE_PRODUCT_PARTS";
                    //dr["NAME"] = "商品材料构成";
                    //_baseTable.Rows.Add(dr);                    

                    //dr = _baseTable.NewRow();
                    //dr["CODE"] = "BASE_CUSTOMER";
                    //dr["NAME"] = "客户信息";
                    //_baseTable.Rows.Add(dr);

                    //dr = _baseTable.NewRow();
                    //dr["CODE"] = "BASE_CUSTOMER_PRICE";
                    //dr["NAME"] = "客户单价";
                    //_baseTable.Rows.Add(dr);

                    //dr = _baseTable.NewRow();
                    //dr["CODE"] = "BASE_STOCK";
                    //dr["NAME"] = "库存";
                    //_baseTable.Rows.Add(dr);

                    //dr = _baseTable.NewRow();
                    //dr["CODE"] = "BASE_WAREHOUSE";
                    //dr["NAME"] = "仓库";
                    //_baseTable.Rows.Add(dr);

                    //dr = _baseTable.NewRow();
                    //dr["CODE"] = "BASE_LOCATION";
                    //dr["NAME"] = "货位";
                    //_baseTable.Rows.Add(dr);

                    //dr = _baseTable.NewRow();
                    //dr["CODE"] = "BASE_SUPPLIER_PRICE";
                    //dr["NAME"] = "供应商单价";
                    //_baseTable.Rows.Add(dr);

                    //dr = _baseTable.NewRow();
                    //dr["CODE"] = "BASE_TAXATION";
                    //dr["NAME"] = "税率";
                    //_baseTable.Rows.Add(dr);

                    //dr = _baseTable.NewRow();
                    //dr["CODE"] = "BASE_USER";
                    //dr["NAME"] = "用户";
                    //_baseTable.Rows.Add(dr);

                }
                return CCacheData._baseTable;
            }
            set { CCacheData._baseTable = value; }
        }

        //是否标准件
        public static DataTable Distinction
        {
            get
            {
                if (_distinction == null)
                {
                    _distinction = new DataTable();
                    _distinction.Columns.Add("CODE", Type.GetType("System.String"));
                    _distinction.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _distinction.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "标准件";
                    _distinction.Rows.Add(dr);

                    dr = _distinction.NewRow();
                    dr["CODE"] = "2";
                    dr["NAME"] = "工序";
                    _distinction.Rows.Add(dr);
                }
                return CCacheData._distinction;
            }
            set { CCacheData._distinction = value; }
        }

        public static DataTable Receipt
        {
            get
            {
                if (_receipt == null)
                {
                    _receipt = new DataTable();
                    _receipt.Columns.Add("CODE", Type.GetType("System.String"));
                    _receipt.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _receipt.NewRow();
                    dr["CODE"] = 1;
                    dr["NAME"] = "采购入库";
                    _receipt.Rows.Add(dr);

                    dr = _receipt.NewRow();
                    dr["CODE"] = 2;
                    dr["NAME"] = "临时入库";
                    _receipt.Rows.Add(dr);
                }
                return CCacheData._receipt;
            }
            set { CCacheData._receipt = value; }
        }



        public static Hashtable Ht
        {
            get
            {
                if (_ht == null)
                {
                    _ht = new Hashtable();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("NO", Type.GetType("System.String"));
                    dt.Columns.Add("TABLE_FILED", Type.GetType("System.String"));
                    dt.Columns.Add("name", Type.GetType("System.String"));
                    dt.Columns.Add("SELECT", Type.GetType("System.String"));
                    DataRow dr = dt.NewRow();

                    #region  SLIP_TYPE
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "产线编号";
                    dr["name"] = "CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "产线名称";
                    dr["name"] = "NAME";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_SLIP_TYPE", dt.Copy());
                    #endregion

                    #region BASE_COMPOSITION_PRODUCTS
                    dt.Rows.Clear();
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "组成品编号";
                    dr["name"] = "CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "组成品名称";
                    dr["name"] = "NAME";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_COMPOSITION_PRODUCTS", dt.Copy());
                    #endregion

                    #region BASE_SLIP_TYPE_COMPOSITION_PRODUCTS
                    dt.Rows.Clear();
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "产线编号";
                    dr["name"] = "SLIP_TYPE_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "组成品编号";
                    dr["name"] = "COMPOSITION_PRODUCTS_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_SLIP_TYPE_COMPOSITION_PRODUCTS", dt.Copy());
                    #endregion

                    #region BASE_SPECIFICATION 规格
                    dt.Rows.Clear();
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "规格型号编号";
                    dr["name"] = "CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "规格型号名称";
                    dr["name"] = "NAME";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "3";
                    dr["TABLE_FILED"] = "规格";
                    dr["name"] = "SPEC";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "4";
                    dr["TABLE_FILED"] = "单位编号";
                    dr["name"] = "BASIC_UNIT_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "5";
                    dr["TABLE_FILED"] = "销售单价";
                    dr["name"] = "SALES_PRICE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_SPECIFICATION", dt.Copy());
                    #endregion

                    #region BASE_COMPOSITION_PRODUCTS_SPECIFICATION
                    dt.Rows.Clear();
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "组成品编号";
                    dr["name"] = "COMPOSITION_PRODUCTS_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "规格型号编号";
                    dr["name"] = "SPECIFICATION_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_COMPOSITION_PRODUCTS_SPECIFICATION", dt.Copy());
                    #endregion

                    #region 外购件种类 BASE_PRODUCT_GROUP
                    dt.Rows.Clear();
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "外购件种类编号";
                    dr["name"] = "CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "外购件种类名称";
                    dr["name"] = "NAME";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "3";
                    dr["TABLE_FILED"] = "默认供应商";
                    dr["name"] = "BASIC_SUPPLIER";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "4";
                    dr["TABLE_FILED"] = "供应商2";
                    dr["name"] = "SECOND_SUPPLIER_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "5";
                    dr["TABLE_FILED"] = "供应商3";
                    dr["name"] = "THIRD_SUPPLIER_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "6";
                    dr["TABLE_FILED"] = "上级种类编号";
                    dr["name"] = "PARENT_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_PRODUCT_GROUP", dt.Copy());
                    #endregion

                    #region BASE_PRODUCT 外购件
                    dt.Rows.Clear();
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "外购件编号";
                    dr["name"] = "CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "外购件名称";
                    dr["name"] = "NAME";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "3";
                    dr["TABLE_FILED"] = "外购件规格";
                    dr["name"] = "SPEC";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "4";
                    dr["TABLE_FILED"] = "外购件种类编号";
                    dr["name"] = "GROUP_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "5";
                    dr["TABLE_FILED"] = "外购件单位";
                    dr["name"] = "BASIC_UNIT_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "6";
                    dr["TABLE_FILED"] = "外购件销售价格";
                    dr["name"] = "SALES_PRICE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "7";
                    dr["TABLE_FILED"] = "外购件采购价格";
                    dr["name"] = "PURCHASE_PRICE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "8";
                    dr["TABLE_FILED"] = "外购件安全库存";
                    dr["name"] = "SAFETY_STOCK";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_PRODUCT", dt.Copy());
                    #endregion

                    #region BASE_PRODUCT_PARTS
                    dt.Rows.Clear();
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "规格型号编号";
                    dr["name"] = "PRODUCT_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "外购件编号";
                    dr["name"] = "PRODUCT_PARTS_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "3";
                    dr["TABLE_FILED"] = "数量";
                    dr["name"] = "QUANTITY";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_PRODUCT_PARTS", dt.Copy());
                    #endregion

                    #region 供应商 BASE_SUPPLIER
                    dt.Rows.Clear();
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "供应商编号";
                    dr["name"] = "CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "供应商名称";
                    dr["name"] = "NAME";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "3";
                    dr["TABLE_FILED"] = "简称";
                    dr["name"] = "NAME_SHORT";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "4";
                    dr["TABLE_FILED"] = "英文名称";
                    dr["name"] = "NAME_ENGLISH";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "5";
                    dr["TABLE_FILED"] = "邮编";
                    dr["name"] = "ZIP_CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "6";
                    dr["TABLE_FILED"] = "地址1";
                    dr["name"] = "ADDRESS_FIRST";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "7";
                    dr["TABLE_FILED"] = "地址2";
                    dr["name"] = "ADDRESS_MIDDLE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "8";
                    dr["TABLE_FILED"] = "电话1";
                    dr["name"] = "PHONE_NUMBER";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "9";
                    dr["TABLE_FILED"] = "电话2";
                    dr["name"] = "PHONE_NUMBER_LAST";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "10";
                    dr["TABLE_FILED"] = "传真1";
                    dr["name"] = "FAX_NUMBER";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "11";
                    dr["TABLE_FILED"] = "传真2";
                    dr["name"] = "FAX_NUMBER_LAST";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "12";
                    dr["TABLE_FILED"] = "联系人电话";
                    dr["name"] = "MOBIL_NUMBER";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "13";
                    dr["TABLE_FILED"] = "联系人名称";
                    dr["name"] = "CONTACT_NAME";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "14";
                    dr["TABLE_FILED"] = "邮箱";
                    dr["name"] = "EMAIL";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "15";
                    dr["TABLE_FILED"] = "网址";
                    dr["name"] = "URL";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "16";
                    dr["TABLE_FILED"] = "备注";
                    dr["name"] = "MEMO";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_SUPPLIER", dt.Copy());
                    #endregion

                    #region 单位
                    dt.Rows.Clear();
                    dr["NO"] = "1";
                    dr["TABLE_FILED"] = "编号";
                    dr["name"] = "CODE";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["NO"] = "2";
                    dr["TABLE_FILED"] = "名称";
                    dr["name"] = "NAME";
                    dr["SELECT"] = "";
                    dt.Rows.Add(dr);

                    _ht.Add("BASE_UNIT", dt.Copy());
                    #endregion
                }
                return CCacheData._ht;
            }
            set { CCacheData._ht = value; }
        }

        public static DataTable GetTableColumn(string tableName)
        {
            DataTable dt = (DataTable)Ht[tableName];
            return dt;
        }


        /// <summary>
        /// 所有常用输入内容
        /// </summary>
        public static DataTable BaseNames
        {
            get
            {
                if (_baseNames == null)
                {
                    _baseNames = bCommon.GetBaseNames("").Tables[0]; ;
                }
                return CCacheData._baseNames;
            }
            set { CCacheData._baseNames = value; }
        }

        /// <summary>
        /// 根据编号获得常用输入内容
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string[] GetBaseNamesData(string code)
        {

            DataRow[] rows = CCacheData.BaseNames.Select("CODE='" + code + "'");
            string[] str = new string[rows.Length];
            int i = 0;
            foreach (DataRow row in rows)
            {
                str[i++] = CConvert.ToString(row["NAME"]);
            }
            return str;
        }

        public static DataTable DrawingType
        {
            get
            {
                if (_drawingtype == null)
                {
                    _drawingtype = new DataTable();
                    _drawingtype.Columns.Add("CODE", Type.GetType("System.String"));
                    _drawingtype.Columns.Add("NAME", Type.GetType("System.String"));

                    DataRow dr = _drawingtype.NewRow();
                    dr["CODE"] = "1";
                    dr["NAME"] = "上模";
                    _drawingtype.Rows.Add(dr);

                    dr = _drawingtype.NewRow();
                    dr["CODE"] = "2";
                    dr["NAME"] = "下模";
                    _drawingtype.Rows.Add(dr);

                    dr = _drawingtype.NewRow();
                    dr["CODE"] = "3";
                    dr["NAME"] = "上钢圈";
                    _drawingtype.Rows.Add(dr);

                    dr = _drawingtype.NewRow();
                    dr["CODE"] = "4";
                    dr["NAME"] = "下钢圈";
                    _drawingtype.Rows.Add(dr);

                    dr = _drawingtype.NewRow();
                    dr["CODE"] = "5";
                    dr["NAME"] = "上夹盘";
                    _drawingtype.Rows.Add(dr);

                    dr = _drawingtype.NewRow();
                    dr["CODE"] = "6";
                    dr["NAME"] = "下夹盘";
                    _drawingtype.Rows.Add(dr);

                    dr = _drawingtype.NewRow();
                    dr["CODE"] = "7";
                    dr["NAME"] = "中圈";
                    _drawingtype.Rows.Add(dr);

                    dr = _drawingtype.NewRow();
                    dr["CODE"] = "8";
                    dr["NAME"] = "活络块";
                    _drawingtype.Rows.Add(dr);

                }
                return _drawingtype;
            }
            set { _drawingtype = value; }
        }
        //END CLASS
    }
}