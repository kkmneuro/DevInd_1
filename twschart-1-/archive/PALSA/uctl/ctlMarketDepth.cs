using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;
using System.Collections;


namespace PALSA.uctl
{
    public partial class ctlMarketDepth : UctlBase//, IMsgDataReceived<object>
    {

        private string m_Symbol = string.Empty;
        //private delegate void BidUpdateDelegate(List<Order> orders, NDataGridView grid, List<Color> colors, Level2Type orderType);
        private delegate void TopUpdateDelegate(Instrument price);
        private delegate void UpdateCompressedTable();
        private delegate void RefreshSumDelegate();
        private delegate void UpdatePanelsDelegate();
        private delegate void UpdateGridColoursDelegate();

        private string m_NewSymbol = "New...";
        private Color m_DrawingBackColor = Color.Black;
        private Font m_TextFont = new Font("Time New Roman", 12);

        private FrmMain _MainForm;
        private string _CurrentSubscribedSymbol = "";
        private object m_lockAskGrid = new object();
        private object m_lockBidGrid = new object();
        private object m_lock = new object();

        private List<DepthByPrice> _Bids = new List<DepthByPrice>();
        private List<DepthByPrice> _Offers = new List<DepthByPrice>();
        private IEnumerable<BidOfferCrossRow> _BidOfferCrossRows;

        private Dictionary<int, DepthByPrice> dicBid = new Dictionary<int, DepthByPrice>();
        private Dictionary<int, DepthByPrice> dicAsk = new Dictionary<int, DepthByPrice>();
        private string _displayFormat;
        private const string DefaultNewSymbolText = "New...";
        private static readonly Color DefaultBackgroundColour = Color.Black;
        private static readonly Font DefaultScreenFont = new Font("Time New Roman", 12);
        private Color[] m_CellColors = new[] {
                    Color.LightCoral,
                    Color.LightGoldenrodYellow,
                    Color.LightPink,
                    Color.LightYellow,
                    Color.LightSeaGreen,
                    Color.LightBlue,
                    Color.LightGreen,
                    Color.LightCyan,
                    Color.LemonChiffon,
                    Color.LightGray,
                    Color.LightSalmon,
        };

        //Color.Yellow,
        //            Color.Green,
        //            Color.Blue,

        private MessageHandler<object> _MessageHandler;
        private BackgroundWorker _UnsubscribeThread;

        //private ctlData _DataManagerInstance;
        private string _CurrentlySubscribedSymbol = string.Empty;
        private Dictionary<int, OrderbookItem> dicMKTBID = new Dictionary<int, OrderbookItem>();
        private Dictionary<int, OrderbookItem> dicMKTASK = new Dictionary<int, OrderbookItem>();

        public string Symbol
        {
            get { return m_Symbol; }
            set
            {
                m_Symbol = value.ToUpper();
                //By KulChangeLevel2WatchSymbol(m_Symbol);
            }
        }

        string[] BANKS ={" Royal Bank of Scotland Group","Barclays","Deutsche","BNP Paribas","HSBC", "JP Morgan Chase","Credit Agricole", "Citigroup","Mitsubishi UFJ Financial", "ING Group","Bank of America", "UBS",
                               "Mizuho Financial", "Societe Generale","Banco Santander (1)", "UniCredit","Industrial and Commercial Bank of China (ICBC)", "Wells Fargo",
                               "China Construction Bank", "Sumitomo Mitsui Financial"};

        public ctlMarketDepth(FrmMain mainForm)
            : this(mainForm, string.Empty)
        {

        }

        public ctlMarketDepth(FrmMain mainForm, string InstrId)
        {
            InitializeComponent();
            _MainForm = mainForm;
            _MainForm.m_DockManager.DocumentManager.DocumentClosing += DocumentManager_DocumentClosing;
            

            dgvSymbol.Rows.Clear();
            dgvSymbol.Rows.Add();
            
            Symbol sym = Cls.Symbol.GetSymbol(InstrId);
            string initialSymbol = sym.Contract;

            if (!string.IsNullOrEmpty(initialSymbol))
            {
                _MessageHandler = new MessageHandler<object>("MarketDepth");
                _MessageHandler.MessageReceived += _MessageHandler_MessageReceived;
                _MessageHandler.Start();
                
                dgvSymbol.DataError += dgvSymbol_DataError;

                Symbol = initialSymbol;

                dgvSymbol.Rows[0].Cells[1].Value = imageList1.Images[2];
                dgvSymbol.Rows[0].Cells[0].Value = Symbol;
                dgvSymbol.CellMouseDoubleClick += dgvSymbol_CellMouseDoubleClick;
            }
        }


        internal void InitializeDepthFromGrid(DataGridViewRow obj)
        {
            if (obj.Cells["ClmBuyPrice"].Value == null)
                return;

            string symbol = obj.Cells["ClmContractName"].Value.ToString();
            string symbolId = obj.Cells["ClmInstrumentId"].Value.ToString();
            Symbol sym =Cls.Symbol.GetSymbol(symbolId);
            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[sym.Contract];
            string format = "0.";
            for (int digit = 0; digit < instspec.Digits; digit++)
            {
                format += "0";
            }
            _displayFormat = format;

            double BidPx = Convert.ToDouble(obj.Cells["ClmBuyPrice"].Value);
            double AskPx = Convert.ToDouble(obj.Cells["ClmSellPrice"].Value);//BuyQty
            long SIZE = Convert.ToInt64(obj.Cells["ClmBuyQty"].Value);

            Quote BID = CreateDummyData(symbol, BidPx, SIZE, QuoteStreamType.BID);
            Quote ASK = CreateDummyData(symbol, AskPx, SIZE, QuoteStreamType.ASK);

            Randomize(BANKS.ToList());

            List<DepthByPrice> BidDepth = GetDepth(symbol, sym.Gateway, BID, BANKS.ToList());
            List<DepthByPrice> AskDepth = GetDepth(symbol, sym.Gateway, ASK, BANKS.ToList());


            Orderbook_OrderbookInitializedEvent(BidDepth, AskDepth);
            //InitializeDepthLocal(BID, ASK, sym, symbolId, "OEC", BANKS.ToList());
            //Namo 21 March
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
            //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
        }

