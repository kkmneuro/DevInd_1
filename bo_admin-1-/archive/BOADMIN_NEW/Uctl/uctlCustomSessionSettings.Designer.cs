namespace BOADMIN_NEW.Uctl
{
    partial class uctlCustomSessionSettings
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
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.ui_lblContent = new System.Windows.Forms.Label();
            this.ui_chkEnable = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.ui_btnancel = new Nevron.UI.WinForm.Controls.NButton();
            this.ui_btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.nLineControl1 = new Nevron.UI.WinForm.Controls.NLineControl();
            this.ui_lblTrade = new System.Windows.Forms.Label();
            this.ui_lblQuotes = new System.Windows.Forms.Label();
            this.ui_lstTrade = new Nevron.UI.WinForm.Controls.NListBox();
            this.ui_lstQuotes = new Nevron.UI.WinForm.Controls.NListBox();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.Controls.Add(this.ui_lblContent);
            this.nuiPanel1.Controls.Add(this.ui_chkEnable);
            this.nuiPanel1.Controls.Add(this.ui_btnancel);
            this.nuiPanel1.Controls.Add(this.ui_btnOK);
            this.nuiPanel1.Controls.Add(this.nLineControl1);
            this.nuiPanel1.Controls.Add(this.ui_lblTrade);
            this.nuiPanel1.Controls.Add(this.ui_lblQuotes);
            this.nuiPanel1.Controls.Add(this.ui_lstTrade);
            this.nuiPanel1.Controls.Add(this.ui_lstQuotes);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(622, 213);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            this.nuiPanel1.Click += new System.EventHandler(this.nuiPanel1_Click);
            // 
            // ui_lblContent
            // 
            this.ui_lblContent.AutoSize = true;
            this.ui_lblContent.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblContent.Location = new System.Drawing.Point(17, 17);
            this.ui_lblContent.Name = "ui_lblContent";
            this.ui_lblContent.Size = new System.Drawing.Size(197, 13);
            this.ui_lblContent.TabIndex = 40;
            this.ui_lblContent.Text = "Settings of active sessions with in a day.";
            // 
            // ui_chkEnable
            // 
            this.ui_chkEnable.AutoSize = true;
            this.ui_chkEnable.ButtonProperties.BorderOffset = 2;
            this.ui_chkEnable.Location = new System.Drawing.Point(83, 135);
            this.ui_chkEnable.Name = "ui_chkEnable";
            this.ui_chkEnable.Size = new System.Drawing.Size(184, 17);
            this.ui_chkEnable.TabIndex = 38;
            this.ui_chkEnable.TabStop = false;
            this.ui_chkEnable.Text = " Enable seperate trading sessions";
            this.ui_chkEnable.TransparentBackground = true;
            this.ui_chkEnable.UseVisualStyleBackColor = false;
            this.ui_chkEnable.CheckedChanged += new System.EventHandler(this.ui_chkEnable_CheckedChanged);
            // 
            // ui_btnancel
            // 
            this.ui_btnancel.Location = new System.Drawing.Point(496, 180);
            this.ui_btnancel.Name = "ui_btnancel";
            this.ui_btnancel.Size = new System.Drawing.Size(75, 23);
            this.ui_btnancel.TabIndex = 3;
            this.ui_btnancel.Text = "Cancel";
            this.ui_btnancel.UseVisualStyleBackColor = false;
            this.ui_btnancel.Click += new System.EventHandler(this.ui_btnancel_Click);
            // 
            // ui_btnOK
            // 
            this.ui_btnOK.Location = new System.Drawing.Point(391, 180);
            this.ui_btnOK.Name = "ui_btnOK";
            this.ui_btnOK.Size = new System.Drawing.Size(75, 23);
            this.ui_btnOK.TabIndex = 2;
            this.ui_btnOK.Text = "OK";
            this.ui_btnOK.UseVisualStyleBackColor = false;
            this.ui_btnOK.Click += new System.EventHandler(this.ui_btnOK_Click);
            // 
            // nLineControl1
            // 
            this.nLineControl1.Location = new System.Drawing.Point(0, 171);
            this.nLineControl1.Name = "nLineControl1";
            this.nLineControl1.Size = new System.Drawing.Size(620, 2);
            this.nLineControl1.Text = "nLineControl1";
            // 
            // ui_lblTrade
            // 
            this.ui_lblTrade.AutoSize = true;
            this.ui_lblTrade.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblTrade.Location = new System.Drawing.Point(23, 97);
            this.ui_lblTrade.Name = "ui_lblTrade";
            this.ui_lblTrade.Size = new System.Drawing.Size(38, 13);
            this.ui_lblTrade.TabIndex = 34;
            this.ui_lblTrade.Text = "Trade:";
            // 
            // ui_lblQuotes
            // 
            this.ui_lblQuotes.AutoSize = true;
            this.ui_lblQuotes.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblQuotes.Location = new System.Drawing.Point(17, 61);
            this.ui_lblQuotes.Name = "ui_lblQuotes";
            this.ui_lblQuotes.Size = new System.Drawing.Size(44, 13);
            this.ui_lblQuotes.TabIndex = 33;
            this.ui_lblQuotes.Text = "Quotes:";
            // 
            // ui_lstTrade
            // 
            this.ui_lstTrade.ColumnWidth = 20;
            this.ui_lstTrade.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.ui_lstTrade.HorizontalExtent = 45;
            this.ui_lstTrade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ui_lstTrade.ItemHeight = 13;
            this.ui_lstTrade.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("00", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("01", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("02", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("03", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("04", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("05", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("06", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("07", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("08", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("09", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("10", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("11", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("12", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("13", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("14", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("15", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("16", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("17", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("18", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("19", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("20", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("21", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("22", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("23", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("*", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_lstTrade.Location = new System.Drawing.Point(83, 95);
            this.ui_lstTrade.Margin = new System.Windows.Forms.Padding(0);
            this.ui_lstTrade.MultiColumn = true;
            this.ui_lstTrade.Name = "ui_lstTrade";
            this.ui_lstTrade.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ui_lstTrade.Size = new System.Drawing.Size(509, 17);
            this.ui_lstTrade.TabIndex = 1;
            this.ui_lstTrade.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ui_lstTrade_MouseUp);
            // 
            // ui_lstQuotes
            // 
            this.ui_lstQuotes.ColumnWidth = 20;
            this.ui_lstQuotes.DrawMode = System.Windows.Forms.DrawMode.Normal;
            this.ui_lstQuotes.HorizontalExtent = 45;
            this.ui_lstQuotes.ItemHeight = 13;
            this.ui_lstQuotes.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("00", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("01", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("02", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("03", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("04", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("05", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("06", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("07", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("08", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("09", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("10", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("11", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("12", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("13", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("14", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("15", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("16", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("17", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("18", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("19", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("20", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("21", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("22", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("23", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("*", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_lstQuotes.Location = new System.Drawing.Point(83, 59);
            this.ui_lstQuotes.Margin = new System.Windows.Forms.Padding(0);
            this.ui_lstQuotes.MultiColumn = true;
            this.ui_lstQuotes.Name = "ui_lstQuotes";
            this.ui_lstQuotes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ui_lstQuotes.Size = new System.Drawing.Size(509, 17);
            this.ui_lstQuotes.TabIndex = 0;
            this.ui_lstQuotes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ui_lstQuotes_MouseUp);
            // 
            // uctlCustomSessionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nuiPanel1);
            this.Name = "uctlCustomSessionSettings";
            this.Size = new System.Drawing.Size(622, 213);
            this.Load += new System.EventHandler(this.uctlCustomSessionSettings_Load);
            this.nuiPanel1.ResumeLayout(false);
            this.nuiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NCheckBox ui_chkEnable;
        private Nevron.UI.WinForm.Controls.NButton ui_btnancel;
        private Nevron.UI.WinForm.Controls.NButton ui_btnOK;
        private Nevron.UI.WinForm.Controls.NLineControl nLineControl1;
        private System.Windows.Forms.Label ui_lblTrade;
        private System.Windows.Forms.Label ui_lblQuotes;
        private Nevron.UI.WinForm.Controls.NListBox ui_lstTrade;
        private Nevron.UI.WinForm.Controls.NListBox ui_lstQuotes;
        private System.Windows.Forms.Label ui_lblContent;
    }
}
