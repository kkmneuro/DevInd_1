using System;
using System.Windows.Forms;

namespace BOADMIN_NEW.Forms
{
    public partial class frmCollateral : FrmBase
    {
        private static frmCollateral _Instance = null;

        public static frmCollateral INSTANCE
        {
            get { return _Instance ?? (_Instance = new frmCollateral()); }
        }

        public frmCollateral()
        {
            InitializeComponent();
        }

        private void frmCollateral_Load(object sender, EventArgs e)
        {
            uctlCollateralMain1.InitControls();
        }

        private void frmCollateral_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
