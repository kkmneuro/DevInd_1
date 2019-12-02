using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TWS.Cls;
using System.Reflection;

namespace TWS.Frm
{
    public partial class frmRiskMonitor : frmBase
    {
        private object _profiles;
        DataTable dtRiskMonitor;
        public frmRiskMonitor(object profiles)
        {
            InitializeComponent();
            _profiles = profiles;
            // parentForm = _parentForm;
            uctlRiskMonitor1.ui_uctlGridRiskMonitor.EnableCellCustomDraw = false;
        }

        private void frmRiskMonitor_Load(object sender, EventArgs e)
        {
            var ContextMenuItems = new ToolStripMenuItem[1];
            ResizeRedraw = false;
            Width = MdiParent.Width - 20;
            MainMenuStrip = MdiParent.MainMenuStrip;
            ContextMenuItems[0] = new ToolStripMenuItem("View");
            ContextMenuItems[0].Name = "View";
            ContextMenuItems[0].Enabled = false;
            ContextMenuItems[0].Click += OnViewClick;
            uctlRiskMonitor1.ui_uctlGridRiskMonitor.ContextMenuStrip.Items.AddRange(ContextMenuItems);
            clsTWSOrderManagerJSON.INSTANCE.OnPositionUpdate -= new Action<int>(INSTANCE_OnPositionUpdate);            
            clsTWSDataManagerJSON.INSTANCE.OnNetPositionUpdate -= new Action<List<int>>(INSTANCE_OnNetPositionUpdate);            
            DoubleBuffered(uctlRiskMonitor1.ui_uctlGridRiskMonitor.ui_ndgvGrid, true);
            dtRiskMonitor = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtRiskMonitor;
            GetAccountPositions();
            uctlRiskMonitor1.ui_uctlGridRiskMonitor.DataSource = dtRiskMonitor;
            clsTWSDataManagerJSON.INSTANCE.OnNetPositionUpdate += new Action<List<int>>(INSTANCE_OnNetPositionUpdate);
            clsTWSOrderManagerJSON.INSTANCE.OnPositionUpdate += new Action<int>(INSTANCE_OnPositionUpdate);
        }


        public new void DoubleBuffered(DataGridView dgv, bool setting)
        {

            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                                                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);

        }

        void INSTANCE_OnNetPositionUpdate(List<int> lstAccount)
        {
            foreach (int item in lstAccount)
            {
                UpdateAccountPositions(item);
                //System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ThreadPoolHandler), item);
            }
        }

        void INSTANCE_OnPositionUpdate(int accountID)
        {
            UpdateAccountPositions(accountID);
            //System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ThreadPoolHandler), accountID);
        }

