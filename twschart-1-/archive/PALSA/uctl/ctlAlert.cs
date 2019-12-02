using System;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
//using FundXchange.Model.ViewModels.Charts;
//using FundXchange.Infrastructure;
//using FundXchange.Model.Controllers;
//using FundXchange.Model.AuthenticationService;
using Nevron.UI.WinForm.Controls;
using STOCKCHARTXLib;
//using M4Controls.Classes;
using TradeScriptLib;
using System.Diagnostics;
using M4.Workspace;
//using M4.Scripts;
//using FundXchange.Model.Infrastructure;
//using FundXchange.Model.Repositories;
//using FundXchange.Model.PortfolioService;
//using FundXchange.Model.Gateways;
//using FundXchange.Model.AlertService;

namespace PALSA.uctl
{
    public partial class ctlAlert : UserControl//, IDataSubscriber
    {
        #region Initialization and Members

        private const string TRADESCRIPT_LICENSE = "XRT93NQR79ABTW788XR48";
        private bool m_changed;

        private readonly FrmMain m_frmMain;
        private WPFChartControl m_chart;
        private PALSA.Cls.AlertController _Controller;

        private static readonly CultureInfo usCulture = new CultureInfo("en-US");

        private Alert oBuyAlert;
        private Alert oSellAlert;
        private Alert oExitLongAlert;
        private Alert oExitShortAlert;

        private bool m_BuyAlertProcessed;
        private bool m_SellAlertProcessed;
        private bool m_ExitLongAlertProcessed;
        private bool m_ExitShortAlertProcessed;
        private static readonly AlertScriptService.AlertScriptServiceClient AlertServ = new AlertScriptService.AlertScriptServiceClient();
        private AlertScriptService.AlertScripts[] AlertScripts; //= AlertServ.GetAlertScripts();

        public ctlAlert(FrmMain oMain)
        {
            InitializeComponent();

            m_frmMain = oMain;
            _Controller = new Cls.AlertController();

            ApplySecuritySettings();
            InitializeAlertTypes();
            PopulatePeriodicity();

            SetupFocusEvents();
            SetupAlertEvents();
            UpdateControlPalettes(oMain);

            m_ListAlerts.ForeColor = Color.Black;
            m_ListAlerts.BackColor = Color.FromArgb(131, 131, 131);
        }

        private void PopulatePeriodicity()
        {
            cboPeriodicity.Items.Add("Minute");
            cboPeriodicity.Items.Add("Hour");
            cboPeriodicity.Items.Add("Day");
            cboPeriodicity.Items.Add("Week");
        }

        private void ApplySecuritySettings()
        {
            if (!IsTradingUser())
            {
                chkEnableOrder.Visible = false;
                pnlTrade.Visible = false;
            }
        }

        private bool IsTradingUser()
        {
            return true;//_User.Account.Product == Product.QuoteBoardLite || _User.Account.Product == Product.QuoteBoardPro;
        }

        private void InitializeAlertTypes()
        {
            oBuyAlert = new Alert { License = TRADESCRIPT_LICENSE };
            oSellAlert = new Alert { License = TRADESCRIPT_LICENSE };
            oExitLongAlert = new Alert { License = TRADESCRIPT_LICENSE };
            oExitShortAlert = new Alert { License = TRADESCRIPT_LICENSE };
        }

        private void UpdateControlPalettes(FrmMain oMain)
        {
            this.grpAlerts.Palette.UpdateFrom(oMain.Palette);
            this.grpData.Palette.UpdateFrom(oMain.Palette);
            this.grpExpires.Palette.UpdateFrom(oMain.Palette);
            this.grpOrderType.Palette.UpdateFrom(oMain.Palette);
            this.grpSaveLoad.Palette.UpdateFrom(oMain.Palette);
            this.grpTradeOptions.Palette.UpdateFrom(oMain.Palette);
            this.tabScripts.Palette.UpdateFrom(oMain.Palette);

            this.grpAlerts.ApplyPalette(oMain.Palette);
            this.grpData.ApplyPalette(oMain.Palette);
            this.grpExpires.ApplyPalette(oMain.Palette);
            this.grpOrderType.ApplyPalette(oMain.Palette);
            this.grpSaveLoad.ApplyPalette(oMain.Palette);
            this.grpTradeOptions.ApplyPalette(oMain.Palette);
            this.tabScripts.ApplyPalette(oMain.Palette);
        }

        private void SetupAlertEvents()
        {
            oBuyAlert.Alert += oBuyAlert_Alert;
            oSellAlert.Alert += oSellAlert_Alert;
            oExitLongAlert.Alert += oExitLongAlert_Alert;
            oExitShortAlert.Alert += oExitShortAlert_Alert;
        }

        private void SetupFocusEvents()
        {
            txtAlertName.GotFocus += (sender, e) => Text_Focus((TextBoxBase)sender);
            txtBars.GotFocus += (sender, e) => Text_Focus((TextBoxBase)sender);
            txtStopLimit.GotFocus += (sender, e) => Text_Focus((TextBoxBase)sender);
            txtSymbol.GotFocus += (sender, e) => Text_Focus((TextBoxBase)sender);
            txtSymbolOrder.GotFocus += (sender, e) => Text_Focus((TextBoxBase)sender);
        }
        #endregion

        #region Controls

        private void ctlAlert_Load(object sender, EventArgs e)
        {
            txtAlertName.Focus();
            LoadPortfolios();
            LoadAlertScripts();
            cboPeriodicity.SelectedIndex = 0;

            //TODO: add/remove your exchanges here:
            cboExchanges.Items.Add("OEC");
            cboExchanges.SelectedIndex = 0;

            m_changed = false;
        }

