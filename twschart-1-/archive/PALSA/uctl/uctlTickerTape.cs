///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//22/02/2012	NAMO	    1.Desgining and coding of the control
//24/02/2012	NAMO	    1.Added regions for the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PALSA
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
                //    (String.Format("{0} {1:ddMMMyyyy} {2} @ {3:0000.00}", tickerInfo.Symbol, tickerInfo.ExpiryDate,
                //                   tickerInfo.LastTradedQuantity, tickerInfo.LastTradedPrice));
               
                //if (!sensList.ContainsKey(article))
                //{
                //    sensList.Add(article, tickerInfo);
                    //var pb = new PictureBox();
                    //pb.Name = "pb" + tickerInfo.ID;
                    //pb.Size = new Size(25, 16);
                    //pb.SizeMode = PictureBoxSizeMode.AutoSize;
                    ////pb.ImageLocation = Application.StartupPath + "\\Resx\\Unchanged.png";
                    //pb.ImageLocation = Application.StartupPath + "\\Resources\\myphoto.ico";

                    //controls.Add(pb);
                    string[] arr = newSensList[0].Symbol.Split(' ');
                    foreach (string x in arr)
                    {
                        
                        var label = new Label();
                        label.Text = x.ToString() ;
                        //label.Text = article;
                        label.Name = tickerInfo.ID;
                        label.ForeColor = Color.Black; //USED to set the forecolor for up and down trends 
                        label.Font = new Font(new FontFamily("Microsoft Sans Serif"), 12f, FontStyle.Bold);
                        label.AutoSize = true;
                        label.MouseClick += label_MouseClick;
                        label.MouseHover += label_MouseHover;
                        label.MouseLeave += label_MouseLeave;
                        controls.Add(label);
                        if (Array.IndexOf(arr, x) + 1 == arr.Length)
                        {
                            var label1 = new Label();
                            label1.Text = ".                ";
                            //label.Text = article;
                            label1.Name = tickerInfo.ID;
                            label1.ForeColor = Color.Black; //USED to set the forecolor for up and down trends 
                            label1.Font = new Font(new FontFamily("Microsoft Sans Serif"), 12f, FontStyle.Bold);
                            label1.AutoSize = true;
                            label1.MouseClick += label_MouseClick;
                            label1.MouseHover += label_MouseHover;
                            label1.MouseLeave += label_MouseLeave;
                            controls.Add(label1);
                        }
                       
                    }
                   
                //}
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