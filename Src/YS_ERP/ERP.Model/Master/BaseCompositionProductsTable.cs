using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    /// <summary>
    /// BaseCompositionProductsTable:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BaseCompositionProductsTable
    {
        public BaseCompositionProductsTable()
		{}
		#region Model
		private string _code;
		private string _name;
		private string _company_code;
        private string _company_name;
		private int _status_flag=0;
		private string _create_user;
        private string _create_name;
		private DateTime? _create_date_time;
		private string _last_update_user;
        private string _last_update_name;
		private DateTime? _last_update_time;
        private int _order;

        /// <summary>
        /// 
        /// </summary>
        public int ORDER
        {
            set { _order = value; }
            get { return _order; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string CODE
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string COMPANY_CODE
		{
			set{ _company_code=value;}
			get{return _company_code;}
		}
        public string COMPANY_NAME
        {
            set { _company_name = value; }
            get { return _company_name; }
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
        public string CREATE_NAME
        {
            set { _create_name = value; }
            get { return _create_name; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CREATE_DATE_TIME
		{
			set{ _create_date_time=value;}
			get{return _create_date_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LAST_UPDATE_USER
		{
			set{ _last_update_user=value;}
			get{return _last_update_user;}
		}

        public string LAST_UPDATE_NAME
        {
            set { _last_update_name = value; }
            get { return _last_update_name; }
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
