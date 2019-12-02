namespace PALSA.Frm
{
    partial class frmNewChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewChart));
            this.ui_cmsChart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_mnuSelectSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuDeleteObject = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_tsmDeleteIndicator = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_mnuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_ocxStockChart = new AxSTOCKCHARTXLib.AxStockChartX();
            this.ui_cmsChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ocxStockChart)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_cmsChart
            // 
            this.ui_cmsChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_mnuSelectSymbol,
            this.ui_mnuDeleteObject,
            this.ui_tsmDeleteIndicator,
            this.ui_mnuProperties});
            this.ui_cmsChart.Name = "ui_cmsChart";
            this.ui_cmsChart.Size = new System.Drawing.Size(163, 92);
            // 
            // ui_mnuSelectSymbol
            // 
            this.ui_mnuSelectSymbol.Name = "ui_mnuSelectSymbol";
            this.ui_mnuSelectSymbol.Size = new System.Drawing.Size(162, 22);
            this.ui_mnuSelectSymbol.Text = "Select Symbol";
            //this.ui_mnuSelectSymbol.Click += new System.EventHandler(this.ui_mnuSelectSymbol_Click);
            // 
            // ui_mnuDeleteObject
            // 
            this.ui_mnuDeleteObject.Name = "ui_mnuDeleteObject";
            this.ui_mnuDeleteObject.Size = new System.Drawing.Size(162, 22);
            this.ui_mnuDeleteObject.Text = "Delete Object";
           // this.ui_mnuDeleteObject.Click += new System.EventHandler(this.ui_mnuDeleteObject_Click);
            // 
            // ui_tsmDeleteIndicator
            // 
            this.ui_tsmDeleteIndicator.Name = "ui_tsmDeleteIndicator";
            this.ui_tsmDeleteIndicator.Size = new System.Drawing.Size(162, 22);
            this.ui_tsmDeleteIndicator.Text = "Delete Indicator";
            //this.ui_tsmDeleteIndicator.Click += new System.EventHandler(this.ui_tsmDeleteIndicator_Click);
            // 
            // ui_mnuProperties
            // 
            this.ui_mnuProperties.Name = "ui_mnuProperties";
            this.ui_mnuProperties.Size = new System.Drawing.Size(162, 22);
            this.ui_mnuProperties.Text = "Properties";
            //this.ui_mnuProperties.Click += new System.EventHandler(this.ui_mnuProperties_Click);
            // 
            // ui_ocxStockChart
            // 
            this.ui_ocxStockChart.ContextMenuStrip = this.ui_cmsChart;
            this.ui_ocxStockChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ocxStockChart.Enabled = true;
            this.ui_ocxStockChart.Location = new System.Drawing.Point(0, 0);
            this.ui_ocxStockChart.Name = "ui_ocxStockChart";
            this.ui_ocxStockChart.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ui_ocxStockChart.OcxState")));
            this.ui_ocxStockChart.Size = new System.Drawing.Size(773, 352);
            this.ui_ocxStockChart.TabIndex = 0;
            //this.ui_ocxStockChart.PaintEvent += new AxSTOCKCHARTXLib._DStockChartXEvents_PaintEventHandler(this.ui_ocxStockChart_PaintEvent);
            //this.ui_ocxStockChart.ItemRightClick += new AxSTOCKCHARTXLib._DStockChartXEvents_ItemRightClickEventHandler(this.ui_ocxStockChart_ItemRightClick);
            //this.ui_ocxStockChart.OnLButtonDown += new System.EventHandler(this.ui_ocxStockChart_OnLButtonDown);
            //this.ui_ocxStockChart.ClickEvent += new System.EventHandler(this.ui_ocxStockChart_ClickEvent);
            //this.ui_ocxStockChart.OnRButtonDown += new System.EventHandler(this.ui_ocxStockChart_OnRButtonDown);
            // 
            // frmNewChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 352);
            this.Controls.Add(this.ui_ocxStockChart);
            this.MaximumSize = new System.Drawing.Size(1300, 700);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "frmNewChart";
            this.Text = "frmNewChart";
            this.Title = "frmNewChart";
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewChart_FormClosing);
            //this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNewChart_FormClosed);
            //this.Load += new System.EventHandler(this.frmNewChart_Load);
            this.ui_cmsChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ocxStockChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ui_cmsChart;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuDeleteObject;
        public AxSTOCKCHARTXLib.AxStockChartX ui_ocxStockChart;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuProperties;
        private System.Windows.Forms.ToolStripMenuItem ui_mnuSelectSymbol;
        private System.Windows.Forms.ToolStripMenuItem ui_tsmDeleteIndicator;
    }
}