using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BaseHsCodeTable
    {
        /// <summary>
        /// 海关编码
        /// </summary>
     
      
        public BaseHsCodeTable()
        { }
        #region Model
        private string _hs_code;
        private string _hs_name;
        private decimal _tax_rate;
        private int _status_flag = 1;
        private string _create_user;
        private DateTime? _create_date_time;
        private string _last_update_user;
        private DateTime? _last_update_time;
        /// <summary>
        /// 海关商品编号
        /// </summary>
        public string HS_CODE
        {
            set { _hs_code = value; }
            get { return _hs_code; }
        }
        /// <summary>
        /// 海关商品名称
        /// </summary>
        public string HS_NAME
        {
            set { _hs_name = value; }
            get { return _hs_name; }
        }
        /// <summary>
        /// 关税税率
        /// </summary>
        public decimal TAX_RATE
        {
            set { _tax_rate = value; }
            get { return _tax_rate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int STATUS_FLAG
        {
            set { _status_flag = value; }
            get { return _status_flag; }
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
        /// 最后更新人员
        /// </summary>
        public string LAST_UPDATE_USER
        {
            set { _last_update_user = value; }
            get { return _last_update_user; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? LAST_UPDATE_TIME
        {
            set { _last_update_time = value; }
            get { return _last_update_time; }
        }
        #endregion Model

   }
    
}