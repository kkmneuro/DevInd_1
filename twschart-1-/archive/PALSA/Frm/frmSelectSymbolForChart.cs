using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PALSA.Cls;

namespace PALSA.Frm
{
    public partial class frmSelectSymbolForChart : frmBase
    {
        public frmSelectSymbolForChart()
        {
            InitializeComponent();
        }

        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            var lstSymbol = new List<Symbol>();

            //InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(ui_ncmbContractName.Text,
            //                                                                         ui_ncmbProductType.Text,
            //                                                                         ui_ncmbProductName.Text);

            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[ui_ncmbContractName.Text];
            if (instspec != null)
            {
                foreach (string key in Symbol.getKey(instspec))
                {
                    Symbol sym = Symbol.GetSymbol(key);
                    lstSymbol.Add(sym);
                }
                //lstSymbol.Add(Symbol.GetSymbol(Symbol.getKey(instspec)));
                clsTWSDataManagerJSON.INSTANCE.SubscribeForQuotes(eMarketRequest.MARKET_QUOTE_REQUEST, lstSymbol);
            }
            if (ui_ncmbPeriodicity.Text == "")
            {
                MessageBox.Show("Please select periodicity");
                return;
            }
            OnOkClick(ui_ncmbContractName.Text,
                      (ePeriodicity)Enum.Parse(typeof(ePeriodicity), ui_ncmbPeriodicity.Text));
            Close();
        }

        public event Action<string, ePeriodicity> OnOkClick = delegate { };

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSelectSymbolForChart_Load(object sender, EventArgs e)
        {
            ui_ncmbProductType.Items.AddRange(ClsTWSContractManager.INSTANCE.GetProductTypes().ToArray());
            ui_ncmbPeriodicity.Items.Clear();
            ui_ncmbPeriodicity.Items.AddRange(Enum.GetNames(typeof(ePeriodicity)));
        }

        private void ui_ncmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ncmbProductName.Items.Clear();
            //Namo 22 March
            //ui_ncmbProductName.Items.AddRange(ClsTWSContractManager.INSTANCE.GetAllProducts(ui_ncmbProductType.SelectedItem.ToString()).ToArray());
        }

        private void ui_ncmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Namo 22 March
            //List<string> contracts;

            //    contracts = ClsTWSContractManager.INSTANCE.GetAllContracts(ui_ncmbProductType.SelectedItem.ToString(),
            //                                                               ui_ncmbProductName.SelectedItem.ToString());
            //ui_ncmbContractName.Items.Clear();
            //ui_ncmbContractName.Items.AddRange(contracts.ToArray());
            //ui_ncmbExpiryDate.Items.Clear();
            //foreach (string item in contracts)
            //{

            //    InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(item,
            //                                                                             ui_ncmbProductType.SelectedItem
            //                                                                                 .ToString(),
            //                                                                             ui_ncmbProductName.SelectedItem
            //                                                                                 .ToString());
            //    if (instspec != null)
            //    {
            //        string expiryDate = ClsGlobal.GetDateTime(instspec.ExpiryDate);
            //        ui_ncmbExpiryDate.Items.Add(expiryDate);
            //    }
            //}
        }

        private void ui_ncmbContractName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(ui_ncmbContractName.Text,
            //                                                                         ui_ncmbProductType.SelectedItem.
            //                                                                             ToString(),
            //                                                                         ui_ncmbProductName.SelectedItem.
            //                                                                             ToString());
            InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.ddContractDetails[ui_ncmbContractName.Text];
            ui_ncmbExpiryDate.SelectedItem = ClsGlobal.GetDateTimeDT(instspec.ExpiryDate).ToShortDateString();
        }
    }
}