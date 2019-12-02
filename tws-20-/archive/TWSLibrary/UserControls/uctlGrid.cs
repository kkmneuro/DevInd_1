///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION	
//02/02/2012	VP		    1.Commenting of the code
//07/02/2012	VP		    1.Added SizeToFit and Grid menu items in GriddropDown menu and defined there functionality
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Nevron.UI.WinForm.Controls;

namespace CommonLibrary.UserControls
{
    public partial class UctlGrid : UctlBase
    {
        private int _iColIndex = -1;
        private int _iRowIndex = -1;
        DataGridView.HitTestInfo _HitTest;


        /// <summary>
        /// Gets the selected rows of the datagridview
        /// </summary>
        public DataGridView.HitTestInfo HitTest
        {
            get { return _HitTest; }
        }

        /// <summary>
        /// Gets and Sets the DefaultCellStyle of the DatagridView
        /// </summary>
        public DataGridViewCellStyle DataRowStyle
        {
            get { return ui_ndgvGrid.DefaultCellStyle; }
            set { ui_ndgvGrid.DefaultCellStyle = value; }
        }

        /// <summary>
        /// Gets the selected rows of the datagridview
        /// </summary>
        public DataGridViewSelectedRowCollection SelectedRows
        {
            get { return ui_ndgvGrid.SelectedRows; }
        }

        /// <summary>
        /// Gets and sets the FirstDisplayedScrollingRowIndex in datagridview
        /// </summary>
        public int FirstDisplayedScrollingRowIndex { get; set; }

        /// <summary>
        /// Gets and sets the ColumnHeadersHeight in datagridview
        /// </summary>
        public int ColumnHeadersHeight { get; set; }

        #region "Properties"

        /// <summary>
        /// This property sets the VirtualMode value of grid
        /// </summary>
        public bool VirtualMode
        {
            set { ui_ndgvGrid.VirtualMode = value; }
        }

        /// <summary>
        /// This property gets and sets the height of grid column header
        /// </summary>
        [Category("Control Specific")]
        public int ColumnHeaderHeight
        {
            get { return ui_ndgvGrid.ColumnHeadersHeight; }
            set { ui_ndgvGrid.ColumnHeadersHeight = value; }
        }

        /// <summary>
        /// This property gets and sets the height of grid row header
        /// </summary>
        [Category("Control Specific")]
        public int RowHeight
        {
            get { return ui_ndgvGrid.RowTemplate.Height; }
            set { ui_ndgvGrid.RowTemplate.Height = value; }
        }

        /// <summary>
        /// This property Sets the value indicating user have option to add rows
        /// </summary>
        [Category("Control Specific")]
        public bool AllowUserToAddRows
        {
            set { ui_ndgvGrid.AllowUserToAddRows = value; }
            get { return ui_ndgvGrid.AllowUserToAddRows; }
        }

        /// <summary>
        /// This property Sets the value indicating user have option to delete rows
        /// </summary>
        [Category("Control Specific")]
        public bool AllowUserToDeleteRows
        {
            set { ui_ndgvGrid.AllowUserToDeleteRows = value; }
            get { return ui_ndgvGrid.AllowUserToDeleteRows; }
        }

        /// <summary>
        /// This property Sets the value indicating whether manual column ordering is enabled
        /// </summary>
        [Category("Control Specific")]
        public bool AllowUserToOrderColumns
        {
            set { ui_ndgvGrid.AllowUserToOrderColumns = value; }
            get { return ui_ndgvGrid.AllowUserToOrderColumns; }
        }

        /// <summary>
        /// This property Sets the value indicating whether user have option to resize columns
        /// </summary>
        [Category("Control Specific")]
        public bool AllowUserToResizeColumns
        {
            set { ui_ndgvGrid.AllowUserToResizeColumns = value; }
            get { return ui_ndgvGrid.AllowUserToResizeColumns; }
        }

        /// <summary>
        /// This property Sets the value indicating whether user have option to resize rows
        /// </summary>
        [Category("Control Specific")]
        public bool AllowUserToResizeRows
        {
            set { ui_ndgvGrid.AllowUserToResizeRows = value; }
            get { return ui_ndgvGrid.AllowUserToResizeRows; }
        }

        /// <summary>
        /// This property Sets the style of AlternatingRowsDefaultCell in datagridview
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewCellStyle AlternatingRowStyle
        {
            set { ui_ndgvGrid.AlternatingRowsDefaultCellStyle = value; }
            get { return ui_ndgvGrid.AlternatingRowsDefaultCellStyle; }
        }

