using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.CacheData;
using CZZD.ERP.WinUI.Properties;

namespace CZZD.ERP.WinUI
{
    public partial class FrmDownLoadCustomerDrawing : FrmBase
    {
        public FrmDownLoadCustomerDrawing()
        {
            InitializeComponent();
        }
        BOrderHeader orderHeader = new BOrderHeader();
        private string _tmpAttachedDirectoryName = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
        private string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_ORDER);
        private int attachedNumber = 0;
        private void FrmDownLoadCustomerDrawing_Load(object sender, EventArgs e)
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strWhere = GetConduction();
            DataSet ds = orderHeader.GetList(strWhere);
            if (ds.Tables[0].Rows.Count < 1)
            {
                txtSlipNumber.Text = "";
                txtSlipDateFrom.Checked = false;
                txtSlipDateTo.Checked = false;
                txtDepartualDateFrom.Checked = false;
                txtDepartualDateTo.Checked = false;
                dgvData.DataSource = ds.Tables[0];

                //dgvData.Rows.Clear();
                MessageBox.Show("查询的信息不存在!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                dgvData.DataSource = ds.Tables[0];
                foreach (DataGridViewRow dr in dgvData.Rows)
                {
                    if (!CConstant.EXIST_ATTACHED.Equals(dr.Cells["ATTACHED_FLAG"].Value))
                    {
                        dr.Cells["DOWN_LOAD"].ReadOnly = true;
                    }
                }
            }
        }
        private string GetConduction()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" STATUS_FLAG <> {0}", CConstant.DELETE);
            if (!string.IsNullOrEmpty(txtSlipNumber.Text.Trim()))
            {
                sb.AppendFormat("AND SLIP_NUMBER like '{0}'", txtSlipNumber.Text.Trim());
            }
            //出库预定日期From
            if (this.txtSlipDateFrom.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE >= '{0}'", txtSlipDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            //出库预定日期To
            if (this.txtSlipDateTo.Checked)
            {
                sb.AppendFormat(" AND SLIP_DATE < '{0}'", txtSlipDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            if (this.txtDepartualDateFrom.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE >= '{0}'", txtDepartualDateFrom.Value.ToString("yyyy-MM-dd"));
            }
            if (this.txtDepartualDateTo.Checked)
            {
                sb.AppendFormat(" AND DEPARTUAL_DATE < '{0}'", txtDepartualDateTo.Value.AddDays(1).ToString("yyyy-MM-dd"));
            }
            return sb.ToString();

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
                    row.Cells["No"].Value = e.RowIndex + 1;

                    if (CConstant.EXIST_ATTACHED.Equals(row.Cells["ATTACHED_FLAG"].Value))
                    {
                        row.Cells["DOWN_LOAD"].Value = Resources.line_download_over;
                    }
                    else
                    {
                        row.Cells["DOWN_LOAD"].Value = Resources.line_download;
                    }
                }

            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == dgvData.Columns["DOWN_LOAD"].Index)
            //    {
            //        FrmProductionDownLoadCustomer frm = new FrmProductionDownLoadCustomer();
            //        string _oldSlipNumber = dgvData.Rows[e.RowIndex].Cells["SLIP_NUMBER"].Value.ToString();

            //        if (string.IsNullOrEmpty(_oldSlipNumber))
            //        {
            //            frm = new FrmProductionDownLoadCustomer(_tmpAttachedDirectoryName, _attachedDirectory);
            //        }
            //        else
            //        {
            //            frm = new FrmProductionDownLoadCustomer(_oldSlipNumber, _attachedDirectory);
            //            frm.CTag = "CUSTOMER_DOWNLOAD";
            //        }

            //        if (frm != null)
            //        {
            //            frm.ShowDialog(this);
            //            attachedNumber = frm.AttachedNumber;
            //            frm.Dispose();
            //        }
            //    }
            //}
            //catch (Exception ex) { }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                if (e.ColumnIndex == dgvData.Columns["DOWN_LOAD"].Index)
                {
                    if (CConvert.ToString(row.Cells["SLIP_NUMBER"].Value) != "")
                    {
                        Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\order\\" + row.Cells["SLIP_NUMBER"].Value, "FTP_user", "czzd", 21);
                        string[] files = myftp.Dir("\\YS_ERP\\order\\" + row.Cells["SLIP_NUMBER"].Value);
                        //　附件
                        if (files.Length > 1)
                        {
                            string attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_ORDER);
                            string slipNumber = CConvert.ToString(row.Cells["SLIP_NUMBER"].Value);
                            FrmProductionDownLoadCustomer frm = new FrmProductionDownLoadCustomer(slipNumber, attachedDirectory);
                            frm.CTag = CConstant.ORDER_MODIFY;
                            frm.ShowDialog(this);
                            frm.Dispose();
                        }

                    }
                }
            }
        }
    }
}
