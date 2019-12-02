using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
//using Logging;
using PALSA.Cls;
using System.Drawing;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PALSA.Frm
{
    public partial class frmSurveillance : frmBase
    {
        private string _formkey;
        private object _objProfiles;
        private static int count;
        public static int Count
        {
            get { return count; }
        }

        public frmSurveillance()
        {
            InitializeComponent();

            count += 1;
            _formkey = CommandIDS.SURVEILLANCE.ToString() + "/" + Convert.ToString(Count);
        }

        public override string Formkey
        {
            get { return _formkey; }
        }


        private void frmSurveillance_FormClosed(object sender, FormClosedEventArgs e)
        {
            count -= 1;

            _formkey = CommandIDS.SURVEILLANCE.ToString() + "/" + Convert.ToString(Count);
            clsTWSOrderManagerJSON.INSTANCE.OnPositionResponse -= INSTANCE_OnPositionResponse;

        }

        //private void INSTANCE_DoHandleExecutionReport(ExecutionReport item)
        //{
        //    Action A = () =>
        //                   {
        //                       DataGridViewRow row = null;
                               
        //                       if (uctlSurveillance1._DDRows.TryGetValue(item.OrderID, out row))
        //                       {
        //                       }
        //                       string transactTime = string.Empty;
        //                       string expireTime = string.Empty;
        //                       transactTime = clsTWSOrderManagerJSON.INSTANCE.GetDateTime(item.TransactTime);
        //                       expireTime = clsTWSOrderManagerJSON.INSTANCE.GetDateTime(item.ExpireDate);

        //                       if (row == null)
        //                       {
        //                           uctlSurveillance1.ui_uctlGridSurveillance.Rows.Add(item.OrderID, item.Side,
        //                                                                              item.Contract, "", item.Price, "",
        //                                                                              "", "Cancel", "Close");
        //                       }
        //                       else
        //                       {
        //                           row.Cells["ClmOrderId"].Value = item.OrderID;
        //                           row.Cells["ClmSide"].Value = ClsGlobal.DDReverseSide[Convert.ToSByte(item.Side)];
        //                           row.Cells["ClmContract"].Value = item.Contract;
        //                           //row.Cells["ClmPosition"].Value =;
        //                           row.Cells["ClmPrice"].Value = item.Price;
        //                           //row.Cells["ClmCurrentPrice"].Value =;
        //                           //row.Cells["ClmProfitLoss"].Value =;
        //                           //row.Cells["ClmCancel"].Value =;
        //                           row.Cells["ClmExpiry"].Value = expireTime;
        //                       }
        //                   };
        //    if (InvokeRequired)
        //    {
        //        BeginInvoke(A);
        //    }
        //    else
        //    {
        //        A();
        //    }
        //}

        //private void INSTANCE_DoHandleTradeHistoryResponse(
        //    List<ExecutionReport> lstExecutionReport)
        //{
        //    foreach (ExecutionReport item in lstExecutionReport)
        //    {
        //        FileHandling.WriteInOutLog("Order Server : Trade History Respose Account" + item.Account + " Contract" + item.Contract);
        //        FileHandling.WriteAllLog("Order Server : Trade History Respose Account" + item.Account +  " Contract" + item.Contract);

        //        Action A = () =>
        //                       {
        //                           string transactTime = string.Empty;
        //                           string expireTime = string.Empty;
        //                           transactTime = clsTWSOrderManagerJSON.INSTANCE.GetDateTime(item.TransactTime);
        //                           expireTime = clsTWSOrderManagerJSON.INSTANCE.GetDateTime(item.ExpireDate);

        //                           int index = uctlSurveillance1.ui_uctlGridSurveillance.Rows.Add(item.OrderID,
        //                                                                                          item.Side,
        //                                                                                          item.Contract, "",
        //                                                                                          item.Price, "", "",
        //                                                                                          "Cancel", expireTime);
        //                           uctlSurveillance1._DDRows.Add(item.OrderID,
        //                                                         uctlSurveillance1.ui_uctlGridSurveillance.Rows[index]);
        //                       };
        //        if (InvokeRequired)
        //        {
        //            BeginInvoke(A);
        //        }
        //        else
        //        {
        //            A();
        //        }
        //    }
        //}

        //DataTable datatable =new DataTable();
        private void frmSurveillance_Load(object sender, EventArgs e)
        {
            uctlSurveillance1.AddSide(ClsGlobal.DDSide.Keys.ToArray());
            uctlSurveillance1.ui_uctlGridSurveillance.DataSource = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition;
            DoubleBuffered(uctlSurveillance1.ui_uctlGridSurveillance.ui_ndgvGrid, true);
            uctlSurveillance1.ui_uctlGridSurveillance.EnableCellCustomDraw = true;
            //clsTWSOrderManagerJSON.INSTANCE.OnPositionResponse -= INSTANCE_OnPositionResponse;
            //clsTWSOrderManagerJSON.INSTANCE.OnPositionResponse += INSTANCE_OnPositionResponse;
            uctlSurveillance1.ui_uctlGridSurveillance.ui_ndgvGrid.DataBindingComplete -= ui_ndgvGrid_DataBindingComplete;
            uctlSurveillance1.ui_uctlGridSurveillance.ui_ndgvGrid.DataBindingComplete +=ui_ndgvGrid_DataBindingComplete;
        }
        private void ui_ndgvGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //Action A = () =>
            //{
            if (System.Threading.Monitor.TryEnter(uctlSurveillance1.ui_uctlGridSurveillance, 1000))
            {
                try
                {
                    
                    uctlSurveillance1.ui_uctlGridSurveillance.EnableCellCustomDraw = true;
                    for (int i = 0; i < uctlSurveillance1.ui_uctlGridSurveillance.Rows.Count; i++)
                    {
                        int k = i;
                        if (uctlSurveillance1.ui_uctlGridSurveillance.Rows[k].Cells["clmColor"].Value != null)
                        {
                            var colorName = uctlSurveillance1.ui_uctlGridSurveillance.Rows[k].Cells["clmColor"].Value.ToString();
                            uctlSurveillance1.ui_uctlGridSurveillance.Rows[k].DefaultCellStyle.BackColor = Color.FromName(colorName);
                        }
                    }
                    uctlSurveillance1.ResumeLayout(true);
                }
                finally
                {
                    System.Threading.Monitor.Exit(uctlSurveillance1.ui_uctlGridSurveillance);
                }
            }
               
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

        private void INSTANCE_OnPositionResponse(List<Position> obj)
        {
            //FileHandling.WriteDevelopmentLog("Serveliance : Enter into INSTANCE_OnPositionResponse Method");
            Action a =
                () =>
                    {
                        uctlSurveillance1.ui_uctlGridSurveillance.DataSource =clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition;
                    };
            if (InvokeRequired)
            {
                BeginInvoke(a);
            }
            else
            {
                a();
            }
            //FileHandling.WriteDevelopmentLog("Serveliance : Exit from INSTANCE_OnPositionResponse Method");
        }

        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
            //FileHandling.WriteDevelopmentLog("Serveliance" + Count + " : Enter into DoubleBuffered Method");

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

            //FileHandling.WriteDevelopmentLog("Serveliance" + Count + " : Exit from DoubleBuffered Method");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Action A =
            //   () =>
            //   {
                   if(System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition,1000))
                   {
                       try{
                   for(int i=0;i < clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows.Count;i++)
                   {
                       //int index = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows.IndexOf(keyvalue.Value);
                       //left bid
                       //right ask
                       int k = i;
                       double askPrice = 0;
                       double bidPrice = 0;
                       string contract = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["Contract"].ToString();
                       string productType = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["ProductType"].ToString();
                       string productName = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["ProductName"].ToString();
                       int accNo = Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["AccountNo"].ToString());

                       bidPrice=ClsGlobal.GetZeroLevelBidPrice(contract);
                       askPrice = ClsGlobal.GetZeroLevelAskPrice(contract);
                       //InstrumentSpec inst =ClsTWSContractManager.INSTANCE.GetInstrumentSpecification(productType,contract, productName);
                        InstrumentSpec inst = ClsTWSContractManager.INSTANCE.ddContractDetails[contract];
                        int leverage = Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE._DDAccounts[accNo]["Leverage"].ToString());
                       int netqty = Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["NetQty"].ToString());
                       int buyQty = Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["BuyQty"].ToString());
                       int sellQty = Convert.ToInt32(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["sellQty"].ToString());
                       double buyAvg = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["BuyAvg"].ToString());
                       double sellAvg = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["SellAvg"].ToString());
                       if (buyQty > sellQty)
                       {
                           clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["UR_PL"] =
                               Math.Round(Math.Abs(netqty) * (bidPrice - buyAvg) * inst.ContractSize, 2);
                           clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["UsedMargin"] = (Math.Abs(netqty) *
                                              buyAvg * inst.InitialBuyMargin) /
                                              (100 * leverage);
                       }
                       else if (buyQty < sellQty)
                       {
                           clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["UR_PL"] =
                               Math.Round(Math.Abs(netqty) * (sellAvg - askPrice) * inst.ContractSize, 2);

                           clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["UsedMargin"] = (Math.Abs(netqty) *
                                               sellAvg * inst.InitialBuyMargin) /
                                               (100 * leverage);

                       }
                       else
                       {
                           clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["UR_PL"] = Math.Round(0d, 2);
                       }
                       double usedMargin = 0;
                       if (clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["UsedMargin"] != null && clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["UsedMargin"].ToString() != string.Empty)
                           usedMargin = Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["UsedMargin"].ToString());
                       
                       double marginLevel = 0;
                       string urpl = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["UR_PL"].ToString();

                       if (Convert.ToDouble(urpl) < 0)
                       {
                           marginLevel = Math.Abs((Convert.ToDouble(urpl)/usedMargin )* 100);
                           if (marginLevel > Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE._DDAccounts[accNo]["MarginCall1"].ToString()))
                               clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["Color"] = Color.Aquamarine.Name;
                           else if (marginLevel > Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE._DDAccounts[accNo]["MarginCall2"].ToString()))
                               clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["Color"] = Color.Yellow.Name;
                           else if (marginLevel > Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE._DDAccounts[accNo]["MarginCall3"].ToString()))
                               clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["Color"] = Color.Red.Name;
                           else
                               clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["Color"] = Color.White.Name;
                       }
                       else
                       {
                           clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Rows[k]["Color"] = Color.White.Name;
                       }

                       //if (marginLevel <= 320 && marginLevel > 240)
                       //    dr["Color"] = Color.Aquamarine.Name;
                       //else if (marginLevel <= 240 && marginLevel > 200)
                       //    dr["Color"] = Color.Yellow.Name;
                       //else if (marginLevel <= 200)
                           //dr["Color"] = Color.Red.Name;
                       //else
                       //    dr["Color"] = Color.White.Name;

                   }
                   clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.AcceptChanges();
                       }
                       finally
                       {
                           System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition);
                       }
                   }
            //   };
            //if (InvokeRequired)
            //{
            //    BeginInvoke(A);
            //}
            //else
            //{
            //    A();
            //}
        }

        private void uctlSurveillance1_OnProfileRemoveClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("Serveillance : Enter into uctlServeillance1_OnProfileRemoveClick Method");

            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);

            //FileHandling.WriteDevelopmentLog("Serveillance : Exit from uctlServeillance1_OnProfileRemoveClick Method");
        }

        private void uctlSurveillance1_OnProfileSaveClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("Serveillance : Enter into uctlServeillance1_OnProfileSaveClick Method");

            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            SaveProfile(profileName);

            //FileHandling.WriteDevelopmentLog("Serveillance : Exit from uctlServeillance1_OnProfileSaveClick Method");
        }

        private void uctlSurveillance1_OnSetDefaultProfileClick(object objProfiles, string profileName)
        {
            //FileHandling.WriteDevelopmentLog("Serveillance : Enter into uctlServeillance1_OnSetDefaultProfileClick Method");

            Properties.Settings.Default.ServeillanceDefaultProfile = profileName; //by vijay
            Properties.Settings.Default.Save(); //by vijay
            _objProfiles = objProfiles;
            ((FrmMain)MdiParent).Profiles = objProfiles;
            Properties.Settings.Default.ServeillanceDefaultProfile = profileName;
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

            //FileHandling.WriteDevelopmentLog("Serveillance : Exit from uctlServeillance1_OnSetDefaultProfileClick Method");
        }

        private void SaveProfile(string profileName)
        {
            //FileHandling.WriteDevelopmentLog("Serveillance : Enter into SaveProfile Method");

            string dirPath = Path.GetDirectoryName(ClsPalsaUtility.GetProfileFileName());
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            Stream streamWrite = File.Open(ClsPalsaUtility.GetProfileFileName(),
                                           FileMode.Create, FileAccess.Write);
            var binaryWrite = new BinaryFormatter();
            binaryWrite.Serialize(streamWrite, _objProfiles);
            uctlSurveillance1.CurrentProfileName = profileName;

            streamWrite.Close();

            //FileHandling.WriteDevelopmentLog("Serveillance : Exit from SaveProfile Method");
        }
    }
}