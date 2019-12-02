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
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlTimeNew : uctlGeneric, Interfaces.IUserCtrl
    {
        #region MEMBERS
        #region UI_DATA
        public Cls.clsEnums.FRM_MODE _mode = clsEnums.FRM_MODE.NA;
        List<string> TimeSpan = new List<string>();
        #endregion UI_DATA
        #endregion MEMBERS

        public uctlTimeNew()
        {
            InitializeComponent();
            ui_ncmbDay.Items.AddRange(clsTimeManager.INSTANCE.GetDayArray());
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
        public void SetValues(DS4Time ds4Time, DS4Time.dtTimeRow TimeRow)
        {
            ui_ncmbDay.SelectedIndex = ui_ncmbDay.Items.IndexOf(TimeRow.Day);
        }
        #endregion

        private void HandleTimeSpanList(string[] str)
        {
            int start;
            int end;
            string starttime;
            string endtime;

            try
            {
                //Logging.FileHandling.WriteAllLog("uctlTimeNew : Enter HandleTimeSpanList()");
                foreach (string item in str)
                {
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
                            ui_lstTimeSpan.SelectedIndex = i;
                        }
                        if (clsUtility.GetDate(endtime) > clsUtility.GetDate("23:30"))
                            ui_lstTimeSpan.SelectedIndex = 24;
                    }
                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :uctlTimeNew =>" + ex.Message + ex.InnerException.Message + "StackTrace" + ex.StackTrace + "in HandleTimeSpanList()");
            }
        }

        private void ui_nbtnDelete_Click(object sender, EventArgs e)
        {
            TimeSpan.RemoveAt(TimeSpan.IndexOf(ui_ncmbTimeSpan.Text));

            if (TimeSpan.Count >= 0)
            {
                ui_ncmbTimeSpan.Items.Clear();
                ui_ncmbTimeSpan.Items.Insert(0, "Select Time Span");
                ui_ncmbTimeSpan.Items.AddRange(TimeSpan.ToArray());
                ui_ncmbTimeSpan.SelectedIndex = 0;
                ui_lstTimeSpan.ClearSelected();
                HandleTimeSpanList(TimeSpan.ToArray());
                if (TimeSpan.Count == 0)
                {
                    ui_ndtpFrom.Text = "00:00";
                    ui_ndtpTo.Text = "00:00";
                }
            }
        }

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

            }
            else
            {
                ui_ndtpFrom.Text = "00:00";
                ui_ndtpTo.Text = "00:00";
                ui_nbtnDelete.Enabled = false;
                ui_nbtnUpdate.Enabled = false;
                // ui_nbtnAdd.Enabled = true;
            }

        }

        private void ui_nbtnAdd_Click(object sender, EventArgs e)
        {
            if (clsUtility.GetDate(ui_ndtpFrom.Text) >= clsUtility.GetDate(ui_ndtpTo.Text))
            {
                clsDialogBox.ShowErrorBox("Lower Time Span limit should be less than Upper Time Span limit.", "Time Span Error", true);
                return;
            }
            string NewTimeSpan = ui_ndtpFrom.Text + " - " + ui_ndtpTo.Text;
            if (ValidateTimeSpan(NewTimeSpan) == true)
            {
                TimeSpan.Add(NewTimeSpan);
                SetDefaultSettings();
            }
            else
                return;
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ui_nbtnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateOnSubmit() != false)
                EditTime();
        }
        private void EditTime()
        {
            int i = 0;

            TimePS objTime = new TimePS();
            TimePS objTimePS = new TimePS();
            clsTimeSettings objclsTimeSettings = new clsTimeSettings();
            objclsTimeSettings.Day = ui_ncmbDay.SelectedItem.ToString(); ;
            i++;
            string str = string.Empty;
            foreach (string s in TimeSpan)
            {
                if (!s.Contains("23:59"))
                    str += s.TrimStart() + ", ";
                else
                    str += s.TrimStart();
            }

            objclsTimeSettings.TimeSpan = str;
            objclsTimeSettings = clsProxyClassManager.INSTANCE.UpdateTimeSettings(objclsTimeSettings);
            string opMsg=string.Empty;
            opMsg = "Edited Time Settings record of Day : " + objclsTimeSettings.Day+" ,TimeSpan :"+objclsTimeSettings.TimeSpan;
            if (objclsTimeSettings.ServerResponseID != clsGlobal.FailureID)
            {
                {
                    clsBrokerOperationsLog objclsBrokerOpLog = new clsBrokerOperationsLog();
                    objclsBrokerOpLog.OperationName = "Edited time Setting";
                    //objclsBrokerOpLog.ControlName = "Time Settings";
                    objclsBrokerOpLog.Message = opMsg;
                    clsProxyClassManager.INSTANCE.HandleOperationsLog(OperationTypes.INSERT, objclsBrokerOpLog);
                }
                clsTimeManager.INSTANCE.DoHandleTimeTable(objclsTimeSettings);
            }

        }
        private bool ValidateTimeSpan(string Span)
        {
            DateTime StartTSpan;
            DateTime EndTSpan;
            DateTime loweLimit;
            DateTime uperLimit;
            string[] prvTimeSpan;

            string[] TSpan = Span.Split('-');
            StartTSpan = clsUtility.GetDate(TSpan[0].Trim());
            EndTSpan = clsUtility.GetDate(TSpan[1].Trim());

            foreach (string item in TimeSpan)
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
            return true;
        }

        private void ui_ncmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {

            TimeSpan.Clear();
            string ID = ui_ncmbDay.SelectedItem.ToString();
            DS4Time.dtTimeRow Row = Cls.clsTimeManager.INSTANCE._DS4Time.dtTime.FindByDay(ID);
            OnDaySelect(ID, e);
            string[] str = Row.TimeSpan.Split(',');
            foreach (string s in str)
            {
                if (s.Trim() != string.Empty)
                    TimeSpan.Add(s.Trim());
            }
            SetDefaultSettings();
        }

        private void ui_nbtnUpdate_Click(object sender, EventArgs e)
        {
            if (clsUtility.GetDate(ui_ndtpFrom.Text) >= clsUtility.GetDate(ui_ndtpTo.Text))
            {
                clsDialogBox.ShowErrorBox("Upper Time Span limit should be greater than Lower Time Span limit.", "Time Span Error", true);
                return;
            }
            string NewTimeSpan = ui_ndtpFrom.Text + " - " + ui_ndtpTo.Text;
            ValidateOnUpdate(NewTimeSpan);
            int index = TimeSpan.IndexOf(ui_ncmbTimeSpan.SelectedItem.ToString());
            TimeSpan.RemoveAt(index);
            TimeSpan.Insert(index, NewTimeSpan);
            SetDefaultSettings();
        }
        private void SetDefaultSettings()
        {
            ui_lstTimeSpan.ClearSelected();
            ui_ncmbTimeSpan.Items.Clear();
            ui_ncmbTimeSpan.Items.Insert(0, "Select Time Span");
            ui_ncmbTimeSpan.SelectedIndex = 0;
            ui_ndtpFrom.Text = "00:00";
            ui_ndtpTo.Text = "00:00";
            TimeSpan.Sort();
            ui_ncmbTimeSpan.Items.AddRange(TimeSpan.ToArray());
            HandleTimeSpanList(TimeSpan.ToArray());
        }
        private void ValidateOnUpdate(string S)
        {
            string[] Span = S.Split('-');
            DateTime StartTSpan = clsUtility.GetDate(Span[0].Trim());
            DateTime EndTSpan = clsUtility.GetDate(Span[1].Trim());
            DateTime loweLimit;
            DateTime uperLimit;

            string[] prvTimeSpan;
            foreach (string item in TimeSpan)
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
        private bool ValidateOnSubmit()
        {
            DateTime StartTSpan;
            DateTime EndTSpan;
            DateTime loweLimit;
            DateTime uperLimit;

            string[] prvTimeSpan;
            foreach (string s in TimeSpan)
            {
                string[] Span = s.Split('-');
                StartTSpan = clsUtility.GetDate(Span[0].Trim());
                EndTSpan = clsUtility.GetDate(Span[1].Trim());

                foreach (string item in TimeSpan)
                {
                    if (item.Trim() != "Select Time Span" && item.Trim() != string.Empty && s != item)
                    {
                        prvTimeSpan = item.Split('-');
                        loweLimit = clsUtility.GetDate(prvTimeSpan[0].Trim());
                        uperLimit = clsUtility.GetDate(prvTimeSpan[1].Trim());
                        if ((StartTSpan >= loweLimit && StartTSpan <= uperLimit) || (EndTSpan >= loweLimit && EndTSpan <= uperLimit))
                        {
                            clsDialogBox.ShowErrorBox("The Time Span \"" + s + "\" is overlapping with the Time Span \"" + item + "\". Please avoid overlapping.", "Time Span Error", true);
                            ui_ncmbTimeSpan.SelectedIndex = ui_ncmbTimeSpan.Items.IndexOf(s);
                            return false;
                        }
                        else if (loweLimit >= StartTSpan && uperLimit <= EndTSpan)
                        {
                            clsDialogBox.ShowErrorBox("The Time Span \"" + s + "\" is overlapping with the Time Span \"" + item + "\". Please avoid overlapping.", "Time Span Error", true);
                            ui_ncmbTimeSpan.SelectedIndex = ui_ncmbTimeSpan.Items.IndexOf(s);
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private void ui_nbtOK_Click(object sender, EventArgs e)
        {
            if (ValidateOnSubmit() != false)
            {
                EditTime();
            }
            this.ParentForm.Close();
        }
        public event Action<object, EventArgs> OnDaySelect;

    }
}