        //Enables/Disables controls for when the script is running
        private void EnableControls(bool Enable)
        {
            grpSaveLoad.Enabled = Enable;
            grpData.Enabled = Enable;
            tabScripts.Enabled = Enable;
            pnlTrade.Enabled = Enable;
            chkEnableOrder.Enabled = Enable;
        }

        //Turns the alerts on and off
        private void cmdEnable_Click(object sender, EventArgs e)
        {
            if (!VerifyForm())
                return;

            if (cmdEnable.Text == "&Enable Alerts")
            {
                if (!StartAlerts())
                {
                    EnableControls(true);//Kuldeep
                    EnableAlerts();
                }
            }
            else
            {
                cmdEnable.Text = "&Enable Alerts";
                cmdEnable.Border.BaseColor = Color.LimeGreen;
                EnableControls(true);
                StopAlerts();
            }
            cmdEnable.Border.Update();
            m_changed = true;
        }

        

        private void EnableAlerts()
        {
            cmdEnable.Text = "&Enable Alerts";
            cmdEnable.Border.BaseColor = Color.LimeGreen;
            cmdEnable.Border.Update();
            cmdEnable.Enabled = true;
        }

        //Display the TradeScript documentation
        private void cmdDocumentation_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Documents\TradeScript.pdf");
            //string path = Application.StartupPath+ "\\TradeScript.pdf";
            m_frmMain.OpenURL(path, "TradeScript Help");
        }

        private void ctlAlert_Resize(object sender, EventArgs e)
        {
            cmdEnable.Top = (tabScripts.Top + tabScripts.Height) + 10;
            cmdDocumentation.Top = (tabScripts.Top + tabScripts.Height) + 10;
            pnlTrade.Top = (tabScripts.Top + tabScripts.Height) + 20;
            chkEnableOrder.Top = (tabScripts.Top + tabScripts.Height) + 10;
            m_ListAlerts.Columns[1].Width = (grpAlerts.Width - m_ListAlerts.Columns[0].Width) - 8;
            grpAlerts.Width = this.Width - (tabScripts.Location.X + tabScripts.Width) - 10;
        }

        //Handles GotGocus for several text boxes
        private static void Text_Focus(TextBoxBase textBox)
        {
            textBox.SelectAll();
        }

        private void Control_AlertFlagsChanged(object sender, EventArgs e)
        {
            m_changed = true;
            ResetAlertFlags();
        }

        private void txtSymbol_Leave(object sender, EventArgs e)
        {
            txtSymbol.Text = txtSymbol.Text.ToUpper();
        }

        private void ResetAlertFlags()
        {
            m_BuyAlertProcessed = false;
            m_SellAlertProcessed = false;
            m_ExitLongAlertProcessed = false;
            m_ExitShortAlertProcessed = false;
        }

        private void chkEnableOrder_CheckedChanged(object sender, EventArgs e)
        {
            m_changed = true;
            pnlTrade.Enabled = chkEnableOrder.Checked;
            if (chkEnableOrder.Checked)//Kul
            {
                //m_frmMain.Speak("automated trading enabled");
                //m_frmMain.Speak("review automated license");
            }
            else
            {
                //m_frmMain.Speak("automated trading disabled");
            }
        }

        private void Control_Changed(object sender, EventArgs e)
        {
            m_changed = true;
        }

        #endregion

        #region Save/Load

        //Loads the list of available portfolios
        private void LoadPortfolios()
        {
            //Kul
            //AddPortfoliosToCombobox(_User.DataPortfolios);
        }
        //Kul
        //private void AddPortfoliosToCombobox(DataPortfolioDTO[] portfolios)
        //{
        //    for (int n = 0; n <= portfolios.Length - 1; n++)
        //    {
        //        cmbPortfolio.Items.Add(portfolios[n].PortfolioName.Replace("Portfolio: ", ""));
        //        cmbPortfolio.Items[cmbPortfolio.Items.Count - 1].Tag = "";
        //    }
        //}

        //Loads the list of previously saved alerts
        private void LoadAlertScripts()
        {
            AlertScripts= AlertServ.GetAlertScripts();
            AddAlertScriptsToCombobox(AlertScripts);
        }

        private void AddAlertScriptsToCombobox(AlertScriptService.AlertScripts[] AlertScripts)
        {
            cboAlerts.Items.Clear();
            foreach (AlertScriptService.AlertScripts alertScript in AlertScripts)
            {
                cboAlerts.Items.Add(new NListBoxItem(alertScript.IsUserDefined ? 1 : 0, alertScript.AlertName));
            }
        }

