using Nevron.UI.WinForm.Controls;

namespace PALSA.uctl
{
    partial class ctlOptimizer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlOptimizer));
            this.btnOptimiza = new Nevron.UI.WinForm.Controls.NButton();
            this.tabScripts = new Nevron.UI.WinForm.Controls.NTabControl();
            this.tpBuy = new Nevron.UI.WinForm.Controls.NTabPage();
            this.txtBuyScript = new Nevron.UI.WinForm.Controls.NTextBox();
            this.tpSell = new Nevron.UI.WinForm.Controls.NTabPage();
            this.txtSellScript = new Nevron.UI.WinForm.Controls.NTextBox();
            this.tabRezult = new Nevron.UI.WinForm.Controls.NTabPage();
            this.lstResults = new Nevron.UI.WinForm.Controls.NListBox();
            this.grpData = new Nevron.UI.WinForm.Controls.NGrouper();
            this.btnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.numScriptInterval = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.lblScriptInterval = new System.Windows.Forms.Label();
            this.numMax2 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.numMin2 = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.lblMaxPeriod2 = new System.Windows.Forms.Label();
            this.lblMinPeriod2 = new System.Windows.Forms.Label();
            this.cboInterval = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblMaxPeriod = new System.Windows.Forms.Label();
            this.lblMinPeriod = new System.Windows.Forms.Label();
            this.numMax = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.numMin = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboPeriodicity = new Nevron.UI.WinForm.Controls.NComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtBars = new Nevron.UI.WinForm.Controls.NTextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.lblExample = new System.Windows.Forms.Label();
            this.btnStop = new Nevron.UI.WinForm.Controls.NButton();
            this.progressOptimizer = new Nevron.UI.WinForm.Controls.NProgressBar();
            this.tabScripts.SuspendLayout();
            this.tpBuy.SuspendLayout();
            this.tpSell.SuspendLayout();
            this.tabRezult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpData)).BeginInit();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScriptInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOptimiza
            // 
            this.btnOptimiza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptimiza.ButtonProperties.ShowFocusRect = false;
            this.btnOptimiza.Location = new System.Drawing.Point(833, 516);
            this.btnOptimiza.Name = "btnOptimiza";
            //this.btnOptimiza.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            //this.btnOptimiza.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
            //this.btnOptimiza.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            //this.btnOptimiza.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.btnOptimiza.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.btnOptimiza.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.btnOptimiza.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            //this.btnOptimiza.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            //this.btnOptimiza.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            //this.btnOptimiza.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            //this.btnOptimiza.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.btnOptimiza.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.btnOptimiza.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.btnOptimiza.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.btnOptimiza.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            //this.btnOptimiza.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.btnOptimiza.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            //this.btnOptimiza.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            //this.btnOptimiza.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            //this.btnOptimiza.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            //this.btnOptimiza.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOptimiza.Size = new System.Drawing.Size(75, 23);
            this.btnOptimiza.TabIndex = 0;
            this.btnOptimiza.Text = "Optimize";
            this.btnOptimiza.TransparentBackground = true;
            this.btnOptimiza.UseVisualStyleBackColor = false;
            this.btnOptimiza.Click += new System.EventHandler(this.btnOptimiza_Click);
            // 
            // tabScripts
            // 
            this.tabScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabScripts.Controls.Add(this.tpBuy);
            this.tabScripts.Controls.Add(this.tpSell);
            this.tabScripts.Controls.Add(this.tabRezult);
            this.tabScripts.Location = new System.Drawing.Point(3, 115);
            this.tabScripts.Name = "tabScripts";
            this.tabScripts.Padding = new System.Windows.Forms.Padding(4, 29, 4, 4);
            //this.tabScripts.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            //this.tabScripts.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
            //this.tabScripts.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            //this.tabScripts.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.tabScripts.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.tabScripts.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.tabScripts.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            //this.tabScripts.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            //this.tabScripts.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            //this.tabScripts.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.tabScripts.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.tabScripts.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.tabScripts.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.tabScripts.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.tabScripts.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            //this.tabScripts.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.tabScripts.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            //this.tabScripts.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            //this.tabScripts.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            //this.tabScripts.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            //this.tabScripts.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabScripts.Selectable = true;
            this.tabScripts.SelectedIndex = 2;
            this.tabScripts.Size = new System.Drawing.Size(896, 383);
            this.tabScripts.TabIndex = 148;
            // 
            // tpBuy
            // 
            this.tpBuy.Controls.Add(this.txtBuyScript);
            this.tpBuy.ImageIndex = 0;
            this.tpBuy.Location = new System.Drawing.Point(4, 29);
            this.tpBuy.Name = "tpBuy";
            this.tpBuy.Size = new System.Drawing.Size(888, 350);
            this.tpBuy.TabIndex = 1;
            this.tpBuy.Text = "Buy Script";
            // 
            // txtBuyScript
            // 
            this.txtBuyScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuyScript.Location = new System.Drawing.Point(0, 0);
            this.txtBuyScript.Multiline = true;
            this.txtBuyScript.Name = "txtBuyScript";
            this.txtBuyScript.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.txtBuyScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBuyScript.Size = new System.Drawing.Size(888, 350);
            this.txtBuyScript.TabIndex = 8;
            // 
            // tpSell
            // 
            this.tpSell.Controls.Add(this.txtSellScript);
            this.tpSell.ImageIndex = 1;
            this.tpSell.Location = new System.Drawing.Point(4, 29);
            this.tpSell.Name = "tpSell";
            this.tpSell.Size = new System.Drawing.Size(888, 350);
            this.tpSell.TabIndex = 2;
            this.tpSell.Text = "Sell Script";
            // 
            // txtSellScript
            // 
            this.txtSellScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSellScript.Location = new System.Drawing.Point(0, 0);
            this.txtSellScript.Multiline = true;
            this.txtSellScript.Name = "txtSellScript";
            this.txtSellScript.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.txtSellScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSellScript.Size = new System.Drawing.Size(888, 350);
            this.txtSellScript.TabIndex = 9;
            // 
            // tabRezult
            // 
            this.tabRezult.Controls.Add(this.lstResults);
            this.tabRezult.Location = new System.Drawing.Point(4, 29);
            this.tabRezult.Name = "tabRezult";
            this.tabRezult.Size = new System.Drawing.Size(888, 350);
            this.tabRezult.TabIndex = 3;
            this.tabRezult.Text = "Result";
            // 
            // lstResults
            // 
            this.lstResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResults.FormattingEnabled = true;
            this.lstResults.Location = new System.Drawing.Point(0, 0);
            this.lstResults.Name = "lstResults";
            //this.lstResults.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            //this.lstResults.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            //this.lstResults.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.lstResults.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.lstResults.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.lstResults.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            //this.lstResults.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            //this.lstResults.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.lstResults.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            //this.lstResults.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.lstResults.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.lstResults.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.lstResults.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            //this.lstResults.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            //this.lstResults.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.lstResults.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            //this.lstResults.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            //this.lstResults.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            //this.lstResults.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            //this.lstResults.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lstResults.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstResults.Size = new System.Drawing.Size(888, 350);
            this.lstResults.TabIndex = 151;
            // 
            // grpData
            // 
            this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpData.Controls.Add(this.btnSearch);
            this.grpData.Controls.Add(this.numScriptInterval);
            this.grpData.Controls.Add(this.lblScriptInterval);
            this.grpData.Controls.Add(this.numMax2);
            this.grpData.Controls.Add(this.numMin2);
            this.grpData.Controls.Add(this.lblMaxPeriod2);
            this.grpData.Controls.Add(this.lblMinPeriod2);
            this.grpData.Controls.Add(this.cboInterval);
            this.grpData.Controls.Add(this.lblMaxPeriod);
            this.grpData.Controls.Add(this.lblMinPeriod);
            this.grpData.Controls.Add(this.numMax);
            this.grpData.Controls.Add(this.numMin);
            this.grpData.Controls.Add(this.Label6);
            this.grpData.Controls.Add(this.Label7);
            this.grpData.Controls.Add(this.cboPeriodicity);
            this.grpData.Controls.Add(this.Label8);
            this.grpData.Controls.Add(this.txtBars);
            this.grpData.Controls.Add(this.Label9);
            this.grpData.Controls.Add(this.txtSymbol);
            this.grpData.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.grpData.FooterItem.Text = "Footer";
            this.grpData.FooterItem.Visible = false;
            this.grpData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpData.HeaderItem.Text = "Data Source";
            this.grpData.Location = new System.Drawing.Point(3, 3);
            this.grpData.Name = "grpData";
            //this.grpData.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            //this.grpData.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            //this.grpData.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.grpData.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.grpData.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.grpData.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            //this.grpData.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            //this.grpData.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.grpData.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            //this.grpData.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.grpData.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.grpData.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.grpData.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            //this.grpData.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            //this.grpData.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.grpData.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            //this.grpData.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            //this.grpData.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            //this.grpData.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            //this.grpData.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpData.ShadowInfo.Draw = false;
            this.grpData.Size = new System.Drawing.Size(905, 106);
            this.grpData.TabIndex = 149;
            this.grpData.Text = "Data Source";
            // 
            // btnSearch
            // 
            this.btnSearch.ButtonProperties.ShowFocusRect = false;
            this.btnSearch.ButtonProperties.TooltipInfo.CaptionText = "Search Symbols";
            this.btnSearch.ButtonProperties.TooltipInfo.CaptionTextRenderMode = Nevron.UI.TextRenderMode.GdiPlus;
            this.btnSearch.ButtonProperties.TooltipInfo.EnableSkinning = false;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(130, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.btnSearch.Size = new System.Drawing.Size(24, 18);
            this.btnSearch.TabIndex = 168;
            this.btnSearch.TransparentBackground = true;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // numScriptInterval
            // 
            this.numScriptInterval.Location = new System.Drawing.Point(833, 38);
            this.numScriptInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numScriptInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScriptInterval.Name = "numScriptInterval";
            //this.numScriptInterval.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.numScriptInterval.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.numScriptInterval.Size = new System.Drawing.Size(48, 20);
            this.numScriptInterval.TabIndex = 167;
            this.numScriptInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblScriptInterval
            // 
            this.lblScriptInterval.AutoSize = true;
            this.lblScriptInterval.BackColor = System.Drawing.Color.Transparent;
            this.lblScriptInterval.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblScriptInterval.Location = new System.Drawing.Point(743, 42);
            this.lblScriptInterval.Name = "lblScriptInterval";
            this.lblScriptInterval.Size = new System.Drawing.Size(87, 13);
            this.lblScriptInterval.TabIndex = 166;
            this.lblScriptInterval.Text = "Period Increment";
            // 
            // numMax2
            // 
            this.numMax2.Location = new System.Drawing.Point(631, 70);
            this.numMax2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMax2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMax2.Name = "numMax2";
            //this.numMax2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.numMax2.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.numMax2.Size = new System.Drawing.Size(92, 20);
            this.numMax2.TabIndex = 165;
            this.numMax2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numMin2
            // 
            this.numMin2.Location = new System.Drawing.Point(631, 38);
            this.numMin2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMin2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMin2.Name = "numMin2";
            //this.numMin2.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.numMin2.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.numMin2.Size = new System.Drawing.Size(92, 20);
            this.numMin2.TabIndex = 164;
            this.numMin2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblMaxPeriod2
            // 
            this.lblMaxPeriod2.AutoSize = true;
            this.lblMaxPeriod2.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxPeriod2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMaxPeriod2.Location = new System.Drawing.Point(527, 76);
            this.lblMaxPeriod2.Name = "lblMaxPeriod2";
            this.lblMaxPeriod2.Size = new System.Drawing.Size(87, 13);
            this.lblMaxPeriod2.TabIndex = 163;
            this.lblMaxPeriod2.Text = "Max Period ($p2)";
            // 
            // lblMinPeriod2
            // 
            this.lblMinPeriod2.AutoSize = true;
            this.lblMinPeriod2.BackColor = System.Drawing.Color.Transparent;
            this.lblMinPeriod2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMinPeriod2.Location = new System.Drawing.Point(527, 42);
            this.lblMinPeriod2.Name = "lblMinPeriod2";
            this.lblMinPeriod2.Size = new System.Drawing.Size(84, 13);
            this.lblMinPeriod2.TabIndex = 162;
            this.lblMinPeriod2.Text = "Min Period ($p2)";
            // 
            // cboInterval
            // 
            this.cboInterval.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("1", -1, true, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("5", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("10", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("15", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("20", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("30", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cboInterval.ListProperties.ColumnOnLeft = false;
            this.cboInterval.Location = new System.Drawing.Point(235, 38);
            this.cboInterval.Name = "cboInterval";
            //this.cboInterval.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.cboInterval.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.cboInterval.Size = new System.Drawing.Size(77, 20);
            this.cboInterval.TabIndex = 161;
            // 
            // lblMaxPeriod
            // 
            this.lblMaxPeriod.AutoSize = true;
            this.lblMaxPeriod.BackColor = System.Drawing.Color.Transparent;
            this.lblMaxPeriod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMaxPeriod.Location = new System.Drawing.Point(331, 76);
            this.lblMaxPeriod.Name = "lblMaxPeriod";
            this.lblMaxPeriod.Size = new System.Drawing.Size(87, 13);
            this.lblMaxPeriod.TabIndex = 111;
            this.lblMaxPeriod.Text = "Max Period ($p1)";
            // 
            // lblMinPeriod
            // 
            this.lblMinPeriod.AutoSize = true;
            this.lblMinPeriod.BackColor = System.Drawing.Color.Transparent;
            this.lblMinPeriod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMinPeriod.Location = new System.Drawing.Point(331, 42);
            this.lblMinPeriod.Name = "lblMinPeriod";
            this.lblMinPeriod.Size = new System.Drawing.Size(84, 13);
            this.lblMinPeriod.TabIndex = 111;
            this.lblMinPeriod.Text = "Min Period ($p1)";
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(421, 70);
            this.numMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMax.Name = "numMax";
            //this.numMax.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.numMax.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.numMax.Size = new System.Drawing.Size(92, 20);
            this.numMax.TabIndex = 110;
            this.numMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(420, 38);
            this.numMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMin.Name = "numMin";
            //this.numMin.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.numMin.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.numMin.Size = new System.Drawing.Size(92, 20);
            this.numMin.TabIndex = 110;
            this.numMin.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label6.Location = new System.Drawing.Point(167, 42);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(61, 13);
            this.Label6.TabIndex = 109;
            this.Label6.Text = "Bar Interval";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label7.Location = new System.Drawing.Point(13, 76);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(55, 13);
            this.Label7.TabIndex = 108;
            this.Label7.Text = "Periodicity";
            // 
            // cboPeriodicity
            // 
            this.cboPeriodicity.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Minute", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Hour", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Day", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Week", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cboPeriodicity.ListProperties.ColumnOnLeft = false;
            this.cboPeriodicity.Location = new System.Drawing.Point(75, 72);
            this.cboPeriodicity.Name = "cboPeriodicity";
            //this.cboPeriodicity.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.cboPeriodicity.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.cboPeriodicity.Size = new System.Drawing.Size(79, 20);
            this.cboPeriodicity.TabIndex = 3;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label8.Location = new System.Drawing.Point(170, 75);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(58, 13);
            this.Label8.TabIndex = 107;
            this.Label8.Text = "Bar History";
            // 
            // txtBars
            // 
            this.txtBars.Location = new System.Drawing.Point(235, 72);
            this.txtBars.Name = "txtBars";
            //this.txtBars.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.txtBars.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtBars.Size = new System.Drawing.Size(76, 18);
            this.txtBars.TabIndex = 4;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label9.Location = new System.Drawing.Point(26, 42);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(41, 13);
            this.Label9.TabIndex = 106;
            this.Label9.Text = "Symbol";
            // 
            // txtSymbol
            // 
            this.txtSymbol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSymbol.Location = new System.Drawing.Point(75, 40);
            this.txtSymbol.Name = "txtSymbol";
            //this.txtSymbol.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.txtSymbol.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtSymbol.Size = new System.Drawing.Size(55, 18);
            this.txtSymbol.TabIndex = 0;
            // 
            // lblExample
            // 
            this.lblExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(4, 501);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(262, 26);
            this.lblExample.TabIndex = 150;
            this.lblExample.Text = "Example:\r\nCROSSOVER(SMA(CLOSE, $p1), SMA(CLOSE, $p2))";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.ButtonProperties.ShowFocusRect = false;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(740, 516);
            this.btnStop.Name = "btnStop";
            //this.btnStop.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            //this.btnStop.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
            //this.btnStop.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            //this.btnStop.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.btnStop.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.btnStop.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.btnStop.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            //this.btnStop.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            //this.btnStop.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            //this.btnStop.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            //this.btnStop.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.btnStop.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            //this.btnStop.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            //this.btnStop.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.btnStop.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            //this.btnStop.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //this.btnStop.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            //this.btnStop.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            //this.btnStop.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            //this.btnStop.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            //this.btnStop.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 151;
            this.btnStop.Text = "Stop";
            this.btnStop.TransparentBackground = true;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // progressOptimizer
            // 
            this.progressOptimizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressOptimizer.Location = new System.Drawing.Point(373, 507);
            this.progressOptimizer.Name = "progressOptimizer";
            this.progressOptimizer.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.progressOptimizer.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.progressOptimizer.Properties.ShowText = true;
            this.progressOptimizer.Properties.Style = Nevron.UI.WinForm.Controls.ProgressBarStyle.Gradient;
            this.progressOptimizer.Size = new System.Drawing.Size(263, 24);
            this.progressOptimizer.TabIndex = 152;
            this.progressOptimizer.Visible = false;
            // 
            // ctlOptimizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = DefaultBackColor;//global::M4.Properties.Settings.Default.background_default;
            this.Controls.Add(this.progressOptimizer);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblExample);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.tabScripts);
            this.Controls.Add(this.btnOptimiza);
            this.ForeColor = DefaultForeColor;//global::M4.Properties.Settings.Default.forecolour_default;
            this.Name = "ctlOptimizer";
            this.Size = new System.Drawing.Size(911, 542);
            this.tabScripts.ResumeLayout(false);
            this.tpBuy.ResumeLayout(false);
            this.tpSell.ResumeLayout(false);
            this.tabRezult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpData)).EndInit();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScriptInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton btnOptimiza;
        internal Nevron.UI.WinForm.Controls.NTabControl tabScripts;
        internal Nevron.UI.WinForm.Controls.NTabPage tpBuy;
        internal Nevron.UI.WinForm.Controls.NTextBox txtBuyScript;
        internal Nevron.UI.WinForm.Controls.NTabPage tpSell;
        internal Nevron.UI.WinForm.Controls.NTextBox txtSellScript;
        internal Nevron.UI.WinForm.Controls.NGrouper grpData;
        internal System.Windows.Forms.Label lblMaxPeriod;
        internal System.Windows.Forms.Label lblMinPeriod;
        private Nevron.UI.WinForm.Controls.NNumericUpDown numMax;
        private Nevron.UI.WinForm.Controls.NNumericUpDown numMin;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label7;
        internal Nevron.UI.WinForm.Controls.NComboBox cboPeriodicity;
        internal System.Windows.Forms.Label Label8;
        internal Nevron.UI.WinForm.Controls.NTextBox txtBars;
        internal System.Windows.Forms.Label Label9;
        internal Nevron.UI.WinForm.Controls.NTextBox txtSymbol;
        private Nevron.UI.WinForm.Controls.NTabPage tabRezult;
        private Nevron.UI.WinForm.Controls.NListBox lstResults;
        private System.Windows.Forms.Label lblExample;
        internal NComboBox cboInterval;
        private NNumericUpDown numMax2;
        private NNumericUpDown numMin2;
        internal System.Windows.Forms.Label lblMaxPeriod2;
        internal System.Windows.Forms.Label lblMinPeriod2;
        private NNumericUpDown numScriptInterval;
        internal System.Windows.Forms.Label lblScriptInterval;
        private NButton btnSearch;
        private NButton btnStop;
        private NProgressBar progressOptimizer;
    }
}
