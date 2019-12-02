
﻿using CommonLibrary.Cls;
using System.Windows.Forms;
using System.Collections.Generic;
using CommonLibrary.UserControls;
using TWS.Cls;
namespace TWS.Frm
{
    partial class frmOrderBook
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
            this.uctlOrderBookNew1 = new CommonLibrary.UserControls.UctlOrderBookNew();
            this.SuspendLayout();
            // 
            // uctlOrderBookNew1
            // 
            this.uctlOrderBookNew1.AccountNo = 0;
            this.uctlOrderBookNew1.AlertSound = null;
            this.uctlOrderBookNew1.BS = "All";
            this.uctlOrderBookNew1.BuyQty = "";
            this.uctlOrderBookNew1.Contract = "All";
            this.uctlOrderBookNew1.CurrentProfileName = null;
            this.uctlOrderBookNew1.DataRowStyle = System.Drawing.Color.Empty;
            this.uctlOrderBookNew1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctlOrderBookNew1.Location = new System.Drawing.Point(0, 0);
            this.uctlOrderBookNew1.MarketMakerAccountId = 0;
            this.uctlOrderBookNew1.Name = "uctlOrderBookNew1";
            this.uctlOrderBookNew1.OrderFilter = null;
            this.uctlOrderBookNew1.OrderStatus = "All";
            this.uctlOrderBookNew1.OrderType = "All";
            this.uctlOrderBookNew1.ProductType = "All";
            this.uctlOrderBookNew1.Profiles = null;
            this.uctlOrderBookNew1.SellQty = "";
            this.uctlOrderBookNew1.ShortcutKeyFilter = System.Windows.Forms.Keys.None;
            this.uctlOrderBookNew1.Size = new System.Drawing.Size(1209, 396);
            this.uctlOrderBookNew1.TabIndex = 0;
            this.uctlOrderBookNew1.Title = "Order Book";
            // 
            // frmOrderBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1209, 396);
            this.Controls.Add(this.uctlOrderBookNew1);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1225, 600);
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "frmOrderBook";
            this.Text = "Order Book";
            this.Title = "Order Book";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOrderBook_FormClosed);
            this.Load += new System.EventHandler(this.frmOrderBook_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOrderBook_KeyDown);
            this.ResumeLayout(false);

        }

        

        #endregion

        public UctlOrderBookNew uctlOrderBookNew1;





    }
}