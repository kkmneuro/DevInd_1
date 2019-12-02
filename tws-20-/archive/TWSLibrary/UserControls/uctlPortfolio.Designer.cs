namespace CommonLibrary.UserControls
{
    partial class UctlPortfolio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlPortfolio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlPortfolio = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ntxtPortfolioName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_tlpnlPortfolio = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_uctlGridPortfolioProduct = new CommonLibrary.UserControls.UctlGrid();
            this.ui_uctlGridPortfolioSelectedProduct = new CommonLibrary.UserControls.UctlGrid();
            this.ui_nbtnSave = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnRemove = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnAdd = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_lblSelected = new System.Windows.Forms.Label();
            this.ui_nbtnClose = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ngbeProductSearch = new Nevron.UI.WinForm.Controls.NGroupBoxEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_nbtnSearch = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_lblOptType = new System.Windows.Forms.Label();
            this.ui_lblStrikePrice = new System.Windows.Forms.Label();
            this.ui_lblProductType = new System.Windows.Forms.Label();
            this.ui_ncmbProductType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbProduct = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.ui_lblContract = new System.Windows.Forms.Label();
            this.ui_ncmbGateway = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ui_lblExpiryDate = new System.Windows.Forms.Label();
            this.ui_lblSeries = new System.Windows.Forms.Label();
            this.ui_ncmbExpiryDate = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbContract = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbExchange = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_nbtnRemovePortfoilo = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ncmbPortfolioName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblPortfolioName = new System.Windows.Forms.Label();
            this.ui_npnlPortfolio.SuspendLayout();
            this.ui_tlpnlPortfolio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngbeProductSearch)).BeginInit();
            this.ui_ngbeProductSearch.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_npnlPortfolio
            // 
            this.ui_npnlPortfolio.Controls.Add(this.ui_ntxtPortfolioName);
            this.ui_npnlPortfolio.Controls.Add(this.ui_tlpnlPortfolio);
            this.ui_npnlPortfolio.Controls.Add(this.ui_ngbeProductSearch);
            this.ui_npnlPortfolio.Controls.Add(this.ui_nbtnRemovePortfoilo);
            this.ui_npnlPortfolio.Controls.Add(this.ui_ncmbPortfolioName);
            this.ui_npnlPortfolio.Controls.Add(this.ui_lblPortfolioName);
            this.ui_npnlPortfolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlPortfolio.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlPortfolio.Name = "ui_npnlPortfolio";
            this.ui_npnlPortfolio.Size = new System.Drawing.Size(684, 469);
            this.ui_npnlPortfolio.TabIndex = 0;
            this.ui_npnlPortfolio.Text = "nuiPanel1";
            this.ui_npnlPortfolio.Click += new System.EventHandler(this.ui_npnlPortfolio_Click);
            // 
            // ui_ntxtPortfolioName
            // 
            this.ui_ntxtPortfolioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_ntxtPortfolioName.Location = new System.Drawing.Point(113, 10);
            this.ui_ntxtPortfolioName.Name = "ui_ntxtPortfolioName";
            this.ui_ntxtPortfolioName.Size = new System.Drawing.Size(106, 19);
            this.ui_ntxtPortfolioName.TabIndex = 10;
            this.ui_ntxtPortfolioName.TextChanged += new System.EventHandler(this.ui_ntxtPortfolioName_TextChanged);
            // 
            // ui_tlpnlPortfolio
            // 
            this.ui_tlpnlPortfolio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_tlpnlPortfolio.BackColor = System.Drawing.Color.Transparent;
            this.ui_tlpnlPortfolio.ColumnCount = 6;
            this.ui_tlpnlPortfolio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.ui_tlpnlPortfolio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ui_tlpnlPortfolio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.ui_tlpnlPortfolio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.ui_tlpnlPortfolio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.ui_tlpnlPortfolio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.ui_tlpnlPortfolio.Controls.Add(this.label1, 0, 0);
            this.ui_tlpnlPortfolio.Controls.Add(this.ui_uctlGridPortfolioProduct, 0, 1);
            this.ui_tlpnlPortfolio.Controls.Add(this.ui_uctlGridPortfolioSelectedProduct, 0, 3);
            this.ui_tlpnlPortfolio.Controls.Add(this.ui_nbtnSave, 4, 2);
            this.ui_tlpnlPortfolio.Controls.Add(this.ui_nbtnRemove, 3, 2);
            this.ui_tlpnlPortfolio.Controls.Add(this.ui_nbtnAdd, 2, 2);
            this.ui_tlpnlPortfolio.Controls.Add(this.ui_lblSelected, 0, 2);
            this.ui_tlpnlPortfolio.Controls.Add(this.ui_nbtnClose, 5, 2);
            this.ui_tlpnlPortfolio.Location = new System.Drawing.Point(6, 118);
            this.ui_tlpnlPortfolio.Name = "ui_tlpnlPortfolio";
            this.ui_tlpnlPortfolio.RowCount = 4;
            this.ui_tlpnlPortfolio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ui_tlpnlPortfolio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ui_tlpnlPortfolio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.ui_tlpnlPortfolio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ui_tlpnlPortfolio.Size = new System.Drawing.Size(670, 344);
            this.ui_tlpnlPortfolio.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select Product :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_uctlGridPortfolioProduct
            // 
            this.ui_uctlGridPortfolioProduct.AllowUserToAddRows = false;
            this.ui_uctlGridPortfolioProduct.AllowUserToDeleteRows = true;
            this.ui_uctlGridPortfolioProduct.AllowUserToOrderColumns = false;
            this.ui_uctlGridPortfolioProduct.AllowUserToResizeColumns = true;
            this.ui_uctlGridPortfolioProduct.AllowUserToResizeRows = false;
            this.ui_uctlGridPortfolioProduct.AlternatingRowStyle = dataGridViewCellStyle11;
            this.ui_uctlGridPortfolioProduct.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_uctlGridPortfolioProduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridPortfolioProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridPortfolioProduct.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridPortfolioProduct.ColumnHeaderHeight = 23;
            this.ui_uctlGridPortfolioProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridPortfolioProduct.ColumnHeadersCellStyle = dataGridViewCellStyle12;
            this.ui_uctlGridPortfolioProduct.ColumnHeadersHeight = 0;
            this.ui_uctlGridPortfolioProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ui_uctlGridPortfolioProduct.ColumnHeadersVisible = true;
            this.ui_tlpnlPortfolio.SetColumnSpan(this.ui_uctlGridPortfolioProduct, 6);
            this.ui_uctlGridPortfolioProduct.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridPortfolioProduct.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridPortfolioProduct.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridPortfolioProduct.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridPortfolioProduct.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridPortfolioProduct.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridPortfolioProduct.DataRowStyle = dataGridViewCellStyle13;
            this.ui_uctlGridPortfolioProduct.DataSource = null;
            this.ui_uctlGridPortfolioProduct.DefaultCellStyle = dataGridViewCellStyle13;
            this.ui_uctlGridPortfolioProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridPortfolioProduct.EnableCellCustomDraw = true;
            this.ui_uctlGridPortfolioProduct.EnableHeaderCustomDraw = true;
            this.ui_uctlGridPortfolioProduct.EnableHeadersVisualStyles = true;
            this.ui_uctlGridPortfolioProduct.EnableMultiSelect = true;
            this.ui_uctlGridPortfolioProduct.EnableSkinning = true;
            this.ui_uctlGridPortfolioProduct.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridPortfolioProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_uctlGridPortfolioProduct.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridPortfolioProduct.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridPortfolioProduct.GridPalette")));
            this.ui_uctlGridPortfolioProduct.IColIndex = -1;
            this.ui_uctlGridPortfolioProduct.IRowIndex = -1;
            this.ui_uctlGridPortfolioProduct.IsGridReadOnly = true;
            this.ui_uctlGridPortfolioProduct.IsGridVisible = true;
            this.ui_uctlGridPortfolioProduct.IsRowHeadersVisible = false;
            this.ui_uctlGridPortfolioProduct.Location = new System.Drawing.Point(2, 23);
            this.ui_uctlGridPortfolioProduct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ui_uctlGridPortfolioProduct.Name = "ui_uctlGridPortfolioProduct";
            this.ui_uctlGridPortfolioProduct.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridPortfolioProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.ui_uctlGridPortfolioProduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridPortfolioProduct.RowHeight = 20;
            this.ui_uctlGridPortfolioProduct.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.ui_uctlGridPortfolioProduct.Size = new System.Drawing.Size(666, 141);
            this.ui_uctlGridPortfolioProduct.TabIndex = 2;
            this.ui_uctlGridPortfolioProduct.Title = null;
            // 
            // ui_uctlGridPortfolioSelectedProduct
            // 
            this.ui_uctlGridPortfolioSelectedProduct.AllowUserToAddRows = false;
            this.ui_uctlGridPortfolioSelectedProduct.AllowUserToDeleteRows = true;
            this.ui_uctlGridPortfolioSelectedProduct.AllowUserToOrderColumns = false;
            this.ui_uctlGridPortfolioSelectedProduct.AllowUserToResizeColumns = true;
            this.ui_uctlGridPortfolioSelectedProduct.AllowUserToResizeRows = false;
            this.ui_uctlGridPortfolioSelectedProduct.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridPortfolioSelectedProduct.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_uctlGridPortfolioSelectedProduct.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.None;
            this.ui_uctlGridPortfolioSelectedProduct.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridPortfolioSelectedProduct.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridPortfolioSelectedProduct.ColumnHeaderHeight = 23;
            this.ui_uctlGridPortfolioSelectedProduct.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridPortfolioSelectedProduct.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridPortfolioSelectedProduct.ColumnHeadersHeight = 0;
            this.ui_uctlGridPortfolioSelectedProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.ui_uctlGridPortfolioSelectedProduct.ColumnHeadersVisible = true;
            this.ui_tlpnlPortfolio.SetColumnSpan(this.ui_uctlGridPortfolioSelectedProduct, 6);
            this.ui_uctlGridPortfolioSelectedProduct.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridPortfolioSelectedProduct.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridPortfolioSelectedProduct.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridPortfolioSelectedProduct.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridPortfolioSelectedProduct.DataGridScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ui_uctlGridPortfolioSelectedProduct.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridPortfolioSelectedProduct.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridPortfolioSelectedProduct.DataSource = null;
            this.ui_uctlGridPortfolioSelectedProduct.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridPortfolioSelectedProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_uctlGridPortfolioSelectedProduct.EnableCellCustomDraw = true;
            this.ui_uctlGridPortfolioSelectedProduct.EnableHeaderCustomDraw = true;
            this.ui_uctlGridPortfolioSelectedProduct.EnableHeadersVisualStyles = true;
            this.ui_uctlGridPortfolioSelectedProduct.EnableMultiSelect = true;
            this.ui_uctlGridPortfolioSelectedProduct.EnableSkinning = true;
            this.ui_uctlGridPortfolioSelectedProduct.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridPortfolioSelectedProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_uctlGridPortfolioSelectedProduct.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridPortfolioSelectedProduct.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridPortfolioSelectedProduct.GridPalette")));
            this.ui_uctlGridPortfolioSelectedProduct.IColIndex = -1;
            this.ui_uctlGridPortfolioSelectedProduct.IRowIndex = -1;
            this.ui_uctlGridPortfolioSelectedProduct.IsGridReadOnly = true;
            this.ui_uctlGridPortfolioSelectedProduct.IsGridVisible = true;
            this.ui_uctlGridPortfolioSelectedProduct.IsRowHeadersVisible = false;
            this.ui_uctlGridPortfolioSelectedProduct.Location = new System.Drawing.Point(2, 200);
            this.ui_uctlGridPortfolioSelectedProduct.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ui_uctlGridPortfolioSelectedProduct.Name = "ui_uctlGridPortfolioSelectedProduct";
            this.ui_uctlGridPortfolioSelectedProduct.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridPortfolioSelectedProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridPortfolioSelectedProduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            this.ui_uctlGridPortfolioSelectedProduct.RowHeight = 20;
            this.ui_uctlGridPortfolioSelectedProduct.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridPortfolioSelectedProduct.Size = new System.Drawing.Size(666, 141);
            this.ui_uctlGridPortfolioSelectedProduct.TabIndex = 3;
            this.ui_uctlGridPortfolioSelectedProduct.Title = null;
            this.ui_uctlGridPortfolioSelectedProduct.OnRowsAdded += new CommonLibrary.UserControls.UctlGrid.DataGridViewRowsAddedEventHandeler(this.ui_uctlGridPortfolioSelectedProduct_OnRowsAdded);
            this.ui_uctlGridPortfolioSelectedProduct.OnRowsRemoved += new CommonLibrary.UserControls.UctlGrid.DataGridViewRowsRemovedEventHandeler(this.ui_uctlGridPortfolioSelectedProduct_OnRowsRemoved);
            // 
            // ui_nbtnSave
            // 
            this.ui_nbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnSave.Enabled = false;
            this.ui_nbtnSave.Location = new System.Drawing.Point(492, 170);
            this.ui_nbtnSave.Name = "ui_nbtnSave";
            this.ui_nbtnSave.Size = new System.Drawing.Size(84, 24);
            this.ui_nbtnSave.TabIndex = 12;
            this.ui_nbtnSave.Text = "&Save";
            this.ui_nbtnSave.UseVisualStyleBackColor = false;
            this.ui_nbtnSave.Click += new System.EventHandler(this.ui_nbtnSave_Click);
            // 
            // ui_nbtnRemove
            // 
            this.ui_nbtnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnRemove.Enabled = false;
            this.ui_nbtnRemove.Location = new System.Drawing.Point(400, 170);
            this.ui_nbtnRemove.Name = "ui_nbtnRemove";
            this.ui_nbtnRemove.Size = new System.Drawing.Size(84, 24);
            this.ui_nbtnRemove.TabIndex = 11;
            this.ui_nbtnRemove.Text = "&Remove";
            this.ui_nbtnRemove.UseVisualStyleBackColor = false;
            this.ui_nbtnRemove.Click += new System.EventHandler(this.ui_nbtnRemove_Click);
            // 
            // ui_nbtnAdd
            // 
            this.ui_nbtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnAdd.Location = new System.Drawing.Point(308, 170);
            this.ui_nbtnAdd.Name = "ui_nbtnAdd";
            this.ui_nbtnAdd.Size = new System.Drawing.Size(84, 24);
            this.ui_nbtnAdd.TabIndex = 10;
            this.ui_nbtnAdd.Text = "&Add";
            this.ui_nbtnAdd.UseVisualStyleBackColor = false;
            this.ui_nbtnAdd.Click += new System.EventHandler(this.ui_nbtnAdd_Click);
            // 
            // ui_lblSelected
            // 
            this.ui_lblSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblSelected.AutoSize = true;
            this.ui_lblSelected.Location = new System.Drawing.Point(3, 184);
            this.ui_lblSelected.Name = "ui_lblSelected";
            this.ui_lblSelected.Size = new System.Drawing.Size(55, 13);
            this.ui_lblSelected.TabIndex = 4;
            this.ui_lblSelected.Text = "Selected :";
            this.ui_lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_nbtnClose
            // 
            this.ui_nbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnClose.Location = new System.Drawing.Point(583, 170);
            this.ui_nbtnClose.Name = "ui_nbtnClose";
            this.ui_nbtnClose.Size = new System.Drawing.Size(84, 24);
            this.ui_nbtnClose.TabIndex = 13;
            this.ui_nbtnClose.Text = "&Close";
            this.ui_nbtnClose.UseVisualStyleBackColor = false;
            this.ui_nbtnClose.Click += new System.EventHandler(this.ui_nbtnClose_Click);
            // 
            // ui_ngbeProductSearch
            // 
            this.ui_ngbeProductSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ngbeProductSearch.BackColor = System.Drawing.Color.Transparent;
            this.ui_ngbeProductSearch.Controls.Add(this.tableLayoutPanel1);
            this.ui_ngbeProductSearch.Controls.Add(this.ui_ncmbExchange);
            this.ui_ngbeProductSearch.Controls.Add(this.label2);
            this.ui_ngbeProductSearch.HeaderItem.Text = "Product Search";
            this.ui_ngbeProductSearch.HeaderStrokeInfo.Draw = false;
            this.ui_ngbeProductSearch.Location = new System.Drawing.Point(6, 33);
            this.ui_ngbeProductSearch.Name = "ui_ngbeProductSearch";
            this.ui_ngbeProductSearch.Size = new System.Drawing.Size(673, 85);
            this.ui_ngbeProductSearch.StrokeInfo.Rounding = 5;
            this.ui_ngbeProductSearch.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.ui_nbtnSearch, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblOptType, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblStrikePrice, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblProductType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbProductType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbProduct, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblProduct, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblContract, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbGateway, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblExpiryDate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblSeries, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbExpiryDate, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbContract, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(662, 41);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // ui_nbtnSearch
            // 
            this.ui_nbtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnSearch.Location = new System.Drawing.Point(580, 19);
            this.ui_nbtnSearch.Name = "ui_nbtnSearch";
            this.ui_nbtnSearch.Size = new System.Drawing.Size(79, 19);
            this.ui_nbtnSearch.TabIndex = 9;
            this.ui_nbtnSearch.Text = "&Search";
            this.ui_nbtnSearch.UseVisualStyleBackColor = false;
            this.ui_nbtnSearch.Visible = false;
            this.ui_nbtnSearch.Click += new System.EventHandler(this.ui_nbtnSearch_Click);
            // 
            // ui_lblOptType
            // 
            this.ui_lblOptType.Location = new System.Drawing.Point(564, 0);
            this.ui_lblOptType.Name = "ui_lblOptType";
            this.ui_lblOptType.Size = new System.Drawing.Size(5, 13);
            this.ui_lblOptType.TabIndex = 7;
            this.ui_lblOptType.Text = "Opt. Type";
            this.ui_lblOptType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ui_lblOptType.Visible = false;
            // 
            // ui_lblStrikePrice
            // 
            this.ui_lblStrikePrice.Location = new System.Drawing.Point(553, 0);
            this.ui_lblStrikePrice.Name = "ui_lblStrikePrice";
            this.ui_lblStrikePrice.Size = new System.Drawing.Size(5, 13);
            this.ui_lblStrikePrice.TabIndex = 6;
            this.ui_lblStrikePrice.Text = "Strike Price";
            this.ui_lblStrikePrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ui_lblStrikePrice.Visible = false;
            // 
            // ui_lblProductType
            // 
            this.ui_lblProductType.AutoSize = true;
            this.ui_lblProductType.Location = new System.Drawing.Point(0, 0);
            this.ui_lblProductType.Margin = new System.Windows.Forms.Padding(0);
            this.ui_lblProductType.Name = "ui_lblProductType";
            this.ui_lblProductType.Size = new System.Drawing.Size(71, 13);
            this.ui_lblProductType.TabIndex = 2;
            this.ui_lblProductType.Text = "Product Type";
            this.ui_lblProductType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_ncmbProductType
            // 
            this.ui_ncmbProductType.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbProductType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProductType.Location = new System.Drawing.Point(3, 19);
            this.ui_ncmbProductType.Name = "ui_ncmbProductType";
            this.ui_ncmbProductType.Size = new System.Drawing.Size(100, 19);
            this.ui_ncmbProductType.TabIndex = 3;
            // 
            // ui_ncmbProduct
            // 
            this.ui_ncmbProduct.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbProduct.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProduct.Location = new System.Drawing.Point(113, 19);
            this.ui_ncmbProduct.Name = "ui_ncmbProduct";
            this.ui_ncmbProduct.Size = new System.Drawing.Size(100, 19);
            this.ui_ncmbProduct.TabIndex = 11;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(113, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 12;
            this.lblProduct.Text = "Product";
            this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_lblContract
            // 
            this.ui_lblContract.AutoSize = true;
            this.ui_lblContract.Location = new System.Drawing.Point(223, 0);
            this.ui_lblContract.Name = "ui_lblContract";
            this.ui_lblContract.Size = new System.Drawing.Size(47, 13);
            this.ui_lblContract.TabIndex = 3;
            this.ui_lblContract.Text = "Contract";
            this.ui_lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ui_ncmbGateway
            // 
            this.ui_ncmbGateway.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbGateway.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbGateway.Location = new System.Drawing.Point(333, 19);
            this.ui_ncmbGateway.Name = "ui_ncmbGateway";
            this.ui_ncmbGateway.Size = new System.Drawing.Size(100, 19);
            this.ui_ncmbGateway.TabIndex = 14;
            this.ui_ncmbGateway.Visible = false;
            this.ui_ncmbGateway.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbProvider_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Gateway";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // ui_lblExpiryDate
            // 
            this.ui_lblExpiryDate.AutoSize = true;
            this.ui_lblExpiryDate.Location = new System.Drawing.Point(443, 0);
            this.ui_lblExpiryDate.Name = "ui_lblExpiryDate";
            this.ui_lblExpiryDate.Size = new System.Drawing.Size(61, 13);
            this.ui_lblExpiryDate.TabIndex = 5;
            this.ui_lblExpiryDate.Text = "Expiry Date";
            this.ui_lblExpiryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ui_lblExpiryDate.Visible = false;
            // 
            // ui_lblSeries
            // 
            this.ui_lblSeries.Location = new System.Drawing.Point(553, 16);
            this.ui_lblSeries.Name = "ui_lblSeries";
            this.ui_lblSeries.Size = new System.Drawing.Size(5, 13);
            this.ui_lblSeries.TabIndex = 4;
            this.ui_lblSeries.Text = "Series";
            this.ui_lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ui_lblSeries.Visible = false;
            // 
            // ui_ncmbExpiryDate
            // 
            this.ui_ncmbExpiryDate.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbExpiryDate.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbExpiryDate.Location = new System.Drawing.Point(443, 19);
            this.ui_ncmbExpiryDate.Name = "ui_ncmbExpiryDate";
            this.ui_ncmbExpiryDate.Size = new System.Drawing.Size(100, 19);
            this.ui_ncmbExpiryDate.TabIndex = 6;
            this.ui_ncmbExpiryDate.Visible = false;
            this.ui_ncmbExpiryDate.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbExpiryDate_SelectedIndexChanged);
            // 
            // ui_ncmbContract
            // 
            this.ui_ncmbContract.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbContract.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbContract.Location = new System.Drawing.Point(223, 19);
            this.ui_ncmbContract.Name = "ui_ncmbContract";
            this.ui_ncmbContract.Size = new System.Drawing.Size(100, 19);
            this.ui_ncmbContract.TabIndex = 15;
            // 
            // ui_ncmbExchange
            // 
            this.ui_ncmbExchange.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbExchange.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbExchange.Location = new System.Drawing.Point(583, 14);
            this.ui_ncmbExchange.Name = "ui_ncmbExchange";
            this.ui_ncmbExchange.Size = new System.Drawing.Size(82, 19);
            this.ui_ncmbExchange.TabIndex = 15;
            this.ui_ncmbExchange.Visible = false;
            this.ui_ncmbExchange.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbExchange_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(546, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Exchange";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // ui_nbtnRemovePortfoilo
            // 
            this.ui_nbtnRemovePortfoilo.Border.Style = Nevron.UI.BorderStyle3D.None;
            this.ui_nbtnRemovePortfoilo.Enabled = false;
            this.ui_nbtnRemovePortfoilo.Location = new System.Drawing.Point(245, 10);
            this.ui_nbtnRemovePortfoilo.Name = "ui_nbtnRemovePortfoilo";
            this.ui_nbtnRemovePortfoilo.Size = new System.Drawing.Size(125, 20);
            this.ui_nbtnRemovePortfoilo.TabIndex = 2;
            this.ui_nbtnRemovePortfoilo.Text = "&Remove Portfolio";
            this.ui_nbtnRemovePortfoilo.UseVisualStyleBackColor = false;
            this.ui_nbtnRemovePortfoilo.Click += new System.EventHandler(this.ui_nbtnRemovePortfoilo_Click);
            // 
            // ui_ncmbPortfolioName
            // 
            this.ui_ncmbPortfolioName.Editable = true;
            this.ui_ncmbPortfolioName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbPortfolioName.Location = new System.Drawing.Point(113, 10);
            this.ui_ncmbPortfolioName.Name = "ui_ncmbPortfolioName";
            this.ui_ncmbPortfolioName.Size = new System.Drawing.Size(125, 19);
            this.ui_ncmbPortfolioName.TabIndex = 1;
            this.ui_ncmbPortfolioName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbPortfolioName_SelectedIndexChanged);
            // 
            // ui_lblPortfolioName
            // 
            this.ui_lblPortfolioName.AutoSize = true;
            this.ui_lblPortfolioName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblPortfolioName.Location = new System.Drawing.Point(24, 14);
            this.ui_lblPortfolioName.Name = "ui_lblPortfolioName";
            this.ui_lblPortfolioName.Size = new System.Drawing.Size(82, 13);
            this.ui_lblPortfolioName.TabIndex = 0;
            this.ui_lblPortfolioName.Text = "Portfolio Name :";
            // 
            // UctlPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlPortfolio);
            this.Name = "UctlPortfolio";
            this.Size = new System.Drawing.Size(684, 469);
            this.Load += new System.EventHandler(this.uctlPortfolio_Load);
            this.ui_npnlPortfolio.ResumeLayout(false);
            this.ui_npnlPortfolio.PerformLayout();
            this.ui_tlpnlPortfolio.ResumeLayout(false);
            this.ui_tlpnlPortfolio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ngbeProductSearch)).EndInit();
            this.ui_ngbeProductSearch.ResumeLayout(false);
            this.ui_ngbeProductSearch.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRemovePortfoilo;
        private System.Windows.Forms.Label ui_lblPortfolioName;
        private Nevron.UI.WinForm.Controls.NGroupBoxEx ui_ngbeProductSearch;
        private System.Windows.Forms.Label ui_lblOptType;
        private System.Windows.Forms.Label ui_lblStrikePrice;
        private System.Windows.Forms.Label ui_lblExpiryDate;
        private System.Windows.Forms.Label ui_lblSeries;
        private System.Windows.Forms.Label ui_lblContract;
        private System.Windows.Forms.Label ui_lblProductType;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnClose;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSave;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnRemove;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnAdd;
        private System.Windows.Forms.Label ui_lblSelected;
        private System.Windows.Forms.TableLayoutPanel ui_tlpnlPortfolio;
        private System.Windows.Forms.Label label1;
        public UctlGrid ui_uctlGridPortfolioSelectedProduct;
        public UctlGrid ui_uctlGridPortfolioProduct;
        public Nevron.UI.WinForm.Controls.NUIPanel ui_npnlPortfolio;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbExpiryDate;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProductType;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbPortfolioName;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPortfolioName;
        private System.Windows.Forms.Label lblProduct;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProduct;
        public Nevron.UI.WinForm.Controls.NButton ui_nbtnSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbGateway;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbExchange;
        private System.Windows.Forms.Label label2;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbContract;
    }
}
