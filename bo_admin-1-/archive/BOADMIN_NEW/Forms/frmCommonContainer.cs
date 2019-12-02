using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Nevron.UI.WinForm.Controls;
using Nevron.UI.WinForm.Docking;

namespace BOADMIN_NEW.Forms
{
    public partial class frmCommonContainer : FrmBase
    {
        //const int Tolerance_ =45;
        public frmCommonContainer()
        {
            InitializeComponent();
            
        }
       

        private void frmCommonContainer_Load(object sender, EventArgs e)
        {
            this.Size = new Size(this.Controls[0].Size.Width +20, this.Controls[0].Size.Height +40);
            this.Controls[0].Dock = System.Windows.Forms.DockStyle.Fill;
            this.Icon = Properties.Resources.favicon;
        }
      
    }
}
