using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllShipmentLineTable
    {
        public BllShipmentLineTable()
        { }
        #region Model
        private string _slip_number;
        private int _line_number;
        private string _departual_warehouse_code;
        private string _product_code;
        private decimal? _quantity;
        private string _unit_code;
        private decimal? _price;
        private decimal? _amount;
        private string _memo;
        private int _status_flag = 0;
        private int _order_line_number;

       
        /// <summary>
        /// 出库编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 出库行号
        /// </summary>
        public int LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
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
        /// 商品编号
        /// </summary>
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }
        /// <summary>
        /// 出库数量
        /// </summary>
        public decimal? QUANTITY
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
        public decimal? PRICE
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 出库金额
        /// </summary>
        public decimal? AMOUNT
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 出库明细备注
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 0:(暂不启用)
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }

        /// <summary>
        /// 受注订单明细编号
        /// </summary>
        public int ORDER_LINE_NUMBER
        {
            get { return _order_line_number; }
            set { _order_line_number = value; }
        }
        #endregion Model
    }
}