        void DocumentManager_DocumentClosing(object sender, DocumentCancelEventArgs e)
        {
            if (e.Document.Text == "Market Depth")
            {
                bool foundWindows = false;
                //if (null != _MainForm.m_ExternalWindow && _MainForm.m_ExternalWindow.Count > 0)
                //{
                //    for (int i = 0; i < _MainForm.m_ExternalWindow.Count; i++)
                //    {
                //        if (_MainForm.m_ExternalWindow[i].Tag == "Market Depth")
                //        {
                //            frmExternalChartWindow extWindow = (frmExternalChartWindow)_MainForm.m_ExternalWindow[i];
                //            extWindow.m_DockManager.DocumentManager.DocumentClosing += DocumentManager_DocumentClosing;

                //            foundWindows = true;
                //            break;
                //        }
                //    }
                //}
                if (!foundWindows)
                {
                    if (null != _MessageHandler)
                        _MessageHandler.Dispose();

                    _UnsubscribeThread = new BackgroundWorker();
                    _UnsubscribeThread.DoWork += _UnsubscribeThread_DoWork;
                    _UnsubscribeThread.RunWorkerAsync();
                }
            }
        }

        void _UnsubscribeThread_DoWork(object sender, DoWorkEventArgs e)
        {
            var matrixDoc = _MainForm.m_DockManager.DocumentManager.GetDocumentByText("Matrix");
            if (matrixDoc == null)
            {
                if (!string.IsNullOrEmpty(Symbol))
                {
                    //Namo 21 March
                    //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;

                }
            }
        }

        static Random _r = new Random();

      
        public Quote CreateDummyData(string sym, double price, long SIZE, QuoteStreamType QtType)
        {
            // foreach keyvalue pair you get item.value as Quote Object 
            // I am not getting so i have make
            Quote objQuote = new Quote();
            //Namo 21 March
            //// each objQuote contain List of QuoteItem
            //// I am not getting so i have made
            //objQuote._lstItem = new List<QuoteItem>();

            //// first object that you get as market level 0 from OnPriceUpdate
            //// I am making this object as i am not getting it from anywhere

            //QuoteItem objQuoteItem = new QuoteItem();
            //objQuoteItem._MarketLevel = 0;
            //objQuoteItem._Price = price;
            //objQuoteItem._quoteType = QtType;
            //if (SIZE == 0)
            //{
            //    int val = _r.Next(10, 40);
            //    SIZE = val;
            //}
            //objQuoteItem._Size = SIZE;
            //objQuoteItem._Time = Convert.ToString(DateTime.UtcNow);

            //objQuote._lstItem.Add(objQuoteItem);

            //string symbol = sym;// with the help of symbol in dictionary dic as key you can get digit value
            //int digits = 0;
            //if (symbol.Contains("JPY"))
            //    digits = 3;
            //else
            //    digits = 5;


            //// now using above object i will make 20 more values and save in above object
            //// only for BID and ASK
            //double _Price = price;
            //for (int i = 1; i < 20; i++)
            //{
            //    QuoteItem objQuoteItem1 = new QuoteItem();
            //    int val = _r.Next(10, 20);
            //    objQuoteItem1._MarketLevel = (uint)i;
            //    if (objQuoteItem._quoteType == QuoteStreamType.ASK)
            //    {
            //        objQuoteItem1._Price = _Price + (val / (Math.Pow(10, digits)));
            //    }
            //    if (objQuoteItem._quoteType == QuoteStreamType.BID)
            //    {
            //        objQuoteItem1._Price = _Price - (val / (Math.Pow(10, digits)));
            //    }
            //    _Price = objQuoteItem1._Price;
            //    objQuoteItem1._quoteType = QtType;
            //    objQuoteItem1._Size = Math.Abs(SIZE + val);//long.Parse(textBox3.Text.ToString()) + val;                           
            //    objQuoteItem1._Time = Convert.ToString(DateTime.UtcNow);
            //    objQuote._lstItem.Add(objQuoteItem1);
            //}
            return objQuote;
        }

