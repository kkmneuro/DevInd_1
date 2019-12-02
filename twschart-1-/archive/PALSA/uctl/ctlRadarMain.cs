using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using FundXchange.Controls;
//using FundXchange.Infrastructure;
//using FundXchange.RadarView;
using Nevron.UI.WinForm.Controls;
using System.Drawing;
using PALSA.Cls;
using PALSA.ClsRadar;
using PALSA.FrmRadar;
using CommonLibrary.UserControls;
using CommonLibrary.Cls;

namespace PALSA.uctl
{
    public partial class ctlRadarMain : UserControl
    {
        private const int MaximumNumberOfPages = 8;
        private const int MaximumNumberOfRadars = 1000;

        #region Private members

        private readonly FrmMain _mainForm;
        private IRadarGridView _activeRadarGrid = null;
        private static readonly string TemporarySubscriptionsSaveLocation = FileSystemService.GetFilePath(SaveLocations.TemporaryFolder, "temp_rad_startup_symbols.csv");
        private static readonly string TemporaryTemplateFileName = "temp_rad_startup_template.rdr";
        private static readonly string TemporaryTemplatePath = FileSystemService.GetFilePath(SaveLocations.TemporaryFolder, TemporaryTemplateFileName);
        public object Portfolios { get; set; }

        private string _currentPortfolioName = string.Empty;
        public string CurrentPortfolioName
        {
            get { return _currentPortfolioName; }
            set { _currentPortfolioName = value; }
        }
        #endregion

        #region Constructors

        internal ctlRadarMain(object objPortfolio, FrmMain _Main)
        {
            InitializeComponent();
            this.Portfolios = objPortfolio;
            _mainForm = _Main;
           // _mainForm.OnClosing += _mainForm_OnClosing;

            _activeRadarGrid = AddNewRadarView();
            
            //LoadLastSavedSymbolSubscriptions(_activeRadarGrid);//Saved Radar conmmented for the time being

            _mainForm.m_DockManager.DocumentManager.DocumentClosing += DocumentManager_DocumentClosing;
        }

        void DocumentManager_DocumentClosing(object sender, DocumentCancelEventArgs e)
        {
            if (e.Document.Text == "Radar View")
            {
                SaveActiveTemplateToTemporaryFile();
                SaveSubscribedSymbolsToTemporaryFile();

               // _mainForm.m_DockManager.DocumentManager.DocumentClosing -= DocumentManager_DocumentClosing;
            }
        }

        void _mainForm_OnClosing(object sender, EventArgs e)
        {
            SaveActiveTemplateToTemporaryFile();
            SaveSubscribedSymbolsToTemporaryFile();
        }

        #endregion

        #region Event Handlers

        private void ActiveRadarGridRowsChanged(object sender, EventArgs e)
        {
            if (_activeRadarGrid.IsEmpty)
            {
                menuSaveSelectedSymbols.Enabled = false;
                menuDeleteRows.Enabled = false;
                menuFindSymbol.Enabled = false;
            }
            else
            {
                menuSaveSelectedSymbols.Enabled = true;
                menuDeleteRows.Enabled = true;
                menuFindSymbol.Enabled = true;
            }
        }

        void RadarGridTimeFrameChangeRequested(object sender, EventArgs e)
        {
            MenuChangeTimeFrameClick(sender, null);
        }

