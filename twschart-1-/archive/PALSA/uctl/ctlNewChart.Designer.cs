namespace PALSA.uctl
{
    partial class ctlNewChart
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlNewChart));
            this.ui_cmsChart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_mnuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllDrawingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_tsmDeleteIndicator = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuDeleteObject = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmDeleteObject = new Nevron.UI.WinForm.Controls.NContextMenu();
            this.mnuProperty = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuDeleteObject = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuObjList = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuSelDelete = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuUnselAll = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuUnselect = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuUndoDelete = new Nevron.UI.WinForm.Controls.NCommand();
            this.ctmDeleteSeries = new Nevron.UI.WinForm.Controls.NContextMenu();
            this.mnuIndProperty = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuEditSeries = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuDeleteSeries = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuDeleteIndicatorWindow = new Nevron.UI.WinForm.Controls.NCommand();
            this.mnuIndicatorList = new Nevron.UI.WinForm.Controls.NCommand();
            this.ui_ocxStockChart = new AxSTOCKCHARTXLib.AxStockChartX();
            this.trendLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_cmsChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ocxStockChart)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_cmsChart
            // 
            this.ui_cmsChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_mnuProperties,
            this.horizontalLineToolStripMenuItem,
            this.verticalLineToolStripMenuItem,
            this.trendLineToolStripMenuItem,
            this.deleteAllDrawingsToolStripMenuItem,
            this.ui_tsmDeleteIndicator,
            this.ui_mnuDeleteObject});
            this.ui_cmsChart.Name = "ui_cmsChart";
            this.ui_cmsChart.Size = new System.Drawing.Size(177, 180);
            // 
            // ui_mnuProperties
            // 
            this.ui_mnuProperties.Name = "ui_mnuProperties";
            this.ui_mnuProperties.Size = new System.Drawing.Size(176, 22);
            this.ui_mnuProperties.Text = "Properties";
            this.ui_mnuProperties.Click += new System.EventHandler(this.ui_mnuProperties_Click_1);
            // 
            // horizontalLineToolStripMenuItem
            // 
            this.horizontalLineToolStripMenuItem.Name = "horizontalLineToolStripMenuItem";
            this.horizontalLineToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.horizontalLineToolStripMenuItem.Text = "Horizontal Line";
            this.horizontalLineToolStripMenuItem.Click += new System.EventHandler(this.horizontalLineToolStripMenuItem_Click);
            // 
            // verticalLineToolStripMenuItem
            // 
            this.verticalLineToolStripMenuItem.Name = "verticalLineToolStripMenuItem";
            this.verticalLineToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.verticalLineToolStripMenuItem.Text = "Vertical Line";
            this.verticalLineToolStripMenuItem.Click += new System.EventHandler(this.verticalLineToolStripMenuItem_Click);
            // 
            // deleteAllDrawingsToolStripMenuItem
            // 
            this.deleteAllDrawingsToolStripMenuItem.Name = "deleteAllDrawingsToolStripMenuItem";
            this.deleteAllDrawingsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.deleteAllDrawingsToolStripMenuItem.Text = "Delete All Drawings";
            this.deleteAllDrawingsToolStripMenuItem.Click += new System.EventHandler(this.deleteAllDrawingsToolStripMenuItem_Click);
            // 
            // ui_tsmDeleteIndicator
            // 
            this.ui_tsmDeleteIndicator.Name = "ui_tsmDeleteIndicator";
            this.ui_tsmDeleteIndicator.Size = new System.Drawing.Size(176, 22);
            this.ui_tsmDeleteIndicator.Text = "Delete Indicator";
            this.ui_tsmDeleteIndicator.Click += new System.EventHandler(this.ui_tsmDeleteIndicator_Click_1);
            // 
            // ui_mnuDeleteObject
            // 
            this.ui_mnuDeleteObject.Name = "ui_mnuDeleteObject";
            this.ui_mnuDeleteObject.Size = new System.Drawing.Size(176, 22);
            this.ui_mnuDeleteObject.Text = "Delete Object";
            this.ui_mnuDeleteObject.Click += new System.EventHandler(this.ui_mnuDeleteObject_Click_1);
            // 
            // ctmDeleteObject
            // 
            this.ctmDeleteObject.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.mnuProperty,
            this.mnuDeleteObject,
            this.mnuObjList,
            this.mnuSelDelete,
            this.mnuUnselAll,
            this.mnuUnselect,
            this.mnuUndoDelete});
            // 
            // mnuDeleteObject
            // 
            this.mnuDeleteObject.Properties.ImageIndex = 12;
            this.mnuDeleteObject.Properties.Text = "Delete Object";
            // 
            // mnuObjList
            // 
            this.mnuObjList.Properties.BeginGroup = true;
            this.mnuObjList.Properties.ImageIndex = 20;
            this.mnuObjList.Properties.Text = "Objects List";
            // 
            // mnuSelDelete
            // 
            this.mnuSelDelete.Properties.ImageIndex = 22;
            this.mnuSelDelete.Properties.Text = "Delete All Selected";
            // 
            // mnuUnselAll
            // 
            this.mnuUnselAll.Properties.BeginGroup = true;
            this.mnuUnselAll.Properties.ImageIndex = 24;
            this.mnuUnselAll.Properties.Text = "Unselect All";
            // 
            // mnuUnselect
            // 
            this.mnuUnselect.Properties.ImageIndex = 23;
            this.mnuUnselect.Properties.Text = "Unselect";
            // 
            // mnuUndoDelete
            // 
            this.mnuUndoDelete.Enabled = false;
            this.mnuUndoDelete.Properties.BeginGroup = true;
            this.mnuUndoDelete.Properties.Text = "Undo Delete";
            this.mnuUndoDelete.Properties.Visible = false;
            // 
            // ctmDeleteSeries
            // 
            this.ctmDeleteSeries.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.mnuIndProperty,
            this.mnuEditSeries,
            this.mnuDeleteSeries,
            this.mnuDeleteIndicatorWindow,
            this.mnuIndicatorList});
            // 
            // mnuIndProperty
            // 
            this.mnuIndProperty.Properties.ImageIndex = 11;
            this.mnuIndProperty.Properties.Text = "Indicators Properties";
            // 
            // mnuEditSeries
            // 
            this.mnuEditSeries.Properties.ImageIndex = 41;
            this.mnuEditSeries.Properties.Text = "Edit Series";
            this.mnuEditSeries.Properties.Visible = false;
            // 
            // mnuDeleteSeries
            // 
            this.mnuDeleteSeries.Properties.ImageIndex = 42;
            this.mnuDeleteSeries.Properties.Text = "Delete Series";
            // 
            // mnuDeleteIndicatorWindow
            // 
            this.mnuDeleteIndicatorWindow.Properties.ImageIndex = 12;
            this.mnuDeleteIndicatorWindow.Properties.Text = "Delete Indicator Window";
            // 
            // mnuIndicatorList
            // 
            this.mnuIndicatorList.Properties.ImageIndex = 18;
            this.mnuIndicatorList.Properties.Text = "Indicator List";
            // 
            // ui_ocxStockChart
            // 
            this.ui_ocxStockChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ocxStockChart.Enabled = true;
            this.ui_ocxStockChart.Location = new System.Drawing.Point(0, 0);
            this.ui_ocxStockChart.Name = "ui_ocxStockChart";
            this.ui_ocxStockChart.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ui_ocxStockChart.OcxState")));
            this.ui_ocxStockChart.Size = new System.Drawing.Size(800, 400);
            this.ui_ocxStockChart.TabIndex = 1;
            this.ui_ocxStockChart.MouseMoveEvent += new AxSTOCKCHARTXLib._DStockChartXEvents_MouseMoveEventHandler(this.ui_ocxStockChart_MouseMoveEvent);
            this.ui_ocxStockChart.ItemLeftClick += new AxSTOCKCHARTXLib._DStockChartXEvents_ItemLeftClickEventHandler(this.ui_ocxStockChart_ItemLeftClick);
            this.ui_ocxStockChart.MouseEnterEvent += new System.EventHandler(this.ui_ocxStockChart_MouseEnterEvent);
            this.ui_ocxStockChart.EnumIndicator += new AxSTOCKCHARTXLib._DStockChartXEvents_EnumIndicatorEventHandler(this.ui_ocxStockChart_EnumIndicator);
            // 
            // trendLineToolStripMenuItem
            // 
            this.trendLineToolStripMenuItem.Name = "trendLineToolStripMenuItem";
            this.trendLineToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.trendLineToolStripMenuItem.Text = "Trend Line";
            this.trendLineToolStripMenuItem.Click += new System.EventHandler(this.trendLineToolStripMenuItem_Click);
            // 
            // ctlNewChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.ui_cmsChart;
            this.Controls.Add(this.ui_ocxStockChart);
            this.Name = "ctlNewChart";
            this.Size = new System.Drawing.Size(800, 400);
            this.Load += new System.EventHandler(this.ctlNewChart_Load);
            this.ui_cmsChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ocxStockChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ui_cmsChart;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuDeleteObject;
        //public AxSTOCKCHARTXLib.AxStockChartX ui_ocxStockChart;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuProperties;
        private System.Windows.Forms.ToolStripMenuItem ui_tsmDeleteIndicator;
        internal Nevron.UI.WinForm.Controls.NContextMenu ctmDeleteObject;
        private Nevron.UI.WinForm.Controls.NCommand mnuProperty;
        internal Nevron.UI.WinForm.Controls.NCommand mnuDeleteObject;
        private Nevron.UI.WinForm.Controls.NCommand mnuObjList;
        private Nevron.UI.WinForm.Controls.NCommand mnuSelDelete;
        private Nevron.UI.WinForm.Controls.NCommand mnuUnselAll;
        private Nevron.UI.WinForm.Controls.NCommand mnuUnselect;
        private Nevron.UI.WinForm.Controls.NCommand mnuUndoDelete;
        internal Nevron.UI.WinForm.Controls.NContextMenu ctmDeleteSeries;
        private Nevron.UI.WinForm.Controls.NCommand mnuIndProperty;
        internal Nevron.UI.WinForm.Controls.NCommand mnuEditSeries;
        internal Nevron.UI.WinForm.Controls.NCommand mnuDeleteSeries;
        private Nevron.UI.WinForm.Controls.NCommand mnuDeleteIndicatorWindow;
        private Nevron.UI.WinForm.Controls.NCommand mnuIndicatorList;
        public AxSTOCKCHARTXLib.AxStockChartX ui_ocxStockChart;
        private System.Windows.Forms.ToolStripMenuItem horizontalLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllDrawingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trendLineToolStripMenuItem;
    }
}
