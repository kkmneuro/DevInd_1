using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PALSA.Cls
{
    public static class IndicatorList
    {
        private static bool _bLoaded;
        private static List<String> indicatorListValues = new List<string>();
        private static readonly Hashtable indicatorIndexForStockChart = new Hashtable();
        private static int _index;


        //Gets a chart selection from the user


        private static string[] IndicatorListValues
        {
            get
            {
                if (_bLoaded == false)
                {
                    //LoadListValues();Kuldeep
                    _bLoaded = true;
                }
                return indicatorListValues.ToArray();
            }
            
        }

        //Start of function to populate Indicator List
        public static void PopulateIndicatorList(ref TreeNode node)
        {
            indicatorListValues = ClsGlobal.GetIndicators();

            int length = IndicatorListValues.Length;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    string nodeName = ("Node_" + indicatorListValues[i]).Replace(" ", "");
                    TreeNode newNode = node.Nodes.Add(nodeName, IndicatorListValues[i]);

                    newNode.ImageIndex = 0;
                    newNode.SelectedImageIndex = 0;

                    //Kuldeep
                    if (!indicatorIndexForStockChart.Contains(indicatorListValues[i]))
                        indicatorIndexForStockChart.Add(indicatorListValues[i], _index++);
                }
            }
        }

        private static void LoadListValues()
        {
            //try
            //{
            AddNewIndicator("Simple Moving Average");//// 0,
            AddNewIndicator("Exponential Moving Average");//// 1,
            AddNewIndicator("Time Series Moving Average");//// 2,
            AddNewIndicator("Triangular Moving Average");//// 3,
            AddNewIndicator("Variable Moving Average");//// 4,
            AddNewIndicator("VIDYA");//// 5,
            AddNewIndicator("Welles Wilder Smoothing");//// 6,
            AddNewIndicator("Weighted Moving Average");//// 7,
            AddNewIndicator("Williams PctR");//// 8,
            AddNewIndicator("Williams Accumulation Distribution");//// 9,
            AddNewIndicator("Volume Oscillator");//// 10,
            AddNewIndicator("Vertical Horizontal Filter");//// 11,
            AddNewIndicator("Ultimate Oscillator");//// 12,
            AddNewIndicator("True Range");//// 13,
            AddNewIndicator("TRIX");//// 14,
            AddNewIndicator("Rainbow Oscillator");//// 15,
            AddNewIndicator("Price Oscillator");//// 16,
            AddNewIndicator("Parabolic SAR");//// 17,
            AddNewIndicator("Momentum Oscillator");//// 18,
            AddNewIndicator("MACD");//// 19,
            AddNewIndicator("Ease Of Movement");//// 20,
            AddNewIndicator("Directional Movement System");//// 21,
            AddNewIndicator("Detrended Price Oscillator");//// 22,
            AddNewIndicator("Chande Momentum Oscillator");//// 23,
            AddNewIndicator("Chaikin Volatility");//// 24,
            AddNewIndicator("Aroon");//// 25,
            AddNewIndicator("Aroon Oscillator");//// 26,
            AddNewIndicator("Linear Regression RSquared");//// 27,
            AddNewIndicator("Linear Regression Forecast");//// 28,
            AddNewIndicator("Linear Regression Slope");//// 29,
            AddNewIndicator("Linear Regression Intercept");//// 30,
            AddNewIndicator("Price Volume Trend");//// 31,
            AddNewIndicator("Performance Index");//// 32,
            AddNewIndicator("Commodity Channel Index");//// 33,
            AddNewIndicator("Chaikin Money Flow");//// 34,
            AddNewIndicator("Weighted Close");//// 35,
            AddNewIndicator("Volume ROC");//// 36,
            AddNewIndicator("Typical Price");//// 37,
            AddNewIndicator("Standard Deviation");//// 38,
            AddNewIndicator("Price ROC");//// 39,
            AddNewIndicator("Median");//// 40,
            AddNewIndicator("High Minus Low");//// 41,
            AddNewIndicator("Bollinger Bands");//// 42,
            AddNewIndicator("Fractal Chaos Bands");//// 43,
            AddNewIndicator("High Low Bands");//// 44,
            AddNewIndicator("Moving Average Envelope");//// 45,
            AddNewIndicator("Swing Index");//// 46,
            AddNewIndicator("Accumulative Swing Index");//// 47,
            AddNewIndicator("Comparative Relative Strength");//// 48,
            AddNewIndicator("Mass Index");//// 49,
            AddNewIndicator("Money Flow Index");//// 50,
            AddNewIndicator("Negative Volume Index");//// 51,
            AddNewIndicator("OnBalanceVolume");//// 52,
            AddNewIndicator("Positive Volume Index");//// 53,
            AddNewIndicator("Relative Strength Index");//// 54,
            AddNewIndicator("Trade Volume Index");//// 55,
            AddNewIndicator("Stochastic Oscillator");//// 56,
            AddNewIndicator("Stochastic Momentum Index");//// 57,
            AddNewIndicator("Fractal Chaos Oscillator");//// 58,
            AddNewIndicator("Prime Number Oscillator");//// 59,
            AddNewIndicator("Prime Number Bands");//// 60,
            AddNewIndicator("Historical Volatility");//// 61,
            AddNewIndicator("MACD Histogram");//// 62,
            //AddNewIndicator("Ichimoku");//// 63,
            AddNewIndicator("Elder Ray BullPower");//// 64,
            AddNewIndicator("Elder Ray Bear Power");//// 65,
            AddNewIndicator("Ehler Fisher Transform");//// 66,
            AddNewIndicator("Elder Force Index");//// 67,
            AddNewIndicator("Elder Thermometer");//// 68,
            AddNewIndicator("Keltner Channel");//// 69,
            AddNewIndicator("Stoller Average Range Channels");//// 70,
            AddNewIndicator("Market Facilitation Index");//// 71,
            AddNewIndicator("Schaff Trend Cycle");//// 72,
            AddNewIndicator("Q Stick");//// 73,
            AddNewIndicator("Center Of Gravity");//// 74,
            AddNewIndicator("Coppock Curve");//// 75,
            AddNewIndicator("Chande Forecast Oscillator");//// 76,
            AddNewIndicator("Gopalakrishnan Range Index");//// 77,
            AddNewIndicator("Intraday Momentum Index");//// 78,
            AddNewIndicator("Klinger Volume Oscillator");//// 79,
            AddNewIndicator("Pretty Good Oscillator");//// 80,
            AddNewIndicator("RAVI");//// 81,
            AddNewIndicator("Random Walk Index");//// 82,
            AddNewIndicator("Twiggs Money Flow");//// 83,
            AddNewIndicator("Custom Indicator");//// 84,












            //AddNewIndicator("Simple Moving Average");
            //AddNewIndicator("Exponential Moving Average");
            //AddNewIndicator("Time Series Moving Average");
            //AddNewIndicator("Triangular Moving Average");
            //AddNewIndicator("Variable Moving Average");
            //AddNewIndicator("VIDYA");
            //AddNewIndicator("Welles Wilder Smoothing");
            //AddNewIndicator("Weighted Moving Average");
            //AddNewIndicator("Williams Pct R");
            //AddNewIndicator("Williams Accumulation Distribution");
            //AddNewIndicator("Volume Oscillator");
            //AddNewIndicator("Vertical Horizontal Filter");
            //AddNewIndicator("Ultimate Oscillator");
            //AddNewIndicator("True Range");
            //AddNewIndicator("TRIX");
            //AddNewIndicator("Rainbow Oscillator");
            //AddNewIndicator("Price Oscillator");
            //AddNewIndicator("Parabolic SAR");
            //AddNewIndicator("Momentum Oscillator");
            //AddNewIndicator("MACD");
            //AddNewIndicator("Ease Of Movement");
            //AddNewIndicator("Directional Movement System");
            //AddNewIndicator("Detrended Price Oscillator");
            //AddNewIndicator("Chande Momentum Oscillator");
            //AddNewIndicator("Chaikin Volatility");
            //AddNewIndicator("Aroon");
            //AddNewIndicator("Aroon Oscillator");
            //AddNewIndicator("Linear Regression Required");
            //AddNewIndicator("Linear Regressin Forecast");
            //AddNewIndicator("Linear Regression Slope");
            //AddNewIndicator("Linear Regression Intercept");
            //AddNewIndicator("Price Volume Trend");
            //AddNewIndicator("Performance Index");
            //AddNewIndicator("Commodity Channel Index");
            //AddNewIndicator("Chaikin Money Flow");
            //AddNewIndicator("Weighted Close");
            //AddNewIndicator("Volume ROC");
            //AddNewIndicator("Typical Price");
            //AddNewIndicator("Standard Deviation");
            //AddNewIndicator("Price ROC");
            //AddNewIndicator("Median");
            //AddNewIndicator("High Minus Low");
            //AddNewIndicator("Bollinger Bands");
            //AddNewIndicator("Fractal Chaos Bands");
            //AddNewIndicator("High Low Bands");
            //AddNewIndicator("Moving Average Envelope");
            //AddNewIndicator("Swing Index");
            //AddNewIndicator("Accumulative Swing Index");
            //AddNewIndicator("Comperative RSI");
            //AddNewIndicator("Mass Index");
            //AddNewIndicator("Money Flow Index");
            //AddNewIndicator("Negative Volume Index");
            //AddNewIndicator("On Balance Volume");
            //AddNewIndicator("Positive Volume Index");
            //AddNewIndicator("Relative Strength Index");
            //AddNewIndicator("Trade Volume Index");
            //AddNewIndicator("Stochastic Oscillator");
            //AddNewIndicator("Stochastic Momentum Index");
            //AddNewIndicator("Fractal Chaos Oscillator");
            //AddNewIndicator("Prime Number Oscillator");
            //AddNewIndicator("Prime Number Bands");
            //AddNewIndicator("Historical Volatility");
            //AddNewIndicator("MACD Histogram");
            //AddNewIndicator("Custom Indicator");
            //AddNewIndicator("Last Indicator");

            indicatorListValues.Sort();
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private static void AddNewIndicator(string p)
        {
            indicatorListValues.Add(p);
            indicatorIndexForStockChart.Add(p, _index++);
        }

        public static int GetIndicatorIndex(string p)
        {
            int retVal = -1;
            if (indicatorIndexForStockChart.Contains(p))
            {
                retVal = (int) indicatorIndexForStockChart[p];
            }
            return retVal;
        }
    }
}