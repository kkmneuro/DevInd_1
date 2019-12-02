using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
using PALSA.ClsRadar;
using PALSA.Cls;
//using FundXchange.Model.ViewModels.Charts;
//using FundXchange.Model.ViewModels.RadarView;

namespace PALSA.FrmRadar
{
    public partial class FormatRadarGridForm : NForm
    {
        public FormatRadarGridForm(RadarTemplate currentTemplate)
        {
            InitializeComponent();

            if (null == currentTemplate)
                currentTemplate = RadarTemplate.Default;

            DefinedTemplate = RadarTemplate.Clone(currentTemplate);

            InitializeFormValues(currentTemplate);
        }

        #region Private members

        private const string FONT_DESCRIPTION_FORMAT = "Current font: {0}, {1}, {2}";

        private string PageName
        {
            get { return txtPageName.Text; }
            set { txtPageName.Text = value; }
        }

        private Periodicity Periodicity
        {
            get 
            { 
                return GetPeriodicity(); 
            }
            set 
            {
                cboPeriodicity.SelectedIndex = GetIndexOfPeriodicity(value);
                DefinedTemplate.IndicatorPeriodicity = value;
            }
        }

        private int Interval
        {
            get { return Convert.ToInt32(cboInterval.SelectedItem.ToString()); }
            set
            {
                cboInterval.SelectedIndex = GetIndexOfInterval(value);
                DefinedTemplate.IndicatorInterval = value;
            }
        }

        private int StartingBars
        {
            get 
            {
                try
                {
                    return Convert.ToInt32(cboNumberOfBars.Text);
                }
                catch (FormatException)
                {
                    return 100;
                }
            }
            set
            {
                cboNumberOfBars.SelectedIndex = GetIndexOfBarCount(value);
                DefinedTemplate.StartingBars = value;
            }
        }

        private bool IndicatorsEnabled
        {
            get { return chkIndicatorsEnabled.Checked; }
            set
            {
                chkIndicatorsEnabled.Checked = value;
                DefinedTemplate.IndicatorsEnabled = value;
            }
        }

        private Font _gridFont;

        private bool ShowHorizontalGridLines
        {
            get { return chkShowHorizontalLines.Checked; }
            set
            {
                chkShowHorizontalLines.Checked = value;
                DefinedTemplate.ShowHorizontalGridLines = value;
            }
        }

        private bool ShowVerticalGridLines
        {
            get { return chkShowVerticalLines.Checked; }
            set 
            { 
                chkShowVerticalLines.Checked = value;
                DefinedTemplate.ShowVerticalGridLines = value;
            }
        }

        private Color GridLineColour
        {
            get { return btnLineColour.BackColor; }
            set
            {
                btnLineColour.BackColor = value;
                DefinedTemplate.GridLineColor = value;
            }
        }

        private IndicatorColumnTemplate SelectedColumnTemplate
        {
            get
            {
                if(null != lstIndicators.SelectedItemTag)
                {
                    return DefinedTemplate.FindTemplate(lstIndicators.SelectedItemTag.ToString());
                }
                return null;
            }
        }

        #endregion

        #region Public members

        public RadarTemplate DefinedTemplate { get; private set; }

        #endregion

        #region Helper Methods

        private void InitializeFormValues(RadarTemplate currentTemplate)
        {
            PageName = currentTemplate.PageName;
            IndicatorsEnabled = currentTemplate.IndicatorsEnabled;
            Interval = currentTemplate.IndicatorInterval;
            Periodicity = currentTemplate.IndicatorPeriodicity;
            StartingBars = currentTemplate.StartingBars;
            ShowHorizontalGridLines = currentTemplate.ShowHorizontalGridLines;
            ShowVerticalGridLines = currentTemplate.ShowVerticalGridLines;
            GridLineColour = currentTemplate.GridLineColor;

            _gridFont = currentTemplate.Font;
            lblCurrentFont.Text = string.Format(FONT_DESCRIPTION_FORMAT, currentTemplate.Font.Name, currentTemplate.Font.Style, currentTemplate.Font.Size);
            lblCurrentFont.Font = _gridFont;

            foreach(IndicatorColumnTemplate columnTemplate in currentTemplate.ColumnTemplates)
            {                   
                int imageIndex = columnTemplate.AssociatedIndicator.IsUserDefined ? 1 : 0;
                lstIndicators.Items.Add(new NListBoxItem(imageIndex, columnTemplate.AssociatedIndicator.Name) { Tag = columnTemplate.ColumnIdentifier });

                AddToSortTab(columnTemplate);
            }
        }

