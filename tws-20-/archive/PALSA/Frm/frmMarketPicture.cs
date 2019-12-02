///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//04/02/2012	VP		    1.Desgining of the form
//14/02/2012	VP		    1.Code for displaying ContractInformation in controls
//16/02/2012    Vk          1.Correction in adding in list of expirydate
//21 Jun 2014	Namo		Grid refresh method is commented
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.UserControls;
using TWS.Cls;
using TWS.DataSet;
using System.Reflection;

namespace TWS.Frm
{
    public partial class frmMarketPicture : frmBase
    {
        #region "        MEMBERS         "

        private static int count;
        private Dictionary<string, ClsDom> _DDDom = new Dictionary<string, ClsDom>();
        private DS4BuyDom _DS4BuyDom = new DS4BuyDom();
        private DS4SellDom _DS4SellDom = new DS4SellDom();
        private string _crtDomKey;
        private string _crtMarketPictureKey;
        private string _formkey;
        private string contractName;
        private DataGridViewRow _row;
        private int _rowBuyCount;
        private int _rowSellCount;
        #endregion "         MEMBERS         "

        #region "      CONSTRUCTOR       "

        public frmMarketPicture()
        {
            InitializeComponent();
            count += 1;
            _formkey = CommandIDS.MARKET_PICTURE.ToString() + "/" + Convert.ToString(count) + "/" + _crtMarketPictureKey;
        }

        #endregion "        CONSTRUCTOR         "

        #region "       PROPERTIES       "

        public override string Formkey
        {
            get { return _formkey; }
        }

        public override string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public static int Count
        {
            get { return count; }
        }

        #endregion "       PROPERTIES       "

        public void SetValuesToMarketPicture(DataGridViewRow row)
        {
            try
            {
                contractName = row.Cells["ClmContractName"].Value.ToString();
                this.Title = this.Title + "-" + contractName;
                GenerateGridColsRows();
                Action A = () =>
                {
                    uctlMarketPicture1.ui_uctlGridRight.Rows.Clear();
                    uctlMarketPicture1.ui_uctlGridLeft.Rows.Clear();


                    try
                    {
                        if (clsTWSDataManagerJSON.INSTANCE.DicDOM.ContainsKey(contractName))
                        {
                            List<uint> lstMarketLevel = new List<uint>();
                            foreach (var item in clsTWSDataManagerJSON.INSTANCE.DicDOM[contractName].Keys)
                            {
                                lstMarketLevel.Add(item);
                            }
                            lstMarketLevel.Sort();

                            foreach (var item in lstMarketLevel)
                            {
                                if (clsTWSDataManagerJSON.INSTANCE.DicDOM[contractName][item].BID > 0)
                                {
                                    uctlMarketPicture1.ui_uctlGridLeft.Rows.Add(contractName, clsTWSDataManagerJSON.INSTANCE.DicDOM[contractName][item].BID_SIZE, clsTWSDataManagerJSON.INSTANCE.DicDOM[contractName][item].BID);
                                }
                            }
                            foreach (var item in lstMarketLevel)
                            {
                                if (clsTWSDataManagerJSON.INSTANCE.DicDOM[contractName][item].ASK > 0)
                                {
                                    uctlMarketPicture1.ui_uctlGridRight.Rows.Add(contractName, clsTWSDataManagerJSON.INSTANCE.DicDOM[contractName][item].ASK, clsTWSDataManagerJSON.INSTANCE.DicDOM[contractName][item].ASK_SIZE);
                                }

                            }
                        }
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

                _crtMarketPictureKey = row.Cells["ClmInstrumentId"].Value.ToString();
                _crtDomKey = row.Cells["ClmInstrumentId"].Value.ToString();
                _formkey = CommandIDS.MARKET_PICTURE.ToString() + "/" + Convert.ToString(count) + "/" + _crtMarketPictureKey;

            }
            catch (Exception)
            {


            }
        }

        private void frmMarketPicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate -= INSTANCE_onSnapShotUpdate;
            count -= 1;
            _formkey = CommandIDS.MARKET_PICTURE.ToString() + "/" + Convert.ToString(count) + "/" + _crtMarketPictureKey;
        }

        private void frmMarketPicture_Load(object sender, EventArgs e)
        {
            Title = uctlMarketPicture1.Title;
            DoubleBuffered(uctlMarketPicture1.ui_uctlGridRight.ui_ndgvGrid, true);
            DoubleBuffered(uctlMarketPicture1.ui_uctlGridLeft.ui_ndgvGrid, true);
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate += INSTANCE_onSnapShotUpdate;

            uctlMarketPicture1.AddProductType(ClsTWSContractManager.INSTANCE.LstProductTypes);
            uctlMarketPicture1.ui_uctlGridRight.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uctlMarketPicture1.ui_uctlGridLeft.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _rowSellCount = uctlMarketPicture1.ui_uctlGridRight.Rows.Count;
            _rowBuyCount = uctlMarketPicture1.ui_uctlGridLeft.Rows.Count;
        }

        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        private void uctlMarketPicture1_OnProductTypeSelectedIndexChanged(string productType)
        {
            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Enter into uctlMarketPicture1_OnProductTypeSelectedIndexChanged Method");
            List<string> temp = new List<string>();
            foreach (var item in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType].Keys)
            {
                try
                {
                    temp.Add(item);
                }
                catch (Exception)
                {

                }

            }
            uctlMarketPicture1.AddProducts(temp);

            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Exit from uctlMarketPicture1_OnProductTypeSelectedIndexChanged Method");
        }

