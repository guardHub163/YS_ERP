using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Model;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionSchedule : FrmBase
    {
        public FrmProductionSchedule()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentDt = new DataTable();
        private string _currentConduction = "";
        BProductionSchedule bProductionSchedule = new BProductionSchedule();
        BProductionPlan bProductionPlan = new BProductionPlan();
        BProductionPlanSearch bProductionPlanSearch = new BProductionPlanSearch();
        BOrderHeader bOrderheader = new BOrderHeader();
        BCustomer bCustomer = new BCustomer();
        BSlipType bSlipType = new BSlipType();
        BProductionDrawing bProductionDrawing = new BProductionDrawing();
        private bool isSearch = false;

        private void FrmProductionSchedule_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.radioButton3.Checked = true;
            if (UserTable.LEVEL < 6)
            {
                txtSales.Visible = false;
                txtSalesCode.Visible = false;
                label8.Visible = false;
                label10.Visible = false;
                btnSales.Visible = false;
            }

            PageSize = 15;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count > 0)
            {
                DataGridViewRow row = dgvData.CurrentRow;
                string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                //string orderSlipNumber = CConvert.ToString(row.Cells["ORDER_SLIP_NUMBER"].Value);  
                FrmBase frm = new FrmProductionScheduleDetails(slipNumber);

                frm.ShowDialog(this);
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _currentConduction = GetConduction();
            int currentPage = 1;
            int recordCount = bProductionSchedule.GetRecordCount(_currentConduction);
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
            DataSet ds = bProductionSchedule.GetList(_currentConduction, "", (currentPage - 1) * PageSize + 1, currentPage * PageSize);
            _currentDt = ds.Tables[0];
            _currentDt.Columns.Add("PRODUCTION_STATUS", Type.GetType("System.String"));
            foreach (DataRow dr in _currentDt.Rows)
            {
                if (dr["PSPP_ACTUAL_END_TIME"].ToString() == "")
                {
                    if (CConvert.ToDateTime(DateTime.Now.ToShortDateString().ToString()) >CConvert.ToDateTime(CConvert.ToDateTime(dr["PLAN_END_DATE"].ToString()).ToShortDateString()))
                    {
                        dr["PRODUCTION_STATUS"] = "延期";
                    }
                    else
                    {
                        dr["PRODUCTION_STATUS"] = "未延期";
                    }
                }
                else
                {
                    if (CConvert.ToDateTime(CConvert.ToDateTime(dr["PSPP_ACTUAL_END_TIME"].ToString()).ToShortDateString()) <= CConvert.ToDateTime(CConvert.ToDateTime(dr["PLAN_END_DATE"].ToString()).ToShortDateString()))
                    {
                        dr["PRODUCTION_STATUS"] = "未延期";
                    }
                    else
                    {
                        dr["PRODUCTION_STATUS"] = "延期";

                    }
                }

            }

            //reSetCurrentDt();
            this.dgvData.DataSource = _currentDt;


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
            if (!string.IsNullOrEmpty(txtOrderSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND ORDER_SLIP_NUNBER like '{0}'", txtOrderSlipNumber.Text.Trim());
            }

            if (this.txtSlipDate.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE >= '{0}'", txtSlipDate.Value.ToString("yyyy-MM-dd"));
            }

            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }

            if (!string.IsNullOrEmpty(txtSlipType.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_TYPE_CODE = '{0}'", txtSlipType.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat(" AND SLIP_NUMBER = '{0}'", txtSlipNumber.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtCustmerCode.Text.Trim()))
            {
                sb.AppendFormat(" AND CUSTOMER_CODE = '{0}'", txtCustmerCode.Text.Trim());
            }

            if (radioButton2.Checked)
            {
                sb.AppendFormat(" AND ISNUll(PSPP_ACTUAL_END_TIME,CONVERT(varchar(100), GETDATE(), 111)) <= PLAN_END_DATE ");
            }
            if (radioButton1.Checked)
            {
                sb.AppendFormat(" AND ISNUll(PSPP_ACTUAL_END_TIME,CONVERT(varchar(100), GETDATE(), 111)) > PLAN_END_DATE ");
            }
            if (UserTable.LEVEL < 6)
            {
                sb.AppendFormat(" AND OH_CREATE_USER = '{0}'", UserTable.CODE);
            }
            if (!string.IsNullOrEmpty(txtSalesCode.Text.Trim()))
            {
                sb.AppendFormat(" AND OH_CREATE_USER = '{0}'", txtSalesCode.Text.Trim());
                //return sb.ToString();
            }

            return sb.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnCustmer_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("CUSTOMER", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtCustmerCode.Text = frm.BaseMasterTable.Code;
                    txtCustmerName.Text = frm.BaseMasterTable.Name;
                }
            }

            frm.Dispose();
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

        private void btnCustmer_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnCustmer_MouseLeave(object sender, EventArgs e)
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

        private void btnSlipNumber_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnSlipNumber_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void txtCustmerCode_Leave(object sender, EventArgs e)
        {
            string CustmerCode = txtCustmerCode.Text.Trim();
            if (CustmerCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("CUSTOMER", CustmerCode);
                if (baseMaster != null)
                {
                    txtCustmerCode.Text = baseMaster.Code;
                    txtCustmerName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("客户编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustmerCode.Text = "";
                    txtCustmerName.Text = "";
                    txtCustmerCode.Focus();
                }
            }
            else
            {
                txtCustmerName.Text = "";
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
        #region 工序导出
        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable orderHeadDt = new DataTable();

            DataTable lineDt = new DataTable();

            DataTable scheduleDt = new DataTable();

            int CHKchooseCount = 0;
            int CHKchooseCountcheck = 0;
            int Max = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["CHK"].Value) == true)
                {
                    CHKchooseCountcheck++;
                }
            }
            if (CHKchooseCountcheck < 1)
            {
                MessageBox.Show("请选择要导出的数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.Title = "导出文件保存路径";
            saveFileDialog.FileName = "PRODUCTION_PROCESS_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string sheetName = "PRODUCTIONPROCESSDETAIL";
            //string title = "PO.,DATE,生产工单编号,客户名称,尺寸,描述,计划结束时间,PLAN UPDATED,DRAWING DELAIED FROM BUYER,PROCESS DELAIED,DELAIED FROM SUPLIER,CONTROL";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strName = saveFileDialog.FileName;
                if (strName.Length != 0)
                {
                    System.Reflection.Missing miss = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                    excel.Application.Workbooks.Add(true); ;
                    excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
                    if (excel == null)
                    {
                        Logger.Error("Excel文件保存失败。", null);
                        return;
                    }
                    Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                    sheet.Name = sheetName;
                    //int m = 0, n = 0;
                    ////生成列名称 这里i是从1开始的 因为我第0列是个隐藏列ID 没必要写进去

                    Microsoft.Office.Interop.Excel._Worksheet ws = new Microsoft.Office.Interop.Excel.WorksheetClass();
                    ws = (Microsoft.Office.Interop.Excel._Worksheet)excel.ActiveSheet; //取得当前worksheet 


                    foreach (DataGridViewRow dr in dgvData.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["CHK"].Value) == true)
                        {
                            //DataTable
                            orderHeadDt = bOrderheader.GetModelInfo(CConvert.ToString(dr.Cells["ORDER_SLIP_NUMBER"].Value)).Tables[0];

                            // DataTable 
                            lineDt = bProductionSchedule.GetProductionScheduleLine(" SLIP_NUMBER = '" + CConvert.ToString(dr.Cells["SLIP_NUMBER"].Value) + "'").Tables[0];

                            //DataTable 
                            scheduleDt = bProductionPlan.GetProductionPlanHeader(" SLIP_NUMBER = '" + CConvert.ToString(dr.Cells["SLIP_NUMBER"].Value) + "'").Tables[0];
                            CHKchooseCount++;
                            foreach (DataRow lineDr in lineDt.Rows)
                            {
                                if (CConvert.ToInt32(lineDr["SCHEDULE_FLAG"]).Equals(1))
                                {
                                    DataTable processDt = bProductionPlanSearch.GetProductionPlan(" SLIP_NUMBER = '" + CConvert.ToString(lineDr["SLIP_NUMBER"]) + "'" + " AND SCHEDULE_LINE_NUNBER = '" + CConvert.ToInt32(lineDr["LINE_NUMBER"]) + "'").Tables[0];

                                    if (CHKchooseCount == 1)
                                    {

                                        Microsoft.Office.Interop.Excel.Range r;
                                        r = ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 12]); //取得合并的区域 
                                        r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                        r.RowHeight = 30;
                                        r.MergeCells = true;

                                        Microsoft.Office.Interop.Excel.Range r4;
                                        r4 = ws.get_Range(ws.Cells[1 + Max, 13], ws.Cells[1 + Max, 12 + CConvert.ToInt32(processDt.Rows.Count * 2)]); //取得合并的区域                                     
                                        r4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                        r4.MergeCells = true;
                                        r4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                                        excel.Cells[1, 1] = "PO.&PRODUCTION DETAIL";
                                        excel.Cells[1, 13] = "PRODUCTION STATUS";
                                    }

                                    Microsoft.Office.Interop.Excel.Range r2;
                                    r2 = ws.get_Range(ws.Cells[2 + Max, 3], ws.Cells[2 + Max, 4]); //取得合并的区域 
                                    r2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    r2.MergeCells = true;

                                    for (int i = 1; i < 12; i++)
                                    {
                                        Microsoft.Office.Interop.Excel.Range r5;
                                        r5 = ws.get_Range(ws.Cells[4 + Max, i], ws.Cells[6 + Max, i]); //取得合并的区域                                             
                                        r5.MergeCells = true;
                                        r5.Columns.WrapText = true;
                                        r5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    }

                                    for (int i = 0; i < processDt.Rows.Count * 2; i = i + 2)
                                    {
                                        Microsoft.Office.Interop.Excel.Range r1;
                                        r1 = ws.get_Range(ws.Cells[2 + Max, 13 + i], ws.Cells[2 + Max, 14 + i]); //取得合并的区域                                             
                                        r1.MergeCells = true;
                                        r1.Columns.WrapText = true;
                                        r1.ColumnWidth = 10;
                                        r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    }

                                    Microsoft.Office.Interop.Excel.Range r7;
                                    r7 = ws.get_Range(ws.Cells[2 + Max, 7], ws.Cells[2 + Max, 11]); //取得合并的区域 
                                    r7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    r7.MergeCells = true;

                                    Microsoft.Office.Interop.Excel.Range r8;
                                    r8 = ws.get_Range(ws.Cells[2 + Max, 1], ws.Cells[3 + Max, 1]); //取得合并的区域 
                                    r8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    r8.MergeCells = true;

                                    Microsoft.Office.Interop.Excel.Range r9;
                                    r9 = ws.get_Range(ws.Cells[2 + Max, 12], ws.Cells[3 + Max, 12]); //取得合并的区域 
                                    r9.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    r9.MergeCells = true;

                                    Microsoft.Office.Interop.Excel.Range r10;
                                    r10 = ws.get_Range(ws.Cells[2 + Max, 2], ws.Cells[3 + Max, 2]); //取得合并的区域 
                                    r10.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    r10.ColumnWidth = 10;
                                    r10.MergeCells = true;


                                    Microsoft.Office.Interop.Excel.Range r11;
                                    r11 = ws.get_Range(ws.Cells[3 + Max, 3], ws.Cells[3 + Max, 3]); //取得合并的区域 
                                    r11.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    r11.Columns.WrapText = true;
                                    r11.RowHeight = 40;


                                    Microsoft.Office.Interop.Excel.Range r12;
                                    r12 = ws.get_Range(ws.Cells[3 + Max, 1], ws.Cells[3 + Max, 11]); //取得合并的区域 
                                    r12.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    r12.ColumnWidth = 8;
                                    r12.Columns.WrapText = true;


                                    Microsoft.Office.Interop.Excel.Range r13;
                                    r13 = ws.get_Range(ws.Cells[2 + Max, 5], ws.Cells[3 + Max, 5]); //取得合并的区域 
                                    r13.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    r13.MergeCells = true;

                                    Microsoft.Office.Interop.Excel.Range r14;
                                    r14 = ws.get_Range(ws.Cells[2 + Max, 6], ws.Cells[3 + Max, 6]); //取得合并的区域 
                                    r14.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    r14.MergeCells = true;

                                    Microsoft.Office.Interop.Excel.Range r20;
                                    r20 = ws.get_Range(ws.Cells[2 + Max, 1], ws.Cells[3 + Max, 1]); //取得合并的区域 
                                    r20.ColumnWidth = 14;

                                    Microsoft.Office.Interop.Excel.Range r21;
                                    r21 = ws.get_Range(ws.Cells[2 + Max, 2], ws.Cells[3 + Max, 2]); //取得合并的区域 
                                    r21.ColumnWidth = 12;

                                    Microsoft.Office.Interop.Excel.Range r22;
                                    r22 = ws.get_Range(ws.Cells[2 + Max, 3], ws.Cells[3 + Max, 4]); //取得合并的区域 
                                    r22.ColumnWidth = 14;

                                    Microsoft.Office.Interop.Excel.Range r23;
                                    r23 = ws.get_Range(ws.Cells[3 + Max, 7], ws.Cells[3 + Max, 7]); //取得合并的区域 
                                    r23.ColumnWidth = 12;

                                    Microsoft.Office.Interop.Excel.Range r24;
                                    r24 = ws.get_Range(ws.Cells[3 + Max, 8], ws.Cells[3 + Max, 8]); //取得合并的区域 
                                    r24.ColumnWidth = 12;

                                    for (int i = 0; i < processDt.Rows.Count * 2; i++)
                                    {
                                        Microsoft.Office.Interop.Excel.Range r15;
                                        r15 = ws.get_Range(ws.Cells[3 + Max, 13], ws.Cells[3 + Max, 13 + processDt.Rows.Count * 2]); //取得合并的区域
                                        r15.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    }

                                    for (int i = 0; i < processDt.Rows.Count * 2; i++)
                                    {
                                        Microsoft.Office.Interop.Excel.Range r16;
                                        r16 = ws.get_Range(ws.Cells[6 + Max, 13], ws.Cells[6 + Max, 13 + processDt.Rows.Count * 2]); //取得合并的区域
                                        r16.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                    }

                                    //excel.Cells[1, 1] = "生产工单明细";
                                    //excel.Cells[1, 13] = "生产工单工序状态";
                                    excel.Cells[2 + Max, 3] = "PLANT CODE";
                                    excel.Cells[2 + Max, 7] = "DELIVERY";
                                    excel.Cells[4 + Max, 12] = "PLANNED";
                                    excel.Cells[5 + Max, 12] = "ACTUAL";
                                    excel.Cells[6 + Max, 12] = "DELAIED";
                                    excel.Cells[2 + Max, 1] = "PO.";
                                    excel.Cells[2 + Max, 2] = "DATE";
                                    excel.Cells[3 + Max, 3] = "COMMAND";
                                    excel.Cells[3 + Max, 4] = "DRAWING";
                                    excel.Cells[2 + Max, 5] = "SIZE";
                                    excel.Cells[2 + Max, 6] = "PATTERN";
                                    excel.Cells[3 + Max, 7] = "PLANED";
                                    excel.Cells[3 + Max, 8] = "PLAN UPDATED";
                                    excel.Cells[3 + Max, 9] = "DRAWING DELAIED FROM BUYER";
                                    excel.Cells[3 + Max, 10] = "PROCESS DELAIED";
                                    excel.Cells[3 + Max, 11] = "DELAIED FROM SUPLIER";
                                    excel.Cells[2 + Max, 12] = "CONTROL";

                                    //string[] strHeader = title.Split(',');
                                    //for (int i = 0; i < strHeader.Length; i++)
                                    //{
                                    //    excel.Cells[3 + Max, i + 1] = strHeader[i].ToString();
                                    //}

                                    for (int i = 0; i < processDt.Rows.Count * 2; i = i + 2)
                                    {
                                        excel.Cells[3 + Max, i + 13] = "START";
                                        excel.Cells[3 + Max, i + 14] = "COMPLETE";
                                    }


                                    //  填充数据
                                    foreach (DataRow orderDr in orderHeadDt.Rows)
                                    {
                                        excel.Cells[4 + Max, 1] = "'" + CConvert.ToString(orderDr["CUSTOMER_PO_NUMBER"]);
                                        excel.Cells[4 + Max, 2] = "'" + CConvert.ToDateTime(orderDr["SLIP_DATE"]).ToString("yyyy-MM-dd");
                                        excel.Cells[4 + Max, 4] = CConvert.ToString(orderDr["CUSTOMER_NAME"]);
                                        excel.Cells[4 + Max, 5] = CConvert.ToString(orderDr["SPEC"]);
                                        excel.Cells[4 + Max, 6] = CConvert.ToString(orderDr["DESCRIPTION"]);
                                    }

                                    foreach (DataRow scheduleDr in scheduleDt.Rows)
                                    {

                                        excel.Cells[4 + Max, 3] = "'" + CConvert.ToString(scheduleDr["SLIP_NUMBER"]);
                                        excel.Cells[4 + Max, 7] = "'" + CConvert.ToDateTime(scheduleDr["PLAN_END_DATE"]).ToString("yyyy-MM-dd");
                                        excel.Cells[4 + Max, 8] = "'" + CConvert.ToDateTime(scheduleDr["LAST_UPDATE_TIME"]).ToString("yyyy-MM-dd");
                                    }
                                    int processcount = 0;

                                    DataTable ProcessDelaiedDt = new DataTable();
                                    ProcessDelaiedDt.Columns.Add("Days", Type.GetType("System.Int32"));

                                    foreach (DataRow dr2 in processDt.Rows)
                                    {
                                        processcount = processcount + 2;
                                        excel.Cells[2 + Max, 11 + processcount] = CConvert.ToString(dr2["PRODUCTION_PROCESS_NAME"]);

                                        var RowAll1 = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[1, 12 + processcount]);
                                        RowAll1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                                        var RowAll = sheet.get_Range(sheet.Cells[2 + Max, 1], sheet.Cells[6 + Max, 12 + processcount]);

                                        RowAll.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;


                                        if (dr2["PSPP_PLAN_START_DATE"].ToString() != "")
                                        {
                                            excel.Cells[4 + Max, 11 + processcount] = "'" + CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]).ToString("yyyy-MM-dd");
                                        }
                                        if (dr2["PSPP_PLAN_END_DATE"].ToString() != "")
                                        {
                                            excel.Cells[4 + Max, 12 + processcount] = "'" + CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]).ToString("yyyy-MM-dd");
                                        }
                                        if (dr2["PSPP_ACTUAL_START_TIME"].ToString() != "")
                                        {
                                            excel.Cells[5 + Max, 11 + processcount] = "'" + CConvert.ToDateTime(dr2["PSPP_ACTUAL_START_TIME"]).ToString("yyyy-MM-dd");

                                            if (CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]) >= CConvert.ToDateTime(dr2["PSPP_ACTUAL_START_TIME"]))
                                            {
                                                excel.Cells[6 + Max, 11 + processcount] = "'" + "0Day(s)";
                                                ProcessDelaiedDt.Rows.Add(0);
                                            }
                                            else
                                            {
                                                string dateDiff = null;
                                                TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]).Ticks);
                                                TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_ACTUAL_START_TIME"]).Ticks);
                                                TimeSpan ts = ts1.Subtract(ts2).Duration();
                                                dateDiff = ts.Days.ToString() + "Day(s)";
                                                excel.Cells[6 + Max, 11 + processcount] = "'" + CConvert.ToString(dateDiff);
                                                ProcessDelaiedDt.Rows.Add(CConvert.ToInt32(ts.Days.ToString()));
                                            }

                                        }
                                        else
                                        {
                                            if (CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]) >= CConvert.ToDateTime(DateTime.Now.ToShortDateString().ToString()))
                                            {
                                                excel.Cells[6 + Max, 11 + processcount] = "'" + "0Day(s)";
                                                ProcessDelaiedDt.Rows.Add(0);
                                            }
                                            else
                                            {
                                                string dateDiff = null;
                                                TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]).Ticks);
                                                TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(DateTime.Now.ToShortDateString().ToString()).Ticks);
                                                TimeSpan ts = ts1.Subtract(ts2).Duration();
                                                dateDiff = ts.Days.ToString() + "Day(s)";
                                                excel.Cells[6 + Max, 11 + processcount] = "'" + CConvert.ToString(dateDiff);
                                                ProcessDelaiedDt.Rows.Add(CConvert.ToInt32(ts.Days.ToString()));
                                            }
                                        }

                                        if (dr2["PSPP_ACTUAL_END_TIME"].ToString() != "")
                                        {
                                            excel.Cells[5 + Max, 12 + processcount] = "'" + CConvert.ToDateTime(dr2["PSPP_ACTUAL_END_TIME"]).ToString("yyyy-MM-dd");

                                            if (CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]) >= CConvert.ToDateTime(dr2["PSPP_ACTUAL_END_TIME"]))
                                            {
                                                excel.Cells[6 + Max, 12 + processcount] = "'" + "0Day(s)";
                                                ProcessDelaiedDt.Rows.Add(0);
                                            }
                                            else
                                            {
                                                string dateDiff = null;
                                                TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]).Ticks);
                                                TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_ACTUAL_END_TIME"]).Ticks);
                                                TimeSpan ts = ts1.Subtract(ts2).Duration();
                                                dateDiff = ts.Days.ToString() + "Day(s)";
                                                excel.Cells[6 + Max, 12 + processcount] = "'" + CConvert.ToString(dateDiff);
                                                ProcessDelaiedDt.Rows.Add(CConvert.ToInt32(ts.Days.ToString()));
                                            }
                                        }

                                        else
                                        {
                                            if (CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]) >= CConvert.ToDateTime(DateTime.Now.ToShortDateString().ToString()))
                                            {
                                                excel.Cells[6 + Max, 12 + processcount] = "'" + "0Day(s)";
                                                ProcessDelaiedDt.Rows.Add(0);
                                            }
                                            else
                                            {
                                                string dateDiff = null;
                                                TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]).Ticks);
                                                TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(DateTime.Now.ToShortDateString().ToString()).Ticks);
                                                TimeSpan ts = ts1.Subtract(ts2).Duration();
                                                dateDiff = ts.Days.ToString() + "Day(s)";
                                                excel.Cells[6 + Max, 12 + processcount] = "'" + CConvert.ToString(dateDiff);
                                                ProcessDelaiedDt.Rows.Add(CConvert.ToInt32(ts.Days.ToString()));
                                            }
                                        }
                                    }
                                    int a = CConvert.ToInt32(ProcessDelaiedDt.Compute("Max(Days)", "true"));
                                    excel.Cells[4 + Max, 10] = "'" + a + "Day(s)";
                                }

                            }

                            Max = Max + 6;
                        }

                    }
                    try
                    {
                        sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                        book.Close(false, miss, miss);
                        books.Close();
                        excel.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                        GC.Collect();
                        MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Excel文件保存失败。", null);
                        return;
                    }
                }
            }
            #region delete
            //if (CHKchooseCount < 1)
            //{
            //    MessageBox.Show("请选择要导出的数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (CHKchooseCount > 1)
            //{
            //    MessageBox.Show("只能选择一条数据导出!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //foreach (DataRow lineDr in lineDt.Rows)
            //{
            //    if (CConvert.ToInt32(lineDr["SCHEDULE_FLAG"]).Equals(1))
            //    {
            //        DataTable processDt = bProductionPlanSearch.GetProductionPlan(" SLIP_NUMBER = '" + CConvert.ToString(lineDr["SLIP_NUMBER"]) + "'" + " AND SCHEDULE_LINE_NUNBER = '" + CConvert.ToInt32(lineDr["LINE_NUMBER"]) + "'").Tables[0];

            //        if (processDt != null)
            //        {
            //            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //            saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
            //            saveFileDialog.FilterIndex = 0;
            //            saveFileDialog.Title = "导出文件保存路径";
            //            saveFileDialog.FileName = "PRODUCTION_PROCESS_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            //            string sheetName = "PRODUCTIONPROCESSDETAIL";
            //            string title = "PO.,DATE,生产工单编号,客户名称,尺寸,描述,计划结束时间,PLAN UPDATED,DRAWING DELAIED FROM BUYER,PROCESS DELAIED,DELAIED FROM SUPLIER,CONTROL";
            //            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //            {
            //                string strName = saveFileDialog.FileName;
            //                if (strName.Length != 0)
            //                {
            //                    System.Reflection.Missing miss = System.Reflection.Missing.Value;
            //                    Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            //                    excel.Application.Workbooks.Add(true); ;
            //                    excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
            //                    if (excel == null)
            //                    {
            //                        Logger.Error("Excel文件保存失败。", null);
            //                        return;
            //                    }
            //                    Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
            //                    Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
            //                    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            //                    sheet.Name = sheetName;
            //                    //int m = 0, n = 0;
            //                    ////生成列名称 这里i是从1开始的 因为我第0列是个隐藏列ID 没必要写进去

            //                    Microsoft.Office.Interop.Excel._Worksheet ws = new Microsoft.Office.Interop.Excel.WorksheetClass();
            //                    ws = (Microsoft.Office.Interop.Excel._Worksheet)excel.ActiveSheet; //取得当前worksheet 

            //                    Microsoft.Office.Interop.Excel.Range r;
            //                    r = ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 12]); //取得合并的区域 
            //                    r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //                    r.RowHeight = 30;
            //                    r.MergeCells = true;

            //                    Microsoft.Office.Interop.Excel.Range r1;
            //                    r1 = ws.get_Range(ws.Cells[2, 3], ws.Cells[2, 4]); //取得合并的区域 
            //                    r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //                    r1.MergeCells = true;

            //                    Microsoft.Office.Interop.Excel.Range r2;
            //                    r2 = ws.get_Range(ws.Cells[2, 7], ws.Cells[2, 11]); //取得合并的区域 
            //                    r2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //                    r2.MergeCells = true;

            //                    Microsoft.Office.Interop.Excel.Range r3;
            //                    r3 = ws.get_Range(ws.Cells[1, 13], ws.Cells[1, 12 + CConvert.ToInt32(processDt.Rows.Count * 2)]); //取得合并的区域                                     
            //                    r3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //                    r3.RowHeight = 30;
            //                    r3.MergeCells = true;

            //                    Microsoft.Office.Interop.Excel.Range r4;
            //                    r4 = ws.get_Range(ws.Cells[3, 1], ws.Cells[3, 12]); //取得合并的区域 
            //                    r4.RowHeight = 55;
            //                    r4.Columns.WrapText = true;
            //                    r4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //                    for (int i = 1; i < 12; i++)
            //                    {
            //                        Microsoft.Office.Interop.Excel.Range r5;
            //                        r5 = ws.get_Range(ws.Cells[4, i], ws.Cells[6, i]); //取得合并的区域                                             
            //                        r5.MergeCells = true;
            //                        r5.Columns.WrapText = true;
            //                        r5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //                    }



            //                    for (int i = 0; i < processDt.Rows.Count * 2; i = i + 2)
            //                    {
            //                        Microsoft.Office.Interop.Excel.Range r6;
            //                        r6 = ws.get_Range(ws.Cells[2, 13 + i], ws.Cells[2, 14 + i]); //取得合并的区域                                             
            //                        r6.MergeCells = true;
            //                        r6.Columns.WrapText = true;
            //                        r6.ColumnWidth = 10;
            //                        r6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //                    }

            //                    Microsoft.Office.Interop.Excel.Range r7;
            //                    r7 = ws.get_Range(ws.Cells[3, 13], ws.Cells[3, 12 + CConvert.ToInt32(processDt.Rows.Count * 2)]); //取得合并的区域                                     
            //                    r7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //                    Microsoft.Office.Interop.Excel.Range r8;
            //                    r8 = ws.get_Range(ws.Cells[4, 1], ws.Cells[6, 1]); //取得合并的区域                                     
            //                    r8.ColumnWidth = 15;

            //                    Microsoft.Office.Interop.Excel.Range r9;
            //                    r9 = ws.get_Range(ws.Cells[4, 2], ws.Cells[6, 2]); //取得合并的区域                                     
            //                    r9.ColumnWidth = 10;

            //                    Microsoft.Office.Interop.Excel.Range r10;
            //                    r10 = ws.get_Range(ws.Cells[4, 3], ws.Cells[6, 3]); //取得合并的区域                                     
            //                    r10.ColumnWidth = 15;

            //                    Microsoft.Office.Interop.Excel.Range r11;
            //                    r11 = ws.get_Range(ws.Cells[4, 7], ws.Cells[6, 7]); //取得合并的区域                                     
            //                    r11.ColumnWidth = 10;


            //                    excel.Cells[1, 1] = "生产工单明细";
            //                    excel.Cells[1, 13] = "生产工单工序状态";
            //                    excel.Cells[2, 3] = "PLANT CODE";
            //                    excel.Cells[2, 7] = "DELIVERY";
            //                    excel.Cells[4, 12] = "PLANNED";
            //                    excel.Cells[5, 12] = "ACTUAL";
            //                    excel.Cells[6, 12] = "DELAIED";

            //                    string[] strHeader = title.Split(',');
            //                    for (int i = 0; i < strHeader.Length; i++)
            //                    {
            //                        excel.Cells[3, i + 1] = strHeader[i].ToString();
            //                    }

            //                    for (int i = 0; i < processDt.Rows.Count * 2; i = i + 2)
            //                    {
            //                        excel.Cells[3, i + 13] = "START";
            //                        excel.Cells[3, i + 14] = "COMPLETE";
            //                    }

            //                    //填充数据
            //                    foreach (DataRow orderDr in orderHeadDt.Rows)
            //                    {
            //                        excel.Cells[4, 2] = "'" + CConvert.ToDateTime(orderDr["SLIP_DATE"]).ToString("yyyy-MM-dd");
            //                        excel.Cells[4, 4] = CConvert.ToString(orderDr["CUSTOMER_NAME"]);
            //                        excel.Cells[4, 5] = CConvert.ToString(orderDr["SPEC"]);
            //                        excel.Cells[4, 6] = CConvert.ToString(orderDr["DESCRIPTION"]);
            //                    }

            //                    foreach (DataRow scheduleDr in scheduleDt.Rows)
            //                    {
            //                        excel.Cells[4, 1] = "'" + CConvert.ToString(scheduleDr["ORDER_SLIP_NUNBER"]);
            //                        excel.Cells[4, 3] = "'" + CConvert.ToString(scheduleDr["SLIP_NUMBER"]);
            //                        excel.Cells[4, 7] = "'" + CConvert.ToDateTime(scheduleDr["PLAN_END_DATE"]).ToString("yyyy-MM-dd");
            //                    }
            //                    int processcount = 0;
            //                    foreach (DataRow dr2 in processDt.Rows)
            //                    {
            //                        processcount = processcount + 2;
            //                        excel.Cells[2, 11 + processcount] = CConvert.ToString(dr2["PRODUCTION_PROCESS_NAME"]);
            //                        if (dr2["PSPP_PLAN_START_DATE"].ToString() != "")
            //                        {
            //                            excel.Cells[4, 11 + processcount] = "'" + CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]).ToString("yyyy-MM-dd");
            //                        }
            //                        if (dr2["PSPP_PLAN_END_DATE"].ToString() != "")
            //                        {
            //                            excel.Cells[4, 12 + processcount] = "'" + CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]).ToString("yyyy-MM-dd");
            //                        }
            //                        if (dr2["PSPP_ACTUAL_START_TIME"].ToString() != "")
            //                        {
            //                            excel.Cells[5, 11 + processcount] = "'" + CConvert.ToDateTime(dr2["PSPP_ACTUAL_START_TIME"]).ToString("yyyy-MM-dd");

            //                            if (CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]) >= CConvert.ToDateTime(dr2["PSPP_ACTUAL_START_TIME"]))
            //                            {
            //                                excel.Cells[6, 11 + processcount] = "'" + "0天";
            //                            }
            //                            else
            //                            {
            //                                string dateDiff = null;
            //                                TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]).Ticks);
            //                                TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_ACTUAL_START_TIME"]).Ticks);
            //                                TimeSpan ts = ts1.Subtract(ts2).Duration();
            //                                dateDiff = ts.Days.ToString() + "天";
            //                                excel.Cells[6, 11 + processcount] = "'" + CConvert.ToString(dateDiff);
            //                            }

            //                        }
            //                        else
            //                        {
            //                            if (CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]) >= CConvert.ToDateTime(DateTime.Now))
            //                            {
            //                                excel.Cells[6, 11 + processcount] = "'" + "0天";
            //                            }
            //                            else
            //                            {
            //                                string dateDiff = null;
            //                                TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_PLAN_START_DATE"]).Ticks);
            //                                TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(DateTime.Now).Ticks);
            //                                TimeSpan ts = ts1.Subtract(ts2).Duration();
            //                                dateDiff = ts.Days.ToString() + "天";
            //                                excel.Cells[6, 11 + processcount] = "'" + CConvert.ToString(dateDiff);
            //                            }
            //                        }

            //                        if (dr2["PSPP_ACTUAL_END_TIME"].ToString() != "")
            //                        {
            //                            excel.Cells[5, 12 + processcount] = "'" + CConvert.ToDateTime(dr2["PSPP_ACTUAL_END_TIME"]).ToString("yyyy-MM-dd");

            //                            if (CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]) >= CConvert.ToDateTime(dr2["PSPP_ACTUAL_END_TIME"]))
            //                            {
            //                                excel.Cells[6, 12 + processcount] = "'" + "0天";
            //                            }
            //                            else
            //                            {
            //                                string dateDiff = null;
            //                                TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]).Ticks);
            //                                TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_ACTUAL_END_TIME"]).Ticks);
            //                                TimeSpan ts = ts1.Subtract(ts2).Duration();
            //                                dateDiff = ts.Days.ToString() + "天";
            //                                excel.Cells[6, 12 + processcount] = "'" + CConvert.ToString(dateDiff);
            //                            }
            //                        }

            //                        else
            //                        {
            //                            if (CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]) >= CConvert.ToDateTime(DateTime.Now))
            //                            {
            //                                excel.Cells[6, 12 + processcount] = "'" + "0天";
            //                            }
            //                            else
            //                            {
            //                                string dateDiff = null;
            //                                TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSPP_PLAN_END_DATE"]).Ticks);
            //                                TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(DateTime.Now).Ticks);
            //                                TimeSpan ts = ts1.Subtract(ts2).Duration();
            //                                dateDiff = ts.Days.ToString() + "天";
            //                                excel.Cells[6, 12 + processcount] = "'" + CConvert.ToString(dateDiff);
            //                            }
            //                        }
            //                    }

            //                    try
            //                    {
            //                        sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
            //                        book.Close(false, miss, miss);
            //                        books.Close();
            //                        excel.Quit();
            //                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
            //                        System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
            //                        System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
            //                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            //                        GC.Collect();
            //                        MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        //System.Diagnostics.Process.Start(strName);
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        Logger.Error("Excel文件保存失败。", null);
            //                        return;
            //                    }
            //                }
            //                return;
            //            }
            //        }
            //    }
            //}
            #endregion
        }
        #endregion
        #region 图纸导出
        private void btnDrExport_Click(object sender, EventArgs e)
        {
            DataTable orderHeadDt = new DataTable();
            DataTable drawingDt = new DataTable();
            DataTable scheduleDt = new DataTable();
            int CHKchooseCount = 0;
            int CHKchooseCountcheck = 0;
            int Max = 0;
            foreach (DataGridViewRow dr in dgvData.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["CHK"].Value) == true)
                {
                    CHKchooseCountcheck++;
                }
            }
            if (CHKchooseCountcheck < 1)
            {
                MessageBox.Show("请选择要导出的数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.Title = "导出文件保存路径";
            saveFileDialog.FileName = "PRODUCTION_DRAWING" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            string sheetName = "PRODUCTIONDRAWINGDETAIL";
            string title = "PO.,DATE,PLANT CODE,,SIZE,PATTERN,DELAIED,CONTROL";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strName = saveFileDialog.FileName;
                if (strName.Length != 0)
                {
                    System.Reflection.Missing miss = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                    excel.Application.Workbooks.Add(true); ;
                    excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
                    if (excel == null)
                    {
                        Logger.Error("Excel文件保存失败。", null);
                        return;
                    }
                    Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                    Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                    sheet.Name = sheetName;
                    Microsoft.Office.Interop.Excel._Worksheet ws = new Microsoft.Office.Interop.Excel.WorksheetClass();
                    ws = (Microsoft.Office.Interop.Excel._Worksheet)excel.ActiveSheet; //取得当前worksheet 

                    foreach (DataGridViewRow dr in dgvData.Rows)
                    {
                        if (Convert.ToBoolean(dr.Cells["CHK"].Value) == true)
                        {
                            orderHeadDt = bOrderheader.GetModelInfo(CConvert.ToString(dr.Cells["ORDER_SLIP_NUMBER"].Value)).Tables[0];
                            drawingDt = bProductionDrawing.GetProductionDrawing(" SLIP_NUMBER = '" + CConvert.ToString(dr.Cells["SLIP_NUMBER"].Value) + "'").Tables[0];
                            scheduleDt = bProductionPlan.GetProductionPlanHeader(" SLIP_NUMBER = '" + CConvert.ToString(dr.Cells["SLIP_NUMBER"].Value) + "'").Tables[0];
                            CHKchooseCount++;

                            if (CHKchooseCount == 1)
                            {
                                Microsoft.Office.Interop.Excel.Range r8;
                                r8 = ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 8]); //取得合并的区域 
                                r8.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                r8.RowHeight = 25;
                                r8.MergeCells = true;

                                Microsoft.Office.Interop.Excel.Range r9;
                                r9 = ws.get_Range(ws.Cells[1, 9], ws.Cells[1, 8 + CConvert.ToInt32(drawingDt.Rows.Count)]); //取得合并的区域                                     
                                r9.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                //r3.RowHeight = 30;
                                r9.ColumnWidth = 10;
                                r9.MergeCells = true;
                                excel.Cells[1, 1] = "PO.&PRODUCTION DETAIL";
                                excel.Cells[1, 9] = "DRAWING STATUS";
                            }

                            Microsoft.Office.Interop.Excel.Range r1;
                            r1 = ws.get_Range(ws.Cells[2 + Max, 3], ws.Cells[2 + Max, 4]); //取得合并的区域 
                            r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            r1.ColumnWidth = 14;
                            r1.MergeCells = true;

                            Microsoft.Office.Interop.Excel.Range r2;
                            r2 = ws.get_Range(ws.Cells[2 + Max, 1], ws.Cells[3 + Max, 1]); //取得合并的区域                                     
                            r2.MergeCells = true;
                            r2.ColumnWidth = 14;
                            r2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            Microsoft.Office.Interop.Excel.Range r3;
                            r3 = ws.get_Range(ws.Cells[2 + Max, 2], ws.Cells[3 + Max, 2]); //取得合并的区域                                     
                            r3.MergeCells = true;
                            r3.ColumnWidth = 12;
                            r3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            for (int i = 0; i < 4; i++)
                            {
                                Microsoft.Office.Interop.Excel.Range r4;
                                r4 = ws.get_Range(ws.Cells[2 + Max, 5 + i], ws.Cells[3 + Max, 5 + i]); //取得合并的区域 
                                r4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                r4.MergeCells = true;
                            }

                            for (int i = 1; i < 8; i++)
                            {
                                Microsoft.Office.Interop.Excel.Range r5;
                                r5 = ws.get_Range(ws.Cells[4 + Max, i], ws.Cells[6 + Max, i]); //取得合并的区域                                             
                                r5.MergeCells = true;
                                r5.Columns.WrapText = true;
                                r5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            }

                            for (int i = 0; i < drawingDt.Rows.Count; i++)
                            {
                                Microsoft.Office.Interop.Excel.Range r6;
                                r6 = ws.get_Range(ws.Cells[2 + Max, 9 + i], ws.Cells[3 + Max, 9 + i]); //取得合并的区域   
                                r6.ColumnWidth = 10;
                                r6.MergeCells = true;
                                r6.Columns.WrapText = true;
                                r6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            }

                            Microsoft.Office.Interop.Excel.Range r7;
                            r7 = ws.get_Range(ws.Cells[3 + Max, 1], ws.Cells[3 + Max, 8]); //取得合并的区域 
                            r7.RowHeight = 35;
                            r7.Columns.WrapText = true;
                            r7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            excel.Cells[3 + Max, 3] = "COMMAND";
                            excel.Cells[3 + Max, 4] = "DRAWING";
                            excel.Cells[4 + Max, 8] = "PLANNED";
                            excel.Cells[5 + Max, 8] = "ACTUAL";
                            excel.Cells[6 + Max, 8] = "DELAIED";

                            string[] strHeader = title.Split(',');
                            for (int i = 0; i < strHeader.Length; i++)
                            {
                                excel.Cells[2 + Max, i + 1] = strHeader[i].ToString();
                            }

                            //填充数据
                            foreach (DataRow orderDr in orderHeadDt.Rows)
                            {
                                excel.Cells[4 + Max, 1] = "'" + CConvert.ToString(orderDr["CUSTOMER_PO_NUMBER"]);
                                excel.Cells[4 + Max, 2] = "'" + CConvert.ToDateTime(orderDr["SLIP_DATE"]).ToString("yyyy-MM-dd");
                                excel.Cells[4 + Max, 4] = CConvert.ToString(orderDr["CUSTOMER_NAME"]);
                                excel.Cells[4 + Max, 5] = CConvert.ToString(orderDr["SPEC"]);
                                excel.Cells[4 + Max, 6] = CConvert.ToString(orderDr["DESCRIPTION"]);
                            }

                            foreach (DataRow scheduleDr in scheduleDt.Rows)
                            {
                                excel.Cells[4 + Max, 3] = "'" + CConvert.ToString(scheduleDr["SLIP_NUMBER"]);
                            }
                            int drawingcount = 0;
                            int drawingcount1 = 0;
                            DataTable DrawingDelaiedDt = new DataTable();
                            DrawingDelaiedDt.Columns.Add("Days", Type.GetType("System.Int32"));

                            foreach (DataRow dr2 in drawingDt.Rows)
                            {
                                drawingcount++;
                                excel.Cells[2 + Max, 8 + drawingcount] = CConvert.ToString(dr2["NAME"]);

                                var RowAll1 = sheet.get_Range(sheet.Cells[1, 1], sheet.Cells[1, 8 + drawingcount]);
                                RowAll1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                                var RowAll = sheet.get_Range(sheet.Cells[2 + Max, 1], sheet.Cells[6 + Max, 8 + drawingcount]);

                                RowAll.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                                if (dr2["PSDL_PLAN_END_DATE"].ToString() != "")
                                {
                                    excel.Cells[4 + Max, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                }

                                if (dr2["PSDL_ACTUAL_END_TIME"].ToString() != "")
                                {
                                    excel.Cells[5 + Max, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).ToString("yyyy-MM-dd");

                                    if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]))
                                    {
                                        excel.Cells[6 + Max, 8 + drawingcount] = "'" + "0Day(s)";
                                        DrawingDelaiedDt.Rows.Add(0);
                                    }
                                    else
                                    {
                                        string dateDiff = null;
                                        TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
                                        TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).Ticks);
                                        TimeSpan ts = ts1.Subtract(ts2).Duration();
                                        dateDiff = ts.Days.ToString() + "Day(s)";
                                        excel.Cells[6 + Max, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
                                        DrawingDelaiedDt.Rows.Add(CConvert.ToInt32(ts.Days.ToString()));
                                    }
                                }

                                else
                                {
                                    if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(DateTime.Now.ToShortDateString().ToString()))
                                    {
                                        excel.Cells[6 + Max, 8 + drawingcount] = "'" + "0Day(s)";
                                        DrawingDelaiedDt.Rows.Add(0);
                                    }
                                    else
                                    {
                                        string dateDiff = null;
                                        TimeSpan ts1 = new TimeSpan();
                                        TimeSpan ts2 = new TimeSpan();
                                        //TimeSpan 
                                        ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
                                        //TimeSpan 
                                        ts2 = new TimeSpan(CConvert.ToDateTime(DateTime.Now.ToShortDateString().ToString()).Ticks);
                                        TimeSpan ts = ts1.Subtract(ts2).Duration();
                                        dateDiff = ts.Days.ToString() + "Day(s)";
                                        excel.Cells[6 + Max, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
                                        DrawingDelaiedDt.Rows.Add(CConvert.ToInt32(ts.Days.ToString()));
                                    }
                                }
                            }

                            int a = CConvert.ToInt32(DrawingDelaiedDt.Compute("Max(Days)", "true"));
                            excel.Cells[4 + Max, 7] = "'" + a + "Day(s)";
                            Max = Max + 6;

                        }

                        # region delete
                        //    if (CHKchooseCount == 1)
                        //    {
                        //        Microsoft.Office.Interop.Excel.Range r;
                        //        r = ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 8]); //取得合并的区域 
                        //        r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        r.RowHeight = 25;
                        //        r.MergeCells = true;

                        //        Microsoft.Office.Interop.Excel.Range r1;
                        //        r1 = ws.get_Range(ws.Cells[2, 3], ws.Cells[2, 4]); //取得合并的区域 
                        //        r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        r1.MergeCells = true;

                        //        for (int i = 0; i < 4; i++)
                        //        {
                        //            Microsoft.Office.Interop.Excel.Range r2;
                        //            r2 = ws.get_Range(ws.Cells[2, 5 + i], ws.Cells[3, 5 + i]); //取得合并的区域 
                        //            r2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //            r2.MergeCells = true;
                        //        }

                        //        Microsoft.Office.Interop.Excel.Range r3;
                        //        r3 = ws.get_Range(ws.Cells[1, 9], ws.Cells[1, 8 + CConvert.ToInt32(drawingDt.Rows.Count)]); //取得合并的区域                                     
                        //        r3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        //r3.RowHeight = 30;
                        //        r3.ColumnWidth = 10;
                        //        r3.MergeCells = true;

                        //        Microsoft.Office.Interop.Excel.Range r4;
                        //        r4 = ws.get_Range(ws.Cells[3, 1], ws.Cells[3, 8]); //取得合并的区域 
                        //        r4.RowHeight = 35;
                        //        r4.Columns.WrapText = true;
                        //        r4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //        for (int i = 1; i < 8; i++)
                        //        {
                        //            Microsoft.Office.Interop.Excel.Range r5;
                        //            r5 = ws.get_Range(ws.Cells[4, i], ws.Cells[6, i]); //取得合并的区域                                             
                        //            r5.MergeCells = true;
                        //            r5.Columns.WrapText = true;
                        //            r5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        }

                        //        for (int i = 0; i < drawingDt.Rows.Count; i++)
                        //        {
                        //            Microsoft.Office.Interop.Excel.Range r6;
                        //            r6 = ws.get_Range(ws.Cells[2, 9 + i], ws.Cells[3, 9 + i]); //取得合并的区域                                             
                        //            r6.MergeCells = true;
                        //            r6.Columns.WrapText = true;
                        //            r6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        }

                        //        Microsoft.Office.Interop.Excel.Range r8;
                        //        r8 = ws.get_Range(ws.Cells[4, 1], ws.Cells[6, 1]); //取得合并的区域                                     
                        //        r8.ColumnWidth = 15;

                        //        Microsoft.Office.Interop.Excel.Range r9;
                        //        r9 = ws.get_Range(ws.Cells[4, 2], ws.Cells[6, 2]); //取得合并的区域                                     
                        //        r9.ColumnWidth = 10;

                        //        Microsoft.Office.Interop.Excel.Range r10;
                        //        r10 = ws.get_Range(ws.Cells[4, 3], ws.Cells[6, 3]); //取得合并的区域                                     
                        //        r10.ColumnWidth = 15;

                        //        Microsoft.Office.Interop.Excel.Range r11;
                        //        r11 = ws.get_Range(ws.Cells[4, 7], ws.Cells[6, 7]); //取得合并的区域                                     
                        //        r11.ColumnWidth = 10;

                        //        Microsoft.Office.Interop.Excel.Range r12;
                        //        r12 = ws.get_Range(ws.Cells[2, 1], ws.Cells[3, 1]); //取得合并的区域                                     
                        //        r12.MergeCells = true;
                        //        r12.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //        Microsoft.Office.Interop.Excel.Range r13;
                        //        r13 = ws.get_Range(ws.Cells[2, 2], ws.Cells[3, 2]); //取得合并的区域                                     
                        //        r13.MergeCells = true;
                        //        r13.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //        excel.Cells[1, 1] = "生产工单明细";
                        //        excel.Cells[1, 9] = "生产工单图纸状态";
                        //        excel.Cells[3, 3] = "生产工单编号";
                        //        excel.Cells[3, 4] = "客户名称";
                        //        excel.Cells[4, 8] = "PLANNED";
                        //        excel.Cells[5, 8] = "ACTUAL";
                        //        excel.Cells[6, 8] = "DELAIED";

                        //        string[] strHeader = title.Split(',');
                        //        for (int i = 0; i < strHeader.Length; i++)
                        //        {
                        //            excel.Cells[2, i + 1] = strHeader[i].ToString();
                        //        }

                        //        //填充数据
                        //        foreach (DataRow orderDr in orderHeadDt.Rows)
                        //        {
                        //            excel.Cells[4, 1] = "'" + CConvert.ToString(orderDr["SLIP_NUMBER"]);
                        //            excel.Cells[4, 2] = "'" + CConvert.ToDateTime(orderDr["SLIP_DATE"]).ToString("yyyy-MM-dd");
                        //            excel.Cells[4, 4] = CConvert.ToString(orderDr["CUSTOMER_NAME"]);
                        //            excel.Cells[4, 5] = CConvert.ToString(orderDr["SPEC"]);
                        //            excel.Cells[4, 6] = CConvert.ToString(orderDr["DESCRIPTION"]);

                        //        }

                        //        foreach (DataRow scheduleDr in scheduleDt.Rows)
                        //        {
                        //            excel.Cells[4, 3] = "'" + CConvert.ToString(scheduleDr["SLIP_NUMBER"]);
                        //        }
                        //        int drawingcount = 0;
                        //        int drawingcount1 = 0;
                        //        foreach (DataRow dr2 in drawingDt.Rows)
                        //        {
                        //            drawingcount++;
                        //            excel.Cells[2, 8 + drawingcount] = CConvert.ToString(dr2["NAME"]);

                        //            if (dr2["PSDL_PLAN_END_DATE"].ToString() != "")
                        //            {
                        //                excel.Cells[4, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).ToString("yyyy-MM-dd");
                        //            }
                        //            else
                        //            {
                        //            }

                        //            if (dr2["PSDL_ACTUAL_END_TIME"].ToString() != "")
                        //            {
                        //                excel.Cells[5, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).ToString("yyyy-MM-dd");

                        //                if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]))
                        //                {
                        //                    excel.Cells[6, 8 + drawingcount] = "'" + "0天";
                        //                }
                        //                else
                        //                {
                        //                    string dateDiff = null;
                        //                    TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
                        //                    TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).Ticks);
                        //                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                        //                    dateDiff = ts.Days.ToString() + "天";
                        //                    excel.Cells[6, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
                        //                }
                        //            }

                        //            else
                        //            {
                        //                if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(DateTime.Now))
                        //                {
                        //                    excel.Cells[6, 8 + drawingcount] = "'" + "0天";
                        //                }
                        //                else
                        //                {
                        //                    string dateDiff = null;
                        //                    TimeSpan ts1 = new TimeSpan();
                        //                    TimeSpan ts2 = new TimeSpan();
                        //                    //TimeSpan 
                        //                    ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
                        //                    //TimeSpan 
                        //                    ts2 = new TimeSpan(CConvert.ToDateTime(DateTime.Now).Ticks);
                        //                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                        //                    dateDiff = ts.Days.ToString() + "天";
                        //                    excel.Cells[6, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
                        //                }
                        //            }
                        //        }
                        //    }
                        //    else if (CHKchooseCount == 2)
                        //    {
                        //        Microsoft.Office.Interop.Excel.Range r1;
                        //        r1 = ws.get_Range(ws.Cells[7, 3], ws.Cells[7, 4]); //取得合并的区域 
                        //        r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        r1.MergeCells = true;

                        //        Microsoft.Office.Interop.Excel.Range r2;
                        //        r2 = ws.get_Range(ws.Cells[7, 1], ws.Cells[8, 1]); //取得合并的区域                                     
                        //        r2.MergeCells = true;
                        //        r2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //        Microsoft.Office.Interop.Excel.Range r3;
                        //        r3 = ws.get_Range(ws.Cells[7, 2], ws.Cells[8, 2]); //取得合并的区域                                     
                        //        r3.MergeCells = true;
                        //        r3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //        for (int i = 0; i < 4; i++)
                        //        {
                        //            Microsoft.Office.Interop.Excel.Range r4;
                        //            r4 = ws.get_Range(ws.Cells[7, 5 + i], ws.Cells[8, 5 + i]); //取得合并的区域 
                        //            r4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //            r4.MergeCells = true;
                        //        }

                        //        for (int i = 1; i < 8; i++)
                        //        {
                        //            Microsoft.Office.Interop.Excel.Range r5;
                        //            r5 = ws.get_Range(ws.Cells[9, i], ws.Cells[11, i]); //取得合并的区域                                             
                        //            r5.MergeCells = true;
                        //            r5.Columns.WrapText = true;
                        //            r5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        }

                        //        for (int i = 0; i < drawingDt.Rows.Count; i++)
                        //        {
                        //            Microsoft.Office.Interop.Excel.Range r6;
                        //            r6 = ws.get_Range(ws.Cells[7, 9 + i], ws.Cells[8, 9 + i]); //取得合并的区域   
                        //            r6.ColumnWidth = 10;
                        //            r6.MergeCells = true;
                        //            r6.Columns.WrapText = true;
                        //            r6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        }

                        //        Microsoft.Office.Interop.Excel.Range r7;
                        //        r7 = ws.get_Range(ws.Cells[8, 1], ws.Cells[8, 8]); //取得合并的区域 
                        //        r7.RowHeight = 35;
                        //        r7.Columns.WrapText = true;
                        //        r7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //        excel.Cells[8, 3] = "生产工单编号";
                        //        excel.Cells[8, 4] = "客户名称";
                        //        excel.Cells[9, 8] = "PLANNED";
                        //        excel.Cells[10, 8] = "ACTUAL";
                        //        excel.Cells[11, 8] = "DELAIED";

                        //        string[] strHeader = title.Split(',');
                        //        for (int i = 0; i < strHeader.Length; i++)
                        //        {
                        //            excel.Cells[7, i + 1] = strHeader[i].ToString();
                        //        }

                        //        //填充数据
                        //        foreach (DataRow orderDr in orderHeadDt.Rows)
                        //        {
                        //            excel.Cells[9, 1] = "'" + CConvert.ToString(orderDr["SLIP_NUMBER"]);
                        //            excel.Cells[9, 2] = "'" + CConvert.ToDateTime(orderDr["SLIP_DATE"]).ToString("yyyy-MM-dd");
                        //            excel.Cells[9, 4] = CConvert.ToString(orderDr["CUSTOMER_NAME"]);
                        //            excel.Cells[9, 5] = CConvert.ToString(orderDr["SPEC"]);
                        //            excel.Cells[9, 6] = CConvert.ToString(orderDr["DESCRIPTION"]);
                        //        }

                        //        foreach (DataRow scheduleDr in scheduleDt.Rows)
                        //        {
                        //            excel.Cells[9, 3] = "'" + CConvert.ToString(scheduleDr["SLIP_NUMBER"]);
                        //        }
                        //        int drawingcount = 0;
                        //        int drawingcount1 = 0;
                        //        foreach (DataRow dr2 in drawingDt.Rows)
                        //        {
                        //            drawingcount++;
                        //            excel.Cells[7, 8 + drawingcount] = CConvert.ToString(dr2["NAME"]);

                        //            if (dr2["PSDL_PLAN_END_DATE"].ToString() != "")
                        //            {
                        //                excel.Cells[9, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).ToString("yyyy-MM-dd");
                        //            }
                        //            else
                        //            {
                        //            }

                        //            if (dr2["PSDL_ACTUAL_END_TIME"].ToString() != "")
                        //            {
                        //                excel.Cells[10, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).ToString("yyyy-MM-dd");

                        //                if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]))
                        //                {
                        //                    excel.Cells[11, 8 + drawingcount] = "'" + "0天";
                        //                }
                        //                else
                        //                {
                        //                    string dateDiff = null;
                        //                    TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
                        //                    TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).Ticks);
                        //                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                        //                    dateDiff = ts.Days.ToString() + "天";
                        //                    excel.Cells[11, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
                        //                }
                        //            }

                        //            else
                        //            {
                        //                if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(DateTime.Now))
                        //                {
                        //                    excel.Cells[11, 8 + drawingcount] = "'" + "0天";
                        //                }
                        //                else
                        //                {
                        //                    string dateDiff = null;
                        //                    TimeSpan ts1 = new TimeSpan();
                        //                    TimeSpan ts2 = new TimeSpan();
                        //                    //TimeSpan 
                        //                    ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
                        //                    //TimeSpan 
                        //                    ts2 = new TimeSpan(CConvert.ToDateTime(DateTime.Now).Ticks);
                        //                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                        //                    dateDiff = ts.Days.ToString() + "天";
                        //                    excel.Cells[11, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
                        //                }
                        //            }
                        //        }

                        //    }
                        //    else if (CHKchooseCount == 3)
                        //    {
                        //        Microsoft.Office.Interop.Excel.Range r1;
                        //        r1 = ws.get_Range(ws.Cells[12, 3], ws.Cells[12, 4]); //取得合并的区域 
                        //        r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        r1.MergeCells = true;

                        //        Microsoft.Office.Interop.Excel.Range r2;
                        //        r2 = ws.get_Range(ws.Cells[12, 1], ws.Cells[13, 1]); //取得合并的区域                                     
                        //        r2.MergeCells = true;
                        //        r2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //        Microsoft.Office.Interop.Excel.Range r3;
                        //        r3 = ws.get_Range(ws.Cells[12, 2], ws.Cells[13, 2]); //取得合并的区域                                     
                        //        r3.MergeCells = true;
                        //        r3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //        for (int i = 0; i < 4; i++)
                        //        {
                        //            Microsoft.Office.Interop.Excel.Range r4;
                        //            r4 = ws.get_Range(ws.Cells[12, 5 + i], ws.Cells[13, 5 + i]); //取得合并的区域 
                        //            r4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //            r4.MergeCells = true;
                        //        }

                        //        for (int i = 1; i < 8; i++)
                        //        {
                        //            Microsoft.Office.Interop.Excel.Range r5;
                        //            r5 = ws.get_Range(ws.Cells[14, i], ws.Cells[16, i]); //取得合并的区域                                             
                        //            r5.MergeCells = true;
                        //            r5.Columns.WrapText = true;
                        //            r5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        }

                        //        for (int i = 0; i < drawingDt.Rows.Count; i++)
                        //        {
                        //            Microsoft.Office.Interop.Excel.Range r6;
                        //            r6 = ws.get_Range(ws.Cells[12, 9 + i], ws.Cells[13, 9 + i]); //取得合并的区域   
                        //            r6.ColumnWidth = 10;
                        //            r6.MergeCells = true;
                        //            r6.Columns.WrapText = true;
                        //            r6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //        }

                        //        Microsoft.Office.Interop.Excel.Range r7;
                        //        r7 = ws.get_Range(ws.Cells[13, 1], ws.Cells[13, 8]); //取得合并的区域 
                        //        r7.RowHeight = 35;
                        //        r7.Columns.WrapText = true;
                        //        r7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        //        excel.Cells[13, 3] = "生产工单编号";
                        //        excel.Cells[13, 4] = "客户名称";
                        //        excel.Cells[14, 8] = "PLANNED";
                        //        excel.Cells[15, 8] = "ACTUAL";
                        //        excel.Cells[16, 8] = "DELAIED";

                        //        string[] strHeader = title.Split(',');
                        //        for (int i = 0; i < strHeader.Length; i++)
                        //        {
                        //            excel.Cells[12, i + 1] = strHeader[i].ToString();
                        //        }

                        //        //填充数据
                        //        foreach (DataRow orderDr in orderHeadDt.Rows)
                        //        {
                        //            excel.Cells[14, 1] = "'" + CConvert.ToString(orderDr["SLIP_NUMBER"]);
                        //            excel.Cells[14, 2] = "'" + CConvert.ToDateTime(orderDr["SLIP_DATE"]).ToString("yyyy-MM-dd");
                        //            excel.Cells[14, 4] = CConvert.ToString(orderDr["CUSTOMER_NAME"]);
                        //            excel.Cells[14, 5] = CConvert.ToString(orderDr["SPEC"]);
                        //            excel.Cells[14, 6] = CConvert.ToString(orderDr["DESCRIPTION"]);
                        //        }

                        //        foreach (DataRow scheduleDr in scheduleDt.Rows)
                        //        {
                        //            excel.Cells[14, 3] = "'" + CConvert.ToString(scheduleDr["SLIP_NUMBER"]);
                        //        }
                        //        int drawingcount = 0;
                        //        int drawingcount1 = 0;
                        //        foreach (DataRow dr2 in drawingDt.Rows)
                        //        {
                        //            drawingcount++;
                        //            excel.Cells[12, 8 + drawingcount] = CConvert.ToString(dr2["NAME"]);

                        //            if (dr2["PSDL_PLAN_END_DATE"].ToString() != "")
                        //            {
                        //                excel.Cells[14, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).ToString("yyyy-MM-dd");
                        //            }
                        //            else
                        //            {
                        //            }

                        //            if (dr2["PSDL_ACTUAL_END_TIME"].ToString() != "")
                        //            {
                        //                excel.Cells[15, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).ToString("yyyy-MM-dd");

                        //                if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]))
                        //                {
                        //                    excel.Cells[16, 8 + drawingcount] = "'" + "0天";
                        //                }
                        //                else
                        //                {
                        //                    string dateDiff = null;
                        //                    TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
                        //                    TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).Ticks);
                        //                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                        //                    dateDiff = ts.Days.ToString() + "天";
                        //                    excel.Cells[16, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
                        //                }
                        //            }

                        //            else
                        //            {
                        //                if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(DateTime.Now))
                        //                {
                        //                    excel.Cells[16, 8 + drawingcount] = "'" + "0天";
                        //                }
                        //                else
                        //                {
                        //                    string dateDiff = null;
                        //                    TimeSpan ts1 = new TimeSpan();
                        //                    TimeSpan ts2 = new TimeSpan();
                        //                    //TimeSpan 
                        //                    ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
                        //                    //TimeSpan 
                        //                    ts2 = new TimeSpan(CConvert.ToDateTime(DateTime.Now).Ticks);
                        //                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                        //                    dateDiff = ts.Days.ToString() + "天";
                        //                    excel.Cells[16, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
                        //                }
                        //            }
                        //        }

                        //    }
                        //}
                        #endregion
                    }

                    try
                    {
                        sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                        book.Close(false, miss, miss);
                        books.Close();
                        excel.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                        GC.Collect();
                        MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Excel文件保存失败。", null);
                        return;
                    }

                }

            }
            #region
            //if (CHKchooseCount < 1)
            //{
            //    MessageBox.Show("请选择要导出的数据!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (CHKchooseCount > 1)
            //{
            //    MessageBox.Show("只能选择一条数据导出!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (drawingDt != null)
            //{
            //    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //    saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
            //    saveFileDialog.FilterIndex = 0;
            //    saveFileDialog.Title = "导出文件保存路径";
            //    saveFileDialog.FileName = "PRODUCTION_DRAWING" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            //    string sheetName = "PRODUCTIONDRAWINGDETAIL";
            //    string title = "PO.,DATE,PLANT CODE,,尺寸,描述,DELAIED,CONTROL";
            //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        string strName = saveFileDialog.FileName;
            //        if (strName.Length != 0)
            //        {
            //            System.Reflection.Missing miss = System.Reflection.Missing.Value;
            //            Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            //            excel.Application.Workbooks.Add(true); ;
            //            excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
            //            if (excel == null)
            //            {
            //                Logger.Error("Excel文件保存失败。", null);
            //                return;
            //            }
            //            Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
            //            Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
            //            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            //            sheet.Name = sheetName;
            //            //int m = 0, n = 0;
            //            ////生成列名称 这里i是从1开始的 因为我第0列是个隐藏列ID 没必要写进去

            //            Microsoft.Office.Interop.Excel._Worksheet ws = new Microsoft.Office.Interop.Excel.WorksheetClass();
            //            ws = (Microsoft.Office.Interop.Excel._Worksheet)excel.ActiveSheet; //取得当前worksheet 

            //            Microsoft.Office.Interop.Excel.Range r;
            //            r = ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 8]); //取得合并的区域 
            //            r.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //            r.RowHeight = 25;
            //            r.MergeCells = true;

            //            Microsoft.Office.Interop.Excel.Range r1;
            //            r1 = ws.get_Range(ws.Cells[2, 3], ws.Cells[2, 4]); //取得合并的区域 
            //            r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //            r1.MergeCells = true;

            //            for (int i = 0; i < 4; i++)
            //            {
            //                Microsoft.Office.Interop.Excel.Range r2;
            //                r2 = ws.get_Range(ws.Cells[2, 5 + i], ws.Cells[3, 5 + i]); //取得合并的区域 
            //                r2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //                r2.MergeCells = true;
            //            }

            //            Microsoft.Office.Interop.Excel.Range r3;
            //            r3 = ws.get_Range(ws.Cells[1, 9], ws.Cells[1, 8 + CConvert.ToInt32(drawingDt.Rows.Count)]); //取得合并的区域                                     
            //            r3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //            //r3.RowHeight = 30;
            //            r3.ColumnWidth = 10;
            //            r3.MergeCells = true;

            //            Microsoft.Office.Interop.Excel.Range r4;
            //            r4 = ws.get_Range(ws.Cells[3, 1], ws.Cells[3, 8]); //取得合并的区域 
            //            r4.RowHeight = 35;
            //            r4.Columns.WrapText = true;
            //            r4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //            for (int i = 1; i < 8; i++)
            //            {
            //                Microsoft.Office.Interop.Excel.Range r5;
            //                r5 = ws.get_Range(ws.Cells[4, i], ws.Cells[6, i]); //取得合并的区域                                             
            //                r5.MergeCells = true;
            //                r5.Columns.WrapText = true;
            //                r5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //            }

            //            for (int i = 0; i < drawingDt.Rows.Count; i++)
            //            {
            //                Microsoft.Office.Interop.Excel.Range r6;
            //                r6 = ws.get_Range(ws.Cells[2, 9 + i], ws.Cells[3, 9 + i]); //取得合并的区域                                             
            //                r6.MergeCells = true;
            //                r6.Columns.WrapText = true;
            //                r6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //            }

            //            //Microsoft.Office.Interop.Excel.Range r7;
            //            //r7 = ws.get_Range(ws.Cells[3, 9], ws.Cells[3, 8 + CConvert.ToInt32(drawingDt.Rows.Count)]); //取得合并的区域                                     
            //            //r7.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //            Microsoft.Office.Interop.Excel.Range r8;
            //            r8 = ws.get_Range(ws.Cells[4, 1], ws.Cells[6, 1]); //取得合并的区域                                     
            //            r8.ColumnWidth = 15;

            //            Microsoft.Office.Interop.Excel.Range r9;
            //            r9 = ws.get_Range(ws.Cells[4, 2], ws.Cells[6, 2]); //取得合并的区域                                     
            //            r9.ColumnWidth = 10;

            //            Microsoft.Office.Interop.Excel.Range r10;
            //            r10 = ws.get_Range(ws.Cells[4, 3], ws.Cells[6, 3]); //取得合并的区域                                     
            //            r10.ColumnWidth = 15;

            //            Microsoft.Office.Interop.Excel.Range r11;
            //            r11 = ws.get_Range(ws.Cells[4, 7], ws.Cells[6, 7]); //取得合并的区域                                     
            //            r11.ColumnWidth = 10;

            //            Microsoft.Office.Interop.Excel.Range r12;
            //            r12 = ws.get_Range(ws.Cells[2, 1], ws.Cells[3, 1]); //取得合并的区域                                     
            //            r12.MergeCells = true;
            //            r12.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //            Microsoft.Office.Interop.Excel.Range r13;
            //            r13 = ws.get_Range(ws.Cells[2, 2], ws.Cells[3, 2]); //取得合并的区域                                     
            //            r13.MergeCells = true;
            //            r13.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //            excel.Cells[1, 1] = "生产工单明细";
            //            excel.Cells[1, 9] = "生产工单图纸状态";
            //            excel.Cells[3, 3] = "生产工单编号";
            //            excel.Cells[3, 4] = "客户名称";
            //            excel.Cells[4, 8] = "PLANNED";
            //            excel.Cells[5, 8] = "ACTUAL";
            //            excel.Cells[6, 8] = "DELAIED";

            //            string[] strHeader = title.Split(',');
            //            for (int i = 0; i < strHeader.Length; i++)
            //            {
            //                excel.Cells[2, i + 1] = strHeader[i].ToString();
            //            }

            //            //填充数据
            //            foreach (DataRow orderDr in orderHeadDt.Rows)
            //            {
            //                excel.Cells[4, 1] = "'" + CConvert.ToString(orderDr["SLIP_NUMBER"]);
            //                excel.Cells[4, 2] = "'" + CConvert.ToDateTime(orderDr["SLIP_DATE"]).ToString("yyyy-MM-dd");
            //                excel.Cells[4, 4] = CConvert.ToString(orderDr["CUSTOMER_NAME"]);
            //                excel.Cells[4, 5] = CConvert.ToString(orderDr["SPEC"]);
            //                excel.Cells[4, 6] = CConvert.ToString(orderDr["DESCRIPTION"]);

            //            }

            //            foreach (DataRow scheduleDr in scheduleDt.Rows)
            //            {
            //                excel.Cells[4, 3] = "'" + CConvert.ToString(scheduleDr["SLIP_NUMBER"]);
            //            }
            //            int drawingcount = 0;
            //            int drawingcount1 = 0;
            //            foreach (DataRow dr2 in drawingDt.Rows)
            //            {
            //                drawingcount++;
            //                excel.Cells[2, 8 + drawingcount] = CConvert.ToString(dr2["NAME"]);

            //                if (dr2["PSDL_PLAN_END_DATE"].ToString() != "")
            //                {
            //                    excel.Cells[4, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).ToString("yyyy-MM-dd");
            //                }
            //                else
            //                {
            //                }

            //                if (dr2["PSDL_ACTUAL_END_TIME"].ToString() != "")
            //                {
            //                    excel.Cells[5, 8 + drawingcount] = "'" + CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).ToString("yyyy-MM-dd");

            //                    if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]))
            //                    {
            //                        excel.Cells[6, 8 + drawingcount] = "'" + "0天";
            //                    }
            //                    else
            //                    {
            //                        string dateDiff = null;
            //                        TimeSpan ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
            //                        TimeSpan ts2 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_ACTUAL_END_TIME"]).Ticks);
            //                        TimeSpan ts = ts1.Subtract(ts2).Duration();
            //                        dateDiff = ts.Days.ToString() + "天";
            //                        excel.Cells[6, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
            //                    }
            //                }

            //                else
            //                {
            //                    if (CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]) >= CConvert.ToDateTime(DateTime.Now))
            //                    {
            //                        excel.Cells[6, 8 + drawingcount] = "'" + "0天";
            //                    }
            //                    else
            //                    {
            //                        string dateDiff = null;
            //                        TimeSpan ts1 = new TimeSpan();
            //                        TimeSpan ts2 = new TimeSpan();
            //                        //TimeSpan 
            //                        ts1 = new TimeSpan(CConvert.ToDateTime(dr2["PSDL_PLAN_END_DATE"]).Ticks);
            //                        //TimeSpan 
            //                        ts2 = new TimeSpan(CConvert.ToDateTime(DateTime.Now).Ticks);
            //                        TimeSpan ts = ts1.Subtract(ts2).Duration();
            //                        dateDiff = ts.Days.ToString() + "天";
            //                        excel.Cells[6, 8 + drawingcount] = "'" + CConvert.ToString(dateDiff);
            //                    }
            //                }
            //            }

            //            try
            //            {
            //                sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
            //                book.Close(false, miss, miss);
            //                books.Close();
            //                excel.Quit();
            //                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
            //                System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
            //                System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
            //                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            //                GC.Collect();
            //                MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            }
            //            catch (Exception ex)
            //            {
            //                Logger.Error("Excel文件保存失败。", null);
            //                return;
            //            }
            //        }
            //        return;
            //    }


            //}
            #endregion
        }
        #endregion

        private void btnExprotExcel_Click(object sender, EventArgs e)
        {
            DataTable scheduleDt = dgvData.DataSource as DataTable;

            if (scheduleDt != null)
            {

                int result = CExport.DataTableToExcel(scheduleDt, CConstant.SCHEDULE_HEADER, CConstant.SCHEDULE_COLUMNS, "SCHEDULE", "SCHEDULE");
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

        private void btnSales_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("USER", " DEPARTMENT_CODE='D01'");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtSales.Text = frm.BaseMasterTable.Name;
                    txtSalesCode.Text = frm.BaseMasterTable.Code.Substring(2);                  
                }
            }
            frm.Dispose();
        }

        private void txtSalesCode_Leave(object sender, EventArgs e)
        {
            string SalesCode = CConstant.DEFAULT_COMPANY_CODE+txtSalesCode.Text.Trim();
            if (SalesCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("USER", SalesCode);
                if (baseMaster != null)
                {
                    txtSalesCode.Text = baseMaster.Code.Substring(2);
                    txtSales.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("销售人员编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSalesCode.Text = "";
                    txtSales.Text = "";
                    txtSalesCode.Focus();
                }
            }
            else
            {
                txtSales.Text = "";
            }
        }

        private void btnSales_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnSales_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }


    }
}
