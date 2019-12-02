using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clsInterface4OME.DSBO;
using ProtocolStructs.NewPS;
using clsInterface4OME;
using BOADMIN_NEW.BOEngineServiceTCP;
using BOADMIN_NEW.Cls;

namespace BOADMIN_NEW.Uctl
{
    public partial class uctlVirtualDealerChild : UserControl
    {
        public DialogType _dialogMode;
        int _virutalDealerID;
        public uctlVirtualDealerChild()
        {
            InitializeComponent();
        }

        private void ui_npnlControlContainer_Click(object sender, EventArgs e)
        {

        }

        private void ui_nbtnSubmit_Click(object sender, EventArgs e)
        {
            string errorMsg = string.Empty;
            clsVirtualDealerInfo objclsVirtualDealerInfo = new clsVirtualDealerInfo();

            objclsVirtualDealerInfo.Delay = clsUtility.GetInt(ui_ntxtDelay.Text);
            objclsVirtualDealerInfo.VirtualManagerAccount = ui_ntxtVirtualManagerAccount.Text;
            objclsVirtualDealerInfo.Groups = ui_ntxtGroups.Text;
            objclsVirtualDealerInfo.Symbols = ui_ntxtSymbols.Text;
            objclsVirtualDealerInfo.MaximumVolume = clsUtility.GetInt(ui_ntxtMaxVolume.Text);
            objclsVirtualDealerInfo.MaximumLosingSlippage = clsUtility.GetInt(ui_ntxtMaxLosingSlippage.Text);
            objclsVirtualDealerInfo.MaximumProfitSlippage = clsUtility.GetInt(ui_ntxtMaxProfitSlippage.Text);
            objclsVirtualDealerInfo.MaximumProfitSlippageVolume = clsUtility.GetInt(ui_ntxtMaxProfitSlippageVolume.Text);
            objclsVirtualDealerInfo.GapLevel = clsUtility.GetInt(ui_ntxtGapLevel.Text);
            objclsVirtualDealerInfo.GapSafeLevel = clsUtility.GetInt(ui_ntxtGapSafeLevel.Text);
            objclsVirtualDealerInfo.GapTickCounter = clsUtility.GetInt(ui_ntxtGapTickCounter.Text);
            objclsVirtualDealerInfo.GapPendingCancel = clsUtility.GetInt(ui_ntxtGapPendingsCancel.Text);
            objclsVirtualDealerInfo.GapTakeProfitSlide = clsUtility.GetInt(ui_ntxtGapTakeProfitSlide.Text);
            objclsVirtualDealerInfo.GapStopLossSlide = clsUtility.GetInt(ui_ntxtGapStopLossSlide.Text);
            objclsVirtualDealerInfo.NewsStopsFreezes = clsUtility.GetInt(ui_ntxtNewsStopsFreezes.Text);
            objclsVirtualDealerInfo.AllowPendingsOnNews = clsUtility.GetInt(ui_ntxtAllowPendingsOnNews.Text);

            if (_dialogMode == DialogType.Edit)
            {
                errorMsg = "Error in updating Virtual Dealer";
                objclsVirtualDealerInfo.VirtualDealerID = _virutalDealerID;
               objclsVirtualDealerInfo= Cls.clsProxyClassManager.INSTANCE.UpdateVirtualDealer(objclsVirtualDealerInfo);
            }
            else
            {
                errorMsg = "Error in inserting Virtual Dealer";
                objclsVirtualDealerInfo.VirtualDealerID = ProtocolStructs.ProtocolStructIDS.DBInsert;
                objclsVirtualDealerInfo=Cls.clsProxyClassManager.INSTANCE.InsertVirtualDealer(objclsVirtualDealerInfo);
            }
            if (objclsVirtualDealerInfo.ServerResponseID != clsGlobal.FailureID)
            {
                clsVirtualDealerManager.INSTANCE.DoHandleVirtualDealer(objclsVirtualDealerInfo);
            }
            else if (objclsVirtualDealerInfo.ServerResponseID == clsGlobal.FailureID)
            {
                clsDialogBox.ShowErrorBox(errorMsg, "BOAdmin", true);
            }

            this.ParentForm.Close();
        }

        public void SetValues(DS4VirtualDealer.dtVirtualDealerRow row)
        {
            if (_dialogMode == DialogType.Edit)
            {
                _virutalDealerID = row.VirtualDealerID;

                ui_ntxtDelay.Text = row.Delay.ToString();
                ui_ntxtVirtualManagerAccount.Text = row.VirtualManagerAccount;
                ui_ntxtGroups.Text = row.Groups;
                ui_ntxtSymbols.Text = row.Symbols;
                ui_ntxtMaxVolume.Text = row.MaxVolume.ToString();
                ui_ntxtMaxLosingSlippage.Text = row.MaxLosingSlippage.ToString();
                ui_ntxtMaxProfitSlippage.Text = row.MaxProfitSlippage.ToString();
                ui_ntxtMaxProfitSlippageVolume.Text = row.MaxProfitSlippageVolume.ToString();
                ui_ntxtGapLevel.Text = row.GapLevel.ToString();
                ui_ntxtGapSafeLevel.Text = row.GapSafeLevel.ToString();
                ui_ntxtGapTickCounter.Text = row.GapTickCounter.ToString();
                ui_ntxtGapPendingsCancel.Text = row.GapPendingsCancel.ToString();
                ui_ntxtGapTakeProfitSlide.Text = row.GapTakeProfitSlide.ToString();
                ui_ntxtGapStopLossSlide.Text = row.GapStopLossSlide.ToString();
                ui_ntxtNewsStopsFreezes.Text = row.NewsStopFreezes.ToString();
                ui_ntxtAllowPendingsOnNews.Text = row.AllowPedningsOnNews.ToString();    
            }
            else
            {

            }
        }

        private void ui_nbtnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ui_ntxtMaxVolume_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void ui_ntxtMaxVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
