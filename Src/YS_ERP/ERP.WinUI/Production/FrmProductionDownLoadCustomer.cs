using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using System.IO;
using System.Reflection;
using CZZD.ERP.Common;
using System.Collections;
using CZZD.ERP.Bll;
using CZZD.ERP.Bll.Product;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionDownLoadCustomer : Form
    {

        private string _slipNumber;
        private string _fullPath;
        public int AttachedNumber = 0;
        private DataTable _currentDt = new DataTable();
        public string CTag;
        public FrmProductionDownLoadCustomer()
        {
            InitializeComponent();
        }

        public FrmProductionDownLoadCustomer(string slipNumber, string path)
        {
            InitializeComponent();
            _slipNumber = slipNumber;
            _fullPath = path + _slipNumber + "\\";         
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void FrmProductionDownLoadCustomer_Load(object sender, EventArgs e)
        {
            _currentDt.Columns.Add("NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("SIZE", Type.GetType("System.String"));
            _currentDt.Columns.Add("TYPE", Type.GetType("System.String"));

            if (CConstant.ORDER_MODIFY.Equals(CTag))
            {
                try
                {
                    Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\order\\" + _slipNumber, "FTP_user", "czzd", 21);
                    string[] files = myftp.Dir("\\YS_ERP\\order\\" + _slipNumber);
                    for (int i = 0; i < files.Length - 1; i++)
                    {
                        string NAME = files[i].ToString().Substring(0, files[i].Length - 1);
                        long size = myftp.GetFileSize(files[i].Substring(0, files[i].Length - 1));

                        int currentRowIndex = dgvData.Rows.Add(1);
                        DataGridViewRow row = dgvData.Rows[currentRowIndex];
                        row.Cells["NAME"].Value = NAME;
                        row.Cells["SIZE"].Value = size;
                        row.Cells["TYPE"].Value = CCommon.GetFileType(NAME);
                    }

                }
                catch (Exception ex) { }
            }
            else
            {

                try
                {
                    if (Directory.Exists(_fullPath))
                    {
                        DirectoryInfo di = new DirectoryInfo(_fullPath);
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
                dgvData.DataSource = _currentDt;
            }
        }

        /// <summary>
        /// 附件增加
        /// </summary>
        private void AddAttached(FileInfo file)
        {
            DataRow dr = _currentDt.NewRow();
            dr["NAME"] = file.Name;
            dr["SIZE"] = file.Length;
            dr["TYPE"] = CCommon.GetFileType(file.FullName);
            _currentDt.Rows.Add(dr);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FrmProductionDownLoadCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            AttachedNumber = dgvData.Rows.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 附件下载
        /// </summary>
        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (_currentDt.Rows.Count > 0 || dgvData.SelectedRows.Count > 0)
            {
                string fileName = dgvData.SelectedRows[0].Cells["NAME"].Value.ToString();
                string extension = fileName.Substring(fileName.IndexOf('.'));
                if (CConstant.ORDER_MODIFY.Equals(CTag))
                {
                    try
                    {
                        FolderBrowserDialog of = new FolderBrowserDialog();
                        if (DialogResult.OK == of.ShowDialog(this))
                        {
                            Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\order\\" + _slipNumber, "FTP_user", "czzd", 21);
                            myftp.Get(fileName, of.SelectedPath, fileName);
                            MessageBox.Show("您选择的文件下载成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (IOException ex) { }
                }
                else
                {
                    try
                    {

                        SaveFileDialog sf = new SaveFileDialog();
                        sf.FileName = fileName;
                        sf.Filter = "(文件)|*" + extension;
                        sf.ValidateNames = true;
                        if (DialogResult.OK == sf.ShowDialog(this))
                        {
                            File.Copy(_fullPath + fileName, sf.FileName);
                        }
                    }
                    catch (IOException ex) { }
                }
            }
            else
            {
                MessageBox.Show("请选择需要下载的文件！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }//end class
}