        /// <summary>
        /// This property Sets the value of automatic resize of columns size according to the data
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewAutoSizeColumnsMode AutoSizeColumsMode
        {
            set { ui_ndgvGrid.AutoSizeColumnsMode = value; }
            get { return ui_ndgvGrid.AutoSizeColumnsMode; }
        }

        /// <summary>
        /// This property Sets the value of automatic resize of rows size according to the data
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewAutoSizeRowsMode AutoSizeRowsMode
        {
            set { ui_ndgvGrid.AutoSizeRowsMode = value; }
            get { return ui_ndgvGrid.AutoSizeRowsMode; }
        }

        /// <summary>
        ///  This property Sets and Gets the style of the Border of the datagridveiw
        /// </summary>
        [Category("Control Specific")]
        public BorderStyle DataGridBorderStyle
        {
            set { ui_ndgvGrid.BorderStyle = value; }
            get { return ui_ndgvGrid.BorderStyle; }
        }

        /// <summary>
        /// This property Sets and Gets the style of the Border of the datagridveiw cells
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewCellBorderStyle DataGridCellBorderStyle
        {
            set { ui_ndgvGrid.CellBorderStyle = value; }
            get { return ui_ndgvGrid.CellBorderStyle; }
        }

        /// <summary>
        /// This proerty sets whether use is able to copy the text of header,cells of datagridview or not
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewClipboardCopyMode ClipBoardCopyMode
        {
            set { ui_ndgvGrid.ClipboardCopyMode = value; }
            get { return ui_ndgvGrid.ClipboardCopyMode; }
        }

        /// <summary>
        /// This property Sets and Gets the style of the Border of the datagridveiw column header cells
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
        {
            set { ui_ndgvGrid.ColumnHeadersBorderStyle = value; }
            get { return ui_ndgvGrid.ColumnHeadersBorderStyle; }
        }

        /// <summary>
        /// This property Sets and Gets the style of the datagridveiw column header cells
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewCellStyle ColumnHeadersCellStyle
        {
            set { ui_ndgvGrid.ColumnHeadersDefaultCellStyle = value; }
            get { return ui_ndgvGrid.ColumnHeadersDefaultCellStyle; }
        }

        /// <summary>
        /// This property is used to adjust of height of the column headers
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
        {
            set { ui_ndgvGrid.ColumnHeadersHeightSizeMode = value; }
            get { return ui_ndgvGrid.ColumnHeadersHeightSizeMode; }
        }

        /// <summary>
        /// This property specify whether the datagridveiw columns header row is visible or not
        /// </summary>
        [Category("Control Specific")]
        public bool ColumnHeadersVisible
        {
            get { return ui_ndgvGrid.ColumnHeadersVisible; }
            set { ui_ndgvGrid.ColumnHeadersVisible = value; }
        }

        /// <summary>
        /// This property specify the style to be applied on the cells of datagridview if not cell style is used
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewCellStyle DefaultCellStyle
        {
            set { ui_ndgvGrid.DefaultCellStyle = value; }
            get { return ui_ndgvGrid.DefaultCellStyle; }
        }

        /// <summary>
        /// This property specifies the mode that determines how the cell editing is started
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewEditMode DataGridEditMode
        {
            set { ui_ndgvGrid.EditMode = value; }
            get { return ui_ndgvGrid.EditMode; }
        }

        /// <summary>
        /// Nevron Property : This property specifies whether datagridview cells will be painted using Palette logic
        /// </summary>
        [Category("Control Specific")]
        public bool EnableCellCustomDraw
        {
            set
            {
                if (ui_ndgvGrid.InvokeRequired == false)
                {
                    ui_ndgvGrid.EnableCellCustomDraw = value;
                }
            }
            get { return ui_ndgvGrid.EnableCellCustomDraw; }
        }

        /// <summary>
        /// Nevron Property : This property specifies whether datagridview header will be painted using Palette logic
        /// </summary>
        [Category("Control Specific")]
        public bool EnableHeaderCustomDraw
        {
            set
            {
                if (ui_ndgvGrid.InvokeRequired == false)
                    ui_ndgvGrid.EnableHeaderCustomDraw = value;
            }
            get { return ui_ndgvGrid.EnableHeaderCustomDraw; }
        }

