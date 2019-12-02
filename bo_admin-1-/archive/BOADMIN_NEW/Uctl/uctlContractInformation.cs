using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSSocket.Classes;
using ProtocolStructs;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.Cls;
using Nevron.UI.WinForm.Controls;
using System.Runtime.InteropServices;
namespace BOADMIN_NEW.Uctl
{
    public partial class uctlContractInformation : UserControl //uctlGeneric, Interfaces.IUserCtrl
    {
        public DS4Symbol.dtContractInformationRow _SymbolRow = null;
        public clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        public int Askvalue = 0;
        public int BidValue = 0;
        public int prevDPR = 0;
        const Int32 WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint uMsg, Int32 wParam, Int32 lParam);

        public uctlContractInformation()
        {

            InitializeComponent();
            ui_ncmbOrders.SelectedIndex = 1;
            SetComboBoxValues();
        }

        #region IUserCtrl Members

        public void Init()
        {

        }
        /// <summary>
        /// Sets control values
        /// </summary>
        /// <param name="symbolRow"></param>
        public void SetValues(DS4Symbol.dtContractInformationRow symbolRow)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlContractInformation : Enter SetValues()");
                if (symbolRow == null)
                    return;
                //SetComboBoxValues();
                ui_ntxtSymbol.Text = symbolRow.Symbol;
                ui_ntxtDescription.Text = symbolRow.Description;
                ui_ncmbSecurityType.SelectedIndex = ui_ncmbSecurityType.Items.IndexOf(symbolRow.SecurityType);
                //ui_ncmbSetlingCurrency.Text = symbolRow.SettlingCurrency;
                ui_ntxtULAssest.Text = symbolRow.UA_Asset.ToString();
                ui_ncmbTradingCurrecny.SelectedIndex = ui_ncmbTradingCurrecny.Items.IndexOf(symbolRow.TradingCurrency);
                ui_ntxtSource.Text = symbolRow.Source;
                if (symbolRow.Digits.ToString().Trim() != string.Empty)
                {
                    ui_ntxtDigits.Text = symbolRow.Digits.ToString();
                }

                ui_ntxtDescription.Text = symbolRow.Description;
                ui_ncmbMarginCurrency.SelectedIndex = ui_ncmbMarginCurrency.Items.IndexOf(symbolRow.MarginCurrency);
                //ui_ncmbOrders.Text = symbolRow.Orders;
                if (symbolRow.LimitandStopLevel.ToString().Trim() != string.Empty)
                {
                    ui_ntxtLimtStopLevel.Text = symbolRow.LimitandStopLevel.ToString();
                }

                //ui_ntxtFreezeLevel.Text = symbolRow.FreezeLevel.ToString();
                ui_ncmbSetlingCurrency.SelectedIndex = ui_ncmbSetlingCurrency.Items.IndexOf(symbolRow.SettlingCurrency);
                ui_ntxtSpread.Text = symbolRow.Spread.ToString();
                if (symbolRow.MaximumLots.ToString().Trim() != string.Empty)
                {
                    ui_ntxtMaximumLots.Text = symbolRow.MaximumLots.ToString();
                }

                if (symbolRow.MaximumOrderValue.ToString().Trim() != string.Empty)
                {
                    ui_ntxtMaximumOrderValue.Text = symbolRow.MaximumOrderValue.ToString();
                }
                if (symbolRow.MaximumAllowablePosition.ToString().Trim() != string.Empty)
                {
                    ui_ntxtMaximumAllowablePosition.Text = symbolRow.MaximumAllowablePosition.ToString();
                }

                if (symbolRow.BuySideTurnover.ToString().Trim() != string.Empty)
                {
                    ui_ntxtBuySideTurnover.Text = symbolRow.BuySideTurnover.ToString();
                }

                if (symbolRow.SellSideTurnover.ToString().Trim() != string.Empty)
                {
                    ui_ntxtSellSideTurnover.Text = symbolRow.SellSideTurnover.ToString();
                }
                if (symbolRow.DeliveryQuantity.ToString().Trim() != string.Empty)
                {
                    ui_ntxtDeliveryQuantity.Text = symbolRow.DeliveryQuantity.ToString();
                }


                if (symbolRow.QuotationBaseValue.Trim() != string.Empty)
                {
                    ui_ntxtQuotationBaseValue.Text = symbolRow.QuotationBaseValue;
                }

