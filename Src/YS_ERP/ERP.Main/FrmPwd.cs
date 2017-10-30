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
    public partial class FrmPwd : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        public FrmPwd()
        {
            InitializeComponent();
        }
       
        /// <summary>
        /// 密码修正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string strcheck = string.Empty;
            int i = 0;
            if (this.txtPwdOld.Text.Trim() != DESEncrypt.Decrypt(UserTable.PASSWORD))
            {
                strcheck = "旧密码错误！";
            }
            else if (this.txtPwdNew1.Text.Trim() != this.txtPwdNew2.Text.Trim())
            {
                strcheck = "两次密码确认不一致！";
            }
            else if (this.txtPwdOld.Text.Trim() == this.txtPwdNew1.Text.Trim())
            {
                strcheck = "旧密码和新密码不能相同！";
            }
            if (string.IsNullOrEmpty(strcheck))
            {
                i = bCommon.Update_Table_Fileds("BASE_USER", "PASSWORD='" + DESEncrypt.Encrypt(this.txtPwdNew1.Text.Trim()) + "',LAST_UPDATE_TIME=GETDATE()", " CODE='" + UserTable.CODE + "' AND COMPANY_CODE ='" + UserTable.COMPANY_CODE + "'");
                this.Close();
            }
            else
            {
                MessageBox.Show(strcheck, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 页面关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 回车键控制
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
