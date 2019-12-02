using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CommonLibrary.Cls;
using TWS.Cls;

namespace TWS.Frm
{
    public partial class frmProductInfo : frmBase
    {
        #region "    MEMBERS     "

        //private static frmProductInfo _Instance;
        //Dictionary<string, InstrumentSpec> AllContracts = new Dictionary<string, InstrumentSpec>();
        private static string _selectedInstrumentId = string.Empty;

        #endregion "      MEMBERS      "

        #region    "   CONSTRUCTORS    "

        public frmProductInfo()
        {
            InitializeComponent();
        }


        public string SelectedInstrument
        {
            get { return _selectedInstrumentId; }
            set { _selectedInstrumentId = value; }
        }
        #endregion   "    CONSTRUCTORS    " 

        private void frmProductInfo_Load(object sender, EventArgs e)
        {
            Text = "Contract Information";
            MinimumSize = Size;
            MaximumSize = Size;

            uctlContractInformation1.OnSelectedProductChanged -= uctlContractInformation1_OnSelectedProductChanged;
            uctlContractInformation1.OnSelectedContractChanged -= uctlContractInformation1_OnSelectedContractChanged;
            uctlContractInformation1.OnProductTypesChanged -= uctlContractInformation1_OnProductTypesChanged;
            uctlContractInformation1.ui_nCmbProductTypes.Items.Clear();
            foreach (var item in ClsTWSContractManager.INSTANCE.LstProductTypes)
            {
                if (item.ToUpper()!="ALL")
                {
                    uctlContractInformation1.ui_nCmbProductTypes.Items.Add(item);
                }
            }
           // uctlContractInformation1.FillProductTypes(ClsTWSContractManager.INSTANCE.LstProductTypes.ToArray());
            uctlContractInformation1.OnProductTypesChanged += uctlContractInformation1_OnProductTypesChanged;
            if (uctlContractInformation1.ui_nCmbProductTypes.Items.Count > 0)
            {
                uctlContractInformation1.ui_nCmbProductTypes.SelectedIndex = 0;
            }
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();

            TopMost = true;
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
                cs.StartDate = TWS.Cls.ClsGlobal.GetDateTimeDT(instspec.StartDate).ToOADate();
                cs.TenderEndDate = TWS.Cls.ClsGlobal.GetDateTimeDT(instspec.TenderEndDate).ToOADate();
                cs.TenderStartDate = TWS.Cls.ClsGlobal.GetDateTimeDT(instspec.TenderStartDate).ToOADate();
                cs.TradingCurrency = instspec.TradingCurrency;
                cs.UL_Asset = instspec.UL_Asset;
                cs.DeliveryUnit = instspec.DeliveryUnit;
                cs.DeliveryQuantity = instspec.DeliveryQuantity;
            }
            uctlContractInformation1.SetContractInformation(cs);
        }

        private void uctlContractInformation1_OnProductTypesChanged(object arg1, EventArgs arg2)
        {
            try
            {

                if (ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[uctlContractInformation1.ProductType].Keys.Count > 0)
                {
                    uctlContractInformation1.OnSelectedProductChanged -= uctlContractInformation1_OnSelectedProductChanged;
                    uctlContractInformation1.OnSelectedContractChanged -= uctlContractInformation1_OnSelectedContractChanged;
                    uctlContractInformation1.ui_nCmbProducts.Items.Clear();
                    uctlContractInformation1.ui_nCmbProducts.Text = "";
                    foreach (var item in ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[uctlContractInformation1.ProductType].Keys)
                    {
                        uctlContractInformation1.ui_nCmbProducts.Items.Add(item);
                    }
                    uctlContractInformation1.OnSelectedProductChanged += uctlContractInformation1_OnSelectedProductChanged;
                    if (uctlContractInformation1.ui_nCmbProducts.Items.Count > 0)
                    {
                        uctlContractInformation1.ui_nCmbProducts.SelectedIndex = 0;
                    }

                }
            }
            catch (Exception)
            {

            }

        }

        private void uctlContractInformation1_OnSelectedProductChanged(object arg1, EventArgs arg2)
        {
            try
            {
                uctlContractInformation1.OnSelectedContractChanged -= uctlContractInformation1_OnSelectedContractChanged;
                List<string> contracts =
              ClsTWSContractManager.INSTANCE.ddProductTypesProductContract[uctlContractInformation1.ProductType][uctlContractInformation1.ProductName];
                foreach (string contract in contracts)
                {
                    uctlContractInformation1.ui_nCmbContracts.Items.Clear();
                    uctlContractInformation1.ui_nCmbContracts.Items.AddRange(contracts.ToArray());
                }
                uctlContractInformation1.OnSelectedContractChanged += uctlContractInformation1_OnSelectedContractChanged;
                if (uctlContractInformation1.ui_nCmbContracts.Items.Count > 0)
                {
                    uctlContractInformation1.ui_nCmbContracts.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {

            }

        }

        private void uctlContractInformation1_OnSelectedContractChanged(string contract)
        {
            if (ClsTWSContractManager.INSTANCE.ddContractDetails.ContainsKey(contract))
            {
                InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[contract];
                SetProductInformation(instspec);

            }


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