        /// <summary>
        /// Nevron Property : This property specifies whether row and column headers use the visual style of user current themes 
        /// </summary>
        [Category("Control Specific")]
        public bool EnableHeadersVisualStyles
        {
            set
            {
                if (ui_ndgvGrid.InvokeRequired == false)
                    ui_ndgvGrid.EnableHeadersVisualStyles = value;
            }
            get { return ui_ndgvGrid.EnableHeadersVisualStyles; }
        }

        /// <summary>
        /// Nevron Property : This property specifies whether datagridview use skining logic
        /// </summary>
        [Category("Control Specific")]
        public bool EnableSkinning
        {
            set { ui_ndgvGrid.EnableSkinning = value; }
            get { return ui_ndgvGrid.EnableSkinning; }
        }

        /// <summary>
        /// This property sets and gets the color of the gridlines separating the grid cells
        /// </summary>
        [Category("Control Specific")]
        public Color DataGridLineColor
        {
            set { ui_ndgvGrid.GridColor = value; }
            get { return ui_ndgvGrid.GridColor; }
        }

        /// <summary>
        /// This property sets and gets indicating whether use is able to select more than one datagridview cell,row or column at a time
        /// </summary>
        [Category("Control Specific")]
        public bool EnableMultiSelect
        {
            set { ui_ndgvGrid.MultiSelect = value; }
            get { return ui_ndgvGrid.MultiSelect; }
        }

        /// <summary>
        /// Nevron Property : This property gets and sets the palette used with datagridview
        /// </summary>
        [Category("Control Specific")]
        public NPalette GridPalette
        {
            set
            {
                if (value != null)
                    ui_ndgvGrid.Palette = value;
            }
            get { return ui_ndgvGrid.Palette; }
        }

        /// <summary>
        /// This property gets/sets indicates whether user can edit the datagridview cells
        /// </summary>
        [Category("Control Specific")]
        public bool IsGridReadOnly
        {
            set { ui_ndgvGrid.ReadOnly = value; }
            get { return ui_ndgvGrid.ReadOnly; }
        }

        /// <summary>
        /// This property sets the the border style of row header cells
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewHeaderBorderStyle RowHeadersBorderStyle
        {
            set { ui_ndgvGrid.RowHeadersBorderStyle = value; }
            get { return ui_ndgvGrid.RowHeadersBorderStyle; }
        }

        /// <summary>
        /// This property sets the the defualt style of row header cells
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewCellStyle RowHeadersDefaultCellStyle
        {
            set { ui_ndgvGrid.RowHeadersDefaultCellStyle = value; }
            get { return ui_ndgvGrid.RowHeadersDefaultCellStyle; }
        }

        /// <summary>
        /// This property sets whether column containing row headers is visible
        /// </summary>
        [Category("Control Specific")]
        public bool IsRowHeadersVisible
        {
            set { ui_ndgvGrid.RowHeadersVisible = value; }
            get { return ui_ndgvGrid.RowHeadersVisible; }
        }

        /// <summary>
        /// This property sets and gets for adjusting the row headers width
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode
        {
            set { ui_ndgvGrid.RowHeadersWidthSizeMode = value; }
            get { return ui_ndgvGrid.RowHeadersWidthSizeMode; }
        }

        /// <summary>
        /// This property sets and gets the default style to be used with the the datagridview cells
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewCellStyle RowsDefaultCellStyle
        {
            set { ui_ndgvGrid.RowsDefaultCellStyle = value; }
            get { return ui_ndgvGrid.RowsDefaultCellStyle; }
        }

        /// <summary>
        /// This property sets the type of scroll bars to be used with the datagridview
        /// </summary>
        [Category("Control Specific")]
        public ScrollBars DataGridScrollBars
        {
            set { ui_ndgvGrid.ScrollBars = value; }
            get { return ui_ndgvGrid.ScrollBars; }
        }

        /// <summary>
        /// This property gets and sets indicating how the cells of the datagridview is to be selected
        /// </summary>
        [Category("Control Specific")]
        public DataGridViewSelectionMode DataGridSelectMode
        {
            set { ui_ndgvGrid.SelectionMode = value; }
            get { return ui_ndgvGrid.SelectionMode; }
        }

        /// <summary>
        /// This property sets indicating whether the datagridview is visible or hidden
        /// </summary>
        [Category("Control Specific")]
        public bool IsGridVisible
        {
            set { ui_ndgvGrid.Visible = value; }
            get { return ui_ndgvGrid.Visible; }
        }

        //End of vijay code

