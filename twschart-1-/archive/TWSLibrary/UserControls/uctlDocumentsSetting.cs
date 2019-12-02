using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class uctlDocumentsSetting : UserControl
    {
        public uctlDocumentsSetting()
        {
            InitializeComponent();
        }

        private void ui_nbtnRestoreDefault_Click(object sender, EventArgs e)
        {
            RestorDefault();
        }

        public void RestorDefault()
        {
            DDItems.Clear();
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is NCheckBox)
                {
                    ((NCheckBox)ctrl).CheckedChanged -= new EventHandler(uctlDocumentsSetting_CheckedChanged);
                    ((NCheckBox)ctrl).CheckedChanged += new EventHandler(uctlDocumentsSetting_CheckedChanged);
                }
            }
            ui_nlistZone1.Items.Clear();
            ui_nlistZone2.Items.Clear();
            ui_nChkMW.Checked =     false;
            ui_nChkMQ.Checked =     false;
            ui_nChkLevel2.Checked = true;
            ui_nChkChart.Checked =  true;
            ui_nChkRadar.Checked =  false;
            ui_nChkScanner.Checked = false;
            ui_nChkMatrix.Checked =  true;
            ui_nChkOH.Checked =     false;
            ui_nChkTH.Checked =     false;
            ui_nChkNP.Checked =     false;
            ui_nChkMail.Checked =   false;
            ui_nChkAlerts.Checked = false;
            ui_nChkAcounts.Checked = false;
            List<string> zoneItems = new List<string>();
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is NCheckBox && !((NCheckBox)ctrl).Checked)
                {
                    zoneItems.Add(ctrl.Tag.ToString());
                }
                if (ctrl is NCheckBox)
                {
                    ((NCheckBox)ctrl).CheckedChanged -= new EventHandler(uctlDocumentsSetting_CheckedChanged);
                    ((NCheckBox)ctrl).CheckedChanged += new EventHandler(uctlDocumentsSetting_CheckedChanged);
                }
            }
            ui_nlistZone1.Items.Add(zoneItems[0]);
            ui_nlistZone1.Items.Add(zoneItems[1]);
            for (int i = 2; i < zoneItems.Count; i++)
            {
                ui_nlistZone2.Items.Add(zoneItems[i]);
            }
        }

        void uctlDocumentsSetting_CheckedChanged(object sender, EventArgs e)
        {
            CheckChanged(sender, e);
        }

        private void ui_nbtnShiftZ1Z2_Click(object sender, EventArgs e)
        {
            if (ui_nlistZone1.SelectedIndex > 0)
            {
                string x = ui_nlistZone1.SelectedItem.ToString();
                int i = ui_nlistZone1.SelectedIndex;
                ui_nlistZone1.Items.RemoveAt(i);
                int j = ui_nlistZone2.Items.Add(x);
            }

        }

        private void ui_nbtnShiftZ2Z1_Click(object sender, EventArgs e)
        {
            if (ui_nlistZone2.SelectedIndex > 0)
            {
                string x = ui_nlistZone2.SelectedItem.ToString();
                int i = ui_nlistZone2.SelectedIndex;
                ui_nlistZone2.Items.RemoveAt(i);
                int j = ui_nlistZone1.Items.Add(x);
            }
        }

        private void ui_nbtnZone1Up_Click(object sender, EventArgs e)
        {
            if (ui_nlistZone1.SelectedIndex > 0)
            {
                var item = (NListBoxItem)ui_nlistZone1.SelectedItem;
                int index = ui_nlistZone1.SelectedIndex;
                ui_nlistZone1.Items.RemoveAt(index);
                ui_nlistZone1.Items.Insert(index - 1, item);
                ui_nlistZone1.SelectedIndex = index - 1;
            }
        }

        private void ui_nbtnZone1Down_Click(object sender, EventArgs e)
        {
            if (ui_nlistZone1.SelectedIndex != -1 && ui_nlistZone1.SelectedIndex < ui_nlistZone1.Items.Count - 1)
            {
                var item = (NListBoxItem)ui_nlistZone1.SelectedItem;
                int index = ui_nlistZone1.SelectedIndex;
                ui_nlistZone1.Items.RemoveAt(index);
                ui_nlistZone1.Items.Insert(index + 1, item);
                ui_nlistZone1.SelectedIndex = index + 1;
            }
        }

        private void ui_nbtnZone2Up_Click(object sender, EventArgs e)
        {
            if (ui_nlistZone2.SelectedIndex > 0)
            {
                var item = (NListBoxItem)ui_nlistZone2.SelectedItem;
                int index = ui_nlistZone2.SelectedIndex;
                ui_nlistZone2.Items.RemoveAt(index);
                ui_nlistZone2.Items.Insert(index - 1, item);
                ui_nlistZone2.SelectedIndex = index - 1;
            }
        }

        private void ui_nbtnZone2Down_Click(object sender, EventArgs e)
        {
            if (ui_nlistZone2.SelectedIndex != -1 && ui_nlistZone2.SelectedIndex < ui_nlistZone2.Items.Count - 1)
            {
                var item = (NListBoxItem)ui_nlistZone2.SelectedItem;
                int index = ui_nlistZone2.SelectedIndex;
                ui_nlistZone2.Items.RemoveAt(index);
                ui_nlistZone2.Items.Insert(index + 1, item);
                ui_nlistZone2.SelectedIndex = index + 1;
            }
        }
        Dictionary<string, string> DDItems = new Dictionary<string, string>();
        private void CheckChanged(object sender, EventArgs e)
        {
            if (((NCheckBox)sender).Checked)
            {
                foreach (NListBoxItem item in ui_nlistZone1.Items)
                {
                    if (item.Text == ((NCheckBox)sender).Tag.ToString())
                    {
                        int i=ui_nlistZone1.Items.IndexOf(item);
                        ui_nlistZone1.Items.RemoveAt(i);
                        if (DDItems.Keys.Contains(item.Text))
                            DDItems[item.Text] = Convert.ToString(i) + ":1";
                        else
                            DDItems.Add(item.Text, Convert.ToString(i) + ":1");
                        return;
                    }
                }
                foreach (NListBoxItem item in ui_nlistZone2.Items)
                {
                    if (item.Text == ((NCheckBox)sender).Tag.ToString())
                    {
                        int i = ui_nlistZone2.Items.IndexOf(item);
                        ui_nlistZone2.Items.RemoveAt(i);
                        if (DDItems.Keys.Contains(item.Text))
                            DDItems[item.Text] = Convert.ToString(i) + ":2";
                        else
                            DDItems.Add(item.Text, Convert.ToString(i) + ":2");
                        return;
                    }
                }
            }
            else
            {
                if (DDItems.Keys.Contains(((NCheckBox)sender).Tag.ToString()))
                {
                    string[] x = DDItems[((NCheckBox)sender).Tag.ToString()].Split(':');
                    if (x[1] == "1")
                    {
                        if (ui_nlistZone1.Items.Count >= Convert.ToInt32(x[0]))
                        {
                            ui_nlistZone1.Items.Insert(Convert.ToInt32(x[0]), ((NCheckBox)sender).Tag.ToString());
                        }
                        else
                        {
                            int i = ui_nlistZone1.Items.Add(((NCheckBox)sender).Tag.ToString());
                            if (DDItems.Keys.Contains(((NCheckBox)sender).Tag.ToString()))
                                DDItems[((NCheckBox)sender).Tag.ToString()] = Convert.ToString(i) + ":1";
                            else
                                DDItems.Add(((NCheckBox)sender).Tag.ToString(), Convert.ToString(i) + ":1");
                        }
                    }
                    else
                    {


                        if (ui_nlistZone2.Items.Count >= Convert.ToInt32(x[0]))
                        {
                            ui_nlistZone2.Items.Insert(Convert.ToInt32(x[0]), ((NCheckBox)sender).Tag.ToString());
                        }
                        else
                        {
                            int i = ui_nlistZone2.Items.Add(((NCheckBox)sender).Tag.ToString());
                            if (DDItems.Keys.Contains(((NCheckBox)sender).Tag.ToString()))
                                DDItems[((NCheckBox)sender).Tag.ToString()] = Convert.ToString(i) + ":2";
                            else
                                DDItems.Add(((NCheckBox)sender).Tag.ToString(), Convert.ToString(i) + ":2");
                        }
                    }
                }
                else
                {
                   int i= ui_nlistZone1.Items.Add(((NCheckBox)sender).Tag.ToString());
                    if (DDItems.Keys.Contains(((NCheckBox)sender).Tag.ToString()))
                        DDItems[((NCheckBox)sender).Tag.ToString()] = Convert.ToString(i) + ":1";
                    else
                        DDItems.Add(((NCheckBox)sender).Tag.ToString(), Convert.ToString(i) + ":1");
                }
            }

        }

        public void SetValues(ClsDocumentsSettings objDocumentsSetting)
        {
            List<string> allZoneItems = new List<string>();

            //foreach (Control ctrl in tableLayoutPanel1.Controls)
            //{
            //    if (ctrl is NCheckBox && !((NCheckBox)ctrl).Checked)
            //    {
            //        ((NCheckBox)ctrl).CheckedChanged += new EventHandler(uctlDocumentsSetting_CheckedChanged);
            //    }
            //}
            ui_nChkMW.Checked = objDocumentsSetting.MarketWatchInDoc;
            ui_nChkMQ.Checked = objDocumentsSetting.MarketQuoteInDoc;
            ui_nChkLevel2.Checked = objDocumentsSetting.Level2DataInDoc;
            ui_nChkChart.Checked = objDocumentsSetting.ChartInDoc;
            ui_nChkRadar.Checked = objDocumentsSetting.RadarInDoc;
            ui_nChkScanner.Checked = objDocumentsSetting.ScannerInDoc;
            ui_nChkMatrix.Checked = objDocumentsSetting.MatrixInDoc;
            ui_nChkOH.Checked = objDocumentsSetting.OrderHistoryInDoc;
            ui_nChkTH.Checked = objDocumentsSetting.TradeHistoryInDoc;
            ui_nChkNP.Checked = objDocumentsSetting.NetPositionInDoc;
            ui_nChkMail.Checked = objDocumentsSetting.MailInDoc;
            ui_nChkAlerts.Checked = objDocumentsSetting.AlertsInDoc;
            ui_nChkAcounts.Checked = objDocumentsSetting.AcountsInDoc;
            //foreach (string x in allZoneItems)
            //{ 
            
            //}
            List<string> zone1list = new List<string>();
            List<string> zone2list = new List<string>();
            if (!objDocumentsSetting.MarketWatchInDoc)
            {

                if (objDocumentsSetting.MarketWatchZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.MarketWatchIndex+ ":" +ui_nChkMW.Tag.ToString()  );
                }
                else if (objDocumentsSetting.MarketWatchZone ==2)
                {
                    zone2list.Add(objDocumentsSetting.MarketWatchIndex+ ":" +ui_nChkMW.Tag.ToString()  );
                }
            }
            if (!objDocumentsSetting.MarketQuoteInDoc)
            { 
                if (objDocumentsSetting.MarketQuoteZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.MarketQuoteIndex+ ":" +ui_nChkMQ.Tag.ToString()  );
                }
                else if (objDocumentsSetting.MarketQuoteZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.MarketQuoteIndex+ ":" +ui_nChkMQ.Tag.ToString()  );
                }
            }
            if (!objDocumentsSetting.Level2DataInDoc)
            { 
                if (objDocumentsSetting.Level2DataZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.Level2DataIndex+ ":" +ui_nChkLevel2.Tag.ToString()  );
                }
                else if (objDocumentsSetting.Level2DataZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.Level2DataIndex+ ":" +ui_nChkLevel2.Tag.ToString()  );
                }
            }
            if (!objDocumentsSetting.ChartInDoc)
            { 
                if (objDocumentsSetting.ChartZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.ChartIndex+ ":" +ui_nChkChart.Tag.ToString()  );
                }
                else if (objDocumentsSetting.ChartZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.ChartIndex+ ":" +ui_nChkChart.Tag.ToString()  );
                }
            }
            if (!objDocumentsSetting.RadarInDoc)
            { 
                if (objDocumentsSetting.RadarZone == 1)
                {
                    zone1list.Add( objDocumentsSetting.RadarIndex+":"+ui_nChkRadar.Tag.ToString());
                }
                else if (objDocumentsSetting.RadarZone == 2)
                {
                    zone2list.Add( objDocumentsSetting.RadarIndex+":"+ui_nChkRadar.Tag.ToString());
                }
            }
            if (!objDocumentsSetting.ScannerInDoc)
            { 
                if (objDocumentsSetting.ScannerZone == 1)
                {
                    zone1list.Add( objDocumentsSetting.ScannerIndex+ ":" +ui_nChkScanner.Tag.ToString() );
                }
                else if (objDocumentsSetting.ScannerZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.ScannerIndex+ ":" +ui_nChkScanner.Tag.ToString()  );
                }
            }

            if (!objDocumentsSetting.MatrixInDoc)
            { 
                if (objDocumentsSetting.MatrixZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.MatrixIndex+ ":" +ui_nChkMatrix.Tag.ToString()  );
                }
                else if (objDocumentsSetting.MatrixZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.MatrixIndex+ ":" +ui_nChkMatrix.Tag.ToString()  );
                }
            }
            if (!objDocumentsSetting.OrderHistoryInDoc)
            { 
                if (objDocumentsSetting.OrderHistoryZone == 1)
                {
                    zone1list.Add( objDocumentsSetting.OrderHistoryIndex+ ":" +ui_nChkOH.Tag.ToString() );
                }
                else if (objDocumentsSetting.OrderHistoryZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.OrderHistoryIndex+ ":" +ui_nChkOH.Tag.ToString()  );
                }
            }
            if (!objDocumentsSetting.TradeHistoryInDoc)
            { 
                if (objDocumentsSetting.TradeHistoryZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.TradeHistoryIndex+ ":" +ui_nChkTH.Tag.ToString()  );
                }
                else if (objDocumentsSetting.TradeHistoryZone == 2)
                {
                    zone2list.Add( objDocumentsSetting.TradeHistoryIndex+ ":" +ui_nChkTH.Tag.ToString() );
                }
            }
            if (!objDocumentsSetting.NetPositionInDoc)
            { 
                if (objDocumentsSetting.NetPositionZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.NetPositionIndex+ ":" +ui_nChkNP.Tag.ToString()  );
                }
                else if (objDocumentsSetting.NetPositionZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.NetPositionIndex+ ":" +ui_nChkNP.Tag.ToString()  );
                }
            }
            if (!objDocumentsSetting.MailInDoc)
            { 
                if (objDocumentsSetting.MailZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.MailIndex+ ":" + ui_nChkMail.Tag.ToString() );
                }
                else if (objDocumentsSetting.MailZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.MailIndex+":"+ui_nChkMail.Tag.ToString());
                }
            }
            if (!objDocumentsSetting.AlertsInDoc)
            {
                if (objDocumentsSetting.AlertsZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.AlertsIndex + ":" + ui_nChkAlerts.Tag.ToString());
                }
                else if (objDocumentsSetting.AlertsZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.AlertsIndex + ":" + ui_nChkAlerts.Tag.ToString());
                }
            }
            if (!objDocumentsSetting.AcountsInDoc)
            {
                if (objDocumentsSetting.AcountsZone == 1)
                {
                    zone1list.Add(objDocumentsSetting.AcountsIndex + ":" + ui_nChkAcounts.Tag.ToString());
                }
                else if (objDocumentsSetting.AcountsZone == 2)
                {
                    zone2list.Add(objDocumentsSetting.AcountsIndex + ":" + ui_nChkAcounts.Tag.ToString());
                }
            }
            zone1list.Sort();
            zone2list.Sort();
            foreach (string x in zone1list)
            {
                ui_nlistZone1.Items.Add(x.Split(':')[1]);
            }
            foreach (string x in zone2list)
            {
                ui_nlistZone2.Items.Add(x.Split(':')[1]);
            }
            //
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is NCheckBox)
                {
                    ((NCheckBox)ctrl).CheckedChanged -= new EventHandler(uctlDocumentsSetting_CheckedChanged);
                    ((NCheckBox)ctrl).CheckedChanged += new EventHandler(uctlDocumentsSetting_CheckedChanged);
                }
            }

        }

        public ClsDocumentsSettings GetValues()
        {
            var objDocumentsSetting = new ClsDocumentsSettings();
            objDocumentsSetting.MarketWatchInDoc=ui_nChkMW.Checked;
            objDocumentsSetting.MarketQuoteInDoc=ui_nChkMQ.Checked;
            objDocumentsSetting.Level2DataInDoc=ui_nChkLevel2.Checked;
            objDocumentsSetting.ChartInDoc=ui_nChkChart.Checked;
            objDocumentsSetting.RadarInDoc=ui_nChkRadar.Checked;
            objDocumentsSetting.ScannerInDoc=ui_nChkScanner.Checked;
            objDocumentsSetting.MatrixInDoc=ui_nChkMatrix.Checked;
            objDocumentsSetting.OrderHistoryInDoc=ui_nChkOH.Checked ;
            objDocumentsSetting.TradeHistoryInDoc=ui_nChkTH.Checked ;
            objDocumentsSetting.NetPositionInDoc=ui_nChkNP.Checked ;
            objDocumentsSetting.MailInDoc=ui_nChkMail.Checked ;
            objDocumentsSetting.AlertsInDoc = ui_nChkAlerts.Checked;
            objDocumentsSetting.AcountsInDoc = ui_nChkAcounts.Checked;
            if (!objDocumentsSetting.MarketWatchInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkMW.Tag.ToString()))
                {
                    objDocumentsSetting.MarketWatchZone = 1;
                    objDocumentsSetting.MarketWatchIndex = ui_nlistZone1.Items.IndexOf(ui_nChkMW.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.MarketWatchZone = 2;
                    objDocumentsSetting.MarketWatchIndex = ui_nlistZone2.Items.IndexOf(ui_nChkMW.Tag.ToString());
                }
            }
            else
            { 
             objDocumentsSetting.MarketWatchZone = -1;
             objDocumentsSetting.MarketWatchIndex = -1;
            }
              
            if (!objDocumentsSetting.MarketQuoteInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkMQ.Tag.ToString()))
                {
                    objDocumentsSetting.MarketQuoteZone = 1;
                    objDocumentsSetting.MarketQuoteIndex = ui_nlistZone1.Items.IndexOf(ui_nChkMQ.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.MarketQuoteZone = 2;
                    objDocumentsSetting.MarketQuoteIndex = ui_nlistZone2.Items.IndexOf(ui_nChkMQ.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.MarketQuoteZone = -1;
                objDocumentsSetting.MarketQuoteIndex = -1;
            }

            if (!objDocumentsSetting.Level2DataInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkLevel2.Tag.ToString()))
                {
                    objDocumentsSetting.Level2DataZone = 1;
                    objDocumentsSetting.Level2DataIndex = ui_nlistZone1.Items.IndexOf(ui_nChkLevel2.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.Level2DataZone = 2;
                    objDocumentsSetting.Level2DataIndex = ui_nlistZone2.Items.IndexOf(ui_nChkLevel2.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.Level2DataZone = -1;
                objDocumentsSetting.Level2DataIndex = -1;
            }

            if (!objDocumentsSetting.ChartInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkChart.Tag.ToString()))
                {
                    objDocumentsSetting.ChartZone = 1;
                    objDocumentsSetting.ChartIndex = ui_nlistZone1.Items.IndexOf(ui_nChkChart.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.ChartZone = 2;
                    objDocumentsSetting.ChartIndex = ui_nlistZone2.Items.IndexOf(ui_nChkChart.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.ChartZone = -1;
                objDocumentsSetting.ChartIndex =-1;
            }

            if (!objDocumentsSetting.RadarInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkRadar.Tag.ToString()))
                {
                    objDocumentsSetting.RadarZone = 1;
                    objDocumentsSetting.RadarIndex = ui_nlistZone1.Items.IndexOf(ui_nChkRadar.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.RadarZone = 2;
                    objDocumentsSetting.RadarIndex = ui_nlistZone2.Items.IndexOf(ui_nChkRadar.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.RadarZone = -1;
                objDocumentsSetting.RadarIndex = -1;
            }

            if (!objDocumentsSetting.ScannerInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkScanner.Tag.ToString()))
                {
                    objDocumentsSetting.ScannerZone = 1;
                    objDocumentsSetting.ScannerIndex = ui_nlistZone1.Items.IndexOf(ui_nChkScanner.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.ScannerZone = 2;
                    objDocumentsSetting.ScannerIndex = ui_nlistZone2.Items.IndexOf(ui_nChkScanner.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.ScannerZone =-1;
                objDocumentsSetting.ScannerIndex = -1;
            }
            if (!objDocumentsSetting.MatrixInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkMatrix.Tag.ToString()))
                {
                    objDocumentsSetting.MatrixZone = 1;
                    objDocumentsSetting.MatrixIndex = ui_nlistZone1.Items.IndexOf(ui_nChkMatrix.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.MatrixZone = 2;
                    objDocumentsSetting.MatrixIndex = ui_nlistZone2.Items.IndexOf(ui_nChkMatrix.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.MatrixZone = -1;
                objDocumentsSetting.MatrixIndex = -1;
            }
            if (!objDocumentsSetting.OrderHistoryInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkOH.Tag.ToString()))
                {
                    objDocumentsSetting.OrderHistoryZone = 1;
                    objDocumentsSetting.OrderHistoryIndex = ui_nlistZone1.Items.IndexOf(ui_nChkOH.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.OrderHistoryZone = 2;
                    objDocumentsSetting.OrderHistoryIndex = ui_nlistZone2.Items.IndexOf(ui_nChkOH.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.OrderHistoryZone = -1;
                objDocumentsSetting.OrderHistoryIndex = -1;
            }

            if (!objDocumentsSetting.TradeHistoryInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkTH.Tag.ToString()))
                {
                    objDocumentsSetting.TradeHistoryZone = 1;
                    objDocumentsSetting.TradeHistoryIndex = ui_nlistZone1.Items.IndexOf(ui_nChkTH.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.TradeHistoryZone = 2;
                    objDocumentsSetting.TradeHistoryIndex = ui_nlistZone2.Items.IndexOf(ui_nChkTH.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.TradeHistoryZone = -1;
                objDocumentsSetting.TradeHistoryIndex = -1;
            }

            if (!objDocumentsSetting.NetPositionInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkNP.Tag.ToString()))
                {
                    objDocumentsSetting.NetPositionZone = 1;
                    objDocumentsSetting.NetPositionIndex = ui_nlistZone1.Items.IndexOf(ui_nChkNP.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.NetPositionZone = 2;
                    objDocumentsSetting.NetPositionIndex = ui_nlistZone2.Items.IndexOf(ui_nChkNP.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.NetPositionZone = -1;
                objDocumentsSetting.NetPositionIndex = -1;
            }
            if (!objDocumentsSetting.MailInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkMail.Tag.ToString()))
                {
                    objDocumentsSetting.MailZone = 1;
                    objDocumentsSetting.MailIndex = ui_nlistZone1.Items.IndexOf(ui_nChkMail.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.MailZone = 2;
                    objDocumentsSetting.MailIndex = ui_nlistZone2.Items.IndexOf(ui_nChkMail.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.MailZone = -1;
                objDocumentsSetting.MailIndex = -1;
            }
            if (!objDocumentsSetting.AlertsInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkAlerts.Tag.ToString()))
                {
                    objDocumentsSetting.AlertsZone = 1;
                    objDocumentsSetting.AlertsIndex = ui_nlistZone1.Items.IndexOf(ui_nChkAlerts.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.AlertsZone = 2;
                    objDocumentsSetting.AlertsIndex = ui_nlistZone2.Items.IndexOf(ui_nChkAlerts.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.AlertsZone = -1;
                objDocumentsSetting.AlertsIndex = -1;
            }
            if (!objDocumentsSetting.AcountsInDoc)
            {
                if (ui_nlistZone1.Items.Contains(ui_nChkAcounts.Tag.ToString()))
                {
                    objDocumentsSetting.AcountsZone = 1;
                    objDocumentsSetting.AcountsIndex = ui_nlistZone1.Items.IndexOf(ui_nChkAcounts.Tag.ToString());
                }
                else
                {
                    objDocumentsSetting.AcountsZone = 2;
                    objDocumentsSetting.AcountsIndex = ui_nlistZone2.Items.IndexOf(ui_nChkAcounts.Tag.ToString());
                }
            }
            else
            {
                objDocumentsSetting.AcountsZone = -1;
                objDocumentsSetting.AcountsIndex = -1;
            }
            //for (int i = 0; i < ui_nlistZone1.Items.Count; i++)
            //{ 
            //objDocumentsSetting.GetType().GetProperty(
            //}
            return objDocumentsSetting;
        }


    }
}
