using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using FundXchange.Model.Infrastructure;
//using FundXchange.Model.ViewModels.Indicators;
using Nevron.UI.WinForm.Controls;
//using FundXchange.Model.Repositories;
using System.Collections;
using PALSA.ClsRadar;

namespace PALSA.FrmRadar
{
    public partial class IndicatorSelectionForm : Nevron.UI.WinForm.Controls.NForm
    {
        public delegate void ActiveIndicatorChangedDelegate(Indicator indicatorToRefresh);

        public event EventHandler OnTradeScriptHelpRequested;
        public event EventHandler OnClosed;
        public event ActiveIndicatorChangedDelegate OnActiveIndicatorChanged;

        public IndicatorSelectionForm(IEnumerable<Indicator> activeIndicators)
        {
            InitializeComponent();

            _indicatorRepository = new IndicatorRepository();
            _selectedIndicators = activeIndicators.ToList();

            PopulateIndicatorList();
        }

        private readonly IIndicatorRepository _indicatorRepository;
        private readonly IList<Indicator> _selectedIndicators;

        public IEnumerable<Indicator> SelectedIndicators
        {
            get { return _selectedIndicators; }
        }

        private Indicator SelectedIndicator
        {
            get
            {
                Indicator selectedIndicator = null;
                if(null != lstIndicators.SelectedItem)
                {
                    if(_indicatorRepository.TryGetIndicatorBy(lstIndicators.SelectedItem.ToString(), out selectedIndicator))
                    {
                        return selectedIndicator;
                    }
                }
                else if(null != lstSelectedIndicators.SelectedItem)
                {
                    if (_indicatorRepository.TryGetIndicatorBy(lstSelectedIndicators.SelectedItem.ToString(), out selectedIndicator))
                    {
                        return selectedIndicator;
                    }
                }
                return selectedIndicator;
            }
        }

        #region Event handlers

