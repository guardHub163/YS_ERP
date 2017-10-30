using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    /// <summary>
    /// BllOrderServiceTable:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllOrderServiceTable
	{
        public BllOrderServiceTable()
		{}
		#region Model
		private int _id;
		private string _slip_number;
		private DateTime? _start_date_time;
		private DateTime? _end_date_time;
		private string _service_user;
		private string _memo;
		private int _status_flag;
		private string _create_user;
		private DateTime? _create_date_time;
		private string _last_update_user;
		private DateTime? _last_update_time;
        private string _title;

       
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SLIP_NUMBER
		{
			set{ _slip_number=value;}
			get{return _slip_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? START_DATE_TIME
		{
			set{ _start_date_time=value;}
			get{return _start_date_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? END_DATE_TIME
		{
			set{ _end_date_time=value;}
			get{return _end_date_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SERVICE_USER
		{
			set{ _service_user=value;}
			get{return _service_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MEMO
		{
			set{ _memo=value;}
			get{return _memo;}
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
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LAST_UPDATE_TIME
		{
			set{ _last_update_time=value;}
			get{return _last_update_time;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string TITLE
        {
            get { return _title; }
            set { _title = value; }
        }
		#endregion Model

	}
}
