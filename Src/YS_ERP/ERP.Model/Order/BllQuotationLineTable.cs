using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllQuotationLineTable
    {
        public BllQuotationLineTable()
        { }
        #region Model
        private string _slip_number;
        private int _line_number;
        private string _product_code;
        private string _product_name;
        private decimal? _quantity;
        private string _unit_code;
        private string _unit_name;
        private decimal? _price;
        private decimal? _amount;
        private string _currency_code;
        private string _memo;
        private int _status_flag = 0;
        private string _spec;
        private string _description;
        private decimal? _price_discount;
        private string _meterial;
        private string _parts_code;
        private string _composition_products_name;
        private string _description1;

        public string DESCRIPTION1
        {
            set { _description1 = value; }
            get { return _description1; }
        }

        public string COMPOSITION_PRODUCTS_NAME
        {
            set { _composition_products_name = value; }
            get { return _composition_products_name; }
        }
        public string PARTS_CODE
        {
            set { _parts_code = value; }
            get { return _parts_code; }
        }

        public string METERIAL
        {
            set { _meterial = value; }
            get { return _meterial; }
        }

        public decimal? PRICE_DISCOUNT
        {
            set { _price_discount = value; }
            get { return _price_discount; }
        }

        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 订单行号
        /// </summary>
        public int LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }

        public string PRODUCT_NAME
        {
            set { _product_name = value; }
            get { return _product_name; }
        }

        public string SPEC
        {
            set { _spec = value; }
            get { return _spec; }
        }

        /// <summary>
        /// 订单数量
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

        public string UNIT_NAME
        {
            set { _unit_name = value; }
            get { return _unit_name; }
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
        /// 订单金额
        /// </summary>
        public decimal? AMOUNT
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 货币编号(由于业务上每张订单都是同一币种,一般不启用)
        /// </summary>
        public string CURRENCY_CODE
        {
            set { _currency_code = value; }
            get { return _currency_code; }
        }
        /// <summary>
        /// 订单明细备注
        /// </summary>
        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 0:新订单  1: 全部出库  2：部分出库 9:删除　
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        #endregion Model

    }
}
