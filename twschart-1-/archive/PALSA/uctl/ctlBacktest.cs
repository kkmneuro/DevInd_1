using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
//using FundXchange.Infrastructure;
//using FundXchange.Model.Infrastructure;
using TradeScriptLib;
//using FundXchange.Model.ViewModels.Charts;
using System.Linq;
using PALSA.FrmScanner;

namespace PALSA.uctl
{
    public partial class ctlBacktest : UserControl//, IDataSubscriber
    {
        #region Initialization and Members
        private readonly ScriptOutput oScript;
        private readonly Backtest oBacktest;

        public class Bar
        {
            public double jDate = 0;
            public double O = 0;
            public double H = 0;
            public double L = 0;
            public double C = 0;
            public long V = 0;
        }

        public bool m_changed;

        private WPFChartControl m_chart;
        private readonly FrmMain m_frmMain;


        public ctlBacktest(FrmMain oMain)
        {
            InitializeComponent();

            m_frmMain = oMain;
            oBacktest = new BacktestClass { License = "XRT93NQR79ABTW788XR48" };
            oScript = new ScriptOutputClass { License = "XRT93NQR79ABTW788XR48" };

            txtBars.GotFocus += (sender, e) => Text_Focus((TextBoxBase)sender);
            txtSymbol.GotFocus += (sender, e) => Text_Focus((TextBoxBase)sender);

            oScript.ScriptError += oScript_ScriptError;
            oBacktest.ScriptError += oBacktest_ScriptError;
        }

        #endregion

        #region Controls
        private void ctlBacktest_Load(object sender, EventArgs e)
        {
            cboPeriodicity.SelectedIndex = 0;
            m_changed = false;
        }

        //Enables/Disables controls for when the script is running
        private void EnableControls(bool Enable)
        {
            grpData.Enabled = Enable;
            tabScripts.Enabled = Enable;
            cmdBacktest.Enabled = Enable;
            if (Enable)
            {
                cmdBacktest.Text = "&Back Test";
                cmdBacktest.Border.BaseColor = Color.Lime;
            }
            else
            {
                cmdBacktest.Text = "&Stop Backtest";
                cmdBacktest.Border.BaseColor = Color.Red;
            }
            cmdBacktest.Border.Update();
        }

