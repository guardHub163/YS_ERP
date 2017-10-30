using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllPurchaseTable
    {
        public BllPurchaseTable()
        { }
        #region Model
        private string _slip_number;
        private string _supplier_code;
        private string _invoice_number;
        private string _invoice_number_local;
        private DateTime _slip_date;
        private DateTime _payment_date;
        private decimal _invoice_amount;
        private decimal _invoice_amount_local;
        private decimal _packing_amount;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime _create_date_time;
        private DateTime _last_update_time;
        private string _last_update_user;

        private string _company_code;

        private List<BllPurchaseLineTable> _items = new List<BllPurchaseLineTable>();

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
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 付款公司编号
        /// </summary>
        public string SUPPLIER_CODE
        {
            set { _supplier_code = value; }
            get { return _supplier_code; }
        }
        /// <summary>
        /// 国外发票编号
        /// </summary>
        public string INVOICE_NUMBER
        {
            set { _invoice_number = value; }
            get { return _invoice_number; }
        }
        /// <summary>
        /// 国内发票编号
        /// </summary>
        public string INVOICE_NUMBER_LOCAL
        {
            set { _invoice_number_local = value; }
            get { return _invoice_number_local; }
        }
        /// <summary>
        /// 开票日期
        /// </summary>
        public DateTime SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }
        /// <summary>
        /// 付款预定日期
        /// </summary>
        public DateTime PAYMENT_DATE
        {
            set { _payment_date = value; }
            get { return _payment_date; }
        }
        /// <summary>
        /// 国外发票金额
        /// </summary>
        public decimal INVOICE_AMOUNT
        {
            set { _invoice_amount = value; }
            get { return _invoice_amount; }
        }
        /// <summary>
        /// 国内发票金额
        /// </summary>
        public decimal INVOICE_AMOUNT_LOCAL
        {
            set { _invoice_amount_local = value; }
            get { return _invoice_amount_local; }
        }
        /// <summary>
        /// 包装费金额
        /// </summary>
        public decimal PACKING_AMOUNT
        {
            set { _packing_amount = value; }
            get { return _packing_amount; }
        }
        /// <summary>
        /// 0:未付款发票  1: 全部付款 2：部分付款  9:删除
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        /// <summary>
        /// 创建人员
        /// </summary>
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LAST_UPDATE_TIME
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
        /// 明细的集合
        /// </summary>
        public List<BllPurchaseLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public void AddItems(BllPurchaseLineTable line)
        {
            _items.Add(line);
        }
        #endregion Model
    }
}
