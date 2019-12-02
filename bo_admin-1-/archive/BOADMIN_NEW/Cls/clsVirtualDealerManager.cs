using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolStructs.NewPS;
using clsInterface4OME.DSBO;
using BOADMIN_NEW.BOEngineServiceTCP;

namespace BOADMIN_NEW.Cls
{
    class clsVirtualDealerManager : IclsManager
    {
        static clsVirtualDealerManager _instance = null;
        public DS4VirtualDealer _DS4virtualDealer = new DS4VirtualDealer();
        private clsVirtualDealerManager()
        {

        }

        public static clsVirtualDealerManager INSTANCE
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new clsVirtualDealerManager();
                }
                return _instance;
            }
        }

        public void FillDataToDataSet(List<clsVirtualDealerInfo> lstVirtualDealer)
        {
            foreach (clsVirtualDealerInfo virtualDealer in lstVirtualDealer)
            {
                DoHandleVirtualDealer(virtualDealer);
            }
        }

        public void DoHandleVirtualDealer(clsVirtualDealerInfo virtualDealer)
        {
            try
            {
                DS4VirtualDealer.dtVirtualDealerRow row = _DS4virtualDealer.dtVirtualDealer.FindByVirtualDealerID(virtualDealer.VirtualDealerID);

                if (row == null)
                {
                    row = (DS4VirtualDealer.dtVirtualDealerRow)_DS4virtualDealer.dtVirtualDealer.NewRow();

                    row.VirtualDealerID = virtualDealer.VirtualDealerID;
                    row.Delay = virtualDealer.Delay;
                    row.VirtualManagerAccount = virtualDealer.VirtualManagerAccount;
                    row.Groups = virtualDealer.Groups;
                    row.Symbols = virtualDealer.Symbols;
                    row.MaxVolume = Convert.ToDecimal(virtualDealer.MaximumVolume.ToString("0.00"));
                    row.MaxLosingSlippage = virtualDealer.MaximumLosingSlippage;
                    row.MaxProfitSlippage = virtualDealer.MaximumProfitSlippage;
                    row.MaxProfitSlippageVolume = virtualDealer.MaximumProfitSlippageVolume;
                    row.GapLevel = virtualDealer.GapLevel;
                    row.GapSafeLevel = virtualDealer.GapSafeLevel;
                    row.GapTickCounter = virtualDealer.GapTickCounter;
                    row.GapPendingsCancel = virtualDealer.GapPendingCancel;
                    row.GapTakeProfitSlide = virtualDealer.GapTakeProfitSlide;
                    row.GapStopLossSlide = virtualDealer.GapStopLossSlide;
                    row.NewsStopFreezes = virtualDealer.NewsStopsFreezes;
                    row.AllowPedningsOnNews = virtualDealer.AllowPendingsOnNews;

                    _DS4virtualDealer.dtVirtualDealer.AdddtVirtualDealerRow(row);
                }
                else
                {
                    row.VirtualDealerID = virtualDealer.VirtualDealerID;
                    row.Delay = virtualDealer.Delay;
                    row.VirtualManagerAccount = virtualDealer.VirtualManagerAccount;
                    row.Groups = virtualDealer.Groups;
                    row.Symbols = virtualDealer.Symbols;
                    row.MaxVolume = Convert.ToDecimal(virtualDealer.MaximumVolume.ToString("0.00"));
                    row.MaxLosingSlippage = virtualDealer.MaximumLosingSlippage;
                    row.MaxProfitSlippage = virtualDealer.MaximumProfitSlippage;
                    row.MaxProfitSlippageVolume = virtualDealer.MaximumProfitSlippageVolume;
                    row.GapLevel = virtualDealer.GapLevel;
                    row.GapSafeLevel = virtualDealer.GapSafeLevel;
                    row.GapTickCounter = virtualDealer.GapTickCounter;
                    row.GapPendingsCancel = virtualDealer.GapPendingCancel;
                    row.GapTakeProfitSlide = virtualDealer.GapTakeProfitSlide;
                    row.GapStopLossSlide = virtualDealer.GapStopLossSlide;
                    row.NewsStopFreezes = virtualDealer.NewsStopsFreezes;
                    row.AllowPedningsOnNews = virtualDealer.AllowPendingsOnNews;

                }
            }
            catch (Exception)
            {
                //Logging.FileHandling.WriteAllLog("Exception :clsVirtualDealerManager => Type " + ex.GetType().FullName + "ExceptionMessage " + ex.Message +
                   // "ExceptionSource " + ex.Source + "StackTrace" + ex.StackTrace + "in DoHandleVirtualDealer()");
            }
            _DS4virtualDealer.AcceptChanges();
            _DS4virtualDealer.dtVirtualDealer.AcceptChanges();

        }

        public void RemoveSetting(int DataKey)
        {
            if (_DS4virtualDealer.dtVirtualDealer.FindByVirtualDealerID(DataKey) != null)
            {
                lock (_DS4virtualDealer)
                {
                    _DS4virtualDealer.dtVirtualDealer.RemovedtVirtualDealerRow(_DS4virtualDealer.dtVirtualDealer.FindByVirtualDealerID(DataKey));
                }
            }
        }

        public override void ServerRequestResponse(ProtocolStructs.DBResponse response)
        {

        }

        public override void AddSetting(ProtocolStructs.IProtocolStruct PS)
        {
            throw new NotImplementedException();
        }

        public override void RemoveSetting(string DataKey)
        {
            throw new NotImplementedException();
        }
    }
}
