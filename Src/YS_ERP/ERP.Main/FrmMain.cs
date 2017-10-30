using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Threading;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.CacheData;
using CZZD.ERP.Common;
using CZZD.ERP.Bll.Product;
using CZZD.ERP.Main.Properties;

namespace CZZD.ERP.Main
{
    public partial class FrmMain : Form, IMdiParent
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);

        private Hashtable forms = new Hashtable();
        private BaseUserTable _userInfo = new BaseUserTable();
        private Button currentButton = null;
        BCommon bCommon = new BCommon();
        FrmBase subForm = null;

        string notifyMessage = "";

        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(BaseUserTable userTable)
        {
            InitializeComponent();
            _userInfo = userTable;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    MdiClient ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }

            lblUserName.Text = _userInfo.NAME;
            lblDepartmentName.Text = _userInfo.DEPARTMENT_NAME;
            lblCompanyName.Text = _userInfo.COMPANY_NAME;

            try
            {
                CCacheData.SetRolesFunction(_userInfo.ROLES_CODE);
            }
            catch { }
            //我的桌面的重新整理            
            try
            {
                bCommon.ReSetMyDesk(_userInfo.COMPANY_CODE, _userInfo.CODE, _userInfo.ROLES_CODE);
            }
            catch (Exception ex)
            {
                Logger.Error("我的桌面的重新整理异常！", ex);
            }

            menuManage_Click(this.menuDesk, null);

            #region 通知

            BProductionPlanSearch bProductionPlanSearch = new BProductionPlanSearch();
            BProductionDrawing bProductionDrawing = new BProductionDrawing();
            try
            {
                int a = bProductionPlanSearch.GetProductionPlan(" DEPARTMENT_CODE = '" + _userInfo.DEPARTMENT_CODE + "'" + "  AND PSPP_STATUS_FLAG <> 2" + "  AND STATUS_FLAG <> 5").Tables[0].Rows.Count;
                int b = bProductionPlanSearch.GetProductionTechnology(" DEPARTMENT_CODE = '" + _userInfo.DEPARTMENT_CODE + "'" + "  AND PST_STATUS_FLAG <> 1" + "  AND STATUS_FLAG <> 5").Tables[0].Rows.Count;
                if (CConvert.ToInt32(a + b) > 0)
                {
                    menuProduceManage.Image = Resources.warning;
                    menuProduceManage.BackgroundImage = null;
                    menuProduceManage.Top = menuProduceManage.Top - 1;
                    menuProduceManage.Left = menuProduceManage.Left - 1;
                }
                else if (_userInfo.DEPARTMENT_CODE.Equals("D05"))
                {
                    int c = bProductionDrawing.GetProductionDrawing("PSDL_STATUS_FLAG <> 1" + " AND PS_STATUS_FLAG <> 5").Tables[0].Rows.Count;
                    if (c > 0)
                    {
                        menuProduceManage.Image = Resources.warning;
                        menuProduceManage.BackgroundImage = null;
                        menuProduceManage.Top = menuProduceManage.Top - 1;
                        menuProduceManage.Left = menuProduceManage.Left - 1;
                    }

                }
                else
                {
                    menuProduceManage.Image = null;
                    menuProduceManage.BackgroundImage = Resources.buttonup;
                }
            }
            catch (Exception ex) { }


            ////入库预定
            //int receivingCount = 0;
            //try
            //{
            //    receivingCount = (new BReceipt()).GetRecordCount(" STATUS_FLAG =" + CConstant.INIT + " and DUE_DATE<= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ");
            //}
            //catch { }
            //if (receivingCount > 0)
            //{
            //    notifyMessage += "您有未处理的入库预定！\r\n";
            //}

            ////安全库存
            //int stockCount = 0;
            //try
            //{
            //    stockCount = (new BStock()).GetStockNotifyRecordCount(" STATUS_FLAG <> " + CConstant.DELETE + "and QUANTITY < SAFETY_STOCK ");
            //}
            //catch { }

            //if (stockCount > 0)
            //{
            //    notifyMessage += "商品库存不足，请尽快采购！\r\n";
            //}

            ////通知提示
            //if (notifyMessage != "")
            //{
            //    Thread notifyThread = new Thread(new ThreadStart(ShowNotify));
            //    notifyThread.Start();
            //}
            #endregion

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);

        }

        #region 提示信息处理

        //delegate void NotifyDelegate(bool visible);//创建一个代理

        ///// <summary>
        ///// 
        ///// </summary>
        //private void SetNotify(bool visible)
        //{
        //    //if (!notify.InvokeRequired)
        //    if (!InvokeRequired)
        //    {
        //        notify.Visible = visible;
        //        this.notify.ShowBalloonTip(1000, "提示信息", notifyMessage, ToolTipIcon.Info);
        //    }
        //    else
        //    {
        //        NotifyDelegate notifyDelegate = new NotifyDelegate(SetNotify);
        //        Invoke(notifyDelegate, new object[] { visible });//执行唤醒操作
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //private void ShowNotify()
        //{
        //    SetNotify(true);
        //}


        ///// <summary>
        ///// 提示信息点击事件
        ///// </summary>
        //private void notify_BalloonTipClicked(object sender, EventArgs e)
        //{
        //    menuManage_Click(this.menuNotify, null);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //private void notify_BalloonTipClosed(object sender, EventArgs e)
        //{
        //    this.notify.Visible = false;
        //}

        #endregion

        #region  open window
        private void menuManage_Click(object sender, EventArgs e)
        {
            OpenWinForm("WinUI", "NavigationForm", ((Button)sender).Text, "");
            currentButton = ((Button)sender);
            Form[] frms = this.MdiChildren;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals("NavigationForm"))
                {
                    frm.Activate();
                    if (frm is IMyChildForm)
                        (frm as IMyChildForm).ChildShowForm(((Button)sender).Text, ((Button)sender).Name);
                }
            }
        }



        /// <summary>
        /// openWinForm
        /// </summary>
        private void OpenWinForm(string aNamespace, string aName, string aTitle, string tag)
        {
            try
            {
                string strFormName = "CZZD.ERP." + aNamespace + "." + aName;
                Assembly a = this.LoadAssembly(aNamespace);
                Type frmType = a.GetType(strFormName);
                if (frmType == null) return;
                foreach (Form frmChild in this.MdiChildren)
                {
                    if (frmChild.GetType() == frmType && (tag.Equals(frmChild.Tag) || frmChild.Tag == null))
                    {
                        frmChild.WindowState = FormWindowState.Maximized;
                        frmChild.Activate();
                        return;
                    }
                }
                object obj = Activator.CreateInstance(frmType, true);
                FrmBase frm = (FrmBase)obj;
                frm.CTag = tag;
                frm.MinimizeBox = false;
                frm.UserTable = this._userInfo;
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = aTitle;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error("打开新窗口异常！", ex);
            }
        }

        /// <summary>
        /// LoadAssembly
        /// </summary>
        private Assembly LoadAssembly(string assemblyName)
        {
            AppDomain ad = Thread.GetDomain();
            Assembly[] loadedAsms = ad.GetAssemblies();
            foreach (Assembly asm in loadedAsms)
            {
                if (asm.FullName == assemblyName)
                    return asm;
            }
            Assembly newAsm = ad.Load(assemblyName);
            AssemblyName[] refAsms = newAsm.GetReferencedAssemblies();
            bool isLoad = false;
            foreach (AssemblyName refAsm in refAsms)
            {
                foreach (Assembly asm in loadedAsms)
                {
                    if (asm.FullName == refAsm.FullName)
                        isLoad = true;
                    break;
                }
                if (!isLoad)
                {
                    ad.Load(refAsm);
                    isLoad = false;
                }
            }
            return newAsm;
        }
        #endregion

        #region mdiTabStrip1
        private void mdiTabStrip1_MdiTabRemoved(object sender, MdiTabStrip.MdiTabStripTabEventArgs e)
        {
            forms.Remove(e.MdiTab.Form.GetType().FullName);
        }


        #endregion

        public void Die()
        {
            this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed -= new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("确定要退出吗？ ", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
            //{
            //    e.Cancel = true;
            //}
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        #region IMdiParent 成员

        public void ParentShowForm(string aNamespace, string aName, string aTitle, string tag)
        {
            OpenWinForm(aNamespace, aName, aTitle, tag);
        }

        #endregion

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            Form[] frms = this.MdiChildren;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals("NavigationForm"))
                {
                    if (frm is IMyChildForm)
                        (frm as IMyChildForm).ChildShowForm(currentButton.Text, currentButton.Name);
                }
            }
        }

        #region 菜单按钮事件

        /// <summary>
        /// 重新登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuReLogin_Click(object sender, EventArgs e)
        {
            try
            {
                (new FrmLogin(this)).ShowDialog();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCloseCurrentWindow_Click(object sender, EventArgs e)
        {
            try
            {
                subForm = (FrmBase)this.ActiveMdiChild;
                subForm.Close();
            }
            catch (Exception ex)
            {
                Logger.Error("关闭当前窗口 ERROR。", ex);
            }
        }

        /// <summary>
        /// 关闭所有窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCloseAllWindow_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (FrmBase frmChild in this.MdiChildren)
                {
                    frmChild.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("关闭所有窗口 ERROR。", ex);
            }
        }

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPwd_Click(object sender, EventArgs e)
        {
            FrmBase frm = new FrmPwd();
            frm.UserTable = _userInfo;
            frm.ShowDialog(this);
            frm.Dispose();
        }

        /// <summary>
        /// 数据库配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDB_Click(object sender, EventArgs e)
        {
            FrmDBConfig frm = new FrmDBConfig();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        /// <summary>
        /// 操作手册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOperationManual_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 自动更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuUpdate_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frm = new FrmAbout();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        #endregion

        #region 菜单栏的显示与隐藏
        /// <summary>
        /// 菜单栏的显示与隐藏
        /// </summary>
        private void showMenuTop_Click(object sender, EventArgs e)
        {
            menuTop.Visible = !menuTop.Visible;
        }

        private void showMenuMain_Click(object sender, EventArgs e)
        {
            menuMain.Visible = !menuMain.Visible;
            //menuMain_fill.Visible = !menuMain_fill.Visible;
        }
        #endregion

        private void MenuExport_Click(object sender, EventArgs e)
        {
            //    FrmSetting frm = new FrmSetting();
            //    frm.ShowDialog(this);
            //    frm.Dispose();
            FrmBase frm = new FrmSetting();
            frm.UserTable = _userInfo;
            frm.ShowDialog(this);
            frm.Dispose();
        }



    }//end class

    /// <summary> 
    /// 主窗体接口 
    /// </summary> 
    public interface IMdiParent
    {
        void ParentShowForm(string aNamespace, string aName, string aTitle, string tag);
    }
    /// <summary> 
    /// 子窗体接口 
    /// </summary> 
    public interface IMyChildForm
    {
        void ChildShowForm(string caption, string name);
    }
}
