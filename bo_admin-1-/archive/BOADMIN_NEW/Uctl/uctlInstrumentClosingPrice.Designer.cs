namespace BOADMIN_NEW.Uctl
{
    partial class uctlInstrumentClosingPrice
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
            this.ui_ndgvInstrumentClosingPrice = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_cmsInstClosingPrice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonEdit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvInstrumentClosingPrice)).BeginInit();
            this.ui_cmsInstClosingPrice.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_ndgvInstrumentClosingPrice
            // 
            this.ui_ndgvInstrumentClosingPrice.AllowUserToAddRows = false;
            this.ui_ndgvInstrumentClosingPrice.AllowUserToDeleteRows = false;
            this.ui_ndgvInstrumentClosingPrice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_ndgvInstrumentClosingPrice.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_ndgvInstrumentClosingPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_ndgvInstrumentClosingPrice.ContextMenuStrip = this.ui_cmsInstClosingPrice;
            this.ui_ndgvInstrumentClosingPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_ndgvInstrumentClosingPrice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_ndgvInstrumentClosingPrice.Location = new System.Drawing.Point(0, 0);
            this.ui_ndgvInstrumentClosingPrice.Name = "ui_ndgvInstrumentClosingPrice";
            this.ui_ndgvInstrumentClosingPrice.ReadOnly = true;
            this.ui_ndgvInstrumentClosingPrice.RowHeadersVisible = false;
            this.ui_ndgvInstrumentClosingPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_ndgvInstrumentClosingPrice.Size = new System.Drawing.Size(662, 249);
            this.ui_ndgvInstrumentClosingPrice.TabIndex = 0;
            this.ui_ndgvInstrumentClosingPrice.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ui_ndgvInstrumentClosingPrice_CellMouseDoubleClick);
            // 
            // ui_cmsInstClosingPrice
            // 
            this.ui_cmsInstClosingPrice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_contextmnuCommonAdd,
            this.ui_contextmnuCommonEdit});
            this.ui_cmsInstClosingPrice.Name = "ui_contextmnuCommon";
            this.ui_cmsInstClosingPrice.Size = new System.Drawing.Size(142, 48);
            // 
            // ui_contextmnuCommonAdd
            // 
            this.ui_contextmnuCommonAdd.Name = "ui_contextmnuCommonAdd";
            this.ui_contextmnuCommonAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Insert)));
            this.ui_contextmnuCommonAdd.Size = new System.Drawing.Size(141, 22);
            this.ui_contextmnuCommonAdd.Text = "Add";
            this.ui_contextmnuCommonAdd.Click += new System.EventHandler(this.ui_contextmnuCommonAdd_Click);
            // 
            // ui_contextmnuCommonEdit
            // 
            this.ui_contextmnuCommonEdit.Name = "ui_contextmnuCommonEdit";
            this.ui_contextmnuCommonEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ui_contextmnuCommonEdit.Size = new System.Drawing.Size(141, 22);
            this.ui_contextmnuCommonEdit.Text = "Edit";
            this.ui_contextmnuCommonEdit.Click += new System.EventHandler(this.ui_contextmnuCommonEdit_Click);
            // 
            // uctlInstrumentClosingPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_ndgvInstrumentClosingPrice);
            this.Name = "uctlInstrumentClosingPrice";
            this.Size = new System.Drawing.Size(662, 249);
            this.Load += new System.EventHandler(this.uctlInstrumentClosingPrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndgvInstrumentClosingPrice)).EndInit();
            this.ui_cmsInstClosingPrice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView ui_ndgvInstrumentClosingPrice;
        public System.Windows.Forms.ContextMenuStrip ui_cmsInstClosingPrice;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonAdd;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonEdit;
    }
}
