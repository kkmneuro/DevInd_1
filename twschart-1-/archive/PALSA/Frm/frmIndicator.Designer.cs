namespace PALSA.Frm
{
    partial class frmIndicator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndicator));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Indicators");
            this.nuiPanel1 = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.IndicatorImgList = new System.Windows.Forms.ImageList(this.components);
            this.nTreeView1 = new Nevron.UI.WinForm.Controls.NTreeView();
            this.nuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nuiPanel1
            // 
            this.nuiPanel1.BackColor = System.Drawing.Color.White;
            this.nuiPanel1.Controls.Add(this.btnCancel);
            this.nuiPanel1.Controls.Add(this.btnOK);
            this.nuiPanel1.Controls.Add(this.nTreeView1);
            this.nuiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nuiPanel1.Location = new System.Drawing.Point(0, 0);
            this.nuiPanel1.Name = "nuiPanel1";
            this.nuiPanel1.Size = new System.Drawing.Size(295, 447);
            this.nuiPanel1.TabIndex = 0;
            this.nuiPanel1.Text = "nuiPanel1";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(148, 411);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.ImageIndex = 1;
            this.btnOK.ImageList = this.IndicatorImgList;
            this.btnOK.Location = new System.Drawing.Point(35, 411);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // IndicatorImgList
            // 
            this.IndicatorImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IndicatorImgList.ImageStream")));
            this.IndicatorImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.IndicatorImgList.Images.SetKeyName(0, "indicator-list.png");
            this.IndicatorImgList.Images.SetKeyName(1, "Correct.png");
            // 
            // nTreeView1
            // 
            this.nTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nTreeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.nTreeView1.ImageIndex = 0;
            this.nTreeView1.ImageList = this.IndicatorImgList;
            this.nTreeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.nTreeView1.Location = new System.Drawing.Point(0, 0);
            this.nTreeView1.Name = "nTreeView1";
            treeNode1.Name = "Script_Forex";
            treeNode1.Text = "Indicators";
            this.nTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.nTreeView1.SelectedImageIndex = 0;
            this.nTreeView1.Size = new System.Drawing.Size(293, 405);
            this.nTreeView1.TabIndex = 1;
            this.nTreeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.nTreeView1_BeforeSelect);
            this.nTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.nTreeView1_AfterSelect);
            this.nTreeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nTreeView1_MouseDoubleClick);
            // 
            // frmIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(295, 447);
            this.Controls.Add(this.nuiPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIndicator";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scripts";
            this.nuiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        //System.Windows.Forms.TreeNode treeNode1;
        private Nevron.UI.WinForm.Controls.NUIPanel nuiPanel1;
        private Nevron.UI.WinForm.Controls.NTreeView nTreeView1;
        private Nevron.UI.WinForm.Controls.NButton btnCancel;
        private Nevron.UI.WinForm.Controls.NButton btnOK;
        private System.Windows.Forms.ImageList IndicatorImgList;
    }
}