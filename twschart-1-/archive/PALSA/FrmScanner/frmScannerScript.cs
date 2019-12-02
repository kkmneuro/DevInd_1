using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PALSA.FrmScanner
{
	public partial class frmScannerScript
	{
		public frmScannerScript(string initializationScript)
		{
			InitializeComponent();
            //Kul
            //if (frmMain.NevronPalette != null)
            //    Palette = frmMain.NevronPalette;
            Script = initializationScript;
		}

		public string HeaderText {
			get { return NGrouper1.HeaderItem.Text; }
			set { NGrouper1.HeaderItem.Text = value; }
		}

		public string Script 
        {
			get { return txtScript.Text; }
			set { txtScript.Text = value; }
		}
	}
}
