using System;
using System.Collections.Generic;
using System.Text;

namespace CZZD.ERP.Model
{
    public class BllProductBuildTable
    {
        public BllProductBuildTable()
        { }
        #region Model
        private string _slip_number;
        private string _warehouse_code;
        private string _product_code;
        private decimal? _quantity;
        private DateTime _build_date;
        private string _company_code;
        private string _unit_code;
        private int _status_flag = 0;
        private string _create_user;
        private DateTime? _create_date_time;
        private DateTime? _last_update_time;
        private string _last_update_user;
        private List<BllProductBuildLineTable> _items = new List<BllProductBuildLineTable>();

        /// <summary>
        /// 组成编号
        /// </summary>
        public string SLIP_NUMBER
        {
            set { _slip_number = value; }
            get { return _slip_number; }
        }
        /// <summary>
        /// 仓库
        /// </summary>
        public string WAREHOUSE_CODE
        {
            set { _warehouse_code = value; }
            get { return _warehouse_code; }
        }
        /// <summary>
        /// 组成品
        /// </summary>
        public string PRODUCT_CODE
        {
            set { _product_code = value; }
            get { return _product_code; }
        }
        /// <summary>
        /// 组成品数量
        /// </summary>
        public decimal? QUANTITY
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 组成日期
        /// </summary>
        public DateTime BUILD_DATE
        {
            set { _build_date = value; }
            get { return _build_date; }
        }
        /// <summary>
        /// 公司
        /// </summary>
        public string COMPANY_CODE
        {
            set { _company_code = value; }
            get { return _company_code; }
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
        /// 1: 组成  2:解除
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

        public List<BllProductBuildLineTable> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddItem(BllProductBuildLineTable model)
        {
            _items.Add(model);
        #endregion Model

        }
    }
}
