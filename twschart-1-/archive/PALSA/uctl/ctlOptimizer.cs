using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
//using FundXchange.Infrastructure;
//using FundXchange.Model.Infrastructure;
//using FundXchange.Model.ViewModels.Charts;
using TradeScriptLib;
using PALSA.Cls;
using PALSA.FrmScanner;
using M4;

namespace PALSA.uctl
{
    public partial class ctlOptimizer : UserControl
    {
        private const string PERIOD_ONE_PARAMETER = "$p1";
        private const string PERIOD_TWO_PARAMETER = "$p2";

        private Backtest oBacktest;
        private double m_MaxProfit;
        private int m_BestPeriodOne;
        private int m_BestPeriodTwo;
        private readonly List<string> _backtestResults;
        private bool _periodOneUsed;
        private bool _periodTwoUsed;
        private Thread _optimiserThread;

        public ctlOptimizer()
        {
            InitializeComponent();
            cboPeriodicity.SelectedIndex = 0;
            _backtestResults = new List<string>();
            numMin.DataBindings.Add("Maximum",numMax,"Value");
            numMax.DataBindings.Add("Minimum",numMin,"Value");

            oBacktest = new BacktestClass { License = "XRT93NQR79ABTW788XR48" };

            txtSymbol.Text = "EURUSD";//KulProperties.Settings.Default.Symbol.Length > 3 ? "AGL" : Properties.Settings.Default.Symbol;
            cboInterval.SelectedIndex = 0;
            txtBars.Text = "650";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _optimiserThread.Abort();
            }
            catch{}

            ToggleEnabled(true);
            ToggleVisible(false);
        }

