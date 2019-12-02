///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//24/01/2012	VP		    1.Desgining and coding of user control
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommonLibrary.UserControls
{
    public partial class UctlOrderEntryCustomize : UserControl
    {
        public UctlOrderEntryCustomize()
        {
            InitializeComponent();
        }

        public Color BuyColor { get; set; }
        public Color SellColor { get; set; }

        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            OnOkClick(ui_ncbBuyColor.Color, ui_ncbSellColor.Color);
            ParentForm.Close();
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void uctlOrderEntryCustomize_Load(object sender, EventArgs e)
        {
            ui_ncbBuyColor.Color = BuyColor;
            ui_ncbSellColor.Color = SellColor;
        }

        public event Action<Color, Color> OnOkClick;
    }
}