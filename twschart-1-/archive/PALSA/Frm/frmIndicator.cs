using System;
using System.Windows.Forms;
//using Logging;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;

namespace PALSA.Frm
{
    public partial class frmIndicator : NForm
    {
        private readonly IndicatorSelection m_selection = new IndicatorSelection();

        public frmIndicator()
        {
            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Enter into frmIndicator constructor");

            InitializeComponent();
            nTreeView1.ExpandAll();
            PopulateIndicatorlist();
            AcceptButton = btnOK;
            CancelButton = btnCancel;

            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Exit from frmIndicator constructor");
        }

        private void PopulateIndicatorlist()
        {
            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Enter into PopulateIndicatorlist Method");

            TreeNode tNode = nTreeView1.Nodes["Script_Forex"];
            tNode.ImageIndex = 0;
            tNode.SelectedImageIndex = 0;
            IndicatorList.PopulateIndicatorList(ref tNode); //by vijay
            tNode.ExpandAll();

            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Exit from PopulateIndicatorlist Method");
        }


        public IndicatorSelection GetIndicatorSelection()
        {
            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Enter into GetIndicatorSelection Method");

            m_selection.node = -1;
            if (ShowDialog() == DialogResult.Cancel)
                m_selection.node = -1;

            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Exit from GetIndicatorSelection Method");

            return m_selection;
        }

        private void nTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Enter into nTreeView1_AfterSelect Method");

            m_selection.node = IndicatorList.GetIndicatorIndex(e.Node.Text); //e.Node.Index;  //by vijay
            m_selection.IndicatorName = e.Node.Text;

            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Exit from nTreeView1_AfterSelect Method");
        }


        private void nTreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Enter into nTreeView1_BeforeSelect Method");

            nTreeView1.ExpandAll();

            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Exit from nTreeView1_BeforeSelect Method");
        }

        private void SetText()
        {
            //try
            {
                //treeNode1.Text = frmMainGTS.rm.GetString("");
                //nuiPanel1.Text = frmMainGTS.rm.GetString("");  //all line commented by vijay
                //btnCancel.Text = frmMainGTS.rm.GetString("");
                //btnOK.Text = frmMainGTS.rm.GetString("");            
            }
            //catch (Exception ex)
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Enter into btnCancel_Click Method");

            DialogResult = DialogResult.Cancel;
            Close();

            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Exit from btnCancel_Click Method");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Enter into btnOK_Click Method");

            DialogResult = DialogResult.OK;
            Close();

            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Exit from btnOK_Click Method");
        }

        private void nTreeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Enter into nTreeView1_MouseDoubleClick Method");

            DialogResult = DialogResult.OK;
            Close();

            //FileHandling.WriteDevelopmentLog("SelecteIndictor : Exit from nTreeView1_MouseDoubleClick Method");
        }
    }

    public class IndicatorSelection
    {
        public string IndicatorName;
        public int node;
    }
}