        private void AddToSortTab(IndicatorColumnTemplate columnTemplate)
        {
            //cboSortColumn1.Items.Add(new NListBoxItem(0, columnTemplate.AssociatedIndicator.Name) { Tag = columnTemplate.ColumnIdentifier });
            //if(columnTemplate.SortOrder.Equals(1))
            //{
            //    cboSortColumn1.SelectedIndex = cboSortColumn1.Items.Count - 1;
            //}

            //cboSortColumn2.Items.Add(new NListBoxItem(0, columnTemplate.AssociatedIndicator.Name) { Tag = columnTemplate.ColumnIdentifier });
            //if (columnTemplate.SortOrder.Equals(2))
            //{
            //    cboSortColumn1.SelectedIndex = cboSortColumn2.Items.Count - 1;
            //}

            //cboSortColumn3.Items.Add(new NListBoxItem(0, columnTemplate.AssociatedIndicator.Name) { Tag = columnTemplate.ColumnIdentifier });
            //if (columnTemplate.SortOrder.Equals(3))
            //{
            //    cboSortColumn3.SelectedIndex = cboSortColumn3.Items.Count - 1;
            //}

            //cboSortColumn4.Items.Add(new NListBoxItem(0, columnTemplate.AssociatedIndicator.Name) { Tag = columnTemplate.ColumnIdentifier });
            //if (columnTemplate.SortOrder.Equals(4))
            //{
            //    cboSortColumn4.SelectedIndex = cboSortColumn4.Items.Count - 1;
            //}
        }

        private void FinalizeRadarTemplateFromSettings()
        {
            DefinedTemplate.PageName = PageName;
            DefinedTemplate.Font = _gridFont;
            DefinedTemplate.IndicatorsEnabled = IndicatorsEnabled;
            DefinedTemplate.IndicatorPeriodicity = Periodicity;
            DefinedTemplate.StartingBars = StartingBars;
            DefinedTemplate.IndicatorInterval = Interval;
            DefinedTemplate.ShowHorizontalGridLines = ShowHorizontalGridLines;
            DefinedTemplate.ShowVerticalGridLines = ShowVerticalGridLines;
            DefinedTemplate.GridLineColor = GridLineColour;
        }

        private Periodicity GetPeriodicity()
        {
            switch (cboPeriodicity.Text)
            {
                case "Second":
                    return Periodicity.Secondly;
                case "Hour":
                    return Periodicity.Hourly;
                case "Day":
                    return Periodicity.Daily;
                case "Week":
                    return Periodicity.Weekly;
                default:
                    return Periodicity.Minutely;
            }
        }

        private string GetPeriodicity(Periodicity periodicity)
        {
            switch (periodicity)
            {
                case Periodicity.Hourly:
                    return "Hour";
                case Periodicity.Daily:
                    return "Day";
                case Periodicity.Weekly:
                    return "Week";
                default:
                    return "Minute";
            }
        }

        private int GetIndexOfPeriodicity(Periodicity periodicity)
        {
            string expectedStringValue = GetPeriodicity(periodicity);

            foreach (NListBoxItem item in cboPeriodicity.Items)
            {
                if (item.Text == expectedStringValue)
                    return item.Index;
            }
            return 0;
        }

        private int GetIndexOfBarCount(int barCount)
        {
            foreach (NListBoxItem item in cboNumberOfBars.Items)
            {
                if (item.Text == barCount.ToString())
                    return item.Index;
            }
            return 0;
        }

        private int GetIndexOfInterval(int interval)
        {
            foreach (NListBoxItem item in cboInterval.Items)
            {
                if (item.Text == interval.ToString())
                    return item.Index;
            }
            return 0;
        }

        private void ClearSortIndexesFrom(int sortIndex)
        {
            foreach (var columnTempate in DefinedTemplate.ColumnTemplates)
            {
                if (columnTempate.SortOrder >= sortIndex)
                    columnTempate.SortOrder = -1;
            }
        }

        #endregion

        #region Event Handlers

        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                if (null != _gridFont)
                    dialog.Font = _gridFont;

