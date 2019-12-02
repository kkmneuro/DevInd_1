namespace CommonLibrary.UserControls
{
    partial class UctlForexPair
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlForexPair));
            this.ui_nlstAmountList = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_nlstSymbolPairList = new Nevron.UI.WinForm.Controls.NListBox();
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ui_nbtnSymbolPair = new Nevron.UI.WinForm.Controls.NButton();
            this.nTextBox1 = new Nevron.UI.WinForm.Controls.NTextBox();
            this.nListBox1 = new Nevron.UI.WinForm.Controls.NListBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.ui_nddbAmount = new Nevron.UI.WinForm.Controls.NControlDropDownButton();
            this.nSpreadDecorator = new Nevron.UI.WinForm.Controls.NDecorator();
            this.lblSpreadVal = new System.Windows.Forms.Label();
            this.ui_ndctrSell = new Nevron.UI.WinForm.Controls.NDecorator();
            this.picLeftArrow = new System.Windows.Forms.PictureBox();
            this.lblTypeLeft = new System.Windows.Forms.Label();
            this.lblPartialPipsTypeLeft = new System.Windows.Forms.Label();
            this.lblTypeBottomValueLeft = new System.Windows.Forms.Label();
            this.lblTypeTopValueLeft = new System.Windows.Forms.Label();
            this.ui_ndctrBuy = new Nevron.UI.WinForm.Controls.NDecorator();
            this.picRightArrow = new System.Windows.Forms.PictureBox();
            this.lblPartialPipsTypeRight = new System.Windows.Forms.Label();
            this.lblTypeRight = new System.Windows.Forms.Label();
            this.lblTypeTopValueRight = new System.Windows.Forms.Label();
            this.lblTypeBottomValueRight = new System.Windows.Forms.Label();
            this.nBtnOrder = new Nevron.UI.WinForm.Controls.NButton();
            this.btnSell = new Nevron.UI.WinForm.Controls.NDecorator();
            this.btnBuy = new Nevron.UI.WinForm.Controls.NDecorator();
            ((System.ComponentModel.ISupportInitialize)(this.nSpreadDecorator)).BeginInit();
            this.nSpreadDecorator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndctrSell)).BeginInit();
            this.ui_ndctrSell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndctrBuy)).BeginInit();
            this.ui_ndctrBuy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRightArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuy)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_nlstAmountList
            // 
            this.ui_nlstAmountList.ColumnOnLeft = false;
            this.ui_nlstAmountList.FormattingEnabled = true;
            this.ui_nlstAmountList.Location = new System.Drawing.Point(236, 182);
            this.ui_nlstAmountList.Name = "ui_nlstAmountList";
            this.ui_nlstAmountList.Size = new System.Drawing.Size(83, 64);
            this.ui_nlstAmountList.TabIndex = 23;
            this.ui_nlstAmountList.Visible = false;
            this.ui_nlstAmountList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ui_nlstAmountList_MouseClick);
            // 
            // ui_nlstSymbolPairList
            // 
            this.ui_nlstSymbolPairList.ColumnOnLeft = false;
            this.ui_nlstSymbolPairList.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.ui_nlstSymbolPairList.ItemHeight = 13;
            this.ui_nlstSymbolPairList.Location = new System.Drawing.Point(124, 111);
            this.ui_nlstSymbolPairList.Name = "ui_nlstSymbolPairList";
            this.ui_nlstSymbolPairList.ShowFocusRect = true;
            this.ui_nlstSymbolPairList.Size = new System.Drawing.Size(120, 82);
            this.ui_nlstSymbolPairList.Sorted = true;
            this.ui_nlstSymbolPairList.TabIndex = 25;
            this.ui_nlstSymbolPairList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ui_nlstSymbolPairList_MouseClick);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Fuchsia;
            this.ImageList1.Images.SetKeyName(0, "Long.bmp");
            this.ImageList1.Images.SetKeyName(1, "Short.bmp");
            // 
            // ui_nbtnSymbolPair
            // 
            this.ui_nbtnSymbolPair.Location = new System.Drawing.Point(0, 0);
            this.ui_nbtnSymbolPair.Name = "ui_nbtnSymbolPair";
            this.ui_nbtnSymbolPair.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.ui_nbtnSymbolPair.Palette.ControlBorder = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(61)))), ((int)(((byte)(58)))));
            this.ui_nbtnSymbolPair.Size = new System.Drawing.Size(145, 17);
            this.ui_nbtnSymbolPair.TabIndex = 45;
            this.ui_nbtnSymbolPair.Text = "nButton1";
            this.ui_nbtnSymbolPair.UseVisualStyleBackColor = false;
            // 
            // nTextBox1
            // 
            this.nTextBox1.Location = new System.Drawing.Point(18, 111);
            this.nTextBox1.Name = "nTextBox1";
            this.nTextBox1.Size = new System.Drawing.Size(100, 18);
            this.nTextBox1.TabIndex = 44;
            this.nTextBox1.Text = "nTextBox1";
            this.nTextBox1.Visible = false;
            // 
            // nListBox1
            // 
            this.nListBox1.ColumnOnLeft = false;
            this.nListBox1.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.nListBox1.ItemHeight = 13;
            this.nListBox1.Location = new System.Drawing.Point(124, 111);
            this.nListBox1.Name = "nListBox1";
            this.nListBox1.ShowFocusRect = true;
            this.nListBox1.Size = new System.Drawing.Size(120, 82);
            this.nListBox1.Sorted = true;
            this.nListBox1.TabIndex = 43;
            this.nListBox1.Visible = false;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.White;
            this.lblAmount.Location = new System.Drawing.Point(9, 73);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(46, 13);
            this.lblAmount.TabIndex = 42;
            this.lblAmount.Text = "Quantity";
            // 
            // ui_nddbAmount
            // 
            this.ui_nddbAmount.ArrowWidth = 14;
            this.ui_nddbAmount.DialogResult = System.Windows.Forms.DialogResult.No;
            this.ui_nddbAmount.DropDownControl = this.ui_nlstAmountList;
            this.ui_nddbAmount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.ui_nddbAmount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ui_nddbAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_nddbAmount.Location = new System.Drawing.Point(58, 75);
            this.ui_nddbAmount.Name = "ui_nddbAmount";
            this.ui_nddbAmount.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.ui_nddbAmount.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(220)))), ((int)(((byte)(109)))));
            this.ui_nddbAmount.Palette.ControlBorder = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(113)))), ((int)(((byte)(235)))));
            this.ui_nddbAmount.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(198)))), ((int)(((byte)(199)))));
            this.ui_nddbAmount.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ui_nddbAmount.Size = new System.Drawing.Size(69, 13);
            this.ui_nddbAmount.TabIndex = 41;
            this.ui_nddbAmount.Text = "select";
            this.ui_nddbAmount.UseVisualStyleBackColor = true;
            // 
            // nSpreadDecorator
            // 
            this.nSpreadDecorator.Controls.Add(this.lblSpreadVal);
            this.nSpreadDecorator.Location = new System.Drawing.Point(53, 17);
            this.nSpreadDecorator.Name = "nSpreadDecorator";
            this.nSpreadDecorator.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.nSpreadDecorator.Palette.Control = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(231)))), ((int)(((byte)(207)))));
            this.nSpreadDecorator.Palette.ControlBorder = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(61)))), ((int)(((byte)(58)))));
            this.nSpreadDecorator.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.nSpreadDecorator.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nSpreadDecorator.Size = new System.Drawing.Size(22, 15);
            this.nSpreadDecorator.StrokeInfo.Rounding = 50;
            this.nSpreadDecorator.StrokeInfo.RoundingEdges = ((Nevron.UI.RoundingEdges)((Nevron.UI.RoundingEdges.BottomLeft | Nevron.UI.RoundingEdges.BottomRight)));
            this.nSpreadDecorator.TabIndex = 40;
            this.nSpreadDecorator.Text = "nDecorator5";
            // 
            // lblSpreadVal
            // 
            this.lblSpreadVal.AutoSize = true;
            this.lblSpreadVal.BackColor = System.Drawing.Color.Transparent;
            this.lblSpreadVal.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpreadVal.ForeColor = System.Drawing.Color.Black;
            this.lblSpreadVal.Location = new System.Drawing.Point(4, 0);
            this.lblSpreadVal.Name = "lblSpreadVal";
            this.lblSpreadVal.Size = new System.Drawing.Size(15, 12);
            this.lblSpreadVal.TabIndex = 35;
            this.lblSpreadVal.Text = "00";
            this.lblSpreadVal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ui_ndctrSell
            // 
            this.ui_ndctrSell.BackColor = System.Drawing.Color.Transparent;
            this.ui_ndctrSell.Controls.Add(this.picLeftArrow);
            this.ui_ndctrSell.Controls.Add(this.lblTypeLeft);
            this.ui_ndctrSell.Controls.Add(this.lblPartialPipsTypeLeft);
            this.ui_ndctrSell.Controls.Add(this.lblTypeBottomValueLeft);
            this.ui_ndctrSell.Controls.Add(this.lblTypeTopValueLeft);
            this.ui_ndctrSell.Location = new System.Drawing.Point(0, 25);
            this.ui_ndctrSell.Name = "ui_ndctrSell";
            this.ui_ndctrSell.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.ui_ndctrSell.Palette.ControlBorder = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(61)))), ((int)(((byte)(58)))));
            this.ui_ndctrSell.Size = new System.Drawing.Size(60, 46);
            this.ui_ndctrSell.StrokeInfo.Rounding = 50;
            this.ui_ndctrSell.StrokeInfo.RoundingEdges = Nevron.UI.RoundingEdges.TopRight;
            this.ui_ndctrSell.TabIndex = 39;
            this.ui_ndctrSell.Text = "nDecorator4";
            this.ui_ndctrSell.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndctrSell_MouseDown);
            // 
            // picLeftArrow
            // 
            this.picLeftArrow.BackColor = System.Drawing.Color.Transparent;
            this.picLeftArrow.Location = new System.Drawing.Point(52, 21);
            this.picLeftArrow.Name = "picLeftArrow";
            this.picLeftArrow.Size = new System.Drawing.Size(7, 16);
            this.picLeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeftArrow.TabIndex = 33;
            this.picLeftArrow.TabStop = false;
            this.picLeftArrow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndctrSell_MouseDown);
            // 
            // lblTypeLeft
            // 
            this.lblTypeLeft.AutoSize = true;
            this.lblTypeLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeLeft.ForeColor = System.Drawing.Color.Black;
            this.lblTypeLeft.Location = new System.Drawing.Point(16, 1);
            this.lblTypeLeft.Margin = new System.Windows.Forms.Padding(0);
            this.lblTypeLeft.Name = "lblTypeLeft";
            this.lblTypeLeft.Size = new System.Drawing.Size(27, 12);
            this.lblTypeLeft.TabIndex = 1;
            this.lblTypeLeft.Text = "SELL";
            this.lblTypeLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndctrSell_MouseDown);
            // 
            // lblPartialPipsTypeLeft
            // 
            this.lblPartialPipsTypeLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblPartialPipsTypeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartialPipsTypeLeft.ForeColor = System.Drawing.Color.Black;
            this.lblPartialPipsTypeLeft.Location = new System.Drawing.Point(41, 28);
            this.lblPartialPipsTypeLeft.Name = "lblPartialPipsTypeLeft";
            this.lblPartialPipsTypeLeft.Size = new System.Drawing.Size(8, 9);
            this.lblPartialPipsTypeLeft.TabIndex = 32;
            this.lblPartialPipsTypeLeft.Text = "0";
            this.lblPartialPipsTypeLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPartialPipsTypeLeft.Visible = false;
            this.lblPartialPipsTypeLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndctrSell_MouseDown);
            // 
            // lblTypeBottomValueLeft
            // 
            this.lblTypeBottomValueLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeBottomValueLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeBottomValueLeft.ForeColor = System.Drawing.Color.Black;
            this.lblTypeBottomValueLeft.Location = new System.Drawing.Point(1, 25);
            this.lblTypeBottomValueLeft.Name = "lblTypeBottomValueLeft";
            this.lblTypeBottomValueLeft.Size = new System.Drawing.Size(52, 19);
            this.lblTypeBottomValueLeft.TabIndex = 31;
            this.lblTypeBottomValueLeft.Text = "00";
            this.lblTypeBottomValueLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTypeBottomValueLeft.Click += new System.EventHandler(this.lblTypeBottomValueLeft_Click);
            this.lblTypeBottomValueLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndctrSell_MouseDown);
            // 
            // lblTypeTopValueLeft
            // 
            this.lblTypeTopValueLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeTopValueLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeTopValueLeft.ForeColor = System.Drawing.Color.Black;
            this.lblTypeTopValueLeft.Location = new System.Drawing.Point(2, 15);
            this.lblTypeTopValueLeft.Name = "lblTypeTopValueLeft";
            this.lblTypeTopValueLeft.Size = new System.Drawing.Size(30, 10);
            this.lblTypeTopValueLeft.TabIndex = 30;
            this.lblTypeTopValueLeft.Text = "0.00";
            this.lblTypeTopValueLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTypeTopValueLeft.Visible = false;
            this.lblTypeTopValueLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndctrSell_MouseDown);
            // 
            // ui_ndctrBuy
            // 
            this.ui_ndctrBuy.BackColor = System.Drawing.Color.Transparent;
            this.ui_ndctrBuy.Controls.Add(this.picRightArrow);
            this.ui_ndctrBuy.Controls.Add(this.lblPartialPipsTypeRight);
            this.ui_ndctrBuy.Controls.Add(this.lblTypeRight);
            this.ui_ndctrBuy.Controls.Add(this.lblTypeTopValueRight);
            this.ui_ndctrBuy.Controls.Add(this.lblTypeBottomValueRight);
            this.ui_ndctrBuy.Location = new System.Drawing.Point(67, 25);
            this.ui_ndctrBuy.Name = "ui_ndctrBuy";
            this.ui_ndctrBuy.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.ui_ndctrBuy.Palette.ControlBorder = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(61)))), ((int)(((byte)(58)))));
            this.ui_ndctrBuy.Size = new System.Drawing.Size(60, 46);
            this.ui_ndctrBuy.StrokeInfo.Rounding = 50;
            this.ui_ndctrBuy.StrokeInfo.RoundingEdges = Nevron.UI.RoundingEdges.TopLeft;
            this.ui_ndctrBuy.TabIndex = 38;
            this.ui_ndctrBuy.Text = "nDecorator3";
            this.ui_ndctrBuy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_ndctrBuy_MouseDown);
            // 
            // picRightArrow
            // 
            this.picRightArrow.BackColor = System.Drawing.Color.Transparent;
            this.picRightArrow.Location = new System.Drawing.Point(4, 21);
            this.picRightArrow.Name = "picRightArrow";
            this.picRightArrow.Size = new System.Drawing.Size(7, 16);
            this.picRightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRightArrow.TabIndex = 34;
            this.picRightArrow.TabStop = false;
            // 
            // lblPartialPipsTypeRight
            // 
            this.lblPartialPipsTypeRight.BackColor = System.Drawing.Color.Transparent;
            this.lblPartialPipsTypeRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartialPipsTypeRight.ForeColor = System.Drawing.Color.Black;
            this.lblPartialPipsTypeRight.Location = new System.Drawing.Point(34, 28);
            this.lblPartialPipsTypeRight.Name = "lblPartialPipsTypeRight";
            this.lblPartialPipsTypeRight.Size = new System.Drawing.Size(8, 9);
            this.lblPartialPipsTypeRight.TabIndex = 33;
            this.lblPartialPipsTypeRight.Text = "0";
            this.lblPartialPipsTypeRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPartialPipsTypeRight.Visible = false;
            // 
            // lblTypeRight
            // 
            this.lblTypeRight.AutoSize = true;
            this.lblTypeRight.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeRight.ForeColor = System.Drawing.Color.Black;
            this.lblTypeRight.Location = new System.Drawing.Point(20, 1);
            this.lblTypeRight.Margin = new System.Windows.Forms.Padding(0);
            this.lblTypeRight.Name = "lblTypeRight";
            this.lblTypeRight.Size = new System.Drawing.Size(23, 12);
            this.lblTypeRight.TabIndex = 0;
            this.lblTypeRight.Text = "BUY";
            // 
            // lblTypeTopValueRight
            // 
            this.lblTypeTopValueRight.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeTopValueRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeTopValueRight.ForeColor = System.Drawing.Color.Black;
            this.lblTypeTopValueRight.Location = new System.Drawing.Point(29, 15);
            this.lblTypeTopValueRight.Name = "lblTypeTopValueRight";
            this.lblTypeTopValueRight.Size = new System.Drawing.Size(29, 10);
            this.lblTypeTopValueRight.TabIndex = 31;
            this.lblTypeTopValueRight.Text = "0.00";
            this.lblTypeTopValueRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTypeTopValueRight.Visible = false;
            // 
            // lblTypeBottomValueRight
            // 
            this.lblTypeBottomValueRight.BackColor = System.Drawing.Color.Transparent;
            this.lblTypeBottomValueRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeBottomValueRight.ForeColor = System.Drawing.Color.Black;
            this.lblTypeBottomValueRight.Location = new System.Drawing.Point(13, 25);
            this.lblTypeBottomValueRight.Name = "lblTypeBottomValueRight";
            this.lblTypeBottomValueRight.Size = new System.Drawing.Size(47, 18);
            this.lblTypeBottomValueRight.TabIndex = 32;
            this.lblTypeBottomValueRight.Text = "00";
            this.lblTypeBottomValueRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nBtnOrder
            // 
            this.nBtnOrder.ButtonProperties.WrapText = true;
            this.nBtnOrder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.nBtnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nBtnOrder.Location = new System.Drawing.Point(127, 17);
            this.nBtnOrder.Name = "nBtnOrder";
            this.nBtnOrder.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.VistaPlus;
            this.nBtnOrder.Palette.ControlBorder = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(61)))), ((int)(((byte)(58)))));
            this.nBtnOrder.Size = new System.Drawing.Size(18, 73);
            this.nBtnOrder.TabIndex = 37;
            this.nBtnOrder.Text = "ORDER";
            this.nBtnOrder.UseVisualStyleBackColor = false;
            this.nBtnOrder.Click += new System.EventHandler(this.nBtnOrder_Click);
            // 
            // btnSell
            // 
            this.btnSell.FillInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(213)))), ((int)(((byte)(96)))));
            this.btnSell.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(0)))));
            this.btnSell.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSell.FillInfo.HatchStyle = System.Drawing.Drawing2D.HatchStyle.ZigZag;
            this.btnSell.Location = new System.Drawing.Point(3, 17);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(32, 7);
            this.btnSell.StrokeInfo.Rounding = 50;
            this.btnSell.TabIndex = 36;
            // 
            // btnBuy
            // 
            this.btnBuy.FillInfo.Color = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(213)))), ((int)(((byte)(96)))));
            this.btnBuy.FillInfo.Gradient1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnBuy.FillInfo.Gradient2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(204)))));
            this.btnBuy.FillInfo.HatchStyle = System.Drawing.Drawing2D.HatchStyle.SolidDiamond;
            this.btnBuy.Location = new System.Drawing.Point(90, 17);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(32, 7);
            this.btnBuy.StrokeInfo.Rounding = 50;
            this.btnBuy.TabIndex = 35;
            this.btnBuy.Text = "nDecorator1";
            // 
            // UctlForexPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.Controls.Add(this.ui_nbtnSymbolPair);
            this.Controls.Add(this.nTextBox1);
            this.Controls.Add(this.nListBox1);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.ui_nddbAmount);
            this.Controls.Add(this.nSpreadDecorator);
            this.Controls.Add(this.ui_ndctrSell);
            this.Controls.Add(this.ui_ndctrBuy);
            this.Controls.Add(this.nBtnOrder);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnBuy);
            this.Name = "UctlForexPair";
            this.Size = new System.Drawing.Size(145, 91);
            this.Load += new System.EventHandler(this.ctlForexPair_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nSpreadDecorator)).EndInit();
            this.nSpreadDecorator.ResumeLayout(false);
            this.nSpreadDecorator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndctrSell)).EndInit();
            this.ui_ndctrSell.ResumeLayout(false);
            this.ui_ndctrSell.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ui_ndctrBuy)).EndInit();
            this.ui_ndctrBuy.ResumeLayout(false);
            this.ui_ndctrBuy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRightArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Nevron.UI.WinForm.Controls.NListBox ui_nlstSymbolPairList;
        internal System.Windows.Forms.ImageList ImageList1;
        private System.Windows.Forms.Label lblAmount;
        internal System.Windows.Forms.Label lblSpreadVal;
        internal System.Windows.Forms.Label lblPartialPipsTypeLeft;
        internal System.Windows.Forms.Label lblTypeBottomValueLeft;
        internal System.Windows.Forms.Label lblTypeTopValueLeft;
        internal System.Windows.Forms.Label lblPartialPipsTypeRight;
        internal System.Windows.Forms.Label lblTypeTopValueRight;
        internal System.Windows.Forms.Label lblTypeBottomValueRight;
        internal Nevron.UI.WinForm.Controls.NDecorator ui_ndctrSell;
        internal Nevron.UI.WinForm.Controls.NDecorator ui_ndctrBuy;
        internal System.Windows.Forms.Label lblTypeLeft;
        internal System.Windows.Forms.Label lblTypeRight;
        internal Nevron.UI.WinForm.Controls.NButton nBtnOrder;
        internal Nevron.UI.WinForm.Controls.NDecorator btnSell;
        internal Nevron.UI.WinForm.Controls.NDecorator btnBuy;
        public Nevron.UI.WinForm.Controls.NListBox ui_nlstAmountList;
        public Nevron.UI.WinForm.Controls.NControlDropDownButton ui_nddbAmount;
        public Nevron.UI.WinForm.Controls.NDecorator nSpreadDecorator;
        private Nevron.UI.WinForm.Controls.NTextBox nTextBox1;
        private Nevron.UI.WinForm.Controls.NListBox nListBox1;
        private System.Windows.Forms.PictureBox picLeftArrow;
        private System.Windows.Forms.PictureBox picRightArrow;
        private Nevron.UI.WinForm.Controls.NButton ui_nbtnSymbolPair;

    }
}
