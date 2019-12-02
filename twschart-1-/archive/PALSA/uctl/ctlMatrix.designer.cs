using PALSA.Cls;
using M4;
using PALSA.ClsMatrix;

namespace PALSA.uctl
{
    partial class ctlMatrix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlMatrix));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlRightRight = new System.Windows.Forms.Panel();
            this.chkbActivationRule = new System.Windows.Forms.CheckBox();
            this.cmbxPegPrice = new System.Windows.Forms.ComboBox();
            this.chkBoxBuy_Sell = new System.Windows.Forms.CheckBox();
            this.btn3PAR = new System.Windows.Forms.Button();
            this.chkboxECNSweep = new System.Windows.Forms.CheckBox();
            this.cnkBoxifTouched = new System.Windows.Forms.CheckBox();
            this.chkBoxNonDisplay = new System.Windows.Forms.CheckBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPricePeg = new System.Windows.Forms.Label();
            this.chkBoxShowOnly = new System.Windows.Forms.CheckBox();
            this.chkBoxPeg = new System.Windows.Forms.CheckBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.nudPriceDiscretionary = new System.Windows.Forms.NumericUpDown();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.lblPriceD = new System.Windows.Forms.Label();
            this.chkBoxdiscretionary = new System.Windows.Forms.CheckBox();
            this.btn3point = new System.Windows.Forms.Button();
            this.cmbxAttachOSO = new System.Windows.Forms.ComboBox();
            this.lblAttachOSO = new System.Windows.Forms.Label();
            this.cmbxRoute = new System.Windows.Forms.ComboBox();
            this.lblRoute = new System.Windows.Forms.Label();
            this.cmbxDuration = new System.Windows.Forms.ComboBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.rtxtQuantity = new System.Windows.Forms.RichTextBox();
            this.btnP = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnS = new System.Windows.Forms.Button();
            this.cmbxAccount = new System.Windows.Forms.ComboBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.cmbxOrderType = new System.Windows.Forms.ComboBox();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.dgvTop = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.clmnSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBidYick = new System.Windows.Forms.DataGridViewImageColumn();
            this.Last = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnP_L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnAccountNO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btnCollapse = new Nevron.UI.WinForm.Controls.NButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvBottom = new PALSA.Cls.MarketDataGrid();
            this.clmnP_LP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnP_LB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnOrders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBidSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnAskSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnVolume = new M4.DataGridViewBarGraphColumn();
            this.clmnTimeVolBar = new PALSA.ClsMatrix.DataGridViewBarTimeColumn();
            this.clmnVolumeN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnVolumep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBidBar = new M4.DataGridViewBarGraphColumn();
            this.clmnBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnOfferBar = new M4.DataGridViewBarGraphColumn();
            this.clmnOfferP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnBuySellbar = new M4.DataGridViewBarBuySellColumn();
            this.nStatusBar1 = new Nevron.UI.WinForm.Controls.NStatusBar();
            this.nStatusBarPanel1 = new Nevron.UI.WinForm.Controls.NStatusBarPanel();
            this.nTabControl1 = new Nevron.UI.WinForm.Controls.NTabControl();
            this.tabOrderSettings = new Nevron.UI.WinForm.Controls.NTabPage();
            this.pnlOrderSettings = new System.Windows.Forms.Panel();
            this.nGroupBox3 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnXOfrs = new System.Windows.Forms.Button();
            this.btnCancelAll = new System.Windows.Forms.Button();
            this.btnXBids = new System.Windows.Forms.Button();
            this.nGroupBox2 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.btnOcOpoint = new System.Windows.Forms.Button();
            this.btnBuyMkt = new System.Windows.Forms.Button();
            this.btnBuyTRLOrder = new System.Windows.Forms.Button();
            this.btnSellTRLOrder = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnSellMkt = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnOCOOrder = new System.Windows.Forms.Button();
            this.nGroupBox1 = new Nevron.UI.WinForm.Controls.NGroupBox();
            this.tabManOrder = new Nevron.UI.WinForm.Controls.NTabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbManegeOrders_Positions = new System.Windows.Forms.GroupBox();
            this.tabAdvancedOrderBar = new Nevron.UI.WinForm.Controls.NTabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewBarGraphColumn1 = new M4.DataGridViewBarGraphColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlRightRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceDiscretionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel1)).BeginInit();
            this.nTabControl1.SuspendLayout();
            this.tabOrderSettings.SuspendLayout();
            this.pnlOrderSettings.SuspendLayout();
            this.nGroupBox3.SuspendLayout();
            this.nGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.nGroupBox1.SuspendLayout();
            this.tabManOrder.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabAdvancedOrderBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Up.png");
            this.imageList1.Images.SetKeyName(1, "down.png");
            this.imageList1.Images.SetKeyName(2, "empty.png");
            // 
            // pnlRightRight
            // 
            this.pnlRightRight.AutoScroll = true;
            this.pnlRightRight.Controls.Add(this.chkbActivationRule);
            this.pnlRightRight.Controls.Add(this.cmbxPegPrice);
            this.pnlRightRight.Controls.Add(this.chkBoxBuy_Sell);
            this.pnlRightRight.Controls.Add(this.btn3PAR);
            this.pnlRightRight.Controls.Add(this.chkboxECNSweep);
            this.pnlRightRight.Controls.Add(this.cnkBoxifTouched);
            this.pnlRightRight.Controls.Add(this.chkBoxNonDisplay);
            this.pnlRightRight.Controls.Add(this.lblPrice);
            this.pnlRightRight.Controls.Add(this.nudPrice);
            this.pnlRightRight.Controls.Add(this.lblPricePeg);
            this.pnlRightRight.Controls.Add(this.chkBoxShowOnly);
            this.pnlRightRight.Controls.Add(this.chkBoxPeg);
            this.pnlRightRight.Controls.Add(this.lblQty);
            this.pnlRightRight.Controls.Add(this.nudPriceDiscretionary);
            this.pnlRightRight.Controls.Add(this.nudQty);
            this.pnlRightRight.Controls.Add(this.lblPriceD);
            this.pnlRightRight.Controls.Add(this.chkBoxdiscretionary);
            this.pnlRightRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRightRight.Name = "pnlRightRight";
            this.pnlRightRight.Size = new System.Drawing.Size(273, 625);
            this.pnlRightRight.TabIndex = 23;
            // 
            // chkbActivationRule
            // 
            this.chkbActivationRule.AutoSize = true;
            this.chkbActivationRule.Location = new System.Drawing.Point(11, 18);
            this.chkbActivationRule.Name = "chkbActivationRule";
            this.chkbActivationRule.Size = new System.Drawing.Size(98, 17);
            this.chkbActivationRule.TabIndex = 0;
            this.chkbActivationRule.Text = "Activation Rule";
            this.chkbActivationRule.UseVisualStyleBackColor = true;
            // 
            // cmbxPegPrice
            // 
            this.cmbxPegPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxPegPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxPegPrice.FormattingEnabled = true;
            this.cmbxPegPrice.Location = new System.Drawing.Point(62, 204);
            this.cmbxPegPrice.Name = "cmbxPegPrice";
            this.cmbxPegPrice.Size = new System.Drawing.Size(199, 21);
            this.cmbxPegPrice.TabIndex = 19;
            // 
            // chkBoxBuy_Sell
            // 
            this.chkBoxBuy_Sell.AutoSize = true;
            this.chkBoxBuy_Sell.Location = new System.Drawing.Point(11, 339);
            this.chkBoxBuy_Sell.Name = "chkBoxBuy_Sell";
            this.chkBoxBuy_Sell.Size = new System.Drawing.Size(111, 17);
            this.chkBoxBuy_Sell.TabIndex = 22;
            this.chkBoxBuy_Sell.Text = "Buy on -/Sell on +";
            this.chkBoxBuy_Sell.UseVisualStyleBackColor = true;
            // 
            // btn3PAR
            // 
            this.btn3PAR.Location = new System.Drawing.Point(121, 13);
            this.btn3PAR.Name = "btn3PAR";
            this.btn3PAR.Size = new System.Drawing.Size(25, 25);
            this.btn3PAR.TabIndex = 7;
            this.btn3PAR.Text = "...";
            this.btn3PAR.UseVisualStyleBackColor = true;
            // 
            // chkboxECNSweep
            // 
            this.chkboxECNSweep.AutoSize = true;
            this.chkboxECNSweep.Location = new System.Drawing.Point(11, 303);
            this.chkboxECNSweep.Name = "chkboxECNSweep";
            this.chkboxECNSweep.Size = new System.Drawing.Size(84, 17);
            this.chkboxECNSweep.TabIndex = 21;
            this.chkboxECNSweep.Text = "ECN Sweep";
            this.chkboxECNSweep.UseVisualStyleBackColor = true;
            // 
            // cnkBoxifTouched
            // 
            this.cnkBoxifTouched.AutoSize = true;
            this.cnkBoxifTouched.Location = new System.Drawing.Point(11, 41);
            this.cnkBoxifTouched.Name = "cnkBoxifTouched";
            this.cnkBoxifTouched.Size = new System.Drawing.Size(78, 17);
            this.cnkBoxifTouched.TabIndex = 8;
            this.cnkBoxifTouched.Text = "If Touched";
            this.cnkBoxifTouched.UseVisualStyleBackColor = true;
            // 
            // chkBoxNonDisplay
            // 
            this.chkBoxNonDisplay.AutoSize = true;
            this.chkBoxNonDisplay.Location = new System.Drawing.Point(11, 266);
            this.chkBoxNonDisplay.Name = "chkBoxNonDisplay";
            this.chkBoxNonDisplay.Size = new System.Drawing.Size(83, 17);
            this.chkBoxNonDisplay.TabIndex = 20;
            this.chkBoxNonDisplay.Text = "Non Display";
            this.chkBoxNonDisplay.UseVisualStyleBackColor = true;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(8, 69);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 9;
            this.lblPrice.Text = "Price";
            // 
            // nudPrice
            // 
            this.nudPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPrice.Location = new System.Drawing.Point(62, 62);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(197, 20);
            this.nudPrice.TabIndex = 10;
            // 
            // lblPricePeg
            // 
            this.lblPricePeg.AutoSize = true;
            this.lblPricePeg.Location = new System.Drawing.Point(8, 233);
            this.lblPricePeg.Name = "lblPricePeg";
            this.lblPricePeg.Size = new System.Drawing.Size(31, 13);
            this.lblPricePeg.TabIndex = 18;
            this.lblPricePeg.Text = "Price";
            // 
            // chkBoxShowOnly
            // 
            this.chkBoxShowOnly.AutoSize = true;
            this.chkBoxShowOnly.Location = new System.Drawing.Point(11, 94);
            this.chkBoxShowOnly.Name = "chkBoxShowOnly";
            this.chkBoxShowOnly.Size = new System.Drawing.Size(77, 17);
            this.chkBoxShowOnly.TabIndex = 11;
            this.chkBoxShowOnly.Text = "Show Only";
            this.chkBoxShowOnly.UseVisualStyleBackColor = true;
            // 
            // chkBoxPeg
            // 
            this.chkBoxPeg.AutoSize = true;
            this.chkBoxPeg.Location = new System.Drawing.Point(11, 208);
            this.chkBoxPeg.Name = "chkBoxPeg";
            this.chkBoxPeg.Size = new System.Drawing.Size(45, 17);
            this.chkBoxPeg.TabIndex = 17;
            this.chkBoxPeg.Text = "Peg";
            this.chkBoxPeg.UseVisualStyleBackColor = true;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(8, 124);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(23, 13);
            this.lblQty.TabIndex = 12;
            this.lblQty.Text = "Qty";
            // 
            // nudPriceDiscretionary
            // 
            this.nudPriceDiscretionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPriceDiscretionary.Location = new System.Drawing.Point(42, 168);
            this.nudPriceDiscretionary.Name = "nudPriceDiscretionary";
            this.nudPriceDiscretionary.Size = new System.Drawing.Size(217, 20);
            this.nudPriceDiscretionary.TabIndex = 16;
            // 
            // nudQty
            // 
            this.nudQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQty.Location = new System.Drawing.Point(42, 117);
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(219, 20);
            this.nudQty.TabIndex = 13;
            // 
            // lblPriceD
            // 
            this.lblPriceD.AutoSize = true;
            this.lblPriceD.Location = new System.Drawing.Point(5, 175);
            this.lblPriceD.Name = "lblPriceD";
            this.lblPriceD.Size = new System.Drawing.Size(31, 13);
            this.lblPriceD.TabIndex = 15;
            this.lblPriceD.Text = "Price";
            // 
            // chkBoxdiscretionary
            // 
            this.chkBoxdiscretionary.AutoSize = true;
            this.chkBoxdiscretionary.Location = new System.Drawing.Point(11, 145);
            this.chkBoxdiscretionary.Name = "chkBoxdiscretionary";
            this.chkBoxdiscretionary.Size = new System.Drawing.Size(87, 17);
            this.chkBoxdiscretionary.TabIndex = 14;
            this.chkBoxdiscretionary.Text = "Discretionary";
            this.chkBoxdiscretionary.UseVisualStyleBackColor = true;
            // 
            // btn3point
            // 
            this.btn3point.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn3point.Enabled = false;
            this.btn3point.Location = new System.Drawing.Point(228, 313);
            this.btn3point.Name = "btn3point";
            this.btn3point.Size = new System.Drawing.Size(25, 21);
            this.btn3point.TabIndex = 15;
            this.btn3point.Text = "...";
            this.btn3point.UseVisualStyleBackColor = true;
            // 
            // cmbxAttachOSO
            // 
            this.cmbxAttachOSO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxAttachOSO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAttachOSO.Enabled = false;
            this.cmbxAttachOSO.FormattingEnabled = true;
            this.cmbxAttachOSO.Location = new System.Drawing.Point(4, 313);
            this.cmbxAttachOSO.Name = "cmbxAttachOSO";
            this.cmbxAttachOSO.Size = new System.Drawing.Size(219, 21);
            this.cmbxAttachOSO.TabIndex = 14;
            // 
            // lblAttachOSO
            // 
            this.lblAttachOSO.AutoSize = true;
            this.lblAttachOSO.Location = new System.Drawing.Point(4, 297);
            this.lblAttachOSO.Name = "lblAttachOSO";
            this.lblAttachOSO.Size = new System.Drawing.Size(64, 13);
            this.lblAttachOSO.TabIndex = 13;
            this.lblAttachOSO.Text = "Attach OSO";
            // 
            // cmbxRoute
            // 
            this.cmbxRoute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxRoute.Enabled = false;
            this.cmbxRoute.FormattingEnabled = true;
            this.cmbxRoute.Location = new System.Drawing.Point(3, 274);
            this.cmbxRoute.Name = "cmbxRoute";
            this.cmbxRoute.Size = new System.Drawing.Size(250, 21);
            this.cmbxRoute.TabIndex = 12;
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Location = new System.Drawing.Point(3, 257);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(36, 13);
            this.lblRoute.TabIndex = 11;
            this.lblRoute.Text = "Route";
            // 
            // cmbxDuration
            // 
            this.cmbxDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxDuration.FormattingEnabled = true;
            this.cmbxDuration.Items.AddRange(new object[] {
            "GTD",
            "GTC"});
            this.cmbxDuration.Location = new System.Drawing.Point(3, 233);
            this.cmbxDuration.Name = "cmbxDuration";
            this.cmbxDuration.Size = new System.Drawing.Size(250, 21);
            this.cmbxDuration.TabIndex = 10;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(3, 217);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(47, 13);
            this.lblDuration.TabIndex = 9;
            this.lblDuration.Text = "Duration";
            // 
            // rtxtQuantity
            // 
            this.rtxtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.rtxtQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rtxtQuantity.Location = new System.Drawing.Point(3, 153);
            this.rtxtQuantity.Name = "rtxtQuantity";
            this.rtxtQuantity.Size = new System.Drawing.Size(250, 58);
            this.rtxtQuantity.TabIndex = 8;
            this.rtxtQuantity.Text = "1";
            // 
            // btnP
            // 
            this.btnP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnP.Location = new System.Drawing.Point(230, 127);
            this.btnP.Name = "btnP";
            this.btnP.Size = new System.Drawing.Size(23, 23);
            this.btnP.TabIndex = 7;
            this.btnP.Text = "P";
            this.btnP.UseVisualStyleBackColor = true;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQuantity.Location = new System.Drawing.Point(33, 127);
            this.nudQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(191, 20);
            this.nudQuantity.TabIndex = 6;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(3, 101);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity";
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(3, 124);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(21, 23);
            this.btnS.TabIndex = 4;
            this.btnS.Text = "#";
            this.btnS.UseVisualStyleBackColor = true;
            // 
            // cmbxAccount
            // 
            this.cmbxAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxAccount.FormattingEnabled = true;
            this.cmbxAccount.Location = new System.Drawing.Point(3, 77);
            this.cmbxAccount.Name = "cmbxAccount";
            this.cmbxAccount.Size = new System.Drawing.Size(250, 21);
            this.cmbxAccount.TabIndex = 3;
            this.cmbxAccount.SelectedIndexChanged += new System.EventHandler(this.cmbxAccount_SelectedIndexChanged);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(3, 61);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(64, 13);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "Account No";
            // 
            // cmbxOrderType
            // 
            this.cmbxOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxOrderType.FormattingEnabled = true;
            this.cmbxOrderType.Items.AddRange(new object[] {
            "Auto(LMT/STP)",
            "Auto(LMT/STL)",
            "Limit",
            "Stop Market",
            "Stop Limit"});
            this.cmbxOrderType.Location = new System.Drawing.Point(3, 34);
            this.cmbxOrderType.Name = "cmbxOrderType";
            this.cmbxOrderType.Size = new System.Drawing.Size(250, 21);
            this.cmbxOrderType.TabIndex = 1;
            // 
            // lblOrderType
            // 
            this.lblOrderType.AutoSize = true;
            this.lblOrderType.Location = new System.Drawing.Point(3, 18);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(60, 13);
            this.lblOrderType.TabIndex = 0;
            this.lblOrderType.Text = "Order Type";
            // 
            // dgvTop
            // 
            this.dgvTop.AllowUserToAddRows = false;
            this.dgvTop.AllowUserToDeleteRows = false;
            this.dgvTop.AllowUserToResizeColumns = false;
            this.dgvTop.AllowUserToResizeRows = false;
            this.dgvTop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTop.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTop.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnSymbol,
            this.clmnBidYick,
            this.Last,
            this.NetChange,
            this.clmnPosition,
            this.clmnP_L,
            this.clmnQuantity,
            this.clmnAccountNO});
            this.dgvTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTop.EnableCellCustomDraw = false;
            this.dgvTop.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvTop.Location = new System.Drawing.Point(0, 0);
            this.dgvTop.Name = "dgvTop";
            this.dgvTop.RowTemplate.Height = 24;
            this.dgvTop.Size = new System.Drawing.Size(832, 49);
            this.dgvTop.TabIndex = 1;
            this.dgvTop.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTop_CellMouseDoubleClick);
            this.dgvTop.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvTop_EditingControlShowing);
            // 
            // clmnSymbol
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnSymbol.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmnSymbol.HeaderText = "Symbol";
            this.clmnSymbol.Name = "clmnSymbol";
            this.clmnSymbol.ReadOnly = true;
            // 
            // clmnBidYick
            // 
            this.clmnBidYick.HeaderText = "Bid Tick";
            this.clmnBidYick.Name = "clmnBidYick";
            this.clmnBidYick.ReadOnly = true;
            // 
            // Last
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Last.DefaultCellStyle = dataGridViewCellStyle3;
            this.Last.HeaderText = "Last";
            this.Last.Name = "Last";
            this.Last.ReadOnly = true;
            // 
            // NetChange
            // 
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.NetChange.DefaultCellStyle = dataGridViewCellStyle4;
            this.NetChange.HeaderText = "Net Chg";
            this.NetChange.Name = "NetChange";
            this.NetChange.ReadOnly = true;
            // 
            // clmnPosition
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnPosition.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmnPosition.HeaderText = "Position";
            this.clmnPosition.Name = "clmnPosition";
            this.clmnPosition.ReadOnly = true;
            this.clmnPosition.Visible = false;
            // 
            // clmnP_L
            // 
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnP_L.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmnP_L.HeaderText = "P/L";
            this.clmnP_L.Name = "clmnP_L";
            this.clmnP_L.ReadOnly = true;
            this.clmnP_L.Visible = false;
            // 
            // clmnQuantity
            // 
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnQuantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmnQuantity.HeaderText = "Quantity";
            this.clmnQuantity.Name = "clmnQuantity";
            this.clmnQuantity.Visible = false;
            // 
            // clmnAccountNO
            // 
            this.clmnAccountNO.HeaderText = "AccountNo";
            this.clmnAccountNO.Name = "clmnAccountNO";
            this.clmnAccountNO.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnAccountNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmnAccountNO.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1143, 658);
            this.splitContainer1.SplitterDistance = 861;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(861, 658);
            this.splitContainer2.SplitterDistance = 49;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvTop);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btnCollapse);
            this.splitContainer4.Size = new System.Drawing.Size(861, 49);
            this.splitContainer4.SplitterDistance = 832;
            this.splitContainer4.TabIndex = 2;
            // 
            // btnCollapse
            // 
            this.btnCollapse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCollapse.Location = new System.Drawing.Point(0, 0);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(25, 49);
            this.btnCollapse.TabIndex = 0;
            this.btnCollapse.Text = "..";
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            this.btnCollapse.MouseHover += new System.EventHandler(this.btnCollapse_MouseHover);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvBottom);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.nStatusBar1);
            this.splitContainer3.Size = new System.Drawing.Size(861, 608);
            this.splitContainer3.SplitterDistance = 582;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 1;
            // 
            // dgvBottom
            // 
            this.dgvBottom.AllowDrop = true;
            this.dgvBottom.AllowUserToAddRows = false;
            this.dgvBottom.AllowUserToDeleteRows = false;
            this.dgvBottom.AllowUserToResizeColumns = false;
            this.dgvBottom.AllowUserToResizeRows = false;
            this.dgvBottom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBottom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBottom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBottom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBottom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnP_LP,
            this.clmnP_LB,
            this.clmnOrders,
            this.clmnBidSize,
            this.clmnPrice,
            this.clmnAskSize,
            this.clmnVolume,
            this.clmnTimeVolBar,
            this.clmnVolumeN,
            this.clmnVolumep,
            this.clmnBidBar,
            this.clmnBid,
            this.clmnOfferBar,
            this.clmnOfferP,
            this.clmnBuySellbar});
            this.dgvBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBottom.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBottom.EnableCellCustomDraw = false;
            this.dgvBottom.GridColor = System.Drawing.Color.SaddleBrown;
            this.dgvBottom.Location = new System.Drawing.Point(0, 0);
            this.dgvBottom.MultiSelect = false;
            this.dgvBottom.Name = "dgvBottom";
            this.dgvBottom.RowTemplate.Height = 20;
            this.dgvBottom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBottom.Size = new System.Drawing.Size(861, 582);
            this.dgvBottom.TabIndex = 0;
            this.dgvBottom.VirtualMode = true;
            this.dgvBottom.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBottom_CellMouseEnter);
            this.dgvBottom.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DgvBottomCellPainting);
            this.dgvBottom.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvBottom_CellValueNeeded);
            this.dgvBottom.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvBottom_DragDrop);
            this.dgvBottom.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvBottom_DragOver);
            this.dgvBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvBottom_MouseDown);
            this.dgvBottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvBottom_MouseUp);
            // 
            // clmnP_LP
            // 
            this.clmnP_LP.HeaderText = "P/L %";
            this.clmnP_LP.MinimumWidth = 50;
            this.clmnP_LP.Name = "clmnP_LP";
            this.clmnP_LP.ReadOnly = true;
            this.clmnP_LP.Visible = false;
            // 
            // clmnP_LB
            // 
            this.clmnP_LB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnP_LB.DefaultCellStyle = dataGridViewCellStyle9;
            this.clmnP_LB.HeaderText = "P/L $";
            this.clmnP_LB.MinimumWidth = 50;
            this.clmnP_LB.Name = "clmnP_LB";
            this.clmnP_LB.ReadOnly = true;
            this.clmnP_LB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnOrders
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnOrders.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmnOrders.HeaderText = "Orders";
            this.clmnOrders.MinimumWidth = 50;
            this.clmnOrders.Name = "clmnOrders";
            this.clmnOrders.ReadOnly = true;
            this.clmnOrders.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnBidSize
            // 
            this.clmnBidSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnBidSize.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmnBidSize.HeaderText = "Bid Size";
            this.clmnBidSize.MinimumWidth = 50;
            this.clmnBidSize.Name = "clmnBidSize";
            this.clmnBidSize.ReadOnly = true;
            this.clmnBidSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnBidSize.Width = 200;
            // 
            // clmnPrice
            // 
            this.clmnPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnPrice.DefaultCellStyle = dataGridViewCellStyle12;
            this.clmnPrice.HeaderText = "Price";
            this.clmnPrice.MinimumWidth = 50;
            this.clmnPrice.Name = "clmnPrice";
            this.clmnPrice.ReadOnly = true;
            this.clmnPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnPrice.Width = 200;
            // 
            // clmnAskSize
            // 
            this.clmnAskSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnAskSize.DefaultCellStyle = dataGridViewCellStyle13;
            this.clmnAskSize.HeaderText = "Offer Size";
            this.clmnAskSize.MinimumWidth = 50;
            this.clmnAskSize.Name = "clmnAskSize";
            this.clmnAskSize.ReadOnly = true;
            this.clmnAskSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnAskSize.Width = 200;
            // 
            // clmnVolume
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.clmnVolume.DefaultCellStyle = dataGridViewCellStyle14;
            this.clmnVolume.HeaderText = "Volume";
            this.clmnVolume.MaximumValue = ((long)(0));
            this.clmnVolume.MinimumWidth = 150;
            this.clmnVolume.Name = "clmnVolume";
            this.clmnVolume.ReadOnly = true;
            this.clmnVolume.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clmnTimeVolBar
            // 
            this.clmnTimeVolBar.HeaderText = "Time Vol Bar";
            this.clmnTimeVolBar.MaximumValue = ((long)(0));
            this.clmnTimeVolBar.MinimumWidth = 50;
            this.clmnTimeVolBar.Name = "clmnTimeVolBar";
            this.clmnTimeVolBar.ReadOnly = true;
            this.clmnTimeVolBar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnTimeVolBar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clmnVolumeN
            // 
            this.clmnVolumeN.HeaderText = "Vol";
            this.clmnVolumeN.MinimumWidth = 50;
            this.clmnVolumeN.Name = "clmnVolumeN";
            this.clmnVolumeN.ReadOnly = true;
            // 
            // clmnVolumep
            // 
            this.clmnVolumep.HeaderText = "Rel Vol %";
            this.clmnVolumep.MinimumWidth = 50;
            this.clmnVolumep.Name = "clmnVolumep";
            this.clmnVolumep.ReadOnly = true;
            this.clmnVolumep.Visible = false;
            // 
            // clmnBidBar
            // 
            this.clmnBidBar.HeaderText = "Bid";
            this.clmnBidBar.MaximumValue = ((long)(0));
            this.clmnBidBar.MinimumWidth = 50;
            this.clmnBidBar.Name = "clmnBidBar";
            this.clmnBidBar.ReadOnly = true;
            this.clmnBidBar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnBidBar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clmnBid
            // 
            this.clmnBid.HeaderText = "Rel Bar %";
            this.clmnBid.MinimumWidth = 50;
            this.clmnBid.Name = "clmnBid";
            this.clmnBid.ReadOnly = true;
            // 
            // clmnOfferBar
            // 
            this.clmnOfferBar.HeaderText = "Offer";
            this.clmnOfferBar.MaximumValue = ((long)(0));
            this.clmnOfferBar.MinimumWidth = 50;
            this.clmnOfferBar.Name = "clmnOfferBar";
            this.clmnOfferBar.ReadOnly = true;
            this.clmnOfferBar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnOfferBar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clmnOfferP
            // 
            this.clmnOfferP.HeaderText = "Rel Offer %";
            this.clmnOfferP.MinimumWidth = 50;
            this.clmnOfferP.Name = "clmnOfferP";
            this.clmnOfferP.ReadOnly = true;
            // 
            // clmnBuySellbar
            // 
            this.clmnBuySellbar.HeaderText = "Buy/Sell Bar";
            this.clmnBuySellbar.MaximumValue = ((long)(0));
            this.clmnBuySellbar.MinimumWidth = 50;
            this.clmnBuySellbar.Name = "clmnBuySellbar";
            this.clmnBuySellbar.ReadOnly = true;
            this.clmnBuySellbar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnBuySellbar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // nStatusBar1
            // 
            this.nStatusBar1.Location = new System.Drawing.Point(0, 3);
            this.nStatusBar1.Name = "nStatusBar1";
            this.nStatusBar1.Panels.AddRange(new Nevron.UI.WinForm.Controls.NStatusBarPanel[] {
            this.nStatusBarPanel1});
            this.nStatusBar1.ShowPanels = true;
            this.nStatusBar1.Size = new System.Drawing.Size(861, 22);
            this.nStatusBar1.TabIndex = 5;
            // 
            // nStatusBarPanel1
            // 
            this.nStatusBarPanel1.Name = "nStatusBarPanel1";
            this.nStatusBarPanel1.Width = 400;
            // 
            // nTabControl1
            // 
            this.nTabControl1.Controls.Add(this.tabOrderSettings);
            this.nTabControl1.Controls.Add(this.tabManOrder);
            this.nTabControl1.Controls.Add(this.tabAdvancedOrderBar);
            this.nTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nTabControl1.Location = new System.Drawing.Point(0, 0);
            this.nTabControl1.Name = "nTabControl1";
            this.nTabControl1.Padding = new System.Windows.Forms.Padding(4, 29, 4, 4);
            this.nTabControl1.Selectable = true;
            this.nTabControl1.SelectedIndex = 0;
            this.nTabControl1.Size = new System.Drawing.Size(281, 658);
            this.nTabControl1.TabIndex = 1;
            // 
            // tabOrderSettings
            // 
            this.tabOrderSettings.Controls.Add(this.pnlOrderSettings);
            this.tabOrderSettings.Location = new System.Drawing.Point(4, 29);
            this.tabOrderSettings.Name = "tabOrderSettings";
            this.tabOrderSettings.Size = new System.Drawing.Size(273, 625);
            this.tabOrderSettings.TabIndex = 1;
            this.tabOrderSettings.Text = "Order Settings";
            // 
            // pnlOrderSettings
            // 
            this.pnlOrderSettings.AutoScroll = true;
            this.pnlOrderSettings.Controls.Add(this.nGroupBox3);
            this.pnlOrderSettings.Controls.Add(this.nGroupBox2);
            this.pnlOrderSettings.Controls.Add(this.nGroupBox1);
            this.pnlOrderSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlOrderSettings.Name = "pnlOrderSettings";
            this.pnlOrderSettings.Size = new System.Drawing.Size(273, 625);
            this.pnlOrderSettings.TabIndex = 16;
            // 
            // nGroupBox3
            // 
            this.nGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nGroupBox3.Controls.Add(this.btnClose);
            this.nGroupBox3.Controls.Add(this.btnReverse);
            this.nGroupBox3.Controls.Add(this.btnXOfrs);
            this.nGroupBox3.Controls.Add(this.btnCancelAll);
            this.nGroupBox3.Controls.Add(this.btnXBids);
            this.nGroupBox3.Location = new System.Drawing.Point(11, 522);
            this.nGroupBox3.Name = "nGroupBox3";
            this.nGroupBox3.Size = new System.Drawing.Size(259, 101);
            this.nGroupBox3.TabIndex = 27;
            this.nGroupBox3.TabStop = false;
            this.nGroupBox3.Text = "Manage Order(s)/Position";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Location = new System.Drawing.Point(134, 66);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnReverse
            // 
            this.btnReverse.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnReverse.Location = new System.Drawing.Point(5, 66);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(117, 23);
            this.btnReverse.TabIndex = 3;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            // 
            // btnXOfrs
            // 
            this.btnXOfrs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnXOfrs.Location = new System.Drawing.Point(176, 28);
            this.btnXOfrs.Name = "btnXOfrs";
            this.btnXOfrs.Size = new System.Drawing.Size(75, 23);
            this.btnXOfrs.TabIndex = 2;
            this.btnXOfrs.Text = "X Ofrs";
            this.btnXOfrs.UseVisualStyleBackColor = true;
            this.btnXOfrs.Click += new System.EventHandler(this.btnXOfrs_Click);
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelAll.Location = new System.Drawing.Point(93, 28);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Size = new System.Drawing.Size(69, 23);
            this.btnCancelAll.TabIndex = 1;
            this.btnCancelAll.Text = "Cancel All";
            this.btnCancelAll.UseVisualStyleBackColor = true;
            this.btnCancelAll.Click += new System.EventHandler(this.btnCancelAll_Click);
            // 
            // btnXBids
            // 
            this.btnXBids.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnXBids.Location = new System.Drawing.Point(5, 28);
            this.btnXBids.Name = "btnXBids";
            this.btnXBids.Size = new System.Drawing.Size(75, 23);
            this.btnXBids.TabIndex = 0;
            this.btnXBids.Text = "X Bids";
            this.btnXBids.UseVisualStyleBackColor = true;
            this.btnXBids.Click += new System.EventHandler(this.btnXBids_Click);
            // 
            // nGroupBox2
            // 
            this.nGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nGroupBox2.Controls.Add(this.btnOcOpoint);
            this.nGroupBox2.Controls.Add(this.btnBuyMkt);
            this.nGroupBox2.Controls.Add(this.btnBuyTRLOrder);
            this.nGroupBox2.Controls.Add(this.btnSellTRLOrder);
            this.nGroupBox2.Controls.Add(this.comboBox2);
            this.nGroupBox2.Controls.Add(this.btnSellMkt);
            this.nGroupBox2.Controls.Add(this.comboBox1);
            this.nGroupBox2.Controls.Add(this.label1);
            this.nGroupBox2.Controls.Add(this.numericUpDown1);
            this.nGroupBox2.Controls.Add(this.btnOCOOrder);
            this.nGroupBox2.Location = new System.Drawing.Point(11, 357);
            this.nGroupBox2.Name = "nGroupBox2";
            this.nGroupBox2.Size = new System.Drawing.Size(256, 159);
            this.nGroupBox2.TabIndex = 26;
            this.nGroupBox2.TabStop = false;
            this.nGroupBox2.Text = "Place Order";
            // 
            // btnOcOpoint
            // 
            this.btnOcOpoint.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOcOpoint.Location = new System.Drawing.Point(226, 131);
            this.btnOcOpoint.Name = "btnOcOpoint";
            this.btnOcOpoint.Size = new System.Drawing.Size(25, 23);
            this.btnOcOpoint.TabIndex = 25;
            this.btnOcOpoint.Text = "...";
            this.btnOcOpoint.UseVisualStyleBackColor = true;
            // 
            // btnBuyMkt
            // 
            this.btnBuyMkt.Location = new System.Drawing.Point(3, 18);
            this.btnBuyMkt.Name = "btnBuyMkt";
            this.btnBuyMkt.Size = new System.Drawing.Size(119, 23);
            this.btnBuyMkt.TabIndex = 16;
            this.btnBuyMkt.Text = "Buy Mkt";
            this.btnBuyMkt.UseVisualStyleBackColor = true;
            this.btnBuyMkt.Click += new System.EventHandler(this.btnPlaceMarket_Click);
            // 
            // btnBuyTRLOrder
            // 
            this.btnBuyTRLOrder.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBuyTRLOrder.AutoEllipsis = true;
            this.btnBuyTRLOrder.Location = new System.Drawing.Point(3, 47);
            this.btnBuyTRLOrder.Name = "btnBuyTRLOrder";
            this.btnBuyTRLOrder.Size = new System.Drawing.Size(119, 23);
            this.btnBuyTRLOrder.TabIndex = 17;
            this.btnBuyTRLOrder.Text = "Buy Trl Stp";
            this.btnBuyTRLOrder.UseVisualStyleBackColor = true;
            this.btnBuyTRLOrder.Click += new System.EventHandler(this.btnTRLOrder_Click);
            // 
            // btnSellTRLOrder
            // 
            this.btnSellTRLOrder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSellTRLOrder.Location = new System.Drawing.Point(134, 47);
            this.btnSellTRLOrder.Name = "btnSellTRLOrder";
            this.btnSellTRLOrder.Size = new System.Drawing.Size(120, 23);
            this.btnSellTRLOrder.TabIndex = 24;
            this.btnSellTRLOrder.Text = "Sell Trl Stp";
            this.btnSellTRLOrder.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "$",
            "%"});
            this.comboBox2.Location = new System.Drawing.Point(4, 76);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(50, 21);
            this.comboBox2.TabIndex = 18;
            // 
            // btnSellMkt
            // 
            this.btnSellMkt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSellMkt.Location = new System.Drawing.Point(134, 18);
            this.btnSellMkt.Name = "btnSellMkt";
            this.btnSellMkt.Size = new System.Drawing.Size(119, 23);
            this.btnSellMkt.TabIndex = 23;
            this.btnSellMkt.Text = "Sell Mkt";
            this.btnSellMkt.UseVisualStyleBackColor = true;
            this.btnSellMkt.Click += new System.EventHandler(this.btnSellMkt_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 131);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(215, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Amt";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(108, 76);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(143, 20);
            this.numericUpDown1.TabIndex = 20;
            // 
            // btnOCOOrder
            // 
            this.btnOCOOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOCOOrder.Location = new System.Drawing.Point(5, 103);
            this.btnOCOOrder.Name = "btnOCOOrder";
            this.btnOCOOrder.Size = new System.Drawing.Size(246, 23);
            this.btnOCOOrder.TabIndex = 21;
            this.btnOCOOrder.Text = "Place OCO Order";
            this.btnOCOOrder.UseVisualStyleBackColor = true;
            this.btnOCOOrder.Click += new System.EventHandler(this.btnOCOOrder_Click);
            // 
            // nGroupBox1
            // 
            this.nGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nGroupBox1.Controls.Add(this.lblOrderType);
            this.nGroupBox1.Controls.Add(this.lblAccount);
            this.nGroupBox1.Controls.Add(this.cmbxOrderType);
            this.nGroupBox1.Controls.Add(this.cmbxAccount);
            this.nGroupBox1.Controls.Add(this.lblQuantity);
            this.nGroupBox1.Controls.Add(this.btnS);
            this.nGroupBox1.Controls.Add(this.nudQuantity);
            this.nGroupBox1.Controls.Add(this.btnP);
            this.nGroupBox1.Controls.Add(this.rtxtQuantity);
            this.nGroupBox1.Controls.Add(this.lblDuration);
            this.nGroupBox1.Controls.Add(this.cmbxAttachOSO);
            this.nGroupBox1.Controls.Add(this.btn3point);
            this.nGroupBox1.Controls.Add(this.lblRoute);
            this.nGroupBox1.Controls.Add(this.cmbxDuration);
            this.nGroupBox1.Controls.Add(this.lblAttachOSO);
            this.nGroupBox1.Controls.Add(this.cmbxRoute);
            this.nGroupBox1.Location = new System.Drawing.Point(11, 3);
            this.nGroupBox1.Name = "nGroupBox1";
            this.nGroupBox1.Size = new System.Drawing.Size(256, 348);
            this.nGroupBox1.TabIndex = 25;
            this.nGroupBox1.TabStop = false;
            this.nGroupBox1.Text = "Order Setting";
            // 
            // tabManOrder
            // 
            this.tabManOrder.Controls.Add(this.panel3);
            this.tabManOrder.Location = new System.Drawing.Point(4, 29);
            this.tabManOrder.Name = "tabManOrder";
            this.tabManOrder.Size = new System.Drawing.Size(273, 625);
            this.tabManOrder.TabIndex = 4;
            this.tabManOrder.Text = "Manager Order";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.gbManegeOrders_Positions);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 625);
            this.panel3.TabIndex = 5;
            // 
            // gbManegeOrders_Positions
            // 
            this.gbManegeOrders_Positions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbManegeOrders_Positions.Location = new System.Drawing.Point(0, 0);
            this.gbManegeOrders_Positions.Name = "gbManegeOrders_Positions";
            this.gbManegeOrders_Positions.Size = new System.Drawing.Size(273, 625);
            this.gbManegeOrders_Positions.TabIndex = 4;
            this.gbManegeOrders_Positions.TabStop = false;
            this.gbManegeOrders_Positions.Text = "Manage Order(s)/Positions";
            // 
            // tabAdvancedOrderBar
            // 
            this.tabAdvancedOrderBar.Controls.Add(this.pnlRightRight);
            this.tabAdvancedOrderBar.Location = new System.Drawing.Point(4, 29);
            this.tabAdvancedOrderBar.Name = "tabAdvancedOrderBar";
            this.tabAdvancedOrderBar.Size = new System.Drawing.Size(273, 625);
            this.tabAdvancedOrderBar.TabIndex = 2;
            this.tabAdvancedOrderBar.Text = "Advanced Order Bar";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn1.HeaderText = "Symbol";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Bid Tick";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn2.HeaderText = "Position";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 5;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn3.HeaderText = "P/L";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 5;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 5;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn5.HeaderText = "AccountNo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 5;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn6.HeaderText = "P/L";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 5;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn7.HeaderText = "Orders";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn8.HeaderText = "Bid Size";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 65;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn9.HeaderText = "Price";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 64;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn10.HeaderText = "Ask Size";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 65;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn11.HeaderText = "Offer Size";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 59;
            // 
            // dataGridViewBarGraphColumn1
            // 
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewBarGraphColumn1.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewBarGraphColumn1.HeaderText = "Volume";
            this.dataGridViewBarGraphColumn1.MaximumValue = ((long)(0));
            this.dataGridViewBarGraphColumn1.MinimumWidth = 150;
            this.dataGridViewBarGraphColumn1.Name = "dataGridViewBarGraphColumn1";
            this.dataGridViewBarGraphColumn1.ReadOnly = true;
            this.dataGridViewBarGraphColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBarGraphColumn1.Width = 691;
            // 
            // ctlMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "ctlMatrix";
            this.Size = new System.Drawing.Size(1143, 658);
            this.pnlRightRight.ResumeLayout(false);
            this.pnlRightRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceDiscretionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nStatusBarPanel1)).EndInit();
            this.nTabControl1.ResumeLayout(false);
            this.tabOrderSettings.ResumeLayout(false);
            this.pnlOrderSettings.ResumeLayout(false);
            this.nGroupBox3.ResumeLayout(false);
            this.nGroupBox2.ResumeLayout(false);
            this.nGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.nGroupBox1.ResumeLayout(false);
            this.nGroupBox1.PerformLayout();
            this.tabManOrder.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabAdvancedOrderBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MarketDataGrid dgvBottom;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewBarGraphColumn dataGridViewBarGraphColumn1;
        private System.Windows.Forms.Panel pnlRightRight;
        private System.Windows.Forms.CheckBox chkbActivationRule;
        private System.Windows.Forms.CheckBox chkBoxBuy_Sell;
        private System.Windows.Forms.Button btn3PAR;
        private System.Windows.Forms.CheckBox chkboxECNSweep;
        private System.Windows.Forms.CheckBox cnkBoxifTouched;
        private System.Windows.Forms.CheckBox chkBoxNonDisplay;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ComboBox cmbxPegPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblPricePeg;
        private System.Windows.Forms.CheckBox chkBoxShowOnly;
        private System.Windows.Forms.CheckBox chkBoxPeg;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown nudPriceDiscretionary;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Label lblPriceD;
        private System.Windows.Forms.CheckBox chkBoxdiscretionary;
        private System.Windows.Forms.Button btn3point;
        private System.Windows.Forms.ComboBox cmbxAttachOSO;
        private System.Windows.Forms.Label lblAttachOSO;
        private System.Windows.Forms.ComboBox cmbxRoute;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.ComboBox cmbxDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.RichTextBox rtxtQuantity;
        private System.Windows.Forms.Button btnP;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.ComboBox cmbxAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cmbxOrderType;
        private System.Windows.Forms.Label lblOrderType;
        private Nevron.UI.WinForm.Controls.NDataGridView dgvTop;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Nevron.UI.WinForm.Controls.NTabControl nTabControl1;
        private Nevron.UI.WinForm.Controls.NTabPage tabOrderSettings;
        private Nevron.UI.WinForm.Controls.NTabPage tabAdvancedOrderBar;
        private Nevron.UI.WinForm.Controls.NTabPage tabManOrder;
        private System.Windows.Forms.GroupBox gbManegeOrders_Positions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlOrderSettings;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Nevron.UI.WinForm.Controls.NStatusBar nStatusBar1;
        public Nevron.UI.WinForm.Controls.NStatusBarPanel nStatusBarPanel1;
        private System.Windows.Forms.Button btnBuyMkt;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnOCOOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btnBuyTRLOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnSymbol;
        private System.Windows.Forms.DataGridViewImageColumn clmnBidYick;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnP_L;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmnAccountNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnP_LP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnP_LB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnBidSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnAskSize;
        private DataGridViewBarGraphColumn clmnVolume;
        private DataGridViewBarTimeColumn clmnTimeVolBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnVolumeN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnVolumep;
        private DataGridViewBarGraphColumn clmnBidBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnBid;
        private DataGridViewBarGraphColumn clmnOfferBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnOfferP;
        private DataGridViewBarBuySellColumn clmnBuySellbar;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Nevron.UI.WinForm.Controls.NButton btnCollapse;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSellTRLOrder;
        private System.Windows.Forms.Button btnSellMkt;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox1;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox2;
        private System.Windows.Forms.Button btnOcOpoint;
        private Nevron.UI.WinForm.Controls.NGroupBox nGroupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnXOfrs;
        private System.Windows.Forms.Button btnCancelAll;
        private System.Windows.Forms.Button btnXBids;
    }
}