        Random rng = new Random();
        public void Randomize(IList list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                if (swapIndex != i)
                {
                    object tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }

        #region Obsolete Methods

        //public void InitializeDepthLocal(Quote ListBid, Quote ListAsk, string Symb,string symbolId, string Exchange,List<string> lstBanks)
        //{
        //    List<DepthByPrice> DepthBid = new List<DepthByPrice>();
        //    List<DepthByPrice> DepthAsk = new List<DepthByPrice>();
        //    //Code by Vijay

        //    ClientDLL_Model.Cls.Contract.Symbol sym = ClientDLL_Model.Cls.Contract.Symbol.GetSymbol(symbolId);
        //    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(sym.Contract, sym.ProductType, sym.Product);
        //    string format = "0.";
        //    for (int digit = 0; digit < instspec.Digits; digit++)
        //    {
        //        format += "0";
        //    }
        //    _displayFormat = format;
        //    //End of code by vijay
        //    for (int i = 0; i < ListBid._lstItem.Count; i++)
        //    {
        //        DepthByPrice objDepthBid = new DepthByPrice(Symb, Exchange);
        //        OrderbookItem Ord = new OrderbookItem();

        //        objDepthBid.Symbol = Symb;
        //        objDepthBid.Volume = ListBid._lstItem[i]._Size;
        //        objDepthBid.Price =ListBid._lstItem[i]._Price;
        //        objDepthBid.MktLevel = (int)ListBid._lstItem[i]._MarketLevel;

        //        Ord.OriginalOrderCode = lstBanks[i];
        //        Ord.Price = ListBid._lstItem[i]._Price;
        //        Ord.Size = ListBid._lstItem[i]._Size;
        //        Ord.OrderDate = DateTime.UtcNow;//ClsGlobal.GetDateTimeDT(DepthBid[i]._BidTime);

        //        objDepthBid.Orders.Add(Ord);

        //        DepthBid.Add(objDepthBid);
        //    }

        //    for (int i = 0; i < ListAsk._lstItem.Count; i++)
        //    {
        //        DepthByPrice objDepthAsk = new DepthByPrice(Symb, Exchange);
        //        OrderbookItem Ord = new OrderbookItem();

        //        objDepthAsk.Symbol = Symb;
        //        objDepthAsk.Volume = ListAsk._lstItem[i]._Size;
        //        objDepthAsk.Price = ListAsk._lstItem[i]._Price;
        //        objDepthAsk.MktLevel = (int)ListAsk._lstItem[i]._MarketLevel;

        //        Ord.OriginalOrderCode = lstBanks[i];
        //        Ord.Price = ListAsk._lstItem[i]._Price;
        //        Ord.Size = ListAsk._lstItem[i]._Size;
        //        Ord.OrderDate = DateTime.UtcNow;//ClsGlobal.GetDateTimeDT(list[i]._AskTime);

        //        objDepthAsk.Orders.Add(Ord);
        //        DepthAsk.Add(objDepthAsk);
        //    }

        //    Orderbook_OrderbookInitializedEvent(DepthBid, DepthAsk);
        //    //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate -= marketWatch_onPriceUpdate;
        //    //clsTWSDataManagerJSON.INSTANCE.onPriceUpdate += marketWatch_onPriceUpdate;
        //}

        //public void OnDomInitialize(List<ClientDLL_Model.Cls.Market.MarketDepthItem> list, string Symb, string Exchange)// Kuldeep
        //{

        //    List<DepthByPrice> DepthBid = new List<DepthByPrice>();
        //    List<DepthByPrice> DepthAsk = new List<DepthByPrice>();

        //    int Bidk = list.Count;//Contract.DOM.BidLevels.Length;
        //    int AskK = list.Count;//Contract.DOM.AskLevels.Length;

        //    for (int i = 0; i < Bidk; i++)
        //    {
        //        DepthByPrice objDepthBid = new DepthByPrice(Symb, Exchange);
        //        OrderbookItem Ord = new OrderbookItem();

        //        objDepthBid.Symbol = Symb;
        //        objDepthBid.Volume = list[i]._BidSize;
        //        objDepthBid.Price = list[i]._BidPrice;
        //        objDepthBid.MktLevel = (int)list[i]._Level;

        //        Ord.OriginalOrderCode = "1";//(BidId + 1).ToString();//"5000";
        //        Ord.Price = list[i]._BidPrice;
        //        Ord.Size = list[i]._BidSize;
        //        Ord.OrderDate = ClsGlobal.GetDateTimeDT(list[i]._BidTime);

        //        objDepthBid.Orders.Add(Ord);

        //        DepthBid.Add(objDepthBid);
        //        //BidId++;
        //    }

        //    for (int i = 0; i < AskK; i++)
        //    {
        //        DepthByPrice objDepthAsk = new DepthByPrice(Symb, Exchange);
        //        OrderbookItem Ord = new OrderbookItem();

        //        objDepthAsk.Symbol = Symb;
        //        objDepthAsk.Volume = list[i]._AskSize;
        //        objDepthAsk.Price = list[i]._AskPrice;
        //        objDepthAsk.MktLevel = (int)list[i]._Level;

        //        Ord.OriginalOrderCode = "1";//(BidId + 1).ToString();//"5000";
        //        Ord.Price = list[i]._AskPrice;
        //        Ord.Size = list[i]._AskSize;
        //        Ord.OrderDate = ClsGlobal.GetDateTimeDT(list[i]._AskTime);

        //        objDepthAsk.Orders.Add(Ord);
        //        DepthAsk.Add(objDepthAsk);
        //        //AskId++;
        //    }
        //    Orderbook_OrderbookInitializedEvent(DepthBid, DepthAsk);
        //    //if (OrderbookInitializedEvent != null)
        //    //    OrderbookInitializedEvent(DepthBid, DepthAsk);
        //}

        #endregion

        void INSTANCE_onPriceUpdate(Dictionary<string, Quote> obj)
        {
            //Namo 21 March
            //foreach (var item in obj)
            //{
            //    Symbol sym = Symbol.GetSymbol(item.Key);

            //    if (sym.Contract == Symbol)
            //    {
            //        double val = 0;
            //        double BidPX = 0;
            //        double AskPX = 0;
            //        long Size = 0;

            //        //if (!clsTWSOrderManagerJSON.INSTANCE.IsDemo)
            //        {
            //            foreach (QuoteItem item2 in item.Value._lstItem)
            //            {
            //                switch (item2._quoteType)
            //                {
            //                    case QuoteStreamType.ASK:
            //                        {
            //                            Randomize(BANKS);
            //                            AskPX = item2._Price;
            //                            Size = item2._Size;

            //                            Quote AskQuotes = CreateDummyData(sym.Contract, AskPX, Size, QuoteStreamType.ASK);
            //                            List<DepthByPrice> AskDepth = GetDepth(Symbol, sym.Gateway, AskQuotes, BANKS.ToList());
            //                            EnqueueDepthByPriceChangedEvent(_Bids, AskDepth);
            //                        }
            //                        break;
            //                    case QuoteStreamType.BID:
            //                        {
            //                            Randomize(BANKS);
            //                            BidPX = item2._Price;
            //                            Size = item2._Size;
            //                            Quote Bidquotes = CreateDummyData(sym.Contract, BidPX, Size, QuoteStreamType.BID);
            //                            List<DepthByPrice> BidDepth = GetDepth(Symbol, sym.Gateway, Bidquotes, BANKS.ToList());
            //                            EnqueueDepthByPriceChangedEvent(BidDepth, _Offers);
            //                        }
            //                        break;
            //                    case QuoteStreamType.VOLUME:
            //                        {

            //                        }
            //                        break;
            //                    case QuoteStreamType.VOLUME_PER:
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //        }
            //        HandleQuotes(item.Value._lstItem);
                    
            //    }
            //}
        }
        private delegate void UpdateQuoteHandler(List<QuoteItem> quoteItem);
        private void HandleQuotes(List<QuoteItem> list)//By Kuldeep
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpdateQuoteHandler(HandleQuotes), list);
                return;
            }
            else
            {
                DataGridViewRow row = dgvSymbol.Rows[0];
                row.Cells[MarketDepthViewModel.SymbolTable.SYMBOL_COLUMN].Value = Symbol;
                double lastPrice = 0;

                foreach (QuoteItem quoteItem in list)
                {
                    switch (quoteItem._quoteType)
                    {
                        case QuoteStreamType.CLOSE:
                            {
                                row.Cells[MarketDepthViewModel.SymbolTable.CLOSE_COLUMN].Value = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(_displayFormat);
                            }
                            break;
                        case QuoteStreamType.OPEN:
                            {
                                row.Cells[MarketDepthViewModel.SymbolTable.OPEN_COLUMN].Value = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(_displayFormat);
                            }
                            break;
                        case QuoteStreamType.ASK:
                            {

                            }
                            break;
                        case QuoteStreamType.BID:
                            {
                                //row.Cells[MarketDepthViewModel.SymbolTable.B].Value = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(_displayFormat);
                            }
                            break;
                        case QuoteStreamType.HIGH:
                            {
                                row.Cells[MarketDepthViewModel.SymbolTable.HIGH_COLUMN].Value = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(_displayFormat);
                            }
                            break;
                        case QuoteStreamType.LAST:
                            {
                                if (row.Cells[MarketDepthViewModel.SymbolTable.LAST_COLUMN].Value != null && row.Cells[MarketDepthViewModel.SymbolTable.LAST_COLUMN].Value.ToString() != "")
                                {
                                    lastPrice = Convert.ToDouble(row.Cells[MarketDepthViewModel.SymbolTable.LAST_COLUMN].Value.ToString());
                                    if (lastPrice != quoteItem._Price)
                                    {
                                        if (lastPrice < quoteItem._Price)
                                            row.Cells[MarketDepthViewModel.SymbolTable.BID_TICK_COLUMN].Value = imageList1.Images[0];
                                        else
                                            row.Cells[MarketDepthViewModel.SymbolTable.BID_TICK_COLUMN].Value = imageList1.Images[1];
                                    }
                                }
                                else
                                {
                                    //if (instrument.LastTrade > instrument.YesterdayClose)
                                    //    row.Cells[MarketDepthViewModel.SymbolTable.BID_TICK_COLUMN].Value = imageList1.Images[0];
                                    //else
                                    //    row.Cells[MarketDepthViewModel.SymbolTable.BID_TICK_COLUMN].Value = imageList1.Images[1];
                                }
                                row.Cells[MarketDepthViewModel.SymbolTable.LAST_COLUMN].Value = quoteItem._Price;
                            }
                            break;
                        case QuoteStreamType.LOW:
                            {
                                row.Cells[MarketDepthViewModel.SymbolTable.LOW_COLUMN].Value = decimal.Round(Convert.ToDecimal(quoteItem._Price), 5).ToString(_displayFormat);
                            }
                            break;
                        case QuoteStreamType.VOLUME:
                            {
                                row.Cells[MarketDepthViewModel.SymbolTable.TRADE_SIZE_COLUMN].Value = quoteItem._Size;
                            }
                            break;
                        case QuoteStreamType.VOLUME_PER:
                            {
                            }
                            break;
                        default:
                            break;
                    }

                    //This is left
                    //row.Cells[MarketDepthViewModel.SymbolTable.NET_CHANGE_COLUMN].Value

                    dgvSymbol.Update();
                }
            }
        }

        private List<DepthByPrice> GetDepth(string Symb, string Exchange, Quote List, List<string> lstBanks)
        {
            List<DepthByPrice> Depth = new List<DepthByPrice>();
            //Namo 21 March
            //for (int i = 0; i < List._lstItem.Count; i++)
            //{
            //    DepthByPrice objDepth = new DepthByPrice(Symb, Exchange);
            //    OrderbookItem Ord = new OrderbookItem();

            //    objDepth.Symbol = Symb;
            //    objDepth.Volume = List._lstItem[i]._Size;
            //    objDepth.Price = List._lstItem[i]._Price;
            //    objDepth.MktLevel = (int)List._lstItem[i]._MarketLevel;

            //    Ord.OriginalOrderCode = lstBanks[i];
            //    Ord.Price = List._lstItem[i]._Price;
            //    Ord.Size = List._lstItem[i]._Size;
            //    Ord.OrderDate = DateTime.UtcNow;//ClsGlobal.GetDateTimeDT(DepthBid[i]._BidTime);

            //    objDepth.Orders.Add(Ord);

            //    Depth.Add(objDepth);
            //}
            return Depth;
        }

        #region OLD Method
        public Dictionary<string, Instrument> DDInstruments = new Dictionary<string, Instrument>();
        //private void OnPriceFeed(Symbol sym, List<QuoteItem> list)
        //{
        //    foreach (QuoteItem item2 in list)
        //    {
        //        if (!DDInstruments.Keys.Contains(sym.Contract))
        //        {
        //            Instrument Inst = new Instrument();
        //            Inst.Symbol = sym.Contract;
        //            Inst.Exchange = sym.Gateway;
        //            Inst.CompanyShortName = sym.Contract;
        //            Inst.CompanyLongName = sym.Contract;
        //            Inst.TotalTrades = 0;
        //            switch (item2._quoteType)
        //            {
        //                case QuoteStreamType.ASK:
        //                    {
        //                        if (ClsGlobal.DDRightZLevel.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDRightZLevel[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDRightZLevel.Add(sym.Contract, item2._Price);
        //                        }
        //                        Inst.BestOffer = item2._Price;
        //                        Inst.OfferVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.BID:
        //                    {
        //                        if (ClsGlobal.DDLeftZLevel.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDLeftZLevel[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDLeftZLevel.Add(sym.Contract, item2._Price);
        //                        }

        //                        Inst.BestBid = item2._Price;
        //                        Inst.BidVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.HIGH:
        //                    {
        //                        Inst.High = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.LOW:
        //                    {
        //                        Inst.Low = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.OPEN:
        //                    {
        //                        Inst.Open = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.CLOSE:
        //                    {
        //                        Inst.YesterdayClose = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.VOLUME:
        //                    {
        //                        if (ClsGlobal.DDTotalValue.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalValue[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalValue.Add(sym.Contract, item2._Price);
        //                        }
        //                        if (ClsGlobal.DDTotalVolume.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalVolume[sym.Contract] = item2._Size;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalVolume.Add(sym.Contract, item2._Size);
        //                        }
        //                        Inst.TotalValue = item2._Price;
        //                        Inst.TotalVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.LAST:
        //                    {
        //                        if (ClsGlobal.DDLTP.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDLTP[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDLTP.Add(sym.Contract, item2._Price);
        //                        }
        //                        if (ClsGlobal.DDTotalVolume.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalVolume[sym.Contract] = item2._Size;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalVolume.Add(sym.Contract, item2._Size);
        //                        }
        //                        Inst.LastTradeTime = DateTime.UtcNow;
        //                        Inst.LastTrade = item2._Price;
        //                        Inst.TotalVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.VOLUME_PER:
        //                    {
        //                        Inst.PercentageMoved = item2._Price;
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }

        //            DDInstruments.Add(sym.Contract, Inst);
        //        }
        //        else
        //        {
        //            switch (item2._quoteType)
        //            {
        //                case QuoteStreamType.ASK:
        //                    {
        //                        if (ClsGlobal.DDRightZLevel.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDRightZLevel[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDRightZLevel.Add(sym.Contract, item2._Price);
        //                        }
        //                        DDInstruments[sym.Contract].BestOffer = item2._Price;
        //                        DDInstruments[sym.Contract].OfferVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.BID:
        //                    {
        //                        if (ClsGlobal.DDLeftZLevel.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDLeftZLevel[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDLeftZLevel.Add(sym.Contract, item2._Price);
        //                        }

        //                        DDInstruments[sym.Contract].BestBid = item2._Price;
        //                        DDInstruments[sym.Contract].BidVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.HIGH:
        //                    {
        //                        DDInstruments[sym.Contract].High = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.LOW:
        //                    {
        //                        DDInstruments[sym.Contract].Low = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.OPEN:
        //                    {
        //                        DDInstruments[sym.Contract].Open = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.CLOSE:
        //                    {
        //                        DDInstruments[sym.Contract].YesterdayClose = item2._Price;
        //                    }
        //                    break;
        //                case QuoteStreamType.VOLUME:
        //                    {
        //                        if (ClsGlobal.DDTotalValue.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalValue[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalValue.Add(sym.Contract, item2._Price);
        //                        }
        //                        if (ClsGlobal.DDTotalVolume.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDTotalVolume[sym.Contract] = item2._Size;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDTotalVolume.Add(sym.Contract, item2._Size);
        //                        }
        //                        DDInstruments[sym.Contract].TotalValue = item2._Price;
        //                        DDInstruments[sym.Contract].TotalVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.LAST:
        //                    {
        //                        if (ClsGlobal.DDLTP.Keys.Contains(sym.Contract))
        //                        {
        //                            ClsGlobal.DDLTP[sym.Contract] = item2._Price;
        //                        }
        //                        else
        //                        {
        //                            ClsGlobal.DDLTP.Add(sym.Contract, item2._Price);
        //                        }
        //                        DDInstruments[sym.Contract].LastTradeTime = DateTime.UtcNow;
        //                        DDInstruments[sym.Contract].LastTrade = item2._Price;
        //                        DDInstruments[sym.Contract].TotalVolume = item2._Size;
        //                    }
        //                    break;
        //                case QuoteStreamType.VOLUME_PER:
        //                    {
        //                        DDInstruments[sym.Contract].PercentageMoved = item2._Price;
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }

        //        }
        //        _Repository_InstrumentUpdatedEvent(DDInstruments[sym.Contract]);//BroadCast quotes here
        //    }
        //}
        #endregion

        private void ProcessInstrument(Instrument instrument)
        {
            UpdateInstrumentTable(instrument);
        }

        private void EnqueueDepthByPriceChangedEvent(List<DepthByPrice> bids, List<DepthByPrice> offers)
        {
            DepthByPriceMDEvent newEvent = new DepthByPriceMDEvent();
            newEvent.Bids = bids;
            newEvent.Offers = offers;
            _MessageHandler.AddMessage(newEvent);
        }

        private void ProcessOrderbookInitEvent(List<DepthByPrice> bids, List<DepthByPrice> offers)
        {
            int bidCount = bids.SelectMany(bid => bid.Orders).Count();
            int offerCount = offers.SelectMany(offer => offer.Orders).Count();
            dgvBid.Rows.Clear();
            dgvAsk.Rows.Clear();

            dgvBid.RowCount = 20;

            dgvAsk.RowCount = 20;

            dgvBid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAsk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            EnqueueDepthByPriceChangedEvent(bids, offers);
            dgvAsk.Refresh();
            dgvBid.Refresh();
        }

        private void ProcessOrderbookAdd(OrderbookItem order)
        {
            if (order.Side == OrderSide.Sell)
            {
                dgvAsk.RowCount++;
            }
            else
            {
                dgvBid.RowCount++;
            }
        }

        private void ProcessOrderbookUpdate(OrderbookItem order)
        {
            if (order.Side == OrderSide.Sell)
            {
                dgvAsk.Refresh();
            }
            else
            {
                dgvBid.Refresh();
            }
        }

        private void ProcessOrderbookDelete(OrderbookItem order)
        {
            if (order.Side == OrderSide.Sell)
            {
                if (dgvAsk.RowCount > 0)
                    dgvAsk.RowCount--;
            }
            else
            {
                if (dgvBid.RowCount > 0)
                    dgvBid.RowCount--;
            }
        }

        private void ProcessDepthByPriceChanged(List<DepthByPrice> bids, List<DepthByPrice> offers)
        {
            try
            {
                lock (m_lock)
                {
                    //By Kuldeep
                    //foreach (var item in bids)
                    //{
                    //    if (!dicBid.ContainsKey(item.MktLevel))
                    //    {
                    //        dicBid.Add(item.MktLevel, item);
                    //    }
                    //    else
                    //    {
                    //        dicBid[item.MktLevel] = item;
                    //    }
                    //}
                    //foreach (var item in offers)
                    //{
                    //    if (!dicAsk.ContainsKey(item.MktLevel))
                    //    {
                    //        dicAsk.Add(item.MktLevel, item);
                    //    }
                    //    else
                    //    {
                    //        dicAsk[item.MktLevel] = item;
                    //    }
                    //}

                    //Kuldeep
                    _Bids = bids;
                    _Offers = offers;
                    _BidOfferCrossRows = CreateBidOfferCrossRowsFrom(bids, offers);

                    dgvBidOfferCross.RowCount = _BidOfferCrossRows.Count();
                }
                RefreshPanels();
                RefreshBarGraph();

                dgvAsk.Refresh();
                dgvBid.Refresh();
                dgvBidOfferCross.Refresh();
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("MarketDepth Error:{0}", exception.ToString()));
            }
        }

        private IEnumerable<BidOfferCrossRow> CreateBidOfferCrossRowsFrom(List<DepthByPrice> bids, List<DepthByPrice> offers)
        {
            int numberOfRows = bids.Count;
            if (offers.Count < numberOfRows)
                numberOfRows = offers.Count;

            List<BidOfferCrossRow> rows = new List<BidOfferCrossRow>();
            for (int i = 0; i < numberOfRows; i++)
            {
                rows.Add(BidOfferCrossRow.CreateFrom(bids[i], offers[i], m_CellColors[i % m_CellColors.Length], _displayFormat));
            }
            return rows;
        }

        private void ChangeLevel2WatchSymbol(string symbol)
        {
            //_MainForm.ShowStatus(string.Format("Market Depth: Adding level 2 watch for symbol: {0}", symbol));
            bool init = false;
            try
            {

                if (_MessageHandler != null)
                    _MessageHandler.Dispose();

                _MessageHandler = new MessageHandler<object>("MarketDepth");
                _MessageHandler.MessageReceived += _MessageHandler_MessageReceived;
                _MessageHandler.Start();
                _CurrentlySubscribedSymbol = symbol;

                ResetBidAndOfferGrids();
                UpdateSymbol();
                //SubscribeLevel2WatchMDE(symbol);
            }
            catch (Exception dex)
            {
                Utils.DisplayError(dex.Message);
            }
            //_MainForm.ShowStatus("Connected");
        }

        private void UpdateSymbol()
        {
            try
            {
                try
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new UpdateCompressedTable(UpdateSymbol));
                        return;
                    }

                    if ((dgvSymbol.Rows[0].Cells[0] as DataGridViewComboBoxCell) != null)
                    {
                        if (!(dgvSymbol.Rows[0].Cells[0] as DataGridViewComboBoxCell).Items.Contains(DefaultNewSymbolText))
                        {
                            (dgvSymbol.Rows[0].Cells[0] as DataGridViewComboBoxCell).Items.Add(DefaultNewSymbolText);

                            if (!(dgvSymbol.Rows[0].Cells[0] as DataGridViewComboBoxCell).Items.Contains(Symbol))
                            {
                                (dgvSymbol.Rows[0].Cells[0] as DataGridViewComboBoxCell).Items.Add(Symbol);
                                (dgvSymbol.Rows[0].Cells[0] as DataGridViewComboBoxCell).Selected = true;

                                dgvSymbol.Rows[0].Cells[0].Value = Symbol;

                                dgvSymbol.Rows[0].Cells[1].Value = imageList1.Images[2];
                                for (int i = 2; i < dgvSymbol.ColumnCount - 1; i++)
                                {
                                    dgvSymbol.Rows[0].Cells[i].Value = string.Empty;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //ErrorService.LogError("ctlMarketDepth", "UpdateSymbol", ex.ToString());
                }

                RefreshBarGraph();

                RefreshPanels();
                dgvSymbol.Update();
                dgvSymbol.Refresh();
            }
            catch (Exception ex)
            {
                //ErrorService.LogError("ctlMarketDepth", "UpdateSymbol", ex.ToString());
            }
        }

        private void ResetBidAndOfferGrids()
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new UpdatePanelsDelegate(ResetBidAndOfferGrids));
            else
            {
                lock (m_lockBidGrid)
                {
                    dgvBid.Rows.Clear();
                }
                lock (m_lockAskGrid)
                {
                    dgvAsk.Rows.Clear();
                }
                dgvBidOfferCross.Rows.Clear();
            }
        }

        private void RefreshPanels()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdatePanelsDelegate(RefreshPanels));
            }
            else
            {
                NumberOfShares.Panel1.Refresh();
                NumberOfShares.Panel2.Refresh();
            }
        }

        private void UpdateInstrumentTable(Instrument instrument)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new TopUpdateDelegate(UpdateInstrumentTable), instrument);
                return;
            }

            try
            {
                DataGridViewRow row = dgvSymbol.Rows[0];

                row.Cells[MarketDepthViewModel.SymbolTable.SYMBOL_COLUMN].Value = instrument.Symbol;
                double lastPrice = 0;
                if (instrument.LastTrade != 0)
                {
                    if (row.Cells[MarketDepthViewModel.SymbolTable.LAST_COLUMN].Value != null && row.Cells[MarketDepthViewModel.SymbolTable.LAST_COLUMN].Value.ToString() != "")
                    {
                        lastPrice = Convert.ToDouble(row.Cells[MarketDepthViewModel.SymbolTable.LAST_COLUMN].Value.ToString());
                        if (lastPrice != instrument.LastTrade)
                        {
                            if (lastPrice < instrument.LastTrade)
                                row.Cells[MarketDepthViewModel.SymbolTable.BID_TICK_COLUMN].Value = imageList1.Images[0];
                            else
                                row.Cells[MarketDepthViewModel.SymbolTable.BID_TICK_COLUMN].Value = imageList1.Images[1];
                        }
                    }
                    else
                    {
                        if (instrument.LastTrade > instrument.YesterdayClose)
                            row.Cells[MarketDepthViewModel.SymbolTable.BID_TICK_COLUMN].Value = imageList1.Images[0];
                        else
                            row.Cells[MarketDepthViewModel.SymbolTable.BID_TICK_COLUMN].Value = imageList1.Images[1];
                    }
                    row.Cells[MarketDepthViewModel.SymbolTable.LAST_COLUMN].Value = instrument.LastTrade;
                }
                if (instrument.PercentageMoved != 0)
                    row.Cells[MarketDepthViewModel.SymbolTable.NET_CHANGE_COLUMN].Value = Math.Round(instrument.PercentageMoved, 2);
                if (instrument.YesterdayClose != 0)
                    row.Cells[MarketDepthViewModel.SymbolTable.CLOSE_COLUMN].Value = instrument.YesterdayClose;
                if (instrument.Open != 0)
                    row.Cells[MarketDepthViewModel.SymbolTable.OPEN_COLUMN].Value = instrument.Open;
                if (instrument.High != 0)
                    row.Cells[MarketDepthViewModel.SymbolTable.HIGH_COLUMN].Value = instrument.High;
                if (instrument.Low != 0)
                    row.Cells[MarketDepthViewModel.SymbolTable.LOW_COLUMN].Value = instrument.Low;
                if (instrument.TotalVolume > 0)
                    row.Cells[MarketDepthViewModel.SymbolTable.TRADE_SIZE_COLUMN].Value = instrument.TotalVolume;

                dgvSymbol.Update();
            }
            catch (Exception ex)
            {
                //_ErrorService.LogError("ctlMarketDepth (UpdateInstrumentTable)", ex);
            }
        }

        private void RefreshBarGraph()//Changed By Kuldeep
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new RefreshSumDelegate(RefreshBarGraph));
                return;
            }

            clMarketDepthGraph.Ask = _Offers.Count;//_Offers.Sum(o => o.Orders.Count);
            clMarketDepthGraph.AskSize = _Offers.Sum(b => b.Volume);
            clMarketDepthGraph.Bid = _Bids.Count;//_Bids.Sum(b => b.Orders.Count);
            clMarketDepthGraph.BidSize = _Bids.Sum(b => b.Volume);
            clMarketDepthGraph.Refresh();
        }

        private void UpdateBidOfferCrossRowColour(int rowIndex)
        {
            BidOfferCrossRow correspondingCross = _BidOfferCrossRows.ElementAt(rowIndex);
            if (null != correspondingCross && dgvBidOfferCross.RowCount > rowIndex)
            {
                if (dgvBidOfferCross.Rows[rowIndex].DefaultCellStyle.BackColor != correspondingCross.Color)
                {
                    dgvBidOfferCross.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = correspondingCross.Color;
                    dgvBidOfferCross.Rows[rowIndex].DefaultCellStyle.BackColor = correspondingCross.Color;
                }
            }

        }

        private void UpdateOfferRowColour(int rowIndex, OrderbookItem orderBookItem)
        {

            BidOfferCrossRow correspondingCross = _BidOfferCrossRows.FirstOrDefault(cross => cross.OfferPrice.Equals(orderBookItem.Price));
            if (null != correspondingCross && dgvAsk.RowCount > rowIndex)
            {
                if (dgvAsk.Rows[rowIndex].DefaultCellStyle.BackColor != correspondingCross.Color)
                {
                    dgvAsk.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = correspondingCross.Color;
                    dgvAsk.Rows[rowIndex].DefaultCellStyle.BackColor = correspondingCross.Color;
                }
            }
        }

        private void UpdateBidRowColour(int rowIndex, OrderbookItem orderBookItem)
        {
            BidOfferCrossRow correspondingCross = _BidOfferCrossRows.FirstOrDefault(cross => cross.BidPrice.Equals(orderBookItem.Price));
            if (null != correspondingCross && dgvBid.RowCount > rowIndex)
            {
                //lock (m_lockBidGrid)
                //{
                if (dgvBid.Rows[rowIndex].DefaultCellStyle.BackColor != correspondingCross.Color)
                {
                    dgvBid.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = correspondingCross.Color;
                    dgvBid.Rows[rowIndex].DefaultCellStyle.BackColor = correspondingCross.Color;
                }
                //}

            }
        }

        private void clMarketDepthGraph_Resize(object sender, EventArgs e)
        {
            RefreshBarGraph();
        }

        private void NumberOfShares_Panel1_Paint(object sender, PaintEventArgs e)
        {
            lock (m_lock)
            {
                //if (_Bids.Count == 0) return;
                if (_Bids.Count == 0) return;
                int weight = NumberOfShares.Panel1.Width / _Bids.Count;
                long maxVolume = (from o in _Bids
                                  select o.Volume).Max();

                double height = (double)NumberOfShares.Panel1.Height / maxVolume;
                int x = NumberOfShares.Panel1.Width;

                e.Graphics.FillRectangle(new SolidBrush(DefaultBackgroundColour), 0, 0, NumberOfShares.Panel1.Width, NumberOfShares.Panel1.Height);
                for (int i = 0; i < _Bids.Count; i++)
                {
                    Color color = m_CellColors[i % m_CellColors.Length];
                    e.Graphics.FillRectangle(new SolidBrush(color), new Rectangle(x - weight, 0, weight, (int)(_Bids[i].Volume * height)));
                    x -= weight;
                }
                SizeF size = e.Graphics.MeasureString("BIDS", DefaultScreenFont);
                e.Graphics.DrawString("BIDS", DefaultScreenFont, new SolidBrush(Color.DarkBlue), 0 + 10, NumberOfShares.Panel1.Height - size.Height - 10);
            }
        }

        private void NumberOfShares_Panel2_Paint(object sender, PaintEventArgs e)
        {
            lock (m_lock)
            {
                if (_Offers.Count == 0) return;
                //if (dicAsk.Count == 0) return;
                int weight = NumberOfShares.Panel2.Width / _Offers.Count;
                long maxVolume = (from o in _Offers
                                  select o.Volume).Max();

                double height = (double)NumberOfShares.Panel2.Height / maxVolume;
                int x = 0;

                e.Graphics.FillRectangle(new SolidBrush(DefaultBackgroundColour), 0, 0, NumberOfShares.Panel2.Width, NumberOfShares.Panel2.Height);
                for (int i = 0; i < _Offers.Count; i++)
                {
                    Color color = m_CellColors[i % m_CellColors.Length];
                    e.Graphics.FillRectangle(new SolidBrush(color), new Rectangle(x, 0, weight, (int)(_Offers[i].Volume * height)));
                    x += weight;
                }
                SizeF size = e.Graphics.MeasureString("OFFERS", DefaultScreenFont);
                e.Graphics.DrawString("OFFERS", DefaultScreenFont, new SolidBrush(Color.DarkBlue), NumberOfShares.Panel2.Width - size.Width - 10, NumberOfShares.Panel2.Height - size.Height - 10);
            }
        }

        void dgvSymbol_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //_ErrorService.LogError("ctlMarketDepth (dgvSymbol_DataError)", e.Exception);
        }

        void dgvSymbol_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //By Kul
                //frmSymbol fsmb = new frmSymbol();
                //string symbol = fsmb.GetSymbol(Symbol, "Add Symbol");
                //if (!String.IsNullOrEmpty(symbol))
                //{
                //    Symbol = symbol;
                //}
            }
        }

        void _MessageHandler_MessageReceived(object message)
        {
            if (message is Instrument)
            {
                ProcessInstrument((Instrument)message);
            }
            else if (message is OrderbookMDEvent)
            {
                OrderbookMDEvent order = (OrderbookMDEvent)message;
                switch (order.OrderbookType)
                {
                    case OrderbookMDEvent.OrderbookTypes.Add:
                        ProcessOrderbookAdd(order.Item);
                        break;
                    case OrderbookMDEvent.OrderbookTypes.Delete:
                        ProcessOrderbookDelete(order.Item);
                        break;
                    case OrderbookMDEvent.OrderbookTypes.Update:
                        ProcessOrderbookUpdate(order.Item);
                        break;
                    default:
                        break;
                }
            }
            else if (message is OrderbookMDInitEvent)
            {
                OrderbookMDInitEvent orders = (OrderbookMDInitEvent)message;
                ProcessOrderbookInitEvent(orders.Bids, orders.Offers);
            }
            else if (message is DepthByPriceMDEvent)
            {
                DepthByPriceMDEvent depth = (DepthByPriceMDEvent)message;
                ProcessDepthByPriceChanged(depth.Bids, depth.Offers);
            }
        }

        void _Repository_InstrumentUpdatedEvent(Instrument instrument)
        {
            _MessageHandler.AddMessage(instrument);
        }

        void Orderbook_OrderbookItemDeletedEvent(OrderbookItem order)
        {
            OrderbookMDEvent newEvent = new OrderbookMDEvent();
            newEvent.Item = order;
            newEvent.OrderbookType = OrderbookMDEvent.OrderbookTypes.Delete;
            _MessageHandler.AddMessage(newEvent);
        }

        void Orderbook_OrderbookItemUpdatedEvent(OrderbookItem order)
        {
            OrderbookMDEvent newEvent = new OrderbookMDEvent();
            newEvent.Item = order;
            newEvent.OrderbookType = OrderbookMDEvent.OrderbookTypes.Update;
            _MessageHandler.AddMessage(newEvent);
        }

        void Orderbook_OrderbookItemAddedEvent(OrderbookItem order)
        {
            OrderbookMDEvent newEvent = new OrderbookMDEvent();
            newEvent.Item = order;
            newEvent.OrderbookType = OrderbookMDEvent.OrderbookTypes.Add;
            _MessageHandler.AddMessage(newEvent);
        }

        void Orderbook_OrderbookInitializedEvent(List<DepthByPrice> bids, List<DepthByPrice> offers)
        {
            OrderbookMDInitEvent newEvent = new OrderbookMDInitEvent();
            newEvent.Bids = bids;
            newEvent.Offers = offers;
            _MessageHandler.AddMessage(newEvent);
        }

        void Orderbook_DepthByPriceChangedEvent(List<DepthByPrice> bids, List<DepthByPrice> offers)
        {
            EnqueueDepthByPriceChangedEvent(bids, offers);
        }

        void _Repository_Level2SymbolChanged(string symbol)
        {
            if (Symbol != symbol)
            {
                Symbol = symbol;
            }
        }

        private void dgvBidOfferCross_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (_BidOfferCrossRows.Count() > e.RowIndex)
            {
                BidOfferCrossRow applicableRow = _BidOfferCrossRows.ElementAt(e.RowIndex);
                DataGridViewRow gridRow = dgvBidOfferCross.Rows[e.RowIndex];
                if (null != applicableRow)
                {
                    string bidPriceVsOfferPrice = applicableRow.GetBidPriceVsOfferPrice();
                    string bidVolumeVsOfferVolume = applicableRow.GetBidVolumeVsOfferVolume();
                    string ordersAtBidVsOrdersAtVolume = applicableRow.GetOrdersAtBidPriceVsOrdersAtOfferPrice();
                    string spread = applicableRow.GetSpread();//Kul

                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = bidPriceVsOfferPrice;
                            break;
                        case 1:
                            e.Value = bidVolumeVsOfferVolume;
                            break;
                        case 2:
                            e.Value = ordersAtBidVsOrdersAtVolume;
                            break;
                        case 3:
                            e.Value = spread;
                            break;
                    }
                    UpdateBidOfferCrossRowColour(e.RowIndex);
                }
            }
        }

        private void dgvAsk_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            IEnumerable<OrderbookItem> allOrders = _Offers.SelectMany(o => o.Orders); //dicAsk.SelectMany(o => o.Value.Orders);//_Offers.SelectMany(o => o.Orders);

            if (allOrders.Count() > e.RowIndex)//Kuldeep
            {
                OrderbookItem orderBookItem = allOrders.ElementAt(e.RowIndex);

                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = orderBookItem.OriginalOrderCode;
                        break;
                    case 1:
                        e.Value = orderBookItem.Price.ToString(_displayFormat);
                        break;
                    case 2:
                        e.Value = orderBookItem.Size;
                        break;
                    case 3:
                        e.Value = orderBookItem.OrderDate.ToString("HH:mm:ss");
                        break;
                }
                UpdateOfferRowColour(e.RowIndex, orderBookItem);
            }
        }

        private void dgvBid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            IEnumerable<OrderbookItem> allOrders = _Bids.SelectMany(o => o.Orders);//dicBid.SelectMany(o => o.Value.Orders);//_Bids.SelectMany(o => o.Orders);

            if (allOrders.Count() > e.RowIndex)//Kuldeep
            {
                OrderbookItem orderBookItem = allOrders.ElementAt(e.RowIndex);

                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = orderBookItem.OriginalOrderCode;
                        break;
                    case 1:
                        e.Value = orderBookItem.Price.ToString(_displayFormat);
                        break;
                    case 2:
                        e.Value = orderBookItem.Size;
                        break;
                    case 3:
                        e.Value = orderBookItem.OrderDate.ToString("HH:mm:ss");
                        break;
                }
                UpdateBidRowColour(e.RowIndex, orderBookItem);
            }
        }

        private class BidOfferCrossRow
        {
            private BidOfferCrossRow() { }

            public static BidOfferCrossRow CreateFrom(DepthByPrice bid, DepthByPrice offer, Color rowColor, string format)
            {
                return new BidOfferCrossRow()
                {
                    BidPrice = bid.Price,
                    OfferPrice = offer.Price,
                    BidVolume = bid.Volume,
                    OfferVolume = offer.Volume,
                    OrdersAtBidPrice = bid.Orders.Count,
                    OrdersAtOfferPrice = offer.Orders.Count,
                    Color = rowColor,
                    _displayFormat = format
                };
            }

            public double BidPrice { get; private set; }
            public double OfferPrice { get; private set; }
            public long BidVolume { get; private set; }
            public long OfferVolume { get; private set; }
            public long OrdersAtBidPrice { get; private set; }
            public long OrdersAtOfferPrice { get; private set; }
            public Color Color { get; private set; }
            public string _displayFormat { get; private set; }
            public string GetBidPriceVsOfferPrice()
            {
                return string.Format("{0} * {1}", BidPrice, OfferPrice);
            }

            public string GetBidVolumeVsOfferVolume()
            {
                return string.Format("{0} * {1}", BidVolume, OfferVolume);
            }

            public string GetOrdersAtBidPriceVsOrdersAtOfferPrice()
            {
                return string.Format("{0} * {1}", OrdersAtBidPrice, OrdersAtOfferPrice);
            }

            public string GetSpread()
            {
                string temp = Math.Abs(BidPrice - OfferPrice).ToString(_displayFormat);//(Math.Round(Math.Abs(BidPrice - OfferPrice), 5)).ToString();
                return temp;
            }

            public string[] GetCellValues()
            {
                return new string[]
                {
                    GetBidPriceVsOfferPrice(),
                    GetBidVolumeVsOfferVolume(),
                    GetOrdersAtBidPriceVsOrdersAtOfferPrice(),
                    GetSpread()
                };
            }
        }

        internal class OrderbookMDInitEvent
        {
            internal List<DepthByPrice> Bids;
            internal List<DepthByPrice> Offers;
        }

        internal class DepthByPriceMDEvent
        {
            internal List<DepthByPrice> Bids { get; set; }
            internal List<DepthByPrice> Offers { get; set; }
        }

        internal class OrderbookMDEvent
        {
            internal OrderbookItem Item;
            internal enum OrderbookTypes
            {
                Add,
                Update,
                Delete
            }
            internal OrderbookTypes OrderbookType;
        }

        private void dgvBid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvAsk_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


    }
}
