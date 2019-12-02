using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary.Cls;

namespace CommonLibrary.UserControls
{
    public partial class UctlMailBox : UserControl
    {
        public UctlMailBox()
        {
            InitializeComponent();
            DataGridViewColumn[] columnsArray = new DataGridViewColumn[3];
            columnsArray[0] = ClsCommonMethods.CreateGridColumn(columnsArray[0], "ClmTime", "Time");
            columnsArray[0].DataPropertyName = "Time";
            columnsArray[1] = ClsCommonMethods.CreateGridColumn(columnsArray[1], "ClmFrom", "From");
            columnsArray[1].DataPropertyName = "From";
            columnsArray[2] = ClsCommonMethods.CreateGridColumn(columnsArray[2], "ClmSubject", "Subject");
            columnsArray[2].DataPropertyName = "Subject";
            AddColumnsToGrid(columnsArray);


        }
        public event Action<object, DataGridViewCellEventArgs> OnCellClick;
        /// <summary>
        /// This method adds columns to the user grid control at run time
        /// </summary>
        public void AddColumnsToGrid(DataGridViewColumn[] columnsArray)
        {
            ui_uctlGridMailBox.AddColumns(columnsArray);
        }

        private void ui_uctlGridMailBox_OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            OnCellClick(sender, e);
        }

        private void UctlMailBox_Load(object sender, EventArgs e)
        {
            //Kul
            ui_uctlGridMailBox.ColumnHeadersCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
