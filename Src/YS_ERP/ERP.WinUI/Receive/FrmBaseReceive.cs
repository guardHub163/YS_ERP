using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.CacheData;
using CZZD.ERP.Common;
using System.Collections;
using CZZD.ERP.IF;
using CZZD.ERP.IF.Receive;

namespace CZZD.ERP.WinUI
{
    public partial class FrmBaseReceive : FrmBase
    {
        public FrmBaseReceive()
        {
            InitializeComponent();
        }

        private DataTable _bindDt = new DataTable();
        private DataTable _currentTableStruct = new DataTable();
        private DataTable _currentImportStruct = new DataTable();
        private bool isSelect = false;
        private int selectRow;

        private void FrmBaseReceive_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            _bindDt.Columns.Add("NO", Type.GetType("System.String"));
            _bindDt.Columns.Add("TABLE_FILED", Type.GetType("System.String"));
            _bindDt.Columns.Add("EXCEL_FILED", Type.GetType("System.String"));
            _bindDt.Columns.Add("SELECT", Type.GetType("System.String"));
            _bindDt.Columns.Add("NAME", Type.GetType("System.String"));

            try
            {
                this.cboFileType.ValueMember = "CODE";
                this.cboFileType.DisplayMember = "NAME";
                this.cboFileType.DataSource = CCacheData.FileType.Copy();
            }
            catch { }

            try
            {
                this.cboBaseTable.ValueMember = "CODE";
                this.cboBaseTable.DisplayMember = "NAME";
                this.cboBaseTable.DataSource = CCacheData.BaseTable.Copy();
            }
            catch { }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();

            if ("EXCEL".Equals(cboFileType.SelectedValue))
            {
                of.Filter = "Excel文件|*.xls;*.xlsx";
                this.cboExcelSheet.Enabled = true;
            }
            else if ("TXT".Equals(cboFileType.SelectedValue))
            {
                of.Filter = "文本文件|*.txt";
                this.cboExcelSheet.Enabled = false;
            }
            else if ("CSV".Equals(cboFileType.SelectedValue))
            {
                of.Filter = "文本文件|*.csv";
                this.cboExcelSheet.Enabled = false;
            }

            if (DialogResult.OK == of.ShowDialog(this))
            {
                this.txtFilePath.Text = of.FileName;
                //EXCEL SHEET的获得
                if ("EXCEL".Equals(cboFileType.SelectedValue))
                {
                    DataTable dt = FileOperator.ReadExcelSheets(of.FileName);
                    this.cboExcelSheet.ValueMember = "TABLE_NAME";
                    this.cboExcelSheet.DisplayMember = "TABLE_NAME";
                    this.cboExcelSheet.DataSource = dt;                    
                }
                else if ("TXT".Equals(cboFileType.SelectedValue))
                {

                }
                else if ("CSV".Equals(cboFileType.SelectedValue)) { }


            }


        }

