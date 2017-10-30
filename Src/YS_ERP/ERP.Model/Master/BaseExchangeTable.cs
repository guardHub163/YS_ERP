using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseExchangeTable
    {
        public BaseExchangeTable()
        { }
        #region Model
        private DateTime _exchange_date;
        private string _from_currency_code;
        private string _from_currency_name;
        private string _to_currency_code;
        private decimal _exchange_rate;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime _create_date_time;
        private string _last_update_user;
        private DateTime _last_update_time;
        /// <summary>
        /// 汇率日期
        /// </summary>
        public DateTime EXCHANGE_DATE
        {
            set { _exchange_date = value; }
            get { return _exchange_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FROM_CURRENCY_CODE
        {
            set { _from_currency_code = value; }
            get { return _from_currency_code; }
        }

        public string FROM_CURRENCY_NAME
        {
            set { _from_currency_name = value; }
            get { return _from_currency_name; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TO_CURRENCY_CODE
        {
            set { _to_currency_code = value; }
            get { return _to_currency_code; }
        }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal EXCHANGE_RATE
        {
            set { _exchange_rate = value; }
            get { return _exchange_rate; }
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
        public DateTime CREATE_DATE_TIME
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
        public DateTime LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        #endregion Model
    }
}
