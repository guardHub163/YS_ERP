using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Bll;
using CZZD.ERP.Model;
using CZZD.ERP.Common;
using System.IO;

namespace CZZD.ERP.Main
{
    public partial class FrmSetting : FrmBase
    {
        public FrmSetting()
        {
            InitializeComponent();
        }

        BCompany bCompany = new BCompany();
        BaseUserTable buserTable = new BaseUserTable();
        BUser bUser = new BUser();
        private void btnOK_Click(object sender, EventArgs e)
        {
            string info = cboCompany.SelectedValue.ToString() + "|" + txtCompany.Text + "|" + txtPath.Text+@"\"+cboCompany.Text;
            buserTable.INFO = info;
            buserTable.CODE = UserTable.CODE;

            //createFiles("aaaaa",txtPath.Text);

            if (!Directory.Exists(txtPath.Text+@"\"+cboCompany.Text))//如果不存在文件夹
            {
                Directory.CreateDirectory(txtPath.Text + @"\" + cboCompany.Text);//创建文件夹
            }
            //if (!File.Exists(floderPath + fileName))//如果不存在指定的文件
            //{
            //    File.Create(floderPath + fileName);//创建文件，此处可以按照你的要求来创建。

            //}

            bool b = bUser.UpdateDefault(buserTable);

            if (b == true)
            {
                MessageBox.Show("设定成功.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            else
            {
                MessageBox.Show("设定失败.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //public void createFiles(string context, string path)
        //{
        //    using (StreamWriter sw = new StreamWriter(path, true))
        //    {
        //        sw.Write(context);
        //        sw.Close();
        //    }
        //}

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            if (UserTable.INFO == null)
            {
                DataSet ds = bCompany.GetList("");
                cboCompany.ValueMember = "CODE";
                cboCompany.DisplayMember = "CODE";
                cboCompany.DataSource = ds.Tables[0];
                DataTable dt = bCompany.GetList("CODE = '" + cboCompany.SelectedValue.ToString() + "'").Tables[0];
                txtCompany.Text = dt.Rows[0]["NAME"].ToString();
            }
            else
            {   //string[] strHeader = title.Split(',');
                //for (int i = 0; i < strHeader.Length; i++)
                //{
                //    excel.Cells[3 + Max, i + 1] = strHeader[i].ToString();
                //}

                string str = UserTable.INFO.ToString();
                DataSet ds = bCompany.GetList("");
                cboCompany.ValueMember = "CODE";
                cboCompany.DisplayMember = "CODE";
                cboCompany.DataSource = ds.Tables[0];
                string[] strRe = str.Split('|');
                this.cboCompany.SelectedValue = strRe[0].Trim().ToString();
                txtCompany.Text = strRe[1].Trim().ToString();
                txtPath.Text = strRe[2].Trim().ToString();
            }
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = bCompany.GetList("CODE = '" + cboCompany.SelectedValue.ToString() + "'").Tables[0];
            txtCompany.Text = dt.Rows[0]["NAME"].ToString();
        }

        private void btnFileName_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = folder.SelectedPath.ToString();
            }
        }
    }
}
