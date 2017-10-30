using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.CacheData;
using CZZD.ERP.Common;
using CZZD.ERP.Model;

namespace CZZD.ERP.WinUI
{
    public partial class FrmRolesFunction : FrmBase
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name);
        private DataTable _currentRoles = null;
        private string _currentRolesCode = "";


        public FrmRolesFunction()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void FrmRolesFunctioncs_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = Tag;
        }

        #region
        /// <summary>
        /// 绑定TreeView
        /// </summary>
        private void Bind_Tv(DataTable currentRoles)
        {
            DataTable dt = CCacheData.Function.Copy();
            dt.Columns.Add("checked", Type.GetType("System.Boolean"));
            //数据处理
            foreach (DataRow dr in dt.Rows)
            {
                dr["checked"] = false;
                foreach (DataRow row in currentRoles.Rows)
                {
                    if (CConvert.ToString(dr["function_code"]) == CConvert.ToString(row["function_code"]))
                    {
                        dr["checked"] = true;
                        break;
                    }
                }
            }

            //绑定
            TreeNode pNode = null;
            TreeNode cNode = null;
            string pCode = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (pCode != CConvert.ToString(dr["code"]))
                {
                    if (pCode == "")
                    {
                        pNode = new TreeNode();
                    }
                    else
                    {
                        pNode.ExpandAll();
                        tvFunction.Nodes.Add(pNode);
                        pNode = new TreeNode();
                    }
                    pCode = CConvert.ToString(dr["code"]);
                    pNode.Tag = pCode;
                    pNode.Text = CConvert.ToString(dr["name"]);
                    pNode.Checked = CConvert.ToBoolean(dr["checked"]);
                }
                cNode = new TreeNode();
                cNode.Tag = CConvert.ToString(dr["function_code"]);
                cNode.Text = CConvert.ToString(dr["title"]) + "  " + CConvert.ToString(dr["memo"]);
                cNode.Checked = CConvert.ToBoolean(dr["checked"]);
                if (pNode.Checked)
                {
                    pNode.Checked = CConvert.ToBoolean(dr["checked"]);
                }
                pNode.Nodes.Add(cNode);
            }

            if (pNode != null)
            {
                pNode.ExpandAll();
                tvFunction.Nodes.Add(pNode);
            }
        }

        //设置标志，防止死循环
        bool check = false;
        //节点勾选后事件，如果更改某一节点状态会自动触发，所以在后面的方法中无需递归
        private void tvFunction_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (check == false)
            {
                setchild(e.Node);
            }
            setparent(e.Node);
            check = false;
        }

        //设置子节点状态
        private void setchild(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = node.Checked;
            }
            check = true;
        }

        //设置父节点状态
        private void setparent(TreeNode node)
        {
            if (node.Parent != null)
            {
                //如果当前节点状态为勾选，则需要所有兄弟节点都勾选才能勾选父节点      
                if (node.Checked)
                {
                    foreach (TreeNode brother in node.Parent.Nodes)
                    {
                        if (brother.Checked == false)
                            return;
                    }
                }
                node.Parent.Checked = node.Checked;
            }
        }
        #endregion


        private void btnSearch_Click(object sender, EventArgs e)
        {
            //输入验证
            if (this.txtRolesCode.Text.Trim() == "")
            {
                MessageBox.Show(" 角色编号不能为空！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lblRoles.Text = "  角色：" + txtRolesName.Text;
            _currentRolesCode = txtRolesCode.Text.Trim();
            tvFunction.Nodes.Clear();
            _currentRoles = bCommon.GetRoles(txtRolesCode.Text).Tables[0];
            Bind_Tv(_currentRoles);

            btnSave.Enabled = true;
        }

        /// <summary>
        /// 权限保存
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {

            DataTable rolesDt = _currentRoles.Clone();
            foreach (TreeNode pNode in tvFunction.Nodes)
            {
                foreach (TreeNode cNode in pNode.Nodes)
                {
                    if (cNode.Checked)
                    {
                        DataRow dr = rolesDt.NewRow();
                        dr["ROLES_CODE"] = _currentRolesCode;
                        dr["FUNCTION_CODE"] = cNode.Tag;
                        rolesDt.Rows.Add(dr);
                    }
                }
            }
            try
            {
                if (bCommon.UpdateRoles(rolesDt, _currentRolesCode) > 0)
                {
                    MessageBox.Show("权限保存成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRolesCode.Text = "";
                    txtRolesName.Text = "";
                    btnSave.Enabled = false;
                    lblRoles.Text = "  ";
                    tvFunction.Nodes.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("权限保存失败,请重试或与管理员联系。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.Error("权限保存失败！", ex);
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 角色的验证事件
        /// <summary>
        /// 角色的验证事件
        /// </summary>
        private void txtRolesCode_Leave(object sender, EventArgs e)
        {
            string rolesCode = txtRolesCode.Text.Trim();
            if (rolesCode != "")
            {
                BaseMaster baseMaster = bCommon.GetBaseMaster("ROLES", rolesCode);
                if (baseMaster != null)
                {
                    txtRolesCode.Text = baseMaster.Code;
                    txtRolesName.Text = baseMaster.Name;
                }
                else
                {
                    MessageBox.Show("角色不存在！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRolesCode.Text = "";
                    txtRolesName.Text = "";
                    txtRolesCode.Focus();
                }
            }
            else
            {
                txtRolesName.Text = "";
            }
        }

        /// <summary>
        /// 角色的查找事件
        /// </summary>
        private void btnRoles_Click(object sender, EventArgs e)
        {
            FrmMasterSearch frm = new FrmMasterSearch("ROLES", "");
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.BaseMasterTable != null)
                {
                    txtRolesCode.Text = frm.BaseMasterTable.Code;
                    txtRolesName.Text = frm.BaseMasterTable.Name;
                }
            }
            frm.Dispose();
        }

        #endregion


        #region 页面的回车键处理事件
        private void txtRolesCode_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// 回车键控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRolesCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                //SendKeys.Send("{tab}");     
                this.btnSearch.Focus();      
            }
        }



    }//end class
}
