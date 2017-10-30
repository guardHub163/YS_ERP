using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllReReceiptTable
    {
        public BllReReceiptTable()
		{}
		#region Model
        private string _slip_number;
        private string _po_slip_number;
        private DateTime? _slip_date;
        private string _receipt_warehouse_code;
        private string _currency_code;
        private string _supplier_code;
        private decimal? _tax_rate;
        private decimal? _tax_amount;
        private decimal? _amount_without_tax;
        private decimal? _amount_included_tax;
        private string _company_code;
        private int? _rereceipt_flag;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private List<BllReReceiptLineTable> _items = new List<BllReReceiptLineTable>();
        /// <summary>
        /// 
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PO_SLIP_NUMBER
        {
            set { _po_slip_number = value; }
            get { return _po_slip_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RECEIPT_WAREHOUSE_CODE
        {
            set { _receipt_warehouse_code = value; }
            get { return _receipt_warehouse_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CURRENCY_CODE
        {
            set { _currency_code = value; }
            get { return _currency_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SUPPLIER_CODE
        {
            set { _supplier_code = value; }
            get { return _supplier_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TAX_RATE
        {
            set { _tax_rate = value; }
            get { return _tax_rate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? TAX_AMOUNT
        {
            set { _tax_amount = value; }
            get { return _tax_amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AMOUNT_WITHOUT_TAX
        {
            set { _amount_without_tax = value; }
            get { return _amount_without_tax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AMOUNT_INCLUDED_TAX
        {
            set { _amount_included_tax = value; }
            get { return _amount_included_tax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }
        /// <summary>
        /// 返品区别 : 1.采购返品  2.生产返品
        /// </summary>
        public int? RERECEIPT_FLAG
        {
            set { _rereceipt_flag = value; }
            get { return _rereceipt_flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<BllReReceiptLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddItem(BllReReceiptLineTable model)
        {
            _items.Add(model);
        }
		#endregion Model
    }
}
