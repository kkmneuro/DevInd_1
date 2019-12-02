using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolStructs
{
    public class SecurityGroup
    {
        public string _SecurityID;
        public bool _EnableGroup;
        public bool _EnableTrade;
        public string _Execution;
        public int _MaximumDeviation;
        public decimal _MinLotsInaMonths;
        public decimal _MaxLotsInaMonths;
        public decimal _Steps;
        public decimal _Commission;
        public decimal _Taxes;
        public decimal _Spread;
        public decimal _CommissionAgent;
        public bool _EnableCloseBy;
        public bool _MultipleCloseByOrders;
        public string _AutoCloseOut;
        public string _Volume;
        public string _Unit;
        public bool _IsActive;

        public SecurityGroup()
        {
            _SecurityID = string.Empty;
            _EnableGroup = true;
            _EnableTrade = true;
            _Execution = string.Empty;
            _MaximumDeviation = 0;
            _MinLotsInaMonths = 0;
            _MaxLotsInaMonths = 0;
            _Steps = 0;
            _Commission = 0;
            _Taxes = 0;
            _Spread = 0;
            _CommissionAgent = 0;
            _EnableCloseBy = true;
            _MultipleCloseByOrders = true;
            _AutoCloseOut = string.Empty;
            _Volume = string.Empty;
            _Unit = string.Empty;
            _IsActive = true;

        }
        public override string ToString()
        {
            return
            "_SecurityID->" + _SecurityID +
            "_EnableGroup->" + _EnableGroup +
            "_EnableTrade->" + _EnableTrade +
            "_Execution->" + _Execution +
            "_MaximumDeviation->" + _MaximumDeviation +
            "_MinLotsInaMonths->" + _MinLotsInaMonths +
            "_MaxLotsInaMonths->" + _MaxLotsInaMonths +
            "_Steps->" + _Steps +
            "_Commission->" + _Commission +
            "_Taxes->" + _Taxes +
            "_Spread->" + _Spread +
            "_CommissionAgent->" + _CommissionAgent +
            "_EnableCloseBy->" + _EnableCloseBy +
            "_MultipleCloseByOrders->" + _MultipleCloseByOrders +
            "_AutoCloseOut->" + _AutoCloseOut +
            "_Volume->" + _Volume +
            "_Unit->" + _Unit +
            "_IsActive->" + _IsActive;
        }
    }
}
