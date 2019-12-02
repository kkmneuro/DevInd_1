using System;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlPreferencesForexPair : UserControl
    {
        public UctlPreferencesForexPair()
        {
            InitializeComponent();
        }

        private void ui_ncbUpColor_ColorChanged(object sender, EventArgs e)
        {
            uctlForexPair1.ui_ndctrBuy.FillInfo.Gradient1 = ui_ncbUpColor.Color;
            uctlForexPair1.ui_ndctrBuy.FillInfo.Gradient2 = ui_ncbUpColor.Color;
            uctlForexPair1.ui_ndctrSell.FillInfo.Gradient1 = ui_ncbUpColor.Color;
            uctlForexPair1.ui_ndctrSell.FillInfo.Gradient2 = ui_ncbUpColor.Color;
        }

        private void ui_ncbDownColor_ColorChanged(object sender, EventArgs e)
        {
            uctlForexPair1.ui_ndctrBuy.FillInfo.Gradient1 = ui_ncbDownColor.Color;
            uctlForexPair1.ui_ndctrBuy.FillInfo.Gradient2 = ui_ncbDownColor.Color;
            uctlForexPair1.ui_ndctrSell.FillInfo.Gradient1 = ui_ncbDownColor.Color;
            uctlForexPair1.ui_ndctrSell.FillInfo.Gradient2 = ui_ncbDownColor.Color;
        }

        private void ui_ncbBackColor_ColorChanged(object sender, EventArgs e)
        {
            uctlForexPair1.BackColor = ui_ncbBackColor.Color;
        }

        public void SetValues(ClsForexPair forexPair)
        {
            SetOrderFormSettingType(forexPair.OrderFormSetting);
            SetPositionSizeType(forexPair.PositionSizeType);
            ui_ncbUpColor.Color = forexPair.UpTrendColor;
            ui_ncbDownColor.Color = forexPair.DownTrendColor;
            ui_ncbBackColor.Color = forexPair.BackColor;
        }

        private void SetPositionSizeType(int PositionSizeType)
        {
            if (PositionSizeType == 1)
            {
                ui_nrbLot.Checked = true;
            }
            else
            {
                ui_nrbAmount.Checked = true;
            }
        }

        private void SetOrderFormSettingType(int OrderFormSettingType)
        {
            switch (OrderFormSettingType)
            {
                case 1:
                    ui_nrbOpenOrderEntryForm.Checked = true;
                    break;
                case 2:
                    ui_nrbSendMarketOrderWithDefaultQty.Checked = true;
                    break;
                case 3:
                    ui_nrbSendMarketOrderWithDefaultQtyWithoutPrompt.Checked = true;
                    break;
            }
        }

        public ClsForexPair GetValues()
        {
            var objclsForexPair = new ClsForexPair();
            if (ui_nrbOpenOrderEntryForm.Checked)
            {
                objclsForexPair.OrderFormSetting = 1;
            }
            else if (ui_nrbSendMarketOrderWithDefaultQty.Checked)
            {
                objclsForexPair.OrderFormSetting = 2;
            }
            else
            {
                objclsForexPair.OrderFormSetting = 3;
            }

            if (ui_nrbLot.Checked)
            {
                objclsForexPair.PositionSizeType = 1;
            }
            else
            {
                objclsForexPair.PositionSizeType = 2;
            }
            objclsForexPair.UpTrendColor = ui_ncbUpColor.Color;
            objclsForexPair.DownTrendColor = ui_ncbDownColor.Color;
            objclsForexPair.BackColor = ui_ncbBackColor.Color;

            return objclsForexPair;
        }
    }
}