///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//22/02/2012	NAMO	    1.Desgining and coding of the control
//                          2.Added method for displaying script portfolio dialog and applying there values
//23/02/2012	NAMO	    1.Code for stopping ticker on MouseOver of the ticker
//24/02/2012	NAMO	    1.Added regions for the code
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.UserControls;
using PALSA.Cls;

namespace PALSA
{
    public partial class uctlTickerControl : UserControl
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
            //panel.MouseClick += panel_MouseClick;
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
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -=
            //    INSTANCE_onPriceUpdate;

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

                startX += control.Width+4;// +1;
            }
            StartTimer();

            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate +=
            //    INSTANCE_onPriceUpdate;
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
            //try
            {
                string imageControlID = "pb" + tickerInfo.ID;

                Action A = () =>
                               {
                                   lock (panel.Controls)
                                   {
                                       if (panel.Controls.ContainsKey(tickerInfo.ID))
                                       {
                                           var controlText = new string[6];
                                           controlText = panel.Controls[tickerInfo.ID].Text.Split(new[] {' '},
                                                                                                  StringSplitOptions.
                                                                                                      RemoveEmptyEntries);
                                           panel.Controls[tickerInfo.ID].Text =
                                               String.Format("{0} {1:ddMMMyyyy} {2} @ {3:0000.00}", controlText[0],
                                                             controlText[1], tickerInfo.LastTradedQuantity,
                                                             tickerInfo.LastTradedPrice);

                                           //if (imType == ImageType.UP_ARROW)
                                           //{
                                           //    ((PictureBox)this.panel.Controls[imageControlID]).ImageLocation = Application.StartupPath + "Resx\\UpArrow.png";
                                           //}
                                           //else if (imType == ImageType.DOWN_ARROW)
                                           //{
                                           //    ((PictureBox)this.panel.Controls[imageControlID]).ImageLocation = Application.StartupPath + "Resx\\DownArrow.png";
                                           //}
                                           //else
                                           //{
                                           //    ((PictureBox)this.panel.Controls[imageControlID]).ImageLocation = Application.StartupPath + "Resx\\DownArrow.png";
                                           //}
                                           UpdateImage(imageControlID, imType);
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
            //catch (Exception ex)
            {
            }
            //UpdateImage(imageControlID, imType);
        }

        public void UpdateImage(string imageControlID, ImageType imType)
        {
            //Action A = () =>
            //{
            if (imType == ImageType.UP_ARROW)
            {
                ((PictureBox) panel.Controls[imageControlID]).ImageLocation = Application.StartupPath +
                                                                              "\\Resx\\UpArrow.png";
            }
            else if (imType == ImageType.DOWN_ARROW)
            {
                ((PictureBox) panel.Controls[imageControlID]).ImageLocation = Application.StartupPath +
                                                                              "\\Resx\\DownArrow.png";
            }
            //else
            //{
            //    ((PictureBox)this.panel.Controls[imageControlID]).ImageLocation = Application.StartupPath + "\\Resx\\Unchanged.png";
            //}
            //};

            //if (this.InvokeRequired)
            //{
            //    this.BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}
        }

        public void DisplayPortfolioDialog()
        {
            var objuctlSelectPortfolio = new UctlSelectPortfolio(_lstportfolio);
            objuctlSelectPortfolio.OnCancelClick += objuctlSelectPortfolio_OnCancelClick;
            objuctlSelectPortfolio.OnApplyClick += objuctlSelectPortfolio_OnApplyClick;
            objuctlSelectPortfolio.OnModifyClick += objuctlSelectPortfolio_OnModifyClick;
            objuctlSelectPortfolio.OnRemoveClick += objuctlSelectPortfolio_OnRemoveClick;
            _objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objuctlSelectPortfolio.Width + 8, objuctlSelectPortfolio.Height + 28);
            _objfrmDialogForm.Size = objSize;
            objuctlSelectPortfolio.Dock = DockStyle.Fill;
            _objfrmDialogForm.Controls.Add(objuctlSelectPortfolio);
            _objfrmDialogForm.Dock = DockStyle.Fill;
            _objfrmDialogForm.Text = objuctlSelectPortfolio.Title;
            _objfrmDialogForm.Sizable = false;
            _objfrmDialogForm.MinimizeBox = false;
            _objfrmDialogForm.CloseButton = false;
            _objfrmDialogForm.StartPosition = FormStartPosition.CenterScreen;
            _objfrmDialogForm.ShowDialog();
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
            //Cls.clsTWSDataManager.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
        }

        private void INSTANCE_onPriceUpdate(Dictionary<string, Quote> obj)
        {
            ImageType imageType;
            var objclsTickerInfo = new ClsTickerInfo();

            foreach (var item in obj)
            {
                //Namo 21 March
                //foreach (QuoteItem item2 in item.Value._lstItem)
                //{
                //    if (item2._quoteType == QuoteStreamType.LAST)
                //    {
                //        //objclsTickerInfo = new clsTickerInfo();
                //        objclsTickerInfo.ID = item.Key;
                //        objclsTickerInfo.LastTradedPrice = item2._Price;
                //        objclsTickerInfo.LastTradedQuantity = item2._Size.ToString();

                //        if (item2._status == QuoteItemStatus.DOWN) //Down
                //        {
                //            imageType = ImageType.DOWN_ARROW;
                //        }
                //        else if (item2._status == QuoteItemStatus.UP) //UP
                //        {
                //            imageType = ImageType.UP_ARROW;
                //        }
                //        else //Unchanged
                //        {
                //            imageType = ImageType.NO_CHANGE;
                //        }

                //        if (panel.Controls.ContainsKey(item.Key))
                //        {
                //            UpdateControl(objclsTickerInfo, imageType);
                //        }
                //    }
                //}
            }
        }
    }
}