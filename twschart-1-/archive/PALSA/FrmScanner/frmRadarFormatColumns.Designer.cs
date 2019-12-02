using Nevron.UI.WinForm.Controls;

namespace PALSA.FrmScanner
{
    partial class frmRadarFormatColumns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadarFormatColumns));
            this.m_ImgList3 = new System.Windows.Forms.ImageList(this.components);
            this.btnAdd = new Nevron.UI.WinForm.Controls.NButton();
            this.btnRemove = new Nevron.UI.WinForm.Controls.NButton();
            this.btnEdit = new Nevron.UI.WinForm.Controls.NButton();
            this.btnOK = new Nevron.UI.WinForm.Controls.NButton();
            this.btnCancel = new Nevron.UI.WinForm.Controls.NButton();
            this.btnHelp = new Nevron.UI.WinForm.Controls.NButton();
            this.tvAll = new System.Windows.Forms.TreeView();
            this.tvCurrent = new System.Windows.Forms.TreeView();
            this.btnMoveUp = new Nevron.UI.WinForm.Controls.NButton();
            this.btnMoveDown = new Nevron.UI.WinForm.Controls.NButton();
            this.SuspendLayout();
            // 
            // m_ImgList3
            // 
            this.m_ImgList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ImgList3.ImageStream")));
            this.m_ImgList3.TransparentColor = System.Drawing.Color.Fuchsia;
            this.m_ImgList3.Images.SetKeyName(0, "Bands.bmp");
            this.m_ImgList3.Images.SetKeyName(1, "CustomIndicator.png");
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonProperties.ShowFocusRect = false;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(327, 147);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add - >";
            this.btnAdd.TransparentBackground = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.ButtonProperties.ShowFocusRect = false;
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(327, 191);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(85, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "< - Remove";
            this.btnRemove.TransparentBackground = true;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonProperties.ShowFocusRect = false;
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(160, 328);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(132, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit Easy Language ...";
            this.btnEdit.TransparentBackground = true;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnOK
            // 
            this.btnOK.ButtonProperties.ShowFocusRect = false;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(447, 357);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.TransparentBackground = true;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonProperties.ShowFocusRect = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(534, 357);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TransparentBackground = true;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnHelp
            // 
            this.btnHelp.ButtonProperties.ShowFocusRect = false;
            this.btnHelp.Location = new System.Drawing.Point(621, 357);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(82, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.TransparentBackground = true;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tvAll
            // 
            this.tvAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.tvAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tvAll.ImageIndex = 0;
            this.tvAll.ImageList = this.m_ImgList3;
            this.tvAll.LineColor = System.Drawing.Color.White;
            this.tvAll.Location = new System.Drawing.Point(22, 32);
            this.tvAll.Name = "tvAll";
            this.tvAll.SelectedImageIndex = 0;
            this.tvAll.ShowLines = false;
            this.tvAll.ShowPlusMinus = false;
            this.tvAll.ShowRootLines = false;
            this.tvAll.Size = new System.Drawing.Size(270, 286);
            this.tvAll.TabIndex = 5;
            this.tvAll.Click += new System.EventHandler(this.tvAll_Click);
            // 
            // tvCurrent
            // 
            this.tvCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.tvCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tvCurrent.ImageIndex = 0;
            this.tvCurrent.ImageList = this.m_ImgList3;
            this.tvCurrent.LineColor = System.Drawing.Color.White;
            this.tvCurrent.Location = new System.Drawing.Point(447, 32);
            this.tvCurrent.Name = "tvCurrent";
            this.tvCurrent.SelectedImageIndex = 0;
            this.tvCurrent.ShowLines = false;
            this.tvCurrent.ShowPlusMinus = false;
            this.tvCurrent.ShowRootLines = false;
            this.tvCurrent.Size = new System.Drawing.Size(256, 286);
            this.tvCurrent.TabIndex = 5;
            this.tvCurrent.Click += new System.EventHandler(this.tvCurrent_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.ButtonProperties.ShowFocusRect = false;
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Location = new System.Drawing.Point(447, 328);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(130, 23);
            this.btnMoveUp.TabIndex = 4;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.TransparentBackground = true;
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.ButtonProperties.ShowFocusRect = false;
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Location = new System.Drawing.Point(583, 328);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(120, 23);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.TransparentBackground = true;
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // frmRadarFormatColumns
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(728, 402);
            this.Controls.Add(this.tvCurrent);
            this.Controls.Add(this.tvAll);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRadarFormatColumns";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Columns";
            this.UseGlassIfEnabled = Nevron.UI.WinForm.Controls.CommonTriState.False;
            this.Load += new System.EventHandler(this.frmFormatRadarColumns_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ImageList m_ImgList3;
        private NButton btnAdd;
        private NButton btnRemove;
        private NButton btnEdit;
        private NButton btnOK;
        private NButton btnCancel;
        private NButton btnHelp;
        private System.Windows.Forms.TreeView tvAll;
        private System.Windows.Forms.TreeView tvCurrent;
        private NButton btnMoveUp;
        private NButton btnMoveDown;
    }
}