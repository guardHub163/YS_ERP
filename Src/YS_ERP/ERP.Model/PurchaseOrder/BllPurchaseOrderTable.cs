using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllPurchaseOrderTable
    {
        public BllPurchaseOrderTable()
        { }
        #region Model
        private string _slip_number;
        private DateTime _slip_date;
        private string _slip_type;
        private string _order_slip_number;
        private string _supplier_order_number;
        private string _supplier_code;
        private string _receipt_warehouse_code;
        private DateTime? _due_date;
        private decimal _total_amount;
        private decimal? _tax_rate;
        private string _currency_code;
        private string _packing_method;
        private string _payment_condition;
        private string _memo;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private string _company_code;

        private List<BllPurchaseOrderLineTable> _items = new List<BllPurchaseOrderLineTable>();

        /// <summary>
        /// 采购订单编号(系统按照设定规则自动产生)
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 采购订单日期
        /// </summary>
        public DateTime SLIP_DATE
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
        /// 金额
        /// </summary>
        public decimal TOTAL_AMOUNT
        {
            set { _total_amount = value; }
            get { return _total_amount; }
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

        /// <summary>
        /// 
        /// </summary>
        public List<BllPurchaseOrderLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddItem(BllPurchaseOrderLineTable model)
        {
            _items.Add(model);
        }

        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
        }

        #endregion Model
    }
}
