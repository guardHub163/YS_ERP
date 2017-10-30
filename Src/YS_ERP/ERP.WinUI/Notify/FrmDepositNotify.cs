using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;

namespace CZZD.ERP.WinUI
{
    public partial class FrmDepositNotify : FrmBase
    {
        public FrmDepositNotify()
        {
            InitializeComponent();
        }

        private void FrmDepositNotify_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;

            #region dgvData初始化
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            PageSize = 14;
            #endregion

           // btnSearch_Click(null, null);
        }

    }//end class
}
