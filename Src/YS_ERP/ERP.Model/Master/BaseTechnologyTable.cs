using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model.Master
{
    public class BaseTechnologyTable
    {
        public BaseTechnologyTable()
        { }

        #region Model
        private string _code;
        private string _name;
        private string _department_code;
        private string _technology_drawing1;
        private string _technology_drawing2;
        private string _technology_drawing3;
        private int? _period;
        private int? _status_flag;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        private string _technology_drawingname1;
        private string _technology_drawingname2;
        private string _technology_drawingname3;
        private string _department_name;

        public string DEPARTMENT_NAME
        {
            set { _department_name = value; }
            get { return _department_name; }
        }


        public string TECHNOLOGY_DRAWINGNAME1
        {
            set { _technology_drawingname1 = value; }
            get { return _technology_drawingname1; }
        }

        public string TECHNOLOGY_DRAWINGNAME2
        {
            set { _technology_drawingname2 = value; }
            get { return _technology_drawingname2; }
        }

        public string TECHNOLOGY_DRAWINGNAME3
        {
            set { _technology_drawingname3 = value; }
            get { return _technology_drawingname3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DEPARTMENT_CODE
        {
            set { _department_code = value; }
            get { return _department_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TECHNOLOGY_DRAWING1
        {
            set { _technology_drawing1 = value; }
            get { return _technology_drawing1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TECHNOLOGY_DRAWING2
        {
            set { _technology_drawing2 = value; }
            get { return _technology_drawing2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TECHNOLOGY_DRAWING3
        {
            set { _technology_drawing3 = value; }
            get { return _technology_drawing3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PERIOD
        {
            set { _period = value; }
            get { return _period; }
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
        public string CREATE_USER
        {
            set { _create_user = value; }
            get { return _create_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CREATE_DATE_TIME
        {
            set { _create_date_time = value; }
            get { return _create_date_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        #endregion Model

    }
}
