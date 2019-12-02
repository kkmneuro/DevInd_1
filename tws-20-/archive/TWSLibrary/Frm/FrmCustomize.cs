///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//16/02/2012	VP		    1.Code for closing of form on Escape key
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary.Cls;
using Nevron.UI.WinForm.Controls;

namespace CommonLibrary.UserControls
{
    public partial class FrmCustomize : NForm
    {
        #region "          MEMBERS             "

        //Dictionary for storing new custome settings
        private static readonly Dictionary<string, ClsCustomizeSettings> _DDCustomizeSettings =
            new Dictionary<string, ClsCustomizeSettings>();

        private static readonly ClsMixedSettings objclsMixedSettings = new ClsMixedSettings();
        private readonly Object _obj = new Object();

        #endregion "         MEMBERS           "

        #region "         DESIGN COMPONENTS           "

        private Label label5;
        private NButton nbtnCancel;
        private NButton nbtnOk;
        private NUIPanel nuiPnl;
        private TableLayoutPanel tblLayoutpnl;
        private Label ui_lblBackColor;
        private Label ui_lblColor;
        private Label ui_lblCommonColor;
        private Label ui_lblFont;
        private Label ui_lblFontPreview;
        private Label ui_lblFontSize;
        private Label ui_lblFontStyle;
        private Label ui_lblForeColor;
        private Label ui_lblLayoutSelectView;
        private Label ui_lblSelectView;
        private NComboBox ui_ncmbFontStyle;
        private NFontListBox ui_nflstFont;
        private NListBox ui_nlstColor;
        private NListBox ui_nlstLayoutAttributes;
        private NListBox ui_nlstLayoutViews;
        private NListBox ui_nlstSelectViewFont;
        private NTabControl ui_ntbCustomize;
        private NTabPage ui_ntbCustomizeColor;
        private NTabPage ui_ntbCustomizeFont;
        private NTabPage ui_ntbCustomizeLayout;
        private NNumericUpDown ui_nudFontSize;

