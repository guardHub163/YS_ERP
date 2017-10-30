using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.CacheData;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using CZZD.ERP.WinUI.Properties;
using System.Text.RegularExpressions;
using System.Collections;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionTechnology : FrmBase
    {
        public FrmProductionTechnology()
        {
            InitializeComponent();
        }
        BProductionPlanSearch bProductionPlanSearch = new BProductionPlanSearch();
        BaseProductionTechnologyTable productionTechnology = new BaseProductionTechnologyTable();
        private BProductionProcess bProductionProcess = new BProductionProcess();
        private BProductionDrawing bproductionDrawing = new BProductionDrawing();
        private BCompositionProductsProductionProcess bCompositionProductsProductionProcess = new BCompositionProductsProductionProcess();
        private string _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
        private string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PRODUCTION);
        DataSet ds;
        private void FrmProductionTechnology_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            cboStatus.DataSource = CCacheData.TECHNOLOGYSTATUS;
            cboStatus.ValueMember = "CODE";
            cboStatus.DisplayMember = "NAME";
        }
        private void btnSeaarch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {

            string strWhere = GetConduction();
            ds = bProductionPlanSearch.GetProductionTechnology(strWhere);
            ds.Tables[0].Columns.Add("BTN_DOWN_LOAD", Type.GetType("System.String"));
            if (ds.Tables[0].Rows.Count < 1)
            {
                txtSlipNumber.Clear();
                txtSlipType.Clear();
                txtSlipTypeName.Clear();
                cboStatus.SelectedIndex = 0;
                dateTimePicker1.Checked = false;
                dateTimePicker2.Checked = false;
                //dgvData.DataSource = ds.Tables[0];
                dgvData.Rows.Clear();
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                Hashtable TechnologyDwHt = new Hashtable();
                DataTable technologyDw = bProductionPlanSearch.GetTechnologyDw(GetConductionTechnologyDw()).Tables[0];
                foreach (DataRow dr in technologyDw.Rows)
                {
                    string key = CConvert.ToString(dr["SLIP_NUMBER"]) + CConvert.ToString(dr["SCHEDULE_LINE_NUMBER"]) + CConvert.ToString(dr["SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER"]) + CConvert.ToString(dr["TECHNOLOGY_LINE_NUMBER"]);
                    int count = CConvert.ToInt32(dr["COUNT"]);
                    int number = CConvert.ToInt32(dr["NUMBER"]);
                    if (count >= number && number != 0)
                    {
                        TechnologyDwHt.Add(key, "有");
                    }
                    else if (number == 0)
                    {
                        TechnologyDwHt.Add(key, "无");
                    }

                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["PST_STATUS_FLAG"].ToString() == CConvert.ToString(CConstant.STATUS))
                    {
                        dr["PST_ACTUAL_END_TIME"] = DateTime.Now;
                    }
                    else if (dr["PST_STATUS_FLAG"].ToString() == CConvert.ToString(CConstant.STATUS_START))
                    {
                        dr["PST_ACTUAL_END_TIME"] = CConvert.ToDateTime(dr["PST_ACTUAL_END_TIME"].ToString());
                    }

                    string key = CConvert.ToString(dr["SLIP_NUMBER"]) + CConvert.ToString(dr["PST_SCHEDULE_LINE_NUMBER"]) + CConvert.ToString(dr["PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER"]) + CConvert.ToString(dr["PST_TECHNOLOGY_LINE_NUMBER"]);
                    if (TechnologyDwHt.Contains(key))
                    {
                        dr["BTN_DOWN_LOAD"] = TechnologyDwHt[key];
                    }
                    else
                    {
                        dr["BTN_DOWN_LOAD"] = "N/A";
                    }
                }

                //dgvData.DataSource = ds.Tables[0];
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.Rows.Clear();
                    }
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow row = dgvData.Rows[currentRowIndex];
                        row.Cells["SLIP_NUMBER"].Value = dr["SLIP_NUMBER"];
                        row.Cells["TYPE_NAME"].Value = dr["SLIP_TYPE_NAME"];
                        row.Cells["PARTS_NAME"].Value = dr["PARTS_NAME"];
                        row.Cells["PRODUCTION_PROCESS_NAME"].Value = dr["PRODUCTION_PROCESS_NAME"];
                        row.Cells["BT_TECHNOLOGY_NAME"].Value = dr["BT_TECHNOLOGY_NAME"];
                        // row.Cells["START_PLAN_DATE"].Value = dr["TECHNOLOGY_STATUS"];
                        row.Cells["END_PLAN_DATE"].Value = dr["PST_PLAN_END_DATE"];
                        // row.Cells["START_DATE"].Value = dr["PSPP_PLAN_END_DATE"];
                        row.Cells["BTN_DOWN_LOAD"].Value = dr["BTN_DOWN_LOAD"];
                        
                        row.Cells["END_DATE"].Value = dr["PST_ACTUAL_END_TIME"];
                       // row.Cells["WEIGHT"].Value = dr["WEIGHT"];
                        row.Cells["PRODUCTION_PROCESS_CODE"].Value = dr["PRODUCTION_PROCESS_CODE"];
                        row.Cells["PSPP_LINE_NUMBER"].Value = dr["PSPP_LINE_NUMBER"];
                        row.Cells["SCHEDULE_LINE_NUNBER"].Value = dr["SCHEDULE_LINE_NUNBER"];
                        row.Cells["PSPP_STATUS_FLAG"].Value = dr["PSPP_STATUS_FLAG"];
                        row.Cells["PST_STATUS_FLAG"].Value = dr["PST_STATUS_FLAG"];
                        row.Cells["PST_SCHEDULE_LINE_NUMBER"].Value = dr["PST_SCHEDULE_LINE_NUMBER"];
                        row.Cells["PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER"].Value = dr["PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER"];
                        row.Cells["PST_TECHNOLOGY_LINE_NUMBER"].Value = dr["PST_TECHNOLOGY_LINE_NUMBER"];
                        row.Cells["PARTS_CODE"].Value = dr["PARTS_CODE"];
                    }
                }
                catch (Exception ex)
                { }



                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    if (dgvr.Cells["PST_STATUS_FLAG"].Value.ToString().Equals("1"))
                    {
                        dgvr.Cells["CHK"].ReadOnly = true;
                        dgvr.Cells["END_DATE"].ReadOnly = true;
                    }
                }
            }
        }
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" DEPARTMENT_CODE='{0}'", UserTable.DEPARTMENT_CODE);

            sb.AppendFormat(" AND STATUS_FLAG <> {0}", CConstant.PAUSE);
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat("AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }
            if (this.dateTimePicker1.Checked)
            {
                sb.AppendFormat(" AND PLAN_END_DATE >= '{0}'", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            }
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
                sb.AppendFormat(" AND PST_STATUS_FLAG = '{0}'", cboStatus.SelectedValue.ToString());
            }
            return sb.ToString();

        }
        private string GetConductionTechnologyDw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("  PST.STATUS_FLAG <> 1");
            sb.AppendFormat(" AND BTDV.DEPARTMENT_CODE='{0}'", UserTable.DEPARTMENT_CODE);
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat("AND PST.SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }

            return sb.ToString();

        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvData.Rows[e.RowIndex];
                    if (e.ColumnIndex == dgvData.Columns["BTN_DOWN_LOAD"].Index)
                    {
                        if (CConvert.ToString(row.Cells["BTN_DOWN_LOAD"].Value).Equals("有"))
                        {
                            string _oldSlipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                            string productionProcessCode = CConvert.ToString(row.Cells["PRODUCTION_PROCESS_CODE"].Value.ToString());
                            CTag = "technology";
                            string partsCode = CConvert.ToString(row.Cells["PARTS_CODE"].Value.ToString());
                            FrmProductionDownLoad frm = new FrmProductionDownLoad(_oldSlipNumber, _attachedDirectory, productionProcessCode, CTag, partsCode);
                            frm.ShowDialog(this);
                            frm.Dispose();
                        }
                    }

                }
            }
            catch (Exception ex) { }
        }
        static private Regex r = new Regex("^(?:(?!0000)[0-9]{4}([-/.]?)(?:(?:0?[1-9]|1[0-2])([-/.]?)(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])([-/.]?)(?:29|30)|(?:0?[13578]|1[02])([-/.]?)31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-/.]?)0?2([-/.]?)29)");
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvData.Columns["END_DATE"].Index)
            {
                if (dr.Cells["END_DATE"].Value != null)
                {
                    if (!r.IsMatch(dr.Cells["END_DATE"].Value.ToString().Trim()))
                    {
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    row.Cells["No"].Value = e.RowIndex + 1;
                }
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            BaseProductionPlanLineTable planline = new BaseProductionPlanLineTable();
            BaseProductionPlanTable PlanTable = new BaseProductionPlanTable();
            BaseProductionScheduleProductionProcessTable psppTable = new BaseProductionScheduleProductionProcessTable();
            BaseProductionTechnologyTable productionTechnology = null;
            int CHKchooseCount = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["CHK"].Value) == true)
                {
                    CHKchooseCount++;
                }
            }
            if (CHKchooseCount < 1)
            {
                MessageBox.Show("请选择结束的数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string CHKSLIPNUMBER = "";

            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                productionTechnology = new BaseProductionTechnologyTable();
                if (Convert.ToBoolean(dgvData.Rows[i].Cells["CHK"].Value) == true)
                {
                    DataGridViewRow row = dgvData.Rows[i];
                    if (CHKSLIPNUMBER == "")
                    {
                        CHKSLIPNUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    }
                    else if (CHKSLIPNUMBER != row.Cells["SLIP_NUMBER"].Value.ToString())
                    {

                        MessageBox.Show("您选择的生产工单不相同,请重新选择!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (row.Cells["PST_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS))
                    {
                        if (row.Cells["END_DATE"].Value.ToString() != "")
                        {
                            productionTechnology.ACTUAL_END_TIME = CConvert.ToDateTime(row.Cells["END_DATE"].Value.ToString());
                        }
                        else
                        {
                            MessageBox.Show("您选择的生产工单技术结束日期不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        productionTechnology.STATUS_FLAG = CConvert.ToInt32(CConstant.STATUS_START);
                        productionTechnology.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                        productionTechnology.SCHEDULE_LINE_NUMBER = CConvert.ToInt32(row.Cells["PST_SCHEDULE_LINE_NUMBER"].Value.ToString());
                        productionTechnology.SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER = CConvert.ToInt32(row.Cells["PST_SCHEDULE_PRODUCTION_PROCESS_LINE_NUNBER"].Value.ToString());
                        productionTechnology.LINE_NUMBER = CConvert.ToInt32(row.Cells["PST_TECHNOLOGY_LINE_NUMBER"].Value.ToString());
                        psppTable.AddProductionTechnology(productionTechnology);
                    }

                    else if (row.Cells["PST_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS_START))
                    {
                        MessageBox.Show("您选择的生产工单技术已结束!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            try
            {
                int result = bProductionPlanSearch.EndTechnology(psppTable);
                if (result < 1)
                {
                    MessageBox.Show("您选择的生产工单技术结束失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("您选择的生产工单技术结束成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSlipNumber.Text = "";
                    cboStatus.SelectedIndex = 0;
                    Search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("您选择的生产工单技术结束失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSlipNumber_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnSlipNumber_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnSlipType_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnSlipType_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnSlipNumber_Click(object sender, EventArgs e)
        {

            FrmProductionPlanSearch frm = new FrmProductionPlanSearch();
            frm.CTag = CConstant.ORDER_MASTER_SEARCH;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {

            }
            txtSlipNumber.Text = frm.SLIPNUMBER.ToString();
            frm.Dispose();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable technologyDt = ds.Tables[0] as DataTable;

            if (technologyDt != null)
            {

                int result = CExport.DataTableToExcel(technologyDt, CConstant.TECHNOLOGY_HEADER, CConstant.TECHNOLOGY_COLUMNS, "TECHNOLOGY", "TECHNOLOGY");
                if (result == CConstant.EXPORT_SUCCESS)
                {
                    MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == CConstant.EXPORT_FAILURE)
                {
                    MessageBox.Show("数据导出失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("没有可以导出的数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
