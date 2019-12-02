///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	VP		    1.Desgining of the form
//06/02/2012	VP		    1.Added code for persistency of form
//05/03/2012    VP          1.Code for columProfile
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CommonLibrary.Cls;
using TWS.Cls;
using System.Data;
using System.Reflection;

namespace TWS.Frm
{
    public partial class frmTradeWindow : frmBase
    {
        //string _title;
        private static int count;
        private string _formkey;
        private object _objProfiles;

        public frmTradeWindow(object objProfiles, string currentProfile, Keys SkeyFilter)
        {
            InitializeComponent();

            _objProfiles = objProfiles;
            uctlTradeWindow1.ShortcutKeyFilter = SkeyFilter;
            uctlTradeWindow1.Profile = objProfiles;
            uctlTradeWindow1.CurrentProfileName = currentProfile;
            count += 1;
            _formkey = CommandIDS.TRADE.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlTradeWindow1.CurrentProfileName;
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


        private void frmTradeWindow_Load(object sender, EventArgs e)
        {
            clsTWSOrderManagerJSON.INSTANCE.DoHandleExecutionReport += INSTANCE_DoHandleExecutionReport;
            clsTWSOrderManagerJSON.INSTANCE.DoHandleTradeHistoryResponse +=INSTANCE_DoHandleTradeHistoryResponse;
            Title = uctlTradeWindow1.Title;
            uctlTradeWindow1.ui_uctlGridTradeWindow.ui_ndgvGrid.DataBindingComplete += ui_ndgvGrid_DataBindingComplete;
            if(TWS.Cls.ClsGlobal.MarketMakerAccountId>0)
            {
                uctlTradeWindow1.ui_uctlGridTradeWindow.Columns["CounterAvgPx"].Visible = true;
                uctlTradeWindow1.ui_uctlGridTradeWindow.Columns["CounterClOrdId"].Visible = true;
                uctlTradeWindow1.ui_uctlGridTradeWindow.Columns["GrossPL"].Visible = true;
            }
            DoubleBuffered(uctlTradeWindow1.ui_uctlGridTradeWindow.ui_ndgvGrid, true);
            //List<ClientDLL_Model.Cls.Order.ExecutionReport> lstExecutionReport = clsTWSOrderManagerJSON.INSTANCE.GetTradeHistory();
//            foreach (ClientDLL_Model.Cls.Order.ExecutionReport item in lstExecutionReport)
//            {
//                string transactTime = string.Empty;
//                string expireTime = string.Empty;
//                if (Properties.Settings.Default.TimeFormat.Contains("24"))
//                {
//                    transactTime = string.Format("{0:dd/MM/yyyy HH:mm:ss}", clsUtility.GetDateTime(item.TransactTime));
//                    //expireTime = string.Format("{0:dd/MM/yyyy HH:mm:ss}", clsUtility.GetDateTime(item.ExpireDate));

//                }
//                else
//                {
//                    transactTime = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", clsUtility.GetDateTime(item.TransactTime));
//                    //expireTime = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", clsUtility.GetDateTime(item.ExpireDate));
//                }

//                string productType = Cls.clsGlobal.DDReverseProductType[Convert.ToSByte(item.ProductType)].ToString();
//                string pType = string.Empty;
//                if (productType == "EQ")
//                {
//                    pType = "Equity";
//                }
//                else if (productType == "FUT")
//                {
//                    pType = "FUTURE";
//                }
//                else if (productType == "FX")
//                {
//                    pType = "FOREX";
//                }
//                else if (productType == "OPT")
//                {
//                    pType = "OPTION";
//                }
////"TradeNo","OrderNo","ProductType","ProductName","Contract","BS","Quantity","Price","AvgPrice"
////,"FillPrice","OrderType","Status","TradeTime""LastUpdatedTime",
//                //"LeaveQty","TradingCurrency","QtyTotal","SpreadSymbol"
////"AccountType","ClientName","Client","PartOmniId","Split","SplitNo","Remarks"
////"EnteredBy","InstRemark","ReferenceNo"
//                uctlTradeWindow1.ui_uctlGridTradeWindow.AllowUserToResizeRows = false;
//                uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Add(item.ExecID, item.OrderID, pType, item.Product, item.Contract, Cls.clsGlobal.DDReverseSide[Convert.ToSByte(item.Side)], item.OrdQty, item.Price, item.AvgPx, item.LastPx, Cls.clsGlobal.DDReverseOrderType[Convert.ToSByte(item.OrderType)],
//                    Cls.clsGlobal.DDReverseOrderStatus[Convert.ToSByte(item.OrderStatus)], transactTime, transactTime, item.LeavesQty, "", "", "", "", "", "", "", "", "", "", "", "", "");
//            }
            uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource =clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory;
            if (uctlTradeWindow1.CurrentProfileName != string.Empty)
            {
                OnProfileApplyClick(uctlTradeWindow1.CurrentProfileName);
            }
            else if (_objProfiles != null && ((Dictionary<string, ClsProfile>) _objProfiles).Keys.Count > 0)
            {
                if (
                    ((Dictionary<string, ClsProfile>) _objProfiles).Keys.ToList().Contains(
                        Properties.Settings.Default.TradeProfile + "_" + ProfileTypes.Trade.ToString()))
                {
                    int index =
                        ((Dictionary<string, ClsProfile>) _objProfiles).Keys.ToList().IndexOf(
                            Properties.Settings.Default.TradeProfile + "_" + ProfileTypes.Trade.ToString());
                    ApplyDefaultProfile(((Dictionary<string, ClsProfile>) _objProfiles).Keys.ToList()[index]);
                }
            }
        }
        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
           //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Enter into DoubleBuffered Method");

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

           //FileHandling.WriteDevelopmentLog("MarketWatch" + count + " : Exit from DoubleBuffered Method");
        }
        private void INSTANCE_DoHandleTradeHistoryResponse(List<Cls.ExecutionReport> lstExecutionReport)
        {
            //foreach (ClientDLL_Model.Cls.Order.ExecutionReport item in lstExecutionReport)
            //{
            //    Logging.//FileHandling.WriteInOutLog("Order Server : Trade History Respose Account" + item.Account + " Contract" +
            //        item.Contract);
            //    Logging.//FileHandling.WriteAllLog("Order Server : Trade History Respose Account" + item.Account + " Contract" +
            //        item.Contract);
            //    string OrderStatus=Cls.clsGlobal.DDReverseOrderStatus[Convert.ToSByte(item.OrderStatus)].ToUpper();
            //    if (OrderStatus != "FILLED" || OrderStatus != "PARTIALLY_FILLED")
            //        continue;
            //Action A = () =>
            //{
            //    string transactTime = string.Empty;
            //    string expireTime = string.Empty;
            //    if (Properties.Settings.Default.TimeFormat.Contains("24"))
            //    {
            //        transactTime = string.Format("{0:dd/MM/yyyy HH:mm:ss}", clsUtility.GetDateTime(item.TransactTime));
            //        //expireTime = string.Format("{0:dd/MM/yyyy HH:mm:ss}", clsUtility.GetDateTime(item.ExpireDate));

            //    }
            //    else
            //    {
            //        transactTime = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", clsUtility.GetDateTime(item.TransactTime));
            //        //expireTime = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", clsUtility.GetDateTime(item.ExpireDate));
            //    }

            //    string productType = Cls.clsGlobal.DDReverseProductType[Convert.ToSByte(item.ProductType)].ToString();
            //    string pType = string.Empty;
            //    if (productType == "EQ")
            //    {
            //        pType = "Equity";
            //    }
            //    else if (productType == "FUT")
            //    {
            //        pType = "FUTURE";
            //    }
            //    else if (productType == "FX")
            //    {
            //        pType = "FOREX";
            //    }
            //    else if (productType == "OPT")
            //    {
            //        pType = "OPTION";
            //    }

            //    uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Add(item.ExecID, item.OrderID, pType, item.Product, item.Contract, Cls.clsGlobal.DDReverseSide[Convert.ToSByte(item.Side)], item.OrdQty, item.Price, item.AvgPx, item.LastPx, Cls.clsGlobal.DDReverseOrderType[Convert.ToSByte(item.OrderType)],
            //        Cls.clsGlobal.DDReverseOrderStatus[Convert.ToSByte(item.OrderStatus)], transactTime, transactTime, item.LeavesQty, "", "", "", "", "", "", "", "", "", "", "", "", "");
            //    //uctlTradeWindow1._DDRows.Add(item.OrderID, uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Count - 1]);
            //};
            //if (this.InvokeRequired)
            //{
            //    this.BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}
            //}
            //============================================

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

        private void INSTANCE_DoHandleExecutionReport(Cls.ExecutionReport item)
        {
//            string OrderStatus = Cls.clsGlobal.DDReverseOrderStatus[Convert.ToSByte(item.OrderStatus)].ToUpper();
//            if (!OrderStatus.Contains("FILLED"))
//                return;
//            Action A = () =>
//            {
//                //if (!Cls.clsGlobal.DDReverseOrderStatus[Convert.ToSByte(item.OrderStatus)].ToUpper().Contains("FILLED") || !Cls.clsGlobal.DDReverseOrderStatus[Convert.ToSByte(item.OrderStatus)].ToUpper().Contains("PARTIALLY_FILLED"))
//                //    return;
//                //else
//                {
//                    //DataGridViewRow row = null;
//                    //if (uctlTradeWindow1._DDRows.TryGetValue(item.OrderID, out row))
//                    //{
//                    //}
//                    string transactTime = string.Empty;
//                    string expireTime = string.Empty;
//                    if (Properties.Settings.Default.TimeFormat.Contains("24"))
//                    {
//                        transactTime = string.Format("{0:dd/MM/yyyy HH:mm:ss}", clsUtility.GetDateTime(item.TransactTime));
//                        //expireTime = string.Format("{0:dd/MM/yyyy HH:mm:ss}", clsUtility.GetDateTime(item.ExpireDate));

//                    }
//                    else
//                    {
//                        transactTime = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", clsUtility.GetDateTime(item.TransactTime));
//                        //expireTime = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", clsUtility.GetDateTime(item.ExpireDate));
//                    }

//                    string productType = Cls.clsGlobal.DDReverseProductType[Convert.ToSByte(item.ProductType)].ToString();
//                    string pType = string.Empty;
//                    if (productType == "EQ")
//                    {
//                        pType = "Equity";
//                    }
//                    else if (productType == "FUT")
//                    {
//                        pType = "FUTURE";
//                    }
//                    else if (productType == "FX")
//                    {
//                        pType = "FOREX";
//                    }
//                    else if (productType == "OPT")
//                    {
//                        pType = "OPTION";
//                    }
//                    //if (row == null)
//                    //{
////"TradeNo","OrderNo","ProductType","ProductName","Contract","BS","Quantity","Price",
////"AvgPrice",
////"FillPrice",
////"OrderType",
////"Status",
////"TradeTime",
////"LastUpdatedTime",
////"LeaveQty",
////"TradingCurrency",
////"QtyTotal",
////"SpreadSymbol",
////"AccountType",
////"ClientName",
////"Client",
////"PartOmniId",
////"Split",
////"SplitNo",
////"Remarks",
////"EnteredBy",
////"InstRemark",
////"ReferenceNo",
//                    uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Add(item.ExecID, item.OrderID, pType, item.Product, item.Contract, Cls.clsGlobal.DDReverseSide[Convert.ToSByte(item.Side)], item.OrdQty, item.Price, item.AvgPx, item.LastPx, Cls.clsGlobal.DDReverseOrderType[Convert.ToSByte(item.OrderType)],
//                    Cls.clsGlobal.DDReverseOrderStatus[Convert.ToSByte(item.OrderStatus)], transactTime, transactTime,item.LeavesQty, "","", "", "", "", "", "", "", "", "", "", "", "");
//                        //uctlTradeWindow1._DDRows.Add(item.OrderID, uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Count - 1]);
//                    //}
//                 }
//            };
//            if (this.InvokeRequired)
//            {
//                this.BeginInvoke(A);
//            }
//            else
//            {
//                A();
//            }
            //============================================

            Action A = () =>
                           {
                               //clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.AcceptChanges();
                               uctlTradeWindow1.ui_uctlGridTradeWindow.Refresh();
                               //uctlTradeWindow1.ui_uctlGridTradeWindow.DataSource = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory;
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
            ClsProfile profile = ((Dictionary<string, ClsProfile>) _objProfiles)[profileName];
            uctlTradeWindow1.CurrentProfileName =
                profileName.Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries)[0];

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
                ((Dictionary<string, ClsProfile>) _objProfiles)[profileName + "_" + ProfileTypes.Trade.ToString()];
            foreach (DataGridViewColumn col in uctlTradeWindow1.ui_uctlGridTradeWindow.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }
        }

        private void frmTradeWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;
            _formkey = CommandIDS.TRADE.ToString() + "/" + Convert.ToString(count) + "/" +
                       uctlTradeWindow1.CurrentProfileName;
        }

