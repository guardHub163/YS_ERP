using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllPurchaseLineTable
    {
        public BllPurchaseLineTable()
        { }
        #region Model
        private string _slip_number;
        private int _line_number;
        private string _purchase_order_number;
        private string _receipt_slip_number;
        private int _receipt_line_number;
        private decimal _invoice_amount;
        private decimal _tax_amount;
        private decimal _packing_amount;
        private string _currency_code;
        private int _status_flag = 0;
        /// <summary>
        /// 采购发票内部编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 采购发票行号
        /// </summary>
        public int LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
        }
        /// <summary>
        /// 采购订单编号
        /// </summary>
        public string PURCHASE_ORDER_NUMBER
        {
            set { _purchase_order_number = value; }
            get { return _purchase_order_number; }
        }
        /// <summary>
        /// 入库编号
        /// </summary>
        public string RECEIPT_SLIP_NUMBER
        {
            set { _receipt_slip_number = value; }
            get { return _receipt_slip_number; }
        }
        /// <summary>
        /// 入库行号
        /// </summary>
        public int RECEIPT_LINE_NUMBER
        {
            set { _receipt_line_number = value; }
            get { return _receipt_line_number; }
        }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal INVOICE_AMOUNT
        {
            set { _invoice_amount = value; }
            get { return _invoice_amount; }
        }
        /// <summary>
        /// 关税
        /// </summary>
        public decimal TAX_AMOUNT
        {
            set { _tax_amount = value; }
            get { return _tax_amount; }
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
        /// 货币编号
        /// </summary>
        public string CURRENCY_CODE
        {
            set { _currency_code = value; }
            get { return _currency_code; }
        }
        /// <summary>
        /// 0:未付款发票  1: 全部付款 2：部分付款  9:删除
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        #endregion Model
    }
}
