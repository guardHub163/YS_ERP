using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseSafetyStockTable
    {
        public BaseSafetyStockTable()
        { }
        #region Model
        private string _warehouse_code;
        private string _product_code;
        private string _unit_code;
        private decimal? _safety_stock;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private string _warehouse_name;
        private string _product_name;
        private string _unit_name;
        private decimal? _min_purchase_quantity;
        private decimal? _max_quantity;

        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WAREHOUSE_CODE
        {
            set { _warehouse_code = value; }
            get { return _warehouse_code; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UNIT_CODE
        {
            set { _unit_code = value; }
            get { return _unit_code; }
        }
        /// <summary>
        /// 安全在库数量
        /// </summary>
        public decimal? SAFETY_STOCK
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

        public string WAREHOUSE_NAME
        {
            set { _warehouse_name = value; }
            get { return _warehouse_name; }
        }

        public string PRODUCT_NAME
        {
            set { _product_name = value; }
            get { return _product_name; }
        }

        public string UNIT_NAME
        {
            set { _unit_name = value; }
            get { return _unit_name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? MAX_QUANTITY
        {
            set { _max_quantity = value; }
            get { return _max_quantity; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? MIN_PURCHASE_QUANTITY
        {
            set { _min_purchase_quantity = value; }
            get { return _min_purchase_quantity; }
        }
        #endregion Model
    }
}
