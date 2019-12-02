///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//21 Jun 2014	Namo		Grid refresh method is commented
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.UserControls;
using TWS.Cls;
using System.Reflection;

namespace TWS.Frm
{
    public partial class frmMarketPictureNew : frmBase
    {
        #region "        MEMBERS         "

        private static int count;
        private string _crtDomKey;
        private string _crtMarketPictureKey;
        private string _formkey;
        private string contractName;

        #endregion "         MEMBERS         "

        #region "      CONSTRUCTOR       "

        public frmMarketPictureNew()
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
                //_crtDomKey = row.Cells["ClmInstrumentId"].Value.ToString();
                _crtDomKey = contractName;

                _formkey = CommandIDS.MARKET_PICTURE.ToString() + "/" + Convert.ToString(count) + "/" + _crtMarketPictureKey;

            }
            catch (Exception)
            {

            }
        }

        private void frmMarketPicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate -= INSTANCE_onSnapShotUpdate;
            clsTWSDataManagerJSON.INSTANCE.onDOM_Update -= INSTANCE_onDOM_Update;
            count -= 1;
            _formkey = CommandIDS.MARKET_PICTURE.ToString() + "/" + Convert.ToString(count) + "/" + _crtMarketPictureKey;
        }

        private void frmMarketPicture_Load(object sender, EventArgs e)
        {
            Title = uctlMarketPicture1.Title;
            DoubleBuffered(uctlMarketPicture1.ui_uctlGridRight.ui_ndgvGrid, true);
            DoubleBuffered(uctlMarketPicture1.ui_uctlGridLeft.ui_ndgvGrid, true);
            clsTWSDataManagerJSON.INSTANCE.onSnapShotUpdate += INSTANCE_onSnapShotUpdate;
            clsTWSDataManagerJSON.INSTANCE.onDOM_Update -= INSTANCE_onDOM_Update;
            clsTWSDataManagerJSON.INSTANCE.onDOM_Update += INSTANCE_onDOM_Update;
            uctlMarketPicture1.ui_uctlGridRight.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            uctlMarketPicture1.ui_uctlGridLeft.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private void INSTANCE_onDOM_Update(string StreamType, string Symbol, Dictionary<uint, DOM> objDOM)
        {
            try
            {
                if (contractName == Symbol)
                {
                    Action A = () =>
                    {
                        uctlMarketPicture1.ui_uctlGridRight.Rows.Clear();
                        uctlMarketPicture1.ui_uctlGridLeft.Rows.Clear();
                        try
                        {
                            List<uint> lstMarketLevel = new List<uint>();
                            foreach (var item in objDOM.Keys)
                            {
                                lstMarketLevel.Add(item);
                            }
                            lstMarketLevel.Sort();

                            foreach (var item in lstMarketLevel)
                            {
                                if (objDOM[item].BID > 0)
                                {
                                    uctlMarketPicture1.ui_uctlGridLeft.Rows.Add(Symbol, objDOM[item].BID_SIZE, objDOM[item].BID);
                                }
                            }
                            foreach (var item in lstMarketLevel)
                            {
                                if (objDOM[item].ASK > 0)
                                {
                                    uctlMarketPicture1.ui_uctlGridRight.Rows.Add(Symbol, objDOM[item].ASK, objDOM[item].ASK_SIZE);
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
                }
            }
            catch (Exception)
            {
            }
        }

        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        private void INSTANCE_onSnapShotUpdate(SnapShot obj)
        {
            Action A = () =>
            {
                foreach (var item in obj.OHLC)
                {
                    try
                    {
                        if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(item.Contract))
                        {
                            InstrumentSpec spec = ClsTWSContractManager.INSTANCE.ddContractDetails[item.Contract];
                            for (int i = 0; i < item.MarketDepth.Count; i++)
                            {
                                MarketDepthItem item1 = item.MarketDepth[i];
                                
                                if (item.Contract == _crtDomKey)
                                {
                                    if (i == 0) //(item1._Level == 0)
                                    {
                                        if (item1.AskPrice == 0 && item1.AskSize == 0)
                                        {
                                            foreach (DataGridViewRow dgr in uctlMarketPicture1.ui_uctlGridRight.Rows)
                                            {
                                                dgr.Cells["ClmPrice"].Value = string.Empty;
                                                dgr.Cells["ClmLots"].Value = string.Empty;
                                            }
                                        }
                                        else
                                        {
                                            uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmPrice"].Value = item1.AskPrice / Math.Pow(10, spec.Digits);
                                            uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmLots"].Value = (int)(item1.AskSize / spec.ContractSize);
                                        }
                                    }
                                    else
                                    {
                                        if (item1.AskPrice == 0 && item1.AskSize == 0)
                                        {
                                            uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmPrice"].Value = string.Empty;
                                            uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmLots"].Value = string.Empty;
                                        }
                                        else
                                        {
                                            uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmPrice"].Value = item1.AskPrice / Math.Pow(10, spec.Digits);
                                            uctlMarketPicture1.ui_uctlGridRight.Rows[i].Cells["ClmLots"].Value = (int)(item1.AskSize / spec.ContractSize);
                                        }
                                    }

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
                                            uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmPrice"].Value = item1.BidPrice / Math.Pow(10, spec.Digits);
                                            uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmLots"].Value = (int)(item1.BidSize / spec.ContractSize);
                                        }
                                    }
                                    else
                                    {
                                        if (item1.BidPrice == 0 && item1.BidSize == 0)
                                        {
                                            uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmLots"].Value = string.Empty;
                                            uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmPrice"].Value = string.Empty;
                                        }
                                        else
                                        {
                                            uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmLots"].Value = (int)(item1.BidSize / spec.ContractSize);
                                            uctlMarketPicture1.ui_uctlGridLeft.Rows[i].Cells["ClmPrice"].Value = item1.BidPrice / Math.Pow(10, spec.Digits);
                                        }
                                    }
                                }
                            }
                        }                        
                    }
                    catch (Exception)
                    {

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
            if (uctlMarketPicture1.ui_uctlGridLeft.Rows.Count == 0)
            {
                uctlMarketPicture1.ui_uctlGridLeft.Columns.Clear();
                uctlMarketPicture1.ui_uctlGridLeft.AddColumn("ClmKey", "Key");
                uctlMarketPicture1.ui_uctlGridLeft.AddColumn("ClmLots", "Lots");
                uctlMarketPicture1.ui_uctlGridLeft.AddColumn("ClmPrice", "Price");
                uctlMarketPicture1.ui_uctlGridLeft.Columns[2].Width = 125;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[1].DefaultCellStyle = intCellStyle;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[2].DefaultCellStyle = intCellStyle;

                uctlMarketPicture1.ui_uctlGridLeft.Columns[2].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                uctlMarketPicture1.ui_uctlGridLeft.Columns[0].Visible = false;

            }
            if (uctlMarketPicture1.ui_uctlGridRight.Rows.Count == 0)
            {
                uctlMarketPicture1.ui_uctlGridRight.Columns.Clear();
                uctlMarketPicture1.ui_uctlGridRight.AddColumn("ClmKey", "Key");
                uctlMarketPicture1.ui_uctlGridRight.AddColumn("ClmPrice", "Price");
                uctlMarketPicture1.ui_uctlGridRight.AddColumn("ClmLots", "Lots");
                uctlMarketPicture1.ui_uctlGridRight.Columns[1].Width = 125;
                uctlMarketPicture1.ui_uctlGridRight.Columns[1].DefaultCellStyle = intCellStyle;
                uctlMarketPicture1.ui_uctlGridRight.Columns[1].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                uctlMarketPicture1.ui_uctlGridRight.Columns[2].DefaultCellStyle = intCellStyle;

                uctlMarketPicture1.ui_uctlGridRight.Columns[0].Visible = false;

            }

        }

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

        private void uctlMarketPicture1_Load(object sender, EventArgs e)
        {
        }

    }
}
