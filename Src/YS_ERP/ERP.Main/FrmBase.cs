using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;
using CZZD.ERP.Model;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;

namespace CZZD.ERP.Main
{
    public class FrmBase : Form
    {
        public string CTag = "";
        protected BCommon bCommon = new BCommon();
        protected BProduct bProduct = new BProduct();
        protected BProductGroup bProductGroup = new BProductGroup();
        protected BOrderHeader bOrderHeader = new BOrderHeader();
        protected BQuotation bQuotation = new BQuotation();
        protected BPurchaseOrder bPurchaseOrder = new BPurchaseOrder();
        protected BStock bStock = new BStock();
        protected BAlloation bAlloation = new BAlloation();
        protected BShipment bShipment = new BShipment();
        protected BReceipt bRerceipt = new BReceipt();
        protected BTransfer bTransfer = new BTransfer();
        protected BInventory bInventory = new BInventory();
        protected BProductBuild bProductBuild = new BProductBuild();
        protected BSupplier bSupplier = new BSupplier();
        protected Color COLOR_NG = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
        protected Color COLOR_INFO = System.Drawing.SystemColors.Info;
        protected Color COLOR_DIFF_ROW = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));

        protected BaseUserTable _userInfo;

        /// <summary>
        /// 登录用户信息
        /// </summary>
        public BaseUserTable UserTable
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        #region 分页用
        //每页显示记录数
        protected int PageSize = 20;

        protected int MasterMinPageSize = 12;

        /// <summary>
        /// 取得总页数
        /// </summary>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        protected int GetTotalPage(int recordCount)
        {
            int totalPage = 0;
            totalPage = recordCount / PageSize;
            if (recordCount % PageSize >= 1)
            {
                totalPage++;
            }
            return totalPage;
        }

        /// <summary>
        /// 取得总页数
        /// </summary>
        protected int GetTotalPage(int recordCount, int pageSize)
        {
            int totalPage = 0;
            totalPage = recordCount / pageSize;
            if (recordCount % pageSize >= 1)
            {
                totalPage++;
            }
            return totalPage;
        }

        /// <summary>
        /// 获得当前DataTable 的有效行数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        protected int GetDataTabelRowsCount(DataTable dt)
        {
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row[0] != null && !"".Equals(row[0].ToString()))
                {
                    i++;
                }
            }
            return i;
        }
        #endregion

        #region 图像处理
        /// <summary>
        /// 将Image图像类型转换成byte[]
        /// </summary>
        public byte[] GetImageToByte(string fileName)
        {
            byte[] bt = null;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                FileInfo fileInfo = new FileInfo(fileName);
                int streamLength = (int)fs.Length;
                bt = new byte[streamLength];
                fs.Read(bt, 0, streamLength);
                fs.Close();
            }
            catch { }
            return bt;
        }



        /// <summary>
        /// 将byte[]转换成Image图像类型
        /// </summary>
        public Image GetByteToImage(byte[] mybyte)
        {
            Image image = null;
            try
            {
                MemoryStream mymemorystream = new MemoryStream(mybyte, 0, mybyte.Length);
                image = Image.FromStream(mymemorystream);
            }
            catch (Exception ex) { }
            return image;
        }
        #endregion

        #region 重绘datagridview表头
        /// <summary>
        /// 重绘datagridview表头
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="nextColumnIndex"></param>
        /// <param name="titleText"></param>
        /// <param name="e"></param>
        protected void CellPainting(DataGridView dgv, int nextColumnIndex, string titleText, DataGridViewCellPaintingEventArgs e)
        {
            int top = e.CellBounds.Top;
            int left = e.CellBounds.Left;
            int height = e.CellBounds.Height;
            int width1 = e.CellBounds.Width;
            int width2 = dgv.Columns[nextColumnIndex].Width;
            Rectangle rect = new Rectangle(left, top, width1 + width2, e.CellBounds.Height);
            using (Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            {
                //抹去原来的cell背景
                e.Graphics.FillRectangle(backColorBrush, rect);
            }
            using (Pen pen = new Pen(Color.White))
            {
                e.Graphics.DrawLine(pen, left + 1, top + 1, left + width1 + width2 - 1, top + 1);
            }
            using (Pen gridLinePen = new Pen(dgv.GridColor))
            {
                e.Graphics.DrawLine(gridLinePen, left, top, left + width1 + width2, top);
                e.Graphics.DrawLine(gridLinePen, left, top + height - 1, left + width1 + width2, top + height - 1);

                //计算绘制字符串的位置
                string columnValue = titleText;
                SizeF sf = e.Graphics.MeasureString(columnValue, e.CellStyle.Font);
                float lstr = (width1 + width2 - sf.Width) / 2;
                float rstr = (height - sf.Height) / 2;
                //画出文本框
                if (columnValue != "")
                {
                    e.Graphics.DrawString(columnValue, e.CellStyle.Font,
                    new SolidBrush(e.CellStyle.ForeColor),
                    left + 5,
                    top + rstr,
                    StringFormat.GenericDefault);
                }

            }
        }
        #endregion

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBase));
            this.SuspendLayout();
            // 
            // FrmBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBase";
            this.Text = "FrmBase";
            this.ResumeLayout(false);

        }

        protected bool CheckRoles(DataTable rolesDt, string _namespace, string _frmName, string _title, string _tag)
        {
            bool roles = false;
            foreach (DataRow dr in rolesDt.Rows)
            {
                if (_frmName.Equals(dr["CLASS_NAME"]) && _tag.Equals(CConvert.ToString(dr["TAG"])))
                {
                    roles = true;
                    break;
                }
            }
            return roles;
        }

        #region  输入控制
        /// <summary>
        /// //限制数量只能输入整数
        /// </summary>
        protected void InputInteger(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            else　 //以下为输入正确内容过虑
            {
                //如果第一位输入0，则不接收
                if (e.KeyChar == 48 && (((TextBox)sender).SelectionStart == 0))
                    e.Handled = true;
                //如果是回车键，则按tab序进行跳转
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
            }
        }

        /// <summary>
        /// //限制数量只能输入整字，可以为负数
        /// </summary>
        protected void InputnegativeInteger(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26 && e.KeyChar != 8 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
            else　 //以下为输入正确内容过虑
            {
                //如果第一位输入0，则不接收
                if (e.KeyChar == 48 && (((TextBox)sender).SelectionStart == 0))
                    e.Handled = true;
                //如果是回车键，则按tab序进行跳转
                if (e.KeyChar == 13)
                {
                    SendKeys.Send("{TAB}");
                    e.Handled = true;
                }
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
            }
        }

        /// <summary>
        /// //限制数量只能输入数字，带小数
        /// </summary>
        protected void InputDouble(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if (((TextBox)sender).SelectionStart == 0)
                {
                    e.Handled = true;
                }
                else if (((TextBox)sender).Text.IndexOf('.') >= 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            else　 //以下为输入正确内容过虑
            {

                ////如果第一位输入0，则不接收
                //if (e.KeyChar == 48 && (((TextBox)sender).SelectionStart == 0))
                //    e.Handled = true;
                //如果是回车键，则按tab序进行跳转
                //if (e.KeyChar == 13)
                //{
                //    SendKeys.Send("{TAB}");
                //    e.Handled = true;
                //}
            }
        }


        /// <summary>
        /// //限制数量只能输入数字，带小数，金额类型，只能有两位小数
        /// </summary>
        protected void InputAmount(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                if (((TextBox)sender).SelectionStart == 0)
                {
                    e.Handled = true;
                }
                else if (((TextBox)sender).Text.IndexOf('.') >= 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < 48 || e.KeyChar > 57 || e.KeyChar == 46) && e.KeyChar != 13 && e.KeyChar != 22 && e.KeyChar != 3 && e.KeyChar != 24 && e.KeyChar != 26 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            else　 //以下为输入正确内容过虑
            {
                string[] str = ((TextBox)sender).Text.Split('.');
                if (str.Length > 1)
                {
                    if (str[1].Length >= 2 && ((TextBox)sender).SelectionStart > ((TextBox)sender).Text.IndexOf('.'))
                    {
                        e.Handled = true;
                    }
                }

                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
            }
        }
        #endregion

        #region 获得未含税金额
        protected decimal WithoutAmount(decimal INCLUED_TAX_AMOUNT, decimal TAX_RATE)
        {
            return INCLUED_TAX_AMOUNT / (1 + TAX_RATE);
        }
        #endregion

        #region 额户预收款金额的取得
        /// <summary>
        /// 预收款金额
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        protected decimal GetCustomerDepositBlanace(string customerCode)
        {
            decimal blanace = 0;
            if (!"".Equals(customerCode))
            {
                try
                {
                    BDeposit bDeposit = new BDeposit();
                    blanace =CConvert.ToDecimal(bDeposit.GetTotalDeposit(customerCode).Tables[0].Rows[0]["BALANCE"]);
                }
                catch { }
            }
            return blanace;
        }
        #endregion

        #region 供应商预付款金额的取得
        /// <summary>
        /// 预付款金额
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        protected decimal GetSupplierDepositBlanace(string supplierCode)
        {
            decimal blanace = 0;
            if (!"".Equals(supplierCode))
            {
                try
                {
                    BSupplierDeposit bSupplierDeposit = new BSupplierDeposit();
                    blanace = CConvert.ToDecimal(bSupplierDeposit.GetTotalDeposit(supplierCode).Tables[0].Rows[0]["BALANCE"]);
                }
                catch { }
            }
            return blanace;
        }
        #endregion


        protected void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                System.Windows.Forms.SendKeys.Send("{Tab}");
                //ProcessTabKey(true);
            }
        }

        protected BaseSupplierTable GetSupplierCurrence(string CODE)
        {
            BaseSupplierTable supplierTable = new BaseSupplierTable();
            supplierTable = bSupplier.GetModel(CODE);
            return supplierTable;
        }

        #region  btnSave Mouse event
        protected void SetBackgroundImage(object sender, Image img)
        {
            ((Button)sender).BackgroundImage = img;
        }
        #endregion
        

    }//end class
}
