///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//22/02/2012	VP		    1.Desgining and coding of the control
//                          2.Added method for displaying script portfolio dialog and applying there values
//23/02/2012	VP		    1.Code for stopping ticker on MouseOver of the ticker
//24/02/2012	VP		    1.Added regions for the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.UserControls;
using TWS.Cls;

namespace TWS
{
    public partial class uctlTickerControl : UctlBase
    {
        #region "       MEMBERS      "

        private readonly int _PanelWidth;
        private readonly List<Control> controls = new List<Control>();

        private readonly Panel panel = new Panel();
        private int _PanelBegin;
        protected Timer _ScrollerTimer;
        public string _currentTickerPortfolio;
        private object _lstportfolio;

        private delegate void AddControlDelegate(List<Control> controls);

        #endregion "    MEMBERS      "

        #region "    CONSTRUCTORS    "

        public object PortfolioList
        {
            set { _lstportfolio = value; }
        }

        #endregion " CONSTRUCTORS    "

        #region "       METHODS      "

        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();

        public uctlTickerControl()
        {
            InitializeComponent();

            _PanelBegin = Width;
            _PanelWidth = Location.X - 10;
            BackColor = Color.Transparent;

            panel.BackColor = Color.Transparent;
            panel.AutoSize = true;
            panel.MouseClick += panel_MouseClick;
            panel.MouseHover += panel_MouseHover;
            panel.MouseLeave += panel_MouseLeave;

            Controls.Add(panel);
            Initialise();
        }

        public void SetTickerSpeed(int tickerSpeed)
        {
            if (tickerSpeed != 0)
                _ScrollerTimer.Interval = tickerSpeed;
            else
                _ScrollerTimer.Interval = 30;
        }

        private void panel_MouseLeave(object sender, EventArgs e)
        {
            _ScrollerTimer.Enabled = true;
        }

        private void panel_MouseHover(object sender, EventArgs e)
        {
            _ScrollerTimer.Enabled = false;
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DisplayPortfolioDialog();
            }
            else
            {
            }
        }

        private void panel_Click(object sender, EventArgs e)
        {
            DisplayPortfolioDialog();
        }

