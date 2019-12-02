
namespace PALSA.Frm
{
    partial class frmOrderEntry
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
            IsinitialisedBefore = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderEntry));
            this.ChartContextMenu = new Nevron.UI.WinForm.Controls.NContextMenu();
            this.insertStopLoss = new Nevron.UI.WinForm.Controls.NCommand();
            this.insertTakeProfit = new Nevron.UI.WinForm.Controls.NCommand();
            this.insertEntryPrice = new Nevron.UI.WinForm.Controls.NCommand();
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StockChartX1 = new AxSTOCKCHARTXLib.AxStockChartX();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.cbSymbol = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComment = new Nevron.UI.WinForm.Controls.NTextBox();
            this.cmbSL = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.cmbTP = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtTP = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.cbVolume = new Nevron.UI.WinForm.Controls.NComboBox();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.gbParent = new System.Windows.Forms.Panel();
            this.nuiPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockChartX1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTP)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChartContextMenu
            // 
            this.ChartContextMenu.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.insertStopLoss,
            this.insertTakeProfit,
            this.insertEntryPrice});
            // 
            // insertStopLoss
            // 
            this.insertStopLoss.Properties.Text = "Insert Stop Loss";
            // 
            // insertTakeProfit
            // 
            this.insertTakeProfit.Properties.Text = "Insert Take Profit";
            // 
            // insertEntryPrice
            // 
            this.insertEntryPrice.Properties.Text = "Insert Entry Price";
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.tableLayoutPanel1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(670, 416);
            this.nuiPanel1.TabIndex = 18;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.46108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.166899F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.49102F));
            this.tableLayoutPanel1.Controls.Add(this.StockChartX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.nLineControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbParent, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.05797F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.94203F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(668, 414);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // StockChartX1
            // 
            this.StockChartX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockChartX1.Enabled = true;
            this.StockChartX1.Location = new System.Drawing.Point(3, 3);
            this.StockChartX1.Name = "StockChartX1";
            this.StockChartX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("StockChartX1.OcxState")));
            this.tableLayoutPanel1.SetRowSpan(this.StockChartX1, 2);
            this.StockChartX1.Size = new System.Drawing.Size(290, 408);
            this.StockChartX1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbType, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbSymbol, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtComment, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cmbSL, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbTP, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtSL, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtTP, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(306, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(358, 135);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Symbol : ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Volume : ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Stop Loss : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Comment : ";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Type : ";
            // 
            // cbType
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cbType, 2);
            this.cbType.ListProperties.ColumnOnLeft = false;
            this.cbType.Location = new System.Drawing.Point(72, 109);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(175, 21);
            this.cbType.TabIndex = 11;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // cbSymbol
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cbSymbol, 3);
            this.cbSymbol.ListProperties.ColumnOnLeft = false;
            this.cbSymbol.Location = new System.Drawing.Point(72, 3);
            this.cbSymbol.Name = "cbSymbol";
            this.cbSymbol.Size = new System.Drawing.Size(283, 22);
            this.cbSymbol.TabIndex = 12;
            this.cbSymbol.SelectedIndexChanged += new System.EventHandler(this.cbSymbol_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(180, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Take Profit : ";
            // 
            // txtComment
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtComment, 3);
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(72, 84);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(285, 19);
            this.txtComment.TabIndex = 16;
            // 
            // cmbSL
            // 
            this.cmbSL.Location = new System.Drawing.Point(180, 31);
            this.cmbSL.Name = "cmbSL";
            this.cmbSL.Size = new System.Drawing.Size(69, 20);
            this.cmbSL.TabIndex = 14;
            this.cmbSL.Visible = false;
            // 
            // cmbTP
            // 
            this.cmbTP.Location = new System.Drawing.Point(255, 31);
            this.cmbTP.Name = "cmbTP";
            this.cmbTP.Size = new System.Drawing.Size(71, 20);
            this.cmbTP.TabIndex = 15;
            this.cmbTP.Visible = false;
            // 
            // txtSL
            // 
            this.txtSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSL.Location = new System.Drawing.Point(72, 58);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(102, 20);
            this.txtSL.TabIndex = 1;
            this.txtSL.Text = "0";
            this.txtSL.TextChanged += new System.EventHandler(this.txtSL_TextChanged);
            this.txtSL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSL_MouseDown);
            // 
            // txtTP
            // 
            this.txtTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTP.Location = new System.Drawing.Point(255, 58);
            this.txtTP.Name = "txtTP";
            this.txtTP.Size = new System.Drawing.Size(102, 20);
            this.txtTP.TabIndex = 2;
            this.txtTP.Text = "0";
            this.txtTP.TextChanged += new System.EventHandler(this.txtTP_TextChanged);
            this.txtTP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtTP_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtVolume);
            this.panel1.Controls.Add(this.cbVolume);
            this.panel1.Location = new System.Drawing.Point(72, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(102, 21);
            this.panel1.TabIndex = 19;
            // 
            // txtVolume
            // 
            this.txtVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVolume.Location = new System.Drawing.Point(1, 1);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(84, 20);
            this.txtVolume.TabIndex = 0;
            this.txtVolume.TextChanged += new System.EventHandler(this.txtVolume_TextChanged);
            // 
            // cbVolume
            // 
            this.cbVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbVolume.Editable = true;
            this.cbVolume.ListProperties.ColumnOnLeft = false;
            this.cbVolume.Location = new System.Drawing.Point(0, 0);
            this.cbVolume.Name = "cbVolume";
            this.cbVolume.Size = new System.Drawing.Size(102, 21);
            this.cbVolume.TabIndex = 13;
            this.cbVolume.SelectedIndexChanged += new System.EventHandler(this.cbVolumn_SelectedIndexChanged);
            this.cbVolume.TextChanged += new System.EventHandler(this.cbVolume_TextChanged);
            this.cbVolume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbVolume_KeyDown);
            this.cbVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbVolume_KeyPress);
            // 
            // nLineControl1
            // 
            this.nLineControl1.BackColor = System.Drawing.SystemColors.ControlText;
            this.nLineControl1.Location = new System.Drawing.Point(299, 3);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tableLayoutPanel1.SetRowSpan(this.nLineControl1, 2);
            this.nLineControl1.Size = new System.Drawing.Size(2, 408);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // gbParent
            // 
            this.gbParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbParent.Location = new System.Drawing.Point(306, 143);
            this.gbParent.Name = "gbParent";
            this.gbParent.Size = new System.Drawing.Size(359, 268);
            this.gbParent.TabIndex = 21;
            // 
            // frmOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(670, 416);
            this.Controls.Add(this.nuiPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "frmOrderEntry";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Entry Form";
            this.Title = "Order Entry Form";
            this.TopMost = true;
            this.UseGlassIfEnabled = Nevron.UI.WinForm.Controls.CommonTriState.False;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrderEntry_FormClosing);
            this.Load += new System.EventHandler(this.frmOrderEntry_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StockChartX1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal Nevron.UI.WinForm.Controls.NContextMenu ChartContextMenu;
        private Nevron.UI.WinForm.Controls.NCommand insertStopLoss;
        private Nevron.UI.WinForm.Controls.NCommand insertTakeProfit;
        private Nevron.UI.WinForm.Controls.NCommand insertEntryPrice;
        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal AxSTOCKCHARTXLib.AxStockChartX StockChartX1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Nevron.UI.WinForm.Controls.NComboBox cbType;
        private Nevron.UI.WinForm.Controls.NComboBox cbSymbol;
        private Nevron.UI.WinForm.Controls.NComboBox cbVolume;
        private Nevron.UI.WinForm.Controls.NNumericUpDown cmbSL;
        private Nevron.UI.WinForm.Controls.NTextBox txtComment;
        private Nevron.UI.WinForm.Controls.NNumericUpDown cmbTP;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtTP;
        private System.Windows.Forms.Panel gbParent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtVolume;

    }
}