        /// <summary>
        /// 数据库表字段发生变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboBaseTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CConvert.ToString(cboBaseTable.SelectedValue)))
            {
                //_currentTableStruct = bCommon.GetTableStruct(CConvert.ToString(cboBaseTable.SelectedValue)).Tables[0];
                _currentTableStruct = CCacheData.GetTableColumn(CConvert.ToString(cboBaseTable.SelectedValue));
            }
            else
            {
                _currentTableStruct = new DataTable();
            }
            DataBind();
        }

        //excel表头发生变化时
        private void cboExcelSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //表头的取出
            if (!string.IsNullOrEmpty(txtFilePath.Text) && cboExcelSheet.Items.Count > 0)
            {
                _currentImportStruct = FileOperator.ReadExcelHeader(this.txtFilePath.Text, CConvert.ToString(this.cboExcelSheet.SelectedValue));
                DataBind();
            }

        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            _bindDt.Rows.Clear();
            List<string> columns = new List<string>();
            foreach (DataColumn dc in _currentImportStruct.Columns)
            {
                columns.Add(dc.ColumnName);
            }

            int i = 0;
            foreach (DataRow dr in _currentTableStruct.Rows)
            {
                string filedName = Convert.ToString(dr["name"]);
                if ("CREATE_USER".Equals(filedName) || "CREATE_DATE_TIME".Equals(filedName) || "LAST_UPDATE_TIME".Equals(filedName) || "LAST_UPDATE_USER".Equals(filedName))
                {
                    continue;
                }
                DataRow _dr = _bindDt.NewRow();
                string columnName = "";
                if (i < columns.Count)
                {
                    columnName = columns[i];
                }

                //_dr["NO"] = ++i;
                //_dr["TABLE_FILED"] = Convert.ToString(dr["description"]) + "(" + Convert.ToString(dr["type"]) + ")";
                i++;
                _dr["NO"] = dr["NO"];
                _dr["TABLE_FILED"] = dr["TABLE_FILED"];
                _dr["EXCEL_FILED"] = columnName;
                _dr["NAME"] = Convert.ToString(dr["name"]);
                _bindDt.Rows.Add(_dr);
            }

            this.dgvData.DataSource = _bindDt;
            if (rdoDefault.Checked)
            {
                this.dgvData.Columns["SELECT"].Visible = false;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable filedsHt = new Hashtable();
                foreach (DataGridViewRow dr in dgvData.Rows)
                {
                    filedsHt.Add(dr.Cells["NAME"].Value, dr.Cells["EXCEL_FILED"].Value);
                }

                AbstractReceive receive = null;
                if ("BASE_SLIP_TYPE".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new SlipTypeReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                    CCacheData.SlipType = null;
                 }
                else if ("BASE_COMPOSITION_PRODUCTS".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new CompositionProductsReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                }
                else if ("BASE_UNIT".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new UnitReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                }
                else if ("BASE_SUPPLIER".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new SupplierReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                }
                else if ("BASE_SPECIFICATION".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new SpecificationReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                }
                else if ("BASE_PRODUCT".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new ProductReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                }
                else if ("BASE_PRODUCT_GROUP".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new ProductGroupReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                }
                else if ("BASE_SLIP_TYPE_COMPOSITION_PRODUCTS".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new SlipTypeCompositionProductsReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                }
                else if ("BASE_PRODUCT_PARTS".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new ProductPartsReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                }
                else if ("BASE_COMPOSITION_PRODUCTS_SPECIFICATION".Equals(cboBaseTable.SelectedValue))
                {
                    receive = new CompositionProductsSpecificationReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                }
                
                //if ("BASE_PRODUCT_GROUP".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new ProductGroupReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_PRODUCT".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new ProductReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_PRODUCT_PARTS".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new ProductPartsReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_CUSTOMER".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new CustomerReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_SUPPLIER".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new SupplierReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_STOCK".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new StockReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_WAREHOUSE".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new WarehouseReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_LOCATION".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new LocationReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_CUSTOMER_PRICE".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new CustomerPriceReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_CUSTOMER_REPORTED".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new CustomerReportedReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_SUPPLIER_PRICE".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new SupplierPriceReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_PRODUCT_UNIT".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new ProductUnitReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_SAFETY_STOCK".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new SafetyStockReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_CURRENCY".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new CurrencyReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_TAXATION".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new TaxAtionReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_SLIP_TYPE".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new SlipTypeReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //    CCacheData.SlipType = null;
                //}
                //else if ("BASE_DELIVERY".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new DeliveryReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_MASTER_MACHINE".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new MasterMachineReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_USER".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new UserReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                //else if ("BASE_SLIP_TYPE_PRODUCT_GROUP".Equals(cboBaseTable.SelectedValue))
                //{
                //    receive = new MachineReceive(txtFilePath.Text, CConvert.ToString(cboFileType.SelectedValue), CConvert.ToString(cboExcelSheet.SelectedValue), filedsHt, _userInfo);
                //}
                string[] a = receive.DoReceiveJob();
                MessageBox.Show("成功导入" + a[0] + "行!\r\n失败导入" + a[1] + "行!\r\n" + a[2]);
                EndImport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作错误，请重新导入!");
            }
        }

        public void EndImport()
        {
            txtFilePath.Text = "";
            _currentImportStruct = new DataTable();
            cboExcelSheet.DataSource = null;
            cboBaseTable.SelectedIndex = 0;
            //DataBind();
            //MessageBox.Show("导入成功!");
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvData.Columns["SELECT"].Index && !lExcelname.Visible)
                {
                    lExcelname.Visible = true;
                    this.dgvData.Enabled = false;
                    List<string> columns = new List<string>();
                    foreach (DataColumn dc in _currentImportStruct.Columns)
                    {
                        columns.Add(dc.ColumnName);
                    }
                    lExcelname.Items.Add("无");
                    for (int i = 0; i < columns.Count; i++)
                    {
                        lExcelname.Items.Add(columns[i]);
                    }
                    isSelect = true;
                    selectRow = e.RowIndex;
                    int width = dgvData.Location.X + dgvData.Columns[0].Width + dgvData.Columns[1].Width;
                    lExcelname.Location = new Point(width, (dgvData.Location.Y + 25 + 23 * (selectRow + 1)));
                    if ((lExcelname.Size.Height + 25 + 23 * (selectRow + 1)) <= 444)
                    {

                    }
                    else
                    {
                        lExcelname.Location = new Point(width, (dgvData.Location.Y + 25 + 23 * (selectRow) - lExcelname.Size.Height));
                    }
                }
            }
            catch
            { }
        }

        private void lExcelname_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string excelName = CConvert.ToString(lExcelname.SelectedItem);
                if (excelName.Equals("无"))
                {
                    this.dgvData.Rows[selectRow].Cells["EXCEL_FILED"].Value = "";
                }
                else
                {
                    this.dgvData.Rows[selectRow].Cells["EXCEL_FILED"].Value = excelName;
                }
                //foreach (DataGridViewRow row in dgvData.Rows)
                //{
                //    if (excelName.Equals(row.Cells["EXCEL_FILED"].Value) && row.Index != selectRow)
                //    {
                //        row.Cells["EXCEL_FILED"].Value = "";
                //    }
                //}
                this.lExcelname.Visible = false;
                this.dgvData.Enabled = true;
                this.lExcelname.Items.Clear();
            }
            catch (Exception ex)
            { }
        }

        private void rdoDefault_Click(object sender, EventArgs e)
        {
            this.dgvData.Columns["SELECT"].Visible = false;
        }

        private void rdoCustomer_Click(object sender, EventArgs e)
        {
            this.dgvData.Columns["SELECT"].Visible = true;
        }


    }//end class
}