        private bool VerifyForm()
        {
            uint tmpVal;
           
            if (txtAlertName.Text == "")
            {
                txtAlertName.Focus();
                MessageBox.Show("Please enter a name for this alert", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSymbol.Text == "")
            {
                txtSymbol.Focus();
                MessageBox.Show("Please enter a symbol", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboPeriodicity.Text == "")
            {
                cboPeriodicity.Focus();
                MessageBox.Show("Please select a periodicity", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((txtBars.Text == "") | !PALSA.Cls.Utils.IsNumeric(txtBars.Text))
            {
                MessageBox.Show("Please enter the number of bars", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!uint.TryParse(txtBars.Text, out tmpVal))
            {
                NotifyInvalidTextbox(txtBars, "Please enter the number of bars");
                return false;
            }
            if (chkEnableOrder.Checked)
            {
                txtSymbolOrder.Text = txtSymbolOrder.Text.Trim();
                if (txtSymbolOrder.TextLength == 0)
                {
                    txtSymbolOrder.Focus();
                    MessageBox.Show("Please enter a symbol", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        private void NotifyInvalidTextbox(TextBox textbox, string message)
        {
            textbox.SelectAll();
            textbox.Focus();
            MessageBox.Show(message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveAlert(false);
        }

        public void SaveAlert()
        {
            SaveAlert(false);
        }

        private bool PromptSaveAlert(string alertName, bool prompt)
        {
            PALSA.ClsRadar.IIndicatorRepository indicatorRepository = new PALSA.ClsRadar.IndicatorRepository();
            if (prompt)
            {
                if (string.IsNullOrEmpty(alertName))
                    alertName = "Untitled";
                else if (!indicatorRepository.ScriptNameIsValid(alertName))
                    alertName += " (Custom)";
                
                if (MessageBox.Show(String.Format("Save alert '{0}'?", alertName), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }
            return true;
        }

        public void SaveAlert(bool Prompt)
        {
            string alertName = txtAlertName.Text;
            if (PromptSaveAlert(alertName, Prompt) && VerifyForm())
            {
                cmdSave.Enabled = false;
                cmdDelete.Enabled = false;
                cboAlerts.Enabled = false;

                AlertScriptService.AlertScripts newAlertScript = GetAlertScriptFromForm();
                //_Controller.SaveAlertScript(newAlertScript);

                AlertScriptService.AlertScripts newUserAlert = new AlertScriptService.AlertScripts();
                newUserAlert.AlertName = newAlertScript.AlertName;
                newUserAlert.Bars = newAlertScript.Bars;
                newUserAlert.BuyScript = newAlertScript.BuyScript;
                newUserAlert.DayHours = newAlertScript.DayHours;
                newUserAlert.Enabled = newAlertScript.Enabled;
                newUserAlert.EndOfDay = newAlertScript.EndOfDay;
                newUserAlert.Exchange = newAlertScript.Exchange;
                newUserAlert.ExitLongScript = newAlertScript.ExitLongScript;
                newUserAlert.ExitShortScript = newAlertScript.ExitShortScript;
                newUserAlert.GTC = newAlertScript.GTC;
                newUserAlert.GTCHours = newAlertScript.GTCHours;
                newUserAlert.Interval = newAlertScript.Interval;
                newUserAlert.Limit = newAlertScript.Limit;
                newUserAlert.Market = newAlertScript.Market;
                newUserAlert.Period = newAlertScript.Period;
                newUserAlert.Portfolio = newAlertScript.Portfolio;
                newUserAlert.Quantity = newAlertScript.Quantity;
                newUserAlert.SellScript = newAlertScript.SellScript;
                newUserAlert.StopLimit = newAlertScript.StopLimit;
                newUserAlert.StopLimitValue = newAlertScript.StopLimitValue;
                newUserAlert.StopMarket = newAlertScript.StopMarket;
                newUserAlert.Symbol = newAlertScript.Symbol;

                //_User.AlertScripts = _User.AlertScripts.Union(new List<FundXchange.Model.AlertService.AlertScriptDTO>() { newUserAlert }).ToArray();

                PALSA.ClsRadar.IIndicatorRepository indicatorRepository = new PALSA.ClsRadar.IndicatorRepository();
                indicatorRepository.RefreshIndicators();

                LoadAlertScriptsIfNotInDropdown(alertName);

                UpdateTabName(txtAlertName.Text);
                cmdSave.Enabled = true;

                if (cboAlerts.SelectedIndex > -1)
                {
                    cmdDelete.Enabled = true;
                }
                cboAlerts.Enabled = true;
            }
        }

        private void LoadAlertScriptsIfNotInDropdown(string alertName)
        {
            bool found = DoesAlertScriptExistInAlertDropdown();
            if (!found)
            {
                LoadAlertScripts();
                SetAlertScriptSelectedIndex(alertName);
            }
        }

        private bool DoesAlertScriptExistInAlertDropdown()
        {
            bool found = false;
            for (short n = 0; n <= cboAlerts.Items.Count - 1; n++)
            {
                if (cboAlerts.Items[n].Text == txtAlertName.Text)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        private void SetAlertScriptSelectedIndex(string alertName)
        {
            for (short n = 0; n <= cboAlerts.Items.Count - 1; n++)
            {
                if (cboAlerts.Items[n].Text == alertName)
                {
                    cboAlerts.SelectedIndex = n;
                    break;
                }
            }
        }

        private AlertScriptService.AlertScripts GetAlertScriptFromForm()
        {
            var alertScript = new AlertScriptService.AlertScripts();

            alertScript.AlertName = txtAlertName.Text;
            alertScript.Symbol = txtSymbol.Text;
            alertScript.Period = cboPeriodicity.Text;
            alertScript.Interval = Convert.ToInt32(cboInterval.Text);
            alertScript.Bars = (txtBars.Text);
            alertScript.BuyScript = txtBuyScript.Text;
            alertScript.SellScript = txtSellScript.Text;
            alertScript.ExitLongScript = txtExitLongScript.Text;
            alertScript.ExitShortScript = txtExitShortScript.Text;
            //alert.en = chkEnableOrder.Text;
            alertScript.Portfolio = cmbPortfolio.Text;
            //alert.Symbol = txtSymbolOrder.Text;
            alertScript.Exchange = cboExchanges.Text;
            alertScript.Quantity = Convert.ToInt32(udQuantity.Text);
            alertScript.Market = rdoMarket.Checked;
            alertScript.StopMarket = rdoStopMarket.Checked;
            alertScript.Limit = rdoLimit.Checked;
            alertScript.StopLimit = rdoStopLimit.Checked;
            alertScript.StopLimitValue = txtStopLimit.Text;
            alertScript.EndOfDay = rdoDay.Checked;
            alertScript.GTC = rdoGTC.Checked;
            alertScript.DayHours = rdoDayHours.Checked;
            alertScript.GTCHours = rdoGTCHours.Checked;
            //alert.Enabled = cmdEnable.ch;

            return alertScript;
        }

        private void UpdateTabName(string name)
        {
            foreach (NUIDocument doc in m_frmMain.m_DockManager.DocumentManager.Documents)
            {
                if (doc.Client.Name == "ctlAlert")
                {
                    ctlAlert alert = (ctlAlert)doc.Client;
                    if (alert.Handle == Handle)
                    {
                        doc.Text = String.Format("Alert: {0}", name);
                    }
                }
            }
        }

        private void cboAlerts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSymbol.Text))
            {
                MessageBox.Show("Please Enter Symbol", "EA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (var item in AlertScripts)
            {
                item.Symbol = txtSymbol.Text;
            }

            if (m_changed && cboAlerts.Enabled)
            {
                SaveAlert(true);
            }
            LoadAlert();
        }

        private void LoadAlert()
        {
            string alertName = cboAlerts.Text;
            if (alertName == "") return;
            cmdSave.Enabled = false;
            cmdDelete.Enabled = false;
            cboAlerts.Enabled = false;

            var alertScript = AlertScripts.FirstOrDefault(a => a.AlertName == alertName);
            if (alertScript == null)
                return;
            SetAlertScriptFormValues(alertScript);

            txtAlertName.Text = cboAlerts.Text;
            cmdEnable.Text = "&Enable Alerts";
            cmdEnable.Border.BaseColor = Color.LimeGreen;
            EnableControls(true);
            StopAlerts();
            cmdEnable.Border.Update();
            m_changed = false;
            UpdateTabName(txtAlertName.Text);
            cmdSave.Enabled = true;
            cmdDelete.Enabled = true;
            cboAlerts.Enabled = true;
            if (cboAlerts.SelectedIndex == -1)
            {
                cmdDelete.Enabled = false;
            }
        }

        private void SetAlertScriptFormValues(AlertScriptService.AlertScripts alertScript)
        {
            if (alertScript == null) throw new ArgumentNullException("alertScript");
            SetSelectedCombobox(alertScript.Period, cboPeriodicity);

            int intervalIndex = FindIntervalIndex(alertScript.Interval);
            cboInterval.SelectedIndex = intervalIndex;
            txtBars.Text = alertScript.Bars.ToString();
            txtBuyScript.Text = alertScript.BuyScript;
            txtSellScript.Text = alertScript.SellScript;
            txtExitLongScript.Text = alertScript.ExitLongScript;
            txtExitShortScript.Text = alertScript.ExitShortScript;

            txtSymbol.Text = alertScript.Symbol;
            //alertScript.Symbol = txtSymbol.Text;
            SetSelectedCombobox(alertScript.Portfolio, cmbPortfolio);

            SetSelectedCombobox(alertScript.Exchange, cboExchanges);

            udQuantity.Text = alertScript.Quantity.ToString();
            rdoMarket.Checked = alertScript.Market;
            rdoStopMarket.Checked = alertScript.StopMarket;
            rdoLimit.Checked = alertScript.Limit;
            rdoStopLimit.Checked = alertScript.StopLimit;
            txtStopLimit.Text = alertScript.StopLimitValue;
            rdoDay.Checked = alertScript.EndOfDay;
            rdoGTC.Checked = alertScript.GTC;
            rdoDayHours.Checked = alertScript.DayHours;
            rdoGTCHours.Checked = alertScript.GTCHours;
        }

        private void SetSelectedCombobox(string value, NComboBox combo)
        {
            for (short n = 0; n <= combo.Items.Count - 1; n = (short)(n + 1))
            {
                if (combo.Items[n].Text == value)
                {
                    combo.SelectedIndex = n;
                    break;
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if ((cboAlerts.Text != "") &&
                (MessageBox.Show(String.Format("Delete alert {0}?", cboAlerts.Text), "Confirm", MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Question) == DialogResult.OK))
            {
                //Kul
                //_Controller.RemoveAlertScript(cboAlerts.Text);
                //_User.Alerts = _User.Alerts.Where(a => a.AlertName != cboAlerts.Text).ToArray();
                LoadAlertScripts();
            }
        }

        #endregion

        #region Alert Processing

        private static DateTime lastSpokenAlertDate;

        private void Alert_Occurred(string symbol, string broadcastAlertName, string broadcastAlertType)
        {   
            try
            {
                BroadcastAlert(broadcastAlertName, broadcastAlertType);

                if (chkEnableOrder.Checked)
                {
                    //SubmitOrder(orderSide);
                }
                else if ((DateTime.UtcNow - lastSpokenAlertDate).TotalSeconds > 15) //limit
                {
                    PlayAlertNotificationSound();
                }
            }
            catch { }
        }

        private void PlayAlertNotificationSound()
        {
            if (File.Exists(Application.StartupPath + @"\Resx\ScriptAlert.wav"))
            {
                //Kul
                m_frmMain.Speak("trade alert,[" + txtSymbol.Text + "]");
                lastSpokenAlertDate = DateTime.UtcNow;
            }
        }

        private void oBuyAlert_Alert(string symbol, string name)
        {
            if (!m_BuyAlertProcessed)
            {
                Alert_Occurred(symbol, "Buy Alert", "LONG");
                m_chart.AddSymbolObjetc(name, "Buy Alert");
                //m_chart.StockChartX1.AddSymbolObject(m_chart.Panel, m_chart.Value, m_chart.RecordCount, SymbolType.soBuySymbolObject, name, string.Format("Long at R for Rands {0}", m_chart.Value));
            }
            m_BuyAlertProcessed = true;

            //m_chart.StockChartX1.Update();
            //m_chart.StockChartX1.ForcePaint();
        }

        private void oSellAlert_Alert(string symbol, string name)
        {
            if (!m_SellAlertProcessed)
            {
                Alert_Occurred(symbol, "Sell Alert", "SHORT");
                m_chart.AddSymbolObjetc(name, "Sell Alert");
                //m_chart.StockChartX1.AddSymbolObject(m_chart.Panel, m_chart.Value, m_chart.RecordCount, SymbolType.soSellSymbolObject, name, string.Format("Short at R for Rands {0}", m_chart.Value));
            }
            m_SellAlertProcessed = true;

            //m_chart.StockChartX1.Update();
            //m_chart.StockChartX1.ForcePaint();
        }

        private void oExitLongAlert_Alert(string symbol, string name)
        {
            if (!m_ExitLongAlertProcessed)
            {
                Alert_Occurred(symbol, "Exit-Long Alert", "EXIT");
                m_chart.AddSymbolObjetc(name, "Exit-Long Alert");
                //m_chart.StockChartX1.AddSymbolObject(m_chart.Panel, m_chart.Value, m_chart.RecordCount, SymbolType.soSellSymbolObject, name, string.Format("Exit at R for Rands {0}", m_chart.Value));
            }
            m_ExitLongAlertProcessed = true;

            //m_chart.StockChartX1.Update();
            //m_chart.StockChartX1.ForcePaint();
        }

        private void oExitShortAlert_Alert(string symbol, string name)
        {
            if (!m_ExitShortAlertProcessed)
            {
                Alert_Occurred(symbol, "Exit-Short Alert", "EXIT");
                m_chart.AddSymbolObjetc(name, "Exit-Short Alert");
                //m_chart.StockChartX1.AddSymbolObject(m_chart.Panel, m_chart.Value, m_chart.RecordCount, SymbolType.soExitShortSymbolObject, name, string.Format("Exit at R for Rands {0}", m_chart.Value));
            }
            m_ExitShortAlertProcessed = true;

            //m_chart.StockChartX1.Update();
            //m_chart.StockChartX1.ForcePaint();
        }

        //Stops  alerts
        public void StopAlerts()
        {
            m_ListAlerts.Items.Clear();
            //Kul
            //m_ctlData.RemoveSymbolWatch(txtSymbol.Text, this);
            oBuyAlert.ClearRecords();
            oSellAlert.ClearRecords();
            oExitLongAlert.ClearRecords();
            oExitShortAlert.ClearRecords();

            oBuyAlert.AlertScript = "";
            oSellAlert.AlertScript = "";
            oExitLongAlert.AlertScript = "";
            oExitShortAlert.AlertScript = "";
            tmrUpdate.Enabled = false;
            if (m_chart != null)
                m_chart.Subscribers--;
        }

        //Starts alerts
        public bool StartAlerts()
        {
            PALSA.FrmScanner.ChartSelection selection = new PALSA.FrmScanner.ChartSelection();
            if (!VerifyForm()) return false;
            if (!TestScripts()) return false;

            cmdEnable.Text = "&Disable Alerts";
            cmdEnable.Border.BaseColor = Color.Red;
            EnableControls(false);
            cmdEnable.Border.Update();

            PALSA.Cls.Periodicity periodicity = GetPeriodicity();

            cmdEnable.Enabled = false;
            selection.Periodicity = periodicity;
            selection.Symbol = txtSymbol.Text;
            
            SetSelectionInterval(selection);
            SetSelectionBars(selection);


            m_chart = m_frmMain.LoadRealTimeChart(selection);

            if (m_chart == null) return false; //Failed to get the chart

            m_chart.OnHistoricalData += new Action<List<Cls.BarDataNew>>(m_chart_OnHistoricalData);
            m_chart.ChartDataAdded += m_chart_ChartDataAdded;
            m_chart.ChartDataChanged += m_chart_ChartDataChanged;
            
            //PALSA.Cls.BarDataNew[] bars = m_chart.GetDataFromChart();
            //if (bars.Length < 1)
            //{
            //    MessageBox.Show("UnSupported Symbol", "EA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            //m_chart.Subscribers++; //Increment (deincremented in frmMain UI unload)
            //cmdEnable.Enabled = true;

            //if (bars.Length < 3) return false; //Bad request 

            ////Insert the data into all four instances of TradeScript
            //ResetAlertScripts();
            //for (int n = 0; n <= bars.Length - 1; n++)
            //{
            //    DateTime td = bars[n].TradeDateTime;
            //    double jdate = oBuyAlert.ToJulianDate(td.Year, td.Month, td.Day, td.Hour, td.Minute, td.Second, 0);
            //    oBuyAlert.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice, bars[n].LowPrice, bars[n].ClosePrice,
            //                                (int)Math.Round(bars[n].Volume));
            //    oSellAlert.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice, bars[n].LowPrice, bars[n].ClosePrice,
            //                                 (int)Math.Round(bars[n].Volume));
            //    oExitLongAlert.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice, bars[n].LowPrice,
            //                                     bars[n].ClosePrice, (int)Math.Round(bars[n].Volume));
            //    oExitShortAlert.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice, bars[n].LowPrice,
            //                                      bars[n].ClosePrice, (int)Math.Round(bars[n].Volume));
            //}
            //Kul
            //var backTester = new BackTester(txtBuyScript.Text, txtSellScript.Text, txtExitLongScript.Text,
            //                                txtExitShortScript.Text, 0.001, m_chart.StockChartX1, periodicity);
            //backTester.RunBackTest(bars);

            //if (backTester.IsValid)
            //{
            //    backTester.AddSymbolsToAssociatedChart();

            //    foreach (var tradeSignal in backTester.Alerts)
            //        AddAlertToList(tradeSignal.Key, tradeSignal.Value);
            //}

            // Alerts are turned-on after backtest has been run to avoid data inconsistency
            //InitializeAlertScripts();

            tmrUpdate.Enabled = true;

            return true;
        }

        void m_chart_OnHistoricalData(List<Cls.BarDataNew> obj)
        {
            PALSA.Cls.BarDataNew[] bars = obj.ToArray();//m_chart.GetDataFromChart();
            if (bars.Length < 1)
            {
                MessageBox.Show("UnSupported Symbol", "EA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_chart.Subscribers++; //Increment (deincremented in frmMain UI unload)
            cmdEnable.Enabled = true;

            if (bars.Length < 3) return; //Bad request 

            //Insert the data into all four instances of TradeScript
            ResetAlertScripts();
            for (int n = 0; n <= bars.Length - 1; n++)
            {
                DateTime td = bars[n].TradeDateTime;
                double jdate = oBuyAlert.ToJulianDate(td.Year, td.Month, td.Day, td.Hour, td.Minute, td.Second, 0);
                oBuyAlert.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice, bars[n].LowPrice, bars[n].ClosePrice,
                                            (int)Math.Round(bars[n].Volume));
                oSellAlert.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice, bars[n].LowPrice, bars[n].ClosePrice,
                                             (int)Math.Round(bars[n].Volume));
                oExitLongAlert.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice, bars[n].LowPrice,
                                                 bars[n].ClosePrice, (int)Math.Round(bars[n].Volume));
                oExitShortAlert.AppendRecord(jdate, bars[n].OpenPrice, bars[n].HighPrice, bars[n].LowPrice,
                                                  bars[n].ClosePrice, (int)Math.Round(bars[n].Volume));
            }
            InitializeAlertScripts();
            //EnableControls(true);
            //EnableAlerts();
        }

        private void InitializeAlertScripts()
        {
            oBuyAlert.AlertName = "Buy Script";
            oBuyAlert.AlertScript = txtBuyScript.Text;
            oBuyAlert.Symbol = txtSymbol.Text;

            oSellAlert.AlertName = "Sell Script";
            oSellAlert.AlertScript = txtSellScript.Text;
            oSellAlert.Symbol = txtSymbol.Text;
            
            oExitLongAlert.AlertName = "Exit Long Script";
            oExitLongAlert.AlertScript = txtExitLongScript.Text;
            oExitLongAlert.Symbol = txtSymbol.Text;
            
            oExitShortAlert.AlertName = "Exit Short Script";
            oExitShortAlert.AlertScript = txtExitShortScript.Text;
            oExitShortAlert.Symbol = txtSymbol.Text;
        }

        void m_chart_ChartDataChanged(PALSA.Cls.BarDataNew barData)
        {
            //double jdate = m_chart.StockChartX1.ToJulianDate(barData.TradeDateTime.Year, barData.TradeDateTime.Month,
            //                                                             barData.TradeDateTime.Day, barData.TradeDateTime.Hour,
            //                                                             barData.TradeDateTime.Minute, barData.TradeDateTime.Second);

            double jdate = barData.TradeDateTime.ToOADate();
            oBuyAlert.EditRecord(jdate, barData.OpenPrice, barData.HighPrice, barData.LowPrice, barData.ClosePrice, (int) barData.Volume);
            oSellAlert.EditRecord(jdate, barData.OpenPrice, barData.HighPrice, barData.LowPrice, barData.ClosePrice, (int)barData.Volume);
            oExitLongAlert.EditRecord(jdate, barData.OpenPrice, barData.HighPrice, barData.LowPrice, barData.ClosePrice, (int)barData.Volume);
            oExitShortAlert.EditRecord(jdate, barData.OpenPrice, barData.HighPrice, barData.LowPrice, barData.ClosePrice, (int)barData.Volume);
        }

        void m_chart_ChartDataAdded(PALSA.Cls.BarDataNew barData)
        {
            //double jdate = m_chart.StockChartX1.ToJulianDate(barData.TradeDateTime.Year, barData.TradeDateTime.Month,
            //                                                             barData.TradeDateTime.Day, barData.TradeDateTime.Hour,
            //                                                             barData.TradeDateTime.Minute, barData.TradeDateTime.Second);
            double jdate = barData.TradeDateTime.ToOADate();
            oBuyAlert.AppendRecord(jdate, barData.OpenPrice, barData.HighPrice, barData.LowPrice, barData.ClosePrice, (int)barData.Volume);
            oSellAlert.AppendRecord(jdate, barData.OpenPrice, barData.HighPrice, barData.LowPrice, barData.ClosePrice, (int)barData.Volume);
            oExitLongAlert.AppendRecord(jdate, barData.OpenPrice, barData.HighPrice, barData.LowPrice, barData.ClosePrice, (int)barData.Volume);
            oExitShortAlert.AppendRecord(jdate, barData.OpenPrice, barData.HighPrice, barData.LowPrice, barData.ClosePrice, (int)barData.Volume);

            ResetAlertFlags();
        }

        private void ResetAlertScripts()
        {
            oBuyAlert.AlertScript = "";
            oSellAlert.AlertScript = "";
            oExitLongAlert.AlertScript = "";
            oExitShortAlert.AlertScript = "";
            oBuyAlert.ClearRecords();
            oSellAlert.ClearRecords();
            oExitLongAlert.ClearRecords();
            oExitShortAlert.ClearRecords();
        }

        private void SetSelectionBars(PALSA.FrmScanner.ChartSelection selection)
        {
            try
            {
                selection.Bars = (int)Math.Round(Convert.ToDouble(txtBars.Text));
            }
            catch { }
        }

        private void SetSelectionInterval(PALSA.FrmScanner.ChartSelection selection)
        {
            try
            {
                selection.Interval = int.Parse(cboInterval.Text);
            }
            catch { }
        }

        private int FindIntervalIndex(int value)
        {
            foreach (NListBoxItem item in cboInterval.Items)
            {
                if (int.Parse(item.Text) == value)
                    return cboInterval.Items.IndexOf(item);
            }
            return 0;
        }

        private PALSA.Cls.Periodicity GetPeriodicity()
        {
            switch (cboPeriodicity.Text)
            {
                case "Second":
                    return PALSA.Cls.Periodicity.Secondly;
                case "Hour":
                    return PALSA.Cls.Periodicity.Hourly;
                case "Day":
                    return PALSA.Cls.Periodicity.Daily;
                case "Week":
                    return PALSA.Cls.Periodicity.Weekly;
                default:
                    return PALSA.Cls.Periodicity.Minutely;
            }
        }

        //Polls the chart for data every 500ms
        //Note that we could request bars and updates in a push directly from DDFDataManager, however
        //since the bars start at a different time, they would not match with the chart that the user
        //us seeing on the screen.

        private static int tmrUpdate_TicklastRecCnt;
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            //long recCnt = m_chart.StockChartX1.RecordCount;
            //string Symbol = m_chart.StockChartX1.Symbol;

            ////Get the last bar values
            //double j = m_chart.StockChartX1.GetJDate(Symbol + ".Close", (int)recCnt);
            //double o = m_chart.StockChartX1.GetValue(Symbol + ".Open", (int)recCnt);
            //double h = m_chart.StockChartX1.GetValue(Symbol + ".High", (int)recCnt);
            //double l = m_chart.StockChartX1.GetValue(Symbol + ".Low", (int)recCnt);
            //double c = m_chart.StockChartX1.GetValue(Symbol + ".Close", (int)recCnt);
            //double permove = m_chart.StockChartX1.GetValue(Symbol + ".Close", (int)recCnt);

            //double line = m_chart.StockChartX1.GetValue(Symbol + ".Close", (int)recCnt);
            //long v = (long)Math.Round(m_chart.StockChartX1.GetValue(Symbol + ".Volume", (int)recCnt));

            //if (recCnt != tmrUpdate_TicklastRecCnt) //New Record
            //{
            //    oBuyAlert.AppendRecord(j, o, h, l, c, (int)v);
            //    oSellAlert.AppendRecord(j, o, h, l, c, (int)v);
            //    oExitLongAlert.AppendRecord(j, o, h, l, c, (int)v);
            //    oExitShortAlert.AppendRecord(j, o, h, l, c, (int)v);
            //}
            //else
            //{ //Edit last record
            //    j = oBuyAlert.GetJDate(oBuyAlert.RecordCount);
            //    oBuyAlert.EditRecord(j, o, h, l, c, (int)v);
            //    oSellAlert.EditRecord(j, o, h, l, c, (int)v);
            //    oExitLongAlert.EditRecord(j, o, h, l, c, (int)v);
            //    oExitShortAlert.EditRecord(j, o, h, l, c, (int)v);
            //}

            //tmrUpdate_TicklastRecCnt = (int)recCnt;
        }

        public void Disconnect()
        {
            StopAlerts();
            if (m_chart == null) return;
            m_chart.Subscribers--;
        }

        private bool TestScripts()
        {
            Validate script = new ValidateClass { License = TRADESCRIPT_LICENSE };

            string err = script.Validate(txtBuyScript.Text);
            if (!string.IsNullOrEmpty(err))
            {
                tabScripts.SelectedIndex = 0;
                if (script.ScriptHelp != "")
                {
                    if (MessageBox.Show("Your buy script generated an error:\r\n" + err.Replace("Error: ", "") +
                                        "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Your buy script generated an error:\r\n" + err.Replace("Error: ", ""), "Error:",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            err = script.Validate(txtSellScript.Text);
            if (!string.IsNullOrEmpty(err))
            {
                tabScripts.SelectedIndex = 1;
                if (script.ScriptHelp != "")
                {
                    if (MessageBox.Show("Your sell script generated an error:\r\n" + err.Replace("Error: ", "") +
                                        "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Your sell script generated an error:\r\n" + err.Replace("Error: ", ""), "Error:",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            err = script.Validate(txtExitLongScript.Text);
            if (!string.IsNullOrEmpty(err))
            {
                tabScripts.SelectedIndex = 2;
                if (script.ScriptHelp != "")
                {
                    if (MessageBox.Show("Your exit-long script generated an error:\r\n" + err.Replace("Error: ", "") +
                                        "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Your exit-long script generated an error:\r\n" + err.Replace("Error: ", ""), "Error:",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
            err = script.Validate(txtExitShortScript.Text);
            if (string.IsNullOrEmpty(err))
            {
                return true;
            }
            tabScripts.SelectedIndex = 3;
            if (script.ScriptHelp != "")
            {
                if (MessageBox.Show("Your exit-short script generated an error:\r\n" + err.Replace("Error: ", "") +
                                    "\r\nWould you like to view help regarding this error?", "Error:", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    MessageBox.Show(script.ScriptHelp, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Your exit-short script generated an error:\r\n" + err.Replace("Error: ", ""), "Error:",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        #endregion

        #region Broadcast Alerts

        //'Uploads the alert to the web service so that it can be 
        //viewed by another application (desktop or mobile)
        //Note that alerts must be limited in a FIFO manner so that
        //the server is not overloaded with alerts.
        //NOTE: It is a violation of your license agreement to change
        //the number from 100 unless you are licensed to run the web
        //service on your own server!
        private static DateTime BroadcastAlertlastTime = DateTime.Parse("1/1/1900", usCulture.DateTimeFormat);
        private void BroadcastAlert(string Description, string Side)
        {
            //Don't send too many alets at once:
            if ((DateTime.UtcNow - BroadcastAlertlastTime).TotalSeconds < 5) return;

            BroadcastAlertlastTime = DateTime.UtcNow;

            //Kul
            //FundXchange.Model.AlertService.AlertDTO alertDTO = new FundXchange.Model.AlertService.AlertDTO();
            //alertDTO.AlertName = txtAlertName.Text;
            //alertDTO.AlertType = FundXchange.Model.AlertService.AlertType.Script;
            //alertDTO.Exchange = cboExchanges.SelectedItem.ToString();
            //alertDTO.Symbol = txtSymbol.Text;
            //alertDTO.Tag = Description;
            //_Controller.AddAlert(alertDTO);

            //Add the aler to the list
            AddAlertToList(DateTime.UtcNow, Description);
        }

        private void AddAlertToList(DateTime alertDate, string Description)
        {
            Color clr = Color.Black;
            ListViewItem item = new ListViewItem { Text = Convert.ToString(alertDate) };
            item.SubItems.Add(Description);
            item.ForeColor = Color.Black;//m_ctlData.ForeColor;
            item.BackColor = (m_ListAlerts.Items.Count % 2) > 0 ? clr : Color.FromArgb(131, 131, 131);
            m_ListAlerts.Items.Add(item);
        }

        #endregion

        #region IDataSubscriber

        public IntPtr GetHandle()
        {
            return IntPtr.Zero;
        }

        public void BarUpdate(string Symbol, PALSA.Cls.Periodicity BarType, PALSA.Cls.BarDataNew Bar)
        {
        }

        public void PriceUpdate(string Symbol, DateTime TradeDate, double LastPrice, long Volume)
        {
        }

        #endregion

        #region Order Execution

        private static int SubmitOrderlastRecCnt;
        //private void SubmitOrder(ctlPortfolio.Orders.Side BuySell)
        //{
            //if (m_chart == null) return;

            ////'Saftey measure allows only one trade per bar (TODO: consider removal if so desired)
            //if (m_chart.StockChartX1.RecordCount == SubmitOrderlastRecCnt) return;

            //SubmitOrderlastRecCnt = m_chart.StockChartX1.RecordCount;
            //ctlPortfolio.Order MyOrder = new ctlPortfolio.Order();
            //ctlPortfolio portfolio = m_frmMain.GetPortfolio();

            //if (portfolio == null) return;

            ////Gather the order details    
            //MyOrder.OrderID = portfolio.CreateOrderID();
            //MyOrder.Side = BuySell;
            //MyOrder.Quantity = Convert.ToInt32(udQuantity.Text);
            //MyOrder.Exchange = cboExchanges.Text;
            //MyOrder.Symbol = txtSymbol.Text;

            //try
            //{
            //    MyOrder.LimitPrice = Convert.ToDouble(txtStopLimit.Text);
            //}
            //catch { }

            //if (rdoLimit.Checked)
            //{
            //    MyOrder._Order = OrderType.Limit;
            //}
            //else if (rdoMarket.Checked)
            //{
            //    MyOrder._Order = OrderType.Market;
            //}
            //else if (rdoStopLimit.Checked)
            //{
            //    MyOrder._Order = OrderType.StopLimit;
            //}
            //else if (rdoStopMarket.Checked)
            //{
            //    MyOrder._Order = OrderType.StopMarket;
            //}
            //if (rdoGTC.Checked)
            //{
            //    MyOrder.Expires = ctlPortfolio.Order.Expiration.GoodTillCanceled;
            //}
            //else if (rdoGTCHours.Checked)
            //{
            //    MyOrder.Expires = ctlPortfolio.Order.Expiration.GoodTillCanceledPlusAfterHours;
            //}
            //else if (rdoDay.Checked)
            //{
            //    MyOrder.Expires = ctlPortfolio.Order.Expiration.DayOrder;
            //}
            //else if (rdoDayHours.Checked)
            //{
            //    MyOrder.Expires = ctlPortfolio.Order.Expiration.DayOrderPlusAfterHours;
            //}

            ////Ensure the portfolio is selected
            //if (portfolio.cmbPortfolio.Text != cmbPortfolio.Text)
            //{
            //    for (short n = 0; n < portfolio.cmbPortfolio.Items.Count; n++)
            //    {
            //        if (portfolio.cmbPortfolio.Items[n].Text == cmbPortfolio.Text)
            //        {
            //            portfolio.cmbPortfolio.SelectedIndex = n;
            //            break;
            //        }
            //    }
            //}

            ////#### TODO: WARNING! Example code only! Your order entry API is responsible
            ////for sending/receiving orders to update this control. This example just
            ////sends the order straight to the DataViewGrid control! Also the exec time 
            ////and status should be set by the server.
            //MyOrder.ExecTime = DateTime.UtcNow;
            //MyOrder.Status = ctlPortfolio.Orders.Status.Sending;
            //portfolio.ExecuteOrder(MyOrder.OrderID, MyOrder.Status, MyOrder.Symbol, MyOrder.ExecTime, MyOrder.Side,
            //                       MyOrder.Quantity, portfolio.GetLastPrice(MyOrder.Symbol), MyOrder._Order,
            //                       MyOrder.Expires, MyOrder.LimitPrice);
        //}
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> selectedSymbols = new List<string>();

            //Kul
            //IMarketRepository marketRepository = IoC.Resolve<IMarketRepository>();

            //DialogResult result = new frmSymbolLookup(marketRepository, ref selectedSymbols, false).ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    txtSymbol.Text = selectedSymbols.First();
            //}
        }
    }
}
