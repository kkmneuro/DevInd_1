
﻿using CommonLibrary.Cls;
using System.Windows.Forms;
using System.Collections.Generic;
using CommonLibrary.UserControls;
using PALSA.Cls;
namespace PALSA.Frm
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
            this.uctlOrderBook1 = new CommonLibrary.UserControls.UctlOrderBook();
            this.SuspendLayout();
            // 
            // uctlOrderBook1
            // 
            this.uctlOrderBook1.AccountNo = 0;
            this.uctlOrderBook1.AlertSound = null;
            this.uctlOrderBook1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uctlOrderBook1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uctlOrderBook1.BS = "All";
            this.uctlOrderBook1.BuyQty = "";
            this.uctlOrderBook1.CurrentProfileName = null;
            this.uctlOrderBook1.DataRowStyle = System.Drawing.Color.Empty;
            this.uctlOrderBook1.Location = new System.Drawing.Point(0, 0);
            this.uctlOrderBook1.Name = "uctlOrderBook1";
            this.uctlOrderBook1.OrderFilter = null;
            this.uctlOrderBook1.OrderStatus = "All";
            this.uctlOrderBook1.OrderType = "All";
            this.uctlOrderBook1.ProductType = "All";
            this.uctlOrderBook1.Profiles = null;
            this.uctlOrderBook1.SellQty = "";
            this.uctlOrderBook1.ShortcutKeyFilter = System.Windows.Forms.Keys.None;
            this.uctlOrderBook1.Size = new System.Drawing.Size(912, 284);
            this.uctlOrderBook1.TabIndex = 0;
            this.uctlOrderBook1.Title = " ";
            this.uctlOrderBook1.OnGridMouseDown += new System.Action<object, System.Windows.Forms.MouseEventArgs>(this.uctlOrderBook1_OnGridMouseDown);
            this.uctlOrderBook1.Click += new System.EventHandler(this.uctlOrderBook1_Click);
            this.uctlOrderBook1.OnProfileSaveClick += new System.Action<object, string>(this.uctlOrderBook1_OnProfileSaveClick);
            this.uctlOrderBook1.OnProfileRemoveClick += new System.Action<object, string>(this.uctlOrderBook1_OnProfileRemoveClick);
            this.uctlOrderBook1.OnSetDefaultProfileClick += new System.Action<object, string>(this.uctlOrderBook1_OnSetDefaultProfileClick);
            this.uctlOrderBook1.HandleCancelOrderClick += new System.Action<object, System.EventArgs>(this.uctlOrderBook1_HandleCancelOrder);
            this.uctlOrderBook1.HandleModifyOrderClick += new System.Action<object, System.EventArgs>(this.uctlOrderBook1_HandleModifyOrderClick);
            this.uctlOrderBook1.HandleCloseOrderClick += new System.Action<object, System.EventArgs>(uctlOrderBook1_HandleCloseOrderClick);
            // 
            // frmOrderBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(912, 284);
            this.Controls.Add(this.uctlOrderBook1);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1200, 600);
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

        public UctlOrderBook uctlOrderBook1;



    }
}