using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PALSA.Frm
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = "aaa";
            dr["Column2"] = "wwwww";
            dr["Column3"] = "ssssss";
            dt.Rows.Add(dr);
            dr = dt.NewRow();

            ////Store the DataTable in ViewState
            //// ViewState["CurrentTable"] = dt;
            //Application["CurrentTable"] = dt;
            //Gridview1.DataSource = dt;
            //Gridview1.DataBind();
        }
    }
}
