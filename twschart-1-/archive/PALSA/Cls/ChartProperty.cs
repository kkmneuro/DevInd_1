using System;
using System.Drawing;
using System.Text;

namespace PALSA.Cls
{
    public class BarData
    {
        public double ClosePrice;
        public double HighPrice;
        public double LowPrice;
        public double OpenPrice;
        public double Volume;
        public Int64 iTradeDate;

        public DateTime TradeDate
        {
            get { return DateTime.FromBinary(iTradeDate); }
        }
    }

    //[Serializable]
    public class ChartProperty
    {
        // Color Properties
        public int slectedStyleIndex = 3;
        public bool IsStyle = false;
        public Color DownOutLine;
        public Color UpOutLine;
        public Color Crosshair;
        public Color SLLine;
        public Color TPPline;
        public bool ThreeDStyle;
        public Color askLine;
        public Color backGround;
        public bool barChart;
        public Color barDown;
        public Color barUp;
        public Color bearCandle;
        public Color bullCandle;
        public bool candleSticks;
        public bool chartAutoScroll;
        public bool chartShift;
        public Color foreGround;
        public bool forgroundChart;
        public Color grid;
        public bool lineChart;
        public Color lineGraph;
        public double maxYScale;
        public double minYScale;
        public bool objDescription;
        // Common Properties
        public bool offlinechart;
        public bool periodSeperator;
        public bool scaleFix;
        public bool scaleFixOne;
        public bool showAskLine;
        public bool showGrid;
        public bool showOHLC;
        public bool showVolume;
        public Color stopLevels;
        public Color volume;

        /// <summary>
        /// This function sets All Default charts property over charts whatever is sets through Chart Property forms.
        /// and Applied over charts.
        /// </summary>
        /// <param name="prop"></param>
        public void SetChartProperty(string prop)
        {
            string[] propertyArr = prop.Split('^');

            if (propertyArr.Length == 31)
            {
                backGround = Color.FromArgb(int.Parse(propertyArr[0]));
                foreGround = Color.FromArgb(int.Parse(propertyArr[1]));
                grid = Color.FromArgb(int.Parse(propertyArr[2]));
                barUp = Color.FromArgb(int.Parse(propertyArr[3]));
                barDown = Color.FromArgb(int.Parse(propertyArr[4]));
                bullCandle = Color.FromArgb(int.Parse(propertyArr[5]));
                bearCandle = Color.FromArgb(int.Parse(propertyArr[6]));
                lineGraph = Color.FromArgb(int.Parse(propertyArr[7]));
                volume = Color.FromArgb(int.Parse(propertyArr[8]));
                askLine = Color.FromArgb(int.Parse(propertyArr[9]));
                stopLevels = Color.FromArgb(int.Parse(propertyArr[10]));

                offlinechart = bool.Parse(propertyArr[11]);
                forgroundChart = bool.Parse(propertyArr[12]);
                chartShift = bool.Parse(propertyArr[13]);
                scaleFixOne = bool.Parse(propertyArr[14]);
                scaleFix = bool.Parse(propertyArr[15]);
                candleSticks = bool.Parse(propertyArr[17]);
                lineChart = bool.Parse(propertyArr[18]);
                showOHLC = bool.Parse(propertyArr[19]);
                showAskLine = bool.Parse(propertyArr[20]);
                periodSeperator = bool.Parse(propertyArr[21]);
                showGrid = bool.Parse(propertyArr[22]);
                showVolume = bool.Parse(propertyArr[23]);
                objDescription = bool.Parse(propertyArr[24]);
                minYScale = double.Parse(propertyArr[25]);
                maxYScale = double.Parse(propertyArr[26]);
                chartAutoScroll = bool.Parse(propertyArr[27]);
                ThreeDStyle = bool.Parse(propertyArr[28]);
                SLLine = Color.FromArgb(int.Parse(propertyArr[29]));
                TPPline = Color.FromArgb(int.Parse(propertyArr[30]));
            }
        }

        /// <summary>
        /// This function is used to create string format value for chart series datvalue used to store in file.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var chartProp = new StringBuilder();

            chartProp.Append(backGround.ToArgb());
            chartProp.Append("^");
            chartProp.Append(foreGround.ToArgb());
            chartProp.Append("^");
            chartProp.Append(grid.ToArgb());
            chartProp.Append("^");
            chartProp.Append(barUp.ToArgb());
            chartProp.Append("^");
            chartProp.Append(barDown.ToArgb());
            chartProp.Append("^");
            chartProp.Append(bullCandle.ToArgb());
            chartProp.Append("^");
            chartProp.Append(bearCandle.ToArgb());
            chartProp.Append("^");
            chartProp.Append(lineGraph.ToArgb());
            chartProp.Append("^");
            chartProp.Append(volume.ToArgb());
            chartProp.Append("^");
            chartProp.Append(askLine.ToArgb());
            chartProp.Append("^");
            chartProp.Append(stopLevels.ToArgb());
            chartProp.Append("^");
            chartProp.Append(offlinechart);
            chartProp.Append("^");
            chartProp.Append(forgroundChart);
            chartProp.Append("^");
            chartProp.Append(chartShift);
            chartProp.Append("^");
            chartProp.Append(scaleFixOne);
            chartProp.Append("^");
            chartProp.Append(scaleFix);
            chartProp.Append("^");
            chartProp.Append(barChart);
            chartProp.Append("^");
            chartProp.Append(candleSticks);
            chartProp.Append("^");
            chartProp.Append(lineChart);
            chartProp.Append("^");
            chartProp.Append(showOHLC);
            chartProp.Append("^");
            chartProp.Append(showAskLine);
            chartProp.Append("^");
            chartProp.Append(periodSeperator);
            chartProp.Append("^");
            chartProp.Append(showGrid);
            chartProp.Append("^");
            chartProp.Append(showVolume);
            chartProp.Append("^");
            chartProp.Append(objDescription);
            chartProp.Append("^");
            chartProp.Append(minYScale);
            chartProp.Append("^");
            chartProp.Append(maxYScale);
            chartProp.Append("^");
            chartProp.Append(chartAutoScroll);
            chartProp.Append("^");
            chartProp.Append(ThreeDStyle);
            chartProp.Append("^");
            chartProp.Append(SLLine.ToArgb());
            chartProp.Append("^");
            chartProp.Append(TPPline.ToArgb());
            return chartProp.ToString();
        }
    }
}