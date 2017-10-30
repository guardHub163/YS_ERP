using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseSupplierPriceTable
    {
        public BaseSupplierPriceTable()
        { }
        #region Model
        private string _supplier_code;
        private string _product_code;
        private string _unit_code;
        private string _currency_code;
        private decimal? _price;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private string _supplier_name;
        private string _product_name;
        private string _unit_name;
        private string _currency_name;
        /// <summary>
        /// 供应商编号
        /// </summary>
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
        /// 商品编号
        /// </summary>
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }

        public string PRODUCT_NAME
        {
            set { _product_name = value; }
            get { return _product_name; }
        }

        /// <summary>
        /// 单位编号
        /// </summary>
        public string UNIT_CODE
        {
            set { _unit_code = value; }
            get { return _unit_code; }
        }

        public string UNIT_NAME
        {
            set { _unit_name = value; }
            get { return _unit_name; }
        }

        /// <summary>
        /// 货币编号
        /// </summary>
        public string CURRENCY_CODE
        {
            set { _currency_code = value; }
            get { return _currency_code; }
        }

        public string CURRENCY_NAME
        {
            set { _currency_name = value; }
            get { return _currency_name; }
        }

        /// <summary>
        /// 采购价格
        /// </summary>
        public decimal? PRICE
        {
            set { _price = value; }
            get { return _price; }
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
        /// 
        /// </summary>
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        #endregion Model
    }
}
