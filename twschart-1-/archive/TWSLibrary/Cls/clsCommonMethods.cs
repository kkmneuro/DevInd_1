///////REVISION HISTORY/////////////////////////////////////////////////////////////////////////////////////////////////////
//DATE			INITIALS	DESCRIPTION
//13/02/2012	VP          1.Added overloaded method for CreateGridColumn
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CommonLibrary.UserControls;
using Nevron.UI;
using Nevron.UI.WinForm;
using Nevron.UI.WinForm.Controls;
using XLSExportDemo;
using System.Text.RegularExpressions;

namespace CommonLibrary.Cls
{
    public class ClsCommonMethods
    {
        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        /// <param name="column">Column object</param>
        /// <param name="columnName">Name of the column</param>
        /// <param name="headerText">Header text of the column</param>
        /// <returns></returns>
        public static DataGridViewColumn CreateGridColumn(DataGridViewColumn column, string columnName,
                                                          string headerText)
        {
            column = new DataGridViewTextBoxColumn();
            column.Name = columnName;
            column.HeaderText = headerText;

            return column;
        }

        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        /// <param name="column">Column object</param>
        /// <param name="columnName">Name of the column</param>
        /// <param name="headerText">Header text of the column</param>
        /// <param name="columnType">Column type</param>
        /// <returns></returns>
        public static DataGridViewColumn CreateGridColumn(DataGridViewColumn column, string columnName,
                                                          string headerText, DataGridViewColumn columnType)
        {
            column = columnType;
            column.Name = columnName;
            column.HeaderText = headerText;

            return column;
        }

        public static DataGridViewColumn CreateGridColumn(DataGridViewColumn column, string columnName,
                                                          string headerText, bool columnVisiblity)
        {
            column = new DataGridViewTextBoxColumn();
            column.Name = columnName;
            column.HeaderText = headerText;
            column.Visible = columnVisiblity;

            return column;
        }


        public static DialogResult ShowMessageBox(string msg)
        {
            var mydialog = new NTaskDialog { Title = "LTech India" };
            mydialog.Content.Text = msg;
            
            mydialog.Content.Image = NSystemImages.Question;
            var btnyes = new NPushButtonElement {Text = "<b>Yes</b>", Id = 1};
            var btnno = new NPushButtonElement {Text = "<b>No</b>", Id = 2};
            mydialog.UserButtons = new[] {btnyes, btnno};
            
            int result = mydialog.Show();

            switch (result)
            {
                case 1:
                    return DialogResult.Yes;
                case 2:
                    return DialogResult.No;
                case 3:
                    return DialogResult.Cancel;
                default:
                    return DialogResult.Cancel;
            }
        }

        public static DialogResult ShowExitMessageBox(string msg)
        {
            var mydialog = new NTaskDialog { Title = "LTech India" };
            mydialog.Content.UseMnemonic = true;
            mydialog.Content.Text = msg;
            mydialog.Content.Image = NSystemImages.Question;
            mydialog.PreferredWidth =400;
            var btnyes = new NPushButtonElement {Text = "<b>Yes</b>", Id = 1};
            var btnno = new NPushButtonElement {Text = "<b>No</b>", Id = 2};
            var btncancel = new NPushButtonElement {Text = "<b>Cancel</b>", Id = 3};

            mydialog.UserButtons = new[] {btnyes, btnno, btncancel};

            int result = mydialog.Show();

            switch (result)
            {
                case 1:
                    return DialogResult.Yes;
                case 2:
                    return DialogResult.No;
                case 3:
                    return DialogResult.Cancel;
                default:
                    return DialogResult.Cancel;
            }
        }
        public static DialogResult ShowInformation(string msg)
        {
            var mydialog = new NTaskDialog { Title = "LTech India" };
            mydialog.Content.Text = msg;
            mydialog.Content.Image = NSystemImages.Information;
            mydialog.DisplayPosition = TaskDialogDisplayPosition.CenterScreen;            
            var btnok = new NPushButtonElement { Text = "<b>Ok</b>" };
            mydialog.UserButtons = new[] { btnok };
            int result = mydialog.Show();
            switch (result)
            {
                case 1:
                    return DialogResult.OK;
                default:
                    return DialogResult.OK;
            }
        }
        public static DialogResult ShowErrorBox(string msg)
        {
            var mydialog = new NTaskDialog { Title = "LTech India" };
            mydialog.Content.Text = msg;
            mydialog.Content.Image = NSystemImages.Error;
            var btnok = new NPushButtonElement {Text = "<b>Ok</b>"};
            mydialog.UserButtons = new[] {btnok};
            int result = mydialog.Show();
            switch (result)
            {
                case 1:
                    return DialogResult.OK;
                default:
                    return DialogResult.OK;
            }
        }

