///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//20/02/2012	NAMO	    1.Design and coding of the form frmIndexView
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
//using Logging;
using Nevron.UI.WinForm.Controls;

namespace PALSA.Frm
{
    public partial class frmIndexView : NForm
    {
        private static frmIndexView _instance;

        public frmIndexView()
        {
            //FileHandling.WriteDevelopmentLog("IndexView : Enter into frmIndexView Constructor");

            InitializeComponent();

            //FileHandling.WriteDevelopmentLog("IndexView : Exit from frmIndexView Constructor");
        }

        public static frmIndexView INSTANCE
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmIndexView();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        private void frmIndexView_Load(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("IndexView : Enter into frmIndexView_Load Method");

            Text = uctlIndexView1.Title;

            //FileHandling.WriteDevelopmentLog("IndexView : Exit from frmIndexView_Load Method");
        }
    }
}