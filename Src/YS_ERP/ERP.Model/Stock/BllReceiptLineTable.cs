using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllReceiptLineTable
    {
        public BllReceiptLineTable()
        { }
        #region Model
        private string _slip_number;
        private int _line_number;
        private int _receipt_plan_number;
        private DateTime? _slip_date;
        private string _invoice_number;
        private string _receipt_warehouse_code;
        private string _product_code;
        private decimal _quantity;
        private string _unit_code;
        private decimal _price;
        private decimal _amount_without_tax;
        private decimal _tax_amount;
        private decimal _amount_included_tax;
        private int _status_flag = 0;

        private string _supplier_code;

        public string SUPPLIER_CODE
        {
            get { return _supplier_code; }
            set { _supplier_code = value; }
        }


        private decimal _tax_rate;

        public decimal TAX_RATE
        {
            get { return _tax_rate; }
            set { _tax_rate = value; }
        }
        private string _currency_code;

        public string CURRENCY_CODE
        {
            get { return _currency_code; }
            set { _currency_code = value; }
        }

        /// <summary>
        /// 入库编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 入库行号
        /// </summary>
        public int LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
        }

        public int RECEIPT_PLAN_NUMBER
        {
            set { _receipt_plan_number = value; }
            get { return _receipt_plan_number; }
        }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }
        /// <summary>
        /// 单位编号
        /// </summary>
        public string INVOICE_NUMBER
        {
            set { _invoice_number = value; }
            get { return _invoice_number; }
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
        /// 商品编号
        /// </summary>
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }
        /// <summary>
        /// 入库数量
        /// </summary>
        public decimal QUANTITY
        {
            set { _quantity = value; }
            get { return _quantity; }
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
        /// 0:新入库单  1:已开票  2：部分开票 9:删除
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        #endregion Model

    }
}
