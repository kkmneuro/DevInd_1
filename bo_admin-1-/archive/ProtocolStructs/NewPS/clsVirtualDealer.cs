using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolStructs.NewPS
{
    public class clsVirtualDealer
    {
        public int _virtualDealerID;
        public int _delay;
        public string _virtualManagerAccount;
        public string _groups;
        public string _symbols;
        public decimal _maximumVolume;
        public int _maximumLosingSlippage;
        public int _maximumProfitSlippage;
        public int _maximumProfitSlippageVolume;
        public int _gapLevel;
        public int _gapSafeLevel;
        public int _gapTickCounter;
        public int _gapPendingCancel;
        public int _gapTakeProfitSlide;
        public int _gapStopLossSlide;
        public int _newsStopsFreezes;
        public int _allowPendingsOnNews;

        public clsVirtualDealer()
        {
            _virtualDealerID = 0;
            _delay = 0;
            _virtualManagerAccount = string.Empty;
            _groups = string.Empty;
            _symbols = string.Empty;
            _maximumVolume = 0;
            _maximumLosingSlippage = 0;
            _maximumProfitSlippage = 0;
            _maximumProfitSlippageVolume = 0;
            _gapLevel = 0;
            _gapSafeLevel = 0;
            _gapTickCounter = 0;
            _gapPendingCancel = 0;
            _gapTakeProfitSlide = 0;
            _gapStopLossSlide = 0;
            _newsStopsFreezes = 0;
            _allowPendingsOnNews = 0;
        }

        public override string ToString()
        {
            return "_virtualDealerID" + _virtualDealerID+
            "_delay "+_delay+
            "_virtualManagerAccount" +_virtualManagerAccount+
            "_groups"+_groups+
            "_symbols"+ _symbols+
            "_maximumVolume"+_maximumVolume+
            "_maximumLosingSlippage"+_maximumLosingSlippage +
            "_maximumProfitSlippage" +_maximumProfitSlippage+
            "_maximumProfitSlippageVolume"+_maximumProfitSlippageVolume+
            "_gapLevel" +_gapLevel+
            "_gapSafeLevel"+_gapSafeLevel+
            "_gapTickCounter "+_gapTickCounter+
            "_gapPendingCancel "+_gapPendingCancel+
            "_gapTakeProfitSlide" +_gapTakeProfitSlide+
            "_gapStopLossSlide" +_gapStopLossSlide+
            "_newsStopsFreezes "+_newsStopsFreezes+
            "_allowPendingsOnNews" + _allowPendingsOnNews;
        }
    }
}
