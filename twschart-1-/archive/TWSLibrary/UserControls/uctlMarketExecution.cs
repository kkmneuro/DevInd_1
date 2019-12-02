using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonLibrary.UserControls
{
    public partial class uctlMarketExecution : OrderChildControl
    { 

        Color _buyColor;
        Color _sellColor;
        int _digits = 5;
        public Color BuyColor
        {
            get { return _buyColor; }
            set { _buyColor = value; }
        }
        public Color SellColor
        {
            get { return _sellColor; }
            set { _sellColor = value; }
        }
        public string BidValue
        { 
            get{return decimal.Round(Convert.ToDecimal(lblBidVal.Text), Digits).ToString(format);}
            set { lblBidVal.Text = decimal.Round(Convert.ToDecimal(value), Digits).ToString(format); }
        }

        public string AskValue
        {

            get { return decimal.Round(Convert.ToDecimal(lblAskVal.Text), Digits).ToString(format); }
            set { lblAskVal.Text = decimal.Round(Convert.ToDecimal(value), Digits).ToString(format); }
        }

        string format = "0.";
        public override int Digits
        {
            get
            {
                return _digits;
            }
            set
            {
                format = "0.";
                for (int i = 0; i < value; i++)
                {
                    format += "0";
                }
                _digits = value;
            }
        }

        public string CloseText
        {
            get{return btnClose.Text;}
            set{btnClose.Text=value;}
        }
        public string ReverseText
        {
            get { return btnReverse.Text; }
            set { btnReverse.Text = value; }
        }
        //public bool OrderRowReferanced

        public event Action OnMarketExecutionSellClick = delegate { };
        public event Action OnMarketExecutionBuyClick = delegate { };
        public event Action OnMarketExecutionCloseClick = delegate { };
        public event Action OnMarketExecutionReverseClick = delegate { };

        public uctlMarketExecution()
        {
            try
            {
                InitializeComponent();
                //_parent = _frmOrderEntry;
                initControl();
                btnClose.Visible = false;
                btnReverse.Visible = false;
                //if (OrderRowReferanced)
                //{
                //    //double Price = 0;
                //    btnClose.Visible = true;
                //    btnReverse.Visible = true;
                //    //if (_parent.ReferenceOrderRow.Side == Side.BUY.ToString())
                //    //{
                //    //    Price = Convert.ToDouble(lblBidVal.Text);
                //    //}
                //    //else if (_parent.ReferenceOrderRow.Side == Side.SELL.ToString())
                //    //{
                //    //    Price = Convert.ToDouble(lblAskVal.Text);
                //    //}

                //    //btnClose.Text = "Close #" + _parent.ReferenceOrderRow.ClientOrderID + " " + _parent.ReferenceOrderRow.Side + " " + _parent.ReferenceOrderRow.Quantity + " "
                //    //                 + _parent.ReferenceOrderRow.Instrument + " at " + Price;
                    
                //    //btnReverse.Text = "Reverse #" + _parent.ReferenceOrderRow.ClientOrderID + " " + _parent.ReferenceOrderRow.Side + " " + _parent.ReferenceOrderRow.Quantity + " "
                //    //                 + _parent.ReferenceOrderRow.Instrument + " at " + Price;
                    
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        # region override Methods
        protected override void initControl()
        {
            //_parent.CurrentOrder.RequestType = OrderRequestType.NEW;
            btnSell.BackColor = Color.FromArgb(255, 128, 128);
            btnBuy.BackColor = Color.FromArgb(160, 192, 255);
            btnClose.BackColor = Color.FromArgb(255, 255, 160);
            btnReverse.BackColor = Color.FromArgb(0, 130, 203);
            this.Dock = DockStyle.Fill;
            loadMarkupPIPVal();
        }

        //public override void updateOnQuoteChanged(QuoteResponse QR)
        //{
        //    lblBidVal.Text = String.Format(Initializer.getPriceFormat(QR.Symbol_), QR.BidPx_);
        //    lblAskVal.Text = String.Format(Initializer.getPriceFormat(QR.Symbol_), QR.AskPx_);
        //    double Price = 0;
        //    if (_parent.ReferenceOrderRow != null)
        //    {
        //        if (_parent.ReferenceOrderRow.Side == Side.BUY.ToString())
        //        {
        //            Price = Convert.ToDouble(lblBidVal.Text);
        //        }
        //        else if (_parent.ReferenceOrderRow.Side == Side.SELL.ToString())
        //        {
        //            Price = Convert.ToDouble(lblAskVal.Text);
        //        }

        //        btnClose.Text = "Close #" + _parent.ReferenceOrderRow.ClientOrderID + " " + _parent.ReferenceOrderRow.Side + " " + _parent.ReferenceOrderRow.Quantity + " "
        //                         + _parent.ReferenceOrderRow.Instrument + " at " + Price;

        //        btnReverse.Text = "Reverse #" + _parent.ReferenceOrderRow.ClientOrderID + " " + _parent.ReferenceOrderRow.Side + " " + _parent.ReferenceOrderRow.Quantity + " "
        //                         + _parent.ReferenceOrderRow.Instrument + " at " + Price;
        //    }
        //}
        # endregion
        /// <summary>
        /// This function is responsible to load the value of cmbMarkPIP comboBox.
        /// </summary>
        public void loadMarkupPIPVal()
        {
            cmbMarkPIP.Items.Clear();
            cmbMarkPIP.Items.Add(0);
            cmbMarkPIP.Items.Add(1);
            cmbMarkPIP.Items.Add(2);
            cmbMarkPIP.Items.Add(3);
            cmbMarkPIP.Items.Add(4);
            cmbMarkPIP.Items.Add(5);
            cmbMarkPIP.Items.Add(10);
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            OnMarketExecutionSellClick();
            //_parent.CurrentOrder.OrderType = clsInterface4OME.OrderType.MARKET;
            //_parent.CurrentOrder.BuySell = Side.SELL;
            //_parent.CurrentOrder.TimeInForce = TIF.GTC;
            //_parent.CurrentOrder.Price = Convert.ToDouble(lblBidVal.Text);
            //_parent.SendMarketOrPendingOrder();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            OnMarketExecutionBuyClick();
            //_parent.CurrentOrder.OrderType = clsInterface4OME.OrderType.MARKET;
            //_parent.CurrentOrder.BuySell = Side.BUY;
            //_parent.CurrentOrder.TimeInForce = TIF.GTC;
            //_parent.CurrentOrder.Price = Convert.ToDouble(lblAskVal.Text);
            //_parent.SendMarketOrPendingOrder();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnMarketExecutionCloseClick();
            //_parent.closeOrder(_parent.ReferenceOrderRow.ClientOrderID);
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            OnMarketExecutionReverseClick();
            //_parent.IsReverse = true;
            //_parent.reverseOrder(_parent.ReferenceOrderRow.ClientOrderID);
        }
    }
}
