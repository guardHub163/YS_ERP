using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseSlipTypeCompositionProductsTable
    {
        public BaseSlipTypeCompositionProductsTable()
        { }
        #region Model
        private string _slip_type_code;
        private string _slip_type_name;
        private string _composition_products_code;
        private string _composition_products_name;
        private int _quantity;

        public int QUANTITY
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SLIP_TYPE_CODE
        {
            set { _slip_type_code = value; }
            get { return _slip_type_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMPOSITION_PRODUCTS_CODE
        {
            set { _composition_products_code = value; }
            get { return _composition_products_code; }
        }

        public string SLIP_TYPE_NAME
        {
            set { _slip_type_name = value; }
            get { return _slip_type_name; }
        }

        public string COMPOSITION_PRODUCTS_NAME
        {
            set { _composition_products_name = value; }
            get { return _composition_products_name; }
        }
        #endregion Model
    }
}
