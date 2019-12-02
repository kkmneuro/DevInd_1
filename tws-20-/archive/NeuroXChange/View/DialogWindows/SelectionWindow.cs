using NeuroXChange.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroXChange.View.DialogWindows
{
    public partial class SelectionWindow : Form
    {
        public SelectionEnum status;
        public MainWindow mWindow;
        public SelectionWindow()
        {
            InitializeComponent();
        }

        public SelectionWindow(MainWindow mainWindow)
        {
            mWindow = mainWindow;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTraningSession_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Function not implemented.");
            status = SelectionEnum.Training;
            Close();
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            status = SelectionEnum.Trade;
            Close();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            status = SelectionEnum.Reports;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }
    }
}