        private void btnOptimiza_Click(object sender, EventArgs e)
        {
            ToggleEnabled(false);
            ToggleVisible(true);

            ChartSelection selection = InitDate();
            if (selection == null) return;

            BarDataNew[] bars = null;//m_ctlData.GetHistory(selection.Symbol, null, selection.Periodicity, selection.Interval, selection.Bars).ToArray();

            if (bars.Length < 3)
            {
                MessageBox.Show(string.Format("Failed load {0}", selection.Symbol), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }

            oBacktest = new BacktestClass { License = "XRT93NQR79ABTW788XR48" };
            _backtestResults.Clear();

            double jDate = 0;
            DateTime date;

            for (int j = 1; j < bars.Length - 2; j++)
            {
                date = bars[j].TradeDateTime;
                jDate = oBacktest.ToJulianDate(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0, 0);

                oBacktest.AppendRecord(jDate, bars[j].OpenPrice, bars[j].HighPrice, bars[j].LowPrice, bars[j].ClosePrice, (int)bars[j].Volume);
            } 
            
            tabScripts.SelectedIndex = 2;

            _optimiserThread = new Thread(StartOptimiserThread);
            _optimiserThread.IsBackground = true;
            _optimiserThread.Start();
        }

        private void StartOptimiserThread()
        {
            m_MaxProfit = 0;
            m_BestPeriodOne = 0;
            m_BestPeriodTwo = 0;
            _periodOneUsed = false;
            _periodTwoUsed = false;

            if (VerifyMinAndMaxPeriods())
            {
                if (AreParametersAvailable())
                {
                    decimal diff = numMax.Value - numMin.Value;
                    decimal stepPercentage = diff * numScriptInterval.Value;

                    progressOptimizer.Properties.Value = 0;
                    progressOptimizer.Properties.Maximum = 100;
                    progressOptimizer.Properties.Minimum = 0;
                    progressOptimizer.Properties.Step = (int) stepPercentage;

                    int periodOneCurrent = (int)numMin.Value;
                    while (periodOneCurrent <= numMax.Value)
                    {
                        UpdateProgress();

                        int periodTwoCurrent = (int)numMin2.Value;
                        while (periodTwoCurrent <= numMax2.Value)
                        {
                            string buyScript = txtBuyScript.Text.ToLower()
                                .Replace(PERIOD_ONE_PARAMETER, periodOneCurrent.ToString())
                                .Replace(PERIOD_TWO_PARAMETER, periodTwoCurrent.ToString());
                            string sellScript = txtSellScript.Text.ToLower()
                                .Replace(PERIOD_ONE_PARAMETER, periodOneCurrent.ToString())
                                .Replace(PERIOD_TWO_PARAMETER, periodTwoCurrent.ToString());

                            RunBackTest(buyScript, sellScript, periodOneCurrent, periodTwoCurrent);

                            periodTwoCurrent = (int)(periodTwoCurrent + numScriptInterval.Value);
                        }

                        periodOneCurrent = (int)(periodOneCurrent + numScriptInterval.Value);
                    }

                    if (m_BestPeriodOne > 0 || m_BestPeriodTwo > 0)
                    {
                        string message = string.Format("Best period was Period One: {0}", m_BestPeriodOne);

                        if(_periodOneUsed && _periodTwoUsed)
                        {
                            message = string.Format("Best periods were Period One: {0} and Period Two: {1}", m_BestPeriodOne, m_BestPeriodTwo);
                        }
                        else if(!_periodOneUsed && _periodTwoUsed)
                        {
                            message = string.Format("Best period was Period Two: {0}", m_BestPeriodTwo);
                        }
                        MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DisplayResults(message);
                    }
                }
                else
                {
                    RunBackTest(txtBuyScript.Text, txtSellScript.Text, 0, 0);

                    DisplayResults(string.Empty);
                }
            }
            else
            {
                MessageBox.Show("Please ensure Min Period is less than Max Period", Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ToggleEnabled(true);
            ToggleVisible(false);
        }

        private delegate void EnableControlsDelegate(bool isEnbaled);
        private delegate void UpdateProgessDelegate();

        private void ToggleEnabled(bool isEnabled)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new EnableControlsDelegate(ToggleEnabled), isEnabled);
                return;
            }

            btnSearch.Enabled = isEnabled;
            cboInterval.Enabled = isEnabled;
            cboPeriodicity.Enabled = isEnabled;
            numMin.Enabled = isEnabled;
            numMax.Enabled = isEnabled;
            numMin2.Enabled = isEnabled;
            numMax2.Enabled = isEnabled;
            txtBars.Enabled = isEnabled;
            txtSymbol.Enabled = isEnabled;
            numScriptInterval.Enabled = isEnabled;
            btnOptimiza.Enabled = isEnabled;
            tabScripts.Enabled = isEnabled;
            tabRezult.Enabled = isEnabled;
            btnStop.Enabled = !isEnabled;
        }

