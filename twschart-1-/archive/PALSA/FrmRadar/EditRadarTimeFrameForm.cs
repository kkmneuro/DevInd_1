using System;
//using FundXchange.Model.ViewModels.Charts;
using Nevron.UI.WinForm.Controls;
using PALSA.Cls;

namespace PALSA.FrmRadar
{
    public partial class EditRadarTimeFrameForm : NForm
    {
        public Periodicity Periodicity
        {
            get 
            { 
                return GetPeriodicity();
            }
            set
            {
                cboPeriodicity.SelectedIndex = GetIndexOfPeriodicity(value);
            }
        }

        public int Interval
        {
            get { return Convert.ToInt32(cboInterval.Text); }
        }

        public EditRadarTimeFrameForm()
        {
            InitializeComponent();
            cboPeriodicity.SelectedIndex = 0;
            cboInterval.SelectedIndex = 1;
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
                default:
                    break;
            }
        }
    }
}
