using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.CacheData;
using System.IO;

namespace CZZD.ERP.WinUI
{
    public partial class FrmOrderService : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private string _slipNumber = "";
        BllOrderServiceTable _currentTable = null;
        private DialogResult _dialogResult = DialogResult.Cancel;
        private string _parentAttachedDirectory = CCacheData.GetAttacheDirectory(CConstant.ATTACHE_DIRECTORY_ORDER);
        private string _attachedDirectoryName = "SERVICE";

        public FrmOrderService()
        {
            InitializeComponent();
        }

        public FrmOrderService(string slipNumber)
        {
            InitializeComponent();
            _slipNumber = slipNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        private void FrmOrderService_Load(object sender, EventArgs e)
        {
            this.txtSlipNumber.Text = _slipNumber;
            Init();
            _parentAttachedDirectory += _slipNumber + "\\";
        }

        private void Init()
        {
            _currentTable = bOrderHeader.GetOrderServiceMode(_slipNumber);
            if (_currentTable != null)
            {
                txtTitle.Text = _currentTable.TITLE;
                txtStartTime.Value = CConvert.ToDateTime(_currentTable.START_DATE_TIME);
                txtEndTime.Value = CConvert.ToDateTime(_currentTable.END_DATE_TIME);
                txtServiceUser.Text = _currentTable.SERVICE_USER;
                txtMemo.Text = _currentTable.MEMO;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentTable == null)
            {
                _currentTable = new BllOrderServiceTable();
                _currentTable.CREATE_USER = UserTable.CODE;
            }
            _currentTable.SLIP_NUMBER = _slipNumber;
            _currentTable.TITLE = txtTitle.Text;
            _currentTable.START_DATE_TIME = txtStartTime.Value;
            _currentTable.END_DATE_TIME = txtEndTime.Value;
            _currentTable.SERVICE_USER = txtServiceUser.Text;
            _currentTable.MEMO = txtMemo.Text;
            _currentTable.STATUS_FLAG = CConstant.INIT;
            _currentTable.LAST_UPDATE_USER = UserTable.CODE;
            int ret = 0;
            try
            {
                if (_currentTable.ID > 0)
                {
                    ret = bOrderHeader.UpdateOrderService(_currentTable);
                }
                else
                {
                    ret = bOrderHeader.AddOrderService(_currentTable);
                }

                if (ret > 0)
                {
                    MessageBox.Show("保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存失败。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Error("修理输入保存失败：", ex);
            }
        }

        /// <summary>
        /// 附件存放目录的删除
        /// </summary>
        private void DeleteDirectory()
        {
            string fullPath = _parentAttachedDirectory + _attachedDirectoryName;
            if (Directory.Exists(fullPath))
            {
                DirectoryInfo di = new DirectoryInfo(fullPath);
                di.Delete(true);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOrderService_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_dialogResult != DialogResult.OK)
            {
                if (_currentTable == null || _currentTable.ID <= 0)
                {
                    DeleteDirectory();
                }
            }
            this.DialogResult = _dialogResult;
        }

        private void btnAttached_Click(object sender, EventArgs e)
        {
            FrmAttached frm = new FrmAttached(_attachedDirectoryName, _parentAttachedDirectory);
            frm.ShowDialog(this);
            frm.Dispose();
        }




    }//end class
}