        private void tcRadarPages_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt) && (e.KeyCode == Keys.PageUp))
            {
                if (tcRadarPages.SelectedIndex < tcRadarPages.TabPages.Count)
                {
                    tcRadarPages.SelectedIndex += 1;
                }
                return;
            }
            if ((e.Alt) && (e.KeyCode == Keys.PageDown))
            {
                if (tcRadarPages.SelectedIndex > 0)
                {
                    tcRadarPages.SelectedIndex -= 1;
                }
                return;
            }

        }

        private void tcRadarPages_DoubleClick(object sender, EventArgs e)
        {
            //Kul
            //frmRadarRenamePage frrp = new frmRadarRenamePage(tcRadarPages.SelectedTab.Text);
            //if (frrp.ShowDialog() == DialogResult.OK)
            //{
            //    tcRadarPages.SelectedTab.Text = frrp.PageName;
            //}
        }

        private void tcRadarPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcRadarPages.TabPages.Count > 0)
            {
                _activeRadarGrid = (RadarGrid)tcRadarPages.SelectedTab.Controls[0];
            }
            else
            {
                _activeRadarGrid = null;
            }
        }

        private void RadarGridChartRequested(string symbol, Periodicity periodicity, int interval)
        {
            FrmScanner.ChartSelection selection = new FrmScanner.ChartSelection
            {
                Symbol = symbol,
                Interval = interval,
                Bars = 250,
                Periodicity = periodicity
            };
            _mainForm.LoadRealTimeChart(selection);
            //_mainForm.CreateNewChart(new ChartSelection()//Kuldeep
            //{
            //    Symbol = symbol,
            //    Periodicity = periodicity,
            //    Interval = interval,
            //    Bars = 100
            //});
        }

        private void TcRadarPagesSelectedTabChanged(object sender, EventArgs e)
        {
            RadarGrid associatedGrid = (RadarGrid)tcRadarPages.SelectedTab.Controls.OfType<RadarGrid>().FirstOrDefault();
            if (null != associatedGrid)
            {
                _activeRadarGrid = associatedGrid;
            }
        }

        private void MenuSaveSelectedSymbolsClick(object sender, CommandEventArgs e)
        {
            if (_activeRadarGrid.SubscribedSymbolDescriptors.Count() > 0)
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.InitialDirectory = FileSystemService.GetPath(SaveLocations.UserFolder);
                    dialog.Filter = "Comma Separated List|*.csv";
                    dialog.FileName = string.Format("{0}.csv", tcRadarPages.SelectedTab.Text);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter stream = File.CreateText(dialog.FileName))
                        {
                            foreach (string symbol in _activeRadarGrid.SubscribedSymbolDescriptors)
                            {
                                stream.WriteLine(symbol);
                            }
                        }
                        MessageBox.Show("Symbol list saved successfully", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("You are not currently subscribed to any symbols.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MenuLoadSymbolListClick(object sender, CommandEventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = FileSystemService.GetPath(SaveLocations.UserFolder);
                dialog.CheckFileExists = true;
                dialog.Filter = "Comma Separated List|*.csv";
                dialog.AutoUpgradeEnabled = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _activeRadarGrid.Clear();
                    LoadSymbolsFromFile(dialog.FileName);
                }
            }
        }

        private void MenuDeletePageClick(object sender, CommandEventArgs e)
        {
            if (tcRadarPages.TabPages.Count > 0)
            {
                RadarGrid r = (RadarGrid)tcRadarPages.SelectedTab.Controls[0];
                r.Clear();
                tcRadarPages.TabPages.Remove(tcRadarPages.SelectedTab);
            }
        }

        private void MenuDeleteRowsClick(object sender, CommandEventArgs e)
        {
            _activeRadarGrid.DeleteSelectedRows();
        }

        private void MenuChangeTimeFrameClick(object sender, CommandEventArgs e)
        {
            using (EditRadarTimeFrameForm dialog = new EditRadarTimeFrameForm())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _activeRadarGrid.UpdateSelectedRadarTimeFrames(dialog.Periodicity, dialog.Interval);   
                }
            }
        }

        private void MenuFindSymbolClick(object sender, CommandEventArgs e)
        {
            using (FindRadarSymbolForm findSymbolDialog = new FindRadarSymbolForm())
            {
                if (findSymbolDialog.ShowDialog() == DialogResult.OK)
                {
                    if (findSymbolDialog.SearchAllPages)
                    {
                        List<string> pagesContainingSymbol = FindSymbolInAllPages(findSymbolDialog.Symbol);

                        if (pagesContainingSymbol.Count > 0)
                            MessageBox.Show(string.Format("{0} was found on {1}", findSymbolDialog.Symbol, string.Join(", ", pagesContainingSymbol.ToArray())), "Search results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show(string.Format("{0} was not found", findSymbolDialog.Symbol), "Search results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        _activeRadarGrid.SelectRadar(findSymbolDialog.Symbol);
                    }
                }
            }
        }

        private void MenuNewPageClick(object sender, CommandEventArgs e)
        {
            if (tcRadarPages.TabPages.Count.Equals(MaximumNumberOfPages))
            {
                MessageBox.Show(string.Format("You have already created the maximum number of allowable radar pages ({0}).", MaximumNumberOfPages), "Limit exceeded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AddNewRadarView();

            if (tcRadarPages.TabPages.Count > 0)
            {
                tcRadarPages.SelectedIndex = tcRadarPages.TabPages.Count - 1;
                _activeRadarGrid = (RadarGrid)tcRadarPages.SelectedTab.Controls[0];

                menuInsert.Enabled = true;
                menuEdit.Enabled = true;
            }
        }

        public event Action<string> OnScriptPortfolioApplyClick = delegate { };
        public event Action<string> OnScriptPortfolioModifyClick = delegate { };
        public event Action<string> OnScriptPortfolioRemoveClick = delegate { };

        private readonly frmDialogForm _objfrmDialogForm = new frmDialogForm();
        private void MenuAddSymbolClick(object sender, CommandEventArgs e)//Kul
        {
            int totalSymbols = CountTotalSubscribedSymbols();
            if (totalSymbols.Equals(MaximumNumberOfRadars))
            {
                MessageBox.Show(string.Format("You are only allowed to subscribe to a maximum of {0} radars across all radar pages.", MaximumNumberOfRadars), "Limit exceeded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //**** For Portfolio ****
            var objuctlSelectPortfolio = new UctlSelectPortfolio(Portfolios);
            objuctlSelectPortfolio.SelectedPortfolio = CurrentPortfolioName;
            objuctlSelectPortfolio.OnCancelClick += objuctlSelectPortfolio_OnCancelClick;
            objuctlSelectPortfolio.OnApplyClick += objuctlSelectPortfolio_OnApplyClick;
            objuctlSelectPortfolio.OnModifyClick += objuctlSelectPortfolio_OnModifyClick;
            objuctlSelectPortfolio.OnRemoveClick += objuctlSelectPortfolio_OnRemoveClick;
            _objfrmDialogForm.Controls.Clear();
            var objSize = new Size(objuctlSelectPortfolio.Width + 8, objuctlSelectPortfolio.Height + 28);
            _objfrmDialogForm.Size = objSize;
            objuctlSelectPortfolio.Dock = DockStyle.Fill;
            _objfrmDialogForm.Controls.Add(objuctlSelectPortfolio);
            _objfrmDialogForm.Dock = DockStyle.Fill;
            _objfrmDialogForm.Text = objuctlSelectPortfolio.Title;
            _objfrmDialogForm.Sizable = false;
            _objfrmDialogForm.MinimizeBox = false;
            _objfrmDialogForm.CloseButton = false;
            _objfrmDialogForm.TopMost = false;
            _objfrmDialogForm.StartPosition = FormStartPosition.CenterScreen;
            _objfrmDialogForm.ShowDialog();

            //using (var symbolForm = new frmSymbolLookup(_marketRepository, ref selectedSymbols, true))
            //{
            //    if (symbolForm.ShowDialog() == DialogResult.OK)
            //    {
            //        foreach (var symbol in selectedSymbols)
            //        {
            //            _activeRadarGrid.AddRadar(symbol, "JSE");
            //        }
            //    }
            //}            
        }
        private void objuctlSelectPortfolio_OnCancelClick(object arg1, EventArgs arg2)
        {
            _objfrmDialogForm.Close();
        }
        private void objuctlSelectPortfolio_OnApplyClick(string portfilioName)
        {

            _currentPortfolioName = portfilioName;
            //OnScriptPortfolioApplyClick(portfilioName);
            List<string> selectedSymbols = new List<string>();
            if (((Dictionary<string, ClsPortfolio>)Portfolios).Keys.Contains(portfilioName))
            {
                ClsPortfolio objPortfolio = ((Dictionary<string, ClsPortfolio>)Portfolios)[portfilioName];

                int keycount = objPortfolio.Products.Keys.Count;

                if (keycount <= 10)
                {

                    var lst = new List<Symbol>();
                    foreach (string key in objPortfolio.Products.Keys)
                    {
                        Symbol sym = Symbol.GetSymbol(key);
                        selectedSymbols.Add(sym.Contract);
                    }

                    foreach (var symbol in selectedSymbols)
                    {
                        _activeRadarGrid.AddRadar(symbol, "OEC");//Subscribe symbols here
                    }
                }

                else
                {
                    MessageBox.Show("Cannot Add more than 10 symbols", "Radar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }            

            _objfrmDialogForm.DialogResult = DialogResult.OK;

            //else
            //{
            //    MessageBox.Show("Cannot Add more than 10 symbols", "Radar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
        }
        private void objuctlSelectPortfolio_OnModifyClick(string portfilioName)
        {
            OnScriptPortfolioModifyClick(portfilioName);
        }
        private void objuctlSelectPortfolio_OnRemoveClick(string portfilioName)
        {
            OnScriptPortfolioRemoveClick(portfilioName);
        }

        private int CountTotalSubscribedSymbols()
        {
            int total = 0;
            foreach (NTabPage tabPage in tcRadarPages.TabPages)
            {
                if (tabPage.Controls[0] is IRadarGridView)
                {
                    total += (tabPage.Controls[0] as IRadarGridView).SubscribedSymbolDescriptors.Count();
                }
            }
            return total;
        }

        private void MenuAddIndicatorClick(object sender, CommandEventArgs e)
        {
            var dialog = new IndicatorSelectionForm(_activeRadarGrid.GetActiveIndicators());
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.OnActiveIndicatorChanged += dialog_OnActiveIndicatorChanged;
            dialog.OnClosed += indicatorSelectionDialog_Closed;
            dialog.OnTradeScriptHelpRequested += new EventHandler(dialog_OnTradeScriptHelpRequested);
            dialog.Show(this);
        }

        private void ctlRadarMain_VisibleChanged(object sender, EventArgs e)
        {
            // A strange exception is raised when applying the last saved template before the 
            // control is visible. Hence, a check is done before applying said template.
            if (Visible)
            {
                //ApplyLastSavedTemplateTo(_activeRadarGrid);
            }
        }

        void dialog_OnActiveIndicatorChanged(Indicator indicatorToRefresh)
        {
            _activeRadarGrid.RefreshIndicator(indicatorToRefresh);
        }

        void indicatorSelectionDialog_Closed(object sender, EventArgs e)
        {
            var formInstance = (sender as IndicatorSelectionForm);
            if (null != formInstance && formInstance.DialogResult == DialogResult.OK)
            {
                _activeRadarGrid.UpdateIndicators(formInstance.SelectedIndicators);
            }
        }

        void dialog_OnTradeScriptHelpRequested(object sender, EventArgs e)
        {
            //kul_mainForm.OpenTradeScriptGuide();
        }

        private void MenuLabelRowClick(object sender, CommandEventArgs e)
        {
            _activeRadarGrid.InsertLabelRow();
        }

        private void MenuBlankRowClick(object sender, CommandEventArgs e)
        {
            _activeRadarGrid.InsertBlankRow();
        }

        // TODO: [AvdM 2010-11-14] Refactor this method. Too much branching.
        private void MenuEditTemplateClick(object sender, CommandEventArgs e)
        {
            using (FormatRadarGridForm dialog = new FormatRadarGridForm(_activeRadarGrid.ActiveTemplate))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _activeRadarGrid.ApplyTemplate(dialog.DefinedTemplate);
                    if (!string.IsNullOrEmpty(dialog.DefinedTemplate.PageName))
                    {
                        tcRadarPages.SelectedTab.Text = dialog.DefinedTemplate.PageName;
                        tcRadarPages.SelectedTab.ToolTipText = dialog.DefinedTemplate.PageName;
                    }

                    if (dialog.DefinedTemplate.IsSavedToDisk)
                    {
                        if (!UserHasElectedToAlwaysSaveModifications(dialog.DefinedTemplate.FilePath))
                        {
                            //using (SaveChangesDialog saveConfirmation = new SaveChangesDialog())//Kul
                            //{
                            //    if (saveConfirmation.ShowDialog() == DialogResult.Yes)
                            //    {
                            //        FileSystemService.SaveObjectToFile(dialog.DefinedTemplate.FilePath, dialog.DefinedTemplate);
                            //        return;
                            //    }
                            //}
                        }
                        FileSystemService.SaveObjectToFile(dialog.DefinedTemplate.FilePath, dialog.DefinedTemplate);
                    }
                    else
                    {
                        if (MessageBox.Show("Would you like to save this template?", "Confirm save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SaveActiveTemplate();
                        }
                    }
                }
            }
        }

        private bool UserHasElectedToAlwaysSaveModifications(string filePath)
        {
            if (!FileSystemService.IsTemporaryFile(filePath))
            {
                return (bool)Properties.Settings.Default["AlwaysSaveRadarChanges"];
            }
            return true;
        }

        private void MenuSaveTemplateClick(object sender, CommandEventArgs e)
        {
            SaveActiveTemplate();
        }

        private void SaveActiveTemplate()
        {
            if (_activeRadarGrid.ActiveTemplate.IsSavedToDisk && !FileSystemService.IsTemporaryFile(_activeRadarGrid.ActiveTemplate.FilePath))
            {
                FileSystemService.SaveObjectToFile(_activeRadarGrid.ActiveTemplate.FilePath, _activeRadarGrid.ActiveTemplate);
            }
            else
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Radar View template file|*.rdr";
                    dialog.DefaultExt = ".rdr";
                    dialog.InitialDirectory = FileSystemService.GetPath(SaveLocations.UserFolder);

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        FileSystemService.SaveObjectToFile(dialog.FileName, _activeRadarGrid.ActiveTemplate);
                    }
                }
            }
        }

        private void SaveActiveTemplateToTemporaryFile()
        {
            FileSystemService.SaveObjectToFile(TemporaryTemplatePath, _activeRadarGrid.ActiveTemplate);
            File.SetAttributes(TemporaryTemplatePath, FileAttributes.Hidden);
        }

        private void SaveSubscribedSymbolsToTemporaryFile()
        {
            if (!_activeRadarGrid.IsEmpty)
            {
                if (File.Exists(TemporarySubscriptionsSaveLocation))
                {
                    File.Delete(TemporarySubscriptionsSaveLocation);
                }
                using (TextWriter stream = File.CreateText(TemporarySubscriptionsSaveLocation))
                {
                    foreach (string symbol in _activeRadarGrid.SubscribedSymbolDescriptors)
                    {
                        stream.WriteLine(symbol);
                    }
                }
                File.SetAttributes(TemporarySubscriptionsSaveLocation, FileAttributes.Hidden);
            }
        }

        private void MenuLoadTemplateClick(object sender, CommandEventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = FileSystemService.GetPath(SaveLocations.UserFolder);
                dialog.CheckFileExists = true;
                dialog.Filter = "Radar View template file|*.rdr";
                dialog.AutoUpgradeEnabled = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadTemplateFromFile(dialog.FileName);
                }
            }
        }

        private void TcRadarPagesControlRemoved(object sender, ControlEventArgs e)
        {   
            if (tcRadarPages.TabPages.Count == 0)
            {
                menuInsert.Enabled = false;
                menuEdit.Enabled = false;
            }
        }

        #endregion

        #region Helper methods

        private RadarGrid AddNewRadarView()
        {
            string tabName = string.Concat("Page ", tcRadarPages.TabPages.Count + 1);

            var radarGrid = new RadarGrid()
            {
                Dock = DockStyle.Fill                
            };
            radarGrid.RowsChanged += ActiveRadarGridRowsChanged;
            radarGrid.TimeFrameChangeRequested += RadarGridTimeFrameChangeRequested;
            radarGrid.ChartRequested += RadarGridChartRequested;
            radarGrid.Load += (sender, eventArgs) =>
            {
                if (tcRadarPages.TabPages.Equals(1))
                {
                    ApplyLastSavedTemplateTo(radarGrid);
                    tabName = radarGrid.ActiveTemplate.PageName;
                }
                else
                {
                    AddObligatoryIndicatorsTo(radarGrid);
                }
            };
            
            radarGrid.ActiveTemplate.PageName = tabName;

            NTabPage tabPage = new NTabPage()
            {
                Text = tabName,
                ToolTipText = tabName
            };
            tabPage.Controls.Add(radarGrid);
            tcRadarPages.TabPages.Add(tabPage);

            return radarGrid;
        }

        private void ApplyLastSavedTemplateTo(IRadarGridView radarGrid)
        {
            RadarTemplate lastSavedTemplate = FileSystemService.LoadObjectFromFile<RadarTemplate>(TemporaryTemplatePath);
            if (null != lastSavedTemplate)
            {
                radarGrid.ApplyTemplate(lastSavedTemplate);
                return;
            }
            radarGrid.ApplyTemplate(RadarTemplate.GetDefault());
        }

        private void LoadLastSavedSymbolSubscriptions(IRadarGridView radarGrid)
        {
            if (File.Exists(TemporarySubscriptionsSaveLocation))
            {
                LoadSymbolsFromFile(TemporarySubscriptionsSaveLocation);
            }
        }

        private void AddObligatoryIndicatorsTo(IRadarGridView radarGrid)
        {
            IIndicatorRepository indicatorRepository = new IndicatorRepository();//KulIoC.Resolve<IIndicatorRepository>();

            Indicator trendIndicator;
            if (indicatorRepository.TryGetIndicatorBy("Trend Indicator", out trendIndicator))
            {
                radarGrid.AddIndicator(trendIndicator);
            }
        }

        private void LoadSymbolsFromFile(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string symbolString = reader.ReadToEnd();
                    string[] symbolDescriptors = symbolString.Split(new string[] { "\r\n", "," }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string descriptor in symbolDescriptors)
                    {
                        if (SubscriptionDescriptor.IsValidDescriptor(descriptor))
                        {
                            SubscriptionDescriptor typedDescriptor = SubscriptionDescriptor.From(descriptor);
                            _activeRadarGrid.AddRadar(typedDescriptor);
                        }
                        else
                        {
                            _activeRadarGrid.AddRadar(descriptor, "JSE");
                        }
                    }
                }
            }
        }

        private void LoadTemplateFromFile(string filePath)
        {
            RadarTemplate radarTemplate = FileSystemService.LoadObjectFromFile<RadarTemplate>(filePath);
            if (null != radarTemplate)
            {
                _activeRadarGrid.ApplyTemplate(radarTemplate);
            }
        }

        private List<string> FindSymbolInAllPages(string symbol)
        {
            List<string> pagesContainingSymbol = new List<string>();

            foreach (NTabPage tabPage in tcRadarPages.TabPages)
            {
                RadarGrid pageGrid = (RadarGrid)tabPage.Controls.OfType<RadarGrid>().FirstOrDefault();
                if (pageGrid != null)
                {
                    //if (pageGrid.SubscribedSymbols.Contains(symbol))
                    //    pagesContainingSymbol.Add(tabPage.Text);
                }
            }
            return pagesContainingSymbol;
        }

        #endregion
    }
}