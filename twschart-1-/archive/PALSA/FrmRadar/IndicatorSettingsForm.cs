using System;
using System.Windows.Forms;
//using FundXchange.Model.ViewModels.Indicators;
using Nevron.UI.WinForm.Controls;
using PALSA.ClsRadar;
//using M4.Scripts;
//using FundXchange.Infrastructure;
//using FundXchange.Model.Repositories;

namespace PALSA.FrmRadar
{
    public partial class IndicatorSettingsForm : NForm
    {
        public IndicatorSettingsForm(Indicator selectedIndicator, IIndicatorRepository indicatorRepository)
        {
            InitializeComponent();

            if(null != selectedIndicator)
                PopulateFields(selectedIndicator);

            _indicatorRepository = indicatorRepository;
        }

        //private readonly ScriptValidationService _validationService;
        private readonly IIndicatorRepository _indicatorRepository;

        private TextBox[] ScriptFields
        {
            get
            {
                return new TextBox[]
                {
                    txtDefaultScript,
                    txtBuyScript,
                    txtSellScript
                };
            }
        }

        private Guid _indicatorId;
        private Guid IndicatorId
        {
            get
            {
                if (_indicatorId == default(Guid))
                    _indicatorId = Guid.NewGuid();
                return _indicatorId;
            }
            set
            {
                _indicatorId = value;
            }
        }

        public Indicator DefinedIndicator
        {
            get
            {
                return new Indicator(IndicatorId, txtIndicatorName.Text, txtAbbreviation.Text, txtDefaultScript.Text, true)
                {
                    BuyScript = txtBuyScript.Text,
                    SellScript = txtSellScript.Text
                };
            }
        }

        private void PopulateFields(Indicator selectedIndicator)
        {
            if(selectedIndicator.IsUserDefined)
                IndicatorId = selectedIndicator.UniqueId;
            
            txtIndicatorName.Text = selectedIndicator.Name;
            txtBuyScript.Text = selectedIndicator.BuyScript;
            txtSellScript.Text = selectedIndicator.SellScript;
            txtAbbreviation.Text = selectedIndicator.Abbreviation;
            txtDefaultScript.Text = selectedIndicator.Script;
        }

        private bool CheckScriptsAreValid()
        {
            //foreach (TextBox scriptField in ScriptFields)
            //{
            //    if (!_validationService.IsValid(scriptField.Text))
            //    {
            //        string errorText = string.Format(GetScriptErrorText(scriptField), _validationService.GetValidationResult(scriptField.Text));
            //        MessageBox.Show(errorText, "Script error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            return true;
        }

        private string GetScriptErrorText(TextBox inputField)
        {
            if (inputField == txtDefaultScript)
            {
                return "Default script generated the following error: {0}";
            }
            else if (inputField == txtBuyScript)
            {
                return "Buy script generated the following error: {0}";
            }
            else if (inputField == txtSellScript)
            {
                return "Sell script generated the following error: {0}";
            }
            else
            {
                return "Trade signal script generated the following error: {0}";
            }
        }

        #region Event handlers

        private static bool ValidateField(TextBox textBox)
        {
            return !string.IsNullOrEmpty(textBox.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_indicatorRepository.ScriptNameIsValid(txtIndicatorName.Text))
            {
                if (!ValidateField(txtIndicatorName) && ValidateField(txtAbbreviation) && ValidateField(txtDefaultScript))
                {
                    MessageBox.Show("You must enter values for all fields before clicking OK.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (!CheckScriptsAreValid())
                {
                    return;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("The name specified for this indicator conflicts with the name of a pre-defined indicator. Please change the name of this indicator.", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (CheckScriptsAreValid())
            {
                MessageBox.Show("All scripts passed validity checks", "Validation success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}
