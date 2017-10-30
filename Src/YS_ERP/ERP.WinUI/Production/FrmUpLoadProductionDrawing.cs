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
using CZZD.ERP.Common;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Model;
using CZZD.ERP.WinUI.Production;
using System.Text.RegularExpressions;

namespace CZZD.ERP.WinUI
{
    public partial class FrmUpLoadProductionDrawing : FrmBase
    {
        public FrmUpLoadProductionDrawing()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DialogResult result = DialogResult.Cancel;
        BProductionDrawing bProductionDrawing = new BProductionDrawing();
        DataSet ds;
        private void FrmUpLoadProductionDrawing_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            cboStatus.DataSource = CCacheData.DrawingSTATUS;
            cboStatus.ValueMember = "CODE";
            cboStatus.DisplayMember = "NAME";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        public void Search()
        {

            string strWhere = GetConduction();
            ds = bProductionDrawing.GetProductionDrawing(strWhere);
            ds.Tables[0].Columns.Add("Status", Type.GetType("System.String"));
            if (ds.Tables[0].Rows.Count < 1)
            {
                txtSlipNumber.Clear();
                txtSlipType.Clear();
                txtSlipTypeName.Clear();
                cboStatus.SelectedIndex = 0;
                dateTimePicker1.Checked = false;
                dateTimePicker2.Checked = false;
                //dgvData.DataSource = ds.Tables[0];
                //dgvData.Rows.Clear();
                dgvData.Rows.Clear();
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    if (dr["PSDL_ACTUAL_END_TIME"].ToString() == "")
                    {
                        dr["PSDL_ACTUAL_END_TIME"] = DateTime.Now;
                    }
                    if (dr["PSDL_STATUS_FLAG"].ToString() == CConvert.ToString(CConstant.STATUS))
                    {

                        dr["Status"] = "未结束";
                    }
                    else if (dr["PSDL_STATUS_FLAG"].ToString() == CConvert.ToString(CConstant.STATUS_START))
                    {
                        dr["Status"] = "结束";
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
                        row.Cells["PSDL_SLIP_NUMBER"].Value = dr["PSDL_SLIP_NUMBER"];
                        row.Cells["TYPE_NAME"].Value = dr["SLIP_TYPE_NAME"];
                        row.Cells["DrawingName"].Value = dr["NAME"];
                        row.Cells["PSDL_PLAN_END_DATE"].Value = dr["PSDL_PLAN_END_DATE"];
                        row.Cells["PSDL_ACTUAL_END_TIME"].Value = dr["PSDL_ACTUAL_END_TIME"];
                        row.Cells["Status"].Value = dr["Status"];
                        row.Cells["PSDL_STATUS_FLAG"].Value = dr["PSDL_STATUS_FLAG"];
                        row.Cells["PSDL_LINE_NUMBER"].Value = dr["PSDL_LINE_NUMBER"];
                        row.Cells["PSDL_DRAWING_CODE"].Value = dr["PSDL_DRAWING_CODE"];

                    }
                }
                catch (Exception ex)
                { }

                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    if (dgvr.Cells["PSDL_STATUS_FLAG"].Value.ToString().Equals(CConvert.ToString(CConstant.STATUS_START)))
                    {
                        dgvr.Cells["CHK"].ReadOnly = true;
                        dgvr.Cells["BTN_UPLOAD"].ReadOnly = true;
                        dgvr.Cells["PSDL_ACTUAL_END_TIME"].ReadOnly = true;
                    }
                }
                #region delete
                //for (int i = 0; i < dgvData.Rows.Count; i++)
                //{
                //    if (dgvData.Rows[i].Cells["PSDL_ACTUAL_END_TIME"].Value.ToString() == "")
                //    {
                //        dgvData.Rows[i].Cells["PSDL_ACTUAL_END_TIME"].Value = DateTime.Now.ToString();
                //    }
                //    if (dgvData.Rows[i].Cells["PSDL_STATUS_FLAG"].Value.ToString() == "0")
                //    {
                //        dgvData.Rows[i].Cells["Status"].Value = "未结束";
                //    }
                //    else if (dgvData.Rows[i].Cells["PSDL_STATUS_FLAG"].Value.ToString() == "1")
                //    {
                //        dgvData.Rows[i].Cells["Status"].Value = "结束";
                //        dgvData[1, i].ReadOnly = true;
                //        dgvData[6, i].ReadOnly = true;
                //    }

