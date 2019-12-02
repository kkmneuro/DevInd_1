using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CommonLibrary.Cls;
using PALSA.Cls;

namespace PALSA.uctl
{
    public partial class uctlSelectChartSymbol : UserControl
    {
        public uctlSelectChartSymbol()
        {
            InitializeComponent();
        }

        private void uctlSelectChartSymbol_Load(object sender, EventArgs e)
        {
            //Namo 22 March  
            //List<string> products = ClsTWSContractManager.INSTANCE.GetAllProducts("FOREX");
            //foreach (string product in products)
            //{
            //    List<string> symbols = ClsTWSContractManager.INSTANCE.GetAllContracts("FOREX", product);
            //    foreach (string symbol in symbols)
            //    {
            //        InstrumentSpec instspec = ClsTWSContractManager.INSTANCE.GetContractSpec(symbol,
            //                                                                                 "FOREX",
            //                                                                                 product);
            //        List<string> keys = Symbol.getKey(instspec);
            //        ui_nlstSymbols.Items.Add(instspec.Contract);
            //    }
            //}

            InitializePeriodicty();
        }

        private void InitializePeriodicty()
        {
            ui_nlstPeriodicity.Items.Add("1 MINUTE");
            ui_nlstPeriodicity.Items.Add("5 MINUTE");
            ui_nlstPeriodicity.Items.Add("15 MINUTE");
            ui_nlstPeriodicity.Items.Add("30 MINUTE");
            ui_nlstPeriodicity.Items.Add("1 HOUR");
            //ui_nlstPeriodicity.Items.Add("DAILY");
            //ui_nlstPeriodicity.Items.Add("WEEKLY");
            //ui_nlstPeriodicity.Items.Add("MONTHLY");
        }

        private void ui_nbtnOK_Click(object sender, EventArgs e)
        {
            if (ui_nlstSymbols.SelectedItem.ToString() == null)
            {
                ClsCommonMethods.ShowErrorBox("Please select symbol");
                return;
            }
            if (ui_nlstPeriodicity.SelectedItem.ToString() == null)
            {
                ClsCommonMethods.ShowErrorBox("Please select periodicity");
                return;
            }
            OnOkClick(ui_nlstSymbols.SelectedItem.ToString(), ui_nlstPeriodicity.SelectedItem.ToString());
            this.ParentForm.Close();
        }

        public event Action<string,string> OnOkClick=delegate{};
        public event Action OnCancelClick = delegate { };

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
            OnCancelClick();
        }
    }
}