        private void uctlTradeWindow1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            ((FrmMain) MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);
        }

        private void SaveProfile(string profileName)
        {
            uctlTradeWindow1.CurrentProfileName = profileName;
            _formkey = CommandIDS.TRADE.ToString() + "/" + Convert.ToString(count) + "/" + profileName;

            string dirPath = Path.GetDirectoryName(ClsTWSUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsTWSUtility.GetProfileFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, _objProfiles);
            streamWrite.Close();
        }

        private void uctlTradeWindow1_OnProfileRemoveClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            ((FrmMain) MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);
        }

        private void uctlTradeWindow1_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            _objProfiles = objProfiles;
            ((FrmMain) MdiParent).Profiles = objProfiles;
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
                double sellQty = 0;
                double buyQty = 0;
                int totOrder = 0;
                double sellVal = 0;
                double buyVal = 0;
                double sellAvg = 0;
                double buyAvg = 0;
                foreach (DataRow dr in clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows)
                {
                    if (dr["BS"].ToString().ToUpper() == "SELL")
                    {
                        sellQty +=Convert.ToDouble(dr["Quantity"].ToString());
                        sellVal += Convert.ToDouble(dr["FillPrice"].ToString());
                        sellAvg += Convert.ToDouble(dr["AvgPrice"].ToString());
                    }
                    else
                    {
                        buyQty += Convert.ToDouble(dr["Quantity"].ToString());
                        buyVal += Convert.ToDouble(dr["FillPrice"].ToString());
                        buyAvg += Convert.ToDouble(dr["AvgPrice"].ToString());
                    }
                }
                //for (int i = 0; i < uctlTradeWindow1.ui_uctlGridTradeWindow.Rows.Count; i++)
                //{
                //        if (
                //            uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["BS"].Value.ToString()
                //                .ToUpper() == "SELL")
                //        {
                //            sellQty +=
                //                Convert.ToInt32(
                //                    uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["Quantity"]
                //                        .Value.ToString());
                //            sellVal+=Convert.ToInt32(
                //                    uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["FillPrice"]
                //                        .Value.ToString());
                //            sellAvg += Convert.ToInt32(
                //                  uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["AvgPrice"]
                //                      .Value.ToString());
                //        }
                //        else
                //        {
                //            buyQty +=
                //                Convert.ToInt32(
                //                    uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["Quantity"]
                //                        .Value.ToString());
                //            buyVal+=Convert.ToInt32(
                //                    uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["FillPrice"]
                //                        .Value.ToString());
                //            buyAvg += Convert.ToInt32(
                //                   uctlTradeWindow1.ui_uctlGridTradeWindow.Rows[i].Cells["AvgPrice"]
                //                       .Value.ToString());
                //        }
                //}
                totOrder = clsTWSOrderManagerJSON.INSTANCE.tradeHistoryDS.dtTradeHistory.Rows.Count;
                uctlTradeWindow1.SellQty = Convert.ToString(sellQty);
                uctlTradeWindow1.SellVal =Convert.ToString(sellVal);
                uctlTradeWindow1.SellAtp =Convert.ToString(sellAvg);
                uctlTradeWindow1.BuyQty = Convert.ToString(buyQty);
                uctlTradeWindow1.BuyVal =Convert.ToString(buyVal);
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