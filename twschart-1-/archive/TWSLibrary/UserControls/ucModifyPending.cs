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
    public partial class ucModifyPending : OrderChildControl
    {
        #region Members
        GTS.Frm.frmOrderEntry _parent;
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
        #endregion

        public ucModifyPending(GTS.Frm.frmOrderEntry _frmOrderEntry)
        {
            InitializeComponent();
            _parent = _frmOrderEntry;
            initControl();
        }

        #region Override Methods

        protected override void initControl()
        {
            PopulateCurrentOrderDetails();
            this.Dock = DockStyle.Fill;
            btnCancel.BackColor = Color.FromArgb(255, 255, 128);
            setDefaultValues();
            setPrecisionBehaviour();
        }
        protected override void setColor4BuySell()
        {
            if (_parent.ReferenceOrderRow.Side == clsInterface4OME.Side.BUY.ToString())
            {
                btnModify.BackColor = _parent.Color4Buy;
            }
            else
            {
                btnModify.BackColor = _parent.Color4Sell;
            }
        }
        protected override void setPrecisionBehaviour()
        {
            if (_parent.ReferenceOrderRow.Instrument.Contains("JPY"))
            {
                cmbPrice.DecimalPlaces = cmbSLValue.DecimalPlaces = cmbTPValue.DecimalPlaces = 2;
                cmbPrice.Increment = cmbSLValue.Increment = cmbTPValue.Increment = 0.01M;
            }
            else
            {
                cmbPrice.DecimalPlaces = cmbSLValue.DecimalPlaces = cmbTPValue.DecimalPlaces = 4;
                cmbPrice.Increment = cmbSLValue.Increment = cmbTPValue.Increment = 0.0001M;
            }
        }

        public override void updateOnPriceChaged(decimal Price)
        {
            cmbPrice.Value = Price;
        }
        public override void updateOnSLChanged(decimal SL)
        {
            cmbSLValue.Value = SL;
        }
        public override void updateOnTPChanged(decimal TP)
        {
            cmbTPValue.Value = TP;
        }
      
        #endregion

        private void setDefaultValues()
        {
            cmbSLValue.Value = Convert.ToDecimal(_parent.ReferenceOrderRow.StopLoss);
            cmbTPValue.Value = Convert.ToDecimal(_parent.ReferenceOrderRow.TakeProfit);
            cmbPrice.Value = Convert.ToDecimal(_parent.ReferenceOrderRow.LimitPrice);
            _parent.CurrentOrder.Price = _parent.ReferenceOrderRow.LimitPrice;
        }
        void PopulateCurrentOrderDetails()
        {
            _parent.CurrentOrder.RequestType = OrderRequestType.MODIFIED;
            _parent.CurrentOrder.ClientOrderID = Convert.ToInt64(_parent.ReferenceOrderRow.ClientOrderID);
            _parent.CurrentOrder.Price = _parent.ReferenceOrderRow.LimitPrice;
            _parent.CurrentOrder.SL = _parent.ReferenceOrderRow.StopLoss;
            _parent.CurrentOrder.TP = _parent.ReferenceOrderRow.TakeProfit;
            _parent.CurrentOrder.Quantity = _parent.ReferenceOrderRow.Quantity;
            _parent.CurrentOrder.Instrument = _parent.ReferenceOrderRow.Instrument;
            if (_parent.ReferenceOrderRow.Side == Side.BUY.ToString())
            {
                _parent.CurrentOrder.BuySell = Side.BUY;
            }
            else if (_parent.ReferenceOrderRow.Side == Side.SELL.ToString())
            {
                _parent.CurrentOrder.BuySell = Side.SELL;
            }
        }
        private void initializeSL()
        {

            QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(_parent.CurrentOrder.Instrument);
            if (_parent.ReferenceOrderRow.Side == Side.BUY.ToString())
            {
                cmbSLValue.Value = (decimal)QR.BidPx_;
            }
            else
            {
                cmbSLValue.Value = (decimal)QR.AskPx_;
            }

        }
        private void initializeTP()
        {

            QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(_parent.CurrentOrder.Instrument);
            if (_parent.ReferenceOrderRow.Side == Side.BUY.ToString())
            {
                cmbTPValue.Value = (decimal)QR.BidPx_;
            }
            else
            {
                cmbTPValue.Value = (decimal)QR.AskPx_;
            }


        }
        private void initializePrice()
        {

            QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(_parent.CurrentOrder.Instrument);
            if (_parent.ReferenceOrderRow.Side == Side.BUY.ToString())
            {
                cmbPrice.Value = (decimal)QR.BidPx_;
            }
            else
            {
                cmbPrice.Value = (decimal)QR.AskPx_;
            }

        }
        public void setLock(bool Flag)
        {
            btnModify.Enabled = Flag;
            if (Flag == false)
            {
                btnModify.Enabled = false;
                btnModify.BackColor = Color.WhiteSmoke;
            }
            else
            {
                btnModify.Enabled = true;
                setColor4BuySell();
            }
        }

        #region Event Handlers

        private void cmbPrice_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPrice.Value > 0.0M)
            {
                _parent.CurrentOrder.Price = Convert.ToDouble(cmbPrice.Value);
            }
            else
            {
                cmbPrice.Value = Convert.ToDecimal(_parent.CurrentOrder.Price);
            }
            _parent.SetPriceLine(Convert.ToDouble(cmbPrice.Value));
            _parent.validateOrderOnModify(_parent.CurrentOrder);
        }

        private void cmbSLValue_ValueChanged(object sender, EventArgs e)
        {
            _parent.updateSLTP(cmbSLValue.Value, cmbTPValue.Value);
            _parent.validateOrderOnModify(_parent.CurrentOrder);
        }

        private void cmbTPValue_ValueChanged(object sender, EventArgs e)
        {
            _parent.updateSLTP(cmbSLValue.Value, cmbTPValue.Value);
            _parent.validateOrderOnModify(_parent.CurrentOrder);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            _parent.CurrentOrder.RequestType = clsInterface4OME.OrderRequestType.MODIFIED;
            _parent.ModifyOrder();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _parent.CurrentOrder.RequestType = clsInterface4OME.OrderRequestType.CANCELLED;
            _parent.CancelOrder();
        }

        private void cmbSLValue_MouseDown(object sender, MouseEventArgs e)
        {
            if (cmbSLValue.Value <= 0.0M)
            {
                initializeSL();
            }
        }

        private void cmbTPValue_MouseDown(object sender, MouseEventArgs e)
        {
            if (cmbTPValue.Value <= 0.0M)
            {
                initializeTP();
            }
        }

        private void cmbPrice_MouseDown(object sender, MouseEventArgs e)
        {
            if (cmbPrice.Value <= 0.0M)
            {
                initializePrice();
            }
        }

        #endregion


    }
}
