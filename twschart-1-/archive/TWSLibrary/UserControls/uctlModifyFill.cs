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
    public partial class uctlModifyFill : OrderChildControl
    {
  # region Members

        //GTS.Frm.frmOrderEntry _parent;
        Color _color4Buy;
        int _digits = 5;
        public Color Color4Buy
        {
            get { return _color4Buy; }
            set { _color4Buy = value; }
        }
        Color _color4Sell;
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
        public string SLPrice
        {
            get { return txtSL.Text; }
            set { txtSL.Text = value; }
        }
        public string TPPrice
        {
            get { return txtTP.Text; }
            set { txtTP.Text = value; }
        }
        public Color Color4Sell
        {
            get { return _color4Sell; }
            set { _color4Sell = value; }
        }

        //string strFormat_ = "{0:0.00000}";

        # endregion

        public uctlModifyFill()
        {
            InitializeComponent();
            //_parent = _frmOrderEntry;
            initControl();
        }

        # region Override Methods

        protected override void initControl()
        {
            cmbSLValue.DecimalPlaces = Digits;
            cmbTPValue.DecimalPlaces = Digits;
            cmbSLValue.Increment = cmbTPValue.Increment = Convert.ToDecimal(1/Math.Pow(10,Digits-1));
            //cmbMarkUp4SL.SelectedItem = OrderValidation.Level4SL;
            //cmbMarkUp4TP.SelectedItem = OrderValidation.Level4TP;

            //_parent.CurrentOrder.RequestType = OrderRequestType.MODIFIED;
            //_parent.CurrentOrder.ClientOrderID = Convert.ToInt64(_parent.ReferenceOrderRow.ClientOrderID);
            //cmbSLValue.Value = (decimal)_parent.ReferenceOrderRow.StopLoss;
            //cmbTPValue.Value = (decimal)_parent.ReferenceOrderRow.TakeProfit;
            //if (_parent.ReferenceOrderRow.Side == Side.BUY.ToString())
            //{
            //    _parent.CurrentOrder.BuySell = Side.BUY;
            //}
            //else if (_parent.ReferenceOrderRow.Side == Side.SELL.ToString())
            //{
            //    _parent.CurrentOrder.BuySell = Side.SELL;
            //}
            this.Dock = DockStyle.Fill;
            //btnCopy4SL.BackColor = _parent.Color4Sell;
            //btnCopy4TP.BackColor = _parent.Color4Buy;
            //setPrecisionBehaviour();
            //setSL_TPValue();
            setDetaultValue();
            //btnModify.Text = "Modify #" + _parent.ReferenceOrderRow.ClientOrderID + " " +
            //                          _parent.ReferenceOrderRow.Instrument + " " +
            //                          _parent.ReferenceOrderRow.Side + " " +
            //                          _parent.ReferenceOrderRow.Quantity + " " +
            //                          " SL :" + _parent.ReferenceOrderRow.StopLoss + " " +
            //                          " TP :" + _parent.ReferenceOrderRow.TakeProfit + " " +
            //                          " at" + _parent.ReferenceOrderRow.PriceFilled + " ";
        }
        //public override void updateOnQuoteChanged(QuoteResponse QR)
        //{
        //    setSL_TPValue(QR);
        //}
        //public override void updateOnSLChanged(decimal SL)
        //{
        //    cmbSLValue.Value = SL;
        //}
        //public override void updateOnTPChanged(decimal TP)
        //{
        //    cmbTPValue.Value = TP;
        //}
        //protected override void setColor4BuySell()
        //{
        //    if (_parent.ReferenceOrderRow.Side == clsInterface4OME.Side.BUY.ToString())
        //    {
        //        btnModify.BackColor = _parent.Color4Buy;
        //    }
        //    else
        //    {
        //        btnModify.BackColor = _parent.Color4Sell;
        //    }
        //}
        //protected override void setPrecisionBehaviour()
        //{
        //    if (_parent.ReferenceOrderRow.Instrument.Contains("JPY"))
        //    {
        //        cmbSLValue.DecimalPlaces = cmbTPValue.DecimalPlaces = 2;
        //        cmbSLValue.Increment = cmbTPValue.Increment = 0.01M;
        //    }
        //    else
        //    {
        //        cmbSLValue.DecimalPlaces = cmbTPValue.DecimalPlaces = 4;
        //        cmbSLValue.Increment = cmbTPValue.Increment = 0.0001M;
        //    }
        //}

        #endregion
        double currentSl = 0;
        double currentTp = 0;
        public void updateSLTP(string sl, string tp)
        {
            if(sl!=string.Empty)
            currentSl = Convert.ToDouble(sl);
            if(tp!=string.Empty)
            currentTp = Convert.ToDouble(tp);
            txtSL.Text = sl;
            txtTP.Text = tp;
        }
        void setDetaultValue()
        {
            cmbMarkUp4SL.SelectedIndex = 0;
            cmbMarkUp4TP.SelectedIndex = 0;
        }
        //void setModifyText()
        //{
            
        //    btnModify.Text = "Modify #"+_parent.ReferenceOrderRow.ClientOrderID+" "+
        //                               _parent.ReferenceOrderRow.Instrument + " " +
        //                               _parent.ReferenceOrderRow.Side+" "+
        //                               _parent.ReferenceOrderRow.Quantity.ToString()+" "+
        //                               " SL :"+String.Format(strFormat_,_parent.CurrentOrder.SL)+" "+
        //                               " TP :" + String.Format(strFormat_,_parent.CurrentOrder.TP) + " " +
        //                               " at"+String.Format(strFormat_,_parent.ReferenceOrderRow.PriceFilled)+" ";
                                     
        //}
        //void setSL_TPValue()
        //{
        //    ProtocolStructs.QuoteResponse QR = QuoteManager.getQuoteManager().getLastQuote(_parent.ReferenceOrderRow.Instrument);
        //    if (_parent.ReferenceOrderRow.StopLoss <= 0 
        //         || _parent.ReferenceOrderRow.TakeProfit <= 0)
        //    {
        //        setSL_TPValue(QR);
               
        //    }
        //    else
        //    {
        //            btnCopy4TP.Text = string.Format(Initializer.getPriceFormat(_parent.ReferenceOrderRow.Instrument)
        //                                            ,_parent.ReferenceOrderRow.TakeProfit);
        //            btnCopy4SL.Text =  string.Format(Initializer.getPriceFormat(_parent.ReferenceOrderRow.Instrument),
        //                                            _parent.ReferenceOrderRow.StopLoss);
        //    }
        //}
        //void setSL_TPValue(ProtocolStructs.QuoteResponse QR)
        //{
        //    if (QR != null)
        //    {
        //        double diffSL = GetMarkedPIP4SL(_parent.ReferenceOrderRow.Instrument);
        //        double diffTP = GetMarkedPIP4SL(_parent.ReferenceOrderRow.Instrument);
        //        if (_parent.ReferenceOrderRow.Side == clsInterface4OME.Side.BUY.ToString())
        //        {
        //            btnCopy4SL.Text = string.Format(Initializer.getPriceFormat(_parent.ReferenceOrderRow.Instrument),
        //                                         (QR.BidPx_ - diffSL));
        //            btnCopy4TP.Text = string.Format(Initializer.getPriceFormat(_parent.ReferenceOrderRow.Instrument),
        //                                         (QR.BidPx_ + diffTP));
        //        }
        //        else
        //        {
        //            btnCopy4SL.Text = string.Format(Initializer.getPriceFormat(_parent.ReferenceOrderRow.Instrument),
        //                (QR.AskPx_ + diffSL));
        //            btnCopy4TP.Text = string.Format(Initializer.getPriceFormat(_parent.ReferenceOrderRow.Instrument),
        //               (QR.AskPx_ - diffTP));
        //        }
        //    }
        //    else
        //    {
        //        //Throw exception here
        //    }
        //}
        //double GetMarkedPIP4TP(string symbol)
        //{
        //    double val = Convert.ToDouble(cmbMarkUp4TP.SelectedItem);
        //    if (symbol.Contains("JPY"))
        //    {
        //        return (double)val / 100;
        //    }
        //    else
        //    {
        //        return (double)val / 10000;
        //    }

        //}
        //double GetMarkedPIP4SL(string symbol)
        //{
        //    double val = Convert.ToDouble(cmbMarkUp4SL.SelectedItem);
        //    if (symbol.Contains("JPY"))
        //    {
        //        return (double)val / 100;
        //    }
        //    else
        //    {
        //        return (double)val / 10000;
        //    }

        //}
        //public void setLock(bool Flag)
        //{
        //    btnModify.Enabled = Flag;
        //    if (Flag == false)
        //    {
        //        btnModify.BackColor = Color.WhiteSmoke;
        //    }
        //    else
        //    {
        //        setColor4BuySell();
        //    }
        //}
        public event Action<double,double,double,double> OnModifyFill = delegate { };
        # region EventHandlers

        private void btnCopy4SL_Click(object sender, EventArgs e)
        {
            cmbSLValue.Value = Convert.ToDecimal(btnCopy4SL.Text);

        }

        private void btnCopy4TP_Click(object sender, EventArgs e)
        {
            cmbTPValue.Value = Convert.ToDecimal(btnCopy4TP.Text);
        }

        private void cmbTPValue_ValueChanged(object sender, EventArgs e)
        { 
            //if (cmbTPValue.Value <= 0.0M)
            //    btnCopy4TP.PerformClick();
            //_parent.CurrentOrder.TP = (double)cmbTPValue.Value;
            //_parent.updateSLTP(cmbSLValue.Value, cmbTPValue.Value);
            //setModifyText();
            //_parent.validateOrderOnModify(_parent.CurrentOrder);
        }

        private void cmbSLValue_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbSLValue.Value <= 0.0M)
            //    btnCopy4SL.PerformClick();
            //setModifyText();
            //_parent.CurrentOrder.SL = (double)cmbSLValue.Value;
            //_parent.updateSLTP(cmbSLValue.Value, cmbTPValue.Value);
            //_parent.validateOrderOnModify(_parent.CurrentOrder);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            double newSl=0;
            double newTP = 0;
            if (txtSL.Text != string.Empty)
                newSl = Convert.ToDouble(txtSL.Text);
            if(txtTP.Text!=string.Empty)
                newTP=Convert.ToDouble(txtTP.Text);

            OnModifyFill(newSl, newTP, currentSl, currentTp);
            //_parent.CurrentOrder.RequestType = clsInterface4OME.OrderRequestType.MODIFIED;
            //_parent.ModifyOrder();
        }
      
        private void cmbMarkUp4SL_SelectedIndexChanged(object sender, EventArgs e)
        {
            //OrderValidation.Level4SL = Convert.ToInt32(cmbMarkUp4SL.SelectedItem);
            //setSL_TPValue();
        }

        private void cmbMarkUp4TP_SelectedIndexChanged(object sender, EventArgs e)
        {
            //OrderValidation.Level4TP = Convert.ToInt32(cmbMarkUp4TP.SelectedItem);
            //setSL_TPValue();
        }

        private void cmbSLValue_MouseDown(object sender, MouseEventArgs e)
        {
            //if (cmbSLValue.Value <= 0.0M)
            //    btnCopy4SL.PerformClick();
        
        }

        private void cmbTPValue_MouseDown(object sender, MouseEventArgs e)
        {
            //if (cmbTPValue.Value <= 0.0M)
            //    btnCopy4TP.PerformClick();
        }

        # endregion
        public event Action<string> OnSLMouseDown = delegate { };
        public event Action<string> OnTPMouseDown = delegate { };
        private void txtSL_MouseDown(object sender, MouseEventArgs e)
        {
            OnSLMouseDown(txtSL.Text);
        }

        private void txtTP_MouseDown(object sender, MouseEventArgs e)
        {
            OnTPMouseDown(txtTP.Text);
        }
    }
}
