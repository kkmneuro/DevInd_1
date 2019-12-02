///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	NAMO	    1.Desgining of the form
//19/03/2012	NAMO	    1.Code for Displaying messages to grid
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

//using Logging;
using PALSA.Cls;
using PALSA.DS;
using System.Drawing;

namespace PALSA.Frm
{
    public partial class frmMessageLog : frmBase
    {
        public static int count;
        private readonly DS4MessageLog _DS4MessageLog = new DS4MessageLog();
        private readonly List<string> _lstVisibleMessageTypes = new List<string>();
        private string _formkey;

        public frmMessageLog(Keys ShortCutKey)
        {
            InitializeComponent();
            uctlMessagLog1.ShortcutKeyFilter = ShortCutKey;
            count += 1;
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into frmMessageLog Constructor");

            _formkey = CommandIDS.MESSAGE_LOG.ToString() + "/" + Convert.ToString(count);

            clsTWSDataManagerJSON.INSTANCE.OnNews -= INSTANCE_OnNews;
            clsTWSDataManagerJSON.INSTANCE.OnNews += INSTANCE_OnNews;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderLog -= INSTANCE_OnOrderLog;
            clsTWSOrderManagerJSON.INSTANCE.OnOrderLog += INSTANCE_OnOrderLog;
            uctlMessagLog1.ui_uctlGridMessageLog.OnDataError += new CommonLibrary.UserControls.UctlGrid.DataGridViewDataErrorEventHandeler(ui_uctlGridMessageLog_OnDataError);
            //clsTWSDataManagerJSON.INSTANCE.OnNewQuoteRequest += INSTANCE_OnNewQuoteRequest;
            //clsTWSDataManagerJSON.INSTANCE.OnSubscribeReuqest += INSTANCE_OnSubscribeReuqest;
            //clsTWSOrderManagerJSON.INSTANCE.OnTradeLog += INSTANCE_OnTradeLog;

            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from frmMessageLog Constructor");
        }

        void ui_uctlGridMessageLog_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public override string Formkey
        {
            get { return _formkey; }
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        private void INSTANCE_OnOrderLog(string strOrderMsg)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into INSTANCE_OnOrderLog Method");

            //if (Properties.Settings.Default.MessageBarMessageType.Contains("Order"))
            //{
            //    AddMessageToGrid(strOrderMsg);
            //}
            uctlMessagLog1.ui_uctlGridMessageLog.DataSource = clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog;
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from INSTANCE_OnOrderLog Method");
        }

        private void INSTANCE_OnNews(List<News> lstNews)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into INSTANCE_OnNews Method");

            //if (Properties.Settings.Default.MessageBarMessageType.Contains("News"))
            //{
            //    foreach (News item in lstNews)
            //    {
            //        AddMessageToGrid(item._NewsTopic + " : " + item._BodyText);
            //    }
            //}

            uctlMessagLog1.ui_uctlGridMessageLog.DataSource = clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog;

            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from INSTANCE_OnNews Method");
        }

        private void INSTANCE_OnSubscribeReuqest(string msg)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Enter into INSTANCE_OnSubscribeReuqest Method");

