namespace PALSA.Frm
{
    partial class frmPropertyChartWPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPropertyChartWPF));
            this.tabCtrlProperty = new Nevron.UI.WinForm.Controls.NTabControl();
            this.tabPageColors = new Nevron.UI.WinForm.Controls.NTabPage();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.colBtnBarUp = new Nevron.UI.WinForm.Controls.NColorButton();
            this.colBtnBarDown = new Nevron.UI.WinForm.Controls.NColorButton();
            this.colBtnForground = new Nevron.UI.WinForm.Controls.NColorButton();
            this.colBtnBackground = new Nevron.UI.WinForm.Controls.NColorButton();
            this.lblBarDown = new System.Windows.Forms.Label();
            this.cboColorScheme = new Nevron.UI.WinForm.Controls.NComboBox();
            this.lblBarUp = new System.Windows.Forms.Label();
            this.lblForground = new System.Windows.Forms.Label();
            this.lblBackground = new System.Windows.Forms.Label();
            this.colBtnGrid = new Nevron.UI.WinForm.Controls.NColorButton();
            this.lblGrid = new System.Windows.Forms.Label();
            this.nbtnCross = new Nevron.UI.WinForm.Controls.NColorButton();
            this.label1 = new System.Windows.Forms.Label();
            this.nbtnUpOutLine = new Nevron.UI.WinForm.Controls.NColorButton();
            this.label2 = new System.Windows.Forms.Label();
            this.nbtnDownOutLine = new Nevron.UI.WinForm.Controls.NColorButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStyle = new System.Windows.Forms.CheckBox();
            this.nbtnLblBack = new Nevron.UI.WinForm.Controls.NColorButton();
            this.label4 = new System.Windows.Forms.Label();
            this.nbtnLabelFore = new Nevron.UI.WinForm.Controls.NColorButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tabCtrlProperty.SuspendLayout();
            this.tabPageColors.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrlProperty
            // 
            this.tabCtrlProperty.Controls.Add(this.tabPageColors);
            this.tabCtrlProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlProperty.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlProperty.Name = "tabCtrlProperty";
            this.tabCtrlProperty.Padding = new System.Windows.Forms.Padding(4, 29, 4, 4);
            this.tabCtrlProperty.Selectable = true;
            this.tabCtrlProperty.SelectedIndex = 0;
            this.tabCtrlProperty.Size = new System.Drawing.Size(454, 292);
            this.tabCtrlProperty.TabIndex = 1;
            // 
            // tabPageColors
            // 
            this.tabPageColors.Controls.Add(this.nbtnLabelFore);
            this.tabPageColors.Controls.Add(this.label5);
            this.tabPageColors.Controls.Add(this.nbtnLblBack);
            this.tabPageColors.Controls.Add(this.label4);
            this.tabPageColors.Controls.Add(this.chkStyle);
            this.tabPageColors.Controls.Add(this.groupBox1);
            this.tabPageColors.Controls.Add(this.nbtnDownOutLine);
            this.tabPageColors.Controls.Add(this.label3);
            this.tabPageColors.Controls.Add(this.nbtnUpOutLine);
            this.tabPageColors.Controls.Add(this.label2);
            this.tabPageColors.Controls.Add(this.nbtnCross);
            this.tabPageColors.Controls.Add(this.label1);
            this.tabPageColors.Controls.Add(this.btnCancel);
            this.tabPageColors.Controls.Add(this.btnOK);
            this.tabPageColors.Controls.Add(this.cboColorScheme);
            this.tabPageColors.Location = new System.Drawing.Point(4, 29);
            this.tabPageColors.Name = "tabPageColors";
            this.tabPageColors.Size = new System.Drawing.Size(446, 259);
            this.tabPageColors.TabIndex = 1;
            this.tabPageColors.Text = "Colors";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(227, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(145, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 39;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // colBtnBarUp
            // 
            this.colBtnBarUp.ArrowClickOptions = false;
            this.colBtnBarUp.ArrowWidth = 14;
            this.colBtnBarUp.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.colBtnBarUp.Location = new System.Drawing.Point(88, 70);
            this.colBtnBarUp.Name = "colBtnBarUp";
            this.colBtnBarUp.Size = new System.Drawing.Size(100, 20);
            this.colBtnBarUp.TabIndex = 28;
            this.colBtnBarUp.UseVisualStyleBackColor = false;
            // 
            // colBtnBarDown
            // 
            this.colBtnBarDown.ArrowClickOptions = false;
            this.colBtnBarDown.ArrowWidth = 14;
            this.colBtnBarDown.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.colBtnBarDown.Location = new System.Drawing.Point(88, 95);
            this.colBtnBarDown.Name = "colBtnBarDown";
            this.colBtnBarDown.Size = new System.Drawing.Size(100, 20);
            this.colBtnBarDown.TabIndex = 27;
            this.colBtnBarDown.UseVisualStyleBackColor = false;
            // 
            // colBtnForground
            // 
            this.colBtnForground.ArrowClickOptions = false;
            this.colBtnForground.ArrowWidth = 14;
            this.colBtnForground.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.colBtnForground.Location = new System.Drawing.Point(88, 43);
            this.colBtnForground.Name = "colBtnForground";
            this.colBtnForground.Size = new System.Drawing.Size(100, 20);
            this.colBtnForground.TabIndex = 24;
            this.colBtnForground.UseVisualStyleBackColor = false;
            // 
            // colBtnBackground
            // 
            this.colBtnBackground.ArrowClickOptions = false;
            this.colBtnBackground.ArrowWidth = 14;
            this.colBtnBackground.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.colBtnBackground.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.colBtnBackground.Location = new System.Drawing.Point(88, 14);
            this.colBtnBackground.Name = "colBtnBackground";
            this.colBtnBackground.Size = new System.Drawing.Size(100, 20);
            this.colBtnBackground.TabIndex = 23;
            this.colBtnBackground.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.colBtnBackground.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.colBtnBackground.TransparentBackground = true;
            this.colBtnBackground.UseVisualStyleBackColor = false;
            // 
            // lblBarDown
            // 
            this.lblBarDown.AutoSize = true;
            this.lblBarDown.Location = new System.Drawing.Point(12, 99);
            this.lblBarDown.Name = "lblBarDown";
            this.lblBarDown.Size = new System.Drawing.Size(57, 13);
            this.lblBarDown.TabIndex = 8;
            this.lblBarDown.Text = "Bar Down:";
            // 
            // cboColorScheme
            // 
            this.cboColorScheme.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("Yellow on black", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Green on black", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Black on white", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("None", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.cboColorScheme.ListProperties.ColumnOnLeft = false;
            this.cboColorScheme.ListProperties.DefaultImageIndex = 0;
            this.cboColorScheme.Location = new System.Drawing.Point(97, 15);
            this.cboColorScheme.Name = "cboColorScheme";
            this.cboColorScheme.Size = new System.Drawing.Size(121, 18);
            this.cboColorScheme.TabIndex = 5;
            this.cboColorScheme.Text = "nComboBox1";
            this.cboColorScheme.SelectedIndexChanged += new System.EventHandler(this.cboColorScheme_SelectedIndexChanged);
            // 
            // lblBarUp
            // 
            this.lblBarUp.AutoSize = true;
            this.lblBarUp.Location = new System.Drawing.Point(12, 74);
            this.lblBarUp.Name = "lblBarUp";
            this.lblBarUp.Size = new System.Drawing.Size(43, 13);
            this.lblBarUp.TabIndex = 4;
            this.lblBarUp.Text = "Bar Up:";
            // 
            // lblForground
            // 
            this.lblForground.AutoSize = true;
            this.lblForground.BackColor = System.Drawing.Color.Transparent;
            this.lblForground.Location = new System.Drawing.Point(12, 47);
            this.lblForground.Name = "lblForground";
            this.lblForground.Size = new System.Drawing.Size(64, 13);
            this.lblForground.TabIndex = 2;
            this.lblForground.Text = "Foreground:";
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.BackColor = System.Drawing.Color.Transparent;
            this.lblBackground.Location = new System.Drawing.Point(12, 18);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(68, 13);
            this.lblBackground.TabIndex = 1;
            this.lblBackground.Text = "Background:";
            // 
            // colBtnGrid
            // 
            this.colBtnGrid.ArrowClickOptions = false;
            this.colBtnGrid.ArrowWidth = 14;
            this.colBtnGrid.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.colBtnGrid.Location = new System.Drawing.Point(88, 125);
            this.colBtnGrid.Name = "colBtnGrid";
            this.colBtnGrid.Size = new System.Drawing.Size(100, 20);
            this.colBtnGrid.TabIndex = 43;
            this.colBtnGrid.UseVisualStyleBackColor = false;
            // 
            // lblGrid
            // 
            this.lblGrid.AutoSize = true;
            this.lblGrid.BackColor = System.Drawing.Color.Transparent;
            this.lblGrid.Location = new System.Drawing.Point(18, 125);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(29, 13);
            this.lblGrid.TabIndex = 42;
            this.lblGrid.Text = "Grid:";
            // 
            // nbtnCross
            // 
            this.nbtnCross.ArrowClickOptions = false;
            this.nbtnCross.ArrowWidth = 14;
            this.nbtnCross.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.nbtnCross.Location = new System.Drawing.Point(342, 56);
            this.nbtnCross.Name = "nbtnCross";
            this.nbtnCross.Size = new System.Drawing.Size(100, 20);
            this.nbtnCross.TabIndex = 45;
            this.nbtnCross.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(241, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Crosshair:";
            // 
            // nbtnUpOutLine
            // 
            this.nbtnUpOutLine.ArrowClickOptions = false;
            this.nbtnUpOutLine.ArrowWidth = 14;
            this.nbtnUpOutLine.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.nbtnUpOutLine.Location = new System.Drawing.Point(342, 118);
            this.nbtnUpOutLine.Name = "nbtnUpOutLine";
            this.nbtnUpOutLine.Size = new System.Drawing.Size(100, 20);
            this.nbtnUpOutLine.TabIndex = 47;
            this.nbtnUpOutLine.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(241, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "UpOutlineColor:";
            // 
            // nbtnDownOutLine
            // 
            this.nbtnDownOutLine.ArrowClickOptions = false;
            this.nbtnDownOutLine.ArrowWidth = 14;
            this.nbtnDownOutLine.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.nbtnDownOutLine.Location = new System.Drawing.Point(343, 86);
            this.nbtnDownOutLine.Name = "nbtnDownOutLine";
            this.nbtnDownOutLine.Size = new System.Drawing.Size(100, 20);
            this.nbtnDownOutLine.TabIndex = 49;
            this.nbtnDownOutLine.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(241, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "DownOutlineColor:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBackground);
            this.groupBox1.Controls.Add(this.lblForground);
            this.groupBox1.Controls.Add(this.lblBarUp);
            this.groupBox1.Controls.Add(this.lblBarDown);
            this.groupBox1.Controls.Add(this.colBtnBackground);
            this.groupBox1.Controls.Add(this.colBtnForground);
            this.groupBox1.Controls.Add(this.colBtnBarDown);
            this.groupBox1.Controls.Add(this.colBtnGrid);
            this.groupBox1.Controls.Add(this.colBtnBarUp);
            this.groupBox1.Controls.Add(this.lblGrid);
            this.groupBox1.Location = new System.Drawing.Point(8, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 156);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Style";
            // 
            // chkStyle
            // 
            this.chkStyle.AutoSize = true;
            this.chkStyle.Location = new System.Drawing.Point(12, 15);
            this.chkStyle.Name = "chkStyle";
            this.chkStyle.Size = new System.Drawing.Size(76, 17);
            this.chkStyle.TabIndex = 51;
            this.chkStyle.Text = "Color Style";
            this.chkStyle.UseVisualStyleBackColor = true;
            this.chkStyle.CheckedChanged += new System.EventHandler(this.chkStyle_CheckedChanged);
            // 
            // nbtnLblBack
            // 
            this.nbtnLblBack.ArrowClickOptions = false;
            this.nbtnLblBack.ArrowWidth = 14;
            this.nbtnLblBack.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.nbtnLblBack.Location = new System.Drawing.Point(342, 150);
            this.nbtnLblBack.Name = "nbtnLblBack";
            this.nbtnLblBack.Size = new System.Drawing.Size(100, 20);
            this.nbtnLblBack.TabIndex = 53;
            this.nbtnLblBack.UseVisualStyleBackColor = false;
            this.nbtnLblBack.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(241, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "LabelBackColor:";
            this.label4.Visible = false;
            // 
            // nbtnLabelFore
            // 
            this.nbtnLabelFore.ArrowClickOptions = false;
            this.nbtnLabelFore.ArrowWidth = 14;
            this.nbtnLabelFore.ColorPaneType = Nevron.UI.WinForm.Controls.ColorPaneType.Palette;
            this.nbtnLabelFore.Location = new System.Drawing.Point(342, 179);
            this.nbtnLabelFore.Name = "nbtnLabelFore";
            this.nbtnLabelFore.Size = new System.Drawing.Size(100, 20);
            this.nbtnLabelFore.TabIndex = 55;
            this.nbtnLabelFore.UseVisualStyleBackColor = false;
            this.nbtnLabelFore.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(241, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "LabelForeColor:";
            this.label5.Visible = false;
            // 
            // frmPropertyChartWPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 292);
            this.Controls.Add(this.tabCtrlProperty);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPropertyChartWPF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
            this.tabCtrlProperty.ResumeLayout(false);
            this.tabPageColors.ResumeLayout(false);
            this.tabPageColors.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTabControl tabCtrlProperty;
        public stockXUserctrl.chartingCtrl chartingCtrl1;
        private Nevron.UI.WinForm.Controls.NTabPage tabPageColors;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private Nevron.UI.WinForm.Controls.NButton btnOK;
        private Nevron.UI.WinForm.Controls.NColorButton colBtnBarUp;
        private Nevron.UI.WinForm.Controls.NColorButton colBtnBarDown;
        private Nevron.UI.WinForm.Controls.NColorButton colBtnForground;
        private Nevron.UI.WinForm.Controls.NColorButton colBtnBackground;
        private System.Windows.Forms.Label lblBarDown;
        private Nevron.UI.WinForm.Controls.NComboBox cboColorScheme;
        private System.Windows.Forms.Label lblBarUp;
        private System.Windows.Forms.Label lblForground;
        private System.Windows.Forms.Label lblBackground;
        private Nevron.UI.WinForm.Controls.NColorButton colBtnGrid;
        private System.Windows.Forms.Label lblGrid;
        private Nevron.UI.WinForm.Controls.NColorButton nbtnCross;
        private System.Windows.Forms.Label label1;
        private Nevron.UI.WinForm.Controls.NColorButton nbtnDownOutLine;
        private System.Windows.Forms.Label label3;
        private Nevron.UI.WinForm.Controls.NColorButton nbtnUpOutLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkStyle;
        private System.Windows.Forms.GroupBox groupBox1;
        private Nevron.UI.WinForm.Controls.NColorButton nbtnLabelFore;
        private System.Windows.Forms.Label label5;
        private Nevron.UI.WinForm.Controls.NColorButton nbtnLblBack;
        private System.Windows.Forms.Label label4;
    }
}