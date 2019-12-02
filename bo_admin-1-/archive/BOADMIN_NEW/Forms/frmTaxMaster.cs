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
    public partial class frmTaxMaster : FrmBase
    {
        private static frmTaxMaster _Instance=null;

        public static frmTaxMaster GetInstance()
        {
            if (_Instance == null)
                _Instance = new frmTaxMaster();
            return _Instance;
        }

        public frmTaxMaster()
        {
            InitializeComponent();
            this.Palette.UseThemes = true;
            this.Icon = Properties.Resources.favicon;
        }

        private void frmTaxMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
