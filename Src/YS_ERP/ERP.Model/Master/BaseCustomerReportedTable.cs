using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseCustomerReportedTable
    {
        public BaseCustomerReportedTable()
		{}
		#region Model
		private string _customer_code;
		private string _customer_reported_code;
		private DateTime _reported_date;
		private int _status_flag=1;
		private string _create_user;
		private DateTime _create_date;
		private string _last_update_user;
		private DateTime? _last_update_time;
        private DateTime _effective_date;

        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime EFFECTIVE_DATE
        {
            set { _effective_date = value; }
            get { return _effective_date; }
        }
		/// <summary>
		/// 代理店
		/// </summary>
		public string CUSTOMER_CODE
		{
			set{ _customer_code=value;}
			get{return _customer_code;}
		}
		/// <summary>
		/// 报备客户名称
		/// </summary>
		public string CUSTOMER_REPORTED_CODE
		{
			set{ _customer_reported_code=value;}
			get{return _customer_reported_code;}
		}
		/// <summary>
		/// 报备日期
		/// </summary>
		public DateTime REPORTED_DATE
		{
			set{ _reported_date=value;}
			get{return _reported_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int STATUS_FLAG
		{
			set{ _status_flag=value;}
			get{return _status_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CREATE_USER
		{
			set{ _create_user=value;}
			get{return _create_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CREATE_DATE
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LAST_UPDATE_USER
		{
			set{ _last_update_user=value;}
			get{return _last_update_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LAST_UPDATE_TIME
		{
			set{ _last_update_time=value;}
			get{return _last_update_time;}
		}
		#endregion Model
    }
}
