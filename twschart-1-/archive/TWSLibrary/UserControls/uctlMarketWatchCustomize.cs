///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//17/01/2012	VP		    1.Design and coding of the control
//23/01/2012	VP          1.Add one more field Alert Trigger color
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommonLibrary.UserControls
{
    public partial class UctlMarketWatchCustomize : UserControl
    {
        public UctlMarketWatchCustomize()
        {
            InitializeComponent();
        }

        public Color UpColor { get; set; }
        public Color DownColor { get; set; }
        public Color AlertTriggerColor { get; set; }

        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            OnOkClick(ui_ncbUpTrendColor.Color, ui_ncbDownTrendColor.Color, ui_ncbAlertTriggerColor.Color);
            if (ParentForm != null) ParentForm.Close();
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            if (ParentForm != null) ParentForm.Close();
        }

        public event Action<Color, Color, Color> OnOkClick;

        private void uctlMarketWatchCustomize_Load(object sender, EventArgs e)
        {
            ui_ncbUpTrendColor.Color = UpColor;
            ui_ncbDownTrendColor.Color = DownColor;
            ui_ncbAlertTriggerColor.Color = AlertTriggerColor;
        }
    }
}