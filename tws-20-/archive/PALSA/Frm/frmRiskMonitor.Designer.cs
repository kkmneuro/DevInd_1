namespace TWS.Frm
{
    partial class frmRiskMonitor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_pnlFilter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.uctlRiskMonitor1 = new CommonLibrary.UserControls.uctlRiskMonitor();
            this.tableLayoutPanel1.SuspendLayout();
            this.ui_pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ui_pnlFilter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uctlRiskMonitor1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1060, 564);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // ui_pnlFilter
            // 
            this.ui_pnlFilter.BackColor = System.Drawing.SystemColors.Control;
            this.ui_pnlFilter.Controls.Add(this.label1);
            this.ui_pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_pnlFilter.Location = new System.Drawing.Point(3, 3);
            this.ui_pnlFilter.Name = "ui_pnlFilter";
            this.ui_pnlFilter.Size = new System.Drawing.Size(1054, 50);
            this.ui_pnlFilter.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(473, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Risk Monitor";
            // 
            // uctlRiskMonitor1
            // 
            this.uctlRiskMonitor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlRiskMonitor1.DownTrendColor = System.Drawing.Color.Red;
            this.uctlRiskMonitor1.Equity = "";
            this.uctlRiskMonitor1.Location = new System.Drawing.Point(3, 59);
            this.uctlRiskMonitor1.Name = "uctlRiskMonitor1";
            this.uctlRiskMonitor1.Size = new System.Drawing.Size(1054, 502);
            this.uctlRiskMonitor1.TabIndex = 4;
            this.uctlRiskMonitor1.Title = null;
            this.uctlRiskMonitor1.TotalBuyQty = "";
            this.uctlRiskMonitor1.TotalMargin = "";
            this.uctlRiskMonitor1.TotalPnL = "";
            this.uctlRiskMonitor1.TotalSellQty = "";
            this.uctlRiskMonitor1.TotalUsedMargin = "";
            this.uctlRiskMonitor1.UpTrendColor = System.Drawing.Color.Blue;
            this.uctlRiskMonitor1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlRiskMonitor1_OnGridMouseDown);
            // 
            // frmRiskMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 564);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmRiskMonitor";
            this.Text = "Risk Monitor";
            this.Title = "Risk Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRiskMonitor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRiskMonitor_FormClosed);
            this.Load += new System.EventHandler(this.frmRiskMonitor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ui_pnlFilter.ResumeLayout(false);
            this.ui_pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel ui_pnlFilter;
        private System.Windows.Forms.Label label1;
        private CommonLibrary.UserControls.uctlRiskMonitor uctlRiskMonitor1;

    }
}