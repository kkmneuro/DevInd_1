namespace PALSA.Frm
{
    partial class frmTradeWindow
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
            this.uctlTradeWindow1 = new CommonLibrary.UserControls.uctlTradeWindow();
            this.SuspendLayout();
            // 
            // uctlTradeWindow1
            // 
            this.uctlTradeWindow1.AutoSize = true;
            this.uctlTradeWindow1.BuyAtp = "0";
            this.uctlTradeWindow1.BuyQty = "0";
            this.uctlTradeWindow1.BuyVal = "0";
            this.uctlTradeWindow1.CurrentProfileName = null;
            this.uctlTradeWindow1.DataRowStyle = System.Drawing.Color.Empty;
            this.uctlTradeWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlTradeWindow1.Location = new System.Drawing.Point(0, 0);
            this.uctlTradeWindow1.Name = "uctlTradeWindow1";
            this.uctlTradeWindow1.NoOfTotalOrder = "0";
            this.uctlTradeWindow1.OrderFilter = null;
            this.uctlTradeWindow1.Profile = null;
            this.uctlTradeWindow1.SellAtp = "0";
            this.uctlTradeWindow1.SellQty = "0";
            this.uctlTradeWindow1.SellVal = "0";
            this.uctlTradeWindow1.ShortcutKeyFilter = System.Windows.Forms.Keys.None;
            this.uctlTradeWindow1.Size = new System.Drawing.Size(809, 233);
            this.uctlTradeWindow1.TabIndex = 0;
            this.uctlTradeWindow1.Title = " ";
            this.uctlTradeWindow1.OnProfileSaveClick += new System.Action<object, string>(this.uctlTradeWindow1_OnProfileSaveClick);
            this.uctlTradeWindow1.OnProfileRemoveClick += new System.Action<object, string>(this.uctlTradeWindow1_OnProfileRemoveClick);
            this.uctlTradeWindow1.OnSetDefaultProfileClick += new System.Action<object, string>(this.uctlTradeWindow1_OnSetDefaultProfileClick);
            this.uctlTradeWindow1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlTradeWindow1_OnGridMouseDown);
            // 
            // frmTradeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 233);
            this.Controls.Add(this.uctlTradeWindow1);
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(600, 150);
            this.Name = "frmTradeWindow";
            this.Text = "Trade Window";
            this.Title = "Trade Window";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTradeWindow_FormClosed);
            this.Load += new System.EventHandler(this.frmTradeWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CommonLibrary.UserControls.uctlTradeWindow uctlTradeWindow1;

    }
}