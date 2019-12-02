using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlQuickOrderButton : UctlBase
    {
        string _controlKey = string.Empty;
        bool _isShowConfirmationDialog = false;
        List<string> _lstOrderSize = new List<string>();
        int _crtOrderSizeNo=0;
        string _orderSize = string.Empty;
        double _crtOrderPrice;
        //double _previousBuyPrice;
        //double _previousSellPrice;
        private string _title = "Forex Pair";
        Image up =null;
        Image down =null;
        #region "  PROPERTY   "

        public string Key
        {
            get
            {
                return _controlKey;
            }
            set
            {
                _controlKey = value;
            }
        }

        public string Symbol
        {
            get
            {
                return ui_lblSymbolName.Text;
            }
            set
            {
                ui_lblSymbolName.Text = value;
            }
        }
        /// <summary>
        /// Sets and gets the title of the ForexPair control
        /// </summary>
        public override string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public List<string> SizeList
        {
            get
            {
                return _lstOrderSize;
            }
            set
            {
                _lstOrderSize = value;
            }
        }

        public string InitialOrdersize
        {
            set
            {
                ui_nbtnOrderSize.Text = value;
            }
        }

        public bool IsShowConfirmationDialog
        {
            get
            {
               return _isShowConfirmationDialog;
            }
            set
            {
                _isShowConfirmationDialog = value;
            }
        }

        public string CurrentAccount
        {
            get
            {
                return ui_nbtnCurrAccountNo.Text;
            }
            set
            {
                ui_nbtnCurrAccountNo.Text = value;
            }
        }

        public string OrderSize1
        {
            get
            {
               return  ui_nbtnOrderSize1.Text;
            }
            set
            {
                ui_nbtnOrderSize1.Text = value;
            }
        }

        public string OrderSize2
        {
            get
            {
                return ui_nbtnOrderSize2.Text;
            }
            set
            {
                ui_nbtnOrderSize2.Text = value;
            }
        }

        public string OrderSize3
        {
            get
            {
                return ui_nbtnOrderSize3.Text;
            }
            set
            {
                ui_nbtnOrderSize3.Text = value;
            }
        }

        public string OrderSize4
        {
            get
            {
                return ui_nbtnOrderSize4.Text;
            }
            set
            {
                ui_nbtnOrderSize4.Text = value;
            }
        }

        #endregion "  PROPERTY   "

        #region "     METHODS     "

        public void SetBuyColor(Color bColor)
        {
             Action A=()=>
                {
                };
            if(this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public void SetSellColor(Color bColor)
        {
             Action A=()=>
                {
                };
            if(this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public void SetProfitLoss(int pl)
        {
            ui_lblOpenPLValue.Text=pl.ToString();
        }

        public void SetPCT(double pct)
        {
            ui_lblPctValue.Text=pct.ToString();
        }

        public void SetPosition(int position)
        {
            ui_lblPositionValue.Text=position.ToString();
        }

        public void SetAveragePrice(double avgPrice)
        {
            ui_lblAvgPriceValue.Text=avgPrice.ToString();
        }

        public void SetSymbolHighValue(double hValue)
        {
            Action A=()=>
                {
                    ui_lblHighValue.Text = hValue.ToString();
                };
            if(this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public void SetSymbolLowValue(double lValue)
        {
            Action A=()=>
                {
                    ui_lblLowValue.Text = lValue.ToString();
                };
            if(this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public void SetBuyArrow(string updown)
        {
            Action A=()=>
                {
                };
            if(this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

         public void SetSellArrow(string updown)
        {
             Action A=()=>
                {
                };
            if(this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public void SetCurrentAccount(string value)
        {
            ui_nbtnCurrAccountNo.Text=value;
        }

        public void UpdateBuyValue(double bValue)
        {
            Action A=()=>
                {

                };
            if(this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public void UpdateSellValue(double sValue)
        {
            Action A=()=>
                {

                };
            if(this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        public uctlQuickOrderButton()
        {
            InitializeComponent();

        }

        public uctlQuickOrderButton(string key,string symbol)
        {
            InitializeComponent();
            up = Properties.Resources.up;
            down = Properties.Resources.down;
            string[] x={"1", "5", "10", "15", "30", "50", "100", "200"};
            _lstOrderSize.AddRange(x);
            this.Key = key;
            this.Symbol = symbol;
            this.InitialOrdersize = "1";
            //ui_nbtnOrderSize1.Palette = this.nuiPanel1.Palette;
            //ui_nbtnOrderSize2.Palette = this.nuiPanel1.Palette;
            //ui_nbtnOrderSize3.Palette = this.nuiPanel1.Palette;
            //ui_nbtnOrderSize4.Palette = this.nuiPanel1.Palette;
            //ui_nbtnCurrAccountNo.Palette = this.nuiPanel1.Palette;
            //ui_nbtnOrderSize.Palette = this.nuiPanel1.Palette;
            //ui_nbtnSizeUp.Palette = this.nuiPanel1.Palette;
            //ui_btnSizeDown.Palette = this.nuiPanel1.Palette;
            //By Kuldeep
            ui_lblAveragePrice.Visible = false;
            ui_lblAvgPriceValue.Visible = false;
            ui_lblOpenPL.Visible = false;
            ui_lblOpenPLValue.Visible = false;
            ui_lblPct.Visible = false;
            ui_lblPctValue.Visible = false;
            ui_lblPosition.Visible = false;
            ui_lblPositionValue.Visible = false;
            
        }

        private void ui_ndtrBuyButton_Click(object sender, EventArgs e)
        {
            _crtOrderPrice = Convert.ToDouble(ui_lblBuyPriceLeft.Text.Trim() + ui_lblBuyPriceMiddle.Text.Trim() + ui_lblBuyPriceRight.Text.Trim());

            SendOrder(OrderTypes.BUY, "Buy");
        }

        //private bool sendOrder = false;
        private bool DispalyOrderConfirmationDialog(OrderTypes orderType, string Side)
        {
            //return false;
            //OrderSide side = (OrderSide)Enum.Parse(typeof(OrderSide), Side, true);
            //frmConfirm confirm = new frmConfirm("send", side, ui_nbtnOrderSize.Text, ui_lblSymbolName.Text, _crtOrderPrice.ToString(), orderType.ToString(), "", ui_nbtnCurrAccountNo.Text);

            //if (confirm.ShowDialog() == DialogResult.OK)
            //{
            //    sendOrder = confirm._isDisplay;

            //    //ResetALL();
            //    return sendOrder;
            //}
            //else if (confirm.DialogResult == DialogResult.Cancel)
            //{
            //    sendOrder = false;
            //    return sendOrder;
            //}
            return false;
            //if (_orderSize == string.Empty)
            //{
            //    _orderSize = ui_nbtnOrderSize.Text;
            //}
            //frmOrderConfirmation objfrmOrderConfirmation = new frmOrderConfirmation();
            //objfrmOrderConfirmation.Message="Are you want to send order of AccountNo :"+ui_nbtnCurrAccountNo.Text+", OrderSize :"+_orderSize+
            //    ", Price :"+_crtOrderPrice+"? click ok to confirm";
            //objfrmOrderConfirmation.OnOkClick += new Action(objfrmOrderConfirmation_OnOkClick);
            //objfrmOrderConfirmation.OnCancelClick += new Action(objfrmOrderConfirmation_OnCancelClick);
            //objfrmOrderConfirmation.ShowDialog();
            //return sendOrder;
        }

        void objfrmOrderConfirmation_OnCancelClick()
        {
            //sendOrder = false;
        }

        void objfrmOrderConfirmation_OnOkClick()
        {
            //sendOrder = true;
        }

        private void ui_ndtrSellButton_Click(object sender, EventArgs e)
        {
            _crtOrderPrice = Convert.ToDouble(ui_lblSellPriceLeft.Text.Trim() + ui_lblSellPriceMiddle.Text.Trim() + ui_lblSellPriceRight.Text.Trim());

            SendOrder(OrderTypes.SELL,"Sell");
        }

        private void ui_btnSellMkt_Click(object sender, EventArgs e)
        {
            //_crtOrderPrice = Convert.ToDouble(ui_lblSellPriceLeft.Text.Trim() + ui_lblSellPriceMiddle.Text.Trim() + ui_lblSellPriceRight.Text.Trim());

            SendOrder(OrderTypes.SELL_MARKET, "Sell");
        }

        private void ui_nbtnBuyMkt_Click(object sender, EventArgs e)
        {
            //_crtOrderPrice = Convert.ToDouble(ui_lblBuyPriceLeft.Text.Trim() + ui_lblBuyPriceMiddle.Text.Trim() + ui_lblBuyPriceRight.Text.Trim());

            SendOrder(OrderTypes.BUY_MARKET, "Buy");
        }

        #endregion "     METHODS     "

        #region "   EVENTS    "

        public event Action<string,string,double,double> OnBuyClick=delegate{};
        public event Action<string, string, double, double> OnSellClick = delegate { };
        public event Action<string, string, double, double> OnBuyMarketClick = delegate { };
        public event Action<string, string, double, double> OnSellMarketClick = delegate { };
        public event Action OnCloseClick = delegate { };

        #endregion "   EVENTS    "

        private void ui_nbtnSizeUp_Click(object sender, EventArgs e)
        {
            _orderSize = string.Empty;

            if (_crtOrderSizeNo == _lstOrderSize.Count-1)
            {
                return;
            }
            _crtOrderSizeNo = _crtOrderSizeNo + 1;
            if(_lstOrderSize.Count>=_crtOrderSizeNo)
                ui_nbtnOrderSize.Text = _lstOrderSize[_crtOrderSizeNo].ToString();//_crtOrderSizeNo++].ToString();
        }

        private void ui_btnSizeDown_Click(object sender, EventArgs e)
        {
             _orderSize = string.Empty;

            if(_crtOrderSizeNo==0)
            {
                return;
            }
            ui_nbtnOrderSize.Text=_lstOrderSize[--_crtOrderSizeNo].ToString();
        }

        private void ui_lblSellPriceMiddle_Click(object sender, EventArgs e)
        {
            //frmQOrder frm = new frmQOrder(this, false, "Limit");
            //frm.Show();
            ////ui_ndtrSellButton_Click(null, null);
        }

        private void ui_lblSell_Click(object sender, EventArgs e)
        {
            //frmQOrder frm = new frmQOrder(this, false, "Limit");
            //frm.Show();
            ////ui_ndtrSellButton_Click(null, null);
        }

        private void ui_lblSellPriceRight_Click(object sender, EventArgs e)
        {
            //frmQOrder frm = new frmQOrder(this, false, "Limit");
            //frm.Show();
            ////ui_ndtrSellButton_Click(null, null);
        }

        private void ui_lblSellPriceLeft_Click(object sender, EventArgs e)
        {
            //frmQOrder frm = new frmQOrder(this, false, "Limit");
            //frm.Show();
            ////ui_ndtrSellButton_Click(null, null);
        }

        private void ui_pbSellArrow_Click(object sender, EventArgs e)
        {
            //frmQOrder frm = new frmQOrder(this, false, "Limit");
            //frm.Show();
            ////ui_ndtrSellButton_Click(null, null);
        }

        private void ui_lblBuyPriceMiddle_Click(object sender, EventArgs e)
        {
           // frmQOrder frm = new frmQOrder(this, true, "Limit");
           // frm.Show();
           //// ui_ndtrSellButton_Click(null, null);
        }

        private void ui_lblBuy_Click(object sender, EventArgs e)
        {
            //frmQOrder frm = new frmQOrder(this, true, "Limit");
            //frm.Show();
            ////ui_ndtrSellButton_Click(null, null);
        }

        private void ui_lblBuyPriceRight_Click(object sender, EventArgs e)
        {
            //frmQOrder frm = new frmQOrder(this, true, "Limit");
            //frm.Show();
            ////ui_ndtrSellButton_Click(null, null);
        }

        private void ui_pbBuyArrow_Click(object sender, EventArgs e)
        {
           // frmQOrder frm = new frmQOrder(this, true, "Limit");
           // frm.Show();
           //// ui_ndtrSellButton_Click(null, null);
        }

        private void ui_lblBuyPriceLeft_Click(object sender, EventArgs e)
        {
            //frmQOrder frm = new frmQOrder(this, true, "Limit");
            //frm.Show();
           //// ui_ndtrSellButton_Click(null, null);
        }

        public void SendOrder(OrderTypes orderType, string side)
        {
            if (_isShowConfirmationDialog)
            {
                bool flag = DispalyOrderConfirmationDialog(orderType, side);
                if (flag)
                {
                    SendOrderofSpecificType(orderType);
                }
            }
            else
            {
                SendOrderofSpecificType(orderType);
            }
        }

        public void SendOrderofSpecificType(OrderTypes orderType)
        {
            if (_orderSize == string.Empty)
            {
                _orderSize = ui_nbtnOrderSize.Text;
            }

            switch (orderType)
            {
                case OrderTypes.BUY:
                    {
                        string[] orderSize = _orderSize.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                         string x =ui_lblBuyPriceLeft.Text.Trim() + ui_lblBuyPriceMiddle.Text.Trim() + ui_lblBuyPriceRight.Text.Trim();
                         if (x != string.Empty)
                         {
                             double _crtBuyPrice = Convert.ToDouble(ui_lblBuyPriceLeft.Text.Trim() + ui_lblBuyPriceMiddle.Text.Trim() + ui_lblBuyPriceRight.Text.Trim());
                             OnBuyClick(this.Key, ui_nbtnCurrAccountNo.Text, _crtBuyPrice, Convert.ToInt32(ui_nbtnOrderSize.Text)); //Convert.ToInt32(orderSize[0] + orderSize[1].Trim()));
                         }
                    }
                    break;
                case OrderTypes.SELL:
                    {
                        string[] orderSize = ui_nbtnOrderSize.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string x = ui_lblSellPriceLeft.Text.Trim() + ui_lblSellPriceMiddle.Text.Trim() + ui_lblSellPriceRight.Text.Trim();
                         if (x != string.Empty)
                         {
                             double _crtSellPrice = Convert.ToDouble(ui_lblSellPriceLeft.Text.Trim() + ui_lblSellPriceMiddle.Text.Trim() + ui_lblSellPriceRight.Text.Trim());
                             OnSellClick(this.Key, ui_nbtnCurrAccountNo.Text, _crtSellPrice, Convert.ToInt32(ui_nbtnOrderSize.Text));// Convert.ToInt32(orderSize[0] + orderSize[1].Trim()));
                         }
                    }
                    break;
                case OrderTypes.BUY_MARKET:
                    {
                        string[] orderSize = ui_nbtnOrderSize.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                         string x = ui_lblBuyPriceLeft.Text.Trim() + ui_lblBuyPriceMiddle.Text.Trim() + ui_lblBuyPriceRight.Text.Trim();
                         if (x != string.Empty)
                         {
                             double _crtBuyPrice = Convert.ToDouble(ui_lblBuyPriceLeft.Text.Trim() + ui_lblBuyPriceMiddle.Text.Trim() + ui_lblBuyPriceRight.Text.Trim());
                             OnBuyMarketClick(this.Key, ui_nbtnCurrAccountNo.Text, _crtBuyPrice, Convert.ToInt32(ui_nbtnOrderSize.Text));//Convert.ToInt32(orderSize[0] + orderSize[1].Trim()));
                         }
                    }
                    break;
                case OrderTypes.SELL_MARKET:
                    {
                        string[] orderSize = ui_nbtnOrderSize.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string x = ui_lblSellPriceLeft.Text.Trim() + ui_lblSellPriceMiddle.Text.Trim() + ui_lblSellPriceRight.Text.Trim();
                        if (x != string.Empty)
                        {
                            double _crtSellPrice = Convert.ToDouble(ui_lblSellPriceLeft.Text.Trim() + ui_lblSellPriceMiddle.Text.Trim() + ui_lblSellPriceRight.Text.Trim());
                            OnSellMarketClick(this.Key, ui_nbtnCurrAccountNo.Text, _crtSellPrice, Convert.ToInt32(ui_nbtnOrderSize.Text));//Convert.ToInt32(orderSize[0] + orderSize[1].Trim()));
                        }
                    }
                    break;
            }
        }

        private void ui_nbtnOrderSize4_Click(object sender, EventArgs e)
        {
            _orderSize = ui_nbtnOrderSize4.Text;
            ui_nbtnOrderSize.Text = ui_nbtnOrderSize4.Text;
        }

        private void ui_nbtnOrderSize3_Click(object sender, EventArgs e)
        {
            _orderSize = ui_nbtnOrderSize3.Text;
            ui_nbtnOrderSize.Text = ui_nbtnOrderSize3.Text;
        }

        private void ui_nbtnOrderSize2_Click(object sender, EventArgs e)
        {
            _orderSize = ui_nbtnOrderSize2.Text;
            ui_nbtnOrderSize.Text = ui_nbtnOrderSize2.Text;
        }

        private void ui_nbtnOrderSize1_Click(object sender, EventArgs e)
        {
            
            _orderSize = ui_nbtnOrderSize1.Text;
            ui_nbtnOrderSize.Text = ui_nbtnOrderSize1.Text;
        }
        
        public void UpdateValues(clsQuotes quotes)
        {
            Action A=()=>
                {
             
                    string format = "0.";
                    for (int i = 0; i < quotes.Digits; i++)
                    {
                        format += "0";
                    }
                

                    //ui_lblOpenPLValue.Text = "$" + quotes.ProfitLoss.ToString();
                    ui_lblPctValue.Text = quotes.PCT.ToString("0.00") + "%";
                    ui_lblLowValue.Text = quotes.LowValue.ToString(format);//ToString("0.00000");
                    ui_lblHighValue.Text = quotes.HighValue.ToString(format);//ToString("0.00000") ;
                    //ui_lblPositionValue.Text = quotes.Position.ToString();
                    //ui_lblAvgPriceValue.Text = quotes.AveragePrice.ToString("0.00");

                    int Buylength = quotes.SellPrice.ToString(format).Length;
                    int Selllength = quotes.BuyPrice.ToString(format).Length;

                    ProcessLength(quotes.SellPrice);//For Buy = Ask Price
                    ProcessLength(quotes.BuyPrice);//For Sell = Bid Price


                    string BUY = quotes.SellPrice.ToString(format);
                    string SELL = quotes.BuyPrice.ToString(format);

                    string[] spltBuy = BUY.Split('.');
                    string[] spltSell = SELL.Split('.');
                    
                    //****For Buy
                    if (spltBuy.Length == 2)
                    {
                        switch (spltBuy[1].Length)
                        {
                            case 5:
                                ui_lblBuyPriceLeft.Text = spltBuy[0] + "." + spltBuy[1].Substring(0, 2);
                                ui_lblBuyPriceMiddle.Text = spltBuy[1].Substring(2, 2);
                                ui_lblBuyPriceRight.Text = spltBuy[1].Substring(4);
                                break;
                            case 4:
                                ui_lblBuyPriceLeft.Text = spltBuy[0] + "." + spltBuy[1].Substring(0, 2);
                                ui_lblBuyPriceMiddle.Text = spltBuy[1].Substring(2, 2);
                                ui_lblBuyPriceRight.Text = "";//spltBuy[1].Substring(4);
                                break;
                            case 3:
                                ui_lblBuyPriceLeft.Text = spltBuy[0] + ".";
                                ui_lblBuyPriceMiddle.Text = spltBuy[1].Substring(0, 2);
                                ui_lblBuyPriceRight.Text = spltBuy[1].Substring(2);
                                break;
                            case 2:
                                ui_lblBuyPriceLeft.Text = spltBuy[0] + ".";
                                ui_lblBuyPriceMiddle.Text = spltBuy[1].Substring(0, 2);
                                ui_lblBuyPriceRight.Text = "";//spltBuy[1].Substring(2);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (spltBuy.Length == 1)
                    {

                    }



                    //****For Sell
                    if (spltSell.Length == 2)
                    {
                        switch (spltSell[1].Length)
                        {
                            case 5:
                                ui_lblSellPriceLeft.Text = spltSell[0] + "." + spltSell[1].Substring(0, 2);
                                ui_lblSellPriceMiddle.Text = spltSell[1].Substring(2, 2);
                                ui_lblSellPriceRight.Text = spltSell[1].Substring(4);
                                break;
                            case 4:
                                ui_lblSellPriceLeft.Text = spltSell[0] + "." + spltSell[1].Substring(0, 2);
                                ui_lblSellPriceMiddle.Text = spltSell[1].Substring(2, 2);
                                ui_lblSellPriceRight.Text = "";//spltBuy[1].Substring(4);
                                break;
                            case 3:
                                ui_lblSellPriceLeft.Text = spltSell[0] + ".";
                                ui_lblSellPriceMiddle.Text = spltSell[1].Substring(0, 2);
                                ui_lblSellPriceRight.Text = spltSell[1].Substring(2);
                                break;
                            case 2:
                                ui_lblSellPriceLeft.Text = spltSell[0] + ".";
                                ui_lblSellPriceMiddle.Text = spltSell[1].Substring(0, 2);
                                ui_lblSellPriceRight.Text = "";//spltBuy[1].Substring(2);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (spltSell.Length == 1)
                    {

                    }


                    #region Old Logic
                    //if (Buylength == 7)
                    //{
                    //    ui_lblBuyPriceLeft.Text = quotes.BuyPrice.ToString(format).Substring(0, 3);//("0.00000").Substring(0, 3);
                    //    ui_lblBuyPriceMiddle.Text = quotes.BuyPrice.ToString(format).Substring(3, 2);//("0.00000").Substring(3, 2);
                    //    ui_lblBuyPriceRight.Text = quotes.BuyPrice.ToString(format).Substring(5);//("0.00000").Substring(5, 1);
                    //}
                    //if (Selllength == 7)
                    //{
                    //    ui_lblSellPriceLeft.Text = quotes.SellPrice.ToString(format).Substring(0, 3);//("0.00000").Substring(0, 3);
                    //    ui_lblSellPriceMiddle.Text = quotes.SellPrice.ToString(format).Substring(3, 2);//("0.00000").Substring(3, 2);
                    //    //ui_lblSellPriceRight.Text = quotes.SellPrice.ToString(format).Substring(5, 2);//("0.00000").Substring(5, 1);
                    //    ui_lblSellPriceRight.Text = quotes.SellPrice.ToString(format).Substring(5);//("0.00000").Substring(5, 1);
                    //}

                    //if (Buylength == 6)
                    //{
                    //    ui_lblBuyPriceLeft.Text = quotes.BuyPrice.ToString(format).Substring(0, 2);//("0.00000").Substring(0, 3);
                    //    ui_lblBuyPriceMiddle.Text = quotes.BuyPrice.ToString(format).Substring(2, 2);//("0.00000").Substring(3, 2);
                    //    //ui_lblBuyPriceRight.Text = quotes.BuyPrice.ToString(format).Substring(4, 2);//("0.00000").Substring(5, 1);
                    //    ui_lblBuyPriceRight.Text = quotes.BuyPrice.ToString(format).Substring(4);//("0.00000").Substring(5, 1);
                    //}
                    //if (Selllength == 6)
                    //{
                    //    ui_lblSellPriceLeft.Text = quotes.SellPrice.ToString(format).Substring(0, 2);//("0.00000").Substring(0, 3);
                    //    ui_lblSellPriceMiddle.Text = quotes.SellPrice.ToString(format).Substring(2, 2);//("0.00000").Substring(3, 2);
                    //    //ui_lblSellPriceRight.Text = quotes.SellPrice.ToString(format).Substring(4, 2);//("0.00000").Substring(5, 1);
                    //    ui_lblSellPriceRight.Text = quotes.SellPrice.ToString(format).Substring(4);//("0.00000").Substring(5, 1);
                    //}

                    //if (Buylength == 5)
                    //{
                    //    ui_lblBuyPriceLeft.Text = quotes.BuyPrice.ToString(format).Substring(0, 2);//("0.00000").Substring(0, 3);
                    //    ui_lblBuyPriceMiddle.Text = quotes.BuyPrice.ToString(format).Substring(2, 2);//("0.00000").Substring(3, 2);
                    //    //ui_lblBuyPriceRight.Text = quotes.BuyPrice.ToString(format).Substring(4, 1);//("0.00000").Substring(5, 1);
                    //    ui_lblBuyPriceRight.Text = quotes.BuyPrice.ToString(format).Substring(4);//("0.00000").Substring(5, 1);
                    //}
                    //if (Selllength == 5)
                    //{
                    //    ui_lblSellPriceLeft.Text = quotes.SellPrice.ToString(format).Substring(0, 2);//("0.00000").Substring(0, 3);
                    //    ui_lblSellPriceMiddle.Text = quotes.SellPrice.ToString(format).Substring(2, 2);//("0.00000").Substring(3, 2);
                    //    //ui_lblSellPriceRight.Text = quotes.SellPrice.ToString(format).Substring(4, 1);//("0.00000").Substring(5, 1);
                    //    ui_lblSellPriceRight.Text = quotes.SellPrice.ToString(format).Substring(4);//("0.00000").Substring(5, 1);
                    //}

                    //if (Buylength == 4)
                    //{
                    //    ui_lblBuyPriceLeft.Text = quotes.BuyPrice.ToString(format).Substring(0, 2);//("0.00000").Substring(0, 3);
                    //    ui_lblBuyPriceMiddle.Text = quotes.BuyPrice.ToString(format).Substring(2, 2);//("0.00000").Substring(3, 2);
                    //    ui_lblBuyPriceRight.Text = "0";//quotes.BuyPrice.ToString().Substring(6, 1);//("0.00000").Substring(5, 1);
                    //}

                    //if (Selllength == 4)
                    //{
                    //    ui_lblSellPriceLeft.Text = quotes.SellPrice.ToString(format).Substring(0, 2);//("0.00000").Substring(0, 3);
                    //    ui_lblSellPriceMiddle.Text = quotes.SellPrice.ToString(format).Substring(2, 2);//("0.00000").Substring(3, 2);
                    //    ui_lblSellPriceRight.Text = "0";//quotes.SellPrice.ToString().Substring(6, 1);//("0.00000").Substring(5, 1);
                    //}
                    #endregion

                    if (quotes.BuyUp)
                    {
                        ui_pbBuyArrow.Image = up;
                    }
                    else
                    {
                        ui_pbBuyArrow.Image = down;
                    }

                    if (quotes.SellUp)
                    {
                        ui_pbSellArrow.Image = up;
                    }
                    else
                    {
                        ui_pbSellArrow.Image = down;
                    }

                    //if (ui_lblBuyPriceLeft.Text != string.Empty)
                    //{
                    //    _previousBuyPrice = quotes.BuyPrice;//Convert.ToDouble(ui_lblBuyPriceLeft.Text.Trim() + ui_lblBuyPriceMiddle.Text.Trim() + "." + ui_lblBuyPriceRight.Text.Trim());
                    //    _previousSellPrice = quotes.SellPrice;//Convert.ToDouble(ui_lblSellPriceLeft.Text.Trim() + ui_lblSellPriceMiddle.Text.Trim() + "." + ui_lblSellPriceRight.Text.Trim());
                    //}

                };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
      
        }

        private void ProcessLength(double price)
        {
            
        }

        private void ui_ndcrtBuyMkt_Click(object sender, EventArgs e)
        {
            ui_nbtnBuyMkt_Click(null, null);
        }

        private void ui_lblBuyMarketLabel_Click(object sender, EventArgs e)
        {
            ui_nbtnBuyMkt_Click(null, null);
        }

        private void ui_lblSellMkt_Click(object sender, EventArgs e)
        {
            ui_btnSellMkt_Click(null, null);
        }

        private void ui_ndcrtSellMkt_Click(object sender, EventArgs e)
        {
            ui_btnSellMkt_Click(null, null);
        }

        internal void SendOrder(string Qty, double price, bool Isbuy, string OrdType)
        {
            _crtOrderPrice = price;
            _orderSize = Qty;
            if (Isbuy)
            {
                //if (OrdType == "Stop")
                //{
                //    SendOrderofSpecificType(OrderTypes.BUY_STOP);
                //}
                //else
                //{
                    SendOrderofSpecificType(OrderTypes.BUY);
                //}
            }
            else
            {
              

                //if (OrdType == "Stop")
                //{
                //    SendOrderofSpecificType(OrderTypes.SELL_STOP);
                //}
                //else
                //{
                    SendOrderofSpecificType(OrderTypes.SELL);
                //}
            }
        }
    }

    public enum OrderTypes
    {
        BUY,
        SELL,
        BUY_MARKET,
        SELL_MARKET
    }
}
