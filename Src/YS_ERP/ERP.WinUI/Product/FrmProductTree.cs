using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZZD.ERP.Main;
using CZZD.ERP.Bll;
using CZZD.ERP.Common;
using CZZD.ERP.Model;
using CZZD.ERP.CacheData;

namespace CZZD.ERP.WinUI
{
    public partial class FrmProductTree : FrmBase
    {
        BSlipType bll = new BSlipType();
        DataTable currentDt = new DataTable();
        public FrmProductTree()
        {
            InitializeComponent();
        }
        BProductionProcess bProductionProcess = new BProductionProcess();
        private void FrmProductTree_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Tag = CTag;
            currentDt = bll.GetProductTreeList().Tables[0];
            tv_Bind();

            cboStatus.DataSource = CCacheData.JUDGMENT;
            cboStatus.ValueMember = "CODE";
            cboStatus.DisplayMember = "NAME";

        }

        private void tv_Bind()
        {
            tv.Nodes.Clear();
            TreeNode pNode = null;
            TreeNode cNode = null;
            TreeNode gNode = null;

            string currentPCode = "";
            string currentCCode = "";
            try
            {
                foreach (DataRow dr in currentDt.Rows)
                {
                    string pCode = CConvert.ToString(dr["SLIP_TYPE_CODE"]);
                    string cCode = CConvert.ToString(dr["COMPOSITION_PRODUCTS_CODE"]);
                    string gCode = CConvert.ToString(dr["PRODUCTION_PROCESS_CODE"]);
                    string pName = CConvert.ToString(dr["SLIP_TYPE_NAME"]);
                    string cName = CConvert.ToString(dr["COMPOSITION_PRODUCTS_NAME"]);
                    string gName = CConvert.ToString(dr["PRODUCTION_PROCESS_NAME"]);


                    if (currentPCode != pCode)
                    {
                        if (!"".Equals(currentPCode))
                        {
                            if (cNode != null)
                            {
                                pNode.Nodes.Add(cNode);
                            }
                            currentCCode = "";
                            tv.Nodes.Add(pNode);
                        }
                        pNode = new TreeNode();
                        //pNode.ContextMenuStrip = contextMenuType;
                        pNode.Name = pCode;
                        pNode.Text = pName;
                    }


                    if (currentCCode != cCode)
                    {
                        if (!"".Equals(currentCCode))
                        {
                            pNode.Nodes.Add(cNode);
                        }
                        cNode = new TreeNode();
                        //cNode.ContextMenuStrip = contextMenuParts;
                        cNode.Name = cCode;
                        cNode.Text = cName;
                    }

                    gNode = new TreeNode();
                    //gNode.ContextMenuStrip = contextMenuProductionProcess;
                    gNode.Name = gCode;
                    gNode.Text = gName;
                    cNode.Nodes.Add(gNode);

                    currentPCode = pCode;
                    currentCCode = cCode;
                }

                if (pNode != null)
                {
                    if (cNode != null)
                    {
                        pNode.Nodes.Add(cNode);
                    }
                    tv.Nodes.Add(pNode);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            TreeNode node = tv.SelectedNode;
            TreeNode prevNode = node.PrevNode;
            if (prevNode != null)
            {

                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent == null)
                {
                    tv.Nodes.Insert(prevNode.Index, newNode);
                }
                else
                {
                    node.Parent.Nodes.Insert(prevNode.Index, newNode);
                }
                node.Remove();
                tv.Focus();
                tv.SelectedNode = newNode;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            TreeNode node = tv.SelectedNode;
            TreeNode nextNode = node.NextNode;
            if (nextNode != null)
            {

                TreeNode newNode = (TreeNode)node.Clone();
                if (node.Parent == null)
                {
                    tv.Nodes.Insert(nextNode.Index + 1, newNode);
                }
                else
                {
                    node.Parent.Nodes.Insert(nextNode.Index + 1, newNode);
                }
                node.Remove();
                tv.Focus();
                tv.SelectedNode = newNode;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void tv_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = tv.SelectedNode;
            if (node.Nodes.Count <= 0)
            {
                //MessageBox.Show(node.Name + node.Text);
                BaseProductionProcessTable _currentProductionProcessTable = bProductionProcess.GetModel(node.Name);
                txtCode.Text = _currentProductionProcessTable.CODE;
                txtName.Text = _currentProductionProcessTable.NAME;
                txtenglishname.Text = _currentProductionProcessTable.ENGLISHNAME;
                txtDepartment.Text = _currentProductionProcessTable.DEPARTMENT_NAME;
                txtDepartmentCode.Text = _currentProductionProcessTable.DEPARTMENT_CODE;
                txtDrawingType1.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME1;
                txtDrawingType2.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME2;
                txtDrawingType3.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME3;
                txtDrawingType4.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME4;
                txtDrawingType5.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME5;
                txtDrawingType6.Text = _currentProductionProcessTable.DRAWING_TYPE_NAME6;
                txtDrawingTypeCode1.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE1;
                txtDrawingTypeCode2.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE2;
                txtDrawingTypeCode3.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE3;
                txtDrawingTypeCode4.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE4;
                txtDrawingTypeCode5.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE5;
                txtDrawingTypeCode6.Text = _currentProductionProcessTable.DRAWING_TYPE_CODE6;
                txtTechnologyCode1.Text = _currentProductionProcessTable.TECHNOLOGY_CODE1;
                txtTechnologyCode2.Text = _currentProductionProcessTable.TECHNOLOGY_CODE2;
                txtTechnologyCode3.Text = _currentProductionProcessTable.TECHNOLOGY_CODE3;
                txtTechnology1.Text = _currentProductionProcessTable.TECHNOLOGY_NAME1;
                txtTechnology2.Text = _currentProductionProcessTable.TECHNOLOGY_NAME2;
                txtTechnology3.Text = _currentProductionProcessTable.TECHNOLOGY_NAME3;
                txtproductioncycle.Text = _currentProductionProcessTable.PRODUCTION_CYCLE.ToString();
                this.cboStatus.SelectedValue = _currentProductionProcessTable.JUDGMENT;
            }
        }

    }//end class
}
