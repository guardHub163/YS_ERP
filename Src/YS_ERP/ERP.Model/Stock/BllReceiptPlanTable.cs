using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllReceiptPlanTable
    {
        public BllReceiptPlanTable()
        { }
        #region Model
        private int _slip_number;
        private string _purchase_order_slip_number;
        private int _purchase_order_line_number;
        private DateTime? _slip_date;
        private string _slip_type;
        private string _order_slip_number;
        private string _supplier_order_number;
        private string _supplier_code;
        private string _receipt_warehouse_code;
        private DateTime? _due_date;
        private decimal _total_amount;
        private decimal _tax_rate;
        private string _currency_code;
        private string _packing_method;
        private string _payment_condition;
        private string _memo;
        private string _product_code;
        private decimal _quantity;
        private decimal _receipt_plan_quantity;
        private string _unit_code;
        private decimal _price;
        private decimal _amount_without_tax;
        private decimal _tax_amount;
        private decimal _amount_included_tax;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private string _company_code;
        /// <summary>
        /// 
        /// </summary>
        public int SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PURCHASE_ORDER_SLIP_NUMBER
        {
            set { _purchase_order_slip_number = value; }
            get { return _purchase_order_slip_number; }
        }
        /// <summary>
        /// 订单行号
        /// </summary>
        public int PURCHASE_ORDER_LINE_NUMBER
        {
            set { _purchase_order_line_number = value; }
            get { return _purchase_order_line_number; }
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
        /// 采购订单区分
        /// </summary>
        public string SLIP_TYPE
        {
            set { _slip_type = value; }
            get { return _slip_type; }
        }
        /// <summary>
        /// 销售订单编号
        /// </summary>
        public string ORDER_SLIP_NUMBER
        {
            set { _order_slip_number = value; }
            get { return _order_slip_number; }
        }
        /// <summary>
        /// 报价单号
        /// </summary>
        public string SUPPLIER_ORDER_NUMBER
        {
            set { _supplier_order_number = value; }
            get { return _supplier_order_number; }
        }
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string SUPPLIER_CODE
        {
            set { _supplier_code = value; }
            get { return _supplier_code; }
        }
        /// <summary>
        /// 入库仓库
        /// </summary>
        public string RECEIPT_WAREHOUSE_CODE
        {
            set { _receipt_warehouse_code = value; }
            get { return _receipt_warehouse_code; }
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
        public decimal TOTAL_AMOUNT
        {
            set { _total_amount = value; }
            get { return _total_amount; }
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
        /// 货币编号
        /// </summary>
        public string CURRENCY_CODE
        {
            set { _currency_code = value; }
            get { return _currency_code; }
        }
        /// <summary>
        /// 包装方式
        /// </summary>
        public string PACKING_METHOD
        {
            set { _packing_method = value; }
            get { return _packing_method; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PAYMENT_CONDITION
        {
            set { _payment_condition = value; }
            get { return _payment_condition; }
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
        /// 商品编号
        /// </summary>
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }
        /// <summary>
        /// 采购数量
        /// </summary>
        public decimal QUANTITY
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal RECEIPT_PLAN_QUANTITY
        {
            set { _receipt_plan_quantity = value; }
            get { return _receipt_plan_quantity; }
        }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UNIT_CODE
        {
            set { _unit_code = value; }
            get { return _unit_code; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal PRICE
        {
            set { _price = value; }
            get { return _price; }
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
        /// 含税金额
        /// </summary>
        public decimal AMOUNT_INCLUDED_TAX
        {
            set { _amount_included_tax = value; }
            get { return _amount_included_tax; }
        }
        /// <summary>
        /// 0:新采购订单  1: 全部入库  9:删除
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

        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }

        #endregion Model
    }
}
