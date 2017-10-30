using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.Common;
using CZZD.ERP.Model.Product;
using System.IO;
using CZZD.ERP.CacheData;
using CZZD.ERP.WinUI.Properties;
using System.Text.RegularExpressions;

namespace CZZD.ERP.WinUI.Production
{
    public partial class DrawingUpLoad : Form
    {
        private string _slipnumber;
        private string _drawing_code;

        public string SLIPNUMBER
        {
            set { _slipnumber = value; }
            get { return _slipnumber; }
        }

        public string DRAWING_CODE
        {
            set { _drawing_code = value; }
            get { return _drawing_code; }
        }

        public DrawingUpLoad()
        {
            InitializeComponent();
        }
        //private DialogResult result = DialogResult.OK;
        private DataTable _currentDt = new DataTable();
        BProductionDrawing bProductionDrawing = new BProductionDrawing();
        BaseProductionDrawingTable productionDrawing = new BaseProductionDrawingTable();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog.FileName;
            }
        }

        private void DrawingUpLoad_Load(object sender, EventArgs e)
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;

            string _tmpAttachedDirectoryName = SLIPNUMBER;
            string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PRODUCTION);
            DataSet ds = bProductionDrawing.GetProductionDrawing(" PSDL_SLIP_NUMBER = '" + SLIPNUMBER + "'" + " AND PSDL_STATUS_FLAG= '0'");
            clbDrawing.DataSource = ds.Tables[0];
            clbDrawing.ValueMember = "PSDL_DRAWING_CODE";
            clbDrawing.DisplayMember = "NAME";
            DataSet dsUpload = bProductionDrawing.GetProductionDrawingUpload(" SLIP_NUMBER = '" + SLIPNUMBER + "'" + " AND DRAWING_CODE= '" + DRAWING_CODE + "'");
            dgvData.DataSource = dsUpload.Tables[0];
            _currentDt.Columns.Add("NAME", Type.GetType("System.String"));
            try
            {
                if (Directory.Exists(_attachedDirectory + _tmpAttachedDirectoryName + "\\"))
                {
                    DirectoryInfo di = new DirectoryInfo(_attachedDirectory + _tmpAttachedDirectoryName + "\\");
                    FileInfo[] files = di.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        AddAttached(file);
                    }
                }
            }
            catch (IOException ex)
            {

            }
        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            string _tmpAttachedDirectoryName = SLIPNUMBER;
            string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PRODUCTION);

            if (txtFileName.Text.Trim() == "")
            {
                MessageBox.Show("文件名不能为空！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                if (!Directory.Exists(_attachedDirectory + _tmpAttachedDirectoryName + "\\"))
                {
                    Directory.CreateDirectory(_attachedDirectory + _tmpAttachedDirectoryName + "\\");
                    //Directory.CreateDirectory(_attachedDirectory + _tmpAttachedDirectoryName);
                    Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\production", "FTP_user", "czzd", 21);
                    myftp.MkDir(_tmpAttachedDirectoryName);
                }
                foreach (DataRow dr in _currentDt.Rows)
                {
                    if (openFileDialog.SafeFileName.Equals(dr["NAME"]))
                    {
                        MessageBox.Show("文件己经存在，请确认！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                AddAttached(new FileInfo(openFileDialog.FileName));
                File.Copy(openFileDialog.FileName, _attachedDirectory + _tmpAttachedDirectoryName + "\\" + openFileDialog.SafeFileName);

             
                   
           
                if (Directory.Exists(_attachedDirectory + _tmpAttachedDirectoryName))
                {
                    DirectoryInfo di = new DirectoryInfo(_attachedDirectory + _tmpAttachedDirectoryName);
                    FileInfo[] files = di.GetFiles();
                    Czzd.Common.Library.FTPOperate myftp1 = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\production\\"+_tmpAttachedDirectoryName, "FTP_user", "czzd", 21);
                    foreach (FileInfo file in files)
                    {
                        myftp1.Put("\\YY模具\\bin\\production\\" + _tmpAttachedDirectoryName + "\\" + file);
                    }

                    if (di.Exists)
                    {
                        DirectoryInfo[] childs = di.GetDirectories();
                        foreach (DirectoryInfo child in childs)
                        {
                            child.Delete(true);
                        }
                        di.Delete(true);
                    }
                }


            }

            catch (IOException ex)
            { }
            int result = 0;
            productionDrawing.Items.Clear();
            for (int i = 0; i < this.clbDrawing.Items.Count; i++)
            {
                BaseProductionDrawingTable productionDrawing1 = new BaseProductionDrawingTable();

                if (clbDrawing.GetItemChecked(i))
                {
                    productionDrawing1.SLIPNUMBER = SLIPNUMBER;
                    string[] sArray = Regex.Split(txtFileName.Text.Trim(), @"\\", RegexOptions.IgnoreCase);

                    //productionDrawing1.FILENAME = txtFileName.Text.Trim();
                    //productionDrawing1.SERVERFILENAME = sArray[sArray.Length - 1];


                    productionDrawing1.FILENAME = sArray[sArray.Length - 1];
                    productionDrawing1.SERVERFILENAME = sArray[sArray.Length - 1] + "_"  +DateTime.Now.ToString("yyyyMMddHHmmss");
                    clbDrawing.SelectedIndex = i;
                    productionDrawing1.DRAWINGCODE = clbDrawing.SelectedValue.ToString();

                    productionDrawing.AddItem(productionDrawing1);
                }
            }
            result = bProductionDrawing.Add(productionDrawing);
            if (result < 1)
            {
                MessageBox.Show("上传失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("上传成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFileName.Text = "";
                DataTable dt = new DataTable();
                clbDrawing.DataSource = dt;
                dgvData.DataSource = dt;
                DataSet ds = bProductionDrawing.GetProductionDrawing(" PSDL_SLIP_NUMBER = '" + SLIPNUMBER + "'" + " AND PSDL_STATUS_FLAG= '0'");
                clbDrawing.DataSource = ds.Tables[0];
                clbDrawing.ValueMember = "PSDL_DRAWING_CODE";
                clbDrawing.DisplayMember = "NAME";
                DataSet dsUpload = bProductionDrawing.GetProductionDrawingUpload(" SLIP_NUMBER = '" + SLIPNUMBER + "'" + " AND DRAWING_CODE= '" + DRAWING_CODE + "'");
                dgvData.DataSource = dsUpload.Tables[0];
            }

        }

        /// <summary>
        /// 附件增加
        /// </summary>
        private void AddAttached(FileInfo file)
        {
            DataRow dr = _currentDt.NewRow();
            dr["NAME"] = file.Name;
            _currentDt.Rows.Add(dr);
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
                    //
                    row.Cells["No"].Value = e.RowIndex + 1;
                }

            }
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int result = 0;

            try
            {
                if (e.ColumnIndex == dgvData.Columns["BTN_DELETE"].Index)
                {
                    if (MessageBox.Show("确定要删除当前行吗？", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        string SLIPNUMBER = dgvData.Rows[e.RowIndex].Cells["SLIP_NUMBER"].Value.ToString();
                        string DRAWINGCODE = dgvData.Rows[e.RowIndex].Cells["DRAWINGCODE"].Value.ToString();
                        string SERVERFILENAME = dgvData.Rows[e.RowIndex].Cells["FILENAME"].Value.ToString();
                        string LOCATION_FILE_NAME = dgvData.Rows[e.RowIndex].Cells["LOCATION_FILE_NAME"].Value.ToString();
                        
                        result = bProductionDrawing.Delete(SLIPNUMBER, DRAWINGCODE, SERVERFILENAME);
                        if (result < 1)
                        {
                            MessageBox.Show("删除失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            txtFileName.Text = "";
                            DataTable dt = new DataTable();
                            clbDrawing.DataSource = dt;
                            dgvData.DataSource = dt;
                            DataSet ds1 = bProductionDrawing.GetProductionDrawing(" PSDL_SLIP_NUMBER = '" + SLIPNUMBER + "'" + " AND PSDL_STATUS_FLAG= '0'");
                            clbDrawing.DataSource = ds1.Tables[0];
                            clbDrawing.ValueMember = "PSDL_DRAWING_CODE";
                            clbDrawing.DisplayMember = "NAME";
                            DataSet dsUpload = bProductionDrawing.GetProductionDrawingUpload(" SLIP_NUMBER = '" + SLIPNUMBER + "'" + " AND DRAWING_CODE= '" + DRAWING_CODE + "'");
                            dgvData.DataSource = dsUpload.Tables[0];
                            //MessageBox.Show("删除成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            DataSet ds = bProductionDrawing.GetProductionDrawingUpload(" SLIP_NUMBER = '" + SLIPNUMBER + "'" + " AND SERVER_FILE_NAME = '" + SERVERFILENAME + "'");
                            if (ds.Tables[0].Rows.Count < 1)
                            {
                                string _tmpAttachedDirectoryName = SLIPNUMBER;
                                string _attachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_PRODUCTION);
                               // File.Delete(_attachedDirectory + _tmpAttachedDirectoryName + "\\" + openFileDialog.SafeFileName + SERVERFILENAME);
                                Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\production\\" + _tmpAttachedDirectoryName, "FTP_user", "czzd", 21);
                                myftp.Delete(LOCATION_FILE_NAME);
                                MessageBox.Show("您选择的文件删除成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }


    }
}
