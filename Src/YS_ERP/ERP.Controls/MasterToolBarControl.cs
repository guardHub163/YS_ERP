using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CZZD.ERP.ComControls
{
    public partial class MasterToolBarControl : UserControl
    {
        public MasterToolBarControl()
        {
            InitializeComponent();
        }

        //新建
        private  const int MODE_NEW = 1;

        //复制
        private const int MODE_COPY = 2;

        //编辑
        private const int MODE_MODIFY = 3;

        //删除
        private const int MODE_DELETE = 4;       

        //查询
        private const int MODE_SEARCH = 5;

        //导出
        private const int MODE_EXPORT = 6;


        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e);

        #region 定义事件
        public event BtnClickHandle DoNew_Click;
        private void menuNew_Click(object sender, EventArgs e)
        {
            if (DoNew_Click != null)
            {
                DoNew_Click(sender, e);
            }
        }

        public event BtnClickHandle DoModify_Click;
        private void menuModify_Click(object sender, EventArgs e)
        {
            if (DoModify_Click != null)
            {
                DoModify_Click(sender, e);
            }
        }

        public event BtnClickHandle DoDelete_Click;
        private void menuDelete_Click(object sender, EventArgs e)
        {
            if (DoDelete_Click != null)
            {
                DoDelete_Click(sender, e);
            }
        }

        public event BtnClickHandle DoCopy_Click;
        private void menuCopy_Click(object sender, EventArgs e)
        {
            if (DoCopy_Click != null)
            {
                DoCopy_Click(sender, e);
            }
        }

        public event BtnClickHandle DoExport_Click;
        private void menuExport_Click(object sender, EventArgs e)
        {
            if (DoExport_Click != null)
            {
                DoExport_Click(sender, e);
            }
        }

        public event BtnClickHandle DoCancel_Click;
        private void menuCancel_Click(object sender, EventArgs e)
        {
            if (DoCancel_Click != null)
            {
                DoCancel_Click(sender, e);
            }
        }

        public event BtnClickHandle DoSearch_Click;
        /// <summary>
        /// 查询
        /// </summary>
        private void menuSearch_Click(object sender, EventArgs e)
        {
            if (DoSearch_Click != null)
            {
                DoSearch_Click(sender, e);
            }
        }
        #endregion       

        /// <summary>
        /// 单个工具条设置
        /// </summary>
        /// <param name="currentMode"></param>
        /// <param name="status"></param>
        public void SetMasterToolsBar(int currentMode, bool status)
        {
            switch (currentMode)
            {
                case MODE_NEW:
                    menuNew.Enabled = status;
                    break;
                case MODE_COPY:
                    menuCopy.Enabled = status;
                    break;
                case MODE_MODIFY:
                    menuModify.Enabled = status;
                    break;
                case MODE_DELETE:
                    menuDelete.Enabled = status;
                    break;                
                case MODE_SEARCH:
                    menuSearch.Enabled = status;
                    break;
                case MODE_EXPORT:
                    menuExport.Enabled = status;
                    break;
            }//end switch
        }

        /// <summary>
        /// 工具条设置
        /// </summary>
        public void SetMasterToolsBar(int dataCount)
        {
            bool status = false;
            if (dataCount > 0) 
            {
                status = true;
            }
            menuCopy.Enabled = status;
            menuModify.Enabled = status;
            menuDelete.Enabled = status;
            menuExport.Enabled = status;
           
        }


        #region delete
        /// <summary>
        /// 整体工具条设置
        /// </summary>
        /// <param name="currentTab"></param>
        /// <param name="currentMode"></param>
        /// <param name="dataCount"></param>
        //public void SetMasterToolsBar(int currentTab, int currentMode, int dataCount)
        //{
        //    if (currentTab == TAB_INFO)
        //    {             
        //        menuDelete.Enabled = false; 
        //        menuModify.Enabled = false;
        //        menuCancel.Enabled = false;
        //        menuCopy.Enabled = false;

        //        menuExport.Enabled = true;
        //        menuNew.Enabled = true;
        //        menuSearch.Enabled = true;
        //    }
        //    else if (currentTab == TAB_EDIT)
        //    {
        //        switch (currentMode)
        //        {
        //            case MODE_NEW:
        //                menuModify.Enabled = false;
        //                menuDelete.Enabled = false;
        //                menuSearch.Enabled = false;
        //                menuExport.Enabled = false;

        //                menuNew.Enabled = true;
        //                menuCancel.Enabled = true;
        //                menuCopy.Enabled = true;
        //                break;
        //            case MODE_MODIFY:
        //                menuNew.Enabled = false;
        //                menuDelete.Enabled = false;
        //                menuSearch.Enabled = false;
        //                menuExport.Enabled = false;

        //                menuModify.Enabled = true;
        //                menuCancel.Enabled = true;
        //                menuCopy.Enabled = true;
        //                break;
        //            case MODE_DELETE:
        //                if (dataCount >= 1)
        //                {
        //                    menuModify.Enabled = true;
        //                    menuDelete.Enabled = true;
        //                }
        //                else
        //                {
        //                    menuModify.Enabled = false;
        //                    menuDelete.Enabled = false;
        //                }
        //                break;
        //            case MODE_SAVE:
        //                menuCancel.Enabled = false;
        //                menuDelete.Enabled = false;
        //                menuSearch.Enabled = false;
        //                menuExport.Enabled = false;

        //                menuNew.Enabled = true;
        //                menuModify.Enabled = true;                        
        //                menuCopy.Enabled = true;
        //                break;
        //            case MODE_CANCEL:
        //                menuCancel.Enabled = false;
        //                menuCopy.Enabled = false;                        
        //                menuSearch.Enabled = false;
        //                menuExport.Enabled = false;
        //                if (dataCount >= 1)
        //                {
        //                    menuModify.Enabled = true;
        //                    menuDelete.Enabled = true;
        //                }
        //                else 
        //                {
        //                    menuModify.Enabled = false;
        //                    menuDelete.Enabled = false;
        //                }
        //                menuNew.Enabled = true;

        //                break;
        //            default:
        //                if (dataCount >= 1)
        //                {
        //                    menuModify.Enabled = true;
        //                    menuDelete.Enabled = true;
        //                }
        //                else
        //                {
        //                    menuModify.Enabled = false;
        //                    menuDelete.Enabled = false;
        //                }
        //                menuNew.Enabled = true;
        //                menuCancel.Enabled = false;
        //                menuCopy.Enabled = false;
        //                menuSearch.Enabled = false;
        //                menuExport.Enabled = false;
        //                break;
        //        }//end switch
        //    }
        //}
        #endregion
        
    }//end class
}
