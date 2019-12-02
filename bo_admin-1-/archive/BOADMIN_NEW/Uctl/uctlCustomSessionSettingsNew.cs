using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ProtocolStructs;
using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;
using Nevron.UI.WinForm.Controls;


namespace BOADMIN_NEW.Uctl
{
    /// <summary>
    /// Custom session settings information
    /// </summary>
    public partial class uctlCustomSessionSettingsNew : uctlGeneric, Interfaces.IUserCtrl
    {
        List<string> QuoteTimeSpan = new List<string>();
        List<string> TradeTimeSpan = new List<string>();
        Dictionary<string, bool> ddEOD = new Dictionary<string, bool>();
        Dictionary<string, bool> ddMM = new Dictionary<string, bool>();
        string ID = string.Empty;
        bool DataSubmit = false;
        public DS4Symbol.dtSessionRow[] _row = null;
       

        public uctlCustomSessionSettingsNew()
        {           
            InitializeComponent();
            ui_ncmbDay.Items.AddRange(Enum.GetNames(typeof(DAYS)));
        }

        #region IUserCtrl Members

        public void Init()
        {
            throw new NotImplementedException();
        }

        public void InitControls()
        {

        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_chkEnable_CheckStateChanged(object sender, EventArgs e)
        {
            if (ui_chkEnable.Checked == true)
            {
                ui_nrbtnQuotes.Checked = true;
                ui_lblSettingFor.Visible = true;
                ui_nrbtnQuotes.Visible = true;
                ui_nrbtnTrades.Visible = true;

            }
            else
            {
                ui_nrbtnQuotes.Checked = true;
                ui_lblSettingFor.Visible = false;
                ui_nrbtnQuotes.Visible = false;
                ui_nrbtnTrades.Visible = false;
                ui_nchbxEODSession.Visible = false;
                ui_nchbxMarketMaker.Visible = false;
            }
        }

        public event Action<object, EventArgs> OnDaySelect;
        /// <summary>
        /// select day
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSubmit = false;
            ui_chkEnable.Checked = false;
            QuoteTimeSpan.Clear();
            TradeTimeSpan.Clear();
            ddEOD.Clear();
            ddMM.Clear();
            ID = ui_ncmbDay.SelectedItem.ToString();
            if (this.ParentForm != null)
                this.ParentForm.Text = "Session of " + GetDay(ID);
            ui_chkEnable.Text = " Enable seperate sessions for " + GetDay(ID) + " ";
            OnDaySelect(ID, e);

            if (_row[0].Quotes != string.Empty)
            {
                string[] Quotes = _row[0].Quotes.Split(',');
                foreach (string item in Quotes)
                {
                    if (!(string.IsNullOrEmpty(item.Trim())))
                        QuoteTimeSpan.Add(item.Trim());// AddRange(_row[0].Quotes.Split(','));                    
                }
                QuoteTimeSpan.Sort();
            }
            if (_row[0].Trade != string.Empty)
            {
                string[] Trade = _row[0].Trade.Split(',');
                // TradeTimeSpan.Clear();
                foreach (string item in Trade)
                {
                    if (!(string.IsNullOrEmpty(item.Trim())))
                        TradeTimeSpan.Add(item.Trim());// TradeTimeSpan.AddRange(_row[0].Trade.Split(','));   
                }
                TradeTimeSpan.Sort();
            }
            if (_row[0].SessionEODMM != string.Empty)
            {
                if (_row[0].SessionEODMM.Contains(','))
                {
                    string[] _lstSessionEODMM = _row[0].SessionEODMM.Split(',');
                    foreach (string item in _lstSessionEODMM)
                    {
                        string[] _sessionEODMM = item.Split('_');
                        ddEOD.Add(_sessionEODMM[0], Convert.ToBoolean(_sessionEODMM[1]));
                        ddMM.Add(_sessionEODMM[0], Convert.ToBoolean(_sessionEODMM[2]));
                    }
                }
                else
                {
                    string[] _sessionEODMM = _row[0].SessionEODMM.Split('_');

                    ddEOD.Add(_sessionEODMM[0], Convert.ToBoolean(_sessionEODMM[1]));
                    ddMM.Add(_sessionEODMM[0], Convert.ToBoolean(_sessionEODMM[2]));
                }
            }
            SetDefaultSettings();
            ui_ncmbTimeSpan.Items.AddRange(QuoteTimeSpan.ToArray());
            ui_nlstQuotes.ClearSelected();
            ui_nlstTrade.ClearSelected();
            HandleTimeSpanList(QuoteTimeSpan, ui_nlstQuotes);
            HandleTimeSpanList(TradeTimeSpan, ui_nlstTrade);
        }

