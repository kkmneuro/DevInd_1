//<Revision History>

//Date : 04/01/2012
//Author Name : Vijay Prakash Singh
//Description : Added naming conventions and comments in method and properties

//</Revision History>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlForexPair : UctlBase
    {
        #region  "       MEMBERS        "

        private readonly string _key;

        private int MultipliedValue_ = 10000;
        private int RoundOff_ = 4;
        private string _title = "Forex Pair";
        // private double LastBidValue_ = 0.0;
        //private double LastAskValue_ = 0.0;

        private Label lblAskBottomValue_;
        private Label lblAskTopValue_;
        private Label lblAsk_;
        private Label lblBidBottomValue_;
        private Label lblBidTopValue_;
        private Label lblBid_;
        private Label lblPartialPipsAskValue_;
        private Label lblPartialPipsBidValue_;
        private PictureBox picAskArrow_;
        private PictureBox picBidArrow_;
        private string strAmount_;
        private string strSymbol_;

        //bool isOrderSubscriberLogin = false;
        //bool isQuoteSubscriberLogin = false;

        //Cls.clsOrderFunctions OrderUtility_ = new GTS.Cls.clsOrderFunctions();

        #endregion "       MEMBERS        "

        #region    "       PROPERTY       "

        public string Key
        {
            get { return _key; }
        }

        /// <summary>
        /// Sets and gets the title of the ForexPair control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// gets and set the selected symbol value for order
        /// </summary>
        public string Symbol
        {
            get
            {
                if (string.IsNullOrEmpty(strSymbol_))
                {
                    return "Select";
                }
                return strSymbol_;
            }
            set
            {
                if (string.IsNullOrEmpty(strSymbol_))
                {
                    strSymbol_ = ui_nbtnSymbolPair.Text = "Select";
                    return;
                }

                strSymbol_ = ui_nbtnSymbolPair.Text = value;
                ui_nlstSymbolPairList.SelectedItem = strSymbol_;
                //UpdateQuote(QuoteManager.getQuoteManager().getLastQuote(strSymbol_));
            }
        }

        /// <summary>
        /// gets and set the selected amonut value for order
        /// </summary>
        public string Amount
        {
            get
            {
                if (string.IsNullOrEmpty(strAmount_))
                {
                    return "Select";
                }
                return strAmount_;
            }
            set { strAmount_ = value; }
        }

        /// <summary>
        /// gets and set the multiplied value for order
        /// </summary>
        public int MultipliedValue
        {
            get { return MultipliedValue_; }
            set { MultipliedValue_ = value; }
        }

        /// <summary>
        /// gets and set the roundoff value for order
        /// </summary>
        public int RoundOff
        {
            get { return RoundOff_; }
            set { RoundOff_ = value; }
        }

        public int OrderFormSettings { get; set; }
        public int PositionSizeType { get; set; }

        #endregion "       PROPERTY       "

        #region   "        METHODS        "

        /// <summary>
        /// Constructor for initilizing the components of the uctlForexPair 
        /// </summary>
        public UctlForexPair()
        {
            InitializeComponent();
            //ResetToDefaultColorScheme();
        }

        /// <summary>
        /// Creates a ForexPair for a specified given symbol
        /// </summary>
        /// <param name="key"></param>
        /// <param name="symbol"></param>
        public UctlForexPair(string key, string symbol)
        {
            InitializeComponent();
            _key = key;
            strSymbol_ = ui_nbtnSymbolPair.Text = symbol;
        }

        /// <summary>
        /// Constructor for initilizing the components of the uctlForexPair control with customised settings
        /// </summary>
        /// <param name="customizeSettings"></param>
        public UctlForexPair(object customizeSettings)
        {
        }

        #region COLOR_SETTINGS

        //public void setnBtnOrderColorScheme(Color ControlBorder, Color ControlDark, Color ControlLight)
        //{
        //    this.nBtnOrder.Palette.ControlBorder = ControlBorder;
        //    this.nBtnOrder.Palette.ControlDark = ControlDark;
        //    this.nBtnOrder.Palette.ControlLight = ControlLight;
        //}
        //public void setnLeftTypeDecoratorColorScheme(Color ControlBorder, Color ControlDark, Color ControlLight)
        //{
        //    this.nLeftTypeDecorator.Palette.ControlBorder = ControlBorder;
        //    this.nLeftTypeDecorator.Palette.ControlDark = ControlDark;
        //    this.nLeftTypeDecorator.Palette.ControlLight = ControlLight;
        //}
        //public void setnRightTypeDecoratorColorScheme(Color ControlBorder, Color ControlDark, Color ControlLight)
        //{
        //    this.nRightTypeDecorator.Palette.ControlBorder = ControlBorder;
        //    this.nRightTypeDecorator.Palette.ControlDark = ControlDark;
        //    this.nRightTypeDecorator.Palette.ControlLight = ControlLight;
        //}
        //public void setnSpreadDecoratorColorScheme(Color ControlBorder, Color ControlDark, Color ControlLight)
        //{
        //    this.nSpreadDecorator.Palette.ControlBorder = ControlBorder;
        //    this.nSpreadDecorator.Palette.ControlDark = ControlDark;
        //    this.nSpreadDecorator.Palette.ControlLight = ControlLight;
        //}
        //public void setui_nddbAmountColorScheme(Color ControlBorder, Color ControlDark, Color ControlLight)
        //{
        //    this.ui_nddbAmount.Palette.ControlBorder = ControlBorder;
        //    this.ui_nddbAmount.Palette.ControlDark = ControlDark;
        //    this.ui_nddbAmount.Palette.ControlLight = ControlLight;
        //}
        //public void setlblPairNameColorScheme(Color ControlBorder, Color ControlDark, Color ControlLight)
        //{
        //    this.lblPairName.Palette.ControlBorder = ControlBorder;
        //    this.lblPairName.Palette.ControlDark = ControlDark;
        //    this.lblPairName.Palette.ControlLight = ControlLight;
        //}

        //public void setBackColor(Color clr)
        //{
        //    this.BackColor = clr;
        //}

        public void ShowArrowVisibility(bool Visible)
        {
            picLeftArrow.Visible = Visible;
            picRightArrow.Visible = Visible;
        }

        //public void setColorScheme(SettingFormData.structColorScheme[] colorScheme, Color BackColor)
        //{
        //    this.setBackColor(BackColor);
        //    this.setnBtnOrderColorScheme(colorScheme[0].ControlBorder_,
        //        colorScheme[0].ControlDark_, colorScheme[0].ControlLight_);
        //    this.setnLeftTypeDecoratorColorScheme(colorScheme[1].ControlBorder_,
        //        colorScheme[1].ControlDark_, colorScheme[1].ControlLight_);
        //    this.setnRightTypeDecoratorColorScheme(colorScheme[2].ControlBorder_,
        //        colorScheme[2].ControlDark_, colorScheme[2].ControlLight_);
        //    this.setnSpreadDecoratorColorScheme(colorScheme[3].ControlBorder_,
        //        colorScheme[3].ControlDark_, colorScheme[3].ControlLight_);
        //    this.setui_nddbAmountColorScheme(colorScheme[4].ControlBorder_,
        //        colorScheme[4].ControlDark_, colorScheme[4].ControlLight_);
        //    this.setlblPairNameColorScheme(colorScheme[5].ControlBorder_,
        //         colorScheme[5].ControlDark_, colorScheme[5].ControlLight_);
        //}

        //public SettingFormData.structColorScheme[] getColorScheme()
        //{
        //    SettingFormData.structColorScheme[] colorScheme = new SettingFormData.structColorScheme[6];

        //    colorScheme[0].ControlBorder_ = this.nBtnOrder.Palette.ControlBorder;
        //    colorScheme[0].ControlDark_   = this.nBtnOrder.Palette.ControlDark;
        //    colorScheme[0].ControlLight_  = this.nBtnOrder.Palette.ControlLight;


        //    colorScheme[1].ControlBorder_ = this.nLeftTypeDecorator.Palette.ControlBorder;
        //    colorScheme[1].ControlDark_ = this.nLeftTypeDecorator.Palette.ControlDark;
        //    colorScheme[1].ControlLight_ = this.nLeftTypeDecorator.Palette.ControlLight;


        //    colorScheme[2].ControlBorder_ = this.nRightTypeDecorator.Palette.ControlBorder;
        //    colorScheme[2].ControlDark_ = this.nRightTypeDecorator.Palette.ControlDark;
        //    colorScheme[2].ControlLight_ = this.nRightTypeDecorator.Palette.ControlLight;


        //    colorScheme[3].ControlBorder_ = this.nSpreadDecorator.Palette.ControlBorder;
        //    colorScheme[3].ControlDark_ = this.nSpreadDecorator.Palette.ControlDark;
        //    colorScheme[3].ControlLight_ = this.nSpreadDecorator.Palette.ControlLight;


        //    colorScheme[4].ControlBorder_ = this.ui_nddbAmount.Palette.ControlBorder;
        //    colorScheme[4].ControlDark_ = this.ui_nddbAmount.Palette.ControlDark;
        //    colorScheme[4].ControlLight_ = this.ui_nddbAmount.Palette.ControlLight;


        //    colorScheme[5].ControlBorder_ = this.lblPairName.Palette.ControlBorder;
        //    colorScheme[5].ControlDark_ = this.lblPairName.Palette.ControlDark;
        //    colorScheme[5].ControlLight_ = this.lblPairName.Palette.ControlLight;

        //    return colorScheme;

        //}

        public void ResetToDefaultColorScheme()
        {
            BackColor = Color.DodgerBlue;

            //this.nBtnOrder.Palette.ControlBorder = Color.FromArgb(180,180,180);
            nBtnOrder.Palette.ControlBorder = Color.FromArgb(65, 61, 58);
            nBtnOrder.Palette.ControlDark = Color.FromArgb(225, 225, 225);
            nBtnOrder.Palette.ControlLight = Color.FromArgb(255, 255, 255);

            ui_ndctrSell.Palette.ControlBorder = Color.FromArgb(65, 61, 58);
            ui_ndctrSell.Palette.ControlDark = Color.FromArgb(225, 225, 225);
            ui_ndctrSell.Palette.ControlLight = Color.FromArgb(255, 255, 255);

            ui_ndctrBuy.Palette.ControlBorder = Color.FromArgb(65, 61, 58);
            ui_ndctrBuy.Palette.ControlDark = Color.FromArgb(225, 225, 225);
            ui_ndctrBuy.Palette.ControlLight = Color.FromArgb(255, 255, 255);

            nSpreadDecorator.Palette.ControlBorder = Color.FromArgb(65, 61, 58);
            nSpreadDecorator.Palette.ControlDark = Color.FromArgb(225, 225, 225);
            nSpreadDecorator.Palette.ControlLight = Color.FromArgb(255, 255, 255);

            ui_nddbAmount.Palette.ControlBorder = Color.FromArgb(134, 113, 235);
            ui_nddbAmount.Palette.ControlDark = Color.FromArgb(128, 198, 199);
            ui_nddbAmount.Palette.ControlLight = Color.FromArgb(32, 208, 208);

            ui_nbtnSymbolPair.Palette.ControlBorder = Color.FromArgb(180, 180, 180);
            ui_nbtnSymbolPair.Palette.ControlDark = Color.FromArgb(0, 171, 0);
            ui_nbtnSymbolPair.Palette.ControlLight = Color.FromArgb(0, 174, 0);
        }

        #endregion

        /// <summary>
        /// Sets the side for displaying buy and sell decorator( Ask in Left Side and Bid in Right Side )
        /// </summary>
        public void setAskInLeftSide()
        {
            lblTypeLeft.Text = "BUY";
            lblAskTopValue_ = lblTypeTopValueLeft;
            lblAskBottomValue_ = lblTypeBottomValueLeft;
            lblPartialPipsAskValue_ = lblPartialPipsTypeLeft;
            lblAsk_ = lblTypeLeft;
            picAskArrow_ = picLeftArrow;
            btnBuy.FillInfo.Gradient1 = Color.Red;
            btnBuy.FillInfo.Gradient2 = Color.Red;
            btnSell.FillInfo.Gradient1 = Color.FromArgb(0, 204, 0);
            btnSell.FillInfo.Gradient2 = Color.FromArgb(0, 204, 0);
            lblTypeRight.Text = "SELL";
            lblBidTopValue_ = lblTypeTopValueRight;
            lblBidBottomValue_ = lblTypeBottomValueRight;
            lblPartialPipsBidValue_ = lblPartialPipsTypeRight;
            lblBid_ = lblTypeRight;
            picBidArrow_ = picRightArrow;
        }

        /// <summary>
        /// Sets the side for displaying buy and sell decorator ( Ask in Right Side and Bid in Left Side )
        /// </summary>
        public void setAskInRightSide()
        {
            lblTypeRight.Text = "BUY";
            lblAskTopValue_ = lblTypeTopValueRight;
            lblAskBottomValue_ = lblTypeBottomValueRight;
            lblPartialPipsAskValue_ = lblPartialPipsTypeRight;
            lblAsk_ = lblTypeRight;
            picAskArrow_ = picRightArrow;
            btnBuy.FillInfo.Gradient1 = Color.FromArgb(0, 204, 0);
            btnBuy.FillInfo.Gradient2 = Color.FromArgb(0, 204, 0);
            btnSell.FillInfo.Gradient1 = Color.Red;
            btnSell.FillInfo.Gradient2 = Color.Red;
            lblTypeLeft.Text = "SELL";
            lblBidTopValue_ = lblTypeTopValueLeft;
            lblBidBottomValue_ = lblTypeBottomValueLeft;
            lblPartialPipsBidValue_ = lblPartialPipsTypeLeft;
            lblBid_ = lblTypeLeft;
            picBidArrow_ = picLeftArrow;
        }

        /// <summary>
        /// Sets the symbols list to the Dropdown attached with ui_nddbSymbolPair
        /// </summary>
        /// <param name="symbolArray"></param>
        public void setSymbolList(List<string> symbolArray)
        {
            ui_nlstSymbolPairList.Items.Clear();
            ui_nlstSymbolPairList.Items.AddRange(symbolArray.ToArray());
        }

        /// <summary>
        /// Sets the items list to the Dropdown attached with ui_nddbAmount
        /// </summary>
        /// <param name="AmountArray"></param>
        public void setAmountList(string[] AmountArray)
        {
            ui_nlstAmountList.Items.Clear();
            ui_nlstAmountList.Items.AddRange(AmountArray);
        }

        /// <summary>
        /// Sets the symbol for order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstSymbolPairList_MouseClick(object sender, MouseEventArgs e)
        {
            strSymbol_ = ui_nbtnSymbolPair.Text = ui_nlstSymbolPairList.SelectedItem.ToString();

            //UpdateQuote(QuoteManager.getQuoteManager().getLastQuote(strSymbol_));
            ui_nlstSymbolPairList.Visible = false;
            ui_nlstSymbolPairList.Parent.Visible = false;
        }

        private void ctlForexPair_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Sets the amount for order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstAmountList_MouseClick(object sender, MouseEventArgs e)
        {
            strAmount_ = ui_nddbAmount.Text = ui_nlstAmountList.SelectedItem.ToString();

            ui_nlstAmountList.Visible = false;
            ui_nlstAmountList.Parent.Visible = false;
        }

        // delegate void dlg_QuoteUpdate(ProtocolStructs.QuoteResponse quote);
        //public void UpdateQuote(ProtocolStructs.QuoteResponse quote)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke(new dlg_QuoteUpdate(UpdateBidAskValues), quote);
        //    }
        //    else
        //        UpdateBidAskValues(quote);

        //}
        //private void UpdateBidAskValues(ProtocolStructs.QuoteResponse quote)
        //{
        //    long CurrBidSize, CurrAskSize;
        //    double CurreBidPx, CurrAskPx;
        //    double DiffBid, DiffAsk;
        //    DiffBid = DiffAsk = 0.0;
        //    CurrBidSize = CurrAskSize = 0;
        //    CurreBidPx = CurrAskPx = 0.0;

        //    try
        //    {
        //        CurreBidPx = quote.BidPx_;//Math.Round(Convert.ToDouble(quote.strBidPrice_), RoundOff);
        //        CurrBidSize = quote.BidSize_;//Convert.ToInt64(quote.strBidSize_);                
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logger.LogEx(ex, "uctlForex", "UpdateBidAskValues(ProtocolStructs.QuoteResponse quote) Region1");
        //    }

        //    try
        //    {
        //        CurrAskPx = quote.AskPx_;//Math.Round(Convert.ToDouble(quote.strAskPrice_), RoundOff);
        //        CurrAskSize = quote.AskSize_;//Convert.ToInt64(quote.strAskSize_);               
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logger.LogEx(ex, "uctlForex", "UpdateBidAskValues(ProtocolStructs.QuoteResponse quote) Region2");
        //    }

        //    //double spread = (Math.Round((askValue - bidValue), roundTo) * multiplicity).ToString();
        //    double spread = Math.Round((CurrAskPx - CurreBidPx), RoundOff) * MultipliedValue;
        //    lblSpreadVal.Text = spread.ToString();

        //    //DiffAsk = CurrAskPx - LastAskValue_;
        //    // DiffBid = CurreBidPx - LastBidValue_;

        //    //LastBidValue_ = CurreBidPx;
        //    //LastAskValue_ = CurrAskPx;

        //    //if (DiffAsk == 0)
        //    //{
        //    //    picAskArrow_.Image = null;
        //    //}
        //    //else 
        //    if (DiffAsk > 0.0)
        //    {
        //        picAskArrow_.Image = null;
        //        picAskArrow_.Image = ImageList1.Images[0];
        //    }
        //    else
        //    {
        //        picAskArrow_.Image = null;
        //        picAskArrow_.Image = ImageList1.Images[1];
        //    }

        //    //if (DiffBid == 0)
        //    //{
        //    //    picBidArrow_.Image = null;
        //    //}
        //    //else 
        //    if (DiffBid > 0.0)
        //    {
        //        picBidArrow_.Image = null;
        //        picBidArrow_.Image = ImageList1.Images[0];
        //    }
        //    else
        //    {
        //        picBidArrow_.Image = null;
        //        picBidArrow_.Image = ImageList1.Images[1];
        //    }


        //    string strBidValue = CurreBidPx.ToString();
        //    if (strBidValue.Length < 6)
        //    {
        //        strBidValue = strBidValue + "0";
        //    }

        //    lblBidTopValue_.Text = strBidValue.Substring(0, strBidValue.Length - 2);//first
        //    lblBidBottomValue_.Text = strBidValue.Substring(strBidValue.Length - 2);//last two
        //    lblPartialPipsBidValue_.Text = strBidValue.Substring(strBidValue.Length - 1);//last


        //    string strAskValue = CurrAskPx.ToString();
        //    if (strAskValue.Length < 6)
        //    {
        //        strAskValue = strAskValue + "0";
        //    }

        //    lblAskTopValue_.Text = strAskValue.Substring(0, strAskValue.Length - 2);//first
        //    lblAskBottomValue_.Text = strAskValue.Substring(strAskValue.Length - 2);//last two
        //    lblPartialPipsAskValue_.Text = strAskValue.Substring(strAskValue.Length - 1);//last

        //}

        /// <summary>
        /// Handles Sell Decorator click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndctrSell_MouseDown(object sender, MouseEventArgs e)
        {
            //HandleMouseEvent(sender,lblTypeLeft, e);
            string str = lblTypeBottomValueLeft.Text;
            //lblTypeTopValueLeft.Text + lblTypeBottomValueLeft.Text + lblPartialPipsTypeLeft.Text;
            double price = Convert.ToDouble(str);
            HandleOrderButtonClick("SELL", price);
        }

        private void HandleOrderButtonClick(string orderType, double price)
        {
            switch (OrderFormSettings)
            {
                case 1:
                    OpenOrderEntryForm(orderType, price);
                    break;
                case 2:
                    {
                        DialogResult dResult = MessageBox.Show("Are you want to send order");
                        if (dResult == DialogResult.OK)
                        {
                            if (ui_nddbAmount.Text == "select")
                            {
                                MessageBox.Show("Please select quantity");
                                return;
                            }
                            OnOrderSend(ui_nbtnSymbolPair.Text, price, Convert.ToInt32(ui_nddbAmount.Text));
                        }
                    }
                    break;
                case 3:
                    {
                        if (ui_nddbAmount.Text == "select")
                        {
                            MessageBox.Show("Please select quantity");
                            return;
                        }

                        OnOrderSend(ui_nbtnSymbolPair.Text, price, Convert.ToInt32(ui_nddbAmount.Text));
                    }
                    break;
            }
        }

        private void OpenOrderEntryForm(string orderType, double price)
        {
            if (ui_nddbAmount.Text == "select")
            {
                MessageBox.Show("Please select quantity");
                return;
            }

            OnOrderEntryDialogOpen(orderType, price, Convert.ToDouble(ui_nddbAmount.Text));
            //frmDialogForm objfrmDialogForm = new frmDialogForm();
            //uctlOrderEntry objuctlOrderEntry = new uctlOrderEntry();
            //objfrmDialogForm.Controls.Clear();
            //objfrmDialogForm.Size=new Size(objuctlOrderEntry.Width+30,objuctlOrderEntry.Height+45);
            //objfrmDialogForm.Controls.Add(objuctlOrderEntry);
            //objfrmDialogForm.MdiParent = this.ParentForm.ParentForm;
            //objfrmDialogForm.Show();
        }

        /// <summary>
        /// Handles Buy Decorator click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndctrBuy_MouseDown(object sender, MouseEventArgs e)
        {
            string str = lblTypeBottomValueRight.Text;
            //lblTypeTopValueRight.Text + lblTypeBottomValueRight.Text + lblPartialPipsTypeRight.Text;
            double price = Convert.ToDouble(str);
            HandleOrderButtonClick("BUY", price);
            //HandleMouseEvent( sender,lblTypeRight,  e);           
        }

        /// <summary>
        /// handles the click event on the buy & sell decorator
        /// </summary>
        /// <param name="sender">Event trigger information</param>
        /// <param name="lbl">Buy or Sell</param>
        /// <param name="e">information of the event</param>
        private void HandleMouseEvent(object sender, Label lbl, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (lbl.Text == "BUY")
                {
                    //if (((uctlForex)this.Parent).isBuyOnSingleClick)
                    {
                        onClickBuy();
                    }
                }
                else
                {
                    //if (((uctlForex)this.Parent).isSellOnSingleClick)
                    {
                        onClickSell();
                    }
                }
            }
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (lbl.Text == "BUY")
                {
                    if (!((UctlForex) Parent).isBuyOnSingleClick)
                    {
                        onClickBuy();
                    }
                }
                else
                {
                    if (!((UctlForex) Parent).isSellOnSingleClick)
                    {
                        onClickSell();
                    }
                }
            }
        }

        /// <summary>
        /// For sending buy order
        /// </summary>
        private void onClickBuy()
        {
            double Volume = 0.0;
            //double SL = 0.0;
            //double TP = 0.0;
            //var isInLot = false;
            string strQuantity = string.Empty;
            //OrderUtility_.GetOrderDefaultType(strSymbol_, out strQuantity, out SL, out TP, out isInLot, Side.BUY);
            if (!ui_nddbAmount.Text.Equals("select", StringComparison.OrdinalIgnoreCase))
            {
                strQuantity = ui_nddbAmount.Text;
            }
            Volume = Convert.ToDouble(strQuantity);
            //if (isInLot)
            //{
            //    //Volume = OrderManager.getOrderManager().GetQuantityInAmount(Volume);
            //}
            if (
                MessageBox.Show("Buy " + Volume + " " + strSymbol_ + " at Market Price?", "Confirm New Order",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // OrderUtility_.PlaceMarketOrder(strSymbol_, Side.BUY, Volume, SL, TP);
            }
        }

        /// <summary>
        /// For sending sell order
        /// </summary>
        private void onClickSell()
        {
            double Volume = 0.0;
            //bool isInLot = false;
            string strQuantity = string.Empty;
            //OrderUtility_.GetOrderDefaultType(strSymbol_, out strQuantity, out SL, out TP, out isInLot, Side.SELL);
            if (!ui_nddbAmount.Text.Equals("select", StringComparison.OrdinalIgnoreCase))
            {
                strQuantity = ui_nddbAmount.Text;
            }
            Volume = Convert.ToDouble(strQuantity);
            //if (isInLot)
            //{
            //    //Volume = OrderManager.getOrderManager().GetQuantityInAmount(Volume);
            //}
            if (
                MessageBox.Show("Sell " + Volume + " " + strSymbol_ + " at Market Price?", "Confirm New Order",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //OrderUtility_.PlaceMarketOrder(strSymbol_, Side.SELL, Volume, SL, TP);
            }
        }

        /// <summary>
        /// For opening of Order Entry Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nBtnOrder_Click(object sender, EventArgs e)
        {
            //OrderUtility_.ShowOrderEntryForm(strSymbol_);
        }

        /// <summary>
        /// Sets the text of the controls corresponding the localize value
        /// </summary>
        public override void SetLocalization()
        {
            Title = ClsLocalizationHandler.Forex + " " + ClsLocalizationHandler.Pair;
        }

        #endregion "       METHODS      "

        //To place market order for gold sell side 12-oct-2010 by sauarbh
        //private void PlaceMarketOrder(string symbol, Side BuySell, double Volume, double StopLoss, double TakeProfit)
        //{
        //    isOrderSubscriberLogin = OrderManager.getOrderManager().isServerConnected;
        //    isQuoteSubscriberLogin = QuoteManager.getQuoteManager().isServerConnected;
        //    if (!(isOrderSubscriberLogin && isQuoteSubscriberLogin))
        //    {
        //        MessageBox.Show("No Server Connected", "Servers Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    if (OrderManager.getOrderManager().ActiveAccountID_ == null)
        //    {
        //        MessageBox.Show("No Active Account", "Servers Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }
        //    double Price = 0;

        //    QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(symbol);            
        //    if (BuySell == Side.BUY)
        //    {
        //        Price = QR.BidPx_;

        //    }
        //    else
        //    {
        //        Price = QR.AskPx_;

        //    }


        //    if (Initializer.GetReference().objSettingForm_.bisPositionSizeInLot_)
        //    {
        //        Volume = OrderManager.getOrderManager().GetQuantityInAmount(Volume);
        //    }
        //    Side buysell = BuySell;

        //    clsInterface4OME.OrderType orderType = clsInterface4OME.OrderType.MARKET;
        //    TIF tif = TIF.GTC;
        //    clsInterface4OME.OrderStatus orderStatus = clsInterface4OME.OrderStatus.NEW;

        //    long serverOrderID = 0;
        //    string Reason = string.Empty;
        //    Reason = OrderManager.getOrderManager().
        //             CreateNewOrder(buysell, Price, symbol,
        //                            Convert.ToInt32(Volume), StopLoss,
        //                            TakeProfit, orderType, tif, orderStatus, 
        //                            OrderRequestType.NEW, serverOrderID);            
        //    if (!string.IsNullOrEmpty(Reason))
        //    {
        //        MessageBox.Show(Reason,"Order Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
        //    }

        //}

        public void UpdateForexPair(ClsUpdatePrice updatePrice)
        {
            Action A = () =>
                           {
                               lblTypeTopValueRight.Text = updatePrice.BuyPrice.ToString("0.00000").Substring(0, 4);
                               lblTypeBottomValueRight.Text = updatePrice.BuyPrice.ToString("0.000");
                               //updatePrice.BuyPrice.ToString("0.00000").Substring(4, 2);
                               lblPartialPipsTypeRight.Text = updatePrice.BuyPrice.ToString("0.00000").Substring(6, 1);
                               lblTypeTopValueLeft.Text = updatePrice.SellPrice.ToString("0.00000").Substring(0, 4);
                               lblTypeBottomValueLeft.Text = updatePrice.SellPrice.ToString("0.000");
                               //updatePrice.SellPrice.ToString("0.00000").Substring(4, 2);
                               lblPartialPipsTypeLeft.Text = updatePrice.SellPrice.ToString("0.00000").Substring(6, 1);

                               lblSpreadVal.Text = (updatePrice.SellPrice - updatePrice.BuyPrice).ToString();
                               ui_ndctrBuy.FillInfo.Gradient1 = updatePrice.BuyColor;
                               ui_ndctrBuy.FillInfo.Gradient2 = updatePrice.BuyColor;
                               ui_ndctrSell.FillInfo.Gradient1 = updatePrice.SellColor;
                               ui_ndctrSell.FillInfo.Gradient2 = updatePrice.SellColor;
                               picRightArrow.ImageLocation = updatePrice.BuyImagePath;
                               picLeftArrow.ImageLocation = updatePrice.SellImagePath;
                           };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public event Action<string, double, double> OnOrderEntryDialogOpen;
        public event Action<string, double, int> OnOrderSend;
    }
}