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
    public partial class FrmProductionDownLoad : Form
    {
        private BProductionProcess bProductionProcess = new BProductionProcess();
        private BProductionDrawing bproductionDrawing = new BProductionDrawing();
        private BCompositionProductsProductionProcess bCompositionProductsProductionProcess = new BCompositionProductsProductionProcess();
        private BTechnology bTechnology = new BTechnology();
        private string _slipNumber;
        private string _fullPath;
        private string _productionProcessCode;
        private string _partsCode;
        private string _CTag;
        public int AttachedNumber = 0;
        private DataTable _currentDt = new DataTable();
        public FrmProductionDownLoad()
        {
            InitializeComponent();
        }

        public FrmProductionDownLoad(string slipNumber, string path, string productionProcessCode, string CTag, string partsCode)
        {
            InitializeComponent();
            _slipNumber = slipNumber;
            _fullPath = path + _slipNumber + "\\";
            _productionProcessCode = productionProcessCode;
            _CTag = CTag;
            _partsCode = partsCode;

        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void FrmProductionDownLoad_Load(object sender, EventArgs e)
        {
            _currentDt.Columns.Add("NAME", Type.GetType("System.String"));
            _currentDt.Columns.Add("SIZE", Type.GetType("System.String"));
            _currentDt.Columns.Add("TYPE", Type.GetType("System.String"));
            #region
            try
            {
                //if (Directory.Exists(_fullPath))
                // {
                // DirectoryInfo di = new DirectoryInfo(_fullPath);
                Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\production\\" + _slipNumber, "FTP_user", "czzd", 21);
                string[] files = myftp.Dir("\\YS_ERP\\production\\" + _slipNumber);
                Hashtable dwHt = new Hashtable();
                Hashtable technologyHt = new Hashtable();
                if (_CTag.Equals("productionProcess"))
                {
                    _currentDt.Rows.Clear();
                    DataTable productionProcessDt = bProductionProcess.GetList(" CODE = '" + _productionProcessCode + "'").Tables[0];
                    foreach (DataRow dr in productionProcessDt.Rows)
                    {
                        for (int l = 1; l <= 6; l++)
                        {
                            string dwCode = CConvert.ToString(dr["DRAWING_TYPE_CODE" + l]);
                            if (string.IsNullOrEmpty(dwCode))
                            {
                                continue;
                            }
                            if (dwHt.ContainsKey(dwCode))
                            {

                            }
                            else
                            {
                                dwHt.Add(dwCode, "");
                            }

                        }
                    }

                    foreach (DictionaryEntry de in dwHt)
                    {
                        DataTable drawingDt = new DataTable();
                        string drawingcode = de.Key.ToString();
                        drawingDt = bproductionDrawing.GetProductionDrawingUpload(" SLIP_NUMBER = '" + _slipNumber + "'" + " AND DRAWING_CODE = '" + drawingcode + "'").Tables[0];


                        if (drawingDt.Rows.Count > 0)
                        {
                            //FileInfo[] files = di.GetFiles();
                            foreach (DataRow dr in drawingDt.Rows)
                            {
                                foreach (string file in files)
                                {
                                    if (CConvert.ToString(dr["LOCATION_FILE_NAME"].ToString()).Equals(CConvert.ToString(file.ToString())))
                                    {
                                        int _count = 0;
                                        if (_currentDt.Rows.Count > 0)
                                        {
                                            //foreach (DataRow filecurrentDt in _currentDt.Rows)
                                            for (int t = 0; t < _currentDt.Rows.Count; t++)
                                            {

                                                if (CConvert.ToString(_currentDt.Rows[t]["NAME"].ToString()).Equals(CConvert.ToString(file.ToString())))
                                                {

                                                }
                                                else
                                                {
                                                    _count++;
                                                }

                                            }
                                            if (_currentDt.Rows.Count == _count)
                                            {
                                                AddAttached(file);
                                            }

                                        }
                                        else
                                        {
                                            AddAttached(file);
                                        }

                                    }
                                    //if (CConvert.ToString(drawingDt.Rows[0]["SERVER_FILE_NAME"].ToString()).Equals(CConvert.ToString(file.ToString())))
                                    //{
                                    //    AddAttached(file);
                                    //}
                                }
                            }
                        }
                    }

                }

                else
                {
                    _currentDt.Rows.Clear();
                    DataTable productionTechnologyDt = bCompositionProductsProductionProcess.GetList(" COMPOSITION_PRODUCTS_CODE = '" + _partsCode + "'" + " AND PRODUCTION_PROCESS_CODE = '" + _productionProcessCode + "'").Tables[0];

                    foreach (DataRow dr in productionTechnologyDt.Rows)
                    {
                        for (int j = 1; j <= 3; j++)
                        {
                            string technologyCode = CConvert.ToString(dr["TECHNOLOGY_CODE" + j]);
                            if (technologyCode != "")
                            {
                                DataTable technologyDt = bTechnology.GetList(" CODE = '" + technologyCode + "'").Tables[0];
                                foreach (DataRow drTechnology in technologyDt.Rows)
                                {
                                    for (int k = 1; k <= 3; k++)
                                    {
                                        string drawCode = CConvert.ToString(drTechnology["TECHNOLOGY_DRAWING" + k]);
                                        if (string.IsNullOrEmpty(drawCode))
                                        {
                                            continue;
                                        }
                                        if (technologyHt.ContainsKey(drawCode))
                                        {

                                        }
                                        else
                                        {
                                            technologyHt.Add(drawCode, "");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (DictionaryEntry de in technologyHt)
                    {
                        DataTable drawingDt = new DataTable();
                        string drawingcode = de.Key.ToString();
                        drawingDt = bproductionDrawing.GetProductionDrawingUpload(" SLIP_NUMBER = '" + _slipNumber + "'" + " AND DRAWING_CODE = '" + drawingcode + "'").Tables[0];

                        if (drawingDt.Rows.Count > 0)
                        {
                            try
                            {
                                //FileInfo[] files = di.GetFiles();
                                foreach (DataRow dr in drawingDt.Rows)
                                {
                                    foreach (string file in files)
                                    {
                                        if (CConvert.ToString(dr["LOCATION_FILE_NAME"].ToString()).Equals(CConvert.ToString(file.ToString())))
                                        {
                                            int _count = 0;
                                            if (_currentDt.Rows.Count > 0)
                                            {
                                                //foreach (DataRow filecurrentDt in _currentDt.Rows)
                                                for (int t = 0; t < _currentDt.Rows.Count; t++)
                                                {

                                                    if (CConvert.ToString(_currentDt.Rows[t]["NAME"].ToString()).Equals(CConvert.ToString(file.ToString())))
                                                    {

                                                    }
                                                    else
                                                    {
                                                        _count++;
                                                    }

                                                }
                                                if (_currentDt.Rows.Count == _count)
                                                {
                                                    AddAttached(file);
                                                }

                                            }
                                            else
                                            {
                                                AddAttached(file);
                                            }

                                        }
                                    }
                                }
                            }
                            catch (Exception ex) { }
                        }
                    }

                }
                // }
            }
            catch (IOException ex)
            {

            }
            #endregion
            dgvData.DataSource = _currentDt;
        }

        /// <summary>
        /// 附件增加
        /// </summary>
        private void AddAttached(string file)
        {
            DataRow dr = _currentDt.NewRow();
            dr["NAME"] = file.ToString().Substring(0, file.Length - 1);
            dr["SIZE"] = file.Length;
            dr["TYPE"] = CCommon.GetFileType(file.ToString().Substring(0, file.Length - 1));
            _currentDt.Rows.Add(dr);
        }

        /// <summary>
        /// 
        /// </summary>
        private void FrmProductionDownLoad_FormClosed(object sender, FormClosedEventArgs e)
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
            if (_currentDt.Rows.Count > 0 && dgvData.SelectedRows.Count > 0)
            {
                string fileName = dgvData.SelectedRows[0].Cells["NAME"].Value.ToString();
                string extension = fileName.Substring(fileName.IndexOf('.'));
                try
                {

                    //SaveFileDialog sf = new SaveFileDialog();
                    //sf.FileName = fileName;
                    //sf.Filter = "(文件)|*" + extension;
                    //sf.ValidateNames = true;
                    //if (DialogResult.OK == sf.ShowDialog(this))
                    //{
                    //    File.Copy(_fullPath + fileName, sf.FileName);
                    //}
                    FolderBrowserDialog of = new FolderBrowserDialog();
                    if (DialogResult.OK == of.ShowDialog(this))
                    {
                        Czzd.Common.Library.FTPOperate myftp = new Czzd.Common.Library.FTPOperate("112.82.245.2", "YS_ERP\\production\\" + _slipNumber, "FTP_user", "czzd", 21);
                        myftp.Get(fileName, of.SelectedPath, fileName);
                        MessageBox.Show("您选择的文件下载成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (IOException ex) { }
            }
            else
            {
                MessageBox.Show("请选择需要下载的文件！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }//end class
}