        public void FillExpiryDateData(string productType, string productName)
        {
            //FileHandling.WriteDevelopmentLog("MarketPicture" + count + " : Enter into FillExpiryDateData Method");

            var lstExpiry = new List<string>();
            List<string> contracts;
            var lstSymbol = new List<Symbol>();
            var lstSubscribeSymbol = new List<Symbol>();
            contracts =ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][productName];
            //contracts = ClsTWSContractManager.INSTANCE.ddContractDetails(productType, productName);

            foreach (string item in contracts)
            {
                InstrumentSpec instspec = null;
                //InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(item, productType, productName);
                if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(item))
                {
                    instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[item];
                }
                if (instspec != null)
                {
                    string expiryDate = clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(instspec.ExpiryDate);
                    lstExpiry.Add(expiryDate);
                    lstSymbol.Add(Symbol.GetSymbol(Symbol.getKey(instspec)[0]));
                }
            }
            if (lstSymbol.Count != 0)
            {
                lstSubscribeSymbol.Add(lstSymbol[0]);
                _crtDomKey = lstSymbol[0].KEY;
                _crtMarketPictureKey = lstSymbol[0].ProductType + "_" + lstSymbol[0].Product + "_" +
                                       lstSymbol[0].Contract + "_" + lstExpiry[0];
                _formkey = CommandIDS.MARKET_PICTURE.ToString() + "/" + Convert.ToString(count) + "/" +
                           _crtMarketPictureKey;
            }
            //clsTWSDataManagerJSON.INSTANCE.SubscribeForDom(true, eMarketRequest.MARKET_DEPTH, lstSubscribeSymbol);
            //clsTWSDataManagerJSON.INSTANCE.SubscribeForQuoteSnapShot(lstSubscribeSymbol);
            uctlMarketPicture1.AddExpiryDate(lstExpiry);

