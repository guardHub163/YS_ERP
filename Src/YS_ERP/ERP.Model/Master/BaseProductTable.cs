using System;
using System.Collections.Generic;
using System.Text;
namespace CZZD.ERP.Model
{
    /// <summary>
    /// 商品信息
    /// </summary>
    [Serializable]
    public class BaseProductTable
    {
        public BaseProductTable()
        { }
        #region Model
        private string _code;
        private string _name;
        private string _spec;
        private string _model_number;
        private string _group_code;
        private string _basic_unit_code;
        private int _accouting_target;
        private string _product_accouting;
        private string _hs_code;
        private decimal _sales_price;
        private string _location_code;
        private int _stock_flag;
        private string _product_stock;
        private int _property_flag;
        private string _product_property;
        private int _fromset_flag;
        private int _mechanical_distinction_flag;
        private decimal _safety_stock;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private string _group_name;
        private string _basic_unit_name;
        private string _location_name;
        private string _hscode_name;
        private int _sell_location;
        private int _package_model;
        private string _name_jp;
        private decimal purchase_price;
        private string _supplier_code;
        private string _supplier_name;
        private int? _product_flag;
        private string _create_user_name;
        private string _last_update_user_name;     

        /// <summary>
        /// 采购价格
        /// </summary>
        public decimal PURCHASE_PRICE
        {
            get { return purchase_price; }
            set { purchase_price = value; }
        }

        /// <summary>
        /// 销售地点
        /// </summary>
        public int SELL_LOCATION
        {
            get { return _sell_location; }
            set { _sell_location = value; }
        }

        /// <summary>
        /// 包装方式
        /// </summary>
        public int PACKAGE_MODE
        {
            get { return _package_model; }
            set { _package_model = value; }
        }

        /// <summary>
        /// 日文名称
        /// </summary>
        public string NAME_JP
        {
            get { return _name_jp; }
            set { _name_jp = value; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string SPEC
        {
            set { _spec = value; }
            get { return _spec; }
        }
        /// <summary>
        /// 机器型号
        /// </summary>
        public string MODEL_NUMBER
        {
            set { _model_number = value; }
            get { return _model_number; }
        }
        /// <summary>
        /// 商品类别编号
        /// </summary>
        public string GROUP_CODE
        {
            set { _group_code = value; }
            get { return _group_code; }
        }
        /// <summary>
        /// 基本单位
        /// </summary>
        public string BASIC_UNIT_CODE
        {
            set { _basic_unit_code = value; }
            get { return _basic_unit_code; }
        }
        /// <summary>
        /// 原价计算对象 1: 就算对象 2 非计算对象
        /// </summary>
        public int ACCOUTING_TARGET
        {
            set { _accouting_target = value; }
            get { return _accouting_target; }
        }

        public string PRODUCT_ACCOUTING
        {
            set { _product_accouting = value; }
            get { return _product_accouting; }
        }

        /// <summary>
        /// 海关商品编号
        /// </summary>
        public string HS_CODE
        {
            set { _hs_code = value; }
            get { return _hs_code; }
        }

        public string HSCODE_NAME
        {
            set { _hscode_name = value; }
            get { return _hscode_name; }
        }

        /// <summary>
        /// 默认售价
        /// </summary>
        public decimal SALES_PRICE
        {
            set { _sales_price = value; }
            get { return _sales_price; }
        }
        /// <summary>
        /// 货位
        /// </summary>
        public string LOCATION_CODE
        {
            set { _location_code = value; }
            get { return _location_code; }
        }
        /// <summary>
        /// 在库Flag  1: 在库类 2：服务类（不Check库存）
        /// </summary>
        public int STOCK_FLAG
        {
            set { _stock_flag = value; }
            get { return _stock_flag; }
        }

        public string PRODUCT_STOCK
        {
            set { _product_stock = value; }
            get { return _product_stock; }
        }

        /// <summary>
        /// 1:组成品  2：材料
        /// </summary>
        public int PROPERTY_FLAG
        {
            set { _property_flag = value; }
            get { return _property_flag; }
        }

        public string PRODUCT_PROPERTY
        {
            set { _product_property = value; }
            get { return _product_property; }
        }

        /// <summary>
        /// 一式品flag   1:通常    2:一式品
        /// </summary>
        public int FROMSET_FLAG
        {
            set { _fromset_flag = value; }
            get { return _fromset_flag; }
        }
        /// <summary>
        /// 机械区分   1：机械本体           2：机械附件
        /// </summary>
        public int MECHANICAL_DISTINCTION_FLAG
        {
            set { _mechanical_distinction_flag = value; }
            get { return _mechanical_distinction_flag; }
        }

        /// <summary>
        /// 安全在库数
        /// </summary>
        public decimal SAFETY_STOCK
        {
            set { _safety_stock = value; }
            get { return _safety_stock; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        /// <summary>
        /// 创建人员
        /// </summary>
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }

        public string GROUP_NAME
        {
            set { _group_name = value; }
            get { return _group_name; }
        }

        public string BASIC_UNIT_NAME
        {
            set { _basic_unit_name = value; }
            get { return _basic_unit_name; }
        }

        public string LOCATION_NAME
        {
            set { _location_name = value; }
            get { return _location_name; }
        }

        public string SUPPLIER_CODE
        {
            set { _supplier_code = value; }
            get { return _supplier_code; }
        }

        public string SUPPLIER_NAME
        {
            set { _supplier_name = value; }
            get { return _supplier_name; }
        }
        /// <summary>
        /// 1:规格   2:外购件  3:自制件  4:原材料
        /// </summary>
        public int? PRODUCT_FLAG
        {
            set { _product_flag = value; }
            get { return _product_flag; }
        }

        public string CREATE_USER_NAME
        {
            get { return _create_user_name; }
            set { _create_user_name = value; }
        }

        public string LAST_UPDATE_USER_NAME
        {
            get { return _last_update_user_name; }
            set { _last_update_user_name = value; }
        }
        #endregion Model

    }
}

