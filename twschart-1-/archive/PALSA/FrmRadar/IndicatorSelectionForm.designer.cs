namespace PALSA.FrmRadar
{
    partial class IndicatorSelectionForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndicatorSelectionForm));
            this.indicatorImageList = new System.Windows.Forms.ImageList(this.components);
            this.btnHelp = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.btnRemove = new Nevron.UI.WinForm.Controls.NButton();
            this.btnAdd = new Nevron.UI.WinForm.Controls.NButton();
            this.btnEditIndicator = new Nevron.UI.WinForm.Controls.NButton();
            this.btnNewIndicator = new Nevron.UI.WinForm.Controls.NButton();
            this.lstIndicators = new Nevron.UI.WinForm.Controls.NListBox();
            this.lstSelectedIndicators = new Nevron.UI.WinForm.Controls.NListBox();
            this.btnDelete = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // indicatorImageList
            // 
            this.indicatorImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("indicatorImageList.ImageStream")));
            this.indicatorImageList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.indicatorImageList.Images.SetKeyName(0, "Bands.bmp");
            this.indicatorImageList.Images.SetKeyName(1, "CustomIndicator.png");
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonProperties.ShowFocusRect = false;
            this.btnHelp.Location = new System.Drawing.Point(624, 302);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(82, 23);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "Help";
            this.btnHelp.TransparentBackground = true;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonProperties.ShowFocusRect = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(536, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TransparentBackground = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ButtonProperties.ShowFocusRect = false;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(448, 302);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.TransparentBackground = true;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ButtonProperties.ShowFocusRect = false;
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(320, 163);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(85, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "< - Remove";
            this.btnRemove.TransparentBackground = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonProperties.ShowFocusRect = false;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(320, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add - >";
            this.btnAdd.TransparentBackground = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEditIndicator
            // 
            this.btnEditIndicator.ButtonProperties.ShowFocusRect = false;
            this.btnEditIndicator.Location = new System.Drawing.Point(119, 302);
            this.btnEditIndicator.Name = "btnEditIndicator";
            this.btnEditIndicator.Size = new System.Drawing.Size(82, 23);
            this.btnEditIndicator.TabIndex = 16;
            this.btnEditIndicator.Text = "&Edit";
            this.btnEditIndicator.TransparentBackground = true;
            this.btnEditIndicator.UseVisualStyleBackColor = false;
            this.btnEditIndicator.Click += new System.EventHandler(this.btnEditIndicator_Click);
            // 
            // btnNewIndicator
            // 
            this.btnNewIndicator.ButtonProperties.ShowFocusRect = false;
            this.btnNewIndicator.Location = new System.Drawing.Point(31, 302);
            this.btnNewIndicator.Name = "btnNewIndicator";
            this.btnNewIndicator.Size = new System.Drawing.Size(82, 23);
            this.btnNewIndicator.TabIndex = 17;
            this.btnNewIndicator.Text = "&New";
            this.btnNewIndicator.TransparentBackground = true;
            this.btnNewIndicator.UseVisualStyleBackColor = false;
            this.btnNewIndicator.Click += new System.EventHandler(this.btnNewIndicator_Click);
            // 
            // lstIndicators
            // 
            this.lstIndicators.ImageList = this.indicatorImageList;
            this.lstIndicators.Location = new System.Drawing.Point(12, 12);
            this.lstIndicators.Name = "lstIndicators";
            this.lstIndicators.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.lstIndicators.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
            this.lstIndicators.Palette.CaptionText = System.Drawing.Color.White;
            this.lstIndicators.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.lstIndicators.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.lstIndicators.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lstIndicators.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lstIndicators.Palette.Highlight = System.Drawing.SystemColors.Highlight;
            this.lstIndicators.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.lstIndicators.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.lstIndicators.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
            this.lstIndicators.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.lstIndicators.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.lstIndicators.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lstIndicators.Palette.Window = System.Drawing.SystemColors.Window;
            this.lstIndicators.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.lstIndicators.Size = new System.Drawing.Size(277, 284);
            this.lstIndicators.Sorted = true;
            this.lstIndicators.TabIndex = 18;
            this.lstIndicators.SelectedIndexChanged += new System.EventHandler(this.lstIndicators_SelectedIndexChanged);
            this.lstIndicators.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstIndicators_MouseDoubleClick);
            // 
            // lstSelectedIndicators
            // 
            this.lstSelectedIndicators.ImageList = this.indicatorImageList;
            this.lstSelectedIndicators.Location = new System.Drawing.Point(429, 12);
            this.lstSelectedIndicators.Name = "lstSelectedIndicators";
            this.lstSelectedIndicators.Palette.BaseScheme = Nevron.UI.WinForm.Controls.ColorScheme.WindowsDefault;
            this.lstSelectedIndicators.Palette.Caption = System.Drawing.SystemColors.ControlDarkDark;
            this.lstSelectedIndicators.Palette.CaptionText = System.Drawing.Color.White;
            this.lstSelectedIndicators.Palette.CheckedDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.lstSelectedIndicators.Palette.CheckedLight = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.lstSelectedIndicators.Palette.ControlDark = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.lstSelectedIndicators.Palette.ControlLight = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.lstSelectedIndicators.Palette.Highlight = System.Drawing.SystemColors.Highlight;
            this.lstSelectedIndicators.Palette.HighlightDark = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.lstSelectedIndicators.Palette.HighlightLight = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.lstSelectedIndicators.Palette.HighlightText = System.Drawing.SystemColors.HighlightText;
            this.lstSelectedIndicators.Palette.Menu = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.lstSelectedIndicators.Palette.PressedLight = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.lstSelectedIndicators.Palette.SelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lstSelectedIndicators.Palette.Window = System.Drawing.SystemColors.Window;
            this.lstSelectedIndicators.PaletteInheritance = ((Nevron.UI.WinForm.Controls.PaletteInheritance)(Nevron.UI.WinForm.Controls.PaletteInheritance.None));
            this.lstSelectedIndicators.Size = new System.Drawing.Size(277, 284);
            this.lstSelectedIndicators.Sorted = true;
            this.lstSelectedIndicators.TabIndex = 19;
            this.lstSelectedIndicators.SelectedIndexChanged += new System.EventHandler(this.lstSelectedIndicators_SelectedIndexChanged);
            this.lstSelectedIndicators.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSelectedIndicators_MouseDoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonProperties.ShowFocusRect = false;
            this.btnDelete.Location = new System.Drawing.Point(207, 302);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TransparentBackground = true;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // IndicatorSelectionForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(729, 346);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lstSelectedIndicators);
            this.Controls.Add(this.lstIndicators);
            this.Controls.Add(this.btnNewIndicator);
            this.Controls.Add(this.btnEditIndicator);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IndicatorSelectionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Indicator selection";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NButton btnHelp;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private Nevron.UI.WinForm.Controls.NButton btnOK;
        private Nevron.UI.WinForm.Controls.NButton btnRemove;
        private Nevron.UI.WinForm.Controls.NButton btnAdd;
        internal System.Windows.Forms.ImageList indicatorImageList;
        private Nevron.UI.WinForm.Controls.NButton btnEditIndicator;
        private Nevron.UI.WinForm.Controls.NButton btnNewIndicator;
        private Nevron.UI.WinForm.Controls.NListBox lstIndicators;
        private Nevron.UI.WinForm.Controls.NListBox lstSelectedIndicators;
        private Nevron.UI.WinForm.Controls.NButton btnDelete;
    }
}