        public static DialogResult ShowInfoBox(string msg)
        {
            var mydialog = new NTaskDialog { Title = "LTech Indiar" };
            mydialog.Content.Text = msg;
            mydialog.Content.Image = NSystemImages.Information;
            var btnok = new NPushButtonElement {Text = "<b>Ok</b>"};
            var btnclose = new NPushButtonElement {Text = "<b>Close</b>"};
            mydialog.UserButtons = new[] {btnok, btnclose};
            int result = mydialog.Show();
            switch (result)
            {
                case 1:
                    return DialogResult.OK;
                case 2:
                    return DialogResult.OK;
                default:
                    return DialogResult.OK;
            }
        }


        /// <summary>
        /// Saves grid control data in Excel file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="gridControl"></param>
        public static void SaveGridDataInExcel(string fileName, UctlGrid gridControl)
        {
            //Microsoft.Office.Interop.Excel._Application objApplication = new Microsoft.Office.Interop.Excel.Application();
            //objApplication.Application.Workbooks.Add(Type.Missing);

            //// Change properties of the Workbook 
            //objApplication.Columns.ColumnWidth = 20;

            //// Storing header part in Excel
            //for (int i = 1; i < gridControl.Columns.Count + 1; i++)
            //{
            //    objApplication.Cells[1, i] = gridControl.Columns[i - 1].HeaderText;
            //}

            //// Storing Each row and column value to excel sheet
            //for (int i = 0; i < gridControl.Rows.Count ; i++)
            //{
            //    for (int j = 0; j < gridControl.Columns.Count; j++)
            //    {  
            //        if(gridControl.Rows[i].Cells[j].Value!=null)
            //         objApplication.Cells[i + 2, j + 1] = gridControl.Rows[i].Cells[j].Value.ToString();
            //    }
            //}

            //objApplication.ActiveWorkbook.SaveCopyAs(fileName);
            //objApplication.ActiveWorkbook.Saved = true;
            //objApplication.Quit();
            //=====================================================

            var document = new ExcelDocument
                               {UserName = "VinodKumarVarma", CodePage = CultureInfo.CurrentCulture.TextInfo.ANSICodePage};
            document.ColumnWidth(0, 120);
            document.ColumnWidth(1, 80);
            // Storing header part in Excel
            for (int i = 0; i < gridControl.Columns.Count; i++)
            {
                if (gridControl.Columns[i].Visible == true)
                {
                    document[0, i].Value = gridControl.Columns[i].HeaderText;
                    document[0, i].Font = new Font("Tahoma", 10, FontStyle.Bold);
                    document[0, i].ForeColor = ExcelColor.DarkRed;
                    document[0, i].Alignment = Alignment.Centered;
                    document[0, i].BackColor = ExcelColor.Silver;
                }
            }
            // Storing Each row and column value to excel sheet
            for (int i = 0; i < gridControl.Rows.Count; i++)
            {
                for (int j = 0; j < gridControl.Columns.Count; j++)
                {
                    if (gridControl.Rows[i].Cells[j].Value != null && gridControl.Rows[i].Cells[j].Visible==true)
                        document.Cell(i + 1, j).Value = gridControl.Rows[i].Cells[j].Value.ToString();
                }
            }
            var stream = new FileStream(fileName, FileMode.Create);
            document.Save(stream);
            stream.Close();
        }

        public static void SaveGridDataInText(string fileName, UctlGrid gridControl)
        {
            var objFileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            TextWriter objStreamWriter = new StreamWriter(objFileStream);
            int rowcount = gridControl.Rows.Count;
            string dataLine = string.Empty;
            for (int i = 0; i < rowcount - 1; i++)
            {
                for (int j = 0; j < gridControl.Columns.Count; j++)
                {
                    if (gridControl.Rows[i].Cells[j].Value != null && gridControl.Rows[i].Cells[j].Visible == true)
                        dataLine += gridControl.Rows[i].Cells[j].Value.ToString() + "\t";
                }
                objStreamWriter.WriteLine(dataLine);
            }
            objStreamWriter.Close();
        }

        //Code added by vijay on 28 Nov 2012
        /// <summary>
        /// Validattes Email address
        /// </summary>
        /// <param name="ctrlText"></param>
        /// <returns></returns>
        public static bool ValidateEmail(string ctrlText)
        {
            bool flag = true;

            Match objMatch = Regex.Match(ctrlText, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase);
            if (!objMatch.Success)
            {
                flag = false;
            }
            return flag;
        }
    }
}