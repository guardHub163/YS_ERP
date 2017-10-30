using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseDeliveryTable
    {
        public BaseDeliveryTable()
        { }
        #region Model
        private string _customer_code;
        private string _delivery_code;
        private string _address_first;
        private string _address_middle;
        private string _address_last;
        private string _zip_code;
        private string _phone_number;
        private string _fax_number;
        private string _mobil_number;
        private string _contact_name;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CUSTOMER_CODE
        {
            set { _customer_code = value; }
            get { return _customer_code; }
        }
        /// <summary>
        /// 地址编号
        /// </summary>
        public string DELIVERY_CODE
        {
            set { _delivery_code = value; }
            get { return _delivery_code; }
        }
        /// <summary>
        /// 地址1
        /// </summary>
        public string ADDRESS_FIRST
        {
            set { _address_first = value; }
            get { return _address_first; }
        }
        /// <summary>
        /// 地址2
        /// </summary>
        public string ADDRESS_MIDDLE
        {
            set { _address_middle = value; }
            get { return _address_middle; }
        }
        /// <summary>
        /// 地址3
        /// </summary>
        public string ADDRESS_LAST
        {
            set { _address_last = value; }
            get { return _address_last; }
        }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZIP_CODE
        {
            set { _zip_code = value; }
            get { return _zip_code; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string PHONE_NUMBER
        {
            set { _phone_number = value; }
            get { return _phone_number; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string FAX_NUMBER
        {
            set { _fax_number = value; }
            get { return _fax_number; }
        }
        /// <summary>
        /// 联系人手机
        /// </summary>
        public string MOBIL_NUMBER
        {
            set { _mobil_number = value; }
            get { return _mobil_number; }
        }
        /// <summary>
        /// 客户联系人
        /// </summary>
        public string CONTACT_NAME
        {
            set { _contact_name = value; }
            get { return _contact_name; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        /// <summary>
        /// 创建人
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
        /// 更新人
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        #endregion Model
    }
}
