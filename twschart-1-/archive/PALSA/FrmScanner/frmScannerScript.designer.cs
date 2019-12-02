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

	partial class frmScannerScript : NForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScannerScript));
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.btnHelp = new Nevron.UI.WinForm.Controls.NButton();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.NGrouper1 = new Nevron.UI.WinForm.Controls.NGrouper();
            this.txtScript = new Nevron.UI.WinForm.Controls.NTextBox();
            this.TableLayoutPanel1.SuspendLayout();
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
            this.TableLayoutPanel1.Location = new System.Drawing.Point(428, 196);
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
            this.btnCancel.TransparentBackground = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.ButtonProperties.ShowFocusRect = false;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            this.btnOk.TransparentBackground = true;
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonProperties.ShowFocusRect = false;
            this.btnHelp.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnHelp.Location = new System.Drawing.Point(17, 155);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.btnHelp.Palette.Caption = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.btnHelp.Palette.CaptionText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHelp.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHelp.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnHelp.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnHelp.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnHelp.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHelp.Palette.ControlText = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(8)))));
            this.btnHelp.Palette.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHelp.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnHelp.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnHelp.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.btnHelp.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.btnHelp.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHelp.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.btnHelp.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnHelp.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.btnHelp.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.btnHelp.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHelp.Size = new System.Drawing.Size(97, 23);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "&Script Guide";
            this.btnHelp.TransparentBackground = true;
            this.btnHelp.UseVisualStyleBackColor = false;
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            this.OpenFileDialog1.Filter = "CSV Files|*.csv|Text Files|*.txt";
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
            this.NGrouper1.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.NGrouper1.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.NGrouper1.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NGrouper1.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.NGrouper1.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.NGrouper1.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.NGrouper1.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.NGrouper1.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NGrouper1.Size = new System.Drawing.Size(560, 137);
            this.NGrouper1.TabIndex = 153;
            this.NGrouper1.Text = "Script";
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(4, 25);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.txtScript.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
            this.txtScript.Palette.CaptionText = System.Drawing.Color.White;
            this.txtScript.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.txtScript.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.txtScript.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtScript.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.txtScript.Palette.Highlight = System.Drawing.SystemColors.Highlight;
            this.txtScript.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.txtScript.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.txtScript.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
            this.txtScript.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtScript.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.txtScript.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.txtScript.Palette.Window = System.Drawing.SystemColors.Window;
            this.txtScript.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtScript.Size = new System.Drawing.Size(546, 103);
            this.txtScript.TabIndex = 0;
            // 
            // frmScannerScript
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(580, 228);
            this.Controls.Add(this.NGrouper1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScannerScript";
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
            this.Palette.HighlightText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            this.Palette.MenuText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Palette.PressedDark = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(223)))), ((int)(((byte)(127)))));
            this.Palette.Window = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.Palette.WindowText = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scanner Settings";
            this.UseGlassIfEnabled = Nevron.UI.WinForm.Controls.CommonTriState.False;
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NGrouper1)).EndInit();
            this.NGrouper1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
		internal Nevron.UI.WinForm.Controls.NButton btnHelp;
		internal Nevron.UI.WinForm.Controls.NButton btnOk;
		internal Nevron.UI.WinForm.Controls.NButton btnCancel;
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
		internal Nevron.UI.WinForm.Controls.NGrouper NGrouper1;

		internal Nevron.UI.WinForm.Controls.NTextBox txtScript;
		public frmScannerScript()
		{
			InitializeComponent();
		}
	}
}
