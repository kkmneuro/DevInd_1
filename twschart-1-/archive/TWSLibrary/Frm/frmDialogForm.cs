///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//16/02/2012	VP		    1.Code for closing of form on Escape key
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;

namespace CommonLibrary.UserControls
{
    public partial class frmDialogForm : NForm
    {
        #region "            CONSTRUCTOR           "

        /// <summary>
        /// Constructor for initilizing the components of the frmDialogForm 
        /// </summary>
        public frmDialogForm()
        {
            InitializeComponent();
        }

        #endregion "          CONSTRUCTOR            "

        private void frmDialogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Close();
        }

        private void frmDialogForm_Load(object sender, EventArgs e)
        {
        }
    }
}