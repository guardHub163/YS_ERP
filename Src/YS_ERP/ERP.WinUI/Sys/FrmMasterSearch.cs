using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Bll;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Model;

namespace CZZD.ERP.WinUI
{
    public partial class FrmMasterSearch : FrmBase
    {
        private DataTable _currentDt = new DataTable();
        private DialogResult resule = DialogResult.Cancel;
        private bool isSearch = false;
        private string _tableName = "";
        private string _strWhere = "";
        private string _code = "";
        private int _pageSize;
        private BaseMaster _baseMasterTable = null;

        public BaseMaster BaseMasterTable
        {
            get { return _baseMasterTable; }
            set { _baseMasterTable = value; }
        }

        public FrmMasterSearch()
        {
            InitializeComponent();
        }

        public FrmMasterSearch(string tableName, string strWhere)
        {
            _tableName += tableName;
            _strWhere = strWhere;
            InitializeComponent();
        }

        public FrmMasterSearch(string tableName, string strWhere, string code)
        {
            _tableName += tableName;
            _strWhere = strWhere;
            _code = code;
            InitializeComponent();
        }

        /// <summary>
        /// Load
        /// </summary>
        private void FrmMasterSearch_Load(object sender, EventArgs e)
        {
            _pageSize = MasterMinPageSize;
            txtCode.Text = _code;
            init();
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void init()
        {
            #region dgvData
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            _currentDt.Columns.Add("CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("DISP_CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("NAME_JP", Type.GetType("System.String"));
            _currentDt.Columns.Add("COMPOSITION_PRODUCTS_CODE", Type.GetType("System.String"));
            _currentDt.Columns.Add("COMPOSITION_PRODUCTS_NAME", Type.GetType("System.String"));
            DataRow row = null;
            //if (_tableName == "PRODUCT" || _tableName == "Customer" || _tableName == "Product" || _tableName == "CUSTOMER")
            //{
            //    this.txtJapan.Enabled = true;
            //    dgvData.Columns[2].Visible = true;
            //}
            //else
            //{
            //    this.txtJapan.Enabled = false;
            //    dgvData.Columns[2].Visible = false;
            //    dgvData.Columns[1].Width = 290;
            //}
            if (_tableName == "PRODUCT" || _tableName == "Product")
            {
                dgvData.Columns["SPEC"].Visible = true;
            }
            //else if (_tableName)
            //{}
            else if (_tableName == "BTN_PARTS_CODE")
            {
                txtCode.ReadOnly = true;
                txtName.ReadOnly = true;
                dgvData.Columns["SPEC"].Visible = false;
                dgvData.Columns["NAME"].Width = 290;
            }
            else
            {
                dgvData.Columns["SPEC"].Visible = false;
                dgvData.Columns["NAME"].Width = 290;
            }

            for (int i = 1; i <= _pageSize; i++)
            {
                row = _currentDt.NewRow();
                _currentDt.Rows.Add(row);
            }
            this.dgvData.DataSource = _currentDt;

            if (_tableName == "DELIVERY")
            {
                label1.Text = "客 户 编 号：";
                label2.Text = "地 址 编 号：";
            }
            #endregion
        }

        private void pgControlMin_PageChanged(object sender, EventArgs e, int currentPage)
        {
            if (isSearch)
            {
                BindData(currentPage);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            isSearch = true;
            Search(1);
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void Search(int currentPage)
        {
            string strWhere = getConduction();
            int recordCount = bCommon.GetMasterRecordCount(_tableName, txtCode.Text.Trim(), txtName.Text.Trim(), strWhere);
            if (recordCount == 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (recordCount > CConstant.MAX_MASTER_PAGE_SIZE)
            {

                //分页标签初始化
                _pageSize = MasterMinPageSize - 1;
                pgControlMin.Visible = true;
                pgControlMin.init(GetTotalPage(recordCount, _pageSize), currentPage);

                //数据绑定
                BindData(currentPage);
            }
            else
            {
                _pageSize = MasterMinPageSize;
                pgControlMin.Visible = false;
                BindData();
            }
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            string strWhere = getConduction();

            DataSet ds = bCommon.GetMasterDataList(_tableName, txtCode.Text.Trim(), txtName.Text.Trim(), strWhere, (currentPage - 1) * _pageSize + 1, currentPage * _pageSize);

            _currentDt = ds.Tables[0];
            ReSetCurrentDt();
            for (int i = _currentDt.Rows.Count; i < _pageSize; i++)
            {
                _currentDt.Rows.Add(ds.Tables[0].NewRow());
            }
            this.dgvData.DataSource = _currentDt;
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData()
        {

            string strWhere = getConduction();

            DataSet ds = bCommon.GetMasterList(_tableName, txtCode.Text.Trim(), txtName.Text.Trim(), strWhere);
            _currentDt = ds.Tables[0];
            ReSetCurrentDt();
            for (int i = _currentDt.Rows.Count; i < _pageSize; i++)
            {
                _currentDt.Rows.Add(ds.Tables[0].NewRow());
            }
            this.dgvData.DataSource = _currentDt;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReSetCurrentDt()
        {
            try
            {
                _currentDt.Columns.Add("DISP_CODE", Type.GetType("System.String"));
            }
            catch { }

            foreach (DataRow row in _currentDt.Rows)
            {
                if ("USER".Equals(_tableName))
                {
                    row["DISP_CODE"] = CConvert.ToString(row["CODE"]).Substring(2);
                }
                else
                {
                    row["DISP_CODE"] = row["CODE"];
                }
            }
        }

        public string getConduction()
        {
            string sb = "";
            //if (this.txtJapan.Text != "")
            //{
            //    if (_tableName == "PRODUCT" || _tableName == "Product")
            //    {
            //        if (_strWhere != "")
            //        {
            //            sb = _strWhere + " AND NAME_JP like '%" + this.txtJapan.Text + "%' AND SELL_LOCATION=1";
            //        }
            //        else
            //        {
            //            sb = "NAME_JP like '%" + this.txtJapan.Text + "%' AND SELL_LOCATION=1";
            //        }
            //    }
            //    else if (_tableName == "Customer" || _tableName == "CUSTOMER")
            //    {
            //        if (_strWhere != "")
            //        {
            //            sb = _strWhere + " AND NAME_JP like '%" + this.txtJapan.Text + "%'";
            //        }
            //        else
            //        {
            //            sb = "NAME_JP like '%" + this.txtJapan.Text + "%'";
            //        }
            //    }
            //    else
            //    {
            //        sb = _strWhere;
            //    }
            //}
            //else
            //if (_tableName == "PRODUCT" || _tableName == "Product")
            //{
            //    if (_strWhere != "")
            //    {
            //        sb = _strWhere + " AND SELL_LOCATION=1";
            //    }
            //    else
            //    {
            //        sb = " SELL_LOCATION=1";
            //    }
            //}
            //else
            //{
            //    sb = _strWhere;
            //}

            return _strWhere + sb;

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            resule = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GetSelectObject();
            if (_baseMasterTable != null)
            {
                resule = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择正确的行!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetSelectObject();
            if (_baseMasterTable != null)
            {
                resule = DialogResult.OK;
                this.Close();
            }
        }

        private void GetSelectObject()
        {
            try
            {
                string code = dgvData.SelectedRows[0].Cells["CODE"].Value.ToString();
                if (code != "")
                {
                    if ("DELIVERY".Equals(_tableName) && string.IsNullOrEmpty(_strWhere))
                    {
                        string customercode = dgvData.SelectedRows[0].Cells["CUSTOMER_CODE"].Value.ToString();
                        _strWhere = "CUSTOMER_CODE = '" + customercode + "'";
                    }
                    _baseMasterTable = bCommon.GetBaseMaster(_tableName, code, _strWhere);
                }
            }
            catch (Exception ex) { }

            if (_baseMasterTable == null || _baseMasterTable.Code == null || "".Equals(_baseMasterTable.Code))
            {
                _baseMasterTable = null;
            }
        }

        private void FrmMasterSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = resule;
        }

        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if (row.Cells["CODE"].Value == null || "".Equals(row.Cells["CODE"].Value.ToString()))
                {
                    row.Selected = false;
                }
            }
        }
    }//end class
}
