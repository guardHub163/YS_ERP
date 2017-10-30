using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main.Properties;
using CZZD.ERP.Common;
using CZZD.ERP.Bll;
using System.Threading;
using System.Diagnostics;
using CZZD.ERP.Model;
using System.Runtime.InteropServices;

namespace CZZD.ERP.Main
{
    public partial class FrmLogin : Form
    {
        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("User32.DLL")]
        public static extern bool ReleaseCapture();
        public const uint WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 61456;
        public const int HTCAPTION = 2;

        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        private FrmMain _mainWin;
        public FrmLogin()
            : this(null)
        { }
        public FrmLogin(FrmMain caller)
        {
            _mainWin = caller;
            InitializeComponent();
        }

        /// <summary>
        ///  init 页面初始化
        /// </summary>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //this.TransparencyKey = Color.WhiteSmoke;
            //panelDBConfig.BackColor = Color.FromArgb(65, 204, 212, 230);

            try
            {
                string strconn = string.Empty;
                strconn = AppXmlTool.ReadXmlFiles("ConnectionString");
                string ConStringEncrypt = AppXmlTool.ReadXmlFiles("ConStringEncrypt");
                if (ConStringEncrypt == "true")
                {
                    strconn = DESEncrypt.Decrypt(strconn);
                }
                string[] ary = strconn.Split(';');
                if (ary.Length > 3)
                {
                    this.cmbSqlServers.Text = ary[0].Substring(ary[0].IndexOf("=") + 1).Trim();
                    this.txtUserName.Text = ary[1].Substring(ary[1].IndexOf("=") + 1).Trim();
                    this.txtPassword.Text = ary[2].Substring(ary[2].IndexOf("=") + 1).Trim();
                    this.cmbAllDataBases.Text = ary[3].Substring(ary[3].IndexOf("=") + 1).Trim();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("数据库配置文件文读取异常！", ex);
            }

            try
            {
                string strconn = "Data Source={0};User ID={1};Password={2};Initial Catalog={3};Pooling=true";
                strconn = string.Format(strconn, this.cmbSqlServers.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.cmbAllDataBases.Text.Trim());
                string strsql = string.Empty;
                strsql = "select 1";
                BCommon bcomm = new BCommon();
                if (bcomm.IsDBConn(strconn, strsql))
                {
                    DataTable dt = bcomm.GetMasterList("COMPANY", "", "", " STATUS_FLAG =" + CConstant.NORMAL).Tables[0];
                    cboCompany.DisplayMember = "NAME_SHORT";
                    cboCompany.ValueMember = "CODE";
                    cboCompany.DataSource = dt;
                    txtLoginUserCode.Focus();
                }
                else
                {
                    MessageBox.Show("数据库连接失败!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelDBConfig.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Error("数据库连接失败！", ex);
            }

        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((null == _mainWin) || (!_mainWin.IsHandleCreated))
                Application.Exit();
        }

        /// <summary>
        /// 取消
        /// </summary>
        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 登录
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.panelDBConfig.Visible)
            {
                MessageBox.Show("请先保存数据库连接设定", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            login();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        private void login()
        {
            this.Cursor = Cursors.WaitCursor;
            string strErrorlog = string.Empty;
            string _errorLog = string.Empty;
            try
            {
                BUser buser = new BUser();
                BaseUserTable tuser = new BaseUserTable();
                if (string.IsNullOrEmpty(this.txtLoginUserCode.Text.Trim()))
                {
                    strErrorlog = "登录名不能为空!";
                    this.txtLoginUserCode.Focus();
                    this.txtLoginUserCode.Select();
                    MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Cursor = Cursors.Default;
                    return;
                }
                tuser = buser.GetModel(CConvert.ToString(cboCompany.SelectedValue) + this.txtLoginUserCode.Text.Trim(), CConvert.ToString(cboCompany.SelectedValue));
                //用户名验证
                if (null == tuser)
                {
                    strErrorlog = "登录名不存在或密码错误！";
                    _errorLog = "登录名不存在!";
                    this.txtLoginUserCode.Focus();
                }
                //公司验证
                else if (tuser.COMPANY_CODE != CConvert.ToString(cboCompany.SelectedValue))
                {
                    strErrorlog = "登录名不存在或密码错误！";
                    _errorLog = "公司与登录名不符合!";
                    this.txtLoginUserCode.Focus();
                }
                else
                {
                    //密码验证
                    if (DESEncrypt.Encrypt(this.txtLoginPassword.Text.Trim()) != tuser.PASSWORD)
                    {
                        strErrorlog = "登录名不存在或密码错误！";
                        _errorLog = "密码错误!";
                        this.txtLoginPassword.Focus();
                    }
                }
                if (!string.IsNullOrEmpty(strErrorlog))
                {
                    MessageBox.Show(strErrorlog, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    strErrorlog += "  " + this.txtLoginUserCode.Text.Trim();
                }
                else
                {
                    if (null != _mainWin)
                    {
                        _mainWin.Die();
                        if (_mainWin.IsHandleCreated)
                        {
                            this.Hide();
                            return;
                        }
                    }

                    FrmMain mainForm = new FrmMain(tuser);
                    this.Hide();
                    mainForm.Show();
                    _mainWin = mainForm;
                    _errorLog = "登录成功！";
                }
                //new BBaseLogs().Info(UserConstants.LOG_MODE_LOGIN, strErrorlog, tuser.USERID);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); //
                Logger.Error("数据库连接失败！", err);
                this.Cursor = Cursors.Default;
                ShowDBConfig();

            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 数据连接设定
        /// </summary>
        private void ShowDBConfig()
        {
            DialogResult dr = MessageBox.Show("配置信息错误,是否重新配置!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                RunDBConfig();
            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// RunDBConfig
        /// </summary>
        private void RunDBConfig()
        {
            lkSetDB_LinkClicked(null, null);
        }


        #region 按钮图片替换
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackgroundImage = Resources.login;
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackgroundImage = Resources.login_over;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.cancel;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = Resources.cancel_over;
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.BackgroundImage = Resources.min_over;
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.BackgroundImage = Resources.min;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Resources.close_over;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = Resources.close;
        }
        #endregion

        /// <summary>
        /// lkSetDB_LinkClicked
        /// </summary>
        private void lkSetDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.panelDBConfig.Visible)
            {
                return;
            }
            panelDBConfig.Visible = true;
            try
            {
                string strconn = string.Empty;
                strconn = AppXmlTool.ReadXmlFiles("ConnectionString");
                string ConStringEncrypt = AppXmlTool.ReadXmlFiles("ConStringEncrypt");
                if (ConStringEncrypt == "true")
                {
                    strconn = DESEncrypt.Decrypt(strconn);
                }
                string[] ary = strconn.Split(';');
                if (ary.Length > 3)
                {
                    this.cmbSqlServers.Text = ary[0].Substring(ary[0].IndexOf("=") + 1).Trim();
                    this.txtUserName.Text = ary[1].Substring(ary[1].IndexOf("=") + 1).Trim();
                    this.txtPassword.Text = ary[2].Substring(ary[2].IndexOf("=") + 1).Trim();
                    this.cmbAllDataBases.Text = ary[3].Substring(ary[3].IndexOf("=") + 1).Trim();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("数据库配置文件文读取异常！", ex);
            }
        }

        /// <summary>
        /// 连接测试
        /// </summary>
        private void btnTestConn_Click(object sender, EventArgs e)
        {
            if (this.cmbSqlServers.Text == "" || this.cmbAllDataBases.Text == "" || this.txtUserName.Text == "" || this.txtPassword.Text == "")
            {
                MessageBox.Show("数据库名称及用户密码不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string strconn = "Data Source={0};User ID={1};Password={2};Initial Catalog={3};Pooling=true";
                strconn = string.Format(strconn, this.cmbSqlServers.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.cmbAllDataBases.Text.Trim());
                string strsql = string.Empty;
                strsql = "select 1";
                BCommon bcomm = new BCommon();
                if (bcomm.IsDBConn(strconn, strsql))
                    MessageBox.Show("连接成功!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("连接失败!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Error("数据库连接失败！", ex);
            }
        }

        /// <summary>
        /// 连接保存
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cmbSqlServers.Text == "" || this.cmbAllDataBases.Text == "" || this.txtUserName.Text == "" || this.txtPassword.Text == "")
            {
                MessageBox.Show("数据库名称及用户密码不能为空!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string strconn = "Data Source={0};User ID={1};Password={2};Initial Catalog={3};Pooling=true";
                strconn = string.Format(strconn, this.cmbSqlServers.Text.Trim(), this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.cmbAllDataBases.Text.Trim());

                string ConStringEncrypt = AppXmlTool.ReadXmlFiles("ConStringEncrypt");
                if (ConStringEncrypt == "true")
                {
                    strconn = DESEncrypt.Encrypt(strconn);
                }
                AppXmlTool.XmlNodeWrite("Config.xml", "ConfigSetting//AppConfig//ConnectionString", strconn);
                DialogResult dr = MessageBox.Show("配置信息保存成功,请重新启动应用程序", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    Application.ExitThread();
                    Restart();
                }
                else
                {
                    this.panelDBConfig.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, false);
                Logger.Error("数据库连接保存、重启！", ex);
            }
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        private void btnDBClose_Click(object sender, EventArgs e)
        {
            this.panelDBConfig.Visible = false;
        }

        /// <summary>
        /// 系统重新启动
        /// </summary>
        private void Restart()
        {
            Thread thtmp = new Thread(new ParameterizedThreadStart(run));
            object appName = Application.ExecutablePath;
            Thread.Sleep(2000);
            thtmp.Start("yserp.exe");
        }

        /// <summary>
        /// run
        /// </summary>
        private void run(Object obj)
        {
            Process ps = new Process();
            ps.StartInfo.FileName = obj.ToString();
            ps.Start();
        }

        /// <summary>
        /// txtLoginUserCode_KeyDown
        /// </summary>
        private void txtLoginUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtLoginPassword.Focus();
                this.txtLoginPassword.SelectAll();
            }
        }

        /// <summary>
        /// txtLoginPassword_KeyDown
        /// </summary>
        private void txtLoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE | HTCAPTION, 0);
        }

    }//end class
}
