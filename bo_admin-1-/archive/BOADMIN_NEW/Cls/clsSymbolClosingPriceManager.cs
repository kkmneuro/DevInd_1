using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BOADMIN_NEW.BOEngineServiceTCP;
using clsInterface4OME.DSBO;

namespace BOADMIN_NEW.Cls
{
    public class clsSymbolClosingPriceManager
    {
        public DS4InstrumentClosingPrice _DS4InstClosingPrice=new DS4InstrumentClosingPrice();
        static clsSymbolClosingPriceManager _instance = null;
        
        public static clsSymbolClosingPriceManager INSTANCE
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new clsSymbolClosingPriceManager();
                }
                return _instance;
            }
        }

        public void HandleInstClosingPrice(clsInstrumentClosingPrice instClosingPrice)
        {
            DS4InstrumentClosingPrice.dtInstrumentClosingPriceRow row = _DS4InstClosingPrice.dtInstrumentClosingPrice.FindByInstrumentID(
                clsMasterInfoManager.INSTANCE.GetSymbolName(instClosingPrice.FK_InstrumentID));

            if (row == null)
            {
                row = _DS4InstClosingPrice.dtInstrumentClosingPrice.NewRow() as DS4InstrumentClosingPrice.dtInstrumentClosingPriceRow;

                row.InstrumentClosingPrice = instClosingPrice.PK_InstrumentClosingPrice;
                row.InstrumentID = clsMasterInfoManager.INSTANCE.GetSymbolName(instClosingPrice.FK_InstrumentID);
                row.ClosingPrice = Convert.ToDecimal(instClosingPrice.ClosingPrice.ToString("0.00"));
                row.ClosingDate = instClosingPrice.ClosingDate;

                _DS4InstClosingPrice.dtInstrumentClosingPrice.AdddtInstrumentClosingPriceRow(row);
            }
            else
            {
                row.InstrumentClosingPrice = instClosingPrice.PK_InstrumentClosingPrice;
                row.InstrumentID = clsMasterInfoManager.INSTANCE.GetSymbolName(instClosingPrice.FK_InstrumentID);
                row.ClosingPrice = Convert.ToDecimal(instClosingPrice.ClosingPrice.ToString("0.00"));
                row.ClosingDate = instClosingPrice.ClosingDate;
            }
            
        }
    }
}
