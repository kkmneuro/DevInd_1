///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	VP		    1.Desgining of the form
//14/02/2012	VP		    1.Code for displaying instruments in Instrument combobox
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CommonLibrary.Cls;
using TWS.Cls;
using TWS.DS;
using ClsGlobal = TWS.Cls.ClsGlobal;
using System.Data;

namespace TWS.Frm
{
    public partial class frmNetPosition : frmBase
    {
        private readonly DS4NetPosition netpositionDS = new DS4NetPosition();
        private string _formkey;
        private object _objProfiles;
        public static int Count { get; private set; }
        private int AccountID = -1;
        private DataTable dtNetPositionGrid;

        public frmNetPosition(object objProfiles, string profileName)
        {
            InitializeComponent();
            dtNetPositionGrid = new DataTable();
            Count += 1;
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into frmNetPosition Constructor");

            _objProfiles = objProfiles;
            uctlNetPosition1.Profiles = objProfiles as Dictionary<string, ClsProfile>;
            //uctlNetPosition1.Profiles = objProfiles;
            uctlNetPosition1.CurrentProfileName = profileName;

            _formkey = CommandIDS.NET_POSITION.ToString() + "/" + Convert.ToString(Count) + "/" +
                       uctlNetPosition1.CurrentProfileName;

           // FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from frmNetPosition Constructor");
        }


        public frmNetPosition(object objProfiles, string profileName, int _AccountID)
        {
            InitializeComponent();
            AccountID = _AccountID;
            dtNetPositionGrid = new DataTable();
            Count += 1;
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into frmNetPosition Constructor");

            _objProfiles = objProfiles;
            uctlNetPosition1.Profiles = objProfiles as Dictionary<string, ClsProfile>;
            //uctlNetPosition1.Profiles = objProfiles;
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
            clsTWSDataManagerJSON.INSTANCE.OnLTPChange2 -= INSTANCE_OnLTPChange;
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
            List<string> lstAccountNos = clsTWSOrderManagerJSON.INSTANCE.GetParticipants();
            lstAccountNos.Insert(0, "All");
            uctlNetPosition1.AddAccountNo(lstAccountNos);
            List<string> lstContracts = clsTWSOrderManagerJSON.INSTANCE.PosContracts;
            if (!lstContracts.Contains("All"))
            {
                lstContracts.Insert(0, "All");
            }
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
            if (AccountID == -1)
            {
                dtNetPositionGrid = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Copy();
                uctlNetPosition1.ui_uctlGridNetPosition.DataSource = dtNetPositionGrid;//Namo

                //uctlNetPosition1.ui_uctlGridNetPosition.DataSource = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition;
            }
            else
            {
                uctlNetPosition1.ui_nbtnHideFilter.Visible = false;
                uctlNetPosition1.ui_pnlFilter.Visible = false;
                SetDataSource(AccountID);
            }

            //clsTWSOrderManagerJSON.INSTANCE.OnPositionUpdate -= new Action<int>(INSTANCE_OnPositionUpdate);
            //clsTWSOrderManagerJSON.INSTANCE.OnPositionUpdate += new Action<int>(INSTANCE_OnPositionUpdate);
            clsTWSOrderManagerJSON.INSTANCE.PositionResponse -= new Action<List<Cls.Position>>(INSTANCE_PositionResponse);
            clsTWSOrderManagerJSON.INSTANCE.PositionResponse += new Action<List<Cls.Position>>(INSTANCE_PositionResponse);
            clsTWSDataManagerJSON.INSTANCE.OnLTPChange2 -= INSTANCE_OnLTPChange;
            clsTWSDataManagerJSON.INSTANCE.OnLTPChange2 += INSTANCE_OnLTPChange;
            //clsTWSDataManagerJSON.INSTANCE.onMarketPriceUpdate -= new Action<string>(INSTANCE_onPnLUpdate);
            //clsTWSDataManagerJSON.INSTANCE.onMarketPriceUpdate += new Action<string>(INSTANCE_onPnLUpdate);
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from frmNetPosition_Load Method");
        }

