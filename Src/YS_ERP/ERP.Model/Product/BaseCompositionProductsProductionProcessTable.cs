using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseCompositionProductsProductionProcessTable
    {
        public BaseCompositionProductsProductionProcessTable()
		{}
		#region Model
		private string _composition_products_code;
        private string _composition_products_name;
        private string _productionProcess_code;
        private string _productionProcess_name;
        private string _order;

        public string ORDER
        {
            set { _order = value; }
            get { return _order; }
        }

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
		public string PRODUCTION_PROCESS_CODE
		{
            set { _productionProcess_code = value; }
            get { return _productionProcess_code; }
		}

        public string PRODUCTION_PROCESS_NAME
        {
            set { _productionProcess_name = value; }
            get { return _productionProcess_name; }
        }
		#endregion Model
    }
}
