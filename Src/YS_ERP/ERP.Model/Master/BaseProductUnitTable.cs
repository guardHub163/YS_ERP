﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseProductUnitTable
    {
        public BaseProductUnitTable()
		{}
		#region Model
		private string _product_code;
		private string _unit_code;
		private int? _basic_flag;
        private string _unit_basic;
		private int _status_flag=1;
		private string _create_user;
		private DateTime? _create_date_time;
		private string _last_update_user;
		private DateTime? _last_update_time;
        private string _product_name;
        private string _unit_name;
		/// <summary>
		/// 商品编号
		/// </summary>
		public string PRODUCT_CODE
		{
			set{ _product_code=value;}
			get{return _product_code;}
		}
		/// <summary>
		/// 单位编号
		/// </summary>
		public string UNIT_CODE
		{
			set{ _unit_code=value;}
			get{return _unit_code;}
		}
		/// <summary>
		/// 基础单位Flag  1：基础单位 2：非基础单位
		/// </summary>
		public int? BASIC_FLAG
		{
			set{ _basic_flag=value;}
			get{return _basic_flag;}
		}

        public string UNIT_BASIC
        {
            set { _unit_basic = value; }
            get { return _unit_basic; }
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

        public string PRODUCT_NAME
        {
            set { _product_name = value;}
            get {return _product_name;}
        }

        public string UNIT_NAME
        {
            set { _unit_name = value; }
            get { return _unit_name; }
        }

		#endregion Model
    }
}
