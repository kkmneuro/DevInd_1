using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOADMIN_NEW.Forms
{
    public partial class frmLoadInitialDetails : Form
    {
        public frmLoadInitialDetails()
        {
            InitializeComponent();
        }

        private void frmLoadInitialDetails_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
            ui_nwbInitialDetails.BeginWait();
        }
    }
}
