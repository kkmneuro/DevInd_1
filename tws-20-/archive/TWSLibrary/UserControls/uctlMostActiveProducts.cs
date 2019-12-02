///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//27/01/2012	VP		    1.Created uctlMostActiveProducts user control(Design)
//                          2.Completed coding related to ui of the control.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace CommonLibrary.UserControls
{
    public partial class UctlMostActiveProducts : UctlBase
    {
        #region    "      MEMBERS       "

        private string _title = "Most Active Products";

        #endregion "      MEMBERS       "

        #region    "      PROPERTY      "

        /// <summary>
        /// Sets and gets the title of the AlertDialog control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Sets and gets the Instrument Name of the Instrument Name combo box
        /// </summary>
        public string InstrumentList
        {
            get { return ui_ncmbInstrumentName.SelectedItem.ToString(); }
            set { ui_ncmbInstrumentName.SelectedItem = value; }
        }

        #endregion "      PROPERTY      "

        #region "            CONSTRUCTOR           "

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog 
        /// </summary>
        public UctlMostActiveProducts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlAlertDialog with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlMostActiveProducts(object customizeSettings)
        {
        }

        #endregion "          CONSTRUCTOR            "

        #region    "      METHODS       "

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            //Title = Cls.clsLocalizationHandler.MostActiveProducts;

            //ui_lblInstrumentName.Text = Cls.clsLocalizationHandler.Instrument + Cls.clsLocalizationHandler.Name + " :";
            //ui_ngbUpper.Text = Cls.clsLocalizationHandler.MostActiveProductsByValue;
            //ui_ngbDown.Text = Cls.clsLocalizationHandler.MostActiveProductsByVolume;
        }

        public void AddInstruments(List<string> lst)
        {
            ui_ncmbInstrumentName.Items.AddRange(lst.ToArray());
        }

        #endregion "      METHODS       "
    }
}