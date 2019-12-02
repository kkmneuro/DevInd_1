
///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//17/01/2012	VP          Designing and Coding of form	
//18/01/2012	VP		    Commenting of Code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Nevron.UI.WinForm.Controls;

namespace PALSA.Frm
{
    public partial class frmBuyOrderEntry : frmBase
    {
        #region    "      MEMBERS       "

        static Frm.frmBuyOrderEntry _Instance = null;

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "
        /// <summary>
        /// Provides the instance of frmOrderEntry form
        /// </summary>
        public static frmBuyOrderEntry INSTANCE
        {
            get
            {
                if(_Instance==null)
                    _Instance=new frmBuyOrderEntry();
                return _Instance;
            }
        }

        #endregion "      PROPERTY      "

        #region "            CONSTRUCTOR           "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public frmBuyOrderEntry()
        {
            InitializeComponent();
        }
        #endregion "          CONSTRUCTOR            "

        #region    "      METHODS       "

        /// <summary>
        /// Called when form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOrderEntry_Load(object sender, EventArgs e)
        {
            this.Title = ui_uctlOrderEntry.Title;
            ui_uctlOrderEntry.OnSubmitClick += new Action<object, EventArgs>(ui_uctlOrderEntry_OnSubmitClick);
        }

        /// <summary>
        /// Called when submit button clicked
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        void ui_uctlOrderEntry_OnSubmitClick(object arg1, EventArgs arg2)
        {
            this.Close();
        }

        #endregion "      METHODS       "

        private void ui_uctlOrderEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
