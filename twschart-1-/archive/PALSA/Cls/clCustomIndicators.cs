using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TradeScriptLib;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using STOCKCHARTXLib;
using PALSA.uctl;

namespace M4
{
    #region Classes

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

    [Serializable]
    public enum IndicatorType
    {
        Line,
        Histogram,
    }

    [Serializable]
    public enum IndicatorSite
    {
        OnChart,
        BelowChart
    }

    [Serializable]
    public class IndicatorParameters
    {
        public string Name;
        public string Text;
        public int MinValue;
        public int MaxValue;
        public int DefValue;
        public string Script;
        public int Value = -1;
        public IndicatorParameters()
        {

        }

        public IndicatorParameters(string aName, string aText, int aMin, int aMax, int aDef)
        {
            Name = aName;
            Text = aText;
            MinValue = aMin;
            MaxValue = aMax;
            DefValue = aDef;
        }
    }

    #endregion

    [Serializable]
    public class CustomIndicatorWorker
    {

        #region Variable
        [NonSerialized]
        //private ctlChart m_currentChart = null;
        private ctlNewChart m_currentChart = null;
        public CustomIndicator m_CurrentIndicator = null;
        [NonSerialized]
        private ScriptOutput m_Script = null;
        [NonSerialized]
        private bool m_Update = false;
        public List<CusIndSeriesProperty> m_SeriesProperties = new List<CusIndSeriesProperty>();
        public IndicatorType m_IndType;
        public IndicatorSite m_IndSite;
        public string m_RunScript;
        public List<IndicatorParameters> m_Parameters = new List<IndicatorParameters>();
        private const string m_ParametersBegin = "$";
        private const string m_ParametersFunctino = "INPUT";

        #endregion
        
        #region Init

        public CustomIndicatorWorker(ctlNewChart aChart, CustomIndicator aIndicator)
        {
            m_currentChart = aChart;
            m_CurrentIndicator = aIndicator;
            m_Script = new ScriptOutput();
            m_Script.License = "XRT93NQR79ABTW788XR48";
            ParseStartData();
        }

        public void LoadData(ctlNewChart aChart)
        {
            m_currentChart = aChart;
            m_Script = new ScriptOutput();
            m_Script.License = "XRT93NQR79ABTW788XR48";
        }

        #endregion

        #region Publick methods

        public static string GetScriptForRadarView(CustomIndicator aIndsicator)
        {
            string RunScript = GetFinishScript(aIndsicator.Script);
            string err = string.Empty;
            List<IndicatorParameters> Parameters = GetParameter(aIndsicator.Script, out err);
            foreach (IndicatorParameters param in Parameters)
                param.Value = param.DefValue;

            RunScript = ReplaceScript(RunScript, Parameters);

            return RunScript;
        }

