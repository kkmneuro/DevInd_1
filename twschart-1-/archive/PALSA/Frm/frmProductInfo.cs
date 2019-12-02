using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonLibrary.Cls;
using PALSA.Cls;

namespace PALSA.Frm
{
    public partial class frmProductInfo : frmBase
    {
        #region "    MEMBERS     "

        private static frmProductInfo _Instance;
        //Dictionary<string, InstrumentSpec> AllContracts = new Dictionary<string, InstrumentSpec>();
        private static string _selectedInstrumentId = string.Empty;

        #endregion "      MEMBERS      "

        #region    "   CONSTRUCTORS    "

        private frmProductInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for initilizing the  
        /// </summary>
        public static frmProductInfo GetInstance(string selectedInstrumentId)
        {
            if (_Instance == null)
            {
                _Instance = new frmProductInfo();
            }
            _selectedInstrumentId = selectedInstrumentId;
            return _Instance;
        }

        #endregion   "    CONSTRUCTORS    " 

        private void frmProductInfo_Load(object sender, EventArgs e)
        {
            Text = "Contract Information";
            MinimumSize = Size;
            MaximumSize = Size;

            uctlContractInformation1.OnSelectedInstChanged -=
    uctlContractInformation1_OnSelectedInstChanged;
            uctlContractInformation1.OnExpiryDateSelected -=
                uctlContractInformation1_OnExpiryDateSelected;
            uctlContractInformation1.OnSymbolTextChanged -=
                uctlContractInformation1_OnSymbolTextChanged;
            uctlContractInformation1.OnSelectedProductChanged -=
                uctlContractInformation1_OnSelectedProductChanged;
            uctlContractInformation1.OnSelectedContractChanged -=
                uctlContractInformation1_OnSelectedContractChanged;

            uctlContractInformation1.OnSelectedInstChanged +=
                uctlContractInformation1_OnSelectedInstChanged;
            uctlContractInformation1.OnExpiryDateSelected +=
                uctlContractInformation1_OnExpiryDateSelected;
            uctlContractInformation1.OnSymbolTextChanged +=
                uctlContractInformation1_OnSymbolTextChanged;
            uctlContractInformation1.OnSelectedProductChanged +=
                uctlContractInformation1_OnSelectedProductChanged;
            uctlContractInformation1.OnSelectedContractChanged +=
                uctlContractInformation1_OnSelectedContractChanged;
            uctlContractInformation1.ui_nCmbProductTypes.Items.Clear();

            // uctlContractInformation1.FillProductTypes(ClsTWSContractManager.INSTANCE.GetAllProductTypes().ToArray());
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();

            TopMost = true;
        }

        private void uctlContractInformation1_OnSymbolTextChanged(object arg1, EventArgs arg2)
        {
            //Namo 21 March
            //IEnumerable<string> res =
            //    ClsTWSContractManager.INSTANCE.GetProductsInfo(uctlContractInformation1.ProductType,
            //                                                   uctlContractInformation1.Symbol,
            //                                                   eSEARCH_CRITERIA.IS);
            //uctlContractInformation1.ClearExpiryDates();

            //foreach (string item in res)
            //{
            //    List<string> contracts =
            //        ClsTWSContractManager.INSTANCE.GetAllContracts(uctlContractInformation1.ProductType, item);
            //    uctlContractInformation1.ClearExpiryDates();
            //    foreach (string item2 in contracts)
            //    {
            //        InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[item2];
            //        string expiryDate = Cls.ClsGlobal.GetDateTime(instspec.ExpiryDate);
            //        uctlContractInformation1.AddExpiryDate(expiryDate);                    
            //    }
            //}
        }

        private void uctlContractInformation1_OnExpiryDateSelected(object arg1, EventArgs arg2)
        {

            //InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(uctlContractInformation1.Symbol, uctlContractInformation1.ProductType, uctlContractInformation1.ProductName);
            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[uctlContractInformation1.Symbol];
            SetProductInformation(instspec);
        }

