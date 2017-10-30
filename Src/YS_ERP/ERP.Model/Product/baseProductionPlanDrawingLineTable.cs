using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseProductionPlanDrawingLineTable
    {
        public BaseProductionPlanDrawingLineTable()
        { }
        private string _slip_number;
        private int? _line_number;
        private string _drawing_code;
        private string _drawing_name;
        private DateTime? _plan_end_date;
        private int? _status_flag;
        private DateTime? _actual_start_time;
        private DateTime? _actual_end_time;

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
        public string DRAWING_CODE
        {
            set { _drawing_code = value; }
            get { return _drawing_code; }
        }
        public string DRAWING_NAME
        {
            set { _drawing_name = value; }
            get { return _drawing_name; }
        }

        public DateTime? PLAN_END_DATE
        {
            set { _plan_end_date = value; }
            get { return _plan_end_date; }
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

    }
}
