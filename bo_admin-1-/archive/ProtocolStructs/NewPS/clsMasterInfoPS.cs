using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using clsInterface4OME;

namespace ProtocolStructs.NewPS
{
    public class clsMasterInfoPS:IProtocolStruct
    {
        public clsMasterInfo _objclsMasterInfo;
        public clsMasterInfoPS()
        {
            _objclsMasterInfo = new clsMasterInfo();
        }

        public clsMasterInfoPS(clsMasterInfo deepCopy)
        {
            _objclsMasterInfo._lstDeliveryUnitCount = deepCopy._lstDeliveryUnitCount;
            _objclsMasterInfo._lstOrderTypesCount = deepCopy._lstOrderTypesCount;
            _objclsMasterInfo._lstProductNamesCount = deepCopy._lstProductNamesCount;
            _objclsMasterInfo._lstDataTypesCount = deepCopy._lstDataTypesCount;
            _objclsMasterInfo._lstIdleTimeOutCount = deepCopy._lstIdleTimeOutCount;
            _objclsMasterInfo._lstReconnectAfterCount = deepCopy._lstReconnectAfterCount;
            _objclsMasterInfo._lstDeliveryUnit = deepCopy._lstDeliveryUnit;
            _objclsMasterInfo._lstProductNames = deepCopy._lstProductNames;
            _objclsMasterInfo._lstOrderTypes = deepCopy._lstOrderTypes;
            _objclsMasterInfo._lstDataTypes = deepCopy._lstDataTypes;
            _objclsMasterInfo._lstReconnectAfter = deepCopy._lstReconnectAfter;
            _objclsMasterInfo._lstIdleTimeOut = deepCopy._lstIdleTimeOut;
            _objclsMasterInfo._DDRoles = deepCopy._DDRoles;
            _objclsMasterInfo._RolesCount = deepCopy._RolesCount;
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
            AppendStr(_objclsMasterInfo._lstDeliveryUnitCount);
            AppendStr(_objclsMasterInfo._lstOrderTypesCount);
            AppendStr(_objclsMasterInfo._lstProductNamesCount);
            AppendStr(_objclsMasterInfo._lstDataTypesCount);
            AppendStr(_objclsMasterInfo._lstIdleTimeOutCount);
            AppendStr(_objclsMasterInfo._lstReconnectAfterCount);
            AppendStr(_objclsMasterInfo._DDRoles.Keys.Count);
            foreach (var deliveryUnit in _objclsMasterInfo._lstDeliveryUnit)
            {
                AppendStr(deliveryUnit);
            }

            foreach (var products in _objclsMasterInfo._lstProductNames)
            {
                AppendStr(products);
            }

            foreach (var orderTypes in _objclsMasterInfo._lstOrderTypes)
            {
                AppendStr(orderTypes);
            }

            foreach (var dataTypes in _objclsMasterInfo._lstDataTypes)
            {
                AppendStr(dataTypes);
            }

            foreach (var idletimeout in _objclsMasterInfo._lstIdleTimeOut)
            {
                AppendStr(idletimeout);
            }

            foreach (var reconnectAfter in _objclsMasterInfo._lstReconnectAfter)
            {
                AppendStr(reconnectAfter);
            }

            foreach (KeyValuePair<int,string> item in _objclsMasterInfo._DDRoles)
            {
                AppendStr(item.Key);
                AppendStr(item.Value);
            }

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            int ind = -1;
            _objclsMasterInfo._lstDeliveryUnitCount=clsUtility.GetInt(SpltString[++ind]);
            _objclsMasterInfo._lstOrderTypesCount = clsUtility.GetInt(SpltString[++ind]);
            _objclsMasterInfo._lstProductNamesCount = clsUtility.GetInt(SpltString[++ind]);
            _objclsMasterInfo._lstDataTypesCount = clsUtility.GetInt(SpltString[++ind]);
            _objclsMasterInfo._lstIdleTimeOutCount = clsUtility.GetInt(SpltString[++ind]);
            _objclsMasterInfo._lstReconnectAfterCount = clsUtility.GetInt(SpltString[++ind]);
            _objclsMasterInfo._RolesCount = clsUtility.GetInt(SpltString[++ind]);
            for (int i = 0; i < _objclsMasterInfo._lstDeliveryUnitCount; i++)
            {
                _objclsMasterInfo._lstDeliveryUnit.Add(SpltString[++ind]);
            }

            for (int i = 0; i < _objclsMasterInfo._lstOrderTypesCount; i++)
            {
                _objclsMasterInfo._lstOrderTypes.Add(SpltString[++ind]);
            }

            for (int i = 0; i < _objclsMasterInfo._lstProductNamesCount; i++)
            {
                _objclsMasterInfo._lstProductNames.Add(SpltString[++ind]);
            }

            for (int i = 0; i < _objclsMasterInfo._lstDataTypesCount; i++)
            {
                _objclsMasterInfo._lstDataTypes.Add(SpltString[++ind]);
            }

            for (int i = 0; i < _objclsMasterInfo._lstIdleTimeOutCount; i++)
            {
                _objclsMasterInfo._lstIdleTimeOut.Add(SpltString[++ind]);
            }

            for (int i = 0; i < _objclsMasterInfo._lstReconnectAfterCount; i++)
            {
                _objclsMasterInfo._lstReconnectAfter.Add(SpltString[++ind]);
            }

            for (int i = 0; i < _objclsMasterInfo._RolesCount; i++)
            {
                _objclsMasterInfo._DDRoles.Add(clsUtility.GetInt(SpltString[++ind]), SpltString[++ind]);
            }
        }
    }
}
