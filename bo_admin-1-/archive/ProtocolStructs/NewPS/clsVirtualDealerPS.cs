using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using clsInterface4OME;

namespace ProtocolStructs.NewPS
{
    public class clsVirtualDealerPS:IProtocolStruct
    {
        public clsVirtualDealer _virtualDealer;

        public clsVirtualDealerPS()
        {
            _virtualDealer = new clsVirtualDealer();
        }

        public clsVirtualDealerPS(clsVirtualDealer deepCopy)
        {
            _virtualDealer._virtualDealerID = deepCopy._virtualDealerID;
            _virtualDealer._delay = deepCopy._delay;
            _virtualDealer._virtualManagerAccount = deepCopy._virtualManagerAccount;
            _virtualDealer._groups = deepCopy._groups;
            _virtualDealer._symbols = deepCopy._symbols;
            _virtualDealer._maximumVolume = deepCopy._maximumVolume;
            _virtualDealer._maximumLosingSlippage = deepCopy._maximumLosingSlippage;
            _virtualDealer._maximumProfitSlippage = deepCopy._maximumProfitSlippage;
            _virtualDealer._maximumProfitSlippageVolume = deepCopy._maximumProfitSlippageVolume;
            _virtualDealer._gapLevel = deepCopy._gapLevel;
            _virtualDealer._gapSafeLevel = deepCopy._gapSafeLevel;
            _virtualDealer._gapTickCounter = deepCopy._gapTickCounter;
            _virtualDealer._gapPendingCancel = deepCopy._gapPendingCancel;
            _virtualDealer._gapTakeProfitSlide = deepCopy._gapTakeProfitSlide;
            _virtualDealer._gapStopLossSlide = deepCopy._gapStopLossSlide;
            _virtualDealer._newsStopsFreezes = deepCopy._newsStopsFreezes;
            _virtualDealer._allowPendingsOnNews = deepCopy._allowPendingsOnNews;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.VirtualDealer_ID; }
        }

        public override void StartWrite(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void StartRead(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        public override void WriteString()
        {
            StartStrW();

            AppendStr(_virtualDealer._virtualDealerID);
            AppendStr(_virtualDealer._delay);
            AppendStr(_virtualDealer._virtualManagerAccount);
            AppendStr(_virtualDealer._groups);
            AppendStr(_virtualDealer._symbols);
            AppendStr(_virtualDealer._maximumVolume);
            AppendStr(_virtualDealer._maximumLosingSlippage);
            AppendStr(_virtualDealer._maximumProfitSlippage);
            AppendStr(_virtualDealer._maximumProfitSlippageVolume);
            AppendStr(_virtualDealer._gapLevel);
            AppendStr(_virtualDealer._gapSafeLevel);
            AppendStr(_virtualDealer._gapTickCounter);
            AppendStr(_virtualDealer._gapPendingCancel);
            AppendStr(_virtualDealer._gapTakeProfitSlide);
            AppendStr(_virtualDealer._gapStopLossSlide);
            AppendStr(_virtualDealer._newsStopsFreezes);
            AppendStr(_virtualDealer._allowPendingsOnNews);

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            int ind = -1;

            _virtualDealer._virtualDealerID = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._delay = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._virtualManagerAccount = SpltString[++ind];
            _virtualDealer._groups = SpltString[++ind];
            _virtualDealer._symbols = SpltString[++ind];
            _virtualDealer._maximumVolume = clsUtility.GetDecimal(SpltString[++ind]);
            _virtualDealer._maximumLosingSlippage = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._maximumProfitSlippage = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._maximumProfitSlippageVolume = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._gapLevel = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._gapSafeLevel = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._gapTickCounter = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._gapPendingCancel = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._gapTakeProfitSlide = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._gapStopLossSlide = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._newsStopsFreezes = clsUtility.GetInt(SpltString[++ind]);
            _virtualDealer._allowPendingsOnNews = clsUtility.GetInt(SpltString[++ind]);        
        }
    }
}
