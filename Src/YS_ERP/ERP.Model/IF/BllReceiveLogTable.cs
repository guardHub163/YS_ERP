using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    /// <summary>
    /// BllImportLogTable:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BllReceiveLogTable
    {
        public BllReceiveLogTable()
        { }
        #region Model
        private decimal _id;
        private bool _auto_mode;
        private string _source_file;
        private int? _success_number;
        private int? _failure_number;
        private string _back_file;
        private string _error_file;
        private int? _status_flag;
        private DateTime? _create_date;
        private decimal? _create_user_id;
        private DateTime? _last_update_date;
        private decimal? _last_update_user_id;
        /// <summary>
        /// 
        /// </summary>
        public decimal ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool AUTO_MODE
        {
            set { _auto_mode = value; }
            get { return _auto_mode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SOURCE_FILE
        {
            set { _source_file = value; }
            get { return _source_file; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SUCCESS_NUMBER
        {
            set { _success_number = value; }
            get { return _success_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FAILURE_NUMBER
        {
            set { _failure_number = value; }
            get { return _failure_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BACK_FILE
        {
            set { _back_file = value; }
            get { return _back_file; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ERROR_FILE
        {
            set { _error_file = value; }
            get { return _error_file; }
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
        public DateTime? CREATE_DATE
        {
            set { _create_date = value; }
            get { return _create_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CREATE_USER_ID
        {
            set { _create_user_id = value; }
            get { return _create_user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LAST_UPDATE_DATE
        {
            set { _last_update_date = value; }
            get { return _last_update_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? LAST_UPDATE_USER_ID
        {
            set { _last_update_user_id = value; }
            get { return _last_update_user_id; }
        }
        #endregion Model
    
    }//end class
}
