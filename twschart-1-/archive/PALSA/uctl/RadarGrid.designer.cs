namespace PALSA.uctl
{
    partial class RadarGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadarGrid));
            this.dgvRadar = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.colInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastTrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercentageMovement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signalImageList = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRadar
            // 
            this.dgvRadar.AllowDrop = true;
            this.dgvRadar.AllowUserToAddRows = false;
            this.dgvRadar.AllowUserToDeleteRows = false;
            this.dgvRadar.AllowUserToOrderColumns = true;
            this.dgvRadar.AllowUserToResizeColumns = false;
            this.dgvRadar.AllowUserToResizeRows = false;
            this.dgvRadar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRadar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRadar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRadar.ColumnHeadersHeight = 30;
            this.dgvRadar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRadar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInterval,
            this.colSymbol,
            this.colLastTrade,
            this.colTime,
            this.colLow,
            this.colHigh,
            this.colBid,
            this.colPercentageMovement});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRadar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRadar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRadar.EnableCellCustomDraw = false;
            this.dgvRadar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvRadar.Location = new System.Drawing.Point(0, 0);
            this.dgvRadar.Name = "dgvRadar";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRadar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRadar.RowHeadersVisible = false;
            this.dgvRadar.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRadar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRadar.ShowCellToolTips = false;
            this.dgvRadar.ShowEditingIcon = false;
            this.dgvRadar.Size = new System.Drawing.Size(908, 150);
            this.dgvRadar.TabIndex = 0;
            this.dgvRadar.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvRadarCellBeginEdit);
            this.dgvRadar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRadar_CellClick);
            this.dgvRadar.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvRadarCellMouseDoubleClick);
            this.dgvRadar.ColumnStateChanged += new System.Windows.Forms.DataGridViewColumnStateChangedEventHandler(this.dgvRadar_ColumnStateChanged);
            this.dgvRadar.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DgvRadarRowsAdded);
            this.dgvRadar.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DgvRadarRowsRemoved);
            this.dgvRadar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvRadar_KeyUp);
            // 
            // colInterval
            // 
            this.colInterval.HeaderText = "Interval";
            this.colInterval.Name = "colInterval";
            // 
            // colSymbol
            // 
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.Name = "colSymbol";
            // 
            // colLastTrade
            // 
            this.colLastTrade.HeaderText = "Last trade";
            this.colLastTrade.Name = "colLastTrade";
            // 
            // colTime
            // 
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            // 
            // colLow
            // 
            this.colLow.HeaderText = "Low";
            this.colLow.Name = "colLow";
            // 
            // colHigh
            // 
            this.colHigh.HeaderText = "High";
            this.colHigh.Name = "colHigh";
            // 
            // colBid
            // 
            this.colBid.HeaderText = "Bid";
            this.colBid.Name = "colBid";
            // 
            // colPercentageMovement
            // 
            this.colPercentageMovement.HeaderText = "% Move";
            this.colPercentageMovement.Name = "colPercentageMovement";
            // 
            // signalImageList
            // 
            this.signalImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("signalImageList.ImageStream")));
            this.signalImageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.signalImageList.Images.SetKeyName(0, "Long.bmp");
            this.signalImageList.Images.SetKeyName(1, "Short.bmp");
            this.signalImageList.Images.SetKeyName(2, "minus-indicator.png");
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Interval";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 124;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Symbol";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 123;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Last trade";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 124;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Time";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 123;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Low";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 124;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "High";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 123;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Bid";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 124;
            // 
            // RadarGrid
            // 
            this.Controls.Add(this.dgvRadar);
            this.Name = "RadarGrid";
            this.Size = new System.Drawing.Size(908, 150);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView dgvRadar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ImageList signalImageList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastTrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercentageMovement;
    }
}