        //Creates Contract Object and sets it to controls.
        private void SetProductInformation(InstrumentSpec instspec)
        {
            ClsContractInfo cs = null;
            if (instspec != null)
            {
                cs = new ClsContractInfo();
                cs.ProductName = instspec.Product;
                cs.ProductType = instspec.ProductType;
                cs.ContractName = instspec.Contract;
                cs.Hedged = instspec.Hedged;
                cs.Information = instspec.Information;
                cs.InitialBuyMargin = instspec.InitialBuyMargin;
                cs.InitialSellMargin = instspec.InitialSellMargin;
                cs.Limit_Stop_Level = instspec.Limit_Stop_Level;
                cs.LongPositions = instspec.LongPositions;
                cs.MarginCall1 = instspec.MarginCall1;
                cs.MarginCall2 = instspec.MarginCall2;
                cs.MarginCall3 = instspec.MarginCall3;
                cs.MarginCurrency = instspec.MarginCurrency;
                cs.MarketLot = instspec.MarketLot;
                cs.MaxDPR = instspec.MaxDPR;
                cs.MaximumAllowablePosition = instspec.MaximumAllowablePosition;
                cs.MaximumLotsForIE = instspec.MaximumLotsForIE;
                cs.MaxOrderSize = instspec.MaxOrderSize;
                cs.MaxOrderValue = instspec.MaxOrderValue;
                cs.MinDPR = instspec.MinDPR;
                cs.Orders = instspec.Orders;
                cs.OtherBuyMargin = instspec.OtherBuyMargin;
                cs.OtherSellMargin = instspec.OtherSellMargin;
                cs.Percentage = instspec.Percentage;
                cs.PriceDenominator = instspec.PriceDenominator;
                cs.PriceNumerator = instspec.PriceNumerator;
                cs.PriceQuantity = instspec.PriceQuantity; //
                cs.PriceTick = instspec.PriceTick;
                cs.QuotationBaseValue = instspec.QuotationBaseValue;
                cs.SellSideTurnover = instspec.SellSideTurnover;
                cs.SettlingCurrency = instspec.SettlingCurrency;
                cs.ShortPositions = instspec.ShortPositions;
                cs.Specification = instspec.Specification;
                cs.SpreadBalance = instspec.SpreadBalance;
                cs.SpreadByDefault = instspec.SpreadByDefault;
                cs.StartDate = PALSA.Cls.ClsGlobal.GetDateTimeDT(instspec.StartDate).ToOADate();
                cs.TenderEndDate = PALSA.Cls.ClsGlobal.GetDateTimeDT(instspec.TenderEndDate).ToOADate();
                cs.TenderStartDate = PALSA.Cls.ClsGlobal.GetDateTimeDT(instspec.TenderStartDate).ToOADate();
                cs.TradingCurrency = instspec.TradingCurrency;
                cs.UL_Asset = instspec.UL_Asset;
            }
            uctlContractInformation1.SetContractInformation(cs);
        }

        private void uctlContractInformation1_OnSelectedInstChanged(object arg1, EventArgs arg2)
        {
            //Namo 22 March
            //List<string> products =
            //    ClsTWSContractManager.INSTANCE.GetAllProducts(uctlContractInformation1.ProductType);
            //if (products != null && products.Count > 0)
            //{
            //    uctlContractInformation1.ui_nCmbProducts.Items.Clear();
            //    uctlContractInformation1.ui_nCmbProducts.Text = "";
            //    uctlContractInformation1.ui_nCmbProducts.Items.AddRange(products.ToArray());
            //}
        }

        private void uctlContractInformation1_OnSelectedProductChanged(object arg1, EventArgs arg2)
        {
            //Namo 22 March
            //List<string> contracts =
            //    ClsTWSContractManager.INSTANCE.GetAllContracts(uctlContractInformation1.ProductType,
            //                                                   uctlContractInformation1.ProductName);
            //foreach (string contract in contracts)
            //{
            //    uctlContractInformation1.ui_nCmbContracts.Items.Clear();
            //    uctlContractInformation1.ui_nCmbContracts.Items.AddRange(contracts.ToArray());
            //    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(contract,
            //                                                                             uctlContractInformation1.
            //                                                                                 ui_nCmbProductTypes.
            //                                                                                 SelectedItem.ToString(),
            //                                                                             uctlContractInformation1.
            //                                                                                 ui_nCmbProducts.
            //                                                                                 SelectedItem.ToString());
            //    if (instspec != null)
            //    {
            //        string expiryDate = PALSA.Cls.ClsGlobal.GetDateTimeDT(instspec.ExpiryDate).ToShortDateString();
            //        uctlContractInformation1.AddExpiryDate(expiryDate);
            //    }
            //}
        }

        private void uctlContractInformation1_OnSelectedContractChanged(string contract)
        {
            if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(contract))
            {
                InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[contract];
                SetProductInformation(instspec);

            }
            //uctlContractInformation1.Symbol = contract;
            //InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(contract,
            //                                                                         uctlContractInformation1.
            //                                                                             ui_nCmbProductTypes.
            //                                                                             SelectedItem.ToString(),
            //                                                                         uctlContractInformation1.
            //                                                                             ui_nCmbProducts.
            //                                                                             SelectedItem.ToString());
            //SetProductInformation(instspec);
            //uctlContractInformation1.ui_nCmbExpiryDates.Text =
            //    Cls.ClsGlobal.GetDateTime(instspec.ExpiryDate);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_selectedInstrumentId != string.Empty)
            {
                Symbol sym = Symbol.GetSymbol(_selectedInstrumentId);

                InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[sym.Contract];
                uctlContractInformation1.ui_nCmbProductTypes.SelectedItem = sym.ProductType;
                uctlContractInformation1.ui_nCmbProducts.SelectedItem = sym.Product;
                uctlContractInformation1.ui_nCmbContracts.SelectedItem = sym.Contract;
                //SetProductInformation(instspec);
            }
        }

        private void frmProductInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}