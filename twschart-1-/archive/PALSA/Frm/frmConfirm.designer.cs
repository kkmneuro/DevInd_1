namespace PALSA.Frm
{
    partial class frmConfirm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirm));
            this.lblmsg = new System.Windows.Forms.Label();
            this.chkdisplay = new Nevron.UI.WinForm.Controls.NCheckBox();
            this.btnOk = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.nTreeView1 = new Nevron.UI.WinForm.Controls.NTreeView();
            this.SuspendLayout();
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Location = new System.Drawing.Point(12, 9);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(54, 13);
            this.lblmsg.TabIndex = 0;
            this.lblmsg.Text = "OrderText";
            // 
            // chkdisplay
            // 
            this.chkdisplay.AutoSize = true;
            this.chkdisplay.ButtonProperties.BorderOffset = 2;
            this.chkdisplay.Location = new System.Drawing.Point(17, 165);
            this.chkdisplay.Name = "chkdisplay";
            this.chkdisplay.Size = new System.Drawing.Size(224, 17);
            this.chkdisplay.TabIndex = 2;
            this.chkdisplay.Text = "Don\'t show me this again for Matrix Orders";
            this.chkdisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkdisplay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(48, 191);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(141, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nTreeView1
            // 
            this.nTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nTreeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.nTreeView1.Location = new System.Drawing.Point(9, 35);
            this.nTreeView1.Name = "nTreeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Node2";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Node3";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Node4";
            treeNode5.Name = "Node0";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode5.Text = "Node0";
            this.nTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.nTreeView1.Size = new System.Drawing.Size(263, 114);
            this.nTreeView1.TabIndex = 5;
            // 
            // frmConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 224);
            this.Controls.Add(this.nTreeView1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chkdisplay);
            this.Controls.Add(this.lblmsg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblmsg;
        private Nevron.UI.WinForm.Controls.NCheckBox chkdisplay;
        private Nevron.UI.WinForm.Controls.NButton btnOk;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private Nevron.UI.WinForm.Controls.NTreeView nTreeView1;
    }
}