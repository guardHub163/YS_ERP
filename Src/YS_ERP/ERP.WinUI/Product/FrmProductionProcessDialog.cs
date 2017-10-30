using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.CacheData;
using CZZD.ERP.Main;


namespace CZZD.ERP.WinUI
{
    public partial class FrmProductionProcessDialog : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private BaseUserTable _userInfo;
        private BaseProductionProcessTable _currentProductionProcessTable = null;
        private int _mode = 1;
        private DialogResult result = DialogResult.Cancel;
        private BProductionProcess bProductionProcess = new BProductionProcess();

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public BaseUserTable UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        /// <summary>
        /// 当前数据
        /// </summary>
        public BaseProductionProcessTable CurrentProductionProcessTable
        {
            get { return _currentProductionProcessTable; }
            set { _currentProductionProcessTable = value; }
        }

        /// <summary>
        /// 当前操作状态
        /// </summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public FrmProductionProcessDialog()
        {
            InitializeComponent();
        }

        private void FrmProductionProcessDialog_Load(object sender, EventArgs e)
        {
            //btnDrawingType1.Enabled = true;
            //btnDrawingType2.Enabled = false;
            //btnDrawingType3.Enabled = false;
            //btnDrawingType4.Enabled = false;
            //btnDrawingType5.Enabled = false;
            //btnDrawingType6.Enabled = false;

            //cobdrawingtype.ValueMember = "CODE";
            //cobdrawingtype.DisplayMember = "NAME";
            //cobdrawingtype.DataSource = CCacheData.DrawingType;
            //DataTable ds = bProductionProcess.GETDEPARTMENT().Tables[0];
            // cobdepartment.DataSource = ds;
            //cobdepartment.DisplayMember = "NAME";
            //DataTable ds = bProductionProcess.GetDrawingType().Tables[0];
            //cobdrawingtype.DataSource = ds;
            //cobdrawingtype.DisplayMember = "NAME";
            //cobdrawingtype2.DataSource = ds;
            //cobdrawingtype2.DisplayMember = "NAME";
            //cobdrawingtype3.DataSource = ds;
            //cobdrawingtype3.DisplayMember = "NAME";
            //cobdrawingtype4.DataSource = ds;
            //cobdrawingtype4.DisplayMember = "NAME";
            //cobdrawingtype5.DataSource = ds;
            //cobdrawingtype5.DisplayMember = "NAME";
            //cobdrawingtype6.DataSource = ds;
            //cobdrawingtype6.DisplayMember = "NAME";
            //cobdrawingtype.SelectedIndex = -1;
            //cobdrawingtype2.SelectedIndex = -1;
            //cobdrawingtype3.SelectedIndex = -1;
            //cobdrawingtype4.SelectedIndex = -1;
            //cobdrawingtype5.SelectedIndex = -1;
            //cobdrawingtype6.SelectedIndex = -1;
            cboStatus.DataSource = CCacheData.JUDGMENT;
            cboStatus.ValueMember = "CODE";
            cboStatus.DisplayMember = "NAME";

            if (_currentProductionProcessTable != null)
            {
                txtCode.Text = _currentProductionProcessTable.CODE;
                txtName.Text = _currentProductionProcessTable.NAME;
                txtenglishname.Text = _currentProductionProcessTable.ENGLISHNAME;
                txtDepartment.Text = _currentProductionProcessTable.DEPARTMENT_NAME;
                txtDepartmentCode.Text = _currentProductionProcessTable.DEPARTMENT_CODE;
                txtDrawingType1.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME1;
                txtDrawingType2.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME2;
                txtDrawingType3.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME3;
                txtDrawingType4.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME4;
                txtDrawingType5.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME5;
                txtDrawingType6.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME6;
                txtDrawingTypeCode1.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE1;
                txtDrawingTypeCode2.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE2;
                txtDrawingTypeCode3.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE3;
                txtDrawingTypeCode4.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE4;
                txtDrawingTypeCode5.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE5;
                txtDrawingTypeCode6.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE6;
                txtTechnologyCode1.Text = _currentProductionProcessTable.TECHNOLOGY_CODE1;
                txtTechnologyCode2.Text = _currentProductionProcessTable.TECHNOLOGY_CODE2;
                txtTechnologyCode3.Text = _currentProductionProcessTable.TECHNOLOGY_CODE3;
                txtTechnology1.Text = _currentProductionProcessTable.TECHNOLOGY_NAME1;
                txtTechnology2.Text = _currentProductionProcessTable.TECHNOLOGY_NAME2;
                txtTechnology3.Text = _currentProductionProcessTable.TECHNOLOGY_NAME3;
                txtproductioncycle.Text = _currentProductionProcessTable.PRODUCTION_CYCLE.ToString();
                this.cboStatus.SelectedValue = _currentProductionProcessTable.JUDGMENT;
            }
            if (_mode == CConstant.MODE_NEW)
            {
                this.Text = "新建";

            }
            else if (_mode == CConstant.MODE_MODIFY)
            {
                this.Text = "编辑";
                txtCode.BackColor = Color.WhiteSmoke;
                txtCode.Enabled = false;
            }
            else if (_mode == CConstant.MODE_COPY)
            {
                this.Text = "新建";
                txtCode.Text = "";
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                if (_currentProductionProcessTable == null)
                {
                    _currentProductionProcessTable = new BaseProductionProcessTable();
                }
                _currentProductionProcessTable.CODE = txtCode.Text.Trim();
                _currentProductionProcessTable.NAME = txtName.Text.Trim();
                //_currentProductionProcessTable.COMPANY_CODE = "01";
                _currentProductionProcessTable.LAST_UPDATE_USER = _userInfo.CODE;
                _currentProductionProcessTable.ENGLISHNAME = txtenglishname.Text.Trim();
                _currentProductionProcessTable.DEPARTMENT_CODE = txtDepartmentCode.Text.Trim();
                _currentProductionProcessTable.DRAWING_TYPE_CODE1 = txtDrawingTypeCode1.Text.Trim();
                _currentProductionProcessTable.DRAWING_TYPE_CODE2 = txtDrawingTypeCode2.Text.Trim();
                _currentProductionProcessTable.DRAWING_TYPE_CODE3 = txtDrawingTypeCode3.Text.Trim();
                _currentProductionProcessTable.DRAWING_TYPE_CODE4 = txtDrawingTypeCode4.Text.Trim();
                _currentProductionProcessTable.DRAWING_TYPE_CODE5 = txtDrawingTypeCode5.Text.Trim();
                _currentProductionProcessTable.DRAWING_TYPE_CODE6 = txtDrawingTypeCode6.Text.Trim();
                _currentProductionProcessTable.PRODUCTION_CYCLE = CConvert.ToDecimal(txtproductioncycle.Text.Trim());
                _currentProductionProcessTable.ATTRIBUTE1 = "";
                _currentProductionProcessTable.ATTRIBUTE2 = "";
                _currentProductionProcessTable.ATTRIBUTE3 = "";
                _currentProductionProcessTable.TECHNOLOGY_CODE1 = txtTechnologyCode1.Text.Trim();
                _currentProductionProcessTable.TECHNOLOGY_CODE2 = txtTechnologyCode2.Text.Trim();
                _currentProductionProcessTable.TECHNOLOGY_CODE3 = txtTechnologyCode3.Text.Trim();
                _currentProductionProcessTable.JUDGMENT = cboStatus.SelectedValue.ToString();
                try
                {
                    if (bProductionProcess.Exists(txtCode.Text.Trim()))
                    {
                        bProductionProcess.Update(_currentProductionProcessTable);
                    }
                    else
                    {
                        _currentProductionProcessTable.CREATE_USER = _userInfo.CODE;
                        bProductionProcess.Add(_currentProductionProcessTable);
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
                CCacheData.DrawingType = null;
            }

        }

        /// <summary>
        /// 输入检查
        /// </summary>
        private bool CheckInput()
        {
            string strErrorlog = null;
            //判断材料编号不能为空
            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }

        private void FrmProductPartsDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = result;
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtName.Focused)
                {
                    btnSave.Focus();
                }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                    //ProcessTabKey(true);
                }
            }
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find;
        }

        private void btnSearch_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = Resources.find_over;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            //判断编号是否已存在
            if (!(txtCode.Focused))
            {
                BaseProductionProcessTable ProductionProcess = new BaseProductionProcessTable();
                ProductionProcess = bProductionProcess.GetModel(txtCode.Text);
                if (ProductionProcess != null)
                {
                    txtCode.Text = "";
                    MessageBox.Show("类型编号和订单编号的组合已存在，请重新输入!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtCode.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("+{Tab}");
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (txtName.Focused)
                { }
                else
                {
                    System.Windows.Forms.SendKeys.Send("{Tab}");
                }
            }
        }

        private void FrmProductionProcessDialog_Shown(object sender, EventArgs e)
        {
            if (_mode == CConstant.MODE_NEW || _mode == CConstant.MODE_COPY)
            {
                txtCode.Focus();
            }
            else
            {
                txtName.Focus();
            }
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DEPARTMENT", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDepartment.Text = frm.BaseMasterTable.Name;
                    txtDepartmentCode.Text = frm.BaseMasterTable.Code;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void btnDrawingType1_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDrawingType1.Text = frm.BaseMasterTable.Name;
                    txtDrawingTypeCode1.Text = frm.BaseMasterTable.Code;

                    //btnDrawingType2.Enabled = true;

                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }
        private void btnDrawingType2_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDrawingType2.Text = frm.BaseMasterTable.Name;
                    txtDrawingTypeCode2.Text = frm.BaseMasterTable.Code;

                    //btnDrawingType3.Enabled = true;

                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }
        private void btnDrawingType3_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDrawingType3.Text = frm.BaseMasterTable.Name;
                    txtDrawingTypeCode3.Text = frm.BaseMasterTable.Code;

                   // btnDrawingType4.Enabled = true;

                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }
        private void btnDrawingType4_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDrawingType4.Text = frm.BaseMasterTable.Name;
                    txtDrawingTypeCode4.Text = frm.BaseMasterTable.Code;

                    //btnDrawingType5.Enabled = true;

                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void btnDrawingType5_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDrawingType5.Text = frm.BaseMasterTable.Name;
                    txtDrawingTypeCode5.Text = frm.BaseMasterTable.Code;

                    //btnDrawingType6.Enabled = true;

                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }
        private void btnDrawingType6_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("DRAWING", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtDrawingType6.Text = frm.BaseMasterTable.Name;
                    txtDrawingTypeCode6.Text = frm.BaseMasterTable.Code;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void btnDepartment_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnDepartment_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnDrawingType1_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnDrawingType1_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnDrawingType2_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnDrawingType2_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnDrawingType3_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnDrawingType3_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnDrawingType4_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnDrawingType4_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnDrawingType5_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnDrawingType5_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnDrawingType6_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnDrawingType6_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnTechnology1_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnTechnology1_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnTechnology2_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnTechnology2_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnTechnology3_MouseEnter(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find_over);
        }

        private void btnTechnology3_MouseLeave(object sender, EventArgs e)
        {
            SetBackgroundImage(sender, Resources.find);
        }

        private void btnTechnology1_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("TECHNOLOGY", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtTechnology1.Text = frm.BaseMasterTable.Name;
                    txtTechnologyCode1.Text = frm.BaseMasterTable.Code;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void btnTechnology2_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("TECHNOLOGY", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtTechnology2.Text = frm.BaseMasterTable.Name;
                    txtTechnologyCode2.Text = frm.BaseMasterTable.Code;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void btnTechnology3_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("TECHNOLOGY", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtTechnology3.Text = frm.BaseMasterTable.Name;
                    txtTechnologyCode3.Text = frm.BaseMasterTable.Code;
                    btnSave.Focus();
                }
            }
            frm.Dispose();
        }

        private void FrmProductionProcessDialog_FormClosed(object sender, FormClosedEventArgs e)
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
                    txtDepartment.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("部门编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDepartmentCode.Text = "";
                    txtDepartment.Text = "";
                    txtDepartmentCode.Focus();
                }
            }
            else
            {
                txtDepartment.Text = "";
            }
        }

        private void txtDrawingTypeCode1_Leave(object sender, EventArgs e)
        {
            string DrawingTypeCode1 = txtDrawingTypeCode1.Text.Trim();
            if (DrawingTypeCode1 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DRAWING", DrawingTypeCode1);
                if (baseMaster != null)
                {
                    txtDrawingTypeCode1.Text = baseMaster.Code;
                    txtDrawingType1.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("图纸编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDrawingTypeCode1.Text = "";
                    txtDrawingType1.Text = "";
                    txtDrawingTypeCode1.Focus();
                }
            }
            else
            {
                txtDrawingType1.Text = "";
            }
        }

        private void txtDrawingTypeCode2_Leave(object sender, EventArgs e)
        {
            string DrawingTypeCode2 = txtDrawingTypeCode2.Text.Trim();
            if (DrawingTypeCode2 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DRAWING", DrawingTypeCode2);
                if (baseMaster != null)
                {
                    txtDrawingTypeCode2.Text = baseMaster.Code;
                    txtDrawingType2.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("图纸编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDrawingTypeCode2.Text = "";
                    txtDrawingType2.Text = "";
                    txtDrawingTypeCode2.Focus();
                }
            }
            else
            {
                txtDrawingType2.Text = "";
            }
        }

        private void txtDrawingTypeCode3_Leave(object sender, EventArgs e)
        {
            string DrawingTypeCode3 = txtDrawingTypeCode3.Text.Trim();
            if (DrawingTypeCode3 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DRAWING", DrawingTypeCode3);
                if (baseMaster != null)
                {
                    txtDrawingTypeCode3.Text = baseMaster.Code;
                    txtDrawingType3.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("图纸编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDrawingTypeCode3.Text = "";
                    txtDrawingType3.Text = "";
                    txtDrawingTypeCode3.Focus();
                }
            }
            else
            {
                txtDrawingType3.Text = "";
            }
        }

        private void txtDrawingTypeCode4_Leave(object sender, EventArgs e)
        {
            string DrawingTypeCode4 = txtDrawingTypeCode4.Text.Trim();
            if (DrawingTypeCode4 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DRAWING", DrawingTypeCode4);
                if (baseMaster != null)
                {
                    txtDrawingTypeCode4.Text = baseMaster.Code;
                    txtDrawingType4.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("图纸编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDrawingTypeCode4.Text = "";
                    txtDrawingType4.Text = "";
                    txtDrawingTypeCode4.Focus();
                }
            }
            else
            {
                txtDrawingType4.Text = "";
            }
        }

        private void txtDrawingTypeCode5_Leave(object sender, EventArgs e)
        {
            string DrawingTypeCode5 = txtDrawingTypeCode5.Text.Trim();
            if (DrawingTypeCode5 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DRAWING", DrawingTypeCode5);
                if (baseMaster != null)
                {
                    txtDrawingTypeCode5.Text = baseMaster.Code;
                    txtDrawingType5.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("图纸编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDrawingTypeCode5.Text = "";
                    txtDrawingType5.Text = "";
                    txtDrawingTypeCode5.Focus();
                }
            }
            else
            {
                txtDrawingType5.Text = "";
            }
        }

        private void txtDrawingTypeCode6_Leave(object sender, EventArgs e)
        {
            string DrawingTypeCode6 = txtDrawingTypeCode6.Text.Trim();
            if (DrawingTypeCode6 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("DRAWING", DrawingTypeCode6);
                if (baseMaster != null)
                {
                    txtDrawingTypeCode6.Text = baseMaster.Code;
                    txtDrawingType6.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("图纸编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDrawingTypeCode6.Text = "";
                    txtDrawingType6.Text = "";
                    txtDrawingTypeCode6.Focus();
                }
            }
            else
            {
                txtDrawingType6.Text = "";
            }
        }

        private void txtTechnologyCode1_Leave(object sender, EventArgs e)
        {
            string TechnologyCode1 = txtTechnologyCode1.Text.Trim();
            if (TechnologyCode1 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("TECHNOLOGY", TechnologyCode1);
                if (baseMaster != null)
                {
                    txtTechnologyCode1.Text = baseMaster.Code;
                    txtTechnology1.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("技术编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTechnologyCode1.Text = "";
                    txtTechnology1.Text = "";
                    txtTechnologyCode1.Focus();
                }
            }
            else
            {
                txtTechnology1.Text = "";
            }
        }

        private void txtTechnologyCode2_Leave(object sender, EventArgs e)
        {
            string TechnologyCode2 = txtTechnologyCode2.Text.Trim();
            if (TechnologyCode2 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("TECHNOLOGY", TechnologyCode2);
                if (baseMaster != null)
                {
                    txtTechnologyCode2.Text = baseMaster.Code;
                    txtTechnology2.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("技术编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTechnologyCode2.Text = "";
                    txtTechnology2.Text = "";
                    txtTechnologyCode2.Focus();
                }
            }
            else
            {
                txtTechnology2.Text = "";
            }
        }

        private void txtTechnologyCode3_Leave(object sender, EventArgs e)
        {
            string TechnologyCode3 = txtTechnologyCode3.Text.Trim();
            if (TechnologyCode3 != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("TECHNOLOGY", TechnologyCode3);
                if (baseMaster != null)
                {
                    txtTechnologyCode3.Text = baseMaster.Code;
                    txtTechnology3.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("技术编号不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTechnologyCode3.Text = "";
                    txtTechnology3.Text = "";
                    txtTechnologyCode3.Focus();
                }
            }
            else
            {
                txtTechnology3.Text = "";
            }
        }
    }
}
