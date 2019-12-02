namespace CommonLibrary.UserControls
{
    partial class uctlQuickOrderContainer
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
            this.contextForexMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_nmnuScriptPortfolio = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.contextForexMenuStrip.SuspendLayout();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextForexMenuStrip
            // 
            this.contextForexMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSymbolToolStripMenuItem,
            this.ui_nmnuScriptPortfolio});
            this.contextForexMenuStrip.Name = "contextForexMenuStrip";
            this.contextForexMenuStrip.Size = new System.Drawing.Size(212, 48);
            this.contextForexMenuStrip.Text = "Add New Symbol";
            // 
            // addNewSymbolToolStripMenuItem
            // 
            this.addNewSymbolToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewSymbolToolStripMenuItem.Name = "addNewSymbolToolStripMenuItem";
            this.addNewSymbolToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addNewSymbolToolStripMenuItem.Text = "Modify Instrument Quotes";
            this.addNewSymbolToolStripMenuItem.Visible = false;
            this.addNewSymbolToolStripMenuItem.Click += new System.EventHandler(this.addNewSymbolToolStripMenuItem_Click);
            // 
            // ui_nmnuScriptPortfolio
            // 
            this.ui_nmnuScriptPortfolio.Name = "ui_nmnuScriptPortfolio";
            this.ui_nmnuScriptPortfolio.Size = new System.Drawing.Size(211, 22);
            this.ui_nmnuScriptPortfolio.Text = "Script Portfolio";
            this.ui_nmnuScriptPortfolio.Click += new System.EventHandler(this.ui_nmnuScriptPortfolio_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(525, 386);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.flowLayoutPanel1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(527, 388);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // uctlQuickOrderContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ContextMenuStrip = this.contextForexMenuStrip;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlQuickOrderContainer";
            this.Size = new System.Drawing.Size(527, 388);
            this.Load += new System.EventHandler(this.uctlQuickOrderContainer_Load);
            this.contextForexMenuStrip.ResumeLayout(false);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem addNewSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ui_nmnuScriptPortfolio;
        public System.Windows.Forms.ContextMenuStrip contextForexMenuStrip;
    }
}
