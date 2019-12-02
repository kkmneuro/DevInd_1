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
    public partial class uctlPendingNew : OrderChildControl
    {


        public uctlPendingNew()
        {
            InitializeComponent();
            //_parent = _frmOrderEntry;
            //Default value
            initControl();
            //setPrecisionBehaviour();
        }
        //public ucPendingNew(GTS.Frm.frmOrderEntry _frmOrderEntry, clsInterface4OME.OrderType type, Side side, decimal Price)
        //{
        //    InitializeComponent();
        //    _parent = _frmOrderEntry;
        //    //Default value
        //    initControl();
        //    switch (side)
        //    {
        //        case Side.BUY:
        //            if (type == clsInterface4OME.OrderType.LIMIT)
        //            {
        //                cmbSide.SelectedIndex = 0;
        //            }
        //            else if (type == clsInterface4OME.OrderType.STL)
        //            {
        //                cmbSide.SelectedIndex = 1;
        //            }
        //            break;
        //        case Side.NA:
        //            break;
        //        case Side.SELL:
        //            if (type == clsInterface4OME.OrderType.LIMIT)
        //            {
        //                cmbSide.SelectedIndex = 2;
        //            }
        //            else if (type == clsInterface4OME.OrderType.STL)
        //            {
        //                cmbSide.SelectedIndex = 3;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    //On one line it is set to xero.Not enough time to fix the bug.
        //    cmbPrice.Value = Price;
        //    cmbPrice.Value = Price;

        //    setPrecisionBehaviour();
        //}

        #region Override Methods
        protected override void initControl()
        {
            //_parent.CurrentOrder.RequestType = OrderRequestType.NEW;
            this.Dock = DockStyle.Fill;
            cmbSide.SelectedIndex = 0;
            cmbTIF.SelectedIndex = 0;
            //setColor4BuySell();
            //if (_parent.ReferenceOrderRow != null)
            //{
            //    _parent.CurrentOrder.Price = _parent.ReferenceOrderRow.LimitPrice;
            //}
        }
        //protected override void setPrecisionBehaviour()
        //{
        //    if (_parent.CurrentOrder.Instrument.Contains("JPY"))
        //    {
        //        cmbPrice.DecimalPlaces = 2;
        //        cmbPrice.Increment = 0.01M;
        //    }
        //    else
        //    {
        //        cmbPrice.DecimalPlaces = 4;
        //        cmbPrice.Increment = 0.0001M;
        //    }
        //}
        //public override void updateOnPriceChaged(decimal Price)
        //{
        //    cmbPrice.Value = Price;
        //}
        #endregion
       

        private void cmbTIF_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (cmbTIF.SelectedIndex)
            //{
            //    case 0:
            //    case 1:
            //        _parent.CurrentOrder.TimeInForce = TIF.GTC;
            //        break;
            //    case 2:
            //        _parent.CurrentOrder.TimeInForce = TIF.DAY;
            //        break;
            //    case 3:
            //        _parent.CurrentOrder.TimeInForce = TIF.DATE;
            //        dtpickerGTD.Visible = true;
            //        dtpickerGTD.Value = DateTime.UtcNow;
            //        _parent.CurrentOrder.GTD = dtpickerGTD.Value;
            //        break;
            //    default:
            //        break;
            //}
        }

        private void cmbSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (cmbSide.SelectedIndex)
            //{
            //    case 0:
            //        _parent.CurrentOrder.BuySell = Side.BUY;
            //        _parent.CurrentOrder.OrderType = clsInterface4OME.OrderType.LIMIT;
            //        btnPlace.BackColor = _parent.Color4Buy;
            //        break;
            //    case 1:
            //        _parent.CurrentOrder.BuySell = Side.BUY;
            //        _parent.CurrentOrder.OrderType = clsInterface4OME.OrderType.STP;
            //        btnPlace.BackColor = _parent.Color4Buy;
            //        break;
            //    case 2:
            //        _parent.CurrentOrder.BuySell = Side.SELL;
            //        _parent.CurrentOrder.OrderType = clsInterface4OME.OrderType.LIMIT;
            //        btnPlace.BackColor = _parent.Color4Sell;
            //        break;
            //    case 3:
            //        _parent.CurrentOrder.BuySell = Side.SELL;
            //        _parent.CurrentOrder.OrderType = clsInterface4OME.OrderType.STP;
            //        btnPlace.BackColor = _parent.Color4Sell;
            //        break;
            //    default:
            //        break;
            //}
        }
        public event Action<double,string,string>  OnPendingNewPlaceClick=delegate{};
        public event Action<string> OnPriceChanged = delegate { };
        public event Action<string> OnPriceMouseDown = delegate { };
        private void btnPlace_Click(object sender, EventArgs e)
        {
            //OnPendingNewPlaceClick(Convert.ToDouble(cmbPrice.Value), cmbTIF.SelectedItem.ToString(), cmbSide.SelectedItem.ToString());
            OnPendingNewPlaceClick(Convert.ToDouble(txtPrice.Text), cmbTIF.SelectedItem.ToString(), cmbSide.SelectedItem.ToString());
        }

        private void dtpickerGTD_ValueChanged(object sender, EventArgs e)
        {
            //_parent.CurrentOrder.GTD = dtpickerGTD.Value;
        }

        private void cmbPrice_ValueChanged(object sender, EventArgs e)
        {
            // _parent.CurrentOrder.Price = Convert.ToDouble(cmbPrice.Value);

            //_parent.SetPriceLine(Convert.ToDouble(cmbPrice.Value));
        }

        private void cmbPrice_MouseDown(object sender, MouseEventArgs e)
        {

        }

        void initializePrice()
        {
            //QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(_parent.CurrentOrder.Instrument);
            //if (QR != null)
            //{
            //    switch (_parent.CurrentOrder.BuySell)
            //    {
            //        case Side.BUY:
            //            cmbPrice.Value = Convert.ToDecimal(QR.AskPx_);
            //            _parent.CurrentOrder.Price = QR.AskPx_;
            //            break;
            //        case Side.NA:
            //            break;
            //        case Side.SELL:
            //            cmbPrice.Value = Convert.ToDecimal(QR.BidPx_);
            //            _parent.CurrentOrder.Price = QR.BidPx_;
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        private void txtPrice_MouseDown(object sender, MouseEventArgs e)
        {
            //if (Convert.ToDecimal(txtPrice.Text) <= 0.0M == false)
            //{
            //    initializePrice();
            //}
            OnPriceMouseDown(txtPrice.Text);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            OnPriceChanged(txtPrice.Text);
        }
        public void UpdatePrice(double _askPrice, double _bidPrice,double mindiff, int digits)
        { 
            string formate ="0.";
            for(int i=0;i<digits;i++)
            {
            formate+="0";
            }
            if(cmbSide.Text.ToLower().Contains("buy"))
            {
                if(cmbSide.Text.ToLower().Contains("limit"))
                    txtPrice.Text = (_askPrice-mindiff).ToString(formate);
                else
                    txtPrice.Text = (_askPrice+mindiff).ToString(formate);
            }
            else 
            {
                if(cmbSide.Text.ToLower().Contains("limit"))
                    txtPrice.Text = (_bidPrice+mindiff).ToString(formate);
                else
                    txtPrice.Text = (_bidPrice-mindiff).ToString(formate);
            }
        }
    }
}
