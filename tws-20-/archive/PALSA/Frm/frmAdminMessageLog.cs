using System;

namespace TWS.Frm
{
    public partial class frmAdminMessageLog : frmBase
    {
        private static frmAdminMessageLog _instance;

        public frmAdminMessageLog()
        {
            InitializeComponent();
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public static frmAdminMessageLog INSTANCE
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmAdminMessageLog();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        private void frmAdminMessageLog_Load(object sender, EventArgs e)
        {
            Title = uctlAdminMessageLog1.Title;
        }
    }
}