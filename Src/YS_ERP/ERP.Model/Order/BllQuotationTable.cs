using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllQuotationTable
    {
        public BllQuotationTable()
        { }

        #region Model
        private string _slip_number;
        private DateTime? _slip_date;
        private string _slip_type;
        private string _customer_code;
        private string _customer_name;
        private string _departual_warehouse_code;
        private string _warehouse_name;
        private string _sales_employee_code;
        private decimal? _quantity;
        private string _currency_code;
        private string _currency_name;
        private string _company_code;
        private decimal? _amount_included_tax;
        private decimal? _amount_without_tax;
        private decimal? _tax_rate;
        private decimal? _tax_amount;
        private string _payment_condition;
        private string _memo;
        private int? _order_flag = 0;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private decimal? _discount_rate;
        private string _enquiry_method;
        private DateTime? _enquiry_date;
        private string _delivery_period;
        private string _delivery_terms;
        private string _payment_terms;
        private decimal? _discount_amout;
        private string _ver;
        private int? _update_count = 0;
        private string to_customer_memo;

        private List<BllQuotationLineTable> _items = new List<BllQuotationLineTable>();

        public string TO_CUSTOMER_MEMO
        {
            set { to_customer_memo = value; }
            get { return to_customer_memo; }
        }        

        public int? UPDATE_COUNT
        {
            set { _update_count = value; }
            get { return _update_count; }
        }

        public string VER
        {
            set { _ver = value; }
            get { return _ver; }
        }
        
        public decimal? DISCOUNT_RATE
        {
            set { _discount_rate = value; }
            get { return _discount_rate; }
        }

        public string ENQUIRY_METHOD
        {
            set { _enquiry_method = value; }
            get { return _enquiry_method; }
        }
        public DateTime? ENQUIRY_DATE
        {
            set { _enquiry_date = value; }
            get { return _enquiry_date; }
        }

        public string DELIVERY_PERIOD
        {
            set { _delivery_period = value; }
            get { return _delivery_period; }
        }
        public string DELIVERY_TERMS
        {
            set { _delivery_terms = value; }
            get { return _delivery_terms; }
        }

        public string PAYMENT_TERMS
        {
            set { _payment_terms = value; }
            get { return _payment_terms; }
        }

        public decimal? DISCOUNT_AMOUNT
        {
            set { _discount_amout = value; }
            get { return _discount_amout; }
        }

        /// <summary>
        /// 订单编号(系统按照设定规则自动产生)
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 报价日期　
        /// </summary>
        public DateTime? SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }
        /// <summary>
        /// 订单区分
        /// </summary>
        public string SLIP_TYPE
        {
            set { _slip_type = value; }
            get { return _slip_type; }
        }

        /// <summary>
        /// 客户
        /// </summary>
        public string CUSTOMER_CODE
        {
            set { _customer_code = value; }
            get { return _customer_code; }
        }

        public string CUSTOMER_NAME
        {
            set { _customer_name = value; }
            get { return _customer_name; }
        }

        /// <summary>
        /// 出库仓库
        /// </summary>
        public string DEPARTUAL_WAREHOUSE_CODE
        {
            set { _departual_warehouse_code = value; }
            get { return _departual_warehouse_code; }
        }

        public string WAREHOUSE_NAME
        {
            set { _warehouse_name = value; }
            get { return _warehouse_name; }
        }


        /// <summary>
        /// 营业担当者
        /// </summary>
        public string SALES_EMPLOYEE_CODE
        {
            set { _sales_employee_code = value; }
            get { return _sales_employee_code; }
        }


        /// <summary>
        /// 
        /// </summary>
        public decimal? QUANTITY
        {
            set { _quantity = value; }
            get { return _quantity; }
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
        /// 货币编号
        /// </summary>
        public string CURRENCY_NAME
        {
            set { _currency_name = value; }
            get { return _currency_name; }
        }

        /// <summary>
        /// 公司编号
        /// </summary>
        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }
        /// <summary>
        /// 含税金额
        /// </summary>
        public decimal? AMOUNT_INCLUDED_TAX
        {
            set { _amount_included_tax = value; }
            get { return _amount_included_tax; }
        }
        /// <summary>
        /// 不含税金额
        /// </summary>
        public decimal? AMOUNT_WITHOUT_TAX
        {
            set { _amount_without_tax = value; }
            get { return _amount_without_tax; }
        }
        /// <summary>
        /// 税率
        /// </summary>
        public decimal? TAX_RATE
        {
            set { _tax_rate = value; }
            get { return _tax_rate; }
        }
        /// <summary>
        /// 税金
        /// </summary>
        public decimal? TAX_AMOUNT
        {
            set { _tax_amount = value; }
            get { return _tax_amount; }
        }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }

        /// <summary>
        /// 是否生产销售订单: 1. 未生产销售订单   2.生成销售订单
        /// </summary>
        public int? ORDER_FLAG
        {
            set { _order_flag = value; }
            get { return _order_flag; }
        }

        /// <summary>
        /// 0:新订单  1: 全部出库  9:删除
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        /// <summary>
        /// 创建人员　作成担当者
        /// </summary>
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 作成時間
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 最終更新時間
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        /// <summary>
        /// 最終更新担当者
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }

        public List<BllQuotationLineTable> Items
        {
            set { _items = value; }
            get { return _items; }
        }

        public void AddItem(BllQuotationLineTable model)
        {
            _items.Add(model);
        }

        /// <summary>
        /// 
        /// </summary>
        public string PAYMENT_CONDITION
        {
            set { _payment_condition = value; }
            get { return _payment_condition; }
        }
        #endregion Model
    }
}
