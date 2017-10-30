using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseProductionPlanLineTable
    {
        public BaseProductionPlanLineTable()
        { }

        private string _slip_number;
        private int? _line_number;
        private string _parts_code;
        private DateTime? _plan_start_time;
        private DateTime? _plan_end_time;
        private decimal? _plan_number;
        private int? _schedule_flag;
        private int? _status_flag;
        private DateTime? _actual_start_time;
        private DateTime? _actual_end_time;
        private string _parts_name;
        private string _type_code;
        private string _type_name;
        private List<BaseProductionScheduleProductionProcessTable> _productionprocess = new List<BaseProductionScheduleProductionProcessTable>();



        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }

        public int? LINE_NUMBER
        {
            set { _line_number = value; }
            get { return _line_number; }
        }

        public string PARTS_CODE
        {
            set { _parts_code = value; }
            get { return _parts_code; }
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

        public decimal? PLAN_NUMBER
        {
            set { _plan_number = value; }
            get { return _plan_number; }
        }

        public int? SCHEDULE_FLAG
        {
            set { _schedule_flag = value; }
            get { return _schedule_flag; }
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

        public List<BaseProductionScheduleProductionProcessTable> ProductionProcess
        {
            get { return _productionprocess; }
            set { _productionprocess = value; }
        }

        public void AddProductionProcess(BaseProductionScheduleProductionProcessTable model)
        {
            _productionprocess.Add(model);
        }

        public string PARTS_NAME
        {
            set { _parts_name = value; }
            get { return _parts_name; }
        }
        public string TYPE_CODE
        {
            set { _type_code = value; }
            get { return _type_code; }
        }

        public string TYPE_NAME
        {
            get { return _type_name; }
            set { _type_name = value; }
        }
    }//end class
}