        ///// <summary>
        ///// This property sets indicating whether the datagridview is enabled
        ///// </summary>
        //public bool Enabled
        //{
        //    get { return ndgvGrid.Enabled; }
        //    set { ndgvGrid.Enabled = value; }
        //}
        /// <summary>
        /// This property gets the column of the datagridview
        /// </summary>
        public DataGridViewColumnCollection Columns
        {
            get { return ui_ndgvGrid.Columns; }
        }

        /// <summary>
        /// This property gets the rows of the datagridview
        /// </summary>
        public DataGridViewRowCollection Rows
        {
            get { return ui_ndgvGrid.Rows; }
        }

        /// <summary>
        /// This property sets and gets the source of data associated with the datagridview
        /// </summary>
        public object DataSource
        {
            get { return ui_ndgvGrid.DataSource; }
            set
            {
                try
                {
                    if (value!=null)
                    {
                       // ui_ndgvGrid.DataSource = null;
                        ui_ndgvGrid.DataSource = value; 
                    }
                  
                }
                catch (Exception)
                {
                    
                    
                }
               
            }
        }

        /// <summary>
        /// This property sets and gets the current clicked cells  row index
        /// </summary>
        public int IRowIndex
        {
            get { return _iRowIndex; }
            set { _iRowIndex = value; }
        }

        /// <summary>
        /// This property sets and gets the current clicked cells column index
        /// </summary>
        public int IColIndex
        {
            get { return _iColIndex; }
            set { _iColIndex = value; }
        }

        /// <summary>
        /// This property sets and gets the background color of the datagridview
        /// </summary>
        public Color BackgroundColor
        {
            get { return ui_ndgvGrid.BackgroundColor; }
            set
            {
                if (value == Color.Empty)
                    ui_ndgvGrid.BackgroundColor = Color.FromArgb(225, 225, 225);
                else
                    ui_ndgvGrid.BackgroundColor = value;
            }
        }

        public Color GridForeColor
        {
            get { return ui_ndgvGrid.ForeColor; }
            set { ui_ndgvGrid.ForeColor = value; }
        }

        #endregion

        #region "Constructor"

        public UctlGrid()
        {
            InitializeComponent();
            ui_ndgvGrid.AutoGenerateColumns = false;
            DoubleBuffered = true;
        }

        //public uctlGrid(DataTable dt, ContextMenuStrip cms)
        //{
        //    InitializeComponent();
        //    DataSource = dt;
        //    ndgvGrid.DataSource = dt;
        //    ndgvGrid.ContextMenuStrip = cms;
        //    //GenerateRandom();
        //}

        #endregion

        #region "Methods"

        /// <summary>
        /// Adds the specified datagridviewrow to the collection
        /// </summary>
        /// <param name="dgvRow"></param>
        public void AppendRow(DataGridViewRow dgvRow)
        {
            ui_ndgvGrid.Rows.Add(dgvRow);
        }

        /// <summary>
        /// Adds a new row to the collection
        /// </summary>
        public void AppendRow()
        {
            ui_ndgvGrid.Rows.Add();
        }

        /// <summary>
        /// Adds specified no of new rows to the collection
        /// </summary>
        /// <param name="noOfRows"></param>
        public void AppendRow(int noOfRows)
        {
            ui_ndgvGrid.Rows.Add(noOfRows);
        }

        /// <summary>
        /// Adds the given column to the collection
        /// </summary>
        /// <param name="columnsArrayolumn"></param>
        public void AddColumn(DataGridViewColumn columnsArrayolumn)
        {
            ui_ndgvGrid.Columns.Add(columnsArrayolumn);
        }

        /// <summary>
        /// Adds list of TextBoxColumn with the given column name and headertext
        /// </summary>
        /// <param name="columnsArrayolumns">Array of datagridview columns</param>
        public void AddColumns(DataGridViewColumn[] columnsArrayolumns)
        {
            ui_ndgvGrid.Columns.Clear();
            ui_ndgvGrid.Columns.AddRange(columnsArrayolumns);
        }

        /// <summary>
        /// Adds TextBoxColumn with the given column name and headertext
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="headerText"></param>
        public void AddColumn(String columnName, String headerText)
        {
            ui_ndgvGrid.Columns.Add(columnName, headerText);
        }

        /// <summary>
        /// Clears the collection
        /// </summary>
        public void Clear()
        {
            ui_ndgvGrid.Rows.Clear();
        }

