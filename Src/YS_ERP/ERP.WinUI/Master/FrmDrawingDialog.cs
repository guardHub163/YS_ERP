using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.WinUI.Master
{
    public partial class FrmDrawingDialog : Form
    {
        public FrmDrawingDialog()
        {
            InitializeComponent();
        }

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DialogResult result = DialogResult.Cancel;
        private BaseUserTable _userInfo;
        private int _mode = 1;
        BaseDrawingTable _currentDrawingTable = null;
        BDrawing bDrawing = new BDrawing();

        public BaseDrawingTable CurrentDrawingTable
        {
            get { return _currentDrawingTable; }
            set { _currentDrawingTable = value; }
        }

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentDrawingTable == null)
                {
                    _currentDrawingTable = new BaseDrawingTable();
                }
                _currentDrawingTable.CODE = this.txtDrawingCode.Text.Trim();
                _currentDrawingTable.NAME = txtDrawingName.Text.Trim();

                _currentDrawingTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bDrawing.Exists(txtDrawingCode.Text.Trim()))
                    {
                        bDrawing.Update(_currentDrawingTable);
                    }
                    else
                    {
                        _currentDrawingTable.CREATE_USER = _userInfo.CODE;
                        bDrawing.Add(_currentDrawingTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败,请重新输入!");
                    Logger.Error("订单类型保存失败!", ex);
                    return;
                }
                result = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断材料编号不能为空
            if (string.IsNullOrEmpty(this.txtDrawingCode.Text.Trim()))
            {
                strErrorlog += "编号不能为空!\r\n";
            }

            if (strErrorlog != null)
            {
                MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }


        private void FrmDrawingDialog_Load(object sender, EventArgs e)
        {

            if (_currentDrawingTable != null)
            {
                txtDrawingCode.Text = _currentDrawingTable.CODE;
                txtDrawingName.Text = _currentDrawingTable.NAME;
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtDrawingCode.BackColor = Color.WhiteSmoke;
                txtDrawingCode.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtDrawingCode.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FrmDrawingDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void txtDrawingCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在

            BaseDrawingTable DrawingTable = new BaseDrawingTable();
            DrawingTable = bDrawing.GetModel(txtDrawingCode.Text);
            if (DrawingTable != null)
            {
                txtDrawingCode.Text = "";
                MessageBox.Show("图纸编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
