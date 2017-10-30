using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseProductionTechnologyTable
    {
        public BaseProductionTechnologyTable()
        { }
        #region Model
        private string _slip_number;
        private int _schedule_production_process_line_nunber;
        private int _line_number;
        private string _technology_code;
        private DateTime? _plan_start_date;
        private DateTime? _plan_end_date;
        private int? _status_flag;
        private DateTime? _actual_start_time;
        private DateTime? _actual_end_time;
        private string _technology_name;
        private string _composition_products_name;
        private string _composition_products_code;
        private string _production_process_name;
        private string _production_process_code;
        private int _schedule_line_number;

        public int SCHEDULE_LINE_NUMBER
        {
            set { _schedule_line_number = value; }
            get { return _schedule_line_number; }
        }

        public string COMPOSITION_PRODUCTS_CODE
        {
            set { _composition_products_code = value; }
            get { return _composition_products_code; }
        }
        public string COMPOSITION_PRODUCTS_NAME
        {
            set { _composition_products_name = value; }
            get { return _composition_products_name; }
        }
        public string PRODUCTION_PROCESS_CODE
        {
            set { _production_process_code = value; }
            get { return _production_process_code; }
        }
        public string PRODUCTION_PROCESS_NAME
        {
            set { _production_process_name = value; }
            get { return _production_process_name; }
        }

        public string TECHNOLOGY_NAME
        {
            set { _technology_name = value; }
            get { return _technology_name; }
        }

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
        public int SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER
        {
            set { _schedule_production_process_line_nunber = value; }
            get { return _schedule_production_process_line_nunber; }
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
        public string TECHNOLOGY_CODE
        {
            set { _technology_code = value; }
            get { return _technology_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PLAN_START_DATE
        {
            set { _plan_start_date = value; }
            get { return _plan_start_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PLAN_END_DATE
        {
            set { _plan_end_date = value; }
            get { return _plan_end_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ACTUAL_START_TIME
        {
            set { _actual_start_time = value; }
            get { return _actual_start_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ACTUAL_END_TIME
        {
            set { _actual_end_time = value; }
            get { return _actual_end_time; }
        }
        #endregion Model


    }
}
