using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseProductPartsTable
    {
        public BaseProductPartsTable()
        { }
        #region Model
        private string _product_code;
        private string _product_parts_code;
        private decimal? _quantity;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private string _product_name;
        private string _product_parts_name;
        private string _create_user_name;
        private string _last_update_user_name;

        /// <summary>
        /// 商品编号
        /// </summary>
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }
        /// <summary>
        /// 材料编号
        /// </summary>
        public string PRODUCT_PARTS_CODE
        {
            set { _product_parts_code = value; }
            get { return _product_parts_code; }
        }
        /// <summary>
        /// 组成数量
        /// </summary>
        public decimal? QUANTITY
        {
            set { _quantity = value; }
            get { return _quantity; }
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

        public string PRODUCT_NAME
        {
            set { _product_name = value; }
            get { return _product_name; }
        }

        public string PRODUCT_PARTS_NAME
        {
            set { _product_parts_name = value; }
            get { return _product_parts_name;}
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