        public static bool ValidateScript(string aScript)
        {
            TradeScriptLib.Validate script = new TradeScriptLib.Validate();
            script.License = "XRT93NQR79ABTW788XR48";
            aScript = GetFinishScript(aScript);
            string err = string.Empty;
            List<IndicatorParameters> par = GetParameter(aScript, out err);
            if (err != string.Empty)
            {
                MessageBox.Show(err, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            foreach (IndicatorParameters param in par)
                param.Value = param.DefValue;

            aScript = ReplaceScript(aScript, par);
            err = script.Validate(aScript);
            
            if (!string.IsNullOrEmpty(err))
            {
                if (!string.IsNullOrEmpty(script.ScriptHelp))
                {
                    if (MessageBox.Show("Your buy script generated an error:" + '\n' + err.Replace("Error: ", "") + '\n' + "Would you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Your buy script generated an error:" + '\n' + err.Replace("Error: ", ""), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
            return true;
        }

        public void AddIndicator()
        {
            Add();
        }

        public void PriceUpdate()
        {

            UpdateChart(false);
        }

        public void BarUpdate()
        {
            UpdateChart(true);
        }

        public CusIndSeriesProperty GetSeriesProperty(string name)
        {
            foreach (CusIndSeriesProperty ind in m_SeriesProperties)
            {
                if (ind.Name == name)
                    return ind;
            }
            return null;
        }

        public void UpdateProperties()
        {
            for (int i = 0; i < 50; i++)
                m_Script.AppendRecord(GetJDate(DateTime.Now.ToString(), m_currentChart), 0, 0, 0, 0, 0);

            m_RunScript = GetFinishScript(m_CurrentIndicator.Script);
            m_RunScript = ReplaceScript(m_RunScript, m_Parameters);
            string scripOut = m_Script.GetScriptOutput(m_RunScript);
            m_Script.ClearRecords();
            if (scripOut == null) return;
            List<string> headerLst = ParseHeader(scripOut.Split('\n')[0]);
            for (int i = 0; i < m_SeriesProperties.Count; i++)
            {
                if (headerLst.Count > 6 + i)
                    m_SeriesProperties[i].Script = headerLst[6 + i];
            }
        }

        #endregion

        #region Helper methods

        private void ParseStartData()
        {
            m_SeriesProperties = new List<CusIndSeriesProperty>();

            for (int i = 0; i < 50; i++)
                m_Script.AppendRecord(GetJDate(DateTime.Now.ToString(),m_currentChart), 0, 0, 0, 0, 0);

            m_RunScript = GetFinishScript(m_CurrentIndicator.Script);
            string err = string.Empty;
            m_Parameters = GetParameter(m_CurrentIndicator.Script, out err);
            foreach (IndicatorParameters param in m_Parameters)
                param.Value = param.DefValue;

            m_RunScript = ReplaceScript(m_RunScript, m_Parameters);
            string scripOut = m_Script.GetScriptOutput(m_RunScript);
            m_Script.ClearRecords();
            if (scripOut == null) return;
           List<string> headerLst = ParseHeader(scripOut.Split('\n')[0]);
           string seriosAdd = string.Empty;
           if (headerLst.Count > 5)
           {
               string name;
               int panelIndex = -1,index = 0;
               name = m_CurrentIndicator.Name + " Line 1";
               do
               {
                   index++;
                   panelIndex = m_currentChart.ui_ocxStockChart.GetPanelBySeriesName(name);
                   name = m_CurrentIndicator.Name +" " + index.ToString() + " Line 1";
               }
               while (panelIndex != -1);

               if (index > 1)
                   seriosAdd = " " + index.ToString();
           }

           for (int i = 6; i < headerLst.Count; i++)
               m_SeriesProperties.Add(new CusIndSeriesProperty(m_CurrentIndicator.Name + seriosAdd +" Line " + (i - 5).ToString(), Color.Black, 1, 0, headerLst[i]));
         
        }
        
        private double GetJDate(string szDate, ctlNewChart aChart)
        {
            double functionReturnValue = 0;
            DateTime dtDate = DateTime.Parse(szDate);
            functionReturnValue = aChart.ui_ocxStockChart.ToJulianDate(dtDate.Year, dtDate.Month, dtDate.Day, dtDate.Hour, dtDate.Minute, dtDate.Second);
            return functionReturnValue;
        }

        private void Add()
        {
            if (!ValidateScript(m_CurrentIndicator.Script)) return;
            m_RunScript = GetFinishScript(m_CurrentIndicator.Script);
            m_RunScript = ReplaceScript(m_RunScript, m_Parameters);
            m_RunScript= m_RunScript.Replace("\r\n",string.Empty);
            m_currentChart.ui_ocxStockChart.IgnoreSeriesLengthErrors = true;
            m_Script.ClearRecords();
            string Result = string.Empty, indicatorName = m_CurrentIndicator.Name;
            double Jdate = 0, Open = double.NaN, Close = double.NaN, High = double.NaN, Low = double.NaN, Volume = double.NaN, value = 0;
            for (int i = 1; i <= m_currentChart.ui_ocxStockChart.RecordCount; i++)
            {
                Jdate = m_currentChart.ui_ocxStockChart.GetJDate(m_currentChart.m_Symbol + ".open", i);
                Open = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".open", Jdate);
                Close = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".close", Jdate);
                High = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".high", Jdate);
                Low = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".low", Jdate);
                Volume = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".volume", Jdate);

                m_Script.AppendRecord(Jdate, Open, High, Low, Close, (int)Volume);
            }
            Result = m_Script.GetScriptOutput(m_RunScript);
            if (string.IsNullOrEmpty(Result)) return;

            string[] rows = null, cols = null;
            int row = 0;
            rows = Result.Split('\n');

            SeriesType serType = m_IndType == IndicatorType.Line ? SeriesType.stLineChart : SeriesType.stVolumeChart;
            int panel =-1;

            foreach (CusIndSeriesProperty ind in m_SeriesProperties)
                m_currentChart.ui_ocxStockChart.RemoveSeries(ind.Name);

            m_currentChart.ui_ocxStockChart.Update();
            if (m_IndSite == IndicatorSite.OnChart)
                panel = 0;
            else
                 panel = m_currentChart.ui_ocxStockChart.AddChartPanel();

            List<string> headerLst = ParseHeader(rows[0]);

            m_currentChart.ui_ocxStockChart.AddIndicatorSeries(Indicator.indCustomIndicator, indicatorName, panel, true);

            List<double> chartData = new List<double>();

            for (row = 1; row < rows.Length; row++)
            {
                rows[row] = rows[row].Replace("\r", "");
                if (rows[row] == string.Empty) continue;
                cols = rows[row].Split(',');
                Jdate = GetJDate(cols[0], m_currentChart);

                value = double.Parse(cols[6], System.Globalization.CultureInfo.InvariantCulture);
                if (value == 0) value = (double)DataType.dtNullValue;
                chartData.Add(value);
            }
            m_currentChart.ui_ocxStockChart.SetCustomIndicatorData(indicatorName, chartData.ToArray(), false);
            m_currentChart.ui_ocxStockChart.Update();

            m_currentChart.ui_ocxStockChart.Update();
            m_Update = true;
        }

        private void UpdateChart(bool addBar)
        {
            if (!m_Update) return;

            string Result = string.Empty, indicatorName = m_CurrentIndicator.Name;
            double Jdate = 0, Open = double.NaN, Close = double.NaN, High = double.NaN, Low = double.NaN, Volume = double.NaN, value = 0;

            Jdate = m_currentChart.ui_ocxStockChart.GetJDate(m_currentChart.m_Symbol + ".open", m_currentChart.ui_ocxStockChart.RecordCount);
            Open = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".open", Jdate);
            Close = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".close", Jdate);
            High = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".high", Jdate);
            Low = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".low", Jdate);
            Volume = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".volume", Jdate);

            if (addBar)
            {
                m_Script.AppendRecord(Jdate, Open, High, Low, Close, (int)Volume);
                foreach (CusIndSeriesProperty ind in m_SeriesProperties)
                {
                    m_currentChart.ui_ocxStockChart.AppendValue(ind.Name, Jdate, (double)STOCKCHARTXLib.DataType.dtNullValue);
                }

                Jdate = m_currentChart.ui_ocxStockChart.GetJDate(m_currentChart.m_Symbol + ".open", m_currentChart.ui_ocxStockChart.RecordCount - 1);
                Open = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".open", Jdate);
                Close = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".close", Jdate);
                High = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".high", Jdate);
                Low = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".low", Jdate);
                Volume = m_currentChart.ui_ocxStockChart.GetValueByJDate(m_currentChart.m_Symbol + ".volume", Jdate);
                m_Script.EditRecord(Jdate, Open, High, Low, Close, (int)Volume);
            }
            else
            {
                m_Script.EditRecord(Jdate, Open, High, Low, Close, (int)Volume);
            }

            Result = m_Script.GetScriptOutput(m_RunScript);
            if (string.IsNullOrEmpty(Result)) return;

            string[] rows = null, cols = null;
            int row = 0;
            rows = Result.Split('\n');

            foreach (CusIndSeriesProperty ind in m_SeriesProperties)
            {
                for (row = 1; row < rows.Length; row++)
                {
                    rows[row] = rows[row].Replace("\r", "");
                    if (rows[row] == string.Empty) continue;
                    cols = rows[row].Split(',');
                    Jdate = GetJDate(cols[0], m_currentChart);

                    value = double.Parse(cols[ind.OutIndex], System.Globalization.CultureInfo.InvariantCulture);
                    if (value == 0) value = (double)STOCKCHARTXLib.DataType.dtNullValue;
                    m_currentChart.ui_ocxStockChart.EditValue(ind.Name, Jdate, value);
                }
            }
        }

        private List<string> ParseHeader(string headerOut)
        {
            headerOut = headerOut.Replace("\r", "");
            List<string> header = new List<string>();
            string tmpHeader = string.Empty;
            bool isFormula = false;
            for (int i = 0; i < headerOut.Length; i++)
            {
                switch (headerOut[i])
                {
                    case ',':
                        if (isFormula)
                            tmpHeader += headerOut[i];
                        else
                        {
                            header.Add(tmpHeader.ToUpper().Replace(" ",""));
                            tmpHeader = string.Empty;
                        }
                        break;
                    case '\"':
                        isFormula = !isFormula;
                        break;
                    default:
                        tmpHeader += headerOut[i];
                        break;
                }
            }
            header.Add(tmpHeader.ToUpper().Replace(" ", ""));
            return header;
        }

        private static string GetFinishScript(string script)
        {
            string outScript = script;
            outScript = outScript.Replace("\r\n", "\n");
            outScript = outScript.Replace("\n", "\r\n");
            return outScript;
        }
        
        //$a = input(text,1,9,3)
        private static List<IndicatorParameters> GetParameter(string scriptLine, out string error)
        {
            error = string.Empty;
            string originalScript = scriptLine;
            scriptLine = scriptLine.Trim().ToUpper();
            List<IndicatorParameters> outParam = new List<IndicatorParameters>();
            List<string> param;
            List<string> SpaceSymbol = new List<string>();
            SpaceSymbol.Add(" "); SpaceSymbol.Add("\n"); SpaceSymbol.Add("\r");
            string smb, tmpVal;
            int indexBegin = scriptLine.IndexOf(m_ParametersBegin), outtemp = 0;

            while (indexBegin != -1)
            {
                bool next = false;
                param = new List<string>();
                tmpVal = string.Empty;
                for (int i = indexBegin + m_ParametersBegin.Length; i < scriptLine.Length; i++)
                {
                    smb = scriptLine[i].ToString();
                    switch (param.Count)
                    {
                        case 0:
                            if (tmpVal == string.Empty)
                            {
                                if (SpaceSymbol.Contains(smb) || int.TryParse(smb, out outtemp))
                                {
                                    error = "Incorrect syntaxes in " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                                    break;
                                }
                                else
                                    tmpVal += m_ParametersBegin + smb;

                            }
                            else if (SpaceSymbol.Contains(smb) || smb == "=")
                            {
                                param.Add(tmpVal);
                                tmpVal = string.Empty;
                                for (int j = 0; i < outParam.Count; i++)
                                {
                                    if (outParam[j].Name == param[0])
                                    {
                                        error = "Dublicate variable " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                                        break;
                                    }
                                }
                                if (error != string.Empty)
                                    break;
                                if (smb == "=")
                                    param.Add(smb);
                            }
                            else
                                tmpVal += smb;
                            break;

                        case 1:
                            if (SpaceSymbol.Contains(smb)) continue;
                            if (smb != "=")
                                next = true;
                            else
                                param.Add("=");

                            break;
                        case 2:
                            if (tmpVal == string.Empty && SpaceSymbol.Contains(smb)) continue;
                            if (SpaceSymbol.Contains(smb) || smb == "(")
                            {
                                if (tmpVal == m_ParametersFunctino)
                                    param.Add(tmpVal);
                                else
                                    next = true;

                                if (smb == "(")
                                    param.Add("(");

                                tmpVal = string.Empty;
                            }
                            else
                                tmpVal += smb;

                            break;
                        case 3:
                            if (SpaceSymbol.Contains(smb)) continue;
                            if (smb != "(")
                                error = "Incorrect syntaxes in " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                            else
                                param.Add("(");

                            break;
                        case 4:
                            if (SpaceSymbol.Contains(smb)) continue;
                            if (smb != "\"")
                                error = "Incorrect syntaxes in " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                            else
                                param.Add("\"");

                            break;
                        case 5:
                            if (smb == "\"")
                            {
                                param.Add(tmpVal);
                                tmpVal = string.Empty;
                            }
                            else
                                tmpVal += originalScript[i]; //smb;

                            break;

                        case 6:
                            if (SpaceSymbol.Contains(smb)) continue;
                            if (smb != ",")
                                error = "Incorrect syntaxes in " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                            else
                                param.Add(",");

                            break;
                        case 7:
                            if (SpaceSymbol.Contains(smb)) continue;
                            if (smb == ",")
                            {
                                if (!int.TryParse(tmpVal, out outtemp))
                                    error = "Invalid parameter " + tmpVal + " in " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                                else
                                {
                                    param.Add(tmpVal);
                                    tmpVal = string.Empty;
                                }
                            }
                            else
                                tmpVal += smb;

                            break;
                        case 8:
                            if (SpaceSymbol.Contains(smb)) continue;
                            if (smb == ",")
                            {
                                if (!int.TryParse(tmpVal, out outtemp))
                                    error = "Invalid parameter " + tmpVal + " in " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                                else
                                {
                                    int min;
                                    int.TryParse(param[6], out min);
                                    if (min >= outtemp)
                                    {
                                        error = "Parameter " + tmpVal + " mast be bigest for " + min.ToString() +
                                            " in " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                                        break;
                                    }

                                    param.Add(tmpVal);
                                    tmpVal = string.Empty;
                                }
                            }
                            else
                                tmpVal += smb;

                            break;

                        case 9:
                            if (SpaceSymbol.Contains(smb)) continue;
                            if (smb == ")")
                            {
                                if (!int.TryParse(tmpVal, out outtemp))
                                    error = "Invalid parameter " + tmpVal + " in " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                                else
                                {
                                    int min, max;
                                    int.TryParse(param[7], out min);
                                    int.TryParse(param[8], out max);
                                    if (outtemp < min || outtemp > max)
                                    {
                                        error = "Parameter " + tmpVal + " mast be betveen " + min.ToString() + " and " + max.ToString() +
                                            " in " + scriptLine.Substring(indexBegin, i - indexBegin + 1);
                                        break;
                                    }

                                    param.Add(tmpVal);
                                    tmpVal = string.Empty;
                                }
                            }
                            else
                                tmpVal += smb;

                            break;
                    }
                    if (error != string.Empty)
                        break;

                    if (param.Count == 10)
                    {
                        IndicatorParameters indPar = new IndicatorParameters();
                        indPar.Name = param[0];
                        indPar.Text = param[5];
                        int.TryParse(param[7], out indPar.MinValue);
                        int.TryParse(param[8], out indPar.MaxValue);
                        int.TryParse(param[9], out indPar.DefValue);
                        indPar.Script = scriptLine.Substring(indexBegin, i - indexBegin + 1);
                        outParam.Add(indPar);
                        indexBegin = scriptLine.IndexOf(m_ParametersBegin, indexBegin + 5);
                        break;
                    }
                }
                if (error != string.Empty || next)
                    break;
                if (param.Count == 0)
                {
                    indexBegin = scriptLine.IndexOf(m_ParametersBegin, indexBegin + 5);
                }
                else if (param.Count != 10)
                {
                    if (param.Count == 9)
                        error = "Not Exist \"(\" in " + scriptLine.Substring(indexBegin, scriptLine.Length - indexBegin);
                    else
                        error = "Incorrect syntaxes in " + scriptLine.Substring(indexBegin, scriptLine.Length - indexBegin);
                    break;
                }
            }

            return outParam;
        }

        private static string ReplaceScript(string script, List<IndicatorParameters> parameters)
        {
            script = script.ToUpper();
            List<string> invalid = new List<string>(); invalid.Add(" "); invalid.Add("\r"); invalid.Add("\n");
            invalid.Add("\""); invalid.Add("("); invalid.Add(")");
            int index = -1;

            foreach (IndicatorParameters par in parameters)
            {
               script = script.Replace(par.Script, string.Empty);
               index = script.IndexOf(par.Name);
               while (index != -1)
               {
                   if (!(script.Length > index + par.Name.Length && char.IsLetterOrDigit(script[index + par.Name.Length])))
                   {
                       script = script.Substring(0, index) + par.Value.ToString() + script.Substring(index + par.Name.Length, script.Length - index - par.Name.Length);
                   }
                   index = script.IndexOf(par.Name, index +1);
               }
            }
            return script;
        }
        

        #endregion

       
    }

    [Serializable]
    public class CustomIndicatorWorkerCollection:List<CustomIndicatorWorker>
    {
        public static CustomIndicatorWorkerCollection Load(string fileName)
        {
            BinaryFormatter m_Serializer = new BinaryFormatter();
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] b = new byte[4];
                    if (fs.Read(b, 0, 4) == 4)
                    {
                        fs.Seek(BitConverter.ToInt32(b, 0), SeekOrigin.Current);
                        return (CustomIndicatorWorkerCollection)m_Serializer.Deserialize(fs);
                    }
                }
            }
            return new CustomIndicatorWorkerCollection();
        }

        public void Save(string fileName)
        {
            BinaryFormatter m_Serializer = new BinaryFormatter();
            FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.None);
            m_Serializer.Serialize(fs, this);
            fs.Close();
        }
    }
}