        void INSTANCE_OnPositionUpdate(int obj)
        {
            if (AccountID != -1 && AccountID == obj)
            {
                SetDataSource(AccountID);
            }
            else
            {
                uctlNetPosition1_OnAccountChanged();
            }
        }

        public void INSTANCE_PositionResponse(List<Cls.Position> lstPosition)
        {

            foreach (Cls.Position positionInfo in lstPosition)
            {
                if (AccountID != -1 && AccountID == positionInfo.Account)
                {
                    UpdateNetPosition(positionInfo);
                }
                else
                {
                    UpdateNetPosition(positionInfo);
                }
            }
        }

        private void UpdateNetPosition(Cls.Position positionInfo)
        {
            try
            {
                if (System.Threading.Monitor.TryEnter(dtNetPositionGrid, 500))
                {
                    try
                    {
                        lock (dtNetPositionGrid)
                        {
                            string productType = ClsGlobal.DDReverseProductType[Convert.ToSByte(positionInfo.ProductType)];

                            string pType = string.Empty;
                            switch (productType)
                            {
                                case "EQ":
                                    pType = "Equity";
                                    break;
                                case "FUT":
                                    pType = "FUTURE";
                                    break;
                                case "FX":
                                    pType = "FOREX";
                                    break;
                                case "OPT":
                                    pType = "OPTION";
                                    break;
                                case "SP":
                                    pType = "SPOT";
                                    break;
                                case "PH":
                                    pType = "PHYSICAL";
                                    break;
                                case "AU":
                                    pType = "AUCTION";
                                    break;
                                case "BON":
                                    pType = "BOND";
                                    break;
                                default:
                                    break;
                            }
                            ;
                            InstrumentSpec objInstrumentSpec = ClsTWSContractManager.INSTANCE.ddContractDetails[positionInfo.Contract];

                            if (objInstrumentSpec != null)
                            {
                                double BuyQty = positionInfo.BuyQty / objInstrumentSpec.ContractSize;
                                double SellQty = positionInfo.SellQty / objInstrumentSpec.ContractSize;
                                double BuyAvg = positionInfo.BuyAvg / Convert.ToDouble(Math.Pow(10, objInstrumentSpec.Digits));
                                double SellAvg = positionInfo.SellAvg / Convert.ToDouble(Math.Pow(10, objInstrumentSpec.Digits));

                                DataRow[] rw = dtNetPositionGrid.Select("AccountNo=" + positionInfo.Account);
                                if (rw.Length < 1)
                                {
                                    DataRow row = netpositionDS.dtNetPosition.NewRow();
                                    row["AccountNo"] = Convert.ToString(positionInfo.Account);
                                    row["ProductType"] = pType;
                                    row["Contract"] = Convert.ToString(positionInfo.Contract);
                                    if (objInstrumentSpec != null)
                                        row["TradingCurrency"] = objInstrumentSpec.TradingCurrency;
                                    row["ProductName"] = Convert.ToString(positionInfo.Product);
                                    row["BuyQty"] = BuyQty;
                                    row["ContractSize"] = objInstrumentSpec.ContractSize;
                                    if (objInstrumentSpec.ContractSize != 0)
                                    {
                                        row["BuyVal"] = Math.Round((positionInfo.BuyVal / objInstrumentSpec.ContractSize), 2);
                                        row["SellVal"] = Math.Round((positionInfo.SellVal / objInstrumentSpec.ContractSize), 2);
                                    }
                                    else
                                    {
                                        row["BuyVal"] = Math.Round((positionInfo.BuyVal), 2);
                                        row["SellVal"] = Math.Round((positionInfo.SellVal), 2);
                                    }
                                    row["BuyAvg"] = Math.Round(BuyAvg, 2).ToString("0.00");
                                    row["SellQty"] = SellQty;
                                    row["SellAvg"] = Math.Round(SellAvg,2).ToString("0.00");

                                    if (SellQty > BuyQty)
                                    {
                                        row["NetQty"] = Convert.ToString(SellQty - BuyQty);
                                    }
                                    else
                                        row["NetQty"] = Convert.ToString(BuyQty - SellQty);
                                    row["NetVal"] = Convert.ToString(Math.Round(positionInfo.NetVal, 2));
                                    row["NetPrice"] = Math.Round(positionInfo.NetPrice, 2).ToString("0.00");
                                    if (pType != "FOREX")
                                    {
                                        if (ClsGlobal.DDLTP.Keys.Contains(row["Contract"].ToString()))
                                            row["MarketPrice"] =
                                                Math.Round(Convert.ToDecimal(ClsGlobal.DDLTP[row["Contract"].ToString()]), 2).ToString("0.00");
                                    }
                                    else
                                    {
                                        if (positionInfo.NetQty >= 0)
                                        {
                                            if (ClsGlobal.DDLeftZLevel.Keys.Contains(row["Contract"].ToString()))
                                                row["MarketPrice"] = Math.Round(Convert.ToDecimal(ClsGlobal.DDLeftZLevel[row["Contract"].ToString()]), 2).ToString("0.00");
                                        }
                                        else
                                        {
                                            if (ClsGlobal.DDRightZLevel.Keys.Contains(row["Contract"].ToString()))
                                                row["MarketPrice"] = Math.Round(Convert.ToDecimal(ClsGlobal.DDRightZLevel[row["Contract"].ToString()]), 2).ToString("0.00");
                                        }
                                    }
                                    double marketPrice = 0;

                                    if (ClsGlobal.DDLTP.Keys.Contains(row["Contract"].ToString()))
                                        marketPrice = Math.Round(Convert.ToDouble(ClsGlobal.DDLTP[row["Contract"].ToString()]), 2);

                                    if (BuyQty > SellQty)
                                        row["UR_PL"] = Math.Round((BuyQty - SellQty) * (marketPrice - BuyAvg) * objInstrumentSpec.ContractSize, 2).ToString("0.00");

                                    else if (BuyQty < SellQty)
                                        row["UR_PL"] = Math.Round((SellQty - BuyQty) * (SellAvg - marketPrice) * objInstrumentSpec.ContractSize, 2).ToString("0.00");
                                    else
                                        row["UR_PL"] = Math.Round(0d, 2).ToString("0.00");



                                    if (dtNetPositionGrid.Rows.Count == 0)
                                        dtNetPositionGrid.Rows.Add(row);
                                    else
                                        dtNetPositionGrid.Rows.InsertAt(row, 0);


                                }
                                else
                                {
                                    rw[0]["AccountNo"] = Convert.ToString(positionInfo.Account);
                                    rw[0]["ProductType"] = pType;
                                    rw[0]["Contract"] = Convert.ToString(positionInfo.Contract);
                                    rw[0]["TradingCurrency"] = objInstrumentSpec.TradingCurrency;
                                    rw[0]["ProductName"] = Convert.ToString(positionInfo.Product);
                                    rw[0]["BuyQty"] = BuyQty;
                                    rw[0]["BuyVal"] = Convert.ToString(Math.Round(positionInfo.BuyVal, 2));
                                    rw[0]["BuyAvg"] = Math.Round(BuyAvg, 2).ToString("0.00");
                                    rw[0]["SellQty"] = SellQty;
                                    rw[0]["SellVal"] = Convert.ToString(Math.Round(positionInfo.SellVal, 2));
                                    rw[0]["SellAvg"] = Math.Round(SellAvg, 2).ToString("0.00");
                                    if (SellQty > BuyQty)
                                    {
                                        rw[0]["NetQty"] = Convert.ToString(SellQty - BuyQty);
                                    }
                                    else
                                        rw[0]["NetQty"] = Convert.ToString(BuyQty - SellQty);
                                    rw[0]["NetVal"] = Convert.ToString(Math.Round(positionInfo.NetVal, 2));
                                    rw[0]["NetPrice"] = Math.Round(positionInfo.NetPrice, 2).ToString("0.00");
                                    double marketPrice = 0;

                                    if (ClsGlobal.DDLTP.Keys.Contains(rw[0]["Contract"].ToString()))
                                        marketPrice = Math.Round(Convert.ToDouble(ClsGlobal.DDLTP[rw[0]["Contract"].ToString()]), 2);

                                    if (BuyQty > SellQty)
                                        rw[0]["UR_PL"] = Math.Round((BuyQty - SellQty) * (marketPrice - BuyAvg) * objInstrumentSpec.ContractSize, 2).ToString("0.00");

                                    else if (BuyQty < SellQty)
                                        rw[0]["UR_PL"] = Math.Round((SellQty - BuyQty) * (SellAvg - marketPrice) * objInstrumentSpec.ContractSize, 2).ToString("0.00");
                                    else
                                        rw[0]["UR_PL"] = Math.Round(0d, 2).ToString("0.00");

                                    rw[0].AcceptChanges();
                                }

                            }

                        }
                    }
                    finally
                    {
                        System.Threading.Monitor.Exit(dtNetPositionGrid);
                       // dtNetPositionGrid.AcceptChanges();
                    }
                }
                dtNetPositionGrid.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void INSTANCE_onPnLUpdate(string ContractName)
        {
            Action A = () =>
                           {
                               try
                               {
                                   if (System.Threading.Monitor.TryEnter(dtNetPositionGrid, 500))
                                   {
                                       try
                                       {
                                           DataRow[] rws = dtNetPositionGrid.Select("Contract ='" + ContractName + "'");
                                           foreach (DataRow rw in rws)
                                           {
                                               double LTPPrice = 0;
                                               if (ClsGlobal.DDLTP.Keys.Contains(ContractName))
                                               {
                                                   LTPPrice = Math.Round(Convert.ToDouble(ClsGlobal.DDLTP[ContractName]), 2);
                                               }

                                               double sellAvg = Convert.ToDouble(rw["SellAvg"].ToString());
                                               double buyAvg = Convert.ToDouble(rw["BuyAvg"].ToString());
                                               int netqty = Convert.ToInt32(rw["NetQty"].ToString());
                                               int buyQty = Convert.ToInt32(rw["BuyQty"].ToString());
                                               int sellQty = Convert.ToInt32(rw["sellQty"].ToString());
                                               int ContractSize = Convert.ToInt32(rw["ContractSize"].ToString());

                                               if (buyQty > sellQty)
                                                   rw["UR_PL"] = Math.Round(Math.Abs(buyQty - sellQty) * (LTPPrice - buyAvg) * ContractSize, 2);

                                               else if (buyQty < sellQty)
                                                   rw["UR_PL"] = Math.Round(Math.Abs(sellQty - buyQty) * (sellAvg - LTPPrice) * ContractSize, 2);
                                               else
                                                   rw["UR_PL"] = Math.Round(0d, 2);
                                               rw.AcceptChanges();
                                           }
                                       }
                                       finally
                                       {
                                           System.Threading.Monitor.Exit(dtNetPositionGrid);
                                       }
                                   }
                                   dtNetPositionGrid.AcceptChanges();
                               }
                               catch (Exception)
                               {


                               }

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

        private void INSTANCE_OnLTPChange(string ContractName, double marketpriceAskBid)
        {
            Action A = () =>
                           {
                               try
                               {
                                   if (System.Threading.Monitor.TryEnter(dtNetPositionGrid, 500))
                                   {
                                       try
                                       {
                                           DataRow[] rws = dtNetPositionGrid.Select("Contract ='" + ContractName + "'");
                                           foreach (DataRow rw in rws)
                                           {
                                               double LTPPrice = 0;
                                               if (ClsGlobal.DDLTP.Keys.Contains(ContractName))
                                               {
                                                   LTPPrice = Math.Round(Convert.ToDouble(ClsGlobal.DDLTP[ContractName]), 2);
                                               }

                                               double sellAvg = Convert.ToDouble(rw["SellAvg"].ToString());
                                               double buyAvg = Convert.ToDouble(rw["BuyAvg"].ToString());
                                               int netqty = Convert.ToInt32(rw["NetQty"].ToString());
                                               int buyQty = Convert.ToInt32(rw["BuyQty"].ToString());
                                               int sellQty = Convert.ToInt32(rw["sellQty"].ToString());
                                               int ContractSize = Convert.ToInt32(rw["ContractSize"].ToString());

                                               if (buyQty > sellQty)
                                                   rw["UR_PL"] = Math.Round((buyQty - sellQty) * (LTPPrice - buyAvg) * ContractSize, 2);

                                               else if (buyQty < sellQty)
                                                   rw["UR_PL"] = Math.Round((sellQty - buyQty) * (sellAvg - LTPPrice) * ContractSize, 2);
                                               else
                                                   rw["UR_PL"] = Math.Round(0d, 2);
                                               rw.AcceptChanges();
                                           }
                                       }
                                       finally
                                       {
                                           System.Threading.Monitor.Exit(dtNetPositionGrid);
                                       }
                                   }
                                   dtNetPositionGrid.AcceptChanges();
                               }
                               catch (Exception)
                               {


                               }

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


 
        private void INSTANCE_OnPositionResponse(List<Cls.Position> obj)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition : Enter in to INSTANCE_OnPositionResponse Method");
            ////Action A =
            ////    () =>
            ////    {
            ////        lock (uctlNetPosition1.ui_uctlGridNetPosition)
            ////        {
            ////            uctlNetPosition1.ui_uctlGridNetPosition.DataSource = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition;
            ////        }
            ////    };
            ////if (InvokeRequired)
            ////{
            ////    BeginInvoke(A);
            ////}
            ////else
            ////{
            ////    A();
            ////}

            //FileHandling.WriteDevelopmentLog("NetPosition : Exit from INSTANCE_OnPositionResponse Method");
        }


        private void uctlNetPosition1_OnApplyClick(string accountId, string instrumentName)
        {
           // FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into uctlNetPosition1_OnApplyClick Method");

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
                    dtNetPositionGrid.Rows.Clear();
                    DataRow[] dr = netpositionDS.dtNetPosition.Select(query);
                    if (dr.Length > 0)
                    {
                        dtNetPositionGrid = dr.CopyToDataTable();
                        uctlNetPosition1.ui_uctlGridNetPosition.DataSource = dtNetPositionGrid;//Namo
                    }
                    else
                    {
                        dtNetPositionGrid.Rows.Clear();
                        dtNetPositionGrid.AcceptChanges();
                    }

                    //uctlNetPosition1.ui_uctlGridNetPosition.DataSource = netpositionDS.dtNetPosition.Select(query);
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
           // FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into ApplyDefaultProfile Method");

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
           // FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into uctlNetPosition1_OnProfileRemoveClick Method");

            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);

           // FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from uctlNetPosition1_OnProfileRemoveClick Method");
        }

        private void uctlNetPosition1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into uctlNetPosition1_OnProfileSaveClick Method");

            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);

           // FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from uctlNetPosition1_OnProfileSaveClick Method");
        }

        private void SaveProfile(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into SaveProfile Method");

            string dirPath = Path.GetDirectoryName(ClsTWSUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsTWSUtility.GetProfileFileName(),
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
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into uctlNetPosition1_OnSetDefaultProfileClick Method");

            Properties.Settings.Default.NetPositionProfile = profileName;
            Properties.Settings.Default.Save();

            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from uctlNetPosition1_OnSetDefaultProfileClick Method");
        }

        private void uctlNetPosition1_OnGridMouseDown(object arg1, MouseEventArgs arg2)
        {
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into uctlNetPosition1_OnGridMouseDown Method");

            uctlNetPosition1.ui_uctlGridNetPosition.ContextMenuStrip.Items["SaveAs"].Enabled =
                uctlNetPosition1.ui_uctlGridNetPosition.Rows.Count > 0;

//            FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from uctlNetPosition1_OnGridMouseDown Method");
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
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Enter into uctlNetPosition1_OnAccountChanged Method");
            int acNo = 0;

            if (clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows.Count > 0)
            {
                if (uctlNetPosition1.AccountNo != "All" && uctlNetPosition1.AccountNo != string.Empty)
                    acNo = Convert.ToInt32(uctlNetPosition1.AccountNo);
                string _contract = uctlNetPosition1.InstrumentList;
                string query = string.Empty;
                query = acNo == 0 ? "" : "AccountNo=" + acNo + " and ";
                query = query + (_contract == "All" ? "" : "Contract='" + _contract + "' and ");
                if (query != string.Empty)
                {
                    query = query.Remove(query.Length - 5);

                    Action A = () =>
                    {
                        dtNetPositionGrid.Rows.Clear();
                        DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Select(query);
                        if (dr.Length > 0)
                        {
                            dtNetPositionGrid = dr.CopyToDataTable();
                            uctlNetPosition1.ui_uctlGridNetPosition.DataSource = dtNetPositionGrid;//Namo
                        }
                        else
                        {
                            dtNetPositionGrid.Rows.Clear();
                            dtNetPositionGrid.AcceptChanges();
                        }
                        //uctlNetPosition1.ui_uctlGridNetPosition.DataSource = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Select(query);
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
                else
                {
                    dtNetPositionGrid.Rows.Clear();
                    dtNetPositionGrid = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Copy();
                    uctlNetPosition1.ui_uctlGridNetPosition.DataSource = dtNetPositionGrid;//Namo

                    //uctlNetPosition1.ui_uctlGridNetPosition.DataSource = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition;
                }
            }
            //FileHandling.WriteDevelopmentLog("NetPosition" + Count + " : Exit from uctlNetPosition1_OnAccountChanged Method");
        }

        private void SetDataSource(int acNo)
        {
            try
            {
                if (clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows.Count > 0)
                {
                    Action A = () =>
                    {
                        dtNetPositionGrid.Rows.Clear();
                        DataRow[] dr = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Select("AccountNo=" + acNo);
                        if (dr.Length > 0)
                        {
                            dtNetPositionGrid = dr.CopyToDataTable();
                            uctlNetPosition1.ui_uctlGridNetPosition.DataSource = dtNetPositionGrid;//Namo
                        }
                        else
                        {
                            dtNetPositionGrid.Rows.Clear();
                            dtNetPositionGrid.AcceptChanges();
                        }
                        // uctlNetPosition1.ui_uctlGridNetPosition.DataSource = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Select("AccountNo=" + acNo);
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
            catch (Exception)
            {

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Action A =
            //    () =>
            //    {

            //        for (int i = 0; i < clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows.Count; i++)
            //        {
            //            int j = i;
            //            //Right means ask
            //            //left means bid
            //            double bidZLevel = ClsGlobal.GetZeroLevelBidPrice(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["Contract"].ToString());
            //            double askZLevel = ClsGlobal.GetZeroLevelAskPrice(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["Contract"].ToString());
            //            double sellAvg = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["SellAvg"].ToString());
            //            double buyAvg = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["BuyAvg"].ToString());
            //            double netqty = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["NetQty"].ToString());
            //            double buyQty = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["BuyQty"].ToString());
            //            double sellQty = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["sellQty"].ToString());
            //            string contract = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["Contract"].ToString();
            //            string pType = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["ProductType"].ToString();
            //            string productName = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["ProductName"].ToString();
            //             InstrumentSpec inst =ClsTWSContractManager.INSTANCE.GetInstrumentSpecification(pType,contract, productName);
            //            if (pType != "FOREX")
            //            {
            //                if (ClsGlobal.DDLTP.Keys.Contains(contract))
            //                    clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["MarketPrice"] =
            //                       Math.Round(Convert.ToDecimal(ClsGlobal.DDLTP[contract]), 2);
            //            }
            //            else
            //            {
            //                if (netqty >= 0) //left//bid
            //                {
            //                    if (ClsGlobal.DDLeftZLevel.Keys.Contains(contract))
            //                        clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["MarketPrice"] =
            //                            Math.Round(Convert.ToDecimal(ClsGlobal.GetZeroLevelBidPrice(contract)), 2);
            //                }
            //                else //right//ask
            //                {
            //                    if (ClsGlobal.DDRightZLevel.Keys.Contains(contract))
            //                        clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["MarketPrice"] =
            //                            Math.Round(Convert.ToDecimal(ClsGlobal.GetZeroLevelAskPrice(contract)), 2);
            //                }
            //            }

            //            if (buyQty > sellQty)
            //                clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["UR_PL"] =
            //                     Math.Round(Math.Abs(netqty) * (bidZLevel - buyAvg) * inst.ContractSize, 2);
            //            else if (buyQty < sellQty)
            //                clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["UR_PL"] =
            //                     Math.Round(Math.Abs(netqty) * (sellAvg - askZLevel) * inst.ContractSize, 2);
            //            else
            //                clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[j]["UR_PL"] = Math.Round(0d, 2);

            //        }
            //        clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.AcceptChanges();

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

        private void uctlNetPosition1_OnSquareOffClick()
        {
            if (uctlNetPosition1.ui_uctlGridNetPosition.Rows.Count > 0)
            {
                if (AccountID == -1)
                {
                    DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure want to square off all the orders?");
                    if (result == DialogResult.Yes)
                    {
                        squareOffOrders();
                    }
                }
                else if (AccountID > -1)
                {
                    DialogResult result = ClsCommonMethods.ShowMessageBox("Are you sure want to square off all the orders of account " + AccountID + " ?");
                    if (result == DialogResult.Yes)
                    {
                        squareOffOrders();
                    }
                }

            }
            else
            {
                ClsCommonMethods.ShowInformation("No open position is available to square off.");
            }

        }

        private void squareOffOrders()
        {

            try
            {
                List<order> lstOrders = new List<order>();
                List<int> lstAccounts = new List<int>();
                if (AccountID == -1)
                {
                    foreach (DataGridViewRow rws in uctlNetPosition1.ui_uctlGridNetPosition.Rows)
                    {
                        int accountId = -1;
                        int.TryParse(rws.Cells["clmAccount"].Value.ToString().Trim(), out accountId);
                        if (accountId > -1 && !lstAccounts.Contains(accountId))
                        {
                            lstAccounts.Add(accountId);
                        }
                    }
                }
                else
                {
                    lstAccounts.Add(AccountID);
                }
                //int.TryParse(uctlNetPosition1.ui_uctlGridNetPosition.SelectedRows[0].Cells["clmAccount"].Value.ToString().Trim(), out accountId);
                foreach (int accountId in lstAccounts)
                {
                    if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory, 500))
                    {
                        try
                        {
                            if (clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Rows.Count > 0)
                            {
                                string query = "Account=" + accountId + " AND CumQty - SettledQty > 0";
                                DataRow[] ords = clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory.Select(query);
                                if (ords.Length > 0)
                                {
                                    foreach (var rw in ords)
                                    {
                                        string orderStatus = rw["OrderStatus"].ToString().ToUpper();

                                        if (orderStatus == "FILLED" || orderStatus == "PARTIALLY_FILLED")
                                        {
                                            DateTime expiryDateTime = DateTime.UtcNow;
                                            DateTime transactTime = DateTime.UtcNow;
                                            DateTime.TryParse(rw["TransactTime"].ToString(), out transactTime);
                                            double transTime = transactTime.ToOADate();
                                            DateTime.TryParse(rw["ExpireDate"].ToString(), out expiryDateTime);
                                            string pType = rw["ProductType"].ToString();
                                            switch (pType)
                                            {
                                                case "Equity":
                                                    pType = "EQ";
                                                    break;
                                                case "FUTURE":
                                                    pType = "FUT";
                                                    break;
                                                case "FOREX":
                                                    pType = "FX";
                                                    break;
                                                case "OPTION":
                                                    pType = "OPT";
                                                    break;
                                                case "SPOT":
                                                    pType = "SP";
                                                    break;
                                                case "PHYSICAL":
                                                    pType = "PH";
                                                    break;
                                                case "AUCTION":
                                                    pType = "AU";
                                                    break;
                                                case "BOND":
                                                    pType = "BON";
                                                    break;
                                                default:
                                                    break;
                                            }
                                            ;

                                            string _side = string.Empty;

                                            if (rw["Side"].ToString().Trim().ToUpper() == "BUY")
                                            {
                                                _side = "SELL";
                                            }
                                            else
                                            {
                                                _side = "BUY";
                                            }
                                            sbyte ordType = TWS.Cls.ClsGlobal.DDOrderTypes[rw["OrderType"].ToString()];
                                            sbyte side = TWS.Cls.ClsGlobal.DDSide[_side];
                                            // int Account = Convert.ToInt32(rw["clmClient"].ToString());
                                            string clOrdId = rw["ClientOrderID"].ToString();
                                            string CloseClOrdID = rw["ClientOrderID"].ToString();
                                            string CloseOrderID = rw["ClientOrderID"].ToString();
                                            string ContractName = rw["Contract"].ToString().Trim();
                                            string ProductType = rw["ProductType"].ToString();
                                            sbyte Producttype = TWS.Cls.ClsGlobal.DDProductTypes[pType];
                                            int digit = 0;
                                            if (ClsGlobal.DDContractDigit.ContainsKey(ContractName))
                                            {
                                                digit = ClsGlobal.DDContractDigit[ContractName];
                                            }
                                            int Contractsize = 1;
                                            if (ClsGlobal.DDContractSize.ContainsKey(ContractName))
                                            {
                                                Contractsize = ClsGlobal.DDContractSize[ContractName];
                                            }

                                            double ordQty = 0;
                                            ordQty = (Convert.ToDouble(rw["CumQty"].ToString()) - Convert.ToDouble(rw["SettledQty"].ToString())) * Contractsize;
                                            double price = 0;

                                            if (rw["Side"].ToString().ToUpper() == "BUY")
                                            {
                                                price = TWS.Cls.ClsGlobal.GetZeroLevelBidPrice(ContractName) * Math.Pow(10, digit);
                                            }
                                            else
                                            {
                                                price = TWS.Cls.ClsGlobal.GetZeroLevelAskPrice(ContractName) * Math.Pow(10, digit);
                                            }


                                            double stopPx = Convert.ToDouble(rw["StopPx"].ToString()) * Math.Pow(10, digit);
                                            sbyte tif = TWS.Cls.ClsGlobal.DDValidity[rw["TimeInForce"].ToString()];
                                            bool OCOrder = false;
                                            order objOrder = new order();
                                            objOrder.accountId = accountId;
                                            objOrder.clOrdId = clOrdId;
                                            objOrder.ContractName = ContractName;
                                            objOrder.Producttype = Producttype;
                                            objOrder.ProductName = rw["Product"].ToString();
                                            objOrder.ExpiryDate = expiryDateTime;
                                            objOrder.GatewayName = rw["Gateway"].ToString();
                                            objOrder.Side = side;
                                            objOrder.ordQty = ordQty;
                                            objOrder.OrderType = ordType;
                                            objOrder.Price = price;
                                            objOrder.StopPX = stopPx;
                                            objOrder.Tif = tif;
                                            objOrder.transTime = transTime;
                                            objOrder.CloseClOrdID = CloseClOrdID;
                                            objOrder.CloseOrderID = CloseOrderID;
                                            objOrder.OCOrder = OCOrder;
                                            lstOrders.Add(objOrder);

                                        }
                                        else
                                        {
                                            ClsCommonMethods.ShowErrorBox(orderStatus + " Order can not be Closed.");
                                        }
                                    }
                                }
                            }

                        }
                        finally
                        {
                            System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.orderHistoryDS.dtOrderHistory);
                        }
                    }
                }
                if (lstOrders.Count > 0)
                {
                    foreach (var item in lstOrders)
                    {
                        clsTWSOrderManagerJSON.INSTANCE.CloseOrder(item.accountId, item.clOrdId, item.ContractName, item.Producttype, item.ProductName, item.ExpiryDate,
                                                                                item.GatewayName, item.clOrdId, item.Side, item.ordQty, item.OrderType, item.Price, item.StopPX, item.Tif,
                                                                                0, 0, item.transTime, 0, item.CloseClOrdID, item.CloseOrderID, item.OCOrder);
                    }
                }
                else
                {
                    ClsCommonMethods.ShowInformation("No open position is available to square off.");
                }
            }
            catch (Exception)
            {

            }
        }
    }

    public class order
    {
        public int accountId;
        public string clOrdId;
        public string ContractName;
        public sbyte Producttype;
        public string ProductName;
        public DateTime ExpiryDate;
        public string GatewayName;
        public sbyte Side;
        public double ordQty;
        public sbyte OrderType;
        public double Price;
        public double StopPX;
        public sbyte Tif;
        public double transTime;
        public string CloseClOrdID;
        public string CloseOrderID;
        public bool OCOrder;
    }
}