                //}
                #endregion
            }
        }

        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" PSDL_STATUS_FLAG <> {0}", CConstant.DELETE);
            sb.AppendFormat(" AND  PS_STATUS_FLAG <> {0}", CConstant.PAUSE);
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat("AND PSDL_SLIP_NUMBER like '{0}'", txtSlipNumber.Text.Trim());
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
                sb.AppendFormat(" AND PSDL_STATUS_FLAG = '{0}'", cboStatus.SelectedValue.ToString());
            }
            return sb.ToString();

        }

        private void btnEndDrawing_Click(object sender, EventArgs e)
        {
            BaseProductionPlanLineTable planline = new BaseProductionPlanLineTable();
            BaseProductionPlanTable planTable = new BaseProductionPlanTable();
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
                MessageBox.Show("请选择数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        CHKSLIPNUMBER = row.Cells["PSDL_SLIP_NUMBER"].Value.ToString();
                    }
                    else if (CHKSLIPNUMBER != row.Cells["PSDL_SLIP_NUMBER"].Value.ToString())
                    {

                        MessageBox.Show("您选择的生产工单不相同,请重新选择!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (row.Cells["PSDL_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS))
                    {


                        if (row.Cells["PSDL_ACTUAL_END_TIME"].Value.ToString() != "")
                        {
                            bpsppmodel.ACTUAL_END_TIME = Convert.ToDateTime(row.Cells["PSDL_ACTUAL_END_TIME"].Value.ToString());
                        }
                        else
                        {
                            MessageBox.Show("您选择的生产工单图纸加工结束日期不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        bpsppmodel.STATUS_FLAG = 1;
                        bpsppmodel.SLIP_NUMBER = row.Cells["PSDL_SLIP_NUMBER"].Value.ToString();
                        bpsppmodel.LINE_NUMBER = Convert.ToInt32(row.Cells["PSDL_LINE_NUMBER"].Value.ToString());
                        //planTable.a
                        planline.AddProductionProcess(bpsppmodel);
                    }

                    else if (row.Cells["PSDL_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS_START))
                    {
                        MessageBox.Show("您选择的生产工单图纸加工已结束!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            try
            {
                int result = bProductionDrawing.EndDrawing(planline);
                if (result < 1)
                {
                    MessageBox.Show("您选择的生产工单图纸加工结束失败,请检查数据。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("您选择的生产工单图纸加工结束成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Search();
                }
            }
            catch (Exception ex)
            { }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)(sender);
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];
                    row.Cells["NO"].Value = e.RowIndex + 1;
                    if (row.Cells["PSDL_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS))
                    {
                        row.Cells["BTN_UPLOAD"].Value = Resources.line_upload_over;
                    }
                    else
                    {
                        row.Cells["BTN_UPLOAD"].Value = Resources.line_upload;
                    }
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

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvData.Columns["BTN_UPLOAD"].Index)
                {
                    if (dgvData.Rows[e.RowIndex].Cells["PSDL_STATUS_FLAG"].Value.ToString() == CConvert.ToString(CConstant.STATUS))
                    {

                        DrawingUpLoad frm = new DrawingUpLoad();
                        frm.SLIPNUMBER = dgvData.Rows[e.RowIndex].Cells["PSDL_SLIP_NUMBER"].Value.ToString();
                        frm.DRAWING_CODE = dgvData.Rows[e.RowIndex].Cells["PSDL_DRAWING_CODE"].Value.ToString();
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                        }

                        frm.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {


            }
        }

        private void btnSlipType_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.line_find_over);
        }

        private void btnSlipType_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.line_find);
        }

        private void FrmUpLoadProductionDrawing_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
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
            DataTable drawingDt = ds.Tables[0] as DataTable;

            if (drawingDt != null)
            {

                int result = CExport.DataTableToExcel(drawingDt, CConstant.DRAWING_HEADER, CConstant.DRAWING_COLUMNS, "DRAWING", "DRAWING");
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
        static private Regex r = new Regex("^(?:(?!0000)[0-9]{4}([-/.]?)(?:(?:0?[1-9]|1[0-2])([-/.]?)(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])([-/.]?)(?:29|30)|(?:0?[13578]|1[02])([-/.]?)31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-/.]?)0?2([-/.]?)29)");

        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {



            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvData.Columns["PSDL_ACTUAL_END_TIME"].Index)
            {
                if (dr.Cells["PSDL_ACTUAL_END_TIME"].Value != null)
                {
                    if (!r.IsMatch(dr.Cells["PSDL_ACTUAL_END_TIME"].Value.ToString().Trim()))
                    {
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
        }
    }
}
