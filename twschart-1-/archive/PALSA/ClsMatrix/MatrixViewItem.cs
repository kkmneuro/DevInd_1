using System;
using System.Drawing;
//using FundXchange.Model.ViewModels.Generic;
using System.Collections.Generic;
using PALSA.ClsRadar;

namespace PALSA.ClsMatrix
{
    public class MatrixViewItem
    {
        public double Price { get; set; }
        public Color PriceBackgroundColor { get; set; }
        public int MktLvl { get; set; }
        public GridCell PriceCell
        {
            get
            {
                GridCell cell = new GridCell();
                cell.Text = Price.ToString();
                cell.BackColor = PriceBackgroundColor;
                cell.ForeColor = Color.White;
                return cell;
            }
        }

        public long BidSize { get; set; }
        public long BidOrderCount { get; set; }
        public GridCell BidSizeCell
        {
            get
            {
                GridCell cell = new GridCell();
                cell.ForeColor = Color.White;

                if (BidSize == 0)
                {
                    cell.Text = "";
                    cell.BackColor = Color.DarkBlue;
                }
                else
                {
                    cell.Text = String.Format("{0} ({1})", BidSize, BidOrderCount);
                    cell.BackColor = Color.Blue;
                }
                return cell;
            }
        }
        public long OfferSize { get; set; }
        public long OfferOrderCount { get; set; }
        public GridCell OfferSizeCell
        {
            get
            {
                GridCell cell = new GridCell();
                cell.ForeColor = Color.White;

                if (OfferSize == 0)
                {
                    cell.Text = "";
                    cell.BackColor = Color.DarkRed;
                }
                else
                {
                    cell.Text = String.Format("{0} ({1})", OfferSize, OfferOrderCount);
                    cell.BackColor = Color.Red;
                }
                return cell;
            }
        }
        public long TradeVolume { get; set; }
        public long TradeAtBidSize { get; set; }
        public long TradeAtOfferSize { get; set; }
        public long TradeAtBetSize { get; set; }
        public List<long> TimeTradeVolume { get; set; }
    }
}