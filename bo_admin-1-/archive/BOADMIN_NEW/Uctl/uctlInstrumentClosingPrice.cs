using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BOADMIN_NEW.BOEngineServiceTCP;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlInstrumentClosingPrice : UserControl
    {
         
        public uctlInstrumentClosingPrice()
        {
            InitializeComponent();

            clsSymbolClosingPriceManager.INSTANCE._DS4InstClosingPrice.dtInstrumentClosingPrice.TableNewRow += new DataTableNewRowEventHandler(dtInstrumentClosingPrice_TableNewRow);      
        }

        void dtInstrumentClosingPrice_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            RefreshMe();
        }

        void RefreshMe()
        {
            Action A = () =>
            {
                ui_ndgvInstrumentClosingPrice.ScrollBars = ScrollBars.None;
                ui_ndgvInstrumentClosingPrice.Refresh();

                if (ui_ndgvInstrumentClosingPrice.Rows.Count > 0)
                {
                    ui_ndgvInstrumentClosingPrice.FirstDisplayedScrollingRowIndex = ui_ndgvInstrumentClosingPrice.Rows.Count - 1;
                }

                ui_ndgvInstrumentClosingPrice.ScrollBars = ScrollBars.Both;
            };
            if (ui_ndgvInstrumentClosingPrice.InvokeRequired)
            {
                ui_ndgvInstrumentClosingPrice.BeginInvoke(A);

            }
            else
            {
                A();
            }
        }

        private void ui_contextmnuCommonAdd_Click(object sender, EventArgs e)
        {
            HandleMenuClick(DialogType.New);
        }

        private void ui_contextmnuCommonEdit_Click(object sender, EventArgs e)
        {
            HandleMenuClick(DialogType.Edit);
        }

        private void HandleMenuClick(DialogType type)
        {
            Forms.frmCommonContainer objfrmCommonContainer = new BOADMIN_NEW.Forms.frmCommonContainer();
            uctlClosingPriceChild objuctlClosingPriceChild = new uctlClosingPriceChild();
            objuctlClosingPriceChild._dialogType = type;
            objfrmCommonContainer.Controls.Clear();
            objfrmCommonContainer.Controls.Add(objuctlClosingPriceChild);
            if (type == DialogType.Edit)
            {
                objfrmCommonContainer.Text = "Edit";
                string strIDColumn = (clsSymbolClosingPriceManager.INSTANCE._DS4InstClosingPrice.dtInstrumentClosingPrice).InstrumentIDColumn.Caption;
                if (ui_ndgvInstrumentClosingPrice.SelectedRows.Count==0 && ui_ndgvInstrumentClosingPrice.SelectedRows[0].Cells[strIDColumn].Value == null)
                {
                    return;
                }
                string ID = (string)ui_ndgvInstrumentClosingPrice.SelectedRows[0].Cells[strIDColumn].Value;
                objuctlClosingPriceChild.SetValues(clsSymbolClosingPriceManager.INSTANCE._DS4InstClosingPrice.dtInstrumentClosingPrice.FindByInstrumentID(ID));
            }
            else
            {
                objfrmCommonContainer.Text = "Add";
            }
            objfrmCommonContainer.ShowDialog();
        }

        private void ui_ndgvInstrumentClosingPrice_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ui_ndgvInstrumentClosingPrice.Rows.Count == 0)
            {
                //ui_cmsGateway.Items[1].Enabled = false;
                return;
            }
            //DataGridView.HitTestInfo hitinfo = ui_ndgvInstrumentClosingPrice.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Left) //&& hitinfo.RowIndex >= 0)
            {
                if (e.Clicks == 2 && e.Button == MouseButtons.Left)//Double Click
                {
                    HandleMenuClick(DialogType.Edit);
                }
            }
        }

        private void uctlInstrumentClosingPrice_Load(object sender, EventArgs e)
        {
            ui_ndgvInstrumentClosingPrice.DataSource = clsSymbolClosingPriceManager.INSTANCE._DS4InstClosingPrice.dtInstrumentClosingPrice;

            ui_ndgvInstrumentClosingPrice.Columns["InstrumentClosingPrice"].HeaderText = "Symbol Closing Price";
            ui_ndgvInstrumentClosingPrice.Columns["InstrumentClosingPrice"].Visible = false;
            ui_ndgvInstrumentClosingPrice.Columns["InstrumentID"].HeaderText = "Symbol";
            ui_ndgvInstrumentClosingPrice.Columns["ClosingPrice"].HeaderText = "Closing Price";
            ui_ndgvInstrumentClosingPrice.Columns["ClosingDate"].HeaderText = "Closing Date";
        }
    }
}
