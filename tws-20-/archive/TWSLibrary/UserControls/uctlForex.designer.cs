namespace CommonLibrary.UserControls

{
    partial class UctlForex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlForex));
            this.contextForexMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_nmnuScriptPortfolio = new System.Windows.Forms.ToolStripMenuItem();
            this.contextForexMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextForexMenuStrip
            // 
            this.contextForexMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSymbolToolStripMenuItem,
            this.ui_nmnuScriptPortfolio});
            this.contextForexMenuStrip.Name = "contextForexMenuStrip";
            this.contextForexMenuStrip.Size = new System.Drawing.Size(195, 70);
            this.contextForexMenuStrip.Text = "Add New Symbol";
            // 
            // addNewSymbolToolStripMenuItem
            // 
            this.addNewSymbolToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewSymbolToolStripMenuItem.Image")));
            this.addNewSymbolToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewSymbolToolStripMenuItem.Name = "addNewSymbolToolStripMenuItem";
            this.addNewSymbolToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.addNewSymbolToolStripMenuItem.Text = "Modify Instrument Quotes";
            this.addNewSymbolToolStripMenuItem.Visible = false;
            this.addNewSymbolToolStripMenuItem.Click += new System.EventHandler(this.addNewSymbolToolStripMenuItem_Click);
            // 
            // ui_nmnuScriptPortfolio
            // 
            this.ui_nmnuScriptPortfolio.Name = "ui_nmnuScriptPortfolio";
            this.ui_nmnuScriptPortfolio.Size = new System.Drawing.Size(194, 22);
            this.ui_nmnuScriptPortfolio.Text = "Scrip Portfolio";
            this.ui_nmnuScriptPortfolio.Click += new System.EventHandler(this.ui_nmnuScriptPortfolio_Click);
            // 
            // uctlForex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.contextForexMenuStrip;
            this.Name = "UctlForex";
            this.Size = new System.Drawing.Size(257, 239);
            this.Load += new System.EventHandler(this.uctlForex_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.uctlForex_Paint);
            this.Resize += new System.EventHandler(this.uctlForex_Resize);
            this.contextForexMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextForexMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNewSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ui_nmnuScriptPortfolio;

    }
}
