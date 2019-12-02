using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace PALSA.uctl
{
	partial class ctlScanner : System.Windows.Forms.UserControl
	{

		//UserControl overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlScanner));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_ImgList = new System.Windows.Forms.ImageList(this.components);
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.grdResults = new PALSA.uctl.M4DataGridView();
            this.contextMenuScanner = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.contextMenuScanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ImgList
            // 
            this.m_ImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ImgList.ImageStream")));
            this.m_ImgList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.m_ImgList.Images.SetKeyName(0, "");
            this.m_ImgList.Images.SetKeyName(1, "");
            this.m_ImgList.Images.SetKeyName(2, "");
            this.m_ImgList.Images.SetKeyName(3, "");
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 500;
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.grdResults);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(876, 602);
            this.nuiPanel1.TabIndex = 153;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // grdResults
            // 
            this.grdResults.AllowUserToAddRows = false;
            this.grdResults.AllowUserToDeleteRows = false;
            this.grdResults.AllowUserToResizeRows = false;
            this.grdResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.grdResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResults.ContextMenuStrip = this.contextMenuScanner;
            this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdResults.EnableCellCustomDraw = false;
            this.grdResults.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.grdResults.Location = new System.Drawing.Point(0, 0);
            this.grdResults.MultiSelect = false;
            this.grdResults.Name = "grdResults";
            this.grdResults.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdResults.RowHeadersVisible = false;
            this.grdResults.RowHeadersWidth = 4;
            this.grdResults.RowTemplate.Height = 24;
            this.grdResults.RowTemplate.ReadOnly = true;
            this.grdResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResults.Size = new System.Drawing.Size(874, 600);
            this.grdResults.TabIndex = 147;
            this.grdResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdResults_CellClick);
            // 
            // contextMenuScanner
            // 
            this.contextMenuScanner.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runScannerToolStripMenuItem});
            this.contextMenuScanner.Name = "contextMenuScanner";
            this.contextMenuScanner.Size = new System.Drawing.Size(147, 26);
            // 
            // runScannerToolStripMenuItem
            // 
            this.runScannerToolStripMenuItem.Name = "runScannerToolStripMenuItem";
            this.runScannerToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.runScannerToolStripMenuItem.Text = "Run Scanner";
            this.runScannerToolStripMenuItem.Click += new System.EventHandler(this.runScannerToolStripMenuItem_Click);
            // 
            // ctlScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "ctlScanner";
            this.Size = new System.Drawing.Size(876, 602);
            this.Load += new System.EventHandler(this.ctlScanner_Load);
            this.Resize += new System.EventHandler(this.ctlScanner_Resize);
            this.nuiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.contextMenuScanner.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		internal System.Windows.Forms.ImageList m_ImgList;
        internal System.Windows.Forms.Timer tmrUpdate;
        internal M4DataGridView grdResults;
        //Kul
        //public ctlScanner()
        //{
        //    InitializeComponent();
        //}
        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private ContextMenuStrip contextMenuScanner;
        private ToolStripMenuItem runScannerToolStripMenuItem;
	}
}
