///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//22/02/2012	VP		    1.Desgining and coding of the control
//24/02/2012	VP		    1.Added regions for the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TWS
{
    public partial class UctlTickerTape : uctlTickerControl
    {
        #region "       MEMBERS      "

        #region Delegates

        public delegate void SensSelectedDelegate(ClsTickerInfo sens);

        #endregion

        private readonly Dictionary<string, ClsTickerInfo> sensList = new Dictionary<string, ClsTickerInfo>();

        //public event SensSelectedDelegate SensSelectedEvent;

        #endregion "    MEMBERS      "

        #region "    CONSTRUCTORS    "

        public UctlTickerTape()
        {
            InitializeComponent();
            BackColor = Color.WhiteSmoke;
        }

        #endregion " CONSTRUCTORS    "

        #region "       METHODS      "

        public void AddSensArticles(List<ClsTickerInfo> newSensList)
        {
            var controls = new List<Control>();
            sensList.Clear();

            foreach (ClsTickerInfo tickerInfo in newSensList)
            {
                //string article =
                //    (String.Format("{0} {1:ddMMMyyyy} {2} @ {3:0000.00}", tickerInfo.Symbol, tickerInfo.ExpiryDate, tickerInfo.LastTradedQuantity, tickerInfo.LastTradedPrice));
                string article = (String.Format("{0} {1} @ {2:0000.00}", tickerInfo.Symbol, tickerInfo.LastTradedQuantity, tickerInfo.LastTradedPrice.ToString("0000.00")));

                if (!sensList.ContainsKey(article))
                {
                    sensList.Add(article, tickerInfo);

                    var label = new Label();
                    label.AutoSize = true;
                    label.Text = article;
                    label.Name = tickerInfo.ID;
                    label.ForeColor = Color.Black; //USED to set the forecolor for up and down trends 
                    label.Font = new Font(label.Font, FontStyle.Bold);                                    
                    label.MouseClick += label_MouseClick;
                    label.MouseHover += label_MouseHover;
                    label.MouseLeave += label_MouseLeave;
                   
                    controls.Add(label);
                    var pb = new PictureBox();
                    pb.Name = "pb" + tickerInfo.ID;
                    pb.Size = new Size(16, 16);
                    pb.SizeMode = PictureBoxSizeMode.AutoSize;                    
                    pb.ImageLocation = Application.StartupPath + "\\Resx\\Unchanged.png";
                    controls.Add(pb);
                }
            }
            AddControls(controls);
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            _ScrollerTimer.Enabled = true;
        }

        private void label_MouseHover(object sender, EventArgs e)
        {
            _ScrollerTimer.Enabled = false;
        }

        private void label_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DisplayPortfolioDialog();
            }
            else
            {
            }
        }

        public void UpdateControlValues(ClsTickerInfo sens)
        {
            //this.UpdateControl(sens);
        }

        private void TickerTape_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DisplayPortfolioDialog();
            }
            else
            {
            }
        }

        private void uctlTickerTape_MouseHover(object sender, EventArgs e)
        {
            _ScrollerTimer.Enabled = false;
        }

        private void uctlTickerTape_MouseLeave(object sender, EventArgs e)
        {
            _ScrollerTimer.Enabled = true;
        }

        #endregion "     METHODS    "
    }

    public class ClsTickerInfo
    {
        public string Symbol { get; set; }
        //public DateTime ExpiryDate { get; set; }
        public string ExpiryDate { get; set; }
        public string LastTradedQuantity { get; set; }
        public double LastTradedPrice { get; set; }
        public string ID { get; set; }
    }

    public enum ImageType
    {
        UP_ARROW,
        DOWN_ARROW,
        NO_CHANGE
    }
}