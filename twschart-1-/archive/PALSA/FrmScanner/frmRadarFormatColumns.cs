using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;
using PALSA.uctl;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PALSA.FrmScanner
{
    public partial class frmRadarFormatColumns : NForm
    {
        public class Column
        {
            public string indicatorname;
            public string ABR;
            public string script;
        }

        //private frmMain m_frmmain;
        private List<string> m_existing=new List<string>();
        //private List<string> m_columns = new List<string>();
        //public List<string> Columns
        //{
        //    get { return m_columns; }
        //    set { m_columns = value; }
        //}
        private List<Column> m_columns = new List<Column>();
        public List<Column> Columns
        {
            get { return m_columns; }
            set { m_columns = value; }
        }
        private CustomIndicatorCollection m_CustomIndicators = new CustomIndicatorCollection();

        public frmRadarFormatColumns(List<string> existing)//Kul(frmMain mainform, List<string> existing)
        {
            InitializeComponent();
            //Kul
            //m_frmmain = mainform;
            //m_CustomIndicators = m_frmmain.CustomIndicators;
            for (int k = 0; k < existing.Count; k++)
            {
                m_existing.Add(existing[k]);
            }}

        private void frmFormatRadarColumns_Load(object sender, EventArgs e)
        {
            tvAll.Nodes.Add(new TreeNode("% Move", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Accumulative Swing Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("ADX", 0, 0));
            tvAll.Nodes.Add(new TreeNode("ADXR", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Aroon", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Bid", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Bid Volume", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Bollinger Bands Bottom", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Bollinger Bands Middle", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Bollinger Bands Top", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Chande Momentum Oscillator", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Chaikin Money Flow Index", 0, 0));            
            tvAll.Nodes.Add(new TreeNode("Chaikin Volatility", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Close", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Commodity Channel Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Comparative Relative Strength Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Correlation Analysis", 0, 0));            
            tvAll.Nodes.Add(new TreeNode("Daily Value", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Daily Volume", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Deals", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Detrended Price Oscillator", 0, 0));            
            tvAll.Nodes.Add(new TreeNode("DIN", 0, 0));
            tvAll.Nodes.Add(new TreeNode("DIP", 0, 0));
            tvAll.Nodes.Add(new TreeNode("DX", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Ease Of Movement", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Exponential Moving Average", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Forecast", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Fractal Chaos Oscillator", 0, 0));
            tvAll.Nodes.Add(new TreeNode("High", 0, 0));
            tvAll.Nodes.Add(new TreeNode("High Minus Low", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Highest High Value", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Historical Volatility Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Intercept", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Interval", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Keltner Channel Bottom", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Keltner Channel Median", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Keltner Channel Top", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Lowest Low Value", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Low", 0, 0));
            tvAll.Nodes.Add(new TreeNode("MACD", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Mass Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Median Price", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Momentum Oscillator", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Money Flow Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Move", 0, 0));            
            tvAll.Nodes.Add(new TreeNode("Moving Average Envelope Bottom", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Moving Average Envelope Top", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Negative Volume Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("On Balance Volume", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Offer", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Offer volume", 0, 0));            
            tvAll.Nodes.Add(new TreeNode("ParabolicSAR", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Performance Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Positive Volume Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Price Oscillator", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Price Rate of Change", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Price Volume Trend", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Prime Number Bands Bottom", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Prime Number Bands Top", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Prime Number Oscillator", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Rainbow Oscillator", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Relative Strength Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("RSquared", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Simple Moving Average", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Slope", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Standard Deviations", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Stochastic Momentum Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Stochastic Oscillator", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Swing Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Time Series Moving Average", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Trade Volume Index", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Triangular Moving Average", 0, 0));
            tvAll.Nodes.Add(new TreeNode("TRIX", 0, 0));
            tvAll.Nodes.Add(new TreeNode("TRSUM", 0, 0));
            tvAll.Nodes.Add(new TreeNode("True Range", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Typical Price", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Variable Moving Average", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Vertical Horizontal Filter", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Volatility Index Dynamic Average", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Volume Oscillator", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Volume Rate of Change", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Weighted Close", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Weighted Moving Average", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Welles Wilder Smoothing", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Williams %R", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Williams Accumulation / Distribution", 0, 0));
            tvAll.Nodes.Add(new TreeNode("Yesterday Close", 0, 0));  
            for (int i = 0; i < m_CustomIndicators.Count; i++)
            {
                if (m_CustomIndicators[i].IsDisplayInQuickList)
                    tvAll.Nodes.Add(new TreeNode(m_CustomIndicators[i].Name, 0,0) { Tag = m_CustomIndicators[i] });
            }
            for (int i = 0; i < m_existing.Count; i++)
            {
                string script = "";
                string ABR = "";
                switch (m_existing[i])
                {
                    case "Simple Moving Average":
                        {
                            script = "SMA(CLOSE, 30) > CLOSE";
                            ABR = "SMA";
                        }
                        break;
                    case "Exponential Moving Average":
                        {
                            script = "EMA(CLOSE, 30) > CLOSE";
                            ABR = "EMA";
                        }
                        break;
                    case "Time Series Moving Average":
                        {
                            script = "TSMA(CLOSE, 30) > CLOSE";
                            ABR = "TSMA";
                        }
                        break;
                    case "Variable Moving Average":
                        {
                            script = "VMA(CLOSE, 30) > CLOSE";
                            ABR = "VMA";
                        }
                        break;
                    case "Triangular Moving Average":
                        {
                            script = "TMA(CLOSE, 30) > CLOSE";
                            ABR = "TMA";
                        }
                        break;
                    case "Weighted Moving Average":
                        {
                            script = "WMA(CLOSE, 30) > CLOSE";
                            ABR = "WMA";
                        }
                        break;
                    case "Welles Wilder Smoothing":
                        {
                            script = "WWS(CLOSE, 30) > CLOSE";
                            ABR = "WWS";
                        }
                        break;
                    case "Volatility Index Dynamic Average":
                        {
                            script = "VIDYA(CLOSE, 30, 0.65) > CLOSE";
                            ABR = "VIDYA";
                        }
                        break;
                    case "RSquared":
                        {
                            script = "R2(CLOSE, 30) < 0.1";
                            ABR = "R2";
                        }
                        break;
                    case "Slope":
                        {
                            script = "SLOPE(CLOSE, 30) > 0.3";
                            ABR = "SLOPE";
                        }
                        break;
                    case "Forecast":
                        {
                            script = "Forecast(CLOSE, 30) > REF(CLOSE,1)";
                            ABR = "Forecast";
                        }
                        break;
                    case "Intercept":
                        {
                            script = "Intercept(CLOSE, 30) > REF(CLOSE,1)";
                            ABR = "Intercept";
                        }
                        break;
                    case "Bollinger Bands Top":
                        {
                            script = "BBT(CLOSE, 20, 2, EXPONENTIAL) > CLOSE";
                            ABR = "BBT";
                        }
                        break;
                    case "Bollinger Bands Middle":
                        {
                            script = "BBM(CLOSE, 20, 2, EXPONENTIAL) > CLOSE";
                            ABR = "BBM";
                        }
                        break;
                    case "Bollinger Bands Bottom":
                        {
                            script = "BBB(CLOSE, 20, 2, EXPONENTIAL) > CLOSE";
                            ABR = "BBB";
                        }
                        break;
                    case "Keltner Channel Top":
                        {
                            script = "KCT(15, EXPONENTIAL, 1.3) > CLOSE";
                            ABR = "KCT";
                        }
                        break;
                    case "Keltner Channel Median":
                        {
                            script = "KCM(15, EXPONENTIAL, 1.3) > CLOSE";
                            ABR = "KCM";
                        }
                        break;
                    case "Keltner Channel Bottom":
                        {
                            script = "KCB(15, EXPONENTIAL, 1.3) > CLOSE";
                            ABR = "KCB";
                        }
                        break;
                    case "Moving Average Envelope Top":
                        {
                            script = "MAET(20, SIMPLE, 5) > CLOSE";
                            ABR = "MAET";
                        }
                        break;
                    case "Moving Average Envelope Bottom":
                        {
                            script = "MAEB(20, SIMPLE, 5) > CLOSE";
                            ABR = "MAEB";
                        }
                        break;
                    case "Prime Number Bands Top":
                        {
                            script = "PNBT() > CLOSE";
                            ABR = "PNBT";
                        }
                        break;
                    case "Prime Number Bands Bottom":
                        {
                            script = "PNBB() > CLOSE";
                            ABR = "PNBB";
                        }
                        break;
                    case "Momentum Oscillator":
                        {
                            script = "MO(CLOSE, 14) > 90";
                            ABR = "MO";
                        }
                        break;
                    case "Chande Momentum Oscillator":
                        {
                            script = "CMO(CLOSE, 14) > 48";
                            ABR = "CMO";
                        }
                        break;
                    case "Volume Oscillator":
                        {
                            script = "VO(9, 21, SIMPLE, PERCENT) > 0";
                            ABR = "VO";
                        }
                        break;
                    case "Price Oscillator":
                        {
                            script = "PO(CLOSE, 9, 14, SIMPLE) > 0";
                            ABR = "PO";
                        }
                        break;
                    case "Detrended Price Oscillator":
                        {
                            script = "DPO(CLOSE, 20, SIMPLE) > 0";
                            ABR = "DPO";
                        }
                        break;
                    case "Prime Number Oscillator":
                        {
                            script = "PNO(CLOSE) = REF(PNO(CLOSE), 1)";
                            ABR = "PNO";
                        }
                        break;
                    case "Fractal Chaos Oscillator":
                        {
                            script = "FCO(21) > REF(FCO(21),1)";
                            ABR = "FCO";
                        }
                        break;
                    case "Rainbow Oscillator":
                        {
                            script = "RBO(CLOSE, 3, SIMPLE)>0.8";
                            ABR = "RBO";
                        }
                        break;
                    case "TRIX":
                        {
                            script = "TRIX(CLOSE, 9) > 0.9";
                            ABR = "TRIX";
                        }
                        break;
                    case "Vertical Horizontal Filter":
                        {
                            script = "VHF(CLOSE, 21) < 0.2";
                            ABR = "VHF";
                        }
                        break;
                    case "Ease Of Movement":
                        {
                            script = "EOM(CLOSE, 21) > 0";
                            ABR = "EOM";
                        }
                        break;
                    case "ADX":
                        {
                            script = "ADX(14) > 60";
                            ABR = "ADX";
                        }
                        break;
                    case "ADXR":
                        {
                            script = "ADXR(14) > 60";
                            ABR = "ADXR";
                        }
                        break;
                    case "DIP":
                        {
                            script = "DIP(14) > 60";
                            ABR = "DIP";
                        }
                        break;
                    case "DIN":
                        {
                            script = "DIN(14) > 60";
                            ABR = "DIN";
                        }
                        break;
                    case "TRSUM":
                        {
                            script = "TRSUM(14) > 60";
                            ABR = "TRSUM";
                        }
                        break;
                    case "DX":
                        {
                            script = "DX(14) > 60";
                            ABR = "DX";
                        }
                        break;
                    case "True Range":
                        {
                            script = "TR() > 1.95";
                            ABR = "TR";
                        }
                        break;
                    case "Williams %R":
                        {
                            script = "WPR(14) < -80";
                            ABR = "WPR";
                        }
                        break;
                    case "Williams Accumulation / Distribution":
                        {
                            script = "WAD() < 1";
                            ABR = "WAD";
                        }
                        break;
                    case "Chaikin Volatility":
                        {
                            script = "CV(10, 10, SIMPLE) < -25";
                            ABR = "CV";
                        }
                        break;
                    case "Aroon":
                        {
                            script = "AroonUp(25) > 80 AND AroonDown(25) > 80";
                            ABR = "Aroon";
                        }
                        break;
                    case "MACD":
                        {
                            script = "SET A = MACDSignal(13, 26, 9, SIMPLE) SET B = MACD(13, 26, 9, SIMPLE) CROSSOVER(A, B) = TRUE";
                            ABR = "MACD";
                        }
                        break;
                    case "High Minus Low":
                        {
                            script = "SET A = SMA(HML(), 14) A > REF(A, 10)";
                            ABR = "HML";
                        }
                        break;
                    case "Stochastic Oscillator":
                        {
                            script = "SOPK(9, 3, 9, SIMPLE) > 80 OR SOPD(9, 3, 9, SIMPLE) > 80";
                            ABR = "SOP";
                        }
                        break;
                    case "Relative Strength Index":
                        {
                            script = "RSI(CLOSE, 14) > 55";
                            ABR = "RSI";
                        }
                        break;
                    case "Mass Index":
                        {
                            script = "MI(25) > 27";
                            ABR = "MI";
                        }
                        break;
                    case "Historical Volatility Index":
                        {
                            script = "HVI(CLOSE, 15, 30, 2) < 0.01";
                            ABR = "HVI";
                        }
                        break;
                    case "Money Flow Index":
                        {
                            script = "MFI(15) < 20";
                            ABR = "MFI";
                        }
                        break;
                    case "Chaikin Money Flow Index":
                        {
                            script = "CMF(15) > 20 AND REF(CMF(15), 1) > 20";
                            ABR = "CMF";
                        }
                        break;
                    case "Comparative Relative Strength Index":
                        {
                            script = "CRSI(CLOSE, VOLUME) > 1";
                            ABR = "CRSI";
                        }
                        break;
                    case "Price Volume Trend":
                        {
                            script = "TREND(PVT(CLOSE)) = UP";
                            ABR = "PVT";
                        }
                        break;
                    case "Positive Volume Index":
                        {
                            script = "TREND(PVI(CLOSE)) = UP";
                            ABR = "PVI";
                        }
                        break;
                    case "Negative Volume Index":
                        {
                            script = "TREND(NVI(CLOSE)) = UP";
                            ABR = "NVI";
                        }
                        break;
                    case "On Balance Volume":
                        {
                            script = "TREND(OBV(CLOSE)) = UP";
                            ABR = "OBV";
                        }
                        break;
                    case "Performance Index":
                        {
                            script = "PFI(CLOSE) > 45";
                            ABR = "PFI";
                        }
                        break;
                    case "Trade Volume Index":
                        {
                            script = "TVI(CLOSE, 0.25) > 0";
                            ABR = "TVI";
                        }
                        break;
                    case "Swing Index":
                        {
                            script = "SI(1) > 0";
                            ABR = "SI";
                        }
                        break;
                    case "Accumulative Swing Index":
                        {
                            script = "TREND(ASI(1)) > UP";
                            ABR = "ASI";
                        }
                        break;
                    case "Commodity Channel Index":
                        {
                            script = "CCI(12, SIMPLE) > 0 AND REF(CCI(12, SIMPLE), 1) < 0";
                            ABR = "CCI";
                        }
                        break;
                    case "ParabolicSAR":
                        {
                            script = "CROSSOVER(CLOSE, PSAR(0.02, 0.2)) = TRUE";
                            ABR = "PSAR";
                        }
                        break;
                    case "Stochastic Momentum Index":
                        {
                            script = "SMID(14, 2, 3, 9, SIMPLE, SIMPLE) > 40 OR SMIK(14, 2, 3, 9, SIMPLE, SIMPLE) > 40";
                            ABR = "SMID";
                        }
                        break;
                    case "Median Price":
                        {
                            script = "MP() > CLOSE";
                            ABR = "MP";
                        }
                        break;
                    case "Typical Price":
                        {
                            script = "TP() > CLOSE";
                            ABR = "TP";
                        }
                        break;
                    case "Weighted Close":
                        {
                            script = "WC() > REF(WC(), 1)";
                            ABR = "WC";
                        }
                        break;
                    case "Price Rate of Change":
                        {
                            script = "PROC(CLOSE, 12) > 0 AND REF(PROC(CLOSE, 12),1) < 0";
                            ABR = "PROC";
                        }
                        break;
                    case "Volume Rate of Change":
                        {
                            script = "VROC(VOLUME, 12) > 0 AND REF(VROC(VOLUME, 12), 1) < 0";
                            ABR = "VROC";
                        }
                        break;
                    case "Highest High Value":
                        {
                            script = "HHV(21) > CLOSE";
                            ABR = "HHV";
                        }
                        break;
                    case "Lowest Low Value":
                        {
                            script = "LLV(21) < CLOSE";
                            ABR = "LLV";
                        }
                        break;
                    case "Standard Deviations":
                        {
                            script = "SDV(CLOSE, 21, 2, SIMPLE) > REF(SDV(CLOSE, 21, 2, SIMPLE), 10)";
                            ABR = "SDV";
                        }
                        break;
                    case "Correlation Analysis":
                        {
                            script = "CA(CLOSE, SMA(CLOSE, 14)) > 0.99";
                            ABR = "CA";
                        }
                        break;
                }
                Column c = new Column();
                c.ABR = ABR;
                c.indicatorname = m_existing[i];
                c.script = script;
                TreeNode n = new TreeNode(m_existing[i], 0, 0);
                n.Tag = c;
                tvCurrent.Nodes.Add(n);
            }  
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tvAll.SelectedNode!=null)
            {
                tvAll.Focus();
                for (int k = 0; k < tvCurrent.Nodes.Count;k++ )
                {
                    if (tvCurrent.Nodes[k].Text == tvAll.SelectedNode.Text)
                    {
                        return;
                    }
                }
                string script="";
                string ABR="";
                switch (tvAll.SelectedNode.Text)
                {
                    case "Simple Moving Average":
                        {
                            script = "SMA(CLOSE, 30) > CLOSE";
                            ABR = "SMA";
                        }
                        break;
                    case "Exponential Moving Average":
                        {
                            script = "EMA(CLOSE, 30) > CLOSE";
                            ABR = "EMA";
                        }
                        break;
                    case "Time Series Moving Average":
                        {
                            script = "TSMA(CLOSE, 30) > CLOSE";
                            ABR = "TSMA";
                        }
                        break;
                    case "Variable Moving Average":
                        {
                            script = "VMA(CLOSE, 30) > CLOSE";
                            ABR = "VMA";
                        }
                        break;
                    case "Triangular Moving Average":
                        {
                            script = "TMA(CLOSE, 30) > CLOSE";
                            ABR = "TMA";
                        }
                        break;
                    case "Weighted Moving Average":
                        {
                            script = "WMA(CLOSE, 30) > CLOSE";
                            ABR = "WMA";
                        }
                        break;
                    case "Welles Wilder Smoothing":
                        {
                            script = "WWS(CLOSE, 30) > CLOSE";
                            ABR = "WWS";
                        }
                        break;
                    case "Volatility Index Dynamic Average":
                        {
                            script = "VIDYA(CLOSE, 30, 0.65) > CLOSE";
                            ABR = "VIDYA";
                        }
                        break;
                    case "RSquared":
                        {
                            script = "R2(CLOSE, 30) < 0.1";
                            ABR = "R2";
                        }
                        break;
                    case "Slope":
                        {
                            script = "SLOPE(CLOSE, 30) > 0.3";
                            ABR = "SLOPE";
                        }
                        break;
                    case "Forecast":
                        {
                            script = "Forecast(CLOSE, 30) > REF(CLOSE,1)";
                            ABR = "Forecast";
                        }
                        break;
                    case "Intercept":
                        {
                            script = "Intercept(CLOSE, 30) > REF(CLOSE,1)";
                            ABR = "Intercept";
                        }
                        break;
                    case "Bollinger Bands Top":
                        {
                            script = "BBT(CLOSE, 20, 2, EXPONENTIAL) > CLOSE";
                            ABR = "BBT";
                        }
                        break;
                    case "Bollinger Bands Middle":
                        {
                            script = "BBM(CLOSE, 20, 2, EXPONENTIAL) > CLOSE";
                            ABR = "BBM";
                        }
                        break;
                    case "Bollinger Bands Bottom":
                        {
                            script = "BBB(CLOSE, 20, 2, EXPONENTIAL) > CLOSE";
                            ABR = "BBB";
                        }
                        break;
                    case "Keltner Channel Top":
                        {
                            script = "KCT(15, EXPONENTIAL, 1.3) > CLOSE";
                            ABR = "KCT";
                        }
                        break;
                    case "Keltner Channel Median":
                        {
                            script = "KCM(15, EXPONENTIAL, 1.3) > CLOSE";
                            ABR = "KCM";
                        }
                        break;
                    case "Keltner Channel Bottom":
                        {
                            script = "KCB(15, EXPONENTIAL, 1.3) > CLOSE";
                            ABR = "KCB";
                        }
                        break;
                    case "Moving Average Envelope Top":
                        {
                            script = "MAET(20, SIMPLE, 5) > CLOSE";
                            ABR = "MAET";
                        }
                        break;
                    case "Moving Average Envelope Bottom":
                        {
                            script = "MAEB(20, SIMPLE, 5) > CLOSE";
                            ABR = "MAEB";
                        }
                        break;
                    case "Prime Number Bands Top":
                        {
                            script = "PNBT() > CLOSE";
                            ABR = "PNBT";
                        }
                        break;
                    case "Prime Number Bands Bottom":
                        {
                            script = "PNBB() > CLOSE";
                            ABR = "PNBB";
                        }
                        break;
                    case "Momentum Oscillator":
                        {
                            script = "MO(CLOSE, 14) > 90";
                            ABR = "MO";
                        }
                        break;
                    case "Chande Momentum Oscillator":
                        {
                            script = "CMO(CLOSE, 14) > 48";
                            ABR = "CMO";
                        }
                        break;
                    case "Volume Oscillator":
                        {
                            script = "VO(9, 21, SIMPLE, PERCENT) > 0";
                            ABR = "VO";
                        }
                        break;
                    case "Price Oscillator":
                        {
                            script = "PO(CLOSE, 9, 14, SIMPLE) > 0";
                            ABR = "PO";
                        }
                        break;
                    case "Detrended Price Oscillator":
                        {
                            script = "DPO(CLOSE, 20, SIMPLE) > 0";
                            ABR = "DPO";
                        }
                        break;
                    case "Prime Number Oscillator":
                        {
                            script = "PNO(CLOSE) = REF(PNO(CLOSE), 1)";
                            ABR = "PNO";
                        }
                        break;
                    case "Fractal Chaos Oscillator":
                        {
                            script = "FCO(21) > REF(FCO(21),1)";
                            ABR = "FCO";
                        }
                        break;
                    case "Rainbow Oscillator":
                        {
                            script = "RBO(CLOSE, 3, SIMPLE)>0.8";
                            ABR = "RBO";
                        }
                        break;
                    case "TRIX":
                        {
                            script = "TRIX(CLOSE, 9) > 0.9";
                            ABR = "TRIX";
                        }
                        break;
                    case "Vertical Horizontal Filter":
                        {
                            script = "VHF(CLOSE, 21) < 0.2";
                            ABR = "VHF";
                        }
                        break;
                    case "Ease Of Movement":
                        {
                            script = "EOM(CLOSE, 21) > 0";
                            ABR = "EOM";
                        }
                        break;
                    case "ADX":
                        {
                            script = "ADX(14) > 60";
                            ABR = "ADX";
                        }
                        break;
                    case "ADXR":
                        {
                            script = "ADXR(14) > 60";
                            ABR = "ADXR";
                        }
                        break;
                    case "DIP":
                        {
                            script = "DIP(14) > 60";
                            ABR = "DIP";
                        }
                        break;
                    case "DIN":
                        {
                            script = "DIN(14) > 60";
                            ABR = "DIN";
                        }
                        break;
                    case "TRSUM":
                        {
                            script = "TRSUM(14) > 60";
                            ABR = "TRSUM";
                        }
                        break;
                    case "DX":
                        {
                            script = "DX(14) > 60";
                            ABR = "DX";
                        }
                        break;
                    case "True Range":
                        {
                            script = "TR() > 1.95";
                            ABR = "TR";
                        }
                        break;
                    case "Williams %R":
                        {
                            script = "WPR(14) < -80";
                            ABR = "WPR";
                        }
                        break;
                    case "Williams Accumulation / Distribution":
                        {
                            script = "WAD() < 1";
                            ABR = "WAD";
                        }
                        break;
                    case "Chaikin Volatility":
                        {
                            script = "CV(10, 10, SIMPLE) < -25";
                            ABR = "CV";
                        }
                        break;
                    case "Aroon":
                        {
                            script = "AroonUp(25) > 80 AND AroonDown(25) > 80";
                            ABR = "Aroon";
                        }
                        break;
                    case "MACD":
                        {
                            script = "SET A = MACDSignal(13, 26, 9, SIMPLE) SET B = MACD(13, 26, 9, SIMPLE) CROSSOVER(A, B) = TRUE";
                            ABR = "MACD";
                        }
                        break;
                    case "High Minus Low":
                        {
                            script = "SET A = SMA(HML(), 14) A > REF(A, 10)";
                            ABR = "HML";
                        }
                        break;
                    case "Stochastic Oscillator":
                        {
                            script = "SOPK(9, 3, 9, SIMPLE) > 80 OR SOPD(9, 3, 9, SIMPLE) > 80";
                            ABR = "SOP";
                        }
                        break;
                    case "Relative Strength Index":
                        {
                            script = "RSI(CLOSE, 14) > 55";
                            ABR = "RSI";
                        }
                        break;
                    case "Mass Index":
                        {
                            script = "MI(25) > 27";
                            ABR = "MI";
                        }
                        break;
                    case "Historical Volatility Index":
                        {
                            script = "HVI(CLOSE, 15, 30, 2) < 0.01";
                            ABR = "HVI";
                        }
                        break;
                    case "Money Flow Index":
                        {
                            script = "MFI(15) < 20";
                            ABR = "MFI";
                        }
                        break;
                    case "Chaikin Money Flow Index":
                        {
                            script = "CMF(15) > 20 AND REF(CMF(15), 1) > 20";
                            ABR = "CMF";
                        }
                        break;
                    case "Comparative Relative Strength Index":
                        {
                            script = "CRSI(CLOSE, VOLUME) > 1";
                            ABR = "CRSI";
                        }
                        break;
                    case "Price Volume Trend":
                        {
                            script = "TREND(PVT(CLOSE)) = UP";
                            ABR = "PVT";
                        }
                        break;
                    case "Positive Volume Index":
                        {
                            script = "TREND(PVI(CLOSE)) = UP";
                            ABR = "PVI";
                        }
                        break;
                    case "Negative Volume Index":
                        {
                            script = "TREND(NVI(CLOSE)) = UP";
                            ABR = "NVI";
                        }
                        break;
                    case "On Balance Volume":
                        {
                            script = "TREND(OBV(CLOSE)) = UP";
                            ABR = "OBV";
                        }
                        break;
                    case "Performance Index":
                        {
                            script = "PFI(CLOSE) > 45";
                            ABR = "PFI";
                        }
                        break;
                    case "Trade Volume Index":
                        {
                            script = "TVI(CLOSE, 0.25) > 0";
                            ABR = "TVI";
                        }
                        break;
                    case "Swing Index":
                        {
                            script = "SI(1) > 0";
                            ABR = "SI";
                        }
                        break;
                    case "Accumulative Swing Index":
                        {
                            script = "TREND(ASI(1)) > UP";
                            ABR = "ASI";
                        }
                        break;
                    case "Commodity Channel Index":
                        {
                            script = "CCI(12, SIMPLE) > 0 AND REF(CCI(12, SIMPLE), 1) < 0";
                            ABR = "CCI";
                        }
                        break;
                    case "ParabolicSAR":
                        {
                            script = "CROSSOVER(CLOSE, PSAR(0.02, 0.2)) = TRUE";
                            ABR = "PSAR";
                        }
                        break;
                    case "Stochastic Momentum Index":
                        {
                            script = "SMID(14, 2, 3, 9, SIMPLE, SIMPLE) > 40 OR SMIK(14, 2, 3, 9, SIMPLE, SIMPLE) > 40";
                            ABR = "SMD";
                        }
                        break;
                    case "Median Price":
                        {
                            script = "MP() > CLOSE";
                            ABR = "MP";
                        }
                        break;
                    case "Typical Price":
                        {
                            script = "TP() > CLOSE";
                            ABR = "TP";
                        }
                        break;
                    case "Weighted Close":
                        {
                            script = "WC() > REF(WC(), 1)";
                            ABR = "WC";
                        }
                        break;
                    case "Price Rate of Change":
                        {
                            script = "PROC(CLOSE, 12) > 0 AND REF(PROC(CLOSE, 12),1) < 0";
                            ABR = "PROC";
                        }
                        break;
                    case "Volume Rate of Change":
                        {
                            script = "VROC(VOLUME, 12) > 0 AND REF(VROC(VOLUME, 12), 1) < 0";
                            ABR = "VROC";
                        }
                        break;
                    case "Highest High Value":
                        {
                            script = "HHV(21) > CLOSE";
                            ABR = "HHV";
                        }
                        break;
                    case "Lowest Low Value":
                        {
                            script = "LLV(21) < CLOSE";
                            ABR = "LLV";
                        }
                        break;
                    case "Standard Deviations":
                        {
                            script = "SDV(CLOSE, 21, 2, SIMPLE) > REF(SDV(CLOSE, 21, 2, SIMPLE), 10)";
                            ABR = "SDV";
                        }
                        break;
                    case "Correlation Analysis":
                        {
                            script = "CA(CLOSE, SMA(CLOSE, 14)) > 0.99";
                            ABR = "CA";
                        }
                        break;
                }
                Column c = new Column();
                c.ABR = ABR;
                c.indicatorname = tvAll.SelectedNode.Text;
                c.script = script;
                TreeNode n = new TreeNode(tvAll.SelectedNode.Text, 0, 0);
                n.Tag = c;
                tvCurrent.Nodes.Add(n);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (tvCurrent.SelectedNode!=null)
            {
                tvCurrent.Focus();
                tvCurrent.Nodes.Remove(tvCurrent.SelectedNode);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < tvCurrent.Nodes.Count; k++)
            {
                m_columns.Add((Column)tvCurrent.Nodes[k].Tag);
                //m_columns.Add(tvCurrent.Nodes[k].Text);
            }
        }

        private void tvAll_Click(object sender, EventArgs e)
        {
            btnRemove.Enabled = false;
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnMoveDown.Enabled = false;
            btnMoveUp.Enabled = false;
        }

        private void tvCurrent_Click(object sender, EventArgs e)
        {
            btnRemove.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnMoveDown.Enabled = true;
            btnMoveUp.Enabled = true;
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (tvCurrent.SelectedNode!=null)
            {
                try
                {
                    string temp = tvCurrent.SelectedNode.Text;
                    int idx = 0;
                    for (int k = 0; k < tvCurrent.Nodes.Count;k++ )
                    {
                        if (tvCurrent.Nodes[k].Text==temp)
                        {
                            if (k==0)
                            {
                                tvCurrent.Focus();
                                return;
                            }
                            idx = k;
                            break;
                        }
                    }
                    tvCurrent.Nodes[idx].Text = tvCurrent.Nodes[idx-1].Text;
                    tvCurrent.Nodes[idx - 1].Text=temp;
                    tvCurrent.SelectedNode = tvCurrent.Nodes[idx - 1];
                    tvCurrent.Focus();
                }
                catch (System.Exception ex)
                {}
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (tvCurrent.SelectedNode != null)
            {
                try
                {
                    string temp = tvCurrent.SelectedNode.Text;
                    int idx = 0;
                    for (int k = 0; k < tvCurrent.Nodes.Count; k++)
                    {
                        if (tvCurrent.Nodes[k].Text == temp)
                        {
                            if (k == tvCurrent.Nodes.Count-1)
                            {
                                tvCurrent.Focus();
                                return;
                            }
                            idx = k;
                            break;
                        }
                    }
                    tvCurrent.Nodes[idx].Text = tvCurrent.Nodes[idx + 1].Text;
                    tvCurrent.Nodes[idx + 1].Text = temp;
                    tvCurrent.SelectedNode = tvCurrent.Nodes[idx + 1];
                    tvCurrent.Focus();
                }
                catch (System.Exception ex)
                { }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string script = "";
            string ABR = "";
            switch (tvAll.SelectedNode.Text)
            {
                case "Simple Moving Average":
                    {
                        script = "SMA(CLOSE, 30) > CLOSE";
                        ABR = "SMA";
                    }
                    break;
                case "Exponential Moving Average":
                    {
                        script = "EMA(CLOSE, 30) > CLOSE";
                        ABR = "EMA";
                    }
                    break;
                case "Time Series Moving Average":
                    {
                        script = "TSMA(CLOSE, 30) > CLOSE";
                        ABR = "TSMA";
                    }
                    break;
                case "Variable Moving Average":
                    {
                        script = "VMA(CLOSE, 30) > CLOSE";
                        ABR = "VMA";
                    }
                    break;
                case "Triangular Moving Average":
                    {
                        script = "TMA(CLOSE, 30) > CLOSE";
                        ABR = "TMA";
                    }
                    break;
                case "Weighted Moving Average":
                    {
                        script = "WMA(CLOSE, 30) > CLOSE";
                        ABR = "WMA";
                    }
                    break;
                case "Welles Wilder Smoothing":
                    {
                        script = "WWS(CLOSE, 30) > CLOSE";
                        ABR = "WWS";
                    }
                    break;
                case "Volatility Index Dynamic Average":
                    {
                        script = "VIDYA(CLOSE, 30, 0.65) > CLOSE";
                        ABR = "VIDYA";
                    }
                    break;
                case "RSquared":
                    {
                        script = "R2(CLOSE, 30) < 0.1";
                        ABR = "R2";
                    }
                    break;
                case "Slope":
                    {
                        script = "SLOPE(CLOSE, 30) > 0.3";
                        ABR = "SLOPE";
                    }
                    break;
                case "Forecast":
                    {
                        script = "Forecast(CLOSE, 30) > REF(CLOSE,1)";
                        ABR = "Forecast";
                    }
                    break;
                case "Intercept":
                    {
                        script = "Intercept(CLOSE, 30) > REF(CLOSE,1)";
                        ABR = "Intercept";
                    }
                    break;
                case "Bollinger Bands Top":
                    {
                        script = "BBT(CLOSE, 20, 2, EXPONENTIAL) > CLOSE";
                        ABR = "BBT";
                    }
                    break;
                case "Bollinger Bands Middle":
                    {
                        script = "BBM(CLOSE, 20, 2, EXPONENTIAL) > CLOSE";
                        ABR = "BBM";
                    }
                    break;
                case "Bollinger Bands Bottom":
                    {
                        script = "BBB(CLOSE, 20, 2, EXPONENTIAL) > CLOSE";
                        ABR = "BBB";
                    }
                    break;
                case "Keltner Channel Top":
                    {
                        script = "KCT(15, EXPONENTIAL, 1.3) > CLOSE";
                        ABR = "KCT";
                    }
                    break;
                case "Keltner Channel Median":
                    {
                        script = "KCM(15, EXPONENTIAL, 1.3) > CLOSE";
                        ABR = "KCM";
                    }
                    break;
                case "Keltner Channel Bottom":
                    {
                        script = "KCB(15, EXPONENTIAL, 1.3) > CLOSE";
                        ABR = "KCB";
                    }
                    break;
                case "Moving Average Envelope Top":
                    {
                        script = "MAET(20, SIMPLE, 5) > CLOSE";
                        ABR = "MAET";
                    }
                    break;
                case "Moving Average Envelope Bottom":
                    {
                        script = "MAEB(20, SIMPLE, 5) > CLOSE";
                        ABR = "MAEB";
                    }
                    break;
                case "Prime Number Bands Top":
                    {
                        script = "PNBT() > CLOSE";
                        ABR = "PNBT";
                    }
                    break;
                case "Prime Number Bands Bottom()":
                    {
                        script = "PNBB() > CLOSE";
                        ABR = "PNBB";
                    }
                    break;
                case "Momentum Oscillator":
                    {
                        script = "MO(CLOSE, 14) > 90";
                        ABR = "MO";
                    }
                    break;
                case "Chande Momentum Oscillator":
                    {
                        script = "CMO(CLOSE, 14) > 48";
                        ABR = "CMO";
                    }
                    break;
                case "Volume Oscillator":
                    {
                        script = "VO(9, 21, SIMPLE, PERCENT) > 0";
                        ABR = "VO";
                    }
                    break;
                case "Price Oscillator":
                    {
                        script = "PO(CLOSE, 9, 14, SIMPLE) > 0";
                        ABR = "PO";
                    }
                    break;
                case "Detrended Price Oscillator":
                    {
                        script = "DPO(CLOSE, 20, SIMPLE) > 0";
                        ABR = "DPO";
                    }
                    break;
                case "Prime Number Oscillator":
                    {
                        script = "PNO(CLOSE) = REF(PNO(CLOSE), 1)";
                        ABR = "PNO";
                    }
                    break;
                case "Fractal Chaos Oscillator":
                    {
                        script = "FCO(21) > REF(FCO(21),1)";
                        ABR = "FCO";
                    }
                    break;
                case "Rainbow Oscillator":
                    {
                        script = "RBO(CLOSE, 3, SIMPLE)>0.8";
                        ABR = "RBO";
                    }
                    break;
                case "TRIX":
                    {
                        script = "TRIX(CLOSE, 9) > 0.9";
                        ABR = "TRIX";
                    }
                    break;
                case "Vertical Horizontal Filter":
                    {
                        script = "VHF(CLOSE, 21) < 0.2";
                        ABR = "VHF";
                    }
                    break;
                case "Ease Of Movement":
                    {
                        script = "EOM(CLOSE, 21) > 0";
                        ABR = "EOM";
                    }
                    break;
                case "ADX":
                    {
                        script = "ADX(14) > 60";
                        ABR = "ADX";
                    }
                    break;
                case "ADXR":
                    {
                        script = "ADXR(14) > 60";
                        ABR = "ADXR";
                    }
                    break;
                case "DIP":
                    {
                        script = "DIP(14) > 60";
                        ABR = "DIP";
                    }
                    break;
                case "DIN":
                    {
                        script = "DIN(14) > 60";
                        ABR = "DIN";
                    }
                    break;
                case "TRSUM":
                    {
                        script = "TRSUM(14) > 60";
                        ABR = "TRSUM";
                    }
                    break;
                case "DX":
                    {
                        script = "DX(14) > 60";
                        ABR = "DX";
                    }
                    break;
                case "True Range":
                    {
                        script = "TR() > 1.95";
                        ABR = "TR";
                    }
                    break;
                case "Williams %R":
                    {
                        script = "WPR(14) < -80";
                        ABR = "WPR";
                    }
                    break;
                case "Williams Accumulation / Distribution":
                    {
                        script = "WAD() < 1";
                        ABR = "WAD";
                    }
                    break;
                case "Chaikin Volatility":
                    {
                        script = "CV(10, 10, SIMPLE) < -25";
                        ABR = "CV";
                    }
                    break;
                case "Aroon":
                    {
                        script = "AroonUp(25) > 80 AND AroonDown(25) > 80";
                        ABR = "Aroon";
                    }
                    break;
                case "MACD":
                    {
                        script = "SET A = MACDSignal(13, 26, 9, SIMPLE) SET B = MACD(13, 26, 9, SIMPLE) CROSSOVER(A, B) = TRUE";
                        ABR = "MACD";
                    }
                    break;
                case "High Minus Low":
                    {
                        script = "SET A = SMA(HML(), 14) A > REF(A, 10)";
                        ABR = "HML";
                    }
                    break;
                case "Stochastic Oscillator":
                    {
                        script = "SOPK(9, 3, 9, SIMPLE) > 80 OR SOPD(9, 3, 9, SIMPLE) > 80";
                        ABR = "SOP";
                    }
                    break;
                case "Relative Strength Index":
                    {
                        script = "RSI(CLOSE, 14) > 55";
                        ABR = "RSI";
                    }
                    break;
                case "Mass Index":
                    {
                        script = "MI(25) > 27";
                        ABR = "MI";
                    }
                    break;
                case "Historical Volatility Index":
                    {
                        script = "HVI(CLOSE, 15, 30, 2) < 0.01";
                        ABR = "HVI";
                    }
                    break;
                case "Money Flow Index":
                    {
                        script = "MFI(15) < 20";
                        ABR = "MFI";
                    }
                    break;
                case "Chaikin Money Flow Index":
                    {
                        script = "CMF(15) > 20 AND REF(CMF(15), 1) > 20";
                        ABR = "CMF";
                    }
                    break;
                case "Comparative Relative Strength Index":
                    {
                        script = "CRSI(CLOSE, VOLUME) > 1";
                        ABR = "CRSI";
                    }
                    break;
                case "Price Volume Trend":
                    {
                        script = "TREND(PVT(CLOSE)) = UP";
                        ABR = "PVT";
                    }
                    break;
                case "Positive Volume Index":
                    {
                        script = "TREND(PVI(CLOSE)) = UP";
                        ABR = "PVI";
                    }
                    break;
                case "Negative Volume Index":
                    {
                        script = "TREND(NVI(CLOSE)) = UP";
                        ABR = "NVI";
                    }
                    break;
                case "On Balance Volume":
                    {
                        script = "TREND(OBV(CLOSE)) = UP";
                        ABR = "OBV";
                    }
                    break;
                case "Performance Index":
                    {
                        script = "PFI(CLOSE) > 45";
                        ABR = "PFI";
                    }
                    break;
                case "Trade Volume Index":
                    {
                        script = "TVI(CLOSE, 0.25) > 0";
                        ABR = "TVI";
                    }
                    break;
                case "Swing Index":
                    {
                        script = "SI(1) > 0";
                        ABR = "SI";
                    }
                    break;
                case "Accumulative Swing Index":
                    {
                        script = "TREND(ASI(1)) > UP";
                        ABR = "ASI";
                    }
                    break;
                case "Commodity Channel Index":
                    {
                        script = "CCI(12, SIMPLE) > 0 AND REF(CCI(12, SIMPLE), 1) < 0";
                        ABR = "CCI";
                    }
                    break;
                case "ParabolicSAR":
                    {
                        script = "CROSSOVER(CLOSE, PSAR(0.02, 0.2)) = TRUE";
                        ABR = "PSAR";
                    }
                    break;
                case "Stochastic Momentum Index":
                    {
                        script = "SMID(14, 2, 3, 9, SIMPLE, SIMPLE) > 40 OR SMIK(14, 2, 3, 9, SIMPLE, SIMPLE) > 40";
                        ABR = "SMID";
                    }
                    break;
                case "Median Price":
                    {
                        script = "MP() > CLOSE";
                        ABR = "MP";
                    }
                    break;
                case "Typical Price":
                    {
                        script = "TP() > CLOSE";
                        ABR = "TP";
                    }
                    break;
                case "Weighted Close":
                    {
                        script = "WC() > REF(WC(), 1)";
                        ABR = "WC";
                    }
                    break;
                case "Price Rate of Change":
                    {
                        script = "PROC(CLOSE, 12) > 0 AND REF(PROC(CLOSE, 12),1) < 0";
                        ABR = "PROC";
                    }
                    break;
                case "Volume Rate of Change":
                    {
                        script = "VROC(VOLUME, 12) > 0 AND REF(VROC(VOLUME, 12), 1) < 0";
                        ABR = "VROC";
                    }
                    break;
                case "Highest High Value":
                    {
                        script = "HHV(21) > CLOSE";
                        ABR = "HHV";
                    }
                    break;
                case "Lowest Low Value":
                    {
                        script = "LLV(21) < CLOSE";
                        ABR = "LLV";
                    }
                    break;
                case "Standard Deviations":
                    {
                        script = "SDV(CLOSE, 21, 2, SIMPLE) > REF(SDV(CLOSE, 21, 2, SIMPLE), 10)";
                        ABR = "SDV";
                    }
                    break;
                case "Correlation Analysis":
                    {
                        script = "CA(CLOSE, SMA(CLOSE, 14)) > 0.99";
                        ABR = "CA";
                    }
                    break;
                default:
                    {
                        MessageBox.Show("You can't edit this column", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
            }
            frmRadarIndicatorEdit frie = new frmRadarIndicatorEdit(tvAll.SelectedNode.Text, script);
            if (frie.ShowDialog()==DialogResult.OK)
            {
                if (frie.Script.Length>0)
                {
                    Column c = new Column();
                    c.ABR = ABR;
                    c.indicatorname = tvAll.SelectedNode.Text;
                    c.script = frie.Script;
                    TreeNode n = new TreeNode(tvAll.SelectedNode.Text, 0, 0);
                    n.Tag = c;
                    tvCurrent.Nodes.Add(n);
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Kul m_frmmain.DisplayHelp();
        }
    }

    [Serializable]
    public class CustomIndicator
    {
        public Guid Id;
        public string Name;
        public string Script;
        public bool IsDisplayInQuickList;

        public CustomIndicator()
        {

        }

        public CustomIndicator(Guid aId, string aName, string aScript, bool aIsDisplay)
        {
            Id = aId;
            Name = aName;
            Script = aScript;
            IsDisplayInQuickList = aIsDisplay;
        }
    }

    [Serializable]
    public class CustomIndicatorCollection : List<CustomIndicator>
    {
        public static CustomIndicatorCollection Load(string fileName)
        {
            BinaryFormatter m_Serializer = new BinaryFormatter();
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (CustomIndicatorCollection)m_Serializer.Deserialize(fs);
                }
            }
            return new CustomIndicatorCollection();
        }

        public void Save(string fileName)
        {
            BinaryFormatter m_Serializer = new BinaryFormatter();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            m_Serializer.Serialize(fs, this);
        }

        public CustomIndicator GetIndicator(string name)
        {
            foreach (CustomIndicator cusInd in this)
            {
                if (cusInd.Name == name)
                    return cusInd;
            }
            return null;
        }
    }

    [Serializable]
    public class CusIndSeriesProperty
    {
        public string Name;
        public Color Color;
        public int Weigh;
        public int Style;
        public string Script;
        public int OutIndex = -1;

        public CusIndSeriesProperty()
        {

        }

        public CusIndSeriesProperty(string aName, Color aColor, int aWeigh, int aStyle, string aScript)
        {
            Name = aName;
            Color = aColor;
            Weigh = aWeigh;
            Style = aStyle;
            Script = aScript;
        }
    }
}
