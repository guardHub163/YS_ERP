using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseDepartmentTable
    {
        public BaseDepartmentTable()
		{}
		#region Model
		private string _code;
		private string _name;
		private string _parent_code;
		private string _company_code;
		private int _status_flag=1;
		private string _create_user;
		private DateTime? _create_date_time;
		private string _last_update_user;
		private DateTime? _last_update_time;
        private string _parent_name;
        private string _company_name;
		/// <summary>
		/// 部门编号
		/// </summary>
		public string CODE
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 上级部门编号
		/// </summary>
		public string PARENT_CODE
		{
			set{ _parent_code=value;}
			get{return _parent_code;}
		}
		/// <summary>
		/// 公司编号
		/// </summary>
		public string COMPANY_CODE
		{
			set{ _company_code=value;}
			get{return _company_code;}
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
		/// 创建人员
		/// </summary>
		public string CREATE_USER
		{
			set{ _create_user=value;}
			get{return _create_user;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CREATE_DATE_TIME
		{
			set{ _create_date_time=value;}
			get{return _create_date_time;}
		}
		/// <summary>
		/// 最后更新人员
		/// </summary>
		public string LAST_UPDATE_USER
		{
			set{ _last_update_user=value;}
			get{return _last_update_user;}
		}
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime? LAST_UPDATE_TIME
		{
			set{ _last_update_time=value;}
			get{return _last_update_time;}
		}

        public string PARENT_NAME
        {
            set { _parent_name = value; }
            get { return _parent_name; }
        }

        public string COMPANY_NAME
        {
            set { _company_name = value; }
            get { return _company_name; }
        }

		#endregion Model

    }
}
