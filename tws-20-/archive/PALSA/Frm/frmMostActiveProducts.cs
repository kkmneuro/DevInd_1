///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	VP		    1.Desgining of the form
//06/02/2012	VP		    1.Added code for persistency of form
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
//using Logging;
using TWS.Cls;

namespace TWS.Frm
{
    public partial class frmMostActiveProducts : frmBase
    {
        private static int count;
        private string _formkey;

        public frmMostActiveProducts()
        {
            InitializeComponent();
            count += 1;

           //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Enter into frmMostActiveProducts Constructor");

            _formkey = CommandIDS.MOST_ACTIVE_PRODCUTS.ToString() + "/" + Convert.ToString(count);

           //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from frmMostActiveProducts Constructor");
        }

        public override string Formkey
        {
            get { return _formkey; }
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        private void frmMostActiveProducts_Load(object sender, EventArgs e)
        {
           //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Enter into frmMostActiveProducts_Load Method");

            Title = uctlMostActiveProducts1.Title;

           //FileHandling.WriteDevelopmentLog("MarketWatch" + count +" : Exit from frmMostActiveProducts_Load Method");
        }

        private void frmMostActiveProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            _formkey = CommandIDS.MOST_ACTIVE_PRODCUTS.ToString() + "/" + Convert.ToString(count);
        }
    }
}