        //Display the TradeScript documentation
        private void cmdDocumentation_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), @"Documents\TradeScript.pdf");
            m_frmMain.OpenURL(path, "TradeScript Help");
            //m_frmMain.OpenURL(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TradeScript.pdf"), "TradeScript Help");
            /*m_frmMain.OpenURL("http://platform.modulusfe.com/m4/" + frmMain.ClientTitle + "/TradeScript.pdf",
                              "TradeScript Help");*/
        }

        private void ctlBacktest_Resize(object sender, EventArgs e)
        {
            m_ListTrades.Columns[0].Width = grpTrades.Width - 10;
        }

        //Handles GotGocus for several text boxes
        private static void Text_Focus(TextBoxBase textBox)
        {
            textBox.SelectAll();
        }
        #endregion

        #region IDataSubscriber
        public IntPtr GetHandle()
        {
            return IntPtr.Zero;
        }

        public void BarUpdate(string Symbol, PALSA.Cls.Periodicity BarType, PALSA.Cls.BarDataNew Bar)
        {

        }

        public void PriceUpdate(string Symbol, DateTime TradeDate, double LastPrice, long Volume)
        {

        }
        #endregion

        #region Back Testing
        private void oScript_ScriptError(string description)
        {
            if (oScript.ScriptHelp != "")
            {
                if (MessageBox.Show("Your script generated an error:\r\n" + description +
                                    "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    MessageBox.Show(oScript.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Your script generated an error:\r\n" + description, "Error:", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            EnableControls(true);
        }

        private void oBacktest_ScriptError(string description)
        {
            if (oBacktest.ScriptHelp != "")
            {
                if (MessageBox.Show("Your script generated an error:\r\n" + description +
                                    "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    MessageBox.Show(oBacktest.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Your script generated an error:\r\n" + description, "Error:", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            EnableControls(true);
        }

        private void cmdBacktest_Click(object sender, EventArgs e)
        {
            string Results = RunBacktest();
            if (Results != "")
            {
                DisplayResults(Results);
            }
        }

        //Validates the form for saving
        private bool VerifyForm()
        {
            uint uintVal;
            txtSymbol.Text = txtSymbol.Text.Trim();
            if (txtSymbol.Text == "")
            {
                txtSymbol.Focus();
                MessageBox.Show("Please enter a symbol", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboPeriodicity.Text == "")
            {
                cboPeriodicity.Focus();
                MessageBox.Show("Please select a periodicity", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!uint.TryParse(txtBars.Text, out uintVal))
            {
                txtBars.SelectAll();
                txtBars.Focus();
                MessageBox.Show("Please enter the number of bars", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        //Checks the scripts for errors
        private bool TestScripts()
        {
            Validate script = new ValidateClass { License = "XRT93NQR79ABTW788XR48" };
            string err = script.Validate(txtBuyScript.Text);
            if (!string.IsNullOrEmpty(err))
            {
                tabScripts.SelectedIndex = 0;
                if (script.ScriptHelp != "")
                {
                    if (MessageBox.Show("Your buy script generated an error:\r\n" + err.Replace("Error: ", "") +
                                        "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Your buy script generated an error:\r\n" + err.Replace("Error: ", ""), "Error:",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            err = script.Validate(txtSellScript.Text);
            if (!string.IsNullOrEmpty(err))
            {
                tabScripts.SelectedIndex = 1;
                if (script.ScriptHelp != "")
                {
                    if (MessageBox.Show("Your sell script generated an error:\r\n" + err.Replace("Error: ", "") +
                                        "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Your sell script generated an error:\r\n" + err.Replace("Error: ", ""), "Error:",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            err = script.Validate(txtExitLongScript.Text);
            if (!string.IsNullOrEmpty(err))
            {
                tabScripts.SelectedIndex = 2;
                if (script.ScriptHelp != "")
                {
                    if (MessageBox.Show("Your exit long script generated an error:\r\n" + err.Replace("Error: ", "") +
                                        "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Your exit-long script generated an error:\r\n" + err.Replace("Error: ", ""), "Error:",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            err = script.Validate(txtExitShortScript.Text);
            if (!string.IsNullOrEmpty(err))
            {
                tabScripts.SelectedIndex = 3;
                if (script.ScriptHelp != "")
                {
                    if (MessageBox.Show("Your exit short script generated an error:\r\n" + err.Replace("Error: ", "") +
                                        "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Your exit-short script generated an error:\r\n" + err.Replace("Error: ", ""), "Error:",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            return true;
        }

        //Runs the backtest and displays the chart with buy/sell/exit icons.
        private string RunBacktest()
        {
            string ret = "";

            oScript.ClearRecords();
            oBacktest.ClearRecords();

            if (!VerifyForm()) return "";
            if (!TestScripts()) return "";
            //if (m_ctlData == null) return "";

            cmdBacktest.Text = "&Stop Backtest";
            cmdBacktest.Border.BaseColor = Color.Red;
            EnableControls(false);
            cmdBacktest.Border.Update();

            PALSA.Cls.Periodicity periodicity;
            switch (cboPeriodicity.Text)
            {
                case "Minute":
                    periodicity = PALSA.Cls.Periodicity.Minutely;
                    break;
                case "Hour":
                    periodicity = PALSA.Cls.Periodicity.Hourly;
                    break;
                case "Day":
                    periodicity = PALSA.Cls.Periodicity.Daily;
                    break;
                case "Week":
                    periodicity = PALSA.Cls.Periodicity.Weekly;
                    break;
                default:
                    periodicity = PALSA.Cls.Periodicity.Minutely;
                    break;
            }

            cmdBacktest.Enabled = false;

            //Get the data selection
            ChartSelection selection = new ChartSelection
                                         {
                                             Periodicity = periodicity,
                                             Symbol = txtSymbol.Text.ToUpper(),
                                             Interval = Convert.ToInt32(cboInterval.Text),
                                             Bars = Convert.ToInt32(txtBars.Text)
                                         };
            m_chart.OnHistoricalData += new Action<List<Cls.BarDataNew>>(m_chart_OnHistoricalData);
            m_chart = m_frmMain.LoadRealTimeChart(selection);//m_ctlData.GetChart(selection, true, false); //Ensure the chart is new
            if (m_chart == null) goto Quit;

            //PALSA.Cls.BarDataNew[] bars = m_chart.GetDataFromChart();
            //if (bars.Length < 1) goto Quit;
            //m_chart.Subscribers += 1;
            ////Get historic data
            //cmdBacktest.Enabled = true;
            //if (bars.Length < 3) goto Quit; //Bad request 

            ////Insert the data into all four instances of TradeScript
            //oScript.ClearRecords();
            //oBacktest.ClearRecords();

            //DateTime td;
            //double jdate;

            //for (int n = 1; n < bars.Length - 2; n++)
            //{
            //    td = bars[n].TradeDateTime;
            //    jdate = oScript.ToJulianDate(td.Year, td.Month, td.Day, td.Hour, td.Minute, td.Second, 0);

            //    oScript.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice,
            //                         bars[n].LowPrice, bars[n].ClosePrice, (int)bars[n].Volume);
            //    oBacktest.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice,
            //                           bars[n].LowPrice, bars[n].ClosePrice, (int)bars[n].Volume);
            //}
            
            //ret = oBacktest.Backtest(txtBuyScript.Text, txtSellScript.Text, txtExitLongScript.Text, txtExitShortScript.Text, 0.001);
            //if (string.IsNullOrEmpty(ret)) goto Quit;

            //string output =
            //  oScript.GetScriptOutput(txtBuyScript.Text + " AND " + txtSellScript.Text + " AND " + txtExitLongScript.Text +
            //                          " AND " + txtExitShortScript.Text);
            //if (string.IsNullOrEmpty(output)) goto Quit;

            //string[] cols;
            //string[] rows = output.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //string[] Header = SplitHeader(rows[0]);






            //StockChartX//Kuldeep
            //AxSTOCKCHARTXLib.AxStockChartX StockChartX1 = m_chart.StockChartX1;
            //StockChartX1.RemoveAllSeries();

            //string symbol = selection.Symbol;
            //StockChartX1.Symbol = symbol;

            //StockChartX1.AddChartPanel();
            //StockChartX1.AddSeries(symbol + ".open", STOCKCHARTXLib.SeriesType.stCandleChart, 0);
            //StockChartX1.AddSeries(symbol + ".high", STOCKCHARTXLib.SeriesType.stCandleChart, 0);
            //StockChartX1.AddSeries(symbol + ".low", STOCKCHARTXLib.SeriesType.stCandleChart, 0);
            //StockChartX1.AddSeries(symbol + ".close", STOCKCHARTXLib.SeriesType.stCandleChart, 0);
            //StockChartX1.set_SeriesColor(symbol + ".close", ColorTranslator.ToOle(Color.Black));
            //StockChartX1.AddSeries(symbol + ".% move", STOCKCHARTXLib.SeriesType.stCandleChart, 0);
            //StockChartX1.set_SeriesVisible(symbol + ".% move", false);
            //StockChartX1.AddChartPanel();
            //StockChartX1.AddSeries(symbol + ".volume", STOCKCHARTXLib.SeriesType.stVolumeChart, 1);
            //StockChartX1.set_SeriesColor(symbol + ".volume", ColorTranslator.ToOle(Color.Blue));
            //StockChartX1.set_SeriesWeight(symbol + ".volume", 3);
            //StockChartX1.VolumePostfixLetter = "M"; //Google trades in millions

            //for (int colIndex = 6; colIndex < Header.Length; colIndex++)
            //{
            //    int panel = StockChartX1.AddChartPanel();
            //    StockChartX1.AddSeries(Header[colIndex].Replace('.', ','), STOCKCHARTXLib.SeriesType.stLineChart, panel);
            //}

            ////double m_dayopen = bars[0].OpenPrice;
            //double m_daymove = (100 * (bars[0].ClosePrice - bars[0].OpenPrice)) / bars[0].OpenPrice;

            //for (int rowIndex = 1; rowIndex < rows.Length; rowIndex++)
            //{
            //    cols = rows[rowIndex].Split(',');
            //    jdate = GetJDate(cols[0]);

            //    try
            //    {
            //        StockChartX1.AppendValue(symbol + ".open", jdate, Convert.ToDouble(cols[1]));
            //        StockChartX1.AppendValue(symbol + ".high", jdate, Convert.ToDouble(cols[2]));
            //        StockChartX1.AppendValue(symbol + ".low", jdate, Convert.ToDouble(cols[3]));
            //        StockChartX1.AppendValue(symbol + ".close", jdate, Convert.ToDouble(cols[4]));
            //        StockChartX1.AppendValue(symbol + ".volume", jdate, Convert.ToDouble(cols[5]) / 1000000);

            //        if ((periodicity != PALSA.Cls.Periodicity.Daily) && periodicity != PALSA.Cls.Periodicity.Weekly)
            //        {
            //            if (rowIndex == 0)
            //            {
            //                StockChartX1.AppendValue(symbol + ".% move", jdate, m_daymove);
            //            }
            //            else
            //            {
            //                //if ((bars[rowIndex].TradeDateTime.Day) != (bars[rowIndex - 1].TradeDateTime).Day)
            //                //{
            //                //    m_dayopen = bars[rowIndex].OpenPrice;
            //                //}
            //                m_daymove = (100 * (bars[rowIndex].ClosePrice - bars[rowIndex].OpenPrice)) / bars[rowIndex].OpenPrice;
            //                StockChartX1.AppendValue(symbol + ".% move", jdate, m_daymove);
            //            }
            //        }
            //        else
            //        {
            //            StockChartX1.AppendValue(symbol + ".% move", jdate, 0);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Failed to build chart for back test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return "";
            //    }

            //    for (int colIndex = 6; colIndex < cols.Length; colIndex++)
            //    {
            //        double value = Convert.ToDouble(cols[colIndex]);
            //        if (value == 0 && rowIndex < rows.Length * 0.2)
            //            value = (double)STOCKCHARTXLib.DataType.dtNullValue;
            //        StockChartX1.AppendValue(Header[colIndex].Replace('.', ','), jdate, value);
            //    }
            //}

            //StockChartX1.Update();

        Quit:
            if (m_chart != null)
                m_chart.Show();

            cmdBacktest.Text = "&Back Test";
            cmdBacktest.Border.BaseColor = Color.Lime;
            EnableControls(true);
            cmdBacktest.Border.Update();

            if (m_chart != null)
                m_chart.Subscribers -= 1;

            return ret;
        }

        void m_chart_OnHistoricalData(List<Cls.BarDataNew> obj)
        {
            string ret = string.Empty;
            PALSA.Cls.BarDataNew[] bars = obj.ToArray();
            if (bars.Length < 1) return;
            m_chart.Subscribers += 1;
            //Get historic data
            cmdBacktest.Enabled = true;
            if (bars.Length < 3) return; //Bad request 

            //Insert the data into all four instances of TradeScript
            oScript.ClearRecords();
            oBacktest.ClearRecords();

            DateTime td;
            double jdate;

            for (int n = 1; n < bars.Length - 2; n++)
            {
                td = bars[n].TradeDateTime;
                jdate = oScript.ToJulianDate(td.Year, td.Month, td.Day, td.Hour, td.Minute, td.Second, 0);

                oScript.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice,
                                     bars[n].LowPrice, bars[n].ClosePrice, (int)bars[n].Volume);
                oBacktest.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice,
                                       bars[n].LowPrice, bars[n].ClosePrice, (int)bars[n].Volume);
            }

            ret = oBacktest.Backtest(txtBuyScript.Text, txtSellScript.Text, txtExitLongScript.Text, txtExitShortScript.Text, 0.001);
            if (string.IsNullOrEmpty(ret)) return;//goto Quit;

            string output =
              oScript.GetScriptOutput(txtBuyScript.Text + " AND " + txtSellScript.Text + " AND " + txtExitLongScript.Text +
                                      " AND " + txtExitShortScript.Text);
            if (string.IsNullOrEmpty(output)) return;//goto Quit;

            string[] cols;
            string[] rows = output.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] Header = SplitHeader(rows[0]);


            if (ret != "")
            {
                DisplayResults(ret);
            }
        }

        private void DisplayResults(string Results)
        {
            if (string.IsNullOrEmpty(Results))
            {
                MessageBox.Show("No results. Make sure that at least Buy and Sell scripts are typed in.");
                return;
            }
            int found = Results.IndexOf("Trade Log:");//kul
            //AxSTOCKCHARTXLib.AxStockChartX StockChartX1 = m_chart.StockChartX1;
            if (found > 0)
            {
                int n;
                string[] tradeLog = Results.Substring(found + "trade log:".Length + 1).Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string[] report = Results.Substring(0, found - 1).Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                //Loop through the trade log and the statistical report

                m_ListTrades.Items.Clear();
                m_ListTrades.Items.Add(report[0].Replace("Back tested from ", ""));
                for (n = 1; n < report.Length; n++)
                {
                    if (!(n >= 13 && n <= 22))
                    {
                        m_ListTrades.Items.Add(report[n]);
                    }
                }

                //Get the trade
                for (n = 0; n < tradeLog.Length; n++)
                {
                    long record;
                    double value;

                    m_ListTrades.Items.Add(tradeLog[n]);
                    string[] trade = tradeLog[n].Split(',');
                    double jDate = GetJDate(trade[0]);
                    string signal = trade[1];
                    double price = 0;
                    try
                    {
                        price = Convert.ToDouble(trade[2]);
                    }
                    catch { }
                    //By Kul
                    string key = string.Empty;


                    switch (signal)
                    {
                        case "LONG":
                            //record = StockChartX1.GetRecordByJDate(jDate);
                            //value = StockChartX1.GetValue(StockChartX1.Symbol + ".low", (int)record);
                            //StockChartX1.AddSymbolObject(0, value, (int)record, STOCKCHARTXLib.SymbolType.soBuySymbolObject, "BUY " + Convert.ToString(record), string.Format("Long at R {0}", Convert.ToString(price)));
                            record = m_chart.GetRecordByJDate(jDate);
                            key = "BUY " + Convert.ToString(record);
                            m_chart.AddSymbolObjetc(key, "Buy Alert");
                            break;
                        case "SHORT":
                            //record = StockChartX1.GetRecordByJDate(jDate);
                            //value = StockChartX1.GetValue(StockChartX1.Symbol + ".high", (int)record);
                            //StockChartX1.AddSymbolObject(0, value, (int)record, STOCKCHARTXLib.SymbolType.soSellSymbolObject,
                            //                             "SELL " + Convert.ToString(record), string.Format("Short at R {0}", Convert.ToString(price)));
                            record = m_chart.GetRecordByJDate(jDate);
                            key = "BUY " + Convert.ToString(record);
                            m_chart.AddSymbolObjetc(key, "Sell Alert");
                            break;
                        case "EXIT":
                            //record = StockChartX1.GetRecordByJDate(jDate);
                            //StockChartX1.AddSymbolObject(0, price, (int)record, STOCKCHARTXLib.SymbolType.soExitSymbolObject,
                            //                             "EXIT " + Convert.ToString(record), string.Format("Exit at R {0}", Convert.ToString(price)));
                            record = m_chart.GetRecordByJDate(jDate);
                            key = "BUY " + Convert.ToString(record);
                            m_chart.AddSymbolObjetc(key, "Exit");
                            break;
                        case "EXIT LONG":
                            //record = StockChartX1.GetRecordByJDate(jDate);
                            //StockChartX1.AddSymbolObject(0, price, (int)record, STOCKCHARTXLib.SymbolType.soExitSymbolObject,
                            //                             "EXIT " + Convert.ToString(record), string.Format("Exit Long at R {0}", Convert.ToString(price)));
                            record = m_chart.GetRecordByJDate(jDate);
                            key = "BUY " + Convert.ToString(record);
                            m_chart.AddSymbolObjetc(key, "Exit-Long Alert");
                            break;
                        case "EXIT SHORT":
                            //record = StockChartX1.GetRecordByJDate(jDate);
                            //StockChartX1.AddSymbolObject(0, price, (int)record, STOCKCHARTXLib.SymbolType.soExitSymbolObject,
                            //                             "EXIT " + Convert.ToString(record), string.Format("Exit Short at R {0}", Convert.ToString(price)));
                            record = m_chart.GetRecordByJDate(jDate);
                            key = "BUY " + Convert.ToString(record);
                            m_chart.AddSymbolObjetc(key, "Exit-Short Alert");
                            break;
                    }
                }
            }
            //StockChartX1.ForcePaint();
        }

        private static string[] SplitHeader(string header)
        {
            List<string> Values = new List<string>();
            int p = 1;
            int n = 0;
            int PCnt = 0;
            while (n < header.Length)
            {
                if (header[n] == '\"') PCnt += 1;
                if (header[n] == ',' && (PCnt % 2) == 0)
                {
                    string ret = header.Substring(p, n - p).Trim();
                    p = n + 1;
                    Values.Add(ret.Replace("\"", ""));
                }
                n += 1;
            }

            Values.Add(header.Substring(p, n - p).Trim().Replace("\"", ""));
            return Values.ToArray();
        }

        private double GetJDate(string szDate)
        {
            try
            {
                DateTime dtDate = DateTime.Parse(szDate);

                // hack to fix scriptoutput object returning incorrect dates - candlesticks work on 0 seconds.
                DateTime roundedDate = dtDate;
                if (roundedDate.Minute == 59 && roundedDate.Second == 59)
                    roundedDate = roundedDate.AddSeconds(1);
                else if (roundedDate.Second == 59)
                    roundedDate = roundedDate.AddSeconds(-59);

                //Get a Julian date from the StockChartX control))
                //return m_chart.StockChartX1.ToJulianDate(roundedDate.Year, roundedDate.Month, roundedDate.Day,
                //                       roundedDate.Hour, roundedDate.Minute, roundedDate.Second);
              //kul
                return roundedDate.ToOADate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetJDate Error: " + ex.Message);
                return 0.0;
            }
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> selectedSymbols = new List<string>();

            //var marketRepository = IoC.Resolve<IMarketRepository>();

            //DialogResult result = new frmSymbolLookup(marketRepository, ref selectedSymbols, false).ShowDialog();

            //if(result == DialogResult.OK)
            //{
            //    txtSymbol.Text = selectedSymbols.First();
            //}
        }
    }
}
