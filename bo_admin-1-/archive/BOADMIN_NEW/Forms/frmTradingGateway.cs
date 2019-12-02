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
    public partial class frmTradingGateway : FrmBase
    {
        private static frmTradingGateway _Instance = null;

        public static frmTradingGateway INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmTradingGateway();
                }
                return _Instance;
            }
        }

        public frmTradingGateway()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void frmTradingGateway_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
