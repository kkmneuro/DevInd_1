using CommonLibrary.UserControls;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    partial class UctlMarketPicture
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctlMarketPicture));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_npnlMarketPictureControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_ncmbProduct = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_pbMarketTrend = new System.Windows.Forms.PictureBox();
            this.ui_lblRightNumericValue = new System.Windows.Forms.Label();
            this.ui_lblLTTValue = new System.Windows.Forms.Label();
            this.ui_lblLUTValue = new System.Windows.Forms.Label();
            this.ui_lblLeftNumericValue = new System.Windows.Forms.Label();
            this.ui_lblLTT = new System.Windows.Forms.Label();
            this.ui_lblLUT = new System.Windows.Forms.Label();
            this.ui_lblDPRValue = new System.Windows.Forms.Label();
            this.ui_lblOpenValue = new System.Windows.Forms.Label();
            this.ui_lblLifeTimeLowValue = new System.Windows.Forms.Label();
            this.ui_lblLifeTimeHighValue = new System.Windows.Forms.Label();
            this.ui_lblCloseValue = new System.Windows.Forms.Label();
            this.ui_lblLowValue = new System.Windows.Forms.Label();
            this.ui_lblHighValue = new System.Windows.Forms.Label();
            this.ui_lblDPR = new System.Windows.Forms.Label();
            this.ui_lblOpen = new System.Windows.Forms.Label();
            this.ui_lblLifeTimeLow = new System.Windows.Forms.Label();
            this.ui_lblLifeTimeHigh = new System.Windows.Forms.Label();
            this.ui_lblClose = new System.Windows.Forms.Label();
            this.ui_lblLow = new System.Windows.Forms.Label();
            this.ui_lblHigh = new System.Windows.Forms.Label();
            this.ui_lblOIValue = new System.Windows.Forms.Label();
            this.ui_lblLTPValue = new System.Windows.Forms.Label();
            this.ui_lblChangePercentageValue = new System.Windows.Forms.Label();
            this.ui_lblATPValue = new System.Windows.Forms.Label();
            this.ui_lblValueLabelValue = new System.Windows.Forms.Label();
            this.ui_lblVolumeValue = new System.Windows.Forms.Label();
            this.ui_lblLTQValue = new System.Windows.Forms.Label();
            this.ui_lblOI = new System.Windows.Forms.Label();
            this.ui_lblLTP = new System.Windows.Forms.Label();
            this.ui_lblPercentagechange = new System.Windows.Forms.Label();
            this.ui_lblATP = new System.Windows.Forms.Label();
            this.ui_lblValue = new System.Windows.Forms.Label();
            this.ui_lblVolume = new System.Windows.Forms.Label();
            this.ui_lblLTQ = new System.Windows.Forms.Label();
            this.ui_uctlGridRight = new CommonLibrary.UserControls.UctlGrid();
            this.ui_uctlGridLeft = new CommonLibrary.UserControls.UctlGrid();
            this.ui_ncmbProductType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbOptType = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbSeries = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbStrikePrice = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_ncmbExpiryDate = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblProductType = new System.Windows.Forms.Label();
            this.ui_lblOptType = new System.Windows.Forms.Label();
            this.ui_lblStrikePrice = new System.Windows.Forms.Label();
            this.ui_lblEpiryDate = new System.Windows.Forms.Label();
            this.ui_lblSeries = new System.Windows.Forms.Label();
            this.ui_lblProduct = new System.Windows.Forms.Label();
            this.ui_npnlMarketPictureControlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_pbMarketTrend)).BeginInit();
            this.SuspendLayout();
            // 
            // ui_npnlMarketPictureControlContainer
            // 
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_ncmbProduct);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_pbMarketTrend);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblRightNumericValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLTTValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLUTValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLeftNumericValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLTT);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLUT);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblDPRValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblOpenValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLifeTimeLowValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLifeTimeHighValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblCloseValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLowValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblHighValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblDPR);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblOpen);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLifeTimeLow);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLifeTimeHigh);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblClose);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLow);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblHigh);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblOIValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLTPValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblChangePercentageValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblATPValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblValueLabelValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblVolumeValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLTQValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblOI);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLTP);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblPercentagechange);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblATP);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblValue);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblVolume);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblLTQ);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_uctlGridRight);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_uctlGridLeft);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_ncmbProductType);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_ncmbOptType);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_ncmbSeries);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_ncmbStrikePrice);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_ncmbExpiryDate);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblProductType);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblOptType);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblStrikePrice);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblEpiryDate);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblSeries);
            this.ui_npnlMarketPictureControlContainer.Controls.Add(this.ui_lblProduct);
            this.ui_npnlMarketPictureControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlMarketPictureControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlMarketPictureControlContainer.Name = "ui_npnlMarketPictureControlContainer";
            this.ui_npnlMarketPictureControlContainer.Size = new System.Drawing.Size(738, 197);
            this.ui_npnlMarketPictureControlContainer.TabIndex = 0;
            this.ui_npnlMarketPictureControlContainer.Text = "MarketPictureControlContainer";
            // 
            // ui_ncmbProduct
            // 
            this.ui_ncmbProduct.Editable = true;
            this.ui_ncmbProduct.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("--SELECT--", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbProduct.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProduct.Location = new System.Drawing.Point(102, 24);
            this.ui_ncmbProduct.Name = "ui_ncmbProduct";
            this.ui_ncmbProduct.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbProduct.TabIndex = 76;
            this.ui_ncmbProduct.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbProduct_SelectedIndexChanged);
            this.ui_ncmbProduct.TextChanged += new System.EventHandler(this.ui_ncmbProduct_TextChanged);
            // 
            // ui_pbMarketTrend
            // 
            this.ui_pbMarketTrend.BackColor = System.Drawing.Color.Transparent;
            this.ui_pbMarketTrend.Location = new System.Drawing.Point(587, 3);
            this.ui_pbMarketTrend.Name = "ui_pbMarketTrend";
            this.ui_pbMarketTrend.Size = new System.Drawing.Size(41, 35);
            this.ui_pbMarketTrend.TabIndex = 75;
            this.ui_pbMarketTrend.TabStop = false;
            // 
            // ui_lblRightNumericValue
            // 
            this.ui_lblRightNumericValue.AutoSize = true;
            this.ui_lblRightNumericValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblRightNumericValue.Location = new System.Drawing.Point(461, 150);
            this.ui_lblRightNumericValue.Name = "ui_lblRightNumericValue";
            this.ui_lblRightNumericValue.Size = new System.Drawing.Size(13, 13);
            this.ui_lblRightNumericValue.TabIndex = 74;
            this.ui_lblRightNumericValue.Text = "0";
            this.ui_lblRightNumericValue.Visible = false;
            // 
            // ui_lblLTTValue
            // 
            this.ui_lblLTTValue.AutoSize = true;
            this.ui_lblLTTValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLTTValue.Location = new System.Drawing.Point(239, 171);
            this.ui_lblLTTValue.Name = "ui_lblLTTValue";
            this.ui_lblLTTValue.Size = new System.Drawing.Size(47, 13);
            this.ui_lblLTTValue.TabIndex = 73;
            this.ui_lblLTTValue.Text = "date&time";
            this.ui_lblLTTValue.Visible = false;
            // 
            // ui_lblLUTValue
            // 
            this.ui_lblLUTValue.AutoSize = true;
            this.ui_lblLUTValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLUTValue.Location = new System.Drawing.Point(239, 150);
            this.ui_lblLUTValue.Name = "ui_lblLUTValue";
            this.ui_lblLUTValue.Size = new System.Drawing.Size(47, 13);
            this.ui_lblLUTValue.TabIndex = 72;
            this.ui_lblLUTValue.Text = "date&time";
            this.ui_lblLUTValue.Visible = false;
            // 
            // ui_lblLeftNumericValue
            // 
            this.ui_lblLeftNumericValue.AutoSize = true;
            this.ui_lblLeftNumericValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLeftNumericValue.Location = new System.Drawing.Point(7, 150);
            this.ui_lblLeftNumericValue.Name = "ui_lblLeftNumericValue";
            this.ui_lblLeftNumericValue.Size = new System.Drawing.Size(13, 13);
            this.ui_lblLeftNumericValue.TabIndex = 70;
            this.ui_lblLeftNumericValue.Text = "0";
            this.ui_lblLeftNumericValue.Visible = false;
            // 
            // ui_lblLTT
            // 
            this.ui_lblLTT.AutoSize = true;
            this.ui_lblLTT.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLTT.Location = new System.Drawing.Point(119, 171);
            this.ui_lblLTT.Name = "ui_lblLTT";
            this.ui_lblLTT.Size = new System.Drawing.Size(36, 13);
            this.ui_lblLTT.TabIndex = 69;
            this.ui_lblLTT.Text = "LTT : ";
            this.ui_lblLTT.Visible = false;
            // 
            // ui_lblLUT
            // 
            this.ui_lblLUT.AutoSize = true;
            this.ui_lblLUT.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLUT.Location = new System.Drawing.Point(119, 150);
            this.ui_lblLUT.Name = "ui_lblLUT";
            this.ui_lblLUT.Size = new System.Drawing.Size(37, 13);
            this.ui_lblLUT.TabIndex = 68;
            this.ui_lblLUT.Text = "LUT : ";
            this.ui_lblLUT.Visible = false;
            // 
            // ui_lblDPRValue
            // 
            this.ui_lblDPRValue.AutoSize = true;
            this.ui_lblDPRValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDPRValue.Location = new System.Drawing.Point(683, 171);
            this.ui_lblDPRValue.Name = "ui_lblDPRValue";
            this.ui_lblDPRValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblDPRValue.TabIndex = 67;
            this.ui_lblDPRValue.Text = "00.00";
            this.ui_lblDPRValue.Visible = false;
            // 
            // ui_lblOpenValue
            // 
            this.ui_lblOpenValue.AutoSize = true;
            this.ui_lblOpenValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOpenValue.Location = new System.Drawing.Point(683, 45);
            this.ui_lblOpenValue.Name = "ui_lblOpenValue";
            this.ui_lblOpenValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblOpenValue.TabIndex = 66;
            this.ui_lblOpenValue.Text = "00.00";
            // 
            // ui_lblLifeTimeLowValue
            // 
            this.ui_lblLifeTimeLowValue.AutoSize = true;
            this.ui_lblLifeTimeLowValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLifeTimeLowValue.Location = new System.Drawing.Point(683, 150);
            this.ui_lblLifeTimeLowValue.Name = "ui_lblLifeTimeLowValue";
            this.ui_lblLifeTimeLowValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblLifeTimeLowValue.TabIndex = 65;
            this.ui_lblLifeTimeLowValue.Text = "00.00";
            this.ui_lblLifeTimeLowValue.Visible = false;
            // 
            // ui_lblLifeTimeHighValue
            // 
            this.ui_lblLifeTimeHighValue.AutoSize = true;
            this.ui_lblLifeTimeHighValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLifeTimeHighValue.Location = new System.Drawing.Point(683, 129);
            this.ui_lblLifeTimeHighValue.Name = "ui_lblLifeTimeHighValue";
            this.ui_lblLifeTimeHighValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblLifeTimeHighValue.TabIndex = 64;
            this.ui_lblLifeTimeHighValue.Text = "00.00";
            this.ui_lblLifeTimeHighValue.Visible = false;
            // 
            // ui_lblCloseValue
            // 
            this.ui_lblCloseValue.AutoSize = true;
            this.ui_lblCloseValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblCloseValue.Location = new System.Drawing.Point(683, 108);
            this.ui_lblCloseValue.Name = "ui_lblCloseValue";
            this.ui_lblCloseValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblCloseValue.TabIndex = 63;
            this.ui_lblCloseValue.Text = "00.00";
            // 
            // ui_lblLowValue
            // 
            this.ui_lblLowValue.AutoSize = true;
            this.ui_lblLowValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLowValue.Location = new System.Drawing.Point(683, 87);
            this.ui_lblLowValue.Name = "ui_lblLowValue";
            this.ui_lblLowValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblLowValue.TabIndex = 62;
            this.ui_lblLowValue.Text = "00.00";
            // 
            // ui_lblHighValue
            // 
            this.ui_lblHighValue.AutoSize = true;
            this.ui_lblHighValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblHighValue.Location = new System.Drawing.Point(683, 66);
            this.ui_lblHighValue.Name = "ui_lblHighValue";
            this.ui_lblHighValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblHighValue.TabIndex = 61;
            this.ui_lblHighValue.Text = "00.00";
            // 
            // ui_lblDPR
            // 
            this.ui_lblDPR.AutoSize = true;
            this.ui_lblDPR.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblDPR.Location = new System.Drawing.Point(600, 171);
            this.ui_lblDPR.Name = "ui_lblDPR";
            this.ui_lblDPR.Size = new System.Drawing.Size(39, 13);
            this.ui_lblDPR.TabIndex = 60;
            this.ui_lblDPR.Text = "DPR : ";
            this.ui_lblDPR.Visible = false;
            // 
            // ui_lblOpen
            // 
            this.ui_lblOpen.AutoSize = true;
            this.ui_lblOpen.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOpen.Location = new System.Drawing.Point(600, 45);
            this.ui_lblOpen.Name = "ui_lblOpen";
            this.ui_lblOpen.Size = new System.Drawing.Size(42, 13);
            this.ui_lblOpen.TabIndex = 59;
            this.ui_lblOpen.Text = "Open : ";
            // 
            // ui_lblLifeTimeLow
            // 
            this.ui_lblLifeTimeLow.AutoSize = true;
            this.ui_lblLifeTimeLow.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLifeTimeLow.Location = new System.Drawing.Point(600, 150);
            this.ui_lblLifeTimeLow.Name = "ui_lblLifeTimeLow";
            this.ui_lblLifeTimeLow.Size = new System.Drawing.Size(82, 13);
            this.ui_lblLifeTimeLow.TabIndex = 58;
            this.ui_lblLifeTimeLow.Text = "Life Time Low : ";
            this.ui_lblLifeTimeLow.Visible = false;
            // 
            // ui_lblLifeTimeHigh
            // 
            this.ui_lblLifeTimeHigh.AutoSize = true;
            this.ui_lblLifeTimeHigh.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLifeTimeHigh.Location = new System.Drawing.Point(600, 129);
            this.ui_lblLifeTimeHigh.Name = "ui_lblLifeTimeHigh";
            this.ui_lblLifeTimeHigh.Size = new System.Drawing.Size(84, 13);
            this.ui_lblLifeTimeHigh.TabIndex = 57;
            this.ui_lblLifeTimeHigh.Text = "Life Time High : ";
            this.ui_lblLifeTimeHigh.Visible = false;
            // 
            // ui_lblClose
            // 
            this.ui_lblClose.AutoSize = true;
            this.ui_lblClose.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblClose.Location = new System.Drawing.Point(600, 108);
            this.ui_lblClose.Name = "ui_lblClose";
            this.ui_lblClose.Size = new System.Drawing.Size(42, 13);
            this.ui_lblClose.TabIndex = 56;
            this.ui_lblClose.Text = "Close : ";
            // 
            // ui_lblLow
            // 
            this.ui_lblLow.AutoSize = true;
            this.ui_lblLow.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLow.Location = new System.Drawing.Point(600, 87);
            this.ui_lblLow.Name = "ui_lblLow";
            this.ui_lblLow.Size = new System.Drawing.Size(36, 13);
            this.ui_lblLow.TabIndex = 55;
            this.ui_lblLow.Text = "Low : ";
            // 
            // ui_lblHigh
            // 
            this.ui_lblHigh.AutoSize = true;
            this.ui_lblHigh.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblHigh.Location = new System.Drawing.Point(600, 66);
            this.ui_lblHigh.Name = "ui_lblHigh";
            this.ui_lblHigh.Size = new System.Drawing.Size(38, 13);
            this.ui_lblHigh.TabIndex = 54;
            this.ui_lblHigh.Text = "High : ";
            // 
            // ui_lblOIValue
            // 
            this.ui_lblOIValue.AutoSize = true;
            this.ui_lblOIValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOIValue.Location = new System.Drawing.Point(573, 171);
            this.ui_lblOIValue.Name = "ui_lblOIValue";
            this.ui_lblOIValue.Size = new System.Drawing.Size(19, 13);
            this.ui_lblOIValue.TabIndex = 46;
            this.ui_lblOIValue.Text = "00";
            this.ui_lblOIValue.Visible = false;
            // 
            // ui_lblLTPValue
            // 
            this.ui_lblLTPValue.AutoSize = true;
            this.ui_lblLTPValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLTPValue.Location = new System.Drawing.Point(558, 45);
            this.ui_lblLTPValue.Name = "ui_lblLTPValue";
            this.ui_lblLTPValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblLTPValue.TabIndex = 45;
            this.ui_lblLTPValue.Text = "00.00";
            this.ui_lblLTPValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ui_lblChangePercentageValue
            // 
            this.ui_lblChangePercentageValue.AutoSize = true;
            this.ui_lblChangePercentageValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblChangePercentageValue.Location = new System.Drawing.Point(558, 150);
            this.ui_lblChangePercentageValue.Name = "ui_lblChangePercentageValue";
            this.ui_lblChangePercentageValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblChangePercentageValue.TabIndex = 44;
            this.ui_lblChangePercentageValue.Text = "00.00";
            this.ui_lblChangePercentageValue.Visible = false;
            // 
            // ui_lblATPValue
            // 
            this.ui_lblATPValue.AutoSize = true;
            this.ui_lblATPValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblATPValue.Location = new System.Drawing.Point(558, 129);
            this.ui_lblATPValue.Name = "ui_lblATPValue";
            this.ui_lblATPValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblATPValue.TabIndex = 43;
            this.ui_lblATPValue.Text = "00.00";
            this.ui_lblATPValue.Visible = false;
            // 
            // ui_lblValueLabelValue
            // 
            this.ui_lblValueLabelValue.AutoSize = true;
            this.ui_lblValueLabelValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblValueLabelValue.Location = new System.Drawing.Point(558, 108);
            this.ui_lblValueLabelValue.Name = "ui_lblValueLabelValue";
            this.ui_lblValueLabelValue.Size = new System.Drawing.Size(34, 13);
            this.ui_lblValueLabelValue.TabIndex = 42;
            this.ui_lblValueLabelValue.Text = "00.00";
            this.ui_lblValueLabelValue.Visible = false;
            // 
            // ui_lblVolumeValue
            // 
            this.ui_lblVolumeValue.AutoSize = true;
            this.ui_lblVolumeValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblVolumeValue.Location = new System.Drawing.Point(573, 87);
            this.ui_lblVolumeValue.Name = "ui_lblVolumeValue";
            this.ui_lblVolumeValue.Size = new System.Drawing.Size(19, 13);
            this.ui_lblVolumeValue.TabIndex = 41;
            this.ui_lblVolumeValue.Text = "00";
            this.ui_lblVolumeValue.Visible = false;
            // 
            // ui_lblLTQValue
            // 
            this.ui_lblLTQValue.AutoSize = true;
            this.ui_lblLTQValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLTQValue.Location = new System.Drawing.Point(573, 66);
            this.ui_lblLTQValue.Name = "ui_lblLTQValue";
            this.ui_lblLTQValue.Size = new System.Drawing.Size(19, 13);
            this.ui_lblLTQValue.TabIndex = 40;
            this.ui_lblLTQValue.Text = "00";
            // 
            // ui_lblOI
            // 
            this.ui_lblOI.AutoSize = true;
            this.ui_lblOI.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOI.Location = new System.Drawing.Point(488, 171);
            this.ui_lblOI.Name = "ui_lblOI";
            this.ui_lblOI.Size = new System.Drawing.Size(27, 13);
            this.ui_lblOI.TabIndex = 39;
            this.ui_lblOI.Text = "OI : ";
            this.ui_lblOI.Visible = false;
            // 
            // ui_lblLTP
            // 
            this.ui_lblLTP.AutoSize = true;
            this.ui_lblLTP.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLTP.Location = new System.Drawing.Point(488, 45);
            this.ui_lblLTP.Name = "ui_lblLTP";
            this.ui_lblLTP.Size = new System.Drawing.Size(36, 13);
            this.ui_lblLTP.TabIndex = 38;
            this.ui_lblLTP.Text = "LTP : ";
            // 
            // ui_lblPercentagechange
            // 
            this.ui_lblPercentagechange.AutoSize = true;
            this.ui_lblPercentagechange.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblPercentagechange.Location = new System.Drawing.Point(488, 150);
            this.ui_lblPercentagechange.Name = "ui_lblPercentagechange";
            this.ui_lblPercentagechange.Size = new System.Drawing.Size(64, 13);
            this.ui_lblPercentagechange.TabIndex = 37;
            this.ui_lblPercentagechange.Text = "% Change : ";
            this.ui_lblPercentagechange.Visible = false;
            // 
            // ui_lblATP
            // 
            this.ui_lblATP.AutoSize = true;
            this.ui_lblATP.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblATP.Location = new System.Drawing.Point(488, 129);
            this.ui_lblATP.Name = "ui_lblATP";
            this.ui_lblATP.Size = new System.Drawing.Size(37, 13);
            this.ui_lblATP.TabIndex = 36;
            this.ui_lblATP.Text = "ATP : ";
            this.ui_lblATP.Visible = false;
            // 
            // ui_lblValue
            // 
            this.ui_lblValue.AutoSize = true;
            this.ui_lblValue.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblValue.Location = new System.Drawing.Point(488, 108);
            this.ui_lblValue.Name = "ui_lblValue";
            this.ui_lblValue.Size = new System.Drawing.Size(68, 13);
            this.ui_lblValue.TabIndex = 35;
            this.ui_lblValue.Text = "Value(lacs) : ";
            this.ui_lblValue.Visible = false;
            // 
            // ui_lblVolume
            // 
            this.ui_lblVolume.AutoSize = true;
            this.ui_lblVolume.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblVolume.Location = new System.Drawing.Point(488, 87);
            this.ui_lblVolume.Name = "ui_lblVolume";
            this.ui_lblVolume.Size = new System.Drawing.Size(51, 13);
            this.ui_lblVolume.TabIndex = 34;
            this.ui_lblVolume.Text = "Volume : ";
            this.ui_lblVolume.Visible = false;
            // 
            // ui_lblLTQ
            // 
            this.ui_lblLTQ.AutoSize = true;
            this.ui_lblLTQ.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblLTQ.Location = new System.Drawing.Point(488, 66);
            this.ui_lblLTQ.Name = "ui_lblLTQ";
            this.ui_lblLTQ.Size = new System.Drawing.Size(37, 13);
            this.ui_lblLTQ.TabIndex = 33;
            this.ui_lblLTQ.Text = "LTQ : ";
            // 
            // ui_uctlGridRight
            // 
            this.ui_uctlGridRight.AllowUserToAddRows = false;
            this.ui_uctlGridRight.AllowUserToDeleteRows = false;
            this.ui_uctlGridRight.AllowUserToOrderColumns = false;
            this.ui_uctlGridRight.AllowUserToResizeColumns = false;
            this.ui_uctlGridRight.AllowUserToResizeRows = false;
            this.ui_uctlGridRight.AlternatingRowStyle = dataGridViewCellStyle1;
            this.ui_uctlGridRight.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_uctlGridRight.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ui_uctlGridRight.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridRight.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridRight.ColumnHeaderHeight = 4;
            this.ui_uctlGridRight.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridRight.ColumnHeadersCellStyle = dataGridViewCellStyle2;
            this.ui_uctlGridRight.ColumnHeadersHeight = 0;
            this.ui_uctlGridRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridRight.ColumnHeadersVisible = false;
            this.ui_uctlGridRight.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridRight.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridRight.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridRight.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridRight.DataGridScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ui_uctlGridRight.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridRight.DataRowStyle = dataGridViewCellStyle3;
            this.ui_uctlGridRight.DataSource = null;
            this.ui_uctlGridRight.DefaultCellStyle = dataGridViewCellStyle3;
            this.ui_uctlGridRight.EnableCellCustomDraw = true;
            this.ui_uctlGridRight.EnableHeaderCustomDraw = true;
            this.ui_uctlGridRight.EnableHeadersVisualStyles = true;
            this.ui_uctlGridRight.EnableMultiSelect = true;
            this.ui_uctlGridRight.EnableSkinning = true;
            this.ui_uctlGridRight.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridRight.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridRight.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridRight.GridPalette")));
            this.ui_uctlGridRight.IColIndex = -1;
            this.ui_uctlGridRight.IRowIndex = -1;
            this.ui_uctlGridRight.IsGridReadOnly = true;
            this.ui_uctlGridRight.IsGridVisible = true;
            this.ui_uctlGridRight.IsRowHeadersVisible = false;
            this.ui_uctlGridRight.Location = new System.Drawing.Point(242, 45);
            this.ui_uctlGridRight.Name = "ui_uctlGridRight";
            this.ui_uctlGridRight.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridRight.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ui_uctlGridRight.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ui_uctlGridRight.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ui_uctlGridRight.Size = new System.Drawing.Size(232, 102);
            this.ui_uctlGridRight.TabIndex = 32;
            this.ui_uctlGridRight.Title = null;
            this.ui_uctlGridRight.OnGridCellEnter += new System.Action<object, System.Windows.Forms.DataGridViewCellEventArgs>(this.ui_uctlGridRight_OnGridCellEnter);
            // 
            // ui_uctlGridLeft
            // 
            this.ui_uctlGridLeft.AllowUserToAddRows = false;
            this.ui_uctlGridLeft.AllowUserToDeleteRows = false;
            this.ui_uctlGridLeft.AllowUserToOrderColumns = false;
            this.ui_uctlGridLeft.AllowUserToResizeColumns = false;
            this.ui_uctlGridLeft.AllowUserToResizeRows = false;
            this.ui_uctlGridLeft.AlternatingRowStyle = dataGridViewCellStyle6;
            this.ui_uctlGridLeft.AutoSizeColumsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_uctlGridLeft.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ui_uctlGridLeft.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_uctlGridLeft.ClipBoardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            this.ui_uctlGridLeft.ColumnHeaderHeight = 4;
            this.ui_uctlGridLeft.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridLeft.ColumnHeadersCellStyle = dataGridViewCellStyle7;
            this.ui_uctlGridLeft.ColumnHeadersHeight = 0;
            this.ui_uctlGridLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ui_uctlGridLeft.ColumnHeadersVisible = false;
            this.ui_uctlGridLeft.DataGridBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ui_uctlGridLeft.DataGridCellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.ui_uctlGridLeft.DataGridEditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.ui_uctlGridLeft.DataGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_uctlGridLeft.DataGridScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ui_uctlGridLeft.DataGridSelectMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_uctlGridLeft.DataRowStyle = dataGridViewCellStyle8;
            this.ui_uctlGridLeft.DataSource = null;
            this.ui_uctlGridLeft.DefaultCellStyle = dataGridViewCellStyle8;
            this.ui_uctlGridLeft.EnableCellCustomDraw = true;
            this.ui_uctlGridLeft.EnableHeaderCustomDraw = true;
            this.ui_uctlGridLeft.EnableHeadersVisualStyles = true;
            this.ui_uctlGridLeft.EnableMultiSelect = true;
            this.ui_uctlGridLeft.EnableSkinning = true;
            this.ui_uctlGridLeft.FirstDisplayedScrollingRowIndex = 0;
            this.ui_uctlGridLeft.GridForeColor = System.Drawing.SystemColors.ControlText;
            this.ui_uctlGridLeft.GridPalette = ((Nevron.UI.WinForm.Controls.NPalette)(resources.GetObject("ui_uctlGridLeft.GridPalette")));
            this.ui_uctlGridLeft.IColIndex = -1;
            this.ui_uctlGridLeft.IRowIndex = -1;
            this.ui_uctlGridLeft.IsGridReadOnly = true;
            this.ui_uctlGridLeft.IsGridVisible = true;
            this.ui_uctlGridLeft.IsRowHeadersVisible = false;
            this.ui_uctlGridLeft.Location = new System.Drawing.Point(7, 45);
            this.ui_uctlGridLeft.Name = "ui_uctlGridLeft";
            this.ui_uctlGridLeft.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ui_uctlGridLeft.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.ui_uctlGridLeft.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ui_uctlGridLeft.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.ui_uctlGridLeft.Size = new System.Drawing.Size(232, 102);
            this.ui_uctlGridLeft.TabIndex = 31;
            this.ui_uctlGridLeft.Title = null;
            this.ui_uctlGridLeft.OnGridCellEnter += new System.Action<object, System.Windows.Forms.DataGridViewCellEventArgs>(this.ui_uctlGridLeft_OnGridCellEnter);
            this.ui_uctlGridLeft.MouseEnter += new System.EventHandler(this.ui_uctlGridLeft_MouseEnter);
            // 
            // ui_ncmbProductType
            // 
            this.ui_ncmbProductType.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("--SELECT--", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbProductType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbProductType.Location = new System.Drawing.Point(7, 24);
            this.ui_ncmbProductType.Name = "ui_ncmbProductType";
            this.ui_ncmbProductType.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbProductType.TabIndex = 0;
            this.ui_ncmbProductType.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbProductType_SelectedIndexChanged);
            // 
            // ui_ncmbOptType
            // 
            this.ui_ncmbOptType.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("SELECT", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbOptType.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbOptType.Location = new System.Drawing.Point(429, 24);
            this.ui_ncmbOptType.Name = "ui_ncmbOptType";
            this.ui_ncmbOptType.Size = new System.Drawing.Size(45, 18);
            this.ui_ncmbOptType.TabIndex = 5;
            this.ui_ncmbOptType.Text = "nComboBox2";
            // 
            // ui_ncmbSeries
            // 
            this.ui_ncmbSeries.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("SELECT", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbSeries.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbSeries.Location = new System.Drawing.Point(194, 24);
            this.ui_ncmbSeries.Name = "ui_ncmbSeries";
            this.ui_ncmbSeries.Size = new System.Drawing.Size(45, 18);
            this.ui_ncmbSeries.TabIndex = 2;
            // 
            // ui_ncmbStrikePrice
            // 
            this.ui_ncmbStrikePrice.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("SELECT", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbStrikePrice.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbStrikePrice.Location = new System.Drawing.Point(336, 24);
            this.ui_ncmbStrikePrice.Name = "ui_ncmbStrikePrice";
            this.ui_ncmbStrikePrice.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbStrikePrice.TabIndex = 4;
            this.ui_ncmbStrikePrice.Text = "nComboBox2";
            // 
            // ui_ncmbExpiryDate
            // 
            this.ui_ncmbExpiryDate.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("SELECT", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbExpiryDate.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbExpiryDate.Location = new System.Drawing.Point(242, 24);
            this.ui_ncmbExpiryDate.Name = "ui_ncmbExpiryDate";
            this.ui_ncmbExpiryDate.Size = new System.Drawing.Size(89, 18);
            this.ui_ncmbExpiryDate.TabIndex = 3;
            this.ui_ncmbExpiryDate.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbExpiryDate_SelectedIndexChanged);
            // 
            // ui_lblProductType
            // 
            this.ui_lblProductType.AutoSize = true;
            this.ui_lblProductType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProductType.Location = new System.Drawing.Point(6, 8);
            this.ui_lblProductType.Name = "ui_lblProductType";
            this.ui_lblProductType.Size = new System.Drawing.Size(71, 13);
            this.ui_lblProductType.TabIndex = 19;
            this.ui_lblProductType.Text = "Product Type";
            // 
            // ui_lblOptType
            // 
            this.ui_lblOptType.AutoSize = true;
            this.ui_lblOptType.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblOptType.Location = new System.Drawing.Point(424, 8);
            this.ui_lblOptType.Name = "ui_lblOptType";
            this.ui_lblOptType.Size = new System.Drawing.Size(54, 13);
            this.ui_lblOptType.TabIndex = 18;
            this.ui_lblOptType.Text = "Opt. Type";
            // 
            // ui_lblStrikePrice
            // 
            this.ui_lblStrikePrice.AutoSize = true;
            this.ui_lblStrikePrice.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblStrikePrice.Location = new System.Drawing.Point(333, 8);
            this.ui_lblStrikePrice.Name = "ui_lblStrikePrice";
            this.ui_lblStrikePrice.Size = new System.Drawing.Size(61, 13);
            this.ui_lblStrikePrice.TabIndex = 17;
            this.ui_lblStrikePrice.Text = "Strike Price";
            // 
            // ui_lblEpiryDate
            // 
            this.ui_lblEpiryDate.AutoSize = true;
            this.ui_lblEpiryDate.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblEpiryDate.Location = new System.Drawing.Point(239, 8);
            this.ui_lblEpiryDate.Name = "ui_lblEpiryDate";
            this.ui_lblEpiryDate.Size = new System.Drawing.Size(61, 13);
            this.ui_lblEpiryDate.TabIndex = 16;
            this.ui_lblEpiryDate.Text = "Expiry Date";
            // 
            // ui_lblSeries
            // 
            this.ui_lblSeries.AutoSize = true;
            this.ui_lblSeries.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblSeries.Location = new System.Drawing.Point(191, 9);
            this.ui_lblSeries.Name = "ui_lblSeries";
            this.ui_lblSeries.Size = new System.Drawing.Size(36, 13);
            this.ui_lblSeries.TabIndex = 15;
            this.ui_lblSeries.Text = "Series";
            // 
            // ui_lblProduct
            // 
            this.ui_lblProduct.AutoSize = true;
            this.ui_lblProduct.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblProduct.Location = new System.Drawing.Point(96, 8);
            this.ui_lblProduct.Name = "ui_lblProduct";
            this.ui_lblProduct.Size = new System.Drawing.Size(44, 13);
            this.ui_lblProduct.TabIndex = 14;
            this.ui_lblProduct.Text = "Product";
            // 
            // UctlMarketPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlMarketPictureControlContainer);
            this.Name = "UctlMarketPicture";
            this.Size = new System.Drawing.Size(738, 197);
            this.Load += new System.EventHandler(this.uctlMarketPicture_Load);
            this.ui_npnlMarketPictureControlContainer.ResumeLayout(false);
            this.ui_npnlMarketPictureControlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ui_pbMarketTrend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlMarketPictureControlContainer;
        private System.Windows.Forms.Label ui_lblProductType;
        private System.Windows.Forms.Label ui_lblOptType;
        private System.Windows.Forms.Label ui_lblStrikePrice;
        private System.Windows.Forms.Label ui_lblEpiryDate;
        private System.Windows.Forms.Label ui_lblSeries;
        private System.Windows.Forms.Label ui_lblProduct;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProductType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbOptType;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbSeries;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbStrikePrice;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbExpiryDate;
        private System.Windows.Forms.Label ui_lblOI;
        private System.Windows.Forms.Label ui_lblLTP;
        private System.Windows.Forms.Label ui_lblPercentagechange;
        private System.Windows.Forms.Label ui_lblATP;
        private System.Windows.Forms.Label ui_lblValue;
        private System.Windows.Forms.Label ui_lblVolume;
        private System.Windows.Forms.Label ui_lblLTQ;
        private System.Windows.Forms.Label ui_lblDPR;
        private System.Windows.Forms.Label ui_lblOpen;
        private System.Windows.Forms.Label ui_lblLifeTimeLow;
        private System.Windows.Forms.Label ui_lblLifeTimeHigh;
        private System.Windows.Forms.Label ui_lblClose;
        private System.Windows.Forms.Label ui_lblLow;
        private System.Windows.Forms.Label ui_lblHigh;
        private System.Windows.Forms.PictureBox ui_pbMarketTrend;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbProduct;
        public UctlGrid ui_uctlGridRight;
        public UctlGrid ui_uctlGridLeft;
        public System.Windows.Forms.Label ui_lblDPRValue;
        public System.Windows.Forms.Label ui_lblOpenValue;
        public System.Windows.Forms.Label ui_lblLifeTimeLowValue;
        public System.Windows.Forms.Label ui_lblLifeTimeHighValue;
        public System.Windows.Forms.Label ui_lblCloseValue;
        public System.Windows.Forms.Label ui_lblLowValue;
        public System.Windows.Forms.Label ui_lblHighValue;
        public System.Windows.Forms.Label ui_lblOIValue;
        public System.Windows.Forms.Label ui_lblLTPValue;
        public System.Windows.Forms.Label ui_lblChangePercentageValue;
        public System.Windows.Forms.Label ui_lblATPValue;
        public System.Windows.Forms.Label ui_lblValueLabelValue;
        public System.Windows.Forms.Label ui_lblVolumeValue;
        public System.Windows.Forms.Label ui_lblLTQValue;
        public System.Windows.Forms.Label ui_lblLeftNumericValue;
        public System.Windows.Forms.Label ui_lblLTT;
        public System.Windows.Forms.Label ui_lblLUT;
        public System.Windows.Forms.Label ui_lblRightNumericValue;
        public System.Windows.Forms.Label ui_lblLTTValue;
        public System.Windows.Forms.Label ui_lblLUTValue;
    }
}
