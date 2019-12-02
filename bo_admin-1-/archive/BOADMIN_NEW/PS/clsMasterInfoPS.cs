using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using clsInterface4OME;

namespace ProtocolStructs
{
    public class clsMasterInfoPS:IProtocolStruct
    {
        clsMasterInfo _objclsMasterInfo;
        public clsMasterInfoPS()
        {
            _objclsMasterInfo = new clsMasterInfo();
        }

        public clsMasterInfoPS(clsMasterInfo deepCopy)
        {
            _objclsMasterInfo._lstSecurityType = deepCopy._lstSecurityType;
            _objclsMasterInfo._lstSettlingCurrency = deepCopy._lstSettlingCurrency;
            _objclsMasterInfo._lstMarginCurrency = deepCopy._lstMarginCurrency;
            _objclsMasterInfo._lstDeliveryType = deepCopy._lstDeliveryType;
            _objclsMasterInfo._lstDeliveryUnit = deepCopy._lstDeliveryUnit;
        }

        public override int ID
        {
            get { return  ProtocolStructIDS.MasterInfo_ID; }
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

            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._SecurityCount; iSessionLoop++)
            {
                AppendStr(_objclsMasterInfo._lstSecurityType[iSessionLoop]);
            }

            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._SettlingCurrencyCount; iSessionLoop++)
            {
                AppendStr(_objclsMasterInfo._lstSettlingCurrency[iSessionLoop]);
            }
            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._MarginCurrecnyCount; iSessionLoop++)
            {
                AppendStr(_objclsMasterInfo._lstMarginCurrency[iSessionLoop]);
            }

            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._DeliveryTypeCount; iSessionLoop++)
            {
                AppendStr(_objclsMasterInfo._lstDeliveryType[iSessionLoop]);
            }

            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._DeliveryUnitCount; iSessionLoop++)
            {
                AppendStr(_objclsMasterInfo._lstDeliveryUnit[iSessionLoop]);
            }

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            int ind = -1;
            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._SecurityCount; iSessionLoop++)
            {
                _objclsMasterInfo._lstSecurityType.Add(SpltString[++ind]);
            }

            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._SettlingCurrencyCount; iSessionLoop++)
            {
                _objclsMasterInfo._lstSettlingCurrency.Add(SpltString[++ind]);
            }

            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._MarginCurrecnyCount; iSessionLoop++)
            {
                _objclsMasterInfo._lstMarginCurrency.Add(SpltString[++ind]);
            }
            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._DeliveryTypeCount; iSessionLoop++)
            {
                _objclsMasterInfo._lstDeliveryType.Add(SpltString[++ind]);
            }
            for (int iSessionLoop = 0; iSessionLoop < _objclsMasterInfo._DeliveryUnitCount; iSessionLoop++)
            {
                _objclsMasterInfo._lstDeliveryUnit.Add(SpltString[++ind]);
            }
        }
    }
}
