using Nevron.UI.WinForm.Controls;

namespace PALSA.uctl
{
    partial class ctlRadarMain
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
            this.tcRadarPages = new Nevron.UI.WinForm.Controls.NTabControl();
            this.nMenuBar = new Nevron.UI.WinForm.Controls.NMenuBar();
            this.menuFile = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuNewPage = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuSave = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuSaveSelectedSymbols = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuSaveTemplate = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuLoad = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuLoadSymbolList = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuLoadTemplate = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuEdit = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuAddItem = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuAddSymbol = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuAddIndicator = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuRemove = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuDeleteRows = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuDeletePage = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuEditTemplate = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuChangeTimeFrame = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuFindSymbol = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuInsert = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuLabelRow = new Nevron.UI.WinForm.Controls.NCommand();
            this.menuBlankRow = new Nevron.UI.WinForm.Controls.NCommand();
            this.nCommandBarsManager1 = new Nevron.UI.WinForm.Controls.NCommandBarsManager(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nCommand1 = new Nevron.UI.WinForm.Controls.NCommand();
            this.nCommand2 = new Nevron.UI.WinForm.Controls.NCommand();
            this.nCommand3 = new Nevron.UI.WinForm.Controls.NCommand();
            ((System.ComponentModel.ISupportInitialize)(this.nCommandBarsManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcRadarPages
            // 
            this.tcRadarPages.AllowTabReorder = true;
            this.tcRadarPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcRadarPages.Location = new System.Drawing.Point(3, 23);
            this.tcRadarPages.Name = "tcRadarPages";
            this.tcRadarPages.Padding = new System.Windows.Forms.Padding(4, 4, 4, 24);
            this.tcRadarPages.Selectable = true;
            this.tcRadarPages.SelectedIndex = -1;
            this.tcRadarPages.ShowToolTips = false;
            this.tcRadarPages.Size = new System.Drawing.Size(844, 470);
            this.tcRadarPages.TabAlign = Nevron.UI.WinForm.Controls.TabAlign.Bottom;
            this.tcRadarPages.TabIndex = 1;
            this.tcRadarPages.SelectedTabChanged += new System.EventHandler(this.TcRadarPagesSelectedTabChanged);
            this.tcRadarPages.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.TcRadarPagesControlRemoved);
            // 
            // nMenuBar
            // 
            this.nMenuBar.AllowDelete = false;
            this.nMenuBar.AllowHide = false;
            this.nMenuBar.AutoDropDownDelay = false;
            this.nMenuBar.BackgroundType = Nevron.UI.WinForm.Controls.BackgroundType.Transparent;
            this.nMenuBar.CanDock = false;
            this.nMenuBar.CanDockBottom = false;
            this.nMenuBar.CanDockLeft = false;
            this.nMenuBar.CanDockRight = false;
            this.nMenuBar.CanFloat = false;
            this.nMenuBar.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.menuFile,
            this.menuEdit,
            this.menuInsert});
            this.nMenuBar.DefaultCommandStyle = Nevron.UI.WinForm.Controls.CommandStyle.Text;
            this.nMenuBar.DefaultLocation = new System.Drawing.Point(0, 0);
            this.nMenuBar.HasGripper = false;
            this.nMenuBar.HasPendantCommand = false;
            this.nMenuBar.MdiEnabled = false;
            this.nMenuBar.Moveable = false;
            this.nMenuBar.Name = "nMenuBar";
            this.nMenuBar.PrefferedRowIndex = 0;
            this.nMenuBar.RowIndex = 0;
            this.nMenuBar.ShowTooltips = false;
            this.nMenuBar.Text = "Menu Bar";
            // 
            // menuFile
            // 
            this.menuFile.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.menuNewPage,
            this.menuSave,
            this.menuLoad});
            this.menuFile.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuFile.Properties.Text = "File";
            // 
            // menuNewPage
            // 
            this.menuNewPage.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(78, 131072);
            this.menuNewPage.Properties.Text = "New Radar View Page";
            this.menuNewPage.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuNewPageClick);
            // 
            // menuSave
            // 
            this.menuSave.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.menuSaveSelectedSymbols,
            this.menuSaveTemplate});
            this.menuSave.Properties.Text = "Save";
            // 
            // menuSaveSelectedSymbols
            // 
            this.menuSaveSelectedSymbols.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(83, 131072);
            this.menuSaveSelectedSymbols.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuSaveSelectedSymbols.Properties.Text = "Active Symbols";
            this.menuSaveSelectedSymbols.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuSaveSelectedSymbolsClick);
            // 
            // menuSaveTemplate
            // 
            this.menuSaveTemplate.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(83, 393216);
            this.menuSaveTemplate.Properties.Text = "Active Template";
            this.menuSaveTemplate.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuSaveTemplateClick);
            // 
            // menuLoad
            // 
            this.menuLoad.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.menuLoadSymbolList,
            this.menuLoadTemplate});
            this.menuLoad.Properties.Text = "Load";
            // 
            // menuLoadSymbolList
            // 
            this.menuLoadSymbolList.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(76, 131072);
            this.menuLoadSymbolList.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuLoadSymbolList.Properties.Text = "Symbol List";
            this.menuLoadSymbolList.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuLoadSymbolListClick);
            // 
            // menuLoadTemplate
            // 
            this.menuLoadTemplate.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(76, 393216);
            this.menuLoadTemplate.Properties.Text = "Template";
            this.menuLoadTemplate.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuLoadTemplateClick);
            // 
            // menuEdit
            // 
            this.menuEdit.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.menuAddItem,
            this.menuRemove,
            this.menuEditTemplate,
            this.menuChangeTimeFrame,
            this.menuFindSymbol});
            this.menuEdit.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuEdit.Properties.Text = "Edit";
            // 
            // menuAddItem
            // 
            this.menuAddItem.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.menuAddSymbol,
            this.menuAddIndicator});
            this.menuAddItem.Properties.Text = "Add";
            // 
            // menuAddSymbol
            // 
            this.menuAddSymbol.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(65, 196608);
            this.menuAddSymbol.Properties.Text = "Symbol(s) to page";
            this.menuAddSymbol.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuAddSymbolClick);
            // 
            // menuAddIndicator
            // 
            this.menuAddIndicator.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(73, 196608);
            this.menuAddIndicator.Properties.Text = "Indicator(s) to page";
            this.menuAddIndicator.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuAddIndicatorClick);
            // 
            // menuRemove
            // 
            this.menuRemove.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.menuDeleteRows,
            this.menuDeletePage});
            this.menuRemove.Properties.Text = "Remove";
            // 
            // menuDeleteRows
            // 
            this.menuDeleteRows.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(82, 196608);
            this.menuDeleteRows.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuDeleteRows.Properties.Text = "Selected row(s)";
            this.menuDeleteRows.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuDeleteRowsClick);
            // 
            // menuDeletePage
            // 
            this.menuDeletePage.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(46, 196608);
            this.menuDeletePage.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuDeletePage.Properties.Text = "Current RadarView page";
            this.menuDeletePage.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuDeletePageClick);
            // 
            // menuEditTemplate
            // 
            this.menuEditTemplate.Properties.Text = "Radar View template";
            this.menuEditTemplate.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuEditTemplateClick);
            // 
            // menuChangeTimeFrame
            // 
            this.menuChangeTimeFrame.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuChangeTimeFrame.Properties.Text = "Change time frame(s)";
            this.menuChangeTimeFrame.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuChangeTimeFrameClick);
            // 
            // menuFindSymbol
            // 
            this.menuFindSymbol.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(70, 131072);
            this.menuFindSymbol.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuFindSymbol.Properties.Text = "Find symbol";
            this.menuFindSymbol.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuFindSymbolClick);
            // 
            // menuInsert
            // 
            this.menuInsert.Commands.AddRange(new Nevron.UI.WinForm.Controls.NCommand[] {
            this.menuLabelRow,
            this.menuBlankRow});
            this.menuInsert.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuInsert.Properties.Text = "Insert";
            // 
            // menuLabelRow
            // 
            this.menuLabelRow.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(76, 196608);
            this.menuLabelRow.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuLabelRow.Properties.Text = "Label Row";
            this.menuLabelRow.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuLabelRowClick);
            // 
            // menuBlankRow
            // 
            this.menuBlankRow.Properties.Shortcut = new Nevron.UI.WinForm.Controls.NShortcut(66, 196608);
            this.menuBlankRow.Properties.ShowArrowStyle = Nevron.UI.WinForm.Controls.ShowArrowStyle.Never;
            this.menuBlankRow.Properties.Text = "Blank Row";
            this.menuBlankRow.Click += new Nevron.UI.WinForm.Controls.CommandEventHandler(this.MenuBlankRowClick);
            // 
            // nCommandBarsManager1
            // 
            this.nCommandBarsManager1.ParentControl = this;
            this.nCommandBarsManager1.Toolbars.Add(this.nMenuBar);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tcRadarPages, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(850, 496);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ctlRadarMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ctlRadarMain";
            this.Size = new System.Drawing.Size(850, 496);
            this.VisibleChanged += new System.EventHandler(this.ctlRadarMain_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.nCommandBarsManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Nevron.UI.WinForm.Controls.NTabControl tcRadarPages;
        private NCommandBarsManager nCommandBarsManager1;
        private NMenuBar nMenuBar;
        private NCommand menuFile;
        private NCommand menuSaveSelectedSymbols;
        private NCommand menuLoadSymbolList;
        private NCommand menuEdit;
        private NCommand menuDeletePage;
        private NCommand menuDeleteRows;
        private NCommand menuChangeTimeFrame;
        private NCommand menuFindSymbol;
        private NCommand menuInsert;
        private NCommand menuLabelRow;
        private NCommand menuBlankRow;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private NCommand menuNewPage;
        private NCommand menuAddItem;
        private NCommand menuAddSymbol;
        private NCommand menuAddIndicator;
        private NCommand menuEditTemplate;
        private NCommand menuSaveTemplate;
        private NCommand menuLoadTemplate;
        private NCommand menuSave;
        private NCommand nCommand1;
        private NCommand menuLoad;
        private NCommand nCommand2;
        private NCommand menuRemove;
        private NCommand nCommand3;
    }
}
