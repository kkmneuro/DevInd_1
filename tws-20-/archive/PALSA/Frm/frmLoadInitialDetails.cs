/////////////////////////////////REVISION HISTORY//////////////////////////////////////////////////////////////////////////
//
//DATE			INITIALS			DESCRIPTION
//1 July 2014	Namo				frmLoadInitialDetails a splash screen is added which will be active untill all trade history is not loaded
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TWS.Frm
{
    public partial class frmLoadInitialDetails : Form
    {
        public frmLoadInitialDetails()
        {
            InitializeComponent();
        }

        private void frmLoadInitialDetails_Load(object sender, EventArgs e)
        {
            ui_nwbInitialDetails.BeginWait();
        }
    }
}