                ui_ndtpDeliveryStartDate.Text = symbolRow.DeliveryStartDate;
                ui_ndtpDeliveryEndDate.Text = symbolRow.DeliveryEndDate;
                ui_ncmbDeliveryType.SelectedIndex = ui_ncmbDeliveryType.Items.IndexOf(symbolRow.DeliveryType);
                ui_ncmbDeliveryUnit.SelectedIndex = ui_ncmbDeliveryUnit.Items.IndexOf(symbolRow.DeliveryUnit);
                if (symbolRow.DeliveryQuantity.ToString().Trim() != string.Empty)
                {
                    ui_ntxtDeliveryQuantity.Text = symbolRow.DeliveryQuantity.ToString();
                }

                if (symbolRow.MarketLot.ToString().Trim() != string.Empty)
                {
                    ui_ntxtMarketLot.Text = symbolRow.MarketLot.ToString();
                }

                ui_ndtpExpiryDate.Text = symbolRow.ExpiryDate;
                ui_ndtpStartDate.Text = symbolRow.StartDate;
                ui_ndtpEndDate.Text = symbolRow.EndDate;
                ui_ndtpTenderStartDate.Text = symbolRow.TenderStartDate;
                ui_ndtpTenderEndDate.Text = symbolRow.TenderEndDate;
                if (symbolRow.DPRInitialPercentage.ToString().Trim() != string.Empty)
                {
                    ui_ntxtDPRInitialPercentage.Text = symbolRow.DPRInitialPercentage.ToString();
                }
                int.TryParse(symbolRow.DPR_Range_Higher.ToString(), out prevDPR);
                if (symbolRow.DPR_Range_Higher.ToString().Trim() != string.Empty)
                {
                    ui_ntxtDPRRangeHigher.Text = symbolRow.DPR_Range_Higher.ToString();
                }

                if (symbolRow.DPRInterval.ToString().Trim() != string.Empty)
                {
                    ui_ntxtDPRInterval.Text = symbolRow.DPRInterval.ToString();
                }

                if (symbolRow.ContractSize.Trim() != string.Empty)
                {
                    ui_ntxtContractSize.Text = symbolRow.ContractSize;
                }

                if (symbolRow.InitialBuyMargin.ToString().Trim() != string.Empty)
                {
                    ui_ntxtInitialBuyMargin.Text = symbolRow.InitialBuyMargin.ToString();
                }

                if (symbolRow.InitialSellMargin.ToString().Trim() != string.Empty)
                {
                    ui_ntxtInitialSellMargin.Text = symbolRow.InitialSellMargin.ToString();
                }

                if (symbolRow.MaintenanceBuyMargin.ToString().Trim() != string.Empty)
                {
                    ui_ntxtMaintenanceBuyMargin.Text = symbolRow.MaintenanceBuyMargin.ToString();
                }

                if (symbolRow.MaintenanceSellMargin.ToString().Trim() != string.Empty)
                {
                    ui_ntxtMaintenanceSellMargin.Text = symbolRow.MaintenanceSellMargin.ToString();
                }

                if (symbolRow.Hedged.Trim() != string.Empty)
                {
                    ui_ntxtHedged.Text = symbolRow.Hedged;
                }

                if (symbolRow.TickPrice.Trim() != string.Empty)
                {
                    ui_ntxtTickPrice.Text = symbolRow.TickPrice;
                }

                if (symbolRow.TickSize.Trim() != string.Empty)
                {
                    ui_ntxtTickSize.Text = symbolRow.TickSize;
                }


