using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CommonLibrary.Cls;
using PALSA.Cls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PALSA.uctl
{
    public partial class ctlTradeHistory : UserControl
    {
        private object _objProfiles;
        public ctlTradeHistory(object objProfiles, string currentProfile, Keys SkeyFilter)
        {
            InitializeComponent();
            _objProfiles = objProfiles;
            uctlTradeWindow1.ShortcutKeyFilter = SkeyFilter;
            uctlTradeWindow1.Profile = objProfiles;
            uctlTradeWindow1.ui_uctlGridTradeWindow.ui_ndgvGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uctlTradeWindow1.ui_uctlGridTradeWindow.ui_ndgvGrid.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle datastyle = new DataGridViewCellStyle { BackColor=SystemColors.Control, ForeColor=SystemColors.WindowText, SelectionBackColor=SystemColors.Highlight, SelectionForeColor=SystemColors.HighlightText, Alignment=DataGridViewContentAlignment.MiddleLeft};
          
            uctlTradeWindow1.ui_uctlGridTradeWindow.ui_ndgvGrid.ColumnHeadersDefaultCellStyle = datastyle;
            uctlTradeWindow1.CurrentProfileName = currentProfile;
        }

        void ctlTradeHistory_Load(object sender, System.EventArgs e)
        {
            clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport += INSTANCE_DoHandleExecutionReport;
            clsTWSOrderManagerJSON.INSTANCE.DoHandleTradeHistoryResponse += INSTANCE_DoHandleTradeHistoryResponse;
            //Title = uctlTradeWindow1.Title;
            uctlTradeWindow1.ui_uctlGridTradeWindow.ui_ndgvGrid.DataBindingComplete += ui_ndgvGrid_DataBindingComplete;
            if (PALSA.Cls.ClsGlobal.MarketMakerAccountId > 0)
            {
                uctlTradeWindow1.ui_uctlGridTradeWindow.Columns["CounterAvgPx"].Visible = true;
                uctlTradeWindow1.ui_uctlGridTradeWindow.Columns["CounterClOrdId"].Visible = true;
                uctlTradeWindow1.ui_uctlGridTradeWindow.Columns["GrossPL"].Visible = true;
            }
            uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory;
            if (uctlTradeWindow1.CurrentProfileName != string.Empty)
            {
                OnProfileApplyClick(uctlTradeWindow1.CurrentProfileName);
            }
            else if (_objProfiles != null && ((Dictionary<string, ClsProfile>)_objProfiles).Keys.Count > 0)
            {
                if (
                    ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().Contains(
                        Properties.Settings.Default.TradeProfile + "_" + ProfileTypes.Trade.ToString()))
                {
                    int index =
                        ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().IndexOf(
                            Properties.Settings.Default.TradeProfile + "_" + ProfileTypes.Trade.ToString());
                    ApplyDefaultProfile(((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList()[index]);
                }
            }
        }
        private void INSTANCE_DoHandleTradeHistoryResponse(List<ExecutionReport> lstExecutionReport)
        {
            Action A =
                () =>
                {
                    uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =
                        clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory;
                };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        private void INSTANCE_DoHandleExecutionReport(ExecutionReport item)
        {
            Action A = () =>
            {
                uctlTradeWindow1.ui_uctlGridTradeWindow.Refresh();
            };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        private void ApplyDefaultProfile(string profileName)
        {
            ClsProfile profile = ((Dictionary<string, ClsProfile>)_objProfiles)[profileName];
            uctlTradeWindow1.CurrentProfileName =
                profileName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];

            foreach (DataGridViewColumn col in uctlTradeWindow1.ui_uctlGridTradeWindow.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        private void OnProfileApplyClick(string profileName)
        {
            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)_objProfiles)[profileName + "_" + ProfileTypes.Trade.ToString()];
            foreach (DataGridViewColumn col in uctlTradeWindow1.ui_uctlGridTradeWindow.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        private void uctlTradeWindow1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
           FrmMain.INSTANCE.Profiles = objProfiles;
            SaveProfile(profileName);
        }

        private void SaveProfile(string profileName)
        {
            uctlTradeWindow1.CurrentProfileName = profileName;
            //_formkey = CommandIDS.TRADE.ToString() + "/" + Convert.ToString(count) + "/" + profileName;

            string dirPath = Path.GetDirectoryName(ClsPalsaUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsPalsaUtility.GetProfileFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, _objProfiles);
            streamWrite.Close();
        }

        private void uctlTradeWindow1_OnProfileRemoveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            FrmMain.INSTANCE.Profiles = objProfiles;
            SaveProfile(profileName);
        }

        private void uctlTradeWindow1_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            FrmMain.INSTANCE.Profiles = objProfiles;
            Properties.Settings.Default.TradeProfile = profileName;
            Properties.Settings.Default.Save();
        }

        private void uctlTradeWindow1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {
            if (uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Count > 0)
            {
                uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["Filter"].Enabled = true;
                uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["SaveAs"].Enabled = true;
            }
            else
            {
                uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["Filter"].Enabled = false;
                uctlTradeWindow1.ui_uctlGridTradeWindow.ContextMenuStrip.Items["SaveAs"].Enabled = false;
            }
        }

        private void ui_ndgvGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Action A = () =>
            {
                int sellQty = 0;
                int buyQty = 0;
                int totOrder = 0;
                double sellVal = 0;
                double buyVal = 0;
                double sellAvg = 0;
                double buyAvg = 0;
                //foreach (DataRow dr in clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows)
                //{
                //    if (dr["BS"].ToString().ToUpper() == "SELL")
                //    {
                //        sellQty += Convert.ToInt32(dr["Quantity"].ToString());
                //        sellVal += Convert.ToDouble(dr["FillPrice"].ToString());
                //        sellAvg += Convert.ToDouble(dr["AvgPrice"].ToString());
                //    }
                //    else
                //    {
                //        buyQty += Convert.ToInt32(dr["Quantity"].ToString());
                //        buyVal += Convert.ToDouble(dr["FillPrice"].ToString());
                //        buyAvg += Convert.ToDouble(dr["AvgPrice"].ToString());
                //    }
                //}
                if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory))
                {
                    try
                    {
                        int count = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count;
                        for (int i = 0; i < count; i++)// Vinod
                        {
                            int j = i;
                            DataRow dr = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count>j? clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows[j]:null;
                            if (dr != null)
                            {
                                if (dr["BS"].ToString().ToUpper() == "SELL")
                                {
                                    sellQty += Convert.ToInt32(dr["Quantity"].ToString());
                                    sellVal += Convert.ToDouble(dr["FillPrice"].ToString());
                                    sellAvg += Convert.ToDouble(dr["AvgPrice"].ToString());
                                }
                                else
                                {
                                    buyQty += Convert.ToInt32(dr["Quantity"].ToString());
                                    buyVal += Convert.ToDouble(dr["FillPrice"].ToString());
                                    buyAvg += Convert.ToDouble(dr["AvgPrice"].ToString());
                                }
                            }
                        }
                        totOrder = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count;
                    }
                    catch 
                    { 
                    }
                    finally
                    {
                        System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory);
                    }
                }
               
                uctlTradeWindow1.SellQty = Convert.ToString(sellQty);
                uctlTradeWindow1.SellVal = Convert.ToString(sellVal);
                uctlTradeWindow1.SellAtp = Convert.ToString(sellAvg);
                uctlTradeWindow1.BuyQty = Convert.ToString(buyQty);
                uctlTradeWindow1.BuyVal = Convert.ToString(buyVal);
                uctlTradeWindow1.BuyAtp = Convert.ToString(buyAvg);
                uctlTradeWindow1.NoOfTotalOrder = Convert.ToString(totOrder);
            };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

    }
}
