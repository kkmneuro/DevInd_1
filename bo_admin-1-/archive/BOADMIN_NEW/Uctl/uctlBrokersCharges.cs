using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using clsInterface4OME.DSBO;
using clsInterface4OME;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlBrokersCharges : UserControl
    {
        int _chargesId;
        static int _index = -9999;
        DialogType _currentChargesDialogType;
        List<string> _lstSymbolNames=new List<string>();
        List<int> _lstSymbolIDS=new List<int>();

        public uctlBrokersCharges()
        {
            InitializeComponent();
        }

        public void SetValues(DS4Brokers.dtChargesRow chargesRow , DialogType dialogType)
        {
            InitComboBox();
            if (chargesRow != null)
            {
                _chargesId = chargesRow.SymbolChargesID;
            }
            _currentChargesDialogType = dialogType;

            if (dialogType != DialogType.Edit) return;
            if (chargesRow != null)
            {
                ui_ncmbSymbol.SelectedIndex = ui_ncmbSymbol.Items.IndexOf(chargesRow.Symbol);
                ui_ncmbFee.SelectedIndex = ui_ncmbFee.Items.IndexOf(chargesRow.FeeType);
                ui_ntxtFeeValue.Text = chargesRow.FeeValue.ToString();
                ui_ncmbTax.SelectedIndex = ui_ncmbTax.Items.IndexOf(chargesRow.TaxType);
                ui_ntxtTaxValue.Text = chargesRow.TaxValue.ToString();
            }
        }

        public void SetValues(DS.DS4Charges.dtChargesRow chargesRow, DialogType dialogType)
        {
            InitComboBox();
            _currentChargesDialogType = dialogType;
            if (chargesRow == null) return;
            if (dialogType != DialogType.Edit) return;
            _chargesId = chargesRow.SymbolChargesID;
            ui_ncmbSymbol.SelectedIndex = ui_ncmbSymbol.Items.IndexOf(chargesRow.Symbol);
            ui_ncmbFee.SelectedIndex = ui_ncmbFee.Items.IndexOf(chargesRow.FeeType);
            if (chargesRow.FeeValue != string.Empty)
            {
                ui_ntxtFeeValue.Text = chargesRow.FeeValue;
            }
            ui_ncmbTax.SelectedIndex = ui_ncmbTax.Items.IndexOf(chargesRow.TaxType);
            if (chargesRow.TaxValue != string.Empty)
            {
                ui_ntxtTaxValue.Text = chargesRow.TaxValue;
            }
        }
        public void AddSymbols(Dictionary<int,string> ddSymbols)
        {
            ui_ncmbSymbol.Items.Clear();
            foreach (KeyValuePair<int,string> item in ddSymbols)
            {
                _lstSymbolIDS.Add(item.Key);
                _lstSymbolNames.Add(item.Value);
            }
            ui_ncmbSymbol.Items.AddRange(_lstSymbolNames.ToArray());
        }

        private void ui_nbtnOk_Click(object sender, EventArgs e)
        {
            ChargesInfo objChargesInfo = new ChargesInfo();
            if (_currentChargesDialogType == DialogType.Edit)
            {
                objChargesInfo.SymbolChargesID = _chargesId;
            }
            else
            {
                _index = _index + 1;
                objChargesInfo.SymbolChargesID = _index;
            }

            objChargesInfo.Symbol = ui_ncmbSymbol.Text; 
            if (ui_ncmbSymbol.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Symbol Can't be null", "Broker Error ", true);
                return;
            }
            if (ui_ncmbFee.SelectedItem == null)
            {
                clsDialogBox.ShowErrorBox("Fee Type Can't be null", "Broker Error ", true);
                return;
            }
            if (ui_ntxtFeeValue.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Fee Value Can't be null", "Broker Error ", true);
                return;
            }
            if (ui_ncmbTax.Text == null)
            {
                clsDialogBox.ShowErrorBox("Tax Type Can't be null", "Broker Error ", true);
                return;
            }
            if (ui_ntxtTaxValue.Text == string.Empty)
            {
                clsDialogBox.ShowErrorBox("Tax Value Can't be null", "Broker Error ", true);
                return;
            }
            objChargesInfo.SymbolID =_lstSymbolIDS[_lstSymbolNames.IndexOf(ui_ncmbSymbol.Text)];           
            objChargesInfo.Fee = clsUtility.GetStr(ui_ncmbFee.Text);
            objChargesInfo.FeeValue =clsUtility.GetStr( ui_ntxtFeeValue.Text);
            objChargesInfo.Tax = clsUtility.GetStr(ui_ncmbTax.Text);
            objChargesInfo.TaxValue = clsUtility.GetStr(ui_ntxtTaxValue.Text);
            DS4FeeMaster.dtFeeMasterRow row= clsFeeMasterManager.INSTANCE.GetFeeRow(ui_ncmbFee.Text);
            if(row!=null)
            {
                if (!(Convert.ToDecimal(objChargesInfo.FeeValue) >= row.MinimumFeeValue && Convert.ToDecimal(objChargesInfo.FeeValue) <= row.MaximunFeeValue))
                {
                    clsDialogBox.ShowErrorBox("FeeValue must be between max and min value of Fee", "Broker Error ", true);
                    return;
                }
            }

            DS4TaxMaster.dtTaxMasterRow taxRow = clsTaxMasterManager.INSTANCE.GetTaxRow(objChargesInfo.Tax);
            if (taxRow != null)
            {
                if (Convert.ToDecimal(objChargesInfo.TaxValue) > taxRow.TaxPercent)
                {
                    clsDialogBox.ShowErrorBox("TaxValue must be less than or equal to value of Fee", "Broker Error ", true);
                    return;
                }
            }

            OnOkClick(objChargesInfo);

            this.ParentForm.Close();
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        #region    "    EVENTS    "

        public event Action<ChargesInfo> OnOkClick;

        #endregion "    EVENTS    "

        public void InitComboBox()
        {
            ui_ncmbFee.Items.AddRange(clsBrokersManagerHandler.INSTANCE._lstFeeType.ToArray());
            ui_ncmbTax.Items.AddRange(clsBrokersManagerHandler.INSTANCE._lstTaxType.ToArray());
        }

        private void uctlBrokersCharges_Load(object sender, EventArgs e)
        {
            if (!FrmMain.Instance._FeeMasterLoaded)
            {
                FrmMain.Instance.GetFeeMaster();
                FrmMain.Instance._FeeMasterLoaded = true;
            }
            if (!FrmMain.Instance._TaxMasterLoaded)
            {
                FrmMain.Instance.GetTaxMaster();
                FrmMain.Instance._TaxMasterLoaded = true;
            }
        }

        private void ui_ntxtFeeValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ui_ncmbFee.SelectedItem == null)
            {
                e.Handled = true;
                clsDialogBox.ShowErrorBox("Please selected FeeType first", "Charges Error", true);
            }
            else
            {
                if (ui_ntxtFeeValue.Text.Contains('.'))
                {
                    if (ui_ntxtFeeValue.Text.Substring(ui_ntxtFeeValue.Text.IndexOf('.') + 1).Length >= 5 && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                        return;
                    }
                }
                if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void ui_ntxtFeeValue_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void ui_ntxtTaxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ui_ncmbTax.SelectedItem == null)
            {
                e.Handled = true;
                clsDialogBox.ShowErrorBox("Please selected TaxType first", "Charges Error", true);
            }
            else
            {
                if (ui_ntxtTaxValue.Text.Contains('.'))
                {
                    if (ui_ntxtTaxValue.Text.Substring(ui_ntxtTaxValue.Text.IndexOf('.') + 1).Length >= 2 && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                        return;
                    }
                }
                if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }

    public class ChargesInfo
    {
        public int SymbolChargesID { get; set; }
        public int BrokersGroupId { get; set; }
        public int SymbolID { get; set; }
        public string Symbol { get; set; }
        public string Fee { get; set; }
        public string FeeValue { get; set; }
        public string Tax { get; set; }
        public string TaxValue { get; set; }
    }
}
