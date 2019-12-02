using System;
using System.Collections.Generic;
using System.Text;
using clsInterface4OME;
namespace ProtocolStructs
{
    public class SecurityGroupPS : IProtocolStruct
    {
        public SecurityGroup _SecurityGroup;
        public SecurityGroupPS()
        {
            _SecurityGroup = new SecurityGroup();
        }
        public SecurityGroupPS(SecurityGroup deepCopy)
        {
            _SecurityGroup._AutoCloseOut = deepCopy._AutoCloseOut;
            _SecurityGroup._Commission = deepCopy._Commission;
            _SecurityGroup._CommissionAgent = deepCopy._CommissionAgent;
            _SecurityGroup._EnableCloseBy = deepCopy._EnableCloseBy;
            _SecurityGroup._EnableGroup = deepCopy._EnableGroup;
            _SecurityGroup._EnableTrade = deepCopy._EnableTrade;
            _SecurityGroup._Execution = deepCopy._Execution;
            _SecurityGroup._IsActive = deepCopy._IsActive;
            _SecurityGroup._MaximumDeviation = deepCopy._MaximumDeviation;
            _SecurityGroup._MaxLotsInaMonths = deepCopy._MaxLotsInaMonths;
            _SecurityGroup._MinLotsInaMonths = deepCopy._MinLotsInaMonths;
            _SecurityGroup._MultipleCloseByOrders = deepCopy._MultipleCloseByOrders;
            _SecurityGroup._SecurityID = deepCopy._SecurityID;
            _SecurityGroup._Spread = deepCopy._Spread;
            _SecurityGroup._Steps = deepCopy._Steps;
            _SecurityGroup._Taxes = deepCopy._Taxes;
            _SecurityGroup._Unit = deepCopy._Unit;
            _SecurityGroup._Volume = deepCopy._Volume;
        }
        public override int ID
        {
            get { return ProtocolStructIDS.SecurityGroup_ID; }
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
            AppendStr(_SecurityGroup._AutoCloseOut);
            AppendStr(_SecurityGroup._Commission);
            AppendStr(_SecurityGroup._CommissionAgent);
            AppendStr(_SecurityGroup._EnableCloseBy);
            AppendStr(_SecurityGroup._EnableGroup);
            AppendStr(_SecurityGroup._EnableTrade);
            AppendStr(_SecurityGroup._Execution);
            AppendStr(_SecurityGroup._IsActive);
            AppendStr(_SecurityGroup._MaximumDeviation);
            AppendStr(_SecurityGroup._MaxLotsInaMonths);
            AppendStr(_SecurityGroup._MinLotsInaMonths);
            AppendStr(_SecurityGroup._MultipleCloseByOrders);
            AppendStr(_SecurityGroup._SecurityID);
            AppendStr(_SecurityGroup._Spread);
            AppendStr(_SecurityGroup._Steps);
            AppendStr(_SecurityGroup._Taxes);
            AppendStr(_SecurityGroup._Unit);
            AppendStr(_SecurityGroup._Volume);
            EndStrW();
        }
        public override void ReadString(string Msgbfr)
        {
            StartStrR(Msgbfr);
            _SecurityGroup._AutoCloseOut = SpltString[0];
            _SecurityGroup._Commission = clsUtility.GetDecimal(SpltString[1]);
            _SecurityGroup._CommissionAgent = clsUtility.GetDecimal(SpltString[2]);
            _SecurityGroup._EnableCloseBy =Convert.ToBoolean(SpltString[3]);
            _SecurityGroup._EnableGroup =Convert.ToBoolean(SpltString[4]);
            _SecurityGroup._EnableTrade = Convert.ToBoolean(SpltString[5]);
            _SecurityGroup._Execution = SpltString[6];
            _SecurityGroup._IsActive = Convert.ToBoolean(SpltString[7]);
            _SecurityGroup._MaximumDeviation = clsUtility.GetInt(SpltString[8]);
            _SecurityGroup._MaxLotsInaMonths = clsUtility.GetDecimal(SpltString[9]);
            _SecurityGroup._MinLotsInaMonths = clsUtility.GetDecimal(SpltString[10]);
            _SecurityGroup._MultipleCloseByOrders = Convert.ToBoolean(SpltString[11]);
            _SecurityGroup._SecurityID = SpltString[12];
            _SecurityGroup._Spread =clsUtility.GetDecimal(SpltString[13]);
            _SecurityGroup._Steps = clsUtility.GetDecimal(SpltString[14]);
            _SecurityGroup._Taxes = clsUtility.GetDecimal(SpltString[15]);
            _SecurityGroup._Unit = SpltString[16];
            _SecurityGroup._Volume = SpltString[17];
        }
        public override string ToString()
        {

            return _SecurityGroup==null?base.ToString():_SecurityGroup.ToString();
        }

        public override bool ValidateData()
        {
            throw new NotImplementedException();
        }
    }
}
