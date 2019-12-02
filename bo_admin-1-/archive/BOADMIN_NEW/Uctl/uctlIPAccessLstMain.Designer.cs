namespace BOADMIN_NEW.Uctl
{
    partial class uctlIPAccessLstMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ui_dtgIPAccessLst = new Nevron.UI.WinForm.Controls.NDataGridView();
            this.ui_contextmnuCommon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ui_contextmnuCommonAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ui_contextmnuCommonDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ui_npnlControlContainer = new Nevron.UI.WinForm.Controls.NUIPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ui_ncmbAction = new Nevron.UI.WinForm.Controls.NComboBox();
            this.ui_lblAction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgIPAccessLst)).BeginInit();
            this.ui_contextmnuCommon.SuspendLayout();
            this.ui_npnlControlContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ui_dtgIPAccessLst
            // 
            this.ui_dtgIPAccessLst.AllowUserToAddRows = false;
            this.ui_dtgIPAccessLst.AllowUserToDeleteRows = false;
            this.ui_dtgIPAccessLst.AllowUserToOrderColumns = true;
            this.ui_dtgIPAccessLst.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            this.ui_dtgIPAccessLst.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ui_dtgIPAccessLst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ui_dtgIPAccessLst.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.ui_dtgIPAccessLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetColumnSpan(this.ui_dtgIPAccessLst, 2);
            this.ui_dtgIPAccessLst.ContextMenuStrip = this.ui_contextmnuCommon;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ui_dtgIPAccessLst.DefaultCellStyle = dataGridViewCellStyle2;
            this.ui_dtgIPAccessLst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_dtgIPAccessLst.EnableCellCustomDraw = false;
            this.ui_dtgIPAccessLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ui_dtgIPAccessLst.Location = new System.Drawing.Point(3, 33);
            this.ui_dtgIPAccessLst.MultiSelect = false;
            this.ui_dtgIPAccessLst.Name = "ui_dtgIPAccessLst";
            this.ui_dtgIPAccessLst.ReadOnly = true;
            this.ui_dtgIPAccessLst.RowHeadersVisible = false;
            this.ui_dtgIPAccessLst.RowHeadersWidth = 20;
            this.ui_dtgIPAccessLst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ui_dtgIPAccessLst.Size = new System.Drawing.Size(456, 132);
            this.ui_dtgIPAccessLst.TabIndex = 2;
            this.ui_dtgIPAccessLst.UseColumnContextMenu = false;
            this.ui_dtgIPAccessLst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ui_dtgIPAccessLst_MouseDown);
            this.ui_dtgIPAccessLst.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ui_dtgIPAccessLst_CellDoubleClick);
            // 
            // ui_contextmnuCommon
            // 
            this.ui_contextmnuCommon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ui_contextmnuCommonAdd,
            this.ui_contextmnuCommonEdit,
            this.ui_contextmnuCommonDelete});
            this.ui_contextmnuCommon.Name = "ui_contextmnuCommon";
            this.ui_contextmnuCommon.Size = new System.Drawing.Size(149, 70);
            this.ui_contextmnuCommon.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ui_contextmnuCommon_ItemClicked);
            this.ui_contextmnuCommon.Opening += new System.ComponentModel.CancelEventHandler(this.ui_contextmnuCommon_Opening);
            // 
            // ui_contextmnuCommonAdd
            // 
            this.ui_contextmnuCommonAdd.Name = "ui_contextmnuCommonAdd";
            this.ui_contextmnuCommonAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Insert)));
            this.ui_contextmnuCommonAdd.Size = new System.Drawing.Size(148, 22);
            this.ui_contextmnuCommonAdd.Text = "Add";
            // 
            // ui_contextmnuCommonEdit
            // 
            this.ui_contextmnuCommonEdit.Name = "ui_contextmnuCommonEdit";
            this.ui_contextmnuCommonEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.ui_contextmnuCommonEdit.Size = new System.Drawing.Size(148, 22);
            this.ui_contextmnuCommonEdit.Text = "Edit";
            // 
            // ui_contextmnuCommonDelete
            // 
            this.ui_contextmnuCommonDelete.Name = "ui_contextmnuCommonDelete";
            this.ui_contextmnuCommonDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.ui_contextmnuCommonDelete.Size = new System.Drawing.Size(148, 22);
            this.ui_contextmnuCommonDelete.Text = "Delete";
            // 
            // From
            // 
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            // 
            // To
            // 
            this.To.HeaderText = "To";
            this.To.Name = "To";
            this.To.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // ui_npnlControlContainer
            // 
            this.ui_npnlControlContainer.Controls.Add(this.tableLayoutPanel1);
            this.ui_npnlControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_npnlControlContainer.Location = new System.Drawing.Point(0, 0);
            this.ui_npnlControlContainer.Name = "ui_npnlControlContainer";
            this.ui_npnlControlContainer.Size = new System.Drawing.Size(464, 170);
            this.ui_npnlControlContainer.TabIndex = 3;
            this.ui_npnlControlContainer.Text = "nuiPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ui_ncmbAction, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ui_dtgIPAccessLst, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ui_lblAction, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 168);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ui_ncmbAction
            // 
            this.ui_ncmbAction.AcceptTextChangeOnReturnOnly = true;
            this.ui_ncmbAction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ui_ncmbAction.Items.AddRange(new object[] {
            new Nevron.UI.WinForm.Controls.NListBoxItem("All", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Permit", -1, false, 0, new System.Drawing.Size(0, 0)),
            new Nevron.UI.WinForm.Controls.NListBoxItem("Block", -1, false, 0, new System.Drawing.Size(0, 0))});
            this.ui_ncmbAction.ListProperties.ColumnOnLeft = false;
            this.ui_ncmbAction.Location = new System.Drawing.Point(73, 6);
            this.ui_ncmbAction.Name = "ui_ncmbAction";
            this.ui_ncmbAction.Size = new System.Drawing.Size(100, 18);
            this.ui_ncmbAction.TabIndex = 0;
            this.ui_ncmbAction.SelectedIndexChanged += new System.EventHandler(this.ui_ncmbAction_SelectedIndexChanged);
            // 
            // ui_lblAction
            // 
            this.ui_lblAction.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ui_lblAction.AutoSize = true;
            this.ui_lblAction.BackColor = System.Drawing.Color.Transparent;
            this.ui_lblAction.Location = new System.Drawing.Point(30, 8);
            this.ui_lblAction.Name = "ui_lblAction";
            this.ui_lblAction.Size = new System.Drawing.Size(37, 13);
            this.ui_lblAction.TabIndex = 1;
            this.ui_lblAction.Text = "Action";
            // 
            // uctlIPAccessLstMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_npnlControlContainer);
            this.Name = "uctlIPAccessLstMain";
            this.Size = new System.Drawing.Size(464, 170);
            this.Load += new System.EventHandler(this.uctlIPAccessLstMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ui_dtgIPAccessLst)).EndInit();
            this.ui_contextmnuCommon.ResumeLayout(false);
            this.ui_npnlControlContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NDataGridView ui_dtgIPAccessLst;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        public System.Windows.Forms.ContextMenuStrip ui_contextmnuCommon;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonAdd;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonEdit;
        private System.Windows.Forms.ToolStripMenuItem ui_contextmnuCommonDelete;
        private Nevron.UI.WinForm.Controls.NUIPanel ui_npnlControlContainer;
        private System.Windows.Forms.Label ui_lblAction;
        private Nevron.UI.WinForm.Controls.NComboBox ui_ncmbAction;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
