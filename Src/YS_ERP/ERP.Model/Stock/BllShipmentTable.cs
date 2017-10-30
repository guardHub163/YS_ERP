using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllShipmentTable
    {
        public BllShipmentTable()
        { }
        #region Model
        private string _slip_number;
        private string _order_slip_number;
        private string _serial_number;
        private DateTime _slip_date;
        private DateTime _arrival_date;
        private decimal _amount;
        private string _currency_code;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime _create_date_time;
        private DateTime _last_update_time;
        private string _last_update_user;
        private List<BllShipmentLineTable> _items = new List<BllShipmentLineTable>();
        private decimal _amount_included_tax;
        private decimal _amount_without_tax;
        private decimal _tax_rate;
        private decimal _tax_amount;
        private string _company_code;
        private string _check_number;
        private string _customer_po_number;

        public string CHECK_NUMBER
        {
            get { return _check_number; }
            set { _check_number = value; }
        }


        public string CUSTOMER_PO_NUMBER
        {
            get { return _customer_po_number; }
            set { _customer_po_number = value; }
        }

        /// <summary>
        /// 公司编号
        /// </summary>
        public string COMPANY_CODE
        {
            get { return _company_code; }
            set { _company_code = value; }
        }
        /// <summary>
        /// 出库编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ORDER_SLIP_NUMBER
        {
            set { _order_slip_number = value; }
            get { return _order_slip_number; }
        }
        /// <summary>
        /// 机器序列号
        /// </summary>
        public string SERIAL_NUMBER
        {
            set { _serial_number = value; }
            get { return _serial_number; }
        }
        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }
        /// <summary>
        /// 交货期限
        /// </summary>
        public DateTime ARRIVAL_DATE
        {
            set { _arrival_date = value; }
            get { return _arrival_date; }
        }
        /// <summary>
        /// 出库总金额
        /// </summary>
        public decimal AMOUNT
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 货币编号
        /// </summary>
        public string CURRENCY_CODE
        {
            set { _currency_code = value; }
            get { return _currency_code; }
        }
        /// <summary>
        /// 0:出库  1: 已开发票  9:删除
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
        public List<BllShipmentLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 增加一条明细
        /// </summary>
        /// <param name="item"></param>
        public void AddItems(BllShipmentLineTable item) 
        {
            _items.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal AMOUNT_INCLUDED_TAX
        {
            set { _amount_included_tax = value; }
            get { return _amount_included_tax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal AMOUNT_WITHOUT_TAX
        {
            set { _amount_without_tax = value; }
            get { return _amount_without_tax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TAX_RATE
        {
            set { _tax_rate = value; }
            get { return _tax_rate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TAX_AMOUNT
        {
            set { _tax_amount = value; }
            get { return _tax_amount; }
        }
        #endregion Model
    }
}
