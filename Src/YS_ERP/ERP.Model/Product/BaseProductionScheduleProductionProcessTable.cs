using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseProductionScheduleProductionProcessTable
    {
        public BaseProductionScheduleProductionProcessTable()
        { }

        private string _slip_number;
        private int? _schedule_line_number;
        private int? _line_number;
        private string _production_process_code;
        private string _department_code;
        private DateTime? _plan_start_time;
        private DateTime? _plan_end_time;
        private int? _status_flag;
        private DateTime? _actual_start_time;
        private DateTime? _actual_end_time;
        private string _department_name;
        private string _production_process_name;
        private decimal? _production_cycle;
        private string _weight;


        public string WEIGHT
        {
            set { _weight = value; }
            get { return _weight; }
        }
        private List<BaseProductionTechnologyTable> _productiontechnology = new List<BaseProductionTechnologyTable>();

        public List<BaseProductionTechnologyTable> ProductionTechnology
        {
            get { return _productiontechnology; }
            set { _productiontechnology = value; }
        }

        public void AddProductionTechnology(BaseProductionTechnologyTable model)
        {
            _productiontechnology.Add(model);
        }

        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }

        public int? SCHEDULE_LINE_NUNBER
        {
            set { _schedule_line_number = value; }
            get { return _schedule_line_number; }
        }

        public int? LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
        }

        public string PRODUCTION_PROCESS_CODE
        {
            set { _production_process_code = value; }
            get { return _production_process_code; }
        }

        public string DEPARTMENT_CODE
        {
            set { _department_code = value; }
            get { return _department_code; }
        }

        public DateTime? PLAN_START_DATE
        {
            set { _plan_start_time = value; }
            get { return _plan_start_time; }
        }

        public DateTime? PLAN_END_DATE
        {
            set { _plan_end_time = value; }
            get { return _plan_end_time; }
        }

        public int? STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }

        public DateTime? ACTUAL_START_TIME
        {
            set { _actual_start_time = value; }
            get { return _actual_start_time; }
        }

        public DateTime? ACTUAL_END_TIME
        {
            set { _actual_end_time = value; }
            get { return _actual_end_time; }
        }

        public string DEPARTMENT_NAME
        {
            get { return _department_name; }
            set { _department_name = value; }
        }

        public string PRODUCTION_PROCESS_NAME
        {
            get { return _production_process_name; }
            set { _production_process_name = value; }
        }

        public decimal? PRODUCTION_CYCLE
        {
            get { return _production_cycle; }
            set { _production_cycle = value; }
        }


    }//END CLASS
}
