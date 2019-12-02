using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlVirtualDealer : UserControl
    {
        public uctlVirtualDealer()
        {
            InitializeComponent();

            Cls.clsVirtualDealerManager.INSTANCE._DS4virtualDealer.dtVirtualDealer.RowChanged += new DataRowChangeEventHandler(dtVirtualDealer_RowChanged);
        }

        void dtVirtualDealer_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            Action A = () =>
            {
                ui_ndgvVirtualDealer.Refresh();
            };
            if (ui_ndgvVirtualDealer.InvokeRequired)
            {
                ui_ndgvVirtualDealer.BeginInvoke(A);

            }
            else
            {
                A();
            }
        }

        private void ui_ndgvVirtualDealer_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hInfo = ui_ndgvVirtualDealer.HitTest(e.X, e.Y);

            if (hInfo.RowIndex >= 0 && e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                DisplayDialog(DialogType.Edit);
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (hInfo.RowIndex >= 0)
                {
                    ui_mnuEdit.Enabled = true;
                    ui_mnuDelete.Enabled = true;
                }
                else
                {
                    ui_mnuEdit.Enabled = false;
                    ui_mnuDelete.Enabled = false;
                }
            }
        }

        private void ui_mnuDelete_Click(object sender, EventArgs e)
        {
            uctlDelete Delete = new uctlDelete();
            Delete._MGR = Cls.clsVirtualDealerManager.INSTANCE;
            Delete._DBDelete._DeleteID = ProtocolStructs.ProtocolStructIDS.VirtualDealer_ID;
            Delete._DBDelete._DeleteKey = ui_ndgvVirtualDealer.SelectedRows[0].Cells["VirtualDealerID"].Value.ToString();
            Delete._ContainerCaption = "Delete Virtual Dealer";
            Delete.ShowDialog();
        }

        private void ui_mnuEdit_Click(object sender, EventArgs e)
        {
            DisplayDialog(DialogType.Edit);
        }

        private void ui_mnuAdd_Click(object sender, EventArgs e)
        {
            DisplayDialog(DialogType.New);
        }

        public void DisplayDialog(DialogType dType)
        {
            uctlVirtualDealerChild objuctlVirtualDealerChild = new uctlVirtualDealerChild();
            Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
            objfrmCommonContainer.Controls.Add(objuctlVirtualDealerChild);
            objfrmCommonContainer.ClientSize = objuctlVirtualDealerChild.Size;
            objuctlVirtualDealerChild._dialogMode = dType;
            if (ui_ndgvVirtualDealer.SelectedRows.Count > 0)
            {
                DS4VirtualDealer.dtVirtualDealerRow row = Cls.clsVirtualDealerManager.INSTANCE._DS4virtualDealer.dtVirtualDealer.FindByVirtualDealerID((int)ui_ndgvVirtualDealer.SelectedRows[0].Cells["VirtualDealerID"].Value);
                objuctlVirtualDealerChild.SetValues(row);
            }
            if (dType == DialogType.Edit)
            {
                objfrmCommonContainer.Text = "Edit";
            }
            else
            {
                objfrmCommonContainer.Text = "Add";
            }
            objfrmCommonContainer.ShowDialog();
        }

        private void uctlVirtualDealer_Load(object sender, EventArgs e)
        {
            ui_ndgvVirtualDealer.DataSource = Cls.clsVirtualDealerManager.INSTANCE._DS4virtualDealer.dtVirtualDealer;

            ui_ndgvVirtualDealer.Columns["VirtualDealerID"].Visible = false;
            ui_ndgvVirtualDealer.Columns["VirtualManagerAccount"].HeaderText = "Virtual Manager Account";
            ui_ndgvVirtualDealer.Columns["MaxVolume"].HeaderText = "Max Volume";
            ui_ndgvVirtualDealer.Columns["MaxLosingSlippage"].HeaderText = "Max Losing Slippage";
            ui_ndgvVirtualDealer.Columns["MaxProfitSlippage"].HeaderText = "Max Profit Slippage";
            ui_ndgvVirtualDealer.Columns["MaxProfitSlippageVolume"].HeaderText = "Max Profit Slippage Volume";
            ui_ndgvVirtualDealer.Columns["GapLevel"].HeaderText = "Gap Level";
            ui_ndgvVirtualDealer.Columns["GapSafeLevel"].HeaderText = "Gap Safe Level";
            ui_ndgvVirtualDealer.Columns["GapTickCounter"].HeaderText = "Gap Tick Counter";
            ui_ndgvVirtualDealer.Columns["GapPendingsCancel"].HeaderText = "Gap Pendings Cancel";
            ui_ndgvVirtualDealer.Columns["GapTakeProfitSlide"].HeaderText = "Gap Take Profit Slide";
            ui_ndgvVirtualDealer.Columns["GapStopLossSlide"].HeaderText = "Gap Stop Loss Slide";
            ui_ndgvVirtualDealer.Columns["NewsStopFreezes"].HeaderText = "News Stop Freezes";
            ui_ndgvVirtualDealer.Columns["AllowPedningsOnNews"].HeaderText = "Allow Pednings On News";
        }
    }
}
