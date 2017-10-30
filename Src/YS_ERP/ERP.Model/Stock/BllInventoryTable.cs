using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllInventoryTable
    {
        public BllInventoryTable()
		{}
		#region Model
		private string _slip_number;
		private string _warehouse_code;
		private string _company_code;
		private DateTime _start_date;
		private DateTime _end_date;
		private int _statue_flag;
		private string _create_user;
		private DateTime? _create_date_time;
		private DateTime? _last_update_time;
		private string _last_update_user;

        List<BllInventoryLineTable> _items = new List<BllInventoryLineTable>();
		/// <summary>
		/// 盘点编号
		/// </summary>
		public string SLIP_NUMBER
		{
			set{ _slip_number=value;}
			get{return _slip_number;}
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
		/// 开始日期
		/// </summary>
		public DateTime START_DATE
		{
			set{ _start_date=value;}
			get{return _start_date;}
		}
		/// <summary>
		/// 结束日期
		/// </summary>
		public DateTime END_DATE
		{
			set{ _end_date=value;}
			get{return _end_date;}
		}
		/// <summary>
		/// 状态    0 ：开始     1  ： 盘点一部分    2  ：已完成 
		/// </summary>
		public int STATUE_FLAG
		{
			set{ _statue_flag=value;}
			get{return _statue_flag;}
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
        public List<BllInventoryLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddItem(BllInventoryLineTable model)
        {
            _items.Add(model);
        }

		#endregion Model
    }
}