        private void ToggleVisible(bool isVisible)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EnableControlsDelegate(ToggleVisible), isVisible);
                return;
            }
            progressOptimizer.Visible = isVisible;
        }

        private void UpdateProgress()
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new UpdateProgessDelegate(UpdateProgress));
                return;
            }
            progressOptimizer.PerformStep();
        }

        private bool AreParametersAvailable()
        {
            bool parametersAvailable = false;

            if(txtBuyScript.Text.IndexOf(PERIOD_ONE_PARAMETER) > -1 || txtSellScript.Text.IndexOf(PERIOD_ONE_PARAMETER) > -1)
            {
                parametersAvailable = true;
                _periodOneUsed = true;
            }
            if (txtBuyScript.Text.IndexOf(PERIOD_TWO_PARAMETER) > -1 || txtSellScript.Text.IndexOf(PERIOD_TWO_PARAMETER) > -1)
            {
                parametersAvailable = true;
                _periodTwoUsed = true;
            }

            return parametersAvailable;
        }

        private bool VerifyMinAndMaxPeriods()
        {
            if(numMin.Value > numMax.Value)
                return false;
            if(numMin2.Value > numMax2.Value)
                return false;

            return true;
        }

        private void RunBackTest(string buyScript, string sellScript, int periodOne, int periodTwo)
        {
            string result = oBacktest.Backtest(buyScript, sellScript, string.Empty, string.Empty, 0.001);

            if (string.IsNullOrEmpty(result)) return;

            int found = result.IndexOf("Trade Log:");

            if (found > 0)
            {
                string[] tradeLog = result.Substring(found + "trade log:".Length + 1).Split(
                    new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                string[] report = result.Substring(0, found - 1).Split(new[] {Environment.NewLine},
                                                                       StringSplitOptions.RemoveEmptyEntries);

                //You can now loop through the trade log and the statistical report
                found = report[5].IndexOf(": ");

                if(found <= 0) return;
                
                double m_totalProfit = Double.Parse(report[5].Substring(found + 2), System.Globalization.CultureInfo.InvariantCulture);

                if (m_totalProfit > m_MaxProfit)
                {
                    m_MaxProfit = m_totalProfit;
                    m_BestPeriodOne = periodOne;
                    m_BestPeriodTwo = periodTwo;

                    _backtestResults.Clear();

                    for (int n = 0; n < report.Length; n++)
                    {
                        if (!(n >= 13 && n <= 22))
                        {
                            _backtestResults.Add(report[n]);
                        }
                    }

                    for (int n = 0; n < tradeLog.Length; n++)
                    {
                        _backtestResults.Add(tradeLog[n]);
                    }
                }
            }
        }

        private void DisplayResults(string message)
        {
            lstResults.Items.Clear();

            lstResults.Items.Add(message);

            foreach (string backtestResult in _backtestResults)
            {
                lstResults.Items.Add(backtestResult);
            }
        }

        private ChartSelection InitDate()
        {
            string error = string.Empty;
            ChartSelection selection = new ChartSelection();
            selection.Symbol = txtSymbol.Text;
            if (selection.Symbol.Trim() == string.Empty)
            {
                error = "Invalid symbol";
                txtSymbol.Focus();                
            }
            selection.Periodicity = (Periodicity)cboPeriodicity.SelectedIndex + 2;
            selection.Interval = int.Parse(cboInterval.Text);
            if (!int.TryParse(txtBars.Text, out selection.Bars))
            {
                error = "Invalid bars";
                txtBars.Focus();
            }
            if (txtBuyScript.Text.Trim() == string.Empty)
            {
                tabScripts.SelectedIndex = 0;
                txtBuyScript.Focus();
                error = "Invalid buy script";
            }

            if (txtSellScript.Text.Trim() == string.Empty)
            {
                tabScripts.SelectedIndex = 1;
                txtSellScript.Focus();
                error = "Invalid sell script";
            }
            if (error != string.Empty)
            {
                MessageBox.Show(error, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            //By Kul
            //if (!CustomIndicatorWorker.ValidateScript(txtBuyScript.Text.ToLower().Replace(PERIOD_ONE_PARAMETER, numMin.Value.ToString()).Replace(PERIOD_TWO_PARAMETER, numMin.Value.ToString())))
            //{
            //    tabScripts.SelectedIndex = 0;
            //    txtBuyScript.Focus();
            //    return null;
            //}
            //if (!CustomIndicatorWorker.ValidateScript(txtSellScript.Text.ToLower().Replace(PERIOD_ONE_PARAMETER, numMin.Value.ToString()).Replace(PERIOD_TWO_PARAMETER, numMin.Value.ToString())))
            //{
            //    tabScripts.SelectedIndex = 1;
            //    txtSellScript.Focus();
            //    return null;
            //}



            return selection;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> selectedSymbols = new List<string>();

            //var marketRepository = IoC.Resolve<IMarketRepository>();

            //DialogResult result = new frmSymbolLookup(marketRepository, ref selectedSymbols, false).ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    txtSymbol.Text = selectedSymbols.First();
            //}
        }
    }
}
