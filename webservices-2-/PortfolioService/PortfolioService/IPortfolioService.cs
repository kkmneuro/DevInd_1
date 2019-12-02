using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace PortfolioService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPortfolioService" in both code and config file together.
    [ServiceContract]
    public interface IPortfolioService
    {
        [OperationContract]
        GeneralResult AddDataPortfolio(int userId, string portfolioName);
        [OperationContract]
        GeneralResult AddDataPortfolioInstrument(int userId, string portfolioName, string Exchange, string Symbol, string AlternateSymbol, string ISIN, string MarketSegment, string Security, string ShortName);
        [OperationContract]
        GeneralResult RemoveDataPortfolio(int userId, string portfolioName);
        [OperationContract]
        GeneralResult RemoveDataPortfolioInstrument(int userId, string portfolioName, string exchange, string symbol);
        [OperationContract]
        List<DataPortfolioDTO> GetUserPortfolio(int userId);
        [OperationContract]
        void AddWorkspace(int AccountID,byte[] Workspace);
        [OperationContract]
        byte[] GetWorkspace(int AccountID);
    }
    [DataContract]
    public class GeneralResult : ActionResultOfboolean
    {
       
    }

    [DataContract]
    public enum ResultType
    { [EnumMember] Failure, [EnumMember] Success, [EnumMember] Warning };

    [DataContract]
    public class ActionResultOfboolean
    {
        private string ErrorMessageField;
        private bool ObjectField;
        private ResultType ResultField;

        [DataMember]
        public string ErrorMessage
        {
            set
            {
                ErrorMessageField = value;
            }
            get
            {
                return ErrorMessageField;
            }
        }

        [DataMember]
        public bool Object
        {
            set
            {
                ObjectField = value;
            }
            get
            {
                return ObjectField;
            }
        }
        [DataMember]
        public ResultType Result
        {
            set
            {
                ResultField = value;
            }
            get
            {
                return ResultField;
            }
        }

    }

    [DataContract]
    public class DataPortfolioDTO
    {
        private List<InstrumentDTO> _instrument;
        private string _prortFolioName;


        public DataPortfolioDTO()
        {
            _instrument = new List<InstrumentDTO>();
            _prortFolioName = string.Empty;
        }

        [DataMember]
        public List<InstrumentDTO> Instruments
        {
            get { return _instrument; }
        }

        [DataMember]
        public string PortfolioName
        {
            get { return _prortFolioName; }
            set { _prortFolioName = value; }
        }
    }

   [DataContract]
    public class InstrumentDTO
    {
        private string _AlternateSymbol;
        private string _Exchange;
        private string _ISIN;
        private string _MarketSegment;
        private string _Security;
        private string _ShortName;
        private string _Symbol;

        public InstrumentDTO()
        {
            _AlternateSymbol = string.Empty;
            _Exchange = string.Empty;
            _ISIN = string.Empty;
            _MarketSegment = string.Empty;
            _Security = string.Empty;
            _ShortName = string.Empty;
            _Symbol = string.Empty;
        }

       [DataMember]
        public string AlternateSymbol
        {
            get { return _AlternateSymbol; }
            set { _AlternateSymbol = value; }
        }

       [DataMember]
        public string Exchange
        {
            get { return _Exchange; }
            set { _Exchange = value; }
        }

       [DataMember]
        public string ISIN
        {
            get { return _ISIN; }
            set { _ISIN = value; }
        }

       [DataMember]
        public string MarketSegment
        {
            get { return _MarketSegment; }
            set { _MarketSegment = value; }
        }

       [DataMember]
        public string Security
        {
            get { return _Security; }
            set { _Security = value; }
        }

       [DataMember]
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }

       [DataMember]
        public string Symbol
        {
            get { return _Symbol; }
            set { _Symbol = value; }
        }
    }

}
