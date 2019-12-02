using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradeScriptLib;
using AxSTOCKCHARTXLib;
using System.Windows.Forms;
//using M4.Trades;
//using FundXchange.Model.ViewModels.Charts;
using System.Diagnostics;

namespace M4.Workspace
{
    internal class BackTester
    {
        private const string TRADESCRIPT_LICENSE = "XRT93NQR79ABTW788XR48";
        private readonly Backtest _BackTestObject;
        private readonly string _BuyScript, _SellScript, _ExitLongScript, _ExitShortScript;
        private readonly double _SlipPercentage;
        private readonly AxStockChartX _Chart;
        private readonly PALSA.Cls.Periodicity _periodicity;
        private string _RawResult;

        private readonly IList<string> _backTestSummaryValues = new List<string>();
        public IEnumerable<string> BackTestSummaryValues
        {
            get
            {
                foreach (string value in _backTestSummaryValues)
                    yield return value;
            }
        }

        private readonly List<KeyValuePair<DateTime, string>> _alerts = new List<KeyValuePair<DateTime, string>>();
        public List<KeyValuePair<DateTime, string>> Alerts
        {
            get
            {
                return _alerts.OrderBy(s => s.Key).ToList<KeyValuePair<DateTime, string>>();
            }
        }
        
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(_RawResult);
            }
        }


        public BackTester(string buyScript, string sellScript, string exitLongScript, string exitShortScript, double slipPercentage, AxStockChartX associatedChart, PALSA.Cls.Periodicity periodicity)
        {
            _BackTestObject = new Backtest { License = TRADESCRIPT_LICENSE };

            _BuyScript = buyScript;
            _SellScript = sellScript;
            _ExitLongScript = exitLongScript;
            _ExitShortScript = exitShortScript;
            _SlipPercentage = slipPercentage;
            _Chart = associatedChart;
            _periodicity = periodicity;
        }

        public void RunBackTest(PALSA.Cls.BarDataNew[] barData)
        {
            _BackTestObject.ClearRecords();

            foreach (var bar in barData)
            {
                _BackTestObject.AppendRecord(GetJulianDate(bar.TradeDateTime), bar.OpenPrice, bar.HighPrice, bar.LowPrice, bar.ClosePrice,
                                            (int)Math.Round(bar.Volume));
            }

            _RawResult = _BackTestObject.Backtest(_BuyScript, _SellScript, _ExitLongScript, _ExitShortScript, _SlipPercentage);

            if (!string.IsNullOrEmpty(_RawResult))
            {
                string[] rows = _RawResult.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (rows.Length > 0)
                {
                    GetBackTestSummary(rows[0]);
                }
            }
        }

        private void GetBackTestSummary(string header)
        {
            _backTestSummaryValues.Clear();

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
                    _backTestSummaryValues.Add(ret.Replace("\"", ""));
                }
                n += 1;
            }

            _backTestSummaryValues.Add(header.Substring(p, n - p).Trim().Replace("\"", ""));
        }

        // TODO: Refactor
        public void AddSymbolsToAssociatedChart()
        {
            if (!this.IsValid)
            {
                MessageBox.Show("No results. Make sure that at least Buy and Sell scripts are typed in.");
                return;
            }
            int found = _RawResult.IndexOf("Trade Log:");
            if (found > 0)
            {
                int n;
                string[] tradeLog = _RawResult.Substring(found + "trade log:".Length + 1).Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                string[] report = _RawResult.Substring(0, found - 1).Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (n = 0; n < tradeLog.Length; n++)
                {
                    DateTime tradeDate;
                    long record;
                    double value;

                    string[] trade = tradeLog[n].Split(',');
                    double jDate = GetJulianDate(trade[0]);
                    DateTime.TryParse(trade[0], out tradeDate);

                    // signals are given at 17:00 but candle records are 09:00.
                    if(_periodicity == PALSA.Cls.Periodicity.Daily && tradeDate.Hour == 17)
                    {
                        tradeDate = tradeDate.AddHours(-8);
                        jDate = GetJulianDate(tradeDate);
                    }
                    else if(_periodicity == PALSA.Cls.Periodicity.Weekly && tradeDate.Hour == 17)
                    {
                        tradeDate = tradeDate.AddHours(-8).AddDays(-4);
                        jDate = GetJulianDate(tradeDate);
                    }
                    else if(_periodicity == PALSA.Cls.Periodicity.Hourly && tradeDate.Hour == 17)
                    {
                        tradeDate = tradeDate.AddHours(-1);
                        jDate = GetJulianDate(tradeDate);
                    }

                    string signal = trade[1];
                    
                    double price;
                    double.TryParse(trade[2], out price);

                    switch (signal)
                    {
                        case "LONG":
                            record = _Chart.GetRecordByJDate(jDate);
                            value = _Chart.GetValue(_Chart.Symbol + ".low", (int)record);                            
                            _Chart.AddSymbolObject(0, value, (int)record, STOCKCHARTXLib.SymbolType.soBuySymbolObject,
                                                         "BUY " + Convert.ToString(record), "Long at R for Rands " + Convert.ToString(price));
                            _alerts.Add(new KeyValuePair<DateTime, string>(tradeDate, "Buy alert"));
                            break;

                        case "SHORT":
                            record = _Chart.GetRecordByJDate(jDate);
                            value = _Chart.GetValue(_Chart.Symbol + ".high", (int)record);
                            _Chart.AddSymbolObject(0, value, (int)record, STOCKCHARTXLib.SymbolType.soSellSymbolObject,
                                                         "SELL " + Convert.ToString(record), "Short at R for Rands " + Convert.ToString(price));
                            _alerts.Add(new KeyValuePair<DateTime, string>(tradeDate, "Sell alert"));
                            break;

                        case "EXIT":
                            record = _Chart.GetRecordByJDate(jDate);
                            _Chart.AddSymbolObject(0, price, (int)record, STOCKCHARTXLib.SymbolType.soExitSymbolObject,
                                                         "EXIT " + Convert.ToString(record), "Exit at R for Rands " + Convert.ToString(price));
                            _alerts.Add(new KeyValuePair<DateTime, string>(tradeDate, "Exit alert"));
                            break;
                        case "EXIT LONG":
                            record = _Chart.GetRecordByJDate(jDate);
                            _Chart.AddSymbolObject(0, price, (int)record, STOCKCHARTXLib.SymbolType.soExitLongSymbolObject,
                                                         "EXIT " + Convert.ToString(record), "Exit at R for Rands " + Convert.ToString(price));
                            _alerts.Add(new KeyValuePair<DateTime, string>(tradeDate, "Exit long alert"));
                            break;
                        case "EXIT SHORT":
                            record = _Chart.GetRecordByJDate(jDate);
                            _Chart.AddSymbolObject(0, price, (int)record, STOCKCHARTXLib.SymbolType.soExitShortSymbolObject,
                                                         "EXIT " + Convert.ToString(record), "Exit at R for Rands " + Convert.ToString(price));
                            _alerts.Add(new KeyValuePair<DateTime, string>(tradeDate, "Exit short alert"));
                            break;
                    }
                }
            }
            _Chart.Update();
        }

        private double GetJulianDate(string dateString)
        {
            try
            {
                DateTime dtDate = DateTime.Parse(dateString);
                return _Chart.ToJulianDate(dtDate.Year, dtDate.Month, dtDate.Day,
                                                         dtDate.Hour, dtDate.Minute, dtDate.Second);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetJDate Error: " + ex.Message);
                return 0.0;
            }
        }

        private double GetJulianDate(DateTime tradeDate)
        {
            try
            {
                return _Chart.ToJulianDate(tradeDate.Year, tradeDate.Month, tradeDate.Day,
                                                         tradeDate.Hour, tradeDate.Minute, tradeDate.Second);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetJDate Error: " + ex.Message);
                return 0.0;
            }
        }
    }
}
