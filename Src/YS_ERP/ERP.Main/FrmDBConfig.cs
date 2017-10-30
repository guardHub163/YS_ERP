using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.Main
{
    public partial class FrmDBConfig : Form
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        public FrmDBConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面初始化，原有数据库配置信息读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDBConfig_Load(object sender, EventArgs e)
        {
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
        /// 数据库连接测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 数据库连接保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                DialogResult dr = MessageBox.Show("配置信息保存成功。", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, false);
                Logger.Error("数据库连接保存、重启！", ex);
            }
        }

        /// <summary>
        /// 页面关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{tab}");
            }
        }

        
    }//end class
}
