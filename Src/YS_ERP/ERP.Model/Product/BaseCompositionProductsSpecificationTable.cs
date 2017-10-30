using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseCompositionProductsSpecificationTable
    {
        public BaseCompositionProductsSpecificationTable()
		{}
		#region Model
		private string _composition_products_code;
        private string _composition_products_name;
		private string _specification_code;
        private string _specification_name;
		/// <summary>
		/// 
		/// </summary>
		public string COMPOSITION_PRODUCTS_CODE
		{
			set{ _composition_products_code=value;}
			get{return _composition_products_code;}
		}

        public string COMPOSITION_PRODUCTS_NAME
        {
            set { _composition_products_name = value; }
            get { return _composition_products_name; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string SPECIFICATION_CODE
		{
			set{ _specification_code=value;}
			get{return _specification_code;}
		}

        public string SPECIFICATION_NAME
        {
            set { _specification_name = value; }
            get { return _specification_name; }
        }
		#endregion Model
    }
}
