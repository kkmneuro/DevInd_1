namespace BOADMIN_NEW.Uctl
{
    partial class uctlTaxMasterMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_dtgTaxMaster = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_contextmnuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgTaxMaster)).BeginInit();
            this.ui_contextmnuCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_dtgTaxMaster
            // 
            this.ui_dtgTaxMaster.AllowUserToAddRows = false;
            this.ui_dtgTaxMaster.AllowUserToDeleteRows = false;
            this.ui_dtgTaxMaster.AllowUserToOrderColumns = true;
            this.ui_dtgTaxMaster.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_dtgTaxMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_dtgTaxMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_dtgTaxMaster.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_dtgTaxMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ui_dtgTaxMaster.ContextMenuStrip = this.ui_contextmnuCommon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_dtgTaxMaster.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_dtgTaxMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_dtgTaxMaster.EnableCellCustomDraw = false;
            this.ui_dtgTaxMaster.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_dtgTaxMaster.Location = new System.Drawing.Point(0, 0);
            this.ui_dtgTaxMaster.MultiSelect = false;
            this.ui_dtgTaxMaster.Name = "ui_dtgTaxMaster";
            this.ui_dtgTaxMaster.ReadOnly = true;
            this.ui_dtgTaxMaster.RowHeadersVisible = false;
            this.ui_dtgTaxMaster.RowHeadersWidth = 20;
            this.ui_dtgTaxMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_dtgTaxMaster.Size = new System.Drawing.Size(601, 186);
            this.ui_dtgTaxMaster.TabIndex = 4;
            this.ui_dtgTaxMaster.UseColumnContextMenu = false;
            this.ui_dtgTaxMaster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_dtgTaxMaster_MouseDown);
            this.ui_dtgTaxMaster.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_dtgTaxMaster_CellDoubleClick);
            // 
            // ui_contextmnuCommon
            // 
            this.ui_contextmnuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_contextmnuCommonAdd,
            this.ui_contextmnuCommonEdit,
            this.ui_contextmnuCommonDelete});
            this.ui_contextmnuCommon.Name = "ui_contextmnuCommon";
            this.ui_contextmnuCommon.Size = new System.Drawing.Size(149, 70);
            this.ui_contextmnuCommon.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ui_contextmnuCommon_ItemClicked);
            // 
            // ui_contextmnuCommonAdd
            // 
            this.ui_contextmnuCommonAdd.Name = "ui_contextmnuCommonAdd";
            this.ui_contextmnuCommonAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Insert)));
            this.ui_contextmnuCommonAdd.Size = new System.Drawing.Size(148, 22);
            this.ui_contextmnuCommonAdd.Text = "Add";
            // 
            // ui_contextmnuCommonEdit
            // 
            this.ui_contextmnuCommonEdit.Name = "ui_contextmnuCommonEdit";
            this.ui_contextmnuCommonEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ui_contextmnuCommonEdit.Size = new System.Drawing.Size(148, 22);
            this.ui_contextmnuCommonEdit.Text = "Edit";
            // 
            // ui_contextmnuCommonDelete
            // 
            this.ui_contextmnuCommonDelete.Name = "ui_contextmnuCommonDelete";
            this.ui_contextmnuCommonDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.ui_contextmnuCommonDelete.Size = new System.Drawing.Size(148, 22);
            this.ui_contextmnuCommonDelete.Text = "Delete";
            // 
            // uctlTaxMasterMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_dtgTaxMaster);
            this.Name = "uctlTaxMasterMain";
            this.Size = new System.Drawing.Size(601, 186);
            this.Load += new System.EventHandler(this.uctlTaxMasterMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgTaxMaster)).EndInit();
            this.ui_contextmnuCommon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView ui_dtgTaxMaster;
        public System.Windows.Forms.ContextMenuStrip ui_contextmnuCommon;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonAdd;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonEdit;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonDelete;
    }
}
