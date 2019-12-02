using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProtocolStructs.NewPS;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlMapOrders : UserControl
    {
        public uctlMapOrders()
        {
            InitializeComponent();

            Cls.clsMapOrderManager.INSTANCE._DS4MapOrders.dtMapOrders.TableNewRow += new DataTableNewRowEventHandler(dtMapOrders_TableNewRow);
        }

        void dtMapOrders_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            Action A = () =>
                {
                    ui_ndgvMapOrders.Refresh();
                    if (ui_ndgvMapOrders.Rows.Count > 0)
                    {
                        ui_ndgvMapOrders.FirstDisplayedScrollingRowIndex = ui_ndgvMapOrders.Rows.Count - 1;
                    }
                    ui_ndgvMapOrders.ScrollBars = ScrollBars.Both;

                    ui_ncmbAccountID.Items.Clear();
                    ui_ncmbAccountID.Items.AddRange(Cls.clsMapOrderManager.INSTANCE.GetAccountIDs().ToArray());
                    ui_ncmbAccountID.Items.Insert(0, "All");
                };
            if (this.InvokeRequired)
            {
                this.BeginInvoke(A);
            }
            else
            {
                A();
            }
        }

        private void uctlMapOrders_Load(object sender, EventArgs e)
        {
            ui_ndgvMapOrders.DataSource = Cls.clsMapOrderManager.INSTANCE._DS4MapOrders.dtMapOrders;

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ui_ndgvMapOrders.Columns["MapOrderID"].Visible = false;
            ui_ndgvMapOrders.Columns["BuyFillID"].Visible = false;
            ui_ndgvMapOrders.Columns["SellFillID"].Visible = false;
            ui_ndgvMapOrders.Columns["BuyAccountID"].HeaderText = "Buy AccountID";
            ui_ndgvMapOrders.Columns["BuyAccountID"].DefaultCellStyle = cellStyle;
            ui_ndgvMapOrders.Columns["BuyOrderID"].HeaderText = "Buy OrderID";
            ui_ndgvMapOrders.Columns["BuyOrderID"].DefaultCellStyle = cellStyle;
            ui_ndgvMapOrders.Columns["SellAccountID"].HeaderText = "Sell AccountID";
            ui_ndgvMapOrders.Columns["SellAccountID"].DefaultCellStyle = cellStyle;
            ui_ndgvMapOrders.Columns["SellOrderID"].HeaderText = "Sell OrderID";
            ui_ndgvMapOrders.Columns["SellOrderID"].DefaultCellStyle = cellStyle;
            ui_ndgvMapOrders.Columns["BuyFillID"].HeaderText = "Buy FillID";
            ui_ndgvMapOrders.Columns["BuyFillID"].DefaultCellStyle = cellStyle;
            ui_ndgvMapOrders.Columns["SellFillID"].HeaderText = "Sell FillID";
            ui_ndgvMapOrders.Columns["SellFillID"].DefaultCellStyle = cellStyle;
            ui_ndgvMapOrders.Columns["FilledQty"].HeaderText = "Filled Qty";
            ui_ndgvMapOrders.Columns["FilledQty"].DefaultCellStyle = cellStyle;
            ui_ndgvMapOrders.Columns["LastUpdatedTime"].HeaderText = "Last Update Time";
            ui_ndgvMapOrders.Columns["Price"].DefaultCellStyle = cellStyle;

            ui_ncmbAccountID.Items.Clear();
            ui_ncmbAccountID.Items.AddRange(Cls.clsMapOrderManager.INSTANCE.GetAccountIDs().ToArray());
            ui_ncmbAccountType.Items.AddRange(clsMasterInfoManager.INSTANCE.GetClientAccountTypes().ToArray());
            ui_ncmbAccountID.Items.Insert(0, "All");
            ui_ncmbAccountID.SelectedIndex = 0;
            ui_ncmbAccountType.SelectedIndex = 0;
        }

        private void ui_nbtnRefresh_Click(object sender, EventArgs e)
        {
            clsMapOrderManager.INSTANCE.GetMapOrderInfo();
        }

        private void ui_ncmbAccountID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ui_ncmbAccountID.SelectedItem.ToString() == "All")
            {
                ui_ndgvMapOrders.DataSource = Cls.clsMapOrderManager.INSTANCE._DS4MapOrders.dtMapOrders;
                return;
            }

            ui_ndgvMapOrders.DataSource = Cls.clsMapOrderManager.INSTANCE.GetRows(Convert.ToInt32(ui_ncmbAccountID.SelectedItem.ToString()));
        }

        private void ui_ncmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ui_ncmbAccountID.Items.Clear();
            ui_ncmbAccountID.Items.AddRange(clsProxyClassManager.INSTANCE.GetAccountIDsByAccountTypeID(clsMasterInfoManager.INSTANCE
                .GetClientAccountTypeID(ui_ncmbAccountType.SelectedItem.ToString())).ToArray());

            ui_ncmbAccountID.Items.Insert(0, "All");
            ui_ncmbAccountID.SelectedIndex = 0;
        }
    }
}