        public void AddControls(List<Control> newControls)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new AddControlDelegate(AddControls), newControls);
                return;
            }
            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -=  INSTANCE_onPriceUpdate;

            StopTimer();
            ClearControls();

            int controlXBegin = _PanelBegin - 100;
            int controlY = 8;
            int startX = controlXBegin;

            for (int i = 0; i < newControls.Count; i++)
            {
                Control control = newControls[i];
                control.Location = new Point(startX, controlY);
                panel.Controls.Add(control);                
                controls.Add(control);

                startX += control.Width + 8;
            }
            StartTimer();

            clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += INSTANCE_onPriceUpdate;
        }

        public void SetStartX(int x)
        {
            _PanelBegin = x;
        }

        public void ClearControls()
        {
            controls.Clear();
            panel.Controls.Clear();
        }

        private void Initialise()
        {
            CheckForIllegalCrossThreadCalls = false;
            DoubleBuffered = true;

            SetStyle(ControlStyles.DoubleBuffer |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);

            UpdateStyles();
            SetupScrollerTimer();
        }

        private void SetupScrollerTimer()
        {
            _ScrollerTimer = new Timer();
            _ScrollerTimer.Interval = 25;
            _ScrollerTimer.Tick += _ScrollerTimer_Tick;
        }

        private void StartTimer()
        {
            _ScrollerTimer.Start();
        }

        private void StopTimer()
        {
            _ScrollerTimer.Stop();
        }

        /// <summary>
        /// Moves the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _ScrollerTimer_Tick(object sender, EventArgs e)
        {
            if (controls.Count == 0)
                return;

            if (controls.Count <= 12)
            {
                for (int i = 0; i < controls.Count; i++)
                {
                    Control control = controls[i];
                    if (control.Location.X <= (_PanelWidth - control.Width))
                    {
                        control.Location =
                            new Point(Screen.PrimaryScreen.WorkingArea.Width - control.Width,
                                      control.Location.Y);
                    }
                    else
                    {
                        control.Location = new Point(control.Location.X - 1, control.Location.Y);
                    }
                }
            }
            else
            {
                for (int i = 0; i < controls.Count; i++)
                {
                    Control control = controls[i];
                    if (control.Location.X <= (_PanelWidth - control.Width))
                    {
                        if (i == 0)
                        {
                            Control lastControl = controls[controls.Count - 1];
                            control.Location = new Point(lastControl.Location.X + lastControl.Width + 2,
                                                         control.Location.Y);
                        }
                        else
                        {
                            Control lastControl = controls[i - 1];
                            control.Location = new Point(lastControl.Location.X + lastControl.Width + 2,
                                                         control.Location.Y);
                        }
                    }
                    else
                    {
                        control.Location = new Point(control.Location.X - 1, control.Location.Y);
                    }
                }
            }

            Refresh();
        }

        /// <summary>
        /// Updates the particular control value
        /// </summary>
        /// <param name="sens"></param>
        public void UpdateControl(ClsTickerInfo tickerInfo, ImageType imType)
        {

            string imageControlID = "pb" + tickerInfo.ID;

            Action A = () =>
                           {
                               //lock (panel.Controls)
                               {
                                   try
                                   {
                                       if (panel.Controls.ContainsKey(tickerInfo.ID))
                                       {
                                           var controlText = new string[6];
                                           controlText = panel.Controls[tickerInfo.ID].Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                           //panel.Controls[tickerInfo.ID].Text = String.Format("{0} {1:ddMMMyyyy} {2} @ {3:0000.00}", controlText[0], controlText[1], tickerInfo.LastTradedQuantity, tickerInfo.LastTradedPrice.ToString());


                                           panel.Controls[tickerInfo.ID].Text =
                                               String.Format("{0}  {1} @ {2:0000.00}", controlText[0], tickerInfo.LastTradedQuantity, tickerInfo.LastTradedPrice);
                                           if (imType == ImageType.UP_ARROW)
                                           {
                                               //((PictureBox)panel.Controls[imageControlID]).Image = Image.FromFile(Application.StartupPath + "\\Resx\\UpArrow.png");
                                               panel.Controls[tickerInfo.ID].ForeColor = Color.Green;
                                               ((PictureBox)panel.Controls[imageControlID]).Image = Properties.Resources.UpArrow;
                                               
                                           }
                                           else if (imType == ImageType.DOWN_ARROW)
                                           {
                                               // ((PictureBox)panel.Controls[imageControlID]).Image = Image.FromFile(Application.StartupPath + "\\Resx\\DownArrow.png");
                                               panel.Controls[tickerInfo.ID].ForeColor = Color.Red;
                                               ((PictureBox)panel.Controls[imageControlID]).Image = Properties.Resources.DownArrow;
                                               
                                           }
                                           else
                                           {
                                               //((PictureBox)panel.Controls[imageControlID]).ImageLocation = Application.StartupPath + "\\Resx\\Unchanged.png";
                                               panel.Controls[tickerInfo.ID].ForeColor = Color.Black;
                                               ((PictureBox)panel.Controls[imageControlID]).Image = Properties.Resources.Unchanged;
                                               
                                           }
                                           Refresh();
                                           //  UpdateImage(imageControlID, imType);
                                       }
                                   }
                                   catch (Exception ex)
                                   {
                                       MessageBox.Show(ex.Message);
                                   }
                               }
                           };
            if (InvokeRequired)
            {
                BeginInvoke(A);
                return;
            }
            else
            {
                A();
            }


        }

        public void UpdateImage(string imageControlID, ImageType imType)
        {
            try
            {
                if (imType == ImageType.UP_ARROW)
                {
                    //((PictureBox)panel.Controls[imageControlID]).ImageLocation = Application.StartupPath +
                    //                                                              "\\Resx\\UpArrow.png";
                    ((PictureBox)panel.Controls[imageControlID]).Image = Image.FromFile(Application.StartupPath + "\\Resx\\UpArrow.png");
                }
                else if (imType == ImageType.DOWN_ARROW)
                {
                    //((PictureBox)panel.Controls[imageControlID]).ImageLocation = Application.StartupPath +
                    //                                                              "\\Resx\\DownArrow.png";
                    ((PictureBox)panel.Controls[imageControlID]).Image = Image.FromFile(Application.StartupPath + "\\Resx\\DownArrow.png");
                }
            }
            catch (Exception)
            {

            }

        }

        public void DisplayPortfolioDialog()
        {
            try
            {
                var objuctlSelectPortfolio = new UctlSelectPortfolio(_lstportfolio);
                objuctlSelectPortfolio.OnCancelClick += objuctlSelectPortfolio_OnCancelClick;
                objuctlSelectPortfolio.OnApplyClick += objuctlSelectPortfolio_OnApplyClick;
                objuctlSelectPortfolio.OnModifyClick += objuctlSelectPortfolio_OnModifyClick;
                objuctlSelectPortfolio.OnRemoveClick += objuctlSelectPortfolio_OnRemoveClick;
                _objfrmDialogForm.Controls.Clear();
                var objSize = new Size(objuctlSelectPortfolio.Width + 8, objuctlSelectPortfolio.Height + 28);
                _objfrmDialogForm.Size = objSize;
                _objfrmDialogForm.Controls.Add(objuctlSelectPortfolio);
                _objfrmDialogForm.Dock = DockStyle.Fill;
                _objfrmDialogForm.Text = objuctlSelectPortfolio.Title;
                _objfrmDialogForm.Sizable = false;
                _objfrmDialogForm.MinimizeBox = false;
                _objfrmDialogForm.CloseButton = false;
                //_objfrmDialogForm.BackColor.A = 255;
                    //"{Name=ffe4f4fb, ARGB=(255, 228, 244, 251)}"
                _objfrmDialogForm.StartPosition = FormStartPosition.CenterScreen;
                _objfrmDialogForm.ShowDialog();
            }
            catch (Exception)
            {
            }

        }

        private void objuctlSelectPortfolio_OnApplyClick(string portfilioName)
        {
            _currentTickerPortfolio = portfilioName;
            OnPortFolioApplyClick(portfilioName);
            Properties.Settings.Default.LastTickerPortfolio = _currentTickerPortfolio;
            Properties.Settings.Default.Save();
            _objfrmDialogForm.Close();
        }

        private void objuctlSelectPortfolio_OnCancelClick(object arg1, EventArgs arg2)
        {
            _objfrmDialogForm.Close();
        }

        private void objuctlSelectPortfolio_OnModifyClick(string portfilioName)
        {
            // OnScriptPortfolioModifyClick(portfilioName);
        }

        private void objuctlSelectPortfolio_OnRemoveClick(string portfilioName)
        {
            // OnScriptPortfolioRemoveClick(portfilioName);
        }

        #endregion "     METHODS      "

        #region "        EVENTS       "

        public event Action<string> OnPortFolioApplyClick;

        #endregion "     EVENTS       "

        private void uctlTickerControl_Load(object sender, EventArgs e)
        {
            //Cls.clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += new Action<Dictionary<string, ClientDLL_Model.Cls.Market.Quote>>(INSTANCE_onPriceUpdate);
        }

        private void INSTANCE_onPriceUpdate(QuotesStream _QuotesStream)
        {
           

            foreach (var quotes in _QuotesStream.QuotesItem)
            {
                try
                {
                    if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(quotes.Contract) && quotes.MarketLevel == 0)
                    {
                        InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[quotes.Contract];
                        ImageType imageType;
                        var objclsTickerInfo = new ClsTickerInfo();
                      
                        switch (quotes.QuotesStreamType)
                        {
                            case "L":
                                {
                                    long _size = quotes.Size;
                                    if (spec != null && spec.ContractSize > 0)
                                    {
                                        _size = (long)(quotes.Size / spec.ContractSize);
                                    }
                                    double _Price = quotes.Price / Math.Pow(10, spec.Digits);
                                    double prevPrice = objclsTickerInfo.LastTradedPrice;
                                    long prevSize = 0;
                                    long.TryParse(objclsTickerInfo.LastTradedQuantity, out prevSize);
                                    objclsTickerInfo.ID = quotes.Gateway + "_" + quotes.ProductType + "_" + quotes.Product + "_" + quotes.Contract;
                                    //objclsTickerInfo.ID = spec.Gateway + "_" + spec.ProductType + "_" + spec.Product + "_" + spec.Contract;
                                    objclsTickerInfo.LastTradedPrice = _Price;
                                    objclsTickerInfo.LastTradedQuantity = _size.ToString();

                                    if (prevPrice > _Price) //Down
                                    {
                                        imageType = ImageType.DOWN_ARROW;
                                    }
                                    else if (prevPrice < _Price) //UP
                                    {
                                        imageType = ImageType.UP_ARROW;
                                    }
                                    else //Unchanged
                                    {
                                        imageType = ImageType.NO_CHANGE;
                                    }

                                    if (panel.Controls.ContainsKey(objclsTickerInfo.ID))
                                    {
                                        UpdateControl(objclsTickerInfo, imageType);
                                    }
                                }
                                break;
                            default:
                                break;
                        }

                    }

                }
                catch (Exception)
                {

                }
            }
        }    
    }
}