        private void GetAccountPositions()
        {
            try
            {
                DataTable dt = clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.DefaultView.ToTable(true, "AccountNo");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rw in dt.Rows)
                    {
                        int account = 0;
                        int.TryParse(rw["AccountNo"].ToString().Trim(), out account);
                        UpdateAccountPositions(account);
                        //System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ThreadPoolHandler), account);

                    }
                }
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.ToString());

            }
        }

        public void ThreadPoolHandler(object account)
        {
            UpdateAccountPositions((int)account);
        }

        private void UpdateAccountPositions(int AccountId)
        {
            if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo, 1000))
            {
                try
                {
                    DataRow[] rwAc = clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo.Select("AccountId=" + AccountId);
                    if (rwAc.Length > 0)
                    {
                        double Balance = 0;
                        double MarginLevel = 0;
                        double UsedMargin = 0;
                        double FreeMargin = 0;
                        double Equity = 0;
                        double ProfitLoss = 0;
                        double UR_PL = 0;
                        //  double margin = 0;
                        int index = -1;
                        if (System.Threading.Monitor.TryEnter(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition, 1000))
                        {
                            try
                            {
                                UR_PL = Math.Round(Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Compute("Sum(UR_PL)", "")), 2);
                                double _tempUR_PL = Math.Round(Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Compute("Sum(UR_PL)", "AccountNo=" + AccountId)), 2);
                                double.TryParse(rwAc[0]["Balance"].ToString().Trim(), out Balance);
                                double.TryParse(rwAc[0]["UsedMargin"].ToString().Trim(), out UsedMargin);
                                UsedMargin = Math.Round(UsedMargin, 2);
                                Equity = Math.Round(Balance + _tempUR_PL, 2);
                                FreeMargin = Math.Round(Equity - UsedMargin, 2);
                                if (UsedMargin > 0)
                                {
                                    MarginLevel = Math.Round(Equity / UsedMargin * 100, 2);
                                }

                                double _prevUR_PL = 0;
                                DataRow[] rw = dtRiskMonitor.Select("AccountNo = '" + AccountId.ToString() + "'");
                                if (rw.Length > 0)
                                {
                                    index = dtRiskMonitor.Rows.IndexOf(rw[0]);
                                    double.TryParse(rw[0]["UR_PL"].ToString().Trim(), out _prevUR_PL);
                                    rw[0]["AccountNo"] = AccountId.ToString();
                                    rw[0]["Balance"] = Balance;
                                    if (MarginLevel > 0)
                                    {
                                        rw[0]["MarginLevel"] = MarginLevel;
                                    }
                                    else
                                    {
                                        rw[0]["MarginLevel"] = "";
                                    }
                                    rw[0]["UsedMargin"] = UsedMargin;
                                    rw[0]["FreeMargin"] = FreeMargin;
                                    rw[0]["Equity"] = Equity;
                                    rw[0]["ProfitLoss"] = ProfitLoss;
                                    rw[0]["UR_PL"] = _tempUR_PL;
                                    if (clsTWSOrderManagerJSON.INSTANCE._DDAccountTraderName.ContainsKey(AccountId))
                                    {
                                        rw[0]["TraderName"] = clsTWSOrderManagerJSON.INSTANCE._DDAccountTraderName[AccountId];
                                    }
                                    rw[0].AcceptChanges();

                                }
                                else
                                {

                                    DataRow newRow = dtRiskMonitor.NewRow();
                                    _prevUR_PL = _tempUR_PL;
                                    newRow["AccountNo"] = AccountId.ToString();
                                    newRow["Balance"] = Balance;
                                    if (MarginLevel > 0)
                                    {
                                        newRow["MarginLevel"] = MarginLevel;
                                    }
                                    else
                                    {
                                        newRow["MarginLevel"] = "";
                                    }
                                    // newRow["MarginLevel"] = MarginLevel;
                                    newRow["UsedMargin"] = UsedMargin;
                                    newRow["FreeMargin"] = FreeMargin;
                                    newRow["Equity"] = Equity;
                                    newRow["ProfitLoss"] = ProfitLoss;
                                    newRow["UR_PL"] = _tempUR_PL;
                                    if (clsTWSOrderManagerJSON.INSTANCE._DDAccountTraderName.ContainsKey(AccountId))
                                    {
                                        newRow["TraderName"] = clsTWSOrderManagerJSON.INSTANCE._DDAccountTraderName[AccountId];
                                    }
                                    dtRiskMonitor.Rows.Add(newRow);

                                    index = dtRiskMonitor.Rows.IndexOf(newRow);
                                }
                                dtRiskMonitor.AcceptChanges();

                                uctlRiskMonitor1.TotalBuyQty = Math.Round(Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Compute("Sum(BuyQty)", "")), 2).ToString();
                                uctlRiskMonitor1.TotalSellQty = Math.Round(Convert.ToDouble(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition.Compute("Sum(SellQty)", "")), 2).ToString();
                                uctlRiskMonitor1.TotalUsedMargin = Math.Round(Convert.ToDouble(dtRiskMonitor.Compute("Sum(UsedMargin)", "")), 2).ToString();
                                uctlRiskMonitor1.TotalMargin = Math.Round(Convert.ToDouble(dtRiskMonitor.Compute("Sum(FreeMargin)", "")), 2).ToString();
                                uctlRiskMonitor1.Equity = Math.Round(Convert.ToDouble(dtRiskMonitor.Compute("Sum(Equity)", "")), 2).ToString();
                                uctlRiskMonitor1.TotalPnL = UR_PL.ToString();

                                if (uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows.Count > 0)
                                {
                                    if (index > -1 && _tempUR_PL > _prevUR_PL)
                                    {
                                        uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["ClmImage"].Value = null;
                                        uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["ClmImage"].Value = Image.FromFile(Application.StartupPath + "\\Resx\\UpArrow.png");
                                        uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["clmURPL"].Style.BackColor = uctlRiskMonitor1.UpTrendColor;
                                        uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["clmURPL"].Style.ForeColor = Color.White;
                                    }
                                    else if (index > -1 && _tempUR_PL < _prevUR_PL)
                                    {
                                        uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["ClmImage"].Value = null;
                                        uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["ClmImage"].Value = Image.FromFile(Application.StartupPath + "\\Resx\\DownArrow.png");
                                        uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["clmURPL"].Style.BackColor = uctlRiskMonitor1.DownTrendColor;
                                        uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["clmURPL"].Style.ForeColor = Color.White;
                                    }
                                    //else
                                    //{
                                    //    uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["ClmImage"].Value = null;
                                    //    uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["clmURPL"].Style.BackColor = Color.Black;
                                    //    uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[index].Cells["clmURPL"].Style.ForeColor = Color.White;
                                    //}
                                }

                            }
                            catch (Exception)
                            {
                                //MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtNetPosition);
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    // MessageBox.Show(ex.ToString());
                }
                finally
                {
                    System.Threading.Monitor.Exit(clsTWSOrderManagerJSON.INSTANCE.accountInfoDS.dtAccountInfo);
                }
            }
        }


        /// <summary>
        /// Called when user select the View option from the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnViewClick(object sender, EventArgs e)
        {
            if (uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows.Count > 0 && uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[uctlRiskMonitor1.ui_uctlGridRiskMonitor.SelectedRows[0].Index].Cells["clmAccount"].Value.ToString() != "")
            {
                DataGridViewRow selectedRow = uctlRiskMonitor1.ui_uctlGridRiskMonitor.SelectedRows[0];
                openNetPosition(Convert.ToInt32(selectedRow.Cells["clmAccount"].Value.ToString().Trim()));
            }

        }

        private void uctlRiskMonitor1_OnGridMouseDown(object arg1, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo = uctlRiskMonitor1.ui_uctlGridRiskMonitor.HitTest;
            if (hitTestInfo.RowIndex < 0)
            {
                uctlRiskMonitor1.ui_uctlGridRiskMonitor.ContextMenuStrip.Items["View"].Enabled = false;
            }
            else
            {
                if (uctlRiskMonitor1.ui_uctlGridRiskMonitor.SelectedRows.Count > 0)
                {
                    uctlRiskMonitor1.ui_uctlGridRiskMonitor.ContextMenuStrip.Items["View"].Enabled = true;
                    if (e.Clicks == 2 && e.Button == MouseButtons.Left)//Double Click
                    {
                        if (uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows.Count > 0 && uctlRiskMonitor1.ui_uctlGridRiskMonitor.Rows[uctlRiskMonitor1.ui_uctlGridRiskMonitor.SelectedRows[0].Index].Cells["clmAccount"].Value.ToString() != "")
                        {
                            DataGridViewRow selectedRow = uctlRiskMonitor1.ui_uctlGridRiskMonitor.SelectedRows[0];
                            openNetPosition(Convert.ToInt32(selectedRow.Cells["clmAccount"].Value.ToString().Trim()));
                        }
                    }
                }
            }
        }

        private void openNetPosition(int AccountId)
        {
            var objfrmNetPosition = new frmNetPosition(_profiles, string.Empty, AccountId);
            objfrmNetPosition.MdiParent = FrmMain.INSTANCE;
            objfrmNetPosition.Show();
        }

        private void frmRiskMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void frmRiskMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cls.clsTWSOrderManagerJSON.INSTANCE.OnPositionUpdate -= new Action<int>(INSTANCE_OnPositionUpdate);
            clsTWSOrderManagerJSON.INSTANCE.OnPositionUpdate -= new Action<int>(INSTANCE_OnPositionUpdate);
            clsTWSDataManagerJSON.INSTANCE.OnNetPositionUpdate -= new Action<List<int>>(INSTANCE_OnNetPositionUpdate);
            clsTWSOrderManagerJSON.INSTANCE.netpositionDS.dtRiskMonitor.Clear();
        }
    }
}
