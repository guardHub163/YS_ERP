using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllHistoryStockLineTable
    {
        public BllHistoryStockLineTable()
		{}
		#region Model
		private string _slip_number;
		private int _line_number;
		private string _product_code;
		private decimal? _quantity;
		private string _unit_code;
		private string _reason_code;
		private int _status_flag=0;
		/// <summary>
		/// 库存编号
		/// </summary>
		public string SLIP_NUMBER
		{
			set{ _slip_number=value;}
			get{return _slip_number;}
		}
		/// <summary>
		/// 在库商品行号
		/// </summary>
		public int LINE_NUMBER
		{
			set{ _line_number=value;}
			get{return _line_number;}
		}
		/// <summary>
		/// 商品编号
		/// </summary>
		public string PRODUCT_CODE
		{
			set{ _product_code=value;}
			get{return _product_code;}
		}
		/// <summary>
		/// 修改数量
		/// </summary>
		public decimal? QUANTITY
		{
			set{ _quantity=value;}
			get{return _quantity;}
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
		/// 
		/// </summary>
		public string REASON_CODE
		{
			set{ _reason_code=value;}
			get{return _reason_code;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int STATUS_FLAG
		{
			set{ _status_flag=value;}
			get{return _status_flag;}
		}
		#endregion Model
    }
}
