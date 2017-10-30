using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllSalesTable
    {
        public BllSalesTable()
		{}
		#region Model
		private string _slip_number;
		private string _customer_claim_code;
		private string _invoice_number;
		private DateTime _slip_date;
		private DateTime _customer_claim_date;
		private decimal _invoice_amount;
		private int _status_flag=0;
		private string _create_user;
		private DateTime _create_date_time;
		private DateTime _last_update_time;
		private string _last_update_user;
        private string _company_code;
        private string _customer_claim_name;

        public string CUSTOMER_CLAIM_NAME
        {
            get { return _customer_claim_name; }
            set { _customer_claim_name = value; }
        }

        private List<BllSalesLineTable> _items = new List<BllSalesLineTable>();

        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }
		/// <summary>
		/// 销售发票内部编号
		/// </summary>
		public string SLIP_NUMBER
		{
			set{ _slip_number=value;}
			get{return _slip_number;}
		}
		/// <summary>
		/// 请款公司编号
		/// </summary>
		public string CUSTOMER_CLAIM_CODE
		{
			set{ _customer_claim_code=value;}
			get{return _customer_claim_code;}
		}
		/// <summary>
		/// 发票编号
		/// </summary>
		public string INVOICE_NUMBER
		{
			set{ _invoice_number=value;}
			get{return _invoice_number;}
		}
		/// <summary>
		/// 开票日期
		/// </summary>
		public DateTime SLIP_DATE
		{
			set{ _slip_date=value;}
			get{return _slip_date;}
		}
		/// <summary>
		/// 收款预定日期
		/// </summary>
		public DateTime CUSTOMER_CLAIM_DATE
		{
			set{ _customer_claim_date=value;}
			get{return _customer_claim_date;}
		}
		/// <summary>
		/// 不含税金额
		/// </summary>
		public decimal INVOICE_AMOUNT
		{
			set{ _invoice_amount=value;}
			get{return _invoice_amount;}
		}
		/// <summary>
		/// 0:未收款发票  1: 全部收款 2：部分收款  9:删除
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
		public DateTime CREATE_DATE_TIME
		{
			set{ _create_date_time=value;}
			get{return _create_date_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime LAST_UPDATE_TIME
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
        /// 明细的集合
        /// </summary>
        public List<BllSalesLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }		

        public void AddItems(BllSalesLineTable line)
        {
            _items.Add(line);
        }
        #endregion Model
    }
}