        /// <summary>
        /// Inserts the specified no of rows in to the collection at the specified location
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="noOfRows"></param>
        public void InsertRows(int rowIndex, int noOfRows)
        {
            ui_ndgvGrid.Rows.Insert(rowIndex, noOfRows);
        }

        /// <summary>
        /// Inserts the specified DataGridViewRow into the collection
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="dgvRow"></param>
        public void InsertDataGridViewRow(int rowIndex, DataGridViewRow dgvRow)
        {
            ui_ndgvGrid.Rows.Insert(rowIndex, dgvRow);
        }

        /// <summary>
        /// Removes the specified row from collection
        /// </summary>
        /// <param name="dgvRow"></param>
        public void Remove(DataGridViewRow dgvRow)
        {
            ui_ndgvGrid.Rows.Remove(dgvRow);
        }

        /// <summary>
        /// Removes the row at the specified position from the collection
        /// </summary>
        /// <param name="rowIndex"></param>
        public void RemoveAt(int rowIndex)
        {
            ui_ndgvGrid.Rows.RemoveAt(rowIndex);
        }


        //vijay (CODE FOR METHODS)

        /// <summary>
        /// This method is used to set the visibility of specified column in the datagrid
        /// </summary>
        /// <param name="colIndex">Index of the column</param>
        /// <param name="visibility">Value indicating whether the column is visible or hidden</param>
        public void SetColumnVisiblity(int colIndex, bool visibility)
        {
            ui_ndgvGrid.Columns[colIndex].Visible = visibility;
        }

        /// <summary>
        /// This method is used to set the list of columns visibility in the datagrid
        /// </summary>
        /// <param name="colIndexs">Array of columns indexs</param>
        /// <param name="visibility">Value indicating whether the column is visible or hidden</param>
        public void SetColumnsVisiblity(int[] colIndexs, bool visibility)
        {
            foreach (int item in colIndexs)
            {
                ui_ndgvGrid.Columns[item].Visible = visibility;
            }
        }

        /// <summary>
        /// This method is used to set the font of a specified cell in datagrid
        /// </summary>
        /// <param name="rowIndex">Rowindex of the cell</param>
        /// <param name="colIndex">columnindex of the cell</param>
        /// <param name="newFontFamilly">newFontFamilly to be applied on the cell</param>
        /// <param name="newFontSize">newFontSize to be applied on the cell</param>
        /// <param name="newFontStyle">newFontStyle to be applied on the cell</param>
        public void setCellFont(int rowIndex, int colIndex, string newFontFamilly, float newFontSize,
                                FontStyle newFontStyle)
        {
            var objFont = new Font(newFontFamilly, newFontSize, newFontStyle);
            ui_ndgvGrid.Rows[rowIndex].Cells[colIndex].Style.Font = objFont;
            
        }

        /// <summary>
        /// This method is used to set the font of a specified column in datagrid
        /// </summary>
        /// <param name="colIndex">Index of the specified column</param>
        /// <param name="newFontFamilly">newFontFamilly to be applied on the column</param>
        /// <param name="newFontSize">newFontSize to be applied on the column</param>
        /// <param name="newFontStyle">newFontStyle to be applied on the column</param>
        public void setColumnFont(int colIndex, string newFontFamilly, float newFontSize, FontStyle newFontStyle)
        {
            var objFont = new Font(newFontFamilly, newFontSize, newFontStyle);
            ui_ndgvGrid.Columns[colIndex].DefaultCellStyle.Font = objFont;
        }

        /// <summary>
        /// This method is used to set the font of a specified row in datagrid
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="newFontFamilly">newFontFamilly to be applied on the row</param>
        /// <param name="newFontSize">newFontSize to be applied on the row</param>
        /// <param name="newFontStyle">newFontStyle to be applied on the row</param>
        public void setRowFont(int rowIndex, string newFontFamilly, float newFontSize, FontStyle newFontStyle)
        {
            var objFont = new Font(newFontFamilly, newFontSize, newFontStyle);
            ui_ndgvGrid.Columns[rowIndex].DefaultCellStyle.Font = objFont;
            //ui_ndgvGrid.Columns[rowIndex].DefaultCellStyle.Font = objFont;
        }

