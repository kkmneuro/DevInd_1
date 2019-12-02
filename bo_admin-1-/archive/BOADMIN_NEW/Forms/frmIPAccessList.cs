using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOADMIN_NEW.Forms
{
    public partial class frmIPAccessList : FrmBase
    {
        private static frmIPAccessList _Instance = null;

        public static frmIPAccessList INSTANCE
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmIPAccessList();
                }
                return _Instance;
            }
        }

       // bool _crtState=true;
       // FormWindowState windowState=FormWindowState.Normal;
        Size _ipAccessSize;
        public frmIPAccessList()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.favicon;
        }

        private void frmIPAccessList_Resize(object sender, EventArgs e)
        {
            //Form1 newMDIChild = new Form1();
            //newMDIChild.MdiParent = this;
            //newMDIChild.Show();
            //this.LayoutMdi(MdiLayout.Cascade);
            //this.ParentForm.LayoutMdi(MdiLayout.Cascade);
            //if (windowState == FormWindowState.Maximized)
            //{
            //    this.windowState = FormWindowState.Normal;
                //this.Dock = DockStyle.Fill;
            //}
             //this.rectang= this.MdiParent.Bounds
            //frmIPAccessList_Paint(null, null);
            //if (this.Size == _ipAccessSize)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            //    this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X, Screen.PrimaryScreen.WorkingArea.Y);
            //}
            //else if (this.Size == new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height))
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    this.Size = new Size(491, 217);
            //    this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X, Screen.PrimaryScreen.WorkingArea.Y);
            //}

            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            //    this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X, Screen.PrimaryScreen.WorkingArea.Y);
            //}
            //if (_crtState == false && this.WindowState == FormWindowState.Maximized)
            //{
            //    _crtState = true;
            //    this.WindowState = FormWindowState.Normal;
            //    this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            //    this.Location = new Point(Screen.PrimaryScreen.WorkingArea.X, Screen.PrimaryScreen.WorkingArea.Y);
            //}
            //else if (_crtState == true && this.Size == new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height))//_crtState == true && this.WindowState == FormWindowState.Normal)
            //{
            //    _crtState = false;
            //    this.WindowState = FormWindowState.Normal;
            //    this.Size = new Size(491, 217);
            //    //491, 217
            //}
            //else
            //{
            //    _crtState = false;
            //}
        }

        private void frmIPAccessList_Load(object sender, EventArgs e)
        {
            _ipAccessSize = this.Size;
        }

        private void frmIPAccessList_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
