using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Model.Master;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.CacheData;
using log4net.Repository.Hierarchy;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Main;

namespace CZZD.ERP.WinUI.Master
{
    public partial class FrmTechnologyDialog : FrmBase
    {
        public FrmTechnologyDialog()
        {
            InitializeComponent();
        }

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DialogResult result = DialogResult.Cancel;
        private BaseUserTable _userInfo;
        private int _mode = 1;
        BaseTechnologyTable _currentTechnologyTable = null;
        BTechnology bTechnology = new BTechnology();

        public BaseTechnologyTable CurrentTechnologyTable
        {
            get { return _currentTechnologyTable; }
            set { _currentTechnologyTable = value; }
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
                if (_currentTechnologyTable == null)
                {
                    _currentTechnologyTable = new BaseTechnologyTable();
                }
                _currentTechnologyTable.CODE = this.txtTechnologyCode.Text.Trim();
                _currentTechnologyTable.NAME = txtTechnologyName.Text.Trim();
                _currentTechnologyTable.TECHNOLOGY_DRAWING1 = txtTechnologyDrawingCode1.Text.Trim();
                _currentTechnologyTable.TECHNOLOGY_DRAWING2 = txtTechnologyDrawingCode2.Text.Trim();
                _currentTechnologyTable.TECHNOLOGY_DRAWING3 = txtTechnologyDrawingCode3.Text.Trim();
                _currentTechnologyTable.DEPARTMENT_CODE = txtDepartmentCode.Text.Trim();
                _currentTechnologyTable.PERIOD = CConvert.ToInt32(txtPeriod.Text.Trim());
                _currentTechnologyTable.LAST_UPDATE_USER = _userInfo.CODE;

                try
                {
                    if (bTechnology.Exists(txtTechnologyCode.Text.Trim()))
                    {
                        bTechnology.Update(_currentTechnologyTable);
                    }
                    else
                    {
                        _currentTechnologyTable.CREATE_USER = _userInfo.CODE;
                        bTechnology.Add(_currentTechnologyTable);
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
            if (string.IsNullOrEmpty(this.txtTechnologyCode.Text.Trim()))
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


        private void FrmTechnologyDialog_Load(object sender, EventArgs e)
        {

            if (_currentTechnologyTable != null)
            {
                txtTechnologyCode.Text = _currentTechnologyTable.CODE;
                txtTechnologyName.Text = _currentTechnologyTable.NAME;
                txtTechnologyDrawingCode1.Text = _currentTechnologyTable.TECHNOLOGY_DRAWING1;
                txtTechnologyDrawingCode2.Text = _currentTechnologyTable.TECHNOLOGY_DRAWING2;
                txtTechnologyDrawingCode3.Text = _currentTechnologyTable.TECHNOLOGY_DRAWING3;
                txtDepartmentCode.Text = _currentTechnologyTable.DEPARTMENT_CODE;
                txtPeriod.Text = _currentTechnologyTable.PERIOD.ToString();

                txtTechnologyDrawingName1.Text = _currentTechnologyTable.TECHNOLOGY_DRAWINGNAME1;
                txtTechnologyDrawingName2.Text = _currentTechnologyTable.TECHNOLOGY_DRAWINGNAME2;
                txtTechnologyDrawingName3.Text = _currentTechnologyTable.TECHNOLOGY_DRAWINGNAME3;
                txtDepartmentName.Text = _currentTechnologyTable.DEPARTMENT_NAME;

            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtTechnologyCode.BackColor = Color.WhiteSmoke;
                txtTechnologyCode.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtTechnologyCode.Text = "";
            }
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DEPARTMENT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {

                    txtDepartmentCode.Text = frm.BaseMasterTable.Code;
                    txtDepartmentName.Text = frm.BaseMasterTable.Name;
                    txtDepartmentCode.Focus();
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void btnTechnologyDrawing1_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {

                    txtTechnologyDrawingCode1.Text = frm.BaseMasterTable.Code;
                    txtTechnologyDrawingName1.Text = frm.BaseMasterTable.Name;
                    txtTechnologyDrawingCode1.Focus();
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void btnTechnologyDrawing2_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {

                    txtTechnologyDrawingCode2.Text = frm.BaseMasterTable.Code;
                    txtTechnologyDrawingName2.Text = frm.BaseMasterTable.Name;
                    txtTechnologyDrawingCode2.Focus();
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void btnTechnologyDrawing3_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {

                    txtTechnologyDrawingCode3.Text = frm.BaseMasterTable.Code;
                    txtTechnologyDrawingName3.Text = frm.BaseMasterTable.Name;
                    txtTechnologyDrawingCode3.Focus();
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定取消吗?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                result = DialogResult.Cancel;
                this.Close();
            }
        }

        private void txtTechnologyCode_Leave(object sender, EventArgs e)
        {


            //判断编号是否已存在
            if (!(txtTechnologyCode.Focused))
            {
                BaseTechnologyTable TechnologyTable = new BaseTechnologyTable();
                TechnologyTable = bTechnology.GetModel(txtTechnologyCode.Text);
                if (TechnologyTable != null)
                {
                    txtTechnologyCode.Text = "";
                    MessageBox.Show("技术编号已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void FrmTechnologyDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtTechnologyCode.Focus();
            }
            else
            {
                txtTechnologyName.Focus();
            }
        }

        private void FrmTechnologyDialog_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                if (txtTechnologyCode.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtTechnologyName.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }

        private void btnDepartment_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnDepartment_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnTechnologyDrawing1_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnTechnologyDrawing1_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnTechnologyDrawing2_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnTechnologyDrawing2_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnTechnologyDrawing3_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnTechnologyDrawing3_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void FrmTechnologyDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void txtDepartmentCode_Leave(object sender, EventArgs e)
        {
            string DepartmentCode = txtDepartmentCode.Text.Trim();
            if (DepartmentCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DEPARTMENT", DepartmentCode);
                if (baseMaster != null)
                {
                    txtDepartmentCode.Text = baseMaster.Code;
                    txtDepartmentName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("部门编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDepartmentCode.Text = "";
                    txtDepartmentName.Text = "";
                    txtDepartmentCode.Focus();
                }
            }
            else
            {
                txtDepartmentName.Text = "";
            }
        }

        private void txtTechnologyDrawingCode1_Leave(object sender, EventArgs e)
        {
            string TechnologyDrawingCode1 = txtTechnologyDrawingCode1.Text.Trim();
            if (TechnologyDrawingCode1 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DRAWING", TechnologyDrawingCode1);
                if (baseMaster != null)
                {
                    txtTechnologyDrawingCode1.Text = baseMaster.Code;
                    txtTechnologyDrawingName1.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("技术图纸编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTechnologyDrawingCode1.Text = "";
                    txtTechnologyDrawingName1.Text = "";
                    txtTechnologyDrawingCode1.Focus();
                }
            }
            else
            {
                txtTechnologyDrawingName1.Text = "";
            }
        }

        private void txtTechnologyDrawingCode2_Leave(object sender, EventArgs e)
        {
            string TechnologyDrawingCode2 = txtTechnologyDrawingCode2.Text.Trim();
            if (TechnologyDrawingCode2 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DRAWING", TechnologyDrawingCode2);
                if (baseMaster != null)
                {
                    txtTechnologyDrawingCode2.Text = baseMaster.Code;
                    txtTechnologyDrawingName2.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("技术图纸编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTechnologyDrawingCode2.Text = "";
                    txtTechnologyDrawingName2.Text = "";
                    txtTechnologyDrawingCode2.Focus();
                }
            }
            else
            {
                txtTechnologyDrawingName2.Text = "";
            }
        }

        private void txtTechnologyDrawingCode3_Leave(object sender, EventArgs e)
        {
            string TechnologyDrawingCode3 = txtTechnologyDrawingCode3.Text.Trim();
            if (TechnologyDrawingCode3 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DRAWING", TechnologyDrawingCode3);
                if (baseMaster != null)
                {
                    txtTechnologyDrawingCode3.Text = baseMaster.Code;
                    txtTechnologyDrawingName3.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("技术图纸编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTechnologyDrawingCode3.Text = "";
                    txtTechnologyDrawingName3.Text = "";
                    txtTechnologyDrawingCode3.Focus();
                }
            }
            else
            {
                txtTechnologyDrawingName3.Text = "";
            }
        }
    }
}