        /// <summary>
        /// This method is used to set the Width and/or Fillweidth and/or AutoSizeMode of specified column of grid.
        /// </summary>
        /// <param name="colIndex"></param>
        /// <param name="width"></param>
        /// <param name="fillWeight"></param>
        /// <param name="AutoSizeMode"></param>
        public void setColumnSize(int colIndex, int width, float fillWeight = 100,
                                  DataGridViewAutoSizeColumnMode AutoSizeMode = DataGridViewAutoSizeColumnMode.None)
        {
            try
            {
                ui_ndgvGrid.Columns[colIndex].FillWeight = fillWeight;
                ui_ndgvGrid.Columns[colIndex].Width = width;
                ui_ndgvGrid.Columns[colIndex].AutoSizeMode = AutoSizeMode;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="hight"></param>
        public void setRowHight(int rowIndex, int hight)
        {
            try
            {
                ui_ndgvGrid.Rows[rowIndex].Height = hight;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// This method is used to set the BackColor of a specified cell in datagrid
        /// </summary>
        /// <param name="rowIndex">Rowindex of the cell</param>
        /// <param name="colIndex">columnindex of the cell</param>
        /// <param name="colorName">Specified backcolor name</param>
        public void setCellBackColor(int rowIndex, int colIndex, Color colorName)
        {
            ui_ndgvGrid.Rows[rowIndex].Cells[colIndex].Style.BackColor = colorName;
        }

        /// <summary>
        /// This method is used to set the BackColor of a specified column in datagrid
        /// </summary>
        /// <param name="colIndex">columnindex of the cell</param>
        /// <param name="colorName">Specified backcolor name</param>
        public void setColumnBackColor(int colIndex, Color colorName)
        {
            ui_ndgvGrid.Columns[colIndex].DefaultCellStyle.BackColor = colorName;
        }

        /// <summary>
        /// This method is used to set the BackColor of a specified row in datagrid
        /// </summary>
        /// <param name="rowIndex">Rowindex of the cell</param>
        /// <param name="colorName">Specified backcolor name</param>
        public void setRowBackColor(int rowIndex, Color colorName)
        {
            ui_ndgvGrid.Rows[rowIndex].DefaultCellStyle.BackColor = colorName;
        }

        /// <summary>
        /// This method is used to set the ForeColor of a specified cell in datagrid
        /// </summary>
        /// <param name="rowIndex">Rowindex of the cell</param>
        /// <param name="colIndex">columnindex of the cell</param>
        /// <param name="colorName">Specified forecolor name</param>
        public void setCellForeColor(int rowIndex, int colIndex, Color colorName)
        {
            ui_ndgvGrid.Rows[rowIndex].Cells[colIndex].Style.ForeColor = colorName;
        }

        /// <summary>
        /// This method is used to set the ForeColor of a specified column in datagrid
        /// </summary>
        /// <param name="colHeaderStyle"></param>
        public void setColumnHeaderStyle(DataGridViewCellStyle colHeaderStyle)
        {
            ui_ndgvGrid.ColumnHeadersDefaultCellStyle = colHeaderStyle;
        }

        /// <summary>
        /// This method is used to set the ForeColor of a specified column in datagrid
        /// </summary>
        /// <param name="colIndex">columnindex of the cell</param>
        /// <param name="colorName">Specified forecolor name</param>
        public void setColumnForeColor(int colIndex, Color colorName)
        {
            ui_ndgvGrid.Columns[colIndex].DefaultCellStyle.ForeColor = colorName;
        }

        public void setColumnHeadersHeightSizeMode(DataGridViewColumnHeadersHeightSizeMode columnHeadersHeightSizeMode)
        {
            ui_ndgvGrid.ColumnHeadersHeightSizeMode = columnHeadersHeightSizeMode;
        }

        /// <summary>
        /// This method is used to set the ForeColor of a specified row in datagrid
        /// </summary>
        /// <param name="rowIndex">Rowindex of the cell</param>
        /// <param name="colorName">Specified forecolor name</param>
        public void setRowForeColor(int rowIndex, Color colorName)
        {
            ui_ndgvGrid.Rows[rowIndex].DefaultCellStyle.ForeColor = colorName;
        }

        //END OF VIJAY CODE FOR METHODS

        #endregion

        #region "Events"

        #region Delegates

        public delegate void DataGridViewCellCancelEventHandeler(object sender, DataGridViewCellCancelEventArgs e);

        public delegate void DataGridViewCellEventHandeler(object sender, DataGridViewCellEventArgs e);

        public delegate void DataGridViewCellMouseEventHandeler(object sender, DataGridViewCellMouseEventArgs e);

        public delegate void DataGridViewCellValidatingEventHandeler(
            object sender, DataGridViewCellValidatingEventArgs e);

        public delegate void DataGridViewCellValueNeeded(object sender, DataGridViewCellValueEventArgs e);

        public delegate void DataGridViewCellValuePused(object sender, DataGridViewCellValueEventArgs e);

        public delegate void DataGridViewColumnEventHandeler(object sender, DataGridViewColumnEventArgs e);

        public delegate void DataGridViewColumnHeaderClickHandler(object sender, DataGridViewCellMouseEventArgs e);

        public delegate void DataGridViewDataErrorEventHandeler(object sender, DataGridViewDataErrorEventArgs e);

        public delegate void DataGridViewRowsAddedEventHandeler(object sender, DataGridViewRowsAddedEventArgs e);

        public delegate void DataGridViewRowsRemovedEventHandeler(object sender, DataGridViewRowsRemovedEventArgs e);

        public delegate void EventArgsHandeler(object sender, EventArgs e);

        #endregion

        /// <summary>
        /// Occurs when column header clicked.
        /// </summary>
        public event DataGridViewColumnHeaderClickHandler OnColumnHeaderClick = delegate { };

        /// <summary>
        /// Occurs when cell’s content is clicked.
        /// </summary>
        public event DataGridViewCellEventHandeler OnCellContentClick = delegate { };

        /// <summary>
        /// Occurs when cell is clicked.
        /// </summary>
        public event DataGridViewCellEventHandeler OnCellClick = delegate { };

        /// <summary>
        /// Occurs when cell validation finishes.
        /// </summary>
        public event DataGridViewCellEventHandeler OnCellValidated = delegate { };

        /// <summary>
        /// Occurs when cell receives input.
        /// </summary>
        public event DataGridViewCellEventHandeler OnCellEnter = delegate { };

        /// <summary>
        /// Occurs when cell’s value changed.
        /// </summary>
        public event DataGridViewCellEventHandeler OnCellValueChanged = delegate { };

        /// <summary>
        /// Occurs when cell’s value is edited.
        /// </summary>
        public event DataGridViewCellEventHandeler OnCellEndEdit = delegate { };

        /// <summary>
        /// Occurs when cell mouse up happens.
        /// </summary>
        public event DataGridViewCellMouseEventHandeler OnCellMouseUp = delegate { };

        /// <summary>
        /// Occurs when cell mouse down happens.
        /// </summary>
        public event DataGridViewCellMouseEventHandeler OnCellMouseDown = delegate { };

        /// <summary>
        /// Occurs when an external data-parsing or validation throws exception or update to the datasource fails.
        /// </summary>
        public event DataGridViewDataErrorEventHandeler OnDataError = delegate { };

        /// <summary>
        /// Occurs when grid cell validation happens.
        /// </summary>
        public event DataGridViewCellValidatingEventHandeler OnCellValidating = delegate { };

        /// <summary>
        /// Occurs when cell’s value is about to edit.
        /// </summary>
        public event DataGridViewCellCancelEventHandeler OnCellBeginEdit = delegate { };

        /// <summary>
        /// Occurs when customize menu click happens.
        /// </summary>
        public event EventArgsHandeler OnCustomizeClick = delegate { };

        /// <summary>
        /// Occurs when contextmenustrip of grid is changed.
        /// </summary>
        public new event EventArgsHandeler OnContextMenuStripChanged = delegate { };

        /// <summary>
        /// Occurs when rows are added to grid.
        /// </summary>
        public event DataGridViewRowsAddedEventHandeler OnRowsAdded = delegate { };

        /// <summary>
        /// Occurs when rows are removed from grid.
        /// </summary>
        public event DataGridViewRowsRemovedEventHandeler OnRowsRemoved = delegate { };

        /// <summary>
        /// Occurs when column adds to grid.
        /// </summary>
        public event DataGridViewColumnEventHandeler OnColumnAdded = delegate { };

        /// <summary>
        /// Occurs when column removed from grid.
        /// </summary>
        public event DataGridViewColumnEventHandeler OnColumnRemoved = delegate { };

        /// <summary>
        /// Occurs when cell value is needed
        /// </summary>
        public event DataGridViewCellValueNeeded OnCellValueNeeded = delegate { };

        /// <summary>
        /// Occurs when cell value is pused
        /// </summary>
        public event DataGridViewCellValuePused OnCellValuePused = delegate { };

        /// <summary>
        /// Occurs when mouse is over the control and mouse button clicked
        /// </summary>
        public event MouseEventHandler OnGridMouseDown = delegate { };

        public event Action<object, EventArgs> OnGridMouseOver = delegate { };

        public event Action<object, DataGridViewColumnEventArgs> OnColumnWidthChange = delegate { };

        private void ndgvGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OnCellContentClick(this, e);
        }

        private void ui_ndgvGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OnCellClick(this, e);
        }

        private void ui_ndgvGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            OnCellValidated(this, e);
        }

        private void ui_ndgvGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            OnCellEnter(this, e);
        }

