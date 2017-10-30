using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.WinUI.Properties;
using CZZD.ERP.Main;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using System.IO;
using System.Drawing.Imaging;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class NavigationForm : FrmBase, CZZD.ERP.Main.IMyChildForm
    {
        private float X = 1028;
        private float Y = 663;
        float newx = 1;
        float newy = 1;
        int maxSize = 20;
        public NavigationForm()
        {
            InitializeComponent();
        }
        //存放当前选中的控件
        private PictureBox _pic = null;

        private void NavigationForm_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
        }

        #region IMyChildForm 成员

        public void ChildShowForm(string caption, string name)
        {
            newx = (this.pMain.Width) / X; //窗体宽度缩放比例
            newy = this.pMain.Height / Y;//窗体高度缩放比例
            this.Text = caption;
            this.pMain.Controls.Clear();
            this.pMain.Tag = name;
            switch (name)
            {
                case "menuMasterManage":      //基本数据管理
                    newMinFrmPictureBox(this.pMain, 50, 25, "SlipType", "模具种类设定", Resources.sliptype, Resources.sliptype_enabled, "");
                    newMinFrmPictureBox(this.pMain, 250, 25, "SlipTypeCompositionProducts", "模具种类构成", Resources.product_parts, Resources.product_parts_enabled, "");
                    newMinFrmPictureBox(this.pMain, 450, 25, "CompositionProducts", "部件设定", Resources.CompositionProducts, Resources.CompositionProducts_enabled, "");
                    newMinFrmPictureBox(this.pMain, 650, 25, "CompositionProductsProductionProcess", "部件工序设定", Resources.product_parts, Resources.product_parts_enabled, "");
                    newMinFrmPictureBox(this.pMain, 850, 25, "ProductionProcess", "工序设定", Resources.Specification, Resources.Specification_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 185, "ProductTree", "模具构成图", Resources.product_parts, Resources.product_parts_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 185, "Material", "材质设定", Resources.product, Resources.product_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 185, "Technology", "技术设定", Resources.product_unit, Resources.product_unit_enabled, "");

                    newFrmPictureBox(this.pMain, 50, 345, "Customer", "客户设定", Resources.customer, Resources.customer_enabled, "");
                    //newFrmPictureBox(this.pMain, 250, 345, "TaxAtion", "税率设定", Resources.taxation, Resources.taxation_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 345, "Currency", "货币设定", Resources.currency, Resources.currency_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 345, "Bank", "银行设定", Resources.receiptMatch, Resources.receiptMatch_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 185, "Drawing", "图纸设定", Resources.unit, Resources.unit_enabled, "");
                    break;
                case "menuProduct":
                    break;
                case "menuUserRoles":         //用户权限
                    newFrmPictureBox(this.pMain, 100, 50, "Company", "公司管理", Resources.company, Resources.company_enabled, "");
                    newFrmPictureBox(this.pMain, 400, 50, "Department", "部门管理", Resources.department, Resources.department_enabled, "");
                    newFrmPictureBox(this.pMain, 700, 50, "User", "用户管理", Resources.user, Resources.user_enabled, "");

                    newFrmPictureBox(this.pMain, 100, 250, "Roles", "角色管理", Resources.roles, Resources.roles_enabled, "");
                    newFrmPictureBox(this.pMain, 400, 250, "RolesFunction", "权限设定", Resources.userRoles, Resources.userRoles_enabled, "");
                    break;
                case "menuQuotationManage":
                    newFrmPictureBox(this.pMain, 100, 50, "Quotation", "报价单输入", Resources.Quotation, Resources.Quotation_enabled, "");
                    newFrmPictureBox(this.pMain, 400, 50, "QuotationSearch", "报价单查询", Resources.QuotationSearch, Resources.QuotationSearch_enabled, "");
                    break;

                case "menuSalesManage":
                    newFrmPictureBox(this.pMain, 100, 50, "OrdersEntry", "订单输入", Resources.orderEntry, Resources.orderEntry_enabled, CConstant.ORDER_NEW);
                    newFrmPictureBox(this.pMain, 400, 50, "OrdersSearch", "订单查询", Resources.orderSearch, Resources.orderSearch_enabled, CConstant.ORDER_SEARCH);
                    newFrmPictureBox(this.pMain, 700, 50, "OrdersSearch", "订单修正", Resources.orderModify, Resources.orderModify_enabled, CConstant.ORDER_MODIFY);
                    newFrmPictureBox(this.pMain, 100, 250, "OrdersSearch", "订单通知", Resources.orderVerify, Resources.orderVerify_enabled, CConstant.ORDER_VERIFY);
                    break;
                case "menuPurchaseManage":
                    break;
                case "menuFinanceManage":
                    break;
                case "menuStockManage":
                    break;
                case "menuImportManage":
                    break;
                case "menuNotify":
                    break;
                case "menuInvoiceManage":
                    break;
                case "menuProduceManage":
                    newFrmPictureBox(this.pMain, 50, 50, "ProductionNotification", "生产通知查询", Resources.ProductionNotification, Resources.ProductionNotification_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 50, "ProductionPlan", "生产计划输入", Resources.ProductionPlan, Resources.ProductionPlan_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 50, "ProductionPlanSearch", "生产计划查询", Resources.ProductionPlanSearch, Resources.ProductionPlanSearch_enabled, "");
                    newFrmPictureBox(this.pMain, 50, 250, "DownLoadCustomerDrawing", "客户图纸下载", Resources.DownLoadCustomerDrawing, Resources.DownLoadCustomerDrawing_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 250, "UpLoadProductionDrawing", "生产图纸上传", Resources.UpLoadProductionDrawing, Resources.UpLoadProductionDrawing_enabled, "");
                    newFrmPictureBox(this.pMain, 450, 250, "Production", "生产实绩输入", Resources.Production, Resources.Production_enabled, "");
                    newFrmPictureBox(this.pMain, 50, 450, "ProductionSchedule", "生产进度查询", Resources.ProductionSchedule, Resources.ProductionSchedule_enabled, "");
                    newFrmPictureBox(this.pMain, 650, 250, "ProductionTechnology", "技术实绩输入", Resources.Production, Resources.Production_enabled, "");
                    newFrmPictureBox(this.pMain, 250, 450, "ProductionProcessWeight", "备料重量统计", Resources.PurchaseOrderSupplementEntry, Resources.PurchaseOrderSupplementEntry_enabled, "");
                   
                    break;
                case "menuLogManage":
                    break;
                case "menuDesk":
                    DataTable dt = bCommon.GetDeskDatas(UserTable.COMPANY_CODE, UserTable.CODE).Tables[0];
                    int i = 0, j = 0;

                    foreach (DataRow dr in dt.Rows)
                    {
                        int x = 50 + 200 * i;
                        int y = 25 + 160 * j;
                        string frmName = dr["FORM_NAME"].ToString();
                        string title = dr["FORM_TITLE"].ToString();
                        Image img = ByteToImage((byte[])dr["PIC"]);
                        string tag = dr["FORM_ARGS"].ToString();
                        newDeskFrmPictureBox(this.pMain, x, y, frmName, title, img, tag);

                        i++;
                        if (i == 5)
                        {
                            i = 0;
                            j++;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region newFrmPictureBox

        private void newDeskFrmPictureBox(Panel panel, int x, int y, string name, string text, Image image, string tag)
        {
            bool roles = CheckRoles(CCacheData.GetRolesFunction(UserTable.ROLES_CODE), "", name, text, tag);
            x = Int32.Parse(Math.Ceiling(x * newx).ToString());
            y = Int32.Parse(Math.Ceiling(y * newy).ToString());
            PictureBox pic = new System.Windows.Forms.PictureBox();
            pic.Image = image;
            pic.Location = new System.Drawing.Point(x, y);
            pic.Name = "Frm" + name;
            pic.Size = new System.Drawing.Size(100, 100);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pic.TabIndex = 1;
            pic.Tag = tag;
            pic.TabStop = false;
            pic.Cursor = Cursors.Hand;
            if (roles)
            {
                pic.ContextMenuStrip = menuDelete;
                pic.Click += new System.EventHandler(this.Pic_Click);
                pic.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
                pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
                pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
            }
            panel.Controls.Add(pic);

            Label lbl = new System.Windows.Forms.Label();
            lbl.ForeColor = Color.Black;
            lbl.Location = new System.Drawing.Point(x - 15, y + 104);
            lbl.Name = "LBL" + name + CConvert.ToString(tag, 2);
            lbl.Size = new System.Drawing.Size(130, 20);
            lbl.TabIndex = 0;
            lbl.Text = text;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panel.Controls.Add(lbl);
        }

        private void newFrmPictureBox(Panel panel, int x, int y, string name, string text, Image image, Image image_enabled, string tag)
        {
            bool roles = CheckRoles(CCacheData.GetRolesFunction(UserTable.ROLES_CODE), "", name, text, tag);
            x = Int32.Parse(Math.Ceiling(x * newx).ToString());
            y = Int32.Parse(Math.Ceiling(y * newy).ToString());
            PictureBox pic = new System.Windows.Forms.PictureBox();
            pic.Location = new System.Drawing.Point(x, y);
            pic.Name = "Frm" + name;
            pic.Size = new System.Drawing.Size(100, 100);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pic.TabIndex = 1;
            pic.Tag = tag;
            pic.TabStop = false;
            pic.Cursor = Cursors.Hand;
            if (roles)
            {
                if (!"Invoice".Equals(name))
                {
                    pic.Image = image;
                    pic.Click += new System.EventHandler(this.Pic_Click);
                    pic.ContextMenuStrip = menuAdd;
                    pic.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
                    pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
                    pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
                }
                else
                {
                    pic.Image = image;
                    pic.Click += new System.EventHandler(this.Invoice_click);
                    pic.ContextMenuStrip = menuAdd;
                    pic.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
                    pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
                    pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
                }
            }
            else
            {
                pic.Image = image_enabled;
            }

            panel.Controls.Add(pic);

            Label lbl = new System.Windows.Forms.Label();
            lbl.ForeColor = Color.Black;
            lbl.Location = new System.Drawing.Point(x - 15, y + 104);
            lbl.Name = "LBL" + name + CConvert.ToString(tag, 2);
            lbl.Size = new System.Drawing.Size(130, 20);
            lbl.TabIndex = 0;
            lbl.Text = text;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panel.Controls.Add(lbl);
        }

        private void newMinFrmPictureBox(Panel panel, int x, int y, string name, string text, Image image, Image image_enabled, string tag)
        {
            bool roles = CheckRoles(CCacheData.GetRolesFunction(UserTable.ROLES_CODE), "", name, text, tag);
            x = Int32.Parse(Math.Ceiling(x * newx).ToString());
            y = Int32.Parse(Math.Ceiling(y * newy).ToString());
            PictureBox pic = new System.Windows.Forms.PictureBox();
            pic.Location = new System.Drawing.Point(x, y);
            pic.Name = "Frm" + name;
            pic.Size = new System.Drawing.Size(80, 80);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pic.TabIndex = 1;
            pic.Tag = tag;
            pic.TabStop = false;
            pic.Cursor = Cursors.Hand;
            if (roles)
            {
                if (!"Invoice".Equals(name))
                {
                    pic.Image = image;
                    pic.Click += new System.EventHandler(this.Pic_Click);
                    pic.ContextMenuStrip = menuAdd;
                    pic.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
                    pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
                    pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
                }
                else
                {
                    pic.Image = image;
                    pic.Click += new System.EventHandler(this.Invoice_click);
                    pic.ContextMenuStrip = menuAdd;
                    pic.MouseLeave += new System.EventHandler(this.Pic_MouseLeave);
                    pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseMove);
                    pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pic_MouseDown);
                }
            }
            else
            {
                pic.Image = image_enabled;
            }

            panel.Controls.Add(pic);

            Label lbl = new System.Windows.Forms.Label();
            lbl.ForeColor = Color.Black;
            lbl.Location = new System.Drawing.Point(x - 15, y + 84);
            lbl.Name = "LBL" + name + CConvert.ToString(tag, 2);
            lbl.Size = new System.Drawing.Size(130, 20);
            lbl.TabIndex = 0;
            lbl.Text = text;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panel.Controls.Add(lbl);
        }

        private void newMenuLine(int x, int y, int width, int height, Image image)
        {
            PictureBox pic = new System.Windows.Forms.PictureBox();
            pic.Location = new System.Drawing.Point(Int32.Parse(Math.Ceiling(x * newx).ToString()), Int32.Parse(Math.Ceiling(y * newy).ToString()));
            pic.Size = new System.Drawing.Size(width, Int32.Parse(Math.Ceiling(height * newy).ToString()));
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic.Image = image;
            this.pMain.Controls.Add(pic);
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            Control[] control = this.Controls.Find(pic.Name.Replace("Frm", "LBL") + CConvert.ToString(_pic.Tag, 2), true);

            //调用父窗体的ParentShowForm()方法 
            if ((this.MdiParent != null) && (this.MdiParent is CZZD.ERP.Main.IMdiParent))
                (this.MdiParent as CZZD.ERP.Main.IMdiParent).ParentShowForm("WinUI", pic.Name, control[0].Text, pic.Tag.ToString());
        }

        private void Invoice_click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            FrmInvoice frm = new FrmInvoice(pic.Tag.ToString());
            frm.ShowDialog();
            frm.Dispose();
        }

        private void Pic_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.BackgroundImage = null;
        }

        private void Pic_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pic.BackgroundImage = Resources.menu_border;
            pic.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Pic_MouseDown(object sender, MouseEventArgs e)
        {
            _pic = (PictureBox)sender;
        }
        #endregion

        /// <summary>
        /// 添加到我的桌面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeskAdd_Click(object sender, EventArgs e)
        {
            Control[] control = this.Controls.Find(_pic.Name.Replace("Frm", "LBL") + CConvert.ToString(_pic.Tag, 2), true);
            BaseDeskTable deskTable = new BaseDeskTable();
            deskTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            deskTable.USER_CODE = UserTable.CODE;
            deskTable.FORM_NAME = _pic.Name.Replace("Frm", "");
            deskTable.FORM_TITLE = control[0].Text;
            deskTable.FORM_ARGS = _pic.Tag.ToString();
            deskTable.PIC = ImageToByte(_pic.Image);

            try
            {
                DataTable dt = CCacheData.GetDesk(UserTable.COMPANY_CODE, UserTable.CODE);

                if (dt != null && dt.Rows.Count > maxSize)
                {
                    MessageBox.Show("我的桌面己经超出最大上限　" + maxSize, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {

            }

            if (bCommon.Exists(deskTable))
            {
                MessageBox.Show(deskTable.FORM_TITLE + "己经存在！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //添加
            if (bCommon.InsertDesk(deskTable))
            {
                CCacheData.ResetDesk(UserTable.COMPANY_CODE, UserTable.CODE);
            }
        }

        /// <summary>
        /// 从我的桌面删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeskDelete_Click(object sender, EventArgs e)
        {
            Control[] control = this.Controls.Find(_pic.Name.Replace("Frm", "LBL") + CConvert.ToString(_pic.Tag, 2), true);
            BaseDeskTable deskTable = new BaseDeskTable();
            deskTable.COMPANY_CODE = UserTable.COMPANY_CODE;
            deskTable.USER_CODE = UserTable.CODE;
            deskTable.FORM_NAME = _pic.Name.Replace("Frm", "");
            deskTable.FORM_TITLE = control[0].Text;
            deskTable.FORM_ARGS = _pic.Tag.ToString();

            //删除
            if (bCommon.DeleteDesk(deskTable))
            {
                CCacheData.ResetDesk(UserTable.COMPANY_CODE, UserTable.CODE);
                //页面刷新
                ChildShowForm(this.Text, "menuDesk");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private byte[] ImageToByte(Image image)
        {
            byte[] img = null;
            try
            {
                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Png);
                img = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(img, 0, Convert.ToInt32(ms.Length));
                ms.Close();
            }
            catch (Exception ex) { }

            return img;
        }

        private Image ByteToImage(byte[] bt)
        {
            MemoryStream stream = new MemoryStream(bt);
            Image img = Image.FromStream(stream);
            return img;
        }

    }//end class
}
