using System;
using System.Windows.Forms;
//using FundXchange.Model.ViewModels.Charts;
//using FundXchange.Model.Infrastructure;
//using FundXchange.Infrastructure;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;

//M4 Trading Platform - copyright Modulus Financial Engineering, Inc. - all rights reserved.
//http://www.modulusfe.com

namespace PALSA.FrmScanner
{
    public partial class frmSelectChart : NForm
    {
        private ChartSelection m_selection = new ChartSelection();
        //Kul private IMarketRepository _Repository;
        private int _MaxDaysData = 15000;

        public frmSelectChart()
        {
            //Kul _Repository = _Repository = IoC.Resolve<IMarketRepository>();
            InitializeComponent();
            txtSymbol.GotFocus += (sender, e) => txtSymbol.SelectAll();
            cboInterval.SelectedIndex = 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            int minutesRequested = 0;
            m_selection.Symbol = txtSymbol.Text.Trim();
            string indexSymbol = "";//Kul _Repository.GetIndexSymbol(m_selection.Symbol);
            if (!String.IsNullOrEmpty(indexSymbol))
            {
                m_selection.Symbol = indexSymbol;
            }
            m_selection.Symbol = m_selection.Symbol.ToUpper();

            m_selection.Interval = Convert.ToInt32(cboInterval.Text);
            m_selection.Bars = (int)nudHistory.Value;
            switch (cboPeriodicity.Text)
            {
                case "Minute":
                    m_selection.Periodicity = Periodicity.Minutely;
                    minutesRequested = m_selection.Bars;
                    break;

                case "Hour":
                    m_selection.Periodicity = Periodicity.Hourly;
                    minutesRequested = m_selection.Bars * 60;
                    break;

                case "Day":
                    m_selection.Periodicity = Periodicity.Daily;
                    minutesRequested = m_selection.Bars * 60 * 8;
                    break;

                case "Week":
                    m_selection.Periodicity = Periodicity.Weekly;
                    minutesRequested = m_selection.Bars * 60 * 8 * 5;
                    break;

                case "Month":
                    m_selection.Periodicity = Periodicity.Monthly;
                    minutesRequested = m_selection.Bars * 60 * 8 * 5 * 4;
                    break;
            }
            int hoursRequested = minutesRequested / 60;
            int daysRequested = hoursRequested / 8;

            if (daysRequested > _MaxDaysData)
            {
                MessageBox.Show("Max amount of days exceeded. Please enter a range smaller than " + _MaxDaysData + " days.",
                    "Max days exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                //Kul
                //Properties.Settings.Default.Symbol = m_selection.Symbol;
                //Properties.Settings.Default.Interval = m_selection.Interval;
                //Properties.Settings.Default.Bars = m_selection.Bars;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        //Gets a chart selection from the user
        public ChartSelection GetChartSelection(bool edit, string smb, string periodicity, int interval)
        {
            if (edit)
            {
                txtSymbol.Enabled = false;
                cboInterval.Text = interval.ToString();
                switch (periodicity)
                {
                    case "Minutely":
                        cboPeriodicity.SelectedIndex = 0;
                        break;
                    case "Hourly":
                        cboPeriodicity.SelectedIndex = 1;
                        break;

                    case "Daily":
                        cboPeriodicity.SelectedIndex = 2;
                        break;

                    case "Weekly":
                        cboPeriodicity.SelectedIndex = 3;
                        break;

                    case "Monthly":
                        cboPeriodicity.SelectedIndex = 4;
                        break;
                }
                SetBars();

                string symbol = smb;
                //Kul
                //if (_Repository.IndexWatchList.ContainsKey(symbol))
                //{
                //    symbol = _Repository.IndexWatchList[symbol].ShortName;
                //}
                txtSymbol.Text = symbol;
            }
            else
            {
                //Kul
                //txtSymbol.Enabled = true;
                //txtSymbol.Text = Properties.Settings.Default.Symbol;
                //SetBars();
                //if ((decimal)Properties.Settings.Default.Interval == 0)
                //{
                //    cboPeriodicity.Text = "1";
                //}
                //else
                //{
                //    cboPeriodicity.Text = Properties.Settings.Default.Interval.ToString();
                //}
                cboPeriodicity.SelectedIndex = 0;
            }

            this.StartPosition = FormStartPosition.CenterScreen;
            ShowDialog();
            return m_selection;
        }

        private void SetBars()
        {
            //Kul
            //if ((decimal)Properties.Settings.Default.Bars == 0)
            //{
            //    nudHistory.Value = 10;
            //}
            //else
            //{
            //    nudHistory.Value = (decimal)Properties.Settings.Default.Bars;
            //}
        }
        private void cboPeriodicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboInterval.SelectedIndex = 0;

            switch (cboPeriodicity.Text)
            {
                case "Hour":
                    cboPeriodicity.Text = "1";
                    cboPeriodicity.Enabled = true;
                    cboInterval.Enabled = false;
                    break;
                case "Day":
                    cboPeriodicity.Text = "1";
                    cboPeriodicity.Enabled = true;
                    cboInterval.Enabled = false;
                    break;
                case "Week":
                    cboPeriodicity.Text = "1";
                    cboPeriodicity.Enabled = true;
                    cboInterval.Enabled = false;
                    break;
                case "Month":
                    cboPeriodicity.Text = "1";
                    cboPeriodicity.Enabled = true;
                    cboInterval.Enabled = false;
                    break;
                default:
                    cboPeriodicity.Enabled = true;
                    cboInterval.Enabled = true;
                    break;
            }
        }

        private void frmSelectChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                m_selection = new ChartSelection();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            m_selection = new ChartSelection();
            DialogResult = DialogResult.Cancel;
        }
    }

    public class ChartSelection
    {
        public string Symbol;
        public Periodicity Periodicity;
        public int Interval;
        public int Bars;
        public TimeSpan Frequency
        {
            get { return GetFrequency(); }
        }

        private TimeSpan GetFrequency()
        {
            switch (Periodicity)
            {   
                case Periodicity.Secondly:
                    return new TimeSpan(0, 0, 0, Interval);
                case Periodicity.Unspecified:
                case Periodicity.Minutely:
                    return new TimeSpan(0, 0, Interval, 0);
                case Periodicity.Hourly:
                    return new TimeSpan(0, Interval, 0, 0);
                case Periodicity.Daily:
                    return new TimeSpan(Interval, 0, 0, 0);
                case Periodicity.Weekly:
                    return new TimeSpan(Interval * 7, 0, 0, 0);
                case Periodicity.Monthly:
                    return new TimeSpan(Interval * 7 * 4, 0, 0, 0);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
