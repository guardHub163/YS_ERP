using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.WinUI.Properties;
using System.Collections;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using System.Text.RegularExpressions;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionPlanDetails : FrmBase
    {
        public FrmProductionPlanDetails()
        {
            InitializeComponent();
        }
        BProductionProcess BProductionProcess = new BProductionProcess();
        BCompositionProductsProductionProcess BCompositionProductsProductionProcess = new BCompositionProductsProductionProcess();
        private DialogResult result = DialogResult.Cancel;
        private DataTable dt;

        public DataTable DT
        {
            get { return dt; }
            set { dt = value; }
        }

        private BaseProductionPlanTable planTable;

        public BaseProductionPlanTable PLANTABLE
        {
            get { return planTable; }
            set { planTable = value; }
        }

        private string _type_name;
        private string _parts_code;
        private DateTime _plan_start_time;
        private DateTime _plan_end_time;
        private string _spec;
        private decimal _plan_quantity;
        private string _type_code;
        private string _parts_name;

        private int _dgv_count;


        public int DGV_COUNT
        {
            set { _dgv_count = value; }
            get { return _dgv_count; }
        }
        public string TYPE_NAME
        {
            set { _type_name = value; }
            get { return _type_name; }
        }


        public string PARTS_NAME
        {
            set { _parts_name = value; }
            get { return _parts_name; }
        }

        public string PARTS_CODE
        {
            set { _parts_code = value; }
            get { return _parts_code; }
        }

        public DateTime PLAN_START_DATE
        {
            set { _plan_start_time = value; }
            get { return _plan_start_time; }
        }

        public DateTime PLAN_END_DATE
        {
            set { _plan_end_time = value; }
            get { return _plan_end_time; }
        }

        public string SPEC
        {
            set { _spec = value; }
            get { return _spec; }
        }

        public decimal PLAN_QUANTITY
        {
            set { _plan_quantity = value; }
            get { return _plan_quantity; }
        }


        public string TYPE_CODE
        {
            set { _type_code = value; }
            get { return _type_code; }
        }



        BaseProductionPlanTable baseProductionplantable = new BaseProductionPlanTable();
        private void FrmProductionPlanDetails_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            txtProductionQuantity.Text = _plan_quantity.ToString();
            textBox2.Text = planTable.SLIP_TYPE_NAME;
            textBox3.Text = _parts_name;
            textBox1.Text = planTable.SPEC;
            txtSlipDateFrom.Value = _plan_start_time;
            txtDepartualDateFrom.Value = _plan_end_time;
            if (CConstant.PRODUCTIONPLAN_OPERATE.Equals(CTag))
            {
                dgvData.Columns["START_DATE"].ReadOnly = true;
                dgvData.Columns["END_DATE"].ReadOnly = true;
                dgvData.Columns["PRODUCTION_CYCLE"].ReadOnly = true;
                this.btnAddProductionProcess.Visible = false;
                this.btnSave.Visible = false;
                this.btnDown.Visible = false;
                this.btnUp.Visible = false;
            }

            else if (CConstant.PRODUCTIONPLAN_MODIFY.Equals(CTag))
            {
                dgvData.Columns["START_DATE"].ReadOnly = true;
                dgvData.Columns["END_DATE"].ReadOnly = true;
                this.btnAddProductionProcess.Visible = false;
                //this.btnSave.Visible = false;
                this.btnDown.Visible = false;
                this.btnUp.Visible = false;

            }

            foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
            {
                if (lineTable.PARTS_CODE == PARTS_CODE)
                {
                    foreach (BaseProductionScheduleProductionProcessTable productionProcessTable in lineTable.ProductionProcess)
                    {
                        object[] dgvr = { "", productionProcessTable.PRODUCTION_PROCESS_CODE, productionProcessTable.PRODUCTION_PROCESS_NAME, productionProcessTable.DEPARTMENT_CODE, productionProcessTable.DEPARTMENT_NAME, productionProcessTable.PLAN_START_DATE, productionProcessTable.PLAN_END_DATE, productionProcessTable.STATUS_FLAG };
                        dgvData.Rows.Add(dgvr);
                    }
                }
            }
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                string dateDiff = null;
                TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(CConvert.ToDateTime(dr.Cells["START_DATE"].Value).ToShortDateString()).Ticks);
                TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(CConvert.ToDateTime(dr.Cells["END_DATE"].Value).ToShortDateString()).Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                dateDiff = ts.Days.ToString();
                dr.Cells["PRODUCTION_CYCLE"].Value = CConvert.ToInt32(dateDiff);
                if (CConstant.PRODUCTIONPLAN_OPERATE.Equals(CTag) || CConstant.PRODUCTIONPLAN_MODIFY.Equals(CTag))
                {
                    if (CConvert.ToInt32(dr.Cells["FLAG"].Value).Equals(2))
                    {

                        dr.Cells["STATUS_FLAG"].Value = "已结束";
                        dr.Cells["PRODUCTION_CYCLE"].ReadOnly = true;
                    }
                    else
                    {
                        dr.Cells["STATUS_FLAG"].Value = "未结束";
                    }
                }
            }

        }

        private void btnAddProductionProcess_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("PRODUCTION_PROCESS", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                string strWhere = " CODE = " + "'" + frm.BaseMasterTable.Code + "'";
                DataSet ds = BProductionProcess.GetList(strWhere);
                string departmentcode = ds.Tables[0].Rows[0]["DEPARTMENT_CODE"].ToString().Trim();
                string departmentname = ds.Tables[0].Rows[0]["DEPARTMENT_NAME"].ToString().Trim();
                decimal productioncycle = CConvert.ToDecimal(ds.Tables[0].Rows[0]["PRODUCTION_CYCLE"].ToString().Trim());
                if (dgvData.Rows.Count > 0)
                {
                    int dgvrow = dgvData.Rows.Count - 1;
                    DateTime StartDate = CConvert.ToDateTime(dgvData.Rows[dgvrow].Cells["END_DATE"].Value.ToString());
                    DateTime EndDate = StartDate.AddDays(CConvert.ToDouble(productioncycle) + 0D);
                    object[] rows = { "", frm.BaseMasterTable.Code, frm.BaseMasterTable.Name, departmentcode, departmentname, StartDate, EndDate, "", productioncycle };
                    dgvData.Rows.Add(rows);
                }
                else
                {
                    DateTime EndDate = CConvert.ToDateTime(txtSlipDateFrom.Text).AddDays(CConvert.ToDouble(productioncycle) + 0D);
                    object[] rows = { "", frm.BaseMasterTable.Code, frm.BaseMasterTable.Name, departmentcode, departmentname, txtSlipDateFrom.Text, EndDate, "", productioncycle };
                    dgvData.Rows.Add(rows);
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
                    //
                    row.Cells["NO"].Value = e.RowIndex + 1;

                    //按钮图片 
                    row.Cells["BTN_DELETE"].Value = Resources.line_delete;
                    row.Cells["PRODUCTION_CYCLE"].Style.BackColor = COLOR_INFO;
                    row.Cells["BTN_DELETE"].Style.BackColor = Color.White;

                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("工序不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (CConvert.ToDateTime(CConvert.ToDateTime(dr.Cells["END_DATE"].Value).ToShortDateString()) > CConvert.ToDateTime(CConvert.ToDateTime(planTable.PLAN_END_DATE).ToShortDateString()))
                {
                    if (DialogResult.OK == MessageBox.Show("此部件预定日期超出此工单预定完成日期,确定要调整吗，确定后不能返回？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                    {
                        foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                        {
                            if (lineTable.PARTS_CODE == PARTS_CODE)
                            {
                                lineTable.ProductionProcess.Clear();
                                lineTable.PLAN_START_DATE = CConvert.ToDateTime(dgvData.Rows[0].Cells["START_DATE"].Value.ToString());
                                lineTable.PLAN_END_DATE = CConvert.ToDateTime(dgvData.Rows[dgvData.Rows.Count - 1].Cells["END_DATE"].Value.ToString());
                                int ProductionProcessLineNumber = 1;
                                foreach (DataGridViewRow dr2 in dgvData.Rows)
                                {
                                    BaseProductionScheduleProductionProcessTable productionProcessTable = new BaseProductionScheduleProductionProcessTable();
                                    productionProcessTable.PRODUCTION_PROCESS_CODE = CConvert.ToString(dr2.Cells["PRODUCTION_PROCESS_CODE"].Value);
                                    productionProcessTable.PRODUCTION_PROCESS_NAME = CConvert.ToString(dr2.Cells["PRODUCTION_PROCESS_NAME"].Value);
                                    productionProcessTable.DEPARTMENT_CODE = CConvert.ToString(dr2.Cells["DEPARTMENT_CODE"].Value);
                                    productionProcessTable.DEPARTMENT_NAME = CConvert.ToString(dr2.Cells["DEPARTMENT_NAME"].Value);
                                    productionProcessTable.PLAN_START_DATE = CConvert.ToDateTime(dr2.Cells["START_DATE"].Value);
                                    productionProcessTable.PLAN_END_DATE = CConvert.ToDateTime(dr2.Cells["END_DATE"].Value);
                                    productionProcessTable.LINE_NUMBER = ProductionProcessLineNumber++;
                                    productionProcessTable.SCHEDULE_LINE_NUNBER = lineTable.LINE_NUMBER;
                                    productionProcessTable.PRODUCTION_CYCLE = CConvert.ToInt32(dr2.Cells["PRODUCTION_CYCLE"].Value);
                                    lineTable.AddProductionProcess(productionProcessTable);
                                }
                            }
                        }
                        result = DialogResult.OK;
                        this.Close();
                    }
                    else 
                    {
                        dgvData.Rows.Clear();
                        foreach (BaseProductionPlanLineTable lineTable in planTable.Items)
                        {
                            if (lineTable.PARTS_CODE == PARTS_CODE)
                            {
                                foreach (BaseProductionScheduleProductionProcessTable productionProcessTable in lineTable.ProductionProcess)
                                {
                                    object[] dgvr = { "", productionProcessTable.PRODUCTION_PROCESS_CODE, productionProcessTable.PRODUCTION_PROCESS_NAME, productionProcessTable.DEPARTMENT_CODE, productionProcessTable.DEPARTMENT_NAME, productionProcessTable.PLAN_START_DATE, productionProcessTable.PLAN_END_DATE, productionProcessTable.STATUS_FLAG };
                                    dgvData.Rows.Add(dgvr);
                                }
                            }
                        }
                        foreach (DataGridViewRow dr1 in dgvData.Rows)
                        {
                            string dateDiff = null;
                            TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(CConvert.ToDateTime(dr1.Cells["START_DATE"].Value).ToShortDateString()).Ticks);
                            TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(CConvert.ToDateTime(dr1.Cells["END_DATE"].Value).ToShortDateString()).Ticks);
                            TimeSpan ts = ts1.Subtract(ts2).Duration();
                            dateDiff = ts.Days.ToString();
                            dr1.Cells["PRODUCTION_CYCLE"].Value = CConvert.ToInt32(dateDiff);
                            if (CConstant.PRODUCTIONPLAN_OPERATE.Equals(CTag) || CConstant.PRODUCTIONPLAN_MODIFY.Equals(CTag))
                            {
                                if (CConvert.ToInt32(dr1.Cells["FLAG"].Value).Equals(2))
                                {

                                    dr1.Cells["STATUS_FLAG"].Value = "已结束";
                                    dr1.Cells["PRODUCTION_CYCLE"].ReadOnly = true;
                                }
                                else
                                {
                                    dr1.Cells["STATUS_FLAG"].Value = "未结束";
                                }
                            }
                        }
                    }
                    break;
                }
            }

        }

        private void FrmProductionPlanDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CConstant.QUOTATION_OPERATE.Equals(CTag))
            { }
            else
            {
                if (e.ColumnIndex == dgvData.Columns["BTN_DELETE"].Index)
                {
                    if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        if (dgvData.Rows.Count != 1)
                        {
                            DateTime a = DateTime.Parse(dgvData.Rows[e.RowIndex].Cells["END_DATE"].Value.ToString());
                            DateTime b = DateTime.Parse(dgvData.Rows[e.RowIndex].Cells["START_DATE"].Value.ToString());
                            TimeSpan ts = a - b;
                            string[] tsspan = ts.ToString().Split('.');
                            string date = tsspan[0].ToString();
                            dgvData.Rows.Remove(dgvData.Rows[e.RowIndex]);
                            for (int j = e.RowIndex; j < dgvData.Rows.Count; j++)
                            {
                                if (e.RowIndex == 0)
                                {
                                    if (j == e.RowIndex)
                                    {
                                        dgvData.Rows[e.RowIndex].Cells["START_DATE"].Value = DateTime.Parse(txtSlipDateFrom.Text.Trim());
                                    }
                                    else
                                    {
                                        dgvData.Rows[j].Cells["START_DATE"].Value = DateTime.Parse(dgvData.Rows[j - 1].Cells["END_DATE"].Value.ToString());
                                    }
                                    if (date.Equals("00:00:00"))
                                    {
                                        dgvData.Rows[j].Cells["END_DATE"].Value = DateTime.Parse(dgvData.Rows[j].Cells["END_DATE"].Value.ToString());
                                    }
                                    else
                                    {
                                        dgvData.Rows[j].Cells["END_DATE"].Value = DateTime.Parse(dgvData.Rows[j].Cells["END_DATE"].Value.ToString()).AddDays(-int.Parse(date));
                                    }
                                }
                                else
                                {
                                    dgvData.Rows[j].Cells["START_DATE"].Value = DateTime.Parse(dgvData.Rows[j - 1].Cells["END_DATE"].Value.ToString());
                                    if (date.Equals("00:00:00"))
                                    {
                                        dgvData.Rows[j].Cells["END_DATE"].Value = DateTime.Parse(dgvData.Rows[j].Cells["END_DATE"].Value.ToString());
                                    }
                                    else
                                    {
                                        dgvData.Rows[j].Cells["END_DATE"].Value = DateTime.Parse(dgvData.Rows[j].Cells["END_DATE"].Value.ToString()).AddDays(-int.Parse(date));
                                    }
                                }
                            }

                        }
                        else
                        {
                            dgvData.Rows.Remove(dgvData.Rows[e.RowIndex]);
                        }
                    }
                }
            }
        }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        static private Regex r = new Regex("^(?:(?!0000)[0-9]{4}([-/.]?)(?:(?:0?[1-9]|1[0-2])([-/.]?)(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])([-/.]?)(?:29|30)|(?:0?[13578]|1[02])([-/.]?)31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)([-/.]?)0?2([-/.]?)29)");
        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvData.Rows[e.RowIndex];
            if (e.ColumnIndex == dgvData.Columns["START_DATE"].Index)
            {
                if (dr.Cells["START_DATE"].Value != null)
                {
                    if (!r.IsMatch(dr.Cells["START_DATE"].Value.ToString().Trim()))
                    {
                        MessageBox.Show("请输入正确的日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
            else if (e.ColumnIndex == dgvData.Columns["END_DATE"].Index)
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

            else if (e.ColumnIndex == dgvData.Columns["PRODUCTION_CYCLE"].Index)
            {
                int j = 0;
                foreach (DataGridViewRow dr1 in dgvData.Rows)
                {
                    string strWhere = " CODE = " + "'" + dr.Cells["PRODUCTION_PROCESS_CODE"].Value.ToString() + "'";
                    DataSet ds = BProductionProcess.GetList(strWhere);

                    decimal productioncycle = CConvert.ToDecimal(ds.Tables[0].Rows[0]["PRODUCTION_CYCLE"].ToString().Trim());
                    if (j != 0)
                    {
                        dr1.Cells["START_DATE"].Value = CConvert.ToDateTime(dgvData.Rows[j - 1].Cells["END_DATE"].Value.ToString()).AddDays(1);
                        dr1.Cells["END_DATE"].Value = CConvert.ToDateTime(dgvData.Rows[j].Cells["START_DATE"].Value.ToString()).AddDays(CConvert.ToDouble(dgvData.Rows[j].Cells["PRODUCTION_CYCLE"].Value) + 0D);
                        j++;
                    }
                    else
                    {
                        dr1.Cells["START_DATE"].Value = txtSlipDateFrom.Text;
                        dr1.Cells["END_DATE"].Value = CConvert.ToDateTime(txtSlipDateFrom.Text).AddDays(CConvert.ToDouble(dgvData.Rows[0].Cells["PRODUCTION_CYCLE"].Value) + 0D);
                        j++;
                    }
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择一行记录。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow dgvr = dgvData.SelectedRows[0];
            int index = dgvr.Index;
            if (index == 0)
            {
                MessageBox.Show("选中行己经是第一行了。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow newDgvr = (DataGridViewRow)dgvr.Clone();
            for (int i = 0; i < dgvr.Cells.Count; i++)
            {
                newDgvr.Cells[i].Value = dgvr.Cells[i].Value;
            }
            dgvData.Rows.Insert(index - 1, newDgvr);
            dgvData.Rows[index - 1].Selected = true;
            dgvData.Rows.RemoveAt(index + 1);
            int j = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                string strWhere = " CODE = " + "'" + dr.Cells["PRODUCTION_PROCESS_CODE"].Value.ToString() + "'";
                DataSet ds = BProductionProcess.GetList(strWhere);

                decimal productioncycle = CConvert.ToDecimal(ds.Tables[0].Rows[0]["PRODUCTION_CYCLE"].ToString().Trim());
                if (j != 0)
                {
                    dr.Cells["START_DATE"].Value = CConvert.ToDateTime(dgvData.Rows[j - 1].Cells["END_DATE"].Value.ToString());
                    dr.Cells["END_DATE"].Value = CConvert.ToDateTime(dgvData.Rows[j].Cells["START_DATE"].Value.ToString()).AddDays(CConvert.ToDouble(productioncycle) + 0D);
                    j++;
                }
                else
                {
                    dr.Cells["START_DATE"].Value = txtSlipDateFrom.Text;
                    dr.Cells["END_DATE"].Value = CConvert.ToDateTime(txtSlipDateFrom.Text).AddDays(CConvert.ToDouble(productioncycle) + 0D);
                    j++;
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选择一行记录。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow dgvr = dgvData.SelectedRows[0];
            int index = dgvr.Index;
            if (index == dgvData.Rows.Count - 1)
            {
                MessageBox.Show("选中行己经是最后一行了。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow newDgvr = (DataGridViewRow)dgvr.Clone();
            for (int i = 0; i < dgvr.Cells.Count; i++)
            {
                newDgvr.Cells[i].Value = dgvr.Cells[i].Value;
            }
            dgvData.Rows.RemoveAt(index);
            dgvData.Rows.Insert(index + 1, newDgvr);
            dgvData.Rows[index + 1].Selected = true;
            int j = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                string strWhere = " CODE = " + "'" + dr.Cells["PRODUCTION_PROCESS_CODE"].Value.ToString() + "'";
                DataSet ds = BProductionProcess.GetList(strWhere);

                decimal productioncycle = CConvert.ToDecimal(ds.Tables[0].Rows[0]["PRODUCTION_CYCLE"].ToString().Trim());
                if (j != 0)
                {
                    dr.Cells["START_DATE"].Value = CConvert.ToDateTime(dgvData.Rows[j - 1].Cells["END_DATE"].Value.ToString());
                    dr.Cells["END_DATE"].Value = CConvert.ToDateTime(dgvData.Rows[j].Cells["START_DATE"].Value.ToString()).AddDays(CConvert.ToDouble(productioncycle) + 0D);
                    j++;
                }
                else
                {
                    dr.Cells["START_DATE"].Value = txtSlipDateFrom.Text;
                    dr.Cells["END_DATE"].Value = CConvert.ToDateTime(txtSlipDateFrom.Text).AddDays(CConvert.ToDouble(productioncycle) + 0D);
                    j++;
                }
            }

        }
        bool HasAttachEvent = false;
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl control = (DataGridViewTextBoxEditingControl)e.Control;

            if (!this.HasAttachEvent) // 注册事件
            {
                control.KeyPress += new KeyPressEventHandler(delegate(object o, KeyPressEventArgs c)
                {

                    if (dgvData.Columns[dgvData.CurrentCell.ColumnIndex].Name == "PRODUCTION_CYCLE")
                    {
                        InputInteger(o, c);
                    }
                    else
                    {
                        return;
                    }

                    //if (this.dgvData.CurrentCell.ColumnIndex == 1) return; // 第二列不验证
                    //if (!char.IsNumber(c.KeyChar)) c.Handled = true;
                });

                this.HasAttachEvent = true;
            }

        }
    }//end class
}
