using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TWS.Cls
{
    public static class IndicatorList
    {
        private static bool _bLoaded;
        private static readonly List<String> indicatorListValues = new List<string>();
        private static readonly Hashtable indicatorIndexForStockChart = new Hashtable();
        private static int _index;


        //Gets a chart selection from the user


        private static string[] IndicatorListValues
        {
            get
            {
                if (_bLoaded == false)
                {
                    LoadListValues();
                    _bLoaded = true;
                }
                return indicatorListValues.ToArray();
            }
        }

        //Start of function to populate Indicator List
        public static void PopulateIndicatorList(ref TreeNode node)
        {
            int length = IndicatorListValues.Length;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    string nodeName = ("Node_" + IndicatorListValues[i]).Replace(" ", "");
                    TreeNode newNode = node.Nodes.Add(nodeName, IndicatorListValues[i]);

                    newNode.ImageIndex = 0;
                    newNode.SelectedImageIndex = 0;
                }
            }
        }

        private static void LoadListValues()
        {
            //try
            //{
            AddNewIndicator("Simple Moving Average");
            AddNewIndicator("Exponential Moving Average");
            AddNewIndicator("Time Series Moving Average");
            AddNewIndicator("Triangular Moving Average");
            AddNewIndicator("Variable Moving Average");
            AddNewIndicator("VIDYA");
            AddNewIndicator("Welles Wilder Smoothing");
            AddNewIndicator("Weighted Moving Average");
            AddNewIndicator("Williams Pct R");
            AddNewIndicator("Williams Accumulation Distribution");
            AddNewIndicator("Volume Oscillator");
            AddNewIndicator("Vertical Horizontal Filter");
            AddNewIndicator("Ultimate Oscillator");
            AddNewIndicator("True Range");
            AddNewIndicator("TRIX");
            AddNewIndicator("Rainbow Oscillator");
            AddNewIndicator("Price Oscillator");
            AddNewIndicator("Parabolic SAR");
            AddNewIndicator("Momentum Oscillator");
            AddNewIndicator("MACD");
            AddNewIndicator("Ease Of Movement");
            AddNewIndicator("Directional Movement System");
            AddNewIndicator("Detrended Price Oscillator");
            AddNewIndicator("Chande Momentum Oscillator");
            AddNewIndicator("Chalkin Volatility");
            AddNewIndicator("Aroon");
            AddNewIndicator("Aroon Oscillator");
            AddNewIndicator("Linear Regression Required");
            AddNewIndicator("Linear Regressin Forecast");
            AddNewIndicator("Linear Regression Slope");
            AddNewIndicator("Linear Regression Intercept");
            AddNewIndicator("Price Volume Trend");
            AddNewIndicator("Performance Index");
            AddNewIndicator("Commodity Channel Index");
            AddNewIndicator("Chaikin Money Flow");
            AddNewIndicator("Weighted Close");
            AddNewIndicator("Volume ROC");
            AddNewIndicator("Typical Price");
            AddNewIndicator("Standard Deviation");
            AddNewIndicator("Price ROC");
            AddNewIndicator("Median");
            AddNewIndicator("High Minus Low");
            AddNewIndicator("Bollinger Bands");
            AddNewIndicator("Fractal Chaos Bands");
            AddNewIndicator("High Low Bands");
            AddNewIndicator("Moving Average Envelope");
            AddNewIndicator("Swing Index");
            AddNewIndicator("Accumulative Swing Index");
            AddNewIndicator("Comperative RSI");
            AddNewIndicator("Mass Index");
            AddNewIndicator("Money Flow Index");
            AddNewIndicator("Negative Volume Index");
            AddNewIndicator("On Balance Volume");
            AddNewIndicator("Positive Volume Index");
            AddNewIndicator("Relative Strength Index");
            AddNewIndicator("Trade Volume Index");
            AddNewIndicator("Stochastic Oscillator");
            AddNewIndicator("Stochastic Momentum Index");
            AddNewIndicator("Fractal Chaos Oscillator");
            AddNewIndicator("Prime Number Oscillator");
            AddNewIndicator("Prime Number Bands");
            AddNewIndicator("Historical Volatility");
            AddNewIndicator("MACD Histogram");
            AddNewIndicator("Custom Indicator");
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