        public void SetValues(string Day)
        {
            ui_ncmbDay.SelectedIndex = ui_ncmbDay.Items.IndexOf(Day);
        }
        /// <summary>
        /// time span list handler
        /// </summary>
        /// <param name="str"></param>
        /// <param name="NlistBox"></param>
        private void HandleTimeSpanList(List<string> str, NListBox NlistBox)
        {
            int start;
            int end;
            string starttime;
            string endtime;

            foreach (string item in str)
            {
                try
                {
                    //Logging.FileHandling.WriteAllLog("uctlCustomSessionSettingsNew : Enter HandleTimeSpanList()");
                    if (item == "" || item == " ")
                        break;
                    else
                    {
                        string[] timepart = item.Split('-');
                        starttime = timepart[0];
                        endtime = timepart[1];
                        string[] part1 = starttime.Split(':');
                        if (part1[0] == "" || part1[0] == " ")
                            start = 0;
                        else
                            start = Convert.ToInt32(part1[0]);
                        string[] part2 = endtime.Split(':');
                        if (part2[0] == "" || part2[0] == " ")
                            end = 0;
                        else
                            end = Convert.ToInt32(part2[0]);
                        for (int i = start; i <= end; i++)
                        {
                            NlistBox.SelectedIndex = i;
                        }
                        if (clsUtility.GetDate(endtime) > clsUtility.GetDate("23:30"))
                            NlistBox.SelectedIndex = 24;
                    }
                }
                catch (Exception)
                {
                    //Logging.FileHandling.WriteAllLog("Exception :uctlCustomSessionSettingsNew =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in HandleTimeSpanList()");
                }
            }
        }