        private void InitializeComponent()
        {
            nuiPnl = new NUIPanel();
            tblLayoutpnl = new TableLayoutPanel();
            nbtnOk = new NButton();
            nbtnCancel = new NButton();
            ui_ntbCustomize = new NTabControl();
            ui_ntbCustomizeColor = new NTabPage();
            ui_ncbtColor = new NColorButton();
            ui_ncbtnForegroundColor = new NColorButton();
            ui_ncbtnBackgroundColor = new NColorButton();
            ui_lblCommonColor = new Label();
            ui_lblForeColor = new Label();
            ui_lblBackColor = new Label();
            ui_nlstColor = new NListBox();
            ui_lblColor = new Label();
            ui_ntbCustomizeLayout = new NTabPage();
            ui_nlstLayoutAttributes = new NListBox();
            label5 = new Label();
            ui_nlstLayoutViews = new NListBox();
            ui_lblLayoutSelectView = new Label();
            ui_ntbCustomizeFont = new NTabPage();
            ui_ncmbFontStyle = new NComboBox();
            ui_nudFontSize = new NNumericUpDown();
            ui_lblFontSize = new Label();
            ui_lblFontStyle = new Label();
            ui_lblFont = new Label();
            ui_nflstFont = new NFontListBox();
            ui_nlstSelectViewFont = new NListBox();
            ui_lblSelectView = new Label();
            ui_ndgvPreview = new NDataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            ui_lblFontPreview = new Label();
            nuiPnl.SuspendLayout();
            tblLayoutpnl.SuspendLayout();
            ui_ntbCustomize.SuspendLayout();
            ui_ntbCustomizeColor.SuspendLayout();
            ui_ntbCustomizeLayout.SuspendLayout();
            ui_ntbCustomizeFont.SuspendLayout();
            ((ISupportInitialize)(ui_nudFontSize)).BeginInit();
            ((ISupportInitialize)(ui_ndgvPreview)).BeginInit();
            SuspendLayout();
            // 
            // nuiPnl
            // 
            nuiPnl.Controls.Add(tblLayoutpnl);
            nuiPnl.Location = new Point(0, 2);
            nuiPnl.Name = "nuiPnl";
            nuiPnl.Size = new Size(327, 419);
            nuiPnl.TabIndex = 3;
            nuiPnl.Text = "nuiPanel1";
            // 
            // tblLayoutpnl
            // 
            tblLayoutpnl.BackColor = Color.Transparent;
            tblLayoutpnl.ColumnCount = 4;
            tblLayoutpnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,
                                                          46.70209F));
            tblLayoutpnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,
                                                          29.90818F));
            tblLayoutpnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,
                                                          23.38973F));
            tblLayoutpnl.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,
                                                          85F));
            tblLayoutpnl.Controls.Add(nbtnOk, 2, 3);
            tblLayoutpnl.Controls.Add(nbtnCancel, 3, 3);
            tblLayoutpnl.Controls.Add(ui_ntbCustomize, 0, 0);
            tblLayoutpnl.Controls.Add(ui_ndgvPreview, 0, 2);
            tblLayoutpnl.Controls.Add(ui_lblFontPreview, 0, 1);
            tblLayoutpnl.Dock = DockStyle.Fill;
            tblLayoutpnl.Location = new Point(0, 0);
            tblLayoutpnl.Name = "tblLayoutpnl";
            tblLayoutpnl.RowCount = 4;
            tblLayoutpnl.RowStyles.Add(new RowStyle(SizeType.Percent,
                                                    65.46763F));
            tblLayoutpnl.RowStyles.Add(new RowStyle(SizeType.Percent,
                                                    5.035971F));
            tblLayoutpnl.RowStyles.Add(new RowStyle(SizeType.Percent,
                                                    22.30216F));
            tblLayoutpnl.RowStyles.Add(new RowStyle(SizeType.Percent,
                                                    6.954436F));
            tblLayoutpnl.Size = new Size(325, 417);
            tblLayoutpnl.TabIndex = 1;
            // 
            // nbtnOk
            // 
            nbtnOk.Anchor = AnchorStyles.None;
            nbtnOk.Location = new Point(186, 390);
            nbtnOk.Name = "nbtnOk";
            nbtnOk.Size = new Size(50, 23);
            nbtnOk.TabIndex = 8;
            nbtnOk.Text = "Ok";
            nbtnOk.UseVisualStyleBackColor = false;
            nbtnOk.Click += nbtnOk_Click;
            // 
            // nbtnCancel
            // 
            nbtnCancel.Anchor = AnchorStyles.None;
            nbtnCancel.DialogResult = DialogResult.Cancel;
            nbtnCancel.Location = new Point(256, 390);
            nbtnCancel.Name = "nbtnCancel";
            nbtnCancel.Size = new Size(52, 23);
            nbtnCancel.TabIndex = 9;
            nbtnCancel.Text = "Cancel";
            nbtnCancel.UseVisualStyleBackColor = false;
            nbtnCancel.Click += nbtnCancel_Click;
            // 
            // ui_ntbCustomize
            // 
            tblLayoutpnl.SetColumnSpan(ui_ntbCustomize, 4);
            ui_ntbCustomize.Controls.Add(ui_ntbCustomizeColor);
            ui_ntbCustomize.Controls.Add(ui_ntbCustomizeLayout);
            ui_ntbCustomize.Controls.Add(ui_ntbCustomizeFont);
            ui_ntbCustomize.Dock = DockStyle.Fill;
            ui_ntbCustomize.Location = new Point(3, 3);
            ui_ntbCustomize.Name = "ui_ntbCustomize";
            ui_ntbCustomize.Padding = new Padding(4, 29, 4, 4);
            ui_ntbCustomize.Selectable = true;
            ui_ntbCustomize.SelectedIndex = 0;
            ui_ntbCustomize.Size = new Size(319, 267);
            ui_ntbCustomize.TabIndex = 0;
            // 
            // ui_ntbCustomizeColor
            // 
            ui_ntbCustomizeColor.Controls.Add(ui_ncbtColor);
            ui_ntbCustomizeColor.Controls.Add(ui_ncbtnForegroundColor);
            ui_ntbCustomizeColor.Controls.Add(ui_ncbtnBackgroundColor);
            ui_ntbCustomizeColor.Controls.Add(ui_lblCommonColor);
            ui_ntbCustomizeColor.Controls.Add(ui_lblForeColor);
            ui_ntbCustomizeColor.Controls.Add(ui_lblBackColor);
            ui_ntbCustomizeColor.Controls.Add(ui_nlstColor);
            ui_ntbCustomizeColor.Controls.Add(ui_lblColor);
            ui_ntbCustomizeColor.Location = new Point(4, 29);
            ui_ntbCustomizeColor.Name = "ui_ntbCustomizeColor";
            ui_ntbCustomizeColor.Size = new Size(311, 234);
            ui_ntbCustomizeColor.TabIndex = 0;
            ui_ntbCustomizeColor.Text = "Color";
            ui_ntbCustomizeColor.Paint += ui_ntbCustomizeColor_Paint;
            // 
            // ui_ncbtColor
            // 
            ui_ncbtColor.ArrowClickOptions = false;
            ui_ncbtColor.ArrowWidth = 14;
            ui_ncbtColor.Location = new Point(162, 124);
            ui_ncbtColor.Name = "ui_ncbtColor";
            ui_ncbtColor.Size = new Size(144, 21);
            ui_ncbtColor.TabIndex = 4;
            ui_ncbtColor.UseVisualStyleBackColor = false;
            ui_ncbtColor.ColorChanged += ui_ncbtColor_ColorChanged;
            // 
            // ui_ncbtnForegroundColor
            // 
            ui_ncbtnForegroundColor.ArrowClickOptions = false;
            ui_ncbtnForegroundColor.ArrowWidth = 14;
            ui_ncbtnForegroundColor.Location = new Point(162, 83);
            ui_ncbtnForegroundColor.Name = "ui_ncbtnForegroundColor";
            ui_ncbtnForegroundColor.Size = new Size(144, 21);
            ui_ncbtnForegroundColor.TabIndex = 3;
            ui_ncbtnForegroundColor.UseVisualStyleBackColor = false;
            ui_ncbtnForegroundColor.ColorChanged += ui_ncbtnForegroundColor_ColorChanged;
            // 
            // ui_ncbtnBackgroundColor
            // 
            ui_ncbtnBackgroundColor.ArrowClickOptions = false;
            ui_ncbtnBackgroundColor.ArrowWidth = 14;
            ui_ncbtnBackgroundColor.Location = new Point(162, 38);
            ui_ncbtnBackgroundColor.Name = "ui_ncbtnBackgroundColor";
            ui_ncbtnBackgroundColor.Size = new Size(144, 21);
            ui_ncbtnBackgroundColor.TabIndex = 2;
            ui_ncbtnBackgroundColor.UseVisualStyleBackColor = false;
            ui_ncbtnBackgroundColor.ColorChanged += ui_ncbtnBackgroundColor_ColorChanged;
            // 
            // ui_lblCommonColor
            // 
            ui_lblCommonColor.AutoSize = true;
            ui_lblCommonColor.Location = new Point(159, 109);
            ui_lblCommonColor.Name = "ui_lblCommonColor";
            ui_lblCommonColor.Size = new Size(37, 13);
            ui_lblCommonColor.TabIndex = 46;
            ui_lblCommonColor.Text = "Color :";
            // 
            // ui_lblForeColor
            // 
            ui_lblForeColor.AutoSize = true;
            ui_lblForeColor.Location = new Point(162, 68);
            ui_lblForeColor.Name = "ui_lblForeColor";
            ui_lblForeColor.Size = new Size(94, 13);
            ui_lblForeColor.TabIndex = 23;
            ui_lblForeColor.Text = "Foreground Color :";
            // 
            // ui_lblBackColor
            // 
            ui_lblBackColor.AutoSize = true;
            ui_lblBackColor.Location = new Point(162, 24);
            ui_lblBackColor.Name = "ui_lblBackColor";
            ui_lblBackColor.Size = new Size(98, 13);
            ui_lblBackColor.TabIndex = 22;
            ui_lblBackColor.Text = "Background Color :";
            // 
            // ui_nlstColor
            // 
            ui_nlstColor.ColumnOnLeft = false;
            ui_nlstColor.Items.AddRange(new object[]
                                            {
                                                new NListBoxItem("Grid", -1, false, 0,
                                                                 new Size(0, 0))
                                                ,
                                                new NListBoxItem("GridLine", -1, false, 0,
                                                                 new Size(0, 0))
                                            });
            ui_nlstColor.Location = new Point(6, 21);
            ui_nlstColor.Name = "ui_nlstColor";
            ui_nlstColor.Size = new Size(135, 204);
            ui_nlstColor.TabIndex = 1;
            ui_nlstColor.SelectedIndexChanged += ui_nlstColor_SelectedIndexChanged;
            // 
            // ui_lblColor
            // 
            ui_lblColor.AutoSize = true;
            ui_lblColor.ImeMode = ImeMode.NoControl;
            ui_lblColor.Location = new Point(2, 5);
            ui_lblColor.Name = "ui_lblColor";
            ui_lblColor.Size = new Size(115, 13);
            ui_lblColor.TabIndex = 14;
            ui_lblColor.Text = "Select View Elements :";
            // 
            // ui_ntbCustomizeLayout
            // 
            ui_ntbCustomizeLayout.Controls.Add(ui_nlstLayoutAttributes);
            ui_ntbCustomizeLayout.Controls.Add(label5);
            ui_ntbCustomizeLayout.Controls.Add(ui_nlstLayoutViews);
            ui_ntbCustomizeLayout.Controls.Add(ui_lblLayoutSelectView);
            ui_ntbCustomizeLayout.Location = new Point(4, 29);
            ui_ntbCustomizeLayout.Name = "ui_ntbCustomizeLayout";
            ui_ntbCustomizeLayout.Size = new Size(311, 234);
            ui_ntbCustomizeLayout.TabIndex = 1;
            ui_ntbCustomizeLayout.Text = "Layout";
            // 
            // ui_nlstLayoutAttributes
            // 
            ui_nlstLayoutAttributes.CheckBoxes = true;
            ui_nlstLayoutAttributes.CheckOnClick = true;
            ui_nlstLayoutAttributes.ColumnOnLeft = false;
            ui_nlstLayoutAttributes.Location = new Point(138, 22);
            ui_nlstLayoutAttributes.Name = "ui_nlstLayoutAttributes";
            ui_nlstLayoutAttributes.SelectionMode = SelectionMode.MultiSimple;
            ui_nlstLayoutAttributes.Size = new Size(169, 204);
            ui_nlstLayoutAttributes.TabIndex = 1;
            ui_nlstLayoutAttributes.CheckedChanged +=
                ui_nlstLayoutAttributes_CheckedChanged;
            ui_nlstLayoutAttributes.SelectedIndexChanged +=
                ui_nlstLayoutAttributes_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(142, 7);
            label5.Name = "label5";
            label5.Size = new Size(85, 13);
            label5.TabIndex = 18;
            label5.Text = "Select Attribute :";
            // 
            // ui_nlstLayoutViews
            // 
            ui_nlstLayoutViews.ColumnOnLeft = false;
            ui_nlstLayoutViews.Items.AddRange(new object[]
                                                  {
                                                      new NListBoxItem("Grid", -1, false, 0,
                                                                       new Size(0, 0))
                                                  });
            ui_nlstLayoutViews.Location = new Point(3, 22);
            ui_nlstLayoutViews.Name = "ui_nlstLayoutViews";
            ui_nlstLayoutViews.Size = new Size(129, 204);
            ui_nlstLayoutViews.TabIndex = 0;
            ui_nlstLayoutViews.SelectedIndexChanged += ui_nlstLayoutViews_SelectedIndexChanged;
            // 
            // ui_lblLayoutSelectView
            // 
            ui_lblLayoutSelectView.AutoSize = true;
            ui_lblLayoutSelectView.ImeMode = ImeMode.NoControl;
            ui_lblLayoutSelectView.Location = new Point(3, 5);
            ui_lblLayoutSelectView.Name = "ui_lblLayoutSelectView";
            ui_lblLayoutSelectView.Size = new Size(115, 13);
            ui_lblLayoutSelectView.TabIndex = 17;
            ui_lblLayoutSelectView.Text = "Select View Elements :";
            // 
            // ui_ntbCustomizeFont
            // 
            ui_ntbCustomizeFont.Controls.Add(ui_ncmbFontStyle);
            ui_ntbCustomizeFont.Controls.Add(ui_nudFontSize);
            ui_ntbCustomizeFont.Controls.Add(ui_lblFontSize);
            ui_ntbCustomizeFont.Controls.Add(ui_lblFontStyle);
            ui_ntbCustomizeFont.Controls.Add(ui_lblFont);
            ui_ntbCustomizeFont.Controls.Add(ui_nflstFont);
            ui_ntbCustomizeFont.Controls.Add(ui_nlstSelectViewFont);
            ui_ntbCustomizeFont.Controls.Add(ui_lblSelectView);
            ui_ntbCustomizeFont.Location = new Point(4, 29);
            ui_ntbCustomizeFont.Name = "ui_ntbCustomizeFont";
            ui_ntbCustomizeFont.Size = new Size(311, 234);
            ui_ntbCustomizeFont.TabIndex = 2;
            ui_ntbCustomizeFont.Text = "Font";
            // 
            // ui_ncmbFontStyle
            // 
            ui_ncmbFontStyle.Enabled = false;
            ui_ncmbFontStyle.ListProperties.ColumnOnLeft = false;
            ui_ncmbFontStyle.Location = new Point(66, 202);
            ui_ncmbFontStyle.Name = "ui_ncmbFontStyle";
            ui_ncmbFontStyle.Size = new Size(95, 22);
            ui_ncmbFontStyle.TabIndex = 3;
            ui_ncmbFontStyle.Text = "--Select--";
            ui_ncmbFontStyle.SelectedIndexChanged += ui_ncmbFontStyle_SelectedIndexChanged;
            // 
            // ui_nudFontSize
            // 
            ui_nudFontSize.Enabled = false;
            ui_nudFontSize.Location = new Point(244, 203);
            ui_nudFontSize.Maximum = new decimal(new[]
                                                     {
                                                         24,
                                                         0,
                                                         0,
                                                         0
                                                     });
            ui_nudFontSize.Minimum = new decimal(new[]
                                                     {
                                                         8,
                                                         0,
                                                         0,
                                                         0
                                                     });
            ui_nudFontSize.Name = "ui_nudFontSize";
            ui_nudFontSize.Size = new Size(61, 20);
            ui_nudFontSize.TabIndex = 4;
            ui_nudFontSize.Value = new decimal(new[]
                                                   {
                                                       8,
                                                       0,
                                                       0,
                                                       0
                                                   });
            ui_nudFontSize.ValueChanged += ui_nudFontSize_ValueChanged;
            // 
            // ui_lblFontSize
            // 
            ui_lblFontSize.AutoSize = true;
            ui_lblFontSize.ImeMode = ImeMode.NoControl;
            ui_lblFontSize.Location = new Point(209, 206);
            ui_lblFontSize.Name = "ui_lblFontSize";
            ui_lblFontSize.Size = new Size(33, 13);
            ui_lblFontSize.TabIndex = 27;
            ui_lblFontSize.Text = "Size :";
            // 
            // ui_lblFontStyle
            // 
            ui_lblFontStyle.AutoSize = true;
            ui_lblFontStyle.ImeMode = ImeMode.NoControl;
            ui_lblFontStyle.Location = new Point(6, 205);
            ui_lblFontStyle.Name = "ui_lblFontStyle";
            ui_lblFontStyle.Size = new Size(60, 13);
            ui_lblFontStyle.TabIndex = 26;
            ui_lblFontStyle.Text = "Font Style :";
            // 
            // ui_lblFont
            // 
            ui_lblFont.AutoSize = true;
            ui_lblFont.ImeMode = ImeMode.NoControl;
            ui_lblFont.Location = new Point(160, 7);
            ui_lblFont.Name = "ui_lblFont";
            ui_lblFont.Size = new Size(34, 13);
            ui_lblFont.TabIndex = 25;
            ui_lblFont.Text = "Font :";
            // 
            // ui_nflstFont
            // 
            ui_nflstFont.DisplayStyle = FontDisplayStyle.NameAndSample;
            ui_nflstFont.DrawMode = DrawMode.OwnerDrawVariable;
            ui_nflstFont.Enabled = false;
            ui_nflstFont.Location = new Point(162, 23);
            ui_nflstFont.Name = "ui_nflstFont";
            ui_nflstFont.Size = new Size(145, 164);
            ui_nflstFont.Sorted = true;
            ui_nflstFont.TabIndex = 2;
            ui_nflstFont.SelectedIndexChanged += ui_nflstFont_SelectedIndexChanged;
            // 
            // ui_nlstSelectViewFont
            // 
            ui_nlstSelectViewFont.ColumnOnLeft = false;
            ui_nlstSelectViewFont.Items.AddRange(new object[]
                                                     {
                                                         new NListBoxItem("Grid", -1, false,
                                                                          0,
                                                                          new Size(0, 0))
                                                     });
            ui_nlstSelectViewFont.Location = new Point(4, 25);
            ui_nlstSelectViewFont.MultiColumn = true;
            ui_nlstSelectViewFont.Name = "ui_nlstSelectViewFont";
            ui_nlstSelectViewFont.Size = new Size(152, 164);
            ui_nlstSelectViewFont.TabIndex = 1;
            ui_nlstSelectViewFont.SelectedIndexChanged +=
                ui_nlstSelectViewFont_SelectedIndexChanged;
            // 
            // ui_lblSelectView
            // 
            ui_lblSelectView.AutoSize = true;
            ui_lblSelectView.ImeMode = ImeMode.NoControl;
            ui_lblSelectView.Location = new Point(3, 7);
            ui_lblSelectView.Name = "ui_lblSelectView";
            ui_lblSelectView.Size = new Size(115, 13);
            ui_lblSelectView.TabIndex = 20;
            ui_lblSelectView.Text = "Select View Elements :";
            // 
            // ui_ndgvPreview
            // 
            ui_ndgvPreview.AllowUserToAddRows = false;
            ui_ndgvPreview.BackgroundColor = Color.FromArgb(((((225)))),
                                                            ((((225)))),
                                                            ((((225)))));
            ui_ndgvPreview.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ui_ndgvPreview.Columns.AddRange(new DataGridViewColumn[]
                                                {
                                                    Column1,
                                                    Column2,
                                                    Column3
                                                });
            tblLayoutpnl.SetColumnSpan(ui_ndgvPreview, 4);
            ui_ndgvPreview.Dock = DockStyle.Fill;
            ui_ndgvPreview.EnableCellCustomDraw = false;
            ui_ndgvPreview.EnableHeadersVisualStyles = false;
            ui_ndgvPreview.GridColor = Color.FromArgb(((((180)))), ((((180)))),
                                                      ((((180)))));
            ui_ndgvPreview.Location = new Point(3, 297);
            ui_ndgvPreview.Name = "ui_ndgvPreview";
            ui_ndgvPreview.Size = new Size(319, 87);
            ui_ndgvPreview.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            // 
            // ui_lblFontPreview
            // 
            ui_lblFontPreview.AutoSize = true;
            tblLayoutpnl.SetColumnSpan(ui_lblFontPreview, 4);
            ui_lblFontPreview.Dock = DockStyle.Fill;
            ui_lblFontPreview.Location = new Point(3, 273);
            ui_lblFontPreview.Name = "ui_lblFontPreview";
            ui_lblFontPreview.Size = new Size(319, 21);
            ui_lblFontPreview.TabIndex = 39;
            ui_lblFontPreview.Text = "Preview ";
            ui_lblFontPreview.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmCustomize
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 420);
            Controls.Add(nuiPnl);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCustomize";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Customize Grid";
            Load += FrmCustomize_Load;
            KeyDown += FrmCustomize_KeyDown;
            nuiPnl.ResumeLayout(false);
            tblLayoutpnl.ResumeLayout(false);
            tblLayoutpnl.PerformLayout();
            ui_ntbCustomize.ResumeLayout(false);
            ui_ntbCustomizeColor.ResumeLayout(false);
            ui_ntbCustomizeColor.PerformLayout();
            ui_ntbCustomizeLayout.ResumeLayout(false);
            ui_ntbCustomizeLayout.PerformLayout();
            ui_ntbCustomizeFont.ResumeLayout(false);
            ui_ntbCustomizeFont.PerformLayout();
            ((ISupportInitialize)(ui_nudFontSize)).EndInit();
            ((ISupportInitialize)(ui_ndgvPreview)).EndInit();
            ResumeLayout(false);
        }

        #endregion "         DESIGN COMPONENTS           "

        #region "            CONSTRUCTOR           "

        /// <summary>
        ///  Constructor for initilizing the components of the customize 
        /// </summary>
        /// <param name="obj"></param>
        public FrmCustomize(Object obj)
        {
            _obj = obj;
            InitializeComponent();
        }

        #endregion "          CONSTRUCTOR            "

        #region "            METHODS           "

        /// <summary>
        /// Method to be called whene the customize form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCustomize_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn item in ((UctlGrid)_obj).Columns)
            {
                if (!_DDCustomizeSettings.ContainsKey(item.Name))
                    _DDCustomizeSettings.Add(item.Name, new ClsCustomizeSettings());
            }

            SetDefaultDataToGrid();
            SetDefaultValueToPreviewGrid();
            //LoadColorOnComboBox();

            ui_ncmbFontStyle.Items.AddRange(Enum.GetNames(typeof(FontStyle)));
            ui_nlstColor.SelectedIndex = 0;
            ui_nlstLayoutViews.SelectedIndex = 0;
            ui_nlstSelectViewFont.SelectedIndex = 0;
            this.ShowCaptionImage = false;
            this.ShowIcon = false;
        }

        private void SetDefaultValueToPreviewGrid()
        {
            ((UctlGrid)_obj).EnableCellCustomDraw = false;
            ui_ndgvPreview.Font = ((UctlGrid)_obj).Font;
            ui_ndgvPreview.BackgroundColor = ((UctlGrid)_obj).BackgroundColor;
            ui_ndgvPreview.ForeColor = ((UctlGrid)_obj).GridForeColor;
            ui_ndgvPreview.GridColor = ((UctlGrid)_obj).DataGridLineColor;
            ui_ndgvPreview.AllowUserToAddRows = ((UctlGrid)_obj).AllowUserToAddRows;
            ui_ndgvPreview.RowHeadersVisible = ((UctlGrid)_obj).IsRowHeadersVisible;
            ui_ndgvPreview.ColumnHeadersVisible = ((UctlGrid)_obj).ColumnHeadersVisible;
            ui_ndgvPreview.AllowUserToResizeColumns = ((UctlGrid)_obj).AllowUserToResizeColumns;
            ui_ndgvPreview.CellBorderStyle = ((UctlGrid)_obj).DataGridCellBorderStyle;
            ui_ndgvPreview.ColumnHeadersDefaultCellStyle = ((UctlGrid)_obj).ColumnHeadersCellStyle;
        }

        /// <summary>
        /// Method for adding default data to the grid
        /// </summary>
        public void SetDefaultDataToGrid()
        {
            ui_ndgvPreview.Rows.Add("abc", "ABC", "123");
        }

        /// <summary>
        /// Method for adding items to list related to grid layout
        /// </summary>
        private void SetGridLayoutListAttributes()
        {
            //ui_nlstLayoutAttributes.Items.Add("NotAllowUserToAddRow");
            ui_nlstLayoutAttributes.Items.Add("ColumnHeadersInVisible");
            ui_nlstLayoutAttributes.Items.Add("RowHeadersInVisible");
            ui_nlstLayoutAttributes.Items.Add("DisableColumnResizing");
            ui_nlstLayoutAttributes.Items.Add("GridLineInvisible");
        }

        /// <summary>
        /// Method for populating items in the ColorComboBox of the customize control
        /// </summary>
        public void LoadColorOnComboBox()
        {
            // ui_ncbtnBackgroundColor.PopulateWebColors();
            // ui_ncbtnForegroundColor.PopulateWebColors();
            //ui_ncbtColor.PopulateWebColors();
        }
                
        /// <summary>
        /// Method called for setting customize property to the called grid
        /// </summary>
        private void SetCustomizeProperties()
        {
            ((UctlGrid)_obj).EnableCellCustomDraw = false;
            ((UctlGrid)_obj).Font = ui_ndgvPreview.Font;
            ((UctlGrid)_obj).BackgroundColor = ui_ndgvPreview.BackgroundColor;
            ((UctlGrid)_obj).RowsDefaultCellStyle.BackColor = ui_ndgvPreview.BackgroundColor;
            ((UctlGrid)_obj).DefaultCellStyle.BackColor = ui_ndgvPreview.BackgroundColor;//Namo
            ((UctlGrid)_obj).GridForeColor = ui_ndgvPreview.ForeColor;
            ((UctlGrid)_obj).DataGridLineColor = ui_ndgvPreview.GridColor;
            ((UctlGrid)_obj).AllowUserToAddRows = ui_ndgvPreview.AllowUserToAddRows;
            ((UctlGrid)_obj).IsRowHeadersVisible = ui_ndgvPreview.RowHeadersVisible;
            ((UctlGrid)_obj).ColumnHeadersVisible = ui_ndgvPreview.ColumnHeadersVisible;
            ((UctlGrid)_obj).AllowUserToResizeColumns = ui_ndgvPreview.AllowUserToResizeColumns;
            ((UctlGrid)_obj).DataGridCellBorderStyle = ui_ndgvPreview.CellBorderStyle;
            ((UctlGrid)_obj).setColumnHeaderStyle(ui_ndgvPreview.ColumnHeadersDefaultCellStyle);            
            DataGridViewRow r = ui_ndgvPreview.Rows[0];
            foreach (DataGridViewRow row in ((UctlGrid)_obj).Rows)
            {
                row.Height = Convert.ToInt32(ui_nudFontSize.Value) + 7;
                UctlMarketWatch.GridFontSize = row.Height;
                //var objFont = new Font(ui_nflstFont.SelectedFontName, (float)(ui_nudFontSize.Value),
                //                 (FontStyle)
                //                 Enum.Parse(typeof(FontStyle),
                //                            ui_ncmbFontStyle.SelectedItem.ToString()));
                // ((UctlGrid)_obj).setRowFont(row.Index, ui_ndgvPreview.Font.FontFamily.ToString(), ui_ndgvPreview.Font.Size, ui_ndgvPreview.Font.Style);
                //((UctlGrid)_obj).Font = objFont;
                ((UctlGrid)_obj).ColumnHeaderHeight = row.Height + 12;
            }
            if (((UctlGrid)_obj).Rows.Count > 0 && UctlMarketWatch.GridFontSize > 22)
            {
                ((UctlGrid)_obj).ColumnHeaderHeight = UctlMarketWatch.GridFontSize + 4;
            }
            else if (((UctlGrid)_obj).Rows.Count==0)
            {
                UctlMarketWatch.GridFontSize = Convert.ToInt32(ui_nudFontSize.Value)+7;                
                ((UctlGrid)_obj).ColumnHeaderHeight = UctlMarketWatch.GridFontSize + 6;               
            }
            
            //SetColumnsCustomizeProperties();
        }

        /// <summary>
        /// Method for seting customize properties to the columns fo the grid
        /// </summary>
        private void SetColumnsCustomizeProperties()
        {
            foreach (var item in _DDCustomizeSettings)
            {
                string fontName = item.Value.FontName;
                FontStyle fontStyle = item.Value.FontStyle;
                float fontSize = item.Value.FontSize;

                if (item.Value.HeaderText != null)
                    ((UctlGrid)_obj).Columns[item.Key].HeaderText = item.Value.HeaderText;
                if (item.Value.BackColor != Color.FromArgb(0, 0, 0))
                    ((UctlGrid)_obj).Columns[item.Key].DefaultCellStyle.BackColor = item.Value.BackColor;
                if (item.Value.ForeColor != Color.FromArgb(0, 0, 0))
                    ((UctlGrid)_obj).Columns[item.Key].DefaultCellStyle.ForeColor = item.Value.ForeColor;

                if (item.Value.FontName == null && ((UctlGrid)_obj).Columns[item.Key].DefaultCellStyle.Font == null)
                {
                    fontName = ((UctlGrid)_obj).Font.FontFamily.Name;
                }
                else if (item.Value.FontName == null)
                {
                    fontName = ((UctlGrid)_obj).Columns[item.Key].DefaultCellStyle.Font.FontFamily.Name;
                }
                if (item.Value.FontSize == 0.0)
                    fontSize = ((UctlGrid)_obj).Font.Size;
                //if (item.Value.FontStyle !=null)
                //    fontStyle = item.Value.FontStyle;

                var objFont = new Font(fontName, fontSize, fontStyle);

                ((UctlGrid)_obj).Columns[item.Key].DefaultCellStyle.Font = objFont;
            }
        }

        /// <summary>
        /// Called for to set the customize properties to the grid & there columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nbtnOk_Click(object sender, EventArgs e)
        {
            SetCustomizeProperties();
            Close();
        }

        private void ui_nbtnSetFont_Click(object sender, EventArgs e)
        {
        }

        private void nCmbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Method called whene the selected item in the nFlstFont is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nflstFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedView = ui_nlstSelectViewFont.SelectedItem.ToString();
            string[] fontStyleArr= Enum.GetNames(typeof (FontStyle));
            List<string> supportedStyles=new List<string>();
            foreach(string style in fontStyleArr)
            {
                try
                {

                    Font objFont = new Font(ui_nflstFont.SelectedFontName, (float) (ui_nudFontSize.Value),
                                            (FontStyle)
                                            Enum.Parse(typeof (FontStyle),
                                                       style));
                    supportedStyles.Add(style);
                }
                catch (ArgumentException)
                {
                    
                }
            }
            ui_ncmbFontStyle.Items.Clear();
            ui_ncmbFontStyle.Items.AddRange(supportedStyles.ToArray());
            ui_ncmbFontStyle.SelectedIndex = 0;
            //try
            //{

                Font objFont1 = new Font(ui_nflstFont.SelectedFontName, (float)(ui_nudFontSize.Value),
                                        (FontStyle)
                                        Enum.Parse(typeof(FontStyle),
                                                   ui_ncmbFontStyle.SelectedItem.ToString()));
                switch (selectedView)
                {
                    case "Grid":
                        ui_ndgvPreview.Font = objFont1;
                        break;
                    default:
                        ui_ndgvPreview.Columns[0].DefaultCellStyle.Font = objFont1;
                        _DDCustomizeSettings[ui_nlstSelectViewFont.SelectedItem.ToString()].FontName =
                            ui_nflstFont.SelectedFontName;
                        break;
                }
            //}
            //catch (ArgumentException)
            //{
            //    MessageBox.Show("Please change the font style this font " + ui_nflstFont.SelectedFontName + " does not suport " + ui_ncmbFontStyle.SelectedItem.ToString() + " style.");
            //    return;
            //}

        }


        /// <summary>
        /// Method called whene the selected item in the ncmbFontStyle is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncmbFontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedView = ui_nlstSelectViewFont.SelectedItem.ToString();
            try
            {
            var objFont = new Font(ui_nflstFont.SelectedFontName, (float)(ui_nudFontSize.Value),
                                   (FontStyle)
                                   Enum.Parse(typeof(FontStyle),
                                              ui_ncmbFontStyle.SelectedItem.ToString()));
            switch (selectedView)
            {
                case "Grid":
                    ui_ndgvPreview.Font = objFont;
                    break;
                default:
                    ui_ndgvPreview.Columns[0].DefaultCellStyle.Font = objFont;
                    _DDCustomizeSettings[ui_nlstSelectViewFont.SelectedItem.ToString()].FontStyle =
                        (FontStyle)Enum.Parse(typeof(FontStyle), ui_ncmbFontStyle.SelectedItem.ToString());
                    break;
            }
                        }
            catch (ArgumentException)
            {
                MessageBox.Show("Please change the font style this font " + ui_nflstFont.SelectedFontName + " does not suport " + ui_ncmbFontStyle.SelectedItem.ToString() + " style.");
                return;
            }
        }

        /// <summary>
        /// Method called whene the the value of the numeric updown(nudFontSize) control is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nudFontSize_ValueChanged(object sender, EventArgs e)
        {
            string selectedView = ui_nlstSelectViewFont.SelectedItem.ToString();
            var objFont = new Font(ui_nflstFont.SelectedFontName, (float)(ui_nudFontSize.Value),
                                   (FontStyle)
                                   Enum.Parse(typeof(FontStyle),
                                              ui_ncmbFontStyle.SelectedItem.ToString()));
            switch (selectedView)
            {
                case "Grid":
                    ui_ndgvPreview.Font = objFont;
                    break;
                default:
                    ui_ndgvPreview.Columns[0].DefaultCellStyle.Font = objFont;
                    _DDCustomizeSettings[ui_nlstSelectViewFont.SelectedItem.ToString()].FontSize =
                        (float)(ui_nudFontSize.Value);
                    break;
            }
        }

        /// <summary>
        /// Method called whene the selected item in the nlstSelectViewFont is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstSelectViewFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ncmbFontStyle.SelectedIndex = 0;
            ui_nflstFont.Enabled = true;
            ui_ncmbFontStyle.Enabled = true;
            ui_nudFontSize.Enabled = true;

            string viewName = ui_nlstSelectViewFont.SelectedItem.ToString();
            switch (viewName)
            {
                case "Grid":
                    ui_nflstFont.SelectedFontName = ((UctlGrid)_obj).Font.FontFamily.Name;
                    ui_ncmbFontStyle.SelectedItem = ((UctlGrid)_obj).Font.Style.ToString();
                    ui_nudFontSize.Value = Convert.ToDecimal(((UctlGrid)_obj).Font.Size);
                    break;
                default:
                    if (((UctlGrid)_obj).Columns[viewName].DefaultCellStyle.Font != null)
                    {
                        ui_nflstFont.SelectedFontName =
                            ((UctlGrid)_obj).Columns[viewName].DefaultCellStyle.Font.FontFamily.Name;
                        ui_ncmbFontStyle.SelectedItem =
                            ((UctlGrid)_obj).Columns[viewName].DefaultCellStyle.Font.Style.ToString();
                        ui_nudFontSize.Value =
                            Convert.ToDecimal(((UctlGrid)_obj).Columns[viewName].DefaultCellStyle.Font.Size);
                    }
                    break;
            }
        }

        private void ui_ntbCustomizeColor_Paint(object sender, PaintEventArgs e)
        {
        }

        //int iRowIndex = -1;
        //int iColumnIndex = -1;
        private void nbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Method called whene the selected item in the ui_nlstColor is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ResetColorSettings();


            if (ui_nlstColor.SelectedItem.ToString() == "GridLine" ||
                ui_nlstColor.SelectedItem.ToString() == "AlertTriggerColor" ||
                ui_nlstColor.SelectedItem.ToString() == "UpTrendColor" ||
                ui_nlstColor.SelectedItem.ToString() == "DownTrendColor")
            {
                ui_ncbtnBackgroundColor.Enabled = false;
                ui_ncbtnForegroundColor.Enabled = false;
                ui_ncbtColor.Enabled = true;
            }
            else
            {
                ui_ncbtnBackgroundColor.Enabled = true;
                ui_ncbtnForegroundColor.Enabled = true;
                ui_ncbtColor.Enabled = false;
            }

            string viewName = ui_nlstColor.SelectedItem.ToString();
            switch (viewName)
            {
                case "Grid":
                    if (((UctlGrid)_obj).RowsDefaultCellStyle.BackColor.Name == "0")
                    {
                        ui_ncbtnBackgroundColor.Color = ((UctlGrid)_obj).DefaultCellStyle.BackColor;// Color.Black;
                        ui_ncbtnForegroundColor.Color = ((UctlGrid)_obj).DefaultCellStyle.ForeColor;//Color.White;
                    }
                    else
                    {
                        ui_ncbtnBackgroundColor.Color = ((UctlGrid)_obj).BackgroundColor;
                        ui_ncbtnForegroundColor.Color = ((UctlGrid)_obj).GridForeColor;
                    }
                    break;
                case "GridLine":
                    ui_ncbtColor.Color = ((UctlGrid)_obj).DataGridLineColor;
                    break;
                case "UpTrendColor":
                    ui_ncbtColor.Color = objclsMixedSettings.UpTrendcolor;
                    break;
                case "DownTrendColor":
                    ui_ncbtColor.Color = objclsMixedSettings.DownTrendColor;
                    break;
                default:
                    if (((UctlGrid)_obj).Columns[viewName] != null)
                    {
                        if (((UctlGrid)_obj).Columns[viewName].DefaultCellStyle.BackColor != null)
                        {
                            ui_ncbtnBackgroundColor.Color =
                                ((UctlGrid)_obj).Columns[viewName].DefaultCellStyle.BackColor;
                            ui_ncbtnForegroundColor.Color =
                                ((UctlGrid)_obj).Columns[viewName].DefaultCellStyle.ForeColor;
                        }
                    }
                    break;
            }
        }

        private void ResetColorSettings()
        {
            ui_ncbtnBackgroundColor.Color = ui_ncbtnBackgroundColor.DefaultBaseBorderColor;
            ui_ncbtnForegroundColor.Color = ui_ncbtnForegroundColor.DefaultBaseBorderColor;
            ui_ncbtColor.Color = ui_ncbtColor.DefaultBaseBorderColor;
        }

        /// <summary>
        /// Method called whene the selected item in the ui_nlstLayoutViews is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstLayoutViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_nlstLayoutAttributes.Items.Count == 0)
                SetGridLayoutListAttributes();

            //if (((uctlGrid)_obj).AllowUserToAddRows == false)
            //{
            //    ui_nlstLayoutAttributes.Items["NotAllowUserToAddRow"].Checked = true;
            //}

            if (((UctlGrid)_obj).IsRowHeadersVisible == false)
            {
                ui_nlstLayoutAttributes.Items["RowHeadersInVisible"].Checked = true;
            }

            if (((UctlGrid)_obj).ColumnHeadersVisible == false)
            {
                ui_nlstLayoutAttributes.Items["ColumnHeadersInVisible"].Checked = true;
            }

            if (((UctlGrid)_obj).AllowUserToResizeColumns == false)
            {
                ui_nlstLayoutAttributes.Items["DisableColumnResizing"].Checked = true;
            }

            if (((UctlGrid)_obj).DataGridCellBorderStyle == DataGridViewCellBorderStyle.None)
            {
                ui_nlstLayoutAttributes.Items["GridLineInvisible"].Checked = true;
            }
        }


        private void ui_nlstLayoutAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Method called whene the item of the ui_nlstLayoutAttributes list is checked or unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_nlstLayoutAttributes_CheckedChanged(object sender, NListBoxItemCheckEventArgs e)
        {
            //if (ui_nlstLayoutAttributes.Items["NotAllowUserToAddRow"].Checked == true)
            //{
            //    ui_ndgvPreview.AllowUserToAddRows = false;
            //}
            //else
            //{
            //    ui_ndgvPreview.AllowUserToAddRows = true;
            //}

            if (ui_nlstLayoutAttributes.Items["ColumnHeadersInVisible"].Checked)
            {
                ui_ndgvPreview.ColumnHeadersVisible = false;
            }
            else
            {
                ui_ndgvPreview.ColumnHeadersVisible = true;
            }

            if (ui_nlstLayoutAttributes.Items["RowHeadersInVisible"].Checked)
            {
                ui_ndgvPreview.RowHeadersVisible = false;
            }
            else
            {
                ui_ndgvPreview.RowHeadersVisible = true;
            }

            if (ui_nlstLayoutAttributes.Items["DisableColumnResizing"].Checked)
            {
                ui_ndgvPreview.AllowUserToResizeColumns = false;
            }
            else
            {
                ui_ndgvPreview.AllowUserToResizeColumns = true;
            }

            if (ui_nlstLayoutAttributes.Items["GridLineInvisible"].Checked)
            {
                ui_ndgvPreview.CellBorderStyle = DataGridViewCellBorderStyle.None;
            }
            else
            {
                ui_ndgvPreview.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
        }

        ///// <summary>
        ///// Method called whene the selected item in the ui_cmbColStyles is changed
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ui_cmbColStyles_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
        //    if (ui_cmbColStyles.SelectedIndex == 0)
        //    {
        //        columnHeaderStyle.BackColor = Color.Beige;
        //        columnHeaderStyle.ForeColor = Color.White;
        //        columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        //        ui_ndgvPreview.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
        //    }
        //    else if (ui_cmbColStyles.SelectedIndex == 1)
        //    {
        //        columnHeaderStyle.BackColor = Color.Brown;
        //        columnHeaderStyle.ForeColor = Color.Red;
        //        columnHeaderStyle.Font = new Font("Microsoft sun sarif", 11, FontStyle.Italic);
        //        ui_ndgvPreview.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
        //    }
        //    else if (ui_cmbColStyles.SelectedIndex == 2)
        //    {
        //        columnHeaderStyle.BackColor = Color.Black;
        //        columnHeaderStyle.ForeColor = Color.White;
        //        columnHeaderStyle.Font = new Font("Consolas", 10, FontStyle.Underline);
        //        ui_ndgvPreview.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
        //    }
        //    else
        //    {
        //        ui_ndgvPreview.EnableHeaderCustomDraw = true;
        //        ui_ndgvPreview.EnableHeadersVisualStyles = true;
        //    }
        //}
        ///// <summary>
        ///// Method called whene the selected item in the ui_nlstInVisibleColumns is changed
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ui_nlstInVisibleColumns_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ui_nlstInVisibleColumns.SelectedItem != null)
        //    {
        //        ui_ntxtColHeaderText.Text = ((uctlGrid)_obj).Columns[ui_nlstInVisibleColumns.SelectedItem.ToString()].HeaderText;
        //    }
        //}
        ///// <summary>
        /////Called on ok button click to store the change text for columns
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ui_nbtnChangeText_Click(object sender, EventArgs e)
        //{
        //    if (ui_nlstColumns.SelectedItem != null)
        //    {
        //        _DDCustomizeSettings[ui_nlstColumns.SelectedItem.ToString()].HeaderText = ui_ntxtColHeaderText.Text;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select the column to which hedertext has to be changed!!");
        //        ui_nlstColumns.Focus();
        //    }
        //}

        /// <summary>
        /// Method called whene the selected item in the ui_ncbtnBackgroundColor is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncbtnBackgroundColor_ColorChanged(object sender, EventArgs e)
        {
            try
            {
                string viewName = ui_nlstColor.SelectedItem.ToString();
                switch (viewName)
                {
                    case "Grid":
                        ui_ndgvPreview.BackgroundColor = ui_ncbtnBackgroundColor.Color;
                        ui_ndgvPreview.RowsDefaultCellStyle.BackColor = ui_ncbtnBackgroundColor.Color;
                        break;
                    default:
                        _DDCustomizeSettings[ui_nlstColor.SelectedItem.ToString()].Name =
                            ui_nlstColor.SelectedItem.ToString();
                        ui_ndgvPreview.Columns[0].DefaultCellStyle.BackColor = ui_ncbtnBackgroundColor.Color;
                        _DDCustomizeSettings[ui_nlstColor.SelectedItem.ToString()].BackColor =
                            ui_ncbtnBackgroundColor.Color;
                        break;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Method called whene the selected item in the ui_ncbtnForegroundColor is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncbtnForegroundColor_ColorChanged(object sender, EventArgs e)
        {
            if (ui_nlstColor.SelectedItem != null)
            {
                try
                {
                    string viewName = ui_nlstColor.SelectedItem.ToString();
                    switch (viewName)
                    {
                        case "Grid":
                            ui_ndgvPreview.ForeColor = ui_ncbtnForegroundColor.Color;
                            break;
                        default:
                            ui_ndgvPreview.Columns[0].DefaultCellStyle.ForeColor = ui_ncbtnForegroundColor.Color;
                            _DDCustomizeSettings[ui_nlstColor.SelectedItem.ToString()].ForeColor =
                                ui_ncbtnForegroundColor.Color;
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Method called whene the selected item in the ui_ncbtColor is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ncbtColor_ColorChanged(object sender, EventArgs e)
        {
            switch (ui_nlstColor.SelectedItem.ToString())
            {
                case "GridLine":
                    ui_ndgvPreview.GridColor = ui_ncbtColor.Color;
                    break;
                case "AlertTriggerColor":
                    objclsMixedSettings.AlertTriggerColor = ui_ncbtColor.Color;
                    break;
                case "UpTrendColor":
                    objclsMixedSettings.UpTrendcolor = ui_ncbtColor.Color;
                    break;
                case "DownTrendColor":
                    objclsMixedSettings.DownTrendColor = ui_ncbtColor.Color;
                    break;
                case "ViewColor":
                    objclsMixedSettings.ViewColor = ui_ncbtColor.Color;
                    break;
            }
        }

        #endregion "          METHODS         "

        private void FrmCustomize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Close();
        }

        //private void ui_nbtnMoveUp_Click(object sender, EventArgs e)
        //{
        //   int selIndex= ui_nlstColumns.SelectedIndex;
        //   if (selIndex != 0)
        //   {
        //       NListBoxItem item = ui_nlstColumns.Items[selIndex];
        //       ui_nlstColumns.Items.RemoveAt(selIndex);
        //       ui_nlstColumns.Items.Insert(selIndex - 1, item);
        //   }
        //   else
        //   {
        //       MessageBox.Show("This is first item in List can not move up!!!");
        //   }
        //}

        //private void ui_nbtnMoveDown_Click(object sender, EventArgs e)
        //{
        //    int selIndex = ui_nlstColumns.SelectedIndex;
        //    if (selIndex != ui_nlstColumns.Items.Count-1)
        //    {
        //        NListBoxItem item = ui_nlstColumns.Items[selIndex];
        //        ui_nlstColumns.Items.RemoveAt(selIndex);
        //        ui_nlstColumns.Items.Insert(selIndex + 1, item);
        //    }
        //    else
        //    {
        //        MessageBox.Show("This is Last item in List can not move down!!!");
        //    }
        //}
    }
}