            //FileHandling.WriteDevelopmentLog("MarketPicture" + count + " : Exit from FillExpiryDateData Method");
        }

        private void INSTANCE_onSnapShotUpdate(Dictionary<string, QuoteSnapshot> obj)
        {
            //if (uctlMarketPicture1.ui_uctlGridRight.Columns.Count + uctlMarketPicture1.ui_uctlGridLeft.Columns.Count == 0)
            //{
            //    uctlMarketPicture1.AddColumnsToGrid();
            //}
            Action A = () =>
                           {
                               //GenerateGridColsRows();//Namo
                               foreach (var item in obj)
                               {
                                   uctlMarketPicture1.ui_lblLUTValue.Text =
                                       clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(Convert.ToString(item.Value.LastUpdatedTime));

                                   uctlMarketPicture1.ui_lblLTPValue.Text = item.Value.LastPrice.ToString();
                                   uctlMarketPicture1.ui_lblLTQValue.Text = item.Value.LastSize.ToString();
                                   uctlMarketPicture1.ui_lblLTTValue.Text = item.Value.LastTime.ToString();
                                   uctlMarketPicture1.ui_lblHighValue.Text = item.Value.High.ToString();
                                   uctlMarketPicture1.ui_lblLowValue.Text = item.Value.Low.ToString();
                                   uctlMarketPicture1.ui_lblVolumeValue.Text = item.Value.Volume.ToString();
                                   uctlMarketPicture1.ui_lblOpenValue.Text = item.Value.Open.ToString();
                                   uctlMarketPicture1.ui_lblCloseValue.Text = item.Value.Close.ToString();
                                   for (int i = 0; i < item.Value.MarketDepth.Count; i++)
                                   {
                                       MarketDepthItem item1 = item.Value.MarketDepth[i];
                                       //if (item1._Level == 5)
                                       //    continue;

                                       if (item.Key == _crtDomKey)
                                       {
                                           if (i == 0) //(item1._Level == 0)
                                           {
                                               if (item1.AskPrice == 0 && item1.AskSize == 0)
                                               {
                                                   foreach (
                                                       DataGridViewRow dgr in uctlMarketPicture1.ui_uctlGridRight.Rows)
                                                   {
                                                       dgr.Cells["ClmPrice"].Value = string.Empty;
                                                       dgr.Cells["ClmLots"].Value = string.Empty;
                                                   }
                                               }
                                               else
                                               {
                                                   uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmPrice"].Value =
                                                       item1.AskPrice;
                                                   uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmLots"].Value =
                                                       item1.AskSize;
                                               }
                                           }
                                           else
                                           {
                                               if (item1.AskPrice == 0 && item1.AskSize == 0)
                                               {
                                                   uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmPrice"].Value =
                                                       string.Empty;
                                                   uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmLots"].Value =
                                                       string.Empty;
                                               }
                                               else
                                               {
                                                   uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmPrice"].Value =
                                                       item1.AskPrice;
                                                   uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmLots"].Value =
                                                       item1.AskSize;
                                               }
                                           }

                                           //if (item1._AskPrice == 0 && item1._AskSize == 0)
                                           //{
                                           //    uctlMarketPicture1.ui_uctlGridRight.Rows[(int)item1._Level].Cells["ClmPrice"].Value = string.Empty;
                                           //    uctlMarketPicture1.ui_uctlGridRight.Rows[(int)item1._Level].Cells["ClmLots"].Value = string.Empty;
                                           //}
                                           //else
                                           //{
                                           //    uctlMarketPicture1.ui_uctlGridRight.Rows[(int)item1._Level].Cells["ClmPrice"].Value = item1._AskPrice;
                                           //    uctlMarketPicture1.ui_uctlGridRight.Rows[(int)item1._Level].Cells["ClmLots"].Value = item1._AskSize;
                                           //}
                                           if (i == 0) //(item1._Level == 0)
                                           {
                                               if (item1.BidPrice == 0 && item1.BidSize == 0)
                                               {
                                                   foreach (
                                                       DataGridViewRow dgr in uctlMarketPicture1.ui_uctlGridLeft.Rows)
                                                   {
                                                       dgr.Cells["ClmPrice"].Value = string.Empty;
                                                       dgr.Cells["ClmLots"].Value = string.Empty;
                                                   }
                                               }
                                               else
                                               {
                                                   uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmPrice"].Value =
                                                       item1.BidPrice;
                                                   uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmLots"].Value =
                                                       item1.BidSize;
                                               }
                                           }
                                           else
                                           {
                                               if (item1.BidPrice == 0 && item1.BidSize == 0)
                                               {
                                                   uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmLots"].Value =
                                                       string.Empty;
                                                   uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmPrice"].Value =
                                                       string.Empty;
                                               }
                                               else
                                               {
                                                   uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmLots"].Value =
                                                       item1.BidSize;
                                                   uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmPrice"].Value =
                                                       item1.BidPrice;
                                               }
                                           }
                                           //if (item1._BidPrice == 0 && item1._BidSize == 0)
                                           //{
                                           //    uctlMarketPicture1.ui_uctlGridLeft.Rows[(int)item1._Level].Cells["ClmPrice"].Value = string.Empty;
                                           //    uctlMarketPicture1.ui_uctlGridLeft.Rows[(int)item1._Level].Cells["ClmLots"].Value = string.Empty;
                                           //}
                                           //else
                                           //{
                                           //    uctlMarketPicture1.ui_uctlGridLeft.Rows[(int)item1._Level].Cells["ClmPrice"].Value = item1._BidPrice;
                                           //    uctlMarketPicture1.ui_uctlGridLeft.Rows[(int)item1._Level].Cells["ClmLots"].Value = item1._BidSize;
                                           //}
                                       }
                                   }
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

        private void GenerateGridColsRows()
        {
            var intCellStyle = new DataGridViewCellStyle();
            intCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (uctlMarketPicture1.ui_uctlGridRight.Rows.Count == 0)
            {
                uctlMarketPicture1.ui_uctlGridRight.Columns.Clear();
                uctlMarketPicture1.ui_uctlGridRight.AddColumn("ClmKey", "Key");
                uctlMarketPicture1.ui_uctlGridRight.AddColumn("ClmPrice", "Price");
                uctlMarketPicture1.ui_uctlGridRight.AddColumn("ClmLots", "Lots");
                uctlMarketPicture1.ui_uctlGridRight.AddColumn("ClmNoOfOrder", "NoOfOrder");
                //uctlMarketPicture1.ui_uctlGridRight.AddColumn("ClmMarketDepth", "Market Depth");
                int width = uctlMarketPicture1.ui_uctlGridRight.Width / 3;
                uctlMarketPicture1.ui_uctlGridRight.Columns[1].Width = width;
                uctlMarketPicture1.ui_uctlGridRight.Columns[2].Width = width;
                uctlMarketPicture1.ui_uctlGridRight.Columns[3].Width = width;
                //uctlMarketPicture1.ui_uctlGridRight.Columns[4].Width = width;
                uctlMarketPicture1.ui_uctlGridRight.Columns[1].DefaultCellStyle = intCellStyle;
                uctlMarketPicture1.ui_uctlGridRight.Columns[1].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                uctlMarketPicture1.ui_uctlGridRight.Columns[2].DefaultCellStyle = intCellStyle;
                uctlMarketPicture1.ui_uctlGridRight.Columns[3].DefaultCellStyle = intCellStyle;
                //uctlMarketPicture1.ui_uctlGridRight.Columns[4].DefaultCellStyle = intCellStyle;
                uctlMarketPicture1.ui_uctlGridRight.Columns[0].Visible = false;
                //uctlMarketPicture1.ui_uctlGridRight.Columns[3].Visible = false;

                uctlMarketPicture1.ui_uctlGridRight.Columns[1].DataPropertyName = "SellPrice";
                uctlMarketPicture1.ui_uctlGridRight.Columns[2].DataPropertyName = "SellQty";


                //for (int i = 0; i < 5; i++)
                //{
                //    uctlMarketPicture1.ui_uctlGridRight.Rows.Add();
                //}
            }
            if (uctlMarketPicture1.ui_uctlGridLeft.Rows.Count == 0)
            {
                uctlMarketPicture1.ui_uctlGridLeft.Columns.Clear();
                uctlMarketPicture1.ui_uctlGridLeft.AddColumn("ClmKey", "Key");
                //uctlMarketPicture1.ui_uctlGridLeft.AddColumn("ClmMarketDepth", "Market Depth");
                uctlMarketPicture1.ui_uctlGridLeft.AddColumn("ClmNoOfOrder", "NoOfOrder");
                uctlMarketPicture1.ui_uctlGridLeft.AddColumn("ClmLots", "Lots");
                uctlMarketPicture1.ui_uctlGridLeft.AddColumn("ClmPrice", "Price");
                int width = uctlMarketPicture1.ui_uctlGridLeft.Width / 3;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[1].Width = width;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[2].Width = width;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[3].Width = width;
                //uctlMarketPicture1.ui_uctlGridLeft.Columns[4].Width = width;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[1].DefaultCellStyle = intCellStyle;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[2].DefaultCellStyle = intCellStyle;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[3].DefaultCellStyle = intCellStyle;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[3].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                //uctlMarketPicture1.ui_uctlGridLeft.Columns[4].DefaultCellStyle = intCellStyle;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[0].Visible = false;
                //uctlMarketPicture1.ui_uctlGridLeft.Columns[2].Visible = false;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[2].DataPropertyName = "BuyQty";
                uctlMarketPicture1.ui_uctlGridLeft.Columns[3].DataPropertyName = "BuyPrice";

                //for (int i = 0; i < 5; i++)
                //{
                //    uctlMarketPicture1.ui_uctlGridLeft.Rows.Add();
                //}
            }
        }

        //private void INSTANCE_onPriceUpdate(Dictionary<string, Quote> obj)//Namo
        //{
        //   //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Enter into INSTANCE_onPriceUpdate Method");
        //    Action A = () =>
        //                   {
        //                       //GenerateGridColsRows();//Namo
        //                       var objclsDom = new ClsDom();
        //                       foreach (var item in obj)
        //                       {
        //                           foreach (QuoteItem item2 in item.Value._lstItem)
        //                           {
        //                               if (item2._MarketLevel == 5)
        //                                   continue;
        //                               if (item.Key == _crtDomKey)
        //                               {
        //                                   #region "   Commented Code   "

        //                                   //if (item2._MarketLevel == 0)
        //                                   //{
        //                                   //    switch (item2._quoteType)
        //                                   //    {
        //                                   //        case QuoteStreamType.HIGH:
        //                                   //            {
        //                                   //                uctlMarketPicture1.ui_lblHighValue.Text = item2._Price.ToString();
        //                                   //            }
        //                                   //            break;
        //                                   //        case QuoteStreamType.LAST:
        //                                   //            {
        //                                   //                uctlMarketPicture1.ui_lblLTPValue.Text = item2._Price.ToString();
        //                                   //                uctlMarketPicture1.ui_lblLTQValue.Text = item2._Size.ToString();
        //                                   //                if (Properties.Settings.Default.TimeFormat.Contains("24"))
        //                                   //                    uctlMarketPicture1.ui_lblLTTValue.Text = string.Format("{0:dd/MM/yyyy HH:mm:ss}", clsUtility.GetDateTime(item2._Time));
        //                                   //                else
        //                                   //                    uctlMarketPicture1.ui_lblLTTValue.Text = string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", clsUtility.GetDateTime(item2._Time));
        //                                   //                //uctlMarketPicture1.ui_lblLTTValue.Text =.ToString();
        //                                   //            }
        //                                   //            break;
        //                                   //        case QuoteStreamType.LOW:
        //                                   //            {
        //                                   //                uctlMarketPicture1.ui_lblLowValue.Text = item2._Price.ToString();
        //                                   //            }
        //                                   //            break;
        //                                   //        case QuoteStreamType.VOLUME:
        //                                   //            {
        //                                   //                uctlMarketPicture1.ui_lblVolumeValue.Text = item2._Size.ToString();
        //                                   //            }
        //                                   //            break;
        //                                   //    }
        //                                   //    continue;
        //                                   //}

        //                                   #endregion "   Commented Code   "                                           
        //                                   Symbol sym = Symbol.GetSymbol(item.Key);
        //                                   switch (item2._quoteType)
        //                                   {
        //                                       case QuoteStreamType.CLOSE:
        //                                           uctlMarketPicture1.ui_lblCloseValue.Text = item2._Price.ToString();
        //                                           objclsDom.ClosePrice = item2._Price;
        //                                           break;
        //                                       case QuoteStreamType.OPEN:
        //                                           uctlMarketPicture1.ui_lblOpenValue.Text = item2._Price.ToString();
        //                                           objclsDom.OpenPrice = item2._Price;
        //                                           break;
        //                                       case QuoteStreamType.ASK:
        //                                           {
        //                                               //if (item2._MarketLevel == 0)
        //                                               //{ 
        //                                               //    if(TWS.Cls.clsGlobal.DDRightZLevel.Keys.Contains(sym._ContractName))
        //                                               //    {
        //                                               //        TWS.Cls.clsGlobal.DDRightZLevel[sym._ContractName] = item2._Price;
        //                                               //    }
        //                                               //    else
        //                                               //    {
        //                                               //        TWS.Cls.clsGlobal.DDRightZLevel.Add(sym._ContractName, item2._Price);
        //                                               //    }
        //                                               //}

        //                                               if (item2._MarketLevel == 0)
        //                                               {
        //                                                   if (item2._Price == 0 && item2._Size == 0)
        //                                                   {
        //                                                       foreach (
        //                                                           DataGridViewRow dgr in
        //                                                               uctlMarketPicture1.ui_uctlGridRight.Rows)
        //                                                       {
        //                                                           dgr.Cells["ClmPrice"].Value = string.Empty;
        //                                                           dgr.Cells["ClmLots"].Value = string.Empty;                                                                  
        //                                                       }
        //                                                   }
        //                                                   else
        //                                                   {
        //                                                       uctlMarketPicture1.ui_uctlGridRight.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
        //                                                           ].Value = item2._Price;
        //                                                       uctlMarketPicture1.ui_uctlGridRight.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
        //                                                           .Value = item2._Size;                                                             
        //                                                   }
        //                                               }
        //                                               else
        //                                               {
        //                                                   if (item2._Price == 0 && item2._Size == 0)
        //                                                   {
        //                                                       uctlMarketPicture1.ui_uctlGridRight.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
        //                                                           ].Value = string.Empty;
        //                                                       uctlMarketPicture1.ui_uctlGridRight.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
        //                                                           .Value = string.Empty;                                                               
        //                                                   }
        //                                                   else
        //                                                   {
        //                                                       uctlMarketPicture1.ui_uctlGridRight.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
        //                                                           ].Value = item2._Price;
        //                                                       uctlMarketPicture1.ui_uctlGridRight.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
        //                                                           .Value = item2._Size;                                                               
        //                                                   }
        //                                               }
        //                                               uctlMarketPicture1.ui_lblLUTValue.Text = clsTWSOrderManagerJSON.INSTANCE.GetDateTime(item2._Time);
        //                                               //if (Properties.Settings.Default.TimeFormat.Contains("24"))
        //                                               //    uctlMarketPicture1.ui_lblLUTValue.Text =
        //                                               //        string.Format("{0:dd/MM/yyyy HH:mm:ss}",
        //                                               //                      clsUtility.GetDateTime(item2._Time));
        //                                               //else
        //                                               //    uctlMarketPicture1.ui_lblLUTValue.Text =
        //                                               //        string.Format("{0:dd/MM/yyyy hh:mm:ss tt}",
        //                                               //                      clsUtility.GetDateTime(item2._Time));


        //                                           }
        //                                           break;
        //                                       case QuoteStreamType.BID:
        //                                           {
        //                                               //if (item2._MarketLevel == 0)
        //                                               //{
        //                                               //    if (TWS.Cls.clsGlobal.DDLeftZLevel.Keys.Contains(sym._ContractName))
        //                                               //    {
        //                                               //        TWS.Cls.clsGlobal.DDLeftZLevel[sym._ContractName] = item2._Price;
        //                                               //    }
        //                                               //    else
        //                                               //    {
        //                                               //        TWS.Cls.clsGlobal.DDLeftZLevel.Add(sym._ContractName, item2._Price);
        //                                               //    }
        //                                               //}
        //                                               if (item2._MarketLevel == 0)
        //                                               {
        //                                                   if (item2._Price == 0 && item2._Size == 0)
        //                                                   {
        //                                                       foreach (
        //                                                           DataGridViewRow dgr in
        //                                                               uctlMarketPicture1.ui_uctlGridLeft.Rows)
        //                                                       {
        //                                                           dgr.Cells["ClmPrice"].Value = string.Empty;
        //                                                           dgr.Cells["ClmLots"].Value = string.Empty;                                                                  
        //                                                       }
        //                                                   }
        //                                                   else
        //                                                   {
        //                                                       uctlMarketPicture1.ui_uctlGridLeft.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
        //                                                           ].Value = item2._Price;
        //                                                       uctlMarketPicture1.ui_uctlGridLeft.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
        //                                                           .Value = item2._Size;
        //                                                                                                                  }
        //                                               }
        //                                               else
        //                                               {
        //                                                   if (item2._Price == 0 && item2._Size == 0)
        //                                                   {
        //                                                       uctlMarketPicture1.ui_uctlGridLeft.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
        //                                                           .Value = string.Empty;
        //                                                       uctlMarketPicture1.ui_uctlGridLeft.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
        //                                                           ].Value = string.Empty;                                                               
        //                                                   }
        //                                                   else
        //                                                   {
        //                                                       uctlMarketPicture1.ui_uctlGridLeft.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmLots"]
        //                                                           .Value = item2._Size;
        //                                                       uctlMarketPicture1.ui_uctlGridLeft.Rows[
        //                                                           Convert.ToInt32(item2._MarketLevel)].Cells["ClmPrice"
        //                                                           ].Value = item2._Price;
        //                                                                                                                 }
        //                                               }
        //                                               uctlMarketPicture1.ui_lblLUTValue.Text =clsTWSOrderManagerJSON.INSTANCE.GetDateTime(item2._Time);
        //                                               //if (Properties.Settings.Default.TimeFormat.Contains("24"))
        //                                               //    uctlMarketPicture1.ui_lblLUTValue.Text =
        //                                               //        string.Format("{0:dd/MM/yyyy HH:mm:ss}",
        //                                               //                      clsUtility.GetDateTime(item2._Time));
        //                                               //else
        //                                               //    uctlMarketPicture1.ui_lblLUTValue.Text =
        //                                               //        string.Format("{0:dd/MM/yyyy hh:mm:ss tt}",
        //                                               //                      clsUtility.GetDateTime(item2._Time));
        //                                           }
        //                                           break;
        //                                       case QuoteStreamType.HIGH:
        //                                           {
        //                                               uctlMarketPicture1.ui_lblHighValue.Text = item2._Price.ToString();
        //                                               objclsDom.HighPrice = item2._Price;
        //                                           }
        //                                           break;
        //                                       case QuoteStreamType.LAST:
        //                                           {
        //                                               uctlMarketPicture1.ui_lblLTPValue.Text = item2._Price.ToString();
        //                                               uctlMarketPicture1.ui_lblLTQValue.Text = item2._Size.ToString();
        //                                               uctlMarketPicture1.ui_lblLTTValue.Text = item2._Time.ToString();
        //                                           }
        //                                           break;
        //                                       case QuoteStreamType.LOW:
        //                                           {
        //                                               uctlMarketPicture1.ui_lblLowValue.Text = item2._Price.ToString();
        //                                               objclsDom.LowPrice = item2._Price;
        //                                           }
        //                                           break;
        //                                       case QuoteStreamType.VOLUME:
        //                                           {
        //                                               uctlMarketPicture1.ui_lblVolumeValue.Text =
        //                                                   item2._Size.ToString();
        //                                           }
        //                                           break;
        //                                       case QuoteStreamType.VOLUME_PER:
        //                                           break;
        //                                       default:
        //                                           break;
        //                                   }
        //                               }
        //                           }
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
        //   //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Exit from INSTANCE_onPriceUpdate Method");
        //}

        public void RefreshMe(UctlGrid grid)
        {
            //FileHandling.WriteDevelopmentLog("MarketPicture" + count + " : Enter into RefreshMe Method");

            Action A = () => { grid.Refresh(); };
            if (grid.InvokeRequired)
            {
                grid.BeginInvoke(A);
            }
            else
            {
                A();
            }

            //FileHandling.WriteDevelopmentLog("MarketPicture" + count + " : Exit from RefreshMe Method");
        }

        private void uctlMarketPicture1_OnProductSelectedIndexChanged(string productType, string productName)
        {
            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Enter into uctlMarketPicture1_OnProductSelectedIndexChanged Method");

            FillExpiryDateData(productType, productName);

            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Exit from uctlMarketPicture1_OnProductSelectedIndexChanged Method");
        }

        private void uctlMarketPicture1_OnProductTextChanged(string productType, string productName)
        {
            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Enter into uctlMarketPicture1_OnProductTextChanged Method");

            FillExpiryDateData(productType, productName);

            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Exit from uctlMarketPicture1_OnProductTextChanged Method");
        }

        private void uctlMarketPicture1_OnExpiryDateSelectedIndexChanged(string productType, string productName,
                                                                         string expiryDate)
        {
            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Enter into uctlMarketPicture1_OnExpiryDateSelectedIndexChanged Method");

            var lstSymbol = new List<Symbol>();
            List<string> contracts;
            //contracts = ClsTWSContractManager.INSTANCE.GetAllContracts(productType, productName);
            contracts = ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[productType][productName];
            foreach (string item in contracts)
            {
                InstrumentSpec instspec = null;
                //InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(item, productType, productName);
                if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(item))
                {
                    instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[item];
                }
                if (instspec != null)
                {
                    if (expiryDate == clsTWSOrderManagerJSON.INSTANCE.GetDateTimeFromString(instspec.ExpiryDate))
                    {
                        lstSymbol.Add(Symbol.GetSymbol(Symbol.getKey(instspec)[0]));
                        _crtMarketPictureKey = Symbol.GetSymbol(Symbol.getKey(instspec)[0]).ProductType + "_" +
                                               Symbol.GetSymbol(Symbol.getKey(instspec)[0]).Product + "_"
                                               + Symbol.GetSymbol(Symbol.getKey(instspec)[0]).Contract + "_" +
                                               expiryDate;
                        _crtDomKey = Symbol.GetSymbol(Symbol.getKey(instspec)[0]).KEY;
                        _formkey = CommandIDS.MARKET_PICTURE.ToString() + "/" + Convert.ToString(count) + "/" +
                                   _crtMarketPictureKey;

                        //clsTWSDataManagerJSON.INSTANCE.SubscribeForQuoteSnapShot(true,
                        //                                                     eMarketRequest.
                        //                                                         MARKET_QUOTE_SNAP, lstSymbol);
                        //clsTWSDataManagerJSON.INSTANCE.SubscribeForDom(true, eMarketRequest.MARKET_DEPTH,
                        //                                           lstSymbol);
                    }
                }
            }

            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Exit from uctlMarketPicture1_OnExpiryDateSelectedIndexChanged Method");
        }

        private void uctlMarketPicture1_Load(object sender, EventArgs e)
        {
        }

        public void SetValuesFromWorkSpace(string marketPictureKey, string expiryDate)
        {
            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Enter into SetValuesFromWorkSpace Method");

            if (marketPictureKey != string.Empty)
            {
                string[] str = marketPictureKey.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                uctlMarketPicture1.SetProductValues(str[0], str[1]);

                if (Properties.Settings.Default.TimeFormat.Contains("24"))
                    uctlMarketPicture1.SetExpiryDate(string.Format("{0:dd/MM/yyyy HH:mm:ss}", str[3] + "/" + expiryDate));
                else
                    uctlMarketPicture1.SetExpiryDate(string.Format("{0:dd/MM/yyyy hh:mm:ss tt}",
                                                                   str[3] + "/" + expiryDate));

                var lstSymbol = new List<Symbol>();

                InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[str[2]];

                lstSymbol.Add(Symbol.GetSymbol(Symbol.getKey(instspec)[0]));

                _crtMarketPictureKey = marketPictureKey;

                _crtDomKey = Symbol.GetSymbol(Symbol.getKey(instspec)[0]).KEY;

                _formkey = CommandIDS.MARKET_PICTURE.ToString() + "/" + Convert.ToString(count) + "/" +
                           _crtMarketPictureKey;

                //clsTWSDataManagerJSON.INSTANCE.SubscribeForDom(true, eMarketRequest.MARKET_DEPTH,
                //                                           lstSymbol);
                //clsTWSDataManagerJSON.INSTANCE.SubscribeForQuoteSnapShot(true,
                //                                                     eMarketRequest.
                //                                                         MARKET_QUOTE_SNAP, lstSymbol);
            }
            //FileHandling.WriteDevelopmentLog("MarketPicture" + count +" : Exit from SetValuesFromWorkSpace Method");
        }
    }
}