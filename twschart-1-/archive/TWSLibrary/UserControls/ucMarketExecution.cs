using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using clsInterface4OME;
//using ProtocolStructs;

namespace CommonLibrary.UserControls
{
    /// <summary>
    /// Code Review done.
    /// </summary>
    public partial class ucMarketExecution : OrderChildControl
    {
        #region Members
        Color _color4Buy;
        public Color Color4Buy
        {
            get { return _color4Buy; }
            set { _color4Buy = value; }
        }

        Color _color4Sell;
        public Color Color4Sell
        {
            get { return _color4Sell; }
            set { _color4Sell = value; }
        }

        GTS.Frm.frmOrderEntry _parent;
        #endregion

        #region Constructs
        public ucMarketExecution(GTS.Frm.frmOrderEntry _frmOrderEntry):base()
        {
            try
            {
                InitializeComponent();
                _parent = _frmOrderEntry;
                initControl();
                btnClose.Visible = false;
                btnReverse.Visible = false;
                if (_parent.ReferenceOrderRow != null)
                {
                    double Price = 0;

                    if (_parent.ReferenceOrderRow.Side == Side.BUY.ToString())
                    {
                        Price = Convert.ToDouble(lblBidVal.Text);
                    }
                    else if (_parent.ReferenceOrderRow.Side == Side.SELL.ToString())
                    {
                        Price = Convert.ToDouble(lblAskVal.Text);
                    }

                    btnClose.Text = "Close #" + _parent.ReferenceOrderRow.ClientOrderID + " " + _parent.ReferenceOrderRow.Side + " " + _parent.ReferenceOrderRow.Quantity + " "
                                     + _parent.ReferenceOrderRow.Instrument + " at " + Price;
                    btnClose.Visible = true;
                    btnReverse.Text = "Reverse #" + _parent.ReferenceOrderRow.ClientOrderID + " " + _parent.ReferenceOrderRow.Side + " " + _parent.ReferenceOrderRow.Quantity + " "
                                     + _parent.ReferenceOrderRow.Instrument + " at " + Price;
                    btnReverse.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //public ucMarketExecution(GTS.Frm.frmOrderEntry _frmOrderEntry, DS4Orders.OrdersRow OrderRow)
        //    : base()
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        _parent = _frmOrderEntry;
        //        initControl();

        //        double Price = 0;

        //        if (OrderRow.Side == Side.BUY.ToString())
        //        {
        //            Price = Convert.ToDouble(lblBidVal.Text);
        //        }
        //        else if (OrderRow.Side == Side.SELL.ToString())
        //        {
        //            Price = Convert.ToDouble(lblAskVal.Text);
        //        }

        //        btnClose.Text = "Close #" + OrderRow.ClientOrderID + " " + OrderRow.Side + " " + OrderRow.Quantity + " "
        //                         + OrderRow.Instrument + " at " + Price;
        //        btnClose.Visible = true;
        //        btnReverse.Text = "Reverse #" + OrderRow.ClientOrderID + " " + OrderRow.Side + " " + OrderRow.Quantity + " "
        //                         + OrderRow.Instrument + " at " + Price;
        //        btnReverse.Visible = true;
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        #endregion

        # region override Methods
        protected override void initControl()
        {
            _parent.CurrentOrder.RequestType = OrderRequestType.NEW;
            btnSell.BackColor = Color.FromArgb(255, 128, 128);
            btnBuy.BackColor = Color.FromArgb(160, 192, 255);
            btnClose.BackColor = Color.FromArgb(255, 255, 160);
            btnReverse.BackColor = Color.FromArgb(0, 130, 203);
            this.Dock = DockStyle.Fill;
            loadMarkupPIPVal();
        }
        public override void updateOnQuoteChanged(QuoteResponse QR)
        {
            lblBidVal.Text = String.Format(Initializer.getPriceFormat(QR.Symbol_), QR.BidPx_);
            lblAskVal.Text = String.Format(Initializer.getPriceFormat(QR.Symbol_), QR.AskPx_);
            double Price = 0;
            if (_parent.ReferenceOrderRow != null)
            {
                if (_parent.ReferenceOrderRow.Side == Side.BUY.ToString())
                {
                    Price = Convert.ToDouble(lblBidVal.Text);
                }
                else if (_parent.ReferenceOrderRow.Side == Side.SELL.ToString())
                {
                    Price = Convert.ToDouble(lblAskVal.Text);
                }

                btnClose.Text = "Close #" + _parent.ReferenceOrderRow.ClientOrderID + " " + _parent.ReferenceOrderRow.Side + " " + _parent.ReferenceOrderRow.Quantity + " "
                                 + _parent.ReferenceOrderRow.Instrument + " at " + Price;

                btnReverse.Text = "Reverse #" + _parent.ReferenceOrderRow.ClientOrderID + " " + _parent.ReferenceOrderRow.Side + " " + _parent.ReferenceOrderRow.Quantity + " "
                                 + _parent.ReferenceOrderRow.Instrument + " at " + Price;
            }
        }
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

        private void ucMarketExecution_Load(object sender, EventArgs e)
        {

        }

        # region Event Handler

        private void btnBuy_Click(object sender, EventArgs e)
        {
            _parent.CurrentOrder.OrderType = clsInterface4OME.OrderType.MARKET;
            _parent.CurrentOrder.BuySell = Side.BUY;
            _parent.CurrentOrder.TimeInForce = TIF.GTC;
            _parent.CurrentOrder.Price = Convert.ToDouble(lblAskVal.Text);
            _parent.SendMarketOrPendingOrder();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _parent.closeOrder(_parent.ReferenceOrderRow.ClientOrderID);
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            _parent.IsReverse = true;
            _parent.reverseOrder(_parent.ReferenceOrderRow.ClientOrderID);
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            _parent.CurrentOrder.OrderType = clsInterface4OME.OrderType.MARKET;
            _parent.CurrentOrder.BuySell = Side.SELL;
            _parent.CurrentOrder.TimeInForce = TIF.GTC;
            _parent.CurrentOrder.Price = Convert.ToDouble(lblBidVal.Text);
            _parent.SendMarketOrPendingOrder();

        }

        #endregion
    }
}
