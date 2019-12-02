using System.Windows.Forms;

namespace BOADMIN_NEW.Forms
{
    /// <summary>
    /// Main form of the FeeMaster control
    /// </summary>
    public partial class frmFeeMaster : FrmBase
    {
        private static frmFeeMaster _instance = null;
        public static frmFeeMaster GetInstance()
        {
            return _instance ?? (_instance = new frmFeeMaster());
        }

        public frmFeeMaster()
        {
            InitializeComponent();
            this.Palette.UseThemes = true;
            this.Icon = Properties.Resources.favicon;
        }

        private void frmFeeMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null; 
        }
    }
}