        /// <summary>
        /// delete operation handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnDelete_Click(object sender, EventArgs e)
        {
            if (ddEOD.ContainsKey(ui_ncmbTimeSpan.Text.Trim()))
            {
                ddEOD.Remove(ui_ncmbTimeSpan.Text.Trim());
            }
            if (ddMM.ContainsKey(ui_ncmbTimeSpan.Text.Trim()))
            {
                ddMM.Remove(ui_ncmbTimeSpan.Text.Trim());
            }
            if (ui_chkEnable.Checked == true)
            {

                if (ui_nrbtnTrades.Checked == true)
                {
                    TradeTimeSpan.RemoveAt(TradeTimeSpan.IndexOf(ui_ncmbTimeSpan.SelectedItem.ToString()));
                    ui_nlstTrade.ClearSelected();
                    HandleTimeSpanList(TradeTimeSpan, ui_nlstTrade);
                    SetDefaultSettings();
                    ui_ncmbTimeSpan.Items.AddRange(TradeTimeSpan.ToArray());
                }
                else
                {
                    if (TradeTimeSpan.Count > 0)
                    {

                        DateTime StartTSpan;
                        DateTime EndTSpan;
                        DateTime loweLimit;
                        DateTime uperLimit;
                        string[] prvTimeSpan;
                        string[] TSpan = ui_ncmbTimeSpan.SelectedItem.ToString().Split('-');

                        StartTSpan = clsUtility.GetDate(TSpan[0].Trim());
                        EndTSpan = clsUtility.GetDate(TSpan[1].Trim());
                        try
                        {
                            //Logging.FileHandling.WriteAllLog("uctlCustomSessionSettingsNew : Enter ui_nbtnDelete_Click()");
                            List<string> _tempTradeSpanLst = new List<string>();
                            _tempTradeSpanLst.AddRange(TradeTimeSpan);
                            foreach (string item in _tempTradeSpanLst)
                            {
                                if (item.Trim() != "Select Time Span" && item.Trim() != string.Empty)
                                {
                                    prvTimeSpan = item.Split('-');
                                    loweLimit = clsUtility.GetDate(prvTimeSpan[0].Trim());
                                    uperLimit = clsUtility.GetDate(prvTimeSpan[1].Trim());
                                    //if ((StartTSpan >= loweLimit && StartTSpan <= uperLimit) || (EndTSpan >= loweLimit && EndTSpan <= uperLimit))
                                    //{
                                    //    clsDialogBox.ShowErrorBox("The Time Span \"" + Span + "\" is overlapping with the Time Span \"" + item + "\". Please avoid overlapping.", "Time Span Error", true);
                                    //    return false;
                                    //}
                                    if (loweLimit >= StartTSpan && uperLimit <= EndTSpan)
                                    {
                                        TradeTimeSpan.Remove(item);
                                        //clsDialogBox.ShowErrorBox("The Time Span \"" + Span + "\" is overlapping with the Time Span \"" + item + "\". Please avoid overlapping.", "Time Span Error", true);
                                        //return false;
                                    }
                                }
                            }
                            ui_nlstTrade.ClearSelected();
                            HandleTimeSpanList(TradeTimeSpan, ui_nlstTrade);
                        }
                        catch (Exception)
                        {
                            //Logging.FileHandling.WriteAllLog("Exception :uctlCustomSessionSettingsNew =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ui_nbtnDelete_Click()");
                        }
                        
                    }

                    QuoteTimeSpan.RemoveAt(QuoteTimeSpan.IndexOf(ui_ncmbTimeSpan.SelectedItem.ToString()));
                    ui_nlstQuotes.ClearSelected();
                    HandleTimeSpanList(QuoteTimeSpan, ui_nlstQuotes);
                    SetDefaultSettings();
                    ui_ncmbTimeSpan.Items.AddRange(QuoteTimeSpan.ToArray());
                }
            }
            else
            {
                QuoteTimeSpan.RemoveAt(QuoteTimeSpan.IndexOf(ui_ncmbTimeSpan.SelectedItem.ToString()));
                TradeTimeSpan.Clear();
                TradeTimeSpan.AddRange(QuoteTimeSpan);
                ui_nlstTrade.ClearSelected();
                ui_nlstQuotes.ClearSelected();
                HandleTimeSpanList(QuoteTimeSpan, ui_nlstTrade);
                HandleTimeSpanList(TradeTimeSpan, ui_nlstQuotes);
                SetDefaultSettings();
                ui_ncmbTimeSpan.Items.AddRange(QuoteTimeSpan.ToArray());
            }
            if (QuoteTimeSpan.Count == 0)
            {
                ui_nrbtnQuotes.Checked = true;
                ui_ndtpFrom.Text = "00:00";
                ui_ndtpTo.Text = "00:00";
            }
            DataSubmit = true;
        }
        /// <summary>
        /// quotes change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nrbtnQuotes_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_chkEnable.Checked == true)
            {
                SetDefaultSettings();
                if (ui_nrbtnQuotes.Checked == true)
                {
                    ui_ncmbTimeSpan.Items.AddRange(QuoteTimeSpan.ToArray());
                    ui_nchbxEODSession.Visible = false;
                    ui_nchbxMarketMaker.Visible = false;
                    ui_nchbxEODSession.Checked = false;
                    ui_nchbxMarketMaker.Checked = false;
                }
                else
                {
                    ui_ncmbTimeSpan.Items.AddRange(TradeTimeSpan.ToArray());
                }
            }
            else
            {
                SetDefaultSettings();
                ui_ncmbTimeSpan.Items.AddRange(QuoteTimeSpan.ToArray());
            }
        }
        private void SetDefaultSettings()
        {
            ui_ncmbTimeSpan.Items.Clear();
            ui_ncmbTimeSpan.Items.Insert(0, "Select Time Span");
            ui_ncmbTimeSpan.SelectedIndex = 0;
            ui_ndtpFrom.Text = "00:00";
            ui_ndtpTo.Text = "00:00";
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        /// <summary>
        /// time span selected handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbTimeSpan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbTimeSpan.SelectedIndex != 0 && ui_ncmbTimeSpan.Text.Trim() != string.Empty)
            {
                ui_nbtnDelete.Enabled = true;
                ui_nbtnUpdate.Enabled = true;
                // ui_nbtnAdd.Enabled = false;               
                string[] TimeSpan = ui_ncmbTimeSpan.Text.Split('-');
                ui_ndtpFrom.Text = TimeSpan[0].Trim();
                if (TimeSpan[1].Trim() == "24:00")
                {
                    ui_ndtpTo.Text = "23:59";
                }
                else
                    ui_ndtpTo.Text = TimeSpan[1].Trim();

                if (ui_nrbtnTrades.Checked)
                {
                    if (ddEOD.ContainsKey(ui_ncmbTimeSpan.Text.Trim()))
                    {
                        ui_nchbxEODSession.Checked = ddEOD[ui_ncmbTimeSpan.Text.Trim()];
                    }
                    if (ddMM.ContainsKey(ui_ncmbTimeSpan.Text.Trim()))
                    {
                        ui_nchbxMarketMaker.Checked = ddMM[ui_ncmbTimeSpan.Text.Trim()];
                    }                   
                   
                }
                else if (ui_chkEnable.Checked && !ui_nrbtnTrades.Checked)
                {
                    //ui_nchbxEODSession.Checked = false;
                    //ui_nchbxMarketMaker.Checked = false;
                    //ui_nchbxEODSession.Checked = false;
                    //ui_nchbxMarketMaker.Checked = false;
                }
            }
            else
            {
                ui_nchbxEODSession.Checked = false;
                ui_nchbxMarketMaker.Checked = false;
                ui_ndtpFrom.Text = "00:00";
                ui_ndtpTo.Text = "00:00";
                ui_nbtnDelete.Enabled = false;
                ui_nbtnUpdate.Enabled = false;
                // ui_nbtnAdd.Enabled = true;
            }
        }

