using System;
using System.Drawing;
using System.Windows.Forms;

namespace PALSA.uctl
{
    public partial class ctlMarketDepthGraph : UserControl
    {
        #region variables

        public double Ask;
        public double Bid;
        public long AskSize;
        public long BidSize;

        private int MiddleWidth
        {
            get
            {
                return (int)Math.Round(this.Width * 0.1);
            }
        }

        #endregion

        public ctlMarketDepthGraph()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Bid + Ask == 0 || BidSize + AskSize == 0) return;

            Color borderColor = Color.Black;
            Color backColor = Color.Black;
            Color bidColor = Color.Green;
            Color askColor = Color.Red;
            Font textFont = new Font("Time new roman", 10);
            int Vidstup = 10;

            double pricePer = Bid + Ask == 0 ? 0 : ((double)(Bid - Ask) / (Bid + Ask)) * 100.00;
            double sizePer = BidSize + AskSize == 0 ? 0 : ((double)(BidSize - AskSize) / (BidSize + AskSize)) * 100.00;
            string pricePerStr = /*(Ask>Bid? "-":string.Empty) +*/ pricePer.ToString("0.00") + "%";
            string sizePerStr = /*(AskSize > BidSize ? "-" : string.Empty) +*/ sizePer.ToString("0.00") + "%";
            int tempX, tempWidth;
            SizeF tempSize;

            Graphics gr = e.Graphics;
            gr.FillRectangle(new SolidBrush(backColor), 0, 0, this.Width, this.Height);
            //bid
            tempWidth = (int)((Bid == 0 ? Bid : (double)Bid / (Bid + Ask)) * (this.Width - MiddleWidth) / 2);
            tempX = (this.Width - MiddleWidth) / 2 - tempWidth;
            gr.FillRectangle(new SolidBrush(bidColor), tempX, 0, tempWidth, this.Height / 2);
            tempWidth = (int)((BidSize == 0 ? BidSize : (double)BidSize / (BidSize + AskSize)) * (this.Width - MiddleWidth) / 2);
            tempX = (this.Width - MiddleWidth) / 2 - tempWidth;
            tempSize = gr.MeasureString(Bid.ToString(), textFont);

            //tempSize = gr.MeasureString(Ask.ToString(), textFont);
            //tempX += Vidstup;
            int tempXX = (int)((this.Width - MiddleWidth) / 2 - tempSize.Width - Vidstup);
            gr.DrawString(Bid.ToString(), textFont, new SolidBrush(borderColor), tempXX, (this.Height / 2 - tempSize.Height) / 2);

            //gr.DrawString(Bid.ToString(), textFont, new SolidBrush(borderColor), tempX, (this.Height / 2 - tempSize.Height) / 2 + this.Height / 2);
            gr.FillRectangle(new SolidBrush(bidColor), tempX, this.Height / 2, tempWidth, this.Height / 2);
            tempSize = gr.MeasureString(BidSize.ToString(), textFont);
            tempX = (int)((this.Width - MiddleWidth) / 2 - tempSize.Width - Vidstup);
            gr.DrawString(BidSize.ToString(), textFont, new SolidBrush(borderColor), tempX, (this.Height / 2 - tempSize.Height) / 2 + this.Height / 2);
            //ask
            tempWidth = (int)((Ask == 0 ? Ask : (double)Ask / (Bid + Ask)) * (this.Width - MiddleWidth) / 2);
            tempX = (this.Width - MiddleWidth) / 2 + MiddleWidth;
            gr.FillRectangle(new SolidBrush(askColor), tempX, 0, tempWidth, this.Height / 2);
            tempSize = gr.MeasureString(Ask.ToString(), textFont);
            tempX += Vidstup;
            gr.DrawString(Ask.ToString(), textFont, new SolidBrush(borderColor), tempX, (this.Height / 2 - tempSize.Height) / 2);
            //Ask size
            tempWidth = (int)((AskSize == 0 ? AskSize : (double)AskSize / (BidSize + AskSize)) * (this.Width - MiddleWidth) / 2);
            tempX = (this.Width - MiddleWidth) / 2 + MiddleWidth;
            gr.FillRectangle(new SolidBrush(askColor), tempX, this.Height / 2, tempWidth, this.Height / 2);
            tempSize = gr.MeasureString(AskSize.ToString(), textFont);
            tempX += Vidstup;
            gr.DrawString(AskSize.ToString(), textFont, new SolidBrush(borderColor), tempX, (this.Height / 2 - tempSize.Height) / 2 + this.Height / 2);
            // price percent
            gr.FillRectangle(new SolidBrush(Bid > Ask ? bidColor : askColor), (this.Width - MiddleWidth) / 2, 0, MiddleWidth, this.Height / 2);
            tempSize = gr.MeasureString(pricePerStr, textFont);
            tempX = (int)((this.Width - MiddleWidth) / 2 + (MiddleWidth - tempSize.Width) / 2);
            gr.DrawString(pricePerStr, textFont, new SolidBrush(borderColor), tempX, (this.Height / 2 - tempSize.Height) / 2);
            // size per
            gr.FillRectangle(new SolidBrush(BidSize > AskSize ? bidColor : askColor), (this.Width - MiddleWidth) / 2, this.Height / 2, MiddleWidth, this.Height);
            tempSize = gr.MeasureString(sizePerStr, textFont);
            tempX = (int)((this.Width - MiddleWidth) / 2 + (MiddleWidth - tempSize.Width) / 2);
            gr.DrawString(sizePerStr, textFont, new SolidBrush(borderColor), tempX, this.Height / 2 + (this.Height / 2 - tempSize.Height) / 2);


            gr.DrawRectangle(new Pen(new SolidBrush(borderColor)), 0, 0, this.Width - 1, this.Height - 1);
            gr.DrawRectangle(new Pen(new SolidBrush(borderColor)), (this.Width - MiddleWidth) / 2, 0, MiddleWidth - 1, this.Height - 1);
            gr.DrawLine(new Pen(new SolidBrush(borderColor)), 0, this.Height / 2, this.Width, this.Height / 2);
        }


    }
}
