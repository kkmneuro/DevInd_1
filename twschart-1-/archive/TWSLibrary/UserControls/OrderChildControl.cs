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
    public partial class OrderChildControl : UserControl
    {
        public OrderChildControl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        //public virtual void updateOnQuoteChanged(QuoteResponse QR) { }

        //public virtual void updateOnSLChanged(decimal SL) { }

        //public virtual void updateOnPriceChaged(decimal Price) { }

        //public virtual void updateOnTPChanged(decimal TP) { }
        public virtual int Digits { get; set; }
        protected virtual void initControl() { }

        //protected virtual void setPrecisionBehaviour() { }

        //protected virtual void setColor4BuySell() { }

    }
   
}
