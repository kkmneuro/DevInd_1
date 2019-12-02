using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;

namespace PALSA.Frm
{
    public partial class frmConfirm : NForm
    {
        public bool _isDisplay = false;
        public frmConfirm(string msg, string side, string quantitis, string symbol, string price, string ordertype, string duration, string Account)
        {
            InitializeComponent();
            lblmsg.Text = "Would you like to "+msg+" the following order(s)?";
            nTreeView1.Nodes[0].Text = side.ToString()+" "+quantitis+" "+symbol+" @ "+price+ " "+ordertype;
            nTreeView1.Nodes[0].Nodes[0].Text = "Quantities: "+quantitis;
            nTreeView1.Nodes[0].Nodes[1].Text = "Price: "+price;
            nTreeView1.Nodes[0].Nodes[2].Text = "Duration: "+duration;
            nTreeView1.Nodes[0].Nodes[3].Text = "Account: "+Account;
            nTreeView1.Nodes[0].ExpandAll();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkdisplay.Checked)
            { _isDisplay = false; }
            else
            { _isDisplay = true; }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
