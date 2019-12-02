using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;

namespace BOADMIN_NEW.Forms
{
    public partial class FrmBase : NForm
    {
        public FrmBase()
        {
            InitializeComponent();

                    
            System.Drawing.Icon ico = new System.Drawing.Icon(Properties.Resources.favicon, 16, 16);// Application.StartupPath + "\\Icons\\myphoto.ico");
            this.Icon = ico;

           
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {
          
        }
    }
}
