using System;
using System.Collections.Generic;
using System.Text;
using CZZD.ERP.Model;

namespace CZZD.ERP.Model
{
    public class BaseProductionPlanTable
    {
        public BaseProductionPlanTable()
        { }
        #region Model

        private string _slip_number;
        private string _order_slip_number;
        private string _slip_type_code;
        private string _slip_type_name;

        private DateTime? _plan_start_time;
        private DateTime? _plan_end_time;
        private DateTime? _slip_date;
        private string _spec;
        private decimal? _plan_number;
        private string _memo;
        private int? _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private DateTime? _actual_start_time;
        private DateTime? _actual_end_time;
        private string _memo1;
        private string _memo2;
        private string _memo3;
        private List<BaseProductionPlanLineTable> _items = new List<BaseProductionPlanLineTable>();
        private List<BaseProductionPlanDrawingLineTable> _itemsdrawing = new List<BaseProductionPlanDrawingLineTable>();
        private List<BaseProductionScheduleProductionProcessTable> _itemsproductionprocess = new List<BaseProductionScheduleProductionProcessTable>();

        public List<BaseProductionPlanLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public void AddItem(BaseProductionPlanLineTable model)
        {
            _items.Add(model);
        }


        public List<BaseProductionPlanDrawingLineTable> ItemsDrawing
        {
            get { return _itemsdrawing; }
            set { _itemsdrawing = value; }
        }

        public void AddItemDrawing(BaseProductionPlanDrawingLineTable model)
        {
            _itemsdrawing.Add(model);
        }


        public List<BaseProductionScheduleProductionProcessTable> ItemsProductionProcess
        {
            get { return _itemsproductionprocess; }
            set { _itemsproductionprocess = value; }
        }

        public void AddItemProductionProcess(BaseProductionScheduleProductionProcessTable model)
        {
            _itemsproductionprocess.Add(model);
        }


        /// <summary>
        /// 创建人员
        /// </summary>
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }

        public int? STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
        }

        public string MEMO
        {
            set { _memo = value; }
            get { return _memo; }
        }

        public DateTime? SLIP_DATE
        {
            set { _slip_date = value; }
            get { return _slip_date; }
        }

        public string ORDER_SLIP_NUNBER
        {
            set { _order_slip_number = value; }
            get { return _order_slip_number; }
        }

        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }

        public string SLIP_TYPE_CODE
        {
            set { _slip_type_code = value; }
            get { return _slip_type_code; }
        }

        public string SLIP_TYPE_NAME
        {
            get { return _slip_type_name; }
            set { _slip_type_name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
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

        public string SPEC
        {
            set { _spec = value; }
            get { return _spec; }
        }

        public decimal? PLAN_QUANTITY
        {
            set { _plan_number = value; }
            get { return _plan_number; }
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

        public string MEMO1
        {
            set { _memo1 = value; }
            get { return _memo1; }
        }
        public string MEMO2
        {
            set { _memo2 = value; }
            get { return _memo2; }
        }
        public string MEMO3
        {
            set { _memo3 = value; }
            get { return _memo3; }
        }
        #endregion Model
    }
}
