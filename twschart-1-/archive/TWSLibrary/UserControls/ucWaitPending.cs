using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GTS.Ctrl
{
    public partial class ucWaitPending : OrderChildControl
    {
        GTS.Frm.frmOrderEntry _Parent;
        public ucWaitPending(GTS.Frm.frmOrderEntry _frmOrderEntry)
        {
            InitializeComponent();
            _Parent = _frmOrderEntry;
            initControls();
        }
        private void initControls()
        {
            this.Dock = DockStyle.Fill;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Cancel the sent order
        }
    }
}
