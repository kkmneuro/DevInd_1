namespace PALSA.uctl
{
    partial class ctlOrderBook
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
            this.uctlOrderBook1 = new CommonLibrary.UserControls.UctlOrderBook();
            this.SuspendLayout();
            // 
            // uctlOrderBook1
            // 
            this.uctlOrderBook1.AccountNo = 0;
            this.uctlOrderBook1.AlertSound = null;
            this.uctlOrderBook1.BS = "All";
            this.uctlOrderBook1.BuyQty = "";
            this.uctlOrderBook1.CurrentProfileName = null;
            this.uctlOrderBook1.DataRowStyle = System.Drawing.Color.Empty;
            this.uctlOrderBook1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlOrderBook1.Location = new System.Drawing.Point(0, 0);
            this.uctlOrderBook1.Name = "uctlOrderBook1";
            this.uctlOrderBook1.OrderFilter = null;
            this.uctlOrderBook1.OrderStatus = "All";
            this.uctlOrderBook1.OrderType = "All";
            this.uctlOrderBook1.ProductType = "All";
            this.uctlOrderBook1.Profiles = null;
            this.uctlOrderBook1.SellQty = "";
            this.uctlOrderBook1.ShortcutKeyFilter = System.Windows.Forms.Keys.None;
            this.uctlOrderBook1.Size = new System.Drawing.Size(998, 172);
            this.uctlOrderBook1.TabIndex = 0;
            this.uctlOrderBook1.Title = "Order Book";
            this.uctlOrderBook1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlOrderBook1_OnGridMouseDown);
            this.uctlOrderBook1.Click += new System.EventHandler(this.uctlOrderBook1_Click);
            this.uctlOrderBook1.OnProfileSaveClick += new System.Action<object, string>(this.uctlOrderBook1_OnProfileSaveClick);
            this.uctlOrderBook1.OnProfileRemoveClick += new System.Action<object, string>(this.uctlOrderBook1_OnProfileRemoveClick);
            this.uctlOrderBook1.OnSetDefaultProfileClick += new System.Action<object, string>(this.uctlOrderBook1_OnSetDefaultProfileClick);
            this.uctlOrderBook1.HandleCancelOrderClick += new System.Action<object, System.EventArgs>(this.uctlOrderBook1_HandleCancelOrder);
            this.uctlOrderBook1.HandleModifyOrderClick += new System.Action<object, System.EventArgs>(this.uctlOrderBook1_HandleModifyOrderClick);
            this.uctlOrderBook1.HandleCloseOrderClick += new System.Action<object, System.EventArgs>(this.uctlOrderBook1_HandleCloseOrderClick);
            // 
            // ctlOrderBook
            // 
            this.Controls.Add(this.uctlOrderBook1);
            this.Name = "ctlOrderBook";
            this.Size = new System.Drawing.Size(998, 172);
            this.Load += new System.EventHandler(this.ctlOrderBook_Load);
            this.ResumeLayout(false);

        }

     

        #endregion

        public CommonLibrary.UserControls.UctlOrderBook uctlOrderBook1;


    }
}
