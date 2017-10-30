using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllProductBuildLineTable
    {
        public BllProductBuildLineTable()
        { }
        #region Model
        private string _slip_number;
        private int _line_number;
        private string _product_parts_code;
        private decimal? _parts_quantity;
        private string _unit_code;
        private int _status_flag = 0;
        /// <summary>
        /// 
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PRODUCT_PARTS_CODE
        {
            set { _product_parts_code = value; }
            get { return _product_parts_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PARTS_QUANTITY
        {
            set { _parts_quantity = value; }
            get { return _parts_quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UNIT_CODE
        {
            set { _unit_code = value; }
            get { return _unit_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        #endregion Model
    }
}
