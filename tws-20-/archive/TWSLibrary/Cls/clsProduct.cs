using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.Cls
{
    [Serializable]
    public class clsProduct
    {
        public clsProduct()
        { }
        public clsProduct(int instId, int symbolCode,string symbol,string instrumentName,
        string series,float strikePrice,string optionType,string tradingCurrency)
        {
            _instrumentId=instId;
            _symbolCode=symbolCode;
            _symbol=symbol;
            _instrumentName=instrumentName;
            _series=series;
            _strikePrice=strikePrice;
            _optionType=optionType;
            _tradingCurrency=tradingCurrency;
        }
        int    _instrumentId;
        int    _symbolCode;  
        string _symbol;    
        string _instrumentName;
        string _series;
        float  _strikePrice;
        string _optionType;
        string _tradingCurrency;


        public int InstrumentId
        {
            get { return _instrumentId; }
            set { _instrumentId = value; }
        }

        public int SymbolCode
        {
            get { return _symbolCode; }
            set { _symbolCode = value; }
        }

        public string InstrumentName
        {
            get { return _instrumentName; }
            set { _instrumentName = value; }
        }

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public string Series
        {
            get { return _series; }
            set { _series = value; }
        }

        public float StrikePrice
        {
            get { return _strikePrice; }
            set { _strikePrice = value; }
        }

        public string OptionType
        {
            get { return _optionType; }
            set { _optionType = value; }
        }

        public string TradingCurrency
        {
            get { return _tradingCurrency; }
            set { _tradingCurrency = value; }
        }
    }
}
