using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;
using CZZD.ERP.Model;
using System.Text.RegularExpressions;
using CZZD.ERP.WinUI.Properties;
using System.Collections;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProduction : FrmBase
    {
        public FrmProduction()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        BProductionPlanSearch bProductionPlanSearch = new BProductionPlanSearch();
        private BSlipTypeCompositionProducts bSlipTypeCompositionProducts = new BSlipTypeCompositionProducts();
        private BaseProductionPlanTable baseProductionplantable = new BaseProductionPlanTable();
        private BProductionProcess bProductionProcess = new BProductionProcess();

        private BCompositionProductsProductionProcess bCompositionProductsProductionProcess = new BCompositionProductsProductionProcess();
        private BProductionPlan bProductionPlan = new BProductionPlan();
        private BaseProductionScheduleProductionProcessTable BpsppTable = new BaseProductionScheduleProductionProcessTable();
        private BProductionDrawing bproductionDrawing = new BProductionDrawing();
        private string _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
        private string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PRODUCTION);
        private int attachedNumber = 0;
        DataTable dt;
        private void FrmProduction_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            cboStatus.DataSource = CCacheData.STATUS;
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
             dt = bProductionPlanSearch.GetProductionPlan(strWhere).Tables[0];
            dt.Columns.Add("TECHNOLOGY_STATUS", Type.GetType("System.String"));
            dt.Columns.Add("BTN_DOWN_LOAD", Type.GetType("System.String"));
            if (dt.Rows.Count < 1)
            {
                txtSlipNumber.Clear();
                txtSlipType.Clear();
                txtSlipTypeName.Clear();
                cboStatus.SelectedIndex = 0;
                txtSlipDateFrom.Checked = false;
                txtSlipDateTo.Checked = false;
                dateTimePicker1.Checked = false;
                dateTimePicker2.Checked = false;
                //dgvData.DataSource = dt;
                dgvData.Rows.Clear();
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {

                Hashtable dwHt = new Hashtable();
                Hashtable technologyHt = new Hashtable();
                DataTable dtTechnology = bProductionPlanSearch.GetProductionTechnologyStatus(GetConductionTechnology()).Tables[0];
                DataTable dtDw = bProductionPlanSearch.GetProductionDw(GetConductionDw()).Tables[0];

                //技术判断是否结束
                foreach (DataRow dr in dtTechnology.Rows)
                {
                    string key = CConvert.ToString(dr["SLIP_NUMBER"]) + CConvert.ToString(dr["SCHEDULE_LINE_NUNBER"]) + CConvert.ToString(dr["LINE_NUMBER"]);
                    int count = CConvert.ToInt32(dr["COUNT"]);
                    int number = CConvert.ToInt32(dr["NUMBER"]);
                    if (count == number)
                    {
                        technologyHt.Add(key, "结束");
                    }
                    else if (number == 0)
                    {
                        technologyHt.Add(key, "未开始");
                    }
                    else if (count > number)
                    {
                        technologyHt.Add(key, "已开始");
                    }
                }

                //图纸判断有无
                foreach (DataRow dr in dtDw.Rows)
                {
                    string key = CConvert.ToString(dr["SLIP_NUMBER"]) + CConvert.ToString(dr["SCHEDULE_LINE_NUNBER"]) + CConvert.ToString(dr["LINE_NUMBER"]);
                    int count = CConvert.ToInt32(dr["COUNT"]);
                    int number = CConvert.ToInt32(dr["NUMBER"]);
                    if (count >= number && number != 0)
                    {
                        dwHt.Add(key, "有");
                    }
                    else if (number == 0)
                    {
                        dwHt.Add(key, "无");
                    }
                }

                //
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["PSPP_STATUS_FLAG"].ToString() == CConvert.ToString(CConstant.STATUS))
                    {
                        dr["PSPP_ACTUAL_START_TIME"] = DateTime.Now;
                    }
                    else if (dr["PSPP_STATUS_FLAG"].ToString() == CConvert.ToString(CConstant.STATUS_START))
                    {
                        dr["PSPP_ACTUAL_END_TIME"] = DateTime.Now;
                    }

                    if (dr["PSPP_STATUS_FLAG"].ToString() == CConvert.ToString(CConstant.STATUS_END))
                    {
                        dr["TECHNOLOGY_STATUS"] = "结束";
                        //dr["BTN_DOWN_LOAD"] = "结束";
                    }
                    //else
                    //{
                    //
                    string key = CConvert.ToString(dr["SLIP_NUMBER"]) + CConvert.ToString(dr["SCHEDULE_LINE_NUNBER"]) + CConvert.ToString(dr["PSPP_LINE_NUMBER"]);
                    if (technologyHt.Contains(key))
                    {
                        dr["TECHNOLOGY_STATUS"] = technologyHt[key];
                    }
                    else
                    {
                        dr["TECHNOLOGY_STATUS"] = "N/A";
                    }
                    if (dwHt.Contains(key))
                    {
                        dr["BTN_DOWN_LOAD"] = dwHt[key];
                    }
                    else
                    {
                        dr["BTN_DOWN_LOAD"] = "N/A";
                    }
                    //
                    //}
                }

                //dgvData.DataSource = dt;
                try
                {
                    if (dgvData.Rows.Count > 0)
                    {
                        dgvData.Rows.Clear();
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow row = dgvData.Rows[currentRowIndex];
                        row.Cells["SLIP_NUMBER"].Value = dr["SLIP_NUMBER"];
                        row.Cells["TYPE_NAME"].Value = dr["SLIP_TYPE_NAME"];
                        row.Cells["PARTS_NAME"].Value = dr["PARTS_NAME"];
                        row.Cells["PRODUCTION_PROCESS_NAME"].Value = dr["PRODUCTION_PROCESS_NAME"];
                        row.Cells["BTN_DOWN_LOAD"].Value = dr["BTN_DOWN_LOAD"];
                        row.Cells["TECHNOLOGY_STATUS"].Value = dr["TECHNOLOGY_STATUS"];
                        row.Cells["START_PLAN_DATE"].Value = dr["PSPP_PLAN_START_DATE"];
                        row.Cells["END_PLAN_DATE"].Value = dr["PSPP_PLAN_END_DATE"];
                        row.Cells["PSPP_ACTUAL_START_TIME"].Value = dr["PSPP_ACTUAL_START_TIME"];
                        row.Cells["PSPP_ACTUAL_END_TIME"].Value = dr["PSPP_ACTUAL_END_TIME"];
                        row.Cells["WEIGHT"].Value = dr["WEIGHT"];
                        row.Cells["PRODUCTION_PROCESS_CODE"].Value = dr["PRODUCTION_PROCESS_CODE"];
                        row.Cells["SCHEDULE_LINE_NUNBER"].Value = dr["SCHEDULE_LINE_NUNBER"];
                        row.Cells["PSPP_LINE_NUMBER"].Value = dr["PSPP_LINE_NUMBER"];
                        row.Cells["PSPP_STATUS_FLAG"].Value = dr["PSPP_STATUS_FLAG"];
                        row.Cells["PARTS_CODE"].Value = dr["PARTS_CODE"];
                        row.Cells["PROCESS_STATUS"].Value = dr["PROCESS_STATUS"];
                    }
                }
                catch (Exception ex) 
                { }

                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    if (dgvr.Cells["PROCESS_STATUS"].Value.ToString().Equals("0"))
                    {
                        dgvr.Cells["WEIGHT"].ReadOnly = true;
                    }
                    if (dgvr.Cells["PSPP_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS))
                    {
                        dgvr.Cells["PSPP_ACTUAL_END_TIME"].ReadOnly = true;
                    }
                    if (dgvr.Cells["PSPP_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS_START))
                    {
                        dgvr.Cells["PSPP_ACTUAL_START_TIME"].ReadOnly = true;
                    }

                    if ("2".Equals(CConvert.ToString(dgvr.Cells["PSPP_STATUS_FLAG"].Value)))
                    {
                        dgvr.Cells["CHK"].ReadOnly = true;
                        dgvr.Cells["PSPP_ACTUAL_START_TIME"].ReadOnly = true;
                        dgvr.Cells["PSPP_ACTUAL_END_TIME"].ReadOnly = true;
                        dgvr.Cells["WEIGHT"].ReadOnly = true;
                    }
                    #region delete
                    //string _oldSlipNumber = dgvData.Rows[i].Cells["SLIP_NUMBER"].Value.ToString();
                    //string productionProcessCode = dgvData.Rows[i].Cells["PRODUCTION_PROCESS_CODE"].Value.ToString();
                    //Hashtable dwHt = new Hashtable();
                    //DataTable productionProcessDt = bProductionProcess.GetList(" CODE = '" + productionProcessCode + "'").Tables[0];
                    //foreach (DataRow dr in productionProcessDt.Rows)
                    //{
                    //    for (int l = 1; l <= 6; l++)
                    //    {
                    //        string dwCode = CConvert.ToString(dr["DRAWING_TYPE_CODE" + l]);
                    //        if (string.IsNullOrEmpty(dwCode))
                    //        {
                    //            continue;
                    //        }
                    //        if (dwHt.ContainsKey(dwCode))
                    //        {

                    //        }
                    //        else
                    //        {
                    //            dwHt.Add(dwCode, "");
                    //        }

                    //    }
                    //}

                    //foreach (DictionaryEntry de in dwHt)
                    //{
                    //    DataTable drawingDt = new DataTable();
                    //    string drawingcode = de.Key.ToString();
                    //    drawingDt = bproductionDrawing.GetProductionDrawingUpload(" SLIP_NUMBER = '" + _oldSlipNumber + "'" + " AND DRAWING_CODE = '" + drawingcode + "'").Tables[0];

                    //    if (drawingDt.Rows.Count > 0)
                    //    {
                    //        dgvData.Rows[i].Cells["BTN_DOWN_LOAD"].Value = "有";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        dgvData.Rows[i].Cells["BTN_DOWN_LOAD"].Value = "无";
                    //    }

                    //}
                    #endregion
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
                sb.AppendFormat(" AND PSPP_STATUS_FLAG = '{0}'", cboStatus.SelectedValue.ToString());
            }
            return sb.ToString();

        }

        private string GetConductionTechnology()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" PST.SLIP_NUMBER IS NOT NULL ");
            sb.AppendFormat(" AND PSPP.STATUS_FLAG <> 9");
            sb.AppendFormat(" AND DEPARTMENT_CODE='{0}'", UserTable.DEPARTMENT_CODE);
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat("AND PSPP.SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }
            return sb.ToString();
        }

        private string GetConductionDw()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("  PSPP.STATUS_FLAG <> 9");
            sb.AppendFormat(" AND PPDV.DEPARTMENT_CODE='{0}'", UserTable.DEPARTMENT_CODE);
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat("AND PSPP.SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }
            return sb.ToString();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            BaseProductionPlanLineTable planline = new BaseProductionPlanLineTable();
            BaseProductionPlanTable PlanTable = new BaseProductionPlanTable();
            BaseProductionScheduleProductionProcessTable bpsppmodel = null;
            int CHKchooseCount = 0;
            //int CHKChoosesame = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["CHK"].Value) == true)
                {
                    CHKchooseCount++;
                }
            }
            if (CHKchooseCount < 1)
            {
                MessageBox.Show("请选择加工开始的数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string CHKSLIPNUMBER = "";
            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                bpsppmodel = new BaseProductionScheduleProductionProcessTable();
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
                    if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS))
                    {

                        if (row.Cells["PSPP_ACTUAL_START_TIME"].Value.ToString() != "")
                        {
                            bpsppmodel.ACTUAL_START_TIME = CConvert.ToDateTime(row.Cells["PSPP_ACTUAL_START_TIME"].Value.ToString());
                        }
                        else
                        {
                            MessageBox.Show("您选择的生产工单加工开始日期不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (row.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString() != "")
                        {
                            bpsppmodel.ACTUAL_END_TIME = CConvert.ToDateTime(row.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString());
                        }
                        else
                        { }
                        bpsppmodel.STATUS_FLAG = 1;
                        bpsppmodel.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                        bpsppmodel.SCHEDULE_LINE_NUNBER = CConvert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                        bpsppmodel.LINE_NUMBER = CConvert.ToInt32(row.Cells["PSPP_LINE_NUMBER"].Value.ToString());
                        // model.AddProductionProcess(bpsppmodel);
                        PlanTable.AddItemProductionProcess(bpsppmodel);
                    }

                    else if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS_START))
                    {
                        MessageBox.Show("您选择的生产工单加工已开始!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS_END))
                    {
                        MessageBox.Show("您选择的生产工单加工已结束!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    #region   更改明细中的status
                    //string strWhere = "SLIP_NUMBER=" + row.Cells["SLIP_NUMBER"].Value.ToString() + " AND SCHEDULE_LINE_NUNBER=" + Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                    //DataSet ds = bProductionPlanSearch.GetProductionPlan(strWhere);
                    //int status = 0;
                    //int endstatus = 0;
                    //int count = ds.Tables[0].Rows.Count;
                    //foreach (DataRow dt in ds.Tables[0].Rows)
                    //{
                    //    if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 0)
                    //    {
                    //        status++;
                    //    }
                    //    else if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == 2)
                    //    {
                    //        endstatus++;
                    //    }
                    //}
                    //if (status == count)
                    //{

                    //}
                    //else if (endstatus == count)
                    //{
                    //    planline = new BaseProductionPlanLineTable();
                    //    planline.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    planline.LINE_NUMBER = Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                    //    planline.STATUS_FLAG = 2;
                    //    PlanTable.AddItem(planline);
                    //}
                    //else
                    //{
                    //    planline = new BaseProductionPlanLineTable();
                    //    planline.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    planline.LINE_NUMBER = Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                    //    planline.STATUS_FLAG = 1;
                    //    PlanTable.AddItem(planline);
                    //}
                    //#endregion
                    //#region 更改status
                    //string strWhere1 = "SLIP_NUMBER=" + row.Cells["SLIP_NUMBER"].Value.ToString();
                    //DataSet scheduleds = bProductionPlanSearch.GetProductionPlan(strWhere1);
                    //int schedulestatus = 0;
                    //int scheduleendstatus = 0;
                    //int schedulecount = scheduleds.Tables[0].Rows.Count;
                    //foreach (DataRow dt in scheduleds.Tables[0].Rows)
                    //{
                    //    if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 0)
                    //    {
                    //        schedulestatus++;
                    //    }
                    //    else if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == 2)
                    //    {
                    //        scheduleendstatus++;
                    //    }
                    //}
                    //if (schedulestatus == schedulecount)
                    //{

                    //}
                    //else if (scheduleendstatus == schedulecount)
                    //{

                    //    PlanTable.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    PlanTable.STATUS_FLAG = 2;
                    //}
                    //else
                    //{
                    //    PlanTable.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                    //    PlanTable.STATUS_FLAG = 1;
                    //}
                    #endregion
                }
            }

            try
            {
                int result = bProductionPlanSearch.StartProcessing(PlanTable);
                if (result < 1)
                {
                    MessageBox.Show("您选择的生产工单加工开始失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (BaseProductionScheduleProductionProcessTable bpspptable in PlanTable.ItemsProductionProcess)
                    {// + " AND SCHEDULE_LINE_NUNBER=" + bpspptable.SCHEDULE_LINE_NUNBER
                        string strWhere = "SLIP_NUMBER=" + bpspptable.SLIP_NUMBER;
                        DataSet ds = bProductionPlanSearch.GetProductionPlan(strWhere);
                        int status = 0;
                        int endstatus = 0;
                        int count = ds.Tables[0].Rows.Count;
                        foreach (DataRow dt in ds.Tables[0].Rows)
                        {
                            if (CConvert.ToInt32(dt["PSPP_STATUS_FLAG"]) == CConvert.ToInt32(CConstant.STATUS))
                            {
                                status++;
                            }
                            else if (CConvert.ToInt32(dt["PSPP_STATUS_FLAG"]) == CConvert.ToInt32(CConstant.STATUS_END))
                            {
                                endstatus++;
                            }
                        }
                        if (status == count)
                        {

                        }
                        else if (endstatus == count)
                        {
                            planline = new BaseProductionPlanLineTable();
                            planline.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            planline.LINE_NUMBER = CConvert.ToInt32(bpspptable.SCHEDULE_LINE_NUNBER);
                            planline.STATUS_FLAG = CConvert.ToInt32(CConstant.STATUS_END);
                            PlanTable.AddItem(planline);
                        }
                        else
                        {
                            planline = new BaseProductionPlanLineTable();
                            planline.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            planline.LINE_NUMBER = CConvert.ToInt32(bpspptable.SCHEDULE_LINE_NUNBER);
                            planline.STATUS_FLAG = CConvert.ToInt32(CConstant.STATUS_START);
                            PlanTable.AddItem(planline);
                        }
                    }

                    try
                    {
                        int resultstatus = bProductionPlanSearch.LineStatus(PlanTable);
                    }
                    catch (Exception ex)
                    {

                    }
                    foreach (BaseProductionScheduleProductionProcessTable bpspptable in PlanTable.ItemsProductionProcess)
                    {
                        //更改status
                        string strWhere1 = "SLIP_NUMBER=" + bpspptable.SLIP_NUMBER;
                        DataSet scheduleds = bProductionPlanSearch.GetProductionPlan(strWhere1);
                        int schedulestatus = 0;
                        int scheduleendstatus = 0;
                        int schedulecount = scheduleds.Tables[0].Rows.Count;
                        foreach (DataRow dt in scheduleds.Tables[0].Rows)
                        {
                            if (CConvert.ToInt32(dt["PSL_STATUS_FLAG"]) == CConvert.ToInt32(CConstant.STATUS))
                            {
                                schedulestatus++;
                            }
                            else if (CConvert.ToInt32(dt["PSL_STATUS_FLAG"]) == CConvert.ToInt32(CConstant.STATUS_END))
                            {
                                scheduleendstatus++;
                            }
                        }
                        if (schedulestatus == schedulecount)
                        {

                        }
                        else if (scheduleendstatus == schedulecount)
                        {
                            PlanTable.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            PlanTable.STATUS_FLAG = CConvert.ToInt32(CConstant.STATUS_END);
                        }
                        else
                        {
                            PlanTable.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            PlanTable.STATUS_FLAG = CConvert.ToInt32(CConstant.STATUS_START);
                        }
                    }
                    try
                    {
                        int resultschedule = bProductionPlanSearch.Status(PlanTable);
                    }
                    catch (Exception ex)
                    {

                    }
                    MessageBox.Show("您选择的生产工单加工开始成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSlipNumber.Text = "";
                    cboStatus.SelectedIndex = 0;
                    Search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("您选择的生产工单加工开始失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            BaseProductionPlanLineTable planline = new BaseProductionPlanLineTable();
            BaseProductionPlanTable PlanTable = new BaseProductionPlanTable();
            BaseProductionScheduleProductionProcessTable bpsppmodel = null;
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
                MessageBox.Show("请选择加工结束的数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string CHKSLIPNUMBER = "";

            for (int i = 0; i < dgvData.Rows.Count; i++)
            {
                bpsppmodel = new BaseProductionScheduleProductionProcessTable();
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
                    if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS_START))
                    {

                        bpsppmodel.ACTUAL_START_TIME = Convert.ToDateTime(row.Cells["PSPP_ACTUAL_START_TIME"].Value.ToString());
                        if (row.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString() != "")
                        {
                            bpsppmodel.ACTUAL_END_TIME = Convert.ToDateTime(row.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString());
                        }
                        else
                        {
                            MessageBox.Show("您选择的生产工单加工结束日期不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (DateTime.Compare(Convert.ToDateTime(bpsppmodel.ACTUAL_START_TIME), Convert.ToDateTime(bpsppmodel.ACTUAL_END_TIME)) > 0)
                        {
                            MessageBox.Show("您选择的生产工单加工开始日期不能大于加工结束日期!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        bpsppmodel.STATUS_FLAG = 2;
                        bpsppmodel.SLIP_NUMBER = row.Cells["SLIP_NUMBER"].Value.ToString();
                        bpsppmodel.SCHEDULE_LINE_NUNBER = Convert.ToInt32(row.Cells["SCHEDULE_LINE_NUNBER"].Value.ToString());
                        bpsppmodel.LINE_NUMBER = Convert.ToInt32(row.Cells["PSPP_LINE_NUMBER"].Value.ToString());
                        if (row.Cells["WEIGHT"].Value != null)
                        {
                            bpsppmodel.WEIGHT = row.Cells["WEIGHT"].Value.ToString();
                        }
                        PlanTable.AddItemProductionProcess(bpsppmodel);
                    }
                    else if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS))
                    {
                        MessageBox.Show("您选择的生产工单加工未开始!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (row.Cells["PSPP_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS_END))
                    {
                        MessageBox.Show("您选择的生产工单加工已结束!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            try
            {
                int result = bProductionPlanSearch.StartProcessing(PlanTable);
                if (result < 1)
                {
                    MessageBox.Show("您选择的生产工单加工结束失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (BaseProductionScheduleProductionProcessTable bpspptable in PlanTable.ItemsProductionProcess)
                    {//+ " AND SCHEDULE_LINE_NUNBER=" + bpspptable.SCHEDULE_LINE_NUNBER
                        string strWhere = "SLIP_NUMBER=" + bpspptable.SLIP_NUMBER;
                        DataSet ds = bProductionPlanSearch.GetProductionPlan(strWhere);
                        int status = 0;
                        int endstatus = 0;
                        int count = ds.Tables[0].Rows.Count;
                        foreach (DataRow dt in ds.Tables[0].Rows)
                        {
                            if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == CConvert.ToInt32(CConstant.STATUS))
                            {
                                status++;
                            }
                            else if (Convert.ToInt32(dt["PSPP_STATUS_FLAG"]) == CConvert.ToInt32(CConstant.STATUS_END))
                            {
                                endstatus++;
                            }
                        }
                        if (status == count)
                        {

                        }
                        else if (endstatus == count)
                        {
                            planline = new BaseProductionPlanLineTable();
                            planline.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            planline.LINE_NUMBER = Convert.ToInt32(bpspptable.SCHEDULE_LINE_NUNBER);
                            planline.STATUS_FLAG = CConvert.ToInt32(CConstant.STATUS_END);
                            PlanTable.AddItem(planline);
                        }
                        else
                        {
                            planline = new BaseProductionPlanLineTable();
                            planline.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            planline.LINE_NUMBER = Convert.ToInt32(bpspptable.SCHEDULE_LINE_NUNBER);
                            planline.STATUS_FLAG = CConvert.ToInt32(CConstant.STATUS_START);
                            PlanTable.AddItem(planline);
                        }
                    }

                    try
                    {
                        int resultstatus = bProductionPlanSearch.LineStatus(PlanTable);
                    }
                    catch (Exception ex)
                    {

                    }
                    foreach (BaseProductionScheduleProductionProcessTable bpspptable in PlanTable.ItemsProductionProcess)
                    {
                        //更改status
                        string strWhere1 = "SLIP_NUMBER=" + bpspptable.SLIP_NUMBER;
                        DataSet scheduleds = bProductionPlanSearch.GetProductionPlan(strWhere1);
                        int schedulestatus = 0;
                        int scheduleendstatus = 0;
                        int schedulecount = scheduleds.Tables[0].Rows.Count;
                        foreach (DataRow dt in scheduleds.Tables[0].Rows)
                        {
                            if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == CConvert.ToInt32(CConstant.STATUS))
                            {
                                schedulestatus++;
                            }
                            else if (Convert.ToInt32(dt["PSL_STATUS_FLAG"]) == CConvert.ToInt32(CConstant.STATUS_END))
                            {
                                scheduleendstatus++;
                            }
                        }
                        if (schedulestatus == schedulecount)
                        {

                        }
                        else if (scheduleendstatus == schedulecount)
                        {
                            PlanTable.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            PlanTable.STATUS_FLAG = CConvert.ToInt32(CConstant.STATUS_END);

                            PlanTable.ACTUAL_END_TIME = CConvert.ToDateTime(scheduleds.Tables[0].Compute("Max(PSPP_ACTUAL_END_TIME)", "true"));

                        }
                        else
                        {
                            PlanTable.SLIP_NUMBER = bpspptable.SLIP_NUMBER;
                            PlanTable.STATUS_FLAG = CConvert.ToInt32(CConstant.STATUS_START);
                        }
                    }
                    try
                    {
                        int resultschedule = bProductionPlanSearch.Status(PlanTable);
                    }
                    catch (Exception ex)
                    {

                    }

                    MessageBox.Show("您选择的生产工单加工结束成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSlipNumber.Text = "";
                    cboStatus.SelectedIndex = 0;
                    Search();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("您选择的生产工单加工结束失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        static private Regex r = new Regex("^(?:(?!0000)[0-9]{4}([-/.]?)(?:(?:0?[1-9]|1[0-2])([-/.]?)(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])([-/.]?)(?:29|30)|(?:0?[13578]|1[02])([-/.]?)31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-/.]?)0?2([-/.]?)29)");
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvData.Columns["PSPP_ACTUAL_START_TIME"].Index)
            {
                if (dr.Cells["PSPP_ACTUAL_START_TIME"].Value.ToString() != "")
                {
                    if (!r.IsMatch(dr.Cells["PSPP_ACTUAL_START_TIME"].Value.ToString().Trim()))
                    {
                        //MessageBox.Show("请输入正确的日期");
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
            if (e.ColumnIndex == dgvData.Columns["PSPP_ACTUAL_END_TIME"].Index)
            {
                if (dr.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString() != "")
                {
                    if (!r.IsMatch(dr.Cells["PSPP_ACTUAL_END_TIME"].Value.ToString().Trim()))
                    {
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // MessageBox.Show("请输入正确的日期");
                        dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
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
                            CTag = "productionProcess";
                            string partsCode = "";
                            FrmProductionDownLoad frm = new FrmProductionDownLoad(_oldSlipNumber, _attachedDirectory, productionProcessCode, CTag, partsCode);
                            frm.ShowDialog(this);
                            frm.Dispose();
                        }
                    }

                }
            }
            catch (Exception ex) { }
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
            DataTable productionDt = dt as DataTable;

            if (productionDt != null)
            {

                int result = CExport.DataTableToExcel(productionDt, CConstant.PRODUCTION_HEADER, CConstant.PRODUCTION_COLUMNS, "PRODUCTION", "PRODUCTION");
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


