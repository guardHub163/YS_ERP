using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllInventoryLineTable
    {
        public BllInventoryLineTable()
		{}
		#region Model
		private string _slip_number;
		private int _line_number;
		private string _product_code;
		private string _warehouse_code;
		private decimal? _stock_quantity;
		private decimal? _true_quantity;
		private int _status_flag=0;
		private string _create_user;
		private DateTime? _create_date_time;
		private DateTime? _last_update_time;
		private string _last_update_user;
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
		public int LINE_NUMBER
		{
			set{ _line_number=value;}
			get{return _line_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PRODUCT_CODE
		{
			set{ _product_code=value;}
			get{return _product_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WAREHOUSE_CODE
		{
			set{ _warehouse_code=value;}
			get{return _warehouse_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? STOCK_QUANTITY
		{
			set{ _stock_quantity=value;}
			get{return _stock_quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TRUE_QUANTITY
		{
			set{ _true_quantity=value;}
			get{return _true_quantity;}
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
		public string LAST_UPDATE_USER
		{
			set{ _last_update_user=value;}
			get{return _last_update_user;}
		}
		#endregion Model
    }
}
