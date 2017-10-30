using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.CacheData;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Model;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionPlanSearch : FrmBase
    {
        public FrmProductionPlanSearch()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private string _currentConduction = "";
        BProductionPlan bProductionPlan = new BProductionPlan();
        private bool isSearch = false;
        private DialogResult resule = DialogResult.Cancel;
        private string slipNumber = "";
        public string SLIPNUMBER
        {
            get { return slipNumber; }
            set { slipNumber = value; }
        }

        private void FrmProductionPlanSearch_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 15;
            //dgvData.Rows[0].Selected = true;

            if (CConstant.ORDER_MASTER_SEARCH.Equals(CTag))
            {
                this.Text = "生产计划查询";
                btnDetails.Text = "确认";
                btnEdite.Enabled = false;
                btnEdite.Visible = false;
                btnPause.Visible = false;
            }
            cboStatus.DataSource = CCacheData.STATUS;
            cboStatus.ValueMember = "CODE";
            cboStatus.DisplayMember = "NAME";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _currentConduction = GetConduction();
            int currentPage = 1;
            int recordCount = bProductionPlan.GetRecordCount(_currentConduction);
            if (recordCount <= 0)
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //分页标签初始化
            this.pgControl.init(GetTotalPage(recordCount), currentPage);

            //数据绑定
            BindData(currentPage);
            isSearch = true;
        }

        /// <summary>
        /// 数据查询,绑定
        /// </summary>
        private void BindData(int currentPage)
        {
            DataSet ds = bProductionPlan.GetList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells["STATUS_FLAG"].Value.ToString().Equals("1"))
                {
                    row.Cells["STATUS_NAME"].Value = "已开始";
                }
                else if (row.Cells["STATUS_FLAG"].Value.ToString().Equals("2"))
                {
                    row.Cells["STATUS_NAME"].Value = "已结束";
                }
                else if (row.Cells["STATUS_FLAG"].Value.ToString().Equals("0"))
                {
                    row.Cells["STATUS_NAME"].Value = "未开始";
                }
                else if (row.Cells["STATUS_FLAG"].Value.ToString().Equals("5"))
                {
                    row.Cells["STATUS_NAME"].Value = "暂停";
                }
            }

        }

        /// <summary>
        /// 当前页码发生变化时的操作
        /// </summary>

        private void pgControl_PageChanged(object sender, EventArgs e, int currentPage)
        {
            BindData(currentPage);
        }
        /// <summary>
        /// 当前数据集的重新整理
        /// </summary>
        private void reSetCurrentDt()
        {
            for (int i = 0; i < _currentDt.Rows.Count; i++)
            {
                #region 是否生成销售订单

                #endregion
            }

            for (int i = _currentDt.Rows.Count; i < PageSize; i++)
            {
                _currentDt.Rows.Add(_currentDt.NewRow());
            }
        }

        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);       
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }

            if (this.txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND PLAN_START_DATE >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }

            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND PLAN_START_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            //出库预定日期From
            if (this.dateTimePicker1.Checked)
            {
                sb.AppendFormat(" AND PLAN_END_DATE >= '{0}'", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            }
            //出库预定日期To
            if (this.dateTimePicker2.Checked)
            {
                sb.AppendFormat(" AND PLAN_END_DATE < '{0}'", dateTimePicker2.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            if (!string.IsNullOrEmpty(txtSlipType.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_TYPE_CODE = '{0}'", txtSlipType.Text.Trim());
            }
            if (!cboStatus.SelectedValue.ToString().Equals("4"))
            {
                sb.AppendFormat(" AND STATUS_FLAG = '{0}'", cboStatus.SelectedValue.ToString());
            }
            return sb.ToString();

        }

        private void dgvData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Index >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.Row.Index];
                if ("".Equals(CConvert.ToString(row.Cells["SLIP_NUMBER"].Value)))
                {
                    row.Selected = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (CConstant.ORDER_MASTER_SEARCH.Equals(CTag))
            {
                slipNumber = dgvData.SelectedRows[0].Cells["SLIP_NUMBER"].Value.ToString();
                if (slipNumber != null)
                {
                    resule = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("请选择正确的行!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                if (dgvData.Rows.Count > 0)
                {
                    DataGridViewRow row = dgvData.CurrentRow;
                    string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                    if (!string.IsNullOrEmpty(slipNumber))
                    {
                        FrmBase frm = new FrmProductionPlan(slipNumber);
                        frm.CTag = CConstant.PRODUCTIONPLAN_OPERATE;
                        frm.UserTable = _userInfo;
                        if (DialogResult.OK == frm.ShowDialog())
                        {

                        }
                        frm.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("请先选择一条生产计划。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("请先选择一条生产计划。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSlipType_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("SLIP_TYPE", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSlipType.Text = frm.BaseMasterTable.Code;
                    txtSlipTypeName.Text = frm.BaseMasterTable.Name;
                }
            }

            frm.Dispose();
        }

        private void btnSlipType_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnSlipType_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                DataGridViewRow row = dgvData.CurrentRow;
                string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                // if (row.Cells["STATUS_FLAG"].Value.ToString() != "0")
                if (row.Cells["STATUS_FLAG"].Value.ToString().Equals("2"))
                {
                    MessageBox.Show("请先选择一条未开始的生产计划数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (row.Cells["STATUS_FLAG"].Value.ToString().Equals("5"))
                {
                    MessageBox.Show("请先选择一条未暂停的生产计划数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty(slipNumber))
                {
                    FrmBase frm = new FrmProductionPlan(slipNumber);

                    frm.CTag = CConstant.PRODUCTIONPLAN_MODIFY;
                    frm.UserTable = _userInfo;
                    if (DialogResult.OK == frm.ShowDialog())
                    {

                    }
                    frm.Dispose();
                }
                else
                {
                    MessageBox.Show("请先选择一条生产计划数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("没有生产计划数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSlipType_Leave(object sender, EventArgs e)
        {
            string SlipTypeCode = txtSlipType.Text.Trim();
            if (SlipTypeCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("SLIP_TYPE", SlipTypeCode);
                if (baseMaster != null)
                {
                    txtSlipType.Text = baseMaster.Code;
                    txtSlipTypeName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("模具种类编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSlipType.Text = "";
                    txtSlipTypeName.Text = "";
                    txtSlipType.Focus();
                }
            }
            else
            {
                txtSlipTypeName.Text = "";
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                DataGridViewRow row = dgvData.CurrentRow;
                string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                string status = CConvert.ToString(row.Cells["STATUS_FLAG"].Value);
                if (row.Cells["STATUS_FLAG"].Value.ToString().Equals("2"))
                {
                    MessageBox.Show("您选择的生产计划数据未开始或已结束。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!string.IsNullOrEmpty(slipNumber))
                {
                    int result = bProductionPlan.Pause(slipNumber,status);
                    if (status.Equals("1"))
                    {
                        if (result > 0)
                        {
                            MessageBox.Show("此工单暂停成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _currentConduction = GetConduction();
                            int currentPage = 1;
                            int recordCount = bProductionPlan.GetRecordCount(_currentConduction);
                            if (recordCount <= 0)
                            {
                                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            //分页标签初始化
                            this.pgControl.init(GetTotalPage(recordCount), currentPage);

                            //数据绑定
                            BindData(currentPage);
                            isSearch = true;
                        }
                        else
                        {
                            MessageBox.Show("此工单暂停失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (result > 0)
                        {
                            MessageBox.Show("此工单解除暂停成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _currentConduction = GetConduction();
                            int currentPage = 1;
                            int recordCount = bProductionPlan.GetRecordCount(_currentConduction);
                            if (recordCount <= 0)
                            {
                                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            //分页标签初始化
                            this.pgControl.init(GetTotalPage(recordCount), currentPage);

                            //数据绑定
                            BindData(currentPage);
                            isSearch = true;
                        }
                        else
                        {
                            MessageBox.Show("此工单暂停失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择一条生产计划数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("没有生产计划数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