                ui_ncmbMaxLotsUnit.SelectedIndex = ui_ncmbMaxLotsUnit.Items.IndexOf(symbolRow.MaximumLostUnit);
                ui_ncmbMarketLotsUnit.SelectedIndex = ui_ncmbMarketLotsUnit.Items.IndexOf(symbolRow.MarketLostUnit);
                ui_ncmbBaseValueUnit.SelectedIndex = ui_ncmbBaseValueUnit.Items.IndexOf(symbolRow.QuotationBaseValueUnit);
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlContractInformation =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in SetValues()");
            }
        }
        /// <summary>
        /// Clears control info
        /// </summary>
        public void ClearControlsText()
        {
            ui_ntxtSymbol.Text = string.Empty;
            ui_ntxtDescription.Text = string.Empty;
            ui_ncmbSecurityType.Text = string.Empty;
            ui_ncmbSetlingCurrency.SelectedItem = string.Empty;
            ui_ntxtULAssest.Text = string.Empty;
            ui_ncmbTradingCurrecny.Text = string.Empty;
            ui_ntxtSource.Text = string.Empty;
            ui_ntxtDigits.Text = string.Empty;
            ui_ntxtDescription.Text = string.Empty;
            ui_ncmbMarginCurrency.Text = string.Empty;
            ui_ncmbOrders.SelectedItem = string.Empty;
            ui_ntxtLimtStopLevel.Text = string.Empty;
            ui_ntxtFreezeLevel.Text = string.Empty;
            ui_ncmbSetlingCurrency.Text = string.Empty;
            ui_ntxtSpread.Text = string.Empty;
            ui_ntxtMaximumLots.Text = string.Empty;
            ui_ntxtMaximumOrderValue.Text = string.Empty;
            ui_ntxtBuySideTurnover.Text = string.Empty;
            ui_ntxtSellSideTurnover.Text = string.Empty;
            ui_ntxtMaximumOrderValue.Text = string.Empty;
            ui_ntxtQuotationBaseValue.Text = string.Empty;
            ui_ndtpDeliveryStartDate.Text = string.Empty;
            ui_ndtpDeliveryEndDate.Text = string.Empty;
            ui_ncmbDeliveryType.Text = string.Empty;
            ui_ncmbDeliveryUnit.Text = string.Empty;
            ui_ntxtDeliveryQuantity.Text = string.Empty;
            ui_ntxtMarketLot.Text = string.Empty;
            ui_ndtpExpiryDate.Text = string.Empty;
            ui_ndtpStartDate.Text = string.Empty;
            ui_ndtpEndDate.Text = string.Empty;
            ui_ndtpTenderStartDate.Text = string.Empty;
            ui_ndtpTenderEndDate.Text = string.Empty;
            ui_ntxtDPRInitialPercentage.Text = string.Empty;
            ui_ntxtDPRRangeHigher.Text = string.Empty;
            ui_ntxtDPRInterval.Text = string.Empty;
            ui_ntxtSpreadBalance.Text = string.Empty;
            ui_ntxtFreezeLevel.Text = string.Empty;
            ui_ntxtContractSize.Text = string.Empty;
            ui_ntxtInitialBuyMargin.Text = string.Empty;
            ui_ntxtInitialSellMargin.Text = string.Empty;
            ui_ntxtMaintenanceBuyMargin.Text = string.Empty;
            ui_ntxtMaintenanceSellMargin.Text = string.Empty;
            ui_ntxtHedged.Text = string.Empty;
            ui_ntxtTickPrice.Text = string.Empty;
            ui_ntxtTickSize.Text = string.Empty;
            ui_ncmbMaxLotsUnit.Text = string.Empty;
            ui_ncmbMarketLotsUnit.Text = string.Empty;
            ui_ncmbBaseValueUnit.Text = string.Empty;

        }

        public void SaveMe()
        {
        }

        #endregion

        private void ui_txtSpreadByDefault_KeyUp(object sender, KeyEventArgs e)
        {
            if (ui_ntxtTickSize.Text == "")
            {
                ui_ntxtTickSize.Text = "0";

            }
            changeBidAndAskValue(Convert.ToInt32(Convert.ToDecimal(ui_ntxtTickSize.Text)));
        }


        private void changeBidAndAskValue(int value)
        {
            if (value % 2 == 0)
            {
                Askvalue = Convert.ToInt32(value) / 2;
                BidValue = (Convert.ToInt32(value) / 2);
            }
            else
            {
                Askvalue = (Convert.ToInt32(value) / 2) + 1;
                BidValue = (Convert.ToInt32(value) / 2);
            }
        }



        private void ui_TrackbarSpreadbalance_MouseClick(object sender, MouseEventArgs e)
        {
            // int i = ui_TrackbarSpreadbalance.TrackBarElement.Value;
        }

        private void uctlContractInformation_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Sets values of combobox
        /// </summary>
        public void SetComboBoxValues()
        {
            ui_ncmbTradingCurrecny.Items.Clear();
            ui_ncmbSetlingCurrency.Items.Clear();
            ui_ncmbMarginCurrency.Items.Clear();
            ui_ncmbSecurityType.Items.Clear();
            ui_ncmbDeliveryUnit.Items.Clear();
            ui_ncmbOrders.Items.Clear();
            ui_ncmbBaseValueUnit.Items.Clear();
            ui_ncmbMarketLotsUnit.Items.Clear();
            ui_ncmbMaxLotsUnit.Items.Clear();


            ui_ncmbTradingCurrecny.Items.AddRange(Cls.clsCurrencyManager.INSTANCE.GetCurrencyArray());
            ui_ncmbSetlingCurrency.Items.AddRange(Cls.clsCurrencyManager.INSTANCE.GetCurrencyArray());
            ui_ncmbMarginCurrency.Items.AddRange(Cls.clsCurrencyManager.INSTANCE.GetCurrencyArray());
            ui_ncmbSecurityType.Items.AddRange(Cls.clsSecurityManager.INSTANCE.GetSecurityNameArray());
            ui_ncmbBaseValueUnit.Items.AddRange(Cls.clsMasterInfoManager.INSTANCE.GetDeliveryUnits.ToArray());
            ui_ncmbMarketLotsUnit.Items.AddRange(Cls.clsMasterInfoManager.INSTANCE.GetDeliveryUnits.ToArray());
            ui_ncmbMaxLotsUnit.Items.AddRange(Cls.clsMasterInfoManager.INSTANCE.GetDeliveryUnits.ToArray());
            ui_ncmbDeliveryUnit.Items.AddRange(Cls.clsMasterInfoManager.INSTANCE.GetDeliveryUnits.ToArray());
            ui_ncmbOrders.Items.AddRange(Cls.clsMasterInfoManager.INSTANCE.GetOrderTypes.ToArray());

        }

        private void ui_ncmbDeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbDeliveryType.SelectedIndex == 0)
                ui_ncmbDeliveryUnit.Enabled = false;
            else
                ui_ncmbDeliveryUnit.Enabled = true;
        }

        private void ui_ntxtSymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsGlobal.KeyPressHandler(ui_ntxtSymbol.Text, e, clsEnums.TextType.AlphaNumeric, 20, 0);
        }

        private void ui_ntxtSource_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsGlobal.KeyPressHandler(ui_ntxtSource.Text, e, clsEnums.TextType.AlphaNumeric, 20, 0);
        }

        private void ui_ntxtSellSideTurnover_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
            else
                clsGlobal.KeyPressHandler(ui_ntxtSellSideTurnover.Text, e, clsEnums.TextType.Real, 18, 2);
        }

        private void ui_ntxtBuySideTurnover_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
            else
                clsGlobal.KeyPressHandler(ui_ntxtBuySideTurnover.Text, e, clsEnums.TextType.Real, 18, 2);
        }

        private void ui_ntxtMaximumLots_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
            if (ui_ntxtMaximumLots.Text == string.Empty || ui_ntxtMaximumLots.Text == "0")
                ui_ncmbMaxLotsUnit.SelectedIndex = ui_ncmbMaxLotsUnit.Items.IndexOf("");
        }

        private void ui_ntxtMarketLot_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
            if (ui_ntxtMarketLot.Text == string.Empty || ui_ntxtMarketLot.Text == "0")
                ui_ncmbMarketLotsUnit.SelectedIndex = ui_ncmbMarketLotsUnit.Items.IndexOf("");
        }

        private void ui_ntxtQuotationBaseValue_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
            if (ui_ntxtQuotationBaseValue.Text == string.Empty || ui_ntxtQuotationBaseValue.Text == "0")
                ui_ncmbBaseValueUnit.SelectedIndex = ui_ncmbBaseValueUnit.Items.IndexOf("");
        }

        private void SetValue(object sender, EventArgs e)
        {
            if (((NTextBox)sender).Text != string.Empty)
            {
                int value = Convert.ToInt32(((NTextBox)sender).Text);
                int NewValue = value.ToString("D").Length + 0;
                ((NTextBox)sender).Text = value.ToString("D" + NewValue.ToString());
            }
        }
        private void ui_ntxtMaximumOrderValue_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtMaximumAllowablePosition_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtInitialSellMargin_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtInitialSellMargin.Text != string.Empty)
            {
                if (Convert.ToInt32(ui_ntxtInitialSellMargin.Text) > 100 || Convert.ToInt32(ui_ntxtInitialSellMargin.Text) < 0)
                {
                    ui_ntxtInitialSellMargin.Text = "0";
                    clsDialogBox.ShowErrorBox("Initial Sell Margin must be between 0 to 100", "Contract Information Error", true);
                    return;
                }
            }
            SetValue(sender, e);
        }

        private void ui_ntxtInitialBuyMargin_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtInitialBuyMargin.Text != string.Empty)
            {
                if (Convert.ToInt32(ui_ntxtInitialBuyMargin.Text) > 100 || Convert.ToInt32(ui_ntxtInitialBuyMargin.Text) < 0)
                {
                    ui_ntxtInitialBuyMargin.Text = "0";
                    clsDialogBox.ShowErrorBox("Initial Buy Margin must be between 0 to 100", "Contract Information Error", true);
                    return;
                }
            }
            SetValue(sender, e);
        }

        private void ui_ntxtMaintenanceBuyMargin_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtMaintenanceBuyMargin.Text != string.Empty)
            {
                if (Convert.ToInt32(ui_ntxtMaintenanceBuyMargin.Text) > 100 || Convert.ToInt32(ui_ntxtMaintenanceBuyMargin.Text) < 0)
                {
                    ui_ntxtMaintenanceBuyMargin.Text = "0";
                    clsDialogBox.ShowErrorBox("Maintenance Buy Margin must be between 0 to 100", "Contract Information Error", true);
                    return;
                }
            }
            SetValue(sender, e);
        }

        private void ui_ntxtMaintenanceSellMargin_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtMaintenanceSellMargin.Text != string.Empty)
            {
                if (Convert.ToInt32(ui_ntxtMaintenanceSellMargin.Text) > 100 || Convert.ToInt32(ui_ntxtMaintenanceSellMargin.Text) < 0)
                {
                    ui_ntxtMaintenanceSellMargin.Text = "0";
                    clsDialogBox.ShowErrorBox("Maintenance Sell Margin must be between 0 to 100", "Contract Information Error", true);
                    return;
                }
            }
            SetValue(sender, e);
        }

        private void ui_ntxtDPRInitialPercentage_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtLimtStopLevel_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtContractSize_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtTickPrice_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtTickSize_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtDeliveryQuantity_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtDPRRangeHigher_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtHedged_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtDPRInterval_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ntxtDigits_Leave(object sender, EventArgs e)
        {
            SetValue(sender, e);
        }

        private void ui_ncmbMaxLotsUnit_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtMaximumLots.Text == string.Empty || ui_ntxtMaximumLots.Text == "0")
                ui_ncmbMaxLotsUnit.SelectedIndex = ui_ncmbMaxLotsUnit.Items.IndexOf("");
        }

        private void ui_ncmbMarketLotsUnit_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtMarketLot.Text == string.Empty || ui_ntxtMarketLot.Text == "0")
                ui_ncmbMarketLotsUnit.SelectedIndex = ui_ncmbMarketLotsUnit.Items.IndexOf("");

        }

        private void ui_ncmbBaseValueUnit_Leave(object sender, EventArgs e)
        {
            if (ui_ntxtQuotationBaseValue.Text == string.Empty || ui_ntxtQuotationBaseValue.Text == "0")
                ui_ncmbBaseValueUnit.SelectedIndex = ui_ncmbBaseValueUnit.Items.IndexOf("");
        }

        public void HandleDateTimePickerInvoke(NDateTimePicker dateTimePicker)
        {
            MouseEventArgs cc = new MouseEventArgs(MouseButtons.Left, 1, 204, 8, 0);
            Int32 x = dateTimePicker.Width - 10;
            Int32 y = dateTimePicker.Height / 2;
            Int32 lParam = x + y * 0x00010000;
            SendMessage(dateTimePicker.Handle, WM_LBUTTONDOWN, 1, lParam);
            SendMessage(dateTimePicker.Handle, WM_LBUTTONUP, 1, lParam);
        }

        private void nButton7_Click(object sender, EventArgs e)
        {
            HandleDateTimePickerInvoke(ui_ndtpTenderStartDate);
        }

        private void nButton6_Click(object sender, EventArgs e)
        {
            HandleDateTimePickerInvoke(ui_ndtpDeliveryStartDate);
        }

        private void nButton1_Click(object sender, EventArgs e)
        {
            HandleDateTimePickerInvoke(ui_ndtpExpiryDate);
        }

        private void nButton4_Click(object sender, EventArgs e)
        {
            HandleDateTimePickerInvoke(ui_ndtpStartDate);
        }

        private void nButton3_Click(object sender, EventArgs e)
        {
            HandleDateTimePickerInvoke(ui_ndtpEndDate);
        }

        private void nButton2_Click(object sender, EventArgs e)
        {
            HandleDateTimePickerInvoke(ui_ndtpTenderEndDate);
        }

        private void nButton5_Click(object sender, EventArgs e)
        {
            HandleDateTimePickerInvoke(ui_ndtpDeliveryEndDate);
        }

    }
}
