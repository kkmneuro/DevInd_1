///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//03/01/2012	NN		    1.properties are renamed
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlMessageLogFilter : UctlBase
    {
        #region    "        MEMBERS           "

        private readonly string _fromDate = string.Empty;
        private readonly string _fromTime = string.Empty;
        private readonly string _toDate = string.Empty;
        private readonly string _toTime = string.Empty;
        private string _title = "Message Log Filter";

        #endregion  "        MEMBERS           "

        #region    "        PROPERTY          "

        /// <summary>
        /// This property sets and gets the title of the MessageLogFilter
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// This property gets the "From Date" of the MessageLogFilter
        /// </summary>
        public string FromDate
        {
            get { return _fromDate; }
        }

        /// <summary>
        /// This property gets the "From Time" of the MessageLogFilter
        /// </summary>
        public string FromTime
        {
            get { return _fromTime; }
        }

        /// <summary>
        /// This property gets the "To Date" of the MessageLogFilter
        /// </summary>
        public string ToDate
        {
            get { return _toDate; }
        }

        /// <summary>
        /// This property gets the "To Time" of the MessageLogFilter
        /// </summary>
        public string ToTime
        {
            get { return _toTime; }
        }

        #endregion    "        PROPERTY          "

        #region "        CONSTRUCTOR       "

        /// <summary>
        /// Constructor for initilizing the components of the uctlMessageLogFilter 
        /// </summary>
        public UctlMessageLogFilter()
        {
            InitializeComponent();
        }

        #endregion "    CONSTRUCTOR     "

        #region "         METHODS          "

        /// <summary>
        /// Sets the text of controls corresponding to localized value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Message + " " + ClsLocalizationHandler.Log + " " +
                    ClsLocalizationHandler.Filter;

            ui_nchkTimeRange.Text = ClsLocalizationHandler.Time + " " + ClsLocalizationHandler.Range;
            ui_lblFromTime.Text = ClsLocalizationHandler.From + " " + ClsLocalizationHandler.Time;
            ui_lblToTime.Text = ClsLocalizationHandler.To + " " + ClsLocalizationHandler.Time;
            ui_nbtnOK.Text = ClsLocalizationHandler.Ok;
            ui_nbtnCancel.Text = ClsLocalizationHandler.Cancel;
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick(sender, e);
        }

        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            OnOkClick(ui_ndtpFromDate.Value.ToString("MM/dd/yyyy"), ui_ndtpFromTime.Text,
                      ui_ndtpToDate.Value.ToString("MM/dd/yyyy"), ui_ndtpToTime.Text);
        }

        #endregion "       METHODS        "

        #region    "      EVENTS        "

        public event Action<string, string, string, string> OnOkClick;
        public event Action<object, EventArgs> OnCancelClick;

        #endregion "      EVENTS        "

        /// <summary>
        /// Task to be performed on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlMessageLogFilter_Load(object sender, EventArgs e)
        {
            SetLocalization();
        }

        public void GetLogFilterValues()
        {
        }

        private void ui_npnlMessageLogFilter_Click(object sender, EventArgs e)
        {
        }
    }
}