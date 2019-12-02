using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;
namespace PALSA.FrmScanner
{

	partial class frmScannerMainSettings : NForm
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try {
				if (disposing && components != null) {
					components.Dispose();
				}
			}
			finally {
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScannerMainSettings));
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.btnHelp = new Nevron.UI.WinForm.Controls.NButton();
            this.lblSymbolFile = new System.Windows.Forms.Label();
            this.grpData = new Nevron.UI.WinForm.Controls.NGrouper();
            this.btnSelectSymbols = new Nevron.UI.WinForm.Controls.NButton();
            this.cboInterval = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nudBarCount = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboPeriodicity = new Nevron.UI.WinForm.Controls.NComboBox();
            this.btnBrowse = new Nevron.UI.WinForm.Controls.NButton();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.NGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
            this.txtScript = new Nevron.UI.WinForm.Controls.NTextBox();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpData)).BeginInit();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NGrouper1)).BeginInit();
            this.NGrouper1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.btnOk, 0, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(427, 360);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonProperties.ShowFocusRect = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(76, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.btnCancel.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
            this.btnCancel.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnCancel.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancel.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancel.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCancel.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnCancel.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnCancel.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnCancel.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnCancel.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancel.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCancel.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancel.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancel.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnCancel.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancel.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnCancel.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCancel.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.btnCancel.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.btnCancel.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCancel.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.btnCancel.Size = new System.Drawing.Size(67, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.Cancel_Button_Click_1);
            // 
            // btnOk
            // 
            this.btnOk.ButtonProperties.ShowFocusRect = false;
            this.btnOk.Location = new System.Drawing.Point(3, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.btnOk.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
            this.btnOk.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnOk.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOk.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnOk.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnOk.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnOk.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnOk.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnOk.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnOk.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnOk.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnOk.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnOk.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOk.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnOk.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOk.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnOk.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnOk.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.btnOk.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.btnOk.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnOk.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.btnOk.Size = new System.Drawing.Size(67, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.OK_Button_Click_1);
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonProperties.ShowFocusRect = false;
            this.btnHelp.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnHelp.Location = new System.Drawing.Point(17, 155);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.btnHelp.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
            this.btnHelp.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnHelp.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHelp.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHelp.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnHelp.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnHelp.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnHelp.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnHelp.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnHelp.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHelp.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnHelp.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHelp.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHelp.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnHelp.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHelp.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnHelp.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnHelp.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.btnHelp.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.btnHelp.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHelp.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.btnHelp.Size = new System.Drawing.Size(97, 23);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "&Script Guide";
            this.btnHelp.UseVisualStyleBackColor = false;
            // 
            // lblSymbolFile
            // 
            this.lblSymbolFile.AutoSize = true;
            this.lblSymbolFile.BackColor = System.Drawing.Color.Transparent;
            this.lblSymbolFile.Location = new System.Drawing.Point(458, 76);
            this.lblSymbolFile.Name = "lblSymbolFile";
            this.lblSymbolFile.Size = new System.Drawing.Size(0, 13);
            this.lblSymbolFile.TabIndex = 156;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.btnSelectSymbols);
            this.grpData.Controls.Add(this.cboInterval);
            this.grpData.Controls.Add(this.nudBarCount);
            this.grpData.Controls.Add(this.Label7);
            this.grpData.Controls.Add(this.cboPeriodicity);
            this.grpData.Controls.Add(this.lblSymbolFile);
            this.grpData.Controls.Add(this.btnBrowse);
            this.grpData.Controls.Add(this.Label6);
            this.grpData.Controls.Add(this.Label8);
            this.grpData.Controls.Add(this.Label9);
            this.grpData.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.grpData.FooterItem.Text = "Footer";
            this.grpData.FooterItem.Visible = false;
            this.grpData.HeaderItem.Text = "Data Source";
            this.grpData.Location = new System.Drawing.Point(12, 198);
            this.grpData.Name = "grpData";
            this.grpData.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.grpData.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.grpData.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpData.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpData.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.grpData.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.grpData.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grpData.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpData.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.grpData.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpData.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.grpData.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpData.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.grpData.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.grpData.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpData.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.grpData.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.grpData.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.grpData.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.grpData.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.grpData.Size = new System.Drawing.Size(559, 119);
            this.grpData.TabIndex = 152;
            this.grpData.Text = "Data Source";
            // 
            // btnSelectSymbols
            // 
            this.btnSelectSymbols.ButtonProperties.ShowFocusRect = false;
            this.btnSelectSymbols.Location = new System.Drawing.Point(332, 73);
            this.btnSelectSymbols.Name = "btnSelectSymbols";
            this.btnSelectSymbols.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.btnSelectSymbols.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
            this.btnSelectSymbols.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnSelectSymbols.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSelectSymbols.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnSelectSymbols.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSelectSymbols.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnSelectSymbols.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnSelectSymbols.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnSelectSymbols.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnSelectSymbols.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnSelectSymbols.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSelectSymbols.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnSelectSymbols.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSelectSymbols.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnSelectSymbols.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSelectSymbols.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnSelectSymbols.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSelectSymbols.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.btnSelectSymbols.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.btnSelectSymbols.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSelectSymbols.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.btnSelectSymbols.Size = new System.Drawing.Size(120, 20);
            this.btnSelectSymbols.TabIndex = 161;
            this.btnSelectSymbols.Text = "From symbol lookup...";
            this.btnSelectSymbols.TransparentBackground = true;
            this.btnSelectSymbols.UseVisualStyleBackColor = false;
            this.btnSelectSymbols.Click += new System.EventHandler(this.btnSelectSymbols_Click);
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
            this.cboInterval.Location = new System.Drawing.Point(83, 39);
            this.cboInterval.Name = "cboInterval";
            this.cboInterval.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.cboInterval.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.cboInterval.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboInterval.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cboInterval.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cboInterval.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cboInterval.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cboInterval.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboInterval.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.cboInterval.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cboInterval.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cboInterval.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cboInterval.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cboInterval.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.cboInterval.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboInterval.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.cboInterval.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cboInterval.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.cboInterval.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.cboInterval.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.cboInterval.Size = new System.Drawing.Size(77, 20);
            this.cboInterval.TabIndex = 160;
            // 
            // nudBarCount
            // 
            this.nudBarCount.Location = new System.Drawing.Point(84, 73);
            this.nudBarCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudBarCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudBarCount.Name = "nudBarCount";
            this.nudBarCount.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.nudBarCount.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.nudBarCount.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nudBarCount.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nudBarCount.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudBarCount.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.nudBarCount.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.nudBarCount.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nudBarCount.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.nudBarCount.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nudBarCount.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.nudBarCount.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nudBarCount.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.nudBarCount.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.nudBarCount.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nudBarCount.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.nudBarCount.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.nudBarCount.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.nudBarCount.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.nudBarCount.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.nudBarCount.Size = new System.Drawing.Size(76, 20);
            this.nudBarCount.TabIndex = 159;
            this.nudBarCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Location = new System.Drawing.Point(185, 43);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(55, 13);
            this.Label7.TabIndex = 158;
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
            this.cboPeriodicity.Location = new System.Drawing.Point(247, 39);
            this.cboPeriodicity.Name = "cboPeriodicity";
            this.cboPeriodicity.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.cboPeriodicity.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.cboPeriodicity.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboPeriodicity.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cboPeriodicity.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cboPeriodicity.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cboPeriodicity.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cboPeriodicity.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboPeriodicity.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.cboPeriodicity.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cboPeriodicity.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cboPeriodicity.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cboPeriodicity.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cboPeriodicity.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.cboPeriodicity.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboPeriodicity.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.cboPeriodicity.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cboPeriodicity.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.cboPeriodicity.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.cboPeriodicity.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.cboPeriodicity.Size = new System.Drawing.Size(79, 20);
            this.cboPeriodicity.TabIndex = 4;
            this.cboPeriodicity.SelectedIndexChanged += new System.EventHandler(this.cboPeriodicity_SelectedIndexChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.ButtonProperties.ShowFocusRect = false;
            this.btnBrowse.Location = new System.Drawing.Point(247, 73);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.btnBrowse.Palette.BlendStyle = Nevron.UI.BlendStyle.Aqua;
            this.btnBrowse.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnBrowse.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowse.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnBrowse.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnBrowse.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnBrowse.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnBrowse.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnBrowse.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnBrowse.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnBrowse.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnBrowse.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnBrowse.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowse.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnBrowse.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowse.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnBrowse.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnBrowse.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.btnBrowse.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.btnBrowse.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrowse.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.btnBrowse.Size = new System.Drawing.Size(79, 20);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "From file...";
            this.btnBrowse.TransparentBackground = true;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Location = new System.Drawing.Point(16, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(61, 13);
            this.Label6.TabIndex = 109;
            this.Label6.Text = "Bar Interval";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Location = new System.Drawing.Point(19, 76);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(58, 13);
            this.Label8.TabIndex = 107;
            this.Label8.Text = "Bar History";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Location = new System.Drawing.Point(193, 75);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(46, 13);
            this.Label9.TabIndex = 106;
            this.Label9.Text = "Symbols";
            // 
            // NGrouper1
            // 
            this.NGrouper1.Controls.Add(this.txtScript);
            this.NGrouper1.FooterItem.ContentAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NGrouper1.FooterItem.Text = "Footer";
            this.NGrouper1.FooterItem.Visible = false;
            this.NGrouper1.HeaderItem.Text = "Script (will be applied to all unlocked symbols)";
            this.NGrouper1.Location = new System.Drawing.Point(12, 15);
            this.NGrouper1.Name = "NGrouper1";
            this.NGrouper1.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.NGrouper1.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.NGrouper1.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NGrouper1.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.NGrouper1.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.NGrouper1.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.NGrouper1.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.NGrouper1.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NGrouper1.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.NGrouper1.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.NGrouper1.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.NGrouper1.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.NGrouper1.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.NGrouper1.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.NGrouper1.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NGrouper1.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.NGrouper1.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.NGrouper1.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.NGrouper1.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.NGrouper1.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.NGrouper1.Size = new System.Drawing.Size(560, 137);
            this.NGrouper1.TabIndex = 153;
            this.NGrouper1.Text = "Script";
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(4, 25);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.txtScript.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.txtScript.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtScript.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtScript.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtScript.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.txtScript.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtScript.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtScript.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.txtScript.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtScript.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtScript.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtScript.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtScript.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.txtScript.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtScript.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.txtScript.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtScript.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.txtScript.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.txtScript.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScript.Size = new System.Drawing.Size(546, 103);
            this.txtScript.TabIndex = 0;
            this.txtScript.TextChanged += new System.EventHandler(this.txtScript_TextChanged);
            // 
            // frmScannerMainSettings
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(580, 394);
            this.Controls.Add(this.NGrouper1);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScannerMainSettings";
            this.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scanner Settings";
            this.UseGlassIfEnabled = Nevron.UI.WinForm.Controls.CommonTriState.False;
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpData)).EndInit();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBarCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NGrouper1)).EndInit();
            this.NGrouper1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal Nevron.UI.WinForm.Controls.NButton btnHelp;
		internal Nevron.UI.WinForm.Controls.NGrouper grpData;
		internal Nevron.UI.WinForm.Controls.NButton btnBrowse;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label9;
		internal Nevron.UI.WinForm.Controls.NButton btnOk;
        internal Nevron.UI.WinForm.Controls.NButton btnCancel;
		internal System.Windows.Forms.Label lblSymbolFile;
		internal System.Windows.Forms.Label Label7;
		internal Nevron.UI.WinForm.Controls.NComboBox cboPeriodicity;
		internal Nevron.UI.WinForm.Controls.NGrouper NGrouper1;

		internal Nevron.UI.WinForm.Controls.NTextBox txtScript;
		public frmScannerMainSettings()
		{
			InitializeComponent();
		}

        private NNumericUpDown nudBarCount;
        internal NComboBox cboInterval;
        internal NButton btnSelectSymbols;
	}
}
