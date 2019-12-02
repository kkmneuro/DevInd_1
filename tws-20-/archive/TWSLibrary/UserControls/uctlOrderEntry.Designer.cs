namespace CommonLibrary.UserControls
{
    partial class UctlOrderEntry
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
            this.ui_ncmnuOrderEntry = new Nevron.UI.WinForm.Controls.NContextMenu();
            this.ui_ncmnuOrderEntryCustomize = new Nevron.UI.WinForm.Controls.NCommand();
            this.ui_npnlOrderEntry = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_tblPnl = new System.Windows.Forms.TableLayoutPanel();
            this.ui_lblOrderEntryType = new System.Windows.Forms.Label();
            this.ui_lblProductType = new System.Windows.Forms.Label();
            this.ui_ncmbInstrumentName = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ntxtSymbol = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblContractName = new System.Windows.Forms.Label();
            this.ui_ncmbOrderType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblOrderType = new System.Windows.Forms.Label();
            this.ui_ncmbMMOType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbAccountNos = new Nevron.UI.WinForm.Controls.NComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_lblQty = new System.Windows.Forms.Label();
            this.ui_lblPrice = new System.Windows.Forms.Label();
            this.ui_ntxtPrice = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblAccType = new System.Windows.Forms.Label();
            this.ui_ncmbAccType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblClientName = new System.Windows.Forms.Label();
            this.ui_ntxtClientName = new Nevron.UI.WinForm.Controls.NTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_lblValidity = new System.Windows.Forms.Label();
            this.ui_ncmbValidity = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbStrikePrice = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblStrikePrice = new System.Windows.Forms.Label();
            this.ui_lblSeries = new System.Windows.Forms.Label();
            this.ui_ncmbSeries = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblExpiryDate = new System.Windows.Forms.Label();
            this.ui_ncmbExpiryDate = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblOptType = new System.Windows.Forms.Label();
            this.ui_ncmbOptType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_nbtnSubmit = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_nbtnClear = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_ntxtDQty = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblDQty = new System.Windows.Forms.Label();
            this.ui_ntxtTrigPrice = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_lblTrigPrice = new System.Windows.Forms.Label();
            this.ui_ntxtQty = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_nNUpDown = new Nevron.UI.WinForm.Controls.NNumericUpDown();
            this.ui_ntxtPartOminiId = new Nevron.UI.WinForm.Controls.NTextBox();
            this.ui_ntxtUserRemark = new Nevron.UI.WinForm.Controls.NTextBox();
            this.nComboBox10 = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblUserRemark = new System.Windows.Forms.Label();
            this.ui_lblPartOmini = new System.Windows.Forms.Label();
            this.ui_npnlOrderEntry.SuspendLayout();
            this.ui_tblPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nNUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_ncmnuOrderEntry
            // 
            this.ui_ncmnuOrderEntry.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.ui_ncmnuOrderEntryCustomize});
            this.ui_ncmnuOrderEntry.CommandClick += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.ui_ncmnuOrderEntry_CommandClick);
            // 
            // ui_ncmnuOrderEntryCustomize
            // 
            this.ui_ncmnuOrderEntryCustomize.Properties.Text = "Customize";
            // 
            // ui_npnlOrderEntry
            // 
            this.ui_npnlOrderEntry.Controls.Add(this.ui_tblPnl);
            this.ui_npnlOrderEntry.Controls.Add(this.ui_ntxtPartOminiId);
            this.ui_npnlOrderEntry.Controls.Add(this.ui_ntxtUserRemark);
            this.ui_npnlOrderEntry.Controls.Add(this.nComboBox10);
            this.ui_npnlOrderEntry.Controls.Add(this.ui_lblUserRemark);
            this.ui_npnlOrderEntry.Controls.Add(this.ui_lblPartOmini);
            this.ui_npnlOrderEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlOrderEntry.FillInfo.Draw = false;
            this.ui_npnlOrderEntry.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlOrderEntry.Name = "ui_npnlOrderEntry";
            this.ui_npnlOrderEntry.Size = new System.Drawing.Size(761, 106);
            this.ui_npnlOrderEntry.TabIndex = 0;
            this.ui_npnlOrderEntry.Text = "nuiPanel1";
            this.ui_npnlOrderEntry.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ui_nPanelOrderEntry_MouseClick);
            // 
            // ui_tblPnl
            // 
            this.ui_tblPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_tblPnl.BackColor = System.Drawing.Color.Transparent;
            this.ui_tblPnl.ColumnCount = 8;
            this.ui_tblPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ui_tblPnl.Controls.Add(this.ui_lblOrderEntryType, 0, 0);
            this.ui_tblPnl.Controls.Add(this.ui_lblProductType, 0, 1);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbInstrumentName, 0, 2);
            this.ui_tblPnl.Controls.Add(this.ui_ntxtSymbol, 1, 2);
            this.ui_tblPnl.Controls.Add(this.ui_lblContractName, 1, 1);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbOrderType, 2, 2);
            this.ui_tblPnl.Controls.Add(this.ui_lblOrderType, 2, 1);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbMMOType, 5, 0);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbAccountNos, 3, 2);
            this.ui_tblPnl.Controls.Add(this.label1, 3, 1);
            this.ui_tblPnl.Controls.Add(this.ui_lblQty, 4, 1);
            this.ui_tblPnl.Controls.Add(this.ui_lblPrice, 5, 1);
            this.ui_tblPnl.Controls.Add(this.ui_ntxtPrice, 5, 2);
            this.ui_tblPnl.Controls.Add(this.ui_lblAccType, 6, 1);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbAccType, 6, 2);
            this.ui_tblPnl.Controls.Add(this.ui_lblClientName, 7, 1);
            this.ui_tblPnl.Controls.Add(this.ui_ntxtClientName, 7, 2);
            this.ui_tblPnl.Controls.Add(this.label2, 4, 0);
            this.ui_tblPnl.Controls.Add(this.ui_lblValidity, 0, 3);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbValidity, 0, 4);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbStrikePrice, 3, 4);
            this.ui_tblPnl.Controls.Add(this.ui_lblStrikePrice, 3, 3);
            this.ui_tblPnl.Controls.Add(this.ui_lblSeries, 4, 3);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbSeries, 4, 4);
            this.ui_tblPnl.Controls.Add(this.ui_lblExpiryDate, 5, 3);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbExpiryDate, 5, 4);
            this.ui_tblPnl.Controls.Add(this.ui_lblOptType, 2, 0);
            this.ui_tblPnl.Controls.Add(this.ui_ncmbOptType, 3, 0);
            this.ui_tblPnl.Controls.Add(this.ui_nbtnSubmit, 6, 4);
            this.ui_tblPnl.Controls.Add(this.ui_nbtnClear, 7, 4);
            this.ui_tblPnl.Controls.Add(this.ui_ntxtDQty, 7, 0);
            this.ui_tblPnl.Controls.Add(this.ui_lblDQty, 6, 0);
            this.ui_tblPnl.Controls.Add(this.ui_ntxtTrigPrice, 1, 4);
            this.ui_tblPnl.Controls.Add(this.ui_lblTrigPrice, 1, 3);
            this.ui_tblPnl.Controls.Add(this.ui_ntxtQty, 1, 0);
            this.ui_tblPnl.Controls.Add(this.ui_nNUpDown, 4, 2);
            this.ui_tblPnl.Location = new System.Drawing.Point(1, 0);
            this.ui_tblPnl.Name = "ui_tblPnl";
            this.ui_tblPnl.Padding = new System.Windows.Forms.Padding(2);
            this.ui_tblPnl.RowCount = 5;
            this.ui_tblPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPnl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ui_tblPnl.Size = new System.Drawing.Size(755, 102);
            this.ui_tblPnl.TabIndex = 41;
            this.ui_tblPnl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ui_nPanelOrderEntry_MouseClick);
            // 
            // ui_lblOrderEntryType
            // 
            this.ui_lblOrderEntryType.AutoSize = true;
            this.ui_lblOrderEntryType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOrderEntryType.Dock = System.Windows.Forms.DockStyle.Top;
            this.ui_lblOrderEntryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_lblOrderEntryType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblOrderEntryType.Location = new System.Drawing.Point(5, 2);
            this.ui_lblOrderEntryType.Name = "ui_lblOrderEntryType";
            this.ui_lblOrderEntryType.Size = new System.Drawing.Size(89, 15);
            this.ui_lblOrderEntryType.TabIndex = 20;
            this.ui_lblOrderEntryType.Text = "BUY";
            // 
            // ui_lblProductType
            // 
            this.ui_lblProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblProductType.AutoSize = true;
            this.ui_lblProductType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProductType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblProductType.Location = new System.Drawing.Point(5, 26);
            this.ui_lblProductType.Name = "ui_lblProductType";
            this.ui_lblProductType.Size = new System.Drawing.Size(71, 13);
            this.ui_lblProductType.TabIndex = 21;
            this.ui_lblProductType.Text = "Product Type";
            // 
            // ui_ncmbInstrumentName
            // 
            this.ui_ncmbInstrumentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbInstrumentName.Editable = true;
            this.ui_ncmbInstrumentName.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbInstrumentName.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbInstrumentName.Location = new System.Drawing.Point(5, 42);
            this.ui_ncmbInstrumentName.Name = "ui_ncmbInstrumentName";
            this.ui_ncmbInstrumentName.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbInstrumentName.TabIndex = 0;
            this.ui_ncmbInstrumentName.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbInstrumentName_SelectedIndexChanged);
            // 
            // ui_ntxtSymbol
            // 
            this.ui_ntxtSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtSymbol.Location = new System.Drawing.Point(100, 42);
            this.ui_ntxtSymbol.MaxLength = 20;
            this.ui_ntxtSymbol.Name = "ui_ntxtSymbol";
            this.ui_ntxtSymbol.Size = new System.Drawing.Size(89, 18);
            this.ui_ntxtSymbol.TabIndex = 1;
            this.ui_ntxtSymbol.TextChanged += new System.EventHandler(this.ui_ntxtSymbol_TextChanged);
            // 
            // ui_lblContractName
            // 
            this.ui_lblContractName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblContractName.AutoSize = true;
            this.ui_lblContractName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblContractName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblContractName.Location = new System.Drawing.Point(100, 26);
            this.ui_lblContractName.Name = "ui_lblContractName";
            this.ui_lblContractName.Size = new System.Drawing.Size(78, 13);
            this.ui_lblContractName.TabIndex = 23;
            this.ui_lblContractName.Text = "Contract Name";
            // 
            // ui_ncmbOrderType
            // 
            this.ui_ncmbOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbOrderType.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbOrderType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOrderType.Location = new System.Drawing.Point(195, 42);
            this.ui_ncmbOrderType.Name = "ui_ncmbOrderType";
            this.ui_ncmbOrderType.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbOrderType.TabIndex = 2;
            this.ui_ncmbOrderType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbOrderType_SelectedIndexChanged);
            // 
            // ui_lblOrderType
            // 
            this.ui_lblOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblOrderType.AutoSize = true;
            this.ui_lblOrderType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOrderType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblOrderType.Location = new System.Drawing.Point(195, 26);
            this.ui_lblOrderType.Name = "ui_lblOrderType";
            this.ui_lblOrderType.Size = new System.Drawing.Size(60, 13);
            this.ui_lblOrderType.TabIndex = 22;
            this.ui_lblOrderType.Text = "Order Type";
            // 
            // ui_ncmbMMOType
            // 
            this.ui_ncmbMMOType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbMMOType.Enabled = false;
            this.ui_ncmbMMOType.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbMMOType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbMMOType.Location = new System.Drawing.Point(479, 5);
            this.ui_ncmbMMOType.Name = "ui_ncmbMMOType";
            this.ui_ncmbMMOType.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbMMOType.TabIndex = 1;
            this.ui_ncmbMMOType.Visible = false;
            // 
            // ui_ncmbAccountNos
            // 
            this.ui_ncmbAccountNos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbAccountNos.Editable = true;
            this.ui_ncmbAccountNos.ListProperties.CheckOnClick = true;
            this.ui_ncmbAccountNos.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccountNos.Location = new System.Drawing.Point(290, 42);
            this.ui_ncmbAccountNos.Name = "ui_ncmbAccountNos";
            this.ui_ncmbAccountNos.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbAccountNos.TabIndex = 3;
            this.ui_ncmbAccountNos.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbAccountNos_SelectedIndexChanged);
            this.ui_ncmbAccountNos.Validating += new System.ComponentModel.CancelEventHandler(this.ui_ncmbAccountNos_Validating);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Account No :";
            // 
            // ui_lblQty
            // 
            this.ui_lblQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblQty.AutoSize = true;
            this.ui_lblQty.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblQty.Location = new System.Drawing.Point(385, 26);
            this.ui_lblQty.Name = "ui_lblQty";
            this.ui_lblQty.Size = new System.Drawing.Size(23, 13);
            this.ui_lblQty.TabIndex = 28;
            this.ui_lblQty.Text = "Qty";
            // 
            // ui_lblPrice
            // 
            this.ui_lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblPrice.AutoSize = true;
            this.ui_lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblPrice.Location = new System.Drawing.Point(479, 26);
            this.ui_lblPrice.Name = "ui_lblPrice";
            this.ui_lblPrice.Size = new System.Drawing.Size(31, 13);
            this.ui_lblPrice.TabIndex = 29;
            this.ui_lblPrice.Text = "Price";
            // 
            // ui_ntxtPrice
            // 
            this.ui_ntxtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtPrice.Location = new System.Drawing.Point(479, 42);
            this.ui_ntxtPrice.Name = "ui_ntxtPrice";
            this.ui_ntxtPrice.ShortcutsEnabled = false;
            this.ui_ntxtPrice.Size = new System.Drawing.Size(89, 20);
            this.ui_ntxtPrice.TabIndex = 5;
            this.ui_ntxtPrice.UseCustomScrollBars = false;
            this.ui_ntxtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtPrice_KeyPress);
            // 
            // ui_lblAccType
            // 
            this.ui_lblAccType.AutoSize = true;
            this.ui_lblAccType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAccType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblAccType.Location = new System.Drawing.Point(574, 26);
            this.ui_lblAccType.Name = "ui_lblAccType";
            this.ui_lblAccType.Size = new System.Drawing.Size(56, 13);
            this.ui_lblAccType.TabIndex = 31;
            this.ui_lblAccType.Text = "Acc. Type";
            // 
            // ui_ncmbAccType
            // 
            this.ui_ncmbAccType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbAccType.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Client", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("OWN", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbAccType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAccType.Location = new System.Drawing.Point(574, 42);
            this.ui_ncmbAccType.Name = "ui_ncmbAccType";
            this.ui_ncmbAccType.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbAccType.TabIndex = 6;
            // 
            // ui_lblClientName
            // 
            this.ui_lblClientName.AutoSize = true;
            this.ui_lblClientName.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblClientName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblClientName.Location = new System.Drawing.Point(669, 26);
            this.ui_lblClientName.Name = "ui_lblClientName";
            this.ui_lblClientName.Size = new System.Drawing.Size(64, 13);
            this.ui_lblClientName.TabIndex = 32;
            this.ui_lblClientName.Text = "Client Name";
            // 
            // ui_ntxtClientName
            // 
            this.ui_ntxtClientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtClientName.Location = new System.Drawing.Point(669, 42);
            this.ui_ntxtClientName.MaxLength = 50;
            this.ui_ntxtClientName.Name = "ui_ntxtClientName";
            this.ui_ntxtClientName.Size = new System.Drawing.Size(96, 18);
            this.ui_ntxtClientName.TabIndex = 7;
            this.ui_ntxtClientName.TextChanged += new System.EventHandler(this.ui_ntxtClientName_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(385, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "MMO Type";
            this.label2.Visible = false;
            // 
            // ui_lblValidity
            // 
            this.ui_lblValidity.AutoSize = true;
            this.ui_lblValidity.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblValidity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblValidity.Location = new System.Drawing.Point(5, 65);
            this.ui_lblValidity.Name = "ui_lblValidity";
            this.ui_lblValidity.Size = new System.Drawing.Size(40, 13);
            this.ui_lblValidity.TabIndex = 36;
            this.ui_lblValidity.Text = "Validity";
            // 
            // ui_ncmbValidity
            // 
            this.ui_ncmbValidity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbValidity.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbValidity.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbValidity.Location = new System.Drawing.Point(5, 81);
            this.ui_ncmbValidity.Name = "ui_ncmbValidity";
            this.ui_ncmbValidity.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbValidity.TabIndex = 8;
            // 
            // ui_ncmbStrikePrice
            // 
            this.ui_ncmbStrikePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbStrikePrice.Enabled = false;
            this.ui_ncmbStrikePrice.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbStrikePrice.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbStrikePrice.Location = new System.Drawing.Point(290, 81);
            this.ui_ncmbStrikePrice.Name = "ui_ncmbStrikePrice";
            this.ui_ncmbStrikePrice.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbStrikePrice.TabIndex = 6;
            this.ui_ncmbStrikePrice.Visible = false;
            // 
            // ui_lblStrikePrice
            // 
            this.ui_lblStrikePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblStrikePrice.AutoSize = true;
            this.ui_lblStrikePrice.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblStrikePrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblStrikePrice.Location = new System.Drawing.Point(290, 65);
            this.ui_lblStrikePrice.Name = "ui_lblStrikePrice";
            this.ui_lblStrikePrice.Size = new System.Drawing.Size(60, 13);
            this.ui_lblStrikePrice.TabIndex = 26;
            this.ui_lblStrikePrice.Text = "Strike price";
            this.ui_lblStrikePrice.Visible = false;
            // 
            // ui_lblSeries
            // 
            this.ui_lblSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblSeries.AutoSize = true;
            this.ui_lblSeries.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSeries.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblSeries.Location = new System.Drawing.Point(385, 65);
            this.ui_lblSeries.Name = "ui_lblSeries";
            this.ui_lblSeries.Size = new System.Drawing.Size(36, 13);
            this.ui_lblSeries.TabIndex = 24;
            this.ui_lblSeries.Text = "Series";
            this.ui_lblSeries.Visible = false;
            // 
            // ui_ncmbSeries
            // 
            this.ui_ncmbSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbSeries.Enabled = false;
            this.ui_ncmbSeries.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbSeries.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbSeries.Location = new System.Drawing.Point(385, 81);
            this.ui_ncmbSeries.Name = "ui_ncmbSeries";
            this.ui_ncmbSeries.Size = new System.Drawing.Size(88, 18);
            this.ui_ncmbSeries.TabIndex = 4;
            this.ui_ncmbSeries.Visible = false;
            // 
            // ui_lblExpiryDate
            // 
            this.ui_lblExpiryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblExpiryDate.AutoSize = true;
            this.ui_lblExpiryDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblExpiryDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblExpiryDate.Location = new System.Drawing.Point(479, 65);
            this.ui_lblExpiryDate.Name = "ui_lblExpiryDate";
            this.ui_lblExpiryDate.Size = new System.Drawing.Size(61, 13);
            this.ui_lblExpiryDate.TabIndex = 25;
            this.ui_lblExpiryDate.Text = "Expiry Date";
            this.ui_lblExpiryDate.Visible = false;
            // 
            // ui_ncmbExpiryDate
            // 
            this.ui_ncmbExpiryDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbExpiryDate.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbExpiryDate.Location = new System.Drawing.Point(479, 81);
            this.ui_ncmbExpiryDate.Name = "ui_ncmbExpiryDate";
            this.ui_ncmbExpiryDate.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbExpiryDate.TabIndex = 5;
            this.ui_ncmbExpiryDate.Text = "nComboBox4";
            this.ui_ncmbExpiryDate.Visible = false;
            // 
            // ui_lblOptType
            // 
            this.ui_lblOptType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ui_lblOptType.AutoSize = true;
            this.ui_lblOptType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOptType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblOptType.Location = new System.Drawing.Point(195, 13);
            this.ui_lblOptType.Name = "ui_lblOptType";
            this.ui_lblOptType.Size = new System.Drawing.Size(54, 13);
            this.ui_lblOptType.TabIndex = 27;
            this.ui_lblOptType.Text = "Opt. Type";
            this.ui_lblOptType.Visible = false;
            // 
            // ui_ncmbOptType
            // 
            this.ui_ncmbOptType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ncmbOptType.Enabled = false;
            this.ui_ncmbOptType.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbOptType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOptType.Location = new System.Drawing.Point(290, 5);
            this.ui_ncmbOptType.Name = "ui_ncmbOptType";
            this.ui_ncmbOptType.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbOptType.TabIndex = 7;
            this.ui_ncmbOptType.Visible = false;
            // 
            // ui_nbtnSubmit
            // 
            this.ui_nbtnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnSubmit.Location = new System.Drawing.Point(574, 81);
            this.ui_nbtnSubmit.Name = "ui_nbtnSubmit";
            this.ui_nbtnSubmit.Size = new System.Drawing.Size(89, 20);
            this.ui_nbtnSubmit.TabIndex = 10;
            this.ui_nbtnSubmit.Text = "&Submit";
            this.ui_nbtnSubmit.UseVisualStyleBackColor = false;
            this.ui_nbtnSubmit.Click += new System.EventHandler(this.ui_nbtnSubmit_Click);
            // 
            // ui_nbtnClear
            // 
            this.ui_nbtnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_nbtnClear.Location = new System.Drawing.Point(669, 81);
            this.ui_nbtnClear.Name = "ui_nbtnClear";
            this.ui_nbtnClear.Size = new System.Drawing.Size(96, 20);
            this.ui_nbtnClear.TabIndex = 11;
            this.ui_nbtnClear.Text = "&Clear";
            this.ui_nbtnClear.UseVisualStyleBackColor = false;
            this.ui_nbtnClear.Click += new System.EventHandler(this.ui_nbtnClear_Click);
            // 
            // ui_ntxtDQty
            // 
            this.ui_ntxtDQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtDQty.Enabled = false;
            this.ui_ntxtDQty.Location = new System.Drawing.Point(669, 5);
            this.ui_ntxtDQty.MaxLength = 10;
            this.ui_ntxtDQty.Name = "ui_ntxtDQty";
            this.ui_ntxtDQty.Size = new System.Drawing.Size(96, 18);
            this.ui_ntxtDQty.TabIndex = 14;
            this.ui_ntxtDQty.Visible = false;
            this.ui_ntxtDQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtDQty_KeyPress);
            // 
            // ui_lblDQty
            // 
            this.ui_lblDQty.AutoSize = true;
            this.ui_lblDQty.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblDQty.Location = new System.Drawing.Point(574, 2);
            this.ui_lblDQty.Name = "ui_lblDQty";
            this.ui_lblDQty.Size = new System.Drawing.Size(37, 13);
            this.ui_lblDQty.TabIndex = 30;
            this.ui_lblDQty.Text = "D. Qty";
            this.ui_lblDQty.Visible = false;
            // 
            // ui_ntxtTrigPrice
            // 
            this.ui_ntxtTrigPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtTrigPrice.Enabled = false;
            this.ui_ntxtTrigPrice.Location = new System.Drawing.Point(100, 81);
            this.ui_ntxtTrigPrice.Name = "ui_ntxtTrigPrice";
            this.ui_ntxtTrigPrice.Size = new System.Drawing.Size(89, 18);
            this.ui_ntxtTrigPrice.TabIndex = 9;
            this.ui_ntxtTrigPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtTrigPrice_KeyPress);
            // 
            // ui_lblTrigPrice
            // 
            this.ui_lblTrigPrice.AutoSize = true;
            this.ui_lblTrigPrice.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTrigPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblTrigPrice.Location = new System.Drawing.Point(100, 65);
            this.ui_lblTrigPrice.Name = "ui_lblTrigPrice";
            this.ui_lblTrigPrice.Size = new System.Drawing.Size(55, 13);
            this.ui_lblTrigPrice.TabIndex = 35;
            this.ui_lblTrigPrice.Text = "Trig. Price";
            // 
            // ui_ntxtQty
            // 
            this.ui_ntxtQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ui_ntxtQty.Location = new System.Drawing.Point(100, 5);
            this.ui_ntxtQty.MaxLength = 10;
            this.ui_ntxtQty.Name = "ui_ntxtQty";
            this.ui_ntxtQty.ShortcutsEnabled = false;
            this.ui_ntxtQty.Size = new System.Drawing.Size(89, 18);
            this.ui_ntxtQty.TabIndex = 8;
            this.ui_ntxtQty.Text = "0";
            this.ui_ntxtQty.Visible = false;
            this.ui_ntxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ui_ntxtQty_KeyPress);
            // 
            // ui_nNUpDown
            // 
            this.ui_nNUpDown.Location = new System.Drawing.Point(385, 42);
            this.ui_nNUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ui_nNUpDown.Name = "ui_nNUpDown";
            this.ui_nNUpDown.Size = new System.Drawing.Size(88, 20);
            this.ui_nNUpDown.TabIndex = 4;
            this.ui_nNUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ui_ntxtPartOminiId
            // 
            this.ui_ntxtPartOminiId.Enabled = false;
            this.ui_ntxtPartOminiId.Location = new System.Drawing.Point(647, 69);
            this.ui_ntxtPartOminiId.Name = "ui_ntxtPartOminiId";
            this.ui_ntxtPartOminiId.Size = new System.Drawing.Size(73, 18);
            this.ui_ntxtPartOminiId.TabIndex = 38;
            this.ui_ntxtPartOminiId.Visible = false;
            // 
            // ui_ntxtUserRemark
            // 
            this.ui_ntxtUserRemark.Location = new System.Drawing.Point(646, 69);
            this.ui_ntxtUserRemark.Name = "ui_ntxtUserRemark";
            this.ui_ntxtUserRemark.Size = new System.Drawing.Size(73, 18);
            this.ui_ntxtUserRemark.TabIndex = 17;
            this.ui_ntxtUserRemark.Visible = false;
            // 
            // nComboBox10
            // 
            this.nComboBox10.Enabled = false;
            this.nComboBox10.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("---SELECT---", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.nComboBox10.ListProperties.ColumnOnLeft = false;
            this.nComboBox10.Location = new System.Drawing.Point(515, 69);
            this.nComboBox10.Name = "nComboBox10";
            this.nComboBox10.Size = new System.Drawing.Size(73, 18);
            this.nComboBox10.TabIndex = 16;
            this.nComboBox10.Text = "nComboBox10";
            this.nComboBox10.Visible = false;
            // 
            // ui_lblUserRemark
            // 
            this.ui_lblUserRemark.AutoSize = true;
            this.ui_lblUserRemark.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblUserRemark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblUserRemark.Location = new System.Drawing.Point(644, 54);
            this.ui_lblUserRemark.Name = "ui_lblUserRemark";
            this.ui_lblUserRemark.Size = new System.Drawing.Size(69, 13);
            this.ui_lblUserRemark.TabIndex = 37;
            this.ui_lblUserRemark.Text = "User Remark";
            this.ui_lblUserRemark.Visible = false;
            // 
            // ui_lblPartOmini
            // 
            this.ui_lblPartOmini.AutoSize = true;
            this.ui_lblPartOmini.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblPartOmini.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_lblPartOmini.Location = new System.Drawing.Point(645, 54);
            this.ui_lblPartOmini.Name = "ui_lblPartOmini";
            this.ui_lblPartOmini.Size = new System.Drawing.Size(79, 13);
            this.ui_lblPartOmini.TabIndex = 34;
            this.ui_lblPartOmini.Text = "PartID/OminiID";
            this.ui_lblPartOmini.Visible = false;
            // 
            // UctlOrderEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ui_npnlOrderEntry);
            this.Name = "UctlOrderEntry";
            this.Size = new System.Drawing.Size(761, 106);
            this.Load += new System.EventHandler(this.uctlOrderEntry_Load);            
            this.ui_npnlOrderEntry.ResumeLayout(false);
            this.ui_npnlOrderEntry.PerformLayout();
            this.ui_tblPnl.ResumeLayout(false);
            this.ui_tblPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_nNUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtUserRemark;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtClientName;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtDQty;
        private System.Windows.Forms.Label ui_lblSeries;
        private Nevron.UI.WinForm.Controls.NComboBox nComboBox10;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbValidity;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOptType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbStrikePrice;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbExpiryDate;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbSeries;
        private System.Windows.Forms.Label ui_lblUserRemark;
        private System.Windows.Forms.Label ui_lblValidity;
        private System.Windows.Forms.Label ui_lblTrigPrice;
        private System.Windows.Forms.Label ui_lblPartOmini;
        private System.Windows.Forms.Label ui_lblClientName;
        private System.Windows.Forms.Label ui_lblAccType;
        private System.Windows.Forms.Label ui_lblDQty;
        private System.Windows.Forms.Label ui_lblPrice;
        private System.Windows.Forms.Label ui_lblQty;
        private System.Windows.Forms.Label ui_lblOptType;
        private System.Windows.Forms.Label ui_lblStrikePrice;
        private System.Windows.Forms.Label ui_lblExpiryDate;
        private System.Windows.Forms.Label ui_lblContractName;
        private System.Windows.Forms.Label ui_lblOrderType;
        private System.Windows.Forms.Label ui_lblProductType;
        public System.Windows.Forms.Label ui_lblOrderEntryType;
        private Nevron.UI.WinForm.Controls.NContextMenu ui_ncmnuOrderEntry;
        private Nevron.UI.WinForm.Controls.NCommand ui_ncmnuOrderEntryCustomize;
        public Nevron.UI.WinForm.Controls.NUIPanel ui_npnlOrderEntry;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbInstrumentName;
        private Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPartOminiId;
        public Nevron.UI.WinForm.Controls.NButton ui_nbtnSubmit;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TableLayoutPanel ui_tblPnl;
        private System.Windows.Forms.Label label1;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAccountNos;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbMMOType;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtQty;
        public Nevron.UI.WinForm.Controls.NButton ui_nbtnClear;
        public Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOrderType;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtPrice;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtSymbol;
        public Nevron.UI.WinForm.Controls.NNumericUpDown ui_nNUpDown;
        public Nevron.UI.WinForm.Controls.NTextBox ui_ntxtTrigPrice;

    }
}
