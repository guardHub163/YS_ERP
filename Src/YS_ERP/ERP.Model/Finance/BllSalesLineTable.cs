using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllSalesLineTable
    {
        public BllSalesLineTable()
        { }
        #region Model
        private string _slip_number;
        private int _line_number;
        private string _order_slip_number;
        private string _shipment_slip_number;
        private decimal? _invoice_amount;
        private string _currency_code;
        private int _status_flag = 0;
        private string _currency_name;
        private decimal? _order_amount;
        private string _serial_number;
        private decimal? _shipment_amount;

        public decimal? SHIPMENT_AMOUNT
        {
            get { return _shipment_amount; }
            set { _shipment_amount = value; }
        }

        public string SERIAL_NUMBER
        {
            get { return _serial_number; }
            set { _serial_number = value; }
        }

        public decimal? ORDER_AMOUNT
        {
            get { return _order_amount; }
            set { _order_amount = value; }
        }

        public string CURRENCY_NAME
        {
            get { return _currency_name; }
            set { _currency_name = value; }
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
        /// 销售发票行号
        /// </summary>
        public int LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
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
        /// 出库编号
        /// </summary>
        public string SHIPMENT_SLIP_NUMBER
        {
            set { _shipment_slip_number = value; }
            get { return _shipment_slip_number; }
        }
        /// <summary>
        /// 发票金额
        /// </summary>
        public decimal? INVOICE_AMOUNT
        {
            set { _invoice_amount = value; }
            get { return _invoice_amount; }
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
        /// 0:未收款发票  1: 全部收款 2：部分收款  9:删除
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        #endregion Model

    }
}
