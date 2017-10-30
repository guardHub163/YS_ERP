using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllOrderHeaderTable
    {
        public BllOrderHeaderTable()
        { }
        #region Model
        private string _slip_number;
        private DateTime? _slip_date;
        private string _slip_type;
        private string _serial_number;
        private string _owner_po_number;
        private string _customer_po_number;
        private string _delivery_point_code;
        private string _customer_code;
        private string _ender_customer_code;
        private string _departual_warehouse_code;
        private DateTime? _departual_date;
        private DateTime? _due_date;
        private string _sales_employee_code;
        private int _attached_flag;
        private int _updated_count;
        private int _verify_flag;
        private string _currency_code;
        private string _currence_name;
        private decimal _order_deposit;
        private decimal _shipment_deposit;
        private string _company_code;
        private string _memo;
        private decimal _amount_included_tax;
        private decimal _amount_without_tax;
        private decimal _tax_amount;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private decimal _tax_rate;
        private int _alloation_flag;
        private string _customer_name;
        private string _ender_customer_name;
        private string _delivery_point_name;
        private string _departual_warehouse_name;
        private string _check_number;
        private DateTime? _check_date;
        private DateTime? _order_deposit_date;
        private DateTime? _order_shipment_deposit_date;
        private string _quotes_number;
        private int? _produce_flag;
        private decimal? _quantity;
        private string _ver;
        private string delivery__terms;
        private string _payment_terms;
        private decimal? _discount_rate;
        private decimal? _discount_amount;
        private string to_customer_memo;

        public string TO_CUSTOMER_MEMO
        {
            set { to_customer_memo = value; }
            get { return to_customer_memo; }
        }

        public decimal? DISCOUNT_AMOUNT
        {
            set { _discount_amount = value; }
            get { return _discount_amount; }
        }

        public decimal? DISCOUNT_RATE
        {
            set { _discount_rate = value; }
            get { return _discount_rate; }
        }

        public string DELIVERY_TERMS
        {
            set { delivery__terms = value; }
            get { return delivery__terms; }
        }
        public string PAYMENT_TERMS
        {
            set { _payment_terms = value; }
            get { return _payment_terms; }
        }

        public string VER
        {
            set { _ver = value; }
            get { return _ver; }
        }

        private List<BllOrderLineTable> _items = new List<BllOrderLineTable>();

        /// <summary>
        /// 订单编号(系统按照设定规则自动产生)
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 订单日期
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
        /// 机器序列号
        /// </summary>
        public string SERIAL_NUMBER
        {
            set { _serial_number = value; }
            get { return _serial_number; }
        }
        /// <summary>
        /// 自社订单编号
        /// </summary>
        public string OWNER_PO_NUMBER
        {
            set { _owner_po_number = value; }
            get { return _owner_po_number; }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string CUSTOMER_PO_NUMBER
        {
            set { _customer_po_number = value; }
            get { return _customer_po_number; }
        }
        /// <summary>
        /// 最终客户
        /// </summary>
        public string DELIVERY_POINT_CODE
        {
            set { _delivery_point_code = value; }
            get { return _delivery_point_code; }
        }
        /// <summary>
        /// 代理商
        /// </summary>
        public string CUSTOMER_CODE
        {
            set { _customer_code = value; }
            get { return _customer_code; }
        }
        /// <summary>
        /// 最终客户
        /// </summary>
        public string ENDER_CUSTOMER_CODE
        {
            set { _ender_customer_code = value; }
            get { return _ender_customer_code; }
        }
        /// <summary>
        /// 出库仓库
        /// </summary>
        public string DEPARTUAL_WAREHOUSE_CODE
        {
            set { _departual_warehouse_code = value; }
            get { return _departual_warehouse_code; }
        }
        /// <summary>
        /// 出库预定日
        /// </summary>
        public DateTime? DEPARTUAL_DATE
        {
            set { _departual_date = value; }
            get { return _departual_date; }
        }
        /// <summary>
        /// 交货期限
        /// </summary>
        public DateTime? DUE_DATE
        {
            set { _due_date = value; }
            get { return _due_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SALES_EMPLOYEE_CODE
        {
            set { _sales_employee_code = value; }
            get { return _sales_employee_code; }
        }
        /// <summary>
        /// 附件有无FLAG(0: 无附件  1:有附件)
        /// </summary>
        public int ATTACHED_FLAG
        {
            set { _attached_flag = value; }
            get { return _attached_flag; }
        }
        /// <summary>
        /// 更新次数(每次修改自动加1)
        /// </summary>
        public int UPDATED_COUNT
        {
            set { _updated_count = value; }
            get { return _updated_count; }
        }
        /// <summary>
        /// 0: 未承认 1：承认  
        /// </summary>
        public int VERIFY_FLAG
        {
            set { _verify_flag = value; }
            get { return _verify_flag; }
        }
        /// <summary>
        /// 货币编号
        /// </summary>
        public string CURRENCY_CODE
        {
            set { _currency_code = value; }
            get { return _currency_code; }
        }

        /// 默认货币编号
        /// </summary>
        public string CURRENCY_NAME
        {
            set { _currence_name = value; }
            get { return _currence_name; }
        }
        /// <summary>
        /// 订单预付款
        /// </summary>
        public decimal ORDER_DEPOSIT
        {
            set { _order_deposit = value; }
            get { return _order_deposit; }
        }
        /// <summary>
        /// 出库预付款
        /// </summary>
        public decimal SHIPMENT_DEPOSIT
        {
            set { _shipment_deposit = value; }
            get { return _shipment_deposit; }
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
        /// 订单备注
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 含税金额
        /// </summary>
        public decimal AMOUNT_INCLUDED_TAX
        {
            set { _amount_included_tax = value; }
            get { return _amount_included_tax; }
        }
        /// <summary>
        /// 不含税金额
        /// </summary>
        public decimal AMOUNT_WITHOUT_TAX
        {
            set { _amount_without_tax = value; }
            get { return _amount_without_tax; }
        }
        /// <summary>
        /// 税金
        /// </summary>
        public decimal TAX_AMOUNT
        {
            set { _tax_amount = value; }
            get { return _tax_amount; }
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
        public List<BllOrderLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddItem(BllOrderLineTable model)
        {
            _items.Add(model);
        }

        /// <summary>
        /// 税率
        /// </summary>
        public decimal TAX_RATE
        {
            set { _tax_rate = value; }
            get { return _tax_rate; }
        }

        /// <summary>
        /// 引当区分
        /// </summary>
        public int ALLOATION_FLAG
        {
            get { return _alloation_flag; }
            set { _alloation_flag = value; }
        }

        /// <summary>
        /// 代理店
        /// </summary>
        public string CUSTOMER_NAME
        {
            get { return _customer_name; }
            set { _customer_name = value; }
        }

        /// <summary>
        /// 需要家
        /// </summary>
        public string ENDER_CUSTOMER_NAME
        {
            get { return _ender_customer_name; }
            set { _ender_customer_name = value; }
        }

        /// <summary>
        /// 纳入先
        /// </summary>
        public string DELIVERY_POINT_NAME
        {
            get { return _delivery_point_name; }
            set { _delivery_point_name = value; }
        }

        /// <summary>
        /// 出库仓库
        /// </summary>
        public string DEPARTUAL_WAREHOUSE_NAME
        {
            get { return _departual_warehouse_name; }
            set { _departual_warehouse_name = value; }
        }

        /// <summary>
        /// 检查编号
        /// </summary>
        public string CHECK_NUMBER
        {
            get { return _check_number; }
            set { _check_number = value; }
        }

        /// <summary>
        /// 检查日期
        /// </summary>
        public DateTime? CHECK_DATE
        {
            get { return _check_date; }
            set { _check_date = value; }
        }

        public DateTime? ORDER_DEPOSIT_DATE
        {
            set { _order_deposit_date = value; }
            get { return _order_deposit_date; }
        }

        public DateTime? ORDER_SHIPMENT_DEPOSIT_DATE
        {
            set { _order_shipment_deposit_date = value; }
            get { return _order_shipment_deposit_date; }
        }

        public string QUOTES_NUMBER
        {
            get { return _quotes_number; }
            set { _quotes_number = value; }
        }
        /// <summary>
        /// 生产FLAG  1：未生产    2 ：生产
        /// </summary>
        public int? PRODUCE_FLAG
        {
            set { _produce_flag = value; }
            get { return _produce_flag; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? QUANTITY
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        #endregion Model
    }//end class
}