                dialog.AllowScriptChange = false;
                dialog.FontMustExist = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _gridFont = dialog.Font;
                    lblCurrentFont.Text = string.Format(FONT_DESCRIPTION_FORMAT, _gridFont.Name, _gridFont.Style, _gridFont.Size);
                    lblCurrentFont.Font = _gridFont;
                }
            }
        }

        private void lstIndicators_SelectedIndexChanged(object sender, EventArgs e)
        {
            string columnIdentifier = lstIndicators.SelectedItemTag.ToString();
            if (!string.IsNullOrEmpty(columnIdentifier))
            {
                IndicatorColumnTemplate associatedTemplate = DefinedTemplate.FindTemplate(columnIdentifier);
                if (associatedTemplate != null)
                {
                    nudOverBoughtValue.Value = associatedTemplate.OverBoughtValue;
                    nudOverSoldValue.Value = associatedTemplate.OverSoldValue;
                    btnSetPositiveColour.BackColor = associatedTemplate.OverBoughtConditionColor;
                    btnSetNegativeColour.BackColor = associatedTemplate.OverSoldConditionColor;
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            FinalizeRadarTemplateFromSettings();
        }

        private void btnSetColour_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (null != clickedButton)
            {
                using (NColorDialog dialog = new NColorDialog(clickedButton.BackColor))
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        clickedButton.BackColor = dialog.Color;

                        if (clickedButton.Equals(btnSetPositiveColour))
                        {
                            if (null != SelectedColumnTemplate)
                            {
                                SelectedColumnTemplate.OverBoughtConditionColor = dialog.Color;
                            }
                        }
                        else if (clickedButton.Equals(btnSetNegativeColour))
                        {
                            if (null != SelectedColumnTemplate)
                            {
                                SelectedColumnTemplate.OverSoldConditionColor = dialog.Color;
                            }
                        }
                        else
                        {
                            GridLineColour = clickedButton.BackColor;
                        }
                    }
                }
            }
        }

        private void nudOverBoughtValue_ValueChanged(object sender, EventArgs e)
        {
            if (null != SelectedColumnTemplate)
            {
                SelectedColumnTemplate.OverBoughtValue = Convert.ToInt32(nudOverBoughtValue.Value);
            }
        }

        private void nudOverSoldValue_ValueChanged(object sender, EventArgs e)
        {
            if (null != SelectedColumnTemplate)
            {
                SelectedColumnTemplate.OverSoldValue = Convert.ToInt32(nudOverSoldValue.Value);
            }
        }

        private void cboSortColumn1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (null != cboSortColumn1.Items[cboSortColumn1.SelectedIndex].Tag)
            //{
            //    string itemTag = cboSortColumn1.Items[cboSortColumn1.SelectedIndex].Tag.ToString();
            //    if (null != itemTag)
            //    {
            //        var columnTemplate = DefinedTemplate.FindTemplate(itemTag);
            //        columnTemplate.SortOrder = 1;
            //        cboSortColumn2.Enabled = true;
            //        return;
            //    }
            //}
            //cboSortColumn2.Enabled = false;
            //cboSortColumn2.SelectedIndex = 0;
            //ClearSortIndexesFrom(1);
        }

        private void cboSortColumn2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (null != cboSortColumn2.Items[cboSortColumn2.SelectedIndex].Tag)
            //{
            //    string itemTag = cboSortColumn2.Items[cboSortColumn2.SelectedIndex].Tag.ToString();
            //    if (null != itemTag)
            //    {
            //        var columnTemplate = DefinedTemplate.FindTemplate(itemTag);
            //        columnTemplate.SortOrder = 2;
            //        cboSortColumn3.Enabled = true;
            //        return;
            //    }
            //}
            //cboSortColumn3.Enabled = false;
            //cboSortColumn3.SelectedIndex = 0;
            //ClearSortIndexesFrom(2);
        }

        private void cboSortColumn3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (null != cboSortColumn3.Items[cboSortColumn3.SelectedIndex].Tag)
            //{
            //    string itemTag = cboSortColumn3.Items[cboSortColumn3.SelectedIndex].Tag.ToString();
            //    if (null != itemTag)
            //    {
            //        var columnTemplate = DefinedTemplate.FindTemplate(itemTag);
            //        columnTemplate.SortOrder = 3;
            //        cboSortColumn4.Enabled = true;
            //        return;
            //    }
            //}
            //cboSortColumn4.Enabled = false;
            //cboSortColumn4.SelectedIndex = 0;
            //ClearSortIndexesFrom(3);
        }

        private void cboSortColumn4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (null != cboSortColumn4.Items[cboSortColumn4.SelectedIndex].Tag)
            //{
            //    string itemTag = cboSortColumn4.Items[cboSortColumn4.SelectedIndex].Tag.ToString();
            //    if (null != itemTag)
            //    {
            //        var columnTemplate = DefinedTemplate.FindTemplate(itemTag);
            //        columnTemplate.SortOrder = 4;
            //        return;
            //    }
            //}
            //ClearSortIndexesFrom(4);
        }

        #endregion

        private void cboPeriodicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboPeriodicity.Text)
            {
                case "Hour":
                case "Day":
                case "Week":
                    {
                        cboInterval.SelectedIndex = 0;
                        cboInterval.Enabled = false;
                    }
                    break;
                case "Minute":
                    cboInterval.Enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
}
