using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CZZD.ERP.ComControls
{
    public partial class PageControlMin : UserControl
    {
        private int _currentPage = 1;
        private int _totalPage = 1;

        public PageControlMin()
        {
            InitializeComponent();
        }

        public int TotalPage
        {
            get { return _totalPage; }
            set { _totalPage = value;}
        }

        private void PageControl_Load(object sender, EventArgs e)
        {
            init(1,1);
        }


        /// <summary>
        /// 页面初始化
        /// </summary>
        public void init(int totalPage,int currentPage) 
        {
            _totalPage = totalPage;
            if (_totalPage <= 0) 
            {
                _totalPage = 1;
            }
            _currentPage = currentPage;
            lblTotalPage.Text = _totalPage.ToString();
            ChangePage(_currentPage);
        }

        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e, int currentPage);
        public event BtnClickHandle PageChanged;
        /// <summary>
        /// 事件注册
        /// </summary>
        private void OnPageChanged(object sender, EventArgs e, int _currentPage)
        {
            if (PageChanged != null)
            {
                PageChanged(sender, e, _currentPage);
            }
        }

        /// <summary>
        /// 页面点击事件,更改当前页
        /// </summary>
        private void Menu_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            switch (btn.Name)
            {
                case "menuFirst":
                    _currentPage = 1;
                    break;
                case "menuPrev":
                    _currentPage--;
                    break;
                case "menuNext":
                    _currentPage++;
                    break;
                case "menuLast":
                    _currentPage = Convert.ToInt32(lblTotalPage.Text);
                    break;
                case "menuGoto":
                    int iGoto = 1;
                    if (int.TryParse(this.txtCurrentPage.Text, out iGoto))
                    {
                        if (iGoto <= 1)
                        {
                            iGoto = 1;
                        }
                        if (iGoto > _totalPage)
                        {
                            iGoto = _totalPage;
                        }
                        _currentPage = iGoto;
                    }
                    break;
                default:
                    break;
            }
            ChangePage(_currentPage);
            OnPageChanged(sender, e, _currentPage);

        }

        /// <summary>
        /// 页面标签按钮控制
        /// </summary>
        private void ChangePage(int _currentPage)
        {
           if (_currentPage <= 1)
            {
                this.menuFirst.Enabled = false;
                this.menuPrev.Enabled = false;
                this.menuNext.Enabled = true;
                this.menuLast.Enabled = true;
                this.menuGoto.Enabled = true;
                _currentPage = 1;
            }
            else if (_currentPage >= _totalPage)
            {
                this.menuFirst.Enabled = true;
                this.menuPrev.Enabled = true;
                this.menuNext.Enabled = false;
                this.menuLast.Enabled = false;
                this.menuGoto.Enabled = true;
                _currentPage = _totalPage;
            }
            else
            {
                this.menuFirst.Enabled = true;
                this.menuPrev.Enabled = true;
                this.menuNext.Enabled = true;
                this.menuLast.Enabled = true;
                this.menuGoto.Enabled = true;
            }

            if (_totalPage <= 1)
            {
                this.menuFirst.Enabled = false;
                this.menuPrev.Enabled = false;
                this.menuNext.Enabled = false;
                this.menuLast.Enabled = false;
                this.menuGoto.Enabled = false;
            }

            this.lblCurrentPage.Text = _currentPage.ToString();
            this.txtCurrentPage.Text = _currentPage.ToString();
        }


        /// <summary>
        /// 返回当前页
        /// </summary>
        public int GetCurrentPage() 
        {
            return _currentPage;
        }


    }//end class
}