            //AddMessageToGrid(msg);

            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Exit from INSTANCE_OnSubscribeReuqest Method");
        }
        private void INSTANCE_OnTradeLog(string strTradeMsg)
        {
        //    //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into INSTANCE_OnTradeLog Method");

        //    //if (Properties.Settings.Default.MessageBarMessageType.Contains("Trade"))
        //    //{
        //    //    AddMessageToGrid(strTradeMsg);
        //    //}
        //    uctlMessagLog1.ui_uctlGridMessageLog.DataSource = clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog;
        //    //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from INSTANCE_OnTradeLog Method");
        }
        private void INSTANCE_OnNewQuoteRequest(string msg)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Enter into INSTANCE_OnNewQuoteRequest Method");

            //AddMessageToGrid(msg);

            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Exit from INSTANCE_OnNewQuoteRequest Method");
        }

        private void frmMessageLog_Load(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into frmMessageLog_Load Method");
            Title = uctlMessagLog1.Title;
            //CheckLogFileExists();
            DoubleBuffered(uctlMessagLog1.ui_uctlGridMessageLog.ui_ndgvGrid, true);
            //clsTWSOrderManagerJSON.INSTANCE.OnMessageArrived -= new Action<string>(INSTANCE_OnMessageArrived);
            //clsTWSOrderManagerJSON.INSTANCE.OnMessageArrived += new Action<string>(INSTANCE_OnMessageArrived);
            //uctlMessagLog1.ui_uctlGridMessageLog.ui_ndgvGrid.DataBindingComplete -= new DataGridViewBindingCompleteEventHandler(ui_ndgvGrid_DataBindingComplete);
            //uctlMessagLog1.ui_uctlGridMessageLog.ui_ndgvGrid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(ui_ndgvGrid_DataBindingComplete);
            //backgroundWorker1.WorkerSupportsCancellation = true;
            //backgroundWorker1.RunWorkerAsync();
            uctlMessagLog1.ui_uctlGridMessageLog.DataSource = clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog;
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from frmMessageLog_Load Method");
        }

        private void frmMessageLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Enter into frmMessageLog_FormClosed Method");
            _formkey = CommandIDS.MESSAGE_LOG.ToString() + "/" + Convert.ToString(count);
            count -= 1;
            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Exit from frmMessageLog_FormClosed Method");
        }

        private void ui_ndgvGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Action A = () =>
            //    {
            //        uctlMessagLog1.ui_uctlGridMessageLog.EnableCellCustomDraw = true;
            //        for (int i = 0; i < uctlMessagLog1.ui_uctlGridMessageLog.Rows.Count; i++)
            //        {
            //            int j = i;
            //            if (uctlMessagLog1.ui_uctlGridMessageLog.Rows[j].Cells["Color"].Value != null)
            //                uctlMessagLog1.ui_uctlGridMessageLog.Rows[j].DefaultCellStyle.BackColor =
            //                    Color.FromName(
            //                        uctlMessagLog1.ui_uctlGridMessageLog.Rows[j].Cells["Color"].Value.
            //                            ToString());
            //        }
            //    };
            //if (InvokeRequired)
            //{
            //    BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}
        }

        private void uctlMessagLog1_OnMessageFilterItemClilck(string filterStr)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Enter into uctlMessagLog1_OnMessageFilterItemClilck Method");

            switch (filterStr)
            {
                case "All Transaction Messages":
                    {
                        FillAllInfo();
                    }
                    break;
                case "Market":
                    {
                        FillFilterInformation("Quote");
                    }
                    break;
                case "Order":
                    {
                        FillFilterInformation("Order");
                    }
                    break;
                case "Trade":
                    {
                        FillFilterInformation("Trade");
                    }
                    break;
                case "System":
                    {
                        FillFilterInformation("System");
                    }
                    break;
                case "Surveillance":
                    {
                        FillFilterInformation("Surveillance");
                    }
                    break;
                case "Alert":
                    {
                        FillFilterInformation("Alert");
                    }
                    break;
                case "Admin":
                    {
                        FillFilterInformation("Admin");
                    }
                    break;
                case "Member":
                    {
                        FillFilterInformation("Member");
                    }
                    break;
                case "News":
                    {
                        FillFilterInformation("News");
                    }
                    break;
                case "Other":
                    {
                        FillFilterInformation("Other");
                    }
                    break;
            }

            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Exit from uctlMessagLog1_OnMessageFilterItemClilck Method");
        }

        private void uctlMessagLog1_OnMessageFilterOkClick(string fromDate, string fromTime, string toDate,
                                                           string toTime)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Enter into uctlMessagLog1_OnMessageFilterOkClick Method");

            DateTime startDate = DateTime.Parse(fromDate + " " + fromTime);
            DateTime endDate = Convert.ToDateTime(toDate + " " + toTime);
            uctlMessagLog1.ui_uctlGridMessageLog.Rows.Clear();
            var rows =(DS4MessageLog.dtMessageLogRow[])_DS4MessageLog.dtMessageLog.Select("Time >'" + startDate + "' and Time <'" + endDate + "'");
            foreach (DS4MessageLog.dtMessageLogRow item in rows)
            {
                string str;
                if (Properties.Settings.Default.TimeFormat.Contains("24"))
                {
                    str = string.Format("{0:HH:mm:ss tt dd/MM/yyyy}", item.Time);
                }
                else
                {
                    str = string.Format("{0:hh:mm:ss tt dd/MM/yyyy}", item.Time);
                }
                uctlMessagLog1.ui_uctlGridMessageLog.Rows.Add(str, item.Message);
            }

            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Exit from uctlMessagLog1_OnMessageFilterOkClick Method");
        }

        private void uctlMessagLog1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Enter into uctlMessagLog1_OnGridMouseDown Method");

            if (uctlMessagLog1.ui_uctlGridMessageLog.Rows.Count > 0)
            {
                uctlMessagLog1.ui_uctlGridMessageLog.ContextMenuStrip.Items["Save As"].Enabled = true;
            }
            else
            {
                uctlMessagLog1.ui_uctlGridMessageLog.ContextMenuStrip.Items["Save As"].Enabled = false;
            }

            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Exit from uctlMessagLog1_OnGridMouseDown Method");
        }

        private void CheckLogFileExists()
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into CheckLogFileExists Method");

            if (Directory.Exists(ClsPalsaUtility.GetLoggingPath()))
            {
                string dir = ClsPalsaUtility.GetLoggingPath();
                string[] str = Directory.GetFiles(dir, "InOut_*", SearchOption.AllDirectories);
                if (str.Count() != 0)
                {
                    var fs = new FileStream(str[str.Length - 1], FileMode.Open, FileAccess.Read,
                                            FileShare.ReadWrite);
                    var sw = new StreamReader(fs);
                    while (!sw.EndOfStream)
                    {
                        int maxMessages = Properties.Settings.Default.MaxMessageInMessageBox;
                        string[] gridValues = sw.ReadLine().Split(new[] {"=>"},
                                                                  StringSplitOptions.RemoveEmptyEntries);
                        uctlMessagLog1.ui_uctlGridMessageLog.Rows.Add(gridValues[0], gridValues[1]);
                        DS4MessageLog.dtMessageLogRow row = _DS4MessageLog.dtMessageLog.NewdtMessageLogRow();
                        string[] time = gridValues[0].Split(' ');
                        row.Time =DateTime.Parse(time[0] + " " + time[1] + " " + time[2].Split('/')[1] + "/" +
                                           time[2].Split('/')[0] + "/" + time[2].Split('/')[2]);
                        row.Message = gridValues[1];
                        _DS4MessageLog.dtMessageLog.AdddtMessageLogRow(row);

                        if (uctlMessagLog1.ui_uctlGridMessageLog.Rows.Count > maxMessages)
                        {
                            uctlMessagLog1.ui_uctlGridMessageLog.Rows.RemoveAt(0);
                            _DS4MessageLog.dtMessageLog.Rows.RemoveAt(0);
                        }
                    }
                }
            }

            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from CheckLogFileExists Method");
        }

        //public void AddMessageToGrid(string msg)
        //{
        //    //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into AddMessageToGrid Method");

        //    if (uctlMessagLog1.ui_uctlGridMessageLog.Rows.Count >
        //        Convert.ToInt32(Properties.Settings.Default.MaxMessageInMessageBox))
        //    {
        //        uctlMessagLog1.ui_uctlGridMessageLog.RemoveAt(0);
        //    }
        //    DS4MessageLog.dtMessageLogRow row = _DS4MessageLog.dtMessageLog.NewdtMessageLogRow();
        //    DateTime dt = DateTime.UtcNow;
        //    string str;
        //    if (Properties.Settings.Default.TimeFormat.Contains("24"))
        //    {
        //        str = string.Format("{0:HH:mm:ss tt dd/MM/yyyy}", dt);
        //    }
        //    else
        //    {
        //        str = string.Format("{0:hh:mm:ss tt dd/MM/yyyy}", dt);
        //    }

        //    row.Time = dt;
        //    row.Message = msg;
        //    if (uctlMessagLog1.ui_uctlGridMessageLog.Columns.Count != 0)
        //    {
        //        uctlMessagLog1.ui_uctlGridMessageLog.Rows.Add(str, msg);
        //    }
        //    _DS4MessageLog.dtMessageLog.AdddtMessageLogRow(row);

        //    //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from AddMessageToGrid Method");
        //}

        private void FillAllInfo()
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into FillAllInfo Method");

            uctlMessagLog1.ui_uctlGridMessageLog.Rows.Clear();
            foreach (DS4MessageLog.dtMessageLogRow item in _DS4MessageLog.dtMessageLog.Rows)
            {
                uctlMessagLog1.ui_uctlGridMessageLog.Rows.Add(item.Time, item.Message);
            }

            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from FillAllInfo Method");
        }

        private void FillFilterInformation(string filterStr)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into FillFilterInformation Method");

            //DS.DS4MessageLog.dtMessageLogRow[] rows = (DS.DS4MessageLog.dtMessageLogRow[])_DS4MessageLog.dtMessageLog.where("Message Like '" + filterStr + "%'");
            uctlMessagLog1.ui_uctlGridMessageLog.Rows.Clear();
            foreach (DS4MessageLog.dtMessageLogRow item in _DS4MessageLog.dtMessageLog.Rows)
            {
                if (item.Message.Contains(filterStr))
                {
                    uctlMessagLog1.ui_uctlGridMessageLog.Rows.Add(item.Time, item.Message);
                }
            }

            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from FillFilterInformation Method");
        }

        public void GetVisibleMessageTypes()
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count +" : Enter into GetVisibleMessageTypes Method");

            //Properties.Settings.Default.MessageBarMessageType.Contains("News");
            foreach (
                string item in
                    Properties.Settings.Default.MessageBarMessageType.Split(new[] {','},
                                                                            StringSplitOptions.RemoveEmptyEntries))
            {
                _lstVisibleMessageTypes.Add(item);
            }

            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from GetVisibleMessageTypes Method");
        }

        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Enter into DoubleBuffered Method");

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

            //FileHandling.WriteDevelopmentLog("MessageLog" + count + " : Exit from DoubleBuffered Method");
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
                 //Action A = () =>
                 //{
                 //        uctlMessagLog1.ui_uctlGridMessageLog.DataSource = clsTWSOrderManagerJSON.INSTANCE.messageLogDS.dtMessageLog;
                 //};
                 //if (InvokeRequired)
                 //{
                 //    BeginInvoke(A);
                 //}
                 //else
                 //{
                 //    A();
                 //}
        }
    }
}