        /// <summary>
        /// validate update handler
        /// </summary>
        /// <param name="S"></param>
        private void ValidateOnUpdate(string S)
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlCustomSessionSettingsNew : Enter ValidateOnUpdate()");
                List<string> currentTimeSpan;
                if (ui_nrbtnTrades.Checked == true)
                    currentTimeSpan = TradeTimeSpan;
                else
                    currentTimeSpan = QuoteTimeSpan;
                string[] Span = S.Split('-');
                DateTime StartTSpan = clsUtility.GetDate(Span[0].Trim());
                DateTime EndTSpan = clsUtility.GetDate(Span[1].Trim());
                DateTime loweLimit;
                DateTime uperLimit;

                string[] prvTimeSpan;
                foreach (string item in currentTimeSpan)
                {
                    if (item.Trim() != "Select Time Span" && item.Trim() != string.Empty && item.Trim() != ui_ncmbTimeSpan.SelectedItem.ToString())
                    {
                        prvTimeSpan = item.Split('-');
                        loweLimit = clsUtility.GetDate(prvTimeSpan[0].Trim());
                        uperLimit = clsUtility.GetDate(prvTimeSpan[1].Trim());
                        if ((StartTSpan >= loweLimit && StartTSpan <= uperLimit) || (EndTSpan >= loweLimit && EndTSpan <= uperLimit))
                        {
                            clsDialogBox.ShowErrorBox("Updated time span is overlapping with previous time span :\"" + item + "\". Please avoid overlapping.", "Time Span Error", true);
                            return;
                        }

                        else if (loweLimit >= StartTSpan && uperLimit <= EndTSpan)
                        {
                            clsDialogBox.ShowErrorBox("Updated time span is overlapping with previous time span :\"" + item + "\". Please avoid overlapping.", "Time Span Error", true);
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlCustomSessionSettingsNew =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ValidateOnUpdate()");
            }
        }

        /// <summary>
        /// time handler
        /// </summary>
        /// <param name="Span"></param>
        /// <returns></returns>
        private bool ValidateTimeSpan(string Span)
        {
            List<string> currentTimeSpan;
            if (ui_nrbtnTrades.Checked == true)
                currentTimeSpan = TradeTimeSpan;
            else
                currentTimeSpan = QuoteTimeSpan;
            DateTime StartTSpan;
            DateTime EndTSpan;
            DateTime loweLimit;
            DateTime uperLimit;
            string[] prvTimeSpan;
            string[] TSpan = Span.Split('-');

            StartTSpan = clsUtility.GetDate(TSpan[0].Trim());
            EndTSpan = clsUtility.GetDate(TSpan[1].Trim());
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlCustomSessionSettingsNew : Enter ValidateTimeSpan()");

                foreach (string item in currentTimeSpan)
                {
                    if (item.Trim() != "Select Time Span" && item.Trim() != string.Empty)
                    {
                        prvTimeSpan = item.Split('-');
                        loweLimit = clsUtility.GetDate(prvTimeSpan[0].Trim());
                        uperLimit = clsUtility.GetDate(prvTimeSpan[1].Trim());
                        if ((StartTSpan >= loweLimit && StartTSpan <= uperLimit) || (EndTSpan >= loweLimit && EndTSpan <= uperLimit))
                        {
                            clsDialogBox.ShowErrorBox("The Time Span \"" + Span + "\" is overlapping with the Time Span \"" + item + "\". Please avoid overlapping.", "Time Span Error", true);
                            return false;
                        }
                        else if (loweLimit >= StartTSpan && uperLimit <= EndTSpan)
                        {
                            clsDialogBox.ShowErrorBox("The Time Span \"" + Span + "\" is overlapping with the Time Span \"" + item + "\". Please avoid overlapping.", "Time Span Error", true);
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlCustomSessionSettingsNew =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ValidateTimeSpan()");
            }
            return true;
        }

        /// <summary>
        /// validate summit 
        /// </summary>
        /// <param name="LocalTimeSpan"></param>
        /// <returns></returns>
        private bool ValidateOnSubmit(List<string> LocalTimeSpan)
        {
            string TimeSpanName = string.Empty;
            if (LocalTimeSpan == QuoteTimeSpan)
                TimeSpanName = "Quote Time Span";
            else
                TimeSpanName = "Trade Time Span";
            DateTime StartTSpan;
            DateTime EndTSpan;
            DateTime loweLimit;
            DateTime uperLimit;

            string[] prvTimeSpan;
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlCustomSessionSettingsNew : Enter ValidateOnSubmit()");
                foreach (string s in LocalTimeSpan)
                {
                    string[] Span = s.Split('-');
                    StartTSpan = clsUtility.GetDate(Span[0].Trim());
                    EndTSpan = clsUtility.GetDate(Span[1].Trim());

                    foreach (string item in LocalTimeSpan)
                    {
                        if (item.Trim() != string.Empty && s != item)   //item.Trim() != "Select Time Span" && 
                        {
                            prvTimeSpan = item.Split('-');
                            loweLimit = clsUtility.GetDate(prvTimeSpan[0].Trim());
                            uperLimit = clsUtility.GetDate(prvTimeSpan[1].Trim());
                            if ((StartTSpan >= loweLimit && StartTSpan <= uperLimit) || (EndTSpan >= loweLimit && EndTSpan <= uperLimit))
                            {
                                clsDialogBox.ShowErrorBox("The Time Span \"" + s + "\" is overlapping with the Time Span \"" + item + "\" in " + TimeSpanName + ". Please avoid overlapping.", "Time Span Error", true);
                                ui_ncmbTimeSpan.SelectedIndex = ui_ncmbTimeSpan.Items.IndexOf(s);
                                return false;
                            }
                            else if (loweLimit >= StartTSpan && uperLimit <= EndTSpan)
                            {
                                clsDialogBox.ShowErrorBox("The Time Span \"" + s + "\" is overlapping with the Time Span \"" + item + "\" in " + TimeSpanName + ". Please avoid overlapping.", "Time Span Error", true);
                                ui_ncmbTimeSpan.SelectedIndex = ui_ncmbTimeSpan.Items.IndexOf(s);
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlCustomSessionSettingsNew =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in ValidateOnSubmit()");
            }
            return true;
        }

        /// <summary>
        /// edit time handler
        /// </summary>
        private void EditTime()
        {
            try
            {
                //Logging.FileHandling.WriteAllLog("uctlCustomSessionSettingsNew : Enter EditTime()");
                if (_row == null)
                    return;
                string strQuotes = string.Empty;
                string strTrade = string.Empty;
                string strTradeEODMM = string.Empty;

                foreach (string s in QuoteTimeSpan)
                {
                    if (!s.Contains("23:59"))
                        strQuotes += s.TrimStart() + ", ";
                    else
                        strQuotes += s.TrimStart();
                }

                foreach (string s in TradeTimeSpan)
                {
                    if (!s.Contains("23:59"))
                    {
                        strTrade += s.TrimStart() + ", ";
                        if (ddEOD.ContainsKey(s) && ddMM.ContainsKey(s))
                        {
                            strTradeEODMM += s.Trim() + "_" + ddEOD[s].ToString() + "_" + ddMM[s].ToString() + ",";
                        }

                    }
                    else
                    {
                        strTrade += s.TrimStart();
                        if (ddEOD.ContainsKey(s) && ddMM.ContainsKey(s))
                        {
                            strTradeEODMM += s.Trim() + "_" + ddEOD[s].ToString() + "_" + ddMM[s].ToString();
                        }
                    }
                }
                if (ui_chkEnable.Checked == true)
                {
                    _row[0].Quotes = strQuotes;
                    _row[0].Trade = strTrade;
                    if (strTradeEODMM.EndsWith(","))
                   {
                        _row[0].SessionEODMM = strTradeEODMM.Trim().Remove(strTradeEODMM.Length - 1);
                    }
                    else
                        _row[0].SessionEODMM = strTradeEODMM.Trim();

                    _row[0].AcceptChanges();
                    //_frmCommonContainer.Close();                        
                }
                else
                {
                    _row[0].Quotes = strQuotes;
                    _row[0].Trade = strQuotes;


                    ////01-12-14

                   // if (strTradeEODMM.Length>0)
                    //{
                        _row[0].SessionEODMM = strTradeEODMM.Trim().Remove(strTradeEODMM.Length - 1);  
                  //}
                    
                    _row[0].AcceptChanges();
                    //_frmCommonContainer.Close();
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlCustomSessionSettingsNew =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in EditTime()");
            }
        }

        /// <summary>
        /// check trade boundary
        /// </summary>
        /// <param name="NewTradeTimeSpan"></param>
        /// <returns></returns>
        private bool CheckTradeBoundary(string NewTradeTimeSpan)
        {
            bool f = false;
            DateTime StartTSpan;
            DateTime EndTSpan;
            DateTime loweLimit;
            DateTime uperLimit;
            string[] prvTimeSpan;
            string[] TSpan = NewTradeTimeSpan.Split('-');

            StartTSpan = clsUtility.GetDate(TSpan[0].Trim());
            EndTSpan = clsUtility.GetDate(TSpan[1].Trim());

            foreach (string item in QuoteTimeSpan)
            {
                if (item.Trim() != string.Empty)
                {
                    prvTimeSpan = item.Split('-');
                    loweLimit = clsUtility.GetDate(prvTimeSpan[0].Trim());
                    uperLimit = clsUtility.GetDate(prvTimeSpan[1].Trim());
                    if ((StartTSpan >= loweLimit && StartTSpan <= uperLimit) && (EndTSpan >= loweLimit && EndTSpan <= uperLimit))
                    {
                        f = true;
                        break;
                    }

                }
            }
            return f;
        }

        /// <summary>
        /// get day settings
        /// </summary>
        /// <param name="_day"></param>
        /// <returns></returns>
        public string GetDay(string _day)
        {
            string Day = string.Empty;
            switch (_day)
            {
                case "SUN":
                    Day = "Sunday";
                    break;
                case "MON":
                    Day = "Monday";
                    break;
                case "TUE":
                    Day = "Tuesday";
                    break;
                case "WED":
                    Day = "Wednesday";
                    break;
                case "THU":
                    Day = "Thursday";
                    break;
                case "FRI":
                    Day = "Friday";
                    break;
                case "SAT":
                    Day = "Saturday";
                    break;
            }
            return Day;
        }

        /// <summary>
        /// update handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnUpdate_Click(object sender, EventArgs e)
        {
            if (clsUtility.GetDate(ui_ndtpFrom.Text) >= clsUtility.GetDate(ui_ndtpTo.Text))
            {
                clsDialogBox.ShowErrorBox("Upper Time Span limit should be greater than Lower Time Span limit.", "Time Span Error", true);
                return;
            }
            string NewTimeSpan = ui_ndtpFrom.Text.Trim() + "-" + ui_ndtpTo.Text.Trim();
            if (ui_nrbtnTrades.Checked == true && CheckTradeBoundary(NewTimeSpan) == false)
            {
                clsDialogBox.ShowErrorBox("Trade Sassion Time should not beyond Quotes Session Time.", "Session Selection Error", true);
                return;
            }
            ValidateOnUpdate(NewTimeSpan);
            string ts = ui_ncmbTimeSpan.SelectedItem.ToString().Trim();
            if (ddEOD.ContainsKey(ts))
            {
                ddEOD.Remove(ts);
                ddEOD.Add(NewTimeSpan, ui_nchbxEODSession.Checked);
            }
            if (ddMM.ContainsKey(ts))
            {
                ddMM.Remove(ts);
                ddMM.Add(NewTimeSpan, ui_nchbxMarketMaker.Checked);
            }
            if (ui_chkEnable.Checked == true)
            {
                if (ui_nrbtnTrades.Checked == true)
                {
                    int index = TradeTimeSpan.IndexOf(ui_ncmbTimeSpan.SelectedItem.ToString());

                    TradeTimeSpan.RemoveAt(index);
                    TradeTimeSpan.Insert(index, NewTimeSpan);
                    ui_nlstTrade.ClearSelected();
                    HandleTimeSpanList(TradeTimeSpan, ui_nlstTrade);
                    SetDefaultSettings();
                    TradeTimeSpan.Sort();
                    ui_ncmbTimeSpan.Items.AddRange(TradeTimeSpan.ToArray());
                }
                else
                {
                    int index = QuoteTimeSpan.IndexOf(ui_ncmbTimeSpan.SelectedItem.ToString());
                    QuoteTimeSpan.RemoveAt(index);
                    QuoteTimeSpan.Insert(index, NewTimeSpan);
                    ui_nlstQuotes.ClearSelected();
                    HandleTimeSpanList(QuoteTimeSpan, ui_nlstQuotes);
                    SetDefaultSettings();
                    QuoteTimeSpan.Sort();
                    ui_ncmbTimeSpan.Items.AddRange(QuoteTimeSpan.ToArray());
                }
            }
            else
            {
                int index = QuoteTimeSpan.IndexOf(ui_ncmbTimeSpan.SelectedItem.ToString());
                QuoteTimeSpan.RemoveAt(index);
                QuoteTimeSpan.Insert(index, NewTimeSpan);
                QuoteTimeSpan.Sort();
                TradeTimeSpan.Clear();
                TradeTimeSpan.AddRange(QuoteTimeSpan);
                ui_nlstTrade.ClearSelected();
                ui_nlstQuotes.ClearSelected();
                HandleTimeSpanList(QuoteTimeSpan, ui_nlstTrade);
                HandleTimeSpanList(TradeTimeSpan, ui_nlstQuotes);
                SetDefaultSettings();
                ui_ncmbTimeSpan.Items.AddRange(QuoteTimeSpan.ToArray());
            }
            DataSubmit = true;
        }

        /// <summary>
        /// add time settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nbtnAdd_Click(object sender, EventArgs e)
        {
            if (clsUtility.GetDate(ui_ndtpFrom.Text) >= clsUtility.GetDate(ui_ndtpTo.Text))
            {
                clsDialogBox.ShowErrorBox("Lower Time Span limit should be less than Upper Time Span limit.", "Time Span Error", true);
                return;
            }
            string NewTimeSpan = ui_ndtpFrom.Text + "-" + ui_ndtpTo.Text;
            if (ValidateTimeSpan(NewTimeSpan) == true)
            {
                if (ui_chkEnable.Checked == true)
                {
                    if (ui_nrbtnTrades.Checked == true)
                    {
                        if (CheckTradeBoundary(NewTimeSpan) == true)
                        {
                            TradeTimeSpan.Add(NewTimeSpan);
                            ddEOD.Add(NewTimeSpan, ui_nchbxEODSession.Checked);
                            ddMM.Add(NewTimeSpan, ui_nchbxMarketMaker.Checked);
                            TradeTimeSpan.Sort();
                            SetDefaultSettings();
                            ui_ncmbTimeSpan.Items.AddRange(TradeTimeSpan.ToArray());
                            HandleTimeSpanList(TradeTimeSpan, ui_nlstTrade);
                        }
                        else
                        {
                            clsDialogBox.ShowErrorBox("Trade Sassion Time should not beyond Quotes Session Time.", "Session Selection Error", true);
                            return;
                        }
                    }
                    else
                    {
                        QuoteTimeSpan.Add(NewTimeSpan);
                        ddEOD.Add(NewTimeSpan, false);
                        ddMM.Add(NewTimeSpan, false);
                        QuoteTimeSpan.Sort();
                        SetDefaultSettings();
                        ui_ncmbTimeSpan.Items.AddRange(QuoteTimeSpan.ToArray());
                        HandleTimeSpanList(QuoteTimeSpan, ui_nlstQuotes);
                    }
                }

                else
                {
                    QuoteTimeSpan.Add(NewTimeSpan);
                    ddEOD.Add(NewTimeSpan, false);
                    ddMM.Add(NewTimeSpan, false);
                    QuoteTimeSpan.Sort();
                    SetDefaultSettings();
                    ui_ncmbTimeSpan.Items.AddRange(QuoteTimeSpan.ToArray());
                    TradeTimeSpan.Clear();
                    TradeTimeSpan.AddRange(QuoteTimeSpan);
                    HandleTimeSpanList(QuoteTimeSpan, ui_nlstQuotes);
                    HandleTimeSpanList(TradeTimeSpan, ui_nlstTrade);
                }
                DataSubmit = true;
            }
        }

        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            if (DataSubmit == true)
            {
                if (ValidateOnSubmit(QuoteTimeSpan) != false && ValidateOnSubmit(TradeTimeSpan) != false)
                {
                    EditTime();
                    Properties.Settings.Default.Save();
                    this.ParentForm.Close();
                }
            }
            else
                this.ParentForm.Close();
        }

        private void ui_nbtnsubmit_Click(object sender, EventArgs e)
        {
            if (ValidateOnSubmit(QuoteTimeSpan) != false && ValidateOnSubmit(TradeTimeSpan) != false)
            {
                EditTime();
                ////ui_ncmbDay.Items.Clear();
                ui_ncmbDay.Items.AddRange(Enum.GetNames(typeof(DAYS)));
                ui_ncmbDay.SelectedIndex = ui_ncmbDay.Items.IndexOf(ID);
            }
        }

        private void ui_nrbtnTrades_CheckedChanged(object sender, EventArgs e)
        {
            //if (ui_nlstQuotes.SelectedItems.Count == 0 && ui_nrbtnTrades.Checked == true)
            if (QuoteTimeSpan.Count == 0 && ui_nrbtnTrades.Checked == true)
            {
                clsDialogBox.ShowErrorBox("Please define Quotes Session Time first.", "Time Span Error", true);
                // ui_nrbtnTrades.Checked = false;
                ui_nrbtnQuotes.Checked = true;
                return;
            }
            if (QuoteTimeSpan.Count > 0 && ui_nrbtnTrades.Checked == true)
            {
                ui_nchbxEODSession.Visible = true;
                ui_nchbxMarketMaker.Visible = true;
                if (ui_ncmbTimeSpan.SelectedIndex != 0 && ui_ncmbTimeSpan.Text.Trim() != string.Empty)
                {
                    ui_nchbxEODSession.Checked = ddEOD[ui_ncmbTimeSpan.Text.Trim()];
                    ui_nchbxMarketMaker.Checked = ddMM[ui_ncmbTimeSpan.Text.Trim()];
                }
                return;
            }
        }

        private void ui_nchbxEODSession_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_ncmbTimeSpan.SelectedIndex != 0 && ui_ncmbTimeSpan.Text.Trim() != string.Empty)
            {
                ddEOD[ui_ncmbTimeSpan.Text] = ui_nchbxEODSession.Checked;
            }
        }

        private void ui_nchbxMarketMaker_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_ncmbTimeSpan.SelectedIndex != 0 && ui_ncmbTimeSpan.Text.Trim() != string.Empty)
            {
                ddMM[ui_ncmbTimeSpan.Text] = ui_nchbxMarketMaker.Checked;
            }
        }

    }
}
