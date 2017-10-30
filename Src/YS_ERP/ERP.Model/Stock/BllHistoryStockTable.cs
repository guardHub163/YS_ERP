using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllHistoryStockTable
    {
        public BllHistoryStockTable()
		{}
		#region Model
		private string _slip_number;
		private DateTime? _slip_date;
		private string _warehouse_code;
		private string _company_code;
		private int _status_flag=0;
		private string _create_user;
		private DateTime? _create_date_time;
		private DateTime? _last_update_time;
		private string _last_update_user;

        private List<BllHistoryStockLineTable> _items = new List<BllHistoryStockLineTable>();
		/// <summary>
		/// 库存编号
		/// </summary>
		public string SLIP_NUMBER
		{
			set{ _slip_number=value;}
			get{return _slip_number;}
		}
		/// <summary>
		/// 库存日期
		/// </summary>
		public DateTime? SLIP_DATE
		{
			set{ _slip_date=value;}
			get{return _slip_date;}
		}
		/// <summary>
		/// 仓库编号
		/// </summary>
		public string WAREHOUSE_CODE
		{
			set{ _warehouse_code=value;}
			get{return _warehouse_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string COMPANY_CODE
		{
			set{ _company_code=value;}
			get{return _company_code;}
		}
		/// <summary>
		/// 状态
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

        /// <summary>
        /// 
        /// </summary>
        public List<BllHistoryStockLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddItem(BllHistoryStockLineTable model)
        {
            _items.Add(model);
        }
		#endregion Model
    }
}
