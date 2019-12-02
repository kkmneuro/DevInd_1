﻿///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//27/01/2012	VP		    1.Code for localization in the control
//02/02/2012	VP		    1.Commenting of the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    /// <summary>
    /// ContractInformation control code
    /// </summary>
    public partial class UctlContractInformation : UctlBase
    {
        private string _title = "Contract Information";

        public UctlContractInformation()
        {
            Title = "Contract Information";
            InitializeComponent();
        }

        public string SelectedInstrumentId { get; set; }

        public string Symbol
        {
            get { return ui_ntxtConract.Text; }
            set { ui_ntxtConract.Text = value; }
        }

        public string ProductType
        {
            get
            {
                if (ui_nCmbProductTypes.SelectedItem != null)
                    return ui_nCmbProductTypes.SelectedItem.ToString();
                else
                    return string.Empty;
            }
            set { ui_nCmbProductTypes.Text = value; }
        }

        public new string ProductName
        {
            get
            {
                if (ui_nCmbProducts.SelectedItem != null)
                    return ui_nCmbProducts.SelectedItem.ToString();
                else
                    return string.Empty;
            }
            set { ui_nCmbProducts.Text = value; }
        }

        public string ExpiryDate
        {
            get
            {
                if (ui_nCmbExpiryDates.SelectedItem != null)
                    return ui_nCmbExpiryDates.SelectedItem.ToString();
                else
                    return string.Empty;
            }
            set { ui_nCmbExpiryDates.Text = value; }
        }

        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            ui_lblInstName.Text = ClsLocalizationHandler.Instrument + " " + ClsLocalizationHandler.Name;
            ui_lblContract.Text = ClsLocalizationHandler.Symbol;
            ui_lblSeries.Text = ClsLocalizationHandler.Series;
            ui_lblExpiryDate.Text = ClsLocalizationHandler.Expiry + " " + ClsLocalizationHandler.Date;
            ui_lblStricePrice.Text = ClsLocalizationHandler.Strike + " " + ClsLocalizationHandler.Price;
            ui_lblOptType.Text = ClsLocalizationHandler.Option + " " + ClsLocalizationHandler.Type;
            ui_lblName.Text = ClsLocalizationHandler.Name;
            ui_lblInfo.Text = ClsLocalizationHandler.Information;
            ui_lblULAsset.Text = "U/L " + ClsLocalizationHandler.Asset;
            ui_lblStartDate.Text = ClsLocalizationHandler.Start + " " + ClsLocalizationHandler.Date;
            ui_lblTradingCurrency.Text = ClsLocalizationHandler.Trading + " " + ClsLocalizationHandler.Currency;
            ui_lblSettingCurrency.Text = ClsLocalizationHandler.Setting + " " + ClsLocalizationHandler.Currency;
            ui_lblDeliveryUnit.Text = ClsLocalizationHandler.Delivery + " " + ClsLocalizationHandler.Unit;
            ui_lblDelivereyQty.Text = ClsLocalizationHandler.Delivery + " " + ClsLocalizationHandler.Quantity;
            ui_lblMarketLot.Text = ClsLocalizationHandler.Market + " " + ClsLocalizationHandler.Lot;
            ui_lblPriceNumerator.Text = ClsLocalizationHandler.Price + " " + ClsLocalizationHandler.Numerator;
            ui_lblPriceDenomenator.Text = ClsLocalizationHandler.Price + " " +
                                          ClsLocalizationHandler.Denomenator;
            ui_lblPriceQuotation.Text = ClsLocalizationHandler.Price + " " + ClsLocalizationHandler.Quotation;
            ui_lblPriceTick.Text = ClsLocalizationHandler.Price + " " + ClsLocalizationHandler.Ticker;
            ui_lblGenNumerator.Text = ClsLocalizationHandler.General + " " + ClsLocalizationHandler.Numerator;
            ui_lblGenDenomenator.Text = ClsLocalizationHandler.General + " " +
                                        ClsLocalizationHandler.Denomenator;
            ui_lblTftStatus.Text = "TFT " + ClsLocalizationHandler.Status;
            ui_lblInitBuyMargin.Text = ClsLocalizationHandler.Initial + " " + ClsLocalizationHandler.Buy + " " +
                                       ClsLocalizationHandler.Margin;
            ui_lblOthBuyMargin.Text = ClsLocalizationHandler.Other + " " + ClsLocalizationHandler.Buy + " " +
                                      ClsLocalizationHandler.Margin;
            ui_lblMaxOrderSize.Text = ClsLocalizationHandler.Maximum + " " + ClsLocalizationHandler.Order + " " +
                                      ClsLocalizationHandler.Size;
            ui_lblDpr.Text = "DPR";
            ui_lblMaintenanceMargin.Text = ClsLocalizationHandler.Life + " " + ClsLocalizationHandler.Time + " " +
                                           ClsLocalizationHandler.Price + " " + ClsLocalizationHandler.Range;
            ui_lblInitSellMargin.Text = ClsLocalizationHandler.Initial + " " + ClsLocalizationHandler.Sell + " " +
                                        ClsLocalizationHandler.Margin;
            ui_lblOthSellMargin.Text = ClsLocalizationHandler.Other + " " + ClsLocalizationHandler.Sell + " " +
                                       ClsLocalizationHandler.Margin;
            ui_lblMaxOrderValue.Text = ClsLocalizationHandler.Maximum + " " + ClsLocalizationHandler.Order + " " +
                                       ClsLocalizationHandler.Value;
            ui_lblIMSpreadBenefit.Text = "IM " + ClsLocalizationHandler.Spread + " " +
                                         ClsLocalizationHandler.Benefit;
            ui_ngbTenderPeriod.Text = ClsLocalizationHandler.Tender + " " + ClsLocalizationHandler.Period;
            ui_lblTenderStartDate.Text = ClsLocalizationHandler.Tender + " " + ClsLocalizationHandler.Start +
                                         " " + ClsLocalizationHandler.Date;
            ui_lblTenderEndDate.Text = ClsLocalizationHandler.Tender + " " + ClsLocalizationHandler.End + " " +
                                       ClsLocalizationHandler.Date;
            ui_ngbDeliveryPeriod.Text = ClsLocalizationHandler.Delivery + " " + ClsLocalizationHandler.Period;
            ui_lblDeliveryStartDate.Text = ClsLocalizationHandler.Delivery + " " + ClsLocalizationHandler.Start +
                                           " " + ClsLocalizationHandler.Date;
            ui_lblDeliveryEndDate.Text = ClsLocalizationHandler.Delivery + " " + ClsLocalizationHandler.End +
                                         " " + ClsLocalizationHandler.Date;
            ui_lblSpecification.Text = ClsLocalizationHandler.Specification;
        }

        /// <summary>
        /// Called on control load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uctlContractInformation_Load(object sender, EventArgs e)
        {
            //SetLocalization();
        }

        /// <summary>
        /// Populates ui_nCmbInstNames combobox items
        /// </summary>
        /// <param name="instNames"></param>
        public void FillProductTypes(string[] instNames)
        {
            ui_nCmbProductTypes.Items.AddRange(instNames);
        }

        public void SetContractInformation(ClsContractInfo cs)
        {
            if (cs != null)
            {
                ui_lblName.Text = cs.ContractName;
                ui_lblProductName.Text = cs.ProductName;
                ui_lblProductInfo.Text = cs.Specification;
                ui_lblAsset.Text = cs.UL_Asset;
                ui_lblTrCurrencyName.Text = cs.TradingCurrency;
                ui_lblSetCurrencyName.Text = cs.SettlingCurrency;
                ui_lblMMargin.Text = Convert.ToString(cs.OtherBuyMargin); //Mantinance buy Margin
                ui_lblOthBuyMar.Text = Convert.ToString(cs.OtherBuyMargin);
                ui_lblOthSellMar.Text = Convert.ToString(cs.OtherSellMargin);
                //instspec.TickSize;
                ui_lblTenderSDate.Text = Convert.ToString(cs.TenderStartDate);
                ui_lblTenderEDate.Text = Convert.ToString(cs.TenderEndDate);
                ui_lblSDate.Text = Convert.ToString(cs.StartDate);
                //ui_lbls instspec.SpreadByDefault;
                //ui_lbl instspec.SpreadBalance;
                //ui_lbl instspec.ShortPositions;
                //ui_lbl instspec.SettlingCurrency;
                //ui_lbl instspec.QuotationBaseValue;
                //ui_lbl instspec.SellSideTurnover;
                ui_lblPTick.Text = Convert.ToString(cs.PriceTick);
                ui_lblPriceQuotation.Text = Convert.ToString(cs.PriceQuantity);
                ui_lblPriceNum.Text = Convert.ToString(cs.PriceNumerator);
                ui_lblPriceDeno.Text = Convert.ToString(cs.PriceDenominator);
                //ui_lbl instspec.Percentage;
                //ui_lbl instspec.Orders;
                ui_lblDprValue.Text = cs.MinDPR + "-" + cs.MaxDPR;
                ui_lblLotUnit.Text = Convert.ToString(cs.MarketLot);
                //ui_lbl instspec.MarginCurrency;
                //ui_lbl instspec.Limit_Stop_Level;
                ui_lblInitSellMar.Text = Convert.ToString(cs.InitialSellMargin);
                ui_lblInitBuyMar.Text = Convert.ToString(cs.InitialBuyMargin);
                //ui_lblh instspec.Hedged;
                ui_lblGenDeno.Text = Convert.ToString(cs.GeneralDenominator);
                ui_lblGenNum.Text = Convert.ToString(cs.GeneralNumerator);
                //ui_lbl =instspec.ExpiryDate;
                //ui_lblEDate.Text = clsUtility. (cs.EndDate);
                ui_lblDUnit.Text = cs.DeliveryUnit;
                //ui_lbl =instspec.DeliveryType;
                //ui_lbl =instspec.DeliveryStartDate;
                ui_lblDQty.Text = cs.DeliveryQuantity;
                //ui_lbl =instspec.DeliveryEndDate;
                //ui_lbl =instspec.ContractSize;
                //ui_lbl =instspec.BuySideTurnover;
            }
        }

        public void GetContactInformation()
        {
        }

        /// <summary>
        /// Invokes OnSelectedInstChanged click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nCmbInstNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductType = ui_nCmbProductTypes.SelectedItem.ToString();
            OnSelectedInstChanged(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntxtSymbol_Validating(object sender, CancelEventArgs e)
        {
            //OnSymbolValidating(sender, e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntxtSymbol_Validated(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Invokes OnExpiryDateSelected click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nCmbExpiryDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnExpiryDateSelected(sender, e);
        }

        /// <summary>
        /// Invokes OnSymbolTextChanged click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ntxtSymbol_TextChanged(object sender, EventArgs e)
        {
            OnSymbolTextChanged(sender, e);
        }

        /// <summary>
        /// Invokes OnSelectedSeriesChanged click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nCmbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedSeriesChanged(sender, e);
        }

        /// <summary>
        /// Invokes OnSelectedStrikePriceChanged click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nCmbStrikePrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedStrikePriceChanged(sender, e);
        }

        /// <summary>
        /// Invokes OnSelectedOptTypesChanged click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nCmbOptTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedOptTypesChanged(sender, e);
        }


        public void ClearExpiryDates()
        {
            ui_nCmbExpiryDates.Items.Clear();
        }


        public void AddExpiryDate(string expiryDate)
        {
            ui_nCmbExpiryDates.Items.Add(expiryDate);
        }

        private void ui_nCmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductName = ui_nCmbProducts.SelectedItem.ToString();
            OnSelectedProductChanged(sender, e);
        }

        private void ui_nCmbContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_nCmbContracts.SelectedItem != null && ui_nCmbContracts.SelectedItem.ToString() != "--Select--")
                OnSelectedContractChanged(ui_nCmbContracts.SelectedItem.ToString());
        }

        public event Action<string> OnSelectedContractChanged = delegate { };

        private void ui_nCmbContracts_KeyPress(object sender, KeyPressEventArgs e)
        {
            ClsGlobal.KeyPressHandler(ui_nCmbContracts.Text, e, TextType.AlphaNumeric, 50, 1);
        }

        #region    "          EVENTS        "

        public event Action<object, EventArgs> OnSelectedInstChanged = delegate { };
        public event Action<object, EventArgs> OnSymbolValidating = delegate { };
        public event Action<object, EventArgs> OnSymbolValidated = delegate { };
        public event Action<object, EventArgs> OnExpiryDateSelected = delegate { };
        public event Action<object, EventArgs> OnSymbolTextChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedSeriesChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedStrikePriceChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedOptTypesChanged = delegate { };
        public event Action<object, EventArgs> OnSelectedProductChanged = delegate { };

        #endregion "          EVENTS        "
    }
}