        private void ui_ndgvGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            OnCellMouseUp(this, e);
        }

        private void ui_ndgvGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            OnCellMouseDown(this, e);
        }

        private void ui_ndgvGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            OnCellValidating(this, e);
        }

        private void ui_ndgvGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            OnCellValueChanged(this, e);
        }

        private void ui_ndgvGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            OnCellBeginEdit(sender, e);
        }

        private void ui_ndgvGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            OnCellEndEdit(this, e);
        }

        private void ui_ndgvGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            OnDataError(this, e);
        }

        private void ui_ndgvGrid_ContextMenuStripChanged(object sender, EventArgs e)
        {
            OnContextMenuStripChanged(this, e);
        }

        private void ui_ndgvGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            OnRowsAdded(this, e);
        }

        private void ui_ndgvGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            OnRowsRemoved(this, e);
        }

        private void ui_ndgvGrid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            OnColumnAdded(this, e);
        }

        private void ui_ndgvGrid_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            OnColumnRemoved(this, e);
        }

        private void tsmItem_Click(object sender, EventArgs e)
        {
            OnCustomizeClick(this, e);
        }

        private void ui_ndgvGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OnColumnHeaderClick(this, e);
        }

        private void ui_ndgvGrid_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            OnCellValueNeeded(sender, e);
        }

        private void ui_ndgvGrid_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            OnCellValuePused(sender, e);
        }

        #endregion

        /// <summary>
        /// Displays customize dialog for the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var frmCustomize = new FrmCustomize(this);
            try
            {
            //    FontDialog dlg = new FontDialog();
            //    dlg.ShowDialog();

            //    if (dlg.ShowDialog() == DialogResult.OK)
            //    {
            //        string fontName;
            //        float fontSize;
            //        fontName = dlg.Font.Name;
            //        fontSize = dlg.Font.Size;
            //        dlg.ShowEffects = true;
                    //MessageBox.Show(fontName + "    " + fontSize);
                    
                //}

                frmCustomize.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
            }
        }

        private void SetColumnList()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ui_ndgvGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ui_mnuSizeToFit_Click(object sender, EventArgs e)
        {
            if (ui_mnuSizeToFit.Checked == false)
            {
                ui_mnuSizeToFit.Checked = true;
                //ui_ndgvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            }
            else
            {
                ui_mnuSizeToFit.Checked = false;
                //ui_ndgvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }

        private void ui_mnuGrid_Click(object sender, EventArgs e)
        {
            if (ui_mnuGrid.Checked == false)
            {
                ui_mnuGrid.Checked = true;
                ui_ndgvGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            }
            else
            {
                ui_mnuGrid.Checked = false;
                ui_ndgvGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            }
        }

        private void ui_ndgvGrid_MouseClick(object sender, MouseEventArgs e)
        {
            OnMouseClick(sender);
        }

        public new event Action<object> OnMouseClick = delegate { };
        public event Action<object, DataGridViewCellEventArgs> OnGridCellEnter;

        private void ui_ndgvGrid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (OnGridCellEnter != null)
            {
                OnGridCellEnter(sender, e);
            }
        }

        private void ui_ndgvGrid_MouseDown(object sender, MouseEventArgs e)
        {
            _HitTest = ui_ndgvGrid.HitTest(e.X, e.Y);
            OnGridMouseDown(sender, e);
        }

        private void ui_ndgvGrid_MouseHover(object sender, EventArgs e)
        {
            OnGridMouseOver(sender, e);
        }

        private void ui_ndgvGrid_MouseEnter(object sender, EventArgs e)
        {
        }

        private void ui_ndgvGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ui_ndgvGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            OnColumnWidthChange(sender, e);
        }

        private void ui_mnuSizeToFit_CheckedChanged(object sender, EventArgs e)
        {
            if (ui_mnuSizeToFit.Checked == false)
            {
                ui_ndgvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            }
            else
            {
                ui_ndgvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }
    }

    #region    "     CUSTOMIZE DIALOG        "

    #endregion "     CUSTOMIZE DIALOG        "
}