        private void lstIndicators_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstIndicators.SelectedIndex > -1)
            {   
                lstSelectedIndicators.DeselectAll();
            }
            btnAdd.Enabled = lstIndicators.SelectedIndex > -1;
        }

        private void lstSelectedIndicators_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSelectedIndicators.SelectedIndex > -1)
            {  
                lstIndicators.DeselectAll();
            }
            btnRemove.Enabled = lstSelectedIndicators.SelectedIndex > -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (null != SelectedIndicator)
            {
                AddIndicatorToSelection(SelectedIndicator);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (null != SelectedIndicator)
            {
                _selectedIndicators.Remove(SelectedIndicator);
                AddAvailableIndicatorNode(SelectedIndicator);
                lstSelectedIndicators.Items.Remove(lstSelectedIndicators.SelectedItem);
            }
        }

        private void lstIndicators_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAdd_Click(sender, null);
        }

        private void lstSelectedIndicators_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnRemove_Click(sender, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CloseSelf(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseSelf(DialogResult.Cancel);
        }

        private void CloseSelf(DialogResult result)
        {
            DialogResult = result;

            if (null != OnClosed)
                OnClosed(this, new EventArgs());
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (null != OnTradeScriptHelpRequested)
                OnTradeScriptHelpRequested(this, new EventArgs());
        }

        private void btnNewIndicator_Click(object sender, EventArgs e)
        {
            ShowIndicatorSettingsDialog(null);
        }

        private void btnEditIndicator_Click(object sender, EventArgs e)
        {
            if (null != SelectedIndicator)
            {
                ShowIndicatorSettingsDialog(SelectedIndicator);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (null != SelectedIndicator)
            {
                if (SelectedIndicator.IsUserDefined)
                {
                    DeleteCustomIndicator(SelectedIndicator);
                }
                else
                {
                    MessageBox.Show("You are not permitted to remove pre-defined indicators from the selection.", "Invalid action performed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #region Helper methods

        private void PopulateIndicatorList()
        {
            foreach (Indicator indicator in _selectedIndicators)
            {
                AddSelectedIndicatorNode(indicator);
            }

            foreach (Indicator indicator in _indicatorRepository.AvailableIndicators.Except(_selectedIndicators))
            {
                AddAvailableIndicatorNode(indicator);
            }
        }

        private void AddIndicatorToSelection(Indicator selectedIndicator)
        {
            if (!_selectedIndicators.Contains(selectedIndicator))
            {
                _selectedIndicators.Add(selectedIndicator);
                AddSelectedIndicatorNode(selectedIndicator);
                RemoveIndicatorFromIndex(selectedIndicator);

                if (_indicatorRepository.IsGroupedIndicator(selectedIndicator))
                {
                    var siblings = _indicatorRepository.GetSiblingsOf(selectedIndicator);

                    foreach (var sibling in siblings)
                    {
                        AddIndicatorToSelection(sibling);
                    }
                }
            }
        }

        private void RemoveIndicatorFromIndex(Indicator selectedIndicator)
        {
            for (int i = 0; i < lstIndicators.Items.Count; i++)
            {
                if ((Guid)lstIndicators.Items[i].Tag == selectedIndicator.UniqueId)
                {
                    lstIndicators.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void RemoveIndicatorFromSelection(Indicator selectedIndicator)
        {
            for(int i = 0; i < lstSelectedIndicators.Items.Count; i++)
            {
                if ((Guid)lstSelectedIndicators.Items[i].Tag == selectedIndicator.UniqueId)
                {
                    lstSelectedIndicators.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void AddAvailableIndicatorNode(Indicator indicator)
        {
            int imageIndex = indicator.IsUserDefined ? 1 : 0;
            lstIndicators.Items.Add(new NListBoxItem(imageIndex, indicator.Name) { Tag = indicator.UniqueId });
        }

        private void AddSelectedIndicatorNode(Indicator indicator)
        {
            int imageIndex = indicator.IsUserDefined ? 1 : 0;
            lstSelectedIndicators.Items.Add(new NListBoxItem(imageIndex, indicator.Name) { Tag = indicator.UniqueId });
        }

        private void ShowIndicatorSettingsDialog(Indicator indicatorToEdit)
        {   
            using (var dialog = new IndicatorSettingsForm(indicatorToEdit, _indicatorRepository))
            {
               if (dialog.ShowDialog(this) == DialogResult.OK)
               {
                   Indicator definedIndicator = dialog.DefinedIndicator;

                   if (UserCreatedANewIndicator(indicatorToEdit))
                   {
                       _indicatorRepository.AddIndicator(dialog.DefinedIndicator);
                       AddAvailableIndicatorNode(dialog.DefinedIndicator);
                   }
                   else
                   {
                       if (IndicatorIsActive(indicatorToEdit))
                       {
                           RaiseActiveIndicatorChanged(dialog.DefinedIndicator);
                       }
                       _indicatorRepository.UpdateIndicator(indicatorToEdit.UniqueId, dialog.DefinedIndicator);
                   }
                }
            }
        }

        private bool IndicatorIsActive(Indicator indicator)
        {
            return _selectedIndicators.Contains(indicator);
        }

        private bool UserCreatedANewIndicator(Indicator indicatorToEdit)
        {
            return null == indicatorToEdit || !indicatorToEdit.IsUserDefined;
        }

        private void DeleteCustomIndicator(Indicator indicator)
        {
            _indicatorRepository.RemoveIndicator(indicator.UniqueId);

            RemoveIndicatorFromIndex(indicator);
            RemoveIndicatorFromSelection(indicator);
        }

        private bool SelectedIndicatorIsActive()
        {
            if(null != SelectedIndicator)
                return _selectedIndicators.Contains(SelectedIndicator);
            return false;
        }

        private void RaiseActiveIndicatorChanged(Indicator indicator)
        {
            if (null != OnActiveIndicatorChanged)
                OnActiveIndicatorChanged(indicator);
        }

        #endregion

        private enum IndicatorSettingsDialogResult
        {
            None,
            NewIndicatorCreated,
            ExistingIndicatorEdited,
            ExistingActiveIndicatorEdited
        }
    }
}
