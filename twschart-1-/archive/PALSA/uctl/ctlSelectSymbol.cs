using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonLibrary.UserControls;
using PALSA.Cls;

namespace PALSA.uctl
{
    public partial class ctlSelectSymbol : UserControl
    {
        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        private string Symbol;

        //public string Symbol_
        //{
        //    get { return Symbol; }
        //    set { Symbol = value; }
        //}
        private readonly List<SymbolAttributes> _symbols;
        public IEnumerable<SymbolAttributes> Symbols
        {
            get { return _symbols; }
        }

        public ctlSelectSymbol(List<SymbolAttributes> symbol)
        {
            InitializeComponent();
            _symbols = symbol;
            // Symbol Combolist is populated with Hardcoded symbols for the time being 

            FillSymbols();

            cmbSymbols.SelectedIndex = 0;
            _objfrmDialogForm.Controls.Clear();
            //var objSize = new Size(objuctlSelectPortfolio.Width + 8, objuctlSelectPortfolio.Height + 28);
            _objfrmDialogForm.Size = this.Size;
            _objfrmDialogForm.Controls.Add(this);
            _objfrmDialogForm.Dock = DockStyle.Fill;
            _objfrmDialogForm.Text = "Symbols";
            _objfrmDialogForm.Sizable = false;
            _objfrmDialogForm.MinimizeBox = false;
            _objfrmDialogForm.CloseButton = false;
            //objfrmDialogForm.CancelButton= 
            _objfrmDialogForm.StartPosition = FormStartPosition.CenterScreen;
            _objfrmDialogForm.ShowDialog();
        }

        private void FillSymbols()
        {
            //Namo 22 March
            //List<string> productTypes = ClsTWSContractManager.INSTANCE.GetAllProductTypes();
            //if (productTypes.Contains("FOREX"))
            //{
            //    List<string> Products = ClsTWSContractManager.INSTANCE.GetAllProducts("FOREX");//(productTypes[productTypes.Count - 1]);
            //    foreach (var item in Products)
            //    {
            //        List<string> contracts = ClsTWSContractManager.INSTANCE.GetAllContracts("FOREX", item);

            //        foreach (var symbols in contracts)
            //        {
            //            cmbSymbols.Items.Add(symbols);
            //        }

            //    }
            //}
        }

        internal DialogResult ShowDialog()
        {
            return _objfrmDialogForm.ShowDialog();
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            SymbolAttributes SymAt = _symbols.Find(i=>i.Symbol==cmbSymbols.Text);

            if (SymAt == null)
            {
                _symbols.Add(new SymbolAttributes(cmbSymbols.Text, "FOREX", "FOREX", "OEC"));
            }
            this._objfrmDialogForm.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this._objfrmDialogForm.Close();
        }
    }
}
