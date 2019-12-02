using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using clsInterface4OME;

namespace ProtocolStructs.NewPS
{
    public class clsCommonSettingsNewPS : IProtocolStruct
    {
        public clsCommonSettingsNew _CommonSettings;

        public clsCommonSettingsNewPS()
        {
            _CommonSettings = new clsCommonSettingsNew();
        }
        public clsCommonSettingsNewPS(clsCommonSettingsNew deepCopy)
        {
            _CommonSettings._ID = deepCopy._ID;
            _CommonSettings._Property = deepCopy._Property;
            _CommonSettings._Value = deepCopy._Value;

        }
        public override int ID
        {
            get { return ProtocolStructIDS.CommonSettingsNew_ID; }
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

            AppendStr(_CommonSettings._ID);
            AppendStr(_CommonSettings._Property);
            AppendStr(_CommonSettings._Value);

            EndStrW();
        }

        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);

            int ind = -1;

            _CommonSettings._ID = clsUtility.GetInt(SpltString[++ind]);
            _CommonSettings._Property = SpltString[++ind];
            _CommonSettings._Value = SpltString[++ind];

        }
        public override string ToString()
        {
            return _CommonSettings == null ? base.ToString() : _CommonSettings.ToString();
        }
    }
}
