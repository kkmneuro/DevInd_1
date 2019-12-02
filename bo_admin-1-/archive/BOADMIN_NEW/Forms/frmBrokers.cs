using System.Windows.Forms;

namespace BOADMIN_NEW.Forms
{
    public partial class frmBrokers : FrmBase
    {
        private static frmBrokers _Instance = null;

        public static frmBrokers INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmBrokers();
                }
                return _Instance;
            }
        }

        public frmBrokers()
        {
            InitializeComponent();
            this.Palette.UseThemes = true;
            this.Icon = Properties.Resources.favicon;
        }

        private void frmBrokers_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }


       
    }
}
