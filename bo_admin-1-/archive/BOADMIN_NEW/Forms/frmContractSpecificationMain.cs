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
    public partial class frmContractSpecificationMain : FrmBase
    {
        private static frmContractSpecificationMain _Instance = null;

        public static frmContractSpecificationMain INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmContractSpecificationMain();
                }
                return _Instance;
            }
        }
        public frmContractSpecificationMain()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void frmContractSpecificationMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
