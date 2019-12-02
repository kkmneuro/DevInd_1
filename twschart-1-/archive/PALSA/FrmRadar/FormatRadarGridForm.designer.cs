namespace PALSA.FrmRadar
{
    partial class FormatRadarGridForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormatRadarGridForm));
            this.tcSettings = new Nevron.UI.WinForm.Controls.NTabControl();
            this.tpGrid = new Nevron.UI.WinForm.Controls.NTabPage();
            this.btnLineColour = new System.Windows.Forms.Button();
            this.lblGridLineColour = new System.Windows.Forms.Label();
            this.chkShowVerticalLines = new System.Windows.Forms.CheckBox();
            this.chkShowHorizontalLines = new System.Windows.Forms.CheckBox();
            this.tpIndicatorSettings = new Nevron.UI.WinForm.Controls.NTabPage();
            this.nudOverSoldValue = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.btnSetNegativeColour = new System.Windows.Forms.Button();
            this.lblNegativeColour = new System.Windows.Forms.Label();
            this.lblPositiveColour = new System.Windows.Forms.Label();
            this.nudOverBoughtValue = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.btnSetPositiveColour = new System.Windows.Forms.Button();
            this.lstIndicators = new Nevron.UI.WinForm.Controls.NListBox();
            this.indicatorImageList = new System.Windows.Forms.ImageList(this.components);
            this.tpFont = new Nevron.UI.WinForm.Controls.NTabPage();
            this.btnChangeFont = new Nevron.UI.WinForm.Controls.NButton();
            this.lblCurrentFont = new System.Windows.Forms.Label();
            this.tpGeneral = new Nevron.UI.WinForm.Controls.NTabPage();
            this.txtPageName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.lblPageName = new System.Windows.Forms.Label();
            this.cboNumberOfBars = new Nevron.UI.WinForm.Controls.NComboBox();
            this.cboInterval = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblDefaultBarCount = new System.Windows.Forms.Label();
            this.cboPeriodicity = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblPeriodicity = new System.Windows.Forms.Label();
            this.lblInterval = new System.Windows.Forms.Label();
            this.chkIndicatorsEnabled = new System.Windows.Forms.CheckBox();
            this.pnlButtons = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.btnApply = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.tcSettings.SuspendLayout();
            this.tpGrid.SuspendLayout();
            this.tpIndicatorSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverSoldValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverBoughtValue)).BeginInit();
            this.tpFont.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcSettings
            // 
            this.tcSettings.Controls.Add(this.tpFont);
            this.tcSettings.Controls.Add(this.tpGrid);
            this.tcSettings.Controls.Add(this.tpIndicatorSettings);
            this.tcSettings.Controls.Add(this.tpGeneral);
            this.tcSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSettings.Location = new System.Drawing.Point(0, 0);
            this.tcSettings.Name = "tcSettings";
            this.tcSettings.Padding = new System.Windows.Forms.Padding(4, 29, 4, 4);
            this.tcSettings.Selectable = true;
            this.tcSettings.SelectedIndex = 2;
            this.tcSettings.Size = new System.Drawing.Size(410, 318);
            this.tcSettings.TabIndex = 0;
            // 
            // tpGrid
            // 
            this.tpGrid.Controls.Add(this.btnLineColour);
            this.tpGrid.Controls.Add(this.lblGridLineColour);
            this.tpGrid.Controls.Add(this.chkShowVerticalLines);
            this.tpGrid.Controls.Add(this.chkShowHorizontalLines);
            this.tpGrid.Location = new System.Drawing.Point(4, 29);
            this.tpGrid.Name = "tpGrid";
            this.tpGrid.Size = new System.Drawing.Size(391, 275);
            this.tpGrid.TabIndex = 2;
            this.tpGrid.Text = "Grid Settings";
            // 
            // btnLineColour
            // 
            this.btnLineColour.Location = new System.Drawing.Point(65, 52);
            this.btnLineColour.Name = "btnLineColour";
            this.btnLineColour.Size = new System.Drawing.Size(26, 23);
            this.btnLineColour.TabIndex = 7;
            this.btnLineColour.Text = "...";
            this.btnLineColour.UseVisualStyleBackColor = true;
            this.btnLineColour.Click += new System.EventHandler(this.btnSetColour_Click);
            // 
            // lblGridLineColour
            // 
            this.lblGridLineColour.AutoSize = true;
            this.lblGridLineColour.ForeColor = System.Drawing.Color.Black;
            this.lblGridLineColour.Location = new System.Drawing.Point(0, 57);
            this.lblGridLineColour.Name = "lblGridLineColour";
            this.lblGridLineColour.Size = new System.Drawing.Size(59, 13);
            this.lblGridLineColour.TabIndex = 2;
            this.lblGridLineColour.Text = "Line colour";
            // 
            // chkShowVerticalLines
            // 
            this.chkShowVerticalLines.AutoSize = true;
            this.chkShowVerticalLines.ForeColor = System.Drawing.Color.Black;
            this.chkShowVerticalLines.Location = new System.Drawing.Point(3, 26);
            this.chkShowVerticalLines.Name = "chkShowVerticalLines";
            this.chkShowVerticalLines.Size = new System.Drawing.Size(114, 17);
            this.chkShowVerticalLines.TabIndex = 1;
            this.chkShowVerticalLines.Text = "Show vertical lines";
            // 
            // chkShowHorizontalLines
            // 
            this.chkShowHorizontalLines.AutoSize = true;
            this.chkShowHorizontalLines.ForeColor = System.Drawing.Color.Black;
            this.chkShowHorizontalLines.Location = new System.Drawing.Point(3, 3);
            this.chkShowHorizontalLines.Name = "chkShowHorizontalLines";
            this.chkShowHorizontalLines.Size = new System.Drawing.Size(125, 17);
            this.chkShowHorizontalLines.TabIndex = 0;
            this.chkShowHorizontalLines.Text = "Show horizontal lines";
            // 
            // tpIndicatorSettings
            // 
            this.tpIndicatorSettings.Controls.Add(this.nudOverSoldValue);
            this.tpIndicatorSettings.Controls.Add(this.btnSetNegativeColour);
            this.tpIndicatorSettings.Controls.Add(this.lblNegativeColour);
            this.tpIndicatorSettings.Controls.Add(this.lblPositiveColour);
            this.tpIndicatorSettings.Controls.Add(this.nudOverBoughtValue);
            this.tpIndicatorSettings.Controls.Add(this.btnSetPositiveColour);
            this.tpIndicatorSettings.Controls.Add(this.lstIndicators);
            this.tpIndicatorSettings.Location = new System.Drawing.Point(4, 29);
            this.tpIndicatorSettings.Name = "tpIndicatorSettings";
            this.tpIndicatorSettings.Size = new System.Drawing.Size(391, 275);
            this.tpIndicatorSettings.TabIndex = 3;
            this.tpIndicatorSettings.Text = "Indicator Settings";
            // 
            // nudOverSoldValue
            // 
            this.nudOverSoldValue.Location = new System.Drawing.Point(92, 181);
            this.nudOverSoldValue.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudOverSoldValue.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.nudOverSoldValue.Name = "nudOverSoldValue";
            this.nudOverSoldValue.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.nudOverSoldValue.Size = new System.Drawing.Size(99, 20);
            this.nudOverSoldValue.TabIndex = 7;
            this.nudOverSoldValue.ValueChanged += new System.EventHandler(this.nudOverSoldValue_ValueChanged);
            // 
            // btnSetNegativeColour
            // 
            this.btnSetNegativeColour.Location = new System.Drawing.Point(203, 181);
            this.btnSetNegativeColour.Name = "btnSetNegativeColour";
            this.btnSetNegativeColour.Size = new System.Drawing.Size(26, 23);
            this.btnSetNegativeColour.TabIndex = 6;
            this.btnSetNegativeColour.Text = "...";
            this.btnSetNegativeColour.UseVisualStyleBackColor = true;
            this.btnSetNegativeColour.Click += new System.EventHandler(this.btnSetColour_Click);
            // 
            // lblNegativeColour
            // 
            this.lblNegativeColour.AutoSize = true;
            this.lblNegativeColour.ForeColor = System.Drawing.Color.Black;
            this.lblNegativeColour.Location = new System.Drawing.Point(8, 180);
            this.lblNegativeColour.Name = "lblNegativeColour";
            this.lblNegativeColour.Size = new System.Drawing.Size(64, 13);
            this.lblNegativeColour.TabIndex = 5;
            this.lblNegativeColour.Text = "Oversold <=";
            // 
            // lblPositiveColour
            // 
            this.lblPositiveColour.AutoSize = true;
            this.lblPositiveColour.ForeColor = System.Drawing.Color.Black;
            this.lblPositiveColour.Location = new System.Drawing.Point(8, 148);
            this.lblPositiveColour.Name = "lblPositiveColour";
            this.lblPositiveColour.Size = new System.Drawing.Size(78, 13);
            this.lblPositiveColour.TabIndex = 4;
            this.lblPositiveColour.Text = "Overbought >=";
            // 
            // nudOverBoughtValue
            // 
            this.nudOverBoughtValue.Location = new System.Drawing.Point(92, 148);
            this.nudOverBoughtValue.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudOverBoughtValue.Minimum = new decimal(new int[] {
            999999,
            0,
            0,
            -2147483648});
            this.nudOverBoughtValue.Name = "nudOverBoughtValue";
            this.nudOverBoughtValue.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.nudOverBoughtValue.Size = new System.Drawing.Size(99, 20);
            this.nudOverBoughtValue.TabIndex = 3;
            this.nudOverBoughtValue.ValueChanged += new System.EventHandler(this.nudOverBoughtValue_ValueChanged);
            // 
            // btnSetPositiveColour
            // 
            this.btnSetPositiveColour.Location = new System.Drawing.Point(203, 148);
            this.btnSetPositiveColour.Name = "btnSetPositiveColour";
            this.btnSetPositiveColour.Size = new System.Drawing.Size(26, 23);
            this.btnSetPositiveColour.TabIndex = 1;
            this.btnSetPositiveColour.Text = "...";
            this.btnSetPositiveColour.UseVisualStyleBackColor = true;
            this.btnSetPositiveColour.Click += new System.EventHandler(this.btnSetColour_Click);
            // 
            // lstIndicators
            // 
            this.lstIndicators.DefaultImageIndex = 0;
            this.lstIndicators.ImageList = this.indicatorImageList;
            this.lstIndicators.Location = new System.Drawing.Point(3, 3);
            this.lstIndicators.Name = "lstIndicators";
            this.lstIndicators.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.lstIndicators.Size = new System.Drawing.Size(380, 124);
            this.lstIndicators.TabIndex = 0;
            this.lstIndicators.SelectedIndexChanged += new System.EventHandler(this.lstIndicators_SelectedIndexChanged);
            // 
            // indicatorImageList
            // 
            this.indicatorImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("indicatorImageList.ImageStream")));
            this.indicatorImageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.indicatorImageList.Images.SetKeyName(0, "Bands.bmp");
            this.indicatorImageList.Images.SetKeyName(1, "CustomIndicator.png");
            // 
            // tpFont
            // 
            this.tpFont.Controls.Add(this.btnChangeFont);
            this.tpFont.Controls.Add(this.lblCurrentFont);
            this.tpFont.Location = new System.Drawing.Point(4, 29);
            this.tpFont.Name = "tpFont";
            this.tpFont.Size = new System.Drawing.Size(402, 285);
            this.tpFont.TabIndex = 4;
            this.tpFont.Text = "Font";
            // 
            // btnChangeFont
            // 
            this.btnChangeFont.Location = new System.Drawing.Point(3, 41);
            this.btnChangeFont.Name = "btnChangeFont";
            this.btnChangeFont.Size = new System.Drawing.Size(75, 23);
            this.btnChangeFont.TabIndex = 1;
            this.btnChangeFont.Text = "Change Font";
            this.btnChangeFont.UseVisualStyleBackColor = false;
            this.btnChangeFont.Click += new System.EventHandler(this.btnChangeFont_Click);
            // 
            // lblCurrentFont
            // 
            this.lblCurrentFont.AutoSize = true;
            this.lblCurrentFont.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentFont.Location = new System.Drawing.Point(3, 10);
            this.lblCurrentFont.Name = "lblCurrentFont";
            this.lblCurrentFont.Size = new System.Drawing.Size(62, 13);
            this.lblCurrentFont.TabIndex = 0;
            this.lblCurrentFont.Text = "Current font";
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.txtPageName);
            this.tpGeneral.Controls.Add(this.lblPageName);
            this.tpGeneral.Controls.Add(this.cboNumberOfBars);
            this.tpGeneral.Controls.Add(this.cboInterval);
            this.tpGeneral.Controls.Add(this.lblDefaultBarCount);
            this.tpGeneral.Controls.Add(this.cboPeriodicity);
            this.tpGeneral.Controls.Add(this.lblPeriodicity);
            this.tpGeneral.Controls.Add(this.lblInterval);
            this.tpGeneral.Controls.Add(this.chkIndicatorsEnabled);
            this.tpGeneral.Location = new System.Drawing.Point(4, 29);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(391, 275);
            this.tpGeneral.TabIndex = 1;
            this.tpGeneral.Text = "General";
            // 
            // txtPageName
            // 
            this.txtPageName.Location = new System.Drawing.Point(101, 7);
            this.txtPageName.Name = "txtPageName";
            this.txtPageName.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.txtPageName.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
            this.txtPageName.Palette.Border = System.Drawing.SystemColors.ControlDark;
            this.txtPageName.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPageName.Palette.CaptionText = System.Drawing.Color.White;
            this.txtPageName.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.txtPageName.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.txtPageName.Palette.ControlBorder = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.txtPageName.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPageName.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtPageName.Palette.Highlight = System.Drawing.SystemColors.Highlight;
            this.txtPageName.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.txtPageName.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.txtPageName.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
            this.txtPageName.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtPageName.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txtPageName.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.txtPageName.Palette.Window = System.Drawing.SystemColors.Window;
            this.txtPageName.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtPageName.Size = new System.Drawing.Size(186, 18);
            this.txtPageName.TabIndex = 37;
            // 
            // lblPageName
            // 
            this.lblPageName.AutoSize = true;
            this.lblPageName.ForeColor = System.Drawing.Color.Black;
            this.lblPageName.Location = new System.Drawing.Point(5, 7);
            this.lblPageName.Name = "lblPageName";
            this.lblPageName.Size = new System.Drawing.Size(63, 13);
            this.lblPageName.TabIndex = 36;
            this.lblPageName.Text = "Page Name";
            // 
            // cboNumberOfBars
            // 
            this.cboNumberOfBars.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("100", -1, true, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("200", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("250", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("300", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("500", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("1000", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cboNumberOfBars.ListProperties.ColumnOnLeft = false;
            this.cboNumberOfBars.Location = new System.Drawing.Point(101, 85);
            this.cboNumberOfBars.Name = "cboNumberOfBars";
            this.cboNumberOfBars.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.cboNumberOfBars.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.cboNumberOfBars.Size = new System.Drawing.Size(186, 20);
            this.cboNumberOfBars.TabIndex = 35;
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
            this.cboInterval.Location = new System.Drawing.Point(101, 59);
            this.cboInterval.Name = "cboInterval";
            this.cboInterval.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.cboInterval.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.cboInterval.Size = new System.Drawing.Size(186, 20);
            this.cboInterval.TabIndex = 34;
            // 
            // lblDefaultBarCount
            // 
            this.lblDefaultBarCount.AutoSize = true;
            this.lblDefaultBarCount.ForeColor = System.Drawing.Color.Black;
            this.lblDefaultBarCount.Location = new System.Drawing.Point(7, 85);
            this.lblDefaultBarCount.Name = "lblDefaultBarCount";
            this.lblDefaultBarCount.Size = new System.Drawing.Size(49, 13);
            this.lblDefaultBarCount.TabIndex = 26;
            this.lblDefaultBarCount.Text = "# of bars";
            // 
            // cboPeriodicity
            // 
            this.cboPeriodicity.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Minute", -1, true, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Hour", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Day", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Week", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cboPeriodicity.ListProperties.ColumnOnLeft = false;
            this.cboPeriodicity.Location = new System.Drawing.Point(101, 31);
            this.cboPeriodicity.Name = "cboPeriodicity";
            this.cboPeriodicity.Palette.Scheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.cboPeriodicity.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.cboPeriodicity.Size = new System.Drawing.Size(186, 22);
            this.cboPeriodicity.TabIndex = 21;
            this.cboPeriodicity.Text = "NComboBox1";
            this.cboPeriodicity.SelectedIndexChanged += new System.EventHandler(this.cboPeriodicity_SelectedIndexChanged);
            // 
            // lblPeriodicity
            // 
            this.lblPeriodicity.AutoSize = true;
            this.lblPeriodicity.ForeColor = System.Drawing.Color.Black;
            this.lblPeriodicity.Location = new System.Drawing.Point(7, 35);
            this.lblPeriodicity.Name = "lblPeriodicity";
            this.lblPeriodicity.Size = new System.Drawing.Size(92, 13);
            this.lblPeriodicity.TabIndex = 24;
            this.lblPeriodicity.Text = "Default Periodicity";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.ForeColor = System.Drawing.Color.Black;
            this.lblInterval.Location = new System.Drawing.Point(7, 59);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(79, 13);
            this.lblInterval.TabIndex = 23;
            this.lblInterval.Text = "Default Interval";
            // 
            // chkIndicatorsEnabled
            // 
            this.chkIndicatorsEnabled.AutoSize = true;
            this.chkIndicatorsEnabled.Checked = true;
            this.chkIndicatorsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIndicatorsEnabled.ForeColor = System.Drawing.Color.Black;
            this.chkIndicatorsEnabled.Location = new System.Drawing.Point(101, 119);
            this.chkIndicatorsEnabled.Name = "chkIndicatorsEnabled";
            this.chkIndicatorsEnabled.Size = new System.Drawing.Size(113, 17);
            this.chkIndicatorsEnabled.TabIndex = 2;
            this.chkIndicatorsEnabled.Text = "Indicators enabled";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlButtons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlButtons.Controls.Add(this.btnApply);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.FillInfo.Color = System.Drawing.Color.Transparent;
            this.pnlButtons.FillInfo.Draw = false;
            this.pnlButtons.Location = new System.Drawing.Point(0, 279);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(410, 39);
            this.pnlButtons.TabIndex = 26;
            this.pnlButtons.Text = "nuiPanel1";
            // 
            // btnApply
            // 
            this.btnApply.ButtonProperties.ShowFocusRect = false;
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(226, 7);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "&Apply";
            this.btnApply.TransparentBackground = true;
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonProperties.ShowFocusRect = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(307, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.TransparentBackground = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormatRadarGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 318);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.tcSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormatRadarGridForm";
            this.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Edit the active Radar View template";
            this.TopMost = true;
            this.tcSettings.ResumeLayout(false);
            this.tpGrid.ResumeLayout(false);
            this.tpGrid.PerformLayout();
            this.tpIndicatorSettings.ResumeLayout(false);
            this.tpIndicatorSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverSoldValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverBoughtValue)).EndInit();
            this.tpFont.ResumeLayout(false);
            this.tpFont.PerformLayout();
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTabControl tcSettings;
        private Nevron.UI.WinForm.Controls.NTabPage tpGeneral;
        private System.Windows.Forms.CheckBox chkIndicatorsEnabled;
        internal Nevron.UI.WinForm.Controls.NComboBox cboPeriodicity;
        private System.Windows.Forms.Label lblPeriodicity;
        private System.Windows.Forms.Label lblInterval;
        private Nevron.UI.WinForm.Controls.NTabPage tpFont;
        private Nevron.UI.WinForm.Controls.NTabPage tpGrid;
        private Nevron.UI.WinForm.Controls.NUIPanel pnlButtons;
        private Nevron.UI.WinForm.Controls.NButton btnApply;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private System.Windows.Forms.CheckBox chkShowVerticalLines;
        private System.Windows.Forms.CheckBox chkShowHorizontalLines;
        private System.Windows.Forms.Label lblCurrentFont;
        private Nevron.UI.WinForm.Controls.NButton btnChangeFont;
        private System.Windows.Forms.Label lblDefaultBarCount;
        private Nevron.UI.WinForm.Controls.NTabPage tpIndicatorSettings;
        private Nevron.UI.WinForm.Controls.NListBox lstIndicators;
        internal System.Windows.Forms.ImageList indicatorImageList;
        private System.Windows.Forms.Button btnSetPositiveColour;
        private Nevron.UI.WinForm.Controls.NNumericUpDown nudOverBoughtValue;
        private System.Windows.Forms.Label lblPositiveColour;
        private System.Windows.Forms.Label lblNegativeColour;
        private System.Windows.Forms.Button btnSetNegativeColour;
        private System.Windows.Forms.Label lblGridLineColour;
        private System.Windows.Forms.Button btnLineColour;
        internal Nevron.UI.WinForm.Controls.NComboBox cboInterval;
        internal Nevron.UI.WinForm.Controls.NComboBox cboNumberOfBars;
        private Nevron.UI.WinForm.Controls.NNumericUpDown nudOverSoldValue;
        private Nevron.UI.WinForm.Controls.NTextBox txtPageName;
        private System.Windows.Forms.Label lblPageName;
    }
}