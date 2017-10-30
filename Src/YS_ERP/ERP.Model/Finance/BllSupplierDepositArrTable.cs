using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    /// <summary>
	/// BLL_SUPPLIER_DEPOSIT_ARR:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class BllSupplierDepositArrTable
	{
        public BllSupplierDepositArrTable()
		{}
		#region Model
		private string _slip_number;
		private DateTime? _slip_date;
		private string _supplier_code;
		private int _status_flag=0;
		private string _create_user;
		private DateTime? _create_date_time;
		private DateTime? _last_update_time;
		private string _last_update_user;
		private string _company_code;
        private List<BllSupplierDepositArrLineTable> lineTables = new List<BllSupplierDepositArrLineTable>();
		/// <summary>
		/// 预付款分配编号
		/// </summary>
		public string SLIP_NUMBER
		{
			set{ _slip_number=value;}
			get{return _slip_number;}
		}
		/// <summary>
		/// 预付款分配日期
		/// </summary>
		public DateTime? SLIP_DATE
		{
			set{ _slip_date=value;}
			get{return _slip_date;}
		}
		/// <summary>
		/// 供应商编号
		/// </summary>
		public string SUPPLIER_CODE
		{
			set{ _supplier_code=value;}
			get{return _supplier_code;}
		}
		/// <summary>
		/// 状态　９：删除
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
		/// 预付款分配人所属公司
		/// </summary>
		public string COMPANY_CODE
		{
			set{ _company_code=value;}
			get{return _company_code;}
		}

        /// <summary>
        /// 配分明细
        /// </summary>
        public List<BllSupplierDepositArrLineTable> LineTable
        {
            get
            {
                return lineTables;
            }
            set
            {
                lineTables = value;
            }
        }

        /// <summary>
        /// 配分明细
        /// </summary>
        public void addLineTable(BllSupplierDepositArrLineTable lineTable)
        {
            lineTables.Add(lineTable);
        }
		#endregion Model
	}


    /// <summary>
    /// BLL_SUPPLIER_DEPOSIT_ARR_LINE:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BllSupplierDepositArrLineTable
    {
        public BllSupplierDepositArrLineTable()
        { }
        #region Model
        private string _slip_number;
        private int _line_number;
        private string _purchase_order_slip_number;
        private decimal? _arr_amount;
        private string _memo;
        private int _status_flag = 0;
        /// <summary>
        /// 预付款分配内部编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 预付款明细编号
        /// </summary>
        public int LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
        }
        /// <summary>
        /// 预付款支付的采购订单
        /// </summary>
        public string PURCHASE_ORDER_SLIP_NUMBER
        {
            set { _purchase_order_slip_number = value; }
            get { return _purchase_order_slip_number; }
        }
        /// <summary>
        /// 预付款分配金额
        /// </summary>
        public decimal? ARR_AMOUNT
        {
            set { _arr_amount = value; }
            get { return _arr_amount; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 状态　9:删除
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        #endregion Model

    }

}
