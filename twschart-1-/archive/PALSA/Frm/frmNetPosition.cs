///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	NAMO	    1.Desgining of the form
//14/02/2012	NAMO	    1.Code for displaying instruments in Instrument combobox
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CommonLibrary.Cls;
//using Logging;
using PALSA.Cls;
using PALSA.DS;
using ClsGlobal = PALSA.Cls.ClsGlobal;
using System.Data;

namespace PALSA.Frm
{
    public partial class frmNetPosition : frmBase
    {
        private readonly DS4NetPosition netpositionDS = new DS4NetPosition();
        private string _formkey;
        private object _objProfiles;
        public static int Count { get; private set; }

        public frmNetPosition(object objProfiles, string profileName)
        {
            InitializeComponent();

            Count += 1;
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into frmNetPosition Constructor");

            _objProfiles = objProfiles;
            uctlNetPosition1.Profiles = objProfiles as Dictionary<string, ClsProfile>;
            uctlNetPosition1.CurrentProfileName = profileName;

            _formkey = CommandIDS.NET_POSITION.ToString() + "/" + Convert.ToString(Count) + "/" +
                       uctlNetPosition1.CurrentProfileName;

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from frmNetPosition Constructor");
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

        private void frmNetPosition_FormClosed(object sender, FormClosedEventArgs e)
        {
            Count -= 1;
            clsTWSOrderManagerJSON.INSTANCE.OnPositionResponse -= INSTANCE_OnPositionResponse;
            //clsTWSDataManagerJSON.INSTANCE.OnLTPChange -= INSTANCE_OnLTPChange;
            //clsTWSDataManager.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            //clsTWSDataManager.INSTANCE.onSnapShotUpdate -= new Action<Dictionary<string, ClientDLL_Model.Cls.Market.QuoteSnapshot>>(INSTANCE_onSnapShotUpdate);
            _formkey = CommandIDS.NET_POSITION.ToString() + "/" + Convert.ToString(Count) + "/" +
                       uctlNetPosition1.CurrentProfileName;
        }

        private void frmNetPosition_Load(object sender, EventArgs e)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into frmNetPosition_Load Method");

            Title = uctlNetPosition1.Title;
            uctlNetPosition1.AddInstruments(ClsTWSContractManager.INSTANCE.GetProductTypes());
            uctlNetPosition1.OnApplyClick -= uctlNetPosition1_OnApplyClick;
            uctlNetPosition1.OnApplyClick += uctlNetPosition1_OnApplyClick;
            //clsTWSDataManagerJSON.INSTANCE.OnLTPChange += INSTANCE_OnLTPChange;
            List<string> lstAccountNos = clsTWSOrderManagerJSON.INSTANCE.GetParticipants();
            lstAccountNos.Insert(0, "All");
            uctlNetPosition1.AddAccountNo(lstAccountNos);
            List<string> lstContracts = clsTWSOrderManagerJSON.INSTANCE.PosContracts;
            lstContracts.Insert(0, "All");
            uctlNetPosition1.AddContracts(lstContracts);
            if (uctlNetPosition1.CurrentProfileName != string.Empty)
            {
                OnProfileApplyClick(uctlNetPosition1.CurrentProfileName);
            }
            else if (_objProfiles != null && ((Dictionary<string, ClsProfile>)_objProfiles).Keys.Count > 0 &&
                     ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().Contains(
                         Properties.Settings.Default.NetPositionProfile + "_" + ProfileTypes.NetPosition.ToString()))
            {
                int index = ((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList().IndexOf(
                    Properties.Settings.Default.NetPositionProfile + "_" + ProfileTypes.NetPosition);

                ApplyDefaultProfile(((Dictionary<string, ClsProfile>)_objProfiles).Keys.ToList()[index]);
            }
            DoubleBuffered(uctlNetPosition1.ui_uctlGridNetPosition.ui_ndgvGrid, true);
            
            uctlNetPosition1.ui_uctlGridNetPosition.DataSource = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition;
            clsTWSOrderManagerJSON.INSTANCE.OnPositionResponse -= INSTANCE_OnPositionResponse;
            clsTWSOrderManagerJSON.INSTANCE.OnPositionResponse += INSTANCE_OnPositionResponse;
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from frmNetPosition_Load Method");
        }

        private void INSTANCE_OnLTPChange(string arg1, double marketpriceAskBid)
        {
            Action A = () =>
                           {
                               foreach (
                                   var keyvalue in
                                       clsTWSOrderManagerJSON.INSTANCE._DDNetPos.Where(keyvalue => keyvalue.Key == arg1))
                               {
                                  
                                   //double rightZLevel = 0;
                                   //double leftZLevel = 0;
                                   //ClsGlobal.DDLeftZLevel.TryGetValue(arg1, out leftZLevel);
                                   //ClsGlobal.DDRightZLevel.TryGetValue(arg1, out rightZLevel);
                                   //int netqty = Convert.ToInt32(keyvalue.Value["NetQty"].ToString());
                                   //int buyQty = Convert.ToInt32(keyvalue.Value["BuyQty"].ToString());
                                   //int sellQty = Convert.ToInt32(keyvalue.Value["sellQty"].ToString());

                                   //if (buyQty > sellQty)
                                   //    keyvalue.Value["UR_PL"] =
                                   //        Math.Round(
                                   //            netqty*
                                   //            (leftZLevel -
                                   //             Convert.ToDouble(keyvalue.Value["BuyAvg"].ToString())), 2);
                                   //else if (buyQty < sellQty)
                                   //    keyvalue.Value["UR_PL"] =
                                   //        Math.Round(
                                   //            netqty*
                                   //            (Convert.ToDouble(keyvalue.Value["SellAvg"].ToString()) -
                                   //             rightZLevel), 2);
                                   //else
                                   //    keyvalue.Value["UR_PL"] = Math.Round(0d, 2);
                                   double bidZLevel = ClsGlobal.GetZeroLevelBidPrice(arg1);
                                   double askZLevel = ClsGlobal.GetZeroLevelAskPrice(arg1);
                                   double sellAvg = Convert.ToDouble(keyvalue.Value["SellAvg"].ToString());
                                   double buyAvg = Convert.ToDouble(keyvalue.Value["BuyAvg"].ToString());
                                   int netqty = Convert.ToInt32(keyvalue.Value["NetQty"].ToString());
                                   int buyQty = Convert.ToInt32(keyvalue.Value["BuyQty"].ToString());
                                   int sellQty = Convert.ToInt32(keyvalue.Value["sellQty"].ToString());

                                   if (buyQty > sellQty)
                                       keyvalue.Value["UR_PL"] =
                                            Math.Round(Math.Abs(netqty) * (bidZLevel - buyAvg), 2);
                                   else if (buyQty < sellQty)
                                       keyvalue.Value["UR_PL"] =
                                            Math.Round(Math.Abs(netqty) * (sellAvg - askZLevel), 2);
                                   else
                                       keyvalue.Value["UR_PL"] = Math.Round(0d, 2);
                                   //keyvalue.Value["UR_PL"] = netqty >= 0
                                   //                              ? netqty * (Convert.ToDouble(keyvalue.Value["BuyAvg"].ToString()) - marketpriceAsk_Bid)
                                   //                              : netqty * (Convert.ToDouble(keyvalue.Value["SellAvg"].ToString()) - marketpriceAsk_Bid);
                               }
                               clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.AcceptChanges();
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

  
        private void INSTANCE_OnPositionResponse(List<Position> obj)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition : Enter in to INSTANCE_OnPositionResponse Method");
            Action A =
                () =>
                {
                    uctlNetPosition1.ui_uctlGridNetPosition.DataSource = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition;
                };
            if (InvokeRequired)
            {
                BeginInvoke(A);
            }
            else
            {
                A();
            }

            //FileHandling.WriteDevelopmentLog("NetPosition : Exit from INSTANCE_OnPositionResponse Method");
        }


        private void uctlNetPosition1_OnApplyClick(string accountId, string instrumentName)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count +" : Enter into uctlNetPosition1_OnApplyClick Method");

            if (clsTWSOrderManagerJSON.INSTANCE.IsOrderMgrLoaded)
            {
                //try
                //{
                if (netpositionDS.dtNetPosition.Rows.Count > 0)
                {
                    if (instrumentName != "All")
                    {
                        instrumentName = instrumentName.Trim().Replace(' ', '_');
                        instrumentName = instrumentName.ToUpper();
                    }
                    string query = string.Empty;
                    query = accountId == "All" ? "" : "AccountNo='" + accountId + "' and ";
                    query = query + (instrumentName == "All" ? "" : "ProductType='" + instrumentName + "' and ");

                    if (query != string.Empty)
                    {
                        query = query.Remove(query.Length - 5);
                    }
                    uctlNetPosition1.ui_uctlGridNetPosition.DataSource = netpositionDS.dtNetPosition.Select(query);
                }
                //}
                //catch (Exception ex)
                //{

                //}
            }

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from uctlNetPosition1_OnApplyClick Method");
        }

        private void ApplyDefaultProfile(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into ApplyDefaultProfile Method");

            ClsProfile profile = ((Dictionary<string, ClsProfile>)_objProfiles)[profileName];
            uctlNetPosition1.CurrentProfileName =
                profileName.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0];

            foreach (DataGridViewColumn col in uctlNetPosition1.ui_uctlGridNetPosition.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from ApplyDefaultProfile Method");
        }

        private void OnProfileApplyClick(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into OnProfileApplyClick Method");

            ClsProfile profile =
                ((Dictionary<string, ClsProfile>)_objProfiles)[profileName + "_" + ProfileTypes.NetPosition.ToString()];
            foreach (DataGridViewColumn col in uctlNetPosition1.ui_uctlGridNetPosition.Columns)
            {
                ClsColumnSetting colsetting = profile.DDColumnSetting[col.HeaderText];
                col.DisplayIndex = colsetting.Index;
                col.Visible = colsetting.Visible;
            }

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from OnProfileApplyClick Method");
        }

        private void uctlNetPosition1_OnProfileRemoveClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count +" : Enter into uctlNetPosition1_OnProfileRemoveClick Method");

            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count +" : Exit from uctlNetPosition1_OnProfileRemoveClick Method");
        }

        private void uctlNetPosition1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count +" : Enter into uctlNetPosition1_OnProfileSaveClick Method");

            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count +" : Exit from uctlNetPosition1_OnProfileSaveClick Method");
        }

        private void SaveProfile(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into SaveProfile Method");

            string dirPath = Path.GetDirectoryName(ClsPalsaUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsPalsaUtility.GetProfileFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, _objProfiles);
            uctlNetPosition1.CurrentProfileName = profileName;
            _formkey = CommandIDS.NET_POSITION.ToString() + "/" + Convert.ToString(Count) + "/" +
                       uctlNetPosition1.CurrentProfileName;
            streamWrite.Close();

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from SaveProfile Method");
        }

        private void uctlNetPosition1_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count +" : Enter into uctlNetPosition1_OnSetDefaultProfileClick Method");

            Properties.Settings.Default.NetPositionProfile = profileName;
            Properties.Settings.Default.Save();

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count +" : Exit from uctlNetPosition1_OnSetDefaultProfileClick Method");
        }

        private void uctlNetPosition1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count +" : Enter into uctlNetPosition1_OnGridMouseDown Method");

            uctlNetPosition1.ui_uctlGridNetPosition.ContextMenuStrip.Items["SaveAs"].Enabled =
                uctlNetPosition1.ui_uctlGridNetPosition.Rows.Count > 0;

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count +" : Exit from uctlNetPosition1_OnGridMouseDown Method");
        }

        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into DoubleBuffered Method");

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from DoubleBuffered Method");
        }

        private void uctlNetPosition1_OnAccountChanged()
        {
            int acNo = 0;
            if (uctlNetPosition1.AccountNo != "All" && uctlNetPosition1.AccountNo != string.Empty)
            {
                acNo = Convert.ToInt32(uctlNetPosition1.AccountNo);
                clsTWSOrderManagerJSON.INSTANCE.RequestForNetPositionOfAccount(acNo, true);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Action A =
                () =>
                {

                    for (int i = 0; i < clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows.Count; i++)
                    {
                        int j = i;
                        //Right means ask
                        //left means bid
                        double bidZLevel = ClsGlobal.GetZeroLevelBidPrice(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["Contract"].ToString());
                        double askZLevel = ClsGlobal.GetZeroLevelAskPrice(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["Contract"].ToString());
                        double sellAvg = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["SellAvg"].ToString());
                        double buyAvg = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["BuyAvg"].ToString());
                        int netqty = Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["NetQty"].ToString());
                        int buyQty = Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["BuyQty"].ToString());
                        int sellQty = Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["sellQty"].ToString());
                        string contract = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["Contract"].ToString();
                        string pType = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["ProductType"].ToString();
                       string productName = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["ProductName"].ToString();
                        //InstrumentSpec inst =ClsTWSContractManager.INSTANCE.GetInstrumentSpecification(pType,contract, productName);
                        InstrumentSpec inst = ClsTWSContractManager.INSTANCE.ddContractDetails[contract];
                        if (pType != "FOREX")
                        {
                            if (ClsGlobal.DDLTP.Keys.Contains(contract))
                                clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["MarketPrice"] =
                                   Math.Round(Convert.ToDecimal(ClsGlobal.DDLTP[contract]), 2);
                        }
                        else
                        {
                            if (netqty >= 0) //left//bid
                            {
                                if (ClsGlobal.DDLeftZLevel.Keys.Contains(contract))
                                    clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["MarketPrice"] =
                                        Math.Round(Convert.ToDecimal(ClsGlobal.GetZeroLevelBidPrice(contract)), 2);
                            }
                            else //right//ask
                            {
                                if (ClsGlobal.DDRightZLevel.Keys.Contains(contract))
                                    clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["MarketPrice"] =
                                        Math.Round(Convert.ToDecimal(ClsGlobal.GetZeroLevelAskPrice(contract)), 2);
                            }
                        }

                        if (buyQty > sellQty)
                            clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["UR_PL"] =
                                 Math.Round(Math.Abs(netqty) * (bidZLevel - buyAvg) * inst.ContractSize, 2);
                        else if (buyQty < sellQty)
                            clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["UR_PL"] =
                                 Math.Round(Math.Abs(netqty) * (sellAvg - askZLevel) * inst.ContractSize, 2);
                        else
                            clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["UR_PL"] = Math.Round(0d, 2);

                    }
                    clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.AcceptChanges();

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
