using PALSA.ClsAlerts;
using CommonLibrary.Cls;
namespace PALSA
{
    partial class uctlAlert
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctlAlert));
            this.ndgAlertGrid = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.colAlertId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSymbol = new CommonLibrary.Cls.TextAndImageColumn();
            this.colCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Create = new System.Windows.Forms.ToolStripMenuItem();
            this.Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.EnableOnOff = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.Grid = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textAndImageColumn1 = new CommonLibrary.Cls.TextAndImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ndgAlertGrid)).BeginInit();
            this.AlertMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ndgAlertGrid
            // 
            this.ndgAlertGrid.AllowUserToAddRows = false;
            this.ndgAlertGrid.AllowUserToOrderColumns = true;
            this.ndgAlertGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.ndgAlertGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ndgAlertGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ndgAlertGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ndgAlertGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ndgAlertGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ndgAlertGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAlertId,
            this.colSymbol,
            this.colCondition,
            this.colCounter,
            this.colLimit,
            this.colTimeout,
            this.colEvent});
            this.ndgAlertGrid.ContextMenuStrip = this.AlertMenuStrip;
            this.ndgAlertGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ndgAlertGrid.EnableCellCustomDraw = false;
            this.ndgAlertGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ndgAlertGrid.Location = new System.Drawing.Point(0, 0);
            this.ndgAlertGrid.Name = "ndgAlertGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ndgAlertGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ndgAlertGrid.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ndgAlertGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ndgAlertGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ndgAlertGrid.Size = new System.Drawing.Size(1129, 228);
            this.ndgAlertGrid.TabIndex = 0;
            this.ndgAlertGrid.UseColumnContextMenu = false;
            this.ndgAlertGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ndgAlertGrid_KeyDown);
            this.ndgAlertGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ndgAlertGrid_MouseDoubleClick);
            this.ndgAlertGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ndgAlertGrid_Mousedown);
            // 
            // colAlertId
            // 
            this.colAlertId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAlertId.HeaderText = "AlertId";
            this.colAlertId.Name = "colAlertId";
            this.colAlertId.ReadOnly = true;
            this.colAlertId.Visible = false;
            // 
            // colSymbol
            // 
            this.colSymbol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.Image = null;
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.ReadOnly = true;
            this.colSymbol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colCondition
            // 
            this.colCondition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCondition.HeaderText = "Condition";
            this.colCondition.Name = "colCondition";
            this.colCondition.ReadOnly = true;
            // 
            // colCounter
            // 
            this.colCounter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCounter.HeaderText = "Counter";
            this.colCounter.Name = "colCounter";
            this.colCounter.ReadOnly = true;
            // 
            // colLimit
            // 
            this.colLimit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLimit.HeaderText = "Limit";
            this.colLimit.Name = "colLimit";
            this.colLimit.ReadOnly = true;
            // 
            // colTimeout
            // 
            this.colTimeout.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTimeout.HeaderText = "Timeout";
            this.colTimeout.Name = "colTimeout";
            this.colTimeout.ReadOnly = true;
            // 
            // colEvent
            // 
            this.colEvent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEvent.HeaderText = "Event";
            this.colEvent.Name = "colEvent";
            this.colEvent.ReadOnly = true;
            // 
            // AlertMenuStrip
            // 
            this.AlertMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Create,
            this.Modify,
            this.Delete,
            this.EnableOnOff,
            this.AutoArrange,
            this.Grid});
            this.AlertMenuStrip.Name = "AlertMenuStrip";
            this.AlertMenuStrip.Size = new System.Drawing.Size(189, 158);
            this.AlertMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.AlertMenuStrip_ItemClicked);
            // 
            // Create
            // 
            this.Create.Image = global::PALSA.Properties.Resources.alert_create;
            this.Create.Name = "Create";
            this.Create.ShortcutKeyDisplayString = "Insert";
            this.Create.Size = new System.Drawing.Size(188, 22);
            this.Create.Text = "Create";

            // 
            // Modify
            // 
            this.Modify.Image = global::PALSA.Properties.Resources.alert_modify;
            this.Modify.Name = "Modify";
            this.Modify.ShortcutKeyDisplayString = "Enter";
            this.Modify.Size = new System.Drawing.Size(188, 22);
            this.Modify.Text = "Modify";
            // 
            // Delete
            // 
            this.Delete.Image = global::PALSA.Properties.Resources.alert_delete;
            this.Delete.Name = "Delete";
            this.Delete.ShortcutKeyDisplayString = "Delete";
            this.Delete.Size = new System.Drawing.Size(188, 22);
            this.Delete.Text = "Delete";
            // 
            // EnableOnOff
            // 
            this.EnableOnOff.Image = global::PALSA.Properties.Resources.alert_Disable;
            this.EnableOnOff.Name = "EnableOnOff";
            this.EnableOnOff.ShortcutKeyDisplayString = "Space";
            this.EnableOnOff.Size = new System.Drawing.Size(188, 22);
            this.EnableOnOff.Text = "Enable On/Off";
            // 
            // AutoArrange
            // 
            this.AutoArrange.Image = global::PALSA.Properties.Resources.autoarrangeToolStripMenuItem;
            this.AutoArrange.Name = "AutoArrange";
            this.AutoArrange.ShortcutKeyDisplayString = "A";
            this.AutoArrange.Size = new System.Drawing.Size(188, 22);
            this.AutoArrange.Text = "Auto Arrange";
            // 
            // Grid
            // 
            this.Grid.Image = global::PALSA.Properties.Resources.gridToolStripMenuItem;
            this.Grid.Name = "Grid";
            this.Grid.ShortcutKeyDisplayString = "G";
            this.Grid.Size = new System.Drawing.Size(188, 22);
            this.Grid.Text = "Grid";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "AlertId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // textAndImageColumn1
            // 
            this.textAndImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.textAndImageColumn1.HeaderText = "Symbol";
            this.textAndImageColumn1.Image = null;
            this.textAndImageColumn1.Name = "textAndImageColumn1";
            this.textAndImageColumn1.ReadOnly = true;
            this.textAndImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Condition";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Counter";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Limit";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Timeout";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Event";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "alert_normal.png");
            this.imageList1.Images.SetKeyName(1, "alert_Disable.png");
            this.imageList1.Images.SetKeyName(2, "alert_on.png");
            this.imageList1.Images.SetKeyName(3, "alert_create.png");
            this.imageList1.Images.SetKeyName(4, "alert_modify.png");
            this.imageList1.Images.SetKeyName(5, "alert_delete.png");
            this.imageList1.Images.SetKeyName(6, "alert1.ico");
            // 
            // uctlAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ndgAlertGrid);
            this.Name = "uctlAlert";
            this.Size = new System.Drawing.Size(1129, 228);
            this.Load += new System.EventHandler(this.uctlAlert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ndgAlertGrid)).EndInit();
            this.AlertMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip AlertMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem Create;
        private System.Windows.Forms.ToolStripMenuItem Modify;
        private System.Windows.Forms.ToolStripMenuItem Delete;       
        private System.Windows.Forms.ToolStripMenuItem EnableOnOff;
        private System.Windows.Forms.ToolStripMenuItem AutoArrange; 
        private System.Windows.Forms.ToolStripMenuItem Grid;
        public Nevron.UI.WinForm.Controls.NDataGridView ndgAlertGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlertId;
        private TextAndImageColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCounter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeout;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvent;
        
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private TextAndImageColumn textAndImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ImageList imageList1;


    }
}
